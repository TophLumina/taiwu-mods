using System;
using System.Collections.Generic;
using Config.Common;
using Config.ConfigCells;

namespace Config;

[Serializable]
public class CombatStateItem : ConfigItem<CombatStateItem, short>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 属性变化列表
	/// - 每个数据第3项为数据修改类型，对应代码中DataModifyType。仅支持：0-A类、1-B类
	/// </summary>
	public readonly List<CombatStateProperty> PropertyList;

	/// <summary>
	/// 翻转状态
	/// </summary>
	public readonly short ReverseState;

	/// <summary>
	/// 特殊提示文字
	/// - 仅用于无属性变化的状态
	/// </summary>
	public readonly string TipsDesc;

	/// <summary>
	/// 描述
	/// - 用于战斗之外的界面
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="name">名称</param>
	/// <param name="propertyList">属性变化列表 - 每个数据第3项为数据修改类型，对应代码中DataModifyType。仅支持：0-A类、1-B类</param>
	/// <param name="reverseState">翻转状态</param>
	/// <param name="tipsDesc">特殊提示文字 - 仅用于无属性变化的状态</param>
	/// <param name="desc">描述 - 用于战斗之外的界面</param>
	public CombatStateItem(short templateId, string name, List<CombatStateProperty> propertyList, short reverseState, string tipsDesc, string desc)
	{
		TemplateId = templateId;
		Name = name;
		PropertyList = propertyList;
		ReverseState = reverseState;
		TipsDesc = tipsDesc;
		Desc = desc;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public CombatStateItem()
	{
		TemplateId = 0;
		Name = null;
		PropertyList = new List<CombatStateProperty>();
		ReverseState = 0;
		TipsDesc = null;
		Desc = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public CombatStateItem(short templateId, CombatStateItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		PropertyList = other.PropertyList;
		ReverseState = other.ReverseState;
		TipsDesc = other.TipsDesc;
		Desc = other.Desc;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override CombatStateItem Duplicate(int templateId)
	{
		return new CombatStateItem((short)templateId, this);
	}
}
