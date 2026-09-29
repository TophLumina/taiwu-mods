using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class DestinyType : ConfigData<DestinyTypeItem, sbyte>
{
	public static DestinyType Instance = new DestinyType();

	private readonly HashSet<string> RequiredFields = new HashSet<string>
	{
		"Name", "Desc", "Feature", "MotherLifeRecord", "SectList", "UnlockResourceTypeIcon", "TemplateId", "MoralityRange", "OrganizationGradeRange", "RecordColor",
		"UnlockCost", "LockedIcon", "UnlockedIcon"
	};

	internal override int ToInt(sbyte value)
	{
		return value;
	}

	internal override sbyte ToTemplateId(int value)
	{
		return (sbyte)value;
	}

	private void CreateItems0()
	{
		_dataArray.Add(new DestinyTypeItem(0, LocalStringManager.GetConfig("DestinyType_language", "Name_0"), LocalStringManager.GetConfig("DestinyType_language", "Desc_0"), 231, new short[2] { -500, -125 }, 401, new List<sbyte> { 1, 2, 3, 4, 5 }, new sbyte[2] { 0, 2 }, "lightred", LocalStringManager.GetConfig("DestinyType_language", "UnlockResourceTypeIcon_0"), new ushort[6] { 50000, 0, 0, 0, 0, 0 }, "building_liudao_lock_1_2", "building_liudao_1_2"));
		_dataArray.Add(new DestinyTypeItem(1, LocalStringManager.GetConfig("DestinyType_language", "Name_1"), LocalStringManager.GetConfig("DestinyType_language", "Desc_1"), 230, new short[2] { -500, -125 }, 402, new List<sbyte> { 6, 7, 8, 9, 10 }, new sbyte[2] { 1, 3 }, "lightred", LocalStringManager.GetConfig("DestinyType_language", "UnlockResourceTypeIcon_1"), new ushort[6] { 0, 0, 0, 0, 0, 50000 }, "building_liudao_lock_1_1", "building_liudao_1_1"));
		_dataArray.Add(new DestinyTypeItem(2, LocalStringManager.GetConfig("DestinyType_language", "Name_2"), LocalStringManager.GetConfig("DestinyType_language", "Desc_2"), 229, new short[2] { -500, 124 }, 403, new List<sbyte> { 11, 12, 13, 14, 15 }, new sbyte[2] { 2, 4 }, "lightred", LocalStringManager.GetConfig("DestinyType_language", "UnlockResourceTypeIcon_2"), new ushort[6] { 0, 0, 50000, 0, 0, 0 }, "building_liudao_lock_1_0", "building_liudao_1_0"));
		_dataArray.Add(new DestinyTypeItem(3, LocalStringManager.GetConfig("DestinyType_language", "Name_3"), LocalStringManager.GetConfig("DestinyType_language", "Desc_3"), 228, new short[2] { -124, 500 }, 404, new List<sbyte> { 11, 12, 13, 14, 15 }, new sbyte[2] { 4, 6 }, "lightblue", LocalStringManager.GetConfig("DestinyType_language", "UnlockResourceTypeIcon_3"), new ushort[6] { 0, 0, 0, 0, 50000, 0 }, "building_liudao_lock_0_2", "building_liudao_0_2"));
		_dataArray.Add(new DestinyTypeItem(4, LocalStringManager.GetConfig("DestinyType_language", "Name_4"), LocalStringManager.GetConfig("DestinyType_language", "Desc_4"), 227, new short[2] { 125, 500 }, 405, new List<sbyte> { 6, 7, 8, 9, 10 }, new sbyte[2] { 5, 7 }, "lightblue", LocalStringManager.GetConfig("DestinyType_language", "UnlockResourceTypeIcon_4"), new ushort[6] { 0, 50000, 0, 0, 0, 0 }, "building_liudao_lock_0_1", "building_liudao_0_1"));
		_dataArray.Add(new DestinyTypeItem(5, LocalStringManager.GetConfig("DestinyType_language", "Name_5"), LocalStringManager.GetConfig("DestinyType_language", "Desc_5"), 226, new short[2] { 125, 500 }, 406, new List<sbyte> { 1, 2, 3, 4, 5 }, new sbyte[2] { 6, 8 }, "lightblue", LocalStringManager.GetConfig("DestinyType_language", "UnlockResourceTypeIcon_5"), new ushort[6] { 0, 0, 0, 50000, 0, 0 }, "building_liudao_lock_0_0", "building_liudao_0_0"));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<DestinyTypeItem>(6);
		CreateItems0();
	}
}
