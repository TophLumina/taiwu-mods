using System;
using Config.Common;

namespace Config;

[Serializable]
public class SkillBreakBonusEffectItem : ConfigItem<SkillBreakBonusEffectItem, sbyte>
{
	public readonly sbyte TemplateId;

	public readonly string ShortName;

	public readonly string Name;

	public readonly sbyte EffectNeigong;

	public readonly sbyte EffectAttack;

	public readonly sbyte EffectAgile;

	public readonly sbyte EffectDefense;

	public readonly sbyte EffectAssist;

	public SkillBreakBonusEffectItem(sbyte templateId, string shortName, string name, sbyte effectNeigong, sbyte effectAttack, sbyte effectAgile, sbyte effectDefense, sbyte effectAssist)
	{
		TemplateId = templateId;
		ShortName = shortName;
		Name = name;
		EffectNeigong = effectNeigong;
		EffectAttack = effectAttack;
		EffectAgile = effectAgile;
		EffectDefense = effectDefense;
		EffectAssist = effectAssist;
	}

	public SkillBreakBonusEffectItem()
	{
		TemplateId = 0;
		ShortName = null;
		Name = null;
		EffectNeigong = 0;
		EffectAttack = 0;
		EffectAgile = 0;
		EffectDefense = 0;
		EffectAssist = 0;
	}

	public SkillBreakBonusEffectItem(sbyte templateId, SkillBreakBonusEffectItem other)
	{
		TemplateId = templateId;
		ShortName = other.ShortName;
		Name = other.Name;
		EffectNeigong = other.EffectNeigong;
		EffectAttack = other.EffectAttack;
		EffectAgile = other.EffectAgile;
		EffectDefense = other.EffectDefense;
		EffectAssist = other.EffectAssist;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override SkillBreakBonusEffectItem Duplicate(int templateId)
	{
		return new SkillBreakBonusEffectItem((sbyte)templateId, this);
	}

	public int GetImplementId(sbyte equipType)
	{
		return equipType switch
		{
			0 => EffectNeigong, 
			1 => EffectAttack, 
			2 => EffectAgile, 
			3 => EffectDefense, 
			4 => EffectAssist, 
			_ => -1, 
		};
	}
}
