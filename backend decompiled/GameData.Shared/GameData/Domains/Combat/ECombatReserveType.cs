namespace GameData.Domains.Combat;

/// <summary>
/// 战斗预约类型
/// </summary>
public enum ECombatReserveType : sbyte
{
	/// <summary>
	/// 无预约
	/// </summary>
	Invalid,
	/// <summary>
	/// 功法
	/// </summary>
	Skill,
	/// <summary>
	/// 变招
	/// </summary>
	ChangeTrick,
	/// <summary>
	/// 切换武器
	/// </summary>
	ChangeWeapon,
	/// <summary>
	/// 解封攻击
	/// </summary>
	UnlockAttack,
	/// <summary>
	/// 使用道具
	/// </summary>
	UseItem,
	/// <summary>
	/// 其它行为
	/// </summary>
	OtherAction,
	/// <summary>
	/// 同道指令
	/// </summary>
	TeammateCommand
}
