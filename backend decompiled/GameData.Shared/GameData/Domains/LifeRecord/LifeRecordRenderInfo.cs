using GameData.Domains.LifeRecord.GeneralRecord;

namespace GameData.Domains.LifeRecord;

/// <summary>
/// 经历文本渲染信息 (仅供前端使用)
/// </summary>
public class LifeRecordRenderInfo : RenderInfo
{
	/// <summary>
	/// 经历发生日期
	/// </summary>
	public readonly int Date;

	/// <summary>
	/// 该经历的得分
	/// </summary>
	public int Score = 50;

	/// <summary>
	/// 经历文本渲染信息
	/// </summary>
	/// <param name="recordType"></param>
	/// <param name="text"></param>
	/// <param name="date"></param>
	public LifeRecordRenderInfo(short recordType, string text, int date)
		: base(recordType, text)
	{
		Date = date;
	}
}
