using GameData.Domains.LifeRecord.GeneralRecord;

namespace GameData.Domains.Building.SamsaraPlatformRecord;

public class SamsaraPlatformRecordRenderInfo : RenderInfo
{
	public readonly int Date;

	public SamsaraPlatformRecordRenderInfo(short recordType, string text, int date)
		: base(recordType, text)
	{
		Date = date;
	}
}
