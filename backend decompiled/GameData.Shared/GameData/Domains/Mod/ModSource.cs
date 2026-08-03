namespace GameData.Domains.Mod;

/// <summary>
/// Mod 来源
/// </summary>
public static class ModSource
{
	/// <summary>
	/// 外部 Mod，不与任何平台绑定
	/// </summary>
	public const byte External = 0;

	/// <summary>
	/// Steam Workshop 上的 mod
	/// </summary>
	public const byte Steam = 1;

	/// <summary>
	/// DLC
	/// </summary>
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
