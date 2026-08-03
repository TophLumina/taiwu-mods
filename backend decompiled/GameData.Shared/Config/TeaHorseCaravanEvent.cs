using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class TeaHorseCaravanEvent : ConfigData<TeaHorseCaravanEventItem, short>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 遇到海市蜃楼
		/// </summary>
		public const short FindMirage = 0;

		/// <summary>
		/// 发现野人
		/// </summary>
		public const short FindBigfoot = 1;

		/// <summary>
		/// 发现动物
		/// </summary>
		public const short FindAnimal = 2;

		/// <summary>
		/// 发现植物
		/// </summary>
		public const short FindPlant = 3;

		/// <summary>
		/// 回传见闻
		/// </summary>
		public const short GetInformation = 4;

		/// <summary>
		/// 发现聚落
		/// </summary>
		public const short FindSettlement = 5;

		/// <summary>
		/// 发现天气
		/// </summary>
		public const short FindWeather = 6;

		/// <summary>
		/// 迷路了
		/// </summary>
		public const short Lost = 7;

		/// <summary>
		/// 遇到盗贼
		/// </summary>
		public const short MeetTheif = 8;

		/// <summary>
		/// 遇到盗贼1
		/// </summary>
		public const short MeetTheif1 = 9;

		/// <summary>
		/// 遇到盗贼2
		/// </summary>
		public const short MeetTheif2 = 10;

		/// <summary>
		/// 遇到盗贼3
		/// </summary>
		public const short MeetTheif3 = 11;

		/// <summary>
		/// 颠簸损坏
		/// </summary>
		public const short GoodsDamage = 12;

		/// <summary>
		/// 发现商队残骸
		/// </summary>
		public const short FindWreckage = 13;

		/// <summary>
		/// 援助路人
		/// </summary>
		public const short HelpPasserby = 14;

		/// <summary>
		/// 水土不服
		/// </summary>
		public const short Unacclimatized = 15;

		/// <summary>
		/// 获得援助
		/// </summary>
		public const short GetHelp = 16;

		/// <summary>
		/// 偶得野味
		/// </summary>
		public const short FindVenison = 17;

		/// <summary>
		/// 发现果林
		/// </summary>
		public const short FindFruit = 18;

		/// <summary>
		/// 发现村落
		/// </summary>
		public const short FindVillage = 19;

		/// <summary>
		/// 路遇商队
		/// </summary>
		public const short MeetMerchan = 20;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 遇到海市蜃楼
		/// </summary>
		public static TeaHorseCaravanEventItem FindMirage => Instance[(short)0];

		/// <summary>
		/// 发现野人
		/// </summary>
		public static TeaHorseCaravanEventItem FindBigfoot => Instance[(short)1];

		/// <summary>
		/// 发现动物
		/// </summary>
		public static TeaHorseCaravanEventItem FindAnimal => Instance[(short)2];

		/// <summary>
		/// 发现植物
		/// </summary>
		public static TeaHorseCaravanEventItem FindPlant => Instance[(short)3];

		/// <summary>
		/// 回传见闻
		/// </summary>
		public static TeaHorseCaravanEventItem GetInformation => Instance[(short)4];

		/// <summary>
		/// 发现聚落
		/// </summary>
		public static TeaHorseCaravanEventItem FindSettlement => Instance[(short)5];

		/// <summary>
		/// 发现天气
		/// </summary>
		public static TeaHorseCaravanEventItem FindWeather => Instance[(short)6];

		/// <summary>
		/// 迷路了
		/// </summary>
		public static TeaHorseCaravanEventItem Lost => Instance[(short)7];

		/// <summary>
		/// 遇到盗贼
		/// </summary>
		public static TeaHorseCaravanEventItem MeetTheif => Instance[(short)8];

		/// <summary>
		/// 遇到盗贼1
		/// </summary>
		public static TeaHorseCaravanEventItem MeetTheif1 => Instance[(short)9];

		/// <summary>
		/// 遇到盗贼2
		/// </summary>
		public static TeaHorseCaravanEventItem MeetTheif2 => Instance[(short)10];

		/// <summary>
		/// 遇到盗贼3
		/// </summary>
		public static TeaHorseCaravanEventItem MeetTheif3 => Instance[(short)11];

		/// <summary>
		/// 颠簸损坏
		/// </summary>
		public static TeaHorseCaravanEventItem GoodsDamage => Instance[(short)12];

		/// <summary>
		/// 发现商队残骸
		/// </summary>
		public static TeaHorseCaravanEventItem FindWreckage => Instance[(short)13];

		/// <summary>
		/// 援助路人
		/// </summary>
		public static TeaHorseCaravanEventItem HelpPasserby => Instance[(short)14];

		/// <summary>
		/// 水土不服
		/// </summary>
		public static TeaHorseCaravanEventItem Unacclimatized => Instance[(short)15];

		/// <summary>
		/// 获得援助
		/// </summary>
		public static TeaHorseCaravanEventItem GetHelp => Instance[(short)16];

		/// <summary>
		/// 偶得野味
		/// </summary>
		public static TeaHorseCaravanEventItem FindVenison => Instance[(short)17];

		/// <summary>
		/// 发现果林
		/// </summary>
		public static TeaHorseCaravanEventItem FindFruit => Instance[(short)18];

		/// <summary>
		/// 发现村落
		/// </summary>
		public static TeaHorseCaravanEventItem FindVillage => Instance[(short)19];

		/// <summary>
		/// 路遇商队
		/// </summary>
		public static TeaHorseCaravanEventItem MeetMerchan => Instance[(short)20];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static TeaHorseCaravanEvent Instance = new TeaHorseCaravanEvent();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "Desc", "TemplateId", "Parameters" };

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
		_dataArray.Add(new TeaHorseCaravanEventItem(0, LocalStringManager.GetConfig("TeaHorseCaravanEvent_language", "Name_0"), LocalStringManager.GetConfig("TeaHorseCaravanEvent_language", "Desc_0"), new string[6] { "Integer", "", "", "", "", "" }, 2, 1, forwardHappen: true, returnHappen: true, 0, 0, 0, 0, 0, 0, 30, 0, 0, 0, 0, 0, 0, 0));
		_dataArray.Add(new TeaHorseCaravanEventItem(1, LocalStringManager.GetConfig("TeaHorseCaravanEvent_language", "Name_1"), LocalStringManager.GetConfig("TeaHorseCaravanEvent_language", "Desc_1"), new string[6] { "Integer", "", "", "", "", "" }, 2, 1, forwardHappen: true, returnHappen: true, 0, 0, 0, 0, 0, 0, 50, 0, 0, 0, 0, 0, 0, 0));
		_dataArray.Add(new TeaHorseCaravanEventItem(2, LocalStringManager.GetConfig("TeaHorseCaravanEvent_language", "Name_2"), LocalStringManager.GetConfig("TeaHorseCaravanEvent_language", "Desc_2"), new string[6] { "Integer", "", "", "", "", "" }, 2, 1, forwardHappen: true, returnHappen: true, 0, 0, 0, 0, 0, 0, 20, 0, 0, 0, 0, 0, 0, 0));
		_dataArray.Add(new TeaHorseCaravanEventItem(3, LocalStringManager.GetConfig("TeaHorseCaravanEvent_language", "Name_3"), LocalStringManager.GetConfig("TeaHorseCaravanEvent_language", "Desc_3"), new string[6] { "Integer", "", "", "", "", "" }, 2, 1, forwardHappen: true, returnHappen: true, 0, 0, 0, 0, 0, 0, 20, 0, 0, 0, 0, 0, 0, 0));
		_dataArray.Add(new TeaHorseCaravanEventItem(4, LocalStringManager.GetConfig("TeaHorseCaravanEvent_language", "Name_4"), LocalStringManager.GetConfig("TeaHorseCaravanEvent_language", "Desc_4"), new string[6] { "Integer", "", "", "", "", "" }, 2, 1, forwardHappen: true, returnHappen: true, 0, 0, 0, 0, 0, 0, 20, 0, 0, 0, 0, 0, 0, 0));
		_dataArray.Add(new TeaHorseCaravanEventItem(5, LocalStringManager.GetConfig("TeaHorseCaravanEvent_language", "Name_5"), LocalStringManager.GetConfig("TeaHorseCaravanEvent_language", "Desc_5"), new string[6] { "Integer", "", "", "", "", "" }, 2, 1, forwardHappen: true, returnHappen: true, 0, 0, 0, 0, 0, 0, 50, 0, 0, 0, 0, 0, 0, 0));
		_dataArray.Add(new TeaHorseCaravanEventItem(6, LocalStringManager.GetConfig("TeaHorseCaravanEvent_language", "Name_6"), LocalStringManager.GetConfig("TeaHorseCaravanEvent_language", "Desc_6"), new string[6] { "Integer", "", "", "", "", "" }, 2, 1, forwardHappen: true, returnHappen: true, 0, 0, 0, 0, 0, 0, 20, 0, 0, 0, 0, 0, 0, 0));
		_dataArray.Add(new TeaHorseCaravanEventItem(7, LocalStringManager.GetConfig("TeaHorseCaravanEvent_language", "Name_7"), LocalStringManager.GetConfig("TeaHorseCaravanEvent_language", "Desc_7"), new string[6] { "Integer", "", "", "", "", "" }, 3, 1, forwardHappen: true, returnHappen: true, 0, 0, 0, 0, 0, 0, -100, 0, 0, 0, 0, 0, 0, 0));
		_dataArray.Add(new TeaHorseCaravanEventItem(8, LocalStringManager.GetConfig("TeaHorseCaravanEvent_language", "Name_8"), LocalStringManager.GetConfig("TeaHorseCaravanEvent_language", "Desc_8"), new string[6] { "", "", "", "", "", "" }, 5, 1, forwardHappen: true, returnHappen: true, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 3, 0, 0, 0));
		_dataArray.Add(new TeaHorseCaravanEventItem(9, LocalStringManager.GetConfig("TeaHorseCaravanEvent_language", "Name_9"), LocalStringManager.GetConfig("TeaHorseCaravanEvent_language", "Desc_9"), new string[6] { "Item", "", "", "", "", "" }, 5, 0, forwardHappen: true, returnHappen: true, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0));
		_dataArray.Add(new TeaHorseCaravanEventItem(10, LocalStringManager.GetConfig("TeaHorseCaravanEvent_language", "Name_10"), LocalStringManager.GetConfig("TeaHorseCaravanEvent_language", "Desc_10"), new string[6] { "Item", "Item", "", "", "", "" }, 5, 0, forwardHappen: true, returnHappen: true, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 0, 0, 0));
		_dataArray.Add(new TeaHorseCaravanEventItem(11, LocalStringManager.GetConfig("TeaHorseCaravanEvent_language", "Name_11"), LocalStringManager.GetConfig("TeaHorseCaravanEvent_language", "Desc_11"), new string[6] { "Item", "Item", "Item", "", "", "" }, 5, 0, forwardHappen: true, returnHappen: true, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 3, 0, 0, 0));
		_dataArray.Add(new TeaHorseCaravanEventItem(12, LocalStringManager.GetConfig("TeaHorseCaravanEvent_language", "Name_12"), LocalStringManager.GetConfig("TeaHorseCaravanEvent_language", "Desc_12"), new string[6] { "Item", "", "", "", "", "" }, 5, 1, forwardHappen: true, returnHappen: true, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0));
		_dataArray.Add(new TeaHorseCaravanEventItem(13, LocalStringManager.GetConfig("TeaHorseCaravanEvent_language", "Name_13"), LocalStringManager.GetConfig("TeaHorseCaravanEvent_language", "Desc_13"), new string[6] { "Item", "", "", "", "", "" }, 4, 1, forwardHappen: true, returnHappen: true, 0, 0, 0, 0, 0, 0, 0, 4, 6, 0, 0, 0, 0, 1));
		_dataArray.Add(new TeaHorseCaravanEventItem(14, LocalStringManager.GetConfig("TeaHorseCaravanEvent_language", "Name_14"), LocalStringManager.GetConfig("TeaHorseCaravanEvent_language", "Desc_14"), new string[6] { "Integer", "Integer", "", "", "", "" }, 7, 1, forwardHappen: true, returnHappen: true, 0, 0, 0, 0, 0, 0, 100, 0, 0, 0, 0, -10, -5, 0));
		_dataArray.Add(new TeaHorseCaravanEventItem(15, LocalStringManager.GetConfig("TeaHorseCaravanEvent_language", "Name_15"), LocalStringManager.GetConfig("TeaHorseCaravanEvent_language", "Desc_15"), new string[6] { "Integer", "", "", "", "", "" }, 7, 1, forwardHappen: true, returnHappen: true, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -30, -10, 0));
		_dataArray.Add(new TeaHorseCaravanEventItem(16, LocalStringManager.GetConfig("TeaHorseCaravanEvent_language", "Name_16"), LocalStringManager.GetConfig("TeaHorseCaravanEvent_language", "Desc_16"), new string[6] { "Integer", "", "", "", "", "" }, 6, 1, forwardHappen: true, returnHappen: true, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 30, 0));
		_dataArray.Add(new TeaHorseCaravanEventItem(17, LocalStringManager.GetConfig("TeaHorseCaravanEvent_language", "Name_17"), LocalStringManager.GetConfig("TeaHorseCaravanEvent_language", "Desc_17"), new string[6] { "Integer", "", "", "", "", "" }, 6, 1, forwardHappen: true, returnHappen: true, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 30, 0));
		_dataArray.Add(new TeaHorseCaravanEventItem(18, LocalStringManager.GetConfig("TeaHorseCaravanEvent_language", "Name_18"), LocalStringManager.GetConfig("TeaHorseCaravanEvent_language", "Desc_18"), new string[6] { "Integer", "", "", "", "", "" }, 1, 1, forwardHappen: true, returnHappen: true, 0, 0, 30, 50, 10, 15, 0, 0, 0, 0, 0, 0, 0, 0));
		_dataArray.Add(new TeaHorseCaravanEventItem(19, LocalStringManager.GetConfig("TeaHorseCaravanEvent_language", "Name_19"), LocalStringManager.GetConfig("TeaHorseCaravanEvent_language", "Desc_19"), new string[6] { "Integer", "", "", "", "", "" }, 0, 1, forwardHappen: true, returnHappen: true, 60, 80, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
		_dataArray.Add(new TeaHorseCaravanEventItem(20, LocalStringManager.GetConfig("TeaHorseCaravanEvent_language", "Name_20"), LocalStringManager.GetConfig("TeaHorseCaravanEvent_language", "Desc_20"), new string[6] { "Integer", "", "", "", "", "" }, 0, 1, forwardHappen: true, returnHappen: true, 40, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<TeaHorseCaravanEventItem>(21);
		CreateItems0();
	}
}
