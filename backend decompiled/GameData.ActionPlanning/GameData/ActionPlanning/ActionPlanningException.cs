using System;

namespace GameData.ActionPlanning;

public class ActionPlanningException : Exception
{
	public ActionPlanningException(string message)
		: base(message)
	{
	}
}
