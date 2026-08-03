/// <summary>
/// SkillBreakPlateGridBonusType -&gt; AppearType
/// </summary>
public enum ESkillBreakPlateGridBonusTypeAppearType
{
	/// <summary>
	/// 独创心法不可出现
	/// </summary>
	Never,
	/// <summary>
	/// 不限制
	/// </summary>
	NoLimit,
	/// <summary>
	/// 仅内功、被动绝技出现
	/// </summary>
	NeigongAndPassiveSkill,
	/// <summary>
	/// 内功、被动绝技不可出现
	/// </summary>
	NeigongAndPassiveSkillExclude,
	/// <summary>
	/// 仅内功
	/// </summary>
	NeigongOnly,
	/// <summary>
	/// 仅内功可出现，配置中非混元内功
	/// </summary>
	NeigongOnlyExcludeMix,
	/// <summary>
	/// 仅身法
	/// </summary>
	PosingOnly,
	/// <summary>
	/// 仅身法，配置中的增加力道&gt;0
	/// </summary>
	PosingAndStrength,
	/// <summary>
	/// 仅身法，配置中的增加精妙&gt;0
	/// </summary>
	PosingAndTechnique,
	/// <summary>
	/// 仅身法，配置中的增加迅疾&gt;0
	/// </summary>
	PosingAndSpeed,
	/// <summary>
	/// 仅身法，配置中的增加动心&gt;0
	/// </summary>
	PosingAndMind,
	/// <summary>
	/// 仅身法，配置中的每帧身法消耗&gt;0的可出现
	/// </summary>
	PosingAndSpeedCost,
	/// <summary>
	/// 仅身法，配置中的每次移动消耗&gt;0的可出现
	/// </summary>
	PosingAndMoveCost,
	/// <summary>
	/// 仅护体功法，配置中的增加御体&gt;0
	/// </summary>
	DefendSkillAndOuterDef,
	/// <summary>
	/// 仅护体功法，配置中的增加御气&gt;0
	/// </summary>
	DefendSkillAndInnerDef,
	/// <summary>
	/// 仅护体功法，配置中的增加卸力&gt;0
	/// </summary>
	DefendSkillAndAvoidStrength,
	/// <summary>
	/// 仅护体功法，配置中的增加拆招&gt;0
	/// </summary>
	DefendSkillAndAvoidTechnique,
	/// <summary>
	/// 仅护体功法，配置中的增加闪避&gt;0
	/// </summary>
	DefendSkillAndAvoidSpeed,
	/// <summary>
	/// 仅护体功法，配置中的增加守心&gt;0
	/// </summary>
	DefendSkillAndAvoidMind,
	/// <summary>
	/// 仅护体功法，配置中的反击威力&gt;0
	/// </summary>
	DefendSkillAndFightbackPower,
	/// <summary>
	/// 仅护体功法，配置中的外伤反震威力&gt;0
	/// </summary>
	DefendSkillAndBouncePowerOuter,
	/// <summary>
	/// 仅护体功法，配置中的内伤反震威力&gt;0
	/// </summary>
	DefendSkillAndBouncePowerInner,
	/// <summary>
	/// 仅护体功法，配置中的反震距离&gt;0
	/// </summary>
	DefendSkillAndBounceDistance,
	/// <summary>
	/// 仅护体功法
	/// </summary>
	DefendSkillOnly,
	/// <summary>
	/// 仅摧破功法
	/// </summary>
	AttackSkillOnly,
	/// <summary>
	/// 仅摧破功法，当前精妙成数&gt;10
	/// </summary>
	AttackSkillAndTechniqueHitDistribution,
	/// <summary>
	/// 仅摧破功法，当前迅疾成数&gt;10
	/// </summary>
	AttackSkillAndSpeedHitDistribution,
	/// <summary>
	/// 仅摧破功法，当前力道成数&gt;10
	/// </summary>
	AttackSkillAndStrengthHitDistribution,
	/// <summary>
	/// 仅摧破功法，配置中的攻击胸背&gt;0
	/// </summary>
	AttackSkillAndHitChest,
	/// <summary>
	/// 仅摧破功法，配置中的攻击腰腹&gt;0
	/// </summary>
	AttackSkillAndHitBelly,
	/// <summary>
	/// 仅摧破功法，配置中的攻击头部&gt;0
	/// </summary>
	AttackSkillAndHitHead,
	/// <summary>
	/// 仅摧破功法，配置中的攻击双手&gt;0
	/// </summary>
	AttackSkillAndHitBothHands,
	/// <summary>
	/// 仅摧破功法，配置中的攻击双足&gt;0
	/// </summary>
	AttackSkillAndHitBothLegs,
	/// <summary>
	/// 仅摧破功法，配置中功法可点穴
	/// </summary>
	AttackSkillAndHasAtkAcupointEffect,
	/// <summary>
	/// 仅摧破功法，配置中功法可破绽
	/// </summary>
	AttackSkillAndHasAtkFlawEffect,
	/// <summary>
	/// 仅摧破功法，配置中对应类型的烈毒存在
	/// </summary>
	AttackSkillAndHotPoison,
	/// <summary>
	/// 仅摧破功法，配置中对应类型的郁毒存在
	/// </summary>
	AttackSkillAndGloomyPoison,
	/// <summary>
	/// 仅摧破功法，配置中对应类型的寒毒存在
	/// </summary>
	AttackSkillAndColdPoison,
	/// <summary>
	/// 仅摧破功法，配置中对应类型的赤毒存在
	/// </summary>
	AttackSkillAndRedPoison,
	/// <summary>
	/// 仅摧破功法，配置中对应类型的腐毒存在
	/// </summary>
	AttackSkillAndRottenPoison,
	/// <summary>
	/// 仅摧破功法，配置中对应类型的幻毒存在
	/// </summary>
	AttackSkillAndIllusoryPoison,
	/// <summary>
	/// 仅摧破功法，当前总计至少需要1个式
	/// </summary>
	AttackSkillAndTrickCost,
	/// <summary>
	/// 仅身法，配置中的蓄力帧数&gt;0
	/// </summary>
	PosingAndJumpPrepareFrame,
	/// <summary>
	/// 仅摧破功法，配置中对应类型的式消耗存在
	/// </summary>
	AttackSkillAndTrickCostExist,
	Count
}
