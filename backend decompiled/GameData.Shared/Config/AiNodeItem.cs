using System;
using AiEditor;
using Config.Common;

namespace Config;

[Serializable]
public class AiNodeItem : ConfigItem<AiNodeItem, int>, IAiConfigTuple
{
	public readonly int TemplateId;

	public readonly EAiNodeType Type;

	public readonly string Name;

	public readonly string Desc;

	public readonly bool IsAction;

	int IAiConfigTuple.TemplateId => TemplateId;

	int IAiConfigTuple.GroupId => 0;

	string IAiConfigTuple.Name => Name;

	string IAiConfigTuple.Desc => Desc;

	public AiNodeItem(int templateId, EAiNodeType type, string name, string desc, bool isAction)
	{
		TemplateId = templateId;
		Type = type;
		Name = name;
		Desc = desc;
		IsAction = isAction;
	}

	public AiNodeItem()
	{
		TemplateId = 0;
		Type = EAiNodeType.Linear;
		Name = null;
		Desc = null;
		IsAction = false;
	}

	public AiNodeItem(int templateId, AiNodeItem other)
	{
		TemplateId = templateId;
		Type = other.Type;
		Name = other.Name;
		Desc = other.Desc;
		IsAction = other.IsAction;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override AiNodeItem Duplicate(int templateId)
	{
		return new AiNodeItem(templateId, this);
	}
}
