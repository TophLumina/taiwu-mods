using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai;

public class AiMemoryNew
{
	public readonly Dictionary<string, int> Ints = new Dictionary<string, int>();

	public readonly Dictionary<string, string> Strings = new Dictionary<string, string>();

	public readonly Dictionary<string, bool> Booleans = new Dictionary<string, bool>();

	private readonly Dictionary<short, EAiPriority> _skillPriorities = new Dictionary<short, EAiPriority>();

	public void Clear()
	{
		Ints.Clear();
		Strings.Clear();
		Booleans.Clear();
		_skillPriorities.Clear();
	}

	public void SetPriority(short skillId, EAiPriority priority)
	{
		if (priority == EAiPriority.Middle)
		{
			_skillPriorities.Remove(skillId);
		}
		else
		{
			_skillPriorities[skillId] = priority;
		}
	}

	public EAiPriority GetPriority(short skillId)
	{
		EAiPriority priority;
		return (!_skillPriorities.TryGetValue(skillId, out priority)) ? EAiPriority.Middle : priority;
	}
}
