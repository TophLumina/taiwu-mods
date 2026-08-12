using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class Cricket : ConfigData<CricketItem, short>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 九品促织
		/// </summary>
		public const short Cricket0 = 0;

		/// <summary>
		/// 八品促织
		/// </summary>
		public const short Cricket1 = 1;

		/// <summary>
		/// 七品促织
		/// </summary>
		public const short Cricket2 = 2;

		/// <summary>
		/// 六品促织
		/// </summary>
		public const short Cricket3 = 3;

		/// <summary>
		/// 五品促织
		/// </summary>
		public const short Cricket4 = 4;

		/// <summary>
		/// 四品促织
		/// </summary>
		public const short Cricket5 = 5;

		/// <summary>
		/// 三品促织
		/// </summary>
		public const short Cricket6 = 6;

		/// <summary>
		/// 二品促织
		/// </summary>
		public const short Cricket7 = 7;

		/// <summary>
		/// 一品促织
		/// </summary>
		public const short Cricket8 = 8;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 九品促织
		/// </summary>
		public static CricketItem Cricket0 => Instance[(short)0];

		/// <summary>
		/// 八品促织
		/// </summary>
		public static CricketItem Cricket1 => Instance[(short)1];

		/// <summary>
		/// 七品促织
		/// </summary>
		public static CricketItem Cricket2 => Instance[(short)2];

		/// <summary>
		/// 六品促织
		/// </summary>
		public static CricketItem Cricket3 => Instance[(short)3];

		/// <summary>
		/// 五品促织
		/// </summary>
		public static CricketItem Cricket4 => Instance[(short)4];

		/// <summary>
		/// 四品促织
		/// </summary>
		public static CricketItem Cricket5 => Instance[(short)5];

		/// <summary>
		/// 三品促织
		/// </summary>
		public static CricketItem Cricket6 => Instance[(short)6];

		/// <summary>
		/// 二品促织
		/// </summary>
		public static CricketItem Cricket7 => Instance[(short)7];

		/// <summary>
		/// 一品促织
		/// </summary>
		public static CricketItem Cricket8 => Instance[(short)8];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static Cricket Instance = new Cricket();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "ItemSubType", "GroupId", "Desc", "ResourceType", "TaskLock", "TemplateId", "Grade", "Icon" };

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
		_dataArray.Add(new CricketItem(0, LocalStringManager.GetConfig("Cricket_language", "Name_0"), 11, 1100, 0, 0, "icon_Cricket_cuzhi_9", LocalStringManager.GetConfig("Cricket_language", "Desc_0"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 0, 0, 0, 0, 8, allowRandomCreate: false, 0, isSpecial: true, 0, 12, new List<int>()));
		_dataArray.Add(new CricketItem(1, LocalStringManager.GetConfig("Cricket_language", "Name_1"), 11, 1100, 1, 0, "icon_Cricket_cuzhi_8", LocalStringManager.GetConfig("Cricket_language", "Desc_1"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 0, 0, 0, 0, 8, allowRandomCreate: false, 0, isSpecial: true, 0, 12, new List<int>()));
		_dataArray.Add(new CricketItem(2, LocalStringManager.GetConfig("Cricket_language", "Name_2"), 11, 1100, 2, 0, "icon_Cricket_cuzhi_7", LocalStringManager.GetConfig("Cricket_language", "Desc_2"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 0, 0, 0, 0, 8, allowRandomCreate: false, 0, isSpecial: true, 0, 12, new List<int>()));
		_dataArray.Add(new CricketItem(3, LocalStringManager.GetConfig("Cricket_language", "Name_3"), 11, 1100, 3, 0, "icon_Cricket_cuzhi_6", LocalStringManager.GetConfig("Cricket_language", "Desc_3"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 0, 1, 0, 0, 8, allowRandomCreate: false, 0, isSpecial: true, 0, 12, new List<int>()));
		_dataArray.Add(new CricketItem(4, LocalStringManager.GetConfig("Cricket_language", "Name_4"), 11, 1100, 4, 0, "icon_Cricket_cuzhi_5", LocalStringManager.GetConfig("Cricket_language", "Desc_4"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 0, 2, 0, 0, 8, allowRandomCreate: false, 0, isSpecial: true, 0, 12, new List<int>()));
		_dataArray.Add(new CricketItem(5, LocalStringManager.GetConfig("Cricket_language", "Name_5"), 11, 1100, 5, 0, "icon_Cricket_cuzhi_4", LocalStringManager.GetConfig("Cricket_language", "Desc_5"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 0, 3, 0, 0, 8, allowRandomCreate: false, 0, isSpecial: true, 0, 12, new List<int>()));
		_dataArray.Add(new CricketItem(6, LocalStringManager.GetConfig("Cricket_language", "Name_6"), 11, 1100, 6, 0, "icon_Cricket_cuzhi_3", LocalStringManager.GetConfig("Cricket_language", "Desc_6"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 0, 4, 0, 0, 8, allowRandomCreate: false, 0, isSpecial: true, 0, 12, new List<int>()));
		_dataArray.Add(new CricketItem(7, LocalStringManager.GetConfig("Cricket_language", "Name_7"), 11, 1100, 7, 0, "icon_Cricket_cuzhi_2", LocalStringManager.GetConfig("Cricket_language", "Desc_7"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 0, 5, 0, 0, 8, allowRandomCreate: false, 0, isSpecial: true, 0, 12, new List<int>()));
		_dataArray.Add(new CricketItem(8, LocalStringManager.GetConfig("Cricket_language", "Name_8"), 11, 1100, 8, 0, "icon_Cricket_cuzhi_1", LocalStringManager.GetConfig("Cricket_language", "Desc_8"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 10, 0, 6, 0, 0, 8, allowRandomCreate: false, 0, isSpecial: true, 0, 12, new List<int>()));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<CricketItem>(9);
		CreateItems0();
	}
}
