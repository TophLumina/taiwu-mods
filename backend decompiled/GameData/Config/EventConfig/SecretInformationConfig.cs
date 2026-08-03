using System;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.Character.Relation;
using GameData.Domains.Information;
using GameData.Domains.Information.Secret;
using GameData.Domains.TaiwuEvent.EventHelper;

namespace Config.EventConfig;

public class SecretInformationConfig
{
	private static readonly int[] LeadToGoodByCombatBehaviorTypeParam = new int[5] { 20, 18, 16, 14, 12 };

	private static readonly int[] LeadToGoodByRationalityBehaviorTypeParam = new int[5] { 12, 14, 16, 18, 20 };

	private static readonly int[] LeadToGoodByEmotionBehaviorTypeParam = new int[5] { 18, 6, 12, 6, 18 };

	private static readonly int[] LeadToGoodByEmotionBehaviorTypeCorrectionParam = new int[5] { -400, -800, -600, -800, -400 };

	private static readonly int[] LeadToEvilByCombatBehaviorTypeParam = new int[5] { 20, 18, 16, 14, 12 };

	private static readonly int[] LeadToEvilByRationalityBehaviorTypeParam = new int[5] { 12, 14, 16, 18, 20 };

	private static readonly int[] GetLeadToEvilByEmotionBehaviorTypeParam = new int[5] { 18, 6, 12, 6, 18 };

	private static readonly int[] GetLeadToEvilByEmotionBehaviorTypeCorrectionParam = new int[5] { -400, -800, -600, -800, -400 };

	public static readonly int GradeFactor_StartRelation_Difficulty = 6;

	public static readonly int[] BehaviorAdjust_StartRelation_Difficulty = new int[5] { 18, 6, 12, 6, 18 };

	public static readonly int[] FavorFactor_StartRelation_Difficulty = new int[5] { 0, -300, -200, 300, -100 };

	public static readonly int SortValueFactor_StartRelation_Effect = 4;

	public static readonly int HolderCountFactor_StartRelation_Effect = 50;

	public static readonly int[] FavorFactor_StartRelation_Effect = new int[5] { 0, 300, 200, -300, 100 };

	public static readonly int FameDenominator_StartRelation_Effect = 2;

	public static readonly int GradeFactor_EndRelation_Difficulty = 6;

	public static readonly int[] BehaviorAdjust_EndRelation_Difficulty = new int[5] { 18, 6, 12, 6, 18 };

	public static readonly int[] FavorFactor_EndRelation_Difficulty = new int[5] { 100, 300, 200, -300, 0 };

	public static readonly int SortValueFactor_EndRelation_Effect = 4;

	public static readonly int HolderCountFactor_EndRelation_Effect = 50;

	public static readonly int[] FavorFactor_EndRelation_Effect = new int[5] { 100, 300, 200, -300, 0 };

	public static readonly int FameDenominator_EndRelation_Effect = 2;

	public static readonly int[] ReduceDebtBehaviorFactorOfThreatening = new int[5] { 14, 18, 20, 16, 12 };

	public static int GetLeadToGoodByCombatFavorabilityChange(int charId, SecretInformationId secretId)
	{
		GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
		SecretInformationItem config = DomainManager.Information.CalcSecretInformationConfig(secretId);
		return -((config.SortValue - 1) * 50 * LeadToGoodByCombatBehaviorTypeParam[character.GetBehaviorType()] + 2000);
	}

	public static int GetLeadToGoodByCombatBehaviorTypeOffset(SecretInformationId secretId)
	{
		SecretInformationItem config = DomainManager.Information.CalcSecretInformationConfig(secretId);
		return config.SortValue * 50 + 50;
	}

	public static int GetLeadToGoodByRationalityFavorabilityChange(int charId, SecretInformationId secretId)
	{
		GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
		SecretInformationItem config = DomainManager.Information.CalcSecretInformationConfig(secretId);
		return -((config.SortValue - 1) * 25 * LeadToGoodByRationalityBehaviorTypeParam[character.GetBehaviorType()] + 1000);
	}

