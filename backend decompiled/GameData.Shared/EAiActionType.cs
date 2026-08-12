/// <summary>
/// AiAction -&gt; Type
/// </summary>
public enum EAiActionType
{
	/// <summary>
	/// 普攻
	/// </summary>
	NormalAttack,
	/// <summary>
	/// 普攻1
	/// </summary>
	ChangeTrick,
	/// <summary>
	/// 普攻2
	/// </summary>
	ChangeTrickFlaw,
	/// <summary>
	/// 普攻3
	/// </summary>
	ChangeTrickAcupoint,
	/// <summary>
	/// 普攻4
	/// </summary>
	ChangeTrickNeiliType,
	/// <summary>
	/// 功法
	/// </summary>
	CastSkill,
	/// <summary>
	/// 功法1
	/// </summary>
	CastSkillAttackBest,
	/// <summary>
	/// 功法2
	/// </summary>
	CastSkillDefendBest,
	/// <summary>
	/// 功法3
	/// </summary>
	CastSkillDefendBlock,
	/// <summary>
	/// 功法4
	/// </summary>
	CastSkillAgileBuff,
	/// <summary>
	/// 功法5
	/// </summary>
	CastSkillAgileSpeed,
	/// <summary>
	/// 功法6
	/// </summary>
	CastSkillCastBoost,
	/// <summary>
	/// 移动0
	/// </summary>
	MoveToAttackRangeCenter,
	/// <summary>
	/// 移动1
	/// </summary>
	MoveToNearbyEscape,
	/// <summary>
	/// 移动2
	/// </summary>
	MoveToTargetDistance,
	/// <summary>
	/// 移动3
	/// </summary>
	MoveToFarthest,
	/// <summary>
	/// 记忆0
	/// </summary>
	MemorySetString,
	/// <summary>
	/// 记忆1
	/// </summary>
	MemorySetBoolean,
	/// <summary>
	/// 记忆2
	/// </summary>
	MemorySet,
	/// <summary>
	/// 同道指令
	/// </summary>
	UseTeammateCommand,
	/// <summary>
	/// 武器
	/// </summary>
	ChangeWeaponAuto,
	/// <summary>
	/// 行为
	/// </summary>
	UseOtherAction,
	/// <summary>
	/// 道具0
	/// </summary>
	UseItemHealInjury,
	/// <summary>
	/// 道具1
	/// </summary>
	UseItemHealPoison,
	/// <summary>
	/// 道具2
	/// </summary>
	UseItemHealQiDisorder,
	/// <summary>
	/// 道具3
	/// </summary>
	UseItemBuff,
	/// <summary>
	/// 道具4
	/// </summary>
	UseItemPoison,
	/// <summary>
	/// 道具5
	/// </summary>
	UseItemNeili,
	/// <summary>
	/// 道具6
	/// </summary>
	UseItemWine,
	/// <summary>
	/// 道具7
	/// </summary>
	UseItemRepairWeapon,
	/// <summary>
	/// 道具8
	/// </summary>
	UseItemRepairArmor,
	/// <summary>
	/// 武器1
	/// </summary>
	ChangeWeaponIndex,
	/// <summary>
	/// 武器2
	/// </summary>
	ChangeWeaponSpecial,
	/// <summary>
	/// 武器3
	/// </summary>
	ChangeWeaponType,
	/// <summary>
	/// 记忆3
	/// </summary>
	MemoryAdd,
	/// <summary>
	/// 中断0
	/// </summary>
	InterruptCasting,
	/// <summary>
	/// 中断1
	/// </summary>
	InterruptAffectingDefense,
	/// <summary>
	/// 记忆4
	/// </summary>
	MemoryInternalSetString,
	/// <summary>
	/// 记忆5
	/// </summary>
	MemoryInternalSetBoolean,
	/// <summary>
	/// 记忆6
	/// </summary>
	MemoryInternalSet,
	/// <summary>
	/// 记忆7
	/// </summary>
	MemorySetAllMarkCount,
	/// <summary>
	/// 记忆8
	/// </summary>
	MemorySetInjuryMarkCount,
	/// <summary>
	/// 记忆9
	/// </summary>
	MemorySetFlawMarkCount,
	/// <summary>
	/// 记忆10
	/// </summary>
	MemorySetAcupointMarkCount,
	/// <summary>
	/// 记忆11
	/// </summary>
	MemorySetPoisonMarkCount,
	/// <summary>
	/// 记忆12
	/// </summary>
	MemorySetMindMarkCount,
	/// <summary>
	/// 记忆13
	/// </summary>
	MemorySetFatalMarkCount,
	/// <summary>
	/// 记忆14
	/// </summary>
	MemorySetChangeTrickCountByFlawCost,
	/// <summary>
	/// 记忆15
	/// </summary>
	MemorySetSpecialCombatSkill,
	/// <summary>
	/// 移动4
	/// </summary>
	MoveToAttackRangeEdge,
	/// <summary>
	/// 记忆16
	/// </summary>
	MemorySetLastPrepareCombatSkill,
	/// <summary>
	/// 优先级0
	/// </summary>
	PrioritySetHigh,
	/// <summary>
	/// 优先级1
	/// </summary>
	PrioritySetLow,
	/// <summary>
	/// 优先级2
	/// </summary>
	PriorityReset,
	/// <summary>
	/// 记忆17
	/// </summary>
	MemorySetBestAttackCombatSkill,
	/// <summary>
	/// 功法7
	/// </summary>
	CastSkillByMemory,
	/// <summary>
	/// 中断2
	/// </summary>
	InterruptAffectingMove,
	/// <summary>
	/// 解封1
	/// </summary>
	UnlockAttackWeapon,
	/// <summary>
	/// 解封2
	/// </summary>
	UnlockAttackWeaponType,
	/// <summary>
	/// 消耗蓄式1
	/// </summary>
	CostFirstUnavailableTrick,
	/// <summary>
	/// 消耗蓄式2
	/// </summary>
	CostMemoryFirstTrick,
	/// <summary>
	/// 消耗蓄式3
	/// </summary>
	CostFirstAnyTrick,
	/// <summary>
	/// 道具9
	/// </summary>
	UseItemMisc,
	/// <summary>
	/// 记忆18
	/// </summary>
	MemorySetNeedUseSkill,
	/// <summary>
	/// 功法8
	/// </summary>
	CastSkillAgileJumpPrepare,
	/// <summary>
	/// 功法9
	/// </summary>
	CastSkillAttackRatio,
	/// <summary>
	/// 功法10
	/// </summary>
	CastSkillDefenceBounce,
	Count
}
