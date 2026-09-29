namespace GameData.Domains.Mod;

public static class ModSource
{
	public const byte External = 0;

	public const byte Steam = 1;

	public const byte DLC = 2;

	public static string GetModSourceName(byte modSource)
	{
		return modSource switch
		{
			1 => "Steam", 
			2 => "DLC", 
			_ => LocalStringManager.Get(LanguageKey.LK_Unknown), 
		};
	}
}
