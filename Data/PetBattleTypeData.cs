using CoreKeeperPetSkillEditor.Models.Pet;

namespace CoreKeeperPetSkillEditor.Data;

public static class PetBattleTypeData
{
    public static readonly Dictionary<
        PetType,
        PetBattleType> BattleTypes =
        new()
        {
            // Melee
            { PetType.Subterrier, PetBattleType.Melee },
            { PetType.JrOrangeSlime, PetBattleType.Melee },
            { PetType.ElectroPest, PetBattleType.Melee },
            { PetType.PrinceSlime, PetBattleType.Melee },
            { PetType.JrPurpleSlime, PetBattleType.Melee },
            { PetType.JrBlueSlime, PetBattleType.Melee },
            { PetType.JrLavaSlime, PetBattleType.Melee },
            { PetType.Snugglygrade, PetBattleType.Melee },

            // Range
            { PetType.Embertail, PetBattleType.Range },
            { PetType.Fanhare, PetBattleType.Range },

            // Buff
            { PetType.Owlux, PetBattleType.Buff },
            { PetType.Earie, PetBattleType.Buff },
            { PetType.Pheromoth, PetBattleType.Buff },
            { PetType.ArcaneSymbiote, PetBattleType.Buff }
        };

    public static PetBattleType GetBattleType(
        PetType petType)
    {
        return BattleTypes.TryGetValue(
            petType,
            out PetBattleType battleType)
            ? battleType
            : PetBattleType.Undefined;
    }
}