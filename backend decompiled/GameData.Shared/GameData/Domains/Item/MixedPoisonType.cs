using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using GameData.Utilities;

namespace GameData.Domains.Item;

/// <summary>
/// 混合毒素相关定义
/// </summary>
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

	/// <summary>
	/// 裂皮碎骨
	/// </summary>
	public const sbyte HotRedRotten = 15;

	/// <summary>
	/// 心残肉挫
	/// </summary>
	public const sbyte HotRottenIllusory = 16;

	/// <summary>
	/// 骨错筋缠
	/// </summary>
	public const sbyte HotRottenGloomy = 17;

	/// <summary>
	/// 肝肠寸断
	/// </summary>
	public const sbyte HotRottenCold = 18;

	/// <summary>
	/// 血迷关窍
	/// </summary>
	public const sbyte RedRottenIllusory = 19;

	/// <summary>
	/// 五脏败腐
	/// </summary>
	public const sbyte RedRottenGloomy = 20;

	/// <summary>
	/// 坏血断肠
	/// </summary>
	public const sbyte RedRottenCold = 21;

	/// <summary>
	/// 毒火焚心
	/// </summary>
	public const sbyte HotRedIllusory = 22;

	/// <summary>
	/// 骨中烧疽
	/// </summary>
	public const sbyte HotRedGloomy = 23;

	/// <summary>
	/// 血火阴杀
	/// </summary>
	public const sbyte HotRedCold = 24;

	/// <summary>
	/// 摧心蚀元
	/// </summary>
	public const sbyte GloomyColdIllusory = 25;

	/// <summary>
	/// 化骨封髓
	/// </summary>
	public const sbyte RottenGloomyCold = 26;

	/// <summary>
	/// 寒锥锁脉
	/// </summary>
	public const sbyte HotGloomyCold = 27;

	/// <summary>
	/// 锁血凝髓
	/// </summary>
	public const sbyte RedGloomyCold = 28;

	/// <summary>
	/// 邪阴彻体
	/// </summary>
	public const sbyte RottenColdIllusory = 29;

	/// <summary>
	/// 迷惧钻心
	/// </summary>
	public const sbyte HotColdIllusory = 30;

	/// <summary>
	/// 剧恶深苦
	/// </summary>
	public const sbyte RedColdIllusory = 31;

	/// <summary>
	/// 失魂鬼瘴
	/// </summary>
	public const sbyte RottenGloomyIllusory = 32;

	/// <summary>
	/// 绝脉乱心
	/// </summary>
	public const sbyte HotGloomyIllusory = 33;

	/// <summary>
	/// 封颅闭血
	/// </summary>
	public const sbyte RedGloomyIllusory = 34;

	public const int Count = 35;

	public const int MaxMixedAmount = 3;

	public const sbyte MixedOfThreeBegin = 15;

	public const sbyte MixedOfThreeEnd = 34;

	/// <summary>
	/// 将混合毒类型转为其包含的毒素
	/// <see cref="T:GameData.Domains.Item.MixedPoisonType" /> =&gt; <see cref="T:GameData.Domains.Combat.PoisonType" />[]
	/// </summary>
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

	/// <summary>
	/// 将运功栏位转为混合毒物品模板ID
	/// <see cref="T:GameData.Domains.CombatSkill.CombatSkillEquipType" /> =&gt; <see cref="T:GameData.Domains.Item.MixedPoisonType" />
	/// </summary>
	public static readonly sbyte[] SkillEquipTypeToMixedPoisonType = new sbyte[5] { -1, 19, 16, 32, 29 };

	private static Dictionary<byte, sbyte> _poisonTypesToMixedPoisonType;

	/// <summary>
	/// 将药毒模板ID转为混合毒素类型. 该方法不会检查ID是否为混合毒
	/// </summary>
	/// <param name="medicineTemplateId"><see cref="F:Config.MedicineItem.TemplateId" /></param>
	/// <returns><see cref="T:GameData.Domains.Item.MixedPoisonType" /></returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static sbyte FromMedicineTemplateId(short medicineTemplateId)
	{
		return (sbyte)(medicineTemplateId - 389);
	}

	/// <summary>
	/// 将混合毒素类型转为药毒模板ID.
	/// </summary>
	/// <param name="mixedPoisonType"><see cref="T:GameData.Domains.Item.MixedPoisonType" /></param>
	/// <returns><see cref="F:Config.MedicineItem.TemplateId" /></returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static short ToMedicineTemplateId(sbyte mixedPoisonType)
	{
		return (short)(389 + mixedPoisonType);
	}

	/// <summary>
	/// 将混合毒素类型转为混合毒效果模板ID
	/// </summary>
	/// <param name="mixedPoisonType"><see cref="T:GameData.Domains.Item.MixedPoisonType" /></param>
	/// <returns><see cref="F:Config.MixPoisonEffectItem.TemplateId" /></returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static short ToMixPoisonEffectTemplateId(sbyte mixedPoisonType)
	{
		return (short)(mixedPoisonType - 15);
	}

	/// <summary>
	/// 将功法装备类型转为混合毒素类型
	/// </summary>
	/// <param name="equipType"><see cref="T:GameData.Domains.CombatSkill.CombatSkillEquipType" /></param>
	/// <returns><see cref="T:GameData.Domains.Item.MixedPoisonType" /></returns>
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

	/// <summary>
	/// 将混合毒素类型转为功法装备类型
	/// </summary>
	/// <param name="mixedPoisonType"><see cref="T:GameData.Domains.Item.MixedPoisonType" /></param>
	/// <returns><see cref="T:GameData.Domains.CombatSkill.CombatSkillEquipType" /></returns>
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

	/// <summary>
	/// 指定药毒模板ID是否为混合毒
	/// </summary>
	/// <param name="medicineTemplateId"></param>
	/// <returns></returns>
	public static bool IsMixedPoisonItem(short medicineTemplateId)
	{
		if (medicineTemplateId >= 389)
		{
			return medicineTemplateId <= 423;
		}
		return false;
	}

	/// <summary>
	/// 将毒素值和等级转为混合药毒模板ID
	/// </summary>
	/// <param name="poisonsAndLevels"></param>
	/// <returns></returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static short PoisonsAndLevelToMedicineTemplateId(ref PoisonsAndLevels poisonsAndLevels)
	{
		return ToMedicineTemplateId(FromPoisonsAndLevels(ref poisonsAndLevels));
	}

	/// <summary>
	/// 将毒素转为混合毒 ID
	/// </summary>
	/// <param name="poisonsAndLevels"></param>
	/// <returns></returns>
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

	/// <summary>
	/// 初始化混合毒素字典.
	/// 2025/1/2: 此前疑似因过月在多线程中首次处理毒素判断，导致极少数情况在多个子线程同时初始化而出错, 后端改为随数据域初始化. 
	/// </summary>
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
