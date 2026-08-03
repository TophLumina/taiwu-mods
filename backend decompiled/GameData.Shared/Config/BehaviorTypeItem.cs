using System;
using Config.Common;

namespace Config;

[Serializable]
public class BehaviorTypeItem : ConfigItem<BehaviorTypeItem, short>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly short TemplateId;

	public readonly string Name;

	public readonly string Desc;

	/// <summary>
	/// 交换藏书
	/// - 私传功法的时候所需的好感度等级
	/// </summary>
	public readonly sbyte ExchangeBook;

	public readonly string Icon;

	/// <summary>
	/// 倒戈提示文字
	/// </summary>
	public readonly string[] BetrayTips;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="name"></param>
	/// <param name="desc"></param>
	/// <param name="exchangeBook">交换藏书 - 私传功法的时候所需的好感度等级</param>
	/// <param name="icon"></param>
	/// <param name="betrayTips">倒戈提示文字</param>
	public BehaviorTypeItem(short templateId, string name, string desc, sbyte exchangeBook, string icon, string[] betrayTips)
	{
		TemplateId = templateId;
		Name = name;
		Desc = desc;
		ExchangeBook = exchangeBook;
		Icon = icon;
		BetrayTips = betrayTips;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public BehaviorTypeItem()
	{
		TemplateId = 0;
		Name = null;
		Desc = null;
		ExchangeBook = 0;
		Icon = null;
		BetrayTips = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public BehaviorTypeItem(short templateId, BehaviorTypeItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Desc = other.Desc;
		ExchangeBook = other.ExchangeBook;
		Icon = other.Icon;
		BetrayTips = other.BetrayTips;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override BehaviorTypeItem Duplicate(int templateId)
	{
		return new BehaviorTypeItem((short)templateId, this);
	}
}
