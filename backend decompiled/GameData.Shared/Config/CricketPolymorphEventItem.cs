using System;
using Config.Common;

namespace Config;

[Serializable]
public class CricketPolymorphEventItem : ConfigItem<CricketPolymorphEventItem, short>
{
	public readonly short TemplateId;

	public readonly string ContentEvent02;

	public readonly string ContentEventFirstMeet03;

	public readonly string ContentEventFirstMeet03Option;

	public readonly string ContentEventFirstMeet04;

	public readonly string ContentEventFirstMeet05;

	public readonly string ContentEventFirstMeet06;

	public readonly string ContentEventMeetAgain03;

	public readonly string ContentEventMeetAgain04;

	public readonly string ContentEventRevive03;

	public readonly string ContentEventRevive04;

	public readonly string ContentEventName07;

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

	public override CricketPolymorphEventItem Duplicate(int templateId)
	{
		return new CricketPolymorphEventItem((short)templateId, this);
	}
}
