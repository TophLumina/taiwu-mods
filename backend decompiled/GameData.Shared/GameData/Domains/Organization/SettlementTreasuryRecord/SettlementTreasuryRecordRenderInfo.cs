using GameData.Domains.LifeRecord.GeneralRecord;

namespace GameData.Domains.Organization.SettlementTreasuryRecord;

/// <summary>
/// 库房记录文本渲染信息 (仅供前端使用)
/// </summary>
public class SettlementTreasuryRecordRenderInfo : RenderInfo
{
	/// <summary>
	/// 发生日期
	/// </summary>
	public readonly int Date;

	/// <summary>
	/// 发生日期
	/// </summary>
	public readonly short SettlementId;

	/// <summary>
	/// 文本渲染信息
	/// </summary>
	/// <param name="recordType"></param>
	/// <param name="text"></param>
	/// <param name="date"></param>
	/// <param name="settlementId"></param>
	public SettlementTreasuryRecordRenderInfo(short recordType, string text, int date, short settlementId)
		: base(recordType, text)
	{
		Date = date;
		SettlementId = settlementId;
	}
}
