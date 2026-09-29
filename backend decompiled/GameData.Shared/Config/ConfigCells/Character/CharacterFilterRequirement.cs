using System;
using System.Linq;

namespace Config.ConfigCells.Character;

[Serializable]
public class CharacterFilterRequirement
{
	public short[] CharacterFilterRuleIds;

	public int MinCharactersRequired;

	public int MaxCharactersRequired;

	public CharacterFilterRequirement(int[] filterRuleIds, int minCharactersRequired, int maxCharactersRequired = -1)
	{
		if (filterRuleIds == null || filterRuleIds.Length == 0)
		{
			throw new ArgumentException("CharacterFilterRequirement need at least one filterRuleId");
		}
		CharacterFilterRuleIds = filterRuleIds.Select((int id) => (short)id).ToArray();
		MinCharactersRequired = minCharactersRequired;
		MaxCharactersRequired = maxCharactersRequired;
	}

	public CharacterFilterRequirement(short[] filterRuleIds, int minCharactersRequired, int maxCharactersRequired = -1)
	{
		if (filterRuleIds == null || filterRuleIds.Length == 0)
		{
			throw new ArgumentException("CharacterFilterRequirement need at least one filterRuleId");
		}
		CharacterFilterRuleIds = filterRuleIds;
		MinCharactersRequired = minCharactersRequired;
		MaxCharactersRequired = maxCharactersRequired;
	}

	public bool HasMaximum()
	{
		return MaxCharactersRequired != -1;
	}
}
