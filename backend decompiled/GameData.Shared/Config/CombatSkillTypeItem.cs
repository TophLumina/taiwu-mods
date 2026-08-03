using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class CombatSkillTypeItem : ConfigItem<CombatSkillTypeItem, sbyte>
{
	/// <summary>
	/// 模板ID
	/// </summary>
	public readonly sbyte TemplateId;

	/// <summary>
	/// 名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// Loading界面插画
	/// </summary>
	public readonly string LoadingTexture;

	/// <summary>
	/// 图标
	/// </summary>
	public readonly string Icon;

	/// <summary>
	/// 展示图标
	/// - 40*40
	/// </summary>
	public readonly string DisplayIcon;

	/// <summary>
	/// 稍大一圈的带勾线展示图标
	/// - 48*48
	/// </summary>
	public readonly string DisplayIconOutLine;

	/// <summary>
	/// 稍大一圈的展示图标
	/// - 90*90
	/// </summary>
	public readonly string DisplayIconBig;

	/// <summary>
	/// 用于Tips的小图标
	/// </summary>
	public readonly string TipsIcon;

	/// <summary>
	/// 说明
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 对应七元
	/// </summary>
	public readonly sbyte PersonalityType;

	/// <summary>
	/// 奇书兵器栏位
	/// </summary>
	public readonly short LegendaryBookWeaponSlot;

	/// <summary>
	/// 奇书功法栏位列表
	/// </summary>
	public readonly List<short> LegendaryBookSkillSlots;

	/// <summary>
	/// 奇书兵器栏位可放置兵器类型
	/// - 配置值为ItemSubType。留空表示不限类型
	/// </summary>
	public readonly List<short> LegendaryBookWeaponSlotItemSubTypes;

	/// <summary>
	/// 奇书加成点列表-阴
	/// </summary>
	public readonly List<short> LegendaryBookAddPropertyYin;

	/// <summary>
	/// 奇书加成点列表-阳
	/// </summary>
	public readonly List<short> LegendaryBookAddPropertyYang;

	/// <summary>
	/// 奇书特效栏位-阴
	/// - 0~8为功法栏位，-1表示兵器栏位
	/// </summary>
	public readonly List<sbyte> LegendaryBookEffectSlotYin;

	/// <summary>
	/// 奇书特效栏位-阳
	/// </summary>
	public readonly List<sbyte> LegendaryBookEffectSlotYang;

	/// <summary>
	/// 奇书特性
	/// </summary>
	public readonly short LegendaryBookFeature;

	/// <summary>
	/// 奇书特性-太吾
	/// </summary>
	public readonly short LegendaryBookTaiwuFeature;

	/// <summary>
	/// 相枢吞噬奇书特性
	/// </summary>
	public readonly short LegendaryBookConsumedFeature;

	/// <summary>
	/// 奇书物品id
	/// </summary>
	public readonly short LegendaryBookTemplateId;

	/// <summary>
	/// 夏日比武奇遇
	/// </summary>
	public readonly int CombatMatchAdventure;

	/// <summary>
	/// 加载页面可用
	/// - 0可用 1不可用
	/// </summary>
	public readonly byte AvailableOnLoading;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板ID</param>
	/// <param name="name">名称</param>
	/// <param name="loadingTexture">Loading界面插画</param>
	/// <param name="icon">图标</param>
	/// <param name="displayIcon">展示图标 - 40*40</param>
	/// <param name="displayIconOutLine">稍大一圈的带勾线展示图标 - 48*48</param>
	/// <param name="displayIconBig">稍大一圈的展示图标 - 90*90</param>
	/// <param name="tipsIcon">用于Tips的小图标</param>
	/// <param name="desc">说明</param>
	/// <param name="personalityType">对应七元</param>
	/// <param name="legendaryBookWeaponSlot">奇书兵器栏位</param>
	/// <param name="legendaryBookSkillSlots">奇书功法栏位列表</param>
	/// <param name="legendaryBookWeaponSlotItemSubTypes">奇书兵器栏位可放置兵器类型 - 配置值为ItemSubType。留空表示不限类型</param>
	/// <param name="legendaryBookAddPropertyYin">奇书加成点列表-阴</param>
	/// <param name="legendaryBookAddPropertyYang">奇书加成点列表-阳</param>
	/// <param name="legendaryBookEffectSlotYin">奇书特效栏位-阴 - 0~8为功法栏位，-1表示兵器栏位</param>
	/// <param name="legendaryBookEffectSlotYang">奇书特效栏位-阳</param>
	/// <param name="legendaryBookFeature">奇书特性</param>
	/// <param name="legendaryBookTaiwuFeature">奇书特性-太吾</param>
	/// <param name="legendaryBookConsumedFeature">相枢吞噬奇书特性</param>
	/// <param name="legendaryBookTemplateId">奇书物品id</param>
	/// <param name="combatMatchAdventure">夏日比武奇遇</param>
	/// <param name="availableOnLoading">加载页面可用 - 0可用 1不可用</param>
	public CombatSkillTypeItem(sbyte templateId, string name, string loadingTexture, string icon, string displayIcon, string displayIconOutLine, string displayIconBig, string tipsIcon, string desc, sbyte personalityType, short legendaryBookWeaponSlot, List<short> legendaryBookSkillSlots, List<short> legendaryBookWeaponSlotItemSubTypes, List<short> legendaryBookAddPropertyYin, List<short> legendaryBookAddPropertyYang, List<sbyte> legendaryBookEffectSlotYin, List<sbyte> legendaryBookEffectSlotYang, short legendaryBookFeature, short legendaryBookTaiwuFeature, short legendaryBookConsumedFeature, short legendaryBookTemplateId, int combatMatchAdventure, byte availableOnLoading)
	{
		TemplateId = templateId;
		Name = name;
		LoadingTexture = loadingTexture;
		Icon = icon;
		DisplayIcon = displayIcon;
		DisplayIconOutLine = displayIconOutLine;
		DisplayIconBig = displayIconBig;
		TipsIcon = tipsIcon;
		Desc = desc;
		PersonalityType = personalityType;
		LegendaryBookWeaponSlot = legendaryBookWeaponSlot;
		LegendaryBookSkillSlots = legendaryBookSkillSlots;
		LegendaryBookWeaponSlotItemSubTypes = legendaryBookWeaponSlotItemSubTypes;
		LegendaryBookAddPropertyYin = legendaryBookAddPropertyYin;
		LegendaryBookAddPropertyYang = legendaryBookAddPropertyYang;
		LegendaryBookEffectSlotYin = legendaryBookEffectSlotYin;
		LegendaryBookEffectSlotYang = legendaryBookEffectSlotYang;
		LegendaryBookFeature = legendaryBookFeature;
		LegendaryBookTaiwuFeature = legendaryBookTaiwuFeature;
		LegendaryBookConsumedFeature = legendaryBookConsumedFeature;
		LegendaryBookTemplateId = legendaryBookTemplateId;
		CombatMatchAdventure = combatMatchAdventure;
		AvailableOnLoading = availableOnLoading;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public CombatSkillTypeItem()
	{
		TemplateId = 0;
		Name = null;
		LoadingTexture = null;
		Icon = null;
		DisplayIcon = null;
		DisplayIconOutLine = null;
		DisplayIconBig = null;
		TipsIcon = null;
		Desc = null;
		PersonalityType = 0;
		LegendaryBookWeaponSlot = 0;
		LegendaryBookSkillSlots = new List<short>();
		LegendaryBookWeaponSlotItemSubTypes = null;
		LegendaryBookAddPropertyYin = null;
		LegendaryBookAddPropertyYang = null;
		LegendaryBookEffectSlotYin = null;
		LegendaryBookEffectSlotYang = null;
		LegendaryBookFeature = 0;
		LegendaryBookTaiwuFeature = 0;
		LegendaryBookConsumedFeature = 0;
		LegendaryBookTemplateId = 0;
		CombatMatchAdventure = 0;
		AvailableOnLoading = 0;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public CombatSkillTypeItem(sbyte templateId, CombatSkillTypeItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		LoadingTexture = other.LoadingTexture;
		Icon = other.Icon;
		DisplayIcon = other.DisplayIcon;
		DisplayIconOutLine = other.DisplayIconOutLine;
		DisplayIconBig = other.DisplayIconBig;
		TipsIcon = other.TipsIcon;
		Desc = other.Desc;
		PersonalityType = other.PersonalityType;
		LegendaryBookWeaponSlot = other.LegendaryBookWeaponSlot;
		LegendaryBookSkillSlots = other.LegendaryBookSkillSlots;
		LegendaryBookWeaponSlotItemSubTypes = other.LegendaryBookWeaponSlotItemSubTypes;
		LegendaryBookAddPropertyYin = other.LegendaryBookAddPropertyYin;
		LegendaryBookAddPropertyYang = other.LegendaryBookAddPropertyYang;
		LegendaryBookEffectSlotYin = other.LegendaryBookEffectSlotYin;
		LegendaryBookEffectSlotYang = other.LegendaryBookEffectSlotYang;
		LegendaryBookFeature = other.LegendaryBookFeature;
		LegendaryBookTaiwuFeature = other.LegendaryBookTaiwuFeature;
		LegendaryBookConsumedFeature = other.LegendaryBookConsumedFeature;
		LegendaryBookTemplateId = other.LegendaryBookTemplateId;
		CombatMatchAdventure = other.CombatMatchAdventure;
		AvailableOnLoading = other.AvailableOnLoading;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override CombatSkillTypeItem Duplicate(int templateId)
	{
		return new CombatSkillTypeItem((sbyte)templateId, this);
	}
}
