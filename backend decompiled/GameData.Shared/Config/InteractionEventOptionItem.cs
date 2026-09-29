using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Config.Common;
using GameData.Domains.Character;

namespace Config;

[Serializable]
public class InteractionEventOptionItem : ConfigItem<InteractionEventOptionItem, short>
{
	public readonly short TemplateId;

	public readonly string OptionGuid;

	public readonly short MutexGroupId;

	public readonly EInteractionEventOptionInteractionType InteractionType;

	public readonly string Name;

	public readonly EInteractionEventOptionTaiwuGroupStatus TaiwuGroupStatus;

	public readonly bool OncePerMonth;

	public readonly sbyte[] MinFavorType;

	public readonly sbyte[] MaxFavorType;

	public readonly List<sbyte> BehaviorType;

	public readonly List<sbyte> TaiwuBehaviorType;

	public readonly int ProfessionSkill;

	public readonly int ActionPointCost;

	public readonly int SpiritualDebtCost;

	public readonly int ExpCost;

	public readonly ResourceInts ResourceCost;

	public readonly MainAttributes MainAttributeCost;

	public readonly short AfterMainStoryLineProgress;

	public readonly short BeforeMainStoryLineProgress;

	public readonly List<short> DuringTask;

	public readonly List<short> OrganizationIdentity;

	public readonly EInteractionEventOptionCompareConsummate CompareConsummate;

	public readonly List<short> Organization;

	public readonly List<short> NonOrganization;

	public readonly bool AbleAffectionate;

	public readonly bool AbleNormalMarried;

	public readonly bool AbleMonkMarried;

	public readonly short InteractionFeature;

	public readonly short InteractionItem;

	public readonly bool AbleChicken;

	public readonly EInteractionEventOptionAbleXiangshu AbleXiangshu;

	public readonly EInteractionEventOptionIdentityAbility IdentityAbility;

	public readonly bool TaiwuSecretInformation;

	public readonly short TaiwuItem;

	public readonly EInteractionEventOptionOrganizationSupport OrganizationSupport;

	public readonly short RelationNumber;

	public readonly bool TeammateNumber;

	public readonly sbyte TaiwuGender;

	public readonly sbyte InteractionGender;

	public readonly sbyte InteractionMinAge;

	public readonly sbyte InteractionMaxAge;

	public readonly sbyte TaiwuMinAge;

	public readonly sbyte TaiwuMaxAge;

	public readonly bool OneAdult;

	public readonly short AbleQi;

	public readonly short ExistentRelation;

	public readonly List<short> NonexistentRelation;

	public readonly List<short> TaiwuNonexistentRelation;

	public readonly List<short> InteractionNonexistentRelation;

	public readonly bool AbleOnOrganizationBlock;

	public readonly bool AbleZhujian;

	public readonly bool AbleJoinSect;

	public readonly bool AbleReturnInfant;

	public readonly List<string> MapBlockCharCustomButtonEventPath;

	public readonly List<string> MapBlockCharCustomButtonEventOptionPath;

	public InteractionEventOptionItem MutexGroup
	{
		[return: MaybeNull]
		get
		{
			return InteractionEventOption.Instance.GetItemOrDefault(MutexGroupId);
		}
	}

