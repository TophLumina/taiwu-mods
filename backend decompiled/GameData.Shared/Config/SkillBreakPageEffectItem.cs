using System;
using Config.Common;

namespace Config;

[Serializable]
public class SkillBreakPageEffectItem : ConfigItem<SkillBreakPageEffectItem, sbyte>
{
	public readonly sbyte TemplateId;

	public readonly bool IsDirect;

	public readonly byte PageId;

	public readonly sbyte EffectNeigong;

	public readonly sbyte EffectAttack;

	public readonly sbyte EffectAgile;

	public readonly sbyte EffectDefense;

	public readonly sbyte EffectAssist;

	public SkillBreakPageEffectItem(sbyte templateId, bool isDirect, byte pageId, sbyte effectNeigong, sbyte effectAttack, sbyte effectAgile, sbyte effectDefense, sbyte effectAssist)
	{
		TemplateId = templateId;
		IsDirect = isDirect;
		PageId = pageId;
		EffectNeigong = effectNeigong;
		EffectAttack = effectAttack;
		EffectAgile = effectAgile;
		EffectDefense = effectDefense;
		EffectAssist = effectAssist;
	}

	public SkillBreakPageEffectItem()
	{
		TemplateId = 0;
		IsDirect = false;
		PageId = 0;
		EffectNeigong = 0;
		EffectAttack = 0;
		EffectAgile = 0;
		EffectDefense = 0;
		EffectAssist = 0;
	}

	public SkillBreakPageEffectItem(sbyte templateId, SkillBreakPageEffectItem other)
	{
		TemplateId = templateId;
		IsDirect = other.IsDirect;
		PageId = other.PageId;
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

	public override SkillBreakPageEffectItem Duplicate(int templateId)
	{
		return new SkillBreakPageEffectItem((sbyte)templateId, this);
	}
}
