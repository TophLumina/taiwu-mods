namespace GameData.Domains.Combat;

/// <summary>
/// 同道指令禁用原因
/// </summary>
public enum ETeammateCommandBanReason : sbyte
{
	/// <summary>
	/// 内部原因 - 负面指令不可操作
	/// </summary>
	Negative = -2,
	/// <summary>
	/// 内部原因 - 指令未实装或不存在
	/// </summary>
	Internal,
	/// <summary>
	/// 通用提示 - 需主战者出战时才可使用
	/// </summary>
	CommonNotMain,
	/// <summary>
	/// 通用提示 - 同道指令未完成冷却
	/// </summary>
	CommonCd,
	/// <summary>
	/// 通用提示 - 同道已无法行动
	/// </summary>
	CommonFallen,
	/// <summary>
	/// 通用提示 - 同道指令被封禁
	/// </summary>
	CommonStop,
	/// <summary>
	/// 通用提示 - 存在正在执行中的同道指令
	/// </summary>
	CommonConflict,
	/// <summary>
	/// 催发 - 主战者没有正在施展的功法
	/// </summary>
	AccelerateNotPreparing,
	/// <summary>
	/// 迅进 - 与敌人之间的距离已不可拉近
	/// </summary>
	PushInEdge,
	/// <summary>
	/// 拉回 - 与敌人之间的距离已不可拉远
	/// </summary>
	PullInEdge,
	/// <summary>
	/// 疗伤 - 无伤无病，无须治疗
	/// </summary>
	HealInjuryNonInjury,
	/// <summary>
	/// 疗伤 - 大夫医术造诣不足，无法治疗当前的伤势
	/// </summary>
	HealInjuryAttainmentLack,
	/// <summary>
	/// 疗伤 - 同道剩余疗伤次数不足
	/// </summary>
	HealInjuryCountLack,
	/// <summary>
	/// 疗伤 - 同道药材数量不足
	/// </summary>
	HealInjuryHerbLack,
	/// <summary>
	/// 驱毒 - 无毒无痛，无须驱毒
	/// </summary>
	HealPoisonNonPoison,
	/// <summary>
	/// 驱毒 - 大夫毒术造诣不足，无法驱除当前的毒素
	/// </summary>
	HealPoisonAttainmentLack,
	/// <summary>
	/// 驱毒 - 同道剩余驱毒次数不足
	/// </summary>
	HealPoisonCountLack,
	/// <summary>
	/// 驱毒 - 同道药材数量不足
	/// </summary>
	HealPoisonHerbLack,
	/// <summary>
	/// 还护 - 主战者身上不存在破绽
	/// </summary>
	HealFlawNonFlaw,
	/// <summary>
	/// 解穴 - 主战者身上不存在点穴
	/// </summary>
	HealAcupointNonAcupoint,
	/// <summary>
	/// 替命 - 对应的伤势与重创标记数量不符合条件
	/// </summary>
	TransferInjuryNonInjury,
	/// <summary>
	/// 真气 - 剩余真气不足以完成传输
	/// </summary>
	TransferNeiliAllocationLack,
	/// <summary>
	/// 攻击 - 同道无可用式
	/// </summary>
	AttackNonTrick,
	/// <summary>
	/// 摧破 - 无可施展的摧破
	/// </summary>
	AttackSkillNonSkill,
	/// <summary>
	/// 摧破 - 同道摧破不符合本场战斗限制
	/// </summary>
	AttackSkillBanned,
	/// <summary>
	/// 防御 - 无可施展的护体
	/// </summary>
	DefendSkillNonSkill,
	/// <summary>
	/// 防御 - 同道护体不符合本场战斗限制
	/// </summary>
	DefendSkillBanned,
	/// <summary>
	/// 解封 - 主战者当前武器解封值已满或不可解封
	/// </summary>
	AddUnlockAttackValueFull,
	/// <summary>
	/// 替身 - 主战者或同道伤势、毒素与内息不符合转移条件
	/// </summary>
	TransferManyMarkNonAnyMark,
	/// <summary>
	/// 修理 - 无可修理的装备
	/// </summary>
	RepairItemNonAnyRepairable,
	/// <summary>
	/// 让手 - 敌人当前未施展功法
	/// </summary>
	EnemyNotInPreparing,
	/// <summary>
	/// 赤煞 - 对方所有部位均已有伤势
	/// </summary>
	EnemyAllBodyPartInjured,
	/// <summary>
	/// 异血 - 主战者没有重创标记
	/// </summary>
	MergeFatalToDieNoFatal,
	/// <summary>
	/// 焚莲 - 敌人所有真气均未超出上限
	/// </summary>
	AbsorbNeiliAllocationNoTarget
}
