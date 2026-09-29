using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class SecretInformationEffectItem : ConfigItem<SecretInformationEffectItem, short>
{
	public readonly short TemplateId;

	public readonly string Name;

	public readonly int ActorIndex;

	public readonly int ReactorIndex;

	public readonly int SecactorIndex;

	public readonly int Item;

	public readonly sbyte[] ActorHappinessDiffs;

	public readonly sbyte[] ReactorHappinessDiffs;

	public readonly sbyte[] SecactorHappinessDiffs;

	public readonly List<ShortList> ActorFavorabilityDiffs;

	public readonly List<ShortList> ReactorFavorabilityDiffs;

	public readonly List<ShortList> SecactorFavorabilityDiffs;

	public readonly List<ShortList> ActorFriendFavorabilityDiffs;

	public readonly List<ShortList> ActorEnemyFavorabilityDiffs;

	public readonly List<ShortList> ReactorFriendFavorabilityDiffs;

	public readonly List<ShortList> ReactorEnemyFavorabilityDiffs;

	public readonly List<ShortList> SecactorFriendFavorabilityDiffs;

	public readonly List<ShortList> SecactorEnemyFavorabilityDiffs;

	public readonly List<ShortList> OtherFavorabilityDiffs;

	public readonly List<ShortList> SpecialConditionIndices;

	public readonly List<ShortList> SpecialConditionFavorabilities;

	public readonly List<ShortList> ActorFavorabilityDiffsWhenSpecial;

	public readonly List<ShortList> ReactorFavorabilityDiffsWhenSpecial;

	public readonly List<ShortList> SecactorFavorabilityDiffsWhenSpecial;

	public readonly List<ShortList> ActorFriendFavorabilityDiffsWhenSpecial;

	public readonly List<ShortList> ActorEnemyFavorabilityDiffsWhenSpecial;

	public readonly List<ShortList> ReactorFriendFavorabilityDiffsWhenSpecial;

	public readonly List<ShortList> ReactorEnemyFavorabilityDiffsWhenSpecial;

	public readonly List<ShortList> SecactorFriendFavorabilityDiffsWhenSpecial;

	public readonly List<ShortList> SecactorEnemyFavorabilityDiffsWhenSpecial;

	public readonly List<ShortList> OtherFavorabilityDiffsWhenSpecial;

	public readonly List<ShortList> ActorFameApplyCondition;

	public readonly List<ShortList> ActorFameApplyContent;

	public readonly List<ShortList> ReactorFameApplyCondition;

	public readonly List<ShortList> ReactorFameApplyContent;

	public readonly List<ShortList> SeactorFameApplyCondition;

	public readonly List<ShortList> SecactorFameApplyContent;

	public readonly short[] BaseSecretRate;

	public readonly short CombatType;

	public readonly short[] KillingProbOfRefuseKeepSecret;

	public readonly short[] OppositeFavorabilityDiffsWhenResult;

	public readonly int JudgementOfActor;

	public readonly int JudgementOfReactor;

	public readonly int JudgementOfSecactor;

	public readonly List<byte> StartEnemyRelationOddsToActor;

	public readonly List<byte> StartEnemyRelationOddsToReactor;

	public readonly List<byte> StartEnemyRelationOddsToSecactor;

	public readonly List<byte> StartEnemyRelationOddsToSource;

	public readonly List<ShortList> AlertnessEffectToActor;

	public readonly List<ShortList> AlertnessEffectToReactor;

	public readonly List<ShortList> AlertnessEffectToReactor2;

	public readonly List<ShortList> AlertnessEffectToSource;

	public SecretInformationEffectItem(short templateId, string name, int actorIndex, int reactorIndex, int secactorIndex, int item, sbyte[] actorHappinessDiffs, sbyte[] reactorHappinessDiffs, sbyte[] secactorHappinessDiffs, List<ShortList> actorFavorabilityDiffs, List<ShortList> reactorFavorabilityDiffs, List<ShortList> secactorFavorabilityDiffs, List<ShortList> actorFriendFavorabilityDiffs, List<ShortList> actorEnemyFavorabilityDiffs, List<ShortList> reactorFriendFavorabilityDiffs, List<ShortList> reactorEnemyFavorabilityDiffs, List<ShortList> secactorFriendFavorabilityDiffs, List<ShortList> secactorEnemyFavorabilityDiffs, List<ShortList> otherFavorabilityDiffs, List<ShortList> specialConditionIndices, List<ShortList> specialConditionFavorabilities, List<ShortList> actorFavorabilityDiffsWhenSpecial, List<ShortList> reactorFavorabilityDiffsWhenSpecial, List<ShortList> secactorFavorabilityDiffsWhenSpecial, List<ShortList> actorFriendFavorabilityDiffsWhenSpecial, List<ShortList> actorEnemyFavorabilityDiffsWhenSpecial, List<ShortList> reactorFriendFavorabilityDiffsWhenSpecial, List<ShortList> reactorEnemyFavorabilityDiffsWhenSpecial, List<ShortList> secactorFriendFavorabilityDiffsWhenSpecial, List<ShortList> secactorEnemyFavorabilityDiffsWhenSpecial, List<ShortList> otherFavorabilityDiffsWhenSpecial, List<ShortList> actorFameApplyCondition, List<ShortList> actorFameApplyContent, List<ShortList> reactorFameApplyCondition, List<ShortList> reactorFameApplyContent, List<ShortList> seactorFameApplyCondition, List<ShortList> secactorFameApplyContent, short[] baseSecretRate, short combatType, short[] killingProbOfRefuseKeepSecret, short[] oppositeFavorabilityDiffsWhenResult, int judgementOfActor, int judgementOfReactor, int judgementOfSecactor, List<byte> startEnemyRelationOddsToActor, List<byte> startEnemyRelationOddsToReactor, List<byte> startEnemyRelationOddsToSecactor, List<byte> startEnemyRelationOddsToSource, List<ShortList> alertnessEffectToActor, List<ShortList> alertnessEffectToReactor, List<ShortList> alertnessEffectToReactor2, List<ShortList> alertnessEffectToSource)
	{
		TemplateId = templateId;
		Name = name;
		ActorIndex = actorIndex;
		ReactorIndex = reactorIndex;
		SecactorIndex = secactorIndex;
		Item = item;
		ActorHappinessDiffs = actorHappinessDiffs;
		ReactorHappinessDiffs = reactorHappinessDiffs;
		SecactorHappinessDiffs = secactorHappinessDiffs;
		ActorFavorabilityDiffs = actorFavorabilityDiffs;
		ReactorFavorabilityDiffs = reactorFavorabilityDiffs;
		SecactorFavorabilityDiffs = secactorFavorabilityDiffs;
		ActorFriendFavorabilityDiffs = actorFriendFavorabilityDiffs;
		ActorEnemyFavorabilityDiffs = actorEnemyFavorabilityDiffs;
		ReactorFriendFavorabilityDiffs = reactorFriendFavorabilityDiffs;
		ReactorEnemyFavorabilityDiffs = reactorEnemyFavorabilityDiffs;
		SecactorFriendFavorabilityDiffs = secactorFriendFavorabilityDiffs;
		SecactorEnemyFavorabilityDiffs = secactorEnemyFavorabilityDiffs;
		OtherFavorabilityDiffs = otherFavorabilityDiffs;
		SpecialConditionIndices = specialConditionIndices;
		SpecialConditionFavorabilities = specialConditionFavorabilities;
		ActorFavorabilityDiffsWhenSpecial = actorFavorabilityDiffsWhenSpecial;
		ReactorFavorabilityDiffsWhenSpecial = reactorFavorabilityDiffsWhenSpecial;
		SecactorFavorabilityDiffsWhenSpecial = secactorFavorabilityDiffsWhenSpecial;
		ActorFriendFavorabilityDiffsWhenSpecial = actorFriendFavorabilityDiffsWhenSpecial;
		ActorEnemyFavorabilityDiffsWhenSpecial = actorEnemyFavorabilityDiffsWhenSpecial;
		ReactorFriendFavorabilityDiffsWhenSpecial = reactorFriendFavorabilityDiffsWhenSpecial;
		ReactorEnemyFavorabilityDiffsWhenSpecial = reactorEnemyFavorabilityDiffsWhenSpecial;
		SecactorFriendFavorabilityDiffsWhenSpecial = secactorFriendFavorabilityDiffsWhenSpecial;
		SecactorEnemyFavorabilityDiffsWhenSpecial = secactorEnemyFavorabilityDiffsWhenSpecial;
		OtherFavorabilityDiffsWhenSpecial = otherFavorabilityDiffsWhenSpecial;
		ActorFameApplyCondition = actorFameApplyCondition;
		ActorFameApplyContent = actorFameApplyContent;
		ReactorFameApplyCondition = reactorFameApplyCondition;
		ReactorFameApplyContent = reactorFameApplyContent;
		SeactorFameApplyCondition = seactorFameApplyCondition;
		SecactorFameApplyContent = secactorFameApplyContent;
		BaseSecretRate = baseSecretRate;
		CombatType = combatType;
		KillingProbOfRefuseKeepSecret = killingProbOfRefuseKeepSecret;
		OppositeFavorabilityDiffsWhenResult = oppositeFavorabilityDiffsWhenResult;
		JudgementOfActor = judgementOfActor;
		JudgementOfReactor = judgementOfReactor;
		JudgementOfSecactor = judgementOfSecactor;
		StartEnemyRelationOddsToActor = startEnemyRelationOddsToActor;
		StartEnemyRelationOddsToReactor = startEnemyRelationOddsToReactor;
		StartEnemyRelationOddsToSecactor = startEnemyRelationOddsToSecactor;
		StartEnemyRelationOddsToSource = startEnemyRelationOddsToSource;
		AlertnessEffectToActor = alertnessEffectToActor;
		AlertnessEffectToReactor = alertnessEffectToReactor;
		AlertnessEffectToReactor2 = alertnessEffectToReactor2;
		AlertnessEffectToSource = alertnessEffectToSource;
	}

	public SecretInformationEffectItem()
	{
		TemplateId = 0;
		Name = null;
		ActorIndex = -1;
		ReactorIndex = -1;
		SecactorIndex = -1;
		Item = -1;
		ActorHappinessDiffs = null;
		ReactorHappinessDiffs = null;
		SecactorHappinessDiffs = null;
		ActorFavorabilityDiffs = null;
		ReactorFavorabilityDiffs = null;
		SecactorFavorabilityDiffs = null;
		ActorFriendFavorabilityDiffs = null;
		ActorEnemyFavorabilityDiffs = null;
		ReactorFriendFavorabilityDiffs = null;
		ReactorEnemyFavorabilityDiffs = null;
		SecactorFriendFavorabilityDiffs = null;
		SecactorEnemyFavorabilityDiffs = null;
		OtherFavorabilityDiffs = null;
		SpecialConditionIndices = new List<ShortList>
		{
			new ShortList()
		};
		SpecialConditionFavorabilities = new List<ShortList>
		{
			new ShortList(-1)
		};
		ActorFavorabilityDiffsWhenSpecial = null;
		ReactorFavorabilityDiffsWhenSpecial = null;
		SecactorFavorabilityDiffsWhenSpecial = null;
		ActorFriendFavorabilityDiffsWhenSpecial = null;
		ActorEnemyFavorabilityDiffsWhenSpecial = null;
		ReactorFriendFavorabilityDiffsWhenSpecial = null;
		ReactorEnemyFavorabilityDiffsWhenSpecial = null;
		SecactorFriendFavorabilityDiffsWhenSpecial = null;
		SecactorEnemyFavorabilityDiffsWhenSpecial = null;
		OtherFavorabilityDiffsWhenSpecial = null;
		ActorFameApplyCondition = new List<ShortList>
		{
			new ShortList(-1)
		};
		ActorFameApplyContent = new List<ShortList>
		{
			new ShortList(-1)
		};
		ReactorFameApplyCondition = new List<ShortList>
		{
			new ShortList(-1)
		};
		ReactorFameApplyContent = new List<ShortList>
		{
			new ShortList(-1)
		};
		SeactorFameApplyCondition = new List<ShortList>
		{
			new ShortList(-1)
		};
		SecactorFameApplyContent = new List<ShortList>
		{
			new ShortList(-1)
		};
		BaseSecretRate = new short[5];
		CombatType = 0;
		KillingProbOfRefuseKeepSecret = new short[5];
		OppositeFavorabilityDiffsWhenResult = new short[5];
		JudgementOfActor = 999;
		JudgementOfReactor = 999;
		JudgementOfSecactor = 999;
		StartEnemyRelationOddsToActor = new List<byte> { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
		StartEnemyRelationOddsToReactor = new List<byte> { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
		StartEnemyRelationOddsToSecactor = new List<byte> { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
		StartEnemyRelationOddsToSource = new List<byte> { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
		AlertnessEffectToActor = new List<ShortList>
		{
			new ShortList(default(short), default(short), default(short), default(short), default(short)),
			new ShortList(default(short), default(short), default(short), default(short), default(short)),
			new ShortList(default(short), default(short), default(short), default(short), default(short)),
			new ShortList(default(short), default(short), default(short), default(short), default(short)),
			new ShortList(default(short), default(short), default(short), default(short), default(short)),
			new ShortList(default(short), default(short), default(short), default(short), default(short)),
			new ShortList(default(short), default(short), default(short), default(short), default(short)),
			new ShortList(default(short), default(short), default(short), default(short), default(short)),
			new ShortList(default(short), default(short), default(short), default(short), default(short))
		};
		AlertnessEffectToReactor = new List<ShortList>
		{
			new ShortList(default(short), default(short), default(short), default(short), default(short)),
			new ShortList(default(short), default(short), default(short), default(short), default(short)),
			new ShortList(default(short), default(short), default(short), default(short), default(short)),
			new ShortList(default(short), default(short), default(short), default(short), default(short)),
			new ShortList(default(short), default(short), default(short), default(short), default(short)),
			new ShortList(default(short), default(short), default(short), default(short), default(short)),
			new ShortList(default(short), default(short), default(short), default(short), default(short)),
			new ShortList(default(short), default(short), default(short), default(short), default(short)),
			new ShortList(default(short), default(short), default(short), default(short), default(short))
		};
		AlertnessEffectToReactor2 = new List<ShortList>
		{
			new ShortList(default(short), default(short), default(short), default(short), default(short)),
			new ShortList(default(short), default(short), default(short), default(short), default(short)),
			new ShortList(default(short), default(short), default(short), default(short), default(short)),
			new ShortList(default(short), default(short), default(short), default(short), default(short)),
			new ShortList(default(short), default(short), default(short), default(short), default(short)),
			new ShortList(default(short), default(short), default(short), default(short), default(short)),
			new ShortList(default(short), default(short), default(short), default(short), default(short)),
			new ShortList(default(short), default(short), default(short), default(short), default(short)),
			new ShortList(default(short), default(short), default(short), default(short), default(short))
		};
		AlertnessEffectToSource = new List<ShortList>
		{
			new ShortList(default(short), default(short), default(short), default(short), default(short)),
			new ShortList(default(short), default(short), default(short), default(short), default(short)),
			new ShortList(default(short), default(short), default(short), default(short), default(short)),
			new ShortList(default(short), default(short), default(short), default(short), default(short)),
			new ShortList(default(short), default(short), default(short), default(short), default(short)),
			new ShortList(default(short), default(short), default(short), default(short), default(short)),
			new ShortList(default(short), default(short), default(short), default(short), default(short)),
			new ShortList(default(short), default(short), default(short), default(short), default(short)),
			new ShortList(default(short), default(short), default(short), default(short), default(short))
		};
	}

	public SecretInformationEffectItem(short templateId, SecretInformationEffectItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		ActorIndex = other.ActorIndex;
		ReactorIndex = other.ReactorIndex;
		SecactorIndex = other.SecactorIndex;
		Item = other.Item;
		ActorHappinessDiffs = other.ActorHappinessDiffs;
		ReactorHappinessDiffs = other.ReactorHappinessDiffs;
		SecactorHappinessDiffs = other.SecactorHappinessDiffs;
		ActorFavorabilityDiffs = other.ActorFavorabilityDiffs;
		ReactorFavorabilityDiffs = other.ReactorFavorabilityDiffs;
		SecactorFavorabilityDiffs = other.SecactorFavorabilityDiffs;
		ActorFriendFavorabilityDiffs = other.ActorFriendFavorabilityDiffs;
		ActorEnemyFavorabilityDiffs = other.ActorEnemyFavorabilityDiffs;
		ReactorFriendFavorabilityDiffs = other.ReactorFriendFavorabilityDiffs;
		ReactorEnemyFavorabilityDiffs = other.ReactorEnemyFavorabilityDiffs;
		SecactorFriendFavorabilityDiffs = other.SecactorFriendFavorabilityDiffs;
		SecactorEnemyFavorabilityDiffs = other.SecactorEnemyFavorabilityDiffs;
		OtherFavorabilityDiffs = other.OtherFavorabilityDiffs;
		SpecialConditionIndices = other.SpecialConditionIndices;
		SpecialConditionFavorabilities = other.SpecialConditionFavorabilities;
		ActorFavorabilityDiffsWhenSpecial = other.ActorFavorabilityDiffsWhenSpecial;
		ReactorFavorabilityDiffsWhenSpecial = other.ReactorFavorabilityDiffsWhenSpecial;
		SecactorFavorabilityDiffsWhenSpecial = other.SecactorFavorabilityDiffsWhenSpecial;
		ActorFriendFavorabilityDiffsWhenSpecial = other.ActorFriendFavorabilityDiffsWhenSpecial;
		ActorEnemyFavorabilityDiffsWhenSpecial = other.ActorEnemyFavorabilityDiffsWhenSpecial;
		ReactorFriendFavorabilityDiffsWhenSpecial = other.ReactorFriendFavorabilityDiffsWhenSpecial;
		ReactorEnemyFavorabilityDiffsWhenSpecial = other.ReactorEnemyFavorabilityDiffsWhenSpecial;
		SecactorFriendFavorabilityDiffsWhenSpecial = other.SecactorFriendFavorabilityDiffsWhenSpecial;
		SecactorEnemyFavorabilityDiffsWhenSpecial = other.SecactorEnemyFavorabilityDiffsWhenSpecial;
		OtherFavorabilityDiffsWhenSpecial = other.OtherFavorabilityDiffsWhenSpecial;
		ActorFameApplyCondition = other.ActorFameApplyCondition;
		ActorFameApplyContent = other.ActorFameApplyContent;
		ReactorFameApplyCondition = other.ReactorFameApplyCondition;
		ReactorFameApplyContent = other.ReactorFameApplyContent;
		SeactorFameApplyCondition = other.SeactorFameApplyCondition;
		SecactorFameApplyContent = other.SecactorFameApplyContent;
		BaseSecretRate = other.BaseSecretRate;
		CombatType = other.CombatType;
		KillingProbOfRefuseKeepSecret = other.KillingProbOfRefuseKeepSecret;
		OppositeFavorabilityDiffsWhenResult = other.OppositeFavorabilityDiffsWhenResult;
		JudgementOfActor = other.JudgementOfActor;
		JudgementOfReactor = other.JudgementOfReactor;
		JudgementOfSecactor = other.JudgementOfSecactor;
		StartEnemyRelationOddsToActor = other.StartEnemyRelationOddsToActor;
		StartEnemyRelationOddsToReactor = other.StartEnemyRelationOddsToReactor;
		StartEnemyRelationOddsToSecactor = other.StartEnemyRelationOddsToSecactor;
		StartEnemyRelationOddsToSource = other.StartEnemyRelationOddsToSource;
		AlertnessEffectToActor = other.AlertnessEffectToActor;
		AlertnessEffectToReactor = other.AlertnessEffectToReactor;
		AlertnessEffectToReactor2 = other.AlertnessEffectToReactor2;
		AlertnessEffectToSource = other.AlertnessEffectToSource;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override SecretInformationEffectItem Duplicate(int templateId)
	{
		return new SecretInformationEffectItem((short)templateId, this);
	}
}
