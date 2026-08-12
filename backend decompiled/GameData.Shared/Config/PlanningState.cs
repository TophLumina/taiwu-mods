using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class PlanningState : ConfigData<PlanningStateItem, int>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 整数
		/// </summary>
		public const int IntegerParameter = 0;

		/// <summary>
		/// 目标需要资源
		/// </summary>
		public const int RequiredResourceAmount = 1;

		/// <summary>
		/// 目标购入价格
		/// </summary>
		public const int ItemPurchasePrice = 2;

		/// <summary>
		/// 目标道具可预定
		/// </summary>
		public const int ItemCanMakeArtisanOrder = 602;

		/// <summary>
		/// 目标道具存在订单
		/// </summary>
		public const int ItemSubscribed = 603;

		/// <summary>
		/// 道具品级
		/// </summary>
		public const int ItemGrade = 392;

		/// <summary>
		/// 道具耐久度
		/// </summary>
		public const int ItemDurability = 394;

		/// <summary>
		/// 道具最大耐久度
		/// </summary>
		public const int ItemMaxDurability = 395;

		/// <summary>
		/// 道具为武学书籍
		/// </summary>
		public const int ItemIsCombatSkillBook = 610;

		/// <summary>
		/// 道具为技艺书籍
		/// </summary>
		public const int ItemIsLifeSkillBook = 611;

		/// <summary>
		/// 目标武学造诣
		/// </summary>
		public const int RequiredCombatSkillAttainment = 3;

		/// <summary>
		/// 目标技艺造诣
		/// </summary>
		public const int RequiredLifeSkillAttainment = 4;

		/// <summary>
		/// 伏虞心念
		/// </summary>
		public const int FuyuFaith = 5;

		/// <summary>
		/// 主要属性当前值
		/// </summary>
		public const int CurrMainAttribute = 6;

		/// <summary>
		/// 膂力
		/// </summary>
		public const int CurrMainAttributeStrength = 7;

		/// <summary>
		/// 悟性
		/// </summary>
		public const int CurrMainAttributeIntelligent = 12;

		/// <summary>
		/// 对方主要属性当前值
		/// </summary>
		public const int TargetCurrMainAttribute = 13;

		/// <summary>
		/// 对方膂力
		/// </summary>
		public const int TargetCurrMainAttributeStrength = 14;

		/// <summary>
		/// 对方悟性
		/// </summary>
		public const int TargetCurrMainAttributeIntelligent = 19;

		/// <summary>
		/// 主要属性最大值
		/// </summary>
		public const int MaxMainAttribute = 20;

		/// <summary>
		/// 膂力最大值
		/// </summary>
		public const int MaxMainAttributeStrength = 21;

		/// <summary>
		/// 悟性最大值
		/// </summary>
		public const int MaxMainAttributeIntelligent = 26;

		/// <summary>
		/// 对方主要属性最大值
		/// </summary>
		public const int TargetMaxMainAttribute = 27;

		/// <summary>
		/// 对方膂力最大值
		/// </summary>
		public const int TargetMaxMainAttributeStrength = 28;

		/// <summary>
		/// 对方悟性最大值
		/// </summary>
		public const int TargetMaxMainAttributeIntelligent = 33;

		/// <summary>
		/// 性别
		/// </summary>
		public const int Gender = 34;

		/// <summary>
		/// 魅力
		/// </summary>
		public const int Attraction = 35;

		/// <summary>
		/// 立场
		/// </summary>
		public const int Morality = 36;

		/// <summary>
		/// 身份品级
		/// </summary>
		public const int InteractionGrade = 37;

		/// <summary>
		/// 出家
		/// </summary>
		public const int IsMonk = 600;

		/// <summary>
		/// 志向资历
		/// </summary>
		public const int CurrProfessionSeniority = 38;

		/// <summary>
		/// 资源满足阈值
		/// </summary>
		public const int ResourceSatisfyingThreshold = 39;

		/// <summary>
		/// 道具满足阈值
		/// </summary>
		public const int ItemSatisfyingThreshold = 40;

		/// <summary>
		/// 持有秘闻
		/// </summary>
		public const int KnowSecrets = 41;

		/// <summary>
		/// 名誉
		/// </summary>
		public const int Fame = 42;

		/// <summary>
		/// 心情
		/// </summary>
		public const int Happiness = 43;

		/// <summary>
		/// 好感
		/// </summary>
		public const int SelfToTargetFavorability = 44;

		/// <summary>
		/// 身龄
		/// </summary>
		public const int CurrAge = 45;

		/// <summary>
		/// 命龄
		/// </summary>
		public const int ActualAge = 46;

		/// <summary>
		/// 轮回数
		/// </summary>
		public const int ReincarnationCount = 47;

		/// <summary>
		/// 历练
		/// </summary>
		public const int Exp = 48;

		/// <summary>
		/// 战斗力
		/// </summary>
		public const int CombatPower = 49;

		/// <summary>
		/// 势力值
		/// </summary>
		public const int InfluencePower = 50;

		/// <summary>
		/// 精纯
		/// </summary>
		public const int ConsummateLevel = 51;

		/// <summary>
		/// 内力
		/// </summary>
		public const int Neili = 52;

		/// <summary>
		/// 最大内力
		/// </summary>
		public const int MaxNeili = 53;

		/// <summary>
		/// 健康
		/// </summary>
		public const int Health = 55;

		/// <summary>
		/// 最大健康
		/// </summary>
		public const int LeftMaxHealth = 56;

		/// <summary>
		/// 伤势
		/// </summary>
		public const int Injuries = 57;

		/// <summary>
		/// 毒素
		/// </summary>
		public const int Poisoned = 58;

		/// <summary>
		/// 内息紊乱
		/// </summary>
		public const int DisorderOfQi = 59;

		/// <summary>
		/// 玄灰
		/// </summary>
		public const int DarkAsh = 60;

		/// <summary>
		/// 蛊虫
		/// </summary>
		public const int Wug = 61;

		/// <summary>
		/// 坏蛊虫
		/// </summary>
		public const int BadWug = 62;

		/// <summary>
		/// 王蛊
		/// </summary>
		public const int WugKing = 63;

		/// <summary>
		/// 有任意受损
		/// </summary>
		public const int NeedHealing = 64;

		/// <summary>
		/// 相枢入邪值
		/// </summary>
		public const int XiangshuInfection = 65;

		/// <summary>
		/// 相枢入邪
		/// </summary>
		public const int XiangshuCompletelyInfected = 66;

		/// <summary>
		/// 相枢入魔
		/// </summary>
		public const int XiangshuPartiallyInfected = 67;

		/// <summary>
		/// 对方魅力
		/// </summary>
		public const int TargetAttraction = 72;

		/// <summary>
		/// 对方持有秘闻
		/// </summary>
		public const int TargetKnowSecrets = 78;

		/// <summary>
		/// 对方心情
		/// </summary>
		public const int TargetHappiness = 80;

		/// <summary>
		/// 对方好感
		/// </summary>
		public const int TargetToSelfFavorability = 81;

		/// <summary>
		/// 对方身龄
		/// </summary>
		public const int TargetCurrAge = 82;

		/// <summary>
		/// 对方命龄
		/// </summary>
		public const int TargetActualAge = 83;

		/// <summary>
		/// 对方势力值
		/// </summary>
		public const int TargetInfluencePower = 87;

		/// <summary>
		/// 对方健康
		/// </summary>
		public const int TargetHealth = 92;

		/// <summary>
		/// 对方伤势
		/// </summary>
		public const int TargetInjuries = 94;

		/// <summary>
		/// 对方毒素
		/// </summary>
		public const int TargetPoisoned = 95;

		/// <summary>
		/// 对方内息紊乱
		/// </summary>
		public const int TargetDisorderOfQi = 96;

		/// <summary>
		/// 对方蛊虫
		/// </summary>
		public const int TargetWug = 98;

		/// <summary>
		/// 对方相枢入邪值
		/// </summary>
		public const int TargetXiangshuInfection = 102;

		/// <summary>
		/// 对方相枢入邪
		/// </summary>
		public const int TargetPartiallyInfected = 103;

		/// <summary>
		/// 对方相枢入魔
		/// </summary>
		public const int TargetCompletelyInfected = 104;

		/// <summary>
		/// 对方被绑架
		/// </summary>
		public const int TargetIsKidnapped = 106;

		/// <summary>
		/// 对方死亡
		/// </summary>
		public const int TargetDead = 107;

		/// <summary>
		/// 装备负重
		/// </summary>
		public const int EquipmentLoad = 108;

		/// <summary>
		/// 行囊负重
		/// </summary>
		public const int InventoryLoad = 109;

		/// <summary>
		/// 最大装备负重
		/// </summary>
		public const int EquipmentMaxLoad = 110;

		/// <summary>
		/// 最大行囊负重
		/// </summary>
		public const int InventoryMaxLoad = 111;

		/// <summary>
		/// 持有道具价值
		/// </summary>
		public const int InventoryItemValue = 112;

		/// <summary>
		/// 丹药总价值
		/// </summary>
		public const int MedicineTotalWorth = 113;

		/// <summary>
		/// 毒药总价值
		/// </summary>
		public const int PoisonTotalWorth = 114;

		/// <summary>
		/// 七元
		/// </summary>
		public const int Personality = 115;

		/// <summary>
		/// 冷静
		/// </summary>
		public const int PersonalityCalm = 116;

		/// <summary>
		/// 合道
		/// </summary>
		public const int PersonalityPerceptive = 122;

		/// <summary>
		/// 武学资质
		/// </summary>
		public const int CombatSkillQualification = 131;

		/// <summary>
		/// 内功资质
		/// </summary>
		public const int CombatSkillQualificationNeigong = 132;

		/// <summary>
		/// 乐器资质
		/// </summary>
		public const int CombatSkillQualificationMusic = 145;

		/// <summary>
		/// 对方武学资质
		/// </summary>
		public const int TargetCombatSkillQualification = 146;

		/// <summary>
		/// 对方内功资质
		/// </summary>
		public const int TargetCombatSkillQualificationNeigong = 147;

		/// <summary>
		/// 对方乐器资质
		/// </summary>
		public const int TargetCombatSkillQualificationMusic = 160;

		/// <summary>
		/// 技艺资质
		/// </summary>
		public const int LifeSkillQualification = 161;

		/// <summary>
		/// 音律资质
		/// </summary>
		public const int LifeSkillQualificationMusic = 162;

		/// <summary>
		/// 杂学资质
		/// </summary>
		public const int LifeSkillQualificationEclectic = 177;

		/// <summary>
		/// 对方技艺资质
		/// </summary>
		public const int TargetLifeSkillQualification = 178;

		/// <summary>
		/// 对方音律资质
		/// </summary>
		public const int TargetLifeSkillQualificationMusic = 179;

		/// <summary>
		/// 对方杂学资质
		/// </summary>
		public const int TargetLifeSkillQualificationEclectic = 194;

		/// <summary>
		/// 武学造诣
		/// </summary>
		public const int CombatSkillAttainment = 195;

		/// <summary>
		/// 内功造诣
		/// </summary>
		public const int CombatSkillAttainmentNeigong = 196;

		/// <summary>
		/// 乐器造诣
		/// </summary>
		public const int CombatSkillAttainmentMusic = 209;

		/// <summary>
		/// 对方武学造诣
		/// </summary>
		public const int TargetCombatSkillAttainment = 211;

		/// <summary>
		/// 对方内功造诣
		/// </summary>
		public const int TargetCombatSkillAttainmentNeigong = 212;

		/// <summary>
		/// 对方乐器造诣
		/// </summary>
		public const int TargetCombatSkillAttainmentMusic = 225;

		/// <summary>
		/// 技艺造诣
		/// </summary>
		public const int LifeSkillAttainment = 227;

		/// <summary>
		/// 音律造诣
		/// </summary>
		public const int LifeSkillAttainmentMusic = 228;

		/// <summary>
		/// 杂学造诣
		/// </summary>
		public const int LifeSkillAttainmentEclectic = 243;

		/// <summary>
		/// 制造造诣
		/// </summary>
		public const int LifeSkillAttainmentCrafting = 244;

		/// <summary>
		/// 最高技艺造诣
		/// </summary>
		public const int MaxLifeSkillQualification = 246;

		/// <summary>
		/// 对方技艺造诣
		/// </summary>
		public const int TargetLifeSkillAttainment = 247;

		/// <summary>
		/// 对方音律造诣
		/// </summary>
		public const int TargetLifeSkillAttainmentMusic = 248;

		/// <summary>
		/// 对方杂学造诣
		/// </summary>
		public const int TargetLifeSkillAttainmentEclectic = 263;

		/// <summary>
		/// 对方制造造诣
		/// </summary>
		public const int TargetLifeSkillAttainmentCraft = 264;

		/// <summary>
		/// 获得朋友关系
		/// </summary>
		public const int FriendRelationAdded = 267;

		/// <summary>
		/// 获得派系关系
		/// </summary>
		public const int FactionRelationAdded = 268;

		/// <summary>
		/// 获得义亲关系
		/// </summary>
		public const int AdoptedRelationAdded = 269;

		/// <summary>
		/// 获得夫妻关系
		/// </summary>
		public const int SpouseRelationAdded = 270;

		/// <summary>
		/// 获得结义关系
		/// </summary>
		public const int SwornRelationAdded = 271;

		/// <summary>
		/// 获得伴侣关系
		/// </summary>
		public const int CoupleRelationAdded = 272;

		/// <summary>
		/// 获得仇敌关系
		/// </summary>
		public const int EnemyRelationAdded = 274;

		/// <summary>
		/// 解除夫妻关系
		/// </summary>
		public const int SpouseRelationEnded = 280;

		/// <summary>
		/// 解除伴侣关系
		/// </summary>
		public const int CoupleRelationEnded = 282;

		/// <summary>
		/// 朋友人数
		/// </summary>
		public const int FriendRelationCount = 287;

		/// <summary>
		/// 父母人数
		/// </summary>
		public const int ParentRelationCount = 607;

		/// <summary>
		/// 手足人数
		/// </summary>
		public const int SiblingRelationCount = 608;

		/// <summary>
		/// 子女人数
		/// </summary>
		public const int ChildrenRlationCount = 609;

		/// <summary>
		/// 派系人数
		/// </summary>
		public const int FactionRelationCount = 288;

		/// <summary>
		/// 义亲人数
		/// </summary>
		public const int AdoptiveRelatioinCount = 289;

		/// <summary>
		/// 夫妻人数
		/// </summary>
		public const int SpouseRelationCount = 290;

		/// <summary>
		/// 结义人数
		/// </summary>
		public const int SwornBrotherhoodRelationCount = 291;

		/// <summary>
		/// 伴侣人数
		/// </summary>
		public const int TwoWayAdoredRelationCount = 292;

		/// <summary>
		/// 爱慕人数
		/// </summary>
		public const int AdoredRelationCount = 293;

		/// <summary>
		/// 仇敌人数
		/// </summary>
		public const int EnemyRelationCount = 294;

		/// <summary>
		/// 师徒人数
		/// </summary>
		public const int MentorMenteeRelationCount = 295;

		/// <summary>
		/// 是太吾
		/// </summary>
		public const int IsTaiwu = 296;

		/// <summary>
		/// 是逃犯
		/// </summary>
		public const int IsFugitive = 297;

		/// <summary>
		/// 对方为爱慕
		/// </summary>
		public const int TargetAdoreSelf = 302;

		/// <summary>
		/// 对方为仇敌
		/// </summary>
		public const int TargetEnemySelf = 303;

		/// <summary>
		/// 对方是亲友
		/// </summary>
		public const int TargetIsFriendOrFamily = 304;

		/// <summary>
		/// 对方为父母
		/// </summary>
		public const int TargetIsParent = 305;

		/// <summary>
		/// 对方为手足
		/// </summary>
		public const int TargetIsSibling = 306;

		/// <summary>
		/// 对方为子女
		/// </summary>
		public const int TargetIsChild = 307;

		/// <summary>
		/// 对方为朋友
		/// </summary>
		public const int TargetIsFriend = 308;

		/// <summary>
		/// 对方为义亲
		/// </summary>
		public const int TargetIsAdoptiveFamily = 309;

		/// <summary>
		/// 对方为夫妻
		/// </summary>
		public const int TargetIsSpouse = 310;

		/// <summary>
		/// 对方为结义
		/// </summary>
		public const int TargetIsSwornBrotherOrSister = 311;

		/// <summary>
		/// 对方为伴侣
		/// </summary>
		public const int TargetIsTwoWayAdored = 312;

		/// <summary>
		/// 对方为师徒
		/// </summary>
		public const int TargetIsMentorOrMentee = 313;

		/// <summary>
		/// 对方为派系
		/// </summary>
		public const int TargetIsFromSameFaction = 314;

		/// <summary>
		/// 对方为同门
		/// </summary>
		public const int TargetIsFromSameSettlement = 315;

		/// <summary>
		/// 对方为同乡
		/// </summary>
		public const int TargetIsFromSameArea = 316;

		/// <summary>
		/// 从属门派
		/// </summary>
		public const int IsSectMember = 317;

		/// <summary>
		/// 从属城镇
		/// </summary>
		public const int IsCivilian = 318;

		/// <summary>
		/// 从属其他
		/// </summary>
		public const int TargetIsOtherMember = 606;

		/// <summary>
		/// 从属外道
		/// </summary>
		public const int IsHeretic = 319;

		/// <summary>
		/// 从属义士
		/// </summary>
		public const int IsRightous = 320;

		/// <summary>
		/// 从属太吾
		/// </summary>
		public const int IsTaiwuVillageMember = 321;

		/// <summary>
		/// 从属爪牙
		/// </summary>
		public const int IsXiangshuMinion = 322;

		/// <summary>
		/// 从属野兽
		/// </summary>
		public const int IsAnimal = 323;

		/// <summary>
		/// 从属邪派门派
		/// </summary>
		public const int IsEvilSectMember = 331;

		/// <summary>
		/// 从属正派门派
		/// </summary>
		public const int IsGoodSectMember = 332;

		/// <summary>
		/// 从属中立门派
		/// </summary>
		public const int IsNeutralSectMember = 333;

		/// <summary>
		/// 志向为山人
		/// </summary>
		public const int ProfessionIsSavage = 337;

		/// <summary>
		/// 志向为猎户
		/// </summary>
		public const int ProfessionIsHunter = 338;

		/// <summary>
		/// 志向为匠人
		/// </summary>
		public const int ProfessionIsCraft = 339;

		/// <summary>
		/// 志向为武师
		/// </summary>
		public const int ProfessionIsMartialArtist = 340;

		/// <summary>
		/// 志向为才俊
		/// </summary>
		public const int ProfessionIsLiterati = 341;

		/// <summary>
		/// 志向为道长
		/// </summary>
		public const int ProfessionIsTaoistMonk = 342;

		/// <summary>
		/// 志向为高僧
		/// </summary>
		public const int ProfessionIsBuddhistMonk = 343;

		/// <summary>
		/// 志向为豪客
		/// </summary>
		public const int ProfessionIsWineTaster = 344;

		/// <summary>
		/// 志向为名门
		/// </summary>
		public const int ProfessionIsAristocrat = 345;

		/// <summary>
		/// 志向为乞丐
		/// </summary>
		public const int ProfessionIsBeggar = 346;

		/// <summary>
		/// 志向为平民
		/// </summary>
		public const int ProfessionIsCivilian = 347;

		/// <summary>
		/// 志向为旅人
		/// </summary>
		public const int ProfessionIsTraveler = 348;

		/// <summary>
		/// 志向为云游僧
		/// </summary>
		public const int ProfessionIsTravelingBuddhistMonk = 349;

		/// <summary>
		/// 志向为大夫
		/// </summary>
		public const int ProfessionIsDoctor = 350;

		/// <summary>
		/// 志向为云游道
		/// </summary>
		public const int ProfessionIsTravelingTaoistMonk = 351;

		/// <summary>
		/// 志向为富商
		/// </summary>
		public const int ProfessionIsCapitalist = 352;

		/// <summary>
		/// 志向为贵客
		/// </summary>
		public const int ProfessionIsTeaTaster = 353;

		/// <summary>
		/// 志向为王公
		/// </summary>
		public const int ProfessionIsDuke = 354;

		/// <summary>
		/// 资源
		/// </summary>
		public const int Resource = 355;

		/// <summary>
		/// 食材
		/// </summary>
		public const int ResourceFood = 356;

		/// <summary>
		/// 威望
		/// </summary>
		public const int ResourceAuthority = 363;

		/// <summary>
		/// 任意材料资源
		/// </summary>
		public const int MaterialResource = 364;

		/// <summary>
		/// 持有资源价值
		/// </summary>
		public const int ResourceTotalWorth = 365;

		/// <summary>
		/// 对方资源
		/// </summary>
		public const int TargetResource = 366;

		/// <summary>
		/// 对方食材
		/// </summary>
		public const int TargetFood = 367;

		/// <summary>
		/// 对方威望
		/// </summary>
		public const int TargetAuthority = 374;

		/// <summary>
		/// 对方任意材料资源
		/// </summary>
		public const int TargetMaterialResource = 375;

		/// <summary>
		/// 对方持有资源价值
		/// </summary>
		public const int TargetResourceTotalWorth = 376;

		/// <summary>
		/// 道具
		/// </summary>
		public const int Item = 391;

		/// <summary>
		/// 道具数量
		/// </summary>
		public const int ItemNumber = 393;

		/// <summary>
		/// 工具道具
		/// </summary>
		public const int CraftToolItem = 409;

		/// <summary>
		/// 心材道具
		/// </summary>
		public const int BuildingCoreItem = 410;

		/// <summary>
		/// 天劫符箓
		/// </summary>
		public const int TianjieFulu = 411;

		/// <summary>
		/// 野兽代步
		/// </summary>
		public const int AnimalCarrier = 412;

		/// <summary>
		/// 功法书籍
		/// </summary>
		public const int CombatSkillBook = 413;

		/// <summary>
		/// 技艺书籍
		/// </summary>
		public const int LifeSkillBook = 414;

		/// <summary>
		/// 疗伤道具
		/// </summary>
		public const int WoundRecoveryItem = 415;

		/// <summary>
		/// 毒药道具
		/// </summary>
		public const int PoisonItem = 416;

		/// <summary>
		/// 调息道具
		/// </summary>
		public const int QiRecoveryItem = 417;

		/// <summary>
		/// 解毒道具
		/// </summary>
		public const int DetoxPoisonItem = 418;

		/// <summary>
		/// 野果道具
		/// </summary>
		public const int FruitItem = 419;

		/// <summary>
		/// 内力道具
		/// </summary>
		public const int NeiliRecoveryItem = 420;

		/// <summary>
		/// 属性道具
		/// </summary>
		public const int AttributeRecoveryItem = 421;

		/// <summary>
		/// 健康道具
		/// </summary>
		public const int HealthRecoveryItem = 422;

		/// <summary>
		/// 解蛊道具
		/// </summary>
		public const int DetoxWugItem = 423;

		/// <summary>
		/// 酒类道具
		/// </summary>
		public const int Wine = 424;

		/// <summary>
		/// 茶类道具
		/// </summary>
		public const int Tea = 425;

		/// <summary>
		/// 公库贡献值
		/// </summary>
		public const int TreasuryContribution = 427;

		/// <summary>
		/// 坟墓耐久
		/// </summary>
		public const int GraveDurability = 432;

		/// <summary>
		/// 最大坟墓耐久
		/// </summary>
		public const int GraveMaxDurability = 433;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 整数
		/// </summary>
		public static PlanningStateItem IntegerParameter => Instance[0];

		/// <summary>
		/// 目标需要资源
		/// </summary>
		public static PlanningStateItem RequiredResourceAmount => Instance[1];

		/// <summary>
		/// 目标购入价格
		/// </summary>
		public static PlanningStateItem ItemPurchasePrice => Instance[2];

		/// <summary>
		/// 目标道具可预定
		/// </summary>
		public static PlanningStateItem ItemCanMakeArtisanOrder => Instance[602];

		/// <summary>
		/// 目标道具存在订单
		/// </summary>
		public static PlanningStateItem ItemSubscribed => Instance[603];

		/// <summary>
		/// 道具品级
		/// </summary>
		public static PlanningStateItem ItemGrade => Instance[392];

		/// <summary>
		/// 道具耐久度
		/// </summary>
		public static PlanningStateItem ItemDurability => Instance[394];

		/// <summary>
		/// 道具最大耐久度
		/// </summary>
		public static PlanningStateItem ItemMaxDurability => Instance[395];

		/// <summary>
		/// 道具为武学书籍
		/// </summary>
		public static PlanningStateItem ItemIsCombatSkillBook => Instance[610];

		/// <summary>
		/// 道具为技艺书籍
		/// </summary>
		public static PlanningStateItem ItemIsLifeSkillBook => Instance[611];

		/// <summary>
		/// 目标武学造诣
		/// </summary>
		public static PlanningStateItem RequiredCombatSkillAttainment => Instance[3];

		/// <summary>
		/// 目标技艺造诣
		/// </summary>
		public static PlanningStateItem RequiredLifeSkillAttainment => Instance[4];

		/// <summary>
		/// 伏虞心念
		/// </summary>
		public static PlanningStateItem FuyuFaith => Instance[5];

		/// <summary>
		/// 主要属性当前值
		/// </summary>
		public static PlanningStateItem CurrMainAttribute => Instance[6];

		/// <summary>
		/// 膂力
		/// </summary>
		public static PlanningStateItem CurrMainAttributeStrength => Instance[7];

		/// <summary>
		/// 悟性
		/// </summary>
		public static PlanningStateItem CurrMainAttributeIntelligent => Instance[12];

		/// <summary>
		/// 对方主要属性当前值
		/// </summary>
		public static PlanningStateItem TargetCurrMainAttribute => Instance[13];

		/// <summary>
		/// 对方膂力
		/// </summary>
		public static PlanningStateItem TargetCurrMainAttributeStrength => Instance[14];

		/// <summary>
		/// 对方悟性
		/// </summary>
		public static PlanningStateItem TargetCurrMainAttributeIntelligent => Instance[19];

		/// <summary>
		/// 主要属性最大值
		/// </summary>
		public static PlanningStateItem MaxMainAttribute => Instance[20];

		/// <summary>
		/// 膂力最大值
		/// </summary>
		public static PlanningStateItem MaxMainAttributeStrength => Instance[21];

		/// <summary>
		/// 悟性最大值
		/// </summary>
		public static PlanningStateItem MaxMainAttributeIntelligent => Instance[26];

		/// <summary>
		/// 对方主要属性最大值
		/// </summary>
		public static PlanningStateItem TargetMaxMainAttribute => Instance[27];

		/// <summary>
		/// 对方膂力最大值
		/// </summary>
		public static PlanningStateItem TargetMaxMainAttributeStrength => Instance[28];

		/// <summary>
		/// 对方悟性最大值
		/// </summary>
		public static PlanningStateItem TargetMaxMainAttributeIntelligent => Instance[33];

		/// <summary>
		/// 性别
		/// </summary>
		public static PlanningStateItem Gender => Instance[34];

		/// <summary>
		/// 魅力
		/// </summary>
		public static PlanningStateItem Attraction => Instance[35];

		/// <summary>
		/// 立场
		/// </summary>
		public static PlanningStateItem Morality => Instance[36];

		/// <summary>
		/// 身份品级
		/// </summary>
		public static PlanningStateItem InteractionGrade => Instance[37];

		/// <summary>
		/// 出家
		/// </summary>
		public static PlanningStateItem IsMonk => Instance[600];

		/// <summary>
		/// 志向资历
		/// </summary>
		public static PlanningStateItem CurrProfessionSeniority => Instance[38];

		/// <summary>
		/// 资源满足阈值
		/// </summary>
		public static PlanningStateItem ResourceSatisfyingThreshold => Instance[39];

		/// <summary>
		/// 道具满足阈值
		/// </summary>
		public static PlanningStateItem ItemSatisfyingThreshold => Instance[40];

		/// <summary>
		/// 持有秘闻
		/// </summary>
		public static PlanningStateItem KnowSecrets => Instance[41];

		/// <summary>
		/// 名誉
		/// </summary>
		public static PlanningStateItem Fame => Instance[42];

		/// <summary>
		/// 心情
		/// </summary>
		public static PlanningStateItem Happiness => Instance[43];

		/// <summary>
		/// 好感
		/// </summary>
		public static PlanningStateItem SelfToTargetFavorability => Instance[44];

		/// <summary>
		/// 身龄
		/// </summary>
		public static PlanningStateItem CurrAge => Instance[45];

		/// <summary>
		/// 命龄
		/// </summary>
		public static PlanningStateItem ActualAge => Instance[46];

		/// <summary>
		/// 轮回数
		/// </summary>
		public static PlanningStateItem ReincarnationCount => Instance[47];

		/// <summary>
		/// 历练
		/// </summary>
		public static PlanningStateItem Exp => Instance[48];

		/// <summary>
		/// 战斗力
		/// </summary>
		public static PlanningStateItem CombatPower => Instance[49];

		/// <summary>
		/// 势力值
		/// </summary>
		public static PlanningStateItem InfluencePower => Instance[50];

		/// <summary>
		/// 精纯
		/// </summary>
		public static PlanningStateItem ConsummateLevel => Instance[51];

		/// <summary>
		/// 内力
		/// </summary>
		public static PlanningStateItem Neili => Instance[52];

		/// <summary>
		/// 最大内力
		/// </summary>
		public static PlanningStateItem MaxNeili => Instance[53];

		/// <summary>
		/// 健康
		/// </summary>
		public static PlanningStateItem Health => Instance[55];

		/// <summary>
		/// 最大健康
		/// </summary>
		public static PlanningStateItem LeftMaxHealth => Instance[56];

		/// <summary>
		/// 伤势
		/// </summary>
		public static PlanningStateItem Injuries => Instance[57];

		/// <summary>
		/// 毒素
		/// </summary>
		public static PlanningStateItem Poisoned => Instance[58];

		/// <summary>
		/// 内息紊乱
		/// </summary>
		public static PlanningStateItem DisorderOfQi => Instance[59];

		/// <summary>
		/// 玄灰
		/// </summary>
		public static PlanningStateItem DarkAsh => Instance[60];

		/// <summary>
		/// 蛊虫
		/// </summary>
		public static PlanningStateItem Wug => Instance[61];

		/// <summary>
		/// 坏蛊虫
		/// </summary>
		public static PlanningStateItem BadWug => Instance[62];

		/// <summary>
		/// 王蛊
		/// </summary>
		public static PlanningStateItem WugKing => Instance[63];

		/// <summary>
		/// 有任意受损
		/// </summary>
		public static PlanningStateItem NeedHealing => Instance[64];

		/// <summary>
		/// 相枢入邪值
		/// </summary>
		public static PlanningStateItem XiangshuInfection => Instance[65];

		/// <summary>
		/// 相枢入邪
		/// </summary>
		public static PlanningStateItem XiangshuCompletelyInfected => Instance[66];

		/// <summary>
		/// 相枢入魔
		/// </summary>
		public static PlanningStateItem XiangshuPartiallyInfected => Instance[67];

		/// <summary>
		/// 对方魅力
		/// </summary>
		public static PlanningStateItem TargetAttraction => Instance[72];

		/// <summary>
		/// 对方持有秘闻
		/// </summary>
		public static PlanningStateItem TargetKnowSecrets => Instance[78];

		/// <summary>
		/// 对方心情
		/// </summary>
		public static PlanningStateItem TargetHappiness => Instance[80];

		/// <summary>
		/// 对方好感
		/// </summary>
		public static PlanningStateItem TargetToSelfFavorability => Instance[81];

		/// <summary>
		/// 对方身龄
		/// </summary>
		public static PlanningStateItem TargetCurrAge => Instance[82];

		/// <summary>
		/// 对方命龄
		/// </summary>
		public static PlanningStateItem TargetActualAge => Instance[83];

		/// <summary>
		/// 对方势力值
		/// </summary>
		public static PlanningStateItem TargetInfluencePower => Instance[87];

		/// <summary>
		/// 对方健康
		/// </summary>
		public static PlanningStateItem TargetHealth => Instance[92];

		/// <summary>
		/// 对方伤势
		/// </summary>
		public static PlanningStateItem TargetInjuries => Instance[94];

		/// <summary>
		/// 对方毒素
		/// </summary>
		public static PlanningStateItem TargetPoisoned => Instance[95];

		/// <summary>
		/// 对方内息紊乱
		/// </summary>
		public static PlanningStateItem TargetDisorderOfQi => Instance[96];

		/// <summary>
		/// 对方蛊虫
		/// </summary>
		public static PlanningStateItem TargetWug => Instance[98];

		/// <summary>
		/// 对方相枢入邪值
		/// </summary>
		public static PlanningStateItem TargetXiangshuInfection => Instance[102];

		/// <summary>
		/// 对方相枢入邪
		/// </summary>
		public static PlanningStateItem TargetPartiallyInfected => Instance[103];

		/// <summary>
		/// 对方相枢入魔
		/// </summary>
		public static PlanningStateItem TargetCompletelyInfected => Instance[104];

		/// <summary>
		/// 对方被绑架
		/// </summary>
		public static PlanningStateItem TargetIsKidnapped => Instance[106];

		/// <summary>
		/// 对方死亡
		/// </summary>
		public static PlanningStateItem TargetDead => Instance[107];

		/// <summary>
		/// 装备负重
		/// </summary>
		public static PlanningStateItem EquipmentLoad => Instance[108];

		/// <summary>
		/// 行囊负重
		/// </summary>
		public static PlanningStateItem InventoryLoad => Instance[109];

		/// <summary>
		/// 最大装备负重
		/// </summary>
		public static PlanningStateItem EquipmentMaxLoad => Instance[110];

		/// <summary>
		/// 最大行囊负重
		/// </summary>
		public static PlanningStateItem InventoryMaxLoad => Instance[111];

		/// <summary>
		/// 持有道具价值
		/// </summary>
		public static PlanningStateItem InventoryItemValue => Instance[112];

		/// <summary>
		/// 丹药总价值
		/// </summary>
		public static PlanningStateItem MedicineTotalWorth => Instance[113];

		/// <summary>
		/// 毒药总价值
		/// </summary>
		public static PlanningStateItem PoisonTotalWorth => Instance[114];

		/// <summary>
		/// 七元
		/// </summary>
		public static PlanningStateItem Personality => Instance[115];

		/// <summary>
		/// 冷静
		/// </summary>
		public static PlanningStateItem PersonalityCalm => Instance[116];

		/// <summary>
		/// 合道
		/// </summary>
		public static PlanningStateItem PersonalityPerceptive => Instance[122];

		/// <summary>
		/// 武学资质
		/// </summary>
		public static PlanningStateItem CombatSkillQualification => Instance[131];

		/// <summary>
		/// 内功资质
		/// </summary>
		public static PlanningStateItem CombatSkillQualificationNeigong => Instance[132];

		/// <summary>
		/// 乐器资质
		/// </summary>
		public static PlanningStateItem CombatSkillQualificationMusic => Instance[145];

		/// <summary>
		/// 对方武学资质
		/// </summary>
		public static PlanningStateItem TargetCombatSkillQualification => Instance[146];

		/// <summary>
		/// 对方内功资质
		/// </summary>
		public static PlanningStateItem TargetCombatSkillQualificationNeigong => Instance[147];

		/// <summary>
		/// 对方乐器资质
		/// </summary>
		public static PlanningStateItem TargetCombatSkillQualificationMusic => Instance[160];

		/// <summary>
		/// 技艺资质
		/// </summary>
		public static PlanningStateItem LifeSkillQualification => Instance[161];

		/// <summary>
		/// 音律资质
		/// </summary>
		public static PlanningStateItem LifeSkillQualificationMusic => Instance[162];

		/// <summary>
		/// 杂学资质
		/// </summary>
		public static PlanningStateItem LifeSkillQualificationEclectic => Instance[177];

		/// <summary>
		/// 对方技艺资质
		/// </summary>
		public static PlanningStateItem TargetLifeSkillQualification => Instance[178];

		/// <summary>
		/// 对方音律资质
		/// </summary>
		public static PlanningStateItem TargetLifeSkillQualificationMusic => Instance[179];

		/// <summary>
		/// 对方杂学资质
		/// </summary>
		public static PlanningStateItem TargetLifeSkillQualificationEclectic => Instance[194];

		/// <summary>
		/// 武学造诣
		/// </summary>
		public static PlanningStateItem CombatSkillAttainment => Instance[195];

		/// <summary>
		/// 内功造诣
		/// </summary>
		public static PlanningStateItem CombatSkillAttainmentNeigong => Instance[196];

		/// <summary>
		/// 乐器造诣
		/// </summary>
		public static PlanningStateItem CombatSkillAttainmentMusic => Instance[209];

		/// <summary>
		/// 对方武学造诣
		/// </summary>
		public static PlanningStateItem TargetCombatSkillAttainment => Instance[211];

		/// <summary>
		/// 对方内功造诣
		/// </summary>
		public static PlanningStateItem TargetCombatSkillAttainmentNeigong => Instance[212];

		/// <summary>
		/// 对方乐器造诣
		/// </summary>
		public static PlanningStateItem TargetCombatSkillAttainmentMusic => Instance[225];

		/// <summary>
		/// 技艺造诣
		/// </summary>
		public static PlanningStateItem LifeSkillAttainment => Instance[227];

		/// <summary>
		/// 音律造诣
		/// </summary>
		public static PlanningStateItem LifeSkillAttainmentMusic => Instance[228];

		/// <summary>
		/// 杂学造诣
		/// </summary>
		public static PlanningStateItem LifeSkillAttainmentEclectic => Instance[243];

		/// <summary>
		/// 制造造诣
		/// </summary>
		public static PlanningStateItem LifeSkillAttainmentCrafting => Instance[244];

		/// <summary>
		/// 最高技艺造诣
		/// </summary>
		public static PlanningStateItem MaxLifeSkillQualification => Instance[246];

		/// <summary>
		/// 对方技艺造诣
		/// </summary>
		public static PlanningStateItem TargetLifeSkillAttainment => Instance[247];

		/// <summary>
		/// 对方音律造诣
		/// </summary>
		public static PlanningStateItem TargetLifeSkillAttainmentMusic => Instance[248];

		/// <summary>
		/// 对方杂学造诣
		/// </summary>
		public static PlanningStateItem TargetLifeSkillAttainmentEclectic => Instance[263];

		/// <summary>
		/// 对方制造造诣
		/// </summary>
		public static PlanningStateItem TargetLifeSkillAttainmentCraft => Instance[264];

		/// <summary>
		/// 获得朋友关系
		/// </summary>
		public static PlanningStateItem FriendRelationAdded => Instance[267];

		/// <summary>
		/// 获得派系关系
		/// </summary>
		public static PlanningStateItem FactionRelationAdded => Instance[268];

		/// <summary>
		/// 获得义亲关系
		/// </summary>
		public static PlanningStateItem AdoptedRelationAdded => Instance[269];

		/// <summary>
		/// 获得夫妻关系
		/// </summary>
		public static PlanningStateItem SpouseRelationAdded => Instance[270];

		/// <summary>
		/// 获得结义关系
		/// </summary>
		public static PlanningStateItem SwornRelationAdded => Instance[271];

		/// <summary>
		/// 获得伴侣关系
		/// </summary>
		public static PlanningStateItem CoupleRelationAdded => Instance[272];

		/// <summary>
		/// 获得仇敌关系
		/// </summary>
		public static PlanningStateItem EnemyRelationAdded => Instance[274];

		/// <summary>
		/// 解除夫妻关系
		/// </summary>
		public static PlanningStateItem SpouseRelationEnded => Instance[280];

		/// <summary>
		/// 解除伴侣关系
		/// </summary>
		public static PlanningStateItem CoupleRelationEnded => Instance[282];

		/// <summary>
		/// 朋友人数
		/// </summary>
		public static PlanningStateItem FriendRelationCount => Instance[287];

		/// <summary>
		/// 父母人数
		/// </summary>
		public static PlanningStateItem ParentRelationCount => Instance[607];

		/// <summary>
		/// 手足人数
		/// </summary>
		public static PlanningStateItem SiblingRelationCount => Instance[608];

		/// <summary>
		/// 子女人数
		/// </summary>
		public static PlanningStateItem ChildrenRlationCount => Instance[609];

		/// <summary>
		/// 派系人数
		/// </summary>
		public static PlanningStateItem FactionRelationCount => Instance[288];

		/// <summary>
		/// 义亲人数
		/// </summary>
		public static PlanningStateItem AdoptiveRelatioinCount => Instance[289];

		/// <summary>
		/// 夫妻人数
		/// </summary>
		public static PlanningStateItem SpouseRelationCount => Instance[290];

		/// <summary>
		/// 结义人数
		/// </summary>
		public static PlanningStateItem SwornBrotherhoodRelationCount => Instance[291];

		/// <summary>
		/// 伴侣人数
		/// </summary>
		public static PlanningStateItem TwoWayAdoredRelationCount => Instance[292];

		/// <summary>
		/// 爱慕人数
		/// </summary>
		public static PlanningStateItem AdoredRelationCount => Instance[293];

		/// <summary>
		/// 仇敌人数
		/// </summary>
		public static PlanningStateItem EnemyRelationCount => Instance[294];

		/// <summary>
		/// 师徒人数
		/// </summary>
		public static PlanningStateItem MentorMenteeRelationCount => Instance[295];

		/// <summary>
		/// 是太吾
		/// </summary>
		public static PlanningStateItem IsTaiwu => Instance[296];

		/// <summary>
		/// 是逃犯
		/// </summary>
		public static PlanningStateItem IsFugitive => Instance[297];

		/// <summary>
		/// 对方为爱慕
		/// </summary>
		public static PlanningStateItem TargetAdoreSelf => Instance[302];

		/// <summary>
		/// 对方为仇敌
		/// </summary>
		public static PlanningStateItem TargetEnemySelf => Instance[303];

		/// <summary>
		/// 对方是亲友
		/// </summary>
		public static PlanningStateItem TargetIsFriendOrFamily => Instance[304];

		/// <summary>
		/// 对方为父母
		/// </summary>
		public static PlanningStateItem TargetIsParent => Instance[305];

		/// <summary>
		/// 对方为手足
		/// </summary>
		public static PlanningStateItem TargetIsSibling => Instance[306];

		/// <summary>
		/// 对方为子女
		/// </summary>
		public static PlanningStateItem TargetIsChild => Instance[307];

		/// <summary>
		/// 对方为朋友
		/// </summary>
		public static PlanningStateItem TargetIsFriend => Instance[308];

		/// <summary>
		/// 对方为义亲
		/// </summary>
		public static PlanningStateItem TargetIsAdoptiveFamily => Instance[309];

		/// <summary>
		/// 对方为夫妻
		/// </summary>
		public static PlanningStateItem TargetIsSpouse => Instance[310];

		/// <summary>
		/// 对方为结义
		/// </summary>
		public static PlanningStateItem TargetIsSwornBrotherOrSister => Instance[311];

		/// <summary>
		/// 对方为伴侣
		/// </summary>
		public static PlanningStateItem TargetIsTwoWayAdored => Instance[312];

		/// <summary>
		/// 对方为师徒
		/// </summary>
		public static PlanningStateItem TargetIsMentorOrMentee => Instance[313];

		/// <summary>
		/// 对方为派系
		/// </summary>
		public static PlanningStateItem TargetIsFromSameFaction => Instance[314];

		/// <summary>
		/// 对方为同门
		/// </summary>
		public static PlanningStateItem TargetIsFromSameSettlement => Instance[315];

		/// <summary>
		/// 对方为同乡
		/// </summary>
		public static PlanningStateItem TargetIsFromSameArea => Instance[316];

		/// <summary>
		/// 从属门派
		/// </summary>
		public static PlanningStateItem IsSectMember => Instance[317];

		/// <summary>
		/// 从属城镇
		/// </summary>
		public static PlanningStateItem IsCivilian => Instance[318];

		/// <summary>
		/// 从属其他
		/// </summary>
		public static PlanningStateItem TargetIsOtherMember => Instance[606];

		/// <summary>
		/// 从属外道
		/// </summary>
		public static PlanningStateItem IsHeretic => Instance[319];

		/// <summary>
		/// 从属义士
		/// </summary>
		public static PlanningStateItem IsRightous => Instance[320];

		/// <summary>
		/// 从属太吾
		/// </summary>
		public static PlanningStateItem IsTaiwuVillageMember => Instance[321];

		/// <summary>
		/// 从属爪牙
		/// </summary>
		public static PlanningStateItem IsXiangshuMinion => Instance[322];

		/// <summary>
		/// 从属野兽
		/// </summary>
		public static PlanningStateItem IsAnimal => Instance[323];

		/// <summary>
		/// 从属邪派门派
		/// </summary>
		public static PlanningStateItem IsEvilSectMember => Instance[331];

		/// <summary>
		/// 从属正派门派
		/// </summary>
		public static PlanningStateItem IsGoodSectMember => Instance[332];

		/// <summary>
		/// 从属中立门派
		/// </summary>
		public static PlanningStateItem IsNeutralSectMember => Instance[333];

		/// <summary>
		/// 志向为山人
		/// </summary>
		public static PlanningStateItem ProfessionIsSavage => Instance[337];

		/// <summary>
		/// 志向为猎户
		/// </summary>
		public static PlanningStateItem ProfessionIsHunter => Instance[338];

		/// <summary>
		/// 志向为匠人
		/// </summary>
		public static PlanningStateItem ProfessionIsCraft => Instance[339];

		/// <summary>
		/// 志向为武师
		/// </summary>
		public static PlanningStateItem ProfessionIsMartialArtist => Instance[340];

		/// <summary>
		/// 志向为才俊
		/// </summary>
		public static PlanningStateItem ProfessionIsLiterati => Instance[341];

		/// <summary>
		/// 志向为道长
		/// </summary>
		public static PlanningStateItem ProfessionIsTaoistMonk => Instance[342];

		/// <summary>
		/// 志向为高僧
		/// </summary>
		public static PlanningStateItem ProfessionIsBuddhistMonk => Instance[343];

		/// <summary>
		/// 志向为豪客
		/// </summary>
		public static PlanningStateItem ProfessionIsWineTaster => Instance[344];

		/// <summary>
		/// 志向为名门
		/// </summary>
		public static PlanningStateItem ProfessionIsAristocrat => Instance[345];

		/// <summary>
		/// 志向为乞丐
		/// </summary>
		public static PlanningStateItem ProfessionIsBeggar => Instance[346];

		/// <summary>
		/// 志向为平民
		/// </summary>
		public static PlanningStateItem ProfessionIsCivilian => Instance[347];

		/// <summary>
		/// 志向为旅人
		/// </summary>
		public static PlanningStateItem ProfessionIsTraveler => Instance[348];

		/// <summary>
		/// 志向为云游僧
		/// </summary>
		public static PlanningStateItem ProfessionIsTravelingBuddhistMonk => Instance[349];

		/// <summary>
		/// 志向为大夫
		/// </summary>
		public static PlanningStateItem ProfessionIsDoctor => Instance[350];

		/// <summary>
		/// 志向为云游道
		/// </summary>
		public static PlanningStateItem ProfessionIsTravelingTaoistMonk => Instance[351];

		/// <summary>
		/// 志向为富商
		/// </summary>
		public static PlanningStateItem ProfessionIsCapitalist => Instance[352];

		/// <summary>
		/// 志向为贵客
		/// </summary>
		public static PlanningStateItem ProfessionIsTeaTaster => Instance[353];

		/// <summary>
		/// 志向为王公
		/// </summary>
		public static PlanningStateItem ProfessionIsDuke => Instance[354];

		/// <summary>
		/// 资源
		/// </summary>
		public static PlanningStateItem Resource => Instance[355];

		/// <summary>
		/// 食材
		/// </summary>
		public static PlanningStateItem ResourceFood => Instance[356];

		/// <summary>
		/// 威望
		/// </summary>
		public static PlanningStateItem ResourceAuthority => Instance[363];

		/// <summary>
		/// 任意材料资源
		/// </summary>
		public static PlanningStateItem MaterialResource => Instance[364];

		/// <summary>
		/// 持有资源价值
		/// </summary>
		public static PlanningStateItem ResourceTotalWorth => Instance[365];

		/// <summary>
		/// 对方资源
		/// </summary>
		public static PlanningStateItem TargetResource => Instance[366];

		/// <summary>
		/// 对方食材
		/// </summary>
		public static PlanningStateItem TargetFood => Instance[367];

		/// <summary>
		/// 对方威望
		/// </summary>
		public static PlanningStateItem TargetAuthority => Instance[374];

		/// <summary>
		/// 对方任意材料资源
		/// </summary>
		public static PlanningStateItem TargetMaterialResource => Instance[375];

		/// <summary>
		/// 对方持有资源价值
		/// </summary>
		public static PlanningStateItem TargetResourceTotalWorth => Instance[376];

		/// <summary>
		/// 道具
		/// </summary>
		public static PlanningStateItem Item => Instance[391];

		/// <summary>
		/// 道具数量
		/// </summary>
		public static PlanningStateItem ItemNumber => Instance[393];

		/// <summary>
		/// 工具道具
		/// </summary>
		public static PlanningStateItem CraftToolItem => Instance[409];

		/// <summary>
		/// 心材道具
		/// </summary>
		public static PlanningStateItem BuildingCoreItem => Instance[410];

		/// <summary>
		/// 天劫符箓
		/// </summary>
		public static PlanningStateItem TianjieFulu => Instance[411];

		/// <summary>
		/// 野兽代步
		/// </summary>
		public static PlanningStateItem AnimalCarrier => Instance[412];

		/// <summary>
		/// 功法书籍
		/// </summary>
		public static PlanningStateItem CombatSkillBook => Instance[413];

		/// <summary>
		/// 技艺书籍
		/// </summary>
		public static PlanningStateItem LifeSkillBook => Instance[414];

		/// <summary>
		/// 疗伤道具
		/// </summary>
		public static PlanningStateItem WoundRecoveryItem => Instance[415];

		/// <summary>
		/// 毒药道具
		/// </summary>
		public static PlanningStateItem PoisonItem => Instance[416];

		/// <summary>
		/// 调息道具
		/// </summary>
		public static PlanningStateItem QiRecoveryItem => Instance[417];

		/// <summary>
		/// 解毒道具
		/// </summary>
		public static PlanningStateItem DetoxPoisonItem => Instance[418];

		/// <summary>
		/// 野果道具
		/// </summary>
		public static PlanningStateItem FruitItem => Instance[419];

		/// <summary>
		/// 内力道具
		/// </summary>
		public static PlanningStateItem NeiliRecoveryItem => Instance[420];

		/// <summary>
		/// 属性道具
		/// </summary>
		public static PlanningStateItem AttributeRecoveryItem => Instance[421];

		/// <summary>
		/// 健康道具
		/// </summary>
		public static PlanningStateItem HealthRecoveryItem => Instance[422];

		/// <summary>
		/// 解蛊道具
		/// </summary>
		public static PlanningStateItem DetoxWugItem => Instance[423];

		/// <summary>
		/// 酒类道具
		/// </summary>
		public static PlanningStateItem Wine => Instance[424];

		/// <summary>
		/// 茶类道具
		/// </summary>
		public static PlanningStateItem Tea => Instance[425];

		/// <summary>
		/// 公库贡献值
		/// </summary>
		public static PlanningStateItem TreasuryContribution => Instance[427];

		/// <summary>
		/// 坟墓耐久
		/// </summary>
		public static PlanningStateItem GraveDurability => Instance[432];

		/// <summary>
		/// 最大坟墓耐久
		/// </summary>
		public static PlanningStateItem GraveMaxDurability => Instance[433];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static PlanningState Instance = new PlanningState();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "ParentState", "InputParamType", "OutputParamType", "TemplateId", "ValueType" };

	internal override int ToInt(int value)
	{
		return value;
	}

	internal override int ToTemplateId(int value)
	{
		return value;
	}

	private void CreateItems0()
	{
		_dataArray.Add(new PlanningStateItem(0, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.GoalArgumentStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(1, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.GoalArgumentStateSensor, 5, -1, 0));
		_dataArray.Add(new PlanningStateItem(2, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.GoalArgumentStateSensor, 11, -1, 0));
		_dataArray.Add(new PlanningStateItem(3, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.GoalArgumentStateSensor, 7, -1, 0));
		_dataArray.Add(new PlanningStateItem(4, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.GoalArgumentStateSensor, 8, -1, 0));
		_dataArray.Add(new PlanningStateItem(5, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.CharacterStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(6, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.MainAttributeStateSensor, 1, -1, 0));
		_dataArray.Add(new PlanningStateItem(7, EPlanningStateValueType.Int, 6, EPlanningStateSensorType.MainAttributeStateSensor, -1, 1, 0));
		_dataArray.Add(new PlanningStateItem(8, EPlanningStateValueType.Int, 6, EPlanningStateSensorType.MainAttributeStateSensor, -1, 1, 1));
		_dataArray.Add(new PlanningStateItem(9, EPlanningStateValueType.Int, 6, EPlanningStateSensorType.MainAttributeStateSensor, -1, 1, 2));
		_dataArray.Add(new PlanningStateItem(10, EPlanningStateValueType.Int, 6, EPlanningStateSensorType.MainAttributeStateSensor, -1, 1, 3));
		_dataArray.Add(new PlanningStateItem(11, EPlanningStateValueType.Int, 6, EPlanningStateSensorType.MainAttributeStateSensor, -1, 1, 4));
		_dataArray.Add(new PlanningStateItem(12, EPlanningStateValueType.Int, 6, EPlanningStateSensorType.MainAttributeStateSensor, -1, 1, 5));
		_dataArray.Add(new PlanningStateItem(13, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.TargetStateSensor, 1, -1, 0));
		_dataArray.Add(new PlanningStateItem(14, EPlanningStateValueType.Int, 13, EPlanningStateSensorType.TargetStateSensor, -1, 1, 0));
		_dataArray.Add(new PlanningStateItem(15, EPlanningStateValueType.Int, 13, EPlanningStateSensorType.TargetStateSensor, -1, 1, 1));
		_dataArray.Add(new PlanningStateItem(16, EPlanningStateValueType.Int, 13, EPlanningStateSensorType.TargetStateSensor, -1, 1, 2));
		_dataArray.Add(new PlanningStateItem(17, EPlanningStateValueType.Int, 13, EPlanningStateSensorType.TargetStateSensor, -1, 1, 3));
		_dataArray.Add(new PlanningStateItem(18, EPlanningStateValueType.Int, 13, EPlanningStateSensorType.TargetStateSensor, -1, 1, 4));
		_dataArray.Add(new PlanningStateItem(19, EPlanningStateValueType.Int, 13, EPlanningStateSensorType.TargetStateSensor, -1, 1, 5));
		_dataArray.Add(new PlanningStateItem(20, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.MainAttributeStateSensor, 1, -1, 0));
		_dataArray.Add(new PlanningStateItem(21, EPlanningStateValueType.Int, 20, EPlanningStateSensorType.MainAttributeStateSensor, -1, 1, 0));
		_dataArray.Add(new PlanningStateItem(22, EPlanningStateValueType.Int, 20, EPlanningStateSensorType.MainAttributeStateSensor, -1, 1, 1));
		_dataArray.Add(new PlanningStateItem(23, EPlanningStateValueType.Int, 20, EPlanningStateSensorType.MainAttributeStateSensor, -1, 1, 2));
		_dataArray.Add(new PlanningStateItem(24, EPlanningStateValueType.Int, 20, EPlanningStateSensorType.MainAttributeStateSensor, -1, 1, 3));
		_dataArray.Add(new PlanningStateItem(25, EPlanningStateValueType.Int, 20, EPlanningStateSensorType.MainAttributeStateSensor, -1, 1, 4));
		_dataArray.Add(new PlanningStateItem(26, EPlanningStateValueType.Int, 20, EPlanningStateSensorType.MainAttributeStateSensor, -1, 1, 5));
		_dataArray.Add(new PlanningStateItem(27, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.TargetStateSensor, 1, -1, 0));
		_dataArray.Add(new PlanningStateItem(28, EPlanningStateValueType.Int, 27, EPlanningStateSensorType.TargetStateSensor, -1, 1, 0));
		_dataArray.Add(new PlanningStateItem(29, EPlanningStateValueType.Int, 27, EPlanningStateSensorType.TargetStateSensor, -1, 1, 1));
		_dataArray.Add(new PlanningStateItem(30, EPlanningStateValueType.Int, 27, EPlanningStateSensorType.TargetStateSensor, -1, 1, 2));
		_dataArray.Add(new PlanningStateItem(31, EPlanningStateValueType.Int, 27, EPlanningStateSensorType.TargetStateSensor, -1, 1, 3));
		_dataArray.Add(new PlanningStateItem(32, EPlanningStateValueType.Int, 27, EPlanningStateSensorType.TargetStateSensor, -1, 1, 4));
		_dataArray.Add(new PlanningStateItem(33, EPlanningStateValueType.Int, 27, EPlanningStateSensorType.TargetStateSensor, -1, 1, 5));
		_dataArray.Add(new PlanningStateItem(34, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.CharacterStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(35, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.CharacterStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(36, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.CharacterStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(37, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.CharacterStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(38, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.CharacterStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(39, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.ResourceStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(40, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.InventoryStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(41, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.CharacterStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(42, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.CharacterStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(43, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.CharacterStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(44, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.TargetStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(45, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.CharacterStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(46, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.CharacterStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(47, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.CharacterStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(48, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.CharacterStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(49, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.CharacterStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(50, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.CharacterStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(51, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.CharacterStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(52, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.CharacterStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(53, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.CharacterStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(54, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.None, 19, -1, 0));
		_dataArray.Add(new PlanningStateItem(55, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.CharacterStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(56, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.CharacterStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(57, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.CharacterStateSensor, 2, -1, 0));
		_dataArray.Add(new PlanningStateItem(58, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.CharacterStateSensor, 3, -1, 0));
		_dataArray.Add(new PlanningStateItem(59, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.CharacterStateSensor, -1, -1, 0));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new PlanningStateItem(60, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.CharacterStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(61, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.CharacterStateSensor, 4, -1, 0));
		_dataArray.Add(new PlanningStateItem(62, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.CharacterStateSensor, 4, -1, 0));
		_dataArray.Add(new PlanningStateItem(63, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.CharacterStateSensor, 4, -1, 0));
		_dataArray.Add(new PlanningStateItem(64, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.CharacterStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(65, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.CharacterStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(66, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.CharacterStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(67, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.CharacterStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(68, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.None, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(69, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.None, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(70, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.None, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(71, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.None, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(72, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.TargetStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(73, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.None, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(74, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.None, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(75, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.None, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(76, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.None, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(77, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.None, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(78, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TargetStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(79, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.None, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(80, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.TargetStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(81, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.TargetStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(82, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.TargetStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(83, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.TargetStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(84, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.None, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(85, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.None, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(86, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.None, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(87, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.TargetStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(88, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.None, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(89, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.None, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(90, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.None, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(91, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.None, 19, -1, 0));
		_dataArray.Add(new PlanningStateItem(92, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.TargetStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(93, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.None, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(94, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.TargetStateSensor, 2, -1, 0));
		_dataArray.Add(new PlanningStateItem(95, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.TargetStateSensor, 3, -1, 0));
		_dataArray.Add(new PlanningStateItem(96, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.TargetStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(97, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.None, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(98, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TargetStateSensor, 4, -1, 0));
		_dataArray.Add(new PlanningStateItem(99, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.None, 4, -1, 0));
		_dataArray.Add(new PlanningStateItem(100, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.None, 4, -1, 0));
		_dataArray.Add(new PlanningStateItem(101, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.None, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(102, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.TargetStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(103, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TargetStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(104, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TargetStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(105, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.None, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(106, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TargetStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(107, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TargetStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(108, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.InventoryStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(109, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.InventoryStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(110, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.InventoryStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(111, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.InventoryStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(112, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.InventoryStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(113, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.InventoryStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(114, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.InventoryStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(115, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.CharacterStateSensor, 20, -1, 0));
		_dataArray.Add(new PlanningStateItem(116, EPlanningStateValueType.Int, 115, EPlanningStateSensorType.CharacterStateSensor, -1, 20, 0));
		_dataArray.Add(new PlanningStateItem(117, EPlanningStateValueType.Int, 115, EPlanningStateSensorType.CharacterStateSensor, -1, 20, 2));
		_dataArray.Add(new PlanningStateItem(118, EPlanningStateValueType.Int, 115, EPlanningStateSensorType.CharacterStateSensor, -1, 20, 1));
		_dataArray.Add(new PlanningStateItem(119, EPlanningStateValueType.Int, 115, EPlanningStateSensorType.CharacterStateSensor, -1, 20, 3));
	}

	private void CreateItems2()
	{
		_dataArray.Add(new PlanningStateItem(120, EPlanningStateValueType.Int, 115, EPlanningStateSensorType.CharacterStateSensor, -1, 20, 4));
		_dataArray.Add(new PlanningStateItem(121, EPlanningStateValueType.Int, 115, EPlanningStateSensorType.CharacterStateSensor, -1, 20, 6));
		_dataArray.Add(new PlanningStateItem(122, EPlanningStateValueType.Int, 115, EPlanningStateSensorType.CharacterStateSensor, -1, 20, 5));
		_dataArray.Add(new PlanningStateItem(123, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.None, 20, -1, 0));
		_dataArray.Add(new PlanningStateItem(124, EPlanningStateValueType.Int, 123, EPlanningStateSensorType.None, -1, 20, 0));
		_dataArray.Add(new PlanningStateItem(125, EPlanningStateValueType.Int, 123, EPlanningStateSensorType.None, -1, 20, 2));
		_dataArray.Add(new PlanningStateItem(126, EPlanningStateValueType.Int, 123, EPlanningStateSensorType.None, -1, 20, 1));
		_dataArray.Add(new PlanningStateItem(127, EPlanningStateValueType.Int, 123, EPlanningStateSensorType.None, -1, 20, 3));
		_dataArray.Add(new PlanningStateItem(128, EPlanningStateValueType.Int, 123, EPlanningStateSensorType.None, -1, 20, 4));
		_dataArray.Add(new PlanningStateItem(129, EPlanningStateValueType.Int, 123, EPlanningStateSensorType.None, -1, 20, 5));
		_dataArray.Add(new PlanningStateItem(130, EPlanningStateValueType.Int, 123, EPlanningStateSensorType.None, -1, 20, 6));
		_dataArray.Add(new PlanningStateItem(131, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.CombatSkillStateSensor, 7, -1, 0));
		_dataArray.Add(new PlanningStateItem(132, EPlanningStateValueType.Int, 131, EPlanningStateSensorType.CombatSkillStateSensor, -1, 7, 0));
		_dataArray.Add(new PlanningStateItem(133, EPlanningStateValueType.Int, 131, EPlanningStateSensorType.CombatSkillStateSensor, -1, 7, 1));
		_dataArray.Add(new PlanningStateItem(134, EPlanningStateValueType.Int, 131, EPlanningStateSensorType.CombatSkillStateSensor, -1, 7, 2));
		_dataArray.Add(new PlanningStateItem(135, EPlanningStateValueType.Int, 131, EPlanningStateSensorType.CombatSkillStateSensor, -1, 7, 3));
		_dataArray.Add(new PlanningStateItem(136, EPlanningStateValueType.Int, 131, EPlanningStateSensorType.CombatSkillStateSensor, -1, 7, 4));
		_dataArray.Add(new PlanningStateItem(137, EPlanningStateValueType.Int, 131, EPlanningStateSensorType.CombatSkillStateSensor, -1, 7, 5));
		_dataArray.Add(new PlanningStateItem(138, EPlanningStateValueType.Int, 131, EPlanningStateSensorType.CombatSkillStateSensor, -1, 7, 6));
		_dataArray.Add(new PlanningStateItem(139, EPlanningStateValueType.Int, 131, EPlanningStateSensorType.CombatSkillStateSensor, -1, 7, 7));
		_dataArray.Add(new PlanningStateItem(140, EPlanningStateValueType.Int, 131, EPlanningStateSensorType.CombatSkillStateSensor, -1, 7, 8));
		_dataArray.Add(new PlanningStateItem(141, EPlanningStateValueType.Int, 131, EPlanningStateSensorType.CombatSkillStateSensor, -1, 7, 9));
		_dataArray.Add(new PlanningStateItem(142, EPlanningStateValueType.Int, 131, EPlanningStateSensorType.CombatSkillStateSensor, -1, 7, 10));
		_dataArray.Add(new PlanningStateItem(143, EPlanningStateValueType.Int, 131, EPlanningStateSensorType.CombatSkillStateSensor, -1, 7, 11));
		_dataArray.Add(new PlanningStateItem(144, EPlanningStateValueType.Int, 131, EPlanningStateSensorType.CombatSkillStateSensor, -1, 7, 12));
		_dataArray.Add(new PlanningStateItem(145, EPlanningStateValueType.Int, 131, EPlanningStateSensorType.CombatSkillStateSensor, -1, 7, 13));
		_dataArray.Add(new PlanningStateItem(146, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.TargetStateSensor, 7, -1, 0));
		_dataArray.Add(new PlanningStateItem(147, EPlanningStateValueType.Int, 146, EPlanningStateSensorType.TargetStateSensor, -1, 7, 0));
		_dataArray.Add(new PlanningStateItem(148, EPlanningStateValueType.Int, 146, EPlanningStateSensorType.TargetStateSensor, -1, 7, 1));
		_dataArray.Add(new PlanningStateItem(149, EPlanningStateValueType.Int, 146, EPlanningStateSensorType.TargetStateSensor, -1, 7, 2));
		_dataArray.Add(new PlanningStateItem(150, EPlanningStateValueType.Int, 146, EPlanningStateSensorType.TargetStateSensor, -1, 7, 3));
		_dataArray.Add(new PlanningStateItem(151, EPlanningStateValueType.Int, 146, EPlanningStateSensorType.TargetStateSensor, -1, 7, 4));
		_dataArray.Add(new PlanningStateItem(152, EPlanningStateValueType.Int, 146, EPlanningStateSensorType.TargetStateSensor, -1, 7, 5));
		_dataArray.Add(new PlanningStateItem(153, EPlanningStateValueType.Int, 146, EPlanningStateSensorType.TargetStateSensor, -1, 7, 6));
		_dataArray.Add(new PlanningStateItem(154, EPlanningStateValueType.Int, 146, EPlanningStateSensorType.TargetStateSensor, -1, 7, 7));
		_dataArray.Add(new PlanningStateItem(155, EPlanningStateValueType.Int, 146, EPlanningStateSensorType.TargetStateSensor, -1, 7, 8));
		_dataArray.Add(new PlanningStateItem(156, EPlanningStateValueType.Int, 146, EPlanningStateSensorType.TargetStateSensor, -1, 7, 9));
		_dataArray.Add(new PlanningStateItem(157, EPlanningStateValueType.Int, 146, EPlanningStateSensorType.TargetStateSensor, -1, 7, 10));
		_dataArray.Add(new PlanningStateItem(158, EPlanningStateValueType.Int, 146, EPlanningStateSensorType.TargetStateSensor, -1, 7, 11));
		_dataArray.Add(new PlanningStateItem(159, EPlanningStateValueType.Int, 146, EPlanningStateSensorType.TargetStateSensor, -1, 7, 12));
		_dataArray.Add(new PlanningStateItem(160, EPlanningStateValueType.Int, 146, EPlanningStateSensorType.TargetStateSensor, -1, 7, 13));
		_dataArray.Add(new PlanningStateItem(161, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.LifeSkillStateSensor, 8, -1, 0));
		_dataArray.Add(new PlanningStateItem(162, EPlanningStateValueType.Int, 161, EPlanningStateSensorType.LifeSkillStateSensor, -1, 8, 0));
		_dataArray.Add(new PlanningStateItem(163, EPlanningStateValueType.Int, 161, EPlanningStateSensorType.LifeSkillStateSensor, -1, 8, 1));
		_dataArray.Add(new PlanningStateItem(164, EPlanningStateValueType.Int, 161, EPlanningStateSensorType.LifeSkillStateSensor, -1, 8, 2));
		_dataArray.Add(new PlanningStateItem(165, EPlanningStateValueType.Int, 161, EPlanningStateSensorType.LifeSkillStateSensor, -1, 8, 3));
		_dataArray.Add(new PlanningStateItem(166, EPlanningStateValueType.Int, 161, EPlanningStateSensorType.LifeSkillStateSensor, -1, 8, 4));
		_dataArray.Add(new PlanningStateItem(167, EPlanningStateValueType.Int, 161, EPlanningStateSensorType.LifeSkillStateSensor, -1, 8, 5));
		_dataArray.Add(new PlanningStateItem(168, EPlanningStateValueType.Int, 161, EPlanningStateSensorType.LifeSkillStateSensor, -1, 8, 6));
		_dataArray.Add(new PlanningStateItem(169, EPlanningStateValueType.Int, 161, EPlanningStateSensorType.LifeSkillStateSensor, -1, 8, 7));
		_dataArray.Add(new PlanningStateItem(170, EPlanningStateValueType.Int, 161, EPlanningStateSensorType.LifeSkillStateSensor, -1, 8, 8));
		_dataArray.Add(new PlanningStateItem(171, EPlanningStateValueType.Int, 161, EPlanningStateSensorType.LifeSkillStateSensor, -1, 8, 9));
		_dataArray.Add(new PlanningStateItem(172, EPlanningStateValueType.Int, 161, EPlanningStateSensorType.LifeSkillStateSensor, -1, 8, 10));
		_dataArray.Add(new PlanningStateItem(173, EPlanningStateValueType.Int, 161, EPlanningStateSensorType.LifeSkillStateSensor, -1, 8, 11));
		_dataArray.Add(new PlanningStateItem(174, EPlanningStateValueType.Int, 161, EPlanningStateSensorType.LifeSkillStateSensor, -1, 8, 12));
		_dataArray.Add(new PlanningStateItem(175, EPlanningStateValueType.Int, 161, EPlanningStateSensorType.LifeSkillStateSensor, -1, 8, 13));
		_dataArray.Add(new PlanningStateItem(176, EPlanningStateValueType.Int, 161, EPlanningStateSensorType.LifeSkillStateSensor, -1, 8, 14));
		_dataArray.Add(new PlanningStateItem(177, EPlanningStateValueType.Int, 161, EPlanningStateSensorType.LifeSkillStateSensor, -1, 8, 15));
		_dataArray.Add(new PlanningStateItem(178, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.TargetStateSensor, 8, -1, 0));
		_dataArray.Add(new PlanningStateItem(179, EPlanningStateValueType.Int, 178, EPlanningStateSensorType.TargetStateSensor, -1, 8, 0));
	}

	private void CreateItems3()
	{
		_dataArray.Add(new PlanningStateItem(180, EPlanningStateValueType.Int, 178, EPlanningStateSensorType.TargetStateSensor, -1, 8, 1));
		_dataArray.Add(new PlanningStateItem(181, EPlanningStateValueType.Int, 178, EPlanningStateSensorType.TargetStateSensor, -1, 8, 2));
		_dataArray.Add(new PlanningStateItem(182, EPlanningStateValueType.Int, 178, EPlanningStateSensorType.TargetStateSensor, -1, 8, 3));
		_dataArray.Add(new PlanningStateItem(183, EPlanningStateValueType.Int, 178, EPlanningStateSensorType.TargetStateSensor, -1, 8, 4));
		_dataArray.Add(new PlanningStateItem(184, EPlanningStateValueType.Int, 178, EPlanningStateSensorType.TargetStateSensor, -1, 8, 5));
		_dataArray.Add(new PlanningStateItem(185, EPlanningStateValueType.Int, 178, EPlanningStateSensorType.TargetStateSensor, -1, 8, 6));
		_dataArray.Add(new PlanningStateItem(186, EPlanningStateValueType.Int, 178, EPlanningStateSensorType.TargetStateSensor, -1, 8, 7));
		_dataArray.Add(new PlanningStateItem(187, EPlanningStateValueType.Int, 178, EPlanningStateSensorType.TargetStateSensor, -1, 8, 8));
		_dataArray.Add(new PlanningStateItem(188, EPlanningStateValueType.Int, 178, EPlanningStateSensorType.TargetStateSensor, -1, 8, 9));
		_dataArray.Add(new PlanningStateItem(189, EPlanningStateValueType.Int, 178, EPlanningStateSensorType.TargetStateSensor, -1, 8, 10));
		_dataArray.Add(new PlanningStateItem(190, EPlanningStateValueType.Int, 178, EPlanningStateSensorType.TargetStateSensor, -1, 8, 11));
		_dataArray.Add(new PlanningStateItem(191, EPlanningStateValueType.Int, 178, EPlanningStateSensorType.TargetStateSensor, -1, 8, 12));
		_dataArray.Add(new PlanningStateItem(192, EPlanningStateValueType.Int, 178, EPlanningStateSensorType.TargetStateSensor, -1, 8, 13));
		_dataArray.Add(new PlanningStateItem(193, EPlanningStateValueType.Int, 178, EPlanningStateSensorType.TargetStateSensor, -1, 8, 14));
		_dataArray.Add(new PlanningStateItem(194, EPlanningStateValueType.Int, 178, EPlanningStateSensorType.TargetStateSensor, -1, 8, 15));
		_dataArray.Add(new PlanningStateItem(195, EPlanningStateValueType.Int, 210, EPlanningStateSensorType.CombatSkillStateSensor, 7, -1, 0));
		_dataArray.Add(new PlanningStateItem(196, EPlanningStateValueType.Int, 195, EPlanningStateSensorType.CombatSkillStateSensor, -1, 7, 0));
		_dataArray.Add(new PlanningStateItem(197, EPlanningStateValueType.Int, 195, EPlanningStateSensorType.CombatSkillStateSensor, -1, 7, 1));
		_dataArray.Add(new PlanningStateItem(198, EPlanningStateValueType.Int, 195, EPlanningStateSensorType.CombatSkillStateSensor, -1, 7, 2));
		_dataArray.Add(new PlanningStateItem(199, EPlanningStateValueType.Int, 195, EPlanningStateSensorType.CombatSkillStateSensor, -1, 7, 3));
		_dataArray.Add(new PlanningStateItem(200, EPlanningStateValueType.Int, 195, EPlanningStateSensorType.CombatSkillStateSensor, -1, 7, 4));
		_dataArray.Add(new PlanningStateItem(201, EPlanningStateValueType.Int, 195, EPlanningStateSensorType.CombatSkillStateSensor, -1, 7, 5));
		_dataArray.Add(new PlanningStateItem(202, EPlanningStateValueType.Int, 195, EPlanningStateSensorType.CombatSkillStateSensor, -1, 7, 6));
		_dataArray.Add(new PlanningStateItem(203, EPlanningStateValueType.Int, 195, EPlanningStateSensorType.CombatSkillStateSensor, -1, 7, 7));
		_dataArray.Add(new PlanningStateItem(204, EPlanningStateValueType.Int, 195, EPlanningStateSensorType.CombatSkillStateSensor, -1, 7, 8));
		_dataArray.Add(new PlanningStateItem(205, EPlanningStateValueType.Int, 195, EPlanningStateSensorType.CombatSkillStateSensor, -1, 7, 9));
		_dataArray.Add(new PlanningStateItem(206, EPlanningStateValueType.Int, 195, EPlanningStateSensorType.CombatSkillStateSensor, -1, 7, 10));
		_dataArray.Add(new PlanningStateItem(207, EPlanningStateValueType.Int, 195, EPlanningStateSensorType.CombatSkillStateSensor, -1, 7, 11));
		_dataArray.Add(new PlanningStateItem(208, EPlanningStateValueType.Int, 195, EPlanningStateSensorType.CombatSkillStateSensor, -1, 7, 12));
		_dataArray.Add(new PlanningStateItem(209, EPlanningStateValueType.Int, 195, EPlanningStateSensorType.CombatSkillStateSensor, -1, 7, 13));
		_dataArray.Add(new PlanningStateItem(210, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.None, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(211, EPlanningStateValueType.Int, 226, EPlanningStateSensorType.TargetStateSensor, 7, -1, 0));
		_dataArray.Add(new PlanningStateItem(212, EPlanningStateValueType.Int, 211, EPlanningStateSensorType.TargetStateSensor, -1, 7, 0));
		_dataArray.Add(new PlanningStateItem(213, EPlanningStateValueType.Int, 211, EPlanningStateSensorType.TargetStateSensor, -1, 7, 1));
		_dataArray.Add(new PlanningStateItem(214, EPlanningStateValueType.Int, 211, EPlanningStateSensorType.TargetStateSensor, -1, 7, 2));
		_dataArray.Add(new PlanningStateItem(215, EPlanningStateValueType.Int, 211, EPlanningStateSensorType.TargetStateSensor, -1, 7, 3));
		_dataArray.Add(new PlanningStateItem(216, EPlanningStateValueType.Int, 211, EPlanningStateSensorType.TargetStateSensor, -1, 7, 4));
		_dataArray.Add(new PlanningStateItem(217, EPlanningStateValueType.Int, 211, EPlanningStateSensorType.TargetStateSensor, -1, 7, 5));
		_dataArray.Add(new PlanningStateItem(218, EPlanningStateValueType.Int, 211, EPlanningStateSensorType.TargetStateSensor, -1, 7, 6));
		_dataArray.Add(new PlanningStateItem(219, EPlanningStateValueType.Int, 211, EPlanningStateSensorType.TargetStateSensor, -1, 7, 7));
		_dataArray.Add(new PlanningStateItem(220, EPlanningStateValueType.Int, 211, EPlanningStateSensorType.TargetStateSensor, -1, 7, 8));
		_dataArray.Add(new PlanningStateItem(221, EPlanningStateValueType.Int, 211, EPlanningStateSensorType.TargetStateSensor, -1, 7, 9));
		_dataArray.Add(new PlanningStateItem(222, EPlanningStateValueType.Int, 211, EPlanningStateSensorType.TargetStateSensor, -1, 7, 10));
		_dataArray.Add(new PlanningStateItem(223, EPlanningStateValueType.Int, 211, EPlanningStateSensorType.TargetStateSensor, -1, 7, 11));
		_dataArray.Add(new PlanningStateItem(224, EPlanningStateValueType.Int, 211, EPlanningStateSensorType.TargetStateSensor, -1, 7, 12));
		_dataArray.Add(new PlanningStateItem(225, EPlanningStateValueType.Int, 211, EPlanningStateSensorType.TargetStateSensor, -1, 7, 13));
		_dataArray.Add(new PlanningStateItem(226, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.None, -1, 7, 0));
		_dataArray.Add(new PlanningStateItem(227, EPlanningStateValueType.Int, 246, EPlanningStateSensorType.LifeSkillStateSensor, 8, -1, 0));
		_dataArray.Add(new PlanningStateItem(228, EPlanningStateValueType.Int, 227, EPlanningStateSensorType.LifeSkillStateSensor, -1, 8, 0));
		_dataArray.Add(new PlanningStateItem(229, EPlanningStateValueType.Int, 227, EPlanningStateSensorType.LifeSkillStateSensor, -1, 8, 1));
		_dataArray.Add(new PlanningStateItem(230, EPlanningStateValueType.Int, 227, EPlanningStateSensorType.LifeSkillStateSensor, -1, 8, 2));
		_dataArray.Add(new PlanningStateItem(231, EPlanningStateValueType.Int, 227, EPlanningStateSensorType.LifeSkillStateSensor, -1, 8, 3));
		_dataArray.Add(new PlanningStateItem(232, EPlanningStateValueType.Int, 227, EPlanningStateSensorType.LifeSkillStateSensor, -1, 8, 4));
		_dataArray.Add(new PlanningStateItem(233, EPlanningStateValueType.Int, 227, EPlanningStateSensorType.LifeSkillStateSensor, -1, 8, 5));
		_dataArray.Add(new PlanningStateItem(234, EPlanningStateValueType.Int, 244, EPlanningStateSensorType.LifeSkillStateSensor, -1, 8, 6));
		_dataArray.Add(new PlanningStateItem(235, EPlanningStateValueType.Int, 244, EPlanningStateSensorType.LifeSkillStateSensor, -1, 8, 7));
		_dataArray.Add(new PlanningStateItem(236, EPlanningStateValueType.Int, 227, EPlanningStateSensorType.LifeSkillStateSensor, -1, 8, 8));
		_dataArray.Add(new PlanningStateItem(237, EPlanningStateValueType.Int, 227, EPlanningStateSensorType.LifeSkillStateSensor, -1, 8, 9));
		_dataArray.Add(new PlanningStateItem(238, EPlanningStateValueType.Int, 244, EPlanningStateSensorType.LifeSkillStateSensor, -1, 8, 10));
		_dataArray.Add(new PlanningStateItem(239, EPlanningStateValueType.Int, 244, EPlanningStateSensorType.LifeSkillStateSensor, -1, 8, 11));
	}

	private void CreateItems4()
	{
		_dataArray.Add(new PlanningStateItem(240, EPlanningStateValueType.Int, 227, EPlanningStateSensorType.LifeSkillStateSensor, -1, 8, 12));
		_dataArray.Add(new PlanningStateItem(241, EPlanningStateValueType.Int, 227, EPlanningStateSensorType.LifeSkillStateSensor, -1, 8, 13));
		_dataArray.Add(new PlanningStateItem(242, EPlanningStateValueType.Int, 244, EPlanningStateSensorType.LifeSkillStateSensor, -1, 8, 14));
		_dataArray.Add(new PlanningStateItem(243, EPlanningStateValueType.Int, 227, EPlanningStateSensorType.LifeSkillStateSensor, -1, 8, 15));
		_dataArray.Add(new PlanningStateItem(244, EPlanningStateValueType.Int, 227, EPlanningStateSensorType.LifeSkillStateSensor, -1, 8, 16));
		_dataArray.Add(new PlanningStateItem(245, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.None, -1, 8, 17));
		_dataArray.Add(new PlanningStateItem(246, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.LifeSkillStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(247, EPlanningStateValueType.Int, 266, EPlanningStateSensorType.TargetStateSensor, 8, -1, 0));
		_dataArray.Add(new PlanningStateItem(248, EPlanningStateValueType.Int, 247, EPlanningStateSensorType.TargetStateSensor, -1, 8, 0));
		_dataArray.Add(new PlanningStateItem(249, EPlanningStateValueType.Int, 247, EPlanningStateSensorType.TargetStateSensor, -1, 8, 1));
		_dataArray.Add(new PlanningStateItem(250, EPlanningStateValueType.Int, 247, EPlanningStateSensorType.TargetStateSensor, -1, 8, 2));
		_dataArray.Add(new PlanningStateItem(251, EPlanningStateValueType.Int, 247, EPlanningStateSensorType.TargetStateSensor, -1, 8, 3));
		_dataArray.Add(new PlanningStateItem(252, EPlanningStateValueType.Int, 247, EPlanningStateSensorType.TargetStateSensor, -1, 8, 4));
		_dataArray.Add(new PlanningStateItem(253, EPlanningStateValueType.Int, 247, EPlanningStateSensorType.TargetStateSensor, -1, 8, 5));
		_dataArray.Add(new PlanningStateItem(254, EPlanningStateValueType.Int, 264, EPlanningStateSensorType.TargetStateSensor, -1, 8, 6));
		_dataArray.Add(new PlanningStateItem(255, EPlanningStateValueType.Int, 264, EPlanningStateSensorType.TargetStateSensor, -1, 8, 7));
		_dataArray.Add(new PlanningStateItem(256, EPlanningStateValueType.Int, 247, EPlanningStateSensorType.TargetStateSensor, -1, 8, 8));
		_dataArray.Add(new PlanningStateItem(257, EPlanningStateValueType.Int, 247, EPlanningStateSensorType.TargetStateSensor, -1, 8, 9));
		_dataArray.Add(new PlanningStateItem(258, EPlanningStateValueType.Int, 264, EPlanningStateSensorType.TargetStateSensor, -1, 8, 10));
		_dataArray.Add(new PlanningStateItem(259, EPlanningStateValueType.Int, 264, EPlanningStateSensorType.TargetStateSensor, -1, 8, 11));
		_dataArray.Add(new PlanningStateItem(260, EPlanningStateValueType.Int, 247, EPlanningStateSensorType.TargetStateSensor, -1, 8, 12));
		_dataArray.Add(new PlanningStateItem(261, EPlanningStateValueType.Int, 247, EPlanningStateSensorType.TargetStateSensor, -1, 8, 13));
		_dataArray.Add(new PlanningStateItem(262, EPlanningStateValueType.Int, 264, EPlanningStateSensorType.TargetStateSensor, -1, 8, 14));
		_dataArray.Add(new PlanningStateItem(263, EPlanningStateValueType.Int, 247, EPlanningStateSensorType.TargetStateSensor, -1, 8, 15));
		_dataArray.Add(new PlanningStateItem(264, EPlanningStateValueType.Int, 247, EPlanningStateSensorType.TargetStateSensor, -1, 8, 16));
		_dataArray.Add(new PlanningStateItem(265, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.None, -1, 8, 17));
		_dataArray.Add(new PlanningStateItem(266, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.None, -1, 8, 18));
		_dataArray.Add(new PlanningStateItem(267, EPlanningStateValueType.Bool, 276, EPlanningStateSensorType.TriggerStateSensor, -1, 9, 0));
		_dataArray.Add(new PlanningStateItem(268, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, 9, 0));
		_dataArray.Add(new PlanningStateItem(269, EPlanningStateValueType.Bool, 276, EPlanningStateSensorType.TriggerStateSensor, -1, 9, 0));
		_dataArray.Add(new PlanningStateItem(270, EPlanningStateValueType.Bool, 276, EPlanningStateSensorType.TriggerStateSensor, -1, 9, 0));
		_dataArray.Add(new PlanningStateItem(271, EPlanningStateValueType.Bool, 276, EPlanningStateSensorType.TriggerStateSensor, -1, 9, 0));
		_dataArray.Add(new PlanningStateItem(272, EPlanningStateValueType.Bool, 276, EPlanningStateSensorType.TriggerStateSensor, -1, 9, 0));
		_dataArray.Add(new PlanningStateItem(273, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, 9, 0));
		_dataArray.Add(new PlanningStateItem(274, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, 9, 0));
		_dataArray.Add(new PlanningStateItem(275, EPlanningStateValueType.Bool, 276, EPlanningStateSensorType.TriggerStateSensor, -1, 9, 0));
		_dataArray.Add(new PlanningStateItem(276, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.TriggerStateSensor, -1, 9, 0));
		_dataArray.Add(new PlanningStateItem(277, EPlanningStateValueType.Bool, 286, EPlanningStateSensorType.TriggerStateSensor, -1, 9, 0));
		_dataArray.Add(new PlanningStateItem(278, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, 9, 0));
		_dataArray.Add(new PlanningStateItem(279, EPlanningStateValueType.Bool, 286, EPlanningStateSensorType.TriggerStateSensor, -1, 9, 0));
		_dataArray.Add(new PlanningStateItem(280, EPlanningStateValueType.Bool, 286, EPlanningStateSensorType.TriggerStateSensor, -1, 9, 0));
		_dataArray.Add(new PlanningStateItem(281, EPlanningStateValueType.Bool, 286, EPlanningStateSensorType.TriggerStateSensor, -1, 9, 0));
		_dataArray.Add(new PlanningStateItem(282, EPlanningStateValueType.Bool, 286, EPlanningStateSensorType.TriggerStateSensor, -1, 9, 0));
		_dataArray.Add(new PlanningStateItem(283, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, 9, 0));
		_dataArray.Add(new PlanningStateItem(284, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, 9, 0));
		_dataArray.Add(new PlanningStateItem(285, EPlanningStateValueType.Bool, 286, EPlanningStateSensorType.TriggerStateSensor, -1, 9, 0));
		_dataArray.Add(new PlanningStateItem(286, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.TriggerStateSensor, -1, 9, 0));
		_dataArray.Add(new PlanningStateItem(287, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.RelationStateSensor, -1, 0, 0));
		_dataArray.Add(new PlanningStateItem(288, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.RelationStateSensor, -1, 0, 0));
		_dataArray.Add(new PlanningStateItem(289, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.RelationStateSensor, -1, 0, 0));
		_dataArray.Add(new PlanningStateItem(290, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.RelationStateSensor, -1, 0, 0));
		_dataArray.Add(new PlanningStateItem(291, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.RelationStateSensor, -1, 0, 0));
		_dataArray.Add(new PlanningStateItem(292, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.RelationStateSensor, -1, 0, 0));
		_dataArray.Add(new PlanningStateItem(293, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.RelationStateSensor, -1, 0, 0));
		_dataArray.Add(new PlanningStateItem(294, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.RelationStateSensor, -1, 0, 0));
		_dataArray.Add(new PlanningStateItem(295, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.RelationStateSensor, -1, 0, 0));
		_dataArray.Add(new PlanningStateItem(296, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.CharacterStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(297, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.CharacterStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(298, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.None, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(299, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.None, -1, -1, 0));
	}

	private void CreateItems5()
	{
		_dataArray.Add(new PlanningStateItem(300, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.None, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(301, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.None, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(302, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TargetStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(303, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TargetStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(304, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TargetStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(305, EPlanningStateValueType.Bool, 304, EPlanningStateSensorType.TargetStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(306, EPlanningStateValueType.Bool, 304, EPlanningStateSensorType.TargetStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(307, EPlanningStateValueType.Bool, 304, EPlanningStateSensorType.TargetStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(308, EPlanningStateValueType.Bool, 304, EPlanningStateSensorType.TargetStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(309, EPlanningStateValueType.Bool, 304, EPlanningStateSensorType.TargetStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(310, EPlanningStateValueType.Bool, 304, EPlanningStateSensorType.TargetStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(311, EPlanningStateValueType.Bool, 304, EPlanningStateSensorType.TargetStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(312, EPlanningStateValueType.Bool, 304, EPlanningStateSensorType.TargetStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(313, EPlanningStateValueType.Bool, 304, EPlanningStateSensorType.TargetStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(314, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TargetStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(315, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TargetStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(316, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TargetStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(317, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.OrganizationStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(318, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.OrganizationStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(319, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.None, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(320, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.None, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(321, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.OrganizationStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(322, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.None, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(323, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.None, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(324, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.None, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(325, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.None, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(326, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.None, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(327, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.None, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(328, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.None, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(329, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.None, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(330, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.None, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(331, EPlanningStateValueType.Bool, 317, EPlanningStateSensorType.OrganizationStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(332, EPlanningStateValueType.Bool, 317, EPlanningStateSensorType.OrganizationStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(333, EPlanningStateValueType.Bool, 317, EPlanningStateSensorType.OrganizationStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(334, EPlanningStateValueType.Bool, 324, EPlanningStateSensorType.None, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(335, EPlanningStateValueType.Bool, 324, EPlanningStateSensorType.None, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(336, EPlanningStateValueType.Bool, 324, EPlanningStateSensorType.None, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(337, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.ProfessionStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(338, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.ProfessionStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(339, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.ProfessionStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(340, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.ProfessionStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(341, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.ProfessionStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(342, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.ProfessionStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(343, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.ProfessionStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(344, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.ProfessionStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(345, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.ProfessionStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(346, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.ProfessionStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(347, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.ProfessionStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(348, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.ProfessionStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(349, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.ProfessionStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(350, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.ProfessionStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(351, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.ProfessionStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(352, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.ProfessionStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(353, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.ProfessionStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(354, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.ProfessionStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(355, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.ResourceStateSensor, 5, -1, 0));
		_dataArray.Add(new PlanningStateItem(356, EPlanningStateValueType.Int, 364, EPlanningStateSensorType.ResourceStateSensor, -1, 5, 0));
		_dataArray.Add(new PlanningStateItem(357, EPlanningStateValueType.Int, 364, EPlanningStateSensorType.ResourceStateSensor, -1, 5, 1));
		_dataArray.Add(new PlanningStateItem(358, EPlanningStateValueType.Int, 364, EPlanningStateSensorType.ResourceStateSensor, -1, 5, 2));
		_dataArray.Add(new PlanningStateItem(359, EPlanningStateValueType.Int, 364, EPlanningStateSensorType.ResourceStateSensor, -1, 5, 3));
	}

	private void CreateItems6()
	{
		_dataArray.Add(new PlanningStateItem(360, EPlanningStateValueType.Int, 364, EPlanningStateSensorType.ResourceStateSensor, -1, 5, 4));
		_dataArray.Add(new PlanningStateItem(361, EPlanningStateValueType.Int, 364, EPlanningStateSensorType.ResourceStateSensor, -1, 5, 5));
		_dataArray.Add(new PlanningStateItem(362, EPlanningStateValueType.Int, 355, EPlanningStateSensorType.ResourceStateSensor, -1, 5, 6));
		_dataArray.Add(new PlanningStateItem(363, EPlanningStateValueType.Int, 355, EPlanningStateSensorType.ResourceStateSensor, -1, 5, 7));
		_dataArray.Add(new PlanningStateItem(364, EPlanningStateValueType.Int, 355, EPlanningStateSensorType.ResourceStateSensor, 5, -1, 0));
		_dataArray.Add(new PlanningStateItem(365, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.ResourceStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(366, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.TargetStateSensor, 5, -1, 0));
		_dataArray.Add(new PlanningStateItem(367, EPlanningStateValueType.Int, 375, EPlanningStateSensorType.TargetStateSensor, -1, 5, 0));
		_dataArray.Add(new PlanningStateItem(368, EPlanningStateValueType.Int, 375, EPlanningStateSensorType.TargetStateSensor, -1, 5, 1));
		_dataArray.Add(new PlanningStateItem(369, EPlanningStateValueType.Int, 375, EPlanningStateSensorType.TargetStateSensor, -1, 5, 2));
		_dataArray.Add(new PlanningStateItem(370, EPlanningStateValueType.Int, 375, EPlanningStateSensorType.TargetStateSensor, -1, 5, 3));
		_dataArray.Add(new PlanningStateItem(371, EPlanningStateValueType.Int, 375, EPlanningStateSensorType.TargetStateSensor, -1, 5, 4));
		_dataArray.Add(new PlanningStateItem(372, EPlanningStateValueType.Int, 375, EPlanningStateSensorType.TargetStateSensor, -1, 5, 5));
		_dataArray.Add(new PlanningStateItem(373, EPlanningStateValueType.Int, 366, EPlanningStateSensorType.TargetStateSensor, -1, 5, 6));
		_dataArray.Add(new PlanningStateItem(374, EPlanningStateValueType.Int, 366, EPlanningStateSensorType.TargetStateSensor, -1, 5, 7));
		_dataArray.Add(new PlanningStateItem(375, EPlanningStateValueType.Int, 366, EPlanningStateSensorType.TargetStateSensor, 5, -1, 0));
		_dataArray.Add(new PlanningStateItem(376, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.TargetStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(377, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(378, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(379, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(380, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(381, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(382, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(383, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(384, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(385, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(386, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(387, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(388, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(389, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(390, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(391, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.InventoryStateSensor, 11, -1, 0));
		_dataArray.Add(new PlanningStateItem(392, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.GoalArgumentStateSensor, 11, -1, 0));
		_dataArray.Add(new PlanningStateItem(393, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.InventoryStateSensor, 11, -1, 0));
		_dataArray.Add(new PlanningStateItem(394, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.GoalArgumentStateSensor, 12, -1, 0));
		_dataArray.Add(new PlanningStateItem(395, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.GoalArgumentStateSensor, 12, -1, 0));
		_dataArray.Add(new PlanningStateItem(396, EPlanningStateValueType.Bool, 391, EPlanningStateSensorType.None, 6, -1, 0));
		_dataArray.Add(new PlanningStateItem(397, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.None, 12, -1, 0));
		_dataArray.Add(new PlanningStateItem(398, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.None, 12, -1, 0));
		_dataArray.Add(new PlanningStateItem(399, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.None, 12, -1, 0));
		_dataArray.Add(new PlanningStateItem(400, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.None, 12, -1, 0));
		_dataArray.Add(new PlanningStateItem(401, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.None, 12, -1, 0));
		_dataArray.Add(new PlanningStateItem(402, EPlanningStateValueType.Bool, 391, EPlanningStateSensorType.None, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(403, EPlanningStateValueType.Bool, 391, EPlanningStateSensorType.None, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(404, EPlanningStateValueType.Bool, 391, EPlanningStateSensorType.None, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(405, EPlanningStateValueType.Bool, 391, EPlanningStateSensorType.None, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(406, EPlanningStateValueType.Bool, 391, EPlanningStateSensorType.None, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(407, EPlanningStateValueType.Bool, 391, EPlanningStateSensorType.None, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(408, EPlanningStateValueType.Bool, 391, EPlanningStateSensorType.None, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(409, EPlanningStateValueType.Bool, 391, EPlanningStateSensorType.InventoryStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(410, EPlanningStateValueType.Bool, 391, EPlanningStateSensorType.InventoryStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(411, EPlanningStateValueType.Int, 391, EPlanningStateSensorType.InventoryStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(412, EPlanningStateValueType.Bool, 391, EPlanningStateSensorType.InventoryStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(413, EPlanningStateValueType.Bool, 391, EPlanningStateSensorType.InventoryStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(414, EPlanningStateValueType.Bool, 391, EPlanningStateSensorType.InventoryStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(415, EPlanningStateValueType.Bool, 391, EPlanningStateSensorType.InventoryStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(416, EPlanningStateValueType.Bool, 391, EPlanningStateSensorType.InventoryStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(417, EPlanningStateValueType.Bool, 391, EPlanningStateSensorType.InventoryStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(418, EPlanningStateValueType.Bool, 391, EPlanningStateSensorType.InventoryStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(419, EPlanningStateValueType.Bool, 391, EPlanningStateSensorType.InventoryStateSensor, -1, -1, 0));
	}

	private void CreateItems7()
	{
		_dataArray.Add(new PlanningStateItem(420, EPlanningStateValueType.Bool, 391, EPlanningStateSensorType.InventoryStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(421, EPlanningStateValueType.Bool, 391, EPlanningStateSensorType.InventoryStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(422, EPlanningStateValueType.Bool, 391, EPlanningStateSensorType.InventoryStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(423, EPlanningStateValueType.Bool, 391, EPlanningStateSensorType.InventoryStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(424, EPlanningStateValueType.Bool, 391, EPlanningStateSensorType.InventoryStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(425, EPlanningStateValueType.Bool, 391, EPlanningStateSensorType.InventoryStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(426, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.None, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(427, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.OrganizationStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(428, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.None, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(429, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.None, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(430, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.None, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(431, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.None, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(432, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.GoalArgumentStateSensor, 21, -1, 0));
		_dataArray.Add(new PlanningStateItem(433, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.GoalArgumentStateSensor, 21, -1, 0));
		_dataArray.Add(new PlanningStateItem(434, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.None, 11, -1, 0));
		_dataArray.Add(new PlanningStateItem(435, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.None, 11, -1, 0));
		_dataArray.Add(new PlanningStateItem(436, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.None, 11, -1, 0));
		_dataArray.Add(new PlanningStateItem(437, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.None, 11, -1, 0));
		_dataArray.Add(new PlanningStateItem(438, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.None, 11, -1, 0));
		_dataArray.Add(new PlanningStateItem(439, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.None, 11, -1, 0));
		_dataArray.Add(new PlanningStateItem(440, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.None, 11, -1, 0));
		_dataArray.Add(new PlanningStateItem(441, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, 12, -1, 0));
		_dataArray.Add(new PlanningStateItem(442, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, 7, -1, 0));
		_dataArray.Add(new PlanningStateItem(443, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, 8, -1, 0));
		_dataArray.Add(new PlanningStateItem(444, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, 7, -1, 0));
		_dataArray.Add(new PlanningStateItem(445, EPlanningStateValueType.Bool, 444, EPlanningStateSensorType.TriggerStateSensor, 8, -1, 0));
		_dataArray.Add(new PlanningStateItem(446, EPlanningStateValueType.Bool, 444, EPlanningStateSensorType.TriggerStateSensor, 8, -1, 0));
		_dataArray.Add(new PlanningStateItem(447, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, 7, -1, 0));
		_dataArray.Add(new PlanningStateItem(448, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, 8, -1, 0));
		_dataArray.Add(new PlanningStateItem(449, EPlanningStateValueType.Bool, 442, EPlanningStateSensorType.TriggerStateSensor, 7, -1, 0));
		_dataArray.Add(new PlanningStateItem(450, EPlanningStateValueType.Bool, 443, EPlanningStateSensorType.TriggerStateSensor, 8, -1, 0));
		_dataArray.Add(new PlanningStateItem(451, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, 7, -1, 0));
		_dataArray.Add(new PlanningStateItem(452, EPlanningStateValueType.Bool, 444, EPlanningStateSensorType.TriggerStateSensor, 7, -1, 0));
		_dataArray.Add(new PlanningStateItem(453, EPlanningStateValueType.Bool, 444, EPlanningStateSensorType.TriggerStateSensor, 8, -1, 0));
		_dataArray.Add(new PlanningStateItem(454, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, 7, -1, 0));
		_dataArray.Add(new PlanningStateItem(455, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, 8, -1, 0));
		_dataArray.Add(new PlanningStateItem(456, EPlanningStateValueType.Bool, 442, EPlanningStateSensorType.TriggerStateSensor, 7, -1, 0));
		_dataArray.Add(new PlanningStateItem(457, EPlanningStateValueType.Bool, 443, EPlanningStateSensorType.TriggerStateSensor, 8, -1, 0));
		_dataArray.Add(new PlanningStateItem(458, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, 7, -1, 0));
		_dataArray.Add(new PlanningStateItem(459, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(460, EPlanningStateValueType.Int, 459, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(461, EPlanningStateValueType.Int, 459, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(462, EPlanningStateValueType.Int, 459, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(463, EPlanningStateValueType.Int, 459, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(464, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(465, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(466, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(467, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(468, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(469, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(470, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(471, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(472, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(473, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(474, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(475, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(476, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(477, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(478, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(479, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
	}

	private void CreateItems8()
	{
		_dataArray.Add(new PlanningStateItem(480, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(481, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(482, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(483, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(484, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(485, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(486, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(487, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(488, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(489, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(490, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(491, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(492, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(493, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(494, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(495, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(496, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(497, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(498, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(499, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(500, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(501, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(502, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(503, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(504, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(505, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(506, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(507, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(508, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(509, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(510, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(511, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(512, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(513, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(514, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(515, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(516, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(517, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(518, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(519, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(520, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(521, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(522, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(523, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(524, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(525, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(526, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(527, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(528, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(529, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(530, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(531, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(532, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(533, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(534, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(535, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(536, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(537, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(538, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(539, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
	}

	private void CreateItems9()
	{
		_dataArray.Add(new PlanningStateItem(540, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(541, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(542, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(543, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(544, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(545, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(546, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(547, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(548, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(549, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(550, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(551, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(552, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(553, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(554, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(555, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(556, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(557, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(558, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(559, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(560, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(561, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(562, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(563, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(564, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(565, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(566, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(567, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(568, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(569, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(570, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(571, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(572, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(573, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(574, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(575, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(576, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(577, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(578, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(579, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(580, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(581, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(582, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(583, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(584, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(585, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(586, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(587, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(588, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(589, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(590, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(591, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(592, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(593, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(594, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(595, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(596, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(597, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(598, EPlanningStateValueType.Bool, 391, EPlanningStateSensorType.InventoryStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(599, EPlanningStateValueType.Bool, 391, EPlanningStateSensorType.None, -1, -1, 0));
	}

	private void CreateItems10()
	{
		_dataArray.Add(new PlanningStateItem(600, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.CharacterStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(601, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.None, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(602, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.GoalArgumentStateSensor, 11, -1, 0));
		_dataArray.Add(new PlanningStateItem(603, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.GoalArgumentStateSensor, 11, -1, 0));
		_dataArray.Add(new PlanningStateItem(604, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.None, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(605, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.None, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(606, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.OrganizationStateSensor, -1, -1, 0));
		_dataArray.Add(new PlanningStateItem(607, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.RelationStateSensor, -1, 0, 0));
		_dataArray.Add(new PlanningStateItem(608, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.RelationStateSensor, -1, 0, 0));
		_dataArray.Add(new PlanningStateItem(609, EPlanningStateValueType.Int, -1, EPlanningStateSensorType.RelationStateSensor, -1, 0, 0));
		_dataArray.Add(new PlanningStateItem(610, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.GoalArgumentStateSensor, 12, -1, 0));
		_dataArray.Add(new PlanningStateItem(611, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.GoalArgumentStateSensor, 12, -1, 0));
		_dataArray.Add(new PlanningStateItem(612, EPlanningStateValueType.Bool, -1, EPlanningStateSensorType.TriggerStateSensor, -1, -1, 0));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<PlanningStateItem>(613);
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
	}
}
