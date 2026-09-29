using GameData.Domains.LifeRecord.GeneralRecord;

namespace GameData.Domains.Organization.SettlementPrisonRecord;

public class SettlementPrisonRecordRenderInfo : RenderInfo
{
	public readonly int Date;

	public readonly short SettlementId;

	public SettlementPrisonRecordRenderInfo(short recordType, string text, int date, short settlementId)
		: base(recordType, text)
	{
		Date = date;
		SettlementId = settlementId;
	}
}
