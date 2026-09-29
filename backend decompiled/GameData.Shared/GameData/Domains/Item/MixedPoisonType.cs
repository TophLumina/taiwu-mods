using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using GameData.Utilities;

namespace GameData.Domains.Item;

public static class MixedPoisonType
{
	public const sbyte Invalid = -1;

	public const sbyte HotGloomy = 0;

	public const sbyte HotRed = 1;

	public const sbyte HotCold = 2;

	public const sbyte HotRotten = 3;

	public const sbyte HotIllusory = 4;

	public const sbyte GloomyRed = 5;

	public const sbyte GloomyCold = 6;

	public const sbyte GloomyRotten = 7;

	public const sbyte GloomyIllusory = 8;

	public const sbyte RedCold = 9;

	public const sbyte RedRotten = 10;

	public const sbyte RedIllusory = 11;

	public const sbyte ColdRotten = 12;

	public const sbyte ColdIllusory = 13;

	public const sbyte RottenIllusory = 14;

	public const sbyte HotRedRotten = 15;

	public const sbyte HotRottenIllusory = 16;

	public const sbyte HotRottenGloomy = 17;

	public const sbyte HotRottenCold = 18;

	public const sbyte RedRottenIllusory = 19;

	public const sbyte RedRottenGloomy = 20;

	public const sbyte RedRottenCold = 21;

	public const sbyte HotRedIllusory = 22;

	public const sbyte HotRedGloomy = 23;

	public const sbyte HotRedCold = 24;

	public const sbyte GloomyColdIllusory = 25;

	public const sbyte RottenGloomyCold = 26;

	public const sbyte HotGloomyCold = 27;

	public const sbyte RedGloomyCold = 28;

	public const sbyte RottenColdIllusory = 29;

	public const sbyte HotColdIllusory = 30;

	public const sbyte RedColdIllusory = 31;

	public const sbyte RottenGloomyIllusory = 32;

	public const sbyte HotGloomyIllusory = 33;

	public const sbyte RedGloomyIllusory = 34;

	public const int Count = 35;

	public const int MaxMixedAmount = 3;

	public const sbyte MixedOfThreeBegin = 15;

	public const sbyte MixedOfThreeEnd = 34;

	public static readonly sbyte[][] ToPoisonTypes = new sbyte[35][]
	{
		new sbyte[2] { 0, 1 },
		new sbyte[2] { 0, 3 },
		new sbyte[2] { 0, 2 },
		new sbyte[2] { 0, 4 },
		new sbyte[2] { 0, 5 },
		new sbyte[2] { 1, 3 },
		new sbyte[2] { 1, 2 },
		new sbyte[2] { 1, 4 },
		new sbyte[2] { 1, 5 },
		new sbyte[2] { 3, 2 },
		new sbyte[2] { 3, 4 },
		new sbyte[2] { 3, 5 },
		new sbyte[2] { 2, 4 },
		new sbyte[2] { 2, 5 },
		new sbyte[2] { 4, 5 },
		new sbyte[3] { 0, 3, 4 },
		new sbyte[3] { 0, 4, 5 },
		new sbyte[3] { 0, 4, 1 },
		new sbyte[3] { 0, 4, 2 },
		new sbyte[3] { 3, 4, 5 },
		new sbyte[3] { 3, 4, 1 },
		new sbyte[3] { 3, 4, 2 },
		new sbyte[3] { 0, 3, 5 },
		new sbyte[3] { 0, 3, 1 },
		new sbyte[3] { 0, 3, 2 },
		new sbyte[3] { 1, 2, 5 },
		new sbyte[3] { 4, 1, 2 },
		new sbyte[3] { 0, 1, 2 },
		new sbyte[3] { 3, 1, 2 },
		new sbyte[3] { 4, 2, 5 },
		new sbyte[3] { 0, 2, 5 },
		new sbyte[3] { 3, 2, 5 },
		new sbyte[3] { 4, 1, 5 },
		new sbyte[3] { 0, 1, 5 },
		new sbyte[3] { 3, 1, 5 }
	};

	public static readonly sbyte[] SkillEquipTypeToMixedPoisonType = new sbyte[5] { -1, 19, 16, 32, 29 };

	private static Dictionary<byte, sbyte> _poisonTypesToMixedPoisonType;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static sbyte FromMedicineTemplateId(short medicineTemplateId)
	{
		return (sbyte)(medicineTemplateId - 389);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static short ToMedicineTemplateId(sbyte mixedPoisonType)
	{
		return (short)(389 + mixedPoisonType);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static short ToMixPoisonEffectTemplateId(sbyte mixedPoisonType)
	{
		return (short)(mixedPoisonType - 15);
	}

	public static sbyte FromCombatSkillEquipType(sbyte equipType)
	{
		return equipType switch
		{
			1 => 19, 
			2 => 16, 
			3 => 32, 
			4 => 29, 
			_ => -1, 
		};
	}

	public static sbyte ToCombatSkillEquipType(sbyte mixedPoisonType)
	{
		return mixedPoisonType switch
		{
			16 => 2, 
			19 => 1, 
			29 => 4, 
			32 => 3, 
			_ => -1, 
		};
	}

	public static bool IsMixedPoisonItem(short medicineTemplateId)
	{
		if (medicineTemplateId >= 389)
		{
			return medicineTemplateId <= 423;
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static short PoisonsAndLevelToMedicineTemplateId(ref PoisonsAndLevels poisonsAndLevels)
	{
		return ToMedicineTemplateId(FromPoisonsAndLevels(ref poisonsAndLevels));
	}

	public unsafe static sbyte FromPoisonsAndLevels(ref PoisonsAndLevels poisonsAndLevels)
	{
		InitializeMaskDict();
		byte key = 0;
		int count = 0;
		sbyte poisonType = 0;
		while (poisonType < 6 && count < 3)
		{
			if (poisonsAndLevels.Values[poisonType] > 0)
			{
				key = BitOperation.SetBit(key, poisonType, bit: true);
				count++;
			}
			poisonType++;
		}
		if (_poisonTypesToMixedPoisonType.TryGetValue(key, out var value))
		{
			return value;
		}
		throw new Exception($"Invalid poisons and level data with bits {key}.");
	}

	public static void InitializeMaskDict()
	{
		if (_poisonTypesToMixedPoisonType != null)
		{
			return;
		}
		_poisonTypesToMixedPoisonType = new Dictionary<byte, sbyte>();
		for (sbyte mixedType = 0; mixedType < 35; mixedType++)
		{
			sbyte[] obj = ToPoisonTypes[mixedType];
			byte key = 0;
			sbyte[] array = obj;
			foreach (sbyte poisonType in array)
			{
				key = BitOperation.SetBit(key, poisonType, bit: true);
			}
			_poisonTypesToMixedPoisonType.Add(key, mixedType);
		}
	}
}
