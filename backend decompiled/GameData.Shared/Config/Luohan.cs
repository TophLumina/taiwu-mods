using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class Luohan : ConfigData<LuohanItem, sbyte>
{
	/// <summary>
	/// 配置表实例
	/// </summary>
	public static Luohan Instance = new Luohan();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "Accessory", "Medicine", "Material", "TemplateId" };

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
		_dataArray.Add(new LuohanItem(0, LocalStringManager.GetConfig("Luohan_language", "Name_0"), 250, ELuohanBonusType.Medicine, new List<short> { 321 }, -1));
		_dataArray.Add(new LuohanItem(1, LocalStringManager.GetConfig("Luohan_language", "Name_1"), 251, ELuohanBonusType.Relation, null, -1));
		_dataArray.Add(new LuohanItem(2, LocalStringManager.GetConfig("Luohan_language", "Name_2"), 252, ELuohanBonusType.Medicine, new List<short> { 141, 153, 165, 177, 189, 201 }, -1));
		_dataArray.Add(new LuohanItem(3, LocalStringManager.GetConfig("Luohan_language", "Name_3"), 253, ELuohanBonusType.Material, null, 20));
		_dataArray.Add(new LuohanItem(4, LocalStringManager.GetConfig("Luohan_language", "Name_4"), 254, ELuohanBonusType.Medicine, new List<short> { 93 }, -1));
		_dataArray.Add(new LuohanItem(5, LocalStringManager.GetConfig("Luohan_language", "Name_5"), 255, ELuohanBonusType.Medicine, new List<short> { 273 }, -1));
		_dataArray.Add(new LuohanItem(6, LocalStringManager.GetConfig("Luohan_language", "Name_6"), 256, ELuohanBonusType.Medicine, new List<short> { 65 }, -1));
		_dataArray.Add(new LuohanItem(7, LocalStringManager.GetConfig("Luohan_language", "Name_7"), 257, ELuohanBonusType.Medicine, new List<short> { 297 }, -1));
		_dataArray.Add(new LuohanItem(8, LocalStringManager.GetConfig("Luohan_language", "Name_8"), 258, ELuohanBonusType.Medicine, new List<short> { 117 }, -1));
		_dataArray.Add(new LuohanItem(9, LocalStringManager.GetConfig("Luohan_language", "Name_9"), 259, ELuohanBonusType.Medicine, new List<short> { 285 }, -1));
		_dataArray.Add(new LuohanItem(10, LocalStringManager.GetConfig("Luohan_language", "Name_10"), 260, ELuohanBonusType.Material, null, 34));
		_dataArray.Add(new LuohanItem(11, LocalStringManager.GetConfig("Luohan_language", "Name_11"), 261, ELuohanBonusType.Medicine, new List<short> { 261 }, -1));
		_dataArray.Add(new LuohanItem(12, LocalStringManager.GetConfig("Luohan_language", "Name_12"), 262, ELuohanBonusType.Material, null, 48));
		_dataArray.Add(new LuohanItem(13, LocalStringManager.GetConfig("Luohan_language", "Name_13"), 263, ELuohanBonusType.Material, null, 6));
		_dataArray.Add(new LuohanItem(14, LocalStringManager.GetConfig("Luohan_language", "Name_14"), 264, ELuohanBonusType.Medicine, new List<short> { 105 }, -1));
		_dataArray.Add(new LuohanItem(15, LocalStringManager.GetConfig("Luohan_language", "Name_15"), 265, ELuohanBonusType.Exp, null, -1));
		_dataArray.Add(new LuohanItem(16, LocalStringManager.GetConfig("Luohan_language", "Name_16"), 266, ELuohanBonusType.Medicine, new List<short> { 129, 345 }, -1));
		_dataArray.Add(new LuohanItem(17, LocalStringManager.GetConfig("Luohan_language", "Name_17"), 267, ELuohanBonusType.Medicine, new List<short> { 213, 225 }, -1));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<LuohanItem>(18);
		CreateItems0();
	}
}
