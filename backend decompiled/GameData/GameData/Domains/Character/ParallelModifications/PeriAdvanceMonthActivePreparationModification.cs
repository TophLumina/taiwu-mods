using System.Collections.Generic;
using GameData.Domains.Item;

namespace GameData.Domains.Character.ParallelModifications;

public class PeriAdvanceMonthActivePreparationModification
{
	public readonly Character Character;

	public bool ResourcesChanged;

	public bool PersonalNeedChanged;

	public List<ItemBase> ItemsFixed;

	public HashSet<int> CraftToolsUsed;

	public ItemKey[] PoisonsToUse;

	public sbyte EquipmentSlotToAddPoison;

	public ItemKey FeedingCarrierKey;

	public ItemKey FeedingFoodKey;

	public bool IsChanged => ResourcesChanged || PersonalNeedChanged || PoisonsToUse != null || (FeedingCarrierKey.IsValid() && FeedingFoodKey.IsValid());

	public PeriAdvanceMonthActivePreparationModification(Character character)
	{
		Character = character;
		PoisonsToUse = null;
		EquipmentSlotToAddPoison = -1;
		FeedingCarrierKey = ItemKey.Invalid;
		FeedingFoodKey = ItemKey.Invalid;
	}
}
