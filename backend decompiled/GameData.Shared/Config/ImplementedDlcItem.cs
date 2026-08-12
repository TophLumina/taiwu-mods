using System;
using Config.Common;

namespace Config;

[Serializable]
public class ImplementedDlcItem : ConfigItem<ImplementedDlcItem, byte>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly byte TemplateId;

	/// <summary>
	/// AppId
	/// </summary>
	public readonly uint AppId;

	/// <summary>
	/// 英文标识符
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 中文名
	/// </summary>
	public readonly string DisplayName;

	/// <summary>
	/// 介绍
	/// - 奇数是标题，偶数是正文
	/// </summary>
	public readonly string[] Desc;

	/// <summary>
	/// 列表图片
	/// </summary>
	public readonly string ScrollIcon;

	/// <summary>
	/// 横向海报
	/// </summary>
	public readonly string MainImageHorizontal;

	/// <summary>
	/// 纵向海报
	/// </summary>
	public readonly string MainImageVertical;

	/// <summary>
	/// 内容图片
	/// </summary>
	public readonly string[] Screenshots;

	/// <summary>
	/// 仅展示
	/// - OST等与本体无关的DLC
	/// </summary>
	public readonly bool OnlyDisplay;

	/// <summary>
	/// 排序
	/// </summary>
	public readonly int Order;

	/// <summary>
	/// 类型
	/// </summary>
	public readonly EImplementedDlcType Type;

	/// <summary>
	/// 是否免费
	/// </summary>
	public readonly bool IsFree;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="appId">AppId</param>
	/// <param name="name">英文标识符</param>
	/// <param name="displayName">中文名</param>
	/// <param name="desc">介绍 - 奇数是标题，偶数是正文</param>
	/// <param name="scrollIcon">列表图片</param>
	/// <param name="mainImageHorizontal">横向海报</param>
	/// <param name="mainImageVertical">纵向海报</param>
	/// <param name="screenshots">内容图片</param>
	/// <param name="onlyDisplay">仅展示 - OST等与本体无关的DLC</param>
	/// <param name="order">排序</param>
	/// <param name="type">类型</param>
	/// <param name="isFree">是否免费</param>
	public ImplementedDlcItem(byte templateId, uint appId, string name, string displayName, string[] desc, string scrollIcon, string mainImageHorizontal, string mainImageVertical, string[] screenshots, bool onlyDisplay, int order, EImplementedDlcType type, bool isFree)
	{
		TemplateId = templateId;
		AppId = appId;
		Name = name;
		DisplayName = displayName;
		Desc = desc;
		ScrollIcon = scrollIcon;
		MainImageHorizontal = mainImageHorizontal;
		MainImageVertical = mainImageVertical;
		Screenshots = screenshots;
		OnlyDisplay = onlyDisplay;
		Order = order;
		Type = type;
		IsFree = isFree;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public ImplementedDlcItem()
	{
		TemplateId = 0;
		AppId = 0u;
		Name = null;
		DisplayName = null;
		Desc = null;
		ScrollIcon = null;
		MainImageHorizontal = null;
		MainImageVertical = null;
		Screenshots = null;
		OnlyDisplay = false;
		Order = -1;
		Type = EImplementedDlcType.Appearance;
		IsFree = false;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public ImplementedDlcItem(byte templateId, ImplementedDlcItem other)
	{
		TemplateId = templateId;
		AppId = other.AppId;
		Name = other.Name;
		DisplayName = other.DisplayName;
		Desc = other.Desc;
		ScrollIcon = other.ScrollIcon;
		MainImageHorizontal = other.MainImageHorizontal;
		MainImageVertical = other.MainImageVertical;
		Screenshots = other.Screenshots;
		OnlyDisplay = other.OnlyDisplay;
		Order = other.Order;
		Type = other.Type;
		IsFree = other.IsFree;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override ImplementedDlcItem Duplicate(int templateId)
	{
		return new ImplementedDlcItem((byte)templateId, this);
	}
}
