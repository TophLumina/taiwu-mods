using GameData.Common;

namespace GameData.Domains.Combat.MixPoison;

public delegate bool MixPoisonEffectDelegate(DataContext context, CombatCharacter combatChar, byte[] poisonMarkList);
