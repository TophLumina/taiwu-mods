using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Config.Common;
using Config.ConfigCells.Character;
using GameData.Domains.Character;
using GameData.Utilities;

namespace Config;

[Serializable]
public class OrganizationMemberItem : ConfigItem<OrganizationMemberItem, short>
{
	public readonly short TemplateId;

	public readonly string GradeName;

	public readonly sbyte Organization;

	public readonly sbyte Grade;

	public readonly sbyte[] PotentialSuccessorGrades;

	public readonly sbyte Amount;

	public readonly sbyte UpAmount;

	public readonly sbyte DownAmount;

	public readonly bool RestrictPrincipalAmount;

	public readonly sbyte Gender;

	public readonly short SurnameId;

	public readonly sbyte UpgradeLevel;

	public readonly sbyte DeputySpouseDowngrade;

	public readonly sbyte[] ChildGrade;

	public readonly sbyte BrotherGrade;

	public readonly sbyte TeacherGrade;

	public readonly sbyte RejoinGrade;

	public readonly sbyte ProbOfBecomingMonk;

	public readonly byte MonkType;

	public readonly string[] MonasticTitleSuffixes;

	public readonly short Neili;

	public readonly sbyte ConsummateLevel;

	public readonly short ExpPerMonth;

	public readonly int ContributionPerMonth;

	public readonly sbyte ApprenticeProbAdjust;

	public readonly List<short> FavoriteClothingIds;

	public readonly List<short> HatedClothingIds;

	public readonly string[] SpouseAnonymousTitles;

	public readonly bool CanStroll;

	public readonly short MinionGroupId;

	public readonly short[] InitialAges;

	public readonly PresetEquipmentItemWithProb[] Equipment;

	public readonly PresetEquipmentItem Clothing;

	public readonly List<PresetInventoryItem> Inventory;

	public readonly List<PresetOrgMemberCombatSkill> CombatSkills;

	public readonly sbyte[] ExtraCombatSkillGrids;

	public readonly short[] ResourcesAdjust;

	public readonly int ResourceSatisfyingThreshold;

	public readonly int ItemSatisfyingThreshold;

	public readonly int ResourceIncomeRatio;

	public readonly int PurchaseItemDiscount;

	public readonly int ExpectedWagerValue;

	public readonly short[] LifeSkillsAdjust;

	public readonly sbyte LifeSkillGradeLimit;

	public readonly short[] CombatSkillsAdjust;

	public readonly short[] MainAttributesAdjust;

	public readonly List<sbyte> IdentityInteractConfig;

	public readonly short IdentityActiveAge;

	public readonly ResourceInts DropResources;

	public readonly IntPair[] PreferProfessions;

	public readonly sbyte[] CraftTypes;

	public MinionGroupItem MinionGroup
	{
		[return: MaybeNull]
		get
		{
			return Config.MinionGroup.Instance.GetItemOrDefault(MinionGroupId);
		}
	}

