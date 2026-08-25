namespace CoreKeeperPetSkillEditor.Models.ItemAux;

public class AuxStableType
{
    public ulong stableTypeHash { get; set; }

    public IEnumerable<string> data { get; set; } = [];

    public AuxStableType()
    {
    }

    public AuxStableType(
        ulong stableTypeHash,
        IEnumerable<string> data)
    {
        this.stableTypeHash = stableTypeHash;
        this.data = data;
    }
}