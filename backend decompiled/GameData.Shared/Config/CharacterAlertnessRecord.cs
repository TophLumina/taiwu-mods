using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class CharacterAlertnessRecord : ConfigData<CharacterAlertnessRecordItem, short>
{
	public static class DefKey
	{
		public const short CharBehaviorType = 0;

		public const short CharGrade = 1;

		public const short OrganizationApprove = 2;

		public const short TaiwuFame = 3;

		public const short ChallengeFame = 56;

		public const short ChallengeBehavior = 57;

		public const short SendGif = 4;

		public const short GiveTeammateResource = 5;

		public const short GiveTeammateItem = 6;

		public const short TalkByNormalInformation = 7;

		public const short PraiseSevenElement = 8;

		public const short PraiseCharm = 9;

		public const short PraiseFame = 10;

		public const short PraiseFeature = 11;

		public const short PraiseMoney = 12;

		public const short SneerSevenElement = 13;

		public const short SneerCharm = 14;

		public const short SneerFame = 15;

		public const short SneerFeature = 16;

		public const short SneerMoney = 17;

		public const short MakeLineAndBridge = 18;

		public const short ProfessionWineTasterSkill0 = 19;

		public const short ProfessionWineTasterSkill3 = 20;

		public const short ProfessionLiteratiSkill3 = 21;

		public const short ProfessionTaoistMonkSkill1 = 22;

		public const short ProfessionAristocratSkill0 = 23;

		public const short ProfessionAristocratSkill1 = 24;

		public const short ProfessionBeggarSkill3 = 25;

		public const short ProfessionCivilianSkill0 = 26;

		public const short ProfessionCivilianSkill1 = 27;

		public const short ProfessionDoctorSkill0 = 28;

		public const short ProfessionDoctorSkill1 = 29;

		public const short ProfessionDoctorSkill3 = 30;

		public const short ProfessionTeaTasterSkill0 = 31;

		public const short ProfessionTeaTasterSkill3 = 32;

		public const short ProfessionDukeSkill1Add = 33;

		public const short ProfessionMartialArtistSkill0 = 34;

		public const short ProfessionCivilianSkill2 = 35;

		public const short ProfessionDukeSkill1Remove = 36;

		public const short TakeTeammateResource = 37;

		public const short TakeTeammateItem = 38;

		public const short StealLifeSkill = 39;

		public const short StealCombatSkill = 40;

		public const short ScamLifeSkill = 41;

		public const short ScamCombatSkill = 42;

		public const short ScamItem = 43;

		public const short ScamResource = 44;

		public const short ScamNormalInformation = 45;

		public const short ScamSecretInformation = 46;

		public const short StealItem = 47;

		public const short StealResource = 48;

		public const short RobItem = 49;

		public const short RobResource = 50;

		public const short Poison = 51;

		public const short Damage = 52;

		public const short Attack = 53;

		public const short AttackKidnappedCharacter = 54;

		public const short RemoveKidnappedCharacter = 55;

		public const short Base = 58;
	}

	public static class DefValue
	{
		public static CharacterAlertnessRecordItem CharBehaviorType => Instance[(short)0];

		public static CharacterAlertnessRecordItem CharGrade => Instance[(short)1];

		public static CharacterAlertnessRecordItem OrganizationApprove => Instance[(short)2];

		public static CharacterAlertnessRecordItem TaiwuFame => Instance[(short)3];

		public static CharacterAlertnessRecordItem ChallengeFame => Instance[(short)56];

		public static CharacterAlertnessRecordItem ChallengeBehavior => Instance[(short)57];

		public static CharacterAlertnessRecordItem SendGif => Instance[(short)4];

		public static CharacterAlertnessRecordItem GiveTeammateResource => Instance[(short)5];

		public static CharacterAlertnessRecordItem GiveTeammateItem => Instance[(short)6];

		public static CharacterAlertnessRecordItem TalkByNormalInformation => Instance[(short)7];

		public static CharacterAlertnessRecordItem PraiseSevenElement => Instance[(short)8];

		public static CharacterAlertnessRecordItem PraiseCharm => Instance[(short)9];

		public static CharacterAlertnessRecordItem PraiseFame => Instance[(short)10];

		public static CharacterAlertnessRecordItem PraiseFeature => Instance[(short)11];

		public static CharacterAlertnessRecordItem PraiseMoney => Instance[(short)12];

		public static CharacterAlertnessRecordItem SneerSevenElement => Instance[(short)13];

		public static CharacterAlertnessRecordItem SneerCharm => Instance[(short)14];

		public static CharacterAlertnessRecordItem SneerFame => Instance[(short)15];

		public static CharacterAlertnessRecordItem SneerFeature => Instance[(short)16];

		public static CharacterAlertnessRecordItem SneerMoney => Instance[(short)17];

		public static CharacterAlertnessRecordItem MakeLineAndBridge => Instance[(short)18];

		public static CharacterAlertnessRecordItem ProfessionWineTasterSkill0 => Instance[(short)19];

		public static CharacterAlertnessRecordItem ProfessionWineTasterSkill3 => Instance[(short)20];

		public static CharacterAlertnessRecordItem ProfessionLiteratiSkill3 => Instance[(short)21];

		public static CharacterAlertnessRecordItem ProfessionTaoistMonkSkill1 => Instance[(short)22];

		public static CharacterAlertnessRecordItem ProfessionAristocratSkill0 => Instance[(short)23];

		public static CharacterAlertnessRecordItem ProfessionAristocratSkill1 => Instance[(short)24];

		public static CharacterAlertnessRecordItem ProfessionBeggarSkill3 => Instance[(short)25];

		public static CharacterAlertnessRecordItem ProfessionCivilianSkill0 => Instance[(short)26];

		public static CharacterAlertnessRecordItem ProfessionCivilianSkill1 => Instance[(short)27];

		public static CharacterAlertnessRecordItem ProfessionDoctorSkill0 => Instance[(short)28];

		public static CharacterAlertnessRecordItem ProfessionDoctorSkill1 => Instance[(short)29];

		public static CharacterAlertnessRecordItem ProfessionDoctorSkill3 => Instance[(short)30];

		public static CharacterAlertnessRecordItem ProfessionTeaTasterSkill0 => Instance[(short)31];

		public static CharacterAlertnessRecordItem ProfessionTeaTasterSkill3 => Instance[(short)32];

		public static CharacterAlertnessRecordItem ProfessionDukeSkill1Add => Instance[(short)33];

		public static CharacterAlertnessRecordItem ProfessionMartialArtistSkill0 => Instance[(short)34];

		public static CharacterAlertnessRecordItem ProfessionCivilianSkill2 => Instance[(short)35];

		public static CharacterAlertnessRecordItem ProfessionDukeSkill1Remove => Instance[(short)36];

		public static CharacterAlertnessRecordItem TakeTeammateResource => Instance[(short)37];

		public static CharacterAlertnessRecordItem TakeTeammateItem => Instance[(short)38];

		public static CharacterAlertnessRecordItem StealLifeSkill => Instance[(short)39];

		public static CharacterAlertnessRecordItem StealCombatSkill => Instance[(short)40];

		public static CharacterAlertnessRecordItem ScamLifeSkill => Instance[(short)41];

		public static CharacterAlertnessRecordItem ScamCombatSkill => Instance[(short)42];

		public static CharacterAlertnessRecordItem ScamItem => Instance[(short)43];

		public static CharacterAlertnessRecordItem ScamResource => Instance[(short)44];

		public static CharacterAlertnessRecordItem ScamNormalInformation => Instance[(short)45];

		public static CharacterAlertnessRecordItem ScamSecretInformation => Instance[(short)46];

		public static CharacterAlertnessRecordItem StealItem => Instance[(short)47];

		public static CharacterAlertnessRecordItem StealResource => Instance[(short)48];

		public static CharacterAlertnessRecordItem RobItem => Instance[(short)49];

		public static CharacterAlertnessRecordItem RobResource => Instance[(short)50];

		public static CharacterAlertnessRecordItem Poison => Instance[(short)51];

		public static CharacterAlertnessRecordItem Damage => Instance[(short)52];

		public static CharacterAlertnessRecordItem Attack => Instance[(short)53];

		public static CharacterAlertnessRecordItem AttackKidnappedCharacter => Instance[(short)54];

		public static CharacterAlertnessRecordItem RemoveKidnappedCharacter => Instance[(short)55];

		public static CharacterAlertnessRecordItem Base => Instance[(short)58];
	}

	public static CharacterAlertnessRecord Instance = new CharacterAlertnessRecord();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "Desc", "TemplateId", "Type" };

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
		_dataArray.Add(new CharacterAlertnessRecordItem(0, LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Name_0"), LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Desc_0"), new string[5] { "Integer", "", "", "", "" }, ECharacterAlertnessRecordType.Initial));
		_dataArray.Add(new CharacterAlertnessRecordItem(1, LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Name_1"), LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Desc_1"), new string[5] { "Integer", "", "", "", "" }, ECharacterAlertnessRecordType.Initial));
		_dataArray.Add(new CharacterAlertnessRecordItem(2, LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Name_2"), LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Desc_2"), new string[5] { "Integer", "", "", "", "" }, ECharacterAlertnessRecordType.Initial));
		_dataArray.Add(new CharacterAlertnessRecordItem(3, LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Name_3"), LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Desc_3"), new string[5] { "Integer", "", "", "", "" }, ECharacterAlertnessRecordType.Initial));
		_dataArray.Add(new CharacterAlertnessRecordItem(4, LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Name_4"), LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Desc_4"), new string[5] { "Item", "Integer", "", "", "" }, ECharacterAlertnessRecordType.Trade));
		_dataArray.Add(new CharacterAlertnessRecordItem(5, LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Name_5"), LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Desc_5"), new string[5] { "Resource", "Integer", "Integer", "", "" }, ECharacterAlertnessRecordType.Trade));
		_dataArray.Add(new CharacterAlertnessRecordItem(6, LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Name_6"), LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Desc_6"), new string[5] { "Item", "Integer", "Integer", "", "" }, ECharacterAlertnessRecordType.Trade));
		_dataArray.Add(new CharacterAlertnessRecordItem(7, LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Name_7"), LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Desc_7"), new string[5] { "Information", "Integer", "", "", "" }, ECharacterAlertnessRecordType.Interact));
		_dataArray.Add(new CharacterAlertnessRecordItem(8, LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Name_8"), LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Desc_8"), new string[5] { "Integer", "", "", "", "" }, ECharacterAlertnessRecordType.Interact));
		_dataArray.Add(new CharacterAlertnessRecordItem(9, LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Name_9"), LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Desc_9"), new string[5] { "Integer", "", "", "", "" }, ECharacterAlertnessRecordType.Interact));
		_dataArray.Add(new CharacterAlertnessRecordItem(10, LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Name_10"), LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Desc_10"), new string[5] { "Integer", "", "", "", "" }, ECharacterAlertnessRecordType.Interact));
		_dataArray.Add(new CharacterAlertnessRecordItem(11, LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Name_11"), LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Desc_11"), new string[5] { "Integer", "", "", "", "" }, ECharacterAlertnessRecordType.Interact));
		_dataArray.Add(new CharacterAlertnessRecordItem(12, LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Name_12"), LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Desc_12"), new string[5] { "Integer", "", "", "", "" }, ECharacterAlertnessRecordType.Interact));
		_dataArray.Add(new CharacterAlertnessRecordItem(13, LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Name_13"), LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Desc_13"), new string[5] { "Integer", "", "", "", "" }, ECharacterAlertnessRecordType.Interact));
		_dataArray.Add(new CharacterAlertnessRecordItem(14, LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Name_14"), LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Desc_14"), new string[5] { "Integer", "", "", "", "" }, ECharacterAlertnessRecordType.Interact));
		_dataArray.Add(new CharacterAlertnessRecordItem(15, LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Name_15"), LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Desc_15"), new string[5] { "Integer", "", "", "", "" }, ECharacterAlertnessRecordType.Interact));
		_dataArray.Add(new CharacterAlertnessRecordItem(16, LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Name_16"), LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Desc_16"), new string[5] { "Integer", "", "", "", "" }, ECharacterAlertnessRecordType.Interact));
		_dataArray.Add(new CharacterAlertnessRecordItem(17, LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Name_17"), LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Desc_17"), new string[5] { "Integer", "", "", "", "" }, ECharacterAlertnessRecordType.Interact));
		_dataArray.Add(new CharacterAlertnessRecordItem(18, LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Name_18"), LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Desc_18"), new string[5] { "Character", "Integer", "", "", "" }, ECharacterAlertnessRecordType.Interact));
		_dataArray.Add(new CharacterAlertnessRecordItem(19, LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Name_19"), LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Desc_19"), new string[5] { "Integer", "", "", "", "" }, ECharacterAlertnessRecordType.Interact));
		_dataArray.Add(new CharacterAlertnessRecordItem(20, LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Name_20"), LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Desc_20"), new string[5] { "Integer", "", "", "", "" }, ECharacterAlertnessRecordType.Interact));
		_dataArray.Add(new CharacterAlertnessRecordItem(21, LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Name_21"), LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Desc_21"), new string[5] { "Information", "Integer", "", "", "" }, ECharacterAlertnessRecordType.Interact));
		_dataArray.Add(new CharacterAlertnessRecordItem(22, LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Name_22"), LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Desc_22"), new string[5] { "Integer", "", "", "", "" }, ECharacterAlertnessRecordType.Interact));
		_dataArray.Add(new CharacterAlertnessRecordItem(23, LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Name_23"), LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Desc_23"), new string[5] { "Integer", "", "", "", "" }, ECharacterAlertnessRecordType.Interact));
		_dataArray.Add(new CharacterAlertnessRecordItem(24, LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Name_24"), LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Desc_24"), new string[5] { "Integer", "", "", "", "" }, ECharacterAlertnessRecordType.Interact));
		_dataArray.Add(new CharacterAlertnessRecordItem(25, LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Name_25"), LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Desc_25"), new string[5] { "Item", "Integer", "", "", "" }, ECharacterAlertnessRecordType.Interact));
		_dataArray.Add(new CharacterAlertnessRecordItem(26, LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Name_26"), LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Desc_26"), new string[5] { "Integer", "", "", "", "" }, ECharacterAlertnessRecordType.Interact));
		_dataArray.Add(new CharacterAlertnessRecordItem(27, LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Name_27"), LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Desc_27"), new string[5] { "Integer", "", "", "", "" }, ECharacterAlertnessRecordType.Interact));
		_dataArray.Add(new CharacterAlertnessRecordItem(28, LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Name_28"), LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Desc_28"), new string[5] { "Integer", "", "", "", "" }, ECharacterAlertnessRecordType.Interact));
		_dataArray.Add(new CharacterAlertnessRecordItem(29, LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Name_29"), LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Desc_29"), new string[5] { "Integer", "", "", "", "" }, ECharacterAlertnessRecordType.Interact));
		_dataArray.Add(new CharacterAlertnessRecordItem(30, LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Name_30"), LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Desc_30"), new string[5] { "Integer", "", "", "", "" }, ECharacterAlertnessRecordType.Interact));
		_dataArray.Add(new CharacterAlertnessRecordItem(31, LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Name_31"), LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Desc_31"), new string[5] { "Integer", "", "", "", "" }, ECharacterAlertnessRecordType.Interact));
		_dataArray.Add(new CharacterAlertnessRecordItem(32, LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Name_32"), LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Desc_32"), new string[5] { "Integer", "", "", "", "" }, ECharacterAlertnessRecordType.Interact));
		_dataArray.Add(new CharacterAlertnessRecordItem(33, LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Name_33"), LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Desc_33"), new string[5] { "Integer", "", "", "", "" }, ECharacterAlertnessRecordType.Interact));
		_dataArray.Add(new CharacterAlertnessRecordItem(34, LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Name_34"), LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Desc_34"), new string[5] { "Integer", "", "", "", "" }, ECharacterAlertnessRecordType.Interact));
		_dataArray.Add(new CharacterAlertnessRecordItem(35, LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Name_35"), LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Desc_35"), new string[5] { "Integer", "", "", "", "" }, ECharacterAlertnessRecordType.Interact));
		_dataArray.Add(new CharacterAlertnessRecordItem(36, LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Name_36"), LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Desc_36"), new string[5] { "Integer", "", "", "", "" }, ECharacterAlertnessRecordType.Interact));
		_dataArray.Add(new CharacterAlertnessRecordItem(37, LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Name_37"), LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Desc_37"), new string[5] { "Resource", "Integer", "Integer", "", "" }, ECharacterAlertnessRecordType.Trade));
		_dataArray.Add(new CharacterAlertnessRecordItem(38, LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Name_38"), LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Desc_38"), new string[5] { "Item", "Integer", "", "", "" }, ECharacterAlertnessRecordType.Trade));
		_dataArray.Add(new CharacterAlertnessRecordItem(39, LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Name_39"), LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Desc_39"), new string[5] { "LifeSkill", "Integer", "", "", "" }, ECharacterAlertnessRecordType.Interact));
		_dataArray.Add(new CharacterAlertnessRecordItem(40, LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Name_40"), LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Desc_40"), new string[5] { "LifeSkill", "Integer", "", "", "" }, ECharacterAlertnessRecordType.Interact));
		_dataArray.Add(new CharacterAlertnessRecordItem(41, LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Name_41"), LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Desc_41"), new string[5] { "LifeSkill", "Integer", "", "", "" }, ECharacterAlertnessRecordType.Interact));
		_dataArray.Add(new CharacterAlertnessRecordItem(42, LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Name_42"), LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Desc_42"), new string[5] { "LifeSkill", "Integer", "", "", "" }, ECharacterAlertnessRecordType.Interact));
		_dataArray.Add(new CharacterAlertnessRecordItem(43, LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Name_43"), LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Desc_43"), new string[5] { "Item", "Integer", "", "", "" }, ECharacterAlertnessRecordType.Interact));
		_dataArray.Add(new CharacterAlertnessRecordItem(44, LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Name_44"), LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Desc_44"), new string[5] { "Resource", "Integer", "Integer", "", "" }, ECharacterAlertnessRecordType.Interact));
		_dataArray.Add(new CharacterAlertnessRecordItem(45, LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Name_45"), LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Desc_45"), new string[5] { "Information", "Integer", "", "", "" }, ECharacterAlertnessRecordType.Interact));
		_dataArray.Add(new CharacterAlertnessRecordItem(46, LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Name_46"), LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Desc_46"), new string[5] { "SecretInformation", "Integer", "", "", "" }, ECharacterAlertnessRecordType.Interact));
		_dataArray.Add(new CharacterAlertnessRecordItem(47, LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Name_47"), LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Desc_47"), new string[5] { "Item", "Integer", "", "", "" }, ECharacterAlertnessRecordType.Interact));
		_dataArray.Add(new CharacterAlertnessRecordItem(48, LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Name_48"), LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Desc_48"), new string[5] { "Resource", "Integer", "Integer", "", "" }, ECharacterAlertnessRecordType.Interact));
		_dataArray.Add(new CharacterAlertnessRecordItem(49, LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Name_49"), LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Desc_49"), new string[5] { "Item", "Integer", "", "", "" }, ECharacterAlertnessRecordType.Interact));
		_dataArray.Add(new CharacterAlertnessRecordItem(50, LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Name_50"), LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Desc_50"), new string[5] { "Resource", "Integer", "Integer", "", "" }, ECharacterAlertnessRecordType.Interact));
		_dataArray.Add(new CharacterAlertnessRecordItem(51, LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Name_51"), LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Desc_51"), new string[5] { "Integer", "", "", "", "" }, ECharacterAlertnessRecordType.Interact));
		_dataArray.Add(new CharacterAlertnessRecordItem(52, LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Name_52"), LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Desc_52"), new string[5] { "Integer", "", "", "", "" }, ECharacterAlertnessRecordType.Interact));
		_dataArray.Add(new CharacterAlertnessRecordItem(53, LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Name_53"), LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Desc_53"), new string[5] { "Integer", "", "", "", "" }, ECharacterAlertnessRecordType.Interact));
		_dataArray.Add(new CharacterAlertnessRecordItem(54, LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Name_54"), LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Desc_54"), new string[5] { "Integer", "", "", "", "" }, ECharacterAlertnessRecordType.Interact));
		_dataArray.Add(new CharacterAlertnessRecordItem(55, LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Name_55"), LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Desc_55"), new string[5] { "Integer", "", "", "", "" }, ECharacterAlertnessRecordType.Interact));
		_dataArray.Add(new CharacterAlertnessRecordItem(56, LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Name_56"), LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Desc_56"), new string[5] { "Integer", "", "", "", "" }, ECharacterAlertnessRecordType.Initial));
		_dataArray.Add(new CharacterAlertnessRecordItem(57, LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Name_57"), LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Desc_57"), new string[5] { "Integer", "", "", "", "" }, ECharacterAlertnessRecordType.Initial));
		_dataArray.Add(new CharacterAlertnessRecordItem(58, LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Name_58"), LocalStringManager.GetConfig("CharacterAlertnessRecord_language", "Desc_58"), new string[5] { "Integer", "", "", "", "" }, ECharacterAlertnessRecordType.Initial));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<CharacterAlertnessRecordItem>(59);
		CreateItems0();
	}
}