	public OrganizationMemberItem(short templateId, string gradeName, sbyte organization, sbyte grade, sbyte[] potentialSuccessorGrades, sbyte amount, sbyte upAmount, sbyte downAmount, bool restrictPrincipalAmount, sbyte gender, short surnameId, sbyte upgradeLevel, sbyte deputySpouseDowngrade, sbyte[] childGrade, sbyte brotherGrade, sbyte teacherGrade, sbyte rejoinGrade, sbyte probOfBecomingMonk, byte monkType, string[] monasticTitleSuffixes, short neili, sbyte consummateLevel, short expPerMonth, int contributionPerMonth, sbyte apprenticeProbAdjust, List<short> favoriteClothingIds, List<short> hatedClothingIds, string[] spouseAnonymousTitles, bool canStroll, short minionGroupId, short[] initialAges, PresetEquipmentItemWithProb[] equipment, PresetEquipmentItem clothing, List<PresetInventoryItem> inventory, List<PresetOrgMemberCombatSkill> combatSkills, sbyte[] extraCombatSkillGrids, short[] resourcesAdjust, int resourceSatisfyingThreshold, int itemSatisfyingThreshold, int resourceIncomeRatio, int purchaseItemDiscount, int expectedWagerValue, short[] lifeSkillsAdjust, sbyte lifeSkillGradeLimit, short[] combatSkillsAdjust, short[] mainAttributesAdjust, List<sbyte> identityInteractConfig, short identityActiveAge, ResourceInts dropResources, IntPair[] preferProfessions, sbyte[] craftTypes)
	{
		TemplateId = templateId;
		GradeName = gradeName;
		Organization = organization;
		Grade = grade;
		PotentialSuccessorGrades = potentialSuccessorGrades;
		Amount = amount;
		UpAmount = upAmount;
		DownAmount = downAmount;
		RestrictPrincipalAmount = restrictPrincipalAmount;
		Gender = gender;
		SurnameId = surnameId;
		UpgradeLevel = upgradeLevel;
		DeputySpouseDowngrade = deputySpouseDowngrade;
		ChildGrade = childGrade;
		BrotherGrade = brotherGrade;
		TeacherGrade = teacherGrade;
		RejoinGrade = rejoinGrade;
		ProbOfBecomingMonk = probOfBecomingMonk;
		MonkType = monkType;
		MonasticTitleSuffixes = monasticTitleSuffixes;
		Neili = neili;
		ConsummateLevel = consummateLevel;
		ExpPerMonth = expPerMonth;
		ContributionPerMonth = contributionPerMonth;
		ApprenticeProbAdjust = apprenticeProbAdjust;
		FavoriteClothingIds = favoriteClothingIds;
		HatedClothingIds = hatedClothingIds;
		SpouseAnonymousTitles = spouseAnonymousTitles;
		CanStroll = canStroll;
		MinionGroupId = minionGroupId;
		InitialAges = initialAges;
		Equipment = equipment;
		Clothing = clothing;
		Inventory = inventory;
		CombatSkills = combatSkills;
		ExtraCombatSkillGrids = extraCombatSkillGrids;
		ResourcesAdjust = resourcesAdjust;
		ResourceSatisfyingThreshold = resourceSatisfyingThreshold;
		ItemSatisfyingThreshold = itemSatisfyingThreshold;
		ResourceIncomeRatio = resourceIncomeRatio;
		PurchaseItemDiscount = purchaseItemDiscount;
		ExpectedWagerValue = expectedWagerValue;
		LifeSkillsAdjust = lifeSkillsAdjust;
		LifeSkillGradeLimit = lifeSkillGradeLimit;
		CombatSkillsAdjust = combatSkillsAdjust;
		MainAttributesAdjust = mainAttributesAdjust;
		IdentityInteractConfig = identityInteractConfig;
		IdentityActiveAge = identityActiveAge;
		DropResources = dropResources;
		PreferProfessions = preferProfessions;
		CraftTypes = craftTypes;
	}

