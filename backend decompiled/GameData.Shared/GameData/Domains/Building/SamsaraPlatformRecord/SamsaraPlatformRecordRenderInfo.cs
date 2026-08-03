using GameData.Domains.LifeRecord.GeneralRecord;

namespace GameData.Domains.Building.SamsaraPlatformRecord;

/// <summary>
/// 轮回台记录记录文本渲染信息 (仅供前端使用)
/// </summary>
public class SamsaraPlatformRecordRenderInfo : RenderInfo
{
	/// <summary>
	/// 发生日期
	/// </summary>
	public readonly int Date;

	/// <summary>
	/// 文本渲染信息
	/// </summary>
	/// <param name="recordType"></param>
	/// <param name="text"></param>
	/// <param name="date"></param>
	public SamsaraPlatformRecordRenderInfo(short recordType, string text, int date)
		: base(recordType, text)
	{
		Date = date;
	}
}