	public static int GetLeadToGoodByRationalityBehaviorTypeOffset(SecretInformationId secretId)
	{
		SecretInformationItem config = DomainManager.Information.CalcSecretInformationConfig(secretId);
		return config.SortValue * 50 + 50;
	}

	public static int GetLeadToGoodByEmotionBehaviorTypeOffset(SecretInformationId secretId)
	{
		SecretInformationItem config = DomainManager.Information.CalcSecretInformationConfig(secretId);
		return config.SortValue * 50 + 50;
	}

	public static int GetLeadToGoodByEmotionDifficultyValue(int charId)
	{
		GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
		int baseValue = (character.GetOrganizationInfo().InteractionGrade + 1) * 6 + LeadToGoodByEmotionBehaviorTypeParam[character.GetBehaviorType()];
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		sbyte favorabilityType = FavorabilityType.GetFavorabilityType(DomainManager.Character.GetFavorability(charId, taiwuCharId));
		return Math.Max(favorabilityType * LeadToGoodByEmotionBehaviorTypeCorrectionParam[character.GetBehaviorType()] / 100 + baseValue, 0);
	}

	public static int GetLeadToGoodByEmotionEffectValue(int charId, SecretInformationId secretId)
	{
		GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
		GameData.Domains.Information.Secret.SecretInformation secret = DomainManager.Information.QuerySecretInformation(secretId);
		SecretOccurence occurence;
		byte[] secretParams = secret.QueryParameters(out occurence);
		SecretInformationItem config = SecretInformation.Instance[occurence.TemplateId];
		bool isSect = Organization.Instance[character.GetOrganizationInfo().OrgTemplateId].IsSect;
		int punishLevel = 0;
		if (isSect)
		{
			SecretInformationProcessor processor = DomainManager.Information.SecretInformationProcessorPool.Get();
			if (!processor.Initialize(occurence, secretParams))
			{
				DomainManager.Information.SecretInformationProcessorPool.Return(processor);
			}
			else
			{
				punishLevel = processor.CalSectPunishLevel_WithCharId(charId) + 1;
				DomainManager.Information.SecretInformationProcessorPool.Return(processor);
			}
		}
		else
		{
			punishLevel = config.SortValue / 3;
		}
		int baseValue = config.SortValue * 2;
		baseValue += baseValue * punishLevel * 20 / 100;
		int knownCount = (EventHelper.IsSecretInformationBroadcast((int)secretId) ? SecretInformation.Instance.GetItem(config.TemplateId).MaxPersonAmount : Math.Min(EventHelper.GetSecretInformationHolderCount((int)secretId), SecretInformation.Instance.GetItem(config.TemplateId).MaxPersonAmount));
		int finalValue = knownCount * 50 / SecretInformation.Instance.GetItem(config.TemplateId).MaxPersonAmount * baseValue / 100;
		return finalValue + finalValue * character.GetFame() / 2 / 100;
	}

	public static int GetLeadToEvilByCombatFavorabilityChange(int charId, int metaDataId)
	{
		return 0;
	}

	public static int GetLeadToEvilByCombatBehaviorTypeOffset(SecretInformationId secretId)
	{
		SecretInformationItem config = DomainManager.Information.CalcSecretInformationConfig(secretId);
		return -(config.SortValue * 50 + 50);
	}

	public static int GetLeadToEvilByRationalityFavorabilityChange(int charId, int metaDataId)
	{
		return 0;
	}

	public static int GetLeadToEvilByRationalityBehaviorTypeOffset(SecretInformationId secretId)
	{
		SecretInformationItem config = DomainManager.Information.CalcSecretInformationConfig(secretId);
		return -(config.SortValue * 50 + 50);
	}

	public static int GetLeadToEvilByEmotionBehaviorTypeOffset(SecretInformationId secretId)
	{
		SecretInformationItem config = DomainManager.Information.CalcSecretInformationConfig(secretId);
		return -(config.SortValue * 50 + 50);
	}

	public static int GetLeadToEvilByEmotionDifficultyValue(int charId, int metaDataId)
	{
		return 0;
	}

	public static int GetLeadToEvilByEmotionEffectValue(int charId, int metaDataId)
	{
		return 0;
	}
}
