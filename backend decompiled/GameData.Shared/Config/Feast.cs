using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class Feast : ConfigData<FeastItem, short>
{
	public static class DefKey
	{
		public const short None = 0;

		public const short Fruit = 1;

		public const short Vegetable = 2;

		public const short WhiteMeat = 3;

		public const short RedMeat = 4;

		public const short SeaFood = 5;

		public const short Tea = 6;

		public const short Wine = 7;

		public const short Mixed = 8;

		public const short HighestMixed = 9;
	}

	public static class DefValue
	{
		public static FeastItem None => Instance[(short)0];

		public static FeastItem Fruit => Instance[(short)1];

		public static FeastItem Vegetable => Instance[(short)2];

		public static FeastItem WhiteMeat => Instance[(short)3];

		public static FeastItem RedMeat => Instance[(short)4];

		public static FeastItem SeaFood => Instance[(short)5];

		public static FeastItem Tea => Instance[(short)6];

		public static FeastItem Wine => Instance[(short)7];

		public static FeastItem Mixed => Instance[(short)8];

		public static FeastItem HighestMixed => Instance[(short)9];
	}

	public static Feast Instance = new Feast();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "Desc", "ConditionDesc", "EffectDesc", "RequirementType", "TemplateId", "Icon", "RequirementData" };

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
		_dataArray.Add(new FeastItem(0, LocalStringManager.GetConfig("Feast_language", "Name_0"), LocalStringManager.GetConfig("Feast_language", "Desc_0"), LocalStringManager.GetConfig("Feast_language", "ConditionDesc_0"), LocalStringManager.GetConfig("Feast_language", "EffectDesc_0"), 0, EFeastType.Invalid, null, 0, 0, 0, 0, 0, 0, 0, 0, ignoreHate: false, forceLove: false, null, null));
		_dataArray.Add(new FeastItem(1, LocalStringManager.GetConfig("Feast_language", "Name_1"), LocalStringManager.GetConfig("Feast_language", "Desc_1"), LocalStringManager.GetConfig("Feast_language", "ConditionDesc_1"), LocalStringManager.GetConfig("Feast_language", "EffectDesc_1"), 7, EFeastType.Fruit, "ui9_icon_feast_unlocked_fruit", 50, 100, 0, 100, 0, 0, 0, 0, ignoreHate: false, forceLove: false, new List<EFeastRequirementType> { EFeastRequirementType.FoodTypeFruit }, new List<int[]> { new int[2] { 3, 0 } }));
		_dataArray.Add(new FeastItem(2, LocalStringManager.GetConfig("Feast_language", "Name_2"), LocalStringManager.GetConfig("Feast_language", "Desc_2"), LocalStringManager.GetConfig("Feast_language", "ConditionDesc_2"), LocalStringManager.GetConfig("Feast_language", "EffectDesc_2"), 5, EFeastType.Vegetable, "ui9_icon_feast_unlocked_vegetable", 50, 100, 0, 0, 100, 0, 0, 0, ignoreHate: false, forceLove: false, new List<EFeastRequirementType> { EFeastRequirementType.FoodTypeVegetarian }, new List<int[]> { new int[2] { 3, 0 } }));
		_dataArray.Add(new FeastItem(3, LocalStringManager.GetConfig("Feast_language", "Name_3"), LocalStringManager.GetConfig("Feast_language", "Desc_3"), LocalStringManager.GetConfig("Feast_language", "ConditionDesc_3"), LocalStringManager.GetConfig("Feast_language", "EffectDesc_3"), 7, EFeastType.WhiteMeat, "ui9_icon_feast_unlocked_whitemeat", 50, 100, 0, 0, 0, 500, 0, 0, ignoreHate: false, forceLove: false, new List<EFeastRequirementType> { EFeastRequirementType.FoodTypeBird }, new List<int[]> { new int[2] { 3, 0 } }));
		_dataArray.Add(new FeastItem(4, LocalStringManager.GetConfig("Feast_language", "Name_4"), LocalStringManager.GetConfig("Feast_language", "Desc_4"), LocalStringManager.GetConfig("Feast_language", "ConditionDesc_4"), LocalStringManager.GetConfig("Feast_language", "EffectDesc_4"), 7, EFeastType.RedMeat, "ui9_icon_feast_unlocked_redmeat", 50, 100, 0, 0, 0, 0, 500, 0, ignoreHate: false, forceLove: false, new List<EFeastRequirementType> { EFeastRequirementType.FoodTypeBeast }, new List<int[]> { new int[2] { 3, 0 } }));
		_dataArray.Add(new FeastItem(5, LocalStringManager.GetConfig("Feast_language", "Name_5"), LocalStringManager.GetConfig("Feast_language", "Desc_5"), LocalStringManager.GetConfig("Feast_language", "ConditionDesc_5"), LocalStringManager.GetConfig("Feast_language", "EffectDesc_5"), 7, EFeastType.SeaFood, "ui9_icon_feast_unlocked_seafood", 50, 100, 0, 0, 0, 0, 0, 500, ignoreHate: false, forceLove: false, new List<EFeastRequirementType> { EFeastRequirementType.FoodTypeFish }, new List<int[]> { new int[2] { 3, 0 } }));
		_dataArray.Add(new FeastItem(6, LocalStringManager.GetConfig("Feast_language", "Name_6"), LocalStringManager.GetConfig("Feast_language", "Desc_6"), LocalStringManager.GetConfig("Feast_language", "ConditionDesc_6"), LocalStringManager.GetConfig("Feast_language", "EffectDesc_6"), 5, EFeastType.Tea, "ui9_icon_feast_unlocked_tea", 0, 200, 0, 0, 0, 0, 0, 0, ignoreHate: false, forceLove: false, new List<EFeastRequirementType> { EFeastRequirementType.SubTypeTea }, new List<int[]> { new int[2] { 2, 0 } }));
		_dataArray.Add(new FeastItem(7, LocalStringManager.GetConfig("Feast_language", "Name_7"), LocalStringManager.GetConfig("Feast_language", "Desc_7"), LocalStringManager.GetConfig("Feast_language", "ConditionDesc_7"), LocalStringManager.GetConfig("Feast_language", "EffectDesc_7"), 5, EFeastType.Wine, "ui9_icon_feast_unlocked_wine", 100, 0, 0, 0, 0, 0, 0, 0, ignoreHate: false, forceLove: false, new List<EFeastRequirementType> { EFeastRequirementType.SubTypeWine }, new List<int[]> { new int[2] { 2, 0 } }));
		_dataArray.Add(new FeastItem(8, LocalStringManager.GetConfig("Feast_language", "Name_8"), LocalStringManager.GetConfig("Feast_language", "Desc_8"), LocalStringManager.GetConfig("Feast_language", "ConditionDesc_8"), LocalStringManager.GetConfig("Feast_language", "EffectDesc_8"), 4, EFeastType.Mixed, "ui9_icon_feast_unlocked_mixed", 50, 50, 0, 0, 0, 0, 0, 0, ignoreHate: true, forceLove: false, new List<EFeastRequirementType> { EFeastRequirementType.SubTypeDiff }, new List<int[]> { new int[2] { 3, 0 } }));
		_dataArray.Add(new FeastItem(9, LocalStringManager.GetConfig("Feast_language", "Name_9"), LocalStringManager.GetConfig("Feast_language", "Desc_9"), LocalStringManager.GetConfig("Feast_language", "ConditionDesc_9"), LocalStringManager.GetConfig("Feast_language", "EffectDesc_9"), 8, EFeastType.HighestMixed, "ui9_icon_feast_unlocked_highestmixed", 150, 300, 0, 0, 0, 0, 0, 0, ignoreHate: true, forceLove: true, new List<EFeastRequirementType> { EFeastRequirementType.SubTypeDiff }, new List<int[]> { new int[2] { 3, 8 } }));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<FeastItem>(10);
		CreateItems0();
	}
}
