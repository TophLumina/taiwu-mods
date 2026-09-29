using System;
using Config.Common;

namespace Config;

[Serializable]
public class CharacterMapBlockButtonItem : ConfigItem<CharacterMapBlockButtonItem, sbyte>
{
	public readonly sbyte TemplateId;

	public readonly string Name;

	public readonly string IconNormal;

	public readonly string IconHighLight;

	public readonly string IconPressed;

	public readonly string IconDisable;

	public readonly short InteractionEventOption;

	public CharacterMapBlockButtonItem(sbyte templateId, string name, string iconNormal, string iconHighLight, string iconPressed, string iconDisable, short interactionEventOption)
	{
		TemplateId = templateId;
		Name = name;
		IconNormal = iconNormal;
		IconHighLight = iconHighLight;
		IconPressed = iconPressed;
		IconDisable = iconDisable;
		InteractionEventOption = interactionEventOption;
	}

	public CharacterMapBlockButtonItem()
	{
		TemplateId = 0;
		Name = null;
		IconNormal = null;
		IconHighLight = null;
		IconPressed = null;
		IconDisable = null;
		InteractionEventOption = 0;
	}

	public CharacterMapBlockButtonItem(sbyte templateId, CharacterMapBlockButtonItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		IconNormal = other.IconNormal;
		IconHighLight = other.IconHighLight;
		IconPressed = other.IconPressed;
		IconDisable = other.IconDisable;
		InteractionEventOption = other.InteractionEventOption;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override CharacterMapBlockButtonItem Duplicate(int templateId)
	{
		return new CharacterMapBlockButtonItem((sbyte)templateId, this);
	}
}
