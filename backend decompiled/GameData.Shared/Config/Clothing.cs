using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class Clothing : ConfigData<ClothingItem, short>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 山野竖褐
		/// </summary>
		public const short GeneralCombat0 = 0;

		/// <summary>
		/// 猎户装
		/// </summary>
		public const short GeneralCombat1 = 1;

		/// <summary>
		/// 戎服短打
		/// </summary>
		public const short GeneralCombat2 = 2;

		/// <summary>
		/// 练功服
		/// </summary>
		public const short GeneralCombat3 = 3;

		/// <summary>
		/// 锦衫
		/// </summary>
		public const short GeneralCombat4 = 4;

		/// <summary>
		/// 天师大氅
		/// </summary>
		public const short GeneralCombat5 = 5;

		/// <summary>
		/// 纳宝锦裘
		/// </summary>
		public const short GeneralCombat6 = 6;

		/// <summary>
		/// 将军披挂
		/// </summary>
		public const short GeneralCombat7 = 7;

		/// <summary>
		/// 绛纱金装
		/// </summary>
		public const short GeneralCombat8 = 8;

		/// <summary>
		/// 百衲衣
		/// </summary>
		public const short GeneralLife0 = 9;

		/// <summary>
		/// 布衣素裳
		/// </summary>
		public const short GeneralLife1 = 10;

		/// <summary>
		/// 劲衣
		/// </summary>
		public const short GeneralLife2 = 11;

		/// <summary>
		/// 坏色僧衣
		/// </summary>
		public const short GeneralLife3 = 12;

		/// <summary>
		/// 纹绣深衣
		/// </summary>
		public const short GeneralLife4 = 13;

		/// <summary>
		/// 老君袍
		/// </summary>
		public const short GeneralLife5 = 14;

		/// <summary>
		/// 福禄锦衣
		/// </summary>
		public const short GeneralLife6 = 15;

		/// <summary>
		/// 玉带紫袍
		/// </summary>
		public const short GeneralLife7 = 16;

		/// <summary>
		/// 衮龙黄袍
		/// </summary>
		public const short GeneralLife8 = 17;

		/// <summary>
		/// 武当_4
		/// </summary>
		public const short Wudang4 = 30;

		/// <summary>
		/// 然山_1
		/// </summary>
		public const short Ranshan1 = 37;

		/// <summary>
		/// 襁褓
		/// </summary>
		public const short BabyClothing = 64;

		/// <summary>
		/// 童衣
		/// </summary>
		public const short ChildClothing = 65;

		/// <summary>
		/// 相枢爪牙_1
		/// </summary>
		public const short xiangshuMinion1 = 66;

		/// <summary>
		/// 相枢爪牙_2
		/// </summary>
		public const short xiangshuMinion2 = 67;

		/// <summary>
		/// 相枢爪牙_3
		/// </summary>
		public const short xiangshuMinion3 = 68;

		/// <summary>
		/// 相枢爪牙_100
		/// </summary>
		public const short SkeletonLow = 69;

		/// <summary>
		/// 相枢爪牙_101
		/// </summary>
		public const short SkeletonMid = 70;

		/// <summary>
		/// 相枢爪牙_102
		/// </summary>
		public const short SkeletonHigh = 71;

		/// <summary>
		/// 霸戈衣
		/// </summary>
		public const short Bug = 72;

		/// <summary>
		/// 银导衣
		/// </summary>
		public const short Tutorial = 73;

		/// <summary>
		/// 斑皓衣
		/// </summary>
		public const short ISBNCloth = 74;

		/// <summary>
		/// 白蛟鳞衣
		/// </summary>
		public const short DLCJiaoWhite = 75;

		/// <summary>
		/// 黑蛟鳞衣
		/// </summary>
		public const short DLCJiaoBlack = 76;

		/// <summary>
		/// 青蛟鳞衣
		/// </summary>
		public const short DLCJiaoGreen = 77;

		/// <summary>
		/// 赤蛟鳞衣
		/// </summary>
		public const short DLCJiaoRed = 78;

		/// <summary>
		/// 黄蛟鳞衣
		/// </summary>
		public const short DLCJiaoYellow = 79;

		/// <summary>
		/// 烛月无双衣
		/// </summary>
		public const short DLCChineseNewYear = 80;

		/// <summary>
		/// 碧霄灵蛇衣
		/// </summary>
		public const short DLCYearOfSnakeCloth = 92;

		/// <summary>
		/// 青霄灵蛇衣
		/// </summary>
		public const short DLCYearOfSnakeClothBlue = 93;

		/// <summary>
		/// 琼霄灵蛇衣
		/// </summary>
		public const short DLCYearOfSnakeClothYellow = 94;

		/// <summary>
		/// 血褓1
		/// </summary>
		public const short ProtagonistFeatureClothing1 = 95;

		/// <summary>
		/// 血褓2
		/// </summary>
		public const short ProtagonistFeatureClothing2 = 96;

		/// <summary>
		/// 香驹衣
		/// </summary>
		public const short DLCYearOfHorseCloth = 97;

		/// <summary>
		/// 无念众
		/// </summary>
		public const short NoMindGuyCloth = 101;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 山野竖褐
		/// </summary>
		public static ClothingItem GeneralCombat0 => Instance[(short)0];

		/// <summary>
		/// 猎户装
		/// </summary>
		public static ClothingItem GeneralCombat1 => Instance[(short)1];

		/// <summary>
		/// 戎服短打
		/// </summary>
		public static ClothingItem GeneralCombat2 => Instance[(short)2];

		/// <summary>
		/// 练功服
		/// </summary>
		public static ClothingItem GeneralCombat3 => Instance[(short)3];

		/// <summary>
		/// 锦衫
		/// </summary>
		public static ClothingItem GeneralCombat4 => Instance[(short)4];

		/// <summary>
		/// 天师大氅
		/// </summary>
		public static ClothingItem GeneralCombat5 => Instance[(short)5];

		/// <summary>
		/// 纳宝锦裘
		/// </summary>
		public static ClothingItem GeneralCombat6 => Instance[(short)6];

		/// <summary>
		/// 将军披挂
		/// </summary>
		public static ClothingItem GeneralCombat7 => Instance[(short)7];

		/// <summary>
		/// 绛纱金装
		/// </summary>
		public static ClothingItem GeneralCombat8 => Instance[(short)8];

		/// <summary>
		/// 百衲衣
		/// </summary>
		public static ClothingItem GeneralLife0 => Instance[(short)9];

		/// <summary>
		/// 布衣素裳
		/// </summary>
		public static ClothingItem GeneralLife1 => Instance[(short)10];

		/// <summary>
		/// 劲衣
		/// </summary>
		public static ClothingItem GeneralLife2 => Instance[(short)11];

		/// <summary>
		/// 坏色僧衣
		/// </summary>
		public static ClothingItem GeneralLife3 => Instance[(short)12];

		/// <summary>
		/// 纹绣深衣
		/// </summary>
		public static ClothingItem GeneralLife4 => Instance[(short)13];

		/// <summary>
		/// 老君袍
		/// </summary>
		public static ClothingItem GeneralLife5 => Instance[(short)14];

		/// <summary>
		/// 福禄锦衣
		/// </summary>
		public static ClothingItem GeneralLife6 => Instance[(short)15];

		/// <summary>
		/// 玉带紫袍
		/// </summary>
		public static ClothingItem GeneralLife7 => Instance[(short)16];

		/// <summary>
		/// 衮龙黄袍
		/// </summary>
		public static ClothingItem GeneralLife8 => Instance[(short)17];

		/// <summary>
		/// 武当_4
		/// </summary>
		public static ClothingItem Wudang4 => Instance[(short)30];

		/// <summary>
		/// 然山_1
		/// </summary>
		public static ClothingItem Ranshan1 => Instance[(short)37];

		/// <summary>
		/// 襁褓
		/// </summary>
		public static ClothingItem BabyClothing => Instance[(short)64];

		/// <summary>
		/// 童衣
		/// </summary>
		public static ClothingItem ChildClothing => Instance[(short)65];

		/// <summary>
		/// 相枢爪牙_1
		/// </summary>
		public static ClothingItem xiangshuMinion1 => Instance[(short)66];

		/// <summary>
		/// 相枢爪牙_2
		/// </summary>
		public static ClothingItem xiangshuMinion2 => Instance[(short)67];

		/// <summary>
		/// 相枢爪牙_3
		/// </summary>
		public static ClothingItem xiangshuMinion3 => Instance[(short)68];

		/// <summary>
		/// 相枢爪牙_100
		/// </summary>
		public static ClothingItem SkeletonLow => Instance[(short)69];

		/// <summary>
		/// 相枢爪牙_101
		/// </summary>
		public static ClothingItem SkeletonMid => Instance[(short)70];

		/// <summary>
		/// 相枢爪牙_102
		/// </summary>
		public static ClothingItem SkeletonHigh => Instance[(short)71];

		/// <summary>
		/// 霸戈衣
		/// </summary>
		public static ClothingItem Bug => Instance[(short)72];

		/// <summary>
		/// 银导衣
		/// </summary>
		public static ClothingItem Tutorial => Instance[(short)73];

		/// <summary>
		/// 斑皓衣
		/// </summary>
		public static ClothingItem ISBNCloth => Instance[(short)74];

		/// <summary>
		/// 白蛟鳞衣
		/// </summary>
		public static ClothingItem DLCJiaoWhite => Instance[(short)75];

		/// <summary>
		/// 黑蛟鳞衣
		/// </summary>
		public static ClothingItem DLCJiaoBlack => Instance[(short)76];

		/// <summary>
		/// 青蛟鳞衣
		/// </summary>
		public static ClothingItem DLCJiaoGreen => Instance[(short)77];

		/// <summary>
		/// 赤蛟鳞衣
		/// </summary>
		public static ClothingItem DLCJiaoRed => Instance[(short)78];

		/// <summary>
		/// 黄蛟鳞衣
		/// </summary>
		public static ClothingItem DLCJiaoYellow => Instance[(short)79];

		/// <summary>
		/// 烛月无双衣
		/// </summary>
		public static ClothingItem DLCChineseNewYear => Instance[(short)80];

		/// <summary>
		/// 碧霄灵蛇衣
		/// </summary>
		public static ClothingItem DLCYearOfSnakeCloth => Instance[(short)92];

		/// <summary>
		/// 青霄灵蛇衣
		/// </summary>
		public static ClothingItem DLCYearOfSnakeClothBlue => Instance[(short)93];

		/// <summary>
		/// 琼霄灵蛇衣
		/// </summary>
		public static ClothingItem DLCYearOfSnakeClothYellow => Instance[(short)94];

		/// <summary>
		/// 血褓1
		/// </summary>
		public static ClothingItem ProtagonistFeatureClothing1 => Instance[(short)95];

		/// <summary>
		/// 血褓2
		/// </summary>
		public static ClothingItem ProtagonistFeatureClothing2 => Instance[(short)96];

		/// <summary>
		/// 香驹衣
		/// </summary>
		public static ClothingItem DLCYearOfHorseCloth => Instance[(short)97];

		/// <summary>
		/// 无念众
		/// </summary>
		public static ClothingItem NoMindGuyCloth => Instance[(short)101];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static Clothing Instance = new Clothing();

	private readonly HashSet<string> RequiredFields = new HashSet<string>
	{
		"Name", "ItemSubType", "GroupId", "Desc", "FunctionDesc", "ResourceType", "MakeItemSubType", "TaskLock", "EquipmentEffectId", "SmallVillageDesc",
		"TemplateId", "Grade", "Icon", "MaxDurability", "BaseWeight", "BaseHappinessChange", "DropRate", "DisplayId", "DlcName"
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
		_dataArray.Add(new ClothingItem(0, LocalStringManager.GetConfig("Clothing_language", "Name_0"), 3, 300, 0, 0, "icon_Clothing_shanyeshuhe", LocalStringManager.GetConfig("Clothing_language", "Desc_0"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_0"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 10, 150, 0, 1, 600, 3, allowRandomCreate: true, 45, isSpecial: false, 4, 12, 176, new List<int>(), 2, -1, 1, 2, keepOnPassing: false, 10, 1, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_0"), 0));
		_dataArray.Add(new ClothingItem(1, LocalStringManager.GetConfig("Clothing_language", "Name_1"), 3, 300, 1, 0, "icon_Clothing_shanyeshuhe", LocalStringManager.GetConfig("Clothing_language", "Desc_1"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_1"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 30, 300, 0, 2, 1200, 4, allowRandomCreate: true, 40, isSpecial: false, 4, 12, 176, new List<int>(), 2, -1, 2, 2, keepOnPassing: false, 30, 1, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_1"), 0));
		_dataArray.Add(new ClothingItem(2, LocalStringManager.GetConfig("Clothing_language", "Name_2"), 3, 300, 2, 0, "icon_Clothing_shanyeshuhe", LocalStringManager.GetConfig("Clothing_language", "Desc_2"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_2"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 10, 900, 0, 3, 1800, 5, allowRandomCreate: true, 35, isSpecial: false, 4, 12, 176, new List<int>(), 2, -1, 3, 2, keepOnPassing: false, 60, 1, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_2"), 0));
		_dataArray.Add(new ClothingItem(3, LocalStringManager.GetConfig("Clothing_language", "Name_3"), 3, 300, 3, 0, "icon_Clothing_liangongfu", LocalStringManager.GetConfig("Clothing_language", "Desc_3"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_3"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 10, 2250, 1, 4, 3000, 6, allowRandomCreate: true, 30, isSpecial: false, 4, 12, 176, new List<int>(), 2, -1, 4, 2, keepOnPassing: false, 100, 1, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_3"), 0));
		_dataArray.Add(new ClothingItem(4, LocalStringManager.GetConfig("Clothing_language", "Name_4"), 3, 300, 4, 0, "icon_Clothing_liangongfu", LocalStringManager.GetConfig("Clothing_language", "Desc_4"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_4"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 20, 4650, 2, 5, 4200, 7, allowRandomCreate: true, 25, isSpecial: false, 4, 12, 176, new List<int>(), 2, -1, 5, 2, keepOnPassing: false, 150, 1, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_4"), 0));
		_dataArray.Add(new ClothingItem(5, LocalStringManager.GetConfig("Clothing_language", "Name_5"), 3, 300, 5, 0, "icon_Clothing_liangongfu", LocalStringManager.GetConfig("Clothing_language", "Desc_5"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_5"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 30, 8400, 3, 6, 5400, 7, allowRandomCreate: true, 20, isSpecial: false, 4, 12, 176, new List<int>(), 2, -1, 6, 2, keepOnPassing: false, 210, 1, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_5"), 0));
		_dataArray.Add(new ClothingItem(6, LocalStringManager.GetConfig("Clothing_language", "Name_6"), 3, 300, 6, 0, "icon_Clothing_nabaojinqiu", LocalStringManager.GetConfig("Clothing_language", "Desc_6"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_6"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 30, 13800, 4, 7, 7200, 8, allowRandomCreate: true, 15, isSpecial: false, 4, 12, 176, new List<int>(), 2, -1, 7, 2, keepOnPassing: false, 280, 1, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_6"), 0));
		_dataArray.Add(new ClothingItem(7, LocalStringManager.GetConfig("Clothing_language", "Name_7"), 3, 300, 7, 0, "icon_Clothing_nabaojinqiu", LocalStringManager.GetConfig("Clothing_language", "Desc_7"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_7"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 150, 21150, 5, 8, 9000, 8, allowRandomCreate: true, 10, isSpecial: false, 4, 12, 176, new List<int>(), 2, -1, 8, 2, keepOnPassing: false, 360, 1, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_7"), 0));
		_dataArray.Add(new ClothingItem(8, LocalStringManager.GetConfig("Clothing_language", "Name_8"), 3, 300, 8, 0, "icon_Clothing_nabaojinqiu", LocalStringManager.GetConfig("Clothing_language", "Desc_8"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_8"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 40, 30750, 6, 9, 10800, 8, allowRandomCreate: true, 5, isSpecial: false, 4, 12, 176, new List<int>(), 2, -1, 9, 2, keepOnPassing: false, 450, 1, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_8"), 0));
		_dataArray.Add(new ClothingItem(9, LocalStringManager.GetConfig("Clothing_language", "Name_9"), 3, 300, 0, 9, "icon_Clothing_shanyeshuhe", LocalStringManager.GetConfig("Clothing_language", "Desc_9"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_9"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 10, 150, 0, 1, 600, 3, allowRandomCreate: true, 45, isSpecial: false, 4, 12, 177, new List<int>(), 2, -1, 10, 2, keepOnPassing: false, 10, 1, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_9"), 0));
		_dataArray.Add(new ClothingItem(10, LocalStringManager.GetConfig("Clothing_language", "Name_10"), 3, 300, 1, 9, "icon_Clothing_shanyeshuhe", LocalStringManager.GetConfig("Clothing_language", "Desc_10"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_10"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 20, 300, 0, 2, 1200, 4, allowRandomCreate: true, 40, isSpecial: false, 4, 12, 177, new List<int>(), 2, -1, 11, 2, keepOnPassing: false, 30, 1, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_10"), 0));
		_dataArray.Add(new ClothingItem(11, LocalStringManager.GetConfig("Clothing_language", "Name_11"), 3, 300, 2, 9, "icon_Clothing_shanyeshuhe", LocalStringManager.GetConfig("Clothing_language", "Desc_11"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_11"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 10, 900, 0, 3, 1800, 5, allowRandomCreate: true, 35, isSpecial: false, 4, 12, 177, new List<int>(), 2, -1, 12, 2, keepOnPassing: false, 60, 1, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_11"), 0));
		_dataArray.Add(new ClothingItem(12, LocalStringManager.GetConfig("Clothing_language", "Name_12"), 3, 300, 3, 9, "icon_Clothing_liangongfu", LocalStringManager.GetConfig("Clothing_language", "Desc_12"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_12"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 10, 2250, 1, 4, 3000, 6, allowRandomCreate: true, 30, isSpecial: false, 4, 12, 177, new List<int>(), 2, -1, 13, 2, keepOnPassing: false, 100, 1, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_12"), 0));
		_dataArray.Add(new ClothingItem(13, LocalStringManager.GetConfig("Clothing_language", "Name_13"), 3, 300, 4, 9, "icon_Clothing_liangongfu", LocalStringManager.GetConfig("Clothing_language", "Desc_13"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_13"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 30, 4650, 2, 5, 4200, 7, allowRandomCreate: true, 25, isSpecial: false, 4, 12, 177, new List<int>(), 2, -1, 14, 2, keepOnPassing: false, 150, 1, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_13"), 0));
		_dataArray.Add(new ClothingItem(14, LocalStringManager.GetConfig("Clothing_language", "Name_14"), 3, 300, 5, 9, "icon_Clothing_liangongfu", LocalStringManager.GetConfig("Clothing_language", "Desc_14"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_14"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 30, 8400, 3, 6, 5400, 7, allowRandomCreate: true, 20, isSpecial: false, 4, 12, 177, new List<int>(), 2, -1, 15, 2, keepOnPassing: false, 210, 1, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_14"), 0));
		_dataArray.Add(new ClothingItem(15, LocalStringManager.GetConfig("Clothing_language", "Name_15"), 3, 300, 6, 9, "icon_Clothing_nabaojinqiu", LocalStringManager.GetConfig("Clothing_language", "Desc_15"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_15"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 40, 13800, 4, 7, 7200, 8, allowRandomCreate: true, 15, isSpecial: false, 4, 12, 177, new List<int>(), 2, -1, 16, 2, keepOnPassing: false, 280, 1, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_15"), 0));
		_dataArray.Add(new ClothingItem(16, LocalStringManager.GetConfig("Clothing_language", "Name_16"), 3, 300, 7, 9, "icon_Clothing_nabaojinqiu", LocalStringManager.GetConfig("Clothing_language", "Desc_16"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_16"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 50, 21150, 5, 8, 9000, 8, allowRandomCreate: true, 10, isSpecial: false, 4, 12, 177, new List<int>(), 2, -1, 17, 2, keepOnPassing: false, 360, 1, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_16"), 0));
		_dataArray.Add(new ClothingItem(17, LocalStringManager.GetConfig("Clothing_language", "Name_17"), 3, 300, 8, 9, "icon_Clothing_nabaojinqiu", LocalStringManager.GetConfig("Clothing_language", "Desc_17"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_17"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 60, 30750, 6, 9, 10800, 8, allowRandomCreate: true, 5, isSpecial: false, 4, 12, 177, new List<int>(), 2, -1, 18, 2, keepOnPassing: false, 450, 1, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_17"), 0));
		_dataArray.Add(new ClothingItem(18, LocalStringManager.GetConfig("Clothing_language", "Name_18"), 3, 300, 2, 18, "icon_Clothing_shaolinsengyi", LocalStringManager.GetConfig("Clothing_language", "Desc_18"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_18"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 10, 900, 0, 3, 900, 5, allowRandomCreate: true, 35, isSpecial: false, 4, 12, -1, new List<int>(), 2, -1, 19, 2, keepOnPassing: false, 60, 2, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_18"), 0));
		_dataArray.Add(new ClothingItem(19, LocalStringManager.GetConfig("Clothing_language", "Name_19"), 3, 300, 4, 18, "icon_Clothing_shaolinluohanpao", LocalStringManager.GetConfig("Clothing_language", "Desc_19"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_19"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 20, 4650, 2, 5, 2100, 7, allowRandomCreate: true, 25, isSpecial: false, 4, 12, -1, new List<int>(), 2, -1, 20, 2, keepOnPassing: false, 150, 2, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_19"), 0));
		_dataArray.Add(new ClothingItem(20, LocalStringManager.GetConfig("Clothing_language", "Name_20"), 3, 300, 6, 18, "icon_Clothing_shaolinjiasha", LocalStringManager.GetConfig("Clothing_language", "Desc_20"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_20"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 30, 13800, 4, 7, 3600, 8, allowRandomCreate: true, 15, isSpecial: false, 4, 12, -1, new List<int>(), 2, -1, 21, 2, keepOnPassing: false, 280, 2, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_20"), 0));
		_dataArray.Add(new ClothingItem(21, LocalStringManager.GetConfig("Clothing_language", "Name_21"), 3, 300, 2, 21, "icon_Clothing_emeixiupao", LocalStringManager.GetConfig("Clothing_language", "Desc_21"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_21"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 20, 900, 0, 3, 900, 5, allowRandomCreate: true, 35, isSpecial: false, 4, 12, -1, new List<int>(), 2, -1, 22, 2, keepOnPassing: false, 60, 2, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_21"), 0));
		_dataArray.Add(new ClothingItem(22, LocalStringManager.GetConfig("Clothing_language", "Name_22"), 3, 300, 4, 21, "icon_Clothing_emeijinyi", LocalStringManager.GetConfig("Clothing_language", "Desc_22"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_22"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 30, 4650, 2, 5, 2100, 7, allowRandomCreate: true, 25, isSpecial: false, 4, 12, -1, new List<int>(), 2, -1, 23, 2, keepOnPassing: false, 150, 2, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_22"), 0));
		_dataArray.Add(new ClothingItem(23, LocalStringManager.GetConfig("Clothing_language", "Name_23"), 3, 300, 6, 21, "icon_Clothing_emeibaolianyi", LocalStringManager.GetConfig("Clothing_language", "Desc_23"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_23"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 40, 13800, 4, 7, 3600, 8, allowRandomCreate: true, 15, isSpecial: false, 4, 12, -1, new List<int>(), 2, -1, 24, 2, keepOnPassing: false, 280, 2, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_23"), 0));
		_dataArray.Add(new ClothingItem(24, LocalStringManager.GetConfig("Clothing_language", "Name_24"), 3, 300, 2, 24, "icon_Clothing_yuzhenpi", LocalStringManager.GetConfig("Clothing_language", "Desc_24"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_24"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 20, 900, 0, 3, 900, 5, allowRandomCreate: true, 35, isSpecial: false, 4, 12, -1, new List<int>(), 2, -1, 25, 2, keepOnPassing: false, 60, 2, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_24"), 0));
		_dataArray.Add(new ClothingItem(25, LocalStringManager.GetConfig("Clothing_language", "Name_25"), 3, 300, 4, 24, "icon_Clothing_tacuipao", LocalStringManager.GetConfig("Clothing_language", "Desc_25"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_25"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 30, 4650, 2, 5, 2100, 7, allowRandomCreate: true, 25, isSpecial: false, 4, 12, -1, new List<int>(), 2, -1, 26, 2, keepOnPassing: false, 150, 2, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_25"), 0));
		_dataArray.Add(new ClothingItem(26, LocalStringManager.GetConfig("Clothing_language", "Name_26"), 3, 300, 6, 24, "icon_Clothing_qinghupigua", LocalStringManager.GetConfig("Clothing_language", "Desc_26"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_26"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 40, 13800, 4, 7, 3600, 8, allowRandomCreate: true, 15, isSpecial: false, 4, 12, -1, new List<int>(), 2, -1, 27, 2, keepOnPassing: false, 280, 2, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_26"), 0));
		_dataArray.Add(new ClothingItem(27, LocalStringManager.GetConfig("Clothing_language", "Name_27"), 3, 300, 2, 27, "icon_Clothing_wudangdaopao", LocalStringManager.GetConfig("Clothing_language", "Desc_27"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_27"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 20, 900, 0, 3, 900, 5, allowRandomCreate: true, 35, isSpecial: false, 4, 12, -1, new List<int>(), 2, -1, 28, 2, keepOnPassing: false, 60, 2, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_27"), 0));
		_dataArray.Add(new ClothingItem(28, LocalStringManager.GetConfig("Clothing_language", "Name_28"), 3, 300, 4, 27, "icon_Clothing_qingyangdaopao", LocalStringManager.GetConfig("Clothing_language", "Desc_28"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_28"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 40, 4650, 2, 5, 2100, 7, allowRandomCreate: true, 25, isSpecial: false, 4, 12, -1, new List<int>(), 2, -1, 29, 2, keepOnPassing: false, 150, 2, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_28"), 0));
		_dataArray.Add(new ClothingItem(29, LocalStringManager.GetConfig("Clothing_language", "Name_29"), 3, 300, 6, 27, "icon_Clothing_zhenwudaopao", LocalStringManager.GetConfig("Clothing_language", "Desc_29"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_29"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 60, 13800, 4, 7, 3600, 8, allowRandomCreate: true, 15, isSpecial: false, 4, 12, -1, new List<int>(), 2, -1, 30, 2, keepOnPassing: false, 280, 2, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_29"), 0));
		_dataArray.Add(new ClothingItem(30, LocalStringManager.GetConfig("Clothing_language", "Name_30"), 3, 300, 6, 27, "icon_Clothing_zhenwudaopao", LocalStringManager.GetConfig("Clothing_language", "Desc_30"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_30"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 60, 13800, 4, 7, 3600, 8, allowRandomCreate: true, 0, isSpecial: true, 4, 12, -1, new List<int>(), 2, -1, 31, 2, keepOnPassing: false, 280, 2, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_30"), 0));
		_dataArray.Add(new ClothingItem(31, LocalStringManager.GetConfig("Clothing_language", "Name_31"), 3, 300, 2, 31, "icon_Clothing_yuanshankuxingyi", LocalStringManager.GetConfig("Clothing_language", "Desc_31"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_31"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 10, 900, 0, 3, 900, 5, allowRandomCreate: true, 35, isSpecial: false, 4, 12, -1, new List<int>(), 2, -1, 32, 2, keepOnPassing: false, 60, 2, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_31"), 0));
		_dataArray.Add(new ClothingItem(32, LocalStringManager.GetConfig("Clothing_language", "Name_32"), 3, 300, 4, 31, "icon_Clothing_yuanshanhufayi", LocalStringManager.GetConfig("Clothing_language", "Desc_32"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_32"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 20, 4650, 2, 5, 2100, 7, allowRandomCreate: true, 25, isSpecial: false, 4, 12, -1, new List<int>(), 2, -1, 33, 2, keepOnPassing: false, 150, 2, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_32"), 0));
		_dataArray.Add(new ClothingItem(33, LocalStringManager.GetConfig("Clothing_language", "Name_33"), 3, 300, 6, 31, "icon_Clothing_yuanshanzunshipao", LocalStringManager.GetConfig("Clothing_language", "Desc_33"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_33"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 30, 13800, 4, 7, 3600, 8, allowRandomCreate: true, 15, isSpecial: false, 4, 12, -1, new List<int>(), 2, -1, 34, 2, keepOnPassing: false, 280, 2, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_33"), 0));
		_dataArray.Add(new ClothingItem(34, LocalStringManager.GetConfig("Clothing_language", "Name_34"), 3, 300, 2, 34, "icon_Clothing_shixianghushenjia", LocalStringManager.GetConfig("Clothing_language", "Desc_34"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_34"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 100, 900, 0, 3, 900, 5, allowRandomCreate: true, 35, isSpecial: false, 4, 12, -1, new List<int>(), 2, -1, 35, 2, keepOnPassing: false, 60, 2, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_34"), 0));
		_dataArray.Add(new ClothingItem(35, LocalStringManager.GetConfig("Clothing_language", "Name_35"), 3, 300, 4, 34, "icon_Clothing_shixiangbaizhanjia", LocalStringManager.GetConfig("Clothing_language", "Desc_35"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_35"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 200, 4650, 2, 5, 2100, 7, allowRandomCreate: true, 25, isSpecial: false, 4, 12, -1, new List<int>(), 2, -1, 36, 2, keepOnPassing: false, 150, 2, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_35"), 0));
		_dataArray.Add(new ClothingItem(36, LocalStringManager.GetConfig("Clothing_language", "Name_36"), 3, 300, 6, 34, "icon_Clothing_shiwangkai", LocalStringManager.GetConfig("Clothing_language", "Desc_36"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_36"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 300, 13800, 4, 7, 3600, 8, allowRandomCreate: true, 15, isSpecial: false, 4, 12, -1, new List<int>(), 2, -1, 37, 2, keepOnPassing: false, 280, 2, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_36"), 0));
		_dataArray.Add(new ClothingItem(37, LocalStringManager.GetConfig("Clothing_language", "Name_37"), 3, 300, 2, 37, "icon_Clothing_youfangyi", LocalStringManager.GetConfig("Clothing_language", "Desc_37"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_37"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 10, 900, 0, 3, 900, 5, allowRandomCreate: true, 35, isSpecial: false, 4, 12, -1, new List<int>(), 2, -1, 38, 2, keepOnPassing: false, 60, 2, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_37"), 0));
		_dataArray.Add(new ClothingItem(38, LocalStringManager.GetConfig("Clothing_language", "Name_38"), 3, 300, 4, 37, "icon_Clothing_wenxianshan", LocalStringManager.GetConfig("Clothing_language", "Desc_38"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_38"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 20, 4650, 2, 5, 2100, 7, allowRandomCreate: true, 25, isSpecial: false, 4, 12, -1, new List<int>(), 2, -1, 39, 2, keepOnPassing: false, 150, 2, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_38"), 0));
		_dataArray.Add(new ClothingItem(39, LocalStringManager.GetConfig("Clothing_language", "Name_39"), 3, 300, 6, 37, "icon_Clothing_wuchenpao", LocalStringManager.GetConfig("Clothing_language", "Desc_39"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_39"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 30, 13800, 4, 7, 3600, 8, allowRandomCreate: true, 15, isSpecial: false, 4, 12, -1, new List<int>(), 2, -1, 40, 2, keepOnPassing: false, 280, 2, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_39"), 0));
		_dataArray.Add(new ClothingItem(40, LocalStringManager.GetConfig("Clothing_language", "Name_40"), 3, 300, 2, 40, "icon_Clothing_xuannvsuyi", LocalStringManager.GetConfig("Clothing_language", "Desc_40"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_40"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 20, 900, 0, 3, 900, 5, allowRandomCreate: true, 35, isSpecial: false, 4, 12, -1, new List<int>(), 2, -1, 41, 2, keepOnPassing: false, 60, 2, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_40"), 0));
		_dataArray.Add(new ClothingItem(41, LocalStringManager.GetConfig("Clothing_language", "Name_41"), 3, 300, 4, 40, "icon_Clothing_xuannvlingqiu", LocalStringManager.GetConfig("Clothing_language", "Desc_41"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_41"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 30, 4650, 2, 5, 2100, 7, allowRandomCreate: true, 25, isSpecial: false, 4, 12, -1, new List<int>(), 2, -1, 42, 2, keepOnPassing: false, 150, 2, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_41"), 0));
		_dataArray.Add(new ClothingItem(42, LocalStringManager.GetConfig("Clothing_language", "Name_42"), 3, 300, 6, 40, "icon_Clothing_xuannvtianyi", LocalStringManager.GetConfig("Clothing_language", "Desc_42"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_42"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 40, 13800, 4, 7, 3600, 8, allowRandomCreate: true, 15, isSpecial: false, 4, 12, -1, new List<int>(), 2, -1, 43, 2, keepOnPassing: false, 280, 2, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_42"), 0));
		_dataArray.Add(new ClothingItem(43, LocalStringManager.GetConfig("Clothing_language", "Name_43"), 3, 300, 2, 43, "icon_Clothing_huogongzhuang", LocalStringManager.GetConfig("Clothing_language", "Desc_43"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_43"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 40, 900, 0, 3, 900, 5, allowRandomCreate: true, 35, isSpecial: false, 4, 12, -1, new List<int>(), 2, -1, 44, 2, keepOnPassing: false, 60, 2, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_43"), 0));
		_dataArray.Add(new ClothingItem(44, LocalStringManager.GetConfig("Clothing_language", "Name_44"), 3, 300, 4, 43, "icon_Clothing_mingshijinfu", LocalStringManager.GetConfig("Clothing_language", "Desc_44"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_44"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 60, 4650, 2, 5, 2100, 7, allowRandomCreate: true, 25, isSpecial: false, 4, 12, -1, new List<int>(), 2, -1, 45, 2, keepOnPassing: false, 150, 2, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_44"), 0));
		_dataArray.Add(new ClothingItem(45, LocalStringManager.GetConfig("Clothing_language", "Name_45"), 3, 300, 6, 43, "icon_Clothing_dajiangpao", LocalStringManager.GetConfig("Clothing_language", "Desc_45"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_45"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 80, 13800, 4, 7, 3600, 8, allowRandomCreate: true, 15, isSpecial: false, 4, 12, -1, new List<int>(), 2, -1, 46, 2, keepOnPassing: false, 280, 2, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_45"), 0));
		_dataArray.Add(new ClothingItem(46, LocalStringManager.GetConfig("Clothing_language", "Name_46"), 3, 300, 2, 46, "icon_Clothing_yaoshiduanqiu", LocalStringManager.GetConfig("Clothing_language", "Desc_46"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_46"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 50, 900, 0, 3, 900, 5, allowRandomCreate: true, 35, isSpecial: false, 4, 12, -1, new List<int>(), 2, -1, 47, 2, keepOnPassing: false, 60, 2, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_46"), 0));
		_dataArray.Add(new ClothingItem(47, LocalStringManager.GetConfig("Clothing_language", "Name_47"), 3, 300, 4, 46, "icon_Clothing_yaoshijinqiu", LocalStringManager.GetConfig("Clothing_language", "Desc_47"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_47"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 100, 4650, 2, 5, 2100, 7, allowRandomCreate: true, 25, isSpecial: false, 4, 12, -1, new List<int>(), 2, -1, 48, 2, keepOnPassing: false, 150, 2, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_47"), 0));
		_dataArray.Add(new ClothingItem(48, LocalStringManager.GetConfig("Clothing_language", "Name_48"), 3, 300, 6, 46, "icon_Clothing_yaowangbaoqiu", LocalStringManager.GetConfig("Clothing_language", "Desc_48"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_48"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 150, 13800, 4, 7, 3600, 8, allowRandomCreate: true, 15, isSpecial: false, 4, 12, -1, new List<int>(), 2, -1, 49, 2, keepOnPassing: false, 280, 2, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_48"), 0));
		_dataArray.Add(new ClothingItem(49, LocalStringManager.GetConfig("Clothing_language", "Name_49"), 3, 300, 2, 49, "icon_Clothing_jingangpigua", LocalStringManager.GetConfig("Clothing_language", "Desc_49"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_49"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 20, 900, 0, 3, 900, 5, allowRandomCreate: true, 35, isSpecial: false, 4, 12, -1, new List<int>(), 2, -1, 50, 2, keepOnPassing: false, 60, 2, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_49"), 0));
		_dataArray.Add(new ClothingItem(50, LocalStringManager.GetConfig("Clothing_language", "Name_50"), 3, 300, 4, 49, "icon_Clothing_zunzhebaoyi", LocalStringManager.GetConfig("Clothing_language", "Desc_50"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_50"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 30, 4650, 2, 5, 2100, 7, allowRandomCreate: true, 25, isSpecial: false, 4, 12, -1, new List<int>(), 2, -1, 51, 2, keepOnPassing: false, 150, 2, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_50"), 0));
		_dataArray.Add(new ClothingItem(51, LocalStringManager.GetConfig("Clothing_language", "Name_51"), 3, 300, 6, 49, "icon_Clothing_mingwangfayi", LocalStringManager.GetConfig("Clothing_language", "Desc_51"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_51"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 40, 13800, 4, 7, 3600, 8, allowRandomCreate: true, 15, isSpecial: false, 4, 12, -1, new List<int>(), 2, -1, 52, 2, keepOnPassing: false, 280, 2, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_51"), 0));
		_dataArray.Add(new ClothingItem(52, LocalStringManager.GetConfig("Clothing_language", "Name_52"), 3, 300, 2, 52, "icon_Clothing_miaoxiularanyi", LocalStringManager.GetConfig("Clothing_language", "Desc_52"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_52"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 20, 900, 0, 3, 900, 5, allowRandomCreate: true, 35, isSpecial: false, 4, 12, -1, new List<int>(), 2, -1, 53, 2, keepOnPassing: false, 60, 2, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_52"), 0));
		_dataArray.Add(new ClothingItem(53, LocalStringManager.GetConfig("Clothing_language", "Name_53"), 3, 300, 4, 52, "icon_Clothing_wucaiwuyi", LocalStringManager.GetConfig("Clothing_language", "Desc_53"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_53"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 30, 4650, 2, 5, 2100, 7, allowRandomCreate: true, 25, isSpecial: false, 4, 12, -1, new List<int>(), 2, -1, 54, 2, keepOnPassing: false, 150, 2, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_53"), 0));
		_dataArray.Add(new ClothingItem(54, LocalStringManager.GetConfig("Clothing_language", "Name_54"), 3, 300, 6, 52, "icon_Clothing_shengjiaofayi", LocalStringManager.GetConfig("Clothing_language", "Desc_54"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_54"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 40, 13800, 4, 7, 3600, 8, allowRandomCreate: true, 15, isSpecial: false, 4, 12, -1, new List<int>(), 2, -1, 55, 2, keepOnPassing: false, 280, 2, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_54"), 0));
		_dataArray.Add(new ClothingItem(55, LocalStringManager.GetConfig("Clothing_language", "Name_55"), 3, 300, 2, 55, "icon_Clothing_yexingyi", LocalStringManager.GetConfig("Clothing_language", "Desc_55"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_55"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 10, 900, 0, 3, 900, 5, allowRandomCreate: true, 35, isSpecial: false, 4, 12, -1, new List<int>(), 2, -1, 56, 2, keepOnPassing: false, 60, 2, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_55"), 0));
		_dataArray.Add(new ClothingItem(56, LocalStringManager.GetConfig("Clothing_language", "Name_56"), 3, 300, 4, 55, "icon_Clothing_moyingzhuang", LocalStringManager.GetConfig("Clothing_language", "Desc_56"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_56"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 20, 4650, 2, 5, 2100, 7, allowRandomCreate: true, 25, isSpecial: false, 4, 12, -1, new List<int>(), 2, -1, 57, 2, keepOnPassing: false, 150, 2, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_56"), 0));
		_dataArray.Add(new ClothingItem(57, LocalStringManager.GetConfig("Clothing_language", "Name_57"), 3, 300, 6, 55, "icon_Clothing_zhuaixingpao", LocalStringManager.GetConfig("Clothing_language", "Desc_57"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_57"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 30, 13800, 4, 7, 3600, 8, allowRandomCreate: true, 15, isSpecial: false, 4, 12, -1, new List<int>(), 2, -1, 58, 2, keepOnPassing: false, 280, 2, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_57"), 0));
		_dataArray.Add(new ClothingItem(58, LocalStringManager.GetConfig("Clothing_language", "Name_58"), 3, 300, 2, 58, "icon_Clothing_fulongchiyi", LocalStringManager.GetConfig("Clothing_language", "Desc_58"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_58"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 20, 900, 0, 3, 900, 5, allowRandomCreate: true, 35, isSpecial: false, 4, 12, -1, new List<int>(), 2, -1, 59, 2, keepOnPassing: false, 60, 2, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_58"), 0));
		_dataArray.Add(new ClothingItem(59, LocalStringManager.GetConfig("Clothing_language", "Name_59"), 3, 300, 4, 58, "icon_Clothing_fulongsihaipao", LocalStringManager.GetConfig("Clothing_language", "Desc_59"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_59"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 30, 4650, 2, 5, 2100, 7, allowRandomCreate: true, 25, isSpecial: false, 4, 12, -1, new List<int>(), 2, -1, 60, 2, keepOnPassing: false, 150, 2, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_59"), 0));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new ClothingItem(60, LocalStringManager.GetConfig("Clothing_language", "Name_60"), 3, 300, 6, 58, "icon_Clothing_liuhuoxuanpi", LocalStringManager.GetConfig("Clothing_language", "Desc_60"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_60"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 40, 13800, 4, 7, 3600, 8, allowRandomCreate: true, 15, isSpecial: false, 4, 12, -1, new List<int>(), 2, -1, 61, 2, keepOnPassing: false, 280, 2, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_60"), 0));
		_dataArray.Add(new ClothingItem(61, LocalStringManager.GetConfig("Clothing_language", "Name_61"), 3, 300, 2, 61, "icon_Clothing_xiehoujiaoyi", LocalStringManager.GetConfig("Clothing_language", "Desc_61"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_61"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 20, 900, 0, 3, 900, 5, allowRandomCreate: true, 35, isSpecial: false, 4, 12, -1, new List<int>(), 2, -1, 62, 2, keepOnPassing: false, 60, 2, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_61"), 0));
		_dataArray.Add(new ClothingItem(62, LocalStringManager.GetConfig("Clothing_language", "Name_62"), 3, 300, 4, 61, "icon_Clothing_xiehoujinyi", LocalStringManager.GetConfig("Clothing_language", "Desc_62"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_62"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 30, 4650, 2, 5, 2100, 7, allowRandomCreate: true, 25, isSpecial: false, 4, 12, -1, new List<int>(), 2, -1, 63, 2, keepOnPassing: false, 150, 2, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_62"), 0));
		_dataArray.Add(new ClothingItem(63, LocalStringManager.GetConfig("Clothing_language", "Name_63"), 3, 300, 6, 61, "icon_Clothing_houmuxueyi", LocalStringManager.GetConfig("Clothing_language", "Desc_63"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_63"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 40, 13800, 4, 7, 3600, 8, allowRandomCreate: true, 15, isSpecial: false, 4, 12, -1, new List<int>(), 2, -1, 64, 2, keepOnPassing: false, 280, 2, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_63"), 0));
		_dataArray.Add(new ClothingItem(64, LocalStringManager.GetConfig("Clothing_language", "Name_64"), 3, 300, 0, -1, "icon_Clothing_qiangbao", LocalStringManager.GetConfig("Clothing_language", "Desc_64"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_64"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: false, 5, 10, 0, 0, 0, 0, 0, allowRandomCreate: false, 0, isSpecial: true, 4, 12, -1, new List<int>(), 2, -1, 0, 0, keepOnPassing: false, 0, 0, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_64"), 0));
		_dataArray.Add(new ClothingItem(65, LocalStringManager.GetConfig("Clothing_language", "Name_65"), 3, 300, 0, -1, "icon_Clothing_tongyi", LocalStringManager.GetConfig("Clothing_language", "Desc_65"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_65"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: false, 5, 10, 0, 0, 0, 0, 0, allowRandomCreate: false, 0, isSpecial: true, 4, 12, -1, new List<int>(), 2, -1, 0, 1, keepOnPassing: false, 0, 0, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_65"), 0));
		_dataArray.Add(new ClothingItem(66, LocalStringManager.GetConfig("Clothing_language", "Name_66"), 3, 300, 2, 66, "icon_Clothing_yingeyi", LocalStringManager.GetConfig("Clothing_language", "Desc_66"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_66"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: false, 5, 50, 0, 0, 0, 0, 0, allowRandomCreate: true, 15, isSpecial: true, 4, 12, -1, new List<int>(), 2, -1, 10000, 2, keepOnPassing: false, 60, 4, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_66"), 0));
		_dataArray.Add(new ClothingItem(67, LocalStringManager.GetConfig("Clothing_language", "Name_67"), 3, 300, 4, 66, "icon_Clothing_yehuopao", LocalStringManager.GetConfig("Clothing_language", "Desc_67"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_67"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 100, 0, 2, 0, 0, 0, allowRandomCreate: true, 10, isSpecial: true, 4, 12, -1, new List<int>(), 2, -1, 10001, 2, keepOnPassing: false, 150, 4, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_67"), 0));
		_dataArray.Add(new ClothingItem(68, LocalStringManager.GetConfig("Clothing_language", "Name_68"), 3, 300, 6, 66, "icon_Clothing_xuanshiheipi", LocalStringManager.GetConfig("Clothing_language", "Desc_68"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_68"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: false, 5, 200, 0, 4, 0, 0, 0, allowRandomCreate: true, 5, isSpecial: true, 4, 12, -1, new List<int>(), 2, -1, 10002, 2, keepOnPassing: false, 280, 4, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_68"), 0));
		_dataArray.Add(new ClothingItem(69, LocalStringManager.GetConfig("Clothing_language", "Name_69"), 3, 300, 2, 69, "icon_Clothing_yingeyi", LocalStringManager.GetConfig("Clothing_language", "Desc_69"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_69"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: false, 5, 50, 0, 0, 0, 0, 0, allowRandomCreate: false, 0, isSpecial: true, 4, 12, -1, new List<int>(), 2, -1, 20000, 2, keepOnPassing: false, 60, 4, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_69"), 0));
		_dataArray.Add(new ClothingItem(70, LocalStringManager.GetConfig("Clothing_language", "Name_70"), 3, 300, 4, 69, "icon_Clothing_yehuopao", LocalStringManager.GetConfig("Clothing_language", "Desc_70"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_70"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 100, 0, 2, 0, 0, 0, allowRandomCreate: false, 0, isSpecial: true, 4, 12, -1, new List<int>(), 2, -1, 20001, 2, keepOnPassing: false, 150, 4, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_70"), 0));
		_dataArray.Add(new ClothingItem(71, LocalStringManager.GetConfig("Clothing_language", "Name_71"), 3, 300, 6, 69, "icon_Clothing_xuanshiheipi", LocalStringManager.GetConfig("Clothing_language", "Desc_71"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_71"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: false, 5, 200, 0, 4, 0, 0, 0, allowRandomCreate: false, 0, isSpecial: true, 4, 12, -1, new List<int>(), 2, -1, 20002, 2, keepOnPassing: false, 280, 4, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_71"), 0));
		_dataArray.Add(new ClothingItem(72, LocalStringManager.GetConfig("Clothing_language", "Name_72"), 3, 300, 8, -1, "icon_Clothing_bageyi", LocalStringManager.GetConfig("Clothing_language", "Desc_72"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_72"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 0, 0, 6, 0, 0, 0, allowRandomCreate: false, 0, isSpecial: true, 4, 12, -1, new List<int>(), 2, -1, 30000, 2, keepOnPassing: true, 0, 4, "GiftFromConchShip1", LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_72"), 0));
		_dataArray.Add(new ClothingItem(73, LocalStringManager.GetConfig("Clothing_language", "Name_73"), 3, 300, 8, -1, "icon_Clothing_yindaoyi", LocalStringManager.GetConfig("Clothing_language", "Desc_73"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_73"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 0, 0, 6, 0, 0, 0, allowRandomCreate: false, 0, isSpecial: true, 4, 12, -1, new List<int>(), 2, -1, 30001, 2, keepOnPassing: true, 0, 4, "GiftFromConchShip1", LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_73"), 0));
		_dataArray.Add(new ClothingItem(74, LocalStringManager.GetConfig("Clothing_language", "Name_74"), 3, 300, 8, -1, "icon_Clothing_banhaoyi", LocalStringManager.GetConfig("Clothing_language", "Desc_74"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_74"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 0, 0, 6, 0, 0, 0, allowRandomCreate: false, 0, isSpecial: true, 4, 12, -1, new List<int>(), 2, -1, 66, 2, keepOnPassing: true, 0, 4, "GiftFromConchShip2", LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_74"), 0));
		_dataArray.Add(new ClothingItem(75, LocalStringManager.GetConfig("Clothing_language", "Name_75"), 3, 300, 8, -1, "icon_Clothing_baijiaolinyi", LocalStringManager.GetConfig("Clothing_language", "Desc_75"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_75"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 0, 0, 6, 0, 0, 0, allowRandomCreate: false, 0, isSpecial: true, 4, 12, -1, new List<int>(), 2, -1, 30002, 2, keepOnPassing: true, 0, 4, "FiveLoong", LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_75"), 0));
		_dataArray.Add(new ClothingItem(76, LocalStringManager.GetConfig("Clothing_language", "Name_76"), 3, 300, 8, -1, "icon_Clothing_heijiaolinyi", LocalStringManager.GetConfig("Clothing_language", "Desc_76"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_76"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 0, 0, 6, 0, 0, 0, allowRandomCreate: false, 0, isSpecial: true, 4, 12, -1, new List<int>(), 2, -1, 30003, 2, keepOnPassing: true, 0, 4, "FiveLoong", LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_76"), 0));
		_dataArray.Add(new ClothingItem(77, LocalStringManager.GetConfig("Clothing_language", "Name_77"), 3, 300, 8, -1, "icon_Clothing_qingjiaolinyi", LocalStringManager.GetConfig("Clothing_language", "Desc_77"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_77"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 0, 0, 6, 0, 0, 0, allowRandomCreate: false, 0, isSpecial: true, 4, 12, -1, new List<int>(), 2, -1, 30005, 2, keepOnPassing: true, 0, 4, "FiveLoong", LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_77"), 0));
		_dataArray.Add(new ClothingItem(78, LocalStringManager.GetConfig("Clothing_language", "Name_78"), 3, 300, 8, -1, "icon_Clothing_chijiaolinyi", LocalStringManager.GetConfig("Clothing_language", "Desc_78"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_78"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 0, 0, 6, 0, 0, 0, allowRandomCreate: false, 0, isSpecial: true, 4, 12, -1, new List<int>(), 2, -1, 30004, 2, keepOnPassing: true, 0, 4, "FiveLoong", LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_78"), 0));
		_dataArray.Add(new ClothingItem(79, LocalStringManager.GetConfig("Clothing_language", "Name_79"), 3, 300, 8, -1, "icon_Clothing_huangjiaolinyi", LocalStringManager.GetConfig("Clothing_language", "Desc_79"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_79"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 0, 0, 6, 0, 0, 0, allowRandomCreate: false, 0, isSpecial: true, 4, 12, -1, new List<int>(), 2, -1, 30006, 2, keepOnPassing: true, 0, 4, "FiveLoong", LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_79"), 0));
		_dataArray.Add(new ClothingItem(80, LocalStringManager.GetConfig("Clothing_language", "Name_80"), 3, 300, 8, -1, "icon_Clothing_zhuyuewushuangyi", LocalStringManager.GetConfig("Clothing_language", "Desc_80"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_80"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 0, 0, 6, 0, 0, 0, allowRandomCreate: false, 0, isSpecial: true, 4, 12, -1, new List<int>(), 2, -1, 30007, 2, keepOnPassing: true, 0, 4, "HappyNewYear2024", LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_80"), 0));
		_dataArray.Add(new ClothingItem(81, LocalStringManager.GetConfig("Clothing_language", "Name_81"), 3, 300, 2, -1, "icon_Clothing_longshiyi", LocalStringManager.GetConfig("Clothing_language", "Desc_81"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_81"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 20, 900, 0, 3, 900, 5, allowRandomCreate: false, 25, isSpecial: true, 4, 12, -1, new List<int>(), 2, -1, 69, 2, keepOnPassing: false, 0, 2, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_81"), 0));
		_dataArray.Add(new ClothingItem(82, LocalStringManager.GetConfig("Clothing_language", "Name_82"), 3, 300, 4, -1, "icon_Clothing_jinglongyi", LocalStringManager.GetConfig("Clothing_language", "Desc_82"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_82"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 30, 4650, 2, 5, 2100, 7, allowRandomCreate: false, 15, isSpecial: true, 4, 12, -1, new List<int>(), 2, -1, 68, 2, keepOnPassing: false, 0, 2, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_82"), 0));
		_dataArray.Add(new ClothingItem(83, LocalStringManager.GetConfig("Clothing_language", "Name_83"), 3, 300, 6, -1, "icon_Clothing_xiankepao", LocalStringManager.GetConfig("Clothing_language", "Desc_83"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_83"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 40, 13800, 4, 7, 3600, 8, allowRandomCreate: false, 5, isSpecial: true, 4, 12, -1, new List<int>(), 2, -1, 70, 2, keepOnPassing: false, 0, 4, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_83"), 0));
		_dataArray.Add(new ClothingItem(84, LocalStringManager.GetConfig("Clothing_language", "Name_84"), 3, 300, 0, 84, "icon_Clothing_danyisupao", LocalStringManager.GetConfig("Clothing_language", "Desc_84"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_84"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 10, 150, 0, 1, 600, 3, allowRandomCreate: false, 0, isSpecial: true, 4, 12, 177, new List<int>(), 2, -1, 71, 2, keepOnPassing: false, 10, 3, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_84"), 0));
		_dataArray.Add(new ClothingItem(85, LocalStringManager.GetConfig("Clothing_language", "Name_85"), 3, 300, 1, 84, "icon_Clothing_tiansheyi", LocalStringManager.GetConfig("Clothing_language", "Desc_85"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_85"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 20, 300, 0, 2, 1200, 4, allowRandomCreate: false, 0, isSpecial: true, 4, 12, 177, new List<int>(), 2, -1, 72, 2, keepOnPassing: false, 30, 3, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_85"), 0));
		_dataArray.Add(new ClothingItem(86, LocalStringManager.GetConfig("Clothing_language", "Name_86"), 3, 300, 2, 84, "icon_Clothing_jiangzuofu", LocalStringManager.GetConfig("Clothing_language", "Desc_86"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_86"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 40, 900, 0, 3, 1800, 5, allowRandomCreate: false, 0, isSpecial: true, 4, 12, 177, new List<int>(), 2, -1, 73, 2, keepOnPassing: false, 60, 3, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_86"), 0));
		_dataArray.Add(new ClothingItem(87, LocalStringManager.GetConfig("Clothing_language", "Name_87"), 3, 300, 3, 84, "icon_Clothing_qingluopi", LocalStringManager.GetConfig("Clothing_language", "Desc_87"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_87"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 20, 2250, 1, 4, 3000, 6, allowRandomCreate: false, 0, isSpecial: true, 4, 12, 177, new List<int>(), 2, -1, 74, 2, keepOnPassing: false, 100, 3, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_87"), 0));
		_dataArray.Add(new ClothingItem(88, LocalStringManager.GetConfig("Clothing_language", "Name_88"), 3, 300, 4, 84, "icon_Clothing_jinyuqiu", LocalStringManager.GetConfig("Clothing_language", "Desc_88"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_88"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 30, 4650, 2, 5, 4200, 7, allowRandomCreate: false, 0, isSpecial: true, 4, 12, 177, new List<int>(), 2, -1, 75, 2, keepOnPassing: false, 150, 3, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_88"), 0));
		_dataArray.Add(new ClothingItem(89, LocalStringManager.GetConfig("Clothing_language", "Name_89"), 3, 300, 5, 84, "icon_Clothing_lanshan", LocalStringManager.GetConfig("Clothing_language", "Desc_89"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_89"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 10, 8400, 3, 6, 5400, 7, allowRandomCreate: false, 0, isSpecial: true, 4, 12, 177, new List<int>(), 2, -1, 76, 2, keepOnPassing: false, 210, 3, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_89"), 0));
		_dataArray.Add(new ClothingItem(90, LocalStringManager.GetConfig("Clothing_language", "Name_90"), 3, 300, 6, 84, "icon_Clothing_guqingjuanjia", LocalStringManager.GetConfig("Clothing_language", "Desc_90"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_90"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 20, 13800, 4, 7, 7200, 8, allowRandomCreate: false, 0, isSpecial: true, 4, 12, 177, new List<int>(), 2, -1, 77, 2, keepOnPassing: false, 280, 3, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_90"), 0));
		_dataArray.Add(new ClothingItem(91, LocalStringManager.GetConfig("Clothing_language", "Name_91"), 3, 300, 7, 84, "icon_Clothing_bodaibaoyi", LocalStringManager.GetConfig("Clothing_language", "Desc_91"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_91"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 10, 21150, 5, 8, 9000, 8, allowRandomCreate: false, 0, isSpecial: true, 4, 12, 177, new List<int>(), 2, -1, 78, 2, keepOnPassing: false, 360, 3, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_91"), 0));
		_dataArray.Add(new ClothingItem(92, LocalStringManager.GetConfig("Clothing_language", "Name_92"), 3, 300, 8, 92, "icon_Clothing_bixiaolingsheyi", LocalStringManager.GetConfig("Clothing_language", "Desc_92"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_92"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 0, 0, 6, 0, 0, 0, allowRandomCreate: false, 0, isSpecial: true, 4, 12, -1, new List<int>(), 2, -1, 30008, 2, keepOnPassing: true, 0, 4, "YearOfSnakeCloth", LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_92"), 0));
		_dataArray.Add(new ClothingItem(93, LocalStringManager.GetConfig("Clothing_language", "Name_93"), 3, 300, 8, 92, "icon_Clothing_qingxiaolingshey", LocalStringManager.GetConfig("Clothing_language", "Desc_93"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_93"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 0, 0, 6, 0, 0, 0, allowRandomCreate: false, 0, isSpecial: true, 4, 12, -1, new List<int>(), 2, -1, 30009, 2, keepOnPassing: true, 0, 4, "YearOfSnakeCloth", LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_93"), 0));
		_dataArray.Add(new ClothingItem(94, LocalStringManager.GetConfig("Clothing_language", "Name_94"), 3, 300, 8, 92, "icon_Clothing_qiongxiaolingsheyi", LocalStringManager.GetConfig("Clothing_language", "Desc_94"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_94"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 0, 0, 6, 0, 0, 0, allowRandomCreate: false, 0, isSpecial: true, 4, 12, -1, new List<int>(), 2, -1, 30010, 2, keepOnPassing: true, 0, 4, "YearOfSnakeCloth", LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_94"), 0));
		_dataArray.Add(new ClothingItem(95, LocalStringManager.GetConfig("Clothing_language", "Name_95"), 3, 300, 4, 95, "icon_Clothing_liangongfu", LocalStringManager.GetConfig("Clothing_language", "Desc_95"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_95"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 0, 4650, 0, 0, 0, 0, allowRandomCreate: false, 0, isSpecial: true, 4, 12, -1, new List<int>(), 2, -1, 5, 2, keepOnPassing: true, 0, 4, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_95"), 0));
		_dataArray.Add(new ClothingItem(96, LocalStringManager.GetConfig("Clothing_language", "Name_96"), 3, 300, 4, 95, "icon_Clothing_liangongfu", LocalStringManager.GetConfig("Clothing_language", "Desc_96"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_96"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 0, 4650, 0, 0, 0, 0, allowRandomCreate: false, 0, isSpecial: true, 4, 12, -1, new List<int>(), 2, -1, 14, 2, keepOnPassing: true, 0, 4, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_96"), 0));
		_dataArray.Add(new ClothingItem(97, LocalStringManager.GetConfig("Clothing_language", "Name_97"), 3, 300, 8, 97, "icon_Clothing_xiangjuyi", LocalStringManager.GetConfig("Clothing_language", "Desc_97"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_97"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 0, 0, 6, 0, 0, 0, allowRandomCreate: false, 0, isSpecial: true, 4, 12, -1, new List<int>(), 2, -1, 30011, 2, keepOnPassing: true, 0, 4, "HappyNewYear2026", LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_97"), 0));
		_dataArray.Add(new ClothingItem(98, LocalStringManager.GetConfig("Clothing_language", "Name_98"), 3, 300, 6, -1, "icon_Clothing_tianmuyinyi", LocalStringManager.GetConfig("Clothing_language", "Desc_98"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_98"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 40, 13800, 4, 7, 3600, 8, allowRandomCreate: false, 0, isSpecial: true, 4, 12, -1, new List<int>(), 2, -1, 80, 2, keepOnPassing: false, 0, 4, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_98"), 0));
		_dataArray.Add(new ClothingItem(99, LocalStringManager.GetConfig("Clothing_language", "Name_99"), 3, 300, 8, -1, "icon_Clothing_jinshoutianmupao", LocalStringManager.GetConfig("Clothing_language", "Desc_99"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_99"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 40, 21150, 5, 9, 5400, 8, allowRandomCreate: false, 0, isSpecial: true, 4, 12, -1, new List<int>(), 2, -1, 81, 2, keepOnPassing: false, 0, 4, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_99"), 0));
		_dataArray.Add(new ClothingItem(100, LocalStringManager.GetConfig("Clothing_language", "Name_100"), 3, 300, 6, -1, "icon_Clothing_tianmuyi", LocalStringManager.GetConfig("Clothing_language", "Desc_100"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_100"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 40, 13800, 4, 7, 3600, 8, allowRandomCreate: false, 0, isSpecial: true, 4, 12, -1, new List<int>(), 2, -1, 79, 2, keepOnPassing: false, 0, 4, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_100"), 0));
		_dataArray.Add(new ClothingItem(101, LocalStringManager.GetConfig("Clothing_language", "Name_101"), 3, 300, 8, 101, "icon_Clothing_xiankepao", LocalStringManager.GetConfig("Clothing_language", "Desc_101"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_101"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: true, inheritable: false, detachable: false, 5, 0, 21150, 5, 9, 1800, 8, allowRandomCreate: false, 0, isSpecial: true, 4, 12, -1, new List<int>(), 2, -1, 85, 2, keepOnPassing: false, 0, 0, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_101"), 0));
		_dataArray.Add(new ClothingItem(102, LocalStringManager.GetConfig("Clothing_language", "Name_102"), 3, 300, 8, 102, "icon_Clothing_tiandaozhuang", LocalStringManager.GetConfig("Clothing_language", "Desc_102"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_102"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: true, inheritable: false, detachable: true, 5, 0, 21150, 5, 9, 1800, 8, allowRandomCreate: false, 0, isSpecial: true, 4, 12, -1, new List<int>(), 2, -1, 82, 2, keepOnPassing: false, 0, 0, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_102"), 0));
		_dataArray.Add(new ClothingItem(103, LocalStringManager.GetConfig("Clothing_language", "Name_103"), 3, 300, 8, 102, "icon_Clothing_zhongdaozhuang", LocalStringManager.GetConfig("Clothing_language", "Desc_103"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_103"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: true, inheritable: false, detachable: true, 5, 0, 21150, 5, 9, 1800, 8, allowRandomCreate: false, 0, isSpecial: true, 4, 12, -1, new List<int>(), 2, -1, 83, 2, keepOnPassing: false, 0, 0, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_103"), 0));
		_dataArray.Add(new ClothingItem(104, LocalStringManager.GetConfig("Clothing_language", "Name_104"), 3, 300, 8, 102, "icon_Clothing_xiedaozhuang", LocalStringManager.GetConfig("Clothing_language", "Desc_104"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_104"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: true, inheritable: false, detachable: true, 5, 0, 21150, 5, 9, 1800, 8, allowRandomCreate: false, 0, isSpecial: true, 4, 12, -1, new List<int>(), 2, -1, 84, 2, keepOnPassing: false, 0, 0, null, LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_104"), 0));
		_dataArray.Add(new ClothingItem(105, LocalStringManager.GetConfig("Clothing_language", "Name_105"), 3, 300, 8, 105, "icon_Clothing_qingshanyijiu", LocalStringManager.GetConfig("Clothing_language", "Desc_105"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_105"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 0, 0, 6, 0, 0, 0, allowRandomCreate: false, 0, isSpecial: true, 4, 12, -1, new List<int>(), 2, -1, 30012, 2, keepOnPassing: true, 0, 4, "GreenHillsRemain", LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_105"), 0));
		_dataArray.Add(new ClothingItem(106, LocalStringManager.GetConfig("Clothing_language", "Name_106"), 3, 300, 8, 106, "icon_Clothing_bazaitongzhou", LocalStringManager.GetConfig("Clothing_language", "Desc_106"), LocalStringManager.GetConfig("Clothing_language", "FunctionDesc_106"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 5, 0, 0, 6, 0, 0, 0, allowRandomCreate: false, 0, isSpecial: true, 4, 12, -1, new List<int>(), 2, -1, 30014, 2, keepOnPassing: true, 0, 4, "EightYears", LocalStringManager.GetConfig("Clothing_language", "SmallVillageDesc_106"), 0));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<ClothingItem>(107);
		CreateItems0();
		CreateItems1();
	}
}
