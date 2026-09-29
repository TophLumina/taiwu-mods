using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class PredefinedLog : ConfigData<PredefinedLogItem, short>
{
	public static class DefKey
	{
		public const short SecretInformationForcedToBeErased = 0;

		public const short LoadModConfigFail = 1;

		public const short LoadModConfigFailWithoutName = 2;

		public const short LoadModSettingsFail = 3;

		public const short LoadModSystemSettingsFail = 4;

		public const short CombatFrameConfigNegative = 5;

		public const short ProfessionSkillAnimationRuntimeException = 6;

		public const short CombatSpecialEffectRuntimeException = 7;

		public const short CombatRuntimeException = 8;

		public const short VideoFormatUnSupportedException = 9;

		public const short TaskTemplateIdNotExist = 10;

		public const short MapRuntimeException = 11;

		public const short CharacterRuntimeException = 12;

		public const short CombatSkillRuntimeException = 13;

		public const short NetRuntimeException = 14;

		public const short LifeSkillCombatOperationExpired = 15;

		public const short DreamBackWorldNotMatch = 16;

		public const short JiaoChangeloongRefreshIndexException = 17;

		public const short GeneralRefreshIndexException = 18;

		public const short WorldRuntimeException = 19;

		public const short DuplicatedItemDetected = 20;

		public const short UnownedItemDetected = 21;

		public const short EventChangedWithNotEntering = 22;

		public const short CombatAiLoadException = 23;

		public const short ModConfigNotFoundException = 24;

		public const short ValueCanNotBeEmpty = 25;

		public const short ValueNotFoundInConfigTable = 26;

		public const short EventNotFoundInAnyEventGroup = 27;

		public const short InvalidEnumIndex = 28;

		public const short LuaScriptingException = 29;

		public const short CacheCorruptedNoChickenInSettlement = 30;

		public const short CacheCorruptedSetSettlementHasNoChicken = 31;

		public const short CacheCorruptedRemoveNonExistsChicken = 32;

		public const short UnknownPunishmentType = 33;

		public const short GetNotAliveDisplayingAge = 34;

		public const short ConfigurationParseFailed = 35;

		public const short AdventureElementNotFind = 36;

		public const short AdventureMajorEventNotFind = 37;

		public const short AdventureNotFind = 38;

		public const short AdventureEventOverflow = 39;

		public const short AdventureGenerateFailed = 40;

		public const short CricketExtraWagerGenerateFailed = 41;

		public const short PolymorphStateChangeFailed = 42;

		public const short LoadArchiveDataFailed = 43;

		public const short TransferToOldFailed = 44;

		public const short CharacterGoalCreationFailed = 45;

		public const short CharacterActionPlanningFailed = 46;

		public const short CharacterActionExecutionFailed = 47;

		public const short GameMessageRenderError = 48;

		public const short SerializedSizeExceedLimit = 49;

		public const short InvalidItemStacking1 = 50;

		public const short InvalidItemStacking2 = 51;

		public const short FrontendDebateError = 52;
	}

	public static class DefValue
	{
		public static PredefinedLogItem SecretInformationForcedToBeErased => Instance[(short)0];

		public static PredefinedLogItem LoadModConfigFail => Instance[(short)1];

		public static PredefinedLogItem LoadModConfigFailWithoutName => Instance[(short)2];

		public static PredefinedLogItem LoadModSettingsFail => Instance[(short)3];

		public static PredefinedLogItem LoadModSystemSettingsFail => Instance[(short)4];

		public static PredefinedLogItem CombatFrameConfigNegative => Instance[(short)5];

		public static PredefinedLogItem ProfessionSkillAnimationRuntimeException => Instance[(short)6];

		public static PredefinedLogItem CombatSpecialEffectRuntimeException => Instance[(short)7];

		public static PredefinedLogItem CombatRuntimeException => Instance[(short)8];

		public static PredefinedLogItem VideoFormatUnSupportedException => Instance[(short)9];

		public static PredefinedLogItem TaskTemplateIdNotExist => Instance[(short)10];

		public static PredefinedLogItem MapRuntimeException => Instance[(short)11];

		public static PredefinedLogItem CharacterRuntimeException => Instance[(short)12];

		public static PredefinedLogItem CombatSkillRuntimeException => Instance[(short)13];

		public static PredefinedLogItem NetRuntimeException => Instance[(short)14];

		public static PredefinedLogItem LifeSkillCombatOperationExpired => Instance[(short)15];

		public static PredefinedLogItem DreamBackWorldNotMatch => Instance[(short)16];

		public static PredefinedLogItem JiaoChangeloongRefreshIndexException => Instance[(short)17];

		public static PredefinedLogItem GeneralRefreshIndexException => Instance[(short)18];

		public static PredefinedLogItem WorldRuntimeException => Instance[(short)19];

		public static PredefinedLogItem DuplicatedItemDetected => Instance[(short)20];

		public static PredefinedLogItem UnownedItemDetected => Instance[(short)21];

		public static PredefinedLogItem EventChangedWithNotEntering => Instance[(short)22];

		public static PredefinedLogItem CombatAiLoadException => Instance[(short)23];

		public static PredefinedLogItem ModConfigNotFoundException => Instance[(short)24];

		public static PredefinedLogItem ValueCanNotBeEmpty => Instance[(short)25];

		public static PredefinedLogItem ValueNotFoundInConfigTable => Instance[(short)26];

		public static PredefinedLogItem EventNotFoundInAnyEventGroup => Instance[(short)27];

		public static PredefinedLogItem InvalidEnumIndex => Instance[(short)28];

		public static PredefinedLogItem LuaScriptingException => Instance[(short)29];

		public static PredefinedLogItem CacheCorruptedNoChickenInSettlement => Instance[(short)30];

		public static PredefinedLogItem CacheCorruptedSetSettlementHasNoChicken => Instance[(short)31];

		public static PredefinedLogItem CacheCorruptedRemoveNonExistsChicken => Instance[(short)32];

		public static PredefinedLogItem UnknownPunishmentType => Instance[(short)33];

		public static PredefinedLogItem GetNotAliveDisplayingAge => Instance[(short)34];

		public static PredefinedLogItem ConfigurationParseFailed => Instance[(short)35];

		public static PredefinedLogItem AdventureElementNotFind => Instance[(short)36];

		public static PredefinedLogItem AdventureMajorEventNotFind => Instance[(short)37];

		public static PredefinedLogItem AdventureNotFind => Instance[(short)38];

		public static PredefinedLogItem AdventureEventOverflow => Instance[(short)39];

		public static PredefinedLogItem AdventureGenerateFailed => Instance[(short)40];

		public static PredefinedLogItem CricketExtraWagerGenerateFailed => Instance[(short)41];

		public static PredefinedLogItem PolymorphStateChangeFailed => Instance[(short)42];

		public static PredefinedLogItem LoadArchiveDataFailed => Instance[(short)43];

		public static PredefinedLogItem TransferToOldFailed => Instance[(short)44];

		public static PredefinedLogItem CharacterGoalCreationFailed => Instance[(short)45];

		public static PredefinedLogItem CharacterActionPlanningFailed => Instance[(short)46];

		public static PredefinedLogItem CharacterActionExecutionFailed => Instance[(short)47];

		public static PredefinedLogItem GameMessageRenderError => Instance[(short)48];

		public static PredefinedLogItem SerializedSizeExceedLimit => Instance[(short)49];

		public static PredefinedLogItem InvalidItemStacking1 => Instance[(short)50];

		public static PredefinedLogItem InvalidItemStacking2 => Instance[(short)51];

		public static PredefinedLogItem FrontendDebateError => Instance[(short)52];
	}

	public static PredefinedLog Instance = new PredefinedLog();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "Info", "TemplateId" };

	internal override int ToInt(short value)
	{
		return value;
	}

	internal override short ToTemplateId(int value)
	{
		return (short)value;
	}

	private void CreateItems0()
	{
		_dataArray.Add(new PredefinedLogItem(0, LocalStringManager.GetConfig("PredefinedLog_language", "Name_0"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_0"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(1, LocalStringManager.GetConfig("PredefinedLog_language", "Name_1"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_1"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(2, LocalStringManager.GetConfig("PredefinedLog_language", "Name_2"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_2"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(3, LocalStringManager.GetConfig("PredefinedLog_language", "Name_3"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_3"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(4, LocalStringManager.GetConfig("PredefinedLog_language", "Name_4"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_4"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(5, LocalStringManager.GetConfig("PredefinedLog_language", "Name_5"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_5"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(6, LocalStringManager.GetConfig("PredefinedLog_language", "Name_6"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_6"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(7, LocalStringManager.GetConfig("PredefinedLog_language", "Name_7"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_7"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(8, LocalStringManager.GetConfig("PredefinedLog_language", "Name_8"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_8"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(9, LocalStringManager.GetConfig("PredefinedLog_language", "Name_9"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_9"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(10, LocalStringManager.GetConfig("PredefinedLog_language", "Name_10"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_10"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(11, LocalStringManager.GetConfig("PredefinedLog_language", "Name_11"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_11"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(12, LocalStringManager.GetConfig("PredefinedLog_language", "Name_12"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_12"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(13, LocalStringManager.GetConfig("PredefinedLog_language", "Name_13"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_13"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(14, LocalStringManager.GetConfig("PredefinedLog_language", "Name_14"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_14"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(15, LocalStringManager.GetConfig("PredefinedLog_language", "Name_15"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_15"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(16, LocalStringManager.GetConfig("PredefinedLog_language", "Name_16"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_16"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(17, LocalStringManager.GetConfig("PredefinedLog_language", "Name_17"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_17"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(18, LocalStringManager.GetConfig("PredefinedLog_language", "Name_18"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_18"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(19, LocalStringManager.GetConfig("PredefinedLog_language", "Name_19"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_19"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(20, LocalStringManager.GetConfig("PredefinedLog_language", "Name_20"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_20"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(21, LocalStringManager.GetConfig("PredefinedLog_language", "Name_21"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_21"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(22, LocalStringManager.GetConfig("PredefinedLog_language", "Name_22"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_22"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(23, LocalStringManager.GetConfig("PredefinedLog_language", "Name_23"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_23"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(24, LocalStringManager.GetConfig("PredefinedLog_language", "Name_24"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_24"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(25, LocalStringManager.GetConfig("PredefinedLog_language", "Name_25"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_25"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(26, LocalStringManager.GetConfig("PredefinedLog_language", "Name_26"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_26"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(27, LocalStringManager.GetConfig("PredefinedLog_language", "Name_27"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_27"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(28, LocalStringManager.GetConfig("PredefinedLog_language", "Name_28"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_28"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(29, LocalStringManager.GetConfig("PredefinedLog_language", "Name_29"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_29"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(30, LocalStringManager.GetConfig("PredefinedLog_language", "Name_30"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_30"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(31, LocalStringManager.GetConfig("PredefinedLog_language", "Name_31"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_31"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(32, LocalStringManager.GetConfig("PredefinedLog_language", "Name_32"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_32"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(33, LocalStringManager.GetConfig("PredefinedLog_language", "Name_33"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_33"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(34, LocalStringManager.GetConfig("PredefinedLog_language", "Name_34"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_34"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(35, LocalStringManager.GetConfig("PredefinedLog_language", "Name_35"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_35"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(36, LocalStringManager.GetConfig("PredefinedLog_language", "Name_36"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_36"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(37, LocalStringManager.GetConfig("PredefinedLog_language", "Name_37"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_37"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(38, LocalStringManager.GetConfig("PredefinedLog_language", "Name_38"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_38"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(39, LocalStringManager.GetConfig("PredefinedLog_language", "Name_39"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_39"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(40, LocalStringManager.GetConfig("PredefinedLog_language", "Name_40"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_40"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(41, LocalStringManager.GetConfig("PredefinedLog_language", "Name_41"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_41"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(42, LocalStringManager.GetConfig("PredefinedLog_language", "Name_42"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_42"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(43, LocalStringManager.GetConfig("PredefinedLog_language", "Name_43"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_43"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(44, LocalStringManager.GetConfig("PredefinedLog_language", "Name_44"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_44"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(45, LocalStringManager.GetConfig("PredefinedLog_language", "Name_45"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_45"), debugOnly: true));
		_dataArray.Add(new PredefinedLogItem(46, LocalStringManager.GetConfig("PredefinedLog_language", "Name_46"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_46"), debugOnly: true));
		_dataArray.Add(new PredefinedLogItem(47, LocalStringManager.GetConfig("PredefinedLog_language", "Name_47"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_47"), debugOnly: true));
		_dataArray.Add(new PredefinedLogItem(48, LocalStringManager.GetConfig("PredefinedLog_language", "Name_48"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_48"), debugOnly: true));
		_dataArray.Add(new PredefinedLogItem(49, LocalStringManager.GetConfig("PredefinedLog_language", "Name_49"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_49"), debugOnly: true));
		_dataArray.Add(new PredefinedLogItem(50, LocalStringManager.GetConfig("PredefinedLog_language", "Name_50"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_50"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(51, LocalStringManager.GetConfig("PredefinedLog_language", "Name_51"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_51"), debugOnly: false));
		_dataArray.Add(new PredefinedLogItem(52, LocalStringManager.GetConfig("PredefinedLog_language", "Name_52"), LocalStringManager.GetConfig("PredefinedLog_language", "Info_52"), debugOnly: false));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<PredefinedLogItem>(53);
		CreateItems0();
	}

	public static void Show(short predefinedLogId)
	{
		Instance[predefinedLogId].Log();
	}

	public static void Show(short predefinedLogId, object arg0)
	{
		Instance[predefinedLogId].Log(arg0);
	}

	public static void Show(short predefinedLogId, object arg0, object arg1)
	{
		Instance[predefinedLogId].Log(arg0, arg1);
	}

	public static void Show(short predefinedLogId, object arg0, object arg1, object arg2)
	{
		Instance[predefinedLogId].Log(arg0, arg1, arg2);
	}

	public static void Show(short predefinedLogId, params object[] parameters)
	{
		Instance[predefinedLogId].Log(parameters);
	}
}
