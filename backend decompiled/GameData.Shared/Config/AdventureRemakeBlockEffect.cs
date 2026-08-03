using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class AdventureRemakeBlockEffect : ConfigData<AdventureRemakeBlockEffectItem, short>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 雾气
		/// </summary>
		public const short Fog = 0;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 雾气
		/// </summary>
		public static AdventureRemakeBlockEffectItem Fog => Instance[(short)0];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static AdventureRemakeBlockEffect Instance = new AdventureRemakeBlockEffect();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "Desc", "TemplateId", "LoadName" };

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
		_dataArray.Add(new AdventureRemakeBlockEffectItem(0, LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Name_0"), LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Desc_0"), "eff_adventure_new_wuqi", EAdventureRemakeBlockEffectLocation.Down));
		_dataArray.Add(new AdventureRemakeBlockEffectItem(1, LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Name_1"), LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Desc_1"), "eff_adventure_lzg_shuikou", EAdventureRemakeBlockEffectLocation.Down));
		_dataArray.Add(new AdventureRemakeBlockEffectItem(2, LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Name_2"), LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Desc_2"), "eff_adventure_lzg_yanwusanqu", EAdventureRemakeBlockEffectLocation.Down));
		_dataArray.Add(new AdventureRemakeBlockEffectItem(3, LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Name_3"), LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Desc_3"), "eff_adventure_lzg_mizhang", EAdventureRemakeBlockEffectLocation.Down));
		_dataArray.Add(new AdventureRemakeBlockEffectItem(4, LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Name_4"), LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Desc_4"), "eff_adventure_caodui", EAdventureRemakeBlockEffectLocation.Top));
		_dataArray.Add(new AdventureRemakeBlockEffectItem(5, LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Name_5"), LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Desc_5"), "eff_adventure_youhuopen", EAdventureRemakeBlockEffectLocation.Top));
		_dataArray.Add(new AdventureRemakeBlockEffectItem(6, LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Name_6"), LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Desc_6"), "eff_adventure_jianbingzi", EAdventureRemakeBlockEffectLocation.Top));
		_dataArray.Add(new AdventureRemakeBlockEffectItem(7, LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Name_7"), LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Desc_7"), "eff_adventure_caomu", EAdventureRemakeBlockEffectLocation.Down));
		_dataArray.Add(new AdventureRemakeBlockEffectItem(8, LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Name_8"), LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Desc_8"), "eff_adventure_yushijintie", EAdventureRemakeBlockEffectLocation.Down));
		_dataArray.Add(new AdventureRemakeBlockEffectItem(9, LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Name_9"), LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Desc_9"), "eff_adventure_putuan", EAdventureRemakeBlockEffectLocation.Top));
		_dataArray.Add(new AdventureRemakeBlockEffectItem(10, LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Name_10"), LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Desc_10"), "eff_adventure_buketongxing", EAdventureRemakeBlockEffectLocation.Top));
		_dataArray.Add(new AdventureRemakeBlockEffectItem(11, LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Name_11"), LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Desc_11"), "eff_adventure_xianjing01", EAdventureRemakeBlockEffectLocation.Top));
		_dataArray.Add(new AdventureRemakeBlockEffectItem(12, LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Name_12"), LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Desc_12"), "eff_adventure_huanhai_fazhen_in", EAdventureRemakeBlockEffectLocation.Down));
		_dataArray.Add(new AdventureRemakeBlockEffectItem(13, LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Name_13"), LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Desc_13"), "eff_adventure_huanhai_fazhen_loop", EAdventureRemakeBlockEffectLocation.Down));
		_dataArray.Add(new AdventureRemakeBlockEffectItem(14, LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Name_14"), LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Desc_14"), "eff_adventure_huanhai_fazhen_out", EAdventureRemakeBlockEffectLocation.Down));
		_dataArray.Add(new AdventureRemakeBlockEffectItem(15, LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Name_15"), LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Desc_15"), "eff_adventure_huanhai_qingyan", EAdventureRemakeBlockEffectLocation.Down));
		_dataArray.Add(new AdventureRemakeBlockEffectItem(16, LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Name_16"), LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Desc_16"), "eff_adventure_huanhai_jian", EAdventureRemakeBlockEffectLocation.Top));
		_dataArray.Add(new AdventureRemakeBlockEffectItem(17, LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Name_17"), LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Desc_17"), "eff_adventure_huanhai_jianqing", EAdventureRemakeBlockEffectLocation.Top));
		_dataArray.Add(new AdventureRemakeBlockEffectItem(18, LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Name_18"), LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Desc_18"), "eff_adventure_jianzhu1", EAdventureRemakeBlockEffectLocation.Top));
		_dataArray.Add(new AdventureRemakeBlockEffectItem(19, LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Name_19"), LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Desc_19"), "eff_adventure_jianzhu2", EAdventureRemakeBlockEffectLocation.Top));
		_dataArray.Add(new AdventureRemakeBlockEffectItem(20, LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Name_20"), LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Desc_20"), "eff_adventure_jianzhu3", EAdventureRemakeBlockEffectLocation.Top));
		_dataArray.Add(new AdventureRemakeBlockEffectItem(21, LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Name_21"), LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Desc_21"), "eff_adventure_jianzhu4", EAdventureRemakeBlockEffectLocation.Top));
		_dataArray.Add(new AdventureRemakeBlockEffectItem(22, LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Name_22"), LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Desc_22"), "eff_adventure_jianzhu5", EAdventureRemakeBlockEffectLocation.Top));
		_dataArray.Add(new AdventureRemakeBlockEffectItem(23, LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Name_23"), LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Desc_23"), "eff_adventure_biwuyanwu", EAdventureRemakeBlockEffectLocation.Top));
		_dataArray.Add(new AdventureRemakeBlockEffectItem(24, LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Name_24"), LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Desc_24"), "eff_adventure_ui_zhakai2", EAdventureRemakeBlockEffectLocation.Top));
		_dataArray.Add(new AdventureRemakeBlockEffectItem(25, LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Name_25"), LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Desc_25"), "eff_adventure_ui_yanzhakai", EAdventureRemakeBlockEffectLocation.Top));
		_dataArray.Add(new AdventureRemakeBlockEffectItem(26, LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Name_26"), LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Desc_26"), "eff_adventure_ui_zhakai1", EAdventureRemakeBlockEffectLocation.Top));
		_dataArray.Add(new AdventureRemakeBlockEffectItem(27, LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Name_27"), LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Desc_27"), "eff_adventure_ui_duwu2", EAdventureRemakeBlockEffectLocation.Top));
		_dataArray.Add(new AdventureRemakeBlockEffectItem(28, LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Name_28"), LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Desc_28"), "eff_adventure_ui_duwu1", EAdventureRemakeBlockEffectLocation.Top));
		_dataArray.Add(new AdventureRemakeBlockEffectItem(29, LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Name_29"), LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Desc_29"), "eff__adventure_guishaoxianjing", EAdventureRemakeBlockEffectLocation.Top));
		_dataArray.Add(new AdventureRemakeBlockEffectItem(30, LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Name_30"), LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Desc_30"), "eff_adventure_fengxihe", EAdventureRemakeBlockEffectLocation.Top));
		_dataArray.Add(new AdventureRemakeBlockEffectItem(31, LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Name_31"), LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Desc_31"), "eff_adventure_fengxi", EAdventureRemakeBlockEffectLocation.Top));
		_dataArray.Add(new AdventureRemakeBlockEffectItem(32, LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Name_32"), LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Desc_32"), "eff_adventure_new_wuqi01", EAdventureRemakeBlockEffectLocation.Down));
		_dataArray.Add(new AdventureRemakeBlockEffectItem(33, LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Name_33"), LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Desc_33"), "eff_adventure_new_wuqi02", EAdventureRemakeBlockEffectLocation.Down));
		_dataArray.Add(new AdventureRemakeBlockEffectItem(34, LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Name_34"), LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Desc_34"), "eff_adventure_xingxinglanse", EAdventureRemakeBlockEffectLocation.Top));
		_dataArray.Add(new AdventureRemakeBlockEffectItem(35, LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Name_35"), LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Desc_35"), "eff_adventure_xingxingjinse", EAdventureRemakeBlockEffectLocation.Top));
		_dataArray.Add(new AdventureRemakeBlockEffectItem(36, LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Name_36"), LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Desc_36"), "eff_adventure_new_wuqi04", EAdventureRemakeBlockEffectLocation.Top));
		_dataArray.Add(new AdventureRemakeBlockEffectItem(37, LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Name_37"), LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Desc_37"), "eff_adventure_lansehuo", EAdventureRemakeBlockEffectLocation.Top));
		_dataArray.Add(new AdventureRemakeBlockEffectItem(38, LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Name_38"), LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Desc_38"), "eff_adventure_shenmoyn_baiguang", EAdventureRemakeBlockEffectLocation.Top));
		_dataArray.Add(new AdventureRemakeBlockEffectItem(39, LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Name_39"), LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Desc_39"), "eff_adventure_shenmoyn_balizi", EAdventureRemakeBlockEffectLocation.Top));
		_dataArray.Add(new AdventureRemakeBlockEffectItem(40, LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Name_40"), LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Desc_40"), "eff_adventure_shenmoyn_guangquan1", EAdventureRemakeBlockEffectLocation.Top));
		_dataArray.Add(new AdventureRemakeBlockEffectItem(41, LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Name_41"), LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Desc_41"), "eff_adventure_shenmoyn_guangquan2", EAdventureRemakeBlockEffectLocation.Top));
		_dataArray.Add(new AdventureRemakeBlockEffectItem(42, LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Name_42"), LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Desc_42"), "eff_adventure_shenmoyn_heiguang_in", EAdventureRemakeBlockEffectLocation.Down));
		_dataArray.Add(new AdventureRemakeBlockEffectItem(43, LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Name_43"), LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Desc_43"), "eff_adventure_shenmoyn_heiguang_loop", EAdventureRemakeBlockEffectLocation.Down));
		_dataArray.Add(new AdventureRemakeBlockEffectItem(44, LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Name_44"), LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Desc_44"), "eff_adventure_shenmoyn_heiguang_out", EAdventureRemakeBlockEffectLocation.Down));
		_dataArray.Add(new AdventureRemakeBlockEffectItem(45, LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Name_45"), LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Desc_45"), "eff_adventure_shenmoyn_jianqi", EAdventureRemakeBlockEffectLocation.Top));
		_dataArray.Add(new AdventureRemakeBlockEffectItem(46, LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Name_46"), LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Desc_46"), "eff_adventure_shenmoyn_jinshandian_in", EAdventureRemakeBlockEffectLocation.Down));
		_dataArray.Add(new AdventureRemakeBlockEffectItem(47, LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Name_47"), LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Desc_47"), "eff_adventure_shenmoyn_jinshandian_loop", EAdventureRemakeBlockEffectLocation.Down));
		_dataArray.Add(new AdventureRemakeBlockEffectItem(48, LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Name_48"), LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Desc_48"), "eff_adventure_shenmoyn_jinshandian_out", EAdventureRemakeBlockEffectLocation.Down));
		_dataArray.Add(new AdventureRemakeBlockEffectItem(49, LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Name_49"), LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Desc_49"), "eff_adventure_shenmoyn_qiangguang_in", EAdventureRemakeBlockEffectLocation.Down));
		_dataArray.Add(new AdventureRemakeBlockEffectItem(50, LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Name_50"), LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Desc_50"), "eff_adventure_shenmoyn_qiangguang_loop", EAdventureRemakeBlockEffectLocation.Down));
		_dataArray.Add(new AdventureRemakeBlockEffectItem(51, LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Name_51"), LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Desc_51"), "eff_adventure_shenmoyn_qiangguang_out", EAdventureRemakeBlockEffectLocation.Down));
		_dataArray.Add(new AdventureRemakeBlockEffectItem(52, LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Name_52"), LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Desc_52"), "eff_adventure_shenmoyn_wu", EAdventureRemakeBlockEffectLocation.Top));
		_dataArray.Add(new AdventureRemakeBlockEffectItem(53, LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Name_53"), LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Desc_53"), "eff_adventure_weijihuo", EAdventureRemakeBlockEffectLocation.Top));
		_dataArray.Add(new AdventureRemakeBlockEffectItem(54, LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Name_54"), LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Desc_54"), "eff_adventure_ui_chenggong", EAdventureRemakeBlockEffectLocation.Top));
		_dataArray.Add(new AdventureRemakeBlockEffectItem(55, LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Name_55"), LocalStringManager.GetConfig("AdventureRemakeBlockEffect_language", "Desc_55"), "eff_adventure_ui_shibai", EAdventureRemakeBlockEffectLocation.Top));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<AdventureRemakeBlockEffectItem>(56);
		CreateItems0();
	}
}
