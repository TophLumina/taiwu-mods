namespace GameData.Domains.TaiwuEvent.Enum;

/// <summary>
/// 杀害类型. 此前用于EventHelper事件接口的参数, 后续通过指令实现，不应再增加新的引用, 而是通过配置表
/// <see cref="T:Config.CharacterDeathType" />
/// </summary>
public enum EKillCharacterType
{
	/// <summary>
	/// 公开处决
	/// </summary>
	KillInPublic,
	/// <summary>
	/// 秘密杀害
	/// </summary>
	KillInPrivate
}
