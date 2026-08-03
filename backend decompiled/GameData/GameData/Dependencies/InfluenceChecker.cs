using System;
using System.Collections.Generic;
using Config;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.Item;
using GameData.Domains.Organization;
using GameData.Domains.SpecialEffect;
using GameData.Utilities;

namespace GameData.Dependencies;

public static class InfluenceChecker
{
	public static readonly LocalObjectPool<List<BaseGameDataObject>> InfluencedObjectsPool = new LocalObjectPool<List<BaseGameDataObject>>(8, 16);

	public static bool CheckCondition(DataContext context, BaseGameDataObject sourceObject, InfluenceCondition condition)
	{
		return condition switch
		{
			InfluenceCondition.None => true, 
			InfluenceCondition.CharIsTaiwu => CheckCondition_CharIsTaiwu(sourceObject), 
			InfluenceCondition.CharIsInTaiwuGroup => CheckCondition_CharIsInTaiwuGroup(sourceObject), 
			InfluenceCondition.ItemIsEquipped => CheckCondition_ItemIsEquipped(sourceObject), 
			InfluenceCondition.CivilianSettlementIsTaiwuVillage => CheckCondition_CivilianSettlementIsTaiwuVillage(sourceObject), 
			InfluenceCondition.CharIsInAnySect => CheckCondition_CharIsInAnySect(sourceObject), 
			InfluenceCondition.CharIsInAnyCivilianSettlement => CheckCondition_CharIsInAnyCivilianSettlement(sourceObject), 
			InfluenceCondition.CombatSkillIsProactive => CheckCondition_CombatSkillIsProactive(sourceObject), 
			InfluenceCondition.CharIsTaiwuWorker => CheckCondition_CharIsTaiwuWorker(sourceObject), 
			InfluenceCondition.CharIsTaiwuVillager => CheckCondition_CharIsTaiwuVillager(sourceObject), 
			InfluenceCondition.CharIsTaiwuVillageHead => CheckCondition_CharIsTaiwuVillageHead(sourceObject), 
			InfluenceCondition.CharIsTaskRelated => CheckCondition_CharIsTaskRelated(sourceObject), 
			InfluenceCondition.CharIsXiangshuInfectedDemon => CheckCondition_CharIsXiangshuInfectedDemon(sourceObject), 
			InfluenceCondition.CombatSkillIsLearnedByTaiwu => CheckCondition_CombatSkillIsLearnedByTaiwu(sourceObject), 
			InfluenceCondition.CombatWeaponIsTaiwuWeapon => CheckCondition_CombatWeaponIsTaiwuWeapon(sourceObject), 
			InfluenceCondition.CombatWeaponIsNotTaiwuWeapon => CheckCondition_CombatWeaponIsNotTaiwuWeapon(sourceObject), 
			_ => throw new Exception($"Unsupported InfluenceCondition: {condition}"), 
		};
	}

