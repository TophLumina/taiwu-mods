namespace GameData.Domains.Extra;

public class SharedConstValue
{
	public const int MaxTamePoint = 100;

	public const float LoveFoodTamePointFactor = 1.5f;

	public const float HateFoodTamePointFactor = 0.5f;

	public static int[] MaterialWeightToArtisanOrder => GlobalConfig.Instance.MaterialWeightToArtisanOrder;

	public static int[] MakeItemStageAttainmentFactor => GlobalConfig.Instance.MakeItemStageAttainmentFactor;

	public static int[] InitialProductionWeight => GlobalConfig.Instance.InitialProductionWeight;

	public static int AddOnAttainmentOfWorker => GlobalConfig.Instance.AddOnAttainmentOfWorker;

	public static int AddOnAttainmentOfLeader => GlobalConfig.Instance.AddOnAttainmentOfLeader;

	public static int WorkerAttainmentDivider => GlobalConfig.Instance.WorkerAttainmentDivider;

	public static int ArtisanAttainmentFactor1 => GlobalConfig.Instance.ArtisanAttainmentFactor1;

	public static int ArtisanAttainmentFactor2 => GlobalConfig.Instance.ArtisanAttainmentFactor2;

	public static int MonthlyOrderProgressBase => GlobalConfig.Instance.MonthlyOrderProgressBase;

	public static int MonthlyOrderProgressFactor => GlobalConfig.Instance.MonthlyOrderProgressFactor;

	public static int[] TeaWineArtisanOrderAttainmentRequirement => GlobalConfig.Instance.TeaWineArtisanOrderAttainmentRequirement;

	public static int ArtisanOrderPricePercent => GlobalConfig.Instance.ArtisanOrderPricePercent;

	public static int ArtisanOrderInterceptPricePercent => GlobalConfig.Instance.ArtisanOrderInterceptPricePercent;

	public static int ArtisanOrderInterceptDebatePricePercent => GlobalConfig.Instance.ArtisanOrderInterceptDebatePricePercent;
}
