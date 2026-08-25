namespace CoreKeeperPetSkillEditor.Models.ItemAux;

public class AuxPrefab
{
    public ulong prefabHash { get; set; }

    public List<AuxStableType> types { get; set; } = [];

    public AuxPrefab()
    {
    }

    public AuxPrefab(
        ulong prefabHash,
        List<AuxStableType> types)
    {
        this.prefabHash = prefabHash;
        this.types = types;
    }
}