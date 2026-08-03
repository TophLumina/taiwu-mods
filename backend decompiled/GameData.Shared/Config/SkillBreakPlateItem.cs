using System;
using Config.Common;

namespace Config;

[Serializable]
public class SkillBreakPlateItem : ConfigItem<SkillBreakPlateItem, sbyte>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly sbyte TemplateId;

	/// <summary>
	/// 突破盘宽度
	/// </summary>
	public readonly byte PlateWidth;

	/// <summary>
	/// 突破盘高度
	/// </summary>
	public readonly byte PlateHeight;

	/// <summary>
	/// 每步消耗历练
	/// </summary>
	public readonly short CostExp;

	/// <summary>
	/// 威力上限总量
	/// </summary>
	public readonly short TotalMaxPower;

	/// <summary>
	/// 玄机格数量
	/// </summary>
	public readonly int BonusCount;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="plateWidth">突破盘宽度</param>
	/// <param name="plateHeight">突破盘高度</param>
	/// <param name="costExp">每步消耗历练</param>
	/// <param name="totalMaxPower">威力上限总量</param>
	/// <param name="bonusCount">玄机格数量</param>
	public SkillBreakPlateItem(sbyte templateId, byte plateWidth, byte plateHeight, short costExp, short totalMaxPower, int bonusCount)
	{
		TemplateId = templateId;
		PlateWidth = plateWidth;
		PlateHeight = plateHeight;
		CostExp = costExp;
		TotalMaxPower = totalMaxPower;
		BonusCount = bonusCount;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public SkillBreakPlateItem()
	{
		TemplateId = 0;
		PlateWidth = 0;
		PlateHeight = 0;
		CostExp = 0;
		TotalMaxPower = 0;
		BonusCount = 0;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
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

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override SkillBreakPlateItem Duplicate(int templateId)
	{
		return new SkillBreakPlateItem((sbyte)templateId, this);
	}
}