	public static bool GetScope<TKey, TValue>(DataContext context, BaseGameDataObject sourceObject, InfluenceScope scope, IDictionary<TKey, TValue> targetCollection, List<BaseGameDataObject> influencedObjects) where TKey : unmanaged where TValue : BaseGameDataObject
	{
		return scope switch
		{
			InfluenceScope.All => true, 
			InfluenceScope.Self => GetScope_Self(sourceObject, influencedObjects), 
			InfluenceScope.TaiwuChar => GetScope_TaiwuChar(influencedObjects), 
			InfluenceScope.CharWhoEquippedTheItem => GetScope_CharWhoEquippedTheItem(sourceObject, targetCollection, influencedObjects), 
			InfluenceScope.WeaponsOfTheChar => GetScope_WeaponsOfTheChar(sourceObject, influencedObjects), 
			InfluenceScope.ArmorsOfTheChar => GetScope_ArmorsOfTheChar(sourceObject, influencedObjects), 
			InfluenceScope.AccessoriesOfTheChar => GetScope_AccessoriesOfTheChar(sourceObject, influencedObjects), 
			InfluenceScope.CombatSkillOwner => GetScope_CombatSkillOwner(sourceObject, targetCollection, influencedObjects), 
			InfluenceScope.AllCharsInTaiwuVillage => GetScope_AllCharsInTaiwuVillage(influencedObjects), 
			InfluenceScope.AllNonHeadCharsInTaiwuVillage => GetScope_AllNonHeadCharsInTaiwuVillage(influencedObjects), 
			InfluenceScope.AllFixedCharsAffectedByXiangshuInfectedDemons => GetScope_AllFixedCharsAffectedByXiangshuInfectedDemons(influencedObjects), 
			InfluenceScope.AllCharsInCombat => GetScope_AllCharsInCombat(influencedObjects), 
			InfluenceScope.AllCombatCharsInCombat => GetScope_AllCombatCharsInCombat(influencedObjects), 
			InfluenceScope.CombatSkillsOfAllCharsInCombat => GetScope_CombatSkillsOfAllCharsInCombat(influencedObjects), 
			InfluenceScope.CombatSkillsOfTheChar => GetScope_CombatSkillsOfTheChar(sourceObject, influencedObjects), 
			InfluenceScope.CombatSkillsOfTaiwuChar => GetScope_CombatSkillsOfTaiwuChar(sourceObject, influencedObjects), 
			InfluenceScope.CombatSkillsOfTheCombatChar => GetScope_CombatSkillsOfTheCombatChar(sourceObject, influencedObjects), 
			InfluenceScope.CombatCharOfTheCombatSkillData => GetScope_CombatCharOfTheCombatSkillData(sourceObject, influencedObjects), 
			InfluenceScope.CombatCharOfTheCombatWeaponData => GetScope_CombatCharOfTheCombatWeaponData(sourceObject, influencedObjects), 
			InfluenceScope.CombatCharOfTheChar => GetScope_CombatCharOfTheChar(sourceObject, influencedObjects), 
			InfluenceScope.CharOfTheCombatChar => GetScope_CharOfTheCombatChar(sourceObject, influencedObjects), 
			InfluenceScope.SectCharOfTheChar => GetScope_SectCharOfTheChar(sourceObject, targetCollection, influencedObjects), 
			InfluenceScope.CivilianSettlementCharOfTheChar => GetScope_CivilianSettlementCharOfTheChar(sourceObject, targetCollection, influencedObjects), 
			InfluenceScope.SectOfTheChar => GetScope_SectOfTheChar(sourceObject, targetCollection, influencedObjects), 
			InfluenceScope.SectCharsOfTheSect => GetScope_SectCharsOfTheSect(sourceObject, targetCollection, influencedObjects), 
			InfluenceScope.CivilianSettlementCharsOfTheCivilianSettlement => GetScope_CivilianSettlementCharsOfTheCivilianSettlement(sourceObject, targetCollection, influencedObjects), 
			InfluenceScope.SectCharsOfTheChar => GetScope_SectCharsOfTheChar(sourceObject, targetCollection, influencedObjects), 
			InfluenceScope.CivilianSettlementCharsOfTheChar => GetScope_CivilianSettlementCharsOfTheChar(sourceObject, targetCollection, influencedObjects), 
			InfluenceScope.CharacterAffectedByTheSpecialEffects => GetScope_CharacterAffectedByTheSpecialEffects(sourceObject, influencedObjects), 
			InfluenceScope.CombatSkillsOfTheCharacterAffectedByTheSpecialEffects => GetScope_CombatSkillsOfTheCharacterAffectedByTheSpecialEffects(sourceObject, influencedObjects), 
			InfluenceScope.WeaponsOfTheCharacterAffectedByTheSpecialEffects => GetScope_WeaponsOfTheCharacterAffectedByTheSpecialEffects(sourceObject, influencedObjects), 
			InfluenceScope.ArmorsOfTheCharacterAffectedByTheSpecialEffects => GetScope_ArmorsOfTheCharacterAffectedByTheSpecialEffects(sourceObject, influencedObjects), 
			InfluenceScope.AccessoriesOfTheCharacterAffectedByTheSpecialEffects => GetScope_AccessoriesOfTheCharacterAffectedByTheSpecialEffects(sourceObject, influencedObjects), 
			InfluenceScope.CombatCharacterAffectedByTheSpecialEffects => GetScope_CombatCharacterAffectedByTheSpecialEffects(sourceObject, influencedObjects), 
			InfluenceScope.CombatSkillDataAffectedByTheSpecialEffects => GetScope_CombatSkillDataAffectedByTheSpecialEffects(sourceObject, influencedObjects), 
			InfluenceScope.CombatSkillsAffectedByPowerChangeInCombat => GetScope_CombatSkillsAffectedByPowerChangeInCombat(influencedObjects), 
			InfluenceScope.CombatSkillsAffectedByPowerReplaceInCombat => GetScope_CombatSkillsAffectedByPowerReplaceInCombat(influencedObjects), 
			InfluenceScope.CombatSkillsAffectedByCombatSkillDataInCombat => GetScope_CombatSkillsAffectedByCombatSkillDataInCombat(sourceObject, influencedObjects), 
			InfluenceScope.TaiwuAndGearMates => GetScope_TaiwuAndGearMates(influencedObjects), 
			_ => throw new Exception($"Unsupported InfluenceScope: {scope}"), 
		};
	}

