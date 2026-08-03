using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class EventActionKey : ConfigData<EventActionKeyItem, int>, IEventArgumentCollectionFormatter
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 进入产业视图
		/// </summary>
		public const int EnterBuildingArea = 0;

		/// <summary>
		/// 演武放下建筑
		/// </summary>
		public const int TutorialPlaceBuilding = 4;

		/// <summary>
		/// 演武打开制造
		/// </summary>
		public const int TutorialOpenViewMake = 10;

		/// <summary>
		/// 演武关闭突破
		/// </summary>
		public const int TutorialExitSkillBreak = 1;

		/// <summary>
		/// 演武打开突破
		/// </summary>
		public const int TutorialEnterSkillBreak = 9;

		/// <summary>
		/// 演武关闭研读
		/// </summary>
		public const int TutorialExitViewReading = 2;

		/// <summary>
		/// 演武打开灵光一闪
		/// </summary>
		public const int TutorialEnterReadingEvent = 11;

		/// <summary>
		/// 演武关闭周天
		/// </summary>
		public const int TutorialExitViewLooping = 3;

		/// <summary>
		/// 演武结束采集
		/// </summary>
		public const int TutorialFinishCollectResource = 5;

		/// <summary>
		/// 演武关闭志向
		/// </summary>
		public const int TutorialExitProfession = 12;

		/// <summary>
		/// 播放CG结束
		/// </summary>
		public const int PerformCutsceneComplete = 6;

		/// <summary>
		/// 黑屏遮罩显示完成
		/// </summary>
		public const int OnBlackMaskShowComplete = 7;

		/// <summary>
		/// 黑屏遮罩隐藏完成
		/// </summary>
		public const int OnBlackMaskHideComplete = 8;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 进入产业视图
		/// </summary>
		public static EventActionKeyItem EnterBuildingArea => Instance[0];

		/// <summary>
		/// 演武放下建筑
		/// </summary>
		public static EventActionKeyItem TutorialPlaceBuilding => Instance[4];

		/// <summary>
		/// 演武打开制造
		/// </summary>
		public static EventActionKeyItem TutorialOpenViewMake => Instance[10];

		/// <summary>
		/// 演武关闭突破
		/// </summary>
		public static EventActionKeyItem TutorialExitSkillBreak => Instance[1];

		/// <summary>
		/// 演武打开突破
		/// </summary>
		public static EventActionKeyItem TutorialEnterSkillBreak => Instance[9];

		/// <summary>
		/// 演武关闭研读
		/// </summary>
		public static EventActionKeyItem TutorialExitViewReading => Instance[2];

		/// <summary>
		/// 演武打开灵光一闪
		/// </summary>
		public static EventActionKeyItem TutorialEnterReadingEvent => Instance[11];

		/// <summary>
		/// 演武关闭周天
		/// </summary>
		public static EventActionKeyItem TutorialExitViewLooping => Instance[3];

		/// <summary>
		/// 演武结束采集
		/// </summary>
		public static EventActionKeyItem TutorialFinishCollectResource => Instance[5];

		/// <summary>
		/// 演武关闭志向
		/// </summary>
		public static EventActionKeyItem TutorialExitProfession => Instance[12];

		/// <summary>
		/// 播放CG结束
		/// </summary>
		public static EventActionKeyItem PerformCutsceneComplete => Instance[6];

		/// <summary>
		/// 黑屏遮罩显示完成
		/// </summary>
		public static EventActionKeyItem OnBlackMaskShowComplete => Instance[7];

		/// <summary>
		/// 黑屏遮罩隐藏完成
		/// </summary>
		public static EventActionKeyItem OnBlackMaskHideComplete => Instance[8];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static EventActionKey Instance = new EventActionKey();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Parameters", "TemplateId", "KeyCode" };

	internal override int ToInt(int value)
	{
		return value;
	}

	internal override int ToTemplateId(int value)
	{
		return value;
	}

	private void CreateItems0()
	{
		_dataArray.Add(new EventActionKeyItem(0, "EnterBuildingArea", null, blockTrigger: false, registerByEventFunction: true));
		_dataArray.Add(new EventActionKeyItem(1, "TutorialExitSkillBreak", null, blockTrigger: false, registerByEventFunction: true));
		_dataArray.Add(new EventActionKeyItem(2, "TutorialExitViewReading", null, blockTrigger: false, registerByEventFunction: true));
		_dataArray.Add(new EventActionKeyItem(3, "TutorialExitViewLooping", null, blockTrigger: false, registerByEventFunction: true));
		_dataArray.Add(new EventActionKeyItem(4, "TutorialPlaceBuilding", null, blockTrigger: false, registerByEventFunction: true));
		_dataArray.Add(new EventActionKeyItem(5, "TutorialFinishCollectResource", null, blockTrigger: false, registerByEventFunction: true));
		_dataArray.Add(new EventActionKeyItem(6, "PerformCutsceneComplete", null, blockTrigger: true, registerByEventFunction: false));
		_dataArray.Add(new EventActionKeyItem(7, "OnBlackMaskShowComplete", null, blockTrigger: true, registerByEventFunction: false));
		_dataArray.Add(new EventActionKeyItem(8, "OnBlackMaskHideComplete", null, blockTrigger: true, registerByEventFunction: false));
		_dataArray.Add(new EventActionKeyItem(9, "TutorialEnterSkillBreak", null, blockTrigger: false, registerByEventFunction: true));
		_dataArray.Add(new EventActionKeyItem(10, "TutorialOpenViewMake", null, blockTrigger: false, registerByEventFunction: true));
		_dataArray.Add(new EventActionKeyItem(11, "TutorialEnterReadingEvent", null, blockTrigger: false, registerByEventFunction: true));
		_dataArray.Add(new EventActionKeyItem(12, "TutorialExitProfession", null, blockTrigger: false, registerByEventFunction: true));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<EventActionKeyItem>(13);
		CreateItems0();
	}

	public int ToTemplateId(string str)
	{
		foreach (EventActionKeyItem item in (IEnumerable<EventActionKeyItem>)this)
		{
			if (item.KeyCode == str)
			{
				return item.TemplateId;
			}
		}
		return -1;
	}

	public string ToArgString(int templateId)
	{
		return GetItem(templateId)?.KeyCode;
	}
}
