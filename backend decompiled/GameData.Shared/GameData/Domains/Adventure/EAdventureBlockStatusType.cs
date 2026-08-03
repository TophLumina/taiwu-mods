using System;

namespace GameData.Domains.Adventure;

/// <summary>
/// 奇遇格状态缓存
/// </summary>
[Flags]
public enum EAdventureBlockStatusType
{
	/// <summary>
	/// 无状态
	/// </summary>
	None = 0,
	/// <summary>
	/// 可作为入口
	/// </summary>
	In = 1,
	/// <summary>
	/// 可作为出口
	/// </summary>
	Out = 2,
	/// <summary>
	/// 可通行
	/// </summary>
	Passable = 4
}
