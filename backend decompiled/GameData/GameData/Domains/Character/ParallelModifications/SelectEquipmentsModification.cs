using GameData.Domains.Item;
using GameData.Utilities;

namespace GameData.Domains.Character.ParallelModifications;

public class SelectEquipmentsModification
{
	public readonly Character Character;

	public readonly bool RemoveUnequippedEquipment;

	public bool EquippedSkillsChanged;

	public CombatSkillEquipment CombatSkillEquipment;

	public bool NeiliAllocationChanged;

	public NeiliAllocation NeiliAllocation;

	public bool LoopingNeigongChanged;

	public short LoopingNeigong;

	public ItemKey[] EquippedItems;

	public bool PersonalNeedChanged;

	public ShortList MasteredCombatSkills;

	public bool MasteredSkillsChanged;

	public byte[] GenericSkillSlotAllocation;

	public SelectEquipmentsModification(Character character, bool removeUnequippedEquipment)
	{
		Character = character;
		RemoveUnequippedEquipment = removeUnequippedEquipment;
		EquippedSkillsChanged = false;
		NeiliAllocationChanged = false;
		LoopingNeigongChanged = false;
	}
}
