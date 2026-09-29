using System;
using Config.Common;

namespace Config;

[Serializable]
public class EncyclopediaTipLinkItem : ConfigItem<EncyclopediaTipLinkItem, int>
{
	public readonly int TemplateId;

	public readonly EEncyclopediaTipLinkMode Mode;

	public readonly string RefName;

	public readonly EEncyclopediaTipLinkType Type;

	public EncyclopediaTipLinkItem(int templateId, EEncyclopediaTipLinkMode mode, string refName, EEncyclopediaTipLinkType type)
	{
		TemplateId = templateId;
		Mode = mode;
		RefName = refName;
		Type = type;
	}

	public EncyclopediaTipLinkItem()
	{
		TemplateId = 0;
		Mode = EEncyclopediaTipLinkMode.Default;
		RefName = null;
		Type = EEncyclopediaTipLinkType.TipLegacy;
	}

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

	public override EncyclopediaTipLinkItem Duplicate(int templateId)
	{
		return new EncyclopediaTipLinkItem(templateId, this);
	}
}
