using GameData.Utilities;

namespace GameData;

public class ExternalDataBridge
{
	internal static IGameContext Context;

	public static void Initialize(IGameContext context)
	{
		AdaptableLog.Info("ExternalDataBridge initialized.");
		Context = context;
	}
}
