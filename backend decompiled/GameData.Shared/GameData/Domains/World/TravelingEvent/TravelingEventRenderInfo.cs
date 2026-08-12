using GameData.Domains.LifeRecord.GeneralRecord;

namespace GameData.Domains.World.TravelingEvent;

/// <summary>
/// 旅行事件渲染信息
/// </summary>
public class TravelingEventRenderInfo : RenderInfo
{
	/// <summary>
	/// 该通知在数据块中的位置
	/// </summary>
	public int Offset;

	/// <summary>
	/// 该通知绑定的事件 Guid
	/// </summary>
	public string EventGuid;

	/// <summary>
	/// 旅行事件渲染信息。
	/// </summary>
	/// <param name="recordType"></param>
	/// <param name="text"></param>
	/// <param name="offset"></param>
	public TravelingEventRenderInfo(short recordType, string text, int offset)
		: base(recordType, text)
	{
		Offset = offset;
		EventGuid = string.Empty;
	}
}
