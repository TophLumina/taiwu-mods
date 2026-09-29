using GameData.Domains.LifeRecord.GeneralRecord;

namespace GameData.Domains.World.MonthlyEvent;

public class MonthlyEventRenderInfo : RenderInfo
{
	public int Offset;

	public string EventGuid;

	public MonthlyEventRenderInfo(short recordType, string text, int offset)
		: base(recordType, text)
	{
		Offset = offset;
		EventGuid = string.Empty;
	}
}
