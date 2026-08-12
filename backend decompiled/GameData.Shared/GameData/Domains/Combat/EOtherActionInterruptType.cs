using GameData.Serializer;

namespace GameData.Domains.Combat;

/// <summary>
/// 其它行为中断类型
/// </summary>
[SerializeAs(typeof(byte))]
public enum EOtherActionInterruptType
{
	/// <summary>
	/// 允许进行中断
	/// </summary>
	Allow,
	/// <summary>
	/// 隐藏中断按钮
	/// </summary>
	HideClose,
	/// <summary>
	/// 由特殊效果强制引发的逃跑，无法中断
	/// </summary>
	ForceFlee
}
