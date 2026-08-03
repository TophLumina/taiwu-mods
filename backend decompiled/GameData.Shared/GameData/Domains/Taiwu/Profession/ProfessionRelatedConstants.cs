using System;
using System.Collections.Generic;
using GameData.Combat.Math;
using Redzen.Random;

namespace GameData.Domains.Taiwu.Profession;

/// <summary>
/// 职业(志向) 相关常量
/// </summary>
public static class ProfessionRelatedConstants
{
	/// <summary>
	/// 定居点类型
	/// </summary>
	public static class SettlementType
	{
		/// <summary>
		/// 非定居点
		/// </summary>
		public const sbyte Invalid = -1;

		/// <summary>
		/// 村庄
		/// </summary>
		public const sbyte Village = 0;

		/// <summary>
		/// 山寨
		/// </summary>
		public const sbyte WalledTown = 1;

		/// <summary>
		/// 市镇
		/// </summary>
		public const sbyte Town = 2;

		/// <summary>
		/// 门派、主城
		/// </summary>
		public const sbyte SectCity = 3;
	}

	/// <summary>
	/// 资历最大值
	/// </summary>
	public const int MaxSeniority = 3000000;

	/// <summary>
	/// 额外资历最大值
	/// </summary>
	public const int MaxExtraSeniority = 1500000;

	/// <summary>
	/// 最大资历门槛需求的造诣阈值
	/// </summary>
	public static readonly int[] MaxSeniorityAttainmentThresholds = new int[4] { 0, 100, 220, 380 };

	/// <summary>
	/// 资历最小值
	/// </summary>
	public const int MinSeniority = 0;

	/// <summary>
	/// 每月增加资历
	/// </summary>
	public const int SeniorityGainPerMonth = 20;

	/// <summary>
	/// 职业技能解锁所需资历
	/// </summary>
	[Obsolete("现在需要看具体的职业技能配置")]
	public static readonly int[] SkillUnlockSeniority = new int[4] { 150000, 600000, 1500000, 3000000 };

	/// <summary>
	/// 兼容志向切换冷却
	/// </summary>
	[Obsolete]
	public const int CompatibleProfessionCooldown = 3;

	/// <summary>
	/// 通常志向切换冷却
	/// </summary>
	[Obsolete]
	public const int ProfessionCooldown = 6;

	/// <summary>
	/// 互斥志向切换冷却
	/// </summary>
	[Obsolete]
	public const int ConflictingProfessionCooldown = 12;

	/// <summary>
	/// 山人休养生息的范围
	/// </summary>
	public const int SavageSaveResourceRange = 1;

	/// <summary>
	/// 山人 - 因地制宜 - 获得加成值的范围
	/// </summary>
	public const int SavageAddEffectRange = 1;

	/// <summary>
	/// 富商一技能，购买时的基础价格因子
	/// </summary>
	public const int CapitalistTradePriceFactor = 500;

	/// <summary>
	/// 富商加商会好感的因子
	/// </summary>
	public const int CapitalistAddMerchantFavorFactor = 3;

	/// <summary>
	/// 匠人4技能精制效果增加的百分数
	/// </summary>
	public const int CraftRefineEffectFactor = 150;

	/// <summary>
	/// 旅人 - 世外仙府 - 最大仙府数
	/// </summary>
	public const int TravelerPalaceMaxCount = 3;

	/// <summary>
	/// 旅人 - 世外仙府 - 传送消耗精力值
	/// </summary>
	public const int TravelerPalaceTeleportCostActionPoint = 10;

	/// <summary>
	/// 旅人 - 世外仙府 - 中毒类型数
	/// </summary>
	public const int TravelerPalaceMakePoisonCount = 3;

	/// <summary>
	/// 云游僧 - 功德无量 寺庙数量对应可学功法、技艺品级
	/// </summary>
	public static readonly sbyte[] TempleCountToSkillGrade = new sbyte[16]
	{
		-1, 0, 0, 1, 1, 2, 2, 3, 3, 4,
		4, 5, 5, 6, 7, 8
	};

	/// <summary>
	/// 道士 - 天劫符箓 击杀入魔人后获得天劫符箓数量与被击杀入魔人精纯等级的关系
	/// </summary>
	public static readonly sbyte[] TaoistMonkSkill2GetSecretSignCount = new sbyte[19]
	{
		1, 1, 1, 1, 2, 2, 3, 3, 4, 4,
		5, 6, 7, 8, 10, 12, 14, 16, 19
	};

	/// <summary>
	/// 道士 - 天劫符箓 解救入魔人后获得天劫符箓数量与被击杀入魔人精纯等级的关系
	/// 目前这个数值与FuyuFaithCountBySaveInfected相等
	/// </summary>
	public static readonly sbyte[] TaoistMonkSkill2GetSecretSignCountBySave = GlobalConfig.FuyuFaithCountBySaveInfected;

	/// <summary>
	/// 王公三技能  立场得分
	/// </summary>
	public static readonly int[] BehaviorTypeScore = new int[5] { 1, 2, 0, -2, -1 };

	/// <summary>
	/// 云游道-易天改命-每个正面特性对应的好感增加
	/// </summary>
	public static readonly int TravelingTaoistMonkSkill2FavorValue = 3000;

