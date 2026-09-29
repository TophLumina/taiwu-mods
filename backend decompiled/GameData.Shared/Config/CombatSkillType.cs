using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class CombatSkillType : ConfigData<CombatSkillTypeItem, sbyte>
{
	public static CombatSkillType Instance = new CombatSkillType();

	private readonly HashSet<string> RequiredFields = new HashSet<string>
	{
		"Name", "Desc", "PersonalityType", "LegendaryBookWeaponSlot", "LegendaryBookSkillSlots", "LegendaryBookAddPropertyYin", "LegendaryBookAddPropertyYang", "LegendaryBookFeature", "LegendaryBookTaiwuFeature", "LegendaryBookConsumedFeature",
		"LegendaryBookTemplateId", "CombatMatchAdventure", "TipsDesc", "TemplateId", "LoadingTexture", "Icon", "DisplayIcon", "DisplayIconOutLine", "DisplayIconBig", "TipsIcon",
		"LegendaryBookWeaponSlotItemSubTypes", "LegendaryBookEffectSlotYin", "LegendaryBookEffectSlotYang"
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
		_dataArray.Add(new CombatSkillTypeItem(0, LocalStringManager.GetConfig("CombatSkillType_language", "Name_0"), "tex_combatskilltype_0", "sp_icon_dawuxue_0", "ui9_back_attainments_combat_2_0", "ui9_icon_attainments_big_0_0", "sp_18_iconwuxue_0", "mousetip_gongfa_0", LocalStringManager.GetConfig("CombatSkillType_language", "Desc_0"), 0, 0, new List<short> { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, null, new List<short>
		{
			2, 43, 43, 43, 15, 43, 43, 43, 0, 43,
			43, 43
		}, new List<short>
		{
			2, 43, 43, 43, 15, 43, 43, 43, 0, 43,
			43, 43
		}, new List<sbyte> { 1, 2, 5 }, new List<sbyte> { 0, 3, 4 }, 636, 650, 664, 240, 0, 0, LocalStringManager.GetConfig("CombatSkillType_language", "TipsDesc_0")));
		_dataArray.Add(new CombatSkillTypeItem(1, LocalStringManager.GetConfig("CombatSkillType_language", "Name_1"), "tex_combatskilltype_1", "sp_icon_dawuxue_1", "ui9_back_attainments_combat_2_1", "ui9_icon_attainments_big_0_1", "sp_18_iconwuxue_1", "mousetip_gongfa_1", LocalStringManager.GetConfig("CombatSkillType_language", "Desc_1"), 1, 10, new List<short> { 11, 12, 13, 14, 15, 16, 17, 18, 19 }, null, new List<short>
		{
			4, 44, 44, 44, 16, 44, 44, 44, 4, 44,
			44, 44
		}, new List<short>
		{
			4, 44, 44, 44, 16, 44, 44, 44, 4, 44,
			44, 44
		}, new List<sbyte> { 1, 2, 5 }, new List<sbyte> { 0, 3, 4 }, 637, 651, 665, 241, 0, 0, LocalStringManager.GetConfig("CombatSkillType_language", "TipsDesc_1")));
		_dataArray.Add(new CombatSkillTypeItem(2, LocalStringManager.GetConfig("CombatSkillType_language", "Name_2"), "tex_combatskilltype_2", "sp_icon_dawuxue_2", "ui9_back_attainments_combat_2_2", "ui9_icon_attainments_big_0_2", "sp_18_iconwuxue_2", "mousetip_gongfa_2", LocalStringManager.GetConfig("CombatSkillType_language", "Desc_2"), 2, 20, new List<short> { 21, 22, 23, 24, 25, 26, 27, 28, 29 }, null, new List<short>
		{
			9, 45, 45, 45, 17, 45, 45, 45, 9, 45,
			45, 45
		}, new List<short>
		{
			9, 45, 45, 45, 17, 45, 45, 45, 9, 45,
			45, 45
		}, new List<sbyte> { 1, 2, 5 }, new List<sbyte> { 0, 3, 4 }, 638, 652, 666, 242, 0, 0, LocalStringManager.GetConfig("CombatSkillType_language", "TipsDesc_2")));
		_dataArray.Add(new CombatSkillTypeItem(3, LocalStringManager.GetConfig("CombatSkillType_language", "Name_3"), "tex_combatskilltype_3", "sp_icon_dawuxue_3", "ui9_back_attainments_combat_2_3", "ui9_icon_attainments_big_0_3", "sp_18_iconwuxue_3", "mousetip_gongfa_3", LocalStringManager.GetConfig("CombatSkillType_language", "Desc_3"), 3, 30, new List<short> { 31, 32, 33, 34, 35, 36, 37, 38, 39 }, new List<short> { 4 }, new List<short>
		{
			10, 46, 46, 46, 18, 46, 46, 46, 10, 46,
			46, 46
		}, new List<short>
		{
			10, 46, 46, 46, 18, 46, 46, 46, 10, 46,
			46, 46
		}, new List<sbyte> { 2, 1, 4 }, new List<sbyte> { 0, -1, 3 }, 639, 653, 667, 243, 248555998, 0, LocalStringManager.GetConfig("CombatSkillType_language", "TipsDesc_3")));
		_dataArray.Add(new CombatSkillTypeItem(4, LocalStringManager.GetConfig("CombatSkillType_language", "Name_4"), "tex_combatskilltype_4", "sp_icon_dawuxue_4", "ui9_back_attainments_combat_2_4", "ui9_icon_attainments_big_0_4", "sp_18_iconwuxue_4", "mousetip_gongfa_4", LocalStringManager.GetConfig("CombatSkillType_language", "Desc_4"), 4, 40, new List<short> { 41, 42, 43, 44, 45, 46, 47, 48, 49 }, new List<short> { 4 }, new List<short>
		{
			6, 47, 47, 47, 19, 47, 47, 47, 6, 47,
			47, 47
		}, new List<short>
		{
			6, 47, 47, 47, 19, 47, 47, 47, 6, 47,
			47, 47
		}, new List<sbyte> { 2, 1, 4 }, new List<sbyte> { 0, -1, 3 }, 640, 654, 668, 244, 0, 0, LocalStringManager.GetConfig("CombatSkillType_language", "TipsDesc_4")));
		_dataArray.Add(new CombatSkillTypeItem(5, LocalStringManager.GetConfig("CombatSkillType_language", "Name_5"), "tex_combatskilltype_5", "sp_icon_dawuxue_5", "ui9_back_attainments_combat_2_5", "ui9_icon_attainments_big_0_5", "sp_18_iconwuxue_5", "mousetip_gongfa_5", LocalStringManager.GetConfig("CombatSkillType_language", "Desc_5"), 5, 50, new List<short> { 51, 52, 53, 54, 55, 56, 57, 58, 59 }, null, new List<short>
		{
			13, 48, 48, 48, 20, 48, 48, 48, 13, 48,
			48, 48
		}, new List<short>
		{
			13, 48, 48, 48, 20, 48, 48, 48, 13, 48,
			48, 48
		}, new List<sbyte> { 2, 1, 4 }, new List<sbyte> { 0, -1, 3 }, 641, 655, 669, 245, 0, 0, LocalStringManager.GetConfig("CombatSkillType_language", "TipsDesc_5")));
		_dataArray.Add(new CombatSkillTypeItem(6, LocalStringManager.GetConfig("CombatSkillType_language", "Name_6"), "tex_combatskilltype_6", "sp_icon_dawuxue_6", "ui9_back_attainments_combat_2_6", "ui9_icon_attainments_big_0_6", "sp_18_iconwuxue_6", "mousetip_gongfa_6", LocalStringManager.GetConfig("CombatSkillType_language", "Desc_6"), 6, 60, new List<short> { 61, 62, 63, 64, 65, 66, 67, 68, 69 }, new List<short> { 2, 14, 15 }, new List<short>
		{
			7, 49, 49, 49, 21, 49, 49, 49, 7, 49,
			49, 49
		}, new List<short>
		{
			7, 49, 49, 49, 21, 49, 49, 49, 7, 49,
			49, 49
		}, new List<sbyte> { 2, 1, 4 }, new List<sbyte> { 0, -1, 3 }, 642, 656, 670, 246, 0, 0, LocalStringManager.GetConfig("CombatSkillType_language", "TipsDesc_6")));
		_dataArray.Add(new CombatSkillTypeItem(7, LocalStringManager.GetConfig("CombatSkillType_language", "Name_7"), "tex_combatskilltype_7", "sp_icon_dawuxue_7", "ui9_back_attainments_combat_2_7", "ui9_icon_attainments_big_0_7", "sp_18_iconwuxue_7", "mousetip_gongfa_7", LocalStringManager.GetConfig("CombatSkillType_language", "Desc_7"), 0, 70, new List<short> { 71, 72, 73, 74, 75, 76, 77, 78, 79 }, new List<short> { 8 }, new List<short>
		{
			8, 50, 50, 50, 22, 50, 50, 50, 8, 50,
			50, 50
		}, new List<short>
		{
			8, 50, 50, 50, 22, 50, 50, 50, 8, 50,
			50, 50
		}, new List<sbyte> { 2, 1, 4 }, new List<sbyte> { 0, -1, 3 }, 643, 657, 671, 247, 237866249, 0, LocalStringManager.GetConfig("CombatSkillType_language", "TipsDesc_7")));
		_dataArray.Add(new CombatSkillTypeItem(8, LocalStringManager.GetConfig("CombatSkillType_language", "Name_8"), "tex_combatskilltype_8", "sp_icon_dawuxue_8", "ui9_back_attainments_combat_2_8", "ui9_icon_attainments_big_0_8", "sp_18_iconwuxue_8", "mousetip_gongfa_8", LocalStringManager.GetConfig("CombatSkillType_language", "Desc_8"), 1, 80, new List<short> { 81, 82, 83, 84, 85, 86, 87, 88, 89 }, new List<short> { 9 }, new List<short>
		{
			5, 51, 51, 51, 23, 51, 51, 51, 5, 51,
			51, 51
		}, new List<short>
		{
			5, 51, 51, 51, 23, 51, 51, 51, 5, 51,
			51, 51
		}, new List<sbyte> { 2, 1, 4 }, new List<sbyte> { 0, -1, 3 }, 644, 658, 672, 248, 0, 0, LocalStringManager.GetConfig("CombatSkillType_language", "TipsDesc_8")));
		_dataArray.Add(new CombatSkillTypeItem(9, LocalStringManager.GetConfig("CombatSkillType_language", "Name_9"), "tex_combatskilltype_9", "sp_icon_dawuxue_9", "ui9_back_attainments_combat_2_9", "ui9_icon_attainments_big_0_9", "sp_18_iconwuxue_9", "mousetip_gongfa_9", LocalStringManager.GetConfig("CombatSkillType_language", "Desc_9"), 2, 90, new List<short> { 91, 92, 93, 94, 95, 96, 97, 98, 99 }, new List<short> { 10 }, new List<short>
		{
			3, 52, 52, 52, 24, 52, 52, 52, 3, 52,
			52, 52
		}, new List<short>
		{
			3, 52, 52, 52, 24, 52, 52, 52, 3, 52,
			52, 52
		}, new List<sbyte> { 2, 1, 4 }, new List<sbyte> { 0, -1, 3 }, 645, 659, 673, 249, 0, 0, LocalStringManager.GetConfig("CombatSkillType_language", "TipsDesc_9")));
		_dataArray.Add(new CombatSkillTypeItem(10, LocalStringManager.GetConfig("CombatSkillType_language", "Name_10"), "tex_combatskilltype_10", "sp_icon_dawuxue_10", "ui9_back_attainments_combat_2_10", "ui9_icon_attainments_big_0_10", "sp_18_iconwuxue_10", "mousetip_gongfa_10", LocalStringManager.GetConfig("CombatSkillType_language", "Desc_10"), 3, 100, new List<short> { 101, 102, 103, 104, 105, 106, 107, 108, 109 }, new List<short> { 1, 5, 13 }, new List<short>
		{
			12, 53, 53, 53, 25, 53, 53, 53, 12, 53,
			53, 53
		}, new List<short>
		{
			12, 53, 53, 53, 25, 53, 53, 53, 12, 53,
			53, 53
		}, new List<sbyte> { 2, 1, 4 }, new List<sbyte> { 0, -1, 3 }, 646, 660, 674, 250, 163293008, 0, LocalStringManager.GetConfig("CombatSkillType_language", "TipsDesc_10")));
		_dataArray.Add(new CombatSkillTypeItem(11, LocalStringManager.GetConfig("CombatSkillType_language", "Name_11"), "tex_combatskilltype_11", "sp_icon_dawuxue_11", "ui9_back_attainments_combat_2_11", "ui9_icon_attainments_big_0_11", "sp_18_iconwuxue_11", "mousetip_gongfa_11", LocalStringManager.GetConfig("CombatSkillType_language", "Desc_11"), 4, 110, new List<short> { 111, 112, 113, 114, 115, 116, 117, 118, 119 }, new List<short> { 6, 7 }, new List<short>
		{
			11, 54, 54, 54, 26, 54, 54, 54, 11, 54,
			54, 54
		}, new List<short>
		{
			11, 54, 54, 54, 26, 54, 54, 54, 11, 54,
			54, 54
		}, new List<sbyte> { 2, 1, 4 }, new List<sbyte> { 0, -1, 3 }, 647, 661, 675, 251, 0, 0, LocalStringManager.GetConfig("CombatSkillType_language", "TipsDesc_11")));
		_dataArray.Add(new CombatSkillTypeItem(12, LocalStringManager.GetConfig("CombatSkillType_language", "Name_12"), "tex_combatskilltype_12", "sp_icon_dawuxue_12", "ui9_back_attainments_combat_2_12", "ui9_icon_attainments_big_0_12", "sp_18_iconwuxue_12", "mousetip_gongfa_12", LocalStringManager.GetConfig("CombatSkillType_language", "Desc_12"), 5, 120, new List<short> { 121, 122, 123, 124, 125, 126, 127, 128, 129 }, new List<short> { 0, 12 }, new List<short>
		{
			1, 55, 55, 55, 27, 55, 55, 55, 1, 55,
			55, 55
		}, new List<short>
		{
			1, 55, 55, 55, 27, 55, 55, 55, 1, 55,
			55, 55
		}, new List<sbyte> { 2, 1, 4 }, new List<sbyte> { 0, -1, 3 }, 648, 662, 676, 252, 0, 0, LocalStringManager.GetConfig("CombatSkillType_language", "TipsDesc_12")));
		_dataArray.Add(new CombatSkillTypeItem(13, LocalStringManager.GetConfig("CombatSkillType_language", "Name_13"), "tex_combatskilltype_13", "sp_icon_dawuxue_13", "ui9_back_attainments_combat_2_13", "ui9_icon_attainments_big_0_13", "sp_18_iconwuxue_13", "mousetip_gongfa_13", LocalStringManager.GetConfig("CombatSkillType_language", "Desc_13"), 6, 130, new List<short> { 131, 132, 133, 134, 135, 136, 137, 138, 139 }, new List<short> { 3, 11 }, new List<short>
		{
			14, 56, 56, 56, 28, 56, 56, 56, 14, 56,
			56, 56
		}, new List<short>
		{
			14, 56, 56, 56, 28, 56, 56, 56, 14, 56,
			56, 56
		}, new List<sbyte> { 2, 1, 4 }, new List<sbyte> { 0, -1, 3 }, 649, 663, 677, 253, 0, 0, LocalStringManager.GetConfig("CombatSkillType_language", "TipsDesc_13")));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<CombatSkillTypeItem>(14);
		CreateItems0();
	}
}
