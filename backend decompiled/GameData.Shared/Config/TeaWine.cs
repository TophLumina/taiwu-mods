using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class TeaWine : ConfigData<TeaWineItem, short>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 关外酪酒
		/// </summary>
		public const short WineOuter0 = 0;

		/// <summary>
		/// 宝丰酒
		/// </summary>
		public const short WineOuter1 = 1;

		/// <summary>
		/// 竹叶青酒
		/// </summary>
		public const short WineOuter2 = 2;

		/// <summary>
		/// 花雕酒
		/// </summary>
		public const short WineOuter3 = 3;

		/// <summary>
		/// 新丰酒
		/// </summary>
		public const short WineOuter4 = 4;

		/// <summary>
		/// 曲阿酒
		/// </summary>
		public const short WineOuter5 = 5;

		/// <summary>
		/// 剑南烧春
		/// </summary>
		public const short WineOuter6 = 6;

		/// <summary>
		/// 茅台白酒
		/// </summary>
		public const short WineOuter7 = 7;

		/// <summary>
		/// 猴儿酒
		/// </summary>
		public const short WineOuter8 = 8;

		/// <summary>
		/// 高粱酒
		/// </summary>
		public const short WineInner0 = 9;

		/// <summary>
		/// 西凤酒
		/// </summary>
		public const short WineInner1 = 10;

		/// <summary>
		/// 东坡蜜酒
		/// </summary>
		public const short WineInner2 = 11;

		/// <summary>
		/// 西域葡萄酒
		/// </summary>
		public const short WineInner3 = 12;

		/// <summary>
		/// 姚子雪曲
		/// </summary>
		public const short WineInner4 = 13;

		/// <summary>
		/// 百草玉露酒
		/// </summary>
		public const short WineInner5 = 14;

		/// <summary>
		/// 杏花汾清
		/// </summary>
		public const short WineInner6 = 15;

		/// <summary>
		/// 兰陵美酒
		/// </summary>
		public const short WineInner7 = 16;

		/// <summary>
		/// 杜康酒
		/// </summary>
		public const short WineInner8 = 17;

		/// <summary>
		/// 普洱茶
		/// </summary>
		public const short TeaOuter0 = 18;

		/// <summary>
		/// 鹿苑毛尖
		/// </summary>
		public const short TeaOuter1 = 19;

		/// <summary>
		/// 武夷岩茶
		/// </summary>
		public const short TeaOuter2 = 20;

		/// <summary>
		/// 君山银针
		/// </summary>
		public const short TeaOuter3 = 21;

		/// <summary>
		/// 祁门红茶
		/// </summary>
		public const short TeaOuter4 = 22;

		/// <summary>
		/// 金瓜贡茶
		/// </summary>
		public const short TeaOuter5 = 23;

		/// <summary>
		/// 顾渚紫笋
		/// </summary>
		public const short TeaOuter6 = 24;

		/// <summary>
		/// 大红袍
		/// </summary>
		public const short TeaOuter7 = 25;

		/// <summary>
		/// 蒙顶黄芽
		/// </summary>
		public const short TeaOuter8 = 26;

		/// <summary>
		/// 竹叶青茶
		/// </summary>
		public const short TeaInner0 = 27;

		/// <summary>
		/// 都匀毛尖
		/// </summary>
		public const short TeaInner1 = 28;

		/// <summary>
		/// 六安瓜片
		/// </summary>
		public const short TeaInner2 = 29;

		/// <summary>
		/// 信阳毛尖
		/// </summary>
		public const short TeaInner3 = 30;

		/// <summary>
		/// 庐山云雾茶
		/// </summary>
		public const short TeaInner4 = 31;

		/// <summary>
		/// 碧螺春
		/// </summary>
		public const short TeaInner5 = 32;

		/// <summary>
		/// 西湖龙井茶
		/// </summary>
		public const short TeaInner6 = 33;

		/// <summary>
		/// 方山露芽
		/// </summary>
		public const short TeaInner7 = 34;

		/// <summary>
		/// 蒙顶甘露
		/// </summary>
		public const short TeaInner8 = 35;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 关外酪酒
		/// </summary>
		public static TeaWineItem WineOuter0 => Instance[(short)0];

		/// <summary>
		/// 宝丰酒
		/// </summary>
		public static TeaWineItem WineOuter1 => Instance[(short)1];

		/// <summary>
		/// 竹叶青酒
		/// </summary>
		public static TeaWineItem WineOuter2 => Instance[(short)2];

		/// <summary>
		/// 花雕酒
		/// </summary>
		public static TeaWineItem WineOuter3 => Instance[(short)3];

		/// <summary>
		/// 新丰酒
		/// </summary>
		public static TeaWineItem WineOuter4 => Instance[(short)4];

		/// <summary>
		/// 曲阿酒
		/// </summary>
		public static TeaWineItem WineOuter5 => Instance[(short)5];

		/// <summary>
		/// 剑南烧春
		/// </summary>
		public static TeaWineItem WineOuter6 => Instance[(short)6];

		/// <summary>
		/// 茅台白酒
		/// </summary>
		public static TeaWineItem WineOuter7 => Instance[(short)7];

		/// <summary>
		/// 猴儿酒
		/// </summary>
		public static TeaWineItem WineOuter8 => Instance[(short)8];

		/// <summary>
		/// 高粱酒
		/// </summary>
		public static TeaWineItem WineInner0 => Instance[(short)9];

		/// <summary>
		/// 西凤酒
		/// </summary>
		public static TeaWineItem WineInner1 => Instance[(short)10];

		/// <summary>
		/// 东坡蜜酒
		/// </summary>
		public static TeaWineItem WineInner2 => Instance[(short)11];

		/// <summary>
		/// 西域葡萄酒
		/// </summary>
		public static TeaWineItem WineInner3 => Instance[(short)12];

		/// <summary>
		/// 姚子雪曲
		/// </summary>
		public static TeaWineItem WineInner4 => Instance[(short)13];

		/// <summary>
		/// 百草玉露酒
		/// </summary>
		public static TeaWineItem WineInner5 => Instance[(short)14];

		/// <summary>
		/// 杏花汾清
		/// </summary>
		public static TeaWineItem WineInner6 => Instance[(short)15];

		/// <summary>
		/// 兰陵美酒
		/// </summary>
		public static TeaWineItem WineInner7 => Instance[(short)16];

		/// <summary>
		/// 杜康酒
		/// </summary>
		public static TeaWineItem WineInner8 => Instance[(short)17];

		/// <summary>
		/// 普洱茶
		/// </summary>
		public static TeaWineItem TeaOuter0 => Instance[(short)18];

		/// <summary>
		/// 鹿苑毛尖
		/// </summary>
		public static TeaWineItem TeaOuter1 => Instance[(short)19];

		/// <summary>
		/// 武夷岩茶
		/// </summary>
		public static TeaWineItem TeaOuter2 => Instance[(short)20];

		/// <summary>
		/// 君山银针
		/// </summary>
		public static TeaWineItem TeaOuter3 => Instance[(short)21];

		/// <summary>
		/// 祁门红茶
		/// </summary>
		public static TeaWineItem TeaOuter4 => Instance[(short)22];

		/// <summary>
		/// 金瓜贡茶
		/// </summary>
		public static TeaWineItem TeaOuter5 => Instance[(short)23];

		/// <summary>
		/// 顾渚紫笋
		/// </summary>
		public static TeaWineItem TeaOuter6 => Instance[(short)24];

		/// <summary>
		/// 大红袍
		/// </summary>
		public static TeaWineItem TeaOuter7 => Instance[(short)25];

		/// <summary>
		/// 蒙顶黄芽
		/// </summary>
		public static TeaWineItem TeaOuter8 => Instance[(short)26];

		/// <summary>
		/// 竹叶青茶
		/// </summary>
		public static TeaWineItem TeaInner0 => Instance[(short)27];

		/// <summary>
		/// 都匀毛尖
		/// </summary>
		public static TeaWineItem TeaInner1 => Instance[(short)28];

		/// <summary>
		/// 六安瓜片
		/// </summary>
		public static TeaWineItem TeaInner2 => Instance[(short)29];

		/// <summary>
		/// 信阳毛尖
		/// </summary>
		public static TeaWineItem TeaInner3 => Instance[(short)30];

		/// <summary>
		/// 庐山云雾茶
		/// </summary>
		public static TeaWineItem TeaInner4 => Instance[(short)31];

		/// <summary>
		/// 碧螺春
		/// </summary>
		public static TeaWineItem TeaInner5 => Instance[(short)32];

		/// <summary>
		/// 西湖龙井茶
		/// </summary>
		public static TeaWineItem TeaInner6 => Instance[(short)33];

		/// <summary>
		/// 方山露芽
		/// </summary>
		public static TeaWineItem TeaInner7 => Instance[(short)34];

		/// <summary>
		/// 蒙顶甘露
		/// </summary>
		public static TeaWineItem TeaInner8 => Instance[(short)35];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static TeaWine Instance = new TeaWine();

	private readonly HashSet<string> RequiredFields = new HashSet<string>
	{
		"Name", "ItemSubType", "GroupId", "Desc", "FunctionDesc", "ResourceType", "BreakBonusEffect", "TaskLock", "TemplateId", "Grade",
		"Icon", "BigIcon", "BaseWeight", "BaseHappinessChange", "DropRate"
	};

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
		_dataArray.Add(new TeaWineItem(0, LocalStringManager.GetConfig("TeaWine_language", "Name_0"), 9, 901, 0, 0, "icon_TeaWine_guanwailaojiu", "bigIcon_TeaWine_guanwailaojiu", LocalStringManager.GetConfig("TeaWine_language", "Desc_0"), LocalStringManager.GetConfig("TeaWine_language", "FunctionDesc_0"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 100, 150, 0, 2, 600, 3, allowRandomCreate: true, 50, isSpecial: false, 0, 36, 39, new List<int>(), 1, 400, 1, 60, 0, 0, 0, 0, 50, 50, 0, 0, 0, 0, -50, -50, 20, 0, 0, 8, 1));
		_dataArray.Add(new TeaWineItem(1, LocalStringManager.GetConfig("TeaWine_language", "Name_1"), 9, 901, 1, 0, "icon_TeaWine_baofengjiu", "bigIcon_TeaWine_baofengjiu", LocalStringManager.GetConfig("TeaWine_language", "Desc_1"), LocalStringManager.GetConfig("TeaWine_language", "FunctionDesc_1"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 100, 300, 0, 4, 1200, 4, allowRandomCreate: true, 45, isSpecial: false, 0, 36, 39, new List<int>(), 1, 600, 1, 60, 0, 0, 0, 0, 55, 55, 0, 0, 0, 0, -55, -55, 25, 0, 0, 12, 1));
		_dataArray.Add(new TeaWineItem(2, LocalStringManager.GetConfig("TeaWine_language", "Name_2"), 9, 901, 2, 0, "icon_TeaWine_zhuyeqingjiu", "bigIcon_TeaWine_zhuyeqingjiu", LocalStringManager.GetConfig("TeaWine_language", "Desc_2"), LocalStringManager.GetConfig("TeaWine_language", "FunctionDesc_2"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 100, 900, 0, 6, 1800, 5, allowRandomCreate: true, 40, isSpecial: false, 0, 36, 39, new List<int>(), 1, 800, 1, 60, 0, 0, 0, 0, 60, 60, 0, 0, 0, 0, -60, -60, 30, 0, 0, 16, 1));
		_dataArray.Add(new TeaWineItem(3, LocalStringManager.GetConfig("TeaWine_language", "Name_3"), 9, 901, 3, 0, "icon_TeaWine_huadiaojiu", "bigIcon_TeaWine_huadiaojiu", LocalStringManager.GetConfig("TeaWine_language", "Desc_3"), LocalStringManager.GetConfig("TeaWine_language", "FunctionDesc_3"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 100, 2250, 1, 8, 3000, 6, allowRandomCreate: true, 35, isSpecial: false, 0, 36, 39, new List<int>(), 1, 1000, 1, 60, 0, 0, 0, 0, 70, 70, 0, 0, 0, 0, -70, -70, 35, 0, 0, 24, 1));
		_dataArray.Add(new TeaWineItem(4, LocalStringManager.GetConfig("TeaWine_language", "Name_4"), 9, 901, 4, 0, "icon_TeaWine_xinfengjiu", "bigIcon_TeaWine_xinfengjiu", LocalStringManager.GetConfig("TeaWine_language", "Desc_4"), LocalStringManager.GetConfig("TeaWine_language", "FunctionDesc_4"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 100, 4650, 2, 10, 4200, 7, allowRandomCreate: true, 30, isSpecial: false, 0, 36, 39, new List<int>(), 1, 1200, 1, 60, 0, 0, 0, 0, 80, 80, 0, 0, 0, 0, -80, -80, 40, 0, 0, 32, 1));
		_dataArray.Add(new TeaWineItem(5, LocalStringManager.GetConfig("TeaWine_language", "Name_5"), 9, 901, 5, 0, "icon_TeaWine_quejiu", "bigIcon_TeaWine_quejiu", LocalStringManager.GetConfig("TeaWine_language", "Desc_5"), LocalStringManager.GetConfig("TeaWine_language", "FunctionDesc_5"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 100, 8400, 3, 12, 5400, 7, allowRandomCreate: true, 25, isSpecial: false, 0, 36, 39, new List<int>(), 1, 1400, 1, 60, 0, 0, 0, 0, 90, 90, 0, 0, 0, 0, -90, -90, 45, 0, 0, 40, 1));
		_dataArray.Add(new TeaWineItem(6, LocalStringManager.GetConfig("TeaWine_language", "Name_6"), 9, 901, 6, 0, "icon_TeaWine_jiannanshaochun", "bigIcon_TeaWine_jiannanshaochun", LocalStringManager.GetConfig("TeaWine_language", "Desc_6"), LocalStringManager.GetConfig("TeaWine_language", "FunctionDesc_6"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 100, 13800, 4, 14, 7200, 8, allowRandomCreate: true, 20, isSpecial: false, 0, 36, 39, new List<int>(), 1, 1600, 1, 60, 0, 0, 0, 0, 105, 105, 0, 0, 0, 0, -105, -105, 50, 0, 0, 52, 1));
		_dataArray.Add(new TeaWineItem(7, LocalStringManager.GetConfig("TeaWine_language", "Name_7"), 9, 901, 7, 0, "icon_TeaWine_maotaibaijiu", "bigIcon_TeaWine_maotaibaijiu", LocalStringManager.GetConfig("TeaWine_language", "Desc_7"), LocalStringManager.GetConfig("TeaWine_language", "FunctionDesc_7"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 100, 21150, 5, 16, 9000, 8, allowRandomCreate: true, 15, isSpecial: false, 0, 36, 39, new List<int>(), 1, 1800, 1, 60, 0, 0, 0, 0, 125, 125, 0, 0, 0, 0, -125, -125, 55, 0, 0, 68, 1));
		_dataArray.Add(new TeaWineItem(8, LocalStringManager.GetConfig("TeaWine_language", "Name_8"), 9, 901, 8, 0, "icon_TeaWine_houerjiu", "bigIcon_TeaWine_houerjiu", LocalStringManager.GetConfig("TeaWine_language", "Desc_8"), LocalStringManager.GetConfig("TeaWine_language", "FunctionDesc_8"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 100, 30750, 6, 18, 10800, 8, allowRandomCreate: true, 10, isSpecial: false, 0, 36, 39, new List<int>(), 1, 2000, 1, 60, 0, 0, 0, 0, 150, 150, 0, 0, 0, 0, -150, -150, 60, 0, 0, 88, 1));
		_dataArray.Add(new TeaWineItem(9, LocalStringManager.GetConfig("TeaWine_language", "Name_9"), 9, 901, 0, 9, "icon_TeaWine_gaoliangjiu", "bigIcon_TeaWine_gaoliangjiu", LocalStringManager.GetConfig("TeaWine_language", "Desc_9"), LocalStringManager.GetConfig("TeaWine_language", "FunctionDesc_9"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 100, 150, 0, 2, 600, 3, allowRandomCreate: true, 50, isSpecial: false, 0, 36, 39, new List<int>(), 1, 400, 1, 60, 50, 50, 50, 50, 0, 0, -50, -50, -50, -50, 0, 0, 20, 0, 0, 8, 0));
		_dataArray.Add(new TeaWineItem(10, LocalStringManager.GetConfig("TeaWine_language", "Name_10"), 9, 901, 1, 9, "icon_TeaWine_xifengjiu", "bigIcon_TeaWine_xifengjiu", LocalStringManager.GetConfig("TeaWine_language", "Desc_10"), LocalStringManager.GetConfig("TeaWine_language", "FunctionDesc_10"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 100, 300, 0, 4, 1200, 4, allowRandomCreate: true, 45, isSpecial: false, 0, 36, 39, new List<int>(), 1, 600, 1, 60, 55, 55, 55, 55, 0, 0, -55, -55, -55, -55, 0, 0, 25, 0, 0, 12, 0));
		_dataArray.Add(new TeaWineItem(11, LocalStringManager.GetConfig("TeaWine_language", "Name_11"), 9, 901, 2, 9, "icon_TeaWine_dongpomijiu", "bigIcon_TeaWine_dongpomijiu", LocalStringManager.GetConfig("TeaWine_language", "Desc_11"), LocalStringManager.GetConfig("TeaWine_language", "FunctionDesc_11"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 100, 900, 0, 6, 1800, 5, allowRandomCreate: true, 40, isSpecial: false, 0, 36, 39, new List<int>(), 1, 800, 1, 60, 60, 60, 60, 60, 0, 0, -60, -60, -60, -60, 0, 0, 30, 0, 0, 16, 0));
		_dataArray.Add(new TeaWineItem(12, LocalStringManager.GetConfig("TeaWine_language", "Name_12"), 9, 901, 3, 9, "icon_TeaWine_xiyuputaojiu", "bigIcon_TeaWine_xiyuputaojiu", LocalStringManager.GetConfig("TeaWine_language", "Desc_12"), LocalStringManager.GetConfig("TeaWine_language", "FunctionDesc_12"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 100, 2250, 1, 8, 3000, 6, allowRandomCreate: true, 35, isSpecial: false, 0, 36, 39, new List<int>(), 1, 1000, 1, 60, 70, 70, 70, 70, 0, 0, -70, -70, -70, -70, 0, 0, 35, 0, 0, 24, 0));
		_dataArray.Add(new TeaWineItem(13, LocalStringManager.GetConfig("TeaWine_language", "Name_13"), 9, 901, 4, 9, "icon_TeaWine_yaozixuequ", "bigIcon_TeaWine_yaozixuequ", LocalStringManager.GetConfig("TeaWine_language", "Desc_13"), LocalStringManager.GetConfig("TeaWine_language", "FunctionDesc_13"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 100, 4650, 2, 10, 4200, 7, allowRandomCreate: true, 30, isSpecial: false, 0, 36, 39, new List<int>(), 1, 1200, 1, 60, 80, 80, 80, 80, 0, 0, -80, -80, -80, -80, 0, 0, 40, 0, 0, 32, 0));
		_dataArray.Add(new TeaWineItem(14, LocalStringManager.GetConfig("TeaWine_language", "Name_14"), 9, 901, 5, 9, "icon_TeaWine_baicaoyulujiu", "bigIcon_TeaWine_baicaoyulujiu", LocalStringManager.GetConfig("TeaWine_language", "Desc_14"), LocalStringManager.GetConfig("TeaWine_language", "FunctionDesc_14"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 100, 8400, 3, 12, 5400, 7, allowRandomCreate: true, 25, isSpecial: false, 0, 36, 39, new List<int>(), 1, 1400, 1, 60, 90, 90, 90, 90, 0, 0, -90, -90, -90, -90, 0, 0, 45, 0, 0, 40, 0));
		_dataArray.Add(new TeaWineItem(15, LocalStringManager.GetConfig("TeaWine_language", "Name_15"), 9, 901, 6, 9, "icon_TeaWine_xinghuafenqing", "bigIcon_TeaWine_xinghuafenqing", LocalStringManager.GetConfig("TeaWine_language", "Desc_15"), LocalStringManager.GetConfig("TeaWine_language", "FunctionDesc_15"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 100, 13800, 4, 14, 7200, 8, allowRandomCreate: true, 20, isSpecial: false, 0, 36, 39, new List<int>(), 1, 1600, 1, 60, 105, 105, 105, 105, 0, 0, -105, -105, -105, -105, 0, 0, 50, 0, 0, 52, 0));
		_dataArray.Add(new TeaWineItem(16, LocalStringManager.GetConfig("TeaWine_language", "Name_16"), 9, 901, 7, 9, "icon_TeaWine_lanlingmeijiu", "bigIcon_TeaWine_lanlingmeijiu", LocalStringManager.GetConfig("TeaWine_language", "Desc_16"), LocalStringManager.GetConfig("TeaWine_language", "FunctionDesc_16"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 100, 21150, 5, 16, 9000, 8, allowRandomCreate: true, 15, isSpecial: false, 0, 36, 39, new List<int>(), 1, 1800, 1, 60, 125, 125, 125, 125, 0, 0, -125, -125, -125, -125, 0, 0, 55, 0, 0, 68, 0));
		_dataArray.Add(new TeaWineItem(17, LocalStringManager.GetConfig("TeaWine_language", "Name_17"), 9, 901, 8, 9, "icon_TeaWine_dukangjiu", "bigIcon_TeaWine_dukangjiu", LocalStringManager.GetConfig("TeaWine_language", "Desc_17"), LocalStringManager.GetConfig("TeaWine_language", "FunctionDesc_17"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 100, 30750, 6, 18, 10800, 8, allowRandomCreate: true, 10, isSpecial: false, 0, 36, 39, new List<int>(), 1, 2000, 1, 60, 150, 150, 150, 150, 0, 0, -150, -150, -150, -150, 0, 0, 60, 0, 0, 88, 0));
		_dataArray.Add(new TeaWineItem(18, LocalStringManager.GetConfig("TeaWine_language", "Name_18"), 9, 900, 0, 18, "icon_TeaWine_puercha", "bigIcon_TeaWine_puercha", LocalStringManager.GetConfig("TeaWine_language", "Desc_18"), LocalStringManager.GetConfig("TeaWine_language", "FunctionDesc_18"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 40, 150, 0, 2, 600, 3, allowRandomCreate: true, 50, isSpecial: false, 0, 36, 36, new List<int>(), 1, -400, 1, 60, 0, 0, 0, 0, -50, -50, 0, 0, 0, 0, 50, 50, 0, 20, 20, 8, -1));
		_dataArray.Add(new TeaWineItem(19, LocalStringManager.GetConfig("TeaWine_language", "Name_19"), 9, 900, 1, 18, "icon_TeaWine_luyuanmaojian", "bigIcon_TeaWine_luyuanmaojian", LocalStringManager.GetConfig("TeaWine_language", "Desc_19"), LocalStringManager.GetConfig("TeaWine_language", "FunctionDesc_19"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 40, 300, 0, 4, 1200, 4, allowRandomCreate: true, 45, isSpecial: false, 0, 36, 36, new List<int>(), 1, -600, 1, 60, 0, 0, 0, 0, -55, -55, 0, 0, 0, 0, 55, 55, 0, 25, 40, 12, -1));
		_dataArray.Add(new TeaWineItem(20, LocalStringManager.GetConfig("TeaWine_language", "Name_20"), 9, 900, 2, 18, "icon_TeaWine_wuyiyancha", "bigIcon_TeaWine_wuyiyancha", LocalStringManager.GetConfig("TeaWine_language", "Desc_20"), LocalStringManager.GetConfig("TeaWine_language", "FunctionDesc_20"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 40, 900, 0, 6, 1800, 5, allowRandomCreate: true, 40, isSpecial: false, 0, 36, 36, new List<int>(), 1, -800, 1, 60, 0, 0, 0, 0, -60, -60, 0, 0, 0, 0, 60, 60, 0, 30, 60, 16, -1));
		_dataArray.Add(new TeaWineItem(21, LocalStringManager.GetConfig("TeaWine_language", "Name_21"), 9, 900, 3, 18, "icon_TeaWine_junshanyinzhen", "bigIcon_TeaWine_junshanyinzhen", LocalStringManager.GetConfig("TeaWine_language", "Desc_21"), LocalStringManager.GetConfig("TeaWine_language", "FunctionDesc_21"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 40, 2250, 1, 8, 3000, 6, allowRandomCreate: true, 35, isSpecial: false, 0, 36, 36, new List<int>(), 1, -1000, 1, 60, 0, 0, 0, 0, -70, -70, 0, 0, 0, 0, 70, 70, 0, 35, 90, 24, -1));
		_dataArray.Add(new TeaWineItem(22, LocalStringManager.GetConfig("TeaWine_language", "Name_22"), 9, 900, 4, 18, "icon_TeaWine_qimenhongcha", "bigIcon_TeaWine_qimenhongcha", LocalStringManager.GetConfig("TeaWine_language", "Desc_22"), LocalStringManager.GetConfig("TeaWine_language", "FunctionDesc_22"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 40, 4650, 2, 10, 4200, 7, allowRandomCreate: true, 30, isSpecial: false, 0, 36, 36, new List<int>(), 1, -1200, 1, 60, 0, 0, 0, 0, -80, -80, 0, 0, 0, 0, 80, 80, 0, 40, 120, 32, -1));
		_dataArray.Add(new TeaWineItem(23, LocalStringManager.GetConfig("TeaWine_language", "Name_23"), 9, 900, 5, 18, "icon_TeaWine_jinguagongcha", "bigIcon_TeaWine_jinguagongcha", LocalStringManager.GetConfig("TeaWine_language", "Desc_23"), LocalStringManager.GetConfig("TeaWine_language", "FunctionDesc_23"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 40, 8400, 3, 12, 5400, 7, allowRandomCreate: true, 25, isSpecial: false, 0, 36, 36, new List<int>(), 1, -1400, 1, 60, 0, 0, 0, 0, -90, -90, 0, 0, 0, 0, 90, 90, 0, 45, 150, 40, -1));
		_dataArray.Add(new TeaWineItem(24, LocalStringManager.GetConfig("TeaWine_language", "Name_24"), 9, 900, 6, 18, "icon_TeaWine_guzhuzisun", "bigIcon_TeaWine_guzhuzisun", LocalStringManager.GetConfig("TeaWine_language", "Desc_24"), LocalStringManager.GetConfig("TeaWine_language", "FunctionDesc_24"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 40, 13800, 4, 14, 7200, 8, allowRandomCreate: true, 20, isSpecial: false, 0, 36, 36, new List<int>(), 1, -1600, 1, 60, 0, 0, 0, 0, -105, -105, 0, 0, 0, 0, 105, 105, 0, 50, 190, 52, -1));
		_dataArray.Add(new TeaWineItem(25, LocalStringManager.GetConfig("TeaWine_language", "Name_25"), 9, 900, 7, 18, "icon_TeaWine_dahongpao", "bigIcon_TeaWine_dahongpao", LocalStringManager.GetConfig("TeaWine_language", "Desc_25"), LocalStringManager.GetConfig("TeaWine_language", "FunctionDesc_25"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 40, 21150, 5, 16, 9000, 8, allowRandomCreate: true, 15, isSpecial: false, 0, 36, 36, new List<int>(), 1, -1800, 1, 60, 0, 0, 0, 0, -125, -125, 0, 0, 0, 0, 125, 125, 0, 55, 240, 68, -1));
		_dataArray.Add(new TeaWineItem(26, LocalStringManager.GetConfig("TeaWine_language", "Name_26"), 9, 900, 8, 18, "icon_TeaWine_mengdinghuangya", "bigIcon_TeaWine_mengdinghuangya", LocalStringManager.GetConfig("TeaWine_language", "Desc_26"), LocalStringManager.GetConfig("TeaWine_language", "FunctionDesc_26"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 40, 30750, 6, 18, 10800, 8, allowRandomCreate: true, 10, isSpecial: false, 0, 36, 36, new List<int>(), 1, -2000, 1, 60, 0, 0, 0, 0, -150, -150, 0, 0, 0, 0, 150, 150, 0, 60, 300, 88, -1));
		_dataArray.Add(new TeaWineItem(27, LocalStringManager.GetConfig("TeaWine_language", "Name_27"), 9, 900, 0, 27, "icon_TeaWine_zhuyeqingcha", "bigIcon_TeaWine_zhuyeqingcha", LocalStringManager.GetConfig("TeaWine_language", "Desc_27"), LocalStringManager.GetConfig("TeaWine_language", "FunctionDesc_27"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 40, 150, 0, 2, 600, 3, allowRandomCreate: true, 50, isSpecial: false, 0, 36, 36, new List<int>(), 1, -400, 1, 60, -50, -50, -50, -50, 0, 0, 50, 50, 50, 50, 0, 0, 0, 20, 20, 8, -1));
		_dataArray.Add(new TeaWineItem(28, LocalStringManager.GetConfig("TeaWine_language", "Name_28"), 9, 900, 1, 27, "icon_TeaWine_douyunmaojian", "bigIcon_TeaWine_douyunmaojian", LocalStringManager.GetConfig("TeaWine_language", "Desc_28"), LocalStringManager.GetConfig("TeaWine_language", "FunctionDesc_28"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 40, 300, 0, 4, 1200, 4, allowRandomCreate: true, 45, isSpecial: false, 0, 36, 36, new List<int>(), 1, -600, 1, 60, -55, -55, -55, -55, 0, 0, 55, 55, 55, 55, 0, 0, 0, 25, 40, 12, -1));
		_dataArray.Add(new TeaWineItem(29, LocalStringManager.GetConfig("TeaWine_language", "Name_29"), 9, 900, 2, 27, "icon_TeaWine_liuanguapian", "bigIcon_TeaWine_liuanguapian", LocalStringManager.GetConfig("TeaWine_language", "Desc_29"), LocalStringManager.GetConfig("TeaWine_language", "FunctionDesc_29"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 40, 900, 0, 6, 1800, 5, allowRandomCreate: true, 40, isSpecial: false, 0, 36, 36, new List<int>(), 1, -800, 1, 60, -60, -60, -60, -60, 0, 0, 60, 60, 60, 60, 0, 0, 0, 30, 60, 16, -1));
		_dataArray.Add(new TeaWineItem(30, LocalStringManager.GetConfig("TeaWine_language", "Name_30"), 9, 900, 3, 27, "icon_TeaWine_xinyangmaojian", "bigIcon_TeaWine_xinyangmaojian", LocalStringManager.GetConfig("TeaWine_language", "Desc_30"), LocalStringManager.GetConfig("TeaWine_language", "FunctionDesc_30"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 40, 2250, 1, 8, 3000, 6, allowRandomCreate: true, 35, isSpecial: false, 0, 36, 36, new List<int>(), 1, -1000, 1, 60, -70, -70, -70, -70, 0, 0, 70, 70, 70, 70, 0, 0, 0, 35, 90, 24, -1));
		_dataArray.Add(new TeaWineItem(31, LocalStringManager.GetConfig("TeaWine_language", "Name_31"), 9, 900, 4, 27, "icon_TeaWine_lushanyunwucha", "bigIcon_TeaWine_lushanyunwucha", LocalStringManager.GetConfig("TeaWine_language", "Desc_31"), LocalStringManager.GetConfig("TeaWine_language", "FunctionDesc_31"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 40, 4650, 2, 10, 4200, 7, allowRandomCreate: true, 30, isSpecial: false, 0, 36, 36, new List<int>(), 1, -1200, 1, 60, -80, -80, -80, -80, 0, 0, 80, 80, 80, 80, 0, 0, 0, 40, 120, 32, -1));
		_dataArray.Add(new TeaWineItem(32, LocalStringManager.GetConfig("TeaWine_language", "Name_32"), 9, 900, 5, 27, "icon_TeaWine_biluochun", "bigIcon_TeaWine_biluochun", LocalStringManager.GetConfig("TeaWine_language", "Desc_32"), LocalStringManager.GetConfig("TeaWine_language", "FunctionDesc_32"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 40, 8400, 3, 12, 5400, 7, allowRandomCreate: true, 25, isSpecial: false, 0, 36, 36, new List<int>(), 1, -1400, 1, 60, -90, -90, -90, -90, 0, 0, 90, 90, 90, 90, 0, 0, 0, 45, 150, 40, -1));
		_dataArray.Add(new TeaWineItem(33, LocalStringManager.GetConfig("TeaWine_language", "Name_33"), 9, 900, 6, 27, "icon_TeaWine_xihulongjingcha", "bigIcon_TeaWine_xihulongjingcha", LocalStringManager.GetConfig("TeaWine_language", "Desc_33"), LocalStringManager.GetConfig("TeaWine_language", "FunctionDesc_33"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 40, 13800, 4, 14, 7200, 8, allowRandomCreate: true, 20, isSpecial: false, 0, 36, 36, new List<int>(), 1, -1600, 1, 60, -105, -105, -105, -105, 0, 0, 105, 105, 105, 105, 0, 0, 0, 50, 190, 52, -1));
		_dataArray.Add(new TeaWineItem(34, LocalStringManager.GetConfig("TeaWine_language", "Name_34"), 9, 900, 7, 27, "icon_TeaWine_fangshanluya", "bigIcon_TeaWine_fangshanluya", LocalStringManager.GetConfig("TeaWine_language", "Desc_34"), LocalStringManager.GetConfig("TeaWine_language", "FunctionDesc_34"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 40, 21150, 5, 16, 9000, 8, allowRandomCreate: true, 15, isSpecial: false, 0, 36, 36, new List<int>(), 1, -1800, 1, 60, -125, -125, -125, -125, 0, 0, 125, 125, 125, 125, 0, 0, 0, 55, 240, 68, -1));
		_dataArray.Add(new TeaWineItem(35, LocalStringManager.GetConfig("TeaWine_language", "Name_35"), 9, 900, 8, 27, "icon_TeaWine_mengdingganlu", "bigIcon_TeaWine_mengdingganlu", LocalStringManager.GetConfig("TeaWine_language", "Desc_35"), LocalStringManager.GetConfig("TeaWine_language", "FunctionDesc_35"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: true, repairable: false, inheritable: true, 0, 40, 30750, 6, 18, 10800, 8, allowRandomCreate: true, 10, isSpecial: false, 0, 36, 36, new List<int>(), 1, -2000, 1, 60, -150, -150, -150, -150, 0, 0, 150, 150, 150, 150, 0, 0, 0, 60, 300, 88, -1));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<TeaWineItem>(36);
		CreateItems0();
	}

	public static int GetCharacterPropertyBonus(int key, ECharacterPropertyReferencedType property)
	{
		return Instance[key]?.GetCharacterPropertyBonusInt(property) ?? 0;
	}

	public static int GetCharacterPropertyBonus(short[] keys, ECharacterPropertyReferencedType property)
	{
		int sum = 0;
		int i = 0;
		for (int count = keys.Length; i < count; i++)
		{
			sum += Instance[keys[i]]?.GetCharacterPropertyBonusInt(property) ?? 0;
		}
		return sum;
	}

	public static int GetCharacterPropertyBonus(List<short> keys, ECharacterPropertyReferencedType property)
	{
		int sum = 0;
		int i = 0;
		for (int count = keys.Count; i < count; i++)
		{
			sum += Instance[keys[i]]?.GetCharacterPropertyBonusInt(property) ?? 0;
		}
		return sum;
	}

	public static int GetCharacterPropertyBonus(int[] keys, ECharacterPropertyReferencedType property)
	{
		int sum = 0;
		int i = 0;
		for (int count = keys.Length; i < count; i++)
		{
			sum += Instance[keys[i]]?.GetCharacterPropertyBonusInt(property) ?? 0;
		}
		return sum;
	}

	public static int GetCharacterPropertyBonus(List<int> keys, ECharacterPropertyReferencedType property)
	{
		int sum = 0;
		int i = 0;
		for (int count = keys.Count; i < count; i++)
		{
			sum += Instance[keys[i]]?.GetCharacterPropertyBonusInt(property) ?? 0;
		}
		return sum;
	}
}
