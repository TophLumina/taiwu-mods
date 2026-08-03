using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class MapElementDisplayRuleGroup : ConfigData<MapElementDisplayRuleGroupItem, short>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 人物数量
		/// </summary>
		public const short CharacterCount = 0;

		/// <summary>
		/// 人物头像
		/// </summary>
		public const short CharacterAvatar = 1;

		/// <summary>
		/// 地图元素
		/// </summary>
		public const short MapElement = 2;

		/// <summary>
		/// 地图互动
		/// </summary>
		public const short MapInteract = 3;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 人物数量
		/// </summary>
		public static MapElementDisplayRuleGroupItem CharacterCount => Instance[(short)0];

		/// <summary>
		/// 人物头像
		/// </summary>
		public static MapElementDisplayRuleGroupItem CharacterAvatar => Instance[(short)1];

		/// <summary>
		/// 地图元素
		/// </summary>
		public static MapElementDisplayRuleGroupItem MapElement => Instance[(short)2];

		/// <summary>
		/// 地图互动
		/// </summary>
		public static MapElementDisplayRuleGroupItem MapInteract => Instance[(short)3];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
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
