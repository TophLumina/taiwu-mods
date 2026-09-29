using System;
using System.Diagnostics.CodeAnalysis;
using Config.Common;

namespace Config;

[Serializable]
public class SecretInformationItem : ConfigItem<SecretInformationItem, short>
{
	public readonly short TemplateId;

	public readonly string Name;

	public readonly string Desc;

	public readonly sbyte[] Parameters;

	public readonly sbyte NotDisplayedParm;

	public readonly string[] ParametersUiName;

	public readonly sbyte[] BlockSizeArgs;

	public readonly byte InvolvedCharacterCount;

	public readonly byte InvolvedItemCount;

	public readonly byte InvolvedCombatSkillCount;

	public readonly byte InvolvedLifeSkillCount;

	public readonly byte InvolvedLocationCount;

	public readonly byte InvolvedResourceTypeCount;

	public readonly byte InvolvedIntegerDataCount;

	public readonly bool AutoBroadCast;

	public readonly short CostAuthority;

	public readonly sbyte DiffusionRange;

	public readonly byte DiffusionSpeed;

	public readonly sbyte FameThreshold;

	public readonly byte MaxPersonAmount;

	public readonly short Duration;

	public readonly ESecretInformationInitialTarget InitialTarget;

	public readonly int[] InitialTargetParameterIndices;

	public readonly int[] RelationshipSnapshotParameterIndices;

	public readonly int[] ExtraSnapshotParameterIndices;

	public readonly bool IsGeneralRelationCharactersNeedSnapshot;

	public readonly bool IsRelationCharactersAliveStateNeedSnapshot;

	public readonly ESecretInformationValueType ValueType;

	public readonly short DisseminationId;

	public readonly short ReceptionId;

	public readonly short DefaultEffectId;

	public readonly short StructGroupId;

	public readonly short SectPunishRuleId;

	public readonly short SortValue;

	public readonly short DiscoveryRate;

	public readonly short DiscoveryRateTaiwu;

	public readonly short DiscoveryRateFactorA;

	public readonly short DiscoveryRateFactorB;

	public readonly short DiscoveryRateFactorC;

	public readonly string BroadcastDesc;

	public readonly bool AutoDissemination;

	public readonly short GeneralFilterType;

	public readonly short DetailedFilterType;

	public SecretInformationDisseminationItem Dissemination
	{
		[return: MaybeNull]
		get
		{
			return SecretInformationDissemination.Instance.GetItemOrDefault(DisseminationId);
		}
	}

	public SecretInformationReceptionItem Reception
	{
		[return: MaybeNull]
		get
		{
			return SecretInformationReception.Instance.GetItemOrDefault(ReceptionId);
		}
	}

	public SecretInformationEffectItem DefaultEffect
	{
		[return: MaybeNull]
		get
		{
			return SecretInformationEffect.Instance.GetItemOrDefault(DefaultEffectId);
		}
	}

	public SecretInformationAppliedStructItem StructGroup
	{
		[return: MaybeNull]
		get
		{
			return SecretInformationAppliedStruct.Instance.GetItemOrDefault(StructGroupId);
		}
	}

	public SecretInformationSectPunishItem SectPunishRule
	{
		[return: MaybeNull]
		get
		{
			return SecretInformationSectPunish.Instance.GetItemOrDefault(SectPunishRuleId);
		}
	}

	public SecretInformationItem(short templateId, string name, string desc, sbyte[] parameters, sbyte notDisplayedParm, string[] parametersUiName, sbyte[] blockSizeArgs, byte involvedCharacterCount, byte involvedItemCount, byte involvedCombatSkillCount, byte involvedLifeSkillCount, byte involvedLocationCount, byte involvedResourceTypeCount, byte involvedIntegerDataCount, bool autoBroadCast, short costAuthority, sbyte diffusionRange, byte diffusionSpeed, sbyte fameThreshold, byte maxPersonAmount, short duration, ESecretInformationInitialTarget initialTarget, int[] initialTargetParameterIndices, int[] relationshipSnapshotParameterIndices, int[] extraSnapshotParameterIndices, bool isGeneralRelationCharactersNeedSnapshot, bool isRelationCharactersAliveStateNeedSnapshot, ESecretInformationValueType valueType, short disseminationId, short receptionId, short defaultEffectId, short structGroupId, short sectPunishRuleId, short sortValue, short discoveryRate, short discoveryRateTaiwu, short discoveryRateFactorA, short discoveryRateFactorB, short discoveryRateFactorC, string broadcastDesc, bool autoDissemination, short generalFilterType, short detailedFilterType)
	{
		TemplateId = templateId;
		Name = name;
		Desc = desc;
		Parameters = parameters;
		NotDisplayedParm = notDisplayedParm;
		ParametersUiName = parametersUiName;
		BlockSizeArgs = blockSizeArgs;
		InvolvedCharacterCount = involvedCharacterCount;
		InvolvedItemCount = involvedItemCount;
		InvolvedCombatSkillCount = involvedCombatSkillCount;
		InvolvedLifeSkillCount = involvedLifeSkillCount;
		InvolvedLocationCount = involvedLocationCount;
		InvolvedResourceTypeCount = involvedResourceTypeCount;
		InvolvedIntegerDataCount = involvedIntegerDataCount;
		AutoBroadCast = autoBroadCast;
		CostAuthority = costAuthority;
		DiffusionRange = diffusionRange;
		DiffusionSpeed = diffusionSpeed;
		FameThreshold = fameThreshold;
		MaxPersonAmount = maxPersonAmount;
		Duration = duration;
		InitialTarget = initialTarget;
		InitialTargetParameterIndices = initialTargetParameterIndices;
		RelationshipSnapshotParameterIndices = relationshipSnapshotParameterIndices;
		ExtraSnapshotParameterIndices = extraSnapshotParameterIndices;
		IsGeneralRelationCharactersNeedSnapshot = isGeneralRelationCharactersNeedSnapshot;
		IsRelationCharactersAliveStateNeedSnapshot = isRelationCharactersAliveStateNeedSnapshot;
		ValueType = valueType;
		DisseminationId = disseminationId;
		ReceptionId = receptionId;
		DefaultEffectId = defaultEffectId;
		StructGroupId = structGroupId;
		SectPunishRuleId = sectPunishRuleId;
		SortValue = sortValue;
		DiscoveryRate = discoveryRate;
		DiscoveryRateTaiwu = discoveryRateTaiwu;
		DiscoveryRateFactorA = discoveryRateFactorA;
		DiscoveryRateFactorB = discoveryRateFactorB;
		DiscoveryRateFactorC = discoveryRateFactorC;
		BroadcastDesc = broadcastDesc;
		AutoDissemination = autoDissemination;
		GeneralFilterType = generalFilterType;
		DetailedFilterType = detailedFilterType;
	}

