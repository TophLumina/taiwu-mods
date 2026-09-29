using System;
using Config.Common;

namespace Config;

[Serializable]
public class CharacterTitleItem : ConfigItem<CharacterTitleItem, short>
{
	public readonly short TemplateId;

	public readonly string Name;

	public readonly short Misc;

	public readonly int Duration;

	public CharacterTitleItem(short templateId, string name, short misc, int duration)
	{
		TemplateId = templateId;
		Name = name;
		Misc = misc;
		Duration = duration;
	}

	public CharacterTitleItem()
	{
		TemplateId = 0;
		Name = null;
		Misc = 0;
		Duration = -1;
	}

	public CharacterTitleItem(short templateId, CharacterTitleItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Misc = other.Misc;
		Duration = other.Duration;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override CharacterTitleItem Duplicate(int templateId)
	{
		return new CharacterTitleItem((short)templateId, this);
	}
}
