using GameData.Utilities;

namespace GameData;

/// <summary>
/// 外部数据桥
/// </summary>
public class ExternalDataBridge
{
	internal static IGameContext Context;

	public static void Initialize(IGameContext context)
	{
		AdaptableLog.Info("ExternalDataBridge initialized.");
		Context = context;
	}
}
