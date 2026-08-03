using System;

namespace GameData.Domains.TaiwuEvent;

[AttributeUsage(AttributeTargets.Method)]
public class EventFunctionAttribute : Attribute
{
	public readonly int Id;

	public EventFunctionAttribute(int id)
	{
		Id = id;
	}
}
