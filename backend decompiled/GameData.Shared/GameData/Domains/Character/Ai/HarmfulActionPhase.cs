namespace GameData.Domains.Character.Ai;

/// <summary>
/// 危害性行为的阶段
/// </summary>
public static class HarmfulActionPhase
{
	/// <summary>
	/// 辨认目标
	/// </summary>
	public const sbyte RecognizeTarget = 0;

	/// <summary>
	/// 隐藏潜伏
	/// </summary>
	public const sbyte StayHidden = 1;

	/// <summary>
	/// 判断时机
	/// </summary>
	public const sbyte WaitForGoodTiming = 2;

	/// <summary>
	/// 果断行动
	/// </summary>
	public const sbyte TakeAction = 3;

	/// <summary>
	/// 顺利逃脱
	/// </summary>
	public const sbyte OnTheWayOut = 4;

	/// <summary>
	/// 总数
	/// </summary>
	public const sbyte Count = 5;

	/// <summary>
	/// 行动对应的七元赋性
	/// </summary>
	public static readonly sbyte[] ToPersonalityType = new sbyte[5] { 1, 4, 0, 2, 3 };
}
