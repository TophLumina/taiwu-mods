namespace GameData.Domains.Character.Ai;

/// <summary>
/// 优先行为类型
/// </summary>
public static class PrioritizedActionType
{
	/// <summary>
	/// 行动 - 拜师学艺
	/// </summary>
	public const sbyte JoinSect = 0;

	/// <summary>
	/// 行动 - 受邀赴约
	/// </summary>
	public const sbyte Appointment = 1;

	/// <summary>
	/// 行动 - 保护亲友
	/// </summary>
	public const sbyte ProtectFriendOrFamily = 2;

	/// <summary>
	/// 行动 - 解救亲友
	/// </summary>
	public const sbyte RescueFriendOrFamily = 3;

	/// <summary>
	/// 行动 - 祭拜故人
	/// </summary>
	public const sbyte Mourn = 4;

	/// <summary>
	/// 行动 - 探访亲友
	/// </summary>
	public const sbyte VisitFriendOrFamily = 5;

	/// <summary>
	/// 行动 - 寻找宝藏
	/// </summary>
	public const sbyte FindTreasure = 6;

	/// <summary>
	/// 行动 - 天材地宝
	/// </summary>
	public const sbyte FindSpecialMaterial = 7;

	/// <summary>
	/// 寻仇报复
	/// </summary>
	public const sbyte TakeRevenge = 8;

	/// <summary>
	/// 优先行为类型总数（不包含奇遇）
	/// </summary>
	public const sbyte Count = 9;
}
