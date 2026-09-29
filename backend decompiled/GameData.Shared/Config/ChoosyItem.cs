using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class ChoosyItem : ConfigItem<ChoosyItem, short>
{
	public readonly short TemplateId;

	public readonly int BaseUpgradeRate;

	public readonly int MaxUpgradeRate;

	public readonly int BaseUpgradeCount;

	public readonly int MaxUpgradeCount;

	public readonly List<short> GradeList;

	public readonly int AttainmentRate;

	public readonly int UpgradeRateAttainmentBonus;

	public readonly int UpgradeCountAttainmentBonus;

	public readonly sbyte LifeSkillType;

	public ChoosyItem(short templateId, int baseUpgradeRate, int maxUpgradeRate, int baseUpgradeCount, int maxUpgradeCount, List<short> gradeList, int attainmentRate, int upgradeRateAttainmentBonus, int upgradeCountAttainmentBonus, sbyte lifeSkillType)
	{
		TemplateId = templateId;
		BaseUpgradeRate = baseUpgradeRate;
		MaxUpgradeRate = maxUpgradeRate;
		BaseUpgradeCount = baseUpgradeCount;
		MaxUpgradeCount = maxUpgradeCount;
		GradeList = gradeList;
		AttainmentRate = attainmentRate;
		UpgradeRateAttainmentBonus = upgradeRateAttainmentBonus;
		UpgradeCountAttainmentBonus = upgradeCountAttainmentBonus;
		LifeSkillType = lifeSkillType;
	}

	public ChoosyItem()
	{
		TemplateId = 0;
		BaseUpgradeRate = 0;
		MaxUpgradeRate = 0;
		BaseUpgradeCount = 0;
		MaxUpgradeCount = 0;
		GradeList = null;
		AttainmentRate = 0;
		UpgradeRateAttainmentBonus = 0;
		UpgradeCountAttainmentBonus = 0;
		LifeSkillType = 0;
	}

	public ChoosyItem(short templateId, ChoosyItem other)
	{
		TemplateId = templateId;
		BaseUpgradeRate = other.BaseUpgradeRate;
		MaxUpgradeRate = other.MaxUpgradeRate;
		BaseUpgradeCount = other.BaseUpgradeCount;
		MaxUpgradeCount = other.MaxUpgradeCount;
		GradeList = other.GradeList;
		AttainmentRate = other.AttainmentRate;
		UpgradeRateAttainmentBonus = other.UpgradeRateAttainmentBonus;
		UpgradeCountAttainmentBonus = other.UpgradeCountAttainmentBonus;
		LifeSkillType = other.LifeSkillType;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override ChoosyItem Duplicate(int templateId)
	{
		return new ChoosyItem((short)templateId, this);
	}
}
