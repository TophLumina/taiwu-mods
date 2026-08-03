using System.Collections.Generic;

namespace GameData.Domains.TaiwuEvent.DisplayEvent;

public class EventInteractionCheckDataHelper
{
	public static EventInteractCheckData EventInteractCheckData(short interactCheckTemplateId)
	{
		return new EventInteractCheckData
		{
			InteractCheckTemplateId = interactCheckTemplateId,
			PhaseProbList = new List<int>(),
			FailPhase = 5
		};
	}
}
