using System;

namespace GameData.Combat.Cricket;

[Flags]
public enum ECricketCombatAttackStatus
{
	None = 0,
	Critical = 1,
	Parry = 2,
	CriticalAndParry = 3,
	Counter = 4
}
