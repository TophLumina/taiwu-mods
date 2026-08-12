using System.Collections.Generic;

public class AnimData
{
	public readonly string Name;

	public readonly float Duration;

	public readonly Dictionary<string, float[]> Events;

	public AnimData(string name, float duration, Dictionary<string, float[]> events)
	{
		Name = name;
		Duration = duration;
		Events = events;
	}
}
