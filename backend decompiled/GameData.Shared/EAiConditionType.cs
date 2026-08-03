/// <summary>
/// AiCondition -&gt; Type
/// </summary>
public enum EAiConditionType
{
	/// <summary>
	/// 延迟
	/// </summary>
	Delay,
	/// <summary>
	/// 概率
	/// </summary>
	CheckPercentProb,
	/// <summary>
	/// 首次
	/// </summary>
	First,
	/// <summary>
	/// 功法0
	/// </summary>
	EquipCombatSkill,
	/// <summary>
	/// 功法1
	/// </summary>
	BreakCombatSkill,
	/// <summary>
	/// 功法2
	/// </summary>
	LearnCombatSkill,
	/// <summary>
	/// 位置0
	/// </summary>
	InCurrentAttackRange,
	/// <summary>
	/// 位置1
	/// </summary>
	InCombatSkillRange,
	/// <summary>
	/// 位置2
	/// </summary>
	AnyAttackRangeEdge,
	/// <summary>
	/// 记忆等于0
	/// </summary>
	MemoryEqualString,
	/// <summary>
	/// 记忆等于1
	/// </summary>
	MemoryEqualBoolean,
	/// <summary>
	/// 记忆等于2
	/// </summary>
	MemoryEqual,
	/// <summary>
	/// 记忆不等0
	/// </summary>
	MemoryNotEqualString,
	/// <summary>
	/// 记忆不等1
	/// </summary>
	MemoryNotEqualBoolean,
	/// <summary>
	/// 记忆不等2
	/// </summary>
	MemoryNotEqual,
	/// <summary>
	/// 记忆大于
	/// </summary>
	MemoryAbove,
	/// <summary>
	/// 记忆小于
	/// </summary>
	MemoryBelow,
	/// <summary>
	/// 战斗难度
	/// </summary>
	CombatDifficulty,
	/// <summary>
	/// 目标距离0
	/// </summary>
	TargetDistanceNearby,
	/// <summary>
	/// 目标距离1
	/// </summary>
	TargetDistanceIsNot,
	/// <summary>
	/// 目标距离2
	/// </summary>
	TargetDistanceIsNotFarthest,
	/// <summary>
	/// 正在施展0
	/// </summary>
	CastingSkillType,
	/// <summary>
	/// 正在施展1
	/// </summary>
	CastingSkill,
	/// <summary>
	/// 功法进度0
	/// </summary>
	CastingProgressMoreOrEqual,
	/// <summary>
	/// 功法进度1
	/// </summary>
	CastingProgressLess,
	/// <summary>
	/// 招架
	/// </summary>
	BlockPercentLess,
	/// <summary>
	/// 逃跑0
	/// </summary>
	IsCharacterHalfFallen,
	/// <summary>
	/// 逃跑1
	/// </summary>
	CheckBanFlee,
	/// <summary>
	/// 逃跑2
	/// </summary>
	CheckFleeNormal,
	/// <summary>
	/// 逃跑3
	/// </summary>
	InHazard,
	/// <summary>
	/// 选项0
	/// </summary>
	OptionAttack,
	/// <summary>
	/// 选项1
	/// </summary>
	OptionChangeTrick,
	/// <summary>
	/// 选项2
	/// </summary>
	OptionChangeTrickFlaw,
	/// <summary>
	/// 选项3
	/// </summary>
	OptionChangeTrickAcupoint,
	/// <summary>
	/// 选项4
	/// </summary>
	OptionChangeTrickNeiliType,
	/// <summary>
	/// 选项5
	/// </summary>
	OptionChangeWeapon,
	/// <summary>
	/// 选项6
	/// </summary>
	OptionTryDodge,
	/// <summary>
	/// 选项7
	/// </summary>
	OptionOtherAction,
	/// <summary>
	/// 选项8
	/// </summary>
	OptionTeammateCommand,
	/// <summary>
	/// 选项9
	/// </summary>
	OptionProactiveSkillType,
	/// <summary>
	/// 选项10
	/// </summary>
	OptionCastBoost,
	/// <summary>
	/// 选项11
	/// </summary>
	OptionCastDefendBlock,
	/// <summary>
	/// 选项12
	/// </summary>
	OptionCastAgileBuff,
	/// <summary>
	/// 选项13
	/// </summary>
	OptionUseItemHealInjury,
	/// <summary>
	/// 选项14
	/// </summary>
	OptionUseItemHealPoison,
	/// <summary>
	/// 选项15
	/// </summary>
	OptionUseItemHealQiDisorder,
	/// <summary>
	/// 选项16
	/// </summary>
	OptionUseItemBuff,
	/// <summary>
	/// 选项17
	/// </summary>
	OptionUseItemPoison,
	/// <summary>
	/// 选项18
	/// </summary>
	OptionUseItemNeili,
	/// <summary>
	/// 选项19
	/// </summary>
	OptionUseItemWine,
	/// <summary>
	/// 选项20
	/// </summary>
	OptionUseItemRepairWeapon,
	/// <summary>
	/// 选项21
	/// </summary>
	OptionUseItemRepairArmor,
	/// <summary>
	/// 战斗类型
	/// </summary>
	CombatTypeEqual,
	/// <summary>
	/// 运起0
	/// </summary>
	AnyAffectingAgile,
	/// <summary>
	/// 运起1
	/// </summary>
	SpecialAffectingAgile,
	/// <summary>
	/// 运起2
	/// </summary>
	AnyAffectingDefense,
	/// <summary>
	/// 运起3
	/// </summary>
	SpecialAffectingDefense,
	/// <summary>
	/// 太吾
	/// </summary>
	IsTaiwu,
	/// <summary>
	/// 标记0
	/// </summary>
	InjuryMarkCountMoreOrEqual,
	/// <summary>
	/// 标记1
	/// </summary>
	FlawMarkCountMoreOrEqual,
	/// <summary>
	/// 标记2
	/// </summary>
	AcupointMarkCountMoreOrEqual,
	/// <summary>
	/// 标记3
	/// </summary>
	PoisonMarkCountMoreOrEqual,
	/// <summary>
	/// 标记4
	/// </summary>
	MindMarkCountMoreOrEqual,
	/// <summary>
	/// 标记5
	/// </summary>
	FatalMarkCountMoreOrEqual,
	/// <summary>
	/// 标记6
	/// </summary>
	DieMarkCountMoreOrEqual,
	/// <summary>
	/// 标记7
	/// </summary>
	QiDisorderMarkCountMoreOrEqual,
	/// <summary>
	/// 标记8
	/// </summary>
	StateMarkCountMoreOrEqual,
	/// <summary>
	/// 标记9
	/// </summary>
	HealthMarkCountMoreOrEqual,
	/// <summary>
	/// 标记10
	/// </summary>
	HasGrowingWug,
	/// <summary>
	/// 标记11
	/// </summary>
	HasGrownWug,
	/// <summary>
	/// 标记12
	/// </summary>
	HasKingWug,
	/// <summary>
	/// 标记13
	/// </summary>
	NeiliAllocationPercentMoreOrEqual,
	/// <summary>
	/// 功法效果
	/// </summary>
	CombatSkillEffectCountMoreOrEqual,
	/// <summary>
	/// 脚力值
	/// </summary>
	MobilityPercentMoreOrEqual,
	/// <summary>
	/// 疲怠中
	/// </summary>
	MobilityLocking,
	/// <summary>
	/// 精纯
	/// </summary>
	ConsummateLevelMoreOrEqual,
	/// <summary>
	/// 阶段
	/// </summary>
	BossPhaseMoreOrEqual,
	/// <summary>
	/// 式槽
	/// </summary>
	TrickCountMoreOrEqual,
	/// <summary>
	/// 选项22
	/// </summary>
	OptionChangeWeaponIndex,
	/// <summary>
	/// 选项23
	/// </summary>
	OptionChangeWeaponSpecial,
	/// <summary>
	/// 选项24
	/// </summary>
	OptionChangeWeaponType,
	/// <summary>
	/// 当前武器0
	/// </summary>
	CurrentWeaponIsSpecial,
	/// <summary>
	/// 当前武器1
	/// </summary>
	CurrentWeaponIsType,
	/// <summary>
	/// 内力属性
	/// </summary>
	NeiliTypeFiveElementEqual,
	/// <summary>
	/// 标记14
	/// </summary>
	AllMarkCountMoreOrEqual,
	/// <summary>
	/// 标记15
	/// </summary>
	OuterOrInnerInjuryMarkCountMoreOrEqual,
	/// <summary>
	/// 标记16
	/// </summary>
	AllInjuryMarkCountMoreOrEqual,
	/// <summary>
	/// 标记17
	/// </summary>
	AllFlawMarkCountMoreOrEqual,
	/// <summary>
	/// 标记18
	/// </summary>
	AllAcupointMarkCountMoreOrEqual,
	/// <summary>
	/// 记忆内大于
	/// </summary>
	MemoryInternalAbove,
	/// <summary>
	/// 记忆内小于
	/// </summary>
	MemoryInternalBelow,
	/// <summary>
	/// 记忆等于施展
	/// </summary>
	MemoryEqualCasting,
	/// <summary>
	/// 位置3
	/// </summary>
	AttackRangeEdgeMore,
	/// <summary>
	/// 位置4
	/// </summary>
	AttackRangeEdgeLess,
	/// <summary>
	/// 环境0
	/// </summary>
	EnvironmentLastNormalAttackAnyMiss,
	/// <summary>
	/// 当前武器2
	/// </summary>
	CurrentWeaponIsIndex,
	/// <summary>
	/// 正在施展2
	/// </summary>
	CastingDirectOrReverseSkill,
	/// <summary>
	/// 选项25
	/// </summary>
	OptionCastSpecialCombatSkill,
	/// <summary>
	/// 选项26
	/// </summary>
	OptionCastDirectOrReverseCombatSkill,
	/// <summary>
	/// 状态0
	/// </summary>
	BuffStatePowerSumMoreOrEqual,
	/// <summary>
	/// 状态1
	/// </summary>
	DebuffStatePowerSumMoreOrEqual,
	/// <summary>
	/// 状态2
	/// </summary>
	SpecialStatePowerSumMoreOrEqual,
	/// <summary>
	/// 位置5
	/// </summary>
	InMemoryCombatSkillRange,
	/// <summary>
	/// 选项27
	/// </summary>
	OptionCastMemoryCombatSkill,
	/// <summary>
	/// 位置6
	/// </summary>
	CurrentDistanceEqual,
	/// <summary>
	/// 位置7
	/// </summary>
	CurrentDistanceAbove,
	/// <summary>
	/// 位置8
	/// </summary>
	CurrentDistanceBelow,
	/// <summary>
	/// 环境1
	/// </summary>
	EnvironmentLastNormalAttackOutOfRange,
	/// <summary>
	/// 选项28
	/// </summary>
	OptionUnlockAttackWeapon,
	/// <summary>
	/// 选项29
	/// </summary>
	OptionUnlockAttackWeaponType,
	/// <summary>
	/// 解封值
	/// </summary>
	UnlockAttackValuePercentMoreOrEqual,
	/// <summary>
	/// 选项30
	/// </summary>
	OptionInterruptCasting,
	/// <summary>
	/// 选项31
	/// </summary>
	OptionInterruptAffectingDefense,
	/// <summary>
	/// 选项32
	/// </summary>
	OptionInterruptAffectingMove,
	/// <summary>
	/// 选项33
	/// </summary>
	OptionAutoCostTrick,
	/// <summary>
	/// 选项34
	/// </summary>
	OptionUseItemMisc,
	/// <summary>
	/// 功法被封禁
	/// </summary>
	AnyNotInfinitySilenceSkill,
	/// <summary>
	/// 存在任意同道
	/// </summary>
	AnyTeammate,
	/// <summary>
	/// 提气值
	/// </summary>
	BreathPercentMoreOrEqual,
	/// <summary>
	/// 架势值
	/// </summary>
	StancePercentMoreOrEqual,
	/// <summary>
	/// 目标距离3
	/// </summary>
	TargetDistanceGreaterThan,
	/// <summary>
	/// 御体御气
	/// </summary>
	PenetrationResist,
	/// <summary>
	/// 摧破内外比1
	/// </summary>
	PreparingAttackRatio,
	/// <summary>
	/// 身法跳跃
	/// </summary>
	MoveJump,
	/// <summary>
	/// 摧破内外比2
	/// </summary>
	ExistAttackRatio,
	/// <summary>
	/// 护体功法1
	/// </summary>
	ExistDefenseBounce,
	/// <summary>
	/// 攻击落空
	/// </summary>
	AttackMiss,
	Count
}
