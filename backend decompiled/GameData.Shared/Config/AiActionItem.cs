using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using AiEditor;
using Config.Common;

namespace Config;

[Serializable]
public class AiActionItem : ConfigItem<AiActionItem, int>, IAiConfigTuple
{
	public readonly int TemplateId;

	public readonly EAiActionType Type;

	public readonly string Name;

	public readonly string Desc;

	public readonly List<int> ParamStrings;

	public readonly List<int> ParamInts;

	public readonly int GroupId;

	public AiGroupItem Group
	{
		[return: MaybeNull]
		get
		{
			return AiGroup.Instance.GetItemOrDefault(GroupId);
		}
	}

	int IAiConfigTuple.TemplateId => TemplateId;

	int IAiConfigTuple.GroupId => GroupId;

	string IAiConfigTuple.Name => Name;

	string IAiConfigTuple.Desc => Desc;

	public AiActionItem(int templateId, EAiActionType type, string name, string desc, List<int> paramStrings, List<int> paramInts, int groupId)
	{
		TemplateId = templateId;
		Type = type;
		Name = name;
		Desc = desc;
		ParamStrings = paramStrings;
		ParamInts = paramInts;
		GroupId = groupId;
	}

	public AiActionItem()
	{
		TemplateId = 0;
		Type = EAiActionType.NormalAttack;
		Name = null;
		Desc = null;
		ParamStrings = null;
		ParamInts = null;
		GroupId = 0;
	}

	public AiActionItem(int templateId, AiActionItem other)
	{
		TemplateId = templateId;
		Type = other.Type;
		Name = other.Name;
		Desc = other.Desc;
		ParamStrings = other.ParamStrings;
		ParamInts = other.ParamInts;
		GroupId = other.GroupId;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override AiActionItem Duplicate(int templateId)
	{
		return new AiActionItem(templateId, this);
	}
}
