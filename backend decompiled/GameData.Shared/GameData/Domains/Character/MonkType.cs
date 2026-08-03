namespace GameData.Domains.Character;

/// <summary>
/// 出家类型
/// </summary>
public static class MonkType
{
	/// <summary>
	/// 未出家
	/// </summary>
	public const byte None = 0;

	/// <summary>
	/// (掩码) 是否门派人士.
	/// 门派出家会赐法号, 非门派出家无法号.
	/// </summary>
	public const byte MaskSect = 128;

	/// <summary>
	/// (掩码) 道士
	/// </summary>
	public const byte MaskTaoist = 1;

	/// <summary>
	/// (掩码) 和尚
	/// </summary>
	public const byte MaskBuddhist = 2;

	/// <summary>
	/// 门派道人
	/// </summary>
	public const byte SectTaoist = 129;

	/// <summary>
	/// 非门派道人
	/// </summary>
	public const byte NonSectTaoist = 1;

	/// <summary>
	/// 门派和尚
	/// </summary>
	public const byte SectBuddhist = 130;

	/// <summary>
	/// 非门派和尚
	/// </summary>
	public const byte NonSectBuddhist = 2;
}
