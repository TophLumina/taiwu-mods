using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class MonthlyNotification : ConfigData<MonthlyNotificationItem, short>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// SolarTerm0
		/// </summary>
		public const short SolarTerm0 = 0;

		/// <summary>
		/// SolarTerm1
		/// </summary>
		public const short SolarTerm1 = 1;

		/// <summary>
		/// SolarTerm2
		/// </summary>
		public const short SolarTerm2 = 2;

		/// <summary>
		/// SolarTerm3
		/// </summary>
		public const short SolarTerm3 = 3;

		/// <summary>
		/// SolarTerm4
		/// </summary>
		public const short SolarTerm4 = 4;

		/// <summary>
		/// SolarTerm5
		/// </summary>
		public const short SolarTerm5 = 5;

		/// <summary>
		/// SolarTerm6
		/// </summary>
		public const short SolarTerm6 = 6;

		/// <summary>
		/// SolarTerm7
		/// </summary>
		public const short SolarTerm7 = 7;

		/// <summary>
		/// SolarTerm8
		/// </summary>
		public const short SolarTerm8 = 8;

		/// <summary>
		/// SolarTerm9
		/// </summary>
		public const short SolarTerm9 = 9;

		/// <summary>
		/// SolarTerm10
		/// </summary>
		public const short SolarTerm10 = 10;

		/// <summary>
		/// SolarTerm11
		/// </summary>
		public const short SolarTerm11 = 11;

		/// <summary>
		/// GraveDestroyed
		/// </summary>
		public const short GraveDestroyed = 12;

		/// <summary>
		/// IncomeFromNest
		/// </summary>
		public const short IncomeFromNest = 13;

		/// <summary>
		/// LoseItemCausedByWarehouseFull
		/// </summary>
		public const short LoseItemCausedByWarehouseFull = 14;

		/// <summary>
		/// Assassinated
		/// </summary>
		public const short Assassinated = 15;

		/// <summary>
		/// AssassinatedDueToKillerToken
		/// </summary>
		public const short AssassinatedDueToKillerToken = 16;

		/// <summary>
		/// Die
		/// </summary>
		public const short Die = 17;

		/// <summary>
		/// InfectXiangshuPartially
		/// </summary>
		public const short InfectXiangshuPartially = 18;

		/// <summary>
		/// InfectXiangshuCompletely
		/// </summary>
		public const short InfectXiangshuCompletely = 19;

		/// <summary>
		/// CreateHatredInPrison
		/// </summary>
		public const short CreateHatredByPrison = 20;

		/// <summary>
		/// EscapeFromPrison
		/// </summary>
		public const short EscapeFromPrison = 21;

		/// <summary>
		/// CricketEndLife
		/// </summary>
		public const short CricketEndLife = 22;

		/// <summary>
		/// LoseResourceCausedByInventoryFull
		/// </summary>
		public const short LoseResourceCausedByInventoryFull = 23;

		/// <summary>
		/// LoseItemCausedByInventoryFull
		/// </summary>
		public const short LoseItemCausedByInventoryFull = 24;

		/// <summary>
		/// CreateHatred
		/// </summary>
		public const short CreateHatred = 25;

		/// <summary>
		/// DecreaseHatred
		/// </summary>
		public const short DecreaseHatred = 26;

		/// <summary>
		/// ConfessLoveAndSucceed
		/// </summary>
		public const short ConfessLoveAndSucceed = 27;

		/// <summary>
		/// SeverLove
		/// </summary>
		public const short SeverLove = 28;

		/// <summary>
		/// Marriage
		/// </summary>
		public const short Marriage = 29;

		/// <summary>
		/// BecomeFriend
		/// </summary>
		public const short BecomeFriend = 30;

		/// <summary>
		/// DecreaseFriendship
		/// </summary>
		public const short DecreaseFriendship = 31;

		/// <summary>
		/// BecomeSwornBrotherOrSister
		/// </summary>
		public const short BecomeSwornBrotherOrSister = 32;

		/// <summary>
		/// SeverFriendship
		/// </summary>
		public const short SeverFriendship = 33;

		/// <summary>
		/// AdoptBoy
		/// </summary>
		public const short AdoptBoy = 34;

		/// <summary>
		/// AdoptGirl
		/// </summary>
		public const short AdoptGirl = 35;

		/// <summary>
		/// RecognizeFather
		/// </summary>
		public const short RecognizeFather = 36;

		/// <summary>
		/// RecognizeMother
		/// </summary>
		public const short RecognizeMother = 37;

		/// <summary>
		/// MakeLove
		/// </summary>
		public const short MakeLove = 38;

		/// <summary>
		/// RapeFailure
		/// </summary>
		public const short RapeFailure = 39;

		/// <summary>
		/// MotherGiveBirthToBoy
		/// </summary>
		public const short MotherGiveBirthToBoy = 40;

		/// <summary>
		/// MotherGiveBirthToGirl
		/// </summary>
		public const short MotherGiveBirthToGirl = 41;

		/// <summary>
		/// FatherGetBoy
		/// </summary>
		public const short FatherGetBoy = 42;

		/// <summary>
		/// FatherGetGirl
		/// </summary>
		public const short FatherGetGirl = 43;

		/// <summary>
		/// GiveBirthToCricket
		/// </summary>
		public const short GiveBirthToCricket = 44;

		/// <summary>
		/// MotherLoseFetus
		/// </summary>
		public const short MotherLoseFetus = 45;

		/// <summary>
		/// GoToJoinOrganization
		/// </summary>
		public const short GoToJoinOrganization = 46;

		/// <summary>
		/// JoinOrganization
		/// </summary>
		public const short JoinOrganization = 47;

		/// <summary>
		/// GoToAppointment
		/// </summary>
		public const short GoToAppointment = 48;

		/// <summary>
		/// WaitingForAppointment
		/// </summary>
		public const short WaitingForAppointment = 49;

		/// <summary>
		/// AppointmentExpired
		/// </summary>
		public const short AppointmentExpired = 50;

		/// <summary>
		/// AppointmentCancelled
		/// </summary>
		public const short AppointmentCancelled = 51;

		/// <summary>
		/// GoToRescue
		/// </summary>
		public const short GoToRescue = 52;

		/// <summary>
		/// RescuePrisoner
		/// </summary>
		public const short RescuePrisoner = 53;

		/// <summary>
		/// ReleasePrisoner
		/// </summary>
		public const short ReleasePrisoner = 54;

		/// <summary>
		/// Disappear
		/// </summary>
		public const short Disappear = 55;

		/// <summary>
		/// GoToRevenge
		/// </summary>
		public const short GoToRevenge = 56;

		/// <summary>
		/// GoToProtect
		/// </summary>
		public const short GoToProtect = 57;

		/// <summary>
		/// ProtectRelativeOrFriend
		/// </summary>
		public const short ProtectRelativeOrFriend = 58;

		/// <summary>
		/// SectUpgrade
		/// </summary>
		public const short SectUpgrade = 59;

		/// <summary>
		/// CivilianSettlementUpgrade
		/// </summary>
		public const short CivilianSettlementUpgrade = 60;

		/// <summary>
		/// FactionUpgrade
		/// </summary>
		public const short FactionUpgrade = 61;

		/// <summary>
		/// StealResourceFailure
		/// </summary>
		public const short StealResourceFailure = 62;

		/// <summary>
		/// StealResourceSuccess
		/// </summary>
		public const short StealResourceSuccess = 63;

		/// <summary>
		/// CheatResourceFailure
		/// </summary>
		public const short CheatResourceFailure = 64;

		/// <summary>
		/// RobResourceFailure
		/// </summary>
		public const short RobResourceFailure = 65;

		/// <summary>
		/// DigResource
		/// </summary>
		public const short DigResource = 66;

		/// <summary>
		/// StealItemFailure
		/// </summary>
		public const short StealItemFailure = 67;

		/// <summary>
		/// StealItemSuccess
		/// </summary>
		public const short StealItemSuccess = 68;

		/// <summary>
		/// CheatItemFailure
		/// </summary>
		public const short CheatItemFailure = 69;

		/// <summary>
		/// RobItemFailure
		/// </summary>
		public const short RobItemFailure = 70;

		/// <summary>
		/// DigItem
		/// </summary>
		public const short DigItem = 71;

		/// <summary>
		/// StealLifeSkillFailure
		/// </summary>
		public const short StealLifeSkillFailure = 72;

		/// <summary>
		/// StealLifeSkillSuccess
		/// </summary>
		public const short StealLifeSkillSuccess = 73;

		/// <summary>
		/// CheatLifeSkillFailure
		/// </summary>
		public const short CheatLifeSkillFailure = 74;

		/// <summary>
		/// StealCombatSkillFailure
		/// </summary>
		public const short StealCombatSkillFailure = 75;

		/// <summary>
		/// StealCombatSkillSuccess
		/// </summary>
		public const short StealCombatSkillSuccess = 76;

		/// <summary>
		/// CheatCombatSkillFailure
		/// </summary>
		public const short CheatCombatSkillFailure = 77;

		/// <summary>
		/// GivePresentResource
		/// </summary>
		public const short GivePresentResource = 78;

		/// <summary>
		/// GivePresentItem
		/// </summary>
		public const short GivePresentItem = 79;

		/// <summary>
		/// TeachLifeSkillSuccess
		/// </summary>
		public const short TeachLifeSkillSuccess = 80;

		/// <summary>
		/// TeachLifeSkillFailure
		/// </summary>
		public const short TeachLifeSkillFailure = 81;

		/// <summary>
		/// TeachCombatSkillSuccess
		/// </summary>
		public const short TeachCombatSkillSuccess = 82;

		/// <summary>
		/// TeachCombatSkillFailure
		/// </summary>
		public const short TeachCombatSkillFailure = 83;

		/// <summary>
		/// AmuseOthersByMusic
		/// </summary>
		public const short AmuseOthersByMusic = 84;

		/// <summary>
		/// AmuseOthersByChess
		/// </summary>
		public const short AmuseOthersByChess = 85;

		/// <summary>
		/// AmuseOthersByPoem
		/// </summary>
		public const short AmuseOthersByPoem = 86;

		/// <summary>
		/// AmuseOthersByPainting
		/// </summary>
		public const short AmuseOthersByPainting = 87;

		/// <summary>
		/// MakeFamousItem
		/// </summary>
		public const short MakeFamousItem = 88;

		/// <summary>
		/// EnlightenedByDaoism
		/// </summary>
		public const short EnlightenedByDaoism = 89;

		/// <summary>
		/// EnlightenedByBuddhism
		/// </summary>
		public const short EnlightenedByBuddhism = 90;

		/// <summary>
		/// PractiseDivination
		/// </summary>
		public const short PractiseDivination = 91;

		/// <summary>
		/// UnexpectedlyGetRareItem
		/// </summary>
		public const short UnexpectedlyGetRareItem = 92;

		/// <summary>
		/// UnexpectedlyGetResource
		/// </summary>
		public const short UnexpectedlyGetResource = 93;

		/// <summary>
		/// UnexpectedlyGetCombatSkill
		/// </summary>
		public const short UnexpectedlyGetCombatSkill = 94;

		/// <summary>
		/// UnexpectedlyGetLifeSkill
		/// </summary>
		public const short UnexpectedlyGetLifeSkill = 95;

		/// <summary>
		/// UnexpectedlyGetHealth
		/// </summary>
		public const short UnexpectedlyGetHealth = 96;

		/// <summary>
		/// UnexpectedlyHealOuterInjury
		/// </summary>
		public const short UnexpectedlyHealOuterInjury = 97;

		/// <summary>
		/// UnexpectedlyHealInneInjury
		/// </summary>
		public const short UnexpectedlyHealInnerInjury = 98;

		/// <summary>
		/// UnexpectedlyHealPoison
		/// </summary>
		public const short UnexpectedlyHealPoison = 99;

		/// <summary>
		/// UnexpectedlyHealQi
		/// </summary>
		public const short UnexpectedlyHealQi = 100;

		/// <summary>
		/// UnexpectedlyLoseRareItem
		/// </summary>
		public const short UnexpectedlyLoseRareItem = 101;

		/// <summary>
		/// UnexpectedlyLoseResource
		/// </summary>
		public const short UnexpectedlyLoseResource = 102;

		/// <summary>
		/// UnexpectedlyLoseCombatSkill
		/// </summary>
		public const short UnexpectedlyLoseCombatSkill = 103;

		/// <summary>
		/// UnexpectedlyLoseLifeSkill
		/// </summary>
		public const short UnexpectedlyLoseLifeSkill = 104;

		/// <summary>
		/// UnexpectedlyLoseHealth
		/// </summary>
		public const short UnexpectedlyLoseHealth = 105;

		/// <summary>
		/// UnexpectedlySufferOuterInjury
		/// </summary>
		public const short UnexpectedlySufferOuterInjury = 106;

		/// <summary>
		/// UnexpectedlySufferInneInjury
		/// </summary>
		public const short UnexpectedlySufferInneInjury = 107;

		/// <summary>
		/// UnexpectedlySufferPoison
		/// </summary>
		public const short UnexpectedlySufferPoison = 108;

		/// <summary>
		/// UnexpectedlySufferDisorderOfQi
		/// </summary>
		public const short UnexpectedlySufferDisorderOfQi = 109;

		/// <summary>
		/// BuildingResourceIncreased
		/// </summary>
		public const short BuildingResourceIncreased = 110;

		/// <summary>
		/// BuildingResourceSpread
		/// </summary>
		public const short BuildingResourceSpread = 111;

		/// <summary>
		/// BuildingDamaged
		/// </summary>
		public const short BuildingDamaged = 112;

		/// <summary>
		/// BuildingRuined
		/// </summary>
		public const short BuildingRuined = 113;

		/// <summary>
		/// BuildingConstructionCompleted
		/// </summary>
		public const short BuildingConstructionCompleted = 114;

		/// <summary>
		/// BuildingUpgradingCompleted
		/// </summary>
		public const short BuildingUpgradingCompleted = 115;

		/// <summary>
		/// BuildingDemolitionCompleted
		/// </summary>
		public const short BuildingDemolitionCompleted = 116;

		/// <summary>
		/// BuildingIncome
		/// </summary>
		public const short BuildingIncome = 117;

		/// <summary>
		/// DispatchInPlace
		/// </summary>
		public const short DispatchInPlace = 118;

		/// <summary>
		/// FindViciousBeggarsNest
		/// </summary>
		public const short FindViciousBeggarsNest = 119;

		/// <summary>
		/// FindThievesCamp
		/// </summary>
		public const short FindThievesCamp = 120;

		/// <summary>
		/// FindBanditsStronghold
		/// </summary>
		public const short FindBanditsStronghold = 121;

		/// <summary>
		/// FindTraitorsGang
		/// </summary>
		public const short FindTraitorsGang = 122;

		/// <summary>
		/// FindVillainsValley
		/// </summary>
		public const short FindVillainsValley = 123;

		/// <summary>
		/// FindMixiangzhen
		/// </summary>
		public const short FindMixiangzhen = 124;

		/// <summary>
		/// FindMassGrave
		/// </summary>
		public const short FindMassGrave = 125;

		/// <summary>
		/// FindHereticHome
		/// </summary>
		public const short FindHereticHome = 126;

		/// <summary>
		/// KidnappedByHeresy
		/// </summary>
		public const short KidnappedByHeresy = 127;

		/// <summary>
		/// KidnappedByHeart
		/// </summary>
		public const short KidnappedByHeart = 128;

		/// <summary>
		/// KidnappedBySoumoulou
		/// </summary>
		public const short KidnappedBySoumoulou = 129;

		/// <summary>
		/// KidnappedByWorldWeary
		/// </summary>
		public const short KidnappedByWorldWeary = 130;

		/// <summary>
		/// MarketAppeared
		/// </summary>
		public const short MarketAppeared = 131;

		/// <summary>
		/// TownCombatAppeared
		/// </summary>
		public const short TownCombatAppeared = 132;

		/// <summary>
		/// CricketsAppeared
		/// </summary>
		public const short CricketsAppeared = 133;

		/// <summary>
		/// StartCricketContest
		/// </summary>
		public const short StartCricketContest = 134;

		/// <summary>
		/// LifeCompetitionAppeared
		/// </summary>
		public const short LifeCompetitionAppeared = 135;

		/// <summary>
		/// StartSectJuniorContest
		/// </summary>
		public const short StartSectJuniorContest = 136;

		/// <summary>
		/// StartSectIntermediateContest
		/// </summary>
		public const short StartSectIntermediateContest = 137;

		/// <summary>
		/// StartSectSeniorContest
		/// </summary>
		public const short StartSectSeniorContest = 138;

		/// <summary>
		/// JoustForSpouse
		/// </summary>
		public const short JoustForSpouse = 139;

		/// <summary>
		/// MarryNotice
		/// </summary>
		public const short MarryNotice = 140;

		/// <summary>
		/// XiangshuAvatarAppeared
		/// </summary>
		public const short XiangshuAvatarAppeared = 141;

		/// <summary>
		/// MonvBringDisaster
		/// </summary>
		public const short MonvBringDisaster = 142;

		/// <summary>
		/// DayueYaochangBringDisaster
		/// </summary>
		public const short DayueYaochangBringDisaster = 143;

		/// <summary>
		/// JiuhanvBringDisaster
		/// </summary>
		public const short JiuhanvBringDisaster = 144;

		/// <summary>
		/// JinHuangervBringDisaster
		/// </summary>
		public const short JinHuangervBringDisaster = 145;

		/// <summary>
		/// YiYihouvBringDisaster
		/// </summary>
		public const short YiYihouvBringDisaster = 146;

		/// <summary>
		/// WeiQivBringDisaster
		/// </summary>
		public const short WeiQivBringDisaster = 147;

		/// <summary>
		/// YixiangvBringDisaster
		/// </summary>
		public const short YixiangvBringDisaster = 148;

		/// <summary>
		/// XuefengBringDisaster
		/// </summary>
		public const short XuefengBringDisaster = 149;

		/// <summary>
		/// ShuFangvBringDisaster
		/// </summary>
		public const short ShuFangvBringDisaster = 150;

		/// <summary>
		/// MonvSaveSuffering
		/// </summary>
		public const short MonvSaveSuffering = 151;

		/// <summary>
		/// DayueYaochangSaveSuffering
		/// </summary>
		public const short DayueYaochangSaveSuffering = 152;

		/// <summary>
		/// JiuhanvSaveSuffering
		/// </summary>
		public const short JiuhanvSaveSuffering = 153;

		/// <summary>
		/// JinHuangervSaveSuffering
		/// </summary>
		public const short JinHuangervSaveSuffering = 154;

		/// <summary>
		/// YiYihouvSaveSuffering
		/// </summary>
		public const short YiYihouvSaveSuffering = 155;

		/// <summary>
		/// WeiQivSaveSuffering
		/// </summary>
		public const short WeiQivSaveSuffering = 156;

		/// <summary>
		/// YixiangvSaveSuffering
		/// </summary>
		public const short YixiangvSaveSuffering = 157;

		/// <summary>
		/// XuefengSaveSuffering
		/// </summary>
		public const short XuefengSaveSuffering = 158;

		/// <summary>
		/// ShuFangvSaveSuffering
		/// </summary>
		public const short ShuFangvSaveSuffering = 159;

		/// <summary>
		/// CivilianDisappear
		/// </summary>
		public const short CivilianDisappear = 160;

		/// <summary>
		/// MerchantGoTravelling
		/// </summary>
		public const short MerchantGoTravelling = 161;

		/// <summary>
		/// ChickenEscaped
		/// </summary>
		public const short ChickenEscaped = 162;

		/// <summary>
		/// NaturalDisasterOccurred
		/// </summary>
		public const short NaturalDisasterOccurred = 163;

		/// <summary>
		/// Reincarnation
		/// </summary>
		public const short Reincarnation = 164;

		/// <summary>
		/// AccumulatedSkillPowerLost
		/// </summary>
		public const short AccumulatedSkillPowerLost = 165;

		/// <summary>
		/// TaiwuVillageDestructed
		/// </summary>
		public const short TaiwuVillageDestructed = 166;

		/// <summary>
		/// RebirthAsJuniorXiangshu
		/// </summary>
		public const short RebirthAsJuniorXiangshu = 167;

		/// <summary>
		/// LegendaryBookAppeared
		/// </summary>
		public const short LegendaryBookAppeared = 168;

		/// <summary>
		/// WulinConferenceWithoutParticipant
		/// </summary>
		public const short WulinConferenceWithoutParticipant = 169;

		/// <summary>
		/// WulinConferenceInPreparing
		/// </summary>
		public const short WulinConferenceInPreparing = 170;

		/// <summary>
		/// WulinConferenceInProgress
		/// </summary>
		public const short WulinConferenceInProgress = 171;

		/// <summary>
		/// XiangshuKilling
		/// </summary>
		public const short XiangshuKilling = 172;

		/// <summary>
		/// MonthlyNormalInformation
		/// </summary>
		public const short MonthlyNormalInformation = 173;

		/// <summary>
		/// MonthlySecretInformation
		/// </summary>
		public const short MonthlySecretInformation = 174;

		/// <summary>
		/// SecretInformationWillExpire
		/// </summary>
		public const short SecretInformationWillExpire = 175;

		/// <summary>
		/// SecretInformationExpired
		/// </summary>
		public const short SecretInformationExpired = 176;

		/// <summary>
		/// YirenAppearInTaiwuArea
		/// </summary>
		public const short YirenAppearInTaiwuArea = 177;

		/// <summary>
		/// WesternMerchantBackAfterLong
		/// </summary>
		public const short WesternMerchantBackAfterLong = 178;

		/// <summary>
		/// WesternMerchantLoseContact
		/// </summary>
		public const short WesternMerchantLoseContact = 179;

		/// <summary>
		/// WesternMerchantBackSucceed
		/// </summary>
		public const short WesternMerchantBackSucceed = 180;

		/// <summary>
		/// GainAuthority
		/// </summary>
		public const short GainAuthority = 181;

		/// <summary>
		/// FemaleJoustForSpouseReady
		/// </summary>
		public const short FemaleJoustForSpouseReady = 182;

		/// <summary>
		/// StartSectNormalCompetition
		/// </summary>
		public const short StartSectNormalCompetition = 183;

		/// <summary>
		/// EscapeWithForeverLover
		/// </summary>
		public const short EscapeWithForeverLover = 184;

		/// <summary>
		/// DisasterAndPreciousMaterial
		/// </summary>
		public const short DisasterAndPreciousMaterial = 185;

		/// <summary>
		/// HeroesDefendMorality
		/// </summary>
		public const short HeroesDefendMorality = 186;

		/// <summary>
		/// IncomeFromNestViciousBeggars
		/// </summary>
		public const short IncomeFromNestViciousBeggars = 187;

		/// <summary>
		/// IncomeFromNestThievesCamp
		/// </summary>
		public const short IncomeFromNestThievesCamp = 188;

		/// <summary>
		/// IncomeFromNestBanditsStronghold
		/// </summary>
		public const short IncomeFromNestBanditsStronghold = 189;

		/// <summary>
		/// IncomeFromNestVillainsValley
		/// </summary>
		public const short IncomeFromNestVillainsValley = 190;

		/// <summary>
		/// IncomeFromNestRighteousLow
		/// </summary>
		public const short IncomeFromNestRighteousLow = 191;

		/// <summary>
		/// IncomeFromNestRighteousMiddle
		/// </summary>
		public const short IncomeFromNestRighteousMiddle = 192;

		/// <summary>
		/// BuildingWorkerDie
		/// </summary>
		public const short BuildingWorkerDie = 193;

		/// <summary>
		/// StoneHouseInfectedKidnapped
		/// </summary>
		public const short StoneHouseInfectedKidnapped = 194;

		/// <summary>
		/// WesternMerchanLost
		/// </summary>
		public const short WesternMerchanLost = 195;

		/// <summary>
		/// WesternMerchanFindMirage
		/// </summary>
		public const short WesternMerchanFindMirage = 196;

		/// <summary>
		/// WesternMerchanFindBigfoot
		/// </summary>
		public const short WesternMerchanFindBigfoot = 197;

		/// <summary>
		/// WesternMerchanFindPlant
		/// </summary>
		public const short WesternMerchanFindPlant = 198;

		/// <summary>
		/// WesternMerchanFindAnimal
		/// </summary>
		public const short WesternMerchanFindAnimal = 199;

		/// <summary>
		/// WesternMerchanGetInformation
		/// </summary>
		public const short WesternMerchanGetInformation = 200;

		/// <summary>
		/// WesternMerchanFindSettlement
		/// </summary>
		public const short WesternMerchanFindSettlement = 201;

		/// <summary>
		/// WesternMerchanFindWeather
		/// </summary>
		public const short WesternMerchanFindWeather = 202;

		/// <summary>
		/// WesternMerchanFindWreckage
		/// </summary>
		public const short WesternMerchanFindWreckage = 203;

		/// <summary>
		/// WesternMerchanHelpPasserby
		/// </summary>
		public const short WesternMerchanHelpPasserby = 204;

		/// <summary>
		/// WesternMerchanGetHelp
		/// </summary>
		public const short WesternMerchanGetHelp = 205;

		/// <summary>
		/// WesternMerchanFindVenison
		/// </summary>
		public const short WesternMerchanFindVenison = 206;

		/// <summary>
		/// WesternMerchanFindFruit
		/// </summary>
		public const short WesternMerchanFindFruit = 207;

		/// <summary>
		/// WesternMerchanFindVillage
		/// </summary>
		public const short WesternMerchanFindVillage = 208;

		/// <summary>
		/// WesternMerchanMeetMerchan
		/// </summary>
		public const short WesternMerchanMeetMerchan = 209;

		/// <summary>
		/// WesternMerchanMeetTheif
		/// </summary>
		public const short WesternMerchanMeetTheif = 210;

		/// <summary>
		/// WesternMerchanGoodsDamage
		/// </summary>
		public const short WesternMerchanGoodsDamage = 211;

		/// <summary>
		/// WesternMerchanUnacclimatized
		/// </summary>
		public const short WesternMerchanUnacclimatized = 212;

		/// <summary>
		/// WesternMerchanLackReplenishment
		/// </summary>
		public const short WesternMerchanLackReplenishment = 213;

		/// <summary>
		/// AboutToDie
		/// </summary>
		public const short AboutToDie = 214;

		/// <summary>
		/// EnemyNestDemise
		/// </summary>
		public const short EnemyNestDemise = 215;

		/// <summary>
		/// SecretInformationBroadcast
		/// </summary>
		public const short SecretInformationBroadcast = 216;

		/// <summary>
		/// ReadingEvent
		/// </summary>
		public const short ReadingEvent = 217;

		/// <summary>
		/// EnemyNestGrow
		/// </summary>
		public const short EnemyNestGrow = 218;

		/// <summary>
		/// RandomEnemyGrow
		/// </summary>
		public const short RandomEnemyGrow = 219;

		/// <summary>
		/// RandomEnemyDecay
		/// </summary>
		public const short RandomEnemyDecay = 220;

		/// <summary>
		/// XiangshuGetStrengthened
		/// </summary>
		public const short XiangshuGetStrengthened = 221;

		/// <summary>
		/// LegendaryBookShocked
		/// </summary>
		public const short LegendaryBookShocked = 222;

		/// <summary>
		/// LegendaryBookInsane
		/// </summary>
		public const short LegendaryBookInsane = 223;

		/// <summary>
		/// LegendaryBookConsumed
		/// </summary>
		public const short LegendaryBookConsumed = 224;

		/// <summary>
		/// LegendaryBookLost
		/// </summary>
		public const short LegendaryBookLost = 225;

		/// <summary>
		/// FightForNewLegendaryBook
		/// </summary>
		public const short FightForNewLegendaryBook = 226;

		/// <summary>
		/// FightForLegendaryBookAbandoned
		/// </summary>
		public const short FightForLegendaryBookAbandoned = 227;

		/// <summary>
		/// FightForLegendaryBookOwnerDie
		/// </summary>
		public const short FightForLegendaryBookOwnerDie = 228;

		/// <summary>
		/// FightForLegendaryBookOwnerConsumed
		/// </summary>
		public const short FightForLegendaryBookOwnerConsumed = 229;

		/// <summary>
		/// LegendaryBookAppear
		/// </summary>
		public const short LegendaryBookAppear = 230;

		/// <summary>
		/// ChallengeForLegendaryBook
		/// </summary>
		public const short ChallengeForLegendaryBook = 231;

		/// <summary>
		/// RobLegendaryBook
		/// </summary>
		public const short RobLegendaryBook = 232;

		/// <summary>
		/// VillagerLeftForLegendaryBook
		/// </summary>
		public const short VillagerLeftForLegendaryBook = 233;

		/// <summary>
		/// HappyBirthday
		/// </summary>
		public const short HappyBirthday = 234;

		/// <summary>
		/// PoisonMakeLoss
		/// </summary>
		public const short PoisonMakeLoss = 235;

		/// <summary>
		/// RottenPoisonDiffuse
		/// </summary>
		public const short RottenPoisonDiffuse = 236;

		/// <summary>
		/// PoisonDestroyFace
		/// </summary>
		public const short PoisonDestroyFace = 237;

		/// <summary>
		/// IllusoryPoisonDiffuse
		/// </summary>
		public const short IllusoryPoisonDiffuse = 238;

		/// <summary>
		/// PoisonDisturbMindAttckSuccess
		/// </summary>
		public const short PoisonDisturbMindAttckSuccess = 239;

		/// <summary>
		/// PoisonDisturbMindEmpoisonSuccess
		/// </summary>
		public const short PoisonDisturbMindEmpoisonSuccess = 240;

		/// <summary>
		/// PoisonDisturbMindSneakAttckSuccess
		/// </summary>
		public const short PoisonDisturbMindSneakAttckSuccess = 241;

		/// <summary>
		/// PoisonDisturbMindRapeSuccess
		/// </summary>
		public const short PoisonDisturbMindRapeSuccess = 242;

		/// <summary>
		/// PoisonDisturbMindAttckFalse
		/// </summary>
		public const short PoisonDisturbMindAttckFalse = 243;

		/// <summary>
		/// PoisonDisturbMindEmpoisonFalse
		/// </summary>
		public const short PoisonDisturbMindEmpoisonFalse = 244;

		/// <summary>
		/// PoisonDisturbMindSneakAttckFalse
		/// </summary>
		public const short PoisonDisturbMindSneakAttckFalse = 245;

		/// <summary>
		/// PoisonDisturbMindRapeFalse
		/// </summary>
		public const short PoisonDisturbMindRapeFalse = 246;

		/// <summary>
		/// SectMainStoryXuehouJixiKillsPeople
		/// </summary>
		public const short SectMainStoryXuehouJixiKillsPeople = 247;

		/// <summary>
		/// SectMainStoryYuanshanAbsorbInfectedPeople
		/// </summary>
		public const short SectMainStoryYuanshanAbsorbInfectedPeople = 248;

		/// <summary>
		/// SectMainStoryShixiangAdventure
		/// </summary>
		public const short SectMainStoryShixiangAdventure = 249;

		/// <summary>
		/// SectMainStoryXuehouJixiGone
		/// </summary>
		public const short SectMainStoryXuehouJixiGone = 250;

		/// <summary>
		/// WulinConferenceWinner
		/// </summary>
		public const short WulinConferenceWinner = 251;

		/// <summary>
		/// SectMainStoryEmeiInfighting
		/// </summary>
		public const short SectMainStoryEmeiInfighting = 252;

		/// <summary>
		/// SectMainStoryWhiteGibbonReturns
		/// </summary>
		public const short SectMainStoryWhiteGibbonReturns = 253;

		/// <summary>
		/// SectMainStoryXuehouJixiGoneAgain
		/// </summary>
		public const short SectMainStoryXuehouJixiGoneAgain = 254;

		/// <summary>
		/// SectMainStoryXuehouJixiRescue
		/// </summary>
		public const short SectMainStoryXuehouJixiRescue = 255;

		/// <summary>
		/// SectMainStoryXuehouJixiGoneFinal
		/// </summary>
		public const short SectMainStoryXuehouJixiGoneFinal = 256;

		/// <summary>
		/// SectMainStoryKongsangTripodVesselCures
		/// </summary>
		public const short SectMainStoryKongsangTripodVesselCures = 257;

		/// <summary>
		/// SectMainStoryKongsangTripodVesselDetoxifies
		/// </summary>
		public const short SectMainStoryKongsangTripodVesselDetoxifies = 258;

		/// <summary>
		/// SectMainStoryKongsangTripodVesselRemovesQiDisorder
		/// </summary>
		public const short SectMainStoryKongsangTripodVesselRemovesQiDisorder = 259;

		/// <summary>
		/// SectMainStoryKongsangTripodVesselRestoresHealth
		/// </summary>
		public const short SectMainStoryKongsangTripodVesselRestoresHealth = 260;

		/// <summary>
		/// ReincarnationNewWithLocation
		/// </summary>
		public const short ReincarnationNewWithLocation = 261;

		/// <summary>
		/// SectMainStoryWudangVillagersInjured
		/// </summary>
		public const short SectMainStoryWudangVillagersInjured = 262;

		/// <summary>
		/// SectMainStoryWudangVillagerCasualty
		/// </summary>
		public const short SectMainStoryWudangVillagerCasualty = 263;

		/// <summary>
		/// KillHereticRandomEnemy
		/// </summary>
		public const short KillHereticRandomEnemy = 264;

		/// <summary>
		/// DefeatedByHereticRandomEnemy
		/// </summary>
		public const short DefeatedByHereticRandomEnemy = 265;

		/// <summary>
		/// KillRighteousRandomEnemy
		/// </summary>
		public const short KillRighteousRandomEnemy = 266;

		/// <summary>
		/// DefeatedByRighteousRandomEnemy
		/// </summary>
		public const short DefeatedByRighteousRandomEnemy = 267;

		/// <summary>
		/// KillAnimal
		/// </summary>
		public const short KillAnimal = 268;

		/// <summary>
		/// DefeatedByAnimal
		/// </summary>
		public const short DefeatedByAnimal = 269;

		/// <summary>
		/// DieFromEnemyNest
		/// </summary>
		public const short DieFromEnemyNest = 270;

		/// <summary>
		/// Dummy0
		/// </summary>
		public const short Dummy0 = 271;

		/// <summary>
		/// Dummy1
		/// </summary>
		public const short Dummy1 = 272;

		/// <summary>
		/// Dummy2
		/// </summary>
		public const short Dummy2 = 273;

		/// <summary>
		/// MiscarriageAndReincarnation
		/// </summary>
		public const short MiscarriageAndReincarnation = 274;

		/// <summary>
		/// MiscarriageAndReincarnationMotherDies
		/// </summary>
		public const short MiscarriageAndReincarnationMotherDies = 275;

		/// <summary>
		/// MiscarriageAndReincarnationMotherKilled
		/// </summary>
		public const short MiscarriageAndReincarnationMotherKilled = 276;

		/// <summary>
		/// SectMainStoryEmeiShiReturns
		/// </summary>
		public const short SectMainStoryEmeiShiReturns = 277;

		/// <summary>
		/// SectMainStoryEmeiDoomOfEmei
		/// </summary>
		public const short SectMainStoryEmeiDoomOfEmei = 278;

		/// <summary>
		/// EscapeFromEnemyNest
		/// </summary>
		public const short EscapeFromEnemyNest = 279;

		/// <summary>
		/// SavedFromEnemyNest
		/// </summary>
		public const short SavedFromEnemyNest = 280;

		/// <summary>
		/// CultureDecline
		/// </summary>
		public const short CultureDecline = 281;

		/// <summary>
		/// FiveLoongArise
		/// </summary>
		public const short FiveLoongArise = 282;

		/// <summary>
		/// JiaoPoolAccident
		/// </summary>
		public const short JiaoPoolAccident = 283;

		/// <summary>
		/// JiaoGoHome
		/// </summary>
		public const short JiaoGoHome = 284;

		/// <summary>
		/// JiaoBrokeThroughTheShell
		/// </summary>
		public const short JiaoBrokeThroughTheShell = 285;

		/// <summary>
		/// JiaoHasReachedAnAdultAge
		/// </summary>
		public const short JiaoHasReachedAnAdultAge = 286;

		/// <summary>
		/// DLCLoongRidingEffectQiuniu
		/// </summary>
		public const short DLCLoongRidingEffectQiuniu = 287;

		/// <summary>
		/// DLCLoongRidingEffectYazi
		/// </summary>
		public const short DLCLoongRidingEffectYazi = 288;

		/// <summary>
		/// DLCLoongRidingEffectChaofeng
		/// </summary>
		public const short DLCLoongRidingEffectChaofeng = 289;

		/// <summary>
		/// DLCLoongRidingEffectPulao
		/// </summary>
		public const short DLCLoongRidingEffectPulao = 290;

		/// <summary>
		/// DLCLoongRidingEffectSuanni
		/// </summary>
		public const short DLCLoongRidingEffectSuanni = 291;

		/// <summary>
		/// DLCLoongRidingEffectBaxia
		/// </summary>
		public const short DLCLoongRidingEffectBaxia = 292;

		/// <summary>
		/// DLCLoongRidingEffectBian
		/// </summary>
		public const short DLCLoongRidingEffectBian = 293;

		/// <summary>
		/// DLCLoongRidingEffectFuxi
		/// </summary>
		public const short DLCLoongRidingEffectFuxi = 294;

		/// <summary>
		/// DLCLoongRidingEffectChiwen
		/// </summary>
		public const short DLCLoongRidingEffectChiwen = 295;

		/// <summary>
		/// JiaoLayEggs
		/// </summary>
		public const short JiaoLayEggs = 296;

		/// <summary>
		/// JiaoTamingPointsLow
		/// </summary>
		public const short JiaoTamingPointsLow = 297;

		/// <summary>
		/// DieFromAge
		/// </summary>
		public const short DieFromAge = 298;

		/// <summary>
		/// DieFromPoorHealth
		/// </summary>
		public const short DieFromPoorHealth = 299;

		/// <summary>
		/// KilledInPubilc
		/// </summary>
		public const short KilledInPubilc = 300;

		/// <summary>
		/// SectMainStoryJingangHaunted
		/// </summary>
		public const short SectMainStoryJingangHaunted = 301;

		/// <summary>
		/// SectMainStoryJingangFollowedByGhost
		/// </summary>
		public const short SectMainStoryJingangFollowedByGhost = 302;

		/// <summary>
		/// SectMainStoryJingangWrongdoing
		/// </summary>
		public const short SectMainStoryJingangWrongdoing = 303;

		/// <summary>
		/// SectMainStoryJingangPray
		/// </summary>
		public const short SectMainStoryJingangPray = 304;

		/// <summary>
		/// SectMainStoryJingangFameDistribution
		/// </summary>
		public const short SectMainStoryJingangFameDistribution = 305;

		/// <summary>
		/// WugKingParasitiferDead
		/// </summary>
		public const short WugKingParasitiferDead = 306;

		/// <summary>
		/// WugKingDead
		/// </summary>
		public const short WugKingDead = 307;

		/// <summary>
		/// WugKingDeadSpecial
		/// </summary>
		public const short WugKingDeadSpecial = 308;

		/// <summary>
		/// SectMainStoryJingangFamousFakeMonk
		/// </summary>
		public const short SectMainStoryJingangFamousFakeMonk = 309;

		/// <summary>
		/// SectMainStoryJingangRockFleshed
		/// </summary>
		public const short SectMainStoryJingangRockFleshed = 310;

		/// <summary>
		/// SectMainStoryWuxianParanoiaAppeared
		/// </summary>
		public const short SectMainStoryWuxianParanoiaAppeared = 311;

		/// <summary>
		/// SectMainStoryJingangVillagerFlee
		/// </summary>
		public const short SectMainStoryJingangVillagerFlee = 312;

		/// <summary>
		/// SectMainStoryRanshanSanZongBiWu
		/// </summary>
		public const short SectMainStoryRanshanSanZongBiWu = 313;

		/// <summary>
		/// GiveUpLegendaryBookSuccessHuaJu
		/// </summary>
		public const short GiveUpLegendaryBookSuccessHuaJu = 314;

		/// <summary>
		/// GiveUpLegendaryBookSuccessXuanZhi
		/// </summary>
		public const short GiveUpLegendaryBookSuccessXuanZhi = 315;

		/// <summary>
		/// GiveUpLegendaryBookSuccessYingJiao
		/// </summary>
		public const short GiveUpLegendaryBookSuccessYingJiao = 316;

		/// <summary>
		/// GiveUpLegendaryBookFailureHuaJu
		/// </summary>
		public const short GiveUpLegendaryBookFailureHuaJu = 317;

		/// <summary>
		/// GiveUpLegendaryBookFailureXuanZhi
		/// </summary>
		public const short GiveUpLegendaryBookFailureXuanZhi = 318;

		/// <summary>
		/// GiveUpLegendaryBookFailureYingJiao
		/// </summary>
		public const short GiveUpLegendaryBookFailureYingJiao = 319;

		/// <summary>
		/// GiveUpLegendaryBookLoseBookHuaJu
		/// </summary>
		public const short GiveUpLegendaryBookLoseBookHuaJu = 320;

		/// <summary>
		/// GiveUpLegendaryBookLoseBookXuanZhi
		/// </summary>
		public const short GiveUpLegendaryBookLoseBookXuanZhi = 321;

		/// <summary>
		/// GiveUpLegendaryBookLoseBookYingJiao
		/// </summary>
		public const short GiveUpLegendaryBookLoseBookYingJiao = 322;

		/// <summary>
		/// GiveUpLegendaryBookLoseTargetHuaJu
		/// </summary>
		public const short GiveUpLegendaryBookLoseTargetHuaJu = 323;

		/// <summary>
		/// GiveUpLegendaryBookLoseTargetXuanZhi
		/// </summary>
		public const short GiveUpLegendaryBookLoseTargetXuanZhi = 324;

		/// <summary>
		/// GiveUpLegendaryBookLoseTargetYingJiao
		/// </summary>
		public const short GiveUpLegendaryBookLoseTargetYingJiao = 325;

		/// <summary>
		/// LifeLinkHealing
		/// </summary>
		public const short LifeLinkHealing = 326;

		/// <summary>
		/// LifeLinkDamage
		/// </summary>
		public const short LifeLinkDamage = 327;

		/// <summary>
		/// SectMainStoryBaIhuaLeukoKills
		/// </summary>
		public const short SectMainStoryBaihuaLeukoKills = 328;

		/// <summary>
		/// SectMainStoryBaIhuaMelanoKills
		/// </summary>
		public const short SectMainStoryBaihuaMelanoKills = 329;

		/// <summary>
		/// SectMainStoryBaIhuaLeukoHelps
		/// </summary>
		public const short SectMainStoryBaihuaLeukoHelps = 330;

		/// <summary>
		/// SectMainStoryBaIhuaMelanoHelps
		/// </summary>
		public const short SectMainStoryBaihuaMelanoHelps = 331;

		/// <summary>
		/// SectMainStoryBaIhuaManicLow
		/// </summary>
		public const short SectMainStoryBaihuaManicLow = 332;

		/// <summary>
		/// SectMainStoryBaIhuaManicHigh
		/// </summary>
		public const short SectMainStoryBaihuaManicHigh = 333;

		/// <summary>
		/// LoopingEvent
		/// </summary>
		public const short LoopingEvent = 334;

		/// <summary>
		/// FiveElementsChange
		/// </summary>
		public const short FiveElementsChange = 335;

		/// <summary>
		/// ResourcesCollectionCompleted
		/// </summary>
		public const short ResourcesCollectionCompleted = 336;

		/// <summary>
		/// SectMainStoryFulongSacrifice
		/// </summary>
		public const short SectMainStoryFulongSacrifice = 337;

		/// <summary>
		/// SectMainStoryFulongFeatherDrop
		/// </summary>
		public const short SectMainStoryFulongFeatherDrop = 338;

		/// <summary>
		/// MarketComing
		/// </summary>
		public const short MarketComing = 339;

		/// <summary>
		/// TownCombatComing
		/// </summary>
		public const short TownCombatComing = 340;

		/// <summary>
		/// CricketContestComing
		/// </summary>
		public const short CricketContestComing = 341;

		/// <summary>
		/// LifeCompetitionComing
		/// </summary>
		public const short LifeCompetitionComing = 342;

		/// <summary>
		/// SectNormalCompetitionComing
		/// </summary>
		public const short SectNormalCompetitionComing = 343;

		/// <summary>
		/// JoustForSpouseComing
		/// </summary>
		public const short JoustForSpouseComing = 344;

		/// <summary>
		/// DyingNotice
		/// </summary>
		public const short DyingNotice = 345;

		/// <summary>
		/// InjuredNotice
		/// </summary>
		public const short InjuredNotice = 346;

		/// <summary>
		/// TrappedNotice
		/// </summary>
		public const short TrappedNotice = 347;

		/// <summary>
		/// SectMainStoryFulongFightSucceed
		/// </summary>
		public const short SectMainStoryFulongFightSucceed = 348;

		/// <summary>
		/// SectMainStoryFulongFightFail
		/// </summary>
		public const short SectMainStoryFulongFightFail = 349;

		/// <summary>
		/// SectMainStoryFulongFamilyFightFail
		/// </summary>
		public const short SectMainStoryFulongFamilyFightFail = 350;

		/// <summary>
		/// SectMainStoryFulongRobbery
		/// </summary>
		public const short SectMainStoryFulongRobbery = 351;

		/// <summary>
		/// SectMainStoryFulongFamilyRobbery
		/// </summary>
		public const short SectMainStoryFulongFamilyRobbery = 352;

		/// <summary>
		/// DeliverInPrison0
		/// </summary>
		public const short DeliverInPrison0 = 353;

		/// <summary>
		/// DeliverInPrison1
		/// </summary>
		public const short DeliverInPrison1 = 354;

		/// <summary>
		/// DieInPrison
		/// </summary>
		public const short DieInPrison = 355;

		/// <summary>
		/// AssassinatedInPrison
		/// </summary>
		public const short AssassinatedInPrison = 356;

		/// <summary>
		/// AssassinatedDueToKillerTokenInPrison
		/// </summary>
		public const short AssassinatedDueToKillerTokenInPrison = 357;

		/// <summary>
		/// ImprisonAndAbandonBaby0
		/// </summary>
		public const short ImprisonAndAbandonBaby0 = 358;

		/// <summary>
		/// ImprisonAndAbandonBaby1
		/// </summary>
		public const short ImprisonAndAbandonBaby1 = 359;

		/// <summary>
		/// ResourceMigration
		/// </summary>
		public const short ResourceMigration = 360;

		/// <summary>
		/// ChickenSecretInformation
		/// </summary>
		public const short ChickenSecretInformation = 361;

		/// <summary>
		/// XiangshuNormalInformation
		/// </summary>
		public const short XiangshuNormalInformation = 362;

		/// <summary>
		/// SectMainStoryFulongFireVanishes
		/// </summary>
		public const short SectMainStoryFulongFireVanishes = 363;

		/// <summary>
		/// SectMainStoryFulongLooting
		/// </summary>
		public const short SectMainStoryFulongLooting = 364;

		/// <summary>
		/// SectMainStoryWudangTreesGrow
		/// </summary>
		public const short SectMainStoryWudangTreesGrow = 365;

		/// <summary>
		/// SectMainStoryZhujianSwordTestCeremony
		/// </summary>
		public const short SectMainStoryZhujianSwordTestCeremony = 366;

		/// <summary>
		/// InvestedCaravanMove
		/// </summary>
		public const short InvestedCaravanMove = 367;

		/// <summary>
		/// InvestedCaravanPassSettlement
		/// </summary>
		public const short InvestedCaravanPassSettlement = 368;

		/// <summary>
		/// InvestedCaravanPassLowCultureSettlement
		/// </summary>
		public const short InvestedCaravanPassLowCultureSettlement = 369;

		/// <summary>
		/// InvestedCaravanPassHighCultureSettlement
		/// </summary>
		public const short InvestedCaravanPassHighCultureSettlement = 370;

		/// <summary>
		/// InvestedCaravanPassLowSafetySettlement
		/// </summary>
		public const short InvestedCaravanPassLowSafetySettlement = 371;

		/// <summary>
		/// InvestedCaravanPassHighSafetySettlement
		/// </summary>
		public const short InvestedCaravanPassHighSafetySettlement = 372;

		/// <summary>
		/// InvestedCaravanPassLowSafetyLowCultureSettlement
		/// </summary>
		public const short InvestedCaravanPassLowSafetyLowCultureSettlement = 373;

		/// <summary>
		/// InvestedCaravanPassLowSafetyHighCultureSettlement
		/// </summary>
		public const short InvestedCaravanPassLowSafetyHighCultureSettlement = 374;

		/// <summary>
		/// InvestedCaravanPassHighSafetyLowCultureSettlement
		/// </summary>
		public const short InvestedCaravanPassHighSafetyLowCultureSettlement = 375;

		/// <summary>
		/// InvestedCaravanPassHighSafetyHighCultureSettlement
		/// </summary>
		public const short InvestedCaravanPassHighSafetyHighCultureSettlement = 376;

		/// <summary>
		/// InvestedCaravanArrive
		/// </summary>
		public const short InvestedCaravanArrive = 377;

		/// <summary>
		/// InvestedCaravanIsRobbed
		/// </summary>
		public const short InvestedCaravanIsRobbed = 378;

		/// <summary>
		/// InvestedCaravanIsRobbedAndFailed
		/// </summary>
		public const short InvestedCaravanIsRobbedAndFailed = 379;

		/// <summary>
		/// BuildingUpgradingHolded
		/// </summary>
		public const short BuildingUpgradingHolded = 380;

		/// <summary>
		/// PunishmentLost0
		/// </summary>
		public const short PunishmentLost0 = 381;

		/// <summary>
		/// PunishmentLost1
		/// </summary>
		public const short PunishmentLost1 = 382;

		/// <summary>
		/// OutsiderMakeHarvest
		/// </summary>
		public const short OutsiderMakeHarvest = 383;

		/// <summary>
		/// TaiwuVillageCraftObjectsFinished
		/// </summary>
		public const short TaiwuVillageCraftObjectsFinished = 384;

		/// <summary>
		/// OutsiderMakeHarvest1
		/// </summary>
		public const short OutsiderMakeHarvest1 = 385;

		/// <summary>
		/// TaiwuVillagerDied
		/// </summary>
		public const short TaiwuVillagerDied = 386;

		/// <summary>
		/// SectMainStoryRemakeEmeiHomocideCase
		/// </summary>
		public const short SectMainStoryRemakeEmeiHomocideCase = 387;

		/// <summary>
		/// SectMainStoryRemakeEmeiRumor
		/// </summary>
		public const short SectMainStoryRemakeEmeiRumor = 388;

		/// <summary>
		/// DieNotice
		/// </summary>
		public const short DieNotice = 389;

		/// <summary>
		/// WantedNotice
		/// </summary>
		public const short WantedNotice = 390;

		/// <summary>
		/// SectMainStoryYuanshanJuemo
		/// </summary>
		public const short SectMainStoryYuanshanJuemo = 391;

		/// <summary>
		/// CoreMaterialIncome
		/// </summary>
		public const short CoreMaterialIncome = 392;

		/// <summary>
		/// FamilyGetInfected
		/// </summary>
		public const short FamilyGetInfected = 393;

		/// <summary>
		/// FamilyDieByInfected
		/// </summary>
		public const short FamilyDieByInfected = 394;

		/// <summary>
		/// FocusedGetInfected
		/// </summary>
		public const short FocusedGetInfected = 395;

		/// <summary>
		/// FocusedDieByInfected
		/// </summary>
		public const short FocusedDieByInfected = 396;

		/// <summary>
		/// NormalVillagersInjured
		/// </summary>
		public const short NormalVillagersInjured = 397;

		/// <summary>
		/// NormalVillagerCasualty
		/// </summary>
		public const short NormalVillagerCasualty = 398;

		/// <summary>
		/// NormalTreesGrow
		/// </summary>
		public const short NormalTreesGrow = 399;

		/// <summary>
		/// VillagerCraftFinished0
		/// </summary>
		public const short VillagerCraftFinished0 = 400;

		/// <summary>
		/// VillagerCraftFinished1
		/// </summary>
		public const short VillagerCraftFinished1 = 401;

		/// <summary>
		/// VillagerCraftFinished2
		/// </summary>
		public const short VillagerCraftFinished2 = 402;

		/// <summary>
		/// VillagerCraftFinished3
		/// </summary>
		public const short VillagerCraftFinished3 = 403;

		/// <summary>
		/// NpcCraftFinished0
		/// </summary>
		public const short NpcCraftFinished0 = 404;

		/// <summary>
		/// NpcCraftFinished1
		/// </summary>
		public const short NpcCraftFinished1 = 405;

		/// <summary>
		/// NpcCraftFinished2
		/// </summary>
		public const short NpcCraftFinished2 = 406;

		/// <summary>
		/// NpcCraftFinished3
		/// </summary>
		public const short NpcCraftFinished3 = 407;

		/// <summary>
		/// NpcLongDistanceMarriage0
		/// </summary>
		public const short NpcLongDistanceMarriage0 = 408;

		/// <summary>
		/// NpcLongDistanceMarriage1
		/// </summary>
		public const short NpcLongDistanceMarriage1 = 409;

		/// <summary>
		/// NpcLongDistanceMarriage2
		/// </summary>
		public const short NpcLongDistanceMarriage2 = 410;

		/// <summary>
		/// WithoutFood
		/// </summary>
		public const short WithoutFood = 411;

		/// <summary>
		/// Escape0
		/// </summary>
		public const short Escape0 = 412;

		/// <summary>
		/// Escape1
		/// </summary>
		public const short Escape1 = 413;

		/// <summary>
		/// EscapeFailed
		/// </summary>
		public const short EscapeFailed = 438;

		/// <summary>
		/// FirstGetInfected0
		/// </summary>
		public const short FirstGetInfected0 = 414;

		/// <summary>
		/// FirstGetInfected1
		/// </summary>
		public const short FirstGetInfected1 = 415;

		/// <summary>
		/// YuanshanSpiritCrisis
		/// </summary>
		public const short YuanshanSpiritCrisis = 416;

		/// <summary>
		/// YuanshanDemonCrisis
		/// </summary>
		public const short YuanshanDemonCrisis = 417;

		/// <summary>
		/// PlotPoisonedEnemyEscaped
		/// </summary>
		public const short PlotPoisonedEnemyEscaped = 418;

		/// <summary>
		/// PlotHarmEnemyEscaped
		/// </summary>
		public const short PlotHarmEnemyEscaped = 419;

		/// <summary>
		/// GoingToAppointment
		/// </summary>
		public const short GoingToAppointment = 420;

		/// <summary>
		/// SectMainStoryXuehouJixiDrainPeople
		/// </summary>
		public const short SectMainStoryXuehouJixiDrainPeople = 421;

		/// <summary>
		/// SectMainStoryXuehouJixiDrainFail
		/// </summary>
		public const short SectMainStoryXuehouJixiDrainFail = 422;

		/// <summary>
		/// SectMainStoryXuehouTaiwuTransferFiveElements
		/// </summary>
		public const short SectMainStoryXuehouTaiwuTransferFiveElements = 423;

		/// <summary>
		/// SectMainStoryXuehouTaiwuTransferFiveElementsFail
		/// </summary>
		public const short SectMainStoryXuehouTaiwuTransferFiveElementsFail = 424;

		/// <summary>
		/// SectMainStoryXuehouJixiDrainNeili
		/// </summary>
		public const short SectMainStoryXuehouJixiDrainNeili = 425;

		/// <summary>
		/// SectMainStoryXuehouJixiDrainNeiliFail
		/// </summary>
		public const short SectMainStoryXuehouJixiDrainNeiliFail = 426;

		/// <summary>
		/// SectMainStoryXuehouTaiwuTransFiveElements
		/// </summary>
		public const short SectMainStoryXuehouTaiwuTransFiveElements = 427;

		/// <summary>
		/// SectMainStoryXuehouTaiwuTransFiveElementsFail
		/// </summary>
		public const short SectMainStoryXuehouTaiwuTransFiveElementsFail = 428;

		/// <summary>
		/// SectMainStoryXuehouJixiDrainNeiliFail1
		/// </summary>
		public const short SectMainStoryXuehouJixiDrainNeiliFail1 = 429;

		/// <summary>
		/// SectMainStoryXuehouJixiDrainNeiliFail2
		/// </summary>
		public const short SectMainStoryXuehouJixiDrainNeiliFail2 = 430;

		/// <summary>
		/// SectMainStoryXuehouJixiDrainNeiliFail3
		/// </summary>
		public const short SectMainStoryXuehouJixiDrainNeiliFail3 = 431;

		/// <summary>
		/// ChallengeModeAdvanceMonthWorsenInjuryOuter
		/// </summary>
		public const short ChallengeModeAdvanceMonthWorsenInjuryOuter = 432;

		/// <summary>
		/// ChallengeModeAdvanceMonthWorsenInjuryInner
		/// </summary>
		public const short ChallengeModeAdvanceMonthWorsenInjuryInner = 433;

		/// <summary>
		/// ChallengeModeAdvanceMonthWorsenPoison
		/// </summary>
		public const short ChallengeModeAdvanceMonthWorsenPoison = 434;

		/// <summary>
		/// ChickenFullyFledged
		/// </summary>
		public const short ChickenFullyFledged = 435;

		/// <summary>
		/// CostResourceNotEnough
		/// </summary>
		public const short CostResourceNotEnough = 436;

		/// <summary>
		/// CostResourceNotEnoughResult
		/// </summary>
		public const short CostResourceNotEnoughResult = 437;

		/// <summary>
		/// CricketGrowUp
		/// </summary>
		public const short CricketGrowUp = 439;

		/// <summary>
		/// KillRighteousRandomEnemyVillager
		/// </summary>
		public const short KillRighteousRandomEnemyVillager = 440;

		/// <summary>
		/// DefeatedByRighteousRandomEnemyVillager
		/// </summary>
		public const short DefeatedByRighteousRandomEnemyVillager = 441;

		/// <summary>
		/// KillHereticRandomEnemyVillager
		/// </summary>
		public const short KillHereticRandomEnemyVillager = 442;

		/// <summary>
		/// DefeatedByHereticRandomEnemyVillager
		/// </summary>
		public const short DefeatedByHereticRandomEnemyVillager = 443;

		/// <summary>
		/// KillAnimalVillager
		/// </summary>
		public const short KillAnimalVillager = 444;

		/// <summary>
		/// DefeatedByAnimalVillager
		/// </summary>
		public const short DefeatedByAnimalVillager = 445;

		/// <summary>
		/// DieFromEnemyNestVillager
		/// </summary>
		public const short DieFromEnemyNestVillager = 446;

		/// <summary>
		/// EscapeFromEnemyNestVillager
		/// </summary>
		public const short EscapeFromEnemyNestVillager = 447;

		/// <summary>
		/// SavedFromEnemyNestVillager
		/// </summary>
		public const short SavedFromEnemyNestVillager = 448;

		/// <summary>
		/// InfectedKidnapedCharacterEscape
		/// </summary>
		public const short InfectedKidnapedCharacterEscape = 449;

		/// <summary>
		/// OwningBookKidnapedCharacterEscape
		/// </summary>
		public const short OwningBookKidnapedCharacterEscape = 450;

		/// <summary>
		/// SectMainStoryEmeiStrangerAttack
		/// </summary>
		public const short SectMainStoryEmeiStrangerAttack = 451;

		/// <summary>
		/// SectMainStoryEmeiInsaneMember
		/// </summary>
		public const short SectMainStoryEmeiInsaneMember = 452;

		/// <summary>
		/// SectMainStoryEmeiRumors
		/// </summary>
		public const short SectMainStoryEmeiRumors = 453;

		/// <summary>
		/// SectMainStoryEmeiReputation
		/// </summary>
		public const short SectMainStoryEmeiReputation = 454;

		/// <summary>
		/// SectMainStoryEmeiSecretBook
		/// </summary>
		public const short SectMainStoryEmeiSecretBook = 455;

		/// <summary>
		/// SectMainStoryJieqingUpgradeXingYun
		/// </summary>
		public const short SectMainStoryJieqingUpgradeXingYun = 456;

		/// <summary>
		/// MainStoryImmortalWuFanKe
		/// </summary>
		public const short MainStoryImmortalWuFanKe = 457;

		/// <summary>
		/// MainStoryImmortalDianFanMo
		/// </summary>
		public const short MainStoryImmortalDianFanMo = 458;

		/// <summary>
		/// AdventureCapitalCity
		/// </summary>
		public const short AdventureCapitalCity = 459;

		/// <summary>
		/// SmallMarketAppeared
		/// </summary>
		public const short SmallMarketAppeared = 460;

		/// <summary>
		/// AdventureJieqi
		/// </summary>
		public const short AdventureJieqi = 461;

		/// <summary>
		/// AdventureTeaParty
		/// </summary>
		public const short AdventureTeaParty = 462;

		/// <summary>
		/// AdventureWineParty
		/// </summary>
		public const short AdventureWineParty = 463;

		/// <summary>
		/// AdventureMartialHall
		/// </summary>
		public const short AdventureMartialHall = 464;

		/// <summary>
		/// AdventureMissionReward
		/// </summary>
		public const short AdventureMissionReward = 465;

		/// <summary>
		/// AdventureWorldSecretRealm
		/// </summary>
		public const short AdventureWorldSecretRealm = 466;

		/// <summary>
		/// AdventureJieqiComing
		/// </summary>
		public const short AdventureJieqiComing = 467;

		/// <summary>
		/// BehaviorTypeAction1
		/// </summary>
		public const short BehaviorTypeAction1 = 468;

		/// <summary>
		/// BehaviorTypeAction2
		/// </summary>
		public const short BehaviorTypeAction2 = 469;

		/// <summary>
		/// NewMarketAppeared
		/// </summary>
		public const short NewMarketAppeared = 470;

		/// <summary>
		/// PreciousMaterial
		/// </summary>
		public const short PreciousMaterial = 471;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// SolarTerm0
		/// </summary>
		public static MonthlyNotificationItem SolarTerm0 => Instance[(short)0];

		/// <summary>
		/// SolarTerm1
		/// </summary>
		public static MonthlyNotificationItem SolarTerm1 => Instance[(short)1];

		/// <summary>
		/// SolarTerm2
		/// </summary>
		public static MonthlyNotificationItem SolarTerm2 => Instance[(short)2];

		/// <summary>
		/// SolarTerm3
		/// </summary>
		public static MonthlyNotificationItem SolarTerm3 => Instance[(short)3];

		/// <summary>
		/// SolarTerm4
		/// </summary>
		public static MonthlyNotificationItem SolarTerm4 => Instance[(short)4];

		/// <summary>
		/// SolarTerm5
		/// </summary>
		public static MonthlyNotificationItem SolarTerm5 => Instance[(short)5];

		/// <summary>
		/// SolarTerm6
		/// </summary>
		public static MonthlyNotificationItem SolarTerm6 => Instance[(short)6];

		/// <summary>
		/// SolarTerm7
		/// </summary>
		public static MonthlyNotificationItem SolarTerm7 => Instance[(short)7];

		/// <summary>
		/// SolarTerm8
		/// </summary>
		public static MonthlyNotificationItem SolarTerm8 => Instance[(short)8];

		/// <summary>
		/// SolarTerm9
		/// </summary>
		public static MonthlyNotificationItem SolarTerm9 => Instance[(short)9];

		/// <summary>
		/// SolarTerm10
		/// </summary>
		public static MonthlyNotificationItem SolarTerm10 => Instance[(short)10];

		/// <summary>
		/// SolarTerm11
		/// </summary>
		public static MonthlyNotificationItem SolarTerm11 => Instance[(short)11];

		/// <summary>
		/// GraveDestroyed
		/// </summary>
		public static MonthlyNotificationItem GraveDestroyed => Instance[(short)12];

		/// <summary>
		/// IncomeFromNest
		/// </summary>
		public static MonthlyNotificationItem IncomeFromNest => Instance[(short)13];

		/// <summary>
		/// LoseItemCausedByWarehouseFull
		/// </summary>
		public static MonthlyNotificationItem LoseItemCausedByWarehouseFull => Instance[(short)14];

		/// <summary>
		/// Assassinated
		/// </summary>
		public static MonthlyNotificationItem Assassinated => Instance[(short)15];

		/// <summary>
		/// AssassinatedDueToKillerToken
		/// </summary>
		public static MonthlyNotificationItem AssassinatedDueToKillerToken => Instance[(short)16];

		/// <summary>
		/// Die
		/// </summary>
		public static MonthlyNotificationItem Die => Instance[(short)17];

		/// <summary>
		/// InfectXiangshuPartially
		/// </summary>
		public static MonthlyNotificationItem InfectXiangshuPartially => Instance[(short)18];

		/// <summary>
		/// InfectXiangshuCompletely
		/// </summary>
		public static MonthlyNotificationItem InfectXiangshuCompletely => Instance[(short)19];

		/// <summary>
		/// CreateHatredInPrison
		/// </summary>
		public static MonthlyNotificationItem CreateHatredByPrison => Instance[(short)20];

		/// <summary>
		/// EscapeFromPrison
		/// </summary>
		public static MonthlyNotificationItem EscapeFromPrison => Instance[(short)21];

		/// <summary>
		/// CricketEndLife
		/// </summary>
		public static MonthlyNotificationItem CricketEndLife => Instance[(short)22];

		/// <summary>
		/// LoseResourceCausedByInventoryFull
		/// </summary>
		public static MonthlyNotificationItem LoseResourceCausedByInventoryFull => Instance[(short)23];

		/// <summary>
		/// LoseItemCausedByInventoryFull
		/// </summary>
		public static MonthlyNotificationItem LoseItemCausedByInventoryFull => Instance[(short)24];

		/// <summary>
		/// CreateHatred
		/// </summary>
		public static MonthlyNotificationItem CreateHatred => Instance[(short)25];

		/// <summary>
		/// DecreaseHatred
		/// </summary>
		public static MonthlyNotificationItem DecreaseHatred => Instance[(short)26];

		/// <summary>
		/// ConfessLoveAndSucceed
		/// </summary>
		public static MonthlyNotificationItem ConfessLoveAndSucceed => Instance[(short)27];

		/// <summary>
		/// SeverLove
		/// </summary>
		public static MonthlyNotificationItem SeverLove => Instance[(short)28];

		/// <summary>
		/// Marriage
		/// </summary>
		public static MonthlyNotificationItem Marriage => Instance[(short)29];

		/// <summary>
		/// BecomeFriend
		/// </summary>
		public static MonthlyNotificationItem BecomeFriend => Instance[(short)30];

		/// <summary>
		/// DecreaseFriendship
		/// </summary>
		public static MonthlyNotificationItem DecreaseFriendship => Instance[(short)31];

		/// <summary>
		/// BecomeSwornBrotherOrSister
		/// </summary>
		public static MonthlyNotificationItem BecomeSwornBrotherOrSister => Instance[(short)32];

		/// <summary>
		/// SeverFriendship
		/// </summary>
		public static MonthlyNotificationItem SeverFriendship => Instance[(short)33];

		/// <summary>
		/// AdoptBoy
		/// </summary>
		public static MonthlyNotificationItem AdoptBoy => Instance[(short)34];

		/// <summary>
		/// AdoptGirl
		/// </summary>
		public static MonthlyNotificationItem AdoptGirl => Instance[(short)35];

		/// <summary>
		/// RecognizeFather
		/// </summary>
		public static MonthlyNotificationItem RecognizeFather => Instance[(short)36];

		/// <summary>
		/// RecognizeMother
		/// </summary>
		public static MonthlyNotificationItem RecognizeMother => Instance[(short)37];

		/// <summary>
		/// MakeLove
		/// </summary>
		public static MonthlyNotificationItem MakeLove => Instance[(short)38];

		/// <summary>
		/// RapeFailure
		/// </summary>
		public static MonthlyNotificationItem RapeFailure => Instance[(short)39];

		/// <summary>
		/// MotherGiveBirthToBoy
		/// </summary>
		public static MonthlyNotificationItem MotherGiveBirthToBoy => Instance[(short)40];

		/// <summary>
		/// MotherGiveBirthToGirl
		/// </summary>
		public static MonthlyNotificationItem MotherGiveBirthToGirl => Instance[(short)41];

		/// <summary>
		/// FatherGetBoy
		/// </summary>
		public static MonthlyNotificationItem FatherGetBoy => Instance[(short)42];

		/// <summary>
		/// FatherGetGirl
		/// </summary>
		public static MonthlyNotificationItem FatherGetGirl => Instance[(short)43];

		/// <summary>
		/// GiveBirthToCricket
		/// </summary>
		public static MonthlyNotificationItem GiveBirthToCricket => Instance[(short)44];

		/// <summary>
		/// MotherLoseFetus
		/// </summary>
		public static MonthlyNotificationItem MotherLoseFetus => Instance[(short)45];

		/// <summary>
		/// GoToJoinOrganization
		/// </summary>
		public static MonthlyNotificationItem GoToJoinOrganization => Instance[(short)46];

		/// <summary>
		/// JoinOrganization
		/// </summary>
		public static MonthlyNotificationItem JoinOrganization => Instance[(short)47];

		/// <summary>
		/// GoToAppointment
		/// </summary>
		public static MonthlyNotificationItem GoToAppointment => Instance[(short)48];

		/// <summary>
		/// WaitingForAppointment
		/// </summary>
		public static MonthlyNotificationItem WaitingForAppointment => Instance[(short)49];

		/// <summary>
		/// AppointmentExpired
		/// </summary>
		public static MonthlyNotificationItem AppointmentExpired => Instance[(short)50];

		/// <summary>
		/// AppointmentCancelled
		/// </summary>
		public static MonthlyNotificationItem AppointmentCancelled => Instance[(short)51];

		/// <summary>
		/// GoToRescue
		/// </summary>
		public static MonthlyNotificationItem GoToRescue => Instance[(short)52];

		/// <summary>
		/// RescuePrisoner
		/// </summary>
		public static MonthlyNotificationItem RescuePrisoner => Instance[(short)53];

		/// <summary>
		/// ReleasePrisoner
		/// </summary>
		public static MonthlyNotificationItem ReleasePrisoner => Instance[(short)54];

		/// <summary>
		/// Disappear
		/// </summary>
		public static MonthlyNotificationItem Disappear => Instance[(short)55];

		/// <summary>
		/// GoToRevenge
		/// </summary>
		public static MonthlyNotificationItem GoToRevenge => Instance[(short)56];

		/// <summary>
		/// GoToProtect
		/// </summary>
		public static MonthlyNotificationItem GoToProtect => Instance[(short)57];

		/// <summary>
		/// ProtectRelativeOrFriend
		/// </summary>
		public static MonthlyNotificationItem ProtectRelativeOrFriend => Instance[(short)58];

		/// <summary>
		/// SectUpgrade
		/// </summary>
		public static MonthlyNotificationItem SectUpgrade => Instance[(short)59];

		/// <summary>
		/// CivilianSettlementUpgrade
		/// </summary>
		public static MonthlyNotificationItem CivilianSettlementUpgrade => Instance[(short)60];

		/// <summary>
		/// FactionUpgrade
		/// </summary>
		public static MonthlyNotificationItem FactionUpgrade => Instance[(short)61];

		/// <summary>
		/// StealResourceFailure
		/// </summary>
		public static MonthlyNotificationItem StealResourceFailure => Instance[(short)62];

		/// <summary>
		/// StealResourceSuccess
		/// </summary>
		public static MonthlyNotificationItem StealResourceSuccess => Instance[(short)63];

		/// <summary>
		/// CheatResourceFailure
		/// </summary>
		public static MonthlyNotificationItem CheatResourceFailure => Instance[(short)64];

		/// <summary>
		/// RobResourceFailure
		/// </summary>
		public static MonthlyNotificationItem RobResourceFailure => Instance[(short)65];

		/// <summary>
		/// DigResource
		/// </summary>
		public static MonthlyNotificationItem DigResource => Instance[(short)66];

		/// <summary>
		/// StealItemFailure
		/// </summary>
		public static MonthlyNotificationItem StealItemFailure => Instance[(short)67];

		/// <summary>
		/// StealItemSuccess
		/// </summary>
		public static MonthlyNotificationItem StealItemSuccess => Instance[(short)68];

		/// <summary>
		/// CheatItemFailure
		/// </summary>
		public static MonthlyNotificationItem CheatItemFailure => Instance[(short)69];

		/// <summary>
		/// RobItemFailure
		/// </summary>
		public static MonthlyNotificationItem RobItemFailure => Instance[(short)70];

		/// <summary>
		/// DigItem
		/// </summary>
		public static MonthlyNotificationItem DigItem => Instance[(short)71];

		/// <summary>
		/// StealLifeSkillFailure
		/// </summary>
		public static MonthlyNotificationItem StealLifeSkillFailure => Instance[(short)72];

		/// <summary>
		/// StealLifeSkillSuccess
		/// </summary>
		public static MonthlyNotificationItem StealLifeSkillSuccess => Instance[(short)73];

		/// <summary>
		/// CheatLifeSkillFailure
		/// </summary>
		public static MonthlyNotificationItem CheatLifeSkillFailure => Instance[(short)74];

		/// <summary>
		/// StealCombatSkillFailure
		/// </summary>
		public static MonthlyNotificationItem StealCombatSkillFailure => Instance[(short)75];

		/// <summary>
		/// StealCombatSkillSuccess
		/// </summary>
		public static MonthlyNotificationItem StealCombatSkillSuccess => Instance[(short)76];

		/// <summary>
		/// CheatCombatSkillFailure
		/// </summary>
		public static MonthlyNotificationItem CheatCombatSkillFailure => Instance[(short)77];

		/// <summary>
		/// GivePresentResource
		/// </summary>
		public static MonthlyNotificationItem GivePresentResource => Instance[(short)78];

		/// <summary>
		/// GivePresentItem
		/// </summary>
		public static MonthlyNotificationItem GivePresentItem => Instance[(short)79];

		/// <summary>
		/// TeachLifeSkillSuccess
		/// </summary>
		public static MonthlyNotificationItem TeachLifeSkillSuccess => Instance[(short)80];

		/// <summary>
		/// TeachLifeSkillFailure
		/// </summary>
		public static MonthlyNotificationItem TeachLifeSkillFailure => Instance[(short)81];

		/// <summary>
		/// TeachCombatSkillSuccess
		/// </summary>
		public static MonthlyNotificationItem TeachCombatSkillSuccess => Instance[(short)82];

		/// <summary>
		/// TeachCombatSkillFailure
		/// </summary>
		public static MonthlyNotificationItem TeachCombatSkillFailure => Instance[(short)83];

		/// <summary>
		/// AmuseOthersByMusic
		/// </summary>
		public static MonthlyNotificationItem AmuseOthersByMusic => Instance[(short)84];

		/// <summary>
		/// AmuseOthersByChess
		/// </summary>
		public static MonthlyNotificationItem AmuseOthersByChess => Instance[(short)85];

		/// <summary>
		/// AmuseOthersByPoem
		/// </summary>
		public static MonthlyNotificationItem AmuseOthersByPoem => Instance[(short)86];

		/// <summary>
		/// AmuseOthersByPainting
		/// </summary>
		public static MonthlyNotificationItem AmuseOthersByPainting => Instance[(short)87];

		/// <summary>
		/// MakeFamousItem
		/// </summary>
		public static MonthlyNotificationItem MakeFamousItem => Instance[(short)88];

		/// <summary>
		/// EnlightenedByDaoism
		/// </summary>
		public static MonthlyNotificationItem EnlightenedByDaoism => Instance[(short)89];

		/// <summary>
		/// EnlightenedByBuddhism
		/// </summary>
		public static MonthlyNotificationItem EnlightenedByBuddhism => Instance[(short)90];

		/// <summary>
		/// PractiseDivination
		/// </summary>
		public static MonthlyNotificationItem PractiseDivination => Instance[(short)91];

		/// <summary>
		/// UnexpectedlyGetRareItem
		/// </summary>
		public static MonthlyNotificationItem UnexpectedlyGetRareItem => Instance[(short)92];

		/// <summary>
		/// UnexpectedlyGetResource
		/// </summary>
		public static MonthlyNotificationItem UnexpectedlyGetResource => Instance[(short)93];

		/// <summary>
		/// UnexpectedlyGetCombatSkill
		/// </summary>
		public static MonthlyNotificationItem UnexpectedlyGetCombatSkill => Instance[(short)94];

		/// <summary>
		/// UnexpectedlyGetLifeSkill
		/// </summary>
		public static MonthlyNotificationItem UnexpectedlyGetLifeSkill => Instance[(short)95];

		/// <summary>
		/// UnexpectedlyGetHealth
		/// </summary>
		public static MonthlyNotificationItem UnexpectedlyGetHealth => Instance[(short)96];

		/// <summary>
		/// UnexpectedlyHealOuterInjury
		/// </summary>
		public static MonthlyNotificationItem UnexpectedlyHealOuterInjury => Instance[(short)97];

		/// <summary>
		/// UnexpectedlyHealInneInjury
		/// </summary>
		public static MonthlyNotificationItem UnexpectedlyHealInnerInjury => Instance[(short)98];

		/// <summary>
		/// UnexpectedlyHealPoison
		/// </summary>
		public static MonthlyNotificationItem UnexpectedlyHealPoison => Instance[(short)99];

		/// <summary>
		/// UnexpectedlyHealQi
		/// </summary>
		public static MonthlyNotificationItem UnexpectedlyHealQi => Instance[(short)100];

		/// <summary>
		/// UnexpectedlyLoseRareItem
		/// </summary>
		public static MonthlyNotificationItem UnexpectedlyLoseRareItem => Instance[(short)101];

		/// <summary>
		/// UnexpectedlyLoseResource
		/// </summary>
		public static MonthlyNotificationItem UnexpectedlyLoseResource => Instance[(short)102];

		/// <summary>
		/// UnexpectedlyLoseCombatSkill
		/// </summary>
		public static MonthlyNotificationItem UnexpectedlyLoseCombatSkill => Instance[(short)103];

		/// <summary>
		/// UnexpectedlyLoseLifeSkill
		/// </summary>
		public static MonthlyNotificationItem UnexpectedlyLoseLifeSkill => Instance[(short)104];

		/// <summary>
		/// UnexpectedlyLoseHealth
		/// </summary>
		public static MonthlyNotificationItem UnexpectedlyLoseHealth => Instance[(short)105];

		/// <summary>
		/// UnexpectedlySufferOuterInjury
		/// </summary>
		public static MonthlyNotificationItem UnexpectedlySufferOuterInjury => Instance[(short)106];

		/// <summary>
		/// UnexpectedlySufferInneInjury
		/// </summary>
		public static MonthlyNotificationItem UnexpectedlySufferInneInjury => Instance[(short)107];

		/// <summary>
		/// UnexpectedlySufferPoison
		/// </summary>
		public static MonthlyNotificationItem UnexpectedlySufferPoison => Instance[(short)108];

		/// <summary>
		/// UnexpectedlySufferDisorderOfQi
		/// </summary>
		public static MonthlyNotificationItem UnexpectedlySufferDisorderOfQi => Instance[(short)109];

		/// <summary>
		/// BuildingResourceIncreased
		/// </summary>
		public static MonthlyNotificationItem BuildingResourceIncreased => Instance[(short)110];

		/// <summary>
		/// BuildingResourceSpread
		/// </summary>
		public static MonthlyNotificationItem BuildingResourceSpread => Instance[(short)111];

		/// <summary>
		/// BuildingDamaged
		/// </summary>
		public static MonthlyNotificationItem BuildingDamaged => Instance[(short)112];

		/// <summary>
		/// BuildingRuined
		/// </summary>
		public static MonthlyNotificationItem BuildingRuined => Instance[(short)113];

		/// <summary>
		/// BuildingConstructionCompleted
		/// </summary>
		public static MonthlyNotificationItem BuildingConstructionCompleted => Instance[(short)114];

		/// <summary>
		/// BuildingUpgradingCompleted
		/// </summary>
		public static MonthlyNotificationItem BuildingUpgradingCompleted => Instance[(short)115];

		/// <summary>
		/// BuildingDemolitionCompleted
		/// </summary>
		public static MonthlyNotificationItem BuildingDemolitionCompleted => Instance[(short)116];

		/// <summary>
		/// BuildingIncome
		/// </summary>
		public static MonthlyNotificationItem BuildingIncome => Instance[(short)117];

		/// <summary>
		/// DispatchInPlace
		/// </summary>
		public static MonthlyNotificationItem DispatchInPlace => Instance[(short)118];

		/// <summary>
		/// FindViciousBeggarsNest
		/// </summary>
		public static MonthlyNotificationItem FindViciousBeggarsNest => Instance[(short)119];

		/// <summary>
		/// FindThievesCamp
		/// </summary>
		public static MonthlyNotificationItem FindThievesCamp => Instance[(short)120];

		/// <summary>
		/// FindBanditsStronghold
		/// </summary>
		public static MonthlyNotificationItem FindBanditsStronghold => Instance[(short)121];

		/// <summary>
		/// FindTraitorsGang
		/// </summary>
		public static MonthlyNotificationItem FindTraitorsGang => Instance[(short)122];

		/// <summary>
		/// FindVillainsValley
		/// </summary>
		public static MonthlyNotificationItem FindVillainsValley => Instance[(short)123];

		/// <summary>
		/// FindMixiangzhen
		/// </summary>
		public static MonthlyNotificationItem FindMixiangzhen => Instance[(short)124];

		/// <summary>
		/// FindMassGrave
		/// </summary>
		public static MonthlyNotificationItem FindMassGrave => Instance[(short)125];

		/// <summary>
		/// FindHereticHome
		/// </summary>
		public static MonthlyNotificationItem FindHereticHome => Instance[(short)126];

		/// <summary>
		/// KidnappedByHeresy
		/// </summary>
		public static MonthlyNotificationItem KidnappedByHeresy => Instance[(short)127];

		/// <summary>
		/// KidnappedByHeart
		/// </summary>
		public static MonthlyNotificationItem KidnappedByHeart => Instance[(short)128];

		/// <summary>
		/// KidnappedBySoumoulou
		/// </summary>
		public static MonthlyNotificationItem KidnappedBySoumoulou => Instance[(short)129];

		/// <summary>
		/// KidnappedByWorldWeary
		/// </summary>
		public static MonthlyNotificationItem KidnappedByWorldWeary => Instance[(short)130];

		/// <summary>
		/// MarketAppeared
		/// </summary>
		public static MonthlyNotificationItem MarketAppeared => Instance[(short)131];

		/// <summary>
		/// TownCombatAppeared
		/// </summary>
		public static MonthlyNotificationItem TownCombatAppeared => Instance[(short)132];

		/// <summary>
		/// CricketsAppeared
		/// </summary>
		public static MonthlyNotificationItem CricketsAppeared => Instance[(short)133];

		/// <summary>
		/// StartCricketContest
		/// </summary>
		public static MonthlyNotificationItem StartCricketContest => Instance[(short)134];

		/// <summary>
		/// LifeCompetitionAppeared
		/// </summary>
		public static MonthlyNotificationItem LifeCompetitionAppeared => Instance[(short)135];

		/// <summary>
		/// StartSectJuniorContest
		/// </summary>
		public static MonthlyNotificationItem StartSectJuniorContest => Instance[(short)136];

		/// <summary>
		/// StartSectIntermediateContest
		/// </summary>
		public static MonthlyNotificationItem StartSectIntermediateContest => Instance[(short)137];

		/// <summary>
		/// StartSectSeniorContest
		/// </summary>
		public static MonthlyNotificationItem StartSectSeniorContest => Instance[(short)138];

		/// <summary>
		/// JoustForSpouse
		/// </summary>
		public static MonthlyNotificationItem JoustForSpouse => Instance[(short)139];

		/// <summary>
		/// MarryNotice
		/// </summary>
		public static MonthlyNotificationItem MarryNotice => Instance[(short)140];

		/// <summary>
		/// XiangshuAvatarAppeared
		/// </summary>
		public static MonthlyNotificationItem XiangshuAvatarAppeared => Instance[(short)141];

		/// <summary>
		/// MonvBringDisaster
		/// </summary>
		public static MonthlyNotificationItem MonvBringDisaster => Instance[(short)142];

		/// <summary>
		/// DayueYaochangBringDisaster
		/// </summary>
		public static MonthlyNotificationItem DayueYaochangBringDisaster => Instance[(short)143];

		/// <summary>
		/// JiuhanvBringDisaster
		/// </summary>
		public static MonthlyNotificationItem JiuhanvBringDisaster => Instance[(short)144];

		/// <summary>
		/// JinHuangervBringDisaster
		/// </summary>
		public static MonthlyNotificationItem JinHuangervBringDisaster => Instance[(short)145];

		/// <summary>
		/// YiYihouvBringDisaster
		/// </summary>
		public static MonthlyNotificationItem YiYihouvBringDisaster => Instance[(short)146];

		/// <summary>
		/// WeiQivBringDisaster
		/// </summary>
		public static MonthlyNotificationItem WeiQivBringDisaster => Instance[(short)147];

		/// <summary>
		/// YixiangvBringDisaster
		/// </summary>
		public static MonthlyNotificationItem YixiangvBringDisaster => Instance[(short)148];

		/// <summary>
		/// XuefengBringDisaster
		/// </summary>
		public static MonthlyNotificationItem XuefengBringDisaster => Instance[(short)149];

		/// <summary>
		/// ShuFangvBringDisaster
		/// </summary>
		public static MonthlyNotificationItem ShuFangvBringDisaster => Instance[(short)150];

		/// <summary>
		/// MonvSaveSuffering
		/// </summary>
		public static MonthlyNotificationItem MonvSaveSuffering => Instance[(short)151];

		/// <summary>
		/// DayueYaochangSaveSuffering
		/// </summary>
		public static MonthlyNotificationItem DayueYaochangSaveSuffering => Instance[(short)152];

		/// <summary>
		/// JiuhanvSaveSuffering
		/// </summary>
		public static MonthlyNotificationItem JiuhanvSaveSuffering => Instance[(short)153];

		/// <summary>
		/// JinHuangervSaveSuffering
		/// </summary>
		public static MonthlyNotificationItem JinHuangervSaveSuffering => Instance[(short)154];

		/// <summary>
		/// YiYihouvSaveSuffering
		/// </summary>
		public static MonthlyNotificationItem YiYihouvSaveSuffering => Instance[(short)155];

		/// <summary>
		/// WeiQivSaveSuffering
		/// </summary>
		public static MonthlyNotificationItem WeiQivSaveSuffering => Instance[(short)156];

		/// <summary>
		/// YixiangvSaveSuffering
		/// </summary>
		public static MonthlyNotificationItem YixiangvSaveSuffering => Instance[(short)157];

		/// <summary>
		/// XuefengSaveSuffering
		/// </summary>
		public static MonthlyNotificationItem XuefengSaveSuffering => Instance[(short)158];

		/// <summary>
		/// ShuFangvSaveSuffering
		/// </summary>
		public static MonthlyNotificationItem ShuFangvSaveSuffering => Instance[(short)159];

		/// <summary>
		/// CivilianDisappear
		/// </summary>
		public static MonthlyNotificationItem CivilianDisappear => Instance[(short)160];

		/// <summary>
		/// MerchantGoTravelling
		/// </summary>
		public static MonthlyNotificationItem MerchantGoTravelling => Instance[(short)161];

		/// <summary>
		/// ChickenEscaped
		/// </summary>
		public static MonthlyNotificationItem ChickenEscaped => Instance[(short)162];

		/// <summary>
		/// NaturalDisasterOccurred
		/// </summary>
		public static MonthlyNotificationItem NaturalDisasterOccurred => Instance[(short)163];

		/// <summary>
		/// Reincarnation
		/// </summary>
		public static MonthlyNotificationItem Reincarnation => Instance[(short)164];

		/// <summary>
		/// AccumulatedSkillPowerLost
		/// </summary>
		public static MonthlyNotificationItem AccumulatedSkillPowerLost => Instance[(short)165];

		/// <summary>
		/// TaiwuVillageDestructed
		/// </summary>
		public static MonthlyNotificationItem TaiwuVillageDestructed => Instance[(short)166];

		/// <summary>
		/// RebirthAsJuniorXiangshu
		/// </summary>
		public static MonthlyNotificationItem RebirthAsJuniorXiangshu => Instance[(short)167];

		/// <summary>
		/// LegendaryBookAppeared
		/// </summary>
		public static MonthlyNotificationItem LegendaryBookAppeared => Instance[(short)168];

		/// <summary>
		/// WulinConferenceWithoutParticipant
		/// </summary>
		public static MonthlyNotificationItem WulinConferenceWithoutParticipant => Instance[(short)169];

		/// <summary>
		/// WulinConferenceInPreparing
		/// </summary>
		public static MonthlyNotificationItem WulinConferenceInPreparing => Instance[(short)170];

		/// <summary>
		/// WulinConferenceInProgress
		/// </summary>
		public static MonthlyNotificationItem WulinConferenceInProgress => Instance[(short)171];

		/// <summary>
		/// XiangshuKilling
		/// </summary>
		public static MonthlyNotificationItem XiangshuKilling => Instance[(short)172];

		/// <summary>
		/// MonthlyNormalInformation
		/// </summary>
		public static MonthlyNotificationItem MonthlyNormalInformation => Instance[(short)173];

		/// <summary>
		/// MonthlySecretInformation
		/// </summary>
		public static MonthlyNotificationItem MonthlySecretInformation => Instance[(short)174];

		/// <summary>
		/// SecretInformationWillExpire
		/// </summary>
		public static MonthlyNotificationItem SecretInformationWillExpire => Instance[(short)175];

		/// <summary>
		/// SecretInformationExpired
		/// </summary>
		public static MonthlyNotificationItem SecretInformationExpired => Instance[(short)176];

		/// <summary>
		/// YirenAppearInTaiwuArea
		/// </summary>
		public static MonthlyNotificationItem YirenAppearInTaiwuArea => Instance[(short)177];

		/// <summary>
		/// WesternMerchantBackAfterLong
		/// </summary>
		public static MonthlyNotificationItem WesternMerchantBackAfterLong => Instance[(short)178];

		/// <summary>
		/// WesternMerchantLoseContact
		/// </summary>
		public static MonthlyNotificationItem WesternMerchantLoseContact => Instance[(short)179];

		/// <summary>
		/// WesternMerchantBackSucceed
		/// </summary>
		public static MonthlyNotificationItem WesternMerchantBackSucceed => Instance[(short)180];

		/// <summary>
		/// GainAuthority
		/// </summary>
		public static MonthlyNotificationItem GainAuthority => Instance[(short)181];

		/// <summary>
		/// FemaleJoustForSpouseReady
		/// </summary>
		public static MonthlyNotificationItem FemaleJoustForSpouseReady => Instance[(short)182];

		/// <summary>
		/// StartSectNormalCompetition
		/// </summary>
		public static MonthlyNotificationItem StartSectNormalCompetition => Instance[(short)183];

		/// <summary>
		/// EscapeWithForeverLover
		/// </summary>
		public static MonthlyNotificationItem EscapeWithForeverLover => Instance[(short)184];

		/// <summary>
		/// DisasterAndPreciousMaterial
		/// </summary>
		public static MonthlyNotificationItem DisasterAndPreciousMaterial => Instance[(short)185];

		/// <summary>
		/// HeroesDefendMorality
		/// </summary>
		public static MonthlyNotificationItem HeroesDefendMorality => Instance[(short)186];

		/// <summary>
		/// IncomeFromNestViciousBeggars
		/// </summary>
		public static MonthlyNotificationItem IncomeFromNestViciousBeggars => Instance[(short)187];

		/// <summary>
		/// IncomeFromNestThievesCamp
		/// </summary>
		public static MonthlyNotificationItem IncomeFromNestThievesCamp => Instance[(short)188];

		/// <summary>
		/// IncomeFromNestBanditsStronghold
		/// </summary>
		public static MonthlyNotificationItem IncomeFromNestBanditsStronghold => Instance[(short)189];

		/// <summary>
		/// IncomeFromNestVillainsValley
		/// </summary>
		public static MonthlyNotificationItem IncomeFromNestVillainsValley => Instance[(short)190];

		/// <summary>
		/// IncomeFromNestRighteousLow
		/// </summary>
		public static MonthlyNotificationItem IncomeFromNestRighteousLow => Instance[(short)191];

		/// <summary>
		/// IncomeFromNestRighteousMiddle
		/// </summary>
		public static MonthlyNotificationItem IncomeFromNestRighteousMiddle => Instance[(short)192];

		/// <summary>
		/// BuildingWorkerDie
		/// </summary>
		public static MonthlyNotificationItem BuildingWorkerDie => Instance[(short)193];

		/// <summary>
		/// StoneHouseInfectedKidnapped
		/// </summary>
		public static MonthlyNotificationItem StoneHouseInfectedKidnapped => Instance[(short)194];

		/// <summary>
		/// WesternMerchanLost
		/// </summary>
		public static MonthlyNotificationItem WesternMerchanLost => Instance[(short)195];

		/// <summary>
		/// WesternMerchanFindMirage
		/// </summary>
		public static MonthlyNotificationItem WesternMerchanFindMirage => Instance[(short)196];

		/// <summary>
		/// WesternMerchanFindBigfoot
		/// </summary>
		public static MonthlyNotificationItem WesternMerchanFindBigfoot => Instance[(short)197];

		/// <summary>
		/// WesternMerchanFindPlant
		/// </summary>
		public static MonthlyNotificationItem WesternMerchanFindPlant => Instance[(short)198];

		/// <summary>
		/// WesternMerchanFindAnimal
		/// </summary>
		public static MonthlyNotificationItem WesternMerchanFindAnimal => Instance[(short)199];

		/// <summary>
		/// WesternMerchanGetInformation
		/// </summary>
		public static MonthlyNotificationItem WesternMerchanGetInformation => Instance[(short)200];

		/// <summary>
		/// WesternMerchanFindSettlement
		/// </summary>
		public static MonthlyNotificationItem WesternMerchanFindSettlement => Instance[(short)201];

		/// <summary>
		/// WesternMerchanFindWeather
		/// </summary>
		public static MonthlyNotificationItem WesternMerchanFindWeather => Instance[(short)202];

		/// <summary>
		/// WesternMerchanFindWreckage
		/// </summary>
		public static MonthlyNotificationItem WesternMerchanFindWreckage => Instance[(short)203];

		/// <summary>
		/// WesternMerchanHelpPasserby
		/// </summary>
		public static MonthlyNotificationItem WesternMerchanHelpPasserby => Instance[(short)204];

		/// <summary>
		/// WesternMerchanGetHelp
		/// </summary>
		public static MonthlyNotificationItem WesternMerchanGetHelp => Instance[(short)205];

		/// <summary>
		/// WesternMerchanFindVenison
		/// </summary>
		public static MonthlyNotificationItem WesternMerchanFindVenison => Instance[(short)206];

		/// <summary>
		/// WesternMerchanFindFruit
		/// </summary>
		public static MonthlyNotificationItem WesternMerchanFindFruit => Instance[(short)207];

		/// <summary>
		/// WesternMerchanFindVillage
		/// </summary>
		public static MonthlyNotificationItem WesternMerchanFindVillage => Instance[(short)208];

		/// <summary>
		/// WesternMerchanMeetMerchan
		/// </summary>
		public static MonthlyNotificationItem WesternMerchanMeetMerchan => Instance[(short)209];

		/// <summary>
		/// WesternMerchanMeetTheif
		/// </summary>
		public static MonthlyNotificationItem WesternMerchanMeetTheif => Instance[(short)210];

		/// <summary>
		/// WesternMerchanGoodsDamage
		/// </summary>
		public static MonthlyNotificationItem WesternMerchanGoodsDamage => Instance[(short)211];

		/// <summary>
		/// WesternMerchanUnacclimatized
		/// </summary>
		public static MonthlyNotificationItem WesternMerchanUnacclimatized => Instance[(short)212];

		/// <summary>
		/// WesternMerchanLackReplenishment
		/// </summary>
		public static MonthlyNotificationItem WesternMerchanLackReplenishment => Instance[(short)213];

		/// <summary>
		/// AboutToDie
		/// </summary>
		public static MonthlyNotificationItem AboutToDie => Instance[(short)214];

		/// <summary>
		/// EnemyNestDemise
		/// </summary>
		public static MonthlyNotificationItem EnemyNestDemise => Instance[(short)215];

		/// <summary>
		/// SecretInformationBroadcast
		/// </summary>
		public static MonthlyNotificationItem SecretInformationBroadcast => Instance[(short)216];

		/// <summary>
		/// ReadingEvent
		/// </summary>
		public static MonthlyNotificationItem ReadingEvent => Instance[(short)217];

		/// <summary>
		/// EnemyNestGrow
		/// </summary>
		public static MonthlyNotificationItem EnemyNestGrow => Instance[(short)218];

		/// <summary>
		/// RandomEnemyGrow
		/// </summary>
		public static MonthlyNotificationItem RandomEnemyGrow => Instance[(short)219];

		/// <summary>
		/// RandomEnemyDecay
		/// </summary>
		public static MonthlyNotificationItem RandomEnemyDecay => Instance[(short)220];

		/// <summary>
		/// XiangshuGetStrengthened
		/// </summary>
		public static MonthlyNotificationItem XiangshuGetStrengthened => Instance[(short)221];

		/// <summary>
		/// LegendaryBookShocked
		/// </summary>
		public static MonthlyNotificationItem LegendaryBookShocked => Instance[(short)222];

		/// <summary>
		/// LegendaryBookInsane
		/// </summary>
		public static MonthlyNotificationItem LegendaryBookInsane => Instance[(short)223];

		/// <summary>
		/// LegendaryBookConsumed
		/// </summary>
		public static MonthlyNotificationItem LegendaryBookConsumed => Instance[(short)224];

		/// <summary>
		/// LegendaryBookLost
		/// </summary>
		public static MonthlyNotificationItem LegendaryBookLost => Instance[(short)225];

		/// <summary>
		/// FightForNewLegendaryBook
		/// </summary>
		public static MonthlyNotificationItem FightForNewLegendaryBook => Instance[(short)226];

		/// <summary>
		/// FightForLegendaryBookAbandoned
		/// </summary>
		public static MonthlyNotificationItem FightForLegendaryBookAbandoned => Instance[(short)227];

		/// <summary>
		/// FightForLegendaryBookOwnerDie
		/// </summary>
		public static MonthlyNotificationItem FightForLegendaryBookOwnerDie => Instance[(short)228];

		/// <summary>
		/// FightForLegendaryBookOwnerConsumed
		/// </summary>
		public static MonthlyNotificationItem FightForLegendaryBookOwnerConsumed => Instance[(short)229];

		/// <summary>
		/// LegendaryBookAppear
		/// </summary>
		public static MonthlyNotificationItem LegendaryBookAppear => Instance[(short)230];

		/// <summary>
		/// ChallengeForLegendaryBook
		/// </summary>
		public static MonthlyNotificationItem ChallengeForLegendaryBook => Instance[(short)231];

		/// <summary>
		/// RobLegendaryBook
		/// </summary>
		public static MonthlyNotificationItem RobLegendaryBook => Instance[(short)232];

		/// <summary>
		/// VillagerLeftForLegendaryBook
		/// </summary>
		public static MonthlyNotificationItem VillagerLeftForLegendaryBook => Instance[(short)233];

		/// <summary>
		/// HappyBirthday
		/// </summary>
		public static MonthlyNotificationItem HappyBirthday => Instance[(short)234];

		/// <summary>
		/// PoisonMakeLoss
		/// </summary>
		public static MonthlyNotificationItem PoisonMakeLoss => Instance[(short)235];

		/// <summary>
		/// RottenPoisonDiffuse
		/// </summary>
		public static MonthlyNotificationItem RottenPoisonDiffuse => Instance[(short)236];

		/// <summary>
		/// PoisonDestroyFace
		/// </summary>
		public static MonthlyNotificationItem PoisonDestroyFace => Instance[(short)237];

		/// <summary>
		/// IllusoryPoisonDiffuse
		/// </summary>
		public static MonthlyNotificationItem IllusoryPoisonDiffuse => Instance[(short)238];

		/// <summary>
		/// PoisonDisturbMindAttckSuccess
		/// </summary>
		public static MonthlyNotificationItem PoisonDisturbMindAttckSuccess => Instance[(short)239];

		/// <summary>
		/// PoisonDisturbMindEmpoisonSuccess
		/// </summary>
		public static MonthlyNotificationItem PoisonDisturbMindEmpoisonSuccess => Instance[(short)240];

		/// <summary>
		/// PoisonDisturbMindSneakAttckSuccess
		/// </summary>
		public static MonthlyNotificationItem PoisonDisturbMindSneakAttckSuccess => Instance[(short)241];

		/// <summary>
		/// PoisonDisturbMindRapeSuccess
		/// </summary>
		public static MonthlyNotificationItem PoisonDisturbMindRapeSuccess => Instance[(short)242];

		/// <summary>
		/// PoisonDisturbMindAttckFalse
		/// </summary>
		public static MonthlyNotificationItem PoisonDisturbMindAttckFalse => Instance[(short)243];

		/// <summary>
		/// PoisonDisturbMindEmpoisonFalse
		/// </summary>
		public static MonthlyNotificationItem PoisonDisturbMindEmpoisonFalse => Instance[(short)244];

		/// <summary>
		/// PoisonDisturbMindSneakAttckFalse
		/// </summary>
		public static MonthlyNotificationItem PoisonDisturbMindSneakAttckFalse => Instance[(short)245];

		/// <summary>
		/// PoisonDisturbMindRapeFalse
		/// </summary>
		public static MonthlyNotificationItem PoisonDisturbMindRapeFalse => Instance[(short)246];

		/// <summary>
		/// SectMainStoryXuehouJixiKillsPeople
		/// </summary>
		public static MonthlyNotificationItem SectMainStoryXuehouJixiKillsPeople => Instance[(short)247];

		/// <summary>
		/// SectMainStoryYuanshanAbsorbInfectedPeople
		/// </summary>
		public static MonthlyNotificationItem SectMainStoryYuanshanAbsorbInfectedPeople => Instance[(short)248];

		/// <summary>
		/// SectMainStoryShixiangAdventure
		/// </summary>
		public static MonthlyNotificationItem SectMainStoryShixiangAdventure => Instance[(short)249];

		/// <summary>
		/// SectMainStoryXuehouJixiGone
		/// </summary>
		public static MonthlyNotificationItem SectMainStoryXuehouJixiGone => Instance[(short)250];

		/// <summary>
		/// WulinConferenceWinner
		/// </summary>
		public static MonthlyNotificationItem WulinConferenceWinner => Instance[(short)251];

		/// <summary>
		/// SectMainStoryEmeiInfighting
		/// </summary>
		public static MonthlyNotificationItem SectMainStoryEmeiInfighting => Instance[(short)252];

		/// <summary>
		/// SectMainStoryWhiteGibbonReturns
		/// </summary>
		public static MonthlyNotificationItem SectMainStoryWhiteGibbonReturns => Instance[(short)253];

		/// <summary>
		/// SectMainStoryXuehouJixiGoneAgain
		/// </summary>
		public static MonthlyNotificationItem SectMainStoryXuehouJixiGoneAgain => Instance[(short)254];

		/// <summary>
		/// SectMainStoryXuehouJixiRescue
		/// </summary>
		public static MonthlyNotificationItem SectMainStoryXuehouJixiRescue => Instance[(short)255];

		/// <summary>
		/// SectMainStoryXuehouJixiGoneFinal
		/// </summary>
		public static MonthlyNotificationItem SectMainStoryXuehouJixiGoneFinal => Instance[(short)256];

		/// <summary>
		/// SectMainStoryKongsangTripodVesselCures
		/// </summary>
		public static MonthlyNotificationItem SectMainStoryKongsangTripodVesselCures => Instance[(short)257];

		/// <summary>
		/// SectMainStoryKongsangTripodVesselDetoxifies
		/// </summary>
		public static MonthlyNotificationItem SectMainStoryKongsangTripodVesselDetoxifies => Instance[(short)258];

		/// <summary>
		/// SectMainStoryKongsangTripodVesselRemovesQiDisorder
		/// </summary>
		public static MonthlyNotificationItem SectMainStoryKongsangTripodVesselRemovesQiDisorder => Instance[(short)259];

		/// <summary>
		/// SectMainStoryKongsangTripodVesselRestoresHealth
		/// </summary>
		public static MonthlyNotificationItem SectMainStoryKongsangTripodVesselRestoresHealth => Instance[(short)260];

		/// <summary>
		/// ReincarnationNewWithLocation
		/// </summary>
		public static MonthlyNotificationItem ReincarnationNewWithLocation => Instance[(short)261];

		/// <summary>
		/// SectMainStoryWudangVillagersInjured
		/// </summary>
		public static MonthlyNotificationItem SectMainStoryWudangVillagersInjured => Instance[(short)262];

		/// <summary>
		/// SectMainStoryWudangVillagerCasualty
		/// </summary>
		public static MonthlyNotificationItem SectMainStoryWudangVillagerCasualty => Instance[(short)263];

		/// <summary>
		/// KillHereticRandomEnemy
		/// </summary>
		public static MonthlyNotificationItem KillHereticRandomEnemy => Instance[(short)264];

		/// <summary>
		/// DefeatedByHereticRandomEnemy
		/// </summary>
		public static MonthlyNotificationItem DefeatedByHereticRandomEnemy => Instance[(short)265];

		/// <summary>
		/// KillRighteousRandomEnemy
		/// </summary>
		public static MonthlyNotificationItem KillRighteousRandomEnemy => Instance[(short)266];

		/// <summary>
		/// DefeatedByRighteousRandomEnemy
		/// </summary>
		public static MonthlyNotificationItem DefeatedByRighteousRandomEnemy => Instance[(short)267];

		/// <summary>
		/// KillAnimal
		/// </summary>
		public static MonthlyNotificationItem KillAnimal => Instance[(short)268];

		/// <summary>
		/// DefeatedByAnimal
		/// </summary>
		public static MonthlyNotificationItem DefeatedByAnimal => Instance[(short)269];

		/// <summary>
		/// DieFromEnemyNest
		/// </summary>
		public static MonthlyNotificationItem DieFromEnemyNest => Instance[(short)270];

		/// <summary>
		/// Dummy0
		/// </summary>
		public static MonthlyNotificationItem Dummy0 => Instance[(short)271];

		/// <summary>
		/// Dummy1
		/// </summary>
		public static MonthlyNotificationItem Dummy1 => Instance[(short)272];

		/// <summary>
		/// Dummy2
		/// </summary>
		public static MonthlyNotificationItem Dummy2 => Instance[(short)273];

		/// <summary>
		/// MiscarriageAndReincarnation
		/// </summary>
		public static MonthlyNotificationItem MiscarriageAndReincarnation => Instance[(short)274];

		/// <summary>
		/// MiscarriageAndReincarnationMotherDies
		/// </summary>
		public static MonthlyNotificationItem MiscarriageAndReincarnationMotherDies => Instance[(short)275];

		/// <summary>
		/// MiscarriageAndReincarnationMotherKilled
		/// </summary>
		public static MonthlyNotificationItem MiscarriageAndReincarnationMotherKilled => Instance[(short)276];

		/// <summary>
		/// SectMainStoryEmeiShiReturns
		/// </summary>
		public static MonthlyNotificationItem SectMainStoryEmeiShiReturns => Instance[(short)277];

		/// <summary>
		/// SectMainStoryEmeiDoomOfEmei
		/// </summary>
		public static MonthlyNotificationItem SectMainStoryEmeiDoomOfEmei => Instance[(short)278];

		/// <summary>
		/// EscapeFromEnemyNest
		/// </summary>
		public static MonthlyNotificationItem EscapeFromEnemyNest => Instance[(short)279];

		/// <summary>
		/// SavedFromEnemyNest
		/// </summary>
		public static MonthlyNotificationItem SavedFromEnemyNest => Instance[(short)280];

		/// <summary>
		/// CultureDecline
		/// </summary>
		public static MonthlyNotificationItem CultureDecline => Instance[(short)281];

		/// <summary>
		/// FiveLoongArise
		/// </summary>
		public static MonthlyNotificationItem FiveLoongArise => Instance[(short)282];

		/// <summary>
		/// JiaoPoolAccident
		/// </summary>
		public static MonthlyNotificationItem JiaoPoolAccident => Instance[(short)283];

		/// <summary>
		/// JiaoGoHome
		/// </summary>
		public static MonthlyNotificationItem JiaoGoHome => Instance[(short)284];

		/// <summary>
		/// JiaoBrokeThroughTheShell
		/// </summary>
		public static MonthlyNotificationItem JiaoBrokeThroughTheShell => Instance[(short)285];

		/// <summary>
		/// JiaoHasReachedAnAdultAge
		/// </summary>
		public static MonthlyNotificationItem JiaoHasReachedAnAdultAge => Instance[(short)286];

		/// <summary>
		/// DLCLoongRidingEffectQiuniu
		/// </summary>
		public static MonthlyNotificationItem DLCLoongRidingEffectQiuniu => Instance[(short)287];

		/// <summary>
		/// DLCLoongRidingEffectYazi
		/// </summary>
		public static MonthlyNotificationItem DLCLoongRidingEffectYazi => Instance[(short)288];

		/// <summary>
		/// DLCLoongRidingEffectChaofeng
		/// </summary>
		public static MonthlyNotificationItem DLCLoongRidingEffectChaofeng => Instance[(short)289];

		/// <summary>
		/// DLCLoongRidingEffectPulao
		/// </summary>
		public static MonthlyNotificationItem DLCLoongRidingEffectPulao => Instance[(short)290];

		/// <summary>
		/// DLCLoongRidingEffectSuanni
		/// </summary>
		public static MonthlyNotificationItem DLCLoongRidingEffectSuanni => Instance[(short)291];

		/// <summary>
		/// DLCLoongRidingEffectBaxia
		/// </summary>
		public static MonthlyNotificationItem DLCLoongRidingEffectBaxia => Instance[(short)292];

		/// <summary>
		/// DLCLoongRidingEffectBian
		/// </summary>
		public static MonthlyNotificationItem DLCLoongRidingEffectBian => Instance[(short)293];

		/// <summary>
		/// DLCLoongRidingEffectFuxi
		/// </summary>
		public static MonthlyNotificationItem DLCLoongRidingEffectFuxi => Instance[(short)294];

		/// <summary>
		/// DLCLoongRidingEffectChiwen
		/// </summary>
		public static MonthlyNotificationItem DLCLoongRidingEffectChiwen => Instance[(short)295];

		/// <summary>
		/// JiaoLayEggs
		/// </summary>
		public static MonthlyNotificationItem JiaoLayEggs => Instance[(short)296];

		/// <summary>
		/// JiaoTamingPointsLow
		/// </summary>
		public static MonthlyNotificationItem JiaoTamingPointsLow => Instance[(short)297];

		/// <summary>
		/// DieFromAge
		/// </summary>
		public static MonthlyNotificationItem DieFromAge => Instance[(short)298];

		/// <summary>
		/// DieFromPoorHealth
		/// </summary>
		public static MonthlyNotificationItem DieFromPoorHealth => Instance[(short)299];

		/// <summary>
		/// KilledInPubilc
		/// </summary>
		public static MonthlyNotificationItem KilledInPubilc => Instance[(short)300];

		/// <summary>
		/// SectMainStoryJingangHaunted
		/// </summary>
		public static MonthlyNotificationItem SectMainStoryJingangHaunted => Instance[(short)301];

		/// <summary>
		/// SectMainStoryJingangFollowedByGhost
		/// </summary>
		public static MonthlyNotificationItem SectMainStoryJingangFollowedByGhost => Instance[(short)302];

		/// <summary>
		/// SectMainStoryJingangWrongdoing
		/// </summary>
		public static MonthlyNotificationItem SectMainStoryJingangWrongdoing => Instance[(short)303];

		/// <summary>
		/// SectMainStoryJingangPray
		/// </summary>
		public static MonthlyNotificationItem SectMainStoryJingangPray => Instance[(short)304];

		/// <summary>
		/// SectMainStoryJingangFameDistribution
		/// </summary>
		public static MonthlyNotificationItem SectMainStoryJingangFameDistribution => Instance[(short)305];

		/// <summary>
		/// WugKingParasitiferDead
		/// </summary>
		public static MonthlyNotificationItem WugKingParasitiferDead => Instance[(short)306];

		/// <summary>
		/// WugKingDead
		/// </summary>
		public static MonthlyNotificationItem WugKingDead => Instance[(short)307];

		/// <summary>
		/// WugKingDeadSpecial
		/// </summary>
		public static MonthlyNotificationItem WugKingDeadSpecial => Instance[(short)308];

		/// <summary>
		/// SectMainStoryJingangFamousFakeMonk
		/// </summary>
		public static MonthlyNotificationItem SectMainStoryJingangFamousFakeMonk => Instance[(short)309];

		/// <summary>
		/// SectMainStoryJingangRockFleshed
		/// </summary>
		public static MonthlyNotificationItem SectMainStoryJingangRockFleshed => Instance[(short)310];

		/// <summary>
		/// SectMainStoryWuxianParanoiaAppeared
		/// </summary>
		public static MonthlyNotificationItem SectMainStoryWuxianParanoiaAppeared => Instance[(short)311];

		/// <summary>
		/// SectMainStoryJingangVillagerFlee
		/// </summary>
		public static MonthlyNotificationItem SectMainStoryJingangVillagerFlee => Instance[(short)312];

		/// <summary>
		/// SectMainStoryRanshanSanZongBiWu
		/// </summary>
		public static MonthlyNotificationItem SectMainStoryRanshanSanZongBiWu => Instance[(short)313];

		/// <summary>
		/// GiveUpLegendaryBookSuccessHuaJu
		/// </summary>
		public static MonthlyNotificationItem GiveUpLegendaryBookSuccessHuaJu => Instance[(short)314];

		/// <summary>
		/// GiveUpLegendaryBookSuccessXuanZhi
		/// </summary>
		public static MonthlyNotificationItem GiveUpLegendaryBookSuccessXuanZhi => Instance[(short)315];

		/// <summary>
		/// GiveUpLegendaryBookSuccessYingJiao
		/// </summary>
		public static MonthlyNotificationItem GiveUpLegendaryBookSuccessYingJiao => Instance[(short)316];

		/// <summary>
		/// GiveUpLegendaryBookFailureHuaJu
		/// </summary>
		public static MonthlyNotificationItem GiveUpLegendaryBookFailureHuaJu => Instance[(short)317];

		/// <summary>
		/// GiveUpLegendaryBookFailureXuanZhi
		/// </summary>
		public static MonthlyNotificationItem GiveUpLegendaryBookFailureXuanZhi => Instance[(short)318];

		/// <summary>
		/// GiveUpLegendaryBookFailureYingJiao
		/// </summary>
		public static MonthlyNotificationItem GiveUpLegendaryBookFailureYingJiao => Instance[(short)319];

		/// <summary>
		/// GiveUpLegendaryBookLoseBookHuaJu
		/// </summary>
		public static MonthlyNotificationItem GiveUpLegendaryBookLoseBookHuaJu => Instance[(short)320];

		/// <summary>
		/// GiveUpLegendaryBookLoseBookXuanZhi
		/// </summary>
		public static MonthlyNotificationItem GiveUpLegendaryBookLoseBookXuanZhi => Instance[(short)321];

		/// <summary>
		/// GiveUpLegendaryBookLoseBookYingJiao
		/// </summary>
		public static MonthlyNotificationItem GiveUpLegendaryBookLoseBookYingJiao => Instance[(short)322];

		/// <summary>
		/// GiveUpLegendaryBookLoseTargetHuaJu
		/// </summary>
		public static MonthlyNotificationItem GiveUpLegendaryBookLoseTargetHuaJu => Instance[(short)323];

		/// <summary>
		/// GiveUpLegendaryBookLoseTargetXuanZhi
		/// </summary>
		public static MonthlyNotificationItem GiveUpLegendaryBookLoseTargetXuanZhi => Instance[(short)324];

		/// <summary>
		/// GiveUpLegendaryBookLoseTargetYingJiao
		/// </summary>
		public static MonthlyNotificationItem GiveUpLegendaryBookLoseTargetYingJiao => Instance[(short)325];

		/// <summary>
		/// LifeLinkHealing
		/// </summary>
		public static MonthlyNotificationItem LifeLinkHealing => Instance[(short)326];

		/// <summary>
		/// LifeLinkDamage
		/// </summary>
		public static MonthlyNotificationItem LifeLinkDamage => Instance[(short)327];

		/// <summary>
		/// SectMainStoryBaIhuaLeukoKills
		/// </summary>
		public static MonthlyNotificationItem SectMainStoryBaihuaLeukoKills => Instance[(short)328];

		/// <summary>
		/// SectMainStoryBaIhuaMelanoKills
		/// </summary>
		public static MonthlyNotificationItem SectMainStoryBaihuaMelanoKills => Instance[(short)329];

		/// <summary>
		/// SectMainStoryBaIhuaLeukoHelps
		/// </summary>
		public static MonthlyNotificationItem SectMainStoryBaihuaLeukoHelps => Instance[(short)330];

		/// <summary>
		/// SectMainStoryBaIhuaMelanoHelps
		/// </summary>
		public static MonthlyNotificationItem SectMainStoryBaihuaMelanoHelps => Instance[(short)331];

		/// <summary>
		/// SectMainStoryBaIhuaManicLow
		/// </summary>
		public static MonthlyNotificationItem SectMainStoryBaihuaManicLow => Instance[(short)332];

		/// <summary>
		/// SectMainStoryBaIhuaManicHigh
		/// </summary>
		public static MonthlyNotificationItem SectMainStoryBaihuaManicHigh => Instance[(short)333];

		/// <summary>
		/// LoopingEvent
		/// </summary>
		public static MonthlyNotificationItem LoopingEvent => Instance[(short)334];

		/// <summary>
		/// FiveElementsChange
		/// </summary>
		public static MonthlyNotificationItem FiveElementsChange => Instance[(short)335];

		/// <summary>
		/// ResourcesCollectionCompleted
		/// </summary>
		public static MonthlyNotificationItem ResourcesCollectionCompleted => Instance[(short)336];

		/// <summary>
		/// SectMainStoryFulongSacrifice
		/// </summary>
		public static MonthlyNotificationItem SectMainStoryFulongSacrifice => Instance[(short)337];

		/// <summary>
		/// SectMainStoryFulongFeatherDrop
		/// </summary>
		public static MonthlyNotificationItem SectMainStoryFulongFeatherDrop => Instance[(short)338];

		/// <summary>
		/// MarketComing
		/// </summary>
		public static MonthlyNotificationItem MarketComing => Instance[(short)339];

		/// <summary>
		/// TownCombatComing
		/// </summary>
		public static MonthlyNotificationItem TownCombatComing => Instance[(short)340];

		/// <summary>
		/// CricketContestComing
		/// </summary>
		public static MonthlyNotificationItem CricketContestComing => Instance[(short)341];

		/// <summary>
		/// LifeCompetitionComing
		/// </summary>
		public static MonthlyNotificationItem LifeCompetitionComing => Instance[(short)342];

		/// <summary>
		/// SectNormalCompetitionComing
		/// </summary>
		public static MonthlyNotificationItem SectNormalCompetitionComing => Instance[(short)343];

		/// <summary>
		/// JoustForSpouseComing
		/// </summary>
		public static MonthlyNotificationItem JoustForSpouseComing => Instance[(short)344];

		/// <summary>
		/// DyingNotice
		/// </summary>
		public static MonthlyNotificationItem DyingNotice => Instance[(short)345];

		/// <summary>
		/// InjuredNotice
		/// </summary>
		public static MonthlyNotificationItem InjuredNotice => Instance[(short)346];

		/// <summary>
		/// TrappedNotice
		/// </summary>
		public static MonthlyNotificationItem TrappedNotice => Instance[(short)347];

		/// <summary>
		/// SectMainStoryFulongFightSucceed
		/// </summary>
		public static MonthlyNotificationItem SectMainStoryFulongFightSucceed => Instance[(short)348];

		/// <summary>
		/// SectMainStoryFulongFightFail
		/// </summary>
		public static MonthlyNotificationItem SectMainStoryFulongFightFail => Instance[(short)349];

		/// <summary>
		/// SectMainStoryFulongFamilyFightFail
		/// </summary>
		public static MonthlyNotificationItem SectMainStoryFulongFamilyFightFail => Instance[(short)350];

		/// <summary>
		/// SectMainStoryFulongRobbery
		/// </summary>
		public static MonthlyNotificationItem SectMainStoryFulongRobbery => Instance[(short)351];

		/// <summary>
		/// SectMainStoryFulongFamilyRobbery
		/// </summary>
		public static MonthlyNotificationItem SectMainStoryFulongFamilyRobbery => Instance[(short)352];

		/// <summary>
		/// DeliverInPrison0
		/// </summary>
		public static MonthlyNotificationItem DeliverInPrison0 => Instance[(short)353];

		/// <summary>
		/// DeliverInPrison1
		/// </summary>
		public static MonthlyNotificationItem DeliverInPrison1 => Instance[(short)354];

		/// <summary>
		/// DieInPrison
		/// </summary>
		public static MonthlyNotificationItem DieInPrison => Instance[(short)355];

		/// <summary>
		/// AssassinatedInPrison
		/// </summary>
		public static MonthlyNotificationItem AssassinatedInPrison => Instance[(short)356];

		/// <summary>
		/// AssassinatedDueToKillerTokenInPrison
		/// </summary>
		public static MonthlyNotificationItem AssassinatedDueToKillerTokenInPrison => Instance[(short)357];

		/// <summary>
		/// ImprisonAndAbandonBaby0
		/// </summary>
		public static MonthlyNotificationItem ImprisonAndAbandonBaby0 => Instance[(short)358];

		/// <summary>
		/// ImprisonAndAbandonBaby1
		/// </summary>
		public static MonthlyNotificationItem ImprisonAndAbandonBaby1 => Instance[(short)359];

		/// <summary>
		/// ResourceMigration
		/// </summary>
		public static MonthlyNotificationItem ResourceMigration => Instance[(short)360];

		/// <summary>
		/// ChickenSecretInformation
		/// </summary>
		public static MonthlyNotificationItem ChickenSecretInformation => Instance[(short)361];

		/// <summary>
		/// XiangshuNormalInformation
		/// </summary>
		public static MonthlyNotificationItem XiangshuNormalInformation => Instance[(short)362];

		/// <summary>
		/// SectMainStoryFulongFireVanishes
		/// </summary>
		public static MonthlyNotificationItem SectMainStoryFulongFireVanishes => Instance[(short)363];

		/// <summary>
		/// SectMainStoryFulongLooting
		/// </summary>
		public static MonthlyNotificationItem SectMainStoryFulongLooting => Instance[(short)364];

		/// <summary>
		/// SectMainStoryWudangTreesGrow
		/// </summary>
		public static MonthlyNotificationItem SectMainStoryWudangTreesGrow => Instance[(short)365];

		/// <summary>
		/// SectMainStoryZhujianSwordTestCeremony
		/// </summary>
		public static MonthlyNotificationItem SectMainStoryZhujianSwordTestCeremony => Instance[(short)366];

		/// <summary>
		/// InvestedCaravanMove
		/// </summary>
		public static MonthlyNotificationItem InvestedCaravanMove => Instance[(short)367];

		/// <summary>
		/// InvestedCaravanPassSettlement
		/// </summary>
		public static MonthlyNotificationItem InvestedCaravanPassSettlement => Instance[(short)368];

		/// <summary>
		/// InvestedCaravanPassLowCultureSettlement
		/// </summary>
		public static MonthlyNotificationItem InvestedCaravanPassLowCultureSettlement => Instance[(short)369];

		/// <summary>
		/// InvestedCaravanPassHighCultureSettlement
		/// </summary>
		public static MonthlyNotificationItem InvestedCaravanPassHighCultureSettlement => Instance[(short)370];

		/// <summary>
		/// InvestedCaravanPassLowSafetySettlement
		/// </summary>
		public static MonthlyNotificationItem InvestedCaravanPassLowSafetySettlement => Instance[(short)371];

		/// <summary>
		/// InvestedCaravanPassHighSafetySettlement
		/// </summary>
		public static MonthlyNotificationItem InvestedCaravanPassHighSafetySettlement => Instance[(short)372];

		/// <summary>
		/// InvestedCaravanPassLowSafetyLowCultureSettlement
		/// </summary>
		public static MonthlyNotificationItem InvestedCaravanPassLowSafetyLowCultureSettlement => Instance[(short)373];

		/// <summary>
		/// InvestedCaravanPassLowSafetyHighCultureSettlement
		/// </summary>
		public static MonthlyNotificationItem InvestedCaravanPassLowSafetyHighCultureSettlement => Instance[(short)374];

		/// <summary>
		/// InvestedCaravanPassHighSafetyLowCultureSettlement
		/// </summary>
		public static MonthlyNotificationItem InvestedCaravanPassHighSafetyLowCultureSettlement => Instance[(short)375];

		/// <summary>
		/// InvestedCaravanPassHighSafetyHighCultureSettlement
		/// </summary>
		public static MonthlyNotificationItem InvestedCaravanPassHighSafetyHighCultureSettlement => Instance[(short)376];

		/// <summary>
		/// InvestedCaravanArrive
		/// </summary>
		public static MonthlyNotificationItem InvestedCaravanArrive => Instance[(short)377];

		/// <summary>
		/// InvestedCaravanIsRobbed
		/// </summary>
		public static MonthlyNotificationItem InvestedCaravanIsRobbed => Instance[(short)378];

		/// <summary>
		/// InvestedCaravanIsRobbedAndFailed
		/// </summary>
		public static MonthlyNotificationItem InvestedCaravanIsRobbedAndFailed => Instance[(short)379];

		/// <summary>
		/// BuildingUpgradingHolded
		/// </summary>
		public static MonthlyNotificationItem BuildingUpgradingHolded => Instance[(short)380];

		/// <summary>
		/// PunishmentLost0
		/// </summary>
		public static MonthlyNotificationItem PunishmentLost0 => Instance[(short)381];

		/// <summary>
		/// PunishmentLost1
		/// </summary>
		public static MonthlyNotificationItem PunishmentLost1 => Instance[(short)382];

		/// <summary>
		/// OutsiderMakeHarvest
		/// </summary>
		public static MonthlyNotificationItem OutsiderMakeHarvest => Instance[(short)383];

		/// <summary>
		/// TaiwuVillageCraftObjectsFinished
		/// </summary>
		public static MonthlyNotificationItem TaiwuVillageCraftObjectsFinished => Instance[(short)384];

		/// <summary>
		/// OutsiderMakeHarvest1
		/// </summary>
		public static MonthlyNotificationItem OutsiderMakeHarvest1 => Instance[(short)385];

		/// <summary>
		/// TaiwuVillagerDied
		/// </summary>
		public static MonthlyNotificationItem TaiwuVillagerDied => Instance[(short)386];

		/// <summary>
		/// SectMainStoryRemakeEmeiHomocideCase
		/// </summary>
		public static MonthlyNotificationItem SectMainStoryRemakeEmeiHomocideCase => Instance[(short)387];

		/// <summary>
		/// SectMainStoryRemakeEmeiRumor
		/// </summary>
		public static MonthlyNotificationItem SectMainStoryRemakeEmeiRumor => Instance[(short)388];

		/// <summary>
		/// DieNotice
		/// </summary>
		public static MonthlyNotificationItem DieNotice => Instance[(short)389];

		/// <summary>
		/// WantedNotice
		/// </summary>
		public static MonthlyNotificationItem WantedNotice => Instance[(short)390];

		/// <summary>
		/// SectMainStoryYuanshanJuemo
		/// </summary>
		public static MonthlyNotificationItem SectMainStoryYuanshanJuemo => Instance[(short)391];

		/// <summary>
		/// CoreMaterialIncome
		/// </summary>
		public static MonthlyNotificationItem CoreMaterialIncome => Instance[(short)392];

		/// <summary>
		/// FamilyGetInfected
		/// </summary>
		public static MonthlyNotificationItem FamilyGetInfected => Instance[(short)393];

		/// <summary>
		/// FamilyDieByInfected
		/// </summary>
		public static MonthlyNotificationItem FamilyDieByInfected => Instance[(short)394];

		/// <summary>
		/// FocusedGetInfected
		/// </summary>
		public static MonthlyNotificationItem FocusedGetInfected => Instance[(short)395];

		/// <summary>
		/// FocusedDieByInfected
		/// </summary>
		public static MonthlyNotificationItem FocusedDieByInfected => Instance[(short)396];

		/// <summary>
		/// NormalVillagersInjured
		/// </summary>
		public static MonthlyNotificationItem NormalVillagersInjured => Instance[(short)397];

		/// <summary>
		/// NormalVillagerCasualty
		/// </summary>
		public static MonthlyNotificationItem NormalVillagerCasualty => Instance[(short)398];

		/// <summary>
		/// NormalTreesGrow
		/// </summary>
		public static MonthlyNotificationItem NormalTreesGrow => Instance[(short)399];

		/// <summary>
		/// VillagerCraftFinished0
		/// </summary>
		public static MonthlyNotificationItem VillagerCraftFinished0 => Instance[(short)400];

		/// <summary>
		/// VillagerCraftFinished1
		/// </summary>
		public static MonthlyNotificationItem VillagerCraftFinished1 => Instance[(short)401];

		/// <summary>
		/// VillagerCraftFinished2
		/// </summary>
		public static MonthlyNotificationItem VillagerCraftFinished2 => Instance[(short)402];

		/// <summary>
		/// VillagerCraftFinished3
		/// </summary>
		public static MonthlyNotificationItem VillagerCraftFinished3 => Instance[(short)403];

		/// <summary>
		/// NpcCraftFinished0
		/// </summary>
		public static MonthlyNotificationItem NpcCraftFinished0 => Instance[(short)404];

		/// <summary>
		/// NpcCraftFinished1
		/// </summary>
		public static MonthlyNotificationItem NpcCraftFinished1 => Instance[(short)405];

		/// <summary>
		/// NpcCraftFinished2
		/// </summary>
		public static MonthlyNotificationItem NpcCraftFinished2 => Instance[(short)406];

		/// <summary>
		/// NpcCraftFinished3
		/// </summary>
		public static MonthlyNotificationItem NpcCraftFinished3 => Instance[(short)407];

		/// <summary>
		/// NpcLongDistanceMarriage0
		/// </summary>
		public static MonthlyNotificationItem NpcLongDistanceMarriage0 => Instance[(short)408];

		/// <summary>
		/// NpcLongDistanceMarriage1
		/// </summary>
		public static MonthlyNotificationItem NpcLongDistanceMarriage1 => Instance[(short)409];

		/// <summary>
		/// NpcLongDistanceMarriage2
		/// </summary>
		public static MonthlyNotificationItem NpcLongDistanceMarriage2 => Instance[(short)410];

		/// <summary>
		/// WithoutFood
		/// </summary>
		public static MonthlyNotificationItem WithoutFood => Instance[(short)411];

		/// <summary>
		/// Escape0
		/// </summary>
		public static MonthlyNotificationItem Escape0 => Instance[(short)412];

		/// <summary>
		/// Escape1
		/// </summary>
		public static MonthlyNotificationItem Escape1 => Instance[(short)413];

		/// <summary>
		/// EscapeFailed
		/// </summary>
		public static MonthlyNotificationItem EscapeFailed => Instance[(short)438];

		/// <summary>
		/// FirstGetInfected0
		/// </summary>
		public static MonthlyNotificationItem FirstGetInfected0 => Instance[(short)414];

		/// <summary>
		/// FirstGetInfected1
		/// </summary>
		public static MonthlyNotificationItem FirstGetInfected1 => Instance[(short)415];

		/// <summary>
		/// YuanshanSpiritCrisis
		/// </summary>
		public static MonthlyNotificationItem YuanshanSpiritCrisis => Instance[(short)416];

		/// <summary>
		/// YuanshanDemonCrisis
		/// </summary>
		public static MonthlyNotificationItem YuanshanDemonCrisis => Instance[(short)417];

		/// <summary>
		/// PlotPoisonedEnemyEscaped
		/// </summary>
		public static MonthlyNotificationItem PlotPoisonedEnemyEscaped => Instance[(short)418];

		/// <summary>
		/// PlotHarmEnemyEscaped
		/// </summary>
		public static MonthlyNotificationItem PlotHarmEnemyEscaped => Instance[(short)419];

		/// <summary>
		/// GoingToAppointment
		/// </summary>
		public static MonthlyNotificationItem GoingToAppointment => Instance[(short)420];

		/// <summary>
		/// SectMainStoryXuehouJixiDrainPeople
		/// </summary>
		public static MonthlyNotificationItem SectMainStoryXuehouJixiDrainPeople => Instance[(short)421];

		/// <summary>
		/// SectMainStoryXuehouJixiDrainFail
		/// </summary>
		public static MonthlyNotificationItem SectMainStoryXuehouJixiDrainFail => Instance[(short)422];

		/// <summary>
		/// SectMainStoryXuehouTaiwuTransferFiveElements
		/// </summary>
		public static MonthlyNotificationItem SectMainStoryXuehouTaiwuTransferFiveElements => Instance[(short)423];

		/// <summary>
		/// SectMainStoryXuehouTaiwuTransferFiveElementsFail
		/// </summary>
		public static MonthlyNotificationItem SectMainStoryXuehouTaiwuTransferFiveElementsFail => Instance[(short)424];

		/// <summary>
		/// SectMainStoryXuehouJixiDrainNeili
		/// </summary>
		public static MonthlyNotificationItem SectMainStoryXuehouJixiDrainNeili => Instance[(short)425];

		/// <summary>
		/// SectMainStoryXuehouJixiDrainNeiliFail
		/// </summary>
		public static MonthlyNotificationItem SectMainStoryXuehouJixiDrainNeiliFail => Instance[(short)426];

		/// <summary>
		/// SectMainStoryXuehouTaiwuTransFiveElements
		/// </summary>
		public static MonthlyNotificationItem SectMainStoryXuehouTaiwuTransFiveElements => Instance[(short)427];

		/// <summary>
		/// SectMainStoryXuehouTaiwuTransFiveElementsFail
		/// </summary>
		public static MonthlyNotificationItem SectMainStoryXuehouTaiwuTransFiveElementsFail => Instance[(short)428];

		/// <summary>
		/// SectMainStoryXuehouJixiDrainNeiliFail1
		/// </summary>
		public static MonthlyNotificationItem SectMainStoryXuehouJixiDrainNeiliFail1 => Instance[(short)429];

		/// <summary>
		/// SectMainStoryXuehouJixiDrainNeiliFail2
		/// </summary>
		public static MonthlyNotificationItem SectMainStoryXuehouJixiDrainNeiliFail2 => Instance[(short)430];

		/// <summary>
		/// SectMainStoryXuehouJixiDrainNeiliFail3
		/// </summary>
		public static MonthlyNotificationItem SectMainStoryXuehouJixiDrainNeiliFail3 => Instance[(short)431];

		/// <summary>
		/// ChallengeModeAdvanceMonthWorsenInjuryOuter
		/// </summary>
		public static MonthlyNotificationItem ChallengeModeAdvanceMonthWorsenInjuryOuter => Instance[(short)432];

		/// <summary>
		/// ChallengeModeAdvanceMonthWorsenInjuryInner
		/// </summary>
		public static MonthlyNotificationItem ChallengeModeAdvanceMonthWorsenInjuryInner => Instance[(short)433];

		/// <summary>
		/// ChallengeModeAdvanceMonthWorsenPoison
		/// </summary>
		public static MonthlyNotificationItem ChallengeModeAdvanceMonthWorsenPoison => Instance[(short)434];

		/// <summary>
		/// ChickenFullyFledged
		/// </summary>
		public static MonthlyNotificationItem ChickenFullyFledged => Instance[(short)435];

		/// <summary>
		/// CostResourceNotEnough
		/// </summary>
		public static MonthlyNotificationItem CostResourceNotEnough => Instance[(short)436];

		/// <summary>
		/// CostResourceNotEnoughResult
		/// </summary>
		public static MonthlyNotificationItem CostResourceNotEnoughResult => Instance[(short)437];

		/// <summary>
		/// CricketGrowUp
		/// </summary>
		public static MonthlyNotificationItem CricketGrowUp => Instance[(short)439];

		/// <summary>
		/// KillRighteousRandomEnemyVillager
		/// </summary>
		public static MonthlyNotificationItem KillRighteousRandomEnemyVillager => Instance[(short)440];

		/// <summary>
		/// DefeatedByRighteousRandomEnemyVillager
		/// </summary>
		public static MonthlyNotificationItem DefeatedByRighteousRandomEnemyVillager => Instance[(short)441];

		/// <summary>
		/// KillHereticRandomEnemyVillager
		/// </summary>
		public static MonthlyNotificationItem KillHereticRandomEnemyVillager => Instance[(short)442];

		/// <summary>
		/// DefeatedByHereticRandomEnemyVillager
		/// </summary>
		public static MonthlyNotificationItem DefeatedByHereticRandomEnemyVillager => Instance[(short)443];

		/// <summary>
		/// KillAnimalVillager
		/// </summary>
		public static MonthlyNotificationItem KillAnimalVillager => Instance[(short)444];

		/// <summary>
		/// DefeatedByAnimalVillager
		/// </summary>
		public static MonthlyNotificationItem DefeatedByAnimalVillager => Instance[(short)445];

		/// <summary>
		/// DieFromEnemyNestVillager
		/// </summary>
		public static MonthlyNotificationItem DieFromEnemyNestVillager => Instance[(short)446];

		/// <summary>
		/// EscapeFromEnemyNestVillager
		/// </summary>
		public static MonthlyNotificationItem EscapeFromEnemyNestVillager => Instance[(short)447];

		/// <summary>
		/// SavedFromEnemyNestVillager
		/// </summary>
		public static MonthlyNotificationItem SavedFromEnemyNestVillager => Instance[(short)448];

		/// <summary>
		/// InfectedKidnapedCharacterEscape
		/// </summary>
		public static MonthlyNotificationItem InfectedKidnapedCharacterEscape => Instance[(short)449];

		/// <summary>
		/// OwningBookKidnapedCharacterEscape
		/// </summary>
		public static MonthlyNotificationItem OwningBookKidnapedCharacterEscape => Instance[(short)450];

		/// <summary>
		/// SectMainStoryEmeiStrangerAttack
		/// </summary>
		public static MonthlyNotificationItem SectMainStoryEmeiStrangerAttack => Instance[(short)451];

		/// <summary>
		/// SectMainStoryEmeiInsaneMember
		/// </summary>
		public static MonthlyNotificationItem SectMainStoryEmeiInsaneMember => Instance[(short)452];

		/// <summary>
		/// SectMainStoryEmeiRumors
		/// </summary>
		public static MonthlyNotificationItem SectMainStoryEmeiRumors => Instance[(short)453];

		/// <summary>
		/// SectMainStoryEmeiReputation
		/// </summary>
		public static MonthlyNotificationItem SectMainStoryEmeiReputation => Instance[(short)454];

		/// <summary>
		/// SectMainStoryEmeiSecretBook
		/// </summary>
		public static MonthlyNotificationItem SectMainStoryEmeiSecretBook => Instance[(short)455];

		/// <summary>
		/// SectMainStoryJieqingUpgradeXingYun
		/// </summary>
		public static MonthlyNotificationItem SectMainStoryJieqingUpgradeXingYun => Instance[(short)456];

		/// <summary>
		/// MainStoryImmortalWuFanKe
		/// </summary>
		public static MonthlyNotificationItem MainStoryImmortalWuFanKe => Instance[(short)457];

		/// <summary>
		/// MainStoryImmortalDianFanMo
		/// </summary>
		public static MonthlyNotificationItem MainStoryImmortalDianFanMo => Instance[(short)458];

		/// <summary>
		/// AdventureCapitalCity
		/// </summary>
		public static MonthlyNotificationItem AdventureCapitalCity => Instance[(short)459];

		/// <summary>
		/// SmallMarketAppeared
		/// </summary>
		public static MonthlyNotificationItem SmallMarketAppeared => Instance[(short)460];

		/// <summary>
		/// AdventureJieqi
		/// </summary>
		public static MonthlyNotificationItem AdventureJieqi => Instance[(short)461];

		/// <summary>
		/// AdventureTeaParty
		/// </summary>
		public static MonthlyNotificationItem AdventureTeaParty => Instance[(short)462];

		/// <summary>
		/// AdventureWineParty
		/// </summary>
		public static MonthlyNotificationItem AdventureWineParty => Instance[(short)463];

		/// <summary>
		/// AdventureMartialHall
		/// </summary>
		public static MonthlyNotificationItem AdventureMartialHall => Instance[(short)464];

		/// <summary>
		/// AdventureMissionReward
		/// </summary>
		public static MonthlyNotificationItem AdventureMissionReward => Instance[(short)465];

		/// <summary>
		/// AdventureWorldSecretRealm
		/// </summary>
		public static MonthlyNotificationItem AdventureWorldSecretRealm => Instance[(short)466];

		/// <summary>
		/// AdventureJieqiComing
		/// </summary>
		public static MonthlyNotificationItem AdventureJieqiComing => Instance[(short)467];

		/// <summary>
		/// BehaviorTypeAction1
		/// </summary>
		public static MonthlyNotificationItem BehaviorTypeAction1 => Instance[(short)468];

		/// <summary>
		/// BehaviorTypeAction2
		/// </summary>
		public static MonthlyNotificationItem BehaviorTypeAction2 => Instance[(short)469];

		/// <summary>
		/// NewMarketAppeared
		/// </summary>
		public static MonthlyNotificationItem NewMarketAppeared => Instance[(short)470];

		/// <summary>
		/// PreciousMaterial
		/// </summary>
		public static MonthlyNotificationItem PreciousMaterial => Instance[(short)471];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static MonthlyNotification Instance = new MonthlyNotification();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "Desc", "SortingGroup", "MergeDesc", "TemplateId", "Icon", "MergeableParameters", "ValueCheckParameters", "FirstPageBg" };

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
		_dataArray.Add(new MonthlyNotificationItem(0, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_0"), "sp_monthnotify_0_0", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_0"), new string[6] { "", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 0, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_0"), 0, 100, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(1, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_1"), "sp_monthnotify_0_1", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_1"), new string[6] { "", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 0, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_1"), 0, 100, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(2, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_2"), "sp_monthnotify_0_2", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_2"), new string[6] { "", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 0, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_2"), 0, 100, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(3, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_3"), "sp_monthnotify_0_3", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_3"), new string[6] { "", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 0, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_3"), 0, 100, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(4, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_4"), "sp_monthnotify_0_4", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_4"), new string[6] { "", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 0, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_4"), 0, 100, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(5, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_5"), "sp_monthnotify_0_5", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_5"), new string[6] { "", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 0, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_5"), 0, 100, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(6, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_6"), "sp_monthnotify_0_6", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_6"), new string[6] { "", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 0, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_6"), 0, 100, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(7, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_7"), "sp_monthnotify_0_7", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_7"), new string[6] { "", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 0, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_7"), 0, 100, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(8, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_8"), "sp_monthnotify_0_8", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_8"), new string[6] { "", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 0, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_8"), 0, 100, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(9, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_9"), "sp_monthnotify_0_9", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_9"), new string[6] { "", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 0, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_9"), 0, 100, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(10, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_10"), "sp_monthnotify_0_10", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_10"), new string[6] { "", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 0, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_10"), 0, 100, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(11, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_11"), "sp_monthnotify_0_11", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_11"), new string[6] { "", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 0, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_11"), 0, 100, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(12, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_12"), "sp_monthnotify_1_0", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_12"), new string[6] { "Character", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 1, 67, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_12"), 0, 30, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(13, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_13"), "sp_monthnotify_1_1", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_13"), new string[6] { "Character", "Location", "Character", "Adventure", "", "" }, null, EMonthlyNotificationSectionType.TaiwuVillage, 1, 145, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_13"), 0, 30, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(14, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_14"), "sp_monthnotify_1_2", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_14"), new string[6] { "Item", "", "", "", "", "" }, new List<sbyte> { 0 }, EMonthlyNotificationSectionType.Biography, 0, 7, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_14"), 0, 60, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(15, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_15"), "sp_monthnotify_2_0", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_15"), new string[6] { "Character", "Location", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 2, 3, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_15"), 0, 65, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(16, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_16"), "sp_monthnotify_2_1", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_16"), new string[6] { "Character", "Location", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 2, 4, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_16"), 0, 65, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(17, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_17"), "sp_monthnotify_2_2", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_17"), new string[6] { "Character", "Location", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 64, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_17"), 0, 70, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(18, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_18"), "sp_monthnotify_2_3", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_18"), new string[6] { "Character", "Location", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 2, 70, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_18"), 0, 100, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(19, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_19"), "sp_monthnotify_2_4", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_19"), new string[6] { "Character", "Location", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 2, 71, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_19"), 0, 100, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(20, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_20"), "sp_monthnotify_3_0", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_20"), new string[6] { "Character", "Location", "Character", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 9, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_20"), 0, 60, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(21, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_21"), "sp_monthnotify_3_1", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_21"), new string[6] { "Character", "Location", "Character", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 2, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_21"), 0, 60, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(22, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_22"), "sp_monthnotify_4_0", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_22"), new string[6] { "Cricket", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 1, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_22"), 0, 50, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(23, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_23"), "sp_monthnotify_4_1", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_23"), new string[6] { "Character", "Resource", "", "", "", "" }, new List<sbyte> { 1 }, EMonthlyNotificationSectionType.Biography, 0, 5, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_23"), 0, 60, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(24, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_24"), "sp_monthnotify_4_2", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_24"), new string[6] { "Character", "Item", "", "", "", "" }, new List<sbyte> { 1 }, EMonthlyNotificationSectionType.Biography, 0, 6, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_24"), 0, 60, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(25, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_25"), "sp_monthnotify_5_0", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_25"), new string[6] { "Character", "Location", "Character", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 8, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_25"), 0, 50, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(26, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_26"), "sp_monthnotify_5_1", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_26"), new string[6] { "Character", "Location", "Character", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 10, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_26"), 0, 60, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(27, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_27"), "sp_monthnotify_5_2", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_27"), new string[6] { "Character", "Location", "Character", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 11, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_27"), 0, 60, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(28, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_28"), "sp_monthnotify_5_3", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_28"), new string[6] { "Character", "Location", "Character", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 12, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_28"), 0, 85, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(29, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_29"), "sp_monthnotify_5_4", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_29"), new string[6] { "Character", "Location", "Character", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 13, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_29"), 0, 85, canFirstPage: true, "ui9_tex_month_notify_bg_0_5", allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(30, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_30"), "sp_monthnotify_5_5", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_30"), new string[6] { "Character", "Location", "Character", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 14, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_30"), 0, 50, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(31, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_31"), "sp_monthnotify_5_6", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_31"), new string[6] { "Character", "Location", "Character", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 15, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_31"), 0, 55, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(32, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_32"), "sp_monthnotify_5_7", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_32"), new string[6] { "Character", "Location", "Character", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 16, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_32"), 0, 50, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(33, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_33"), "sp_monthnotify_5_8", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_33"), new string[6] { "Character", "Location", "Character", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 17, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_33"), 0, 65, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(34, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_34"), "sp_monthnotify_5_9", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_34"), new string[6] { "Character", "Location", "Character", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 18, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_34"), 0, 70, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(35, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_35"), "sp_monthnotify_5_10", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_35"), new string[6] { "Character", "Location", "Character", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 18, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_35"), 0, 70, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(36, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_36"), "sp_monthnotify_5_11", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_36"), new string[6] { "Character", "Location", "Character", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 19, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_36"), 0, 70, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(37, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_37"), "sp_monthnotify_5_12", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_37"), new string[6] { "Character", "Location", "Character", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 19, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_37"), 0, 70, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(38, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_38"), "sp_monthnotify_5_13", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_38"), new string[6] { "Character", "Location", "Character", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 20, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_38"), 0, 60, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(39, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_39"), "sp_monthnotify_5_14", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_39"), new string[6] { "Character", "Location", "Character", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 21, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_39"), 0, 75, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(40, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_40"), "sp_monthnotify_6_0", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_40"), new string[6] { "Character", "Location", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 22, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_40"), 0, 80, canFirstPage: true, "ui9_tex_month_notify_bg_0_5", allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(41, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_41"), "sp_monthnotify_6_1", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_41"), new string[6] { "Character", "Location", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 22, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_41"), 0, 80, canFirstPage: true, "ui9_tex_month_notify_bg_0_5", allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(42, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_42"), "sp_monthnotify_6_0", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_42"), new string[6] { "Character", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 22, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_42"), 0, 80, canFirstPage: true, "ui9_tex_month_notify_bg_0_5", allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(43, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_43"), "sp_monthnotify_6_1", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_43"), new string[6] { "Character", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 22, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_43"), 0, 80, canFirstPage: true, "ui9_tex_month_notify_bg_0_5", allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(44, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_44"), "sp_monthnotify_6_2", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_44"), new string[6] { "Character", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 23, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_44"), 0, 80, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(45, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_45"), "sp_monthnotify_6_3", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_45"), new string[6] { "Character", "Location", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 24, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_45"), 0, 80, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(46, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_46"), "sp_monthnotify_7_0", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_46"), new string[6] { "Character", "Settlement", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 25, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_46"), 0, 30, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(47, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_47"), "sp_monthnotify_7_1", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_47"), new string[6] { "Character", "Settlement", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 26, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_47"), 0, 40, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(48, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_48"), "sp_monthnotify_7_2", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_48"), new string[6] { "Character", "Location", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 27, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_48"), 0, 50, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(49, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_49"), "sp_monthnotify_7_3", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_49"), new string[6] { "Character", "Location", "Character", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 27, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_49"), 0, 50, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(50, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_50"), "sp_monthnotify_7_4", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_50"), new string[6] { "Character", "Location", "Character", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 27, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_50"), 0, 50, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(51, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_51"), "sp_monthnotify_7_5", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_51"), new string[6] { "Character", "Location", "Character", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 27, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_51"), 0, 50, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(52, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_52"), "sp_monthnotify_7_6", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_52"), new string[6] { "Character", "Character", "Character", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 28, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_52"), 0, 45, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(53, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_53"), "sp_monthnotify_7_7", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_53"), new string[6] { "Character", "Character", "Character", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 28, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_53"), 0, 45, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(54, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_54"), "sp_monthnotify_7_8", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_54"), new string[6] { "Character", "Location", "Character", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 28, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_54"), 0, 45, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(55, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_55"), "sp_monthnotify_7_9", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_55"), new string[6] { "Character", "Location", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 45, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_55"), 0, 60, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(56, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_56"), "sp_monthnotify_7_10", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_56"), new string[6] { "Character", "Character", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 29, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_56"), 0, 50, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(57, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_57"), "sp_monthnotify_7_11", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_57"), new string[6] { "Character", "Character", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 30, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_57"), 0, 45, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(58, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_58"), "sp_monthnotify_7_12", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_58"), new string[6] { "Character", "Character", "Character", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 30, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_58"), 0, 45, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(59, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_59"), "sp_monthnotify_7_13", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_59"), new string[6] { "Character", "Settlement", "OrgGrade", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 165, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_59"), 0, 40, canFirstPage: false, "ui9_tex_month_notify_bg_0_7", allowByEventFunction: false));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new MonthlyNotificationItem(60, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_60"), "sp_monthnotify_7_14", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_60"), new string[6] { "Character", "Settlement", "OrgGrade", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 166, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_60"), 0, 50, canFirstPage: false, "ui9_tex_month_notify_bg_0_7", allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(61, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_61"), "sp_monthnotify_7_15", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_61"), new string[6] { "Character", "Settlement", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 167, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_61"), 0, 55, canFirstPage: true, "ui9_tex_month_notify_bg_0_7", allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(62, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_62"), "sp_monthnotify_8_0", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_62"), new string[6] { "Character", "Location", "Character", "Resource", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 168, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_62"), 0, 15, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(63, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_63"), "sp_monthnotify_8_1", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_63"), new string[6] { "Character", "Location", "Character", "Resource", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 168, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_63"), 0, 15, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(64, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_64"), "sp_monthnotify_8_2", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_64"), new string[6] { "Character", "Location", "Character", "Resource", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 169, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_64"), 0, 15, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(65, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_65"), "sp_monthnotify_8_3", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_65"), new string[6] { "Character", "Location", "Character", "Resource", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 170, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_65"), 0, 18, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(66, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_66"), "sp_monthnotify_8_4", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_66"), new string[6] { "Character", "Location", "Character", "Resource", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 171, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_66"), 0, 15, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(67, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_67"), "sp_monthnotify_8_0", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_67"), new string[6] { "Character", "Location", "Character", "Item", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 172, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_67"), 0, 15, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(68, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_68"), "sp_monthnotify_8_1", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_68"), new string[6] { "Character", "Location", "Character", "Item", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 172, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_68"), 0, 15, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(69, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_69"), "sp_monthnotify_8_2", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_69"), new string[6] { "Character", "Location", "Character", "Item", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 173, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_69"), 0, 15, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(70, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_70"), "sp_monthnotify_8_3", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_70"), new string[6] { "Character", "Location", "Character", "Item", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 174, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_70"), 0, 18, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(71, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_71"), "sp_monthnotify_8_4", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_71"), new string[6] { "Character", "Location", "Character", "Item", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 175, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_71"), 0, 15, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(72, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_72"), "sp_monthnotify_8_5", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_72"), new string[6] { "Character", "Location", "Character", "LifeSkill", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 176, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_72"), 0, 15, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(73, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_73"), "sp_monthnotify_8_6", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_73"), new string[6] { "Character", "Location", "Character", "LifeSkill", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 176, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_73"), 0, 15, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(74, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_74"), "sp_monthnotify_8_7", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_74"), new string[6] { "Character", "Location", "Character", "LifeSkill", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 177, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_74"), 0, 15, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(75, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_75"), "sp_monthnotify_8_8", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_75"), new string[6] { "Character", "Location", "Character", "CombatSkill", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 178, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_75"), 0, 15, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(76, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_76"), "sp_monthnotify_8_9", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_76"), new string[6] { "Character", "Location", "Character", "CombatSkill", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 178, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_76"), 0, 15, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(77, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_77"), "sp_monthnotify_8_10", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_77"), new string[6] { "Character", "Location", "Character", "CombatSkill", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 179, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_77"), 0, 15, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(78, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_78"), "sp_monthnotify_8_11", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_78"), new string[6] { "Character", "Location", "Resource", "Character", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 180, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_78"), 0, 20, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(79, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_79"), "sp_monthnotify_8_12", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_79"), new string[6] { "Character", "Location", "Item", "Character", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 181, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_79"), 0, 20, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(80, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_80"), "sp_monthnotify_8_13", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_80"), new string[6] { "Character", "Location", "Character", "LifeSkill", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 182, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_80"), 0, 20, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(81, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_81"), "sp_monthnotify_8_14", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_81"), new string[6] { "Character", "Location", "Character", "LifeSkill", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 182, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_81"), 0, 20, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(82, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_82"), "sp_monthnotify_8_15", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_82"), new string[6] { "Character", "Location", "Character", "CombatSkill", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 183, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_82"), 0, 20, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(83, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_83"), "sp_monthnotify_8_16", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_83"), new string[6] { "Character", "Location", "Character", "CombatSkill", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 183, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_83"), 0, 20, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(84, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_84"), "sp_monthnotify_9_0", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_84"), new string[6] { "Character", "Location", "Character", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 1, 157, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_84"), 0, 10, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(85, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_85"), "sp_monthnotify_9_1", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_85"), new string[6] { "Character", "Location", "Character", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 1, 158, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_85"), 0, 10, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(86, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_86"), "sp_monthnotify_9_2", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_86"), new string[6] { "Character", "Location", "Character", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 1, 159, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_86"), 0, 10, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(87, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_87"), "sp_monthnotify_9_3", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_87"), new string[6] { "Character", "Location", "Character", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 1, 160, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_87"), 0, 10, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(88, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_88"), "sp_monthnotify_9_4", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_88"), new string[6] { "Character", "Location", "Item", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 161, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_88"), 0, 10, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(89, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_89"), "sp_monthnotify_9_5", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_89"), new string[6] { "Character", "Location", "Character", "LifeSkillType", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 162, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_89"), 0, 12, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(90, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_90"), "sp_monthnotify_9_6", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_90"), new string[6] { "Character", "Location", "Character", "LifeSkillType", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 163, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_90"), 0, 12, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(91, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_91"), "sp_monthnotify_9_7", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_91"), new string[6] { "Character", "Location", "Character", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 164, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_91"), 0, 30, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(92, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_92"), "sp_monthnotify_10_0", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_92"), new string[6] { "Character", "Location", "Item", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 2, 184, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_92"), 0, 10, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(93, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_93"), "sp_monthnotify_10_0", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_93"), new string[6] { "Character", "Location", "Integer", "Resource", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 2, 184, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_93"), 0, 10, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(94, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_94"), "sp_monthnotify_10_1", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_94"), new string[6] { "Character", "Location", "Item", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 2, 185, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_94"), 0, 10, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(95, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_95"), "sp_monthnotify_10_1", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_95"), new string[6] { "Character", "Location", "Item", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 2, 186, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_95"), 0, 10, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(96, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_96"), "sp_monthnotify_10_2", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_96"), new string[6] { "Character", "Location", "Integer", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 2, 187, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_96"), 0, 8, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(97, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_97"), "sp_monthnotify_10_2", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_97"), new string[6] { "Character", "Location", "Integer", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 2, 187, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_97"), 0, 8, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(98, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_98"), "sp_monthnotify_10_2", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_98"), new string[6] { "Character", "Location", "Integer", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 2, 187, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_98"), 0, 8, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(99, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_99"), "sp_monthnotify_10_2", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_99"), new string[6] { "Character", "Location", "PoisonType", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 2, 187, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_99"), 0, 8, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(100, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_100"), "sp_monthnotify_10_3", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_100"), new string[6] { "Character", "Location", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 2, 187, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_100"), 0, 8, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(101, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_101"), "sp_monthnotify_10_4", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_101"), new string[6] { "Character", "Location", "Item", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 2, 188, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_101"), 0, 9, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(102, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_102"), "sp_monthnotify_10_5", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_102"), new string[6] { "Character", "Location", "Integer", "Resource", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 2, 188, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_102"), 0, 9, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(103, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_103"), "sp_monthnotify_10_6", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_103"), new string[6] { "Character", "Location", "Item", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 2, 189, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_103"), 0, 9, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(104, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_104"), "sp_monthnotify_10_6", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_104"), new string[6] { "Character", "Location", "Item", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 2, 189, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_104"), 0, 9, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(105, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_105"), "sp_monthnotify_10_7", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_105"), new string[6] { "Character", "Location", "Integer", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 2, 190, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_105"), 0, 7, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(106, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_106"), "sp_monthnotify_10_7", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_106"), new string[6] { "Character", "Location", "Integer", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 2, 190, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_106"), 0, 7, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(107, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_107"), "sp_monthnotify_10_7", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_107"), new string[6] { "Character", "Location", "Integer", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 2, 190, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_107"), 0, 7, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(108, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_108"), "sp_monthnotify_10_7", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_108"), new string[6] { "Character", "Location", "PoisonType", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 2, 190, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_108"), 0, 7, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(109, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_109"), "sp_monthnotify_10_8", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_109"), new string[6] { "Character", "Location", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 2, 190, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_109"), 0, 7, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(110, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_110"), "sp_monthnotify_11_0", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_110"), new string[6] { "Settlement", "Building", "", "", "", "" }, new List<sbyte> { 1 }, EMonthlyNotificationSectionType.TaiwuVillage, 1, 136, new List<sbyte> { 1 }, 1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_110"), 1, 35, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(111, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_111"), "sp_monthnotify_11_1", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_111"), new string[6] { "Settlement", "Building", "", "", "", "" }, new List<sbyte> { 1 }, EMonthlyNotificationSectionType.TaiwuVillage, 1, 137, new List<sbyte> { 1 }, 1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_111"), 1, 35, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(112, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_112"), "sp_monthnotify_11_2", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_112"), new string[6] { "Settlement", "Building", "", "", "", "" }, new List<sbyte> { 1 }, EMonthlyNotificationSectionType.TaiwuVillage, 0, 138, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_112"), 0, 50, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(113, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_113"), "sp_monthnotify_11_3", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_113"), new string[6] { "Settlement", "Building", "", "", "", "" }, new List<sbyte> { 1 }, EMonthlyNotificationSectionType.TaiwuVillage, 0, 139, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_113"), 0, 50, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(114, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_114"), "sp_monthnotify_11_4", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_114"), new string[6] { "Settlement", "Building", "", "", "", "" }, new List<sbyte> { 1 }, EMonthlyNotificationSectionType.TaiwuVillage, 1, 140, null, 3, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_114"), 2, 40, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(115, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_115"), "sp_monthnotify_11_5", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_115"), new string[6] { "Settlement", "Building", "", "", "", "" }, new List<sbyte> { 1 }, EMonthlyNotificationSectionType.TaiwuVillage, 1, 141, null, 3, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_115"), 2, 40, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(116, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_116"), "sp_monthnotify_11_6", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_116"), new string[6] { "Settlement", "Building", "", "", "", "" }, new List<sbyte> { 1 }, EMonthlyNotificationSectionType.TaiwuVillage, 1, 142, null, 3, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_116"), 2, 40, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(117, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_117"), "sp_monthnotify_11_7", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_117"), new string[6] { "Settlement", "Building", "", "", "", "" }, new List<sbyte> { 1 }, EMonthlyNotificationSectionType.TaiwuVillage, 1, 143, null, 1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_117"), 3, 35, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(118, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_118"), "sp_monthnotify_11_8", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_118"), new string[6] { "Location", "Character", "", "", "", "" }, null, EMonthlyNotificationSectionType.TaiwuVillage, 1, 144, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_118"), 0, 35, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(119, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_119"), "sp_monthnotify_12_0", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_119"), new string[6] { "Location", "Adventure", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 1, 121, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_119"), 0, 40, canFirstPage: false, null, allowByEventFunction: false));
	}

	private void CreateItems2()
	{
		_dataArray.Add(new MonthlyNotificationItem(120, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_120"), "sp_monthnotify_12_1", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_120"), new string[6] { "Location", "Adventure", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 1, 122, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_120"), 0, 40, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(121, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_121"), "sp_monthnotify_12_2", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_121"), new string[6] { "Location", "Adventure", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 1, 123, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_121"), 0, 40, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(122, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_122"), "sp_monthnotify_12_3", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_122"), new string[6] { "Location", "Adventure", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 1, 124, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_122"), 0, 40, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(123, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_123"), "sp_monthnotify_12_4", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_123"), new string[6] { "Location", "Adventure", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 1, 125, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_123"), 0, 40, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(124, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_124"), "sp_monthnotify_12_5", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_124"), new string[6] { "Location", "Adventure", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 1, 126, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_124"), 0, 40, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(125, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_125"), "sp_monthnotify_12_6", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_125"), new string[6] { "Location", "Adventure", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 1, 127, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_125"), 0, 40, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(126, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_126"), "sp_monthnotify_12_7", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_126"), new string[6] { "Location", "Adventure", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 1, 128, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_126"), 0, 40, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(127, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_127"), "sp_monthnotify_12_8", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_127"), new string[6] { "Location", "Adventure", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 129, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_127"), 0, 50, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(128, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_128"), "sp_monthnotify_12_9", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_128"), new string[6] { "Location", "Adventure", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 130, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_128"), 0, 50, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(129, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_129"), "sp_monthnotify_12_10", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_129"), new string[6] { "Location", "Adventure", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 131, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_129"), 0, 0, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(130, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_130"), "sp_monthnotify_12_11", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_130"), new string[6] { "Location", "Adventure", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 132, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_130"), 0, 0, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(131, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_131"), "sp_monthnotify_13_0", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_131"), new string[6] { "Location", "Adventure", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 152, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_131"), 0, 65, canFirstPage: true, "ui9_tex_month_notify_bg_0_3_2", allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(132, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_132"), "sp_monthnotify_13_1", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_132"), new string[6] { "Location", "Adventure", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 153, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_132"), 0, 64, canFirstPage: true, "ui9_tex_month_notify_bg_0_8_1", allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(133, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_133"), "sp_monthnotify_13_2", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_133"), new string[6] { "", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 154, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_133"), 0, 62, canFirstPage: true, "ui9_tex_month_notify_bg_0_10", allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(134, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_134"), "sp_monthnotify_13_3", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_134"), new string[6] { "Location", "Adventure", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 155, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_134"), 0, 66, canFirstPage: true, "ui9_tex_month_notify_bg_0_3_2", allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(135, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_135"), "sp_monthnotify_13_4", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_135"), new string[6] { "Location", "Adventure", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 156, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_135"), 0, 64, canFirstPage: true, "ui9_tex_month_notify_bg_0_8_1", allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(136, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_136"), "sp_monthnotify_13_5", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_136"), new string[6] { "Settlement", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, -1, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_136"), 0, 0, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(137, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_137"), "sp_monthnotify_13_6", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_137"), new string[6] { "Settlement", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, -1, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_137"), 0, 0, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(138, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_138"), "sp_monthnotify_13_7", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_138"), new string[6] { "Settlement", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, -1, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_138"), 0, 0, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(139, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_139"), "sp_monthnotify_13_8", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_139"), new string[6] { "Location", "Adventure", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 42, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_139"), 0, 0, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(140, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_140"), "sp_monthnotify_5_4", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_140"), new string[6] { "Character", "Character", "Location", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 46, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_140"), 0, 0, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(141, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_141"), "sp_monthnotify_14_0", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_141"), new string[6] { "SwordTomb", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 68, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_141"), 0, 98, canFirstPage: true, "ui9_tex_month_notify_bg_0_1", allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(142, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_142"), "sp_monthnotify_14_1", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_142"), new string[6] { "Location", "Character", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 99, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_142"), 0, 50, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(143, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_143"), "sp_monthnotify_14_2", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_143"), new string[6] { "Location", "Character", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 100, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_143"), 0, 50, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(144, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_144"), "sp_monthnotify_14_3", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_144"), new string[6] { "Location", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 101, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_144"), 0, 50, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(145, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_145"), "sp_monthnotify_14_4", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_145"), new string[6] { "Location", "Character", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 102, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_145"), 0, 50, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(146, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_146"), "sp_monthnotify_14_5", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_146"), new string[6] { "Location", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 103, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_146"), 0, 50, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(147, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_147"), "sp_monthnotify_14_6", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_147"), new string[6] { "Location", "Character", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 104, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_147"), 0, 50, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(148, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_148"), "sp_monthnotify_14_7", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_148"), new string[6] { "Location", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 105, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_148"), 0, 50, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(149, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_149"), "sp_monthnotify_14_8", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_149"), new string[6] { "Location", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 106, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_149"), 0, 50, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(150, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_150"), "sp_monthnotify_14_9", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_150"), new string[6] { "Location", "Character", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 107, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_150"), 0, 50, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(151, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_151"), "sp_monthnotify_14_10", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_151"), new string[6] { "Character", "Location", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 108, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_151"), 0, 40, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(152, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_152"), "sp_monthnotify_14_11", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_152"), new string[6] { "Character", "Location", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 109, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_152"), 0, 40, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(153, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_153"), "sp_monthnotify_14_12", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_153"), new string[6] { "Location", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 110, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_153"), 0, 40, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(154, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_154"), "sp_monthnotify_14_13", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_154"), new string[6] { "Character", "Location", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 111, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_154"), 0, 40, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(155, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_155"), "sp_monthnotify_14_14", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_155"), new string[6] { "Location", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 112, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_155"), 0, 40, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(156, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_156"), "sp_monthnotify_14_15", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_156"), new string[6] { "Character", "Location", "Character", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 113, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_156"), 0, 40, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(157, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_157"), "sp_monthnotify_14_16", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_157"), new string[6] { "Location", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 114, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_157"), 0, 40, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(158, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_158"), "sp_monthnotify_14_17", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_158"), new string[6] { "Character", "Location", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 115, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_158"), 0, 40, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(159, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_159"), "sp_monthnotify_14_18", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_159"), new string[6] { "Character", "Location", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 116, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_159"), 0, 40, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(160, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_160"), "sp_monthnotify_14_19", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_160"), new string[6] { "Character", "Location", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, -1, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_160"), 0, 0, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(161, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_161"), "sp_monthnotify_15_0", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_161"), new string[6] { "Settlement", "MerchantType", "", "", "", "" }, new List<sbyte> { 1 }, EMonthlyNotificationSectionType.Worldwide, 0, 31, new List<sbyte> { 0 }, 1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_161"), 1, 31, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(162, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_162"), "sp_monthnotify_15_1", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_162"), new string[6] { "Chicken", "", "", "", "", "" }, new List<sbyte> { 0 }, EMonthlyNotificationSectionType.TaiwuVillage, 0, 146, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_162"), 0, 60, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(163, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_163"), "sp_monthnotify_15_2", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_163"), new string[6] { "Location", "Integer", "Integer", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 32, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_163"), 0, 85, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(164, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_164"), "sp_monthnotify_15_3", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_164"), new string[6] { "Character", "Character", "Settlement", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 65, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_164"), 0, 70, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(165, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_165"), "sp_monthnotify_15_4", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_165"), new string[6] { "CombatSkill", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 44, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_165"), 0, 70, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(166, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_166"), "sp_monthnotify_16_0", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_166"), new string[6] { "Settlement", "Building", "", "", "", "" }, null, EMonthlyNotificationSectionType.TaiwuVillage, 0, 75, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_166"), 0, 100, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(167, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_167"), "sp_monthnotify_16_1", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_167"), new string[6] { "", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 69, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_167"), 0, 90, canFirstPage: true, "ui9_tex_month_notify_bg_0_9", allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(168, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_168"), "sp_monthnotify_16_2", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_168"), new string[6] { "Character", "Location", "Item", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 91, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_168"), 0, 90, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(169, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_169"), "sp_monthnotify_16_3", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_169"), new string[6] { "", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 33, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_169"), 0, 99, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(170, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_170"), "sp_monthnotify_17_0", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_170"), new string[6] { "", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 33, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_170"), 0, 0, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(171, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_171"), "sp_monthnotify_17_1", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_171"), new string[6] { "Location", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 33, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_171"), 0, 97, canFirstPage: true, "ui9_tex_month_notify_bg_0_2", allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(172, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_172"), "sp_monthnotify_17_2", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_172"), new string[6] { "Location", "Integer", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 75, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_172"), 0, 80, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(173, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_173"), "sp_monthnotify_17_3", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_173"), new string[6] { "", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 1, 117, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_173"), 0, 50, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(174, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_174"), "sp_monthnotify_17_4", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_174"), new string[6] { "", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 1, 118, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_174"), 0, 50, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(175, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_175"), "sp_monthnotify_17_5", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_175"), new string[6] { "", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 1, 120, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_175"), 0, 50, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(176, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_176"), "sp_monthnotify_17_6", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_176"), new string[6] { "", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 1, 120, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_176"), 0, 50, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(177, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_177"), "sp_monthnotify_17_7", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_177"), new string[6] { "Character", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.TaiwuVillage, 0, 75, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_177"), 0, 100, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(178, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_178"), "sp_monthnotify_17_8", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_178"), new string[6] { "", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.TaiwuVillage, 0, 149, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_178"), 0, 70, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(179, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_179"), "sp_monthnotify_17_9", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_179"), new string[6] { "", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.TaiwuVillage, 0, 150, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_179"), 0, 70, canFirstPage: false, null, allowByEventFunction: false));
	}

	private void CreateItems3()
	{
		_dataArray.Add(new MonthlyNotificationItem(180, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_180"), "sp_monthnotify_17_10", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_180"), new string[6] { "", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.TaiwuVillage, 0, 151, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_180"), 0, 70, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(181, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_181"), "sp_monthnotify_17_11", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_181"), new string[6] { "Character", "Integer", "", "", "", "" }, new List<sbyte> { 1 }, EMonthlyNotificationSectionType.Biography, 0, 119, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_181"), 0, 50, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(182, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_182"), "sp_monthnotify_17_12", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_182"), new string[6] { "Location", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 43, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_182"), 0, 0, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(183, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_183"), "sp_monthnotify_13_7", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_183"), new string[6] { "Location", "Adventure", "", "", "", "" }, new List<sbyte> { 0 }, EMonthlyNotificationSectionType.Worldwide, 0, 34, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_183"), 0, 70, canFirstPage: true, "ui9_tex_month_notify_bg_0_7", allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(184, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_184"), "sp_monthnotify_17_13", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_184"), new string[6] { "Location", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 35, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_184"), 0, 75, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(185, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_185"), "sp_monthnotify_17_14", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_185"), new string[6] { "Location", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 36, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_185"), 0, 65, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(186, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_186"), "sp_monthnotify_17_15", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_186"), new string[6] { "Location", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, -1, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_186"), 0, 0, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(187, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_187"), "sp_monthnotify_18_0", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_187"), new string[6] { "Character", "Location", "Character", "Adventure", "", "" }, null, EMonthlyNotificationSectionType.TaiwuVillage, 1, -1, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_187"), 0, 0, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(188, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_188"), "sp_monthnotify_18_1", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_188"), new string[6] { "Character", "Location", "Character", "Adventure", "", "" }, null, EMonthlyNotificationSectionType.TaiwuVillage, 1, -1, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_188"), 0, 0, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(189, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_189"), "sp_monthnotify_18_2", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_189"), new string[6] { "Character", "Location", "Character", "Adventure", "", "" }, null, EMonthlyNotificationSectionType.TaiwuVillage, 1, -1, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_189"), 0, 0, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(190, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_190"), "sp_monthnotify_18_3", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_190"), new string[6] { "Character", "Location", "Character", "Adventure", "", "" }, null, EMonthlyNotificationSectionType.TaiwuVillage, 1, -1, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_190"), 0, 0, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(191, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_191"), "sp_monthnotify_18_4", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_191"), new string[6] { "Character", "Location", "Character", "Adventure", "", "" }, null, EMonthlyNotificationSectionType.TaiwuVillage, 1, -1, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_191"), 0, 0, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(192, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_192"), "sp_monthnotify_18_5", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_192"), new string[6] { "Character", "Location", "Character", "Adventure", "", "" }, null, EMonthlyNotificationSectionType.TaiwuVillage, 1, -1, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_192"), 0, 0, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(193, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_193"), "sp_monthnotify_17_16", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_193"), new string[6] { "Character", "Location", "Building", "Character", "", "" }, null, EMonthlyNotificationSectionType.TaiwuVillage, 0, -1, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_193"), 0, 0, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(194, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_194"), "sp_monthnotify_17_17", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_194"), new string[6] { "Settlement", "Character", "", "", "", "" }, new List<sbyte> { 1 }, EMonthlyNotificationSectionType.TaiwuVillage, 1, 72, null, 3, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_194"), 2, 40, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(195, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_195"), "sp_monthnotify_17_18", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_195"), new string[6] { "", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.TaiwuVillage, 1, 147, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_195"), 0, 30, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(196, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_196"), "sp_monthnotify_19_0", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_196"), new string[6] { "", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.TaiwuVillage, 1, 147, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_196"), 0, 30, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(197, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_197"), "sp_monthnotify_19_1", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_197"), new string[6] { "", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.TaiwuVillage, 1, 147, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_197"), 0, 30, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(198, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_198"), "sp_monthnotify_19_3", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_198"), new string[6] { "", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.TaiwuVillage, 1, 147, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_198"), 0, 30, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(199, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_199"), "sp_monthnotify_19_2", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_199"), new string[6] { "", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.TaiwuVillage, 1, 147, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_199"), 0, 30, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(200, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_200"), "sp_monthnotify_19_4", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_200"), new string[6] { "", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.TaiwuVillage, 1, 147, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_200"), 0, 30, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(201, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_201"), "sp_monthnotify_19_5", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_201"), new string[6] { "", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.TaiwuVillage, 1, 147, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_201"), 0, 30, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(202, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_202"), "sp_monthnotify_19_6", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_202"), new string[6] { "", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.TaiwuVillage, 1, 147, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_202"), 0, 30, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(203, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_203"), "sp_monthnotify_19_7", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_203"), new string[6] { "", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.TaiwuVillage, 1, 147, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_203"), 0, 30, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(204, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_204"), "sp_monthnotify_19_8", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_204"), new string[6] { "", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.TaiwuVillage, 1, 147, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_204"), 0, 30, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(205, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_205"), "sp_monthnotify_19_9", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_205"), new string[6] { "", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.TaiwuVillage, 1, 147, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_205"), 0, 30, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(206, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_206"), "sp_monthnotify_19_10", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_206"), new string[6] { "", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.TaiwuVillage, 1, 147, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_206"), 0, 30, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(207, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_207"), "sp_monthnotify_19_11", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_207"), new string[6] { "", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.TaiwuVillage, 1, 147, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_207"), 0, 30, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(208, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_208"), "sp_monthnotify_19_12", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_208"), new string[6] { "", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.TaiwuVillage, 1, 147, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_208"), 0, 30, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(209, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_209"), "sp_monthnotify_19_13", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_209"), new string[6] { "", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.TaiwuVillage, 1, 147, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_209"), 0, 30, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(210, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_210"), "sp_monthnotify_19_14", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_210"), new string[6] { "", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.TaiwuVillage, 1, 147, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_210"), 0, 30, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(211, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_211"), "sp_monthnotify_19_15", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_211"), new string[6] { "", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.TaiwuVillage, 1, 147, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_211"), 0, 30, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(212, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_212"), "sp_monthnotify_19_16", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_212"), new string[6] { "", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.TaiwuVillage, 1, 147, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_212"), 0, 30, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(213, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_213"), "sp_monthnotify_19_17", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_213"), new string[6] { "", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.TaiwuVillage, 0, 148, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_213"), 0, 70, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(214, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_214"), "sp_monthnotify_17_20", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_214"), new string[6] { "Character", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 60, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_214"), 0, 90, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(215, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_215"), "sp_monthnotify_18_6", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_215"), new string[6] { "Location", "Adventure", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 135, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_215"), 0, 50, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(216, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_216"), "sp_monthnotify_17_22", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_216"), new string[6] { "", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, -1, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_216"), 0, 0, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(217, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_217"), "sp_monthnotify_15_14", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_217"), new string[6] { "ItemKey", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 73, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_217"), 0, 40, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(218, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_218"), "sp_monthnotify_20_1", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_218"), new string[6] { "Location", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, -1, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_218"), 0, 0, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(219, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_219"), "sp_monthnotify_20_8", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_219"), new string[6] { "Location", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 98, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_219"), 0, 55, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(220, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_220"), "sp_monthnotify_20_7", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_220"), new string[6] { "Location", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 98, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_220"), 0, 55, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(221, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_221"), "sp_monthnotify_20_11", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_221"), new string[6] { "", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 98, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_221"), 0, 55, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(222, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_222"), "sp_monthnotify_20_13", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_222"), new string[6] { "Character", "Location", "Item", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 95, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_222"), 0, 60, canFirstPage: true, "ui9_tex_month_notify_bg_0_4", allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(223, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_223"), "sp_monthnotify_20_12", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_223"), new string[6] { "Character", "Location", "Item", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 96, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_223"), 0, 60, canFirstPage: true, "ui9_tex_month_notify_bg_0_4", allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(224, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_224"), "sp_monthnotify_20_3", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_224"), new string[6] { "Character", "Location", "Item", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 97, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_224"), 0, 60, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(225, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_225"), "sp_monthnotify_20_4", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_225"), new string[6] { "Character", "Location", "Item", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 93, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_225"), 0, 92, canFirstPage: true, "ui9_tex_month_notify_bg_0_6", allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(226, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_226"), "sp_monthnotify_20_6", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_226"), new string[6] { "Location", "Item", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 90, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_226"), 0, 92, canFirstPage: true, "ui9_tex_month_notify_bg_0_6", allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(227, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_227"), "sp_monthnotify_20_6", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_227"), new string[6] { "Character", "Location", "Item", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 90, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_227"), 0, 92, canFirstPage: true, "ui9_tex_month_notify_bg_0_6", allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(228, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_228"), "sp_monthnotify_20_6", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_228"), new string[6] { "Character", "Location", "Item", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 90, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_228"), 0, 92, canFirstPage: true, "ui9_tex_month_notify_bg_0_6", allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(229, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_229"), "sp_monthnotify_20_6", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_229"), new string[6] { "Character", "Location", "Item", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 90, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_229"), 0, 92, canFirstPage: true, "ui9_tex_month_notify_bg_0_6", allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(230, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_230"), "sp_monthnotify_20_0", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_230"), new string[6] { "Character", "Location", "Item", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 90, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_230"), 0, 92, canFirstPage: true, "ui9_tex_month_notify_bg_0_6", allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(231, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_231"), "sp_monthnotify_20_5", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_231"), new string[6] { "Character", "Location", "Character", "Item", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 92, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_231"), 0, 80, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(232, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_232"), "sp_monthnotify_20_10", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_232"), new string[6] { "Character", "Location", "Character", "Item", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 92, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_232"), 0, 80, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(233, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_233"), "sp_monthnotify_20_14", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_233"), new string[6] { "Character", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 94, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_233"), 0, 55, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(234, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_234"), null, LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_234"), new string[6] { "Month", "Character", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 37, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_234"), 0, 65, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(235, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_235"), "sp_monthnotify_21_0", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_235"), new string[6] { "Character", "Location", "Item", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 85, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_235"), 0, 35, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(236, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_236"), "sp_monthnotify_21_1", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_236"), new string[6] { "Character", "Location", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 86, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_236"), 0, 35, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(237, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_237"), "sp_monthnotify_21_2", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_237"), new string[6] { "Character", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 87, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_237"), 0, 35, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(238, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_238"), "sp_monthnotify_21_3", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_238"), new string[6] { "Character", "Location", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 88, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_238"), 0, 35, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(239, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_239"), "sp_monthnotify_21_4", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_239"), new string[6] { "Character", "Location", "Character", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 89, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_239"), 0, 35, canFirstPage: false, null, allowByEventFunction: false));
	}

	private void CreateItems4()
	{
		_dataArray.Add(new MonthlyNotificationItem(240, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_240"), "sp_monthnotify_21_5", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_240"), new string[6] { "Character", "Location", "Character", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 89, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_240"), 0, 35, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(241, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_241"), "sp_monthnotify_21_6", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_241"), new string[6] { "Character", "Location", "Character", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 89, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_241"), 0, 35, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(242, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_242"), "sp_monthnotify_21_7", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_242"), new string[6] { "Character", "Location", "Character", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 89, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_242"), 0, 35, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(243, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_243"), "sp_monthnotify_21_4", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_243"), new string[6] { "Character", "Location", "Character", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 89, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_243"), 0, 30, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(244, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_244"), "sp_monthnotify_21_5", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_244"), new string[6] { "Character", "Location", "Character", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 89, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_244"), 0, 30, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(245, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_245"), "sp_monthnotify_21_6", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_245"), new string[6] { "Character", "Location", "Character", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 89, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_245"), 0, 30, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(246, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_246"), "sp_monthnotify_21_7", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_246"), new string[6] { "Character", "Location", "Character", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 89, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_246"), 0, 30, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(247, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_247"), "sp_monthnotify_22_0", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_247"), new string[6] { "Location", "Integer", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 76, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_247"), 0, 75, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(248, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_248"), "sp_monthlyevent_2", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_248"), new string[6] { "Character", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, -1, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_248"), 0, 0, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(249, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_249"), "sp_monthnotify_22_4", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_249"), new string[6] { "", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 77, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_249"), 0, 80, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(250, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_250"), "sp_monthnotify_22_1", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_250"), new string[6] { "", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 76, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_250"), 0, 80, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(251, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_251"), "sp_monthnotify_17_23", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_251"), new string[6] { "Settlement", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 33, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_251"), 0, 99, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(252, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_252"), "sp_monthnotify_22_7", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_252"), new string[6] { "Character", "Location", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 1, 78, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_252"), 0, 80, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(253, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_253"), "sp_monthnotify_22_8", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_253"), new string[6] { "", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 78, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_253"), 0, 80, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(254, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_254"), "sp_monthnotify_22_1", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_254"), new string[6] { "", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 76, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_254"), 0, 80, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(255, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_255"), "sp_monthnotify_22_2", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_255"), new string[6] { "Character", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 76, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_255"), 0, 80, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(256, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_256"), "sp_monthnotify_22_1", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_256"), new string[6] { "Character", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 76, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_256"), 0, 80, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(257, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_257"), "sp_monthnotify_22_3", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_257"), new string[6] { "Location", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 79, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_257"), 0, 80, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(258, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_258"), "sp_monthnotify_22_3", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_258"), new string[6] { "Location", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 79, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_258"), 0, 80, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(259, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_259"), "sp_monthnotify_22_3", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_259"), new string[6] { "Location", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 79, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_259"), 0, 80, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(260, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_260"), "sp_monthnotify_22_3", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_260"), new string[6] { "Location", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 79, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_260"), 0, 80, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(261, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_261"), "sp_monthnotify_15_3", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_261"), new string[6] { "Character", "Character", "Location", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 65, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_261"), 0, 70, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(262, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_262"), "sp_monthnotify_22_5", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_262"), new string[6] { "Integer", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 80, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_262"), 0, 80, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(263, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_263"), "sp_monthnotify_22_6", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_263"), new string[6] { "Character", "Location", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 80, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_263"), 0, 80, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(264, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_264"), "sp_monthnotify_15_6", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_264"), new string[6] { "Character", "Location", "CharacterTemplate", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 2, 38, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_264"), 0, 35, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(265, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_265"), "sp_monthnotify_15_7", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_265"), new string[6] { "Character", "Location", "CharacterTemplate", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 2, 38, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_265"), 0, 35, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(266, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_266"), "sp_monthnotify_15_8", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_266"), new string[6] { "Character", "Location", "CharacterTemplate", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 2, 39, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_266"), 0, 35, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(267, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_267"), "sp_monthnotify_15_9", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_267"), new string[6] { "Character", "Location", "CharacterTemplate", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 2, 39, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_267"), 0, 35, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(268, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_268"), "sp_monthnotify_15_10", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_268"), new string[6] { "Character", "Location", "CharacterTemplate", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 2, 40, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_268"), 0, 30, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(269, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_269"), "sp_monthnotify_15_11", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_269"), new string[6] { "Character", "Location", "CharacterTemplate", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 2, 40, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_269"), 0, 30, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(270, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_270"), "sp_monthnotify_15_12", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_270"), new string[6] { "Character", "Location", "Adventure", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 2, 134, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_270"), 0, 80, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(271, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_271"), "sp_monthnotify_22_0", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_271"), new string[6] { "Location", "Integer", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, -1, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_271"), 0, 0, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(272, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_272"), "sp_monthlyevent_2", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_272"), new string[6] { "Character", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, -1, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_272"), 0, 0, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(273, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_273"), "sp_monthnotify_22_4", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_273"), new string[6] { "", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, -1, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_273"), 0, 0, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(274, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_274"), "sp_monthnotify_15_5", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_274"), new string[6] { "Character", "Location", "Character", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 66, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_274"), 0, 70, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(275, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_275"), "sp_monthnotify_15_5", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_275"), new string[6] { "Character", "Location", "Character", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 66, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_275"), 0, 70, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(276, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_276"), "sp_monthnotify_15_5", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_276"), new string[6] { "Character", "Location", "Character", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 66, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_276"), 0, 70, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(277, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_277"), "sp_monthnotify_22_9", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_277"), new string[6] { "", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 78, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_277"), 0, 80, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(278, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_278"), "sp_monthnotify_22_10", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_278"), new string[6] { "", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 78, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_278"), 0, 80, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(279, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_279"), "sp_monthnotify_12_12", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_279"), new string[6] { "Character", "Location", "Adventure", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 2, 133, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_279"), 0, 80, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(280, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_280"), "sp_monthnotify_12_13", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_280"), new string[6] { "Character", "Location", "Adventure", "Character", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 2, 133, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_280"), 0, 80, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(281, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_281"), "sp_monthnotify_15_13", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_281"), new string[6] { "Settlement", "Character", "Building", "", "", "" }, null, EMonthlyNotificationSectionType.TaiwuVillage, 0, 41, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_281"), 0, 50, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(282, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_282"), "sp_monthnotify_22_24", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_282"), new string[6] { "Location", "CharacterTemplate", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 47, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_282"), 0, 96, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(283, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_283"), "sp_monthnotify_22_11", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_283"), new string[6] { "Location", "JiaoLoong", "", "", "", "" }, null, EMonthlyNotificationSectionType.TaiwuVillage, 0, 48, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_283"), 0, 55, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(284, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_284"), "sp_monthnotify_22_12", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_284"), new string[6] { "Location", "JiaoLoong", "", "", "", "" }, null, EMonthlyNotificationSectionType.TaiwuVillage, 0, 49, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_284"), 0, 70, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(285, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_285"), "sp_monthnotify_22_13", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_285"), new string[6] { "Location", "JiaoLoong", "", "", "", "" }, null, EMonthlyNotificationSectionType.TaiwuVillage, 0, 50, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_285"), 0, 55, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(286, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_286"), "sp_monthnotify_22_14", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_286"), new string[6] { "Location", "JiaoLoong", "", "", "", "" }, null, EMonthlyNotificationSectionType.TaiwuVillage, 0, 50, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_286"), 0, 55, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(287, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_287"), "sp_monthnotify_22_15", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_287"), new string[6] { "Character", "Location", "JiaoLoong", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 51, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_287"), 0, 80, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(288, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_288"), "sp_monthnotify_22_16", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_288"), new string[6] { "Character", "Location", "JiaoLoong", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 52, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_288"), 0, 80, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(289, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_289"), "sp_monthnotify_22_17", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_289"), new string[6] { "Location", "JiaoLoong", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 53, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_289"), 0, 80, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(290, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_290"), "sp_monthnotify_22_18", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_290"), new string[6] { "JiaoLoong", "Cricket", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 54, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_290"), 0, 80, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(291, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_291"), "sp_monthnotify_22_19", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_291"), new string[6] { "Location", "JiaoLoong", "Item", "Integer", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 55, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_291"), 0, 80, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(292, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_292"), "sp_monthnotify_22_20", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_292"), new string[6] { "Character", "Location", "JiaoLoong", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 56, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_292"), 0, 80, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(293, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_293"), "sp_monthnotify_22_21", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_293"), new string[6] { "Location", "JiaoLoong", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 57, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_293"), 0, 80, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(294, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_294"), "sp_monthnotify_22_22", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_294"), new string[6] { "Location", "JiaoLoong", "Item", "Integer", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 58, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_294"), 0, 80, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(295, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_295"), "sp_monthnotify_22_23", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_295"), new string[6] { "Location", "JiaoLoong", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 59, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_295"), 0, 80, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(296, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_296"), "sp_monthnotify_22_25", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_296"), new string[6] { "Location", "JiaoLoong", "JiaoLoong", "", "", "" }, null, EMonthlyNotificationSectionType.TaiwuVillage, 0, 50, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_296"), 0, 55, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(297, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_297"), "sp_monthnotify_22_12", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_297"), new string[6] { "Location", "JiaoLoong", "", "", "", "" }, new List<sbyte> { 1 }, EMonthlyNotificationSectionType.TaiwuVillage, 0, 50, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_297"), 0, 55, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(298, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_298"), "sp_monthnotify_2_2", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_298"), new string[6] { "Character", "Location", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 61, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_298"), 0, 70, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(299, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_299"), "sp_monthnotify_2_2", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_299"), new string[6] { "Character", "Location", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 62, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_299"), 0, 70, canFirstPage: false, null, allowByEventFunction: false));
	}

	private void CreateItems5()
	{
		_dataArray.Add(new MonthlyNotificationItem(300, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_300"), "sp_monthnotify_2_0", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_300"), new string[6] { "Character", "Location", "Character", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 63, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_300"), 0, 80, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(301, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_301"), "sp_monthnotify_22_30", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_301"), new string[6] { "Character", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 82, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_301"), 0, 80, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(302, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_302"), "sp_monthnotify_22_29", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_302"), new string[6] { "Character", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 82, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_302"), 0, 80, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(303, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_303"), "sp_monthnotify_22_27", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_303"), new string[6] { "", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 82, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_303"), 0, 90, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(304, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_304"), "sp_monthnotify_22_28", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_304"), new string[6] { "", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 82, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_304"), 0, 90, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(305, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_305"), "sp_monthnotify_22_26", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_305"), new string[6] { "Character", "Location", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 82, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_305"), 0, 90, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(306, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_306"), "sp_monthnotify_22_31", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_306"), new string[6] { "Item", "Location", "Character", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 81, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_306"), 0, 90, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(307, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_307"), "sp_monthnotify_22_32", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_307"), new string[6] { "Character", "Item", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 81, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_307"), 0, 90, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(308, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_308"), "sp_monthnotify_22_32", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_308"), new string[6] { "Character", "Item", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 81, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_308"), 0, 90, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(309, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_309"), "sp_monthnotify_22_33", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_309"), new string[6] { "", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 82, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_309"), 0, 90, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(310, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_310"), "sp_monthnotify_22_34", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_310"), new string[6] { "", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 82, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_310"), 0, 90, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(311, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_311"), "sp_monthnotify_22_35", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_311"), new string[6] { "Character", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 81, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_311"), 0, 90, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(312, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_312"), "sp_monthnotify_22_26", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_312"), new string[6] { "Character", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 82, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_312"), 0, 90, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(313, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_313"), "sp_monthnotify_22_36", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_313"), new string[6] { "", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 83, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_313"), 0, 90, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(314, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_314"), "sp_monthnotify_22_37", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_314"), new string[6] { "Character", "Item", "Location", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 83, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_314"), 0, 80, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(315, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_315"), "sp_monthnotify_22_38", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_315"), new string[6] { "Character", "Item", "Location", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 83, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_315"), 0, 80, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(316, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_316"), "sp_monthnotify_22_39", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_316"), new string[6] { "Character", "Item", "Location", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 83, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_316"), 0, 80, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(317, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_317"), "sp_monthnotify_22_40", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_317"), new string[6] { "Character", "Item", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 83, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_317"), 0, 80, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(318, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_318"), "sp_monthnotify_22_41", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_318"), new string[6] { "Character", "Item", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 83, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_318"), 0, 80, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(319, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_319"), "sp_monthnotify_22_42", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_319"), new string[6] { "Character", "Item", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 83, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_319"), 0, 80, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(320, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_320"), "sp_monthnotify_22_40", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_320"), new string[6] { "Character", "Item", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 83, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_320"), 0, 80, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(321, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_321"), "sp_monthnotify_22_41", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_321"), new string[6] { "Character", "Item", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 83, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_321"), 0, 80, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(322, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_322"), "sp_monthnotify_22_42", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_322"), new string[6] { "Character", "Item", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 83, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_322"), 0, 80, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(323, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_323"), "sp_monthnotify_22_40", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_323"), new string[6] { "Character", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 83, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_323"), 0, 80, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(324, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_324"), "sp_monthnotify_22_41", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_324"), new string[6] { "Character", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 83, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_324"), 0, 80, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(325, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_325"), "sp_monthnotify_22_42", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_325"), new string[6] { "Character", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 83, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_325"), 0, 80, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(326, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_326"), "sp_monthnotify_22_43", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_326"), new string[6] { "Character", "", "", "", "", "" }, new List<sbyte> { 0 }, EMonthlyNotificationSectionType.Biography, 0, 84, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_326"), 0, 80, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(327, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_327"), "sp_monthnotify_22_44", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_327"), new string[6] { "Character", "", "", "", "", "" }, new List<sbyte> { 0 }, EMonthlyNotificationSectionType.Biography, 0, 84, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_327"), 0, 80, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(328, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_328"), "sp_monthnotify_22_46", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_328"), new string[6] { "Location", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 84, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_328"), 0, 90, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(329, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_329"), "sp_monthnotify_22_47", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_329"), new string[6] { "Location", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 84, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_329"), 0, 90, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(330, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_330"), "sp_monthnotify_22_48", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_330"), new string[6] { "", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 84, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_330"), 0, 80, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(331, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_331"), "sp_monthnotify_22_49", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_331"), new string[6] { "", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 84, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_331"), 0, 80, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(332, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_332"), "sp_monthnotify_22_50", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_332"), new string[6] { "Location", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 84, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_332"), 0, 90, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(333, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_333"), "sp_monthnotify_22_51", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_333"), new string[6] { "Location", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 84, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_333"), 0, 90, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(334, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_334"), "sp_monthnotify_15_15", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_334"), new string[6] { "CombatSkill", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 74, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_334"), 0, 80, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(335, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_335"), "sp_monthnotify_22_52", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_335"), new string[6] { "", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 84, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_335"), 0, 80, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(336, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_336"), "sp_monthnotify_11_9", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_336"), new string[6] { "Settlement", "Building", "", "", "", "" }, null, EMonthlyNotificationSectionType.TaiwuVillage, 0, 191, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_336"), 0, 40, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(337, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_337"), "sp_monthnotify_22_53", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_337"), new string[6] { "", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 194, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_337"), 0, 90, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(338, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_338"), "sp_monthnotify_22_54", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_338"), new string[6] { "Chicken", "", "", "", "", "" }, new List<sbyte> { 0 }, EMonthlyNotificationSectionType.Worldwide, 0, 194, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_338"), 0, 90, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(339, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_339"), "sp_monthnotify_13_9", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_339"), new string[6] { "Location", "Adventure", "Integer", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 152, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_339"), 0, 0, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(340, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_340"), "sp_monthnotify_13_10", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_340"), new string[6] { "Location", "Adventure", "Integer", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 153, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_340"), 0, 0, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(341, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_341"), "sp_monthnotify_13_11", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_341"), new string[6] { "Location", "Adventure", "Integer", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 155, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_341"), 0, 0, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(342, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_342"), "sp_monthnotify_13_12", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_342"), new string[6] { "Location", "Adventure", "Integer", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 156, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_342"), 0, 0, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(343, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_343"), "sp_monthnotify_13_14", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_343"), new string[6] { "Location", "Adventure", "Integer", "", "", "" }, new List<sbyte> { 0 }, EMonthlyNotificationSectionType.Worldwide, 0, 34, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_343"), 0, 0, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(344, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_344"), "sp_monthnotify_13_13", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_344"), new string[6] { "Location", "Adventure", "Integer", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 42, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_344"), 0, 0, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(345, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_345"), "sp_monthnotify_15_18", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_345"), new string[6] { "Character", "", "", "", "", "" }, new List<sbyte> { 0 }, EMonthlyNotificationSectionType.Biography, 0, 192, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_345"), 0, 90, canFirstPage: true, "ui9_tex_month_notify_bg_0_5", allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(346, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_346"), "sp_monthnotify_15_17", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_346"), new string[6] { "Character", "", "", "", "", "" }, new List<sbyte> { 0 }, EMonthlyNotificationSectionType.Biography, 0, 192, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_346"), 0, 90, canFirstPage: true, "ui9_tex_month_notify_bg_0_5", allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(347, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_347"), "sp_monthnotify_15_16", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_347"), new string[6] { "Character", "", "", "", "", "" }, new List<sbyte> { 0 }, EMonthlyNotificationSectionType.Biography, 0, 192, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_347"), 0, 90, canFirstPage: true, "ui9_tex_month_notify_bg_0_5", allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(348, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_348"), "sp_monthnotify_22_55", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_348"), new string[6] { "Character", "Settlement", "", "", "", "" }, new List<sbyte> { 0 }, EMonthlyNotificationSectionType.Worldwide, 0, 194, new List<sbyte> { 1 }, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_348"), 0, 90, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(349, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_349"), "sp_monthnotify_22_56", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_349"), new string[6] { "Character", "Settlement", "", "", "", "" }, new List<sbyte> { 0 }, EMonthlyNotificationSectionType.Worldwide, 0, 194, new List<sbyte> { 1 }, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_349"), 0, 90, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(350, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_350"), "sp_monthnotify_22_56", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_350"), new string[6] { "Character", "Settlement", "", "", "", "" }, new List<sbyte> { 0 }, EMonthlyNotificationSectionType.Worldwide, 0, 194, new List<sbyte> { 1 }, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_350"), 0, 90, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(351, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_351"), "sp_monthnotify_22_56", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_351"), new string[6] { "Character", "Settlement", "", "", "", "" }, new List<sbyte> { 0 }, EMonthlyNotificationSectionType.Worldwide, 0, 194, new List<sbyte> { 1 }, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_351"), 0, 90, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(352, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_352"), "sp_monthnotify_22_56", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_352"), new string[6] { "Character", "Settlement", "", "", "", "" }, new List<sbyte> { 0 }, EMonthlyNotificationSectionType.Worldwide, 0, 194, new List<sbyte> { 1 }, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_352"), 0, 90, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(353, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_353"), "sp_monthnotify_7_16", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_353"), new string[6] { "Character", "Settlement", "Character", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 193, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_353"), 0, 90, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(354, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_354"), "sp_monthnotify_7_17", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_354"), new string[6] { "Character", "Settlement", "Character", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 193, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_354"), 0, 90, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(355, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_355"), "sp_monthnotify_7_18", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_355"), new string[6] { "Character", "Settlement", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 193, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_355"), 0, 90, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(356, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_356"), "sp_monthnotify_7_19", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_356"), new string[6] { "Character", "Settlement", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 193, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_356"), 0, 90, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(357, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_357"), "sp_monthnotify_7_19", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_357"), new string[6] { "Character", "Settlement", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 193, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_357"), 0, 90, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(358, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_358"), "sp_monthnotify_7_20", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_358"), new string[6] { "Character", "Settlement", "Character", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 193, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_358"), 0, 90, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(359, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_359"), "sp_monthnotify_7_17", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_359"), new string[6] { "Character", "Settlement", "Character", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 193, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_359"), 0, 90, canFirstPage: false, null, allowByEventFunction: false));
	}

	private void CreateItems6()
	{
		_dataArray.Add(new MonthlyNotificationItem(360, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_360"), "sp_monthnotify_17_26", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_360"), new string[6] { "Character", "Location", "Item", "", "", "" }, null, EMonthlyNotificationSectionType.TaiwuVillage, 0, 191, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_360"), 0, 40, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(361, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_361"), "sp_monthnotify_17_27", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_361"), new string[6] { "Character", "Location", "Character", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 118, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_361"), 0, 50, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(362, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_362"), "sp_monthnotify_17_28", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_362"), new string[6] { "Character", "SwordTomb", "CharacterTemplate", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 117, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_362"), 0, 50, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(363, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_363"), "sp_monthnotify_22_57", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_363"), new string[6] { "", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 194, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_363"), 0, 80, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(364, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_364"), "sp_monthnotify_22_56", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_364"), new string[6] { "", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 194, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_364"), 0, 90, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(365, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_365"), "sp_monthnotify_22_58", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_365"), new string[6] { "Location", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 80, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_365"), 0, 80, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(366, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_366"), "sp_monthnotify_22_36", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_366"), new string[6] { "", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 195, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_366"), 0, 90, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(367, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_367"), "sp_monthnotify_19_18", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_367"), new string[6] { "Merchant", "Settlement", "Integer", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 31, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_367"), 0, 30, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(368, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_368"), "sp_monthnotify_19_19", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_368"), new string[6] { "Merchant", "Settlement", "Integer", "Settlement", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 31, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_368"), 0, 30, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(369, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_369"), "sp_monthnotify_19_19", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_369"), new string[6] { "Merchant", "Settlement", "Integer", "Settlement", "Integer", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 31, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_369"), 0, 30, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(370, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_370"), "sp_monthnotify_19_19", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_370"), new string[6] { "Merchant", "Settlement", "Integer", "Settlement", "Integer", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 31, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_370"), 0, 30, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(371, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_371"), "sp_monthnotify_19_19", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_371"), new string[6] { "Merchant", "Settlement", "Integer", "Settlement", "Integer", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 31, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_371"), 0, 30, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(372, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_372"), "sp_monthnotify_19_19", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_372"), new string[6] { "Merchant", "Settlement", "Integer", "Settlement", "Integer", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 31, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_372"), 0, 30, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(373, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_373"), "sp_monthnotify_19_19", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_373"), new string[6] { "Merchant", "Settlement", "Integer", "Settlement", "Integer", "Integer" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 31, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_373"), 0, 30, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(374, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_374"), "sp_monthnotify_19_19", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_374"), new string[6] { "Merchant", "Settlement", "Integer", "Settlement", "Integer", "Integer" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 31, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_374"), 0, 30, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(375, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_375"), "sp_monthnotify_19_19", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_375"), new string[6] { "Merchant", "Settlement", "Integer", "Settlement", "Integer", "Integer" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 31, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_375"), 0, 30, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(376, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_376"), "sp_monthnotify_19_19", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_376"), new string[6] { "Merchant", "Settlement", "Integer", "Settlement", "Integer", "Integer" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 31, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_376"), 0, 30, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(377, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_377"), "sp_monthnotify_19_22", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_377"), new string[6] { "Merchant", "Settlement", "Integer", "MerchantType", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 31, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_377"), 0, 30, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(378, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_378"), "sp_monthnotify_19_20", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_378"), new string[6] { "Merchant", "Location", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 31, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_378"), 0, 30, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(379, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_379"), "sp_monthnotify_19_21", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_379"), new string[6] { "Merchant", "Location", "Integer", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 31, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_379"), 0, 30, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(380, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_380"), "sp_monthnotify_11_10", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_380"), new string[6] { "Settlement", "Building", "", "", "", "" }, new List<sbyte> { 1 }, EMonthlyNotificationSectionType.TaiwuVillage, 0, 196, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_380"), 0, 60, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(381, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_381"), "sp_monthnotify_11_13", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_381"), new string[6] { "Settlement", "PunishmentType", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 197, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_381"), 0, 60, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(382, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_382"), "sp_monthnotify_11_13", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_382"), new string[6] { "Settlement", "PunishmentType", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 197, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_382"), 0, 60, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(383, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_383"), "sp_monthnotify_11_14", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_383"), new string[6] { "Character", "Settlement", "", "", "", "" }, null, EMonthlyNotificationSectionType.TaiwuVillage, 0, 198, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_383"), 0, 0, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(384, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_384"), "sp_monthnotify_11_14", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_384"), new string[6] { "Item", "", "", "", "", "" }, new List<sbyte> { 0 }, EMonthlyNotificationSectionType.TaiwuVillage, 0, 198, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_384"), 0, 0, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(385, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_385"), "sp_monthnotify_11_14", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_385"), new string[6] { "Character", "Settlement", "Item", "", "", "" }, null, EMonthlyNotificationSectionType.TaiwuVillage, 0, 198, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_385"), 0, 0, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(386, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_386"), "sp_monthnotify_11_15", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_386"), new string[6] { "Character", "OrgGrade", "Location", "", "", "" }, null, EMonthlyNotificationSectionType.TaiwuVillage, 0, 64, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_386"), 0, 70, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(387, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_387"), null, LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_387"), new string[6] { "", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, -1, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_387"), 0, 0, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(388, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_388"), null, LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_388"), new string[6] { "", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, -1, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_388"), 0, 0, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(389, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_389"), "sp_monthnotify_17_21", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_389"), new string[6] { "Character", "Location", "", "", "", "" }, new List<sbyte> { 0 }, EMonthlyNotificationSectionType.Biography, 0, 192, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_389"), 0, 90, canFirstPage: true, "ui9_tex_month_notify_bg_0_5", allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(390, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_390"), "sp_monthnotify_22_60", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_390"), new string[6] { "Character", "Settlement", "", "", "", "" }, new List<sbyte> { 0 }, EMonthlyNotificationSectionType.Biography, 0, 192, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_390"), 0, 90, canFirstPage: true, "ui9_tex_month_notify_bg_0_5", allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(391, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_391"), "sp_monthnotify_22_59", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_391"), new string[6] { "", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 199, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_391"), 0, 90, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(392, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_392"), "sp_monthnotify_11_17", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_392"), new string[6] { "Building", "Item", "", "", "", "" }, null, EMonthlyNotificationSectionType.TaiwuVillage, 0, 143, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_392"), 0, 50, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(393, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_393"), "sp_monthnotify_22_63", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_393"), new string[6] { "Character", "Integer", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 200, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_393"), 0, 70, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(394, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_394"), "sp_monthnotify_22_64", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_394"), new string[6] { "Character", "Location", "", "", "", "" }, new List<sbyte> { 0 }, EMonthlyNotificationSectionType.Biography, 0, 200, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_394"), 0, 70, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(395, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_395"), "sp_monthnotify_22_61", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_395"), new string[6] { "Character", "Integer", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 200, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_395"), 0, 90, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(396, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_396"), "sp_monthnotify_22_62", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_396"), new string[6] { "Character", "Location", "", "", "", "" }, new List<sbyte> { 0 }, EMonthlyNotificationSectionType.Biography, 0, 200, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_396"), 0, 90, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(397, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_397"), "sp_monthnotify_22_65", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_397"), new string[6] { "Integer", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 201, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_397"), 0, 60, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(398, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_398"), "sp_monthnotify_22_66", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_398"), new string[6] { "Character", "Location", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 201, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_398"), 0, 75, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(399, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_399"), "sp_monthnotify_22_67", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_399"), new string[6] { "Location", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 201, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_399"), 0, 60, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(400, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_400"), "sp_monthnotify_11_14", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_400"), new string[6] { "Building", "Item", "Character", "", "", "" }, new List<sbyte> { 0 }, EMonthlyNotificationSectionType.TaiwuVillage, 0, 198, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_400"), 0, 20, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(401, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_401"), "sp_monthnotify_11_14", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_401"), new string[6] { "Building", "Item", "", "", "", "" }, new List<sbyte> { 0 }, EMonthlyNotificationSectionType.TaiwuVillage, 0, 198, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_401"), 0, 20, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(402, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_402"), "sp_monthnotify_11_14", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_402"), new string[6] { "Building", "Item", "", "", "", "" }, new List<sbyte> { 0 }, EMonthlyNotificationSectionType.TaiwuVillage, 0, 198, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_402"), 0, 20, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(403, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_403"), "sp_monthnotify_11_14", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_403"), new string[6] { "Building", "Item", "", "", "", "" }, new List<sbyte> { 0 }, EMonthlyNotificationSectionType.TaiwuVillage, 0, 198, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_403"), 0, 20, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(404, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_404"), "sp_monthnotify_11_14", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_404"), new string[6] { "Character", "Settlement", "Item", "Character", "", "" }, null, EMonthlyNotificationSectionType.TaiwuVillage, 0, 198, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_404"), 0, 20, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(405, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_405"), "sp_monthnotify_11_14", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_405"), new string[6] { "Character", "Settlement", "Item", "", "", "" }, null, EMonthlyNotificationSectionType.TaiwuVillage, 0, 198, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_405"), 0, 20, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(406, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_406"), "sp_monthnotify_11_14", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_406"), new string[6] { "Character", "Settlement", "Item", "", "", "" }, null, EMonthlyNotificationSectionType.TaiwuVillage, 0, 198, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_406"), 0, 20, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(407, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_407"), "sp_monthnotify_11_14", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_407"), new string[6] { "Character", "Settlement", "Item", "", "", "" }, null, EMonthlyNotificationSectionType.TaiwuVillage, 0, 198, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_407"), 0, 20, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(408, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_408"), "sp_monthnotify_22_68", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_408"), new string[6] { "Settlement", "Character", "Settlement", "Character", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 202, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_408"), 0, 60, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(409, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_409"), "sp_monthnotify_22_68", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_409"), new string[6] { "Settlement", "Character", "Settlement", "Character", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 202, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_409"), 0, 60, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(410, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_410"), "sp_monthnotify_22_68", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_410"), new string[6] { "Settlement", "Character", "Settlement", "Character", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 202, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_410"), 0, 60, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(411, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_411"), "sp_monthnotify_7_4", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_411"), new string[6] { "Character", "", "", "", "", "" }, new List<sbyte> { 0 }, EMonthlyNotificationSectionType.TaiwuVillage, 0, 203, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_411"), 0, 58, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(412, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_412"), "sp_monthnotify_3_1", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_412"), new string[6] { "Character", "Location", "Character", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 2, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_412"), 0, 64, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(413, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_413"), "sp_monthnotify_3_1", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_413"), new string[6] { "Character", "Location", "Character", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 2, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_413"), 0, 64, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(414, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_414"), "sp_monthnotify_18_9", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_414"), new string[6] { "Character", "Location", "Integer", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 200, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_414"), 0, 80, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(415, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_415"), "sp_monthnotify_18_8", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_415"), new string[6] { "Character", "Location", "Integer", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 200, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_415"), 0, 80, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(416, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_416"), "sp_monthnotify_22_71", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_416"), new string[6] { "CharacterTemplate", "", "", "", "", "" }, new List<sbyte> { 0 }, EMonthlyNotificationSectionType.Biography, 0, 204, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_416"), 0, 82, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(417, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_417"), "sp_monthnotify_22_72", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_417"), new string[6] { "CharacterTemplate", "", "", "", "", "" }, new List<sbyte> { 0 }, EMonthlyNotificationSectionType.Biography, 0, 204, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_417"), 0, 82, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(418, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_418"), "sp_monthnotify_22_69", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_418"), new string[6] { "Character", "Location", "Character", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 205, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_418"), 0, 56, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(419, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_419"), "sp_monthnotify_22_70", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_419"), new string[6] { "Character", "Location", "Character", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 206, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_419"), 0, 56, canFirstPage: false, null, allowByEventFunction: false));
	}

	private void CreateItems7()
	{
		_dataArray.Add(new MonthlyNotificationItem(420, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_420"), "sp_monthnotify_7_2", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_420"), new string[6] { "Character", "Integer", "Location", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 27, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_420"), 0, 62, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(421, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_421"), "sp_monthnotify_22_73", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_421"), new string[6] { "Location", "Character", "", "", "", "" }, null, EMonthlyNotificationSectionType.None, 0, -1, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_421"), 0, 0, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(422, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_422"), "sp_monthnotify_22_74", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_422"), new string[6] { "Character", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.None, 0, -1, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_422"), 0, 0, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(423, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_423"), "sp_monthnotify_18_10", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_423"), new string[6] { "Character", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.None, 0, -1, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_423"), 0, 0, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(424, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_424"), "sp_monthnotify_18_11", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_424"), new string[6] { "Character", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.None, 0, -1, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_424"), 0, 0, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(425, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_425"), "sp_monthnotify_22_73", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_425"), new string[6] { "Character", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 76, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_425"), 0, 52, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(426, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_426"), "sp_monthnotify_22_74", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_426"), new string[6] { "Character", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 76, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_426"), 0, 52, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(427, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_427"), "sp_monthnotify_18_10", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_427"), new string[6] { "Location", "Character", "Character", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 76, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_427"), 0, 52, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(428, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_428"), "sp_monthnotify_18_11", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_428"), new string[6] { "Character", "Character", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 76, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_428"), 0, 52, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(429, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_429"), "sp_monthnotify_22_74", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_429"), new string[6] { "Character", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 76, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_429"), 0, 52, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(430, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_430"), "sp_monthnotify_22_74", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_430"), new string[6] { "Character", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 76, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_430"), 0, 52, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(431, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_431"), "sp_monthnotify_22_74", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_431"), new string[6] { "Character", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 76, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_431"), 0, 52, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(432, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_432"), "sp_monthnotify_15_23", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_432"), new string[6] { "Integer", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, -1, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_432"), 0, 48, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(433, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_433"), "sp_monthnotify_15_22", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_433"), new string[6] { "Integer", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, -1, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_433"), 0, 48, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(434, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_434"), "sp_monthnotify_15_21", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_434"), new string[6] { "", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, -1, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_434"), 0, 48, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(435, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_435"), "sp_monthnotify_11_18", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_435"), new string[6] { "", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.TaiwuVillage, 0, 143, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_435"), 0, 60, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(436, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_436"), "sp_monthnotify_11_20", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_436"), new string[6] { "Character", "", "", "", "", "" }, new List<sbyte> { 0 }, EMonthlyNotificationSectionType.TaiwuVillage, 0, 207, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_436"), 0, 55, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(437, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_437"), "sp_monthnotify_11_19", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_437"), new string[6] { "Character", "", "", "", "", "" }, new List<sbyte> { 0 }, EMonthlyNotificationSectionType.TaiwuVillage, 0, 208, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_437"), 0, 55, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(438, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_438"), "sp_monthnotify_3_2", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_438"), new string[6] { "Character", "Character", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 2, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_438"), 0, 0, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(439, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_439"), "sp_monthnotify_4_3", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_439"), new string[6] { "Cricket", "", "", "", "", "" }, new List<sbyte> { 0 }, EMonthlyNotificationSectionType.TaiwuVillage, 0, -1, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_439"), 0, 80, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(440, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_440"), "sp_monthnotify_15_8", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_440"), new string[6] { "Character", "Location", "CharacterTemplate", "", "", "" }, null, EMonthlyNotificationSectionType.TaiwuVillage, 2, 39, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_440"), 0, 35, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(441, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_441"), "sp_monthnotify_15_9", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_441"), new string[6] { "Character", "Location", "CharacterTemplate", "", "", "" }, null, EMonthlyNotificationSectionType.TaiwuVillage, 2, 39, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_441"), 0, 35, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(442, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_442"), "sp_monthnotify_15_6", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_442"), new string[6] { "Character", "Location", "CharacterTemplate", "", "", "" }, null, EMonthlyNotificationSectionType.TaiwuVillage, 2, 38, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_442"), 0, 35, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(443, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_443"), "sp_monthnotify_15_7", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_443"), new string[6] { "Character", "Location", "CharacterTemplate", "", "", "" }, null, EMonthlyNotificationSectionType.TaiwuVillage, 2, 38, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_443"), 0, 35, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(444, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_444"), "sp_monthnotify_15_10", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_444"), new string[6] { "Character", "Location", "CharacterTemplate", "", "", "" }, null, EMonthlyNotificationSectionType.TaiwuVillage, 2, 40, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_444"), 0, 30, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(445, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_445"), "sp_monthnotify_15_11", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_445"), new string[6] { "Character", "Location", "CharacterTemplate", "", "", "" }, null, EMonthlyNotificationSectionType.TaiwuVillage, 2, 40, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_445"), 0, 30, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(446, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_446"), "sp_monthnotify_15_12", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_446"), new string[6] { "Character", "Location", "Adventure", "", "", "" }, null, EMonthlyNotificationSectionType.TaiwuVillage, 2, 134, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_446"), 0, 80, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(447, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_447"), "sp_monthnotify_12_12", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_447"), new string[6] { "Character", "Location", "Adventure", "", "", "" }, null, EMonthlyNotificationSectionType.TaiwuVillage, 2, 133, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_447"), 0, 80, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(448, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_448"), "sp_monthnotify_12_13", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_448"), new string[6] { "Character", "Location", "Adventure", "Character", "", "" }, null, EMonthlyNotificationSectionType.TaiwuVillage, 2, 133, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_448"), 0, 80, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(449, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_449"), "sp_monthnotify_3_1", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_449"), new string[6] { "Character", "Character", "Location", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 2, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_449"), 0, 60, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(450, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_450"), "sp_monthnotify_3_1", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_450"), new string[6] { "Character", "Character", "Location", "Item", "", "" }, null, EMonthlyNotificationSectionType.Biography, 2, 2, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_450"), 0, 60, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(451, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_451"), "sp_monthnotify_22_75", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_451"), new string[6] { "", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 78, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_451"), 0, 90, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(452, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_452"), "sp_monthnotify_22_76", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_452"), new string[6] { "", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 78, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_452"), 0, 90, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(453, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_453"), "sp_monthnotify_22_77", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_453"), new string[6] { "", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 78, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_453"), 0, 90, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(454, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_454"), "sp_monthnotify_22_78", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_454"), new string[6] { "", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 78, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_454"), 0, 90, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(455, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_455"), "sp_monthnotify_22_79", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_455"), new string[6] { "", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 78, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_455"), 0, 90, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(456, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_456"), "sp_monthnotify_22_80", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_456"), new string[6] { "Character", "Integer", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 209, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_456"), 0, 50, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(457, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_457"), "sp_monthnotify_5_15", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_457"), new string[6] { "Character", "Character", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 211, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_457"), 0, 80, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(458, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_458"), "sp_monthnotify_5_16", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_458"), new string[6] { "Character", "Character", "", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 211, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_458"), 0, 80, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(459, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_459"), "sp_monthnotify_13_0", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_459"), new string[6] { "Location", "Adventure", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, -1, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_459"), 0, 80, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(460, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_460"), "sp_monthnotify_13_0", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_460"), new string[6] { "Location", "Adventure", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, -1, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_460"), 0, 80, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(461, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_461"), "sp_monthnotify_13_0", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_461"), new string[6] { "Location", "Adventure", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, -1, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_461"), 0, 80, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(462, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_462"), "sp_monthnotify_13_0", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_462"), new string[6] { "Location", "Adventure", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, -1, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_462"), 0, 80, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(463, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_463"), "sp_monthnotify_13_0", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_463"), new string[6] { "Location", "Adventure", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, -1, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_463"), 0, 80, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(464, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_464"), "sp_monthnotify_12_0", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_464"), new string[6] { "Location", "Adventure", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, -1, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_464"), 0, 80, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(465, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_465"), "sp_monthnotify_12_0", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_465"), new string[6] { "Location", "Adventure", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, -1, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_465"), 0, 80, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(466, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_466"), "sp_monthnotify_12_0", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_466"), new string[6] { "Location", "Adventure", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, -1, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_466"), 0, 80, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(467, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_467"), null, LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_467"), new string[6] { "Location", "Adventure", "Integer", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, -1, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_467"), 0, 0, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(468, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_468"), "sp_monthnotify_8_17", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_468"), new string[6] { "Character", "Character", "Location", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 210, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_468"), 0, 0, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(469, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_469"), "sp_monthnotify_8_18", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_469"), new string[6] { "Character", "Character", "Location", "", "", "" }, null, EMonthlyNotificationSectionType.Biography, 0, 210, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_469"), 0, 0, canFirstPage: false, null, allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(470, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_470"), "sp_monthnotify_13_0", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_470"), new string[6] { "Location", "Adventure", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 152, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_470"), 0, 65, canFirstPage: true, "ui9_tex_month_notify_bg_0_3_2", allowByEventFunction: false));
		_dataArray.Add(new MonthlyNotificationItem(471, LocalStringManager.GetConfig("MonthlyNotification_language", "Name_471"), "sp_monthnotify_17_14", LocalStringManager.GetConfig("MonthlyNotification_language", "Desc_471"), new string[6] { "Location", "", "", "", "", "" }, null, EMonthlyNotificationSectionType.Worldwide, 0, 36, null, -1, LocalStringManager.GetConfig("MonthlyNotification_language", "MergeDesc_471"), 0, 65, canFirstPage: false, null, allowByEventFunction: false));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<MonthlyNotificationItem>(472);
		CreateItems0();
		CreateItems1();
		CreateItems2();
		CreateItems3();
		CreateItems4();
		CreateItems5();
		CreateItems6();
		CreateItems7();
	}
}
