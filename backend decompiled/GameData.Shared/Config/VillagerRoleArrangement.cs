using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class VillagerRoleArrangement : ConfigData<VillagerRoleArrangementItem, short>
{
	public static class DefKey
	{
		public const short Cooking = 0;

		public const short CollectResource = 1;

		public const short MigrateResource = 2;

		public const short IntensiveCultivation = 3;

		public const short Making = 4;

		public const short MakingMedicine = 5;

		public const short Healing = 6;

		public const short ReduceXiangshuInfection = 7;

		public const short Peddling = 8;

		public const short CommerceContacting = 9;

		public const short MakingTeaWine = 10;

		public const short Entertaining = 11;

		public const short JianghuContacting = 12;

		public const short GuardingSwordTomb = 13;

		public const short ResistXiangshuInfection = 14;

		public const short TaiwuEnvoy = 15;
	}

	public static class DefValue
	{
		public static VillagerRoleArrangementItem Cooking => Instance[(short)0];

		public static VillagerRoleArrangementItem CollectResource => Instance[(short)1];

		public static VillagerRoleArrangementItem MigrateResource => Instance[(short)2];

		public static VillagerRoleArrangementItem IntensiveCultivation => Instance[(short)3];

		public static VillagerRoleArrangementItem Making => Instance[(short)4];

		public static VillagerRoleArrangementItem MakingMedicine => Instance[(short)5];

		public static VillagerRoleArrangementItem Healing => Instance[(short)6];

		public static VillagerRoleArrangementItem ReduceXiangshuInfection => Instance[(short)7];

		public static VillagerRoleArrangementItem Peddling => Instance[(short)8];

		public static VillagerRoleArrangementItem CommerceContacting => Instance[(short)9];

		public static VillagerRoleArrangementItem MakingTeaWine => Instance[(short)10];

		public static VillagerRoleArrangementItem Entertaining => Instance[(short)11];

		public static VillagerRoleArrangementItem JianghuContacting => Instance[(short)12];

		public static VillagerRoleArrangementItem GuardingSwordTomb => Instance[(short)13];

		public static VillagerRoleArrangementItem ResistXiangshuInfection => Instance[(short)14];

		public static VillagerRoleArrangementItem TaiwuEnvoy => Instance[(short)15];
	}

	public static VillagerRoleArrangement Instance = new VillagerRoleArrangement();

	private readonly HashSet<string> RequiredFields = new HashSet<string>
	{
		"VillagerRole", "ShortName", "Name", "Desc", "DescName", "DescShort", "DescContent", "TemplateId", "DisplayIcon", "DisplayIcon2",
		"Illustration"
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
		_dataArray.Add(new VillagerRoleArrangementItem(0, 0, LocalStringManager.GetConfig("VillagerRoleArrangement_language", "ShortName_0"), LocalStringManager.GetConfig("VillagerRoleArrangement_language", "Name_0"), null, null, LocalStringManager.GetConfig("VillagerRoleArrangement_language", "Desc_0"), unlockByChicken: false, invisibleInGui: true, LocalStringManager.GetConfig("VillagerRoleArrangement_language", "DescName_0"), LocalStringManager.GetConfig("VillagerRoleArrangement_language", "DescShort_0"), LocalStringManager.GetConfig("VillagerRoleArrangement_language", "DescContent_0"), "ui9_back_villagerrole_Illustration_0_0"));
		_dataArray.Add(new VillagerRoleArrangementItem(1, 0, LocalStringManager.GetConfig("VillagerRoleArrangement_language", "ShortName_1"), LocalStringManager.GetConfig("VillagerRoleArrangement_language", "Name_1"), null, null, LocalStringManager.GetConfig("VillagerRoleArrangement_language", "Desc_1"), unlockByChicken: false, invisibleInGui: false, LocalStringManager.GetConfig("VillagerRoleArrangement_language", "DescName_1"), LocalStringManager.GetConfig("VillagerRoleArrangement_language", "DescShort_1"), LocalStringManager.GetConfig("VillagerRoleArrangement_language", "DescContent_1"), "ui9_back_villagerrole_Illustration_0_1"));
		_dataArray.Add(new VillagerRoleArrangementItem(2, 0, LocalStringManager.GetConfig("VillagerRoleArrangement_language", "ShortName_2"), LocalStringManager.GetConfig("VillagerRoleArrangement_language", "Name_2"), null, null, LocalStringManager.GetConfig("VillagerRoleArrangement_language", "Desc_2"), unlockByChicken: false, invisibleInGui: false, LocalStringManager.GetConfig("VillagerRoleArrangement_language", "DescName_2"), LocalStringManager.GetConfig("VillagerRoleArrangement_language", "DescShort_2"), LocalStringManager.GetConfig("VillagerRoleArrangement_language", "DescContent_2"), "ui9_back_villagerrole_Illustration_0_2"));
		_dataArray.Add(new VillagerRoleArrangementItem(3, 0, LocalStringManager.GetConfig("VillagerRoleArrangement_language", "ShortName_3"), LocalStringManager.GetConfig("VillagerRoleArrangement_language", "Name_3"), null, null, LocalStringManager.GetConfig("VillagerRoleArrangement_language", "Desc_3"), unlockByChicken: true, invisibleInGui: true, LocalStringManager.GetConfig("VillagerRoleArrangement_language", "DescName_3"), LocalStringManager.GetConfig("VillagerRoleArrangement_language", "DescShort_3"), LocalStringManager.GetConfig("VillagerRoleArrangement_language", "DescContent_3"), "ui9_back_villagerrole_Illustration_0_3"));
		_dataArray.Add(new VillagerRoleArrangementItem(4, 1, LocalStringManager.GetConfig("VillagerRoleArrangement_language", "ShortName_4"), LocalStringManager.GetConfig("VillagerRoleArrangement_language", "Name_4"), null, null, LocalStringManager.GetConfig("VillagerRoleArrangement_language", "Desc_4"), unlockByChicken: false, invisibleInGui: true, LocalStringManager.GetConfig("VillagerRoleArrangement_language", "DescName_4"), LocalStringManager.GetConfig("VillagerRoleArrangement_language", "DescShort_4"), LocalStringManager.GetConfig("VillagerRoleArrangement_language", "DescContent_4"), "ui9_back_villagerrole_Illustration_1_0"));
		_dataArray.Add(new VillagerRoleArrangementItem(5, 2, LocalStringManager.GetConfig("VillagerRoleArrangement_language", "ShortName_5"), LocalStringManager.GetConfig("VillagerRoleArrangement_language", "Name_5"), null, null, LocalStringManager.GetConfig("VillagerRoleArrangement_language", "Desc_5"), unlockByChicken: false, invisibleInGui: true, LocalStringManager.GetConfig("VillagerRoleArrangement_language", "DescName_5"), LocalStringManager.GetConfig("VillagerRoleArrangement_language", "DescShort_5"), LocalStringManager.GetConfig("VillagerRoleArrangement_language", "DescContent_5"), "ui9_back_villagerrole_Illustration_2_0"));
		_dataArray.Add(new VillagerRoleArrangementItem(6, 2, LocalStringManager.GetConfig("VillagerRoleArrangement_language", "ShortName_6"), LocalStringManager.GetConfig("VillagerRoleArrangement_language", "Name_6"), null, null, LocalStringManager.GetConfig("VillagerRoleArrangement_language", "Desc_6"), unlockByChicken: false, invisibleInGui: false, LocalStringManager.GetConfig("VillagerRoleArrangement_language", "DescName_6"), LocalStringManager.GetConfig("VillagerRoleArrangement_language", "DescShort_6"), LocalStringManager.GetConfig("VillagerRoleArrangement_language", "DescContent_6"), "ui9_back_villagerrole_Illustration_2_1"));
		_dataArray.Add(new VillagerRoleArrangementItem(7, 2, LocalStringManager.GetConfig("VillagerRoleArrangement_language", "ShortName_7"), LocalStringManager.GetConfig("VillagerRoleArrangement_language", "Name_7"), null, null, LocalStringManager.GetConfig("VillagerRoleArrangement_language", "Desc_7"), unlockByChicken: true, invisibleInGui: true, LocalStringManager.GetConfig("VillagerRoleArrangement_language", "DescName_7"), LocalStringManager.GetConfig("VillagerRoleArrangement_language", "DescShort_7"), LocalStringManager.GetConfig("VillagerRoleArrangement_language", "DescContent_7"), "ui9_back_villagerrole_Illustration_2_2"));
		_dataArray.Add(new VillagerRoleArrangementItem(8, 3, LocalStringManager.GetConfig("VillagerRoleArrangement_language", "ShortName_8"), LocalStringManager.GetConfig("VillagerRoleArrangement_language", "Name_8"), null, null, LocalStringManager.GetConfig("VillagerRoleArrangement_language", "Desc_8"), unlockByChicken: false, invisibleInGui: false, LocalStringManager.GetConfig("VillagerRoleArrangement_language", "DescName_8"), LocalStringManager.GetConfig("VillagerRoleArrangement_language", "DescShort_8"), LocalStringManager.GetConfig("VillagerRoleArrangement_language", "DescContent_8"), "ui9_back_villagerrole_Illustration_3_0"));
		_dataArray.Add(new VillagerRoleArrangementItem(9, 3, LocalStringManager.GetConfig("VillagerRoleArrangement_language", "ShortName_9"), LocalStringManager.GetConfig("VillagerRoleArrangement_language", "Name_9"), null, null, LocalStringManager.GetConfig("VillagerRoleArrangement_language", "Desc_9"), unlockByChicken: true, invisibleInGui: true, LocalStringManager.GetConfig("VillagerRoleArrangement_language", "DescName_9"), LocalStringManager.GetConfig("VillagerRoleArrangement_language", "DescShort_9"), LocalStringManager.GetConfig("VillagerRoleArrangement_language", "DescContent_9"), "ui9_back_villagerrole_Illustration_3_1"));
		_dataArray.Add(new VillagerRoleArrangementItem(10, 4, LocalStringManager.GetConfig("VillagerRoleArrangement_language", "ShortName_10"), LocalStringManager.GetConfig("VillagerRoleArrangement_language", "Name_10"), null, null, LocalStringManager.GetConfig("VillagerRoleArrangement_language", "Desc_10"), unlockByChicken: false, invisibleInGui: true, LocalStringManager.GetConfig("VillagerRoleArrangement_language", "DescName_10"), LocalStringManager.GetConfig("VillagerRoleArrangement_language", "DescShort_10"), LocalStringManager.GetConfig("VillagerRoleArrangement_language", "DescContent_10"), "ui9_back_villagerrole_Illustration_4_0"));
		_dataArray.Add(new VillagerRoleArrangementItem(11, 4, LocalStringManager.GetConfig("VillagerRoleArrangement_language", "ShortName_11"), LocalStringManager.GetConfig("VillagerRoleArrangement_language", "Name_11"), null, null, LocalStringManager.GetConfig("VillagerRoleArrangement_language", "Desc_11"), unlockByChicken: false, invisibleInGui: false, LocalStringManager.GetConfig("VillagerRoleArrangement_language", "DescName_11"), LocalStringManager.GetConfig("VillagerRoleArrangement_language", "DescShort_11"), LocalStringManager.GetConfig("VillagerRoleArrangement_language", "DescContent_11"), "ui9_back_villagerrole_Illustration_4_1"));
		_dataArray.Add(new VillagerRoleArrangementItem(12, 4, LocalStringManager.GetConfig("VillagerRoleArrangement_language", "ShortName_12"), LocalStringManager.GetConfig("VillagerRoleArrangement_language", "Name_12"), null, null, LocalStringManager.GetConfig("VillagerRoleArrangement_language", "Desc_12"), unlockByChicken: true, invisibleInGui: true, LocalStringManager.GetConfig("VillagerRoleArrangement_language", "DescName_12"), LocalStringManager.GetConfig("VillagerRoleArrangement_language", "DescShort_12"), LocalStringManager.GetConfig("VillagerRoleArrangement_language", "DescContent_12"), "ui9_back_villagerrole_Illustration_4_2"));
		_dataArray.Add(new VillagerRoleArrangementItem(13, 5, LocalStringManager.GetConfig("VillagerRoleArrangement_language", "ShortName_13"), LocalStringManager.GetConfig("VillagerRoleArrangement_language", "Name_13"), null, null, LocalStringManager.GetConfig("VillagerRoleArrangement_language", "Desc_13"), unlockByChicken: false, invisibleInGui: false, LocalStringManager.GetConfig("VillagerRoleArrangement_language", "DescName_13"), LocalStringManager.GetConfig("VillagerRoleArrangement_language", "DescShort_13"), LocalStringManager.GetConfig("VillagerRoleArrangement_language", "DescContent_13"), "ui9_back_villagerrole_Illustration_5_0"));
		_dataArray.Add(new VillagerRoleArrangementItem(14, 5, LocalStringManager.GetConfig("VillagerRoleArrangement_language", "ShortName_14"), LocalStringManager.GetConfig("VillagerRoleArrangement_language", "Name_14"), null, null, LocalStringManager.GetConfig("VillagerRoleArrangement_language", "Desc_14"), unlockByChicken: true, invisibleInGui: true, LocalStringManager.GetConfig("VillagerRoleArrangement_language", "DescName_14"), LocalStringManager.GetConfig("VillagerRoleArrangement_language", "DescShort_14"), LocalStringManager.GetConfig("VillagerRoleArrangement_language", "DescContent_14"), "ui9_back_villagerrole_Illustration_5_1"));
		_dataArray.Add(new VillagerRoleArrangementItem(15, 6, LocalStringManager.GetConfig("VillagerRoleArrangement_language", "ShortName_15"), LocalStringManager.GetConfig("VillagerRoleArrangement_language", "Name_15"), null, null, LocalStringManager.GetConfig("VillagerRoleArrangement_language", "Desc_15"), unlockByChicken: false, invisibleInGui: false, LocalStringManager.GetConfig("VillagerRoleArrangement_language", "DescName_15"), LocalStringManager.GetConfig("VillagerRoleArrangement_language", "DescShort_15"), LocalStringManager.GetConfig("VillagerRoleArrangement_language", "DescContent_15"), "ui9_back_villagerrole_Illustration_6_0"));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<VillagerRoleArrangementItem>(16);
		CreateItems0();
	}
}
