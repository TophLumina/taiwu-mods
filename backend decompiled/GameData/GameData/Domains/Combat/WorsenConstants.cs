using GameData.Combat.Math;

namespace GameData.Domains.Combat;

public static class WorsenConstants
{
	public static readonly CValuePercent[] WorsenFatalPercent = new CValuePercent[6] { 10, 20, 40, 70, 110, 160 };

	public static readonly CValuePercent DefaultPercent = 80;

	public static readonly CValuePercent LowPercent = 40;

	public static readonly CValuePercent HighPercent = 120;

	public static readonly CValuePercent SpecialPercentBaiXie = 160;

	public static readonly CValuePercent SpecialPercentMingYunWuJianYu = 240;

	public static readonly CValuePercent SpecialPercentLoongFire = 160;

	public static CValuePercent CalcPoisonPercent(CValueMultiplier poisonLevel)
	{
		return HighPercent * poisonLevel;
	}
}
