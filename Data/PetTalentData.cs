using CoreKeeperPetSkillEditor.Models;

namespace CoreKeeperPetSkillEditor.Data;

public static class PetTalentData
{
    public static readonly List<PetTalentDefinition> All =
    [
        // 0
        new() { Id = 0, InternalName = "MeleeAttackSpeed", Name = "Leap Attack", Variant = "Melee" },
        new() { Id = 0, InternalName = "MeleeAttackSpeed", Name = "Divebombing", Variant = "Buff" },

        // 1
        new() { Id = 1, InternalName = "RangeAttackSpeed", Name = "Leap Attack", Variant = "Range" },
        new() { Id = 1, InternalName = "RangeAttackSpeed", Name = "Flock Together", Variant = "Buff" },

        // 2
        new() { Id = 2, InternalName = "CritChance", Name = "Laser Pointer Play", Variant = "Melee" },
        new() { Id = 2, InternalName = "CritChance", Name = "Laser Pointer Play", Variant = "Range" },
        new() { Id = 2, InternalName = "CritChance", Name = "Spirit of the Hawk", Variant = "Buff" },

        // 3
        new() { Id = 3, InternalName = "CritDamage", Name = "Breaking Skin", Variant = "Melee" },
        new() { Id = 3, InternalName = "CritDamage", Name = "Breaking Skin", Variant = "Range" },
        new() { Id = 3, InternalName = "CritDamage", Name = "Crane Style", Variant = "Buff" },

        // 4
        new() { Id = 4, InternalName = "MeleeDamage", Name = "Puffing Up", Variant = "Melee" },
        new() { Id = 4, InternalName = "MeleeDamage", Name = "Plume Power", Variant = "Buff" },

        // 5
        new() { Id = 5, InternalName = "RangeDamage", Name = "Puffing Up", Variant = "Range" },
        new() { Id = 5, InternalName = "RangeDamage", Name = "Plume Projectile", Variant = "Buff" },

        // 6
        new() { Id = 6, InternalName = "BossDamage", Name = "Asserting Dominance", Variant = "Melee" },
        new() { Id = 6, InternalName = "BossDamage", Name = "Asserting Dominance", Variant = "Range" },
        new() { Id = 6, InternalName = "BossDamage", Name = "Alpha Instincts", Variant = "Buff" },

        // 7
        new() { Id = 7, InternalName = "ChanceToDealTripleDamage", Name = "Off-Leash", Variant = "Melee" },
        new() { Id = 7, InternalName = "ChanceToDealTripleDamage", Name = "Off-Leash", Variant = "Range" },
        new() { Id = 7, InternalName = "ChanceToDealTripleDamage", Name = "Triple Trouble", Variant = "Buff" },

        // 8
        new() { Id = 8, InternalName = "ApplyBurn", Name = "Burning Anger", Variant = "Melee" },
        new() { Id = 8, InternalName = "ApplyBurn", Name = "Burning Anger", Variant = "Range" },
        new() { Id = 8, InternalName = "ApplyBurn", Name = "Rising Phoenix", Variant = "Buff" },

        // 9
        new() { Id = 9, InternalName = "ApplyPoison", Name = "Bite Wound Infection", Variant = "Melee" },
        new() { Id = 9, InternalName = "ApplyPoison", Name = "Bite Wound Infection", Variant = "Range" },
        new() { Id = 9, InternalName = "ApplyPoison", Name = "Vile Droppings", Variant = "Buff" },

        // 10
        new() { Id = 10, InternalName = "ApplyStun", Name = "Paralyzing Fangs", Variant = "Melee" },
        new() { Id = 10, InternalName = "ApplyStun", Name = "Paralyzing Fangs", Variant = "Range" },
        new() { Id = 10, InternalName = "ApplyStun", Name = "Secret Neck Grip", Variant = "Buff" },

        // 11
        new() { Id = 11, InternalName = "ApplySlime", Name = "Sticky Toy", Variant = "Melee" },
        new() { Id = 11, InternalName = "ApplySlime", Name = "Sticky Toy", Variant = "Range" },
        new() { Id = 11, InternalName = "ApplySlime", Name = "Mucus Missile", Variant = "Buff" },

        // 12
        new() { Id = 12, InternalName = "OrangeGlow", Name = "Spirit Animal", Variant = "Melee" },
        new() { Id = 12, InternalName = "OrangeGlow", Name = "Spirit Animal", Variant = "Range" },
        new() { Id = 12, InternalName = "OrangeGlow", Name = "Sun Glow", Variant = "Buff" },

        // 13
        new() { Id = 13, InternalName = "BlueGlow", Name = "Moon Glow", Variant = "Buff" },

        // 14
        new() { Id = 14, InternalName = "StunDuration", Name = "Intimidating Presence", Variant = "Melee" },
        new() { Id = 14, InternalName = "StunDuration", Name = "Intimidating Presence", Variant = "Range" },
        new() { Id = 14, InternalName = "StunDuration", Name = "Taxidermy", Variant = "Buff" },

        // 15
        new() { Id = 15, InternalName = "DamageIncreaseAgainstStunned", Name = "Predator's Mark", Variant = "Melee" },
        new() { Id = 15, InternalName = "DamageIncreaseAgainstStunned", Name = "Predator's Mark", Variant = "Range" },
        new() { Id = 15, InternalName = "DamageIncreaseAgainstStunned", Name = "Paralyze Pawnch", Variant = "Buff" },

        // 16
        new() { Id = 16, InternalName = "MovementSpeed", Name = "Zoomies", Variant = "Melee" },
        new() { Id = 16, InternalName = "MovementSpeed", Name = "Zoomies", Variant = "Range" },
        new() { Id = 16, InternalName = "MovementSpeed", Name = "Avian Run", Variant = "Buff" },

        // 17
        new() { Id = 17, InternalName = "ApplySlippery", Name = "Icky Tounge", Variant = "Melee" },
        new() { Id = 17, InternalName = "ApplySlippery", Name = "Icky Tounge", Variant = "Range" },
        new() { Id = 17, InternalName = "ApplySlippery", Name = "Coated Feather", Variant = "Buff" },

        // 18
        new() { Id = 18, InternalName = "DamageBasedOnTargetRemainingHealth", Name = "Hungry Fang", Variant = "Melee" },
        new() { Id = 18, InternalName = "DamageBasedOnTargetRemainingHealth", Name = "Hungry Fang", Variant = "Range" },
        new() { Id = 18, InternalName = "DamageBasedOnTargetRemainingHealth", Name = "Inflated Target", Variant = "Buff" },

        // 19
        new() { Id = 19, InternalName = "ChanceToConsumeBurning", Name = "Flaming Treat", Variant = "Melee" },
        new() { Id = 19, InternalName = "ChanceToConsumeBurning", Name = "Flaming Treat", Variant = "Range" },
        new() { Id = 19, InternalName = "ChanceToConsumeBurning", Name = "Bellows", Variant = "Buff" },

        // 20
        new() { Id = 20, InternalName = "PiercingProjectiles", Name = "Hypersonic Claw", Variant = "Range" },
        new() { Id = 20, InternalName = "PiercingProjectiles", Name = "Hypersonic Talon", Variant = "Buff" },

        // 21
        new() { Id = 21, InternalName = "StunAndSnareReduction", Name = "Winged Escape", Variant = "Buff" },

        // 22
        new() { Id = 22, InternalName = "ChanceToGainManaOnAttack", Name = "Energy Tap", Variant = "Melee" },

        // 23
        new() { Id = 23, InternalName = "ManaRegeneration", Name = "Mana Bowl", Variant = "Melee" },

        // 24
        new() { Id = 24, InternalName = "MagicDamage", Name = "Arcane Beast", Variant = "Melee" },

        // 25
        new() { Id = 25, InternalName = "MinionAttackSpeed", Name = "Provoked Swarm", Variant = "Universal" },

        // 26
        new() { Id = 26, InternalName = "ApplyRadiationDamage", Name = "Territorial Fallout", Variant = "Melee" },
        new() { Id = 26, InternalName = "ApplyRadiationDamage", Name = "Irradiated Scent", Variant = "Buff" },

        // 27
        new() { Id = 27, InternalName = "MinionCritChance", Name = "Laser Pointer Play", Variant = "Universal" },

        // 28
        new() { Id = 28, InternalName = "MinionCritDamage", Name = "Breaking Skin", Variant = "Universal" },

        // 29
        new() { Id = 29, InternalName = "MinionDamage", Name = "Battle Born", Variant = "Universal" },

        // 30
        new() { Id = 30, InternalName = "MinionBossDamage", Name = "Drone Dominance", Variant = "Universal" },

        // 31
        new() { Id = 31, InternalName = "MinionLifeSpan", Name = "Longevity", Variant = "Universal" },

        // 32
        new() { Id = 32, InternalName = "LifeToOwnerOnMinionHit", Name = "Colony Foraging", Variant = "Universal" },

        // 33
        new() { Id = 33, InternalName = "LifeToOwnerOnPetHit", Name = "Life to Owner on Pet Hit", Variant = "Melee" },
        new() { Id = 33, InternalName = "LifeToOwnerOnPetHit", Name = "Life to Owner on Pet Hit", Variant = "Range" },
        new() { Id = 33, InternalName = "LifeToOwnerOnPetHit", Name = "Life to Owner on Pet Hit", Variant = "Buff" }
    ];
}