using System;
using Config.Common;

namespace Config;

[Serializable]
public class ImplementedDlcItem : ConfigItem<ImplementedDlcItem, byte>
{
	public readonly byte TemplateId;

	public readonly uint AppId;

	public readonly string Name;

	public readonly string DisplayName;

	public readonly string[] Desc;

	public readonly string ScrollIcon;

	public readonly string MainImageHorizontal;

	public readonly string MainImageVertical;

	public readonly string[] Screenshots;

	public readonly bool OnlyDisplay;

	public readonly int Order;

	public readonly EImplementedDlcType Type;

	public readonly bool IsFree;

	public readonly bool IsImplemented;

	public ImplementedDlcItem(byte templateId, uint appId, string name, string displayName, string[] desc, string scrollIcon, string mainImageHorizontal, string mainImageVertical, string[] screenshots, bool onlyDisplay, int order, EImplementedDlcType type, bool isFree, bool isImplemented)
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
		IsImplemented = isImplemented;
	}

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
		IsImplemented = true;
	}

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
		IsImplemented = other.IsImplemented;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override ImplementedDlcItem Duplicate(int templateId)
	{
		return new ImplementedDlcItem((byte)templateId, this);
	}
}
