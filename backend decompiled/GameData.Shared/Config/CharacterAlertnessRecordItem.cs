using System;
using Config.Common;

namespace Config;

[Serializable]
public class CharacterAlertnessRecordItem : ConfigItem<CharacterAlertnessRecordItem, short>
{
	public readonly short TemplateId;

	public readonly string Name;

	public readonly string Desc;

	public readonly string[] Parameters;

	public readonly ECharacterAlertnessRecordType Type;

	public CharacterAlertnessRecordItem(short templateId, string name, string desc, string[] parameters, ECharacterAlertnessRecordType type)
	{
		TemplateId = templateId;
		Name = name;
		Desc = desc;
		Parameters = parameters;
		Type = type;
	}

	public CharacterAlertnessRecordItem()
	{
		TemplateId = 0;
		Name = null;
		Desc = null;
		Parameters = new string[5] { "", "", "", "", "" };
		Type = ECharacterAlertnessRecordType.Initial;
	}

	public CharacterAlertnessRecordItem(short templateId, CharacterAlertnessRecordItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Desc = other.Desc;
		Parameters = other.Parameters;
		Type = other.Type;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override CharacterAlertnessRecordItem Duplicate(int templateId)
	{
		return new CharacterAlertnessRecordItem((short)templateId, this);
	}
}
