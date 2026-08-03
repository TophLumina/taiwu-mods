namespace GameData.Domains.Information;

/// <summary>
/// 秘闻与太吾相关的通知类型
/// </summary>
public static class SecretInformationActorBroadcastType
{
	/// <summary>
	/// 与太吾相关
	/// </summary>
	public const byte RelatedToTaiwu = 0;

	/// <summary>
	/// 经由太吾传播
	/// </summary>
	public const byte DisseminatedByTaiwu = 1;

	/// <summary>
	/// 与太吾无关
	/// </summary>
	public const byte None = 2;
}
