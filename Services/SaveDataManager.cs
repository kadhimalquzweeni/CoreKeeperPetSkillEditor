using CoreKeeperPetSkillEditor.Models.ItemAux;
using CoreKeeperPetSkillEditor.Models.Items;
using CoreKeeperPetSkillEditor.Models.Pet;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace CoreKeeperPetSkillEditor.Services;

public class SaveDataManager
{
    public string SaveDataPath { get; private set; } =
        string.Empty;

    public JsonObject SaveData { get; private set; } =
        new();

    public List<Item> Items { get; private set; } = [];

    public List<Pet> LoadSaveFile(string filePath)
    {
        SaveDataPath = filePath;

        string json = File.ReadAllText(filePath);

        // Core Keeper saves can contain the non-standard value Infinity.
        // System.Text.Json cannot parse it directly.
        json = SanitizeJsonString(json);

        SaveData = JsonNode.Parse(json)!.AsObject();

        var inventory =
            SaveData["inventory"]!.AsArray();

        var inventoryNames =
            SaveData["inventoryObjectNames"]!.AsArray();

        var inventoryAux =
            SaveData["inventoryAuxData"]!.AsArray();

        Items.Clear();

        var pets = new List<Pet>();

        for (int i = 0; i < inventory.Count; i++)
        {
            var inventoryItem = inventory[i]!.AsObject();

            int objectId =
                inventoryItem["objectID"]!.GetValue<int>();

            int amount =
                inventoryItem["amount"]!.GetValue<int>();

            int variation =
                inventoryItem["variation"]!.GetValue<int>();

            int variationUpdateCount =
                inventoryItem["variationUpdateCount"]!
                    .GetValue<int>();

            string keyName =
                inventoryNames[i]!.GetValue<string>();

            var auxNode =
                inventoryAux[i]!.AsObject();

            int auxIndex =
                auxNode["index"]!.GetValue<int>();

            string auxData =
                auxNode["data"]!.GetValue<string>();

            var item = new Item(
                objectId,
                amount,
                variation,
                variationUpdateCount,
                keyName,
                new ItemAuxData(
                    auxIndex,
                    auxData));

            Items.Add(item);

            if (Pet.IsPet(objectId))
            {
                pets.Add(new Pet(item, i));
            }
        }

        return pets;
    }
    private static string SanitizeJsonString(string json)
    {
        return json.Replace("Infinity", "\"Infinity\"");
    }

    private static string RestoreJsonString(string json)
    {
        return json.Replace("\"Infinity\"", "Infinity");
    }
    public void SavePet(Pet pet)
    {
        if (SaveData is null)
        {
            throw new InvalidOperationException(
                "No Core Keeper save file has been loaded.");
        }

        if (string.IsNullOrWhiteSpace(SaveDataPath))
        {
            throw new InvalidOperationException(
                "No save file path has been loaded.");
        }

        // Create a backup only if one does not already exist.
        string backupPath = SaveDataPath + ".backup";

        if (!File.Exists(backupPath))
        {
            File.Copy(SaveDataPath, backupPath);
        }

        int index = pet.InventoryIndex;

        // Update the pet's inventory data.
        var itemData = new
        {
            objectID = pet.objectID,
            amount = pet.amount,
            variation = pet.variation,
            variationUpdateCount = pet.variationUpdateCount
        };

        SaveData["inventory"]![index] =
            JsonNode.Parse(JsonSerializer.Serialize(itemData));

        SaveData["inventoryObjectNames"]![index] =
            pet.keyName;

        // Update the pet's AUX data containing the talents.
        SaveData["inventoryAuxData"]![index] =
            JsonNode.Parse(JsonSerializer.Serialize(pet.Aux));

        // Important:
        // Prevent Core Keeper from potentially rolling back
        // the edited inventory from the previous session.
        ResetLastActiveSession();

        string changedJson =
            SaveData.ToJsonString(
                new JsonSerializerOptions
                {
                    WriteIndented = true
                });

        changedJson = RestoreJsonString(changedJson);

        File.WriteAllText(
            SaveDataPath,
            changedJson);
    }

    private void ResetLastActiveSession()
    {
        if (!SaveData.TryGetPropertyValue(
                "lastActiveSession",
                out JsonNode? lastActiveSessionNode)
            || lastActiveSessionNode is null)
        {
            // Older save versions might not contain this.
            return;
        }

        if (lastActiveSessionNode["Value"] is not JsonObject valueObject)
        {
            return;
        }

        valueObject["x"] = 0;
        valueObject["y"] = 0;
        valueObject["z"] = 0;
        valueObject["w"] = 0;

        SaveData["lastActiveSession"]!["Value"] =
            valueObject;
    }
}