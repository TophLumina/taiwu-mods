using System.Collections.Generic;
using GameData.Domains.Item;
using GameData.Domains.Taiwu;
using GameData.Utilities;

namespace GameData.Domains.Character.ParallelModifications;

public class UpdateBreakPlateBonusesModification
{
	public Character Character;

	public List<(short skillTemplateId, int startIndex, SerializableList<SkillBreakPlateBonus> bonuses)> ModifiedBonuses;

	public bool PersonalNeedsUpdated;

	public List<ItemKey> ToDeleteItems;

	public int ExpCost;

	public UpdateBreakPlateBonusesModification(Character character)
	{
		Character = character;
	}
}
