using System.Runtime.CompilerServices;

namespace Config;

/// <summary>
/// 枚举EMedicineEffectSubType的扩展类
/// </summary>
public static class EMedicineEffectSubTypeExtension
{
	/// <summary>
	/// EMedicineEffectSubType对应的操作种类
	/// </summary>
	public enum Operate : sbyte
	{
		/// <summary>
		/// 目前用于随机疗伤
		/// </summary>
		Other = -1,
		/// <summary>
		/// 值
		/// </summary>
		Value,
		/// <summary>
		/// 百分比
		/// </summary>
		Percentage
	}

	/// <summary>
	/// 获取EMedicineEffectSubType对应的操作种类
	/// </summary>
	/// <param name="effectSubType"></param>
	/// <returns></returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Operate OperateType(this EMedicineEffectSubType effectSubType)
	{
		return effectSubType switch
		{
			EMedicineEffectSubType.RecoverHealthValue => Operate.Value, 
			EMedicineEffectSubType.ChangeDisorderOfQiValue => Operate.Value, 
			EMedicineEffectSubType.DetoxPoisonHotValue => Operate.Value, 
			EMedicineEffectSubType.DetoxPoisonGloomyValue => Operate.Value, 
			EMedicineEffectSubType.DetoxPoisonColdValue => Operate.Value, 
			EMedicineEffectSubType.DetoxPoisonRedValue => Operate.Value, 
			EMedicineEffectSubType.DetoxPoisonRottenValue => Operate.Value, 
			EMedicineEffectSubType.DetoxPoisonIllusoryValue => Operate.Value, 
			EMedicineEffectSubType.ApplyPoisonHotValue => Operate.Value, 
			EMedicineEffectSubType.ApplyPoisonGloomyValue => Operate.Value, 
			EMedicineEffectSubType.ApplyPoisonColdValue => Operate.Value, 
			EMedicineEffectSubType.ApplyPoisonRedValue => Operate.Value, 
			EMedicineEffectSubType.ApplyPoisonRottenValue => Operate.Value, 
			EMedicineEffectSubType.ApplyPoisonIllusoryValue => Operate.Value, 
			EMedicineEffectSubType.RecoverHealthPercentage => Operate.Percentage, 
			EMedicineEffectSubType.ChangeDisorderOfQiPercentage => Operate.Percentage, 
			EMedicineEffectSubType.DetoxPoisonHotPercentage => Operate.Percentage, 
			EMedicineEffectSubType.DetoxPoisonGloomyPercentage => Operate.Percentage, 
			EMedicineEffectSubType.DetoxPoisonColdPercentage => Operate.Percentage, 
			EMedicineEffectSubType.DetoxPoisonRedPercentage => Operate.Percentage, 
			EMedicineEffectSubType.DetoxPoisonRottenPercentage => Operate.Percentage, 
			EMedicineEffectSubType.DetoxPoisonIllusoryPercentage => Operate.Percentage, 
			EMedicineEffectSubType.PropertyAddValue => Operate.Value, 
			EMedicineEffectSubType.PropertyAddPercentage => Operate.Percentage, 
			_ => Operate.Other, 
		};
	}

	/// <summary>
	/// 子类的影响是百分比类型
	/// </summary>
	/// <param name="effectSubType"></param>
	/// <returns></returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool IsPercentage(this EMedicineEffectSubType effectSubType)
	{
		return effectSubType.OperateType() == Operate.Percentage;
	}

	/// <summary>
	/// 子类的影响是值类型
	/// </summary>
	/// <param name="effectSubType"></param>
	/// <returns></returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool IsValue(this EMedicineEffectSubType effectSubType)
	{
		return effectSubType.OperateType() == Operate.Value;
	}

