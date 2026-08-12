using GameData.Combat.Math;
using GameData.Domains.Character;

namespace GameData.Domains.Combat;

public readonly struct CombatDamageResultMixed
{
	public CombatDamageResult Outer { get; init; }

	public CombatDamageResult Inner { get; init; }

	public CValuePercentBonus CriticalPercent { get; init; }

	public int TotalDamage => Outer.TotalDamage + Inner.TotalDamage;

	public OuterAndInnerInts MarkCounts => new OuterAndInnerInts(Outer.MarkCount, Inner.MarkCount);

	public void Deconstruct(out CombatDamageResult outer, out CombatDamageResult inner)
	{
		outer = Outer;
		inner = Inner;
	}
}
