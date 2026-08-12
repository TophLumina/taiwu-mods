using System;
using Config.Common;

namespace Config;

[Serializable]
public class NewFunctionUnlockItem : ConfigItem<NewFunctionUnlockItem, byte>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly byte TemplateId;

	/// <summary>
	/// 显示排序
	/// - 数字越大的越靠前
	/// </summary>
	public readonly sbyte IncrementSortOrder;

	/// <summary>
	/// 标题
	/// </summary>
	public readonly string Title;

	/// <summary>
	/// 分类
	/// </summary>
	public readonly ENewFunctionUnlockType Type;

	/// <summary>
	/// 描述
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 图标
	/// </summary>
	public readonly string Icon;

	/// <summary>
	/// 对应界面
	/// </summary>
	public readonly string UIPage;

	/// <summary>
	/// 百晓册一级页签
	/// </summary>
	public readonly string EncyclopediaTabFirst;

	/// <summary>
	/// 百晓册二级页签
	/// </summary>
	public readonly string EncyclopediaTabSecond;

	/// <summary>
	/// 百晓册三级页签
	/// </summary>
	public readonly string EncyclopediaTabThird;

	/// <summary>
	/// 百晓册四级页签
	/// </summary>
	public readonly string EncyclopediaTabFourth;

	/// <summary>
	/// 百晓册术语Id
	/// </summary>
	public readonly int EncyclopediaTabId;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="incrementSortOrder">显示排序 - 数字越大的越靠前</param>
	/// <param name="title">标题</param>
	/// <param name="type">分类</param>
	/// <param name="desc">描述</param>
	/// <param name="icon">图标</param>
	/// <param name="uIPage">对应界面</param>
	/// <param name="encyclopediaTabFirst">百晓册一级页签</param>
	/// <param name="encyclopediaTabSecond">百晓册二级页签</param>
	/// <param name="encyclopediaTabThird">百晓册三级页签</param>
	/// <param name="encyclopediaTabFourth">百晓册四级页签</param>
	/// <param name="encyclopediaTabId">百晓册术语Id</param>
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

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
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

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
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

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override NewFunctionUnlockItem Duplicate(int templateId)
	{
		return new NewFunctionUnlockItem((byte)templateId, this);
	}
}