	public static bool CheckCondition_CharIsTaiwu(BaseGameDataObject sourceObject)
	{
		return sourceObject == DomainManager.Taiwu.GetTaiwu();
	}

	public static bool CheckCondition_CharIsInTaiwuGroup(BaseGameDataObject sourceObject)
	{
		GameData.Domains.Character.Character character = (GameData.Domains.Character.Character)sourceObject;
		return character.GetLeaderId() == DomainManager.Taiwu.GetTaiwuCharId();
	}

	public static bool CheckCondition_ItemIsEquipped(BaseGameDataObject sourceObject)
	{
		EquipmentBase baseItem = (EquipmentBase)sourceObject;
		return baseItem.GetEquippedCharId() >= 0;
	}

	public static bool CheckCondition_CivilianSettlementIsTaiwuVillage(BaseGameDataObject sourceObject)
	{
		CivilianSettlement civilianSettlement = (CivilianSettlement)sourceObject;
		return civilianSettlement.GetId() == DomainManager.Taiwu.GetTaiwuVillageSettlementId();
	}

	public static bool CheckCondition_CharIsInAnySect(BaseGameDataObject sourceObject)
	{
		GameData.Domains.Character.Character character = (GameData.Domains.Character.Character)sourceObject;
		return OrganizationDomain.IsSect(character.GetOrganizationInfo().OrgTemplateId);
	}

	public static bool CheckCondition_CharIsInAnyCivilianSettlement(BaseGameDataObject sourceObject)
	{
		GameData.Domains.Character.Character character = (GameData.Domains.Character.Character)sourceObject;
		return !OrganizationDomain.IsSect(character.GetOrganizationInfo().OrgTemplateId);
	}

	public static bool CheckCondition_CombatSkillIsProactive(BaseGameDataObject sourceObject)
	{
		short skillTemplateId = ((GameData.Domains.CombatSkill.CombatSkill)sourceObject).GetId().SkillTemplateId;
		CombatSkillItem config = Config.CombatSkill.Instance[skillTemplateId];
		return GameData.Domains.Character.CombatSkillHelper.IsProactiveSkill(config.EquipType);
	}

	public static bool CheckCondition_CombatSkillIsLearnedByTaiwu(BaseGameDataObject sourceObject)
	{
		return ((GameData.Domains.CombatSkill.CombatSkill)sourceObject).GetId().CharId == DomainManager.Taiwu.GetTaiwuCharId();
	}

	public static bool CheckCondition_CombatWeaponIsTaiwuWeapon(BaseGameDataObject sourceObject)
	{
		return ((CombatWeaponData)sourceObject).Character.GetId() == DomainManager.Taiwu.GetTaiwuCharId();
	}

	public static bool CheckCondition_CombatWeaponIsNotTaiwuWeapon(BaseGameDataObject sourceObject)
	{
		return ((CombatWeaponData)sourceObject).Character.GetId() != DomainManager.Taiwu.GetTaiwuCharId();
	}

	public static bool CheckCondition_CharIsTaiwuWorker(BaseGameDataObject sourceObject)
	{
		GameData.Domains.Character.Character character = (GameData.Domains.Character.Character)sourceObject;
		return character.IsActiveExternalRelationState(1uL);
	}

	public static bool CheckCondition_CharIsTaiwuVillager(BaseGameDataObject sourceObject)
	{
		GameData.Domains.Character.Character character = (GameData.Domains.Character.Character)sourceObject;
		return character.GetOrganizationInfo().OrgTemplateId == 16;
	}

	public static bool CheckCondition_CharIsTaiwuVillageHead(BaseGameDataObject sourceObject)
	{
		GameData.Domains.Character.Character character = (GameData.Domains.Character.Character)sourceObject;
		OrganizationInfo orgInfo = character.GetOrganizationInfo();
		return orgInfo.OrgTemplateId == 16 && orgInfo.Grade == 7;
	}

	public static bool CheckCondition_CharIsTaskRelated(BaseGameDataObject sourceObject)
	{
		GameData.Domains.Character.Character character = (GameData.Domains.Character.Character)sourceObject;
		return character == DomainManager.Taiwu.GetTaiwu() || Config.Character.Instance[character.GetTemplateId()].CreatingType == 0;
	}

	public static bool CheckCondition_CharIsXiangshuInfectedDemon(BaseGameDataObject sourceObject)
	{
		GameData.Domains.Character.Character character = (GameData.Domains.Character.Character)sourceObject;
		return character.IsCompletelyInfected() && character.GetFeatureIds().Contains(814);
	}

