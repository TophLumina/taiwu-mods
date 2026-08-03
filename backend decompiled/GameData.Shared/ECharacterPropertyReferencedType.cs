/// <summary>
/// CharacterPropertyReferenced -&gt; Type
/// </summary>
public enum ECharacterPropertyReferencedType
{
	/// <summary>
	/// 主要属性 - 膂力
	/// </summary>
	Strength,
	/// <summary>
	/// 主要属性 - 灵敏
	/// </summary>
	Dexterity,
	/// <summary>
	/// 主要属性 - 定力
	/// </summary>
	Concentration,
	/// <summary>
	/// 主要属性 - 体质
	/// </summary>
	Vitality,
	/// <summary>
	/// 主要属性 - 根骨
	/// </summary>
	Energy,
	/// <summary>
	/// 主要属性 - 悟性
	/// </summary>
	Intelligence,
	/// <summary>
	/// 命中 - 力道
	/// </summary>
	HitRateStrength,
	/// <summary>
	/// 命中 - 精妙
	/// </summary>
	HitRateTechnique,
	/// <summary>
	/// 命中 - 迅疾
	/// </summary>
	HitRateSpeed,
	/// <summary>
	/// 命中 - 动心
	/// </summary>
	HitRateMind,
	/// <summary>
	/// 攻击 - 破体
	/// </summary>
	PenetrateOfOuter,
	/// <summary>
	/// 攻击 - 破气
	/// </summary>
	PenetrateOfInner,
	/// <summary>
	/// 化解 - 卸力
	/// </summary>
	AvoidRateStrength,
	/// <summary>
	/// 化解 - 拆招
	/// </summary>
	AvoidRateTechnique,
	/// <summary>
	/// 化解 - 闪避
	/// </summary>
	AvoidRateSpeed,
	/// <summary>
	/// 化解 - 守心
	/// </summary>
	AvoidRateMind,
	/// <summary>
	/// 防御 - 御体
	/// </summary>
	PenetrateResistOfOuter,
	/// <summary>
	/// 防御 - 御气
	/// </summary>
	PenetrateResistOfInner,
	/// <summary>
	/// 次要属性 - 架势恢复
	/// </summary>
	RecoveryOfStance,
	/// <summary>
	/// 次要属性 - 提气恢复
	/// </summary>
	RecoveryOfBreath,
	/// <summary>
	/// 次要属性 - 移动速度
	/// </summary>
	MoveSpeed,
	/// <summary>
	/// 次要属性 - 步伐稳健
	/// </summary>
	RecoveryOfFlaw,
	/// <summary>
	/// 次要属性 - 施展速度
	/// </summary>
	CastSpeed,
	/// <summary>
	/// 次要属性 - 引气冲关
	/// </summary>
	RecoveryOfBlockedAcupoint,
	/// <summary>
	/// 次要属性 - 武具运用
	/// </summary>
	WeaponSwitchSpeed,
	/// <summary>
	/// 次要属性 - 攻击速度
	/// </summary>
	AttackSpeed,
	/// <summary>
	/// 次要属性 - 内功发挥
	/// </summary>
	InnerRatio,
	/// <summary>
	/// 次要属性 - 调息吐纳
	/// </summary>
	RecoveryOfQiDisorder,
	/// <summary>
	/// 毒素抵抗 - 烈毒
	/// </summary>
	ResistOfHotPoison,
	/// <summary>
	/// 毒素抵抗 - 郁毒
	/// </summary>
	ResistOfGloomyPoison,
	/// <summary>
	/// 毒素抵抗 - 寒毒
	/// </summary>
	ResistOfColdPoison,
	/// <summary>
	/// 毒素抵抗 - 赤毒
	/// </summary>
	ResistOfRedPoison,
	/// <summary>
	/// 毒素抵抗 - 腐毒
	/// </summary>
	ResistOfRottenPoison,
	/// <summary>
	/// 毒素抵抗 - 幻毒
	/// </summary>
	ResistOfIllusoryPoison,
	/// <summary>
	/// 技艺资质 - 音律
	/// </summary>
	QualificationMusic,
	/// <summary>
	/// 技艺资质 - 弈棋
	/// </summary>
	QualificationChess,
	/// <summary>
	/// 技艺资质 - 诗书
	/// </summary>
	QualificationPoem,
	/// <summary>
	/// 技艺资质 - 绘画
	/// </summary>
	QualificationPainting,
	/// <summary>
	/// 技艺资质 - 术数
	/// </summary>
	QualificationMath,
	/// <summary>
	/// 技艺资质 - 品鉴
	/// </summary>
	QualificationAppraisal,
	/// <summary>
	/// 技艺资质 - 锻造
	/// </summary>
	QualificationForging,
	/// <summary>
	/// 技艺资质 - 制木
	/// </summary>
	QualificationWoodworking,
	/// <summary>
	/// 技艺资质 - 医术
	/// </summary>
	QualificationMedicine,
	/// <summary>
	/// 技艺资质 - 毒术
	/// </summary>
	QualificationToxicology,
	/// <summary>
	/// 技艺资质 - 织锦
	/// </summary>
	QualificationWeaving,
	/// <summary>
	/// 技艺资质 - 巧匠
	/// </summary>
	QualificationJade,
	/// <summary>
	/// 技艺资质 - 道法
	/// </summary>
	QualificationTaoism,
	/// <summary>
	/// 技艺资质 - 佛学
	/// </summary>
	QualificationBuddhism,
	/// <summary>
	/// 技艺资质 - 厨艺
	/// </summary>
	QualificationCooking,
	/// <summary>
	/// 技艺资质 - 杂学
	/// </summary>
	QualificationEclectic,
	/// <summary>
	/// 技艺造诣 - 音律
	/// </summary>
	AttainmentMusic,
	/// <summary>
	/// 技艺造诣 - 弈棋
	/// </summary>
	AttainmentChess,
	/// <summary>
	/// 技艺造诣 - 诗书
	/// </summary>
	AttainmentPoem,
	/// <summary>
	/// 技艺造诣 - 绘画
	/// </summary>
	AttainmentPainting,
	/// <summary>
	/// 技艺造诣 - 术数
	/// </summary>
	AttainmentMath,
	/// <summary>
	/// 技艺造诣 - 品鉴
	/// </summary>
	AttainmentAppraisal,
	/// <summary>
	/// 技艺造诣 - 锻造
	/// </summary>
	AttainmentForging,
	/// <summary>
	/// 技艺造诣 - 制木
	/// </summary>
	AttainmentWoodworking,
	/// <summary>
	/// 技艺造诣 - 医术
	/// </summary>
	AttainmentMedicine,
	/// <summary>
	/// 技艺造诣 - 毒术
	/// </summary>
	AttainmentToxicology,
	/// <summary>
	/// 技艺造诣 - 织锦
	/// </summary>
	AttainmentWeaving,
	/// <summary>
	/// 技艺造诣 - 巧匠
	/// </summary>
	AttainmentJade,
	/// <summary>
	/// 技艺造诣 - 道法
	/// </summary>
	AttainmentTaoism,
	/// <summary>
	/// 技艺造诣 - 佛学
	/// </summary>
	AttainmentBuddhism,
	/// <summary>
	/// 技艺造诣 - 厨艺
	/// </summary>
	AttainmentCooking,
	/// <summary>
	/// 技艺造诣 - 杂学
	/// </summary>
	AttainmentEclectic,
	/// <summary>
	/// 武学资质 - 内功
	/// </summary>
	QualificationNeigong,
	/// <summary>
	/// 武学资质 - 身法
	/// </summary>
	QualificationPosing,
	/// <summary>
	/// 武学资质 - 绝技
	/// </summary>
	QualificationStunt,
	/// <summary>
	/// 武学资质 - 拳掌
	/// </summary>
	QualificationFistAndPalm,
	/// <summary>
	/// 武学资质 - 指法
	/// </summary>
	QualificationFinger,
	/// <summary>
	/// 武学资质 - 腿法
	/// </summary>
	QualificationLeg,
	/// <summary>
	/// 武学资质 - 暗器
	/// </summary>
	QualificationThrow,
	/// <summary>
	/// 武学资质 - 剑法
	/// </summary>
	QualificationSword,
	/// <summary>
	/// 武学资质 - 刀法
	/// </summary>
	QualificationBlade,
	/// <summary>
	/// 武学资质 - 长兵
	/// </summary>
	QualificationPolearm,
	/// <summary>
	/// 武学资质 - 奇门
	/// </summary>
	QualificationSpecial,
	/// <summary>
	/// 武学资质 - 软兵
	/// </summary>
	QualificationWhip,
	/// <summary>
	/// 武学资质 - 御射
	/// </summary>
	QualificationControllableShot,
	/// <summary>
	/// 武学资质 - 乐器
	/// </summary>
	QualificationCombatMusic,
	/// <summary>
	/// 武学造诣 - 内功
	/// </summary>
	AttainmentNeigong,
	/// <summary>
	/// 武学造诣 - 身法
	/// </summary>
	AttainmentPosing,
	/// <summary>
	/// 武学造诣 - 绝技
	/// </summary>
	AttainmentStunt,
	/// <summary>
	/// 武学造诣 - 拳掌
	/// </summary>
	AttainmentFistAndPalm,
	/// <summary>
	/// 武学造诣 - 指法
	/// </summary>
	AttainmentFinger,
	/// <summary>
	/// 武学造诣 - 腿法
	/// </summary>
	AttainmentLeg,
	/// <summary>
	/// 武学造诣 - 暗器
	/// </summary>
	AttainmentThrow,
	/// <summary>
	/// 武学造诣 - 剑法
	/// </summary>
	AttainmentSword,
	/// <summary>
	/// 武学造诣 - 刀法
	/// </summary>
	AttainmentBlade,
	/// <summary>
	/// 武学造诣 - 长兵
	/// </summary>
	AttainmentPolearm,
	/// <summary>
	/// 武学造诣 - 奇门
	/// </summary>
	AttainmentSpecial,
	/// <summary>
	/// 武学造诣 - 软兵
	/// </summary>
	AttainmentWhip,
	/// <summary>
	/// 武学造诣 - 御射
	/// </summary>
	AttainmentControllableShot,
	/// <summary>
	/// 武学造诣 - 乐器
	/// </summary>
	AttainmentCombatMusic,
	/// <summary>
	/// 七元赋性 - 冷静
	/// </summary>
	PersonalityCalm,
	/// <summary>
	/// 七元赋性 - 聪颖
	/// </summary>
	PersonalityClever,
	/// <summary>
	/// 七元赋性 - 热情
	/// </summary>
	PersonalityEnthusiastic,
	/// <summary>
	/// 七元赋性 - 勇壮
	/// </summary>
	PersonalityBrave,
	/// <summary>
	/// 七元赋性 - 坚毅
	/// </summary>
	PersonalityFirm,
	/// <summary>
	/// 七元赋性 - 福缘
	/// </summary>
	PersonalityLucky,
	/// <summary>
	/// 七元赋性 - 合道
	/// </summary>
	PersonalityPerceptive,
	/// <summary>
	/// 魅力
	/// </summary>
	Attraction,
	/// <summary>
	/// 生育能力
	/// </summary>
	Fertility,
	/// <summary>
	/// 喜恶变化周期
	/// </summary>
	HobbyChangingPeriod,
	/// <summary>
	/// 寿元
	/// </summary>
	MaxHealth,
	/// <summary>
	/// 最大内力
	/// </summary>
	MaxNeili,
	/// <summary>
	/// 武学造诣 - 神力
	/// </summary>
	AttainmentDivinePower,
	/// <summary>
	/// 武学造诣 - 鬼术
	/// </summary>
	AttainmentGhostTechnique,
	/// <summary>
	/// 技艺研读效率
	/// </summary>
	LifeSkillBookReadEfficiency,
	/// <summary>
	/// 功法研读效率
	/// </summary>
	CombatSkillBookReadEfficiency,
	/// <summary>
	/// 实战度
	/// </summary>
	CombatSkillProficiency,
	/// <summary>
	/// 促织缘
	/// </summary>
	CricketLuckPoint,
	/// <summary>
	/// 主要属性恢复量 - 膂力
	/// </summary>
	RecoveryStrength,
	/// <summary>
	/// 主要属性恢复量 - 灵敏
	/// </summary>
	RecoveryDexterity,
	/// <summary>
	/// 主要属性恢复量 - 定力
	/// </summary>
	RecoveryConcentration,
	/// <summary>
	/// 主要属性恢复量 - 体质
	/// </summary>
	RecoveryVitality,
	/// <summary>
	/// 主要属性恢复量 - 根骨
	/// </summary>
	RecoveryEnergy,
	/// <summary>
	/// 主要属性恢复量 - 悟性
	/// </summary>
	RecoveryIntelligence,
	/// <summary>
	/// 基础强健值
	/// </summary>
	BaseDamageStep,
	/// <summary>
	/// 内功突破天资数
	/// </summary>
	BreakStepNeigong,
	/// <summary>
	/// 身法突破天资数
	/// </summary>
	BreakStepPosing,
	/// <summary>
	/// 绝技突破天资数
	/// </summary>
	BreakStepStunt,
	/// <summary>
	/// 拳掌突破天资数
	/// </summary>
	BreakStepFistAndPalm,
	/// <summary>
	/// 指法突破天资数
	/// </summary>
	BreakStepFinger,
	/// <summary>
	/// 腿法突破天资数
	/// </summary>
	BreakStepLeg,
	/// <summary>
	/// 暗器突破天资数
	/// </summary>
	BreakStepThrow,
	/// <summary>
	/// 剑法突破天资数
	/// </summary>
	BreakStepSword,
	/// <summary>
	/// 刀法突破天资数
	/// </summary>
	BreakStepBlade,
	/// <summary>
	/// 长兵突破天资数
	/// </summary>
	BreakStepPolearm,
	/// <summary>
	/// 奇门突破天资数
	/// </summary>
	BreakStepSpecial,
	/// <summary>
	/// 软兵突破天资数
	/// </summary>
	BreakStepWhip,
	/// <summary>
	/// 御射突破天资数
	/// </summary>
	BreakStepControllableShot,
	/// <summary>
	/// 乐器突破天资数
	/// </summary>
	BreakStepCombatMusic,
	/// <summary>
	/// 表白成功率
	/// </summary>
	ConfessingLoveSuccessOdds,
	/// <summary>
	/// 先天万用格
	/// </summary>
	InnateGenericGrid,
	/// <summary>
	/// 契合度
	/// </summary>
	MysteryItemCompatibility,
	/// <summary>
	/// 内功威力
	/// </summary>
	SkillPowerNeigong,
	/// <summary>
	/// 摧破威力
	/// </summary>
	SkillPowerAttack,
	/// <summary>
	/// 轻灵威力
	/// </summary>
	SkillPowerAgile,
	/// <summary>
	/// 护体威力
	/// </summary>
	SkillPowerDefense,
	/// <summary>
	/// 奇窍威力
	/// </summary>
	SkillPowerAssist,
	/// <summary>
	/// 头部外伤强健
	/// </summary>
	BaseDamageStepOuterHead,
	/// <summary>
	/// 胸背外伤强健
	/// </summary>
	BaseDamageStepOuterChest,
	/// <summary>
	/// 双手外伤强健
	/// </summary>
	BaseDamageStepOuterHand,
	/// <summary>
	/// 腰腹外伤强健
	/// </summary>
	BaseDamageStepOuterBelly,
	/// <summary>
	/// 双腿外伤强健
	/// </summary>
	BaseDamageStepOuterLeg,
	/// <summary>
	/// 头部内伤强健
	/// </summary>
	BaseDamageStepInnerHead,
	/// <summary>
	/// 胸背内伤强健
	/// </summary>
	BaseDamageStepInnerChest,
	/// <summary>
	/// 双手内伤强健
	/// </summary>
	BaseDamageStepInnerHand,
	/// <summary>
	/// 腰腹内伤强健
	/// </summary>
	BaseDamageStepInnerBelly,
	/// <summary>
	/// 双腿内伤强健
	/// </summary>
	BaseDamageStepInnerLeg,
	/// <summary>
	/// 重创强健
	/// </summary>
	BaseDamageStepFatal,
	/// <summary>
	/// 心神强健
	/// </summary>
	BaseDamageStepMind,
	/// <summary>
	/// 人物机略
	/// </summary>
	Wisdom,
	/// <summary>
	/// 真气自然恢复速度
	/// </summary>
	NeiliAllocationAddSpeed,
	/// <summary>
	/// 真气自然消退速度
	/// </summary>
	NeiliAllocationReduceSpeed,
	/// <summary>
	/// 内功格栏位
	/// </summary>
	SkillSlotCountNeigong,
	/// <summary>
	/// 摧破格栏位
	/// </summary>
	SkillSlotCountAttack,
	/// <summary>
	/// 轻灵格栏位
	/// </summary>
	SkillSlotCountAgile,
	/// <summary>
	/// 护体格栏位
	/// </summary>
	SkillSlotCountDefense,
	/// <summary>
	/// 奇窍格栏位
	/// </summary>
	SkillSlotCountAssist,
	Count
}
