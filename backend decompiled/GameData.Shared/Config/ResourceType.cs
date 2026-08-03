using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class ResourceType : ConfigData<ResourceTypeItem, sbyte>
{
	/// <summary>
	/// 配置表实例
	/// </summary>
	public static ResourceType Instance = new ResourceType();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "Desc", "LifeSkillType", "PossibleBuildingCoreItem", "PossibleUpgradedBuildingCoreItem", "TemplateId", "Icon", "ImgPrefix" };

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
		_dataArray.Add(new ResourceTypeItem(0, LocalStringManager.GetConfig("ResourceType_language", "Name_0"), LocalStringManager.GetConfig("ResourceType_language", "Desc_0"), "ui9_icon_resource_bar_0", "charactermenu3_10_shicai_", 1, 25, 14, new short[3] { 100, 108, 109 }, new short[0], new string[0], new string[0], new string[0], new string[0]));
		_dataArray.Add(new ResourceTypeItem(1, LocalStringManager.GetConfig("ResourceType_language", "Name_1"), LocalStringManager.GetConfig("ResourceType_language", "Desc_1"), "ui9_icon_resource_bar_1", "charactermenu3_10_mucai_", 1, 25, 7, new short[2] { 102, 108 }, new short[2] { 112, 113 }, new string[2] { "se_combat_hit_wood_1", "se_combat_hit_wood_2" }, new string[1] { "se_combat_whoosh_wood" }, new string[2] { "se_combat_shock_wood_1", "se_combat_shock_wood_2" }, new string[2] { "se_combat_foot_wood_1", "se_combat_foot_wood_2" }));
		_dataArray.Add(new ResourceTypeItem(2, LocalStringManager.GetConfig("ResourceType_language", "Name_2"), LocalStringManager.GetConfig("ResourceType_language", "Desc_2"), "ui9_icon_resource_bar_2", "charactermenu3_10_jintie_", 1, 25, 6, new short[2] { 101, 103 }, new short[2] { 110, 111 }, new string[2] { "se_combat_hit_iron_1", "se_combat_hit_iron_2" }, new string[1] { "se_combat_whoosh_iron" }, new string[2] { "se_combat_shock_iron_1", "se_combat_shock_iron_2" }, new string[2] { "se_combat_foot_iron_1", "se_combat_foot_iron_2" }));
		_dataArray.Add(new ResourceTypeItem(3, LocalStringManager.GetConfig("ResourceType_language", "Name_3"), LocalStringManager.GetConfig("ResourceType_language", "Desc_3"), "ui9_icon_resource_bar_3", "charactermenu3_10_yushi_", 1, 25, 11, new short[2] { 103, 107 }, new short[2] { 118, 119 }, new string[2] { "se_combat_hit_jade_1", "se_combat_hit_jade_2" }, new string[1] { "se_combat_whoosh_jade" }, new string[2] { "se_combat_shock_jade_1", "se_combat_shock_jade_2" }, new string[2] { "se_combat_foot_jade_1", "se_combat_foot_jade_2" }));
		_dataArray.Add(new ResourceTypeItem(4, LocalStringManager.GetConfig("ResourceType_language", "Name_4"), LocalStringManager.GetConfig("ResourceType_language", "Desc_4"), "ui9_icon_resource_bar_4", "charactermenu3_10_zhiwu_", 1, 25, 10, new short[2] { 106, 109 }, new short[2] { 116, 117 }, new string[2] { "se_combat_hit_cloth_1", "se_combat_hit_cloth_2" }, new string[1] { "se_combat_whoosh_cloths" }, new string[2] { "se_combat_shock_cloth_1", "se_combat_shock_cloth_2" }, new string[2] { "se_combat_foot_cloth_1", "se_combat_foot_cloth_2" }));
		_dataArray.Add(new ResourceTypeItem(5, LocalStringManager.GetConfig("ResourceType_language", "Name_5"), LocalStringManager.GetConfig("ResourceType_language", "Desc_5"), "ui9_icon_resource_bar_5", "charactermenu3_10_yaocai_", 1, 25, 8, new short[2] { 104, 105 }, new short[2] { 114, 115 }, new string[0], new string[0], new string[0], new string[0]));
		_dataArray.Add(new ResourceTypeItem(6, LocalStringManager.GetConfig("ResourceType_language", "Name_6"), LocalStringManager.GetConfig("ResourceType_language", "Desc_6"), "ui9_icon_resource_bar_6", "charactermenu3_10_jinqian_", -1, -1, -1, new short[0], new short[0], new string[0], new string[0], new string[0], new string[0]));
		_dataArray.Add(new ResourceTypeItem(7, LocalStringManager.GetConfig("ResourceType_language", "Name_7"), LocalStringManager.GetConfig("ResourceType_language", "Desc_7"), "ui9_icon_resource_bar_7", "charactermenu3_10_weiwang_", -1, -1, -1, new short[0], new short[0], new string[0], new string[0], new string[0], new string[0]));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<ResourceTypeItem>(8);
		CreateItems0();
	}
}
