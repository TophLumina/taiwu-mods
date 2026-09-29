using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class CharacterTableItem : ConfigItem<CharacterTableItem, short>
{
	public readonly short TemplateId;

	public readonly string Title;

	public readonly ECharacterTableType Type;

	public readonly List<short> Elements;

	public readonly List<int> Width;

	public CharacterTableItem(short templateId, string title, ECharacterTableType type, List<short> elements, List<int> width)
	{
		TemplateId = templateId;
		Title = title;
		Type = type;
		Elements = elements;
		Width = width;
	}

	public CharacterTableItem()
	{
		TemplateId = 0;
		Title = null;
		Type = ECharacterTableType.Invalid;
		Elements = null;
		Width = null;
	}

	public CharacterTableItem(short templateId, CharacterTableItem other)
	{
		TemplateId = templateId;
		Title = other.Title;
		Type = other.Type;
		Elements = other.Elements;
		Width = other.Width;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override CharacterTableItem Duplicate(int templateId)
	{
		return new CharacterTableItem((short)templateId, this);
	}
}
