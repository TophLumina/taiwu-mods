using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Config.Common;

namespace Config;

[Serializable]
public class SecretInformationAppliedResultItem : ConfigItem<SecretInformationAppliedResultItem, short>
{
	public readonly short TemplateId;

	public readonly short InnerResultEvent;

	public readonly string ResultEventGuid;

	public readonly string ResultEventGuidKey;

	public readonly bool EndEventAfterJump;

	public readonly bool RevealCharacters;

	public readonly string[] Texts;

	public readonly short[] SelectionIds;

	public readonly List<ShortList> SecretInformation;

	public readonly short CombatConfigId;

	public readonly bool NoGuard;

	public readonly short SpecialConditionId;

	public readonly List<ShortList> SpecialConditionResultIds;

	public readonly sbyte SelfHappinessDiff;

	public readonly sbyte OppositeHappinessDiff;

	public readonly short SelfFavorabilityDiff;

	public readonly short OppositeFavorabilityDiff;

	public readonly sbyte SelfInfectionDiff;

	public readonly sbyte OppositeInfectionDiff;

	public readonly bool IsFavorabilityCost;

	public CombatConfigItem CombatConfig
	{
		[return: MaybeNull]
		get
		{
			return Config.CombatConfig.Instance.GetItemOrDefault(CombatConfigId);
		}
	}

	public SecretInformationSpecialConditionItem SpecialCondition
	{
		[return: MaybeNull]
		get
		{
			return SecretInformationSpecialCondition.Instance.GetItemOrDefault(SpecialConditionId);
		}
	}

	public SecretInformationAppliedResultItem(short templateId, short innerResultEvent, string resultEventGuid, string resultEventGuidKey, bool endEventAfterJump, bool revealCharacters, string[] texts, short[] selectionIds, List<ShortList> secretInformation, short combatConfigId, bool noGuard, short specialConditionId, List<ShortList> specialConditionResultIds, sbyte selfHappinessDiff, sbyte oppositeHappinessDiff, short selfFavorabilityDiff, short oppositeFavorabilityDiff, sbyte selfInfectionDiff, sbyte oppositeInfectionDiff, bool isFavorabilityCost)
	{
		TemplateId = templateId;
		InnerResultEvent = innerResultEvent;
		ResultEventGuid = resultEventGuid;
		ResultEventGuidKey = resultEventGuidKey;
		EndEventAfterJump = endEventAfterJump;
		RevealCharacters = revealCharacters;
		Texts = texts;
		SelectionIds = selectionIds;
		SecretInformation = secretInformation;
		CombatConfigId = combatConfigId;
		NoGuard = noGuard;
		SpecialConditionId = specialConditionId;
		SpecialConditionResultIds = specialConditionResultIds;
		SelfHappinessDiff = selfHappinessDiff;
		OppositeHappinessDiff = oppositeHappinessDiff;
		SelfFavorabilityDiff = selfFavorabilityDiff;
		OppositeFavorabilityDiff = oppositeFavorabilityDiff;
		SelfInfectionDiff = selfInfectionDiff;
		OppositeInfectionDiff = oppositeInfectionDiff;
		IsFavorabilityCost = isFavorabilityCost;
	}

	public SecretInformationAppliedResultItem()
	{
		TemplateId = 0;
		InnerResultEvent = 0;
		ResultEventGuid = null;
		ResultEventGuidKey = null;
		EndEventAfterJump = true;
		RevealCharacters = true;
		Texts = null;
		SelectionIds = new short[0];
		SecretInformation = new List<ShortList>
		{
			new ShortList(-1)
		};
		CombatConfigId = 0;
		NoGuard = false;
		SpecialConditionId = 0;
		SpecialConditionResultIds = new List<ShortList>
		{
			new ShortList(-1)
		};
		SelfHappinessDiff = 0;
		OppositeHappinessDiff = 0;
		SelfFavorabilityDiff = 0;
		OppositeFavorabilityDiff = 0;
		SelfInfectionDiff = 0;
		OppositeInfectionDiff = 0;
		IsFavorabilityCost = false;
	}

	public SecretInformationAppliedResultItem(short templateId, SecretInformationAppliedResultItem other)
	{
		TemplateId = templateId;
		InnerResultEvent = other.InnerResultEvent;
		ResultEventGuid = other.ResultEventGuid;
		ResultEventGuidKey = other.ResultEventGuidKey;
		EndEventAfterJump = other.EndEventAfterJump;
		RevealCharacters = other.RevealCharacters;
		Texts = other.Texts;
		SelectionIds = other.SelectionIds;
		SecretInformation = other.SecretInformation;
		CombatConfigId = other.CombatConfigId;
		NoGuard = other.NoGuard;
		SpecialConditionId = other.SpecialConditionId;
		SpecialConditionResultIds = other.SpecialConditionResultIds;
		SelfHappinessDiff = other.SelfHappinessDiff;
		OppositeHappinessDiff = other.OppositeHappinessDiff;
		SelfFavorabilityDiff = other.SelfFavorabilityDiff;
		OppositeFavorabilityDiff = other.OppositeFavorabilityDiff;
		SelfInfectionDiff = other.SelfInfectionDiff;
		OppositeInfectionDiff = other.OppositeInfectionDiff;
		IsFavorabilityCost = other.IsFavorabilityCost;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override SecretInformationAppliedResultItem Duplicate(int templateId)
	{
		return new SecretInformationAppliedResultItem((short)templateId, this);
	}
}
