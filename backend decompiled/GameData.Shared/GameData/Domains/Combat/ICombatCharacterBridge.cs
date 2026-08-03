using GameData.Domains.Character;

namespace GameData.Domains.Combat;

/// <summary>
/// 战斗角色数据接口
/// </summary>
public interface ICombatCharacterBridge
{
	/// <summary>
	/// 获取角色 ID
	/// </summary>
	int GetId();

	/// <summary>
	/// 获取架势值
	/// </summary>
	int GetStanceValue();

	/// <summary>
	/// 获取提气值
	/// </summary>
	int GetBreathValue();

	/// <summary>
	/// 获取脚力值
	/// </summary>
	int GetMobilityValue();

	/// <summary>
	/// 获取蓄式数
	/// </summary>
	byte GetTrickCount(sbyte trickType);

	/// <summary>
	/// 获取蛊引数
	/// </summary>
	short GetWugCount();

	/// <summary>
	/// 获取真气值
	/// </summary>
	NeiliAllocation GetNeiliAllocation();

	/// <summary>
	/// 获取初始真气值
	/// </summary>
	NeiliAllocation GetOriginNeiliAllocation();

	/// <summary>
	/// 获取内息紊乱
	/// </summary>
	short GetDisorderOfQi();

	/// <summary>
	/// 获取旧内息紊乱
	/// </summary>
	short GetOldDisorderOfQi();

	/// <summary>
	/// 获取旧毒
	/// </summary>
	ref PoisonInts GetOldPoison();

	/// <summary>
	/// 获取旧伤
	/// </summary>
	/// <returns></returns>
	Injuries GetOldInjuries();

	/// <summary>
	/// 健康类型
	/// </summary>
	EHealthType GetHealthType();
}
