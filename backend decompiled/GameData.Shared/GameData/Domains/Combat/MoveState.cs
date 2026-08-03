using GameData.Serializer;

namespace GameData.Domains.Combat;

/// <summary>
/// 移动状态
/// </summary>
[SerializeAs(typeof(byte))]
public enum MoveState
{
	/// <summary>
	/// 静止
	/// </summary>
	Stay,
	/// <summary>
	/// 前进
	/// </summary>
	Forward,
	/// <summary>
	/// 后退
	/// </summary>
	Backward
}
