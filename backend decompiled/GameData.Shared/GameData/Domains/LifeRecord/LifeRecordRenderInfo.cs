using GameData.Domains.LifeRecord.GeneralRecord;

namespace GameData.Domains.LifeRecord;

public class LifeRecordRenderInfo : RenderInfo
{
	public readonly int Date;

	public int Score = 50;

	public LifeRecordRenderInfo(short recordType, string text, int date)
		: base(recordType, text)
	{
		Date = date;
	}
}
