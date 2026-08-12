using System.Collections.Generic;

namespace GameData.Domains.Information;

public static class InformationDomainHelper
{
	/// <summary>
	/// 数据域所辖数据
	/// </summary>
	public static class DataIds
	{
		public const ushort Information = 0;

		public const ushort SecretInformationCollection = 1;

		public const ushort TaiwuReceivedNormalInformationInMonth = 2;

		public const ushort TaiwuReceivedInformation = 3;

		public const ushort TaiwuTmpInformation = 4;

		public const ushort CharacterKnownSecrets = 5;

		public const ushort SecretInformation = 6;

		public const ushort SecretOccurence = 7;

		public const ushort SecretInformationLevelFactors = 8;
	}

	/// <summary>
	/// 数据域中的方法
	/// </summary>
	public static class MethodIds
	{
		public const ushort GetCharacterNormalInformation = 0;

		public const ushort AddNormalInformationToCharacter = 1;

		public const ushort DeleteTmpInformation = 2;

		public const ushort GetNormalInformationUsedCount = 3;

		public const ushort GetSecretInformationDisplayPackage = 4;

		public const ushort GetSecretInformationDisplayPackageFromCharacter = 5;

		public const ushort GetSecretInformationDisplayPackageFromBroadcast = 6;

		public const ushort GetSecretInformationDisplayPackageForSelections = 7;

		public const ushort DiscardSecretInformation = 8;

		public const ushort GmCmd_CreateSecretInformationByCharacterIds = 9;

		public const ushort GmCmd_MakeCharacterReceiveSecretInformation = 10;

		public const ushort DisseminateSecretInformation = 11;

		public const ushort GetCharacterDisplayDataWithInfoList = 12;

		public const ushort GmCmd_MakeSecretInformationBroadcast = 13;

		public const ushort PerformProfessionLiteratiSkill3 = 14;

		public const ushort PerformProfessionLiteratiSkill2 = 15;

		public const ushort GetNormalInformationUsedCountAndMax = 16;

		public const ushort SettleSecretInformationShopTrade = 17;

		public const ushort GmCmd_DisseminationSecretInformationToRandomCharacters = 18;

		public const ushort GetCharacterNormalInformationDisplayData = 19;

		public const ushort SetSecretInformationLevelFactor = 20;

		public const ushort GetSecretInformationLevelFactor = 21;

		public const ushort GetSecretInformationDetailedData = 22;

		public const ushort GetSecretInformationAmountFromCharacter = 23;
	}

	/// <summary>
	/// 数据域所辖数据的个数
	/// </summary>
	public const ushort DataCount = 9;

	/// <summary>
	/// 通过字段名获取数据 ID
	/// </summary>
	public static readonly Dictionary<string, ushort> FieldName2DataId = new Dictionary<string, ushort>
	{
		{ "Information", 0 },
		{ "SecretInformationCollection", 1 },
		{ "TaiwuReceivedNormalInformationInMonth", 2 },
		{ "TaiwuReceivedInformation", 3 },
		{ "TaiwuTmpInformation", 4 },
		{ "CharacterKnownSecrets", 5 },
		{ "SecretInformation", 6 },
		{ "SecretOccurence", 7 },
		{ "SecretInformationLevelFactors", 8 }
	};

	/// <summary>
	/// 通过数据 ID 获取对应的字段名.
	/// 字段名不一定要与字段的真实名称完全一致, 只要保证正反对应关系就行.
	/// </summary>
	public static readonly string[] DataId2FieldName = new string[9] { "Information", "SecretInformationCollection", "TaiwuReceivedNormalInformationInMonth", "TaiwuReceivedInformation", "TaiwuTmpInformation", "CharacterKnownSecrets", "SecretInformation", "SecretOccurence", "SecretInformationLevelFactors" };

	/// <summary>
	/// DataId -&gt; 集合对象内的 FieldId -&gt; FieldName
	/// </summary>
	public static readonly string[][] DataId2ObjectFieldId2FieldName = new string[9][];

	/// <summary>
	/// 通过数据域方法名获取数据域方法 ID
	/// </summary>
	public static readonly Dictionary<string, ushort> MethodName2MethodId = new Dictionary<string, ushort>
	{
		{ "GetCharacterNormalInformation", 0 },
		{ "AddNormalInformationToCharacter", 1 },
		{ "DeleteTmpInformation", 2 },
		{ "GetNormalInformationUsedCount", 3 },
		{ "GetSecretInformationDisplayPackage", 4 },
		{ "GetSecretInformationDisplayPackageFromCharacter", 5 },
		{ "GetSecretInformationDisplayPackageFromBroadcast", 6 },
		{ "GetSecretInformationDisplayPackageForSelections", 7 },
		{ "DiscardSecretInformation", 8 },
		{ "GmCmd_CreateSecretInformationByCharacterIds", 9 },
		{ "GmCmd_MakeCharacterReceiveSecretInformation", 10 },
		{ "DisseminateSecretInformation", 11 },
		{ "GetCharacterDisplayDataWithInfoList", 12 },
		{ "GmCmd_MakeSecretInformationBroadcast", 13 },
		{ "PerformProfessionLiteratiSkill3", 14 },
		{ "PerformProfessionLiteratiSkill2", 15 },
		{ "GetNormalInformationUsedCountAndMax", 16 },
		{ "SettleSecretInformationShopTrade", 17 },
		{ "GmCmd_DisseminationSecretInformationToRandomCharacters", 18 },
		{ "GetCharacterNormalInformationDisplayData", 19 },
		{ "SetSecretInformationLevelFactor", 20 },
		{ "GetSecretInformationLevelFactor", 21 },
		{ "GetSecretInformationDetailedData", 22 },
		{ "GetSecretInformationAmountFromCharacter", 23 }
	};

	public static readonly string[] MethodId2MethodName = new string[24]
	{
		"GetCharacterNormalInformation", "AddNormalInformationToCharacter", "DeleteTmpInformation", "GetNormalInformationUsedCount", "GetSecretInformationDisplayPackage", "GetSecretInformationDisplayPackageFromCharacter", "GetSecretInformationDisplayPackageFromBroadcast", "GetSecretInformationDisplayPackageForSelections", "DiscardSecretInformation", "GmCmd_CreateSecretInformationByCharacterIds",
		"GmCmd_MakeCharacterReceiveSecretInformation", "DisseminateSecretInformation", "GetCharacterDisplayDataWithInfoList", "GmCmd_MakeSecretInformationBroadcast", "PerformProfessionLiteratiSkill3", "PerformProfessionLiteratiSkill2", "GetNormalInformationUsedCountAndMax", "SettleSecretInformationShopTrade", "GmCmd_DisseminationSecretInformationToRandomCharacters", "GetCharacterNormalInformationDisplayData",
		"SetSecretInformationLevelFactor", "GetSecretInformationLevelFactor", "GetSecretInformationDetailedData", "GetSecretInformationAmountFromCharacter"
	};
}
