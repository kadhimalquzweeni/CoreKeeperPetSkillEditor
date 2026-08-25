namespace CoreKeeperPetSkillEditor.Models;

public class PetTalentDefinition
{
    public int Id { get; set; }

    public string InternalName { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string Variant { get; set; } = string.Empty;

    public string DisplayName =>
        $"[{Id}] {Name} ({Variant})";

    public override string ToString() => DisplayName;
}