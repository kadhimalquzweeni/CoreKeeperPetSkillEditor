using CoreKeeperPetSkillEditor.Models.Items;
using CoreKeeperPetSkillEditor.Models.ItemAux;
namespace CoreKeeperPetSkillEditor.Models.Pet;

public class Pet : Item
{
    public int InventoryIndex { get; set; }
    public PetType Type
    {
        get
        {
            return (PetType)objectID;
        }
    }
    public int Exp
    {
        get => amount;
        set => amount = value;
    }
    public Pet(Item item, int inventoryIndex)
        : base(
            item.objectID,
            item.amount,
            item.variation,
            item.variationUpdateCount,
            item.keyName,
            item.Aux)
    {
        InventoryIndex = inventoryIndex;
    }
    public List<PetTalent> Talents
    {
        get
        {
            return Aux.AuxPrefabManager
                .GetData(
                    AuxHash.PetGroupHash,
                    AuxHash.PetTalentsHash)
                .Select(data => new PetTalent(data))
                .ToList();
        }

        set
        {
            Aux.AuxPrefabManager.UpdateData(
                AuxHash.PetGroupHash,
                AuxHash.PetTalentsHash,
                value.Select(t => t.ToJsonString()));
        }
    }

    public static bool IsPet(int objectId)
    {
        return Enum.GetValues<PetType>()
            .Cast<int>()
            .Contains(objectId);
    }

    public override string ToString()
    {
        return $"{keyName} - Slot {InventoryIndex}";
    }

}