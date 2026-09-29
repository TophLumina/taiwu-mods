using System;
using System.Collections.Generic;
using Config.Common;
using GameData.Domains.Item;

namespace Config;

[Serializable]
public class Carrier : ConfigData<CarrierItem, short>
{
	public static class DefKey
	{
		public const short CarDrop0 = 0;

		public const short CarDrop1 = 1;

		public const short CarDrop2 = 2;

		public const short CarDrop3 = 3;

		public const short CarDrop4 = 4;

		public const short CarDrop5 = 5;

		public const short CarDrop6 = 6;

		public const short CarDrop7 = 7;

		public const short CarDrop8 = 8;

		public const short CarCapture0 = 9;

		public const short CarCapture1 = 10;

		public const short CarCapture2 = 11;

		public const short CarCapture3 = 12;

		public const short CarCapture4 = 13;

		public const short CarCapture5 = 14;

		public const short CarCapture6 = 15;

		public const short CarCapture7 = 16;

		public const short CarCapture8 = 17;

		public const short Horse0 = 18;

		public const short Horse1 = 19;

		public const short Horse2 = 20;

		public const short Horse3 = 21;

		public const short Horse4 = 22;

		public const short Horse5 = 23;

		public const short Horse6 = 24;

		public const short Horse7 = 25;

		public const short Horse8 = 26;

		public const short Monkey0 = 27;

		public const short Eagle0 = 28;

		public const short Pig0 = 29;

		public const short Bear0 = 30;

		public const short Bull0 = 31;

		public const short Snake0 = 32;

		public const short Jaguar0 = 33;

		public const short Lion0 = 34;

		public const short Tiger0 = 35;

		public const short Monkey1 = 36;

		public const short Eagle1 = 37;

		public const short Pig1 = 38;

		public const short Bear1 = 39;

		public const short Bull1 = 40;

		public const short Snake1 = 41;

		public const short Jaguar1 = 42;

		public const short Lion1 = 43;

		public const short Tiger1 = 44;

		public const short HorseOfHuanxin = 45;

		public const short JiaoWhite = 46;

		public const short JiaoBlack = 47;

		public const short JiaoGreen = 48;

		public const short JiaoRed = 49;

		public const short JiaoYellow = 50;

		public const short JiaoWB = 51;

		public const short JiaoWG = 52;

		public const short JiaoWR = 53;

		public const short JiaoWY = 54;

		public const short JiaoBG = 55;

		public const short JiaoBR = 56;

		public const short JiaoBY = 57;

		public const short JiaoGR = 58;

		public const short JiaoGY = 59;

		public const short JiaoRY = 60;

		public const short JiaoWBG = 61;

		public const short JiaoWBR = 62;

		public const short JiaoWBY = 63;

		public const short JiaoWGR = 64;

		public const short JiaoWGY = 65;

		public const short JiaoWRY = 66;

		public const short JiaoBGR = 67;

		public const short JiaoBGY = 68;

		public const short JiaoBRY = 69;

		public const short JiaoGRY = 70;

		public const short JiaoWBGR = 71;

		public const short JiaoWBGY = 72;

		public const short JiaoWBRY = 73;

		public const short JiaoWGRY = 74;

		public const short JiaoBGRY = 75;

		public const short JiaoWGRYB = 76;

		public const short Qiuniu = 77;

		public const short Yazi = 78;

		public const short Chaofeng = 79;

		public const short Pulao = 80;

		public const short Suanni = 81;

		public const short Baxia = 82;

		public const short Bian = 83;

		public const short Fuxi = 84;

		public const short Chiwen = 85;

		public const short LoongWhite = 86;

		public const short LoongBlack = 87;

		public const short LoongGreen = 88;

		public const short LoongRed = 89;

		public const short LoongYellow = 90;
	}

	public static class DefValue
	{
		public static CarrierItem CarDrop0 => Instance[(short)0];

		public static CarrierItem CarDrop1 => Instance[(short)1];

		public static CarrierItem CarDrop2 => Instance[(short)2];

		public static CarrierItem CarDrop3 => Instance[(short)3];

		public static CarrierItem CarDrop4 => Instance[(short)4];

		public static CarrierItem CarDrop5 => Instance[(short)5];

		public static CarrierItem CarDrop6 => Instance[(short)6];

		public static CarrierItem CarDrop7 => Instance[(short)7];

		public static CarrierItem CarDrop8 => Instance[(short)8];

		public static CarrierItem CarCapture0 => Instance[(short)9];

		public static CarrierItem CarCapture1 => Instance[(short)10];

		public static CarrierItem CarCapture2 => Instance[(short)11];

		public static CarrierItem CarCapture3 => Instance[(short)12];

		public static CarrierItem CarCapture4 => Instance[(short)13];

		public static CarrierItem CarCapture5 => Instance[(short)14];

		public static CarrierItem CarCapture6 => Instance[(short)15];

		public static CarrierItem CarCapture7 => Instance[(short)16];

		public static CarrierItem CarCapture8 => Instance[(short)17];

		public static CarrierItem Horse0 => Instance[(short)18];

		public static CarrierItem Horse1 => Instance[(short)19];

		public static CarrierItem Horse2 => Instance[(short)20];

		public static CarrierItem Horse3 => Instance[(short)21];

		public static CarrierItem Horse4 => Instance[(short)22];

		public static CarrierItem Horse5 => Instance[(short)23];

		public static CarrierItem Horse6 => Instance[(short)24];

		public static CarrierItem Horse7 => Instance[(short)25];

		public static CarrierItem Horse8 => Instance[(short)26];

		public static CarrierItem Monkey0 => Instance[(short)27];

		public static CarrierItem Eagle0 => Instance[(short)28];

		public static CarrierItem Pig0 => Instance[(short)29];

		public static CarrierItem Bear0 => Instance[(short)30];

		public static CarrierItem Bull0 => Instance[(short)31];

		public static CarrierItem Snake0 => Instance[(short)32];

		public static CarrierItem Jaguar0 => Instance[(short)33];

		public static CarrierItem Lion0 => Instance[(short)34];

		public static CarrierItem Tiger0 => Instance[(short)35];

		public static CarrierItem Monkey1 => Instance[(short)36];

		public static CarrierItem Eagle1 => Instance[(short)37];

		public static CarrierItem Pig1 => Instance[(short)38];

		public static CarrierItem Bear1 => Instance[(short)39];

		public static CarrierItem Bull1 => Instance[(short)40];

		public static CarrierItem Snake1 => Instance[(short)41];

		public static CarrierItem Jaguar1 => Instance[(short)42];

		public static CarrierItem Lion1 => Instance[(short)43];

		public static CarrierItem Tiger1 => Instance[(short)44];

		public static CarrierItem HorseOfHuanxin => Instance[(short)45];

		public static CarrierItem JiaoWhite => Instance[(short)46];

		public static CarrierItem JiaoBlack => Instance[(short)47];

		public static CarrierItem JiaoGreen => Instance[(short)48];

		public static CarrierItem JiaoRed => Instance[(short)49];

		public static CarrierItem JiaoYellow => Instance[(short)50];

		public static CarrierItem JiaoWB => Instance[(short)51];

		public static CarrierItem JiaoWG => Instance[(short)52];

		public static CarrierItem JiaoWR => Instance[(short)53];

		public static CarrierItem JiaoWY => Instance[(short)54];

		public static CarrierItem JiaoBG => Instance[(short)55];

		public static CarrierItem JiaoBR => Instance[(short)56];

		public static CarrierItem JiaoBY => Instance[(short)57];

		public static CarrierItem JiaoGR => Instance[(short)58];

		public static CarrierItem JiaoGY => Instance[(short)59];

		public static CarrierItem JiaoRY => Instance[(short)60];

		public static CarrierItem JiaoWBG => Instance[(short)61];

		public static CarrierItem JiaoWBR => Instance[(short)62];

		public static CarrierItem JiaoWBY => Instance[(short)63];

		public static CarrierItem JiaoWGR => Instance[(short)64];

		public static CarrierItem JiaoWGY => Instance[(short)65];

		public static CarrierItem JiaoWRY => Instance[(short)66];

		public static CarrierItem JiaoBGR => Instance[(short)67];

		public static CarrierItem JiaoBGY => Instance[(short)68];

		public static CarrierItem JiaoBRY => Instance[(short)69];

		public static CarrierItem JiaoGRY => Instance[(short)70];

		public static CarrierItem JiaoWBGR => Instance[(short)71];

		public static CarrierItem JiaoWBGY => Instance[(short)72];

		public static CarrierItem JiaoWBRY => Instance[(short)73];

		public static CarrierItem JiaoWGRY => Instance[(short)74];

		public static CarrierItem JiaoBGRY => Instance[(short)75];

		public static CarrierItem JiaoWGRYB => Instance[(short)76];

		public static CarrierItem Qiuniu => Instance[(short)77];

		public static CarrierItem Yazi => Instance[(short)78];

		public static CarrierItem Chaofeng => Instance[(short)79];

		public static CarrierItem Pulao => Instance[(short)80];

		public static CarrierItem Suanni => Instance[(short)81];

		public static CarrierItem Baxia => Instance[(short)82];

		public static CarrierItem Bian => Instance[(short)83];

		public static CarrierItem Fuxi => Instance[(short)84];

		public static CarrierItem Chiwen => Instance[(short)85];

		public static CarrierItem LoongWhite => Instance[(short)86];

		public static CarrierItem LoongBlack => Instance[(short)87];

		public static CarrierItem LoongGreen => Instance[(short)88];

		public static CarrierItem LoongRed => Instance[(short)89];

		public static CarrierItem LoongYellow => Instance[(short)90];
	}

	public static Carrier Instance = new Carrier();

