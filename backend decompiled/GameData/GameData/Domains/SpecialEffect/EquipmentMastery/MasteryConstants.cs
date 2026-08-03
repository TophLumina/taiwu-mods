using System.Collections.Generic;
using GameData.Combat.Math;

namespace GameData.Domains.SpecialEffect.EquipmentMastery;

public class MasteryConstants
{
	public const int AffectOdds = 25;

	public static readonly IReadOnlyList<int> JadeAffectOdds = new int[3] { 15, 10, 5 };

	public const int AddValue33 = 33;

	public const int AddValue50 = 50;

	public const int AddValue100 = 100;

	public const int ReduceValue33 = -33;

	public static CValuePercent PercentValue33 => 33;
}
