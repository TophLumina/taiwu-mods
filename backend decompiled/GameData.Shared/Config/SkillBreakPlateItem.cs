using System;
using Config.Common;

namespace Config;

[Serializable]
public class SkillBreakPlateItem : ConfigItem<SkillBreakPlateItem, sbyte>
{
	public readonly sbyte TemplateId;

	public readonly byte PlateWidth;

	public readonly byte PlateHeight;

	public readonly short CostExp;

	public readonly short TotalMaxPower;

	public readonly int BonusCount;

	public SkillBreakPlateItem(sbyte templateId, byte plateWidth, byte plateHeight, short costExp, short totalMaxPower, int bonusCount)
	{
		TemplateId = templateId;
		PlateWidth = plateWidth;
		PlateHeight = plateHeight;
		CostExp = costExp;
		TotalMaxPower = totalMaxPower;
		BonusCount = bonusCount;
	}

	public SkillBreakPlateItem()
	{
		TemplateId = 0;
		PlateWidth = 0;
		PlateHeight = 0;
		CostExp = 0;
		TotalMaxPower = 0;
		BonusCount = 0;
	}

	public SkillBreakPlateItem(sbyte templateId, SkillBreakPlateItem other)
	{
		TemplateId = templateId;
		PlateWidth = other.PlateWidth;
		PlateHeight = other.PlateHeight;
		CostExp = other.CostExp;
		TotalMaxPower = other.TotalMaxPower;
		BonusCount = other.BonusCount;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override SkillBreakPlateItem Duplicate(int templateId)
	{
		return new SkillBreakPlateItem((sbyte)templateId, this);
	}
}
