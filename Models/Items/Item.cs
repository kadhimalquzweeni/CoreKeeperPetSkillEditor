using CoreKeeperPetSkillEditor.Models.ItemAux;

namespace CoreKeeperPetSkillEditor.Models.Items;

public class Item
{
    public int objectID { get; set; }

    public int amount { get; set; }

    public int variation { get; set; }

    public int variationUpdateCount { get; set; }

    public string keyName { get; set; } = string.Empty;

    public ItemAuxData Aux { get; set; }

    public Item(
        int objectID,
        int amount,
        int variation,
        int variationUpdateCount,
        string keyName,
        ItemAuxData aux)
    {
        this.objectID = objectID;
        this.amount = amount;
        this.variation = variation;
        this.variationUpdateCount = variationUpdateCount;
        this.keyName = keyName;
        Aux = aux;
    }
}