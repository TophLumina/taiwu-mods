using System;
using Config.Common;

namespace Config;

[Serializable]
public class EventTriggerTypeItem : ConfigItem<EventTriggerTypeItem, int>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly int TemplateId;

	/// <summary>
	/// 参数定义
	/// </summary>
	public readonly int[] Parameters;

	/// <summary>
	/// 编辑器键
	/// </summary>
	public readonly string KeyCode;

	/// <summary>
	/// 允许过月流程自动弹出
	/// - 主要用于在处理过月事件中切入到其他流程，导致一些状态变化需要弹出事件的情况.
	/// </summary>
	public readonly bool CanTriggerInAdvanceMonth;

	/// <summary>
	/// 允许战斗界面自动弹出
	/// - 战斗中的事件触发，除非是战斗开始触发点，其他类型的事件都暂时不处理
	/// </summary>
	public readonly bool CanTriggerInCombat;

	/// <summary>
	/// 允许战斗准备界面自动弹出
	/// </summary>
	public readonly bool CanTriggerInCombatBegin;

	/// <summary>
	/// 允许外部使用
	/// </summary>
	public readonly bool AllowExternal;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="parameters">参数定义</param>
	/// <param name="keyCode">编辑器键</param>
	/// <param name="canTriggerInAdvanceMonth">允许过月流程自动弹出 - 主要用于在处理过月事件中切入到其他流程，导致一些状态变化需要弹出事件的情况.</param>
	/// <param name="canTriggerInCombat">允许战斗界面自动弹出 - 战斗中的事件触发，除非是战斗开始触发点，其他类型的事件都暂时不处理</param>
	/// <param name="canTriggerInCombatBegin">允许战斗准备界面自动弹出</param>
	/// <param name="allowExternal">允许外部使用</param>
	public EventTriggerTypeItem(int templateId, int[] parameters, string keyCode, bool canTriggerInAdvanceMonth, bool canTriggerInCombat, bool canTriggerInCombatBegin, bool allowExternal)
	{
		TemplateId = templateId;
		Parameters = parameters;
		KeyCode = keyCode;
		CanTriggerInAdvanceMonth = canTriggerInAdvanceMonth;
		CanTriggerInCombat = canTriggerInCombat;
		CanTriggerInCombatBegin = canTriggerInCombatBegin;
		AllowExternal = allowExternal;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public EventTriggerTypeItem()
	{
		TemplateId = 0;
		Parameters = new int[0];
		KeyCode = null;
		CanTriggerInAdvanceMonth = false;
		CanTriggerInCombat = false;
		CanTriggerInCombatBegin = false;
		AllowExternal = true;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public EventTriggerTypeItem(int templateId, EventTriggerTypeItem other)
	{
		TemplateId = templateId;
		Parameters = other.Parameters;
		KeyCode = other.KeyCode;
		CanTriggerInAdvanceMonth = other.CanTriggerInAdvanceMonth;
		CanTriggerInCombat = other.CanTriggerInCombat;
		CanTriggerInCombatBegin = other.CanTriggerInCombatBegin;
		AllowExternal = other.AllowExternal;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override EventTriggerTypeItem Duplicate(int templateId)
	{
		return new EventTriggerTypeItem(templateId, this);
	}
}
