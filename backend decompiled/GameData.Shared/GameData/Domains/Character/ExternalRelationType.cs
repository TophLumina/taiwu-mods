namespace GameData.Domains.Character;

/// <summary>
/// 角色的外部关联类型
/// </summary>
public static class ExternalRelationType
{
	/// <summary>
	/// 在太吾村有工作 (采集, 建造, 驻店等)
	/// </summary>
	public const ulong HasWorkInTaiwuVillage = 1uL;

	/// <summary>
	/// 劫持了其他角色
	/// </summary>
	public const ulong KidnappedOthers = 2uL;

	/// <summary>
	/// 被拉到奇遇
	/// </summary>
	public const ulong CalledByAdventure = 4uL;

	/// <summary>
	/// 被石屋关押
	/// </summary>
	public const ulong CapturedInStoneRoom = 8uL;

	/// <summary>
	/// 被事件隐藏
	/// </summary>
	public const ulong HiddenByEvent = 16uL;

	/// <summary>
	/// 被门派监牢关押
	/// </summary>
	public const ulong CapturedInSettlementPrison = 32uL;

	/// <summary>
	/// 角色被固定位置
	/// </summary>
	public const ulong DisableAiMove = 64uL;

	/// <summary>
	/// 返灵的促织人物
	/// </summary>
	public const ulong CricketPolymorph = 128uL;

	/// <summary>
	/// 隐藏角色相关状态
	/// </summary>
	public const ulong HideCharacterStates = 188uL;
}
