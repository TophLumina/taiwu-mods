using System;
using System.Collections.Generic;
using Config.Common;
using Config.ConfigCells.Character;
using GameData.Domains.Character;

namespace Config;

[Serializable]
public class Armor : ConfigData<ArmorItem, short>
{
	public static Armor Instance = new Armor();

	private readonly HashSet<string> RequiredFields = new HashSet<string>
	{
		"Name", "ItemSubType", "GroupId", "Desc", "FunctionDesc", "ResourceType", "MakeItemSubType", "TaskLock", "EquipmentEffectId", "EquipmentMasteryId",
		"RequiredCharacterProperties", "RelatedWeapon", "TemplateId", "Grade", "Icon", "MaxDurability", "BaseWeight", "BaseHappinessChange", "DropRate", "EquipmentType",
		"BaseEquipmentAttack", "BaseEquipmentDefense", "SkeletonSlotAndAttachment"
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
		_dataArray.Add(new ArmorItem(0, LocalStringManager.GetConfig("Armor_language", "Name_0"), 1, 100, 0, 0, "icon_Armor_toutuotiegu", LocalStringManager.GetConfig("Armor_language", "Desc_0"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_0"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 210, 300, 0, 2, 600, 3, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 45, isSpecial: false, 2, 36, 118, new List<int>(), 1, -1, 1793, 625, 625, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 60)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(40, 0), new OuterAndInnerShorts(10, 0), -1, new List<string> { "equip_hel/equip_hel", "equip_hel/equip_hel_131" }, 100));
		_dataArray.Add(new ArmorItem(1, LocalStringManager.GetConfig("Armor_language", "Name_1"), 1, 100, 1, 0, "icon_Armor_bingangkui", LocalStringManager.GetConfig("Armor_language", "Desc_1"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_1"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 275, 600, 0, 4, 1200, 4, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 40, isSpecial: false, 2, 36, 118, new List<int>(), 1, -1, 1793, 700, 700, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 65)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(50, 0), new OuterAndInnerShorts(10, 0), -1, new List<string> { "equip_hel/equip_hel", "equip_hel/equip_hel_131" }, 100));
		_dataArray.Add(new ArmorItem(2, LocalStringManager.GetConfig("Armor_language", "Name_2"), 1, 100, 2, 0, "icon_Armor_suweidou", LocalStringManager.GetConfig("Armor_language", "Desc_2"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_2"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 345, 1800, 1, 6, 1800, 5, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 35, isSpecial: false, 2, 36, 118, new List<int>(), 1, -1, 1793, 790, 790, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 70)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(60, 0), new OuterAndInnerShorts(15, 0), -1, new List<string> { "equip_hel/equip_hel", "equip_hel/equip_hel_131" }, 100));
		_dataArray.Add(new ArmorItem(3, LocalStringManager.GetConfig("Armor_language", "Name_3"), 1, 100, 3, 0, "icon_Armor_jiangjunwuyoudou", LocalStringManager.GetConfig("Armor_language", "Desc_3"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_3"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 410, 4500, 2, 8, 3000, 6, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 30, isSpecial: false, 2, 36, 118, new List<int>(), 1, -1, 1793, 880, 880, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 75)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(70, 0), new OuterAndInnerShorts(20, 0), -1, new List<string> { "equip_hel/equip_hel", "equip_hel/equip_hel_135" }, 100));
		_dataArray.Add(new ArmorItem(4, LocalStringManager.GetConfig("Armor_language", "Name_4"), 1, 100, 4, 0, "icon_Armor_babaohutoukui", LocalStringManager.GetConfig("Armor_language", "Desc_4"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_4"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 480, 9300, 3, 10, 4200, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 25, isSpecial: false, 2, 36, 118, new List<int>(), 1, -1, 1793, 975, 975, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 80)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(80, 0), new OuterAndInnerShorts(20, 0), -1, new List<string> { "equip_hel/equip_hel", "equip_hel/equip_hel_135" }, 100));
		_dataArray.Add(new ArmorItem(5, LocalStringManager.GetConfig("Armor_language", "Name_5"), 1, 100, 5, 0, "icon_Armor_jingangli", LocalStringManager.GetConfig("Armor_language", "Desc_5"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_5"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 545, 16800, 4, 12, 5400, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 20, isSpecial: false, 2, 36, 118, new List<int>(), 1, -1, 1793, 1070, 1070, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 85)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(90, 0), new OuterAndInnerShorts(25, 0), -1, new List<string> { "equip_hel/equip_hel", "equip_hel/equip_hel_135" }, 100));
		_dataArray.Add(new ArmorItem(6, LocalStringManager.GetConfig("Armor_language", "Name_6"), 1, 100, 6, 0, "icon_Armor_tiewolong", LocalStringManager.GetConfig("Armor_language", "Desc_6"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_6"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 615, 27600, 5, 14, 7200, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 15, isSpecial: false, 2, 36, 118, new List<int>(), 1, -1, 1793, 1180, 1180, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 90)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(100, 0), new OuterAndInnerShorts(30, 0), -1, new List<string> { "equip_hel/equip_hel", "equip_hel/equip_hel_139" }, 100));
		_dataArray.Add(new ArmorItem(7, LocalStringManager.GetConfig("Armor_language", "Name_7"), 1, 100, 7, 0, "icon_Armor_daaonilindou", LocalStringManager.GetConfig("Armor_language", "Desc_7"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_7"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 680, 42300, 6, 16, 9000, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 10, isSpecial: false, 2, 36, 118, new List<int>(), 1, -1, 1793, 1285, 1285, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 95)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(110, 0), new OuterAndInnerShorts(30, 0), -1, new List<string> { "equip_hel/equip_hel", "equip_hel/equip_hel_139" }, 100));
		_dataArray.Add(new ArmorItem(8, LocalStringManager.GetConfig("Armor_language", "Name_8"), 1, 100, 8, 0, "icon_Armor_xuantieli", LocalStringManager.GetConfig("Armor_language", "Desc_8"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_8"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 750, 61500, 6, 18, 10800, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 5, isSpecial: false, 2, 36, 118, new List<int>(), 1, -1, 1793, 1400, 1400, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 100)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(120, 0), new OuterAndInnerShorts(35, 0), -1, new List<string> { "equip_hel/equip_hel", "equip_hel/equip_hel_139" }, 100));
		_dataArray.Add(new ArmorItem(9, LocalStringManager.GetConfig("Armor_language", "Name_9"), 1, 100, 0, 9, "icon_Armor_tongdou", LocalStringManager.GetConfig("Armor_language", "Desc_9"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_9"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 180, 300, 0, 2, 600, 3, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 45, isSpecial: false, 2, 36, 125, new List<int>(), 1, -1, 1793, 490, 730, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 60)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(20, 20), new OuterAndInnerShorts(0, 0), -1, new List<string> { "headwear/headwear", "headwear/headwear_131" }, 100));
		_dataArray.Add(new ArmorItem(10, LocalStringManager.GetConfig("Armor_language", "Name_10"), 1, 100, 1, 9, "icon_Armor_louhuabiandian", LocalStringManager.GetConfig("Armor_language", "Desc_10"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_10"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 230, 600, 0, 4, 1200, 4, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 40, isSpecial: false, 2, 36, 125, new List<int>(), 1, -1, 1793, 555, 815, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 65)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(30, 30), new OuterAndInnerShorts(0, 0), -1, new List<string> { "headwear/headwear", "headwear/headwear_131" }, 100));
		_dataArray.Add(new ArmorItem(11, LocalStringManager.GetConfig("Armor_language", "Name_11"), 1, 100, 2, 9, "icon_Armor_shaoyinlandian", LocalStringManager.GetConfig("Armor_language", "Desc_11"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_11"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 285, 1800, 1, 6, 1800, 5, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 35, isSpecial: false, 2, 36, 125, new List<int>(), 1, -1, 1793, 625, 905, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 70)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(40, 40), new OuterAndInnerShorts(0, 0), -1, new List<string> { "headwear/headwear", "headwear/headwear_131" }, 100));
		_dataArray.Add(new ArmorItem(12, LocalStringManager.GetConfig("Armor_language", "Name_12"), 1, 100, 3, 9, "icon_Armor_baishejindian", LocalStringManager.GetConfig("Armor_language", "Desc_12"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_12"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 335, 4500, 2, 8, 3000, 6, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 30, isSpecial: false, 2, 36, 125, new List<int>(), 1, -1, 1793, 690, 990, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 75)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(50, 50), new OuterAndInnerShorts(10, 10), -1, new List<string> { "headwear/headwear", "headwear/headwear_135" }, 100));
		_dataArray.Add(new ArmorItem(13, LocalStringManager.GetConfig("Armor_language", "Name_13"), 1, 100, 4, 9, "icon_Armor_zijinguan", LocalStringManager.GetConfig("Armor_language", "Desc_13"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_13"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 390, 9300, 3, 10, 4200, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 25, isSpecial: false, 2, 36, 125, new List<int>(), 1, -1, 1793, 770, 1090, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 80)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(60, 60), new OuterAndInnerShorts(10, 10), -1, new List<string> { "headwear/headwear", "headwear/headwear_135" }, 100));
		_dataArray.Add(new ArmorItem(14, LocalStringManager.GetConfig("Armor_language", "Name_14"), 1, 100, 5, 9, "icon_Armor_linjiaoshiziguan", LocalStringManager.GetConfig("Armor_language", "Desc_14"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_14"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 440, 16800, 4, 12, 5400, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 20, isSpecial: false, 2, 36, 125, new List<int>(), 1, -1, 1793, 840, 1180, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 85)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(70, 70), new OuterAndInnerShorts(15, 15), -1, new List<string> { "headwear/headwear", "headwear/headwear_135" }, 100));
		_dataArray.Add(new ArmorItem(15, LocalStringManager.GetConfig("Armor_language", "Name_15"), 1, 100, 6, 9, "icon_Armor_jinjingshouliandou", LocalStringManager.GetConfig("Armor_language", "Desc_15"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_15"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 495, 27600, 5, 14, 7200, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 15, isSpecial: false, 2, 36, 125, new List<int>(), 1, -1, 1793, 925, 1285, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 90)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(80, 80), new OuterAndInnerShorts(20, 20), -1, new List<string> { "headwear/headwear", "headwear/headwear_139" }, 100));
		_dataArray.Add(new ArmorItem(16, LocalStringManager.GetConfig("Armor_language", "Name_16"), 1, 100, 7, 9, "icon_Armor_tunxiabaodian", LocalStringManager.GetConfig("Armor_language", "Desc_16"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_16"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 545, 42300, 6, 16, 9000, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 10, isSpecial: false, 2, 36, 125, new List<int>(), 1, -1, 1793, 1005, 1385, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 95)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(90, 90), new OuterAndInnerShorts(20, 20), -1, new List<string> { "headwear/headwear", "headwear/headwear_139" }, 100));
		_dataArray.Add(new ArmorItem(17, LocalStringManager.GetConfig("Armor_language", "Name_17"), 1, 100, 8, 9, "icon_Armor_jiutoujiao", LocalStringManager.GetConfig("Armor_language", "Desc_17"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_17"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 600, 61500, 6, 18, 10800, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 5, isSpecial: false, 2, 36, 125, new List<int>(), 1, -1, 1793, 1100, 1500, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 100)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(100, 100), new OuterAndInnerShorts(25, 25), -1, new List<string> { "headwear/headwear", "headwear/headwear_139" }, 100));
		_dataArray.Add(new ArmorItem(18, LocalStringManager.GetConfig("Armor_language", "Name_18"), 1, 100, 0, 18, "icon_Armor_baimuzan", LocalStringManager.GetConfig("Armor_language", "Desc_18"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_18"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 60, 70, 300, 0, 2, 600, 3, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 45, isSpecial: false, 1, 36, 119, new List<int>(), 1, -1, 1794, 215, 575, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 50)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(20, 10), new OuterAndInnerShorts(0, 0), -1, new List<string> { "equip_hel/equip_hel", "equip_hel/equip_hel_211" }, 100));
		_dataArray.Add(new ArmorItem(19, LocalStringManager.GetConfig("Armor_language", "Name_19"), 1, 100, 1, 18, "icon_Armor_quezuiwuwenzan", LocalStringManager.GetConfig("Armor_language", "Desc_19"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_19"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 60, 100, 600, 0, 4, 1200, 4, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 40, isSpecial: false, 1, 36, 119, new List<int>(), 1, -1, 1794, 245, 635, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 55)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(30, 15), new OuterAndInnerShorts(0, 0), -1, new List<string> { "equip_hel/equip_hel", "equip_hel/equip_hel_211" }, 100));
		_dataArray.Add(new ArmorItem(20, LocalStringManager.GetConfig("Armor_language", "Name_20"), 1, 100, 2, 18, "icon_Armor_yulongguan", LocalStringManager.GetConfig("Armor_language", "Desc_20"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_20"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 60, 130, 1800, 1, 6, 1800, 5, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 35, isSpecial: false, 1, 36, 119, new List<int>(), 1, -1, 1794, 285, 705, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 60)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(40, 20), new OuterAndInnerShorts(10, 0), -1, new List<string> { "equip_hel/equip_hel", "equip_hel/equip_hel_211" }, 100));
		_dataArray.Add(new ArmorItem(21, LocalStringManager.GetConfig("Armor_language", "Name_21"), 1, 100, 3, 18, "icon_Armor_pomoyuanyang", LocalStringManager.GetConfig("Armor_language", "Desc_21"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_21"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 60, 160, 4500, 2, 8, 3000, 6, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 30, isSpecial: false, 1, 36, 119, new List<int>(), 1, -1, 1794, 325, 775, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 65)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(50, 25), new OuterAndInnerShorts(10, 0), -1, new List<string> { "equip_hel/equip_hel", "equip_hel/equip_hel_215" }, 100));
		_dataArray.Add(new ArmorItem(22, LocalStringManager.GetConfig("Armor_language", "Name_22"), 1, 100, 4, 18, "icon_Armor_hongmeizhuzan", LocalStringManager.GetConfig("Armor_language", "Desc_22"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_22"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 60, 190, 9300, 3, 10, 4200, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 25, isSpecial: false, 1, 36, 119, new List<int>(), 1, -1, 1794, 370, 850, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 70)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(60, 30), new OuterAndInnerShorts(15, 0), -1, new List<string> { "equip_hel/equip_hel", "equip_hel/equip_hel_215" }, 100));
		_dataArray.Add(new ArmorItem(23, LocalStringManager.GetConfig("Armor_language", "Name_23"), 1, 100, 5, 18, "icon_Armor_baihuahudiezan", LocalStringManager.GetConfig("Armor_language", "Desc_23"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_23"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 60, 220, 16800, 4, 12, 5400, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 20, isSpecial: false, 1, 36, 119, new List<int>(), 1, -1, 1794, 410, 920, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 75)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(70, 35), new OuterAndInnerShorts(20, 0), -1, new List<string> { "equip_hel/equip_hel", "equip_hel/equip_hel_215" }, 100));
		_dataArray.Add(new ArmorItem(24, LocalStringManager.GetConfig("Armor_language", "Name_24"), 1, 100, 6, 18, "icon_Armor_fulongyinxiangzan", LocalStringManager.GetConfig("Armor_language", "Desc_24"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_24"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 60, 250, 27600, 5, 14, 7200, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 15, isSpecial: false, 1, 36, 119, new List<int>(), 1, -1, 1794, 460, 1000, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 80)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(80, 40), new OuterAndInnerShorts(20, 0), -1, new List<string> { "equip_hel/equip_hel", "equip_hel/equip_hel_219" }, 100));
		_dataArray.Add(new ArmorItem(25, LocalStringManager.GetConfig("Armor_language", "Name_25"), 1, 100, 7, 18, "icon_Armor_huanglongbaoguan", LocalStringManager.GetConfig("Armor_language", "Desc_25"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_25"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 60, 280, 42300, 6, 16, 9000, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 10, isSpecial: false, 1, 36, 119, new List<int>(), 1, -1, 1794, 505, 1075, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 85)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(90, 45), new OuterAndInnerShorts(25, 0), -1, new List<string> { "equip_hel/equip_hel", "equip_hel/equip_hel_219" }, 100));
		_dataArray.Add(new ArmorItem(26, LocalStringManager.GetConfig("Armor_language", "Name_26"), 1, 100, 8, 18, "icon_Armor_zhaochenshu", LocalStringManager.GetConfig("Armor_language", "Desc_26"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_26"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 60, 310, 61500, 6, 18, 10800, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 5, isSpecial: false, 1, 36, 119, new List<int>(), 1, -1, 1794, 560, 1160, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 90)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(100, 50), new OuterAndInnerShorts(30, 0), -1, new List<string> { "equip_hel/equip_hel", "equip_hel/equip_hel_219" }, 100));
		_dataArray.Add(new ArmorItem(27, LocalStringManager.GetConfig("Armor_language", "Name_27"), 1, 100, 0, 27, "icon_Armor_qingzhuzan", LocalStringManager.GetConfig("Armor_language", "Desc_27"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_27"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 60, 45, 300, 0, 2, 600, 3, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 45, isSpecial: false, 1, 36, 126, new List<int>(), 1, -1, 1794, 265, 505, new List<PropertyAndValue>
		{
			new PropertyAndValue(4, 50)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(10, 20), new OuterAndInnerShorts(0, 0), -1, new List<string> { "equip_hel/equip_hel", "equip_hel/equip_hel_231" }, 100));
		_dataArray.Add(new ArmorItem(28, LocalStringManager.GetConfig("Armor_language", "Name_28"), 1, 100, 1, 27, "icon_Armor_wuzhumianju", LocalStringManager.GetConfig("Armor_language", "Desc_28"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_28"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 60, 70, 600, 0, 4, 1200, 4, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 40, isSpecial: false, 1, 36, 126, new List<int>(), 1, -1, 1794, 300, 560, new List<PropertyAndValue>
		{
			new PropertyAndValue(4, 55)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(15, 30), new OuterAndInnerShorts(0, 0), -1, new List<string> { "equip_hel/equip_hel", "equip_hel/equip_hel_231" }, 100));
		_dataArray.Add(new ArmorItem(29, LocalStringManager.GetConfig("Armor_language", "Name_29"), 1, 100, 2, 27, "icon_Armor_duanyanzan", LocalStringManager.GetConfig("Armor_language", "Desc_29"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_29"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 60, 95, 1800, 1, 6, 1800, 5, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 35, isSpecial: false, 1, 36, 126, new List<int>(), 1, -1, 1794, 335, 615, new List<PropertyAndValue>
		{
			new PropertyAndValue(4, 60)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(20, 40), new OuterAndInnerShorts(0, 10), -1, new List<string> { "equip_hel/equip_hel", "equip_hel/equip_hel_231" }, 100));
		_dataArray.Add(new ArmorItem(30, LocalStringManager.GetConfig("Armor_language", "Name_30"), 1, 100, 3, 27, "icon_Armor_qiushouzanbi", LocalStringManager.GetConfig("Armor_language", "Desc_30"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_30"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 60, 120, 4500, 2, 8, 3000, 6, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 30, isSpecial: false, 1, 36, 126, new List<int>(), 1, -1, 1794, 375, 675, new List<PropertyAndValue>
		{
			new PropertyAndValue(4, 65)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(25, 50), new OuterAndInnerShorts(0, 10), -1, new List<string> { "equip_hel/equip_hel", "equip_hel/equip_hel_235" }, 100));
		_dataArray.Add(new ArmorItem(31, LocalStringManager.GetConfig("Armor_language", "Name_31"), 1, 100, 4, 27, "icon_Armor_lianhuaguan", LocalStringManager.GetConfig("Armor_language", "Desc_31"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_31"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 60, 140, 9300, 3, 10, 4200, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 25, isSpecial: false, 1, 36, 126, new List<int>(), 1, -1, 1794, 415, 735, new List<PropertyAndValue>
		{
			new PropertyAndValue(4, 70)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(30, 60), new OuterAndInnerShorts(0, 15), -1, new List<string> { "equip_hel/equip_hel", "equip_hel/equip_hel_235" }, 100));
		_dataArray.Add(new ArmorItem(32, LocalStringManager.GetConfig("Armor_language", "Name_32"), 1, 100, 5, 27, "icon_Armor_mihuaguimian", LocalStringManager.GetConfig("Armor_language", "Desc_32"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_32"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 60, 165, 16800, 4, 12, 5400, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 20, isSpecial: false, 1, 36, 126, new List<int>(), 1, -1, 1794, 460, 800, new List<PropertyAndValue>
		{
			new PropertyAndValue(4, 75)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(35, 70), new OuterAndInnerShorts(0, 20), -1, new List<string> { "equip_hel/equip_hel", "equip_hel/equip_hel_235" }, 100));
		_dataArray.Add(new ArmorItem(33, LocalStringManager.GetConfig("Armor_language", "Name_33"), 1, 100, 6, 27, "icon_Armor_wujikou", LocalStringManager.GetConfig("Armor_language", "Desc_33"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_33"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 60, 190, 27600, 5, 14, 7200, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 15, isSpecial: false, 1, 36, 126, new List<int>(), 1, -1, 1794, 505, 865, new List<PropertyAndValue>
		{
			new PropertyAndValue(4, 80)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(40, 80), new OuterAndInnerShorts(0, 20), -1, new List<string> { "equip_hel/equip_hel", "equip_hel/equip_hel_239" }, 100));
		_dataArray.Add(new ArmorItem(34, LocalStringManager.GetConfig("Armor_language", "Name_34"), 1, 100, 7, 27, "icon_Armor_shenmufazan", LocalStringManager.GetConfig("Armor_language", "Desc_34"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_34"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 60, 215, 42300, 6, 16, 9000, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 10, isSpecial: false, 1, 36, 126, new List<int>(), 1, -1, 1794, 550, 930, new List<PropertyAndValue>
		{
			new PropertyAndValue(4, 85)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(45, 90), new OuterAndInnerShorts(0, 25), -1, new List<string> { "equip_hel/equip_hel", "equip_hel/equip_hel_239" }, 100));
		_dataArray.Add(new ArmorItem(35, LocalStringManager.GetConfig("Armor_language", "Name_35"), 1, 100, 8, 27, "icon_Armor_ziyuanyin", LocalStringManager.GetConfig("Armor_language", "Desc_35"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_35"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 60, 240, 61500, 6, 18, 10800, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 5, isSpecial: false, 1, 36, 126, new List<int>(), 1, -1, 1794, 600, 1000, new List<PropertyAndValue>
		{
			new PropertyAndValue(4, 90)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(50, 100), new OuterAndInnerShorts(0, 30), -1, new List<string> { "equip_hel/equip_hel", "equip_hel/equip_hel_239" }, 100));
		_dataArray.Add(new ArmorItem(36, LocalStringManager.GetConfig("Armor_language", "Name_36"), 1, 100, 0, 36, "icon_Armor_chize", LocalStringManager.GetConfig("Armor_language", "Desc_36"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_36"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 60, 300, 0, 2, 600, 3, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 45, isSpecial: false, 4, 36, 121, new List<int>(), 1, -1, 1796, 155, 395, new List<PropertyAndValue>
		{
			new PropertyAndValue(1, 20),
			new PropertyAndValue(3, 20)
		}, new HitOrAvoidShorts(0, 0, 20, 0), new OuterAndInnerShorts(20, 0), new OuterAndInnerShorts(0, 0), -1, new List<string> { "hair/hair_hat", "hair/hair_311" }, 100));
		_dataArray.Add(new ArmorItem(37, LocalStringManager.GetConfig("Armor_language", "Name_37"), 1, 100, 1, 36, "icon_Armor_xiaoyaojin", LocalStringManager.GetConfig("Armor_language", "Desc_37"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_37"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 65, 600, 0, 4, 1200, 4, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 40, isSpecial: false, 4, 36, 121, new List<int>(), 1, -1, 1796, 170, 430, new List<PropertyAndValue>
		{
			new PropertyAndValue(1, 25),
			new PropertyAndValue(3, 25)
		}, new HitOrAvoidShorts(0, 0, 20, 0), new OuterAndInnerShorts(30, 0), new OuterAndInnerShorts(0, 0), -1, new List<string> { "hair/hair_hat", "hair/hair_311" }, 100));
		_dataArray.Add(new ArmorItem(38, LocalStringManager.GetConfig("Armor_language", "Name_38"), 1, 100, 2, 36, "icon_Armor_xianyunguan", LocalStringManager.GetConfig("Armor_language", "Desc_38"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_38"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 70, 1800, 1, 6, 1800, 5, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 35, isSpecial: false, 4, 36, 121, new List<int>(), 1, -1, 1796, 190, 470, new List<PropertyAndValue>
		{
			new PropertyAndValue(1, 30),
			new PropertyAndValue(3, 30)
		}, new HitOrAvoidShorts(0, 0, 20, 0), new OuterAndInnerShorts(40, 0), new OuterAndInnerShorts(0, 0), -1, new List<string> { "hair/hair_hat", "hair/hair_311" }, 100));
		_dataArray.Add(new ArmorItem(39, LocalStringManager.GetConfig("Armor_language", "Name_39"), 1, 100, 3, 36, "icon_Armor_bailujin", LocalStringManager.GetConfig("Armor_language", "Desc_39"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_39"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 75, 4500, 2, 8, 3000, 6, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 30, isSpecial: false, 4, 36, 121, new List<int>(), 1, -1, 1796, 205, 505, new List<PropertyAndValue>
		{
			new PropertyAndValue(1, 35),
			new PropertyAndValue(3, 35)
		}, new HitOrAvoidShorts(0, 0, 25, 0), new OuterAndInnerShorts(50, 0), new OuterAndInnerShorts(0, 0), -1, new List<string> { "hair/hair_hat", "hair/hair_315" }, 100));
		_dataArray.Add(new ArmorItem(40, LocalStringManager.GetConfig("Armor_language", "Name_40"), 1, 100, 4, 36, "icon_Armor_qingchifeiyingguan", LocalStringManager.GetConfig("Armor_language", "Desc_40"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_40"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 80, 9300, 3, 10, 4200, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 25, isSpecial: false, 4, 36, 121, new List<int>(), 1, -1, 1796, 225, 545, new List<PropertyAndValue>
		{
			new PropertyAndValue(1, 40),
			new PropertyAndValue(3, 40)
		}, new HitOrAvoidShorts(0, 0, 25, 0), new OuterAndInnerShorts(60, 0), new OuterAndInnerShorts(0, 0), -1, new List<string> { "hair/hair_hat", "hair/hair_315" }, 100));
		_dataArray.Add(new ArmorItem(41, LocalStringManager.GetConfig("Armor_language", "Name_41"), 1, 100, 5, 36, "icon_Armor_yunxiajin", LocalStringManager.GetConfig("Armor_language", "Desc_41"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_41"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 85, 16800, 4, 12, 5400, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 20, isSpecial: false, 4, 36, 121, new List<int>(), 1, -1, 1796, 240, 580, new List<PropertyAndValue>
		{
			new PropertyAndValue(1, 45),
			new PropertyAndValue(3, 45)
		}, new HitOrAvoidShorts(0, 0, 25, 0), new OuterAndInnerShorts(70, 0), new OuterAndInnerShorts(0, 0), -1, new List<string> { "hair/hair_hat", "hair/hair_315" }, 100));
		_dataArray.Add(new ArmorItem(42, LocalStringManager.GetConfig("Armor_language", "Name_42"), 1, 100, 6, 36, "icon_Armor_ruyihunyuanjin", LocalStringManager.GetConfig("Armor_language", "Desc_42"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_42"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 90, 27600, 5, 14, 7200, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 15, isSpecial: false, 4, 36, 121, new List<int>(), 1, -1, 1796, 260, 620, new List<PropertyAndValue>
		{
			new PropertyAndValue(1, 50),
			new PropertyAndValue(3, 50)
		}, new HitOrAvoidShorts(0, 0, 30, 0), new OuterAndInnerShorts(80, 0), new OuterAndInnerShorts(0, 0), -1, new List<string> { "hair/hair_hat", "hair/hair_319" }, 100));
		_dataArray.Add(new ArmorItem(43, LocalStringManager.GetConfig("Armor_language", "Name_43"), 1, 100, 7, 36, "icon_Armor_tianyanjintong", LocalStringManager.GetConfig("Armor_language", "Desc_43"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_43"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 95, 42300, 6, 16, 9000, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 10, isSpecial: false, 4, 36, 121, new List<int>(), 1, -1, 1796, 275, 655, new List<PropertyAndValue>
		{
			new PropertyAndValue(1, 55),
			new PropertyAndValue(3, 55)
		}, new HitOrAvoidShorts(0, 0, 30, 0), new OuterAndInnerShorts(90, 0), new OuterAndInnerShorts(0, 0), -1, new List<string> { "hair/hair_hat", "hair/hair_319" }, 100));
		_dataArray.Add(new ArmorItem(44, LocalStringManager.GetConfig("Armor_language", "Name_44"), 1, 100, 8, 36, "icon_Armor_chankebaoshu", LocalStringManager.GetConfig("Armor_language", "Desc_44"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_44"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 100, 61500, 6, 18, 10800, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 5, isSpecial: false, 4, 36, 121, new List<int>(), 1, -1, 1796, 300, 700, new List<PropertyAndValue>
		{
			new PropertyAndValue(1, 60),
			new PropertyAndValue(3, 60)
		}, new HitOrAvoidShorts(0, 0, 30, 0), new OuterAndInnerShorts(100, 0), new OuterAndInnerShorts(0, 0), -1, new List<string> { "hair/hair_hat", "hair/hair_319" }, 100));
		_dataArray.Add(new ArmorItem(45, LocalStringManager.GetConfig("Armor_language", "Name_45"), 1, 100, 0, 45, "icon_Armor_hupidou", LocalStringManager.GetConfig("Armor_language", "Desc_45"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_45"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 100, 300, 0, 2, 600, 3, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 45, isSpecial: false, 4, 36, 122, new List<int>(), 1, -1, 1796, 180, 420, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 20),
			new PropertyAndValue(3, 20)
		}, new HitOrAvoidShorts(20, 0, 0, 0), new OuterAndInnerShorts(20, 0), new OuterAndInnerShorts(0, 0), -1, new List<string> { "equip_hel/equip_hel", "equip_hel/equip_hel_331" }, 100));
		_dataArray.Add(new ArmorItem(46, LocalStringManager.GetConfig("Armor_language", "Name_46"), 1, 100, 1, 45, "icon_Armor_fanyangdouli", LocalStringManager.GetConfig("Armor_language", "Desc_46"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_46"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 105, 600, 0, 4, 1200, 4, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 40, isSpecial: false, 4, 36, 122, new List<int>(), 1, -1, 1796, 195, 455, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 25),
			new PropertyAndValue(3, 25)
		}, new HitOrAvoidShorts(20, 0, 0, 0), new OuterAndInnerShorts(30, 0), new OuterAndInnerShorts(0, 0), -1, new List<string> { "equip_hel/equip_hel", "equip_hel/equip_hel_331" }, 100));
		_dataArray.Add(new ArmorItem(47, LocalStringManager.GetConfig("Armor_language", "Name_47"), 1, 100, 2, 45, "icon_Armor_shuanglilongguan", LocalStringManager.GetConfig("Armor_language", "Desc_47"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_47"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 110, 1800, 1, 6, 1800, 5, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 35, isSpecial: false, 4, 36, 122, new List<int>(), 1, -1, 1796, 215, 495, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 30),
			new PropertyAndValue(3, 30)
		}, new HitOrAvoidShorts(20, 0, 0, 0), new OuterAndInnerShorts(40, 0), new OuterAndInnerShorts(0, 0), -1, new List<string> { "equip_hel/equip_hel", "equip_hel/equip_hel_331" }, 100));
		_dataArray.Add(new ArmorItem(48, LocalStringManager.GetConfig("Armor_language", "Name_48"), 1, 100, 3, 45, "icon_Armor_baishoudou", LocalStringManager.GetConfig("Armor_language", "Desc_48"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_48"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 115, 4500, 2, 8, 3000, 6, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 30, isSpecial: false, 4, 36, 122, new List<int>(), 1, -1, 1796, 235, 535, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 35),
			new PropertyAndValue(3, 35)
		}, new HitOrAvoidShorts(25, 0, 0, 0), new OuterAndInnerShorts(50, 0), new OuterAndInnerShorts(0, 0), -1, new List<string> { "equip_hel/equip_hel", "equip_hel/equip_hel_335" }, 100));
		_dataArray.Add(new ArmorItem(49, LocalStringManager.GetConfig("Armor_language", "Name_49"), 1, 100, 4, 45, "icon_Armor_xuerongmao", LocalStringManager.GetConfig("Armor_language", "Desc_49"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_49"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 120, 9300, 3, 10, 4200, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 25, isSpecial: false, 4, 36, 122, new List<int>(), 1, -1, 1796, 255, 575, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 40),
			new PropertyAndValue(3, 40)
		}, new HitOrAvoidShorts(25, 0, 0, 0), new OuterAndInnerShorts(60, 0), new OuterAndInnerShorts(0, 0), -1, new List<string> { "equip_hel/equip_hel", "equip_hel/equip_hel_335" }, 100));
		_dataArray.Add(new ArmorItem(50, LocalStringManager.GetConfig("Armor_language", "Name_50"), 1, 100, 5, 45, "icon_Armor_bixieduishouguan", LocalStringManager.GetConfig("Armor_language", "Desc_50"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_50"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 125, 16800, 4, 12, 5400, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 20, isSpecial: false, 4, 36, 122, new List<int>(), 1, -1, 1796, 270, 610, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 45),
			new PropertyAndValue(3, 45)
		}, new HitOrAvoidShorts(25, 0, 0, 0), new OuterAndInnerShorts(70, 0), new OuterAndInnerShorts(0, 0), -1, new List<string> { "equip_hel/equip_hel", "equip_hel/equip_hel_335" }, 100));
		_dataArray.Add(new ArmorItem(51, LocalStringManager.GetConfig("Armor_language", "Name_51"), 1, 100, 6, 45, "icon_Armor_jiufengzhuling", LocalStringManager.GetConfig("Armor_language", "Desc_51"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_51"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 130, 27600, 5, 14, 7200, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 15, isSpecial: false, 4, 36, 122, new List<int>(), 1, -1, 1796, 295, 655, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 50),
			new PropertyAndValue(3, 50)
		}, new HitOrAvoidShorts(30, 0, 0, 0), new OuterAndInnerShorts(80, 0), new OuterAndInnerShorts(0, 0), -1, new List<string> { "equip_hel/equip_hel", "equip_hel/equip_hel_339" }, 100));
		_dataArray.Add(new ArmorItem(52, LocalStringManager.GetConfig("Armor_language", "Name_52"), 1, 100, 7, 45, "icon_Armor_yanwangmian", LocalStringManager.GetConfig("Armor_language", "Desc_52"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_52"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 135, 42300, 6, 16, 9000, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 10, isSpecial: false, 4, 36, 122, new List<int>(), 1, -1, 1796, 315, 695, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 55),
			new PropertyAndValue(3, 55)
		}, new HitOrAvoidShorts(30, 0, 0, 0), new OuterAndInnerShorts(90, 0), new OuterAndInnerShorts(0, 0), -1, new List<string> { "equip_hel/equip_hel", "equip_hel/equip_hel_339" }, 100));
		_dataArray.Add(new ArmorItem(53, LocalStringManager.GetConfig("Armor_language", "Name_53"), 1, 100, 8, 45, "icon_Armor_daluotianxianguan", LocalStringManager.GetConfig("Armor_language", "Desc_53"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_53"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 140, 61500, 6, 18, 10800, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 5, isSpecial: false, 4, 36, 122, new List<int>(), 1, -1, 1796, 340, 740, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 60),
			new PropertyAndValue(3, 60)
		}, new HitOrAvoidShorts(30, 0, 0, 0), new OuterAndInnerShorts(100, 0), new OuterAndInnerShorts(0, 0), -1, new List<string> { "equip_hel/equip_hel", "equip_hel/equip_hel_339" }, 100));
		_dataArray.Add(new ArmorItem(54, LocalStringManager.GetConfig("Armor_language", "Name_54"), 1, 100, 0, 54, "icon_Armor_zhanmao", LocalStringManager.GetConfig("Armor_language", "Desc_54"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_54"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 80, 300, 0, 2, 600, 3, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 45, isSpecial: false, 4, 36, 123, new List<int>(), 1, -1, 1796, 170, 410, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 20),
			new PropertyAndValue(5, 20)
		}, new HitOrAvoidShorts(0, 20, 0, 0), new OuterAndInnerShorts(20, 0), new OuterAndInnerShorts(0, 0), -1, new List<string> { "equip_hel/equip_hel", "equip_hel/equip_hel_311" }, 100));
		_dataArray.Add(new ArmorItem(55, LocalStringManager.GetConfig("Armor_language", "Name_55"), 1, 100, 1, 54, "icon_Armor_jinmaoqiaotou", LocalStringManager.GetConfig("Armor_language", "Desc_55"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_55"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 85, 600, 0, 4, 1200, 4, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 40, isSpecial: false, 4, 36, 123, new List<int>(), 1, -1, 1796, 180, 440, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 25),
			new PropertyAndValue(5, 25)
		}, new HitOrAvoidShorts(0, 20, 0, 0), new OuterAndInnerShorts(30, 0), new OuterAndInnerShorts(0, 0), -1, new List<string> { "equip_hel/equip_hel", "equip_hel/equip_hel_311" }, 100));
		_dataArray.Add(new ArmorItem(56, LocalStringManager.GetConfig("Armor_language", "Name_56"), 1, 100, 2, 54, "icon_Armor_shanguimao", LocalStringManager.GetConfig("Armor_language", "Desc_56"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_56"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 90, 1800, 1, 6, 1800, 5, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 35, isSpecial: false, 4, 36, 123, new List<int>(), 1, -1, 1796, 205, 485, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 30),
			new PropertyAndValue(5, 30)
		}, new HitOrAvoidShorts(0, 20, 0, 0), new OuterAndInnerShorts(40, 0), new OuterAndInnerShorts(0, 0), -1, new List<string> { "equip_hel/equip_hel", "equip_hel/equip_hel_311" }, 100));
		_dataArray.Add(new ArmorItem(57, LocalStringManager.GetConfig("Armor_language", "Name_57"), 1, 100, 3, 54, "icon_Armor_baguajin", LocalStringManager.GetConfig("Armor_language", "Desc_57"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_57"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 95, 4500, 2, 8, 3000, 6, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 30, isSpecial: false, 4, 36, 123, new List<int>(), 1, -1, 1796, 220, 520, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 35),
			new PropertyAndValue(5, 35)
		}, new HitOrAvoidShorts(0, 25, 0, 0), new OuterAndInnerShorts(50, 0), new OuterAndInnerShorts(0, 0), -1, new List<string> { "equip_hel/equip_hel", "equip_hel/equip_hel_315" }, 100));
		_dataArray.Add(new ArmorItem(58, LocalStringManager.GetConfig("Armor_language", "Name_58"), 1, 100, 4, 54, "icon_Armor_ruicaoheguan", LocalStringManager.GetConfig("Armor_language", "Desc_58"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_58"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 100, 9300, 3, 10, 4200, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 25, isSpecial: false, 4, 36, 123, new List<int>(), 1, -1, 1796, 240, 560, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 40),
			new PropertyAndValue(5, 40)
		}, new HitOrAvoidShorts(0, 25, 0, 0), new OuterAndInnerShorts(60, 0), new OuterAndInnerShorts(0, 0), -1, new List<string> { "equip_hel/equip_hel", "equip_hel/equip_hel_315" }, 100));
		_dataArray.Add(new ArmorItem(59, LocalStringManager.GetConfig("Armor_language", "Name_59"), 1, 100, 5, 54, "icon_Armor_youlongshu", LocalStringManager.GetConfig("Armor_language", "Desc_59"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_59"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 105, 16800, 4, 12, 5400, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 20, isSpecial: false, 4, 36, 123, new List<int>(), 1, -1, 1796, 255, 595, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 45),
			new PropertyAndValue(5, 45)
		}, new HitOrAvoidShorts(0, 25, 0, 0), new OuterAndInnerShorts(70, 0), new OuterAndInnerShorts(0, 0), -1, new List<string> { "equip_hel/equip_hel", "equip_hel/equip_hel_315" }, 100));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new ArmorItem(60, LocalStringManager.GetConfig("Armor_language", "Name_60"), 1, 100, 6, 54, "icon_Armor_chizhafengleiguan", LocalStringManager.GetConfig("Armor_language", "Desc_60"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_60"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 110, 27600, 5, 14, 7200, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 15, isSpecial: false, 4, 36, 123, new List<int>(), 1, -1, 1796, 280, 640, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 50),
			new PropertyAndValue(5, 50)
		}, new HitOrAvoidShorts(0, 30, 0, 0), new OuterAndInnerShorts(80, 0), new OuterAndInnerShorts(0, 0), -1, new List<string> { "equip_hel/equip_hel", "equip_hel/equip_hel_319" }, 100));
		_dataArray.Add(new ArmorItem(61, LocalStringManager.GetConfig("Armor_language", "Name_61"), 1, 100, 7, 54, "icon_Armor_chongtianguan", LocalStringManager.GetConfig("Armor_language", "Desc_61"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_61"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 115, 42300, 6, 16, 9000, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 10, isSpecial: false, 4, 36, 123, new List<int>(), 1, -1, 1796, 295, 675, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 55),
			new PropertyAndValue(5, 55)
		}, new HitOrAvoidShorts(0, 30, 0, 0), new OuterAndInnerShorts(90, 0), new OuterAndInnerShorts(0, 0), -1, new List<string> { "equip_hel/equip_hel", "equip_hel/equip_hel_319" }, 100));
		_dataArray.Add(new ArmorItem(62, LocalStringManager.GetConfig("Armor_language", "Name_62"), 1, 100, 8, 54, "icon_Armor_jinxiaguan", LocalStringManager.GetConfig("Armor_language", "Desc_62"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_62"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 120, 61500, 6, 18, 10800, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 5, isSpecial: false, 4, 36, 123, new List<int>(), 1, -1, 1796, 320, 720, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 60),
			new PropertyAndValue(5, 60)
		}, new HitOrAvoidShorts(0, 30, 0, 0), new OuterAndInnerShorts(100, 0), new OuterAndInnerShorts(0, 0), -1, new List<string> { "equip_hel/equip_hel", "equip_hel/equip_hel_319" }, 100));
		_dataArray.Add(new ArmorItem(63, LocalStringManager.GetConfig("Armor_language", "Name_63"), 1, 100, 0, 63, "icon_Armor_wurenbian", LocalStringManager.GetConfig("Armor_language", "Desc_63"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_63"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 100, 300, 0, 2, 600, 3, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 45, isSpecial: false, 4, 36, 124, new List<int>(), 1, -1, 1796, 180, 540, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 20),
			new PropertyAndValue(3, 20)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(20, 0), new OuterAndInnerShorts(10, 0), -1, new List<string> { "headwear/headwear", "headwear/headwear_331" }, 100));
		_dataArray.Add(new ArmorItem(64, LocalStringManager.GetConfig("Armor_language", "Name_64"), 1, 100, 1, 63, "icon_Armor_fenghuoqiaotou", LocalStringManager.GetConfig("Armor_language", "Desc_64"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_64"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 110, 600, 0, 4, 1200, 4, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 40, isSpecial: false, 4, 36, 124, new List<int>(), 1, -1, 1796, 200, 590, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 25),
			new PropertyAndValue(3, 25)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(25, 0), new OuterAndInnerShorts(10, 0), -1, new List<string> { "headwear/headwear", "headwear/headwear_331" }, 100));
		_dataArray.Add(new ArmorItem(65, LocalStringManager.GetConfig("Armor_language", "Name_65"), 1, 100, 2, 63, "icon_Armor_yuntouque", LocalStringManager.GetConfig("Armor_language", "Desc_65"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_65"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 120, 1800, 1, 6, 1800, 5, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 35, isSpecial: false, 4, 36, 124, new List<int>(), 1, -1, 1796, 225, 645, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 30),
			new PropertyAndValue(3, 30)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(30, 0), new OuterAndInnerShorts(15, 0), -1, new List<string> { "headwear/headwear", "headwear/headwear_331" }, 100));
		_dataArray.Add(new ArmorItem(66, LocalStringManager.GetConfig("Armor_language", "Name_66"), 1, 100, 3, 63, "icon_Armor_fuhuguan", LocalStringManager.GetConfig("Armor_language", "Desc_66"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_66"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 130, 4500, 2, 8, 3000, 6, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 30, isSpecial: false, 4, 36, 124, new List<int>(), 1, -1, 1796, 250, 700, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 35),
			new PropertyAndValue(3, 35)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(35, 0), new OuterAndInnerShorts(20, 0), -1, new List<string> { "headwear/headwear", "headwear/headwear_335" }, 100));
		_dataArray.Add(new ArmorItem(67, LocalStringManager.GetConfig("Armor_language", "Name_67"), 1, 100, 4, 63, "icon_Armor_chaotianmao", LocalStringManager.GetConfig("Armor_language", "Desc_67"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_67"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 140, 9300, 3, 10, 4200, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 25, isSpecial: false, 4, 36, 124, new List<int>(), 1, -1, 1796, 270, 750, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 40),
			new PropertyAndValue(3, 40)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(40, 0), new OuterAndInnerShorts(20, 0), -1, new List<string> { "headwear/headwear", "headwear/headwear_335" }, 100));
		_dataArray.Add(new ArmorItem(68, LocalStringManager.GetConfig("Armor_language", "Name_68"), 1, 100, 5, 63, "icon_Armor_jinluanziqueguan", LocalStringManager.GetConfig("Armor_language", "Desc_68"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_68"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 150, 16800, 4, 12, 5400, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 20, isSpecial: false, 4, 36, 124, new List<int>(), 1, -1, 1796, 300, 810, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 45),
			new PropertyAndValue(3, 45)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(45, 0), new OuterAndInnerShorts(25, 0), -1, new List<string> { "headwear/headwear", "headwear/headwear_335" }, 100));
		_dataArray.Add(new ArmorItem(69, LocalStringManager.GetConfig("Armor_language", "Name_69"), 1, 100, 6, 63, "icon_Armor_zhuangjinjiulongguan", LocalStringManager.GetConfig("Armor_language", "Desc_69"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_69"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 160, 27600, 5, 14, 7200, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 15, isSpecial: false, 4, 36, 124, new List<int>(), 1, -1, 1796, 325, 865, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 50),
			new PropertyAndValue(3, 50)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(50, 0), new OuterAndInnerShorts(30, 0), -1, new List<string> { "headwear/headwear", "headwear/headwear_339" }, 100));
		_dataArray.Add(new ArmorItem(70, LocalStringManager.GetConfig("Armor_language", "Name_70"), 1, 100, 7, 63, "icon_Armor_jiuxiaojin", LocalStringManager.GetConfig("Armor_language", "Desc_70"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_70"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 170, 42300, 6, 16, 9000, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 10, isSpecial: false, 4, 36, 124, new List<int>(), 1, -1, 1796, 350, 920, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 55),
			new PropertyAndValue(3, 55)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(55, 0), new OuterAndInnerShorts(30, 0), -1, new List<string> { "headwear/headwear", "headwear/headwear_339" }, 100));
		_dataArray.Add(new ArmorItem(71, LocalStringManager.GetConfig("Armor_language", "Name_71"), 1, 100, 8, 63, "icon_Armor_xuanyuanmian", LocalStringManager.GetConfig("Armor_language", "Desc_71"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_71"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 180, 61500, 6, 18, 10800, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 5, isSpecial: false, 4, 36, 124, new List<int>(), 1, -1, 1796, 380, 980, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 60),
			new PropertyAndValue(3, 60)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(60, 0), new OuterAndInnerShorts(35, 0), -1, new List<string> { "headwear/headwear", "headwear/headwear_339" }, 100));
		_dataArray.Add(new ArmorItem(72, LocalStringManager.GetConfig("Armor_language", "Name_72"), 1, 100, 0, 72, "icon_Armor_huangze", LocalStringManager.GetConfig("Armor_language", "Desc_72"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_72"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 80, 300, 0, 2, 600, 3, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 45, isSpecial: false, 4, 36, 129, new List<int>(), 1, -1, 1796, 170, 410, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 20),
			new PropertyAndValue(4, 20)
		}, new HitOrAvoidShorts(20, 0, 0, 0), new OuterAndInnerShorts(0, 20), new OuterAndInnerShorts(0, 0), -1, new List<string> { "headwear/headwear", "headwear/headwear_311" }, 100));
		_dataArray.Add(new ArmorItem(73, LocalStringManager.GetConfig("Armor_language", "Name_73"), 1, 100, 1, 72, "icon_Armor_wulaoguan", LocalStringManager.GetConfig("Armor_language", "Desc_73"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_73"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 80, 600, 0, 4, 1200, 4, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 40, isSpecial: false, 4, 36, 129, new List<int>(), 1, -1, 1796, 180, 440, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 25),
			new PropertyAndValue(4, 25)
		}, new HitOrAvoidShorts(20, 0, 0, 0), new OuterAndInnerShorts(0, 30), new OuterAndInnerShorts(0, 0), -1, new List<string> { "headwear/headwear", "headwear/headwear_311" }, 100));
		_dataArray.Add(new ArmorItem(74, LocalStringManager.GetConfig("Armor_language", "Name_74"), 1, 100, 2, 72, "icon_Armor_zhuyuguan", LocalStringManager.GetConfig("Armor_language", "Desc_74"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_74"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 80, 1800, 1, 6, 1800, 5, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 35, isSpecial: false, 4, 36, 129, new List<int>(), 1, -1, 1796, 195, 475, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 30),
			new PropertyAndValue(4, 30)
		}, new HitOrAvoidShorts(20, 0, 0, 0), new OuterAndInnerShorts(0, 40), new OuterAndInnerShorts(0, 0), -1, new List<string> { "headwear/headwear", "headwear/headwear_311" }, 100));
		_dataArray.Add(new ArmorItem(75, LocalStringManager.GetConfig("Armor_language", "Name_75"), 1, 100, 3, 72, "icon_Armor_jiuliangjin", LocalStringManager.GetConfig("Armor_language", "Desc_75"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_75"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 80, 4500, 2, 8, 3000, 6, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 30, isSpecial: false, 4, 36, 129, new List<int>(), 1, -1, 1796, 210, 510, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 35),
			new PropertyAndValue(4, 35)
		}, new HitOrAvoidShorts(25, 0, 0, 0), new OuterAndInnerShorts(0, 50), new OuterAndInnerShorts(0, 0), -1, new List<string> { "headwear/headwear", "headwear/headwear_315" }, 100));
		_dataArray.Add(new ArmorItem(76, LocalStringManager.GetConfig("Armor_language", "Name_76"), 1, 100, 4, 72, "icon_Armor_nanhuazhenshiguan", LocalStringManager.GetConfig("Armor_language", "Desc_76"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_76"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 80, 9300, 3, 10, 4200, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 25, isSpecial: false, 4, 36, 129, new List<int>(), 1, -1, 1796, 225, 545, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 40),
			new PropertyAndValue(4, 40)
		}, new HitOrAvoidShorts(25, 0, 0, 0), new OuterAndInnerShorts(0, 60), new OuterAndInnerShorts(0, 0), -1, new List<string> { "headwear/headwear", "headwear/headwear_315" }, 100));
		_dataArray.Add(new ArmorItem(77, LocalStringManager.GetConfig("Armor_language", "Name_77"), 1, 100, 5, 72, "icon_Armor_muxueguan", LocalStringManager.GetConfig("Armor_language", "Desc_77"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_77"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 80, 16800, 4, 12, 5400, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 20, isSpecial: false, 4, 36, 129, new List<int>(), 1, -1, 1796, 240, 580, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 45),
			new PropertyAndValue(4, 45)
		}, new HitOrAvoidShorts(25, 0, 0, 0), new OuterAndInnerShorts(0, 70), new OuterAndInnerShorts(0, 0), -1, new List<string> { "headwear/headwear", "headwear/headwear_315" }, 100));
		_dataArray.Add(new ArmorItem(78, LocalStringManager.GetConfig("Armor_language", "Name_78"), 1, 100, 6, 72, "icon_Armor_tiansheguan", LocalStringManager.GetConfig("Armor_language", "Desc_78"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_78"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 80, 27600, 5, 14, 7200, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 15, isSpecial: false, 4, 36, 129, new List<int>(), 1, -1, 1796, 250, 610, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 50),
			new PropertyAndValue(4, 50)
		}, new HitOrAvoidShorts(30, 0, 0, 0), new OuterAndInnerShorts(0, 80), new OuterAndInnerShorts(0, 0), -1, new List<string> { "headwear/headwear", "headwear/headwear_319" }, 100));
		_dataArray.Add(new ArmorItem(79, LocalStringManager.GetConfig("Armor_language", "Name_79"), 1, 100, 7, 72, "icon_Armor_taijizhenyuanguan", LocalStringManager.GetConfig("Armor_language", "Desc_79"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_79"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 80, 42300, 6, 16, 9000, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 10, isSpecial: false, 4, 36, 129, new List<int>(), 1, -1, 1796, 265, 645, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 55),
			new PropertyAndValue(4, 55)
		}, new HitOrAvoidShorts(30, 0, 0, 0), new OuterAndInnerShorts(0, 90), new OuterAndInnerShorts(0, 0), -1, new List<string> { "headwear/headwear", "headwear/headwear_319" }, 100));
		_dataArray.Add(new ArmorItem(80, LocalStringManager.GetConfig("Armor_language", "Name_80"), 1, 100, 8, 72, "icon_Armor_hundunxuanjin", LocalStringManager.GetConfig("Armor_language", "Desc_80"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_80"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 80, 61500, 6, 18, 10800, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 5, isSpecial: false, 4, 36, 129, new List<int>(), 1, -1, 1796, 280, 680, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 60),
			new PropertyAndValue(4, 60)
		}, new HitOrAvoidShorts(30, 0, 0, 0), new OuterAndInnerShorts(0, 100), new OuterAndInnerShorts(0, 0), -1, new List<string> { "headwear/headwear", "headwear/headwear_319" }, 100));
		_dataArray.Add(new ArmorItem(81, LocalStringManager.GetConfig("Armor_language", "Name_81"), 1, 100, 0, 81, "icon_Armor_malongguan", LocalStringManager.GetConfig("Armor_language", "Desc_81"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_81"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 60, 300, 0, 2, 600, 3, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 45, isSpecial: false, 4, 36, 130, new List<int>(), 1, -1, 1796, 155, 395, new List<PropertyAndValue>
		{
			new PropertyAndValue(4, 20),
			new PropertyAndValue(5, 20)
		}, new HitOrAvoidShorts(0, 20, 0, 0), new OuterAndInnerShorts(0, 20), new OuterAndInnerShorts(0, 0), -1, new List<string> { "headwear/headwear", "headwear/headwear_351" }, 100));
		_dataArray.Add(new ArmorItem(82, LocalStringManager.GetConfig("Armor_language", "Name_82"), 1, 100, 1, 81, "icon_Armor_sifangjin", LocalStringManager.GetConfig("Armor_language", "Desc_82"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_82"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 60, 600, 0, 4, 1200, 4, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 40, isSpecial: false, 4, 36, 130, new List<int>(), 1, -1, 1796, 170, 430, new List<PropertyAndValue>
		{
			new PropertyAndValue(4, 25),
			new PropertyAndValue(5, 25)
		}, new HitOrAvoidShorts(0, 20, 0, 0), new OuterAndInnerShorts(0, 30), new OuterAndInnerShorts(0, 0), -1, new List<string> { "headwear/headwear", "headwear/headwear_351" }, 100));
		_dataArray.Add(new ArmorItem(83, LocalStringManager.GetConfig("Armor_language", "Name_83"), 1, 100, 2, 81, "icon_Armor_guiwenguan", LocalStringManager.GetConfig("Armor_language", "Desc_83"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_83"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 60, 1800, 1, 6, 1800, 5, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 35, isSpecial: false, 4, 36, 130, new List<int>(), 1, -1, 1796, 180, 460, new List<PropertyAndValue>
		{
			new PropertyAndValue(4, 30),
			new PropertyAndValue(5, 30)
		}, new HitOrAvoidShorts(0, 20, 0, 0), new OuterAndInnerShorts(0, 40), new OuterAndInnerShorts(0, 0), -1, new List<string> { "headwear/headwear", "headwear/headwear_351" }, 100));
		_dataArray.Add(new ArmorItem(84, LocalStringManager.GetConfig("Armor_language", "Name_84"), 1, 100, 3, 81, "icon_Armor_pilumao", LocalStringManager.GetConfig("Armor_language", "Desc_84"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_84"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 60, 4500, 2, 8, 3000, 6, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 30, isSpecial: false, 4, 36, 130, new List<int>(), 1, -1, 1796, 195, 495, new List<PropertyAndValue>
		{
			new PropertyAndValue(4, 35),
			new PropertyAndValue(5, 35)
		}, new HitOrAvoidShorts(0, 25, 0, 0), new OuterAndInnerShorts(0, 50), new OuterAndInnerShorts(0, 0), -1, new List<string> { "headwear/headwear", "headwear/headwear_355" }, 100));
		_dataArray.Add(new ArmorItem(85, LocalStringManager.GetConfig("Armor_language", "Name_85"), 1, 100, 4, 81, "icon_Armor_jinruifurong", LocalStringManager.GetConfig("Armor_language", "Desc_85"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_85"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 60, 9300, 3, 10, 4200, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 25, isSpecial: false, 4, 36, 130, new List<int>(), 1, -1, 1796, 210, 530, new List<PropertyAndValue>
		{
			new PropertyAndValue(4, 40),
			new PropertyAndValue(5, 40)
		}, new HitOrAvoidShorts(0, 25, 0, 0), new OuterAndInnerShorts(0, 60), new OuterAndInnerShorts(0, 0), -1, new List<string> { "headwear/headwear", "headwear/headwear_355" }, 100));
		_dataArray.Add(new ArmorItem(86, LocalStringManager.GetConfig("Armor_language", "Name_86"), 1, 100, 5, 81, "icon_Armor_shibanjin", LocalStringManager.GetConfig("Armor_language", "Desc_86"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_86"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 60, 16800, 4, 12, 5400, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 20, isSpecial: false, 4, 36, 130, new List<int>(), 1, -1, 1796, 220, 560, new List<PropertyAndValue>
		{
			new PropertyAndValue(4, 45),
			new PropertyAndValue(5, 45)
		}, new HitOrAvoidShorts(0, 25, 0, 0), new OuterAndInnerShorts(0, 70), new OuterAndInnerShorts(0, 0), -1, new List<string> { "headwear/headwear", "headwear/headwear_355" }, 100));
		_dataArray.Add(new ArmorItem(87, LocalStringManager.GetConfig("Armor_language", "Name_87"), 1, 100, 6, 81, "icon_Armor_liuyabaoxiangguan", LocalStringManager.GetConfig("Armor_language", "Desc_87"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_87"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 60, 27600, 5, 14, 7200, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 15, isSpecial: false, 4, 36, 130, new List<int>(), 1, -1, 1796, 235, 595, new List<PropertyAndValue>
		{
			new PropertyAndValue(4, 50),
			new PropertyAndValue(5, 50)
		}, new HitOrAvoidShorts(0, 30, 0, 0), new OuterAndInnerShorts(0, 80), new OuterAndInnerShorts(0, 0), -1, new List<string> { "headwear/headwear", "headwear/headwear_359" }, 100));
		_dataArray.Add(new ArmorItem(88, LocalStringManager.GetConfig("Armor_language", "Name_88"), 1, 100, 7, 81, "icon_Armor_huohuanbingluo", LocalStringManager.GetConfig("Armor_language", "Desc_88"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_88"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 60, 42300, 6, 16, 9000, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 10, isSpecial: false, 4, 36, 130, new List<int>(), 1, -1, 1796, 245, 625, new List<PropertyAndValue>
		{
			new PropertyAndValue(4, 55),
			new PropertyAndValue(5, 55)
		}, new HitOrAvoidShorts(0, 30, 0, 0), new OuterAndInnerShorts(0, 90), new OuterAndInnerShorts(0, 0), -1, new List<string> { "headwear/headwear", "headwear/headwear_359" }, 100));
		_dataArray.Add(new ArmorItem(89, LocalStringManager.GetConfig("Armor_language", "Name_89"), 1, 100, 8, 81, "icon_Armor_tiancanshu", LocalStringManager.GetConfig("Armor_language", "Desc_89"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_89"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 60, 61500, 6, 18, 10800, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 5, isSpecial: false, 4, 36, 130, new List<int>(), 1, -1, 1796, 260, 660, new List<PropertyAndValue>
		{
			new PropertyAndValue(4, 60),
			new PropertyAndValue(5, 60)
		}, new HitOrAvoidShorts(0, 30, 0, 0), new OuterAndInnerShorts(0, 100), new OuterAndInnerShorts(0, 0), -1, new List<string> { "headwear/headwear", "headwear/headwear_359" }, 100));
		_dataArray.Add(new ArmorItem(90, LocalStringManager.GetConfig("Armor_language", "Name_90"), 1, 100, 0, 90, "icon_Armor_shushengjin", LocalStringManager.GetConfig("Armor_language", "Desc_90"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_90"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 80, 300, 0, 2, 600, 3, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 45, isSpecial: false, 4, 36, 131, new List<int>(), 1, -1, 1796, 170, 530, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 20),
			new PropertyAndValue(4, 20)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 20), new OuterAndInnerShorts(0, 10), -1, new List<string> { "hair/hair_hat", "hair/hair_321" }, 100));
		_dataArray.Add(new ArmorItem(91, LocalStringManager.GetConfig("Armor_language", "Name_91"), 1, 100, 1, 90, "icon_Armor_jinxianguan", LocalStringManager.GetConfig("Armor_language", "Desc_91"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_91"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 90, 600, 0, 4, 1200, 4, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 40, isSpecial: false, 4, 36, 131, new List<int>(), 1, -1, 1796, 190, 580, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 25),
			new PropertyAndValue(4, 25)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 25), new OuterAndInnerShorts(0, 10), -1, new List<string> { "hair/hair_hat", "hair/hair_321" }, 100));
		_dataArray.Add(new ArmorItem(92, LocalStringManager.GetConfig("Armor_language", "Name_92"), 1, 100, 2, 90, "icon_Armor_xiangsijin", LocalStringManager.GetConfig("Armor_language", "Desc_92"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_92"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 100, 1800, 1, 6, 1800, 5, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 35, isSpecial: false, 4, 36, 131, new List<int>(), 1, -1, 1796, 210, 630, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 30),
			new PropertyAndValue(4, 30)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 30), new OuterAndInnerShorts(0, 15), -1, new List<string> { "hair/hair_hat", "hair/hair_321" }, 100));
		_dataArray.Add(new ArmorItem(93, LocalStringManager.GetConfig("Armor_language", "Name_93"), 1, 100, 3, 90, "icon_Armor_sishibaihuashu", LocalStringManager.GetConfig("Armor_language", "Desc_93"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_93"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 110, 4500, 2, 8, 3000, 6, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 30, isSpecial: false, 4, 36, 131, new List<int>(), 1, -1, 1796, 235, 685, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 35),
			new PropertyAndValue(4, 35)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 35), new OuterAndInnerShorts(0, 20), -1, new List<string> { "hair/hair_hat", "hair/hair_325" }, 100));
		_dataArray.Add(new ArmorItem(94, LocalStringManager.GetConfig("Armor_language", "Name_94"), 1, 100, 4, 90, "icon_Armor_zhugeguanjin", LocalStringManager.GetConfig("Armor_language", "Desc_94"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_94"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 120, 9300, 3, 10, 4200, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 25, isSpecial: false, 4, 36, 131, new List<int>(), 1, -1, 1796, 255, 735, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 40),
			new PropertyAndValue(4, 40)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 40), new OuterAndInnerShorts(0, 20), -1, new List<string> { "hair/hair_hat", "hair/hair_325" }, 100));
		_dataArray.Add(new ArmorItem(95, LocalStringManager.GetConfig("Armor_language", "Name_95"), 1, 100, 5, 90, "icon_Armor_mudanjinluo", LocalStringManager.GetConfig("Armor_language", "Desc_95"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_95"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 130, 16800, 4, 12, 5400, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 20, isSpecial: false, 4, 36, 131, new List<int>(), 1, -1, 1796, 280, 790, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 45),
			new PropertyAndValue(4, 45)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 45), new OuterAndInnerShorts(0, 25), -1, new List<string> { "hair/hair_hat", "hair/hair_325" }, 100));
		_dataArray.Add(new ArmorItem(96, LocalStringManager.GetConfig("Armor_language", "Name_96"), 1, 100, 6, 90, "icon_Armor_xuantianguan", LocalStringManager.GetConfig("Armor_language", "Desc_96"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_96"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 140, 27600, 5, 14, 7200, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 15, isSpecial: false, 4, 36, 131, new List<int>(), 1, -1, 1796, 305, 845, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 50),
			new PropertyAndValue(4, 50)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 50), new OuterAndInnerShorts(0, 30), -1, new List<string> { "hair/hair_hat", "hair/hair_329" }, 100));
		_dataArray.Add(new ArmorItem(97, LocalStringManager.GetConfig("Armor_language", "Name_97"), 1, 100, 7, 90, "icon_Armor_jiusexueying", LocalStringManager.GetConfig("Armor_language", "Desc_97"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_97"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 150, 42300, 6, 16, 9000, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 10, isSpecial: false, 4, 36, 131, new List<int>(), 1, -1, 1796, 335, 905, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 55),
			new PropertyAndValue(4, 55)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 55), new OuterAndInnerShorts(0, 30), -1, new List<string> { "hair/hair_hat", "hair/hair_329" }, 100));
		_dataArray.Add(new ArmorItem(98, LocalStringManager.GetConfig("Armor_language", "Name_98"), 1, 100, 8, 90, "icon_Armor_mingmingjin", LocalStringManager.GetConfig("Armor_language", "Desc_98"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_98"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 160, 61500, 6, 18, 10800, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 5, isSpecial: false, 4, 36, 131, new List<int>(), 1, -1, 1796, 360, 960, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 60),
			new PropertyAndValue(4, 60)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 60), new OuterAndInnerShorts(0, 35), -1, new List<string> { "hair/hair_hat", "hair/hair_329" }, 100));
		_dataArray.Add(new ArmorItem(99, LocalStringManager.GetConfig("Armor_language", "Name_99"), 1, 100, 0, 99, "icon_Armor_wansujin", LocalStringManager.GetConfig("Armor_language", "Desc_99"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_99"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 40, 300, 0, 2, 600, 3, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 45, isSpecial: false, 4, 36, 128, new List<int>(), 1, -1, 1796, 145, 385, new List<PropertyAndValue>
		{
			new PropertyAndValue(1, 20),
			new PropertyAndValue(4, 20)
		}, new HitOrAvoidShorts(0, 0, 20, 0), new OuterAndInnerShorts(0, 20), new OuterAndInnerShorts(0, 0), -1, new List<string> { "hair/hair_hat", "hair/hair_331" }, 100));
		_dataArray.Add(new ArmorItem(100, LocalStringManager.GetConfig("Armor_language", "Name_100"), 1, 100, 1, 99, "icon_Armor_badawenjin", LocalStringManager.GetConfig("Armor_language", "Desc_100"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_100"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 40, 600, 0, 4, 1200, 4, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 40, isSpecial: false, 4, 36, 128, new List<int>(), 1, -1, 1796, 155, 415, new List<PropertyAndValue>
		{
			new PropertyAndValue(1, 25),
			new PropertyAndValue(4, 25)
		}, new HitOrAvoidShorts(0, 0, 20, 0), new OuterAndInnerShorts(0, 30), new OuterAndInnerShorts(0, 0), -1, new List<string> { "hair/hair_hat", "hair/hair_331" }, 100));
		_dataArray.Add(new ArmorItem(101, LocalStringManager.GetConfig("Armor_language", "Name_101"), 1, 100, 2, 99, "icon_Armor_xingwenshu", LocalStringManager.GetConfig("Armor_language", "Desc_101"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_101"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 40, 1800, 1, 6, 1800, 5, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 35, isSpecial: false, 4, 36, 128, new List<int>(), 1, -1, 1796, 170, 450, new List<PropertyAndValue>
		{
			new PropertyAndValue(1, 30),
			new PropertyAndValue(4, 30)
		}, new HitOrAvoidShorts(0, 0, 20, 0), new OuterAndInnerShorts(0, 40), new OuterAndInnerShorts(0, 0), -1, new List<string> { "hair/hair_hat", "hair/hair_331" }, 100));
		_dataArray.Add(new ArmorItem(102, LocalStringManager.GetConfig("Armor_language", "Name_102"), 1, 100, 3, 99, "icon_Armor_baxianguan", LocalStringManager.GetConfig("Armor_language", "Desc_102"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_102"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 40, 4500, 2, 8, 3000, 6, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 30, isSpecial: false, 4, 36, 128, new List<int>(), 1, -1, 1796, 180, 480, new List<PropertyAndValue>
		{
			new PropertyAndValue(1, 35),
			new PropertyAndValue(4, 35)
		}, new HitOrAvoidShorts(0, 0, 25, 0), new OuterAndInnerShorts(0, 50), new OuterAndInnerShorts(0, 0), -1, new List<string> { "hair/hair_hat", "hair/hair_335" }, 100));
		_dataArray.Add(new ArmorItem(103, LocalStringManager.GetConfig("Armor_language", "Name_103"), 1, 100, 4, 99, "icon_Armor_haoranjin", LocalStringManager.GetConfig("Armor_language", "Desc_103"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_103"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 40, 9300, 3, 10, 4200, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 25, isSpecial: false, 4, 36, 128, new List<int>(), 1, -1, 1796, 190, 510, new List<PropertyAndValue>
		{
			new PropertyAndValue(1, 40),
			new PropertyAndValue(4, 40)
		}, new HitOrAvoidShorts(0, 0, 25, 0), new OuterAndInnerShorts(0, 60), new OuterAndInnerShorts(0, 0), -1, new List<string> { "hair/hair_hat", "hair/hair_335" }, 100));
		_dataArray.Add(new ArmorItem(104, LocalStringManager.GetConfig("Armor_language", "Name_104"), 1, 100, 5, 99, "icon_Armor_qingshuangguan", LocalStringManager.GetConfig("Armor_language", "Desc_104"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_104"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 40, 16800, 4, 12, 5400, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 20, isSpecial: false, 4, 36, 128, new List<int>(), 1, -1, 1796, 205, 545, new List<PropertyAndValue>
		{
			new PropertyAndValue(1, 45),
			new PropertyAndValue(4, 45)
		}, new HitOrAvoidShorts(0, 0, 25, 0), new OuterAndInnerShorts(0, 70), new OuterAndInnerShorts(0, 0), -1, new List<string> { "hair/hair_hat", "hair/hair_335" }, 100));
		_dataArray.Add(new ArmorItem(105, LocalStringManager.GetConfig("Armor_language", "Name_105"), 1, 100, 6, 99, "icon_Armor_qibaoyinhezhi", LocalStringManager.GetConfig("Armor_language", "Desc_105"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_105"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 40, 27600, 5, 14, 7200, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 15, isSpecial: false, 4, 36, 128, new List<int>(), 1, -1, 1796, 215, 575, new List<PropertyAndValue>
		{
			new PropertyAndValue(1, 50),
			new PropertyAndValue(4, 50)
		}, new HitOrAvoidShorts(0, 0, 30, 0), new OuterAndInnerShorts(0, 80), new OuterAndInnerShorts(0, 0), -1, new List<string> { "hair/hair_hat", "hair/hair_339" }, 100));
		_dataArray.Add(new ArmorItem(106, LocalStringManager.GetConfig("Armor_language", "Name_106"), 1, 100, 7, 99, "icon_Armor_longxubaoshouguan", LocalStringManager.GetConfig("Armor_language", "Desc_106"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_106"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 40, 42300, 6, 16, 9000, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 10, isSpecial: false, 4, 36, 128, new List<int>(), 1, -1, 1796, 230, 610, new List<PropertyAndValue>
		{
			new PropertyAndValue(1, 55),
			new PropertyAndValue(4, 55)
		}, new HitOrAvoidShorts(0, 0, 30, 0), new OuterAndInnerShorts(0, 90), new OuterAndInnerShorts(0, 0), -1, new List<string> { "hair/hair_hat", "hair/hair_339" }, 100));
		_dataArray.Add(new ArmorItem(107, LocalStringManager.GetConfig("Armor_language", "Name_107"), 1, 100, 8, 99, "icon_Armor_taishicangshu", LocalStringManager.GetConfig("Armor_language", "Desc_107"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_107"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 40, 61500, 6, 18, 10800, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 5, isSpecial: false, 4, 36, 128, new List<int>(), 1, -1, 1796, 240, 640, new List<PropertyAndValue>
		{
			new PropertyAndValue(1, 60),
			new PropertyAndValue(4, 60)
		}, new HitOrAvoidShorts(0, 0, 30, 0), new OuterAndInnerShorts(0, 100), new OuterAndInnerShorts(0, 0), -1, new List<string> { "hair/hair_hat", "hair/hair_339" }, 100));
		_dataArray.Add(new ArmorItem(108, LocalStringManager.GetConfig("Armor_language", "Name_108"), 1, 100, 0, 108, "icon_Armor_heishizan", LocalStringManager.GetConfig("Armor_language", "Desc_108"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_108"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 80, 140, 300, 0, 2, 600, 3, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 45, isSpecial: false, 3, 36, 120, new List<int>(), 1, -1, 1795, 480, 480, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 30),
			new PropertyAndValue(3, 30)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(40, 5), new OuterAndInnerShorts(0, 0), -1, new List<string> { "headwear/headwear", "headwear/headwear_431" }, 100));
		_dataArray.Add(new ArmorItem(109, LocalStringManager.GetConfig("Armor_language", "Name_109"), 1, 100, 1, 108, "icon_Armor_yinghongguan", LocalStringManager.GetConfig("Armor_language", "Desc_109"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_109"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 80, 175, 600, 0, 4, 1200, 4, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 40, isSpecial: false, 3, 36, 120, new List<int>(), 1, -1, 1795, 535, 535, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 35),
			new PropertyAndValue(3, 35)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(50, 10), new OuterAndInnerShorts(0, 0), -1, new List<string> { "headwear/headwear", "headwear/headwear_431" }, 100));
		_dataArray.Add(new ArmorItem(110, LocalStringManager.GetConfig("Armor_language", "Name_110"), 1, 100, 2, 108, "icon_Armor_zhujingsheguan", LocalStringManager.GetConfig("Armor_language", "Desc_110"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_110"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 80, 210, 1800, 1, 6, 1800, 5, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 35, isSpecial: false, 3, 36, 120, new List<int>(), 1, -1, 1795, 595, 595, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 40),
			new PropertyAndValue(3, 40)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(60, 15), new OuterAndInnerShorts(10, 0), -1, new List<string> { "headwear/headwear", "headwear/headwear_431" }, 100));
		_dataArray.Add(new ArmorItem(111, LocalStringManager.GetConfig("Armor_language", "Name_111"), 1, 100, 3, 108, "icon_Armor_tongxiazan", LocalStringManager.GetConfig("Armor_language", "Desc_111"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_111"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 80, 245, 4500, 2, 8, 3000, 6, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 30, isSpecial: false, 3, 36, 120, new List<int>(), 1, -1, 1795, 655, 655, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 45),
			new PropertyAndValue(3, 45)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(70, 20), new OuterAndInnerShorts(10, 0), -1, new List<string> { "headwear/headwear", "headwear/headwear_435" }, 100));
		_dataArray.Add(new ArmorItem(112, LocalStringManager.GetConfig("Armor_language", "Name_112"), 1, 100, 4, 108, "icon_Armor_yeguangqixingguan", LocalStringManager.GetConfig("Armor_language", "Desc_112"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_112"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 80, 280, 9300, 3, 10, 4200, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 25, isSpecial: false, 3, 36, 120, new List<int>(), 1, -1, 1795, 720, 720, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 50),
			new PropertyAndValue(3, 50)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(80, 25), new OuterAndInnerShorts(15, 0), -1, new List<string> { "headwear/headwear", "headwear/headwear_435" }, 100));
		_dataArray.Add(new ArmorItem(113, LocalStringManager.GetConfig("Armor_language", "Name_113"), 1, 100, 5, 108, "icon_Armor_tianwangbaoguan", LocalStringManager.GetConfig("Armor_language", "Desc_113"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_113"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 80, 315, 16800, 4, 12, 5400, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 20, isSpecial: false, 3, 36, 120, new List<int>(), 1, -1, 1795, 780, 780, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 55),
			new PropertyAndValue(3, 55)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(90, 30), new OuterAndInnerShorts(20, 10), -1, new List<string> { "headwear/headwear", "headwear/headwear_435" }, 100));
		_dataArray.Add(new ArmorItem(114, LocalStringManager.GetConfig("Armor_language", "Name_114"), 1, 100, 6, 108, "icon_Armor_chihuzan", LocalStringManager.GetConfig("Armor_language", "Desc_114"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_114"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 80, 350, 27600, 5, 14, 7200, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 15, isSpecial: false, 3, 36, 120, new List<int>(), 1, -1, 1795, 855, 855, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 60),
			new PropertyAndValue(3, 60)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(100, 35), new OuterAndInnerShorts(20, 10), -1, new List<string> { "headwear/headwear", "headwear/headwear_439" }, 100));
		_dataArray.Add(new ArmorItem(115, LocalStringManager.GetConfig("Armor_language", "Name_115"), 1, 100, 7, 108, "icon_Armor_biyanxianyan", LocalStringManager.GetConfig("Armor_language", "Desc_115"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_115"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 80, 385, 42300, 6, 16, 9000, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 10, isSpecial: false, 3, 36, 120, new List<int>(), 1, -1, 1795, 920, 920, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 65),
			new PropertyAndValue(3, 65)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(110, 40), new OuterAndInnerShorts(25, 15), -1, new List<string> { "headwear/headwear", "headwear/headwear_439" }, 100));
		_dataArray.Add(new ArmorItem(116, LocalStringManager.GetConfig("Armor_language", "Name_116"), 1, 100, 8, 108, "icon_Armor_chiyoujiao", LocalStringManager.GetConfig("Armor_language", "Desc_116"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_116"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 80, 420, 61500, 6, 18, 10800, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 5, isSpecial: false, 3, 36, 120, new List<int>(), 1, -1, 1795, 1000, 1000, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 70),
			new PropertyAndValue(3, 70)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(120, 45), new OuterAndInnerShorts(30, 20), -1, new List<string> { "headwear/headwear", "headwear/headwear_439" }, 100));
		_dataArray.Add(new ArmorItem(117, LocalStringManager.GetConfig("Armor_language", "Name_117"), 1, 100, 0, 117, "icon_Armor_jingyuzan", LocalStringManager.GetConfig("Armor_language", "Desc_117"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_117"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 80, 80, 300, 0, 2, 600, 3, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 45, isSpecial: false, 3, 36, 127, new List<int>(), 1, -1, 1795, 515, 395, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 30),
			new PropertyAndValue(4, 30)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(5, 40), new OuterAndInnerShorts(0, 0), -1, new List<string> { "headwear/headwear", "headwear/headwear_411" }, 100));
		_dataArray.Add(new ArmorItem(118, LocalStringManager.GetConfig("Armor_language", "Name_118"), 1, 100, 1, 117, "icon_Armor_zhujiguan", LocalStringManager.GetConfig("Armor_language", "Desc_118"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_118"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 80, 110, 600, 0, 4, 1200, 4, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 40, isSpecial: false, 3, 36, 127, new List<int>(), 1, -1, 1795, 570, 440, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 35),
			new PropertyAndValue(4, 35)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(10, 50), new OuterAndInnerShorts(0, 0), -1, new List<string> { "headwear/headwear", "headwear/headwear_411" }, 100));
		_dataArray.Add(new ArmorItem(119, LocalStringManager.GetConfig("Armor_language", "Name_119"), 1, 100, 2, 117, "icon_Armor_yufeicaidian", LocalStringManager.GetConfig("Armor_language", "Desc_119"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_119"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 80, 140, 1800, 1, 6, 1800, 5, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 35, isSpecial: false, 3, 36, 127, new List<int>(), 1, -1, 1795, 630, 490, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 40),
			new PropertyAndValue(4, 40)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(15, 60), new OuterAndInnerShorts(0, 10), -1, new List<string> { "headwear/headwear", "headwear/headwear_411" }, 100));
	}

	private void CreateItems2()
	{
		_dataArray.Add(new ArmorItem(120, LocalStringManager.GetConfig("Armor_language", "Name_120"), 1, 100, 3, 117, "icon_Armor_liushuangguan", LocalStringManager.GetConfig("Armor_language", "Desc_120"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_120"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 80, 165, 4500, 2, 8, 3000, 6, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 30, isSpecial: false, 3, 36, 127, new List<int>(), 1, -1, 1795, 690, 540, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 45),
			new PropertyAndValue(4, 45)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(20, 70), new OuterAndInnerShorts(0, 10), -1, new List<string> { "headwear/headwear", "headwear/headwear_415" }, 100));
		_dataArray.Add(new ArmorItem(121, LocalStringManager.GetConfig("Armor_language", "Name_121"), 1, 100, 4, 117, "icon_Armor_youmangshuo", LocalStringManager.GetConfig("Armor_language", "Desc_121"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_121"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 80, 195, 9300, 3, 10, 4200, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 25, isSpecial: false, 3, 36, 127, new List<int>(), 1, -1, 1795, 750, 590, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 50),
			new PropertyAndValue(4, 50)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(25, 80), new OuterAndInnerShorts(0, 15), -1, new List<string> { "headwear/headwear", "headwear/headwear_415" }, 100));
		_dataArray.Add(new ArmorItem(122, LocalStringManager.GetConfig("Armor_language", "Name_122"), 1, 100, 5, 117, "icon_Armor_binglidiancui", LocalStringManager.GetConfig("Armor_language", "Desc_122"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_122"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 80, 220, 16800, 4, 12, 5400, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 20, isSpecial: false, 3, 36, 127, new List<int>(), 1, -1, 1795, 815, 645, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 55),
			new PropertyAndValue(4, 55)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(30, 90), new OuterAndInnerShorts(10, 20), -1, new List<string> { "headwear/headwear", "headwear/headwear_415" }, 100));
		_dataArray.Add(new ArmorItem(123, LocalStringManager.GetConfig("Armor_language", "Name_123"), 1, 100, 6, 117, "icon_Armor_jiuhuazhuxinzan", LocalStringManager.GetConfig("Armor_language", "Desc_123"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_123"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 80, 250, 27600, 5, 14, 7200, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 15, isSpecial: false, 3, 36, 127, new List<int>(), 1, -1, 1795, 880, 700, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 60),
			new PropertyAndValue(4, 60)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(35, 100), new OuterAndInnerShorts(10, 20), -1, new List<string> { "headwear/headwear", "headwear/headwear_419" }, 100));
		_dataArray.Add(new ArmorItem(124, LocalStringManager.GetConfig("Armor_language", "Name_124"), 1, 100, 7, 117, "icon_Armor_lirenzan", LocalStringManager.GetConfig("Armor_language", "Desc_124"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_124"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 80, 280, 42300, 6, 16, 9000, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 10, isSpecial: false, 3, 36, 127, new List<int>(), 1, -1, 1795, 950, 760, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 65),
			new PropertyAndValue(4, 65)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(40, 110), new OuterAndInnerShorts(15, 25), -1, new List<string> { "headwear/headwear", "headwear/headwear_419" }, 100));
		_dataArray.Add(new ArmorItem(125, LocalStringManager.GetConfig("Armor_language", "Name_125"), 1, 100, 8, 117, "icon_Armor_kongmingguan", LocalStringManager.GetConfig("Armor_language", "Desc_125"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_125"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 80, 305, 61500, 6, 18, 10800, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 5, isSpecial: false, 3, 36, 127, new List<int>(), 1, -1, 1795, 1020, 820, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 70),
			new PropertyAndValue(4, 70)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(45, 120), new OuterAndInnerShorts(20, 30), -1, new List<string> { "headwear/headwear", "headwear/headwear_419" }, 100));
		_dataArray.Add(new ArmorItem(126, LocalStringManager.GetConfig("Armor_language", "Name_126"), 1, 103, 0, 126, "icon_Armor_jiaoliao", LocalStringManager.GetConfig("Armor_language", "Desc_126"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_126"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 210, 300, 0, 2, 600, 3, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 45, isSpecial: false, 2, 36, 132, new List<int>(), 5, -1, 1793, 625, 625, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 60)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(40, 0), new OuterAndInnerShorts(10, 0), 381, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_111", "equip_shank_r", "equip_shank_r/equip_shank_r_111" }, 100));
		_dataArray.Add(new ArmorItem(127, LocalStringManager.GetConfig("Armor_language", "Name_127"), 1, 103, 1, 126, "icon_Armor_tiesuolu", LocalStringManager.GetConfig("Armor_language", "Desc_127"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_127"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 275, 600, 0, 4, 1200, 4, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 40, isSpecial: false, 2, 36, 132, new List<int>(), 5, -1, 1793, 700, 700, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 65)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(50, 0), new OuterAndInnerShorts(10, 0), 382, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_111", "equip_shank_r", "equip_shank_r/equip_shank_r_111" }, 100));
		_dataArray.Add(new ArmorItem(128, LocalStringManager.GetConfig("Armor_language", "Name_128"), 1, 103, 2, 126, "icon_Armor_jiashixue", LocalStringManager.GetConfig("Armor_language", "Desc_128"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_128"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 345, 1800, 1, 6, 1800, 5, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 35, isSpecial: false, 2, 36, 132, new List<int>(), 5, -1, 1793, 790, 790, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 70)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(60, 0), new OuterAndInnerShorts(15, 0), 383, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_111", "equip_shank_r", "equip_shank_r/equip_shank_r_111" }, 100));
		_dataArray.Add(new ArmorItem(129, LocalStringManager.GetConfig("Armor_language", "Name_129"), 1, 103, 3, 126, "icon_Armor_baoliantiexue", LocalStringManager.GetConfig("Armor_language", "Desc_129"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_129"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 410, 4500, 2, 8, 3000, 6, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 30, isSpecial: false, 2, 36, 132, new List<int>(), 5, -1, 1793, 880, 880, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 75)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(70, 0), new OuterAndInnerShorts(20, 0), 384, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_115", "equip_shank_r", "equip_shank_r/equip_shank_r_115" }, 100));
		_dataArray.Add(new ArmorItem(130, LocalStringManager.GetConfig("Armor_language", "Name_130"), 1, 103, 4, 126, "icon_Armor_guitouxue", LocalStringManager.GetConfig("Armor_language", "Desc_130"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_130"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 480, 9300, 3, 10, 4200, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 25, isSpecial: false, 2, 36, 132, new List<int>(), 5, -1, 1793, 975, 975, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 80)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(80, 0), new OuterAndInnerShorts(20, 0), 385, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_115", "equip_shank_r", "equip_shank_r/equip_shank_r_115" }, 100));
		_dataArray.Add(new ArmorItem(131, LocalStringManager.GetConfig("Armor_language", "Name_131"), 1, 103, 5, 126, "icon_Armor_shuanghuanzhentianlu", LocalStringManager.GetConfig("Armor_language", "Desc_131"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_131"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 545, 16800, 4, 12, 5400, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 20, isSpecial: false, 2, 36, 132, new List<int>(), 5, -1, 1793, 1070, 1070, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 85)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(90, 0), new OuterAndInnerShorts(25, 0), 386, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_115", "equip_shank_r", "equip_shank_r/equip_shank_r_115" }, 100));
		_dataArray.Add(new ArmorItem(132, LocalStringManager.GetConfig("Armor_language", "Name_132"), 1, 103, 6, 126, "icon_Armor_jingangzuhuan", LocalStringManager.GetConfig("Armor_language", "Desc_132"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_132"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 615, 27600, 5, 14, 7200, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 15, isSpecial: false, 2, 36, 132, new List<int>(), 5, -1, 1793, 1180, 1180, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 90)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(100, 0), new OuterAndInnerShorts(30, 0), 387, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_119", "equip_shank_r", "equip_shank_r/equip_shank_r_119" }, 100));
		_dataArray.Add(new ArmorItem(133, LocalStringManager.GetConfig("Armor_language", "Name_133"), 1, 103, 7, 126, "icon_Armor_longxiangbaoxue", LocalStringManager.GetConfig("Armor_language", "Desc_133"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_133"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 680, 42300, 6, 16, 9000, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 10, isSpecial: false, 2, 36, 132, new List<int>(), 5, -1, 1793, 1285, 1285, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 95)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(110, 0), new OuterAndInnerShorts(30, 0), 388, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_119", "equip_shank_r", "equip_shank_r/equip_shank_r_119" }, 100));
		_dataArray.Add(new ArmorItem(134, LocalStringManager.GetConfig("Armor_language", "Name_134"), 1, 103, 8, 126, "icon_Armor_qiushensuo", LocalStringManager.GetConfig("Armor_language", "Desc_134"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_134"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 750, 61500, 6, 18, 10800, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 5, isSpecial: false, 2, 36, 132, new List<int>(), 5, -1, 1793, 1400, 1400, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 100)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(120, 0), new OuterAndInnerShorts(35, 0), 389, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_119", "equip_shank_r", "equip_shank_r/equip_shank_r_119" }, 100));
		_dataArray.Add(new ArmorItem(135, LocalStringManager.GetConfig("Armor_language", "Name_135"), 1, 103, 0, 135, "icon_Armor_tongzuhuan", LocalStringManager.GetConfig("Armor_language", "Desc_135"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_135"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 180, 300, 0, 2, 600, 3, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 45, isSpecial: false, 2, 36, 139, new List<int>(), 5, -1, 1793, 490, 730, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 60)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(20, 20), new OuterAndInnerShorts(0, 0), 390, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_131", "equip_shank_r", "equip_shank_r/equip_shank_r_131" }, 100));
		_dataArray.Add(new ArmorItem(136, LocalStringManager.GetConfig("Armor_language", "Name_136"), 1, 103, 1, 135, "icon_Armor_yinjitongxue", LocalStringManager.GetConfig("Armor_language", "Desc_136"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_136"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 230, 600, 0, 4, 1200, 4, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 40, isSpecial: false, 2, 36, 139, new List<int>(), 5, -1, 1793, 555, 815, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 65)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(30, 30), new OuterAndInnerShorts(0, 0), 391, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_131", "equip_shank_r", "equip_shank_r/equip_shank_r_131" }, 100));
		_dataArray.Add(new ArmorItem(137, LocalStringManager.GetConfig("Armor_language", "Name_137"), 1, 103, 2, 135, "icon_Armor_xuelianxue", LocalStringManager.GetConfig("Armor_language", "Desc_137"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_137"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 285, 1800, 1, 6, 1800, 5, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 35, isSpecial: false, 2, 36, 139, new List<int>(), 5, -1, 1793, 625, 905, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 70)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(40, 40), new OuterAndInnerShorts(0, 0), 392, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_131", "equip_shank_r", "equip_shank_r/equip_shank_r_131" }, 100));
		_dataArray.Add(new ArmorItem(138, LocalStringManager.GetConfig("Armor_language", "Name_138"), 1, 103, 3, 135, "icon_Armor_tujinxiongtouxue", LocalStringManager.GetConfig("Armor_language", "Desc_138"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_138"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 335, 4500, 2, 8, 3000, 6, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 30, isSpecial: false, 2, 36, 139, new List<int>(), 5, -1, 1793, 690, 990, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 75)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(50, 50), new OuterAndInnerShorts(10, 10), 393, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_135", "equip_shank_r", "equip_shank_r/equip_shank_r_135" }, 100));
		_dataArray.Add(new ArmorItem(139, LocalStringManager.GetConfig("Armor_language", "Name_139"), 1, 103, 4, 135, "icon_Armor_baotaxue", LocalStringManager.GetConfig("Armor_language", "Desc_139"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_139"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 390, 9300, 3, 10, 4200, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 25, isSpecial: false, 2, 36, 139, new List<int>(), 5, -1, 1793, 770, 1090, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 80)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(60, 60), new OuterAndInnerShorts(10, 10), 394, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_135", "equip_shank_r", "equip_shank_r/equip_shank_r_135" }, 100));
		_dataArray.Add(new ArmorItem(140, LocalStringManager.GetConfig("Armor_language", "Name_140"), 1, 103, 5, 135, "icon_Armor_fengchijinxue", LocalStringManager.GetConfig("Armor_language", "Desc_140"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_140"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 440, 16800, 4, 12, 5400, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 20, isSpecial: false, 2, 36, 139, new List<int>(), 5, -1, 1793, 840, 1180, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 85)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(70, 70), new OuterAndInnerShorts(15, 15), 395, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_135", "equip_shank_r", "equip_shank_r/equip_shank_r_135" }, 100));
		_dataArray.Add(new ArmorItem(141, LocalStringManager.GetConfig("Armor_language", "Name_141"), 1, 103, 6, 135, "icon_Armor_jiangmohumulun", LocalStringManager.GetConfig("Armor_language", "Desc_141"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_141"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 495, 27600, 5, 14, 7200, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 15, isSpecial: false, 2, 36, 139, new List<int>(), 5, -1, 1793, 925, 1285, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 90)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(80, 80), new OuterAndInnerShorts(20, 20), 396, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_139", "equip_shank_r", "equip_shank_r/equip_shank_r_139" }, 100));
		_dataArray.Add(new ArmorItem(142, LocalStringManager.GetConfig("Armor_language", "Name_142"), 1, 103, 7, 135, "icon_Armor_shenquelu", LocalStringManager.GetConfig("Armor_language", "Desc_142"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_142"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 545, 42300, 6, 16, 9000, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 10, isSpecial: false, 2, 36, 139, new List<int>(), 5, -1, 1793, 1005, 1385, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 95)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(90, 90), new OuterAndInnerShorts(20, 20), 397, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_139", "equip_shank_r", "equip_shank_r/equip_shank_r_139" }, 100));
		_dataArray.Add(new ArmorItem(143, LocalStringManager.GetConfig("Armor_language", "Name_143"), 1, 103, 8, 135, "icon_Armor_jinjiazu", LocalStringManager.GetConfig("Armor_language", "Desc_143"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_143"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 600, 61500, 6, 18, 10800, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 5, isSpecial: false, 2, 36, 139, new List<int>(), 5, -1, 1793, 1100, 1500, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 100)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(100, 100), new OuterAndInnerShorts(25, 25), 398, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_139", "equip_shank_r", "equip_shank_r/equip_shank_r_139" }, 100));
		_dataArray.Add(new ArmorItem(144, LocalStringManager.GetConfig("Armor_language", "Name_144"), 1, 103, 0, 144, "icon_Armor_muji", LocalStringManager.GetConfig("Armor_language", "Desc_144"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_144"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 60, 70, 300, 0, 2, 600, 3, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 45, isSpecial: false, 1, 36, 133, new List<int>(), 5, -1, 1794, 215, 575, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 50)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(20, 10), new OuterAndInnerShorts(0, 0), 327, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_211", "equip_shank_r", "equip_shank_r/equip_shank_r_211" }, 100));
		_dataArray.Add(new ArmorItem(145, LocalStringManager.GetConfig("Armor_language", "Name_145"), 1, 103, 1, 144, "icon_Armor_yingzuixie", LocalStringManager.GetConfig("Armor_language", "Desc_145"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_145"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 60, 100, 600, 0, 4, 1200, 4, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 40, isSpecial: false, 1, 36, 133, new List<int>(), 5, -1, 1794, 245, 635, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 55)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(30, 15), new OuterAndInnerShorts(0, 0), 328, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_211", "equip_shank_r", "equip_shank_r/equip_shank_r_211" }, 100));
		_dataArray.Add(new ArmorItem(146, LocalStringManager.GetConfig("Armor_language", "Name_146"), 1, 103, 2, 144, "icon_Armor_pansheji", LocalStringManager.GetConfig("Armor_language", "Desc_146"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_146"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 60, 130, 1800, 1, 6, 1800, 5, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 35, isSpecial: false, 1, 36, 133, new List<int>(), 5, -1, 1794, 285, 705, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 60)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(40, 20), new OuterAndInnerShorts(10, 0), 329, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_211", "equip_shank_r", "equip_shank_r/equip_shank_r_211" }, 100));
		_dataArray.Add(new ArmorItem(147, LocalStringManager.GetConfig("Armor_language", "Name_147"), 1, 103, 3, 144, "icon_Armor_xiegongchiji", LocalStringManager.GetConfig("Armor_language", "Desc_147"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_147"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 60, 160, 4500, 2, 8, 3000, 6, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 30, isSpecial: false, 1, 36, 133, new List<int>(), 5, -1, 1794, 325, 775, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 65)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(50, 25), new OuterAndInnerShorts(10, 0), 330, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_215", "equip_shank_r", "equip_shank_r/equip_shank_r_215" }, 100));
		_dataArray.Add(new ArmorItem(148, LocalStringManager.GetConfig("Armor_language", "Name_148"), 1, 103, 4, 144, "icon_Armor_diechihongji", LocalStringManager.GetConfig("Armor_language", "Desc_148"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_148"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 60, 190, 9300, 3, 10, 4200, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 25, isSpecial: false, 1, 36, 133, new List<int>(), 5, -1, 1794, 370, 850, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 70)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(60, 30), new OuterAndInnerShorts(15, 0), 331, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_215", "equip_shank_r", "equip_shank_r/equip_shank_r_215" }, 100));
		_dataArray.Add(new ArmorItem(149, LocalStringManager.GetConfig("Armor_language", "Name_149"), 1, 103, 5, 144, "icon_Armor_yechazu", LocalStringManager.GetConfig("Armor_language", "Desc_149"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_149"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 60, 220, 16800, 4, 12, 5400, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 20, isSpecial: false, 1, 36, 133, new List<int>(), 5, -1, 1794, 410, 920, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 75)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(70, 35), new OuterAndInnerShorts(20, 0), 332, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_215", "equip_shank_r", "equip_shank_r/equip_shank_r_215" }, 100));
		_dataArray.Add(new ArmorItem(150, LocalStringManager.GetConfig("Armor_language", "Name_150"), 1, 103, 6, 144, "icon_Armor_yinyangshunnilu", LocalStringManager.GetConfig("Armor_language", "Desc_150"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_150"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 60, 250, 27600, 5, 14, 7200, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 15, isSpecial: false, 1, 36, 133, new List<int>(), 5, -1, 1794, 460, 1000, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 80)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(80, 40), new OuterAndInnerShorts(20, 0), 333, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_219", "equip_shank_r", "equip_shank_r/equip_shank_r_219" }, 100));
		_dataArray.Add(new ArmorItem(151, LocalStringManager.GetConfig("Armor_language", "Name_151"), 1, 103, 7, 144, "icon_Armor_juediwuhuangji", LocalStringManager.GetConfig("Armor_language", "Desc_151"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_151"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 60, 280, 42300, 6, 16, 9000, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 10, isSpecial: false, 1, 36, 133, new List<int>(), 5, -1, 1794, 505, 1075, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 85)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(90, 45), new OuterAndInnerShorts(25, 0), 334, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_219", "equip_shank_r", "equip_shank_r/equip_shank_r_219" }, 100));
		_dataArray.Add(new ArmorItem(152, LocalStringManager.GetConfig("Armor_language", "Name_152"), 1, 103, 8, 144, "icon_Armor_kuilongji", LocalStringManager.GetConfig("Armor_language", "Desc_152"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_152"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 60, 310, 61500, 6, 18, 10800, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 5, isSpecial: false, 1, 36, 133, new List<int>(), 5, -1, 1794, 560, 1160, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 90)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(100, 50), new OuterAndInnerShorts(30, 0), 335, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_219", "equip_shank_r", "equip_shank_r/equip_shank_r_219" }, 100));
		_dataArray.Add(new ArmorItem(153, LocalStringManager.GetConfig("Armor_language", "Name_153"), 1, 103, 0, 153, "icon_Armor_zhubangtui", LocalStringManager.GetConfig("Armor_language", "Desc_153"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_153"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 60, 45, 300, 0, 2, 600, 3, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 45, isSpecial: false, 1, 36, 140, new List<int>(), 5, -1, 1794, 265, 505, new List<PropertyAndValue>
		{
			new PropertyAndValue(4, 50)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(10, 20), new OuterAndInnerShorts(0, 0), 336, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_231", "equip_shank_r", "equip_shank_r/equip_shank_r_231" }, 100));
		_dataArray.Add(new ArmorItem(154, LocalStringManager.GetConfig("Armor_language", "Name_154"), 1, 103, 1, 153, "icon_Armor_danshanchanzu", LocalStringManager.GetConfig("Armor_language", "Desc_154"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_154"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 60, 70, 600, 0, 4, 1200, 4, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 40, isSpecial: false, 1, 36, 140, new List<int>(), 5, -1, 1794, 300, 560, new List<PropertyAndValue>
		{
			new PropertyAndValue(4, 55)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(15, 30), new OuterAndInnerShorts(0, 0), 337, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_231", "equip_shank_r", "equip_shank_r/equip_shank_r_231" }, 100));
		_dataArray.Add(new ArmorItem(155, LocalStringManager.GetConfig("Armor_language", "Name_155"), 1, 103, 2, 153, "icon_Armor_chanbeixie", LocalStringManager.GetConfig("Armor_language", "Desc_155"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_155"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 60, 95, 1800, 1, 6, 1800, 5, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 35, isSpecial: false, 1, 36, 140, new List<int>(), 5, -1, 1794, 335, 615, new List<PropertyAndValue>
		{
			new PropertyAndValue(4, 60)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(20, 40), new OuterAndInnerShorts(0, 10), 338, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_231", "equip_shank_r", "equip_shank_r/equip_shank_r_231" }, 100));
		_dataArray.Add(new ArmorItem(156, LocalStringManager.GetConfig("Armor_language", "Name_156"), 1, 103, 3, 153, "icon_Armor_fenshuimuji", LocalStringManager.GetConfig("Armor_language", "Desc_156"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_156"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 60, 120, 4500, 2, 8, 3000, 6, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 30, isSpecial: false, 1, 36, 140, new List<int>(), 5, -1, 1794, 375, 675, new List<PropertyAndValue>
		{
			new PropertyAndValue(4, 65)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(25, 50), new OuterAndInnerShorts(0, 10), 339, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_235", "equip_shank_r", "equip_shank_r/equip_shank_r_235" }, 100));
		_dataArray.Add(new ArmorItem(157, LocalStringManager.GetConfig("Armor_language", "Name_157"), 1, 103, 4, 153, "icon_Armor_chenxianglu", LocalStringManager.GetConfig("Armor_language", "Desc_157"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_157"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 60, 140, 9300, 3, 10, 4200, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 25, isSpecial: false, 1, 36, 140, new List<int>(), 5, -1, 1794, 415, 735, new List<PropertyAndValue>
		{
			new PropertyAndValue(4, 70)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(30, 60), new OuterAndInnerShorts(0, 15), 340, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_235", "equip_shank_r", "equip_shank_r/equip_shank_r_235" }, 100));
		_dataArray.Add(new ArmorItem(158, LocalStringManager.GetConfig("Armor_language", "Name_158"), 1, 103, 5, 153, "icon_Armor_biluohuaexie", LocalStringManager.GetConfig("Armor_language", "Desc_158"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_158"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 60, 165, 16800, 4, 12, 5400, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 20, isSpecial: false, 1, 36, 140, new List<int>(), 5, -1, 1794, 460, 800, new List<PropertyAndValue>
		{
			new PropertyAndValue(4, 75)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(35, 70), new OuterAndInnerShorts(0, 20), 341, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_235", "equip_shank_r", "equip_shank_r/equip_shank_r_235" }, 100));
		_dataArray.Add(new ArmorItem(159, LocalStringManager.GetConfig("Armor_language", "Name_159"), 1, 103, 6, 153, "icon_Armor_jialanbaoxue", LocalStringManager.GetConfig("Armor_language", "Desc_159"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_159"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 60, 190, 27600, 5, 14, 7200, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 15, isSpecial: false, 1, 36, 140, new List<int>(), 5, -1, 1794, 505, 865, new List<PropertyAndValue>
		{
			new PropertyAndValue(4, 80)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(40, 80), new OuterAndInnerShorts(0, 20), 342, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_239", "equip_shank_r", "equip_shank_r/equip_shank_r_239" }, 100));
		_dataArray.Add(new ArmorItem(160, LocalStringManager.GetConfig("Armor_language", "Name_160"), 1, 103, 7, 153, "icon_Armor_liurendunjiaji", LocalStringManager.GetConfig("Armor_language", "Desc_160"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_160"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 60, 215, 42300, 6, 16, 9000, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 10, isSpecial: false, 1, 36, 140, new List<int>(), 5, -1, 1794, 550, 930, new List<PropertyAndValue>
		{
			new PropertyAndValue(4, 85)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(45, 90), new OuterAndInnerShorts(0, 25), 343, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_239", "equip_shank_r", "equip_shank_r/equip_shank_r_239" }, 100));
		_dataArray.Add(new ArmorItem(161, LocalStringManager.GetConfig("Armor_language", "Name_161"), 1, 103, 8, 153, "icon_Armor_kurongyouta", LocalStringManager.GetConfig("Armor_language", "Desc_161"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_161"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 60, 240, 61500, 6, 18, 10800, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 5, isSpecial: false, 1, 36, 140, new List<int>(), 5, -1, 1794, 600, 1000, new List<PropertyAndValue>
		{
			new PropertyAndValue(4, 90)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(50, 100), new OuterAndInnerShorts(0, 30), 344, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_239", "equip_shank_r", "equip_shank_r/equip_shank_r_239" }, 100));
		_dataArray.Add(new ArmorItem(162, LocalStringManager.GetConfig("Armor_language", "Name_162"), 1, 103, 0, 162, "icon_Armor_sulu", LocalStringManager.GetConfig("Armor_language", "Desc_162"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_162"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 60, 300, 0, 2, 600, 3, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 45, isSpecial: false, 4, 36, 135, new List<int>(), 5, -1, 1796, 155, 395, new List<PropertyAndValue>
		{
			new PropertyAndValue(1, 20),
			new PropertyAndValue(3, 20)
		}, new HitOrAvoidShorts(0, 0, 20, 0), new OuterAndInnerShorts(20, 0), new OuterAndInnerShorts(0, 0), 345, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_311", "equip_shank_r", "equip_shank_r/equip_shank_r_311" }, 100));
		_dataArray.Add(new ArmorItem(163, LocalStringManager.GetConfig("Armor_language", "Name_163"), 1, 103, 1, 162, "icon_Armor_qitouxie", LocalStringManager.GetConfig("Armor_language", "Desc_163"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_163"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 60, 600, 0, 4, 1200, 4, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 40, isSpecial: false, 4, 36, 135, new List<int>(), 5, -1, 1796, 170, 430, new List<PropertyAndValue>
		{
			new PropertyAndValue(1, 25),
			new PropertyAndValue(3, 25)
		}, new HitOrAvoidShorts(0, 0, 20, 0), new OuterAndInnerShorts(30, 0), new OuterAndInnerShorts(0, 0), 346, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_311", "equip_shank_r", "equip_shank_r/equip_shank_r_311" }, 100));
		_dataArray.Add(new ArmorItem(164, LocalStringManager.GetConfig("Armor_language", "Name_164"), 1, 103, 2, 162, "icon_Armor_yanying", LocalStringManager.GetConfig("Armor_language", "Desc_164"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_164"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 60, 1800, 1, 6, 1800, 5, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 35, isSpecial: false, 4, 36, 135, new List<int>(), 5, -1, 1796, 180, 460, new List<PropertyAndValue>
		{
			new PropertyAndValue(1, 30),
			new PropertyAndValue(3, 30)
		}, new HitOrAvoidShorts(0, 0, 20, 0), new OuterAndInnerShorts(40, 0), new OuterAndInnerShorts(0, 0), 347, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_311", "equip_shank_r", "equip_shank_r/equip_shank_r_311" }, 100));
		_dataArray.Add(new ArmorItem(165, LocalStringManager.GetConfig("Armor_language", "Name_165"), 1, 103, 3, 162, "icon_Armor_dianguanglu", LocalStringManager.GetConfig("Armor_language", "Desc_165"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_165"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 60, 4500, 2, 8, 3000, 6, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 30, isSpecial: false, 4, 36, 135, new List<int>(), 5, -1, 1796, 195, 495, new List<PropertyAndValue>
		{
			new PropertyAndValue(1, 35),
			new PropertyAndValue(3, 35)
		}, new HitOrAvoidShorts(0, 0, 25, 0), new OuterAndInnerShorts(50, 0), new OuterAndInnerShorts(0, 0), 348, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_315", "equip_shank_r", "equip_shank_r/equip_shank_r_315" }, 100));
		_dataArray.Add(new ArmorItem(166, LocalStringManager.GetConfig("Armor_language", "Name_166"), 1, 103, 4, 162, "icon_Armor_linyufeizu", LocalStringManager.GetConfig("Armor_language", "Desc_166"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_166"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 60, 9300, 3, 10, 4200, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 25, isSpecial: false, 4, 36, 135, new List<int>(), 5, -1, 1796, 210, 530, new List<PropertyAndValue>
		{
			new PropertyAndValue(1, 40),
			new PropertyAndValue(3, 40)
		}, new HitOrAvoidShorts(0, 0, 25, 0), new OuterAndInnerShorts(60, 0), new OuterAndInnerShorts(0, 0), 349, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_315", "equip_shank_r", "equip_shank_r/equip_shank_r_315" }, 100));
		_dataArray.Add(new ArmorItem(167, LocalStringManager.GetConfig("Armor_language", "Name_167"), 1, 103, 5, 162, "icon_Armor_fenglaiyi", LocalStringManager.GetConfig("Armor_language", "Desc_167"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_167"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 60, 16800, 4, 12, 5400, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 20, isSpecial: false, 4, 36, 135, new List<int>(), 5, -1, 1796, 220, 560, new List<PropertyAndValue>
		{
			new PropertyAndValue(1, 45),
			new PropertyAndValue(3, 45)
		}, new HitOrAvoidShorts(0, 0, 25, 0), new OuterAndInnerShorts(70, 0), new OuterAndInnerShorts(0, 0), 350, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_315", "equip_shank_r", "equip_shank_r/equip_shank_r_315" }, 100));
		_dataArray.Add(new ArmorItem(168, LocalStringManager.GetConfig("Armor_language", "Name_168"), 1, 103, 6, 162, "icon_Armor_jinghuawu", LocalStringManager.GetConfig("Armor_language", "Desc_168"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_168"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 60, 27600, 5, 14, 7200, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 15, isSpecial: false, 4, 36, 135, new List<int>(), 5, -1, 1796, 235, 595, new List<PropertyAndValue>
		{
			new PropertyAndValue(1, 50),
			new PropertyAndValue(3, 50)
		}, new HitOrAvoidShorts(0, 0, 30, 0), new OuterAndInnerShorts(80, 0), new OuterAndInnerShorts(0, 0), 351, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_319", "equip_shank_r", "equip_shank_r/equip_shank_r_319" }, 100));
		_dataArray.Add(new ArmorItem(169, LocalStringManager.GetConfig("Armor_language", "Name_169"), 1, 103, 7, 162, "icon_Armor_piaomiaoluowa", LocalStringManager.GetConfig("Armor_language", "Desc_169"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_169"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 60, 42300, 6, 16, 9000, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 10, isSpecial: false, 4, 36, 135, new List<int>(), 5, -1, 1796, 245, 625, new List<PropertyAndValue>
		{
			new PropertyAndValue(1, 55),
			new PropertyAndValue(3, 55)
		}, new HitOrAvoidShorts(0, 0, 30, 0), new OuterAndInnerShorts(90, 0), new OuterAndInnerShorts(0, 0), 352, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_319", "equip_shank_r", "equip_shank_r/equip_shank_r_319" }, 100));
		_dataArray.Add(new ArmorItem(170, LocalStringManager.GetConfig("Armor_language", "Name_170"), 1, 103, 8, 162, "icon_Armor_chankexue", LocalStringManager.GetConfig("Armor_language", "Desc_170"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_170"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 60, 61500, 6, 18, 10800, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 5, isSpecial: false, 4, 36, 135, new List<int>(), 5, -1, 1796, 260, 660, new List<PropertyAndValue>
		{
			new PropertyAndValue(1, 60),
			new PropertyAndValue(3, 60)
		}, new HitOrAvoidShorts(0, 0, 30, 0), new OuterAndInnerShorts(100, 0), new OuterAndInnerShorts(0, 0), 353, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_319", "equip_shank_r", "equip_shank_r/equip_shank_r_319" }, 100));
		_dataArray.Add(new ArmorItem(171, LocalStringManager.GetConfig("Armor_language", "Name_171"), 1, 103, 0, 171, "icon_Armor_zhifengxue", LocalStringManager.GetConfig("Armor_language", "Desc_171"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_171"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 60, 300, 0, 2, 600, 3, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 45, isSpecial: false, 4, 36, 137, new List<int>(), 5, -1, 1796, 155, 395, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 20),
			new PropertyAndValue(5, 20)
		}, new HitOrAvoidShorts(0, 20, 0, 0), new OuterAndInnerShorts(20, 0), new OuterAndInnerShorts(0, 0), 354, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_321", "equip_shank_r", "equip_shank_r/equip_shank_r_321" }, 100));
		_dataArray.Add(new ArmorItem(172, LocalStringManager.GetConfig("Armor_language", "Name_172"), 1, 103, 1, 171, "icon_Armor_edingxue", LocalStringManager.GetConfig("Armor_language", "Desc_172"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_172"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 65, 600, 0, 4, 1200, 4, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 40, isSpecial: false, 4, 36, 137, new List<int>(), 5, -1, 1796, 170, 430, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 25),
			new PropertyAndValue(5, 25)
		}, new HitOrAvoidShorts(0, 20, 0, 0), new OuterAndInnerShorts(30, 0), new OuterAndInnerShorts(0, 0), 355, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_321", "equip_shank_r", "equip_shank_r/equip_shank_r_321" }, 100));
		_dataArray.Add(new ArmorItem(173, LocalStringManager.GetConfig("Armor_language", "Name_173"), 1, 103, 2, 171, "icon_Armor_shuanglijinxue", LocalStringManager.GetConfig("Armor_language", "Desc_173"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_173"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 70, 1800, 1, 6, 1800, 5, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 35, isSpecial: false, 4, 36, 137, new List<int>(), 5, -1, 1796, 190, 470, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 30),
			new PropertyAndValue(5, 30)
		}, new HitOrAvoidShorts(0, 20, 0, 0), new OuterAndInnerShorts(40, 0), new OuterAndInnerShorts(0, 0), 356, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_321", "equip_shank_r", "equip_shank_r/equip_shank_r_321" }, 100));
		_dataArray.Add(new ArmorItem(174, LocalStringManager.GetConfig("Armor_language", "Name_174"), 1, 103, 3, 171, "icon_Armor_wuyangxue", LocalStringManager.GetConfig("Armor_language", "Desc_174"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_174"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 75, 4500, 2, 8, 3000, 6, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 30, isSpecial: false, 4, 36, 137, new List<int>(), 5, -1, 1796, 205, 505, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 35),
			new PropertyAndValue(5, 35)
		}, new HitOrAvoidShorts(0, 25, 0, 0), new OuterAndInnerShorts(50, 0), new OuterAndInnerShorts(0, 0), 357, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_325", "equip_shank_r", "equip_shank_r/equip_shank_r_325" }, 100));
		_dataArray.Add(new ArmorItem(175, LocalStringManager.GetConfig("Armor_language", "Name_175"), 1, 103, 4, 171, "icon_Armor_baiyu", LocalStringManager.GetConfig("Armor_language", "Desc_175"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_175"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 80, 9300, 3, 10, 4200, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 25, isSpecial: false, 4, 36, 137, new List<int>(), 5, -1, 1796, 225, 545, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 40),
			new PropertyAndValue(5, 40)
		}, new HitOrAvoidShorts(0, 25, 0, 0), new OuterAndInnerShorts(60, 0), new OuterAndInnerShorts(0, 0), 358, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_325", "equip_shank_r", "equip_shank_r/equip_shank_r_325" }, 100));
		_dataArray.Add(new ArmorItem(176, LocalStringManager.GetConfig("Armor_language", "Name_176"), 1, 103, 5, 171, "icon_Armor_qisejiuguangxue", LocalStringManager.GetConfig("Armor_language", "Desc_176"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_176"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 85, 16800, 4, 12, 5400, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 20, isSpecial: false, 4, 36, 137, new List<int>(), 5, -1, 1796, 240, 580, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 45),
			new PropertyAndValue(5, 45)
		}, new HitOrAvoidShorts(0, 25, 0, 0), new OuterAndInnerShorts(70, 0), new OuterAndInnerShorts(0, 0), 359, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_325", "equip_shank_r", "equip_shank_r/equip_shank_r_325" }, 100));
		_dataArray.Add(new ArmorItem(177, LocalStringManager.GetConfig("Armor_language", "Name_177"), 1, 103, 6, 171, "icon_Armor_guizhishenxue", LocalStringManager.GetConfig("Armor_language", "Desc_177"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_177"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 90, 27600, 5, 14, 7200, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 15, isSpecial: false, 4, 36, 137, new List<int>(), 5, -1, 1796, 260, 620, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 50),
			new PropertyAndValue(5, 50)
		}, new HitOrAvoidShorts(0, 30, 0, 0), new OuterAndInnerShorts(80, 0), new OuterAndInnerShorts(0, 0), 360, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_329", "equip_shank_r", "equip_shank_r/equip_shank_r_329" }, 100));
		_dataArray.Add(new ArmorItem(178, LocalStringManager.GetConfig("Armor_language", "Name_178"), 1, 103, 7, 171, "icon_Armor_qilinzu", LocalStringManager.GetConfig("Armor_language", "Desc_178"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_178"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 95, 42300, 6, 16, 9000, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 10, isSpecial: false, 4, 36, 137, new List<int>(), 5, -1, 1796, 275, 655, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 55),
			new PropertyAndValue(5, 55)
		}, new HitOrAvoidShorts(0, 30, 0, 0), new OuterAndInnerShorts(90, 0), new OuterAndInnerShorts(0, 0), 361, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_329", "equip_shank_r", "equip_shank_r/equip_shank_r_329" }, 100));
		_dataArray.Add(new ArmorItem(179, LocalStringManager.GetConfig("Armor_language", "Name_179"), 1, 103, 8, 171, "icon_Armor_jingangdou", LocalStringManager.GetConfig("Armor_language", "Desc_179"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_179"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 100, 61500, 6, 18, 10800, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 5, isSpecial: false, 4, 36, 137, new List<int>(), 5, -1, 1796, 300, 700, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 60),
			new PropertyAndValue(5, 60)
		}, new HitOrAvoidShorts(0, 30, 0, 0), new OuterAndInnerShorts(100, 0), new OuterAndInnerShorts(0, 0), 362, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_329", "equip_shank_r", "equip_shank_r/equip_shank_r_329" }, 100));
	}

	private void CreateItems3()
	{
		_dataArray.Add(new ArmorItem(180, LocalStringManager.GetConfig("Armor_language", "Name_180"), 1, 103, 0, 180, "icon_Armor_zhanxue", LocalStringManager.GetConfig("Armor_language", "Desc_180"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_180"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 80, 300, 0, 2, 600, 3, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 45, isSpecial: false, 4, 36, 136, new List<int>(), 5, -1, 1796, 170, 410, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 20),
			new PropertyAndValue(3, 20)
		}, new HitOrAvoidShorts(20, 0, 0, 0), new OuterAndInnerShorts(20, 0), new OuterAndInnerShorts(0, 0), 399, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_321", "equip_shank_r", "equip_shank_r/equip_shank_r_321" }, 100));
		_dataArray.Add(new ArmorItem(181, LocalStringManager.GetConfig("Armor_language", "Name_181"), 1, 103, 1, 180, "icon_Armor_yuanyoulu", LocalStringManager.GetConfig("Armor_language", "Desc_181"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_181"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 85, 600, 0, 4, 1200, 4, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 40, isSpecial: false, 4, 36, 136, new List<int>(), 5, -1, 1796, 180, 440, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 25),
			new PropertyAndValue(3, 25)
		}, new HitOrAvoidShorts(20, 0, 0, 0), new OuterAndInnerShorts(30, 0), new OuterAndInnerShorts(0, 0), 400, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_321", "equip_shank_r", "equip_shank_r/equip_shank_r_321" }, 100));
		_dataArray.Add(new ArmorItem(182, LocalStringManager.GetConfig("Armor_language", "Name_182"), 1, 103, 2, 180, "icon_Armor_liuhexue", LocalStringManager.GetConfig("Armor_language", "Desc_182"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_182"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 90, 1800, 1, 6, 1800, 5, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 35, isSpecial: false, 4, 36, 136, new List<int>(), 5, -1, 1796, 205, 485, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 30),
			new PropertyAndValue(3, 30)
		}, new HitOrAvoidShorts(20, 0, 0, 0), new OuterAndInnerShorts(40, 0), new OuterAndInnerShorts(0, 0), 401, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_321", "equip_shank_r", "equip_shank_r/equip_shank_r_321" }, 100));
		_dataArray.Add(new ArmorItem(183, LocalStringManager.GetConfig("Armor_language", "Name_183"), 1, 103, 3, 180, "icon_Armor_gunlongxue", LocalStringManager.GetConfig("Armor_language", "Desc_183"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_183"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 95, 4500, 2, 8, 3000, 6, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 30, isSpecial: false, 4, 36, 136, new List<int>(), 5, -1, 1796, 220, 520, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 35),
			new PropertyAndValue(3, 35)
		}, new HitOrAvoidShorts(25, 0, 0, 0), new OuterAndInnerShorts(50, 0), new OuterAndInnerShorts(0, 0), 402, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_325", "equip_shank_r", "equip_shank_r/equip_shank_r_325" }, 100));
		_dataArray.Add(new ArmorItem(184, LocalStringManager.GetConfig("Armor_language", "Name_184"), 1, 103, 4, 180, "icon_Armor_jiayunlu", LocalStringManager.GetConfig("Armor_language", "Desc_184"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_184"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 100, 9300, 3, 10, 4200, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 25, isSpecial: false, 4, 36, 136, new List<int>(), 5, -1, 1796, 240, 560, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 40),
			new PropertyAndValue(3, 40)
		}, new HitOrAvoidShorts(25, 0, 0, 0), new OuterAndInnerShorts(60, 0), new OuterAndInnerShorts(0, 0), 403, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_325", "equip_shank_r", "equip_shank_r/equip_shank_r_325" }, 100));
		_dataArray.Add(new ArmorItem(185, LocalStringManager.GetConfig("Armor_language", "Name_185"), 1, 103, 5, 180, "icon_Armor_qianlizhuifengxue", LocalStringManager.GetConfig("Armor_language", "Desc_185"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_185"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 105, 16800, 4, 12, 5400, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 20, isSpecial: false, 4, 36, 136, new List<int>(), 5, -1, 1796, 255, 595, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 45),
			new PropertyAndValue(3, 45)
		}, new HitOrAvoidShorts(25, 0, 0, 0), new OuterAndInnerShorts(70, 0), new OuterAndInnerShorts(0, 0), 404, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_325", "equip_shank_r", "equip_shank_r/equip_shank_r_325" }, 100));
		_dataArray.Add(new ArmorItem(186, LocalStringManager.GetConfig("Armor_language", "Name_186"), 1, 103, 6, 180, "icon_Armor_zhuri", LocalStringManager.GetConfig("Armor_language", "Desc_186"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_186"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 110, 27600, 5, 14, 7200, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 15, isSpecial: false, 4, 36, 136, new List<int>(), 5, -1, 1796, 280, 640, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 50),
			new PropertyAndValue(3, 50)
		}, new HitOrAvoidShorts(30, 0, 0, 0), new OuterAndInnerShorts(80, 0), new OuterAndInnerShorts(0, 0), 405, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_329", "equip_shank_r", "equip_shank_r/equip_shank_r_329" }, 100));
		_dataArray.Add(new ArmorItem(187, LocalStringManager.GetConfig("Armor_language", "Name_187"), 1, 103, 7, 180, "icon_Armor_zhijiudian", LocalStringManager.GetConfig("Armor_language", "Desc_187"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_187"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 115, 42300, 6, 16, 9000, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 10, isSpecial: false, 4, 36, 136, new List<int>(), 5, -1, 1796, 295, 675, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 55),
			new PropertyAndValue(3, 55)
		}, new HitOrAvoidShorts(30, 0, 0, 0), new OuterAndInnerShorts(90, 0), new OuterAndInnerShorts(0, 0), 406, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_329", "equip_shank_r", "equip_shank_r/equip_shank_r_329" }, 100));
		_dataArray.Add(new ArmorItem(188, LocalStringManager.GetConfig("Armor_language", "Name_188"), 1, 103, 8, 180, "icon_Armor_pidishenhang", LocalStringManager.GetConfig("Armor_language", "Desc_188"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_188"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 120, 61500, 6, 18, 10800, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 5, isSpecial: false, 4, 36, 136, new List<int>(), 5, -1, 1796, 320, 720, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 60),
			new PropertyAndValue(3, 60)
		}, new HitOrAvoidShorts(30, 0, 0, 0), new OuterAndInnerShorts(100, 0), new OuterAndInnerShorts(0, 0), 407, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_329", "equip_shank_r", "equip_shank_r/equip_shank_r_329" }, 100));
		_dataArray.Add(new ArmorItem(189, LocalStringManager.GetConfig("Armor_language", "Name_189"), 1, 103, 0, 189, "icon_Armor_cubuguozu", LocalStringManager.GetConfig("Armor_language", "Desc_189"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_189"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 100, 300, 0, 2, 600, 3, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 45, isSpecial: false, 4, 36, 138, new List<int>(), 5, -1, 1796, 180, 540, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 20),
			new PropertyAndValue(3, 20)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(20, 0), new OuterAndInnerShorts(10, 0), 417, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_321", "equip_shank_r", "equip_shank_r/equip_shank_r_321" }, 100));
		_dataArray.Add(new ArmorItem(190, LocalStringManager.GetConfig("Armor_language", "Name_190"), 1, 103, 1, 189, "icon_Armor_shuanglianggelu", LocalStringManager.GetConfig("Armor_language", "Desc_190"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_190"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 110, 600, 0, 4, 1200, 4, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 40, isSpecial: false, 4, 36, 138, new List<int>(), 5, -1, 1796, 200, 590, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 25),
			new PropertyAndValue(3, 25)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(25, 0), new OuterAndInnerShorts(10, 0), 418, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_321", "equip_shank_r", "equip_shank_r/equip_shank_r_321" }, 100));
		_dataArray.Add(new ArmorItem(191, LocalStringManager.GetConfig("Armor_language", "Name_191"), 1, 103, 2, 189, "icon_Armor_luoquelu", LocalStringManager.GetConfig("Armor_language", "Desc_191"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_191"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 120, 1800, 1, 6, 1800, 5, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 35, isSpecial: false, 4, 36, 138, new List<int>(), 5, -1, 1796, 225, 645, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 30),
			new PropertyAndValue(3, 30)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(30, 0), new OuterAndInnerShorts(15, 0), 419, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_321", "equip_shank_r", "equip_shank_r/equip_shank_r_321" }, 100));
		_dataArray.Add(new ArmorItem(192, LocalStringManager.GetConfig("Armor_language", "Name_192"), 1, 103, 3, 189, "icon_Armor_shifanglu", LocalStringManager.GetConfig("Armor_language", "Desc_192"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_192"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 130, 4500, 2, 8, 3000, 6, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 30, isSpecial: false, 4, 36, 138, new List<int>(), 5, -1, 1796, 250, 700, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 35),
			new PropertyAndValue(3, 35)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(35, 0), new OuterAndInnerShorts(20, 0), 420, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_325", "equip_shank_r", "equip_shank_r/equip_shank_r_325" }, 100));
		_dataArray.Add(new ArmorItem(193, LocalStringManager.GetConfig("Armor_language", "Name_193"), 1, 103, 4, 189, "icon_Armor_chixi", LocalStringManager.GetConfig("Armor_language", "Desc_193"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_193"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 140, 9300, 3, 10, 4200, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 25, isSpecial: false, 4, 36, 138, new List<int>(), 5, -1, 1796, 270, 750, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 40),
			new PropertyAndValue(3, 40)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(40, 0), new OuterAndInnerShorts(20, 0), 421, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_325", "equip_shank_r", "equip_shank_r/equip_shank_r_325" }, 100));
		_dataArray.Add(new ArmorItem(194, LocalStringManager.GetConfig("Armor_language", "Name_194"), 1, 103, 5, 189, "icon_Armor_hubulonghang", LocalStringManager.GetConfig("Armor_language", "Desc_194"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_194"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 150, 16800, 4, 12, 5400, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 20, isSpecial: false, 4, 36, 138, new List<int>(), 5, -1, 1796, 300, 810, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 45),
			new PropertyAndValue(3, 45)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(45, 0), new OuterAndInnerShorts(25, 0), 422, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_325", "equip_shank_r", "equip_shank_r/equip_shank_r_325" }, 100));
		_dataArray.Add(new ArmorItem(195, LocalStringManager.GetConfig("Armor_language", "Name_195"), 1, 103, 6, 189, "icon_Armor_longjuxue", LocalStringManager.GetConfig("Armor_language", "Desc_195"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_195"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 160, 27600, 5, 14, 7200, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 15, isSpecial: false, 4, 36, 138, new List<int>(), 5, -1, 1796, 325, 865, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 50),
			new PropertyAndValue(3, 50)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(50, 0), new OuterAndInnerShorts(30, 0), 423, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_329", "equip_shank_r", "equip_shank_r/equip_shank_r_329" }, 100));
		_dataArray.Add(new ArmorItem(196, LocalStringManager.GetConfig("Armor_language", "Name_196"), 1, 103, 7, 189, "icon_Armor_tongtianxue", LocalStringManager.GetConfig("Armor_language", "Desc_196"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_196"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 170, 42300, 6, 16, 9000, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 10, isSpecial: false, 4, 36, 138, new List<int>(), 5, -1, 1796, 350, 920, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 55),
			new PropertyAndValue(3, 55)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(55, 0), new OuterAndInnerShorts(30, 0), 424, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_329", "equip_shank_r", "equip_shank_r/equip_shank_r_329" }, 100));
		_dataArray.Add(new ArmorItem(197, LocalStringManager.GetConfig("Armor_language", "Name_197"), 1, 103, 8, 189, "icon_Armor_wuzhuosuopo", LocalStringManager.GetConfig("Armor_language", "Desc_197"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_197"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 180, 61500, 6, 18, 10800, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 5, isSpecial: false, 4, 36, 138, new List<int>(), 5, -1, 1796, 380, 980, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 60),
			new PropertyAndValue(3, 60)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(60, 0), new OuterAndInnerShorts(35, 0), 425, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_329", "equip_shank_r", "equip_shank_r/equip_shank_r_329" }, 100));
		_dataArray.Add(new ArmorItem(198, LocalStringManager.GetConfig("Armor_language", "Name_198"), 1, 103, 0, 198, "icon_Armor_penghaoxie", LocalStringManager.GetConfig("Armor_language", "Desc_198"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_198"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 100, 300, 0, 2, 600, 3, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 45, isSpecial: false, 4, 36, 143, new List<int>(), 5, -1, 1796, 180, 420, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 20),
			new PropertyAndValue(4, 20)
		}, new HitOrAvoidShorts(20, 0, 0, 0), new OuterAndInnerShorts(0, 20), new OuterAndInnerShorts(0, 0), 408, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_321", "equip_shank_r", "equip_shank_r/equip_shank_r_321" }, 100));
		_dataArray.Add(new ArmorItem(199, LocalStringManager.GetConfig("Armor_language", "Name_199"), 1, 103, 1, 198, "icon_Armor_qiaotoufanglu", LocalStringManager.GetConfig("Armor_language", "Desc_199"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_199"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 105, 600, 0, 4, 1200, 4, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 40, isSpecial: false, 4, 36, 143, new List<int>(), 5, -1, 1796, 195, 455, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 25),
			new PropertyAndValue(4, 25)
		}, new HitOrAvoidShorts(20, 0, 0, 0), new OuterAndInnerShorts(0, 30), new OuterAndInnerShorts(0, 0), 409, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_321", "equip_shank_r", "equip_shank_r/equip_shank_r_321" }, 100));
		_dataArray.Add(new ArmorItem(200, LocalStringManager.GetConfig("Armor_language", "Name_200"), 1, 103, 2, 198, "icon_Armor_jinyaoxue", LocalStringManager.GetConfig("Armor_language", "Desc_200"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_200"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 110, 1800, 1, 6, 1800, 5, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 35, isSpecial: false, 4, 36, 143, new List<int>(), 5, -1, 1796, 215, 495, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 30),
			new PropertyAndValue(4, 30)
		}, new HitOrAvoidShorts(20, 0, 0, 0), new OuterAndInnerShorts(0, 40), new OuterAndInnerShorts(0, 0), 410, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_321", "equip_shank_r", "equip_shank_r/equip_shank_r_321" }, 100));
		_dataArray.Add(new ArmorItem(201, LocalStringManager.GetConfig("Armor_language", "Name_201"), 1, 103, 3, 198, "icon_Armor_suifuxie", LocalStringManager.GetConfig("Armor_language", "Desc_201"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_201"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 115, 4500, 2, 8, 3000, 6, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 30, isSpecial: false, 4, 36, 143, new List<int>(), 5, -1, 1796, 235, 535, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 35),
			new PropertyAndValue(4, 35)
		}, new HitOrAvoidShorts(25, 0, 0, 0), new OuterAndInnerShorts(0, 50), new OuterAndInnerShorts(0, 0), 411, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_325", "equip_shank_r", "equip_shank_r/equip_shank_r_325" }, 100));
		_dataArray.Add(new ArmorItem(202, LocalStringManager.GetConfig("Armor_language", "Name_202"), 1, 103, 4, 198, "icon_Armor_dunguangxie", LocalStringManager.GetConfig("Armor_language", "Desc_202"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_202"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 120, 9300, 3, 10, 4200, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 25, isSpecial: false, 4, 36, 143, new List<int>(), 5, -1, 1796, 255, 575, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 40),
			new PropertyAndValue(4, 40)
		}, new HitOrAvoidShorts(25, 0, 0, 0), new OuterAndInnerShorts(0, 60), new OuterAndInnerShorts(0, 0), 412, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_325", "equip_shank_r", "equip_shank_r/equip_shank_r_325" }, 100));
		_dataArray.Add(new ArmorItem(203, LocalStringManager.GetConfig("Armor_language", "Name_203"), 1, 103, 5, 198, "icon_Armor_qingyunzhi", LocalStringManager.GetConfig("Armor_language", "Desc_203"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_203"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 125, 16800, 4, 12, 5400, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 20, isSpecial: false, 4, 36, 143, new List<int>(), 5, -1, 1796, 270, 610, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 45),
			new PropertyAndValue(4, 45)
		}, new HitOrAvoidShorts(25, 0, 0, 0), new OuterAndInnerShorts(0, 70), new OuterAndInnerShorts(0, 0), 413, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_325", "equip_shank_r", "equip_shank_r/equip_shank_r_325" }, 100));
		_dataArray.Add(new ArmorItem(204, LocalStringManager.GetConfig("Armor_language", "Name_204"), 1, 103, 6, 198, "icon_Armor_xuejiansizu", LocalStringManager.GetConfig("Armor_language", "Desc_204"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_204"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 130, 27600, 5, 14, 7200, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 15, isSpecial: false, 4, 36, 143, new List<int>(), 5, -1, 1796, 295, 655, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 50),
			new PropertyAndValue(4, 50)
		}, new HitOrAvoidShorts(30, 0, 0, 0), new OuterAndInnerShorts(0, 80), new OuterAndInnerShorts(0, 0), 414, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_329", "equip_shank_r", "equip_shank_r/equip_shank_r_329" }, 100));
		_dataArray.Add(new ArmorItem(205, LocalStringManager.GetConfig("Armor_language", "Name_205"), 1, 103, 7, 198, "icon_Armor_longshalu", LocalStringManager.GetConfig("Armor_language", "Desc_205"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_205"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 135, 42300, 6, 16, 9000, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 10, isSpecial: false, 4, 36, 143, new List<int>(), 5, -1, 1796, 315, 695, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 55),
			new PropertyAndValue(4, 55)
		}, new HitOrAvoidShorts(30, 0, 0, 0), new OuterAndInnerShorts(0, 90), new OuterAndInnerShorts(0, 0), 415, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_329", "equip_shank_r", "equip_shank_r/equip_shank_r_329" }, 100));
		_dataArray.Add(new ArmorItem(206, LocalStringManager.GetConfig("Armor_language", "Name_206"), 1, 103, 8, 198, "icon_Armor_taichongshenxue", LocalStringManager.GetConfig("Armor_language", "Desc_206"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_206"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 140, 61500, 6, 18, 10800, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 5, isSpecial: false, 4, 36, 143, new List<int>(), 5, -1, 1796, 340, 740, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 60),
			new PropertyAndValue(4, 60)
		}, new HitOrAvoidShorts(30, 0, 0, 0), new OuterAndInnerShorts(0, 100), new OuterAndInnerShorts(0, 0), 416, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_329", "equip_shank_r", "equip_shank_r/equip_shank_r_329" }, 100));
		_dataArray.Add(new ArmorItem(207, LocalStringManager.GetConfig("Armor_language", "Name_207"), 1, 103, 0, 207, "icon_Armor_zongmaxie", LocalStringManager.GetConfig("Armor_language", "Desc_207"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_207"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 40, 300, 0, 2, 600, 3, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 45, isSpecial: false, 4, 36, 142, new List<int>(), 5, -1, 1796, 145, 385, new List<PropertyAndValue>
		{
			new PropertyAndValue(1, 20),
			new PropertyAndValue(4, 20)
		}, new HitOrAvoidShorts(0, 0, 20, 0), new OuterAndInnerShorts(0, 20), new OuterAndInnerShorts(0, 0), 363, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_311", "equip_shank_r", "equip_shank_r/equip_shank_r_311" }, 100));
		_dataArray.Add(new ArmorItem(208, LocalStringManager.GetConfig("Armor_language", "Name_208"), 1, 103, 1, 207, "icon_Armor_gaomanxie", LocalStringManager.GetConfig("Armor_language", "Desc_208"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_208"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 40, 600, 0, 4, 1200, 4, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 40, isSpecial: false, 4, 36, 142, new List<int>(), 5, -1, 1796, 155, 415, new List<PropertyAndValue>
		{
			new PropertyAndValue(1, 25),
			new PropertyAndValue(4, 25)
		}, new HitOrAvoidShorts(0, 0, 20, 0), new OuterAndInnerShorts(0, 30), new OuterAndInnerShorts(0, 0), 364, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_311", "equip_shank_r", "equip_shank_r/equip_shank_r_311" }, 100));
		_dataArray.Add(new ArmorItem(209, LocalStringManager.GetConfig("Armor_language", "Name_209"), 1, 103, 2, 207, "icon_Armor_jinwenyuanbaoxie", LocalStringManager.GetConfig("Armor_language", "Desc_209"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_209"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 40, 1800, 1, 6, 1800, 5, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 35, isSpecial: false, 4, 36, 142, new List<int>(), 5, -1, 1796, 170, 450, new List<PropertyAndValue>
		{
			new PropertyAndValue(1, 30),
			new PropertyAndValue(4, 30)
		}, new HitOrAvoidShorts(0, 0, 20, 0), new OuterAndInnerShorts(0, 40), new OuterAndInnerShorts(0, 0), 365, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_311", "equip_shank_r", "equip_shank_r/equip_shank_r_311" }, 100));
		_dataArray.Add(new ArmorItem(210, LocalStringManager.GetConfig("Armor_language", "Name_210"), 1, 103, 3, 207, "icon_Armor_wuyinxue", LocalStringManager.GetConfig("Armor_language", "Desc_210"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_210"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 40, 4500, 2, 8, 3000, 6, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 30, isSpecial: false, 4, 36, 142, new List<int>(), 5, -1, 1796, 180, 480, new List<PropertyAndValue>
		{
			new PropertyAndValue(1, 35),
			new PropertyAndValue(4, 35)
		}, new HitOrAvoidShorts(0, 0, 25, 0), new OuterAndInnerShorts(0, 50), new OuterAndInnerShorts(0, 0), 366, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_315", "equip_shank_r", "equip_shank_r/equip_shank_r_315" }, 100));
		_dataArray.Add(new ArmorItem(211, LocalStringManager.GetConfig("Armor_language", "Name_211"), 1, 103, 4, 207, "icon_Armor_lameiyinxue", LocalStringManager.GetConfig("Armor_language", "Desc_211"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_211"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 40, 9300, 3, 10, 4200, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 25, isSpecial: false, 4, 36, 142, new List<int>(), 5, -1, 1796, 190, 510, new List<PropertyAndValue>
		{
			new PropertyAndValue(1, 40),
			new PropertyAndValue(4, 40)
		}, new HitOrAvoidShorts(0, 0, 25, 0), new OuterAndInnerShorts(0, 60), new OuterAndInnerShorts(0, 0), 367, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_315", "equip_shank_r", "equip_shank_r/equip_shank_r_315" }, 100));
		_dataArray.Add(new ArmorItem(212, LocalStringManager.GetConfig("Armor_language", "Name_212"), 1, 103, 5, 207, "icon_Armor_fengxuyufeng", LocalStringManager.GetConfig("Armor_language", "Desc_212"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_212"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 40, 16800, 4, 12, 5400, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 20, isSpecial: false, 4, 36, 142, new List<int>(), 5, -1, 1796, 205, 545, new List<PropertyAndValue>
		{
			new PropertyAndValue(1, 45),
			new PropertyAndValue(4, 45)
		}, new HitOrAvoidShorts(0, 0, 25, 0), new OuterAndInnerShorts(0, 70), new OuterAndInnerShorts(0, 0), 368, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_315", "equip_shank_r", "equip_shank_r/equip_shank_r_315" }, 100));
		_dataArray.Add(new ArmorItem(213, LocalStringManager.GetConfig("Armor_language", "Name_213"), 1, 103, 6, 207, "icon_Armor_hunyuanxue", LocalStringManager.GetConfig("Armor_language", "Desc_213"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_213"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 40, 27600, 5, 14, 7200, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 15, isSpecial: false, 4, 36, 142, new List<int>(), 5, -1, 1796, 215, 575, new List<PropertyAndValue>
		{
			new PropertyAndValue(1, 50),
			new PropertyAndValue(4, 50)
		}, new HitOrAvoidShorts(0, 0, 30, 0), new OuterAndInnerShorts(0, 80), new OuterAndInnerShorts(0, 0), 369, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_319", "equip_shank_r", "equip_shank_r/equip_shank_r_319" }, 100));
		_dataArray.Add(new ArmorItem(214, LocalStringManager.GetConfig("Armor_language", "Name_214"), 1, 103, 7, 207, "icon_Armor_baoxiangshenglian", LocalStringManager.GetConfig("Armor_language", "Desc_214"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_214"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 40, 42300, 6, 16, 9000, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 10, isSpecial: false, 4, 36, 142, new List<int>(), 5, -1, 1796, 230, 610, new List<PropertyAndValue>
		{
			new PropertyAndValue(1, 55),
			new PropertyAndValue(4, 55)
		}, new HitOrAvoidShorts(0, 0, 30, 0), new OuterAndInnerShorts(0, 90), new OuterAndInnerShorts(0, 0), 370, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_319", "equip_shank_r", "equip_shank_r/equip_shank_r_319" }, 100));
		_dataArray.Add(new ArmorItem(215, LocalStringManager.GetConfig("Armor_language", "Name_215"), 1, 103, 8, 207, "icon_Armor_lingboxianlu", LocalStringManager.GetConfig("Armor_language", "Desc_215"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_215"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 40, 61500, 6, 18, 10800, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 5, isSpecial: false, 4, 36, 142, new List<int>(), 5, -1, 1796, 240, 640, new List<PropertyAndValue>
		{
			new PropertyAndValue(1, 60),
			new PropertyAndValue(4, 60)
		}, new HitOrAvoidShorts(0, 0, 30, 0), new OuterAndInnerShorts(0, 100), new OuterAndInnerShorts(0, 0), 371, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_319", "equip_shank_r", "equip_shank_r/equip_shank_r_319" }, 100));
		_dataArray.Add(new ArmorItem(216, LocalStringManager.GetConfig("Armor_language", "Name_216"), 1, 103, 0, 216, "icon_Armor_maxianguozu", LocalStringManager.GetConfig("Armor_language", "Desc_216"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_216"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 80, 300, 0, 2, 600, 3, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 45, isSpecial: false, 4, 36, 145, new List<int>(), 5, -1, 1796, 170, 530, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 20),
			new PropertyAndValue(4, 20)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 20), new OuterAndInnerShorts(0, 10), 426, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_311", "equip_shank_r", "equip_shank_r/equip_shank_r_311" }, 100));
		_dataArray.Add(new ArmorItem(217, LocalStringManager.GetConfig("Armor_language", "Name_217"), 1, 103, 1, 216, "icon_Armor_luohanxie", LocalStringManager.GetConfig("Armor_language", "Desc_217"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_217"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 90, 600, 0, 4, 1200, 4, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 40, isSpecial: false, 4, 36, 145, new List<int>(), 5, -1, 1796, 190, 580, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 25),
			new PropertyAndValue(4, 25)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 25), new OuterAndInnerShorts(0, 10), 427, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_311", "equip_shank_r", "equip_shank_r/equip_shank_r_311" }, 100));
		_dataArray.Add(new ArmorItem(218, LocalStringManager.GetConfig("Armor_language", "Name_218"), 1, 103, 2, 216, "icon_Armor_liangyidaoxue", LocalStringManager.GetConfig("Armor_language", "Desc_218"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_218"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 100, 1800, 1, 6, 1800, 5, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 35, isSpecial: false, 4, 36, 145, new List<int>(), 5, -1, 1796, 210, 630, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 30),
			new PropertyAndValue(4, 30)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 30), new OuterAndInnerShorts(0, 15), 428, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_311", "equip_shank_r", "equip_shank_r/equip_shank_r_311" }, 100));
		_dataArray.Add(new ArmorItem(219, LocalStringManager.GetConfig("Armor_language", "Name_219"), 1, 103, 3, 216, "icon_Armor_pishuixue", LocalStringManager.GetConfig("Armor_language", "Desc_219"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_219"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 110, 4500, 2, 8, 3000, 6, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 30, isSpecial: false, 4, 36, 145, new List<int>(), 5, -1, 1796, 235, 685, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 35),
			new PropertyAndValue(4, 35)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 35), new OuterAndInnerShorts(0, 20), 429, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_315", "equip_shank_r", "equip_shank_r/equip_shank_r_315" }, 100));
		_dataArray.Add(new ArmorItem(220, LocalStringManager.GetConfig("Armor_language", "Name_220"), 1, 103, 4, 216, "icon_Armor_chengwulu", LocalStringManager.GetConfig("Armor_language", "Desc_220"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_220"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 120, 9300, 3, 10, 4200, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 25, isSpecial: false, 4, 36, 145, new List<int>(), 5, -1, 1796, 255, 735, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 40),
			new PropertyAndValue(4, 40)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 40), new OuterAndInnerShorts(0, 20), 430, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_315", "equip_shank_r", "equip_shank_r/equip_shank_r_315" }, 100));
		_dataArray.Add(new ArmorItem(221, LocalStringManager.GetConfig("Armor_language", "Name_221"), 1, 103, 5, 216, "icon_Armor_cuishitaping", LocalStringManager.GetConfig("Armor_language", "Desc_221"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_221"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 130, 16800, 4, 12, 5400, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 20, isSpecial: false, 4, 36, 145, new List<int>(), 5, -1, 1796, 280, 790, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 45),
			new PropertyAndValue(4, 45)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 45), new OuterAndInnerShorts(0, 25), 431, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_315", "equip_shank_r", "equip_shank_r/equip_shank_r_315" }, 100));
		_dataArray.Add(new ArmorItem(222, LocalStringManager.GetConfig("Armor_language", "Name_222"), 1, 103, 6, 216, "icon_Armor_zhongxiao", LocalStringManager.GetConfig("Armor_language", "Desc_222"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_222"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 140, 27600, 5, 14, 7200, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 15, isSpecial: false, 4, 36, 145, new List<int>(), 5, -1, 1796, 305, 845, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 50),
			new PropertyAndValue(4, 50)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 50), new OuterAndInnerShorts(0, 30), 432, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_319", "equip_shank_r", "equip_shank_r/equip_shank_r_319" }, 100));
		_dataArray.Add(new ArmorItem(223, LocalStringManager.GetConfig("Armor_language", "Name_223"), 1, 103, 7, 216, "icon_Armor_juechenlu", LocalStringManager.GetConfig("Armor_language", "Desc_223"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_223"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 150, 42300, 6, 16, 9000, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 10, isSpecial: false, 4, 36, 145, new List<int>(), 5, -1, 1796, 335, 905, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 55),
			new PropertyAndValue(4, 55)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 55), new OuterAndInnerShorts(0, 30), 433, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_319", "equip_shank_r", "equip_shank_r/equip_shank_r_319" }, 100));
		_dataArray.Add(new ArmorItem(224, LocalStringManager.GetConfig("Armor_language", "Name_224"), 1, 103, 8, 216, "icon_Armor_shenezu", LocalStringManager.GetConfig("Armor_language", "Desc_224"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_224"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 160, 61500, 6, 18, 10800, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 5, isSpecial: false, 4, 36, 145, new List<int>(), 5, -1, 1796, 360, 960, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 60),
			new PropertyAndValue(4, 60)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 60), new OuterAndInnerShorts(0, 35), 434, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_319", "equip_shank_r", "equip_shank_r/equip_shank_r_319" }, 100));
		_dataArray.Add(new ArmorItem(225, LocalStringManager.GetConfig("Armor_language", "Name_225"), 1, 103, 0, 225, "icon_Armor_buboxie", LocalStringManager.GetConfig("Armor_language", "Desc_225"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_225"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 80, 300, 0, 2, 600, 3, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 45, isSpecial: false, 4, 36, 144, new List<int>(), 5, -1, 1796, 170, 410, new List<PropertyAndValue>
		{
			new PropertyAndValue(4, 20),
			new PropertyAndValue(5, 20)
		}, new HitOrAvoidShorts(0, 20, 0, 0), new OuterAndInnerShorts(0, 20), new OuterAndInnerShorts(0, 0), 372, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_311", "equip_shank_r", "equip_shank_r/equip_shank_r_311" }, 100));
		_dataArray.Add(new ArmorItem(226, LocalStringManager.GetConfig("Armor_language", "Name_226"), 1, 103, 1, 225, "icon_Armor_lingwenruanlu", LocalStringManager.GetConfig("Armor_language", "Desc_226"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_226"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 80, 600, 0, 4, 1200, 4, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 40, isSpecial: false, 4, 36, 144, new List<int>(), 5, -1, 1796, 180, 440, new List<PropertyAndValue>
		{
			new PropertyAndValue(4, 25),
			new PropertyAndValue(5, 25)
		}, new HitOrAvoidShorts(0, 20, 0, 0), new OuterAndInnerShorts(0, 30), new OuterAndInnerShorts(0, 0), 373, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_311", "equip_shank_r", "equip_shank_r/equip_shank_r_311" }, 100));
		_dataArray.Add(new ArmorItem(227, LocalStringManager.GetConfig("Armor_language", "Name_227"), 1, 103, 2, 225, "icon_Armor_yuntouziyingxie", LocalStringManager.GetConfig("Armor_language", "Desc_227"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_227"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 80, 1800, 1, 6, 1800, 5, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 35, isSpecial: false, 4, 36, 144, new List<int>(), 5, -1, 1796, 195, 475, new List<PropertyAndValue>
		{
			new PropertyAndValue(4, 30),
			new PropertyAndValue(5, 30)
		}, new HitOrAvoidShorts(0, 20, 0, 0), new OuterAndInnerShorts(0, 40), new OuterAndInnerShorts(0, 0), 374, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_311", "equip_shank_r", "equip_shank_r/equip_shank_r_311" }, 100));
		_dataArray.Add(new ArmorItem(228, LocalStringManager.GetConfig("Armor_language", "Name_228"), 1, 103, 3, 225, "icon_Armor_baguaxie", LocalStringManager.GetConfig("Armor_language", "Desc_228"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_228"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 80, 4500, 2, 8, 3000, 6, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 30, isSpecial: false, 4, 36, 144, new List<int>(), 5, -1, 1796, 210, 510, new List<PropertyAndValue>
		{
			new PropertyAndValue(4, 35),
			new PropertyAndValue(5, 35)
		}, new HitOrAvoidShorts(0, 25, 0, 0), new OuterAndInnerShorts(0, 50), new OuterAndInnerShorts(0, 0), 375, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_315", "equip_shank_r", "equip_shank_r/equip_shank_r_315" }, 100));
		_dataArray.Add(new ArmorItem(229, LocalStringManager.GetConfig("Armor_language", "Name_229"), 1, 103, 4, 225, "icon_Armor_niejing", LocalStringManager.GetConfig("Armor_language", "Desc_229"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_229"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 80, 9300, 3, 10, 4200, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 25, isSpecial: false, 4, 36, 144, new List<int>(), 5, -1, 1796, 225, 545, new List<PropertyAndValue>
		{
			new PropertyAndValue(4, 40),
			new PropertyAndValue(5, 40)
		}, new HitOrAvoidShorts(0, 25, 0, 0), new OuterAndInnerShorts(0, 60), new OuterAndInnerShorts(0, 0), 376, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_315", "equip_shank_r", "equip_shank_r/equip_shank_r_315" }, 100));
		_dataArray.Add(new ArmorItem(230, LocalStringManager.GetConfig("Armor_language", "Name_230"), 1, 103, 5, 225, "icon_Armor_ninghonglu", LocalStringManager.GetConfig("Armor_language", "Desc_230"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_230"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 80, 16800, 4, 12, 5400, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 20, isSpecial: false, 4, 36, 144, new List<int>(), 5, -1, 1796, 240, 580, new List<PropertyAndValue>
		{
			new PropertyAndValue(4, 45),
			new PropertyAndValue(5, 45)
		}, new HitOrAvoidShorts(0, 25, 0, 0), new OuterAndInnerShorts(0, 70), new OuterAndInnerShorts(0, 0), 377, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_315", "equip_shank_r", "equip_shank_r/equip_shank_r_315" }, 100));
		_dataArray.Add(new ArmorItem(231, LocalStringManager.GetConfig("Armor_language", "Name_231"), 1, 103, 6, 225, "icon_Armor_taqiankun", LocalStringManager.GetConfig("Armor_language", "Desc_231"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_231"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 80, 27600, 5, 14, 7200, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 15, isSpecial: false, 4, 36, 144, new List<int>(), 5, -1, 1796, 250, 610, new List<PropertyAndValue>
		{
			new PropertyAndValue(4, 50),
			new PropertyAndValue(5, 50)
		}, new HitOrAvoidShorts(0, 30, 0, 0), new OuterAndInnerShorts(0, 80), new OuterAndInnerShorts(0, 0), 378, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_319", "equip_shank_r", "equip_shank_r/equip_shank_r_319" }, 100));
		_dataArray.Add(new ArmorItem(232, LocalStringManager.GetConfig("Armor_language", "Name_232"), 1, 103, 7, 225, "icon_Armor_xianfulu", LocalStringManager.GetConfig("Armor_language", "Desc_232"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_232"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 80, 42300, 6, 16, 9000, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 10, isSpecial: false, 4, 36, 144, new List<int>(), 5, -1, 1796, 265, 645, new List<PropertyAndValue>
		{
			new PropertyAndValue(4, 55),
			new PropertyAndValue(5, 55)
		}, new HitOrAvoidShorts(0, 30, 0, 0), new OuterAndInnerShorts(0, 90), new OuterAndInnerShorts(0, 0), 379, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_319", "equip_shank_r", "equip_shank_r/equip_shank_r_319" }, 100));
		_dataArray.Add(new ArmorItem(233, LocalStringManager.GetConfig("Armor_language", "Name_233"), 1, 103, 8, 225, "icon_Armor_xuandoubaoxue", LocalStringManager.GetConfig("Armor_language", "Desc_233"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_233"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 80, 61500, 6, 18, 10800, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 5, isSpecial: false, 4, 36, 144, new List<int>(), 5, -1, 1796, 280, 680, new List<PropertyAndValue>
		{
			new PropertyAndValue(4, 60),
			new PropertyAndValue(5, 60)
		}, new HitOrAvoidShorts(0, 30, 0, 0), new OuterAndInnerShorts(0, 100), new OuterAndInnerShorts(0, 0), 380, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_319", "equip_shank_r", "equip_shank_r/equip_shank_r_319" }, 100));
		_dataArray.Add(new ArmorItem(234, LocalStringManager.GetConfig("Armor_language", "Name_234"), 1, 103, 0, 234, "icon_Armor_wuliangzudang", LocalStringManager.GetConfig("Armor_language", "Desc_234"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_234"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 80, 140, 300, 0, 2, 600, 3, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 45, isSpecial: false, 3, 36, 134, new List<int>(), 5, -1, 1795, 480, 480, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 30),
			new PropertyAndValue(3, 30)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(40, 5), new OuterAndInnerShorts(0, 0), 309, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_411", "equip_shank_r", "equip_shank_r/equip_shank_r_411" }, 100));
		_dataArray.Add(new ArmorItem(235, LocalStringManager.GetConfig("Armor_language", "Name_235"), 1, 103, 1, 234, "icon_Armor_jiguanlu", LocalStringManager.GetConfig("Armor_language", "Desc_235"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_235"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 80, 175, 600, 0, 4, 1200, 4, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 40, isSpecial: false, 3, 36, 134, new List<int>(), 5, -1, 1795, 535, 535, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 35),
			new PropertyAndValue(3, 35)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(50, 10), new OuterAndInnerShorts(0, 0), 310, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_411", "equip_shank_r", "equip_shank_r/equip_shank_r_411" }, 100));
		_dataArray.Add(new ArmorItem(236, LocalStringManager.GetConfig("Armor_language", "Name_236"), 1, 103, 2, 234, "icon_Armor_dishazu", LocalStringManager.GetConfig("Armor_language", "Desc_236"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_236"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 80, 210, 1800, 1, 6, 1800, 5, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 35, isSpecial: false, 3, 36, 134, new List<int>(), 5, -1, 1795, 595, 595, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 40),
			new PropertyAndValue(3, 40)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(60, 15), new OuterAndInnerShorts(10, 0), 311, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_411", "equip_shank_r", "equip_shank_r/equip_shank_r_411" }, 100));
		_dataArray.Add(new ArmorItem(237, LocalStringManager.GetConfig("Armor_language", "Name_237"), 1, 103, 3, 234, "icon_Armor_luochazudang", LocalStringManager.GetConfig("Armor_language", "Desc_237"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_237"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 80, 245, 4500, 2, 8, 3000, 6, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 30, isSpecial: false, 3, 36, 134, new List<int>(), 5, -1, 1795, 655, 655, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 45),
			new PropertyAndValue(3, 45)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(70, 20), new OuterAndInnerShorts(10, 0), 312, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_415", "equip_shank_r", "equip_shank_r/equip_shank_r_415" }, 100));
		_dataArray.Add(new ArmorItem(238, LocalStringManager.GetConfig("Armor_language", "Name_238"), 1, 103, 4, 234, "icon_Armor_baibaolu", LocalStringManager.GetConfig("Armor_language", "Desc_238"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_238"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 80, 280, 9300, 3, 10, 4200, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 25, isSpecial: false, 3, 36, 134, new List<int>(), 5, -1, 1795, 720, 720, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 50),
			new PropertyAndValue(3, 50)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(80, 25), new OuterAndInnerShorts(15, 0), 313, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_415", "equip_shank_r", "equip_shank_r/equip_shank_r_415" }, 100));
		_dataArray.Add(new ArmorItem(239, LocalStringManager.GetConfig("Armor_language", "Name_239"), 1, 103, 5, 234, "icon_Armor_xingyiliuguang", LocalStringManager.GetConfig("Armor_language", "Desc_239"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_239"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 80, 315, 16800, 4, 12, 5400, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 20, isSpecial: false, 3, 36, 134, new List<int>(), 5, -1, 1795, 780, 780, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 55),
			new PropertyAndValue(3, 55)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(90, 30), new OuterAndInnerShorts(20, 10), 314, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_415", "equip_shank_r", "equip_shank_r/equip_shank_r_415" }, 100));
	}

	private void CreateItems4()
	{
		_dataArray.Add(new ArmorItem(240, LocalStringManager.GetConfig("Armor_language", "Name_240"), 1, 103, 6, 234, "icon_Armor_longjingzudang", LocalStringManager.GetConfig("Armor_language", "Desc_240"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_240"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 80, 350, 27600, 5, 14, 7200, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 15, isSpecial: false, 3, 36, 134, new List<int>(), 5, -1, 1795, 855, 855, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 60),
			new PropertyAndValue(3, 60)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(100, 35), new OuterAndInnerShorts(20, 10), 315, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_419", "equip_shank_r", "equip_shank_r/equip_shank_r_419" }, 100));
		_dataArray.Add(new ArmorItem(241, LocalStringManager.GetConfig("Armor_language", "Name_241"), 1, 103, 7, 234, "icon_Armor_sanbaodian", LocalStringManager.GetConfig("Armor_language", "Desc_241"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_241"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 80, 385, 42300, 6, 16, 9000, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 10, isSpecial: false, 3, 36, 134, new List<int>(), 5, -1, 1795, 920, 920, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 65),
			new PropertyAndValue(3, 65)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(110, 40), new OuterAndInnerShorts(25, 15), 316, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_419", "equip_shank_r", "equip_shank_r/equip_shank_r_419" }, 100));
		_dataArray.Add(new ArmorItem(242, LocalStringManager.GetConfig("Armor_language", "Name_242"), 1, 103, 8, 234, "icon_Armor_jiuxinglu", LocalStringManager.GetConfig("Armor_language", "Desc_242"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_242"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 80, 420, 61500, 6, 18, 10800, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 5, isSpecial: false, 3, 36, 134, new List<int>(), 5, -1, 1795, 1000, 1000, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 70),
			new PropertyAndValue(3, 70)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(120, 45), new OuterAndInnerShorts(30, 20), 317, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_419", "equip_shank_r", "equip_shank_r/equip_shank_r_419" }, 100));
		_dataArray.Add(new ArmorItem(243, LocalStringManager.GetConfig("Armor_language", "Name_243"), 1, 103, 0, 243, "icon_Armor_shuiyuzuhuan", LocalStringManager.GetConfig("Armor_language", "Desc_243"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_243"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 80, 80, 300, 0, 2, 600, 3, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 45, isSpecial: false, 3, 36, 141, new List<int>(), 5, -1, 1795, 515, 395, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 30),
			new PropertyAndValue(4, 30)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(5, 40), new OuterAndInnerShorts(0, 0), 318, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_431", "equip_shank_r", "equip_shank_r/equip_shank_r_431" }, 100));
		_dataArray.Add(new ArmorItem(244, LocalStringManager.GetConfig("Armor_language", "Name_244"), 1, 103, 1, 243, "icon_Armor_cuijingzu", LocalStringManager.GetConfig("Armor_language", "Desc_244"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_244"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 80, 110, 600, 0, 4, 1200, 4, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 40, isSpecial: false, 3, 36, 141, new List<int>(), 5, -1, 1795, 570, 440, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 35),
			new PropertyAndValue(4, 35)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(10, 50), new OuterAndInnerShorts(0, 0), 319, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_431", "equip_shank_r", "equip_shank_r/equip_shank_r_431" }, 100));
		_dataArray.Add(new ArmorItem(245, LocalStringManager.GetConfig("Armor_language", "Name_245"), 1, 103, 2, 243, "icon_Armor_yurongxie", LocalStringManager.GetConfig("Armor_language", "Desc_245"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_245"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 80, 140, 1800, 1, 6, 1800, 5, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 35, isSpecial: false, 3, 36, 141, new List<int>(), 5, -1, 1795, 630, 490, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 40),
			new PropertyAndValue(4, 40)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(15, 60), new OuterAndInnerShorts(0, 10), 320, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_431", "equip_shank_r", "equip_shank_r/equip_shank_r_431" }, 100));
		_dataArray.Add(new ArmorItem(246, LocalStringManager.GetConfig("Armor_language", "Name_246"), 1, 103, 3, 243, "icon_Armor_lingchiqingjing", LocalStringManager.GetConfig("Armor_language", "Desc_246"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_246"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 80, 165, 4500, 2, 8, 3000, 6, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 30, isSpecial: false, 3, 36, 141, new List<int>(), 5, -1, 1795, 690, 540, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 45),
			new PropertyAndValue(4, 45)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(20, 70), new OuterAndInnerShorts(0, 10), 321, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_435", "equip_shank_r", "equip_shank_r/equip_shank_r_435" }, 100));
		_dataArray.Add(new ArmorItem(247, LocalStringManager.GetConfig("Armor_language", "Name_247"), 1, 103, 4, 243, "icon_Armor_zuixianzulang", LocalStringManager.GetConfig("Armor_language", "Desc_247"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_247"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 80, 195, 9300, 3, 10, 4200, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 25, isSpecial: false, 3, 36, 141, new List<int>(), 5, -1, 1795, 750, 590, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 50),
			new PropertyAndValue(4, 50)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(25, 80), new OuterAndInnerShorts(0, 15), 322, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_435", "equip_shank_r", "equip_shank_r/equip_shank_r_435" }, 100));
		_dataArray.Add(new ArmorItem(248, LocalStringManager.GetConfig("Armor_language", "Name_248"), 1, 103, 5, 243, "icon_Armor_xuanguangyingyue", LocalStringManager.GetConfig("Armor_language", "Desc_248"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_248"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 80, 220, 16800, 4, 12, 5400, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 20, isSpecial: false, 3, 36, 141, new List<int>(), 5, -1, 1795, 815, 645, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 55),
			new PropertyAndValue(4, 55)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(30, 90), new OuterAndInnerShorts(10, 20), 323, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_435", "equip_shank_r", "equip_shank_r/equip_shank_r_435" }, 100));
		_dataArray.Add(new ArmorItem(249, LocalStringManager.GetConfig("Armor_language", "Name_249"), 1, 103, 6, 243, "icon_Armor_liantaibingzu", LocalStringManager.GetConfig("Armor_language", "Desc_249"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_249"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 80, 250, 27600, 5, 14, 7200, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 15, isSpecial: false, 3, 36, 141, new List<int>(), 5, -1, 1795, 880, 700, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 60),
			new PropertyAndValue(4, 60)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(35, 100), new OuterAndInnerShorts(10, 20), 324, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_439", "equip_shank_r", "equip_shank_r/equip_shank_r_439" }, 100));
		_dataArray.Add(new ArmorItem(250, LocalStringManager.GetConfig("Armor_language", "Name_250"), 1, 103, 7, 243, "icon_Armor_panlixue", LocalStringManager.GetConfig("Armor_language", "Desc_250"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_250"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 80, 280, 42300, 6, 16, 9000, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 10, isSpecial: false, 3, 36, 141, new List<int>(), 5, -1, 1795, 950, 760, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 65),
			new PropertyAndValue(4, 65)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(40, 110), new OuterAndInnerShorts(15, 25), 325, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_439", "equip_shank_r", "equip_shank_r/equip_shank_r_439" }, 100));
		_dataArray.Add(new ArmorItem(251, LocalStringManager.GetConfig("Armor_language", "Name_251"), 1, 103, 8, 243, "icon_Armor_kunlunzu", LocalStringManager.GetConfig("Armor_language", "Desc_251"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_251"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 80, 305, 61500, 6, 18, 10800, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 5, isSpecial: false, 3, 36, 141, new List<int>(), 5, -1, 1795, 1020, 820, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 70),
			new PropertyAndValue(4, 70)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(45, 120), new OuterAndInnerShorts(20, 30), 326, new List<string> { "equip_shank_l", "equip_shank_l/equip_shank_l_439", "equip_shank_r", "equip_shank_r/equip_shank_r_439" }, 100));
		_dataArray.Add(new ArmorItem(252, LocalStringManager.GetConfig("Armor_language", "Name_252"), 1, 101, 0, 252, "icon_Armor_tiezhajia", LocalStringManager.GetConfig("Armor_language", "Desc_252"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_252"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 1050, 300, 0, 2, 600, 3, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 45, isSpecial: false, 2, 36, 146, new List<int>(), 3, -1, 1793, 1080, 840, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 80)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(40, 0), new OuterAndInnerShorts(10, 0), -1, new List<string> { "equip_arm_l/equip_arm_l", "equip_arm_l/equip_arm_l_131", "equip_bw_l/equip_bw_l", "equip_bw_l/equip_bw_l_131", "equip_bw_r/equip_bw_r", "equip_bw_r/equip_bw_r_131" }, 100));
		_dataArray.Add(new ArmorItem(253, LocalStringManager.GetConfig("Armor_language", "Name_253"), 1, 101, 1, 252, "icon_Armor_burenjia", LocalStringManager.GetConfig("Armor_language", "Desc_253"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_253"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 1200, 600, 0, 4, 1200, 4, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 40, isSpecial: false, 2, 36, 146, new List<int>(), 3, -1, 1793, 1235, 975, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 85)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(50, 0), new OuterAndInnerShorts(10, 0), -1, new List<string> { "equip_arm_l/equip_arm_l", "equip_arm_l/equip_arm_l_131", "equip_bw_l/equip_bw_l", "equip_bw_l/equip_bw_l_131", "equip_bw_r/equip_bw_r", "equip_bw_r/equip_bw_r_131" }, 100));
		_dataArray.Add(new ArmorItem(254, LocalStringManager.GetConfig("Armor_language", "Name_254"), 1, 101, 2, 252, "icon_Armor_liangdangtiekai", LocalStringManager.GetConfig("Armor_language", "Desc_254"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_254"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 1350, 1800, 1, 6, 1800, 5, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 35, isSpecial: false, 2, 36, 146, new List<int>(), 3, -1, 1793, 1400, 1120, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 90)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(60, 0), new OuterAndInnerShorts(15, 0), -1, new List<string> { "equip_arm_l/equip_arm_l", "equip_arm_l/equip_arm_l_131", "equip_bw_l/equip_bw_l", "equip_bw_l/equip_bw_l_131", "equip_bw_r/equip_bw_r", "equip_bw_r/equip_bw_r_131" }, 100));
		_dataArray.Add(new ArmorItem(255, LocalStringManager.GetConfig("Armor_language", "Name_255"), 1, 101, 3, 252, "icon_Armor_tongxiukai", LocalStringManager.GetConfig("Armor_language", "Desc_255"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_255"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 1500, 4500, 2, 8, 3000, 6, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 30, isSpecial: false, 2, 36, 146, new List<int>(), 3, -1, 1793, 1575, 1275, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 95)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(70, 0), new OuterAndInnerShorts(20, 0), -1, new List<string> { "collar/collar", "collar/collar_135", "equip_arm_l/equip_arm_l", "equip_arm_l/equip_arm_l_135", "equip_arm_r/equip_arm_r", "equip_arm_r/equip_arm_r_135", "equip_bw_l/equip_bw_l", "equip_bw_l/equip_bw_l_135", "equip_bw_r/equip_bw_r", "equip_bw_r/equip_bw_r_135" }, 100));
		_dataArray.Add(new ArmorItem(256, LocalStringManager.GetConfig("Armor_language", "Name_256"), 1, 101, 4, 252, "icon_Armor_wuzhegangkai", LocalStringManager.GetConfig("Armor_language", "Desc_256"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_256"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 1650, 9300, 3, 10, 4200, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 25, isSpecial: false, 2, 36, 146, new List<int>(), 3, -1, 1793, 1760, 1440, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 100)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(80, 0), new OuterAndInnerShorts(20, 0), -1, new List<string> { "collar/collar", "collar/collar_135", "equip_arm_l/equip_arm_l", "equip_arm_l/equip_arm_l_135", "equip_arm_r/equip_arm_r", "equip_arm_r/equip_arm_r_135", "equip_bw_l/equip_bw_l", "equip_bw_l/equip_bw_l_135", "equip_bw_r/equip_bw_r", "equip_bw_r/equip_bw_r_135" }, 100));
		_dataArray.Add(new ArmorItem(257, LocalStringManager.GetConfig("Armor_language", "Name_257"), 1, 101, 5, 252, "icon_Armor_mingguangkai", LocalStringManager.GetConfig("Armor_language", "Desc_257"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_257"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 1800, 16800, 4, 12, 5400, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 20, isSpecial: false, 2, 36, 146, new List<int>(), 3, -1, 1793, 1955, 1615, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 105)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(90, 0), new OuterAndInnerShorts(25, 0), -1, new List<string> { "collar/collar", "collar/collar_135", "equip_arm_l/equip_arm_l", "equip_arm_l/equip_arm_l_135", "equip_arm_r/equip_arm_r", "equip_arm_r/equip_arm_r_135", "equip_bw_l/equip_bw_l", "equip_bw_l/equip_bw_l_135", "equip_bw_r/equip_bw_r", "equip_bw_r/equip_bw_r_135" }, 100));
		_dataArray.Add(new ArmorItem(258, LocalStringManager.GetConfig("Armor_language", "Name_258"), 1, 101, 6, 252, "icon_Armor_bawangkai", LocalStringManager.GetConfig("Armor_language", "Desc_258"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_258"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 1950, 27600, 5, 14, 7200, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 15, isSpecial: false, 2, 36, 146, new List<int>(), 3, -1, 1793, 2160, 1800, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 110)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(100, 0), new OuterAndInnerShorts(30, 0), -1, new List<string>
		{
			"collar/collar", "collar/collar_139", "equip_arm_l/equip_arm_l", "equip_arm_l/equip_arm_l_139", "equip_arm_r/equip_arm_r", "equip_arm_r/equip_arm_r_139", "equip_bw_l/equip_bw_l", "equip_bw_l/equip_bw_l_139", "equip_bw_r/equip_bw_r", "equip_bw_r/equip_bw_r_139",
			"equip_waist/equip_waist", "equip_waist/equip_waist_139", "equip_leg_l/equip_leg_l", "equip_leg_l/equip_leg_l_139", "equip_leg_r/equip_leg_r", "equip_leg_r/equip_leg_r_139"
		}, 100));
		_dataArray.Add(new ArmorItem(259, LocalStringManager.GetConfig("Armor_language", "Name_259"), 1, 101, 7, 252, "icon_Armor_baihuangwusekai", LocalStringManager.GetConfig("Armor_language", "Desc_259"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_259"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 2100, 42300, 6, 16, 9000, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 10, isSpecial: false, 2, 36, 146, new List<int>(), 3, -1, 1793, 2375, 1995, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 115)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(110, 0), new OuterAndInnerShorts(30, 0), -1, new List<string>
		{
			"collar/collar", "collar/collar_139", "equip_arm_l/equip_arm_l", "equip_arm_l/equip_arm_l_139", "equip_arm_r/equip_arm_r", "equip_arm_r/equip_arm_r_139", "equip_bw_l/equip_bw_l", "equip_bw_l/equip_bw_l_139", "equip_bw_r/equip_bw_r", "equip_bw_r/equip_bw_r_139",
			"equip_waist/equip_waist", "equip_waist/equip_waist_139", "equip_leg_l/equip_leg_l", "equip_leg_l/equip_leg_l_139", "equip_leg_r/equip_leg_r", "equip_leg_r/equip_leg_r_139"
		}, 100));
		_dataArray.Add(new ArmorItem(260, LocalStringManager.GetConfig("Armor_language", "Name_260"), 1, 101, 8, 252, "icon_Armor_qingxuanbaokai", LocalStringManager.GetConfig("Armor_language", "Desc_260"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_260"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 2250, 61500, 6, 18, 10800, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 5, isSpecial: false, 2, 36, 146, new List<int>(), 3, -1, 1793, 2600, 2200, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 120)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(120, 0), new OuterAndInnerShorts(35, 0), -1, new List<string>
		{
			"collar/collar", "collar/collar_139", "equip_arm_l/equip_arm_l", "equip_arm_l/equip_arm_l_139", "equip_arm_r/equip_arm_r", "equip_arm_r/equip_arm_r_139", "equip_bw_l/equip_bw_l", "equip_bw_l/equip_bw_l_139", "equip_bw_r/equip_bw_r", "equip_bw_r/equip_bw_r_139",
			"equip_waist/equip_waist", "equip_waist/equip_waist_139", "equip_leg_l/equip_leg_l", "equip_leg_l/equip_leg_l_139", "equip_leg_r/equip_leg_r", "equip_leg_r/equip_leg_r_139"
		}, 100));
		_dataArray.Add(new ArmorItem(261, LocalStringManager.GetConfig("Armor_language", "Name_261"), 1, 101, 0, 261, "icon_Armor_huxinduankai", LocalStringManager.GetConfig("Armor_language", "Desc_261"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_261"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 945, 300, 0, 2, 600, 3, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 45, isSpecial: false, 2, 36, 147, new List<int>(), 3, -1, 1793, 920, 920, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 70)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(40, 20), new OuterAndInnerShorts(0, 0), -1, new List<string> { "equip_arm_l/equip_arm_l", "equip_arm_l/equip_arm_l_111", "equip_arm_r/equip_arm_r", "equip_arm_r/equip_arm_r_111", "equip_bw_l/equip_bw_l", "equip_bw_l/equip_bw_l_111", "equip_bw_r/equip_bw_r", "equip_bw_r/equip_bw_r_111" }, 100));
		_dataArray.Add(new ArmorItem(262, LocalStringManager.GetConfig("Armor_language", "Name_262"), 1, 101, 1, 261, "icon_Armor_huansuoduankai", LocalStringManager.GetConfig("Armor_language", "Desc_262"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_262"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 1080, 600, 0, 4, 1200, 4, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 40, isSpecial: false, 2, 36, 147, new List<int>(), 3, -1, 1793, 1055, 1055, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 75)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(50, 25), new OuterAndInnerShorts(0, 0), -1, new List<string> { "equip_arm_l/equip_arm_l", "equip_arm_l/equip_arm_l_111", "equip_arm_r/equip_arm_r", "equip_arm_r/equip_arm_r_111", "equip_bw_l/equip_bw_l", "equip_bw_l/equip_bw_l_111", "equip_bw_r/equip_bw_r", "equip_bw_r/equip_bw_r_111" }, 100));
		_dataArray.Add(new ArmorItem(263, LocalStringManager.GetConfig("Armor_language", "Name_263"), 1, 101, 2, 261, "icon_Armor_yulinkai", LocalStringManager.GetConfig("Armor_language", "Desc_263"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_263"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 1215, 1800, 1, 6, 1800, 5, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 35, isSpecial: false, 2, 36, 147, new List<int>(), 3, -1, 1793, 1195, 1195, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 80)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(60, 30), new OuterAndInnerShorts(10, 0), -1, new List<string> { "equip_arm_l/equip_arm_l", "equip_arm_l/equip_arm_l_111", "equip_arm_r/equip_arm_r", "equip_arm_r/equip_arm_r_111", "equip_bw_l/equip_bw_l", "equip_bw_l/equip_bw_l_111", "equip_bw_r/equip_bw_r", "equip_bw_r/equip_bw_r_111" }, 100));
		_dataArray.Add(new ArmorItem(264, LocalStringManager.GetConfig("Armor_language", "Name_264"), 1, 101, 3, 261, "icon_Armor_yanlingjia", LocalStringManager.GetConfig("Armor_language", "Desc_264"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_264"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 1350, 4500, 2, 8, 3000, 6, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 30, isSpecial: false, 2, 36, 147, new List<int>(), 3, -1, 1793, 1350, 1350, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 85)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(70, 35), new OuterAndInnerShorts(10, 0), -1, new List<string> { "collar/collar", "collar/collar_115", "equip_arm_l/equip_arm_l", "equip_arm_l/equip_arm_l_115", "equip_arm_r/equip_arm_r", "equip_arm_r/equip_arm_r_115", "equip_bw_l/equip_bw_l", "equip_bw_l/equip_bw_l_115", "equip_bw_r/equip_bw_r", "equip_bw_r/equip_bw_r_115" }, 100));
		_dataArray.Add(new ArmorItem(265, LocalStringManager.GetConfig("Armor_language", "Name_265"), 1, 101, 4, 261, "icon_Armor_wuchuikai", LocalStringManager.GetConfig("Armor_language", "Desc_265"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_265"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 1485, 9300, 3, 10, 4200, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 25, isSpecial: false, 2, 36, 147, new List<int>(), 3, -1, 1793, 1510, 1510, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 90)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(80, 40), new OuterAndInnerShorts(15, 0), -1, new List<string> { "collar/collar", "collar/collar_115", "equip_arm_l/equip_arm_l", "equip_arm_l/equip_arm_l_115", "equip_arm_r/equip_arm_r", "equip_arm_r/equip_arm_r_115", "equip_bw_l/equip_bw_l", "equip_bw_l/equip_bw_l_115", "equip_bw_r/equip_bw_r", "equip_bw_r/equip_bw_r_115" }, 100));
		_dataArray.Add(new ArmorItem(266, LocalStringManager.GetConfig("Armor_language", "Name_266"), 1, 101, 5, 261, "icon_Armor_liuhejinwujia", LocalStringManager.GetConfig("Armor_language", "Desc_266"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_266"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 1620, 16800, 4, 12, 5400, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 20, isSpecial: false, 2, 36, 147, new List<int>(), 3, -1, 1793, 1685, 1685, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 95)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(90, 45), new OuterAndInnerShorts(20, 10), -1, new List<string> { "collar/collar", "collar/collar_115", "equip_arm_l/equip_arm_l", "equip_arm_l/equip_arm_l_115", "equip_arm_r/equip_arm_r", "equip_arm_r/equip_arm_r_115", "equip_bw_l/equip_bw_l", "equip_bw_l/equip_bw_l_115", "equip_bw_r/equip_bw_r", "equip_bw_r/equip_bw_r_115" }, 100));
		_dataArray.Add(new ArmorItem(267, LocalStringManager.GetConfig("Armor_language", "Name_267"), 1, 101, 6, 261, "icon_Armor_tianwangjia", LocalStringManager.GetConfig("Armor_language", "Desc_267"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_267"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 1755, 27600, 5, 14, 7200, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 15, isSpecial: false, 2, 36, 147, new List<int>(), 3, -1, 1793, 1865, 1865, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 100)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(100, 50), new OuterAndInnerShorts(20, 10), -1, new List<string>
		{
			"collar/collar", "collar/collar_119", "equip_arm_l/equip_arm_l", "equip_arm_l/equip_arm_l_119", "equip_arm_r/equip_arm_r", "equip_arm_r/equip_arm_r_119", "equip_bw_l/equip_bw_l", "equip_bw_l/equip_bw_l_119", "equip_bw_r/equip_bw_r", "equip_bw_r/equip_bw_r_119",
			"equip_waist/equip_waist", "equip_waist/equip_waist_119", "equip_leg_l/equip_leg_l", "equip_leg_l/equip_leg_l_119", "equip_leg_r/equip_leg_r", "equip_leg_r/equip_leg_r_119"
		}, 100));
		_dataArray.Add(new ArmorItem(268, LocalStringManager.GetConfig("Armor_language", "Name_268"), 1, 101, 7, 261, "icon_Armor_guibeituolongjia", LocalStringManager.GetConfig("Armor_language", "Desc_268"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_268"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 1890, 42300, 6, 16, 9000, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 10, isSpecial: false, 2, 36, 147, new List<int>(), 3, -1, 1793, 2050, 2050, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 105)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(110, 55), new OuterAndInnerShorts(25, 15), -1, new List<string>
		{
			"collar/collar", "collar/collar_119", "equip_arm_l/equip_arm_l", "equip_arm_l/equip_arm_l_119", "equip_arm_r/equip_arm_r", "equip_arm_r/equip_arm_r_119", "equip_bw_l/equip_bw_l", "equip_bw_l/equip_bw_l_119", "equip_bw_r/equip_bw_r", "equip_bw_r/equip_bw_r_119",
			"equip_waist/equip_waist", "equip_waist/equip_waist_119", "equip_leg_l/equip_leg_l", "equip_leg_l/equip_leg_l_119", "equip_leg_r/equip_leg_r", "equip_leg_r/equip_leg_r_119"
		}, 100));
		_dataArray.Add(new ArmorItem(269, LocalStringManager.GetConfig("Armor_language", "Name_269"), 1, 101, 8, 261, "icon_Armor_niniujia", LocalStringManager.GetConfig("Armor_language", "Desc_269"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_269"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 2025, 61500, 6, 18, 10800, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 5, isSpecial: false, 2, 36, 147, new List<int>(), 3, -1, 1793, 2250, 2250, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 110)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(120, 60), new OuterAndInnerShorts(30, 20), -1, new List<string>
		{
			"collar/collar", "collar/collar_119", "equip_arm_l/equip_arm_l", "equip_arm_l/equip_arm_l_119", "equip_arm_r/equip_arm_r", "equip_arm_r/equip_arm_r_119", "equip_bw_l/equip_bw_l", "equip_bw_l/equip_bw_l_119", "equip_bw_r/equip_bw_r", "equip_bw_r/equip_bw_r_119",
			"equip_waist/equip_waist", "equip_waist/equip_waist_119", "equip_leg_l/equip_leg_l", "equip_leg_l/equip_leg_l_119", "equip_leg_r/equip_leg_r", "equip_leg_r/equip_leg_r_119"
		}, 100));
		_dataArray.Add(new ArmorItem(270, LocalStringManager.GetConfig("Armor_language", "Name_270"), 1, 101, 0, 270, "icon_Armor_yuantongyi", LocalStringManager.GetConfig("Armor_language", "Desc_270"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_270"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 840, 300, 0, 2, 600, 3, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 45, isSpecial: false, 2, 36, 154, new List<int>(), 3, -1, 1793, 755, 995, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 80)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(20, 20), new OuterAndInnerShorts(0, 0), -1, new List<string> { "equip_arm_l/equip_arm_l", "equip_arm_l/equip_arm_l_131", "equip_bw_l/equip_bw_l", "equip_bw_l/equip_bw_l_131", "equip_bw_r/equip_bw_r", "equip_bw_r/equip_bw_r_131" }, 100));
		_dataArray.Add(new ArmorItem(271, LocalStringManager.GetConfig("Armor_language", "Name_271"), 1, 101, 1, 270, "icon_Armor_dayejia", LocalStringManager.GetConfig("Armor_language", "Desc_271"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_271"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 960, 600, 0, 4, 1200, 4, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 40, isSpecial: false, 2, 36, 154, new List<int>(), 3, -1, 1793, 870, 1130, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 85)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(30, 30), new OuterAndInnerShorts(0, 0), -1, new List<string> { "equip_arm_l/equip_arm_l", "equip_arm_l/equip_arm_l_131", "equip_bw_l/equip_bw_l", "equip_bw_l/equip_bw_l_131", "equip_bw_r/equip_bw_r", "equip_bw_r/equip_bw_r_131" }, 100));
		_dataArray.Add(new ArmorItem(272, LocalStringManager.GetConfig("Armor_language", "Name_272"), 1, 101, 2, 270, "icon_Armor_cunjinruanyi", LocalStringManager.GetConfig("Armor_language", "Desc_272"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_272"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 1080, 1800, 1, 6, 1800, 5, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 35, isSpecial: false, 2, 36, 154, new List<int>(), 3, -1, 1793, 995, 1275, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 90)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(40, 40), new OuterAndInnerShorts(0, 0), -1, new List<string> { "equip_arm_l/equip_arm_l", "equip_arm_l/equip_arm_l_131", "equip_bw_l/equip_bw_l", "equip_bw_l/equip_bw_l_131", "equip_bw_r/equip_bw_r", "equip_bw_r/equip_bw_r_131" }, 100));
		_dataArray.Add(new ArmorItem(273, LocalStringManager.GetConfig("Armor_language", "Name_273"), 1, 101, 3, 270, "icon_Armor_juanyunhuangjia", LocalStringManager.GetConfig("Armor_language", "Desc_273"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_273"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 1200, 4500, 2, 8, 3000, 6, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 30, isSpecial: false, 2, 36, 154, new List<int>(), 3, -1, 1793, 1125, 1425, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 95)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(50, 50), new OuterAndInnerShorts(10, 10), -1, new List<string> { "collar/collar", "collar/collar_135", "equip_arm_l/equip_arm_l", "equip_arm_l/equip_arm_l_135", "equip_arm_r/equip_arm_r", "equip_arm_r/equip_arm_r_135", "equip_bw_l/equip_bw_l", "equip_bw_l/equip_bw_l_135", "equip_bw_r/equip_bw_r", "equip_bw_r/equip_bw_r_135" }, 100));
		_dataArray.Add(new ArmorItem(274, LocalStringManager.GetConfig("Armor_language", "Name_274"), 1, 101, 4, 270, "icon_Armor_chijinkai", LocalStringManager.GetConfig("Armor_language", "Desc_274"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_274"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 1320, 9300, 3, 10, 4200, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 25, isSpecial: false, 2, 36, 154, new List<int>(), 3, -1, 1793, 1265, 1585, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 100)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(60, 60), new OuterAndInnerShorts(10, 10), -1, new List<string> { "collar/collar", "collar/collar_135", "equip_arm_l/equip_arm_l", "equip_arm_l/equip_arm_l_135", "equip_arm_r/equip_arm_r", "equip_arm_r/equip_arm_r_135", "equip_bw_l/equip_bw_l", "equip_bw_l/equip_bw_l_135", "equip_bw_r/equip_bw_r", "equip_bw_r/equip_bw_r_135" }, 100));
		_dataArray.Add(new ArmorItem(275, LocalStringManager.GetConfig("Armor_language", "Name_275"), 1, 101, 5, 270, "icon_Armor_huanglongyanxinyi", LocalStringManager.GetConfig("Armor_language", "Desc_275"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_275"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 1440, 16800, 4, 12, 5400, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 20, isSpecial: false, 2, 36, 154, new List<int>(), 3, -1, 1793, 1410, 1750, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 105)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(70, 70), new OuterAndInnerShorts(15, 15), -1, new List<string> { "collar/collar", "collar/collar_135", "equip_arm_l/equip_arm_l", "equip_arm_l/equip_arm_l_135", "equip_arm_r/equip_arm_r", "equip_arm_r/equip_arm_r_135", "equip_bw_l/equip_bw_l", "equip_bw_l/equip_bw_l_135", "equip_bw_r/equip_bw_r", "equip_bw_r/equip_bw_r_135" }, 100));
		_dataArray.Add(new ArmorItem(276, LocalStringManager.GetConfig("Armor_language", "Name_276"), 1, 101, 6, 270, "icon_Armor_qiufuzhou", LocalStringManager.GetConfig("Armor_language", "Desc_276"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_276"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 1560, 27600, 5, 14, 7200, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 15, isSpecial: false, 2, 36, 154, new List<int>(), 3, -1, 1793, 1565, 1925, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 110)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(80, 80), new OuterAndInnerShorts(20, 20), -1, new List<string>
		{
			"collar/collar", "collar/collar_139", "equip_arm_l/equip_arm_l", "equip_arm_l/equip_arm_l_139", "equip_arm_r/equip_arm_r", "equip_arm_r/equip_arm_r_139", "equip_bw_l/equip_bw_l", "equip_bw_l/equip_bw_l_139", "equip_bw_r/equip_bw_r", "equip_bw_r/equip_bw_r_139",
			"equip_waist/equip_waist", "equip_waist/equip_waist_139", "equip_leg_l/equip_leg_l", "equip_leg_l/equip_leg_l_139", "equip_leg_r/equip_leg_r", "equip_leg_r/equip_leg_r_139"
		}, 100));
		_dataArray.Add(new ArmorItem(277, LocalStringManager.GetConfig("Armor_language", "Name_277"), 1, 101, 7, 270, "icon_Armor_xuanzhupao", LocalStringManager.GetConfig("Armor_language", "Desc_277"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_277"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 1680, 42300, 6, 16, 9000, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 10, isSpecial: false, 2, 36, 154, new List<int>(), 3, -1, 1793, 1730, 2110, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 115)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(90, 90), new OuterAndInnerShorts(20, 20), -1, new List<string>
		{
			"collar/collar", "collar/collar_139", "equip_arm_l/equip_arm_l", "equip_arm_l/equip_arm_l_139", "equip_arm_r/equip_arm_r", "equip_arm_r/equip_arm_r_139", "equip_bw_l/equip_bw_l", "equip_bw_l/equip_bw_l_139", "equip_bw_r/equip_bw_r", "equip_bw_r/equip_bw_r_139",
			"equip_waist/equip_waist", "equip_waist/equip_waist_139", "equip_leg_l/equip_leg_l", "equip_leg_l/equip_leg_l_139", "equip_leg_r/equip_leg_r", "equip_leg_r/equip_leg_r_139"
		}, 100));
		_dataArray.Add(new ArmorItem(278, LocalStringManager.GetConfig("Armor_language", "Name_278"), 1, 101, 8, 270, "icon_Armor_jinjianbaojia", LocalStringManager.GetConfig("Armor_language", "Desc_278"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_278"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 1800, 61500, 6, 18, 10800, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 5, isSpecial: false, 2, 36, 154, new List<int>(), 3, -1, 1793, 1900, 2300, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 120)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(100, 100), new OuterAndInnerShorts(25, 25), -1, new List<string>
		{
			"collar/collar", "collar/collar_139", "equip_arm_l/equip_arm_l", "equip_arm_l/equip_arm_l_139", "equip_arm_r/equip_arm_r", "equip_arm_r/equip_arm_r_139", "equip_bw_l/equip_bw_l", "equip_bw_l/equip_bw_l_139", "equip_bw_r/equip_bw_r", "equip_bw_r/equip_bw_r_139",
			"equip_waist/equip_waist", "equip_waist/equip_waist_139", "equip_leg_l/equip_leg_l", "equip_leg_l/equip_leg_l_139", "equip_leg_r/equip_leg_r", "equip_leg_r/equip_leg_r_139"
		}, 100));
		_dataArray.Add(new ArmorItem(279, LocalStringManager.GetConfig("Armor_language", "Name_279"), 1, 101, 0, 279, "icon_Armor_tongsuojia", LocalStringManager.GetConfig("Armor_language", "Desc_279"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_279"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 735, 300, 0, 2, 600, 3, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 45, isSpecial: false, 2, 36, 155, new List<int>(), 3, -1, 1793, 655, 1015, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 70)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(20, 40), new OuterAndInnerShorts(0, 0), -1, new List<string> { "equip_arm_r/equip_arm_r", "equip_arm_r/equip_arm_r_121", "equip_bw_l/equip_bw_l", "equip_bw_l/equip_bw_l_121", "equip_bw_r/equip_bw_r", "equip_bw_r/equip_bw_r_121" }, 100));
		_dataArray.Add(new ArmorItem(280, LocalStringManager.GetConfig("Armor_language", "Name_280"), 1, 101, 1, 279, "icon_Armor_lianhuanjia", LocalStringManager.GetConfig("Armor_language", "Desc_280"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_280"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 840, 600, 0, 4, 1200, 4, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 40, isSpecial: false, 2, 36, 155, new List<int>(), 3, -1, 1793, 755, 1145, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 75)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(25, 50), new OuterAndInnerShorts(0, 0), -1, new List<string> { "equip_arm_r/equip_arm_r", "equip_arm_r/equip_arm_r_121", "equip_bw_l/equip_bw_l", "equip_bw_l/equip_bw_l_121", "equip_bw_r/equip_bw_r", "equip_bw_r/equip_bw_r_121" }, 100));
		_dataArray.Add(new ArmorItem(281, LocalStringManager.GetConfig("Armor_language", "Name_281"), 1, 101, 2, 279, "icon_Armor_wucunkai", LocalStringManager.GetConfig("Armor_language", "Desc_281"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_281"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 945, 1800, 1, 6, 1800, 5, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 35, isSpecial: false, 2, 36, 155, new List<int>(), 3, -1, 1793, 860, 1280, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 80)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(30, 60), new OuterAndInnerShorts(0, 10), -1, new List<string> { "equip_arm_r/equip_arm_r", "equip_arm_r/equip_arm_r_121", "equip_bw_l/equip_bw_l", "equip_bw_l/equip_bw_l_121", "equip_bw_r/equip_bw_r", "equip_bw_r/equip_bw_r_121" }, 100));
		_dataArray.Add(new ArmorItem(282, LocalStringManager.GetConfig("Armor_language", "Name_282"), 1, 101, 3, 279, "icon_Armor_liuhuoshanwenjia", LocalStringManager.GetConfig("Armor_language", "Desc_282"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_282"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 1050, 4500, 2, 8, 3000, 6, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 30, isSpecial: false, 2, 36, 155, new List<int>(), 3, -1, 1793, 975, 1425, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 85)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(35, 70), new OuterAndInnerShorts(0, 10), -1, new List<string> { "collar/collar", "collar/collar_125", "equip_arm_l/equip_arm_l", "equip_arm_l/equip_arm_l_125", "equip_arm_r/equip_arm_r", "equip_arm_r/equip_arm_r_125", "equip_bw_l/equip_bw_l", "equip_bw_l/equip_bw_l_125", "equip_bw_r/equip_bw_r", "equip_bw_r/equip_bw_r_125" }, 100));
		_dataArray.Add(new ArmorItem(283, LocalStringManager.GetConfig("Armor_language", "Name_283"), 1, 101, 4, 279, "icon_Armor_zijinjia", LocalStringManager.GetConfig("Armor_language", "Desc_283"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_283"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 1155, 9300, 3, 10, 4200, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 25, isSpecial: false, 2, 36, 155, new List<int>(), 3, -1, 1793, 1095, 1575, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 90)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(40, 80), new OuterAndInnerShorts(0, 15), -1, new List<string> { "collar/collar", "collar/collar_125", "equip_arm_l/equip_arm_l", "equip_arm_l/equip_arm_l_125", "equip_arm_r/equip_arm_r", "equip_arm_r/equip_arm_r_125", "equip_bw_l/equip_bw_l", "equip_bw_l/equip_bw_l_125", "equip_bw_r/equip_bw_r", "equip_bw_r/equip_bw_r_125" }, 100));
		_dataArray.Add(new ArmorItem(284, LocalStringManager.GetConfig("Armor_language", "Name_284"), 1, 101, 5, 279, "icon_Armor_tianhehanjiangjia", LocalStringManager.GetConfig("Armor_language", "Desc_284"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_284"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 1260, 16800, 4, 12, 5400, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 20, isSpecial: false, 2, 36, 155, new List<int>(), 3, -1, 1793, 1225, 1735, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 95)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(45, 90), new OuterAndInnerShorts(10, 20), -1, new List<string> { "collar/collar", "collar/collar_125", "equip_arm_l/equip_arm_l", "equip_arm_l/equip_arm_l_125", "equip_arm_r/equip_arm_r", "equip_arm_r/equip_arm_r_125", "equip_bw_l/equip_bw_l", "equip_bw_l/equip_bw_l_125", "equip_bw_r/equip_bw_r", "equip_bw_r/equip_bw_r_125" }, 100));
		_dataArray.Add(new ArmorItem(285, LocalStringManager.GetConfig("Armor_language", "Name_285"), 1, 101, 6, 279, "icon_Armor_shengyuanyi", LocalStringManager.GetConfig("Armor_language", "Desc_285"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_285"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 1365, 27600, 5, 14, 7200, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 15, isSpecial: false, 2, 36, 155, new List<int>(), 3, -1, 1793, 1360, 1900, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 100)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(50, 100), new OuterAndInnerShorts(10, 20), -1, new List<string>
		{
			"collar/collar", "collar/collar_129", "equip_arm_l/equip_arm_l", "equip_arm_l/equip_arm_l_129", "equip_arm_r/equip_arm_r", "equip_arm_r/equip_arm_r_129", "equip_bw_l/equip_bw_l", "equip_bw_l/equip_bw_l_129", "equip_bw_r/equip_bw_r", "equip_bw_r/equip_bw_r_129",
			"equip_waist/equip_waist", "equip_waist/equip_waist_129", "equip_leg_l/equip_leg_l", "equip_leg_l/equip_leg_l_129", "equip_leg_r/equip_leg_r", "equip_leg_r/equip_leg_r_129"
		}, 100));
		_dataArray.Add(new ArmorItem(286, LocalStringManager.GetConfig("Armor_language", "Name_286"), 1, 101, 7, 279, "icon_Armor_xuanwukai", LocalStringManager.GetConfig("Armor_language", "Desc_286"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_286"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 1470, 42300, 6, 16, 9000, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 10, isSpecial: false, 2, 36, 155, new List<int>(), 3, -1, 1793, 1500, 2070, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 105)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(55, 110), new OuterAndInnerShorts(15, 25), -1, new List<string>
		{
			"collar/collar", "collar/collar_129", "equip_arm_l/equip_arm_l", "equip_arm_l/equip_arm_l_129", "equip_arm_r/equip_arm_r", "equip_arm_r/equip_arm_r_129", "equip_bw_l/equip_bw_l", "equip_bw_l/equip_bw_l_129", "equip_bw_r/equip_bw_r", "equip_bw_r/equip_bw_r_129",
			"equip_waist/equip_waist", "equip_waist/equip_waist_129", "equip_leg_l/equip_leg_l", "equip_leg_l/equip_leg_l_129", "equip_leg_r/equip_leg_r", "equip_leg_r/equip_leg_r_129"
		}, 100));
		_dataArray.Add(new ArmorItem(287, LocalStringManager.GetConfig("Armor_language", "Name_287"), 1, 101, 8, 279, "icon_Armor_fenguangbaoyi", LocalStringManager.GetConfig("Armor_language", "Desc_287"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_287"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 1575, 61500, 6, 18, 10800, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 5, isSpecial: false, 2, 36, 155, new List<int>(), 3, -1, 1793, 1650, 2250, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 110)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(60, 120), new OuterAndInnerShorts(20, 30), -1, new List<string>
		{
			"collar/collar", "collar/collar_129", "equip_arm_l/equip_arm_l", "equip_arm_l/equip_arm_l_129", "equip_arm_r/equip_arm_r", "equip_arm_r/equip_arm_r_129", "equip_bw_l/equip_bw_l", "equip_bw_l/equip_bw_l_129", "equip_bw_r/equip_bw_r", "equip_bw_r/equip_bw_r_129",
			"equip_waist/equip_waist", "equip_waist/equip_waist_129", "equip_leg_l/equip_leg_l", "equip_leg_l/equip_leg_l_129", "equip_leg_r/equip_leg_r", "equip_leg_r/equip_leg_r_129"
		}, 100));
		_dataArray.Add(new ArmorItem(288, LocalStringManager.GetConfig("Armor_language", "Name_288"), 1, 101, 0, 288, "icon_Armor_muzhajia", LocalStringManager.GetConfig("Armor_language", "Desc_288"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_288"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 60, 360, 300, 0, 2, 600, 3, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 45, isSpecial: false, 1, 36, 148, new List<int>(), 3, -1, 1794, 360, 720, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 60)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(20, 10), new OuterAndInnerShorts(0, 0), -1, new List<string> { "equip_arm_r/equip_arm_r", "equip_arm_r/equip_arm_r_231", "equip_bw_l/equip_bw_l", "equip_bw_l/equip_bw_l_231", "equip_bw_r/equip_bw_r", "equip_bw_r/equip_bw_r_231" }, 100));
		_dataArray.Add(new ArmorItem(289, LocalStringManager.GetConfig("Armor_language", "Name_289"), 1, 101, 1, 288, "icon_Armor_yanbojia", LocalStringManager.GetConfig("Armor_language", "Desc_289"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_289"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 60, 430, 600, 0, 4, 1200, 4, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 40, isSpecial: false, 1, 36, 148, new List<int>(), 3, -1, 1794, 430, 820, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 65)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(30, 15), new OuterAndInnerShorts(0, 0), -1, new List<string> { "equip_arm_r/equip_arm_r", "equip_arm_r/equip_arm_r_231", "equip_bw_l/equip_bw_l", "equip_bw_l/equip_bw_l_231", "equip_bw_r/equip_bw_r", "equip_bw_r/equip_bw_r_231" }, 100));
		_dataArray.Add(new ArmorItem(290, LocalStringManager.GetConfig("Armor_language", "Name_290"), 1, 101, 2, 288, "icon_Armor_qilingmujia", LocalStringManager.GetConfig("Armor_language", "Desc_290"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_290"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 60, 500, 1800, 1, 6, 1800, 5, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 35, isSpecial: false, 1, 36, 148, new List<int>(), 3, -1, 1794, 505, 925, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 70)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(40, 20), new OuterAndInnerShorts(10, 0), -1, new List<string> { "equip_arm_r/equip_arm_r", "equip_arm_r/equip_arm_r_231", "equip_bw_l/equip_bw_l", "equip_bw_l/equip_bw_l_231", "equip_bw_r/equip_bw_r", "equip_bw_r/equip_bw_r_231" }, 100));
		_dataArray.Add(new ArmorItem(291, LocalStringManager.GetConfig("Armor_language", "Name_291"), 1, 101, 3, 288, "icon_Armor_chixiaoyi", LocalStringManager.GetConfig("Armor_language", "Desc_291"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_291"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 60, 575, 4500, 2, 8, 3000, 6, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 30, isSpecial: false, 1, 36, 148, new List<int>(), 3, -1, 1794, 585, 1035, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 75)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(50, 25), new OuterAndInnerShorts(10, 0), -1, new List<string> { "collar/collar", "collar/collar_235", "equip_arm_l/equip_arm_l", "equip_arm_l/equip_arm_l_235", "equip_arm_r/equip_arm_r", "equip_arm_r/equip_arm_r_235", "equip_bw_l/equip_bw_l", "equip_bw_l/equip_bw_l_235", "equip_bw_r/equip_bw_r", "equip_bw_r/equip_bw_r_235" }, 100));
		_dataArray.Add(new ArmorItem(292, LocalStringManager.GetConfig("Armor_language", "Name_292"), 1, 101, 4, 288, "icon_Armor_hunxiangmujia", LocalStringManager.GetConfig("Armor_language", "Desc_292"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_292"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 60, 645, 9300, 3, 10, 4200, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 25, isSpecial: false, 1, 36, 148, new List<int>(), 3, -1, 1794, 670, 1150, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 80)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(60, 30), new OuterAndInnerShorts(15, 0), -1, new List<string> { "collar/collar", "collar/collar_235", "equip_arm_l/equip_arm_l", "equip_arm_l/equip_arm_l_235", "equip_arm_r/equip_arm_r", "equip_arm_r/equip_arm_r_235", "equip_bw_l/equip_bw_l", "equip_bw_l/equip_bw_l_235", "equip_bw_r/equip_bw_r", "equip_bw_r/equip_bw_r_235" }, 100));
		_dataArray.Add(new ArmorItem(293, LocalStringManager.GetConfig("Armor_language", "Name_293"), 1, 101, 5, 288, "icon_Armor_guiluoyi", LocalStringManager.GetConfig("Armor_language", "Desc_293"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_293"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 60, 720, 16800, 4, 12, 5400, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 20, isSpecial: false, 1, 36, 148, new List<int>(), 3, -1, 1794, 765, 1275, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 85)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(70, 35), new OuterAndInnerShorts(20, 0), -1, new List<string> { "collar/collar", "collar/collar_235", "equip_arm_l/equip_arm_l", "equip_arm_l/equip_arm_l_235", "equip_arm_r/equip_arm_r", "equip_arm_r/equip_arm_r_235", "equip_bw_l/equip_bw_l", "equip_bw_l/equip_bw_l_235", "equip_bw_r/equip_bw_r", "equip_bw_r/equip_bw_r_235" }, 100));
		_dataArray.Add(new ArmorItem(294, LocalStringManager.GetConfig("Armor_language", "Name_294"), 1, 101, 6, 288, "icon_Armor_baiqiaolinglongjia", LocalStringManager.GetConfig("Armor_language", "Desc_294"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_294"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 60, 790, 27600, 5, 14, 7200, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 15, isSpecial: false, 1, 36, 148, new List<int>(), 3, -1, 1794, 865, 1405, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 90)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(80, 40), new OuterAndInnerShorts(20, 0), -1, new List<string>
		{
			"collar/collar", "collar/collar_239", "equip_arm_l/equip_arm_l", "equip_arm_l/equip_arm_l_239", "equip_arm_r/equip_arm_r", "equip_arm_r/equip_arm_r_239", "equip_bw_l/equip_bw_l", "equip_bw_l/equip_bw_l_239", "equip_bw_r/equip_bw_r", "equip_bw_r/equip_bw_r_239",
			"equip_waist/equip_waist", "equip_waist/equip_waist_239", "equip_leg_l/equip_leg_l", "equip_leg_l/equip_leg_l_239", "equip_leg_r/equip_leg_r", "equip_leg_r/equip_leg_r_239"
		}, 100));
		_dataArray.Add(new ArmorItem(295, LocalStringManager.GetConfig("Armor_language", "Name_295"), 1, 101, 7, 288, "icon_Armor_kuhuanjia", LocalStringManager.GetConfig("Armor_language", "Desc_295"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_295"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 60, 860, 42300, 6, 16, 9000, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 10, isSpecial: false, 1, 36, 148, new List<int>(), 3, -1, 1794, 970, 1540, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 95)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(90, 45), new OuterAndInnerShorts(25, 0), -1, new List<string>
		{
			"collar/collar", "collar/collar_239", "equip_arm_l/equip_arm_l", "equip_arm_l/equip_arm_l_239", "equip_arm_r/equip_arm_r", "equip_arm_r/equip_arm_r_239", "equip_bw_l/equip_bw_l", "equip_bw_l/equip_bw_l_239", "equip_bw_r/equip_bw_r", "equip_bw_r/equip_bw_r_239",
			"equip_waist/equip_waist", "equip_waist/equip_waist_239", "equip_leg_l/equip_leg_l", "equip_leg_l/equip_leg_l_239", "equip_leg_r/equip_leg_r", "equip_leg_r/equip_leg_r_239"
		}, 100));
		_dataArray.Add(new ArmorItem(296, LocalStringManager.GetConfig("Armor_language", "Name_296"), 1, 101, 8, 288, "icon_Armor_xuanhuangmujia", LocalStringManager.GetConfig("Armor_language", "Desc_296"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_296"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 60, 935, 61500, 6, 18, 10800, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 5, isSpecial: false, 1, 36, 148, new List<int>(), 3, -1, 1794, 1080, 1680, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 100)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(100, 50), new OuterAndInnerShorts(30, 0), -1, new List<string>
		{
			"collar/collar", "collar/collar_239", "equip_arm_l/equip_arm_l", "equip_arm_l/equip_arm_l_239", "equip_arm_r/equip_arm_r", "equip_arm_r/equip_arm_r_239", "equip_bw_l/equip_bw_l", "equip_bw_l/equip_bw_l_239", "equip_bw_r/equip_bw_r", "equip_bw_r/equip_bw_r_239",
			"equip_waist/equip_waist", "equip_waist/equip_waist_239", "equip_leg_l/equip_leg_l", "equip_leg_l/equip_leg_l_239", "equip_leg_r/equip_leg_r", "equip_leg_r/equip_leg_r_239"
		}, 100));
		_dataArray.Add(new ArmorItem(297, LocalStringManager.GetConfig("Armor_language", "Name_297"), 1, 101, 0, 297, "icon_Armor_qingzhuyi", LocalStringManager.GetConfig("Armor_language", "Desc_297"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_297"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 60, 285, 300, 0, 2, 600, 3, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 45, isSpecial: false, 1, 36, 156, new List<int>(), 3, -1, 1794, 385, 625, new List<PropertyAndValue>
		{
			new PropertyAndValue(4, 60)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(10, 20), new OuterAndInnerShorts(0, 0), -1, new List<string> { "equip_arm_r/equip_arm_r", "equip_arm_r/equip_arm_r_211", "equip_bw_l/equip_bw_l", "equip_bw_l/equip_bw_l_211", "equip_bw_r/equip_bw_r", "equip_bw_r/equip_bw_r_211" }, 100));
		_dataArray.Add(new ArmorItem(298, LocalStringManager.GetConfig("Armor_language", "Name_298"), 1, 101, 1, 297, "icon_Armor_wutengmianzhujia", LocalStringManager.GetConfig("Armor_language", "Desc_298"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_298"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 60, 340, 600, 0, 4, 1200, 4, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 40, isSpecial: false, 1, 36, 156, new List<int>(), 3, -1, 1794, 440, 700, new List<PropertyAndValue>
		{
			new PropertyAndValue(4, 65)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(15, 30), new OuterAndInnerShorts(0, 0), -1, new List<string> { "equip_arm_r/equip_arm_r", "equip_arm_r/equip_arm_r_211", "equip_bw_l/equip_bw_l", "equip_bw_l/equip_bw_l_211", "equip_bw_r/equip_bw_r", "equip_bw_r/equip_bw_r_211" }, 100));
		_dataArray.Add(new ArmorItem(299, LocalStringManager.GetConfig("Armor_language", "Name_299"), 1, 101, 2, 297, "icon_Armor_fulujia", LocalStringManager.GetConfig("Armor_language", "Desc_299"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_299"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 60, 395, 1800, 1, 6, 1800, 5, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 35, isSpecial: false, 1, 36, 156, new List<int>(), 3, -1, 1794, 510, 790, new List<PropertyAndValue>
		{
			new PropertyAndValue(4, 70)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(20, 40), new OuterAndInnerShorts(0, 10), -1, new List<string> { "equip_arm_r/equip_arm_r", "equip_arm_r/equip_arm_r_211", "equip_bw_l/equip_bw_l", "equip_bw_l/equip_bw_l_211", "equip_bw_r/equip_bw_r", "equip_bw_r/equip_bw_r_211" }, 100));
	}

	private void CreateItems5()
	{
		_dataArray.Add(new ArmorItem(300, LocalStringManager.GetConfig("Armor_language", "Name_300"), 1, 101, 3, 297, "icon_Armor_guishezhou", LocalStringManager.GetConfig("Armor_language", "Desc_300"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_300"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 60, 450, 4500, 2, 8, 3000, 6, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 30, isSpecial: false, 1, 36, 156, new List<int>(), 3, -1, 1794, 580, 880, new List<PropertyAndValue>
		{
			new PropertyAndValue(4, 75)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(25, 50), new OuterAndInnerShorts(0, 10), -1, new List<string> { "collar/collar", "collar/collar_215", "equip_arm_l/equip_arm_l", "equip_arm_l/equip_arm_l_215", "equip_arm_r/equip_arm_r", "equip_arm_r/equip_arm_r_215", "equip_bw_l/equip_bw_l", "equip_bw_l/equip_bw_l_215", "equip_bw_r/equip_bw_r", "equip_bw_r/equip_bw_r_215" }, 100));
		_dataArray.Add(new ArmorItem(301, LocalStringManager.GetConfig("Armor_language", "Name_301"), 1, 101, 4, 297, "icon_Armor_jingxiemujia", LocalStringManager.GetConfig("Armor_language", "Desc_301"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_301"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 60, 500, 9300, 3, 10, 4200, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 25, isSpecial: false, 1, 36, 156, new List<int>(), 3, -1, 1794, 655, 975, new List<PropertyAndValue>
		{
			new PropertyAndValue(4, 80)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(30, 60), new OuterAndInnerShorts(0, 15), -1, new List<string> { "collar/collar", "collar/collar_215", "equip_arm_l/equip_arm_l", "equip_arm_l/equip_arm_l_215", "equip_arm_r/equip_arm_r", "equip_arm_r/equip_arm_r_215", "equip_bw_l/equip_bw_l", "equip_bw_l/equip_bw_l_215", "equip_bw_r/equip_bw_r", "equip_bw_r/equip_bw_r_215" }, 100));
		_dataArray.Add(new ArmorItem(302, LocalStringManager.GetConfig("Armor_language", "Name_302"), 1, 101, 5, 297, "icon_Armor_zhuquewujieyi", LocalStringManager.GetConfig("Armor_language", "Desc_302"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_302"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 60, 555, 16800, 4, 12, 5400, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 20, isSpecial: false, 1, 36, 156, new List<int>(), 3, -1, 1794, 730, 1070, new List<PropertyAndValue>
		{
			new PropertyAndValue(4, 85)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(35, 70), new OuterAndInnerShorts(0, 20), -1, new List<string> { "collar/collar", "collar/collar_215", "equip_arm_l/equip_arm_l", "equip_arm_l/equip_arm_l_215", "equip_arm_r/equip_arm_r", "equip_arm_r/equip_arm_r_215", "equip_bw_l/equip_bw_l", "equip_bw_l/equip_bw_l_215", "equip_bw_r/equip_bw_r", "equip_bw_r/equip_bw_r_215" }, 100));
		_dataArray.Add(new ArmorItem(303, LocalStringManager.GetConfig("Armor_language", "Name_303"), 1, 101, 6, 297, "icon_Armor_ziweixuanmujia", LocalStringManager.GetConfig("Armor_language", "Desc_303"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_303"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 60, 610, 27600, 5, 14, 7200, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 15, isSpecial: false, 1, 36, 156, new List<int>(), 3, -1, 1794, 820, 1180, new List<PropertyAndValue>
		{
			new PropertyAndValue(4, 90)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(40, 80), new OuterAndInnerShorts(0, 20), -1, new List<string>
		{
			"collar/collar", "collar/collar_219", "equip_arm_l/equip_arm_l", "equip_arm_l/equip_arm_l_219", "equip_arm_r/equip_arm_r", "equip_arm_r/equip_arm_r_219", "equip_bw_l/equip_bw_l", "equip_bw_l/equip_bw_l_219", "equip_bw_r/equip_bw_r", "equip_bw_r/equip_bw_r_219",
			"equip_waist/equip_waist", "equip_waist/equip_waist_219", "equip_leg_l/equip_leg_l", "equip_leg_l/equip_leg_l_219", "equip_leg_r/equip_leg_r", "equip_leg_r/equip_leg_r_219"
		}, 100));
		_dataArray.Add(new ArmorItem(304, LocalStringManager.GetConfig("Armor_language", "Name_304"), 1, 101, 7, 297, "icon_Armor_minglingbaozhou", LocalStringManager.GetConfig("Armor_language", "Desc_304"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_304"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 60, 665, 42300, 6, 16, 9000, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 10, isSpecial: false, 1, 36, 156, new List<int>(), 3, -1, 1794, 905, 1285, new List<PropertyAndValue>
		{
			new PropertyAndValue(4, 95)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(45, 90), new OuterAndInnerShorts(0, 25), -1, new List<string>
		{
			"collar/collar", "collar/collar_219", "equip_arm_l/equip_arm_l", "equip_arm_l/equip_arm_l_219", "equip_arm_r/equip_arm_r", "equip_arm_r/equip_arm_r_219", "equip_bw_l/equip_bw_l", "equip_bw_l/equip_bw_l_219", "equip_bw_r/equip_bw_r", "equip_bw_r/equip_bw_r_219",
			"equip_waist/equip_waist", "equip_waist/equip_waist_219", "equip_leg_l/equip_leg_l", "equip_leg_l/equip_leg_l_219", "equip_leg_r/equip_leg_r", "equip_leg_r/equip_leg_r_219"
		}, 100));
		_dataArray.Add(new ArmorItem(305, LocalStringManager.GetConfig("Armor_language", "Name_305"), 1, 101, 8, 297, "icon_Armor_daixingyi", LocalStringManager.GetConfig("Armor_language", "Desc_305"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_305"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 60, 720, 61500, 6, 18, 10800, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 5, isSpecial: false, 1, 36, 156, new List<int>(), 3, -1, 1794, 1000, 1400, new List<PropertyAndValue>
		{
			new PropertyAndValue(4, 100)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(50, 100), new OuterAndInnerShorts(0, 30), -1, new List<string>
		{
			"collar/collar", "collar/collar_219", "equip_arm_l/equip_arm_l", "equip_arm_l/equip_arm_l_219", "equip_arm_r/equip_arm_r", "equip_arm_r/equip_arm_r_219", "equip_bw_l/equip_bw_l", "equip_bw_l/equip_bw_l_219", "equip_bw_r/equip_bw_r", "equip_bw_r/equip_bw_r_219",
			"equip_waist/equip_waist", "equip_waist/equip_waist_219", "equip_leg_l/equip_leg_l", "equip_leg_l/equip_leg_l_219", "equip_leg_r/equip_leg_r", "equip_leg_r/equip_leg_r_219"
		}, 100));
		_dataArray.Add(new ArmorItem(306, LocalStringManager.GetConfig("Armor_language", "Name_306"), 1, 101, 0, 306, "icon_Armor_hupibeixin", LocalStringManager.GetConfig("Armor_language", "Desc_306"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_306"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 180, 300, 0, 2, 600, 3, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 45, isSpecial: false, 4, 36, 151, new List<int>(), 3, -1, 1796, 230, 470, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 30),
			new PropertyAndValue(3, 30)
		}, new HitOrAvoidShorts(20, 0, 0, 0), new OuterAndInnerShorts(20, 0), new OuterAndInnerShorts(0, 0), -1, new List<string> { "sleeve_l/sleeve_l", "sleeve_l/sleeve_l_311", "peplum/peplum", "peplum/peplum_311", "skirt/skirt", "skirt/skirt_311", "skirt_back/skirt_back", "skirt_back/skirt_back_311" }, 100));
		_dataArray.Add(new ArmorItem(307, LocalStringManager.GetConfig("Armor_language", "Name_307"), 1, 101, 1, 306, "icon_Armor_houqiupi", LocalStringManager.GetConfig("Armor_language", "Desc_307"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_307"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 210, 600, 0, 4, 1200, 4, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 40, isSpecial: false, 4, 36, 151, new List<int>(), 3, -1, 1796, 265, 525, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 35),
			new PropertyAndValue(3, 35)
		}, new HitOrAvoidShorts(20, 0, 0, 0), new OuterAndInnerShorts(30, 0), new OuterAndInnerShorts(0, 0), -1, new List<string> { "sleeve_l/sleeve_l", "sleeve_l/sleeve_l_311", "peplum/peplum", "peplum/peplum_311", "skirt/skirt", "skirt/skirt_311", "skirt_back/skirt_back", "skirt_back/skirt_back_311" }, 100));
		_dataArray.Add(new ArmorItem(308, LocalStringManager.GetConfig("Armor_language", "Name_308"), 1, 101, 2, 306, "icon_Armor_suannijia", LocalStringManager.GetConfig("Armor_language", "Desc_308"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_308"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 240, 1800, 1, 6, 1800, 5, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 35, isSpecial: false, 4, 36, 151, new List<int>(), 3, -1, 1796, 310, 590, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 40),
			new PropertyAndValue(3, 40)
		}, new HitOrAvoidShorts(20, 0, 0, 0), new OuterAndInnerShorts(40, 0), new OuterAndInnerShorts(0, 0), -1, new List<string> { "sleeve_l/sleeve_l", "sleeve_l/sleeve_l_311", "peplum/peplum", "peplum/peplum_311", "skirt/skirt", "skirt/skirt_311", "skirt_back/skirt_back", "skirt_back/skirt_back_311" }, 100));
		_dataArray.Add(new ArmorItem(309, LocalStringManager.GetConfig("Armor_language", "Name_309"), 1, 101, 3, 306, "icon_Armor_shouwangpigua", LocalStringManager.GetConfig("Armor_language", "Desc_309"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_309"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 270, 4500, 2, 8, 3000, 6, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 30, isSpecial: false, 4, 36, 151, new List<int>(), 3, -1, 1796, 355, 655, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 45),
			new PropertyAndValue(3, 45)
		}, new HitOrAvoidShorts(25, 0, 0, 0), new OuterAndInnerShorts(50, 0), new OuterAndInnerShorts(0, 0), -1, new List<string> { "sleeve_r/sleeve_r", "sleeve_r/sleeve_r_315", "peplum/peplum", "peplum/peplum_315", "skirt/skirt", "skirt/skirt_315", "skirt_back/skirt_back", "skirt_back/skirt_back_315" }, 100));
		_dataArray.Add(new ArmorItem(310, LocalStringManager.GetConfig("Armor_language", "Name_310"), 1, 101, 4, 306, "icon_Armor_mangcangqiu", LocalStringManager.GetConfig("Armor_language", "Desc_310"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_310"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 300, 9300, 3, 10, 4200, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 25, isSpecial: false, 4, 36, 151, new List<int>(), 3, -1, 1796, 400, 720, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 50),
			new PropertyAndValue(3, 50)
		}, new HitOrAvoidShorts(25, 0, 0, 0), new OuterAndInnerShorts(60, 0), new OuterAndInnerShorts(0, 0), -1, new List<string> { "sleeve_r/sleeve_r", "sleeve_r/sleeve_r_315", "peplum/peplum", "peplum/peplum_315", "skirt/skirt", "skirt/skirt_315", "skirt_back/skirt_back", "skirt_back/skirt_back_315" }, 100));
		_dataArray.Add(new ArmorItem(311, LocalStringManager.GetConfig("Armor_language", "Name_311"), 1, 101, 5, 306, "icon_Armor_tiangangbaoyi", LocalStringManager.GetConfig("Armor_language", "Desc_311"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_311"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 330, 16800, 4, 12, 5400, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 20, isSpecial: false, 4, 36, 151, new List<int>(), 3, -1, 1796, 450, 790, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 55),
			new PropertyAndValue(3, 55)
		}, new HitOrAvoidShorts(25, 0, 0, 0), new OuterAndInnerShorts(70, 0), new OuterAndInnerShorts(0, 0), -1, new List<string> { "sleeve_r/sleeve_r", "sleeve_r/sleeve_r_315", "peplum/peplum", "peplum/peplum_315", "skirt/skirt", "skirt/skirt_315", "skirt_back/skirt_back", "skirt_back/skirt_back_315" }, 100));
		_dataArray.Add(new ArmorItem(312, LocalStringManager.GetConfig("Armor_language", "Name_312"), 1, 101, 6, 306, "icon_Armor_fenghuangzhijin", LocalStringManager.GetConfig("Armor_language", "Desc_312"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_312"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 360, 27600, 5, 14, 7200, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 15, isSpecial: false, 4, 36, 151, new List<int>(), 3, -1, 1796, 505, 865, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 60),
			new PropertyAndValue(3, 60)
		}, new HitOrAvoidShorts(30, 0, 0, 0), new OuterAndInnerShorts(80, 0), new OuterAndInnerShorts(0, 0), -1, new List<string> { "sleeve_l/sleeve_l", "sleeve_l/sleeve_l_319", "sleeve_r/sleeve_r", "sleeve_r/sleeve_r_319", "peplum/peplum", "peplum/peplum_319", "skirt/skirt", "skirt/skirt_319", "skirt_back/skirt_back", "skirt_back/skirt_back_319" }, 100));
		_dataArray.Add(new ArmorItem(313, LocalStringManager.GetConfig("Armor_language", "Name_313"), 1, 101, 7, 306, "icon_Armor_shenxiuyi", LocalStringManager.GetConfig("Armor_language", "Desc_313"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_313"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 390, 42300, 6, 16, 9000, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 10, isSpecial: false, 4, 36, 151, new List<int>(), 3, -1, 1796, 560, 940, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 65),
			new PropertyAndValue(3, 65)
		}, new HitOrAvoidShorts(30, 0, 0, 0), new OuterAndInnerShorts(90, 0), new OuterAndInnerShorts(0, 0), -1, new List<string> { "sleeve_l/sleeve_l", "sleeve_l/sleeve_l_319", "sleeve_r/sleeve_r", "sleeve_r/sleeve_r_319", "peplum/peplum", "peplum/peplum_319", "skirt/skirt", "skirt/skirt_319", "skirt_back/skirt_back", "skirt_back/skirt_back_319" }, 100));
		_dataArray.Add(new ArmorItem(314, LocalStringManager.GetConfig("Armor_language", "Name_314"), 1, 101, 8, 306, "icon_Armor_tianmingjia", LocalStringManager.GetConfig("Armor_language", "Desc_314"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_314"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 420, 61500, 6, 18, 10800, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 5, isSpecial: false, 4, 36, 151, new List<int>(), 3, -1, 1796, 620, 1020, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 70),
			new PropertyAndValue(3, 70)
		}, new HitOrAvoidShorts(30, 0, 0, 0), new OuterAndInnerShorts(100, 0), new OuterAndInnerShorts(0, 0), -1, new List<string> { "sleeve_l/sleeve_l", "sleeve_l/sleeve_l_319", "sleeve_r/sleeve_r", "sleeve_r/sleeve_r_319", "peplum/peplum", "peplum/peplum_319", "skirt/skirt", "skirt/skirt_319", "skirt_back/skirt_back", "skirt_back/skirt_back_319" }, 100));
		_dataArray.Add(new ArmorItem(315, LocalStringManager.GetConfig("Armor_language", "Name_315"), 1, 101, 0, 315, "icon_Armor_huangwenpigua", LocalStringManager.GetConfig("Armor_language", "Desc_315"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_315"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 140, 300, 0, 2, 600, 3, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 45, isSpecial: false, 4, 36, 152, new List<int>(), 3, -1, 1796, 205, 445, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 30),
			new PropertyAndValue(5, 30)
		}, new HitOrAvoidShorts(0, 20, 0, 0), new OuterAndInnerShorts(20, 0), new OuterAndInnerShorts(0, 0), -1, new List<string>
		{
			"collar/collar", "collar/collar_331", "sleeve_l/sleeve_l", "sleeve_l/sleeve_l_331", "sleeve_r/sleeve_r", "sleeve_r/sleeve_r_331", "peplum/peplum", "peplum/peplum_331", "skirt/skirt", "skirt/skirt_331",
			"skirt_back/skirt_back", "skirt_back/skirt_back_331"
		}, 100));
		_dataArray.Add(new ArmorItem(316, LocalStringManager.GetConfig("Armor_language", "Name_316"), 1, 101, 1, 315, "icon_Armor_wuchangpao", LocalStringManager.GetConfig("Armor_language", "Desc_316"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_316"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 160, 600, 0, 4, 1200, 4, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 40, isSpecial: false, 4, 36, 152, new List<int>(), 3, -1, 1796, 235, 495, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 35),
			new PropertyAndValue(5, 35)
		}, new HitOrAvoidShorts(0, 20, 0, 0), new OuterAndInnerShorts(30, 0), new OuterAndInnerShorts(0, 0), -1, new List<string>
		{
			"collar/collar", "collar/collar_331", "sleeve_l/sleeve_l", "sleeve_l/sleeve_l_331", "sleeve_r/sleeve_r", "sleeve_r/sleeve_r_331", "peplum/peplum", "peplum/peplum_331", "skirt/skirt", "skirt/skirt_331",
			"skirt_back/skirt_back", "skirt_back/skirt_back_331"
		}, 100));
		_dataArray.Add(new ArmorItem(317, LocalStringManager.GetConfig("Armor_language", "Name_317"), 1, 101, 2, 315, "icon_Armor_xiaoyaoshan", LocalStringManager.GetConfig("Armor_language", "Desc_317"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_317"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 180, 1800, 1, 6, 1800, 5, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 35, isSpecial: false, 4, 36, 152, new List<int>(), 3, -1, 1796, 265, 545, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 40),
			new PropertyAndValue(5, 40)
		}, new HitOrAvoidShorts(0, 20, 0, 0), new OuterAndInnerShorts(40, 0), new OuterAndInnerShorts(0, 0), -1, new List<string>
		{
			"collar/collar", "collar/collar_331", "sleeve_l/sleeve_l", "sleeve_l/sleeve_l_331", "sleeve_r/sleeve_r", "sleeve_r/sleeve_r_331", "peplum/peplum", "peplum/peplum_331", "skirt/skirt", "skirt/skirt_331",
			"skirt_back/skirt_back", "skirt_back/skirt_back_331"
		}, 100));
		_dataArray.Add(new ArmorItem(318, LocalStringManager.GetConfig("Armor_language", "Name_318"), 1, 101, 3, 315, "icon_Armor_biyuechangshan", LocalStringManager.GetConfig("Armor_language", "Desc_318"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_318"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 200, 4500, 2, 8, 3000, 6, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 30, isSpecial: false, 4, 36, 152, new List<int>(), 3, -1, 1796, 300, 600, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 45),
			new PropertyAndValue(5, 45)
		}, new HitOrAvoidShorts(0, 25, 0, 0), new OuterAndInnerShorts(50, 0), new OuterAndInnerShorts(0, 0), -1, new List<string>
		{
			"collar/collar", "collar/collar_335", "sleeve_l/sleeve_l", "sleeve_l/sleeve_l_335", "sleeve_r/sleeve_r", "sleeve_r/sleeve_r_335", "peplum/peplum", "peplum/peplum_335", "skirt/skirt", "skirt/skirt_335",
			"skirt_back/skirt_back", "skirt_back/skirt_back_335"
		}, 100));
		_dataArray.Add(new ArmorItem(319, LocalStringManager.GetConfig("Armor_language", "Name_319"), 1, 101, 4, 315, "icon_Armor_waiwailongming", LocalStringManager.GetConfig("Armor_language", "Desc_319"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_319"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 220, 9300, 3, 10, 4200, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 25, isSpecial: false, 4, 36, 152, new List<int>(), 3, -1, 1796, 335, 655, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 50),
			new PropertyAndValue(5, 50)
		}, new HitOrAvoidShorts(0, 25, 0, 0), new OuterAndInnerShorts(60, 0), new OuterAndInnerShorts(0, 0), -1, new List<string>
		{
			"collar/collar", "collar/collar_335", "sleeve_l/sleeve_l", "sleeve_l/sleeve_l_335", "sleeve_r/sleeve_r", "sleeve_r/sleeve_r_335", "peplum/peplum", "peplum/peplum_335", "skirt/skirt", "skirt/skirt_335",
			"skirt_back/skirt_back", "skirt_back/skirt_back_335"
		}, 100));
		_dataArray.Add(new ArmorItem(320, LocalStringManager.GetConfig("Armor_language", "Name_320"), 1, 101, 5, 315, "icon_Armor_yintianshan", LocalStringManager.GetConfig("Armor_language", "Desc_320"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_320"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 240, 16800, 4, 12, 5400, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 20, isSpecial: false, 4, 36, 152, new List<int>(), 3, -1, 1796, 375, 715, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 55),
			new PropertyAndValue(5, 55)
		}, new HitOrAvoidShorts(0, 25, 0, 0), new OuterAndInnerShorts(70, 0), new OuterAndInnerShorts(0, 0), -1, new List<string>
		{
			"collar/collar", "collar/collar_335", "sleeve_l/sleeve_l", "sleeve_l/sleeve_l_335", "sleeve_r/sleeve_r", "sleeve_r/sleeve_r_335", "peplum/peplum", "peplum/peplum_335", "skirt/skirt", "skirt/skirt_335",
			"skirt_back/skirt_back", "skirt_back/skirt_back_335"
		}, 100));
		_dataArray.Add(new ArmorItem(321, LocalStringManager.GetConfig("Armor_language", "Name_321"), 1, 101, 6, 315, "icon_Armor_mingmiwuse", LocalStringManager.GetConfig("Armor_language", "Desc_321"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_321"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 260, 27600, 5, 14, 7200, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 15, isSpecial: false, 4, 36, 152, new List<int>(), 3, -1, 1796, 415, 775, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 60),
			new PropertyAndValue(5, 60)
		}, new HitOrAvoidShorts(0, 30, 0, 0), new OuterAndInnerShorts(80, 0), new OuterAndInnerShorts(0, 0), -1, new List<string>
		{
			"collar/collar", "collar/collar_339", "sleeve_l/sleeve_l", "sleeve_l/sleeve_l_339", "sleeve_r/sleeve_r", "sleeve_r/sleeve_r_339", "peplum/peplum", "peplum/peplum_339", "skirt/skirt", "skirt/skirt_339",
			"skirt_back/skirt_back", "skirt_back/skirt_back_339"
		}, 100));
		_dataArray.Add(new ArmorItem(322, LocalStringManager.GetConfig("Armor_language", "Name_322"), 1, 101, 7, 315, "icon_Armor_baicai", LocalStringManager.GetConfig("Armor_language", "Desc_322"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_322"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 280, 42300, 6, 16, 9000, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 10, isSpecial: false, 4, 36, 152, new List<int>(), 3, -1, 1796, 455, 835, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 65),
			new PropertyAndValue(5, 65)
		}, new HitOrAvoidShorts(0, 30, 0, 0), new OuterAndInnerShorts(90, 0), new OuterAndInnerShorts(0, 0), -1, new List<string>
		{
			"collar/collar", "collar/collar_339", "sleeve_l/sleeve_l", "sleeve_l/sleeve_l_339", "sleeve_r/sleeve_r", "sleeve_r/sleeve_r_339", "peplum/peplum", "peplum/peplum_339", "skirt/skirt", "skirt/skirt_339",
			"skirt_back/skirt_back", "skirt_back/skirt_back_339"
		}, 100));
		_dataArray.Add(new ArmorItem(323, LocalStringManager.GetConfig("Armor_language", "Name_323"), 1, 101, 8, 315, "icon_Armor_jinchanbaoyi", LocalStringManager.GetConfig("Armor_language", "Desc_323"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_323"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 300, 61500, 6, 18, 10800, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 5, isSpecial: false, 4, 36, 152, new List<int>(), 3, -1, 1796, 500, 900, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 70),
			new PropertyAndValue(5, 70)
		}, new HitOrAvoidShorts(0, 30, 0, 0), new OuterAndInnerShorts(100, 0), new OuterAndInnerShorts(0, 0), -1, new List<string>
		{
			"collar/collar", "collar/collar_339", "sleeve_l/sleeve_l", "sleeve_l/sleeve_l_339", "sleeve_r/sleeve_r", "sleeve_r/sleeve_r_339", "peplum/peplum", "peplum/peplum_339", "skirt/skirt", "skirt/skirt_339",
			"skirt_back/skirt_back", "skirt_back/skirt_back_339"
		}, 100));
		_dataArray.Add(new ArmorItem(324, LocalStringManager.GetConfig("Armor_language", "Name_324"), 1, 101, 0, 324, "icon_Armor_shoulieduanshan", LocalStringManager.GetConfig("Armor_language", "Desc_324"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_324"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 120, 300, 0, 2, 600, 3, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 45, isSpecial: false, 4, 36, 150, new List<int>(), 3, -1, 1796, 190, 430, new List<PropertyAndValue>
		{
			new PropertyAndValue(1, 30),
			new PropertyAndValue(3, 30)
		}, new HitOrAvoidShorts(0, 0, 20, 0), new OuterAndInnerShorts(20, 0), new OuterAndInnerShorts(0, 0), -1, new List<string>
		{
			"collar/collar", "collar/collar_331", "sleeve_l/sleeve_l", "sleeve_l/sleeve_l_331", "sleeve_r/sleeve_r", "sleeve_r/sleeve_r_331", "peplum/peplum", "peplum/peplum_331", "skirt/skirt", "skirt/skirt_331",
			"skirt_back/skirt_back", "skirt_back/skirt_back_331"
		}, 100));
		_dataArray.Add(new ArmorItem(325, LocalStringManager.GetConfig("Armor_language", "Name_325"), 1, 101, 1, 324, "icon_Armor_jinqiuyi", LocalStringManager.GetConfig("Armor_language", "Desc_325"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_325"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 135, 600, 0, 4, 1200, 4, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 40, isSpecial: false, 4, 36, 150, new List<int>(), 3, -1, 1796, 215, 475, new List<PropertyAndValue>
		{
			new PropertyAndValue(1, 35),
			new PropertyAndValue(3, 35)
		}, new HitOrAvoidShorts(0, 0, 20, 0), new OuterAndInnerShorts(30, 0), new OuterAndInnerShorts(0, 0), -1, new List<string>
		{
			"collar/collar", "collar/collar_331", "sleeve_l/sleeve_l", "sleeve_l/sleeve_l_331", "sleeve_r/sleeve_r", "sleeve_r/sleeve_r_331", "peplum/peplum", "peplum/peplum_331", "skirt/skirt", "skirt/skirt_331",
			"skirt_back/skirt_back", "skirt_back/skirt_back_331"
		}, 100));
		_dataArray.Add(new ArmorItem(326, LocalStringManager.GetConfig("Armor_language", "Name_326"), 1, 101, 2, 324, "icon_Armor_feishouyi", LocalStringManager.GetConfig("Armor_language", "Desc_326"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_326"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 150, 1800, 1, 6, 1800, 5, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 35, isSpecial: false, 4, 36, 150, new List<int>(), 3, -1, 1796, 245, 525, new List<PropertyAndValue>
		{
			new PropertyAndValue(1, 40),
			new PropertyAndValue(3, 40)
		}, new HitOrAvoidShorts(0, 0, 20, 0), new OuterAndInnerShorts(40, 0), new OuterAndInnerShorts(0, 0), -1, new List<string>
		{
			"collar/collar", "collar/collar_331", "sleeve_l/sleeve_l", "sleeve_l/sleeve_l_331", "sleeve_r/sleeve_r", "sleeve_r/sleeve_r_331", "peplum/peplum", "peplum/peplum_331", "skirt/skirt", "skirt/skirt_331",
			"skirt_back/skirt_back", "skirt_back/skirt_back_331"
		}, 100));
		_dataArray.Add(new ArmorItem(327, LocalStringManager.GetConfig("Armor_language", "Name_327"), 1, 101, 3, 324, "icon_Armor_baguahechang", LocalStringManager.GetConfig("Armor_language", "Desc_327"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_327"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 165, 4500, 2, 8, 3000, 6, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 30, isSpecial: false, 4, 36, 150, new List<int>(), 3, -1, 1796, 270, 570, new List<PropertyAndValue>
		{
			new PropertyAndValue(1, 45),
			new PropertyAndValue(3, 45)
		}, new HitOrAvoidShorts(0, 0, 25, 0), new OuterAndInnerShorts(50, 0), new OuterAndInnerShorts(0, 0), -1, new List<string>
		{
			"collar/collar", "collar/collar_335", "sleeve_l/sleeve_l", "sleeve_l/sleeve_l_335", "sleeve_r/sleeve_r", "sleeve_r/sleeve_r_335", "peplum/peplum", "peplum/peplum_335", "skirt/skirt", "skirt/skirt_335",
			"skirt_back/skirt_back", "skirt_back/skirt_back_335"
		}, 100));
		_dataArray.Add(new ArmorItem(328, LocalStringManager.GetConfig("Armor_language", "Name_328"), 1, 101, 4, 324, "icon_Armor_caiyungui", LocalStringManager.GetConfig("Armor_language", "Desc_328"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_328"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 180, 9300, 3, 10, 4200, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 25, isSpecial: false, 4, 36, 150, new List<int>(), 3, -1, 1796, 305, 625, new List<PropertyAndValue>
		{
			new PropertyAndValue(1, 50),
			new PropertyAndValue(3, 50)
		}, new HitOrAvoidShorts(0, 0, 25, 0), new OuterAndInnerShorts(60, 0), new OuterAndInnerShorts(0, 0), -1, new List<string>
		{
			"collar/collar", "collar/collar_335", "sleeve_l/sleeve_l", "sleeve_l/sleeve_l_335", "sleeve_r/sleeve_r", "sleeve_r/sleeve_r_335", "peplum/peplum", "peplum/peplum_335", "skirt/skirt", "skirt/skirt_335",
			"skirt_back/skirt_back", "skirt_back/skirt_back_335"
		}, 100));
		_dataArray.Add(new ArmorItem(329, LocalStringManager.GetConfig("Armor_language", "Name_329"), 1, 101, 5, 324, "icon_Armor_nongyingyi", LocalStringManager.GetConfig("Armor_language", "Desc_329"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_329"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 195, 16800, 4, 12, 5400, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 20, isSpecial: false, 4, 36, 150, new List<int>(), 3, -1, 1796, 330, 670, new List<PropertyAndValue>
		{
			new PropertyAndValue(1, 55),
			new PropertyAndValue(3, 55)
		}, new HitOrAvoidShorts(0, 0, 25, 0), new OuterAndInnerShorts(70, 0), new OuterAndInnerShorts(0, 0), -1, new List<string>
		{
			"collar/collar", "collar/collar_335", "sleeve_l/sleeve_l", "sleeve_l/sleeve_l_335", "sleeve_r/sleeve_r", "sleeve_r/sleeve_r_335", "peplum/peplum", "peplum/peplum_335", "skirt/skirt", "skirt/skirt_335",
			"skirt_back/skirt_back", "skirt_back/skirt_back_335"
		}, 100));
		_dataArray.Add(new ArmorItem(330, LocalStringManager.GetConfig("Armor_language", "Name_330"), 1, 101, 6, 324, "icon_Armor_liuxupigua", LocalStringManager.GetConfig("Armor_language", "Desc_330"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_330"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 210, 27600, 5, 14, 7200, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 15, isSpecial: false, 4, 36, 150, new List<int>(), 3, -1, 1796, 370, 730, new List<PropertyAndValue>
		{
			new PropertyAndValue(1, 60),
			new PropertyAndValue(3, 60)
		}, new HitOrAvoidShorts(0, 0, 30, 0), new OuterAndInnerShorts(80, 0), new OuterAndInnerShorts(0, 0), -1, new List<string>
		{
			"collar/collar", "collar/collar_339", "sleeve_l/sleeve_l", "sleeve_l/sleeve_l_339", "sleeve_r/sleeve_r", "sleeve_r/sleeve_r_339", "peplum/peplum", "peplum/peplum_339", "skirt/skirt", "skirt/skirt_339",
			"skirt_back/skirt_back", "skirt_back/skirt_back_339"
		}, 100));
		_dataArray.Add(new ArmorItem(331, LocalStringManager.GetConfig("Armor_language", "Name_331"), 1, 101, 7, 324, "icon_Armor_biyixianmei", LocalStringManager.GetConfig("Armor_language", "Desc_331"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_331"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 225, 42300, 6, 16, 9000, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 10, isSpecial: false, 4, 36, 150, new List<int>(), 3, -1, 1796, 400, 780, new List<PropertyAndValue>
		{
			new PropertyAndValue(1, 65),
			new PropertyAndValue(3, 65)
		}, new HitOrAvoidShorts(0, 0, 30, 0), new OuterAndInnerShorts(90, 0), new OuterAndInnerShorts(0, 0), -1, new List<string>
		{
			"collar/collar", "collar/collar_339", "sleeve_l/sleeve_l", "sleeve_l/sleeve_l_339", "sleeve_r/sleeve_r", "sleeve_r/sleeve_r_339", "peplum/peplum", "peplum/peplum_339", "skirt/skirt", "skirt/skirt_339",
			"skirt_back/skirt_back", "skirt_back/skirt_back_339"
		}, 100));
		_dataArray.Add(new ArmorItem(332, LocalStringManager.GetConfig("Armor_language", "Name_332"), 1, 101, 8, 324, "icon_Armor_shenguanglihe", LocalStringManager.GetConfig("Armor_language", "Desc_332"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_332"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 240, 61500, 6, 18, 10800, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 5, isSpecial: false, 4, 36, 150, new List<int>(), 3, -1, 1796, 440, 840, new List<PropertyAndValue>
		{
			new PropertyAndValue(1, 70),
			new PropertyAndValue(3, 70)
		}, new HitOrAvoidShorts(0, 0, 30, 0), new OuterAndInnerShorts(100, 0), new OuterAndInnerShorts(0, 0), -1, new List<string>
		{
			"collar/collar", "collar/collar_339", "sleeve_l/sleeve_l", "sleeve_l/sleeve_l_339", "sleeve_r/sleeve_r", "sleeve_r/sleeve_r_339", "peplum/peplum", "peplum/peplum_339", "skirt/skirt", "skirt/skirt_339",
			"skirt_back/skirt_back", "skirt_back/skirt_back_339"
		}, 100));
		_dataArray.Add(new ArmorItem(333, LocalStringManager.GetConfig("Armor_language", "Name_333"), 1, 101, 0, 333, "icon_Armor_lianjia", LocalStringManager.GetConfig("Armor_language", "Desc_333"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_333"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 220, 300, 0, 2, 600, 3, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 45, isSpecial: false, 4, 36, 153, new List<int>(), 3, -1, 1796, 250, 610, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 30),
			new PropertyAndValue(3, 30)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(20, 0), new OuterAndInnerShorts(10, 0), -1, new List<string> { "sleeve_l/sleeve_l", "sleeve_l/sleeve_l_311", "peplum/peplum", "peplum/peplum_311", "skirt/skirt", "skirt/skirt_311", "skirt_back/skirt_back", "skirt_back/skirt_back_311" }, 100));
		_dataArray.Add(new ArmorItem(334, LocalStringManager.GetConfig("Armor_language", "Name_334"), 1, 101, 1, 333, "icon_Armor_ruangejia", LocalStringManager.GetConfig("Armor_language", "Desc_334"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_334"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 260, 600, 0, 4, 1200, 4, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 40, isSpecial: false, 4, 36, 153, new List<int>(), 3, -1, 1796, 300, 690, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 35),
			new PropertyAndValue(3, 35)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(25, 0), new OuterAndInnerShorts(10, 0), -1, new List<string> { "sleeve_l/sleeve_l", "sleeve_l/sleeve_l_311", "peplum/peplum", "peplum/peplum_311", "skirt/skirt", "skirt/skirt_311", "skirt_back/skirt_back", "skirt_back/skirt_back_311" }, 100));
		_dataArray.Add(new ArmorItem(335, LocalStringManager.GetConfig("Armor_language", "Name_335"), 1, 101, 2, 333, "icon_Armor_jinlinjinzhuang", LocalStringManager.GetConfig("Armor_language", "Desc_335"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_335"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 300, 1800, 1, 6, 1800, 5, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 35, isSpecial: false, 4, 36, 153, new List<int>(), 3, -1, 1796, 350, 770, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 40),
			new PropertyAndValue(3, 40)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(30, 0), new OuterAndInnerShorts(15, 0), -1, new List<string> { "sleeve_l/sleeve_l", "sleeve_l/sleeve_l_311", "peplum/peplum", "peplum/peplum_311", "skirt/skirt", "skirt/skirt_311", "skirt_back/skirt_back", "skirt_back/skirt_back_311" }, 100));
		_dataArray.Add(new ArmorItem(336, LocalStringManager.GetConfig("Armor_language", "Name_336"), 1, 101, 3, 333, "icon_Armor_shuangshijinluoqiu", LocalStringManager.GetConfig("Armor_language", "Desc_336"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_336"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 340, 4500, 2, 8, 3000, 6, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 30, isSpecial: false, 4, 36, 153, new List<int>(), 3, -1, 1796, 405, 855, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 45),
			new PropertyAndValue(3, 45)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(35, 0), new OuterAndInnerShorts(20, 0), -1, new List<string> { "sleeve_r/sleeve_r", "sleeve_r/sleeve_r_315", "peplum/peplum", "peplum/peplum_315", "skirt/skirt", "skirt/skirt_315", "skirt_back/skirt_back", "skirt_back/skirt_back_315" }, 100));
		_dataArray.Add(new ArmorItem(337, LocalStringManager.GetConfig("Armor_language", "Name_337"), 1, 101, 4, 333, "icon_Armor_chenglongyi", LocalStringManager.GetConfig("Armor_language", "Desc_337"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_337"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 380, 9300, 3, 10, 4200, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 25, isSpecial: false, 4, 36, 153, new List<int>(), 3, -1, 1796, 465, 945, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 50),
			new PropertyAndValue(3, 50)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(40, 0), new OuterAndInnerShorts(20, 0), -1, new List<string> { "sleeve_r/sleeve_r", "sleeve_r/sleeve_r_315", "peplum/peplum", "peplum/peplum_315", "skirt/skirt", "skirt/skirt_315", "skirt_back/skirt_back", "skirt_back/skirt_back_315" }, 100));
		_dataArray.Add(new ArmorItem(338, LocalStringManager.GetConfig("Armor_language", "Name_338"), 1, 101, 5, 333, "icon_Armor_xuanniaohuangshan", LocalStringManager.GetConfig("Armor_language", "Desc_338"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_338"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 420, 16800, 4, 12, 5400, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 20, isSpecial: false, 4, 36, 153, new List<int>(), 3, -1, 1796, 525, 1035, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 55),
			new PropertyAndValue(3, 55)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(45, 0), new OuterAndInnerShorts(25, 0), -1, new List<string> { "sleeve_r/sleeve_r", "sleeve_r/sleeve_r_315", "peplum/peplum", "peplum/peplum_315", "skirt/skirt", "skirt/skirt_315", "skirt_back/skirt_back", "skirt_back/skirt_back_315" }, 100));
		_dataArray.Add(new ArmorItem(339, LocalStringManager.GetConfig("Armor_language", "Name_339"), 1, 101, 6, 333, "icon_Armor_kunpengjia", LocalStringManager.GetConfig("Armor_language", "Desc_339"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_339"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 460, 27600, 5, 14, 7200, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 15, isSpecial: false, 4, 36, 153, new List<int>(), 3, -1, 1796, 595, 1135, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 60),
			new PropertyAndValue(3, 60)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(50, 0), new OuterAndInnerShorts(30, 0), -1, new List<string> { "sleeve_l/sleeve_l", "sleeve_l/sleeve_l_319", "sleeve_r/sleeve_r", "sleeve_r/sleeve_r_319", "peplum/peplum", "peplum/peplum_319", "skirt/skirt", "skirt/skirt_319", "skirt_back/skirt_back", "skirt_back/skirt_back_319" }, 100));
		_dataArray.Add(new ArmorItem(340, LocalStringManager.GetConfig("Armor_language", "Name_340"), 1, 101, 7, 333, "icon_Armor_jiaoxiaobaoyi", LocalStringManager.GetConfig("Armor_language", "Desc_340"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_340"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 500, 42300, 6, 16, 9000, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 10, isSpecial: false, 4, 36, 153, new List<int>(), 3, -1, 1796, 665, 1235, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 65),
			new PropertyAndValue(3, 65)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(55, 0), new OuterAndInnerShorts(30, 0), -1, new List<string> { "sleeve_l/sleeve_l", "sleeve_l/sleeve_l_319", "sleeve_r/sleeve_r", "sleeve_r/sleeve_r_319", "peplum/peplum", "peplum/peplum_319", "skirt/skirt", "skirt/skirt_319", "skirt_back/skirt_back", "skirt_back/skirt_back_319" }, 100));
		_dataArray.Add(new ArmorItem(341, LocalStringManager.GetConfig("Armor_language", "Name_341"), 1, 101, 8, 333, "icon_Armor_gualonglin", LocalStringManager.GetConfig("Armor_language", "Desc_341"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_341"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 540, 61500, 6, 18, 10800, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 5, isSpecial: false, 4, 36, 153, new List<int>(), 3, -1, 1796, 740, 1340, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 70),
			new PropertyAndValue(3, 70)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(60, 0), new OuterAndInnerShorts(35, 0), -1, new List<string> { "sleeve_l/sleeve_l", "sleeve_l/sleeve_l_319", "sleeve_r/sleeve_r", "sleeve_r/sleeve_r_319", "peplum/peplum", "peplum/peplum_319", "skirt/skirt", "skirt/skirt_319", "skirt_back/skirt_back", "skirt_back/skirt_back_319" }, 100));
		_dataArray.Add(new ArmorItem(342, LocalStringManager.GetConfig("Armor_language", "Name_342"), 1, 101, 0, 342, "icon_Armor_mabuyi", LocalStringManager.GetConfig("Armor_language", "Desc_342"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_342"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 80, 300, 0, 2, 600, 3, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 45, isSpecial: false, 4, 36, 158, new List<int>(), 3, -1, 1796, 170, 410, new List<PropertyAndValue>
		{
			new PropertyAndValue(1, 30),
			new PropertyAndValue(4, 30)
		}, new HitOrAvoidShorts(0, 0, 20, 0), new OuterAndInnerShorts(0, 20), new OuterAndInnerShorts(0, 0), -1, new List<string>
		{
			"collar/collar", "collar/collar_321", "sleeve_l/sleeve_l", "sleeve_l/sleeve_l_321", "sleeve_r/sleeve_r", "sleeve_r/sleeve_r_321", "peplum/peplum", "peplum/peplum_321", "skirt/skirt", "skirt/skirt_321",
			"skirt_back/skirt_back", "skirt_back/skirt_back_321"
		}, 100));
		_dataArray.Add(new ArmorItem(343, LocalStringManager.GetConfig("Armor_language", "Name_343"), 1, 101, 1, 342, "icon_Armor_jianghuangzhi", LocalStringManager.GetConfig("Armor_language", "Desc_343"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_343"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 85, 600, 0, 4, 1200, 4, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 40, isSpecial: false, 4, 36, 158, new List<int>(), 3, -1, 1796, 180, 440, new List<PropertyAndValue>
		{
			new PropertyAndValue(1, 35),
			new PropertyAndValue(4, 35)
		}, new HitOrAvoidShorts(0, 0, 20, 0), new OuterAndInnerShorts(0, 30), new OuterAndInnerShorts(0, 0), -1, new List<string>
		{
			"collar/collar", "collar/collar_321", "sleeve_l/sleeve_l", "sleeve_l/sleeve_l_321", "sleeve_r/sleeve_r", "sleeve_r/sleeve_r_321", "peplum/peplum", "peplum/peplum_321", "skirt/skirt", "skirt/skirt_321",
			"skirt_back/skirt_back", "skirt_back/skirt_back_321"
		}, 100));
		_dataArray.Add(new ArmorItem(344, LocalStringManager.GetConfig("Armor_language", "Name_344"), 1, 101, 2, 342, "icon_Armor_zhuyupao", LocalStringManager.GetConfig("Armor_language", "Desc_344"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_344"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 90, 1800, 1, 6, 1800, 5, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 35, isSpecial: false, 4, 36, 158, new List<int>(), 3, -1, 1796, 205, 485, new List<PropertyAndValue>
		{
			new PropertyAndValue(1, 40),
			new PropertyAndValue(4, 40)
		}, new HitOrAvoidShorts(0, 0, 20, 0), new OuterAndInnerShorts(0, 40), new OuterAndInnerShorts(0, 0), -1, new List<string>
		{
			"collar/collar", "collar/collar_321", "sleeve_l/sleeve_l", "sleeve_l/sleeve_l_321", "sleeve_r/sleeve_r", "sleeve_r/sleeve_r_321", "peplum/peplum", "peplum/peplum_321", "skirt/skirt", "skirt/skirt_321",
			"skirt_back/skirt_back", "skirt_back/skirt_back_321"
		}, 100));
		_dataArray.Add(new ArmorItem(345, LocalStringManager.GetConfig("Armor_language", "Name_345"), 1, 101, 3, 342, "icon_Armor_taihegangyi", LocalStringManager.GetConfig("Armor_language", "Desc_345"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_345"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 95, 4500, 2, 8, 3000, 6, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 30, isSpecial: false, 4, 36, 158, new List<int>(), 3, -1, 1796, 220, 520, new List<PropertyAndValue>
		{
			new PropertyAndValue(1, 45),
			new PropertyAndValue(4, 45)
		}, new HitOrAvoidShorts(0, 0, 25, 0), new OuterAndInnerShorts(0, 50), new OuterAndInnerShorts(0, 0), -1, new List<string>
		{
			"collar/collar", "collar/collar_325", "sleeve_l/sleeve_l", "sleeve_l/sleeve_l_325", "sleeve_r/sleeve_r", "sleeve_r/sleeve_r_325", "peplum/peplum", "peplum/peplum_325", "skirt/skirt", "skirt/skirt_325",
			"skirt_back/skirt_back", "skirt_back/skirt_back_325"
		}, 100));
		_dataArray.Add(new ArmorItem(346, LocalStringManager.GetConfig("Armor_language", "Name_346"), 1, 101, 4, 342, "icon_Armor_yanyuluoyi", LocalStringManager.GetConfig("Armor_language", "Desc_346"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_346"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 100, 9300, 3, 10, 4200, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 25, isSpecial: false, 4, 36, 158, new List<int>(), 3, -1, 1796, 240, 560, new List<PropertyAndValue>
		{
			new PropertyAndValue(1, 50),
			new PropertyAndValue(4, 50)
		}, new HitOrAvoidShorts(0, 0, 25, 0), new OuterAndInnerShorts(0, 60), new OuterAndInnerShorts(0, 0), -1, new List<string>
		{
			"collar/collar", "collar/collar_325", "sleeve_l/sleeve_l", "sleeve_l/sleeve_l_325", "sleeve_r/sleeve_r", "sleeve_r/sleeve_r_325", "peplum/peplum", "peplum/peplum_325", "skirt/skirt", "skirt/skirt_325",
			"skirt_back/skirt_back", "skirt_back/skirt_back_325"
		}, 100));
		_dataArray.Add(new ArmorItem(347, LocalStringManager.GetConfig("Armor_language", "Name_347"), 1, 101, 5, 342, "icon_Armor_kongmengsushoupao", LocalStringManager.GetConfig("Armor_language", "Desc_347"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_347"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 105, 16800, 4, 12, 5400, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 20, isSpecial: false, 4, 36, 158, new List<int>(), 3, -1, 1796, 255, 595, new List<PropertyAndValue>
		{
			new PropertyAndValue(1, 55),
			new PropertyAndValue(4, 55)
		}, new HitOrAvoidShorts(0, 0, 25, 0), new OuterAndInnerShorts(0, 70), new OuterAndInnerShorts(0, 0), -1, new List<string>
		{
			"collar/collar", "collar/collar_325", "sleeve_l/sleeve_l", "sleeve_l/sleeve_l_325", "sleeve_r/sleeve_r", "sleeve_r/sleeve_r_325", "peplum/peplum", "peplum/peplum_325", "skirt/skirt", "skirt/skirt_325",
			"skirt_back/skirt_back", "skirt_back/skirt_back_325"
		}, 100));
		_dataArray.Add(new ArmorItem(348, LocalStringManager.GetConfig("Armor_language", "Name_348"), 1, 101, 6, 342, "icon_Armor_jiangxuelinghanyi", LocalStringManager.GetConfig("Armor_language", "Desc_348"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_348"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 110, 27600, 5, 14, 7200, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 15, isSpecial: false, 4, 36, 158, new List<int>(), 3, -1, 1796, 280, 640, new List<PropertyAndValue>
		{
			new PropertyAndValue(1, 60),
			new PropertyAndValue(4, 60)
		}, new HitOrAvoidShorts(0, 0, 30, 0), new OuterAndInnerShorts(0, 80), new OuterAndInnerShorts(0, 0), -1, new List<string>
		{
			"collar/collar", "collar/collar_329", "sleeve_l/sleeve_l", "sleeve_l/sleeve_l_329", "sleeve_r/sleeve_r", "sleeve_r/sleeve_r_329", "peplum/peplum", "peplum/peplum_329", "skirt/skirt", "skirt/skirt_329",
			"skirt_back/skirt_back", "skirt_back/skirt_back_329"
		}, 100));
		_dataArray.Add(new ArmorItem(349, LocalStringManager.GetConfig("Armor_language", "Name_349"), 1, 101, 7, 342, "icon_Armor_bingjibaoyi", LocalStringManager.GetConfig("Armor_language", "Desc_349"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_349"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 115, 42300, 6, 16, 9000, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 10, isSpecial: false, 4, 36, 158, new List<int>(), 3, -1, 1796, 295, 675, new List<PropertyAndValue>
		{
			new PropertyAndValue(1, 65),
			new PropertyAndValue(4, 65)
		}, new HitOrAvoidShorts(0, 0, 30, 0), new OuterAndInnerShorts(0, 90), new OuterAndInnerShorts(0, 0), -1, new List<string>
		{
			"collar/collar", "collar/collar_329", "sleeve_l/sleeve_l", "sleeve_l/sleeve_l_329", "sleeve_r/sleeve_r", "sleeve_r/sleeve_r_329", "peplum/peplum", "peplum/peplum_329", "skirt/skirt", "skirt/skirt_329",
			"skirt_back/skirt_back", "skirt_back/skirt_back_329"
		}, 100));
		_dataArray.Add(new ArmorItem(350, LocalStringManager.GetConfig("Armor_language", "Name_350"), 1, 101, 8, 342, "icon_Armor_jiuhuayi", LocalStringManager.GetConfig("Armor_language", "Desc_350"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_350"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 120, 61500, 6, 18, 10800, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 5, isSpecial: false, 4, 36, 158, new List<int>(), 3, -1, 1796, 320, 720, new List<PropertyAndValue>
		{
			new PropertyAndValue(1, 70),
			new PropertyAndValue(4, 70)
		}, new HitOrAvoidShorts(0, 0, 30, 0), new OuterAndInnerShorts(0, 100), new OuterAndInnerShorts(0, 0), -1, new List<string>
		{
			"collar/collar", "collar/collar_329", "sleeve_l/sleeve_l", "sleeve_l/sleeve_l_329", "sleeve_r/sleeve_r", "sleeve_r/sleeve_r_329", "peplum/peplum", "peplum/peplum_329", "skirt/skirt", "skirt/skirt_329",
			"skirt_back/skirt_back", "skirt_back/skirt_back_329"
		}, 100));
		_dataArray.Add(new ArmorItem(351, LocalStringManager.GetConfig("Armor_language", "Name_351"), 1, 101, 0, 351, "icon_Armor_juanmajia", LocalStringManager.GetConfig("Armor_language", "Desc_351"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_351"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 100, 300, 0, 2, 600, 3, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 45, isSpecial: false, 4, 36, 160, new List<int>(), 3, -1, 1796, 180, 420, new List<PropertyAndValue>
		{
			new PropertyAndValue(4, 30),
			new PropertyAndValue(5, 30)
		}, new HitOrAvoidShorts(0, 20, 0, 0), new OuterAndInnerShorts(0, 20), new OuterAndInnerShorts(0, 0), -1, new List<string>
		{
			"collar/collar", "collar/collar_321", "sleeve_l/sleeve_l", "sleeve_l/sleeve_l_321", "sleeve_r/sleeve_r", "sleeve_r/sleeve_r_321", "peplum/peplum", "peplum/peplum_321", "skirt/skirt", "skirt/skirt_321",
			"skirt_back/skirt_back", "skirt_back/skirt_back_321"
		}, 100));
		_dataArray.Add(new ArmorItem(352, LocalStringManager.GetConfig("Armor_language", "Name_352"), 1, 101, 1, 351, "icon_Armor_luoruyi", LocalStringManager.GetConfig("Armor_language", "Desc_352"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_352"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 110, 600, 0, 4, 1200, 4, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 40, isSpecial: false, 4, 36, 160, new List<int>(), 3, -1, 1796, 200, 460, new List<PropertyAndValue>
		{
			new PropertyAndValue(4, 35),
			new PropertyAndValue(5, 35)
		}, new HitOrAvoidShorts(0, 20, 0, 0), new OuterAndInnerShorts(0, 30), new OuterAndInnerShorts(0, 0), -1, new List<string>
		{
			"collar/collar", "collar/collar_321", "sleeve_l/sleeve_l", "sleeve_l/sleeve_l_321", "sleeve_r/sleeve_r", "sleeve_r/sleeve_r_321", "peplum/peplum", "peplum/peplum_321", "skirt/skirt", "skirt/skirt_321",
			"skirt_back/skirt_back", "skirt_back/skirt_back_321"
		}, 100));
		_dataArray.Add(new ArmorItem(353, LocalStringManager.GetConfig("Armor_language", "Name_353"), 1, 101, 2, 351, "icon_Armor_guiwenpao", LocalStringManager.GetConfig("Armor_language", "Desc_353"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_353"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 120, 1800, 1, 6, 1800, 5, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 35, isSpecial: false, 4, 36, 160, new List<int>(), 3, -1, 1796, 225, 505, new List<PropertyAndValue>
		{
			new PropertyAndValue(4, 40),
			new PropertyAndValue(5, 40)
		}, new HitOrAvoidShorts(0, 20, 0, 0), new OuterAndInnerShorts(0, 40), new OuterAndInnerShorts(0, 0), -1, new List<string>
		{
			"collar/collar", "collar/collar_321", "sleeve_l/sleeve_l", "sleeve_l/sleeve_l_321", "sleeve_r/sleeve_r", "sleeve_r/sleeve_r_321", "peplum/peplum", "peplum/peplum_321", "skirt/skirt", "skirt/skirt_321",
			"skirt_back/skirt_back", "skirt_back/skirt_back_321"
		}, 100));
		_dataArray.Add(new ArmorItem(354, LocalStringManager.GetConfig("Armor_language", "Name_354"), 1, 101, 3, 351, "icon_Armor_liemingxuanchang", LocalStringManager.GetConfig("Armor_language", "Desc_354"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_354"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 130, 4500, 2, 8, 3000, 6, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 30, isSpecial: false, 4, 36, 160, new List<int>(), 3, -1, 1796, 250, 550, new List<PropertyAndValue>
		{
			new PropertyAndValue(4, 45),
			new PropertyAndValue(5, 45)
		}, new HitOrAvoidShorts(0, 25, 0, 0), new OuterAndInnerShorts(0, 50), new OuterAndInnerShorts(0, 0), -1, new List<string>
		{
			"collar/collar", "collar/collar_325", "sleeve_l/sleeve_l", "sleeve_l/sleeve_l_325", "sleeve_r/sleeve_r", "sleeve_r/sleeve_r_325", "peplum/peplum", "peplum/peplum_325", "skirt/skirt", "skirt/skirt_325",
			"skirt_back/skirt_back", "skirt_back/skirt_back_325"
		}, 100));
		_dataArray.Add(new ArmorItem(355, LocalStringManager.GetConfig("Armor_language", "Name_355"), 1, 101, 4, 351, "icon_Armor_jinbaodi", LocalStringManager.GetConfig("Armor_language", "Desc_355"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_355"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 140, 9300, 3, 10, 4200, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 25, isSpecial: false, 4, 36, 160, new List<int>(), 3, -1, 1796, 270, 590, new List<PropertyAndValue>
		{
			new PropertyAndValue(4, 50),
			new PropertyAndValue(5, 50)
		}, new HitOrAvoidShorts(0, 25, 0, 0), new OuterAndInnerShorts(0, 60), new OuterAndInnerShorts(0, 0), -1, new List<string>
		{
			"collar/collar", "collar/collar_325", "sleeve_l/sleeve_l", "sleeve_l/sleeve_l_325", "sleeve_r/sleeve_r", "sleeve_r/sleeve_r_325", "peplum/peplum", "peplum/peplum_325", "skirt/skirt", "skirt/skirt_325",
			"skirt_back/skirt_back", "skirt_back/skirt_back_325"
		}, 100));
		_dataArray.Add(new ArmorItem(356, LocalStringManager.GetConfig("Armor_language", "Name_356"), 1, 101, 5, 351, "icon_Armor_tianxiangruanyinshan", LocalStringManager.GetConfig("Armor_language", "Desc_356"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_356"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 150, 16800, 4, 12, 5400, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 20, isSpecial: false, 4, 36, 160, new List<int>(), 3, -1, 1796, 300, 640, new List<PropertyAndValue>
		{
			new PropertyAndValue(4, 55),
			new PropertyAndValue(5, 55)
		}, new HitOrAvoidShorts(0, 25, 0, 0), new OuterAndInnerShorts(0, 70), new OuterAndInnerShorts(0, 0), -1, new List<string>
		{
			"collar/collar", "collar/collar_325", "sleeve_l/sleeve_l", "sleeve_l/sleeve_l_325", "sleeve_r/sleeve_r", "sleeve_r/sleeve_r_325", "peplum/peplum", "peplum/peplum_325", "skirt/skirt", "skirt/skirt_325",
			"skirt_back/skirt_back", "skirt_back/skirt_back_325"
		}, 100));
		_dataArray.Add(new ArmorItem(357, LocalStringManager.GetConfig("Armor_language", "Name_357"), 1, 101, 6, 351, "icon_Armor_baoxiangtianyi", LocalStringManager.GetConfig("Armor_language", "Desc_357"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_357"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 160, 27600, 5, 14, 7200, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 15, isSpecial: false, 4, 36, 160, new List<int>(), 3, -1, 1796, 325, 685, new List<PropertyAndValue>
		{
			new PropertyAndValue(4, 60),
			new PropertyAndValue(5, 60)
		}, new HitOrAvoidShorts(0, 30, 0, 0), new OuterAndInnerShorts(0, 80), new OuterAndInnerShorts(0, 0), -1, new List<string>
		{
			"collar/collar", "collar/collar_329", "sleeve_l/sleeve_l", "sleeve_l/sleeve_l_329", "sleeve_r/sleeve_r", "sleeve_r/sleeve_r_329", "peplum/peplum", "peplum/peplum_329", "skirt/skirt", "skirt/skirt_329",
			"skirt_back/skirt_back", "skirt_back/skirt_back_329"
		}, 100));
		_dataArray.Add(new ArmorItem(358, LocalStringManager.GetConfig("Armor_language", "Name_358"), 1, 101, 7, 351, "icon_Armor_xuehuansha", LocalStringManager.GetConfig("Armor_language", "Desc_358"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_358"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 170, 42300, 6, 16, 9000, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 10, isSpecial: false, 4, 36, 160, new List<int>(), 3, -1, 1796, 350, 730, new List<PropertyAndValue>
		{
			new PropertyAndValue(4, 65),
			new PropertyAndValue(5, 65)
		}, new HitOrAvoidShorts(0, 30, 0, 0), new OuterAndInnerShorts(0, 90), new OuterAndInnerShorts(0, 0), -1, new List<string>
		{
			"collar/collar", "collar/collar_329", "sleeve_l/sleeve_l", "sleeve_l/sleeve_l_329", "sleeve_r/sleeve_r", "sleeve_r/sleeve_r_329", "peplum/peplum", "peplum/peplum_329", "skirt/skirt", "skirt/skirt_329",
			"skirt_back/skirt_back", "skirt_back/skirt_back_329"
		}, 100));
		_dataArray.Add(new ArmorItem(359, LocalStringManager.GetConfig("Armor_language", "Name_359"), 1, 101, 8, 351, "icon_Armor_tiancanbaoyi", LocalStringManager.GetConfig("Armor_language", "Desc_359"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_359"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 180, 61500, 6, 18, 10800, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 5, isSpecial: false, 4, 36, 160, new List<int>(), 3, -1, 1796, 380, 780, new List<PropertyAndValue>
		{
			new PropertyAndValue(4, 70),
			new PropertyAndValue(5, 70)
		}, new HitOrAvoidShorts(0, 30, 0, 0), new OuterAndInnerShorts(0, 100), new OuterAndInnerShorts(0, 0), -1, new List<string>
		{
			"collar/collar", "collar/collar_329", "sleeve_l/sleeve_l", "sleeve_l/sleeve_l_329", "sleeve_r/sleeve_r", "sleeve_r/sleeve_r_329", "peplum/peplum", "peplum/peplum_329", "skirt/skirt", "skirt/skirt_329",
			"skirt_back/skirt_back", "skirt_back/skirt_back_329"
		}, 100));
	}

	private void CreateItems6()
	{
		_dataArray.Add(new ArmorItem(360, LocalStringManager.GetConfig("Armor_language", "Name_360"), 1, 101, 0, 360, "icon_Armor_kuxingyi", LocalStringManager.GetConfig("Armor_language", "Desc_360"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_360"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 200, 300, 0, 2, 600, 3, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 45, isSpecial: false, 4, 36, 161, new List<int>(), 3, -1, 1796, 240, 600, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 30),
			new PropertyAndValue(4, 30)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 20), new OuterAndInnerShorts(0, 10), -1, new List<string>
		{
			"collar/collar", "collar/collar_321", "sleeve_l/sleeve_l", "sleeve_l/sleeve_l_321", "sleeve_r/sleeve_r", "sleeve_r/sleeve_r_321", "peplum/peplum", "peplum/peplum_321", "skirt/skirt", "skirt/skirt_321",
			"skirt_back/skirt_back", "skirt_back/skirt_back_321"
		}, 100));
		_dataArray.Add(new ArmorItem(361, LocalStringManager.GetConfig("Armor_language", "Name_361"), 1, 101, 1, 360, "icon_Armor_sanhuashenyi", LocalStringManager.GetConfig("Armor_language", "Desc_361"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_361"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 235, 600, 0, 4, 1200, 4, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 40, isSpecial: false, 4, 36, 161, new List<int>(), 3, -1, 1796, 280, 670, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 35),
			new PropertyAndValue(4, 35)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 25), new OuterAndInnerShorts(0, 10), -1, new List<string>
		{
			"collar/collar", "collar/collar_321", "sleeve_l/sleeve_l", "sleeve_l/sleeve_l_321", "sleeve_r/sleeve_r", "sleeve_r/sleeve_r_321", "peplum/peplum", "peplum/peplum_321", "skirt/skirt", "skirt/skirt_321",
			"skirt_back/skirt_back", "skirt_back/skirt_back_321"
		}, 100));
		_dataArray.Add(new ArmorItem(362, LocalStringManager.GetConfig("Armor_language", "Name_362"), 1, 101, 2, 360, "icon_Armor_banwenjinpigua", LocalStringManager.GetConfig("Armor_language", "Desc_362"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_362"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 270, 1800, 1, 6, 1800, 5, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 35, isSpecial: false, 4, 36, 161, new List<int>(), 3, -1, 1796, 330, 750, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 40),
			new PropertyAndValue(4, 40)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 30), new OuterAndInnerShorts(0, 15), -1, new List<string>
		{
			"collar/collar", "collar/collar_321", "sleeve_l/sleeve_l", "sleeve_l/sleeve_l_321", "sleeve_r/sleeve_r", "sleeve_r/sleeve_r_321", "peplum/peplum", "peplum/peplum_321", "skirt/skirt", "skirt/skirt_321",
			"skirt_back/skirt_back", "skirt_back/skirt_back_321"
		}, 100));
		_dataArray.Add(new ArmorItem(363, LocalStringManager.GetConfig("Armor_language", "Name_363"), 1, 101, 3, 360, "icon_Armor_cuimuyi", LocalStringManager.GetConfig("Armor_language", "Desc_363"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_363"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 305, 4500, 2, 8, 3000, 6, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 30, isSpecial: false, 4, 36, 161, new List<int>(), 3, -1, 1796, 375, 825, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 45),
			new PropertyAndValue(4, 45)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 35), new OuterAndInnerShorts(0, 20), -1, new List<string>
		{
			"collar/collar", "collar/collar_325", "sleeve_l/sleeve_l", "sleeve_l/sleeve_l_325", "sleeve_r/sleeve_r", "sleeve_r/sleeve_r_325", "peplum/peplum", "peplum/peplum_325", "skirt/skirt", "skirt/skirt_325",
			"skirt_back/skirt_back", "skirt_back/skirt_back_325"
		}, 100));
		_dataArray.Add(new ArmorItem(364, LocalStringManager.GetConfig("Armor_language", "Name_364"), 1, 101, 4, 360, "icon_Armor_bajiaohuilongzhi", LocalStringManager.GetConfig("Armor_language", "Desc_364"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_364"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 340, 9300, 3, 10, 4200, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 25, isSpecial: false, 4, 36, 161, new List<int>(), 3, -1, 1796, 430, 910, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 50),
			new PropertyAndValue(4, 50)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 40), new OuterAndInnerShorts(0, 20), -1, new List<string>
		{
			"collar/collar", "collar/collar_325", "sleeve_l/sleeve_l", "sleeve_l/sleeve_l_325", "sleeve_r/sleeve_r", "sleeve_r/sleeve_r_325", "peplum/peplum", "peplum/peplum_325", "skirt/skirt", "skirt/skirt_325",
			"skirt_back/skirt_back", "skirt_back/skirt_back_325"
		}, 100));
		_dataArray.Add(new ArmorItem(365, LocalStringManager.GetConfig("Armor_language", "Name_365"), 1, 101, 5, 360, "icon_Armor_haitangjinpi", LocalStringManager.GetConfig("Armor_language", "Desc_365"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_365"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 375, 16800, 4, 12, 5400, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 20, isSpecial: false, 4, 36, 161, new List<int>(), 3, -1, 1796, 485, 995, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 55),
			new PropertyAndValue(4, 55)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 45), new OuterAndInnerShorts(0, 25), -1, new List<string>
		{
			"collar/collar", "collar/collar_325", "sleeve_l/sleeve_l", "sleeve_l/sleeve_l_325", "sleeve_r/sleeve_r", "sleeve_r/sleeve_r_325", "peplum/peplum", "peplum/peplum_325", "skirt/skirt", "skirt/skirt_325",
			"skirt_back/skirt_back", "skirt_back/skirt_back_325"
		}, 100));
		_dataArray.Add(new ArmorItem(366, LocalStringManager.GetConfig("Armor_language", "Name_366"), 1, 101, 6, 360, "icon_Armor_kongqueluo", LocalStringManager.GetConfig("Armor_language", "Desc_366"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_366"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 410, 27600, 5, 14, 7200, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 15, isSpecial: false, 4, 36, 161, new List<int>(), 3, -1, 1796, 550, 1090, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 60),
			new PropertyAndValue(4, 60)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 50), new OuterAndInnerShorts(0, 30), -1, new List<string>
		{
			"collar/collar", "collar/collar_329", "sleeve_l/sleeve_l", "sleeve_l/sleeve_l_329", "sleeve_r/sleeve_r", "sleeve_r/sleeve_r_329", "peplum/peplum", "peplum/peplum_329", "skirt/skirt", "skirt/skirt_329",
			"skirt_back/skirt_back", "skirt_back/skirt_back_329"
		}, 100));
		_dataArray.Add(new ArmorItem(367, LocalStringManager.GetConfig("Armor_language", "Name_367"), 1, 101, 7, 360, "icon_Armor_zishoubaoyi", LocalStringManager.GetConfig("Armor_language", "Desc_367"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_367"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 445, 42300, 6, 16, 9000, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 10, isSpecial: false, 4, 36, 161, new List<int>(), 3, -1, 1796, 610, 1180, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 65),
			new PropertyAndValue(4, 65)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 55), new OuterAndInnerShorts(0, 30), -1, new List<string>
		{
			"collar/collar", "collar/collar_329", "sleeve_l/sleeve_l", "sleeve_l/sleeve_l_329", "sleeve_r/sleeve_r", "sleeve_r/sleeve_r_329", "peplum/peplum", "peplum/peplum_329", "skirt/skirt", "skirt/skirt_329",
			"skirt_back/skirt_back", "skirt_back/skirt_back_329"
		}, 100));
		_dataArray.Add(new ArmorItem(368, LocalStringManager.GetConfig("Armor_language", "Name_368"), 1, 101, 8, 360, "icon_Armor_nayuanshan", LocalStringManager.GetConfig("Armor_language", "Desc_368"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_368"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 480, 61500, 6, 18, 10800, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 5, isSpecial: false, 4, 36, 161, new List<int>(), 3, -1, 1796, 680, 1280, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 70),
			new PropertyAndValue(4, 70)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 60), new OuterAndInnerShorts(0, 35), -1, new List<string>
		{
			"collar/collar", "collar/collar_329", "sleeve_l/sleeve_l", "sleeve_l/sleeve_l_329", "sleeve_r/sleeve_r", "sleeve_r/sleeve_r_329", "peplum/peplum", "peplum/peplum_329", "skirt/skirt", "skirt/skirt_329",
			"skirt_back/skirt_back", "skirt_back/skirt_back_329"
		}, 100));
		_dataArray.Add(new ArmorItem(369, LocalStringManager.GetConfig("Armor_language", "Name_369"), 1, 101, 0, 369, "icon_Armor_guantouyi", LocalStringManager.GetConfig("Armor_language", "Desc_369"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_369"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 160, 300, 0, 2, 600, 3, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 45, isSpecial: false, 4, 36, 159, new List<int>(), 3, -1, 1796, 215, 455, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 30),
			new PropertyAndValue(4, 30)
		}, new HitOrAvoidShorts(20, 0, 0, 0), new OuterAndInnerShorts(0, 20), new OuterAndInnerShorts(0, 0), -1, new List<string>
		{
			"collar/collar", "collar/collar_331", "sleeve_l/sleeve_l", "sleeve_l/sleeve_l_331", "sleeve_r/sleeve_r", "sleeve_r/sleeve_r_331", "peplum/peplum", "peplum/peplum_331", "skirt/skirt", "skirt/skirt_331",
			"skirt_back/skirt_back", "skirt_back/skirt_back_331"
		}, 100));
		_dataArray.Add(new ArmorItem(370, LocalStringManager.GetConfig("Armor_language", "Name_370"), 1, 101, 1, 369, "icon_Armor_sunichangshan", LocalStringManager.GetConfig("Armor_language", "Desc_370"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_370"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 185, 600, 0, 4, 1200, 4, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 40, isSpecial: false, 4, 36, 159, new List<int>(), 3, -1, 1796, 245, 505, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 35),
			new PropertyAndValue(4, 35)
		}, new HitOrAvoidShorts(20, 0, 0, 0), new OuterAndInnerShorts(0, 30), new OuterAndInnerShorts(0, 0), -1, new List<string>
		{
			"collar/collar", "collar/collar_331", "sleeve_l/sleeve_l", "sleeve_l/sleeve_l_331", "sleeve_r/sleeve_r", "sleeve_r/sleeve_r_331", "peplum/peplum", "peplum/peplum_331", "skirt/skirt", "skirt/skirt_331",
			"skirt_back/skirt_back", "skirt_back/skirt_back_331"
		}, 100));
		_dataArray.Add(new ArmorItem(371, LocalStringManager.GetConfig("Armor_language", "Name_371"), 1, 101, 2, 369, "icon_Armor_siheruyipao", LocalStringManager.GetConfig("Armor_language", "Desc_371"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_371"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 210, 1800, 1, 6, 1800, 5, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 35, isSpecial: false, 4, 36, 159, new List<int>(), 3, -1, 1796, 285, 565, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 40),
			new PropertyAndValue(4, 40)
		}, new HitOrAvoidShorts(20, 0, 0, 0), new OuterAndInnerShorts(0, 40), new OuterAndInnerShorts(0, 0), -1, new List<string>
		{
			"collar/collar", "collar/collar_331", "sleeve_l/sleeve_l", "sleeve_l/sleeve_l_331", "sleeve_r/sleeve_r", "sleeve_r/sleeve_r_331", "peplum/peplum", "peplum/peplum_331", "skirt/skirt", "skirt/skirt_331",
			"skirt_back/skirt_back", "skirt_back/skirt_back_331"
		}, 100));
		_dataArray.Add(new ArmorItem(372, LocalStringManager.GetConfig("Armor_language", "Name_372"), 1, 101, 3, 369, "icon_Armor_baxianchang", LocalStringManager.GetConfig("Armor_language", "Desc_372"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_372"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 235, 4500, 2, 8, 3000, 6, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 30, isSpecial: false, 4, 36, 159, new List<int>(), 3, -1, 1796, 325, 625, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 45),
			new PropertyAndValue(4, 45)
		}, new HitOrAvoidShorts(25, 0, 0, 0), new OuterAndInnerShorts(0, 50), new OuterAndInnerShorts(0, 0), -1, new List<string>
		{
			"collar/collar", "collar/collar_335", "sleeve_l/sleeve_l", "sleeve_l/sleeve_l_335", "sleeve_r/sleeve_r", "sleeve_r/sleeve_r_335", "peplum/peplum", "peplum/peplum_335", "skirt/skirt", "skirt/skirt_335",
			"skirt_back/skirt_back", "skirt_back/skirt_back_335"
		}, 100));
		_dataArray.Add(new ArmorItem(373, LocalStringManager.GetConfig("Armor_language", "Name_373"), 1, 101, 4, 369, "icon_Armor_piyinyang", LocalStringManager.GetConfig("Armor_language", "Desc_373"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_373"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 260, 9300, 3, 10, 4200, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 25, isSpecial: false, 4, 36, 159, new List<int>(), 3, -1, 1796, 370, 690, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 50),
			new PropertyAndValue(4, 50)
		}, new HitOrAvoidShorts(25, 0, 0, 0), new OuterAndInnerShorts(0, 60), new OuterAndInnerShorts(0, 0), -1, new List<string>
		{
			"collar/collar", "collar/collar_335", "sleeve_l/sleeve_l", "sleeve_l/sleeve_l_335", "sleeve_r/sleeve_r", "sleeve_r/sleeve_r_335", "peplum/peplum", "peplum/peplum_335", "skirt/skirt", "skirt/skirt_335",
			"skirt_back/skirt_back", "skirt_back/skirt_back_335"
		}, 100));
		_dataArray.Add(new ArmorItem(374, LocalStringManager.GetConfig("Armor_language", "Name_374"), 1, 101, 5, 369, "icon_Armor_suijinzhuiyin", LocalStringManager.GetConfig("Armor_language", "Desc_374"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_374"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 285, 16800, 4, 12, 5400, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 20, isSpecial: false, 4, 36, 159, new List<int>(), 3, -1, 1796, 410, 750, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 55),
			new PropertyAndValue(4, 55)
		}, new HitOrAvoidShorts(25, 0, 0, 0), new OuterAndInnerShorts(0, 70), new OuterAndInnerShorts(0, 0), -1, new List<string>
		{
			"collar/collar", "collar/collar_335", "sleeve_l/sleeve_l", "sleeve_l/sleeve_l_335", "sleeve_r/sleeve_r", "sleeve_r/sleeve_r_335", "peplum/peplum", "peplum/peplum_335", "skirt/skirt", "skirt/skirt_335",
			"skirt_back/skirt_back", "skirt_back/skirt_back_335"
		}, 100));
		_dataArray.Add(new ArmorItem(375, LocalStringManager.GetConfig("Armor_language", "Name_375"), 1, 101, 6, 369, "icon_Armor_jiuyouditingpao", LocalStringManager.GetConfig("Armor_language", "Desc_375"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_375"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 310, 27600, 5, 14, 7200, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 15, isSpecial: false, 4, 36, 159, new List<int>(), 3, -1, 1796, 460, 820, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 60),
			new PropertyAndValue(4, 60)
		}, new HitOrAvoidShorts(30, 0, 0, 0), new OuterAndInnerShorts(0, 80), new OuterAndInnerShorts(0, 0), -1, new List<string>
		{
			"collar/collar", "collar/collar_339", "sleeve_l/sleeve_l", "sleeve_l/sleeve_l_339", "sleeve_r/sleeve_r", "sleeve_r/sleeve_r_339", "peplum/peplum", "peplum/peplum_339", "skirt/skirt", "skirt/skirt_339",
			"skirt_back/skirt_back", "skirt_back/skirt_back_339"
		}, 100));
		_dataArray.Add(new ArmorItem(376, LocalStringManager.GetConfig("Armor_language", "Name_376"), 1, 101, 7, 369, "icon_Armor_yunnibaoshan", LocalStringManager.GetConfig("Armor_language", "Desc_376"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_376"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 335, 42300, 6, 16, 9000, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 10, isSpecial: false, 4, 36, 159, new List<int>(), 3, -1, 1796, 505, 885, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 65),
			new PropertyAndValue(4, 65)
		}, new HitOrAvoidShorts(30, 0, 0, 0), new OuterAndInnerShorts(0, 90), new OuterAndInnerShorts(0, 0), -1, new List<string>
		{
			"collar/collar", "collar/collar_339", "sleeve_l/sleeve_l", "sleeve_l/sleeve_l_339", "sleeve_r/sleeve_r", "sleeve_r/sleeve_r_339", "peplum/peplum", "peplum/peplum_339", "skirt/skirt", "skirt/skirt_339",
			"skirt_back/skirt_back", "skirt_back/skirt_back_339"
		}, 100));
		_dataArray.Add(new ArmorItem(377, LocalStringManager.GetConfig("Armor_language", "Name_377"), 1, 101, 8, 369, "icon_Armor_xuandoutianyi", LocalStringManager.GetConfig("Armor_language", "Desc_377"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_377"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 360, 61500, 6, 18, 10800, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 5, isSpecial: false, 4, 36, 159, new List<int>(), 3, -1, 1796, 560, 960, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 70),
			new PropertyAndValue(4, 70)
		}, new HitOrAvoidShorts(30, 0, 0, 0), new OuterAndInnerShorts(0, 100), new OuterAndInnerShorts(0, 0), -1, new List<string>
		{
			"collar/collar", "collar/collar_339", "sleeve_l/sleeve_l", "sleeve_l/sleeve_l_339", "sleeve_r/sleeve_r", "sleeve_r/sleeve_r_339", "peplum/peplum", "peplum/peplum_339", "skirt/skirt", "skirt/skirt_339",
			"skirt_back/skirt_back", "skirt_back/skirt_back_339"
		}, 100));
		_dataArray.Add(new ArmorItem(378, LocalStringManager.GetConfig("Armor_language", "Name_378"), 1, 101, 0, 378, "icon_Armor_fanyijia", LocalStringManager.GetConfig("Armor_language", "Desc_378"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_378"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 80, 585, 300, 0, 2, 600, 3, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 45, isSpecial: false, 3, 36, 149, new List<int>(), 3, -1, 1795, 730, 610, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 40),
			new PropertyAndValue(3, 40)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(40, 5), new OuterAndInnerShorts(0, 0), -1, new List<string> { "equip_arm_l/equip_arm_l", "equip_arm_l/equip_arm_l_421", "equip_bw_l/equip_bw_l", "equip_bw_l/equip_bw_l_421", "equip_bw_r/equip_bw_r", "equip_bw_r/equip_bw_r_421" }, 100));
		_dataArray.Add(new ArmorItem(379, LocalStringManager.GetConfig("Armor_language", "Name_379"), 1, 101, 1, 378, "icon_Armor_bosiruanzhou", LocalStringManager.GetConfig("Armor_language", "Desc_379"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_379"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 80, 670, 600, 0, 4, 1200, 4, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 40, isSpecial: false, 3, 36, 149, new List<int>(), 3, -1, 1795, 830, 700, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 45),
			new PropertyAndValue(3, 45)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(50, 10), new OuterAndInnerShorts(0, 0), -1, new List<string> { "equip_arm_l/equip_arm_l", "equip_arm_l/equip_arm_l_421", "equip_bw_l/equip_bw_l", "equip_bw_l/equip_bw_l_421", "equip_bw_r/equip_bw_r", "equip_bw_r/equip_bw_r_421" }, 100));
		_dataArray.Add(new ArmorItem(380, LocalStringManager.GetConfig("Armor_language", "Name_380"), 1, 101, 2, 378, "icon_Armor_langhuopigua", LocalStringManager.GetConfig("Armor_language", "Desc_380"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_380"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 80, 755, 1800, 1, 6, 1800, 5, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 35, isSpecial: false, 3, 36, 149, new List<int>(), 3, -1, 1795, 940, 800, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 50),
			new PropertyAndValue(3, 50)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(60, 15), new OuterAndInnerShorts(10, 0), -1, new List<string> { "equip_arm_l/equip_arm_l", "equip_arm_l/equip_arm_l_421", "equip_bw_l/equip_bw_l", "equip_bw_l/equip_bw_l_421", "equip_bw_r/equip_bw_r", "equip_bw_r/equip_bw_r_421" }, 100));
		_dataArray.Add(new ArmorItem(381, LocalStringManager.GetConfig("Armor_language", "Name_381"), 1, 101, 3, 378, "icon_Armor_heibazhang", LocalStringManager.GetConfig("Armor_language", "Desc_381"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_381"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 80, 840, 4500, 2, 8, 3000, 6, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 30, isSpecial: false, 3, 36, 149, new List<int>(), 3, -1, 1795, 1050, 900, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 55),
			new PropertyAndValue(3, 55)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(70, 20), new OuterAndInnerShorts(10, 0), -1, new List<string> { "collar/collar", "collar/collar_425", "equip_arm_l/equip_arm_l", "equip_arm_l/equip_arm_l_425", "equip_arm_r/equip_arm_r", "equip_arm_r/equip_arm_r_425", "equip_bw_l/equip_bw_l", "equip_bw_l/equip_bw_l_425", "equip_bw_r/equip_bw_r", "equip_bw_r/equip_bw_r_425" }, 100));
		_dataArray.Add(new ArmorItem(382, LocalStringManager.GetConfig("Armor_language", "Name_382"), 1, 101, 4, 378, "icon_Armor_yunshuinu", LocalStringManager.GetConfig("Armor_language", "Desc_382"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_382"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 80, 920, 9300, 3, 10, 4200, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 25, isSpecial: false, 3, 36, 149, new List<int>(), 3, -1, 1795, 1170, 1010, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 60),
			new PropertyAndValue(3, 60)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(80, 25), new OuterAndInnerShorts(15, 0), -1, new List<string> { "collar/collar", "collar/collar_425", "equip_arm_l/equip_arm_l", "equip_arm_l/equip_arm_l_425", "equip_arm_r/equip_arm_r", "equip_arm_r/equip_arm_r_425", "equip_bw_l/equip_bw_l", "equip_bw_l/equip_bw_l_425", "equip_bw_r/equip_bw_r", "equip_bw_r/equip_bw_r_425" }, 100));
		_dataArray.Add(new ArmorItem(383, LocalStringManager.GetConfig("Armor_language", "Name_383"), 1, 101, 5, 378, "icon_Armor_lanyubiguangyi", LocalStringManager.GetConfig("Armor_language", "Desc_383"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_383"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 80, 1005, 16800, 4, 12, 5400, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 20, isSpecial: false, 3, 36, 149, new List<int>(), 3, -1, 1795, 1290, 1120, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 65),
			new PropertyAndValue(3, 65)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(90, 30), new OuterAndInnerShorts(20, 10), -1, new List<string> { "collar/collar", "collar/collar_425", "equip_arm_l/equip_arm_l", "equip_arm_l/equip_arm_l_425", "equip_arm_r/equip_arm_r", "equip_arm_r/equip_arm_r_425", "equip_bw_l/equip_bw_l", "equip_bw_l/equip_bw_l_425", "equip_bw_r/equip_bw_r", "equip_bw_r/equip_bw_r_425" }, 100));
		_dataArray.Add(new ArmorItem(384, LocalStringManager.GetConfig("Armor_language", "Name_384"), 1, 101, 6, 378, "icon_Armor_baiyaoyi", LocalStringManager.GetConfig("Armor_language", "Desc_384"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_384"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 80, 1090, 27600, 5, 14, 7200, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 15, isSpecial: false, 3, 36, 149, new List<int>(), 3, -1, 1795, 1420, 1240, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 70),
			new PropertyAndValue(3, 70)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(100, 35), new OuterAndInnerShorts(20, 10), -1, new List<string>
		{
			"collar/collar", "collar/collar_429", "equip_arm_l/equip_arm_l", "equip_arm_l/equip_arm_l_429", "equip_arm_r/equip_arm_r", "equip_arm_r/equip_arm_r_429", "equip_bw_l/equip_bw_l", "equip_bw_l/equip_bw_l_429", "equip_bw_r/equip_bw_r", "equip_bw_r/equip_bw_r_429",
			"equip_waist/equip_waist", "equip_waist/equip_waist_429", "equip_leg_l/equip_leg_l", "equip_leg_l/equip_leg_l_429", "equip_leg_r/equip_leg_r", "equip_leg_r/equip_leg_r_429"
		}, 100));
		_dataArray.Add(new ArmorItem(385, LocalStringManager.GetConfig("Armor_language", "Name_385"), 1, 101, 7, 378, "icon_Armor_qinglongbaozhou", LocalStringManager.GetConfig("Armor_language", "Desc_385"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_385"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 80, 1175, 42300, 6, 16, 9000, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 10, isSpecial: false, 3, 36, 149, new List<int>(), 3, -1, 1795, 1560, 1370, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 75),
			new PropertyAndValue(3, 75)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(110, 40), new OuterAndInnerShorts(25, 15), -1, new List<string>
		{
			"collar/collar", "collar/collar_429", "equip_arm_l/equip_arm_l", "equip_arm_l/equip_arm_l_429", "equip_arm_r/equip_arm_r", "equip_arm_r/equip_arm_r_429", "equip_bw_l/equip_bw_l", "equip_bw_l/equip_bw_l_429", "equip_bw_r/equip_bw_r", "equip_bw_r/equip_bw_r_429",
			"equip_waist/equip_waist", "equip_waist/equip_waist_429", "equip_leg_l/equip_leg_l", "equip_leg_l/equip_leg_l_429", "equip_leg_r/equip_leg_r", "equip_leg_r/equip_leg_r_429"
		}, 100));
		_dataArray.Add(new ArmorItem(386, LocalStringManager.GetConfig("Armor_language", "Name_386"), 1, 101, 8, 378, "icon_Armor_haosuyi", LocalStringManager.GetConfig("Armor_language", "Desc_386"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_386"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 80, 1260, 61500, 6, 18, 10800, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 5, isSpecial: false, 3, 36, 149, new List<int>(), 3, -1, 1795, 1700, 1500, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 80),
			new PropertyAndValue(3, 80)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(120, 45), new OuterAndInnerShorts(30, 20), -1, new List<string>
		{
			"collar/collar", "collar/collar_429", "equip_arm_l/equip_arm_l", "equip_arm_l/equip_arm_l_429", "equip_arm_r/equip_arm_r", "equip_arm_r/equip_arm_r_429", "equip_bw_l/equip_bw_l", "equip_bw_l/equip_bw_l_429", "equip_bw_r/equip_bw_r", "equip_bw_r/equip_bw_r_429",
			"equip_waist/equip_waist", "equip_waist/equip_waist_429", "equip_leg_l/equip_leg_l", "equip_leg_l/equip_leg_l_429", "equip_leg_r/equip_leg_r", "equip_leg_r/equip_leg_r_429"
		}, 100));
		_dataArray.Add(new ArmorItem(387, LocalStringManager.GetConfig("Armor_language", "Name_387"), 1, 101, 0, 387, "icon_Armor_yubeixin", LocalStringManager.GetConfig("Armor_language", "Desc_387"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_387"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 80, 530, 300, 0, 2, 600, 3, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 45, isSpecial: false, 3, 36, 157, new List<int>(), 3, -1, 1795, 770, 530, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 40),
			new PropertyAndValue(4, 40)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(5, 40), new OuterAndInnerShorts(0, 0), -1, new List<string> { "equip_arm_r/equip_arm_r", "equip_arm_r/equip_arm_r_411", "equip_bw_l/equip_bw_l", "equip_bw_l/equip_bw_l_411", "equip_bw_r/equip_bw_r", "equip_bw_r/equip_bw_r_411" }, 100));
		_dataArray.Add(new ArmorItem(388, LocalStringManager.GetConfig("Armor_language", "Name_388"), 1, 101, 1, 387, "icon_Armor_qianyujia", LocalStringManager.GetConfig("Armor_language", "Desc_388"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_388"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 80, 580, 600, 0, 4, 1200, 4, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 40, isSpecial: false, 3, 36, 157, new List<int>(), 3, -1, 1795, 850, 590, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 45),
			new PropertyAndValue(4, 45)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(10, 50), new OuterAndInnerShorts(0, 0), -1, new List<string> { "equip_arm_r/equip_arm_r", "equip_arm_r/equip_arm_r_411", "equip_bw_l/equip_bw_l", "equip_bw_l/equip_bw_l_411", "equip_bw_r/equip_bw_r", "equip_bw_r/equip_bw_r_411" }, 100));
		_dataArray.Add(new ArmorItem(389, LocalStringManager.GetConfig("Armor_language", "Name_389"), 1, 101, 2, 387, "icon_Armor_qionglinyi", LocalStringManager.GetConfig("Armor_language", "Desc_389"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_389"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 80, 630, 1800, 1, 6, 1800, 5, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 35, isSpecial: false, 3, 36, 157, new List<int>(), 3, -1, 1795, 945, 665, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 50),
			new PropertyAndValue(4, 50)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(15, 60), new OuterAndInnerShorts(0, 10), -1, new List<string> { "equip_arm_r/equip_arm_r", "equip_arm_r/equip_arm_r_411", "equip_bw_l/equip_bw_l", "equip_bw_l/equip_bw_l_411", "equip_bw_r/equip_bw_r", "equip_bw_r/equip_bw_r_411" }, 100));
		_dataArray.Add(new ArmorItem(390, LocalStringManager.GetConfig("Armor_language", "Name_390"), 1, 101, 3, 387, "icon_Armor_lengxunchangyi", LocalStringManager.GetConfig("Armor_language", "Desc_390"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_390"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 80, 675, 4500, 2, 8, 3000, 6, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 30, isSpecial: false, 3, 36, 157, new List<int>(), 3, -1, 1795, 1035, 735, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 55),
			new PropertyAndValue(4, 55)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(20, 70), new OuterAndInnerShorts(0, 10), -1, new List<string> { "collar/collar", "collar/collar_415", "equip_arm_l/equip_arm_l", "equip_arm_l/equip_arm_l_415", "equip_arm_r/equip_arm_r", "equip_arm_r/equip_arm_r_415", "equip_bw_l/equip_bw_l", "equip_bw_l/equip_bw_l_415", "equip_bw_r/equip_bw_r", "equip_bw_r/equip_bw_r_415" }, 100));
		_dataArray.Add(new ArmorItem(391, LocalStringManager.GetConfig("Armor_language", "Name_391"), 1, 101, 4, 387, "icon_Armor_fanshuangjia", LocalStringManager.GetConfig("Armor_language", "Desc_391"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_391"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 80, 725, 9300, 3, 10, 4200, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 25, isSpecial: false, 3, 36, 157, new List<int>(), 3, -1, 1795, 1135, 815, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 60),
			new PropertyAndValue(4, 60)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(25, 80), new OuterAndInnerShorts(0, 15), -1, new List<string> { "collar/collar", "collar/collar_415", "equip_arm_l/equip_arm_l", "equip_arm_l/equip_arm_l_415", "equip_arm_r/equip_arm_r", "equip_arm_r/equip_arm_r_415", "equip_bw_l/equip_bw_l", "equip_bw_l/equip_bw_l_415", "equip_bw_r/equip_bw_r", "equip_bw_r/equip_bw_r_415" }, 100));
		_dataArray.Add(new ArmorItem(392, LocalStringManager.GetConfig("Armor_language", "Name_392"), 1, 101, 5, 387, "icon_Armor_jiaoqieyujia", LocalStringManager.GetConfig("Armor_language", "Desc_392"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_392"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 80, 775, 16800, 4, 12, 5400, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 20, isSpecial: false, 3, 36, 157, new List<int>(), 3, -1, 1795, 1235, 895, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 65),
			new PropertyAndValue(4, 65)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(30, 90), new OuterAndInnerShorts(10, 20), -1, new List<string> { "collar/collar", "collar/collar_415", "equip_arm_l/equip_arm_l", "equip_arm_l/equip_arm_l_415", "equip_arm_r/equip_arm_r", "equip_arm_r/equip_arm_r_415", "equip_bw_l/equip_bw_l", "equip_bw_l/equip_bw_l_415", "equip_bw_r/equip_bw_r", "equip_bw_r/equip_bw_r_415" }, 100));
		_dataArray.Add(new ArmorItem(393, LocalStringManager.GetConfig("Armor_language", "Name_393"), 1, 101, 6, 387, "icon_Armor_cailuyuyi", LocalStringManager.GetConfig("Armor_language", "Desc_393"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_393"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 80, 825, 27600, 5, 14, 7200, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 15, isSpecial: false, 3, 36, 157, new List<int>(), 3, -1, 1795, 1340, 980, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 70),
			new PropertyAndValue(4, 70)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(35, 100), new OuterAndInnerShorts(10, 20), -1, new List<string>
		{
			"collar/collar", "collar/collar_419", "equip_arm_l/equip_arm_l", "equip_arm_l/equip_arm_l_419", "equip_arm_r/equip_arm_r", "equip_arm_r/equip_arm_r_419", "equip_bw_l/equip_bw_l", "equip_bw_l/equip_bw_l_419", "equip_bw_r/equip_bw_r", "equip_bw_r/equip_bw_r_419",
			"equip_waist/equip_waist", "equip_waist/equip_waist_419", "equip_leg_l/equip_leg_l", "equip_leg_l/equip_leg_l_419", "equip_leg_r/equip_leg_r", "equip_leg_r/equip_leg_r_419"
		}, 100));
		_dataArray.Add(new ArmorItem(394, LocalStringManager.GetConfig("Armor_language", "Name_394"), 1, 101, 7, 387, "icon_Armor_xuelibaojia", LocalStringManager.GetConfig("Armor_language", "Desc_394"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_394"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 80, 875, 42300, 6, 16, 9000, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 10, isSpecial: false, 3, 36, 157, new List<int>(), 3, -1, 1795, 1445, 1065, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 75),
			new PropertyAndValue(4, 75)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(40, 110), new OuterAndInnerShorts(15, 25), -1, new List<string>
		{
			"collar/collar", "collar/collar_419", "equip_arm_l/equip_arm_l", "equip_arm_l/equip_arm_l_419", "equip_arm_r/equip_arm_r", "equip_arm_r/equip_arm_r_419", "equip_bw_l/equip_bw_l", "equip_bw_l/equip_bw_l_419", "equip_bw_r/equip_bw_r", "equip_bw_r/equip_bw_r_419",
			"equip_waist/equip_waist", "equip_waist/equip_waist_419", "equip_leg_l/equip_leg_l", "equip_leg_l/equip_leg_l_419", "equip_leg_r/equip_leg_r", "equip_leg_r/equip_leg_r_419"
		}, 100));
		_dataArray.Add(new ArmorItem(395, LocalStringManager.GetConfig("Armor_language", "Name_395"), 1, 101, 8, 387, "icon_Armor_sumingbaolianyi", LocalStringManager.GetConfig("Armor_language", "Desc_395"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_395"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 80, 920, 61500, 6, 18, 10800, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 5, isSpecial: false, 3, 36, 157, new List<int>(), 3, -1, 1795, 1560, 1160, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 80),
			new PropertyAndValue(4, 80)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(45, 120), new OuterAndInnerShorts(20, 30), -1, new List<string>
		{
			"collar/collar", "collar/collar_419", "equip_arm_l/equip_arm_l", "equip_arm_l/equip_arm_l_419", "equip_arm_r/equip_arm_r", "equip_arm_r/equip_arm_r_419", "equip_bw_l/equip_bw_l", "equip_bw_l/equip_bw_l_419", "equip_bw_r/equip_bw_r", "equip_bw_r/equip_bw_r_419",
			"equip_waist/equip_waist", "equip_waist/equip_waist_419", "equip_leg_l/equip_leg_l", "equip_leg_l/equip_leg_l_419", "equip_leg_r/equip_leg_r", "equip_leg_r/equip_leg_r_419"
		}, 100));
		_dataArray.Add(new ArmorItem(396, LocalStringManager.GetConfig("Armor_language", "Name_396"), 1, 102, 0, 396, "icon_Armor_heitiehubi", LocalStringManager.GetConfig("Armor_language", "Desc_396"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_396"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 210, 300, 0, 2, 600, 3, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 45, isSpecial: false, 2, 36, 162, new List<int>(), 4, -1, 1793, 625, 625, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 60)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(40, 0), new OuterAndInnerShorts(10, 0), -1, new List<string> { "equip_elbow_l", "equip_elbow_l/equip_elbow_l_131", "equip_elbow_r", "equip_elbow_r/equip_elbow_r_131" }, 100));
		_dataArray.Add(new ArmorItem(397, LocalStringManager.GetConfig("Armor_language", "Name_397"), 1, 102, 1, 396, "icon_Armor_huansuochanbi", LocalStringManager.GetConfig("Armor_language", "Desc_397"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_397"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 275, 600, 0, 4, 1200, 4, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 40, isSpecial: false, 2, 36, 162, new List<int>(), 4, -1, 1793, 700, 700, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 65)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(50, 0), new OuterAndInnerShorts(10, 0), -1, new List<string> { "equip_elbow_l", "equip_elbow_l/equip_elbow_l_131", "equip_elbow_r", "equip_elbow_r/equip_elbow_r_131" }, 100));
		_dataArray.Add(new ArmorItem(398, LocalStringManager.GetConfig("Armor_language", "Name_398"), 1, 102, 2, 396, "icon_Armor_liuyehubo", LocalStringManager.GetConfig("Armor_language", "Desc_398"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_398"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 345, 1800, 1, 6, 1800, 5, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 35, isSpecial: false, 2, 36, 162, new List<int>(), 4, -1, 1793, 790, 790, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 70)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(60, 0), new OuterAndInnerShorts(15, 0), -1, new List<string> { "equip_elbow_l", "equip_elbow_l/equip_elbow_l_131", "equip_elbow_r", "equip_elbow_r/equip_elbow_r_131" }, 100));
		_dataArray.Add(new ArmorItem(399, LocalStringManager.GetConfig("Armor_language", "Name_399"), 1, 102, 3, 396, "icon_Armor_jingganghuanbi", LocalStringManager.GetConfig("Armor_language", "Desc_399"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_399"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 410, 4500, 2, 8, 3000, 6, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 30, isSpecial: false, 2, 36, 162, new List<int>(), 4, -1, 1793, 880, 880, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 75)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(70, 0), new OuterAndInnerShorts(20, 0), -1, new List<string> { "equip_elbow_l", "equip_elbow_l/equip_elbow_l_135", "equip_elbow_r", "equip_elbow_r/equip_elbow_r_135" }, 100));
		_dataArray.Add(new ArmorItem(400, LocalStringManager.GetConfig("Armor_language", "Name_400"), 1, 102, 4, 396, "icon_Armor_wuchuibijia", LocalStringManager.GetConfig("Armor_language", "Desc_400"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_400"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 480, 9300, 3, 10, 4200, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 25, isSpecial: false, 2, 36, 162, new List<int>(), 4, -1, 1793, 975, 975, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 80)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(80, 0), new OuterAndInnerShorts(20, 0), -1, new List<string> { "equip_elbow_l", "equip_elbow_l/equip_elbow_l_135", "equip_elbow_r", "equip_elbow_r/equip_elbow_r_135" }, 100));
		_dataArray.Add(new ArmorItem(401, LocalStringManager.GetConfig("Armor_language", "Name_401"), 1, 102, 5, 396, "icon_Armor_woshuanghubi", LocalStringManager.GetConfig("Armor_language", "Desc_401"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_401"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 545, 16800, 4, 12, 5400, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 20, isSpecial: false, 2, 36, 162, new List<int>(), 4, -1, 1793, 1070, 1070, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 85)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(90, 0), new OuterAndInnerShorts(25, 0), -1, new List<string> { "equip_elbow_l", "equip_elbow_l/equip_elbow_l_135", "equip_elbow_r", "equip_elbow_r/equip_elbow_r_135" }, 100));
		_dataArray.Add(new ArmorItem(402, LocalStringManager.GetConfig("Armor_language", "Name_402"), 1, 102, 6, 396, "icon_Armor_chihubijia", LocalStringManager.GetConfig("Armor_language", "Desc_402"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_402"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 615, 27600, 5, 14, 7200, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 15, isSpecial: false, 2, 36, 162, new List<int>(), 4, -1, 1793, 1180, 1180, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 90)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(100, 0), new OuterAndInnerShorts(30, 0), -1, new List<string> { "equip_elbow_l", "equip_elbow_l/equip_elbow_l_139", "equip_elbow_r", "equip_elbow_r/equip_elbow_r_139" }, 100));
		_dataArray.Add(new ArmorItem(403, LocalStringManager.GetConfig("Armor_language", "Name_403"), 1, 102, 7, 396, "icon_Armor_ningchuanzhihai", LocalStringManager.GetConfig("Armor_language", "Desc_403"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_403"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 680, 42300, 6, 16, 9000, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 10, isSpecial: false, 2, 36, 162, new List<int>(), 4, -1, 1793, 1285, 1285, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 95)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(110, 0), new OuterAndInnerShorts(30, 0), -1, new List<string> { "equip_elbow_l", "equip_elbow_l/equip_elbow_l_139", "equip_elbow_r", "equip_elbow_r/equip_elbow_r_139" }, 100));
		_dataArray.Add(new ArmorItem(404, LocalStringManager.GetConfig("Armor_language", "Name_404"), 1, 102, 8, 396, "icon_Armor_xuantiebi", LocalStringManager.GetConfig("Armor_language", "Desc_404"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_404"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 750, 61500, 6, 18, 10800, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 5, isSpecial: false, 2, 36, 162, new List<int>(), 4, -1, 1793, 1400, 1400, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 100)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(120, 0), new OuterAndInnerShorts(35, 0), -1, new List<string> { "equip_elbow_l", "equip_elbow_l/equip_elbow_l_139", "equip_elbow_r", "equip_elbow_r/equip_elbow_r_139" }, 100));
		_dataArray.Add(new ArmorItem(405, LocalStringManager.GetConfig("Armor_language", "Name_405"), 1, 102, 0, 405, "icon_Armor_tonghubi", LocalStringManager.GetConfig("Armor_language", "Desc_405"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_405"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 180, 300, 0, 2, 600, 3, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 45, isSpecial: false, 2, 36, 169, new List<int>(), 4, -1, 1793, 490, 730, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 60)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(20, 20), new OuterAndInnerShorts(0, 0), -1, new List<string> { "equip_elbow_l", "equip_elbow_l/equip_elbow_l_111", "equip_elbow_r", "equip_elbow_r/equip_elbow_r_111" }, 100));
		_dataArray.Add(new ArmorItem(406, LocalStringManager.GetConfig("Armor_language", "Name_406"), 1, 102, 1, 405, "icon_Armor_yinjiyanbo", LocalStringManager.GetConfig("Armor_language", "Desc_406"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_406"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 230, 600, 0, 4, 1200, 4, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 40, isSpecial: false, 2, 36, 169, new List<int>(), 4, -1, 1793, 555, 815, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 65)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(30, 30), new OuterAndInnerShorts(0, 0), -1, new List<string> { "equip_elbow_l", "equip_elbow_l/equip_elbow_l_111", "equip_elbow_r", "equip_elbow_r/equip_elbow_r_111" }, 100));
		_dataArray.Add(new ArmorItem(407, LocalStringManager.GetConfig("Armor_language", "Name_407"), 1, 102, 2, 405, "icon_Armor_yulinxiu", LocalStringManager.GetConfig("Armor_language", "Desc_407"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_407"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 285, 1800, 1, 6, 1800, 5, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 35, isSpecial: false, 2, 36, 169, new List<int>(), 4, -1, 1793, 625, 905, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 70)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(40, 40), new OuterAndInnerShorts(0, 0), -1, new List<string> { "equip_elbow_l", "equip_elbow_l/equip_elbow_l_111", "equip_elbow_r", "equip_elbow_r/equip_elbow_r_111" }, 100));
		_dataArray.Add(new ArmorItem(408, LocalStringManager.GetConfig("Armor_language", "Name_408"), 1, 102, 3, 405, "icon_Armor_shanwenhubi", LocalStringManager.GetConfig("Armor_language", "Desc_408"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_408"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 335, 4500, 2, 8, 3000, 6, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 30, isSpecial: false, 2, 36, 169, new List<int>(), 4, -1, 1793, 690, 990, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 75)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(50, 50), new OuterAndInnerShorts(10, 10), -1, new List<string> { "equip_elbow_l", "equip_elbow_l/equip_elbow_l_115", "equip_elbow_r", "equip_elbow_r/equip_elbow_r_115" }, 100));
		_dataArray.Add(new ArmorItem(409, LocalStringManager.GetConfig("Armor_language", "Name_409"), 1, 102, 4, 405, "icon_Armor_jinguangbitao", LocalStringManager.GetConfig("Armor_language", "Desc_409"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_409"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 390, 9300, 3, 10, 4200, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 25, isSpecial: false, 2, 36, 169, new List<int>(), 4, -1, 1793, 770, 1090, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 80)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(60, 60), new OuterAndInnerShorts(10, 10), -1, new List<string> { "equip_elbow_l", "equip_elbow_l/equip_elbow_l_115", "equip_elbow_r", "equip_elbow_r/equip_elbow_r_115" }, 100));
		_dataArray.Add(new ArmorItem(410, LocalStringManager.GetConfig("Armor_language", "Name_410"), 1, 102, 5, 405, "icon_Armor_fuguangxiu", LocalStringManager.GetConfig("Armor_language", "Desc_410"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_410"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 440, 16800, 4, 12, 5400, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 20, isSpecial: false, 2, 36, 169, new List<int>(), 4, -1, 1793, 840, 1180, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 85)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(70, 70), new OuterAndInnerShorts(15, 15), -1, new List<string> { "equip_elbow_l", "equip_elbow_l/equip_elbow_l_115", "equip_elbow_r", "equip_elbow_r/equip_elbow_r_115" }, 100));
		_dataArray.Add(new ArmorItem(411, LocalStringManager.GetConfig("Armor_language", "Name_411"), 1, 102, 6, 405, "icon_Armor_liucaijinlu", LocalStringManager.GetConfig("Armor_language", "Desc_411"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_411"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 495, 27600, 5, 14, 7200, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 15, isSpecial: false, 2, 36, 169, new List<int>(), 4, -1, 1793, 925, 1285, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 90)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(80, 80), new OuterAndInnerShorts(20, 20), -1, new List<string> { "equip_elbow_l", "equip_elbow_l/equip_elbow_l_119", "equip_elbow_r", "equip_elbow_r/equip_elbow_r_119" }, 100));
		_dataArray.Add(new ArmorItem(412, LocalStringManager.GetConfig("Armor_language", "Name_412"), 1, 102, 7, 405, "icon_Armor_qingyunsuolei", LocalStringManager.GetConfig("Armor_language", "Desc_412"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_412"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 545, 42300, 6, 16, 9000, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 10, isSpecial: false, 2, 36, 169, new List<int>(), 4, -1, 1793, 1005, 1385, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 95)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(90, 90), new OuterAndInnerShorts(20, 20), -1, new List<string> { "equip_elbow_l", "equip_elbow_l/equip_elbow_l_119", "equip_elbow_r", "equip_elbow_r/equip_elbow_r_119" }, 100));
		_dataArray.Add(new ArmorItem(413, LocalStringManager.GetConfig("Armor_language", "Name_413"), 1, 102, 8, 405, "icon_Armor_jinchanbaozhuo", LocalStringManager.GetConfig("Armor_language", "Desc_413"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_413"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 100, 600, 61500, 6, 18, 10800, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 5, isSpecial: false, 2, 36, 169, new List<int>(), 4, -1, 1793, 1100, 1500, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 100)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(100, 100), new OuterAndInnerShorts(25, 25), -1, new List<string> { "equip_elbow_l", "equip_elbow_l/equip_elbow_l_119", "equip_elbow_r", "equip_elbow_r/equip_elbow_r_119" }, 100));
		_dataArray.Add(new ArmorItem(414, LocalStringManager.GetConfig("Armor_language", "Name_414"), 1, 102, 0, 414, "icon_Armor_muhuwan", LocalStringManager.GetConfig("Armor_language", "Desc_414"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_414"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 60, 70, 300, 0, 2, 600, 3, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 45, isSpecial: false, 1, 36, 163, new List<int>(), 4, -1, 1794, 215, 575, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 50)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(20, 10), new OuterAndInnerShorts(0, 0), -1, new List<string> { "equip_elbow_l", "equip_elbow_l/equip_elbow_l_231", "equip_elbow_r", "equip_elbow_r/equip_elbow_r_231" }, 100));
		_dataArray.Add(new ArmorItem(415, LocalStringManager.GetConfig("Armor_language", "Name_415"), 1, 102, 1, 414, "icon_Armor_tiemuhubi", LocalStringManager.GetConfig("Armor_language", "Desc_415"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_415"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 60, 100, 600, 0, 4, 1200, 4, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 40, isSpecial: false, 1, 36, 163, new List<int>(), 4, -1, 1794, 245, 635, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 55)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(30, 15), new OuterAndInnerShorts(0, 0), -1, new List<string> { "equip_elbow_l", "equip_elbow_l/equip_elbow_l_231", "equip_elbow_r", "equip_elbow_r/equip_elbow_r_231" }, 100));
		_dataArray.Add(new ArmorItem(416, LocalStringManager.GetConfig("Armor_language", "Name_416"), 1, 102, 2, 414, "icon_Armor_hufuchanbi", LocalStringManager.GetConfig("Armor_language", "Desc_416"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_416"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 60, 130, 1800, 1, 6, 1800, 5, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 35, isSpecial: false, 1, 36, 163, new List<int>(), 4, -1, 1794, 285, 705, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 60)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(40, 20), new OuterAndInnerShorts(10, 0), -1, new List<string> { "equip_elbow_l", "equip_elbow_l/equip_elbow_l_231", "equip_elbow_r", "equip_elbow_r/equip_elbow_r_231" }, 100));
		_dataArray.Add(new ArmorItem(417, LocalStringManager.GetConfig("Armor_language", "Name_417"), 1, 102, 3, 414, "icon_Armor_xiangdiaobihuan", LocalStringManager.GetConfig("Armor_language", "Desc_417"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_417"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 60, 160, 4500, 2, 8, 3000, 6, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 30, isSpecial: false, 1, 36, 163, new List<int>(), 4, -1, 1794, 325, 775, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 65)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(50, 25), new OuterAndInnerShorts(10, 0), -1, new List<string> { "equip_elbow_l", "equip_elbow_l/equip_elbow_l_235", "equip_elbow_r", "equip_elbow_r/equip_elbow_r_235" }, 100));
		_dataArray.Add(new ArmorItem(418, LocalStringManager.GetConfig("Armor_language", "Name_418"), 1, 102, 4, 414, "icon_Armor_guishouhubo", LocalStringManager.GetConfig("Armor_language", "Desc_418"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_418"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 60, 190, 9300, 3, 10, 4200, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 25, isSpecial: false, 1, 36, 163, new List<int>(), 4, -1, 1794, 370, 850, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 70)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(60, 30), new OuterAndInnerShorts(15, 0), -1, new List<string> { "equip_elbow_l", "equip_elbow_l/equip_elbow_l_235", "equip_elbow_r", "equip_elbow_r/equip_elbow_r_235" }, 100));
		_dataArray.Add(new ArmorItem(419, LocalStringManager.GetConfig("Armor_language", "Name_419"), 1, 102, 5, 414, "icon_Armor_shiwangbijia", LocalStringManager.GetConfig("Armor_language", "Desc_419"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_419"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 60, 220, 16800, 4, 12, 5400, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 20, isSpecial: false, 1, 36, 163, new List<int>(), 4, -1, 1794, 410, 920, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 75)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(70, 35), new OuterAndInnerShorts(20, 0), -1, new List<string> { "equip_elbow_l", "equip_elbow_l/equip_elbow_l_235", "equip_elbow_r", "equip_elbow_r/equip_elbow_r_235" }, 100));
	}

	private void CreateItems7()
	{
		_dataArray.Add(new ArmorItem(420, LocalStringManager.GetConfig("Armor_language", "Name_420"), 1, 102, 6, 414, "icon_Armor_dingyijiangmohuan", LocalStringManager.GetConfig("Armor_language", "Desc_420"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_420"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 60, 250, 27600, 5, 14, 7200, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 15, isSpecial: false, 1, 36, 163, new List<int>(), 4, -1, 1794, 460, 1000, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 80)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(80, 40), new OuterAndInnerShorts(20, 0), -1, new List<string> { "equip_elbow_l", "equip_elbow_l/equip_elbow_l_239", "equip_elbow_r", "equip_elbow_r/equip_elbow_r_239" }, 100));
		_dataArray.Add(new ArmorItem(421, LocalStringManager.GetConfig("Armor_language", "Name_421"), 1, 102, 7, 414, "icon_Armor_wuzhifoguang", LocalStringManager.GetConfig("Armor_language", "Desc_421"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_421"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 60, 280, 42300, 6, 16, 9000, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 10, isSpecial: false, 1, 36, 163, new List<int>(), 4, -1, 1794, 505, 1075, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 85)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(90, 45), new OuterAndInnerShorts(25, 0), -1, new List<string> { "equip_elbow_l", "equip_elbow_l/equip_elbow_l_239", "equip_elbow_r", "equip_elbow_r/equip_elbow_r_239" }, 100));
		_dataArray.Add(new ArmorItem(422, LocalStringManager.GetConfig("Armor_language", "Name_422"), 1, 102, 8, 414, "icon_Armor_yuanjiaohuan", LocalStringManager.GetConfig("Armor_language", "Desc_422"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_422"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 60, 310, 61500, 6, 18, 10800, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 5, isSpecial: false, 1, 36, 163, new List<int>(), 4, -1, 1794, 560, 1160, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 90)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(100, 50), new OuterAndInnerShorts(30, 0), -1, new List<string> { "equip_elbow_l", "equip_elbow_l/equip_elbow_l_239", "equip_elbow_r", "equip_elbow_r/equip_elbow_r_239" }, 100));
		_dataArray.Add(new ArmorItem(423, LocalStringManager.GetConfig("Armor_language", "Name_423"), 1, 102, 0, 423, "icon_Armor_zhutiaotuo", LocalStringManager.GetConfig("Armor_language", "Desc_423"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_423"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 60, 45, 300, 0, 2, 600, 3, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 45, isSpecial: false, 1, 36, 170, new List<int>(), 4, -1, 1794, 265, 505, new List<PropertyAndValue>
		{
			new PropertyAndValue(4, 50)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(10, 20), new OuterAndInnerShorts(0, 0), -1, new List<string> { "equip_elbow_l", "equip_elbow_l/equip_elbow_l_211", "equip_elbow_r", "equip_elbow_r/equip_elbow_r_211" }, 100));
		_dataArray.Add(new ArmorItem(424, LocalStringManager.GetConfig("Armor_language", "Name_424"), 1, 102, 1, 423, "icon_Armor_anshenwanhuan", LocalStringManager.GetConfig("Armor_language", "Desc_424"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_424"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 60, 70, 600, 0, 4, 1200, 4, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 40, isSpecial: false, 1, 36, 170, new List<int>(), 4, -1, 1794, 300, 560, new List<PropertyAndValue>
		{
			new PropertyAndValue(4, 55)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(15, 30), new OuterAndInnerShorts(0, 0), -1, new List<string> { "equip_elbow_l", "equip_elbow_l/equip_elbow_l_211", "equip_elbow_r", "equip_elbow_r/equip_elbow_r_211" }, 100));
		_dataArray.Add(new ArmorItem(425, LocalStringManager.GetConfig("Armor_language", "Name_425"), 1, 102, 2, 423, "icon_Armor_lingshezhuo", LocalStringManager.GetConfig("Armor_language", "Desc_425"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_425"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 60, 95, 1800, 1, 6, 1800, 5, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 35, isSpecial: false, 1, 36, 170, new List<int>(), 4, -1, 1794, 335, 615, new List<PropertyAndValue>
		{
			new PropertyAndValue(4, 60)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(20, 40), new OuterAndInnerShorts(0, 10), -1, new List<string> { "equip_elbow_l", "equip_elbow_l/equip_elbow_l_211", "equip_elbow_r", "equip_elbow_r/equip_elbow_r_211" }, 100));
		_dataArray.Add(new ArmorItem(426, LocalStringManager.GetConfig("Armor_language", "Name_426"), 1, 102, 3, 423, "icon_Armor_hewenhushou", LocalStringManager.GetConfig("Armor_language", "Desc_426"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_426"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 60, 120, 4500, 2, 8, 3000, 6, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 30, isSpecial: false, 1, 36, 170, new List<int>(), 4, -1, 1794, 375, 675, new List<PropertyAndValue>
		{
			new PropertyAndValue(4, 65)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(25, 50), new OuterAndInnerShorts(0, 10), -1, new List<string> { "equip_elbow_l", "equip_elbow_l/equip_elbow_l_215", "equip_elbow_r", "equip_elbow_r/equip_elbow_r_215" }, 100));
		_dataArray.Add(new ArmorItem(427, LocalStringManager.GetConfig("Armor_language", "Name_427"), 1, 102, 4, 423, "icon_Armor_putishouchuan", LocalStringManager.GetConfig("Armor_language", "Desc_427"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_427"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 60, 140, 9300, 3, 10, 4200, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 25, isSpecial: false, 1, 36, 170, new List<int>(), 4, -1, 1794, 415, 735, new List<PropertyAndValue>
		{
			new PropertyAndValue(4, 70)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(30, 60), new OuterAndInnerShorts(0, 15), -1, new List<string> { "equip_elbow_l", "equip_elbow_l/equip_elbow_l_215", "equip_elbow_r", "equip_elbow_r/equip_elbow_r_215" }, 100));
		_dataArray.Add(new ArmorItem(428, LocalStringManager.GetConfig("Armor_language", "Name_428"), 1, 102, 5, 423, "icon_Armor_xiezhihubi", LocalStringManager.GetConfig("Armor_language", "Desc_428"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_428"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 60, 165, 16800, 4, 12, 5400, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 20, isSpecial: false, 1, 36, 170, new List<int>(), 4, -1, 1794, 460, 800, new List<PropertyAndValue>
		{
			new PropertyAndValue(4, 75)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(35, 70), new OuterAndInnerShorts(0, 20), -1, new List<string> { "equip_elbow_l", "equip_elbow_l/equip_elbow_l_215", "equip_elbow_r", "equip_elbow_r/equip_elbow_r_215" }, 100));
		_dataArray.Add(new ArmorItem(429, LocalStringManager.GetConfig("Armor_language", "Name_429"), 1, 102, 6, 423, "icon_Armor_sandiwanhuan", LocalStringManager.GetConfig("Armor_language", "Desc_429"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_429"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 60, 190, 27600, 5, 14, 7200, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 15, isSpecial: false, 1, 36, 170, new List<int>(), 4, -1, 1794, 505, 865, new List<PropertyAndValue>
		{
			new PropertyAndValue(4, 80)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(40, 80), new OuterAndInnerShorts(0, 20), -1, new List<string> { "equip_elbow_l", "equip_elbow_l/equip_elbow_l_219", "equip_elbow_r", "equip_elbow_r/equip_elbow_r_219" }, 100));
		_dataArray.Add(new ArmorItem(430, LocalStringManager.GetConfig("Armor_language", "Name_430"), 1, 102, 7, 423, "icon_Armor_longhuachuan", LocalStringManager.GetConfig("Armor_language", "Desc_430"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_430"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 60, 215, 42300, 6, 16, 9000, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 10, isSpecial: false, 1, 36, 170, new List<int>(), 4, -1, 1794, 550, 930, new List<PropertyAndValue>
		{
			new PropertyAndValue(4, 85)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(45, 90), new OuterAndInnerShorts(0, 25), -1, new List<string> { "equip_elbow_l", "equip_elbow_l/equip_elbow_l_219", "equip_elbow_r", "equip_elbow_r/equip_elbow_r_219" }, 100));
		_dataArray.Add(new ArmorItem(431, LocalStringManager.GetConfig("Armor_language", "Name_431"), 1, 102, 8, 423, "icon_Armor_wuzhuxin", LocalStringManager.GetConfig("Armor_language", "Desc_431"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_431"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 60, 240, 61500, 6, 18, 10800, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 5, isSpecial: false, 1, 36, 170, new List<int>(), 4, -1, 1794, 600, 1000, new List<PropertyAndValue>
		{
			new PropertyAndValue(4, 90)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(50, 100), new OuterAndInnerShorts(0, 30), -1, new List<string> { "equip_elbow_l", "equip_elbow_l/equip_elbow_l_219", "equip_elbow_r", "equip_elbow_r/equip_elbow_r_219" }, 100));
		_dataArray.Add(new ArmorItem(432, LocalStringManager.GetConfig("Armor_language", "Name_432"), 1, 102, 0, 432, "icon_Armor_shoupipibo", LocalStringManager.GetConfig("Armor_language", "Desc_432"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_432"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 60, 300, 0, 2, 600, 3, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 45, isSpecial: false, 4, 36, 166, new List<int>(), 4, -1, 1796, 155, 395, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 20),
			new PropertyAndValue(3, 20)
		}, new HitOrAvoidShorts(20, 0, 0, 0), new OuterAndInnerShorts(20, 0), new OuterAndInnerShorts(0, 0), -1, new List<string> { "sleeve_l/sleeve_l_weapon", "sleeve_l/sleeve_l_121", "sleeve_r/sleeve_r_weapon", "sleeve_r/sleeve_r_121" }, 100));
		_dataArray.Add(new ArmorItem(433, LocalStringManager.GetConfig("Armor_language", "Name_433"), 1, 102, 1, 432, "icon_Armor_manronghubi", LocalStringManager.GetConfig("Armor_language", "Desc_433"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_433"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 65, 600, 0, 4, 1200, 4, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 40, isSpecial: false, 4, 36, 166, new List<int>(), 4, -1, 1796, 170, 430, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 25),
			new PropertyAndValue(3, 25)
		}, new HitOrAvoidShorts(20, 0, 0, 0), new OuterAndInnerShorts(30, 0), new OuterAndInnerShorts(0, 0), -1, new List<string> { "sleeve_l/sleeve_l_weapon", "sleeve_l/sleeve_l_121", "sleeve_r/sleeve_r_weapon", "sleeve_r/sleeve_r_121" }, 100));
		_dataArray.Add(new ArmorItem(434, LocalStringManager.GetConfig("Armor_language", "Name_434"), 1, 102, 2, 432, "icon_Armor_shouwanghubi", LocalStringManager.GetConfig("Armor_language", "Desc_434"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_434"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 70, 1800, 1, 6, 1800, 5, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 35, isSpecial: false, 4, 36, 166, new List<int>(), 4, -1, 1796, 190, 470, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 30),
			new PropertyAndValue(3, 30)
		}, new HitOrAvoidShorts(20, 0, 0, 0), new OuterAndInnerShorts(40, 0), new OuterAndInnerShorts(0, 0), -1, new List<string> { "sleeve_l/sleeve_l_weapon", "sleeve_l/sleeve_l_121", "sleeve_r/sleeve_r_weapon", "sleeve_r/sleeve_r_121" }, 100));
		_dataArray.Add(new ArmorItem(435, LocalStringManager.GetConfig("Armor_language", "Name_435"), 1, 102, 3, 432, "icon_Armor_fengweibijia", LocalStringManager.GetConfig("Armor_language", "Desc_435"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_435"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 75, 4500, 2, 8, 3000, 6, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 30, isSpecial: false, 4, 36, 166, new List<int>(), 4, -1, 1796, 205, 505, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 35),
			new PropertyAndValue(3, 35)
		}, new HitOrAvoidShorts(25, 0, 0, 0), new OuterAndInnerShorts(50, 0), new OuterAndInnerShorts(0, 0), -1, new List<string> { "sleeve_l/sleeve_l_weapon", "sleeve_l/sleeve_l_125", "sleeve_r/sleeve_r_weapon", "sleeve_r/sleeve_r_125" }, 100));
		_dataArray.Add(new ArmorItem(436, LocalStringManager.GetConfig("Armor_language", "Name_436"), 1, 102, 4, 432, "icon_Armor_qingxihubi", LocalStringManager.GetConfig("Armor_language", "Desc_436"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_436"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 80, 9300, 3, 10, 4200, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 25, isSpecial: false, 4, 36, 166, new List<int>(), 4, -1, 1796, 225, 545, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 40),
			new PropertyAndValue(3, 40)
		}, new HitOrAvoidShorts(25, 0, 0, 0), new OuterAndInnerShorts(60, 0), new OuterAndInnerShorts(0, 0), -1, new List<string> { "sleeve_l/sleeve_l_weapon", "sleeve_l/sleeve_l_125", "sleeve_r/sleeve_r_weapon", "sleeve_r/sleeve_r_125" }, 100));
		_dataArray.Add(new ArmorItem(437, LocalStringManager.GetConfig("Armor_language", "Name_437"), 1, 102, 5, 432, "icon_Armor_zhouyingluoxiu", LocalStringManager.GetConfig("Armor_language", "Desc_437"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_437"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 85, 16800, 4, 12, 5400, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 20, isSpecial: false, 4, 36, 166, new List<int>(), 4, -1, 1796, 240, 580, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 45),
			new PropertyAndValue(3, 45)
		}, new HitOrAvoidShorts(25, 0, 0, 0), new OuterAndInnerShorts(70, 0), new OuterAndInnerShorts(0, 0), -1, new List<string> { "sleeve_l/sleeve_l_weapon", "sleeve_l/sleeve_l_125", "sleeve_r/sleeve_r_weapon", "sleeve_r/sleeve_r_125" }, 100));
		_dataArray.Add(new ArmorItem(438, LocalStringManager.GetConfig("Armor_language", "Name_438"), 1, 102, 6, 432, "icon_Armor_longweihushou", LocalStringManager.GetConfig("Armor_language", "Desc_438"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_438"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 90, 27600, 5, 14, 7200, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 15, isSpecial: false, 4, 36, 166, new List<int>(), 4, -1, 1796, 260, 620, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 50),
			new PropertyAndValue(3, 50)
		}, new HitOrAvoidShorts(30, 0, 0, 0), new OuterAndInnerShorts(80, 0), new OuterAndInnerShorts(0, 0), -1, new List<string> { "sleeve_l/sleeve_l_weapon", "sleeve_l/sleeve_l_129", "sleeve_r/sleeve_r_weapon", "sleeve_r/sleeve_r_129" }, 100));
		_dataArray.Add(new ArmorItem(439, LocalStringManager.GetConfig("Armor_language", "Name_439"), 1, 102, 7, 432, "icon_Armor_xuanfengxiu", LocalStringManager.GetConfig("Armor_language", "Desc_439"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_439"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 95, 42300, 6, 16, 9000, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 10, isSpecial: false, 4, 36, 166, new List<int>(), 4, -1, 1796, 275, 655, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 55),
			new PropertyAndValue(3, 55)
		}, new HitOrAvoidShorts(30, 0, 0, 0), new OuterAndInnerShorts(90, 0), new OuterAndInnerShorts(0, 0), -1, new List<string> { "sleeve_l/sleeve_l_weapon", "sleeve_l/sleeve_l_129", "sleeve_r/sleeve_r_weapon", "sleeve_r/sleeve_r_129" }, 100));
		_dataArray.Add(new ArmorItem(440, LocalStringManager.GetConfig("Armor_language", "Name_440"), 1, 102, 8, 432, "icon_Armor_jiexingbijia", LocalStringManager.GetConfig("Armor_language", "Desc_440"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_440"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 100, 61500, 6, 18, 10800, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 5, isSpecial: false, 4, 36, 166, new List<int>(), 4, -1, 1796, 300, 700, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 60),
			new PropertyAndValue(3, 60)
		}, new HitOrAvoidShorts(30, 0, 0, 0), new OuterAndInnerShorts(100, 0), new OuterAndInnerShorts(0, 0), -1, new List<string> { "sleeve_l/sleeve_l_weapon", "sleeve_l/sleeve_l_129", "sleeve_r/sleeve_r_weapon", "sleeve_r/sleeve_r_129" }, 100));
		_dataArray.Add(new ArmorItem(441, LocalStringManager.GetConfig("Armor_language", "Name_441"), 1, 102, 0, 441, "icon_Armor_shupichanbi", LocalStringManager.GetConfig("Armor_language", "Desc_441"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_441"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 100, 300, 0, 2, 600, 3, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 45, isSpecial: false, 4, 36, 168, new List<int>(), 4, -1, 1796, 180, 540, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 20),
			new PropertyAndValue(3, 20)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(20, 0), new OuterAndInnerShorts(10, 0), -1, new List<string> { "sleeve_l/sleeve_l_weapon", "sleeve_l/sleeve_l_131", "sleeve_r/sleeve_r_weapon", "sleeve_r/sleeve_r_131" }, 100));
		_dataArray.Add(new ArmorItem(442, LocalStringManager.GetConfig("Armor_language", "Name_442"), 1, 102, 1, 441, "icon_Armor_piqiuhubi", LocalStringManager.GetConfig("Armor_language", "Desc_442"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_442"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 110, 600, 0, 4, 1200, 4, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 40, isSpecial: false, 4, 36, 168, new List<int>(), 4, -1, 1796, 200, 590, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 25),
			new PropertyAndValue(3, 25)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(25, 0), new OuterAndInnerShorts(10, 0), -1, new List<string> { "sleeve_l/sleeve_l_weapon", "sleeve_l/sleeve_l_131", "sleeve_r/sleeve_r_weapon", "sleeve_r/sleeve_r_131" }, 100));
		_dataArray.Add(new ArmorItem(443, LocalStringManager.GetConfig("Armor_language", "Name_443"), 1, 102, 2, 441, "icon_Armor_zulianbijia", LocalStringManager.GetConfig("Armor_language", "Desc_443"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_443"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 120, 1800, 1, 6, 1800, 5, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 35, isSpecial: false, 4, 36, 168, new List<int>(), 4, -1, 1796, 225, 645, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 30),
			new PropertyAndValue(3, 30)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(30, 0), new OuterAndInnerShorts(15, 0), -1, new List<string> { "sleeve_l/sleeve_l_weapon", "sleeve_l/sleeve_l_131", "sleeve_r/sleeve_r_weapon", "sleeve_r/sleeve_r_131" }, 100));
		_dataArray.Add(new ArmorItem(444, LocalStringManager.GetConfig("Armor_language", "Name_444"), 1, 102, 3, 441, "icon_Armor_mangwenyanbi", LocalStringManager.GetConfig("Armor_language", "Desc_444"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_444"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 130, 4500, 2, 8, 3000, 6, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 30, isSpecial: false, 4, 36, 168, new List<int>(), 4, -1, 1796, 250, 700, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 35),
			new PropertyAndValue(3, 35)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(35, 0), new OuterAndInnerShorts(20, 0), -1, new List<string> { "sleeve_l/sleeve_l_weapon", "sleeve_l/sleeve_l_135", "sleeve_r/sleeve_r_weapon", "sleeve_r/sleeve_r_135" }, 100));
		_dataArray.Add(new ArmorItem(445, LocalStringManager.GetConfig("Armor_language", "Name_445"), 1, 102, 4, 441, "icon_Armor_qushuihuwan", LocalStringManager.GetConfig("Armor_language", "Desc_445"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_445"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 140, 9300, 3, 10, 4200, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 25, isSpecial: false, 4, 36, 168, new List<int>(), 4, -1, 1796, 270, 750, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 40),
			new PropertyAndValue(3, 40)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(40, 0), new OuterAndInnerShorts(20, 0), -1, new List<string> { "sleeve_l/sleeve_l_weapon", "sleeve_l/sleeve_l_135", "sleeve_r/sleeve_r_weapon", "sleeve_r/sleeve_r_135" }, 100));
		_dataArray.Add(new ArmorItem(446, LocalStringManager.GetConfig("Armor_language", "Name_446"), 1, 102, 5, 441, "icon_Armor_baoxiangzhongjinwan", LocalStringManager.GetConfig("Armor_language", "Desc_446"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_446"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 150, 16800, 4, 12, 5400, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 20, isSpecial: false, 4, 36, 168, new List<int>(), 4, -1, 1796, 300, 810, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 45),
			new PropertyAndValue(3, 45)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(45, 0), new OuterAndInnerShorts(25, 0), -1, new List<string> { "sleeve_l/sleeve_l_weapon", "sleeve_l/sleeve_l_135", "sleeve_r/sleeve_r_weapon", "sleeve_r/sleeve_r_135" }, 100));
		_dataArray.Add(new ArmorItem(447, LocalStringManager.GetConfig("Armor_language", "Name_447"), 1, 102, 6, 441, "icon_Armor_kuiniubijia", LocalStringManager.GetConfig("Armor_language", "Desc_447"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_447"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 160, 27600, 5, 14, 7200, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 15, isSpecial: false, 4, 36, 168, new List<int>(), 4, -1, 1796, 325, 865, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 50),
			new PropertyAndValue(3, 50)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(50, 0), new OuterAndInnerShorts(30, 0), -1, new List<string> { "sleeve_l/sleeve_l_weapon", "sleeve_l/sleeve_l_139", "sleeve_r/sleeve_r_weapon", "sleeve_r/sleeve_r_139" }, 100));
		_dataArray.Add(new ArmorItem(448, LocalStringManager.GetConfig("Armor_language", "Name_448"), 1, 102, 7, 441, "icon_Armor_fuyunhubi", LocalStringManager.GetConfig("Armor_language", "Desc_448"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_448"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 170, 42300, 6, 16, 9000, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 10, isSpecial: false, 4, 36, 168, new List<int>(), 4, -1, 1796, 350, 920, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 55),
			new PropertyAndValue(3, 55)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(55, 0), new OuterAndInnerShorts(30, 0), -1, new List<string> { "sleeve_l/sleeve_l_weapon", "sleeve_l/sleeve_l_139", "sleeve_r/sleeve_r_weapon", "sleeve_r/sleeve_r_139" }, 100));
		_dataArray.Add(new ArmorItem(449, LocalStringManager.GetConfig("Armor_language", "Name_449"), 1, 102, 8, 441, "icon_Armor_xinghehuaying", LocalStringManager.GetConfig("Armor_language", "Desc_449"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_449"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 180, 61500, 6, 18, 10800, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 5, isSpecial: false, 4, 36, 168, new List<int>(), 4, -1, 1796, 380, 980, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 60),
			new PropertyAndValue(3, 60)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(60, 0), new OuterAndInnerShorts(35, 0), -1, new List<string> { "sleeve_l/sleeve_l_weapon", "sleeve_l/sleeve_l_139", "sleeve_r/sleeve_r_weapon", "sleeve_r/sleeve_r_139" }, 100));
		_dataArray.Add(new ArmorItem(450, LocalStringManager.GetConfig("Armor_language", "Name_450"), 1, 102, 0, 450, "icon_Armor_ruanpibitao", LocalStringManager.GetConfig("Armor_language", "Desc_450"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_450"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 80, 300, 0, 2, 600, 3, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 45, isSpecial: false, 4, 36, 167, new List<int>(), 4, -1, 1796, 170, 410, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 20),
			new PropertyAndValue(4, 20)
		}, new HitOrAvoidShorts(0, 20, 0, 0), new OuterAndInnerShorts(20, 0), new OuterAndInnerShorts(0, 0), -1, new List<string> { "sleeve_l/sleeve_l_weapon", "sleeve_l/sleeve_l_131", "sleeve_r/sleeve_r_weapon", "sleeve_r/sleeve_r_131" }, 100));
		_dataArray.Add(new ArmorItem(451, LocalStringManager.GetConfig("Armor_language", "Name_451"), 1, 102, 1, 450, "icon_Armor_jiaronghubi", LocalStringManager.GetConfig("Armor_language", "Desc_451"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_451"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 85, 600, 0, 4, 1200, 4, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 40, isSpecial: false, 4, 36, 167, new List<int>(), 4, -1, 1796, 180, 440, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 25),
			new PropertyAndValue(4, 25)
		}, new HitOrAvoidShorts(0, 20, 0, 0), new OuterAndInnerShorts(30, 0), new OuterAndInnerShorts(0, 0), -1, new List<string> { "sleeve_l/sleeve_l_weapon", "sleeve_l/sleeve_l_131", "sleeve_r/sleeve_r_weapon", "sleeve_r/sleeve_r_131" }, 100));
		_dataArray.Add(new ArmorItem(452, LocalStringManager.GetConfig("Armor_language", "Name_452"), 1, 102, 2, 450, "icon_Armor_guiwenhubi", LocalStringManager.GetConfig("Armor_language", "Desc_452"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_452"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 90, 1800, 1, 6, 1800, 5, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 35, isSpecial: false, 4, 36, 167, new List<int>(), 4, -1, 1796, 205, 485, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 30),
			new PropertyAndValue(4, 30)
		}, new HitOrAvoidShorts(0, 20, 0, 0), new OuterAndInnerShorts(40, 0), new OuterAndInnerShorts(0, 0), -1, new List<string> { "sleeve_l/sleeve_l_weapon", "sleeve_l/sleeve_l_131", "sleeve_r/sleeve_r_weapon", "sleeve_r/sleeve_r_131" }, 100));
		_dataArray.Add(new ArmorItem(453, LocalStringManager.GetConfig("Armor_language", "Name_453"), 1, 102, 3, 450, "icon_Armor_baiyegebi", LocalStringManager.GetConfig("Armor_language", "Desc_453"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_453"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 95, 4500, 2, 8, 3000, 6, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 30, isSpecial: false, 4, 36, 167, new List<int>(), 4, -1, 1796, 220, 520, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 35),
			new PropertyAndValue(4, 35)
		}, new HitOrAvoidShorts(0, 25, 0, 0), new OuterAndInnerShorts(50, 0), new OuterAndInnerShorts(0, 0), -1, new List<string> { "sleeve_l/sleeve_l_weapon", "sleeve_l/sleeve_l_135", "sleeve_r/sleeve_r_weapon", "sleeve_r/sleeve_r_135" }, 100));
		_dataArray.Add(new ArmorItem(454, LocalStringManager.GetConfig("Armor_language", "Name_454"), 1, 102, 4, 450, "icon_Armor_jipijiaobi", LocalStringManager.GetConfig("Armor_language", "Desc_454"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_454"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 100, 9300, 3, 10, 4200, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 25, isSpecial: false, 4, 36, 167, new List<int>(), 4, -1, 1796, 240, 560, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 40),
			new PropertyAndValue(4, 40)
		}, new HitOrAvoidShorts(0, 25, 0, 0), new OuterAndInnerShorts(60, 0), new OuterAndInnerShorts(0, 0), -1, new List<string> { "sleeve_l/sleeve_l_weapon", "sleeve_l/sleeve_l_135", "sleeve_r/sleeve_r_weapon", "sleeve_r/sleeve_r_135" }, 100));
		_dataArray.Add(new ArmorItem(455, LocalStringManager.GetConfig("Armor_language", "Name_455"), 1, 102, 5, 450, "icon_Armor_qigelianzhubi", LocalStringManager.GetConfig("Armor_language", "Desc_455"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_455"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 105, 16800, 4, 12, 5400, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 20, isSpecial: false, 4, 36, 167, new List<int>(), 4, -1, 1796, 255, 595, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 45),
			new PropertyAndValue(4, 45)
		}, new HitOrAvoidShorts(0, 25, 0, 0), new OuterAndInnerShorts(70, 0), new OuterAndInnerShorts(0, 0), -1, new List<string> { "sleeve_l/sleeve_l_weapon", "sleeve_l/sleeve_l_135", "sleeve_r/sleeve_r_weapon", "sleeve_r/sleeve_r_135" }, 100));
		_dataArray.Add(new ArmorItem(456, LocalStringManager.GetConfig("Armor_language", "Name_456"), 1, 102, 6, 450, "icon_Armor_xuanlubaopibo", LocalStringManager.GetConfig("Armor_language", "Desc_456"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_456"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 110, 27600, 5, 14, 7200, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 15, isSpecial: false, 4, 36, 167, new List<int>(), 4, -1, 1796, 280, 640, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 50),
			new PropertyAndValue(4, 50)
		}, new HitOrAvoidShorts(0, 30, 0, 0), new OuterAndInnerShorts(80, 0), new OuterAndInnerShorts(0, 0), -1, new List<string> { "sleeve_l/sleeve_l_weapon", "sleeve_l/sleeve_l_139", "sleeve_r/sleeve_r_weapon", "sleeve_r/sleeve_r_139" }, 100));
		_dataArray.Add(new ArmorItem(457, LocalStringManager.GetConfig("Armor_language", "Name_457"), 1, 102, 7, 450, "icon_Armor_duanyanxia", LocalStringManager.GetConfig("Armor_language", "Desc_457"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_457"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 115, 42300, 6, 16, 9000, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 10, isSpecial: false, 4, 36, 167, new List<int>(), 4, -1, 1796, 295, 675, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 55),
			new PropertyAndValue(4, 55)
		}, new HitOrAvoidShorts(0, 30, 0, 0), new OuterAndInnerShorts(90, 0), new OuterAndInnerShorts(0, 0), -1, new List<string> { "sleeve_l/sleeve_l_weapon", "sleeve_l/sleeve_l_139", "sleeve_r/sleeve_r_weapon", "sleeve_r/sleeve_r_139" }, 100));
		_dataArray.Add(new ArmorItem(458, LocalStringManager.GetConfig("Armor_language", "Name_458"), 1, 102, 8, 450, "icon_Armor_qifowanbi", LocalStringManager.GetConfig("Armor_language", "Desc_458"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_458"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 120, 61500, 6, 18, 10800, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 5, isSpecial: false, 4, 36, 167, new List<int>(), 4, -1, 1796, 320, 720, new List<PropertyAndValue>
		{
			new PropertyAndValue(0, 60),
			new PropertyAndValue(4, 60)
		}, new HitOrAvoidShorts(0, 30, 0, 0), new OuterAndInnerShorts(100, 0), new OuterAndInnerShorts(0, 0), -1, new List<string> { "sleeve_l/sleeve_l_weapon", "sleeve_l/sleeve_l_139", "sleeve_r/sleeve_r_weapon", "sleeve_r/sleeve_r_139" }, 100));
		_dataArray.Add(new ArmorItem(459, LocalStringManager.GetConfig("Armor_language", "Name_459"), 1, 102, 0, 459, "icon_Armor_gedaihuwan", LocalStringManager.GetConfig("Armor_language", "Desc_459"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_459"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 60, 300, 0, 2, 600, 3, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 45, isSpecial: false, 4, 36, 165, new List<int>(), 4, -1, 1796, 155, 395, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 20),
			new PropertyAndValue(4, 20)
		}, new HitOrAvoidShorts(0, 0, 20, 0), new OuterAndInnerShorts(20, 0), new OuterAndInnerShorts(0, 0), -1, new List<string> { "sleeve_l/sleeve_l_weapon", "sleeve_l/sleeve_l_111", "sleeve_r/sleeve_r_weapon", "sleeve_r/sleeve_r_111" }, 100));
		_dataArray.Add(new ArmorItem(460, LocalStringManager.GetConfig("Armor_language", "Name_460"), 1, 102, 1, 459, "icon_Armor_yinggebitao", LocalStringManager.GetConfig("Armor_language", "Desc_460"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_460"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 60, 600, 0, 4, 1200, 4, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 40, isSpecial: false, 4, 36, 165, new List<int>(), 4, -1, 1796, 170, 430, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 25),
			new PropertyAndValue(4, 25)
		}, new HitOrAvoidShorts(0, 0, 20, 0), new OuterAndInnerShorts(30, 0), new OuterAndInnerShorts(0, 0), -1, new List<string> { "sleeve_l/sleeve_l_weapon", "sleeve_l/sleeve_l_111", "sleeve_r/sleeve_r_weapon", "sleeve_r/sleeve_r_111" }, 100));
		_dataArray.Add(new ArmorItem(461, LocalStringManager.GetConfig("Armor_language", "Name_461"), 1, 102, 2, 459, "icon_Armor_songwenbijia", LocalStringManager.GetConfig("Armor_language", "Desc_461"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_461"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 60, 1800, 1, 6, 1800, 5, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 35, isSpecial: false, 4, 36, 165, new List<int>(), 4, -1, 1796, 180, 460, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 30),
			new PropertyAndValue(4, 30)
		}, new HitOrAvoidShorts(0, 0, 20, 0), new OuterAndInnerShorts(40, 0), new OuterAndInnerShorts(0, 0), -1, new List<string> { "sleeve_l/sleeve_l_weapon", "sleeve_l/sleeve_l_111", "sleeve_r/sleeve_r_weapon", "sleeve_r/sleeve_r_111" }, 100));
		_dataArray.Add(new ArmorItem(462, LocalStringManager.GetConfig("Armor_language", "Name_462"), 1, 102, 3, 459, "icon_Armor_suiyunbitao", LocalStringManager.GetConfig("Armor_language", "Desc_462"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_462"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 60, 4500, 2, 8, 3000, 6, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 30, isSpecial: false, 4, 36, 165, new List<int>(), 4, -1, 1796, 195, 495, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 35),
			new PropertyAndValue(4, 35)
		}, new HitOrAvoidShorts(0, 0, 25, 0), new OuterAndInnerShorts(50, 0), new OuterAndInnerShorts(0, 0), -1, new List<string> { "sleeve_l/sleeve_l_weapon", "sleeve_l/sleeve_l_115", "sleeve_r/sleeve_r_weapon", "sleeve_r/sleeve_r_115" }, 100));
		_dataArray.Add(new ArmorItem(463, LocalStringManager.GetConfig("Armor_language", "Name_463"), 1, 102, 4, 459, "icon_Armor_loujinluobi", LocalStringManager.GetConfig("Armor_language", "Desc_463"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_463"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 60, 9300, 3, 10, 4200, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 25, isSpecial: false, 4, 36, 165, new List<int>(), 4, -1, 1796, 210, 530, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 40),
			new PropertyAndValue(4, 40)
		}, new HitOrAvoidShorts(0, 0, 25, 0), new OuterAndInnerShorts(60, 0), new OuterAndInnerShorts(0, 0), -1, new List<string> { "sleeve_l/sleeve_l_weapon", "sleeve_l/sleeve_l_115", "sleeve_r/sleeve_r_weapon", "sleeve_r/sleeve_r_115" }, 100));
		_dataArray.Add(new ArmorItem(464, LocalStringManager.GetConfig("Armor_language", "Name_464"), 1, 102, 5, 459, "icon_Armor_liuxiajinwan", LocalStringManager.GetConfig("Armor_language", "Desc_464"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_464"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 60, 16800, 4, 12, 5400, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 20, isSpecial: false, 4, 36, 165, new List<int>(), 4, -1, 1796, 220, 560, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 45),
			new PropertyAndValue(4, 45)
		}, new HitOrAvoidShorts(0, 0, 25, 0), new OuterAndInnerShorts(70, 0), new OuterAndInnerShorts(0, 0), -1, new List<string> { "sleeve_l/sleeve_l_weapon", "sleeve_l/sleeve_l_115", "sleeve_r/sleeve_r_weapon", "sleeve_r/sleeve_r_115" }, 100));
		_dataArray.Add(new ArmorItem(465, LocalStringManager.GetConfig("Armor_language", "Name_465"), 1, 102, 6, 459, "icon_Armor_wusejianlingxiu", LocalStringManager.GetConfig("Armor_language", "Desc_465"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_465"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 60, 27600, 5, 14, 7200, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 15, isSpecial: false, 4, 36, 165, new List<int>(), 4, -1, 1796, 235, 595, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 50),
			new PropertyAndValue(4, 50)
		}, new HitOrAvoidShorts(0, 0, 30, 0), new OuterAndInnerShorts(80, 0), new OuterAndInnerShorts(0, 0), -1, new List<string> { "sleeve_l/sleeve_l_weapon", "sleeve_l/sleeve_l_119", "sleeve_r/sleeve_r_weapon", "sleeve_r/sleeve_r_119" }, 100));
		_dataArray.Add(new ArmorItem(466, LocalStringManager.GetConfig("Armor_language", "Name_466"), 1, 102, 7, 459, "icon_Armor_fuguangpowang", LocalStringManager.GetConfig("Armor_language", "Desc_466"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_466"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 60, 42300, 6, 16, 9000, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 10, isSpecial: false, 4, 36, 165, new List<int>(), 4, -1, 1796, 245, 625, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 55),
			new PropertyAndValue(4, 55)
		}, new HitOrAvoidShorts(0, 0, 30, 0), new OuterAndInnerShorts(90, 0), new OuterAndInnerShorts(0, 0), -1, new List<string> { "sleeve_l/sleeve_l_weapon", "sleeve_l/sleeve_l_119", "sleeve_r/sleeve_r_weapon", "sleeve_r/sleeve_r_119" }, 100));
		_dataArray.Add(new ArmorItem(467, LocalStringManager.GetConfig("Armor_language", "Name_467"), 1, 102, 8, 459, "icon_Armor_wanjianchanbi", LocalStringManager.GetConfig("Armor_language", "Desc_467"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_467"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 60, 61500, 6, 18, 10800, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 5, isSpecial: false, 4, 36, 165, new List<int>(), 4, -1, 1796, 260, 660, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 60),
			new PropertyAndValue(4, 60)
		}, new HitOrAvoidShorts(0, 0, 30, 0), new OuterAndInnerShorts(100, 0), new OuterAndInnerShorts(0, 0), -1, new List<string> { "sleeve_l/sleeve_l_weapon", "sleeve_l/sleeve_l_119", "sleeve_r/sleeve_r_weapon", "sleeve_r/sleeve_r_119" }, 100));
		_dataArray.Add(new ArmorItem(468, LocalStringManager.GetConfig("Armor_language", "Name_468"), 1, 102, 0, 468, "icon_Armor_huangmahuwan", LocalStringManager.GetConfig("Armor_language", "Desc_468"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_468"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 80, 300, 0, 2, 600, 3, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 45, isSpecial: false, 4, 36, 173, new List<int>(), 4, -1, 1796, 170, 410, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 20),
			new PropertyAndValue(5, 20)
		}, new HitOrAvoidShorts(20, 0, 0, 0), new OuterAndInnerShorts(0, 20), new OuterAndInnerShorts(0, 0), -1, new List<string> { "sleeve_l/sleeve_l_weapon", "sleeve_l/sleeve_l_111", "sleeve_r/sleeve_r_weapon", "sleeve_r/sleeve_r_111" }, 100));
		_dataArray.Add(new ArmorItem(469, LocalStringManager.GetConfig("Armor_language", "Name_469"), 1, 102, 1, 468, "icon_Armor_mianbuhuwan", LocalStringManager.GetConfig("Armor_language", "Desc_469"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_469"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 80, 600, 0, 4, 1200, 4, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 40, isSpecial: false, 4, 36, 173, new List<int>(), 4, -1, 1796, 180, 440, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 25),
			new PropertyAndValue(5, 25)
		}, new HitOrAvoidShorts(20, 0, 0, 0), new OuterAndInnerShorts(0, 30), new OuterAndInnerShorts(0, 0), -1, new List<string> { "sleeve_l/sleeve_l_weapon", "sleeve_l/sleeve_l_111", "sleeve_r/sleeve_r_weapon", "sleeve_r/sleeve_r_111" }, 100));
		_dataArray.Add(new ArmorItem(470, LocalStringManager.GetConfig("Armor_language", "Name_470"), 1, 102, 2, 468, "icon_Armor_zaojuanhuwan", LocalStringManager.GetConfig("Armor_language", "Desc_470"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_470"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 80, 1800, 1, 6, 1800, 5, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 35, isSpecial: false, 4, 36, 173, new List<int>(), 4, -1, 1796, 195, 475, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 30),
			new PropertyAndValue(5, 30)
		}, new HitOrAvoidShorts(20, 0, 0, 0), new OuterAndInnerShorts(0, 40), new OuterAndInnerShorts(0, 0), -1, new List<string> { "sleeve_l/sleeve_l_weapon", "sleeve_l/sleeve_l_111", "sleeve_r/sleeve_r_weapon", "sleeve_r/sleeve_r_111" }, 100));
		_dataArray.Add(new ArmorItem(471, LocalStringManager.GetConfig("Armor_language", "Name_471"), 1, 102, 3, 468, "icon_Armor_cuozonghuwan", LocalStringManager.GetConfig("Armor_language", "Desc_471"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_471"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 80, 4500, 2, 8, 3000, 6, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 30, isSpecial: false, 4, 36, 173, new List<int>(), 4, -1, 1796, 210, 510, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 35),
			new PropertyAndValue(5, 35)
		}, new HitOrAvoidShorts(25, 0, 0, 0), new OuterAndInnerShorts(0, 50), new OuterAndInnerShorts(0, 0), -1, new List<string> { "sleeve_l/sleeve_l_weapon", "sleeve_l/sleeve_l_115", "sleeve_r/sleeve_r_weapon", "sleeve_r/sleeve_r_115" }, 100));
		_dataArray.Add(new ArmorItem(472, LocalStringManager.GetConfig("Armor_language", "Name_472"), 1, 102, 4, 468, "icon_Armor_xuanjinhuwan", LocalStringManager.GetConfig("Armor_language", "Desc_472"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_472"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 80, 9300, 3, 10, 4200, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 25, isSpecial: false, 4, 36, 173, new List<int>(), 4, -1, 1796, 225, 545, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 40),
			new PropertyAndValue(5, 40)
		}, new HitOrAvoidShorts(25, 0, 0, 0), new OuterAndInnerShorts(0, 60), new OuterAndInnerShorts(0, 0), -1, new List<string> { "sleeve_l/sleeve_l_weapon", "sleeve_l/sleeve_l_115", "sleeve_r/sleeve_r_weapon", "sleeve_r/sleeve_r_115" }, 100));
		_dataArray.Add(new ArmorItem(473, LocalStringManager.GetConfig("Armor_language", "Name_473"), 1, 102, 5, 468, "icon_Armor_yuehuabingxiu", LocalStringManager.GetConfig("Armor_language", "Desc_473"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_473"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 80, 16800, 4, 12, 5400, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 20, isSpecial: false, 4, 36, 173, new List<int>(), 4, -1, 1796, 240, 580, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 45),
			new PropertyAndValue(5, 45)
		}, new HitOrAvoidShorts(25, 0, 0, 0), new OuterAndInnerShorts(0, 70), new OuterAndInnerShorts(0, 0), -1, new List<string> { "sleeve_l/sleeve_l_weapon", "sleeve_l/sleeve_l_115", "sleeve_r/sleeve_r_weapon", "sleeve_r/sleeve_r_115" }, 100));
		_dataArray.Add(new ArmorItem(474, LocalStringManager.GetConfig("Armor_language", "Name_474"), 1, 102, 6, 468, "icon_Armor_jiangxueyong", LocalStringManager.GetConfig("Armor_language", "Desc_474"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_474"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 80, 27600, 5, 14, 7200, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 15, isSpecial: false, 4, 36, 173, new List<int>(), 4, -1, 1796, 250, 610, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 50),
			new PropertyAndValue(5, 50)
		}, new HitOrAvoidShorts(30, 0, 0, 0), new OuterAndInnerShorts(0, 80), new OuterAndInnerShorts(0, 0), -1, new List<string> { "sleeve_l/sleeve_l_weapon", "sleeve_l/sleeve_l_119", "sleeve_r/sleeve_r_weapon", "sleeve_r/sleeve_r_119" }, 100));
		_dataArray.Add(new ArmorItem(475, LocalStringManager.GetConfig("Armor_language", "Name_475"), 1, 102, 7, 468, "icon_Armor_qingxuanwan", LocalStringManager.GetConfig("Armor_language", "Desc_475"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_475"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 80, 42300, 6, 16, 9000, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 10, isSpecial: false, 4, 36, 173, new List<int>(), 4, -1, 1796, 265, 645, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 55),
			new PropertyAndValue(5, 55)
		}, new HitOrAvoidShorts(30, 0, 0, 0), new OuterAndInnerShorts(0, 90), new OuterAndInnerShorts(0, 0), -1, new List<string> { "sleeve_l/sleeve_l_weapon", "sleeve_l/sleeve_l_119", "sleeve_r/sleeve_r_weapon", "sleeve_r/sleeve_r_119" }, 100));
		_dataArray.Add(new ArmorItem(476, LocalStringManager.GetConfig("Armor_language", "Name_476"), 1, 102, 8, 468, "icon_Armor_juechenhuwan", LocalStringManager.GetConfig("Armor_language", "Desc_476"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_476"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 80, 61500, 6, 18, 10800, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 5, isSpecial: false, 4, 36, 173, new List<int>(), 4, -1, 1796, 280, 680, new List<PropertyAndValue>
		{
			new PropertyAndValue(3, 60),
			new PropertyAndValue(5, 60)
		}, new HitOrAvoidShorts(30, 0, 0, 0), new OuterAndInnerShorts(0, 100), new OuterAndInnerShorts(0, 0), -1, new List<string> { "sleeve_l/sleeve_l_weapon", "sleeve_l/sleeve_l_119", "sleeve_r/sleeve_r_weapon", "sleeve_r/sleeve_r_119" }, 100));
		_dataArray.Add(new ArmorItem(477, LocalStringManager.GetConfig("Armor_language", "Name_477"), 1, 102, 0, 477, "icon_Armor_sumaguoshou", LocalStringManager.GetConfig("Armor_language", "Desc_477"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_477"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 40, 300, 0, 2, 600, 3, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 45, isSpecial: false, 4, 36, 172, new List<int>(), 4, -1, 1796, 145, 385, new List<PropertyAndValue>
		{
			new PropertyAndValue(1, 20),
			new PropertyAndValue(3, 20)
		}, new HitOrAvoidShorts(0, 0, 20, 0), new OuterAndInnerShorts(0, 20), new OuterAndInnerShorts(0, 0), -1, new List<string> { "sleeve_l/sleeve_l_weapon", "sleeve_l/sleeve_l_111", "sleeve_r/sleeve_r_weapon", "sleeve_r/sleeve_r_111" }, 100));
		_dataArray.Add(new ArmorItem(478, LocalStringManager.GetConfig("Armor_language", "Name_478"), 1, 102, 1, 477, "icon_Armor_bianshahuwan", LocalStringManager.GetConfig("Armor_language", "Desc_478"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_478"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 40, 600, 0, 4, 1200, 4, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 40, isSpecial: false, 4, 36, 172, new List<int>(), 4, -1, 1796, 155, 415, new List<PropertyAndValue>
		{
			new PropertyAndValue(1, 25),
			new PropertyAndValue(3, 25)
		}, new HitOrAvoidShorts(0, 0, 20, 0), new OuterAndInnerShorts(0, 30), new OuterAndInnerShorts(0, 0), -1, new List<string> { "sleeve_l/sleeve_l_weapon", "sleeve_l/sleeve_l_111", "sleeve_r/sleeve_r_weapon", "sleeve_r/sleeve_r_111" }, 100));
		_dataArray.Add(new ArmorItem(479, LocalStringManager.GetConfig("Armor_language", "Name_479"), 1, 102, 2, 477, "icon_Armor_zhouzhihuwan", LocalStringManager.GetConfig("Armor_language", "Desc_479"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_479"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 40, 1800, 1, 6, 1800, 5, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 35, isSpecial: false, 4, 36, 172, new List<int>(), 4, -1, 1796, 170, 450, new List<PropertyAndValue>
		{
			new PropertyAndValue(1, 30),
			new PropertyAndValue(3, 30)
		}, new HitOrAvoidShorts(0, 0, 20, 0), new OuterAndInnerShorts(0, 40), new OuterAndInnerShorts(0, 0), -1, new List<string> { "sleeve_l/sleeve_l_weapon", "sleeve_l/sleeve_l_111", "sleeve_r/sleeve_r_weapon", "sleeve_r/sleeve_r_111" }, 100));
	}

	private void CreateItems8()
	{
		_dataArray.Add(new ArmorItem(480, LocalStringManager.GetConfig("Armor_language", "Name_480"), 1, 102, 3, 477, "icon_Armor_tiwenduanxiu", LocalStringManager.GetConfig("Armor_language", "Desc_480"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_480"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 40, 4500, 2, 8, 3000, 6, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 30, isSpecial: false, 4, 36, 172, new List<int>(), 4, -1, 1796, 180, 480, new List<PropertyAndValue>
		{
			new PropertyAndValue(1, 35),
			new PropertyAndValue(3, 35)
		}, new HitOrAvoidShorts(0, 0, 25, 0), new OuterAndInnerShorts(0, 50), new OuterAndInnerShorts(0, 0), -1, new List<string> { "sleeve_l/sleeve_l_weapon", "sleeve_l/sleeve_l_115", "sleeve_r/sleeve_r_weapon", "sleeve_r/sleeve_r_115" }, 100));
		_dataArray.Add(new ArmorItem(481, LocalStringManager.GetConfig("Armor_language", "Name_481"), 1, 102, 4, 477, "icon_Armor_sanhualingwan", LocalStringManager.GetConfig("Armor_language", "Desc_481"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_481"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 40, 9300, 3, 10, 4200, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 25, isSpecial: false, 4, 36, 172, new List<int>(), 4, -1, 1796, 190, 510, new List<PropertyAndValue>
		{
			new PropertyAndValue(1, 40),
			new PropertyAndValue(3, 40)
		}, new HitOrAvoidShorts(0, 0, 25, 0), new OuterAndInnerShorts(0, 60), new OuterAndInnerShorts(0, 0), -1, new List<string> { "sleeve_l/sleeve_l_weapon", "sleeve_l/sleeve_l_115", "sleeve_r/sleeve_r_weapon", "sleeve_r/sleeve_r_115" }, 100));
		_dataArray.Add(new ArmorItem(482, LocalStringManager.GetConfig("Armor_language", "Name_482"), 1, 102, 5, 477, "icon_Armor_lingjiuhuwan", LocalStringManager.GetConfig("Armor_language", "Desc_482"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_482"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 40, 16800, 4, 12, 5400, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 20, isSpecial: false, 4, 36, 172, new List<int>(), 4, -1, 1796, 205, 545, new List<PropertyAndValue>
		{
			new PropertyAndValue(1, 45),
			new PropertyAndValue(3, 45)
		}, new HitOrAvoidShorts(0, 0, 25, 0), new OuterAndInnerShorts(0, 70), new OuterAndInnerShorts(0, 0), -1, new List<string> { "sleeve_l/sleeve_l_weapon", "sleeve_l/sleeve_l_115", "sleeve_r/sleeve_r_weapon", "sleeve_r/sleeve_r_115" }, 100));
		_dataArray.Add(new ArmorItem(483, LocalStringManager.GetConfig("Armor_language", "Name_483"), 1, 102, 6, 477, "icon_Armor_luhuaxixinxiu", LocalStringManager.GetConfig("Armor_language", "Desc_483"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_483"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 40, 27600, 5, 14, 7200, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 15, isSpecial: false, 4, 36, 172, new List<int>(), 4, -1, 1796, 215, 575, new List<PropertyAndValue>
		{
			new PropertyAndValue(1, 50),
			new PropertyAndValue(3, 50)
		}, new HitOrAvoidShorts(0, 0, 30, 0), new OuterAndInnerShorts(0, 80), new OuterAndInnerShorts(0, 0), -1, new List<string> { "sleeve_l/sleeve_l_weapon", "sleeve_l/sleeve_l_119", "sleeve_r/sleeve_r_weapon", "sleeve_r/sleeve_r_119" }, 100));
		_dataArray.Add(new ArmorItem(484, LocalStringManager.GetConfig("Armor_language", "Name_484"), 1, 102, 7, 477, "icon_Armor_wuyaopibo", LocalStringManager.GetConfig("Armor_language", "Desc_484"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_484"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 40, 42300, 6, 16, 9000, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 10, isSpecial: false, 4, 36, 172, new List<int>(), 4, -1, 1796, 230, 610, new List<PropertyAndValue>
		{
			new PropertyAndValue(1, 55),
			new PropertyAndValue(3, 55)
		}, new HitOrAvoidShorts(0, 0, 30, 0), new OuterAndInnerShorts(0, 90), new OuterAndInnerShorts(0, 0), -1, new List<string> { "sleeve_l/sleeve_l_weapon", "sleeve_l/sleeve_l_119", "sleeve_r/sleeve_r_weapon", "sleeve_r/sleeve_r_119" }, 100));
		_dataArray.Add(new ArmorItem(485, LocalStringManager.GetConfig("Armor_language", "Name_485"), 1, 102, 8, 477, "icon_Armor_chongxulun", LocalStringManager.GetConfig("Armor_language", "Desc_485"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_485"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 40, 61500, 6, 18, 10800, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 5, isSpecial: false, 4, 36, 172, new List<int>(), 4, -1, 1796, 240, 640, new List<PropertyAndValue>
		{
			new PropertyAndValue(1, 60),
			new PropertyAndValue(3, 60)
		}, new HitOrAvoidShorts(0, 0, 30, 0), new OuterAndInnerShorts(0, 100), new OuterAndInnerShorts(0, 0), -1, new List<string> { "sleeve_l/sleeve_l_weapon", "sleeve_l/sleeve_l_119", "sleeve_r/sleeve_r_weapon", "sleeve_r/sleeve_r_119" }, 100));
		_dataArray.Add(new ArmorItem(486, LocalStringManager.GetConfig("Armor_language", "Name_486"), 1, 102, 0, 486, "icon_Armor_cumazhixiu", LocalStringManager.GetConfig("Armor_language", "Desc_486"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_486"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 100, 300, 0, 2, 600, 3, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 45, isSpecial: false, 4, 36, 174, new List<int>(), 4, -1, 1796, 180, 420, new List<PropertyAndValue>
		{
			new PropertyAndValue(4, 20),
			new PropertyAndValue(5, 20)
		}, new HitOrAvoidShorts(0, 20, 0, 0), new OuterAndInnerShorts(0, 20), new OuterAndInnerShorts(0, 0), -1, new List<string> { "sleeve_l/sleeve_l_weapon", "sleeve_l/sleeve_l_121", "sleeve_r/sleeve_r_weapon", "sleeve_r/sleeve_r_121" }, 100));
		_dataArray.Add(new ArmorItem(487, LocalStringManager.GetConfig("Armor_language", "Name_487"), 1, 102, 1, 486, "icon_Armor_mashengchanshou", LocalStringManager.GetConfig("Armor_language", "Desc_487"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_487"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 105, 600, 0, 4, 1200, 4, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 40, isSpecial: false, 4, 36, 174, new List<int>(), 4, -1, 1796, 195, 455, new List<PropertyAndValue>
		{
			new PropertyAndValue(4, 25),
			new PropertyAndValue(5, 25)
		}, new HitOrAvoidShorts(0, 20, 0, 0), new OuterAndInnerShorts(0, 30), new OuterAndInnerShorts(0, 0), -1, new List<string> { "sleeve_l/sleeve_l_weapon", "sleeve_l/sleeve_l_121", "sleeve_r/sleeve_r_weapon", "sleeve_r/sleeve_r_121" }, 100));
		_dataArray.Add(new ArmorItem(488, LocalStringManager.GetConfig("Armor_language", "Name_488"), 1, 102, 2, 486, "icon_Armor_mianchouhuwan", LocalStringManager.GetConfig("Armor_language", "Desc_488"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_488"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 110, 1800, 1, 6, 1800, 5, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 35, isSpecial: false, 4, 36, 174, new List<int>(), 4, -1, 1796, 215, 495, new List<PropertyAndValue>
		{
			new PropertyAndValue(4, 30),
			new PropertyAndValue(5, 30)
		}, new HitOrAvoidShorts(0, 20, 0, 0), new OuterAndInnerShorts(0, 40), new OuterAndInnerShorts(0, 0), -1, new List<string> { "sleeve_l/sleeve_l_weapon", "sleeve_l/sleeve_l_121", "sleeve_r/sleeve_r_weapon", "sleeve_r/sleeve_r_121" }, 100));
		_dataArray.Add(new ArmorItem(489, LocalStringManager.GetConfig("Armor_language", "Name_489"), 1, 102, 3, 486, "icon_Armor_baicaolianhuwan", LocalStringManager.GetConfig("Armor_language", "Desc_489"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_489"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 115, 4500, 2, 8, 3000, 6, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 30, isSpecial: false, 4, 36, 174, new List<int>(), 4, -1, 1796, 235, 535, new List<PropertyAndValue>
		{
			new PropertyAndValue(4, 35),
			new PropertyAndValue(5, 35)
		}, new HitOrAvoidShorts(0, 25, 0, 0), new OuterAndInnerShorts(0, 50), new OuterAndInnerShorts(0, 0), -1, new List<string> { "sleeve_l/sleeve_l_weapon", "sleeve_l/sleeve_l_125", "sleeve_r/sleeve_r_weapon", "sleeve_r/sleeve_r_125" }, 100));
		_dataArray.Add(new ArmorItem(490, LocalStringManager.GetConfig("Armor_language", "Name_490"), 1, 102, 4, 486, "icon_Armor_ruanjinchouwan", LocalStringManager.GetConfig("Armor_language", "Desc_490"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_490"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 120, 9300, 3, 10, 4200, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 25, isSpecial: false, 4, 36, 174, new List<int>(), 4, -1, 1796, 255, 575, new List<PropertyAndValue>
		{
			new PropertyAndValue(4, 40),
			new PropertyAndValue(5, 40)
		}, new HitOrAvoidShorts(0, 25, 0, 0), new OuterAndInnerShorts(0, 60), new OuterAndInnerShorts(0, 0), -1, new List<string> { "sleeve_l/sleeve_l_weapon", "sleeve_l/sleeve_l_125", "sleeve_r/sleeve_r_weapon", "sleeve_r/sleeve_r_125" }, 100));
		_dataArray.Add(new ArmorItem(491, LocalStringManager.GetConfig("Armor_language", "Name_491"), 1, 102, 5, 486, "icon_Armor_shuangsiqianjiewan", LocalStringManager.GetConfig("Armor_language", "Desc_491"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_491"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 125, 16800, 4, 12, 5400, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 20, isSpecial: false, 4, 36, 174, new List<int>(), 4, -1, 1796, 270, 610, new List<PropertyAndValue>
		{
			new PropertyAndValue(4, 45),
			new PropertyAndValue(5, 45)
		}, new HitOrAvoidShorts(0, 25, 0, 0), new OuterAndInnerShorts(0, 70), new OuterAndInnerShorts(0, 0), -1, new List<string> { "sleeve_l/sleeve_l_weapon", "sleeve_l/sleeve_l_125", "sleeve_r/sleeve_r_weapon", "sleeve_r/sleeve_r_125" }, 100));
		_dataArray.Add(new ArmorItem(492, LocalStringManager.GetConfig("Armor_language", "Name_492"), 1, 102, 6, 486, "icon_Armor_bingwenxianzaowan", LocalStringManager.GetConfig("Armor_language", "Desc_492"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_492"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 130, 27600, 5, 14, 7200, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 15, isSpecial: false, 4, 36, 174, new List<int>(), 4, -1, 1796, 295, 655, new List<PropertyAndValue>
		{
			new PropertyAndValue(4, 50),
			new PropertyAndValue(5, 50)
		}, new HitOrAvoidShorts(0, 30, 0, 0), new OuterAndInnerShorts(0, 80), new OuterAndInnerShorts(0, 0), -1, new List<string> { "sleeve_l/sleeve_l_weapon", "sleeve_l/sleeve_l_129", "sleeve_r/sleeve_r_weapon", "sleeve_r/sleeve_r_129" }, 100));
		_dataArray.Add(new ArmorItem(493, LocalStringManager.GetConfig("Armor_language", "Name_493"), 1, 102, 7, 486, "icon_Armor_jiehailou", LocalStringManager.GetConfig("Armor_language", "Desc_493"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_493"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 135, 42300, 6, 16, 9000, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 10, isSpecial: false, 4, 36, 174, new List<int>(), 4, -1, 1796, 315, 695, new List<PropertyAndValue>
		{
			new PropertyAndValue(4, 55),
			new PropertyAndValue(5, 55)
		}, new HitOrAvoidShorts(0, 30, 0, 0), new OuterAndInnerShorts(0, 90), new OuterAndInnerShorts(0, 0), -1, new List<string> { "sleeve_l/sleeve_l_weapon", "sleeve_l/sleeve_l_129", "sleeve_r/sleeve_r_weapon", "sleeve_r/sleeve_r_129" }, 100));
		_dataArray.Add(new ArmorItem(494, LocalStringManager.GetConfig("Armor_language", "Name_494"), 1, 102, 8, 486, "icon_Armor_xuanyuanwusebi", LocalStringManager.GetConfig("Armor_language", "Desc_494"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_494"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 140, 61500, 6, 18, 10800, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 5, isSpecial: false, 4, 36, 174, new List<int>(), 4, -1, 1796, 340, 740, new List<PropertyAndValue>
		{
			new PropertyAndValue(4, 60),
			new PropertyAndValue(5, 60)
		}, new HitOrAvoidShorts(0, 30, 0, 0), new OuterAndInnerShorts(0, 100), new OuterAndInnerShorts(0, 0), -1, new List<string> { "sleeve_l/sleeve_l_weapon", "sleeve_l/sleeve_l_129", "sleeve_r/sleeve_r_weapon", "sleeve_r/sleeve_r_129" }, 100));
		_dataArray.Add(new ArmorItem(495, LocalStringManager.GetConfig("Armor_language", "Name_495"), 1, 102, 0, 495, "icon_Armor_huangmashuxiu", LocalStringManager.GetConfig("Armor_language", "Desc_495"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_495"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 80, 300, 0, 2, 600, 3, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 45, isSpecial: false, 4, 36, 175, new List<int>(), 4, -1, 1796, 170, 530, new List<PropertyAndValue>
		{
			new PropertyAndValue(1, 20),
			new PropertyAndValue(4, 20)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 20), new OuterAndInnerShorts(0, 10), -1, new List<string> { "sleeve_l/sleeve_l_weapon", "sleeve_l/sleeve_l_131", "sleeve_r/sleeve_r_weapon", "sleeve_r/sleeve_r_131" }, 100));
		_dataArray.Add(new ArmorItem(496, LocalStringManager.GetConfig("Armor_language", "Name_496"), 1, 102, 1, 495, "icon_Armor_mianbutaoxiu", LocalStringManager.GetConfig("Armor_language", "Desc_496"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_496"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 90, 600, 0, 4, 1200, 4, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 40, isSpecial: false, 4, 36, 175, new List<int>(), 4, -1, 1796, 190, 580, new List<PropertyAndValue>
		{
			new PropertyAndValue(1, 25),
			new PropertyAndValue(4, 25)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 25), new OuterAndInnerShorts(0, 10), -1, new List<string> { "sleeve_l/sleeve_l_weapon", "sleeve_l/sleeve_l_131", "sleeve_r/sleeve_r_weapon", "sleeve_r/sleeve_r_131" }, 100));
		_dataArray.Add(new ArmorItem(497, LocalStringManager.GetConfig("Armor_language", "Name_497"), 1, 102, 2, 495, "icon_Armor_anwenchouwan", LocalStringManager.GetConfig("Armor_language", "Desc_497"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_497"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 100, 1800, 1, 6, 1800, 5, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 35, isSpecial: false, 4, 36, 175, new List<int>(), 4, -1, 1796, 210, 630, new List<PropertyAndValue>
		{
			new PropertyAndValue(1, 30),
			new PropertyAndValue(4, 30)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 30), new OuterAndInnerShorts(0, 15), -1, new List<string> { "sleeve_l/sleeve_l_weapon", "sleeve_l/sleeve_l_131", "sleeve_r/sleeve_r_weapon", "sleeve_r/sleeve_r_131" }, 100));
		_dataArray.Add(new ArmorItem(498, LocalStringManager.GetConfig("Armor_language", "Name_498"), 1, 102, 3, 495, "icon_Armor_xiangluohuwan", LocalStringManager.GetConfig("Armor_language", "Desc_498"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_498"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 110, 4500, 2, 8, 3000, 6, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 30, isSpecial: false, 4, 36, 175, new List<int>(), 4, -1, 1796, 235, 685, new List<PropertyAndValue>
		{
			new PropertyAndValue(1, 35),
			new PropertyAndValue(4, 35)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 35), new OuterAndInnerShorts(0, 20), -1, new List<string> { "sleeve_l/sleeve_l_weapon", "sleeve_l/sleeve_l_135", "sleeve_r/sleeve_r_weapon", "sleeve_r/sleeve_r_135" }, 100));
		_dataArray.Add(new ArmorItem(499, LocalStringManager.GetConfig("Armor_language", "Name_499"), 1, 102, 4, 495, "icon_Armor_feidiezhuhuaxiu", LocalStringManager.GetConfig("Armor_language", "Desc_499"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_499"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 120, 9300, 3, 10, 4200, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 25, isSpecial: false, 4, 36, 175, new List<int>(), 4, -1, 1796, 255, 735, new List<PropertyAndValue>
		{
			new PropertyAndValue(1, 40),
			new PropertyAndValue(4, 40)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 40), new OuterAndInnerShorts(0, 20), -1, new List<string> { "sleeve_l/sleeve_l_weapon", "sleeve_l/sleeve_l_135", "sleeve_r/sleeve_r_weapon", "sleeve_r/sleeve_r_135" }, 100));
		_dataArray.Add(new ArmorItem(500, LocalStringManager.GetConfig("Armor_language", "Name_500"), 1, 102, 5, 495, "icon_Armor_yixuetingmeixiu", LocalStringManager.GetConfig("Armor_language", "Desc_500"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_500"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 130, 16800, 4, 12, 5400, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 20, isSpecial: false, 4, 36, 175, new List<int>(), 4, -1, 1796, 280, 790, new List<PropertyAndValue>
		{
			new PropertyAndValue(1, 45),
			new PropertyAndValue(4, 45)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 45), new OuterAndInnerShorts(0, 25), -1, new List<string> { "sleeve_l/sleeve_l_weapon", "sleeve_l/sleeve_l_135", "sleeve_r/sleeve_r_weapon", "sleeve_r/sleeve_r_135" }, 100));
		_dataArray.Add(new ArmorItem(501, LocalStringManager.GetConfig("Armor_language", "Name_501"), 1, 102, 6, 495, "icon_Armor_shanyunwuxinxiu", LocalStringManager.GetConfig("Armor_language", "Desc_501"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_501"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 140, 27600, 5, 14, 7200, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 15, isSpecial: false, 4, 36, 175, new List<int>(), 4, -1, 1796, 305, 845, new List<PropertyAndValue>
		{
			new PropertyAndValue(1, 50),
			new PropertyAndValue(4, 50)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 50), new OuterAndInnerShorts(0, 30), -1, new List<string> { "sleeve_l/sleeve_l_weapon", "sleeve_l/sleeve_l_139", "sleeve_r/sleeve_r_weapon", "sleeve_r/sleeve_r_139" }, 100));
		_dataArray.Add(new ArmorItem(502, LocalStringManager.GetConfig("Armor_language", "Name_502"), 1, 102, 7, 495, "icon_Armor_wuhehuaqi", LocalStringManager.GetConfig("Armor_language", "Desc_502"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_502"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 150, 42300, 6, 16, 9000, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 10, isSpecial: false, 4, 36, 175, new List<int>(), 4, -1, 1796, 335, 905, new List<PropertyAndValue>
		{
			new PropertyAndValue(1, 55),
			new PropertyAndValue(4, 55)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 55), new OuterAndInnerShorts(0, 30), -1, new List<string> { "sleeve_l/sleeve_l_weapon", "sleeve_l/sleeve_l_139", "sleeve_r/sleeve_r_weapon", "sleeve_r/sleeve_r_139" }, 100));
		_dataArray.Add(new ArmorItem(503, LocalStringManager.GetConfig("Armor_language", "Name_503"), 1, 102, 8, 495, "icon_Armor_tiannuwenxiu", LocalStringManager.GetConfig("Armor_language", "Desc_503"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_503"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 40, 160, 61500, 6, 18, 10800, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 5, isSpecial: false, 4, 36, 175, new List<int>(), 4, -1, 1796, 360, 960, new List<PropertyAndValue>
		{
			new PropertyAndValue(1, 60),
			new PropertyAndValue(4, 60)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(0, 60), new OuterAndInnerShorts(0, 35), -1, new List<string> { "sleeve_l/sleeve_l_weapon", "sleeve_l/sleeve_l_139", "sleeve_r/sleeve_r_weapon", "sleeve_r/sleeve_r_139" }, 100));
		_dataArray.Add(new ArmorItem(504, LocalStringManager.GetConfig("Armor_language", "Name_504"), 1, 102, 0, 504, "icon_Armor_manaohuwan", LocalStringManager.GetConfig("Armor_language", "Desc_504"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_504"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 80, 140, 300, 0, 2, 600, 3, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 45, isSpecial: false, 3, 36, 164, new List<int>(), 4, -1, 1795, 540, 420, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 30),
			new PropertyAndValue(3, 30)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(40, 5), new OuterAndInnerShorts(0, 0), -1, new List<string> { "equip_elbow_l", "equip_elbow_l/equip_elbow_l_431", "equip_elbow_r", "equip_elbow_r/equip_elbow_r_431" }, 100));
		_dataArray.Add(new ArmorItem(505, LocalStringManager.GetConfig("Armor_language", "Name_505"), 1, 102, 1, 504, "icon_Armor_huayezhuo", LocalStringManager.GetConfig("Armor_language", "Desc_505"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_505"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 80, 175, 600, 0, 4, 1200, 4, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 40, isSpecial: false, 3, 36, 164, new List<int>(), 4, -1, 1795, 600, 470, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 35),
			new PropertyAndValue(3, 35)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(50, 10), new OuterAndInnerShorts(0, 0), -1, new List<string> { "equip_elbow_l", "equip_elbow_l/equip_elbow_l_431", "equip_elbow_r", "equip_elbow_r/equip_elbow_r_431" }, 100));
		_dataArray.Add(new ArmorItem(506, LocalStringManager.GetConfig("Armor_language", "Name_506"), 1, 102, 2, 504, "icon_Armor_dieshengbigu", LocalStringManager.GetConfig("Armor_language", "Desc_506"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_506"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 80, 210, 1800, 1, 6, 1800, 5, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 35, isSpecial: false, 3, 36, 164, new List<int>(), 4, -1, 1795, 665, 525, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 40),
			new PropertyAndValue(3, 40)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(60, 15), new OuterAndInnerShorts(10, 0), -1, new List<string> { "equip_elbow_l", "equip_elbow_l/equip_elbow_l_431", "equip_elbow_r", "equip_elbow_r/equip_elbow_r_431" }, 100));
		_dataArray.Add(new ArmorItem(507, LocalStringManager.GetConfig("Armor_language", "Name_507"), 1, 102, 3, 504, "icon_Armor_yuchanbishu", LocalStringManager.GetConfig("Armor_language", "Desc_507"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_507"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 80, 245, 4500, 2, 8, 3000, 6, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 30, isSpecial: false, 3, 36, 164, new List<int>(), 4, -1, 1795, 730, 580, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 45),
			new PropertyAndValue(3, 45)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(70, 20), new OuterAndInnerShorts(10, 0), -1, new List<string> { "equip_elbow_l", "equip_elbow_l/equip_elbow_l_435", "equip_elbow_r", "equip_elbow_r/equip_elbow_r_435" }, 100));
		_dataArray.Add(new ArmorItem(508, LocalStringManager.GetConfig("Armor_language", "Name_508"), 1, 102, 4, 504, "icon_Armor_pixiuhubi", LocalStringManager.GetConfig("Armor_language", "Desc_508"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_508"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 80, 280, 9300, 3, 10, 4200, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 25, isSpecial: false, 3, 36, 164, new List<int>(), 4, -1, 1795, 800, 640, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 50),
			new PropertyAndValue(3, 50)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(80, 25), new OuterAndInnerShorts(15, 0), -1, new List<string> { "equip_elbow_l", "equip_elbow_l/equip_elbow_l_435", "equip_elbow_r", "equip_elbow_r/equip_elbow_r_435" }, 100));
		_dataArray.Add(new ArmorItem(509, LocalStringManager.GetConfig("Armor_language", "Name_509"), 1, 102, 5, 504, "icon_Armor_zhaominghuan", LocalStringManager.GetConfig("Armor_language", "Desc_509"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_509"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 80, 315, 16800, 4, 12, 5400, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 20, isSpecial: false, 3, 36, 164, new List<int>(), 4, -1, 1795, 865, 695, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 55),
			new PropertyAndValue(3, 55)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(90, 30), new OuterAndInnerShorts(20, 10), -1, new List<string> { "equip_elbow_l", "equip_elbow_l/equip_elbow_l_435", "equip_elbow_r", "equip_elbow_r/equip_elbow_r_435" }, 100));
		_dataArray.Add(new ArmorItem(510, LocalStringManager.GetConfig("Armor_language", "Name_510"), 1, 102, 6, 504, "icon_Armor_shichibuduo", LocalStringManager.GetConfig("Armor_language", "Desc_510"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_510"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 80, 350, 27600, 5, 14, 7200, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 15, isSpecial: false, 3, 36, 164, new List<int>(), 4, -1, 1795, 945, 765, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 60),
			new PropertyAndValue(3, 60)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(100, 35), new OuterAndInnerShorts(20, 10), -1, new List<string> { "equip_elbow_l", "equip_elbow_l/equip_elbow_l_439", "equip_elbow_r", "equip_elbow_r/equip_elbow_r_439" }, 100));
		_dataArray.Add(new ArmorItem(511, LocalStringManager.GetConfig("Armor_language", "Name_511"), 1, 102, 7, 504, "icon_Armor_yinyangzhidehuan", LocalStringManager.GetConfig("Armor_language", "Desc_511"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_511"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 80, 385, 42300, 6, 16, 9000, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 10, isSpecial: false, 3, 36, 164, new List<int>(), 4, -1, 1795, 1015, 825, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 65),
			new PropertyAndValue(3, 65)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(110, 40), new OuterAndInnerShorts(25, 15), -1, new List<string> { "equip_elbow_l", "equip_elbow_l/equip_elbow_l_439", "equip_elbow_r", "equip_elbow_r/equip_elbow_r_439" }, 100));
		_dataArray.Add(new ArmorItem(512, LocalStringManager.GetConfig("Armor_language", "Name_512"), 1, 102, 8, 504, "icon_Armor_qiandengyijing", LocalStringManager.GetConfig("Armor_language", "Desc_512"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_512"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 80, 420, 61500, 6, 18, 10800, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 5, isSpecial: false, 3, 36, 164, new List<int>(), 4, -1, 1795, 1100, 900, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 70),
			new PropertyAndValue(3, 70)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(120, 45), new OuterAndInnerShorts(30, 20), -1, new List<string> { "equip_elbow_l", "equip_elbow_l/equip_elbow_l_439", "equip_elbow_r", "equip_elbow_r/equip_elbow_r_439" }, 100));
		_dataArray.Add(new ArmorItem(513, LocalStringManager.GetConfig("Armor_language", "Name_513"), 1, 102, 0, 513, "icon_Armor_yuguoshou", LocalStringManager.GetConfig("Armor_language", "Desc_513"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_513"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 80, 80, 300, 0, 2, 600, 3, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 45, isSpecial: false, 3, 36, 171, new List<int>(), 4, -1, 1795, 575, 335, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 30),
			new PropertyAndValue(4, 30)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(5, 40), new OuterAndInnerShorts(0, 0), -1, new List<string> { "equip_elbow_l", "equip_elbow_l/equip_elbow_l_411", "equip_elbow_r", "equip_elbow_r/equip_elbow_r_411" }, 100));
		_dataArray.Add(new ArmorItem(514, LocalStringManager.GetConfig("Armor_language", "Name_514"), 1, 102, 1, 513, "icon_Armor_banhubishi", LocalStringManager.GetConfig("Armor_language", "Desc_514"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_514"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 80, 110, 600, 0, 4, 1200, 4, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 40, isSpecial: false, 3, 36, 171, new List<int>(), 4, -1, 1795, 635, 375, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 35),
			new PropertyAndValue(4, 35)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(10, 50), new OuterAndInnerShorts(0, 0), -1, new List<string> { "equip_elbow_l", "equip_elbow_l/equip_elbow_l_411", "equip_elbow_r", "equip_elbow_r/equip_elbow_r_411" }, 100));
		_dataArray.Add(new ArmorItem(515, LocalStringManager.GetConfig("Armor_language", "Name_515"), 1, 102, 2, 513, "icon_Armor_bingjingshouchuan", LocalStringManager.GetConfig("Armor_language", "Desc_515"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_515"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 80, 140, 1800, 1, 6, 1800, 5, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 35, isSpecial: false, 3, 36, 171, new List<int>(), 4, -1, 1795, 700, 420, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 40),
			new PropertyAndValue(4, 40)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(15, 60), new OuterAndInnerShorts(0, 10), -1, new List<string> { "equip_elbow_l", "equip_elbow_l/equip_elbow_l_411", "equip_elbow_r", "equip_elbow_r/equip_elbow_r_411" }, 100));
		_dataArray.Add(new ArmorItem(516, LocalStringManager.GetConfig("Armor_language", "Name_516"), 1, 102, 3, 513, "icon_Armor_jingyunbidang", LocalStringManager.GetConfig("Armor_language", "Desc_516"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_516"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 80, 165, 4500, 2, 8, 3000, 6, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 30, isSpecial: false, 3, 36, 171, new List<int>(), 4, -1, 1795, 765, 465, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 45),
			new PropertyAndValue(4, 45)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(20, 70), new OuterAndInnerShorts(0, 10), -1, new List<string> { "equip_elbow_l", "equip_elbow_l/equip_elbow_l_415", "equip_elbow_r", "equip_elbow_r/equip_elbow_r_415" }, 100));
		_dataArray.Add(new ArmorItem(517, LocalStringManager.GetConfig("Armor_language", "Name_517"), 1, 102, 4, 513, "icon_Armor_lianhuayuewan", LocalStringManager.GetConfig("Armor_language", "Desc_517"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_517"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 80, 195, 9300, 3, 10, 4200, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 25, isSpecial: false, 3, 36, 171, new List<int>(), 4, -1, 1795, 830, 510, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 50),
			new PropertyAndValue(4, 50)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(25, 80), new OuterAndInnerShorts(0, 15), -1, new List<string> { "equip_elbow_l", "equip_elbow_l/equip_elbow_l_415", "equip_elbow_r", "equip_elbow_r/equip_elbow_r_415" }, 100));
		_dataArray.Add(new ArmorItem(518, LocalStringManager.GetConfig("Armor_language", "Name_518"), 1, 102, 5, 513, "icon_Armor_shoujinghuan", LocalStringManager.GetConfig("Armor_language", "Desc_518"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_518"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 80, 220, 16800, 4, 12, 5400, 7, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 20, isSpecial: false, 3, 36, 171, new List<int>(), 4, -1, 1795, 900, 560, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 55),
			new PropertyAndValue(4, 55)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(30, 90), new OuterAndInnerShorts(10, 20), -1, new List<string> { "equip_elbow_l", "equip_elbow_l/equip_elbow_l_415", "equip_elbow_r", "equip_elbow_r/equip_elbow_r_415" }, 100));
		_dataArray.Add(new ArmorItem(519, LocalStringManager.GetConfig("Armor_language", "Name_519"), 1, 102, 6, 513, "icon_Armor_wuzhenhuan", LocalStringManager.GetConfig("Armor_language", "Desc_519"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_519"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 80, 250, 27600, 5, 14, 7200, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 15, isSpecial: false, 3, 36, 171, new List<int>(), 4, -1, 1795, 970, 610, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 60),
			new PropertyAndValue(4, 60)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(35, 100), new OuterAndInnerShorts(10, 20), -1, new List<string> { "equip_elbow_l", "equip_elbow_l/equip_elbow_l_419", "equip_elbow_r", "equip_elbow_r/equip_elbow_r_419" }, 100));
		_dataArray.Add(new ArmorItem(520, LocalStringManager.GetConfig("Armor_language", "Name_520"), 1, 102, 7, 513, "icon_Armor_jinggouhuan", LocalStringManager.GetConfig("Armor_language", "Desc_520"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_520"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 80, 280, 42300, 6, 16, 9000, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 10, isSpecial: false, 3, 36, 171, new List<int>(), 4, -1, 1795, 1045, 665, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 65),
			new PropertyAndValue(4, 65)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(40, 110), new OuterAndInnerShorts(15, 25), -1, new List<string> { "equip_elbow_l", "equip_elbow_l/equip_elbow_l_419", "equip_elbow_r", "equip_elbow_r/equip_elbow_r_419" }, 100));
		_dataArray.Add(new ArmorItem(521, LocalStringManager.GetConfig("Armor_language", "Name_521"), 1, 102, 8, 513, "icon_Armor_xiyihuan", LocalStringManager.GetConfig("Armor_language", "Desc_521"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_521"), transferable: true, stackable: false, wagerable: true, refinable: true, poisonable: true, repairable: true, inheritable: true, detachable: true, 80, 305, 61500, 6, 18, 10800, 8, allowRandomCreate: true, allowRawCreate: true, allowCrippledCreate: true, 5, isSpecial: false, 3, 36, 171, new List<int>(), 4, -1, 1795, 1120, 720, new List<PropertyAndValue>
		{
			new PropertyAndValue(2, 70),
			new PropertyAndValue(4, 70)
		}, new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(45, 120), new OuterAndInnerShorts(20, 30), -1, new List<string> { "equip_elbow_l", "equip_elbow_l/equip_elbow_l_419", "equip_elbow_r", "equip_elbow_r/equip_elbow_r_419" }, 100));
		_dataArray.Add(new ArmorItem(522, LocalStringManager.GetConfig("Armor_language", "Name_522"), 1, 104, 3, -1, "icon_Armor_houpi", LocalStringManager.GetConfig("Armor_language", "Desc_522"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_522"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: false, 80, 0, 0, 0, 0, 0, 8, allowRandomCreate: false, allowRawCreate: false, allowCrippledCreate: false, 0, isSpecial: true, -1, 12, -1, new List<int>(), 1, -1, 1797, 300, 400, new List<PropertyAndValue>(), new HitOrAvoidShorts(40, 0, 0, 0), new OuterAndInnerShorts(50, 20), new OuterAndInnerShorts(15, 0), -1, null, 100));
		_dataArray.Add(new ArmorItem(523, LocalStringManager.GetConfig("Armor_language", "Name_523"), 1, 104, 3, -1, "icon_Armor_houpi", LocalStringManager.GetConfig("Armor_language", "Desc_523"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_523"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: false, 80, 0, 0, 0, 0, 0, 8, allowRandomCreate: false, allowRawCreate: false, allowCrippledCreate: false, 0, isSpecial: true, -1, 12, -1, new List<int>(), 3, -1, 1797, 300, 400, new List<PropertyAndValue>(), new HitOrAvoidShorts(40, 0, 0, 0), new OuterAndInnerShorts(50, 20), new OuterAndInnerShorts(15, 0), -1, null, 100));
		_dataArray.Add(new ArmorItem(524, LocalStringManager.GetConfig("Armor_language", "Name_524"), 1, 104, 3, -1, "icon_Armor_houpi", LocalStringManager.GetConfig("Armor_language", "Desc_524"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_524"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: false, 80, 0, 0, 0, 0, 0, 8, allowRandomCreate: false, allowRawCreate: false, allowCrippledCreate: false, 0, isSpecial: true, -1, 12, -1, new List<int>(), 4, -1, 1797, 300, 400, new List<PropertyAndValue>(), new HitOrAvoidShorts(40, 0, 0, 0), new OuterAndInnerShorts(50, 20), new OuterAndInnerShorts(15, 0), -1, null, 100));
		_dataArray.Add(new ArmorItem(525, LocalStringManager.GetConfig("Armor_language", "Name_525"), 1, 104, 3, -1, "icon_Armor_houpi", LocalStringManager.GetConfig("Armor_language", "Desc_525"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_525"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: false, 80, 0, 0, 0, 0, 0, 8, allowRandomCreate: false, allowRawCreate: false, allowCrippledCreate: false, 0, isSpecial: true, -1, 12, -1, new List<int>(), 5, -1, 1797, 300, 400, new List<PropertyAndValue>(), new HitOrAvoidShorts(40, 0, 0, 0), new OuterAndInnerShorts(50, 20), new OuterAndInnerShorts(15, 0), -1, null, 100));
		_dataArray.Add(new ArmorItem(526, LocalStringManager.GetConfig("Armor_language", "Name_526"), 1, 104, 6, -1, "icon_Armor_gangpi", LocalStringManager.GetConfig("Armor_language", "Desc_526"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_526"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: false, 100, 0, 0, 0, 0, 0, 8, allowRandomCreate: false, allowRawCreate: false, allowCrippledCreate: false, 0, isSpecial: true, -1, 12, -1, new List<int>(), 1, -1, 1797, 600, 800, new List<PropertyAndValue>(), new HitOrAvoidShorts(60, 0, 0, 0), new OuterAndInnerShorts(100, 40), new OuterAndInnerShorts(30, 0), -1, null, 100));
		_dataArray.Add(new ArmorItem(527, LocalStringManager.GetConfig("Armor_language", "Name_527"), 1, 104, 6, -1, "icon_Armor_gangpi", LocalStringManager.GetConfig("Armor_language", "Desc_527"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_527"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: false, 100, 0, 0, 0, 0, 0, 8, allowRandomCreate: false, allowRawCreate: false, allowCrippledCreate: false, 0, isSpecial: true, -1, 12, -1, new List<int>(), 3, -1, 1797, 600, 800, new List<PropertyAndValue>(), new HitOrAvoidShorts(60, 0, 0, 0), new OuterAndInnerShorts(100, 40), new OuterAndInnerShorts(30, 0), -1, null, 100));
		_dataArray.Add(new ArmorItem(528, LocalStringManager.GetConfig("Armor_language", "Name_528"), 1, 104, 6, -1, "icon_Armor_gangpi", LocalStringManager.GetConfig("Armor_language", "Desc_528"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_528"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: false, 100, 0, 0, 0, 0, 0, 8, allowRandomCreate: false, allowRawCreate: false, allowCrippledCreate: false, 0, isSpecial: true, -1, 12, -1, new List<int>(), 4, -1, 1797, 600, 800, new List<PropertyAndValue>(), new HitOrAvoidShorts(60, 0, 0, 0), new OuterAndInnerShorts(100, 40), new OuterAndInnerShorts(30, 0), -1, null, 100));
		_dataArray.Add(new ArmorItem(529, LocalStringManager.GetConfig("Armor_language", "Name_529"), 1, 104, 6, -1, "icon_Armor_gangpi", LocalStringManager.GetConfig("Armor_language", "Desc_529"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_529"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: false, 100, 0, 0, 0, 0, 0, 8, allowRandomCreate: false, allowRawCreate: false, allowCrippledCreate: false, 0, isSpecial: true, -1, 12, -1, new List<int>(), 5, -1, 1797, 600, 800, new List<PropertyAndValue>(), new HitOrAvoidShorts(60, 0, 0, 0), new OuterAndInnerShorts(100, 40), new OuterAndInnerShorts(30, 0), -1, null, 100));
		_dataArray.Add(new ArmorItem(530, LocalStringManager.GetConfig("Armor_language", "Name_530"), 1, 104, 3, -1, "icon_Armor_houyu", LocalStringManager.GetConfig("Armor_language", "Desc_530"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_530"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: false, 40, 0, 0, 0, 0, 0, 8, allowRandomCreate: false, allowRawCreate: false, allowCrippledCreate: false, 0, isSpecial: true, -1, 12, -1, new List<int>(), 1, -1, 1797, 200, 300, new List<PropertyAndValue>(), new HitOrAvoidShorts(0, 0, 40, 0), new OuterAndInnerShorts(20, 50), new OuterAndInnerShorts(0, 15), -1, null, 100));
		_dataArray.Add(new ArmorItem(531, LocalStringManager.GetConfig("Armor_language", "Name_531"), 1, 104, 3, -1, "icon_Armor_houyu", LocalStringManager.GetConfig("Armor_language", "Desc_531"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_531"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: false, 40, 0, 0, 0, 0, 0, 8, allowRandomCreate: false, allowRawCreate: false, allowCrippledCreate: false, 0, isSpecial: true, -1, 12, -1, new List<int>(), 3, -1, 1797, 200, 300, new List<PropertyAndValue>(), new HitOrAvoidShorts(0, 0, 40, 0), new OuterAndInnerShorts(20, 50), new OuterAndInnerShorts(0, 15), -1, null, 100));
		_dataArray.Add(new ArmorItem(532, LocalStringManager.GetConfig("Armor_language", "Name_532"), 1, 104, 3, -1, "icon_Armor_houyu", LocalStringManager.GetConfig("Armor_language", "Desc_532"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_532"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: false, 40, 0, 0, 0, 0, 0, 8, allowRandomCreate: false, allowRawCreate: false, allowCrippledCreate: false, 0, isSpecial: true, -1, 12, -1, new List<int>(), 4, -1, 1797, 200, 300, new List<PropertyAndValue>(), new HitOrAvoidShorts(0, 0, 40, 0), new OuterAndInnerShorts(20, 50), new OuterAndInnerShorts(0, 15), -1, null, 100));
		_dataArray.Add(new ArmorItem(533, LocalStringManager.GetConfig("Armor_language", "Name_533"), 1, 104, 3, -1, "icon_Armor_houyu", LocalStringManager.GetConfig("Armor_language", "Desc_533"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_533"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: false, 40, 0, 0, 0, 0, 0, 8, allowRandomCreate: false, allowRawCreate: false, allowCrippledCreate: false, 0, isSpecial: true, -1, 12, -1, new List<int>(), 5, -1, 1797, 200, 300, new List<PropertyAndValue>(), new HitOrAvoidShorts(0, 0, 40, 0), new OuterAndInnerShorts(20, 50), new OuterAndInnerShorts(0, 15), -1, null, 100));
		_dataArray.Add(new ArmorItem(534, LocalStringManager.GetConfig("Armor_language", "Name_534"), 1, 104, 6, -1, "icon_Armor_jinling", LocalStringManager.GetConfig("Armor_language", "Desc_534"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_534"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: false, 60, 0, 0, 0, 0, 0, 8, allowRandomCreate: false, allowRawCreate: false, allowCrippledCreate: false, 0, isSpecial: true, -1, 12, -1, new List<int>(), 1, -1, 1797, 400, 600, new List<PropertyAndValue>(), new HitOrAvoidShorts(0, 0, 60, 0), new OuterAndInnerShorts(40, 100), new OuterAndInnerShorts(0, 30), -1, null, 100));
		_dataArray.Add(new ArmorItem(535, LocalStringManager.GetConfig("Armor_language", "Name_535"), 1, 104, 6, -1, "icon_Armor_jinling", LocalStringManager.GetConfig("Armor_language", "Desc_535"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_535"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: false, 60, 0, 0, 0, 0, 0, 8, allowRandomCreate: false, allowRawCreate: false, allowCrippledCreate: false, 0, isSpecial: true, -1, 12, -1, new List<int>(), 3, -1, 1797, 400, 600, new List<PropertyAndValue>(), new HitOrAvoidShorts(0, 0, 60, 0), new OuterAndInnerShorts(40, 100), new OuterAndInnerShorts(0, 30), -1, null, 100));
		_dataArray.Add(new ArmorItem(536, LocalStringManager.GetConfig("Armor_language", "Name_536"), 1, 104, 6, -1, "icon_Armor_jinling", LocalStringManager.GetConfig("Armor_language", "Desc_536"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_536"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: false, 60, 0, 0, 0, 0, 0, 8, allowRandomCreate: false, allowRawCreate: false, allowCrippledCreate: false, 0, isSpecial: true, -1, 12, -1, new List<int>(), 4, -1, 1797, 400, 600, new List<PropertyAndValue>(), new HitOrAvoidShorts(0, 0, 60, 0), new OuterAndInnerShorts(40, 100), new OuterAndInnerShorts(0, 30), -1, null, 100));
		_dataArray.Add(new ArmorItem(537, LocalStringManager.GetConfig("Armor_language", "Name_537"), 1, 104, 6, -1, "icon_Armor_jinling", LocalStringManager.GetConfig("Armor_language", "Desc_537"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_537"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: false, 60, 0, 0, 0, 0, 0, 8, allowRandomCreate: false, allowRawCreate: false, allowCrippledCreate: false, 0, isSpecial: true, -1, 12, -1, new List<int>(), 5, -1, 1797, 400, 600, new List<PropertyAndValue>(), new HitOrAvoidShorts(0, 0, 60, 0), new OuterAndInnerShorts(40, 100), new OuterAndInnerShorts(0, 30), -1, null, 100));
		_dataArray.Add(new ArmorItem(538, LocalStringManager.GetConfig("Armor_language", "Name_538"), 1, 104, 3, -1, "icon_Armor_houlin", LocalStringManager.GetConfig("Armor_language", "Desc_538"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_538"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: false, 60, 0, 0, 0, 0, 0, 8, allowRandomCreate: false, allowRawCreate: false, allowCrippledCreate: false, 0, isSpecial: true, -1, 12, -1, new List<int>(), 1, -1, 1797, 400, 350, new List<PropertyAndValue>(), new HitOrAvoidShorts(0, 40, 0, 0), new OuterAndInnerShorts(40, 40), new OuterAndInnerShorts(10, 10), -1, null, 100));
		_dataArray.Add(new ArmorItem(539, LocalStringManager.GetConfig("Armor_language", "Name_539"), 1, 104, 3, -1, "icon_Armor_houlin", LocalStringManager.GetConfig("Armor_language", "Desc_539"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_539"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: false, 60, 0, 0, 0, 0, 0, 8, allowRandomCreate: false, allowRawCreate: false, allowCrippledCreate: false, 0, isSpecial: true, -1, 12, -1, new List<int>(), 3, -1, 1797, 400, 350, new List<PropertyAndValue>(), new HitOrAvoidShorts(0, 40, 0, 0), new OuterAndInnerShorts(40, 40), new OuterAndInnerShorts(10, 10), -1, null, 100));
	}

	private void CreateItems9()
	{
		_dataArray.Add(new ArmorItem(540, LocalStringManager.GetConfig("Armor_language", "Name_540"), 1, 104, 6, -1, "icon_Armor_xuanlin", LocalStringManager.GetConfig("Armor_language", "Desc_540"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_540"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: false, 80, 0, 0, 0, 0, 0, 8, allowRandomCreate: false, allowRawCreate: false, allowCrippledCreate: false, 0, isSpecial: true, -1, 12, -1, new List<int>(), 1, -1, 1797, 800, 700, new List<PropertyAndValue>(), new HitOrAvoidShorts(0, 60, 0, 0), new OuterAndInnerShorts(80, 80), new OuterAndInnerShorts(20, 20), -1, null, 100));
		_dataArray.Add(new ArmorItem(541, LocalStringManager.GetConfig("Armor_language", "Name_541"), 1, 104, 6, -1, "icon_Armor_xuanlin", LocalStringManager.GetConfig("Armor_language", "Desc_541"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_541"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: false, 80, 0, 0, 0, 0, 0, 8, allowRandomCreate: false, allowRawCreate: false, allowCrippledCreate: false, 0, isSpecial: true, -1, 12, -1, new List<int>(), 3, -1, 1797, 800, 700, new List<PropertyAndValue>(), new HitOrAvoidShorts(0, 60, 0, 0), new OuterAndInnerShorts(80, 80), new OuterAndInnerShorts(20, 20), -1, null, 100));
		_dataArray.Add(new ArmorItem(542, LocalStringManager.GetConfig("Armor_language", "Name_542"), 1, 104, 8, -1, "icon_Armor_linglintou", LocalStringManager.GetConfig("Armor_language", "Desc_542"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_542"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: false, 80, 0, 0, 0, 0, 0, 8, allowRandomCreate: false, allowRawCreate: false, allowCrippledCreate: false, 0, isSpecial: true, -1, 12, -1, new List<int>(), 1, -1, 1797, 1600, 1400, new List<PropertyAndValue>(), new HitOrAvoidShorts(60, 0, 0, 0), new OuterAndInnerShorts(60, 60), new OuterAndInnerShorts(30, 30), -1, null, 100));
		_dataArray.Add(new ArmorItem(543, LocalStringManager.GetConfig("Armor_language", "Name_543"), 1, 104, 8, -1, "icon_Armor_linglin", LocalStringManager.GetConfig("Armor_language", "Desc_543"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_543"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: false, 80, 0, 0, 0, 0, 0, 8, allowRandomCreate: false, allowRawCreate: false, allowCrippledCreate: false, 0, isSpecial: true, -1, 12, -1, new List<int>(), 3, -1, 1797, 1600, 1400, new List<PropertyAndValue>(), new HitOrAvoidShorts(60, 0, 0, 0), new OuterAndInnerShorts(60, 60), new OuterAndInnerShorts(30, 30), -1, null, 100));
		_dataArray.Add(new ArmorItem(544, LocalStringManager.GetConfig("Armor_language", "Name_544"), 1, 104, 8, -1, "icon_Armor_linglintou", LocalStringManager.GetConfig("Armor_language", "Desc_544"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_544"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: false, 80, 0, 0, 0, 0, 0, 8, allowRandomCreate: false, allowRawCreate: false, allowCrippledCreate: false, 0, isSpecial: true, -1, 12, -1, new List<int>(), 1, -1, 1797, 1600, 1400, new List<PropertyAndValue>(), new HitOrAvoidShorts(0, 60, 0, 0), new OuterAndInnerShorts(60, 60), new OuterAndInnerShorts(30, 30), -1, null, 100));
		_dataArray.Add(new ArmorItem(545, LocalStringManager.GetConfig("Armor_language", "Name_545"), 1, 104, 8, -1, "icon_Armor_linglin", LocalStringManager.GetConfig("Armor_language", "Desc_545"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_545"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: false, 80, 0, 0, 0, 0, 0, 8, allowRandomCreate: false, allowRawCreate: false, allowCrippledCreate: false, 0, isSpecial: true, -1, 12, -1, new List<int>(), 3, -1, 1797, 1600, 1400, new List<PropertyAndValue>(), new HitOrAvoidShorts(0, 60, 0, 0), new OuterAndInnerShorts(60, 60), new OuterAndInnerShorts(30, 30), -1, null, 100));
		_dataArray.Add(new ArmorItem(546, LocalStringManager.GetConfig("Armor_language", "Name_546"), 1, 104, 8, -1, "icon_Armor_linglintou", LocalStringManager.GetConfig("Armor_language", "Desc_546"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_546"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: false, 80, 0, 0, 0, 0, 0, 8, allowRandomCreate: false, allowRawCreate: false, allowCrippledCreate: false, 0, isSpecial: true, -1, 12, -1, new List<int>(), 1, -1, 1797, 1600, 1400, new List<PropertyAndValue>(), new HitOrAvoidShorts(0, 0, 60, 0), new OuterAndInnerShorts(60, 60), new OuterAndInnerShorts(30, 30), -1, null, 100));
		_dataArray.Add(new ArmorItem(547, LocalStringManager.GetConfig("Armor_language", "Name_547"), 1, 104, 8, -1, "icon_Armor_linglin", LocalStringManager.GetConfig("Armor_language", "Desc_547"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_547"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: false, 80, 0, 0, 0, 0, 0, 8, allowRandomCreate: false, allowRawCreate: false, allowCrippledCreate: false, 0, isSpecial: true, -1, 12, -1, new List<int>(), 3, -1, 1797, 1600, 1400, new List<PropertyAndValue>(), new HitOrAvoidShorts(0, 0, 60, 0), new OuterAndInnerShorts(60, 60), new OuterAndInnerShorts(30, 30), -1, null, 100));
		_dataArray.Add(new ArmorItem(548, LocalStringManager.GetConfig("Armor_language", "Name_548"), 1, 104, 8, -1, "icon_Armor_linglintou", LocalStringManager.GetConfig("Armor_language", "Desc_548"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_548"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: false, 80, 0, 0, 0, 0, 0, 8, allowRandomCreate: false, allowRawCreate: false, allowCrippledCreate: false, 0, isSpecial: true, -1, 12, -1, new List<int>(), 1, -1, 1797, 1600, 1400, new List<PropertyAndValue>(), new HitOrAvoidShorts(0, 0, 0, 60), new OuterAndInnerShorts(60, 60), new OuterAndInnerShorts(30, 30), -1, null, 100));
		_dataArray.Add(new ArmorItem(549, LocalStringManager.GetConfig("Armor_language", "Name_549"), 1, 104, 8, -1, "icon_Armor_linglin", LocalStringManager.GetConfig("Armor_language", "Desc_549"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_549"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: false, 80, 0, 0, 0, 0, 0, 8, allowRandomCreate: false, allowRawCreate: false, allowCrippledCreate: false, 0, isSpecial: true, -1, 12, -1, new List<int>(), 3, -1, 1797, 1600, 1400, new List<PropertyAndValue>(), new HitOrAvoidShorts(0, 0, 0, 60), new OuterAndInnerShorts(60, 60), new OuterAndInnerShorts(30, 30), -1, null, 100));
		_dataArray.Add(new ArmorItem(550, LocalStringManager.GetConfig("Armor_language", "Name_550"), 1, 104, 8, -1, "icon_Armor_longlintou", LocalStringManager.GetConfig("Armor_language", "Desc_550"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_550"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: false, 240, 0, 0, 0, 0, 0, 8, allowRandomCreate: false, allowRawCreate: false, allowCrippledCreate: false, 0, isSpecial: true, -1, 12, -1, new List<int>(), 1, -1, 1797, 2200, 2200, new List<PropertyAndValue>(), new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(80, 80), new OuterAndInnerShorts(35, 35), -1, null, 100));
		_dataArray.Add(new ArmorItem(551, LocalStringManager.GetConfig("Armor_language", "Name_551"), 1, 104, 8, -1, "icon_Armor_longlinqu", LocalStringManager.GetConfig("Armor_language", "Desc_551"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_551"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: false, 240, 0, 0, 0, 0, 0, 8, allowRandomCreate: false, allowRawCreate: false, allowCrippledCreate: false, 0, isSpecial: true, -1, 12, -1, new List<int>(), 3, -1, 1797, 2200, 2200, new List<PropertyAndValue>(), new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(80, 80), new OuterAndInnerShorts(35, 35), -1, null, 100));
		_dataArray.Add(new ArmorItem(552, LocalStringManager.GetConfig("Armor_language", "Name_552"), 1, 104, 8, -1, "icon_Armor_longlinshou", LocalStringManager.GetConfig("Armor_language", "Desc_552"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_552"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: false, 240, 0, 0, 0, 0, 0, 8, allowRandomCreate: false, allowRawCreate: false, allowCrippledCreate: false, 0, isSpecial: true, -1, 12, -1, new List<int>(), 4, -1, 1797, 2200, 2200, new List<PropertyAndValue>(), new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(80, 80), new OuterAndInnerShorts(35, 35), -1, null, 100));
		_dataArray.Add(new ArmorItem(553, LocalStringManager.GetConfig("Armor_language", "Name_553"), 1, 104, 8, -1, "icon_Armor_longlinzu", LocalStringManager.GetConfig("Armor_language", "Desc_553"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_553"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: false, 240, 0, 0, 0, 0, 0, 8, allowRandomCreate: false, allowRawCreate: false, allowCrippledCreate: false, 0, isSpecial: true, -1, 12, -1, new List<int>(), 5, -1, 1797, 2200, 2200, new List<PropertyAndValue>(), new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(80, 80), new OuterAndInnerShorts(35, 35), -1, null, 100));
		_dataArray.Add(new ArmorItem(554, LocalStringManager.GetConfig("Armor_language", "Name_554"), 1, 104, 8, -1, "icon_Armor_xiaolongtou", LocalStringManager.GetConfig("Armor_language", "Desc_554"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_554"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: false, 120, 0, 0, 0, 0, 0, 8, allowRandomCreate: false, allowRawCreate: false, allowCrippledCreate: false, 0, isSpecial: true, -1, 12, -1, new List<int>(), 1, -1, 1797, 1800, 1800, new List<PropertyAndValue>(), new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(60, 60), new OuterAndInnerShorts(30, 30), -1, null, 100));
		_dataArray.Add(new ArmorItem(555, LocalStringManager.GetConfig("Armor_language", "Name_555"), 1, 104, 8, -1, "icon_Armor_xiaolongqu", LocalStringManager.GetConfig("Armor_language", "Desc_555"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_555"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: false, 120, 0, 0, 0, 0, 0, 8, allowRandomCreate: false, allowRawCreate: false, allowCrippledCreate: false, 0, isSpecial: true, -1, 12, -1, new List<int>(), 3, -1, 1797, 1800, 1800, new List<PropertyAndValue>(), new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(60, 60), new OuterAndInnerShorts(30, 30), -1, null, 100));
		_dataArray.Add(new ArmorItem(556, LocalStringManager.GetConfig("Armor_language", "Name_556"), 1, 104, 8, -1, "icon_Armor_xiaolongshou", LocalStringManager.GetConfig("Armor_language", "Desc_556"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_556"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: false, 120, 0, 0, 0, 0, 0, 8, allowRandomCreate: false, allowRawCreate: false, allowCrippledCreate: false, 0, isSpecial: true, -1, 12, -1, new List<int>(), 4, -1, 1797, 1800, 1800, new List<PropertyAndValue>(), new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(60, 60), new OuterAndInnerShorts(30, 30), -1, null, 100));
		_dataArray.Add(new ArmorItem(557, LocalStringManager.GetConfig("Armor_language", "Name_557"), 1, 104, 8, -1, "icon_Armor_xiaolongzu", LocalStringManager.GetConfig("Armor_language", "Desc_557"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_557"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: false, 120, 0, 0, 0, 0, 0, 8, allowRandomCreate: false, allowRawCreate: false, allowCrippledCreate: false, 0, isSpecial: true, -1, 12, -1, new List<int>(), 5, -1, 1797, 1800, 1800, new List<PropertyAndValue>(), new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(60, 60), new OuterAndInnerShorts(30, 30), -1, null, 100));
		_dataArray.Add(new ArmorItem(558, LocalStringManager.GetConfig("Armor_language", "Name_558"), 1, 104, 8, -1, "icon_Armor_jiaoyitou", LocalStringManager.GetConfig("Armor_language", "Desc_558"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_558"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: false, 80, 0, 0, 0, 0, 0, 8, allowRandomCreate: false, allowRawCreate: false, allowCrippledCreate: false, 0, isSpecial: true, -1, 12, -1, new List<int>(), 1, -1, 1797, 1200, 1200, new List<PropertyAndValue>(), new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(60, 60), new OuterAndInnerShorts(20, 20), -1, null, 100));
		_dataArray.Add(new ArmorItem(559, LocalStringManager.GetConfig("Armor_language", "Name_559"), 1, 104, 8, -1, "icon_Armor_jiaoyiqu", LocalStringManager.GetConfig("Armor_language", "Desc_559"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_559"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: false, 80, 0, 0, 0, 0, 0, 8, allowRandomCreate: false, allowRawCreate: false, allowCrippledCreate: false, 0, isSpecial: true, -1, 12, -1, new List<int>(), 3, -1, 1797, 1200, 1200, new List<PropertyAndValue>(), new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(60, 60), new OuterAndInnerShorts(20, 20), -1, null, 100));
		_dataArray.Add(new ArmorItem(560, LocalStringManager.GetConfig("Armor_language", "Name_560"), 1, 104, 8, -1, "icon_Armor_xuanke", LocalStringManager.GetConfig("Armor_language", "Desc_560"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_560"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: false, 160, 0, 0, 0, 0, 0, 8, allowRandomCreate: false, allowRawCreate: false, allowCrippledCreate: false, 0, isSpecial: true, -1, 12, -1, new List<int>(), 3, -1, 1797, 2600, 2600, new List<PropertyAndValue>(), new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(120, 120), new OuterAndInnerShorts(30, 30), -1, null, 100));
		_dataArray.Add(new ArmorItem(561, LocalStringManager.GetConfig("Armor_language", "Name_561"), 1, 104, 8, -1, "icon_Armor_qingxuantou", LocalStringManager.GetConfig("Armor_language", "Desc_561"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_561"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: false, 120, 0, 0, 0, 0, 0, 8, allowRandomCreate: false, allowRawCreate: false, allowCrippledCreate: false, 0, isSpecial: true, -1, 12, -1, new List<int>(), 1, -1, 1797, 1800, 1800, new List<PropertyAndValue>(), new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(60, 60), new OuterAndInnerShorts(30, 30), -1, null, 100));
		_dataArray.Add(new ArmorItem(562, LocalStringManager.GetConfig("Armor_language", "Name_562"), 1, 104, 8, -1, "icon_Armor_qingxuanqu", LocalStringManager.GetConfig("Armor_language", "Desc_562"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_562"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: false, 120, 0, 0, 0, 0, 0, 8, allowRandomCreate: false, allowRawCreate: false, allowCrippledCreate: false, 0, isSpecial: true, -1, 12, -1, new List<int>(), 3, -1, 1797, 1800, 1800, new List<PropertyAndValue>(), new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(60, 60), new OuterAndInnerShorts(30, 30), -1, null, 100));
		_dataArray.Add(new ArmorItem(563, LocalStringManager.GetConfig("Armor_language", "Name_563"), 1, 104, 8, -1, "icon_Armor_qingxuanshou", LocalStringManager.GetConfig("Armor_language", "Desc_563"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_563"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: false, 120, 0, 0, 0, 0, 0, 8, allowRandomCreate: false, allowRawCreate: false, allowCrippledCreate: false, 0, isSpecial: true, -1, 12, -1, new List<int>(), 4, -1, 1797, 1800, 1800, new List<PropertyAndValue>(), new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(60, 60), new OuterAndInnerShorts(30, 30), -1, null, 100));
		_dataArray.Add(new ArmorItem(564, LocalStringManager.GetConfig("Armor_language", "Name_564"), 1, 104, 7, -1, "icon_Armor_gangpi", LocalStringManager.GetConfig("Armor_language", "Desc_564"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_564"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: false, 120, 0, 0, 0, 0, 0, 8, allowRandomCreate: false, allowRawCreate: false, allowCrippledCreate: false, 0, isSpecial: true, -1, 12, -1, new List<int>(), 1, -1, 1797, 1400, 1600, new List<PropertyAndValue>(), new HitOrAvoidShorts(60, 0, 0, 0), new OuterAndInnerShorts(100, 40), new OuterAndInnerShorts(30, 0), -1, null, 100));
		_dataArray.Add(new ArmorItem(565, LocalStringManager.GetConfig("Armor_language", "Name_565"), 1, 104, 7, -1, "icon_Armor_gangpi", LocalStringManager.GetConfig("Armor_language", "Desc_565"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_565"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: false, 120, 0, 0, 0, 0, 0, 8, allowRandomCreate: false, allowRawCreate: false, allowCrippledCreate: false, 0, isSpecial: true, -1, 12, -1, new List<int>(), 3, -1, 1797, 1400, 1600, new List<PropertyAndValue>(), new HitOrAvoidShorts(60, 0, 0, 0), new OuterAndInnerShorts(100, 40), new OuterAndInnerShorts(30, 0), -1, null, 100));
		_dataArray.Add(new ArmorItem(566, LocalStringManager.GetConfig("Armor_language", "Name_566"), 1, 104, 7, -1, "icon_Armor_gangpi", LocalStringManager.GetConfig("Armor_language", "Desc_566"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_566"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: false, 120, 0, 0, 0, 0, 0, 8, allowRandomCreate: false, allowRawCreate: false, allowCrippledCreate: false, 0, isSpecial: true, -1, 12, -1, new List<int>(), 4, -1, 1797, 1400, 1600, new List<PropertyAndValue>(), new HitOrAvoidShorts(60, 0, 0, 0), new OuterAndInnerShorts(100, 40), new OuterAndInnerShorts(30, 0), -1, null, 100));
		_dataArray.Add(new ArmorItem(567, LocalStringManager.GetConfig("Armor_language", "Name_567"), 1, 104, 7, -1, "icon_Armor_gangpi", LocalStringManager.GetConfig("Armor_language", "Desc_567"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_567"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: false, 120, 0, 0, 0, 0, 0, 8, allowRandomCreate: false, allowRawCreate: false, allowCrippledCreate: false, 0, isSpecial: true, -1, 12, -1, new List<int>(), 5, -1, 1797, 1400, 1600, new List<PropertyAndValue>(), new HitOrAvoidShorts(60, 0, 0, 0), new OuterAndInnerShorts(100, 40), new OuterAndInnerShorts(30, 0), -1, null, 100));
		_dataArray.Add(new ArmorItem(568, LocalStringManager.GetConfig("Armor_language", "Name_568"), 1, 104, 7, -1, "icon_Armor_jinling", LocalStringManager.GetConfig("Armor_language", "Desc_568"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_568"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: false, 80, 0, 0, 0, 0, 0, 8, allowRandomCreate: false, allowRawCreate: false, allowCrippledCreate: false, 0, isSpecial: true, -1, 12, -1, new List<int>(), 1, -1, 1797, 1000, 1200, new List<PropertyAndValue>(), new HitOrAvoidShorts(0, 0, 60, 0), new OuterAndInnerShorts(40, 100), new OuterAndInnerShorts(0, 30), -1, null, 100));
		_dataArray.Add(new ArmorItem(569, LocalStringManager.GetConfig("Armor_language", "Name_569"), 1, 104, 7, -1, "icon_Armor_jinling", LocalStringManager.GetConfig("Armor_language", "Desc_569"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_569"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: false, 80, 0, 0, 0, 0, 0, 8, allowRandomCreate: false, allowRawCreate: false, allowCrippledCreate: false, 0, isSpecial: true, -1, 12, -1, new List<int>(), 3, -1, 1797, 1000, 1200, new List<PropertyAndValue>(), new HitOrAvoidShorts(0, 0, 60, 0), new OuterAndInnerShorts(40, 100), new OuterAndInnerShorts(0, 30), -1, null, 100));
		_dataArray.Add(new ArmorItem(570, LocalStringManager.GetConfig("Armor_language", "Name_570"), 1, 104, 7, -1, "icon_Armor_jinling", LocalStringManager.GetConfig("Armor_language", "Desc_570"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_570"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: false, 80, 0, 0, 0, 0, 0, 8, allowRandomCreate: false, allowRawCreate: false, allowCrippledCreate: false, 0, isSpecial: true, -1, 12, -1, new List<int>(), 4, -1, 1797, 1000, 1200, new List<PropertyAndValue>(), new HitOrAvoidShorts(0, 0, 60, 0), new OuterAndInnerShorts(40, 100), new OuterAndInnerShorts(0, 30), -1, null, 100));
		_dataArray.Add(new ArmorItem(571, LocalStringManager.GetConfig("Armor_language", "Name_571"), 1, 104, 7, -1, "icon_Armor_jinling", LocalStringManager.GetConfig("Armor_language", "Desc_571"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_571"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: false, 80, 0, 0, 0, 0, 0, 8, allowRandomCreate: false, allowRawCreate: false, allowCrippledCreate: false, 0, isSpecial: true, -1, 12, -1, new List<int>(), 5, -1, 1797, 1000, 1200, new List<PropertyAndValue>(), new HitOrAvoidShorts(0, 0, 60, 0), new OuterAndInnerShorts(40, 100), new OuterAndInnerShorts(0, 30), -1, null, 100));
		_dataArray.Add(new ArmorItem(572, LocalStringManager.GetConfig("Armor_language", "Name_572"), 1, 104, 7, -1, "icon_Armor_xuanlin", LocalStringManager.GetConfig("Armor_language", "Desc_572"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_572"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: false, 100, 0, 0, 0, 0, 0, 8, allowRandomCreate: false, allowRawCreate: false, allowCrippledCreate: false, 0, isSpecial: true, -1, 12, -1, new List<int>(), 1, -1, 1797, 1200, 1100, new List<PropertyAndValue>(), new HitOrAvoidShorts(0, 60, 0, 0), new OuterAndInnerShorts(80, 80), new OuterAndInnerShorts(20, 20), -1, null, 100));
		_dataArray.Add(new ArmorItem(573, LocalStringManager.GetConfig("Armor_language", "Name_573"), 1, 104, 7, -1, "icon_Armor_xuanlin", LocalStringManager.GetConfig("Armor_language", "Desc_573"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_573"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: false, 100, 0, 0, 0, 0, 0, 8, allowRandomCreate: false, allowRawCreate: false, allowCrippledCreate: false, 0, isSpecial: true, -1, 12, -1, new List<int>(), 3, -1, 1797, 1200, 1100, new List<PropertyAndValue>(), new HitOrAvoidShorts(0, 60, 0, 0), new OuterAndInnerShorts(80, 80), new OuterAndInnerShorts(20, 20), -1, null, 100));
		_dataArray.Add(new ArmorItem(574, LocalStringManager.GetConfig("Armor_language", "Name_574"), 1, 104, 7, -1, "icon_Armor_xuanlin", LocalStringManager.GetConfig("Armor_language", "Desc_574"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_574"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: false, 80, 0, 0, 0, 0, 0, 8, allowRandomCreate: false, allowRawCreate: false, allowCrippledCreate: false, 0, isSpecial: true, -1, 12, -1, new List<int>(), 4, -1, 1797, 1000, 1200, new List<PropertyAndValue>(), new HitOrAvoidShorts(0, 60, 0, 0), new OuterAndInnerShorts(80, 80), new OuterAndInnerShorts(20, 20), -1, null, 100));
		_dataArray.Add(new ArmorItem(575, LocalStringManager.GetConfig("Armor_language", "Name_575"), 1, 104, 7, -1, "icon_Armor_xuanlin", LocalStringManager.GetConfig("Armor_language", "Desc_575"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_575"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: false, 80, 0, 0, 0, 0, 0, 8, allowRandomCreate: false, allowRawCreate: false, allowCrippledCreate: false, 0, isSpecial: true, -1, 12, -1, new List<int>(), 5, -1, 1797, 1000, 1200, new List<PropertyAndValue>(), new HitOrAvoidShorts(0, 60, 0, 0), new OuterAndInnerShorts(80, 80), new OuterAndInnerShorts(20, 20), -1, null, 100));
		_dataArray.Add(new ArmorItem(576, LocalStringManager.GetConfig("Armor_language", "Name_576"), 1, 104, 7, -1, "icon_Armor_fuzhijia", LocalStringManager.GetConfig("Armor_language", "Desc_576"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_576"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: false, 100, 0, 0, 0, 0, 0, 8, allowRandomCreate: false, allowRawCreate: false, allowCrippledCreate: false, 0, isSpecial: true, -1, 12, -1, new List<int>(), 1, -1, 1797, 1200, 1400, new List<PropertyAndValue>(), new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(60, 80), new OuterAndInnerShorts(0, 30), -1, null, 100));
		_dataArray.Add(new ArmorItem(577, LocalStringManager.GetConfig("Armor_language", "Name_577"), 1, 104, 7, -1, "icon_Armor_fuzhijia", LocalStringManager.GetConfig("Armor_language", "Desc_577"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_577"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: false, 100, 0, 0, 0, 0, 0, 8, allowRandomCreate: false, allowRawCreate: false, allowCrippledCreate: false, 0, isSpecial: true, -1, 12, -1, new List<int>(), 3, -1, 1797, 1200, 1400, new List<PropertyAndValue>(), new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(60, 80), new OuterAndInnerShorts(0, 30), -1, null, 100));
		_dataArray.Add(new ArmorItem(578, LocalStringManager.GetConfig("Armor_language", "Name_578"), 1, 104, 7, -1, "icon_Armor_fuzhijia", LocalStringManager.GetConfig("Armor_language", "Desc_578"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_578"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: false, 100, 0, 0, 0, 0, 0, 8, allowRandomCreate: false, allowRawCreate: false, allowCrippledCreate: false, 0, isSpecial: true, -1, 12, -1, new List<int>(), 4, -1, 1797, 1200, 1400, new List<PropertyAndValue>(), new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(60, 80), new OuterAndInnerShorts(0, 30), -1, null, 100));
		_dataArray.Add(new ArmorItem(579, LocalStringManager.GetConfig("Armor_language", "Name_579"), 1, 104, 7, -1, "icon_Armor_fuzhijia", LocalStringManager.GetConfig("Armor_language", "Desc_579"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_579"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: false, 100, 0, 0, 0, 0, 0, 8, allowRandomCreate: false, allowRawCreate: false, allowCrippledCreate: false, 0, isSpecial: true, -1, 12, -1, new List<int>(), 5, -1, 1797, 1200, 1400, new List<PropertyAndValue>(), new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(60, 80), new OuterAndInnerShorts(0, 30), -1, null, 100));
		_dataArray.Add(new ArmorItem(580, LocalStringManager.GetConfig("Armor_language", "Name_580"), 1, 104, 7, -1, "icon_Armor_pixingke", LocalStringManager.GetConfig("Armor_language", "Desc_580"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_580"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: false, 80, 0, 0, 0, 0, 0, 8, allowRandomCreate: false, allowRawCreate: false, allowCrippledCreate: false, 0, isSpecial: true, -1, 12, -1, new List<int>(), 1, -1, 1797, 1000, 1200, new List<PropertyAndValue>(), new HitOrAvoidShorts(40, 40, 40, 0), new OuterAndInnerShorts(60, 60), new OuterAndInnerShorts(0, 30), -1, null, 100));
		_dataArray.Add(new ArmorItem(581, LocalStringManager.GetConfig("Armor_language", "Name_581"), 1, 104, 7, -1, "icon_Armor_pixingke", LocalStringManager.GetConfig("Armor_language", "Desc_581"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_581"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: false, 80, 0, 0, 0, 0, 0, 8, allowRandomCreate: false, allowRawCreate: false, allowCrippledCreate: false, 0, isSpecial: true, -1, 12, -1, new List<int>(), 3, -1, 1797, 1000, 1200, new List<PropertyAndValue>(), new HitOrAvoidShorts(40, 40, 40, 0), new OuterAndInnerShorts(60, 60), new OuterAndInnerShorts(0, 30), -1, null, 100));
		_dataArray.Add(new ArmorItem(582, LocalStringManager.GetConfig("Armor_language", "Name_582"), 1, 104, 7, -1, "icon_Armor_rongrongke", LocalStringManager.GetConfig("Armor_language", "Desc_582"), LocalStringManager.GetConfig("Armor_language", "FunctionDesc_582"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, detachable: false, 140, 0, 0, 0, 0, 0, 8, allowRandomCreate: false, allowRawCreate: false, allowCrippledCreate: false, 0, isSpecial: true, -1, 12, -1, new List<int>(), 3, -1, 1797, 2100, 2100, new List<PropertyAndValue>(), new HitOrAvoidShorts(default(short), default(short), default(short), default(short)), new OuterAndInnerShorts(100, 100), new OuterAndInnerShorts(30, 30), -1, null, 100));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<ArmorItem>(583);
		CreateItems0();
		CreateItems1();
		CreateItems2();
		CreateItems3();
		CreateItems4();
		CreateItems5();
		CreateItems6();
		CreateItems7();
		CreateItems8();
		CreateItems9();
	}
}
