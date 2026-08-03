namespace GameData.Domains.Character.AvatarSystem;

/// <summary>
/// 可生长的形象部件
/// </summary>
public static class AvatarGrowableElementType
{
	/// <summary>
	/// 无效值
	/// </summary>
	public const sbyte Invalid = -1;

	/// <summary>
	/// 头发
	/// </summary>
	public const sbyte Hair = 0;

	/// <summary>
	/// 上嘴唇胡须
	/// </summary>
	public const sbyte Beard1 = 1;

	/// <summary>
	/// 下嘴唇胡须
	/// </summary>
	public const sbyte Beard2 = 2;

	/// <summary>
	/// 抬头纹
	/// </summary>
	public const sbyte Wrinkle1 = 3;

	/// <summary>
	/// 表情纹
	/// </summary>
	public const sbyte Wrinkle2 = 4;

	/// <summary>
	/// 眼袋纹
	/// </summary>
	public const sbyte Wrinkle3 = 5;

	/// <summary>
	/// 眉毛
	/// </summary>
	public const sbyte Eyebrow = 6;

	/// <summary>
	/// 可生长的形象部件个数
	/// </summary>
	public const int Count = 7;
}
