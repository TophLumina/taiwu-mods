using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class SortItem : ConfigData<SortItemItem, short>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 名称
		/// </summary>
		public const short Name = 0;

		/// <summary>
		/// 通用品阶
		/// </summary>
		public const short Grade = 1;

		/// <summary>
		/// 功法威力
		/// </summary>
		public const short CombatSkillPower = 2;

		/// <summary>
		/// 功法玄机
		/// </summary>
		public const short CombatSkillBonus = 3;

		/// <summary>
		/// 已读页数
		/// </summary>
		public const short ReadCount = 4;

		/// <summary>
		/// 道具价值
		/// </summary>
		public const short ItemValue = 5;

		/// <summary>
		/// 道具重量
		/// </summary>
		public const short ItemWeight = 6;

		/// <summary>
		/// 见闻次数
		/// </summary>
		public const short InformationLeftTime = 7;

		/// <summary>
		/// 年龄
		/// </summary>
		public const short CharacterAge = 8;

		/// <summary>
		/// 魅力
		/// </summary>
		public const short CharacterCharm = 9;

		/// <summary>
		/// 健康
		/// </summary>
		public const short CharacterHealth = 10;

		/// <summary>
		/// 好感
		/// </summary>
		public const short CharacterFavorabilityToTaiwu = 11;

		/// <summary>
		/// 心情
		/// </summary>
		public const short CharacterHappiness = 12;

		/// <summary>
		/// 培养次数
		/// </summary>
		public const short VillagerLeftPotentialCount = 13;

		/// <summary>
		/// 关押时长
		/// </summary>
		public const short PrisonerDuration = 14;

		/// <summary>
		/// 惩罚力度
		/// </summary>
		public const short PunishmentSeverity = 15;

		/// <summary>
		/// 悬赏金额
		/// </summary>
		public const short BountyAmount = 16;

		/// <summary>
		/// 道具数量
		/// </summary>
		public const short ItemAmount = 17;

		/// <summary>
		/// 当前耐久
		/// </summary>
		public const short CurrentDurability = 18;

		/// <summary>
		/// 威力
		/// </summary>
		public const short Power = 19;

		/// <summary>
		/// 破甲
		/// </summary>
		public const short ArmorBreak = 20;

		/// <summary>
		/// 坚韧
		/// </summary>
		public const short EquipmentDefense = 21;

		/// <summary>
		/// 破体
		/// </summary>
		public const short PenetrateOuter = 22;

		/// <summary>
		/// 破气
		/// </summary>
		public const short PenetrateInner = 23;

		/// <summary>
		/// 力道
		/// </summary>
		public const short HitRateStrength = 24;

		/// <summary>
		/// 精妙
		/// </summary>
		public const short HitRateTechnique = 25;

		/// <summary>
		/// 迅疾
		/// </summary>
		public const short HitRateSpeed = 26;

		/// <summary>
		/// 动心
		/// </summary>
		public const short HitRateMind = 27;

		/// <summary>
		/// 破刃
		/// </summary>
		public const short WeaponBreak = 28;

		/// <summary>
		/// 御体
		/// </summary>
		public const short PenetrateResistOuter = 29;

		/// <summary>
		/// 御气
		/// </summary>
		public const short PenetrateResistInner = 30;

		/// <summary>
		/// 内伤降低
		/// </summary>
		public const short InnerWoundReduce = 31;

		/// <summary>
		/// 外伤降低
		/// </summary>
		public const short OutterWoundReduce = 32;

		/// <summary>
		/// 卸力
		/// </summary>
		public const short AvoidRateStrength = 33;

		/// <summary>
		/// 拆招
		/// </summary>
		public const short AvoidRateTechnique = 34;

		/// <summary>
		/// 闪避
		/// </summary>
		public const short AvoidRateSpeed = 35;

		/// <summary>
		/// 守心
		/// </summary>
		public const short AvoidRateMind = 36;

		/// <summary>
		/// 负重
		/// </summary>
		public const short Carriage = 37;

		/// <summary>
		/// 精力消耗
		/// </summary>
		public const short Energy = 38;

		/// <summary>
		/// 战利品
		/// </summary>
		public const short Loot = 39;

		/// <summary>
		/// 降服概率
		/// </summary>
		public const short SubdueRate = 40;

		/// <summary>
		/// 驯服度
		/// </summary>
		public const short TameRate = 41;

		/// <summary>
		/// 促织耐久
		/// </summary>
		public const short CricketDurability = 42;

		/// <summary>
		/// 蜇龄
		/// </summary>
		public const short CricketAge = 43;

		/// <summary>
		/// 胜利
		/// </summary>
		public const short CricketWin = 44;

		/// <summary>
		/// 败绩
		/// </summary>
		public const short CricketLose = 45;

		/// <summary>
		/// 促织耐力
		/// </summary>
		public const short CricketVitality = 46;

		/// <summary>
		/// 促织斗性
		/// </summary>
		public const short CricketSpirit = 47;

		/// <summary>
		/// 促织气势
		/// </summary>
		public const short CricketVigor = 48;

		/// <summary>
		/// 促织角力
		/// </summary>
		public const short CricketStrength = 49;

		/// <summary>
		/// 促织牙钳
		/// </summary>
		public const short CricketTeeth = 50;

		/// <summary>
		/// 医术造诣
		/// </summary>
		public const short MedicineAttainment = 51;

		/// <summary>
		/// 毒术造诣
		/// </summary>
		public const short ToxicologyAttainment = 52;

		/// <summary>
		/// 总伤势
		/// </summary>
		public const short TotalInjuries = 53;

		/// <summary>
		/// 总毒素
		/// </summary>
		public const short TotalPoisons = 54;

		/// <summary>
		/// 内息
		/// </summary>
		public const short QiDisorder = 55;

		/// <summary>
		/// 类型
		/// </summary>
		public const short Type = 56;

		/// <summary>
		/// 立场
		/// </summary>
		public const short BehaviourType = 57;

		/// <summary>
		/// 轮回
		/// </summary>
		public const short Samsara = 58;

		/// <summary>
		/// 名誉
		/// </summary>
		public const short Fame = 59;

		/// <summary>
		/// 膂力
		/// </summary>
		public const short MainAttribute0 = 60;

		/// <summary>
		/// 灵敏
		/// </summary>
		public const short MainAttribute1 = 61;

		/// <summary>
		/// 定力
		/// </summary>
		public const short MainAttribute2 = 62;

		/// <summary>
		/// 体质
		/// </summary>
		public const short MainAttribute3 = 63;

		/// <summary>
		/// 根骨
		/// </summary>
		public const short MainAttribute4 = 64;

		/// <summary>
		/// 悟性
		/// </summary>
		public const short MainAttribute5 = 65;

		/// <summary>
		/// 音律
		/// </summary>
		public const short LKLifeSkillType0 = 66;

		/// <summary>
		/// 弈棋
		/// </summary>
		public const short LKLifeSkillType1 = 67;

		/// <summary>
		/// 诗书
		/// </summary>
		public const short LKLifeSkillType2 = 68;

		/// <summary>
		/// 绘画
		/// </summary>
		public const short LKLifeSkillType3 = 69;

		/// <summary>
		/// 术数
		/// </summary>
		public const short LKLifeSkillType4 = 70;

		/// <summary>
		/// 品鉴
		/// </summary>
		public const short LKLifeSkillType5 = 71;

		/// <summary>
		/// 锻造
		/// </summary>
		public const short LKLifeSkillType6 = 72;

		/// <summary>
		/// 制木
		/// </summary>
		public const short LKLifeSkillType7 = 73;

		/// <summary>
		/// 医术
		/// </summary>
		public const short LKLifeSkillType8 = 74;

		/// <summary>
		/// 毒术
		/// </summary>
		public const short LKLifeSkillType9 = 75;

		/// <summary>
		/// 织锦
		/// </summary>
		public const short LKLifeSkillType10 = 76;

		/// <summary>
		/// 巧匠
		/// </summary>
		public const short LKLifeSkillType11 = 77;

		/// <summary>
		/// 道法
		/// </summary>
		public const short LKLifeSkillType12 = 78;

		/// <summary>
		/// 佛学
		/// </summary>
		public const short LKLifeSkillType13 = 79;

		/// <summary>
		/// 厨艺
		/// </summary>
		public const short LKLifeSkillType14 = 80;

		/// <summary>
		/// 杂学
		/// </summary>
		public const short LKLifeSkillType15 = 81;

		/// <summary>
		/// 内功
		/// </summary>
		public const short LKCombatSkillType0 = 82;

		/// <summary>
		/// 身法
		/// </summary>
		public const short LKCombatSkillType1 = 83;

		/// <summary>
		/// 绝技
		/// </summary>
		public const short LKCombatSkillType2 = 84;

		/// <summary>
		/// 拳掌
		/// </summary>
		public const short LKCombatSkillType3 = 85;

		/// <summary>
		/// 指法
		/// </summary>
		public const short LKCombatSkillType4 = 86;

		/// <summary>
		/// 腿法
		/// </summary>
		public const short LKCombatSkillType5 = 87;

		/// <summary>
		/// 暗器
		/// </summary>
		public const short LKCombatSkillType6 = 88;

		/// <summary>
		/// 剑法
		/// </summary>
		public const short LKCombatSkillType7 = 89;

		/// <summary>
		/// 刀法
		/// </summary>
		public const short LKCombatSkillType8 = 90;

		/// <summary>
		/// 长兵
		/// </summary>
		public const short LKCombatSkillType9 = 91;

		/// <summary>
		/// 奇门
		/// </summary>
		public const short LKCombatSkillType10 = 92;

		/// <summary>
		/// 软兵
		/// </summary>
		public const short LKCombatSkillType11 = 93;

		/// <summary>
		/// 御射
		/// </summary>
		public const short LKCombatSkillType12 = 94;

		/// <summary>
		/// 乐器
		/// </summary>
		public const short LKCombatSkillType13 = 95;

		/// <summary>
		/// 冷静
		/// </summary>
		public const short Personality0 = 96;

		/// <summary>
		/// 聪颖
		/// </summary>
		public const short Personality1 = 97;

		/// <summary>
		/// 热情
		/// </summary>
		public const short Personality2 = 98;

		/// <summary>
		/// 勇壮
		/// </summary>
		public const short Personality3 = 99;

		/// <summary>
		/// 坚毅
		/// </summary>
		public const short Personality4 = 100;

		/// <summary>
		/// 福缘
		/// </summary>
		public const short Personality5 = 101;

		/// <summary>
		/// 合道
		/// </summary>
		public const short Personality6 = 102;

		/// <summary>
		/// 食材
		/// </summary>
		public const short ResourceType0 = 103;

		/// <summary>
		/// 木材
		/// </summary>
		public const short ResourceType1 = 104;

		/// <summary>
		/// 金铁
		/// </summary>
		public const short ResourceType2 = 105;

		/// <summary>
		/// 玉石
		/// </summary>
		public const short ResourceType3 = 106;

		/// <summary>
		/// 织物
		/// </summary>
		public const short ResourceType4 = 107;

		/// <summary>
		/// 药材
		/// </summary>
		public const short ResourceType5 = 108;

		/// <summary>
		/// 银钱
		/// </summary>
		public const short ResourceType6 = 109;

		/// <summary>
		/// 威望
		/// </summary>
		public const short ResourceType7 = 110;

		/// <summary>
		/// 关押数量
		/// </summary>
		public const short KidnapCount = 111;

		/// <summary>
		/// 进攻
		/// </summary>
		public const short AttackMedal = 112;

		/// <summary>
		/// 守御
		/// </summary>
		public const short DefenceMedal = 113;

		/// <summary>
		/// 机略
		/// </summary>
		public const short WisdomMedal = 114;

		/// <summary>
		/// 同道指令0
		/// </summary>
		public const short Command0 = 115;

		/// <summary>
		/// 同道指令1
		/// </summary>
		public const short Command1 = 116;

		/// <summary>
		/// 同道指令2
		/// </summary>
		public const short Command2 = 117;

		/// <summary>
		/// 技艺成长
		/// </summary>
		public const short LifeSkillGrowth = 118;

		/// <summary>
		/// 武学成长
		/// </summary>
		public const short CombatSkillGrowth = 119;

		/// <summary>
		/// 抵抗值
		/// </summary>
		public const short Resistance = 120;

		/// <summary>
		/// 功法造诣
		/// </summary>
		public const short CombatSKillAttainment = 121;

		/// <summary>
		/// 性别
		/// </summary>
		public const short Gender = 122;

		/// <summary>
		/// 入魔值
		/// </summary>
		public const short Infection = 123;

		/// <summary>
		/// 武学类型
		/// </summary>
		public const short CombatSkillType = 124;

		/// <summary>
		/// 所在地点
		/// </summary>
		public const short Location = 125;

		/// <summary>
		/// 经营地点
		/// </summary>
		public const short WorkingLocation = 126;

		/// <summary>
		/// 经营岗位
		/// </summary>
		public const short WorkingRole = 127;

		/// <summary>
		/// 潜力
		/// </summary>
		public const short Potential = 128;

		/// <summary>
		/// 工作状态
		/// </summary>
		public const short WorkingStatus = 129;

		/// <summary>
		/// 戒心
		/// </summary>
		public const short Alertness = 130;

		/// <summary>
		/// 心法进度
		/// </summary>
		public const short SpecialBreakBonusProgress = 131;

		/// <summary>
		/// 拿取人数
		/// </summary>
		public const short RequireCharacterAmount = 133;

		/// <summary>
		/// 拿取时间
		/// </summary>
		public const short TakeAfterMonth = 134;

		/// <summary>
		/// 拿取数量
		/// </summary>
		public const short TakeAmount = 135;

		/// <summary>
		/// 关系
		/// </summary>
		public const short Relationship = 136;

		/// <summary>
		/// 势力值
		/// </summary>
		public const short Contribution = 137;

		/// <summary>
		/// 支持度
		/// </summary>
		public const short ApprovingRate = 178;

		/// <summary>
		/// 库房补充几率
		/// </summary>
		public const short SupplyRate = 132;

		/// <summary>
		/// 关押原因
		/// </summary>
		public const short PunishmentType = 138;

		/// <summary>
		/// 人物身份
		/// </summary>
		public const short CharacterIdentity = 139;

		/// <summary>
		/// 武学资质总和
		/// </summary>
		public const short CombatSkillQualificationSum = 140;

		/// <summary>
		/// 技艺资质总和
		/// </summary>
		public const short LifeSkillQualificationSum = 141;

		/// <summary>
		/// 主属性总和
		/// </summary>
		public const short MainAttributeSum = 142;

		/// <summary>
		/// 精纯
		/// </summary>
		public const short ConsummateLevel = 143;

		/// <summary>
		/// 内力增长
		/// </summary>
		public const short LoopingObtainedNeili = 144;

		/// <summary>
		/// 五行转移
		/// </summary>
		public const short LoopingFiveElementTranferAmound = 145;

		/// <summary>
		/// 内力获取
		/// </summary>
		public const short LoopingNeili = 146;

		/// <summary>
		/// 真气获取
		/// </summary>
		public const short LoopingNeiliAllocation = 147;

		/// <summary>
		/// 天人感应
		/// </summary>
		public const short LoopingEvent = 148;

		/// <summary>
		/// 周天策略
		/// </summary>
		public const short LoopingStrategy = 149;

		/// <summary>
		/// 七元
		/// </summary>
		public const short Personality = 150;

		/// <summary>
		/// 悬赏原身份等级
		/// </summary>
		public const short OriginalGrade = 151;

		/// <summary>
		/// 志向名称
		/// </summary>
		public const short ProfessionName = 152;

		/// <summary>
		/// 志向资历
		/// </summary>
		public const short ProfessionSeniority = 153;

		/// <summary>
		/// 见闻阶级
		/// </summary>
		public const short InformationLevel = 154;

		/// <summary>
		/// 使用次数
		/// </summary>
		public const short InformationCanUseCount = 155;

		/// <summary>
		/// 出现月份
		/// </summary>
		public const short SecretOccurenceDate = 159;

		/// <summary>
		/// 重要程度
		/// </summary>
		public const short SecretLevel = 160;

		/// <summary>
		/// 剩余时间
		/// </summary>
		public const short SecretLifeTime = 161;

		/// <summary>
		/// 已知人数
		/// </summary>
		public const short SecretKnownCount = 162;

		/// <summary>
		/// 可用次数
		/// </summary>
		public const short SecretCanUseCount = 163;

		/// <summary>
		/// 传播概率
		/// </summary>
		public const short SecretDisseminationRate = 164;

		/// <summary>
		/// 制造所需造诣
		/// </summary>
		public const short MakeNeedAttainment = 156;

		/// <summary>
		/// 制造可用工具数量
		/// </summary>
		public const short MakeAvailableToolCount = 157;

		/// <summary>
		/// 制造可用引子数量
		/// </summary>
		public const short MakeAvailableMaterialCount = 158;

		/// <summary>
		/// 毒素属性
		/// </summary>
		public const short PoisonInfo = 165;

		/// <summary>
		/// 书籍信息
		/// </summary>
		public const short BookInfo = 166;

		/// <summary>
		/// 精制效果
		/// </summary>
		public const short RefineEffect = 167;

		/// <summary>
		/// 精制属性
		/// </summary>
		public const short RefineAttribute = 168;

		/// <summary>
		/// 产出概率
		/// </summary>
		public const short ProductRate = 169;

		/// <summary>
		/// 模组状态
		/// </summary>
		public const short ModStatus = 170;

		/// <summary>
		/// 模组顺序
		/// </summary>
		public const short ModOrder = 171;

		/// <summary>
		/// 模组名字
		/// </summary>
		public const short ModName = 172;

		/// <summary>
		/// 模组评分
		/// </summary>
		public const short ModRate = 173;

		/// <summary>
		/// 模组上传时间
		/// </summary>
		public const short ModUploadTime = 174;

		/// <summary>
		/// 模组修改时间
		/// </summary>
		public const short ModUpdateTime = 175;

		/// <summary>
		/// 模组大小
		/// </summary>
		public const short ModSize = 176;

		/// <summary>
		/// 模组版本
		/// </summary>
		public const short ModVersion = 177;

		/// <summary>
		/// 农户自动采集次数
		/// </summary>
		public const short FarmerAutoCollectActionCount = 179;

		/// <summary>
		/// 农户迁移心材成功率
		/// </summary>
		public const short FarmerMigrateResourceSuccessRate = 180;

		/// <summary>
		/// 农户迁移心材额外成功率
		/// </summary>
		public const short FarmerMigrateResourceExtraSuccessRate = 181;

		/// <summary>
		/// 农户元鸡心材升级几率
		/// </summary>
		public const short FarmerChickenUpgradeBuildingCoreRate = 182;

		/// <summary>
		/// 大夫可互动人物品级
		/// </summary>
		public const short DoctorInteractTargetGrade = 183;

		/// <summary>
		/// 大夫元鸡降低入魔值量
		/// </summary>
		public const short DoctorChickenUpgradeInfectionChangeAmount = 184;

		/// <summary>
		/// 商人可互动人物品级
		/// </summary>
		public const short MerchantInteractTargetGrade = 185;

		/// <summary>
		/// 商人购买物品价格比例
		/// </summary>
		public const short MerchantBuyItemPriceRate = 186;

		/// <summary>
		/// 商人出售物品价格比例
		/// </summary>
		public const short MerchantSellItemPriceRate = 187;

		/// <summary>
		/// 商人元鸡增加地区商会总部好感
		/// </summary>
		public const short MerchantChickenIncreaseHeadMerchantFavor = 188;

		/// <summary>
		/// 商人元鸡增加地区商会分部好感
		/// </summary>
		public const short MerchantChickenIncreaseBranchMerchantFavor = 189;

		/// <summary>
		/// 文人派遣行为可进行的次数
		/// </summary>
		public const short LiteratiWorkUsableCount = 190;

		/// <summary>
		/// 文人派遣行为影响的量
		/// </summary>
		public const short LiteratiWorkEffectiveValue = 191;

		/// <summary>
		/// 文人元鸡影响的人数
		/// </summary>
		public const short LiteratiChickenInfluenceCount = 192;

		/// <summary>
		/// 文人元鸡变化的好感
		/// </summary>
		public const short LiteratiChickenRelationChange = 193;

		/// <summary>
		/// 护冢派遣行为收集几率
		/// </summary>
		public const short SwordTombKeeperWorkCollectOdd = 194;

		/// <summary>
		/// 护冢派遣行为受伤几率
		/// </summary>
		public const short SwordTombKeeperWorkHurtOdd = 195;

		/// <summary>
		/// 护冢派遣行为收集见闻时得到特性几率
		/// </summary>
		public const short SwordTombKeeperWorkFeatureOddWhenInformationCollect = 196;

		/// <summary>
		/// 护冢派遣行为被攻击时得到特性几率
		/// </summary>
		public const short SwordTombKeeperWorkFeatureOddWhenBeAttacked = 197;

		/// <summary>
		/// 护冢元鸡降低比例
		/// </summary>
		public const short SwordTombKeeperChickenDecreaseFactor = 198;

		/// <summary>
		/// 使者派遣行为超常数量
		/// </summary>
		public const short VillageHeadWorkSpecialRuleCount = 199;

		/// <summary>
		/// 使者派遣行为每月威望消耗
		/// </summary>
		public const short VillageHeadWorkMonthlyAuthorityCost = 200;

		/// <summary>
		/// 玄灰绝命
		/// </summary>
		public const short DarkAsh = 201;

		/// <summary>
		/// 鼎蛟淬身
		/// </summary>
		public const short TripodVesselProtect = 202;

		/// <summary>
		/// 从属
		/// </summary>
		public const short Organization = 203;

		/// <summary>
		/// 剩余份量
		/// </summary>
		public const short FoodRemainDurability = 204;

		/// <summary>
		/// 医毒
		/// </summary>
		public const short DoctorLifeSkill = 205;

		/// <summary>
		/// 琴棋书画
		/// </summary>
		public const short LiteratiLifeSkill = 206;

		/// <summary>
		/// 佛道
		/// </summary>
		public const short TombKeeperLifeSkill = 207;

		/// <summary>
		/// 武学
		/// </summary>
		public const short HighestCombatSkill = 208;

		/// <summary>
		/// 款式名称
		/// </summary>
		public const short WeavedClothingTemplateId = 209;

		/// <summary>
		/// 改制使用次数
		/// </summary>
		public const short WeavedCount = 210;

		/// <summary>
		/// 工具造诣
		/// </summary>
		public const short ToolAttainment = 211;

		/// <summary>
		/// 商店物品价值
		/// </summary>
		public const short ShopItemValue = 212;

		/// <summary>
		/// 商店物品价格
		/// </summary>
		public const short ShopItemPrice = 213;

		/// <summary>
		/// 书籍效率
		/// </summary>
		public const short BookEfficiency = 214;

		/// <summary>
		/// 书籍灵感
		/// </summary>
		public const short BookInspiration = 215;

		/// <summary>
		/// 功法实战
		/// </summary>
		public const short CombatSkillProficiency = 216;

		/// <summary>
		/// 毒素数量
		/// </summary>
		public const short PoisonsCount = 217;

		/// <summary>
		/// 金刚内力
		/// </summary>
		public const short NeiliTypeMetal = 218;

		/// <summary>
		/// 紫霞内力
		/// </summary>
		public const short NeiliTypeWood = 219;

		/// <summary>
		/// 玄阴内力
		/// </summary>
		public const short NeiliTypeWater = 220;

		/// <summary>
		/// 纯阳内力
		/// </summary>
		public const short NeiliTypeFire = 221;

		/// <summary>
		/// 归元内力
		/// </summary>
		public const short NeiliTypeEarth = 222;

		/// <summary>
		/// 研读进度
		/// </summary>
		public const short BookReadingProgress = 223;

		/// <summary>
		/// 促织灵性
		/// </summary>
		public const short CricketPolymorphSpirit = 224;

		/// <summary>
		/// 音律造诣
		/// </summary>
		public const short LKLifeSkillAttainmentType0 = 225;

		/// <summary>
		/// 弈棋造诣
		/// </summary>
		public const short LKLifeSkillAttainmentType1 = 226;

		/// <summary>
		/// 诗书造诣
		/// </summary>
		public const short LKLifeSkillAttainmentType2 = 227;

		/// <summary>
		/// 绘画造诣
		/// </summary>
		public const short LKLifeSkillAttainmentType3 = 228;

		/// <summary>
		/// 术数造诣
		/// </summary>
		public const short LKLifeSkillAttainmentType4 = 229;

		/// <summary>
		/// 品鉴造诣
		/// </summary>
		public const short LKLifeSkillAttainmentType5 = 230;

		/// <summary>
		/// 锻造造诣
		/// </summary>
		public const short LKLifeSkillAttainmentType6 = 231;

		/// <summary>
		/// 制木造诣
		/// </summary>
		public const short LKLifeSkillAttainmentType7 = 232;

		/// <summary>
		/// 角色医术造诣
		/// </summary>
		public const short LKLifeSkillAttainmentType8 = 253;

		/// <summary>
		/// 角色毒术造诣
		/// </summary>
		public const short LKLifeSkillAttainmentType9 = 254;

		/// <summary>
		/// 织锦造诣
		/// </summary>
		public const short LKLifeSkillAttainmentType10 = 233;

		/// <summary>
		/// 巧匠造诣
		/// </summary>
		public const short LKLifeSkillAttainmentType11 = 234;

		/// <summary>
		/// 道法造诣
		/// </summary>
		public const short LKLifeSkillAttainmentType12 = 235;

		/// <summary>
		/// 佛学造诣
		/// </summary>
		public const short LKLifeSkillAttainmentType13 = 236;

		/// <summary>
		/// 厨艺造诣
		/// </summary>
		public const short LKLifeSkillAttainmentType14 = 237;

		/// <summary>
		/// 杂学造诣
		/// </summary>
		public const short LKLifeSkillAttainmentType15 = 238;

		/// <summary>
		/// 内功造诣
		/// </summary>
		public const short LKCombatSkillAttainmentType0 = 239;

		/// <summary>
		/// 身法造诣
		/// </summary>
		public const short LKCombatSkillAttainmentType1 = 240;

		/// <summary>
		/// 绝技造诣
		/// </summary>
		public const short LKCombatSkillAttainmentType2 = 241;

		/// <summary>
		/// 拳掌造诣
		/// </summary>
		public const short LKCombatSkillAttainmentType3 = 242;

		/// <summary>
		/// 指法造诣
		/// </summary>
		public const short LKCombatSkillAttainmentType4 = 243;

		/// <summary>
		/// 腿法造诣
		/// </summary>
		public const short LKCombatSkillAttainmentType5 = 244;

		/// <summary>
		/// 暗器造诣
		/// </summary>
		public const short LKCombatSkillAttainmentType6 = 245;

		/// <summary>
		/// 剑法造诣
		/// </summary>
		public const short LKCombatSkillAttainmentType7 = 246;

		/// <summary>
		/// 刀法造诣
		/// </summary>
		public const short LKCombatSkillAttainmentType8 = 247;

		/// <summary>
		/// 长兵造诣
		/// </summary>
		public const short LKCombatSkillAttainmentType9 = 248;

		/// <summary>
		/// 奇门造诣
		/// </summary>
		public const short LKCombatSkillAttainmentType10 = 249;

		/// <summary>
		/// 软兵造诣
		/// </summary>
		public const short LKCombatSkillAttainmentType11 = 250;

		/// <summary>
		/// 御射造诣
		/// </summary>
		public const short LKCombatSkillAttainmentType12 = 251;

		/// <summary>
		/// 乐器造诣
		/// </summary>
		public const short LKCombatSkillAttainmentType13 = 252;

		/// <summary>
		/// 坟墓耐久
		/// </summary>
		public const short GraveDurability = 255;

		/// <summary>
		/// 生于
		/// </summary>
		public const short CharacterBirthDate = 256;

		/// <summary>
		/// 卒于
		/// </summary>
		public const short CharacterDeathDate = 257;

		/// <summary>
		/// 中蛊数量
		/// </summary>
		public const short NormalWugCount = 258;

		/// <summary>
		/// 摧破真气
		/// </summary>
		public const short ExtraNeiliAllocationAttack = 259;

		/// <summary>
		/// 轻灵真气
		/// </summary>
		public const short ExtraNeiliAllocationAgility = 260;

		/// <summary>
		/// 护体真气
		/// </summary>
		public const short ExtraNeiliAllocationDefense = 261;

		/// <summary>
		/// 奇窍真气
		/// </summary>
		public const short ExtraNeiliAllocationAssistance = 262;

		/// <summary>
		/// 奇书功法类型
		/// </summary>
		public const short LegendaryBookType = 263;

		/// <summary>
		/// 奇书特性
		/// </summary>
		public const short LegendaryBookFeature = 264;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 名称
		/// </summary>
		public static SortItemItem Name => Instance[(short)0];

		/// <summary>
		/// 通用品阶
		/// </summary>
		public static SortItemItem Grade => Instance[(short)1];

		/// <summary>
		/// 功法威力
		/// </summary>
		public static SortItemItem CombatSkillPower => Instance[(short)2];

		/// <summary>
		/// 功法玄机
		/// </summary>
		public static SortItemItem CombatSkillBonus => Instance[(short)3];

		/// <summary>
		/// 已读页数
		/// </summary>
		public static SortItemItem ReadCount => Instance[(short)4];

		/// <summary>
		/// 道具价值
		/// </summary>
		public static SortItemItem ItemValue => Instance[(short)5];

		/// <summary>
		/// 道具重量
		/// </summary>
		public static SortItemItem ItemWeight => Instance[(short)6];

		/// <summary>
		/// 见闻次数
		/// </summary>
		public static SortItemItem InformationLeftTime => Instance[(short)7];

		/// <summary>
		/// 年龄
		/// </summary>
		public static SortItemItem CharacterAge => Instance[(short)8];

		/// <summary>
		/// 魅力
		/// </summary>
		public static SortItemItem CharacterCharm => Instance[(short)9];

		/// <summary>
		/// 健康
		/// </summary>
		public static SortItemItem CharacterHealth => Instance[(short)10];

		/// <summary>
		/// 好感
		/// </summary>
		public static SortItemItem CharacterFavorabilityToTaiwu => Instance[(short)11];

		/// <summary>
		/// 心情
		/// </summary>
		public static SortItemItem CharacterHappiness => Instance[(short)12];

		/// <summary>
		/// 培养次数
		/// </summary>
		public static SortItemItem VillagerLeftPotentialCount => Instance[(short)13];

		/// <summary>
		/// 关押时长
		/// </summary>
		public static SortItemItem PrisonerDuration => Instance[(short)14];

		/// <summary>
		/// 惩罚力度
		/// </summary>
		public static SortItemItem PunishmentSeverity => Instance[(short)15];

		/// <summary>
		/// 悬赏金额
		/// </summary>
		public static SortItemItem BountyAmount => Instance[(short)16];

		/// <summary>
		/// 道具数量
		/// </summary>
		public static SortItemItem ItemAmount => Instance[(short)17];

		/// <summary>
		/// 当前耐久
		/// </summary>
		public static SortItemItem CurrentDurability => Instance[(short)18];

		/// <summary>
		/// 威力
		/// </summary>
		public static SortItemItem Power => Instance[(short)19];

		/// <summary>
		/// 破甲
		/// </summary>
		public static SortItemItem ArmorBreak => Instance[(short)20];

		/// <summary>
		/// 坚韧
		/// </summary>
		public static SortItemItem EquipmentDefense => Instance[(short)21];

		/// <summary>
		/// 破体
		/// </summary>
		public static SortItemItem PenetrateOuter => Instance[(short)22];

		/// <summary>
		/// 破气
		/// </summary>
		public static SortItemItem PenetrateInner => Instance[(short)23];

		/// <summary>
		/// 力道
		/// </summary>
		public static SortItemItem HitRateStrength => Instance[(short)24];

		/// <summary>
		/// 精妙
		/// </summary>
		public static SortItemItem HitRateTechnique => Instance[(short)25];

		/// <summary>
		/// 迅疾
		/// </summary>
		public static SortItemItem HitRateSpeed => Instance[(short)26];

		/// <summary>
		/// 动心
		/// </summary>
		public static SortItemItem HitRateMind => Instance[(short)27];

		/// <summary>
		/// 破刃
		/// </summary>
		public static SortItemItem WeaponBreak => Instance[(short)28];

		/// <summary>
		/// 御体
		/// </summary>
		public static SortItemItem PenetrateResistOuter => Instance[(short)29];

		/// <summary>
		/// 御气
		/// </summary>
		public static SortItemItem PenetrateResistInner => Instance[(short)30];

		/// <summary>
		/// 内伤降低
		/// </summary>
		public static SortItemItem InnerWoundReduce => Instance[(short)31];

		/// <summary>
		/// 外伤降低
		/// </summary>
		public static SortItemItem OutterWoundReduce => Instance[(short)32];

		/// <summary>
		/// 卸力
		/// </summary>
		public static SortItemItem AvoidRateStrength => Instance[(short)33];

		/// <summary>
		/// 拆招
		/// </summary>
		public static SortItemItem AvoidRateTechnique => Instance[(short)34];

		/// <summary>
		/// 闪避
		/// </summary>
		public static SortItemItem AvoidRateSpeed => Instance[(short)35];

		/// <summary>
		/// 守心
		/// </summary>
		public static SortItemItem AvoidRateMind => Instance[(short)36];

		/// <summary>
		/// 负重
		/// </summary>
		public static SortItemItem Carriage => Instance[(short)37];

		/// <summary>
		/// 精力消耗
		/// </summary>
		public static SortItemItem Energy => Instance[(short)38];

		/// <summary>
		/// 战利品
		/// </summary>
		public static SortItemItem Loot => Instance[(short)39];

		/// <summary>
		/// 降服概率
		/// </summary>
		public static SortItemItem SubdueRate => Instance[(short)40];

		/// <summary>
		/// 驯服度
		/// </summary>
		public static SortItemItem TameRate => Instance[(short)41];

		/// <summary>
		/// 促织耐久
		/// </summary>
		public static SortItemItem CricketDurability => Instance[(short)42];

		/// <summary>
		/// 蜇龄
		/// </summary>
		public static SortItemItem CricketAge => Instance[(short)43];

		/// <summary>
		/// 胜利
		/// </summary>
		public static SortItemItem CricketWin => Instance[(short)44];

		/// <summary>
		/// 败绩
		/// </summary>
		public static SortItemItem CricketLose => Instance[(short)45];

		/// <summary>
		/// 促织耐力
		/// </summary>
		public static SortItemItem CricketVitality => Instance[(short)46];

		/// <summary>
		/// 促织斗性
		/// </summary>
		public static SortItemItem CricketSpirit => Instance[(short)47];

		/// <summary>
		/// 促织气势
		/// </summary>
		public static SortItemItem CricketVigor => Instance[(short)48];

		/// <summary>
		/// 促织角力
		/// </summary>
		public static SortItemItem CricketStrength => Instance[(short)49];

		/// <summary>
		/// 促织牙钳
		/// </summary>
		public static SortItemItem CricketTeeth => Instance[(short)50];

		/// <summary>
		/// 医术造诣
		/// </summary>
		public static SortItemItem MedicineAttainment => Instance[(short)51];

		/// <summary>
		/// 毒术造诣
		/// </summary>
		public static SortItemItem ToxicologyAttainment => Instance[(short)52];

		/// <summary>
		/// 总伤势
		/// </summary>
		public static SortItemItem TotalInjuries => Instance[(short)53];

		/// <summary>
		/// 总毒素
		/// </summary>
		public static SortItemItem TotalPoisons => Instance[(short)54];

		/// <summary>
		/// 内息
		/// </summary>
		public static SortItemItem QiDisorder => Instance[(short)55];

		/// <summary>
		/// 类型
		/// </summary>
		public static SortItemItem Type => Instance[(short)56];

		/// <summary>
		/// 立场
		/// </summary>
		public static SortItemItem BehaviourType => Instance[(short)57];

		/// <summary>
		/// 轮回
		/// </summary>
		public static SortItemItem Samsara => Instance[(short)58];

		/// <summary>
		/// 名誉
		/// </summary>
		public static SortItemItem Fame => Instance[(short)59];

		/// <summary>
		/// 膂力
		/// </summary>
		public static SortItemItem MainAttribute0 => Instance[(short)60];

		/// <summary>
		/// 灵敏
		/// </summary>
		public static SortItemItem MainAttribute1 => Instance[(short)61];

		/// <summary>
		/// 定力
		/// </summary>
		public static SortItemItem MainAttribute2 => Instance[(short)62];

		/// <summary>
		/// 体质
		/// </summary>
		public static SortItemItem MainAttribute3 => Instance[(short)63];

		/// <summary>
		/// 根骨
		/// </summary>
		public static SortItemItem MainAttribute4 => Instance[(short)64];

		/// <summary>
		/// 悟性
		/// </summary>
		public static SortItemItem MainAttribute5 => Instance[(short)65];

		/// <summary>
		/// 音律
		/// </summary>
		public static SortItemItem LKLifeSkillType0 => Instance[(short)66];

		/// <summary>
		/// 弈棋
		/// </summary>
		public static SortItemItem LKLifeSkillType1 => Instance[(short)67];

		/// <summary>
		/// 诗书
		/// </summary>
		public static SortItemItem LKLifeSkillType2 => Instance[(short)68];

		/// <summary>
		/// 绘画
		/// </summary>
		public static SortItemItem LKLifeSkillType3 => Instance[(short)69];

		/// <summary>
		/// 术数
		/// </summary>
		public static SortItemItem LKLifeSkillType4 => Instance[(short)70];

		/// <summary>
		/// 品鉴
		/// </summary>
		public static SortItemItem LKLifeSkillType5 => Instance[(short)71];

		/// <summary>
		/// 锻造
		/// </summary>
		public static SortItemItem LKLifeSkillType6 => Instance[(short)72];

		/// <summary>
		/// 制木
		/// </summary>
		public static SortItemItem LKLifeSkillType7 => Instance[(short)73];

		/// <summary>
		/// 医术
		/// </summary>
		public static SortItemItem LKLifeSkillType8 => Instance[(short)74];

		/// <summary>
		/// 毒术
		/// </summary>
		public static SortItemItem LKLifeSkillType9 => Instance[(short)75];

		/// <summary>
		/// 织锦
		/// </summary>
		public static SortItemItem LKLifeSkillType10 => Instance[(short)76];

		/// <summary>
		/// 巧匠
		/// </summary>
		public static SortItemItem LKLifeSkillType11 => Instance[(short)77];

		/// <summary>
		/// 道法
		/// </summary>
		public static SortItemItem LKLifeSkillType12 => Instance[(short)78];

		/// <summary>
		/// 佛学
		/// </summary>
		public static SortItemItem LKLifeSkillType13 => Instance[(short)79];

		/// <summary>
		/// 厨艺
		/// </summary>
		public static SortItemItem LKLifeSkillType14 => Instance[(short)80];

		/// <summary>
		/// 杂学
		/// </summary>
		public static SortItemItem LKLifeSkillType15 => Instance[(short)81];

		/// <summary>
		/// 内功
		/// </summary>
		public static SortItemItem LKCombatSkillType0 => Instance[(short)82];

		/// <summary>
		/// 身法
		/// </summary>
		public static SortItemItem LKCombatSkillType1 => Instance[(short)83];

		/// <summary>
		/// 绝技
		/// </summary>
		public static SortItemItem LKCombatSkillType2 => Instance[(short)84];

		/// <summary>
		/// 拳掌
		/// </summary>
		public static SortItemItem LKCombatSkillType3 => Instance[(short)85];

		/// <summary>
		/// 指法
		/// </summary>
		public static SortItemItem LKCombatSkillType4 => Instance[(short)86];

		/// <summary>
		/// 腿法
		/// </summary>
		public static SortItemItem LKCombatSkillType5 => Instance[(short)87];

		/// <summary>
		/// 暗器
		/// </summary>
		public static SortItemItem LKCombatSkillType6 => Instance[(short)88];

		/// <summary>
		/// 剑法
		/// </summary>
		public static SortItemItem LKCombatSkillType7 => Instance[(short)89];

		/// <summary>
		/// 刀法
		/// </summary>
		public static SortItemItem LKCombatSkillType8 => Instance[(short)90];

		/// <summary>
		/// 长兵
		/// </summary>
		public static SortItemItem LKCombatSkillType9 => Instance[(short)91];

		/// <summary>
		/// 奇门
		/// </summary>
		public static SortItemItem LKCombatSkillType10 => Instance[(short)92];

		/// <summary>
		/// 软兵
		/// </summary>
		public static SortItemItem LKCombatSkillType11 => Instance[(short)93];

		/// <summary>
		/// 御射
		/// </summary>
		public static SortItemItem LKCombatSkillType12 => Instance[(short)94];

		/// <summary>
		/// 乐器
		/// </summary>
		public static SortItemItem LKCombatSkillType13 => Instance[(short)95];

		/// <summary>
		/// 冷静
		/// </summary>
		public static SortItemItem Personality0 => Instance[(short)96];

		/// <summary>
		/// 聪颖
		/// </summary>
		public static SortItemItem Personality1 => Instance[(short)97];

		/// <summary>
		/// 热情
		/// </summary>
		public static SortItemItem Personality2 => Instance[(short)98];

		/// <summary>
		/// 勇壮
		/// </summary>
		public static SortItemItem Personality3 => Instance[(short)99];

		/// <summary>
		/// 坚毅
		/// </summary>
		public static SortItemItem Personality4 => Instance[(short)100];

		/// <summary>
		/// 福缘
		/// </summary>
		public static SortItemItem Personality5 => Instance[(short)101];

		/// <summary>
		/// 合道
		/// </summary>
		public static SortItemItem Personality6 => Instance[(short)102];

		/// <summary>
		/// 食材
		/// </summary>
		public static SortItemItem ResourceType0 => Instance[(short)103];

		/// <summary>
		/// 木材
		/// </summary>
		public static SortItemItem ResourceType1 => Instance[(short)104];

		/// <summary>
		/// 金铁
		/// </summary>
		public static SortItemItem ResourceType2 => Instance[(short)105];

		/// <summary>
		/// 玉石
		/// </summary>
		public static SortItemItem ResourceType3 => Instance[(short)106];

		/// <summary>
		/// 织物
		/// </summary>
		public static SortItemItem ResourceType4 => Instance[(short)107];

		/// <summary>
		/// 药材
		/// </summary>
		public static SortItemItem ResourceType5 => Instance[(short)108];

		/// <summary>
		/// 银钱
		/// </summary>
		public static SortItemItem ResourceType6 => Instance[(short)109];

		/// <summary>
		/// 威望
		/// </summary>
		public static SortItemItem ResourceType7 => Instance[(short)110];

		/// <summary>
		/// 关押数量
		/// </summary>
		public static SortItemItem KidnapCount => Instance[(short)111];

		/// <summary>
		/// 进攻
		/// </summary>
		public static SortItemItem AttackMedal => Instance[(short)112];

		/// <summary>
		/// 守御
		/// </summary>
		public static SortItemItem DefenceMedal => Instance[(short)113];

		/// <summary>
		/// 机略
		/// </summary>
		public static SortItemItem WisdomMedal => Instance[(short)114];

		/// <summary>
		/// 同道指令0
		/// </summary>
		public static SortItemItem Command0 => Instance[(short)115];

		/// <summary>
		/// 同道指令1
		/// </summary>
		public static SortItemItem Command1 => Instance[(short)116];

		/// <summary>
		/// 同道指令2
		/// </summary>
		public static SortItemItem Command2 => Instance[(short)117];

		/// <summary>
		/// 技艺成长
		/// </summary>
		public static SortItemItem LifeSkillGrowth => Instance[(short)118];

		/// <summary>
		/// 武学成长
		/// </summary>
		public static SortItemItem CombatSkillGrowth => Instance[(short)119];

		/// <summary>
		/// 抵抗值
		/// </summary>
		public static SortItemItem Resistance => Instance[(short)120];

		/// <summary>
		/// 功法造诣
		/// </summary>
		public static SortItemItem CombatSKillAttainment => Instance[(short)121];

		/// <summary>
		/// 性别
		/// </summary>
		public static SortItemItem Gender => Instance[(short)122];

		/// <summary>
		/// 入魔值
		/// </summary>
		public static SortItemItem Infection => Instance[(short)123];

		/// <summary>
		/// 武学类型
		/// </summary>
		public static SortItemItem CombatSkillType => Instance[(short)124];

		/// <summary>
		/// 所在地点
		/// </summary>
		public static SortItemItem Location => Instance[(short)125];

		/// <summary>
		/// 经营地点
		/// </summary>
		public static SortItemItem WorkingLocation => Instance[(short)126];

		/// <summary>
		/// 经营岗位
		/// </summary>
		public static SortItemItem WorkingRole => Instance[(short)127];

		/// <summary>
		/// 潜力
		/// </summary>
		public static SortItemItem Potential => Instance[(short)128];

		/// <summary>
		/// 工作状态
		/// </summary>
		public static SortItemItem WorkingStatus => Instance[(short)129];

		/// <summary>
		/// 戒心
		/// </summary>
		public static SortItemItem Alertness => Instance[(short)130];

		/// <summary>
		/// 心法进度
		/// </summary>
		public static SortItemItem SpecialBreakBonusProgress => Instance[(short)131];

		/// <summary>
		/// 拿取人数
		/// </summary>
		public static SortItemItem RequireCharacterAmount => Instance[(short)133];

		/// <summary>
		/// 拿取时间
		/// </summary>
		public static SortItemItem TakeAfterMonth => Instance[(short)134];

		/// <summary>
		/// 拿取数量
		/// </summary>
		public static SortItemItem TakeAmount => Instance[(short)135];

		/// <summary>
		/// 关系
		/// </summary>
		public static SortItemItem Relationship => Instance[(short)136];

		/// <summary>
		/// 势力值
		/// </summary>
		public static SortItemItem Contribution => Instance[(short)137];

		/// <summary>
		/// 支持度
		/// </summary>
		public static SortItemItem ApprovingRate => Instance[(short)178];

		/// <summary>
		/// 库房补充几率
		/// </summary>
		public static SortItemItem SupplyRate => Instance[(short)132];

		/// <summary>
		/// 关押原因
		/// </summary>
		public static SortItemItem PunishmentType => Instance[(short)138];

		/// <summary>
		/// 人物身份
		/// </summary>
		public static SortItemItem CharacterIdentity => Instance[(short)139];

		/// <summary>
		/// 武学资质总和
		/// </summary>
		public static SortItemItem CombatSkillQualificationSum => Instance[(short)140];

		/// <summary>
		/// 技艺资质总和
		/// </summary>
		public static SortItemItem LifeSkillQualificationSum => Instance[(short)141];

		/// <summary>
		/// 主属性总和
		/// </summary>
		public static SortItemItem MainAttributeSum => Instance[(short)142];

		/// <summary>
		/// 精纯
		/// </summary>
		public static SortItemItem ConsummateLevel => Instance[(short)143];

		/// <summary>
		/// 内力增长
		/// </summary>
		public static SortItemItem LoopingObtainedNeili => Instance[(short)144];

		/// <summary>
		/// 五行转移
		/// </summary>
		public static SortItemItem LoopingFiveElementTranferAmound => Instance[(short)145];

		/// <summary>
		/// 内力获取
		/// </summary>
		public static SortItemItem LoopingNeili => Instance[(short)146];

		/// <summary>
		/// 真气获取
		/// </summary>
		public static SortItemItem LoopingNeiliAllocation => Instance[(short)147];

		/// <summary>
		/// 天人感应
		/// </summary>
		public static SortItemItem LoopingEvent => Instance[(short)148];

		/// <summary>
		/// 周天策略
		/// </summary>
		public static SortItemItem LoopingStrategy => Instance[(short)149];

		/// <summary>
		/// 七元
		/// </summary>
		public static SortItemItem Personality => Instance[(short)150];

		/// <summary>
		/// 悬赏原身份等级
		/// </summary>
		public static SortItemItem OriginalGrade => Instance[(short)151];

		/// <summary>
		/// 志向名称
		/// </summary>
		public static SortItemItem ProfessionName => Instance[(short)152];

		/// <summary>
		/// 志向资历
		/// </summary>
		public static SortItemItem ProfessionSeniority => Instance[(short)153];

		/// <summary>
		/// 见闻阶级
		/// </summary>
		public static SortItemItem InformationLevel => Instance[(short)154];

		/// <summary>
		/// 使用次数
		/// </summary>
		public static SortItemItem InformationCanUseCount => Instance[(short)155];

		/// <summary>
		/// 出现月份
		/// </summary>
		public static SortItemItem SecretOccurenceDate => Instance[(short)159];

		/// <summary>
		/// 重要程度
		/// </summary>
		public static SortItemItem SecretLevel => Instance[(short)160];

		/// <summary>
		/// 剩余时间
		/// </summary>
		public static SortItemItem SecretLifeTime => Instance[(short)161];

		/// <summary>
		/// 已知人数
		/// </summary>
		public static SortItemItem SecretKnownCount => Instance[(short)162];

		/// <summary>
		/// 可用次数
		/// </summary>
		public static SortItemItem SecretCanUseCount => Instance[(short)163];

		/// <summary>
		/// 传播概率
		/// </summary>
		public static SortItemItem SecretDisseminationRate => Instance[(short)164];

		/// <summary>
		/// 制造所需造诣
		/// </summary>
		public static SortItemItem MakeNeedAttainment => Instance[(short)156];

		/// <summary>
		/// 制造可用工具数量
		/// </summary>
		public static SortItemItem MakeAvailableToolCount => Instance[(short)157];

		/// <summary>
		/// 制造可用引子数量
		/// </summary>
		public static SortItemItem MakeAvailableMaterialCount => Instance[(short)158];

		/// <summary>
		/// 毒素属性
		/// </summary>
		public static SortItemItem PoisonInfo => Instance[(short)165];

		/// <summary>
		/// 书籍信息
		/// </summary>
		public static SortItemItem BookInfo => Instance[(short)166];

		/// <summary>
		/// 精制效果
		/// </summary>
		public static SortItemItem RefineEffect => Instance[(short)167];

		/// <summary>
		/// 精制属性
		/// </summary>
		public static SortItemItem RefineAttribute => Instance[(short)168];

		/// <summary>
		/// 产出概率
		/// </summary>
		public static SortItemItem ProductRate => Instance[(short)169];

		/// <summary>
		/// 模组状态
		/// </summary>
		public static SortItemItem ModStatus => Instance[(short)170];

		/// <summary>
		/// 模组顺序
		/// </summary>
		public static SortItemItem ModOrder => Instance[(short)171];

		/// <summary>
		/// 模组名字
		/// </summary>
		public static SortItemItem ModName => Instance[(short)172];

		/// <summary>
		/// 模组评分
		/// </summary>
		public static SortItemItem ModRate => Instance[(short)173];

		/// <summary>
		/// 模组上传时间
		/// </summary>
		public static SortItemItem ModUploadTime => Instance[(short)174];

		/// <summary>
		/// 模组修改时间
		/// </summary>
		public static SortItemItem ModUpdateTime => Instance[(short)175];

		/// <summary>
		/// 模组大小
		/// </summary>
		public static SortItemItem ModSize => Instance[(short)176];

		/// <summary>
		/// 模组版本
		/// </summary>
		public static SortItemItem ModVersion => Instance[(short)177];

		/// <summary>
		/// 农户自动采集次数
		/// </summary>
		public static SortItemItem FarmerAutoCollectActionCount => Instance[(short)179];

		/// <summary>
		/// 农户迁移心材成功率
		/// </summary>
		public static SortItemItem FarmerMigrateResourceSuccessRate => Instance[(short)180];

		/// <summary>
		/// 农户迁移心材额外成功率
		/// </summary>
		public static SortItemItem FarmerMigrateResourceExtraSuccessRate => Instance[(short)181];

		/// <summary>
		/// 农户元鸡心材升级几率
		/// </summary>
		public static SortItemItem FarmerChickenUpgradeBuildingCoreRate => Instance[(short)182];

		/// <summary>
		/// 大夫可互动人物品级
		/// </summary>
		public static SortItemItem DoctorInteractTargetGrade => Instance[(short)183];

		/// <summary>
		/// 大夫元鸡降低入魔值量
		/// </summary>
		public static SortItemItem DoctorChickenUpgradeInfectionChangeAmount => Instance[(short)184];

		/// <summary>
		/// 商人可互动人物品级
		/// </summary>
		public static SortItemItem MerchantInteractTargetGrade => Instance[(short)185];

		/// <summary>
		/// 商人购买物品价格比例
		/// </summary>
		public static SortItemItem MerchantBuyItemPriceRate => Instance[(short)186];

		/// <summary>
		/// 商人出售物品价格比例
		/// </summary>
		public static SortItemItem MerchantSellItemPriceRate => Instance[(short)187];

		/// <summary>
		/// 商人元鸡增加地区商会总部好感
		/// </summary>
		public static SortItemItem MerchantChickenIncreaseHeadMerchantFavor => Instance[(short)188];

		/// <summary>
		/// 商人元鸡增加地区商会分部好感
		/// </summary>
		public static SortItemItem MerchantChickenIncreaseBranchMerchantFavor => Instance[(short)189];

		/// <summary>
		/// 文人派遣行为可进行的次数
		/// </summary>
		public static SortItemItem LiteratiWorkUsableCount => Instance[(short)190];

		/// <summary>
		/// 文人派遣行为影响的量
		/// </summary>
		public static SortItemItem LiteratiWorkEffectiveValue => Instance[(short)191];

		/// <summary>
		/// 文人元鸡影响的人数
		/// </summary>
		public static SortItemItem LiteratiChickenInfluenceCount => Instance[(short)192];

		/// <summary>
		/// 文人元鸡变化的好感
		/// </summary>
		public static SortItemItem LiteratiChickenRelationChange => Instance[(short)193];

		/// <summary>
		/// 护冢派遣行为收集几率
		/// </summary>
		public static SortItemItem SwordTombKeeperWorkCollectOdd => Instance[(short)194];

		/// <summary>
		/// 护冢派遣行为受伤几率
		/// </summary>
		public static SortItemItem SwordTombKeeperWorkHurtOdd => Instance[(short)195];

		/// <summary>
		/// 护冢派遣行为收集见闻时得到特性几率
		/// </summary>
		public static SortItemItem SwordTombKeeperWorkFeatureOddWhenInformationCollect => Instance[(short)196];

		/// <summary>
		/// 护冢派遣行为被攻击时得到特性几率
		/// </summary>
		public static SortItemItem SwordTombKeeperWorkFeatureOddWhenBeAttacked => Instance[(short)197];

		/// <summary>
		/// 护冢元鸡降低比例
		/// </summary>
		public static SortItemItem SwordTombKeeperChickenDecreaseFactor => Instance[(short)198];

		/// <summary>
		/// 使者派遣行为超常数量
		/// </summary>
		public static SortItemItem VillageHeadWorkSpecialRuleCount => Instance[(short)199];

		/// <summary>
		/// 使者派遣行为每月威望消耗
		/// </summary>
		public static SortItemItem VillageHeadWorkMonthlyAuthorityCost => Instance[(short)200];

		/// <summary>
		/// 玄灰绝命
		/// </summary>
		public static SortItemItem DarkAsh => Instance[(short)201];

		/// <summary>
		/// 鼎蛟淬身
		/// </summary>
		public static SortItemItem TripodVesselProtect => Instance[(short)202];

		/// <summary>
		/// 从属
		/// </summary>
		public static SortItemItem Organization => Instance[(short)203];

		/// <summary>
		/// 剩余份量
		/// </summary>
		public static SortItemItem FoodRemainDurability => Instance[(short)204];

		/// <summary>
		/// 医毒
		/// </summary>
		public static SortItemItem DoctorLifeSkill => Instance[(short)205];

		/// <summary>
		/// 琴棋书画
		/// </summary>
		public static SortItemItem LiteratiLifeSkill => Instance[(short)206];

		/// <summary>
		/// 佛道
		/// </summary>
		public static SortItemItem TombKeeperLifeSkill => Instance[(short)207];

		/// <summary>
		/// 武学
		/// </summary>
		public static SortItemItem HighestCombatSkill => Instance[(short)208];

		/// <summary>
		/// 款式名称
		/// </summary>
		public static SortItemItem WeavedClothingTemplateId => Instance[(short)209];

		/// <summary>
		/// 改制使用次数
		/// </summary>
		public static SortItemItem WeavedCount => Instance[(short)210];

		/// <summary>
		/// 工具造诣
		/// </summary>
		public static SortItemItem ToolAttainment => Instance[(short)211];

		/// <summary>
		/// 商店物品价值
		/// </summary>
		public static SortItemItem ShopItemValue => Instance[(short)212];

		/// <summary>
		/// 商店物品价格
		/// </summary>
		public static SortItemItem ShopItemPrice => Instance[(short)213];

		/// <summary>
		/// 书籍效率
		/// </summary>
		public static SortItemItem BookEfficiency => Instance[(short)214];

		/// <summary>
		/// 书籍灵感
		/// </summary>
		public static SortItemItem BookInspiration => Instance[(short)215];

		/// <summary>
		/// 功法实战
		/// </summary>
		public static SortItemItem CombatSkillProficiency => Instance[(short)216];

		/// <summary>
		/// 毒素数量
		/// </summary>
		public static SortItemItem PoisonsCount => Instance[(short)217];

		/// <summary>
		/// 金刚内力
		/// </summary>
		public static SortItemItem NeiliTypeMetal => Instance[(short)218];

		/// <summary>
		/// 紫霞内力
		/// </summary>
		public static SortItemItem NeiliTypeWood => Instance[(short)219];

		/// <summary>
		/// 玄阴内力
		/// </summary>
		public static SortItemItem NeiliTypeWater => Instance[(short)220];

		/// <summary>
		/// 纯阳内力
		/// </summary>
		public static SortItemItem NeiliTypeFire => Instance[(short)221];

		/// <summary>
		/// 归元内力
		/// </summary>
		public static SortItemItem NeiliTypeEarth => Instance[(short)222];

		/// <summary>
		/// 研读进度
		/// </summary>
		public static SortItemItem BookReadingProgress => Instance[(short)223];

		/// <summary>
		/// 促织灵性
		/// </summary>
		public static SortItemItem CricketPolymorphSpirit => Instance[(short)224];

		/// <summary>
		/// 音律造诣
		/// </summary>
		public static SortItemItem LKLifeSkillAttainmentType0 => Instance[(short)225];

		/// <summary>
		/// 弈棋造诣
		/// </summary>
		public static SortItemItem LKLifeSkillAttainmentType1 => Instance[(short)226];

		/// <summary>
		/// 诗书造诣
		/// </summary>
		public static SortItemItem LKLifeSkillAttainmentType2 => Instance[(short)227];

		/// <summary>
		/// 绘画造诣
		/// </summary>
		public static SortItemItem LKLifeSkillAttainmentType3 => Instance[(short)228];

		/// <summary>
		/// 术数造诣
		/// </summary>
		public static SortItemItem LKLifeSkillAttainmentType4 => Instance[(short)229];

		/// <summary>
		/// 品鉴造诣
		/// </summary>
		public static SortItemItem LKLifeSkillAttainmentType5 => Instance[(short)230];

		/// <summary>
		/// 锻造造诣
		/// </summary>
		public static SortItemItem LKLifeSkillAttainmentType6 => Instance[(short)231];

		/// <summary>
		/// 制木造诣
		/// </summary>
		public static SortItemItem LKLifeSkillAttainmentType7 => Instance[(short)232];

		/// <summary>
		/// 角色医术造诣
		/// </summary>
		public static SortItemItem LKLifeSkillAttainmentType8 => Instance[(short)253];

		/// <summary>
		/// 角色毒术造诣
		/// </summary>
		public static SortItemItem LKLifeSkillAttainmentType9 => Instance[(short)254];

		/// <summary>
		/// 织锦造诣
		/// </summary>
		public static SortItemItem LKLifeSkillAttainmentType10 => Instance[(short)233];

		/// <summary>
		/// 巧匠造诣
		/// </summary>
		public static SortItemItem LKLifeSkillAttainmentType11 => Instance[(short)234];

		/// <summary>
		/// 道法造诣
		/// </summary>
		public static SortItemItem LKLifeSkillAttainmentType12 => Instance[(short)235];

		/// <summary>
		/// 佛学造诣
		/// </summary>
		public static SortItemItem LKLifeSkillAttainmentType13 => Instance[(short)236];

		/// <summary>
		/// 厨艺造诣
		/// </summary>
		public static SortItemItem LKLifeSkillAttainmentType14 => Instance[(short)237];

		/// <summary>
		/// 杂学造诣
		/// </summary>
		public static SortItemItem LKLifeSkillAttainmentType15 => Instance[(short)238];

		/// <summary>
		/// 内功造诣
		/// </summary>
		public static SortItemItem LKCombatSkillAttainmentType0 => Instance[(short)239];

		/// <summary>
		/// 身法造诣
		/// </summary>
		public static SortItemItem LKCombatSkillAttainmentType1 => Instance[(short)240];

		/// <summary>
		/// 绝技造诣
		/// </summary>
		public static SortItemItem LKCombatSkillAttainmentType2 => Instance[(short)241];

		/// <summary>
		/// 拳掌造诣
		/// </summary>
		public static SortItemItem LKCombatSkillAttainmentType3 => Instance[(short)242];

		/// <summary>
		/// 指法造诣
		/// </summary>
		public static SortItemItem LKCombatSkillAttainmentType4 => Instance[(short)243];

		/// <summary>
		/// 腿法造诣
		/// </summary>
		public static SortItemItem LKCombatSkillAttainmentType5 => Instance[(short)244];

		/// <summary>
		/// 暗器造诣
		/// </summary>
		public static SortItemItem LKCombatSkillAttainmentType6 => Instance[(short)245];

		/// <summary>
		/// 剑法造诣
		/// </summary>
		public static SortItemItem LKCombatSkillAttainmentType7 => Instance[(short)246];

		/// <summary>
		/// 刀法造诣
		/// </summary>
		public static SortItemItem LKCombatSkillAttainmentType8 => Instance[(short)247];

		/// <summary>
		/// 长兵造诣
		/// </summary>
		public static SortItemItem LKCombatSkillAttainmentType9 => Instance[(short)248];

		/// <summary>
		/// 奇门造诣
		/// </summary>
		public static SortItemItem LKCombatSkillAttainmentType10 => Instance[(short)249];

		/// <summary>
		/// 软兵造诣
		/// </summary>
		public static SortItemItem LKCombatSkillAttainmentType11 => Instance[(short)250];

		/// <summary>
		/// 御射造诣
		/// </summary>
		public static SortItemItem LKCombatSkillAttainmentType12 => Instance[(short)251];

		/// <summary>
		/// 乐器造诣
		/// </summary>
		public static SortItemItem LKCombatSkillAttainmentType13 => Instance[(short)252];

		/// <summary>
		/// 坟墓耐久
		/// </summary>
		public static SortItemItem GraveDurability => Instance[(short)255];

		/// <summary>
		/// 生于
		/// </summary>
		public static SortItemItem CharacterBirthDate => Instance[(short)256];

		/// <summary>
		/// 卒于
		/// </summary>
		public static SortItemItem CharacterDeathDate => Instance[(short)257];

		/// <summary>
		/// 中蛊数量
		/// </summary>
		public static SortItemItem NormalWugCount => Instance[(short)258];

		/// <summary>
		/// 摧破真气
		/// </summary>
		public static SortItemItem ExtraNeiliAllocationAttack => Instance[(short)259];

		/// <summary>
		/// 轻灵真气
		/// </summary>
		public static SortItemItem ExtraNeiliAllocationAgility => Instance[(short)260];

		/// <summary>
		/// 护体真气
		/// </summary>
		public static SortItemItem ExtraNeiliAllocationDefense => Instance[(short)261];

		/// <summary>
		/// 奇窍真气
		/// </summary>
		public static SortItemItem ExtraNeiliAllocationAssistance => Instance[(short)262];

		/// <summary>
		/// 奇书功法类型
		/// </summary>
		public static SortItemItem LegendaryBookType => Instance[(short)263];

		/// <summary>
		/// 奇书特性
		/// </summary>
		public static SortItemItem LegendaryBookFeature => Instance[(short)264];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static SortItem Instance = new SortItem();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Names", "TemplateId" };

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
		_dataArray.Add(new SortItemItem(0, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_0_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_0_1")
		}));
		_dataArray.Add(new SortItemItem(1, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_1_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_1_1")
		}));
		_dataArray.Add(new SortItemItem(2, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_2_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_2_1")
		}));
		_dataArray.Add(new SortItemItem(3, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_3_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_3_1")
		}));
		_dataArray.Add(new SortItemItem(4, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_4_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_4_1")
		}));
		_dataArray.Add(new SortItemItem(5, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_5_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_5_1")
		}));
		_dataArray.Add(new SortItemItem(6, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_6_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_6_1")
		}));
		_dataArray.Add(new SortItemItem(7, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_7_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_7_1")
		}));
		_dataArray.Add(new SortItemItem(8, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_8_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_8_1")
		}));
		_dataArray.Add(new SortItemItem(9, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_9_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_9_1")
		}));
		_dataArray.Add(new SortItemItem(10, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_10_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_10_1")
		}));
		_dataArray.Add(new SortItemItem(11, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_11_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_11_1")
		}));
		_dataArray.Add(new SortItemItem(12, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_12_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_12_1")
		}));
		_dataArray.Add(new SortItemItem(13, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_13_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_13_1")
		}));
		_dataArray.Add(new SortItemItem(14, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_14_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_14_1")
		}));
		_dataArray.Add(new SortItemItem(15, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_15_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_15_1")
		}));
		_dataArray.Add(new SortItemItem(16, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_16_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_16_1")
		}));
		_dataArray.Add(new SortItemItem(17, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_17_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_17_1")
		}));
		_dataArray.Add(new SortItemItem(18, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_18_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_18_1")
		}));
		_dataArray.Add(new SortItemItem(19, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_19_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_19_1")
		}));
		_dataArray.Add(new SortItemItem(20, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_20_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_20_1")
		}));
		_dataArray.Add(new SortItemItem(21, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_21_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_21_1")
		}));
		_dataArray.Add(new SortItemItem(22, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_22_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_22_1")
		}));
		_dataArray.Add(new SortItemItem(23, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_23_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_23_1")
		}));
		_dataArray.Add(new SortItemItem(24, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_24_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_24_1")
		}));
		_dataArray.Add(new SortItemItem(25, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_25_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_25_1")
		}));
		_dataArray.Add(new SortItemItem(26, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_26_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_26_1")
		}));
		_dataArray.Add(new SortItemItem(27, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_27_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_27_1")
		}));
		_dataArray.Add(new SortItemItem(28, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_28_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_28_1")
		}));
		_dataArray.Add(new SortItemItem(29, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_29_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_29_1")
		}));
		_dataArray.Add(new SortItemItem(30, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_30_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_30_1")
		}));
		_dataArray.Add(new SortItemItem(31, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_31_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_31_1")
		}));
		_dataArray.Add(new SortItemItem(32, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_32_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_32_1")
		}));
		_dataArray.Add(new SortItemItem(33, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_33_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_33_1")
		}));
		_dataArray.Add(new SortItemItem(34, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_34_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_34_1")
		}));
		_dataArray.Add(new SortItemItem(35, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_35_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_35_1")
		}));
		_dataArray.Add(new SortItemItem(36, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_36_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_36_1")
		}));
		_dataArray.Add(new SortItemItem(37, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_37_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_37_1")
		}));
		_dataArray.Add(new SortItemItem(38, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_38_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_38_1")
		}));
		_dataArray.Add(new SortItemItem(39, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_39_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_39_1")
		}));
		_dataArray.Add(new SortItemItem(40, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_40_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_40_1")
		}));
		_dataArray.Add(new SortItemItem(41, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_41_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_41_1")
		}));
		_dataArray.Add(new SortItemItem(42, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_42_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_42_1")
		}));
		_dataArray.Add(new SortItemItem(43, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_43_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_43_1")
		}));
		_dataArray.Add(new SortItemItem(44, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_44_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_44_1")
		}));
		_dataArray.Add(new SortItemItem(45, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_45_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_45_1")
		}));
		_dataArray.Add(new SortItemItem(46, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_46_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_46_1")
		}));
		_dataArray.Add(new SortItemItem(47, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_47_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_47_1")
		}));
		_dataArray.Add(new SortItemItem(48, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_48_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_48_1")
		}));
		_dataArray.Add(new SortItemItem(49, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_49_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_49_1")
		}));
		_dataArray.Add(new SortItemItem(50, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_50_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_50_1")
		}));
		_dataArray.Add(new SortItemItem(51, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_51_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_51_1")
		}));
		_dataArray.Add(new SortItemItem(52, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_52_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_52_1")
		}));
		_dataArray.Add(new SortItemItem(53, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_53_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_53_1")
		}));
		_dataArray.Add(new SortItemItem(54, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_54_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_54_1")
		}));
		_dataArray.Add(new SortItemItem(55, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_55_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_55_1")
		}));
		_dataArray.Add(new SortItemItem(56, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_56_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_56_1")
		}));
		_dataArray.Add(new SortItemItem(57, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_57_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_57_1")
		}));
		_dataArray.Add(new SortItemItem(58, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_58_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_58_1")
		}));
		_dataArray.Add(new SortItemItem(59, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_59_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_59_1")
		}));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new SortItemItem(60, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_60_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_60_1")
		}));
		_dataArray.Add(new SortItemItem(61, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_61_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_61_1")
		}));
		_dataArray.Add(new SortItemItem(62, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_62_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_62_1")
		}));
		_dataArray.Add(new SortItemItem(63, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_63_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_63_1")
		}));
		_dataArray.Add(new SortItemItem(64, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_64_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_64_1")
		}));
		_dataArray.Add(new SortItemItem(65, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_65_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_65_1")
		}));
		_dataArray.Add(new SortItemItem(66, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_66_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_66_1")
		}));
		_dataArray.Add(new SortItemItem(67, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_67_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_67_1")
		}));
		_dataArray.Add(new SortItemItem(68, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_68_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_68_1")
		}));
		_dataArray.Add(new SortItemItem(69, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_69_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_69_1")
		}));
		_dataArray.Add(new SortItemItem(70, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_70_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_70_1")
		}));
		_dataArray.Add(new SortItemItem(71, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_71_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_71_1")
		}));
		_dataArray.Add(new SortItemItem(72, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_72_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_72_1")
		}));
		_dataArray.Add(new SortItemItem(73, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_73_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_73_1")
		}));
		_dataArray.Add(new SortItemItem(74, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_74_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_74_1")
		}));
		_dataArray.Add(new SortItemItem(75, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_75_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_75_1")
		}));
		_dataArray.Add(new SortItemItem(76, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_76_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_76_1")
		}));
		_dataArray.Add(new SortItemItem(77, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_77_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_77_1")
		}));
		_dataArray.Add(new SortItemItem(78, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_78_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_78_1")
		}));
		_dataArray.Add(new SortItemItem(79, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_79_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_79_1")
		}));
		_dataArray.Add(new SortItemItem(80, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_80_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_80_1")
		}));
		_dataArray.Add(new SortItemItem(81, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_81_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_81_1")
		}));
		_dataArray.Add(new SortItemItem(82, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_82_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_82_1")
		}));
		_dataArray.Add(new SortItemItem(83, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_83_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_83_1")
		}));
		_dataArray.Add(new SortItemItem(84, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_84_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_84_1")
		}));
		_dataArray.Add(new SortItemItem(85, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_85_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_85_1")
		}));
		_dataArray.Add(new SortItemItem(86, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_86_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_86_1")
		}));
		_dataArray.Add(new SortItemItem(87, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_87_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_87_1")
		}));
		_dataArray.Add(new SortItemItem(88, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_88_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_88_1")
		}));
		_dataArray.Add(new SortItemItem(89, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_89_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_89_1")
		}));
		_dataArray.Add(new SortItemItem(90, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_90_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_90_1")
		}));
		_dataArray.Add(new SortItemItem(91, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_91_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_91_1")
		}));
		_dataArray.Add(new SortItemItem(92, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_92_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_92_1")
		}));
		_dataArray.Add(new SortItemItem(93, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_93_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_93_1")
		}));
		_dataArray.Add(new SortItemItem(94, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_94_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_94_1")
		}));
		_dataArray.Add(new SortItemItem(95, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_95_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_95_1")
		}));
		_dataArray.Add(new SortItemItem(96, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_96_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_96_1")
		}));
		_dataArray.Add(new SortItemItem(97, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_97_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_97_1")
		}));
		_dataArray.Add(new SortItemItem(98, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_98_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_98_1")
		}));
		_dataArray.Add(new SortItemItem(99, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_99_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_99_1")
		}));
		_dataArray.Add(new SortItemItem(100, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_100_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_100_1")
		}));
		_dataArray.Add(new SortItemItem(101, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_101_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_101_1")
		}));
		_dataArray.Add(new SortItemItem(102, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_102_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_102_1")
		}));
		_dataArray.Add(new SortItemItem(103, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_103_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_103_1")
		}));
		_dataArray.Add(new SortItemItem(104, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_104_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_104_1")
		}));
		_dataArray.Add(new SortItemItem(105, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_105_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_105_1")
		}));
		_dataArray.Add(new SortItemItem(106, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_106_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_106_1")
		}));
		_dataArray.Add(new SortItemItem(107, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_107_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_107_1")
		}));
		_dataArray.Add(new SortItemItem(108, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_108_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_108_1")
		}));
		_dataArray.Add(new SortItemItem(109, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_109_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_109_1")
		}));
		_dataArray.Add(new SortItemItem(110, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_110_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_110_1")
		}));
		_dataArray.Add(new SortItemItem(111, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_111_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_111_1")
		}));
		_dataArray.Add(new SortItemItem(112, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_112_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_112_1")
		}));
		_dataArray.Add(new SortItemItem(113, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_113_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_113_1")
		}));
		_dataArray.Add(new SortItemItem(114, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_114_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_114_1")
		}));
		_dataArray.Add(new SortItemItem(115, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_115_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_115_1")
		}));
		_dataArray.Add(new SortItemItem(116, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_116_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_116_1")
		}));
		_dataArray.Add(new SortItemItem(117, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_117_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_117_1")
		}));
		_dataArray.Add(new SortItemItem(118, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_118_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_118_1")
		}));
		_dataArray.Add(new SortItemItem(119, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_119_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_119_1")
		}));
	}

	private void CreateItems2()
	{
		_dataArray.Add(new SortItemItem(120, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_120_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_120_1")
		}));
		_dataArray.Add(new SortItemItem(121, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_121_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_121_1")
		}));
		_dataArray.Add(new SortItemItem(122, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_122_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_122_1")
		}));
		_dataArray.Add(new SortItemItem(123, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_123_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_123_1")
		}));
		_dataArray.Add(new SortItemItem(124, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_124_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_124_1")
		}));
		_dataArray.Add(new SortItemItem(125, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_125_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_125_1")
		}));
		_dataArray.Add(new SortItemItem(126, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_126_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_126_1")
		}));
		_dataArray.Add(new SortItemItem(127, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_127_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_127_1")
		}));
		_dataArray.Add(new SortItemItem(128, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_128_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_128_1")
		}));
		_dataArray.Add(new SortItemItem(129, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_129_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_129_1")
		}));
		_dataArray.Add(new SortItemItem(130, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_130_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_130_1")
		}));
		_dataArray.Add(new SortItemItem(131, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_131_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_131_1")
		}));
		_dataArray.Add(new SortItemItem(132, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_132_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_132_1")
		}));
		_dataArray.Add(new SortItemItem(133, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_133_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_133_1")
		}));
		_dataArray.Add(new SortItemItem(134, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_134_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_134_1")
		}));
		_dataArray.Add(new SortItemItem(135, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_135_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_135_1")
		}));
		_dataArray.Add(new SortItemItem(136, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_136_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_136_1")
		}));
		_dataArray.Add(new SortItemItem(137, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_137_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_137_1")
		}));
		_dataArray.Add(new SortItemItem(138, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_138_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_138_1")
		}));
		_dataArray.Add(new SortItemItem(139, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_139_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_139_1")
		}));
		_dataArray.Add(new SortItemItem(140, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_140_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_140_1")
		}));
		_dataArray.Add(new SortItemItem(141, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_141_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_141_1")
		}));
		_dataArray.Add(new SortItemItem(142, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_142_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_142_1")
		}));
		_dataArray.Add(new SortItemItem(143, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_143_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_143_1")
		}));
		_dataArray.Add(new SortItemItem(144, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_144_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_144_1")
		}));
		_dataArray.Add(new SortItemItem(145, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_145_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_145_1")
		}));
		_dataArray.Add(new SortItemItem(146, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_146_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_146_1")
		}));
		_dataArray.Add(new SortItemItem(147, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_147_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_147_1")
		}));
		_dataArray.Add(new SortItemItem(148, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_148_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_148_1")
		}));
		_dataArray.Add(new SortItemItem(149, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_149_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_149_1")
		}));
		_dataArray.Add(new SortItemItem(150, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_150_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_150_1")
		}));
		_dataArray.Add(new SortItemItem(151, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_151_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_151_1")
		}));
		_dataArray.Add(new SortItemItem(152, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_152_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_152_1")
		}));
		_dataArray.Add(new SortItemItem(153, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_153_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_153_1")
		}));
		_dataArray.Add(new SortItemItem(154, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_154_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_154_1")
		}));
		_dataArray.Add(new SortItemItem(155, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_155_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_155_1")
		}));
		_dataArray.Add(new SortItemItem(156, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_156_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_156_1")
		}));
		_dataArray.Add(new SortItemItem(157, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_157_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_157_1")
		}));
		_dataArray.Add(new SortItemItem(158, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_158_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_158_1")
		}));
		_dataArray.Add(new SortItemItem(159, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_159_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_159_1")
		}));
		_dataArray.Add(new SortItemItem(160, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_160_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_160_1")
		}));
		_dataArray.Add(new SortItemItem(161, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_161_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_161_1")
		}));
		_dataArray.Add(new SortItemItem(162, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_162_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_162_1")
		}));
		_dataArray.Add(new SortItemItem(163, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_163_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_163_1")
		}));
		_dataArray.Add(new SortItemItem(164, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_164_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_164_1")
		}));
		_dataArray.Add(new SortItemItem(165, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_165_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_165_1")
		}));
		_dataArray.Add(new SortItemItem(166, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_166_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_166_1")
		}));
		_dataArray.Add(new SortItemItem(167, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_167_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_167_1")
		}));
		_dataArray.Add(new SortItemItem(168, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_168_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_168_1")
		}));
		_dataArray.Add(new SortItemItem(169, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_169_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_169_1")
		}));
		_dataArray.Add(new SortItemItem(170, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_170_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_170_1")
		}));
		_dataArray.Add(new SortItemItem(171, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_171_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_171_1")
		}));
		_dataArray.Add(new SortItemItem(172, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_172_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_172_1")
		}));
		_dataArray.Add(new SortItemItem(173, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_173_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_173_1")
		}));
		_dataArray.Add(new SortItemItem(174, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_174_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_174_1")
		}));
		_dataArray.Add(new SortItemItem(175, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_175_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_175_1")
		}));
		_dataArray.Add(new SortItemItem(176, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_176_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_176_1")
		}));
		_dataArray.Add(new SortItemItem(177, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_177_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_177_1")
		}));
		_dataArray.Add(new SortItemItem(178, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_178_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_178_1")
		}));
		_dataArray.Add(new SortItemItem(179, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_179_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_179_1")
		}));
	}

	private void CreateItems3()
	{
		_dataArray.Add(new SortItemItem(180, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_180_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_180_1")
		}));
		_dataArray.Add(new SortItemItem(181, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_181_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_181_1")
		}));
		_dataArray.Add(new SortItemItem(182, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_182_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_182_1")
		}));
		_dataArray.Add(new SortItemItem(183, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_183_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_183_1")
		}));
		_dataArray.Add(new SortItemItem(184, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_184_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_184_1")
		}));
		_dataArray.Add(new SortItemItem(185, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_185_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_185_1")
		}));
		_dataArray.Add(new SortItemItem(186, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_186_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_186_1")
		}));
		_dataArray.Add(new SortItemItem(187, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_187_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_187_1")
		}));
		_dataArray.Add(new SortItemItem(188, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_188_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_188_1")
		}));
		_dataArray.Add(new SortItemItem(189, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_189_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_189_1")
		}));
		_dataArray.Add(new SortItemItem(190, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_190_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_190_1")
		}));
		_dataArray.Add(new SortItemItem(191, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_191_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_191_1")
		}));
		_dataArray.Add(new SortItemItem(192, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_192_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_192_1")
		}));
		_dataArray.Add(new SortItemItem(193, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_193_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_193_1")
		}));
		_dataArray.Add(new SortItemItem(194, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_194_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_194_1")
		}));
		_dataArray.Add(new SortItemItem(195, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_195_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_195_1")
		}));
		_dataArray.Add(new SortItemItem(196, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_196_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_196_1")
		}));
		_dataArray.Add(new SortItemItem(197, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_197_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_197_1")
		}));
		_dataArray.Add(new SortItemItem(198, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_198_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_198_1")
		}));
		_dataArray.Add(new SortItemItem(199, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_199_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_199_1")
		}));
		_dataArray.Add(new SortItemItem(200, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_200_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_200_1")
		}));
		_dataArray.Add(new SortItemItem(201, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_201_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_201_1")
		}));
		_dataArray.Add(new SortItemItem(202, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_202_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_202_1")
		}));
		_dataArray.Add(new SortItemItem(203, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_203_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_203_1")
		}));
		_dataArray.Add(new SortItemItem(204, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_204_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_204_1")
		}));
		_dataArray.Add(new SortItemItem(205, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_205_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_205_1")
		}));
		_dataArray.Add(new SortItemItem(206, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_206_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_206_1")
		}));
		_dataArray.Add(new SortItemItem(207, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_207_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_207_1")
		}));
		_dataArray.Add(new SortItemItem(208, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_208_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_208_1")
		}));
		_dataArray.Add(new SortItemItem(209, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_209_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_209_1")
		}));
		_dataArray.Add(new SortItemItem(210, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_210_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_210_1")
		}));
		_dataArray.Add(new SortItemItem(211, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_211_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_211_1")
		}));
		_dataArray.Add(new SortItemItem(212, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_212_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_212_1")
		}));
		_dataArray.Add(new SortItemItem(213, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_213_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_213_1")
		}));
		_dataArray.Add(new SortItemItem(214, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_214_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_214_1")
		}));
		_dataArray.Add(new SortItemItem(215, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_215_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_215_1")
		}));
		_dataArray.Add(new SortItemItem(216, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_216_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_216_1")
		}));
		_dataArray.Add(new SortItemItem(217, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_217_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_217_1")
		}));
		_dataArray.Add(new SortItemItem(218, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_218_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_218_1")
		}));
		_dataArray.Add(new SortItemItem(219, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_219_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_219_1")
		}));
		_dataArray.Add(new SortItemItem(220, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_220_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_220_1")
		}));
		_dataArray.Add(new SortItemItem(221, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_221_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_221_1")
		}));
		_dataArray.Add(new SortItemItem(222, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_222_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_222_1")
		}));
		_dataArray.Add(new SortItemItem(223, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_223_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_223_1")
		}));
		_dataArray.Add(new SortItemItem(224, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_224_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_224_1")
		}));
		_dataArray.Add(new SortItemItem(225, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_225_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_225_1")
		}));
		_dataArray.Add(new SortItemItem(226, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_226_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_226_1")
		}));
		_dataArray.Add(new SortItemItem(227, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_227_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_227_1")
		}));
		_dataArray.Add(new SortItemItem(228, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_228_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_228_1")
		}));
		_dataArray.Add(new SortItemItem(229, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_229_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_229_1")
		}));
		_dataArray.Add(new SortItemItem(230, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_230_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_230_1")
		}));
		_dataArray.Add(new SortItemItem(231, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_231_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_231_1")
		}));
		_dataArray.Add(new SortItemItem(232, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_232_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_232_1")
		}));
		_dataArray.Add(new SortItemItem(233, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_233_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_233_1")
		}));
		_dataArray.Add(new SortItemItem(234, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_234_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_234_1")
		}));
		_dataArray.Add(new SortItemItem(235, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_235_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_235_1")
		}));
		_dataArray.Add(new SortItemItem(236, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_236_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_236_1")
		}));
		_dataArray.Add(new SortItemItem(237, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_237_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_237_1")
		}));
		_dataArray.Add(new SortItemItem(238, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_238_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_238_1")
		}));
		_dataArray.Add(new SortItemItem(239, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_239_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_239_1")
		}));
	}

	private void CreateItems4()
	{
		_dataArray.Add(new SortItemItem(240, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_240_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_240_1")
		}));
		_dataArray.Add(new SortItemItem(241, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_241_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_241_1")
		}));
		_dataArray.Add(new SortItemItem(242, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_242_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_242_1")
		}));
		_dataArray.Add(new SortItemItem(243, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_243_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_243_1")
		}));
		_dataArray.Add(new SortItemItem(244, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_244_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_244_1")
		}));
		_dataArray.Add(new SortItemItem(245, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_245_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_245_1")
		}));
		_dataArray.Add(new SortItemItem(246, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_246_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_246_1")
		}));
		_dataArray.Add(new SortItemItem(247, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_247_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_247_1")
		}));
		_dataArray.Add(new SortItemItem(248, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_248_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_248_1")
		}));
		_dataArray.Add(new SortItemItem(249, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_249_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_249_1")
		}));
		_dataArray.Add(new SortItemItem(250, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_250_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_250_1")
		}));
		_dataArray.Add(new SortItemItem(251, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_251_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_251_1")
		}));
		_dataArray.Add(new SortItemItem(252, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_252_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_252_1")
		}));
		_dataArray.Add(new SortItemItem(253, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_253_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_253_1")
		}));
		_dataArray.Add(new SortItemItem(254, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_254_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_254_1")
		}));
		_dataArray.Add(new SortItemItem(255, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_255_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_255_1")
		}));
		_dataArray.Add(new SortItemItem(256, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_256_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_256_1")
		}));
		_dataArray.Add(new SortItemItem(257, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_257_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_257_1")
		}));
		_dataArray.Add(new SortItemItem(258, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_258_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_258_1")
		}));
		_dataArray.Add(new SortItemItem(259, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_259_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_259_1")
		}));
		_dataArray.Add(new SortItemItem(260, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_260_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_260_1")
		}));
		_dataArray.Add(new SortItemItem(261, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_261_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_261_1")
		}));
		_dataArray.Add(new SortItemItem(262, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_262_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_262_1")
		}));
		_dataArray.Add(new SortItemItem(263, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_263_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_263_1")
		}));
		_dataArray.Add(new SortItemItem(264, new string[2]
		{
			LocalStringManager.GetConfig("SortItem_language", "Names_264_0"),
			LocalStringManager.GetConfig("SortItem_language", "Names_264_1")
		}));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<SortItemItem>(265);
		CreateItems0();
		CreateItems1();
		CreateItems2();
		CreateItems3();
		CreateItems4();
	}
}