	/// <summary>
	/// 王公 解甲归田 各立场结仇概率
	/// </summary>
	public static readonly int[] BehaviorTypeBecomeEnemyProb = new int[5] { 5, 0, 10, 20, 15 };

	/// <summary>
	/// 天劫所需符箓数量
	/// </summary>
	public const sbyte RequiredTianJieFuLuAmount = 99;

	/// <summary>
	/// 天劫数量
	/// </summary>
	public const sbyte TribulationCount = 4;

	/// <summary>
	/// 天劫每月获得符箓数量
	/// </summary>
	public const sbyte TribulationFuLuCount = 3;

	/// <summary>
	/// 义诊的好感变化
	/// </summary>
	public const int TreatOthersFavorabilityChange = 6000;

	/// <summary>
	/// 僧道破戒 - 酒肉 惩罚资历
	/// </summary>
	public const int MonkEatForbiddenFoodPunishment = 300000;

	/// <summary>
	/// 僧道破解 - 春宵 惩罚资历
	/// </summary>
	public const int MonkHaveSexPunishment = 900000;

	/// <summary>
	/// 造诣资历因数， 加成百分值 = 基础值+(造诣/因数)
	/// </summary>
	public const int BonusSeniorityAttainmentFactor = 3;

	/// <summary>
	/// 造诣资历基础值， 加成百分值 = 基础值+(造诣/因数)
	/// </summary>
	public const int BonusSeniorityAttainmentBase = 100;

	/// <summary>
	/// 托钵行乞最大比例
	/// </summary>
	public static readonly CValuePercent BeggarMoneyMaxPercent = 33;

	/// <summary>
	/// 托钵行乞立场倍率
	/// </summary>
	public static readonly short[] BeggarMoneyBehaviorTypeFactors = new short[5] { 100, 200, 150, 50, 25 };

	/// <summary>
	/// 芜行俚语人物立场对应的离开概率
	/// </summary>
	public static readonly short[] BeggarSkill2BehaviorTypeFactors = new short[5] { 35, 80, 65, 20, 50 };

	/// <summary>
	/// 武师技能需要的安定
	/// </summary>
	public const int MartialArtistRequiredSafety = 25;

	/// <summary>
	///
	/// </summary>
	public const sbyte RemoveEnemyRelationHappinessChange = 20;

	/// <summary>
	/// 村民通过武院和书院习得门派角色功法技艺的间隔
	/// </summary>
	public const sbyte VillagerLearnSectSkillInterval = 3;

	/// <summary>
	/// 高僧-了悟轮回 需要超度的人数
	/// </summary>
	public const sbyte BuddhistMonkSkill3NeedSaveSoulCount = 100;

	/// <summary>
	/// 猎户召集野兽范围
	/// </summary>
	public const int HunterGetAnimalRange = 2;

	/// <summary>
	/// 乞丐 天地为食加成数值
	/// </summary>
	public const int BeggarUltimateBuffPercent = 50;

	/// <summary>
	/// 平民 薪火相传加成数值
	/// </summary>
	public const int CivilianUltimateBuffPercent = 50;

	/// <summary>
	/// 名门资质等级范围
	/// </summary>
	public static sbyte[] AristocratGradeRange = new sbyte[2] { 3, 5 };

	/// <summary>
	/// 大夫三技能合成药品，所消耗的药品数量
	/// </summary>
	public const int DoctorMakeMedicineCostMedicineAmount = 3;

	/// <summary>
	/// 大夫三技能合成药品，所产出的药品数量
	/// </summary>
	public const int DoctorMakeMedicineProduceMedicineAmount = 1;

	/// <summary>
	/// 武师-保镖护院-外道模板id
	/// </summary>
	public static short[] MartialArtistHereticTemplateIds = new short[9] { 310, 330, 335, 340, 345, 350, 355, 360, 365 };

	/// <summary>
	/// 主属性得到某志向恢复作用的映射表
	/// </summary>
	public static readonly IReadOnlyList<int> MainAttributeRecoverProfessionIds = new int[6] { 0, 14, 6, 11, 5, 12 };

	/// <summary>
	/// 王公三技能的促织福缘加成
	/// </summary>
	public const int DukeSkill3AdditionalCricketLuckPoint = 300;

	/// <summary>
	/// 王公三技能的促织点寿命
	/// </summary>
	public const int DukeSkill3CricketPlaceLifeTime = 3;

	/// <summary>
	/// 旅人 - 世外仙府 - 随机受伤数
	/// </summary>
	public static int TravelerPalaceRandomInjuryCount(IRandomSource random)
	{
		return random.Next(3, 10);
	}

	/// <summary>
	/// 旅人 - 世外仙府 - 随机中毒量
	/// </summary>
	public static int TravelerRandomPoisonValue(IRandomSource random)
	{
		return random.Next(500, 1501);
	}

	/// <summary>
	/// 旅人 - 世外仙府 - 随机内息紊乱值
	/// </summary>
	public static int TravelerRandomQiDisorderValue(IRandomSource random)
	{
		return random.Next(1000, 3001);
	}

	/// <summary>
	/// 旅人 - 世外仙府 - 随机健康损耗值
	/// </summary>
	public static int TravelerRandomHealthValue(IRandomSource random)
	{
		return random.Next(6, 19);
	}
}