	public OrganizationMemberItem()
	{
		TemplateId = 0;
		GradeName = null;
		Organization = 0;
		Grade = 0;
		PotentialSuccessorGrades = new sbyte[0];
		Amount = 0;
		UpAmount = 0;
		DownAmount = 0;
		RestrictPrincipalAmount = false;
		Gender = -1;
		SurnameId = -1;
		UpgradeLevel = 0;
		DeputySpouseDowngrade = -1;
		ChildGrade = new sbyte[0];
		BrotherGrade = -1;
		TeacherGrade = -1;
		RejoinGrade = -1;
		ProbOfBecomingMonk = 0;
		MonkType = 0;
		MonasticTitleSuffixes = new string[2]
		{
			string.Empty,
			string.Empty
		};
		Neili = 0;
		ConsummateLevel = 0;
		ExpPerMonth = 0;
		ContributionPerMonth = 0;
		ApprenticeProbAdjust = 0;
		FavoriteClothingIds = new List<short>();
		HatedClothingIds = new List<short>();
		SpouseAnonymousTitles = new string[2]
		{
			string.Empty,
			string.Empty
		};
		CanStroll = false;
		MinionGroupId = 0;
		InitialAges = new short[4] { -1, -1, -1, -1 };
		Equipment = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		Clothing = new PresetEquipmentItem("Clothing", -1);
		Inventory = new List<PresetInventoryItem>();
		CombatSkills = new List<PresetOrgMemberCombatSkill>();
		ExtraCombatSkillGrids = new sbyte[5];
		ResourcesAdjust = null;
		ResourceSatisfyingThreshold = 0;
		ItemSatisfyingThreshold = 0;
		ResourceIncomeRatio = 0;
		PurchaseItemDiscount = 100;
		ExpectedWagerValue = 0;
		LifeSkillsAdjust = null;
		LifeSkillGradeLimit = 0;
		CombatSkillsAdjust = null;
		MainAttributesAdjust = null;
		IdentityInteractConfig = new List<sbyte>();
		IdentityActiveAge = 3;
		DropResources = new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int));
		PreferProfessions = new IntPair[0];
		CraftTypes = null;
	}

	public OrganizationMemberItem(short templateId, OrganizationMemberItem other)
	{
		TemplateId = templateId;
		GradeName = other.GradeName;
		Organization = other.Organization;
		Grade = other.Grade;
		PotentialSuccessorGrades = other.PotentialSuccessorGrades;
		Amount = other.Amount;
		UpAmount = other.UpAmount;
		DownAmount = other.DownAmount;
		RestrictPrincipalAmount = other.RestrictPrincipalAmount;
		Gender = other.Gender;
		SurnameId = other.SurnameId;
		UpgradeLevel = other.UpgradeLevel;
		DeputySpouseDowngrade = other.DeputySpouseDowngrade;
		ChildGrade = other.ChildGrade;
		BrotherGrade = other.BrotherGrade;
		TeacherGrade = other.TeacherGrade;
		RejoinGrade = other.RejoinGrade;
		ProbOfBecomingMonk = other.ProbOfBecomingMonk;
		MonkType = other.MonkType;
		MonasticTitleSuffixes = other.MonasticTitleSuffixes;
		Neili = other.Neili;
		ConsummateLevel = other.ConsummateLevel;
		ExpPerMonth = other.ExpPerMonth;
		ContributionPerMonth = other.ContributionPerMonth;
		ApprenticeProbAdjust = other.ApprenticeProbAdjust;
		FavoriteClothingIds = other.FavoriteClothingIds;
		HatedClothingIds = other.HatedClothingIds;
		SpouseAnonymousTitles = other.SpouseAnonymousTitles;
		CanStroll = other.CanStroll;
		MinionGroupId = other.MinionGroupId;
		InitialAges = other.InitialAges;
		Equipment = other.Equipment;
		Clothing = other.Clothing;
		Inventory = other.Inventory;
		CombatSkills = other.CombatSkills;
		ExtraCombatSkillGrids = other.ExtraCombatSkillGrids;
		ResourcesAdjust = other.ResourcesAdjust;
		ResourceSatisfyingThreshold = other.ResourceSatisfyingThreshold;
		ItemSatisfyingThreshold = other.ItemSatisfyingThreshold;
		ResourceIncomeRatio = other.ResourceIncomeRatio;
		PurchaseItemDiscount = other.PurchaseItemDiscount;
		ExpectedWagerValue = other.ExpectedWagerValue;
		LifeSkillsAdjust = other.LifeSkillsAdjust;
		LifeSkillGradeLimit = other.LifeSkillGradeLimit;
		CombatSkillsAdjust = other.CombatSkillsAdjust;
		MainAttributesAdjust = other.MainAttributesAdjust;
		IdentityInteractConfig = other.IdentityInteractConfig;
		IdentityActiveAge = other.IdentityActiveAge;
		DropResources = other.DropResources;
		PreferProfessions = other.PreferProfessions;
		CraftTypes = other.CraftTypes;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override OrganizationMemberItem Duplicate(int templateId)
	{
		return new OrganizationMemberItem((short)templateId, this);
	}
}
