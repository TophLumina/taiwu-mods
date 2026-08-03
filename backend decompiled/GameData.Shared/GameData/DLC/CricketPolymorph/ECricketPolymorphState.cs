using System;
using GameData.Serializer;

namespace GameData.DLC.CricketPolymorph;

/// <summary>
/// 促织化形状态
/// </summary>
[SerializeAs(typeof(byte))]
[Flags]
public enum ECricketPolymorphState
{
	/// <summary>
	/// 从未化形过
	/// </summary>
	None = 0,
	/// <summary>
	/// 已化形为男角色
	/// </summary>
	Male = 1,
	/// <summary>
	/// 已化形为女角色
	/// </summary>
	Female = 2,
	/// <summary>
	/// 已化形为任意角色
	/// </summary>
	Alive = 3,
	/// <summary>
	/// 等待返灵
	/// </summary>
	WaitForReturn = 4,
	/// <summary>
	/// 已返灵
	/// </summary>
	Returned = 8,
	/// <summary>
	/// 已死亡
	/// </summary>
	Dead = 0x10
}
