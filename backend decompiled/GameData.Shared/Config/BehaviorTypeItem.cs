using System;
using Config.Common;

namespace Config;

[Serializable]
public class BehaviorTypeItem : ConfigItem<BehaviorTypeItem, sbyte>
{
	public readonly sbyte TemplateId;

	public readonly string Name;

	public readonly string Desc;

	public readonly sbyte ExchangeBook;

	public readonly string Icon;

	public readonly string[] BetrayTips;

	public BehaviorTypeItem(sbyte templateId, string name, string desc, sbyte exchangeBook, string icon, string[] betrayTips)
	{
		TemplateId = templateId;
		Name = name;
		Desc = desc;
		ExchangeBook = exchangeBook;
		Icon = icon;
		BetrayTips = betrayTips;
	}

	public BehaviorTypeItem()
	{
		TemplateId = 0;
		Name = null;
		Desc = null;
		ExchangeBook = 0;
		Icon = null;
		BetrayTips = null;
	}

	public BehaviorTypeItem(sbyte templateId, BehaviorTypeItem other)
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

	public override BehaviorTypeItem Duplicate(int templateId)
	{
		return new BehaviorTypeItem((sbyte)templateId, this);
	}
}
