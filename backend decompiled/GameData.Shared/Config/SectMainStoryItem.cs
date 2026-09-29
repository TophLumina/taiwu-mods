using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class SectMainStoryItem : ConfigItem<SectMainStoryItem, sbyte>
{
	public readonly sbyte TemplateId;

	public readonly string Name;

	public readonly string UnlockStoryLogo;

	public readonly string UnlockStoryBg;

	public readonly string UnlockStoryDesc;

	public readonly int[] TaskChains;

	public readonly sbyte TaskReadyWorldState;

	public readonly List<short> GoodEndingsInformation;

	public readonly List<short> BadEndingsInformation;

	public readonly short GoodEndingMonthlyEvent;

	public readonly short BadEndingMonthlyEvent;

	public readonly string GoodEndDateKey;

	public readonly string BadEndDateKey;

	public readonly int RequireDefeatSwordTombCount;

	public SectMainStoryItem(sbyte templateId, string name, string unlockStoryLogo, string unlockStoryBg, string unlockStoryDesc, int[] taskChains, sbyte taskReadyWorldState, List<short> goodEndingsInformation, List<short> badEndingsInformation, short goodEndingMonthlyEvent, short badEndingMonthlyEvent, string goodEndDateKey, string badEndDateKey, int requireDefeatSwordTombCount)
	{
		TemplateId = templateId;
		Name = name;
		UnlockStoryLogo = unlockStoryLogo;
		UnlockStoryBg = unlockStoryBg;
		UnlockStoryDesc = unlockStoryDesc;
		TaskChains = taskChains;
		TaskReadyWorldState = taskReadyWorldState;
		GoodEndingsInformation = goodEndingsInformation;
		BadEndingsInformation = badEndingsInformation;
		GoodEndingMonthlyEvent = goodEndingMonthlyEvent;
		BadEndingMonthlyEvent = badEndingMonthlyEvent;
		GoodEndDateKey = goodEndDateKey;
		BadEndDateKey = badEndDateKey;
		RequireDefeatSwordTombCount = requireDefeatSwordTombCount;
	}

	public SectMainStoryItem()
	{
		TemplateId = 0;
		Name = null;
		UnlockStoryLogo = null;
		UnlockStoryBg = null;
		UnlockStoryDesc = null;
		TaskChains = null;
		TaskReadyWorldState = 0;
		GoodEndingsInformation = null;
		BadEndingsInformation = null;
		GoodEndingMonthlyEvent = 0;
		BadEndingMonthlyEvent = 0;
		GoodEndDateKey = null;
		BadEndDateKey = null;
		RequireDefeatSwordTombCount = 0;
	}

	public SectMainStoryItem(sbyte templateId, SectMainStoryItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		UnlockStoryLogo = other.UnlockStoryLogo;
		UnlockStoryBg = other.UnlockStoryBg;
		UnlockStoryDesc = other.UnlockStoryDesc;
		TaskChains = other.TaskChains;
		TaskReadyWorldState = other.TaskReadyWorldState;
		GoodEndingsInformation = other.GoodEndingsInformation;
		BadEndingsInformation = other.BadEndingsInformation;
		GoodEndingMonthlyEvent = other.GoodEndingMonthlyEvent;
		BadEndingMonthlyEvent = other.BadEndingMonthlyEvent;
		GoodEndDateKey = other.GoodEndDateKey;
		BadEndDateKey = other.BadEndDateKey;
		RequireDefeatSwordTombCount = other.RequireDefeatSwordTombCount;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override SectMainStoryItem Duplicate(int templateId)
	{
		return new SectMainStoryItem((sbyte)templateId, this);
	}
}
