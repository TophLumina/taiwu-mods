using GameData.Serializer;

namespace GameData.Domains.World;

/// <summary>
/// 引导章节状态
/// </summary>
[SerializeAs(typeof(sbyte))]
public enum EGuidingChapterState
{
	/// <summary>
	/// 新触发
	/// </summary>
	NewTriggered,
	/// <summary>
	/// 已读
	/// </summary>
	AlreadyRead,
	/// <summary>
	/// 完成
	/// </summary>
	Finished
}