	public static bool GetScope_Self(BaseGameDataObject sourceObject, List<BaseGameDataObject> influencedObjects)
	{
		influencedObjects.Add(sourceObject);
		return false;
	}

	public static bool GetScope_TaiwuChar(List<BaseGameDataObject> influencedObjects)
	{
		GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
		influencedObjects.Add(taiwuChar);
		return false;
	}

	public static bool GetScope_CharWhoEquippedTheItem<TKey, TValue>(BaseGameDataObject sourceObject, IDictionary<TKey, TValue> targetCollection, List<BaseGameDataObject> influencedObjects) where TKey : unmanaged where TValue : BaseGameDataObject
	{
		EquipmentBase baseItem = (EquipmentBase)sourceObject;
		int equippedCharId = baseItem.GetEquippedCharId();
		if (equippedCharId >= 0)
		{
			IDictionary<int, GameData.Domains.Character.Character> characters = (IDictionary<int, GameData.Domains.Character.Character>)targetCollection;
			if (characters.TryGetValue(equippedCharId, out var character))
			{
				influencedObjects.Add(character);
			}
		}
		return false;
	}

	public static bool GetScope_WeaponsOfTheChar(BaseGameDataObject sourceObject, List<BaseGameDataObject> influencedObjects)
	{
		GameData.Domains.Character.Character character = (GameData.Domains.Character.Character)sourceObject;
		ItemKey[] equipment = character.GetEquipment();
		for (int i = 0; i < equipment.Length; i++)
		{
			ItemKey itemKey = equipment[i];
			if (itemKey.IsValid() && DomainManager.Item.TryGetElement_Weapons(itemKey.Id, out var equipment2))
			{
				influencedObjects.Add(equipment2);
			}
		}
		return false;
	}

	public static bool GetScope_ArmorsOfTheChar(BaseGameDataObject sourceObject, List<BaseGameDataObject> influencedObjects)
	{
		GameData.Domains.Character.Character character = (GameData.Domains.Character.Character)sourceObject;
		ItemKey[] equipment = character.GetEquipment();
		for (int i = 0; i < equipment.Length; i++)
		{
			ItemKey itemKey = equipment[i];
			if (itemKey.IsValid() && DomainManager.Item.TryGetElement_Armors(itemKey.Id, out var equipment2))
			{
				influencedObjects.Add(equipment2);
			}
		}
		return false;
	}

	public static bool GetScope_AccessoriesOfTheChar(BaseGameDataObject sourceObject, List<BaseGameDataObject> influencedObjects)
	{
		GameData.Domains.Character.Character character = (GameData.Domains.Character.Character)sourceObject;
		ItemKey[] equipment = character.GetEquipment();
		for (int i = 0; i < equipment.Length; i++)
		{
			ItemKey itemKey = equipment[i];
			if (itemKey.IsValid() && DomainManager.Item.TryGetElement_Accessories(itemKey.Id, out var equipment2))
			{
				influencedObjects.Add(equipment2);
			}
		}
		return false;
	}

	public static bool GetScope_CombatSkillOwner<TKey, TValue>(BaseGameDataObject sourceObject, IDictionary<TKey, TValue> targetCollection, List<BaseGameDataObject> influencedObjects) where TKey : unmanaged where TValue : BaseGameDataObject
	{
		GameData.Domains.CombatSkill.CombatSkill combatSkill = (GameData.Domains.CombatSkill.CombatSkill)sourceObject;
		IDictionary<int, GameData.Domains.Character.Character> characters = (IDictionary<int, GameData.Domains.Character.Character>)targetCollection;
		GameData.Domains.Character.Character character = characters[combatSkill.GetId().CharId];
		influencedObjects.Add(character);
		return false;
	}

	public static bool GetScope_AllCharsInTaiwuVillage(List<BaseGameDataObject> influencedObjects)
	{
		List<int> memberIds = ObjectPool<List<int>>.Instance.Get();
		short taiwuVillageSettlementId = DomainManager.Taiwu.GetTaiwuVillageSettlementId();
		Settlement taiwuVillageSettlement = DomainManager.Organization.GetSettlement(taiwuVillageSettlementId);
		taiwuVillageSettlement.GetMembers().GetAllMembers(memberIds);
		for (int i = 0; i < memberIds.Count; i++)
		{
			influencedObjects.Add(DomainManager.Character.GetElement_Objects(memberIds[i]));
		}
		ObjectPool<List<int>>.Instance.Return(memberIds);
		return false;
	}

