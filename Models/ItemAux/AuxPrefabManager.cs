using CoreKeeperPetSkillEditor.Models.Pet;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace CoreKeeperPetSkillEditor.Models.ItemAux;

public class AuxPrefabManager
{
    public List<AuxPrefab> Prefabs { get; private set; }

    public AuxPrefabManager(JsonObject json)
    {
        Prefabs = json["prefabs"]!
            .AsArray()
            .Select(prefabNode =>
                JsonSerializer.Deserialize<AuxPrefab>(
                    prefabNode!.ToJsonString())!)
            .ToList();
    }

    public AuxPrefabManager(List<AuxPrefab> prefabs)
    {
        Prefabs = prefabs;
    }

    public IEnumerable<string> GetData(
        ulong prefabHash,
        ulong stableTypeHash)
    {
        var prefab = Prefabs.SingleOrDefault(
            p => p.prefabHash == prefabHash);

        if (prefab is null)
        {
            throw new InvalidOperationException(
                $"Prefab {prefabHash} was not found.");
        }

        var stableType = prefab.types.SingleOrDefault(
            t => t.stableTypeHash == stableTypeHash);

        if (stableType is null)
        {
            throw new InvalidOperationException(
                $"Stable type {stableTypeHash} was not found.");
        }

        return stableType.data;
    }

    public void UpdateData(
        ulong prefabHash,
        ulong stableTypeHash,
        IEnumerable<string> newData)
    {
        var prefab = Prefabs.SingleOrDefault(
            p => p.prefabHash == prefabHash);

        if (prefab is null)
        {
            throw new InvalidOperationException(
                $"Prefab {prefabHash} was not found.");
        }

        var stableType = prefab.types.SingleOrDefault(
            t => t.stableTypeHash == stableTypeHash);

        if (stableType is null)
        {
            throw new InvalidOperationException(
                $"Stable type {stableTypeHash} was not found.");
        }

        stableType.data = newData;
    }

    public string GetJsonString()
    {
        if (Prefabs.Count == 0)
        {
            return string.Empty;
        }

        var jsonObject = new JsonObject
        {
            ["prefabs"] = new JsonArray(
                Prefabs
                    .Select(p =>
                        JsonSerializer.SerializeToNode(p))
                    .ToArray())
        };

        return jsonObject.ToJsonString();
    }
    public static AuxPrefabManager CreatePet(
    string petName,
    int color,
    IEnumerable<PetTalent> talents)
    {
        var prefabs = new List<AuxPrefab>
    {
        new(
            AuxHash.ItemNameGroupHash,
            [
                new AuxStableType(
                    AuxHash.ItemNameHash,
                    [petName])
            ]),

        new(
            AuxHash.PetGroupHash,
            [
                new AuxStableType(
                    AuxHash.PetColorHash,
                    [color.ToString()]),

                new AuxStableType(
                    AuxHash.PetTalentsHash,
                    talents
                        .Select(t => t.ToJsonString()))
            ])
    };

        return new AuxPrefabManager(prefabs);
    }
}