using System.Collections.Generic;
using GameData.Common;
using GameData.Domains.Character;
using Redzen.Random;

namespace GameData.Domains.Taiwu.VillagerRole;

public interface IVillagerRoleContact
{
	bool IncreaseFavorability { get; }

	bool HasChickenUpgradeEffect { get; }

	int ContactFavorabilityChange { get; }

	int ContactCharacterAmount { get; }

	void ApplyContactAction(DataContext context, List<GameData.Domains.Character.Character> targets)
	{
		GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
		int favorChange = ContactFavorabilityChange;
		if (!IncreaseFavorability)
		{
			favorChange = -favorChange;
		}
		foreach (GameData.Domains.Character.Character targetChar in targets)
		{
			DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, targetChar, taiwuChar, favorChange);
		}
	}

	void SelectContactTargets(IRandomSource random, List<GameData.Domains.Character.Character> selectedCharList, int selectAmount);
}
