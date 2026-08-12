/// <summary>
/// TeammateCommand -&gt; Implement
/// </summary>
public enum ETeammateCommandImplement
{
	/// <summary>
	/// 未实装
	/// </summary>
	Invalid = -1,
	/// <summary>
	/// 出战
	/// </summary>
	Fight = 0,
	/// <summary>
	/// 催发
	/// </summary>
	AccelerateCast = 1,
	/// <summary>
	/// 迅进
	/// </summary>
	Push = 2,
	/// <summary>
	/// 拉回
	/// </summary>
	Pull = 3,
	/// <summary>
	/// 攻击
	/// </summary>
	Attack = 4,
	/// <summary>
	/// 防御
	/// </summary>
	Defend = 5,
	/// <summary>
	/// 疗伤
	/// </summary>
	HealInjury = 6,
	/// <summary>
	/// 驱毒
	/// </summary>
	HealPoison = 7,
	/// <summary>
	/// 还护
	/// </summary>
	HealFlaw = 8,
	/// <summary>
	/// 解穴
	/// </summary>
	HealAcupoint = 9,
	/// <summary>
	/// 掠阵
	/// </summary>
	AddHit = 10,
	/// <summary>
	/// 警示
	/// </summary>
	AddAvoid = 11,
	/// <summary>
	/// 真气
	/// </summary>
	TransferNeiliAllocation = 12,
	/// <summary>
	/// 替命
	/// </summary>
	TransferInjury = 13,
	/// <summary>
	/// 牵制
	/// </summary>
	StopEnemy = 14,
	/// <summary>
	/// 摧破
	/// </summary>
	AttackSkill = 15,
	/// <summary>
	/// 打断
	/// </summary>
	InterruptSkill = 16,
	/// <summary>
	/// 陷害
	/// </summary>
	PushOrPullIntoDanger = 17,
	/// <summary>
	/// 偷袭
	/// </summary>
	AttackFlawAndAcupoint = 19,
	/// <summary>
	/// 散功
	/// </summary>
	ClearAgileAndDefense = 20,
	/// <summary>
	/// 暗害
	/// </summary>
	AddInjuryAndPoison = 21,
	/// <summary>
	/// 纠缠
	/// </summary>
	ReduceHitAndAvoid = 22,
	/// <summary>
	/// 扰乱
	/// </summary>
	InterruptOtherAction = 23,
	/// <summary>
	/// 散气
	/// </summary>
	ReduceNeiliAllocation = 24,
	/// <summary>
	/// 驭使
	/// </summary>
	AnimalEffect = 25,
	/// <summary>
	/// 甲阵
	/// </summary>
	GearMateA = 26,
	/// <summary>
	/// 乙阵
	/// </summary>
	GearMateB = 27,
	/// <summary>
	/// 丙阵
	/// </summary>
	GearMateC = 28,
	/// <summary>
	/// 解封
	/// </summary>
	AddUnlockAttackValue = 29,
	/// <summary>
	/// 替身
	/// </summary>
	TransferManyMark = 30,
	/// <summary>
	/// 修理
	/// </summary>
	RepairItem = 31,
	/// <summary>
	/// 法道
	/// </summary>
	VitalDemonA = 32,
	/// <summary>
	/// 法天
	/// </summary>
	VitalDemonB = 33,
	/// <summary>
	/// 法地
	/// </summary>
	VitalDemonC = 34,
	/// <summary>
	/// 丁阵
	/// </summary>
	GearMateD = 35,
	/// <summary>
	/// 戊阵
	/// </summary>
	GearMateE = 36,
	/// <summary>
	/// 己阵
	/// </summary>
	GearMateF = 37,
	/// <summary>
	/// 让手
	/// </summary>
	InterruptEnemySkill = 38,
	/// <summary>
	/// 养剑
	/// </summary>
	CriticalBonus = 39,
	/// <summary>
	/// 煌甲
	/// </summary>
	NormalAttackAddFatal = 40,
	/// <summary>
	/// 勇烈
	/// </summary>
	FightBackBonus = 41,
	/// <summary>
	/// 反戈
	/// </summary>
	DefendFlawAndAcupoint = 42,
	/// <summary>
	/// 百战
	/// </summary>
	BounceBonus = 43,
	/// <summary>
	/// 王血
	/// </summary>
	FatalBonus = 44,
	/// <summary>
	/// 幻形
	/// </summary>
	RecoverAttack = 45,
	/// <summary>
	/// 极势
	/// </summary>
	NormalAttackAddMind = 46,
	/// <summary>
	/// 威严
	/// </summary>
	MinorAttributeRandomToZero = 47,
	/// <summary>
	/// 摄魂
	/// </summary>
	IntoUpheaval = 48,
	/// <summary>
	/// 驰骋
	/// </summary>
	ExchangeMobility = 49,
	/// <summary>
	/// 赤煞
	/// </summary>
	AddInjuryOnEmpty = 50,
	/// <summary>
	/// 无相
	/// </summary>
	AddFlawOrAcupoint = 51,
	/// <summary>
	/// 异血
	/// </summary>
	MergeFatalToDie = 52,
	/// <summary>
	/// 净天
	/// </summary>
	RemoveState = 53,
	/// <summary>
	/// 焚莲
	/// </summary>
	AbsorbNeiliAllocation = 54,
	/// <summary>
	/// 毒锥
	/// </summary>
	AttackSpecialPoison = 55,
	/// <summary>
	/// 逆命
	/// </summary>
	FightSpecialGrow = 56,
	/// <summary>
	/// 舍身
	/// </summary>
	AddPowerUntilCast = 57,
	Count = 58
}
