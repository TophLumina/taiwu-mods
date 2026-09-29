using System;
using System.Diagnostics.CodeAnalysis;
using Config.Common;

namespace Config;

[Serializable]
public class LifeSkillTypeItem : ConfigItem<LifeSkillTypeItem, sbyte>
{
	public readonly sbyte TemplateId;

	public readonly string Name;

	public readonly string Desc;

	public readonly string Icon;

	public readonly string DisplayIcon;

	public readonly string DisplayIconOutLine;

	public readonly string DisplayIconBig;

	public readonly string BackgroundTexture;

	public readonly string LoadingTexture;

	public readonly string AttainmentEffectTexture;

	public readonly sbyte PersonalityType;

	public readonly short InformationTemplateId;

	public readonly short[] SkillList;

	public readonly string MakeDesc;

	public readonly string DialogInBattle;

	public readonly byte AvailableOnLoading;

	public readonly string TipsDesc;

	public InformationItem InformationTemplate
	{
		[return: MaybeNull]
		get
		{
			return Information.Instance.GetItemOrDefault(InformationTemplateId);
		}
	}

	public LifeSkillTypeItem(sbyte templateId, string name, string desc, string icon, string displayIcon, string displayIconOutLine, string displayIconBig, string backgroundTexture, string loadingTexture, string attainmentEffectTexture, sbyte personalityType, short informationTemplateId, short[] skillList, string makeDesc, string dialogInBattle, byte availableOnLoading, string tipsDesc)
	{
		TemplateId = templateId;
		Name = name;
		Desc = desc;
		Icon = icon;
		DisplayIcon = displayIcon;
		DisplayIconOutLine = displayIconOutLine;
		DisplayIconBig = displayIconBig;
		BackgroundTexture = backgroundTexture;
		LoadingTexture = loadingTexture;
		AttainmentEffectTexture = attainmentEffectTexture;
		PersonalityType = personalityType;
		InformationTemplateId = informationTemplateId;
		SkillList = skillList;
		MakeDesc = makeDesc;
		DialogInBattle = dialogInBattle;
		AvailableOnLoading = availableOnLoading;
		TipsDesc = tipsDesc;
	}

	public LifeSkillTypeItem()
	{
		TemplateId = 0;
		Name = null;
		Desc = null;
		Icon = null;
		DisplayIcon = null;
		DisplayIconOutLine = null;
		DisplayIconBig = null;
		BackgroundTexture = null;
		LoadingTexture = null;
		AttainmentEffectTexture = null;
		PersonalityType = 0;
		InformationTemplateId = 0;
		SkillList = null;
		MakeDesc = null;
		DialogInBattle = null;
		AvailableOnLoading = 0;
		TipsDesc = null;
	}

	public LifeSkillTypeItem(sbyte templateId, LifeSkillTypeItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Desc = other.Desc;
		Icon = other.Icon;
		DisplayIcon = other.DisplayIcon;
		DisplayIconOutLine = other.DisplayIconOutLine;
		DisplayIconBig = other.DisplayIconBig;
		BackgroundTexture = other.BackgroundTexture;
		LoadingTexture = other.LoadingTexture;
		AttainmentEffectTexture = other.AttainmentEffectTexture;
		PersonalityType = other.PersonalityType;
		InformationTemplateId = other.InformationTemplateId;
		SkillList = other.SkillList;
		MakeDesc = other.MakeDesc;
		DialogInBattle = other.DialogInBattle;
		AvailableOnLoading = other.AvailableOnLoading;
		TipsDesc = other.TipsDesc;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override LifeSkillTypeItem Duplicate(int templateId)
	{
		return new LifeSkillTypeItem((sbyte)templateId, this);
	}
}
