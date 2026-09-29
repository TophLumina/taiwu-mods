using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class MapElementDisplayRuleGroup : ConfigData<MapElementDisplayRuleGroupItem, short>
{
	public static class DefKey
	{
		public const short CharacterCount = 0;

		public const short CharacterAvatar = 1;

		public const short MapElement = 2;

		public const short MapInteract = 3;
	}

	public static class DefValue
	{
		public static MapElementDisplayRuleGroupItem CharacterCount => Instance[(short)0];

		public static MapElementDisplayRuleGroupItem CharacterAvatar => Instance[(short)1];

		public static MapElementDisplayRuleGroupItem MapElement => Instance[(short)2];

		public static MapElementDisplayRuleGroupItem MapInteract => Instance[(short)3];
	}

	public static MapElementDisplayRuleGroup Instance = new MapElementDisplayRuleGroup();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "Desc", "TemplateId", "Icon" };

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
		_dataArray.Add(new MapElementDisplayRuleGroupItem(0, LocalStringManager.GetConfig("MapElementDisplayRuleGroup_language", "Name_0"), LocalStringManager.GetConfig("MapElementDisplayRuleGroup_language", "Desc_0"), "ui9_btn_mapelement_type_charactercount_0"));
		_dataArray.Add(new MapElementDisplayRuleGroupItem(1, LocalStringManager.GetConfig("MapElementDisplayRuleGroup_language", "Name_1"), LocalStringManager.GetConfig("MapElementDisplayRuleGroup_language", "Desc_1"), "ui9_btn_mapelement_type_characteravatar_0"));
		_dataArray.Add(new MapElementDisplayRuleGroupItem(2, LocalStringManager.GetConfig("MapElementDisplayRuleGroup_language", "Name_2"), LocalStringManager.GetConfig("MapElementDisplayRuleGroup_language", "Desc_2"), "ui9_btn_mapelement_type_mapelement_0"));
		_dataArray.Add(new MapElementDisplayRuleGroupItem(3, LocalStringManager.GetConfig("MapElementDisplayRuleGroup_language", "Name_3"), LocalStringManager.GetConfig("MapElementDisplayRuleGroup_language", "Desc_3"), "ui9_btn_mapelement_type_mapinteract_0"));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<MapElementDisplayRuleGroupItem>(4);
		CreateItems0();
	}
}
