using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class EventFunctionItem : ConfigItem<EventFunctionItem, int>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly int TemplateId;

	/// <summary>
	/// 指令类型
	/// </summary>
	public readonly EEventFunctionType Type;

	/// <summary>
	/// 指令名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 指令描述
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 参数列表
	/// - 用于给前端编辑器决定输入类型。
	/// </summary>
	public readonly int[] ParameterTypes;

	/// <summary>
	/// 参数名列表
	/// - 可不填，显示名称与EventArgument中的配置不同时填写
	/// </summary>
	public readonly string[] ParameterNames;

	/// <summary>
	/// 返回类型
	/// - 用于给前端编辑器显示返回类型。
	/// </summary>
	public readonly int ReturnValue;

	/// <summary>
	/// 添加缩进
	/// - 用于在编辑器中给下一条指令添加缩进。
	/// </summary>
	public readonly bool IndentNext;

	/// <summary>
	/// 同步添加
	/// </summary>
	public readonly int FollowUp;

	/// <summary>
	/// 可以手动添加
	/// </summary>
	public readonly bool CanCreateManually;

	/// <summary>
	/// 依赖的指令
	/// - 上一条同缩进的指令必须为指定指令。
	/// </summary>
	public readonly List<int> RequiredPreviousCommands;

	/// <summary>
	/// 只允许在条件中使用
	/// </summary>
	public readonly bool AllowedInCondition;

	/// <summary>
	/// 是否存在事件跳转
	/// - 用于在编辑器中检测可能的事件跳转.
	/// </summary>
	public readonly bool IsTransition;

	/// <summary>
	/// 允许外部使用
	/// - 不允许的情况，在编辑器中只有Debug模式下可调用该指令 (不影响运行时)
	/// </summary>
	public readonly bool AllowExternalUsage;

	/// <summary>
	/// 游戏内提示文本
	/// - 用于选项可用条件.
	/// </summary>
	public readonly string InGameHint;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="type">指令类型</param>
	/// <param name="name">指令名称</param>
	/// <param name="desc">指令描述</param>
	/// <param name="parameterTypes">参数列表 - 用于给前端编辑器决定输入类型。</param>
	/// <param name="parameterNames">参数名列表 - 可不填，显示名称与EventArgument中的配置不同时填写</param>
	/// <param name="returnValue">返回类型 - 用于给前端编辑器显示返回类型。</param>
	/// <param name="indentNext">添加缩进 - 用于在编辑器中给下一条指令添加缩进。</param>
	/// <param name="followUp">同步添加</param>
	/// <param name="canCreateManually">可以手动添加</param>
	/// <param name="requiredPreviousCommands">依赖的指令 - 上一条同缩进的指令必须为指定指令。</param>
	/// <param name="allowedInCondition">只允许在条件中使用</param>
	/// <param name="isTransition">是否存在事件跳转 - 用于在编辑器中检测可能的事件跳转.</param>
	/// <param name="allowExternalUsage">允许外部使用 - 不允许的情况，在编辑器中只有Debug模式下可调用该指令 (不影响运行时)</param>
	/// <param name="inGameHint">游戏内提示文本 - 用于选项可用条件.</param>
	public EventFunctionItem(int templateId, EEventFunctionType type, string name, string desc, int[] parameterTypes, string[] parameterNames, int returnValue, bool indentNext, int followUp, bool canCreateManually, List<int> requiredPreviousCommands, bool allowedInCondition, bool isTransition, bool allowExternalUsage, string inGameHint)
	{
		TemplateId = templateId;
		Type = type;
		Name = name;
		Desc = desc;
		ParameterTypes = parameterTypes;
		ParameterNames = parameterNames;
		ReturnValue = returnValue;
		IndentNext = indentNext;
		FollowUp = followUp;
		CanCreateManually = canCreateManually;
		RequiredPreviousCommands = requiredPreviousCommands;
		AllowedInCondition = allowedInCondition;
		IsTransition = isTransition;
		AllowExternalUsage = allowExternalUsage;
		InGameHint = inGameHint;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public EventFunctionItem()
	{
		TemplateId = 0;
		Type = EEventFunctionType.Invalid;
		Name = null;
		Desc = null;
		ParameterTypes = new int[0];
		ParameterNames = new string[0];
		ReturnValue = 0;
		IndentNext = false;
		FollowUp = 0;
		CanCreateManually = true;
		RequiredPreviousCommands = new List<int>();
		AllowedInCondition = false;
		IsTransition = false;
		AllowExternalUsage = true;
		InGameHint = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public EventFunctionItem(int templateId, EventFunctionItem other)
	{
		TemplateId = templateId;
		Type = other.Type;
		Name = other.Name;
		Desc = other.Desc;
		ParameterTypes = other.ParameterTypes;
		ParameterNames = other.ParameterNames;
		ReturnValue = other.ReturnValue;
		IndentNext = other.IndentNext;
		FollowUp = other.FollowUp;
		CanCreateManually = other.CanCreateManually;
		RequiredPreviousCommands = other.RequiredPreviousCommands;
		AllowedInCondition = other.AllowedInCondition;
		IsTransition = other.IsTransition;
		AllowExternalUsage = other.AllowExternalUsage;
		InGameHint = other.InGameHint;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override EventFunctionItem Duplicate(int templateId)
	{
		return new EventFunctionItem(templateId, this);
	}
}
