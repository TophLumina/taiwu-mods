using System;
using System.Collections.Generic;
using Config.Common;
using Config.ConfigCells.Character;
using GameData.Domains.Character;
using GameData.Utilities;

namespace Config;

[Serializable]
public class OrganizationMemberItem : ConfigItem<OrganizationMemberItem, short>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 级别名
	/// </summary>
	public readonly string GradeName;

	/// <summary>
	/// 关联组织
	/// </summary>
	public readonly sbyte Organization;

	/// <summary>
	/// 阶级
	/// </summary>
	public readonly sbyte Grade;

	/// <summary>
	/// 可晋升级别
	/// - 该身份的人物当没有符合亲属继承规则的继承人时，会从哪些级别的同团体人物中选择继承者，参数为{}空时，默认不断从下一级别中选择继承者，有多个参数时，参数在{}中的排列也代表了优先级，如果{}不为空，且参数中对应级别的人物也都不存在，则直接生成新的人物继承
	/// </summary>
	public readonly sbyte[] PotentialSuccessorGrades;

	/// <summary>
	/// 核心人数
	/// - 该阶级的核心人数. 核心角色周围会创建数量不等的附属角色.
	/// </summary>
	public readonly sbyte Amount;

	/// <summary>
	/// 昌盛人数
	/// - 地区主线结局影响身份人数
	/// </summary>
	public readonly sbyte UpAmount;

	/// <summary>
	/// 衰落人数
	/// - 地区主线结局影响身份人数
	/// </summary>
	public readonly sbyte DownAmount;

	/// <summary>
	/// 限制正职人数
	/// - 对该阶级的正职人数的硬性限制
	/// </summary>
	public readonly bool RestrictPrincipalAmount;

	/// <summary>
	/// 性别
	/// - 0: 女, 1: 男, -1: 未知/不限制.
	/// </summary>
	public readonly sbyte Gender;

	/// <summary>
	/// 姓氏
	/// - 对应表 NameCore_CN.SurName
	/// </summary>
	public readonly short SurnameId;

	/// <summary>
	/// 副职配偶降级
	/// - 若大于等于 0, 表示配偶是副职. 副职配偶的级别会随着自身级别的变动而变动. 其数值表示自身死亡或离开团体后, 配偶会被降到什么级别.
	/// </summary>
	public readonly sbyte DeputySpouseDowngrade;

	/// <summary>
	/// 子女级别
	/// - 同时表示门派允许自身结婚
	/// </summary>
	public readonly sbyte ChildGrade;

	/// <summary>
	/// 兄弟级别
	/// - 兄弟以及恋人的级别
	/// </summary>
	public readonly sbyte BrotherGrade;

	/// <summary>
	/// 师父级别
	/// </summary>
	public readonly sbyte TeacherGrade;

	/// <summary>
	/// 再加入级别
	/// - 变成无门无派后再加入时对应的级别, -1 表示保留原级别
	/// </summary>
	public readonly sbyte RejoinGrade;

	/// <summary>
	/// 出家几率
	/// - 加入门派时的出家几率
	/// </summary>
	public readonly sbyte ProbOfBecomingMonk;

	/// <summary>
	/// 出家类型
	/// - 该团体成员出家后的固定出家类型, 见角色表同名字段. 0: 无固定出家类型, 1: 非门派道人, 2: 非门派和尚, 129: 门派道人, 130: 门派和尚.
	/// </summary>
	public readonly byte MonkType;

	/// <summary>
	/// 法号尾号
	/// - 0: 女性, 1: 男性.
	/// </summary>
	public readonly string[] MonasticTitleSuffixes;

	/// <summary>
	/// 内力
	/// </summary>
	public readonly short Neili;

	/// <summary>
	/// 精纯
	/// </summary>
	public readonly sbyte ConsummateLevel;

	/// <summary>
	/// 配额历练
	/// - 每个月人物可用于修习和突破的一定数量的虚拟历练；配额历练在每个月没有用完时，不会剩余到下个月
	/// </summary>
	public readonly short ExpPerMonth;

	/// <summary>
	/// 配额贡献值
	/// - 每个月固定配额的贡献值
	/// </summary>
	public readonly int ContributionPerMonth;

	/// <summary>
	/// 拜师几率修正
	/// </summary>
	public readonly sbyte ApprenticeProbAdjust;

	/// <summary>
	/// 喜爱衣着
	/// - 对方穿着列表中的衣着时, 自己对对方的好感会增加. 参考 Clothing 表.
	/// </summary>
	public readonly List<short> FavoriteClothingIds;

	/// <summary>
	/// 厌恶衣着
	/// - 对方穿着列表中的衣着时, 自己对对方的好感会减少. 参考 Clothing 表.
	/// </summary>
	public readonly List<short> HatedClothingIds;

	/// <summary>
	/// 配偶称号
	/// - 0: 女性, 1: 男性.
	/// </summary>
	public readonly string[] SpouseAnonymousTitles;

	/// <summary>
	/// 闲逛
	/// - 人物是否会离开主要地点四处走动
	/// </summary>
	public readonly bool CanStroll;

	/// <summary>
	/// 手下
	/// - 关联 MinionGroup 表
	/// </summary>
	public readonly short MinionGroupId;

	/// <summary>
	/// 初始年龄
	/// - 此字段自动生成, 实际配置字段为从 "早夭" 到 "极长" 的 4 个字段.
	/// </summary>
	public readonly short[] InitialAges;

	/// <summary>
	/// 装备
	/// - 此字段自动生成, 实际配置字段为从 "头盔" 到 "代步" 的 8 个字段.
	/// </summary>
	public readonly PresetEquipmentItemWithProb[] Equipment;

	/// <summary>
	/// 衣着
	/// - 此字段自动生成, 实际配置字段为前一列 "衣着".
	/// </summary>
	public readonly PresetEquipmentItem Clothing;

	/// <summary>
	/// 行囊
	/// - 单个物品格式: {类型, 模板 ID, 数量}. 类型为字串形式, 参考物品子表表名. 模板 ID 参考各物品子表. 行囊中的物品有概率生成, 而且物品品级会根据人物阶级调整.
	/// </summary>
	public readonly List<PresetInventoryItem> Inventory;

	/// <summary>
	/// 功法
	/// - 单个功法格式: {功法组 ID, 已习得的最高品阶}. 功法组 ID 即为该组功法的最低阶的功法 ID. 功法 ID 参考 CombatSkill 表.
	/// </summary>
	public readonly List<PresetOrgMemberCombatSkill> CombatSkills;

	/// <summary>
	/// 额外功法栏位
	/// </summary>
	public readonly sbyte[] ExtraCombatSkillGrids;

	/// <summary>
	/// 资源修正
	/// - 此字段自动生成, 实际配置字段为从 "食" 到 "威" 的 8 个字段.
	/// </summary>
	public readonly short[] ResourcesAdjust;

	/// <summary>
	/// 资源满足阈值
	/// - 资源上限，达到这个量的一半时，ai会认为自己拥有很多资源，所填的值为银钱，并与资源，威望做比例换算，受资源修正的影响
	/// </summary>
	public readonly int ResourceSatisfyingThreshold;

	/// <summary>
	/// 道具满足阈值
	/// - ai持有的所有道具的价值，如果超过这个阈值，ai会认为自己拥有了过多的道具
	/// </summary>
	public readonly int ItemSatisfyingThreshold;

	/// <summary>
	/// 资源获取比例
	/// - 暂用于修正产业资源地格给予的资源量，后续与AI有相应关联
	/// </summary>
	public readonly int ResourceIncomeRatio;

	/// <summary>
	/// 购买道具折扣
	/// - NPC过月时，购买道具、制造道具需要花费的钱银和资源比例
	/// </summary>
	public readonly int PurchaseItemDiscount;

	/// <summary>
	/// 期望赌注值
	/// - 主动押注时的期望赌注值, 和银钱有一定换算关系.
	/// </summary>
	public readonly int ExpectedWagerValue;

	/// <summary>
	/// 技艺修正
	/// - 对技艺资质的修正, 但不是直接加减. 当修正值越大, 资质增加的几率越大. 此字段自动生成, 实际配置字段为从 "音律" 到 "杂学 的 16 个字段.
	/// </summary>
	public readonly short[] LifeSkillsAdjust;

	/// <summary>
	/// 技艺学习上限
	/// - 从组织中学习技艺的品级上限
	/// </summary>
	public readonly sbyte LifeSkillGradeLimit;

	/// <summary>
	/// 武学修正
	/// - 对武学资质的修正, 但不是直接加减. 当修正值越大, 资质增加的几率越大. 此字段自动生成, 实际配置字段为从 "内功" 到 "乐器" 的 14 个字段.
	/// </summary>
	public readonly short[] CombatSkillsAdjust;

	/// <summary>
	/// 主要属性修正
	/// - 不是对主要属性值的直接加减. 当修正值越大, 属性值增加的几率越大. 此字段自动生成, 实际配置字段为从 "膂力" 到 "悟性" 的 6 个字段.
	/// </summary>
	public readonly short[] MainAttributesAdjust;

	/// <summary>
	/// 特殊身份互动能力配置，查阅后端脚本SpecialEventOptionType获取具体互动值
	/// - 角色具备的特殊互动类型组合，如果没有达到配置的身份互动年龄，这些互动将不显示
	/// </summary>
	public readonly List<sbyte> IdentityInteractConfig;

	/// <summary>
	/// 身份互动出现年龄
	/// - 决定特殊互动能力是否进入判定的CurrAge配置。由于此列数值均小于20，而PhysiologicalAge在小于20时与CurrAge一致，因此前端应当使用PhysiologicalAge进行判定
	/// </summary>
	public readonly short IdentityActiveAge;

	/// <summary>
	/// 掉落资源
	/// - 此字段自动生成, 实际配置字段为从 "食材" 到 "威望" 的 8 个字段，用于影响人物在战斗、较艺、促织决斗后掉落的额外的资源和威望。
	/// </summary>
	public readonly ResourceInts DropResources;

	/// <summary>
	/// 人物倾向志向
	/// - 对应身份人物在初次成年或者身份转变时可以获得的志向内容，配置方式为{志向，获得概率}
	/// </summary>
	public readonly IntPair[] PreferProfessions;

	/// <summary>
	/// 匠人互动类型
	/// </summary>
	public readonly sbyte[] CraftTypes;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="gradeName">级别名</param>
	/// <param name="organization">关联组织</param>
	/// <param name="grade">阶级</param>
	/// <param name="potentialSuccessorGrades">可晋升级别 - 该身份的人物当没有符合亲属继承规则的继承人时，会从哪些级别的同团体人物中选择继承者，参数为{}空时，默认不断从下一级别中选择继承者，有多个参数时，参数在{}中的排列也代表了优先级，如果{}不为空，且参数中对应级别的人物也都不存在，则直接生成新的人物继承</param>
	/// <param name="amount">核心人数 - 该阶级的核心人数. 核心角色周围会创建数量不等的附属角色.</param>
	/// <param name="upAmount">昌盛人数 - 地区主线结局影响身份人数</param>
	/// <param name="downAmount">衰落人数 - 地区主线结局影响身份人数</param>
	/// <param name="restrictPrincipalAmount">限制正职人数 - 对该阶级的正职人数的硬性限制</param>
	/// <param name="gender">性别 - 0: 女, 1: 男, -1: 未知/不限制.</param>
	/// <param name="surnameId">姓氏 - 对应表 NameCore_CN.SurName</param>
	/// <param name="deputySpouseDowngrade">副职配偶降级 - 若大于等于 0, 表示配偶是副职. 副职配偶的级别会随着自身级别的变动而变动. 其数值表示自身死亡或离开团体后, 配偶会被降到什么级别.</param>
	/// <param name="childGrade">子女级别 - 同时表示门派允许自身结婚</param>
	/// <param name="brotherGrade">兄弟级别 - 兄弟以及恋人的级别</param>
	/// <param name="teacherGrade">师父级别</param>
	/// <param name="rejoinGrade">再加入级别 - 变成无门无派后再加入时对应的级别, -1 表示保留原级别</param>
	/// <param name="probOfBecomingMonk">出家几率 - 加入门派时的出家几率</param>
	/// <param name="monkType">出家类型 - 该团体成员出家后的固定出家类型, 见角色表同名字段. 0: 无固定出家类型, 1: 非门派道人, 2: 非门派和尚, 129: 门派道人, 130: 门派和尚.</param>
	/// <param name="monasticTitleSuffixes">法号尾号 - 0: 女性, 1: 男性.</param>
	/// <param name="neili">内力</param>
	/// <param name="consummateLevel">精纯</param>
	/// <param name="expPerMonth">配额历练 - 每个月人物可用于修习和突破的一定数量的虚拟历练；配额历练在每个月没有用完时，不会剩余到下个月</param>
	/// <param name="contributionPerMonth">配额贡献值 - 每个月固定配额的贡献值</param>
	/// <param name="apprenticeProbAdjust">拜师几率修正</param>
	/// <param name="favoriteClothingIds">喜爱衣着 - 对方穿着列表中的衣着时, 自己对对方的好感会增加. 参考 Clothing 表.</param>
	/// <param name="hatedClothingIds">厌恶衣着 - 对方穿着列表中的衣着时, 自己对对方的好感会减少. 参考 Clothing 表.</param>
	/// <param name="spouseAnonymousTitles">配偶称号 - 0: 女性, 1: 男性.</param>
	/// <param name="canStroll">闲逛 - 人物是否会离开主要地点四处走动</param>
	/// <param name="minionGroupId">手下 - 关联 MinionGroup 表</param>
	/// <param name="initialAges">初始年龄 - 此字段自动生成, 实际配置字段为从 "早夭" 到 "极长" 的 4 个字段.</param>
	/// <param name="equipment">装备 - 此字段自动生成, 实际配置字段为从 "头盔" 到 "代步" 的 8 个字段.</param>
	/// <param name="clothing">衣着 - 此字段自动生成, 实际配置字段为前一列 "衣着".</param>
	/// <param name="inventory">行囊 - 单个物品格式: {类型, 模板 ID, 数量}. 类型为字串形式, 参考物品子表表名. 模板 ID 参考各物品子表. 行囊中的物品有概率生成, 而且物品品级会根据人物阶级调整.</param>
	/// <param name="combatSkills">功法 - 单个功法格式: {功法组 ID, 已习得的最高品阶}. 功法组 ID 即为该组功法的最低阶的功法 ID. 功法 ID 参考 CombatSkill 表.</param>
	/// <param name="extraCombatSkillGrids">额外功法栏位</param>
	/// <param name="resourcesAdjust">资源修正 - 此字段自动生成, 实际配置字段为从 "食" 到 "威" 的 8 个字段.</param>
	/// <param name="resourceSatisfyingThreshold">资源满足阈值 - 资源上限，达到这个量的一半时，ai会认为自己拥有很多资源，所填的值为银钱，并与资源，威望做比例换算，受资源修正的影响</param>
	/// <param name="itemSatisfyingThreshold">道具满足阈值 - ai持有的所有道具的价值，如果超过这个阈值，ai会认为自己拥有了过多的道具</param>
	/// <param name="resourceIncomeRatio">资源获取比例 - 暂用于修正产业资源地格给予的资源量，后续与AI有相应关联</param>
	/// <param name="purchaseItemDiscount">购买道具折扣 - NPC过月时，购买道具、制造道具需要花费的钱银和资源比例</param>
	/// <param name="expectedWagerValue">期望赌注值 - 主动押注时的期望赌注值, 和银钱有一定换算关系.</param>
	/// <param name="lifeSkillsAdjust">技艺修正 - 对技艺资质的修正, 但不是直接加减. 当修正值越大, 资质增加的几率越大. 此字段自动生成, 实际配置字段为从 "音律" 到 "杂学 的 16 个字段.</param>
	/// <param name="lifeSkillGradeLimit">技艺学习上限 - 从组织中学习技艺的品级上限</param>
	/// <param name="combatSkillsAdjust">武学修正 - 对武学资质的修正, 但不是直接加减. 当修正值越大, 资质增加的几率越大. 此字段自动生成, 实际配置字段为从 "内功" 到 "乐器" 的 14 个字段.</param>
	/// <param name="mainAttributesAdjust">主要属性修正 - 不是对主要属性值的直接加减. 当修正值越大, 属性值增加的几率越大. 此字段自动生成, 实际配置字段为从 "膂力" 到 "悟性" 的 6 个字段.</param>
	/// <param name="identityInteractConfig">特殊身份互动能力配置，查阅后端脚本SpecialEventOptionType获取具体互动值 - 角色具备的特殊互动类型组合，如果没有达到配置的身份互动年龄，这些互动将不显示</param>
	/// <param name="identityActiveAge">身份互动出现年龄 - 决定特殊互动能力是否进入判定的CurrAge配置。由于此列数值均小于20，而PhysiologicalAge在小于20时与CurrAge一致，因此前端应当使用PhysiologicalAge进行判定</param>
	/// <param name="dropResources">掉落资源 - 此字段自动生成, 实际配置字段为从 "食材" 到 "威望" 的 8 个字段，用于影响人物在战斗、较艺、促织决斗后掉落的额外的资源和威望。</param>
	/// <param name="preferProfessions">人物倾向志向 - 对应身份人物在初次成年或者身份转变时可以获得的志向内容，配置方式为{志向，获得概率}</param>
	/// <param name="craftTypes">匠人互动类型</param>
	public OrganizationMemberItem(short templateId, string gradeName, sbyte organization, sbyte grade, sbyte[] potentialSuccessorGrades, sbyte amount, sbyte upAmount, sbyte downAmount, bool restrictPrincipalAmount, sbyte gender, short surnameId, sbyte deputySpouseDowngrade, sbyte childGrade, sbyte brotherGrade, sbyte teacherGrade, sbyte rejoinGrade, sbyte probOfBecomingMonk, byte monkType, string[] monasticTitleSuffixes, short neili, sbyte consummateLevel, short expPerMonth, int contributionPerMonth, sbyte apprenticeProbAdjust, List<short> favoriteClothingIds, List<short> hatedClothingIds, string[] spouseAnonymousTitles, bool canStroll, short minionGroupId, short[] initialAges, PresetEquipmentItemWithProb[] equipment, PresetEquipmentItem clothing, List<PresetInventoryItem> inventory, List<PresetOrgMemberCombatSkill> combatSkills, sbyte[] extraCombatSkillGrids, short[] resourcesAdjust, int resourceSatisfyingThreshold, int itemSatisfyingThreshold, int resourceIncomeRatio, int purchaseItemDiscount, int expectedWagerValue, short[] lifeSkillsAdjust, sbyte lifeSkillGradeLimit, short[] combatSkillsAdjust, short[] mainAttributesAdjust, List<sbyte> identityInteractConfig, short identityActiveAge, ResourceInts dropResources, IntPair[] preferProfessions, sbyte[] craftTypes)
	{
		TemplateId = templateId;
		GradeName = gradeName;
		Organization = organization;
		Grade = grade;
		PotentialSuccessorGrades = potentialSuccessorGrades;
		Amount = amount;
		UpAmount = upAmount;
		DownAmount = downAmount;
		RestrictPrincipalAmount = restrictPrincipalAmount;
		Gender = gender;
		SurnameId = surnameId;
		DeputySpouseDowngrade = deputySpouseDowngrade;
		ChildGrade = childGrade;
		BrotherGrade = brotherGrade;
		TeacherGrade = teacherGrade;
		RejoinGrade = rejoinGrade;
		ProbOfBecomingMonk = probOfBecomingMonk;
		MonkType = monkType;
		MonasticTitleSuffixes = monasticTitleSuffixes;
		Neili = neili;
		ConsummateLevel = consummateLevel;
		ExpPerMonth = expPerMonth;
		ContributionPerMonth = contributionPerMonth;
		ApprenticeProbAdjust = apprenticeProbAdjust;
		FavoriteClothingIds = favoriteClothingIds;
		HatedClothingIds = hatedClothingIds;
		SpouseAnonymousTitles = spouseAnonymousTitles;
		CanStroll = canStroll;
		MinionGroupId = minionGroupId;
		InitialAges = initialAges;
		Equipment = equipment;
		Clothing = clothing;
		Inventory = inventory;
		CombatSkills = combatSkills;
		ExtraCombatSkillGrids = extraCombatSkillGrids;
		ResourcesAdjust = resourcesAdjust;
		ResourceSatisfyingThreshold = resourceSatisfyingThreshold;
		ItemSatisfyingThreshold = itemSatisfyingThreshold;
		ResourceIncomeRatio = resourceIncomeRatio;
		PurchaseItemDiscount = purchaseItemDiscount;
		ExpectedWagerValue = expectedWagerValue;
		LifeSkillsAdjust = lifeSkillsAdjust;
		LifeSkillGradeLimit = lifeSkillGradeLimit;
		CombatSkillsAdjust = combatSkillsAdjust;
		MainAttributesAdjust = mainAttributesAdjust;
		IdentityInteractConfig = identityInteractConfig;
		IdentityActiveAge = identityActiveAge;
		DropResources = dropResources;
		PreferProfessions = preferProfessions;
		CraftTypes = craftTypes;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public OrganizationMemberItem()
	{
		TemplateId = 0;
		GradeName = null;
		Organization = 0;
		Grade = 0;
		PotentialSuccessorGrades = new sbyte[0];
		Amount = 0;
		UpAmount = 0;
		DownAmount = 0;
		RestrictPrincipalAmount = false;
		Gender = -1;
		SurnameId = -1;
		DeputySpouseDowngrade = -1;
		ChildGrade = -1;
		BrotherGrade = -1;
		TeacherGrade = -1;
		RejoinGrade = -1;
		ProbOfBecomingMonk = 0;
		MonkType = 0;
		MonasticTitleSuffixes = new string[2]
		{
			string.Empty,
			string.Empty
		};
		Neili = 0;
		ConsummateLevel = 0;
		ExpPerMonth = 0;
		ContributionPerMonth = 0;
		ApprenticeProbAdjust = 0;
		FavoriteClothingIds = new List<short>();
		HatedClothingIds = new List<short>();
		SpouseAnonymousTitles = new string[2]
		{
			string.Empty,
			string.Empty
		};
		CanStroll = false;
		MinionGroupId = 0;
		InitialAges = new short[4] { -1, -1, -1, -1 };
		Equipment = new PresetEquipmentItemWithProb[13]
		{
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Armor", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Carrier", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0),
			new PresetEquipmentItemWithProb("Accessory", -1, 0)
		};
		Clothing = new PresetEquipmentItem("Clothing", -1);
		Inventory = new List<PresetInventoryItem>();
		CombatSkills = new List<PresetOrgMemberCombatSkill>();
		ExtraCombatSkillGrids = new sbyte[5];
		ResourcesAdjust = null;
		ResourceSatisfyingThreshold = 0;
		ItemSatisfyingThreshold = 0;
		ResourceIncomeRatio = 0;
		PurchaseItemDiscount = 100;
		ExpectedWagerValue = 0;
		LifeSkillsAdjust = null;
		LifeSkillGradeLimit = 0;
		CombatSkillsAdjust = null;
		MainAttributesAdjust = null;
		IdentityInteractConfig = new List<sbyte>();
		IdentityActiveAge = 3;
		DropResources = new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int));
		PreferProfessions = new IntPair[0];
		CraftTypes = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public OrganizationMemberItem(short templateId, OrganizationMemberItem other)
	{
		TemplateId = templateId;
		GradeName = other.GradeName;
		Organization = other.Organization;
		Grade = other.Grade;
		PotentialSuccessorGrades = other.PotentialSuccessorGrades;
		Amount = other.Amount;
		UpAmount = other.UpAmount;
		DownAmount = other.DownAmount;
		RestrictPrincipalAmount = other.RestrictPrincipalAmount;
		Gender = other.Gender;
		SurnameId = other.SurnameId;
		DeputySpouseDowngrade = other.DeputySpouseDowngrade;
		ChildGrade = other.ChildGrade;
		BrotherGrade = other.BrotherGrade;
		TeacherGrade = other.TeacherGrade;
		RejoinGrade = other.RejoinGrade;
		ProbOfBecomingMonk = other.ProbOfBecomingMonk;
		MonkType = other.MonkType;
		MonasticTitleSuffixes = other.MonasticTitleSuffixes;
		Neili = other.Neili;
		ConsummateLevel = other.ConsummateLevel;
		ExpPerMonth = other.ExpPerMonth;
		ContributionPerMonth = other.ContributionPerMonth;
		ApprenticeProbAdjust = other.ApprenticeProbAdjust;
		FavoriteClothingIds = other.FavoriteClothingIds;
		HatedClothingIds = other.HatedClothingIds;
		SpouseAnonymousTitles = other.SpouseAnonymousTitles;
		CanStroll = other.CanStroll;
		MinionGroupId = other.MinionGroupId;
		InitialAges = other.InitialAges;
		Equipment = other.Equipment;
		Clothing = other.Clothing;
		Inventory = other.Inventory;
		CombatSkills = other.CombatSkills;
		ExtraCombatSkillGrids = other.ExtraCombatSkillGrids;
		ResourcesAdjust = other.ResourcesAdjust;
		ResourceSatisfyingThreshold = other.ResourceSatisfyingThreshold;
		ItemSatisfyingThreshold = other.ItemSatisfyingThreshold;
		ResourceIncomeRatio = other.ResourceIncomeRatio;
		PurchaseItemDiscount = other.PurchaseItemDiscount;
		ExpectedWagerValue = other.ExpectedWagerValue;
		LifeSkillsAdjust = other.LifeSkillsAdjust;
		LifeSkillGradeLimit = other.LifeSkillGradeLimit;
		CombatSkillsAdjust = other.CombatSkillsAdjust;
		MainAttributesAdjust = other.MainAttributesAdjust;
		IdentityInteractConfig = other.IdentityInteractConfig;
		IdentityActiveAge = other.IdentityActiveAge;
		DropResources = other.DropResources;
		PreferProfessions = other.PreferProfessions;
		CraftTypes = other.CraftTypes;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override OrganizationMemberItem Duplicate(int templateId)
	{
		return new OrganizationMemberItem((short)templateId, this);
	}
}
