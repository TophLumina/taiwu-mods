namespace GameData.Domains.Building;

/// <summary>
/// 夺舍结果
/// </summary>
public static class PossessionResult
{
	/// <summary>
	/// 成功换魂
	/// </summary>
	public static byte Success = 0;

	/// <summary>
	/// 夺舍者Id无效
	/// </summary>
	public static byte InvalidSoulCharId = 1;

	/// <summary>
	/// 被夺舍者Id无效
	/// </summary>
	public static byte InvalidBodyCharId = 2;

	/// <summary>
	/// 被夺舍者不是太吾的俘虏
	/// </summary>
	public static byte BodyCharNotKidnappedByTaiwu = 3;

	/// <summary>
	/// 夺舍者不符合夺舍的要求
	/// </summary>
	public static byte SoulCharUnavailable = 4;
}
