using System;

namespace GameData.Domains.Organization;

public static class MartialArtTournamentPreparationType
{
	public const sbyte CombatPower = 0;

	[Obsolete("It is Fame that being used now.")]
	public const sbyte Authority = 1;

	public const sbyte FameScore = 1;

	public const sbyte Resources = 2;

	public const int Count = 3;
}
