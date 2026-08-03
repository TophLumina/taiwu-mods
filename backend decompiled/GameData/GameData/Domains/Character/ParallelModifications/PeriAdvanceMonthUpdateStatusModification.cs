using System.Collections.Generic;
using GameData.Domains.Item;

namespace GameData.Domains.Character.ParallelModifications;

public class PeriAdvanceMonthUpdateStatusModification
{
	public readonly Character Character;

	public List<(ItemKey itemKey, int amount)> ItemsToBeUsed;

	public List<ItemKey> RemovedWugKings;

	public List<ItemKey> RemovedSafetyWugKings;

	public List<short> RemovedWugs;

	public bool IsAssassinated;

	public bool ResourcesChanged;

	public bool EatingItemsChanged;

	public bool CurrNeiliChanged;

	public bool QiDisorderChanged;

	public bool InjuriesChanged;

	public bool PoisonedChanged;

	public bool XiangshuInfectionChanged;

	public short XiangshuInfectionFeatureChanged;

	public bool FeaturesChanged;

	public bool RecreateTeammateCommands;

	public bool PersonalNeedsChanged;

	public bool CurrAgeChanged;

	public bool ActualAgeChanged;

	public bool HealthChanged;

	public bool MaxHealthChanged;

	public bool CurrMainAttributesChanged;

	public bool HobbyChanged;

	public List<(int charId, short favorability)> FavorabilitiesOfRelatedChars;

	public short NewClothingTemplateId;

	public PregnantStateModification PregnantStateModification;

	public sbyte UsedHealingCount;

	public sbyte UsedDetoxCount;

	public sbyte UsedBreathingCount;

	public sbyte UsedRecoverCount;

	public bool InventoryChanged;

	public bool HappinessChanged;

	public List<ItemKey> ConsumedForbiddenFoodsOrWines;

	public List<(sbyte, int)> MixedPoisonEffects;

	public OuterAndInnerInts ChallengeModeWorsenInjuryCount;

	public bool ChallengeModeWorsenAnyPoison;

	public PeriAdvanceMonthUpdateStatusModification(Character character)
	{
		Character = character;
		XiangshuInfectionFeatureChanged = -1;
		NewClothingTemplateId = -1;
	}
}
