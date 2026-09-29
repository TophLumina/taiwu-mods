using System;
using System.Diagnostics.CodeAnalysis;
using Config.Common;
using GameData.Domains.Character;

namespace Config;

[Serializable]
public class LegacyItem : ConfigItem<LegacyItem, short>
{
	public readonly short TemplateId;

	public readonly string Name;

	public readonly short GroupId;

	public readonly bool CanManualDraw;

	public readonly sbyte Grade;

	public readonly short Weight;

	public readonly sbyte WorldCreationGroup;

	public readonly sbyte Level;

	public readonly bool IsUnique;

	public readonly bool PermanentlyUnique;

	public readonly short ExtraCost;

	public readonly short Cost;

	public readonly string Icon;

	public readonly string Desc;

	public readonly short AddFeature;

	public readonly short ModifiedProperty;

	public readonly int PropertyDelta;

	public readonly sbyte PropertyBonusType;

	public readonly NeiliProportionOfFiveElements TargetNeiliProportionOfFiveElements;

	public readonly sbyte TargetBehaviorType;

	public readonly sbyte TargetQualificationGrowthTypeLifeSkill;

	public readonly sbyte TargetQualificationGrowthTypeCombatSkill;

	public readonly int PoisonImmunityCount;

	public readonly short AddBuildingBlock;

	public readonly short AddBuildingCoreItem;

	public readonly sbyte AffectingOrganization;

	public readonly sbyte[] SupportingSectCharacterGrades;

	public readonly sbyte AffectingState;

	public readonly sbyte SpiritualDebtDelta;

	public readonly sbyte[] StateNewbornChildrenGrowingGrade;

	public LegacyItem Group
	{
		[return: MaybeNull]
		get
		{
			return Legacy.Instance.GetItemOrDefault(GroupId);
		}
	}

	public LegacyItem(short templateId, string name, short groupId, bool canManualDraw, sbyte grade, short weight, sbyte worldCreationGroup, sbyte level, bool isUnique, bool permanentlyUnique, short extraCost, short cost, string icon, string desc, short addFeature, short modifiedProperty, int propertyDelta, sbyte propertyBonusType, NeiliProportionOfFiveElements targetNeiliProportionOfFiveElements, sbyte targetBehaviorType, sbyte targetQualificationGrowthTypeLifeSkill, sbyte targetQualificationGrowthTypeCombatSkill, int poisonImmunityCount, short addBuildingBlock, short addBuildingCoreItem, sbyte affectingOrganization, sbyte[] supportingSectCharacterGrades, sbyte affectingState, sbyte spiritualDebtDelta, sbyte[] stateNewbornChildrenGrowingGrade)
	{
		TemplateId = templateId;
		Name = name;
		GroupId = groupId;
		CanManualDraw = canManualDraw;
		Grade = grade;
		Weight = weight;
		WorldCreationGroup = worldCreationGroup;
		Level = level;
		IsUnique = isUnique;
		PermanentlyUnique = permanentlyUnique;
		ExtraCost = extraCost;
		Cost = cost;
		Icon = icon;
		Desc = desc;
		AddFeature = addFeature;
		ModifiedProperty = modifiedProperty;
		PropertyDelta = propertyDelta;
		PropertyBonusType = propertyBonusType;
		TargetNeiliProportionOfFiveElements = targetNeiliProportionOfFiveElements;
		TargetBehaviorType = targetBehaviorType;
		TargetQualificationGrowthTypeLifeSkill = targetQualificationGrowthTypeLifeSkill;
		TargetQualificationGrowthTypeCombatSkill = targetQualificationGrowthTypeCombatSkill;
		PoisonImmunityCount = poisonImmunityCount;
		AddBuildingBlock = addBuildingBlock;
		AddBuildingCoreItem = addBuildingCoreItem;
		AffectingOrganization = affectingOrganization;
		SupportingSectCharacterGrades = supportingSectCharacterGrades;
		AffectingState = affectingState;
		SpiritualDebtDelta = spiritualDebtDelta;
		StateNewbornChildrenGrowingGrade = stateNewbornChildrenGrowingGrade;
	}

	public LegacyItem()
	{
		TemplateId = 0;
		Name = null;
		GroupId = 0;
		CanManualDraw = true;
		Grade = 0;
		Weight = 1;
		WorldCreationGroup = 0;
		Level = -1;
		IsUnique = false;
		PermanentlyUnique = false;
		ExtraCost = 0;
		Cost = 0;
		Icon = null;
		Desc = null;
		AddFeature = 0;
		ModifiedProperty = 0;
		PropertyDelta = 0;
		PropertyBonusType = 0;
		TargetNeiliProportionOfFiveElements = new NeiliProportionOfFiveElements(default(sbyte), default(sbyte), default(sbyte), default(sbyte), default(sbyte));
		TargetBehaviorType = 0;
		TargetQualificationGrowthTypeLifeSkill = -1;
		TargetQualificationGrowthTypeCombatSkill = -1;
		PoisonImmunityCount = 0;
		AddBuildingBlock = 0;
		AddBuildingCoreItem = 0;
		AffectingOrganization = 0;
		SupportingSectCharacterGrades = new sbyte[0];
		AffectingState = 0;
		SpiritualDebtDelta = 0;
		StateNewbornChildrenGrowingGrade = new sbyte[0];
	}

	public LegacyItem(short templateId, LegacyItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		GroupId = other.GroupId;
		CanManualDraw = other.CanManualDraw;
		Grade = other.Grade;
		Weight = other.Weight;
		WorldCreationGroup = other.WorldCreationGroup;
		Level = other.Level;
		IsUnique = other.IsUnique;
		PermanentlyUnique = other.PermanentlyUnique;
		ExtraCost = other.ExtraCost;
		Cost = other.Cost;
		Icon = other.Icon;
		Desc = other.Desc;
		AddFeature = other.AddFeature;
		ModifiedProperty = other.ModifiedProperty;
		PropertyDelta = other.PropertyDelta;
		PropertyBonusType = other.PropertyBonusType;
		TargetNeiliProportionOfFiveElements = other.TargetNeiliProportionOfFiveElements;
		TargetBehaviorType = other.TargetBehaviorType;
		TargetQualificationGrowthTypeLifeSkill = other.TargetQualificationGrowthTypeLifeSkill;
		TargetQualificationGrowthTypeCombatSkill = other.TargetQualificationGrowthTypeCombatSkill;
		PoisonImmunityCount = other.PoisonImmunityCount;
		AddBuildingBlock = other.AddBuildingBlock;
		AddBuildingCoreItem = other.AddBuildingCoreItem;
		AffectingOrganization = other.AffectingOrganization;
		SupportingSectCharacterGrades = other.SupportingSectCharacterGrades;
		AffectingState = other.AffectingState;
		SpiritualDebtDelta = other.SpiritualDebtDelta;
		StateNewbornChildrenGrowingGrade = other.StateNewbornChildrenGrowingGrade;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override LegacyItem Duplicate(int templateId)
	{
		return new LegacyItem((short)templateId, this);
	}
}
