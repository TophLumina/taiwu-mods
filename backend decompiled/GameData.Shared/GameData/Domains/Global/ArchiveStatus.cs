namespace GameData.Domains.Global;

/// <summary>
/// 档案状态
/// </summary>
public static class ArchiveStatus
{
	/// <summary>
	/// 状态未知
	/// </summary>
	public const sbyte Unknown = -1;

	/// <summary>
	/// 没有档案
	/// </summary>
	public const sbyte Empty = 0;

	/// <summary>
	/// 档案完好, 可以加载
	/// </summary>
	public const sbyte Good = 1;

	/// <summary>
	/// 档案损坏, 无法加载
	/// </summary>
	public const sbyte Broken = 2;
}
