using System;
using Config.Common;

namespace Config;

[Serializable]
public class EventCutsceneItem : ConfigItem<EventCutsceneItem, short>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 资源名称格式(将会填入语言选项)
	/// - CG动画资源命名遵照下列格式：配置表中没有包含多语言后缀，会自动补齐，中文资源后缀_CN；英文资源后缀_EN；如MainStory_01实际加载的是MainStory_01_CN. 主线CG动画以MainStory作为前缀，按剧情次序或CG动画的制作顺序依次排序；地区主线CG动画以SectStory为前缀，依照Organization配置表中的门派顺序以及资源顺序进行排序，例如SectStory_01_01_CN，即为地区主线-少林派-第一个CG动画-中文资源的命名
	/// </summary>
	public readonly string ResourceFormat;

	/// <summary>
	/// 是否可以跳过
	/// </summary>
	public readonly bool CanSkip;

	/// <summary>
	/// 指令条的偏移
	/// - 此列参数为CG播放时，界面中“点击鼠标左键跳过动画”的提示的坐标
	/// </summary>
	public readonly int[] CommandPanelOffset;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="resourceFormat">资源名称格式(将会填入语言选项) - CG动画资源命名遵照下列格式：配置表中没有包含多语言后缀，会自动补齐，中文资源后缀_CN；英文资源后缀_EN；如MainStory_01实际加载的是MainStory_01_CN. 主线CG动画以MainStory作为前缀，按剧情次序或CG动画的制作顺序依次排序；地区主线CG动画以SectStory为前缀，依照Organization配置表中的门派顺序以及资源顺序进行排序，例如SectStory_01_01_CN，即为地区主线-少林派-第一个CG动画-中文资源的命名</param>
	/// <param name="canSkip">是否可以跳过</param>
	/// <param name="commandPanelOffset">指令条的偏移 - 此列参数为CG播放时，界面中“点击鼠标左键跳过动画”的提示的坐标</param>
	public EventCutsceneItem(short templateId, string resourceFormat, bool canSkip, int[] commandPanelOffset)
	{
		TemplateId = templateId;
		ResourceFormat = resourceFormat;
		CanSkip = canSkip;
		CommandPanelOffset = commandPanelOffset;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public EventCutsceneItem()
	{
		TemplateId = 0;
		ResourceFormat = null;
		CanSkip = true;
		CommandPanelOffset = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public EventCutsceneItem(short templateId, EventCutsceneItem other)
	{
		TemplateId = templateId;
		ResourceFormat = other.ResourceFormat;
		CanSkip = other.CanSkip;
		CommandPanelOffset = other.CommandPanelOffset;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override EventCutsceneItem Duplicate(int templateId)
	{
		return new EventCutsceneItem((short)templateId, this);
	}
}