	public static bool GetScope_AllNonHeadCharsInTaiwuVillage(List<BaseGameDataObject> influencedObjects)
	{
		short taiwuVillageSettlementId = DomainManager.Taiwu.GetTaiwuVillageSettlementId();
		Settlement taiwuVillageSettlement = DomainManager.Organization.GetSettlement(taiwuVillageSettlementId);
		OrgMemberCollection members = taiwuVillageSettlement.GetMembers();
		for (sbyte grade = 0; grade < 7; grade++)
		{
			HashSet<int> gradeMembers = members.GetMembers(grade);
			foreach (int memberId in gradeMembers)
			{
				influencedObjects.Add(DomainManager.Character.GetElement_Objects(memberId));
			}
		}
		return false;
	}

	public static bool GetScope_AllFixedCharsAffectedByXiangshuInfectedDemons(List<BaseGameDataObject> influencedObjects)
	{
		foreach (var (templateId, charId) in DomainManager.Character.FixedCharacterIds)
		{
			if (Config.Character.Instance[templateId].XiangshuInfectedDemonBonus)
			{
				influencedObjects.Add(DomainManager.Character.GetElement_Objects(charId));
			}
		}
		return false;
	}

	public static bool GetScope_AllCharsInCombat(List<BaseGameDataObject> influencedObjects)
	{
		List<int> allCharsInCombat = ObjectPool<List<int>>.Instance.Get();
		DomainManager.Combat.GetAllCharInCombat(allCharsInCombat);
		for (int i = 0; i < allCharsInCombat.Count; i++)
		{
			influencedObjects.Add(DomainManager.Character.GetElement_Objects(allCharsInCombat[i]));
		}
		ObjectPool<List<int>>.Instance.Return(allCharsInCombat);
		return false;
	}

	public static bool GetScope_AllCombatCharsInCombat(List<BaseGameDataObject> influencedObjects)
	{
		List<int> allCharsInCombat = ObjectPool<List<int>>.Instance.Get();
		DomainManager.Combat.GetAllCharInCombat(allCharsInCombat);
		for (int i = 0; i < allCharsInCombat.Count; i++)
		{
			influencedObjects.Add(DomainManager.Combat.GetElement_CombatCharacterDict(allCharsInCombat[i]));
		}
		ObjectPool<List<int>>.Instance.Return(allCharsInCombat);
		return false;
	}

	public static bool GetScope_CombatSkillsOfAllCharsInCombat(List<BaseGameDataObject> influencedObjects)
	{
		List<int> allCharsInCombat = ObjectPool<List<int>>.Instance.Get();
		DomainManager.Combat.GetAllCharInCombat(allCharsInCombat);
		for (int i = 0; i < allCharsInCombat.Count; i++)
		{
			Dictionary<short, GameData.Domains.CombatSkill.CombatSkill> combatSkills = DomainManager.CombatSkill.GetCharCombatSkills(allCharsInCombat[i]);
			foreach (KeyValuePair<short, GameData.Domains.CombatSkill.CombatSkill> item in combatSkills)
			{
				influencedObjects.Add(item.Value);
			}
		}
		ObjectPool<List<int>>.Instance.Return(allCharsInCombat);
		return false;
	}

	public static bool GetScope_CombatSkillsOfTheChar(BaseGameDataObject sourceObject, List<BaseGameDataObject> influencedObjects)
	{
		GameData.Domains.Character.Character character = (GameData.Domains.Character.Character)sourceObject;
		int charId = character.GetId();
		Dictionary<short, GameData.Domains.CombatSkill.CombatSkill> combatSkills = DomainManager.CombatSkill.GetCharCombatSkills(charId);
		foreach (KeyValuePair<short, GameData.Domains.CombatSkill.CombatSkill> item in combatSkills)
		{
			influencedObjects.Add(item.Value);
		}
		return false;
	}

	public static bool GetScope_CombatSkillsOfTaiwuChar(BaseGameDataObject sourceObject, List<BaseGameDataObject> influencedObjects)
	{
		int charId = DomainManager.Taiwu.GetTaiwuCharId();
		Dictionary<short, GameData.Domains.CombatSkill.CombatSkill> combatSkills = DomainManager.CombatSkill.GetCharCombatSkills(charId);
		foreach (KeyValuePair<short, GameData.Domains.CombatSkill.CombatSkill> item in combatSkills)
		{
			influencedObjects.Add(item.Value);
		}
		return false;
	}