	public InteractionEventOptionItem(short templateId, string optionGuid, short mutexGroupId, EInteractionEventOptionInteractionType interactionType, string name, EInteractionEventOptionTaiwuGroupStatus taiwuGroupStatus, bool oncePerMonth, sbyte[] minFavorType, sbyte[] maxFavorType, List<sbyte> behaviorType, List<sbyte> taiwuBehaviorType, int professionSkill, int actionPointCost, int spiritualDebtCost, int expCost, ResourceInts resourceCost, MainAttributes mainAttributeCost, short afterMainStoryLineProgress, short beforeMainStoryLineProgress, List<short> duringTask, List<short> organizationIdentity, EInteractionEventOptionCompareConsummate compareConsummate, List<short> organization, List<short> nonOrganization, bool ableAffectionate, bool ableNormalMarried, bool ableMonkMarried, short interactionFeature, short interactionItem, bool ableChicken, EInteractionEventOptionAbleXiangshu ableXiangshu, EInteractionEventOptionIdentityAbility identityAbility, bool taiwuSecretInformation, short taiwuItem, EInteractionEventOptionOrganizationSupport organizationSupport, short relationNumber, bool teammateNumber, sbyte taiwuGender, sbyte interactionGender, sbyte interactionMinAge, sbyte interactionMaxAge, sbyte taiwuMinAge, sbyte taiwuMaxAge, bool oneAdult, short ableQi, short existentRelation, List<short> nonexistentRelation, List<short> taiwuNonexistentRelation, List<short> interactionNonexistentRelation, bool ableOnOrganizationBlock, bool ableZhujian, bool ableJoinSect, bool ableReturnInfant, List<string> mapBlockCharCustomButtonEventPath, List<string> mapBlockCharCustomButtonEventOptionPath)
	{
		TemplateId = templateId;
		OptionGuid = optionGuid;
		MutexGroupId = mutexGroupId;
		InteractionType = interactionType;
		Name = name;
		TaiwuGroupStatus = taiwuGroupStatus;
		OncePerMonth = oncePerMonth;
		MinFavorType = minFavorType;
		MaxFavorType = maxFavorType;
		BehaviorType = behaviorType;
		TaiwuBehaviorType = taiwuBehaviorType;
		ProfessionSkill = professionSkill;
		ActionPointCost = actionPointCost;
		SpiritualDebtCost = spiritualDebtCost;
		ExpCost = expCost;
		ResourceCost = resourceCost;
		MainAttributeCost = mainAttributeCost;
		AfterMainStoryLineProgress = afterMainStoryLineProgress;
		BeforeMainStoryLineProgress = beforeMainStoryLineProgress;
		DuringTask = duringTask;
		OrganizationIdentity = organizationIdentity;
		CompareConsummate = compareConsummate;
		Organization = organization;
		NonOrganization = nonOrganization;
		AbleAffectionate = ableAffectionate;
		AbleNormalMarried = ableNormalMarried;
		AbleMonkMarried = ableMonkMarried;
		InteractionFeature = interactionFeature;
		InteractionItem = interactionItem;
		AbleChicken = ableChicken;
		AbleXiangshu = ableXiangshu;
		IdentityAbility = identityAbility;
		TaiwuSecretInformation = taiwuSecretInformation;
		TaiwuItem = taiwuItem;
		OrganizationSupport = organizationSupport;
		RelationNumber = relationNumber;
		TeammateNumber = teammateNumber;
		TaiwuGender = taiwuGender;
		InteractionGender = interactionGender;
		InteractionMinAge = interactionMinAge;
		InteractionMaxAge = interactionMaxAge;
		TaiwuMinAge = taiwuMinAge;
		TaiwuMaxAge = taiwuMaxAge;
		OneAdult = oneAdult;
		AbleQi = ableQi;
		ExistentRelation = existentRelation;
		NonexistentRelation = nonexistentRelation;
		TaiwuNonexistentRelation = taiwuNonexistentRelation;
		InteractionNonexistentRelation = interactionNonexistentRelation;
		AbleOnOrganizationBlock = ableOnOrganizationBlock;
		AbleZhujian = ableZhujian;
		AbleJoinSect = ableJoinSect;
		AbleReturnInfant = ableReturnInfant;
		MapBlockCharCustomButtonEventPath = mapBlockCharCustomButtonEventPath;
		MapBlockCharCustomButtonEventOptionPath = mapBlockCharCustomButtonEventOptionPath;
	}

