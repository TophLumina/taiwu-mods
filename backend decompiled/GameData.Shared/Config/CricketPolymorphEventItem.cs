using System;
using Config.Common;

namespace Config;

[Serializable]
public class CricketPolymorphEventItem : ConfigItem<CricketPolymorphEventItem, short>
{
	/// <summary>
	/// ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 事件02
	/// </summary>
	public readonly string ContentEvent02;

	/// <summary>
	/// 初见03
	/// </summary>
	public readonly string ContentEventFirstMeet03;

	/// <summary>
	/// 初见03选项
	/// </summary>
	public readonly string ContentEventFirstMeet03Option;

	/// <summary>
	/// 初见04
	/// </summary>
	public readonly string ContentEventFirstMeet04;

	/// <summary>
	/// 初见05
	/// </summary>
	public readonly string ContentEventFirstMeet05;

	/// <summary>
	/// 初见06
	/// </summary>
	public readonly string ContentEventFirstMeet06;

	/// <summary>
	/// 再见03
	/// </summary>
	public readonly string ContentEventMeetAgain03;

	/// <summary>
	/// 再见04
	/// </summary>
	public readonly string ContentEventMeetAgain04;

	/// <summary>
	/// 复活03
	/// </summary>
	public readonly string ContentEventRevive03;

	/// <summary>
	/// 复活04
	/// </summary>
	public readonly string ContentEventRevive04;

	/// <summary>
	/// 取名07
	/// </summary>
	public readonly string ContentEventName07;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">ID</param>
	/// <param name="contentEvent02">事件02</param>
	/// <param name="contentEventFirstMeet03">初见03</param>
	/// <param name="contentEventFirstMeet03Option">初见03选项</param>
	/// <param name="contentEventFirstMeet04">初见04</param>
	/// <param name="contentEventFirstMeet05">初见05</param>
	/// <param name="contentEventFirstMeet06">初见06</param>
	/// <param name="contentEventMeetAgain03">再见03</param>
	/// <param name="contentEventMeetAgain04">再见04</param>
	/// <param name="contentEventRevive03">复活03</param>
	/// <param name="contentEventRevive04">复活04</param>
	/// <param name="contentEventName07">取名07</param>
	public CricketPolymorphEventItem(short templateId, string contentEvent02, string contentEventFirstMeet03, string contentEventFirstMeet03Option, string contentEventFirstMeet04, string contentEventFirstMeet05, string contentEventFirstMeet06, string contentEventMeetAgain03, string contentEventMeetAgain04, string contentEventRevive03, string contentEventRevive04, string contentEventName07)
	{
		TemplateId = templateId;
		ContentEvent02 = contentEvent02;
		ContentEventFirstMeet03 = contentEventFirstMeet03;
		ContentEventFirstMeet03Option = contentEventFirstMeet03Option;
		ContentEventFirstMeet04 = contentEventFirstMeet04;
		ContentEventFirstMeet05 = contentEventFirstMeet05;
		ContentEventFirstMeet06 = contentEventFirstMeet06;
		ContentEventMeetAgain03 = contentEventMeetAgain03;
		ContentEventMeetAgain04 = contentEventMeetAgain04;
		ContentEventRevive03 = contentEventRevive03;
		ContentEventRevive04 = contentEventRevive04;
		ContentEventName07 = contentEventName07;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public CricketPolymorphEventItem()
	{
		TemplateId = 0;
		ContentEvent02 = null;
		ContentEventFirstMeet03 = null;
		ContentEventFirstMeet03Option = null;
		ContentEventFirstMeet04 = null;
		ContentEventFirstMeet05 = null;
		ContentEventFirstMeet06 = null;
		ContentEventMeetAgain03 = null;
		ContentEventMeetAgain04 = null;
		ContentEventRevive03 = null;
		ContentEventRevive04 = null;
		ContentEventName07 = null;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public CricketPolymorphEventItem(short templateId, CricketPolymorphEventItem other)
	{
		TemplateId = templateId;
		ContentEvent02 = other.ContentEvent02;
		ContentEventFirstMeet03 = other.ContentEventFirstMeet03;
		ContentEventFirstMeet03Option = other.ContentEventFirstMeet03Option;
		ContentEventFirstMeet04 = other.ContentEventFirstMeet04;
		ContentEventFirstMeet05 = other.ContentEventFirstMeet05;
		ContentEventFirstMeet06 = other.ContentEventFirstMeet06;
		ContentEventMeetAgain03 = other.ContentEventMeetAgain03;
		ContentEventMeetAgain04 = other.ContentEventMeetAgain04;
		ContentEventRevive03 = other.ContentEventRevive03;
		ContentEventRevive04 = other.ContentEventRevive04;
		ContentEventName07 = other.ContentEventName07;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override CricketPolymorphEventItem Duplicate(int templateId)
	{
		return new CricketPolymorphEventItem((short)templateId, this);
	}
}
