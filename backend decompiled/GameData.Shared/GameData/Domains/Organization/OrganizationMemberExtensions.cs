using System;
using Config;
using GameData.Domains.Character;
using GameData.Domains.Item;
using GameData.Utilities;

namespace GameData.Domains.Organization;

/// <summary>
/// 组织成员身份配置数据的扩展方法
/// </summary>
public static class OrganizationMemberExtensions
{
	public static int GetEffectiveCombatSkillAdjust(this OrganizationMemberItem memberCfg, sbyte skillType)
	{
		short adjust = memberCfg.CombatSkillsAdjust[skillType];
		if (adjust < 0)
		{
			return 6;
		}
		return adjust;
	}

	public static int GetEffectiveLifeSkillAdjust(this OrganizationMemberItem memberCfg, sbyte skillType)
	{
		short adjust = memberCfg.LifeSkillsAdjust[skillType];
		if (adjust < 0)
		{
			return 6;
		}
		return adjust;
	}

	/// <summary>
	/// 获取修正后的资源满足阈值
	/// </summary>
	/// <param name="memberCfg">角色身份</param>
	/// <param name="resourceType">资源类型</param>
	/// <returns>对应资源类型的满足阈值(价值)</returns>
	public static int GetAdjustedResourceSatisfyingThreshold(this OrganizationMemberItem memberCfg, sbyte resourceType)
	{
		return memberCfg.ResourceSatisfyingThreshold * (100 + memberCfg.ResourcesAdjust[resourceType]) / 100;
	}

	/// <summary>
	/// 获取修正后的资源满足数量
	/// </summary>
	/// <param name="memberCfg">角色身份</param>
	/// <param name="resourceType">资源类型</param>
	/// <returns>满足阈值的对应资源类型的资源数量</returns>
	public static int GetAdjustedResourceSatisfyingAmount(this OrganizationMemberItem memberCfg, sbyte resourceType)
	{
		int threshold = memberCfg.GetAdjustedResourceSatisfyingThreshold(resourceType);
		return ResourceTypeHelper.WorthToResourceAmount(resourceType, threshold);
	}

	/// <summary>
	/// 基于身份计算指定资源类型修正后的相对价值
	/// </summary>
	/// <param name="memberCfg">角色身份</param>
	/// <param name="resourceType">资源类型</param>
	/// <param name="amount">资源数量，要求为正值</param>
	/// <returns>修正后对应的价值</returns>
	public static long AdjustResourceValue(this OrganizationMemberItem memberCfg, sbyte resourceType, long amount)
	{
		if (amount == 0L)
		{
			return 0L;
		}
		long num = ResourceTypeHelper.ResourceAmountToLongWorth(resourceType, amount);
		int percent = 100 + memberCfg.ResourcesAdjust[resourceType];
		long remainder;
		long result = Math.DivRem(num * percent, 100L, out remainder);
		if (remainder > 0)
		{
			result++;
		}
		return Math.Clamp(result, 1L, long.MaxValue);
	}

	/// <summary>
	/// 基于身份计算指定资源类型的价值修正后的数量。
	/// 如果是太吾拿到交易区，价值不为零，那最小是单位量。
	/// 如果是太吾取消交易区，价值不为零，那最小是1。
	/// </summary>
	/// <param name="memberCfg"></param>
	/// <param name="resourceType"></param>
	/// <param name="value">价值，要求为正值</param>
	/// <param name="isPut"></param>
	/// <returns></returns>
	public static long AdjustResourceAmount(this OrganizationMemberItem memberCfg, sbyte resourceType, long value, bool isPut)
	{
		if (value == 0L)
		{
			return 0L;
		}
		int min = ((!isPut) ? 1 : GlobalConfig.ResourcesWorth[resourceType]);
		int percent = 100 + memberCfg.ResourcesAdjust[resourceType];
		long remainder;
		long adjustValue = Math.DivRem(value * 100, percent, out remainder);
		if (remainder > 0)
		{
			adjustValue++;
		}
		return Math.Clamp(ResourceTypeHelper.LongWorthToResourceAmount(resourceType, adjustValue), min, long.MaxValue);
	}

	/// <summary>
	/// 获取实际加入门派级别
	/// </summary>
	/// <param name="orgMemberCfg"></param>
	/// <returns></returns>
	public static sbyte GetRejoinGrade(this OrganizationMemberItem orgMemberCfg)
	{
		sbyte rejoinGrade = ((orgMemberCfg.RejoinGrade >= 0) ? orgMemberCfg.RejoinGrade : orgMemberCfg.Grade);
		OrganizationItem organizationCfg = ((orgMemberCfg.Organization >= 0) ? Config.Organization.Instance[orgMemberCfg.Organization] : Config.Organization.Instance[(sbyte)21]);
		while (OrganizationMember.Instance[organizationCfg.Members[rejoinGrade]].RestrictPrincipalAmount)
		{
			rejoinGrade--;
		}
		return rejoinGrade;
	}

	/// <summary>
	/// 身份是否可以制造指定道具
	/// </summary>
	/// <param name="memberCfg"></param>
	/// <param name="itemType"></param>
	/// <param name="itemTemplateId"></param>
	/// <returns></returns>
	public static bool CanCraftItem(this OrganizationMemberItem memberCfg, sbyte itemType, short itemTemplateId)
	{
		if (memberCfg.CraftTypes == null)
		{
			return false;
		}
		sbyte requiredSkillType = ItemTemplateHelper.GetCraftRequiredLifeSkillType(itemType, itemTemplateId);
		return memberCfg.CraftTypes.Exist(requiredSkillType);
	}
}
