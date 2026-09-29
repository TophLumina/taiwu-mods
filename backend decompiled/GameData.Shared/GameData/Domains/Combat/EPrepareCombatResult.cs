using GameData.Serializer;

namespace GameData.Domains.Combat;

[SerializeTo(typeof(int))]
public enum EPrepareCombatResult
{
	Invalid = -1,
	SelfFirst,
	EnemyFirst,
	EqualsRandom
}
