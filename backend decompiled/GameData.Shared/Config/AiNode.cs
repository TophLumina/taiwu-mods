using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class AiNode : ConfigData<AiNodeItem, int>
{
	public static AiNode Instance = new AiNode();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "Desc", "TemplateId", "Type", "IsAction" };

	internal override int ToInt(int value)
	{
		return value;
	}

	internal override int ToTemplateId(int value)
	{
		return value;
	}

	private void CreateItems0()
	{
		_dataArray.Add(new AiNodeItem(0, EAiNodeType.Linear, LocalStringManager.GetConfig("AiNode_language", "Name_0"), LocalStringManager.GetConfig("AiNode_language", "Desc_0"), isAction: false));
		_dataArray.Add(new AiNodeItem(1, EAiNodeType.Branch, LocalStringManager.GetConfig("AiNode_language", "Name_1"), LocalStringManager.GetConfig("AiNode_language", "Desc_1"), isAction: false));
		_dataArray.Add(new AiNodeItem(2, EAiNodeType.Action, LocalStringManager.GetConfig("AiNode_language", "Name_2"), LocalStringManager.GetConfig("AiNode_language", "Desc_2"), isAction: true));
		_dataArray.Add(new AiNodeItem(3, EAiNodeType.Relay, LocalStringManager.GetConfig("AiNode_language", "Name_3"), LocalStringManager.GetConfig("AiNode_language", "Desc_3"), isAction: false));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<AiNodeItem>(4);
		CreateItems0();
	}
}
