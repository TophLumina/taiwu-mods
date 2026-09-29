using System;
using System.Collections.Generic;
using Config.Common;
using Config.ConfigCells;
using Config.ConfigCells.Character;

namespace Config;

[Serializable]
public class MapPickupsItem : ConfigItem<MapPickupsItem, short>
{
	public readonly short TemplateId;

	public readonly string Name;

	public readonly EMapPickupsType Type;

	public readonly EMapPickupsType2 Type2;

	public readonly string Icon;

	public readonly string TipsContent;

	public readonly byte SpecialAreaTimes;

	public readonly byte[] StateTimes;

	public readonly List<short> BlockList;

	public readonly bool ReadEffect;

	public readonly bool LoopEffect;

	public readonly bool IsExpBonus;

	public readonly bool IsDebtBonus;

	public readonly int[] BonusCount;

	public readonly sbyte[] ItemGrade;

	public readonly PresetItemTemplateId ItemGroup;

	public readonly sbyte[] XiangshuLevel;

	public readonly short[] Resources;

	public readonly bool[] CanShowMonths;

	public readonly short ShowConditionInformation;

	public readonly OrganizationApproving ShowConditionOrganizationApproving;

	public readonly short InstantNotification;

	public readonly short ExtraBonusAddInstantNotification;

	public readonly short ExtraBonusReplaceInstantNotification;

	public readonly string EventMainContent;

	public readonly string[] EventMainOptions;

	public readonly string[] EventSecondContents;

	public readonly string[] EventSecondOptions;

	public readonly List<PresetItemWithCount> EventSecondItemRewards;

	public readonly List<ResourceInfo> EventSecondResourceRewards;

	public readonly List<PropertyAndValue> EventSecondPropertyRewards;

	public readonly List<int> EventSecondDebtRewards;

	public readonly List<int> EventSecondExpRewards;

	public readonly List<PresetItemWithCount> EventSecondItemRewardSelection1;

	public readonly List<PresetItemWithCount> EventSecondItemRewardSelection2;

	public MapPickupsItem(short templateId, string name, EMapPickupsType type, EMapPickupsType2 type2, string icon, string tipsContent, byte specialAreaTimes, byte[] stateTimes, List<short> blockList, bool readEffect, bool loopEffect, bool isExpBonus, bool isDebtBonus, int[] bonusCount, sbyte[] itemGrade, PresetItemTemplateId itemGroup, sbyte[] xiangshuLevel, short[] resources, bool[] canShowMonths, short showConditionInformation, OrganizationApproving showConditionOrganizationApproving, short instantNotification, short extraBonusAddInstantNotification, short extraBonusReplaceInstantNotification, string eventMainContent, string[] eventMainOptions, string[] eventSecondContents, string[] eventSecondOptions, List<PresetItemWithCount> eventSecondItemRewards, List<ResourceInfo> eventSecondResourceRewards, List<PropertyAndValue> eventSecondPropertyRewards, List<int> eventSecondDebtRewards, List<int> eventSecondExpRewards, List<PresetItemWithCount> eventSecondItemRewardSelection1, List<PresetItemWithCount> eventSecondItemRewardSelection2)
	{
		TemplateId = templateId;
		Name = name;
		Type = type;
		Type2 = type2;
		Icon = icon;
		TipsContent = tipsContent;
		SpecialAreaTimes = specialAreaTimes;
		StateTimes = stateTimes;
		BlockList = blockList;
		ReadEffect = readEffect;
		LoopEffect = loopEffect;
		IsExpBonus = isExpBonus;
		IsDebtBonus = isDebtBonus;
		BonusCount = bonusCount;
		ItemGrade = itemGrade;
		ItemGroup = itemGroup;
		XiangshuLevel = xiangshuLevel;
		Resources = resources;
		CanShowMonths = canShowMonths;
		ShowConditionInformation = showConditionInformation;
		ShowConditionOrganizationApproving = showConditionOrganizationApproving;
		InstantNotification = instantNotification;
		ExtraBonusAddInstantNotification = extraBonusAddInstantNotification;
		ExtraBonusReplaceInstantNotification = extraBonusReplaceInstantNotification;
		EventMainContent = eventMainContent;
		EventMainOptions = eventMainOptions;
		EventSecondContents = eventSecondContents;
		EventSecondOptions = eventSecondOptions;
		EventSecondItemRewards = eventSecondItemRewards;
		EventSecondResourceRewards = eventSecondResourceRewards;
		EventSecondPropertyRewards = eventSecondPropertyRewards;
		EventSecondDebtRewards = eventSecondDebtRewards;
		EventSecondExpRewards = eventSecondExpRewards;
		EventSecondItemRewardSelection1 = eventSecondItemRewardSelection1;
		EventSecondItemRewardSelection2 = eventSecondItemRewardSelection2;
	}

