using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class MapBlockCharCustomButtonItem : ConfigItem<MapBlockCharCustomButtonItem, short>
{
	/// <summary>
	/// 模板id
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 显示名称
	/// - 此条目显示的名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 逻辑类型
	/// </summary>
	public readonly EMapBlockCharCustomButtonLogicType LogicType;

	/// <summary>
	/// 前端显示的分组
	/// </summary>
	public readonly EMapBlockCharCustomButtonDisplayGroup DisplayGroup;

	/// <summary>
	/// 对应的互动条目
	/// - 可以对应多个条目，执行时选第1个可执行的，这样设计是因为互动表本身存在多个条目实际对应一个行为的，例如：修习-请教技艺1到3
	/// </summary>
	public readonly List<short> InteractionEventOption;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板id</param>
	/// <param name="name">显示名称 - 此条目显示的名称</param>
	/// <param name="logicType">逻辑类型</param>
	/// <param name="displayGroup">前端显示的分组</param>
	/// <param name="interactionEventOption">对应的互动条目 - 可以对应多个条目，执行时选第1个可执行的，这样设计是因为互动表本身存在多个条目实际对应一个行为的，例如：修习-请教技艺1到3</param>
	public MapBlockCharCustomButtonItem(short templateId, string name, EMapBlockCharCustomButtonLogicType logicType, EMapBlockCharCustomButtonDisplayGroup displayGroup, List<short> interactionEventOption)
	{
		TemplateId = templateId;
		Name = name;
		LogicType = logicType;
		DisplayGroup = displayGroup;
		InteractionEventOption = interactionEventOption;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public MapBlockCharCustomButtonItem()
	{
		TemplateId = 0;
		Name = null;
		LogicType = EMapBlockCharCustomButtonLogicType.Invalid;
		DisplayGroup = EMapBlockCharCustomButtonDisplayGroup.TopLevel;
		InteractionEventOption = new List<short>();
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
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

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override MapBlockCharCustomButtonItem Duplicate(int templateId)
	{
		return new MapBlockCharCustomButtonItem((short)templateId, this);
	}
}
