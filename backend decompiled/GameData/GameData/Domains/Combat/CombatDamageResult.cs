namespace GameData.Domains.Combat;

public readonly struct CombatDamageResult
{
	public int TotalDamage { get; init; }

	public int LeftDamage { get; init; }

	public int MarkCount { get; init; }
}
