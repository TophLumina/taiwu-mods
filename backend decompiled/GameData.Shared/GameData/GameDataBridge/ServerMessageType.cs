namespace GameData.GameDataBridge;

public static class ServerMessageType
{
	public const byte GameModuleInitialized = 0;

	public const byte Notifications = 1;

	public const byte ErrorMessages = 2;

	public const byte WarningMessages = 3;

	public const byte Disconnect = 4;
}
