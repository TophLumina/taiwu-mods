using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class SecretInformationSectPunish : ConfigData<SecretInformationSectPunishItem, short>
{
	public static class DefKey
	{
		public const short Die = 0;

		public const short KillInPublic = 1;

		public const short KidnapInPublic = 2;

		public const short KillForPunishment = 3;

		public const short KidnapForPunishment = 4;

		public const short UnexpectedResourceGain = 5;

		public const short UnexpectedItemGain = 6;

		public const short UnexpectedSkillBookGain = 7;

		public const short UnexpectedCure = 8;

		public const short UnexpectedResourceLose = 9;

		public const short UnexpectedItemLose = 10;

		public const short UnexpectedSkillBookLose = 11;

		public const short UnexpectedHarm = 12;

		public const short LifeSkillBattleWin = 13;

		public const short CricketBattleWin = 14;

		public const short MajorVictoryInCombat = 15;

		public const short MinorVictoryInCombat = 16;

		public const short Mourn = 17;

		public const short OfferProtection = 18;

		public const short LoseFetus = 19;

		public const short LoseFetus2 = 20;

		public const short GiveBirthToChild = 21;

		public const short GiveBirthToChild2 = 22;

		public const short AbandonChild = 23;

		public const short ReleaseKidnappedCharacter = 24;

		public const short RescueKidnappedCharacter = 25;

		public const short KidnappedCharacterEscaped = 26;

		public const short ReadBookFail = 27;

		public const short BreakoutFail = 28;

		public const short LoseOverloadingItem = 29;

		public const short SeverEnemy = 30;

		public const short BecomeEnemy = 31;

		public const short BecomeFriend = 32;

		public const short SeverFriend = 33;

		public const short BecomeLover = 34;

		public const short BreakupWithLover = 35;

		public const short BecomeHusbandAndWife = 36;

		public const short BecomeSwornBrothersAndSisters = 37;

		public const short SeverSwornBrothersAndSisters = 38;

		public const short GetAdopted = 39;

		public const short AdoptChild = 40;

		public const short GivingResource = 41;

		public const short GiveItem = 42;

		public const short BuildGrave = 43;

		public const short Cure = 44;

		public const short RepairItem = 45;

		public const short InstructOnLifeSkill = 46;

		public const short InstructOnCombatSkill = 47;

		public const short AcceptRequestHealInjury = 48;

		public const short AcceptRequestDetoxPoison = 49;

		public const short AcceptRequestIncreaseHealth = 50;

		public const short AcceptRequestRestoreDisorderOfQi = 51;

		public const short AcceptRequestIncreaseNeili = 52;

		public const short AcceptRequestKillWug = 53;

		public const short AcceptRequestFood = 54;

		public const short AcceptRequestTeaWine = 55;

		public const short AcceptRequestResource = 56;

		public const short AcceptRequestItem = 57;

		public const short AcceptRequestDrinking = 58;

		public const short AcceptRequestGivingMoney = 59;

		public const short AcceptRequestInstructionOnReading = 60;

		public const short AcceptRequestInstructionOnBreakout = 61;

		public const short AcceptRequestRepairItem = 62;

		public const short AcceptRequestAddPoisonToItem = 63;

		public const short AcceptRequestInstructionOnLifeSkill = 64;

		public const short AcceptRequestInstructionOnCombatSkill = 65;

		public const short RehaircutSuccess = 66;

		public const short RehaircutIncompleted = 67;

		public const short RehaircutFail = 68;

		public const short RefuseRequestHealInjury = 69;

		public const short RefuseRequestDetoxPoison = 70;

		public const short RefuseRequestIncreaseHealth = 71;

		public const short RefuseRequestRestoreDisorderOfQi = 72;

		public const short RefuseRequestIncreaseNeili = 73;

		public const short RefuseRequestKillWug = 74;

		public const short RefuseRequestFood = 75;

		public const short RefuseRequestTeaWine = 76;

		public const short RefuseRequestResource = 77;

		public const short RefuseRequestItem = 78;

		public const short RefuseRequestDrinking = 79;

		public const short RefuseRequestGivingMoney = 80;

		public const short RefuseRequestInstructionOnReading = 81;

		public const short RefuseRequestInstructionOnBreakout = 82;

		public const short RefuseRequestRepairItem = 83;

		public const short RefuseRequestAddPoisonToItem = 84;

		public const short RefuseRequestInstructionOnLifeSkill = 85;

		public const short RefuseRequestInstructionOnCombatSkill = 86;

		public const short RobGraveResource = 87;

		public const short StealResource = 88;

		public const short ScamResource = 89;

		public const short RobResource = 90;

		public const short RobGraveItem = 91;

		public const short StealItem = 92;

		public const short ScamItem = 93;

		public const short RobItem = 94;

		public const short KillInPrivate = 95;

		public const short KidnapInPrivate = 96;

		public const short PoisonEnemy = 97;

		public const short PlotHarmEnemy = 98;

		public const short StealLifeSkill = 99;

		public const short ScamLifeSkill = 100;

		public const short StealCombatSkill = 101;

		public const short ScamCombatSkill = 102;

		public const short AddPoisonToItem = 103;

		public const short MonkBreakRule = 104;

		public const short MakeLoveIllegal = 105;

		public const short Rape = 106;

		public const short LoseFetusFatherUnknown = 107;

		public const short GiveBirthToChildFatherUnknown = 108;

		public const short DatingWithCrush = 109;

		public const short ForcingSilence = 110;

		public const short RetrieveChild = 111;

		public const short SolveScripture1 = 112;

		public const short SolveScripture2 = 113;

		public const short SolveScripture3 = 114;

		public const short SolveScripture4 = 115;

		public const short PrisonBreak = 116;

		public const short Pregnant = 117;

		public const short PregnantWithoutFather = 118;

		public const short XiangshuType0 = 119;

		public const short XiangshuType1 = 120;

		public const short BecomeMonk = 121;

		public const short Divorce = 122;

		public const short BecomeMaster = 123;

		public const short BecomeApprentice = 124;

		public const short JoinOrganization = 125;

		public const short GainQiBook = 126;

		public const short LostQiBook = 127;

		public const short BegMoney = 128;

		public const short Imprisoned = 129;

		public const short ReleasedPrison = 130;

		public const short BegPrisoner = 131;

		public const short StealPrisoner = 132;

		public const short ScamPrisoner = 133;

		public const short RobPrisoner = 134;

		public const short SeverGetAdopted = 135;

		public const short SeverAdoptChild = 136;
	}

	public static class DefValue
	{
		public static SecretInformationSectPunishItem Die => Instance[(short)0];

		public static SecretInformationSectPunishItem KillInPublic => Instance[(short)1];

		public static SecretInformationSectPunishItem KidnapInPublic => Instance[(short)2];

		public static SecretInformationSectPunishItem KillForPunishment => Instance[(short)3];

		public static SecretInformationSectPunishItem KidnapForPunishment => Instance[(short)4];

		public static SecretInformationSectPunishItem UnexpectedResourceGain => Instance[(short)5];

		public static SecretInformationSectPunishItem UnexpectedItemGain => Instance[(short)6];

		public static SecretInformationSectPunishItem UnexpectedSkillBookGain => Instance[(short)7];

		public static SecretInformationSectPunishItem UnexpectedCure => Instance[(short)8];

		public static SecretInformationSectPunishItem UnexpectedResourceLose => Instance[(short)9];

		public static SecretInformationSectPunishItem UnexpectedItemLose => Instance[(short)10];

		public static SecretInformationSectPunishItem UnexpectedSkillBookLose => Instance[(short)11];

		public static SecretInformationSectPunishItem UnexpectedHarm => Instance[(short)12];

		public static SecretInformationSectPunishItem LifeSkillBattleWin => Instance[(short)13];

		public static SecretInformationSectPunishItem CricketBattleWin => Instance[(short)14];

		public static SecretInformationSectPunishItem MajorVictoryInCombat => Instance[(short)15];

		public static SecretInformationSectPunishItem MinorVictoryInCombat => Instance[(short)16];

		public static SecretInformationSectPunishItem Mourn => Instance[(short)17];

		public static SecretInformationSectPunishItem OfferProtection => Instance[(short)18];

		public static SecretInformationSectPunishItem LoseFetus => Instance[(short)19];

		public static SecretInformationSectPunishItem LoseFetus2 => Instance[(short)20];

		public static SecretInformationSectPunishItem GiveBirthToChild => Instance[(short)21];

		public static SecretInformationSectPunishItem GiveBirthToChild2 => Instance[(short)22];

		public static SecretInformationSectPunishItem AbandonChild => Instance[(short)23];

		public static SecretInformationSectPunishItem ReleaseKidnappedCharacter => Instance[(short)24];

		public static SecretInformationSectPunishItem RescueKidnappedCharacter => Instance[(short)25];

		public static SecretInformationSectPunishItem KidnappedCharacterEscaped => Instance[(short)26];

		public static SecretInformationSectPunishItem ReadBookFail => Instance[(short)27];

		public static SecretInformationSectPunishItem BreakoutFail => Instance[(short)28];

		public static SecretInformationSectPunishItem LoseOverloadingItem => Instance[(short)29];

		public static SecretInformationSectPunishItem SeverEnemy => Instance[(short)30];

		public static SecretInformationSectPunishItem BecomeEnemy => Instance[(short)31];

		public static SecretInformationSectPunishItem BecomeFriend => Instance[(short)32];

		public static SecretInformationSectPunishItem SeverFriend => Instance[(short)33];

		public static SecretInformationSectPunishItem BecomeLover => Instance[(short)34];

		public static SecretInformationSectPunishItem BreakupWithLover => Instance[(short)35];

		public static SecretInformationSectPunishItem BecomeHusbandAndWife => Instance[(short)36];

		public static SecretInformationSectPunishItem BecomeSwornBrothersAndSisters => Instance[(short)37];

		public static SecretInformationSectPunishItem SeverSwornBrothersAndSisters => Instance[(short)38];

		public static SecretInformationSectPunishItem GetAdopted => Instance[(short)39];

		public static SecretInformationSectPunishItem AdoptChild => Instance[(short)40];

		public static SecretInformationSectPunishItem GivingResource => Instance[(short)41];

		public static SecretInformationSectPunishItem GiveItem => Instance[(short)42];

		public static SecretInformationSectPunishItem BuildGrave => Instance[(short)43];

		public static SecretInformationSectPunishItem Cure => Instance[(short)44];

		public static SecretInformationSectPunishItem RepairItem => Instance[(short)45];

		public static SecretInformationSectPunishItem InstructOnLifeSkill => Instance[(short)46];

		public static SecretInformationSectPunishItem InstructOnCombatSkill => Instance[(short)47];

		public static SecretInformationSectPunishItem AcceptRequestHealInjury => Instance[(short)48];

		public static SecretInformationSectPunishItem AcceptRequestDetoxPoison => Instance[(short)49];

		public static SecretInformationSectPunishItem AcceptRequestIncreaseHealth => Instance[(short)50];

		public static SecretInformationSectPunishItem AcceptRequestRestoreDisorderOfQi => Instance[(short)51];

		public static SecretInformationSectPunishItem AcceptRequestIncreaseNeili => Instance[(short)52];

		public static SecretInformationSectPunishItem AcceptRequestKillWug => Instance[(short)53];

		public static SecretInformationSectPunishItem AcceptRequestFood => Instance[(short)54];

		public static SecretInformationSectPunishItem AcceptRequestTeaWine => Instance[(short)55];

		public static SecretInformationSectPunishItem AcceptRequestResource => Instance[(short)56];

		public static SecretInformationSectPunishItem AcceptRequestItem => Instance[(short)57];

		public static SecretInformationSectPunishItem AcceptRequestDrinking => Instance[(short)58];

		public static SecretInformationSectPunishItem AcceptRequestGivingMoney => Instance[(short)59];

		public static SecretInformationSectPunishItem AcceptRequestInstructionOnReading => Instance[(short)60];

		public static SecretInformationSectPunishItem AcceptRequestInstructionOnBreakout => Instance[(short)61];

		public static SecretInformationSectPunishItem AcceptRequestRepairItem => Instance[(short)62];

		public static SecretInformationSectPunishItem AcceptRequestAddPoisonToItem => Instance[(short)63];

		public static SecretInformationSectPunishItem AcceptRequestInstructionOnLifeSkill => Instance[(short)64];

		public static SecretInformationSectPunishItem AcceptRequestInstructionOnCombatSkill => Instance[(short)65];

		public static SecretInformationSectPunishItem RehaircutSuccess => Instance[(short)66];

		public static SecretInformationSectPunishItem RehaircutIncompleted => Instance[(short)67];

		public static SecretInformationSectPunishItem RehaircutFail => Instance[(short)68];

		public static SecretInformationSectPunishItem RefuseRequestHealInjury => Instance[(short)69];

		public static SecretInformationSectPunishItem RefuseRequestDetoxPoison => Instance[(short)70];

		public static SecretInformationSectPunishItem RefuseRequestIncreaseHealth => Instance[(short)71];

		public static SecretInformationSectPunishItem RefuseRequestRestoreDisorderOfQi => Instance[(short)72];

		public static SecretInformationSectPunishItem RefuseRequestIncreaseNeili => Instance[(short)73];

		public static SecretInformationSectPunishItem RefuseRequestKillWug => Instance[(short)74];

		public static SecretInformationSectPunishItem RefuseRequestFood => Instance[(short)75];

		public static SecretInformationSectPunishItem RefuseRequestTeaWine => Instance[(short)76];

		public static SecretInformationSectPunishItem RefuseRequestResource => Instance[(short)77];

		public static SecretInformationSectPunishItem RefuseRequestItem => Instance[(short)78];

		public static SecretInformationSectPunishItem RefuseRequestDrinking => Instance[(short)79];

		public static SecretInformationSectPunishItem RefuseRequestGivingMoney => Instance[(short)80];

		public static SecretInformationSectPunishItem RefuseRequestInstructionOnReading => Instance[(short)81];

		public static SecretInformationSectPunishItem RefuseRequestInstructionOnBreakout => Instance[(short)82];

		public static SecretInformationSectPunishItem RefuseRequestRepairItem => Instance[(short)83];

		public static SecretInformationSectPunishItem RefuseRequestAddPoisonToItem => Instance[(short)84];

		public static SecretInformationSectPunishItem RefuseRequestInstructionOnLifeSkill => Instance[(short)85];

		public static SecretInformationSectPunishItem RefuseRequestInstructionOnCombatSkill => Instance[(short)86];

		public static SecretInformationSectPunishItem RobGraveResource => Instance[(short)87];

		public static SecretInformationSectPunishItem StealResource => Instance[(short)88];

		public static SecretInformationSectPunishItem ScamResource => Instance[(short)89];

		public static SecretInformationSectPunishItem RobResource => Instance[(short)90];

		public static SecretInformationSectPunishItem RobGraveItem => Instance[(short)91];

		public static SecretInformationSectPunishItem StealItem => Instance[(short)92];

		public static SecretInformationSectPunishItem ScamItem => Instance[(short)93];

		public static SecretInformationSectPunishItem RobItem => Instance[(short)94];

		public static SecretInformationSectPunishItem KillInPrivate => Instance[(short)95];

		public static SecretInformationSectPunishItem KidnapInPrivate => Instance[(short)96];

		public static SecretInformationSectPunishItem PoisonEnemy => Instance[(short)97];

		public static SecretInformationSectPunishItem PlotHarmEnemy => Instance[(short)98];

		public static SecretInformationSectPunishItem StealLifeSkill => Instance[(short)99];

		public static SecretInformationSectPunishItem ScamLifeSkill => Instance[(short)100];

		public static SecretInformationSectPunishItem StealCombatSkill => Instance[(short)101];

		public static SecretInformationSectPunishItem ScamCombatSkill => Instance[(short)102];

		public static SecretInformationSectPunishItem AddPoisonToItem => Instance[(short)103];

		public static SecretInformationSectPunishItem MonkBreakRule => Instance[(short)104];

		public static SecretInformationSectPunishItem MakeLoveIllegal => Instance[(short)105];

		public static SecretInformationSectPunishItem Rape => Instance[(short)106];

		public static SecretInformationSectPunishItem LoseFetusFatherUnknown => Instance[(short)107];

		public static SecretInformationSectPunishItem GiveBirthToChildFatherUnknown => Instance[(short)108];

		public static SecretInformationSectPunishItem DatingWithCrush => Instance[(short)109];

		public static SecretInformationSectPunishItem ForcingSilence => Instance[(short)110];

		public static SecretInformationSectPunishItem RetrieveChild => Instance[(short)111];

		public static SecretInformationSectPunishItem SolveScripture1 => Instance[(short)112];

		public static SecretInformationSectPunishItem SolveScripture2 => Instance[(short)113];

		public static SecretInformationSectPunishItem SolveScripture3 => Instance[(short)114];

		public static SecretInformationSectPunishItem SolveScripture4 => Instance[(short)115];

		public static SecretInformationSectPunishItem PrisonBreak => Instance[(short)116];

		public static SecretInformationSectPunishItem Pregnant => Instance[(short)117];

		public static SecretInformationSectPunishItem PregnantWithoutFather => Instance[(short)118];

		public static SecretInformationSectPunishItem XiangshuType0 => Instance[(short)119];

		public static SecretInformationSectPunishItem XiangshuType1 => Instance[(short)120];

		public static SecretInformationSectPunishItem BecomeMonk => Instance[(short)121];

		public static SecretInformationSectPunishItem Divorce => Instance[(short)122];

		public static SecretInformationSectPunishItem BecomeMaster => Instance[(short)123];

		public static SecretInformationSectPunishItem BecomeApprentice => Instance[(short)124];

		public static SecretInformationSectPunishItem JoinOrganization => Instance[(short)125];

		public static SecretInformationSectPunishItem GainQiBook => Instance[(short)126];

		public static SecretInformationSectPunishItem LostQiBook => Instance[(short)127];

		public static SecretInformationSectPunishItem BegMoney => Instance[(short)128];

		public static SecretInformationSectPunishItem Imprisoned => Instance[(short)129];

		public static SecretInformationSectPunishItem ReleasedPrison => Instance[(short)130];

		public static SecretInformationSectPunishItem BegPrisoner => Instance[(short)131];

		public static SecretInformationSectPunishItem StealPrisoner => Instance[(short)132];

		public static SecretInformationSectPunishItem ScamPrisoner => Instance[(short)133];

		public static SecretInformationSectPunishItem RobPrisoner => Instance[(short)134];

		public static SecretInformationSectPunishItem SeverGetAdopted => Instance[(short)135];

		public static SecretInformationSectPunishItem SeverAdoptChild => Instance[(short)136];
	}

	public static SecretInformationSectPunish Instance = new SecretInformationSectPunish();

	private readonly HashSet<string> RequiredFields = new HashSet<string>
	{
		"ActorSectPunishFreeCondition", "ActorSectPunishCondition", "ActorSectPunishBase", "ActorSectPunishSpecialCondition", "ActorSectPunishSpecial", "ReactorSectPunishFreeCondition", "ReactorSectPunishCondition", "ReactorSectPunishBase", "ReactorSectPunishSpecialCondition", "ReactorSectPunishSpecial",
		"SecactorSectPunishFreeCondition", "SecactorSectPunishCondition", "SecactorSectPunishBase", "SecactorSectPunishSpecialCondition", "SecactorSectPunishSpecial", "ActorCityPunishFreeCondition", "ActorCityPunishCondition", "ActorCityPunishBase", "ActorCityPunishSpecialCondition", "ActorCityPunishSpecial",
		"ReactorCityPunishFreeCondition", "ReactorCityPunishCondition", "ReactorCityPunishBase", "ReactorCityPunishSpecialCondition", "ReactorCityPunishSpecial", "SecactorCityPunishFreeCondition", "SecactorCityPunishCondition", "SecactorCityPunishBase", "SecactorCityPunishSpecialCondition", "SecactorCityPunishSpecial",
		"ActorTaiwuPunishFreeCondition", "ActorTaiwuPunishCondition", "ActorTaiwuPunishBase", "ActorTaiwuPunishSpecialCondition", "ActorTaiwuPunishSpecial", "ReactorTaiwuPunishFreeCondition", "ReactorTaiwuPunishCondition", "ReactorTaiwuPunishBase", "ReactorTaiwuPunishSpecialCondition", "ReactorTaiwuPunishSpecial",
		"SecactorTaiwuPunishFreeCondition", "SecactorTaiwuPunishCondition", "SecactorTaiwuPunishBase", "SecactorTaiwuPunishSpecialCondition", "SecactorTaiwuPunishSpecial", "TemplateId"
	};

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
		_dataArray.Add(new SecretInformationSectPunishItem(0, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(1, new List<ShortList>
		{
			new ShortList(2, 0, 1)
		}, new List<ShortList>
		{
			new ShortList(56, 1),
			new ShortList(57, 1),
			new ShortList(58, 1)
		}, new List<ShortList>
		{
			new ShortList(1),
			new ShortList(2),
			new ShortList(3)
		}, new List<ShortList>
		{
			new ShortList(1, 0, 1)
		}, new List<ShortList>
		{
			new ShortList(154)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(56, 1),
			new ShortList(57, 1),
			new ShortList(58, 1)
		}, new List<ShortList>
		{
			new ShortList(1),
			new ShortList(2),
			new ShortList(3)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(56, 1),
			new ShortList(57, 1),
			new ShortList(58, 1)
		}, new List<ShortList>
		{
			new ShortList(1),
			new ShortList(2),
			new ShortList(3)
		}, new List<ShortList>
		{
			new ShortList(55, 1)
		}, new List<ShortList>
		{
			new ShortList(1),
			new ShortList(2),
			new ShortList(3)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(2, new List<ShortList>
		{
			new ShortList(2, 0, 1)
		}, new List<ShortList>
		{
			new ShortList(59, 1),
			new ShortList(60, 1),
			new ShortList(61, 1)
		}, new List<ShortList>
		{
			new ShortList(4),
			new ShortList(5),
			new ShortList(6)
		}, new List<ShortList>
		{
			new ShortList(1, 0, 1)
		}, new List<ShortList>
		{
			new ShortList(155)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(59, 1),
			new ShortList(60, 1),
			new ShortList(61, 1)
		}, new List<ShortList>
		{
			new ShortList(4),
			new ShortList(5),
			new ShortList(6)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(59, 1),
			new ShortList(60, 1),
			new ShortList(61, 1)
		}, new List<ShortList>
		{
			new ShortList(4),
			new ShortList(5),
			new ShortList(6)
		}, new List<ShortList>
		{
			new ShortList(55, 1)
		}, new List<ShortList>
		{
			new ShortList(4),
			new ShortList(5),
			new ShortList(6)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(3, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(4, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(5, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(6, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(7, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(8, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(9, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(10, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(11, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(12, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(13, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(14, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(15, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(16, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(17, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(18, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(19, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(77, 0),
			new ShortList(78, 0),
			new ShortList(79, 0)
		}, new List<ShortList>
		{
			new ShortList(44),
			new ShortList(45),
			new ShortList(46)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(77, 0),
			new ShortList(78, 0),
			new ShortList(79, 0)
		}, new List<ShortList>
		{
			new ShortList(44),
			new ShortList(45),
			new ShortList(46)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(20, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(77, 0),
			new ShortList(78, 0),
			new ShortList(79, 0)
		}, new List<ShortList>
		{
			new ShortList(44),
			new ShortList(45),
			new ShortList(46)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(77, 1),
			new ShortList(78, 1),
			new ShortList(79, 1)
		}, new List<ShortList>
		{
			new ShortList(44),
			new ShortList(45),
			new ShortList(46)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(77, 0),
			new ShortList(78, 0),
			new ShortList(79, 0)
		}, new List<ShortList>
		{
			new ShortList(44),
			new ShortList(45),
			new ShortList(46)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(77, 0),
			new ShortList(78, 0),
			new ShortList(79, 0)
		}, new List<ShortList>
		{
			new ShortList(44),
			new ShortList(45),
			new ShortList(46)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(21, new List<ShortList>
		{
			new ShortList(5)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(77, 0),
			new ShortList(78, 0),
			new ShortList(79, 0)
		}, new List<ShortList>
		{
			new ShortList(44),
			new ShortList(45),
			new ShortList(46)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(77, 0),
			new ShortList(78, 0),
			new ShortList(79, 0)
		}, new List<ShortList>
		{
			new ShortList(44),
			new ShortList(45),
			new ShortList(46)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(22, new List<ShortList>
		{
			new ShortList(5)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(77, 0),
			new ShortList(78, 0),
			new ShortList(79, 0)
		}, new List<ShortList>
		{
			new ShortList(44),
			new ShortList(45),
			new ShortList(46)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(5)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(77, 2),
			new ShortList(78, 2),
			new ShortList(79, 2)
		}, new List<ShortList>
		{
			new ShortList(44),
			new ShortList(45),
			new ShortList(46)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(77, 0),
			new ShortList(78, 0),
			new ShortList(79, 0)
		}, new List<ShortList>
		{
			new ShortList(44),
			new ShortList(45),
			new ShortList(46)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(77, 0),
			new ShortList(78, 0),
			new ShortList(79, 0)
		}, new List<ShortList>
		{
			new ShortList(44),
			new ShortList(45),
			new ShortList(46)
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(23, new List<ShortList>
		{
			new ShortList(5)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(77, 0),
			new ShortList(78, 0),
			new ShortList(79, 0)
		}, new List<ShortList>
		{
			new ShortList(44),
			new ShortList(45),
			new ShortList(46)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(77, 0),
			new ShortList(78, 0),
			new ShortList(79, 0)
		}, new List<ShortList>
		{
			new ShortList(44),
			new ShortList(45),
			new ShortList(46)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(24, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(25, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(26, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(27, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(28, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(29, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(30, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(31, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(32, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(62, 1),
			new ShortList(63, 1),
			new ShortList(64, 1),
			new ShortList(65, 1),
			new ShortList(66, 1),
			new ShortList(67, 1),
			new ShortList(68, 1),
			new ShortList(69, 1),
			new ShortList(70, 1),
			new ShortList(71, 1),
			new ShortList(72, 1),
			new ShortList(73, 1),
			new ShortList(74, 1),
			new ShortList(75, 1),
			new ShortList(76, 1)
		}, new List<ShortList>
		{
			new ShortList(24),
			new ShortList(25),
			new ShortList(26),
			new ShortList(27),
			new ShortList(28),
			new ShortList(29),
			new ShortList(30),
			new ShortList(31),
			new ShortList(32),
			new ShortList(33),
			new ShortList(34),
			new ShortList(35),
			new ShortList(36),
			new ShortList(37),
			new ShortList(38)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(62, 0),
			new ShortList(63, 0),
			new ShortList(64, 0),
			new ShortList(65, 0),
			new ShortList(66, 0),
			new ShortList(67, 0),
			new ShortList(68, 0),
			new ShortList(69, 0),
			new ShortList(70, 1),
			new ShortList(71, 1),
			new ShortList(72, 1),
			new ShortList(73, 1),
			new ShortList(74, 1),
			new ShortList(75, 1),
			new ShortList(76, 1)
		}, new List<ShortList>
		{
			new ShortList(24),
			new ShortList(25),
			new ShortList(26),
			new ShortList(27),
			new ShortList(28),
			new ShortList(29),
			new ShortList(30),
			new ShortList(31),
			new ShortList(32),
			new ShortList(33),
			new ShortList(34),
			new ShortList(35),
			new ShortList(36),
			new ShortList(37),
			new ShortList(38)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(33, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(34, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(80, 0),
			new ShortList(81, 0),
			new ShortList(82, 0),
			new ShortList(95, 1),
			new ShortList(96, 1),
			new ShortList(97, 1),
			new ShortList(98, 1),
			new ShortList(99, 1),
			new ShortList(100, 1),
			new ShortList(101, 1),
			new ShortList(102, 1),
			new ShortList(103, 1),
			new ShortList(104, 1),
			new ShortList(105, 1),
			new ShortList(106, 1),
			new ShortList(107, 1),
			new ShortList(108, 1),
			new ShortList(109, 1)
		}, new List<ShortList>
		{
			new ShortList(47),
			new ShortList(48),
			new ShortList(49),
			new ShortList(64),
			new ShortList(65),
			new ShortList(66),
			new ShortList(67),
			new ShortList(68),
			new ShortList(69),
			new ShortList(70),
			new ShortList(71),
			new ShortList(72),
			new ShortList(73),
			new ShortList(74),
			new ShortList(75),
			new ShortList(76),
			new ShortList(77),
			new ShortList(78)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(80, 1),
			new ShortList(81, 1),
			new ShortList(82, 1),
			new ShortList(95, 0),
			new ShortList(96, 0),
			new ShortList(97, 0),
			new ShortList(98, 0),
			new ShortList(99, 0),
			new ShortList(100, 0),
			new ShortList(101, 0),
			new ShortList(102, 0),
			new ShortList(103, 0),
			new ShortList(104, 0),
			new ShortList(105, 0),
			new ShortList(106, 0),
			new ShortList(107, 0),
			new ShortList(108, 0),
			new ShortList(109, 0)
		}, new List<ShortList>
		{
			new ShortList(47),
			new ShortList(48),
			new ShortList(49),
			new ShortList(64),
			new ShortList(65),
			new ShortList(66),
			new ShortList(67),
			new ShortList(68),
			new ShortList(69),
			new ShortList(70),
			new ShortList(71),
			new ShortList(72),
			new ShortList(73),
			new ShortList(74),
			new ShortList(75),
			new ShortList(76),
			new ShortList(77),
			new ShortList(78)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(80, 0),
			new ShortList(81, 0),
			new ShortList(82, 0),
			new ShortList(95, 1),
			new ShortList(96, 1),
			new ShortList(97, 1),
			new ShortList(98, 1),
			new ShortList(99, 1),
			new ShortList(100, 1),
			new ShortList(101, 1),
			new ShortList(102, 1),
			new ShortList(103, 1),
			new ShortList(104, 1),
			new ShortList(105, 1),
			new ShortList(106, 1),
			new ShortList(107, 1),
			new ShortList(108, 1),
			new ShortList(109, 1)
		}, new List<ShortList>
		{
			new ShortList(47),
			new ShortList(48),
			new ShortList(49),
			new ShortList(64),
			new ShortList(65),
			new ShortList(66),
			new ShortList(67),
			new ShortList(68),
			new ShortList(69),
			new ShortList(70),
			new ShortList(71),
			new ShortList(72),
			new ShortList(73),
			new ShortList(74),
			new ShortList(75),
			new ShortList(76),
			new ShortList(77),
			new ShortList(78)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(80, 0),
			new ShortList(81, 0),
			new ShortList(82, 0),
			new ShortList(95, 1),
			new ShortList(96, 1),
			new ShortList(97, 1),
			new ShortList(98, 1),
			new ShortList(99, 1),
			new ShortList(100, 1),
			new ShortList(101, 1),
			new ShortList(102, 1),
			new ShortList(103, 1),
			new ShortList(104, 1),
			new ShortList(105, 1),
			new ShortList(106, 1),
			new ShortList(107, 1),
			new ShortList(108, 1),
			new ShortList(109, 1)
		}, new List<ShortList>
		{
			new ShortList(47),
			new ShortList(48),
			new ShortList(49),
			new ShortList(64),
			new ShortList(65),
			new ShortList(66),
			new ShortList(67),
			new ShortList(68),
			new ShortList(69),
			new ShortList(70),
			new ShortList(71),
			new ShortList(72),
			new ShortList(73),
			new ShortList(74),
			new ShortList(75),
			new ShortList(76),
			new ShortList(77),
			new ShortList(78)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(35, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(36, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(83, 0),
			new ShortList(84, 0),
			new ShortList(85, 0)
		}, new List<ShortList>
		{
			new ShortList(50),
			new ShortList(51),
			new ShortList(52)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(83, 1),
			new ShortList(84, 1),
			new ShortList(85, 1)
		}, new List<ShortList>
		{
			new ShortList(50),
			new ShortList(51),
			new ShortList(52)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(110, 1),
			new ShortList(111, 1),
			new ShortList(112, 1),
			new ShortList(113, 1),
			new ShortList(114, 1),
			new ShortList(115, 1),
			new ShortList(116, 1),
			new ShortList(117, 1),
			new ShortList(118, 1),
			new ShortList(119, 1),
			new ShortList(120, 1),
			new ShortList(121, 1),
			new ShortList(122, 1),
			new ShortList(123, 1),
			new ShortList(124, 1)
		}, new List<ShortList>
		{
			new ShortList(79),
			new ShortList(80),
			new ShortList(81),
			new ShortList(82),
			new ShortList(83),
			new ShortList(84),
			new ShortList(85),
			new ShortList(86),
			new ShortList(87),
			new ShortList(88),
			new ShortList(89),
			new ShortList(90),
			new ShortList(91),
			new ShortList(92),
			new ShortList(93)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(110, 1),
			new ShortList(111, 1),
			new ShortList(112, 1),
			new ShortList(113, 1),
			new ShortList(114, 1),
			new ShortList(115, 1),
			new ShortList(116, 1),
			new ShortList(117, 1),
			new ShortList(118, 1),
			new ShortList(119, 1),
			new ShortList(120, 1),
			new ShortList(121, 1),
			new ShortList(122, 1),
			new ShortList(123, 1),
			new ShortList(124, 1)
		}, new List<ShortList>
		{
			new ShortList(79),
			new ShortList(80),
			new ShortList(81),
			new ShortList(82),
			new ShortList(83),
			new ShortList(84),
			new ShortList(85),
			new ShortList(86),
			new ShortList(87),
			new ShortList(88),
			new ShortList(89),
			new ShortList(90),
			new ShortList(91),
			new ShortList(92),
			new ShortList(93)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(37, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(110, 1),
			new ShortList(111, 1),
			new ShortList(112, 1),
			new ShortList(113, 1),
			new ShortList(114, 1),
			new ShortList(115, 1),
			new ShortList(116, 1),
			new ShortList(117, 1),
			new ShortList(118, 1),
			new ShortList(119, 1),
			new ShortList(120, 1),
			new ShortList(121, 1),
			new ShortList(122, 1),
			new ShortList(123, 1),
			new ShortList(124, 1)
		}, new List<ShortList>
		{
			new ShortList(79),
			new ShortList(80),
			new ShortList(81),
			new ShortList(82),
			new ShortList(83),
			new ShortList(84),
			new ShortList(85),
			new ShortList(86),
			new ShortList(87),
			new ShortList(88),
			new ShortList(89),
			new ShortList(90),
			new ShortList(91),
			new ShortList(92),
			new ShortList(93)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(110, 0),
			new ShortList(111, 0),
			new ShortList(112, 0),
			new ShortList(113, 0),
			new ShortList(114, 0),
			new ShortList(115, 0),
			new ShortList(116, 0),
			new ShortList(117, 0),
			new ShortList(118, 1),
			new ShortList(119, 1),
			new ShortList(120, 1),
			new ShortList(121, 1),
			new ShortList(122, 1),
			new ShortList(123, 1),
			new ShortList(124, 1)
		}, new List<ShortList>
		{
			new ShortList(79),
			new ShortList(80),
			new ShortList(81),
			new ShortList(82),
			new ShortList(83),
			new ShortList(84),
			new ShortList(85),
			new ShortList(86),
			new ShortList(87),
			new ShortList(88),
			new ShortList(89),
			new ShortList(90),
			new ShortList(91),
			new ShortList(92),
			new ShortList(93)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(38, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(39, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(125, 1),
			new ShortList(126, 1),
			new ShortList(127, 1),
			new ShortList(128, 1),
			new ShortList(129, 1),
			new ShortList(130, 1),
			new ShortList(131, 1),
			new ShortList(132, 1),
			new ShortList(133, 1),
			new ShortList(134, 1),
			new ShortList(135, 1),
			new ShortList(136, 1),
			new ShortList(137, 1),
			new ShortList(138, 1),
			new ShortList(139, 1)
		}, new List<ShortList>
		{
			new ShortList(94),
			new ShortList(95),
			new ShortList(96),
			new ShortList(97),
			new ShortList(98),
			new ShortList(99),
			new ShortList(100),
			new ShortList(101),
			new ShortList(102),
			new ShortList(103),
			new ShortList(104),
			new ShortList(105),
			new ShortList(106),
			new ShortList(107),
			new ShortList(108)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(40, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(140, 1),
			new ShortList(141, 1),
			new ShortList(142, 1),
			new ShortList(143, 1),
			new ShortList(144, 1),
			new ShortList(145, 1),
			new ShortList(146, 1),
			new ShortList(147, 1),
			new ShortList(148, 1),
			new ShortList(149, 1),
			new ShortList(150, 1),
			new ShortList(151, 1),
			new ShortList(152, 1),
			new ShortList(153, 1),
			new ShortList(154, 1)
		}, new List<ShortList>
		{
			new ShortList(109),
			new ShortList(110),
			new ShortList(111),
			new ShortList(112),
			new ShortList(113),
			new ShortList(114),
			new ShortList(115),
			new ShortList(116),
			new ShortList(117),
			new ShortList(118),
			new ShortList(119),
			new ShortList(120),
			new ShortList(121),
			new ShortList(122),
			new ShortList(123)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(41, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(42, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(43, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(44, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(45, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(46, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(47, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(48, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(49, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(50, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(51, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(52, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(53, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(54, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(55, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(56, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(57, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(58, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(59, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new SecretInformationSectPunishItem(60, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(61, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(62, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(63, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(64, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(65, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(66, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(67, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(68, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(69, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(70, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(71, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(72, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(73, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(74, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(75, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(76, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(77, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(78, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(79, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(80, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(81, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(82, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(83, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(84, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(85, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(86, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(87, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(10)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(10)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(10)
		}, new List<ShortList>
		{
			new ShortList(55, 1)
		}, new List<ShortList>
		{
			new ShortList(10)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(88, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(11)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(11)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(11)
		}, new List<ShortList>
		{
			new ShortList(55, 1)
		}, new List<ShortList>
		{
			new ShortList(11)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(89, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(12)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(12)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(12)
		}, new List<ShortList>
		{
			new ShortList(55, 1)
		}, new List<ShortList>
		{
			new ShortList(12)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(90, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(13)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(13)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(13)
		}, new List<ShortList>
		{
			new ShortList(55, 1)
		}, new List<ShortList>
		{
			new ShortList(13)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(91, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(10)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(10)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(10)
		}, new List<ShortList>
		{
			new ShortList(55, 1)
		}, new List<ShortList>
		{
			new ShortList(10)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(92, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(11)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(11)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(11)
		}, new List<ShortList>
		{
			new ShortList(55, 1)
		}, new List<ShortList>
		{
			new ShortList(11)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(93, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(12)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(12)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(12)
		}, new List<ShortList>
		{
			new ShortList(55, 1)
		}, new List<ShortList>
		{
			new ShortList(12)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(94, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(13)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(13)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(13)
		}, new List<ShortList>
		{
			new ShortList(55, 1)
		}, new List<ShortList>
		{
			new ShortList(13)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(95, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(22)
		}, new List<ShortList>
		{
			new ShortList(1, 0, 1)
		}, new List<ShortList>
		{
			new ShortList(156)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(22)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(22)
		}, new List<ShortList>
		{
			new ShortList(55, 1)
		}, new List<ShortList>
		{
			new ShortList(22)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(96, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(23)
		}, new List<ShortList>
		{
			new ShortList(1, 0, 1)
		}, new List<ShortList>
		{
			new ShortList(157)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(23)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(23)
		}, new List<ShortList>
		{
			new ShortList(55, 1)
		}, new List<ShortList>
		{
			new ShortList(23)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(97, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(14)
		}, new List<ShortList>
		{
			new ShortList(1, 0, 1)
		}, new List<ShortList>
		{
			new ShortList(16)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(14)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(14)
		}, new List<ShortList>
		{
			new ShortList(55, 1)
		}, new List<ShortList>
		{
			new ShortList(14)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(98, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(15)
		}, new List<ShortList>
		{
			new ShortList(1, 0, 1)
		}, new List<ShortList>
		{
			new ShortList(17)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(15)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(15)
		}, new List<ShortList>
		{
			new ShortList(55, 1)
		}, new List<ShortList>
		{
			new ShortList(15)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(99, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(158)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(158)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(158)
		}, new List<ShortList>
		{
			new ShortList(55, 1)
		}, new List<ShortList>
		{
			new ShortList(158)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(100, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(159)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(159)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(159)
		}, new List<ShortList>
		{
			new ShortList(55, 1)
		}, new List<ShortList>
		{
			new ShortList(159)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(101, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(160)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(160)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(160)
		}, new List<ShortList>
		{
			new ShortList(55, 1)
		}, new List<ShortList>
		{
			new ShortList(160)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(102, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(161)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(161)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(161)
		}, new List<ShortList>
		{
			new ShortList(55, 1)
		}, new List<ShortList>
		{
			new ShortList(161)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(103, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(19)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(104, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(185, 1),
			new ShortList(186, 1),
			new ShortList(187, 1)
		}, new List<ShortList>
		{
			new ShortList(162),
			new ShortList(163),
			new ShortList(164)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(105, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(62)
		}, new List<ShortList>
		{
			new ShortList(86, 0),
			new ShortList(87, 0),
			new ShortList(88, 0)
		}, new List<ShortList>
		{
			new ShortList(53),
			new ShortList(54),
			new ShortList(55)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(62)
		}, new List<ShortList>
		{
			new ShortList(86, 1),
			new ShortList(87, 1),
			new ShortList(88, 1)
		}, new List<ShortList>
		{
			new ShortList(53),
			new ShortList(54),
			new ShortList(55)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(86, 0),
			new ShortList(87, 0),
			new ShortList(88, 0)
		}, new List<ShortList>
		{
			new ShortList(53),
			new ShortList(54),
			new ShortList(55)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(86, 0),
			new ShortList(87, 0),
			new ShortList(88, 0)
		}, new List<ShortList>
		{
			new ShortList(53),
			new ShortList(54),
			new ShortList(55)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(106, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(63)
		}, new List<ShortList>
		{
			new ShortList(89, 0),
			new ShortList(90, 0),
			new ShortList(91, 0)
		}, new List<ShortList>
		{
			new ShortList(56),
			new ShortList(57),
			new ShortList(58)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(63)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(63)
		}, new List<ShortList>
		{
			new ShortList(89, 0),
			new ShortList(90, 0),
			new ShortList(91, 0)
		}, new List<ShortList>
		{
			new ShortList(56),
			new ShortList(57),
			new ShortList(58)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(107, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(77, 0),
			new ShortList(78, 0),
			new ShortList(79, 0)
		}, new List<ShortList>
		{
			new ShortList(44),
			new ShortList(45),
			new ShortList(46)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(108, new List<ShortList>
		{
			new ShortList(5)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(77, 0),
			new ShortList(78, 0),
			new ShortList(79, 0)
		}, new List<ShortList>
		{
			new ShortList(44),
			new ShortList(45),
			new ShortList(46)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(109, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(92, 0),
			new ShortList(93, 0),
			new ShortList(94, 0),
			new ShortList(155, 1),
			new ShortList(156, 1),
			new ShortList(157, 1),
			new ShortList(158, 1),
			new ShortList(159, 1),
			new ShortList(160, 1),
			new ShortList(161, 1),
			new ShortList(162, 1),
			new ShortList(163, 1),
			new ShortList(164, 1),
			new ShortList(165, 1),
			new ShortList(166, 1),
			new ShortList(167, 1),
			new ShortList(168, 1),
			new ShortList(169, 1)
		}, new List<ShortList>
		{
			new ShortList(59),
			new ShortList(60),
			new ShortList(61),
			new ShortList(124),
			new ShortList(125),
			new ShortList(126),
			new ShortList(127),
			new ShortList(128),
			new ShortList(129),
			new ShortList(130),
			new ShortList(131),
			new ShortList(132),
			new ShortList(133),
			new ShortList(134),
			new ShortList(135),
			new ShortList(136),
			new ShortList(137),
			new ShortList(138)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(92, 1),
			new ShortList(93, 1),
			new ShortList(94, 1),
			new ShortList(155, 0),
			new ShortList(156, 0),
			new ShortList(157, 0),
			new ShortList(158, 0),
			new ShortList(159, 0),
			new ShortList(160, 0),
			new ShortList(161, 0),
			new ShortList(162, 0),
			new ShortList(163, 0),
			new ShortList(164, 0),
			new ShortList(165, 0),
			new ShortList(166, 0),
			new ShortList(167, 0),
			new ShortList(168, 0),
			new ShortList(169, 0)
		}, new List<ShortList>
		{
			new ShortList(59),
			new ShortList(60),
			new ShortList(61),
			new ShortList(124),
			new ShortList(125),
			new ShortList(126),
			new ShortList(127),
			new ShortList(128),
			new ShortList(129),
			new ShortList(130),
			new ShortList(131),
			new ShortList(132),
			new ShortList(133),
			new ShortList(134),
			new ShortList(135),
			new ShortList(136),
			new ShortList(137),
			new ShortList(138)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(92, 0),
			new ShortList(93, 0),
			new ShortList(94, 0),
			new ShortList(155, 1),
			new ShortList(156, 1),
			new ShortList(157, 1),
			new ShortList(158, 1),
			new ShortList(159, 1),
			new ShortList(160, 1),
			new ShortList(161, 1),
			new ShortList(162, 1),
			new ShortList(163, 1),
			new ShortList(164, 1),
			new ShortList(165, 1),
			new ShortList(166, 1),
			new ShortList(167, 1),
			new ShortList(168, 1),
			new ShortList(169, 1)
		}, new List<ShortList>
		{
			new ShortList(59),
			new ShortList(60),
			new ShortList(61),
			new ShortList(124),
			new ShortList(125),
			new ShortList(126),
			new ShortList(127),
			new ShortList(128),
			new ShortList(129),
			new ShortList(130),
			new ShortList(131),
			new ShortList(132),
			new ShortList(133),
			new ShortList(134),
			new ShortList(135),
			new ShortList(136),
			new ShortList(137),
			new ShortList(138)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(92, 0),
			new ShortList(93, 0),
			new ShortList(94, 0),
			new ShortList(155, 1),
			new ShortList(156, 1),
			new ShortList(157, 1),
			new ShortList(158, 1),
			new ShortList(159, 1),
			new ShortList(160, 1),
			new ShortList(161, 1),
			new ShortList(162, 1),
			new ShortList(163, 1),
			new ShortList(164, 1),
			new ShortList(165, 1),
			new ShortList(166, 1),
			new ShortList(167, 1),
			new ShortList(168, 1),
			new ShortList(169, 1)
		}, new List<ShortList>
		{
			new ShortList(59),
			new ShortList(60),
			new ShortList(61),
			new ShortList(124),
			new ShortList(125),
			new ShortList(126),
			new ShortList(127),
			new ShortList(128),
			new ShortList(129),
			new ShortList(130),
			new ShortList(131),
			new ShortList(132),
			new ShortList(133),
			new ShortList(134),
			new ShortList(135),
			new ShortList(136),
			new ShortList(137),
			new ShortList(138)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(110, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(39)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(39)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(39)
		}, new List<ShortList>
		{
			new ShortList(55, 1)
		}, new List<ShortList>
		{
			new ShortList(39)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(111, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(170, 1),
			new ShortList(171, 1),
			new ShortList(172, 1),
			new ShortList(173, 1),
			new ShortList(174, 1),
			new ShortList(175, 1),
			new ShortList(176, 1),
			new ShortList(177, 1),
			new ShortList(178, 1),
			new ShortList(179, 1),
			new ShortList(180, 1),
			new ShortList(181, 1),
			new ShortList(182, 1),
			new ShortList(183, 1),
			new ShortList(184, 1)
		}, new List<ShortList>
		{
			new ShortList(139),
			new ShortList(140),
			new ShortList(141),
			new ShortList(142),
			new ShortList(143),
			new ShortList(144),
			new ShortList(145),
			new ShortList(146),
			new ShortList(147),
			new ShortList(148),
			new ShortList(149),
			new ShortList(150),
			new ShortList(151),
			new ShortList(152),
			new ShortList(153)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(112, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(113, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(114, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(115, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(116, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(41)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(41)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(41)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(117, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(118, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(119, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
	}

	private void CreateItems2()
	{
		_dataArray.Add(new SecretInformationSectPunishItem(120, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(121, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(122, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(123, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(124, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(125, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(126, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(127, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(128, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(129, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(130, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(131, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(132, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(133, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(134, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(135, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(136, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<SecretInformationSectPunishItem>(137);
		CreateItems0();
		CreateItems1();
		CreateItems2();
	}
}
