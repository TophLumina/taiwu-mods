using System;
using Config.Common;

namespace Config;

[Serializable]
public class AdventureLifeSkillRequirementItem : ConfigItem<AdventureLifeSkillRequirementItem, byte>
{
	public readonly byte TemplateId;

	public readonly short RequiredValue;

	public readonly short Weight;

	public AdventureLifeSkillRequirementItem(byte templateId, short requiredValue, short weight)
	{
		TemplateId = templateId;
		RequiredValue = requiredValue;
		Weight = weight;
	}

	public AdventureLifeSkillRequirementItem()
	{
		TemplateId = 0;
		RequiredValue = 0;
		Weight = 0;
	}

	public AdventureLifeSkillRequirementItem(byte templateId, AdventureLifeSkillRequirementItem other)
	{
		TemplateId = templateId;
		RequiredValue = other.RequiredValue;
		Weight = other.Weight;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override AdventureLifeSkillRequirementItem Duplicate(int templateId)
	{
		return new AdventureLifeSkillRequirementItem((byte)templateId, this);
	}
}
