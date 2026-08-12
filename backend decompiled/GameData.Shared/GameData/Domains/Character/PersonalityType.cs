namespace GameData.Domains.Character;

/// <summary>
/// 角色的性格属性类型
/// </summary>
public static class PersonalityType
{
	/// <summary>
	/// 无效值
	/// </summary>
	public const sbyte Invalid = -1;

	/// <summary>
	/// 冷静 (金)
	/// </summary>
	public const sbyte Calm = 0;

	/// <summary>
	/// 聪颖 (水)
	/// </summary>
	public const sbyte Clever = 1;

	/// <summary>
	/// 热情 (木)
	/// </summary>
	public const sbyte Enthusiastic = 2;

	/// <summary>
	/// 勇壮 (火)
	/// </summary>
	public const sbyte Brave = 3;

	/// <summary>
	/// 坚毅 (土)
	/// </summary>
	public const sbyte Firm = 4;

	/// <summary>
	/// 福缘 (阳)
	/// </summary>
	public const sbyte Lucky = 5;

	/// <summary>
	/// 合道 (阴)
	/// </summary>
	public const sbyte Perceptive = 6;

	/// <summary>
	/// 总个数
	/// </summary>
	public const int Count = 7;

	/// <summary>
	/// 五行克制 (索引克制值)
	/// </summary>
	public static readonly sbyte[] Countering = new sbyte[5] { 2, 3, 4, 0, 1 };

	/// <summary>
	/// 五行被克 (索引被值克制)
	/// </summary>
	public static readonly sbyte[] Countered = new sbyte[5] { 3, 4, 0, 1, 2 };

	/// <summary>
	/// 五行化生 (索引化生值)
	/// </summary>
	public static readonly sbyte[] Producing = new sbyte[5] { 1, 2, 3, 4, 0 };

	/// <summary>
	/// 五行被生 (索引被值化生)
	/// </summary>
	public static readonly sbyte[] Produced = new sbyte[5] { 4, 0, 1, 2, 3 };
}
