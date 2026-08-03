/// <summary>
/// MapBlock -&gt; Type
/// </summary>
public enum EMapBlockType
{
	/// <summary>
	/// 非法值
	/// </summary>
	Invalid = -1,
	/// <summary>
	/// 主城
	/// </summary>
	City,
	/// <summary>
	/// 门派
	/// </summary>
	Sect,
	/// <summary>
	/// 城镇村寨
	/// </summary>
	Town,
	/// <summary>
	/// 驿站
	/// </summary>
	Station,
	/// <summary>
	/// 开化地形
	/// </summary>
	Developed,
	/// <summary>
	/// 普通地形
	/// </summary>
	Normal,
	/// <summary>
	/// 野外地形
	/// </summary>
	Wild,
	/// <summary>
	/// 恶劣地形
	/// </summary>
	Bad,
	/// <summary>
	/// 风景名胜
	/// </summary>
	scenery,
	Count
}
