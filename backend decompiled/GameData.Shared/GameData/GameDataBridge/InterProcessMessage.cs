namespace GameData.GameDataBridge;

public static class InterProcessMessage
{
	public const int HeaderSize = 5;

	public const int ErrorMessageMaxSize = 65000;

	public const int WarningMessageMaxSize = 65000;

	public const int ConnectionTimeout = 300000;

	public const int SocketPort = 51827;
}