	public InteractionEventOptionItem()
	{
		TemplateId = 0;
		OptionGuid = null;
		MutexGroupId = 0;
		InteractionType = EInteractionEventOptionInteractionType.Invalid;
		Name = null;
		TaiwuGroupStatus = EInteractionEventOptionTaiwuGroupStatus.Invalid;
		OncePerMonth = false;
		MinFavorType = new sbyte[5] { -6, -6, -6, -6, -6 };
		MaxFavorType = new sbyte[5] { 6, 6, 6, 6, 6 };
		BehaviorType = null;
		TaiwuBehaviorType = null;
		ProfessionSkill = 0;
		ActionPointCost = 0;
		SpiritualDebtCost = 0;
		ExpCost = 0;
		ResourceCost = new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int));
		MainAttributeCost = new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short));
		AfterMainStoryLineProgress = 0;
		BeforeMainStoryLineProgress = 0;
		DuringTask = null;
		OrganizationIdentity = null;
		CompareConsummate = EInteractionEventOptionCompareConsummate.Invalid;
		Organization = null;
		NonOrganization = null;
		AbleAffectionate = false;
		AbleNormalMarried = false;
		AbleMonkMarried = false;
		InteractionFeature = 0;
		InteractionItem = 0;
		AbleChicken = false;
		AbleXiangshu = EInteractionEventOptionAbleXiangshu.Invalid;
		IdentityAbility = EInteractionEventOptionIdentityAbility.Invalid;
		TaiwuSecretInformation = false;
		TaiwuItem = 0;
		OrganizationSupport = EInteractionEventOptionOrganizationSupport.Invalid;
		RelationNumber = 0;
		TeammateNumber = false;
		TaiwuGender = -1;
		InteractionGender = -1;
		InteractionMinAge = -1;
		InteractionMaxAge = -1;
		TaiwuMinAge = -1;
		TaiwuMaxAge = -1;
		OneAdult = false;
		AbleQi = -1;
		ExistentRelation = 0;
		NonexistentRelation = new List<short>();
		TaiwuNonexistentRelation = new List<short>();
		InteractionNonexistentRelation = new List<short>();
		AbleOnOrganizationBlock = false;
		AbleZhujian = false;
		AbleJoinSect = false;
		AbleReturnInfant = false;
		MapBlockCharCustomButtonEventPath = new List<string> { "" };
		MapBlockCharCustomButtonEventOptionPath = new List<string> { "" };
	}

	public InteractionEventOptionItem(short templateId, InteractionEventOptionItem other)
	{
		TemplateId = templateId;
		OptionGuid = other.OptionGuid;
		MutexGroupId = other.MutexGroupId;
		InteractionType = other.InteractionType;
		Name = other.Name;
		TaiwuGroupStatus = other.TaiwuGroupStatus;
		OncePerMonth = other.OncePerMonth;
		MinFavorType = other.MinFavorType;
		MaxFavorType = other.MaxFavorType;
		BehaviorType = other.BehaviorType;
		TaiwuBehaviorType = other.TaiwuBehaviorType;
		ProfessionSkill = other.ProfessionSkill;
		ActionPointCost = other.ActionPointCost;
		SpiritualDebtCost = other.SpiritualDebtCost;
		ExpCost = other.ExpCost;
		ResourceCost = other.ResourceCost;
		MainAttributeCost = other.MainAttributeCost;
		AfterMainStoryLineProgress = other.AfterMainStoryLineProgress;
		BeforeMainStoryLineProgress = other.BeforeMainStoryLineProgress;
		DuringTask = other.DuringTask;
		OrganizationIdentity = other.OrganizationIdentity;
		CompareConsummate = other.CompareConsummate;
		Organization = other.Organization;
		NonOrganization = other.NonOrganization;
		AbleAffectionate = other.AbleAffectionate;
		AbleNormalMarried = other.AbleNormalMarried;
		AbleMonkMarried = other.AbleMonkMarried;
		InteractionFeature = other.InteractionFeature;
		InteractionItem = other.InteractionItem;
		AbleChicken = other.AbleChicken;
		AbleXiangshu = other.AbleXiangshu;
		IdentityAbility = other.IdentityAbility;
		TaiwuSecretInformation = other.TaiwuSecretInformation;
		TaiwuItem = other.TaiwuItem;
		OrganizationSupport = other.OrganizationSupport;
		RelationNumber = other.RelationNumber;
		TeammateNumber = other.TeammateNumber;
		TaiwuGender = other.TaiwuGender;
		InteractionGender = other.InteractionGender;
		InteractionMinAge = other.InteractionMinAge;
		InteractionMaxAge = other.InteractionMaxAge;
		TaiwuMinAge = other.TaiwuMinAge;
		TaiwuMaxAge = other.TaiwuMaxAge;
		OneAdult = other.OneAdult;
		AbleQi = other.AbleQi;
		ExistentRelation = other.ExistentRelation;
		NonexistentRelation = other.NonexistentRelation;
		TaiwuNonexistentRelation = other.TaiwuNonexistentRelation;
		InteractionNonexistentRelation = other.InteractionNonexistentRelation;
		AbleOnOrganizationBlock = other.AbleOnOrganizationBlock;
		AbleZhujian = other.AbleZhujian;
		AbleJoinSect = other.AbleJoinSect;
		AbleReturnInfant = other.AbleReturnInfant;
		MapBlockCharCustomButtonEventPath = other.MapBlockCharCustomButtonEventPath;
		MapBlockCharCustomButtonEventOptionPath = other.MapBlockCharCustomButtonEventOptionPath;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override InteractionEventOptionItem Duplicate(int templateId)
	{
		return new InteractionEventOptionItem((short)templateId, this);
	}
}
