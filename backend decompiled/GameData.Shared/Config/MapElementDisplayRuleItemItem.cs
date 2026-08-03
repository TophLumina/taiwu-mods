using System;
using Config.Common;

namespace Config;

[Serializable]
public class MapElementDisplayRuleItemItem : ConfigItem<MapElementDisplayRuleItemItem, short>
{
	/// <summary>
	/// 模板id
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 分组
	/// </summary>
	public readonly short Group;

	/// <summary>
	/// 名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 文本颜色
	/// </summary>
	public readonly string Color;

	/// <summary>
	/// 显示顺序
	/// - 越小，越底部
	/// </summary>
	public readonly int Order;

	/// <summary>
	/// 商会类型
	/// </summary>
	public readonly sbyte MerchantType;

	/// <summary>
	/// 图例设置图标
	/// - 在图例界面
	/// </summary>
	public readonly string Icon;

	/// <summary>
	/// 地块信息图标
	/// - 在地块上
	/// </summary>
	public readonly string BlockInfoIcon;

	/// <summary>
	/// 显示位置
	/// </summary>
	public readonly EMapElementDisplayRuleItemPoisionType PoisionType;

	/// <summary>
	/// 人物数量分组
	/// </summary>
	public readonly EMapElementDisplayRuleItemCharacterCountGroup CharacterCountGroup;

	/// <summary>
	/// 人物数量分组
	/// - 地图图例界面的
	/// </summary>
	public readonly EMapElementDisplayRuleItemCharacterCountGroupDisplay CharacterCountGroupDisplay;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板id</param>
	/// <param name="group">分组</param>
	/// <param name="name">名称</param>
	/// <param name="color">文本颜色</param>
	/// <param name="order">显示顺序 - 越小，越底部</param>
	/// <param name="merchantType">商会类型</param>
	/// <param name="icon">图例设置图标 - 在图例界面</param>
	/// <param name="blockInfoIcon">地块信息图标 - 在地块上</param>
	/// <param name="poisionType">显示位置</param>
	/// <param name="characterCountGroup">人物数量分组</param>
	/// <param name="characterCountGroupDisplay">人物数量分组 - 地图图例界面的</param>
	public MapElementDisplayRuleItemItem(short templateId, short group, string name, string color, int order, sbyte merchantType, string icon, string blockInfoIcon, EMapElementDisplayRuleItemPoisionType poisionType, EMapElementDisplayRuleItemCharacterCountGroup characterCountGroup, EMapElementDisplayRuleItemCharacterCountGroupDisplay characterCountGroupDisplay)
	{
		TemplateId = templateId;
		Group = group;
		Name = name;
		Color = color;
		Order = order;
		MerchantType = merchantType;
		Icon = icon;
		BlockInfoIcon = blockInfoIcon;
		PoisionType = poisionType;
		CharacterCountGroup = characterCountGroup;
		CharacterCountGroupDisplay = characterCountGroupDisplay;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public MapElementDisplayRuleItemItem()
	{
		TemplateId = 0;
		Group = 0;
		Name = null;
		Color = "pinkyellow";
		Order = 0;
		MerchantType = 0;
		Icon = null;
		BlockInfoIcon = null;
		PoisionType = EMapElementDisplayRuleItemPoisionType.Right;
		CharacterCountGroup = EMapElementDisplayRuleItemCharacterCountGroup.Invalid;
		CharacterCountGroupDisplay = EMapElementDisplayRuleItemCharacterCountGroupDisplay.Invalid;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public MapElementDisplayRuleItemItem(short templateId, MapElementDisplayRuleItemItem other)
	{
		TemplateId = templateId;
		Group = other.Group;
		Name = other.Name;
		Color = other.Color;
		Order = other.Order;
		MerchantType = other.MerchantType;
		Icon = other.Icon;
		BlockInfoIcon = other.BlockInfoIcon;
		PoisionType = other.PoisionType;
		CharacterCountGroup = other.CharacterCountGroup;
		CharacterCountGroupDisplay = other.CharacterCountGroupDisplay;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override MapElementDisplayRuleItemItem Duplicate(int templateId)
	{
		return new MapElementDisplayRuleItemItem((short)templateId, this);
	}
}
