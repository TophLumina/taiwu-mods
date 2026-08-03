using GameData.Domains.LifeRecord.GeneralRecord;

namespace GameData.Domains.World.Notification;

/// <summary>
/// 即时通知文本渲染信息 (仅供前端使用)
/// </summary>
public class InstantNotificationRenderInfo : RenderInfo
{
	/// <summary>
	/// 事件发生日期
	/// </summary>
	public readonly int Date;

	/// <summary>
	/// 简短的文本 参数未被替换时的原始文本
	/// </summary>
	public readonly string SimpleText;

	/// <summary>
	/// 即时通知文本渲染信息
	/// </summary>
	/// <param name="recordType"></param>
	/// <param name="text"></param>
	/// <param name="simpleText"></param>
	/// <param name="date"></param>
	public InstantNotificationRenderInfo(short recordType, string text, string simpleText, int date)
		: base(recordType, text)
	{
		SimpleText = simpleText;
		Date = date;
	}
}
