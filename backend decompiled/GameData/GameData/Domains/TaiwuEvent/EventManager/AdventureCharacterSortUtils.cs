using System;

namespace GameData.Domains.TaiwuEvent.EventManager;

public static class AdventureCharacterSortUtils
{
	public static void Sort(EventArgBox eventArgBox, bool isMajorChar, int groupId, CharacterSortType characterSortType, bool ascendingOrder)
	{
		if (characterSortType == CharacterSortType.CombatPower)
		{
			Sort(eventArgBox, isMajorChar, groupId, CompareCombatPower, ascendingOrder);
		}
	}

	public static void Sort(EventArgBox eventArgBox, bool isMajorChar, int groupId, Comparison<int> comparison, bool ascendingOrder)
	{
		int count = (isMajorChar ? eventArgBox.GetAdventureMajorCharacterCount(groupId) : eventArgBox.GetAdventureParticipateCharacterCount(groupId));
		string prefix = (isMajorChar ? "MajorCharacter" : "ParticipateCharacter");
		int charA = -1;
		int charB = -1;
		for (int i = 0; i < count - 1; i++)
		{
			for (int j = 0; j < count - i - 1; j++)
			{
				eventArgBox.Get($"{prefix}_{groupId}_{j}", ref charA);
				eventArgBox.Get($"{prefix}_{groupId}_{j + 1}", ref charB);
				int result = comparison(charA, charB);
				if (!ascendingOrder)
				{
					result = -result;
				}
				if (result > 0)
				{
					int num = charA;
					charA = charB;
					charB = num;
					eventArgBox.Set($"{prefix}_{groupId}_{j}", charA);
					eventArgBox.Set($"{prefix}_{groupId}_{j + 1}", charB);
				}
			}
		}
	}

	public static int CompareCombatPower(int charIdA, int charIdB)
	{
		DomainManager.Character.TryGetElement_Objects(charIdA, out var charA);
		DomainManager.Character.TryGetElement_Objects(charIdB, out var charB);
		int charAPower = charA?.GetCombatPower() ?? 0;
		int charBPower = charB?.GetCombatPower() ?? 0;
		return charAPower.CompareTo(charBPower);
	}
}