	private readonly HashSet<string> RequiredFields = new HashSet<string>
	{
		"Name", "ItemSubType", "GroupId", "Desc", "FunctionDesc", "ResourceType", "MakeItemSubType", "TaskLock", "EquipmentEffectId", "CharacterIdInCombat",
		"CombatState", "LoveFoodType", "HateFoodType", "TravelSkeleton", "TemplateId", "Grade", "Icon", "MaxDurability", "BaseWeight", "StandDisplay"
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
		_dataArray.Add(new CarrierItem(0, LocalStringManager.GetConfig("Carrier_language", "Name_0"), 4, 400, 0, 0, "icon_Carrier_dulunche", LocalStringManager.GetConfig("Carrier_language", "Desc_0"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_0"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 300, 0, 300, 0, 2, 600, 3, allowRandomCreate: true, 45, isSpecial: false, 1, 36, 178, new List<int>(), 7, -1, 10, 4000, 1, 20, 0, 0, -1, -1, new sbyte[7], isFlying: false, -1, null, null, null, 0, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), 0));
		_dataArray.Add(new CarrierItem(1, LocalStringManager.GetConfig("Carrier_language", "Name_1"), 4, 400, 1, 0, "icon_Carrier_dulunche", LocalStringManager.GetConfig("Carrier_language", "Desc_1"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_1"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 300, 0, 600, 0, 4, 1200, 4, allowRandomCreate: true, 40, isSpecial: false, 1, 36, 178, new List<int>(), 7, -1, 15, 6000, 1, 30, 0, 0, -1, -1, new sbyte[7], isFlying: false, -1, null, null, null, 1, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), 0));
		_dataArray.Add(new CarrierItem(2, LocalStringManager.GetConfig("Carrier_language", "Name_2"), 4, 400, 2, 0, "icon_Carrier_dulunche", LocalStringManager.GetConfig("Carrier_language", "Desc_2"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_2"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 300, 0, 1800, 1, 6, 1800, 5, allowRandomCreate: true, 35, isSpecial: false, 1, 36, 178, new List<int>(), 7, -1, 20, 8000, 1, 40, 0, 0, -1, -1, new sbyte[7], isFlying: false, -1, null, null, null, 2, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), 0));
		_dataArray.Add(new CarrierItem(3, LocalStringManager.GetConfig("Carrier_language", "Name_3"), 4, 400, 3, 0, "icon_Carrier_shuangyuananche", LocalStringManager.GetConfig("Carrier_language", "Desc_3"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_3"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 300, 0, 4500, 2, 8, 3000, 6, allowRandomCreate: true, 30, isSpecial: false, 1, 36, 178, new List<int>(), 7, -1, 25, 10000, 2, 50, 0, 0, -1, -1, new sbyte[7], isFlying: false, -1, null, null, null, 3, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), 0));
		_dataArray.Add(new CarrierItem(4, LocalStringManager.GetConfig("Carrier_language", "Name_4"), 4, 400, 4, 0, "icon_Carrier_shuangyuananche", LocalStringManager.GetConfig("Carrier_language", "Desc_4"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_4"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 300, 0, 9300, 3, 10, 4200, 7, allowRandomCreate: true, 25, isSpecial: false, 1, 36, 178, new List<int>(), 7, -1, 30, 12000, 2, 60, 0, 0, -1, -1, new sbyte[7], isFlying: false, -1, null, null, null, 4, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), 0));
		_dataArray.Add(new CarrierItem(5, LocalStringManager.GetConfig("Carrier_language", "Name_5"), 4, 400, 5, 0, "icon_Carrier_shuangyuananche", LocalStringManager.GetConfig("Carrier_language", "Desc_5"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_5"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 300, 0, 16800, 4, 12, 5400, 7, allowRandomCreate: true, 20, isSpecial: false, 1, 36, 178, new List<int>(), 7, -1, 35, 14000, 2, 70, 0, 0, -1, -1, new sbyte[7], isFlying: false, -1, null, null, null, 5, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), 0));
		_dataArray.Add(new CarrierItem(6, LocalStringManager.GetConfig("Carrier_language", "Name_6"), 4, 400, 6, 0, "icon_Carrier_qilinhuagaiche", LocalStringManager.GetConfig("Carrier_language", "Desc_6"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_6"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 300, 0, 27600, 5, 14, 7200, 8, allowRandomCreate: true, 15, isSpecial: false, 1, 36, 178, new List<int>(), 7, -1, 40, 16000, 3, 80, 0, 0, -1, -1, new sbyte[7], isFlying: false, -1, null, null, null, 6, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), 0));
		_dataArray.Add(new CarrierItem(7, LocalStringManager.GetConfig("Carrier_language", "Name_7"), 4, 400, 7, 0, "icon_Carrier_bajiaobaolouche", LocalStringManager.GetConfig("Carrier_language", "Desc_7"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_7"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 300, 0, 42300, 6, 16, 9000, 8, allowRandomCreate: true, 10, isSpecial: false, 1, 36, 178, new List<int>(), 7, -1, 45, 18000, 3, 90, 0, 0, -1, -1, new sbyte[7], isFlying: false, -1, null, null, null, 7, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), 0));
		_dataArray.Add(new CarrierItem(8, LocalStringManager.GetConfig("Carrier_language", "Name_8"), 4, 400, 8, 0, "icon_Carrier_xuanlongyu", LocalStringManager.GetConfig("Carrier_language", "Desc_8"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_8"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 300, 0, 61500, 6, 18, 10800, 8, allowRandomCreate: true, 5, isSpecial: false, 1, 36, 178, new List<int>(), 7, -1, 50, 20000, 3, 100, 0, 0, -1, -1, new sbyte[7], isFlying: false, -1, null, null, null, 8, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), 0));
		_dataArray.Add(new CarrierItem(9, LocalStringManager.GetConfig("Carrier_language", "Name_9"), 4, 400, 0, 9, "icon_Carrier_zhubanqiao", LocalStringManager.GetConfig("Carrier_language", "Desc_9"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_9"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 300, 0, 300, 0, 2, 600, 3, allowRandomCreate: true, 45, isSpecial: false, 1, 36, 179, new List<int>(), 7, -1, 10, 4000, 1, 0, 20, 10, -1, -1, new sbyte[7], isFlying: false, -1, null, null, null, 9, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), 0));
		_dataArray.Add(new CarrierItem(10, LocalStringManager.GetConfig("Carrier_language", "Name_10"), 4, 400, 1, 9, "icon_Carrier_zhubanqiao", LocalStringManager.GetConfig("Carrier_language", "Desc_10"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_10"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 300, 0, 600, 0, 4, 1200, 4, allowRandomCreate: true, 40, isSpecial: false, 1, 36, 179, new List<int>(), 7, -1, 15, 6000, 1, 0, 30, 15, -1, -1, new sbyte[7], isFlying: false, -1, null, null, null, 10, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), 0));
		_dataArray.Add(new CarrierItem(11, LocalStringManager.GetConfig("Carrier_language", "Name_11"), 4, 400, 2, 9, "icon_Carrier_zhubanqiao", LocalStringManager.GetConfig("Carrier_language", "Desc_11"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_11"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 300, 0, 1800, 1, 6, 1800, 5, allowRandomCreate: true, 35, isSpecial: false, 1, 36, 179, new List<int>(), 7, -1, 20, 8000, 1, 0, 40, 20, -1, -1, new sbyte[7], isFlying: false, -1, null, null, null, 11, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), 0));
		_dataArray.Add(new CarrierItem(12, LocalStringManager.GetConfig("Carrier_language", "Name_12"), 4, 400, 3, 9, "icon_Carrier_pulundache", LocalStringManager.GetConfig("Carrier_language", "Desc_12"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_12"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 300, 0, 4500, 2, 8, 3000, 6, allowRandomCreate: true, 30, isSpecial: false, 1, 36, 179, new List<int>(), 7, -1, 25, 10000, 2, 0, 50, 25, -1, -1, new sbyte[7], isFlying: false, -1, null, null, null, 12, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), 0));
		_dataArray.Add(new CarrierItem(13, LocalStringManager.GetConfig("Carrier_language", "Name_13"), 4, 400, 4, 9, "icon_Carrier_pulundache", LocalStringManager.GetConfig("Carrier_language", "Desc_13"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_13"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 300, 0, 9300, 3, 10, 4200, 7, allowRandomCreate: true, 25, isSpecial: false, 1, 36, 179, new List<int>(), 7, -1, 30, 12000, 2, 0, 60, 30, -1, -1, new sbyte[7], isFlying: false, -1, null, null, null, 13, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), 0));
		_dataArray.Add(new CarrierItem(14, LocalStringManager.GetConfig("Carrier_language", "Name_14"), 4, 400, 5, 9, "icon_Carrier_pulundache", LocalStringManager.GetConfig("Carrier_language", "Desc_14"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_14"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 300, 0, 16800, 4, 12, 5400, 7, allowRandomCreate: true, 20, isSpecial: false, 1, 36, 179, new List<int>(), 7, -1, 35, 14000, 2, 0, 70, 35, -1, -1, new sbyte[7], isFlying: false, -1, null, null, null, 14, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), 0));
		_dataArray.Add(new CarrierItem(15, LocalStringManager.GetConfig("Carrier_language", "Name_15"), 4, 400, 6, 9, "icon_Carrier_fenghouche", LocalStringManager.GetConfig("Carrier_language", "Desc_15"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_15"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 300, 0, 27600, 5, 14, 7200, 8, allowRandomCreate: true, 15, isSpecial: false, 1, 36, 179, new List<int>(), 7, -1, 40, 16000, 3, 0, 80, 40, -1, -1, new sbyte[7], isFlying: false, -1, null, null, null, 15, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), 0));
		_dataArray.Add(new CarrierItem(16, LocalStringManager.GetConfig("Carrier_language", "Name_16"), 4, 400, 7, 9, "icon_Carrier_longqiaoyunchuan", LocalStringManager.GetConfig("Carrier_language", "Desc_16"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_16"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 300, 0, 42300, 6, 16, 9000, 8, allowRandomCreate: true, 10, isSpecial: false, 1, 36, 179, new List<int>(), 7, -1, 45, 18000, 3, 0, 90, 45, -1, -1, new sbyte[7], isFlying: false, -1, null, null, null, 16, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), 0));
		_dataArray.Add(new CarrierItem(17, LocalStringManager.GetConfig("Carrier_language", "Name_17"), 4, 400, 8, 9, "icon_Carrier_qixiangche", LocalStringManager.GetConfig("Carrier_language", "Desc_17"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_17"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: true, inheritable: true, detachable: true, 300, 0, 61500, 6, 18, 10800, 8, allowRandomCreate: true, 5, isSpecial: false, 1, 36, 179, new List<int>(), 7, -1, 50, 20000, 3, 0, 100, 50, -1, -1, new sbyte[7], isFlying: false, -1, null, null, null, 17, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), 0));
		_dataArray.Add(new CarrierItem(18, LocalStringManager.GetConfig("Carrier_language", "Name_18"), 4, 401, 0, 18, "icon_Carrier_luozi", LocalStringManager.GetConfig("Carrier_language", "Desc_18"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_18"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: true, 300, 0, 300, 0, 2, 600, 3, allowRandomCreate: true, 45, isSpecial: false, 0, 12, -1, new List<int>(), 8, -1, 35, 2000, 1, 0, 0, 0, -1, -1, new sbyte[7], isFlying: false, -1, new List<short> { 70, 71, 72, 73, 74, 75, 76 }, new List<short> { 63, 64, 65, 66, 67, 68, 69 }, null, 18, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), 0));
		_dataArray.Add(new CarrierItem(19, LocalStringManager.GetConfig("Carrier_language", "Name_19"), 4, 401, 1, 18, "icon_Carrier_luozi", LocalStringManager.GetConfig("Carrier_language", "Desc_19"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_19"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: true, 300, 0, 600, 0, 4, 1200, 4, allowRandomCreate: true, 40, isSpecial: false, 0, 12, -1, new List<int>(), 8, -1, 40, 3000, 1, 0, 0, 0, -1, -1, new sbyte[7], isFlying: false, -1, new List<short> { 70, 71, 72, 73, 74, 75, 76 }, new List<short> { 63, 64, 65, 66, 67, 68, 69 }, null, 19, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), 0));
		_dataArray.Add(new CarrierItem(20, LocalStringManager.GetConfig("Carrier_language", "Name_20"), 4, 401, 2, 18, "icon_Carrier_luozi", LocalStringManager.GetConfig("Carrier_language", "Desc_20"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_20"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: true, 300, 0, 1800, 1, 6, 1800, 5, allowRandomCreate: true, 35, isSpecial: false, 0, 12, -1, new List<int>(), 8, -1, 45, 4000, 1, 0, 0, 0, -1, -1, new sbyte[7], isFlying: false, -1, new List<short> { 70, 71, 72, 73, 74, 75, 76 }, new List<short> { 63, 64, 65, 66, 67, 68, 69 }, null, 20, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), 0));
		_dataArray.Add(new CarrierItem(21, LocalStringManager.GetConfig("Carrier_language", "Name_21"), 4, 401, 3, 18, "icon_Carrier_guniu", LocalStringManager.GetConfig("Carrier_language", "Desc_21"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_21"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: true, 300, 0, 4500, 2, 8, 3000, 6, allowRandomCreate: true, 30, isSpecial: false, 0, 12, -1, new List<int>(), 8, -1, 50, 5000, 2, 0, 0, 0, -1, -1, new sbyte[7], isFlying: false, -1, new List<short> { 70, 71, 72, 73, 74, 75, 76 }, new List<short> { 63, 64, 65, 66, 67, 68, 69 }, null, 21, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), 0));
		_dataArray.Add(new CarrierItem(22, LocalStringManager.GetConfig("Carrier_language", "Name_22"), 4, 401, 4, 18, "icon_Carrier_guniu", LocalStringManager.GetConfig("Carrier_language", "Desc_22"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_22"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: true, 300, 0, 9300, 3, 10, 4200, 7, allowRandomCreate: true, 25, isSpecial: false, 0, 12, -1, new List<int>(), 8, -1, 55, 6000, 2, 0, 0, 0, -1, -1, new sbyte[7], isFlying: false, -1, new List<short> { 70, 71, 72, 73, 74, 75, 76 }, new List<short> { 63, 64, 65, 66, 67, 68, 69 }, null, 22, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), 0));
		_dataArray.Add(new CarrierItem(23, LocalStringManager.GetConfig("Carrier_language", "Name_23"), 4, 401, 5, 18, "icon_Carrier_guniu", LocalStringManager.GetConfig("Carrier_language", "Desc_23"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_23"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: true, 300, 0, 16800, 4, 12, 5400, 7, allowRandomCreate: true, 20, isSpecial: false, 0, 12, -1, new List<int>(), 8, -1, 60, 7000, 2, 0, 0, 0, -1, -1, new sbyte[7], isFlying: false, -1, new List<short> { 70, 71, 72, 73, 74, 75, 76 }, new List<short> { 63, 64, 65, 66, 67, 68, 69 }, null, 23, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), 0));
		_dataArray.Add(new CarrierItem(24, LocalStringManager.GetConfig("Carrier_language", "Name_24"), 4, 401, 6, 18, "icon_Carrier_guanwaimingju", LocalStringManager.GetConfig("Carrier_language", "Desc_24"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_24"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: true, 300, 0, 27600, 5, 14, 7200, 8, allowRandomCreate: true, 15, isSpecial: false, 0, 12, -1, new List<int>(), 8, -1, 65, 8000, 3, 0, 0, 0, -1, -1, new sbyte[7], isFlying: false, -1, new List<short> { 70, 71, 72, 73, 74, 75, 76 }, new List<short> { 63, 64, 65, 66, 67, 68, 69 }, null, 24, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), 0));
		_dataArray.Add(new CarrierItem(25, LocalStringManager.GetConfig("Carrier_language", "Name_25"), 4, 401, 7, 18, "icon_Carrier_qingniu", LocalStringManager.GetConfig("Carrier_language", "Desc_25"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_25"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: true, 300, 0, 42300, 6, 16, 9000, 8, allowRandomCreate: true, 10, isSpecial: false, 0, 12, -1, new List<int>(), 8, -1, 70, 9000, 3, 0, 0, 0, -1, -1, new sbyte[7], isFlying: false, -1, new List<short> { 70, 71, 72, 73, 74, 75, 76 }, new List<short> { 63, 64, 65, 66, 67, 68, 69 }, null, 25, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), 0));
		_dataArray.Add(new CarrierItem(26, LocalStringManager.GetConfig("Carrier_language", "Name_26"), 4, 401, 8, 18, "icon_Carrier_hanxuebaoma", LocalStringManager.GetConfig("Carrier_language", "Desc_26"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_26"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: true, 300, 0, 61500, 6, 18, 10800, 8, allowRandomCreate: true, 5, isSpecial: false, 0, 12, -1, new List<int>(), 8, -1, 75, 10000, 3, 0, 0, 0, -1, -1, new sbyte[7], isFlying: false, -1, new List<short> { 70, 71, 72, 73, 74, 75, 76 }, new List<short> { 63, 64, 65, 66, 67, 68, 69 }, null, 26, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), 0));
		_dataArray.Add(new CarrierItem(27, LocalStringManager.GetConfig("Carrier_language", "Name_27"), 4, 402, 2, 27, "icon_Carrier_houzi", LocalStringManager.GetConfig("Carrier_language", "Desc_27"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_27"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: true, 300, 0, 900, 1, 6, 1800, 5, allowRandomCreate: true, 35, isSpecial: false, 0, 12, -1, new List<int>(), 9, -1, 15, 4000, 1, 25, 25, 5, 228, 148, new sbyte[7], isFlying: false, 0, new List<short> { 70, 71, 72, 73, 74, 75, 76 }, new List<short> { 63, 64, 65, 66, 67, 68, 69 }, null, 27, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), 20));
		_dataArray.Add(new CarrierItem(28, LocalStringManager.GetConfig("Carrier_language", "Name_28"), 4, 402, 2, 27, "icon_Carrier_eying", LocalStringManager.GetConfig("Carrier_language", "Desc_28"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_28"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: true, 300, 0, 900, 1, 6, 1800, 5, allowRandomCreate: true, 35, isSpecial: false, 0, 12, -1, new List<int>(), 9, -1, 15, 4000, 1, 25, 25, 5, 229, 149, new sbyte[7], isFlying: true, 0, new List<short> { 63, 64, 65, 66, 67, 68, 69 }, new List<short> { 56, 57, 58, 59, 60, 61, 62 }, null, 28, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), 20));
		_dataArray.Add(new CarrierItem(29, LocalStringManager.GetConfig("Carrier_language", "Name_29"), 4, 402, 2, 27, "icon_Carrier_yezhu", LocalStringManager.GetConfig("Carrier_language", "Desc_29"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_29"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: true, 300, 0, 900, 1, 6, 1800, 5, allowRandomCreate: true, 35, isSpecial: false, 0, 12, -1, new List<int>(), 9, -1, 15, 4000, 1, 25, 25, 5, 230, 150, new sbyte[7], isFlying: false, 0, new List<short> { 56, 57, 58, 59, 60, 61, 62 }, new List<short> { 77, 78, 79, 80, 81, 82, 83 }, null, 29, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), 20));
		_dataArray.Add(new CarrierItem(30, LocalStringManager.GetConfig("Carrier_language", "Name_30"), 4, 402, 3, 27, "icon_Carrier_zongxiong", LocalStringManager.GetConfig("Carrier_language", "Desc_30"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_30"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: true, 300, 0, 2250, 1, 8, 3000, 6, allowRandomCreate: true, 30, isSpecial: false, 0, 12, -1, new List<int>(), 9, -1, 20, 5000, 2, 30, 30, 10, 231, 151, new sbyte[7], isFlying: false, 0, new List<short> { 77, 78, 79, 80, 81, 82, 83 }, new List<short> { 56, 57, 58, 59, 60, 61, 62 }, null, 30, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), 20));
		_dataArray.Add(new CarrierItem(31, LocalStringManager.GetConfig("Carrier_language", "Name_31"), 4, 402, 3, 27, "icon_Carrier_yeniu", LocalStringManager.GetConfig("Carrier_language", "Desc_31"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_31"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: true, 300, 0, 2250, 1, 8, 3000, 6, allowRandomCreate: true, 30, isSpecial: false, 0, 12, -1, new List<int>(), 9, -1, 20, 5000, 2, 30, 30, 10, 232, 152, new sbyte[7], isFlying: false, 0, new List<short> { 70, 71, 72, 73, 74, 75, 76 }, new List<short> { 63, 64, 65, 66, 67, 68, 69 }, null, 31, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), 20));
		_dataArray.Add(new CarrierItem(32, LocalStringManager.GetConfig("Carrier_language", "Name_32"), 4, 402, 3, 27, "icon_Carrier_jushe", LocalStringManager.GetConfig("Carrier_language", "Desc_32"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_32"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: true, 300, 0, 2250, 1, 8, 3000, 6, allowRandomCreate: true, 30, isSpecial: false, 0, 12, -1, new List<int>(), 9, -1, 20, 5000, 2, 30, 30, 10, 233, 153, new sbyte[7], isFlying: false, 0, new List<short> { 56, 57, 58, 59, 60, 61, 62 }, new List<short> { 77, 78, 79, 80, 81, 82, 83 }, null, 32, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), 20));
		_dataArray.Add(new CarrierItem(33, LocalStringManager.GetConfig("Carrier_language", "Name_33"), 4, 402, 4, 27, "icon_Carrier_huabao", LocalStringManager.GetConfig("Carrier_language", "Desc_33"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_33"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: true, 300, 0, 4650, 2, 10, 4200, 7, allowRandomCreate: true, 25, isSpecial: false, 0, 12, -1, new List<int>(), 9, -1, 25, 6000, 2, 35, 35, 15, 234, 154, new sbyte[7], isFlying: false, 0, new List<short> { 63, 64, 65, 66, 67, 68, 69 }, new List<short> { 70, 71, 72, 73, 74, 75, 76 }, null, 33, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), 20));
		_dataArray.Add(new CarrierItem(34, LocalStringManager.GetConfig("Carrier_language", "Name_34"), 4, 402, 4, 27, "icon_Carrier_shizi", LocalStringManager.GetConfig("Carrier_language", "Desc_34"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_34"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: true, 300, 0, 4650, 2, 10, 4200, 7, allowRandomCreate: true, 25, isSpecial: false, 0, 12, -1, new List<int>(), 9, -1, 25, 6000, 2, 35, 35, 15, 235, 155, new sbyte[7], isFlying: false, 0, new List<short> { 63, 64, 65, 66, 67, 68, 69 }, new List<short> { 70, 71, 72, 73, 74, 75, 76 }, null, 34, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), 20));
		_dataArray.Add(new CarrierItem(35, LocalStringManager.GetConfig("Carrier_language", "Name_35"), 4, 402, 4, 27, "icon_Carrier_laohu", LocalStringManager.GetConfig("Carrier_language", "Desc_35"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_35"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: true, 300, 0, 4650, 2, 10, 4200, 7, allowRandomCreate: true, 25, isSpecial: false, 0, 12, -1, new List<int>(), 9, -1, 25, 6000, 2, 35, 35, 15, 236, 156, new sbyte[7], isFlying: false, 0, new List<short> { 63, 64, 65, 66, 67, 68, 69 }, new List<short> { 70, 71, 72, 73, 74, 75, 76 }, null, 35, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), 20));
		_dataArray.Add(new CarrierItem(36, LocalStringManager.GetConfig("Carrier_language", "Name_36"), 4, 402, 5, 27, "icon_Carrier_linghou", LocalStringManager.GetConfig("Carrier_language", "Desc_36"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_36"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: true, 300, 0, 8400, 3, 12, 5400, 7, allowRandomCreate: true, 20, isSpecial: false, 0, 12, -1, new List<int>(), 9, -1, 30, 7000, 2, 40, 40, 20, 237, 157, new sbyte[7], isFlying: false, 0, new List<short> { 70, 71, 72, 73, 74, 75, 76 }, new List<short> { 63, 64, 65, 66, 67, 68, 69 }, null, 36, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), 40));
		_dataArray.Add(new CarrierItem(37, LocalStringManager.GetConfig("Carrier_language", "Name_37"), 4, 402, 5, 27, "icon_Carrier_jinpeng", LocalStringManager.GetConfig("Carrier_language", "Desc_37"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_37"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: true, 300, 0, 8400, 3, 12, 5400, 7, allowRandomCreate: true, 20, isSpecial: false, 0, 12, -1, new List<int>(), 9, -1, 30, 7000, 2, 40, 40, 20, 238, 158, new sbyte[7], isFlying: true, 0, new List<short> { 63, 64, 65, 66, 67, 68, 69 }, new List<short> { 56, 57, 58, 59, 60, 61, 62 }, null, 37, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), 40));
		_dataArray.Add(new CarrierItem(38, LocalStringManager.GetConfig("Carrier_language", "Name_38"), 4, 402, 5, 27, "icon_Carrier_xuanzhu", LocalStringManager.GetConfig("Carrier_language", "Desc_38"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_38"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: true, 300, 0, 8400, 3, 12, 5400, 7, allowRandomCreate: true, 20, isSpecial: false, 0, 12, -1, new List<int>(), 9, -1, 30, 7000, 2, 40, 40, 20, 239, 159, new sbyte[7], isFlying: false, 0, new List<short> { 56, 57, 58, 59, 60, 61, 62 }, new List<short> { 77, 78, 79, 80, 81, 82, 83 }, null, 38, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), 40));
		_dataArray.Add(new CarrierItem(39, LocalStringManager.GetConfig("Carrier_language", "Name_39"), 4, 402, 6, 27, "icon_Carrier_baixiong", LocalStringManager.GetConfig("Carrier_language", "Desc_39"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_39"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: true, 300, 0, 13800, 4, 14, 7200, 8, allowRandomCreate: true, 15, isSpecial: false, 0, 12, -1, new List<int>(), 9, -1, 35, 8000, 3, 45, 45, 25, 240, 160, new sbyte[7], isFlying: false, 0, new List<short> { 77, 78, 79, 80, 81, 82, 83 }, new List<short> { 56, 57, 58, 59, 60, 61, 62 }, null, 39, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), 40));
		_dataArray.Add(new CarrierItem(40, LocalStringManager.GetConfig("Carrier_language", "Name_40"), 4, 402, 6, 27, "icon_Carrier_kuiniu", LocalStringManager.GetConfig("Carrier_language", "Desc_40"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_40"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: true, 300, 0, 13800, 4, 14, 7200, 8, allowRandomCreate: true, 15, isSpecial: false, 0, 12, -1, new List<int>(), 9, -1, 35, 8000, 3, 45, 45, 25, 241, 161, new sbyte[7], isFlying: false, 0, new List<short> { 70, 71, 72, 73, 74, 75, 76 }, new List<short> { 63, 64, 65, 66, 67, 68, 69 }, null, 40, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), 40));
		_dataArray.Add(new CarrierItem(41, LocalStringManager.GetConfig("Carrier_language", "Name_41"), 4, 402, 6, 27, "icon_Carrier_bamang", LocalStringManager.GetConfig("Carrier_language", "Desc_41"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_41"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: true, 300, 0, 13800, 4, 14, 7200, 8, allowRandomCreate: true, 15, isSpecial: false, 0, 12, -1, new List<int>(), 9, -1, 35, 8000, 3, 45, 45, 25, 242, 162, new sbyte[7], isFlying: false, 0, new List<short> { 56, 57, 58, 59, 60, 61, 62 }, new List<short> { 77, 78, 79, 80, 81, 82, 83 }, null, 41, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), 40));
		_dataArray.Add(new CarrierItem(42, LocalStringManager.GetConfig("Carrier_language", "Name_42"), 4, 402, 7, 27, "icon_Carrier_heibao", LocalStringManager.GetConfig("Carrier_language", "Desc_42"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_42"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: true, 300, 0, 21150, 5, 16, 9000, 8, allowRandomCreate: true, 10, isSpecial: false, 0, 12, -1, new List<int>(), 9, -1, 40, 9000, 3, 50, 50, 30, 243, 163, new sbyte[7], isFlying: false, 0, new List<short> { 63, 64, 65, 66, 67, 68, 69 }, new List<short> { 70, 71, 72, 73, 74, 75, 76 }, null, 42, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), 40));
		_dataArray.Add(new CarrierItem(43, LocalStringManager.GetConfig("Carrier_language", "Name_43"), 4, 402, 7, 27, "icon_Carrier_jinshi", LocalStringManager.GetConfig("Carrier_language", "Desc_43"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_43"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: true, 300, 0, 21150, 5, 16, 9000, 8, allowRandomCreate: true, 10, isSpecial: false, 0, 12, -1, new List<int>(), 9, -1, 40, 9000, 3, 50, 50, 30, 244, 164, new sbyte[7], isFlying: false, 0, new List<short> { 63, 64, 65, 66, 67, 68, 69 }, new List<short> { 70, 71, 72, 73, 74, 75, 76 }, null, 43, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), 40));
		_dataArray.Add(new CarrierItem(44, LocalStringManager.GetConfig("Carrier_language", "Name_44"), 4, 402, 7, 27, "icon_Carrier_baihu", LocalStringManager.GetConfig("Carrier_language", "Desc_44"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_44"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: true, 300, 0, 21150, 5, 16, 9000, 8, allowRandomCreate: true, 10, isSpecial: false, 0, 12, -1, new List<int>(), 9, -1, 40, 9000, 3, 50, 50, 30, 245, 165, new sbyte[7], isFlying: false, 0, new List<short> { 63, 64, 65, 66, 67, 68, 69 }, new List<short> { 70, 71, 72, 73, 74, 75, 76 }, null, 44, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), 40));
		_dataArray.Add(new CarrierItem(45, LocalStringManager.GetConfig("Carrier_language", "Name_45"), 4, 401, 2, -1, "icon_Carrier_luozi", LocalStringManager.GetConfig("Carrier_language", "Desc_45"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_45"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: true, 300, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, 0, -1, -1, new List<int>(), 8, -1, 40, 10000, 0, 0, 0, 0, -1, -1, new sbyte[7], isFlying: false, -1, null, null, null, 20, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), 0));
		_dataArray.Add(new CarrierItem(46, LocalStringManager.GetConfig("Carrier_language", "Name_46"), 4, 403, 5, -1, "icon_Carrier_baijiao", LocalStringManager.GetConfig("Carrier_language", "Desc_46"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_46"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: true, 600, 0, 20, 3, 0, 150, 8, allowRandomCreate: true, 0, isSpecial: true, 0, 36, -1, new List<int>(), 9, -1, 0, 0, 0, 0, 0, 0, 256, 168, new sbyte[7] { 35, 0, 0, 0, 0, 0, 0 }, isFlying: false, 0, new List<short> { 56, 57, 58, 59, 60, 61, 62 }, new List<short> { 70, 71, 72, 73, 74, 75, 76 }, "NpcFace_baijiao", 45, new PoisonsAndLevels(60, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0), 60));
		_dataArray.Add(new CarrierItem(47, LocalStringManager.GetConfig("Carrier_language", "Name_47"), 4, 403, 5, -1, "icon_Carrier_heijiao", LocalStringManager.GetConfig("Carrier_language", "Desc_47"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_47"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: true, 600, 0, 20, 3, 0, 150, 8, allowRandomCreate: true, 0, isSpecial: true, 0, 36, -1, new List<int>(), 9, -1, 0, 0, 0, 0, 0, 0, 257, 169, new sbyte[7] { 0, 35, 0, 0, 0, 0, 0 }, isFlying: false, 0, new List<short> { 63, 64, 65, 66, 67, 68, 69 }, new List<short> { 70, 71, 72, 73, 74, 75, 76 }, "NpcFace_heijiao", 45, new PoisonsAndLevels(0, 0, 0, 0, 60, 2, 0, 0, 0, 0, 0, 0), 60));
		_dataArray.Add(new CarrierItem(48, LocalStringManager.GetConfig("Carrier_language", "Name_48"), 4, 403, 5, -1, "icon_Carrier_qingjiao", LocalStringManager.GetConfig("Carrier_language", "Desc_48"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_48"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: true, 600, 0, 20, 3, 0, 150, 8, allowRandomCreate: true, 0, isSpecial: true, 0, 36, -1, new List<int>(), 9, -1, 0, 0, 0, 0, 0, 0, 258, 170, new sbyte[7] { 0, 0, 35, 0, 0, 0, 0 }, isFlying: false, 0, new List<short> { 77, 78, 79, 80, 81, 82, 83 }, new List<short> { 70, 71, 72, 73, 74, 75, 76 }, "NpcFace_qingjiao", 45, new PoisonsAndLevels(0, 0, 60, 2, 0, 0, 0, 0, 0, 0, 0, 0), 60));
		_dataArray.Add(new CarrierItem(49, LocalStringManager.GetConfig("Carrier_language", "Name_49"), 4, 403, 5, -1, "icon_Carrier_chijiao", LocalStringManager.GetConfig("Carrier_language", "Desc_49"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_49"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: true, 600, 0, 20, 3, 0, 150, 8, allowRandomCreate: true, 0, isSpecial: true, 0, 36, -1, new List<int>(), 9, -1, 0, 0, 0, 0, 0, 0, 259, 171, new sbyte[7] { 0, 0, 0, 35, 0, 0, 0 }, isFlying: false, 0, new List<short> { 56, 57, 58, 59, 60, 61, 62 }, new List<short> { 70, 71, 72, 73, 74, 75, 76 }, "NpcFace_chijiao", 45, new PoisonsAndLevels(0, 0, 0, 0, 0, 0, 60, 2, 0, 0, 0, 0), 60));
		_dataArray.Add(new CarrierItem(50, LocalStringManager.GetConfig("Carrier_language", "Name_50"), 4, 403, 5, -1, "icon_Carrier_huangjiao", LocalStringManager.GetConfig("Carrier_language", "Desc_50"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_50"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: true, 600, 0, 20, 3, 0, 150, 8, allowRandomCreate: true, 0, isSpecial: true, 0, 36, -1, new List<int>(), 9, -1, 0, 0, 0, 0, 0, 0, 260, 172, new sbyte[7] { 0, 0, 0, 0, 35, 0, 0 }, isFlying: false, 0, new List<short> { 63, 64, 65, 66, 67, 68, 69 }, new List<short> { 70, 71, 72, 73, 74, 75, 76 }, "NpcFace_huangjiao", 45, new PoisonsAndLevels(0, 0, 0, 0, 0, 0, 0, 0, 60, 2, 0, 0), 60));
		_dataArray.Add(new CarrierItem(51, LocalStringManager.GetConfig("Carrier_language", "Name_51"), 4, 403, 5, -1, "icon_Carrier_yinyangjiao", LocalStringManager.GetConfig("Carrier_language", "Desc_51"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_51"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: true, 600, 0, 20, 3, 0, 150, 8, allowRandomCreate: true, 0, isSpecial: true, 0, 36, -1, new List<int>(), 9, -1, 0, 0, 0, 0, 0, 0, 261, 173, new sbyte[7] { 20, 20, 0, 0, 0, 0, 0 }, isFlying: false, 0, new List<short> { 77, 78, 79, 80, 81, 82, 83 }, new List<short> { 70, 71, 72, 73, 74, 75, 76 }, "NpcFace_baiheijiao", 45, new PoisonsAndLevels(80, 2, 0, 0, 80, 2, 0, 0, 0, 0, 0, 0), 80));
		_dataArray.Add(new CarrierItem(52, LocalStringManager.GetConfig("Carrier_language", "Name_52"), 4, 403, 5, -1, "icon_Carrier_feidianjiao", LocalStringManager.GetConfig("Carrier_language", "Desc_52"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_52"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: true, 600, 0, 20, 3, 0, 150, 8, allowRandomCreate: true, 0, isSpecial: true, 0, 36, -1, new List<int>(), 9, -1, 0, 0, 0, 0, 0, 0, 262, 174, new sbyte[7] { 20, 0, 20, 0, 0, 0, 0 }, isFlying: false, 0, new List<short> { 56, 57, 58, 59, 60, 61, 62 }, new List<short> { 70, 71, 72, 73, 74, 75, 76 }, "NpcFace_baiqingjiao", 45, new PoisonsAndLevels(80, 2, 80, 2, 0, 0, 0, 0, 0, 0, 0, 0), 80));
		_dataArray.Add(new CarrierItem(53, LocalStringManager.GetConfig("Carrier_language", "Name_53"), 4, 403, 5, -1, "icon_Carrier_leihuojiao", LocalStringManager.GetConfig("Carrier_language", "Desc_53"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_53"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: true, 600, 0, 20, 3, 0, 150, 8, allowRandomCreate: true, 0, isSpecial: true, 0, 36, -1, new List<int>(), 9, -1, 0, 0, 0, 0, 0, 0, 263, 175, new sbyte[7] { 20, 0, 0, 20, 0, 0, 0 }, isFlying: false, 0, new List<short> { 63, 64, 65, 66, 67, 68, 69 }, new List<short> { 70, 71, 72, 73, 74, 75, 76 }, "NpcFace_baichijiao", 45, new PoisonsAndLevels(80, 2, 0, 0, 0, 0, 80, 2, 0, 0, 0, 0), 80));
		_dataArray.Add(new CarrierItem(54, LocalStringManager.GetConfig("Carrier_language", "Name_54"), 4, 403, 5, -1, "icon_Carrier_jinyanjiao", LocalStringManager.GetConfig("Carrier_language", "Desc_54"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_54"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: true, 600, 0, 20, 3, 0, 150, 8, allowRandomCreate: true, 0, isSpecial: true, 0, 36, -1, new List<int>(), 9, -1, 0, 0, 0, 0, 0, 0, 264, 176, new sbyte[7] { 20, 0, 0, 0, 20, 0, 0 }, isFlying: false, 0, new List<short> { 77, 78, 79, 80, 81, 82, 83 }, new List<short> { 70, 71, 72, 73, 74, 75, 76 }, "NpcFace_baihuangjiao", 45, new PoisonsAndLevels(80, 2, 0, 0, 0, 0, 0, 0, 80, 2, 0, 0), 80));
		_dataArray.Add(new CarrierItem(55, LocalStringManager.GetConfig("Carrier_language", "Name_55"), 4, 403, 5, -1, "icon_Carrier_qingzejiao", LocalStringManager.GetConfig("Carrier_language", "Desc_55"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_55"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: true, 600, 0, 20, 3, 0, 150, 8, allowRandomCreate: true, 0, isSpecial: true, 0, 36, -1, new List<int>(), 9, -1, 0, 0, 0, 0, 0, 0, 265, 177, new sbyte[7] { 0, 20, 20, 0, 0, 0, 0 }, isFlying: false, 0, new List<short> { 56, 57, 58, 59, 60, 61, 62 }, new List<short> { 70, 71, 72, 73, 74, 75, 76 }, "NpcFace_heiqingjiao", 45, new PoisonsAndLevels(0, 0, 80, 2, 80, 2, 0, 0, 0, 0, 0, 0), 80));
		_dataArray.Add(new CarrierItem(56, LocalStringManager.GetConfig("Carrier_language", "Name_56"), 4, 403, 5, -1, "icon_Carrier_shaoyunjiao", LocalStringManager.GetConfig("Carrier_language", "Desc_56"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_56"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: true, 600, 0, 20, 3, 0, 150, 8, allowRandomCreate: true, 0, isSpecial: true, 0, 36, -1, new List<int>(), 9, -1, 0, 0, 0, 0, 0, 0, 266, 178, new sbyte[7] { 0, 20, 0, 20, 0, 0, 0 }, isFlying: false, 0, new List<short> { 63, 64, 65, 66, 67, 68, 69 }, new List<short> { 70, 71, 72, 73, 74, 75, 76 }, "NpcFace_heichijiao", 45, new PoisonsAndLevels(0, 0, 0, 0, 80, 2, 80, 2, 0, 0, 0, 0), 80));
		_dataArray.Add(new CarrierItem(57, LocalStringManager.GetConfig("Carrier_language", "Name_57"), 4, 403, 5, -1, "icon_Carrier_nichijiao", LocalStringManager.GetConfig("Carrier_language", "Desc_57"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_57"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: true, 600, 0, 20, 3, 0, 150, 8, allowRandomCreate: true, 0, isSpecial: true, 0, 36, -1, new List<int>(), 9, -1, 0, 0, 0, 0, 0, 0, 267, 179, new sbyte[7] { 0, 20, 0, 0, 20, 0, 0 }, isFlying: false, 0, new List<short> { 77, 78, 79, 80, 81, 82, 83 }, new List<short> { 70, 71, 72, 73, 74, 75, 76 }, "NpcFace_heihuangjiao", 45, new PoisonsAndLevels(0, 0, 0, 0, 80, 2, 0, 0, 80, 2, 0, 0), 80));
		_dataArray.Add(new CarrierItem(58, LocalStringManager.GetConfig("Carrier_language", "Name_58"), 4, 403, 5, -1, "icon_Carrier_yanjiaojiao", LocalStringManager.GetConfig("Carrier_language", "Desc_58"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_58"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: true, 600, 0, 20, 3, 0, 150, 8, allowRandomCreate: true, 0, isSpecial: true, 0, 36, -1, new List<int>(), 9, -1, 0, 0, 0, 0, 0, 0, 268, 180, new sbyte[7] { 0, 0, 20, 20, 0, 0, 0 }, isFlying: false, 0, new List<short> { 56, 57, 58, 59, 60, 61, 62 }, new List<short> { 70, 71, 72, 73, 74, 75, 76 }, "NpcFace_qingchijiao", 45, new PoisonsAndLevels(0, 0, 80, 2, 0, 0, 80, 2, 0, 0, 0, 0), 80));
		_dataArray.Add(new CarrierItem(59, LocalStringManager.GetConfig("Carrier_language", "Name_59"), 4, 403, 5, -1, "icon_Carrier_fushanjiao", LocalStringManager.GetConfig("Carrier_language", "Desc_59"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_59"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: true, 600, 0, 20, 3, 0, 150, 8, allowRandomCreate: true, 0, isSpecial: true, 0, 36, -1, new List<int>(), 9, -1, 0, 0, 0, 0, 0, 0, 269, 181, new sbyte[7] { 0, 0, 20, 0, 20, 0, 0 }, isFlying: false, 0, new List<short> { 63, 64, 65, 66, 67, 68, 69 }, new List<short> { 70, 71, 72, 73, 74, 75, 76 }, "NpcFace_qinghuangjiao", 45, new PoisonsAndLevels(0, 0, 80, 2, 0, 0, 0, 0, 80, 2, 0, 0), 80));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new CarrierItem(60, LocalStringManager.GetConfig("Carrier_language", "Name_60"), 4, 403, 5, -1, "icon_Carrier_liangujiao", LocalStringManager.GetConfig("Carrier_language", "Desc_60"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_60"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: true, 600, 0, 20, 3, 0, 150, 8, allowRandomCreate: true, 0, isSpecial: true, 0, 36, -1, new List<int>(), 9, -1, 0, 0, 0, 0, 0, 0, 270, 182, new sbyte[7] { 0, 0, 0, 20, 20, 0, 0 }, isFlying: false, 0, new List<short> { 77, 78, 79, 80, 81, 82, 83 }, new List<short> { 70, 71, 72, 73, 74, 75, 76 }, "NpcFace_chihuangjiao", 45, new PoisonsAndLevels(0, 0, 0, 0, 0, 0, 80, 2, 80, 2, 0, 0), 80));
		_dataArray.Add(new CarrierItem(61, LocalStringManager.GetConfig("Carrier_language", "Name_61"), 4, 403, 5, -1, "icon_Carrier_naohaijiao", LocalStringManager.GetConfig("Carrier_language", "Desc_61"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_61"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: true, 600, 0, 20, 3, 0, 150, 8, allowRandomCreate: true, 0, isSpecial: true, 0, 36, -1, new List<int>(), 9, -1, 0, 0, 0, 0, 0, 0, 271, 183, new sbyte[7] { 15, 15, 15, 0, 20, 0, 0 }, isFlying: false, 0, new List<short> { 56, 57, 58, 59, 60, 61, 62 }, new List<short> { 70, 71, 72, 73, 74, 75, 76 }, "NpcFace_baiheiqingjiao", 45, new PoisonsAndLevels(100, 2, 100, 2, 100, 2, 0, 0, 0, 0, 0, 0), 80));
		_dataArray.Add(new CarrierItem(62, LocalStringManager.GetConfig("Carrier_language", "Name_62"), 4, 403, 5, -1, "icon_Carrier_piyunjiao", LocalStringManager.GetConfig("Carrier_language", "Desc_62"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_62"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: true, 600, 0, 20, 3, 0, 150, 8, allowRandomCreate: true, 0, isSpecial: true, 0, 36, -1, new List<int>(), 9, -1, 0, 0, 0, 0, 0, 0, 272, 184, new sbyte[7] { 15, 15, 0, 15, 0, 0, 0 }, isFlying: false, 0, new List<short> { 63, 64, 65, 66, 67, 68, 69 }, new List<short> { 70, 71, 72, 73, 74, 75, 76 }, "NpcFace_baiheichijiao", 45, new PoisonsAndLevels(100, 2, 0, 0, 100, 2, 100, 2, 0, 0, 0, 0), 80));
		_dataArray.Add(new CarrierItem(63, LocalStringManager.GetConfig("Carrier_language", "Name_63"), 4, 403, 5, -1, "icon_Carrier_yuanxiajiao", LocalStringManager.GetConfig("Carrier_language", "Desc_63"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_63"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: true, 600, 0, 20, 3, 0, 150, 8, allowRandomCreate: true, 0, isSpecial: true, 0, 36, -1, new List<int>(), 9, -1, 0, 0, 0, 0, 0, 0, 273, 185, new sbyte[7] { 15, 15, 0, 0, 15, 0, 0 }, isFlying: false, 0, new List<short> { 77, 78, 79, 80, 81, 82, 83 }, new List<short> { 70, 71, 72, 73, 74, 75, 76 }, "NpcFace_baiheihuangjiao", 45, new PoisonsAndLevels(100, 2, 0, 0, 100, 2, 0, 0, 100, 2, 0, 0), 80));
		_dataArray.Add(new CarrierItem(64, LocalStringManager.GetConfig("Carrier_language", "Name_64"), 4, 403, 5, -1, "icon_Carrier_tianleijiao", LocalStringManager.GetConfig("Carrier_language", "Desc_64"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_64"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: true, 600, 0, 20, 3, 0, 150, 8, allowRandomCreate: true, 0, isSpecial: true, 0, 36, -1, new List<int>(), 9, -1, 0, 0, 0, 0, 0, 0, 274, 186, new sbyte[7] { 15, 0, 15, 15, 0, 0, 0 }, isFlying: false, 0, new List<short> { 56, 57, 58, 59, 60, 61, 62 }, new List<short> { 70, 71, 72, 73, 74, 75, 76 }, "NpcFace_baiqingchijiao", 45, new PoisonsAndLevels(100, 2, 100, 2, 0, 0, 100, 2, 0, 0, 0, 0), 80));
		_dataArray.Add(new CarrierItem(65, LocalStringManager.GetConfig("Carrier_language", "Name_65"), 4, 403, 5, -1, "icon_Carrier_huangtujiao", LocalStringManager.GetConfig("Carrier_language", "Desc_65"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_65"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: true, 600, 0, 20, 3, 0, 150, 8, allowRandomCreate: true, 0, isSpecial: true, 0, 36, -1, new List<int>(), 9, -1, 0, 0, 0, 0, 0, 0, 275, 187, new sbyte[7] { 15, 0, 15, 0, 15, 0, 0 }, isFlying: false, 0, new List<short> { 63, 64, 65, 66, 67, 68, 69 }, new List<short> { 70, 71, 72, 73, 74, 75, 76 }, "NpcFace_baiqinghuangjiao", 45, new PoisonsAndLevels(100, 2, 100, 2, 0, 0, 0, 0, 100, 2, 0, 0), 80));
		_dataArray.Add(new CarrierItem(66, LocalStringManager.GetConfig("Carrier_language", "Name_66"), 4, 403, 5, -1, "icon_Carrier_qilinjiao", LocalStringManager.GetConfig("Carrier_language", "Desc_66"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_66"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: true, 600, 0, 20, 3, 0, 150, 8, allowRandomCreate: true, 0, isSpecial: true, 0, 36, -1, new List<int>(), 9, -1, 0, 0, 0, 0, 0, 0, 276, 188, new sbyte[7] { 15, 0, 0, 15, 15, 0, 0 }, isFlying: false, 0, new List<short> { 77, 78, 79, 80, 81, 82, 83 }, new List<short> { 70, 71, 72, 73, 74, 75, 76 }, "NpcFace_baichihuangjiao", 45, new PoisonsAndLevels(100, 2, 0, 0, 0, 0, 100, 2, 100, 2, 0, 0), 80));
		_dataArray.Add(new CarrierItem(67, LocalStringManager.GetConfig("Carrier_language", "Name_67"), 4, 403, 5, -1, "icon_Carrier_guiyujiao", LocalStringManager.GetConfig("Carrier_language", "Desc_67"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_67"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: true, 600, 0, 20, 3, 0, 150, 8, allowRandomCreate: true, 0, isSpecial: true, 0, 36, -1, new List<int>(), 9, -1, 0, 0, 0, 0, 0, 0, 277, 189, new sbyte[7] { 0, 15, 15, 15, 0, 0, 0 }, isFlying: false, 0, new List<short> { 56, 57, 58, 59, 60, 61, 62 }, new List<short> { 70, 71, 72, 73, 74, 75, 76 }, "NpcFace_heiqingchijiao", 45, new PoisonsAndLevels(0, 0, 100, 2, 100, 2, 100, 2, 0, 0, 0, 0), 80));
		_dataArray.Add(new CarrierItem(68, LocalStringManager.GetConfig("Carrier_language", "Name_68"), 4, 403, 5, -1, "icon_Carrier_xianshanjiao", LocalStringManager.GetConfig("Carrier_language", "Desc_68"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_68"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: true, 600, 0, 20, 3, 0, 150, 8, allowRandomCreate: true, 0, isSpecial: true, 0, 36, -1, new List<int>(), 9, -1, 0, 0, 0, 0, 0, 0, 278, 190, new sbyte[7] { 0, 15, 15, 0, 15, 0, 0 }, isFlying: false, 0, new List<short> { 63, 64, 65, 66, 67, 68, 69 }, new List<short> { 70, 71, 72, 73, 74, 75, 76 }, "NpcFace_heiqinghuangjiao", 45, new PoisonsAndLevels(0, 0, 100, 2, 100, 2, 0, 0, 100, 2, 0, 0), 80));
		_dataArray.Add(new CarrierItem(69, LocalStringManager.GetConfig("Carrier_language", "Name_69"), 4, 403, 5, -1, "icon_Carrier_huochijiao", LocalStringManager.GetConfig("Carrier_language", "Desc_69"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_69"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: true, 600, 0, 20, 3, 0, 150, 8, allowRandomCreate: true, 0, isSpecial: true, 0, 36, -1, new List<int>(), 9, -1, 0, 0, 0, 0, 0, 0, 279, 191, new sbyte[7] { 0, 15, 0, 15, 15, 0, 0 }, isFlying: false, 0, new List<short> { 77, 78, 79, 80, 81, 82, 83 }, new List<short> { 70, 71, 72, 73, 74, 75, 76 }, "NpcFace_heichihuangjiao", 45, new PoisonsAndLevels(0, 0, 0, 0, 100, 2, 100, 2, 100, 2, 0, 0), 80));
		_dataArray.Add(new CarrierItem(70, LocalStringManager.GetConfig("Carrier_language", "Name_70"), 4, 403, 5, -1, "icon_Carrier_fenshanjiao", LocalStringManager.GetConfig("Carrier_language", "Desc_70"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_70"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: true, 600, 0, 20, 3, 0, 150, 8, allowRandomCreate: true, 0, isSpecial: true, 0, 36, -1, new List<int>(), 9, -1, 0, 0, 0, 0, 0, 0, 280, 192, new sbyte[7] { 0, 0, 15, 15, 15, 0, 0 }, isFlying: false, 0, new List<short> { 56, 57, 58, 59, 60, 61, 62 }, new List<short> { 70, 71, 72, 73, 74, 75, 76 }, "NpcFace_qingchihuangjiao", 45, new PoisonsAndLevels(0, 0, 100, 2, 0, 0, 100, 2, 100, 2, 0, 0), 80));
		_dataArray.Add(new CarrierItem(71, LocalStringManager.GetConfig("Carrier_language", "Name_71"), 4, 403, 5, -1, "icon_Carrier_sihuajiao", LocalStringManager.GetConfig("Carrier_language", "Desc_71"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_71"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: true, 600, 0, 20, 3, 0, 150, 8, allowRandomCreate: true, 0, isSpecial: true, 0, 36, -1, new List<int>(), 9, -1, 0, 0, 0, 0, 0, 0, 281, 193, new sbyte[7] { 10, 10, 10, 10, 0, 0, 0 }, isFlying: false, 0, new List<short> { 63, 64, 65, 66, 67, 68, 69 }, new List<short> { 70, 71, 72, 73, 74, 75, 76 }, "NpcFace_baiheiqingchijiao", 45, new PoisonsAndLevels(100, 3, 100, 3, 100, 3, 100, 3, 0, 0, 0, 0), 80));
		_dataArray.Add(new CarrierItem(72, LocalStringManager.GetConfig("Carrier_language", "Name_72"), 4, 403, 5, -1, "icon_Carrier_baibaojiao", LocalStringManager.GetConfig("Carrier_language", "Desc_72"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_72"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: true, 600, 0, 20, 3, 0, 150, 8, allowRandomCreate: true, 0, isSpecial: true, 0, 36, -1, new List<int>(), 9, -1, 0, 0, 0, 0, 0, 0, 282, 194, new sbyte[7] { 10, 10, 10, 0, 10, 0, 0 }, isFlying: false, 0, new List<short> { 77, 78, 79, 80, 81, 82, 83 }, new List<short> { 70, 71, 72, 73, 74, 75, 76 }, "NpcFace_baiheiqinghuangjiao", 45, new PoisonsAndLevels(100, 3, 100, 3, 100, 3, 0, 0, 100, 3, 0, 0), 80));
		_dataArray.Add(new CarrierItem(73, LocalStringManager.GetConfig("Carrier_language", "Name_73"), 4, 403, 5, -1, "icon_Carrier_zhenhaijiao", LocalStringManager.GetConfig("Carrier_language", "Desc_73"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_73"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: true, 600, 0, 20, 3, 0, 150, 8, allowRandomCreate: true, 0, isSpecial: true, 0, 36, -1, new List<int>(), 9, -1, 0, 0, 0, 0, 0, 0, 283, 195, new sbyte[7] { 10, 10, 0, 10, 10, 0, 0 }, isFlying: false, 0, new List<short> { 56, 57, 58, 59, 60, 61, 62 }, new List<short> { 70, 71, 72, 73, 74, 75, 76 }, "NpcFace_baiheichihuangjiao", 45, new PoisonsAndLevels(100, 3, 0, 0, 100, 3, 100, 3, 100, 3, 0, 0), 80));
		_dataArray.Add(new CarrierItem(74, LocalStringManager.GetConfig("Carrier_language", "Name_74"), 4, 403, 5, -1, "icon_Carrier_tuntianjiao", LocalStringManager.GetConfig("Carrier_language", "Desc_74"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_74"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: true, 600, 0, 20, 3, 0, 150, 8, allowRandomCreate: true, 0, isSpecial: true, 0, 36, -1, new List<int>(), 9, -1, 0, 0, 0, 0, 0, 0, 284, 196, new sbyte[7] { 10, 0, 10, 10, 10, 0, 0 }, isFlying: false, 0, new List<short> { 63, 64, 65, 66, 67, 68, 69 }, new List<short> { 70, 71, 72, 73, 74, 75, 76 }, "NpcFace_baiqingchihuangjiao", 45, new PoisonsAndLevels(100, 3, 100, 3, 0, 0, 100, 3, 100, 3, 0, 0), 80));
		_dataArray.Add(new CarrierItem(75, LocalStringManager.GetConfig("Carrier_language", "Name_75"), 4, 403, 5, -1, "icon_Carrier_luanlingjiao", LocalStringManager.GetConfig("Carrier_language", "Desc_75"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_75"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: true, 600, 0, 20, 3, 0, 150, 8, allowRandomCreate: true, 0, isSpecial: true, 0, 36, -1, new List<int>(), 9, -1, 0, 0, 0, 0, 0, 0, 285, 197, new sbyte[7] { 0, 10, 10, 10, 10, 0, 0 }, isFlying: false, 0, new List<short> { 77, 78, 79, 80, 81, 82, 83 }, new List<short> { 70, 71, 72, 73, 74, 75, 76 }, "NpcFace_heiqingchihuangjiao", 45, new PoisonsAndLevels(0, 0, 100, 3, 100, 3, 100, 3, 100, 3, 0, 0), 80));
		_dataArray.Add(new CarrierItem(76, LocalStringManager.GetConfig("Carrier_language", "Name_76"), 4, 403, 5, -1, "icon_Carrier_wusejiao", LocalStringManager.GetConfig("Carrier_language", "Desc_76"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_76"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: true, 600, 0, 20, 3, 0, 150, 8, allowRandomCreate: true, 0, isSpecial: true, 0, 36, -1, new List<int>(), 9, -1, 0, 0, 0, 0, 0, 0, 286, 198, new sbyte[7] { 10, 10, 10, 10, 10, 0, 0 }, isFlying: false, 0, new List<short> { 56, 57, 58, 59, 60, 61, 62 }, new List<short> { 70, 71, 72, 73, 74, 75, 76 }, "NpcFace_baiqingchihuangheijiao", 45, new PoisonsAndLevels(100, 3, 100, 3, 100, 3, 100, 3, 100, 3, 0, 0), 80));
		_dataArray.Add(new CarrierItem(77, LocalStringManager.GetConfig("Carrier_language", "Name_77"), 4, 404, 8, -1, "icon_Carrier_qiuniu", LocalStringManager.GetConfig("Carrier_language", "Desc_77"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_77"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: true, 900, 0, 20, 6, 0, 150, 8, allowRandomCreate: true, 0, isSpecial: true, 0, 36, -1, new List<int>(), 9, -1, 0, 0, 0, 0, 0, 0, 287, 199, new sbyte[7], isFlying: false, 0, new List<short> { 70, 71, 72, 73, 74, 75, 76 }, new List<short> { 77, 78, 79, 80, 81, 82, 83 }, "NpcFace_qiuniu_loong", 46, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), 100));
		_dataArray.Add(new CarrierItem(78, LocalStringManager.GetConfig("Carrier_language", "Name_78"), 4, 404, 8, -1, "icon_Carrier_yazi", LocalStringManager.GetConfig("Carrier_language", "Desc_78"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_78"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: true, 900, 0, 20, 6, 0, 150, 8, allowRandomCreate: true, 0, isSpecial: true, 0, 36, -1, new List<int>(), 9, -1, 0, 0, 0, 0, 0, 0, 288, 200, new sbyte[7], isFlying: false, 0, new List<short> { 63, 64, 65, 66, 67, 68, 69 }, new List<short> { 77, 78, 79, 80, 81, 82, 83 }, "NpcFace_yazi_loong", 47, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), 100));
		_dataArray.Add(new CarrierItem(79, LocalStringManager.GetConfig("Carrier_language", "Name_79"), 4, 404, 8, -1, "icon_Carrier_chaofeng", LocalStringManager.GetConfig("Carrier_language", "Desc_79"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_79"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: true, 900, 0, 20, 6, 0, 150, 8, allowRandomCreate: true, 0, isSpecial: true, 0, 36, -1, new List<int>(), 9, -1, 0, 0, 0, 0, 0, 0, 289, 201, new sbyte[7], isFlying: false, 0, new List<short> { 70, 71, 72, 73, 74, 75, 76 }, new List<short> { 56, 57, 58, 59, 60, 61, 62 }, "NpcFace_chaofeng_loong", 48, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), 100));
		_dataArray.Add(new CarrierItem(80, LocalStringManager.GetConfig("Carrier_language", "Name_80"), 4, 404, 8, -1, "icon_Carrier_pulao", LocalStringManager.GetConfig("Carrier_language", "Desc_80"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_80"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: true, 900, 0, 20, 6, 0, 150, 8, allowRandomCreate: true, 0, isSpecial: true, 0, 36, -1, new List<int>(), 9, -1, 0, 0, 0, 0, 0, 0, 290, 202, new sbyte[7], isFlying: false, 0, new List<short> { 77, 78, 79, 80, 81, 82, 83 }, new List<short> { 63, 64, 65, 66, 67, 68, 69 }, "NpcFace_pulao_loong", 49, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), 100));
		_dataArray.Add(new CarrierItem(81, LocalStringManager.GetConfig("Carrier_language", "Name_81"), 4, 404, 8, -1, "icon_Carrier_suanni", LocalStringManager.GetConfig("Carrier_language", "Desc_81"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_81"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: true, 900, 0, 20, 6, 0, 150, 8, allowRandomCreate: true, 0, isSpecial: true, 0, 36, -1, new List<int>(), 9, -1, 0, 0, 0, 0, 0, 0, 291, 203, new sbyte[7], isFlying: false, 0, new List<short> { 63, 64, 65, 66, 67, 68, 69 }, new List<short> { 56, 57, 58, 59, 60, 61, 62 }, "NpcFace_suanni_loong", 50, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), 100));
		_dataArray.Add(new CarrierItem(82, LocalStringManager.GetConfig("Carrier_language", "Name_82"), 4, 404, 8, -1, "icon_Carrier_baxia", LocalStringManager.GetConfig("Carrier_language", "Desc_82"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_82"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: true, 900, 0, 20, 6, 0, 150, 8, allowRandomCreate: true, 0, isSpecial: true, 0, 36, -1, new List<int>(), 9, -1, 0, 0, 0, 0, 0, 0, 292, 204, new sbyte[7], isFlying: false, 0, new List<short> { 70, 71, 72, 73, 74, 75, 76 }, new List<short> { 77, 78, 79, 80, 81, 82, 83 }, "NpcFace_baxia_loong", 51, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), 100));
		_dataArray.Add(new CarrierItem(83, LocalStringManager.GetConfig("Carrier_language", "Name_83"), 4, 404, 8, -1, "icon_Carrier_bian", LocalStringManager.GetConfig("Carrier_language", "Desc_83"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_83"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: true, 900, 0, 20, 6, 0, 150, 8, allowRandomCreate: true, 0, isSpecial: true, 0, 36, -1, new List<int>(), 9, -1, 0, 0, 0, 0, 0, 0, 293, 205, new sbyte[7], isFlying: false, 0, new List<short> { 63, 64, 65, 66, 67, 68, 69 }, new List<short> { 70, 71, 72, 73, 74, 75, 76 }, "NpcFace_bian_loong", 52, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), 100));
		_dataArray.Add(new CarrierItem(84, LocalStringManager.GetConfig("Carrier_language", "Name_84"), 4, 404, 8, -1, "icon_Carrier_fuxi", LocalStringManager.GetConfig("Carrier_language", "Desc_84"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_84"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: true, 900, 0, 20, 6, 0, 150, 8, allowRandomCreate: true, 0, isSpecial: true, 0, 36, -1, new List<int>(), 9, -1, 0, 0, 0, 0, 0, 0, 294, 206, new sbyte[7], isFlying: false, 0, new List<short> { 56, 57, 58, 59, 60, 61, 62 }, new List<short> { 63, 64, 65, 66, 67, 68, 69 }, "NpcFace_fuxi_loong", 53, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), 100));
		_dataArray.Add(new CarrierItem(85, LocalStringManager.GetConfig("Carrier_language", "Name_85"), 4, 404, 8, -1, "icon_Carrier_chiwen", LocalStringManager.GetConfig("Carrier_language", "Desc_85"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_85"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: true, 900, 0, 20, 6, 0, 150, 8, allowRandomCreate: true, 0, isSpecial: true, 0, 36, -1, new List<int>(), 9, -1, 0, 0, 0, 0, 0, 0, 295, 207, new sbyte[7], isFlying: false, 0, new List<short> { 70, 71, 72, 73, 74, 75, 76 }, new List<short> { 77, 78, 79, 80, 81, 82, 83 }, "NpcFace_chiwen_loong", 54, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), 100));
		_dataArray.Add(new CarrierItem(86, LocalStringManager.GetConfig("Carrier_language", "Name_86"), 4, 405, 8, -1, "icon_Carrier_wusejiao", LocalStringManager.GetConfig("Carrier_language", "Desc_86"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_86"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, detachable: true, 800, 0, 61500, 6, 18, 10800, 8, allowRandomCreate: true, 0, isSpecial: true, 0, 36, -1, new List<int>(), 9, -1, 90, 10000, 6, 75, 75, 40, 246, 253, new sbyte[7], isFlying: false, 0, new List<short> { 56, 57, 58, 59, 60, 61, 62 }, new List<short> { 70, 71, 72, 73, 74, 75, 76 }, "NpcFace_bailong", 57, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), 100));
		_dataArray.Add(new CarrierItem(87, LocalStringManager.GetConfig("Carrier_language", "Name_87"), 4, 405, 8, -1, "icon_Carrier_wusejiao", LocalStringManager.GetConfig("Carrier_language", "Desc_87"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_87"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, detachable: true, 800, 0, 61500, 6, 18, 10800, 8, allowRandomCreate: true, 0, isSpecial: true, 0, 36, -1, new List<int>(), 9, -1, 30, 10000, 18, 75, 75, 40, 247, 254, new sbyte[7], isFlying: false, 0, new List<short> { 63, 64, 65, 66, 67, 68, 69 }, new List<short> { 70, 71, 72, 73, 74, 75, 76 }, "NpcFace_heilong", 58, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), 100));
		_dataArray.Add(new CarrierItem(88, LocalStringManager.GetConfig("Carrier_language", "Name_88"), 4, 405, 8, -1, "icon_Carrier_wusejiao", LocalStringManager.GetConfig("Carrier_language", "Desc_88"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_88"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, detachable: true, 800, 0, 61500, 6, 18, 10800, 8, allowRandomCreate: true, 0, isSpecial: true, 0, 36, -1, new List<int>(), 9, -1, 30, 10000, 6, 200, 75, 40, 248, 255, new sbyte[7], isFlying: false, 0, new List<short> { 77, 78, 79, 80, 81, 82, 83 }, new List<short> { 70, 71, 72, 73, 74, 75, 76 }, "NpcFace_qinglong", 59, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), 100));
		_dataArray.Add(new CarrierItem(89, LocalStringManager.GetConfig("Carrier_language", "Name_89"), 4, 405, 8, -1, "icon_Carrier_wusejiao", LocalStringManager.GetConfig("Carrier_language", "Desc_89"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_89"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, detachable: true, 800, 0, 61500, 6, 18, 10800, 8, allowRandomCreate: true, 0, isSpecial: true, 0, 36, -1, new List<int>(), 9, -1, 30, 10000, 6, 75, 200, 80, 249, 256, new sbyte[7], isFlying: false, 0, new List<short> { 56, 57, 58, 59, 60, 61, 62 }, new List<short> { 70, 71, 72, 73, 74, 75, 76 }, "NpcFace_chilong", 60, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), 100));
		_dataArray.Add(new CarrierItem(90, LocalStringManager.GetConfig("Carrier_language", "Name_90"), 4, 405, 8, -1, "icon_Carrier_wusejiao", LocalStringManager.GetConfig("Carrier_language", "Desc_90"), LocalStringManager.GetConfig("Carrier_language", "FunctionDesc_90"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, detachable: true, 800, 0, 61500, 6, 18, 10800, 8, allowRandomCreate: true, 0, isSpecial: true, 0, 36, -1, new List<int>(), 9, -1, 30, 30000, 6, 75, 75, 40, 250, 257, new sbyte[7], isFlying: false, 0, new List<short> { 63, 64, 65, 66, 67, 68, 69 }, new List<short> { 70, 71, 72, 73, 74, 75, 76 }, "NpcFace_huanglong", 61, new PoisonsAndLevels(default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short), default(short)), 100));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<CarrierItem>(91);
		CreateItems0();
		CreateItems1();
	}
}
