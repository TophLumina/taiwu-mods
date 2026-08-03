using System;

namespace GameData.Domains.Combat;

[Flags]
public enum EWugReplaceType
{
	None = 0,
	Nonexistent = 1,
	CombatOnly = 2,
	Ungrown = 4,
	All = -1
}
