using System.Collections.Generic;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.BreakBodyEffect;

public static class BreakFeatureHelper
{
	public static readonly short[] AllCrashFeature = new short[5] { 202, 204, 200, 206, 208 };

	public static readonly short[] AllHurtFeature = new short[5] { 201, 203, 199, 205, 207 };

	public static readonly Dictionary<sbyte, short> BodyPart2CrashFeature = new Dictionary<sbyte, short>
	{
		[0] = 202,
		[1] = 204,
		[2] = 200,
		[3] = 206,
		[4] = 206,
		[5] = 208,
		[6] = 208
	};

	public static readonly Dictionary<sbyte, short> BodyPart2HurtFeature = new Dictionary<sbyte, short>
	{
		[0] = 201,
		[1] = 203,
		[2] = 199,
		[3] = 205,
		[4] = 205,
		[5] = 207,
		[6] = 207
	};

	public static readonly Dictionary<short, sbyte[]> Feature2BodyPart = new Dictionary<short, sbyte[]>
	{
		[202] = new sbyte[1],
		[204] = new sbyte[1] { 1 },
		[200] = new sbyte[1] { 2 },
		[206] = new sbyte[2] { 3, 4 },
		[208] = new sbyte[2] { 5, 6 },
		[201] = new sbyte[1],
		[203] = new sbyte[1] { 1 },
		[199] = new sbyte[1] { 2 },
		[205] = new sbyte[2] { 3, 4 },
		[207] = new sbyte[2] { 5, 6 }
	};
}
