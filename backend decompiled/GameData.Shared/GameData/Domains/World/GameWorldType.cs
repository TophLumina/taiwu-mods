namespace GameData.Domains.World;

/// <summary>
/// 游戏世界类型
/// </summary>
public class GameWorldType
{
	/// <summary>
	/// 尚未载入世界
	/// </summary>
	public const sbyte NotInWorld = 0;

	/// <summary>
	/// 普通游戏世界
	/// </summary>
	public const sbyte NormalWorld = 1;

	/// <summary>
	/// 演武章节世界
	/// </summary>
	public const sbyte TutorialChapter = 2;

	/// <summary>
	/// 游戏内引导世界
	/// </summary>
	public const sbyte InGameGuideWorld = 3;
}
