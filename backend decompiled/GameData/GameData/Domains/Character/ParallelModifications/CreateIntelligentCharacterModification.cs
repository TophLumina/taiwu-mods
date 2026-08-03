using System.Collections.Generic;
using Config.ConfigCells.Character;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.Character.ParallelModifications;

public class CreateIntelligentCharacterModification
{
	public Character Self;

	public int FatherCharId;

	public int MotherCharId;

	public bool CreateFatherRelation;

	public bool CreateMotherRelation;

	public Character Father;

	public sbyte FathersLegitimateBoysCount;

	public PresetEquipmentItem[] Equipment;

	public List<PresetInventoryItem> Inventory;

	public List<GameData.Domains.CombatSkill.CombatSkill> CombatSkills;

	public List<InventoryCombatSkillBookParams> InventorySkillBooks;

	public HashSet<short> SkillWeaponIds;

	public int ReincarnationCharId;

	public sbyte GrowingSectGrade;

	public bool DisableBeReincarnatedBySavedSoul;
}