	public static bool GetScope_CombatSkillsOfTheCombatChar(BaseGameDataObject sourceObject, List<BaseGameDataObject> influencedObjects)
	{
		CombatCharacter combatChar = (CombatCharacter)sourceObject;
		int charId = combatChar.GetId();
		Dictionary<short, GameData.Domains.CombatSkill.CombatSkill> combatSkills = DomainManager.CombatSkill.GetCharCombatSkills(charId);
		foreach (KeyValuePair<short, GameData.Domains.CombatSkill.CombatSkill> item in combatSkills)
		{
			influencedObjects.Add(item.Value);
		}
		return false;
	}

	public static bool GetScope_CombatCharOfTheCombatSkillData(BaseGameDataObject sourceObject, List<BaseGameDataObject> influencedObjects)
	{
		CombatSkillData data = (CombatSkillData)sourceObject;
		if (DomainManager.Combat.TryGetElement_CombatCharacterDict(data.GetId().CharId, out var combatChar))
		{
			influencedObjects.Add(combatChar);
		}
		influencedObjects.Add(combatChar);
		return false;
	}

	public static bool GetScope_CombatCharOfTheCombatWeaponData(BaseGameDataObject sourceObject, List<BaseGameDataObject> influencedObjects)
	{
		CombatWeaponData data = (CombatWeaponData)sourceObject;
		int charId = DomainManager.Combat.GetWeaponCharId(data.GetId());
		if (charId >= 0)
		{
			influencedObjects.Add(DomainManager.Combat.GetElement_CombatCharacterDict(charId));
		}
		return false;
	}

	public static bool GetScope_CombatCharOfTheChar(BaseGameDataObject sourceObject, List<BaseGameDataObject> influencedObjects)
	{
		GameData.Domains.Character.Character character = (GameData.Domains.Character.Character)sourceObject;
		if (DomainManager.Combat.IsCharInCombat(character.GetId()))
		{
			influencedObjects.Add(DomainManager.Combat.GetElement_CombatCharacterDict(character.GetId()));
		}
		return false;
	}

	public static bool GetScope_CharOfTheCombatChar(BaseGameDataObject sourceObject, List<BaseGameDataObject> influencedObjects)
	{
		influencedObjects.Add(((CombatCharacter)sourceObject).GetCharacter());
		return false;
	}

	public static bool GetScope_SectCharOfTheChar<TKey, TValue>(BaseGameDataObject sourceObject, IDictionary<TKey, TValue> targetCollection, List<BaseGameDataObject> influencedObjects) where TKey : unmanaged where TValue : BaseGameDataObject
	{
		GameData.Domains.Character.Character character = (GameData.Domains.Character.Character)sourceObject;
		IDictionary<int, SectCharacter> sectCharacters = (IDictionary<int, SectCharacter>)targetCollection;
		SectCharacter sectCharacter = sectCharacters[character.GetId()];
		influencedObjects.Add(sectCharacter);
		return false;
	}

	public static bool GetScope_CivilianSettlementCharOfTheChar<TKey, TValue>(BaseGameDataObject sourceObject, IDictionary<TKey, TValue> targetCollection, List<BaseGameDataObject> influencedObjects) where TKey : unmanaged where TValue : BaseGameDataObject
	{
		GameData.Domains.Character.Character character = (GameData.Domains.Character.Character)sourceObject;
		IDictionary<int, CivilianSettlementCharacter> civilianSettlementChars = (IDictionary<int, CivilianSettlementCharacter>)targetCollection;
		CivilianSettlementCharacter civilianSettlementChar = civilianSettlementChars[character.GetId()];
		influencedObjects.Add(civilianSettlementChar);
		return false;
	}

	public static bool GetScope_SectCharsOfTheSect<TKey, TValue>(BaseGameDataObject sourceObject, IDictionary<TKey, TValue> targetCollection, List<BaseGameDataObject> influencedObjects) where TKey : unmanaged where TValue : BaseGameDataObject
	{
		Sect sect = (Sect)sourceObject;
		OrgMemberCollection members = sect.GetMembers();
		IDictionary<int, SectCharacter> sectCharacters = (IDictionary<int, SectCharacter>)targetCollection;
		for (sbyte grade = 0; grade < 9; grade++)
		{
			HashSet<int> gradeMembers = members.GetMembers(grade);
			foreach (int charId in gradeMembers)
			{
				influencedObjects.Add(sectCharacters[charId]);
			}
		}
		return false;
	}

