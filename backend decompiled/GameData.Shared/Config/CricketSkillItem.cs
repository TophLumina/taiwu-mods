using System;
using Config.Common;

namespace Config;

[Serializable]
public class CricketSkillItem : ConfigItem<CricketSkillItem, int>
{
	public readonly int TemplateId;

	public readonly string Name;

	public readonly string EffectCondition;

	public readonly string EffectDesc;

	public readonly string EffectTips;

	public CricketSkillItem(int templateId, string name, string effectCondition, string effectDesc, string effectTips)
	{
		TemplateId = templateId;
		Name = name;
		EffectCondition = effectCondition;
		EffectDesc = effectDesc;
		EffectTips = effectTips;
	}

	public CricketSkillItem()
	{
		TemplateId = 0;
		Name = null;
		EffectCondition = null;
		EffectDesc = null;
		EffectTips = null;
	}

	public CricketSkillItem(int templateId, CricketSkillItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		EffectCondition = other.EffectCondition;
		EffectDesc = other.EffectDesc;
		EffectTips = other.EffectTips;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override CricketSkillItem Duplicate(int templateId)
	{
		return new CricketSkillItem(templateId, this);
	}
}
