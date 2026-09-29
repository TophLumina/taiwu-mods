using System;
using System.Diagnostics.CodeAnalysis;
using Config.Common;

namespace Config;

[Serializable]
public class NewFunctionUnlockItem : ConfigItem<NewFunctionUnlockItem, byte>
{
	public readonly byte TemplateId;

	public readonly sbyte IncrementSortOrder;

	public readonly string Title;

	public readonly ENewFunctionUnlockType Type;

	public readonly string Desc;

	public readonly string Icon;

	public readonly string UIPage;

	public readonly string EncyclopediaTabFirst;

	public readonly string EncyclopediaTabSecond;

	public readonly string EncyclopediaTabThird;

	public readonly string EncyclopediaTabFourth;

	public readonly int EncyclopediaTabId;

	public EncyclopediaTipLinkItem EncyclopediaTab
	{
		[return: MaybeNull]
		get
		{
			return EncyclopediaTipLink.Instance.GetItemOrDefault(EncyclopediaTabId);
		}
	}

	public NewFunctionUnlockItem(byte templateId, sbyte incrementSortOrder, string title, ENewFunctionUnlockType type, string desc, string icon, string uIPage, string encyclopediaTabFirst, string encyclopediaTabSecond, string encyclopediaTabThird, string encyclopediaTabFourth, int encyclopediaTabId)
	{
		TemplateId = templateId;
		IncrementSortOrder = incrementSortOrder;
		Title = title;
		Type = type;
		Desc = desc;
		Icon = icon;
		UIPage = uIPage;
		EncyclopediaTabFirst = encyclopediaTabFirst;
		EncyclopediaTabSecond = encyclopediaTabSecond;
		EncyclopediaTabThird = encyclopediaTabThird;
		EncyclopediaTabFourth = encyclopediaTabFourth;
		EncyclopediaTabId = encyclopediaTabId;
	}

	public NewFunctionUnlockItem()
	{
		TemplateId = 0;
		IncrementSortOrder = 0;
		Title = null;
		Type = ENewFunctionUnlockType.Personal;
		Desc = null;
		Icon = null;
		UIPage = null;
		EncyclopediaTabFirst = null;
		EncyclopediaTabSecond = null;
		EncyclopediaTabThird = null;
		EncyclopediaTabFourth = null;
		EncyclopediaTabId = 0;
	}

	public NewFunctionUnlockItem(byte templateId, NewFunctionUnlockItem other)
	{
		TemplateId = templateId;
		IncrementSortOrder = other.IncrementSortOrder;
		Title = other.Title;
		Type = other.Type;
		Desc = other.Desc;
		Icon = other.Icon;
		UIPage = other.UIPage;
		EncyclopediaTabFirst = other.EncyclopediaTabFirst;
		EncyclopediaTabSecond = other.EncyclopediaTabSecond;
		EncyclopediaTabThird = other.EncyclopediaTabThird;
		EncyclopediaTabFourth = other.EncyclopediaTabFourth;
		EncyclopediaTabId = other.EncyclopediaTabId;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override NewFunctionUnlockItem Duplicate(int templateId)
	{
		return new NewFunctionUnlockItem((byte)templateId, this);
	}
}
