using System;
using Config.Common;

namespace Config;

[Serializable]
public class InteractCheckItem : ConfigItem<InteractCheckItem, short>
{
	/// <summary>
	/// ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 行动包含阶段
	/// </summary>
	public readonly short[] ActionPhaseList;

	/// <summary>
	/// 逃跑包含阶段
	/// </summary>
	public readonly short[] EscapePhaseList;

	/// <summary>
	/// 是否判定所有阶段
	/// </summary>
	public readonly bool CheckAllPhase;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">ID</param>
	/// <param name="actionPhaseList">行动包含阶段</param>
	/// <param name="escapePhaseList">逃跑包含阶段</param>
	/// <param name="checkAllPhase">是否判定所有阶段</param>
	public InteractCheckItem(short templateId, short[] actionPhaseList, short[] escapePhaseList, bool checkAllPhase)
	{
		TemplateId = templateId;
		ActionPhaseList = actionPhaseList;
		EscapePhaseList = escapePhaseList;
		CheckAllPhase = checkAllPhase;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public InteractCheckItem()
	{
		TemplateId = 0;
		ActionPhaseList = null;
		EscapePhaseList = new short[1] { -1 };
		CheckAllPhase = false;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public InteractCheckItem(short templateId, InteractCheckItem other)
	{
		TemplateId = templateId;
		ActionPhaseList = other.ActionPhaseList;
		EscapePhaseList = other.EscapePhaseList;
		CheckAllPhase = other.CheckAllPhase;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override InteractCheckItem Duplicate(int templateId)
	{
		return new InteractCheckItem((short)templateId, this);
	}
}
