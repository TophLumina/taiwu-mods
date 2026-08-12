using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class LifeSkillType : ConfigData<LifeSkillTypeItem, sbyte>
{
	/// <summary>
	/// 配置表实例
	/// </summary>
	public static LifeSkillType Instance = new LifeSkillType();

	private readonly HashSet<string> RequiredFields = new HashSet<string>
	{
		"Name", "Desc", "PersonalityType", "InformationTemplateId", "MakeDesc", "DialogInBattle", "TemplateId", "Icon", "DisplayIcon", "DisplayIconOutLine",
		"DisplayIconBig", "BackgroundTexture", "LoadingTexture", "AttainmentEffectTexture", "SkillList"
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
		_dataArray.Add(new LifeSkillTypeItem(0, LocalStringManager.GetConfig("LifeSkillType_language", "Name_0"), LocalStringManager.GetConfig("LifeSkillType_language", "Desc_0"), "sp_icon_dajiyi_0", "ui9_back_attainments_life_2_0", "ui9_icon_craftsmanship_big_0_0", "sp_14_iconone_0", "charactermenu3_14_part_beijing_0", "tex_lifeskilltype_0", "charactermenu3_16_chahua_0", 0, 30, new short[9] { 0, 1, 2, 3, 4, 5, 6, 7, 8 }, LocalStringManager.GetConfig("LifeSkillType_language", "MakeDesc_0"), LocalStringManager.GetConfig("LifeSkillType_language", "DialogInBattle_0"), 0));
		_dataArray.Add(new LifeSkillTypeItem(1, LocalStringManager.GetConfig("LifeSkillType_language", "Name_1"), LocalStringManager.GetConfig("LifeSkillType_language", "Desc_1"), "sp_icon_dajiyi_1", "ui9_back_attainments_life_2_1", "ui9_icon_craftsmanship_big_0_1", "sp_14_iconone_1", "charactermenu3_14_part_beijing_1", "tex_lifeskilltype_1", "charactermenu3_16_chahua_1", 1, 31, new short[9] { 9, 10, 11, 12, 13, 14, 15, 16, 17 }, LocalStringManager.GetConfig("LifeSkillType_language", "MakeDesc_1"), LocalStringManager.GetConfig("LifeSkillType_language", "DialogInBattle_1"), 0));
		_dataArray.Add(new LifeSkillTypeItem(2, LocalStringManager.GetConfig("LifeSkillType_language", "Name_2"), LocalStringManager.GetConfig("LifeSkillType_language", "Desc_2"), "sp_icon_dajiyi_2", "ui9_back_attainments_life_2_2", "ui9_icon_craftsmanship_big_0_2", "sp_14_iconone_2", "charactermenu3_14_part_beijing_2", "tex_lifeskilltype_2", "charactermenu3_16_chahua_2", 2, 32, new short[9] { 18, 19, 20, 21, 22, 23, 24, 25, 26 }, LocalStringManager.GetConfig("LifeSkillType_language", "MakeDesc_2"), LocalStringManager.GetConfig("LifeSkillType_language", "DialogInBattle_2"), 0));
		_dataArray.Add(new LifeSkillTypeItem(3, LocalStringManager.GetConfig("LifeSkillType_language", "Name_3"), LocalStringManager.GetConfig("LifeSkillType_language", "Desc_3"), "sp_icon_dajiyi_3", "ui9_back_attainments_life_2_3", "ui9_icon_craftsmanship_big_0_3", "sp_14_iconone_3", "charactermenu3_14_part_beijing_3", "tex_lifeskilltype_3", "charactermenu3_16_chahua_3", 3, 33, new short[9] { 27, 28, 29, 30, 31, 32, 33, 34, 35 }, LocalStringManager.GetConfig("LifeSkillType_language", "MakeDesc_3"), LocalStringManager.GetConfig("LifeSkillType_language", "DialogInBattle_3"), 0));
		_dataArray.Add(new LifeSkillTypeItem(4, LocalStringManager.GetConfig("LifeSkillType_language", "Name_4"), LocalStringManager.GetConfig("LifeSkillType_language", "Desc_4"), "sp_icon_dajiyi_4", "ui9_back_attainments_life_2_4", "ui9_icon_craftsmanship_big_0_4", "sp_14_iconone_4", "charactermenu3_14_part_beijing_4", "tex_lifeskilltype_4", "charactermenu3_16_chahua_4", 4, 34, new short[9] { 36, 37, 38, 39, 40, 41, 42, 43, 44 }, LocalStringManager.GetConfig("LifeSkillType_language", "MakeDesc_4"), LocalStringManager.GetConfig("LifeSkillType_language", "DialogInBattle_4"), 0));
		_dataArray.Add(new LifeSkillTypeItem(5, LocalStringManager.GetConfig("LifeSkillType_language", "Name_5"), LocalStringManager.GetConfig("LifeSkillType_language", "Desc_5"), "sp_icon_dajiyi_5", "ui9_back_attainments_life_2_5", "ui9_icon_craftsmanship_big_0_5", "sp_14_iconone_5", "charactermenu3_14_part_beijing_5", "tex_lifeskilltype_5", "charactermenu3_16_chahua_5", 5, 35, new short[9] { 45, 46, 47, 48, 49, 50, 51, 52, 53 }, LocalStringManager.GetConfig("LifeSkillType_language", "MakeDesc_5"), LocalStringManager.GetConfig("LifeSkillType_language", "DialogInBattle_5"), 0));
		_dataArray.Add(new LifeSkillTypeItem(6, LocalStringManager.GetConfig("LifeSkillType_language", "Name_6"), LocalStringManager.GetConfig("LifeSkillType_language", "Desc_6"), "sp_icon_dajiyi_6", "ui9_back_attainments_life_2_6", "ui9_icon_craftsmanship_big_0_6", "sp_14_iconone_6", "charactermenu3_14_part_beijing_6", "tex_lifeskilltype_6", "charactermenu3_16_chahua_6", 6, 36, new short[9] { 54, 55, 56, 57, 58, 59, 60, 61, 62 }, LocalStringManager.GetConfig("LifeSkillType_language", "MakeDesc_6"), LocalStringManager.GetConfig("LifeSkillType_language", "DialogInBattle_6"), 0));
		_dataArray.Add(new LifeSkillTypeItem(7, LocalStringManager.GetConfig("LifeSkillType_language", "Name_7"), LocalStringManager.GetConfig("LifeSkillType_language", "Desc_7"), "sp_icon_dajiyi_7", "ui9_back_attainments_life_2_7", "ui9_icon_craftsmanship_big_0_7", "sp_14_iconone_7", "charactermenu3_14_part_beijing_7", "tex_lifeskilltype_7", "charactermenu3_16_chahua_7", 0, 37, new short[9] { 63, 64, 65, 66, 67, 68, 69, 70, 71 }, LocalStringManager.GetConfig("LifeSkillType_language", "MakeDesc_7"), LocalStringManager.GetConfig("LifeSkillType_language", "DialogInBattle_7"), 0));
		_dataArray.Add(new LifeSkillTypeItem(8, LocalStringManager.GetConfig("LifeSkillType_language", "Name_8"), LocalStringManager.GetConfig("LifeSkillType_language", "Desc_8"), "sp_icon_dajiyi_8", "ui9_back_attainments_life_2_8", "ui9_icon_craftsmanship_big_0_8", "sp_14_iconone_8", "charactermenu3_14_part_beijing_8", "tex_lifeskilltype_8", "charactermenu3_16_chahua_8", 1, 38, new short[9] { 72, 73, 74, 75, 76, 77, 78, 79, 80 }, LocalStringManager.GetConfig("LifeSkillType_language", "MakeDesc_8"), LocalStringManager.GetConfig("LifeSkillType_language", "DialogInBattle_8"), 0));
		_dataArray.Add(new LifeSkillTypeItem(9, LocalStringManager.GetConfig("LifeSkillType_language", "Name_9"), LocalStringManager.GetConfig("LifeSkillType_language", "Desc_9"), "sp_icon_dajiyi_9", "ui9_back_attainments_life_2_9", "ui9_icon_craftsmanship_big_0_9", "sp_14_iconone_9", "charactermenu3_14_part_beijing_9", "tex_lifeskilltype_9", "charactermenu3_16_chahua_9", 2, 39, new short[9] { 81, 82, 83, 84, 85, 86, 87, 88, 89 }, LocalStringManager.GetConfig("LifeSkillType_language", "MakeDesc_9"), LocalStringManager.GetConfig("LifeSkillType_language", "DialogInBattle_9"), 0));
		_dataArray.Add(new LifeSkillTypeItem(10, LocalStringManager.GetConfig("LifeSkillType_language", "Name_10"), LocalStringManager.GetConfig("LifeSkillType_language", "Desc_10"), "sp_icon_dajiyi_10", "ui9_back_attainments_life_2_10", "ui9_icon_craftsmanship_big_0_10", "sp_14_iconone_10", "charactermenu3_14_part_beijing_10", "tex_lifeskilltype_10", "charactermenu3_16_chahua_10", 3, 40, new short[9] { 90, 91, 92, 93, 94, 95, 96, 97, 98 }, LocalStringManager.GetConfig("LifeSkillType_language", "MakeDesc_10"), LocalStringManager.GetConfig("LifeSkillType_language", "DialogInBattle_10"), 0));
		_dataArray.Add(new LifeSkillTypeItem(11, LocalStringManager.GetConfig("LifeSkillType_language", "Name_11"), LocalStringManager.GetConfig("LifeSkillType_language", "Desc_11"), "sp_icon_dajiyi_11", "ui9_back_attainments_life_2_11", "ui9_icon_craftsmanship_big_0_11", "sp_14_iconone_11", "charactermenu3_14_part_beijing_11", "tex_lifeskilltype_11", "charactermenu3_16_chahua_11", 4, 41, new short[9] { 99, 100, 101, 102, 103, 104, 105, 106, 107 }, LocalStringManager.GetConfig("LifeSkillType_language", "MakeDesc_11"), LocalStringManager.GetConfig("LifeSkillType_language", "DialogInBattle_11"), 0));
		_dataArray.Add(new LifeSkillTypeItem(12, LocalStringManager.GetConfig("LifeSkillType_language", "Name_12"), LocalStringManager.GetConfig("LifeSkillType_language", "Desc_12"), "sp_icon_dajiyi_12", "ui9_back_attainments_life_2_12", "ui9_icon_craftsmanship_big_0_12", "sp_14_iconone_12", "charactermenu3_14_part_beijing_12", "tex_lifeskilltype_12", "charactermenu3_16_chahua_12", 5, 42, new short[9] { 108, 109, 110, 111, 112, 113, 114, 115, 116 }, LocalStringManager.GetConfig("LifeSkillType_language", "MakeDesc_12"), LocalStringManager.GetConfig("LifeSkillType_language", "DialogInBattle_12"), 0));
		_dataArray.Add(new LifeSkillTypeItem(13, LocalStringManager.GetConfig("LifeSkillType_language", "Name_13"), LocalStringManager.GetConfig("LifeSkillType_language", "Desc_13"), "sp_icon_dajiyi_13", "ui9_back_attainments_life_2_13", "ui9_icon_craftsmanship_big_0_13", "sp_14_iconone_13", "charactermenu3_14_part_beijing_13", "tex_lifeskilltype_13", "charactermenu3_16_chahua_13", 6, 43, new short[9] { 117, 118, 119, 120, 121, 122, 123, 124, 125 }, LocalStringManager.GetConfig("LifeSkillType_language", "MakeDesc_13"), LocalStringManager.GetConfig("LifeSkillType_language", "DialogInBattle_13"), 0));
		_dataArray.Add(new LifeSkillTypeItem(14, LocalStringManager.GetConfig("LifeSkillType_language", "Name_14"), LocalStringManager.GetConfig("LifeSkillType_language", "Desc_14"), "sp_icon_dajiyi_14", "ui9_back_attainments_life_2_14", "ui9_icon_craftsmanship_big_0_14", "sp_14_iconone_14", "charactermenu3_14_part_beijing_14", "tex_lifeskilltype_14", "charactermenu3_16_chahua_14", 0, 44, new short[9] { 126, 127, 128, 129, 130, 131, 132, 133, 134 }, LocalStringManager.GetConfig("LifeSkillType_language", "MakeDesc_14"), LocalStringManager.GetConfig("LifeSkillType_language", "DialogInBattle_14"), 0));
		_dataArray.Add(new LifeSkillTypeItem(15, LocalStringManager.GetConfig("LifeSkillType_language", "Name_15"), LocalStringManager.GetConfig("LifeSkillType_language", "Desc_15"), "sp_icon_dajiyi_15", "ui9_back_attainments_life_2_15", "ui9_icon_craftsmanship_big_0_15", "sp_14_iconone_15", "charactermenu3_14_part_beijing_15", "tex_lifeskilltype_15", "charactermenu3_16_chahua_15", 1, 45, new short[9] { 135, 136, 137, 138, 139, 140, 141, 142, 143 }, LocalStringManager.GetConfig("LifeSkillType_language", "MakeDesc_15"), LocalStringManager.GetConfig("LifeSkillType_language", "DialogInBattle_15"), 0));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<LifeSkillTypeItem>(16);
		CreateItems0();
	}
}
