using GameData.Domains.LifeRecord.GeneralRecord;

namespace GameData.Domains.Organization.SettlementTreasuryRecord;

public class SettlementTreasuryRecordRenderInfo : RenderInfo
{
	public readonly int Date;

	public readonly short SettlementId;

	public SettlementTreasuryRecordRenderInfo(short recordType, string text, int date, short settlementId)
		: base(recordType, text)
	{
		Date = date;
		SettlementId = settlementId;
	}
}
