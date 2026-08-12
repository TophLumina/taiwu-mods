using GameData.Domains.LifeRecord.GeneralRecord;

namespace GameData.Domains.Map.TeammateBubble;

/// <summary>
/// 同道气泡文本渲染信息 (仅供前端使用)
/// </summary>
public class TeammateBubbleRenderInfo : RenderInfo
{
	/// <summary>
	/// 出战同道索引
	/// </summary>
	public readonly int Index;

	/// <summary>
	/// 同道气泡文本渲染信息
	/// </summary>
	/// <param name="recordType"></param>
	/// <param name="text"></param>
	/// <param name="index"></param>
	public TeammateBubbleRenderInfo(short recordType, string text, int index)
		: base(recordType, text)
	{
		Index = index;
	}
}
