using System;
using Config.Common;

namespace Config;

[Serializable]
public class EncyclopediaTipLinkItem : ConfigItem<EncyclopediaTipLinkItem, int>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly int TemplateId;

	/// <summary>
	/// 跳转模式
	/// </summary>
	public readonly EEncyclopediaTipLinkMode Mode;

	/// <summary>
	/// EncyclopediaReference引用名
	/// - EncyclopediaReference.tsv最左边那列，是纯string
	/// </summary>
	public readonly string RefName;

	/// <summary>
	/// 类型枚举
	/// </summary>
	public readonly EEncyclopediaTipLinkType Type;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="mode">跳转模式</param>
	/// <param name="refName">EncyclopediaReference引用名 - EncyclopediaReference.tsv最左边那列，是纯string</param>
	/// <param name="type">类型枚举</param>
	public EncyclopediaTipLinkItem(int templateId, EEncyclopediaTipLinkMode mode, string refName, EEncyclopediaTipLinkType type)
	{
		TemplateId = templateId;
		Mode = mode;
		RefName = refName;
		Type = type;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public EncyclopediaTipLinkItem()
	{
		TemplateId = 0;
		Mode = EEncyclopediaTipLinkMode.Default;
		RefName = null;
		Type = EEncyclopediaTipLinkType.TipLegacy;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public EncyclopediaTipLinkItem(int templateId, EncyclopediaTipLinkItem other)
	{
		TemplateId = templateId;
		Mode = other.Mode;
		RefName = other.RefName;
		Type = other.Type;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override EncyclopediaTipLinkItem Duplicate(int templateId)
	{
		return new EncyclopediaTipLinkItem(templateId, this);
	}
}
