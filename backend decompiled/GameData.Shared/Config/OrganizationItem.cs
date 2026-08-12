using System;
using System.Collections.Generic;
using Config.Common;
using Config.ConfigCells;
using Config.ConfigCells.Character;
using GameData.Utilities;

namespace Config;

[Serializable]
public class OrganizationItem : ConfigItem<OrganizationItem, sbyte>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly sbyte TemplateId;

	/// <summary>
	/// 名称
	/// </summary>
	public readonly string Name;

	/// <summary>
	/// 描述
	/// </summary>
	public readonly string Desc;

	/// <summary>
	/// 太吾村石碑描述
	/// </summary>
	public readonly string TaiwuVillageSteleDesc;

	/// <summary>
	/// 图标
	/// </summary>
	public readonly string Icon;

	/// <summary>
	/// mousetip图标
	/// </summary>
	public readonly string MousetipIcon;

	/// <summary>
	/// 文化值
	/// - 负数表示在配置值和配置值的一半之间随机.
	/// </summary>
	public readonly short Culture;

	/// <summary>
	/// 安定值
	/// - 负数表示在配置值和配置值的一半之间随机.
	/// </summary>
	public readonly short Safety;

	/// <summary>
	/// 人口
	/// </summary>
	public readonly int Population;

	/// <summary>
	/// 人物模板
	/// - 团体的角色模板 ID 列表, 格式为 {女性角色模板 ID, 男性角色模板 ID}. 关联到 Character 表. 若此处未指定模板, 则使用角色所在州的角色模板.
	/// </summary>
	public readonly short[] CharTemplateIds;

	/// <summary>
	/// 门派弟子模板Id
	/// - 门派弟子模板id，精纯从低到高
	/// </summary>
	public readonly short[] RandomEnemyTemplateIds;

	/// <summary>
	/// 定居点类型
	/// - 组织对应的定居点类型.
	/// </summary>
	public readonly EOrganizationSettlementType SettlementType;

	/// <summary>
	/// 是否门派
	/// </summary>
	public readonly bool IsSect;

	/// <summary>
	/// 是否平民
	/// </summary>
	public readonly bool IsCivilian;

	/// <summary>
	/// 字辈组
	/// - 在字辈表中的字辈组 ID, 关联到表 NameCore_CN.MonasticTitle.
	/// </summary>
	public readonly sbyte SeniorityGroupId;

	/// <summary>
	/// 善恶
	/// - 1: 善良, 0: 中立, -1: 邪恶.
	/// </summary>
	public readonly sbyte Goodness;

	/// <summary>
	/// 主立场
	/// - short.MinValue 表示无主立场
	/// </summary>
	public readonly short MainMorality;

	/// <summary>
	/// 性别限制
	/// - 0: 女, 1: 男, -1: 未知/不限制.
	/// </summary>
	public readonly sbyte GenderRestriction;

	/// <summary>
	/// 传功给外人的几率
	/// </summary>
	public readonly sbyte TeachingOutsiderProb;

	/// <summary>
	/// 是否世袭
	/// </summary>
	public readonly bool Hereditary;

	/// <summary>
	/// 可用毒
	/// </summary>
	public readonly bool AllowPoisoning;

	/// <summary>
	/// 禁止荤食
	/// </summary>
	public readonly bool NoMeatEating;

	/// <summary>
	/// 禁酒
	/// </summary>
	public readonly bool NoDrinking;

	/// <summary>
	/// 商会倾向
	/// - 志向成为此门派的人的商会倾向. 0: 服牛帮, 1: 文山书海阁, 2: 五湖商会, 3: 大武魁商号, 4: 回春堂, 5: 公输坊, 6: 奇货斋.
	/// </summary>
	public readonly sbyte MerchantTendency;

	/// <summary>
	/// 商人级别
	/// - 此定居点的商人的货物初始级别
	/// </summary>
	public readonly sbyte MerchantLevel;

	/// <summary>
	/// 奇书倾向
	/// - 参考 CombatSkillType 表, 和功法类型一一对应.
	/// </summary>
	public readonly sbyte LegendaryBookTendency;

	/// <summary>
	/// 弃婴地点
	/// - 不符合门派性别限制的孩子送到哪些团体. 填写本表模板 ID.
	/// </summary>
	public readonly List<sbyte> AbandonedBabyOrganizations;

	/// <summary>
	/// 惩罚特性
	/// - 远走高飞惩罚的特性
	/// </summary>
	public readonly short PunishmentFeature;

	/// <summary>
	/// 太吾被监牢惩罚的特性
	/// </summary>
	public readonly List<short> TaiwuPunishementFeature;

	/// <summary>
	/// 太吾可以请教的技艺类型
	/// </summary>
	public readonly List<sbyte> LearnLifeSkillTypes;

	/// <summary>
	/// 功法类型
	/// - 团体拥有的功法类型. 参考 CombatSkillType 表.
	/// </summary>
	public readonly List<sbyte> CombatSkillTypes;

	/// <summary>
	/// 功法五行
	/// - 团体功法的主五行. 0~4: 金木水火土，5: 混元, -1: 无主五行.
	/// </summary>
	public readonly sbyte FiveElementsType;

	/// <summary>
	/// 势力值更新周期
	/// - 定居点内所有成员的势力值更新的间隔, 单位月.
	/// </summary>
	public readonly short InfluencePowerUpdateInterval;

	/// <summary>
	/// 大门派间好感
	/// - 此字段自动生成, 实际配置字段为从 "少林" 到 "血犼" 的 15 个字段.
	/// </summary>
	public readonly sbyte[] LargeSectFavorabilities;

	/// <summary>
	/// 成员结构
	/// - 按阶级从低到高排列的成员模板 ID. 参考 OrganizationMember 表.
	/// </summary>
	public readonly short[] Members;

	/// <summary>
	/// 转职身份
	/// - 从门派转到村镇后的品级
	/// </summary>
	public readonly sbyte RetireGrade;

	/// <summary>
	/// 修行特性
	/// - 在组织中超过固定年限后添加的特性
	/// </summary>
	public readonly short MemberFeature;

	/// <summary>
	/// 门派额外信息
	/// </summary>
	public readonly string OrganizationExtraDesc;

	/// <summary>
	/// 监牢建筑
	/// </summary>
	public readonly short PrisonBuilding;

	/// <summary>
	/// 武师奖励
	/// - 武师技能：仗义行侠生效时，获取的物品类型：根据Weapon→GroupId和计算出来的物品品阶筛选物品，最后在筛选出来的物品中随机获得一个
	/// </summary>
	public readonly short[] MartialArtistItemBonus;

	/// <summary>
	/// 重申信誓特殊提示
	/// - 完成界青地主实装后联系程序删除
	/// </summary>
	public readonly string VowSpecialHint;

	/// <summary>
	/// 太吾被悬赏事件文本
	/// </summary>
	public readonly short TaiwuBeHunted;

	/// <summary>
	/// 人物玄机需求
	/// - 从属于这个势力的人物产生玄机需求时的待选择物品，结构为{玄机类型,权重}。要产生玄机需求时，按配置的权重进行抽取，具体品级根据人物身份品阶，详见《功法突破系统》
	/// </summary>
	public readonly ShortPair[] SkillBreakBonusWeights;

	/// <summary>
	/// 较艺AI贿赂玩家的物品类型权重
	/// </summary>
	public readonly List<LifeSkillCombatBriberyItemTypeWeight> LifeSkillCombatBriberyItemTypeWeight;

	/// <summary>
	/// 较艺AI贿赂玩家的物品子类型权重
	/// </summary>
	public readonly List<LifeSkillCombatBriberyItemSubTypeWeight> LifeSkillCombatBriberyItemSubTypeWeight;

	/// <summary>
	/// 重申信誓固定奖励道具
	/// </summary>
	public readonly List<PresetInventoryItem> VowFixedRewardItems;

	/// <summary>
	/// 重申信誓随机奖励道具
	/// </summary>
	public readonly List<PresetInventoryItem> VowRandomRewardItems;

	/// <summary>
	/// 重申信誓随机奖励道具数量
	/// </summary>
	public readonly int VowRandomRewardItemsCount;

	/// <summary>
	/// 人口阈值
	/// - 3420
	/// </summary>
	public readonly int PopulationThreshold;

	public SectMainStoryItem SectMainStory
	{
		get
		{
			if (!IsSect)
			{
				return null;
			}
			return Config.SectMainStory.Instance[TemplateId - 1];
		}
	}

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="name">名称</param>
	/// <param name="desc">描述</param>
	/// <param name="taiwuVillageSteleDesc">太吾村石碑描述</param>
	/// <param name="icon">图标</param>
	/// <param name="mousetipIcon">mousetip图标</param>
	/// <param name="culture">文化值 - 负数表示在配置值和配置值的一半之间随机.</param>
	/// <param name="safety">安定值 - 负数表示在配置值和配置值的一半之间随机.</param>
	/// <param name="population">人口</param>
	/// <param name="charTemplateIds">人物模板 - 团体的角色模板 ID 列表, 格式为 {女性角色模板 ID, 男性角色模板 ID}. 关联到 Character 表. 若此处未指定模板, 则使用角色所在州的角色模板.</param>
	/// <param name="randomEnemyTemplateIds">门派弟子模板Id - 门派弟子模板id，精纯从低到高</param>
	/// <param name="settlementType">定居点类型 - 组织对应的定居点类型.</param>
	/// <param name="isSect">是否门派</param>
	/// <param name="isCivilian">是否平民</param>
	/// <param name="seniorityGroupId">字辈组 - 在字辈表中的字辈组 ID, 关联到表 NameCore_CN.MonasticTitle.</param>
	/// <param name="goodness">善恶 - 1: 善良, 0: 中立, -1: 邪恶.</param>
	/// <param name="mainMorality">主立场 - short.MinValue 表示无主立场</param>
	/// <param name="genderRestriction">性别限制 - 0: 女, 1: 男, -1: 未知/不限制.</param>
	/// <param name="teachingOutsiderProb">传功给外人的几率</param>
	/// <param name="hereditary">是否世袭</param>
	/// <param name="allowPoisoning">可用毒</param>
	/// <param name="noMeatEating">禁止荤食</param>
	/// <param name="noDrinking">禁酒</param>
	/// <param name="merchantTendency">商会倾向 - 志向成为此门派的人的商会倾向. 0: 服牛帮, 1: 文山书海阁, 2: 五湖商会, 3: 大武魁商号, 4: 回春堂, 5: 公输坊, 6: 奇货斋.</param>
	/// <param name="merchantLevel">商人级别 - 此定居点的商人的货物初始级别</param>
	/// <param name="legendaryBookTendency">奇书倾向 - 参考 CombatSkillType 表, 和功法类型一一对应.</param>
	/// <param name="abandonedBabyOrganizations">弃婴地点 - 不符合门派性别限制的孩子送到哪些团体. 填写本表模板 ID.</param>
	/// <param name="punishmentFeature">惩罚特性 - 远走高飞惩罚的特性</param>
	/// <param name="taiwuPunishementFeature">太吾被监牢惩罚的特性</param>
	/// <param name="learnLifeSkillTypes">太吾可以请教的技艺类型</param>
	/// <param name="combatSkillTypes">功法类型 - 团体拥有的功法类型. 参考 CombatSkillType 表.</param>
	/// <param name="fiveElementsType">功法五行 - 团体功法的主五行. 0~4: 金木水火土，5: 混元, -1: 无主五行.</param>
	/// <param name="influencePowerUpdateInterval">势力值更新周期 - 定居点内所有成员的势力值更新的间隔, 单位月.</param>
	/// <param name="largeSectFavorabilities">大门派间好感 - 此字段自动生成, 实际配置字段为从 "少林" 到 "血犼" 的 15 个字段.</param>
	/// <param name="members">成员结构 - 按阶级从低到高排列的成员模板 ID. 参考 OrganizationMember 表.</param>
	/// <param name="retireGrade">转职身份 - 从门派转到村镇后的品级</param>
	/// <param name="memberFeature">修行特性 - 在组织中超过固定年限后添加的特性</param>
	/// <param name="organizationExtraDesc">门派额外信息</param>
	/// <param name="prisonBuilding">监牢建筑</param>
	/// <param name="martialArtistItemBonus">武师奖励 - 武师技能：仗义行侠生效时，获取的物品类型：根据Weapon→GroupId和计算出来的物品品阶筛选物品，最后在筛选出来的物品中随机获得一个</param>
	/// <param name="vowSpecialHint">重申信誓特殊提示 - 完成界青地主实装后联系程序删除</param>
	/// <param name="taiwuBeHunted">太吾被悬赏事件文本</param>
	/// <param name="skillBreakBonusWeights">人物玄机需求 - 从属于这个势力的人物产生玄机需求时的待选择物品，结构为{玄机类型,权重}。要产生玄机需求时，按配置的权重进行抽取，具体品级根据人物身份品阶，详见《功法突破系统》</param>
	/// <param name="lifeSkillCombatBriberyItemTypeWeight">较艺AI贿赂玩家的物品类型权重</param>
	/// <param name="lifeSkillCombatBriberyItemSubTypeWeight">较艺AI贿赂玩家的物品子类型权重</param>
	/// <param name="vowFixedRewardItems">重申信誓固定奖励道具</param>
	/// <param name="vowRandomRewardItems">重申信誓随机奖励道具</param>
	/// <param name="vowRandomRewardItemsCount">重申信誓随机奖励道具数量</param>
	/// <param name="populationThreshold">人口阈值 - 3420</param>
	public OrganizationItem(sbyte templateId, string name, string desc, string taiwuVillageSteleDesc, string icon, string mousetipIcon, short culture, short safety, int population, short[] charTemplateIds, short[] randomEnemyTemplateIds, EOrganizationSettlementType settlementType, bool isSect, bool isCivilian, sbyte seniorityGroupId, sbyte goodness, short mainMorality, sbyte genderRestriction, sbyte teachingOutsiderProb, bool hereditary, bool allowPoisoning, bool noMeatEating, bool noDrinking, sbyte merchantTendency, sbyte merchantLevel, sbyte legendaryBookTendency, List<sbyte> abandonedBabyOrganizations, short punishmentFeature, List<short> taiwuPunishementFeature, List<sbyte> learnLifeSkillTypes, List<sbyte> combatSkillTypes, sbyte fiveElementsType, short influencePowerUpdateInterval, sbyte[] largeSectFavorabilities, short[] members, sbyte retireGrade, short memberFeature, string organizationExtraDesc, short prisonBuilding, short[] martialArtistItemBonus, string vowSpecialHint, short taiwuBeHunted, ShortPair[] skillBreakBonusWeights, List<LifeSkillCombatBriberyItemTypeWeight> lifeSkillCombatBriberyItemTypeWeight, List<LifeSkillCombatBriberyItemSubTypeWeight> lifeSkillCombatBriberyItemSubTypeWeight, List<PresetInventoryItem> vowFixedRewardItems, List<PresetInventoryItem> vowRandomRewardItems, int vowRandomRewardItemsCount, int populationThreshold)
	{
		TemplateId = templateId;
		Name = name;
		Desc = desc;
		TaiwuVillageSteleDesc = taiwuVillageSteleDesc;
		Icon = icon;
		MousetipIcon = mousetipIcon;
		Culture = culture;
		Safety = safety;
		Population = population;
		CharTemplateIds = charTemplateIds;
		RandomEnemyTemplateIds = randomEnemyTemplateIds;
		SettlementType = settlementType;
		IsSect = isSect;
		IsCivilian = isCivilian;
		SeniorityGroupId = seniorityGroupId;
		Goodness = goodness;
		MainMorality = mainMorality;
		GenderRestriction = genderRestriction;
		TeachingOutsiderProb = teachingOutsiderProb;
		Hereditary = hereditary;
		AllowPoisoning = allowPoisoning;
		NoMeatEating = noMeatEating;
		NoDrinking = noDrinking;
		MerchantTendency = merchantTendency;
		MerchantLevel = merchantLevel;
		LegendaryBookTendency = legendaryBookTendency;
		AbandonedBabyOrganizations = abandonedBabyOrganizations;
		PunishmentFeature = punishmentFeature;
		TaiwuPunishementFeature = taiwuPunishementFeature;
		LearnLifeSkillTypes = learnLifeSkillTypes;
		CombatSkillTypes = combatSkillTypes;
		FiveElementsType = fiveElementsType;
		InfluencePowerUpdateInterval = influencePowerUpdateInterval;
		LargeSectFavorabilities = largeSectFavorabilities;
		Members = members;
		RetireGrade = retireGrade;
		MemberFeature = memberFeature;
		OrganizationExtraDesc = organizationExtraDesc;
		PrisonBuilding = prisonBuilding;
		MartialArtistItemBonus = martialArtistItemBonus;
		VowSpecialHint = vowSpecialHint;
		TaiwuBeHunted = taiwuBeHunted;
		SkillBreakBonusWeights = skillBreakBonusWeights;
		LifeSkillCombatBriberyItemTypeWeight = lifeSkillCombatBriberyItemTypeWeight;
		LifeSkillCombatBriberyItemSubTypeWeight = lifeSkillCombatBriberyItemSubTypeWeight;
		VowFixedRewardItems = vowFixedRewardItems;
		VowRandomRewardItems = vowRandomRewardItems;
		VowRandomRewardItemsCount = vowRandomRewardItemsCount;
		PopulationThreshold = populationThreshold;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public OrganizationItem()
	{
		TemplateId = 0;
		Name = null;
		Desc = null;
		TaiwuVillageSteleDesc = null;
		Icon = null;
		MousetipIcon = null;
		Culture = 0;
		Safety = 0;
		Population = 0;
		CharTemplateIds = new short[2] { -1, -1 };
		RandomEnemyTemplateIds = new short[9] { -1, -1, -1, -1, -1, -1, -1, -1, -1 };
		SettlementType = EOrganizationSettlementType.Invalid;
		IsSect = false;
		IsCivilian = true;
		SeniorityGroupId = -1;
		Goodness = 0;
		MainMorality = short.MinValue;
		GenderRestriction = -1;
		TeachingOutsiderProb = 30;
		Hereditary = true;
		AllowPoisoning = true;
		NoMeatEating = false;
		NoDrinking = false;
		MerchantTendency = 0;
		MerchantLevel = 1;
		LegendaryBookTendency = 0;
		AbandonedBabyOrganizations = new List<sbyte>();
		PunishmentFeature = 0;
		TaiwuPunishementFeature = null;
		LearnLifeSkillTypes = new List<sbyte>();
		CombatSkillTypes = new List<sbyte>();
		FiveElementsType = -1;
		InfluencePowerUpdateInterval = -1;
		LargeSectFavorabilities = new sbyte[15];
		Members = null;
		RetireGrade = 0;
		MemberFeature = 0;
		OrganizationExtraDesc = null;
		PrisonBuilding = 0;
		MartialArtistItemBonus = null;
		VowSpecialHint = null;
		TaiwuBeHunted = 0;
		SkillBreakBonusWeights = null;
		LifeSkillCombatBriberyItemTypeWeight = new List<LifeSkillCombatBriberyItemTypeWeight>();
		LifeSkillCombatBriberyItemSubTypeWeight = new List<LifeSkillCombatBriberyItemSubTypeWeight>();
		VowFixedRewardItems = null;
		VowRandomRewardItems = null;
		VowRandomRewardItemsCount = 0;
		PopulationThreshold = -1;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public OrganizationItem(sbyte templateId, OrganizationItem other)
	{
		TemplateId = templateId;
		Name = other.Name;
		Desc = other.Desc;
		TaiwuVillageSteleDesc = other.TaiwuVillageSteleDesc;
		Icon = other.Icon;
		MousetipIcon = other.MousetipIcon;
		Culture = other.Culture;
		Safety = other.Safety;
		Population = other.Population;
		CharTemplateIds = other.CharTemplateIds;
		RandomEnemyTemplateIds = other.RandomEnemyTemplateIds;
		SettlementType = other.SettlementType;
		IsSect = other.IsSect;
		IsCivilian = other.IsCivilian;
		SeniorityGroupId = other.SeniorityGroupId;
		Goodness = other.Goodness;
		MainMorality = other.MainMorality;
		GenderRestriction = other.GenderRestriction;
		TeachingOutsiderProb = other.TeachingOutsiderProb;
		Hereditary = other.Hereditary;
		AllowPoisoning = other.AllowPoisoning;
		NoMeatEating = other.NoMeatEating;
		NoDrinking = other.NoDrinking;
		MerchantTendency = other.MerchantTendency;
		MerchantLevel = other.MerchantLevel;
		LegendaryBookTendency = other.LegendaryBookTendency;
		AbandonedBabyOrganizations = other.AbandonedBabyOrganizations;
		PunishmentFeature = other.PunishmentFeature;
		TaiwuPunishementFeature = other.TaiwuPunishementFeature;
		LearnLifeSkillTypes = other.LearnLifeSkillTypes;
		CombatSkillTypes = other.CombatSkillTypes;
		FiveElementsType = other.FiveElementsType;
		InfluencePowerUpdateInterval = other.InfluencePowerUpdateInterval;
		LargeSectFavorabilities = other.LargeSectFavorabilities;
		Members = other.Members;
		RetireGrade = other.RetireGrade;
		MemberFeature = other.MemberFeature;
		OrganizationExtraDesc = other.OrganizationExtraDesc;
		PrisonBuilding = other.PrisonBuilding;
		MartialArtistItemBonus = other.MartialArtistItemBonus;
		VowSpecialHint = other.VowSpecialHint;
		TaiwuBeHunted = other.TaiwuBeHunted;
		SkillBreakBonusWeights = other.SkillBreakBonusWeights;
		LifeSkillCombatBriberyItemTypeWeight = other.LifeSkillCombatBriberyItemTypeWeight;
		LifeSkillCombatBriberyItemSubTypeWeight = other.LifeSkillCombatBriberyItemSubTypeWeight;
		VowFixedRewardItems = other.VowFixedRewardItems;
		VowRandomRewardItems = other.VowRandomRewardItems;
		VowRandomRewardItemsCount = other.VowRandomRewardItemsCount;
		PopulationThreshold = other.PopulationThreshold;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override OrganizationItem Duplicate(int templateId)
	{
		return new OrganizationItem((sbyte)templateId, this);
	}
}
