using System.Text.Json.Nodes;
using System.Collections.Generic;

namespace CoreKeeperPetSkillEditor.Models.ItemAux;

public class ItemAuxData
{
    public AuxPrefabManager AuxPrefabManager { get; set; }

    public int index { get; set; }

    public string data
    {
        get
        {
            if (AuxPrefabManager.Prefabs.Count == 0)
            {
                return string.Empty;
            }

            return AuxPrefabManager.GetJsonString();
        }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                AuxPrefabManager = new AuxPrefabManager(new List<AuxPrefab>());
                return;
            }

            AuxPrefabManager =
                new AuxPrefabManager(
                    JsonNode.Parse(value)!.AsObject());
        }
    }

    public ItemAuxData(int index, string data)
    {
        this.index = index;

        AuxPrefabManager =
            string.IsNullOrWhiteSpace(data)
                ? new AuxPrefabManager(new List<AuxPrefab>())
                : new AuxPrefabManager(
                    JsonNode.Parse(data)!.AsObject());
    }
}