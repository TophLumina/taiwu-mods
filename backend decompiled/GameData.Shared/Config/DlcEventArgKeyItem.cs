using System;
using Config.Common;

namespace Config;

[Serializable]
public class DlcEventArgKeyItem : ConfigItem<DlcEventArgKeyItem, int>, IEventArgumentFormatter
{
	public readonly int TemplateId;

	public readonly byte Dlc;

	public readonly string ArgBoxKey;

	public DlcEventArgKeyItem(int templateId, byte dlc, string argBoxKey)
	{
		TemplateId = templateId;
		Dlc = dlc;
		ArgBoxKey = argBoxKey;
	}

	public DlcEventArgKeyItem()
	{
		TemplateId = 0;
		Dlc = 0;
		ArgBoxKey = null;
	}

	public DlcEventArgKeyItem(int templateId, DlcEventArgKeyItem other)
	{
		TemplateId = templateId;
		Dlc = other.Dlc;
		ArgBoxKey = other.ArgBoxKey;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override DlcEventArgKeyItem Duplicate(int templateId)
	{
		return new DlcEventArgKeyItem(templateId, this);
	}

	public static implicit operator string(DlcEventArgKeyItem item)
	{
		return item.ArgBoxKey;
	}

	string IEventArgumentFormatter.ToArgString()
	{
		return ArgBoxKey;
	}
}