	/// <summary>
	/// 获取药物的毒素类型/解毒类型（若无，返回-1）
	/// 如果需要区分或者强调代码逻辑为毒素类型/解读类型中的特定一种，可以使用下面的两个函数
	/// </summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static sbyte PoisonType(this EMedicineEffectSubType effectSubType)
	{
		return effectSubType switch
		{
			EMedicineEffectSubType.DetoxPoisonHotValue => 0, 
			EMedicineEffectSubType.DetoxPoisonGloomyValue => 1, 
			EMedicineEffectSubType.DetoxPoisonColdValue => 2, 
			EMedicineEffectSubType.DetoxPoisonRedValue => 3, 
			EMedicineEffectSubType.DetoxPoisonRottenValue => 4, 
			EMedicineEffectSubType.DetoxPoisonIllusoryValue => 5, 
			EMedicineEffectSubType.ApplyPoisonHotValue => 0, 
			EMedicineEffectSubType.ApplyPoisonGloomyValue => 1, 
			EMedicineEffectSubType.ApplyPoisonColdValue => 2, 
			EMedicineEffectSubType.ApplyPoisonRedValue => 3, 
			EMedicineEffectSubType.ApplyPoisonRottenValue => 4, 
			EMedicineEffectSubType.ApplyPoisonIllusoryValue => 5, 
			EMedicineEffectSubType.DetoxPoisonHotPercentage => 0, 
			EMedicineEffectSubType.DetoxPoisonGloomyPercentage => 1, 
			EMedicineEffectSubType.DetoxPoisonColdPercentage => 2, 
			EMedicineEffectSubType.DetoxPoisonRedPercentage => 3, 
			EMedicineEffectSubType.DetoxPoisonRottenPercentage => 4, 
			EMedicineEffectSubType.DetoxPoisonIllusoryPercentage => 5, 
			_ => -1, 
		};
	}

	/// <summary>
	/// 获取药物的解毒类型（若无，返回-1）
	/// </summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static sbyte DetoxPoisonType(this EMedicineEffectSubType effectSubType)
	{
		return effectSubType switch
		{
			EMedicineEffectSubType.DetoxPoisonHotValue => 0, 
			EMedicineEffectSubType.DetoxPoisonGloomyValue => 1, 
			EMedicineEffectSubType.DetoxPoisonColdValue => 2, 
			EMedicineEffectSubType.DetoxPoisonRedValue => 3, 
			EMedicineEffectSubType.DetoxPoisonRottenValue => 4, 
			EMedicineEffectSubType.DetoxPoisonIllusoryValue => 5, 
			EMedicineEffectSubType.DetoxPoisonHotPercentage => 0, 
			EMedicineEffectSubType.DetoxPoisonGloomyPercentage => 1, 
			EMedicineEffectSubType.DetoxPoisonColdPercentage => 2, 
			EMedicineEffectSubType.DetoxPoisonRedPercentage => 3, 
			EMedicineEffectSubType.DetoxPoisonRottenPercentage => 4, 
			EMedicineEffectSubType.DetoxPoisonIllusoryPercentage => 5, 
			_ => -1, 
		};
	}

	/// <summary>
	/// 获取药物的毒素类型（若无，返回-1）
	/// </summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static sbyte ApplyPoisonType(this EMedicineEffectSubType effectSubType)
	{
		return effectSubType switch
		{
			EMedicineEffectSubType.ApplyPoisonHotValue => 0, 
			EMedicineEffectSubType.ApplyPoisonGloomyValue => 1, 
			EMedicineEffectSubType.ApplyPoisonColdValue => 2, 
			EMedicineEffectSubType.ApplyPoisonRedValue => 3, 
			EMedicineEffectSubType.ApplyPoisonRottenValue => 4, 
			EMedicineEffectSubType.ApplyPoisonIllusoryValue => 5, 
			_ => -1, 
		};
	}

	/// <summary>
	/// 解蛊类型
	/// </summary>
	/// <param name="effectType"></param>
	/// <param name="sideEffectValue"></param>
	/// <returns></returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static sbyte DetoxWugType(EMedicineEffectType effectType, short sideEffectValue)
	{
		return (sbyte)((effectType == EMedicineEffectType.ApplyPoison) ? sideEffectValue : (-1));
	}

	/// <summary>
	/// 获取药物效果的基础影响值
	/// </summary>
	/// <param name="fullRangeValue"></param>
	/// <param name="effectValue"></param>
	/// <param name="isPercentage"></param>
	/// <returns></returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int EffectValue(int fullRangeValue, short effectValue, bool isPercentage)
	{
		if (!isPercentage)
		{
			return effectValue;
		}
		return fullRangeValue * effectValue / 100;
	}
}
