using CoreKeeperPetSkillEditor.Models.Pet;

namespace CoreKeeperPetSkillEditor.Data;

public static class PetDefaults
{
    public static List<PetTalent> CreateDefaultTalents()
    {
        return Enumerable
            .Repeat(
                new PetTalent(2, 0),
                9)
            .ToList();
    }
}