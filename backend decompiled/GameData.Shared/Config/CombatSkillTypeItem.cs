using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Config.Common;

namespace Config;

[Serializable]
public class CombatSkillTypeItem : ConfigItem<CombatSkillTypeItem, sbyte>
{
	public readonly sbyte TemplateId;

	public readonly string Name;

	public readonly string LoadingTexture;

	public readonly string Icon;

	public readonly string DisplayIcon;

	public readonly string DisplayIconOutLine;

	public readonly string DisplayIconBig;

	public readonly string TipsIcon;

	public readonly string Desc;

	public readonly sbyte PersonalityType;

	public readonly short LegendaryBookWeaponSlot;

	public readonly List<short> LegendaryBookSkillSlots;

	public readonly List<short> LegendaryBookWeaponSlotItemSubTypes;

	public readonly List<short> LegendaryBookAddPropertyYin;

	public readonly List<short> LegendaryBookAddPropertyYang;

	public readonly List<sbyte> LegendaryBookEffectSlotYin;

	public readonly List<sbyte> LegendaryBookEffectSlotYang;

	public readonly short LegendaryBookFeature;

	public readonly short LegendaryBookTaiwuFeature;

	public readonly short LegendaryBookConsumedFeature;

	public readonly short LegendaryBookTemplateId;

	public readonly int CombatMatchAdventure;

	public readonly byte AvailableOnLoading;

	public readonly string TipsDesc;

	public MiscItem LegendaryBookTemplate
	{
		[return: MaybeNull]
		get
		{
			return Misc.Instance.GetItemOrDefault(LegendaryBookTemplateId);
		}
	}

	public CombatSkillTypeItem(sbyte templateId, string name, string loadingTexture, string icon, string displayIcon, string displayIconOutLine, string displayIconBig, string tipsIcon, string desc, sbyte personalityType, short legendaryBookWeaponSlot, List<short> legendaryBookSkillSlots, List<short> legendaryBookWeaponSlotItemSubTypes, List<short> legendaryBookAddPropertyYin, List<short> legendaryBookAddPropertyYang, List<sbyte> legendaryBookEffectSlotYin, List<sbyte> legendaryBookEffectSlotYang, short legendaryBookFeature, short legendaryBookTaiwuFeature, short legendaryBookConsumedFeature, short legendaryBookTemplateId, int combatMatchAdventure, byte availableOnLoading, string tipsDesc)
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
		TipsDesc = tipsDesc;
	}

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
		TipsDesc = null;
	}

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
		TipsDesc = other.TipsDesc;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override CombatSkillTypeItem Duplicate(int templateId)
	{
		return new CombatSkillTypeItem((sbyte)templateId, this);
	}
}
