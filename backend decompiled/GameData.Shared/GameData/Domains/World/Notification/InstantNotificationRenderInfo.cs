using GameData.Domains.LifeRecord.GeneralRecord;

namespace GameData.Domains.World.Notification;

public class InstantNotificationRenderInfo : RenderInfo
{
	public readonly int Date;

	public readonly string SimpleText;

	public InstantNotificationRenderInfo(short recordType, string text, string simpleText, int date)
		: base(recordType, text)
	{
		SimpleText = simpleText;
		Date = date;
	}
}
