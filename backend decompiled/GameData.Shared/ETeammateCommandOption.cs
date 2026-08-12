/// <summary>
/// TeammateCommand -&gt; Option
/// </summary>
public enum ETeammateCommandOption
{
	/// <summary>
	/// 不可开关
	/// </summary>
	Invalid = -1,
	/// <summary>
	/// 出战
	/// </summary>
	Fight,
	/// <summary>
	/// 催发
	/// </summary>
	AccelerateCast,
	/// <summary>
	/// 迅进
	/// </summary>
	Push,
	/// <summary>
	/// 拉回
	/// </summary>
	Pull,
	/// <summary>
	/// 攻击
	/// </summary>
	Attack,
	/// <summary>
	/// 防御
	/// </summary>
	Defend,
	/// <summary>
	/// 疗伤
	/// </summary>
	HealInjury,
	/// <summary>
	/// 驱毒
	/// </summary>
	HealPoison,
	/// <summary>
	/// 还护
	/// </summary>
	HealFlaw,
	/// <summary>
	/// 解穴
	/// </summary>
	HealAcupoint,
	/// <summary>
	/// 掠阵
	/// </summary>
	AddHit,
	/// <summary>
	/// 警示
	/// </summary>
	AddAvoid,
	/// <summary>
	/// 真气
	/// </summary>
	TransferNeiliAllocation,
	/// <summary>
	/// 替命
	/// </summary>
	TransferInjury,
	/// <summary>
	/// 牵制
	/// </summary>
	StopEnemy,
	/// <summary>
	/// 摧破
	/// </summary>
	AttackSkill,
	/// <summary>
	/// 甲阵
	/// </summary>
	GearMateA,
	/// <summary>
	/// 乙阵
	/// </summary>
	GearMateB,
	/// <summary>
	/// 丙阵
	/// </summary>
	GearMateC,
	/// <summary>
	/// 解封
	/// </summary>
	AddUnlockAttackValue,
	/// <summary>
	/// 替身
	/// </summary>
	TransferManyMark,
	/// <summary>
	/// 修理
	/// </summary>
	RepairItem,
	/// <summary>
	/// 法道
	/// </summary>
	BanAttackSkill,
	/// <summary>
	/// 法天
	/// </summary>
	BanDefendSkill,
	/// <summary>
	/// 法地
	/// </summary>
	BanAgileSkill,
	Count
}
