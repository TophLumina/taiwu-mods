using GameData.Serializer;

namespace GameData.Domains.Adventure;

/// <summary>
/// 奇遇值类型
/// </summary>
[SerializeAs(typeof(byte))]
public enum EAdventureParameterValueType
{
	/// <summary>
	/// 整数
	/// </summary>
	Int,
	/// <summary>
	/// 当前/上限值
	/// </summary>
	Progress,
	/// <summary>
	/// 布尔
	/// </summary>
	Bool,
	/// <summary>
	/// 索引
	/// </summary>
	Index,
	/// <summary>
	/// 任务
	/// </summary>
	Task,
	/// <summary>
	/// 字符串
	/// </summary>
	String
}
