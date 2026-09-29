using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class EventActionKey : ConfigData<EventActionKeyItem, int>, IEventArgumentCollectionFormatter
{
	public static class DefKey
	{
		public const int EnterBuildingArea = 0;

		public const int TutorialPlaceBuilding = 4;

		public const int TutorialOpenViewMake = 10;

		public const int TutorialExitSkillBreak = 1;

		public const int TutorialEnterSkillBreak = 9;

		public const int TutorialExitViewReading = 2;

		public const int TutorialEnterReadingEvent = 11;

		public const int TutorialExitViewLooping = 3;

		public const int TutorialFinishCollectResource = 5;

		public const int TutorialExitProfession = 12;

		public const int PerformCutsceneComplete = 6;

		public const int OnBlackMaskShowComplete = 7;

		public const int OnBlackMaskHideComplete = 8;
	}

	public static class DefValue
	{
		public static EventActionKeyItem EnterBuildingArea => Instance[0];

		public static EventActionKeyItem TutorialPlaceBuilding => Instance[4];

		public static EventActionKeyItem TutorialOpenViewMake => Instance[10];

		public static EventActionKeyItem TutorialExitSkillBreak => Instance[1];

		public static EventActionKeyItem TutorialEnterSkillBreak => Instance[9];

		public static EventActionKeyItem TutorialExitViewReading => Instance[2];

		public static EventActionKeyItem TutorialEnterReadingEvent => Instance[11];

		public static EventActionKeyItem TutorialExitViewLooping => Instance[3];

		public static EventActionKeyItem TutorialFinishCollectResource => Instance[5];

		public static EventActionKeyItem TutorialExitProfession => Instance[12];

		public static EventActionKeyItem PerformCutsceneComplete => Instance[6];

		public static EventActionKeyItem OnBlackMaskShowComplete => Instance[7];

		public static EventActionKeyItem OnBlackMaskHideComplete => Instance[8];
	}

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