	public MapPickupsItem()
	{
		TemplateId = 0;
		Name = null;
		Type = EMapPickupsType.Invalid;
		Type2 = EMapPickupsType2.Invalid;
		Icon = null;
		TipsContent = null;
		SpecialAreaTimes = 0;
		StateTimes = new byte[15];
		BlockList = null;
		ReadEffect = false;
		LoopEffect = false;
		IsExpBonus = false;
		IsDebtBonus = false;
		BonusCount = new int[0];
		ItemGrade = new sbyte[0];
		ItemGroup = default(PresetItemTemplateId);
		XiangshuLevel = new sbyte[0];
		Resources = new short[6];
		CanShowMonths = new bool[12]
		{
			true, true, true, true, true, true, true, true, true, true,
			true, true
		};
		ShowConditionInformation = 0;
		ShowConditionOrganizationApproving = new OrganizationApproving();
		InstantNotification = 0;
		ExtraBonusAddInstantNotification = 0;
		ExtraBonusReplaceInstantNotification = 0;
		EventMainContent = null;
		EventMainOptions = new string[0];
		EventSecondContents = new string[0];
		EventSecondOptions = new string[0];
		EventSecondItemRewards = new List<PresetItemWithCount>();
		EventSecondResourceRewards = new List<ResourceInfo>();
		EventSecondPropertyRewards = new List<PropertyAndValue>();
		EventSecondDebtRewards = new List<int>();
		EventSecondExpRewards = new List<int>();
		EventSecondItemRewardSelection1 = new List<PresetItemWithCount>();
		EventSecondItemRewardSelection2 = new List<PresetItemWithCount>();
	}

	public MapPickupsItem(short templateId, MapPickupsItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Type = other.Type;
		Type2 = other.Type2;
		Icon = other.Icon;
		TipsContent = other.TipsContent;
		SpecialAreaTimes = other.SpecialAreaTimes;
		StateTimes = other.StateTimes;
		BlockList = other.BlockList;
		ReadEffect = other.ReadEffect;
		LoopEffect = other.LoopEffect;
		IsExpBonus = other.IsExpBonus;
		IsDebtBonus = other.IsDebtBonus;
		BonusCount = other.BonusCount;
		ItemGrade = other.ItemGrade;
		ItemGroup = other.ItemGroup;
		XiangshuLevel = other.XiangshuLevel;
		Resources = other.Resources;
		CanShowMonths = other.CanShowMonths;
		ShowConditionInformation = other.ShowConditionInformation;
		ShowConditionOrganizationApproving = other.ShowConditionOrganizationApproving;
		InstantNotification = other.InstantNotification;
		ExtraBonusAddInstantNotification = other.ExtraBonusAddInstantNotification;
		ExtraBonusReplaceInstantNotification = other.ExtraBonusReplaceInstantNotification;
		EventMainContent = other.EventMainContent;
		EventMainOptions = other.EventMainOptions;
		EventSecondContents = other.EventSecondContents;
		EventSecondOptions = other.EventSecondOptions;
		EventSecondItemRewards = other.EventSecondItemRewards;
		EventSecondResourceRewards = other.EventSecondResourceRewards;
		EventSecondPropertyRewards = other.EventSecondPropertyRewards;
		EventSecondDebtRewards = other.EventSecondDebtRewards;
		EventSecondExpRewards = other.EventSecondExpRewards;
		EventSecondItemRewardSelection1 = other.EventSecondItemRewardSelection1;
		EventSecondItemRewardSelection2 = other.EventSecondItemRewardSelection2;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override MapPickupsItem Duplicate(int templateId)
	{
		return new MapPickupsItem((short)templateId, this);
	}
}
