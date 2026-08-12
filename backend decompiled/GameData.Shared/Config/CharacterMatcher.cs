using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class CharacterMatcher : ConfigData<CharacterMatcherItem, byte>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 可智能互动
		/// </summary>
		public const byte CanInteractAsIntelligentCharacter = 0;

		/// <summary>
		/// 可定位非婴儿
		/// </summary>
		public const byte NonBabyAndCanBeLocaated = 82;

		/// <summary>
		/// 可工作
		/// </summary>
		public const byte CanWork = 1;

		/// <summary>
		/// 可收养子女
		/// </summary>
		public const byte CanAdoptChild = 2;

		/// <summary>
		/// 可作为复仇目标
		/// </summary>
		public const byte CanBeRevengeTarget = 3;

		/// <summary>
		/// 可进行入魔人过月行动
		/// </summary>
		public const byte CanPerformInfectedAction = 4;

		/// <summary>
		/// 可接收秘闻
		/// </summary>
		public const byte CanReceiveSecretInformation = 5;

		/// <summary>
		/// 可成为紫竹化身跟随对象
		/// </summary>
		public const byte JuniorXiangshuFollowingCharacter = 6;

		/// <summary>
		/// 可进行情感关系判断
		/// </summary>
		public const byte CanStartSexRelation = 8;

		/// <summary>
		/// 可建立坟墓
		/// </summary>
		public const byte CanBeUndertaker = 9;

		/// <summary>
		/// 可被奇书奇遇拉取
		/// </summary>
		public const byte AvailableForLegendaryBookAdventure = 10;

		/// <summary>
		/// 出神之地移动角色
		/// </summary>
		public const byte PrepareCharacterForSpiritualWanderPlace = 11;

		/// <summary>
		/// 可被悬赏
		/// </summary>
		public const byte CanHaveBounty = 12;

		/// <summary>
		/// 可被入魔人攻击
		/// </summary>
		public const byte CanBeAttackedByInfectedCharacter = 13;

		/// <summary>
		/// 可被随机敌人袭击
		/// </summary>
		public const byte CanBeAttackedByRandomEnemy = 14;

		/// <summary>
		/// 可被动脱离队伍
		/// </summary>
		public const byte CanBeRemovedFromGroup = 15;

		/// <summary>
		/// 太吾村商人自动行为目标
		/// </summary>
		public const byte CanBeMerchantAutoActionTarget = 16;

		/// <summary>
		/// 可成为姬兮击杀目标
		/// </summary>
		public const byte CanBeJixiKillingTarget = 17;

		/// <summary>
		/// 可为村民安排工作
		/// </summary>
		public const byte VillagerAvailableForWork = 18;

		/// <summary>
		/// 可设置为经营建筑学徒
		/// </summary>
		public const byte ChildVillagerAvailableForWork = 7;

		/// <summary>
		/// 可成为狮相互动添加对象
		/// </summary>
		public const byte InteractWithShixiangMemberEventTarget = 19;

		/// <summary>
		/// 可成为峨眉地区主线中被袭击的对象
		/// </summary>
		public const byte EmeiPotentialVictims = 20;

		/// <summary>
		/// 可发起邀约
		/// </summary>
		public const byte CanMakeAppointment = 53;

		/// <summary>
		/// 在所属定居点
		/// </summary>
		public const byte InSettlement = 55;

		/// <summary>
		/// 可赴宴的非村民宾客
		/// </summary>
		public const byte CanJoinFeast = 56;

		/// <summary>
		/// 可成为姬兮吸取内力目标
		/// </summary>
		public const byte CanBeJixiDrainTarget = 57;

		/// <summary>
		/// 可指定姬兮吸取内力的目标
		/// </summary>
		public const byte CanBeSelectJixiDrainTarget = 58;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 可智能互动
		/// </summary>
		public static CharacterMatcherItem CanInteractAsIntelligentCharacter => Instance[(byte)0];

		/// <summary>
		/// 可定位非婴儿
		/// </summary>
		public static CharacterMatcherItem NonBabyAndCanBeLocaated => Instance[(byte)82];

		/// <summary>
		/// 可工作
		/// </summary>
		public static CharacterMatcherItem CanWork => Instance[(byte)1];

		/// <summary>
		/// 可收养子女
		/// </summary>
		public static CharacterMatcherItem CanAdoptChild => Instance[(byte)2];

		/// <summary>
		/// 可作为复仇目标
		/// </summary>
		public static CharacterMatcherItem CanBeRevengeTarget => Instance[(byte)3];

		/// <summary>
		/// 可进行入魔人过月行动
		/// </summary>
		public static CharacterMatcherItem CanPerformInfectedAction => Instance[(byte)4];

		/// <summary>
		/// 可接收秘闻
		/// </summary>
		public static CharacterMatcherItem CanReceiveSecretInformation => Instance[(byte)5];

		/// <summary>
		/// 可成为紫竹化身跟随对象
		/// </summary>
		public static CharacterMatcherItem JuniorXiangshuFollowingCharacter => Instance[(byte)6];

		/// <summary>
		/// 可进行情感关系判断
		/// </summary>
		public static CharacterMatcherItem CanStartSexRelation => Instance[(byte)8];

		/// <summary>
		/// 可建立坟墓
		/// </summary>
		public static CharacterMatcherItem CanBeUndertaker => Instance[(byte)9];

		/// <summary>
		/// 可被奇书奇遇拉取
		/// </summary>
		public static CharacterMatcherItem AvailableForLegendaryBookAdventure => Instance[(byte)10];

		/// <summary>
		/// 出神之地移动角色
		/// </summary>
		public static CharacterMatcherItem PrepareCharacterForSpiritualWanderPlace => Instance[(byte)11];

		/// <summary>
		/// 可被悬赏
		/// </summary>
		public static CharacterMatcherItem CanHaveBounty => Instance[(byte)12];

		/// <summary>
		/// 可被入魔人攻击
		/// </summary>
		public static CharacterMatcherItem CanBeAttackedByInfectedCharacter => Instance[(byte)13];

		/// <summary>
		/// 可被随机敌人袭击
		/// </summary>
		public static CharacterMatcherItem CanBeAttackedByRandomEnemy => Instance[(byte)14];

		/// <summary>
		/// 可被动脱离队伍
		/// </summary>
		public static CharacterMatcherItem CanBeRemovedFromGroup => Instance[(byte)15];

		/// <summary>
		/// 太吾村商人自动行为目标
		/// </summary>
		public static CharacterMatcherItem CanBeMerchantAutoActionTarget => Instance[(byte)16];

		/// <summary>
		/// 可成为姬兮击杀目标
		/// </summary>
		public static CharacterMatcherItem CanBeJixiKillingTarget => Instance[(byte)17];

		/// <summary>
		/// 可为村民安排工作
		/// </summary>
		public static CharacterMatcherItem VillagerAvailableForWork => Instance[(byte)18];

		/// <summary>
		/// 可设置为经营建筑学徒
		/// </summary>
		public static CharacterMatcherItem ChildVillagerAvailableForWork => Instance[(byte)7];

		/// <summary>
		/// 可成为狮相互动添加对象
		/// </summary>
		public static CharacterMatcherItem InteractWithShixiangMemberEventTarget => Instance[(byte)19];

		/// <summary>
		/// 可成为峨眉地区主线中被袭击的对象
		/// </summary>
		public static CharacterMatcherItem EmeiPotentialVictims => Instance[(byte)20];

		/// <summary>
		/// 可发起邀约
		/// </summary>
		public static CharacterMatcherItem CanMakeAppointment => Instance[(byte)53];

		/// <summary>
		/// 在所属定居点
		/// </summary>
		public static CharacterMatcherItem InSettlement => Instance[(byte)55];

		/// <summary>
		/// 可赴宴的非村民宾客
		/// </summary>
		public static CharacterMatcherItem CanJoinFeast => Instance[(byte)56];

		/// <summary>
		/// 可成为姬兮吸取内力目标
		/// </summary>
		public static CharacterMatcherItem CanBeJixiDrainTarget => Instance[(byte)57];

		/// <summary>
		/// 可指定姬兮吸取内力的目标
		/// </summary>
		public static CharacterMatcherItem CanBeSelectJixiDrainTarget => Instance[(byte)58];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static CharacterMatcher Instance = new CharacterMatcher();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "MerchantType", "Organization", "SubConditions", "TargetSubConditions", "TemplateId", "FavorRange", "TargetKey" };

	internal override int ToInt(byte value)
	{
		return value;
	}

	internal override byte ToTemplateId(int value)
	{
		return (byte)value;
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
