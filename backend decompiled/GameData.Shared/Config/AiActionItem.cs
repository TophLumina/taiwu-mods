using System;
using System.Collections.Generic;
using AiEditor;
using Config.Common;

namespace Config;

[Serializable]
public class AiActionItem : ConfigItem<AiActionItem, int>, IAiConfigTuple
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly int TemplateId;

	/// <summary>
	/// 类型
	/// </summary>
	public readonly EAiActionType Type;

	/// <summary>
	/// 名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 说明
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 文本参数
	/// - 此处由程序维护，与代码中解析顺序对应，如有新增参数需求，请联系程序修改
	/// </summary>
	public readonly List<int> ParamStrings;

	/// <summary>
	/// 数字参数
	/// </summary>
	public readonly List<int> ParamInts;

	/// <summary>
	/// 所属组
	/// - 此列由程序维护，前端编辑器使用，后端实现需确保与配置值一致
	/// </summary>
	public readonly int GroupId;

	int IAiConfigTuple.TemplateId => TemplateId;

	int IAiConfigTuple.GroupId => GroupId;

	string IAiConfigTuple.Name => Name;

	string IAiConfigTuple.Desc => Desc;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="type">类型</param>
	/// <param name="name">名称</param>
	/// <param name="desc">说明</param>
	/// <param name="paramStrings">文本参数 - 此处由程序维护，与代码中解析顺序对应，如有新增参数需求，请联系程序修改</param>
	/// <param name="paramInts">数字参数</param>
	/// <param name="groupId">所属组 - 此列由程序维护，前端编辑器使用，后端实现需确保与配置值一致</param>
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

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
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

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
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

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override AiActionItem Duplicate(int templateId)
	{
		return new AiActionItem(templateId, this);
	}
}
