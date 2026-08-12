using System.Collections.Generic;
using System.Linq;
using Config;
using GameData.Combat.Math;

namespace GameData.Domains.Character;

/// <summary>
/// 健康类型工具集
/// </summary>
public static class HealthTypeHelper
{
	/// <summary>
	/// 濒死百分比
	/// </summary>
	private static readonly CValuePercent DyingPercent = 0;

	/// <summary>
	/// 垂危百分比
	/// </summary>
	private static readonly CValuePercent CriticallyIllPercent = 25;

	/// <summary>
	/// 衰弱百分比
	/// </summary>
	private static readonly CValuePercent WeakPercent = 50;

	/// <summary>
	/// 抱恙百分比
	/// </summary>
	private static readonly CValuePercent SickPercent = 75;

	/// <summary>
	/// 计算健康类型
	/// 此计算方法自前端 CommonUtils.GetCharacterHealthInfo、CommonUtils.GetCharacterHealthInfos 提取，修改参数时应一并调整
	/// </summary>
	/// <param name="featureIds">角色特性 ID</param>
	/// <param name="health">角色当前健康</param>
	/// <param name="maxHealth">角色健康上限</param>
	/// <returns></returns>
	public static EHealthType CalcType(IEnumerable<short> featureIds, short health, short maxHealth)
	{
		if (featureIds.Any(IgnoreMark))
		{
			return EHealthType.Unknown;
		}
		if (health < maxHealth * DyingPercent || maxHealth < 0)
		{
			return EHealthType.Dying;
		}
		if (health <= maxHealth * CriticallyIllPercent || maxHealth <= 6)
		{
			return EHealthType.CriticallyIll;
		}
		if (health <= maxHealth * WeakPercent || maxHealth <= 12)
		{
			return EHealthType.Weak;
		}
		if (health <= maxHealth * SickPercent || maxHealth <= 24)
		{
			return EHealthType.Sick;
		}
		return EHealthType.Healthy;
	}

	/// <summary>
	/// 计算健康类型
	/// </summary>
	/// <param name="health"></param>
	/// <param name="maxHealth"></param>
	/// <returns></returns>
	public static EHealthType CalcType(short health, short maxHealth)
	{
		if (health < maxHealth * DyingPercent || maxHealth < 0)
		{
			return EHealthType.Dying;
		}
		if (health <= maxHealth * CriticallyIllPercent || maxHealth <= 6)
		{
			return EHealthType.CriticallyIll;
		}
		if (health <= maxHealth * WeakPercent || maxHealth <= 12)
		{
			return EHealthType.Weak;
		}
		if (health <= maxHealth * SickPercent || maxHealth <= 24)
		{
			return EHealthType.Sick;
		}
		return EHealthType.Healthy;
	}

	/// <summary>
	/// 无视健康标记的判定器
	/// </summary>
	/// <param name="featureId"></param>
	/// <returns></returns>
	private static bool IgnoreMark(short featureId)
	{
		return CharacterFeature.Instance[featureId].IgnoreHealthMark;
	}

	/// <summary>
	/// 转换为一般索引格式
	/// </summary>
	/// <param name="healthType">健康类型</param>
	/// <returns></returns>
	public static int ToCommonIndex(this EHealthType healthType)
	{
		return healthType switch
		{
			EHealthType.Healthy => 0, 
			EHealthType.Sick => 1, 
			EHealthType.Weak => 2, 
			EHealthType.CriticallyIll => 3, 
			EHealthType.Dying => 4, 
			_ => -1, 
		};
	}
}
