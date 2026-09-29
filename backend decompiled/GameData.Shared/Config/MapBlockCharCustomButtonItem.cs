using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class MapBlockCharCustomButtonItem : ConfigItem<MapBlockCharCustomButtonItem, short>
{
	public readonly short TemplateId;

	public readonly string Name;

	public readonly EMapBlockCharCustomButtonLogicType LogicType;

	public readonly EMapBlockCharCustomButtonDisplayGroup DisplayGroup;

	public readonly List<short> InteractionEventOption;

	public MapBlockCharCustomButtonItem(short templateId, string name, EMapBlockCharCustomButtonLogicType logicType, EMapBlockCharCustomButtonDisplayGroup displayGroup, List<short> interactionEventOption)
	{
		TemplateId = templateId;
		Name = name;
		LogicType = logicType;
		DisplayGroup = displayGroup;
		InteractionEventOption = interactionEventOption;
	}

	public MapBlockCharCustomButtonItem()
	{
		TemplateId = 0;
		Name = null;
		LogicType = EMapBlockCharCustomButtonLogicType.Invalid;
		DisplayGroup = EMapBlockCharCustomButtonDisplayGroup.TopLevel;
		InteractionEventOption = new List<short>();
	}

	public MapBlockCharCustomButtonItem(short templateId, MapBlockCharCustomButtonItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		LogicType = other.LogicType;
		DisplayGroup = other.DisplayGroup;
		InteractionEventOption = other.InteractionEventOption;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override MapBlockCharCustomButtonItem Duplicate(int templateId)
	{
		return new MapBlockCharCustomButtonItem((short)templateId, this);
	}
}
