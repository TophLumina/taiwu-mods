using System;

namespace GameData.Domains.TaiwuEvent.EventOption;

[Obsolete("Use Config.EventOptionConsumeType.DefKey instead.")]
public class OptionConsumeType
{
	public const sbyte Food = 0;

	public const sbyte Wood = 1;

	public const sbyte Metal = 2;

	public const sbyte Jade = 3;

	public const sbyte Fabric = 4;

	public const sbyte Herb = 5;

	public const sbyte Money = 6;

	public const sbyte Authority = 7;

	public const int MovePoint = 8;

	public const sbyte SpiritualDebt = 9;

	public const sbyte SpiritualDebtInCurrentArea = 10;

	public const int Count = 11;
}
