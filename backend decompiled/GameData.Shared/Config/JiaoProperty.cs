using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class JiaoProperty : ConfigData<JiaoPropertyItem, short>
{
	public static class DefKey
	{
		public const short TravelTimeReduction = 0;

		public const short BaseMaxInventoryLoadBonus = 1;

		public const short BaseDropRateBonus = 2;

		public const short BaseCaptureRateBonus = 3;

		public const short BaseMaxKidnapSlotCountBonus = 4;

		public const short ExploreBonusRate = 5;

		public const short BaseValue = 6;

		public const short BaseHappinessChange = 7;

		public const short BaseFavorabilityChange = 8;

		public const short JiaoLength = 9;

		public const short JiaoWeight = 10;

		public const short JiaoLongevity = 11;

		public const short BasePrice = 12;
	}

	public static class DefValue
	{
		public static JiaoPropertyItem TravelTimeReduction => Instance[(short)0];

		public static JiaoPropertyItem BaseMaxInventoryLoadBonus => Instance[(short)1];

		public static JiaoPropertyItem BaseDropRateBonus => Instance[(short)2];

		public static JiaoPropertyItem BaseCaptureRateBonus => Instance[(short)3];

		public static JiaoPropertyItem BaseMaxKidnapSlotCountBonus => Instance[(short)4];

		public static JiaoPropertyItem ExploreBonusRate => Instance[(short)5];

		public static JiaoPropertyItem BaseValue => Instance[(short)6];

		public static JiaoPropertyItem BaseHappinessChange => Instance[(short)7];

		public static JiaoPropertyItem BaseFavorabilityChange => Instance[(short)8];

		public static JiaoPropertyItem JiaoLength => Instance[(short)9];

		public static JiaoPropertyItem JiaoWeight => Instance[(short)10];

		public static JiaoPropertyItem JiaoLongevity => Instance[(short)11];

		public static JiaoPropertyItem BasePrice => Instance[(short)12];
	}

	public static JiaoProperty Instance = new JiaoProperty();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "EventDescUp", "EventDescDown", "JiaoRecordTemplateId", "JiaoNurturanceTemplateId", "TemplateId", "TipsIcon", "SpecialDescTitle", "SpecialDesc" };

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
		_dataArray.Add(new JiaoPropertyItem(0, LocalStringManager.GetConfig("JiaoProperty_language", "Name_0"), LocalStringManager.GetConfig("JiaoProperty_language", "EventDescUp_0"), LocalStringManager.GetConfig("JiaoProperty_language", "EventDescDown_0"), new int[2] { 100, 200 }, 200, 200, -5, -15, 100, 75, 10, 60, 3, 1, "mousetip_travel", null, null, increaseIsGood: false));
		_dataArray.Add(new JiaoPropertyItem(1, LocalStringManager.GetConfig("JiaoProperty_language", "Name_1"), LocalStringManager.GetConfig("JiaoProperty_language", "EventDescUp_1"), LocalStringManager.GetConfig("JiaoProperty_language", "EventDescDown_1"), new int[2] { 45000, 90000 }, 90000, 200, -5, -15, 100, 75, 10, 20000, 2, 2, "mousetip_bag", null, null, increaseIsGood: true));
		_dataArray.Add(new JiaoPropertyItem(2, LocalStringManager.GetConfig("JiaoProperty_language", "Name_2"), LocalStringManager.GetConfig("JiaoProperty_language", "EventDescUp_2"), LocalStringManager.GetConfig("JiaoProperty_language", "EventDescDown_2"), new int[2] { 400, 800 }, 800, 200, -5, -15, 100, 75, 10, 150, 6, 4, "mousetip_dropped", null, null, increaseIsGood: true));
		_dataArray.Add(new JiaoPropertyItem(3, LocalStringManager.GetConfig("JiaoProperty_language", "Name_3"), LocalStringManager.GetConfig("JiaoProperty_language", "EventDescUp_3"), LocalStringManager.GetConfig("JiaoProperty_language", "EventDescDown_3"), new int[2] { 400, 800 }, 800, 200, -5, -15, 100, 75, 10, 150, 33, 9, "mousetip_detention_0", null, null, increaseIsGood: true));
		_dataArray.Add(new JiaoPropertyItem(4, LocalStringManager.GetConfig("JiaoProperty_language", "Name_4"), LocalStringManager.GetConfig("JiaoProperty_language", "EventDescUp_4"), LocalStringManager.GetConfig("JiaoProperty_language", "EventDescDown_4"), new int[2] { 50, 100 }, 100, 200, -5, -15, 100, 75, 10, 12, 4, 3, "mousetip_detention_1", null, null, increaseIsGood: true));
		_dataArray.Add(new JiaoPropertyItem(5, LocalStringManager.GetConfig("JiaoProperty_language", "Name_5"), LocalStringManager.GetConfig("JiaoProperty_language", "EventDescUp_5"), LocalStringManager.GetConfig("JiaoProperty_language", "EventDescDown_5"), new int[2] { 200, 400 }, 400, 200, -5, -15, 100, 75, 10, 60, 5, 5, "mousetip_fuyusword", null, null, increaseIsGood: true));
		_dataArray.Add(new JiaoPropertyItem(6, LocalStringManager.GetConfig("JiaoProperty_language", "Name_6"), LocalStringManager.GetConfig("JiaoProperty_language", "EventDescUp_6"), LocalStringManager.GetConfig("JiaoProperty_language", "EventDescDown_6"), new int[2] { 450000, 900000 }, 900000, 200, -5, -15, 100, 75, 10, 123000, 7, 6, "mousetip_jiage", "价格", "此蛟被售出时的价格", increaseIsGood: true));
		_dataArray.Add(new JiaoPropertyItem(7, LocalStringManager.GetConfig("JiaoProperty_language", "Name_7"), LocalStringManager.GetConfig("JiaoProperty_language", "EventDescUp_7"), LocalStringManager.GetConfig("JiaoProperty_language", "EventDescDown_7"), new int[2] { 100, 200 }, 200, 200, -5, -15, 100, 75, 10, 36, 9, 7, "mousetip_mood", "赠礼心情", "此蛟作为礼物赠予时，对方的心情额外恢复", increaseIsGood: true));
		_dataArray.Add(new JiaoPropertyItem(8, LocalStringManager.GetConfig("JiaoProperty_language", "Name_8"), LocalStringManager.GetConfig("JiaoProperty_language", "EventDescUp_8"), LocalStringManager.GetConfig("JiaoProperty_language", "EventDescDown_8"), new int[2] { 54000, 108000 }, 108000, 200, -5, -15, 100, 75, 10, 21600, 10, 8, "mousetip_opinion", "赠礼好感", "此蛟作为礼物赠予时，对方的好感额外增加", increaseIsGood: true));
		_dataArray.Add(new JiaoPropertyItem(9, LocalStringManager.GetConfig("JiaoProperty_language", "Name_9"), LocalStringManager.GetConfig("JiaoProperty_language", "EventDescUp_9"), LocalStringManager.GetConfig("JiaoProperty_language", "EventDescDown_9"), new int[2] { 50, 100 }, 0, 0, 0, 0, 0, 0, 0, 0, -1, -1, null, null, null, increaseIsGood: true));
		_dataArray.Add(new JiaoPropertyItem(10, LocalStringManager.GetConfig("JiaoProperty_language", "Name_10"), LocalStringManager.GetConfig("JiaoProperty_language", "EventDescUp_10"), LocalStringManager.GetConfig("JiaoProperty_language", "EventDescDown_10"), new int[2] { 500, 1000 }, 0, 0, 0, 0, 0, 0, 0, 0, -1, -1, null, null, null, increaseIsGood: true));
		_dataArray.Add(new JiaoPropertyItem(11, LocalStringManager.GetConfig("JiaoProperty_language", "Name_11"), LocalStringManager.GetConfig("JiaoProperty_language", "EventDescUp_11"), LocalStringManager.GetConfig("JiaoProperty_language", "EventDescDown_11"), new int[2] { 5000, 10000 }, 0, 0, 0, 0, 0, 0, 0, 0, -1, -1, null, null, null, increaseIsGood: true));
		_dataArray.Add(new JiaoPropertyItem(12, LocalStringManager.GetConfig("JiaoProperty_language", "Name_12"), LocalStringManager.GetConfig("JiaoProperty_language", "EventDescUp_12"), LocalStringManager.GetConfig("JiaoProperty_language", "EventDescDown_12"), new int[2] { 450000, 900000 }, 900000, 200, -5, -15, 100, 75, 10, 0, 7, 6, "mousetip_jiage", "价格", "此蛟被售出时的价格", increaseIsGood: true));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<JiaoPropertyItem>(13);
		CreateItems0();
	}
}