	public static bool GetScope_CivilianSettlementCharsOfTheCivilianSettlement<TKey, TValue>(BaseGameDataObject sourceObject, IDictionary<TKey, TValue> targetCollection, List<BaseGameDataObject> influencedObjects) where TKey : unmanaged where TValue : BaseGameDataObject
	{
		CivilianSettlement civilianSettlement = (CivilianSettlement)sourceObject;
		OrgMemberCollection members = civilianSettlement.GetMembers();
		IDictionary<int, CivilianSettlementCharacter> civilianSettlementChars = (IDictionary<int, CivilianSettlementCharacter>)targetCollection;
		for (sbyte grade = 0; grade < 9; grade++)
		{
			HashSet<int> gradeMembers = members.GetMembers(grade);
			foreach (int charId in gradeMembers)
			{
				influencedObjects.Add(civilianSettlementChars[charId]);
			}
		}
		return false;
	}

	public static bool GetScope_SectOfTheChar<TKey, TValue>(BaseGameDataObject sourceObject, IDictionary<TKey, TValue> targetCollection, List<BaseGameDataObject> influencedObjects) where TKey : unmanaged where TValue : BaseGameDataObject
	{
		GameData.Domains.Character.Character character = (GameData.Domains.Character.Character)sourceObject;
		short settlementId = character.GetOrganizationInfo().SettlementId;
		if (DomainManager.Organization.TryGetElement_Sects(settlementId, out var sect))
		{
			influencedObjects.Add(sect);
		}
		return false;
	}

	public static bool GetScope_SectCharsOfTheChar<TKey, TValue>(BaseGameDataObject sourceObject, IDictionary<TKey, TValue> targetCollection, List<BaseGameDataObject> influencedObjects) where TKey : unmanaged where TValue : BaseGameDataObject
	{
		GameData.Domains.Character.Character character = (GameData.Domains.Character.Character)sourceObject;
		short settlementId = character.GetOrganizationInfo().SettlementId;
		Sect sect = DomainManager.Organization.GetElement_Sects(settlementId);
		OrgMemberCollection members = sect.GetMembers();
		IDictionary<int, SectCharacter> sectCharacters = (IDictionary<int, SectCharacter>)targetCollection;
		for (sbyte grade = 0; grade < 9; grade++)
		{
			HashSet<int> gradeMembers = members.GetMembers(grade);
			foreach (int charId in gradeMembers)
			{
				influencedObjects.Add(sectCharacters[charId]);
			}
		}
		return false;
	}

	public static bool GetScope_CivilianSettlementCharsOfTheChar<TKey, TValue>(BaseGameDataObject sourceObject, IDictionary<TKey, TValue> targetCollection, List<BaseGameDataObject> influencedObjects) where TKey : unmanaged where TValue : BaseGameDataObject
	{
		GameData.Domains.Character.Character character = (GameData.Domains.Character.Character)sourceObject;
		short settlementId = character.GetOrganizationInfo().SettlementId;
		CivilianSettlement civilianSettlement = DomainManager.Organization.GetElement_CivilianSettlements(settlementId);
		OrgMemberCollection members = civilianSettlement.GetMembers();
		IDictionary<int, CivilianSettlementCharacter> civilianSettlementChars = (IDictionary<int, CivilianSettlementCharacter>)targetCollection;
		for (sbyte grade = 0; grade < 9; grade++)
		{
			HashSet<int> gradeMembers = members.GetMembers(grade);
			foreach (int charId in gradeMembers)
			{
				influencedObjects.Add(civilianSettlementChars[charId]);
			}
		}
		return false;
	}

	public static bool GetScope_CharacterAffectedByTheSpecialEffects(BaseGameDataObject sourceObject, List<BaseGameDataObject> influencedObjects)
	{
		AffectedData affectedData = (AffectedData)sourceObject;
		int charId = affectedData.GetId();
		influencedObjects.Add(DomainManager.Character.GetElement_Objects(charId));
		return false;
	}

	public static bool GetScope_CombatSkillsOfTheCharacterAffectedByTheSpecialEffects(BaseGameDataObject sourceObject, List<BaseGameDataObject> influencedObjects)
	{
		AffectedData affectedData = (AffectedData)sourceObject;
		int charId = affectedData.GetId();
		Dictionary<short, GameData.Domains.CombatSkill.CombatSkill> combatSkills = DomainManager.CombatSkill.GetCharCombatSkills(charId);
		foreach (KeyValuePair<short, GameData.Domains.CombatSkill.CombatSkill> item in combatSkills)
		{
			influencedObjects.Add(item.Value);
		}
		return false;
	}

	public static bool GetScope_WeaponsOfTheCharacterAffectedByTheSpecialEffects(BaseGameDataObject sourceObject, List<BaseGameDataObject> influencedObjects)
	{
		AffectedData affectedData = (AffectedData)sourceObject;
		int charId = affectedData.GetId();
		if (!DomainManager.Character.TryGetElement_Objects(charId, out var character))
		{
			return false;
		}
		GetScope_WeaponsOfTheChar(character, influencedObjects);
		return false;
	}

