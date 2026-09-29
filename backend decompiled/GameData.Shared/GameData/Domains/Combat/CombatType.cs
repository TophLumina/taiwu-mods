using System;

namespace GameData.Domains.Combat;

[Serializable]
public enum CombatType : sbyte
{
	Play,
	Beat,
	Die,
	Test
}
