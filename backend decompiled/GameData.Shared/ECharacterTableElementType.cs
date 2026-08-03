/// <summary>
/// CharacterTableElement -&gt; Type
/// </summary>
public enum ECharacterTableElementType
{
	/// <summary>
	/// 非法值
	/// </summary>
	Invalid = -1,
	/// <summary>
	/// 文本
	/// </summary>
	Text,
	/// <summary>
	/// 空格
	/// </summary>
	Empty,
	/// <summary>
	/// 文本和图标
	/// </summary>
	TextWithIcon,
	/// <summary>
	/// 图文混排
	/// </summary>
	TextWithSprite,
	/// <summary>
	/// 角色
	/// </summary>
	Avatar,
	/// <summary>
	/// 特性
	/// </summary>
	Feature,
	/// <summary>
	/// 指令
	/// </summary>
	Command,
	Count
}
