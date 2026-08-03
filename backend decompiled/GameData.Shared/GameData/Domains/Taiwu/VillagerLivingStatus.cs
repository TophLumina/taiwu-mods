namespace GameData.Domains.Taiwu;

/// <summary>
/// 太吾村民的居住状态
/// </summary>
public static class VillagerLivingStatus
{
	/// <summary>
	/// 无家可归
	/// </summary>
	public const byte Homeless = 0;

	/// <summary>
	/// 同道
	/// </summary>
	public const byte InTaiwuGroup = 1;

	/// <summary>
	/// 住在居所
	/// </summary>
	public const byte LivingInNormalResidence = 2;

	/// <summary>
	/// 入魔出走
	/// </summary>
	public const byte XiangshuInfected = 3;
}
