using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class HotKeyDisplayItem : ConfigItem<HotKeyDisplayItem, short>
{
	public readonly short TemplateId;

	public readonly EHotKeyDisplayType Type;

	public readonly string DisplayText;

	public readonly List<HotkeyIndex> Params;

	public HotKeyDisplayItem(short templateId, EHotKeyDisplayType type, string displayText, List<HotkeyIndex> hotkeyIndexParams)
	{
		TemplateId = templateId;
		Type = type;
		DisplayText = displayText;
		Params = hotkeyIndexParams;
	}

	public HotKeyDisplayItem()
	{
		TemplateId = 0;
		Type = EHotKeyDisplayType.GetItem;
		DisplayText = null;
		Params = new List<HotkeyIndex>();
	}

	public HotKeyDisplayItem(short templateId, HotKeyDisplayItem other)
	{
		TemplateId = templateId;
		Type = other.Type;
		DisplayText = other.DisplayText;
		Params = other.Params;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override HotKeyDisplayItem Duplicate(int templateId)
	{
		return new HotKeyDisplayItem((short)templateId, this);
	}
}
