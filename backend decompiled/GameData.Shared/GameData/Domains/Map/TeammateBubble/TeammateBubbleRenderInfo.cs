using GameData.Domains.LifeRecord.GeneralRecord;

namespace GameData.Domains.Map.TeammateBubble;

public class TeammateBubbleRenderInfo : RenderInfo
{
	public readonly int Index;

	public TeammateBubbleRenderInfo(short recordType, string text, int index)
		: base(recordType, text)
	{
		Index = index;
	}
}
