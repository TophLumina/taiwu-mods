namespace GameData.Domains.Extra;

/// <summary>
/// 挖掘相关常量定义
/// </summary>
public class TreasureConstants
{
	/// <summary>
	/// 挖掘消耗的天数
	/// </summary>
	public const int CostTime = 3;

	/// <summary>
	/// 挖掘心材成功率
	/// </summary>
	public const int MaterialSuccessPercent = 20;

	/// <summary>
	/// 挖掘心材失败补偿成功率
	/// </summary>
	public const int MaterialSuccessAmendPercent = 10;

	/// <summary>
	/// 挖掘心材失败资源获取量最小值
	/// </summary>
	public const int MaterialFailedResourceMin = 100;

	/// <summary>
	/// 挖掘心材失败资源获取量最大值
	/// </summary>
	public const int MaterialFailedResourceMax = 300;
}
