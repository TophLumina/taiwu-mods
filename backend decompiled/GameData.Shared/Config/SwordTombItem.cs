using System;
using Config.Common;

namespace Config;

[Serializable]
public class SwordTombItem : ConfigItem<SwordTombItem, sbyte>
{
	public readonly sbyte TemplateId;

	public readonly int AdventureCoreId;

	public readonly short XiangshuAvatarBegin;

	public readonly short WeakenedXiangshuAvatarBegin;

	public readonly short JuniorXiangshuAvatar;

	public readonly short PuppetXiangshuAvatar;

	public readonly short ImmortalXiangshuAvatar;

	public readonly short[] Legacies;

	public readonly short BigEventWhenRemoved;

	public readonly short SwordFragment;

	public readonly short MonthlyEventGood;

	public readonly short MonthlyEventBad;

	public readonly short DefeatAchievementStat;

	public SwordTombItem(sbyte templateId, int adventureCoreId, short xiangshuAvatarBegin, short weakenedXiangshuAvatarBegin, short juniorXiangshuAvatar, short puppetXiangshuAvatar, short immortalXiangshuAvatar, short[] legacies, short bigEventWhenRemoved, short swordFragment, short monthlyEventGood, short monthlyEventBad, short defeatAchievementStat)
	{
		TemplateId = templateId;
		AdventureCoreId = adventureCoreId;
		XiangshuAvatarBegin = xiangshuAvatarBegin;
		WeakenedXiangshuAvatarBegin = weakenedXiangshuAvatarBegin;
		JuniorXiangshuAvatar = juniorXiangshuAvatar;
		PuppetXiangshuAvatar = puppetXiangshuAvatar;
		ImmortalXiangshuAvatar = immortalXiangshuAvatar;
		Legacies = legacies;
		BigEventWhenRemoved = bigEventWhenRemoved;
		SwordFragment = swordFragment;
		MonthlyEventGood = monthlyEventGood;
		MonthlyEventBad = monthlyEventBad;
		DefeatAchievementStat = defeatAchievementStat;
	}

	public SwordTombItem()
	{
		TemplateId = 0;
		AdventureCoreId = 0;
		XiangshuAvatarBegin = 0;
		WeakenedXiangshuAvatarBegin = 0;
		JuniorXiangshuAvatar = 0;
		PuppetXiangshuAvatar = 0;
		ImmortalXiangshuAvatar = 0;
		Legacies = null;
		BigEventWhenRemoved = 0;
		SwordFragment = 0;
		MonthlyEventGood = 0;
		MonthlyEventBad = 0;
		DefeatAchievementStat = 0;
	}

	public SwordTombItem(sbyte templateId, SwordTombItem other)
	{
		TemplateId = templateId;
		AdventureCoreId = other.AdventureCoreId;
		XiangshuAvatarBegin = other.XiangshuAvatarBegin;
		WeakenedXiangshuAvatarBegin = other.WeakenedXiangshuAvatarBegin;
		JuniorXiangshuAvatar = other.JuniorXiangshuAvatar;
		PuppetXiangshuAvatar = other.PuppetXiangshuAvatar;
		ImmortalXiangshuAvatar = other.ImmortalXiangshuAvatar;
		Legacies = other.Legacies;
		BigEventWhenRemoved = other.BigEventWhenRemoved;
		SwordFragment = other.SwordFragment;
		MonthlyEventGood = other.MonthlyEventGood;
		MonthlyEventBad = other.MonthlyEventBad;
		DefeatAchievementStat = other.DefeatAchievementStat;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override SwordTombItem Duplicate(int templateId)
	{
		return new SwordTombItem((sbyte)templateId, this);
	}
}
