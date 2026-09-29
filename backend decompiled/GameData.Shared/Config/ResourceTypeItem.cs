using System;
using Config.Common;

namespace Config;

[Serializable]
public class ResourceTypeItem : ConfigItem<ResourceTypeItem, sbyte>
{
	public readonly sbyte TemplateId;

	public readonly string Name;

	public readonly string Desc;

	public readonly string Icon;

	public readonly string ImgPrefix;

	public readonly sbyte CollectMultiplier;

	public readonly sbyte ResourceReducePerCollection;

	public readonly sbyte LifeSkillType;

	public readonly short[] PossibleBuildingCoreItem;

	public readonly short[] PossibleUpgradedBuildingCoreItem;

	public readonly string[] HitSound;

	public readonly string[] WhooshSound;

	public readonly string[] ShockSound;

	public readonly string[] StepSound;

	public ResourceTypeItem(sbyte templateId, string name, string desc, string icon, string imgPrefix, sbyte collectMultiplier, sbyte resourceReducePerCollection, sbyte lifeSkillType, short[] possibleBuildingCoreItem, short[] possibleUpgradedBuildingCoreItem, string[] hitSound, string[] whooshSound, string[] shockSound, string[] stepSound)
	{
		TemplateId = templateId;
		Name = name;
		Desc = desc;
		Icon = icon;
		ImgPrefix = imgPrefix;
		CollectMultiplier = collectMultiplier;
		ResourceReducePerCollection = resourceReducePerCollection;
		LifeSkillType = lifeSkillType;
		PossibleBuildingCoreItem = possibleBuildingCoreItem;
		PossibleUpgradedBuildingCoreItem = possibleUpgradedBuildingCoreItem;
		HitSound = hitSound;
		WhooshSound = whooshSound;
		ShockSound = shockSound;
		StepSound = stepSound;
	}

	public ResourceTypeItem()
	{
		TemplateId = 0;
		Name = null;
		Desc = null;
		Icon = null;
		ImgPrefix = null;
		CollectMultiplier = -1;
		ResourceReducePerCollection = -1;
		LifeSkillType = 0;
		PossibleBuildingCoreItem = new short[0];
		PossibleUpgradedBuildingCoreItem = new short[0];
		HitSound = new string[0];
		WhooshSound = new string[0];
		ShockSound = new string[0];
		StepSound = new string[0];
	}

	public ResourceTypeItem(sbyte templateId, ResourceTypeItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Desc = other.Desc;
		Icon = other.Icon;
		ImgPrefix = other.ImgPrefix;
		CollectMultiplier = other.CollectMultiplier;
		ResourceReducePerCollection = other.ResourceReducePerCollection;
		LifeSkillType = other.LifeSkillType;
		PossibleBuildingCoreItem = other.PossibleBuildingCoreItem;
		PossibleUpgradedBuildingCoreItem = other.PossibleUpgradedBuildingCoreItem;
		HitSound = other.HitSound;
		WhooshSound = other.WhooshSound;
		ShockSound = other.ShockSound;
		StepSound = other.StepSound;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override ResourceTypeItem Duplicate(int templateId)
	{
		return new ResourceTypeItem((sbyte)templateId, this);
	}
}
