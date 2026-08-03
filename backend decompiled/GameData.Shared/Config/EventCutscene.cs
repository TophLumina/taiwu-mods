using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class EventCutscene : ConfigData<EventCutsceneItem, short>
{
	/// <summary>
	/// 配置表实例
	/// </summary>
	public static EventCutscene Instance = new EventCutscene();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "TemplateId", "ResourceFormat", "CommandPanelOffset" };

	internal override int ToInt(short value)
	{
		return value;
	}

	internal override short ToTemplateId(int value)
	{
		return (short)value;
	}

	private void CreateItems0()
	{
		_dataArray.Add(new EventCutsceneItem(0, "MainStory_01", canSkip: true, new int[2] { 0, -48 }));
		_dataArray.Add(new EventCutsceneItem(1, "MainStory_02", canSkip: true, new int[2] { 0, -48 }));
		_dataArray.Add(new EventCutsceneItem(2, "MainStory_03", canSkip: true, new int[2] { 0, -48 }));
		_dataArray.Add(new EventCutsceneItem(3, "MainStory_04", canSkip: true, new int[2] { 0, -48 }));
		_dataArray.Add(new EventCutsceneItem(4, "MainStory_05", canSkip: true, new int[2] { 0, -48 }));
		_dataArray.Add(new EventCutsceneItem(5, "MainStory_06", canSkip: true, new int[2] { 0, -48 }));
		_dataArray.Add(new EventCutsceneItem(6, "MainStory_07", canSkip: true, new int[2] { 0, -48 }));
		_dataArray.Add(new EventCutsceneItem(7, "MainStory_08", canSkip: true, new int[2] { 0, -48 }));
		_dataArray.Add(new EventCutsceneItem(8, "MainStory_10", canSkip: true, new int[2] { 0, -48 }));
		_dataArray.Add(new EventCutsceneItem(9, "MainStory_11", canSkip: true, new int[2] { 0, -48 }));
		_dataArray.Add(new EventCutsceneItem(10, "MainStory_12", canSkip: true, new int[2] { 0, -48 }));
		_dataArray.Add(new EventCutsceneItem(11, "MainStory_09", canSkip: true, new int[2] { 0, -48 }));
		_dataArray.Add(new EventCutsceneItem(12, "SectStory_04_01", canSkip: true, new int[2] { 0, -48 }));
		_dataArray.Add(new EventCutsceneItem(13, "SectStory_05_01", canSkip: true, new int[2] { 0, -48 }));
		_dataArray.Add(new EventCutsceneItem(14, "SectStory_05_02", canSkip: true, new int[2] { 0, -48 }));
		_dataArray.Add(new EventCutsceneItem(15, "SectStory_07_01", canSkip: true, new int[2] { 0, -48 }));
		_dataArray.Add(new EventCutsceneItem(16, "SectStory_12_01", canSkip: true, new int[2] { 0, -48 }));
		_dataArray.Add(new EventCutsceneItem(17, "SectStory_15_01", canSkip: true, new int[2] { 0, -48 }));
		_dataArray.Add(new EventCutsceneItem(18, "MainStory_13", canSkip: true, new int[2] { 0, -48 }));
		_dataArray.Add(new EventCutsceneItem(19, "MainStory_14", canSkip: false, new int[2] { 0, -48 }));
		_dataArray.Add(new EventCutsceneItem(20, "MainStory_15", canSkip: false, new int[2] { 0, -48 }));
		_dataArray.Add(new EventCutsceneItem(21, "MainStory_16", canSkip: false, new int[2] { 0, -48 }));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<EventCutsceneItem>(22);
		CreateItems0();
	}
}
