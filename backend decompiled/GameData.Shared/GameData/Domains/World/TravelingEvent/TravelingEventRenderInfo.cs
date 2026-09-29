using GameData.Domains.LifeRecord.GeneralRecord;

namespace GameData.Domains.World.TravelingEvent;

public class TravelingEventRenderInfo : RenderInfo
{
	public int Offset;

	public string EventGuid;

	public TravelingEventRenderInfo(short recordType, string text, int offset)
		: base(recordType, text)
	{
		Offset = offset;
		EventGuid = string.Empty;
	}
}
