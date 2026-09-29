using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class CraftTool : ConfigData<CraftToolItem, short>
{
	public static class DefKey
	{
		public const short Wood0 = 0;

		public const short Wood1 = 1;

		public const short Wood2 = 2;

		public const short Wood3 = 3;

		public const short Wood4 = 4;

		public const short Wood5 = 5;

		public const short Wood6 = 6;

		public const short Wood7 = 7;

		public const short Wood8 = 8;

		public const short Metal0 = 9;

		public const short Metal1 = 10;

		public const short Metal2 = 11;

		public const short Metal3 = 12;

		public const short Metal4 = 13;

		public const short Metal5 = 14;

		public const short Metal6 = 15;

		public const short Metal7 = 16;

		public const short Metal8 = 17;

		public const short Jade0 = 18;

		public const short Jade1 = 19;

		public const short Jade2 = 20;

		public const short Jade3 = 21;

		public const short Jade4 = 22;

		public const short Jade5 = 23;

		public const short Jade6 = 24;

		public const short Jade7 = 25;

		public const short Jade8 = 26;

		public const short Fabric0 = 27;

		public const short Fabric1 = 28;

		public const short Fabric2 = 29;

		public const short Fabric3 = 30;

		public const short Fabric4 = 31;

		public const short Fabric5 = 32;

		public const short Fabric6 = 33;

		public const short Fabric7 = 34;

		public const short Fabric8 = 35;

		public const short Cooking0 = 36;

		public const short Cooking1 = 37;

		public const short Cooking2 = 38;

		public const short Cooking3 = 39;

		public const short Cooking4 = 40;

		public const short Cooking5 = 41;

		public const short Cooking6 = 42;

		public const short Cooking7 = 43;

		public const short Cooking8 = 44;

		public const short Medicine0 = 45;

		public const short Medicine1 = 46;

		public const short Medicine2 = 47;

		public const short Medicine3 = 48;

		public const short Medicine4 = 49;

		public const short Medicine5 = 50;

		public const short Medicine6 = 51;

		public const short Medicine7 = 52;

		public const short Medicine8 = 53;

		public const short Empty = 54;
	}

	public static class DefValue
	{
		public static CraftToolItem Wood0 => Instance[(short)0];

		public static CraftToolItem Wood1 => Instance[(short)1];

		public static CraftToolItem Wood2 => Instance[(short)2];

		public static CraftToolItem Wood3 => Instance[(short)3];

		public static CraftToolItem Wood4 => Instance[(short)4];

		public static CraftToolItem Wood5 => Instance[(short)5];

		public static CraftToolItem Wood6 => Instance[(short)6];

		public static CraftToolItem Wood7 => Instance[(short)7];

		public static CraftToolItem Wood8 => Instance[(short)8];

		public static CraftToolItem Metal0 => Instance[(short)9];

		public static CraftToolItem Metal1 => Instance[(short)10];

		public static CraftToolItem Metal2 => Instance[(short)11];

		public static CraftToolItem Metal3 => Instance[(short)12];

		public static CraftToolItem Metal4 => Instance[(short)13];

		public static CraftToolItem Metal5 => Instance[(short)14];

		public static CraftToolItem Metal6 => Instance[(short)15];

		public static CraftToolItem Metal7 => Instance[(short)16];

		public static CraftToolItem Metal8 => Instance[(short)17];

		public static CraftToolItem Jade0 => Instance[(short)18];

		public static CraftToolItem Jade1 => Instance[(short)19];

		public static CraftToolItem Jade2 => Instance[(short)20];

		public static CraftToolItem Jade3 => Instance[(short)21];

		public static CraftToolItem Jade4 => Instance[(short)22];

		public static CraftToolItem Jade5 => Instance[(short)23];

		public static CraftToolItem Jade6 => Instance[(short)24];

		public static CraftToolItem Jade7 => Instance[(short)25];

		public static CraftToolItem Jade8 => Instance[(short)26];

		public static CraftToolItem Fabric0 => Instance[(short)27];

		public static CraftToolItem Fabric1 => Instance[(short)28];

		public static CraftToolItem Fabric2 => Instance[(short)29];

		public static CraftToolItem Fabric3 => Instance[(short)30];

		public static CraftToolItem Fabric4 => Instance[(short)31];

		public static CraftToolItem Fabric5 => Instance[(short)32];

		public static CraftToolItem Fabric6 => Instance[(short)33];

		public static CraftToolItem Fabric7 => Instance[(short)34];

		public static CraftToolItem Fabric8 => Instance[(short)35];

		public static CraftToolItem Cooking0 => Instance[(short)36];

		public static CraftToolItem Cooking1 => Instance[(short)37];

		public static CraftToolItem Cooking2 => Instance[(short)38];

		public static CraftToolItem Cooking3 => Instance[(short)39];

		public static CraftToolItem Cooking4 => Instance[(short)40];

		public static CraftToolItem Cooking5 => Instance[(short)41];

		public static CraftToolItem Cooking6 => Instance[(short)42];

		public static CraftToolItem Cooking7 => Instance[(short)43];

		public static CraftToolItem Cooking8 => Instance[(short)44];

		public static CraftToolItem Medicine0 => Instance[(short)45];

		public static CraftToolItem Medicine1 => Instance[(short)46];

		public static CraftToolItem Medicine2 => Instance[(short)47];

		public static CraftToolItem Medicine3 => Instance[(short)48];

		public static CraftToolItem Medicine4 => Instance[(short)49];

		public static CraftToolItem Medicine5 => Instance[(short)50];

		public static CraftToolItem Medicine6 => Instance[(short)51];

		public static CraftToolItem Medicine7 => Instance[(short)52];

		public static CraftToolItem Medicine8 => Instance[(short)53];

		public static CraftToolItem Empty => Instance[(short)54];
	}

	public static CraftTool Instance = new CraftTool();

	private readonly HashSet<string> RequiredFields = new HashSet<string>
	{
		"Name", "ItemSubType", "GroupId", "Desc", "FunctionDesc", "ResourceType", "TaskLock", "RequiredLifeSkillTypes", "TemplateId", "Grade",
		"Icon", "MaxDurability", "BaseWeight", "BaseHappinessChange", "DropRate", "AttainmentBonus"
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
		_dataArray.Add(new CraftToolItem(0, LocalStringManager.GetConfig("CraftTool_language", "Name_0"), 6, 600, 0, 0, "icon_CraftTool_mugongxiang", LocalStringManager.GetConfig("CraftTool_language", "Desc_0"), LocalStringManager.GetConfig("CraftTool_language", "FunctionDesc_0"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 60, 100, 150, 0, 1, 600, 3, allowRandomCreate: true, 45, isSpecial: false, 2, 36, new List<int>(), new List<sbyte> { 7 }, 30, new short[9] { 3, 4, 5, 6, 7, 8, 9, 10, 20 }, 0));
		_dataArray.Add(new CraftToolItem(1, LocalStringManager.GetConfig("CraftTool_language", "Name_1"), 6, 600, 1, 0, "icon_CraftTool_qiangjianghe", LocalStringManager.GetConfig("CraftTool_language", "Desc_1"), LocalStringManager.GetConfig("CraftTool_language", "FunctionDesc_1"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 54, 120, 300, 0, 2, 1200, 4, allowRandomCreate: true, 40, isSpecial: false, 2, 36, new List<int>(), new List<sbyte> { 7 }, 40, new short[9] { 2, 3, 4, 5, 6, 7, 8, 9, 18 }, 0));
		_dataArray.Add(new CraftToolItem(2, LocalStringManager.GetConfig("CraftTool_language", "Name_2"), 6, 600, 2, 0, "icon_CraftTool_chanyipao", LocalStringManager.GetConfig("CraftTool_language", "Desc_2"), LocalStringManager.GetConfig("CraftTool_language", "FunctionDesc_2"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 48, 60, 900, 0, 3, 1800, 5, allowRandomCreate: true, 35, isSpecial: false, 2, 36, new List<int>(), new List<sbyte> { 7 }, 50, new short[9] { 1, 2, 3, 4, 5, 6, 7, 8, 16 }, 0));
		_dataArray.Add(new CraftToolItem(3, LocalStringManager.GetConfig("CraftTool_language", "Name_3"), 6, 600, 3, 0, "icon_CraftTool_zhuqiyinxia", LocalStringManager.GetConfig("CraftTool_language", "Desc_3"), LocalStringManager.GetConfig("CraftTool_language", "FunctionDesc_3"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 42, 110, 2250, 1, 4, 3000, 6, allowRandomCreate: true, 30, isSpecial: false, 2, 36, new List<int>(), new List<sbyte> { 7 }, 70, new short[9] { 0, 1, 2, 3, 4, 5, 6, 7, 14 }, 0));
		_dataArray.Add(new CraftToolItem(4, LocalStringManager.GetConfig("CraftTool_language", "Name_4"), 6, 600, 4, 0, "icon_CraftTool_shentiehupopao", LocalStringManager.GetConfig("CraftTool_language", "Desc_4"), LocalStringManager.GetConfig("CraftTool_language", "FunctionDesc_4"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 36, 200, 4650, 2, 5, 4200, 7, allowRandomCreate: true, 25, isSpecial: false, 2, 36, new List<int>(), new List<sbyte> { 7 }, 90, new short[9] { 0, 0, 1, 2, 3, 4, 5, 6, 12 }, 0));
		_dataArray.Add(new CraftToolItem(5, LocalStringManager.GetConfig("CraftTool_language", "Name_5"), 6, 600, 5, 0, "icon_CraftTool_qianjibaoxiang", LocalStringManager.GetConfig("CraftTool_language", "Desc_5"), LocalStringManager.GetConfig("CraftTool_language", "FunctionDesc_5"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 30, 140, 8400, 3, 6, 5400, 7, allowRandomCreate: true, 20, isSpecial: false, 2, 36, new List<int>(), new List<sbyte> { 7 }, 110, new short[9] { 0, 0, 0, 1, 2, 3, 4, 5, 10 }, 0));
		_dataArray.Add(new CraftToolItem(6, LocalStringManager.GetConfig("CraftTool_language", "Name_6"), 6, 600, 6, 0, "icon_CraftTool_guifubao", LocalStringManager.GetConfig("CraftTool_language", "Desc_6"), LocalStringManager.GetConfig("CraftTool_language", "FunctionDesc_6"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 24, 170, 13800, 4, 7, 7200, 8, allowRandomCreate: true, 15, isSpecial: false, 2, 36, new List<int>(), new List<sbyte> { 7 }, 140, new short[9] { 0, 0, 0, 0, 1, 2, 3, 4, 8 }, 0));
		_dataArray.Add(new CraftToolItem(7, LocalStringManager.GetConfig("CraftTool_language", "Name_7"), 6, 600, 7, 0, "icon_CraftTool_ruyiqiankunhe", LocalStringManager.GetConfig("CraftTool_language", "Desc_7"), LocalStringManager.GetConfig("CraftTool_language", "FunctionDesc_7"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 18, 100, 21150, 5, 8, 9000, 8, allowRandomCreate: true, 10, isSpecial: false, 2, 36, new List<int>(), new List<sbyte> { 7 }, 180, new short[9] { 0, 0, 0, 0, 0, 1, 2, 3, 6 }, 0));
		_dataArray.Add(new CraftToolItem(8, LocalStringManager.GetConfig("CraftTool_language", "Name_8"), 6, 600, 8, 0, "icon_CraftTool_gongshubaoxia", LocalStringManager.GetConfig("CraftTool_language", "Desc_8"), LocalStringManager.GetConfig("CraftTool_language", "FunctionDesc_8"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 12, 120, 30750, 6, 9, 10800, 8, allowRandomCreate: true, 5, isSpecial: false, 2, 36, new List<int>(), new List<sbyte> { 7 }, 230, new short[9] { 0, 0, 0, 0, 0, 0, 1, 2, 4 }, 0));
		_dataArray.Add(new CraftToolItem(9, LocalStringManager.GetConfig("CraftTool_language", "Name_9"), 6, 600, 0, 9, "icon_CraftTool_qingtongzhulu", LocalStringManager.GetConfig("CraftTool_language", "Desc_9"), LocalStringManager.GetConfig("CraftTool_language", "FunctionDesc_9"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 60, 100, 150, 0, 1, 600, 3, allowRandomCreate: true, 45, isSpecial: false, 2, 36, new List<int>(), new List<sbyte> { 6 }, 30, new short[9] { 3, 4, 5, 6, 7, 8, 9, 10, 20 }, 0));
		_dataArray.Add(new CraftToolItem(10, LocalStringManager.GetConfig("CraftTool_language", "Name_10"), 6, 600, 1, 9, "icon_CraftTool_chiwenlian", LocalStringManager.GetConfig("CraftTool_language", "Desc_10"), LocalStringManager.GetConfig("CraftTool_language", "FunctionDesc_10"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 54, 120, 300, 0, 2, 1200, 4, allowRandomCreate: true, 40, isSpecial: false, 2, 36, new List<int>(), new List<sbyte> { 6 }, 40, new short[9] { 2, 3, 4, 5, 6, 7, 8, 9, 18 }, 0));
		_dataArray.Add(new CraftToolItem(11, LocalStringManager.GetConfig("CraftTool_language", "Name_11"), 6, 600, 2, 9, "icon_CraftTool_bintieyinyanglian", LocalStringManager.GetConfig("CraftTool_language", "Desc_11"), LocalStringManager.GetConfig("CraftTool_language", "FunctionDesc_11"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 48, 60, 900, 0, 3, 1800, 5, allowRandomCreate: true, 35, isSpecial: false, 2, 36, new List<int>(), new List<sbyte> { 6 }, 50, new short[9] { 1, 2, 3, 4, 5, 6, 7, 8, 16 }, 0));
		_dataArray.Add(new CraftToolItem(12, LocalStringManager.GetConfig("CraftTool_language", "Name_12"), 6, 600, 3, 9, "icon_CraftTool_wujinzhulu", LocalStringManager.GetConfig("CraftTool_language", "Desc_12"), LocalStringManager.GetConfig("CraftTool_language", "FunctionDesc_12"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 42, 110, 2250, 1, 4, 3000, 6, allowRandomCreate: true, 30, isSpecial: false, 2, 36, new List<int>(), new List<sbyte> { 6 }, 70, new short[9] { 0, 1, 2, 3, 4, 5, 6, 7, 14 }, 0));
		_dataArray.Add(new CraftToolItem(13, LocalStringManager.GetConfig("CraftTool_language", "Name_13"), 6, 600, 4, 9, "icon_CraftTool_hunyuanzhulu", LocalStringManager.GetConfig("CraftTool_language", "Desc_13"), LocalStringManager.GetConfig("CraftTool_language", "FunctionDesc_13"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 36, 200, 4650, 2, 5, 4200, 7, allowRandomCreate: true, 25, isSpecial: false, 2, 36, new List<int>(), new List<sbyte> { 6 }, 90, new short[9] { 0, 0, 1, 2, 3, 4, 5, 6, 12 }, 0));
		_dataArray.Add(new CraftToolItem(14, LocalStringManager.GetConfig("CraftTool_language", "Name_14"), 6, 600, 5, 9, "icon_CraftTool_qipolian", LocalStringManager.GetConfig("CraftTool_language", "Desc_14"), LocalStringManager.GetConfig("CraftTool_language", "FunctionDesc_14"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 30, 140, 8400, 3, 6, 5400, 7, allowRandomCreate: true, 20, isSpecial: false, 2, 36, new List<int>(), new List<sbyte> { 6 }, 110, new short[9] { 0, 0, 0, 1, 2, 3, 4, 5, 10 }, 0));
		_dataArray.Add(new CraftToolItem(15, LocalStringManager.GetConfig("CraftTool_language", "Name_15"), 6, 600, 6, 9, "icon_CraftTool_qixiazhenhuolian", LocalStringManager.GetConfig("CraftTool_language", "Desc_15"), LocalStringManager.GetConfig("CraftTool_language", "FunctionDesc_15"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 24, 170, 13800, 4, 7, 7200, 8, allowRandomCreate: true, 15, isSpecial: false, 2, 36, new List<int>(), new List<sbyte> { 6 }, 140, new short[9] { 0, 0, 0, 0, 1, 2, 3, 4, 8 }, 0));
		_dataArray.Add(new CraftToolItem(16, LocalStringManager.GetConfig("CraftTool_language", "Name_16"), 6, 600, 7, 9, "icon_CraftTool_jiuhanzhulu", LocalStringManager.GetConfig("CraftTool_language", "Desc_16"), LocalStringManager.GetConfig("CraftTool_language", "FunctionDesc_16"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 18, 100, 21150, 5, 8, 9000, 8, allowRandomCreate: true, 10, isSpecial: false, 2, 36, new List<int>(), new List<sbyte> { 6 }, 180, new short[9] { 0, 0, 0, 0, 0, 1, 2, 3, 6 }, 0));
		_dataArray.Add(new CraftToolItem(17, LocalStringManager.GetConfig("CraftTool_language", "Name_17"), 6, 600, 8, 9, "icon_CraftTool_rexielian", LocalStringManager.GetConfig("CraftTool_language", "Desc_17"), LocalStringManager.GetConfig("CraftTool_language", "FunctionDesc_17"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 12, 120, 30750, 6, 9, 10800, 8, allowRandomCreate: true, 5, isSpecial: false, 2, 36, new List<int>(), new List<sbyte> { 6 }, 230, new short[9] { 0, 0, 0, 0, 0, 0, 1, 2, 4 }, 0));
		_dataArray.Add(new CraftToolItem(18, LocalStringManager.GetConfig("CraftTool_language", "Name_18"), 6, 600, 0, 18, "icon_CraftTool_heidansha", LocalStringManager.GetConfig("CraftTool_language", "Desc_18"), LocalStringManager.GetConfig("CraftTool_language", "FunctionDesc_18"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 60, 100, 150, 0, 1, 600, 3, allowRandomCreate: true, 45, isSpecial: false, 2, 36, new List<int>(), new List<sbyte> { 11 }, 30, new short[9] { 3, 4, 5, 6, 7, 8, 9, 10, 20 }, 0));
		_dataArray.Add(new CraftToolItem(19, LocalStringManager.GetConfig("CraftTool_language", "Name_19"), 6, 600, 1, 18, "icon_CraftTool_jingangsha", LocalStringManager.GetConfig("CraftTool_language", "Desc_19"), LocalStringManager.GetConfig("CraftTool_language", "FunctionDesc_19"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 54, 120, 300, 0, 2, 1200, 4, allowRandomCreate: true, 40, isSpecial: false, 2, 36, new List<int>(), new List<sbyte> { 11 }, 40, new short[9] { 2, 3, 4, 5, 6, 7, 8, 9, 18 }, 0));
		_dataArray.Add(new CraftToolItem(20, LocalStringManager.GetConfig("CraftTool_language", "Name_20"), 6, 600, 2, 18, "icon_CraftTool_feicuizhenzhusha", LocalStringManager.GetConfig("CraftTool_language", "Desc_20"), LocalStringManager.GetConfig("CraftTool_language", "FunctionDesc_20"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 48, 60, 900, 0, 3, 1800, 5, allowRandomCreate: true, 35, isSpecial: false, 2, 36, new List<int>(), new List<sbyte> { 11 }, 50, new short[9] { 1, 2, 3, 4, 5, 6, 7, 8, 16 }, 0));
		_dataArray.Add(new CraftToolItem(21, LocalStringManager.GetConfig("CraftTool_language", "Name_21"), 6, 600, 3, 18, "icon_CraftTool_huanglongsha", LocalStringManager.GetConfig("CraftTool_language", "Desc_21"), LocalStringManager.GetConfig("CraftTool_language", "FunctionDesc_21"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 42, 110, 2250, 1, 4, 3000, 6, allowRandomCreate: true, 30, isSpecial: false, 2, 36, new List<int>(), new List<sbyte> { 11 }, 70, new short[9] { 0, 1, 2, 3, 4, 5, 6, 7, 14 }, 0));
		_dataArray.Add(new CraftToolItem(22, LocalStringManager.GetConfig("CraftTool_language", "Name_22"), 6, 600, 4, 18, "icon_CraftTool_sansebaoshisha", LocalStringManager.GetConfig("CraftTool_language", "Desc_22"), LocalStringManager.GetConfig("CraftTool_language", "FunctionDesc_22"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 36, 200, 4650, 2, 5, 4200, 7, allowRandomCreate: true, 25, isSpecial: false, 2, 36, new List<int>(), new List<sbyte> { 11 }, 90, new short[9] { 0, 0, 1, 2, 3, 4, 5, 6, 12 }, 0));
		_dataArray.Add(new CraftToolItem(23, LocalStringManager.GetConfig("CraftTool_language", "Name_23"), 6, 600, 5, 18, "icon_CraftTool_muxuesha", LocalStringManager.GetConfig("CraftTool_language", "Desc_23"), LocalStringManager.GetConfig("CraftTool_language", "FunctionDesc_23"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 30, 140, 8400, 3, 6, 5400, 7, allowRandomCreate: true, 20, isSpecial: false, 2, 36, new List<int>(), new List<sbyte> { 11 }, 110, new short[9] { 0, 0, 0, 1, 2, 3, 4, 5, 10 }, 0));
		_dataArray.Add(new CraftToolItem(24, LocalStringManager.GetConfig("CraftTool_language", "Name_24"), 6, 600, 6, 18, "icon_CraftTool_zijinchenxiangsha", LocalStringManager.GetConfig("CraftTool_language", "Desc_24"), LocalStringManager.GetConfig("CraftTool_language", "FunctionDesc_24"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 24, 170, 13800, 4, 7, 7200, 8, allowRandomCreate: true, 15, isSpecial: false, 2, 36, new List<int>(), new List<sbyte> { 11 }, 140, new short[9] { 0, 0, 0, 0, 1, 2, 3, 4, 8 }, 0));
		_dataArray.Add(new CraftToolItem(25, LocalStringManager.GetConfig("CraftTool_language", "Name_25"), 6, 600, 7, 18, "icon_CraftTool_bingjingxielousha", LocalStringManager.GetConfig("CraftTool_language", "Desc_25"), LocalStringManager.GetConfig("CraftTool_language", "FunctionDesc_25"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 18, 100, 21150, 5, 8, 9000, 8, allowRandomCreate: true, 10, isSpecial: false, 2, 36, new List<int>(), new List<sbyte> { 11 }, 180, new short[9] { 0, 0, 0, 0, 0, 1, 2, 3, 6 }, 0));
		_dataArray.Add(new CraftToolItem(26, LocalStringManager.GetConfig("CraftTool_language", "Name_26"), 6, 600, 8, 18, "icon_CraftTool_longnvsha", LocalStringManager.GetConfig("CraftTool_language", "Desc_26"), LocalStringManager.GetConfig("CraftTool_language", "FunctionDesc_26"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 12, 120, 30750, 6, 9, 10800, 8, allowRandomCreate: true, 5, isSpecial: false, 2, 36, new List<int>(), new List<sbyte> { 11 }, 230, new short[9] { 0, 0, 0, 0, 0, 0, 1, 2, 4 }, 0));
		_dataArray.Add(new CraftToolItem(27, LocalStringManager.GetConfig("CraftTool_language", "Name_27"), 6, 600, 0, 27, "icon_CraftTool_zhenxianbao", LocalStringManager.GetConfig("CraftTool_language", "Desc_27"), LocalStringManager.GetConfig("CraftTool_language", "FunctionDesc_27"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 60, 100, 150, 0, 1, 600, 3, allowRandomCreate: true, 45, isSpecial: false, 2, 36, new List<int>(), new List<sbyte> { 10 }, 30, new short[9] { 3, 4, 5, 6, 7, 8, 9, 10, 20 }, 0));
		_dataArray.Add(new CraftToolItem(28, LocalStringManager.GetConfig("CraftTool_language", "Name_28"), 6, 600, 1, 27, "icon_CraftTool_qingzhuzhiji", LocalStringManager.GetConfig("CraftTool_language", "Desc_28"), LocalStringManager.GetConfig("CraftTool_language", "FunctionDesc_28"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 54, 120, 300, 0, 2, 1200, 4, allowRandomCreate: true, 40, isSpecial: false, 2, 36, new List<int>(), new List<sbyte> { 10 }, 40, new short[9] { 2, 3, 4, 5, 6, 7, 8, 9, 18 }, 0));
		_dataArray.Add(new CraftToolItem(29, LocalStringManager.GetConfig("CraftTool_language", "Name_29"), 6, 600, 2, 27, "icon_CraftTool_hudiesuo", LocalStringManager.GetConfig("CraftTool_language", "Desc_29"), LocalStringManager.GetConfig("CraftTool_language", "FunctionDesc_29"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 48, 60, 900, 0, 3, 1800, 5, allowRandomCreate: true, 35, isSpecial: false, 2, 36, new List<int>(), new List<sbyte> { 10 }, 50, new short[9] { 1, 2, 3, 4, 5, 6, 7, 8, 16 }, 0));
		_dataArray.Add(new CraftToolItem(30, LocalStringManager.GetConfig("CraftTool_language", "Name_30"), 6, 600, 3, 27, "icon_CraftTool_liuyunsuo", LocalStringManager.GetConfig("CraftTool_language", "Desc_30"), LocalStringManager.GetConfig("CraftTool_language", "FunctionDesc_30"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 42, 110, 2250, 1, 4, 3000, 6, allowRandomCreate: true, 30, isSpecial: false, 2, 36, new List<int>(), new List<sbyte> { 10 }, 70, new short[9] { 0, 1, 2, 3, 4, 5, 6, 7, 14 }, 0));
		_dataArray.Add(new CraftToolItem(31, LocalStringManager.GetConfig("CraftTool_language", "Name_31"), 6, 600, 4, 27, "icon_CraftTool_xiangyazhiji", LocalStringManager.GetConfig("CraftTool_language", "Desc_31"), LocalStringManager.GetConfig("CraftTool_language", "FunctionDesc_31"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 36, 200, 4650, 2, 5, 4200, 7, allowRandomCreate: true, 25, isSpecial: false, 2, 36, new List<int>(), new List<sbyte> { 10 }, 90, new short[9] { 0, 0, 1, 2, 3, 4, 5, 6, 12 }, 0));
		_dataArray.Add(new CraftToolItem(32, LocalStringManager.GetConfig("CraftTool_language", "Name_32"), 6, 600, 5, 27, "icon_CraftTool_baihuisuo", LocalStringManager.GetConfig("CraftTool_language", "Desc_32"), LocalStringManager.GetConfig("CraftTool_language", "FunctionDesc_32"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 30, 140, 8400, 3, 6, 5400, 7, allowRandomCreate: true, 20, isSpecial: false, 2, 36, new List<int>(), new List<sbyte> { 10 }, 110, new short[9] { 0, 0, 0, 1, 2, 3, 4, 5, 10 }, 0));
		_dataArray.Add(new CraftToolItem(33, LocalStringManager.GetConfig("CraftTool_language", "Name_33"), 6, 600, 6, 27, "icon_CraftTool_huangmuzhiji", LocalStringManager.GetConfig("CraftTool_language", "Desc_33"), LocalStringManager.GetConfig("CraftTool_language", "FunctionDesc_33"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 24, 170, 13800, 4, 7, 7200, 8, allowRandomCreate: true, 15, isSpecial: false, 2, 36, new List<int>(), new List<sbyte> { 10 }, 140, new short[9] { 0, 0, 0, 0, 1, 2, 3, 4, 8 }, 0));
		_dataArray.Add(new CraftToolItem(34, LocalStringManager.GetConfig("CraftTool_language", "Name_34"), 6, 600, 7, 27, "icon_CraftTool_qiseliuxiangsuo", LocalStringManager.GetConfig("CraftTool_language", "Desc_34"), LocalStringManager.GetConfig("CraftTool_language", "FunctionDesc_34"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 18, 100, 21150, 5, 8, 9000, 8, allowRandomCreate: true, 10, isSpecial: false, 2, 36, new List<int>(), new List<sbyte> { 10 }, 180, new short[9] { 0, 0, 0, 0, 0, 1, 2, 3, 6 }, 0));
		_dataArray.Add(new CraftToolItem(35, LocalStringManager.GetConfig("CraftTool_language", "Name_35"), 6, 600, 8, 27, "icon_CraftTool_tiannvbaoxiasuo", LocalStringManager.GetConfig("CraftTool_language", "Desc_35"), LocalStringManager.GetConfig("CraftTool_language", "FunctionDesc_35"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 12, 120, 30750, 6, 9, 10800, 8, allowRandomCreate: true, 5, isSpecial: false, 2, 36, new List<int>(), new List<sbyte> { 10 }, 230, new short[9] { 0, 0, 0, 0, 0, 0, 1, 2, 4 }, 0));
		_dataArray.Add(new CraftToolItem(36, LocalStringManager.GetConfig("CraftTool_language", "Name_36"), 6, 600, 0, 36, "icon_CraftTool_danguo", LocalStringManager.GetConfig("CraftTool_language", "Desc_36"), LocalStringManager.GetConfig("CraftTool_language", "FunctionDesc_36"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 120, 340, 150, 0, 1, 600, 3, allowRandomCreate: true, 45, isSpecial: false, 2, 36, new List<int>(), new List<sbyte> { 14 }, 30, new short[9] { 3, 4, 5, 6, 7, 8, 9, 10, 20 }, -1));
		_dataArray.Add(new CraftToolItem(37, LocalStringManager.GetConfig("CraftTool_language", "Name_37"), 6, 600, 1, 36, "icon_CraftTool_shuangertongguo", LocalStringManager.GetConfig("CraftTool_language", "Desc_37"), LocalStringManager.GetConfig("CraftTool_language", "FunctionDesc_37"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 108, 300, 300, 0, 2, 1200, 4, allowRandomCreate: true, 40, isSpecial: false, 2, 36, new List<int>(), new List<sbyte> { 14 }, 40, new short[9] { 2, 3, 4, 5, 6, 7, 8, 9, 18 }, -1));
		_dataArray.Add(new CraftToolItem(38, LocalStringManager.GetConfig("CraftTool_language", "Name_38"), 6, 600, 2, 36, "icon_CraftTool_fululiuerguo", LocalStringManager.GetConfig("CraftTool_language", "Desc_38"), LocalStringManager.GetConfig("CraftTool_language", "FunctionDesc_38"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 96, 320, 900, 0, 3, 1800, 5, allowRandomCreate: true, 35, isSpecial: false, 2, 36, new List<int>(), new List<sbyte> { 14 }, 50, new short[9] { 1, 2, 3, 4, 5, 6, 7, 8, 16 }, -1));
		_dataArray.Add(new CraftToolItem(39, LocalStringManager.GetConfig("CraftTool_language", "Name_39"), 6, 600, 3, 36, "icon_CraftTool_zaowangguo", LocalStringManager.GetConfig("CraftTool_language", "Desc_39"), LocalStringManager.GetConfig("CraftTool_language", "FunctionDesc_39"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 84, 340, 2250, 1, 4, 3000, 6, allowRandomCreate: true, 30, isSpecial: false, 2, 36, new List<int>(), new List<sbyte> { 14 }, 70, new short[9] { 0, 1, 2, 3, 4, 5, 6, 7, 14 }, -1));
		_dataArray.Add(new CraftToolItem(40, LocalStringManager.GetConfig("CraftTool_language", "Name_40"), 6, 600, 4, 36, "icon_CraftTool_taotieshouwenguo", LocalStringManager.GetConfig("CraftTool_language", "Desc_40"), LocalStringManager.GetConfig("CraftTool_language", "FunctionDesc_40"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 72, 400, 4650, 2, 5, 4200, 7, allowRandomCreate: true, 25, isSpecial: false, 2, 36, new List<int>(), new List<sbyte> { 14 }, 90, new short[9] { 0, 0, 1, 2, 3, 4, 5, 6, 12 }, -1));
		_dataArray.Add(new CraftToolItem(41, LocalStringManager.GetConfig("CraftTool_language", "Name_41"), 6, 600, 5, 36, "icon_CraftTool_touxiangguo", LocalStringManager.GetConfig("CraftTool_language", "Desc_41"), LocalStringManager.GetConfig("CraftTool_language", "FunctionDesc_41"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 60, 280, 8400, 3, 6, 5400, 7, allowRandomCreate: true, 20, isSpecial: false, 2, 36, new List<int>(), new List<sbyte> { 14 }, 110, new short[9] { 0, 0, 0, 1, 2, 3, 4, 5, 10 }, -1));
		_dataArray.Add(new CraftToolItem(42, LocalStringManager.GetConfig("CraftTool_language", "Name_42"), 6, 600, 6, 36, "icon_CraftTool_babaoLuheguo", LocalStringManager.GetConfig("CraftTool_language", "Desc_42"), LocalStringManager.GetConfig("CraftTool_language", "FunctionDesc_42"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 48, 360, 13800, 4, 7, 7200, 8, allowRandomCreate: true, 15, isSpecial: false, 2, 36, new List<int>(), new List<sbyte> { 14 }, 140, new short[9] { 0, 0, 0, 0, 1, 2, 3, 4, 8 }, -1));
		_dataArray.Add(new CraftToolItem(43, LocalStringManager.GetConfig("CraftTool_language", "Name_43"), 6, 600, 7, 36, "icon_CraftTool_xuantiegunjinguo", LocalStringManager.GetConfig("CraftTool_language", "Desc_43"), LocalStringManager.GetConfig("CraftTool_language", "FunctionDesc_43"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 36, 480, 21150, 5, 8, 9000, 8, allowRandomCreate: true, 10, isSpecial: false, 2, 36, new List<int>(), new List<sbyte> { 14 }, 180, new short[9] { 0, 0, 0, 0, 0, 1, 2, 3, 6 }, -1));
		_dataArray.Add(new CraftToolItem(44, LocalStringManager.GetConfig("CraftTool_language", "Name_44"), 6, 600, 8, 36, "icon_CraftTool_qiandouguo", LocalStringManager.GetConfig("CraftTool_language", "Desc_44"), LocalStringManager.GetConfig("CraftTool_language", "FunctionDesc_44"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 24, 300, 30750, 6, 9, 10800, 8, allowRandomCreate: true, 5, isSpecial: false, 2, 36, new List<int>(), new List<sbyte> { 14 }, 230, new short[9] { 0, 0, 0, 0, 0, 0, 1, 2, 4 }, -1));
		_dataArray.Add(new CraftToolItem(45, LocalStringManager.GetConfig("CraftTool_language", "Name_45"), 6, 600, 0, 45, "icon_CraftTool_taotuyaobo", LocalStringManager.GetConfig("CraftTool_language", "Desc_45"), LocalStringManager.GetConfig("CraftTool_language", "FunctionDesc_45"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 120, 180, 150, 0, 1, 600, 3, allowRandomCreate: true, 45, isSpecial: false, 3, 36, new List<int>(), new List<sbyte> { 8, 9 }, 30, new short[9] { 3, 4, 5, 6, 7, 8, 9, 10, 20 }, 0));
		_dataArray.Add(new CraftToolItem(46, LocalStringManager.GetConfig("CraftTool_language", "Name_46"), 6, 600, 1, 45, "icon_CraftTool_baicaoding", LocalStringManager.GetConfig("CraftTool_language", "Desc_46"), LocalStringManager.GetConfig("CraftTool_language", "FunctionDesc_46"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 108, 220, 300, 0, 2, 1200, 4, allowRandomCreate: true, 40, isSpecial: false, 3, 36, new List<int>(), new List<sbyte> { 8, 9 }, 40, new short[9] { 2, 3, 4, 5, 6, 7, 8, 9, 18 }, 0));
		_dataArray.Add(new CraftToolItem(47, LocalStringManager.GetConfig("CraftTool_language", "Name_47"), 6, 600, 2, 45, "icon_CraftTool_laojunliandanlu", LocalStringManager.GetConfig("CraftTool_language", "Desc_47"), LocalStringManager.GetConfig("CraftTool_language", "FunctionDesc_47"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 96, 280, 900, 0, 3, 1800, 5, allowRandomCreate: true, 35, isSpecial: false, 3, 36, new List<int>(), new List<sbyte> { 8, 9 }, 50, new short[9] { 1, 2, 3, 4, 5, 6, 7, 8, 16 }, 0));
		_dataArray.Add(new CraftToolItem(48, LocalStringManager.GetConfig("CraftTool_language", "Name_48"), 6, 600, 3, 45, "icon_CraftTool_biyuputibo", LocalStringManager.GetConfig("CraftTool_language", "Desc_48"), LocalStringManager.GetConfig("CraftTool_language", "FunctionDesc_48"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 84, 200, 2250, 1, 4, 3000, 6, allowRandomCreate: true, 30, isSpecial: false, 3, 36, new List<int>(), new List<sbyte> { 8, 9 }, 70, new short[9] { 0, 1, 2, 3, 4, 5, 6, 7, 14 }, 0));
		_dataArray.Add(new CraftToolItem(49, LocalStringManager.GetConfig("CraftTool_language", "Name_49"), 6, 600, 4, 45, "icon_CraftTool_guiwanglu", LocalStringManager.GetConfig("CraftTool_language", "Desc_49"), LocalStringManager.GetConfig("CraftTool_language", "FunctionDesc_49"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 72, 300, 4650, 2, 5, 4200, 7, allowRandomCreate: true, 25, isSpecial: false, 3, 36, new List<int>(), new List<sbyte> { 8, 9 }, 90, new short[9] { 0, 0, 1, 2, 3, 4, 5, 6, 12 }, 0));
		_dataArray.Add(new CraftToolItem(50, LocalStringManager.GetConfig("CraftTool_language", "Name_50"), 6, 600, 5, 45, "icon_CraftTool_shenmuyaowangding", LocalStringManager.GetConfig("CraftTool_language", "Desc_50"), LocalStringManager.GetConfig("CraftTool_language", "FunctionDesc_50"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 60, 160, 8400, 3, 6, 5400, 7, allowRandomCreate: true, 20, isSpecial: false, 3, 36, new List<int>(), new List<sbyte> { 8, 9 }, 110, new short[9] { 0, 0, 0, 1, 2, 3, 4, 5, 10 }, 0));
		_dataArray.Add(new CraftToolItem(51, LocalStringManager.GetConfig("CraftTool_language", "Name_51"), 6, 600, 6, 45, "icon_CraftTool_xieyubo", LocalStringManager.GetConfig("CraftTool_language", "Desc_51"), LocalStringManager.GetConfig("CraftTool_language", "FunctionDesc_51"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 48, 240, 13800, 4, 7, 7200, 8, allowRandomCreate: true, 15, isSpecial: false, 3, 36, new List<int>(), new List<sbyte> { 8, 9 }, 140, new short[9] { 0, 0, 0, 0, 1, 2, 3, 4, 8 }, 0));
		_dataArray.Add(new CraftToolItem(52, LocalStringManager.GetConfig("CraftTool_language", "Name_52"), 6, 600, 7, 45, "icon_CraftTool_tianxiangliuliding", LocalStringManager.GetConfig("CraftTool_language", "Desc_52"), LocalStringManager.GetConfig("CraftTool_language", "FunctionDesc_52"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 36, 260, 21150, 5, 8, 9000, 8, allowRandomCreate: true, 10, isSpecial: false, 3, 36, new List<int>(), new List<sbyte> { 8, 9 }, 180, new short[9] { 0, 0, 0, 0, 0, 1, 2, 3, 6 }, 0));
		_dataArray.Add(new CraftToolItem(53, LocalStringManager.GetConfig("CraftTool_language", "Name_53"), 6, 600, 8, 45, "icon_CraftTool_jiuchenyugulu", LocalStringManager.GetConfig("CraftTool_language", "Desc_53"), LocalStringManager.GetConfig("CraftTool_language", "FunctionDesc_53"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, 24, 220, 30750, 6, 9, 10800, 8, allowRandomCreate: true, 5, isSpecial: false, 3, 36, new List<int>(), new List<sbyte> { 8, 9 }, 230, new short[9] { 0, 0, 0, 0, 0, 0, 1, 2, 4 }, 0));
		_dataArray.Add(new CraftToolItem(54, LocalStringManager.GetConfig("CraftTool_language", "Name_54"), 6, 600, 0, -1, "icon_Weapon_kongshou", LocalStringManager.GetConfig("CraftTool_language", "Desc_54"), LocalStringManager.GetConfig("CraftTool_language", "FunctionDesc_54"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, 0, new List<int>(), new List<sbyte> { 7, 6, 11, 10, 14, 8, 9 }, 0, new short[9], 0));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<CraftToolItem>(55);
		CreateItems0();
	}
}
