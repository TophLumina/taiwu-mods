namespace GameData.Domains.Character;

/// <summary>
/// 内力五行转移类型
/// </summary>
public static class NeiliProportionTransferType
{
	/// <summary>
	/// 从克制自己的转移到自己
	/// </summary>
	public const sbyte FromCountering = 0;

	/// <summary>
	/// 从被自己克制的转移到自己
	/// </summary>
	public const sbyte FromCountered = 1;

	/// <summary>
	/// 从化生自己的转移到自己
	/// </summary>
	public const sbyte FromProducing = 2;

	/// <summary>
	/// 从被自己化生的转移到自己
	/// </summary>
	public const sbyte FromProduced = 3;
}
