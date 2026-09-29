using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class CharacterMatcher : ConfigData<CharacterMatcherItem, short>
{
	public static class DefKey
	{
		public const short CanInteractAsIntelligentCharacter = 0;

		public const short NonBabyAndCanBeLocaated = 82;

		public const short CanWork = 1;

		public const short CanAdoptChild = 2;

		public const short CanBeRevengeTarget = 3;

		public const short CanPerformInfectedAction = 4;

		public const short CanReceiveSecretInformation = 5;

		public const short JuniorXiangshuFollowingCharacter = 6;

		public const short CanStartSexRelation = 8;

		public const short CanBeUndertaker = 9;

		public const short AvailableForLegendaryBookAdventure = 10;

		public const short PrepareCharacterForSpiritualWanderPlace = 11;

		public const short CanHaveBounty = 12;

		public const short CanBeAttackedByInfectedCharacter = 13;

		public const short CanBeAttackedByRandomEnemy = 14;

		public const short CanBeRemovedFromGroup = 15;

		public const short CanBeMerchantAutoActionTarget = 16;

		public const short CanBeJixiKillingTarget = 17;

		public const short VillagerAvailableForWork = 18;

		public const short ChildVillagerAvailableForWork = 7;

		public const short InteractWithShixiangMemberEventTarget = 19;

		public const short EmeiPotentialVictims = 20;

		public const short CanMakeAppointment = 53;

		public const short InSettlement = 55;

		public const short CanJoinFeast = 56;

		public const short CanBeJixiDrainTarget = 57;

		public const short CanBeSelectJixiDrainTarget = 58;
	}

	public static class DefValue
	{
		public static CharacterMatcherItem CanInteractAsIntelligentCharacter => Instance[(short)0];

		public static CharacterMatcherItem NonBabyAndCanBeLocaated => Instance[(short)82];

		public static CharacterMatcherItem CanWork => Instance[(short)1];

		public static CharacterMatcherItem CanAdoptChild => Instance[(short)2];

		public static CharacterMatcherItem CanBeRevengeTarget => Instance[(short)3];

		public static CharacterMatcherItem CanPerformInfectedAction => Instance[(short)4];

		public static CharacterMatcherItem CanReceiveSecretInformation => Instance[(short)5];

		public static CharacterMatcherItem JuniorXiangshuFollowingCharacter => Instance[(short)6];

		public static CharacterMatcherItem CanStartSexRelation => Instance[(short)8];

		public static CharacterMatcherItem CanBeUndertaker => Instance[(short)9];

		public static CharacterMatcherItem AvailableForLegendaryBookAdventure => Instance[(short)10];

		public static CharacterMatcherItem PrepareCharacterForSpiritualWanderPlace => Instance[(short)11];

		public static CharacterMatcherItem CanHaveBounty => Instance[(short)12];

		public static CharacterMatcherItem CanBeAttackedByInfectedCharacter => Instance[(short)13];

		public static CharacterMatcherItem CanBeAttackedByRandomEnemy => Instance[(short)14];

		public static CharacterMatcherItem CanBeRemovedFromGroup => Instance[(short)15];

		public static CharacterMatcherItem CanBeMerchantAutoActionTarget => Instance[(short)16];

		public static CharacterMatcherItem CanBeJixiKillingTarget => Instance[(short)17];

		public static CharacterMatcherItem VillagerAvailableForWork => Instance[(short)18];

		public static CharacterMatcherItem ChildVillagerAvailableForWork => Instance[(short)7];

		public static CharacterMatcherItem InteractWithShixiangMemberEventTarget => Instance[(short)19];

		public static CharacterMatcherItem EmeiPotentialVictims => Instance[(short)20];

		public static CharacterMatcherItem CanMakeAppointment => Instance[(short)53];

		public static CharacterMatcherItem InSettlement => Instance[(short)55];

		public static CharacterMatcherItem CanJoinFeast => Instance[(short)56];

		public static CharacterMatcherItem CanBeJixiDrainTarget => Instance[(short)57];

		public static CharacterMatcherItem CanBeSelectJixiDrainTarget => Instance[(short)58];
	}

	public static CharacterMatcher Instance = new CharacterMatcher();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "MerchantType", "Organization", "SubConditions", "TargetSubConditions", "TemplateId", "FavorRange", "TargetKey" };

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
		_dataArray.Add(new CharacterMatcherItem(0, ECharacterMatcherAgeType.NonBaby, ECharacterMatcherIdentityType.NotRestricted, -1, ECharacterMatcherGenderType.NotRestricted, null, -1, new ECharacterMatcherSubCondition[3]
		{
			ECharacterMatcherSubCondition.NotActingCrazy,
			ECharacterMatcherSubCondition.CanBeLocated,
			ECharacterMatcherSubCondition.NotCrossAreaTraveling
		}, ECharacterMatcherTargetType.None, null, new ECharacterMatcherTargetSubCondition[0]));
		_dataArray.Add(new CharacterMatcherItem(1, ECharacterMatcherAgeType.Adult, ECharacterMatcherIdentityType.NotRestricted, -1, ECharacterMatcherGenderType.NotRestricted, null, -1, new ECharacterMatcherSubCondition[3]
		{
			ECharacterMatcherSubCondition.NotActingCrazy,
			ECharacterMatcherSubCondition.CanBeLocated,
			ECharacterMatcherSubCondition.NotCrossAreaTraveling
		}, ECharacterMatcherTargetType.None, null, new ECharacterMatcherTargetSubCondition[0]));
		_dataArray.Add(new CharacterMatcherItem(2, ECharacterMatcherAgeType.Adult, ECharacterMatcherIdentityType.NotRestricted, -1, ECharacterMatcherGenderType.NotRestricted, null, -1, new ECharacterMatcherSubCondition[5]
		{
			ECharacterMatcherSubCondition.NotActingCrazy,
			ECharacterMatcherSubCondition.CanBeLocated,
			ECharacterMatcherSubCondition.CanHaveChild,
			ECharacterMatcherSubCondition.NotTaiwu,
			ECharacterMatcherSubCondition.NotCrossAreaTraveling
		}, ECharacterMatcherTargetType.None, null, new ECharacterMatcherTargetSubCondition[0]));
		_dataArray.Add(new CharacterMatcherItem(3, ECharacterMatcherAgeType.NonBaby, ECharacterMatcherIdentityType.NotRestricted, -1, ECharacterMatcherGenderType.NotRestricted, null, -1, new ECharacterMatcherSubCondition[2]
		{
			ECharacterMatcherSubCondition.CanBeLocated,
			ECharacterMatcherSubCondition.NotCrossAreaTraveling
		}, ECharacterMatcherTargetType.None, null, new ECharacterMatcherTargetSubCondition[0]));
		_dataArray.Add(new CharacterMatcherItem(4, ECharacterMatcherAgeType.NotRestricted, ECharacterMatcherIdentityType.XiangshuInfected, -1, ECharacterMatcherGenderType.NotRestricted, null, -1, new ECharacterMatcherSubCondition[2]
		{
			ECharacterMatcherSubCondition.CanBeLocated,
			ECharacterMatcherSubCondition.NotCrossAreaTraveling
		}, ECharacterMatcherTargetType.None, null, new ECharacterMatcherTargetSubCondition[0]));
		_dataArray.Add(new CharacterMatcherItem(5, ECharacterMatcherAgeType.NonBaby, ECharacterMatcherIdentityType.NotRestricted, -1, ECharacterMatcherGenderType.NotRestricted, null, -1, new ECharacterMatcherSubCondition[3]
		{
			ECharacterMatcherSubCondition.NotActingCrazy,
			ECharacterMatcherSubCondition.CanBeLocated,
			ECharacterMatcherSubCondition.NotCrossAreaTraveling
		}, ECharacterMatcherTargetType.None, null, new ECharacterMatcherTargetSubCondition[0]));
		_dataArray.Add(new CharacterMatcherItem(6, ECharacterMatcherAgeType.NonBaby, ECharacterMatcherIdentityType.NotRestricted, -1, ECharacterMatcherGenderType.NotRestricted, null, -1, new ECharacterMatcherSubCondition[3]
		{
			ECharacterMatcherSubCondition.CanBeLocated,
			ECharacterMatcherSubCondition.NotInTaiwuGroup,
			ECharacterMatcherSubCondition.NotCrossAreaTraveling
		}, ECharacterMatcherTargetType.None, null, new ECharacterMatcherTargetSubCondition[0]));
		_dataArray.Add(new CharacterMatcherItem(7, ECharacterMatcherAgeType.Child, ECharacterMatcherIdentityType.NotRestricted, -1, ECharacterMatcherGenderType.NotRestricted, null, -1, new ECharacterMatcherSubCondition[4]
		{
			ECharacterMatcherSubCondition.NotActingCrazy,
			ECharacterMatcherSubCondition.CanBeLocated,
			ECharacterMatcherSubCondition.NotInTaiwuGroup,
			ECharacterMatcherSubCondition.NotCrossAreaTraveling
		}, ECharacterMatcherTargetType.None, null, new ECharacterMatcherTargetSubCondition[0]));
		_dataArray.Add(new CharacterMatcherItem(8, ECharacterMatcherAgeType.Adult, ECharacterMatcherIdentityType.NotRestricted, -1, ECharacterMatcherGenderType.NotRestricted, null, -1, new ECharacterMatcherSubCondition[1], ECharacterMatcherTargetType.None, null, new ECharacterMatcherTargetSubCondition[0]));
		_dataArray.Add(new CharacterMatcherItem(9, ECharacterMatcherAgeType.NonBaby, ECharacterMatcherIdentityType.NotRestricted, -1, ECharacterMatcherGenderType.NotRestricted, null, -1, new ECharacterMatcherSubCondition[1], ECharacterMatcherTargetType.None, null, new ECharacterMatcherTargetSubCondition[0]));
		_dataArray.Add(new CharacterMatcherItem(10, ECharacterMatcherAgeType.NonBaby, ECharacterMatcherIdentityType.NotRestricted, -1, ECharacterMatcherGenderType.NotRestricted, null, -1, new ECharacterMatcherSubCondition[7]
		{
			ECharacterMatcherSubCondition.NotActingCrazy,
			ECharacterMatcherSubCondition.CanBeLocated,
			ECharacterMatcherSubCondition.NotInTaiwuGroup,
			ECharacterMatcherSubCondition.NotAssignedWithWork,
			ECharacterMatcherSubCondition.NotCrossAreaTraveling,
			ECharacterMatcherSubCondition.CombatPowerTop30,
			ECharacterMatcherSubCondition.NotSettlementGuard
		}, ECharacterMatcherTargetType.None, null, new ECharacterMatcherTargetSubCondition[0]));
		_dataArray.Add(new CharacterMatcherItem(11, ECharacterMatcherAgeType.NonBaby, ECharacterMatcherIdentityType.NotRestricted, -1, ECharacterMatcherGenderType.NotRestricted, null, -1, new ECharacterMatcherSubCondition[3]
		{
			ECharacterMatcherSubCondition.CanBeLocated,
			ECharacterMatcherSubCondition.NotInTaiwuGroup,
			ECharacterMatcherSubCondition.NotCrossAreaTraveling
		}, ECharacterMatcherTargetType.None, null, new ECharacterMatcherTargetSubCondition[0]));
		_dataArray.Add(new CharacterMatcherItem(12, ECharacterMatcherAgeType.NonBaby, ECharacterMatcherIdentityType.NotXiangshuInfected, -1, ECharacterMatcherGenderType.NotRestricted, null, -1, new ECharacterMatcherSubCondition[3]
		{
			ECharacterMatcherSubCondition.NotActingCrazy,
			ECharacterMatcherSubCondition.NotTaiwu,
			ECharacterMatcherSubCondition.NotInSettlementPrison
		}, ECharacterMatcherTargetType.None, null, new ECharacterMatcherTargetSubCondition[0]));
		_dataArray.Add(new CharacterMatcherItem(13, ECharacterMatcherAgeType.NonBaby, ECharacterMatcherIdentityType.NotRestricted, -1, ECharacterMatcherGenderType.NotRestricted, null, -1, new ECharacterMatcherSubCondition[1] { ECharacterMatcherSubCondition.CanBeLocated }, ECharacterMatcherTargetType.None, null, new ECharacterMatcherTargetSubCondition[0]));
		_dataArray.Add(new CharacterMatcherItem(14, ECharacterMatcherAgeType.NonBaby, ECharacterMatcherIdentityType.NotRestricted, -1, ECharacterMatcherGenderType.NotRestricted, null, -1, new ECharacterMatcherSubCondition[1] { ECharacterMatcherSubCondition.CanBeLocated }, ECharacterMatcherTargetType.None, null, new ECharacterMatcherTargetSubCondition[0]));
		_dataArray.Add(new CharacterMatcherItem(15, ECharacterMatcherAgeType.Adult, ECharacterMatcherIdentityType.NotRestricted, -1, ECharacterMatcherGenderType.NotRestricted, null, -1, new ECharacterMatcherSubCondition[0], ECharacterMatcherTargetType.None, null, new ECharacterMatcherTargetSubCondition[0]));
		_dataArray.Add(new CharacterMatcherItem(16, ECharacterMatcherAgeType.Adult, ECharacterMatcherIdentityType.NotTaiwuVillage, -1, ECharacterMatcherGenderType.NotRestricted, null, -1, new ECharacterMatcherSubCondition[3]
		{
			ECharacterMatcherSubCondition.NotActingCrazy,
			ECharacterMatcherSubCondition.CanBeLocated,
			ECharacterMatcherSubCondition.NotCrossAreaTraveling
		}, ECharacterMatcherTargetType.None, null, new ECharacterMatcherTargetSubCondition[0]));
		_dataArray.Add(new CharacterMatcherItem(17, ECharacterMatcherAgeType.Adult, ECharacterMatcherIdentityType.NotTaiwuVillage, -1, ECharacterMatcherGenderType.NotRestricted, null, -1, new ECharacterMatcherSubCondition[2]
		{
			ECharacterMatcherSubCondition.NotTaiwuFriendlyRelation,
			ECharacterMatcherSubCondition.NotAwakeJixiTaiwuRelated
		}, ECharacterMatcherTargetType.None, null, new ECharacterMatcherTargetSubCondition[0]));
		_dataArray.Add(new CharacterMatcherItem(18, ECharacterMatcherAgeType.Adult, ECharacterMatcherIdentityType.NotRestricted, -1, ECharacterMatcherGenderType.NotRestricted, null, -1, new ECharacterMatcherSubCondition[3]
		{
			ECharacterMatcherSubCondition.NotActingCrazy,
			ECharacterMatcherSubCondition.CanBeLocated,
			ECharacterMatcherSubCondition.NotInTaiwuGroup
		}, ECharacterMatcherTargetType.None, null, new ECharacterMatcherTargetSubCondition[0]));
		_dataArray.Add(new CharacterMatcherItem(19, ECharacterMatcherAgeType.Adult, ECharacterMatcherIdentityType.NotRestricted, -1, ECharacterMatcherGenderType.NotRestricted, null, 6, new ECharacterMatcherSubCondition[4]
		{
			ECharacterMatcherSubCondition.NotActingCrazy,
			ECharacterMatcherSubCondition.CanBeLocated,
			ECharacterMatcherSubCondition.NotHighestGrade,
			ECharacterMatcherSubCondition.NotCrossAreaTraveling
		}, ECharacterMatcherTargetType.None, null, new ECharacterMatcherTargetSubCondition[0]));
		_dataArray.Add(new CharacterMatcherItem(20, ECharacterMatcherAgeType.Adult, ECharacterMatcherIdentityType.NotRestricted, -1, ECharacterMatcherGenderType.NotRestricted, null, 2, new ECharacterMatcherSubCondition[0], ECharacterMatcherTargetType.None, null, new ECharacterMatcherTargetSubCondition[0]));
		_dataArray.Add(new CharacterMatcherItem(21, ECharacterMatcherAgeType.NonBaby, ECharacterMatcherIdentityType.Sect, -1, ECharacterMatcherGenderType.NotRestricted, null, -1, new ECharacterMatcherSubCondition[3]
		{
			ECharacterMatcherSubCondition.NotActingCrazy,
			ECharacterMatcherSubCondition.CanBeLocated,
			ECharacterMatcherSubCondition.NotCrossAreaTraveling
		}, ECharacterMatcherTargetType.None, null, new ECharacterMatcherTargetSubCondition[0]));
		_dataArray.Add(new CharacterMatcherItem(22, ECharacterMatcherAgeType.NonBaby, ECharacterMatcherIdentityType.NotRestricted, -1, ECharacterMatcherGenderType.NotRestricted, null, -1, new ECharacterMatcherSubCondition[2]
		{
			ECharacterMatcherSubCondition.NotActingCrazy,
			ECharacterMatcherSubCondition.NotTaiwuFriendlyRelation
		}, ECharacterMatcherTargetType.None, null, new ECharacterMatcherTargetSubCondition[0]));
		_dataArray.Add(new CharacterMatcherItem(23, ECharacterMatcherAgeType.NonBaby, ECharacterMatcherIdentityType.NotRestricted, -1, ECharacterMatcherGenderType.NotRestricted, null, -1, new ECharacterMatcherSubCondition[0], ECharacterMatcherTargetType.None, null, new ECharacterMatcherTargetSubCondition[0]));
		_dataArray.Add(new CharacterMatcherItem(24, ECharacterMatcherAgeType.NonBaby, ECharacterMatcherIdentityType.NotRestricted, -1, ECharacterMatcherGenderType.Female, null, -1, new ECharacterMatcherSubCondition[3]
		{
			ECharacterMatcherSubCondition.CanHaveChild,
			ECharacterMatcherSubCondition.NotLegendaryBookConsumed,
			ECharacterMatcherSubCondition.NotInSettlementPrison
		}, ECharacterMatcherTargetType.None, null, new ECharacterMatcherTargetSubCondition[0]));
		_dataArray.Add(new CharacterMatcherItem(25, ECharacterMatcherAgeType.NonBaby, ECharacterMatcherIdentityType.NotRestricted, -1, ECharacterMatcherGenderType.NotRestricted, null, -1, new ECharacterMatcherSubCondition[4]
		{
			ECharacterMatcherSubCondition.CanBeLocated,
			ECharacterMatcherSubCondition.NotLegendaryBookConsumed,
			ECharacterMatcherSubCondition.NotInSettlementPrison,
			ECharacterMatcherSubCondition.NotCrossAreaTraveling
		}, ECharacterMatcherTargetType.None, null, new ECharacterMatcherTargetSubCondition[0]));
		_dataArray.Add(new CharacterMatcherItem(26, ECharacterMatcherAgeType.NonBaby, ECharacterMatcherIdentityType.Sect, -1, ECharacterMatcherGenderType.NotRestricted, null, -1, new ECharacterMatcherSubCondition[4]
		{
			ECharacterMatcherSubCondition.CanBeLocated,
			ECharacterMatcherSubCondition.NotLegendaryBookConsumed,
			ECharacterMatcherSubCondition.NotInSettlementPrison,
			ECharacterMatcherSubCondition.NotCrossAreaTraveling
		}, ECharacterMatcherTargetType.None, null, new ECharacterMatcherTargetSubCondition[0]));
		_dataArray.Add(new CharacterMatcherItem(27, ECharacterMatcherAgeType.NonBaby, ECharacterMatcherIdentityType.NotRestricted, -1, ECharacterMatcherGenderType.NotRestricted, null, -1, new ECharacterMatcherSubCondition[4]
		{
			ECharacterMatcherSubCondition.CanBeLocated,
			ECharacterMatcherSubCondition.NotLegendaryBookConsumed,
			ECharacterMatcherSubCondition.NotInSettlementPrison,
			ECharacterMatcherSubCondition.NotCrossAreaTraveling
		}, ECharacterMatcherTargetType.None, null, new ECharacterMatcherTargetSubCondition[0]));
		_dataArray.Add(new CharacterMatcherItem(28, ECharacterMatcherAgeType.NonBaby, ECharacterMatcherIdentityType.NotRestricted, -1, ECharacterMatcherGenderType.NotRestricted, null, -1, new ECharacterMatcherSubCondition[0], ECharacterMatcherTargetType.None, null, new ECharacterMatcherTargetSubCondition[0]));
		_dataArray.Add(new CharacterMatcherItem(29, ECharacterMatcherAgeType.NonBaby, ECharacterMatcherIdentityType.NotRestricted, -1, ECharacterMatcherGenderType.NotRestricted, null, -1, new ECharacterMatcherSubCondition[1], ECharacterMatcherTargetType.None, null, new ECharacterMatcherTargetSubCondition[0]));
		_dataArray.Add(new CharacterMatcherItem(30, ECharacterMatcherAgeType.NotRestricted, ECharacterMatcherIdentityType.NotRestricted, -1, ECharacterMatcherGenderType.NotRestricted, null, -1, new ECharacterMatcherSubCondition[1], ECharacterMatcherTargetType.None, null, new ECharacterMatcherTargetSubCondition[0]));
		_dataArray.Add(new CharacterMatcherItem(31, ECharacterMatcherAgeType.NotRestricted, ECharacterMatcherIdentityType.NotSect, -1, ECharacterMatcherGenderType.NotRestricted, null, -1, new ECharacterMatcherSubCondition[0], ECharacterMatcherTargetType.None, null, new ECharacterMatcherTargetSubCondition[0]));
		_dataArray.Add(new CharacterMatcherItem(32, ECharacterMatcherAgeType.NotRestricted, ECharacterMatcherIdentityType.Sect, -1, ECharacterMatcherGenderType.NotRestricted, null, -1, new ECharacterMatcherSubCondition[0], ECharacterMatcherTargetType.None, null, new ECharacterMatcherTargetSubCondition[0]));
		_dataArray.Add(new CharacterMatcherItem(33, ECharacterMatcherAgeType.NonBaby, ECharacterMatcherIdentityType.Sect, -1, ECharacterMatcherGenderType.NotRestricted, null, 6, new ECharacterMatcherSubCondition[2]
		{
			ECharacterMatcherSubCondition.CanBeLocated,
			ECharacterMatcherSubCondition.NotCrossAreaTraveling
		}, ECharacterMatcherTargetType.None, null, new ECharacterMatcherTargetSubCondition[0]));
		_dataArray.Add(new CharacterMatcherItem(34, ECharacterMatcherAgeType.NonBaby, ECharacterMatcherIdentityType.Sect, -1, ECharacterMatcherGenderType.NotRestricted, null, 6, new ECharacterMatcherSubCondition[0], ECharacterMatcherTargetType.None, null, new ECharacterMatcherTargetSubCondition[0]));
		_dataArray.Add(new CharacterMatcherItem(35, ECharacterMatcherAgeType.NonBaby, ECharacterMatcherIdentityType.Sect, -1, ECharacterMatcherGenderType.NotRestricted, null, -1, new ECharacterMatcherSubCondition[5]
		{
			ECharacterMatcherSubCondition.NotActingCrazy,
			ECharacterMatcherSubCondition.CanBeLocated,
			ECharacterMatcherSubCondition.NotLegendaryBookConsumed,
			ECharacterMatcherSubCondition.NotInSettlementPrison,
			ECharacterMatcherSubCondition.NotCrossAreaTraveling
		}, ECharacterMatcherTargetType.None, null, new ECharacterMatcherTargetSubCondition[0]));
		_dataArray.Add(new CharacterMatcherItem(36, ECharacterMatcherAgeType.NonBaby, ECharacterMatcherIdentityType.NotRestricted, -1, ECharacterMatcherGenderType.NotRestricted, null, -1, new ECharacterMatcherSubCondition[2]
		{
			ECharacterMatcherSubCondition.CanBeLocated,
			ECharacterMatcherSubCondition.NotCrossAreaTraveling
		}, ECharacterMatcherTargetType.None, null, new ECharacterMatcherTargetSubCondition[0]));
		_dataArray.Add(new CharacterMatcherItem(37, ECharacterMatcherAgeType.NonBaby, ECharacterMatcherIdentityType.Sect, -1, ECharacterMatcherGenderType.NotRestricted, null, -1, new ECharacterMatcherSubCondition[1], ECharacterMatcherTargetType.None, null, new ECharacterMatcherTargetSubCondition[0]));
		_dataArray.Add(new CharacterMatcherItem(38, ECharacterMatcherAgeType.Adult, ECharacterMatcherIdentityType.NotRestricted, -1, ECharacterMatcherGenderType.NotRestricted, null, -1, new ECharacterMatcherSubCondition[1], ECharacterMatcherTargetType.None, null, new ECharacterMatcherTargetSubCondition[0]));
		_dataArray.Add(new CharacterMatcherItem(39, ECharacterMatcherAgeType.NonBaby, ECharacterMatcherIdentityType.NotRestricted, -1, ECharacterMatcherGenderType.NotRestricted, null, -1, new ECharacterMatcherSubCondition[1], ECharacterMatcherTargetType.None, null, new ECharacterMatcherTargetSubCondition[0]));
		_dataArray.Add(new CharacterMatcherItem(40, ECharacterMatcherAgeType.NonBaby, ECharacterMatcherIdentityType.NotRestricted, -1, ECharacterMatcherGenderType.NotRestricted, null, -1, new ECharacterMatcherSubCondition[1], ECharacterMatcherTargetType.None, null, new ECharacterMatcherTargetSubCondition[0]));
		_dataArray.Add(new CharacterMatcherItem(41, ECharacterMatcherAgeType.NonBaby, ECharacterMatcherIdentityType.NotRestricted, -1, ECharacterMatcherGenderType.NotRestricted, null, -1, new ECharacterMatcherSubCondition[1], ECharacterMatcherTargetType.None, null, new ECharacterMatcherTargetSubCondition[0]));
		_dataArray.Add(new CharacterMatcherItem(42, ECharacterMatcherAgeType.NonBaby, ECharacterMatcherIdentityType.NotRestricted, -1, ECharacterMatcherGenderType.NotRestricted, null, -1, new ECharacterMatcherSubCondition[1], ECharacterMatcherTargetType.None, null, new ECharacterMatcherTargetSubCondition[0]));
		_dataArray.Add(new CharacterMatcherItem(43, ECharacterMatcherAgeType.NonBaby, ECharacterMatcherIdentityType.NotRestricted, -1, ECharacterMatcherGenderType.NotRestricted, null, -1, new ECharacterMatcherSubCondition[1], ECharacterMatcherTargetType.None, null, new ECharacterMatcherTargetSubCondition[0]));
		_dataArray.Add(new CharacterMatcherItem(44, ECharacterMatcherAgeType.NonBaby, ECharacterMatcherIdentityType.NotRestricted, -1, ECharacterMatcherGenderType.NotRestricted, null, -1, new ECharacterMatcherSubCondition[1], ECharacterMatcherTargetType.None, null, new ECharacterMatcherTargetSubCondition[0]));
		_dataArray.Add(new CharacterMatcherItem(45, ECharacterMatcherAgeType.NonBaby, ECharacterMatcherIdentityType.NotRestricted, -1, ECharacterMatcherGenderType.NotRestricted, null, -1, new ECharacterMatcherSubCondition[1], ECharacterMatcherTargetType.None, null, new ECharacterMatcherTargetSubCondition[0]));
		_dataArray.Add(new CharacterMatcherItem(46, ECharacterMatcherAgeType.NonBaby, ECharacterMatcherIdentityType.NotRestricted, -1, ECharacterMatcherGenderType.NotRestricted, null, -1, new ECharacterMatcherSubCondition[1], ECharacterMatcherTargetType.None, null, new ECharacterMatcherTargetSubCondition[0]));
		_dataArray.Add(new CharacterMatcherItem(47, ECharacterMatcherAgeType.NonBaby, ECharacterMatcherIdentityType.NotRestricted, -1, ECharacterMatcherGenderType.NotRestricted, null, -1, new ECharacterMatcherSubCondition[1], ECharacterMatcherTargetType.None, null, new ECharacterMatcherTargetSubCondition[0]));
		_dataArray.Add(new CharacterMatcherItem(48, ECharacterMatcherAgeType.NonBaby, ECharacterMatcherIdentityType.NotRestricted, -1, ECharacterMatcherGenderType.NotRestricted, null, -1, new ECharacterMatcherSubCondition[1], ECharacterMatcherTargetType.None, null, new ECharacterMatcherTargetSubCondition[0]));
		_dataArray.Add(new CharacterMatcherItem(49, ECharacterMatcherAgeType.NonBaby, ECharacterMatcherIdentityType.NotRestricted, -1, ECharacterMatcherGenderType.NotRestricted, null, -1, new ECharacterMatcherSubCondition[1], ECharacterMatcherTargetType.None, null, new ECharacterMatcherTargetSubCondition[0]));
		_dataArray.Add(new CharacterMatcherItem(50, ECharacterMatcherAgeType.NonBaby, ECharacterMatcherIdentityType.NotRestricted, -1, ECharacterMatcherGenderType.NotRestricted, null, -1, new ECharacterMatcherSubCondition[1], ECharacterMatcherTargetType.None, null, new ECharacterMatcherTargetSubCondition[0]));
		_dataArray.Add(new CharacterMatcherItem(51, ECharacterMatcherAgeType.NonBaby, ECharacterMatcherIdentityType.NotRestricted, -1, ECharacterMatcherGenderType.NotRestricted, null, -1, new ECharacterMatcherSubCondition[1], ECharacterMatcherTargetType.None, null, new ECharacterMatcherTargetSubCondition[0]));
		_dataArray.Add(new CharacterMatcherItem(52, ECharacterMatcherAgeType.NonBaby, ECharacterMatcherIdentityType.NotRestricted, -1, ECharacterMatcherGenderType.NotRestricted, null, -1, new ECharacterMatcherSubCondition[1], ECharacterMatcherTargetType.None, null, new ECharacterMatcherTargetSubCondition[0]));
		_dataArray.Add(new CharacterMatcherItem(53, ECharacterMatcherAgeType.Adult, ECharacterMatcherIdentityType.NotRestricted, -1, ECharacterMatcherGenderType.NotRestricted, new int[2] { 10000, 99999 }, -1, new ECharacterMatcherSubCondition[5]
		{
			ECharacterMatcherSubCondition.NotActingCrazy,
			ECharacterMatcherSubCondition.CanBeLocated,
			ECharacterMatcherSubCondition.NotInTaiwuGroup,
			ECharacterMatcherSubCondition.NotCrossAreaTraveling,
			ECharacterMatcherSubCondition.NotSettlementGuard
		}, ECharacterMatcherTargetType.None, null, new ECharacterMatcherTargetSubCondition[0]));
		_dataArray.Add(new CharacterMatcherItem(54, ECharacterMatcherAgeType.NonBaby, ECharacterMatcherIdentityType.NotRestricted, -1, ECharacterMatcherGenderType.NotRestricted, null, -1, new ECharacterMatcherSubCondition[0], ECharacterMatcherTargetType.None, null, new ECharacterMatcherTargetSubCondition[0]));
		_dataArray.Add(new CharacterMatcherItem(55, ECharacterMatcherAgeType.NotRestricted, ECharacterMatcherIdentityType.NotRestricted, -1, ECharacterMatcherGenderType.NotRestricted, null, -1, new ECharacterMatcherSubCondition[3]
		{
			ECharacterMatcherSubCondition.InSelfSettlement,
			ECharacterMatcherSubCondition.NotAwakeJixiTaiwuRelated,
			ECharacterMatcherSubCondition.HaveNeiliAllocation
		}, ECharacterMatcherTargetType.None, null, new ECharacterMatcherTargetSubCondition[0]));
		_dataArray.Add(new CharacterMatcherItem(56, ECharacterMatcherAgeType.NonBaby, ECharacterMatcherIdentityType.NotRestricted, -1, ECharacterMatcherGenderType.NotRestricted, null, -1, new ECharacterMatcherSubCondition[3]
		{
			ECharacterMatcherSubCondition.NotActingCrazy,
			ECharacterMatcherSubCondition.CanBeLocated,
			ECharacterMatcherSubCondition.NotSettlementGuard
		}, ECharacterMatcherTargetType.None, null, new ECharacterMatcherTargetSubCondition[0]));
		_dataArray.Add(new CharacterMatcherItem(57, ECharacterMatcherAgeType.Adult, ECharacterMatcherIdentityType.NotTaiwuVillage, -1, ECharacterMatcherGenderType.NotRestricted, null, -1, new ECharacterMatcherSubCondition[5]
		{
			ECharacterMatcherSubCondition.NotActingCrazy,
			ECharacterMatcherSubCondition.CanBeLocated,
			ECharacterMatcherSubCondition.NotTaiwuFriendlyRelation,
			ECharacterMatcherSubCondition.NotAwakeJixiTaiwuRelated,
			ECharacterMatcherSubCondition.HaveNeiliAllocation
		}, ECharacterMatcherTargetType.None, null, new ECharacterMatcherTargetSubCondition[0]));
		_dataArray.Add(new CharacterMatcherItem(58, ECharacterMatcherAgeType.Adult, ECharacterMatcherIdentityType.NotRestricted, -1, ECharacterMatcherGenderType.NotRestricted, null, -1, new ECharacterMatcherSubCondition[3]
		{
			ECharacterMatcherSubCondition.NotActingCrazy,
			ECharacterMatcherSubCondition.CanBeLocated,
			ECharacterMatcherSubCondition.HaveNeiliAllocation
		}, ECharacterMatcherTargetType.None, null, new ECharacterMatcherTargetSubCondition[0]));
		_dataArray.Add(new CharacterMatcherItem(59, ECharacterMatcherAgeType.Adult, ECharacterMatcherIdentityType.NotTaiwuVillage, 0, ECharacterMatcherGenderType.NotRestricted, null, -1, new ECharacterMatcherSubCondition[1] { ECharacterMatcherSubCondition.NotInTaiwuGroup }, ECharacterMatcherTargetType.None, null, new ECharacterMatcherTargetSubCondition[0]));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new CharacterMatcherItem(60, ECharacterMatcherAgeType.Adult, ECharacterMatcherIdentityType.NotTaiwuVillage, 1, ECharacterMatcherGenderType.NotRestricted, null, -1, new ECharacterMatcherSubCondition[1] { ECharacterMatcherSubCondition.NotInTaiwuGroup }, ECharacterMatcherTargetType.None, null, new ECharacterMatcherTargetSubCondition[0]));
		_dataArray.Add(new CharacterMatcherItem(61, ECharacterMatcherAgeType.Adult, ECharacterMatcherIdentityType.NotTaiwuVillage, 2, ECharacterMatcherGenderType.NotRestricted, null, -1, new ECharacterMatcherSubCondition[1] { ECharacterMatcherSubCondition.NotInTaiwuGroup }, ECharacterMatcherTargetType.None, null, new ECharacterMatcherTargetSubCondition[0]));
		_dataArray.Add(new CharacterMatcherItem(62, ECharacterMatcherAgeType.Adult, ECharacterMatcherIdentityType.NotTaiwuVillage, 3, ECharacterMatcherGenderType.NotRestricted, null, -1, new ECharacterMatcherSubCondition[1] { ECharacterMatcherSubCondition.NotInTaiwuGroup }, ECharacterMatcherTargetType.None, null, new ECharacterMatcherTargetSubCondition[0]));
		_dataArray.Add(new CharacterMatcherItem(63, ECharacterMatcherAgeType.Adult, ECharacterMatcherIdentityType.NotTaiwuVillage, 4, ECharacterMatcherGenderType.NotRestricted, null, -1, new ECharacterMatcherSubCondition[1] { ECharacterMatcherSubCondition.NotInTaiwuGroup }, ECharacterMatcherTargetType.None, null, new ECharacterMatcherTargetSubCondition[0]));
		_dataArray.Add(new CharacterMatcherItem(64, ECharacterMatcherAgeType.Adult, ECharacterMatcherIdentityType.NotTaiwuVillage, 5, ECharacterMatcherGenderType.NotRestricted, null, -1, new ECharacterMatcherSubCondition[1] { ECharacterMatcherSubCondition.NotInTaiwuGroup }, ECharacterMatcherTargetType.None, null, new ECharacterMatcherTargetSubCondition[0]));
		_dataArray.Add(new CharacterMatcherItem(65, ECharacterMatcherAgeType.Adult, ECharacterMatcherIdentityType.NotTaiwuVillage, 6, ECharacterMatcherGenderType.NotRestricted, null, -1, new ECharacterMatcherSubCondition[1] { ECharacterMatcherSubCondition.NotInTaiwuGroup }, ECharacterMatcherTargetType.None, null, new ECharacterMatcherTargetSubCondition[0]));
		_dataArray.Add(new CharacterMatcherItem(66, ECharacterMatcherAgeType.NotRestricted, ECharacterMatcherIdentityType.NotRestricted, -1, ECharacterMatcherGenderType.NotRestricted, null, -1, new ECharacterMatcherSubCondition[1] { ECharacterMatcherSubCondition.InSettlementInfluenceRange }, ECharacterMatcherTargetType.None, null, new ECharacterMatcherTargetSubCondition[0]));
		_dataArray.Add(new CharacterMatcherItem(67, ECharacterMatcherAgeType.Adult, ECharacterMatcherIdentityType.NotRestricted, -1, ECharacterMatcherGenderType.NotRestricted, new int[2] { 22000, 99999 }, -1, new ECharacterMatcherSubCondition[4]
		{
			ECharacterMatcherSubCondition.NotActingCrazy,
			ECharacterMatcherSubCondition.NotTaiwu,
			ECharacterMatcherSubCondition.NotLegendaryBookConsumed,
			ECharacterMatcherSubCondition.NotTaiwuFamiliyRelation
		}, ECharacterMatcherTargetType.None, null, new ECharacterMatcherTargetSubCondition[0]));
		_dataArray.Add(new CharacterMatcherItem(68, ECharacterMatcherAgeType.Adult, ECharacterMatcherIdentityType.NotRestricted, -1, ECharacterMatcherGenderType.NotRestricted, null, -1, new ECharacterMatcherSubCondition[2]
		{
			ECharacterMatcherSubCondition.NotTaiwu,
			ECharacterMatcherSubCondition.NotTaiwuFamiliyRelation
		}, ECharacterMatcherTargetType.None, null, new ECharacterMatcherTargetSubCondition[0]));
		_dataArray.Add(new CharacterMatcherItem(69, ECharacterMatcherAgeType.Adult, ECharacterMatcherIdentityType.NotRestricted, -1, ECharacterMatcherGenderType.NotRestricted, null, -1, new ECharacterMatcherSubCondition[2]
		{
			ECharacterMatcherSubCondition.NotTaiwu,
			ECharacterMatcherSubCondition.CanBeTaiwu
		}, ECharacterMatcherTargetType.None, null, new ECharacterMatcherTargetSubCondition[0]));
		_dataArray.Add(new CharacterMatcherItem(70, ECharacterMatcherAgeType.NotRestricted, ECharacterMatcherIdentityType.NotRestricted, -1, ECharacterMatcherGenderType.NotRestricted, new int[2] { 10000, 99999 }, -1, new ECharacterMatcherSubCondition[3]
		{
			ECharacterMatcherSubCondition.NotActingCrazy,
			ECharacterMatcherSubCondition.CanBeLocated,
			ECharacterMatcherSubCondition.NotLegendaryBookConsumed
		}, ECharacterMatcherTargetType.TaiwuCharacter, null, new ECharacterMatcherTargetSubCondition[1] { ECharacterMatcherTargetSubCondition.TargetFriendOrFamily }));
		_dataArray.Add(new CharacterMatcherItem(71, ECharacterMatcherAgeType.Adult, ECharacterMatcherIdentityType.NotRestricted, -1, ECharacterMatcherGenderType.NotRestricted, new int[2] { 10000, 99999 }, -1, new ECharacterMatcherSubCondition[3]
		{
			ECharacterMatcherSubCondition.NotActingCrazy,
			ECharacterMatcherSubCondition.CanBeLocated,
			ECharacterMatcherSubCondition.NotLegendaryBookConsumed
		}, ECharacterMatcherTargetType.TaiwuCharacter, null, new ECharacterMatcherTargetSubCondition[1]));
		_dataArray.Add(new CharacterMatcherItem(72, ECharacterMatcherAgeType.Adult, ECharacterMatcherIdentityType.NotRestricted, -1, ECharacterMatcherGenderType.NotRestricted, new int[2] { 10000, 99999 }, -1, new ECharacterMatcherSubCondition[3]
		{
			ECharacterMatcherSubCondition.NotActingCrazy,
			ECharacterMatcherSubCondition.CanBeLocated,
			ECharacterMatcherSubCondition.NotLegendaryBookConsumed
		}, ECharacterMatcherTargetType.TaiwuCharacter, null, new ECharacterMatcherTargetSubCondition[1] { ECharacterMatcherTargetSubCondition.TargetTwoWayAdored }));
		_dataArray.Add(new CharacterMatcherItem(73, ECharacterMatcherAgeType.NotRestricted, ECharacterMatcherIdentityType.NotRestricted, -1, ECharacterMatcherGenderType.NotRestricted, null, -1, new ECharacterMatcherSubCondition[3]
		{
			ECharacterMatcherSubCondition.NotActingCrazy,
			ECharacterMatcherSubCondition.CanBeLocated,
			ECharacterMatcherSubCondition.NotLegendaryBookConsumed
		}, ECharacterMatcherTargetType.AdventurePresetCharacter, "TaiwuMate", new ECharacterMatcherTargetSubCondition[1] { ECharacterMatcherTargetSubCondition.TargetFriendOrFamily }));
		_dataArray.Add(new CharacterMatcherItem(74, ECharacterMatcherAgeType.Adult, ECharacterMatcherIdentityType.NotRestricted, -1, ECharacterMatcherGenderType.NotRestricted, null, -1, new ECharacterMatcherSubCondition[3]
		{
			ECharacterMatcherSubCondition.NotActingCrazy,
			ECharacterMatcherSubCondition.CanBeLocated,
			ECharacterMatcherSubCondition.NotLegendaryBookConsumed
		}, ECharacterMatcherTargetType.AdventurePresetCharacter, "TaiwuMate", new ECharacterMatcherTargetSubCondition[1]));
		_dataArray.Add(new CharacterMatcherItem(75, ECharacterMatcherAgeType.Adult, ECharacterMatcherIdentityType.NotRestricted, -1, ECharacterMatcherGenderType.NotRestricted, null, -1, new ECharacterMatcherSubCondition[3]
		{
			ECharacterMatcherSubCondition.NotActingCrazy,
			ECharacterMatcherSubCondition.CanBeLocated,
			ECharacterMatcherSubCondition.NotLegendaryBookConsumed
		}, ECharacterMatcherTargetType.AdventurePresetCharacter, "TaiwuMate", new ECharacterMatcherTargetSubCondition[1] { ECharacterMatcherTargetSubCondition.TargetTwoWayAdored }));
		_dataArray.Add(new CharacterMatcherItem(76, ECharacterMatcherAgeType.NotRestricted, ECharacterMatcherIdentityType.NotRestricted, -1, ECharacterMatcherGenderType.NotRestricted, null, -1, new ECharacterMatcherSubCondition[3]
		{
			ECharacterMatcherSubCondition.NotActingCrazy,
			ECharacterMatcherSubCondition.CanBeLocated,
			ECharacterMatcherSubCondition.NotLegendaryBookConsumed
		}, ECharacterMatcherTargetType.AdventurePresetCharacter, "NpcGroom", new ECharacterMatcherTargetSubCondition[1] { ECharacterMatcherTargetSubCondition.TargetFriendOrFamily }));
		_dataArray.Add(new CharacterMatcherItem(77, ECharacterMatcherAgeType.Adult, ECharacterMatcherIdentityType.NotRestricted, -1, ECharacterMatcherGenderType.NotRestricted, null, -1, new ECharacterMatcherSubCondition[3]
		{
			ECharacterMatcherSubCondition.NotActingCrazy,
			ECharacterMatcherSubCondition.CanBeLocated,
			ECharacterMatcherSubCondition.NotLegendaryBookConsumed
		}, ECharacterMatcherTargetType.AdventurePresetCharacter, "NpcGroom", new ECharacterMatcherTargetSubCondition[1]));
		_dataArray.Add(new CharacterMatcherItem(78, ECharacterMatcherAgeType.Adult, ECharacterMatcherIdentityType.NotRestricted, -1, ECharacterMatcherGenderType.NotRestricted, null, -1, new ECharacterMatcherSubCondition[3]
		{
			ECharacterMatcherSubCondition.NotActingCrazy,
			ECharacterMatcherSubCondition.CanBeLocated,
			ECharacterMatcherSubCondition.NotLegendaryBookConsumed
		}, ECharacterMatcherTargetType.AdventurePresetCharacter, "NpcGroom", new ECharacterMatcherTargetSubCondition[1] { ECharacterMatcherTargetSubCondition.TargetTwoWayAdored }));
		_dataArray.Add(new CharacterMatcherItem(79, ECharacterMatcherAgeType.NotRestricted, ECharacterMatcherIdentityType.NotRestricted, -1, ECharacterMatcherGenderType.NotRestricted, null, -1, new ECharacterMatcherSubCondition[3]
		{
			ECharacterMatcherSubCondition.NotActingCrazy,
			ECharacterMatcherSubCondition.CanBeLocated,
			ECharacterMatcherSubCondition.NotLegendaryBookConsumed
		}, ECharacterMatcherTargetType.AdventurePresetCharacter, "NpcBride", new ECharacterMatcherTargetSubCondition[1] { ECharacterMatcherTargetSubCondition.TargetFriendOrFamily }));
		_dataArray.Add(new CharacterMatcherItem(80, ECharacterMatcherAgeType.Adult, ECharacterMatcherIdentityType.NotRestricted, -1, ECharacterMatcherGenderType.NotRestricted, null, -1, new ECharacterMatcherSubCondition[3]
		{
			ECharacterMatcherSubCondition.NotActingCrazy,
			ECharacterMatcherSubCondition.CanBeLocated,
			ECharacterMatcherSubCondition.NotLegendaryBookConsumed
		}, ECharacterMatcherTargetType.AdventurePresetCharacter, "NpcBride", new ECharacterMatcherTargetSubCondition[1]));
		_dataArray.Add(new CharacterMatcherItem(81, ECharacterMatcherAgeType.Adult, ECharacterMatcherIdentityType.NotRestricted, -1, ECharacterMatcherGenderType.NotRestricted, null, -1, new ECharacterMatcherSubCondition[3]
		{
			ECharacterMatcherSubCondition.NotActingCrazy,
			ECharacterMatcherSubCondition.CanBeLocated,
			ECharacterMatcherSubCondition.NotLegendaryBookConsumed
		}, ECharacterMatcherTargetType.AdventurePresetCharacter, "NpcBride", new ECharacterMatcherTargetSubCondition[1] { ECharacterMatcherTargetSubCondition.TargetTwoWayAdored }));
		_dataArray.Add(new CharacterMatcherItem(82, ECharacterMatcherAgeType.NonBaby, ECharacterMatcherIdentityType.NotRestricted, -1, ECharacterMatcherGenderType.NotRestricted, null, -1, new ECharacterMatcherSubCondition[1] { ECharacterMatcherSubCondition.CanBeLocated }, ECharacterMatcherTargetType.None, null, null));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<CharacterMatcherItem>(83);
		CreateItems0();
		CreateItems1();
	}
}