	public SecretInformationItem()
	{
		TemplateId = 0;
		Name = null;
		Desc = null;
		Parameters = null;
		NotDisplayedParm = -1;
		ParametersUiName = null;
		BlockSizeArgs = null;
		InvolvedCharacterCount = 0;
		InvolvedItemCount = 0;
		InvolvedCombatSkillCount = 0;
		InvolvedLifeSkillCount = 0;
		InvolvedLocationCount = 0;
		InvolvedResourceTypeCount = 0;
		InvolvedIntegerDataCount = 0;
		AutoBroadCast = false;
		CostAuthority = 0;
		DiffusionRange = -1;
		DiffusionSpeed = 5;
		FameThreshold = -3;
		MaxPersonAmount = 10;
		Duration = 6;
		InitialTarget = ESecretInformationInitialTarget.None;
		InitialTargetParameterIndices = new int[1];
		RelationshipSnapshotParameterIndices = new int[0];
		ExtraSnapshotParameterIndices = new int[0];
		IsGeneralRelationCharactersNeedSnapshot = false;
		IsRelationCharactersAliveStateNeedSnapshot = false;
		ValueType = ESecretInformationValueType.Normal;
		DisseminationId = 0;
		ReceptionId = 0;
		DefaultEffectId = 0;
		StructGroupId = 0;
		SectPunishRuleId = 0;
		SortValue = 1;
		DiscoveryRate = 10000;
		DiscoveryRateTaiwu = 10000;
		DiscoveryRateFactorA = 1;
		DiscoveryRateFactorB = 25;
		DiscoveryRateFactorC = -1;
		BroadcastDesc = null;
		AutoDissemination = true;
		GeneralFilterType = 9;
		DetailedFilterType = 58;
	}

	public SecretInformationItem(short templateId, SecretInformationItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Desc = other.Desc;
		Parameters = other.Parameters;
		NotDisplayedParm = other.NotDisplayedParm;
		ParametersUiName = other.ParametersUiName;
		BlockSizeArgs = other.BlockSizeArgs;
		InvolvedCharacterCount = other.InvolvedCharacterCount;
		InvolvedItemCount = other.InvolvedItemCount;
		InvolvedCombatSkillCount = other.InvolvedCombatSkillCount;
		InvolvedLifeSkillCount = other.InvolvedLifeSkillCount;
		InvolvedLocationCount = other.InvolvedLocationCount;
		InvolvedResourceTypeCount = other.InvolvedResourceTypeCount;
		InvolvedIntegerDataCount = other.InvolvedIntegerDataCount;
		AutoBroadCast = other.AutoBroadCast;
		CostAuthority = other.CostAuthority;
		DiffusionRange = other.DiffusionRange;
		DiffusionSpeed = other.DiffusionSpeed;
		FameThreshold = other.FameThreshold;
		MaxPersonAmount = other.MaxPersonAmount;
		Duration = other.Duration;
		InitialTarget = other.InitialTarget;
		InitialTargetParameterIndices = other.InitialTargetParameterIndices;
		RelationshipSnapshotParameterIndices = other.RelationshipSnapshotParameterIndices;
		ExtraSnapshotParameterIndices = other.ExtraSnapshotParameterIndices;
		IsGeneralRelationCharactersNeedSnapshot = other.IsGeneralRelationCharactersNeedSnapshot;
		IsRelationCharactersAliveStateNeedSnapshot = other.IsRelationCharactersAliveStateNeedSnapshot;
		ValueType = other.ValueType;
		DisseminationId = other.DisseminationId;
		ReceptionId = other.ReceptionId;
		DefaultEffectId = other.DefaultEffectId;
		StructGroupId = other.StructGroupId;
		SectPunishRuleId = other.SectPunishRuleId;
		SortValue = other.SortValue;
		DiscoveryRate = other.DiscoveryRate;
		DiscoveryRateTaiwu = other.DiscoveryRateTaiwu;
		DiscoveryRateFactorA = other.DiscoveryRateFactorA;
		DiscoveryRateFactorB = other.DiscoveryRateFactorB;
		DiscoveryRateFactorC = other.DiscoveryRateFactorC;
		BroadcastDesc = other.BroadcastDesc;
		AutoDissemination = other.AutoDissemination;
		GeneralFilterType = other.GeneralFilterType;
		DetailedFilterType = other.DetailedFilterType;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override SecretInformationItem Duplicate(int templateId)
	{
		return new SecretInformationItem((short)templateId, this);
	}
}
