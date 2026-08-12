using System.Collections.Generic;

namespace GameData.Domains.TaiwuEvent;

public class EventScript : EventScriptBase
{
	public EventInstruction[] Instructions;

	public Dictionary<string, int> Labels;
}
