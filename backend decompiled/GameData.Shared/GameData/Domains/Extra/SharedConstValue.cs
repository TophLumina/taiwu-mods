namespace GameData.Domains.Extra;

public class SharedConstValue
{
	/// <summary>
	/// 野兽驯服度上限
	/// </summary>
	public const int MaxTamePoint = 100;

	/// <summary>
	/// 野兽喜爱的食物的驯服度系数
	/// </summary>
	public const float LoveFoodTamePointFactor = 1.5f;

	/// <summary>
	/// 野兽讨厌的食物的驯服度系数
	/// </summary>
	public const float HateFoodTamePointFactor = 0.5f;

	/// <summary>
	/// 投入引子后引子品级-1，0，+1的产物增加的权重
	/// </summary>
	public static int[] MaterialWeightToArtisanOrder => GlobalConfig.Instance.MaterialWeightToArtisanOrder;

	/// <summary>
	/// 制造物品的三个级别的造诣倍率要求
	/// </summary>
	public static int[] MakeItemStageAttainmentFactor => GlobalConfig.Instance.MakeItemStageAttainmentFactor;

	/// <summary>
	/// 初始产物的三个级别的权重
	/// </summary>
	public static int[] InitialProductionWeight => GlobalConfig.Instance.InitialProductionWeight;

	/// <summary>
	/// 工作者的造诣加成
	/// </summary>
	public static int AddOnAttainmentOfWorker => GlobalConfig.Instance.AddOnAttainmentOfWorker;

	/// <summary>
	/// 领袖的造诣加成
	/// </summary>
	public static int AddOnAttainmentOfLeader => GlobalConfig.Instance.AddOnAttainmentOfLeader;

	/// <summary>
	/// 工作者造诣除数
	/// </summary>
	public static int WorkerAttainmentDivider => GlobalConfig.Instance.WorkerAttainmentDivider;

	/// <summary>
	/// 匠人的造诣乘数
	/// </summary>
	public static int ArtisanAttainmentFactor1 => GlobalConfig.Instance.ArtisanAttainmentFactor1;

	/// <summary>
	/// 匠人的安定值/文化值乘数
	/// </summary>
	public static int ArtisanAttainmentFactor2 => GlobalConfig.Instance.ArtisanAttainmentFactor2;

	/// <summary>
	/// 每月增加的制造进度基础值
	/// </summary>
	public static int MonthlyOrderProgressBase => GlobalConfig.Instance.MonthlyOrderProgressBase;

	/// <summary>
	/// 每月增加的制造进度基础值倍数
	/// </summary>
	public static int MonthlyOrderProgressFactor => GlobalConfig.Instance.MonthlyOrderProgressFactor;

	/// <summary>
	/// 茶酒订单的造诣需求
	/// </summary>
	public static int[] TeaWineArtisanOrderAttainmentRequirement => GlobalConfig.Instance.TeaWineArtisanOrderAttainmentRequirement;

	/// <summary>
	/// 订单价格百分比
	/// </summary>
	public static int ArtisanOrderPricePercent => GlobalConfig.Instance.ArtisanOrderPricePercent;

	/// <summary>
	/// 截取订单价格倍数
	/// </summary>
	public static int ArtisanOrderInterceptPricePercent => GlobalConfig.Instance.ArtisanOrderInterceptPricePercent;

	/// <summary>
	/// 截取订单且较艺获胜价格额外百分比
	/// </summary>
	public static int ArtisanOrderInterceptDebatePricePercent => GlobalConfig.Instance.ArtisanOrderInterceptDebatePricePercent;
}