	public static bool GetScope_ArmorsOfTheCharacterAffectedByTheSpecialEffects(BaseGameDataObject sourceObject, List<BaseGameDataObject> influencedObjects)
	{
		AffectedData affectedData = (AffectedData)sourceObject;
		int charId = affectedData.GetId();
		if (!DomainManager.Character.TryGetElement_Objects(charId, out var character))
		{
			return false;
		}
		GetScope_ArmorsOfTheChar(character, influencedObjects);
		return false;
	}

	public static bool GetScope_AccessoriesOfTheCharacterAffectedByTheSpecialEffects(BaseGameDataObject sourceObject, List<BaseGameDataObject> influencedObjects)
	{
		AffectedData affectedData = (AffectedData)sourceObject;
		int charId = affectedData.GetId();
		if (!DomainManager.Character.TryGetElement_Objects(charId, out var character))
		{
			return false;
		}
		GetScope_AccessoriesOfTheChar(character, influencedObjects);
		return false;
	}

	public static bool GetScope_CombatCharacterAffectedByTheSpecialEffects(BaseGameDataObject sourceObject, List<BaseGameDataObject> influencedObjects)
	{
		AffectedData affectedData = (AffectedData)sourceObject;
		int charId = affectedData.GetId();
		if (DomainManager.Combat.TryGetElement_CombatCharacterDict(charId, out var influencedObject))
		{
			influencedObjects.Add(influencedObject);
		}
		return false;
	}

	public static bool GetScope_CombatSkillDataAffectedByTheSpecialEffects(BaseGameDataObject sourceObject, List<BaseGameDataObject> influencedObjects)
	{
		AffectedData affectedData = (AffectedData)sourceObject;
		int charId = affectedData.GetId();
		if (DomainManager.Combat.TryGetElement_CombatCharacterDict(charId, out var combatChar))
		{
			foreach (CombatSkillKey combatSkillKey in combatChar.GetCombatSkillKeys())
			{
				if (DomainManager.Combat.TryGetCombatSkillData(combatSkillKey.CharId, combatSkillKey.SkillTemplateId, out var combatSkillData))
				{
					influencedObjects.Add(combatSkillData);
				}
			}
		}
		return false;
	}

	public static bool GetScope_CombatSkillsAffectedByPowerChangeInCombat(List<BaseGameDataObject> influencedObjects)
	{
		List<CombatSkillKey> skillKeys = ObjectPool<List<CombatSkillKey>>.Instance.Get();
		skillKeys.Clear();
		skillKeys.AddRange(DomainManager.Combat.GetAllSkillPowerReduceInCombat().Keys);
		skillKeys.AddRange(DomainManager.Combat.GetAllSkillPowerAddInCombat().Keys);
		for (int i = 0; i < skillKeys.Count; i++)
		{
			influencedObjects.Add(DomainManager.CombatSkill.GetElement_CombatSkills(skillKeys[i]));
		}
		ObjectPool<List<CombatSkillKey>>.Instance.Return(skillKeys);
		return false;
	}

	public static bool GetScope_CombatSkillsAffectedByPowerReplaceInCombat(List<BaseGameDataObject> influencedObjects)
	{
		List<CombatSkillKey> skillKeys = ObjectPool<List<CombatSkillKey>>.Instance.Get();
		skillKeys.Clear();
		skillKeys.AddRange(DomainManager.Combat.GetAllSkillPowerReplaceInCombat().Keys);
		for (int i = 0; i < skillKeys.Count; i++)
		{
			influencedObjects.Add(DomainManager.CombatSkill.GetElement_CombatSkills(skillKeys[i]));
		}
		ObjectPool<List<CombatSkillKey>>.Instance.Return(skillKeys);
		return false;
	}

	public static bool GetScope_CombatSkillsAffectedByCombatSkillDataInCombat(BaseGameDataObject sourceObject, List<BaseGameDataObject> influencedObjects)
	{
		CombatSkillData combatSkillData = (CombatSkillData)sourceObject;
		influencedObjects.Add(DomainManager.CombatSkill.GetElement_CombatSkills(combatSkillData.GetId()));
		return false;
	}

	public static bool GetScope_TaiwuAndGearMates(List<BaseGameDataObject> influencedObjects)
	{
		GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
		influencedObjects.Add(taiwuChar);
		List<GameData.Domains.Character.Character> gearMates = DomainManager.Extra.GetAllGearMateCharacter();
		foreach (GameData.Domains.Character.Character gearMate in gearMates)
		{
			influencedObjects.Add(gearMate);
		}
		return false;
	}
}
