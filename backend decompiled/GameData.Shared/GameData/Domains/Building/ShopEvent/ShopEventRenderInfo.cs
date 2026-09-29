using GameData.Domains.LifeRecord.GeneralRecord;

namespace GameData.Domains.Building.ShopEvent;

public class ShopEventRenderInfo : RenderInfo
{
	public readonly int Date;

	public ShopEventRenderInfo(short recordType, string text, int date)
		: base(recordType, text)
	{
		Date = date;
	}
}
