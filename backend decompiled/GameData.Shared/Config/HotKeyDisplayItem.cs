using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class HotKeyDisplayItem : ConfigItem<HotKeyDisplayItem, short>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 类型枚举
	/// </summary>
	public readonly EHotKeyDisplayType Type;

	/// <summary>
	/// 显示文本
	/// - ui上显示的提示，参数是对应的快捷指令
	/// </summary>
	public readonly string DisplayText;

	/// <summary>
	/// 参数列表
	/// - 每个参数对应的命令id；第一个是分组，详见CommandKitBase；第二个是具体ID，比如TipsCommandKit.LockItem
	/// </summary>
	public readonly List<HotkeyIndex> Params;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="type">类型枚举</param>
	/// <param name="displayText">显示文本 - ui上显示的提示，参数是对应的快捷指令</param>
	/// <param name="hotkeyIndexParams">参数列表 - 每个参数对应的命令id；第一个是分组，详见CommandKitBase；第二个是具体ID，比如TipsCommandKit.LockItem</param>
	public HotKeyDisplayItem(short templateId, EHotKeyDisplayType type, string displayText, List<HotkeyIndex> hotkeyIndexParams)
	{
		TemplateId = templateId;
		Type = type;
		DisplayText = displayText;
		Params = hotkeyIndexParams;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public HotKeyDisplayItem()
	{
		TemplateId = 0;
		Type = EHotKeyDisplayType.GetItem;
		DisplayText = null;
		Params = new List<HotkeyIndex>();
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
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

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override HotKeyDisplayItem Duplicate(int templateId)
	{
		return new HotKeyDisplayItem((short)templateId, this);
	}
}
