using System;
using System.Collections.Generic;
using Config.Common;
using Config.ConfigCells;

namespace Config;

[Serializable]
public class MysteryEffectItem : ConfigItem<MysteryEffectItem, int>
{
	/// <summary>
	/// ID
	/// </summary>
	public readonly int TemplateId;

	/// <summary>
	/// 契合度需求
	/// </summary>
	public readonly int CompatibilityRequirement;

	/// <summary>
	/// 激活所需威力
	/// </summary>
	public readonly List<int> PowerRequirements;

	/// <summary>
	/// 数值效果
	/// </summary>
	public readonly List<List<PropertyAndValueAndModifyType>> BonusValues;

	/// <summary>
	/// 机制效果
	/// </summary>
	public readonly List<short> BonusEffects;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">ID</param>
	/// <param name="compatibilityRequirement">契合度需求</param>
	/// <param name="powerRequirements">激活所需威力</param>
	/// <param name="bonusValues">数值效果</param>
	/// <param name="bonusEffects">机制效果</param>
	public MysteryEffectItem(int templateId, int compatibilityRequirement, List<int> powerRequirements, List<List<PropertyAndValueAndModifyType>> bonusValues, List<short> bonusEffects)
	{
		TemplateId = templateId;
		CompatibilityRequirement = compatibilityRequirement;
		PowerRequirements = powerRequirements;
		BonusValues = bonusValues;
		BonusEffects = bonusEffects;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public MysteryEffectItem()
	{
		TemplateId = 0;
		CompatibilityRequirement = 300;
		PowerRequirements = new List<int> { 100, 120, 140, 180 };
		BonusValues = null;
		BonusEffects = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public MysteryEffectItem(int templateId, MysteryEffectItem other)
	{
		TemplateId = templateId;
		CompatibilityRequirement = other.CompatibilityRequirement;
		PowerRequirements = other.PowerRequirements;
		BonusValues = other.BonusValues;
		BonusEffects = other.BonusEffects;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override MysteryEffectItem Duplicate(int templateId)
	{
		return new MysteryEffectItem(templateId, this);
	}
}
