using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class LifeRecord : ConfigData<LifeRecordItem, short>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// Die
		/// </summary>
		public const short Die = 0;

		/// <summary>
		/// XiangshuPartiallyInfected
		/// </summary>
		public const short XiangshuPartiallyInfected = 1;

		/// <summary>
		/// XiangshuCompletelyInfected
		/// </summary>
		public const short XiangshuCompletelyInfected = 2;

		/// <summary>
		/// MotherLoseFetus
		/// </summary>
		public const short MotherLoseFetus = 3;

		/// <summary>
		/// FatherLoseFetus
		/// </summary>
		public const short FatherLoseFetus = 4;

		/// <summary>
		/// AbandonChild
		/// </summary>
		public const short AbandonChild = 5;

		/// <summary>
		/// ChildGetAbandoned
		/// </summary>
		public const short ChildGetAbandoned = 6;

		/// <summary>
		/// GiveBirthToCricket
		/// </summary>
		public const short GiveBirthToCricket = 7;

		/// <summary>
		/// GiveBirthToBoy
		/// </summary>
		public const short GiveBirthToBoy = 8;

		/// <summary>
		/// GiveBirthToGirl
		/// </summary>
		public const short GiveBirthToGirl = 9;

		/// <summary>
		/// BecomeFatherToNewBornBoy
		/// </summary>
		public const short BecomeFatherToNewBornBoy = 10;

		/// <summary>
		/// BecomeFatherToNewBornGirl
		/// </summary>
		public const short BecomeFatherToNewBornGirl = 11;

		/// <summary>
		/// BuildGrave
		/// </summary>
		public const short BuildGrave = 12;

		/// <summary>
		/// MonkBreakRule
		/// </summary>
		public const short MonkBreakRule = 13;

		/// <summary>
		/// KidnappedCharacterEscaped
		/// </summary>
		public const short KidnappedCharacterEscaped = 14;

		/// <summary>
		/// EscapeFromKidnapping
		/// </summary>
		public const short EscapeFromKidnapping = 15;

		/// <summary>
		/// ReadBookSucceed
		/// </summary>
		public const short ReadBookSucceed = 16;

		/// <summary>
		/// ReadBookFail
		/// </summary>
		public const short ReadBookFail = 17;

		/// <summary>
		/// BreakoutSucceed
		/// </summary>
		public const short BreakoutSucceed = 18;

		/// <summary>
		/// BreakoutFail
		/// </summary>
		public const short BreakoutFail = 19;

		/// <summary>
		/// LearnCombatSkill
		/// </summary>
		public const short LearnCombatSkill = 20;

		/// <summary>
		/// LearnLifeSkill
		/// </summary>
		public const short LearnLifeSkill = 21;

		/// <summary>
		/// RepairItem
		/// </summary>
		public const short RepairItem = 22;

		/// <summary>
		/// AddPoisonToItem
		/// </summary>
		public const short AddPoisonToItem = 23;

		/// <summary>
		/// LoseOverloadingResource
		/// </summary>
		public const short LoseOverloadingResource = 24;

		/// <summary>
		/// LoseOverloadingItem
		/// </summary>
		public const short LoseOverloadingItem = 25;

		/// <summary>
		/// MakeEnemy
		/// </summary>
		public const short MakeEnemy = 26;

		/// <summary>
		/// SeverEnemy
		/// </summary>
		public const short SeverEnemy = 27;

		/// <summary>
		/// BeMadeEnemy
		/// </summary>
		public const short BeMadeEnemy = 28;

		/// <summary>
		/// SeveredEnemy
		/// </summary>
		public const short SeveredEnemy = 29;

		/// <summary>
		/// Adore
		/// </summary>
		public const short Adore = 30;

		/// <summary>
		/// LoveAtFirstSight
		/// </summary>
		public const short LoveAtFirstSight = 31;

		/// <summary>
		/// ConfessLoveSucceed
		/// </summary>
		public const short ConfessLoveSucceed = 32;

		/// <summary>
		/// ConfessLoveFail
		/// </summary>
		public const short ConfessLoveFail = 33;

		/// <summary>
		/// AcceptConfessLove
		/// </summary>
		public const short AcceptConfessLove = 34;

		/// <summary>
		/// RefuseConfessLove
		/// </summary>
		public const short RefuseConfessLove = 35;

		/// <summary>
		/// BreakupMutually
		/// </summary>
		public const short BreakupMutually = 36;

		/// <summary>
		/// DumpLover
		/// </summary>
		public const short DumpLover = 37;

		/// <summary>
		/// GetDumppedByLover
		/// </summary>
		public const short GetDumppedByLover = 38;

		/// <summary>
		/// ProposeMarriageSucceed
		/// </summary>
		public const short ProposeMarriageSucceed = 39;

		/// <summary>
		/// ProposeMarriageFail
		/// </summary>
		public const short ProposeMarriageFail = 40;

		/// <summary>
		/// RefuseMarriageProposal
		/// </summary>
		public const short RefuseMarriageProposal = 41;

		/// <summary>
		/// BecomeFriend
		/// </summary>
		public const short BecomeFriend = 42;

		/// <summary>
		/// SeverFriendship
		/// </summary>
		public const short SeverFriendship = 43;

		/// <summary>
		/// BecomeSwornBrotherOrSister
		/// </summary>
		public const short BecomeSwornBrotherOrSister = 44;

		/// <summary>
		/// SeverSwornBrotherhood
		/// </summary>
		public const short SeverSwornBrotherhood = 45;

		/// <summary>
		/// GetAdoptedByFather
		/// </summary>
		public const short GetAdoptedByFather = 46;

		/// <summary>
		/// GetAdoptedByMother
		/// </summary>
		public const short GetAdoptedByMother = 47;

		/// <summary>
		/// AdoptSon
		/// </summary>
		public const short AdoptSon = 48;

		/// <summary>
		/// AdoptDaughter
		/// </summary>
		public const short AdoptDaughter = 49;

		/// <summary>
		/// CreateFaction
		/// </summary>
		public const short CreateFaction = 50;

		/// <summary>
		/// JoinFaction
		/// </summary>
		public const short JoinFaction = 51;

		/// <summary>
		/// LeaveFaction
		/// </summary>
		public const short LeaveFaction = 52;

		/// <summary>
		/// FactionRecruitSucceed
		/// </summary>
		public const short FactionRecruitSucceed = 53;

		/// <summary>
		/// FactionRecruitFail
		/// </summary>
		public const short FactionRecruitFail = 54;

		/// <summary>
		/// AgreeToJoinFaction
		/// </summary>
		public const short AgreeToJoinFaction = 55;

		/// <summary>
		/// RefuseToJoinFaction
		/// </summary>
		public const short RefuseToJoinFaction = 56;

		/// <summary>
		/// DecideToJoinSect
		/// </summary>
		public const short DecideToJoinSect = 57;

		/// <summary>
		/// DecideToFullfillAppointment
		/// </summary>
		public const short DecideToFullfillAppointment = 58;

		/// <summary>
		/// DecideToProtect
		/// </summary>
		public const short DecideToProtect = 59;

		/// <summary>
		/// DecideToRescue
		/// </summary>
		public const short DecideToRescue = 60;

		/// <summary>
		/// DecideToMourn
		/// </summary>
		public const short DecideToMourn = 61;

		/// <summary>
		/// DecideToVisit
		/// </summary>
		public const short DecideToVisit = 62;

		/// <summary>
		/// DecideToFindLostItem
		/// </summary>
		public const short DecideToFindLostItem = 63;

		/// <summary>
		/// DecideToFindSpecialMaterial
		/// </summary>
		public const short DecideToFindSpecialMaterial = 64;

		/// <summary>
		/// DecideToRevenge
		/// </summary>
		public const short DecideToRevenge = 65;

		/// <summary>
		/// DecideToParticipateAdventure
		/// </summary>
		public const short DecideToParticipateAdventure = 66;

		/// <summary>
		/// JoinSectFail
		/// </summary>
		public const short JoinSectFail = 67;

		/// <summary>
		/// JoinSectSucceed
		/// </summary>
		public const short JoinSectSucceed = 68;

		/// <summary>
		/// CanNoLongerFullFillAppointment
		/// </summary>
		public const short CanNoLongerFullFillAppointment = 69;

		/// <summary>
		/// WaitForAppointment
		/// </summary>
		public const short WaitForAppointment = 70;

		/// <summary>
		/// FullFillAppointment
		/// </summary>
		public const short FullFillAppointment = 71;

		/// <summary>
		/// FinishProtection
		/// </summary>
		public const short FinishProtection = 72;

		/// <summary>
		/// OfferProtection
		/// </summary>
		public const short OfferProtection = 73;

		/// <summary>
		/// FinishRescue
		/// </summary>
		public const short FinishRescue = 74;

		/// <summary>
		/// FinishMourning
		/// </summary>
		public const short FinishMourning = 75;

		/// <summary>
		/// MaintainGrave
		/// </summary>
		public const short MaintainGrave = 76;

		/// <summary>
		/// UpgradeGrave
		/// </summary>
		public const short UpgradeGrave = 77;

		/// <summary>
		/// FinishVisit
		/// </summary>
		public const short FinishVisit = 78;

		/// <summary>
		/// FinishFIndingLostItem
		/// </summary>
		public const short FinishFIndingLostItem = 79;

		/// <summary>
		/// FinishFIndingSpecialMaterial
		/// </summary>
		public const short FinishFIndingSpecialMaterial = 80;

		/// <summary>
		/// FindLostItemSucceed
		/// </summary>
		public const short FindLostItemSucceed = 81;

		/// <summary>
		/// FindLostItemFail
		/// </summary>
		public const short FindLostItemFail = 82;

		/// <summary>
		/// FindSpecialMaterialSucceed
		/// </summary>
		public const short FindSpecialMaterialSucceed = 83;

		/// <summary>
		/// FinishTakingRevenge
		/// </summary>
		public const short FinishTakingRevenge = 84;

		/// <summary>
		/// MajorVictoryInCombat
		/// </summary>
		public const short MajorVictoryInCombat = 85;

		/// <summary>
		/// MajorFailureInCombat
		/// </summary>
		public const short MajorFailureInCombat = 86;

		/// <summary>
		/// VictoryInCombat
		/// </summary>
		public const short VictoryInCombat = 87;

		/// <summary>
		/// FailureInCombat
		/// </summary>
		public const short FailureInCombat = 88;

		/// <summary>
		/// EnemyEscape
		/// </summary>
		public const short EnemyEscape = 89;

		/// <summary>
		/// LoseAndEscape
		/// </summary>
		public const short LoseAndEscape = 90;

		/// <summary>
		/// KillInPublic
		/// </summary>
		public const short KillInPublic = 91;

		/// <summary>
		/// KillInPrivate
		/// </summary>
		public const short KillInPrivate = 92;

		/// <summary>
		/// KidnapInPublic
		/// </summary>
		public const short KidnapInPublic = 93;

		/// <summary>
		/// KidnapInPrivate
		/// </summary>
		public const short KidnapInPrivate = 94;

		/// <summary>
		/// ReleaseLoser
		/// </summary>
		public const short ReleaseLoser = 95;

		/// <summary>
		/// GetKidnappedInPublic
		/// </summary>
		public const short GetKidnappedInPublic = 96;

		/// <summary>
		/// GetKidnappedInPrivate
		/// </summary>
		public const short GetKidnappedInPrivate = 97;

		/// <summary>
		/// GetReleasedByWinner
		/// </summary>
		public const short GetReleasedByWinner = 98;

		/// <summary>
		/// AgreeToProtect
		/// </summary>
		public const short AgreeToProtect = 99;

		/// <summary>
		/// RefuseToProtect
		/// </summary>
		public const short RefuseToProtect = 100;

		/// <summary>
		/// FinishAdventure
		/// </summary>
		public const short FinishAdventure = 101;

		/// <summary>
		/// RequestHealOuterInjurySucceed
		/// </summary>
		public const short RequestHealOuterInjurySucceed = 102;

		/// <summary>
		/// RequestHealInnerInjurySucceed
		/// </summary>
		public const short RequestHealInnerInjurySucceed = 103;

		/// <summary>
		/// RequestDetoxPoisonSucceed
		/// </summary>
		public const short RequestDetoxPoisonSucceed = 104;

		/// <summary>
		/// RequestHealthSucceed
		/// </summary>
		public const short RequestHealthSucceed = 105;

		/// <summary>
		/// RequestHealDisorderOfQiSucceed
		/// </summary>
		public const short RequestHealDisorderOfQiSucceed = 106;

		/// <summary>
		/// RequestNeiliSucceed
		/// </summary>
		public const short RequestNeiliSucceed = 107;

		/// <summary>
		/// RequestKillWugSucceed
		/// </summary>
		public const short RequestKillWugSucceed = 108;

		/// <summary>
		/// RequestFoodSucceed
		/// </summary>
		public const short RequestFoodSucceed = 109;

		/// <summary>
		/// RequestTeaWineSucceed
		/// </summary>
		public const short RequestTeaWineSucceed = 110;

		/// <summary>
		/// RequestResourceSucceed
		/// </summary>
		public const short RequestResourceSucceed = 111;

		/// <summary>
		/// RequestItemSucceed
		/// </summary>
		public const short RequestItemSucceed = 112;

		/// <summary>
		/// RequestRepairItemSucceed
		/// </summary>
		public const short RequestRepairItemSucceed = 113;

		/// <summary>
		/// RequestAddPoisonToItemSucceed
		/// </summary>
		public const short RequestAddPoisonToItemSucceed = 114;

		/// <summary>
		/// RequestInstructionOnLifeSkillSucceed
		/// </summary>
		public const short RequestInstructionOnLifeSkillSucceed = 115;

		/// <summary>
		/// RequestInstructionOnCombatSkillSucceed
		/// </summary>
		public const short RequestInstructionOnCombatSkillSucceed = 116;

		/// <summary>
		/// RequestInstructionOnLifeSkillFailToLearn
		/// </summary>
		public const short RequestInstructionOnLifeSkillFailToLearn = 117;

		/// <summary>
		/// RequestInstructionOnCombatSkillFailToLearn
		/// </summary>
		public const short RequestInstructionOnCombatSkillFailToLearn = 118;

		/// <summary>
		/// RequestInstructionOnReadingSucceed
		/// </summary>
		public const short RequestInstructionOnReadingSucceed = 119;

		/// <summary>
		/// RequestInstructionOnBreakoutSucceed
		/// </summary>
		public const short RequestInstructionOnBreakoutSucceed = 120;

		/// <summary>
		/// RequestHealOuterInjuryFail
		/// </summary>
		public const short RequestHealOuterInjuryFail = 121;

		/// <summary>
		/// RequestHealInnerInjuryFail
		/// </summary>
		public const short RequestHealInnerInjuryFail = 122;

		/// <summary>
		/// RequestDetoxPoisonFail
		/// </summary>
		public const short RequestDetoxPoisonFail = 123;

		/// <summary>
		/// RequestHealthFail
		/// </summary>
		public const short RequestHealthFail = 124;

		/// <summary>
		/// RequestHealDisorderOfQiFail
		/// </summary>
		public const short RequestHealDisorderOfQiFail = 125;

		/// <summary>
		/// RequestNeiliFail
		/// </summary>
		public const short RequestNeiliFail = 126;

		/// <summary>
		/// RequestKillWugFail
		/// </summary>
		public const short RequestKillWugFail = 127;

		/// <summary>
		/// RequestFoodFail
		/// </summary>
		public const short RequestFoodFail = 128;

		/// <summary>
		/// RequestTeaWineFail
		/// </summary>
		public const short RequestTeaWineFail = 129;

		/// <summary>
		/// RequestResourceFail
		/// </summary>
		public const short RequestResourceFail = 130;

		/// <summary>
		/// RequestItemFail
		/// </summary>
		public const short RequestItemFail = 131;

		/// <summary>
		/// RequestRepairItemFail
		/// </summary>
		public const short RequestRepairItemFail = 132;

		/// <summary>
		/// RequestAddPoisonToItemFail
		/// </summary>
		public const short RequestAddPoisonToItemFail = 133;

		/// <summary>
		/// RequestInstructionOnLifeSkillFail
		/// </summary>
		public const short RequestInstructionOnLifeSkillFail = 134;

		/// <summary>
		/// RequestInstructionOnCombatSkillFail
		/// </summary>
		public const short RequestInstructionOnCombatSkillFail = 135;

		/// <summary>
		/// RequestInstructionOnReadingFail
		/// </summary>
		public const short RequestInstructionOnReadingFail = 136;

		/// <summary>
		/// RequestInstructionOnBreakoutFail
		/// </summary>
		public const short RequestInstructionOnBreakoutFail = 137;

		/// <summary>
		/// AcceptRequestHealOuterInjury
		/// </summary>
		public const short AcceptRequestHealOuterInjury = 138;

		/// <summary>
		/// AcceptRequestHealInnerInjury
		/// </summary>
		public const short AcceptRequestHealInnerInjury = 139;

		/// <summary>
		/// AcceptRequestDetoxPoison
		/// </summary>
		public const short AcceptRequestDetoxPoison = 140;

		/// <summary>
		/// AcceptRequestHealth
		/// </summary>
		public const short AcceptRequestHealth = 141;

		/// <summary>
		/// AcceptRequestHealDisorderOfQi
		/// </summary>
		public const short AcceptRequestHealDisorderOfQi = 142;

		/// <summary>
		/// AcceptRequestNeili
		/// </summary>
		public const short AcceptRequestNeili = 143;

		/// <summary>
		/// AcceptRequestKillWug
		/// </summary>
		public const short AcceptRequestKillWug = 144;

		/// <summary>
		/// AcceptRequestFood
		/// </summary>
		public const short AcceptRequestFood = 145;

		/// <summary>
		/// AcceptRequestTeaWine
		/// </summary>
		public const short AcceptRequestTeaWine = 146;

		/// <summary>
		/// AcceptRequestResource
		/// </summary>
		public const short AcceptRequestResource = 147;

		/// <summary>
		/// AcceptRequestItem
		/// </summary>
		public const short AcceptRequestItem = 148;

		/// <summary>
		/// AcceptRequestRepairItem
		/// </summary>
		public const short AcceptRequestRepairItem = 149;

		/// <summary>
		/// AcceptRequestAddPoisonToItem
		/// </summary>
		public const short AcceptRequestAddPoisonToItem = 150;

		/// <summary>
		/// AcceptRequestInstructionOnLifeSkill
		/// </summary>
		public const short AcceptRequestInstructionOnLifeSkill = 151;

		/// <summary>
		/// AcceptRequestInstructionOnCombatSkill
		/// </summary>
		public const short AcceptRequestInstructionOnCombatSkill = 152;

		/// <summary>
		/// AcceptRequestInstructionOnLifeSkillButFail
		/// </summary>
		public const short AcceptRequestInstructionOnLifeSkillButFail = 153;

		/// <summary>
		/// AcceptRequestInstructionOnCombatSkillButFail
		/// </summary>
		public const short AcceptRequestInstructionOnCombatSkillButFail = 154;

		/// <summary>
		/// AcceptRequestInstructionOnReading
		/// </summary>
		public const short AcceptRequestInstructionOnReading = 155;

		/// <summary>
		/// AcceptRequestInstructionOnBreakout
		/// </summary>
		public const short AcceptRequestInstructionOnBreakout = 156;

		/// <summary>
		/// RefuseRequestHealOuterInjury
		/// </summary>
		public const short RefuseRequestHealOuterInjury = 157;

		/// <summary>
		/// RefuseRequestHealInnerInjury
		/// </summary>
		public const short RefuseRequestHealInnerInjury = 158;

		/// <summary>
		/// RefuseRequestDetoxPoison
		/// </summary>
		public const short RefuseRequestDetoxPoison = 159;

		/// <summary>
		/// RefuseRequestHealth
		/// </summary>
		public const short RefuseRequestHealth = 160;

		/// <summary>
		/// RefuseRequestHealDisorderOfQi
		/// </summary>
		public const short RefuseRequestHealDisorderOfQi = 161;

		/// <summary>
		/// RefuseRequestNeili
		/// </summary>
		public const short RefuseRequestNeili = 162;

		/// <summary>
		/// RefuseRequestKillWug
		/// </summary>
		public const short RefuseRequestKillWug = 163;

		/// <summary>
		/// RefuseRequestFood
		/// </summary>
		public const short RefuseRequestFood = 164;

		/// <summary>
		/// RefuseRequestTeaWine
		/// </summary>
		public const short RefuseRequestTeaWine = 165;

		/// <summary>
		/// RefuseRequestResource
		/// </summary>
		public const short RefuseRequestResource = 166;

		/// <summary>
		/// RefuseRequestItem
		/// </summary>
		public const short RefuseRequestItem = 167;

		/// <summary>
		/// RefuseRequestRepairItem
		/// </summary>
		public const short RefuseRequestRepairItem = 168;

		/// <summary>
		/// RefuseRequestAddPoisonToItem
		/// </summary>
		public const short RefuseRequestAddPoisonToItem = 169;

		/// <summary>
		/// RefuseRequestInstructionOnLifeSkill
		/// </summary>
		public const short RefuseRequestInstructionOnLifeSkill = 170;

		/// <summary>
		/// RefuseRequestInstructionOnCombatSkill
		/// </summary>
		public const short RefuseRequestInstructionOnCombatSkill = 171;

		/// <summary>
		/// RefuseRequestInstructionOnReading
		/// </summary>
		public const short RefuseRequestInstructionOnReading = 172;

		/// <summary>
		/// RefuseRequestInstructionOnBreakout
		/// </summary>
		public const short RefuseRequestInstructionOnBreakout = 173;

		/// <summary>
		/// RescueKidnappedCharacterSecretlyFail1
		/// </summary>
		public const short RescueKidnappedCharacterSecretlyFail1 = 174;

		/// <summary>
		/// RescueKidnappedCharacterSecretlyFail2
		/// </summary>
		public const short RescueKidnappedCharacterSecretlyFail2 = 175;

		/// <summary>
		/// RescueKidnappedCharacterSecretlyFail3
		/// </summary>
		public const short RescueKidnappedCharacterSecretlyFail3 = 176;

		/// <summary>
		/// RescueKidnappedCharacterSecretlyFail4
		/// </summary>
		public const short RescueKidnappedCharacterSecretlyFail4 = 177;

		/// <summary>
		/// RescueKidnappedCharacterSecretlySucceed
		/// </summary>
		public const short RescueKidnappedCharacterSecretlySucceed = 178;

		/// <summary>
		/// RescueKidnappedCharacterSecretlySucceedAndEscaped
		/// </summary>
		public const short RescueKidnappedCharacterSecretlySucceedAndEscaped = 179;

		/// <summary>
		/// KidnappedCharacterGetRescuedSecretly
		/// </summary>
		public const short KidnappedCharacterGetRescuedSecretly = 180;

		/// <summary>
		/// RescueKidnappedCharacterWithWitFail1
		/// </summary>
		public const short RescueKidnappedCharacterWithWitFail1 = 181;

		/// <summary>
		/// RescueKidnappedCharacterWithWitFail2
		/// </summary>
		public const short RescueKidnappedCharacterWithWitFail2 = 182;

		/// <summary>
		/// RescueKidnappedCharacterWithWitFail3
		/// </summary>
		public const short RescueKidnappedCharacterWithWitFail3 = 183;

		/// <summary>
		/// RescueKidnappedCharacterWithWitFail4
		/// </summary>
		public const short RescueKidnappedCharacterWithWitFail4 = 184;

		/// <summary>
		/// RescueKidnappedCharacterWithWitSucceed
		/// </summary>
		public const short RescueKidnappedCharacterWithWitSucceed = 185;

		/// <summary>
		/// RescueKidnappedCharacterWithWitSucceedAndEscaped
		/// </summary>
		public const short RescueKidnappedCharacterWithWitSucceedAndEscaped = 186;

		/// <summary>
		/// KidnappedCharacterGetRescuedWithWit
		/// </summary>
		public const short KidnappedCharacterGetRescuedWithWit = 187;

		/// <summary>
		/// RescueKidnappedCharacterWithForceFail1
		/// </summary>
		public const short RescueKidnappedCharacterWithForceFail1 = 188;

		/// <summary>
		/// RescueKidnappedCharacterWithForceFail2
		/// </summary>
		public const short RescueKidnappedCharacterWithForceFail2 = 189;

		/// <summary>
		/// RescueKidnappedCharacterWithForceFail3
		/// </summary>
		public const short RescueKidnappedCharacterWithForceFail3 = 190;

		/// <summary>
		/// RescueKidnappedCharacterWithForceFail4
		/// </summary>
		public const short RescueKidnappedCharacterWithForceFail4 = 191;

		/// <summary>
		/// RescueKidnappedCharacterWithForceSucceed
		/// </summary>
		public const short RescueKidnappedCharacterWithForceSucceed = 192;

		/// <summary>
		/// RescueKidnappedCharacterWithForceSucceedAndEscaped
		/// </summary>
		public const short RescueKidnappedCharacterWithForceSucceedAndEscaped = 193;

		/// <summary>
		/// KidnappedCharacterGetRescuedWithForce
		/// </summary>
		public const short KidnappedCharacterGetRescuedWithForce = 194;

		/// <summary>
		/// PoisonEnemyFail1
		/// </summary>
		public const short PoisonEnemyFail1 = 195;

		/// <summary>
		/// PoisonEnemyFail2
		/// </summary>
		public const short PoisonEnemyFail2 = 196;

		/// <summary>
		/// PoisonEnemyFail3
		/// </summary>
		public const short PoisonEnemyFail3 = 197;

		/// <summary>
		/// PoisonEnemyFail4
		/// </summary>
		public const short PoisonEnemyFail4 = 198;

		/// <summary>
		/// PoisonEnemySucceed
		/// </summary>
		public const short PoisonEnemySucceed = 199;

		/// <summary>
		/// PoisonEnemySucceedAndEscaped
		/// </summary>
		public const short PoisonEnemySucceedAndEscaped = 200;

		/// <summary>
		/// GetPoisonedByEnemySucceed
		/// </summary>
		public const short GetPoisonedByEnemySucceed = 201;

		/// <summary>
		/// PlotHarmEnemyFail1
		/// </summary>
		public const short PlotHarmEnemyFail1 = 202;

		/// <summary>
		/// PlotHarmEnemyFail2
		/// </summary>
		public const short PlotHarmEnemyFail2 = 203;

		/// <summary>
		/// PlotHarmEnemyFail3
		/// </summary>
		public const short PlotHarmEnemyFail3 = 204;

		/// <summary>
		/// PlotHarmEnemyFail4
		/// </summary>
		public const short PlotHarmEnemyFail4 = 205;

		/// <summary>
		/// PlotHarmEnemySucceed
		/// </summary>
		public const short PlotHarmEnemySucceed = 206;

		/// <summary>
		/// PlotHarmEnemySucceedAndEscaped
		/// </summary>
		public const short PlotHarmEnemySucceedAndEscaped = 207;

		/// <summary>
		/// GetPlottedAgainstSucceed
		/// </summary>
		public const short GetPlottedAgainstSucceed = 208;

		/// <summary>
		/// StealResourceFail1
		/// </summary>
		public const short StealResourceFail1 = 209;

		/// <summary>
		/// StealResourceFail2
		/// </summary>
		public const short StealResourceFail2 = 210;

		/// <summary>
		/// StealResourceFail3
		/// </summary>
		public const short StealResourceFail3 = 211;

		/// <summary>
		/// StealResourceFail4
		/// </summary>
		public const short StealResourceFail4 = 212;

		/// <summary>
		/// StealResourceSucceed
		/// </summary>
		public const short StealResourceSucceed = 213;

		/// <summary>
		/// StealResourceSucceedAndEscaped
		/// </summary>
		public const short StealResourceSucceedAndEscaped = 214;

		/// <summary>
		/// StealResourceFailAndBeatenUp
		/// </summary>
		public const short StealResourceFailAndBeatenUp = 215;

		/// <summary>
		/// ResourceGetStolenSucceed
		/// </summary>
		public const short ResourceGetStolenSucceed = 216;

		/// <summary>
		/// BeatUpResourceStealer
		/// </summary>
		public const short BeatUpResourceStealer = 217;

		/// <summary>
		/// ScamResourceFail1
		/// </summary>
		public const short ScamResourceFail1 = 218;

		/// <summary>
		/// ScamResourceFail2
		/// </summary>
		public const short ScamResourceFail2 = 219;

		/// <summary>
		/// ScamResourceFail3
		/// </summary>
		public const short ScamResourceFail3 = 220;

		/// <summary>
		/// ScamResourceFail4
		/// </summary>
		public const short ScamResourceFail4 = 221;

		/// <summary>
		/// ScamResourceSucceed
		/// </summary>
		public const short ScamResourceSucceed = 222;

		/// <summary>
		/// ScamResourceSucceedAndEscaped
		/// </summary>
		public const short ScamResourceSucceedAndEscaped = 223;

		/// <summary>
		/// ScamResourceFailAndBeatenUp
		/// </summary>
		public const short ScamResourceFailAndBeatenUp = 224;

		/// <summary>
		/// ResourceGetScammedSucceed
		/// </summary>
		public const short ResourceGetScammedSucceed = 225;

		/// <summary>
		/// BeatUpResourceScammer
		/// </summary>
		public const short BeatUpResourceScammer = 226;

		/// <summary>
		/// RobResourceFail1
		/// </summary>
		public const short RobResourceFail1 = 227;

		/// <summary>
		/// RobResourceFail2
		/// </summary>
		public const short RobResourceFail2 = 228;

		/// <summary>
		/// RobResourceFail3
		/// </summary>
		public const short RobResourceFail3 = 229;

		/// <summary>
		/// RobResourceFail4
		/// </summary>
		public const short RobResourceFail4 = 230;

		/// <summary>
		/// RobResourceSucceed
		/// </summary>
		public const short RobResourceSucceed = 231;

		/// <summary>
		/// RobResourceSucceedAndEscaped
		/// </summary>
		public const short RobResourceSucceedAndEscaped = 232;

		/// <summary>
		/// RobResourceFailAndBeatenUp
		/// </summary>
		public const short RobResourceFailAndBeatenUp = 233;

		/// <summary>
		/// ResourceGetRobbedSucceed
		/// </summary>
		public const short ResourceGetRobbedSucceed = 234;

		/// <summary>
		/// BeatUpResourceRobber
		/// </summary>
		public const short BeatUpResourceRobber = 235;

		/// <summary>
		/// StealItemFail1
		/// </summary>
		public const short StealItemFail1 = 236;

		/// <summary>
		/// StealItemFail2
		/// </summary>
		public const short StealItemFail2 = 237;

		/// <summary>
		/// StealItemFail3
		/// </summary>
		public const short StealItemFail3 = 238;

		/// <summary>
		/// StealItemFail4
		/// </summary>
		public const short StealItemFail4 = 239;

		/// <summary>
		/// StealItemSucceed
		/// </summary>
		public const short StealItemSucceed = 240;

		/// <summary>
		/// StealItemSucceedAndEscaped
		/// </summary>
		public const short StealItemSucceedAndEscaped = 241;

		/// <summary>
		/// StealItemSucceedAndBeatenUp
		/// </summary>
		public const short StealItemSucceedAndBeatenUp = 242;

		/// <summary>
		/// ItemGetStolenSucceed
		/// </summary>
		public const short ItemGetStolenSucceed = 243;

		/// <summary>
		/// BeatUpItemStealer
		/// </summary>
		public const short BeatUpItemStealer = 244;

		/// <summary>
		/// ScamItemFail1
		/// </summary>
		public const short ScamItemFail1 = 245;

		/// <summary>
		/// ScamItemFail2
		/// </summary>
		public const short ScamItemFail2 = 246;

		/// <summary>
		/// ScamItemFail3
		/// </summary>
		public const short ScamItemFail3 = 247;

		/// <summary>
		/// ScamItemFail4
		/// </summary>
		public const short ScamItemFail4 = 248;

		/// <summary>
		/// ScamItemSucceed
		/// </summary>
		public const short ScamItemSucceed = 249;

		/// <summary>
		/// ScamItemSucceedAndEscaped
		/// </summary>
		public const short ScamItemSucceedAndEscaped = 250;

		/// <summary>
		/// ScamItemFailAndBeatenUp
		/// </summary>
		public const short ScamItemFailAndBeatenUp = 251;

		/// <summary>
		/// ItemGetScammedSucceed
		/// </summary>
		public const short ItemGetScammedSucceed = 252;

		/// <summary>
		/// BeatUpItemScammer
		/// </summary>
		public const short BeatUpItemScammer = 253;

		/// <summary>
		/// RobItemFail1
		/// </summary>
		public const short RobItemFail1 = 254;

		/// <summary>
		/// RobItemFail2
		/// </summary>
		public const short RobItemFail2 = 255;

		/// <summary>
		/// RobItemFail3
		/// </summary>
		public const short RobItemFail3 = 256;

		/// <summary>
		/// RobItemFail4
		/// </summary>
		public const short RobItemFail4 = 257;

		/// <summary>
		/// RobItemSucceed
		/// </summary>
		public const short RobItemSucceed = 258;

		/// <summary>
		/// RobItemSucceedAndEscaped
		/// </summary>
		public const short RobItemSucceedAndEscaped = 259;

		/// <summary>
		/// RobItemFailAndBeatenUp
		/// </summary>
		public const short RobItemFailAndBeatenUp = 260;

		/// <summary>
		/// ItemGetRobbedSucceed
		/// </summary>
		public const short ItemGetRobbedSucceed = 261;

		/// <summary>
		/// BeatUpItemRobber
		/// </summary>
		public const short BeatUpItemRobber = 262;

		/// <summary>
		/// RobResourceFromGraveSucceed
		/// </summary>
		public const short RobResourceFromGraveSucceed = 263;

		/// <summary>
		/// RobResourceFromGraveFail
		/// </summary>
		public const short RobResourceFromGraveFail = 264;

		/// <summary>
		/// RobItemFromGraveSucceed
		/// </summary>
		public const short RobItemFromGraveSucceed = 265;

		/// <summary>
		/// RobItemFromGraveFail
		/// </summary>
		public const short RobItemFromGraveFail = 266;

		/// <summary>
		/// StealLifeSkillFail1
		/// </summary>
		public const short StealLifeSkillFail1 = 267;

		/// <summary>
		/// StealLifeSkillFail2
		/// </summary>
		public const short StealLifeSkillFail2 = 268;

		/// <summary>
		/// StealLifeSkillFail3
		/// </summary>
		public const short StealLifeSkillFail3 = 269;

		/// <summary>
		/// StealLifeSkillFail4
		/// </summary>
		public const short StealLifeSkillFail4 = 270;

		/// <summary>
		/// StealLifeSkillSucceed
		/// </summary>
		public const short StealLifeSkillSucceed = 271;

		/// <summary>
		/// StealLifeSkillSucceedAndEscaped
		/// </summary>
		public const short StealLifeSkillSucceedAndEscaped = 272;

		/// <summary>
		/// LifeSkillGetStolenSucceed
		/// </summary>
		public const short LifeSkillGetStolenSucceed = 273;

		/// <summary>
		/// ScamLifeSkillFail1
		/// </summary>
		public const short ScamLifeSkillFail1 = 274;

		/// <summary>
		/// ScamLifeSkillFail2
		/// </summary>
		public const short ScamLifeSkillFail2 = 275;

		/// <summary>
		/// ScamLifeSkillFail3
		/// </summary>
		public const short ScamLifeSkillFail3 = 276;

		/// <summary>
		/// ScamLifeSkillFail4
		/// </summary>
		public const short ScamLifeSkillFail4 = 277;

		/// <summary>
		/// ScamLifeSkillSucceed
		/// </summary>
		public const short ScamLifeSkillSucceed = 278;

		/// <summary>
		/// ScamLifeSkillSucceedAndEscaped
		/// </summary>
		public const short ScamLifeSkillSucceedAndEscaped = 279;

		/// <summary>
		/// LifeSkillGetScammedSucceed
		/// </summary>
		public const short LifeSkillGetScammedSucceed = 280;

		/// <summary>
		/// StealCombatSkillFail1
		/// </summary>
		public const short StealCombatSkillFail1 = 281;

		/// <summary>
		/// StealCombatSkillFail2
		/// </summary>
		public const short StealCombatSkillFail2 = 282;

		/// <summary>
		/// StealCombatSkillFail3
		/// </summary>
		public const short StealCombatSkillFail3 = 283;

		/// <summary>
		/// StealCombatSkillFail4
		/// </summary>
		public const short StealCombatSkillFail4 = 284;

		/// <summary>
		/// StealCombatSkillSucceed
		/// </summary>
		public const short StealCombatSkillSucceed = 285;

		/// <summary>
		/// StealCombatSkillSucceedAndEscaped
		/// </summary>
		public const short StealCombatSkillSucceedAndEscaped = 286;

		/// <summary>
		/// CombatSkillGetStolenSucceed
		/// </summary>
		public const short CombatSkillGetStolenSucceed = 287;

		/// <summary>
		/// ScamCombatSkillFail1
		/// </summary>
		public const short ScamCombatSkillFail1 = 288;

		/// <summary>
		/// ScamCombatSkillFail2
		/// </summary>
		public const short ScamCombatSkillFail2 = 289;

		/// <summary>
		/// ScamCombatSkillFail3
		/// </summary>
		public const short ScamCombatSkillFail3 = 290;

		/// <summary>
		/// ScamCombatSkillFail4
		/// </summary>
		public const short ScamCombatSkillFail4 = 291;

		/// <summary>
		/// ScamCombatSkillSucceed
		/// </summary>
		public const short ScamCombatSkillSucceed = 292;

		/// <summary>
		/// ScamCombatSkillSucceedAndEscaped
		/// </summary>
		public const short ScamCombatSkillSucceedAndEscaped = 293;

		/// <summary>
		/// CombatSkillGetScammedSucceed
		/// </summary>
		public const short CombatSkillGetScammedSucceed = 294;

		/// <summary>
		/// LifeSkillBattleWin
		/// </summary>
		public const short LifeSkillBattleWin = 295;

		/// <summary>
		/// LifeSkillBattleLose
		/// </summary>
		public const short LifeSkillBattleLose = 296;

		/// <summary>
		/// ExchangeResource
		/// </summary>
		public const short ExchangeResource = 297;

		/// <summary>
		/// GiveResource
		/// </summary>
		public const short GiveResource = 298;

		/// <summary>
		/// PurchaseItem
		/// </summary>
		public const short PurchaseItem = 299;

		/// <summary>
		/// SellItem
		/// </summary>
		public const short SellItem = 300;

		/// <summary>
		/// GiveItem
		/// </summary>
		public const short GiveItem = 301;

		/// <summary>
		/// GivePoisonousItem
		/// </summary>
		public const short GivePoisonousItem = 302;

		/// <summary>
		/// GetResourceAsGift
		/// </summary>
		public const short GetResourceAsGift = 303;

		/// <summary>
		/// GetItemAsGift
		/// </summary>
		public const short GetItemAsGift = 304;

		/// <summary>
		/// RefusePoisonousGift
		/// </summary>
		public const short RefusePoisonousGift = 305;

		/// <summary>
		/// InstructLifeSkill
		/// </summary>
		public const short InstructLifeSkill = 306;

		/// <summary>
		/// InstructCombatSkill
		/// </summary>
		public const short InstructCombatSkill = 307;

		/// <summary>
		/// LearnLifeSkillWithInstructionSucceed
		/// </summary>
		public const short LearnLifeSkillWithInstructionSucceed = 308;

		/// <summary>
		/// LearnLifeSkillWithInstructionFail
		/// </summary>
		public const short LearnLifeSkillWithInstructionFail = 309;

		/// <summary>
		/// LearnCombatSkillWithInstructionSucceed
		/// </summary>
		public const short LearnCombatSkillWithInstructionSucceed = 310;

		/// <summary>
		/// LearnCombatSkillWithInstructionFail
		/// </summary>
		public const short LearnCombatSkillWithInstructionFail = 311;

		/// <summary>
		/// InviteToDrinkSucceed
		/// </summary>
		public const short InviteToDrinkSucceed = 312;

		/// <summary>
		/// InviteToDrinkFail
		/// </summary>
		public const short InviteToDrinkFail = 313;

		/// <summary>
		/// SellSucceed
		/// </summary>
		public const short SellSucceed = 314;

		/// <summary>
		/// SellFail
		/// </summary>
		public const short SellFail = 315;

		/// <summary>
		/// CureSucceed
		/// </summary>
		public const short CureSucceed = 316;

		/// <summary>
		/// RepairItemSucceed
		/// </summary>
		public const short RepairItemSucceed = 317;

		/// <summary>
		/// BarbSucceed
		/// </summary>
		public const short BarbSucceed = 318;

		/// <summary>
		/// BarbMistake
		/// </summary>
		public const short BarbMistake = 319;

		/// <summary>
		/// BarbFail
		/// </summary>
		public const short BarbFail = 320;

		/// <summary>
		/// AskForMoneySucceed
		/// </summary>
		public const short AskForMoneySucceed = 321;

		/// <summary>
		/// AskForMoneyFail
		/// </summary>
		public const short AskForMoneyFail = 322;

		/// <summary>
		/// EntertainWithMusic
		/// </summary>
		public const short EntertainWithMusic = 323;

		/// <summary>
		/// EntertainWithChess
		/// </summary>
		public const short EntertainWithChess = 324;

		/// <summary>
		/// EntertainWithPoem
		/// </summary>
		public const short EntertainWithPoem = 325;

		/// <summary>
		/// EntertainWithPainting
		/// </summary>
		public const short EntertainWithPainting = 326;

		/// <summary>
		/// AcceptInviteToDrink
		/// </summary>
		public const short AcceptInviteToDrink = 327;

		/// <summary>
		/// RefuseInviteToDrink
		/// </summary>
		public const short RefuseInviteToDrink = 328;

		/// <summary>
		/// AcceptSell
		/// </summary>
		public const short AcceptSell = 329;

		/// <summary>
		/// RefuseSell
		/// </summary>
		public const short RefuseSell = 330;

		/// <summary>
		/// AcceptCure
		/// </summary>
		public const short AcceptCure = 331;

		/// <summary>
		/// AcceptRepairItem
		/// </summary>
		public const short AcceptRepairItem = 332;

		/// <summary>
		/// GetBarbSucceed
		/// </summary>
		public const short GetBarbSucceed = 333;

		/// <summary>
		/// GetBarbMistake
		/// </summary>
		public const short GetBarbMistake = 334;

		/// <summary>
		/// GetBarbFail
		/// </summary>
		public const short GetBarbFail = 335;

		/// <summary>
		/// AcceptAskForMoney
		/// </summary>
		public const short AcceptAskForMoney = 336;

		/// <summary>
		/// RefuseAskForMoney
		/// </summary>
		public const short RefuseAskForMoney = 337;

		/// <summary>
		/// AcceptEntertainWithMusic
		/// </summary>
		public const short AcceptEntertainWithMusic = 338;

		/// <summary>
		/// AcceptEntertainWithChess
		/// </summary>
		public const short AcceptEntertainWithChess = 339;

		/// <summary>
		/// AcceptEntertainWithPoem
		/// </summary>
		public const short AcceptEntertainWithPoem = 340;

		/// <summary>
		/// AcceptEntertainWithPainting
		/// </summary>
		public const short AcceptEntertainWithPainting = 341;

		/// <summary>
		/// MakeItem
		/// </summary>
		public const short MakeItem = 342;

		/// <summary>
		/// TaoismAwakeningSucceed
		/// </summary>
		public const short TaoismAwakeningSucceed = 343;

		/// <summary>
		/// TaoismAwakeningFail
		/// </summary>
		public const short TaoismAwakeningFail = 344;

		/// <summary>
		/// BuddismAwakeningSucceed
		/// </summary>
		public const short BuddismAwakeningSucceed = 345;

		/// <summary>
		/// BuddismAwakeningFail
		/// </summary>
		public const short BuddismAwakeningFail = 346;

		/// <summary>
		/// TaoismGetAwakenedSucceed
		/// </summary>
		public const short TaoismGetAwakenedSucceed = 347;

		/// <summary>
		/// TaoismGetAwakenedFail
		/// </summary>
		public const short TaoismGetAwakenedFail = 348;

		/// <summary>
		/// BuddismGetAwakenedSucceed
		/// </summary>
		public const short BuddismGetAwakenedSucceed = 349;

		/// <summary>
		/// BuddismGetAwakenedFail
		/// </summary>
		public const short BuddismGetAwakenedFail = 350;

		/// <summary>
		/// CollectTeaWineSucceed
		/// </summary>
		public const short CollectTeaWineSucceed = 351;

		/// <summary>
		/// CollectTeaWineFail
		/// </summary>
		public const short CollectTeaWineFail = 352;

		/// <summary>
		/// DivinationSucceed
		/// </summary>
		public const short DivinationSucceed = 353;

		/// <summary>
		/// DivinationFail
		/// </summary>
		public const short DivinationFail = 354;

		/// <summary>
		/// CricketBattleWin
		/// </summary>
		public const short CricketBattleWin = 355;

		/// <summary>
		/// CricketBattleLose
		/// </summary>
		public const short CricketBattleLose = 356;

		/// <summary>
		/// MakeLoveLegal
		/// </summary>
		public const short MakeLoveLegal = 1401;

		/// <summary>
		/// MakeLoveIllegal
		/// </summary>
		public const short MakeLoveIllegal = 357;

		/// <summary>
		/// RapeFail
		/// </summary>
		public const short RapeFail = 358;

		/// <summary>
		/// RapeSucceed
		/// </summary>
		public const short RapeSucceed = 359;

		/// <summary>
		/// ReleaseKidnappedCharacter
		/// </summary>
		public const short ReleaseKidnappedCharacter = 360;

		/// <summary>
		/// GetRapedFail
		/// </summary>
		public const short GetRapedFail = 361;

		/// <summary>
		/// GetRapedSucceed
		/// </summary>
		public const short GetRapedSucceed = 362;

		/// <summary>
		/// GetReleasedByKidnapper
		/// </summary>
		public const short GetReleasedByKidnapper = 363;

		/// <summary>
		/// MerchantGetNewProduct
		/// </summary>
		public const short MerchantGetNewProduct = 364;

		/// <summary>
		/// UnexpectedResourceGain
		/// </summary>
		public const short UnexpectedResourceGain = 365;

		/// <summary>
		/// UnexpectedItemGain
		/// </summary>
		public const short UnexpectedItemGain = 366;

		/// <summary>
		/// UnexpectedSkillBookGain
		/// </summary>
		public const short UnexpectedSkillBookGain = 367;

		/// <summary>
		/// UnexpectedHealthCure
		/// </summary>
		public const short UnexpectedHealthCure = 368;

		/// <summary>
		/// UnexpectedOuterInjuryCure
		/// </summary>
		public const short UnexpectedOuterInjuryCure = 369;

		/// <summary>
		/// UnexpectedInnerInjuryCure
		/// </summary>
		public const short UnexpectedInnerInjuryCure = 370;

		/// <summary>
		/// UnexpectedPoisonCure
		/// </summary>
		public const short UnexpectedPoisonCure = 371;

		/// <summary>
		/// UnexpectedDisorderOfQiCure
		/// </summary>
		public const short UnexpectedDisorderOfQiCure = 372;

		/// <summary>
		/// UnexpectedResourceLose
		/// </summary>
		public const short UnexpectedResourceLose = 373;

		/// <summary>
		/// UnexpectedItemLose
		/// </summary>
		public const short UnexpectedItemLose = 374;

		/// <summary>
		/// UnexpectedSkillBookLose
		/// </summary>
		public const short UnexpectedSkillBookLose = 375;

		/// <summary>
		/// UnexpectedInjure
		/// </summary>
		public const short UnexpectedHealthHarm = 376;

		/// <summary>
		/// UnexpectedOuterInjuryHarm
		/// </summary>
		public const short UnexpectedOuterInjuryHarm = 377;

		/// <summary>
		/// UnexpectedInnerInjuryHarm
		/// </summary>
		public const short UnexpectedInnerInjuryHarm = 378;

		/// <summary>
		/// UnexpectedPoisonHarm
		/// </summary>
		public const short UnexpectedPoisonHarm = 379;

		/// <summary>
		/// UnexpectedDisorderOfQiHarm
		/// </summary>
		public const short UnexpectedDisorderOfQiHarm = 380;

		/// <summary>
		/// KillHereticRandomEnemy
		/// </summary>
		public const short KillHereticRandomEnemy = 381;

		/// <summary>
		/// KillRighteousRandomEnemy
		/// </summary>
		public const short KillRighteousRandomEnemy = 382;

		/// <summary>
		/// DefeatedByHereticRandomEnemy
		/// </summary>
		public const short DefeatedByHereticRandomEnemy = 383;

		/// <summary>
		/// DefeatedByRighteousRandomEnemy
		/// </summary>
		public const short DefeatedByRighteousRandomEnemy = 384;

		/// <summary>
		/// MonvBad
		/// </summary>
		public const short MonvBad = 385;

		/// <summary>
		/// DayueYaochangBad
		/// </summary>
		public const short DayueYaochangBad = 386;

		/// <summary>
		/// JinHuangerBad
		/// </summary>
		public const short JinHuangerBad = 387;

		/// <summary>
		/// YiyihouBad
		/// </summary>
		public const short YiyihouBad = 388;

		/// <summary>
		/// WeiQiBad
		/// </summary>
		public const short WeiQiBad = 389;

		/// <summary>
		/// YixiangBad
		/// </summary>
		public const short YixiangBad = 390;

		/// <summary>
		/// ShufangBad
		/// </summary>
		public const short ShufangBad = 391;

		/// <summary>
		/// JixiBad
		/// </summary>
		public const short JixiBad = 392;

		/// <summary>
		/// MonvGood
		/// </summary>
		public const short MonvGood = 393;

		/// <summary>
		/// DayueYaochangGood
		/// </summary>
		public const short DayueYaochangGood = 394;

		/// <summary>
		/// JinHuangerGood
		/// </summary>
		public const short JinHuangerGood = 395;

		/// <summary>
		/// YiyihouGood
		/// </summary>
		public const short YiyihouGood = 396;

		/// <summary>
		/// WeiQiGood
		/// </summary>
		public const short WeiQiGood = 397;

		/// <summary>
		/// YixiangGood
		/// </summary>
		public const short YixiangGood = 398;

		/// <summary>
		/// XuefengGood
		/// </summary>
		public const short XuefengGood = 399;

		/// <summary>
		/// ShufangGood
		/// </summary>
		public const short ShufangGood = 400;

		/// <summary>
		/// PregnantWithSamsara0
		/// </summary>
		public const short PregnantWithSamsara0 = 401;

		/// <summary>
		/// PregnantWithSamsara1
		/// </summary>
		public const short PregnantWithSamsara1 = 402;

		/// <summary>
		/// PregnantWithSamsara2
		/// </summary>
		public const short PregnantWithSamsara2 = 403;

		/// <summary>
		/// PregnantWithSamsara3
		/// </summary>
		public const short PregnantWithSamsara3 = 404;

		/// <summary>
		/// PregnantWithSamsara4
		/// </summary>
		public const short PregnantWithSamsara4 = 405;

		/// <summary>
		/// PregnantWithSamsara5
		/// </summary>
		public const short PregnantWithSamsara5 = 406;

		/// <summary>
		/// GainAuthority
		/// </summary>
		public const short GainAuthority = 407;

		/// <summary>
		/// SectPunishNormal
		/// </summary>
		public const short SectPunishNormal = 408;

		/// <summary>
		/// SectPunishElope
		/// </summary>
		public const short SectPunishElope = 409;

		/// <summary>
		/// ExpelVillager
		/// </summary>
		public const short ExpelVillager = 410;

		/// <summary>
		/// SavedFromInfection
		/// </summary>
		public const short SavedFromInfection = 411;

		/// <summary>
		/// ChangeGrade
		/// </summary>
		public const short ChangeGrade = 412;

		/// <summary>
		/// AutoChangeGrade
		/// </summary>
		public const short AutoChangeGrade = 1414;

		/// <summary>
		/// ExpelledByTaiwu
		/// </summary>
		public const short ExpelledByTaiwu = 413;

		/// <summary>
		/// InsteadSectPunishElope
		/// </summary>
		public const short InsteadSectPunishElope = 414;

		/// <summary>
		/// AvoidSectPunishElope
		/// </summary>
		public const short AvoidSectPunishElope = 415;

		/// <summary>
		/// JoinJoustForSpouse
		/// </summary>
		public const short JoinJoustForSpouse = 416;

		/// <summary>
		/// GetHusbandByJoustForSpouse
		/// </summary>
		public const short GetHusbandByJoustForSpouse = 417;

		/// <summary>
		/// GetWifeByJoustForSpouse
		/// </summary>
		public const short GetWifeByJoustForSpouse = 418;

		/// <summary>
		/// NoHusbandByJoustForSpouse
		/// </summary>
		public const short NoHusbandByJoustForSpouse = 419;

		/// <summary>
		/// SectCompetitionBeWinner
		/// </summary>
		public const short SectCompetitionBeWinner = 420;

		/// <summary>
		/// SectCompetitionBeParticipant
		/// </summary>
		public const short SectCompetitionBeParticipant = 421;

		/// <summary>
		/// SectCompetitionBeHost
		/// </summary>
		public const short SectCompetitionBeHost = 422;

		/// <summary>
		/// WulinConferenceBeParticipant
		/// </summary>
		public const short WulinConferenceBeParticipant = 423;

		/// <summary>
		/// WulinConferenceBeWinner
		/// </summary>
		public const short WulinConferenceBeWinner = 424;

		/// <summary>
		/// WulinConferenceBeWinnerButTaiwu
		/// </summary>
		public const short WulinConferenceBeWinnerButTaiwu = 425;

		/// <summary>
		/// WulinConferenceBeHost
		/// </summary>
		public const short WulinConferenceBeHost = 426;

		/// <summary>
		/// WulinConferenceBeKilledByYufu
		/// </summary>
		public const short WulinConferenceBeKilledByYufu = 427;

		/// <summary>
		/// WulinConferenceDonation
		/// </summary>
		public const short WulinConferenceDonation = 428;

		/// <summary>
		/// BeAttackedAndDieByWuYingLing
		/// </summary>
		public const short BeAttackedAndDieByWuYingLing = 429;

		/// <summary>
		/// NaturalDisasterGiveDeath
		/// </summary>
		public const short NaturalDisasterGiveDeath = 430;

		/// <summary>
		/// NaturalDisasterHappen
		/// </summary>
		public const short NaturalDisasterHappen = 431;

		/// <summary>
		/// NaturalDisasterButSurvive
		/// </summary>
		public const short NaturalDisasterButSurvive = 432;

		/// <summary>
		/// NormalInformationChangeLovingItemSubType
		/// </summary>
		public const short NormalInformationChangeLovingItemSubType = 433;

		/// <summary>
		/// NormalInformationChangeHatingItemSubType
		/// </summary>
		public const short NormalInformationChangeHatingItemSubType = 434;

		/// <summary>
		/// NormalInformationChangeIdealSect
		/// </summary>
		public const short NormalInformationChangeIdealSect = 435;

		/// <summary>
		/// NormalInformationChangeBaseMorality
		/// </summary>
		public const short NormalInformationChangeBaseMorality = 436;

		/// <summary>
		/// NormalInformationChangeLifeSkillTypeInterest
		/// </summary>
		public const short NormalInformationChangeLifeSkillTypeInterest = 437;

		/// <summary>
		/// RobGraveEncounterSkeleton
		/// </summary>
		public const short RobGraveEncounterSkeleton = 438;

		/// <summary>
		/// RobGraveFailed
		/// </summary>
		public const short RobGraveFailed = 439;

		/// <summary>
		/// SectPunishLevelLowest
		/// </summary>
		public const short SectPunishLevelLowest = 440;

		/// <summary>
		/// PrincipalSectPunishLevelMiddle
		/// </summary>
		public const short PrincipalSectPunishLevelMiddle = 441;

		/// <summary>
		/// PrincipalSectPunishLevelHighest
		/// </summary>
		public const short PrincipalSectPunishLevelHighest = 442;

		/// <summary>
		/// NonPrincipalSectPunishLevelLowest
		/// </summary>
		public const short NonPrincipalSectPunishLevelLowest = 443;

		/// <summary>
		/// NonPrincipalSectPunishLevelHighest
		/// </summary>
		public const short NonPrincipalSectPunishLevelHighest = 444;

		/// <summary>
		/// BecomeSwornSiblingByThreatened
		/// </summary>
		public const short BecomeSwornSiblingByThreatened = 445;

		/// <summary>
		/// MarriedByThreatened
		/// </summary>
		public const short MarriedByThreatened = 446;

		/// <summary>
		/// GetAdoptedFatherByThreatened
		/// </summary>
		public const short GetAdoptedFatherByThreatened = 447;

		/// <summary>
		/// GetAdoptedMotherByThreatened
		/// </summary>
		public const short GetAdoptedMotherByThreatened = 448;

		/// <summary>
		/// GetAdoptedSonByThreatened
		/// </summary>
		public const short GetAdoptedSonByThreatened = 449;

		/// <summary>
		/// GetAdoptedDaughterByThreatened
		/// </summary>
		public const short GetAdoptedDaughterByThreatened = 450;

		/// <summary>
		/// AddMentorByThreatened
		/// </summary>
		public const short AddMentorByThreatened = 451;

		/// <summary>
		/// SeverSwornSiblingByThreatened
		/// </summary>
		public const short SeverSwornSiblingByThreatened = 452;

		/// <summary>
		/// DivorceByThreatened
		/// </summary>
		public const short DivorceByThreatened = 453;

		/// <summary>
		/// SeverMentorByThreatened
		/// </summary>
		public const short SeverMentorByThreatened = 454;

		/// <summary>
		/// SeverAdoptiveFatherByThreatened
		/// </summary>
		public const short SeverAdoptiveFatherByThreatened = 455;

		/// <summary>
		/// SeverAdoptiveMotherByThreatened
		/// </summary>
		public const short SeverAdoptiveMotherByThreatened = 456;

		/// <summary>
		/// SeverAdoptiveSonByThreatened
		/// </summary>
		public const short SeverAdoptiveSonByThreatened = 457;

		/// <summary>
		/// SeverAdoptiveDaughterByThreatened
		/// </summary>
		public const short SeverAdoptiveDaughterByThreatened = 458;

		/// <summary>
		/// GetThreatenedAdoptiveFather
		/// </summary>
		public const short GetThreatenedAdoptiveFather = 459;

		/// <summary>
		/// GetThreatenedAdoptiveMother
		/// </summary>
		public const short GetThreatenedAdoptiveMother = 460;

		/// <summary>
		/// GetThreatenedAdoptiveSon
		/// </summary>
		public const short GetThreatenedAdoptiveSon = 461;

		/// <summary>
		/// GetThreatenedAdoptiveDaughter
		/// </summary>
		public const short GetThreatenedAdoptiveDaughter = 462;

		/// <summary>
		/// ApproveTaiwuByThreatened
		/// </summary>
		public const short ApproveTaiwuByThreatened = 463;

		/// <summary>
		/// FourSeasonsAdventureBeParticipant
		/// </summary>
		public const short FourSeasonsAdventureBeParticipant = 464;

		/// <summary>
		/// FourSeasonsAdventureBeWinner
		/// </summary>
		public const short FourSeasonsAdventureBeWinner = 465;

		/// <summary>
		/// EndAdored
		/// </summary>
		public const short EndAdored = 466;

		/// <summary>
		/// GetMentor
		/// </summary>
		public const short GetMentor = 467;

		/// <summary>
		/// GetMentee
		/// </summary>
		public const short GetMentee = 468;

		/// <summary>
		/// SeverAdoptiveParent
		/// </summary>
		public const short SeverAdoptiveParent = 469;

		/// <summary>
		/// SeverAdoptiveChild
		/// </summary>
		public const short SeverAdoptiveChild = 470;

		/// <summary>
		/// SeverMentor
		/// </summary>
		public const short SeverMentor = 471;

		/// <summary>
		/// SeverMentee
		/// </summary>
		public const short SeverMentee = 472;

		/// <summary>
		/// Divorce
		/// </summary>
		public const short Divorce = 473;

		/// <summary>
		/// ThreatenSucceed
		/// </summary>
		public const short ThreatenSucceed = 474;

		/// <summary>
		/// AdmonishSucceed
		/// </summary>
		public const short AdmonishSucceed = 475;

		/// <summary>
		/// ChangeBehaviorTypeByAdmonishedGood
		/// </summary>
		public const short ChangeBehaviorTypeByAdmonishedGood = 476;

		/// <summary>
		/// ReduceDebtByAdmonished
		/// </summary>
		public const short ReduceDebtByAdmonished = 477;

		/// <summary>
		/// ReduceDebtByThreatened
		/// </summary>
		public const short ReduceDebtByThreatened = 478;

		/// <summary>
		/// ChangeBehaviorTypeByAdmonishedBad
		/// </summary>
		public const short ChangeBehaviorTypeByAdmonishedBad = 479;

		/// <summary>
		/// GainLegendaryBook
		/// </summary>
		public const short GainLegendaryBook = 480;

		/// <summary>
		/// BoostedByLegendaryBooks
		/// </summary>
		public const short BoostedByLegendaryBooks = 481;

		/// <summary>
		/// ActCrazy
		/// </summary>
		public const short ActCrazy = 482;

		/// <summary>
		/// LegendaryBookShocked
		/// </summary>
		public const short LegendaryBookShocked = 483;

		/// <summary>
		/// LegendaryBookInsane
		/// </summary>
		public const short LegendaryBookInsane = 484;

		/// <summary>
		/// LegendaryBookConsumed
		/// </summary>
		public const short LegendaryBookConsumed = 485;

		/// <summary>
		/// DecideToContestForLegendaryBook
		/// </summary>
		public const short DecideToContestForLegendaryBook = 486;

		/// <summary>
		/// FinishContestForLegendaryBook
		/// </summary>
		public const short FinishContestForLegendaryBook = 487;

		/// <summary>
		/// LegendaryBookChallengeWin
		/// </summary>
		public const short LegendaryBookChallengeWin = 488;

		/// <summary>
		/// LegendaryBookChallengeLose
		/// </summary>
		public const short LegendaryBookChallengeLose = 489;

		/// <summary>
		/// AcceptLegendaryBookChallengeWin
		/// </summary>
		public const short AcceptLegendaryBookChallengeWin = 490;

		/// <summary>
		/// AcceptLegendaryBookChallengeLose
		/// </summary>
		public const short AcceptLegendaryBookChallengeLose = 491;

		/// <summary>
		/// AcceptLegendaryBookChallengeEscape
		/// </summary>
		public const short AcceptLegendaryBookChallengeEscape = 492;

		/// <summary>
		/// LegendaryBookChallengeEscaped
		/// </summary>
		public const short LegendaryBookChallengeEscaped = 493;

		/// <summary>
		/// LegendaryBookChallengeSelfEscaped
		/// </summary>
		public const short LegendaryBookChallengeSelfEscaped = 494;

		/// <summary>
		/// AcceptLegendaryBookChallengeEnemyEscaped
		/// </summary>
		public const short AcceptLegendaryBookChallengeEnemyEscaped = 495;

		/// <summary>
		/// RefuseRequestLegendaryBookChallenge
		/// </summary>
		public const short RefuseRequestLegendaryBookChallenge = 496;

		/// <summary>
		/// RequestLegendaryBookChallengeFail
		/// </summary>
		public const short RequestLegendaryBookChallengeFail = 497;

		/// <summary>
		/// AcceptRequestLegendaryBook
		/// </summary>
		public const short AcceptRequestLegendaryBook = 498;

		/// <summary>
		/// RequestLegendaryBookSucceed
		/// </summary>
		public const short RequestLegendaryBookSucceed = 499;

		/// <summary>
		/// RequestLegendaryBookFail
		/// </summary>
		public const short RequestLegendaryBookFail = 500;

		/// <summary>
		/// RefuseRequestLegendaryBook
		/// </summary>
		public const short RefuseRequestLegendaryBook = 501;

		/// <summary>
		/// AcceptRequestExchangeLegendaryBook
		/// </summary>
		public const short AcceptRequestExchangeLegendaryBook = 502;

		/// <summary>
		/// RequestExchangeLegendaryBookSucceed
		/// </summary>
		public const short RequestExchangeLegendaryBookSucceed = 503;

		/// <summary>
		/// RefuseRequestExchangeLegendaryBook
		/// </summary>
		public const short RefuseRequestExchangeLegendaryBook = 504;

		/// <summary>
		/// RequestExchangeLegendaryBookFail
		/// </summary>
		public const short RequestExchangeLegendaryBookFail = 505;

		/// <summary>
		/// GiveLegendaryBookFail
		/// </summary>
		public const short GiveLegendaryBookFail = 506;

		/// <summary>
		/// RefuseGiveLegendaryBook
		/// </summary>
		public const short RefuseGiveLegendaryBook = 507;

		/// <summary>
		/// DefeatLegendaryBookInsaneJust
		/// </summary>
		public const short DefeatLegendaryBookInsaneJust = 508;

		/// <summary>
		/// DefeatLegendaryBookInsaneKind
		/// </summary>
		public const short DefeatLegendaryBookInsaneKind = 509;

		/// <summary>
		/// DefeatLegendaryBookInsaneEven
		/// </summary>
		public const short DefeatLegendaryBookInsaneEven = 510;

		/// <summary>
		/// DefeatLegendaryBookInsaneRebel
		/// </summary>
		public const short DefeatLegendaryBookInsaneRebel = 511;

		/// <summary>
		/// DefeatLegendaryBookInsaneEgoistic
		/// </summary>
		public const short DefeatLegendaryBookInsaneEgoistic = 512;

		/// <summary>
		/// LegendaryBookInsaneDefeatedJust
		/// </summary>
		public const short LegendaryBookInsaneDefeatedJust = 513;

		/// <summary>
		/// LegendaryBookInsaneDefeatedKind
		/// </summary>
		public const short LegendaryBookInsaneDefeatedKind = 514;

		/// <summary>
		/// LegendaryBookInsaneDefeatedEven
		/// </summary>
		public const short LegendaryBookInsaneDefeatedEven = 515;

		/// <summary>
		/// LegendaryBookInsaneDefeatedRebel
		/// </summary>
		public const short LegendaryBookInsaneDefeatedRebel = 516;

		/// <summary>
		/// LegendaryBookInsaneDefeatedEgoistic
		/// </summary>
		public const short LegendaryBookInsaneDefeatedEgoistic = 517;

		/// <summary>
		/// ShockedInsaneEscaped
		/// </summary>
		public const short ShockedInsaneEscaped = 518;

		/// <summary>
		/// ReleaseShockedInsane
		/// </summary>
		public const short ReleaseShockedInsane = 519;

		/// <summary>
		/// UnderAttackEscaped
		/// </summary>
		public const short UnderAttackEscaped = 520;

		/// <summary>
		/// ReleaseUnderAttack
		/// </summary>
		public const short ReleaseUnderAttack = 521;

		/// <summary>
		/// DefeatConsumed
		/// </summary>
		public const short DefeatConsumed = 522;

		/// <summary>
		/// BeDefetedByConsumed
		/// </summary>
		public const short BeDefetedByConsumed = 523;

		/// <summary>
		/// AcceptRequestExchangeLegendaryBookByExp
		/// </summary>
		public const short AcceptRequestExchangeLegendaryBookByExp = 524;

		/// <summary>
		/// RequestExchangeLegendaryBookSucceedByExp
		/// </summary>
		public const short RequestExchangeLegendaryBookSucceedByExp = 525;

		/// <summary>
		/// ResignPositionToStudyLegendaryBook
		/// </summary>
		public const short ResignPositionToStudyLegendaryBook = 526;

		/// <summary>
		/// SoundOutLoverMind
		/// </summary>
		public const short SoundOutLoverMind = 527;

		/// <summary>
		/// SoundOutMind
		/// </summary>
		public const short SoundOutMind = 528;

		/// <summary>
		/// RedeemMindSucceed
		/// </summary>
		public const short RedeemMindSucceed = 529;

		/// <summary>
		/// RedeemMindFail
		/// </summary>
		public const short RedeemMindFail = 530;

		/// <summary>
		/// AcceptRedeemMind
		/// </summary>
		public const short AcceptRedeemMind = 531;

		/// <summary>
		/// RefuseRedeemMind
		/// </summary>
		public const short RefuseRedeemMind = 532;

		/// <summary>
		/// FirstDateWithLover
		/// </summary>
		public const short FirstDateWithLover = 533;

		/// <summary>
		/// FirstDateWithTaiwu
		/// </summary>
		public const short FirstDateWithTaiwu = 534;

		/// <summary>
		/// SelectLoverToken
		/// </summary>
		public const short SelectLoverToken = 535;

		/// <summary>
		/// SelectLoverToken2
		/// </summary>
		public const short SelectLoverToken2 = 536;

		/// <summary>
		/// DateWithLover
		/// </summary>
		public const short DateWithLover = 537;

		/// <summary>
		/// DateWithLover2
		/// </summary>
		public const short DateWithLover2 = 538;

		/// <summary>
		/// TillDeathDoUsPart
		/// </summary>
		public const short TillDeathDoUsPart = 539;

		/// <summary>
		/// CelebrateBirthday
		/// </summary>
		public const short CelebrateBirthday = 540;

		/// <summary>
		/// CelebrateSelfBirthday
		/// </summary>
		public const short CelebrateSelfBirthday = 541;

		/// <summary>
		/// CelebrateAnniversary
		/// </summary>
		public const short CelebrateAnniversary = 542;

		/// <summary>
		/// BeCaughtCheating
		/// </summary>
		public const short BeCaughtCheating = 543;

		/// <summary>
		/// CaughtCheating
		/// </summary>
		public const short CaughtCheating = 544;

		/// <summary>
		/// PregnancyWithWife
		/// </summary>
		public const short PregnancyWithWife = 545;

		/// <summary>
		/// PregnancyWithHusband
		/// </summary>
		public const short PregnancyWithHusband = 546;

		/// <summary>
		/// TeaTasting
		/// </summary>
		public const short TeaTasting = 547;

		/// <summary>
		/// TeaTastingLifeSkillBattleWin
		/// </summary>
		public const short TeaTastingLifeSkillBattleWin = 548;

		/// <summary>
		/// TeaTastingLifeSkillBattleLose
		/// </summary>
		public const short TeaTastingLifeSkillBattleLose = 549;

		/// <summary>
		/// TeaTastingDisorderOfQi
		/// </summary>
		public const short TeaTastingDisorderOfQi = 550;

		/// <summary>
		/// WineTasting
		/// </summary>
		public const short WineTasting = 551;

		/// <summary>
		/// WineTastingLifeSkillBattleWin
		/// </summary>
		public const short WineTastingLifeSkillBattleWin = 552;

		/// <summary>
		/// WineTastingLifeSkillBattleLose
		/// </summary>
		public const short WineTastingLifeSkillBattleLose = 553;

		/// <summary>
		/// WineTastingDisorderOfQi
		/// </summary>
		public const short WineTastingDisorderOfQi = 554;

		/// <summary>
		/// FirstNameChanged
		/// </summary>
		public const short FirstNameChanged = 555;

		/// <summary>
		/// LifeSkillModel
		/// </summary>
		public const short LifeSkillModel = 556;

		/// <summary>
		/// CombatSkillModel
		/// </summary>
		public const short CombatSkillModel = 557;

		/// <summary>
		/// PromoteReputation
		/// </summary>
		public const short PromoteReputation = 558;

		/// <summary>
		/// ReputationPromoted
		/// </summary>
		public const short ReputationPromoted = 559;

		/// <summary>
		/// CapabilityCultivated
		/// </summary>
		public const short CapabilityCultivated = 560;

		/// <summary>
		/// BroughtToTaiwuByBeggars
		/// </summary>
		public const short BroughtToTaiwuByBeggars = 561;

		/// <summary>
		/// CivilianSkillSeverEnemy
		/// </summary>
		public const short DiscardRevengeForCivilianSkill = 562;

		/// <summary>
		/// CivilianSkillDissolveResentment
		/// </summary>
		public const short CivilianSkillDissolveResentment = 563;

		/// <summary>
		/// PersuadeWithdrawlFromOrganization
		/// </summary>
		public const short PersuadeWithdrawlFromOrganization = 564;

		/// <summary>
		/// WithdrawlFromOrganization
		/// </summary>
		public const short WithdrawlFromOrganization = 565;

		/// <summary>
		/// FreeMedicalConsultation
		/// </summary>
		public const short FreeMedicalConsultation = 566;

		/// <summary>
		/// OfferTreasures
		/// </summary>
		public const short OfferTreasures = 567;

		/// <summary>
		/// ReceiveOfferedTreasures
		/// </summary>
		public const short ReceiveOfferedTreasures = 568;

		/// <summary>
		/// ForcefulPurchase
		/// </summary>
		public const short ForcefulPurchase = 569;

		/// <summary>
		/// ForcefulSale
		/// </summary>
		public const short ForcefulSale = 570;

		/// <summary>
		/// BegForMoney
		/// </summary>
		public const short BegForMoney = 571;

		/// <summary>
		/// AbsurdlyForceToLeave
		/// </summary>
		public const short AbsurdlyForceToLeave = 572;

		/// <summary>
		/// AbsurdlyForcedToLeave
		/// </summary>
		public const short AbsurdlyForcedToLeave = 573;

		/// <summary>
		/// DiagnoseWithMedicine
		/// </summary>
		public const short DiagnoseWithMedicine = 574;

		/// <summary>
		/// DiagnosedWithMedicine
		/// </summary>
		public const short DiagnosedWithMedicine = 575;

		/// <summary>
		/// DiagnoseWithWrongMedicine
		/// </summary>
		public const short DiagnoseWithNonMedicine = 576;

		/// <summary>
		/// DiagnosedWithWrongMedicine
		/// </summary>
		public const short DiagnosedWithWrongMedicine = 577;

		/// <summary>
		/// ExtendLifeSpan
		/// </summary>
		public const short ExtendLifeSpan = 578;

		/// <summary>
		/// LifeSpanExtended
		/// </summary>
		public const short LifeSpanExtended = 579;

		/// <summary>
		/// PersuadeToBecomeMonk
		/// </summary>
		public const short PersuadeToBecomeMonk = 580;

		/// <summary>
		/// BecomeMonkPersuaded
		/// </summary>
		public const short BecomeMonkPersuaded = 581;

		/// <summary>
		/// FailToPersuadeToBecomeMonk
		/// </summary>
		public const short FailToPersuadeToBecomeMonk = 582;

		/// <summary>
		/// ExpiateDeadSouls
		/// </summary>
		public const short ExpiateDeadSouls = 583;

		/// <summary>
		/// ExociseXiangshuInfectionVictoryInCombat
		/// </summary>
		public const short ExociseXiangshuInfectionVictoryInCombat = 584;

		/// <summary>
		/// BecomeExociseXiangshuInfectionVictoryInCombat
		/// </summary>
		public const short BecomeExociseXiangshuInfectionVictoryInCombat = 585;

		/// <summary>
		/// ExociseXiangshuInfectionVictoryInCombatDefeated
		/// </summary>
		public const short ExociseXiangshuInfectionVictoryInCombatDefeated = 586;

		/// <summary>
		/// TribulationSucceeded
		/// </summary>
		public const short TribulationSucceeded = 587;

		/// <summary>
		/// TribulationFailed
		/// </summary>
		public const short TribulationFailed = 588;

		/// <summary>
		/// TribulationCanceled
		/// </summary>
		public const short TribulationCanceled = 589;

		/// <summary>
		/// TribulationContinued
		/// </summary>
		public const short TribulationContinued = 590;

		/// <summary>
		/// GuidingEvilToGoodSucceed
		/// </summary>
		public const short GuidingEvilToGoodSucceed = 591;

		/// <summary>
		/// BecomeGuidingEvilToGoodSucceed
		/// </summary>
		public const short GuidingEvilGoodSucceed = 592;

		/// <summary>
		/// GuidingEvilToGoodFail
		/// </summary>
		public const short GuidingEvilToGoodFail = 593;

		/// <summary>
		/// VisitBuddhismTemples
		/// </summary>
		public const short VisitBuddhismTemples = 594;

		/// <summary>
		/// EpiphanyThruVisitTemples
		/// </summary>
		public const short EpiphanyThruVisitTemples = 595;

		/// <summary>
		/// EpiphanyThruVisitTemplesCombatSkill
		/// </summary>
		public const short EpiphanyThruVisitTemplesCombatSkill = 596;

		/// <summary>
		/// EpiphanyThruVisitTemplesLifeSkill
		/// </summary>
		public const short EpiphanyThruVisitTemplesLifeSkill = 597;

		/// <summary>
		/// EpiphanyThruVisitTemplesExperience
		/// </summary>
		public const short EpiphanyThruVisitTemplesExperience = 598;

		/// <summary>
		/// DivineUnexpectedGain
		/// </summary>
		public const short DivineUnexpectedGain = 599;

		/// <summary>
		/// DivineUnexpectedHarm
		/// </summary>
		public const short DivineUnexpectedHarm = 600;

		/// <summary>
		/// ExchangeFates
		/// </summary>
		public const short ExchangeFates = 601;

		/// <summary>
		/// BecomeExchangeFates
		/// </summary>
		public const short BecomeExchangeFates = 602;

		/// <summary>
		/// ImmortalityGained
		/// </summary>
		public const short ImmortalityGained = 603;

		/// <summary>
		/// ImmortalityLost
		/// </summary>
		public const short ImmortalityLost = 604;

		/// <summary>
		/// ImmortalityRegained
		/// </summary>
		public const short ImmortalityRegained = 605;

		/// <summary>
		/// TaiwuReincarnation
		/// </summary>
		public const short TaiwuReincarnation = 606;

		/// <summary>
		/// TaiwuReincarnationPregnancy
		/// </summary>
		public const short TaiwuReincarnationPregnancy = 607;

		/// <summary>
		/// MixPoisonHotRedRotten
		/// </summary>
		public const short MixPoisonHotRedRotten = 608;

		/// <summary>
		/// MixPoisonHotRottenIllusory
		/// </summary>
		public const short MixPoisonHotRottenIllusory = 609;

		/// <summary>
		/// MixPoisonHotRottenGloomy
		/// </summary>
		public const short MixPoisonHotRottenGloomy = 610;

		/// <summary>
		/// MixPoisonHotRottenCold
		/// </summary>
		public const short MixPoisonHotRottenCold = 611;

		/// <summary>
		/// MixPoisonRedRottenIllusory
		/// </summary>
		public const short MixPoisonRedRottenIllusory = 612;

		/// <summary>
		/// MixPoisonRedRottenGloomy
		/// </summary>
		public const short MixPoisonRedRottenGloomy = 613;

		/// <summary>
		/// MixPoisonRedRottenCold
		/// </summary>
		public const short MixPoisonRedRottenCold = 614;

		/// <summary>
		/// MixPoisonHotRedIllusory
		/// </summary>
		public const short MixPoisonHotRedIllusory = 615;

		/// <summary>
		/// MixPoisonHotRedGloomy
		/// </summary>
		public const short MixPoisonHotRedGloomy = 616;

		/// <summary>
		/// MixPoisonHotRedCold
		/// </summary>
		public const short MixPoisonHotRedCold = 617;

		/// <summary>
		/// MixPoisonGloomyColdIllusory
		/// </summary>
		public const short MixPoisonGloomyColdIllusory = 618;

		/// <summary>
		/// MixPoisonRottenGloomyCold
		/// </summary>
		public const short MixPoisonRottenGloomyCold = 619;

		/// <summary>
		/// MixPoisonHotGloomyCold
		/// </summary>
		public const short MixPoisonHotGloomyCold = 620;

		/// <summary>
		/// MixPoisonRedGloomyCold
		/// </summary>
		public const short MixPoisonRedGloomyCold = 621;

		/// <summary>
		/// MixPoisonRottenColdIllusory
		/// </summary>
		public const short MixPoisonRottenColdIllusory = 622;

		/// <summary>
		/// MixPoisonHotColdIllusory
		/// </summary>
		public const short MixPoisonHotColdIllusory = 623;

		/// <summary>
		/// MixPoisonRedColdIllusory
		/// </summary>
		public const short MixPoisonRedColdIllusory = 624;

		/// <summary>
		/// MixPoisonRottenGloomyIllusory
		/// </summary>
		public const short MixPoisonRottenGloomyIllusory = 625;

		/// <summary>
		/// MixPoisonHotGloomyIllusory
		/// </summary>
		public const short MixPoisonHotGloomyIllusory = 626;

		/// <summary>
		/// MixPoisonRedGloomyIllusory
		/// </summary>
		public const short MixPoisonRedGloomyIllusory = 627;

		/// <summary>
		/// DiggingXiangshuMinionCombatLost
		/// </summary>
		public const short DiggingXiangshuMinionCombatLost = 628;

		/// <summary>
		/// DiggingXiangshuMinionCombatWon
		/// </summary>
		public const short DiggingXiangshuMinionCombatWon = 629;

		/// <summary>
		/// SectMainStoryXuehouJixiKills
		/// </summary>
		public const short SectMainStoryXuehouJixiKills = 630;

		/// <summary>
		/// SectMainStoryWudangTreasure
		/// </summary>
		public const short SectMainStoryWudangTreasure = 631;

		/// <summary>
		/// SectMainStoryXuannvJoinOrg
		/// </summary>
		public const short SectMainStoryXuannvJoinOrg = 632;

		/// <summary>
		/// SectMainStoryYuanshanGetAbsorbed
		/// </summary>
		public const short SectMainStoryYuanshanGetAbsorbed = 633;

		/// <summary>
		/// SectMainStoryYuanshanResistSucceed
		/// </summary>
		public const short SectMainStoryYuanshanResistSucceed = 634;

		/// <summary>
		/// SectMainStoryYuanshanResistOrdinary
		/// </summary>
		public const short SectMainStoryYuanshanResistOrdinary = 635;

		/// <summary>
		/// SectMainStoryYuanshanResistFailed
		/// </summary>
		public const short SectMainStoryYuanshanResistFailed = 636;

		/// <summary>
		/// SectMainStoryXuehouZombieKills
		/// </summary>
		public const short SectMainStoryXuehouZombieKills = 637;

		/// <summary>
		/// SectMainStoryShixiangSkillEnemy
		/// </summary>
		public const short SectMainStoryShixiangSkillEnemy = 638;

		/// <summary>
		/// SectMainStoryWuxianMethysis0
		/// </summary>
		public const short SectMainStoryWuxianMethysis0 = 639;

		/// <summary>
		/// SectMainStoryWuxianPoison
		/// </summary>
		public const short SectMainStoryWuxianPoison = 640;

		/// <summary>
		/// SectMainStoryWuxianAssault
		/// </summary>
		public const short SectMainStoryWuxianAssault = 641;

		/// <summary>
		/// SectMainStoryWuxianMethysis1
		/// </summary>
		public const short SectMainStoryWuxianMethysis1 = 642;

		/// <summary>
		/// SectMainStoryEmeiInfighting
		/// </summary>
		public const short SectMainStoryEmeiInfighting = 643;

		/// <summary>
		/// SectMainStoryJieqingAssassin
		/// </summary>
		public const short SectMainStoryJieqingAssassin = 644;

		/// <summary>
		/// WulinConferencePraiseAndGifts
		/// </summary>
		public const short WulinConferencePraiseAndGifts = 645;

		/// <summary>
		/// NormalInformationChangeIdealSectNegative
		/// </summary>
		public const short NormalInformationChangeIdealSectNegative = 646;

		/// <summary>
		/// SectMainStoryXuehouJixiRescueTaiwu
		/// </summary>
		public const short SectMainStoryXuehouJixiRescueTaiwu = 647;

		/// <summary>
		/// SectMainStoryRanshanThreeFactionCompetetion
		/// </summary>
		public const short SectMainStoryRanshanJoinThreeFactionCompetetion = 648;

		/// <summary>
		/// SectMainStoryRanshanThreeFactionCompetetionWin
		/// </summary>
		public const short SectMainStoryRanshanThreeFactionCompetetionWin = 649;

		/// <summary>
		/// SectMainStoryRanshanThreeFactionCompetetionLose
		/// </summary>
		public const short SectMainStoryRanshanThreeFactionCompetetionLose = 650;

		/// <summary>
		/// GainExpByStroll
		/// </summary>
		public const short GainExpByStroll = 651;

		/// <summary>
		/// GainExpByReadingOldBook
		/// </summary>
		public const short GainExpByReadingOldBook = 652;

		/// <summary>
		/// PunishedAlongsideSpouse
		/// </summary>
		public const short PunishedAlongsideSpouse = 653;

		/// <summary>
		/// DecideToAdoptFoundling
		/// </summary>
		public const short DecideToAdoptFoundling = 654;

		/// <summary>
		/// AdoptFoundlingFail
		/// </summary>
		public const short AdoptFoundlingFail = 655;

		/// <summary>
		/// AdoptFoundlingSucceed
		/// </summary>
		public const short AdoptFoundlingSucceed = 656;

		/// <summary>
		/// FoundlingBeAdopted
		/// </summary>
		public const short FoundlingGetAdopted = 657;

		/// <summary>
		/// ClaimFoundlingSucceed
		/// </summary>
		public const short ClaimFoundlingSucceed = 658;

		/// <summary>
		/// FoundlingGetClaimed
		/// </summary>
		public const short FoundlingGetClaimed = 659;

		/// <summary>
		/// SectMainStoryWudangVillagerKilled
		/// </summary>
		public const short SectMainStoryWudangVillagerKilled = 660;

		/// <summary>
		/// SectMainStoryShixiangFallIll
		/// </summary>
		public const short SectMainStoryShixiangFallIll = 661;

		/// <summary>
		/// KillAnimal
		/// </summary>
		public const short KillAnimal = 662;

		/// <summary>
		/// DefeatedByAnimal
		/// </summary>
		public const short DefeatedByAnimal = 663;

		/// <summary>
		/// EnterEnemyNest
		/// </summary>
		public const short EnterEnemyNest = 664;

		/// <summary>
		/// DieFromEnemyNest
		/// </summary>
		public const short DieFromEnemyNest = 665;

		/// <summary>
		/// EscapeFromEnemyNest
		/// </summary>
		public const short EscapeFromEnemyNest = 666;

		/// <summary>
		/// GetSecretSpreadInVeryHighProbability
		/// </summary>
		public const short GetSecretSpreadInVeryHighProbability = 667;

		/// <summary>
		/// GetSecretSpreadInHighProbability
		/// </summary>
		public const short GetSecretSpreadInHighProbability = 668;

		/// <summary>
		/// GetSecretSpreadInLowProbability
		/// </summary>
		public const short GetSecretSpreadInLowProbability = 669;

		/// <summary>
		/// GetSecretSpreadInVeryLowProbability
		/// </summary>
		public const short GetSecretSpreadInVeryLowProbability = 670;

		/// <summary>
		/// SpreadSecretFail
		/// </summary>
		public const short SpreadSecretFail = 671;

		/// <summary>
		/// SpreadSecretSuccess
		/// </summary>
		public const short SpreadSecretSuccess = 672;

		/// <summary>
		/// HeardSecretSpreadInVeryHighProbability
		/// </summary>
		public const short HeardSecretSpreadInVeryHighProbability = 673;

		/// <summary>
		/// HeardSecretSpreadInHighProbability
		/// </summary>
		public const short HeardSecretSpreadInHighProbability = 674;

		/// <summary>
		/// HeardSecretSpreadInLowProbability
		/// </summary>
		public const short HeardSecretSpreadInLowProbability = 675;

		/// <summary>
		/// HeardSecretSpreadInVeryLowProbability
		/// </summary>
		public const short HeardSecretSpreadInVeryLowProbability = 676;

		/// <summary>
		/// RequestKeepSecretFail
		/// </summary>
		public const short RequestKeepSecretFail = 677;

		/// <summary>
		/// RequestKeepSecretSuccess
		/// </summary>
		public const short RequestKeepSecretSuccess = 678;

		/// <summary>
		/// BeRequestedToKeepSecret
		/// </summary>
		public const short BeRequestedToKeepSecret = 679;

		/// <summary>
		/// ThreadNeedleMatchFail
		/// </summary>
		public const short ThreadNeedleMatchFail = 680;

		/// <summary>
		/// ThreadNeedleSeparateFail
		/// </summary>
		public const short ThreadNeedleSeparateFail = 681;

		/// <summary>
		/// ThreadNeedleMatchSuccess
		/// </summary>
		public const short ThreadNeedleMatchSuccess = 682;

		/// <summary>
		/// ThreadNeedleSeparateSuccess
		/// </summary>
		public const short ThreadNeedleSeparateSuccess = 683;

		/// <summary>
		/// ThreadNeedleBeMatched0
		/// </summary>
		public const short ThreadNeedleBeMatched1 = 684;

		/// <summary>
		/// ThreadNeedleBeSeparated0
		/// </summary>
		public const short ThreadNeedleBeSeparated1 = 685;

		/// <summary>
		/// ThreadNeedleBeMatched1
		/// </summary>
		public const short ThreadNeedleBeMatched2 = 686;

		/// <summary>
		/// ThreadNeedleBeSeparated1
		/// </summary>
		public const short ThreadNeedleBeSeparated2 = 687;

		/// <summary>
		/// SpreadSecretKnown
		/// </summary>
		public const short SpreadSecretKnown = 688;

		/// <summary>
		/// SectMainStoryXuannvBirthOfMirrorCreatedImposture
		/// </summary>
		public const short SectMainStoryXuannvBirthOfMirrorCreatedImposture = 689;

		/// <summary>
		/// EscapeFromEnemyNestBySelf
		/// </summary>
		public const short EscapeFromEnemyNestBySelf = 690;

		/// <summary>
		/// SaveFromInfection
		/// </summary>
		public const short SaveFromInfection = 691;

		/// <summary>
		/// SaveFromEnemyNest
		/// </summary>
		public const short SaveFromEnemyNest = 692;

		/// <summary>
		/// SaveFromEnemyNestFailed
		/// </summary>
		public const short SaveFromEnemyNestFailed = 693;

		/// <summary>
		/// TameCarrierSucceed
		/// </summary>
		public const short TameCarrierSucceed = 694;

		/// <summary>
		/// TameCarrierFail
		/// </summary>
		public const short TameCarrierFail = 695;

		/// <summary>
		/// ReleaseCarrier
		/// </summary>
		public const short ReleaseCarrier = 696;

		/// <summary>
		/// DLCLoongRidingEffectQiuniuAudience
		/// </summary>
		public const short DLCLoongRidingEffectQiuniuAudience = 697;

		/// <summary>
		/// DLCLoongRidingEffectQiuniu
		/// </summary>
		public const short DLCLoongRidingEffectQiuniu = 698;

		/// <summary>
		/// DLCLoongRidingEffectYazi
		/// </summary>
		public const short DLCLoongRidingEffectYazi = 699;

		/// <summary>
		/// DLCLoongRidingEffectChaofeng
		/// </summary>
		public const short DLCLoongRidingEffectChaofeng = 700;

		/// <summary>
		/// DLCLoongRidingEffectPulao
		/// </summary>
		public const short DLCLoongRidingEffectPulao = 701;

		/// <summary>
		/// DLCLoongRidingEffectSuanni
		/// </summary>
		public const short DLCLoongRidingEffectSuanni = 702;

		/// <summary>
		/// DLCLoongRidingEffectBaxia
		/// </summary>
		public const short DLCLoongRidingEffectBaxia = 703;

		/// <summary>
		/// DLCLoongRidingEffectBian
		/// </summary>
		public const short DLCLoongRidingEffectBian = 704;

		/// <summary>
		/// DLCLoongRidingEffectFuxi
		/// </summary>
		public const short DLCLoongRidingEffectFuxi = 705;

		/// <summary>
		/// DLCLoongRidingEffectChiwen
		/// </summary>
		public const short DLCLoongRidingEffectChiwen = 706;

		/// <summary>
		/// DefeatLoong
		/// </summary>
		public const short DefeatLoong = 707;

		/// <summary>
		/// DefeatedByLoong
		/// </summary>
		public const short DefeatedByLoong = 708;

		/// <summary>
		/// DLCLoongRidingEffectYazi2
		/// </summary>
		public const short DLCLoongRidingEffectYazi2 = 709;

		/// <summary>
		/// DieFromAge
		/// </summary>
		public const short DieFromAge = 710;

		/// <summary>
		/// DieFromPoorHealth
		/// </summary>
		public const short DieFromPoorHealth = 711;

		/// <summary>
		/// KilledInPublic
		/// </summary>
		public const short KilledInPublic = 712;

		/// <summary>
		/// KilledInPrivate
		/// </summary>
		public const short KilledInPrivate = 713;

		/// <summary>
		/// KilledAfterXiangshuInfected
		/// </summary>
		public const short KilledAfterXiangshuInfected = 714;

		/// <summary>
		/// Assassinated
		/// </summary>
		public const short Assassinated = 715;

		/// <summary>
		/// KilledByXiangshu
		/// </summary>
		public const short KilledByXiangshu = 716;

		/// <summary>
		/// PurchaseItem1
		/// </summary>
		public const short PurchaseItem1 = 717;

		/// <summary>
		/// SellItem1
		/// </summary>
		public const short SellItem1 = 718;

		/// <summary>
		/// CleanBodyReincarnationSuccess
		/// </summary>
		public const short CleanBodyReincarnationSuccess = 719;

		/// <summary>
		/// CleanBodyReincarnationFail
		/// </summary>
		public const short CleanBodyReincarnationFail = 720;

		/// <summary>
		/// EvilBodyReincarnationSuccess
		/// </summary>
		public const short EvilBodyReincarnationSuccess = 721;

		/// <summary>
		/// EvilBodyReincarnationFail
		/// </summary>
		public const short EvilBodyReincarnationFail = 722;

		/// <summary>
		/// WugKingForestSpiritBecomeEnemy
		/// </summary>
		public const short WugKingForestSpiritBecomeEnemy = 723;

		/// <summary>
		/// SecretMakeEnemy
		/// </summary>
		public const short SecretMakeEnemy = 724;

		/// <summary>
		/// SecretBeMadeEnemy
		/// </summary>
		public const short SecretBeMadeEnemy = 725;

		/// <summary>
		/// CleanBodyDefeatAnimal
		/// </summary>
		public const short CleanBodyDefeatAnimal = 726;

		/// <summary>
		/// EvilBodyDefeatAnimal
		/// </summary>
		public const short EvilBodyDefeatAnimal = 727;

		/// <summary>
		/// CleanBodyDefeatHereticRandomEnemy
		/// </summary>
		public const short CleanBodyDefeatHereticRandomEnemy = 728;

		/// <summary>
		/// EvilBodyDefeatHereticRandomEnemy
		/// </summary>
		public const short EvilBodyDefeatHereticRandomEnemy = 729;

		/// <summary>
		/// CleanBodyDefeatRighteousRandomEnemy
		/// </summary>
		public const short CleanBodyDefeatRighteousRandomEnemy = 730;

		/// <summary>
		/// EvilBodyDefeatRighteousRandomEnemy
		/// </summary>
		public const short EvilBodyDefeatRighteousRandomEnemy = 731;

		/// <summary>
		/// WuxianParanoiaAdded
		/// </summary>
		public const short WuxianParanoiaAdded = 732;

		/// <summary>
		/// WuxianParanoiaAttack
		/// </summary>
		public const short WuxianParanoiaAttack = 733;

		/// <summary>
		/// WuxianParanoiaErased
		/// </summary>
		public const short WuxianParanoiaErased = 734;

		/// <summary>
		/// WugKingRedEyeLoseItem
		/// </summary>
		public const short WugKingRedEyeLoseItem = 735;

		/// <summary>
		/// WugForestSpiritReduceFavorability
		/// </summary>
		public const short WugForestSpiritReduceFavorability = 736;

		/// <summary>
		/// WugKingForestSpiritBeBecomeEnemy
		/// </summary>
		public const short WugKingForestSpiritBeBecomeEnemy = 737;

		/// <summary>
		/// WugKingBlackBloodChangeDisorderOfQi
		/// </summary>
		public const short WugKingBlackBloodChangeDisorderOfQi = 738;

		/// <summary>
		/// WugDevilInsideXiangshuInfection
		/// </summary>
		public const short WugDevilInsideXiangshuInfection = 739;

		/// <summary>
		/// WugCorpseWormChangeHealth
		/// </summary>
		public const short WugCorpseWormChangeHealth = 740;

		/// <summary>
		/// WugKingIceSilkwormLoseNeili
		/// </summary>
		public const short WugKingIceSilkwormLoseNeili = 741;

		/// <summary>
		/// WugKingGoldenSilkwormEatGrownWug
		/// </summary>
		public const short WugKingGoldenSilkwormEatGrownWug = 742;

		/// <summary>
		/// WugAzureMarrowAddPoison
		/// </summary>
		public const short WugAzureMarrowAddPoison = 743;

		/// <summary>
		/// WugAzureMarrowAddWug
		/// </summary>
		public const short WugAzureMarrowAddWug = 744;

		/// <summary>
		/// WugAzureMarrowBeAddWug
		/// </summary>
		public const short WugAzureMarrowBeAddWug = 745;

		/// <summary>
		/// WuxianParanoiaErased2
		/// </summary>
		public const short WuxianParanoiaErased2 = 746;

		/// <summary>
		/// WuxianDecreasedMood
		/// </summary>
		public const short WuxianDecreasedMood = 747;

		/// <summary>
		/// WuxianDecreasedFavorability
		/// </summary>
		public const short WuxianDecreasedFavorability = 748;

		/// <summary>
		/// WuxianQiDecline
		/// </summary>
		public const short WuxianQiDecline = 749;

		/// <summary>
		/// WuxianPoisoning
		/// </summary>
		public const short WuxianPoisoning = 750;

		/// <summary>
		/// WuxianLoseItem
		/// </summary>
		public const short WuxianLoseItem = 751;

		/// <summary>
		/// WugDevilInsideChangeHappiness
		/// </summary>
		public const short WugDevilInsideChangeHappiness = 752;

		/// <summary>
		/// WugRedEyeChangeToGrown
		/// </summary>
		public const short WugRedEyeChangeToGrown = 753;

		/// <summary>
		/// WugForestSpiritChangeToGrown
		/// </summary>
		public const short WugForestSpiritChangeToGrown = 754;

		/// <summary>
		/// WugBlackBloodChangeToGrown
		/// </summary>
		public const short WugBlackBloodChangeToGrown = 755;

		/// <summary>
		/// WugDevilInsideChangeToGrown
		/// </summary>
		public const short WugDevilInsideChangeToGrown = 756;

		/// <summary>
		/// WugCorpseWormChangeToGrown
		/// </summary>
		public const short WugCorpseWormChangeToGrown = 757;

		/// <summary>
		/// WugCorpseWormBeChangeToGrown
		/// </summary>
		public const short WugCorpseWormBeChangeToGrown = 758;

		/// <summary>
		/// WugIceSilkwormChangeToGrown
		/// </summary>
		public const short WugIceSilkwormChangeToGrown = 759;

		/// <summary>
		/// WugGoldenSilkwormChangeToGrown
		/// </summary>
		public const short WugGoldenSilkwormChangeToGrown = 760;

		/// <summary>
		/// WugAzureMarrowChangeToGrown
		/// </summary>
		public const short WugAzureMarrowChangeToGrown = 761;

		/// <summary>
		/// WugAzureMarrowBeChangeToGrown
		/// </summary>
		public const short WugAzureMarrowBeChangeToGrown = 762;

		/// <summary>
		/// ManageLearnLifeSkillSuccess
		/// </summary>
		public const short ManageLearnLifeSkillSuccess = 763;

		/// <summary>
		/// ManageLearnCombatSkillSuccess
		/// </summary>
		public const short ManageLearnCombatSkillSuccess = 764;

		/// <summary>
		/// ManageLearnLifeSkillFail
		/// </summary>
		public const short ManageLearnLifeSkillFail = 765;

		/// <summary>
		/// ManageLearnCombatSkillFail
		/// </summary>
		public const short ManageLearnCombatSkillFail = 766;

		/// <summary>
		/// ManageLifeSkillAbilityUp
		/// </summary>
		public const short ManageLifeSkillAbilityUp = 767;

		/// <summary>
		/// ManageCombatSkillAbilityUp
		/// </summary>
		public const short ManageCombatSkillAbilityUp = 768;

		/// <summary>
		/// SmallVillagerXiangshuCompletelyInfected
		/// </summary>
		public const short SmallVillagerXiangshuCompletelyInfected = 769;

		/// <summary>
		/// SmallVillagerSavedFromInfection
		/// </summary>
		public const short SmallVillagerSavedFromInfection = 770;

		/// <summary>
		/// SmallVillagerSaveFromInfection
		/// </summary>
		public const short SmallVillagerSaveFromInfection = 771;

		/// <summary>
		/// StorageResourceToTreasury
		/// </summary>
		public const short StorageResourceToTreasury = 772;

		/// <summary>
		/// StorageItemToTreasury
		/// </summary>
		public const short StorageItemToTreasury = 773;

		/// <summary>
		/// TakeResourceFromTreasury
		/// </summary>
		public const short TakeResourceFromTreasury = 774;

		/// <summary>
		/// TakeItemFromTreasury
		/// </summary>
		public const short TakeItemFromTreasury = 775;

		/// <summary>
		/// TaiwuStorageResourceToTreasury
		/// </summary>
		public const short TaiwuStorageResourceToTreasury = 776;

		/// <summary>
		/// TaiwuStorageItemToTreasury
		/// </summary>
		public const short TaiwuStorageItemToTreasury = 777;

		/// <summary>
		/// TaiwuTakeResourceFromTreasury
		/// </summary>
		public const short TaiwuTakeResourceFromTreasury = 778;

		/// <summary>
		/// TaiwuTakeItemFromTreasury
		/// </summary>
		public const short TaiwuTakeItemFromTreasury = 779;

		/// <summary>
		/// DecideToGuardTreasury
		/// </summary>
		public const short DecideToGuardTreasury = 780;

		/// <summary>
		/// FinishGuardingTreasury
		/// </summary>
		public const short FinishGuardingTreasury = 781;

		/// <summary>
		/// IntrudeTreasuryCancelSupportMakeEnemy
		/// </summary>
		public const short IntrudeTreasuryCancelSupportMakeEnemy = 782;

		/// <summary>
		/// IntrudeTreasuryBeCancelSupportMakeEnemy
		/// </summary>
		public const short IntrudeTreasuryBeCancelSupportMakeEnemy = 783;

		/// <summary>
		/// IntrudeTreasuryCancelSupport
		/// </summary>
		public const short IntrudeTreasuryCancelSupport = 784;

		/// <summary>
		/// IntrudeTreasuryBeCancelSupport
		/// </summary>
		public const short IntrudeTreasuryBeCancelSupport = 785;

		/// <summary>
		/// IntrudeTreasuryMakeEnemyOthers
		/// </summary>
		public const short IntrudeTreasuryMakeEnemyOthers = 786;

		/// <summary>
		/// IntrudeTreasuryBeMakeEnemyOthers
		/// </summary>
		public const short IntrudeTreasuryBeMakeEnemyOthers = 787;

		/// <summary>
		/// IntrudeTreasuryLostMorale
		/// </summary>
		public const short IntrudeTreasuryLostMorale = 788;

		/// <summary>
		/// IntrudeTreasuryBeLostMorale
		/// </summary>
		public const short IntrudeTreasuryBeLostMorale = 789;

		/// <summary>
		/// IntrudeTreasuryBeLostMorale2
		/// </summary>
		public const short IntrudeTreasuryBeLostMorale2 = 790;

		/// <summary>
		/// PlunderTreasuryCancelSupportMakeEnemy
		/// </summary>
		public const short PlunderTreasuryCancelSupportMakeEnemy = 791;

		/// <summary>
		/// PlunderTreasuryBeCancelSupportMakeEnemy
		/// </summary>
		public const short PlunderTreasuryBeCancelSupportMakeEnemy = 792;

		/// <summary>
		/// PlunderTreasuryCancelSupport
		/// </summary>
		public const short PlunderTreasuryCancelSupport = 793;

		/// <summary>
		/// PlunderTreasuryBeCancelSupport
		/// </summary>
		public const short PlunderTreasuryBeCancelSupport = 794;

		/// <summary>
		/// PlunderTreasuryMakeEnemyOthers
		/// </summary>
		public const short PlunderTreasuryMakeEnemyOthers = 795;

		/// <summary>
		/// PlunderTreasuryBeMakeEnemyOthers
		/// </summary>
		public const short PlunderTreasuryBeMakeEnemyOthers = 796;

		/// <summary>
		/// PlunderTreasuryLostMorale
		/// </summary>
		public const short PlunderTreasuryLostMorale = 797;

		/// <summary>
		/// PlunderTreasuryBeLostMorale
		/// </summary>
		public const short PlunderTreasuryBeLostMorale = 798;

		/// <summary>
		/// PlunderTreasuryBeLostMorale2
		/// </summary>
		public const short PlunderTreasuryBeLostMorale2 = 799;

		/// <summary>
		/// DonateTreasuryProvideSupport
		/// </summary>
		public const short DonateTreasuryProvideSupport = 800;

		/// <summary>
		/// DonateTreasuryBeProvideSupport
		/// </summary>
		public const short DonateTreasuryBeProvideSupport = 801;

		/// <summary>
		/// DonateTreasuryGetMorale
		/// </summary>
		public const short DonateTreasuryGetMorale = 802;

		/// <summary>
		/// DonateTreasuryBeGetMorale
		/// </summary>
		public const short DonateTreasuryBeGetMorale = 803;

		/// <summary>
		/// DonateTreasuryGetMorale2
		/// </summary>
		public const short DonateTreasuryGetMorale2 = 804;

		/// <summary>
		/// TreasuryDistributeResource
		/// </summary>
		public const short TreasuryDistributeResource = 805;

		/// <summary>
		/// TreasuryDistributeItem
		/// </summary>
		public const short TreasuryDistributeItem = 806;

		/// <summary>
		/// PoisonEnemyFail12
		/// </summary>
		public const short PoisonEnemyFail12 = 807;

		/// <summary>
		/// PoisonEnemyFail22
		/// </summary>
		public const short PoisonEnemyFail22 = 808;

		/// <summary>
		/// PoisonEnemyFail32
		/// </summary>
		public const short PoisonEnemyFail32 = 809;

		/// <summary>
		/// PoisonEnemyFail42
		/// </summary>
		public const short PoisonEnemyFail42 = 810;

		/// <summary>
		/// PoisonEnemySucceed2
		/// </summary>
		public const short PoisonEnemySucceed2 = 811;

		/// <summary>
		/// PoisonEnemySucceedAndEscaped2
		/// </summary>
		public const short PoisonEnemySucceedAndEscaped2 = 812;

		/// <summary>
		/// GetPoisonedByEnemySucceed2
		/// </summary>
		public const short GetPoisonedByEnemySucceed2 = 813;

		/// <summary>
		/// PlotHarmEnemyFail12
		/// </summary>
		public const short PlotHarmEnemyFail12 = 814;

		/// <summary>
		/// PlotHarmEnemyFail22
		/// </summary>
		public const short PlotHarmEnemyFail22 = 815;

		/// <summary>
		/// PlotHarmEnemyFail32
		/// </summary>
		public const short PlotHarmEnemyFail32 = 816;

		/// <summary>
		/// PlotHarmEnemyFail42
		/// </summary>
		public const short PlotHarmEnemyFail42 = 817;

		/// <summary>
		/// PlotHarmEnemySucceed2
		/// </summary>
		public const short PlotHarmEnemySucceed2 = 818;

		/// <summary>
		/// PlotHarmEnemySucceedAndEscaped2
		/// </summary>
		public const short PlotHarmEnemySucceedAndEscaped2 = 819;

		/// <summary>
		/// GetPlottedAgainstSucceed2
		/// </summary>
		public const short GetPlottedAgainstSucceed2 = 820;

		/// <summary>
		/// SectMainStoryBaihuaManiaLow
		/// </summary>
		public const short SectMainStoryBaihuaManiaLow = 821;

		/// <summary>
		/// SectMainStoryBaihuaManiaHigh
		/// </summary>
		public const short SectMainStoryBaihuaManiaHigh = 822;

		/// <summary>
		/// SectMainStoryBaihuaManiaAttack
		/// </summary>
		public const short SectMainStoryBaihuaManiaAttack = 823;

		/// <summary>
		/// SectMainStoryBaihuaManiaAttacked
		/// </summary>
		public const short SectMainStoryBaihuaManiaAttacked = 824;

		/// <summary>
		/// SectMainStoryBaihuaManiaCure
		/// </summary>
		public const short SectMainStoryBaihuaManiaCure = 825;

		/// <summary>
		/// SectMainStoryBaihuaManiaCured
		/// </summary>
		public const short SectMainStoryBaihuaManiaCured = 826;

		/// <summary>
		/// GiveUpLegendaryBookSuccessHuaJu
		/// </summary>
		public const short GiveUpLegendaryBookSuccessHuaJu = 827;

		/// <summary>
		/// GiveUpLegendaryBookSuccessXuanZhi
		/// </summary>
		public const short GiveUpLegendaryBookSuccessXuanZhi = 828;

		/// <summary>
		/// GiveUpLegendaryBookSuccessYingJiao
		/// </summary>
		public const short GiveUpLegendaryBookSuccessYingJiao = 829;

		/// <summary>
		/// SecretMakeEnemy2
		/// </summary>
		public const short SecretMakeEnemy2 = 830;

		/// <summary>
		/// SecretBeMadeEnemy2
		/// </summary>
		public const short SecretBeMadeEnemy2 = 831;

		/// <summary>
		/// DecideToHuntFugitive
		/// </summary>
		public const short DecideToHuntFugitive = 832;

		/// <summary>
		/// FinishHuntFugitive
		/// </summary>
		public const short FinishHuntFugitive = 833;

		/// <summary>
		/// DecideToEscapePunishment
		/// </summary>
		public const short DecideToEscapePunishment = 834;

		/// <summary>
		/// FinishEscapePunishment
		/// </summary>
		public const short FinishEscapePunishment = 835;

		/// <summary>
		/// DecideToSeekAsylum
		/// </summary>
		public const short DecideToSeekAsylum = 836;

		/// <summary>
		/// FinishSeekAsylum
		/// </summary>
		public const short FinishSeekAsylum = 837;

		/// <summary>
		/// SeekAsylumSuccess
		/// </summary>
		public const short SeekAsylumSuccess = 838;

		/// <summary>
		/// DecideToEscortPrisoner
		/// </summary>
		public const short DecideToEscortPrisoner = 839;

		/// <summary>
		/// EscortPrisonerSucceed
		/// </summary>
		public const short EscortPrisonerSucceed = 840;

		/// <summary>
		/// ImprisonedShaoLin
		/// </summary>
		public const short ImprisonedShaoLin = 841;

		/// <summary>
		/// ImprisonedEmei1
		/// </summary>
		public const short ImprisonedEmei1 = 842;

		/// <summary>
		/// ImprisonedEmei2
		/// </summary>
		public const short ImprisonedEmei2 = 843;

		/// <summary>
		/// ImprisonedBaihua
		/// </summary>
		public const short ImprisonedBaihua = 844;

		/// <summary>
		/// ImprisonedWudang
		/// </summary>
		public const short ImprisonedWudang = 845;

		/// <summary>
		/// ImprisonedYuanshan
		/// </summary>
		public const short ImprisonedYuanshan = 846;

		/// <summary>
		/// ImprisonedShingXiang
		/// </summary>
		public const short ImprisonedShingXiang = 847;

		/// <summary>
		/// ImprisonedRanShan
		/// </summary>
		public const short ImprisonedRanShan = 848;

		/// <summary>
		/// ImprisonedXuanNv
		/// </summary>
		public const short ImprisonedXuanNv = 849;

		/// <summary>
		/// ImprisonedZhuJian
		/// </summary>
		public const short ImprisonedZhuJian = 850;

		/// <summary>
		/// ImprisonedKongSang
		/// </summary>
		public const short ImprisonedKongSang = 851;

		/// <summary>
		/// ImprisonedJinGang
		/// </summary>
		public const short ImprisonedJinGang = 852;

		/// <summary>
		/// ImprisonedWuXian
		/// </summary>
		public const short ImprisonedWuXian = 853;

		/// <summary>
		/// ImprisonedJieQing1
		/// </summary>
		public const short ImprisonedJieQing1 = 854;

		/// <summary>
		/// ImprisonedJieQing2
		/// </summary>
		public const short ImprisonedJieQing2 = 855;

		/// <summary>
		/// ImprisonedFuLong
		/// </summary>
		public const short ImprisonedFuLong = 856;

		/// <summary>
		/// ImprisonedXueHou
		/// </summary>
		public const short ImprisonedXueHou = 857;

		/// <summary>
		/// IntrudePrisonCancelSupportMakeEnemyNpc
		/// </summary>
		public const short IntrudePrisonCancelSupportMakeEnemyNpc = 858;

		/// <summary>
		/// IntrudePrisonCancelSupportMakeEnemyTaiwu
		/// </summary>
		public const short IntrudePrisonCancelSupportMakeEnemyTaiwu = 859;

		/// <summary>
		/// IntrudePrisonCancelSupportNpc
		/// </summary>
		public const short IntrudePrisonCancelSupportNpc = 860;

		/// <summary>
		/// IntrudePrisonCancelSupportTaiwu
		/// </summary>
		public const short IntrudePrisonCancelSupportTaiwu = 861;

		/// <summary>
		/// IntrudePrisonMakeEnemyOthersNpc
		/// </summary>
		public const short IntrudePrisonMakeEnemyOthersNpc = 862;

		/// <summary>
		/// IntrudePrisonMakeEnemyOthersTaiwu
		/// </summary>
		public const short IntrudePrisonMakeEnemyOthersTaiwu = 863;

		/// <summary>
		/// RequestTheReleaseOfTheCriminalNpc
		/// </summary>
		public const short RequestTheReleaseOfTheCriminalNpc = 864;

		/// <summary>
		/// RequestTheReleaseOfTheCriminalTaiwu
		/// </summary>
		public const short RequestTheReleaseOfTheCriminalTaiwu = 865;

		/// <summary>
		/// ImprisonedXiangshuInfectedSupportIncreaseAndFavorabilityNpc
		/// </summary>
		public const short ImprisonedXiangshuInfectedSupportIncreaseAndFavorabilityNpc = 866;

		/// <summary>
		/// ImprisonedXiangshuInfectedSupportIncreaseAndFavorabilityTaiwu
		/// </summary>
		public const short ImprisonedXiangshuInfectedSupportIncreaseAndFavorabilityTaiwu = 867;

		/// <summary>
		/// ImprisonedXiangshuInfectedIncreaseFavorabilityNpc
		/// </summary>
		public const short ImprisonedXiangshuInfectedIncreaseFavorabilityNpc = 868;

		/// <summary>
		/// ImprisonedXiangshuInfectedIncreaseFavorabilityTaiwu
		/// </summary>
		public const short ImprisonedXiangshuInfectedIncreaseFavorabilityTaiwu = 869;

		/// <summary>
		/// ImprisonedXiangshuInfectedNpc
		/// </summary>
		public const short ImprisonedXiangshuInfectedNpc = 870;

		/// <summary>
		/// ImprisonedXiangshuInfectedTaiwu
		/// </summary>
		public const short ImprisonedXiangshuInfectedTaiwu = 871;

		/// <summary>
		/// RobbedFromPrisonNpc
		/// </summary>
		public const short RobbedFromPrisonNpc = 872;

		/// <summary>
		/// PrisonBreakIntrudePrisonCancelSupportMakeEnemyNpc
		/// </summary>
		public const short PrisonBreakIntrudePrisonCancelSupportMakeEnemyNpc = 873;

		/// <summary>
		/// PrisonBreakIntrudePrisonCancelSupportMakeEnemyTaiwu
		/// </summary>
		public const short PrisonBreakIntrudePrisonCancelSupportMakeEnemyTaiwu = 874;

		/// <summary>
		/// PrisonBreakIntrudePrisonCancelSupportNpc
		/// </summary>
		public const short PrisonBreakIntrudePrisonCancelSupportNpc = 875;

		/// <summary>
		/// PrisonBreakIntrudePrisonCancelSupportTaiwu
		/// </summary>
		public const short PrisonBreakIntrudePrisonCancelSupportTaiwu = 876;

		/// <summary>
		/// PrisonBreakIntrudePrisonMakeEnemyOthersNpc
		/// </summary>
		public const short PrisonBreakIntrudePrisonMakeEnemyOthersNpc = 877;

		/// <summary>
		/// PrisonBreakIntrudePrisonMakeEnemyOthersTaiwu
		/// </summary>
		public const short PrisonBreakIntrudePrisonMakeEnemyOthersTaiwu = 878;

		/// <summary>
		/// ResistArrestIntrudePrisonCancelSupportMakeEnemyNpc
		/// </summary>
		public const short ResistArrestIntrudePrisonCancelSupportMakeEnemyNpc = 879;

		/// <summary>
		/// ResistArresPrisonBreakIntrudePrisonCancelSupportMakeEnemyTaiwu
		/// </summary>
		public const short ResistArresPrisonBreakIntrudePrisonCancelSupportMakeEnemyTaiwu = 880;

		/// <summary>
		/// ResistArresPrisonBreakIntrudePrisonCancelSupportNpc
		/// </summary>
		public const short ResistArresPrisonBreakIntrudePrisonCancelSupportNpc = 881;

		/// <summary>
		/// ResistArresPrisonBreakIntrudePrisonCancelSupportTaiwu
		/// </summary>
		public const short ResistArresPrisonBreakIntrudePrisonCancelSupportTaiwu = 882;

		/// <summary>
		/// ResistArresPrisonBreakIntrudePrisonMakeEnemyOthersNpc
		/// </summary>
		public const short ResistArresPrisonBreakIntrudePrisonMakeEnemyOthersNpc = 883;

		/// <summary>
		/// ResistArresPrisonBreakIntrudePrisonMakeEnemyOthersTaiwu
		/// </summary>
		public const short ResistArresPrisonBreakIntrudePrisonMakeEnemyOthersTaiwu = 884;

		/// <summary>
		/// ArrestFailedCaptor
		/// </summary>
		public const short ArrestFailedCaptor = 885;

		/// <summary>
		/// ArrestFailedCriminal
		/// </summary>
		public const short ArrestFailedCriminal = 886;

		/// <summary>
		/// ResistArresEngageInBattleTaiwu
		/// </summary>
		public const short ResistArresEngageInBattleTaiwu = 887;

		/// <summary>
		/// ArrestedSuccessfullyCaptor
		/// </summary>
		public const short ArrestedSuccessfullyCaptor = 888;

		/// <summary>
		/// ArrestedSuccessfullyCriminal
		/// </summary>
		public const short ArrestedSuccessfullyCriminal = 889;

		/// <summary>
		/// ReceiveCriminalsCaptor
		/// </summary>
		public const short ReceiveCriminalsCaptor = 890;

		/// <summary>
		/// ReceiveCriminalsTaiwu
		/// </summary>
		public const short ReceiveCriminalsTaiwu = 891;

		/// <summary>
		/// ReceiveCriminalsCriminal
		/// </summary>
		public const short ReceiveCriminalsCriminal = 892;

		/// <summary>
		/// BuyHandOverTheCriminalCaptor
		/// </summary>
		public const short BuyHandOverTheCriminalCaptor = 893;

		/// <summary>
		/// BuyHandOverTheCriminalTaiwu
		/// </summary>
		public const short BuyHandOverTheCriminalTaiwu = 894;

		/// <summary>
		/// LifeSkillBattleHandOverTheCriminalCaptor
		/// </summary>
		public const short LifeSkillBattleHandOverTheCriminalCaptor = 895;

		/// <summary>
		/// LifeSkillBattleHandOverTheCriminalTaiwu
		/// </summary>
		public const short LifeSkillBattleHandOverTheCriminalTaiwu = 896;

		/// <summary>
		/// LifeSkillBattleLoseHandOverTheCriminalCaptor
		/// </summary>
		public const short LifeSkillBattleLoseHandOverTheCriminalCaptor = 897;

		/// <summary>
		/// LifeSkillBattleLoseHandOverTheCriminalTaiwu
		/// </summary>
		public const short LifeSkillBattleLoseHandOverTheCriminalTaiwu = 898;

		/// <summary>
		/// VictoryInCombatHandOverTheCriminalCaptor
		/// </summary>
		public const short VictoryInCombatHandOverTheCriminalCaptor = 899;

		/// <summary>
		/// VictoryInCombatHandOverTheCriminalTaiwu
		/// </summary>
		public const short VictoryInCombatHandOverTheCriminalTaiwu = 900;

		/// <summary>
		/// FailureInCombatHandOverTheCriminalCaptor
		/// </summary>
		public const short FailureInCombatHandOverTheCriminalCaptor = 901;

		/// <summary>
		/// FailureInCombatHandOverTheCriminalTaiwu
		/// </summary>
		public const short FailureInCombatHandOverTheCriminalTaiwu = 902;

		/// <summary>
		/// SectMainStoryFulongFightSucceed
		/// </summary>
		public const short SectMainStoryFulongFightSucceed = 903;

		/// <summary>
		/// SectMainStoryFulongFightFail
		/// </summary>
		public const short SectMainStoryFulongFightFail = 904;

		/// <summary>
		/// SectMainStoryFulongRobbery
		/// </summary>
		public const short SectMainStoryFulongRobbery = 905;

		/// <summary>
		/// SectMainStoryFulongRobberKilledByTaiwu
		/// </summary>
		public const short SectMainStoryFulongRobberKilledByTaiwu = 906;

		/// <summary>
		/// SectMainStoryFulongProtect
		/// </summary>
		public const short SectMainStoryFulongProtect = 907;

		/// <summary>
		/// HonestSectPunishLevel1
		/// </summary>
		public const short HonestSectPunishLevel1 = 908;

		/// <summary>
		/// HonestSectPunishLevel2
		/// </summary>
		public const short HonestSectPunishLevel2 = 909;

		/// <summary>
		/// HonestSectPunishLevel3
		/// </summary>
		public const short HonestSectPunishLevel3 = 910;

		/// <summary>
		/// HonestSectPunishLevel4
		/// </summary>
		public const short HonestSectPunishLevel4 = 911;

		/// <summary>
		/// HonestSectPunishLevel5
		/// </summary>
		public const short HonestSectPunishLevel5 = 912;

		/// <summary>
		/// HonestSectPunishTogetherWithSpouseLevel5
		/// </summary>
		public const short HonestSectPunishTogetherWithSpouseLevel5 = 913;

		/// <summary>
		/// ArrestedSectPunishLevel1
		/// </summary>
		public const short ArrestedSectPunishLevel1 = 914;

		/// <summary>
		/// ArrestedSectPunishLevel2
		/// </summary>
		public const short ArrestedSectPunishLevel2 = 915;

		/// <summary>
		/// ArrestedSectPunishLevel3
		/// </summary>
		public const short ArrestedSectPunishLevel3 = 916;

		/// <summary>
		/// ArrestedSectPunishLevel4
		/// </summary>
		public const short ArrestedSectPunishLevel4 = 917;

		/// <summary>
		/// ArrestedSectPunishLevel5
		/// </summary>
		public const short ArrestedSectPunishLevel5 = 918;

		/// <summary>
		/// ArrestedSectPunishTogetherWithSpouseLevel5
		/// </summary>
		public const short ArrestedSectPunishTogetherWithSpouseLevel5 = 919;

		/// <summary>
		/// BeImplicatedSectPunishLevel5
		/// </summary>
		public const short BeImplicatedSectPunishLevel5 = 920;

		/// <summary>
		/// BeReleasedUponCompletionOfASentence
		/// </summary>
		public const short BeReleasedUponCompletionOfASentence = 921;

		/// <summary>
		/// PrisonBreak
		/// </summary>
		public const short PrisonBreak = 922;

		/// <summary>
		/// SendingToPrison1Taiwu
		/// </summary>
		public const short SendingToPrison1Taiwu = 923;

		/// <summary>
		/// SendingToPrison2Taiwu
		/// </summary>
		public const short SendingToPrison2Taiwu = 924;

		/// <summary>
		/// SendingToPrisonCriminal
		/// </summary>
		public const short SendingToPrisonCriminal = 925;

		/// <summary>
		/// SentToPrisonTaiwu
		/// </summary>
		public const short SentToPrisonTaiwu = 926;

		/// <summary>
		/// SentToPrisonCriminal
		/// </summary>
		public const short SentToPrisonCriminal = 927;

		/// <summary>
		/// CatchCriminalsWinTaiwu
		/// </summary>
		public const short CatchCriminalsWinTaiwu = 928;

		/// <summary>
		/// CatchCriminalsWinCriminal
		/// </summary>
		public const short CatchCriminalsWinCriminal = 929;

		/// <summary>
		/// CatchCriminalsFailedTaiwu
		/// </summary>
		public const short CatchCriminalsFailedTaiwu = 930;

		/// <summary>
		/// CatchCriminalsFailedCriminal
		/// </summary>
		public const short CatchCriminalsFailedCriminal = 931;

		/// <summary>
		/// BuyHandOverTheCriminalCaptorByExp
		/// </summary>
		public const short BuyHandOverTheCriminalCaptorByExp = 932;

		/// <summary>
		/// BuyHandOverTheCriminalTaiwuByExp
		/// </summary>
		public const short BuyHandOverTheCriminalTaiwuByExp = 933;

		/// <summary>
		/// SendingToPrison1TaiwuByExp
		/// </summary>
		public const short SendingToPrison1TaiwuByExp = 934;

		/// <summary>
		/// VillagerMigrateResources
		/// </summary>
		public const short VillagerMigrateResources = 935;

		/// <summary>
		/// VillagerCookingIngredient
		/// </summary>
		public const short VillagerCookingIngredient = 936;

		/// <summary>
		/// VillagerMakingItem
		/// </summary>
		public const short VillagerMakingItem = 937;

		/// <summary>
		/// VillagerRepairItem0
		/// </summary>
		public const short VillagerRepairItem0 = 938;

		/// <summary>
		/// VillagerRepairItem1
		/// </summary>
		public const short VillagerRepairItem1 = 939;

		/// <summary>
		/// VillagerDisassembleItem0
		/// </summary>
		public const short VillagerDisassembleItem0 = 940;

		/// <summary>
		/// VillagerDisassembleItem1
		/// </summary>
		public const short VillagerDisassembleItem1 = 941;

		/// <summary>
		/// VillagerRefiningMedicine
		/// </summary>
		public const short VillagerRefiningMedicine = 942;

		/// <summary>
		/// VillagerDetoxify0
		/// </summary>
		public const short VillagerDetoxify0 = 943;

		/// <summary>
		/// VillagerDetoxify1
		/// </summary>
		public const short VillagerDetoxify1 = 944;

		/// <summary>
		/// VillagerEnvenomedItem
		/// </summary>
		public const short VillagerEnvenomedItem = 945;

		/// <summary>
		/// VillagerSoldItem
		/// </summary>
		public const short VillagerSoldItem = 946;

		/// <summary>
		/// VillagerBuyItem
		/// </summary>
		public const short VillagerBuyItem = 947;

		/// <summary>
		/// VillagerSeverEnemy
		/// </summary>
		public const short VillagerSeverEnemy = 948;

		/// <summary>
		/// VillagerEmotionUp
		/// </summary>
		public const short VillagerEmotionUp = 949;

		/// <summary>
		/// VillagerMakeFriends
		/// </summary>
		public const short VillagerMakeFriends = 950;

		/// <summary>
		/// VillagerGetMarried
		/// </summary>
		public const short VillagerGetMarried = 951;

		/// <summary>
		/// VillagerBecomeBrothers
		/// </summary>
		public const short VillagerBecomeBrothers = 952;

		/// <summary>
		/// VillagerAdopt
		/// </summary>
		public const short VillagerAdopt = 953;

		/// <summary>
		/// VillagerTreatment0
		/// </summary>
		public const short VillagerTreatment0 = 954;

		/// <summary>
		/// VillagerTreatment1
		/// </summary>
		public const short VillagerTreatment1 = 955;

		/// <summary>
		/// VillagerBeTreatment0
		/// </summary>
		public const short VillagerBeTreatment0 = 956;

		/// <summary>
		/// VillagerBeTreatment1
		/// </summary>
		public const short VillagerBeTreatment1 = 957;

		/// <summary>
		/// XiangshuInfectedPrisonTaiwuVillage
		/// </summary>
		public const short XiangshuInfectedPrisonTaiwuVillage = 958;

		/// <summary>
		/// XiangshuInfectedPrisonSettlement
		/// </summary>
		public const short XiangshuInfectedPrisonSettlement = 959;

		/// <summary>
		/// VillagerBeRepairItem1
		/// </summary>
		public const short VillagerBeRepairItem1 = 960;

		/// <summary>
		/// TaiwuVillagerTakeItem
		/// </summary>
		public const short TaiwuVillagerTakeItem = 961;

		/// <summary>
		/// TaiwuVillagerStorageItem
		/// </summary>
		public const short TaiwuVillagerStorageItem = 962;

		/// <summary>
		/// TaiwuVillagerStorageResources
		/// </summary>
		public const short TaiwuVillagerStorageResources = 963;

		/// <summary>
		/// TaiwuVillagerTakeResources
		/// </summary>
		public const short TaiwuVillagerTakeResources = 964;

		/// <summary>
		/// LiteratiEntertainingUp
		/// </summary>
		public const short LiteratiEntertainingUp = 965;

		/// <summary>
		/// LiteratiEntertainingDown
		/// </summary>
		public const short LiteratiEntertainingDown = 966;

		/// <summary>
		/// LiteratiBuildingRelationshipUp
		/// </summary>
		public const short LiteratiBuildingRelationshipUp = 967;

		/// <summary>
		/// LiteratiBuildingRelationshipDown
		/// </summary>
		public const short LiteratiBuildingRelationshipDown = 968;

		/// <summary>
		/// LiteratiSpreadingInfluenceUp
		/// </summary>
		public const short LiteratiSpreadingInfluenceUp = 969;

		/// <summary>
		/// LiteratiSpreadingInfluenceDown
		/// </summary>
		public const short LiteratiSpreadingInfluenceDown = 970;

		/// <summary>
		/// SwordTombKeeperBuildingRelationshipUp
		/// </summary>
		public const short SwordTombKeeperBuildingRelationshipUp = 971;

		/// <summary>
		/// SwordTombKeeperBuildingRelationshipDown
		/// </summary>
		public const short SwordTombKeeperBuildingRelationshipDown = 972;

		/// <summary>
		/// SwordTombKeeperSpreadingInfluenceUp
		/// </summary>
		public const short SwordTombKeeperSpreadingInfluenceUp = 973;

		/// <summary>
		/// SwordTombKeeperSpreadingInfluenceDown
		/// </summary>
		public const short SwordTombKeeperSpreadingInfluenceDown = 974;

		/// <summary>
		/// InquireSwordTomb
		/// </summary>
		public const short InquireSwordTomb = 975;

		/// <summary>
		/// GuardingSwordTomb
		/// </summary>
		public const short GuardingSwordTomb = 976;

		/// <summary>
		/// VillagerPrioritizedActions
		/// </summary>
		public const short VillagerPrioritizedActions = 977;

		/// <summary>
		/// VillagerPrioritizedActionsStop
		/// </summary>
		public const short VillagerPrioritizedActionsStop = 978;

		/// <summary>
		/// EnvenomedItemOverload
		/// </summary>
		public const short EnvenomedItemOverload = 979;

		/// <summary>
		/// DetoxifyItemOverload
		/// </summary>
		public const short DetoxifyItemOverload = 980;

		/// <summary>
		/// VillagerEnvenomedItemOverload
		/// </summary>
		public const short VillagerEnvenomedItemOverload = 981;

		/// <summary>
		/// VillagerDetoxifyItemOverload
		/// </summary>
		public const short VillagerDetoxifyItemOverload = 982;

		/// <summary>
		/// VillagerCookingIngredientFailed0
		/// </summary>
		public const short VillagerCookingIngredientFailed0 = 983;

		/// <summary>
		/// VillagerCookingIngredientFailed1
		/// </summary>
		public const short VillagerCookingIngredientFailed1 = 984;

		/// <summary>
		/// VillagerMakingItemFailed0
		/// </summary>
		public const short VillagerMakingItemFailed0 = 985;

		/// <summary>
		/// VillagerMakingItemFailed1
		/// </summary>
		public const short VillagerMakingItemFailed1 = 986;

		/// <summary>
		/// VillagerRepairFailed
		/// </summary>
		public const short VillagerRepairFailed = 987;

		/// <summary>
		/// VillagerDisassembleItemFailed
		/// </summary>
		public const short VillagerDisassembleItemFailed = 988;

		/// <summary>
		/// VillagerRefiningMedicineFailed0
		/// </summary>
		public const short VillagerRefiningMedicineFailed0 = 989;

		/// <summary>
		/// VillagerRefiningMedicineFailed1
		/// </summary>
		public const short VillagerRefiningMedicineFailed1 = 990;

		/// <summary>
		/// VillagerAddPoisonToItemFailed
		/// </summary>
		public const short VillagerAddPoisonToItemFailed = 991;

		/// <summary>
		/// VillagerDetoxItemFailed
		/// </summary>
		public const short VillagerDetoxItemFailed = 992;

		/// <summary>
		/// VillagerDistanceFailed0
		/// </summary>
		public const short VillagerDistanceFailed0 = 993;

		/// <summary>
		/// VillagerDistanceFailed1
		/// </summary>
		public const short VillagerDistanceFailed1 = 994;

		/// <summary>
		/// VillagerDistanceFailed2
		/// </summary>
		public const short VillagerDistanceFailed2 = 995;

		/// <summary>
		/// VillagerAttainmentsFailed
		/// </summary>
		public const short VillagerAttainmentsFailed = 996;

		/// <summary>
		/// TaiwuPunishmentTongyong
		/// </summary>
		public const short TaiwuPunishmentTongyong = 997;

		/// <summary>
		/// TaiwuPunishmentShaolin
		/// </summary>
		public const short TaiwuPunishmentShaolin = 998;

		/// <summary>
		/// TaiwuPunishmentEmei
		/// </summary>
		public const short TaiwuPunishmentEmei = 999;

		/// <summary>
		/// TaiwuPunishmentBaihua
		/// </summary>
		public const short TaiwuPunishmentBaihua = 1000;

		/// <summary>
		/// TaiwuPunishmentWudang
		/// </summary>
		public const short TaiwuPunishmentWudang = 1001;

		/// <summary>
		/// TaiwuPunishmentYuanshan
		/// </summary>
		public const short TaiwuPunishmentYuanshan = 1002;

		/// <summary>
		/// TaiwuPunishmentShingXiang
		/// </summary>
		public const short TaiwuPunishmentShingXiang = 1003;

		/// <summary>
		/// TaiwuPunishmentRanShan
		/// </summary>
		public const short TaiwuPunishmentRanShan = 1004;

		/// <summary>
		/// TaiwuPunishmentXuanNv
		/// </summary>
		public const short TaiwuPunishmentXuanNv = 1005;

		/// <summary>
		/// TaiwuPunishmentZhuJian
		/// </summary>
		public const short TaiwuPunishmentZhuJian = 1006;

		/// <summary>
		/// TaiwuPunishmentKongSang
		/// </summary>
		public const short TaiwuPunishmentKongSang = 1007;

		/// <summary>
		/// TaiwuPunishmentJinGang
		/// </summary>
		public const short TaiwuPunishmentJinGang = 1008;

		/// <summary>
		/// TaiwuPunishmentWuXian
		/// </summary>
		public const short TaiwuPunishmentWuXian = 1009;

		/// <summary>
		/// TaiwuPunishmentJieQing
		/// </summary>
		public const short TaiwuPunishmentJieQing = 1010;

		/// <summary>
		/// TaiwuPunishmentFuLong
		/// </summary>
		public const short TaiwuPunishmentFuLong = 1011;

		/// <summary>
		/// TaiwuPunishmentXueHou
		/// </summary>
		public const short TaiwuPunishmentXueHou = 1012;

		/// <summary>
		/// SectPunishLevel5Expel
		/// </summary>
		public const short SectPunishLevel5Expel = 1013;

		/// <summary>
		/// BeImplicatedSectPunishLevel5New
		/// </summary>
		public const short BeImplicatedSectPunishLevel5New = 1014;

		/// <summary>
		/// BeImplicatedSectPunishLevel5Expel
		/// </summary>
		public const short BeImplicatedSectPunishLevel5Expel = 1015;

		/// <summary>
		/// ResistArrestIntrudePrisonCancelSupportMakeEnemyNpcGuard
		/// </summary>
		public const short ResistArrestIntrudePrisonCancelSupportMakeEnemyNpcGuard = 1016;

		/// <summary>
		/// ResistArresPrisonBreakIntrudePrisonCancelSupportMakeEnemyTaiwuWanted
		/// </summary>
		public const short ResistArresPrisonBreakIntrudePrisonCancelSupportMakeEnemyTaiwuWanted = 1017;

		/// <summary>
		/// ResistArresPrisonBreakIntrudePrisonCancelSupportNpcGuard
		/// </summary>
		public const short ResistArresPrisonBreakIntrudePrisonCancelSupportNpcGuard = 1018;

		/// <summary>
		/// ResistArresPrisonBreakIntrudePrisonCancelSupportTaiwuWanted
		/// </summary>
		public const short ResistArresPrisonBreakIntrudePrisonCancelSupportTaiwuWanted = 1019;

		/// <summary>
		/// ResistArresPrisonBreakIntrudePrisonMakeEnemyOthersNpcGuard
		/// </summary>
		public const short ResistArresPrisonBreakIntrudePrisonMakeEnemyOthersNpcGuard = 1020;

		/// <summary>
		/// ResistArresPrisonBreakIntrudePrisonMakeEnemyOthersTaiwuWanted
		/// </summary>
		public const short ResistArresPrisonBreakIntrudePrisonMakeEnemyOthersTaiwuWanted = 1021;

		/// <summary>
		/// CivilianSkillForgive
		/// </summary>
		public const short ForgiveForCivilianSkill = 1022;

		/// <summary>
		/// BeggarEatSomeoneFood
		/// </summary>
		public const short BeggarEatSomeoneFood = 1023;

		/// <summary>
		/// SomeoneFoodEatedByBeggar
		/// </summary>
		public const short SomeoneFoodEatedByBeggar = 1024;

		/// <summary>
		/// AristocratReleasePrisoner
		/// </summary>
		public const short AristocratReleasePrisoner = 1025;

		/// <summary>
		/// PrisonerBeReleaseByAristocrat
		/// </summary>
		public const short PrisonerBeReleaseByAristocrat = 1026;

		/// <summary>
		/// JieQingPunishmentAssassinSetOut
		/// </summary>
		public const short JieQingPunishmentAssassinSetOut = 1027;

		/// <summary>
		/// JieQingPunishmentAssassinSucceed
		/// </summary>
		public const short JieQingPunishmentAssassinSucceed = 1028;

		/// <summary>
		/// JieQingPunishmentAssassinBeSucceed
		/// </summary>
		public const short JieQingPunishmentAssassinBeSucceed = 1029;

		/// <summary>
		/// JieQingPunishmentAssassinFailed
		/// </summary>
		public const short JieQingPunishmentAssassinFailed = 1030;

		/// <summary>
		/// JieQingPunishmentAssassinBeFailed
		/// </summary>
		public const short JieQingPunishmentAssassinBeFailed = 1031;

		/// <summary>
		/// JieQingPunishmentAssassinGiveUp
		/// </summary>
		public const short JieQingPunishmentAssassinGiveUp = 1032;

		/// <summary>
		/// ExociseXiangshuInfectionVictoryInCombatDie
		/// </summary>
		public const short ExociseXiangshuInfectionVictoryInCombatDie = 1033;

		/// <summary>
		/// BecomeExociseXiangshuInfectionVictoryInCombatDie
		/// </summary>
		public const short BecomeExociseXiangshuInfectionVictoryInCombatDie = 1034;

		/// <summary>
		/// ArrestFailedTaiwu
		/// </summary>
		public const short ArrestFailedTaiwu = 1035;

		/// <summary>
		/// ArrestedSuccessfullyTaiwu
		/// </summary>
		public const short ArrestedSuccessfullyTaiwu = 1036;

		/// <summary>
		/// LifeSkillBattleLoseAndTheArrestFailedCaptor
		/// </summary>
		public const short LifeSkillBattleLoseAndTheArrestFailedCaptor = 1037;

		/// <summary>
		/// LifeSkillBattleWinAndAvoidArrestTaiwu
		/// </summary>
		public const short LifeSkillBattleWinAndAvoidArrestTaiwu = 1038;

		/// <summary>
		/// LifeSkillBattleWinAndSuccessfulArrestCaptor
		/// </summary>
		public const short LifeSkillBattleWinAndSuccessfulArrestCaptor = 1039;

		/// <summary>
		/// LifeSkillBattleLoseAndWasArrestedTaiwu
		/// </summary>
		public const short LifeSkillBattleLoseAndWasArrestedTaiwu = 1040;

		/// <summary>
		/// FailedArrestForBriberyCaptorByAuthority
		/// </summary>
		public const short FailedArrestForBriberyCaptorByAuthority = 1041;

		/// <summary>
		/// BribeSucceededInAvoidingArrestTaiwuByAuthority
		/// </summary>
		public const short BribeSucceededInAvoidingArrestTaiwuByAuthority = 1042;

		/// <summary>
		/// FailedArrestForBriberyCaptorByExp
		/// </summary>
		public const short FailedArrestForBriberyCaptorByExp = 1043;

		/// <summary>
		/// BribeSucceededInAvoidingArrestTaiwuByExp
		/// </summary>
		public const short BribeSucceededInAvoidingArrestTaiwuByExp = 1044;

		/// <summary>
		/// FailedArrestForBriberyCaptorByMoney
		/// </summary>
		public const short FailedArrestForBriberyCaptorByMoney = 1045;

		/// <summary>
		/// BribeSucceededInAvoidingArrestTaiwuByMoney
		/// </summary>
		public const short BribeSucceededInAvoidingArrestTaiwuByMoney = 1046;

		/// <summary>
		/// SubmitToCaptureMeeklyTaiwu
		/// </summary>
		public const short SubmitToCaptureMeeklyTaiwu = 1047;

		/// <summary>
		/// SubmitToCaptureMeeklyCaptor
		/// </summary>
		public const short SubmitToCaptureMeeklyCaptor = 1048;

		/// <summary>
		/// NormalInformationChangeProfession
		/// </summary>
		public const short NormalInformationChangeProfession = 1049;

		/// <summary>
		/// FeedTheAnimal
		/// </summary>
		public const short FeedTheAnimal = 1050;

		/// <summary>
		/// ProfessionDoctorLifeTransition
		/// </summary>
		public const short ProfessionDoctorLifeTransition = 1051;

		/// <summary>
		/// ProfessionDoctorLifeTransitionTaiwu
		/// </summary>
		public const short ProfessionDoctorLifeTransitionTaiwu = 1052;

		/// <summary>
		/// CombatSkillKeyPointComprehensionByExp
		/// </summary>
		public const short CombatSkillKeyPointComprehensionByExp = 1053;

		/// <summary>
		/// CombatSkillKeyPointComprehensionByItems
		/// </summary>
		public const short CombatSkillKeyPointComprehensionByItems = 1054;

		/// <summary>
		/// CombatSkillKeyPointComprehensionByLoveRelationship
		/// </summary>
		public const short CombatSkillKeyPointComprehensionByLoveRelationship = 1055;

		/// <summary>
		/// CombatSkillKeyPointComprehensionByHatredRelationship
		/// </summary>
		public const short CombatSkillKeyPointComprehensionByHatredRelationship = 1056;

		/// <summary>
		/// SpiritualDebtKongsangPoisoned
		/// </summary>
		public const short SpiritualDebtKongsangPoisoned = 1057;

		/// <summary>
		/// MartialArtistSkill3NPCItemDropCaseA
		/// </summary>
		public const short MartialArtistSkill3NPCItemDropCaseA = 1058;

		/// <summary>
		/// MartialArtistSkill3NPCItemDropCaseB
		/// </summary>
		public const short MartialArtistSkill3NPCItemDropCaseB = 1059;

		/// <summary>
		/// SectPunishElopeSucceedJust
		/// </summary>
		public const short SectPunishElopeSucceedJust = 1060;

		/// <summary>
		/// SectPunishElopeSucceedKind
		/// </summary>
		public const short SectPunishElopeSucceedKind = 1061;

		/// <summary>
		/// SectPunishElopeSucceedEven
		/// </summary>
		public const short SectPunishElopeSucceedEven = 1062;

		/// <summary>
		/// SectPunishElopeSucceed
		/// </summary>
		public const short SectPunishElopeSucceed = 1063;

		/// <summary>
		/// VillagerGetRefineItem
		/// </summary>
		public const short VillagerGetRefineItem = 1064;

		/// <summary>
		/// VillagerUpgradeRefineItem
		/// </summary>
		public const short VillagerUpgradeRefineItem = 1065;

		/// <summary>
		/// VillagerTreatmentTaiwu
		/// </summary>
		public const short VillagerTreatmentTaiwu = 1066;

		/// <summary>
		/// VillagerReduceXiangshuInfect
		/// </summary>
		public const short VillagerReduceXiangshuInfect = 1067;

		/// <summary>
		/// VillagerEarnMoney
		/// </summary>
		public const short VillagerEarnMoney = 1068;

		/// <summary>
		/// VillagerBeEarnedMoney
		/// </summary>
		public const short VillagerBeEarnedMoney = 1069;

		/// <summary>
		/// VillagerBeSoldItem
		/// </summary>
		public const short VillagerBeSoldItem = 1070;

		/// <summary>
		/// VillagerBePurchasedItem
		/// </summary>
		public const short VillagerBePurchasedItem = 1071;

		/// <summary>
		/// VillagerGetMerchantFavorability
		/// </summary>
		public const short VillagerGetMerchantFavorability = 1072;

		/// <summary>
		/// VillagerGetMerchantFavorabilityTaiwu
		/// </summary>
		public const short VillagerGetMerchantFavorabilityTaiwu = 1073;

		/// <summary>
		/// LiteratiBeEntertainedUp
		/// </summary>
		public const short LiteratiBeEntertainedUp = 1074;

		/// <summary>
		/// LiteratiBeEntertainedDown
		/// </summary>
		public const short LiteratiBeEntertainedDown = 1075;

		/// <summary>
		/// LiteratiSpreadingInfluenceCultureUp
		/// </summary>
		public const short LiteratiSpreadingInfluenceCultureUp = 1076;

		/// <summary>
		/// LiteratiSpreadingInfluenceCultureDown
		/// </summary>
		public const short LiteratiSpreadingInfluenceCultureDown = 1077;

		/// <summary>
		/// LiteratiSpreadingInfluenceSafetyUp
		/// </summary>
		public const short LiteratiSpreadingInfluenceSafetyUp = 1078;

		/// <summary>
		/// LiteratiSpreadingInfluenceSafetyDown
		/// </summary>
		public const short LiteratiSpreadingInfluenceSafetyDown = 1079;

		/// <summary>
		/// LiteratiConnectRelationshipUp
		/// </summary>
		public const short LiteratiConnectRelationshipUp = 1080;

		/// <summary>
		/// LiteratiConnectRelationshipDown
		/// </summary>
		public const short LiteratiConnectRelationshipDown = 1081;

		/// <summary>
		/// LiteratiConnectRelationshipUpTaiwu
		/// </summary>
		public const short LiteratiConnectRelationshipUpTaiwu = 1082;

		/// <summary>
		/// LiteratiConnectRelationshipDownTaiwu
		/// </summary>
		public const short LiteratiConnectRelationshipDownTaiwu = 1083;

		/// <summary>
		/// LiteratiBeConnectedRelationshipUp
		/// </summary>
		public const short LiteratiBeConnectedRelationshipUp = 1084;

		/// <summary>
		/// LiteratiBeConnectedRelationshipDown
		/// </summary>
		public const short LiteratiBeConnectedRelationshipDown = 1085;

		/// <summary>
		/// GuardingSwordTombXiangshuInfectUp
		/// </summary>
		public const short GuardingSwordTombXiangshuInfectUp = 1086;

		/// <summary>
		/// GuardingSwordTombSucceed
		/// </summary>
		public const short GuardingSwordTombSucceed = 1087;

		/// <summary>
		/// VillagerMakeEnemy
		/// </summary>
		public const short VillagerMakeEnemy = 1088;

		/// <summary>
		/// VillagerConfessLoveSucceed
		/// </summary>
		public const short VillagerConfessLoveSucceed = 1089;

		/// <summary>
		/// OrderProduct
		/// </summary>
		public const short OrderProduct = 1090;

		/// <summary>
		/// ReceiveProduct
		/// </summary>
		public const short ReceiveProduct = 1091;

		/// <summary>
		/// BeOrderProduct
		/// </summary>
		public const short BeOrderProduct = 1092;

		/// <summary>
		/// BeReceiveProduct
		/// </summary>
		public const short BeReceiveProduct = 1093;

		/// <summary>
		/// CaptureOrder
		/// </summary>
		public const short CaptureOrder = 1094;

		/// <summary>
		/// BeCaptureOrder
		/// </summary>
		public const short BeCaptureOrder = 1095;

		/// <summary>
		/// CaptureOrderIntermediator
		/// </summary>
		public const short CaptureOrderIntermediator = 1096;

		/// <summary>
		/// OrderProductForOthers
		/// </summary>
		public const short OrderProductForOthers = 1097;

		/// <summary>
		/// BeOrderProductForOthers
		/// </summary>
		public const short BeOrderProductForOthers = 1098;

		/// <summary>
		/// DeliveredOrderProduct
		/// </summary>
		public const short DeliveredOrderProduct = 1099;

		/// <summary>
		/// BeDeliveredOrderProduct
		/// </summary>
		public const short BeDeliveredOrderProduct = 1100;

		/// <summary>
		/// AcquisitionDiscard
		/// </summary>
		public const short AcquisitionDiscard = 1101;

		/// <summary>
		/// ShopBuildingBaseDevelopLifeSkill
		/// </summary>
		public const short ShopBuildingBaseDevelopLifeSkill = 1102;

		/// <summary>
		/// ShopBuildingBaseDevelopCombatSkill
		/// </summary>
		public const short ShopBuildingBaseDevelopCombatSkill = 1103;

		/// <summary>
		/// ShopBuildingPersonalityDevelopLifeSkill
		/// </summary>
		public const short ShopBuildingPersonalityDevelopLifeSkill = 1104;

		/// <summary>
		/// ShopBuildingPersonalityDevelopCombatSkill
		/// </summary>
		public const short ShopBuildingPersonalityDevelopCombatSkill = 1105;

		/// <summary>
		/// ShopBuildingLeaderDevelopLifeSkill
		/// </summary>
		public const short ShopBuildingLeaderDevelopLifeSkill = 1106;

		/// <summary>
		/// ShopBuildingLeaderDevelopCombatSkill
		/// </summary>
		public const short ShopBuildingLeaderDevelopCombatSkill = 1107;

		/// <summary>
		/// ShopBuildingLearnLifeSkill
		/// </summary>
		public const short ShopBuildingLearnLifeSkill = 1108;

		/// <summary>
		/// ShopBuildingLearnCombatSkill
		/// </summary>
		public const short ShopBuildingLearnCombatSkill = 1109;

		/// <summary>
		/// JoinTaiwuVillageAfterTaiwuVillageStoneClaimed
		/// </summary>
		public const short JoinTaiwuVillageAfterTaiwuVillageStoneClaimed = 1110;

		/// <summary>
		/// TaiwuVillagerFinishedReading
		/// </summary>
		public const short TaiwuVillagerFinishedReading = 1111;

		/// <summary>
		/// TaiwuVillagerSalaryReceived
		/// </summary>
		public const short TaiwuVillagerSalaryReceived = 1112;

		/// <summary>
		/// ChangeGradeDrop
		/// </summary>
		public const short ChangeGradeDrop = 1113;

		/// <summary>
		/// FarmerCollectMaterial
		/// </summary>
		public const short FarmerCollectMaterial = 1114;

		/// <summary>
		/// JoinOrganization
		/// </summary>
		public const short JoinOrganization = 1115;

		/// <summary>
		/// BreakAwayOrganization
		/// </summary>
		public const short BreakAwayOrganization = 1116;

		/// <summary>
		/// ChangeOrganization
		/// </summary>
		public const short ChangeOrganization = 1117;

		/// <summary>
		/// VillagerFavorabilityUp
		/// </summary>
		public const short VillagerFavorabilityUp = 1118;

		/// <summary>
		/// VillagerFavorabilityDown
		/// </summary>
		public const short VillagerFavorabilityDown = 1119;

		/// <summary>
		/// VillagerFavorabilityUpPerson
		/// </summary>
		public const short VillagerFavorabilityUpPerson = 1120;

		/// <summary>
		/// VillagerFavorabilityDownPersonB
		/// </summary>
		public const short VillagerFavorabilityDownPerson = 1121;

		/// <summary>
		/// TeamUpProtection
		/// </summary>
		public const short TeamUpProtection = 1122;

		/// <summary>
		/// TeamUpRescue
		/// </summary>
		public const short TeamUpRescue = 1123;

		/// <summary>
		/// TeamUpMourn
		/// </summary>
		public const short TeamUpMourn = 1124;

		/// <summary>
		/// TeamUpVisitFriendOrFamily
		/// </summary>
		public const short TeamUpVisitFriendOrFamily = 1125;

		/// <summary>
		/// TeamUpFindTreasure
		/// </summary>
		public const short TeamUpFindTreasure = 1126;

		/// <summary>
		/// TeamUpFindSpecialMaterial
		/// </summary>
		public const short TeamUpFindSpecialMaterial = 1127;

		/// <summary>
		/// TeamUpTakeRevenge
		/// </summary>
		public const short TeamUpTakeRevenge = 1128;

		/// <summary>
		/// TeamUpContestForLegendaryBook
		/// </summary>
		public const short TeamUpContestForLegendaryBook = 1129;

		/// <summary>
		/// TeamUpEscapeFromPrison
		/// </summary>
		public const short TeamUpEscapeFromPrison = 1130;

		/// <summary>
		/// TeamUpSeekAsylum
		/// </summary>
		public const short TeamUpSeekAsylum = 1131;

		/// <summary>
		/// GetInfected
		/// </summary>
		public const short GetInfected = 1132;

		/// <summary>
		/// DieByInfected
		/// </summary>
		public const short DieByInfected = 1133;

		/// <summary>
		/// InheritLegacy
		/// </summary>
		public const short InheritLegacy = 1134;

		/// <summary>
		/// 低心情宾客服用了物品
		/// </summary>
		public const short Banquet_1 = 1135;

		/// <summary>
		/// 低心情宾客服用了喜爱的物品
		/// </summary>
		public const short Banquet_2 = 1136;

		/// <summary>
		/// 低心情宾客在宴席上服用了物品
		/// </summary>
		public const short Banquet_3 = 1137;

		/// <summary>
		/// 低心情宾客在宴席上服用了喜爱的物品
		/// </summary>
		public const short Banquet_4 = 1138;

		/// <summary>
		/// 宾客服用了物品
		/// </summary>
		public const short Banquet_5 = 1139;

		/// <summary>
		/// 宾客服用了喜爱的物品
		/// </summary>
		public const short Banquet_6 = 1140;

		/// <summary>
		/// 宾客在宴席上服用了物品
		/// </summary>
		public const short Banquet_7 = 1141;

		/// <summary>
		/// 宾客在宴席上服用了喜爱的物品
		/// </summary>
		public const short Banquet_8 = 1142;

		/// <summary>
		/// 宴堂没有可食用物品
		/// </summary>
		public const short Banquet_9 = 1143;

		/// <summary>
		/// 宾客已经吃不下
		/// </summary>
		public const short Banquet_10 = 1144;

		/// <summary>
		/// SectMainStoryWudangInjured
		/// </summary>
		public const short SectMainStoryWudangInjured = 1145;

		/// <summary>
		/// ExtendDarkAshTime
		/// </summary>
		public const short ExtendDarkAshTime = 1146;

		/// <summary>
		/// AdoreInMarriage
		/// </summary>
		public const short AdoreInMarriage = 1147;

		/// <summary>
		/// SameAreaDistantMarriage
		/// </summary>
		public const short SameAreaDistantMarriage = 1148;

		/// <summary>
		/// SameStateDistantMarriage
		/// </summary>
		public const short SameStateDistantMarriage = 1149;

		/// <summary>
		/// DifferentStateDistantMarriage
		/// </summary>
		public const short DifferentStateDistantMarriage = 1150;

		/// <summary>
		/// GoToOuterWorlds
		/// </summary>
		public const short GoToOuterWorlds = 1151;

		/// <summary>
		/// BackFromOuterWorlds
		/// </summary>
		public const short BackFromOuterWorlds = 1152;

		/// <summary>
		/// SectMainStoryXuehouJixiDrainNeili
		/// </summary>
		public const short SectMainStoryXuehouJixiDrainNeili = 1153;

		/// <summary>
		/// SectMainStoryXuehouTaiwuTransferFiveElements
		/// </summary>
		public const short SectMainStoryXuehouTaiwuTransferFiveElements = 1154;

		/// <summary>
		/// AlertnessUpBySecretInformation
		/// </summary>
		public const short AlertnessUpBySecretInformation = 1155;

		/// <summary>
		/// AlertnessDownBySecretInformation
		/// </summary>
		public const short AlertnessDownBySecretInformation = 1156;

		/// <summary>
		/// ConsummateLevelIncreased
		/// </summary>
		public const short ConsummateLevelIncreased = 1157;

		/// <summary>
		/// CombatSkillQualificationGrowthGuaranteed
		/// </summary>
		public const short CombatSkillQualificationGrowthGuaranteed = 1158;

		/// <summary>
		/// CombatSkillQualificationGrowthPersonality
		/// </summary>
		public const short CombatSkillQualificationGrowthPersonality = 1159;

		/// <summary>
		/// CombatSkillQualificationGrowthMentor
		/// </summary>
		public const short CombatSkillQualificationGrowthMentor = 1160;

		/// <summary>
		/// LifeSkillQualificationGrowthGuaranteed
		/// </summary>
		public const short LifeSkillQualificationGrowthGuaranteed = 1161;

		/// <summary>
		/// LifeSkillQualificationGrowthPersonality
		/// </summary>
		public const short LifeSkillQualificationGrowthPersonality = 1162;

		/// <summary>
		/// LifeSkillQualificationGrowthMentor
		/// </summary>
		public const short LifeSkillQualificationGrowthMentor = 1163;

		/// <summary>
		/// IdentityActionHelpCivilians
		/// </summary>
		public const short IdentityActionHelpCivilians = 1164;

		/// <summary>
		/// IdentityActionHelpCiviliansTarget
		/// </summary>
		public const short IdentityActionHelpCiviliansTarget = 1205;

		/// <summary>
		/// IdentityActionFightHeretics
		/// </summary>
		public const short IdentityActionFightHeretics = 1165;

		/// <summary>
		/// IdentityActionFightHereticsTarget
		/// </summary>
		public const short IdentityActionFightHereticsTarget = 1206;

		/// <summary>
		/// IdentityActionShaolin0
		/// </summary>
		public const short IdentityActionShaolin0 = 1166;

		/// <summary>
		/// IdentityActionShaolin0Target
		/// </summary>
		public const short IdentityActionShaolin0Target = 1207;

		/// <summary>
		/// IdentityActionShaolin1
		/// </summary>
		public const short IdentityActionShaolin1 = 1167;

		/// <summary>
		/// IdentityActionShaolin2
		/// </summary>
		public const short IdentityActionShaolin2 = 1168;

		/// <summary>
		/// IdentityActionShaolin2Target
		/// </summary>
		public const short IdentityActionShaolin2Target = 1208;

		/// <summary>
		/// IdentityActionShaolin3
		/// </summary>
		public const short IdentityActionShaolin3 = 1169;

		/// <summary>
		/// IdentityActionShaolin4
		/// </summary>
		public const short IdentityActionShaolin4 = 1170;

		/// <summary>
		/// IdentityActionShaolin4Target
		/// </summary>
		public const short IdentityActionShaolin4Target = 1375;

		/// <summary>
		/// IdentityActionShaolin5
		/// </summary>
		public const short IdentityActionShaolin5 = 1171;

		/// <summary>
		/// IdentityActionShaolin5Target
		/// </summary>
		public const short IdentityActionShaolin5Target = 1376;

		/// <summary>
		/// IdentityActionShaolin6
		/// </summary>
		public const short IdentityActionShaolin6 = 1172;

		/// <summary>
		/// IdentityActionEmei0
		/// </summary>
		public const short IdentityActionEmei0 = 1173;

		/// <summary>
		/// IdentityActionEmei0Target
		/// </summary>
		public const short IdentityActionEmei0Target = 1380;

		/// <summary>
		/// IdentityActionEmei1
		/// </summary>
		public const short IdentityActionEmei1 = 1174;

		/// <summary>
		/// IdentityActionEmei4
		/// </summary>
		public const short IdentityActionEmei4 = 1175;

		/// <summary>
		/// IdentityActionEmei4Target
		/// </summary>
		public const short IdentityActionEmei4Target = 1209;

		/// <summary>
		/// IdentityActionEmei5
		/// </summary>
		public const short IdentityActionEmei5 = 1176;

		/// <summary>
		/// IdentityActionEmei6
		/// </summary>
		public const short IdentityActionEmei6 = 1177;

		/// <summary>
		/// IdentityActionEmei6Target
		/// </summary>
		public const short IdentityActionEmei6Target = 1210;

		/// <summary>
		/// IdentityActionBaihua0
		/// </summary>
		public const short IdentityActionBaihua0 = 1178;

		/// <summary>
		/// IdentityActionBaihua0Target
		/// </summary>
		public const short IdentityActionBaihua0Target = 1211;

		/// <summary>
		/// IdentityActionBaihua1
		/// </summary>
		public const short IdentityActionBaihua1 = 1179;

		/// <summary>
		/// IdentityActionBaihua2
		/// </summary>
		public const short IdentityActionBaihua2 = 1180;

		/// <summary>
		/// IdentityActionBaihua3
		/// </summary>
		public const short IdentityActionBaihua3 = 1181;

		/// <summary>
		/// IdentityActionBaihua3Target
		/// </summary>
		public const short IdentityActionBaihua3Target = 1212;

		/// <summary>
		/// IdentityActionBaihua5
		/// </summary>
		public const short IdentityActionBaihua5 = 1183;

		/// <summary>
		/// IdentityActionBaihua5Target
		/// </summary>
		public const short IdentityActionBaihua5Target = 1213;

		/// <summary>
		/// IdentityActionWudang5
		/// </summary>
		public const short IdentityActionWudang5 = 1188;

		/// <summary>
		/// IdentityActionYuanshan1
		/// </summary>
		public const short IdentityActionYuanshan1 = 1191;

		/// <summary>
		/// IdentityActionYuanshan1Target
		/// </summary>
		public const short IdentityActionYuanshan1Target = 1218;

		/// <summary>
		/// IdentityActionYuanshan2
		/// </summary>
		public const short IdentityActionYuanshan2 = 1192;

		/// <summary>
		/// IdentityActionYuanshan3
		/// </summary>
		public const short IdentityActionYuanshan3 = 1193;

		/// <summary>
		/// IdentityActionYuanshan3Target
		/// </summary>
		public const short IdentityActionYuanshan3Target = 1219;

		/// <summary>
		/// IdentityActionYuanshan5
		/// </summary>
		public const short IdentityActionYuanshan5 = 1194;

		/// <summary>
		/// IdentityActionYuanshan5Target
		/// </summary>
		public const short IdentityActionYuanshan5Target = 1220;

		/// <summary>
		/// IdentityActionYuanshan6
		/// </summary>
		public const short IdentityActionYuanshan6 = 1195;

		/// <summary>
		/// IdentityActionYuanshan6Target
		/// </summary>
		public const short IdentityActionYuanshan6Target = 1384;

		/// <summary>
		/// IdentityActionShixiang0
		/// </summary>
		public const short IdentityActionShixiang0 = 1196;

		/// <summary>
		/// IdentityActionShixiang1
		/// </summary>
		public const short IdentityActionShixiang1 = 1197;

		/// <summary>
		/// IdentityActionShixiang2
		/// </summary>
		public const short IdentityActionShixiang2 = 1198;

		/// <summary>
		/// IdentityActionShixiang3
		/// </summary>
		public const short IdentityActionShixiang3 = 1199;

		/// <summary>
		/// IdentityActionShixiang4
		/// </summary>
		public const short IdentityActionShixiang4 = 1200;

		/// <summary>
		/// IdentityActionShixiang5
		/// </summary>
		public const short IdentityActionShixiang5 = 1201;

		/// <summary>
		/// IdentityActionShixiang5Target
		/// </summary>
		public const short IdentityActionShixiang5Target = 1221;

		/// <summary>
		/// IdentityActionShixiang6
		/// </summary>
		public const short IdentityActionShixiang6 = 1202;

		/// <summary>
		/// IdentityActionShixiang6Target
		/// </summary>
		public const short IdentityActionShixiang6Target = 1222;

		/// <summary>
		/// IdentityActionShixiang7
		/// </summary>
		public const short IdentityActionShixiang7 = 1203;

		/// <summary>
		/// IdentityActionShixiang7Target
		/// </summary>
		public const short IdentityActionShixiang7Target = 1223;

		/// <summary>
		/// IdentityActionShixiang8
		/// </summary>
		public const short IdentityActionShixiang8 = 1204;

		/// <summary>
		/// IdentityActionShixiang8Target
		/// </summary>
		public const short IdentityActionShixiang8Target = 1224;

		/// <summary>
		/// IdentityActionRanShan1
		/// </summary>
		public const short IdentityActionRanShan1 = 1225;

		/// <summary>
		/// IdentityActionRanShan1Target
		/// </summary>
		public const short IdentityActionRanShan1Target = 1226;

		/// <summary>
		/// IdentityActionRanShan2
		/// </summary>
		public const short IdentityActionRanShan2 = 1227;

		/// <summary>
		/// IdentityActionRanShan2Target
		/// </summary>
		public const short IdentityActionRanShan2Target = 1228;

		/// <summary>
		/// IdentityActionRanShan3
		/// </summary>
		public const short IdentityActionRanShan3 = 1229;

		/// <summary>
		/// IdentityActionRanShan4
		/// </summary>
		public const short IdentityActionRanShan4 = 1230;

		/// <summary>
		/// IdentityActionRanShan5
		/// </summary>
		public const short IdentityActionRanShan5 = 1231;

		/// <summary>
		/// IdentityActionRanShan6
		/// </summary>
		public const short IdentityActionRanShan6 = 1232;

		/// <summary>
		/// IdentityActionRanShan7
		/// </summary>
		public const short IdentityActionRanShan7 = 1233;

		/// <summary>
		/// IdentityActionRanShan7Target
		/// </summary>
		public const short IdentityActionRanShan7Target = 1234;

		/// <summary>
		/// IdentityActionRanShan8
		/// </summary>
		public const short IdentityActionRanShan8 = 1235;

		/// <summary>
		/// IdentityActionRanShan8Target
		/// </summary>
		public const short IdentityActionRanShan8Target = 1236;

		/// <summary>
		/// IdentityActionXuanNv1
		/// </summary>
		public const short IdentityActionXuanNv1 = 1237;

		/// <summary>
		/// IdentityActionXuanNv1Target
		/// </summary>
		public const short IdentityActionXuanNv1Target = 1238;

		/// <summary>
		/// IdentityActionXuanNv2
		/// </summary>
		public const short IdentityActionXuanNv2 = 1239;

		/// <summary>
		/// IdentityActionXuanNv2Target
		/// </summary>
		public const short IdentityActionXuanNv2Target = 1388;

		/// <summary>
		/// IdentityActionXuanNv3
		/// </summary>
		public const short IdentityActionXuanNv3 = 1240;

		/// <summary>
		/// IdentityActionXuanNv3Audience
		/// </summary>
		public const short IdentityActionXuanNv3Audience = 1389;

		/// <summary>
		/// IdentityActionXuanNv4
		/// </summary>
		public const short IdentityActionXuanNv4 = 1241;

		/// <summary>
		/// IdentityActionXuanNv4Target
		/// </summary>
		public const short IdentityActionXuanNv4Target = 1242;

		/// <summary>
		/// IdentityActionXuanNv5
		/// </summary>
		public const short IdentityActionXuanNv5 = 1243;

		/// <summary>
		/// IdentityActionXuanNv5Target
		/// </summary>
		public const short IdentityActionXuanNv5Target = 1244;

		/// <summary>
		/// IdentityActionXuanNv6
		/// </summary>
		public const short IdentityActionXuanNv6 = 1245;

		/// <summary>
		/// IdentityActionXuanNv7
		/// </summary>
		public const short IdentityActionXuanNv7 = 1246;

		/// <summary>
		/// IdentityActionZhuJian1
		/// </summary>
		public const short IdentityActionZhuJian1 = 1247;

		/// <summary>
		/// IdentityActionZhuJian1Target
		/// </summary>
		public const short IdentityActionZhuJian1Target = 1248;

		/// <summary>
		/// IdentityActionZhuJian2
		/// </summary>
		public const short IdentityActionZhuJian2 = 1249;

		/// <summary>
		/// IdentityActionZhuJian3
		/// </summary>
		public const short IdentityActionZhuJian3 = 1250;

		/// <summary>
		/// IdentityActionZhuJian4
		/// </summary>
		public const short IdentityActionZhuJian4 = 1251;

		/// <summary>
		/// IdentityActionZhuJian5
		/// </summary>
		public const short IdentityActionZhuJian5 = 1252;

		/// <summary>
		/// IdentityActionZhuJian8
		/// </summary>
		public const short IdentityActionZhuJian8 = 1377;

		/// <summary>
		/// IdentityActionKongSang1
		/// </summary>
		public const short IdentityActionKongSang1 = 1256;

		/// <summary>
		/// IdentityActionKongSang1Target
		/// </summary>
		public const short IdentityActionKongSang1Target = 1257;

		/// <summary>
		/// IdentityActionKongSang2
		/// </summary>
		public const short IdentityActionKongSang2 = 1258;

		/// <summary>
		/// IdentityActionKongSang3
		/// </summary>
		public const short IdentityActionKongSang3 = 1259;

		/// <summary>
		/// IdentityActionKongSang4A
		/// </summary>
		public const short IdentityActionKongSang4A = 1260;

		/// <summary>
		/// IdentityActionKongSang4B
		/// </summary>
		public const short IdentityActionKongSang4B = 1261;

		/// <summary>
		/// IdentityActionKongSang5A
		/// </summary>
		public const short IdentityActionKongSang5A = 1262;

		/// <summary>
		/// IdentityActionKongSang5B
		/// </summary>
		public const short IdentityActionKongSang5B = 1263;

		/// <summary>
		/// IdentityActionKongSang6
		/// </summary>
		public const short IdentityActionKongSang6 = 1264;

		/// <summary>
		/// IdentityActionKongSang6Target
		/// </summary>
		public const short IdentityActionKongSang6Target = 1265;

		/// <summary>
		/// IdentityActionKongSang7
		/// </summary>
		public const short IdentityActionKongSang7 = 1266;

		/// <summary>
		/// IdentityActionKongSang7Target
		/// </summary>
		public const short IdentityActionKongSang7Target = 1267;

		/// <summary>
		/// IdentityActionKongSang8A
		/// </summary>
		public const short IdentityActionKongSang8A = 1268;

		/// <summary>
		/// IdentityActionKongSang8ATarget
		/// </summary>
		public const short IdentityActionKongSang8ATarget = 1390;

		/// <summary>
		/// IdentityActionKongSang8B
		/// </summary>
		public const short IdentityActionKongSang8B = 1269;

		/// <summary>
		/// IdentityActionKongSang9A
		/// </summary>
		public const short IdentityActionKongSang9A = 1270;

		/// <summary>
		/// IdentityActionKongSang9ATarget
		/// </summary>
		public const short IdentityActionKongSang9ATarget = 1391;

		/// <summary>
		/// IdentityActionKongSang9B
		/// </summary>
		public const short IdentityActionKongSang9B = 1271;

		/// <summary>
		/// IdentityActionKongSang10
		/// </summary>
		public const short IdentityActionKongSang10 = 1272;

		/// <summary>
		/// IdentityActionKongSang10Target
		/// </summary>
		public const short IdentityActionKongSang10Target = 1273;

		/// <summary>
		/// IdentityActionJingGangZong2Steal
		/// </summary>
		public const short IdentityActionJingGangZong2Steal = 1277;

		/// <summary>
		/// IdentityActionJingGangZong2Rob
		/// </summary>
		public const short IdentityActionJingGangZong2Rob = 1278;

		/// <summary>
		/// IdentityActionJingGangZong2Scam
		/// </summary>
		public const short IdentityActionJingGangZong2Scam = 1279;

		/// <summary>
		/// IdentityActionJingGangZong3
		/// </summary>
		public const short IdentityActionJingGangZong3 = 1280;

		/// <summary>
		/// IdentityActionJingGangZong4
		/// </summary>
		public const short IdentityActionJingGangZong4 = 1281;

		/// <summary>
		/// IdentityActionJingGangZong4Target
		/// </summary>
		public const short IdentityActionJingGangZong4Target = 1282;

		/// <summary>
		/// IdentityActionJingGangZong5
		/// </summary>
		public const short IdentityActionJingGangZong5 = 1283;

		/// <summary>
		/// IdentityActionJingGangZong5Target
		/// </summary>
		public const short IdentityActionJingGangZong5Target = 1284;

		/// <summary>
		/// IdentityActionJingGangZong6
		/// </summary>
		public const short IdentityActionJingGangZong6 = 1285;

		/// <summary>
		/// IdentityActionJingGangZong6Target
		/// </summary>
		public const short IdentityActionJingGangZong6Target = 1286;

		/// <summary>
		/// IdentityActionJingGangZong7
		/// </summary>
		public const short IdentityActionJingGangZong7 = 1287;

		/// <summary>
		/// IdentityActionWuXian1
		/// </summary>
		public const short IdentityActionWuXian1 = 1288;

		/// <summary>
		/// IdentityActionWuXian2
		/// </summary>
		public const short IdentityActionWuXian2 = 1289;

		/// <summary>
		/// IdentityActionWuXian2Target
		/// </summary>
		public const short IdentityActionWuXian2Target = 1290;

		/// <summary>
		/// IdentityActionWuXian3
		/// </summary>
		public const short IdentityActionWuXian3 = 1291;

		/// <summary>
		/// IdentityActionWuXian3Target
		/// </summary>
		public const short IdentityActionWuXian3Target = 1292;

		/// <summary>
		/// IdentityActionWuXian4
		/// </summary>
		public const short IdentityActionWuXian4 = 1293;

		/// <summary>
		/// IdentityActionWuXian4Target
		/// </summary>
		public const short IdentityActionWuXian4Target = 1378;

		/// <summary>
		/// IdentityActionWuXian5
		/// </summary>
		public const short IdentityActionWuXian5 = 1294;

		/// <summary>
		/// IdentityActionWuXian6
		/// </summary>
		public const short IdentityActionWuXian6 = 1295;

		/// <summary>
		/// IdentityActionJieQing1A
		/// </summary>
		public const short IdentityActionJieQing1A = 1296;

		/// <summary>
		/// IdentityActionJieQing1B
		/// </summary>
		public const short IdentityActionJieQing1B = 1297;

		/// <summary>
		/// IdentityActionJieQing2
		/// </summary>
		public const short IdentityActionJieQing2 = 1298;

		/// <summary>
		/// IdentityActionJieQing2Target
		/// </summary>
		public const short IdentityActionJieQing2Target = 1392;

		/// <summary>
		/// IdentityActionJieQing3
		/// </summary>
		public const short IdentityActionJieQing3 = 1299;

		/// <summary>
		/// IdentityActionJieQing4
		/// </summary>
		public const short IdentityActionJieQing4 = 1300;

		/// <summary>
		/// IdentityActionJieQing5
		/// </summary>
		public const short IdentityActionJieQing5 = 1301;

		/// <summary>
		/// IdentityActionJieQing6A
		/// </summary>
		public const short IdentityActionJieQing6A = 1302;

		/// <summary>
		/// IdentityActionJieQing6B
		/// </summary>
		public const short IdentityActionJieQing6B = 1303;

		/// <summary>
		/// IdentityActionJieQing7
		/// </summary>
		public const short IdentityActionJieQing7 = 1304;

		/// <summary>
		/// IdentityActionJieQing7Target
		/// </summary>
		public const short IdentityActionJieQing7Target = 1381;

		/// <summary>
		/// IdentityActionJieQing8
		/// </summary>
		public const short IdentityActionJieQing8 = 1305;

		/// <summary>
		/// IdentityActionFuLong2
		/// </summary>
		public const short IdentityActionFuLong2 = 1308;

		/// <summary>
		/// IdentityActionFuLong6
		/// </summary>
		public const short IdentityActionFuLong6 = 1314;

		/// <summary>
		/// IdentityActionXveHou2StealA
		/// </summary>
		public const short IdentityActionXveHou2StealA = 1317;

		/// <summary>
		/// IdentityActionXveHou2StealB
		/// </summary>
		public const short IdentityActionXveHou2StealB = 1318;

		/// <summary>
		/// IdentityActionXveHou3RobA
		/// </summary>
		public const short IdentityActionXveHou3RobA = 1319;

		/// <summary>
		/// IdentityActionXveHou3RobB
		/// </summary>
		public const short IdentityActionXveHou3RobB = 1320;

		/// <summary>
		/// IdentityActionXveHou4ScamA
		/// </summary>
		public const short IdentityActionXveHou4ScamA = 1321;

		/// <summary>
		/// IdentityActionXveHou4ScamB
		/// </summary>
		public const short IdentityActionXveHou4ScamB = 1322;

		/// <summary>
		/// IdentityActionXveHou5
		/// </summary>
		public const short IdentityActionXveHou5 = 1323;

		/// <summary>
		/// IdentityActionXveHou6
		/// </summary>
		public const short IdentityActionXveHou6 = 1324;

		/// <summary>
		/// IdentityActionXveHou7
		/// </summary>
		public const short IdentityActionXveHou7 = 1325;

		/// <summary>
		/// IdentityActionXveHou7Target
		/// </summary>
		public const short IdentityActionXveHou7Target = 1326;

		/// <summary>
		/// IdentityActionChengZhen1
		/// </summary>
		public const short IdentityActionChengZhen1 = 1330;

		/// <summary>
		/// IdentityActionChengZhen1TargetA
		/// </summary>
		public const short IdentityActionChengZhen1TargetA = 1331;

		/// <summary>
		/// IdentityActionChengZhen1TargetB
		/// </summary>
		public const short IdentityActionChengZhen1TargetB = 1332;

		/// <summary>
		/// IdentityActionChengZhen2
		/// </summary>
		public const short IdentityActionChengZhen2 = 1333;

		/// <summary>
		/// IdentityActionChengZhen2TargetA
		/// </summary>
		public const short IdentityActionChengZhen2TargetA = 1334;

		/// <summary>
		/// IdentityActionChengZhen2TargetB
		/// </summary>
		public const short IdentityActionChengZhen2TargetB = 1335;

		/// <summary>
		/// IdentityActionChengZhen3
		/// </summary>
		public const short IdentityActionChengZhen3 = 1336;

		/// <summary>
		/// IdentityActionChengZhen4
		/// </summary>
		public const short IdentityActionChengZhen4 = 1337;

		/// <summary>
		/// IdentityActionChengZhen5
		/// </summary>
		public const short IdentityActionChengZhen5 = 1338;

		/// <summary>
		/// IdentityActionChengZhen6
		/// </summary>
		public const short IdentityActionChengZhen6 = 1339;

		/// <summary>
		/// IdentityActionChengZhen6Target
		/// </summary>
		public const short IdentityActionChengZhen6Target = 1340;

		/// <summary>
		/// IdentityActionChengZhen7
		/// </summary>
		public const short IdentityActionChengZhen7 = 1341;

		/// <summary>
		/// IdentityActionChengZhen7Target
		/// </summary>
		public const short IdentityActionChengZhen7Target = 1342;

		/// <summary>
		/// IdentityActionChengZhen8
		/// </summary>
		public const short IdentityActionChengZhen8 = 1343;

		/// <summary>
		/// IdentityActionChengZhen8Target
		/// </summary>
		public const short IdentityActionChengZhen8Target = 1344;

		/// <summary>
		/// IdentityActionChengZhen9
		/// </summary>
		public const short IdentityActionChengZhen9 = 1345;

		/// <summary>
		/// IdentityActionChengZhen9Target
		/// </summary>
		public const short IdentityActionChengZhen9Target = 1346;

		/// <summary>
		/// IdentityActionChengZhen10
		/// </summary>
		public const short IdentityActionChengZhen10 = 1347;

		/// <summary>
		/// IdentityActionChengZhen10TargetA
		/// </summary>
		public const short IdentityActionChengZhen10TargetA = 1348;

		/// <summary>
		/// IdentityActionChengZhen10TargetB
		/// </summary>
		public const short IdentityActionChengZhen10TargetB = 1349;

		/// <summary>
		/// IdentityActionChengZhen11
		/// </summary>
		public const short IdentityActionChengZhen11 = 1350;

		/// <summary>
		/// IdentityActionChengZhen12
		/// </summary>
		public const short IdentityActionChengZhen12 = 1351;

		/// <summary>
		/// IdentityActionChengZhen13
		/// </summary>
		public const short IdentityActionChengZhen13 = 1352;

		/// <summary>
		/// IdentityActionChengZhen13Target
		/// </summary>
		public const short IdentityActionChengZhen13Target = 1353;

		/// <summary>
		/// IdentityActionChengZhen14
		/// </summary>
		public const short IdentityActionChengZhen14 = 1354;

		/// <summary>
		/// IdentityActionChengZhen15
		/// </summary>
		public const short IdentityActionChengZhen15 = 1355;

		/// <summary>
		/// IdentityActionChengZhen16
		/// </summary>
		public const short IdentityActionChengZhen16 = 1356;

		/// <summary>
		/// IdentityActionChengZhen16Target
		/// </summary>
		public const short IdentityActionChengZhen16Target = 1357;

		/// <summary>
		/// IdentityActionChengZhen17
		/// </summary>
		public const short IdentityActionChengZhen17 = 1358;

		/// <summary>
		/// IdentityActionChengZhen18
		/// </summary>
		public const short IdentityActionChengZhen18 = 1359;

		/// <summary>
		/// IdentityActionChengZhen19
		/// </summary>
		public const short IdentityActionChengZhen19 = 1360;

		/// <summary>
		/// IdentityActionChengZhen20
		/// </summary>
		public const short IdentityActionChengZhen20 = 1361;

		/// <summary>
		/// IdentityActionChengZhen21
		/// </summary>
		public const short IdentityActionChengZhen21 = 1362;

		/// <summary>
		/// IdentityActionChengZhen22
		/// </summary>
		public const short IdentityActionChengZhen22 = 1363;

		/// <summary>
		/// BehaviorTypeAction1
		/// </summary>
		public const short BehaviorTypeAction1 = 1364;

		/// <summary>
		/// BehaviorTypeAction1Target
		/// </summary>
		public const short BehaviorTypeAction1Target = 1402;

		/// <summary>
		/// BehaviorTypeAction2
		/// </summary>
		public const short BehaviorTypeAction2 = 1365;

		/// <summary>
		/// BehaviorTypeAction2Target
		/// </summary>
		public const short BehaviorTypeAction2Target = 1403;

		/// <summary>
		/// BehaviorTypeAction3
		/// </summary>
		public const short BehaviorTypeAction3 = 1366;

		/// <summary>
		/// BehaviorTypeAction4
		/// </summary>
		public const short BehaviorTypeAction4 = 1367;

		/// <summary>
		/// BehaviorTypeAction5
		/// </summary>
		public const short BehaviorTypeAction5 = 1368;

		/// <summary>
		/// BehaviorTypeAction6
		/// </summary>
		public const short BehaviorTypeAction6 = 1369;

		/// <summary>
		/// CherryPickResource
		/// </summary>
		public const short CherryPickResource = 1370;

		/// <summary>
		/// BuddistMeditate
		/// </summary>
		public const short BuddistMeditate = 1371;

		/// <summary>
		/// TaoistMeditate
		/// </summary>
		public const short TaoistMeditate = 1372;

		/// <summary>
		/// IdentityActionCaptureCricket1
		/// </summary>
		public const short IdentityActionCaptureCricket1 = 1373;

		/// <summary>
		/// DLCLoongRidingEffectBaxia02
		/// </summary>
		public const short DLCLoongRidingEffectBaxia02 = 1374;

		/// <summary>
		/// WeiQiBadOther
		/// </summary>
		public const short WeiQiBadOther = 1386;

		/// <summary>
		/// WeiQiGoodOther
		/// </summary>
		public const short WeiQiGoodOther = 1387;

		/// <summary>
		/// TwelveImmortalsEffectAdored
		/// </summary>
		public const short TwelveImmortalsEffectAdored = 1393;

		/// <summary>
		/// TwelveImmortalsEffectEnemy
		/// </summary>
		public const short TwelveImmortalsEffectEnemy = 1394;

		/// <summary>
		/// TwelveImmortalsEffectSuxia
		/// </summary>
		public const short TwelveImmortalsEffectSuxia = 1395;

		/// <summary>
		/// TwelveImmortalsEffectBecomeMoTian
		/// </summary>
		public const short TwelveImmortalsEffectBecomeMoTian = 1396;

		/// <summary>
		/// TwelveImmortalsEffectBeAttackByMoTian
		/// </summary>
		public const short TwelveImmortalsEffectBeAttackByMoTian = 1397;

		/// <summary>
		/// TwelveImmortalsEffectBeAttackByJiao
		/// </summary>
		public const short TwelveImmortalsEffectBeAttackByJiao = 1398;

		/// <summary>
		/// TwelveImmortalsEffectBeAttackByMirror
		/// </summary>
		public const short TwelveImmortalsEffectBeAttackByMirror = 1399;

		/// <summary>
		/// TwelveImmortalsEffectBeAttackBySkeletonDemon
		/// </summary>
		public const short TwelveImmortalsEffectBeAttackBySkeletonDemon = 1400;

		/// <summary>
		/// DemonHeirRevenge
		/// </summary>
		public const short DemonHeirRevenge = 1404;

		/// <summary>
		/// DefeatDemonHeir
		/// </summary>
		public const short DefeatDemonHeir = 1405;

		/// <summary>
		/// BeDefetedByDemonHeir
		/// </summary>
		public const short BeDefetedByDemonHeir = 1406;

		/// <summary>
		/// DemonHeirDefeatTaiwu
		/// </summary>
		public const short DemonHeirDefeatTaiwu = 1407;

		/// <summary>
		/// DemonHeirRebirth1
		/// </summary>
		public const short DemonHeirRebirth1 = 1408;

		/// <summary>
		/// DemonHeirRebirth2
		/// </summary>
		public const short DemonHeirRebirth2 = 1409;

		/// <summary>
		/// DLCCricketTurnToCricketForm
		/// </summary>
		public const short DLCCricketTurnToCricketForm = 1410;

		/// <summary>
		/// DLCCricketRetranmogrifyToHuman
		/// </summary>
		public const short DLCCricketRetranmogrifyToHuman = 1411;

		/// <summary>
		/// DecideToParticipateNewAdventure
		/// </summary>
		public const short DecideToParticipateNewAdventure = 1412;

		/// <summary>
		/// LeaveNewAdventure
		/// </summary>
		public const short LeaveNewAdventure = 1413;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// Die
		/// </summary>
		public static LifeRecordItem Die => Instance[(short)0];

		/// <summary>
		/// XiangshuPartiallyInfected
		/// </summary>
		public static LifeRecordItem XiangshuPartiallyInfected => Instance[(short)1];

		/// <summary>
		/// XiangshuCompletelyInfected
		/// </summary>
		public static LifeRecordItem XiangshuCompletelyInfected => Instance[(short)2];

		/// <summary>
		/// MotherLoseFetus
		/// </summary>
		public static LifeRecordItem MotherLoseFetus => Instance[(short)3];

		/// <summary>
		/// FatherLoseFetus
		/// </summary>
		public static LifeRecordItem FatherLoseFetus => Instance[(short)4];

		/// <summary>
		/// AbandonChild
		/// </summary>
		public static LifeRecordItem AbandonChild => Instance[(short)5];

		/// <summary>
		/// ChildGetAbandoned
		/// </summary>
		public static LifeRecordItem ChildGetAbandoned => Instance[(short)6];

		/// <summary>
		/// GiveBirthToCricket
		/// </summary>
		public static LifeRecordItem GiveBirthToCricket => Instance[(short)7];

		/// <summary>
		/// GiveBirthToBoy
		/// </summary>
		public static LifeRecordItem GiveBirthToBoy => Instance[(short)8];

		/// <summary>
		/// GiveBirthToGirl
		/// </summary>
		public static LifeRecordItem GiveBirthToGirl => Instance[(short)9];

		/// <summary>
		/// BecomeFatherToNewBornBoy
		/// </summary>
		public static LifeRecordItem BecomeFatherToNewBornBoy => Instance[(short)10];

		/// <summary>
		/// BecomeFatherToNewBornGirl
		/// </summary>
		public static LifeRecordItem BecomeFatherToNewBornGirl => Instance[(short)11];

		/// <summary>
		/// BuildGrave
		/// </summary>
		public static LifeRecordItem BuildGrave => Instance[(short)12];

		/// <summary>
		/// MonkBreakRule
		/// </summary>
		public static LifeRecordItem MonkBreakRule => Instance[(short)13];

		/// <summary>
		/// KidnappedCharacterEscaped
		/// </summary>
		public static LifeRecordItem KidnappedCharacterEscaped => Instance[(short)14];

		/// <summary>
		/// EscapeFromKidnapping
		/// </summary>
		public static LifeRecordItem EscapeFromKidnapping => Instance[(short)15];

		/// <summary>
		/// ReadBookSucceed
		/// </summary>
		public static LifeRecordItem ReadBookSucceed => Instance[(short)16];

		/// <summary>
		/// ReadBookFail
		/// </summary>
		public static LifeRecordItem ReadBookFail => Instance[(short)17];

		/// <summary>
		/// BreakoutSucceed
		/// </summary>
		public static LifeRecordItem BreakoutSucceed => Instance[(short)18];

		/// <summary>
		/// BreakoutFail
		/// </summary>
		public static LifeRecordItem BreakoutFail => Instance[(short)19];

		/// <summary>
		/// LearnCombatSkill
		/// </summary>
		public static LifeRecordItem LearnCombatSkill => Instance[(short)20];

		/// <summary>
		/// LearnLifeSkill
		/// </summary>
		public static LifeRecordItem LearnLifeSkill => Instance[(short)21];

		/// <summary>
		/// RepairItem
		/// </summary>
		public static LifeRecordItem RepairItem => Instance[(short)22];

		/// <summary>
		/// AddPoisonToItem
		/// </summary>
		public static LifeRecordItem AddPoisonToItem => Instance[(short)23];

		/// <summary>
		/// LoseOverloadingResource
		/// </summary>
		public static LifeRecordItem LoseOverloadingResource => Instance[(short)24];

		/// <summary>
		/// LoseOverloadingItem
		/// </summary>
		public static LifeRecordItem LoseOverloadingItem => Instance[(short)25];

		/// <summary>
		/// MakeEnemy
		/// </summary>
		public static LifeRecordItem MakeEnemy => Instance[(short)26];

		/// <summary>
		/// SeverEnemy
		/// </summary>
		public static LifeRecordItem SeverEnemy => Instance[(short)27];

		/// <summary>
		/// BeMadeEnemy
		/// </summary>
		public static LifeRecordItem BeMadeEnemy => Instance[(short)28];

		/// <summary>
		/// SeveredEnemy
		/// </summary>
		public static LifeRecordItem SeveredEnemy => Instance[(short)29];

		/// <summary>
		/// Adore
		/// </summary>
		public static LifeRecordItem Adore => Instance[(short)30];

		/// <summary>
		/// LoveAtFirstSight
		/// </summary>
		public static LifeRecordItem LoveAtFirstSight => Instance[(short)31];

		/// <summary>
		/// ConfessLoveSucceed
		/// </summary>
		public static LifeRecordItem ConfessLoveSucceed => Instance[(short)32];

		/// <summary>
		/// ConfessLoveFail
		/// </summary>
		public static LifeRecordItem ConfessLoveFail => Instance[(short)33];

		/// <summary>
		/// AcceptConfessLove
		/// </summary>
		public static LifeRecordItem AcceptConfessLove => Instance[(short)34];

		/// <summary>
		/// RefuseConfessLove
		/// </summary>
		public static LifeRecordItem RefuseConfessLove => Instance[(short)35];

		/// <summary>
		/// BreakupMutually
		/// </summary>
		public static LifeRecordItem BreakupMutually => Instance[(short)36];

		/// <summary>
		/// DumpLover
		/// </summary>
		public static LifeRecordItem DumpLover => Instance[(short)37];

		/// <summary>
		/// GetDumppedByLover
		/// </summary>
		public static LifeRecordItem GetDumppedByLover => Instance[(short)38];

		/// <summary>
		/// ProposeMarriageSucceed
		/// </summary>
		public static LifeRecordItem ProposeMarriageSucceed => Instance[(short)39];

		/// <summary>
		/// ProposeMarriageFail
		/// </summary>
		public static LifeRecordItem ProposeMarriageFail => Instance[(short)40];

		/// <summary>
		/// RefuseMarriageProposal
		/// </summary>
		public static LifeRecordItem RefuseMarriageProposal => Instance[(short)41];

		/// <summary>
		/// BecomeFriend
		/// </summary>
		public static LifeRecordItem BecomeFriend => Instance[(short)42];

		/// <summary>
		/// SeverFriendship
		/// </summary>
		public static LifeRecordItem SeverFriendship => Instance[(short)43];

		/// <summary>
		/// BecomeSwornBrotherOrSister
		/// </summary>
		public static LifeRecordItem BecomeSwornBrotherOrSister => Instance[(short)44];

		/// <summary>
		/// SeverSwornBrotherhood
		/// </summary>
		public static LifeRecordItem SeverSwornBrotherhood => Instance[(short)45];

		/// <summary>
		/// GetAdoptedByFather
		/// </summary>
		public static LifeRecordItem GetAdoptedByFather => Instance[(short)46];

		/// <summary>
		/// GetAdoptedByMother
		/// </summary>
		public static LifeRecordItem GetAdoptedByMother => Instance[(short)47];

		/// <summary>
		/// AdoptSon
		/// </summary>
		public static LifeRecordItem AdoptSon => Instance[(short)48];

		/// <summary>
		/// AdoptDaughter
		/// </summary>
		public static LifeRecordItem AdoptDaughter => Instance[(short)49];

		/// <summary>
		/// CreateFaction
		/// </summary>
		public static LifeRecordItem CreateFaction => Instance[(short)50];

		/// <summary>
		/// JoinFaction
		/// </summary>
		public static LifeRecordItem JoinFaction => Instance[(short)51];

		/// <summary>
		/// LeaveFaction
		/// </summary>
		public static LifeRecordItem LeaveFaction => Instance[(short)52];

		/// <summary>
		/// FactionRecruitSucceed
		/// </summary>
		public static LifeRecordItem FactionRecruitSucceed => Instance[(short)53];

		/// <summary>
		/// FactionRecruitFail
		/// </summary>
		public static LifeRecordItem FactionRecruitFail => Instance[(short)54];

		/// <summary>
		/// AgreeToJoinFaction
		/// </summary>
		public static LifeRecordItem AgreeToJoinFaction => Instance[(short)55];

		/// <summary>
		/// RefuseToJoinFaction
		/// </summary>
		public static LifeRecordItem RefuseToJoinFaction => Instance[(short)56];

		/// <summary>
		/// DecideToJoinSect
		/// </summary>
		public static LifeRecordItem DecideToJoinSect => Instance[(short)57];

		/// <summary>
		/// DecideToFullfillAppointment
		/// </summary>
		public static LifeRecordItem DecideToFullfillAppointment => Instance[(short)58];

		/// <summary>
		/// DecideToProtect
		/// </summary>
		public static LifeRecordItem DecideToProtect => Instance[(short)59];

		/// <summary>
		/// DecideToRescue
		/// </summary>
		public static LifeRecordItem DecideToRescue => Instance[(short)60];

		/// <summary>
		/// DecideToMourn
		/// </summary>
		public static LifeRecordItem DecideToMourn => Instance[(short)61];

		/// <summary>
		/// DecideToVisit
		/// </summary>
		public static LifeRecordItem DecideToVisit => Instance[(short)62];

		/// <summary>
		/// DecideToFindLostItem
		/// </summary>
		public static LifeRecordItem DecideToFindLostItem => Instance[(short)63];

		/// <summary>
		/// DecideToFindSpecialMaterial
		/// </summary>
		public static LifeRecordItem DecideToFindSpecialMaterial => Instance[(short)64];

		/// <summary>
		/// DecideToRevenge
		/// </summary>
		public static LifeRecordItem DecideToRevenge => Instance[(short)65];

		/// <summary>
		/// DecideToParticipateAdventure
		/// </summary>
		public static LifeRecordItem DecideToParticipateAdventure => Instance[(short)66];

		/// <summary>
		/// JoinSectFail
		/// </summary>
		public static LifeRecordItem JoinSectFail => Instance[(short)67];

		/// <summary>
		/// JoinSectSucceed
		/// </summary>
		public static LifeRecordItem JoinSectSucceed => Instance[(short)68];

		/// <summary>
		/// CanNoLongerFullFillAppointment
		/// </summary>
		public static LifeRecordItem CanNoLongerFullFillAppointment => Instance[(short)69];

		/// <summary>
		/// WaitForAppointment
		/// </summary>
		public static LifeRecordItem WaitForAppointment => Instance[(short)70];

		/// <summary>
		/// FullFillAppointment
		/// </summary>
		public static LifeRecordItem FullFillAppointment => Instance[(short)71];

		/// <summary>
		/// FinishProtection
		/// </summary>
		public static LifeRecordItem FinishProtection => Instance[(short)72];

		/// <summary>
		/// OfferProtection
		/// </summary>
		public static LifeRecordItem OfferProtection => Instance[(short)73];

		/// <summary>
		/// FinishRescue
		/// </summary>
		public static LifeRecordItem FinishRescue => Instance[(short)74];

		/// <summary>
		/// FinishMourning
		/// </summary>
		public static LifeRecordItem FinishMourning => Instance[(short)75];

		/// <summary>
		/// MaintainGrave
		/// </summary>
		public static LifeRecordItem MaintainGrave => Instance[(short)76];

		/// <summary>
		/// UpgradeGrave
		/// </summary>
		public static LifeRecordItem UpgradeGrave => Instance[(short)77];

		/// <summary>
		/// FinishVisit
		/// </summary>
		public static LifeRecordItem FinishVisit => Instance[(short)78];

		/// <summary>
		/// FinishFIndingLostItem
		/// </summary>
		public static LifeRecordItem FinishFIndingLostItem => Instance[(short)79];

		/// <summary>
		/// FinishFIndingSpecialMaterial
		/// </summary>
		public static LifeRecordItem FinishFIndingSpecialMaterial => Instance[(short)80];

		/// <summary>
		/// FindLostItemSucceed
		/// </summary>
		public static LifeRecordItem FindLostItemSucceed => Instance[(short)81];

		/// <summary>
		/// FindLostItemFail
		/// </summary>
		public static LifeRecordItem FindLostItemFail => Instance[(short)82];

		/// <summary>
		/// FindSpecialMaterialSucceed
		/// </summary>
		public static LifeRecordItem FindSpecialMaterialSucceed => Instance[(short)83];

		/// <summary>
		/// FinishTakingRevenge
		/// </summary>
		public static LifeRecordItem FinishTakingRevenge => Instance[(short)84];

		/// <summary>
		/// MajorVictoryInCombat
		/// </summary>
		public static LifeRecordItem MajorVictoryInCombat => Instance[(short)85];

		/// <summary>
		/// MajorFailureInCombat
		/// </summary>
		public static LifeRecordItem MajorFailureInCombat => Instance[(short)86];

		/// <summary>
		/// VictoryInCombat
		/// </summary>
		public static LifeRecordItem VictoryInCombat => Instance[(short)87];

		/// <summary>
		/// FailureInCombat
		/// </summary>
		public static LifeRecordItem FailureInCombat => Instance[(short)88];

		/// <summary>
		/// EnemyEscape
		/// </summary>
		public static LifeRecordItem EnemyEscape => Instance[(short)89];

		/// <summary>
		/// LoseAndEscape
		/// </summary>
		public static LifeRecordItem LoseAndEscape => Instance[(short)90];

		/// <summary>
		/// KillInPublic
		/// </summary>
		public static LifeRecordItem KillInPublic => Instance[(short)91];

		/// <summary>
		/// KillInPrivate
		/// </summary>
		public static LifeRecordItem KillInPrivate => Instance[(short)92];

		/// <summary>
		/// KidnapInPublic
		/// </summary>
		public static LifeRecordItem KidnapInPublic => Instance[(short)93];

		/// <summary>
		/// KidnapInPrivate
		/// </summary>
		public static LifeRecordItem KidnapInPrivate => Instance[(short)94];

		/// <summary>
		/// ReleaseLoser
		/// </summary>
		public static LifeRecordItem ReleaseLoser => Instance[(short)95];

		/// <summary>
		/// GetKidnappedInPublic
		/// </summary>
		public static LifeRecordItem GetKidnappedInPublic => Instance[(short)96];

		/// <summary>
		/// GetKidnappedInPrivate
		/// </summary>
		public static LifeRecordItem GetKidnappedInPrivate => Instance[(short)97];

		/// <summary>
		/// GetReleasedByWinner
		/// </summary>
		public static LifeRecordItem GetReleasedByWinner => Instance[(short)98];

		/// <summary>
		/// AgreeToProtect
		/// </summary>
		public static LifeRecordItem AgreeToProtect => Instance[(short)99];

		/// <summary>
		/// RefuseToProtect
		/// </summary>
		public static LifeRecordItem RefuseToProtect => Instance[(short)100];

		/// <summary>
		/// FinishAdventure
		/// </summary>
		public static LifeRecordItem FinishAdventure => Instance[(short)101];

		/// <summary>
		/// RequestHealOuterInjurySucceed
		/// </summary>
		public static LifeRecordItem RequestHealOuterInjurySucceed => Instance[(short)102];

		/// <summary>
		/// RequestHealInnerInjurySucceed
		/// </summary>
		public static LifeRecordItem RequestHealInnerInjurySucceed => Instance[(short)103];

		/// <summary>
		/// RequestDetoxPoisonSucceed
		/// </summary>
		public static LifeRecordItem RequestDetoxPoisonSucceed => Instance[(short)104];

		/// <summary>
		/// RequestHealthSucceed
		/// </summary>
		public static LifeRecordItem RequestHealthSucceed => Instance[(short)105];

		/// <summary>
		/// RequestHealDisorderOfQiSucceed
		/// </summary>
		public static LifeRecordItem RequestHealDisorderOfQiSucceed => Instance[(short)106];

		/// <summary>
		/// RequestNeiliSucceed
		/// </summary>
		public static LifeRecordItem RequestNeiliSucceed => Instance[(short)107];

		/// <summary>
		/// RequestKillWugSucceed
		/// </summary>
		public static LifeRecordItem RequestKillWugSucceed => Instance[(short)108];

		/// <summary>
		/// RequestFoodSucceed
		/// </summary>
		public static LifeRecordItem RequestFoodSucceed => Instance[(short)109];

		/// <summary>
		/// RequestTeaWineSucceed
		/// </summary>
		public static LifeRecordItem RequestTeaWineSucceed => Instance[(short)110];

		/// <summary>
		/// RequestResourceSucceed
		/// </summary>
		public static LifeRecordItem RequestResourceSucceed => Instance[(short)111];

		/// <summary>
		/// RequestItemSucceed
		/// </summary>
		public static LifeRecordItem RequestItemSucceed => Instance[(short)112];

		/// <summary>
		/// RequestRepairItemSucceed
		/// </summary>
		public static LifeRecordItem RequestRepairItemSucceed => Instance[(short)113];

		/// <summary>
		/// RequestAddPoisonToItemSucceed
		/// </summary>
		public static LifeRecordItem RequestAddPoisonToItemSucceed => Instance[(short)114];

		/// <summary>
		/// RequestInstructionOnLifeSkillSucceed
		/// </summary>
		public static LifeRecordItem RequestInstructionOnLifeSkillSucceed => Instance[(short)115];

		/// <summary>
		/// RequestInstructionOnCombatSkillSucceed
		/// </summary>
		public static LifeRecordItem RequestInstructionOnCombatSkillSucceed => Instance[(short)116];

		/// <summary>
		/// RequestInstructionOnLifeSkillFailToLearn
		/// </summary>
		public static LifeRecordItem RequestInstructionOnLifeSkillFailToLearn => Instance[(short)117];

		/// <summary>
		/// RequestInstructionOnCombatSkillFailToLearn
		/// </summary>
		public static LifeRecordItem RequestInstructionOnCombatSkillFailToLearn => Instance[(short)118];

		/// <summary>
		/// RequestInstructionOnReadingSucceed
		/// </summary>
		public static LifeRecordItem RequestInstructionOnReadingSucceed => Instance[(short)119];

		/// <summary>
		/// RequestInstructionOnBreakoutSucceed
		/// </summary>
		public static LifeRecordItem RequestInstructionOnBreakoutSucceed => Instance[(short)120];

		/// <summary>
		/// RequestHealOuterInjuryFail
		/// </summary>
		public static LifeRecordItem RequestHealOuterInjuryFail => Instance[(short)121];

		/// <summary>
		/// RequestHealInnerInjuryFail
		/// </summary>
		public static LifeRecordItem RequestHealInnerInjuryFail => Instance[(short)122];

		/// <summary>
		/// RequestDetoxPoisonFail
		/// </summary>
		public static LifeRecordItem RequestDetoxPoisonFail => Instance[(short)123];

		/// <summary>
		/// RequestHealthFail
		/// </summary>
		public static LifeRecordItem RequestHealthFail => Instance[(short)124];

		/// <summary>
		/// RequestHealDisorderOfQiFail
		/// </summary>
		public static LifeRecordItem RequestHealDisorderOfQiFail => Instance[(short)125];

		/// <summary>
		/// RequestNeiliFail
		/// </summary>
		public static LifeRecordItem RequestNeiliFail => Instance[(short)126];

		/// <summary>
		/// RequestKillWugFail
		/// </summary>
		public static LifeRecordItem RequestKillWugFail => Instance[(short)127];

		/// <summary>
		/// RequestFoodFail
		/// </summary>
		public static LifeRecordItem RequestFoodFail => Instance[(short)128];

		/// <summary>
		/// RequestTeaWineFail
		/// </summary>
		public static LifeRecordItem RequestTeaWineFail => Instance[(short)129];

		/// <summary>
		/// RequestResourceFail
		/// </summary>
		public static LifeRecordItem RequestResourceFail => Instance[(short)130];

		/// <summary>
		/// RequestItemFail
		/// </summary>
		public static LifeRecordItem RequestItemFail => Instance[(short)131];

		/// <summary>
		/// RequestRepairItemFail
		/// </summary>
		public static LifeRecordItem RequestRepairItemFail => Instance[(short)132];

		/// <summary>
		/// RequestAddPoisonToItemFail
		/// </summary>
		public static LifeRecordItem RequestAddPoisonToItemFail => Instance[(short)133];

		/// <summary>
		/// RequestInstructionOnLifeSkillFail
		/// </summary>
		public static LifeRecordItem RequestInstructionOnLifeSkillFail => Instance[(short)134];

		/// <summary>
		/// RequestInstructionOnCombatSkillFail
		/// </summary>
		public static LifeRecordItem RequestInstructionOnCombatSkillFail => Instance[(short)135];

		/// <summary>
		/// RequestInstructionOnReadingFail
		/// </summary>
		public static LifeRecordItem RequestInstructionOnReadingFail => Instance[(short)136];

		/// <summary>
		/// RequestInstructionOnBreakoutFail
		/// </summary>
		public static LifeRecordItem RequestInstructionOnBreakoutFail => Instance[(short)137];

		/// <summary>
		/// AcceptRequestHealOuterInjury
		/// </summary>
		public static LifeRecordItem AcceptRequestHealOuterInjury => Instance[(short)138];

		/// <summary>
		/// AcceptRequestHealInnerInjury
		/// </summary>
		public static LifeRecordItem AcceptRequestHealInnerInjury => Instance[(short)139];

		/// <summary>
		/// AcceptRequestDetoxPoison
		/// </summary>
		public static LifeRecordItem AcceptRequestDetoxPoison => Instance[(short)140];

		/// <summary>
		/// AcceptRequestHealth
		/// </summary>
		public static LifeRecordItem AcceptRequestHealth => Instance[(short)141];

		/// <summary>
		/// AcceptRequestHealDisorderOfQi
		/// </summary>
		public static LifeRecordItem AcceptRequestHealDisorderOfQi => Instance[(short)142];

		/// <summary>
		/// AcceptRequestNeili
		/// </summary>
		public static LifeRecordItem AcceptRequestNeili => Instance[(short)143];

		/// <summary>
		/// AcceptRequestKillWug
		/// </summary>
		public static LifeRecordItem AcceptRequestKillWug => Instance[(short)144];

		/// <summary>
		/// AcceptRequestFood
		/// </summary>
		public static LifeRecordItem AcceptRequestFood => Instance[(short)145];

		/// <summary>
		/// AcceptRequestTeaWine
		/// </summary>
		public static LifeRecordItem AcceptRequestTeaWine => Instance[(short)146];

		/// <summary>
		/// AcceptRequestResource
		/// </summary>
		public static LifeRecordItem AcceptRequestResource => Instance[(short)147];

		/// <summary>
		/// AcceptRequestItem
		/// </summary>
		public static LifeRecordItem AcceptRequestItem => Instance[(short)148];

		/// <summary>
		/// AcceptRequestRepairItem
		/// </summary>
		public static LifeRecordItem AcceptRequestRepairItem => Instance[(short)149];

		/// <summary>
		/// AcceptRequestAddPoisonToItem
		/// </summary>
		public static LifeRecordItem AcceptRequestAddPoisonToItem => Instance[(short)150];

		/// <summary>
		/// AcceptRequestInstructionOnLifeSkill
		/// </summary>
		public static LifeRecordItem AcceptRequestInstructionOnLifeSkill => Instance[(short)151];

		/// <summary>
		/// AcceptRequestInstructionOnCombatSkill
		/// </summary>
		public static LifeRecordItem AcceptRequestInstructionOnCombatSkill => Instance[(short)152];

		/// <summary>
		/// AcceptRequestInstructionOnLifeSkillButFail
		/// </summary>
		public static LifeRecordItem AcceptRequestInstructionOnLifeSkillButFail => Instance[(short)153];

		/// <summary>
		/// AcceptRequestInstructionOnCombatSkillButFail
		/// </summary>
		public static LifeRecordItem AcceptRequestInstructionOnCombatSkillButFail => Instance[(short)154];

		/// <summary>
		/// AcceptRequestInstructionOnReading
		/// </summary>
		public static LifeRecordItem AcceptRequestInstructionOnReading => Instance[(short)155];

		/// <summary>
		/// AcceptRequestInstructionOnBreakout
		/// </summary>
		public static LifeRecordItem AcceptRequestInstructionOnBreakout => Instance[(short)156];

		/// <summary>
		/// RefuseRequestHealOuterInjury
		/// </summary>
		public static LifeRecordItem RefuseRequestHealOuterInjury => Instance[(short)157];

		/// <summary>
		/// RefuseRequestHealInnerInjury
		/// </summary>
		public static LifeRecordItem RefuseRequestHealInnerInjury => Instance[(short)158];

		/// <summary>
		/// RefuseRequestDetoxPoison
		/// </summary>
		public static LifeRecordItem RefuseRequestDetoxPoison => Instance[(short)159];

		/// <summary>
		/// RefuseRequestHealth
		/// </summary>
		public static LifeRecordItem RefuseRequestHealth => Instance[(short)160];

		/// <summary>
		/// RefuseRequestHealDisorderOfQi
		/// </summary>
		public static LifeRecordItem RefuseRequestHealDisorderOfQi => Instance[(short)161];

		/// <summary>
		/// RefuseRequestNeili
		/// </summary>
		public static LifeRecordItem RefuseRequestNeili => Instance[(short)162];

		/// <summary>
		/// RefuseRequestKillWug
		/// </summary>
		public static LifeRecordItem RefuseRequestKillWug => Instance[(short)163];

		/// <summary>
		/// RefuseRequestFood
		/// </summary>
		public static LifeRecordItem RefuseRequestFood => Instance[(short)164];

		/// <summary>
		/// RefuseRequestTeaWine
		/// </summary>
		public static LifeRecordItem RefuseRequestTeaWine => Instance[(short)165];

		/// <summary>
		/// RefuseRequestResource
		/// </summary>
		public static LifeRecordItem RefuseRequestResource => Instance[(short)166];

		/// <summary>
		/// RefuseRequestItem
		/// </summary>
		public static LifeRecordItem RefuseRequestItem => Instance[(short)167];

		/// <summary>
		/// RefuseRequestRepairItem
		/// </summary>
		public static LifeRecordItem RefuseRequestRepairItem => Instance[(short)168];

		/// <summary>
		/// RefuseRequestAddPoisonToItem
		/// </summary>
		public static LifeRecordItem RefuseRequestAddPoisonToItem => Instance[(short)169];

		/// <summary>
		/// RefuseRequestInstructionOnLifeSkill
		/// </summary>
		public static LifeRecordItem RefuseRequestInstructionOnLifeSkill => Instance[(short)170];

		/// <summary>
		/// RefuseRequestInstructionOnCombatSkill
		/// </summary>
		public static LifeRecordItem RefuseRequestInstructionOnCombatSkill => Instance[(short)171];

		/// <summary>
		/// RefuseRequestInstructionOnReading
		/// </summary>
		public static LifeRecordItem RefuseRequestInstructionOnReading => Instance[(short)172];

		/// <summary>
		/// RefuseRequestInstructionOnBreakout
		/// </summary>
		public static LifeRecordItem RefuseRequestInstructionOnBreakout => Instance[(short)173];

		/// <summary>
		/// RescueKidnappedCharacterSecretlyFail1
		/// </summary>
		public static LifeRecordItem RescueKidnappedCharacterSecretlyFail1 => Instance[(short)174];

		/// <summary>
		/// RescueKidnappedCharacterSecretlyFail2
		/// </summary>
		public static LifeRecordItem RescueKidnappedCharacterSecretlyFail2 => Instance[(short)175];

		/// <summary>
		/// RescueKidnappedCharacterSecretlyFail3
		/// </summary>
		public static LifeRecordItem RescueKidnappedCharacterSecretlyFail3 => Instance[(short)176];

		/// <summary>
		/// RescueKidnappedCharacterSecretlyFail4
		/// </summary>
		public static LifeRecordItem RescueKidnappedCharacterSecretlyFail4 => Instance[(short)177];

		/// <summary>
		/// RescueKidnappedCharacterSecretlySucceed
		/// </summary>
		public static LifeRecordItem RescueKidnappedCharacterSecretlySucceed => Instance[(short)178];

		/// <summary>
		/// RescueKidnappedCharacterSecretlySucceedAndEscaped
		/// </summary>
		public static LifeRecordItem RescueKidnappedCharacterSecretlySucceedAndEscaped => Instance[(short)179];

		/// <summary>
		/// KidnappedCharacterGetRescuedSecretly
		/// </summary>
		public static LifeRecordItem KidnappedCharacterGetRescuedSecretly => Instance[(short)180];

		/// <summary>
		/// RescueKidnappedCharacterWithWitFail1
		/// </summary>
		public static LifeRecordItem RescueKidnappedCharacterWithWitFail1 => Instance[(short)181];

		/// <summary>
		/// RescueKidnappedCharacterWithWitFail2
		/// </summary>
		public static LifeRecordItem RescueKidnappedCharacterWithWitFail2 => Instance[(short)182];

		/// <summary>
		/// RescueKidnappedCharacterWithWitFail3
		/// </summary>
		public static LifeRecordItem RescueKidnappedCharacterWithWitFail3 => Instance[(short)183];

		/// <summary>
		/// RescueKidnappedCharacterWithWitFail4
		/// </summary>
		public static LifeRecordItem RescueKidnappedCharacterWithWitFail4 => Instance[(short)184];

		/// <summary>
		/// RescueKidnappedCharacterWithWitSucceed
		/// </summary>
		public static LifeRecordItem RescueKidnappedCharacterWithWitSucceed => Instance[(short)185];

		/// <summary>
		/// RescueKidnappedCharacterWithWitSucceedAndEscaped
		/// </summary>
		public static LifeRecordItem RescueKidnappedCharacterWithWitSucceedAndEscaped => Instance[(short)186];

		/// <summary>
		/// KidnappedCharacterGetRescuedWithWit
		/// </summary>
		public static LifeRecordItem KidnappedCharacterGetRescuedWithWit => Instance[(short)187];

		/// <summary>
		/// RescueKidnappedCharacterWithForceFail1
		/// </summary>
		public static LifeRecordItem RescueKidnappedCharacterWithForceFail1 => Instance[(short)188];

		/// <summary>
		/// RescueKidnappedCharacterWithForceFail2
		/// </summary>
		public static LifeRecordItem RescueKidnappedCharacterWithForceFail2 => Instance[(short)189];

		/// <summary>
		/// RescueKidnappedCharacterWithForceFail3
		/// </summary>
		public static LifeRecordItem RescueKidnappedCharacterWithForceFail3 => Instance[(short)190];

		/// <summary>
		/// RescueKidnappedCharacterWithForceFail4
		/// </summary>
		public static LifeRecordItem RescueKidnappedCharacterWithForceFail4 => Instance[(short)191];

		/// <summary>
		/// RescueKidnappedCharacterWithForceSucceed
		/// </summary>
		public static LifeRecordItem RescueKidnappedCharacterWithForceSucceed => Instance[(short)192];

		/// <summary>
		/// RescueKidnappedCharacterWithForceSucceedAndEscaped
		/// </summary>
		public static LifeRecordItem RescueKidnappedCharacterWithForceSucceedAndEscaped => Instance[(short)193];

		/// <summary>
		/// KidnappedCharacterGetRescuedWithForce
		/// </summary>
		public static LifeRecordItem KidnappedCharacterGetRescuedWithForce => Instance[(short)194];

		/// <summary>
		/// PoisonEnemyFail1
		/// </summary>
		public static LifeRecordItem PoisonEnemyFail1 => Instance[(short)195];

		/// <summary>
		/// PoisonEnemyFail2
		/// </summary>
		public static LifeRecordItem PoisonEnemyFail2 => Instance[(short)196];

		/// <summary>
		/// PoisonEnemyFail3
		/// </summary>
		public static LifeRecordItem PoisonEnemyFail3 => Instance[(short)197];

		/// <summary>
		/// PoisonEnemyFail4
		/// </summary>
		public static LifeRecordItem PoisonEnemyFail4 => Instance[(short)198];

		/// <summary>
		/// PoisonEnemySucceed
		/// </summary>
		public static LifeRecordItem PoisonEnemySucceed => Instance[(short)199];

		/// <summary>
		/// PoisonEnemySucceedAndEscaped
		/// </summary>
		public static LifeRecordItem PoisonEnemySucceedAndEscaped => Instance[(short)200];

		/// <summary>
		/// GetPoisonedByEnemySucceed
		/// </summary>
		public static LifeRecordItem GetPoisonedByEnemySucceed => Instance[(short)201];

		/// <summary>
		/// PlotHarmEnemyFail1
		/// </summary>
		public static LifeRecordItem PlotHarmEnemyFail1 => Instance[(short)202];

		/// <summary>
		/// PlotHarmEnemyFail2
		/// </summary>
		public static LifeRecordItem PlotHarmEnemyFail2 => Instance[(short)203];

		/// <summary>
		/// PlotHarmEnemyFail3
		/// </summary>
		public static LifeRecordItem PlotHarmEnemyFail3 => Instance[(short)204];

		/// <summary>
		/// PlotHarmEnemyFail4
		/// </summary>
		public static LifeRecordItem PlotHarmEnemyFail4 => Instance[(short)205];

		/// <summary>
		/// PlotHarmEnemySucceed
		/// </summary>
		public static LifeRecordItem PlotHarmEnemySucceed => Instance[(short)206];

		/// <summary>
		/// PlotHarmEnemySucceedAndEscaped
		/// </summary>
		public static LifeRecordItem PlotHarmEnemySucceedAndEscaped => Instance[(short)207];

		/// <summary>
		/// GetPlottedAgainstSucceed
		/// </summary>
		public static LifeRecordItem GetPlottedAgainstSucceed => Instance[(short)208];

		/// <summary>
		/// StealResourceFail1
		/// </summary>
		public static LifeRecordItem StealResourceFail1 => Instance[(short)209];

		/// <summary>
		/// StealResourceFail2
		/// </summary>
		public static LifeRecordItem StealResourceFail2 => Instance[(short)210];

		/// <summary>
		/// StealResourceFail3
		/// </summary>
		public static LifeRecordItem StealResourceFail3 => Instance[(short)211];

		/// <summary>
		/// StealResourceFail4
		/// </summary>
		public static LifeRecordItem StealResourceFail4 => Instance[(short)212];

		/// <summary>
		/// StealResourceSucceed
		/// </summary>
		public static LifeRecordItem StealResourceSucceed => Instance[(short)213];

		/// <summary>
		/// StealResourceSucceedAndEscaped
		/// </summary>
		public static LifeRecordItem StealResourceSucceedAndEscaped => Instance[(short)214];

		/// <summary>
		/// StealResourceFailAndBeatenUp
		/// </summary>
		public static LifeRecordItem StealResourceFailAndBeatenUp => Instance[(short)215];

		/// <summary>
		/// ResourceGetStolenSucceed
		/// </summary>
		public static LifeRecordItem ResourceGetStolenSucceed => Instance[(short)216];

		/// <summary>
		/// BeatUpResourceStealer
		/// </summary>
		public static LifeRecordItem BeatUpResourceStealer => Instance[(short)217];

		/// <summary>
		/// ScamResourceFail1
		/// </summary>
		public static LifeRecordItem ScamResourceFail1 => Instance[(short)218];

		/// <summary>
		/// ScamResourceFail2
		/// </summary>
		public static LifeRecordItem ScamResourceFail2 => Instance[(short)219];

		/// <summary>
		/// ScamResourceFail3
		/// </summary>
		public static LifeRecordItem ScamResourceFail3 => Instance[(short)220];

		/// <summary>
		/// ScamResourceFail4
		/// </summary>
		public static LifeRecordItem ScamResourceFail4 => Instance[(short)221];

		/// <summary>
		/// ScamResourceSucceed
		/// </summary>
		public static LifeRecordItem ScamResourceSucceed => Instance[(short)222];

		/// <summary>
		/// ScamResourceSucceedAndEscaped
		/// </summary>
		public static LifeRecordItem ScamResourceSucceedAndEscaped => Instance[(short)223];

		/// <summary>
		/// ScamResourceFailAndBeatenUp
		/// </summary>
		public static LifeRecordItem ScamResourceFailAndBeatenUp => Instance[(short)224];

		/// <summary>
		/// ResourceGetScammedSucceed
		/// </summary>
		public static LifeRecordItem ResourceGetScammedSucceed => Instance[(short)225];

		/// <summary>
		/// BeatUpResourceScammer
		/// </summary>
		public static LifeRecordItem BeatUpResourceScammer => Instance[(short)226];

		/// <summary>
		/// RobResourceFail1
		/// </summary>
		public static LifeRecordItem RobResourceFail1 => Instance[(short)227];

		/// <summary>
		/// RobResourceFail2
		/// </summary>
		public static LifeRecordItem RobResourceFail2 => Instance[(short)228];

		/// <summary>
		/// RobResourceFail3
		/// </summary>
		public static LifeRecordItem RobResourceFail3 => Instance[(short)229];

		/// <summary>
		/// RobResourceFail4
		/// </summary>
		public static LifeRecordItem RobResourceFail4 => Instance[(short)230];

		/// <summary>
		/// RobResourceSucceed
		/// </summary>
		public static LifeRecordItem RobResourceSucceed => Instance[(short)231];

		/// <summary>
		/// RobResourceSucceedAndEscaped
		/// </summary>
		public static LifeRecordItem RobResourceSucceedAndEscaped => Instance[(short)232];

		/// <summary>
		/// RobResourceFailAndBeatenUp
		/// </summary>
		public static LifeRecordItem RobResourceFailAndBeatenUp => Instance[(short)233];

		/// <summary>
		/// ResourceGetRobbedSucceed
		/// </summary>
		public static LifeRecordItem ResourceGetRobbedSucceed => Instance[(short)234];

		/// <summary>
		/// BeatUpResourceRobber
		/// </summary>
		public static LifeRecordItem BeatUpResourceRobber => Instance[(short)235];

		/// <summary>
		/// StealItemFail1
		/// </summary>
		public static LifeRecordItem StealItemFail1 => Instance[(short)236];

		/// <summary>
		/// StealItemFail2
		/// </summary>
		public static LifeRecordItem StealItemFail2 => Instance[(short)237];

		/// <summary>
		/// StealItemFail3
		/// </summary>
		public static LifeRecordItem StealItemFail3 => Instance[(short)238];

		/// <summary>
		/// StealItemFail4
		/// </summary>
		public static LifeRecordItem StealItemFail4 => Instance[(short)239];

		/// <summary>
		/// StealItemSucceed
		/// </summary>
		public static LifeRecordItem StealItemSucceed => Instance[(short)240];

		/// <summary>
		/// StealItemSucceedAndEscaped
		/// </summary>
		public static LifeRecordItem StealItemSucceedAndEscaped => Instance[(short)241];

		/// <summary>
		/// StealItemSucceedAndBeatenUp
		/// </summary>
		public static LifeRecordItem StealItemSucceedAndBeatenUp => Instance[(short)242];

		/// <summary>
		/// ItemGetStolenSucceed
		/// </summary>
		public static LifeRecordItem ItemGetStolenSucceed => Instance[(short)243];

		/// <summary>
		/// BeatUpItemStealer
		/// </summary>
		public static LifeRecordItem BeatUpItemStealer => Instance[(short)244];

		/// <summary>
		/// ScamItemFail1
		/// </summary>
		public static LifeRecordItem ScamItemFail1 => Instance[(short)245];

		/// <summary>
		/// ScamItemFail2
		/// </summary>
		public static LifeRecordItem ScamItemFail2 => Instance[(short)246];

		/// <summary>
		/// ScamItemFail3
		/// </summary>
		public static LifeRecordItem ScamItemFail3 => Instance[(short)247];

		/// <summary>
		/// ScamItemFail4
		/// </summary>
		public static LifeRecordItem ScamItemFail4 => Instance[(short)248];

		/// <summary>
		/// ScamItemSucceed
		/// </summary>
		public static LifeRecordItem ScamItemSucceed => Instance[(short)249];

		/// <summary>
		/// ScamItemSucceedAndEscaped
		/// </summary>
		public static LifeRecordItem ScamItemSucceedAndEscaped => Instance[(short)250];

		/// <summary>
		/// ScamItemFailAndBeatenUp
		/// </summary>
		public static LifeRecordItem ScamItemFailAndBeatenUp => Instance[(short)251];

		/// <summary>
		/// ItemGetScammedSucceed
		/// </summary>
		public static LifeRecordItem ItemGetScammedSucceed => Instance[(short)252];

		/// <summary>
		/// BeatUpItemScammer
		/// </summary>
		public static LifeRecordItem BeatUpItemScammer => Instance[(short)253];

		/// <summary>
		/// RobItemFail1
		/// </summary>
		public static LifeRecordItem RobItemFail1 => Instance[(short)254];

		/// <summary>
		/// RobItemFail2
		/// </summary>
		public static LifeRecordItem RobItemFail2 => Instance[(short)255];

		/// <summary>
		/// RobItemFail3
		/// </summary>
		public static LifeRecordItem RobItemFail3 => Instance[(short)256];

		/// <summary>
		/// RobItemFail4
		/// </summary>
		public static LifeRecordItem RobItemFail4 => Instance[(short)257];

		/// <summary>
		/// RobItemSucceed
		/// </summary>
		public static LifeRecordItem RobItemSucceed => Instance[(short)258];

		/// <summary>
		/// RobItemSucceedAndEscaped
		/// </summary>
		public static LifeRecordItem RobItemSucceedAndEscaped => Instance[(short)259];

		/// <summary>
		/// RobItemFailAndBeatenUp
		/// </summary>
		public static LifeRecordItem RobItemFailAndBeatenUp => Instance[(short)260];

		/// <summary>
		/// ItemGetRobbedSucceed
		/// </summary>
		public static LifeRecordItem ItemGetRobbedSucceed => Instance[(short)261];

		/// <summary>
		/// BeatUpItemRobber
		/// </summary>
		public static LifeRecordItem BeatUpItemRobber => Instance[(short)262];

		/// <summary>
		/// RobResourceFromGraveSucceed
		/// </summary>
		public static LifeRecordItem RobResourceFromGraveSucceed => Instance[(short)263];

		/// <summary>
		/// RobResourceFromGraveFail
		/// </summary>
		public static LifeRecordItem RobResourceFromGraveFail => Instance[(short)264];

		/// <summary>
		/// RobItemFromGraveSucceed
		/// </summary>
		public static LifeRecordItem RobItemFromGraveSucceed => Instance[(short)265];

		/// <summary>
		/// RobItemFromGraveFail
		/// </summary>
		public static LifeRecordItem RobItemFromGraveFail => Instance[(short)266];

		/// <summary>
		/// StealLifeSkillFail1
		/// </summary>
		public static LifeRecordItem StealLifeSkillFail1 => Instance[(short)267];

		/// <summary>
		/// StealLifeSkillFail2
		/// </summary>
		public static LifeRecordItem StealLifeSkillFail2 => Instance[(short)268];

		/// <summary>
		/// StealLifeSkillFail3
		/// </summary>
		public static LifeRecordItem StealLifeSkillFail3 => Instance[(short)269];

		/// <summary>
		/// StealLifeSkillFail4
		/// </summary>
		public static LifeRecordItem StealLifeSkillFail4 => Instance[(short)270];

		/// <summary>
		/// StealLifeSkillSucceed
		/// </summary>
		public static LifeRecordItem StealLifeSkillSucceed => Instance[(short)271];

		/// <summary>
		/// StealLifeSkillSucceedAndEscaped
		/// </summary>
		public static LifeRecordItem StealLifeSkillSucceedAndEscaped => Instance[(short)272];

		/// <summary>
		/// LifeSkillGetStolenSucceed
		/// </summary>
		public static LifeRecordItem LifeSkillGetStolenSucceed => Instance[(short)273];

		/// <summary>
		/// ScamLifeSkillFail1
		/// </summary>
		public static LifeRecordItem ScamLifeSkillFail1 => Instance[(short)274];

		/// <summary>
		/// ScamLifeSkillFail2
		/// </summary>
		public static LifeRecordItem ScamLifeSkillFail2 => Instance[(short)275];

		/// <summary>
		/// ScamLifeSkillFail3
		/// </summary>
		public static LifeRecordItem ScamLifeSkillFail3 => Instance[(short)276];

		/// <summary>
		/// ScamLifeSkillFail4
		/// </summary>
		public static LifeRecordItem ScamLifeSkillFail4 => Instance[(short)277];

		/// <summary>
		/// ScamLifeSkillSucceed
		/// </summary>
		public static LifeRecordItem ScamLifeSkillSucceed => Instance[(short)278];

		/// <summary>
		/// ScamLifeSkillSucceedAndEscaped
		/// </summary>
		public static LifeRecordItem ScamLifeSkillSucceedAndEscaped => Instance[(short)279];

		/// <summary>
		/// LifeSkillGetScammedSucceed
		/// </summary>
		public static LifeRecordItem LifeSkillGetScammedSucceed => Instance[(short)280];

		/// <summary>
		/// StealCombatSkillFail1
		/// </summary>
		public static LifeRecordItem StealCombatSkillFail1 => Instance[(short)281];

		/// <summary>
		/// StealCombatSkillFail2
		/// </summary>
		public static LifeRecordItem StealCombatSkillFail2 => Instance[(short)282];

		/// <summary>
		/// StealCombatSkillFail3
		/// </summary>
		public static LifeRecordItem StealCombatSkillFail3 => Instance[(short)283];

		/// <summary>
		/// StealCombatSkillFail4
		/// </summary>
		public static LifeRecordItem StealCombatSkillFail4 => Instance[(short)284];

		/// <summary>
		/// StealCombatSkillSucceed
		/// </summary>
		public static LifeRecordItem StealCombatSkillSucceed => Instance[(short)285];

		/// <summary>
		/// StealCombatSkillSucceedAndEscaped
		/// </summary>
		public static LifeRecordItem StealCombatSkillSucceedAndEscaped => Instance[(short)286];

		/// <summary>
		/// CombatSkillGetStolenSucceed
		/// </summary>
		public static LifeRecordItem CombatSkillGetStolenSucceed => Instance[(short)287];

		/// <summary>
		/// ScamCombatSkillFail1
		/// </summary>
		public static LifeRecordItem ScamCombatSkillFail1 => Instance[(short)288];

		/// <summary>
		/// ScamCombatSkillFail2
		/// </summary>
		public static LifeRecordItem ScamCombatSkillFail2 => Instance[(short)289];

		/// <summary>
		/// ScamCombatSkillFail3
		/// </summary>
		public static LifeRecordItem ScamCombatSkillFail3 => Instance[(short)290];

		/// <summary>
		/// ScamCombatSkillFail4
		/// </summary>
		public static LifeRecordItem ScamCombatSkillFail4 => Instance[(short)291];

		/// <summary>
		/// ScamCombatSkillSucceed
		/// </summary>
		public static LifeRecordItem ScamCombatSkillSucceed => Instance[(short)292];

		/// <summary>
		/// ScamCombatSkillSucceedAndEscaped
		/// </summary>
		public static LifeRecordItem ScamCombatSkillSucceedAndEscaped => Instance[(short)293];

		/// <summary>
		/// CombatSkillGetScammedSucceed
		/// </summary>
		public static LifeRecordItem CombatSkillGetScammedSucceed => Instance[(short)294];

		/// <summary>
		/// LifeSkillBattleWin
		/// </summary>
		public static LifeRecordItem LifeSkillBattleWin => Instance[(short)295];

		/// <summary>
		/// LifeSkillBattleLose
		/// </summary>
		public static LifeRecordItem LifeSkillBattleLose => Instance[(short)296];

		/// <summary>
		/// ExchangeResource
		/// </summary>
		public static LifeRecordItem ExchangeResource => Instance[(short)297];

		/// <summary>
		/// GiveResource
		/// </summary>
		public static LifeRecordItem GiveResource => Instance[(short)298];

		/// <summary>
		/// PurchaseItem
		/// </summary>
		public static LifeRecordItem PurchaseItem => Instance[(short)299];

		/// <summary>
		/// SellItem
		/// </summary>
		public static LifeRecordItem SellItem => Instance[(short)300];

		/// <summary>
		/// GiveItem
		/// </summary>
		public static LifeRecordItem GiveItem => Instance[(short)301];

		/// <summary>
		/// GivePoisonousItem
		/// </summary>
		public static LifeRecordItem GivePoisonousItem => Instance[(short)302];

		/// <summary>
		/// GetResourceAsGift
		/// </summary>
		public static LifeRecordItem GetResourceAsGift => Instance[(short)303];

		/// <summary>
		/// GetItemAsGift
		/// </summary>
		public static LifeRecordItem GetItemAsGift => Instance[(short)304];

		/// <summary>
		/// RefusePoisonousGift
		/// </summary>
		public static LifeRecordItem RefusePoisonousGift => Instance[(short)305];

		/// <summary>
		/// InstructLifeSkill
		/// </summary>
		public static LifeRecordItem InstructLifeSkill => Instance[(short)306];

		/// <summary>
		/// InstructCombatSkill
		/// </summary>
		public static LifeRecordItem InstructCombatSkill => Instance[(short)307];

		/// <summary>
		/// LearnLifeSkillWithInstructionSucceed
		/// </summary>
		public static LifeRecordItem LearnLifeSkillWithInstructionSucceed => Instance[(short)308];

		/// <summary>
		/// LearnLifeSkillWithInstructionFail
		/// </summary>
		public static LifeRecordItem LearnLifeSkillWithInstructionFail => Instance[(short)309];

		/// <summary>
		/// LearnCombatSkillWithInstructionSucceed
		/// </summary>
		public static LifeRecordItem LearnCombatSkillWithInstructionSucceed => Instance[(short)310];

		/// <summary>
		/// LearnCombatSkillWithInstructionFail
		/// </summary>
		public static LifeRecordItem LearnCombatSkillWithInstructionFail => Instance[(short)311];

		/// <summary>
		/// InviteToDrinkSucceed
		/// </summary>
		public static LifeRecordItem InviteToDrinkSucceed => Instance[(short)312];

		/// <summary>
		/// InviteToDrinkFail
		/// </summary>
		public static LifeRecordItem InviteToDrinkFail => Instance[(short)313];

		/// <summary>
		/// SellSucceed
		/// </summary>
		public static LifeRecordItem SellSucceed => Instance[(short)314];

		/// <summary>
		/// SellFail
		/// </summary>
		public static LifeRecordItem SellFail => Instance[(short)315];

		/// <summary>
		/// CureSucceed
		/// </summary>
		public static LifeRecordItem CureSucceed => Instance[(short)316];

		/// <summary>
		/// RepairItemSucceed
		/// </summary>
		public static LifeRecordItem RepairItemSucceed => Instance[(short)317];

		/// <summary>
		/// BarbSucceed
		/// </summary>
		public static LifeRecordItem BarbSucceed => Instance[(short)318];

		/// <summary>
		/// BarbMistake
		/// </summary>
		public static LifeRecordItem BarbMistake => Instance[(short)319];

		/// <summary>
		/// BarbFail
		/// </summary>
		public static LifeRecordItem BarbFail => Instance[(short)320];

		/// <summary>
		/// AskForMoneySucceed
		/// </summary>
		public static LifeRecordItem AskForMoneySucceed => Instance[(short)321];

		/// <summary>
		/// AskForMoneyFail
		/// </summary>
		public static LifeRecordItem AskForMoneyFail => Instance[(short)322];

		/// <summary>
		/// EntertainWithMusic
		/// </summary>
		public static LifeRecordItem EntertainWithMusic => Instance[(short)323];

		/// <summary>
		/// EntertainWithChess
		/// </summary>
		public static LifeRecordItem EntertainWithChess => Instance[(short)324];

		/// <summary>
		/// EntertainWithPoem
		/// </summary>
		public static LifeRecordItem EntertainWithPoem => Instance[(short)325];

		/// <summary>
		/// EntertainWithPainting
		/// </summary>
		public static LifeRecordItem EntertainWithPainting => Instance[(short)326];

		/// <summary>
		/// AcceptInviteToDrink
		/// </summary>
		public static LifeRecordItem AcceptInviteToDrink => Instance[(short)327];

		/// <summary>
		/// RefuseInviteToDrink
		/// </summary>
		public static LifeRecordItem RefuseInviteToDrink => Instance[(short)328];

		/// <summary>
		/// AcceptSell
		/// </summary>
		public static LifeRecordItem AcceptSell => Instance[(short)329];

		/// <summary>
		/// RefuseSell
		/// </summary>
		public static LifeRecordItem RefuseSell => Instance[(short)330];

		/// <summary>
		/// AcceptCure
		/// </summary>
		public static LifeRecordItem AcceptCure => Instance[(short)331];

		/// <summary>
		/// AcceptRepairItem
		/// </summary>
		public static LifeRecordItem AcceptRepairItem => Instance[(short)332];

		/// <summary>
		/// GetBarbSucceed
		/// </summary>
		public static LifeRecordItem GetBarbSucceed => Instance[(short)333];

		/// <summary>
		/// GetBarbMistake
		/// </summary>
		public static LifeRecordItem GetBarbMistake => Instance[(short)334];

		/// <summary>
		/// GetBarbFail
		/// </summary>
		public static LifeRecordItem GetBarbFail => Instance[(short)335];

		/// <summary>
		/// AcceptAskForMoney
		/// </summary>
		public static LifeRecordItem AcceptAskForMoney => Instance[(short)336];

		/// <summary>
		/// RefuseAskForMoney
		/// </summary>
		public static LifeRecordItem RefuseAskForMoney => Instance[(short)337];

		/// <summary>
		/// AcceptEntertainWithMusic
		/// </summary>
		public static LifeRecordItem AcceptEntertainWithMusic => Instance[(short)338];

		/// <summary>
		/// AcceptEntertainWithChess
		/// </summary>
		public static LifeRecordItem AcceptEntertainWithChess => Instance[(short)339];

		/// <summary>
		/// AcceptEntertainWithPoem
		/// </summary>
		public static LifeRecordItem AcceptEntertainWithPoem => Instance[(short)340];

		/// <summary>
		/// AcceptEntertainWithPainting
		/// </summary>
		public static LifeRecordItem AcceptEntertainWithPainting => Instance[(short)341];

		/// <summary>
		/// MakeItem
		/// </summary>
		public static LifeRecordItem MakeItem => Instance[(short)342];

		/// <summary>
		/// TaoismAwakeningSucceed
		/// </summary>
		public static LifeRecordItem TaoismAwakeningSucceed => Instance[(short)343];

		/// <summary>
		/// TaoismAwakeningFail
		/// </summary>
		public static LifeRecordItem TaoismAwakeningFail => Instance[(short)344];

		/// <summary>
		/// BuddismAwakeningSucceed
		/// </summary>
		public static LifeRecordItem BuddismAwakeningSucceed => Instance[(short)345];

		/// <summary>
		/// BuddismAwakeningFail
		/// </summary>
		public static LifeRecordItem BuddismAwakeningFail => Instance[(short)346];

		/// <summary>
		/// TaoismGetAwakenedSucceed
		/// </summary>
		public static LifeRecordItem TaoismGetAwakenedSucceed => Instance[(short)347];

		/// <summary>
		/// TaoismGetAwakenedFail
		/// </summary>
		public static LifeRecordItem TaoismGetAwakenedFail => Instance[(short)348];

		/// <summary>
		/// BuddismGetAwakenedSucceed
		/// </summary>
		public static LifeRecordItem BuddismGetAwakenedSucceed => Instance[(short)349];

		/// <summary>
		/// BuddismGetAwakenedFail
		/// </summary>
		public static LifeRecordItem BuddismGetAwakenedFail => Instance[(short)350];

		/// <summary>
		/// CollectTeaWineSucceed
		/// </summary>
		public static LifeRecordItem CollectTeaWineSucceed => Instance[(short)351];

		/// <summary>
		/// CollectTeaWineFail
		/// </summary>
		public static LifeRecordItem CollectTeaWineFail => Instance[(short)352];

		/// <summary>
		/// DivinationSucceed
		/// </summary>
		public static LifeRecordItem DivinationSucceed => Instance[(short)353];

		/// <summary>
		/// DivinationFail
		/// </summary>
		public static LifeRecordItem DivinationFail => Instance[(short)354];

		/// <summary>
		/// CricketBattleWin
		/// </summary>
		public static LifeRecordItem CricketBattleWin => Instance[(short)355];

		/// <summary>
		/// CricketBattleLose
		/// </summary>
		public static LifeRecordItem CricketBattleLose => Instance[(short)356];

		/// <summary>
		/// MakeLoveLegal
		/// </summary>
		public static LifeRecordItem MakeLoveLegal => Instance[(short)1401];

		/// <summary>
		/// MakeLoveIllegal
		/// </summary>
		public static LifeRecordItem MakeLoveIllegal => Instance[(short)357];

		/// <summary>
		/// RapeFail
		/// </summary>
		public static LifeRecordItem RapeFail => Instance[(short)358];

		/// <summary>
		/// RapeSucceed
		/// </summary>
		public static LifeRecordItem RapeSucceed => Instance[(short)359];

		/// <summary>
		/// ReleaseKidnappedCharacter
		/// </summary>
		public static LifeRecordItem ReleaseKidnappedCharacter => Instance[(short)360];

		/// <summary>
		/// GetRapedFail
		/// </summary>
		public static LifeRecordItem GetRapedFail => Instance[(short)361];

		/// <summary>
		/// GetRapedSucceed
		/// </summary>
		public static LifeRecordItem GetRapedSucceed => Instance[(short)362];

		/// <summary>
		/// GetReleasedByKidnapper
		/// </summary>
		public static LifeRecordItem GetReleasedByKidnapper => Instance[(short)363];

		/// <summary>
		/// MerchantGetNewProduct
		/// </summary>
		public static LifeRecordItem MerchantGetNewProduct => Instance[(short)364];

		/// <summary>
		/// UnexpectedResourceGain
		/// </summary>
		public static LifeRecordItem UnexpectedResourceGain => Instance[(short)365];

		/// <summary>
		/// UnexpectedItemGain
		/// </summary>
		public static LifeRecordItem UnexpectedItemGain => Instance[(short)366];

		/// <summary>
		/// UnexpectedSkillBookGain
		/// </summary>
		public static LifeRecordItem UnexpectedSkillBookGain => Instance[(short)367];

		/// <summary>
		/// UnexpectedHealthCure
		/// </summary>
		public static LifeRecordItem UnexpectedHealthCure => Instance[(short)368];

		/// <summary>
		/// UnexpectedOuterInjuryCure
		/// </summary>
		public static LifeRecordItem UnexpectedOuterInjuryCure => Instance[(short)369];

		/// <summary>
		/// UnexpectedInnerInjuryCure
		/// </summary>
		public static LifeRecordItem UnexpectedInnerInjuryCure => Instance[(short)370];

		/// <summary>
		/// UnexpectedPoisonCure
		/// </summary>
		public static LifeRecordItem UnexpectedPoisonCure => Instance[(short)371];

		/// <summary>
		/// UnexpectedDisorderOfQiCure
		/// </summary>
		public static LifeRecordItem UnexpectedDisorderOfQiCure => Instance[(short)372];

		/// <summary>
		/// UnexpectedResourceLose
		/// </summary>
		public static LifeRecordItem UnexpectedResourceLose => Instance[(short)373];

		/// <summary>
		/// UnexpectedItemLose
		/// </summary>
		public static LifeRecordItem UnexpectedItemLose => Instance[(short)374];

		/// <summary>
		/// UnexpectedSkillBookLose
		/// </summary>
		public static LifeRecordItem UnexpectedSkillBookLose => Instance[(short)375];

		/// <summary>
		/// UnexpectedInjure
		/// </summary>
		public static LifeRecordItem UnexpectedHealthHarm => Instance[(short)376];

		/// <summary>
		/// UnexpectedOuterInjuryHarm
		/// </summary>
		public static LifeRecordItem UnexpectedOuterInjuryHarm => Instance[(short)377];

		/// <summary>
		/// UnexpectedInnerInjuryHarm
		/// </summary>
		public static LifeRecordItem UnexpectedInnerInjuryHarm => Instance[(short)378];

		/// <summary>
		/// UnexpectedPoisonHarm
		/// </summary>
		public static LifeRecordItem UnexpectedPoisonHarm => Instance[(short)379];

		/// <summary>
		/// UnexpectedDisorderOfQiHarm
		/// </summary>
		public static LifeRecordItem UnexpectedDisorderOfQiHarm => Instance[(short)380];

		/// <summary>
		/// KillHereticRandomEnemy
		/// </summary>
		public static LifeRecordItem KillHereticRandomEnemy => Instance[(short)381];

		/// <summary>
		/// KillRighteousRandomEnemy
		/// </summary>
		public static LifeRecordItem KillRighteousRandomEnemy => Instance[(short)382];

		/// <summary>
		/// DefeatedByHereticRandomEnemy
		/// </summary>
		public static LifeRecordItem DefeatedByHereticRandomEnemy => Instance[(short)383];

		/// <summary>
		/// DefeatedByRighteousRandomEnemy
		/// </summary>
		public static LifeRecordItem DefeatedByRighteousRandomEnemy => Instance[(short)384];

		/// <summary>
		/// MonvBad
		/// </summary>
		public static LifeRecordItem MonvBad => Instance[(short)385];

		/// <summary>
		/// DayueYaochangBad
		/// </summary>
		public static LifeRecordItem DayueYaochangBad => Instance[(short)386];

		/// <summary>
		/// JinHuangerBad
		/// </summary>
		public static LifeRecordItem JinHuangerBad => Instance[(short)387];

		/// <summary>
		/// YiyihouBad
		/// </summary>
		public static LifeRecordItem YiyihouBad => Instance[(short)388];

		/// <summary>
		/// WeiQiBad
		/// </summary>
		public static LifeRecordItem WeiQiBad => Instance[(short)389];

		/// <summary>
		/// YixiangBad
		/// </summary>
		public static LifeRecordItem YixiangBad => Instance[(short)390];

		/// <summary>
		/// ShufangBad
		/// </summary>
		public static LifeRecordItem ShufangBad => Instance[(short)391];

		/// <summary>
		/// JixiBad
		/// </summary>
		public static LifeRecordItem JixiBad => Instance[(short)392];

		/// <summary>
		/// MonvGood
		/// </summary>
		public static LifeRecordItem MonvGood => Instance[(short)393];

		/// <summary>
		/// DayueYaochangGood
		/// </summary>
		public static LifeRecordItem DayueYaochangGood => Instance[(short)394];

		/// <summary>
		/// JinHuangerGood
		/// </summary>
		public static LifeRecordItem JinHuangerGood => Instance[(short)395];

		/// <summary>
		/// YiyihouGood
		/// </summary>
		public static LifeRecordItem YiyihouGood => Instance[(short)396];

		/// <summary>
		/// WeiQiGood
		/// </summary>
		public static LifeRecordItem WeiQiGood => Instance[(short)397];

		/// <summary>
		/// YixiangGood
		/// </summary>
		public static LifeRecordItem YixiangGood => Instance[(short)398];

		/// <summary>
		/// XuefengGood
		/// </summary>
		public static LifeRecordItem XuefengGood => Instance[(short)399];

		/// <summary>
		/// ShufangGood
		/// </summary>
		public static LifeRecordItem ShufangGood => Instance[(short)400];

		/// <summary>
		/// PregnantWithSamsara0
		/// </summary>
		public static LifeRecordItem PregnantWithSamsara0 => Instance[(short)401];

		/// <summary>
		/// PregnantWithSamsara1
		/// </summary>
		public static LifeRecordItem PregnantWithSamsara1 => Instance[(short)402];

		/// <summary>
		/// PregnantWithSamsara2
		/// </summary>
		public static LifeRecordItem PregnantWithSamsara2 => Instance[(short)403];

		/// <summary>
		/// PregnantWithSamsara3
		/// </summary>
		public static LifeRecordItem PregnantWithSamsara3 => Instance[(short)404];

		/// <summary>
		/// PregnantWithSamsara4
		/// </summary>
		public static LifeRecordItem PregnantWithSamsara4 => Instance[(short)405];

		/// <summary>
		/// PregnantWithSamsara5
		/// </summary>
		public static LifeRecordItem PregnantWithSamsara5 => Instance[(short)406];

		/// <summary>
		/// GainAuthority
		/// </summary>
		public static LifeRecordItem GainAuthority => Instance[(short)407];

		/// <summary>
		/// SectPunishNormal
		/// </summary>
		public static LifeRecordItem SectPunishNormal => Instance[(short)408];

		/// <summary>
		/// SectPunishElope
		/// </summary>
		public static LifeRecordItem SectPunishElope => Instance[(short)409];

		/// <summary>
		/// ExpelVillager
		/// </summary>
		public static LifeRecordItem ExpelVillager => Instance[(short)410];

		/// <summary>
		/// SavedFromInfection
		/// </summary>
		public static LifeRecordItem SavedFromInfection => Instance[(short)411];

		/// <summary>
		/// ChangeGrade
		/// </summary>
		public static LifeRecordItem ChangeGrade => Instance[(short)412];

		/// <summary>
		/// AutoChangeGrade
		/// </summary>
		public static LifeRecordItem AutoChangeGrade => Instance[(short)1414];

		/// <summary>
		/// ExpelledByTaiwu
		/// </summary>
		public static LifeRecordItem ExpelledByTaiwu => Instance[(short)413];

		/// <summary>
		/// InsteadSectPunishElope
		/// </summary>
		public static LifeRecordItem InsteadSectPunishElope => Instance[(short)414];

		/// <summary>
		/// AvoidSectPunishElope
		/// </summary>
		public static LifeRecordItem AvoidSectPunishElope => Instance[(short)415];

		/// <summary>
		/// JoinJoustForSpouse
		/// </summary>
		public static LifeRecordItem JoinJoustForSpouse => Instance[(short)416];

		/// <summary>
		/// GetHusbandByJoustForSpouse
		/// </summary>
		public static LifeRecordItem GetHusbandByJoustForSpouse => Instance[(short)417];

		/// <summary>
		/// GetWifeByJoustForSpouse
		/// </summary>
		public static LifeRecordItem GetWifeByJoustForSpouse => Instance[(short)418];

		/// <summary>
		/// NoHusbandByJoustForSpouse
		/// </summary>
		public static LifeRecordItem NoHusbandByJoustForSpouse => Instance[(short)419];

		/// <summary>
		/// SectCompetitionBeWinner
		/// </summary>
		public static LifeRecordItem SectCompetitionBeWinner => Instance[(short)420];

		/// <summary>
		/// SectCompetitionBeParticipant
		/// </summary>
		public static LifeRecordItem SectCompetitionBeParticipant => Instance[(short)421];

		/// <summary>
		/// SectCompetitionBeHost
		/// </summary>
		public static LifeRecordItem SectCompetitionBeHost => Instance[(short)422];

		/// <summary>
		/// WulinConferenceBeParticipant
		/// </summary>
		public static LifeRecordItem WulinConferenceBeParticipant => Instance[(short)423];

		/// <summary>
		/// WulinConferenceBeWinner
		/// </summary>
		public static LifeRecordItem WulinConferenceBeWinner => Instance[(short)424];

		/// <summary>
		/// WulinConferenceBeWinnerButTaiwu
		/// </summary>
		public static LifeRecordItem WulinConferenceBeWinnerButTaiwu => Instance[(short)425];

		/// <summary>
		/// WulinConferenceBeHost
		/// </summary>
		public static LifeRecordItem WulinConferenceBeHost => Instance[(short)426];

		/// <summary>
		/// WulinConferenceBeKilledByYufu
		/// </summary>
		public static LifeRecordItem WulinConferenceBeKilledByYufu => Instance[(short)427];

		/// <summary>
		/// WulinConferenceDonation
		/// </summary>
		public static LifeRecordItem WulinConferenceDonation => Instance[(short)428];

		/// <summary>
		/// BeAttackedAndDieByWuYingLing
		/// </summary>
		public static LifeRecordItem BeAttackedAndDieByWuYingLing => Instance[(short)429];

		/// <summary>
		/// NaturalDisasterGiveDeath
		/// </summary>
		public static LifeRecordItem NaturalDisasterGiveDeath => Instance[(short)430];

		/// <summary>
		/// NaturalDisasterHappen
		/// </summary>
		public static LifeRecordItem NaturalDisasterHappen => Instance[(short)431];

		/// <summary>
		/// NaturalDisasterButSurvive
		/// </summary>
		public static LifeRecordItem NaturalDisasterButSurvive => Instance[(short)432];

		/// <summary>
		/// NormalInformationChangeLovingItemSubType
		/// </summary>
		public static LifeRecordItem NormalInformationChangeLovingItemSubType => Instance[(short)433];

		/// <summary>
		/// NormalInformationChangeHatingItemSubType
		/// </summary>
		public static LifeRecordItem NormalInformationChangeHatingItemSubType => Instance[(short)434];

		/// <summary>
		/// NormalInformationChangeIdealSect
		/// </summary>
		public static LifeRecordItem NormalInformationChangeIdealSect => Instance[(short)435];

		/// <summary>
		/// NormalInformationChangeBaseMorality
		/// </summary>
		public static LifeRecordItem NormalInformationChangeBaseMorality => Instance[(short)436];

		/// <summary>
		/// NormalInformationChangeLifeSkillTypeInterest
		/// </summary>
		public static LifeRecordItem NormalInformationChangeLifeSkillTypeInterest => Instance[(short)437];

		/// <summary>
		/// RobGraveEncounterSkeleton
		/// </summary>
		public static LifeRecordItem RobGraveEncounterSkeleton => Instance[(short)438];

		/// <summary>
		/// RobGraveFailed
		/// </summary>
		public static LifeRecordItem RobGraveFailed => Instance[(short)439];

		/// <summary>
		/// SectPunishLevelLowest
		/// </summary>
		public static LifeRecordItem SectPunishLevelLowest => Instance[(short)440];

		/// <summary>
		/// PrincipalSectPunishLevelMiddle
		/// </summary>
		public static LifeRecordItem PrincipalSectPunishLevelMiddle => Instance[(short)441];

		/// <summary>
		/// PrincipalSectPunishLevelHighest
		/// </summary>
		public static LifeRecordItem PrincipalSectPunishLevelHighest => Instance[(short)442];

		/// <summary>
		/// NonPrincipalSectPunishLevelLowest
		/// </summary>
		public static LifeRecordItem NonPrincipalSectPunishLevelLowest => Instance[(short)443];

		/// <summary>
		/// NonPrincipalSectPunishLevelHighest
		/// </summary>
		public static LifeRecordItem NonPrincipalSectPunishLevelHighest => Instance[(short)444];

		/// <summary>
		/// BecomeSwornSiblingByThreatened
		/// </summary>
		public static LifeRecordItem BecomeSwornSiblingByThreatened => Instance[(short)445];

		/// <summary>
		/// MarriedByThreatened
		/// </summary>
		public static LifeRecordItem MarriedByThreatened => Instance[(short)446];

		/// <summary>
		/// GetAdoptedFatherByThreatened
		/// </summary>
		public static LifeRecordItem GetAdoptedFatherByThreatened => Instance[(short)447];

		/// <summary>
		/// GetAdoptedMotherByThreatened
		/// </summary>
		public static LifeRecordItem GetAdoptedMotherByThreatened => Instance[(short)448];

		/// <summary>
		/// GetAdoptedSonByThreatened
		/// </summary>
		public static LifeRecordItem GetAdoptedSonByThreatened => Instance[(short)449];

		/// <summary>
		/// GetAdoptedDaughterByThreatened
		/// </summary>
		public static LifeRecordItem GetAdoptedDaughterByThreatened => Instance[(short)450];

		/// <summary>
		/// AddMentorByThreatened
		/// </summary>
		public static LifeRecordItem AddMentorByThreatened => Instance[(short)451];

		/// <summary>
		/// SeverSwornSiblingByThreatened
		/// </summary>
		public static LifeRecordItem SeverSwornSiblingByThreatened => Instance[(short)452];

		/// <summary>
		/// DivorceByThreatened
		/// </summary>
		public static LifeRecordItem DivorceByThreatened => Instance[(short)453];

		/// <summary>
		/// SeverMentorByThreatened
		/// </summary>
		public static LifeRecordItem SeverMentorByThreatened => Instance[(short)454];

		/// <summary>
		/// SeverAdoptiveFatherByThreatened
		/// </summary>
		public static LifeRecordItem SeverAdoptiveFatherByThreatened => Instance[(short)455];

		/// <summary>
		/// SeverAdoptiveMotherByThreatened
		/// </summary>
		public static LifeRecordItem SeverAdoptiveMotherByThreatened => Instance[(short)456];

		/// <summary>
		/// SeverAdoptiveSonByThreatened
		/// </summary>
		public static LifeRecordItem SeverAdoptiveSonByThreatened => Instance[(short)457];

		/// <summary>
		/// SeverAdoptiveDaughterByThreatened
		/// </summary>
		public static LifeRecordItem SeverAdoptiveDaughterByThreatened => Instance[(short)458];

		/// <summary>
		/// GetThreatenedAdoptiveFather
		/// </summary>
		public static LifeRecordItem GetThreatenedAdoptiveFather => Instance[(short)459];

		/// <summary>
		/// GetThreatenedAdoptiveMother
		/// </summary>
		public static LifeRecordItem GetThreatenedAdoptiveMother => Instance[(short)460];

		/// <summary>
		/// GetThreatenedAdoptiveSon
		/// </summary>
		public static LifeRecordItem GetThreatenedAdoptiveSon => Instance[(short)461];

		/// <summary>
		/// GetThreatenedAdoptiveDaughter
		/// </summary>
		public static LifeRecordItem GetThreatenedAdoptiveDaughter => Instance[(short)462];

		/// <summary>
		/// ApproveTaiwuByThreatened
		/// </summary>
		public static LifeRecordItem ApproveTaiwuByThreatened => Instance[(short)463];

		/// <summary>
		/// FourSeasonsAdventureBeParticipant
		/// </summary>
		public static LifeRecordItem FourSeasonsAdventureBeParticipant => Instance[(short)464];

		/// <summary>
		/// FourSeasonsAdventureBeWinner
		/// </summary>
		public static LifeRecordItem FourSeasonsAdventureBeWinner => Instance[(short)465];

		/// <summary>
		/// EndAdored
		/// </summary>
		public static LifeRecordItem EndAdored => Instance[(short)466];

		/// <summary>
		/// GetMentor
		/// </summary>
		public static LifeRecordItem GetMentor => Instance[(short)467];

		/// <summary>
		/// GetMentee
		/// </summary>
		public static LifeRecordItem GetMentee => Instance[(short)468];

		/// <summary>
		/// SeverAdoptiveParent
		/// </summary>
		public static LifeRecordItem SeverAdoptiveParent => Instance[(short)469];

		/// <summary>
		/// SeverAdoptiveChild
		/// </summary>
		public static LifeRecordItem SeverAdoptiveChild => Instance[(short)470];

		/// <summary>
		/// SeverMentor
		/// </summary>
		public static LifeRecordItem SeverMentor => Instance[(short)471];

		/// <summary>
		/// SeverMentee
		/// </summary>
		public static LifeRecordItem SeverMentee => Instance[(short)472];

		/// <summary>
		/// Divorce
		/// </summary>
		public static LifeRecordItem Divorce => Instance[(short)473];

		/// <summary>
		/// ThreatenSucceed
		/// </summary>
		public static LifeRecordItem ThreatenSucceed => Instance[(short)474];

		/// <summary>
		/// AdmonishSucceed
		/// </summary>
		public static LifeRecordItem AdmonishSucceed => Instance[(short)475];

		/// <summary>
		/// ChangeBehaviorTypeByAdmonishedGood
		/// </summary>
		public static LifeRecordItem ChangeBehaviorTypeByAdmonishedGood => Instance[(short)476];

		/// <summary>
		/// ReduceDebtByAdmonished
		/// </summary>
		public static LifeRecordItem ReduceDebtByAdmonished => Instance[(short)477];

		/// <summary>
		/// ReduceDebtByThreatened
		/// </summary>
		public static LifeRecordItem ReduceDebtByThreatened => Instance[(short)478];

		/// <summary>
		/// ChangeBehaviorTypeByAdmonishedBad
		/// </summary>
		public static LifeRecordItem ChangeBehaviorTypeByAdmonishedBad => Instance[(short)479];

		/// <summary>
		/// GainLegendaryBook
		/// </summary>
		public static LifeRecordItem GainLegendaryBook => Instance[(short)480];

		/// <summary>
		/// BoostedByLegendaryBooks
		/// </summary>
		public static LifeRecordItem BoostedByLegendaryBooks => Instance[(short)481];

		/// <summary>
		/// ActCrazy
		/// </summary>
		public static LifeRecordItem ActCrazy => Instance[(short)482];

		/// <summary>
		/// LegendaryBookShocked
		/// </summary>
		public static LifeRecordItem LegendaryBookShocked => Instance[(short)483];

		/// <summary>
		/// LegendaryBookInsane
		/// </summary>
		public static LifeRecordItem LegendaryBookInsane => Instance[(short)484];

		/// <summary>
		/// LegendaryBookConsumed
		/// </summary>
		public static LifeRecordItem LegendaryBookConsumed => Instance[(short)485];

		/// <summary>
		/// DecideToContestForLegendaryBook
		/// </summary>
		public static LifeRecordItem DecideToContestForLegendaryBook => Instance[(short)486];

		/// <summary>
		/// FinishContestForLegendaryBook
		/// </summary>
		public static LifeRecordItem FinishContestForLegendaryBook => Instance[(short)487];

		/// <summary>
		/// LegendaryBookChallengeWin
		/// </summary>
		public static LifeRecordItem LegendaryBookChallengeWin => Instance[(short)488];

		/// <summary>
		/// LegendaryBookChallengeLose
		/// </summary>
		public static LifeRecordItem LegendaryBookChallengeLose => Instance[(short)489];

		/// <summary>
		/// AcceptLegendaryBookChallengeWin
		/// </summary>
		public static LifeRecordItem AcceptLegendaryBookChallengeWin => Instance[(short)490];

		/// <summary>
		/// AcceptLegendaryBookChallengeLose
		/// </summary>
		public static LifeRecordItem AcceptLegendaryBookChallengeLose => Instance[(short)491];

		/// <summary>
		/// AcceptLegendaryBookChallengeEscape
		/// </summary>
		public static LifeRecordItem AcceptLegendaryBookChallengeEscape => Instance[(short)492];

		/// <summary>
		/// LegendaryBookChallengeEscaped
		/// </summary>
		public static LifeRecordItem LegendaryBookChallengeEscaped => Instance[(short)493];

		/// <summary>
		/// LegendaryBookChallengeSelfEscaped
		/// </summary>
		public static LifeRecordItem LegendaryBookChallengeSelfEscaped => Instance[(short)494];

		/// <summary>
		/// AcceptLegendaryBookChallengeEnemyEscaped
		/// </summary>
		public static LifeRecordItem AcceptLegendaryBookChallengeEnemyEscaped => Instance[(short)495];

		/// <summary>
		/// RefuseRequestLegendaryBookChallenge
		/// </summary>
		public static LifeRecordItem RefuseRequestLegendaryBookChallenge => Instance[(short)496];

		/// <summary>
		/// RequestLegendaryBookChallengeFail
		/// </summary>
		public static LifeRecordItem RequestLegendaryBookChallengeFail => Instance[(short)497];

		/// <summary>
		/// AcceptRequestLegendaryBook
		/// </summary>
		public static LifeRecordItem AcceptRequestLegendaryBook => Instance[(short)498];

		/// <summary>
		/// RequestLegendaryBookSucceed
		/// </summary>
		public static LifeRecordItem RequestLegendaryBookSucceed => Instance[(short)499];

		/// <summary>
		/// RequestLegendaryBookFail
		/// </summary>
		public static LifeRecordItem RequestLegendaryBookFail => Instance[(short)500];

		/// <summary>
		/// RefuseRequestLegendaryBook
		/// </summary>
		public static LifeRecordItem RefuseRequestLegendaryBook => Instance[(short)501];

		/// <summary>
		/// AcceptRequestExchangeLegendaryBook
		/// </summary>
		public static LifeRecordItem AcceptRequestExchangeLegendaryBook => Instance[(short)502];

		/// <summary>
		/// RequestExchangeLegendaryBookSucceed
		/// </summary>
		public static LifeRecordItem RequestExchangeLegendaryBookSucceed => Instance[(short)503];

		/// <summary>
		/// RefuseRequestExchangeLegendaryBook
		/// </summary>
		public static LifeRecordItem RefuseRequestExchangeLegendaryBook => Instance[(short)504];

		/// <summary>
		/// RequestExchangeLegendaryBookFail
		/// </summary>
		public static LifeRecordItem RequestExchangeLegendaryBookFail => Instance[(short)505];

		/// <summary>
		/// GiveLegendaryBookFail
		/// </summary>
		public static LifeRecordItem GiveLegendaryBookFail => Instance[(short)506];

		/// <summary>
		/// RefuseGiveLegendaryBook
		/// </summary>
		public static LifeRecordItem RefuseGiveLegendaryBook => Instance[(short)507];

		/// <summary>
		/// DefeatLegendaryBookInsaneJust
		/// </summary>
		public static LifeRecordItem DefeatLegendaryBookInsaneJust => Instance[(short)508];

		/// <summary>
		/// DefeatLegendaryBookInsaneKind
		/// </summary>
		public static LifeRecordItem DefeatLegendaryBookInsaneKind => Instance[(short)509];

		/// <summary>
		/// DefeatLegendaryBookInsaneEven
		/// </summary>
		public static LifeRecordItem DefeatLegendaryBookInsaneEven => Instance[(short)510];

		/// <summary>
		/// DefeatLegendaryBookInsaneRebel
		/// </summary>
		public static LifeRecordItem DefeatLegendaryBookInsaneRebel => Instance[(short)511];

		/// <summary>
		/// DefeatLegendaryBookInsaneEgoistic
		/// </summary>
		public static LifeRecordItem DefeatLegendaryBookInsaneEgoistic => Instance[(short)512];

		/// <summary>
		/// LegendaryBookInsaneDefeatedJust
		/// </summary>
		public static LifeRecordItem LegendaryBookInsaneDefeatedJust => Instance[(short)513];

		/// <summary>
		/// LegendaryBookInsaneDefeatedKind
		/// </summary>
		public static LifeRecordItem LegendaryBookInsaneDefeatedKind => Instance[(short)514];

		/// <summary>
		/// LegendaryBookInsaneDefeatedEven
		/// </summary>
		public static LifeRecordItem LegendaryBookInsaneDefeatedEven => Instance[(short)515];

		/// <summary>
		/// LegendaryBookInsaneDefeatedRebel
		/// </summary>
		public static LifeRecordItem LegendaryBookInsaneDefeatedRebel => Instance[(short)516];

		/// <summary>
		/// LegendaryBookInsaneDefeatedEgoistic
		/// </summary>
		public static LifeRecordItem LegendaryBookInsaneDefeatedEgoistic => Instance[(short)517];

		/// <summary>
		/// ShockedInsaneEscaped
		/// </summary>
		public static LifeRecordItem ShockedInsaneEscaped => Instance[(short)518];

		/// <summary>
		/// ReleaseShockedInsane
		/// </summary>
		public static LifeRecordItem ReleaseShockedInsane => Instance[(short)519];

		/// <summary>
		/// UnderAttackEscaped
		/// </summary>
		public static LifeRecordItem UnderAttackEscaped => Instance[(short)520];

		/// <summary>
		/// ReleaseUnderAttack
		/// </summary>
		public static LifeRecordItem ReleaseUnderAttack => Instance[(short)521];

		/// <summary>
		/// DefeatConsumed
		/// </summary>
		public static LifeRecordItem DefeatConsumed => Instance[(short)522];

		/// <summary>
		/// BeDefetedByConsumed
		/// </summary>
		public static LifeRecordItem BeDefetedByConsumed => Instance[(short)523];

		/// <summary>
		/// AcceptRequestExchangeLegendaryBookByExp
		/// </summary>
		public static LifeRecordItem AcceptRequestExchangeLegendaryBookByExp => Instance[(short)524];

		/// <summary>
		/// RequestExchangeLegendaryBookSucceedByExp
		/// </summary>
		public static LifeRecordItem RequestExchangeLegendaryBookSucceedByExp => Instance[(short)525];

		/// <summary>
		/// ResignPositionToStudyLegendaryBook
		/// </summary>
		public static LifeRecordItem ResignPositionToStudyLegendaryBook => Instance[(short)526];

		/// <summary>
		/// SoundOutLoverMind
		/// </summary>
		public static LifeRecordItem SoundOutLoverMind => Instance[(short)527];

		/// <summary>
		/// SoundOutMind
		/// </summary>
		public static LifeRecordItem SoundOutMind => Instance[(short)528];

		/// <summary>
		/// RedeemMindSucceed
		/// </summary>
		public static LifeRecordItem RedeemMindSucceed => Instance[(short)529];

		/// <summary>
		/// RedeemMindFail
		/// </summary>
		public static LifeRecordItem RedeemMindFail => Instance[(short)530];

		/// <summary>
		/// AcceptRedeemMind
		/// </summary>
		public static LifeRecordItem AcceptRedeemMind => Instance[(short)531];

		/// <summary>
		/// RefuseRedeemMind
		/// </summary>
		public static LifeRecordItem RefuseRedeemMind => Instance[(short)532];

		/// <summary>
		/// FirstDateWithLover
		/// </summary>
		public static LifeRecordItem FirstDateWithLover => Instance[(short)533];

		/// <summary>
		/// FirstDateWithTaiwu
		/// </summary>
		public static LifeRecordItem FirstDateWithTaiwu => Instance[(short)534];

		/// <summary>
		/// SelectLoverToken
		/// </summary>
		public static LifeRecordItem SelectLoverToken => Instance[(short)535];

		/// <summary>
		/// SelectLoverToken2
		/// </summary>
		public static LifeRecordItem SelectLoverToken2 => Instance[(short)536];

		/// <summary>
		/// DateWithLover
		/// </summary>
		public static LifeRecordItem DateWithLover => Instance[(short)537];

		/// <summary>
		/// DateWithLover2
		/// </summary>
		public static LifeRecordItem DateWithLover2 => Instance[(short)538];

		/// <summary>
		/// TillDeathDoUsPart
		/// </summary>
		public static LifeRecordItem TillDeathDoUsPart => Instance[(short)539];

		/// <summary>
		/// CelebrateBirthday
		/// </summary>
		public static LifeRecordItem CelebrateBirthday => Instance[(short)540];

		/// <summary>
		/// CelebrateSelfBirthday
		/// </summary>
		public static LifeRecordItem CelebrateSelfBirthday => Instance[(short)541];

		/// <summary>
		/// CelebrateAnniversary
		/// </summary>
		public static LifeRecordItem CelebrateAnniversary => Instance[(short)542];

		/// <summary>
		/// BeCaughtCheating
		/// </summary>
		public static LifeRecordItem BeCaughtCheating => Instance[(short)543];

		/// <summary>
		/// CaughtCheating
		/// </summary>
		public static LifeRecordItem CaughtCheating => Instance[(short)544];

		/// <summary>
		/// PregnancyWithWife
		/// </summary>
		public static LifeRecordItem PregnancyWithWife => Instance[(short)545];

		/// <summary>
		/// PregnancyWithHusband
		/// </summary>
		public static LifeRecordItem PregnancyWithHusband => Instance[(short)546];

		/// <summary>
		/// TeaTasting
		/// </summary>
		public static LifeRecordItem TeaTasting => Instance[(short)547];

		/// <summary>
		/// TeaTastingLifeSkillBattleWin
		/// </summary>
		public static LifeRecordItem TeaTastingLifeSkillBattleWin => Instance[(short)548];

		/// <summary>
		/// TeaTastingLifeSkillBattleLose
		/// </summary>
		public static LifeRecordItem TeaTastingLifeSkillBattleLose => Instance[(short)549];

		/// <summary>
		/// TeaTastingDisorderOfQi
		/// </summary>
		public static LifeRecordItem TeaTastingDisorderOfQi => Instance[(short)550];

		/// <summary>
		/// WineTasting
		/// </summary>
		public static LifeRecordItem WineTasting => Instance[(short)551];

		/// <summary>
		/// WineTastingLifeSkillBattleWin
		/// </summary>
		public static LifeRecordItem WineTastingLifeSkillBattleWin => Instance[(short)552];

		/// <summary>
		/// WineTastingLifeSkillBattleLose
		/// </summary>
		public static LifeRecordItem WineTastingLifeSkillBattleLose => Instance[(short)553];

		/// <summary>
		/// WineTastingDisorderOfQi
		/// </summary>
		public static LifeRecordItem WineTastingDisorderOfQi => Instance[(short)554];

		/// <summary>
		/// FirstNameChanged
		/// </summary>
		public static LifeRecordItem FirstNameChanged => Instance[(short)555];

		/// <summary>
		/// LifeSkillModel
		/// </summary>
		public static LifeRecordItem LifeSkillModel => Instance[(short)556];

		/// <summary>
		/// CombatSkillModel
		/// </summary>
		public static LifeRecordItem CombatSkillModel => Instance[(short)557];

		/// <summary>
		/// PromoteReputation
		/// </summary>
		public static LifeRecordItem PromoteReputation => Instance[(short)558];

		/// <summary>
		/// ReputationPromoted
		/// </summary>
		public static LifeRecordItem ReputationPromoted => Instance[(short)559];

		/// <summary>
		/// CapabilityCultivated
		/// </summary>
		public static LifeRecordItem CapabilityCultivated => Instance[(short)560];

		/// <summary>
		/// BroughtToTaiwuByBeggars
		/// </summary>
		public static LifeRecordItem BroughtToTaiwuByBeggars => Instance[(short)561];

		/// <summary>
		/// CivilianSkillSeverEnemy
		/// </summary>
		public static LifeRecordItem DiscardRevengeForCivilianSkill => Instance[(short)562];

		/// <summary>
		/// CivilianSkillDissolveResentment
		/// </summary>
		public static LifeRecordItem CivilianSkillDissolveResentment => Instance[(short)563];

		/// <summary>
		/// PersuadeWithdrawlFromOrganization
		/// </summary>
		public static LifeRecordItem PersuadeWithdrawlFromOrganization => Instance[(short)564];

		/// <summary>
		/// WithdrawlFromOrganization
		/// </summary>
		public static LifeRecordItem WithdrawlFromOrganization => Instance[(short)565];

		/// <summary>
		/// FreeMedicalConsultation
		/// </summary>
		public static LifeRecordItem FreeMedicalConsultation => Instance[(short)566];

		/// <summary>
		/// OfferTreasures
		/// </summary>
		public static LifeRecordItem OfferTreasures => Instance[(short)567];

		/// <summary>
		/// ReceiveOfferedTreasures
		/// </summary>
		public static LifeRecordItem ReceiveOfferedTreasures => Instance[(short)568];

		/// <summary>
		/// ForcefulPurchase
		/// </summary>
		public static LifeRecordItem ForcefulPurchase => Instance[(short)569];

		/// <summary>
		/// ForcefulSale
		/// </summary>
		public static LifeRecordItem ForcefulSale => Instance[(short)570];

		/// <summary>
		/// BegForMoney
		/// </summary>
		public static LifeRecordItem BegForMoney => Instance[(short)571];

		/// <summary>
		/// AbsurdlyForceToLeave
		/// </summary>
		public static LifeRecordItem AbsurdlyForceToLeave => Instance[(short)572];

		/// <summary>
		/// AbsurdlyForcedToLeave
		/// </summary>
		public static LifeRecordItem AbsurdlyForcedToLeave => Instance[(short)573];

		/// <summary>
		/// DiagnoseWithMedicine
		/// </summary>
		public static LifeRecordItem DiagnoseWithMedicine => Instance[(short)574];

		/// <summary>
		/// DiagnosedWithMedicine
		/// </summary>
		public static LifeRecordItem DiagnosedWithMedicine => Instance[(short)575];

		/// <summary>
		/// DiagnoseWithWrongMedicine
		/// </summary>
		public static LifeRecordItem DiagnoseWithNonMedicine => Instance[(short)576];

		/// <summary>
		/// DiagnosedWithWrongMedicine
		/// </summary>
		public static LifeRecordItem DiagnosedWithWrongMedicine => Instance[(short)577];

		/// <summary>
		/// ExtendLifeSpan
		/// </summary>
		public static LifeRecordItem ExtendLifeSpan => Instance[(short)578];

		/// <summary>
		/// LifeSpanExtended
		/// </summary>
		public static LifeRecordItem LifeSpanExtended => Instance[(short)579];

		/// <summary>
		/// PersuadeToBecomeMonk
		/// </summary>
		public static LifeRecordItem PersuadeToBecomeMonk => Instance[(short)580];

		/// <summary>
		/// BecomeMonkPersuaded
		/// </summary>
		public static LifeRecordItem BecomeMonkPersuaded => Instance[(short)581];

		/// <summary>
		/// FailToPersuadeToBecomeMonk
		/// </summary>
		public static LifeRecordItem FailToPersuadeToBecomeMonk => Instance[(short)582];

		/// <summary>
		/// ExpiateDeadSouls
		/// </summary>
		public static LifeRecordItem ExpiateDeadSouls => Instance[(short)583];

		/// <summary>
		/// ExociseXiangshuInfectionVictoryInCombat
		/// </summary>
		public static LifeRecordItem ExociseXiangshuInfectionVictoryInCombat => Instance[(short)584];

		/// <summary>
		/// BecomeExociseXiangshuInfectionVictoryInCombat
		/// </summary>
		public static LifeRecordItem BecomeExociseXiangshuInfectionVictoryInCombat => Instance[(short)585];

		/// <summary>
		/// ExociseXiangshuInfectionVictoryInCombatDefeated
		/// </summary>
		public static LifeRecordItem ExociseXiangshuInfectionVictoryInCombatDefeated => Instance[(short)586];

		/// <summary>
		/// TribulationSucceeded
		/// </summary>
		public static LifeRecordItem TribulationSucceeded => Instance[(short)587];

		/// <summary>
		/// TribulationFailed
		/// </summary>
		public static LifeRecordItem TribulationFailed => Instance[(short)588];

		/// <summary>
		/// TribulationCanceled
		/// </summary>
		public static LifeRecordItem TribulationCanceled => Instance[(short)589];

		/// <summary>
		/// TribulationContinued
		/// </summary>
		public static LifeRecordItem TribulationContinued => Instance[(short)590];

		/// <summary>
		/// GuidingEvilToGoodSucceed
		/// </summary>
		public static LifeRecordItem GuidingEvilToGoodSucceed => Instance[(short)591];

		/// <summary>
		/// BecomeGuidingEvilToGoodSucceed
		/// </summary>
		public static LifeRecordItem GuidingEvilGoodSucceed => Instance[(short)592];

		/// <summary>
		/// GuidingEvilToGoodFail
		/// </summary>
		public static LifeRecordItem GuidingEvilToGoodFail => Instance[(short)593];

		/// <summary>
		/// VisitBuddhismTemples
		/// </summary>
		public static LifeRecordItem VisitBuddhismTemples => Instance[(short)594];

		/// <summary>
		/// EpiphanyThruVisitTemples
		/// </summary>
		public static LifeRecordItem EpiphanyThruVisitTemples => Instance[(short)595];

		/// <summary>
		/// EpiphanyThruVisitTemplesCombatSkill
		/// </summary>
		public static LifeRecordItem EpiphanyThruVisitTemplesCombatSkill => Instance[(short)596];

		/// <summary>
		/// EpiphanyThruVisitTemplesLifeSkill
		/// </summary>
		public static LifeRecordItem EpiphanyThruVisitTemplesLifeSkill => Instance[(short)597];

		/// <summary>
		/// EpiphanyThruVisitTemplesExperience
		/// </summary>
		public static LifeRecordItem EpiphanyThruVisitTemplesExperience => Instance[(short)598];

		/// <summary>
		/// DivineUnexpectedGain
		/// </summary>
		public static LifeRecordItem DivineUnexpectedGain => Instance[(short)599];

		/// <summary>
		/// DivineUnexpectedHarm
		/// </summary>
		public static LifeRecordItem DivineUnexpectedHarm => Instance[(short)600];

		/// <summary>
		/// ExchangeFates
		/// </summary>
		public static LifeRecordItem ExchangeFates => Instance[(short)601];

		/// <summary>
		/// BecomeExchangeFates
		/// </summary>
		public static LifeRecordItem BecomeExchangeFates => Instance[(short)602];

		/// <summary>
		/// ImmortalityGained
		/// </summary>
		public static LifeRecordItem ImmortalityGained => Instance[(short)603];

		/// <summary>
		/// ImmortalityLost
		/// </summary>
		public static LifeRecordItem ImmortalityLost => Instance[(short)604];

		/// <summary>
		/// ImmortalityRegained
		/// </summary>
		public static LifeRecordItem ImmortalityRegained => Instance[(short)605];

		/// <summary>
		/// TaiwuReincarnation
		/// </summary>
		public static LifeRecordItem TaiwuReincarnation => Instance[(short)606];

		/// <summary>
		/// TaiwuReincarnationPregnancy
		/// </summary>
		public static LifeRecordItem TaiwuReincarnationPregnancy => Instance[(short)607];

		/// <summary>
		/// MixPoisonHotRedRotten
		/// </summary>
		public static LifeRecordItem MixPoisonHotRedRotten => Instance[(short)608];

		/// <summary>
		/// MixPoisonHotRottenIllusory
		/// </summary>
		public static LifeRecordItem MixPoisonHotRottenIllusory => Instance[(short)609];

		/// <summary>
		/// MixPoisonHotRottenGloomy
		/// </summary>
		public static LifeRecordItem MixPoisonHotRottenGloomy => Instance[(short)610];

		/// <summary>
		/// MixPoisonHotRottenCold
		/// </summary>
		public static LifeRecordItem MixPoisonHotRottenCold => Instance[(short)611];

		/// <summary>
		/// MixPoisonRedRottenIllusory
		/// </summary>
		public static LifeRecordItem MixPoisonRedRottenIllusory => Instance[(short)612];

		/// <summary>
		/// MixPoisonRedRottenGloomy
		/// </summary>
		public static LifeRecordItem MixPoisonRedRottenGloomy => Instance[(short)613];

		/// <summary>
		/// MixPoisonRedRottenCold
		/// </summary>
		public static LifeRecordItem MixPoisonRedRottenCold => Instance[(short)614];

		/// <summary>
		/// MixPoisonHotRedIllusory
		/// </summary>
		public static LifeRecordItem MixPoisonHotRedIllusory => Instance[(short)615];

		/// <summary>
		/// MixPoisonHotRedGloomy
		/// </summary>
		public static LifeRecordItem MixPoisonHotRedGloomy => Instance[(short)616];

		/// <summary>
		/// MixPoisonHotRedCold
		/// </summary>
		public static LifeRecordItem MixPoisonHotRedCold => Instance[(short)617];

		/// <summary>
		/// MixPoisonGloomyColdIllusory
		/// </summary>
		public static LifeRecordItem MixPoisonGloomyColdIllusory => Instance[(short)618];

		/// <summary>
		/// MixPoisonRottenGloomyCold
		/// </summary>
		public static LifeRecordItem MixPoisonRottenGloomyCold => Instance[(short)619];

		/// <summary>
		/// MixPoisonHotGloomyCold
		/// </summary>
		public static LifeRecordItem MixPoisonHotGloomyCold => Instance[(short)620];

		/// <summary>
		/// MixPoisonRedGloomyCold
		/// </summary>
		public static LifeRecordItem MixPoisonRedGloomyCold => Instance[(short)621];

		/// <summary>
		/// MixPoisonRottenColdIllusory
		/// </summary>
		public static LifeRecordItem MixPoisonRottenColdIllusory => Instance[(short)622];

		/// <summary>
		/// MixPoisonHotColdIllusory
		/// </summary>
		public static LifeRecordItem MixPoisonHotColdIllusory => Instance[(short)623];

		/// <summary>
		/// MixPoisonRedColdIllusory
		/// </summary>
		public static LifeRecordItem MixPoisonRedColdIllusory => Instance[(short)624];

		/// <summary>
		/// MixPoisonRottenGloomyIllusory
		/// </summary>
		public static LifeRecordItem MixPoisonRottenGloomyIllusory => Instance[(short)625];

		/// <summary>
		/// MixPoisonHotGloomyIllusory
		/// </summary>
		public static LifeRecordItem MixPoisonHotGloomyIllusory => Instance[(short)626];

		/// <summary>
		/// MixPoisonRedGloomyIllusory
		/// </summary>
		public static LifeRecordItem MixPoisonRedGloomyIllusory => Instance[(short)627];

		/// <summary>
		/// DiggingXiangshuMinionCombatLost
		/// </summary>
		public static LifeRecordItem DiggingXiangshuMinionCombatLost => Instance[(short)628];

		/// <summary>
		/// DiggingXiangshuMinionCombatWon
		/// </summary>
		public static LifeRecordItem DiggingXiangshuMinionCombatWon => Instance[(short)629];

		/// <summary>
		/// SectMainStoryXuehouJixiKills
		/// </summary>
		public static LifeRecordItem SectMainStoryXuehouJixiKills => Instance[(short)630];

		/// <summary>
		/// SectMainStoryWudangTreasure
		/// </summary>
		public static LifeRecordItem SectMainStoryWudangTreasure => Instance[(short)631];

		/// <summary>
		/// SectMainStoryXuannvJoinOrg
		/// </summary>
		public static LifeRecordItem SectMainStoryXuannvJoinOrg => Instance[(short)632];

		/// <summary>
		/// SectMainStoryYuanshanGetAbsorbed
		/// </summary>
		public static LifeRecordItem SectMainStoryYuanshanGetAbsorbed => Instance[(short)633];

		/// <summary>
		/// SectMainStoryYuanshanResistSucceed
		/// </summary>
		public static LifeRecordItem SectMainStoryYuanshanResistSucceed => Instance[(short)634];

		/// <summary>
		/// SectMainStoryYuanshanResistOrdinary
		/// </summary>
		public static LifeRecordItem SectMainStoryYuanshanResistOrdinary => Instance[(short)635];

		/// <summary>
		/// SectMainStoryYuanshanResistFailed
		/// </summary>
		public static LifeRecordItem SectMainStoryYuanshanResistFailed => Instance[(short)636];

		/// <summary>
		/// SectMainStoryXuehouZombieKills
		/// </summary>
		public static LifeRecordItem SectMainStoryXuehouZombieKills => Instance[(short)637];

		/// <summary>
		/// SectMainStoryShixiangSkillEnemy
		/// </summary>
		public static LifeRecordItem SectMainStoryShixiangSkillEnemy => Instance[(short)638];

		/// <summary>
		/// SectMainStoryWuxianMethysis0
		/// </summary>
		public static LifeRecordItem SectMainStoryWuxianMethysis0 => Instance[(short)639];

		/// <summary>
		/// SectMainStoryWuxianPoison
		/// </summary>
		public static LifeRecordItem SectMainStoryWuxianPoison => Instance[(short)640];

		/// <summary>
		/// SectMainStoryWuxianAssault
		/// </summary>
		public static LifeRecordItem SectMainStoryWuxianAssault => Instance[(short)641];

		/// <summary>
		/// SectMainStoryWuxianMethysis1
		/// </summary>
		public static LifeRecordItem SectMainStoryWuxianMethysis1 => Instance[(short)642];

		/// <summary>
		/// SectMainStoryEmeiInfighting
		/// </summary>
		public static LifeRecordItem SectMainStoryEmeiInfighting => Instance[(short)643];

		/// <summary>
		/// SectMainStoryJieqingAssassin
		/// </summary>
		public static LifeRecordItem SectMainStoryJieqingAssassin => Instance[(short)644];

		/// <summary>
		/// WulinConferencePraiseAndGifts
		/// </summary>
		public static LifeRecordItem WulinConferencePraiseAndGifts => Instance[(short)645];

		/// <summary>
		/// NormalInformationChangeIdealSectNegative
		/// </summary>
		public static LifeRecordItem NormalInformationChangeIdealSectNegative => Instance[(short)646];

		/// <summary>
		/// SectMainStoryXuehouJixiRescueTaiwu
		/// </summary>
		public static LifeRecordItem SectMainStoryXuehouJixiRescueTaiwu => Instance[(short)647];

		/// <summary>
		/// SectMainStoryRanshanThreeFactionCompetetion
		/// </summary>
		public static LifeRecordItem SectMainStoryRanshanJoinThreeFactionCompetetion => Instance[(short)648];

		/// <summary>
		/// SectMainStoryRanshanThreeFactionCompetetionWin
		/// </summary>
		public static LifeRecordItem SectMainStoryRanshanThreeFactionCompetetionWin => Instance[(short)649];

		/// <summary>
		/// SectMainStoryRanshanThreeFactionCompetetionLose
		/// </summary>
		public static LifeRecordItem SectMainStoryRanshanThreeFactionCompetetionLose => Instance[(short)650];

		/// <summary>
		/// GainExpByStroll
		/// </summary>
		public static LifeRecordItem GainExpByStroll => Instance[(short)651];

		/// <summary>
		/// GainExpByReadingOldBook
		/// </summary>
		public static LifeRecordItem GainExpByReadingOldBook => Instance[(short)652];

		/// <summary>
		/// PunishedAlongsideSpouse
		/// </summary>
		public static LifeRecordItem PunishedAlongsideSpouse => Instance[(short)653];

		/// <summary>
		/// DecideToAdoptFoundling
		/// </summary>
		public static LifeRecordItem DecideToAdoptFoundling => Instance[(short)654];

		/// <summary>
		/// AdoptFoundlingFail
		/// </summary>
		public static LifeRecordItem AdoptFoundlingFail => Instance[(short)655];

		/// <summary>
		/// AdoptFoundlingSucceed
		/// </summary>
		public static LifeRecordItem AdoptFoundlingSucceed => Instance[(short)656];

		/// <summary>
		/// FoundlingBeAdopted
		/// </summary>
		public static LifeRecordItem FoundlingGetAdopted => Instance[(short)657];

		/// <summary>
		/// ClaimFoundlingSucceed
		/// </summary>
		public static LifeRecordItem ClaimFoundlingSucceed => Instance[(short)658];

		/// <summary>
		/// FoundlingGetClaimed
		/// </summary>
		public static LifeRecordItem FoundlingGetClaimed => Instance[(short)659];

		/// <summary>
		/// SectMainStoryWudangVillagerKilled
		/// </summary>
		public static LifeRecordItem SectMainStoryWudangVillagerKilled => Instance[(short)660];

		/// <summary>
		/// SectMainStoryShixiangFallIll
		/// </summary>
		public static LifeRecordItem SectMainStoryShixiangFallIll => Instance[(short)661];

		/// <summary>
		/// KillAnimal
		/// </summary>
		public static LifeRecordItem KillAnimal => Instance[(short)662];

		/// <summary>
		/// DefeatedByAnimal
		/// </summary>
		public static LifeRecordItem DefeatedByAnimal => Instance[(short)663];

		/// <summary>
		/// EnterEnemyNest
		/// </summary>
		public static LifeRecordItem EnterEnemyNest => Instance[(short)664];

		/// <summary>
		/// DieFromEnemyNest
		/// </summary>
		public static LifeRecordItem DieFromEnemyNest => Instance[(short)665];

		/// <summary>
		/// EscapeFromEnemyNest
		/// </summary>
		public static LifeRecordItem EscapeFromEnemyNest => Instance[(short)666];

		/// <summary>
		/// GetSecretSpreadInVeryHighProbability
		/// </summary>
		public static LifeRecordItem GetSecretSpreadInVeryHighProbability => Instance[(short)667];

		/// <summary>
		/// GetSecretSpreadInHighProbability
		/// </summary>
		public static LifeRecordItem GetSecretSpreadInHighProbability => Instance[(short)668];

		/// <summary>
		/// GetSecretSpreadInLowProbability
		/// </summary>
		public static LifeRecordItem GetSecretSpreadInLowProbability => Instance[(short)669];

		/// <summary>
		/// GetSecretSpreadInVeryLowProbability
		/// </summary>
		public static LifeRecordItem GetSecretSpreadInVeryLowProbability => Instance[(short)670];

		/// <summary>
		/// SpreadSecretFail
		/// </summary>
		public static LifeRecordItem SpreadSecretFail => Instance[(short)671];

		/// <summary>
		/// SpreadSecretSuccess
		/// </summary>
		public static LifeRecordItem SpreadSecretSuccess => Instance[(short)672];

		/// <summary>
		/// HeardSecretSpreadInVeryHighProbability
		/// </summary>
		public static LifeRecordItem HeardSecretSpreadInVeryHighProbability => Instance[(short)673];

		/// <summary>
		/// HeardSecretSpreadInHighProbability
		/// </summary>
		public static LifeRecordItem HeardSecretSpreadInHighProbability => Instance[(short)674];

		/// <summary>
		/// HeardSecretSpreadInLowProbability
		/// </summary>
		public static LifeRecordItem HeardSecretSpreadInLowProbability => Instance[(short)675];

		/// <summary>
		/// HeardSecretSpreadInVeryLowProbability
		/// </summary>
		public static LifeRecordItem HeardSecretSpreadInVeryLowProbability => Instance[(short)676];

		/// <summary>
		/// RequestKeepSecretFail
		/// </summary>
		public static LifeRecordItem RequestKeepSecretFail => Instance[(short)677];

		/// <summary>
		/// RequestKeepSecretSuccess
		/// </summary>
		public static LifeRecordItem RequestKeepSecretSuccess => Instance[(short)678];

		/// <summary>
		/// BeRequestedToKeepSecret
		/// </summary>
		public static LifeRecordItem BeRequestedToKeepSecret => Instance[(short)679];

		/// <summary>
		/// ThreadNeedleMatchFail
		/// </summary>
		public static LifeRecordItem ThreadNeedleMatchFail => Instance[(short)680];

		/// <summary>
		/// ThreadNeedleSeparateFail
		/// </summary>
		public static LifeRecordItem ThreadNeedleSeparateFail => Instance[(short)681];

		/// <summary>
		/// ThreadNeedleMatchSuccess
		/// </summary>
		public static LifeRecordItem ThreadNeedleMatchSuccess => Instance[(short)682];

		/// <summary>
		/// ThreadNeedleSeparateSuccess
		/// </summary>
		public static LifeRecordItem ThreadNeedleSeparateSuccess => Instance[(short)683];

		/// <summary>
		/// ThreadNeedleBeMatched0
		/// </summary>
		public static LifeRecordItem ThreadNeedleBeMatched1 => Instance[(short)684];

		/// <summary>
		/// ThreadNeedleBeSeparated0
		/// </summary>
		public static LifeRecordItem ThreadNeedleBeSeparated1 => Instance[(short)685];

		/// <summary>
		/// ThreadNeedleBeMatched1
		/// </summary>
		public static LifeRecordItem ThreadNeedleBeMatched2 => Instance[(short)686];

		/// <summary>
		/// ThreadNeedleBeSeparated1
		/// </summary>
		public static LifeRecordItem ThreadNeedleBeSeparated2 => Instance[(short)687];

		/// <summary>
		/// SpreadSecretKnown
		/// </summary>
		public static LifeRecordItem SpreadSecretKnown => Instance[(short)688];

		/// <summary>
		/// SectMainStoryXuannvBirthOfMirrorCreatedImposture
		/// </summary>
		public static LifeRecordItem SectMainStoryXuannvBirthOfMirrorCreatedImposture => Instance[(short)689];

		/// <summary>
		/// EscapeFromEnemyNestBySelf
		/// </summary>
		public static LifeRecordItem EscapeFromEnemyNestBySelf => Instance[(short)690];

		/// <summary>
		/// SaveFromInfection
		/// </summary>
		public static LifeRecordItem SaveFromInfection => Instance[(short)691];

		/// <summary>
		/// SaveFromEnemyNest
		/// </summary>
		public static LifeRecordItem SaveFromEnemyNest => Instance[(short)692];

		/// <summary>
		/// SaveFromEnemyNestFailed
		/// </summary>
		public static LifeRecordItem SaveFromEnemyNestFailed => Instance[(short)693];

		/// <summary>
		/// TameCarrierSucceed
		/// </summary>
		public static LifeRecordItem TameCarrierSucceed => Instance[(short)694];

		/// <summary>
		/// TameCarrierFail
		/// </summary>
		public static LifeRecordItem TameCarrierFail => Instance[(short)695];

		/// <summary>
		/// ReleaseCarrier
		/// </summary>
		public static LifeRecordItem ReleaseCarrier => Instance[(short)696];

		/// <summary>
		/// DLCLoongRidingEffectQiuniuAudience
		/// </summary>
		public static LifeRecordItem DLCLoongRidingEffectQiuniuAudience => Instance[(short)697];

		/// <summary>
		/// DLCLoongRidingEffectQiuniu
		/// </summary>
		public static LifeRecordItem DLCLoongRidingEffectQiuniu => Instance[(short)698];

		/// <summary>
		/// DLCLoongRidingEffectYazi
		/// </summary>
		public static LifeRecordItem DLCLoongRidingEffectYazi => Instance[(short)699];

		/// <summary>
		/// DLCLoongRidingEffectChaofeng
		/// </summary>
		public static LifeRecordItem DLCLoongRidingEffectChaofeng => Instance[(short)700];

		/// <summary>
		/// DLCLoongRidingEffectPulao
		/// </summary>
		public static LifeRecordItem DLCLoongRidingEffectPulao => Instance[(short)701];

		/// <summary>
		/// DLCLoongRidingEffectSuanni
		/// </summary>
		public static LifeRecordItem DLCLoongRidingEffectSuanni => Instance[(short)702];

		/// <summary>
		/// DLCLoongRidingEffectBaxia
		/// </summary>
		public static LifeRecordItem DLCLoongRidingEffectBaxia => Instance[(short)703];

		/// <summary>
		/// DLCLoongRidingEffectBian
		/// </summary>
		public static LifeRecordItem DLCLoongRidingEffectBian => Instance[(short)704];

		/// <summary>
		/// DLCLoongRidingEffectFuxi
		/// </summary>
		public static LifeRecordItem DLCLoongRidingEffectFuxi => Instance[(short)705];

		/// <summary>
		/// DLCLoongRidingEffectChiwen
		/// </summary>
		public static LifeRecordItem DLCLoongRidingEffectChiwen => Instance[(short)706];

		/// <summary>
		/// DefeatLoong
		/// </summary>
		public static LifeRecordItem DefeatLoong => Instance[(short)707];

		/// <summary>
		/// DefeatedByLoong
		/// </summary>
		public static LifeRecordItem DefeatedByLoong => Instance[(short)708];

		/// <summary>
		/// DLCLoongRidingEffectYazi2
		/// </summary>
		public static LifeRecordItem DLCLoongRidingEffectYazi2 => Instance[(short)709];

		/// <summary>
		/// DieFromAge
		/// </summary>
		public static LifeRecordItem DieFromAge => Instance[(short)710];

		/// <summary>
		/// DieFromPoorHealth
		/// </summary>
		public static LifeRecordItem DieFromPoorHealth => Instance[(short)711];

		/// <summary>
		/// KilledInPublic
		/// </summary>
		public static LifeRecordItem KilledInPublic => Instance[(short)712];

		/// <summary>
		/// KilledInPrivate
		/// </summary>
		public static LifeRecordItem KilledInPrivate => Instance[(short)713];

		/// <summary>
		/// KilledAfterXiangshuInfected
		/// </summary>
		public static LifeRecordItem KilledAfterXiangshuInfected => Instance[(short)714];

		/// <summary>
		/// Assassinated
		/// </summary>
		public static LifeRecordItem Assassinated => Instance[(short)715];

		/// <summary>
		/// KilledByXiangshu
		/// </summary>
		public static LifeRecordItem KilledByXiangshu => Instance[(short)716];

		/// <summary>
		/// PurchaseItem1
		/// </summary>
		public static LifeRecordItem PurchaseItem1 => Instance[(short)717];

		/// <summary>
		/// SellItem1
		/// </summary>
		public static LifeRecordItem SellItem1 => Instance[(short)718];

		/// <summary>
		/// CleanBodyReincarnationSuccess
		/// </summary>
		public static LifeRecordItem CleanBodyReincarnationSuccess => Instance[(short)719];

		/// <summary>
		/// CleanBodyReincarnationFail
		/// </summary>
		public static LifeRecordItem CleanBodyReincarnationFail => Instance[(short)720];

		/// <summary>
		/// EvilBodyReincarnationSuccess
		/// </summary>
		public static LifeRecordItem EvilBodyReincarnationSuccess => Instance[(short)721];

		/// <summary>
		/// EvilBodyReincarnationFail
		/// </summary>
		public static LifeRecordItem EvilBodyReincarnationFail => Instance[(short)722];

		/// <summary>
		/// WugKingForestSpiritBecomeEnemy
		/// </summary>
		public static LifeRecordItem WugKingForestSpiritBecomeEnemy => Instance[(short)723];

		/// <summary>
		/// SecretMakeEnemy
		/// </summary>
		public static LifeRecordItem SecretMakeEnemy => Instance[(short)724];

		/// <summary>
		/// SecretBeMadeEnemy
		/// </summary>
		public static LifeRecordItem SecretBeMadeEnemy => Instance[(short)725];

		/// <summary>
		/// CleanBodyDefeatAnimal
		/// </summary>
		public static LifeRecordItem CleanBodyDefeatAnimal => Instance[(short)726];

		/// <summary>
		/// EvilBodyDefeatAnimal
		/// </summary>
		public static LifeRecordItem EvilBodyDefeatAnimal => Instance[(short)727];

		/// <summary>
		/// CleanBodyDefeatHereticRandomEnemy
		/// </summary>
		public static LifeRecordItem CleanBodyDefeatHereticRandomEnemy => Instance[(short)728];

		/// <summary>
		/// EvilBodyDefeatHereticRandomEnemy
		/// </summary>
		public static LifeRecordItem EvilBodyDefeatHereticRandomEnemy => Instance[(short)729];

		/// <summary>
		/// CleanBodyDefeatRighteousRandomEnemy
		/// </summary>
		public static LifeRecordItem CleanBodyDefeatRighteousRandomEnemy => Instance[(short)730];

		/// <summary>
		/// EvilBodyDefeatRighteousRandomEnemy
		/// </summary>
		public static LifeRecordItem EvilBodyDefeatRighteousRandomEnemy => Instance[(short)731];

		/// <summary>
		/// WuxianParanoiaAdded
		/// </summary>
		public static LifeRecordItem WuxianParanoiaAdded => Instance[(short)732];

		/// <summary>
		/// WuxianParanoiaAttack
		/// </summary>
		public static LifeRecordItem WuxianParanoiaAttack => Instance[(short)733];

		/// <summary>
		/// WuxianParanoiaErased
		/// </summary>
		public static LifeRecordItem WuxianParanoiaErased => Instance[(short)734];

		/// <summary>
		/// WugKingRedEyeLoseItem
		/// </summary>
		public static LifeRecordItem WugKingRedEyeLoseItem => Instance[(short)735];

		/// <summary>
		/// WugForestSpiritReduceFavorability
		/// </summary>
		public static LifeRecordItem WugForestSpiritReduceFavorability => Instance[(short)736];

		/// <summary>
		/// WugKingForestSpiritBeBecomeEnemy
		/// </summary>
		public static LifeRecordItem WugKingForestSpiritBeBecomeEnemy => Instance[(short)737];

		/// <summary>
		/// WugKingBlackBloodChangeDisorderOfQi
		/// </summary>
		public static LifeRecordItem WugKingBlackBloodChangeDisorderOfQi => Instance[(short)738];

		/// <summary>
		/// WugDevilInsideXiangshuInfection
		/// </summary>
		public static LifeRecordItem WugDevilInsideXiangshuInfection => Instance[(short)739];

		/// <summary>
		/// WugCorpseWormChangeHealth
		/// </summary>
		public static LifeRecordItem WugCorpseWormChangeHealth => Instance[(short)740];

		/// <summary>
		/// WugKingIceSilkwormLoseNeili
		/// </summary>
		public static LifeRecordItem WugKingIceSilkwormLoseNeili => Instance[(short)741];

		/// <summary>
		/// WugKingGoldenSilkwormEatGrownWug
		/// </summary>
		public static LifeRecordItem WugKingGoldenSilkwormEatGrownWug => Instance[(short)742];

		/// <summary>
		/// WugAzureMarrowAddPoison
		/// </summary>
		public static LifeRecordItem WugAzureMarrowAddPoison => Instance[(short)743];

		/// <summary>
		/// WugAzureMarrowAddWug
		/// </summary>
		public static LifeRecordItem WugAzureMarrowAddWug => Instance[(short)744];

		/// <summary>
		/// WugAzureMarrowBeAddWug
		/// </summary>
		public static LifeRecordItem WugAzureMarrowBeAddWug => Instance[(short)745];

		/// <summary>
		/// WuxianParanoiaErased2
		/// </summary>
		public static LifeRecordItem WuxianParanoiaErased2 => Instance[(short)746];

		/// <summary>
		/// WuxianDecreasedMood
		/// </summary>
		public static LifeRecordItem WuxianDecreasedMood => Instance[(short)747];

		/// <summary>
		/// WuxianDecreasedFavorability
		/// </summary>
		public static LifeRecordItem WuxianDecreasedFavorability => Instance[(short)748];

		/// <summary>
		/// WuxianQiDecline
		/// </summary>
		public static LifeRecordItem WuxianQiDecline => Instance[(short)749];

		/// <summary>
		/// WuxianPoisoning
		/// </summary>
		public static LifeRecordItem WuxianPoisoning => Instance[(short)750];

		/// <summary>
		/// WuxianLoseItem
		/// </summary>
		public static LifeRecordItem WuxianLoseItem => Instance[(short)751];

		/// <summary>
		/// WugDevilInsideChangeHappiness
		/// </summary>
		public static LifeRecordItem WugDevilInsideChangeHappiness => Instance[(short)752];

		/// <summary>
		/// WugRedEyeChangeToGrown
		/// </summary>
		public static LifeRecordItem WugRedEyeChangeToGrown => Instance[(short)753];

		/// <summary>
		/// WugForestSpiritChangeToGrown
		/// </summary>
		public static LifeRecordItem WugForestSpiritChangeToGrown => Instance[(short)754];

		/// <summary>
		/// WugBlackBloodChangeToGrown
		/// </summary>
		public static LifeRecordItem WugBlackBloodChangeToGrown => Instance[(short)755];

		/// <summary>
		/// WugDevilInsideChangeToGrown
		/// </summary>
		public static LifeRecordItem WugDevilInsideChangeToGrown => Instance[(short)756];

		/// <summary>
		/// WugCorpseWormChangeToGrown
		/// </summary>
		public static LifeRecordItem WugCorpseWormChangeToGrown => Instance[(short)757];

		/// <summary>
		/// WugCorpseWormBeChangeToGrown
		/// </summary>
		public static LifeRecordItem WugCorpseWormBeChangeToGrown => Instance[(short)758];

		/// <summary>
		/// WugIceSilkwormChangeToGrown
		/// </summary>
		public static LifeRecordItem WugIceSilkwormChangeToGrown => Instance[(short)759];

		/// <summary>
		/// WugGoldenSilkwormChangeToGrown
		/// </summary>
		public static LifeRecordItem WugGoldenSilkwormChangeToGrown => Instance[(short)760];

		/// <summary>
		/// WugAzureMarrowChangeToGrown
		/// </summary>
		public static LifeRecordItem WugAzureMarrowChangeToGrown => Instance[(short)761];

		/// <summary>
		/// WugAzureMarrowBeChangeToGrown
		/// </summary>
		public static LifeRecordItem WugAzureMarrowBeChangeToGrown => Instance[(short)762];

		/// <summary>
		/// ManageLearnLifeSkillSuccess
		/// </summary>
		public static LifeRecordItem ManageLearnLifeSkillSuccess => Instance[(short)763];

		/// <summary>
		/// ManageLearnCombatSkillSuccess
		/// </summary>
		public static LifeRecordItem ManageLearnCombatSkillSuccess => Instance[(short)764];

		/// <summary>
		/// ManageLearnLifeSkillFail
		/// </summary>
		public static LifeRecordItem ManageLearnLifeSkillFail => Instance[(short)765];

		/// <summary>
		/// ManageLearnCombatSkillFail
		/// </summary>
		public static LifeRecordItem ManageLearnCombatSkillFail => Instance[(short)766];

		/// <summary>
		/// ManageLifeSkillAbilityUp
		/// </summary>
		public static LifeRecordItem ManageLifeSkillAbilityUp => Instance[(short)767];

		/// <summary>
		/// ManageCombatSkillAbilityUp
		/// </summary>
		public static LifeRecordItem ManageCombatSkillAbilityUp => Instance[(short)768];

		/// <summary>
		/// SmallVillagerXiangshuCompletelyInfected
		/// </summary>
		public static LifeRecordItem SmallVillagerXiangshuCompletelyInfected => Instance[(short)769];

		/// <summary>
		/// SmallVillagerSavedFromInfection
		/// </summary>
		public static LifeRecordItem SmallVillagerSavedFromInfection => Instance[(short)770];

		/// <summary>
		/// SmallVillagerSaveFromInfection
		/// </summary>
		public static LifeRecordItem SmallVillagerSaveFromInfection => Instance[(short)771];

		/// <summary>
		/// StorageResourceToTreasury
		/// </summary>
		public static LifeRecordItem StorageResourceToTreasury => Instance[(short)772];

		/// <summary>
		/// StorageItemToTreasury
		/// </summary>
		public static LifeRecordItem StorageItemToTreasury => Instance[(short)773];

		/// <summary>
		/// TakeResourceFromTreasury
		/// </summary>
		public static LifeRecordItem TakeResourceFromTreasury => Instance[(short)774];

		/// <summary>
		/// TakeItemFromTreasury
		/// </summary>
		public static LifeRecordItem TakeItemFromTreasury => Instance[(short)775];

		/// <summary>
		/// TaiwuStorageResourceToTreasury
		/// </summary>
		public static LifeRecordItem TaiwuStorageResourceToTreasury => Instance[(short)776];

		/// <summary>
		/// TaiwuStorageItemToTreasury
		/// </summary>
		public static LifeRecordItem TaiwuStorageItemToTreasury => Instance[(short)777];

		/// <summary>
		/// TaiwuTakeResourceFromTreasury
		/// </summary>
		public static LifeRecordItem TaiwuTakeResourceFromTreasury => Instance[(short)778];

		/// <summary>
		/// TaiwuTakeItemFromTreasury
		/// </summary>
		public static LifeRecordItem TaiwuTakeItemFromTreasury => Instance[(short)779];

		/// <summary>
		/// DecideToGuardTreasury
		/// </summary>
		public static LifeRecordItem DecideToGuardTreasury => Instance[(short)780];

		/// <summary>
		/// FinishGuardingTreasury
		/// </summary>
		public static LifeRecordItem FinishGuardingTreasury => Instance[(short)781];

		/// <summary>
		/// IntrudeTreasuryCancelSupportMakeEnemy
		/// </summary>
		public static LifeRecordItem IntrudeTreasuryCancelSupportMakeEnemy => Instance[(short)782];

		/// <summary>
		/// IntrudeTreasuryBeCancelSupportMakeEnemy
		/// </summary>
		public static LifeRecordItem IntrudeTreasuryBeCancelSupportMakeEnemy => Instance[(short)783];

		/// <summary>
		/// IntrudeTreasuryCancelSupport
		/// </summary>
		public static LifeRecordItem IntrudeTreasuryCancelSupport => Instance[(short)784];

		/// <summary>
		/// IntrudeTreasuryBeCancelSupport
		/// </summary>
		public static LifeRecordItem IntrudeTreasuryBeCancelSupport => Instance[(short)785];

		/// <summary>
		/// IntrudeTreasuryMakeEnemyOthers
		/// </summary>
		public static LifeRecordItem IntrudeTreasuryMakeEnemyOthers => Instance[(short)786];

		/// <summary>
		/// IntrudeTreasuryBeMakeEnemyOthers
		/// </summary>
		public static LifeRecordItem IntrudeTreasuryBeMakeEnemyOthers => Instance[(short)787];

		/// <summary>
		/// IntrudeTreasuryLostMorale
		/// </summary>
		public static LifeRecordItem IntrudeTreasuryLostMorale => Instance[(short)788];

		/// <summary>
		/// IntrudeTreasuryBeLostMorale
		/// </summary>
		public static LifeRecordItem IntrudeTreasuryBeLostMorale => Instance[(short)789];

		/// <summary>
		/// IntrudeTreasuryBeLostMorale2
		/// </summary>
		public static LifeRecordItem IntrudeTreasuryBeLostMorale2 => Instance[(short)790];

		/// <summary>
		/// PlunderTreasuryCancelSupportMakeEnemy
		/// </summary>
		public static LifeRecordItem PlunderTreasuryCancelSupportMakeEnemy => Instance[(short)791];

		/// <summary>
		/// PlunderTreasuryBeCancelSupportMakeEnemy
		/// </summary>
		public static LifeRecordItem PlunderTreasuryBeCancelSupportMakeEnemy => Instance[(short)792];

		/// <summary>
		/// PlunderTreasuryCancelSupport
		/// </summary>
		public static LifeRecordItem PlunderTreasuryCancelSupport => Instance[(short)793];

		/// <summary>
		/// PlunderTreasuryBeCancelSupport
		/// </summary>
		public static LifeRecordItem PlunderTreasuryBeCancelSupport => Instance[(short)794];

		/// <summary>
		/// PlunderTreasuryMakeEnemyOthers
		/// </summary>
		public static LifeRecordItem PlunderTreasuryMakeEnemyOthers => Instance[(short)795];

		/// <summary>
		/// PlunderTreasuryBeMakeEnemyOthers
		/// </summary>
		public static LifeRecordItem PlunderTreasuryBeMakeEnemyOthers => Instance[(short)796];

		/// <summary>
		/// PlunderTreasuryLostMorale
		/// </summary>
		public static LifeRecordItem PlunderTreasuryLostMorale => Instance[(short)797];

		/// <summary>
		/// PlunderTreasuryBeLostMorale
		/// </summary>
		public static LifeRecordItem PlunderTreasuryBeLostMorale => Instance[(short)798];

		/// <summary>
		/// PlunderTreasuryBeLostMorale2
		/// </summary>
		public static LifeRecordItem PlunderTreasuryBeLostMorale2 => Instance[(short)799];

		/// <summary>
		/// DonateTreasuryProvideSupport
		/// </summary>
		public static LifeRecordItem DonateTreasuryProvideSupport => Instance[(short)800];

		/// <summary>
		/// DonateTreasuryBeProvideSupport
		/// </summary>
		public static LifeRecordItem DonateTreasuryBeProvideSupport => Instance[(short)801];

		/// <summary>
		/// DonateTreasuryGetMorale
		/// </summary>
		public static LifeRecordItem DonateTreasuryGetMorale => Instance[(short)802];

		/// <summary>
		/// DonateTreasuryBeGetMorale
		/// </summary>
		public static LifeRecordItem DonateTreasuryBeGetMorale => Instance[(short)803];

		/// <summary>
		/// DonateTreasuryGetMorale2
		/// </summary>
		public static LifeRecordItem DonateTreasuryGetMorale2 => Instance[(short)804];

		/// <summary>
		/// TreasuryDistributeResource
		/// </summary>
		public static LifeRecordItem TreasuryDistributeResource => Instance[(short)805];

		/// <summary>
		/// TreasuryDistributeItem
		/// </summary>
		public static LifeRecordItem TreasuryDistributeItem => Instance[(short)806];

		/// <summary>
		/// PoisonEnemyFail12
		/// </summary>
		public static LifeRecordItem PoisonEnemyFail12 => Instance[(short)807];

		/// <summary>
		/// PoisonEnemyFail22
		/// </summary>
		public static LifeRecordItem PoisonEnemyFail22 => Instance[(short)808];

		/// <summary>
		/// PoisonEnemyFail32
		/// </summary>
		public static LifeRecordItem PoisonEnemyFail32 => Instance[(short)809];

		/// <summary>
		/// PoisonEnemyFail42
		/// </summary>
		public static LifeRecordItem PoisonEnemyFail42 => Instance[(short)810];

		/// <summary>
		/// PoisonEnemySucceed2
		/// </summary>
		public static LifeRecordItem PoisonEnemySucceed2 => Instance[(short)811];

		/// <summary>
		/// PoisonEnemySucceedAndEscaped2
		/// </summary>
		public static LifeRecordItem PoisonEnemySucceedAndEscaped2 => Instance[(short)812];

		/// <summary>
		/// GetPoisonedByEnemySucceed2
		/// </summary>
		public static LifeRecordItem GetPoisonedByEnemySucceed2 => Instance[(short)813];

		/// <summary>
		/// PlotHarmEnemyFail12
		/// </summary>
		public static LifeRecordItem PlotHarmEnemyFail12 => Instance[(short)814];

		/// <summary>
		/// PlotHarmEnemyFail22
		/// </summary>
		public static LifeRecordItem PlotHarmEnemyFail22 => Instance[(short)815];

		/// <summary>
		/// PlotHarmEnemyFail32
		/// </summary>
		public static LifeRecordItem PlotHarmEnemyFail32 => Instance[(short)816];

		/// <summary>
		/// PlotHarmEnemyFail42
		/// </summary>
		public static LifeRecordItem PlotHarmEnemyFail42 => Instance[(short)817];

		/// <summary>
		/// PlotHarmEnemySucceed2
		/// </summary>
		public static LifeRecordItem PlotHarmEnemySucceed2 => Instance[(short)818];

		/// <summary>
		/// PlotHarmEnemySucceedAndEscaped2
		/// </summary>
		public static LifeRecordItem PlotHarmEnemySucceedAndEscaped2 => Instance[(short)819];

		/// <summary>
		/// GetPlottedAgainstSucceed2
		/// </summary>
		public static LifeRecordItem GetPlottedAgainstSucceed2 => Instance[(short)820];

		/// <summary>
		/// SectMainStoryBaihuaManiaLow
		/// </summary>
		public static LifeRecordItem SectMainStoryBaihuaManiaLow => Instance[(short)821];

		/// <summary>
		/// SectMainStoryBaihuaManiaHigh
		/// </summary>
		public static LifeRecordItem SectMainStoryBaihuaManiaHigh => Instance[(short)822];

		/// <summary>
		/// SectMainStoryBaihuaManiaAttack
		/// </summary>
		public static LifeRecordItem SectMainStoryBaihuaManiaAttack => Instance[(short)823];

		/// <summary>
		/// SectMainStoryBaihuaManiaAttacked
		/// </summary>
		public static LifeRecordItem SectMainStoryBaihuaManiaAttacked => Instance[(short)824];

		/// <summary>
		/// SectMainStoryBaihuaManiaCure
		/// </summary>
		public static LifeRecordItem SectMainStoryBaihuaManiaCure => Instance[(short)825];

		/// <summary>
		/// SectMainStoryBaihuaManiaCured
		/// </summary>
		public static LifeRecordItem SectMainStoryBaihuaManiaCured => Instance[(short)826];

		/// <summary>
		/// GiveUpLegendaryBookSuccessHuaJu
		/// </summary>
		public static LifeRecordItem GiveUpLegendaryBookSuccessHuaJu => Instance[(short)827];

		/// <summary>
		/// GiveUpLegendaryBookSuccessXuanZhi
		/// </summary>
		public static LifeRecordItem GiveUpLegendaryBookSuccessXuanZhi => Instance[(short)828];

		/// <summary>
		/// GiveUpLegendaryBookSuccessYingJiao
		/// </summary>
		public static LifeRecordItem GiveUpLegendaryBookSuccessYingJiao => Instance[(short)829];

		/// <summary>
		/// SecretMakeEnemy2
		/// </summary>
		public static LifeRecordItem SecretMakeEnemy2 => Instance[(short)830];

		/// <summary>
		/// SecretBeMadeEnemy2
		/// </summary>
		public static LifeRecordItem SecretBeMadeEnemy2 => Instance[(short)831];

		/// <summary>
		/// DecideToHuntFugitive
		/// </summary>
		public static LifeRecordItem DecideToHuntFugitive => Instance[(short)832];

		/// <summary>
		/// FinishHuntFugitive
		/// </summary>
		public static LifeRecordItem FinishHuntFugitive => Instance[(short)833];

		/// <summary>
		/// DecideToEscapePunishment
		/// </summary>
		public static LifeRecordItem DecideToEscapePunishment => Instance[(short)834];

		/// <summary>
		/// FinishEscapePunishment
		/// </summary>
		public static LifeRecordItem FinishEscapePunishment => Instance[(short)835];

		/// <summary>
		/// DecideToSeekAsylum
		/// </summary>
		public static LifeRecordItem DecideToSeekAsylum => Instance[(short)836];

		/// <summary>
		/// FinishSeekAsylum
		/// </summary>
		public static LifeRecordItem FinishSeekAsylum => Instance[(short)837];

		/// <summary>
		/// SeekAsylumSuccess
		/// </summary>
		public static LifeRecordItem SeekAsylumSuccess => Instance[(short)838];

		/// <summary>
		/// DecideToEscortPrisoner
		/// </summary>
		public static LifeRecordItem DecideToEscortPrisoner => Instance[(short)839];

		/// <summary>
		/// EscortPrisonerSucceed
		/// </summary>
		public static LifeRecordItem EscortPrisonerSucceed => Instance[(short)840];

		/// <summary>
		/// ImprisonedShaoLin
		/// </summary>
		public static LifeRecordItem ImprisonedShaoLin => Instance[(short)841];

		/// <summary>
		/// ImprisonedEmei1
		/// </summary>
		public static LifeRecordItem ImprisonedEmei1 => Instance[(short)842];

		/// <summary>
		/// ImprisonedEmei2
		/// </summary>
		public static LifeRecordItem ImprisonedEmei2 => Instance[(short)843];

		/// <summary>
		/// ImprisonedBaihua
		/// </summary>
		public static LifeRecordItem ImprisonedBaihua => Instance[(short)844];

		/// <summary>
		/// ImprisonedWudang
		/// </summary>
		public static LifeRecordItem ImprisonedWudang => Instance[(short)845];

		/// <summary>
		/// ImprisonedYuanshan
		/// </summary>
		public static LifeRecordItem ImprisonedYuanshan => Instance[(short)846];

		/// <summary>
		/// ImprisonedShingXiang
		/// </summary>
		public static LifeRecordItem ImprisonedShingXiang => Instance[(short)847];

		/// <summary>
		/// ImprisonedRanShan
		/// </summary>
		public static LifeRecordItem ImprisonedRanShan => Instance[(short)848];

		/// <summary>
		/// ImprisonedXuanNv
		/// </summary>
		public static LifeRecordItem ImprisonedXuanNv => Instance[(short)849];

		/// <summary>
		/// ImprisonedZhuJian
		/// </summary>
		public static LifeRecordItem ImprisonedZhuJian => Instance[(short)850];

		/// <summary>
		/// ImprisonedKongSang
		/// </summary>
		public static LifeRecordItem ImprisonedKongSang => Instance[(short)851];

		/// <summary>
		/// ImprisonedJinGang
		/// </summary>
		public static LifeRecordItem ImprisonedJinGang => Instance[(short)852];

		/// <summary>
		/// ImprisonedWuXian
		/// </summary>
		public static LifeRecordItem ImprisonedWuXian => Instance[(short)853];

		/// <summary>
		/// ImprisonedJieQing1
		/// </summary>
		public static LifeRecordItem ImprisonedJieQing1 => Instance[(short)854];

		/// <summary>
		/// ImprisonedJieQing2
		/// </summary>
		public static LifeRecordItem ImprisonedJieQing2 => Instance[(short)855];

		/// <summary>
		/// ImprisonedFuLong
		/// </summary>
		public static LifeRecordItem ImprisonedFuLong => Instance[(short)856];

		/// <summary>
		/// ImprisonedXueHou
		/// </summary>
		public static LifeRecordItem ImprisonedXueHou => Instance[(short)857];

		/// <summary>
		/// IntrudePrisonCancelSupportMakeEnemyNpc
		/// </summary>
		public static LifeRecordItem IntrudePrisonCancelSupportMakeEnemyNpc => Instance[(short)858];

		/// <summary>
		/// IntrudePrisonCancelSupportMakeEnemyTaiwu
		/// </summary>
		public static LifeRecordItem IntrudePrisonCancelSupportMakeEnemyTaiwu => Instance[(short)859];

		/// <summary>
		/// IntrudePrisonCancelSupportNpc
		/// </summary>
		public static LifeRecordItem IntrudePrisonCancelSupportNpc => Instance[(short)860];

		/// <summary>
		/// IntrudePrisonCancelSupportTaiwu
		/// </summary>
		public static LifeRecordItem IntrudePrisonCancelSupportTaiwu => Instance[(short)861];

		/// <summary>
		/// IntrudePrisonMakeEnemyOthersNpc
		/// </summary>
		public static LifeRecordItem IntrudePrisonMakeEnemyOthersNpc => Instance[(short)862];

		/// <summary>
		/// IntrudePrisonMakeEnemyOthersTaiwu
		/// </summary>
		public static LifeRecordItem IntrudePrisonMakeEnemyOthersTaiwu => Instance[(short)863];

		/// <summary>
		/// RequestTheReleaseOfTheCriminalNpc
		/// </summary>
		public static LifeRecordItem RequestTheReleaseOfTheCriminalNpc => Instance[(short)864];

		/// <summary>
		/// RequestTheReleaseOfTheCriminalTaiwu
		/// </summary>
		public static LifeRecordItem RequestTheReleaseOfTheCriminalTaiwu => Instance[(short)865];

		/// <summary>
		/// ImprisonedXiangshuInfectedSupportIncreaseAndFavorabilityNpc
		/// </summary>
		public static LifeRecordItem ImprisonedXiangshuInfectedSupportIncreaseAndFavorabilityNpc => Instance[(short)866];

		/// <summary>
		/// ImprisonedXiangshuInfectedSupportIncreaseAndFavorabilityTaiwu
		/// </summary>
		public static LifeRecordItem ImprisonedXiangshuInfectedSupportIncreaseAndFavorabilityTaiwu => Instance[(short)867];

		/// <summary>
		/// ImprisonedXiangshuInfectedIncreaseFavorabilityNpc
		/// </summary>
		public static LifeRecordItem ImprisonedXiangshuInfectedIncreaseFavorabilityNpc => Instance[(short)868];

		/// <summary>
		/// ImprisonedXiangshuInfectedIncreaseFavorabilityTaiwu
		/// </summary>
		public static LifeRecordItem ImprisonedXiangshuInfectedIncreaseFavorabilityTaiwu => Instance[(short)869];

		/// <summary>
		/// ImprisonedXiangshuInfectedNpc
		/// </summary>
		public static LifeRecordItem ImprisonedXiangshuInfectedNpc => Instance[(short)870];

		/// <summary>
		/// ImprisonedXiangshuInfectedTaiwu
		/// </summary>
		public static LifeRecordItem ImprisonedXiangshuInfectedTaiwu => Instance[(short)871];

		/// <summary>
		/// RobbedFromPrisonNpc
		/// </summary>
		public static LifeRecordItem RobbedFromPrisonNpc => Instance[(short)872];

		/// <summary>
		/// PrisonBreakIntrudePrisonCancelSupportMakeEnemyNpc
		/// </summary>
		public static LifeRecordItem PrisonBreakIntrudePrisonCancelSupportMakeEnemyNpc => Instance[(short)873];

		/// <summary>
		/// PrisonBreakIntrudePrisonCancelSupportMakeEnemyTaiwu
		/// </summary>
		public static LifeRecordItem PrisonBreakIntrudePrisonCancelSupportMakeEnemyTaiwu => Instance[(short)874];

		/// <summary>
		/// PrisonBreakIntrudePrisonCancelSupportNpc
		/// </summary>
		public static LifeRecordItem PrisonBreakIntrudePrisonCancelSupportNpc => Instance[(short)875];

		/// <summary>
		/// PrisonBreakIntrudePrisonCancelSupportTaiwu
		/// </summary>
		public static LifeRecordItem PrisonBreakIntrudePrisonCancelSupportTaiwu => Instance[(short)876];

		/// <summary>
		/// PrisonBreakIntrudePrisonMakeEnemyOthersNpc
		/// </summary>
		public static LifeRecordItem PrisonBreakIntrudePrisonMakeEnemyOthersNpc => Instance[(short)877];

		/// <summary>
		/// PrisonBreakIntrudePrisonMakeEnemyOthersTaiwu
		/// </summary>
		public static LifeRecordItem PrisonBreakIntrudePrisonMakeEnemyOthersTaiwu => Instance[(short)878];

		/// <summary>
		/// ResistArrestIntrudePrisonCancelSupportMakeEnemyNpc
		/// </summary>
		public static LifeRecordItem ResistArrestIntrudePrisonCancelSupportMakeEnemyNpc => Instance[(short)879];

		/// <summary>
		/// ResistArresPrisonBreakIntrudePrisonCancelSupportMakeEnemyTaiwu
		/// </summary>
		public static LifeRecordItem ResistArresPrisonBreakIntrudePrisonCancelSupportMakeEnemyTaiwu => Instance[(short)880];

		/// <summary>
		/// ResistArresPrisonBreakIntrudePrisonCancelSupportNpc
		/// </summary>
		public static LifeRecordItem ResistArresPrisonBreakIntrudePrisonCancelSupportNpc => Instance[(short)881];

		/// <summary>
		/// ResistArresPrisonBreakIntrudePrisonCancelSupportTaiwu
		/// </summary>
		public static LifeRecordItem ResistArresPrisonBreakIntrudePrisonCancelSupportTaiwu => Instance[(short)882];

		/// <summary>
		/// ResistArresPrisonBreakIntrudePrisonMakeEnemyOthersNpc
		/// </summary>
		public static LifeRecordItem ResistArresPrisonBreakIntrudePrisonMakeEnemyOthersNpc => Instance[(short)883];

		/// <summary>
		/// ResistArresPrisonBreakIntrudePrisonMakeEnemyOthersTaiwu
		/// </summary>
		public static LifeRecordItem ResistArresPrisonBreakIntrudePrisonMakeEnemyOthersTaiwu => Instance[(short)884];

		/// <summary>
		/// ArrestFailedCaptor
		/// </summary>
		public static LifeRecordItem ArrestFailedCaptor => Instance[(short)885];

		/// <summary>
		/// ArrestFailedCriminal
		/// </summary>
		public static LifeRecordItem ArrestFailedCriminal => Instance[(short)886];

		/// <summary>
		/// ResistArresEngageInBattleTaiwu
		/// </summary>
		public static LifeRecordItem ResistArresEngageInBattleTaiwu => Instance[(short)887];

		/// <summary>
		/// ArrestedSuccessfullyCaptor
		/// </summary>
		public static LifeRecordItem ArrestedSuccessfullyCaptor => Instance[(short)888];

		/// <summary>
		/// ArrestedSuccessfullyCriminal
		/// </summary>
		public static LifeRecordItem ArrestedSuccessfullyCriminal => Instance[(short)889];

		/// <summary>
		/// ReceiveCriminalsCaptor
		/// </summary>
		public static LifeRecordItem ReceiveCriminalsCaptor => Instance[(short)890];

		/// <summary>
		/// ReceiveCriminalsTaiwu
		/// </summary>
		public static LifeRecordItem ReceiveCriminalsTaiwu => Instance[(short)891];

		/// <summary>
		/// ReceiveCriminalsCriminal
		/// </summary>
		public static LifeRecordItem ReceiveCriminalsCriminal => Instance[(short)892];

		/// <summary>
		/// BuyHandOverTheCriminalCaptor
		/// </summary>
		public static LifeRecordItem BuyHandOverTheCriminalCaptor => Instance[(short)893];

		/// <summary>
		/// BuyHandOverTheCriminalTaiwu
		/// </summary>
		public static LifeRecordItem BuyHandOverTheCriminalTaiwu => Instance[(short)894];

		/// <summary>
		/// LifeSkillBattleHandOverTheCriminalCaptor
		/// </summary>
		public static LifeRecordItem LifeSkillBattleHandOverTheCriminalCaptor => Instance[(short)895];

		/// <summary>
		/// LifeSkillBattleHandOverTheCriminalTaiwu
		/// </summary>
		public static LifeRecordItem LifeSkillBattleHandOverTheCriminalTaiwu => Instance[(short)896];

		/// <summary>
		/// LifeSkillBattleLoseHandOverTheCriminalCaptor
		/// </summary>
		public static LifeRecordItem LifeSkillBattleLoseHandOverTheCriminalCaptor => Instance[(short)897];

		/// <summary>
		/// LifeSkillBattleLoseHandOverTheCriminalTaiwu
		/// </summary>
		public static LifeRecordItem LifeSkillBattleLoseHandOverTheCriminalTaiwu => Instance[(short)898];

		/// <summary>
		/// VictoryInCombatHandOverTheCriminalCaptor
		/// </summary>
		public static LifeRecordItem VictoryInCombatHandOverTheCriminalCaptor => Instance[(short)899];

		/// <summary>
		/// VictoryInCombatHandOverTheCriminalTaiwu
		/// </summary>
		public static LifeRecordItem VictoryInCombatHandOverTheCriminalTaiwu => Instance[(short)900];

		/// <summary>
		/// FailureInCombatHandOverTheCriminalCaptor
		/// </summary>
		public static LifeRecordItem FailureInCombatHandOverTheCriminalCaptor => Instance[(short)901];

		/// <summary>
		/// FailureInCombatHandOverTheCriminalTaiwu
		/// </summary>
		public static LifeRecordItem FailureInCombatHandOverTheCriminalTaiwu => Instance[(short)902];

		/// <summary>
		/// SectMainStoryFulongFightSucceed
		/// </summary>
		public static LifeRecordItem SectMainStoryFulongFightSucceed => Instance[(short)903];

		/// <summary>
		/// SectMainStoryFulongFightFail
		/// </summary>
		public static LifeRecordItem SectMainStoryFulongFightFail => Instance[(short)904];

		/// <summary>
		/// SectMainStoryFulongRobbery
		/// </summary>
		public static LifeRecordItem SectMainStoryFulongRobbery => Instance[(short)905];

		/// <summary>
		/// SectMainStoryFulongRobberKilledByTaiwu
		/// </summary>
		public static LifeRecordItem SectMainStoryFulongRobberKilledByTaiwu => Instance[(short)906];

		/// <summary>
		/// SectMainStoryFulongProtect
		/// </summary>
		public static LifeRecordItem SectMainStoryFulongProtect => Instance[(short)907];

		/// <summary>
		/// HonestSectPunishLevel1
		/// </summary>
		public static LifeRecordItem HonestSectPunishLevel1 => Instance[(short)908];

		/// <summary>
		/// HonestSectPunishLevel2
		/// </summary>
		public static LifeRecordItem HonestSectPunishLevel2 => Instance[(short)909];

		/// <summary>
		/// HonestSectPunishLevel3
		/// </summary>
		public static LifeRecordItem HonestSectPunishLevel3 => Instance[(short)910];

		/// <summary>
		/// HonestSectPunishLevel4
		/// </summary>
		public static LifeRecordItem HonestSectPunishLevel4 => Instance[(short)911];

		/// <summary>
		/// HonestSectPunishLevel5
		/// </summary>
		public static LifeRecordItem HonestSectPunishLevel5 => Instance[(short)912];

		/// <summary>
		/// HonestSectPunishTogetherWithSpouseLevel5
		/// </summary>
		public static LifeRecordItem HonestSectPunishTogetherWithSpouseLevel5 => Instance[(short)913];

		/// <summary>
		/// ArrestedSectPunishLevel1
		/// </summary>
		public static LifeRecordItem ArrestedSectPunishLevel1 => Instance[(short)914];

		/// <summary>
		/// ArrestedSectPunishLevel2
		/// </summary>
		public static LifeRecordItem ArrestedSectPunishLevel2 => Instance[(short)915];

		/// <summary>
		/// ArrestedSectPunishLevel3
		/// </summary>
		public static LifeRecordItem ArrestedSectPunishLevel3 => Instance[(short)916];

		/// <summary>
		/// ArrestedSectPunishLevel4
		/// </summary>
		public static LifeRecordItem ArrestedSectPunishLevel4 => Instance[(short)917];

		/// <summary>
		/// ArrestedSectPunishLevel5
		/// </summary>
		public static LifeRecordItem ArrestedSectPunishLevel5 => Instance[(short)918];

		/// <summary>
		/// ArrestedSectPunishTogetherWithSpouseLevel5
		/// </summary>
		public static LifeRecordItem ArrestedSectPunishTogetherWithSpouseLevel5 => Instance[(short)919];

		/// <summary>
		/// BeImplicatedSectPunishLevel5
		/// </summary>
		public static LifeRecordItem BeImplicatedSectPunishLevel5 => Instance[(short)920];

		/// <summary>
		/// BeReleasedUponCompletionOfASentence
		/// </summary>
		public static LifeRecordItem BeReleasedUponCompletionOfASentence => Instance[(short)921];

		/// <summary>
		/// PrisonBreak
		/// </summary>
		public static LifeRecordItem PrisonBreak => Instance[(short)922];

		/// <summary>
		/// SendingToPrison1Taiwu
		/// </summary>
		public static LifeRecordItem SendingToPrison1Taiwu => Instance[(short)923];

		/// <summary>
		/// SendingToPrison2Taiwu
		/// </summary>
		public static LifeRecordItem SendingToPrison2Taiwu => Instance[(short)924];

		/// <summary>
		/// SendingToPrisonCriminal
		/// </summary>
		public static LifeRecordItem SendingToPrisonCriminal => Instance[(short)925];

		/// <summary>
		/// SentToPrisonTaiwu
		/// </summary>
		public static LifeRecordItem SentToPrisonTaiwu => Instance[(short)926];

		/// <summary>
		/// SentToPrisonCriminal
		/// </summary>
		public static LifeRecordItem SentToPrisonCriminal => Instance[(short)927];

		/// <summary>
		/// CatchCriminalsWinTaiwu
		/// </summary>
		public static LifeRecordItem CatchCriminalsWinTaiwu => Instance[(short)928];

		/// <summary>
		/// CatchCriminalsWinCriminal
		/// </summary>
		public static LifeRecordItem CatchCriminalsWinCriminal => Instance[(short)929];

		/// <summary>
		/// CatchCriminalsFailedTaiwu
		/// </summary>
		public static LifeRecordItem CatchCriminalsFailedTaiwu => Instance[(short)930];

		/// <summary>
		/// CatchCriminalsFailedCriminal
		/// </summary>
		public static LifeRecordItem CatchCriminalsFailedCriminal => Instance[(short)931];

		/// <summary>
		/// BuyHandOverTheCriminalCaptorByExp
		/// </summary>
		public static LifeRecordItem BuyHandOverTheCriminalCaptorByExp => Instance[(short)932];

		/// <summary>
		/// BuyHandOverTheCriminalTaiwuByExp
		/// </summary>
		public static LifeRecordItem BuyHandOverTheCriminalTaiwuByExp => Instance[(short)933];

		/// <summary>
		/// SendingToPrison1TaiwuByExp
		/// </summary>
		public static LifeRecordItem SendingToPrison1TaiwuByExp => Instance[(short)934];

		/// <summary>
		/// VillagerMigrateResources
		/// </summary>
		public static LifeRecordItem VillagerMigrateResources => Instance[(short)935];

		/// <summary>
		/// VillagerCookingIngredient
		/// </summary>
		public static LifeRecordItem VillagerCookingIngredient => Instance[(short)936];

		/// <summary>
		/// VillagerMakingItem
		/// </summary>
		public static LifeRecordItem VillagerMakingItem => Instance[(short)937];

		/// <summary>
		/// VillagerRepairItem0
		/// </summary>
		public static LifeRecordItem VillagerRepairItem0 => Instance[(short)938];

		/// <summary>
		/// VillagerRepairItem1
		/// </summary>
		public static LifeRecordItem VillagerRepairItem1 => Instance[(short)939];

		/// <summary>
		/// VillagerDisassembleItem0
		/// </summary>
		public static LifeRecordItem VillagerDisassembleItem0 => Instance[(short)940];

		/// <summary>
		/// VillagerDisassembleItem1
		/// </summary>
		public static LifeRecordItem VillagerDisassembleItem1 => Instance[(short)941];

		/// <summary>
		/// VillagerRefiningMedicine
		/// </summary>
		public static LifeRecordItem VillagerRefiningMedicine => Instance[(short)942];

		/// <summary>
		/// VillagerDetoxify0
		/// </summary>
		public static LifeRecordItem VillagerDetoxify0 => Instance[(short)943];

		/// <summary>
		/// VillagerDetoxify1
		/// </summary>
		public static LifeRecordItem VillagerDetoxify1 => Instance[(short)944];

		/// <summary>
		/// VillagerEnvenomedItem
		/// </summary>
		public static LifeRecordItem VillagerEnvenomedItem => Instance[(short)945];

		/// <summary>
		/// VillagerSoldItem
		/// </summary>
		public static LifeRecordItem VillagerSoldItem => Instance[(short)946];

		/// <summary>
		/// VillagerBuyItem
		/// </summary>
		public static LifeRecordItem VillagerBuyItem => Instance[(short)947];

		/// <summary>
		/// VillagerSeverEnemy
		/// </summary>
		public static LifeRecordItem VillagerSeverEnemy => Instance[(short)948];

		/// <summary>
		/// VillagerEmotionUp
		/// </summary>
		public static LifeRecordItem VillagerEmotionUp => Instance[(short)949];

		/// <summary>
		/// VillagerMakeFriends
		/// </summary>
		public static LifeRecordItem VillagerMakeFriends => Instance[(short)950];

		/// <summary>
		/// VillagerGetMarried
		/// </summary>
		public static LifeRecordItem VillagerGetMarried => Instance[(short)951];

		/// <summary>
		/// VillagerBecomeBrothers
		/// </summary>
		public static LifeRecordItem VillagerBecomeBrothers => Instance[(short)952];

		/// <summary>
		/// VillagerAdopt
		/// </summary>
		public static LifeRecordItem VillagerAdopt => Instance[(short)953];

		/// <summary>
		/// VillagerTreatment0
		/// </summary>
		public static LifeRecordItem VillagerTreatment0 => Instance[(short)954];

		/// <summary>
		/// VillagerTreatment1
		/// </summary>
		public static LifeRecordItem VillagerTreatment1 => Instance[(short)955];

		/// <summary>
		/// VillagerBeTreatment0
		/// </summary>
		public static LifeRecordItem VillagerBeTreatment0 => Instance[(short)956];

		/// <summary>
		/// VillagerBeTreatment1
		/// </summary>
		public static LifeRecordItem VillagerBeTreatment1 => Instance[(short)957];

		/// <summary>
		/// XiangshuInfectedPrisonTaiwuVillage
		/// </summary>
		public static LifeRecordItem XiangshuInfectedPrisonTaiwuVillage => Instance[(short)958];

		/// <summary>
		/// XiangshuInfectedPrisonSettlement
		/// </summary>
		public static LifeRecordItem XiangshuInfectedPrisonSettlement => Instance[(short)959];

		/// <summary>
		/// VillagerBeRepairItem1
		/// </summary>
		public static LifeRecordItem VillagerBeRepairItem1 => Instance[(short)960];

		/// <summary>
		/// TaiwuVillagerTakeItem
		/// </summary>
		public static LifeRecordItem TaiwuVillagerTakeItem => Instance[(short)961];

		/// <summary>
		/// TaiwuVillagerStorageItem
		/// </summary>
		public static LifeRecordItem TaiwuVillagerStorageItem => Instance[(short)962];

		/// <summary>
		/// TaiwuVillagerStorageResources
		/// </summary>
		public static LifeRecordItem TaiwuVillagerStorageResources => Instance[(short)963];

		/// <summary>
		/// TaiwuVillagerTakeResources
		/// </summary>
		public static LifeRecordItem TaiwuVillagerTakeResources => Instance[(short)964];

		/// <summary>
		/// LiteratiEntertainingUp
		/// </summary>
		public static LifeRecordItem LiteratiEntertainingUp => Instance[(short)965];

		/// <summary>
		/// LiteratiEntertainingDown
		/// </summary>
		public static LifeRecordItem LiteratiEntertainingDown => Instance[(short)966];

		/// <summary>
		/// LiteratiBuildingRelationshipUp
		/// </summary>
		public static LifeRecordItem LiteratiBuildingRelationshipUp => Instance[(short)967];

		/// <summary>
		/// LiteratiBuildingRelationshipDown
		/// </summary>
		public static LifeRecordItem LiteratiBuildingRelationshipDown => Instance[(short)968];

		/// <summary>
		/// LiteratiSpreadingInfluenceUp
		/// </summary>
		public static LifeRecordItem LiteratiSpreadingInfluenceUp => Instance[(short)969];

		/// <summary>
		/// LiteratiSpreadingInfluenceDown
		/// </summary>
		public static LifeRecordItem LiteratiSpreadingInfluenceDown => Instance[(short)970];

		/// <summary>
		/// SwordTombKeeperBuildingRelationshipUp
		/// </summary>
		public static LifeRecordItem SwordTombKeeperBuildingRelationshipUp => Instance[(short)971];

		/// <summary>
		/// SwordTombKeeperBuildingRelationshipDown
		/// </summary>
		public static LifeRecordItem SwordTombKeeperBuildingRelationshipDown => Instance[(short)972];

		/// <summary>
		/// SwordTombKeeperSpreadingInfluenceUp
		/// </summary>
		public static LifeRecordItem SwordTombKeeperSpreadingInfluenceUp => Instance[(short)973];

		/// <summary>
		/// SwordTombKeeperSpreadingInfluenceDown
		/// </summary>
		public static LifeRecordItem SwordTombKeeperSpreadingInfluenceDown => Instance[(short)974];

		/// <summary>
		/// InquireSwordTomb
		/// </summary>
		public static LifeRecordItem InquireSwordTomb => Instance[(short)975];

		/// <summary>
		/// GuardingSwordTomb
		/// </summary>
		public static LifeRecordItem GuardingSwordTomb => Instance[(short)976];

		/// <summary>
		/// VillagerPrioritizedActions
		/// </summary>
		public static LifeRecordItem VillagerPrioritizedActions => Instance[(short)977];

		/// <summary>
		/// VillagerPrioritizedActionsStop
		/// </summary>
		public static LifeRecordItem VillagerPrioritizedActionsStop => Instance[(short)978];

		/// <summary>
		/// EnvenomedItemOverload
		/// </summary>
		public static LifeRecordItem EnvenomedItemOverload => Instance[(short)979];

		/// <summary>
		/// DetoxifyItemOverload
		/// </summary>
		public static LifeRecordItem DetoxifyItemOverload => Instance[(short)980];

		/// <summary>
		/// VillagerEnvenomedItemOverload
		/// </summary>
		public static LifeRecordItem VillagerEnvenomedItemOverload => Instance[(short)981];

		/// <summary>
		/// VillagerDetoxifyItemOverload
		/// </summary>
		public static LifeRecordItem VillagerDetoxifyItemOverload => Instance[(short)982];

		/// <summary>
		/// VillagerCookingIngredientFailed0
		/// </summary>
		public static LifeRecordItem VillagerCookingIngredientFailed0 => Instance[(short)983];

		/// <summary>
		/// VillagerCookingIngredientFailed1
		/// </summary>
		public static LifeRecordItem VillagerCookingIngredientFailed1 => Instance[(short)984];

		/// <summary>
		/// VillagerMakingItemFailed0
		/// </summary>
		public static LifeRecordItem VillagerMakingItemFailed0 => Instance[(short)985];

		/// <summary>
		/// VillagerMakingItemFailed1
		/// </summary>
		public static LifeRecordItem VillagerMakingItemFailed1 => Instance[(short)986];

		/// <summary>
		/// VillagerRepairFailed
		/// </summary>
		public static LifeRecordItem VillagerRepairFailed => Instance[(short)987];

		/// <summary>
		/// VillagerDisassembleItemFailed
		/// </summary>
		public static LifeRecordItem VillagerDisassembleItemFailed => Instance[(short)988];

		/// <summary>
		/// VillagerRefiningMedicineFailed0
		/// </summary>
		public static LifeRecordItem VillagerRefiningMedicineFailed0 => Instance[(short)989];

		/// <summary>
		/// VillagerRefiningMedicineFailed1
		/// </summary>
		public static LifeRecordItem VillagerRefiningMedicineFailed1 => Instance[(short)990];

		/// <summary>
		/// VillagerAddPoisonToItemFailed
		/// </summary>
		public static LifeRecordItem VillagerAddPoisonToItemFailed => Instance[(short)991];

		/// <summary>
		/// VillagerDetoxItemFailed
		/// </summary>
		public static LifeRecordItem VillagerDetoxItemFailed => Instance[(short)992];

		/// <summary>
		/// VillagerDistanceFailed0
		/// </summary>
		public static LifeRecordItem VillagerDistanceFailed0 => Instance[(short)993];

		/// <summary>
		/// VillagerDistanceFailed1
		/// </summary>
		public static LifeRecordItem VillagerDistanceFailed1 => Instance[(short)994];

		/// <summary>
		/// VillagerDistanceFailed2
		/// </summary>
		public static LifeRecordItem VillagerDistanceFailed2 => Instance[(short)995];

		/// <summary>
		/// VillagerAttainmentsFailed
		/// </summary>
		public static LifeRecordItem VillagerAttainmentsFailed => Instance[(short)996];

		/// <summary>
		/// TaiwuPunishmentTongyong
		/// </summary>
		public static LifeRecordItem TaiwuPunishmentTongyong => Instance[(short)997];

		/// <summary>
		/// TaiwuPunishmentShaolin
		/// </summary>
		public static LifeRecordItem TaiwuPunishmentShaolin => Instance[(short)998];

		/// <summary>
		/// TaiwuPunishmentEmei
		/// </summary>
		public static LifeRecordItem TaiwuPunishmentEmei => Instance[(short)999];

		/// <summary>
		/// TaiwuPunishmentBaihua
		/// </summary>
		public static LifeRecordItem TaiwuPunishmentBaihua => Instance[(short)1000];

		/// <summary>
		/// TaiwuPunishmentWudang
		/// </summary>
		public static LifeRecordItem TaiwuPunishmentWudang => Instance[(short)1001];

		/// <summary>
		/// TaiwuPunishmentYuanshan
		/// </summary>
		public static LifeRecordItem TaiwuPunishmentYuanshan => Instance[(short)1002];

		/// <summary>
		/// TaiwuPunishmentShingXiang
		/// </summary>
		public static LifeRecordItem TaiwuPunishmentShingXiang => Instance[(short)1003];

		/// <summary>
		/// TaiwuPunishmentRanShan
		/// </summary>
		public static LifeRecordItem TaiwuPunishmentRanShan => Instance[(short)1004];

		/// <summary>
		/// TaiwuPunishmentXuanNv
		/// </summary>
		public static LifeRecordItem TaiwuPunishmentXuanNv => Instance[(short)1005];

		/// <summary>
		/// TaiwuPunishmentZhuJian
		/// </summary>
		public static LifeRecordItem TaiwuPunishmentZhuJian => Instance[(short)1006];

		/// <summary>
		/// TaiwuPunishmentKongSang
		/// </summary>
		public static LifeRecordItem TaiwuPunishmentKongSang => Instance[(short)1007];

		/// <summary>
		/// TaiwuPunishmentJinGang
		/// </summary>
		public static LifeRecordItem TaiwuPunishmentJinGang => Instance[(short)1008];

		/// <summary>
		/// TaiwuPunishmentWuXian
		/// </summary>
		public static LifeRecordItem TaiwuPunishmentWuXian => Instance[(short)1009];

		/// <summary>
		/// TaiwuPunishmentJieQing
		/// </summary>
		public static LifeRecordItem TaiwuPunishmentJieQing => Instance[(short)1010];

		/// <summary>
		/// TaiwuPunishmentFuLong
		/// </summary>
		public static LifeRecordItem TaiwuPunishmentFuLong => Instance[(short)1011];

		/// <summary>
		/// TaiwuPunishmentXueHou
		/// </summary>
		public static LifeRecordItem TaiwuPunishmentXueHou => Instance[(short)1012];

		/// <summary>
		/// SectPunishLevel5Expel
		/// </summary>
		public static LifeRecordItem SectPunishLevel5Expel => Instance[(short)1013];

		/// <summary>
		/// BeImplicatedSectPunishLevel5New
		/// </summary>
		public static LifeRecordItem BeImplicatedSectPunishLevel5New => Instance[(short)1014];

		/// <summary>
		/// BeImplicatedSectPunishLevel5Expel
		/// </summary>
		public static LifeRecordItem BeImplicatedSectPunishLevel5Expel => Instance[(short)1015];

		/// <summary>
		/// ResistArrestIntrudePrisonCancelSupportMakeEnemyNpcGuard
		/// </summary>
		public static LifeRecordItem ResistArrestIntrudePrisonCancelSupportMakeEnemyNpcGuard => Instance[(short)1016];

		/// <summary>
		/// ResistArresPrisonBreakIntrudePrisonCancelSupportMakeEnemyTaiwuWanted
		/// </summary>
		public static LifeRecordItem ResistArresPrisonBreakIntrudePrisonCancelSupportMakeEnemyTaiwuWanted => Instance[(short)1017];

		/// <summary>
		/// ResistArresPrisonBreakIntrudePrisonCancelSupportNpcGuard
		/// </summary>
		public static LifeRecordItem ResistArresPrisonBreakIntrudePrisonCancelSupportNpcGuard => Instance[(short)1018];

		/// <summary>
		/// ResistArresPrisonBreakIntrudePrisonCancelSupportTaiwuWanted
		/// </summary>
		public static LifeRecordItem ResistArresPrisonBreakIntrudePrisonCancelSupportTaiwuWanted => Instance[(short)1019];

		/// <summary>
		/// ResistArresPrisonBreakIntrudePrisonMakeEnemyOthersNpcGuard
		/// </summary>
		public static LifeRecordItem ResistArresPrisonBreakIntrudePrisonMakeEnemyOthersNpcGuard => Instance[(short)1020];

		/// <summary>
		/// ResistArresPrisonBreakIntrudePrisonMakeEnemyOthersTaiwuWanted
		/// </summary>
		public static LifeRecordItem ResistArresPrisonBreakIntrudePrisonMakeEnemyOthersTaiwuWanted => Instance[(short)1021];

		/// <summary>
		/// CivilianSkillForgive
		/// </summary>
		public static LifeRecordItem ForgiveForCivilianSkill => Instance[(short)1022];

		/// <summary>
		/// BeggarEatSomeoneFood
		/// </summary>
		public static LifeRecordItem BeggarEatSomeoneFood => Instance[(short)1023];

		/// <summary>
		/// SomeoneFoodEatedByBeggar
		/// </summary>
		public static LifeRecordItem SomeoneFoodEatedByBeggar => Instance[(short)1024];

		/// <summary>
		/// AristocratReleasePrisoner
		/// </summary>
		public static LifeRecordItem AristocratReleasePrisoner => Instance[(short)1025];

		/// <summary>
		/// PrisonerBeReleaseByAristocrat
		/// </summary>
		public static LifeRecordItem PrisonerBeReleaseByAristocrat => Instance[(short)1026];

		/// <summary>
		/// JieQingPunishmentAssassinSetOut
		/// </summary>
		public static LifeRecordItem JieQingPunishmentAssassinSetOut => Instance[(short)1027];

		/// <summary>
		/// JieQingPunishmentAssassinSucceed
		/// </summary>
		public static LifeRecordItem JieQingPunishmentAssassinSucceed => Instance[(short)1028];

		/// <summary>
		/// JieQingPunishmentAssassinBeSucceed
		/// </summary>
		public static LifeRecordItem JieQingPunishmentAssassinBeSucceed => Instance[(short)1029];

		/// <summary>
		/// JieQingPunishmentAssassinFailed
		/// </summary>
		public static LifeRecordItem JieQingPunishmentAssassinFailed => Instance[(short)1030];

		/// <summary>
		/// JieQingPunishmentAssassinBeFailed
		/// </summary>
		public static LifeRecordItem JieQingPunishmentAssassinBeFailed => Instance[(short)1031];

		/// <summary>
		/// JieQingPunishmentAssassinGiveUp
		/// </summary>
		public static LifeRecordItem JieQingPunishmentAssassinGiveUp => Instance[(short)1032];

		/// <summary>
		/// ExociseXiangshuInfectionVictoryInCombatDie
		/// </summary>
		public static LifeRecordItem ExociseXiangshuInfectionVictoryInCombatDie => Instance[(short)1033];

		/// <summary>
		/// BecomeExociseXiangshuInfectionVictoryInCombatDie
		/// </summary>
		public static LifeRecordItem BecomeExociseXiangshuInfectionVictoryInCombatDie => Instance[(short)1034];

		/// <summary>
		/// ArrestFailedTaiwu
		/// </summary>
		public static LifeRecordItem ArrestFailedTaiwu => Instance[(short)1035];

		/// <summary>
		/// ArrestedSuccessfullyTaiwu
		/// </summary>
		public static LifeRecordItem ArrestedSuccessfullyTaiwu => Instance[(short)1036];

		/// <summary>
		/// LifeSkillBattleLoseAndTheArrestFailedCaptor
		/// </summary>
		public static LifeRecordItem LifeSkillBattleLoseAndTheArrestFailedCaptor => Instance[(short)1037];

		/// <summary>
		/// LifeSkillBattleWinAndAvoidArrestTaiwu
		/// </summary>
		public static LifeRecordItem LifeSkillBattleWinAndAvoidArrestTaiwu => Instance[(short)1038];

		/// <summary>
		/// LifeSkillBattleWinAndSuccessfulArrestCaptor
		/// </summary>
		public static LifeRecordItem LifeSkillBattleWinAndSuccessfulArrestCaptor => Instance[(short)1039];

		/// <summary>
		/// LifeSkillBattleLoseAndWasArrestedTaiwu
		/// </summary>
		public static LifeRecordItem LifeSkillBattleLoseAndWasArrestedTaiwu => Instance[(short)1040];

		/// <summary>
		/// FailedArrestForBriberyCaptorByAuthority
		/// </summary>
		public static LifeRecordItem FailedArrestForBriberyCaptorByAuthority => Instance[(short)1041];

		/// <summary>
		/// BribeSucceededInAvoidingArrestTaiwuByAuthority
		/// </summary>
		public static LifeRecordItem BribeSucceededInAvoidingArrestTaiwuByAuthority => Instance[(short)1042];

		/// <summary>
		/// FailedArrestForBriberyCaptorByExp
		/// </summary>
		public static LifeRecordItem FailedArrestForBriberyCaptorByExp => Instance[(short)1043];

		/// <summary>
		/// BribeSucceededInAvoidingArrestTaiwuByExp
		/// </summary>
		public static LifeRecordItem BribeSucceededInAvoidingArrestTaiwuByExp => Instance[(short)1044];

		/// <summary>
		/// FailedArrestForBriberyCaptorByMoney
		/// </summary>
		public static LifeRecordItem FailedArrestForBriberyCaptorByMoney => Instance[(short)1045];

		/// <summary>
		/// BribeSucceededInAvoidingArrestTaiwuByMoney
		/// </summary>
		public static LifeRecordItem BribeSucceededInAvoidingArrestTaiwuByMoney => Instance[(short)1046];

		/// <summary>
		/// SubmitToCaptureMeeklyTaiwu
		/// </summary>
		public static LifeRecordItem SubmitToCaptureMeeklyTaiwu => Instance[(short)1047];

		/// <summary>
		/// SubmitToCaptureMeeklyCaptor
		/// </summary>
		public static LifeRecordItem SubmitToCaptureMeeklyCaptor => Instance[(short)1048];

		/// <summary>
		/// NormalInformationChangeProfession
		/// </summary>
		public static LifeRecordItem NormalInformationChangeProfession => Instance[(short)1049];

		/// <summary>
		/// FeedTheAnimal
		/// </summary>
		public static LifeRecordItem FeedTheAnimal => Instance[(short)1050];

		/// <summary>
		/// ProfessionDoctorLifeTransition
		/// </summary>
		public static LifeRecordItem ProfessionDoctorLifeTransition => Instance[(short)1051];

		/// <summary>
		/// ProfessionDoctorLifeTransitionTaiwu
		/// </summary>
		public static LifeRecordItem ProfessionDoctorLifeTransitionTaiwu => Instance[(short)1052];

		/// <summary>
		/// CombatSkillKeyPointComprehensionByExp
		/// </summary>
		public static LifeRecordItem CombatSkillKeyPointComprehensionByExp => Instance[(short)1053];

		/// <summary>
		/// CombatSkillKeyPointComprehensionByItems
		/// </summary>
		public static LifeRecordItem CombatSkillKeyPointComprehensionByItems => Instance[(short)1054];

		/// <summary>
		/// CombatSkillKeyPointComprehensionByLoveRelationship
		/// </summary>
		public static LifeRecordItem CombatSkillKeyPointComprehensionByLoveRelationship => Instance[(short)1055];

		/// <summary>
		/// CombatSkillKeyPointComprehensionByHatredRelationship
		/// </summary>
		public static LifeRecordItem CombatSkillKeyPointComprehensionByHatredRelationship => Instance[(short)1056];

		/// <summary>
		/// SpiritualDebtKongsangPoisoned
		/// </summary>
		public static LifeRecordItem SpiritualDebtKongsangPoisoned => Instance[(short)1057];

		/// <summary>
		/// MartialArtistSkill3NPCItemDropCaseA
		/// </summary>
		public static LifeRecordItem MartialArtistSkill3NPCItemDropCaseA => Instance[(short)1058];

		/// <summary>
		/// MartialArtistSkill3NPCItemDropCaseB
		/// </summary>
		public static LifeRecordItem MartialArtistSkill3NPCItemDropCaseB => Instance[(short)1059];

		/// <summary>
		/// SectPunishElopeSucceedJust
		/// </summary>
		public static LifeRecordItem SectPunishElopeSucceedJust => Instance[(short)1060];

		/// <summary>
		/// SectPunishElopeSucceedKind
		/// </summary>
		public static LifeRecordItem SectPunishElopeSucceedKind => Instance[(short)1061];

		/// <summary>
		/// SectPunishElopeSucceedEven
		/// </summary>
		public static LifeRecordItem SectPunishElopeSucceedEven => Instance[(short)1062];

		/// <summary>
		/// SectPunishElopeSucceed
		/// </summary>
		public static LifeRecordItem SectPunishElopeSucceed => Instance[(short)1063];

		/// <summary>
		/// VillagerGetRefineItem
		/// </summary>
		public static LifeRecordItem VillagerGetRefineItem => Instance[(short)1064];

		/// <summary>
		/// VillagerUpgradeRefineItem
		/// </summary>
		public static LifeRecordItem VillagerUpgradeRefineItem => Instance[(short)1065];

		/// <summary>
		/// VillagerTreatmentTaiwu
		/// </summary>
		public static LifeRecordItem VillagerTreatmentTaiwu => Instance[(short)1066];

		/// <summary>
		/// VillagerReduceXiangshuInfect
		/// </summary>
		public static LifeRecordItem VillagerReduceXiangshuInfect => Instance[(short)1067];

		/// <summary>
		/// VillagerEarnMoney
		/// </summary>
		public static LifeRecordItem VillagerEarnMoney => Instance[(short)1068];

		/// <summary>
		/// VillagerBeEarnedMoney
		/// </summary>
		public static LifeRecordItem VillagerBeEarnedMoney => Instance[(short)1069];

		/// <summary>
		/// VillagerBeSoldItem
		/// </summary>
		public static LifeRecordItem VillagerBeSoldItem => Instance[(short)1070];

		/// <summary>
		/// VillagerBePurchasedItem
		/// </summary>
		public static LifeRecordItem VillagerBePurchasedItem => Instance[(short)1071];

		/// <summary>
		/// VillagerGetMerchantFavorability
		/// </summary>
		public static LifeRecordItem VillagerGetMerchantFavorability => Instance[(short)1072];

		/// <summary>
		/// VillagerGetMerchantFavorabilityTaiwu
		/// </summary>
		public static LifeRecordItem VillagerGetMerchantFavorabilityTaiwu => Instance[(short)1073];

		/// <summary>
		/// LiteratiBeEntertainedUp
		/// </summary>
		public static LifeRecordItem LiteratiBeEntertainedUp => Instance[(short)1074];

		/// <summary>
		/// LiteratiBeEntertainedDown
		/// </summary>
		public static LifeRecordItem LiteratiBeEntertainedDown => Instance[(short)1075];

		/// <summary>
		/// LiteratiSpreadingInfluenceCultureUp
		/// </summary>
		public static LifeRecordItem LiteratiSpreadingInfluenceCultureUp => Instance[(short)1076];

		/// <summary>
		/// LiteratiSpreadingInfluenceCultureDown
		/// </summary>
		public static LifeRecordItem LiteratiSpreadingInfluenceCultureDown => Instance[(short)1077];

		/// <summary>
		/// LiteratiSpreadingInfluenceSafetyUp
		/// </summary>
		public static LifeRecordItem LiteratiSpreadingInfluenceSafetyUp => Instance[(short)1078];

		/// <summary>
		/// LiteratiSpreadingInfluenceSafetyDown
		/// </summary>
		public static LifeRecordItem LiteratiSpreadingInfluenceSafetyDown => Instance[(short)1079];

		/// <summary>
		/// LiteratiConnectRelationshipUp
		/// </summary>
		public static LifeRecordItem LiteratiConnectRelationshipUp => Instance[(short)1080];

		/// <summary>
		/// LiteratiConnectRelationshipDown
		/// </summary>
		public static LifeRecordItem LiteratiConnectRelationshipDown => Instance[(short)1081];

		/// <summary>
		/// LiteratiConnectRelationshipUpTaiwu
		/// </summary>
		public static LifeRecordItem LiteratiConnectRelationshipUpTaiwu => Instance[(short)1082];

		/// <summary>
		/// LiteratiConnectRelationshipDownTaiwu
		/// </summary>
		public static LifeRecordItem LiteratiConnectRelationshipDownTaiwu => Instance[(short)1083];

		/// <summary>
		/// LiteratiBeConnectedRelationshipUp
		/// </summary>
		public static LifeRecordItem LiteratiBeConnectedRelationshipUp => Instance[(short)1084];

		/// <summary>
		/// LiteratiBeConnectedRelationshipDown
		/// </summary>
		public static LifeRecordItem LiteratiBeConnectedRelationshipDown => Instance[(short)1085];

		/// <summary>
		/// GuardingSwordTombXiangshuInfectUp
		/// </summary>
		public static LifeRecordItem GuardingSwordTombXiangshuInfectUp => Instance[(short)1086];

		/// <summary>
		/// GuardingSwordTombSucceed
		/// </summary>
		public static LifeRecordItem GuardingSwordTombSucceed => Instance[(short)1087];

		/// <summary>
		/// VillagerMakeEnemy
		/// </summary>
		public static LifeRecordItem VillagerMakeEnemy => Instance[(short)1088];

		/// <summary>
		/// VillagerConfessLoveSucceed
		/// </summary>
		public static LifeRecordItem VillagerConfessLoveSucceed => Instance[(short)1089];

		/// <summary>
		/// OrderProduct
		/// </summary>
		public static LifeRecordItem OrderProduct => Instance[(short)1090];

		/// <summary>
		/// ReceiveProduct
		/// </summary>
		public static LifeRecordItem ReceiveProduct => Instance[(short)1091];

		/// <summary>
		/// BeOrderProduct
		/// </summary>
		public static LifeRecordItem BeOrderProduct => Instance[(short)1092];

		/// <summary>
		/// BeReceiveProduct
		/// </summary>
		public static LifeRecordItem BeReceiveProduct => Instance[(short)1093];

		/// <summary>
		/// CaptureOrder
		/// </summary>
		public static LifeRecordItem CaptureOrder => Instance[(short)1094];

		/// <summary>
		/// BeCaptureOrder
		/// </summary>
		public static LifeRecordItem BeCaptureOrder => Instance[(short)1095];

		/// <summary>
		/// CaptureOrderIntermediator
		/// </summary>
		public static LifeRecordItem CaptureOrderIntermediator => Instance[(short)1096];

		/// <summary>
		/// OrderProductForOthers
		/// </summary>
		public static LifeRecordItem OrderProductForOthers => Instance[(short)1097];

		/// <summary>
		/// BeOrderProductForOthers
		/// </summary>
		public static LifeRecordItem BeOrderProductForOthers => Instance[(short)1098];

		/// <summary>
		/// DeliveredOrderProduct
		/// </summary>
		public static LifeRecordItem DeliveredOrderProduct => Instance[(short)1099];

		/// <summary>
		/// BeDeliveredOrderProduct
		/// </summary>
		public static LifeRecordItem BeDeliveredOrderProduct => Instance[(short)1100];

		/// <summary>
		/// AcquisitionDiscard
		/// </summary>
		public static LifeRecordItem AcquisitionDiscard => Instance[(short)1101];

		/// <summary>
		/// ShopBuildingBaseDevelopLifeSkill
		/// </summary>
		public static LifeRecordItem ShopBuildingBaseDevelopLifeSkill => Instance[(short)1102];

		/// <summary>
		/// ShopBuildingBaseDevelopCombatSkill
		/// </summary>
		public static LifeRecordItem ShopBuildingBaseDevelopCombatSkill => Instance[(short)1103];

		/// <summary>
		/// ShopBuildingPersonalityDevelopLifeSkill
		/// </summary>
		public static LifeRecordItem ShopBuildingPersonalityDevelopLifeSkill => Instance[(short)1104];

		/// <summary>
		/// ShopBuildingPersonalityDevelopCombatSkill
		/// </summary>
		public static LifeRecordItem ShopBuildingPersonalityDevelopCombatSkill => Instance[(short)1105];

		/// <summary>
		/// ShopBuildingLeaderDevelopLifeSkill
		/// </summary>
		public static LifeRecordItem ShopBuildingLeaderDevelopLifeSkill => Instance[(short)1106];

		/// <summary>
		/// ShopBuildingLeaderDevelopCombatSkill
		/// </summary>
		public static LifeRecordItem ShopBuildingLeaderDevelopCombatSkill => Instance[(short)1107];

		/// <summary>
		/// ShopBuildingLearnLifeSkill
		/// </summary>
		public static LifeRecordItem ShopBuildingLearnLifeSkill => Instance[(short)1108];

		/// <summary>
		/// ShopBuildingLearnCombatSkill
		/// </summary>
		public static LifeRecordItem ShopBuildingLearnCombatSkill => Instance[(short)1109];

		/// <summary>
		/// JoinTaiwuVillageAfterTaiwuVillageStoneClaimed
		/// </summary>
		public static LifeRecordItem JoinTaiwuVillageAfterTaiwuVillageStoneClaimed => Instance[(short)1110];

		/// <summary>
		/// TaiwuVillagerFinishedReading
		/// </summary>
		public static LifeRecordItem TaiwuVillagerFinishedReading => Instance[(short)1111];

		/// <summary>
		/// TaiwuVillagerSalaryReceived
		/// </summary>
		public static LifeRecordItem TaiwuVillagerSalaryReceived => Instance[(short)1112];

		/// <summary>
		/// ChangeGradeDrop
		/// </summary>
		public static LifeRecordItem ChangeGradeDrop => Instance[(short)1113];

		/// <summary>
		/// FarmerCollectMaterial
		/// </summary>
		public static LifeRecordItem FarmerCollectMaterial => Instance[(short)1114];

		/// <summary>
		/// JoinOrganization
		/// </summary>
		public static LifeRecordItem JoinOrganization => Instance[(short)1115];

		/// <summary>
		/// BreakAwayOrganization
		/// </summary>
		public static LifeRecordItem BreakAwayOrganization => Instance[(short)1116];

		/// <summary>
		/// ChangeOrganization
		/// </summary>
		public static LifeRecordItem ChangeOrganization => Instance[(short)1117];

		/// <summary>
		/// VillagerFavorabilityUp
		/// </summary>
		public static LifeRecordItem VillagerFavorabilityUp => Instance[(short)1118];

		/// <summary>
		/// VillagerFavorabilityDown
		/// </summary>
		public static LifeRecordItem VillagerFavorabilityDown => Instance[(short)1119];

		/// <summary>
		/// VillagerFavorabilityUpPerson
		/// </summary>
		public static LifeRecordItem VillagerFavorabilityUpPerson => Instance[(short)1120];

		/// <summary>
		/// VillagerFavorabilityDownPersonB
		/// </summary>
		public static LifeRecordItem VillagerFavorabilityDownPerson => Instance[(short)1121];

		/// <summary>
		/// TeamUpProtection
		/// </summary>
		public static LifeRecordItem TeamUpProtection => Instance[(short)1122];

		/// <summary>
		/// TeamUpRescue
		/// </summary>
		public static LifeRecordItem TeamUpRescue => Instance[(short)1123];

		/// <summary>
		/// TeamUpMourn
		/// </summary>
		public static LifeRecordItem TeamUpMourn => Instance[(short)1124];

		/// <summary>
		/// TeamUpVisitFriendOrFamily
		/// </summary>
		public static LifeRecordItem TeamUpVisitFriendOrFamily => Instance[(short)1125];

		/// <summary>
		/// TeamUpFindTreasure
		/// </summary>
		public static LifeRecordItem TeamUpFindTreasure => Instance[(short)1126];

		/// <summary>
		/// TeamUpFindSpecialMaterial
		/// </summary>
		public static LifeRecordItem TeamUpFindSpecialMaterial => Instance[(short)1127];

		/// <summary>
		/// TeamUpTakeRevenge
		/// </summary>
		public static LifeRecordItem TeamUpTakeRevenge => Instance[(short)1128];

		/// <summary>
		/// TeamUpContestForLegendaryBook
		/// </summary>
		public static LifeRecordItem TeamUpContestForLegendaryBook => Instance[(short)1129];

		/// <summary>
		/// TeamUpEscapeFromPrison
		/// </summary>
		public static LifeRecordItem TeamUpEscapeFromPrison => Instance[(short)1130];

		/// <summary>
		/// TeamUpSeekAsylum
		/// </summary>
		public static LifeRecordItem TeamUpSeekAsylum => Instance[(short)1131];

		/// <summary>
		/// GetInfected
		/// </summary>
		public static LifeRecordItem GetInfected => Instance[(short)1132];

		/// <summary>
		/// DieByInfected
		/// </summary>
		public static LifeRecordItem DieByInfected => Instance[(short)1133];

		/// <summary>
		/// InheritLegacy
		/// </summary>
		public static LifeRecordItem InheritLegacy => Instance[(short)1134];

		/// <summary>
		/// 低心情宾客服用了物品
		/// </summary>
		public static LifeRecordItem Banquet_1 => Instance[(short)1135];

		/// <summary>
		/// 低心情宾客服用了喜爱的物品
		/// </summary>
		public static LifeRecordItem Banquet_2 => Instance[(short)1136];

		/// <summary>
		/// 低心情宾客在宴席上服用了物品
		/// </summary>
		public static LifeRecordItem Banquet_3 => Instance[(short)1137];

		/// <summary>
		/// 低心情宾客在宴席上服用了喜爱的物品
		/// </summary>
		public static LifeRecordItem Banquet_4 => Instance[(short)1138];

		/// <summary>
		/// 宾客服用了物品
		/// </summary>
		public static LifeRecordItem Banquet_5 => Instance[(short)1139];

		/// <summary>
		/// 宾客服用了喜爱的物品
		/// </summary>
		public static LifeRecordItem Banquet_6 => Instance[(short)1140];

		/// <summary>
		/// 宾客在宴席上服用了物品
		/// </summary>
		public static LifeRecordItem Banquet_7 => Instance[(short)1141];

		/// <summary>
		/// 宾客在宴席上服用了喜爱的物品
		/// </summary>
		public static LifeRecordItem Banquet_8 => Instance[(short)1142];

		/// <summary>
		/// 宴堂没有可食用物品
		/// </summary>
		public static LifeRecordItem Banquet_9 => Instance[(short)1143];

		/// <summary>
		/// 宾客已经吃不下
		/// </summary>
		public static LifeRecordItem Banquet_10 => Instance[(short)1144];

		/// <summary>
		/// SectMainStoryWudangInjured
		/// </summary>
		public static LifeRecordItem SectMainStoryWudangInjured => Instance[(short)1145];

		/// <summary>
		/// ExtendDarkAshTime
		/// </summary>
		public static LifeRecordItem ExtendDarkAshTime => Instance[(short)1146];

		/// <summary>
		/// AdoreInMarriage
		/// </summary>
		public static LifeRecordItem AdoreInMarriage => Instance[(short)1147];

		/// <summary>
		/// SameAreaDistantMarriage
		/// </summary>
		public static LifeRecordItem SameAreaDistantMarriage => Instance[(short)1148];

		/// <summary>
		/// SameStateDistantMarriage
		/// </summary>
		public static LifeRecordItem SameStateDistantMarriage => Instance[(short)1149];

		/// <summary>
		/// DifferentStateDistantMarriage
		/// </summary>
		public static LifeRecordItem DifferentStateDistantMarriage => Instance[(short)1150];

		/// <summary>
		/// GoToOuterWorlds
		/// </summary>
		public static LifeRecordItem GoToOuterWorlds => Instance[(short)1151];

		/// <summary>
		/// BackFromOuterWorlds
		/// </summary>
		public static LifeRecordItem BackFromOuterWorlds => Instance[(short)1152];

		/// <summary>
		/// SectMainStoryXuehouJixiDrainNeili
		/// </summary>
		public static LifeRecordItem SectMainStoryXuehouJixiDrainNeili => Instance[(short)1153];

		/// <summary>
		/// SectMainStoryXuehouTaiwuTransferFiveElements
		/// </summary>
		public static LifeRecordItem SectMainStoryXuehouTaiwuTransferFiveElements => Instance[(short)1154];

		/// <summary>
		/// AlertnessUpBySecretInformation
		/// </summary>
		public static LifeRecordItem AlertnessUpBySecretInformation => Instance[(short)1155];

		/// <summary>
		/// AlertnessDownBySecretInformation
		/// </summary>
		public static LifeRecordItem AlertnessDownBySecretInformation => Instance[(short)1156];

		/// <summary>
		/// ConsummateLevelIncreased
		/// </summary>
		public static LifeRecordItem ConsummateLevelIncreased => Instance[(short)1157];

		/// <summary>
		/// CombatSkillQualificationGrowthGuaranteed
		/// </summary>
		public static LifeRecordItem CombatSkillQualificationGrowthGuaranteed => Instance[(short)1158];

		/// <summary>
		/// CombatSkillQualificationGrowthPersonality
		/// </summary>
		public static LifeRecordItem CombatSkillQualificationGrowthPersonality => Instance[(short)1159];

		/// <summary>
		/// CombatSkillQualificationGrowthMentor
		/// </summary>
		public static LifeRecordItem CombatSkillQualificationGrowthMentor => Instance[(short)1160];

		/// <summary>
		/// LifeSkillQualificationGrowthGuaranteed
		/// </summary>
		public static LifeRecordItem LifeSkillQualificationGrowthGuaranteed => Instance[(short)1161];

		/// <summary>
		/// LifeSkillQualificationGrowthPersonality
		/// </summary>
		public static LifeRecordItem LifeSkillQualificationGrowthPersonality => Instance[(short)1162];

		/// <summary>
		/// LifeSkillQualificationGrowthMentor
		/// </summary>
		public static LifeRecordItem LifeSkillQualificationGrowthMentor => Instance[(short)1163];

		/// <summary>
		/// IdentityActionHelpCivilians
		/// </summary>
		public static LifeRecordItem IdentityActionHelpCivilians => Instance[(short)1164];

		/// <summary>
		/// IdentityActionHelpCiviliansTarget
		/// </summary>
		public static LifeRecordItem IdentityActionHelpCiviliansTarget => Instance[(short)1205];

		/// <summary>
		/// IdentityActionFightHeretics
		/// </summary>
		public static LifeRecordItem IdentityActionFightHeretics => Instance[(short)1165];

		/// <summary>
		/// IdentityActionFightHereticsTarget
		/// </summary>
		public static LifeRecordItem IdentityActionFightHereticsTarget => Instance[(short)1206];

		/// <summary>
		/// IdentityActionShaolin0
		/// </summary>
		public static LifeRecordItem IdentityActionShaolin0 => Instance[(short)1166];

		/// <summary>
		/// IdentityActionShaolin0Target
		/// </summary>
		public static LifeRecordItem IdentityActionShaolin0Target => Instance[(short)1207];

		/// <summary>
		/// IdentityActionShaolin1
		/// </summary>
		public static LifeRecordItem IdentityActionShaolin1 => Instance[(short)1167];

		/// <summary>
		/// IdentityActionShaolin2
		/// </summary>
		public static LifeRecordItem IdentityActionShaolin2 => Instance[(short)1168];

		/// <summary>
		/// IdentityActionShaolin2Target
		/// </summary>
		public static LifeRecordItem IdentityActionShaolin2Target => Instance[(short)1208];

		/// <summary>
		/// IdentityActionShaolin3
		/// </summary>
		public static LifeRecordItem IdentityActionShaolin3 => Instance[(short)1169];

		/// <summary>
		/// IdentityActionShaolin4
		/// </summary>
		public static LifeRecordItem IdentityActionShaolin4 => Instance[(short)1170];

		/// <summary>
		/// IdentityActionShaolin4Target
		/// </summary>
		public static LifeRecordItem IdentityActionShaolin4Target => Instance[(short)1375];

		/// <summary>
		/// IdentityActionShaolin5
		/// </summary>
		public static LifeRecordItem IdentityActionShaolin5 => Instance[(short)1171];

		/// <summary>
		/// IdentityActionShaolin5Target
		/// </summary>
		public static LifeRecordItem IdentityActionShaolin5Target => Instance[(short)1376];

		/// <summary>
		/// IdentityActionShaolin6
		/// </summary>
		public static LifeRecordItem IdentityActionShaolin6 => Instance[(short)1172];

		/// <summary>
		/// IdentityActionEmei0
		/// </summary>
		public static LifeRecordItem IdentityActionEmei0 => Instance[(short)1173];

		/// <summary>
		/// IdentityActionEmei0Target
		/// </summary>
		public static LifeRecordItem IdentityActionEmei0Target => Instance[(short)1380];

		/// <summary>
		/// IdentityActionEmei1
		/// </summary>
		public static LifeRecordItem IdentityActionEmei1 => Instance[(short)1174];

		/// <summary>
		/// IdentityActionEmei4
		/// </summary>
		public static LifeRecordItem IdentityActionEmei4 => Instance[(short)1175];

		/// <summary>
		/// IdentityActionEmei4Target
		/// </summary>
		public static LifeRecordItem IdentityActionEmei4Target => Instance[(short)1209];

		/// <summary>
		/// IdentityActionEmei5
		/// </summary>
		public static LifeRecordItem IdentityActionEmei5 => Instance[(short)1176];

		/// <summary>
		/// IdentityActionEmei6
		/// </summary>
		public static LifeRecordItem IdentityActionEmei6 => Instance[(short)1177];

		/// <summary>
		/// IdentityActionEmei6Target
		/// </summary>
		public static LifeRecordItem IdentityActionEmei6Target => Instance[(short)1210];

		/// <summary>
		/// IdentityActionBaihua0
		/// </summary>
		public static LifeRecordItem IdentityActionBaihua0 => Instance[(short)1178];

		/// <summary>
		/// IdentityActionBaihua0Target
		/// </summary>
		public static LifeRecordItem IdentityActionBaihua0Target => Instance[(short)1211];

		/// <summary>
		/// IdentityActionBaihua1
		/// </summary>
		public static LifeRecordItem IdentityActionBaihua1 => Instance[(short)1179];

		/// <summary>
		/// IdentityActionBaihua2
		/// </summary>
		public static LifeRecordItem IdentityActionBaihua2 => Instance[(short)1180];

		/// <summary>
		/// IdentityActionBaihua3
		/// </summary>
		public static LifeRecordItem IdentityActionBaihua3 => Instance[(short)1181];

		/// <summary>
		/// IdentityActionBaihua3Target
		/// </summary>
		public static LifeRecordItem IdentityActionBaihua3Target => Instance[(short)1212];

		/// <summary>
		/// IdentityActionBaihua5
		/// </summary>
		public static LifeRecordItem IdentityActionBaihua5 => Instance[(short)1183];

		/// <summary>
		/// IdentityActionBaihua5Target
		/// </summary>
		public static LifeRecordItem IdentityActionBaihua5Target => Instance[(short)1213];

		/// <summary>
		/// IdentityActionWudang5
		/// </summary>
		public static LifeRecordItem IdentityActionWudang5 => Instance[(short)1188];

		/// <summary>
		/// IdentityActionYuanshan1
		/// </summary>
		public static LifeRecordItem IdentityActionYuanshan1 => Instance[(short)1191];

		/// <summary>
		/// IdentityActionYuanshan1Target
		/// </summary>
		public static LifeRecordItem IdentityActionYuanshan1Target => Instance[(short)1218];

		/// <summary>
		/// IdentityActionYuanshan2
		/// </summary>
		public static LifeRecordItem IdentityActionYuanshan2 => Instance[(short)1192];

		/// <summary>
		/// IdentityActionYuanshan3
		/// </summary>
		public static LifeRecordItem IdentityActionYuanshan3 => Instance[(short)1193];

		/// <summary>
		/// IdentityActionYuanshan3Target
		/// </summary>
		public static LifeRecordItem IdentityActionYuanshan3Target => Instance[(short)1219];

		/// <summary>
		/// IdentityActionYuanshan5
		/// </summary>
		public static LifeRecordItem IdentityActionYuanshan5 => Instance[(short)1194];

		/// <summary>
		/// IdentityActionYuanshan5Target
		/// </summary>
		public static LifeRecordItem IdentityActionYuanshan5Target => Instance[(short)1220];

		/// <summary>
		/// IdentityActionYuanshan6
		/// </summary>
		public static LifeRecordItem IdentityActionYuanshan6 => Instance[(short)1195];

		/// <summary>
		/// IdentityActionYuanshan6Target
		/// </summary>
		public static LifeRecordItem IdentityActionYuanshan6Target => Instance[(short)1384];

		/// <summary>
		/// IdentityActionShixiang0
		/// </summary>
		public static LifeRecordItem IdentityActionShixiang0 => Instance[(short)1196];

		/// <summary>
		/// IdentityActionShixiang1
		/// </summary>
		public static LifeRecordItem IdentityActionShixiang1 => Instance[(short)1197];

		/// <summary>
		/// IdentityActionShixiang2
		/// </summary>
		public static LifeRecordItem IdentityActionShixiang2 => Instance[(short)1198];

		/// <summary>
		/// IdentityActionShixiang3
		/// </summary>
		public static LifeRecordItem IdentityActionShixiang3 => Instance[(short)1199];

		/// <summary>
		/// IdentityActionShixiang4
		/// </summary>
		public static LifeRecordItem IdentityActionShixiang4 => Instance[(short)1200];

		/// <summary>
		/// IdentityActionShixiang5
		/// </summary>
		public static LifeRecordItem IdentityActionShixiang5 => Instance[(short)1201];

		/// <summary>
		/// IdentityActionShixiang5Target
		/// </summary>
		public static LifeRecordItem IdentityActionShixiang5Target => Instance[(short)1221];

		/// <summary>
		/// IdentityActionShixiang6
		/// </summary>
		public static LifeRecordItem IdentityActionShixiang6 => Instance[(short)1202];

		/// <summary>
		/// IdentityActionShixiang6Target
		/// </summary>
		public static LifeRecordItem IdentityActionShixiang6Target => Instance[(short)1222];

		/// <summary>
		/// IdentityActionShixiang7
		/// </summary>
		public static LifeRecordItem IdentityActionShixiang7 => Instance[(short)1203];

		/// <summary>
		/// IdentityActionShixiang7Target
		/// </summary>
		public static LifeRecordItem IdentityActionShixiang7Target => Instance[(short)1223];

		/// <summary>
		/// IdentityActionShixiang8
		/// </summary>
		public static LifeRecordItem IdentityActionShixiang8 => Instance[(short)1204];

		/// <summary>
		/// IdentityActionShixiang8Target
		/// </summary>
		public static LifeRecordItem IdentityActionShixiang8Target => Instance[(short)1224];

		/// <summary>
		/// IdentityActionRanShan1
		/// </summary>
		public static LifeRecordItem IdentityActionRanShan1 => Instance[(short)1225];

		/// <summary>
		/// IdentityActionRanShan1Target
		/// </summary>
		public static LifeRecordItem IdentityActionRanShan1Target => Instance[(short)1226];

		/// <summary>
		/// IdentityActionRanShan2
		/// </summary>
		public static LifeRecordItem IdentityActionRanShan2 => Instance[(short)1227];

		/// <summary>
		/// IdentityActionRanShan2Target
		/// </summary>
		public static LifeRecordItem IdentityActionRanShan2Target => Instance[(short)1228];

		/// <summary>
		/// IdentityActionRanShan3
		/// </summary>
		public static LifeRecordItem IdentityActionRanShan3 => Instance[(short)1229];

		/// <summary>
		/// IdentityActionRanShan4
		/// </summary>
		public static LifeRecordItem IdentityActionRanShan4 => Instance[(short)1230];

		/// <summary>
		/// IdentityActionRanShan5
		/// </summary>
		public static LifeRecordItem IdentityActionRanShan5 => Instance[(short)1231];

		/// <summary>
		/// IdentityActionRanShan6
		/// </summary>
		public static LifeRecordItem IdentityActionRanShan6 => Instance[(short)1232];

		/// <summary>
		/// IdentityActionRanShan7
		/// </summary>
		public static LifeRecordItem IdentityActionRanShan7 => Instance[(short)1233];

		/// <summary>
		/// IdentityActionRanShan7Target
		/// </summary>
		public static LifeRecordItem IdentityActionRanShan7Target => Instance[(short)1234];

		/// <summary>
		/// IdentityActionRanShan8
		/// </summary>
		public static LifeRecordItem IdentityActionRanShan8 => Instance[(short)1235];

		/// <summary>
		/// IdentityActionRanShan8Target
		/// </summary>
		public static LifeRecordItem IdentityActionRanShan8Target => Instance[(short)1236];

		/// <summary>
		/// IdentityActionXuanNv1
		/// </summary>
		public static LifeRecordItem IdentityActionXuanNv1 => Instance[(short)1237];

		/// <summary>
		/// IdentityActionXuanNv1Target
		/// </summary>
		public static LifeRecordItem IdentityActionXuanNv1Target => Instance[(short)1238];

		/// <summary>
		/// IdentityActionXuanNv2
		/// </summary>
		public static LifeRecordItem IdentityActionXuanNv2 => Instance[(short)1239];

		/// <summary>
		/// IdentityActionXuanNv2Target
		/// </summary>
		public static LifeRecordItem IdentityActionXuanNv2Target => Instance[(short)1388];

		/// <summary>
		/// IdentityActionXuanNv3
		/// </summary>
		public static LifeRecordItem IdentityActionXuanNv3 => Instance[(short)1240];

		/// <summary>
		/// IdentityActionXuanNv3Audience
		/// </summary>
		public static LifeRecordItem IdentityActionXuanNv3Audience => Instance[(short)1389];

		/// <summary>
		/// IdentityActionXuanNv4
		/// </summary>
		public static LifeRecordItem IdentityActionXuanNv4 => Instance[(short)1241];

		/// <summary>
		/// IdentityActionXuanNv4Target
		/// </summary>
		public static LifeRecordItem IdentityActionXuanNv4Target => Instance[(short)1242];

		/// <summary>
		/// IdentityActionXuanNv5
		/// </summary>
		public static LifeRecordItem IdentityActionXuanNv5 => Instance[(short)1243];

		/// <summary>
		/// IdentityActionXuanNv5Target
		/// </summary>
		public static LifeRecordItem IdentityActionXuanNv5Target => Instance[(short)1244];

		/// <summary>
		/// IdentityActionXuanNv6
		/// </summary>
		public static LifeRecordItem IdentityActionXuanNv6 => Instance[(short)1245];

		/// <summary>
		/// IdentityActionXuanNv7
		/// </summary>
		public static LifeRecordItem IdentityActionXuanNv7 => Instance[(short)1246];

		/// <summary>
		/// IdentityActionZhuJian1
		/// </summary>
		public static LifeRecordItem IdentityActionZhuJian1 => Instance[(short)1247];

		/// <summary>
		/// IdentityActionZhuJian1Target
		/// </summary>
		public static LifeRecordItem IdentityActionZhuJian1Target => Instance[(short)1248];

		/// <summary>
		/// IdentityActionZhuJian2
		/// </summary>
		public static LifeRecordItem IdentityActionZhuJian2 => Instance[(short)1249];

		/// <summary>
		/// IdentityActionZhuJian3
		/// </summary>
		public static LifeRecordItem IdentityActionZhuJian3 => Instance[(short)1250];

		/// <summary>
		/// IdentityActionZhuJian4
		/// </summary>
		public static LifeRecordItem IdentityActionZhuJian4 => Instance[(short)1251];

		/// <summary>
		/// IdentityActionZhuJian5
		/// </summary>
		public static LifeRecordItem IdentityActionZhuJian5 => Instance[(short)1252];

		/// <summary>
		/// IdentityActionZhuJian8
		/// </summary>
		public static LifeRecordItem IdentityActionZhuJian8 => Instance[(short)1377];

		/// <summary>
		/// IdentityActionKongSang1
		/// </summary>
		public static LifeRecordItem IdentityActionKongSang1 => Instance[(short)1256];

		/// <summary>
		/// IdentityActionKongSang1Target
		/// </summary>
		public static LifeRecordItem IdentityActionKongSang1Target => Instance[(short)1257];

		/// <summary>
		/// IdentityActionKongSang2
		/// </summary>
		public static LifeRecordItem IdentityActionKongSang2 => Instance[(short)1258];

		/// <summary>
		/// IdentityActionKongSang3
		/// </summary>
		public static LifeRecordItem IdentityActionKongSang3 => Instance[(short)1259];

		/// <summary>
		/// IdentityActionKongSang4A
		/// </summary>
		public static LifeRecordItem IdentityActionKongSang4A => Instance[(short)1260];

		/// <summary>
		/// IdentityActionKongSang4B
		/// </summary>
		public static LifeRecordItem IdentityActionKongSang4B => Instance[(short)1261];

		/// <summary>
		/// IdentityActionKongSang5A
		/// </summary>
		public static LifeRecordItem IdentityActionKongSang5A => Instance[(short)1262];

		/// <summary>
		/// IdentityActionKongSang5B
		/// </summary>
		public static LifeRecordItem IdentityActionKongSang5B => Instance[(short)1263];

		/// <summary>
		/// IdentityActionKongSang6
		/// </summary>
		public static LifeRecordItem IdentityActionKongSang6 => Instance[(short)1264];

		/// <summary>
		/// IdentityActionKongSang6Target
		/// </summary>
		public static LifeRecordItem IdentityActionKongSang6Target => Instance[(short)1265];

		/// <summary>
		/// IdentityActionKongSang7
		/// </summary>
		public static LifeRecordItem IdentityActionKongSang7 => Instance[(short)1266];

		/// <summary>
		/// IdentityActionKongSang7Target
		/// </summary>
		public static LifeRecordItem IdentityActionKongSang7Target => Instance[(short)1267];

		/// <summary>
		/// IdentityActionKongSang8A
		/// </summary>
		public static LifeRecordItem IdentityActionKongSang8A => Instance[(short)1268];

		/// <summary>
		/// IdentityActionKongSang8ATarget
		/// </summary>
		public static LifeRecordItem IdentityActionKongSang8ATarget => Instance[(short)1390];

		/// <summary>
		/// IdentityActionKongSang8B
		/// </summary>
		public static LifeRecordItem IdentityActionKongSang8B => Instance[(short)1269];

		/// <summary>
		/// IdentityActionKongSang9A
		/// </summary>
		public static LifeRecordItem IdentityActionKongSang9A => Instance[(short)1270];

		/// <summary>
		/// IdentityActionKongSang9ATarget
		/// </summary>
		public static LifeRecordItem IdentityActionKongSang9ATarget => Instance[(short)1391];

		/// <summary>
		/// IdentityActionKongSang9B
		/// </summary>
		public static LifeRecordItem IdentityActionKongSang9B => Instance[(short)1271];

		/// <summary>
		/// IdentityActionKongSang10
		/// </summary>
		public static LifeRecordItem IdentityActionKongSang10 => Instance[(short)1272];

		/// <summary>
		/// IdentityActionKongSang10Target
		/// </summary>
		public static LifeRecordItem IdentityActionKongSang10Target => Instance[(short)1273];

		/// <summary>
		/// IdentityActionJingGangZong2Steal
		/// </summary>
		public static LifeRecordItem IdentityActionJingGangZong2Steal => Instance[(short)1277];

		/// <summary>
		/// IdentityActionJingGangZong2Rob
		/// </summary>
		public static LifeRecordItem IdentityActionJingGangZong2Rob => Instance[(short)1278];

		/// <summary>
		/// IdentityActionJingGangZong2Scam
		/// </summary>
		public static LifeRecordItem IdentityActionJingGangZong2Scam => Instance[(short)1279];

		/// <summary>
		/// IdentityActionJingGangZong3
		/// </summary>
		public static LifeRecordItem IdentityActionJingGangZong3 => Instance[(short)1280];

		/// <summary>
		/// IdentityActionJingGangZong4
		/// </summary>
		public static LifeRecordItem IdentityActionJingGangZong4 => Instance[(short)1281];

		/// <summary>
		/// IdentityActionJingGangZong4Target
		/// </summary>
		public static LifeRecordItem IdentityActionJingGangZong4Target => Instance[(short)1282];

		/// <summary>
		/// IdentityActionJingGangZong5
		/// </summary>
		public static LifeRecordItem IdentityActionJingGangZong5 => Instance[(short)1283];

		/// <summary>
		/// IdentityActionJingGangZong5Target
		/// </summary>
		public static LifeRecordItem IdentityActionJingGangZong5Target => Instance[(short)1284];

		/// <summary>
		/// IdentityActionJingGangZong6
		/// </summary>
		public static LifeRecordItem IdentityActionJingGangZong6 => Instance[(short)1285];

		/// <summary>
		/// IdentityActionJingGangZong6Target
		/// </summary>
		public static LifeRecordItem IdentityActionJingGangZong6Target => Instance[(short)1286];

		/// <summary>
		/// IdentityActionJingGangZong7
		/// </summary>
		public static LifeRecordItem IdentityActionJingGangZong7 => Instance[(short)1287];

		/// <summary>
		/// IdentityActionWuXian1
		/// </summary>
		public static LifeRecordItem IdentityActionWuXian1 => Instance[(short)1288];

		/// <summary>
		/// IdentityActionWuXian2
		/// </summary>
		public static LifeRecordItem IdentityActionWuXian2 => Instance[(short)1289];

		/// <summary>
		/// IdentityActionWuXian2Target
		/// </summary>
		public static LifeRecordItem IdentityActionWuXian2Target => Instance[(short)1290];

		/// <summary>
		/// IdentityActionWuXian3
		/// </summary>
		public static LifeRecordItem IdentityActionWuXian3 => Instance[(short)1291];

		/// <summary>
		/// IdentityActionWuXian3Target
		/// </summary>
		public static LifeRecordItem IdentityActionWuXian3Target => Instance[(short)1292];

		/// <summary>
		/// IdentityActionWuXian4
		/// </summary>
		public static LifeRecordItem IdentityActionWuXian4 => Instance[(short)1293];

		/// <summary>
		/// IdentityActionWuXian4Target
		/// </summary>
		public static LifeRecordItem IdentityActionWuXian4Target => Instance[(short)1378];

		/// <summary>
		/// IdentityActionWuXian5
		/// </summary>
		public static LifeRecordItem IdentityActionWuXian5 => Instance[(short)1294];

		/// <summary>
		/// IdentityActionWuXian6
		/// </summary>
		public static LifeRecordItem IdentityActionWuXian6 => Instance[(short)1295];

		/// <summary>
		/// IdentityActionJieQing1A
		/// </summary>
		public static LifeRecordItem IdentityActionJieQing1A => Instance[(short)1296];

		/// <summary>
		/// IdentityActionJieQing1B
		/// </summary>
		public static LifeRecordItem IdentityActionJieQing1B => Instance[(short)1297];

		/// <summary>
		/// IdentityActionJieQing2
		/// </summary>
		public static LifeRecordItem IdentityActionJieQing2 => Instance[(short)1298];

		/// <summary>
		/// IdentityActionJieQing2Target
		/// </summary>
		public static LifeRecordItem IdentityActionJieQing2Target => Instance[(short)1392];

		/// <summary>
		/// IdentityActionJieQing3
		/// </summary>
		public static LifeRecordItem IdentityActionJieQing3 => Instance[(short)1299];

		/// <summary>
		/// IdentityActionJieQing4
		/// </summary>
		public static LifeRecordItem IdentityActionJieQing4 => Instance[(short)1300];

		/// <summary>
		/// IdentityActionJieQing5
		/// </summary>
		public static LifeRecordItem IdentityActionJieQing5 => Instance[(short)1301];

		/// <summary>
		/// IdentityActionJieQing6A
		/// </summary>
		public static LifeRecordItem IdentityActionJieQing6A => Instance[(short)1302];

		/// <summary>
		/// IdentityActionJieQing6B
		/// </summary>
		public static LifeRecordItem IdentityActionJieQing6B => Instance[(short)1303];

		/// <summary>
		/// IdentityActionJieQing7
		/// </summary>
		public static LifeRecordItem IdentityActionJieQing7 => Instance[(short)1304];

		/// <summary>
		/// IdentityActionJieQing7Target
		/// </summary>
		public static LifeRecordItem IdentityActionJieQing7Target => Instance[(short)1381];

		/// <summary>
		/// IdentityActionJieQing8
		/// </summary>
		public static LifeRecordItem IdentityActionJieQing8 => Instance[(short)1305];

		/// <summary>
		/// IdentityActionFuLong2
		/// </summary>
		public static LifeRecordItem IdentityActionFuLong2 => Instance[(short)1308];

		/// <summary>
		/// IdentityActionFuLong6
		/// </summary>
		public static LifeRecordItem IdentityActionFuLong6 => Instance[(short)1314];

		/// <summary>
		/// IdentityActionXveHou2StealA
		/// </summary>
		public static LifeRecordItem IdentityActionXveHou2StealA => Instance[(short)1317];

		/// <summary>
		/// IdentityActionXveHou2StealB
		/// </summary>
		public static LifeRecordItem IdentityActionXveHou2StealB => Instance[(short)1318];

		/// <summary>
		/// IdentityActionXveHou3RobA
		/// </summary>
		public static LifeRecordItem IdentityActionXveHou3RobA => Instance[(short)1319];

		/// <summary>
		/// IdentityActionXveHou3RobB
		/// </summary>
		public static LifeRecordItem IdentityActionXveHou3RobB => Instance[(short)1320];

		/// <summary>
		/// IdentityActionXveHou4ScamA
		/// </summary>
		public static LifeRecordItem IdentityActionXveHou4ScamA => Instance[(short)1321];

		/// <summary>
		/// IdentityActionXveHou4ScamB
		/// </summary>
		public static LifeRecordItem IdentityActionXveHou4ScamB => Instance[(short)1322];

		/// <summary>
		/// IdentityActionXveHou5
		/// </summary>
		public static LifeRecordItem IdentityActionXveHou5 => Instance[(short)1323];

		/// <summary>
		/// IdentityActionXveHou6
		/// </summary>
		public static LifeRecordItem IdentityActionXveHou6 => Instance[(short)1324];

		/// <summary>
		/// IdentityActionXveHou7
		/// </summary>
		public static LifeRecordItem IdentityActionXveHou7 => Instance[(short)1325];

		/// <summary>
		/// IdentityActionXveHou7Target
		/// </summary>
		public static LifeRecordItem IdentityActionXveHou7Target => Instance[(short)1326];

		/// <summary>
		/// IdentityActionChengZhen1
		/// </summary>
		public static LifeRecordItem IdentityActionChengZhen1 => Instance[(short)1330];

		/// <summary>
		/// IdentityActionChengZhen1TargetA
		/// </summary>
		public static LifeRecordItem IdentityActionChengZhen1TargetA => Instance[(short)1331];

		/// <summary>
		/// IdentityActionChengZhen1TargetB
		/// </summary>
		public static LifeRecordItem IdentityActionChengZhen1TargetB => Instance[(short)1332];

		/// <summary>
		/// IdentityActionChengZhen2
		/// </summary>
		public static LifeRecordItem IdentityActionChengZhen2 => Instance[(short)1333];

		/// <summary>
		/// IdentityActionChengZhen2TargetA
		/// </summary>
		public static LifeRecordItem IdentityActionChengZhen2TargetA => Instance[(short)1334];

		/// <summary>
		/// IdentityActionChengZhen2TargetB
		/// </summary>
		public static LifeRecordItem IdentityActionChengZhen2TargetB => Instance[(short)1335];

		/// <summary>
		/// IdentityActionChengZhen3
		/// </summary>
		public static LifeRecordItem IdentityActionChengZhen3 => Instance[(short)1336];

		/// <summary>
		/// IdentityActionChengZhen4
		/// </summary>
		public static LifeRecordItem IdentityActionChengZhen4 => Instance[(short)1337];

		/// <summary>
		/// IdentityActionChengZhen5
		/// </summary>
		public static LifeRecordItem IdentityActionChengZhen5 => Instance[(short)1338];

		/// <summary>
		/// IdentityActionChengZhen6
		/// </summary>
		public static LifeRecordItem IdentityActionChengZhen6 => Instance[(short)1339];

		/// <summary>
		/// IdentityActionChengZhen6Target
		/// </summary>
		public static LifeRecordItem IdentityActionChengZhen6Target => Instance[(short)1340];

		/// <summary>
		/// IdentityActionChengZhen7
		/// </summary>
		public static LifeRecordItem IdentityActionChengZhen7 => Instance[(short)1341];

		/// <summary>
		/// IdentityActionChengZhen7Target
		/// </summary>
		public static LifeRecordItem IdentityActionChengZhen7Target => Instance[(short)1342];

		/// <summary>
		/// IdentityActionChengZhen8
		/// </summary>
		public static LifeRecordItem IdentityActionChengZhen8 => Instance[(short)1343];

		/// <summary>
		/// IdentityActionChengZhen8Target
		/// </summary>
		public static LifeRecordItem IdentityActionChengZhen8Target => Instance[(short)1344];

		/// <summary>
		/// IdentityActionChengZhen9
		/// </summary>
		public static LifeRecordItem IdentityActionChengZhen9 => Instance[(short)1345];

		/// <summary>
		/// IdentityActionChengZhen9Target
		/// </summary>
		public static LifeRecordItem IdentityActionChengZhen9Target => Instance[(short)1346];

		/// <summary>
		/// IdentityActionChengZhen10
		/// </summary>
		public static LifeRecordItem IdentityActionChengZhen10 => Instance[(short)1347];

		/// <summary>
		/// IdentityActionChengZhen10TargetA
		/// </summary>
		public static LifeRecordItem IdentityActionChengZhen10TargetA => Instance[(short)1348];

		/// <summary>
		/// IdentityActionChengZhen10TargetB
		/// </summary>
		public static LifeRecordItem IdentityActionChengZhen10TargetB => Instance[(short)1349];

		/// <summary>
		/// IdentityActionChengZhen11
		/// </summary>
		public static LifeRecordItem IdentityActionChengZhen11 => Instance[(short)1350];

		/// <summary>
		/// IdentityActionChengZhen12
		/// </summary>
		public static LifeRecordItem IdentityActionChengZhen12 => Instance[(short)1351];

		/// <summary>
		/// IdentityActionChengZhen13
		/// </summary>
		public static LifeRecordItem IdentityActionChengZhen13 => Instance[(short)1352];

		/// <summary>
		/// IdentityActionChengZhen13Target
		/// </summary>
		public static LifeRecordItem IdentityActionChengZhen13Target => Instance[(short)1353];

		/// <summary>
		/// IdentityActionChengZhen14
		/// </summary>
		public static LifeRecordItem IdentityActionChengZhen14 => Instance[(short)1354];

		/// <summary>
		/// IdentityActionChengZhen15
		/// </summary>
		public static LifeRecordItem IdentityActionChengZhen15 => Instance[(short)1355];

		/// <summary>
		/// IdentityActionChengZhen16
		/// </summary>
		public static LifeRecordItem IdentityActionChengZhen16 => Instance[(short)1356];

		/// <summary>
		/// IdentityActionChengZhen16Target
		/// </summary>
		public static LifeRecordItem IdentityActionChengZhen16Target => Instance[(short)1357];

		/// <summary>
		/// IdentityActionChengZhen17
		/// </summary>
		public static LifeRecordItem IdentityActionChengZhen17 => Instance[(short)1358];

		/// <summary>
		/// IdentityActionChengZhen18
		/// </summary>
		public static LifeRecordItem IdentityActionChengZhen18 => Instance[(short)1359];

		/// <summary>
		/// IdentityActionChengZhen19
		/// </summary>
		public static LifeRecordItem IdentityActionChengZhen19 => Instance[(short)1360];

		/// <summary>
		/// IdentityActionChengZhen20
		/// </summary>
		public static LifeRecordItem IdentityActionChengZhen20 => Instance[(short)1361];

		/// <summary>
		/// IdentityActionChengZhen21
		/// </summary>
		public static LifeRecordItem IdentityActionChengZhen21 => Instance[(short)1362];

		/// <summary>
		/// IdentityActionChengZhen22
		/// </summary>
		public static LifeRecordItem IdentityActionChengZhen22 => Instance[(short)1363];

		/// <summary>
		/// BehaviorTypeAction1
		/// </summary>
		public static LifeRecordItem BehaviorTypeAction1 => Instance[(short)1364];

		/// <summary>
		/// BehaviorTypeAction1Target
		/// </summary>
		public static LifeRecordItem BehaviorTypeAction1Target => Instance[(short)1402];

		/// <summary>
		/// BehaviorTypeAction2
		/// </summary>
		public static LifeRecordItem BehaviorTypeAction2 => Instance[(short)1365];

		/// <summary>
		/// BehaviorTypeAction2Target
		/// </summary>
		public static LifeRecordItem BehaviorTypeAction2Target => Instance[(short)1403];

		/// <summary>
		/// BehaviorTypeAction3
		/// </summary>
		public static LifeRecordItem BehaviorTypeAction3 => Instance[(short)1366];

		/// <summary>
		/// BehaviorTypeAction4
		/// </summary>
		public static LifeRecordItem BehaviorTypeAction4 => Instance[(short)1367];

		/// <summary>
		/// BehaviorTypeAction5
		/// </summary>
		public static LifeRecordItem BehaviorTypeAction5 => Instance[(short)1368];

		/// <summary>
		/// BehaviorTypeAction6
		/// </summary>
		public static LifeRecordItem BehaviorTypeAction6 => Instance[(short)1369];

		/// <summary>
		/// CherryPickResource
		/// </summary>
		public static LifeRecordItem CherryPickResource => Instance[(short)1370];

		/// <summary>
		/// BuddistMeditate
		/// </summary>
		public static LifeRecordItem BuddistMeditate => Instance[(short)1371];

		/// <summary>
		/// TaoistMeditate
		/// </summary>
		public static LifeRecordItem TaoistMeditate => Instance[(short)1372];

		/// <summary>
		/// IdentityActionCaptureCricket1
		/// </summary>
		public static LifeRecordItem IdentityActionCaptureCricket1 => Instance[(short)1373];

		/// <summary>
		/// DLCLoongRidingEffectBaxia02
		/// </summary>
		public static LifeRecordItem DLCLoongRidingEffectBaxia02 => Instance[(short)1374];

		/// <summary>
		/// WeiQiBadOther
		/// </summary>
		public static LifeRecordItem WeiQiBadOther => Instance[(short)1386];

		/// <summary>
		/// WeiQiGoodOther
		/// </summary>
		public static LifeRecordItem WeiQiGoodOther => Instance[(short)1387];

		/// <summary>
		/// TwelveImmortalsEffectAdored
		/// </summary>
		public static LifeRecordItem TwelveImmortalsEffectAdored => Instance[(short)1393];

		/// <summary>
		/// TwelveImmortalsEffectEnemy
		/// </summary>
		public static LifeRecordItem TwelveImmortalsEffectEnemy => Instance[(short)1394];

		/// <summary>
		/// TwelveImmortalsEffectSuxia
		/// </summary>
		public static LifeRecordItem TwelveImmortalsEffectSuxia => Instance[(short)1395];

		/// <summary>
		/// TwelveImmortalsEffectBecomeMoTian
		/// </summary>
		public static LifeRecordItem TwelveImmortalsEffectBecomeMoTian => Instance[(short)1396];

		/// <summary>
		/// TwelveImmortalsEffectBeAttackByMoTian
		/// </summary>
		public static LifeRecordItem TwelveImmortalsEffectBeAttackByMoTian => Instance[(short)1397];

		/// <summary>
		/// TwelveImmortalsEffectBeAttackByJiao
		/// </summary>
		public static LifeRecordItem TwelveImmortalsEffectBeAttackByJiao => Instance[(short)1398];

		/// <summary>
		/// TwelveImmortalsEffectBeAttackByMirror
		/// </summary>
		public static LifeRecordItem TwelveImmortalsEffectBeAttackByMirror => Instance[(short)1399];

		/// <summary>
		/// TwelveImmortalsEffectBeAttackBySkeletonDemon
		/// </summary>
		public static LifeRecordItem TwelveImmortalsEffectBeAttackBySkeletonDemon => Instance[(short)1400];

		/// <summary>
		/// DemonHeirRevenge
		/// </summary>
		public static LifeRecordItem DemonHeirRevenge => Instance[(short)1404];

		/// <summary>
		/// DefeatDemonHeir
		/// </summary>
		public static LifeRecordItem DefeatDemonHeir => Instance[(short)1405];

		/// <summary>
		/// BeDefetedByDemonHeir
		/// </summary>
		public static LifeRecordItem BeDefetedByDemonHeir => Instance[(short)1406];

		/// <summary>
		/// DemonHeirDefeatTaiwu
		/// </summary>
		public static LifeRecordItem DemonHeirDefeatTaiwu => Instance[(short)1407];

		/// <summary>
		/// DemonHeirRebirth1
		/// </summary>
		public static LifeRecordItem DemonHeirRebirth1 => Instance[(short)1408];

		/// <summary>
		/// DemonHeirRebirth2
		/// </summary>
		public static LifeRecordItem DemonHeirRebirth2 => Instance[(short)1409];

		/// <summary>
		/// DLCCricketTurnToCricketForm
		/// </summary>
		public static LifeRecordItem DLCCricketTurnToCricketForm => Instance[(short)1410];

		/// <summary>
		/// DLCCricketRetranmogrifyToHuman
		/// </summary>
		public static LifeRecordItem DLCCricketRetranmogrifyToHuman => Instance[(short)1411];

		/// <summary>
		/// DecideToParticipateNewAdventure
		/// </summary>
		public static LifeRecordItem DecideToParticipateNewAdventure => Instance[(short)1412];

		/// <summary>
		/// LeaveNewAdventure
		/// </summary>
		public static LifeRecordItem LeaveNewAdventure => Instance[(short)1413];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static LifeRecord Instance = new LifeRecord();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "Desc", "RelatedIds", "TemplateId" };

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
		_dataArray.Add(new LifeRecordItem(0, LocalStringManager.GetConfig("LifeRecord_language", "Name_0"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_0"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(1, LocalStringManager.GetConfig("LifeRecord_language", "Name_1"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 0, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(2, LocalStringManager.GetConfig("LifeRecord_language", "Name_2"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_2"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 0, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(3, LocalStringManager.GetConfig("LifeRecord_language", "Name_3"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_3"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 0, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(4, LocalStringManager.GetConfig("LifeRecord_language", "Name_4"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_4"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 0, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(5, LocalStringManager.GetConfig("LifeRecord_language", "Name_5"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_5"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short> { 6 }, -30000, ELifeRecordScoreType.Absolute, 0, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(6, LocalStringManager.GetConfig("LifeRecord_language", "Name_6"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_6"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 5 }, -30000, ELifeRecordScoreType.Absolute, 0, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(7, LocalStringManager.GetConfig("LifeRecord_language", "Name_7"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_7"), new string[6] { "Location", "Cricket", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 90, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(8, LocalStringManager.GetConfig("LifeRecord_language", "Name_8"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_8"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 90, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(9, LocalStringManager.GetConfig("LifeRecord_language", "Name_9"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_9"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 90, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(10, LocalStringManager.GetConfig("LifeRecord_language", "Name_10"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_10"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 90, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(11, LocalStringManager.GetConfig("LifeRecord_language", "Name_11"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_11"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 90, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(12, LocalStringManager.GetConfig("LifeRecord_language", "Name_12"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_12"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(13, LocalStringManager.GetConfig("LifeRecord_language", "Name_13"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_13"), new string[6] { "Location", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(14, LocalStringManager.GetConfig("LifeRecord_language", "Name_14"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_14"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 15 }, -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(15, LocalStringManager.GetConfig("LifeRecord_language", "Name_15"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_15"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 14 }, -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(16, LocalStringManager.GetConfig("LifeRecord_language", "Name_16"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_16"), new string[6] { "Location", "Item", "Integer", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(17, LocalStringManager.GetConfig("LifeRecord_language", "Name_17"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_17"), new string[6] { "Location", "Item", "Integer", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(18, LocalStringManager.GetConfig("LifeRecord_language", "Name_18"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_18"), new string[6] { "Location", "CombatSkill", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(19, LocalStringManager.GetConfig("LifeRecord_language", "Name_19"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_19"), new string[6] { "Location", "CombatSkill", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(20, LocalStringManager.GetConfig("LifeRecord_language", "Name_20"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_20"), new string[6] { "Location", "CombatSkill", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(21, LocalStringManager.GetConfig("LifeRecord_language", "Name_21"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_21"), new string[6] { "Location", "LifeSkill", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(22, LocalStringManager.GetConfig("LifeRecord_language", "Name_22"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_22"), new string[6] { "Location", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(23, LocalStringManager.GetConfig("LifeRecord_language", "Name_23"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_23"), new string[6] { "Location", "Item", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(24, LocalStringManager.GetConfig("LifeRecord_language", "Name_24"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_24"), new string[6] { "Location", "Resource", "Integer", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(25, LocalStringManager.GetConfig("LifeRecord_language", "Name_25"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_25"), new string[6] { "Location", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(26, LocalStringManager.GetConfig("LifeRecord_language", "Name_26"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_26"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 28 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(27, LocalStringManager.GetConfig("LifeRecord_language", "Name_27"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_27"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 29 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(28, LocalStringManager.GetConfig("LifeRecord_language", "Name_28"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_28"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 26 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(29, LocalStringManager.GetConfig("LifeRecord_language", "Name_29"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_29"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 27 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(30, LocalStringManager.GetConfig("LifeRecord_language", "Name_30"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_30"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(31, LocalStringManager.GetConfig("LifeRecord_language", "Name_31"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_31"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 31 }, -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(32, LocalStringManager.GetConfig("LifeRecord_language", "Name_32"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_32"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 34 }, -30000, ELifeRecordScoreType.Normal, 80, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(33, LocalStringManager.GetConfig("LifeRecord_language", "Name_33"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_33"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 35 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(34, LocalStringManager.GetConfig("LifeRecord_language", "Name_34"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_34"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 32 }, -30000, ELifeRecordScoreType.Normal, 80, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(35, LocalStringManager.GetConfig("LifeRecord_language", "Name_35"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_35"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 33 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(36, LocalStringManager.GetConfig("LifeRecord_language", "Name_36"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_36"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 36 }, -30000, ELifeRecordScoreType.Normal, 30, 15, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(37, LocalStringManager.GetConfig("LifeRecord_language", "Name_37"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_37"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 38 }, -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(38, LocalStringManager.GetConfig("LifeRecord_language", "Name_38"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_38"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 37 }, -30000, ELifeRecordScoreType.Normal, 30, 17, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(39, LocalStringManager.GetConfig("LifeRecord_language", "Name_39"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_39"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 39 }, -30000, ELifeRecordScoreType.Normal, 90, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(40, LocalStringManager.GetConfig("LifeRecord_language", "Name_40"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_40"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 41 }, -30000, ELifeRecordScoreType.Normal, 10, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(41, LocalStringManager.GetConfig("LifeRecord_language", "Name_41"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_41"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 40 }, -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(42, LocalStringManager.GetConfig("LifeRecord_language", "Name_42"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_42"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 42 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(43, LocalStringManager.GetConfig("LifeRecord_language", "Name_43"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_43"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 43 }, -30000, ELifeRecordScoreType.Normal, 40, 18, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(44, LocalStringManager.GetConfig("LifeRecord_language", "Name_44"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_44"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 44 }, -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(45, LocalStringManager.GetConfig("LifeRecord_language", "Name_45"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_45"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 45 }, -30000, ELifeRecordScoreType.Normal, 30, 14, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(46, LocalStringManager.GetConfig("LifeRecord_language", "Name_46"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_46"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 48, 49 }, -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(47, LocalStringManager.GetConfig("LifeRecord_language", "Name_47"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_47"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 48, 49 }, -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(48, LocalStringManager.GetConfig("LifeRecord_language", "Name_48"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_48"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 46, 47 }, -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(49, LocalStringManager.GetConfig("LifeRecord_language", "Name_49"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_49"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 46, 47 }, -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(50, LocalStringManager.GetConfig("LifeRecord_language", "Name_50"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_50"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(51, LocalStringManager.GetConfig("LifeRecord_language", "Name_51"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_51"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(52, LocalStringManager.GetConfig("LifeRecord_language", "Name_52"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_52"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(53, LocalStringManager.GetConfig("LifeRecord_language", "Name_53"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_53"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 55 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(54, LocalStringManager.GetConfig("LifeRecord_language", "Name_54"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_54"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 56 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(55, LocalStringManager.GetConfig("LifeRecord_language", "Name_55"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_55"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 53 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(56, LocalStringManager.GetConfig("LifeRecord_language", "Name_56"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_56"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 54 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(57, LocalStringManager.GetConfig("LifeRecord_language", "Name_57"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_57"), new string[6] { "Location", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(58, LocalStringManager.GetConfig("LifeRecord_language", "Name_58"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_58"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(59, LocalStringManager.GetConfig("LifeRecord_language", "Name_59"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_59"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new LifeRecordItem(60, LocalStringManager.GetConfig("LifeRecord_language", "Name_60"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_60"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(61, LocalStringManager.GetConfig("LifeRecord_language", "Name_61"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_61"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(62, LocalStringManager.GetConfig("LifeRecord_language", "Name_62"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_62"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(63, LocalStringManager.GetConfig("LifeRecord_language", "Name_63"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_63"), new string[6] { "Location", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(64, LocalStringManager.GetConfig("LifeRecord_language", "Name_64"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_64"), new string[6] { "Location", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(65, LocalStringManager.GetConfig("LifeRecord_language", "Name_65"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_65"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(66, LocalStringManager.GetConfig("LifeRecord_language", "Name_66"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_66"), new string[6] { "Location", "Adventure", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(67, LocalStringManager.GetConfig("LifeRecord_language", "Name_67"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_67"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(68, LocalStringManager.GetConfig("LifeRecord_language", "Name_68"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_68"), new string[6] { "Location", "Settlement", "OrgGrade", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(69, LocalStringManager.GetConfig("LifeRecord_language", "Name_69"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_69"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(70, LocalStringManager.GetConfig("LifeRecord_language", "Name_70"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_70"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(71, LocalStringManager.GetConfig("LifeRecord_language", "Name_71"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_71"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(72, LocalStringManager.GetConfig("LifeRecord_language", "Name_72"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_72"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(73, LocalStringManager.GetConfig("LifeRecord_language", "Name_73"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_73"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(74, LocalStringManager.GetConfig("LifeRecord_language", "Name_74"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_74"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(75, LocalStringManager.GetConfig("LifeRecord_language", "Name_75"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_75"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(76, LocalStringManager.GetConfig("LifeRecord_language", "Name_76"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_76"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(77, LocalStringManager.GetConfig("LifeRecord_language", "Name_77"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_77"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(78, LocalStringManager.GetConfig("LifeRecord_language", "Name_78"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_78"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(79, LocalStringManager.GetConfig("LifeRecord_language", "Name_79"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_79"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(80, LocalStringManager.GetConfig("LifeRecord_language", "Name_80"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_80"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(81, LocalStringManager.GetConfig("LifeRecord_language", "Name_81"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_81"), new string[6] { "Location", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(82, LocalStringManager.GetConfig("LifeRecord_language", "Name_82"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_82"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(83, LocalStringManager.GetConfig("LifeRecord_language", "Name_83"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_83"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(84, LocalStringManager.GetConfig("LifeRecord_language", "Name_84"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_84"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(85, LocalStringManager.GetConfig("LifeRecord_language", "Name_85"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_85"), new string[6] { "Character", "Location", "CombatType", "", "", "" }, isSourceRecord: true, new List<short> { 86 }, -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(86, LocalStringManager.GetConfig("LifeRecord_language", "Name_86"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_86"), new string[6] { "Character", "Location", "CombatType", "", "", "" }, isSourceRecord: true, new List<short> { 85 }, -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(87, LocalStringManager.GetConfig("LifeRecord_language", "Name_87"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_87"), new string[6] { "Character", "Location", "CombatType", "", "", "" }, isSourceRecord: true, new List<short> { 88 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(88, LocalStringManager.GetConfig("LifeRecord_language", "Name_88"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_88"), new string[6] { "Character", "Location", "CombatType", "", "", "" }, isSourceRecord: true, new List<short> { 87 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(89, LocalStringManager.GetConfig("LifeRecord_language", "Name_89"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_89"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 90 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(90, LocalStringManager.GetConfig("LifeRecord_language", "Name_90"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_90"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 89 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(91, LocalStringManager.GetConfig("LifeRecord_language", "Name_91"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_91"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 712 }, -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(92, LocalStringManager.GetConfig("LifeRecord_language", "Name_92"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_92"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 713 }, -30000, ELifeRecordScoreType.Normal, 20, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(93, LocalStringManager.GetConfig("LifeRecord_language", "Name_93"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_93"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 96 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(94, LocalStringManager.GetConfig("LifeRecord_language", "Name_94"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_94"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 97 }, -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(95, LocalStringManager.GetConfig("LifeRecord_language", "Name_95"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_95"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 98 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(96, LocalStringManager.GetConfig("LifeRecord_language", "Name_96"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_96"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 93 }, -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(97, LocalStringManager.GetConfig("LifeRecord_language", "Name_97"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_97"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 94 }, -30000, ELifeRecordScoreType.Normal, 20, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(98, LocalStringManager.GetConfig("LifeRecord_language", "Name_98"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_98"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 95 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(99, LocalStringManager.GetConfig("LifeRecord_language", "Name_99"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_99"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(100, LocalStringManager.GetConfig("LifeRecord_language", "Name_100"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_100"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(101, LocalStringManager.GetConfig("LifeRecord_language", "Name_101"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_101"), new string[6] { "Location", "Adventure", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(102, LocalStringManager.GetConfig("LifeRecord_language", "Name_102"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_102"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 138 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(103, LocalStringManager.GetConfig("LifeRecord_language", "Name_103"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_103"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 139 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(104, LocalStringManager.GetConfig("LifeRecord_language", "Name_104"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_104"), new string[6] { "Character", "Location", "Item", "PoisonType", "", "" }, isSourceRecord: true, new List<short> { 140 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(105, LocalStringManager.GetConfig("LifeRecord_language", "Name_105"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_105"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 141 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(106, LocalStringManager.GetConfig("LifeRecord_language", "Name_106"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_106"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 142 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(107, LocalStringManager.GetConfig("LifeRecord_language", "Name_107"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_107"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 143 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(108, LocalStringManager.GetConfig("LifeRecord_language", "Name_108"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_108"), new string[6] { "Character", "Location", "Item", "Item", "", "" }, isSourceRecord: true, new List<short> { 144 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(109, LocalStringManager.GetConfig("LifeRecord_language", "Name_109"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_109"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 145 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(110, LocalStringManager.GetConfig("LifeRecord_language", "Name_110"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_110"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 146 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(111, LocalStringManager.GetConfig("LifeRecord_language", "Name_111"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_111"), new string[6] { "Character", "Location", "Resource", "Integer", "", "" }, isSourceRecord: true, new List<short> { 147 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(112, LocalStringManager.GetConfig("LifeRecord_language", "Name_112"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_112"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 148 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(113, LocalStringManager.GetConfig("LifeRecord_language", "Name_113"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_113"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 149 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(114, LocalStringManager.GetConfig("LifeRecord_language", "Name_114"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_114"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 150 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(115, LocalStringManager.GetConfig("LifeRecord_language", "Name_115"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_115"), new string[6] { "Character", "Location", "Item", "Integer", "", "" }, isSourceRecord: true, new List<short> { 151 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(116, LocalStringManager.GetConfig("LifeRecord_language", "Name_116"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_116"), new string[6] { "Character", "Location", "Item", "Integer", "", "" }, isSourceRecord: true, new List<short> { 152 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(117, LocalStringManager.GetConfig("LifeRecord_language", "Name_117"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_117"), new string[6] { "Character", "Location", "Item", "Integer", "", "" }, isSourceRecord: true, new List<short> { 153 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(118, LocalStringManager.GetConfig("LifeRecord_language", "Name_118"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_118"), new string[6] { "Character", "Location", "Item", "Integer", "", "" }, isSourceRecord: true, new List<short> { 154 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(119, LocalStringManager.GetConfig("LifeRecord_language", "Name_119"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_119"), new string[6] { "Character", "Location", "Item", "Integer", "", "" }, isSourceRecord: true, new List<short> { 155 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Study));
	}

	private void CreateItems2()
	{
		_dataArray.Add(new LifeRecordItem(120, LocalStringManager.GetConfig("LifeRecord_language", "Name_120"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_120"), new string[6] { "Character", "Location", "CombatSkill", "", "", "" }, isSourceRecord: true, new List<short> { 156 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(121, LocalStringManager.GetConfig("LifeRecord_language", "Name_121"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_121"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 157 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(122, LocalStringManager.GetConfig("LifeRecord_language", "Name_122"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_122"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 158 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(123, LocalStringManager.GetConfig("LifeRecord_language", "Name_123"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_123"), new string[6] { "Character", "Location", "Item", "PoisonType", "", "" }, isSourceRecord: true, new List<short> { 159 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(124, LocalStringManager.GetConfig("LifeRecord_language", "Name_124"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_124"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 160 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(125, LocalStringManager.GetConfig("LifeRecord_language", "Name_125"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_125"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 161 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(126, LocalStringManager.GetConfig("LifeRecord_language", "Name_126"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_126"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 162 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(127, LocalStringManager.GetConfig("LifeRecord_language", "Name_127"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_127"), new string[6] { "Character", "Location", "Item", "Item", "", "" }, isSourceRecord: true, new List<short> { 163 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(128, LocalStringManager.GetConfig("LifeRecord_language", "Name_128"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_128"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 164 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(129, LocalStringManager.GetConfig("LifeRecord_language", "Name_129"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_129"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 165 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(130, LocalStringManager.GetConfig("LifeRecord_language", "Name_130"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_130"), new string[6] { "Character", "Location", "Resource", "Integer", "", "" }, isSourceRecord: true, new List<short> { 166 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(131, LocalStringManager.GetConfig("LifeRecord_language", "Name_131"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_131"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 167 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(132, LocalStringManager.GetConfig("LifeRecord_language", "Name_132"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_132"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 168 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(133, LocalStringManager.GetConfig("LifeRecord_language", "Name_133"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_133"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 169 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(134, LocalStringManager.GetConfig("LifeRecord_language", "Name_134"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_134"), new string[6] { "Character", "Location", "Item", "Integer", "", "" }, isSourceRecord: true, new List<short> { 170 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(135, LocalStringManager.GetConfig("LifeRecord_language", "Name_135"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_135"), new string[6] { "Character", "Location", "Item", "Integer", "", "" }, isSourceRecord: true, new List<short> { 171 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(136, LocalStringManager.GetConfig("LifeRecord_language", "Name_136"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_136"), new string[6] { "Character", "Location", "Item", "Integer", "", "" }, isSourceRecord: true, new List<short> { 172 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(137, LocalStringManager.GetConfig("LifeRecord_language", "Name_137"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_137"), new string[6] { "Character", "Location", "CombatSkill", "", "", "" }, isSourceRecord: true, new List<short> { 173 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(138, LocalStringManager.GetConfig("LifeRecord_language", "Name_138"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_138"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 102 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(139, LocalStringManager.GetConfig("LifeRecord_language", "Name_139"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_139"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 103 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(140, LocalStringManager.GetConfig("LifeRecord_language", "Name_140"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_140"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 104 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(141, LocalStringManager.GetConfig("LifeRecord_language", "Name_141"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_141"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 105 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(142, LocalStringManager.GetConfig("LifeRecord_language", "Name_142"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_142"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 106 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(143, LocalStringManager.GetConfig("LifeRecord_language", "Name_143"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_143"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 107 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(144, LocalStringManager.GetConfig("LifeRecord_language", "Name_144"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_144"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 108 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(145, LocalStringManager.GetConfig("LifeRecord_language", "Name_145"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_145"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 109 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(146, LocalStringManager.GetConfig("LifeRecord_language", "Name_146"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_146"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 110 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(147, LocalStringManager.GetConfig("LifeRecord_language", "Name_147"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_147"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 111 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(148, LocalStringManager.GetConfig("LifeRecord_language", "Name_148"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_148"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 112 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(149, LocalStringManager.GetConfig("LifeRecord_language", "Name_149"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_149"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 113 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(150, LocalStringManager.GetConfig("LifeRecord_language", "Name_150"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_150"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 114 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(151, LocalStringManager.GetConfig("LifeRecord_language", "Name_151"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_151"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 115 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(152, LocalStringManager.GetConfig("LifeRecord_language", "Name_152"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_152"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 116 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(153, LocalStringManager.GetConfig("LifeRecord_language", "Name_153"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_153"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 117 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(154, LocalStringManager.GetConfig("LifeRecord_language", "Name_154"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_154"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 118 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(155, LocalStringManager.GetConfig("LifeRecord_language", "Name_155"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_155"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 119 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(156, LocalStringManager.GetConfig("LifeRecord_language", "Name_156"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_156"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 120 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(157, LocalStringManager.GetConfig("LifeRecord_language", "Name_157"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_157"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 121 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(158, LocalStringManager.GetConfig("LifeRecord_language", "Name_158"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_158"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 122 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(159, LocalStringManager.GetConfig("LifeRecord_language", "Name_159"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_159"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 123 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(160, LocalStringManager.GetConfig("LifeRecord_language", "Name_160"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_160"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 124 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(161, LocalStringManager.GetConfig("LifeRecord_language", "Name_161"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_161"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 125 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(162, LocalStringManager.GetConfig("LifeRecord_language", "Name_162"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_162"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 126 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(163, LocalStringManager.GetConfig("LifeRecord_language", "Name_163"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_163"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 127 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(164, LocalStringManager.GetConfig("LifeRecord_language", "Name_164"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_164"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 128 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(165, LocalStringManager.GetConfig("LifeRecord_language", "Name_165"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_165"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 129 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(166, LocalStringManager.GetConfig("LifeRecord_language", "Name_166"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_166"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 130 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(167, LocalStringManager.GetConfig("LifeRecord_language", "Name_167"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_167"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 131 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(168, LocalStringManager.GetConfig("LifeRecord_language", "Name_168"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_168"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 132 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(169, LocalStringManager.GetConfig("LifeRecord_language", "Name_169"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_169"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 133 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(170, LocalStringManager.GetConfig("LifeRecord_language", "Name_170"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_170"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 134 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(171, LocalStringManager.GetConfig("LifeRecord_language", "Name_171"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_171"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 135 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(172, LocalStringManager.GetConfig("LifeRecord_language", "Name_172"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_172"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 136 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(173, LocalStringManager.GetConfig("LifeRecord_language", "Name_173"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_173"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 137 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(174, LocalStringManager.GetConfig("LifeRecord_language", "Name_174"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_174"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(175, LocalStringManager.GetConfig("LifeRecord_language", "Name_175"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_175"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(176, LocalStringManager.GetConfig("LifeRecord_language", "Name_176"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_176"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(177, LocalStringManager.GetConfig("LifeRecord_language", "Name_177"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_177"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(178, LocalStringManager.GetConfig("LifeRecord_language", "Name_178"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_178"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short> { 180 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(179, LocalStringManager.GetConfig("LifeRecord_language", "Name_179"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_179"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short> { 180 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
	}

	private void CreateItems3()
	{
		_dataArray.Add(new LifeRecordItem(180, LocalStringManager.GetConfig("LifeRecord_language", "Name_180"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_180"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 178, 179 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(181, LocalStringManager.GetConfig("LifeRecord_language", "Name_181"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_181"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(182, LocalStringManager.GetConfig("LifeRecord_language", "Name_182"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_182"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(183, LocalStringManager.GetConfig("LifeRecord_language", "Name_183"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_183"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(184, LocalStringManager.GetConfig("LifeRecord_language", "Name_184"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_184"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(185, LocalStringManager.GetConfig("LifeRecord_language", "Name_185"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_185"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short> { 187 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(186, LocalStringManager.GetConfig("LifeRecord_language", "Name_186"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_186"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short> { 187 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(187, LocalStringManager.GetConfig("LifeRecord_language", "Name_187"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_187"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 185, 186 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(188, LocalStringManager.GetConfig("LifeRecord_language", "Name_188"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_188"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(189, LocalStringManager.GetConfig("LifeRecord_language", "Name_189"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_189"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(190, LocalStringManager.GetConfig("LifeRecord_language", "Name_190"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_190"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(191, LocalStringManager.GetConfig("LifeRecord_language", "Name_191"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_191"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(192, LocalStringManager.GetConfig("LifeRecord_language", "Name_192"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_192"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short> { 194 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(193, LocalStringManager.GetConfig("LifeRecord_language", "Name_193"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_193"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short> { 194 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(194, LocalStringManager.GetConfig("LifeRecord_language", "Name_194"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_194"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 192, 193 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(195, LocalStringManager.GetConfig("LifeRecord_language", "Name_195"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_195"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(196, LocalStringManager.GetConfig("LifeRecord_language", "Name_196"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_196"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(197, LocalStringManager.GetConfig("LifeRecord_language", "Name_197"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_197"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(198, LocalStringManager.GetConfig("LifeRecord_language", "Name_198"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_198"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(199, LocalStringManager.GetConfig("LifeRecord_language", "Name_199"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_199"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 201 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(200, LocalStringManager.GetConfig("LifeRecord_language", "Name_200"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_200"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 201 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(201, LocalStringManager.GetConfig("LifeRecord_language", "Name_201"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_201"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 199, 200 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(202, LocalStringManager.GetConfig("LifeRecord_language", "Name_202"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_202"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(203, LocalStringManager.GetConfig("LifeRecord_language", "Name_203"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_203"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(204, LocalStringManager.GetConfig("LifeRecord_language", "Name_204"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_204"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(205, LocalStringManager.GetConfig("LifeRecord_language", "Name_205"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_205"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(206, LocalStringManager.GetConfig("LifeRecord_language", "Name_206"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_206"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 208 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(207, LocalStringManager.GetConfig("LifeRecord_language", "Name_207"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_207"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 208 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(208, LocalStringManager.GetConfig("LifeRecord_language", "Name_208"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_208"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 206, 207 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(209, LocalStringManager.GetConfig("LifeRecord_language", "Name_209"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_209"), new string[6] { "Character", "Location", "Resource", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(210, LocalStringManager.GetConfig("LifeRecord_language", "Name_210"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_210"), new string[6] { "Character", "Location", "Resource", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(211, LocalStringManager.GetConfig("LifeRecord_language", "Name_211"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_211"), new string[6] { "Character", "Location", "Resource", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(212, LocalStringManager.GetConfig("LifeRecord_language", "Name_212"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_212"), new string[6] { "Character", "Location", "Resource", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(213, LocalStringManager.GetConfig("LifeRecord_language", "Name_213"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_213"), new string[6] { "Character", "Location", "Resource", "Integer", "", "" }, isSourceRecord: true, new List<short> { 216 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(214, LocalStringManager.GetConfig("LifeRecord_language", "Name_214"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_214"), new string[6] { "Character", "Location", "Resource", "Integer", "", "" }, isSourceRecord: true, new List<short> { 216 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(215, LocalStringManager.GetConfig("LifeRecord_language", "Name_215"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_215"), new string[6] { "Character", "Location", "Resource", "Integer", "", "" }, isSourceRecord: true, new List<short> { 217 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(216, LocalStringManager.GetConfig("LifeRecord_language", "Name_216"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_216"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 213, 214 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(217, LocalStringManager.GetConfig("LifeRecord_language", "Name_217"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_217"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 215 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(218, LocalStringManager.GetConfig("LifeRecord_language", "Name_218"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_218"), new string[6] { "Character", "Location", "Resource", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(219, LocalStringManager.GetConfig("LifeRecord_language", "Name_219"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_219"), new string[6] { "Character", "Location", "Resource", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(220, LocalStringManager.GetConfig("LifeRecord_language", "Name_220"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_220"), new string[6] { "Character", "Location", "Resource", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(221, LocalStringManager.GetConfig("LifeRecord_language", "Name_221"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_221"), new string[6] { "Character", "Location", "Resource", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(222, LocalStringManager.GetConfig("LifeRecord_language", "Name_222"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_222"), new string[6] { "Character", "Location", "Resource", "Integer", "", "" }, isSourceRecord: true, new List<short> { 225 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(223, LocalStringManager.GetConfig("LifeRecord_language", "Name_223"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_223"), new string[6] { "Character", "Location", "Resource", "Integer", "", "" }, isSourceRecord: true, new List<short> { 225 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(224, LocalStringManager.GetConfig("LifeRecord_language", "Name_224"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_224"), new string[6] { "Character", "Location", "Resource", "Integer", "", "" }, isSourceRecord: true, new List<short> { 226 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(225, LocalStringManager.GetConfig("LifeRecord_language", "Name_225"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_225"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 222, 223 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(226, LocalStringManager.GetConfig("LifeRecord_language", "Name_226"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_226"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 224 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(227, LocalStringManager.GetConfig("LifeRecord_language", "Name_227"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_227"), new string[6] { "Character", "Location", "Resource", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(228, LocalStringManager.GetConfig("LifeRecord_language", "Name_228"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_228"), new string[6] { "Character", "Location", "Resource", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(229, LocalStringManager.GetConfig("LifeRecord_language", "Name_229"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_229"), new string[6] { "Character", "Location", "Resource", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(230, LocalStringManager.GetConfig("LifeRecord_language", "Name_230"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_230"), new string[6] { "Character", "Location", "Resource", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(231, LocalStringManager.GetConfig("LifeRecord_language", "Name_231"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_231"), new string[6] { "Character", "Location", "Resource", "Integer", "", "" }, isSourceRecord: true, new List<short> { 234 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(232, LocalStringManager.GetConfig("LifeRecord_language", "Name_232"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_232"), new string[6] { "Character", "Location", "Resource", "Integer", "", "" }, isSourceRecord: true, new List<short> { 234 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(233, LocalStringManager.GetConfig("LifeRecord_language", "Name_233"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_233"), new string[6] { "Character", "Location", "Resource", "Integer", "", "" }, isSourceRecord: true, new List<short> { 235 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(234, LocalStringManager.GetConfig("LifeRecord_language", "Name_234"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_234"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 231, 232 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(235, LocalStringManager.GetConfig("LifeRecord_language", "Name_235"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_235"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 233 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(236, LocalStringManager.GetConfig("LifeRecord_language", "Name_236"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_236"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(237, LocalStringManager.GetConfig("LifeRecord_language", "Name_237"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_237"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(238, LocalStringManager.GetConfig("LifeRecord_language", "Name_238"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_238"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(239, LocalStringManager.GetConfig("LifeRecord_language", "Name_239"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_239"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
	}

	private void CreateItems4()
	{
		_dataArray.Add(new LifeRecordItem(240, LocalStringManager.GetConfig("LifeRecord_language", "Name_240"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_240"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 243 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(241, LocalStringManager.GetConfig("LifeRecord_language", "Name_241"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_241"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 243 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(242, LocalStringManager.GetConfig("LifeRecord_language", "Name_242"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_242"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 244 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(243, LocalStringManager.GetConfig("LifeRecord_language", "Name_243"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_243"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 240, 241 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(244, LocalStringManager.GetConfig("LifeRecord_language", "Name_244"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_244"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 242 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(245, LocalStringManager.GetConfig("LifeRecord_language", "Name_245"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_245"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(246, LocalStringManager.GetConfig("LifeRecord_language", "Name_246"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_246"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(247, LocalStringManager.GetConfig("LifeRecord_language", "Name_247"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_247"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(248, LocalStringManager.GetConfig("LifeRecord_language", "Name_248"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_248"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(249, LocalStringManager.GetConfig("LifeRecord_language", "Name_249"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_249"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 252 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(250, LocalStringManager.GetConfig("LifeRecord_language", "Name_250"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_250"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 252 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(251, LocalStringManager.GetConfig("LifeRecord_language", "Name_251"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_251"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 253 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(252, LocalStringManager.GetConfig("LifeRecord_language", "Name_252"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_252"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 249, 250 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(253, LocalStringManager.GetConfig("LifeRecord_language", "Name_253"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_253"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 251 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(254, LocalStringManager.GetConfig("LifeRecord_language", "Name_254"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_254"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(255, LocalStringManager.GetConfig("LifeRecord_language", "Name_255"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_255"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(256, LocalStringManager.GetConfig("LifeRecord_language", "Name_256"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_256"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(257, LocalStringManager.GetConfig("LifeRecord_language", "Name_257"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_257"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(258, LocalStringManager.GetConfig("LifeRecord_language", "Name_258"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_258"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 261 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(259, LocalStringManager.GetConfig("LifeRecord_language", "Name_259"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_259"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 261 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(260, LocalStringManager.GetConfig("LifeRecord_language", "Name_260"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_260"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 262 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(261, LocalStringManager.GetConfig("LifeRecord_language", "Name_261"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_261"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 258, 259 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(262, LocalStringManager.GetConfig("LifeRecord_language", "Name_262"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_262"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 260 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(263, LocalStringManager.GetConfig("LifeRecord_language", "Name_263"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_263"), new string[6] { "Character", "Location", "Resource", "Integer", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(264, LocalStringManager.GetConfig("LifeRecord_language", "Name_264"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_264"), new string[6] { "Character", "Location", "Resource", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(265, LocalStringManager.GetConfig("LifeRecord_language", "Name_265"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_265"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(266, LocalStringManager.GetConfig("LifeRecord_language", "Name_266"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_266"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(267, LocalStringManager.GetConfig("LifeRecord_language", "Name_267"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_267"), new string[6] { "Character", "Location", "Item", "Integer", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(268, LocalStringManager.GetConfig("LifeRecord_language", "Name_268"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_268"), new string[6] { "Character", "Location", "Item", "Integer", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(269, LocalStringManager.GetConfig("LifeRecord_language", "Name_269"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_269"), new string[6] { "Character", "Location", "Item", "Integer", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(270, LocalStringManager.GetConfig("LifeRecord_language", "Name_270"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_270"), new string[6] { "Character", "Location", "Item", "Integer", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(271, LocalStringManager.GetConfig("LifeRecord_language", "Name_271"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_271"), new string[6] { "Character", "Location", "Item", "Integer", "", "" }, isSourceRecord: true, new List<short> { 273 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(272, LocalStringManager.GetConfig("LifeRecord_language", "Name_272"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_272"), new string[6] { "Character", "Location", "Item", "Integer", "", "" }, isSourceRecord: true, new List<short> { 273 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(273, LocalStringManager.GetConfig("LifeRecord_language", "Name_273"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_273"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 271, 272 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(274, LocalStringManager.GetConfig("LifeRecord_language", "Name_274"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_274"), new string[6] { "Character", "Location", "Item", "Integer", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(275, LocalStringManager.GetConfig("LifeRecord_language", "Name_275"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_275"), new string[6] { "Character", "Location", "Item", "Integer", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(276, LocalStringManager.GetConfig("LifeRecord_language", "Name_276"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_276"), new string[6] { "Character", "Location", "Item", "Integer", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(277, LocalStringManager.GetConfig("LifeRecord_language", "Name_277"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_277"), new string[6] { "Character", "Location", "Item", "Integer", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(278, LocalStringManager.GetConfig("LifeRecord_language", "Name_278"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_278"), new string[6] { "Character", "Location", "Item", "Integer", "", "" }, isSourceRecord: true, new List<short> { 280 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(279, LocalStringManager.GetConfig("LifeRecord_language", "Name_279"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_279"), new string[6] { "Character", "Location", "Item", "Integer", "", "" }, isSourceRecord: true, new List<short> { 280 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(280, LocalStringManager.GetConfig("LifeRecord_language", "Name_280"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_280"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 278, 279 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(281, LocalStringManager.GetConfig("LifeRecord_language", "Name_281"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_281"), new string[6] { "Character", "Location", "Item", "Integer", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(282, LocalStringManager.GetConfig("LifeRecord_language", "Name_282"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_282"), new string[6] { "Character", "Location", "Item", "Integer", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(283, LocalStringManager.GetConfig("LifeRecord_language", "Name_283"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_283"), new string[6] { "Character", "Location", "Item", "Integer", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(284, LocalStringManager.GetConfig("LifeRecord_language", "Name_284"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_284"), new string[6] { "Character", "Location", "Item", "Integer", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(285, LocalStringManager.GetConfig("LifeRecord_language", "Name_285"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_285"), new string[6] { "Character", "Location", "Item", "Integer", "", "" }, isSourceRecord: true, new List<short> { 287 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(286, LocalStringManager.GetConfig("LifeRecord_language", "Name_286"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_286"), new string[6] { "Character", "Location", "Item", "Integer", "", "" }, isSourceRecord: true, new List<short> { 287 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(287, LocalStringManager.GetConfig("LifeRecord_language", "Name_287"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_287"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 285, 286 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(288, LocalStringManager.GetConfig("LifeRecord_language", "Name_288"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_288"), new string[6] { "Character", "Location", "Item", "Integer", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(289, LocalStringManager.GetConfig("LifeRecord_language", "Name_289"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_289"), new string[6] { "Character", "Location", "Item", "Integer", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(290, LocalStringManager.GetConfig("LifeRecord_language", "Name_290"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_290"), new string[6] { "Character", "Location", "Item", "Integer", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(291, LocalStringManager.GetConfig("LifeRecord_language", "Name_291"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_291"), new string[6] { "Character", "Location", "Item", "Integer", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(292, LocalStringManager.GetConfig("LifeRecord_language", "Name_292"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_292"), new string[6] { "Character", "Location", "Item", "Integer", "", "" }, isSourceRecord: true, new List<short> { 294 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(293, LocalStringManager.GetConfig("LifeRecord_language", "Name_293"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_293"), new string[6] { "Character", "Location", "Item", "Integer", "", "" }, isSourceRecord: true, new List<short> { 294 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(294, LocalStringManager.GetConfig("LifeRecord_language", "Name_294"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_294"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 292, 293 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(295, LocalStringManager.GetConfig("LifeRecord_language", "Name_295"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_295"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(296, LocalStringManager.GetConfig("LifeRecord_language", "Name_296"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_296"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(297, LocalStringManager.GetConfig("LifeRecord_language", "Name_297"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_297"), new string[6] { "Character", "Location", "Resource", "Integer", "Resource", "Integer" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(298, LocalStringManager.GetConfig("LifeRecord_language", "Name_298"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_298"), new string[6] { "Character", "Location", "Resource", "Integer", "", "" }, isSourceRecord: true, new List<short> { 303 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(299, LocalStringManager.GetConfig("LifeRecord_language", "Name_299"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_299"), new string[6] { "Character", "Location", "Resource", "Integer", "Item", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
	}

	private void CreateItems5()
	{
		_dataArray.Add(new LifeRecordItem(300, LocalStringManager.GetConfig("LifeRecord_language", "Name_300"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_300"), new string[6] { "Character", "Location", "Resource", "Integer", "Item", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(301, LocalStringManager.GetConfig("LifeRecord_language", "Name_301"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_301"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 304 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(302, LocalStringManager.GetConfig("LifeRecord_language", "Name_302"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_302"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 305 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(303, LocalStringManager.GetConfig("LifeRecord_language", "Name_303"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_303"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 298 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(304, LocalStringManager.GetConfig("LifeRecord_language", "Name_304"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_304"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 301 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(305, LocalStringManager.GetConfig("LifeRecord_language", "Name_305"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_305"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 302 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(306, LocalStringManager.GetConfig("LifeRecord_language", "Name_306"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_306"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 308, 309 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(307, LocalStringManager.GetConfig("LifeRecord_language", "Name_307"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_307"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 310, 311 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(308, LocalStringManager.GetConfig("LifeRecord_language", "Name_308"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_308"), new string[6] { "Character", "Location", "Item", "Integer", "", "" }, isSourceRecord: true, new List<short> { 306 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(309, LocalStringManager.GetConfig("LifeRecord_language", "Name_309"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_309"), new string[6] { "Character", "Location", "Item", "Integer", "", "" }, isSourceRecord: true, new List<short> { 306 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(310, LocalStringManager.GetConfig("LifeRecord_language", "Name_310"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_310"), new string[6] { "Character", "Location", "Item", "Integer", "", "" }, isSourceRecord: true, new List<short> { 307 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(311, LocalStringManager.GetConfig("LifeRecord_language", "Name_311"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_311"), new string[6] { "Character", "Location", "Item", "Integer", "", "" }, isSourceRecord: true, new List<short> { 307 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(312, LocalStringManager.GetConfig("LifeRecord_language", "Name_312"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_312"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 327 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(313, LocalStringManager.GetConfig("LifeRecord_language", "Name_313"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_313"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 328 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(314, LocalStringManager.GetConfig("LifeRecord_language", "Name_314"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_314"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 329 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(315, LocalStringManager.GetConfig("LifeRecord_language", "Name_315"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_315"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 330 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(316, LocalStringManager.GetConfig("LifeRecord_language", "Name_316"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_316"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 331 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(317, LocalStringManager.GetConfig("LifeRecord_language", "Name_317"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_317"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 332 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(318, LocalStringManager.GetConfig("LifeRecord_language", "Name_318"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_318"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 333 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(319, LocalStringManager.GetConfig("LifeRecord_language", "Name_319"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_319"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 334 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(320, LocalStringManager.GetConfig("LifeRecord_language", "Name_320"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_320"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 335 }, -30000, ELifeRecordScoreType.Normal, 20, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(321, LocalStringManager.GetConfig("LifeRecord_language", "Name_321"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_321"), new string[6] { "Character", "Location", "Resource", "Integer", "", "" }, isSourceRecord: true, new List<short> { 336 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(322, LocalStringManager.GetConfig("LifeRecord_language", "Name_322"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_322"), new string[6] { "Character", "Location", "Resource", "Integer", "", "" }, isSourceRecord: true, new List<short> { 337 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(323, LocalStringManager.GetConfig("LifeRecord_language", "Name_323"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_323"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 338 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(324, LocalStringManager.GetConfig("LifeRecord_language", "Name_324"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_324"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 339 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(325, LocalStringManager.GetConfig("LifeRecord_language", "Name_325"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_325"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 340 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(326, LocalStringManager.GetConfig("LifeRecord_language", "Name_326"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_326"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 341 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(327, LocalStringManager.GetConfig("LifeRecord_language", "Name_327"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_327"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 312 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(328, LocalStringManager.GetConfig("LifeRecord_language", "Name_328"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_328"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 313 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(329, LocalStringManager.GetConfig("LifeRecord_language", "Name_329"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_329"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 314 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(330, LocalStringManager.GetConfig("LifeRecord_language", "Name_330"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_330"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 315 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(331, LocalStringManager.GetConfig("LifeRecord_language", "Name_331"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_331"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 316 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(332, LocalStringManager.GetConfig("LifeRecord_language", "Name_332"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_332"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 317 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(333, LocalStringManager.GetConfig("LifeRecord_language", "Name_333"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_333"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 318 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(334, LocalStringManager.GetConfig("LifeRecord_language", "Name_334"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_334"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 319 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(335, LocalStringManager.GetConfig("LifeRecord_language", "Name_335"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_335"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 320 }, -30000, ELifeRecordScoreType.Normal, 20, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(336, LocalStringManager.GetConfig("LifeRecord_language", "Name_336"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_336"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 321 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(337, LocalStringManager.GetConfig("LifeRecord_language", "Name_337"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_337"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 322 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(338, LocalStringManager.GetConfig("LifeRecord_language", "Name_338"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_338"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 323 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(339, LocalStringManager.GetConfig("LifeRecord_language", "Name_339"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_339"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 324 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(340, LocalStringManager.GetConfig("LifeRecord_language", "Name_340"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_340"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 325 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(341, LocalStringManager.GetConfig("LifeRecord_language", "Name_341"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_341"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 326 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(342, LocalStringManager.GetConfig("LifeRecord_language", "Name_342"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_342"), new string[6] { "Location", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(343, LocalStringManager.GetConfig("LifeRecord_language", "Name_343"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_343"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 347 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(344, LocalStringManager.GetConfig("LifeRecord_language", "Name_344"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_344"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 348 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(345, LocalStringManager.GetConfig("LifeRecord_language", "Name_345"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_345"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 349 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(346, LocalStringManager.GetConfig("LifeRecord_language", "Name_346"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_346"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 350 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(347, LocalStringManager.GetConfig("LifeRecord_language", "Name_347"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_347"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 343 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(348, LocalStringManager.GetConfig("LifeRecord_language", "Name_348"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_348"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 344 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(349, LocalStringManager.GetConfig("LifeRecord_language", "Name_349"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_349"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 345 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(350, LocalStringManager.GetConfig("LifeRecord_language", "Name_350"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_350"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 346 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(351, LocalStringManager.GetConfig("LifeRecord_language", "Name_351"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_351"), new string[6] { "Location", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(352, LocalStringManager.GetConfig("LifeRecord_language", "Name_352"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_352"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(353, LocalStringManager.GetConfig("LifeRecord_language", "Name_353"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_353"), new string[6] { "Character", "Location", "SecretInformationTemplate", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(354, LocalStringManager.GetConfig("LifeRecord_language", "Name_354"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_354"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(355, LocalStringManager.GetConfig("LifeRecord_language", "Name_355"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_355"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 356 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(356, LocalStringManager.GetConfig("LifeRecord_language", "Name_356"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_356"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 355 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(357, LocalStringManager.GetConfig("LifeRecord_language", "Name_357"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_357"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 357 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(358, LocalStringManager.GetConfig("LifeRecord_language", "Name_358"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_358"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 361 }, -30000, ELifeRecordScoreType.Normal, 0, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(359, LocalStringManager.GetConfig("LifeRecord_language", "Name_359"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_359"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 362 }, -30000, ELifeRecordScoreType.Normal, 0, -1, ELifeRecordDisplayType.Relation));
	}

	private void CreateItems6()
	{
		_dataArray.Add(new LifeRecordItem(360, LocalStringManager.GetConfig("LifeRecord_language", "Name_360"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_360"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 363 }, -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(361, LocalStringManager.GetConfig("LifeRecord_language", "Name_361"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_361"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 358 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(362, LocalStringManager.GetConfig("LifeRecord_language", "Name_362"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_362"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 359 }, -30000, ELifeRecordScoreType.Absolute, 0, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(363, LocalStringManager.GetConfig("LifeRecord_language", "Name_363"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_363"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 360 }, -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(364, LocalStringManager.GetConfig("LifeRecord_language", "Name_364"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_364"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(365, LocalStringManager.GetConfig("LifeRecord_language", "Name_365"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_365"), new string[6] { "Location", "Resource", "Integer", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(366, LocalStringManager.GetConfig("LifeRecord_language", "Name_366"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_366"), new string[6] { "Location", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(367, LocalStringManager.GetConfig("LifeRecord_language", "Name_367"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_367"), new string[6] { "Location", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(368, LocalStringManager.GetConfig("LifeRecord_language", "Name_368"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_368"), new string[6] { "Location", "Integer", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(369, LocalStringManager.GetConfig("LifeRecord_language", "Name_369"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_369"), new string[6] { "Location", "Integer", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(370, LocalStringManager.GetConfig("LifeRecord_language", "Name_370"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_370"), new string[6] { "Location", "Integer", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(371, LocalStringManager.GetConfig("LifeRecord_language", "Name_371"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_371"), new string[6] { "Location", "PoisonType", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(372, LocalStringManager.GetConfig("LifeRecord_language", "Name_372"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_372"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(373, LocalStringManager.GetConfig("LifeRecord_language", "Name_373"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_373"), new string[6] { "Location", "Resource", "Integer", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(374, LocalStringManager.GetConfig("LifeRecord_language", "Name_374"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_374"), new string[6] { "Location", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(375, LocalStringManager.GetConfig("LifeRecord_language", "Name_375"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_375"), new string[6] { "Location", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(376, LocalStringManager.GetConfig("LifeRecord_language", "Name_376"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_376"), new string[6] { "Location", "Integer", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(377, LocalStringManager.GetConfig("LifeRecord_language", "Name_377"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_377"), new string[6] { "Location", "Integer", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(378, LocalStringManager.GetConfig("LifeRecord_language", "Name_378"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_378"), new string[6] { "Location", "Integer", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(379, LocalStringManager.GetConfig("LifeRecord_language", "Name_379"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_379"), new string[6] { "Location", "PoisonType", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(380, LocalStringManager.GetConfig("LifeRecord_language", "Name_380"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_380"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(381, LocalStringManager.GetConfig("LifeRecord_language", "Name_381"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_381"), new string[6] { "Location", "CharacterTemplate", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(382, LocalStringManager.GetConfig("LifeRecord_language", "Name_382"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_382"), new string[6] { "Location", "CharacterTemplate", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(383, LocalStringManager.GetConfig("LifeRecord_language", "Name_383"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_383"), new string[6] { "Location", "CharacterTemplate", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(384, LocalStringManager.GetConfig("LifeRecord_language", "Name_384"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_384"), new string[6] { "Location", "CharacterTemplate", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(385, LocalStringManager.GetConfig("LifeRecord_language", "Name_385"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_385"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 20, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(386, LocalStringManager.GetConfig("LifeRecord_language", "Name_386"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_386"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 20, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(387, LocalStringManager.GetConfig("LifeRecord_language", "Name_387"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_387"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 20, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(388, LocalStringManager.GetConfig("LifeRecord_language", "Name_388"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_388"), new string[6] { "Location", "Character", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 20, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(389, LocalStringManager.GetConfig("LifeRecord_language", "Name_389"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_389"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 20, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(390, LocalStringManager.GetConfig("LifeRecord_language", "Name_390"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_390"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 20, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(391, LocalStringManager.GetConfig("LifeRecord_language", "Name_391"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_391"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 20, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(392, LocalStringManager.GetConfig("LifeRecord_language", "Name_392"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_392"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 20, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(393, LocalStringManager.GetConfig("LifeRecord_language", "Name_393"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_393"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 80, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(394, LocalStringManager.GetConfig("LifeRecord_language", "Name_394"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_394"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 80, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(395, LocalStringManager.GetConfig("LifeRecord_language", "Name_395"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_395"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 80, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(396, LocalStringManager.GetConfig("LifeRecord_language", "Name_396"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_396"), new string[6] { "Location", "Character", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 80, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(397, LocalStringManager.GetConfig("LifeRecord_language", "Name_397"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_397"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 80, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(398, LocalStringManager.GetConfig("LifeRecord_language", "Name_398"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_398"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 80, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(399, LocalStringManager.GetConfig("LifeRecord_language", "Name_399"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_399"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 80, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(400, LocalStringManager.GetConfig("LifeRecord_language", "Name_400"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_400"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 80, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(401, LocalStringManager.GetConfig("LifeRecord_language", "Name_401"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_401"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 0, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(402, LocalStringManager.GetConfig("LifeRecord_language", "Name_402"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_402"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 20, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(403, LocalStringManager.GetConfig("LifeRecord_language", "Name_403"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_403"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 40, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(404, LocalStringManager.GetConfig("LifeRecord_language", "Name_404"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_404"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 50, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(405, LocalStringManager.GetConfig("LifeRecord_language", "Name_405"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_405"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 70, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(406, LocalStringManager.GetConfig("LifeRecord_language", "Name_406"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_406"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 90, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(407, LocalStringManager.GetConfig("LifeRecord_language", "Name_407"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_407"), new string[6] { "Character", "Integer", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(408, LocalStringManager.GetConfig("LifeRecord_language", "Name_408"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_408"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 20, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(409, LocalStringManager.GetConfig("LifeRecord_language", "Name_409"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_409"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 20, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(410, LocalStringManager.GetConfig("LifeRecord_language", "Name_410"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_410"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 413 }, -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(411, LocalStringManager.GetConfig("LifeRecord_language", "Name_411"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_411"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 691 }, -30000, ELifeRecordScoreType.Absolute, 80, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(412, LocalStringManager.GetConfig("LifeRecord_language", "Name_412"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_412"), new string[6] { "Location", "OrgGrade", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(413, LocalStringManager.GetConfig("LifeRecord_language", "Name_413"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_413"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 410 }, -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(414, LocalStringManager.GetConfig("LifeRecord_language", "Name_414"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_414"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 20, 5, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(415, LocalStringManager.GetConfig("LifeRecord_language", "Name_415"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_415"), new string[6] { "Character", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 80, 6, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(416, LocalStringManager.GetConfig("LifeRecord_language", "Name_416"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_416"), new string[6] { "Location", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(417, LocalStringManager.GetConfig("LifeRecord_language", "Name_417"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_417"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 90, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(418, LocalStringManager.GetConfig("LifeRecord_language", "Name_418"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_418"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 90, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(419, LocalStringManager.GetConfig("LifeRecord_language", "Name_419"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_419"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Normal));
	}

	private void CreateItems7()
	{
		_dataArray.Add(new LifeRecordItem(420, LocalStringManager.GetConfig("LifeRecord_language", "Name_420"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_420"), new string[6] { "Location", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(421, LocalStringManager.GetConfig("LifeRecord_language", "Name_421"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_421"), new string[6] { "Location", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(422, LocalStringManager.GetConfig("LifeRecord_language", "Name_422"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_422"), new string[6] { "Location", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(423, LocalStringManager.GetConfig("LifeRecord_language", "Name_423"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_423"), new string[6] { "Location", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(424, LocalStringManager.GetConfig("LifeRecord_language", "Name_424"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_424"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 80, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(425, LocalStringManager.GetConfig("LifeRecord_language", "Name_425"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_425"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 80, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(426, LocalStringManager.GetConfig("LifeRecord_language", "Name_426"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_426"), new string[6] { "Location", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(427, LocalStringManager.GetConfig("LifeRecord_language", "Name_427"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_427"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 0, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(428, LocalStringManager.GetConfig("LifeRecord_language", "Name_428"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_428"), new string[6] { "Location", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(429, LocalStringManager.GetConfig("LifeRecord_language", "Name_429"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_429"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 0, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(430, LocalStringManager.GetConfig("LifeRecord_language", "Name_430"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_430"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 0, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(431, LocalStringManager.GetConfig("LifeRecord_language", "Name_431"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_431"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 20, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(432, LocalStringManager.GetConfig("LifeRecord_language", "Name_432"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_432"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 80, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(433, LocalStringManager.GetConfig("LifeRecord_language", "Name_433"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_433"), new string[6] { "Location", "Character", "ItemSubType", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(434, LocalStringManager.GetConfig("LifeRecord_language", "Name_434"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_434"), new string[6] { "Location", "Character", "ItemSubType", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(435, LocalStringManager.GetConfig("LifeRecord_language", "Name_435"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_435"), new string[6] { "Location", "Character", "Settlement", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(436, LocalStringManager.GetConfig("LifeRecord_language", "Name_436"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_436"), new string[6] { "Location", "Character", "BehaviorType", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(437, LocalStringManager.GetConfig("LifeRecord_language", "Name_437"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_437"), new string[6] { "Location", "Character", "LifeSkillType", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(438, LocalStringManager.GetConfig("LifeRecord_language", "Name_438"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_438"), new string[6] { "Location", "Character", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(439, LocalStringManager.GetConfig("LifeRecord_language", "Name_439"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_439"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(440, LocalStringManager.GetConfig("LifeRecord_language", "Name_440"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_440"), new string[6] { "PunishmentType", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(441, LocalStringManager.GetConfig("LifeRecord_language", "Name_441"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_441"), new string[6] { "PunishmentType", "OrgGrade", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(442, LocalStringManager.GetConfig("LifeRecord_language", "Name_442"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_442"), new string[6] { "PunishmentType", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 0, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(443, LocalStringManager.GetConfig("LifeRecord_language", "Name_443"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_443"), new string[6] { "PunishmentType", "OrgGrade", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(444, LocalStringManager.GetConfig("LifeRecord_language", "Name_444"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_444"), new string[6] { "PunishmentType", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 0, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(445, LocalStringManager.GetConfig("LifeRecord_language", "Name_445"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_445"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(446, LocalStringManager.GetConfig("LifeRecord_language", "Name_446"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_446"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(447, LocalStringManager.GetConfig("LifeRecord_language", "Name_447"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_447"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short> { 461, 462 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(448, LocalStringManager.GetConfig("LifeRecord_language", "Name_448"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_448"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short> { 461, 462 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(449, LocalStringManager.GetConfig("LifeRecord_language", "Name_449"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_449"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short> { 459, 460 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(450, LocalStringManager.GetConfig("LifeRecord_language", "Name_450"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_450"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short> { 459, 460 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(451, LocalStringManager.GetConfig("LifeRecord_language", "Name_451"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_451"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(452, LocalStringManager.GetConfig("LifeRecord_language", "Name_452"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_452"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(453, LocalStringManager.GetConfig("LifeRecord_language", "Name_453"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_453"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(454, LocalStringManager.GetConfig("LifeRecord_language", "Name_454"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_454"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(455, LocalStringManager.GetConfig("LifeRecord_language", "Name_455"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_455"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(456, LocalStringManager.GetConfig("LifeRecord_language", "Name_456"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_456"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(457, LocalStringManager.GetConfig("LifeRecord_language", "Name_457"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_457"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(458, LocalStringManager.GetConfig("LifeRecord_language", "Name_458"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_458"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(459, LocalStringManager.GetConfig("LifeRecord_language", "Name_459"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_459"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 449, 450 }, -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(460, LocalStringManager.GetConfig("LifeRecord_language", "Name_460"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_460"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 449, 450 }, -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(461, LocalStringManager.GetConfig("LifeRecord_language", "Name_461"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_461"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 447, 448 }, -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(462, LocalStringManager.GetConfig("LifeRecord_language", "Name_462"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_462"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 447, 448 }, -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(463, LocalStringManager.GetConfig("LifeRecord_language", "Name_463"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_463"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(464, LocalStringManager.GetConfig("LifeRecord_language", "Name_464"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_464"), new string[6] { "Location", "Adventure", "Settlement", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(465, LocalStringManager.GetConfig("LifeRecord_language", "Name_465"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_465"), new string[6] { "Location", "Adventure", "CharacterTitle", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(466, LocalStringManager.GetConfig("LifeRecord_language", "Name_466"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_466"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, 16, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(467, LocalStringManager.GetConfig("LifeRecord_language", "Name_467"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_467"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 468 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(468, LocalStringManager.GetConfig("LifeRecord_language", "Name_468"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_468"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 467 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(469, LocalStringManager.GetConfig("LifeRecord_language", "Name_469"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_469"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 470 }, -30000, ELifeRecordScoreType.Normal, 40, 12, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(470, LocalStringManager.GetConfig("LifeRecord_language", "Name_470"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_470"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 469 }, -30000, ELifeRecordScoreType.Normal, 40, 11, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(471, LocalStringManager.GetConfig("LifeRecord_language", "Name_471"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_471"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 472 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(472, LocalStringManager.GetConfig("LifeRecord_language", "Name_472"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_472"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(473, LocalStringManager.GetConfig("LifeRecord_language", "Name_473"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_473"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 473 }, -30000, ELifeRecordScoreType.Normal, 40, 13, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(474, LocalStringManager.GetConfig("LifeRecord_language", "Name_474"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_474"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(475, LocalStringManager.GetConfig("LifeRecord_language", "Name_475"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_475"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(476, LocalStringManager.GetConfig("LifeRecord_language", "Name_476"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_476"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(477, LocalStringManager.GetConfig("LifeRecord_language", "Name_477"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_477"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(478, LocalStringManager.GetConfig("LifeRecord_language", "Name_478"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_478"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(479, LocalStringManager.GetConfig("LifeRecord_language", "Name_479"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_479"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
	}

	private void CreateItems8()
	{
		_dataArray.Add(new LifeRecordItem(480, LocalStringManager.GetConfig("LifeRecord_language", "Name_480"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_480"), new string[6] { "Location", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(481, LocalStringManager.GetConfig("LifeRecord_language", "Name_481"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_481"), new string[6] { "Location", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(482, LocalStringManager.GetConfig("LifeRecord_language", "Name_482"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_482"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(483, LocalStringManager.GetConfig("LifeRecord_language", "Name_483"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_483"), new string[6] { "Location", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 0, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(484, LocalStringManager.GetConfig("LifeRecord_language", "Name_484"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_484"), new string[6] { "Location", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 0, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(485, LocalStringManager.GetConfig("LifeRecord_language", "Name_485"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_485"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 0, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(486, LocalStringManager.GetConfig("LifeRecord_language", "Name_486"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_486"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(487, LocalStringManager.GetConfig("LifeRecord_language", "Name_487"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_487"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(488, LocalStringManager.GetConfig("LifeRecord_language", "Name_488"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_488"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 491 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(489, LocalStringManager.GetConfig("LifeRecord_language", "Name_489"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_489"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 490 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(490, LocalStringManager.GetConfig("LifeRecord_language", "Name_490"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_490"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 489 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(491, LocalStringManager.GetConfig("LifeRecord_language", "Name_491"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_491"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 488 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(492, LocalStringManager.GetConfig("LifeRecord_language", "Name_492"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_492"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 493 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(493, LocalStringManager.GetConfig("LifeRecord_language", "Name_493"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_493"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 492 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(494, LocalStringManager.GetConfig("LifeRecord_language", "Name_494"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_494"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 495 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(495, LocalStringManager.GetConfig("LifeRecord_language", "Name_495"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_495"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 494 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(496, LocalStringManager.GetConfig("LifeRecord_language", "Name_496"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_496"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 497 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(497, LocalStringManager.GetConfig("LifeRecord_language", "Name_497"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_497"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 496 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(498, LocalStringManager.GetConfig("LifeRecord_language", "Name_498"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_498"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 499 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(499, LocalStringManager.GetConfig("LifeRecord_language", "Name_499"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_499"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 498 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(500, LocalStringManager.GetConfig("LifeRecord_language", "Name_500"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_500"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 501 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(501, LocalStringManager.GetConfig("LifeRecord_language", "Name_501"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_501"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 500 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(502, LocalStringManager.GetConfig("LifeRecord_language", "Name_502"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_502"), new string[6] { "Character", "Location", "Item", "Resource", "Integer", "" }, isSourceRecord: true, new List<short> { 503 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(503, LocalStringManager.GetConfig("LifeRecord_language", "Name_503"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_503"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 502 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(504, LocalStringManager.GetConfig("LifeRecord_language", "Name_504"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_504"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 505 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(505, LocalStringManager.GetConfig("LifeRecord_language", "Name_505"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_505"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 504 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(506, LocalStringManager.GetConfig("LifeRecord_language", "Name_506"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_506"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 507 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(507, LocalStringManager.GetConfig("LifeRecord_language", "Name_507"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_507"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 506 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(508, LocalStringManager.GetConfig("LifeRecord_language", "Name_508"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_508"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 513 }, -30000, ELifeRecordScoreType.Normal, 70, 3, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(509, LocalStringManager.GetConfig("LifeRecord_language", "Name_509"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_509"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 514 }, -30000, ELifeRecordScoreType.Normal, 70, 7, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(510, LocalStringManager.GetConfig("LifeRecord_language", "Name_510"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_510"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 515 }, -30000, ELifeRecordScoreType.Normal, 70, 8, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(511, LocalStringManager.GetConfig("LifeRecord_language", "Name_511"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_511"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 516 }, -30000, ELifeRecordScoreType.Normal, 70, 10, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(512, LocalStringManager.GetConfig("LifeRecord_language", "Name_512"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_512"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 517 }, -30000, ELifeRecordScoreType.Normal, 70, 2, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(513, LocalStringManager.GetConfig("LifeRecord_language", "Name_513"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_513"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 508 }, -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(514, LocalStringManager.GetConfig("LifeRecord_language", "Name_514"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_514"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 509 }, -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(515, LocalStringManager.GetConfig("LifeRecord_language", "Name_515"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_515"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 510 }, -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(516, LocalStringManager.GetConfig("LifeRecord_language", "Name_516"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_516"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 511 }, -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(517, LocalStringManager.GetConfig("LifeRecord_language", "Name_517"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_517"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 512 }, -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(518, LocalStringManager.GetConfig("LifeRecord_language", "Name_518"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_518"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 519 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(519, LocalStringManager.GetConfig("LifeRecord_language", "Name_519"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_519"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 518 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(520, LocalStringManager.GetConfig("LifeRecord_language", "Name_520"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_520"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 521 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(521, LocalStringManager.GetConfig("LifeRecord_language", "Name_521"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_521"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 520 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(522, LocalStringManager.GetConfig("LifeRecord_language", "Name_522"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_522"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 523 }, -30000, ELifeRecordScoreType.Normal, 70, 1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(523, LocalStringManager.GetConfig("LifeRecord_language", "Name_523"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_523"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 522 }, -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(524, LocalStringManager.GetConfig("LifeRecord_language", "Name_524"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_524"), new string[6] { "Character", "Location", "Item", "Integer", "", "" }, isSourceRecord: true, new List<short> { 525 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(525, LocalStringManager.GetConfig("LifeRecord_language", "Name_525"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_525"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 524 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(526, LocalStringManager.GetConfig("LifeRecord_language", "Name_526"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_526"), new string[6] { "Location", "Item", "Settlement", "OrgGrade", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(527, LocalStringManager.GetConfig("LifeRecord_language", "Name_527"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_527"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 528 }, -30000, ELifeRecordScoreType.Normal, 49, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(528, LocalStringManager.GetConfig("LifeRecord_language", "Name_528"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_528"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 527 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(529, LocalStringManager.GetConfig("LifeRecord_language", "Name_529"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_529"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 531 }, -30000, ELifeRecordScoreType.Normal, 80, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(530, LocalStringManager.GetConfig("LifeRecord_language", "Name_530"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_530"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 532 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(531, LocalStringManager.GetConfig("LifeRecord_language", "Name_531"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_531"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 529 }, -30000, ELifeRecordScoreType.Normal, 80, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(532, LocalStringManager.GetConfig("LifeRecord_language", "Name_532"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_532"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 530 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(533, LocalStringManager.GetConfig("LifeRecord_language", "Name_533"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_533"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 534 }, -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(534, LocalStringManager.GetConfig("LifeRecord_language", "Name_534"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_534"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 533 }, -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(535, LocalStringManager.GetConfig("LifeRecord_language", "Name_535"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_535"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 536 }, -30000, ELifeRecordScoreType.Normal, 80, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(536, LocalStringManager.GetConfig("LifeRecord_language", "Name_536"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_536"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 535 }, -30000, ELifeRecordScoreType.Normal, 80, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(537, LocalStringManager.GetConfig("LifeRecord_language", "Name_537"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_537"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 538 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(538, LocalStringManager.GetConfig("LifeRecord_language", "Name_538"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_538"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 537 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(539, LocalStringManager.GetConfig("LifeRecord_language", "Name_539"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_539"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 90, -1, ELifeRecordDisplayType.Relation));
	}

	private void CreateItems9()
	{
		_dataArray.Add(new LifeRecordItem(540, LocalStringManager.GetConfig("LifeRecord_language", "Name_540"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_540"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 541 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(541, LocalStringManager.GetConfig("LifeRecord_language", "Name_541"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_541"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 540 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(542, LocalStringManager.GetConfig("LifeRecord_language", "Name_542"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_542"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(543, LocalStringManager.GetConfig("LifeRecord_language", "Name_543"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_543"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 544 }, -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(544, LocalStringManager.GetConfig("LifeRecord_language", "Name_544"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_544"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 543 }, -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(545, LocalStringManager.GetConfig("LifeRecord_language", "Name_545"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_545"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 546 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(546, LocalStringManager.GetConfig("LifeRecord_language", "Name_546"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_546"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 545 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(547, LocalStringManager.GetConfig("LifeRecord_language", "Name_547"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_547"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(548, LocalStringManager.GetConfig("LifeRecord_language", "Name_548"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_548"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 549 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(549, LocalStringManager.GetConfig("LifeRecord_language", "Name_549"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_549"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 548 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(550, LocalStringManager.GetConfig("LifeRecord_language", "Name_550"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_550"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(551, LocalStringManager.GetConfig("LifeRecord_language", "Name_551"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_551"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(552, LocalStringManager.GetConfig("LifeRecord_language", "Name_552"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_552"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 553 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(553, LocalStringManager.GetConfig("LifeRecord_language", "Name_553"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_553"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 552 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(554, LocalStringManager.GetConfig("LifeRecord_language", "Name_554"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_554"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(555, LocalStringManager.GetConfig("LifeRecord_language", "Name_555"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_555"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(556, LocalStringManager.GetConfig("LifeRecord_language", "Name_556"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_556"), new string[6] { "Location", "LifeSkillType", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(557, LocalStringManager.GetConfig("LifeRecord_language", "Name_557"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_557"), new string[6] { "Location", "CombatSkillType", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(558, LocalStringManager.GetConfig("LifeRecord_language", "Name_558"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_558"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 559 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(559, LocalStringManager.GetConfig("LifeRecord_language", "Name_559"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_559"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 558 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(560, LocalStringManager.GetConfig("LifeRecord_language", "Name_560"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_560"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(561, LocalStringManager.GetConfig("LifeRecord_language", "Name_561"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_561"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(562, LocalStringManager.GetConfig("LifeRecord_language", "Name_562"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_562"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(563, LocalStringManager.GetConfig("LifeRecord_language", "Name_563"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_563"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(564, LocalStringManager.GetConfig("LifeRecord_language", "Name_564"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_564"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 565 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(565, LocalStringManager.GetConfig("LifeRecord_language", "Name_565"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_565"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 564 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(566, LocalStringManager.GetConfig("LifeRecord_language", "Name_566"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_566"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(567, LocalStringManager.GetConfig("LifeRecord_language", "Name_567"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_567"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 568 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(568, LocalStringManager.GetConfig("LifeRecord_language", "Name_568"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_568"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 567 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(569, LocalStringManager.GetConfig("LifeRecord_language", "Name_569"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_569"), new string[6] { "Character", "Location", "Integer", "Item", "", "" }, isSourceRecord: true, new List<short> { 570 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(570, LocalStringManager.GetConfig("LifeRecord_language", "Name_570"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_570"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 569 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(571, LocalStringManager.GetConfig("LifeRecord_language", "Name_571"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_571"), new string[6] { "Location", "Integer", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(572, LocalStringManager.GetConfig("LifeRecord_language", "Name_572"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_572"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 573 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(573, LocalStringManager.GetConfig("LifeRecord_language", "Name_573"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_573"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 572 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(574, LocalStringManager.GetConfig("LifeRecord_language", "Name_574"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_574"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 575 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(575, LocalStringManager.GetConfig("LifeRecord_language", "Name_575"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_575"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 574 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(576, LocalStringManager.GetConfig("LifeRecord_language", "Name_576"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_576"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 577 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(577, LocalStringManager.GetConfig("LifeRecord_language", "Name_577"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_577"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 576 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(578, LocalStringManager.GetConfig("LifeRecord_language", "Name_578"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_578"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 579 }, -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(579, LocalStringManager.GetConfig("LifeRecord_language", "Name_579"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_579"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 578 }, -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(580, LocalStringManager.GetConfig("LifeRecord_language", "Name_580"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_580"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 581 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(581, LocalStringManager.GetConfig("LifeRecord_language", "Name_581"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_581"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 580 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(582, LocalStringManager.GetConfig("LifeRecord_language", "Name_582"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_582"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(583, LocalStringManager.GetConfig("LifeRecord_language", "Name_583"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_583"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(584, LocalStringManager.GetConfig("LifeRecord_language", "Name_584"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_584"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 585 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(585, LocalStringManager.GetConfig("LifeRecord_language", "Name_585"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_585"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 584 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(586, LocalStringManager.GetConfig("LifeRecord_language", "Name_586"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_586"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(587, LocalStringManager.GetConfig("LifeRecord_language", "Name_587"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_587"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 90, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(588, LocalStringManager.GetConfig("LifeRecord_language", "Name_588"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_588"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 0, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(589, LocalStringManager.GetConfig("LifeRecord_language", "Name_589"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_589"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 30, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(590, LocalStringManager.GetConfig("LifeRecord_language", "Name_590"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_590"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 70, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(591, LocalStringManager.GetConfig("LifeRecord_language", "Name_591"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_591"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 592 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(592, LocalStringManager.GetConfig("LifeRecord_language", "Name_592"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_592"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 591 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(593, LocalStringManager.GetConfig("LifeRecord_language", "Name_593"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_593"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(594, LocalStringManager.GetConfig("LifeRecord_language", "Name_594"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_594"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(595, LocalStringManager.GetConfig("LifeRecord_language", "Name_595"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_595"), new string[6] { "Location", "CombatSkill", "LifeSkill", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(596, LocalStringManager.GetConfig("LifeRecord_language", "Name_596"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_596"), new string[6] { "Location", "CombatSkill", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(597, LocalStringManager.GetConfig("LifeRecord_language", "Name_597"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_597"), new string[6] { "Location", "LifeSkill", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(598, LocalStringManager.GetConfig("LifeRecord_language", "Name_598"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_598"), new string[6] { "Location", "Integer", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(599, LocalStringManager.GetConfig("LifeRecord_language", "Name_599"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_599"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
	}

	private void CreateItems10()
	{
		_dataArray.Add(new LifeRecordItem(600, LocalStringManager.GetConfig("LifeRecord_language", "Name_600"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_600"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(601, LocalStringManager.GetConfig("LifeRecord_language", "Name_601"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_601"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 602 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(602, LocalStringManager.GetConfig("LifeRecord_language", "Name_602"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_602"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 601 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(603, LocalStringManager.GetConfig("LifeRecord_language", "Name_603"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_603"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 90, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(604, LocalStringManager.GetConfig("LifeRecord_language", "Name_604"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_604"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 30, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(605, LocalStringManager.GetConfig("LifeRecord_language", "Name_605"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_605"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 70, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(606, LocalStringManager.GetConfig("LifeRecord_language", "Name_606"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_606"), new string[6] { "Character", "Location", "Settlement", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 90, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(607, LocalStringManager.GetConfig("LifeRecord_language", "Name_607"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_607"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 90, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(608, LocalStringManager.GetConfig("LifeRecord_language", "Name_608"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_608"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(609, LocalStringManager.GetConfig("LifeRecord_language", "Name_609"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_609"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(610, LocalStringManager.GetConfig("LifeRecord_language", "Name_610"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_610"), new string[6] { "Location", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(611, LocalStringManager.GetConfig("LifeRecord_language", "Name_611"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_611"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(612, LocalStringManager.GetConfig("LifeRecord_language", "Name_612"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_612"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(613, LocalStringManager.GetConfig("LifeRecord_language", "Name_613"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_613"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(614, LocalStringManager.GetConfig("LifeRecord_language", "Name_614"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_614"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(615, LocalStringManager.GetConfig("LifeRecord_language", "Name_615"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_615"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(616, LocalStringManager.GetConfig("LifeRecord_language", "Name_616"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_616"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(617, LocalStringManager.GetConfig("LifeRecord_language", "Name_617"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_617"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(618, LocalStringManager.GetConfig("LifeRecord_language", "Name_618"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_618"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(619, LocalStringManager.GetConfig("LifeRecord_language", "Name_619"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_619"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(620, LocalStringManager.GetConfig("LifeRecord_language", "Name_620"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_620"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(621, LocalStringManager.GetConfig("LifeRecord_language", "Name_621"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_621"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(622, LocalStringManager.GetConfig("LifeRecord_language", "Name_622"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_622"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(623, LocalStringManager.GetConfig("LifeRecord_language", "Name_623"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_623"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(624, LocalStringManager.GetConfig("LifeRecord_language", "Name_624"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_624"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(625, LocalStringManager.GetConfig("LifeRecord_language", "Name_625"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_625"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(626, LocalStringManager.GetConfig("LifeRecord_language", "Name_626"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_626"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(627, LocalStringManager.GetConfig("LifeRecord_language", "Name_627"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_627"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(628, LocalStringManager.GetConfig("LifeRecord_language", "Name_628"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_628"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Invalid, -1, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(629, LocalStringManager.GetConfig("LifeRecord_language", "Name_629"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_629"), new string[6] { "Location", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Invalid, -1, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(630, LocalStringManager.GetConfig("LifeRecord_language", "Name_630"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_630"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(631, LocalStringManager.GetConfig("LifeRecord_language", "Name_631"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_631"), new string[6] { "Location", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(632, LocalStringManager.GetConfig("LifeRecord_language", "Name_632"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_632"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Invalid, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(633, LocalStringManager.GetConfig("LifeRecord_language", "Name_633"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_633"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Invalid, -1, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(634, LocalStringManager.GetConfig("LifeRecord_language", "Name_634"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_634"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Invalid, -1, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(635, LocalStringManager.GetConfig("LifeRecord_language", "Name_635"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_635"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Invalid, -1, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(636, LocalStringManager.GetConfig("LifeRecord_language", "Name_636"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_636"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Invalid, -1, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(637, LocalStringManager.GetConfig("LifeRecord_language", "Name_637"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_637"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(638, LocalStringManager.GetConfig("LifeRecord_language", "Name_638"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_638"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 60, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(639, LocalStringManager.GetConfig("LifeRecord_language", "Name_639"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_639"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(640, LocalStringManager.GetConfig("LifeRecord_language", "Name_640"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_640"), new string[6] { "Location", "Character", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(641, LocalStringManager.GetConfig("LifeRecord_language", "Name_641"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_641"), new string[6] { "Location", "Character", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(642, LocalStringManager.GetConfig("LifeRecord_language", "Name_642"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_642"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(643, LocalStringManager.GetConfig("LifeRecord_language", "Name_643"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_643"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Invalid, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(644, LocalStringManager.GetConfig("LifeRecord_language", "Name_644"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_644"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Invalid, -1, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(645, LocalStringManager.GetConfig("LifeRecord_language", "Name_645"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_645"), new string[6] { "Settlement", "OrgGrade", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Invalid, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(646, LocalStringManager.GetConfig("LifeRecord_language", "Name_646"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_646"), new string[6] { "Location", "Character", "Settlement", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(647, LocalStringManager.GetConfig("LifeRecord_language", "Name_647"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_647"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 80, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(648, LocalStringManager.GetConfig("LifeRecord_language", "Name_648"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_648"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Invalid, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(649, LocalStringManager.GetConfig("LifeRecord_language", "Name_649"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_649"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Invalid, -1, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(650, LocalStringManager.GetConfig("LifeRecord_language", "Name_650"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_650"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Invalid, -1, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(651, LocalStringManager.GetConfig("LifeRecord_language", "Name_651"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_651"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(652, LocalStringManager.GetConfig("LifeRecord_language", "Name_652"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_652"), new string[6] { "Location", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(653, LocalStringManager.GetConfig("LifeRecord_language", "Name_653"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_653"), new string[6] { "Character", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 0, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(654, LocalStringManager.GetConfig("LifeRecord_language", "Name_654"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_654"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(655, LocalStringManager.GetConfig("LifeRecord_language", "Name_655"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_655"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(656, LocalStringManager.GetConfig("LifeRecord_language", "Name_656"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_656"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 657 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(657, LocalStringManager.GetConfig("LifeRecord_language", "Name_657"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_657"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 656 }, -30000, ELifeRecordScoreType.Absolute, 80, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(658, LocalStringManager.GetConfig("LifeRecord_language", "Name_658"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_658"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 659 }, -30000, ELifeRecordScoreType.Absolute, 80, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(659, LocalStringManager.GetConfig("LifeRecord_language", "Name_659"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_659"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 658 }, -30000, ELifeRecordScoreType.Absolute, 80, -1, ELifeRecordDisplayType.Relation));
	}

	private void CreateItems11()
	{
		_dataArray.Add(new LifeRecordItem(660, LocalStringManager.GetConfig("LifeRecord_language", "Name_660"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_660"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(661, LocalStringManager.GetConfig("LifeRecord_language", "Name_661"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_661"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(662, LocalStringManager.GetConfig("LifeRecord_language", "Name_662"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_662"), new string[6] { "Location", "CharacterTemplate", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(663, LocalStringManager.GetConfig("LifeRecord_language", "Name_663"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_663"), new string[6] { "Location", "CharacterTemplate", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(664, LocalStringManager.GetConfig("LifeRecord_language", "Name_664"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_664"), new string[6] { "Location", "Adventure", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(665, LocalStringManager.GetConfig("LifeRecord_language", "Name_665"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_665"), new string[6] { "Location", "Adventure", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(666, LocalStringManager.GetConfig("LifeRecord_language", "Name_666"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_666"), new string[6] { "Character", "Location", "Adventure", "", "", "" }, isSourceRecord: true, new List<short> { 692 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(667, LocalStringManager.GetConfig("LifeRecord_language", "Name_667"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_667"), new string[6] { "Location", "SecretInformation", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(668, LocalStringManager.GetConfig("LifeRecord_language", "Name_668"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_668"), new string[6] { "Location", "SecretInformation", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(669, LocalStringManager.GetConfig("LifeRecord_language", "Name_669"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_669"), new string[6] { "Location", "SecretInformation", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(670, LocalStringManager.GetConfig("LifeRecord_language", "Name_670"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_670"), new string[6] { "Location", "SecretInformation", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(671, LocalStringManager.GetConfig("LifeRecord_language", "Name_671"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_671"), new string[6] { "Character", "Location", "SecretInformation", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(672, LocalStringManager.GetConfig("LifeRecord_language", "Name_672"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_672"), new string[6] { "Character", "Location", "SecretInformation", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(673, LocalStringManager.GetConfig("LifeRecord_language", "Name_673"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_673"), new string[6] { "Character", "Location", "SecretInformation", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(674, LocalStringManager.GetConfig("LifeRecord_language", "Name_674"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_674"), new string[6] { "Character", "Location", "SecretInformation", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(675, LocalStringManager.GetConfig("LifeRecord_language", "Name_675"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_675"), new string[6] { "Character", "Location", "SecretInformation", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(676, LocalStringManager.GetConfig("LifeRecord_language", "Name_676"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_676"), new string[6] { "Character", "Location", "SecretInformation", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(677, LocalStringManager.GetConfig("LifeRecord_language", "Name_677"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_677"), new string[6] { "Character", "Location", "SecretInformation", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(678, LocalStringManager.GetConfig("LifeRecord_language", "Name_678"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_678"), new string[6] { "Character", "Location", "SecretInformation", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(679, LocalStringManager.GetConfig("LifeRecord_language", "Name_679"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_679"), new string[6] { "Character", "Location", "SecretInformation", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(680, LocalStringManager.GetConfig("LifeRecord_language", "Name_680"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_680"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(681, LocalStringManager.GetConfig("LifeRecord_language", "Name_681"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_681"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(682, LocalStringManager.GetConfig("LifeRecord_language", "Name_682"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_682"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(683, LocalStringManager.GetConfig("LifeRecord_language", "Name_683"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_683"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(684, LocalStringManager.GetConfig("LifeRecord_language", "Name_684"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_684"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(685, LocalStringManager.GetConfig("LifeRecord_language", "Name_685"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_685"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(686, LocalStringManager.GetConfig("LifeRecord_language", "Name_686"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_686"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(687, LocalStringManager.GetConfig("LifeRecord_language", "Name_687"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_687"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(688, LocalStringManager.GetConfig("LifeRecord_language", "Name_688"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_688"), new string[6] { "Character", "Location", "SecretInformation", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(689, LocalStringManager.GetConfig("LifeRecord_language", "Name_689"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_689"), new string[6] { "CharacterRealName", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(690, LocalStringManager.GetConfig("LifeRecord_language", "Name_690"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_690"), new string[6] { "Location", "Adventure", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(691, LocalStringManager.GetConfig("LifeRecord_language", "Name_691"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_691"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 411 }, -30000, ELifeRecordScoreType.Normal, 50, 4, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(692, LocalStringManager.GetConfig("LifeRecord_language", "Name_692"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_692"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 666 }, -30000, ELifeRecordScoreType.Normal, 50, 9, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(693, LocalStringManager.GetConfig("LifeRecord_language", "Name_693"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_693"), new string[6] { "Character", "Location", "Adventure", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(694, LocalStringManager.GetConfig("LifeRecord_language", "Name_694"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_694"), new string[6] { "Item", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(695, LocalStringManager.GetConfig("LifeRecord_language", "Name_695"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_695"), new string[6] { "Item", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(696, LocalStringManager.GetConfig("LifeRecord_language", "Name_696"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_696"), new string[6] { "Item", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(697, LocalStringManager.GetConfig("LifeRecord_language", "Name_697"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_697"), new string[6] { "Character", "Location", "JiaoLoong", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(698, LocalStringManager.GetConfig("LifeRecord_language", "Name_698"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_698"), new string[6] { "Location", "JiaoLoong", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(699, LocalStringManager.GetConfig("LifeRecord_language", "Name_699"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_699"), new string[6] { "Character", "Location", "JiaoLoong", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(700, LocalStringManager.GetConfig("LifeRecord_language", "Name_700"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_700"), new string[6] { "Location", "JiaoLoong", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(701, LocalStringManager.GetConfig("LifeRecord_language", "Name_701"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_701"), new string[6] { "JiaoLoong", "Cricket", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(702, LocalStringManager.GetConfig("LifeRecord_language", "Name_702"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_702"), new string[6] { "Location", "JiaoLoong", "Item", "Integer", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(703, LocalStringManager.GetConfig("LifeRecord_language", "Name_703"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_703"), new string[6] { "Location", "JiaoLoong", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(704, LocalStringManager.GetConfig("LifeRecord_language", "Name_704"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_704"), new string[6] { "Location", "JiaoLoong", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(705, LocalStringManager.GetConfig("LifeRecord_language", "Name_705"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_705"), new string[6] { "Location", "JiaoLoong", "Item", "Integer", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(706, LocalStringManager.GetConfig("LifeRecord_language", "Name_706"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_706"), new string[6] { "Location", "JiaoLoong", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(707, LocalStringManager.GetConfig("LifeRecord_language", "Name_707"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_707"), new string[6] { "CharacterTemplate", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(708, LocalStringManager.GetConfig("LifeRecord_language", "Name_708"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_708"), new string[6] { "CharacterTemplate", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(709, LocalStringManager.GetConfig("LifeRecord_language", "Name_709"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_709"), new string[6] { "Location", "JiaoLoong", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(710, LocalStringManager.GetConfig("LifeRecord_language", "Name_710"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_710"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(711, LocalStringManager.GetConfig("LifeRecord_language", "Name_711"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_711"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(712, LocalStringManager.GetConfig("LifeRecord_language", "Name_712"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_712"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 91 }, -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(713, LocalStringManager.GetConfig("LifeRecord_language", "Name_713"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_713"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 92 }, -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(714, LocalStringManager.GetConfig("LifeRecord_language", "Name_714"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_714"), new string[6] { "Character", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(715, LocalStringManager.GetConfig("LifeRecord_language", "Name_715"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_715"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(716, LocalStringManager.GetConfig("LifeRecord_language", "Name_716"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_716"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(717, LocalStringManager.GetConfig("LifeRecord_language", "Name_717"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_717"), new string[6] { "Location", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(718, LocalStringManager.GetConfig("LifeRecord_language", "Name_718"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_718"), new string[6] { "Location", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(719, LocalStringManager.GetConfig("LifeRecord_language", "Name_719"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_719"), new string[6] { "Character", "Location", "CombatType", "", "", "" }, isSourceRecord: true, new List<short> { 720 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Combat));
	}

	private void CreateItems12()
	{
		_dataArray.Add(new LifeRecordItem(720, LocalStringManager.GetConfig("LifeRecord_language", "Name_720"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_720"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 719 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(721, LocalStringManager.GetConfig("LifeRecord_language", "Name_721"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_721"), new string[6] { "Character", "Location", "CombatType", "", "", "" }, isSourceRecord: true, new List<short> { 722 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(722, LocalStringManager.GetConfig("LifeRecord_language", "Name_722"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_722"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 721 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(723, LocalStringManager.GetConfig("LifeRecord_language", "Name_723"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_723"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 737 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(724, LocalStringManager.GetConfig("LifeRecord_language", "Name_724"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_724"), new string[6] { "Character", "Location", "SecretInformationTemplate", "", "", "" }, isSourceRecord: true, new List<short> { 725 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(725, LocalStringManager.GetConfig("LifeRecord_language", "Name_725"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_725"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 724 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(726, LocalStringManager.GetConfig("LifeRecord_language", "Name_726"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_726"), new string[6] { "Location", "CharacterTemplate", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(727, LocalStringManager.GetConfig("LifeRecord_language", "Name_727"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_727"), new string[6] { "Location", "CharacterTemplate", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(728, LocalStringManager.GetConfig("LifeRecord_language", "Name_728"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_728"), new string[6] { "Location", "CharacterTemplate", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(729, LocalStringManager.GetConfig("LifeRecord_language", "Name_729"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_729"), new string[6] { "Location", "CharacterTemplate", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(730, LocalStringManager.GetConfig("LifeRecord_language", "Name_730"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_730"), new string[6] { "Location", "CharacterTemplate", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(731, LocalStringManager.GetConfig("LifeRecord_language", "Name_731"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_731"), new string[6] { "Location", "CharacterTemplate", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(732, LocalStringManager.GetConfig("LifeRecord_language", "Name_732"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_732"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(733, LocalStringManager.GetConfig("LifeRecord_language", "Name_733"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_733"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(734, LocalStringManager.GetConfig("LifeRecord_language", "Name_734"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_734"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(735, LocalStringManager.GetConfig("LifeRecord_language", "Name_735"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_735"), new string[6] { "Item", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(736, LocalStringManager.GetConfig("LifeRecord_language", "Name_736"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_736"), new string[6] { "Item", "Character", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(737, LocalStringManager.GetConfig("LifeRecord_language", "Name_737"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_737"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 723 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(738, LocalStringManager.GetConfig("LifeRecord_language", "Name_738"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_738"), new string[6] { "Item", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(739, LocalStringManager.GetConfig("LifeRecord_language", "Name_739"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_739"), new string[6] { "Item", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(740, LocalStringManager.GetConfig("LifeRecord_language", "Name_740"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_740"), new string[6] { "Item", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(741, LocalStringManager.GetConfig("LifeRecord_language", "Name_741"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_741"), new string[6] { "Item", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(742, LocalStringManager.GetConfig("LifeRecord_language", "Name_742"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_742"), new string[6] { "Item", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(743, LocalStringManager.GetConfig("LifeRecord_language", "Name_743"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_743"), new string[6] { "Item", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(744, LocalStringManager.GetConfig("LifeRecord_language", "Name_744"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_744"), new string[6] { "Character", "Location", "Item", "Item", "", "" }, isSourceRecord: true, new List<short> { 745 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(745, LocalStringManager.GetConfig("LifeRecord_language", "Name_745"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_745"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 744 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(746, LocalStringManager.GetConfig("LifeRecord_language", "Name_746"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_746"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(747, LocalStringManager.GetConfig("LifeRecord_language", "Name_747"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_747"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(748, LocalStringManager.GetConfig("LifeRecord_language", "Name_748"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_748"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(749, LocalStringManager.GetConfig("LifeRecord_language", "Name_749"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_749"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(750, LocalStringManager.GetConfig("LifeRecord_language", "Name_750"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_750"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(751, LocalStringManager.GetConfig("LifeRecord_language", "Name_751"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_751"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(752, LocalStringManager.GetConfig("LifeRecord_language", "Name_752"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_752"), new string[6] { "Item", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(753, LocalStringManager.GetConfig("LifeRecord_language", "Name_753"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_753"), new string[6] { "Item", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(754, LocalStringManager.GetConfig("LifeRecord_language", "Name_754"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_754"), new string[6] { "Item", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(755, LocalStringManager.GetConfig("LifeRecord_language", "Name_755"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_755"), new string[6] { "Item", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(756, LocalStringManager.GetConfig("LifeRecord_language", "Name_756"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_756"), new string[6] { "Item", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(757, LocalStringManager.GetConfig("LifeRecord_language", "Name_757"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_757"), new string[6] { "Character", "Location", "Item", "Item", "", "" }, isSourceRecord: true, new List<short> { 758 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(758, LocalStringManager.GetConfig("LifeRecord_language", "Name_758"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_758"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 757 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(759, LocalStringManager.GetConfig("LifeRecord_language", "Name_759"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_759"), new string[6] { "Item", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(760, LocalStringManager.GetConfig("LifeRecord_language", "Name_760"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_760"), new string[6] { "Item", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(761, LocalStringManager.GetConfig("LifeRecord_language", "Name_761"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_761"), new string[6] { "Character", "Location", "Item", "Item", "", "" }, isSourceRecord: true, new List<short> { 762 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(762, LocalStringManager.GetConfig("LifeRecord_language", "Name_762"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_762"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 761 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(763, LocalStringManager.GetConfig("LifeRecord_language", "Name_763"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_763"), new string[6] { "Item", "Integer", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(764, LocalStringManager.GetConfig("LifeRecord_language", "Name_764"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_764"), new string[6] { "Item", "Integer", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(765, LocalStringManager.GetConfig("LifeRecord_language", "Name_765"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_765"), new string[6] { "LifeSkillType", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(766, LocalStringManager.GetConfig("LifeRecord_language", "Name_766"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_766"), new string[6] { "CombatSkillType", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(767, LocalStringManager.GetConfig("LifeRecord_language", "Name_767"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_767"), new string[6] { "LifeSkillType", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(768, LocalStringManager.GetConfig("LifeRecord_language", "Name_768"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_768"), new string[6] { "CombatSkillType", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(769, LocalStringManager.GetConfig("LifeRecord_language", "Name_769"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_769"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 0, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(770, LocalStringManager.GetConfig("LifeRecord_language", "Name_770"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_770"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 771 }, -30000, ELifeRecordScoreType.Absolute, 80, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(771, LocalStringManager.GetConfig("LifeRecord_language", "Name_771"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_771"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 770 }, -30000, ELifeRecordScoreType.Normal, 50, 4, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(772, LocalStringManager.GetConfig("LifeRecord_language", "Name_772"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_772"), new string[6] { "Settlement", "Resource", "Integer", "Integer", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(773, LocalStringManager.GetConfig("LifeRecord_language", "Name_773"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_773"), new string[6] { "Settlement", "Item", "Integer", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(774, LocalStringManager.GetConfig("LifeRecord_language", "Name_774"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_774"), new string[6] { "Settlement", "Resource", "Integer", "Integer", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(775, LocalStringManager.GetConfig("LifeRecord_language", "Name_775"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_775"), new string[6] { "Settlement", "Item", "Integer", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(776, LocalStringManager.GetConfig("LifeRecord_language", "Name_776"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_776"), new string[6] { "Settlement", "Resource", "Integer", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(777, LocalStringManager.GetConfig("LifeRecord_language", "Name_777"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_777"), new string[6] { "Settlement", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(778, LocalStringManager.GetConfig("LifeRecord_language", "Name_778"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_778"), new string[6] { "Settlement", "Resource", "Integer", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(779, LocalStringManager.GetConfig("LifeRecord_language", "Name_779"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_779"), new string[6] { "Settlement", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
	}

	private void CreateItems13()
	{
		_dataArray.Add(new LifeRecordItem(780, LocalStringManager.GetConfig("LifeRecord_language", "Name_780"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_780"), new string[6] { "Location", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(781, LocalStringManager.GetConfig("LifeRecord_language", "Name_781"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_781"), new string[6] { "Location", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(782, LocalStringManager.GetConfig("LifeRecord_language", "Name_782"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_782"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(783, LocalStringManager.GetConfig("LifeRecord_language", "Name_783"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_783"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(784, LocalStringManager.GetConfig("LifeRecord_language", "Name_784"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_784"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(785, LocalStringManager.GetConfig("LifeRecord_language", "Name_785"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_785"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(786, LocalStringManager.GetConfig("LifeRecord_language", "Name_786"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_786"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(787, LocalStringManager.GetConfig("LifeRecord_language", "Name_787"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_787"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(788, LocalStringManager.GetConfig("LifeRecord_language", "Name_788"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_788"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(789, LocalStringManager.GetConfig("LifeRecord_language", "Name_789"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_789"), new string[6] { "Settlement", "Float", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(790, LocalStringManager.GetConfig("LifeRecord_language", "Name_790"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_790"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(791, LocalStringManager.GetConfig("LifeRecord_language", "Name_791"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_791"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(792, LocalStringManager.GetConfig("LifeRecord_language", "Name_792"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_792"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(793, LocalStringManager.GetConfig("LifeRecord_language", "Name_793"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_793"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(794, LocalStringManager.GetConfig("LifeRecord_language", "Name_794"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_794"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(795, LocalStringManager.GetConfig("LifeRecord_language", "Name_795"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_795"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(796, LocalStringManager.GetConfig("LifeRecord_language", "Name_796"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_796"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(797, LocalStringManager.GetConfig("LifeRecord_language", "Name_797"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_797"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(798, LocalStringManager.GetConfig("LifeRecord_language", "Name_798"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_798"), new string[6] { "Settlement", "Float", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(799, LocalStringManager.GetConfig("LifeRecord_language", "Name_799"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_799"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(800, LocalStringManager.GetConfig("LifeRecord_language", "Name_800"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_800"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(801, LocalStringManager.GetConfig("LifeRecord_language", "Name_801"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_801"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(802, LocalStringManager.GetConfig("LifeRecord_language", "Name_802"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_802"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(803, LocalStringManager.GetConfig("LifeRecord_language", "Name_803"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_803"), new string[6] { "Settlement", "Float", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(804, LocalStringManager.GetConfig("LifeRecord_language", "Name_804"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_804"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(805, LocalStringManager.GetConfig("LifeRecord_language", "Name_805"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_805"), new string[6] { "Settlement", "Resource", "Integer", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 80, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(806, LocalStringManager.GetConfig("LifeRecord_language", "Name_806"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_806"), new string[6] { "Settlement", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 80, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(807, LocalStringManager.GetConfig("LifeRecord_language", "Name_807"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_807"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(808, LocalStringManager.GetConfig("LifeRecord_language", "Name_808"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_808"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(809, LocalStringManager.GetConfig("LifeRecord_language", "Name_809"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_809"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(810, LocalStringManager.GetConfig("LifeRecord_language", "Name_810"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_810"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(811, LocalStringManager.GetConfig("LifeRecord_language", "Name_811"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_811"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 813 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(812, LocalStringManager.GetConfig("LifeRecord_language", "Name_812"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_812"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 813 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(813, LocalStringManager.GetConfig("LifeRecord_language", "Name_813"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_813"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 811, 812 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(814, LocalStringManager.GetConfig("LifeRecord_language", "Name_814"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_814"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(815, LocalStringManager.GetConfig("LifeRecord_language", "Name_815"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_815"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(816, LocalStringManager.GetConfig("LifeRecord_language", "Name_816"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_816"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(817, LocalStringManager.GetConfig("LifeRecord_language", "Name_817"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_817"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(818, LocalStringManager.GetConfig("LifeRecord_language", "Name_818"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_818"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 820 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(819, LocalStringManager.GetConfig("LifeRecord_language", "Name_819"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_819"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 820 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(820, LocalStringManager.GetConfig("LifeRecord_language", "Name_820"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_820"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 818, 819 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(821, LocalStringManager.GetConfig("LifeRecord_language", "Name_821"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_821"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(822, LocalStringManager.GetConfig("LifeRecord_language", "Name_822"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_822"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(823, LocalStringManager.GetConfig("LifeRecord_language", "Name_823"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_823"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 824 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(824, LocalStringManager.GetConfig("LifeRecord_language", "Name_824"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_824"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 823 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(825, LocalStringManager.GetConfig("LifeRecord_language", "Name_825"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_825"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 826 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(826, LocalStringManager.GetConfig("LifeRecord_language", "Name_826"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_826"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 825 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(827, LocalStringManager.GetConfig("LifeRecord_language", "Name_827"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_827"), new string[6] { "Item", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(828, LocalStringManager.GetConfig("LifeRecord_language", "Name_828"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_828"), new string[6] { "Item", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(829, LocalStringManager.GetConfig("LifeRecord_language", "Name_829"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_829"), new string[6] { "Item", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(830, LocalStringManager.GetConfig("LifeRecord_language", "Name_830"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_830"), new string[6] { "Character", "Location", "SecretInformation", "", "", "" }, isSourceRecord: true, new List<short> { 831 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(831, LocalStringManager.GetConfig("LifeRecord_language", "Name_831"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_831"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 830 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(832, LocalStringManager.GetConfig("LifeRecord_language", "Name_832"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_832"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(833, LocalStringManager.GetConfig("LifeRecord_language", "Name_833"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_833"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(834, LocalStringManager.GetConfig("LifeRecord_language", "Name_834"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_834"), new string[6] { "Location", "PunishmentType", "Settlement", "Location", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(835, LocalStringManager.GetConfig("LifeRecord_language", "Name_835"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_835"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(836, LocalStringManager.GetConfig("LifeRecord_language", "Name_836"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_836"), new string[6] { "Location", "PunishmentType", "Settlement", "Settlement", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(837, LocalStringManager.GetConfig("LifeRecord_language", "Name_837"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_837"), new string[6] { "Location", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(838, LocalStringManager.GetConfig("LifeRecord_language", "Name_838"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_838"), new string[6] { "Location", "Settlement", "OrgGrade", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(839, LocalStringManager.GetConfig("LifeRecord_language", "Name_839"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_839"), new string[6] { "Character", "Location", "Settlement", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
	}

	private void CreateItems14()
	{
		_dataArray.Add(new LifeRecordItem(840, LocalStringManager.GetConfig("LifeRecord_language", "Name_840"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_840"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(841, LocalStringManager.GetConfig("LifeRecord_language", "Name_841"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_841"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(842, LocalStringManager.GetConfig("LifeRecord_language", "Name_842"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_842"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(843, LocalStringManager.GetConfig("LifeRecord_language", "Name_843"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_843"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(844, LocalStringManager.GetConfig("LifeRecord_language", "Name_844"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_844"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(845, LocalStringManager.GetConfig("LifeRecord_language", "Name_845"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_845"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(846, LocalStringManager.GetConfig("LifeRecord_language", "Name_846"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_846"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(847, LocalStringManager.GetConfig("LifeRecord_language", "Name_847"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_847"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(848, LocalStringManager.GetConfig("LifeRecord_language", "Name_848"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_848"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(849, LocalStringManager.GetConfig("LifeRecord_language", "Name_849"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_849"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(850, LocalStringManager.GetConfig("LifeRecord_language", "Name_850"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_850"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(851, LocalStringManager.GetConfig("LifeRecord_language", "Name_851"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_851"), new string[6] { "Settlement", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(852, LocalStringManager.GetConfig("LifeRecord_language", "Name_852"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_852"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(853, LocalStringManager.GetConfig("LifeRecord_language", "Name_853"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_853"), new string[6] { "Settlement", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(854, LocalStringManager.GetConfig("LifeRecord_language", "Name_854"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_854"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(855, LocalStringManager.GetConfig("LifeRecord_language", "Name_855"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_855"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(856, LocalStringManager.GetConfig("LifeRecord_language", "Name_856"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_856"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(857, LocalStringManager.GetConfig("LifeRecord_language", "Name_857"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_857"), new string[6] { "Settlement", "BodyPartType", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(858, LocalStringManager.GetConfig("LifeRecord_language", "Name_858"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_858"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(859, LocalStringManager.GetConfig("LifeRecord_language", "Name_859"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_859"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(860, LocalStringManager.GetConfig("LifeRecord_language", "Name_860"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_860"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(861, LocalStringManager.GetConfig("LifeRecord_language", "Name_861"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_861"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(862, LocalStringManager.GetConfig("LifeRecord_language", "Name_862"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_862"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(863, LocalStringManager.GetConfig("LifeRecord_language", "Name_863"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_863"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(864, LocalStringManager.GetConfig("LifeRecord_language", "Name_864"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_864"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 865 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(865, LocalStringManager.GetConfig("LifeRecord_language", "Name_865"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_865"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short> { 864 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(866, LocalStringManager.GetConfig("LifeRecord_language", "Name_866"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_866"), new string[6] { "Character", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(867, LocalStringManager.GetConfig("LifeRecord_language", "Name_867"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_867"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(868, LocalStringManager.GetConfig("LifeRecord_language", "Name_868"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_868"), new string[6] { "Character", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(869, LocalStringManager.GetConfig("LifeRecord_language", "Name_869"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_869"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(870, LocalStringManager.GetConfig("LifeRecord_language", "Name_870"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_870"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 871 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(871, LocalStringManager.GetConfig("LifeRecord_language", "Name_871"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_871"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short> { 870 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(872, LocalStringManager.GetConfig("LifeRecord_language", "Name_872"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_872"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(873, LocalStringManager.GetConfig("LifeRecord_language", "Name_873"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_873"), new string[6] { "Character", "Character", "Settlement", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(874, LocalStringManager.GetConfig("LifeRecord_language", "Name_874"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_874"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(875, LocalStringManager.GetConfig("LifeRecord_language", "Name_875"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_875"), new string[6] { "Character", "Character", "Settlement", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(876, LocalStringManager.GetConfig("LifeRecord_language", "Name_876"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_876"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(877, LocalStringManager.GetConfig("LifeRecord_language", "Name_877"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_877"), new string[6] { "Character", "Character", "Settlement", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(878, LocalStringManager.GetConfig("LifeRecord_language", "Name_878"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_878"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(879, LocalStringManager.GetConfig("LifeRecord_language", "Name_879"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_879"), new string[6] { "Character", "Character", "Settlement", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(880, LocalStringManager.GetConfig("LifeRecord_language", "Name_880"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_880"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(881, LocalStringManager.GetConfig("LifeRecord_language", "Name_881"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_881"), new string[6] { "Character", "Character", "Settlement", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(882, LocalStringManager.GetConfig("LifeRecord_language", "Name_882"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_882"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(883, LocalStringManager.GetConfig("LifeRecord_language", "Name_883"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_883"), new string[6] { "Character", "Character", "Settlement", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(884, LocalStringManager.GetConfig("LifeRecord_language", "Name_884"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_884"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(885, LocalStringManager.GetConfig("LifeRecord_language", "Name_885"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_885"), new string[6] { "Character", "Location", "Settlement", "", "", "" }, isSourceRecord: true, new List<short> { 886, 1035 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(886, LocalStringManager.GetConfig("LifeRecord_language", "Name_886"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_886"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 885 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(887, LocalStringManager.GetConfig("LifeRecord_language", "Name_887"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_887"), new string[6] { "Character", "Character", "Location", "Settlement", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(888, LocalStringManager.GetConfig("LifeRecord_language", "Name_888"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_888"), new string[6] { "Character", "Location", "Settlement", "", "", "" }, isSourceRecord: true, new List<short> { 889, 1036 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(889, LocalStringManager.GetConfig("LifeRecord_language", "Name_889"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_889"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 888 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(890, LocalStringManager.GetConfig("LifeRecord_language", "Name_890"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_890"), new string[6] { "Character", "Character", "Settlement", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(891, LocalStringManager.GetConfig("LifeRecord_language", "Name_891"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_891"), new string[6] { "Character", "Character", "Settlement", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(892, LocalStringManager.GetConfig("LifeRecord_language", "Name_892"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_892"), new string[6] { "Character", "Character", "Settlement", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(893, LocalStringManager.GetConfig("LifeRecord_language", "Name_893"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_893"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 894 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(894, LocalStringManager.GetConfig("LifeRecord_language", "Name_894"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_894"), new string[6] { "Character", "Character", "Settlement", "Resource", "Integer", "" }, isSourceRecord: true, new List<short> { 893 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(895, LocalStringManager.GetConfig("LifeRecord_language", "Name_895"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_895"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 896 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(896, LocalStringManager.GetConfig("LifeRecord_language", "Name_896"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_896"), new string[6] { "Character", "Character", "Settlement", "", "", "" }, isSourceRecord: true, new List<short> { 895 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(897, LocalStringManager.GetConfig("LifeRecord_language", "Name_897"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_897"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 898 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(898, LocalStringManager.GetConfig("LifeRecord_language", "Name_898"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_898"), new string[6] { "Character", "Character", "Settlement", "", "", "" }, isSourceRecord: true, new List<short> { 897 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(899, LocalStringManager.GetConfig("LifeRecord_language", "Name_899"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_899"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 900 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Combat));
	}

	private void CreateItems15()
	{
		_dataArray.Add(new LifeRecordItem(900, LocalStringManager.GetConfig("LifeRecord_language", "Name_900"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_900"), new string[6] { "Character", "Character", "Settlement", "", "", "" }, isSourceRecord: true, new List<short> { 899 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(901, LocalStringManager.GetConfig("LifeRecord_language", "Name_901"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_901"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 902 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(902, LocalStringManager.GetConfig("LifeRecord_language", "Name_902"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_902"), new string[6] { "Character", "Character", "Settlement", "", "", "" }, isSourceRecord: true, new List<short> { 901 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(903, LocalStringManager.GetConfig("LifeRecord_language", "Name_903"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_903"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(904, LocalStringManager.GetConfig("LifeRecord_language", "Name_904"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_904"), new string[6] { "Location", "Resource", "Integer", "Resource", "Integer", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(905, LocalStringManager.GetConfig("LifeRecord_language", "Name_905"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_905"), new string[6] { "Location", "Resource", "Integer", "Resource", "Integer", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(906, LocalStringManager.GetConfig("LifeRecord_language", "Name_906"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_906"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(907, LocalStringManager.GetConfig("LifeRecord_language", "Name_907"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_907"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(908, LocalStringManager.GetConfig("LifeRecord_language", "Name_908"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_908"), new string[6] { "PunishmentType", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(909, LocalStringManager.GetConfig("LifeRecord_language", "Name_909"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_909"), new string[6] { "PunishmentType", "Settlement", "Integer", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(910, LocalStringManager.GetConfig("LifeRecord_language", "Name_910"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_910"), new string[6] { "PunishmentType", "Settlement", "Integer", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 20, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(911, LocalStringManager.GetConfig("LifeRecord_language", "Name_911"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_911"), new string[6] { "PunishmentType", "Settlement", "Integer", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 10, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(912, LocalStringManager.GetConfig("LifeRecord_language", "Name_912"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_912"), new string[6] { "PunishmentType", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 0, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(913, LocalStringManager.GetConfig("LifeRecord_language", "Name_913"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_913"), new string[6] { "PunishmentType", "Settlement", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 0, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(914, LocalStringManager.GetConfig("LifeRecord_language", "Name_914"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_914"), new string[6] { "PunishmentType", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(915, LocalStringManager.GetConfig("LifeRecord_language", "Name_915"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_915"), new string[6] { "PunishmentType", "Settlement", "Integer", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(916, LocalStringManager.GetConfig("LifeRecord_language", "Name_916"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_916"), new string[6] { "PunishmentType", "Settlement", "Integer", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 20, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(917, LocalStringManager.GetConfig("LifeRecord_language", "Name_917"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_917"), new string[6] { "PunishmentType", "Settlement", "Integer", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 10, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(918, LocalStringManager.GetConfig("LifeRecord_language", "Name_918"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_918"), new string[6] { "PunishmentType", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 0, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(919, LocalStringManager.GetConfig("LifeRecord_language", "Name_919"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_919"), new string[6] { "PunishmentType", "Settlement", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 0, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(920, LocalStringManager.GetConfig("LifeRecord_language", "Name_920"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_920"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 0, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(921, LocalStringManager.GetConfig("LifeRecord_language", "Name_921"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_921"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(922, LocalStringManager.GetConfig("LifeRecord_language", "Name_922"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_922"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(923, LocalStringManager.GetConfig("LifeRecord_language", "Name_923"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_923"), new string[6] { "Character", "Settlement", "Resource", "Integer", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(924, LocalStringManager.GetConfig("LifeRecord_language", "Name_924"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_924"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(925, LocalStringManager.GetConfig("LifeRecord_language", "Name_925"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_925"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(926, LocalStringManager.GetConfig("LifeRecord_language", "Name_926"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_926"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short> { 927 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(927, LocalStringManager.GetConfig("LifeRecord_language", "Name_927"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_927"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 926 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(928, LocalStringManager.GetConfig("LifeRecord_language", "Name_928"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_928"), new string[6] { "Character", "Location", "Settlement", "", "", "" }, isSourceRecord: true, new List<short> { 929 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(929, LocalStringManager.GetConfig("LifeRecord_language", "Name_929"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_929"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 928 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(930, LocalStringManager.GetConfig("LifeRecord_language", "Name_930"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_930"), new string[6] { "Character", "Location", "Settlement", "", "", "" }, isSourceRecord: true, new List<short> { 931 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(931, LocalStringManager.GetConfig("LifeRecord_language", "Name_931"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_931"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 930 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(932, LocalStringManager.GetConfig("LifeRecord_language", "Name_932"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_932"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 933 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(933, LocalStringManager.GetConfig("LifeRecord_language", "Name_933"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_933"), new string[6] { "Character", "Character", "Settlement", "Integer", "", "" }, isSourceRecord: true, new List<short> { 932 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(934, LocalStringManager.GetConfig("LifeRecord_language", "Name_934"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_934"), new string[6] { "Character", "Settlement", "Integer", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(935, LocalStringManager.GetConfig("LifeRecord_language", "Name_935"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_935"), new string[6] { "Location", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(936, LocalStringManager.GetConfig("LifeRecord_language", "Name_936"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_936"), new string[6] { "Location", "Item", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(937, LocalStringManager.GetConfig("LifeRecord_language", "Name_937"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_937"), new string[6] { "Location", "Item", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(938, LocalStringManager.GetConfig("LifeRecord_language", "Name_938"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_938"), new string[6] { "Location", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(939, LocalStringManager.GetConfig("LifeRecord_language", "Name_939"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_939"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 960 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(940, LocalStringManager.GetConfig("LifeRecord_language", "Name_940"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_940"), new string[6] { "Location", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(941, LocalStringManager.GetConfig("LifeRecord_language", "Name_941"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_941"), new string[6] { "Location", "Item", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(942, LocalStringManager.GetConfig("LifeRecord_language", "Name_942"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_942"), new string[6] { "Location", "Item", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(943, LocalStringManager.GetConfig("LifeRecord_language", "Name_943"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_943"), new string[6] { "Location", "Item", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(944, LocalStringManager.GetConfig("LifeRecord_language", "Name_944"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_944"), new string[6] { "Location", "Item", "Item", "Item", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(945, LocalStringManager.GetConfig("LifeRecord_language", "Name_945"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_945"), new string[6] { "Location", "Item", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(946, LocalStringManager.GetConfig("LifeRecord_language", "Name_946"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_946"), new string[6] { "Character", "Location", "Item", "Resource", "Integer", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(947, LocalStringManager.GetConfig("LifeRecord_language", "Name_947"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_947"), new string[6] { "Character", "Location", "Item", "Resource", "Integer", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(948, LocalStringManager.GetConfig("LifeRecord_language", "Name_948"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_948"), new string[6] { "Character", "Character", "Location", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(949, LocalStringManager.GetConfig("LifeRecord_language", "Name_949"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_949"), new string[6] { "Character", "Character", "Location", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(950, LocalStringManager.GetConfig("LifeRecord_language", "Name_950"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_950"), new string[6] { "Character", "Character", "Location", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(951, LocalStringManager.GetConfig("LifeRecord_language", "Name_951"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_951"), new string[6] { "Character", "Character", "Location", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(952, LocalStringManager.GetConfig("LifeRecord_language", "Name_952"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_952"), new string[6] { "Character", "Character", "Location", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(953, LocalStringManager.GetConfig("LifeRecord_language", "Name_953"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_953"), new string[6] { "Character", "Character", "Location", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(954, LocalStringManager.GetConfig("LifeRecord_language", "Name_954"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_954"), new string[6] { "Character", "Location", "Integer", "Resource", "", "" }, isSourceRecord: true, new List<short> { 956 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(955, LocalStringManager.GetConfig("LifeRecord_language", "Name_955"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_955"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 957 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(956, LocalStringManager.GetConfig("LifeRecord_language", "Name_956"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_956"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 954 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(957, LocalStringManager.GetConfig("LifeRecord_language", "Name_957"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_957"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 955 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(958, LocalStringManager.GetConfig("LifeRecord_language", "Name_958"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_958"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(959, LocalStringManager.GetConfig("LifeRecord_language", "Name_959"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_959"), new string[6] { "Location", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Great));
	}

	private void CreateItems16()
	{
		_dataArray.Add(new LifeRecordItem(960, LocalStringManager.GetConfig("LifeRecord_language", "Name_960"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_960"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 939 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(961, LocalStringManager.GetConfig("LifeRecord_language", "Name_961"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_961"), new string[6] { "Item", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(962, LocalStringManager.GetConfig("LifeRecord_language", "Name_962"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_962"), new string[6] { "Item", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(963, LocalStringManager.GetConfig("LifeRecord_language", "Name_963"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_963"), new string[6] { "Integer", "Resource", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(964, LocalStringManager.GetConfig("LifeRecord_language", "Name_964"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_964"), new string[6] { "Integer", "Resource", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(965, LocalStringManager.GetConfig("LifeRecord_language", "Name_965"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_965"), new string[6] { "Location", "Integer", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(966, LocalStringManager.GetConfig("LifeRecord_language", "Name_966"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_966"), new string[6] { "Location", "Integer", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(967, LocalStringManager.GetConfig("LifeRecord_language", "Name_967"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_967"), new string[6] { "Location", "Integer", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(968, LocalStringManager.GetConfig("LifeRecord_language", "Name_968"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_968"), new string[6] { "Location", "Integer", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(969, LocalStringManager.GetConfig("LifeRecord_language", "Name_969"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_969"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(970, LocalStringManager.GetConfig("LifeRecord_language", "Name_970"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_970"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(971, LocalStringManager.GetConfig("LifeRecord_language", "Name_971"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_971"), new string[6] { "Location", "Integer", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(972, LocalStringManager.GetConfig("LifeRecord_language", "Name_972"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_972"), new string[6] { "Location", "Integer", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(973, LocalStringManager.GetConfig("LifeRecord_language", "Name_973"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_973"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(974, LocalStringManager.GetConfig("LifeRecord_language", "Name_974"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_974"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(975, LocalStringManager.GetConfig("LifeRecord_language", "Name_975"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_975"), new string[6] { "SwordTomb", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(976, LocalStringManager.GetConfig("LifeRecord_language", "Name_976"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_976"), new string[6] { "CharacterTemplate", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(977, LocalStringManager.GetConfig("LifeRecord_language", "Name_977"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_977"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(978, LocalStringManager.GetConfig("LifeRecord_language", "Name_978"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_978"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(979, LocalStringManager.GetConfig("LifeRecord_language", "Name_979"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_979"), new string[6] { "Location", "Item", "Item", "Item", "Item", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(980, LocalStringManager.GetConfig("LifeRecord_language", "Name_980"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_980"), new string[6] { "Location", "Item", "Item", "Item", "Item", "Item" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(981, LocalStringManager.GetConfig("LifeRecord_language", "Name_981"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_981"), new string[6] { "Location", "Item", "Item", "Item", "Item", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(982, LocalStringManager.GetConfig("LifeRecord_language", "Name_982"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_982"), new string[6] { "Location", "Item", "Item", "Item", "Item", "Item" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(983, LocalStringManager.GetConfig("LifeRecord_language", "Name_983"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_983"), new string[6] { "Location", "Building", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(984, LocalStringManager.GetConfig("LifeRecord_language", "Name_984"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_984"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(985, LocalStringManager.GetConfig("LifeRecord_language", "Name_985"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_985"), new string[6] { "Location", "Building", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(986, LocalStringManager.GetConfig("LifeRecord_language", "Name_986"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_986"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(987, LocalStringManager.GetConfig("LifeRecord_language", "Name_987"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_987"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(988, LocalStringManager.GetConfig("LifeRecord_language", "Name_988"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_988"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(989, LocalStringManager.GetConfig("LifeRecord_language", "Name_989"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_989"), new string[6] { "Location", "Building", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(990, LocalStringManager.GetConfig("LifeRecord_language", "Name_990"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_990"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(991, LocalStringManager.GetConfig("LifeRecord_language", "Name_991"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_991"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(992, LocalStringManager.GetConfig("LifeRecord_language", "Name_992"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_992"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(993, LocalStringManager.GetConfig("LifeRecord_language", "Name_993"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_993"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(994, LocalStringManager.GetConfig("LifeRecord_language", "Name_994"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_994"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(995, LocalStringManager.GetConfig("LifeRecord_language", "Name_995"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_995"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(996, LocalStringManager.GetConfig("LifeRecord_language", "Name_996"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_996"), new string[6] { "Location", "LifeSkillType", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(997, LocalStringManager.GetConfig("LifeRecord_language", "Name_997"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_997"), new string[6] { "Settlement", "Integer", "Location", "Integer", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(998, LocalStringManager.GetConfig("LifeRecord_language", "Name_998"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_998"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(999, LocalStringManager.GetConfig("LifeRecord_language", "Name_999"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_999"), new string[6] { "Integer", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(1000, LocalStringManager.GetConfig("LifeRecord_language", "Name_1000"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1000"), new string[6] { "Integer", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(1001, LocalStringManager.GetConfig("LifeRecord_language", "Name_1001"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1001"), new string[6] { "Integer", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(1002, LocalStringManager.GetConfig("LifeRecord_language", "Name_1002"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1002"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(1003, LocalStringManager.GetConfig("LifeRecord_language", "Name_1003"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1003"), new string[6] { "Integer", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(1004, LocalStringManager.GetConfig("LifeRecord_language", "Name_1004"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1004"), new string[6] { "Integer", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(1005, LocalStringManager.GetConfig("LifeRecord_language", "Name_1005"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1005"), new string[6] { "Integer", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(1006, LocalStringManager.GetConfig("LifeRecord_language", "Name_1006"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1006"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(1007, LocalStringManager.GetConfig("LifeRecord_language", "Name_1007"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1007"), new string[6] { "Integer", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(1008, LocalStringManager.GetConfig("LifeRecord_language", "Name_1008"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1008"), new string[6] { "Integer", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(1009, LocalStringManager.GetConfig("LifeRecord_language", "Name_1009"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1009"), new string[6] { "Integer", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(1010, LocalStringManager.GetConfig("LifeRecord_language", "Name_1010"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1010"), new string[6] { "Integer", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(1011, LocalStringManager.GetConfig("LifeRecord_language", "Name_1011"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1011"), new string[6] { "Integer", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(1012, LocalStringManager.GetConfig("LifeRecord_language", "Name_1012"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1012"), new string[6] { "Integer", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(1013, LocalStringManager.GetConfig("LifeRecord_language", "Name_1013"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1013"), new string[6] { "PunishmentType", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 0, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(1014, LocalStringManager.GetConfig("LifeRecord_language", "Name_1014"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1014"), new string[6] { "Character", "Settlement", "Integer", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 0, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(1015, LocalStringManager.GetConfig("LifeRecord_language", "Name_1015"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1015"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 0, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(1016, LocalStringManager.GetConfig("LifeRecord_language", "Name_1016"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1016"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1017, LocalStringManager.GetConfig("LifeRecord_language", "Name_1017"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1017"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1018, LocalStringManager.GetConfig("LifeRecord_language", "Name_1018"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1018"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1019, LocalStringManager.GetConfig("LifeRecord_language", "Name_1019"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1019"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
	}

	private void CreateItems17()
	{
		_dataArray.Add(new LifeRecordItem(1020, LocalStringManager.GetConfig("LifeRecord_language", "Name_1020"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1020"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1021, LocalStringManager.GetConfig("LifeRecord_language", "Name_1021"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1021"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1022, LocalStringManager.GetConfig("LifeRecord_language", "Name_1022"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1022"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1023, LocalStringManager.GetConfig("LifeRecord_language", "Name_1023"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1023"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 1024 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1024, LocalStringManager.GetConfig("LifeRecord_language", "Name_1024"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1024"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 1023 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1025, LocalStringManager.GetConfig("LifeRecord_language", "Name_1025"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1025"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1026, LocalStringManager.GetConfig("LifeRecord_language", "Name_1026"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1026"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1027, LocalStringManager.GetConfig("LifeRecord_language", "Name_1027"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1027"), new string[6] { "Character", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(1028, LocalStringManager.GetConfig("LifeRecord_language", "Name_1028"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1028"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 1029 }, -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(1029, LocalStringManager.GetConfig("LifeRecord_language", "Name_1029"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1029"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 1028 }, -30000, ELifeRecordScoreType.Normal, 0, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(1030, LocalStringManager.GetConfig("LifeRecord_language", "Name_1030"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1030"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 1031 }, -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(1031, LocalStringManager.GetConfig("LifeRecord_language", "Name_1031"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1031"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 1030 }, -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(1032, LocalStringManager.GetConfig("LifeRecord_language", "Name_1032"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1032"), new string[6] { "Character", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(1033, LocalStringManager.GetConfig("LifeRecord_language", "Name_1033"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1033"), new string[6] { "Character", "", "", "", "", "" }, isSourceRecord: true, new List<short> { 1034 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(1034, LocalStringManager.GetConfig("LifeRecord_language", "Name_1034"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1034"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 1033 }, -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(1035, LocalStringManager.GetConfig("LifeRecord_language", "Name_1035"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1035"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 885 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(1036, LocalStringManager.GetConfig("LifeRecord_language", "Name_1036"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1036"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 888 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(1037, LocalStringManager.GetConfig("LifeRecord_language", "Name_1037"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1037"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 1038 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1038, LocalStringManager.GetConfig("LifeRecord_language", "Name_1038"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1038"), new string[6] { "Character", "", "", "", "", "" }, isSourceRecord: true, new List<short> { 1037 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1039, LocalStringManager.GetConfig("LifeRecord_language", "Name_1039"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1039"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 1040 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1040, LocalStringManager.GetConfig("LifeRecord_language", "Name_1040"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1040"), new string[6] { "Character", "", "", "", "", "" }, isSourceRecord: true, new List<short> { 1039 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1041, LocalStringManager.GetConfig("LifeRecord_language", "Name_1041"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1041"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 1042 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1042, LocalStringManager.GetConfig("LifeRecord_language", "Name_1042"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1042"), new string[6] { "Character", "Integer", "", "", "", "" }, isSourceRecord: true, new List<short> { 1041 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1043, LocalStringManager.GetConfig("LifeRecord_language", "Name_1043"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1043"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 1044 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1044, LocalStringManager.GetConfig("LifeRecord_language", "Name_1044"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1044"), new string[6] { "Character", "Integer", "", "", "", "" }, isSourceRecord: true, new List<short> { 1043 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1045, LocalStringManager.GetConfig("LifeRecord_language", "Name_1045"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1045"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 1046 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1046, LocalStringManager.GetConfig("LifeRecord_language", "Name_1046"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1046"), new string[6] { "Character", "Integer", "", "", "", "" }, isSourceRecord: true, new List<short> { 1045 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1047, LocalStringManager.GetConfig("LifeRecord_language", "Name_1047"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1047"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short> { 1048 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1048, LocalStringManager.GetConfig("LifeRecord_language", "Name_1048"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1048"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 1047 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1049, LocalStringManager.GetConfig("LifeRecord_language", "Name_1049"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1049"), new string[6] { "Location", "Character", "Profession", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1050, LocalStringManager.GetConfig("LifeRecord_language", "Name_1050"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1050"), new string[6] { "Item", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1051, LocalStringManager.GetConfig("LifeRecord_language", "Name_1051"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1051"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 1052 }, -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1052, LocalStringManager.GetConfig("LifeRecord_language", "Name_1052"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1052"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 1051 }, -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1053, LocalStringManager.GetConfig("LifeRecord_language", "Name_1053"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1053"), new string[6] { "CombatSkill", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1054, LocalStringManager.GetConfig("LifeRecord_language", "Name_1054"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1054"), new string[6] { "CombatSkill", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1055, LocalStringManager.GetConfig("LifeRecord_language", "Name_1055"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1055"), new string[6] { "CombatSkill", "Character", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1056, LocalStringManager.GetConfig("LifeRecord_language", "Name_1056"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1056"), new string[6] { "CombatSkill", "Character", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1057, LocalStringManager.GetConfig("LifeRecord_language", "Name_1057"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1057"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(1058, LocalStringManager.GetConfig("LifeRecord_language", "Name_1058"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1058"), new string[6] { "Location", "Character", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(1059, LocalStringManager.GetConfig("LifeRecord_language", "Name_1059"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1059"), new string[6] { "Location", "Character", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(1060, LocalStringManager.GetConfig("LifeRecord_language", "Name_1060"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1060"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1061, LocalStringManager.GetConfig("LifeRecord_language", "Name_1061"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1061"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1062, LocalStringManager.GetConfig("LifeRecord_language", "Name_1062"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1062"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1063, LocalStringManager.GetConfig("LifeRecord_language", "Name_1063"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1063"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1064, LocalStringManager.GetConfig("LifeRecord_language", "Name_1064"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1064"), new string[6] { "Item", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1065, LocalStringManager.GetConfig("LifeRecord_language", "Name_1065"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1065"), new string[6] { "Item", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1066, LocalStringManager.GetConfig("LifeRecord_language", "Name_1066"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1066"), new string[6] { "Character", "Location", "Integer", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1067, LocalStringManager.GetConfig("LifeRecord_language", "Name_1067"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1067"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1068, LocalStringManager.GetConfig("LifeRecord_language", "Name_1068"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1068"), new string[6] { "Character", "Resource", "Integer", "", "", "" }, isSourceRecord: true, new List<short> { 1069 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1069, LocalStringManager.GetConfig("LifeRecord_language", "Name_1069"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1069"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 1068 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1070, LocalStringManager.GetConfig("LifeRecord_language", "Name_1070"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1070"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 947 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1071, LocalStringManager.GetConfig("LifeRecord_language", "Name_1071"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1071"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 946 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1072, LocalStringManager.GetConfig("LifeRecord_language", "Name_1072"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1072"), new string[6] { "Character", "Location", "MerchantType", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1073, LocalStringManager.GetConfig("LifeRecord_language", "Name_1073"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1073"), new string[6] { "Character", "Location", "MerchantType", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1074, LocalStringManager.GetConfig("LifeRecord_language", "Name_1074"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1074"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1075, LocalStringManager.GetConfig("LifeRecord_language", "Name_1075"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1075"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1076, LocalStringManager.GetConfig("LifeRecord_language", "Name_1076"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1076"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1077, LocalStringManager.GetConfig("LifeRecord_language", "Name_1077"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1077"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1078, LocalStringManager.GetConfig("LifeRecord_language", "Name_1078"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1078"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1079, LocalStringManager.GetConfig("LifeRecord_language", "Name_1079"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1079"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
	}

	private void CreateItems18()
	{
		_dataArray.Add(new LifeRecordItem(1080, LocalStringManager.GetConfig("LifeRecord_language", "Name_1080"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1080"), new string[6] { "Settlement", "Integer", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1081, LocalStringManager.GetConfig("LifeRecord_language", "Name_1081"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1081"), new string[6] { "Settlement", "Integer", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1082, LocalStringManager.GetConfig("LifeRecord_language", "Name_1082"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1082"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1083, LocalStringManager.GetConfig("LifeRecord_language", "Name_1083"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1083"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1084, LocalStringManager.GetConfig("LifeRecord_language", "Name_1084"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1084"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1085, LocalStringManager.GetConfig("LifeRecord_language", "Name_1085"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1085"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1086, LocalStringManager.GetConfig("LifeRecord_language", "Name_1086"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1086"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(1087, LocalStringManager.GetConfig("LifeRecord_language", "Name_1087"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1087"), new string[6] { "CharacterTemplate", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 80, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(1088, LocalStringManager.GetConfig("LifeRecord_language", "Name_1088"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1088"), new string[6] { "Character", "Character", "Location", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1089, LocalStringManager.GetConfig("LifeRecord_language", "Name_1089"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1089"), new string[6] { "Character", "Character", "Location", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1090, LocalStringManager.GetConfig("LifeRecord_language", "Name_1090"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1090"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 1092 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1091, LocalStringManager.GetConfig("LifeRecord_language", "Name_1091"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1091"), new string[6] { "Character", "Item", "", "", "", "" }, isSourceRecord: true, new List<short> { 1093 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1092, LocalStringManager.GetConfig("LifeRecord_language", "Name_1092"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1092"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 1090 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1093, LocalStringManager.GetConfig("LifeRecord_language", "Name_1093"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1093"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 1091 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1094, LocalStringManager.GetConfig("LifeRecord_language", "Name_1094"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1094"), new string[6] { "Character", "Character", "", "", "", "" }, isSourceRecord: true, new List<short> { 1095 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1095, LocalStringManager.GetConfig("LifeRecord_language", "Name_1095"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1095"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 1094 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1096, LocalStringManager.GetConfig("LifeRecord_language", "Name_1096"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1096"), new string[6] { "Character", "Character", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1097, LocalStringManager.GetConfig("LifeRecord_language", "Name_1097"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1097"), new string[6] { "Character", "Character", "Location", "", "", "" }, isSourceRecord: true, new List<short> { 1098 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1098, LocalStringManager.GetConfig("LifeRecord_language", "Name_1098"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1098"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 1097 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1099, LocalStringManager.GetConfig("LifeRecord_language", "Name_1099"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1099"), new string[6] { "Character", "Character", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 1100 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1100, LocalStringManager.GetConfig("LifeRecord_language", "Name_1100"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1100"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 1099 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1101, LocalStringManager.GetConfig("LifeRecord_language", "Name_1101"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1101"), new string[6] { "Item", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1102, LocalStringManager.GetConfig("LifeRecord_language", "Name_1102"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1102"), new string[6] { "Building", "LifeSkillType", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1103, LocalStringManager.GetConfig("LifeRecord_language", "Name_1103"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1103"), new string[6] { "Building", "CombatSkillType", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1104, LocalStringManager.GetConfig("LifeRecord_language", "Name_1104"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1104"), new string[6] { "Building", "LifeSkillType", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1105, LocalStringManager.GetConfig("LifeRecord_language", "Name_1105"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1105"), new string[6] { "Building", "CombatSkillType", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1106, LocalStringManager.GetConfig("LifeRecord_language", "Name_1106"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1106"), new string[6] { "Character", "Building", "LifeSkillType", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1107, LocalStringManager.GetConfig("LifeRecord_language", "Name_1107"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1107"), new string[6] { "Character", "Building", "CombatSkillType", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1108, LocalStringManager.GetConfig("LifeRecord_language", "Name_1108"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1108"), new string[6] { "Building", "Item", "Integer", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1109, LocalStringManager.GetConfig("LifeRecord_language", "Name_1109"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1109"), new string[6] { "Building", "Item", "Integer", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1110, LocalStringManager.GetConfig("LifeRecord_language", "Name_1110"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1110"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1111, LocalStringManager.GetConfig("LifeRecord_language", "Name_1111"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1111"), new string[6] { "Item", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1112, LocalStringManager.GetConfig("LifeRecord_language", "Name_1112"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1112"), new string[6] { "Building", "Integer", "Resource", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1113, LocalStringManager.GetConfig("LifeRecord_language", "Name_1113"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1113"), new string[6] { "Location", "OrgGrade", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1114, LocalStringManager.GetConfig("LifeRecord_language", "Name_1114"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1114"), new string[6] { "Location", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1115, LocalStringManager.GetConfig("LifeRecord_language", "Name_1115"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1115"), new string[6] { "Settlement", "OrgGrade", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1116, LocalStringManager.GetConfig("LifeRecord_language", "Name_1116"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1116"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1117, LocalStringManager.GetConfig("LifeRecord_language", "Name_1117"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1117"), new string[6] { "Settlement", "Settlement", "OrgGrade", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1118, LocalStringManager.GetConfig("LifeRecord_language", "Name_1118"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1118"), new string[6] { "Character", "Character", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1119, LocalStringManager.GetConfig("LifeRecord_language", "Name_1119"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1119"), new string[6] { "Character", "Character", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1120, LocalStringManager.GetConfig("LifeRecord_language", "Name_1120"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1120"), new string[6] { "Character", "Character", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1121, LocalStringManager.GetConfig("LifeRecord_language", "Name_1121"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1121"), new string[6] { "Character", "Character", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1122, LocalStringManager.GetConfig("LifeRecord_language", "Name_1122"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1122"), new string[6] { "Location", "Character", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1123, LocalStringManager.GetConfig("LifeRecord_language", "Name_1123"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1123"), new string[6] { "Location", "Character", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1124, LocalStringManager.GetConfig("LifeRecord_language", "Name_1124"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1124"), new string[6] { "Location", "Character", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1125, LocalStringManager.GetConfig("LifeRecord_language", "Name_1125"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1125"), new string[6] { "Location", "Character", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1126, LocalStringManager.GetConfig("LifeRecord_language", "Name_1126"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1126"), new string[6] { "Location", "Character", "Location", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1127, LocalStringManager.GetConfig("LifeRecord_language", "Name_1127"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1127"), new string[6] { "Location", "Character", "Location", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1128, LocalStringManager.GetConfig("LifeRecord_language", "Name_1128"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1128"), new string[6] { "Location", "Character", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1129, LocalStringManager.GetConfig("LifeRecord_language", "Name_1129"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1129"), new string[6] { "Location", "Character", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1130, LocalStringManager.GetConfig("LifeRecord_language", "Name_1130"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1130"), new string[6] { "Location", "Character", "Location", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1131, LocalStringManager.GetConfig("LifeRecord_language", "Name_1131"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1131"), new string[6] { "Settlement", "Character", "Settlement", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1132, LocalStringManager.GetConfig("LifeRecord_language", "Name_1132"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1132"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 0, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(1133, LocalStringManager.GetConfig("LifeRecord_language", "Name_1133"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1133"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 0, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(1134, LocalStringManager.GetConfig("LifeRecord_language", "Name_1134"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1134"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(1135, LocalStringManager.GetConfig("LifeRecord_language", "Name_1135"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1135"), new string[6] { "Item", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1136, LocalStringManager.GetConfig("LifeRecord_language", "Name_1136"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1136"), new string[6] { "Item", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 65, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1137, LocalStringManager.GetConfig("LifeRecord_language", "Name_1137"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1137"), new string[6] { "Item", "Item", "Feast", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1138, LocalStringManager.GetConfig("LifeRecord_language", "Name_1138"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1138"), new string[6] { "Item", "Item", "Feast", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 75, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1139, LocalStringManager.GetConfig("LifeRecord_language", "Name_1139"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1139"), new string[6] { "Item", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 55, -1, ELifeRecordDisplayType.Relation));
	}

	private void CreateItems19()
	{
		_dataArray.Add(new LifeRecordItem(1140, LocalStringManager.GetConfig("LifeRecord_language", "Name_1140"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1140"), new string[6] { "Item", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1141, LocalStringManager.GetConfig("LifeRecord_language", "Name_1141"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1141"), new string[6] { "Item", "Item", "Feast", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 65, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1142, LocalStringManager.GetConfig("LifeRecord_language", "Name_1142"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1142"), new string[6] { "Item", "Item", "Feast", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1143, LocalStringManager.GetConfig("LifeRecord_language", "Name_1143"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1143"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1144, LocalStringManager.GetConfig("LifeRecord_language", "Name_1144"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1144"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1145, LocalStringManager.GetConfig("LifeRecord_language", "Name_1145"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1145"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(1146, LocalStringManager.GetConfig("LifeRecord_language", "Name_1146"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1146"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(1147, LocalStringManager.GetConfig("LifeRecord_language", "Name_1147"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1147"), new string[6] { "Character", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1148, LocalStringManager.GetConfig("LifeRecord_language", "Name_1148"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1148"), new string[6] { "Settlement", "Character", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1149, LocalStringManager.GetConfig("LifeRecord_language", "Name_1149"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1149"), new string[6] { "Settlement", "Character", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1150, LocalStringManager.GetConfig("LifeRecord_language", "Name_1150"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1150"), new string[6] { "Settlement", "Character", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1151, LocalStringManager.GetConfig("LifeRecord_language", "Name_1151"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1151"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(1152, LocalStringManager.GetConfig("LifeRecord_language", "Name_1152"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1152"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(1153, LocalStringManager.GetConfig("LifeRecord_language", "Name_1153"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1153"), new string[6] { "Character", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 80, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(1154, LocalStringManager.GetConfig("LifeRecord_language", "Name_1154"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1154"), new string[6] { "Character", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 80, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(1155, LocalStringManager.GetConfig("LifeRecord_language", "Name_1155"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1155"), new string[6] { "SecretInformation", "Character", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1156, LocalStringManager.GetConfig("LifeRecord_language", "Name_1156"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1156"), new string[6] { "SecretInformation", "Character", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1157, LocalStringManager.GetConfig("LifeRecord_language", "Name_1157"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1157"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1158, LocalStringManager.GetConfig("LifeRecord_language", "Name_1158"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1158"), new string[6] { "Location", "CombatSkillType", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1159, LocalStringManager.GetConfig("LifeRecord_language", "Name_1159"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1159"), new string[6] { "Location", "PersonalityType", "CombatSkillType", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1160, LocalStringManager.GetConfig("LifeRecord_language", "Name_1160"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1160"), new string[6] { "Character", "Location", "CombatSkillType", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1161, LocalStringManager.GetConfig("LifeRecord_language", "Name_1161"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1161"), new string[6] { "Location", "LifeSkillType", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1162, LocalStringManager.GetConfig("LifeRecord_language", "Name_1162"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1162"), new string[6] { "Location", "PersonalityType", "LifeSkillType", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1163, LocalStringManager.GetConfig("LifeRecord_language", "Name_1163"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1163"), new string[6] { "Character", "Location", "LifeSkillType", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1164, LocalStringManager.GetConfig("LifeRecord_language", "Name_1164"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1164"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1165, LocalStringManager.GetConfig("LifeRecord_language", "Name_1165"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1165"), new string[6] { "Location", "CharacterTemplate", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(1166, LocalStringManager.GetConfig("LifeRecord_language", "Name_1166"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1166"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1167, LocalStringManager.GetConfig("LifeRecord_language", "Name_1167"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1167"), new string[6] { "Location", "CombatSkill", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1168, LocalStringManager.GetConfig("LifeRecord_language", "Name_1168"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1168"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1169, LocalStringManager.GetConfig("LifeRecord_language", "Name_1169"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1169"), new string[6] { "Location", "LifeSkillType", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1170, LocalStringManager.GetConfig("LifeRecord_language", "Name_1170"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1170"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1171, LocalStringManager.GetConfig("LifeRecord_language", "Name_1171"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1171"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1172, LocalStringManager.GetConfig("LifeRecord_language", "Name_1172"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1172"), new string[6] { "Location", "Integer", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1173, LocalStringManager.GetConfig("LifeRecord_language", "Name_1173"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1173"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1174, LocalStringManager.GetConfig("LifeRecord_language", "Name_1174"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1174"), new string[6] { "Location", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1175, LocalStringManager.GetConfig("LifeRecord_language", "Name_1175"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1175"), new string[6] { "Character", "Location", "Settlement", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(1176, LocalStringManager.GetConfig("LifeRecord_language", "Name_1176"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1176"), new string[6] { "Location", "Integer", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1177, LocalStringManager.GetConfig("LifeRecord_language", "Name_1177"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1177"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1178, LocalStringManager.GetConfig("LifeRecord_language", "Name_1178"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1178"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1179, LocalStringManager.GetConfig("LifeRecord_language", "Name_1179"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1179"), new string[6] { "Location", "Integer", "Resource", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1180, LocalStringManager.GetConfig("LifeRecord_language", "Name_1180"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1180"), new string[6] { "Location", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1181, LocalStringManager.GetConfig("LifeRecord_language", "Name_1181"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1181"), new string[6] { "Location", "Integer", "Resource", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1182, LocalStringManager.GetConfig("LifeRecord_language", "Name_1182"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1182"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(1183, LocalStringManager.GetConfig("LifeRecord_language", "Name_1183"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1183"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1184, LocalStringManager.GetConfig("LifeRecord_language", "Name_1184"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1184"), new string[6] { "Location", "Integer", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1185, LocalStringManager.GetConfig("LifeRecord_language", "Name_1185"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1185"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1186, LocalStringManager.GetConfig("LifeRecord_language", "Name_1186"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1186"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1187, LocalStringManager.GetConfig("LifeRecord_language", "Name_1187"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1187"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1188, LocalStringManager.GetConfig("LifeRecord_language", "Name_1188"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1188"), new string[6] { "Location", "LifeSkillType", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1189, LocalStringManager.GetConfig("LifeRecord_language", "Name_1189"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1189"), new string[6] { "Location", "Integer", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1190, LocalStringManager.GetConfig("LifeRecord_language", "Name_1190"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1190"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1191, LocalStringManager.GetConfig("LifeRecord_language", "Name_1191"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1191"), new string[6] { "Location", "CombatSkill", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1192, LocalStringManager.GetConfig("LifeRecord_language", "Name_1192"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1192"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1193, LocalStringManager.GetConfig("LifeRecord_language", "Name_1193"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1193"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1194, LocalStringManager.GetConfig("LifeRecord_language", "Name_1194"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1194"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(1195, LocalStringManager.GetConfig("LifeRecord_language", "Name_1195"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1195"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 1384 }, -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1196, LocalStringManager.GetConfig("LifeRecord_language", "Name_1196"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1196"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1197, LocalStringManager.GetConfig("LifeRecord_language", "Name_1197"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1197"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1198, LocalStringManager.GetConfig("LifeRecord_language", "Name_1198"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1198"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1199, LocalStringManager.GetConfig("LifeRecord_language", "Name_1199"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1199"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
	}

	private void CreateItems20()
	{
		_dataArray.Add(new LifeRecordItem(1200, LocalStringManager.GetConfig("LifeRecord_language", "Name_1200"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1200"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1201, LocalStringManager.GetConfig("LifeRecord_language", "Name_1201"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1201"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1202, LocalStringManager.GetConfig("LifeRecord_language", "Name_1202"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1202"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1203, LocalStringManager.GetConfig("LifeRecord_language", "Name_1203"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1203"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1204, LocalStringManager.GetConfig("LifeRecord_language", "Name_1204"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1204"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1205, LocalStringManager.GetConfig("LifeRecord_language", "Name_1205"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1205"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1206, LocalStringManager.GetConfig("LifeRecord_language", "Name_1206"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1206"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(1207, LocalStringManager.GetConfig("LifeRecord_language", "Name_1207"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1207"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1208, LocalStringManager.GetConfig("LifeRecord_language", "Name_1208"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1208"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1209, LocalStringManager.GetConfig("LifeRecord_language", "Name_1209"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1209"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(1210, LocalStringManager.GetConfig("LifeRecord_language", "Name_1210"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1210"), new string[6] { "Character", "Location", "Integer", "Item", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1211, LocalStringManager.GetConfig("LifeRecord_language", "Name_1211"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1211"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1212, LocalStringManager.GetConfig("LifeRecord_language", "Name_1212"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1212"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1213, LocalStringManager.GetConfig("LifeRecord_language", "Name_1213"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1213"), new string[6] { "Character", "Location", "Integer", "Item", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1214, LocalStringManager.GetConfig("LifeRecord_language", "Name_1214"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1214"), new string[6] { "Character", "Location", "Integer", "Item", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1215, LocalStringManager.GetConfig("LifeRecord_language", "Name_1215"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1215"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1216, LocalStringManager.GetConfig("LifeRecord_language", "Name_1216"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1216"), new string[6] { "Character", "Location", "Integer", "Item", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1217, LocalStringManager.GetConfig("LifeRecord_language", "Name_1217"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1217"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1218, LocalStringManager.GetConfig("LifeRecord_language", "Name_1218"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1218"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.NoCategory));
		_dataArray.Add(new LifeRecordItem(1219, LocalStringManager.GetConfig("LifeRecord_language", "Name_1219"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1219"), new string[6] { "Character", "Location", "CombatSkill", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1220, LocalStringManager.GetConfig("LifeRecord_language", "Name_1220"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1220"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(1221, LocalStringManager.GetConfig("LifeRecord_language", "Name_1221"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1221"), new string[6] { "Character", "Location", "Integer", "Item", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1222, LocalStringManager.GetConfig("LifeRecord_language", "Name_1222"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1222"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1223, LocalStringManager.GetConfig("LifeRecord_language", "Name_1223"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1223"), new string[6] { "Character", "Location", "Integer", "Item", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1224, LocalStringManager.GetConfig("LifeRecord_language", "Name_1224"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1224"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1225, LocalStringManager.GetConfig("LifeRecord_language", "Name_1225"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1225"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1226, LocalStringManager.GetConfig("LifeRecord_language", "Name_1226"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1226"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1227, LocalStringManager.GetConfig("LifeRecord_language", "Name_1227"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1227"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1228, LocalStringManager.GetConfig("LifeRecord_language", "Name_1228"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1228"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1229, LocalStringManager.GetConfig("LifeRecord_language", "Name_1229"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1229"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1230, LocalStringManager.GetConfig("LifeRecord_language", "Name_1230"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1230"), new string[6] { "Location", "CombatSkill", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1231, LocalStringManager.GetConfig("LifeRecord_language", "Name_1231"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1231"), new string[6] { "Location", "Integer", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1232, LocalStringManager.GetConfig("LifeRecord_language", "Name_1232"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1232"), new string[6] { "Location", "Integer", "Item", "Integer", "Item", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1233, LocalStringManager.GetConfig("LifeRecord_language", "Name_1233"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1233"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1234, LocalStringManager.GetConfig("LifeRecord_language", "Name_1234"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1234"), new string[6] { "Character", "Location", "Integer", "Item", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1235, LocalStringManager.GetConfig("LifeRecord_language", "Name_1235"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1235"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(1236, LocalStringManager.GetConfig("LifeRecord_language", "Name_1236"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1236"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(1237, LocalStringManager.GetConfig("LifeRecord_language", "Name_1237"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1237"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1238, LocalStringManager.GetConfig("LifeRecord_language", "Name_1238"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1238"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1239, LocalStringManager.GetConfig("LifeRecord_language", "Name_1239"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1239"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.NoCategory));
		_dataArray.Add(new LifeRecordItem(1240, LocalStringManager.GetConfig("LifeRecord_language", "Name_1240"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1240"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1241, LocalStringManager.GetConfig("LifeRecord_language", "Name_1241"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1241"), new string[6] { "Location", "CombatSkill", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1242, LocalStringManager.GetConfig("LifeRecord_language", "Name_1242"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1242"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.NoCategory));
		_dataArray.Add(new LifeRecordItem(1243, LocalStringManager.GetConfig("LifeRecord_language", "Name_1243"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1243"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1244, LocalStringManager.GetConfig("LifeRecord_language", "Name_1244"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1244"), new string[6] { "Character", "Location", "Integer", "Item", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1245, LocalStringManager.GetConfig("LifeRecord_language", "Name_1245"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1245"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1246, LocalStringManager.GetConfig("LifeRecord_language", "Name_1246"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1246"), new string[6] { "Location", "Integer", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1247, LocalStringManager.GetConfig("LifeRecord_language", "Name_1247"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1247"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1248, LocalStringManager.GetConfig("LifeRecord_language", "Name_1248"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1248"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1249, LocalStringManager.GetConfig("LifeRecord_language", "Name_1249"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1249"), new string[6] { "Location", "Integer", "Resource", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1250, LocalStringManager.GetConfig("LifeRecord_language", "Name_1250"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1250"), new string[6] { "Location", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1251, LocalStringManager.GetConfig("LifeRecord_language", "Name_1251"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1251"), new string[6] { "Location", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1252, LocalStringManager.GetConfig("LifeRecord_language", "Name_1252"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1252"), new string[6] { "Location", "CombatSkill", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1253, LocalStringManager.GetConfig("LifeRecord_language", "Name_1253"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1253"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1254, LocalStringManager.GetConfig("LifeRecord_language", "Name_1254"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1254"), new string[6] { "Character", "Location", "Integer", "Item", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1255, LocalStringManager.GetConfig("LifeRecord_language", "Name_1255"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1255"), new string[6] { "Location", "Integer", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1256, LocalStringManager.GetConfig("LifeRecord_language", "Name_1256"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1256"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1257, LocalStringManager.GetConfig("LifeRecord_language", "Name_1257"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1257"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1258, LocalStringManager.GetConfig("LifeRecord_language", "Name_1258"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1258"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1259, LocalStringManager.GetConfig("LifeRecord_language", "Name_1259"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1259"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Produce));
	}

	private void CreateItems21()
	{
		_dataArray.Add(new LifeRecordItem(1260, LocalStringManager.GetConfig("LifeRecord_language", "Name_1260"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1260"), new string[6] { "Location", "LifeSkillType", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1261, LocalStringManager.GetConfig("LifeRecord_language", "Name_1261"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1261"), new string[6] { "Location", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1262, LocalStringManager.GetConfig("LifeRecord_language", "Name_1262"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1262"), new string[6] { "Location", "LifeSkillType", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1263, LocalStringManager.GetConfig("LifeRecord_language", "Name_1263"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1263"), new string[6] { "Location", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1264, LocalStringManager.GetConfig("LifeRecord_language", "Name_1264"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1264"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1265, LocalStringManager.GetConfig("LifeRecord_language", "Name_1265"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1265"), new string[6] { "Character", "Location", "Integer", "Item", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1266, LocalStringManager.GetConfig("LifeRecord_language", "Name_1266"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1266"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1267, LocalStringManager.GetConfig("LifeRecord_language", "Name_1267"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1267"), new string[6] { "Character", "Location", "Integer", "Item", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1268, LocalStringManager.GetConfig("LifeRecord_language", "Name_1268"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1268"), new string[6] { "Character", "Location", "CombatSkill", "", "", "" }, isSourceRecord: true, new List<short> { 1390 }, -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1269, LocalStringManager.GetConfig("LifeRecord_language", "Name_1269"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1269"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1270, LocalStringManager.GetConfig("LifeRecord_language", "Name_1270"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1270"), new string[6] { "Character", "Location", "CombatSkill", "", "", "" }, isSourceRecord: true, new List<short> { 1391 }, -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1271, LocalStringManager.GetConfig("LifeRecord_language", "Name_1271"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1271"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1272, LocalStringManager.GetConfig("LifeRecord_language", "Name_1272"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1272"), new string[6] { "Location", "Integer", "Resource", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1273, LocalStringManager.GetConfig("LifeRecord_language", "Name_1273"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1273"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1274, LocalStringManager.GetConfig("LifeRecord_language", "Name_1274"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1274"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(1275, LocalStringManager.GetConfig("LifeRecord_language", "Name_1275"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1275"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1276, LocalStringManager.GetConfig("LifeRecord_language", "Name_1276"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1276"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1277, LocalStringManager.GetConfig("LifeRecord_language", "Name_1277"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1277"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(1278, LocalStringManager.GetConfig("LifeRecord_language", "Name_1278"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1278"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(1279, LocalStringManager.GetConfig("LifeRecord_language", "Name_1279"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1279"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(1280, LocalStringManager.GetConfig("LifeRecord_language", "Name_1280"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1280"), new string[6] { "Location", "Settlement", "Settlement", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(1281, LocalStringManager.GetConfig("LifeRecord_language", "Name_1281"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1281"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(1282, LocalStringManager.GetConfig("LifeRecord_language", "Name_1282"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1282"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(1283, LocalStringManager.GetConfig("LifeRecord_language", "Name_1283"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1283"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1284, LocalStringManager.GetConfig("LifeRecord_language", "Name_1284"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1284"), new string[6] { "Character", "Location", "CombatSkill", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1285, LocalStringManager.GetConfig("LifeRecord_language", "Name_1285"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1285"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1286, LocalStringManager.GetConfig("LifeRecord_language", "Name_1286"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1286"), new string[6] { "Character", "Location", "Integer", "Item", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1287, LocalStringManager.GetConfig("LifeRecord_language", "Name_1287"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1287"), new string[6] { "Location", "Settlement", "Settlement", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1288, LocalStringManager.GetConfig("LifeRecord_language", "Name_1288"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1288"), new string[6] { "Location", "Integer", "Resource", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1289, LocalStringManager.GetConfig("LifeRecord_language", "Name_1289"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1289"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1290, LocalStringManager.GetConfig("LifeRecord_language", "Name_1290"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1290"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1291, LocalStringManager.GetConfig("LifeRecord_language", "Name_1291"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1291"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1292, LocalStringManager.GetConfig("LifeRecord_language", "Name_1292"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1292"), new string[6] { "Character", "Location", "Integer", "Item", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1293, LocalStringManager.GetConfig("LifeRecord_language", "Name_1293"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1293"), new string[6] { "Character", "Location", "Integer", "Item", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1294, LocalStringManager.GetConfig("LifeRecord_language", "Name_1294"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1294"), new string[6] { "Location", "CombatSkill", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1295, LocalStringManager.GetConfig("LifeRecord_language", "Name_1295"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1295"), new string[6] { "Location", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1296, LocalStringManager.GetConfig("LifeRecord_language", "Name_1296"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1296"), new string[6] { "Location", "SecretInformation", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1297, LocalStringManager.GetConfig("LifeRecord_language", "Name_1297"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1297"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1298, LocalStringManager.GetConfig("LifeRecord_language", "Name_1298"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1298"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short> { 1392 }, -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(1299, LocalStringManager.GetConfig("LifeRecord_language", "Name_1299"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1299"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1300, LocalStringManager.GetConfig("LifeRecord_language", "Name_1300"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1300"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1301, LocalStringManager.GetConfig("LifeRecord_language", "Name_1301"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1301"), new string[6] { "Character", "Character", "Location", "Item", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(1302, LocalStringManager.GetConfig("LifeRecord_language", "Name_1302"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1302"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(1303, LocalStringManager.GetConfig("LifeRecord_language", "Name_1303"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1303"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(1304, LocalStringManager.GetConfig("LifeRecord_language", "Name_1304"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1304"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1305, LocalStringManager.GetConfig("LifeRecord_language", "Name_1305"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1305"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(1306, LocalStringManager.GetConfig("LifeRecord_language", "Name_1306"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1306"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1307, LocalStringManager.GetConfig("LifeRecord_language", "Name_1307"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1307"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1308, LocalStringManager.GetConfig("LifeRecord_language", "Name_1308"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1308"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1309, LocalStringManager.GetConfig("LifeRecord_language", "Name_1309"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1309"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1310, LocalStringManager.GetConfig("LifeRecord_language", "Name_1310"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1310"), new string[6] { "Character", "Location", "Integer", "Item", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1311, LocalStringManager.GetConfig("LifeRecord_language", "Name_1311"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1311"), new string[6] { "Location", "CombatSkill", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1312, LocalStringManager.GetConfig("LifeRecord_language", "Name_1312"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1312"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1313, LocalStringManager.GetConfig("LifeRecord_language", "Name_1313"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1313"), new string[6] { "Character", "Location", "CombatSkill", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1314, LocalStringManager.GetConfig("LifeRecord_language", "Name_1314"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1314"), new string[6] { "Location", "Integer", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1315, LocalStringManager.GetConfig("LifeRecord_language", "Name_1315"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1315"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1316, LocalStringManager.GetConfig("LifeRecord_language", "Name_1316"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1316"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1317, LocalStringManager.GetConfig("LifeRecord_language", "Name_1317"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1317"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(1318, LocalStringManager.GetConfig("LifeRecord_language", "Name_1318"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1318"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(1319, LocalStringManager.GetConfig("LifeRecord_language", "Name_1319"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1319"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Crime));
	}

	private void CreateItems22()
	{
		_dataArray.Add(new LifeRecordItem(1320, LocalStringManager.GetConfig("LifeRecord_language", "Name_1320"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1320"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(1321, LocalStringManager.GetConfig("LifeRecord_language", "Name_1321"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1321"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(1322, LocalStringManager.GetConfig("LifeRecord_language", "Name_1322"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1322"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(1323, LocalStringManager.GetConfig("LifeRecord_language", "Name_1323"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1323"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1324, LocalStringManager.GetConfig("LifeRecord_language", "Name_1324"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1324"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(1325, LocalStringManager.GetConfig("LifeRecord_language", "Name_1325"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1325"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1326, LocalStringManager.GetConfig("LifeRecord_language", "Name_1326"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1326"), new string[6] { "Character", "Location", "Integer", "Item", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1327, LocalStringManager.GetConfig("LifeRecord_language", "Name_1327"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1327"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1328, LocalStringManager.GetConfig("LifeRecord_language", "Name_1328"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1328"), new string[6] { "Character", "Location", "CombatSkill", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1329, LocalStringManager.GetConfig("LifeRecord_language", "Name_1329"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1329"), new string[6] { "Location", "Integer", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1330, LocalStringManager.GetConfig("LifeRecord_language", "Name_1330"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1330"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1331, LocalStringManager.GetConfig("LifeRecord_language", "Name_1331"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1331"), new string[6] { "Character", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1332, LocalStringManager.GetConfig("LifeRecord_language", "Name_1332"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1332"), new string[6] { "Character", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1333, LocalStringManager.GetConfig("LifeRecord_language", "Name_1333"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1333"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1334, LocalStringManager.GetConfig("LifeRecord_language", "Name_1334"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1334"), new string[6] { "Character", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1335, LocalStringManager.GetConfig("LifeRecord_language", "Name_1335"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1335"), new string[6] { "Character", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1336, LocalStringManager.GetConfig("LifeRecord_language", "Name_1336"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1336"), new string[6] { "Location", "MerchantType", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1337, LocalStringManager.GetConfig("LifeRecord_language", "Name_1337"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1337"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1338, LocalStringManager.GetConfig("LifeRecord_language", "Name_1338"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1338"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1339, LocalStringManager.GetConfig("LifeRecord_language", "Name_1339"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1339"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1340, LocalStringManager.GetConfig("LifeRecord_language", "Name_1340"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1340"), new string[6] { "Character", "Location", "Settlement", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1341, LocalStringManager.GetConfig("LifeRecord_language", "Name_1341"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1341"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1342, LocalStringManager.GetConfig("LifeRecord_language", "Name_1342"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1342"), new string[6] { "Character", "Location", "Settlement", "Item", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1343, LocalStringManager.GetConfig("LifeRecord_language", "Name_1343"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1343"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1344, LocalStringManager.GetConfig("LifeRecord_language", "Name_1344"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1344"), new string[6] { "Character", "Location", "Settlement", "Integer", "Item", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1345, LocalStringManager.GetConfig("LifeRecord_language", "Name_1345"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1345"), new string[6] { "Location", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1346, LocalStringManager.GetConfig("LifeRecord_language", "Name_1346"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1346"), new string[6] { "Character", "Location", "Settlement", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1347, LocalStringManager.GetConfig("LifeRecord_language", "Name_1347"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1347"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1348, LocalStringManager.GetConfig("LifeRecord_language", "Name_1348"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1348"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1349, LocalStringManager.GetConfig("LifeRecord_language", "Name_1349"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1349"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1350, LocalStringManager.GetConfig("LifeRecord_language", "Name_1350"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1350"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1351, LocalStringManager.GetConfig("LifeRecord_language", "Name_1351"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1351"), new string[6] { "Location", "MerchantType", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1352, LocalStringManager.GetConfig("LifeRecord_language", "Name_1352"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1352"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1353, LocalStringManager.GetConfig("LifeRecord_language", "Name_1353"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1353"), new string[6] { "Location", "Integer", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1354, LocalStringManager.GetConfig("LifeRecord_language", "Name_1354"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1354"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.NoCategory));
		_dataArray.Add(new LifeRecordItem(1355, LocalStringManager.GetConfig("LifeRecord_language", "Name_1355"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1355"), new string[6] { "Location", "Integer", "Resource", "MerchantType", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1356, LocalStringManager.GetConfig("LifeRecord_language", "Name_1356"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1356"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.NoCategory));
		_dataArray.Add(new LifeRecordItem(1357, LocalStringManager.GetConfig("LifeRecord_language", "Name_1357"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1357"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.NoCategory));
		_dataArray.Add(new LifeRecordItem(1358, LocalStringManager.GetConfig("LifeRecord_language", "Name_1358"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1358"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.NoCategory));
		_dataArray.Add(new LifeRecordItem(1359, LocalStringManager.GetConfig("LifeRecord_language", "Name_1359"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1359"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.NoCategory));
		_dataArray.Add(new LifeRecordItem(1360, LocalStringManager.GetConfig("LifeRecord_language", "Name_1360"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1360"), new string[6] { "Location", "Integer", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1361, LocalStringManager.GetConfig("LifeRecord_language", "Name_1361"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1361"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.NoCategory));
		_dataArray.Add(new LifeRecordItem(1362, LocalStringManager.GetConfig("LifeRecord_language", "Name_1362"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1362"), new string[6] { "Character", "Location", "SecretInformationTemplate", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1363, LocalStringManager.GetConfig("LifeRecord_language", "Name_1363"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1363"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1364, LocalStringManager.GetConfig("LifeRecord_language", "Name_1364"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1364"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 1402 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1365, LocalStringManager.GetConfig("LifeRecord_language", "Name_1365"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1365"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 1403 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1366, LocalStringManager.GetConfig("LifeRecord_language", "Name_1366"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1366"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1367, LocalStringManager.GetConfig("LifeRecord_language", "Name_1367"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1367"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1368, LocalStringManager.GetConfig("LifeRecord_language", "Name_1368"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1368"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1369, LocalStringManager.GetConfig("LifeRecord_language", "Name_1369"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1369"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1370, LocalStringManager.GetConfig("LifeRecord_language", "Name_1370"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1370"), new string[6] { "Location", "Resource", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1371, LocalStringManager.GetConfig("LifeRecord_language", "Name_1371"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1371"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1372, LocalStringManager.GetConfig("LifeRecord_language", "Name_1372"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1372"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1373, LocalStringManager.GetConfig("LifeRecord_language", "Name_1373"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1373"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1374, LocalStringManager.GetConfig("LifeRecord_language", "Name_1374"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1374"), new string[6] { "Location", "JiaoLoong", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1375, LocalStringManager.GetConfig("LifeRecord_language", "Name_1375"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1375"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1376, LocalStringManager.GetConfig("LifeRecord_language", "Name_1376"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1376"), new string[6] { "Character", "Location", "Integer", "Item", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1377, LocalStringManager.GetConfig("LifeRecord_language", "Name_1377"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1377"), new string[6] { "Location", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1378, LocalStringManager.GetConfig("LifeRecord_language", "Name_1378"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1378"), new string[6] { "Character", "Location", "Integer", "Item", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1379, LocalStringManager.GetConfig("LifeRecord_language", "Name_1379"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1379"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
	}

	private void CreateItems23()
	{
		_dataArray.Add(new LifeRecordItem(1380, LocalStringManager.GetConfig("LifeRecord_language", "Name_1380"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1380"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1381, LocalStringManager.GetConfig("LifeRecord_language", "Name_1381"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1381"), new string[6] { "Character", "Location", "Integer", "Item", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1382, LocalStringManager.GetConfig("LifeRecord_language", "Name_1382"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1382"), new string[6] { "Character", "Location", "Integer", "Item", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1383, LocalStringManager.GetConfig("LifeRecord_language", "Name_1383"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1383"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(1384, LocalStringManager.GetConfig("LifeRecord_language", "Name_1384"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1384"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 1195 }, -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(1385, LocalStringManager.GetConfig("LifeRecord_language", "Name_1385"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1385"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(1386, LocalStringManager.GetConfig("LifeRecord_language", "Name_1386"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1386"), new string[6] { "Location", "Character", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 20, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(1387, LocalStringManager.GetConfig("LifeRecord_language", "Name_1387"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1387"), new string[6] { "Location", "Character", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 20, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(1388, LocalStringManager.GetConfig("LifeRecord_language", "Name_1388"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1388"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.NoCategory));
		_dataArray.Add(new LifeRecordItem(1389, LocalStringManager.GetConfig("LifeRecord_language", "Name_1389"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1389"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1390, LocalStringManager.GetConfig("LifeRecord_language", "Name_1390"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1390"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 1268 }, -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1391, LocalStringManager.GetConfig("LifeRecord_language", "Name_1391"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1391"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 1270 }, -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1392, LocalStringManager.GetConfig("LifeRecord_language", "Name_1392"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1392"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 1298 }, -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(1393, LocalStringManager.GetConfig("LifeRecord_language", "Name_1393"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1393"), new string[6] { "Location", "Character", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(1394, LocalStringManager.GetConfig("LifeRecord_language", "Name_1394"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1394"), new string[6] { "Location", "Character", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(1395, LocalStringManager.GetConfig("LifeRecord_language", "Name_1395"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1395"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(1396, LocalStringManager.GetConfig("LifeRecord_language", "Name_1396"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1396"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(1397, LocalStringManager.GetConfig("LifeRecord_language", "Name_1397"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1397"), new string[6] { "Location", "Character", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(1398, LocalStringManager.GetConfig("LifeRecord_language", "Name_1398"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1398"), new string[6] { "Location", "CharacterTemplate", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(1399, LocalStringManager.GetConfig("LifeRecord_language", "Name_1399"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1399"), new string[6] { "Location", "CharacterTemplate", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(1400, LocalStringManager.GetConfig("LifeRecord_language", "Name_1400"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1400"), new string[6] { "Location", "Character", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(1401, LocalStringManager.GetConfig("LifeRecord_language", "Name_1401"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1401"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 1401 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1402, LocalStringManager.GetConfig("LifeRecord_language", "Name_1402"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1402"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 1364 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1403, LocalStringManager.GetConfig("LifeRecord_language", "Name_1403"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1403"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 1365 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1404, LocalStringManager.GetConfig("LifeRecord_language", "Name_1404"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1404"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 80, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1405, LocalStringManager.GetConfig("LifeRecord_language", "Name_1405"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1405"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 1406 }, -30000, ELifeRecordScoreType.Normal, 90, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(1406, LocalStringManager.GetConfig("LifeRecord_language", "Name_1406"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1406"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 1405 }, -30000, ELifeRecordScoreType.Normal, 20, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(1407, LocalStringManager.GetConfig("LifeRecord_language", "Name_1407"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1407"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 90, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(1408, LocalStringManager.GetConfig("LifeRecord_language", "Name_1408"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1408"), new string[6] { "Location", "Integer", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 100, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(1409, LocalStringManager.GetConfig("LifeRecord_language", "Name_1409"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1409"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 100, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(1410, LocalStringManager.GetConfig("LifeRecord_language", "Name_1410"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1410"), new string[6] { "Cricket", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(1411, LocalStringManager.GetConfig("LifeRecord_language", "Name_1411"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1411"), new string[6] { "Cricket", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(1412, LocalStringManager.GetConfig("LifeRecord_language", "Name_1412"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1412"), new string[6] { "Location", "Adventure", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1413, LocalStringManager.GetConfig("LifeRecord_language", "Name_1413"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1413"), new string[6] { "Location", "Adventure", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1414, LocalStringManager.GetConfig("LifeRecord_language", "Name_1414"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1414"), new string[6] { "OrgGrade", "OrgGrade", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Relation));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<LifeRecordItem>(1415);
		CreateItems0();
		CreateItems1();
		CreateItems2();
		CreateItems3();
		CreateItems4();
		CreateItems5();
		CreateItems6();
		CreateItems7();
		CreateItems8();
		CreateItems9();
		CreateItems10();
		CreateItems11();
		CreateItems12();
		CreateItems13();
		CreateItems14();
		CreateItems15();
		CreateItems16();
		CreateItems17();
		CreateItems18();
		CreateItems19();
		CreateItems20();
		CreateItems21();
		CreateItems22();
		CreateItems23();
	}
}
