using System;
using Config;
using GameData.Domains.Character;
using GameData.Domains.Item;
using GameData.Utilities;

namespace GameData.Domains.Organization;

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

	public static int GetAdjustedResourceSatisfyingThreshold(this OrganizationMemberItem memberCfg, sbyte resourceType)
	{
		return memberCfg.ResourceSatisfyingThreshold * (100 + memberCfg.ResourcesAdjust[resourceType]) / 100;
	}

	public static int GetAdjustedResourceSatisfyingAmount(this OrganizationMemberItem memberCfg, sbyte resourceType)
	{
		int threshold = memberCfg.GetAdjustedResourceSatisfyingThreshold(resourceType);
		return ResourceTypeHelper.WorthToResourceAmount(resourceType, threshold);
	}

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
