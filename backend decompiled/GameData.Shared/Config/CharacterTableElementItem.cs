using System;
using Config.Common;

namespace Config;

[Serializable]
public class CharacterTableElementItem : ConfigItem<CharacterTableElementItem, short>
{
	public readonly short TemplateId;

	public readonly string Name;

	public readonly ECharacterTableElementType Type;

	public readonly bool CanSort;

	public readonly bool CanHighlight;

	public readonly bool NeedAsync;

	public readonly bool HideProperty;

	public CharacterTableElementItem(short templateId, string name, ECharacterTableElementType type, bool canSort, bool canHighlight, bool needAsync, bool hideProperty)
	{
		TemplateId = templateId;
		Name = name;
		Type = type;
		CanSort = canSort;
		CanHighlight = canHighlight;
		NeedAsync = needAsync;
		HideProperty = hideProperty;
	}

	public CharacterTableElementItem()
	{
		TemplateId = 0;
		Name = null;
		Type = ECharacterTableElementType.Text;
		CanSort = true;
		CanHighlight = true;
		NeedAsync = false;
		HideProperty = false;
	}

	public CharacterTableElementItem(short templateId, CharacterTableElementItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Type = other.Type;
		CanSort = other.CanSort;
		CanHighlight = other.CanHighlight;
		NeedAsync = other.NeedAsync;
		HideProperty = other.HideProperty;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override CharacterTableElementItem Duplicate(int templateId)
	{
		return new CharacterTableElementItem((short)templateId, this);
	}
}
