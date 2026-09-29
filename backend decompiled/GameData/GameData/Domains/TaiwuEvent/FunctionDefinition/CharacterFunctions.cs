using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Config;
using GameData.Common;
using GameData.Domains.Character;
using GameData.Domains.Character.Ai;
using GameData.Domains.Character.Ai.GeneralAction.TeachRandom;
using GameData.Domains.Character.Creation;
using GameData.Domains.Character.Display;
using GameData.Domains.Character.Filters;
using GameData.Domains.Character.ParallelModifications;
using GameData.Domains.Information;
using GameData.Domains.Information.Collection;
using GameData.Domains.Item;
using GameData.Domains.Item.Display;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.Organization;
using GameData.Domains.Taiwu.Profession;
using GameData.Domains.TaiwuEvent.DisplayEvent;
using GameData.Domains.TaiwuEvent.EventHelper;
using GameData.Domains.World.Display;
using GameData.Domains.World.Notification;
using GameData.GameDataBridge;
using GameData.Utilities;

namespace GameData.Domains.TaiwuEvent.FunctionDefinition;

public class CharacterFunctions
{
	[EventFunction(963)]
	private static bool CharacterHasSpecialAvatar(EventScriptRuntime runtime, GameData.Domains.Character.Character character)
	{
		CharacterItem itemOrDefault = Config.Character.Instance.GetItemOrDefault(character.GetTemplateId());
		int result;
		if (itemOrDefault != null)
		{
			string fixedAvatarName = itemOrDefault.FixedAvatarName;
			if (fixedAvatarName != null)
			{
				result = ((fixedAvatarName.Length > 0) ? 1 : 0);
				goto IL_002a;
			}
		}
		result = 0;
		goto IL_002a;
		IL_002a:
		return (byte)result != 0;
	}

	[EventFunction(18)]
	private unsafe static void SpecifyCurrMainAttribute(EventScriptRuntime runtime, GameData.Domains.Character.Character character, sbyte mainAttributeType, int value)
	{
		MainAttributes mainAttributes = character.GetCurrMainAttributes();
		mainAttributes.Items[mainAttributeType] = (short)value;
		character.SetCurrMainAttributes(mainAttributes, runtime.Context);
	}

	[EventFunction(19)]
	private static void ChangeCurrMainAttribute(EventScriptRuntime runtime, GameData.Domains.Character.Character character, sbyte mainAttributeType, int delta)
	{
		character.ChangeCurrMainAttribute(runtime.Context, mainAttributeType, delta);
		InstantNotificationCollection collection = DomainManager.World.GetInstantNotificationCollection();
		short referencedType = (short)(mainAttributeType + 0);
		if (delta > 0)
		{
			collection.AddMainAttributeRecovered(character.GetId(), referencedType, delta);
		}
		else if (delta < 0)
		{
			collection.AddMainAttributeConsumed(character.GetId(), referencedType, -delta);
		}
	}

	[EventFunction(20)]
	private static void SpecifyInjury(EventScriptRuntime runtime, GameData.Domains.Character.Character character, sbyte bodyPartType, bool isInner, int value)
	{
		if (bodyPartType < 0)
		{
			bodyPartType = (sbyte)runtime.Context.Random.Next(7);
		}
		value = Math.Clamp(value, 0, 6);
		Injuries injuries = character.GetInjuries();
		injuries.Set(bodyPartType, isInner, (sbyte)value);
		character.SetInjuries(injuries, runtime.Context);
	}

	[EventFunction(21)]
	private static void ChangeInjury(EventScriptRuntime runtime, GameData.Domains.Character.Character character, sbyte bodyPartType, bool isInner, int delta)
	{
		if (bodyPartType < 0)
		{
			bodyPartType = (sbyte)runtime.Context.Random.Next(7);
		}
		delta = Math.Clamp(delta, 0, 6);
		character.ChangeInjury(runtime.Context, bodyPartType, isInner, (sbyte)delta);
	}

	[EventFunction(22)]
	private static void ClearInjuries(EventScriptRuntime runtime, GameData.Domains.Character.Character character)
	{
		Injuries injuries = character.GetInjuries();
		injuries.Initialize();
		character.SetInjuries(injuries, runtime.Context);
	}

	[EventFunction(839)]
	private static void HealAllDefeatMark(EventScriptRuntime runtime, bool enemy)
	{
		DomainManager.Combat.GmCmd_HealAllDefeatMark(runtime.Context, !enemy);
	}

	[EventFunction(23)]
	private static void SpecifyPoisoned(EventScriptRuntime runtime, GameData.Domains.Character.Character character, sbyte poisonType, int value)
	{
		if (poisonType < 0)
		{
			poisonType = (sbyte)runtime.Context.Random.Next(6);
		}
		ref PoisonInts poisoned = ref character.GetPoisoned();
		poisoned[poisonType] = value;
		character.SetPoisoned(ref poisoned, runtime.Context);
	}

	[EventFunction(24)]
	private static void ChangePoisoned(EventScriptRuntime runtime, GameData.Domains.Character.Character character, sbyte poisonType, int level, int delta)
	{
		if (poisonType < 0)
		{
			poisonType = (sbyte)runtime.Context.Random.Next(6);
		}
		level = Math.Clamp(level, 0, 3);
		character.ChangePoisoned(runtime.Context, poisonType, (sbyte)level, delta);
	}

	[EventFunction(25)]
	private static void ClearPoisons(EventScriptRuntime runtime, GameData.Domains.Character.Character character)
	{
		ref PoisonInts poisoned = ref character.GetPoisoned();
		poisoned.Initialize();
		character.SetPoisoned(ref poisoned, runtime.Context);
	}

	[EventFunction(26)]
	private static void SpecifyDisorderOfQi(EventScriptRuntime runtime, GameData.Domains.Character.Character character, int value)
	{
		value = Math.Clamp(value, DisorderLevelOfQi.MinValue, DisorderLevelOfQi.MaxValue);
		character.SetDisorderOfQi((short)value, runtime.Context);
	}

	[EventFunction(27)]
	private static void ChangeDisorderOfQi(EventScriptRuntime runtime, GameData.Domains.Character.Character character, int delta)
	{
		character.ChangeDisorderOfQi(runtime.Context, delta);
	}

	[EventFunction(283)]
	private static void ClearDisorderOfQi(EventScriptRuntime runtime, GameData.Domains.Character.Character character)
	{
		character.SetDisorderOfQi(DisorderLevelOfQi.MinValue, runtime.Context);
	}

	[EventFunction(28)]
	private static void SpecifyHealth(EventScriptRuntime runtime, GameData.Domains.Character.Character character, int value)
	{
		value = Math.Clamp(value, 0, character.GetLeftMaxHealth());
		character.SetHealth((short)value, runtime.Context);
	}

	[EventFunction(29)]
	private static void ChangeHealth(EventScriptRuntime runtime, GameData.Domains.Character.Character character, int delta)
	{
		character.ChangeHealth(runtime.Context, delta);
	}

	[EventFunction(284)]
	private static void RecoverHealth(EventScriptRuntime runtime, GameData.Domains.Character.Character character)
	{
		short leftMaxHealth = character.GetLeftMaxHealth();
		character.SetHealth(leftMaxHealth, runtime.Context);
	}

	[EventFunction(30)]
	private static void SpecifyHappiness(EventScriptRuntime runtime, GameData.Domains.Character.Character character, int value)
	{
		value = Math.Clamp(value, -119, 119);
		character.SetHappiness((sbyte)value, runtime.Context);
	}

	[EventFunction(570)]
	private static int GetHappiness(EventScriptRuntime runtime, GameData.Domains.Character.Character character)
	{
		return character.GetHappiness();
	}

	[EventFunction(573)]
	private static int GetCharacterGrade(EventScriptRuntime runtime, GameData.Domains.Character.Character character)
	{
		return character.GetOrganizationInfo().Grade;
	}

	[EventFunction(31)]
	private static void ChangeHappiness(EventScriptRuntime runtime, GameData.Domains.Character.Character character, int delta)
	{
		character.ChangeHappiness(runtime.Context, delta);
		if (DomainManager.Taiwu.IsInGroup(character.GetId()))
		{
			InstantNotificationCollection collection = DomainManager.World.GetInstantNotificationCollection();
			if (delta > 0)
			{
				collection.AddHappinessIncreased(character.GetId());
			}
			else if (delta < 0)
			{
				collection.AddHappinessDecreased(character.GetId());
			}
		}
	}

	[EventFunction(32)]
	private static void SpecifyFavorabilities(EventScriptRuntime runtime, GameData.Domains.Character.Character self, GameData.Domains.Character.Character target, int selfToTarget, int targetToSelf)
	{
		DomainManager.Character.DirectlySetFavorabilities(runtime.Context, self.GetId(), target.GetId(), (short)selfToTarget, (short)targetToSelf);
	}

	[EventFunction(33)]
	private static void ChangeFavorability(EventScriptRuntime runtime, GameData.Domains.Character.Character self, GameData.Domains.Character.Character target, int delta, short type = -1)
	{
		int selfCharId = self.GetId();
		int targetCharId = target.GetId();
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		byte selfCreatingType = self.GetCreatingType();
		byte targetCreatingType = target.GetCreatingType();
		if (selfCreatingType == 0 || targetCreatingType == 0)
		{
			if (selfCharId != taiwuCharId && targetCharId != taiwuCharId)
			{
				throw new InvalidOperationException($"Failed to create relation between {self} and {target}: fixed character can only create relation with taiwu.");
			}
			int actualDelta = DomainManager.Character.CalcFavorabilityDelta(selfCharId, targetCharId, delta, type);
			DomainManager.Character.DirectlyChangeFavorabilityOptional(runtime.Context, self, target, actualDelta, type);
		}
		else
		{
			DomainManager.Character.ChangeFavorabilityOptional(runtime.Context, self, target, delta, type);
		}
		DomainManager.Character.AddFavorabilityChangeInstantNotification(self, target, delta > 0);
		if (target.IsTaiwu())
		{
			DomainManager.TaiwuEvent.RecordFavorabilityToTaiwuChanged(selfCharId, (short)delta);
		}
	}

	[EventFunction(34)]
	private static void AddFeature(EventScriptRuntime runtime, GameData.Domains.Character.Character character, short featureId, bool removeMutexFeature)
	{
		character.AddFeature(runtime.Context, featureId, removeMutexFeature);
	}

	[EventFunction(35)]
	private static void RemoveFeature(EventScriptRuntime runtime, GameData.Domains.Character.Character character, short featureId)
	{
		character.RemoveFeature(runtime.Context, featureId);
	}

	[EventFunction(36)]
	private static void AddKidnappedCharacter(EventScriptRuntime runtime, GameData.Domains.Character.Character character, GameData.Domains.Character.Character kidnappedChar, ItemKey ropeItemKey)
	{
		if (character.GetKidnapperId() < 0)
		{
			int kidnapperId = character.GetId();
			int kidnappedCharId = kidnappedChar.GetId();
			int srcKidnapperId = kidnappedChar.GetKidnapperId();
			if (srcKidnapperId == kidnapperId)
			{
				DomainManager.Character.ChangeKidnappedCharacterRope(runtime.Context, kidnapperId, kidnappedCharId, ropeItemKey);
			}
			else if (srcKidnapperId >= 0)
			{
				KidnappedCharacterList kidnappedCharacterList = DomainManager.Character.GetKidnappedCharacters(srcKidnapperId);
				int index = kidnappedCharacterList.IndexOf(kidnappedCharId);
				KidnappedCharacter kidnappedCharacter = kidnappedCharacterList.Get(index);
				DomainManager.Character.TransferKidnappedCharacter(runtime.Context, kidnapperId, srcKidnapperId, kidnappedCharacter);
			}
			else
			{
				DomainManager.Character.AddKidnappedCharacter(runtime.Context, character, kidnappedChar, ropeItemKey);
			}
		}
	}

	[EventFunction(37)]
	private static void RemoveKidnappedCharacter(EventScriptRuntime runtime, GameData.Domains.Character.Character character, GameData.Domains.Character.Character kidnappedChar, bool isEscape)
	{
		DomainManager.Character.RemoveKidnappedCharacter(runtime.Context, character.GetId(), kidnappedChar.GetId(), isEscape);
	}

	[EventFunction(38)]
	private static void JoinGroup(EventScriptRuntime runtime, GameData.Domains.Character.Character character, GameData.Domains.Character.Character leader)
	{
		int charId = character.GetId();
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		if (charId != taiwuCharId && character.GetKidnapperId() < 0 && leader.GetKidnapperId() < 0)
		{
			if (character.GetLeaderId() >= 0)
			{
				DomainManager.Character.LeaveGroup(runtime.Context, character);
			}
			if (leader.GetId() == taiwuCharId || leader.GetLeaderId() == taiwuCharId)
			{
				DomainManager.Taiwu.JoinGroup(runtime.Context, charId);
				runtime.Current.RegisterToShowGetCharacter(character.GetId(), EObtainType.Teammate);
			}
			else
			{
				DomainManager.Character.JoinGroup(runtime.Context, character, leader);
			}
		}
	}

	[EventFunction(39)]
	private static void LeaveGroup(EventScriptRuntime runtime, GameData.Domains.Character.Character character, bool bringWard)
	{
		DomainManager.Character.LeaveGroup(runtime.Context, character, bringWard);
	}

	[EventFunction(40)]
	private static void KillCharacter(EventScriptRuntime runtime, GameData.Domains.Character.Character victim, GameData.Domains.Character.Character killer, short deathType)
	{
		if (victim.GetCreatingType() == 1)
		{
			if (deathType == 11)
			{
				if (DomainManager.Character.IsTemporaryIntelligentCharacter(victim.GetId()))
				{
					DomainManager.Character.ConvertTemporaryIntelligentCharacter(runtime.Context, victim);
				}
				DomainManager.Extra.ArchiveKilledByLongYufuCharacter(runtime.Context, victim);
			}
			if (DomainManager.Character.IsTemporaryIntelligentCharacter(victim.GetId()))
			{
				DomainManager.Character.RemoveTemporaryIntelligentCharacter(runtime.Context, victim);
				return;
			}
			if (killer != null && killer.GetId() == DomainManager.Taiwu.GetTaiwuCharId())
			{
				GameData.Domains.TaiwuEvent.EventHelper.EventHelper.KillAddTianJieFuLu(killer.GetId(), victim);
			}
			DomainManager.Character.MakeCharacterDead(runtime.Context, victim, deathType, new CharacterDeathInfo(victim.GetValidLocation())
			{
				KillerId = (killer?.GetId() ?? (-1))
			});
		}
		else
		{
			GameData.Domains.TaiwuEvent.EventHelper.EventHelper.RemoveNonIntelligentCharacter(victim);
		}
	}

	[EventFunction(41)]
	private static void AddInventoryItem(EventScriptRuntime runtime, GameData.Domains.Character.Character character, ItemKey itemKey, int amount)
	{
		Tester.Assert(itemKey.IsValid());
		bool isStackable = ItemTemplateHelper.IsPureStackable(itemKey);
		if (amount > 1 && !isStackable)
		{
			throw new Exception($"ItemKey:{itemKey} is not Stackable,amount need equal 1");
		}
		character.AddInventoryItem(runtime.Context, itemKey, amount);
		if (character.IsTaiwu())
		{
			GameData.Domains.TaiwuEvent.EventHelper.EventHelper.AddSeniorityOnFindMaterialAdventure(itemKey);
		}
		if (character == DomainManager.Taiwu.GetTaiwu())
		{
			InstantNotificationCollection instantNotification = DomainManager.World.GetInstantNotifications();
			instantNotification.AddGetItem(character.GetId(), itemKey.ItemType, itemKey.TemplateId);
			runtime.Current.RegisterToShowGetItem(itemKey, amount);
		}
	}

	[EventFunction(65)]
	private static void RemoveInventoryItem(EventScriptRuntime runtime, GameData.Domains.Character.Character character, ItemKey itemKey, int amount, bool deleteItem)
	{
		Tester.Assert(itemKey.IsValid());
		if (character.GetInventory().Items.ContainsKey(itemKey))
		{
			character.RemoveInventoryItem(runtime.Context, itemKey, amount, deleteItem);
		}
		else
		{
			if (!ItemType.IsEquipmentItemType(itemKey.ItemType) || !character.UnequipItem(runtime.Context, itemKey))
			{
				throw new InvalidOperationException($"{itemKey} is not in {character}'s inventory.");
			}
			character.RemoveInventoryItem(runtime.Context, itemKey, amount, deleteItem);
		}
		if (character == DomainManager.Taiwu.GetTaiwu())
		{
			InstantNotificationCollection instantNotification = DomainManager.World.GetInstantNotifications();
			instantNotification.AddLoseItem(character.GetId(), itemKey.ItemType, itemKey.TemplateId);
		}
	}

	[EventFunction(335)]
	private static void RemoveInventoryItemByTemplateId(EventScriptRuntime runtime, GameData.Domains.Character.Character character, UnmanagedVariant<TemplateKey> itemTemplate, int amount, bool deleteItem)
	{
		ItemKey itemKey = character.GetInventory().GetInventoryItemKey(itemTemplate.Value.ItemType, itemTemplate.Value.TemplateId);
		if (!itemKey.IsValid() && ItemType.IsEquipmentItemType(itemTemplate.Value.ItemType))
		{
			itemKey = character.GetEquipment().FirstOrDefault((ItemKey equipment) => equipment.TemplateEquals(itemTemplate.Value.ItemType, itemTemplate.Value.TemplateId), ItemKey.Invalid);
		}
		RemoveInventoryItem(runtime, character, itemKey, amount, deleteItem);
	}

	[EventFunction(42)]
	private static void TransferInventoryItem(EventScriptRuntime runtime, GameData.Domains.Character.Character character, GameData.Domains.Character.Character destChar, ItemKey itemKey, int amount, bool favorAndDebt)
	{
		Tester.Assert(itemKey.HasTemplate);
		sbyte resourceType = ItemTemplateHelper.GetMiscResourceType(itemKey.ItemType, itemKey.TemplateId);
		if (resourceType == -1)
		{
			if (!itemKey.IsValid())
			{
				AdaptableLog.Info($"Creating item by template on transfer: {itemKey}.");
				itemKey = DomainManager.Item.CreateItem(runtime.Context, itemKey.ItemType, itemKey.TemplateId);
				character.AddInventoryItem(runtime.Context, itemKey, amount);
			}
			GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
			if (ItemType.IsEquipmentItemType(itemKey.ItemType))
			{
				character.UnequipItem(runtime.Context, itemKey);
			}
			DomainManager.Character.TransferInventoryItem(runtime.Context, character, destChar, itemKey, amount);
			if (favorAndDebt)
			{
				bool includeTaiwu = character == taiwu || destChar == taiwu;
				bool bothIntelligent = character.GetCreatingType() == 1 && destChar.GetCreatingType() == 1;
				int itemFavor = DomainManager.Item.GetBaseItem(itemKey).GetFavorabilityChange();
				if (!bothIntelligent)
				{
					int actualDelta = CharacterDomain.CalcFavorabilityDelta(destChar, character, itemFavor, -1);
					DomainManager.Character.DirectlyChangeFavorabilityOptional(runtime.Context, destChar, character, actualDelta, 1);
				}
				else if (!includeTaiwu)
				{
					DomainManager.Character.ChangeFavorabilityOptional(runtime.Context, destChar, character, itemFavor, 1);
				}
				else
				{
					DomainManager.Character.UpdateDebtByItemTransfer(runtime.Context, character, destChar, itemKey, amount, changeFavorAndHappiness: true);
				}
			}
			if (destChar == taiwu)
			{
				InstantNotificationCollection instantNotification = DomainManager.World.GetInstantNotifications();
				instantNotification.AddGetItem(destChar.GetId(), itemKey.ItemType, itemKey.TemplateId);
				runtime.Current.RegisterToShowGetItem(itemKey, amount);
			}
		}
		else
		{
			TransferCharacterResource(runtime, character, destChar, resourceType, amount, favorAndDebt);
		}
	}

	[EventFunction(129)]
	private static void SpecifyCharacterResource(EventScriptRuntime runtime, GameData.Domains.Character.Character character, sbyte resourceType, int value)
	{
		character.SpecifyResource(runtime.Context, resourceType, value);
	}

	[EventFunction(525)]
	private static void ChangeCharacterExp(EventScriptRuntime runtime, GameData.Domains.Character.Character character, int delta)
	{
		character.ChangeExp(runtime.Context, delta);
	}

	[EventFunction(66)]
	private static void ChangeCharacterResource(EventScriptRuntime runtime, GameData.Domains.Character.Character character, sbyte resourceType, int delta)
	{
		character.ChangeResource(runtime.Context, resourceType, delta);
		if (character == DomainManager.Taiwu.GetTaiwu())
		{
			InstantNotificationCollection instantNotification = DomainManager.World.GetInstantNotifications();
			if (delta > 0)
			{
				instantNotification.AddResourceIncreased(character.GetId(), resourceType, delta);
				runtime.Current.RegisterToShowGetResource(resourceType, delta);
			}
			else
			{
				instantNotification.AddResourceDecreased(character.GetId(), resourceType, -delta);
			}
		}
	}

	[EventFunction(679)]
	private static int GetCharacterResource(EventScriptRuntime runtime, GameData.Domains.Character.Character character, sbyte resourceType)
	{
		return character.GetResource(resourceType);
	}

	[EventFunction(130)]
	private static void TransferCharacterResource(EventScriptRuntime runtime, GameData.Domains.Character.Character character, GameData.Domains.Character.Character destChar, sbyte resourceType, int amount, bool favorAndDebt)
	{
		DomainManager.Character.TransferResource(runtime.Context, character, destChar, resourceType, amount);
		GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
		if (destChar == taiwuChar)
		{
			InstantNotificationCollection instantNotification = DomainManager.World.GetInstantNotifications();
			instantNotification.AddResourceIncreased(character.GetId(), resourceType, amount);
			runtime.Current.RegisterToShowGetResource(resourceType, amount);
		}
		else if (character == taiwuChar)
		{
			InstantNotificationCollection instantNotification2 = DomainManager.World.GetInstantNotifications();
			instantNotification2.AddResourceDecreased(character.GetId(), resourceType, amount);
		}
		if (favorAndDebt)
		{
			bool includeTaiwu = character == taiwuChar || destChar == taiwuChar;
			bool bothIntelligent = character.GetCreatingType() == 1 && destChar.GetCreatingType() == 1;
			short resourceFavor = AiHelper.GeneralActionConstants.GetResourceFavorabilityChange(resourceType, amount);
			if (!bothIntelligent)
			{
				DomainManager.Character.DirectlyChangeFavorabilityOptional(runtime.Context, destChar, character, resourceFavor, 1);
				return;
			}
			if (!includeTaiwu)
			{
				DomainManager.Character.ChangeFavorabilityOptional(runtime.Context, destChar, character, resourceFavor, 1);
				return;
			}
			ResourceInts resources = default(ResourceInts);
			resources.Initialize();
			resources[resourceType] = amount;
			DomainManager.Character.UpdateDebtByResourceTransfer(runtime.Context, character, destChar, resources, changeFavorAndHappiness: true);
		}
	}

	[EventFunction(789)]
	private static void SpecifyBaseCombatSkillQualification(EventScriptRuntime runtime, GameData.Domains.Character.Character character, sbyte combatSkillType, int value)
	{
		CombatSkillShorts qualifications = character.GetBaseCombatSkillQualifications();
		qualifications[combatSkillType] = (short)value;
		character.SetBaseCombatSkillQualifications(ref qualifications, runtime.Context);
	}

	[EventFunction(790)]
	private static void SpecifyBaseLifeSkillQualification(EventScriptRuntime runtime, GameData.Domains.Character.Character character, sbyte lifeSkillType, int value)
	{
		LifeSkillShorts qualifications = character.GetBaseLifeSkillQualifications();
		qualifications[lifeSkillType] = (short)value;
		character.SetBaseLifeSkillQualifications(ref qualifications, runtime.Context);
	}

	[EventFunction(43)]
	private static void ChangeCharBaseCombatSkillQualification(EventScriptRuntime runtime, GameData.Domains.Character.Character character, sbyte combatSkillType, int delta)
	{
		character.ChangeBaseCombatSkillQualification(runtime.Context, combatSkillType, delta);
	}

	[EventFunction(44)]
	private static void ChangeCharBaseLifeSkillQualification(EventScriptRuntime runtime, GameData.Domains.Character.Character character, sbyte lifeSkillType, int delta)
	{
		character.ChangeBaseLifeSkillQualification(runtime.Context, lifeSkillType, delta);
	}

	[EventFunction(45)]
	private static void LearnCombatSkill(EventScriptRuntime runtime, GameData.Domains.Character.Character character, short templateId)
	{
		DomainManager.Character.LearnCombatSkill(runtime.Context, character.GetId(), templateId, 0);
	}

	[EventFunction(46)]
	private static void LearnLifeSkill(EventScriptRuntime runtime, GameData.Domains.Character.Character character, short templateId)
	{
		DomainManager.Character.LearnLifeSkill(runtime.Context, character.GetId(), templateId, 0);
	}

	[EventFunction(111)]
	private static int GetCharacterFavorability(EventScriptRuntime runtime, GameData.Domains.Character.Character selfChar, GameData.Domains.Character.Character targetChar)
	{
		return DomainManager.Character.GetFavorability(selfChar.GetId(), targetChar.GetId());
	}

	[EventFunction(117)]
	private static void SetCharacterFollowTaiwu(EventScriptRuntime runtime, GameData.Domains.Character.Character character, int distance)
	{
		if (character.GetCreatingType() != 0)
		{
			AdaptableLog.Warning($"{character} is is not a fixed character thus cannot follow taiwu.");
		}
		else
		{
			DomainManager.Character.SetCharacterFollowTaiwu(runtime.Context, character.GetId(), distance);
		}
	}

	[EventFunction(120)]
	private static void CancelCharacterFollowTaiwu(EventScriptRuntime runtime, GameData.Domains.Character.Character character)
	{
		if (character.GetCreatingType() != 0)
		{
			AdaptableLog.Warning($"{character} is is not a fixed character thus cannot follow taiwu.");
		}
		else
		{
			DomainManager.Character.RemoveCharacterFollowTaiwu(runtime.Context, character.GetId());
		}
	}

	[EventFunction(127)]
	private static void FilterCharacterItem(EventScriptRuntime runtime, GameData.Domains.Character.Character character, string selectItemNameKey, sbyte itemType = -1, short itemSubType = -1, bool includeTransferable = false)
	{
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.FilterItemForCharacterByType(character.GetId(), selectItemNameKey, runtime.Current.ArgBox, itemType, itemSubType, includeTransferable, null, -1);
	}

	[EventFunction(132)]
	private static void RegisterToSelectItemSubTypes(EventScriptRuntime runtime, short itemSubType)
	{
		runtime.Current.RegisterToSelectItemSubTypes(itemSubType);
	}

	[EventFunction(133)]
	private static void RegisterToSelectItemTemplateIds(EventScriptRuntime runtime, UnmanagedVariant<TemplateKey> itemTemplate)
	{
		runtime.Current.RegisterToSelectItemTemplateIds(itemTemplate.Value.ItemType, itemTemplate.Value.TemplateId);
	}

	[EventFunction(134)]
	private static void RegisterToExcludeItemTemplateIds(EventScriptRuntime runtime, UnmanagedVariant<TemplateKey> itemTemplate)
	{
		runtime.Current.RegisterToExcludeItemTemplateIds(itemTemplate.Value.ItemType, itemTemplate.Value.TemplateId);
	}

	[EventFunction(534)]
	private static void RegisterToSelectItemGrade(EventScriptRuntime runtime, sbyte grade)
	{
		runtime.Current.RegisterToSelectItemGrades(grade);
	}

	[EventFunction(559)]
	private static void RegisterToSelectItemGroup(EventScriptRuntime runtime, UnmanagedVariant<TemplateKey> itemTemplate)
	{
		runtime.Current.RegisterToSelectItemGroups(itemTemplate.Value.ItemType, itemTemplate.Value.TemplateId);
	}

	[EventFunction(703)]
	private static void RegisterToSelectItemResourceType(EventScriptRuntime runtime, sbyte resourceType)
	{
		runtime.Current.RegisterToSelectItemResourceType(resourceType);
	}

	[EventFunction(704)]
	private static void RegisterToExcludeItemResourceType(EventScriptRuntime runtime, sbyte resourceType)
	{
		runtime.Current.RegisterToExcludeItemResourceType(resourceType);
	}

	[EventFunction(135)]
	private static void FilterCharacterItemByRegister(EventScriptRuntime runtime, GameData.Domains.Character.Character character, string selectItemNameKey, bool includeTransferable = false)
	{
		runtime.Current.FilterItemForCharacter(character, selectItemNameKey, includeTransferable);
	}

	[EventFunction(164)]
	private static void StartSetCharacterGivenName(EventScriptRuntime runtime, GameData.Domains.Character.Character character, int maxStrCount)
	{
		Tester.Assert(character.IsCreatedWithFixedTemplate());
		runtime.Current.ArgBox.Remove<string>("InputResult");
		EventInputRequestData inputData = new EventInputRequestData();
		inputData.DataKey = "InputResult";
		inputData.InputDataType = (sbyte)(character.IsGearMate ? 2 : 3);
		inputData.FullName = character.GetFullName();
		inputData.NumberRange = new int[2] { 1, maxStrCount };
		runtime.Current.ArgBox.Set("InputRequestData", inputData);
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.AddEventInListenWithActionName(runtime.Current.EventGuid, runtime.Current.ArgBox, "InputActionComplete");
	}

	[EventFunction(165)]
	private static void FinishSetCharacterGivenName(EventScriptRuntime runtime, GameData.Domains.Character.Character character)
	{
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.RemoveEventInListenWithActionName(runtime.Current.EventGuid, "InputActionComplete");
		string input = runtime.Current.ArgBox.GetString("InputResult");
		if (!string.IsNullOrEmpty(input))
		{
			Tester.Assert(character.IsCreatedWithFixedTemplate());
			GameData.Domains.TaiwuEvent.EventHelper.EventHelper.SetCharacterGivenName(character, input);
			Location location = character.GetLocation();
			if (location.IsValid())
			{
				MapBlockData mapBlockData = DomainManager.Map.GetBlock(location);
				DomainManager.Map.SetBlockData(runtime.Context, mapBlockData);
			}
		}
	}

	[EventFunction(739)]
	private static void StartSetCharacterName(EventScriptRuntime runtime, GameData.Domains.Character.Character character, int maxStrCount, int maxStrCountSurName)
	{
		Tester.Assert((character.GetFullName().Type & 1) != 0);
		runtime.Current.ArgBox.Remove<string>("InputResult" + EventInputRequestData.ExtraSurNameKey);
		runtime.Current.ArgBox.Remove<string>("InputResult");
		byte[] nameLengthConfig = GameData.Domains.TaiwuEvent.EventHelper.EventHelper.GetNameLengthConfig();
		byte givenNameMax = nameLengthConfig[1];
		byte surnameMax = nameLengthConfig[0];
		EventInputRequestData inputData = new EventInputRequestData();
		inputData.DataKey = "InputResult";
		inputData.InputDataType = 5;
		inputData.FullName = character.GetFullName();
		inputData.NumberRange = new int[4] { 1, givenNameMax, 1, surnameMax };
		runtime.Current.ArgBox.Set("InputRequestData", inputData);
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.AddEventInListenWithActionName(runtime.Current.EventGuid, runtime.Current.ArgBox, "InputActionComplete");
	}

	[EventFunction(740)]
	private static void FinishSetCharacterName(EventScriptRuntime runtime, GameData.Domains.Character.Character character)
	{
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.RemoveEventInListenWithActionName(runtime.Current.EventGuid, "InputActionComplete");
		string surName = runtime.Current.ArgBox.GetString("InputResult" + EventInputRequestData.ExtraSurNameKey);
		string givenName = runtime.Current.ArgBox.GetString("InputResult");
		if (!string.IsNullOrEmpty(surName) && !string.IsNullOrEmpty(givenName))
		{
			Tester.Assert((character.GetFullName().Type & 1) != 0);
			DataContext context = runtime.Context;
			int customSurNameId = DomainManager.World.RegisterCustomText(context, surName);
			int customGivenNameId = DomainManager.World.RegisterCustomText(context, givenName);
			FullName fullName = CharacterDomain.GenerateRandomHanName(context.Random, customSurNameId, -1, character.GetGender(), 0);
			fullName.SetCustomGivenName(customGivenNameId);
			character.SetFullName(fullName, context);
			Location location = character.GetLocation();
			if (location.IsValid())
			{
				MapBlockData mapBlockData = DomainManager.Map.GetBlock(location);
				DomainManager.Map.SetBlockData(context, mapBlockData);
			}
		}
	}

	[EventFunction(189)]
	private static void TakeRandomDamage(EventScriptRuntime runtime, GameData.Domains.Character.Character character, int damage)
	{
		character.TakeRandomDamage(runtime.Context, damage);
	}

	[EventFunction(359)]
	private static void ReduceRandomDamage(EventScriptRuntime runtime, GameData.Domains.Character.Character character, int reduceCount)
	{
		character.ReduceRandomDamage(runtime.Context, reduceCount);
	}

	[EventFunction(191)]
	private static int GetCharacterConsummateLevel(EventScriptRuntime runtime, GameData.Domains.Character.Character character)
	{
		return character.GetConsummateLevel();
	}

	[EventFunction(200)]
	private static void SpecifyXiangshuInfectionValue(EventScriptRuntime runtime, GameData.Domains.Character.Character character, int value)
	{
		value = (byte)Math.Clamp(value, 0, 200);
		character.SetXiangshuInfection((byte)value, runtime.Context);
		character.UpdateXiangshuInfectionState(runtime.Context);
	}

	[EventFunction(201)]
	private static void ChangeXiangshuInfectionValue(EventScriptRuntime runtime, GameData.Domains.Character.Character character, int delta)
	{
		byte value = character.GetXiangshuInfection();
		value = (byte)Math.Clamp(value + delta, 0, 200);
		character.SetXiangshuInfection(value, runtime.Context);
		character.UpdateXiangshuInfectionState(runtime.Context);
	}

	[EventFunction(205)]
	private static void SetCharacterMarriageStyleOne(EventScriptRuntime runtime, GameData.Domains.Character.Character character, bool set)
	{
		if (set)
		{
			DomainManager.TaiwuEvent.AppendMarriageLook1CharId(character.GetId());
		}
		else
		{
			DomainManager.TaiwuEvent.RemoveMarriageLook1CharId(character.GetId());
		}
	}

	[EventFunction(206)]
	private static void SetCharacterMarriageStyleTwo(EventScriptRuntime runtime, GameData.Domains.Character.Character character, bool set)
	{
		if (set)
		{
			DomainManager.TaiwuEvent.AppendMarriageLook2CharId(character.GetId());
		}
		else
		{
			DomainManager.TaiwuEvent.RemoveMarriageLook2CharId(character.GetId());
		}
	}

	[EventFunction(210)]
	private static int GetCharacterBySettlementGradeAndAge(EventScriptRuntime runtime, Settlement settlement, sbyte gradeLower, sbyte gradeUpper, sbyte ageGroupLower, sbyte ageGroupUpper)
	{
		List<int> characters = new List<int>();
		settlement.GetMembers().GetAllMembers(characters);
		for (int index = characters.Count - 1; index >= 0; index--)
		{
			int charId = characters[index];
			if (!DomainManager.Character.TryGetElement_Objects(charId, out var character))
			{
				characters.RemoveAt(index);
			}
			else
			{
				OrganizationInfo orgInfo = character.GetOrganizationInfo();
				if (orgInfo.Grade < gradeLower || orgInfo.Grade > gradeUpper)
				{
					characters.RemoveAt(index);
				}
				else
				{
					sbyte ageGroup = character.GetAgeGroup();
					if (ageGroup < ageGroupLower || ageGroup > ageGroupUpper)
					{
						characters.RemoveAt(index);
					}
				}
			}
		}
		return characters.GetRandomOrDefault(runtime.Context.Random, -1);
	}

	[EventFunction(238)]
	private static void AddJieqingMaskCharId(EventScriptRuntime runtime, GameData.Domains.Character.Character character)
	{
		DomainManager.TaiwuEvent.AddJieqingMaskCharId(character.GetId());
	}

	[EventFunction(239)]
	private static void RemoveJieqingMaskCharId(EventScriptRuntime runtime, GameData.Domains.Character.Character character)
	{
		DomainManager.TaiwuEvent.RemoveJieqingMaskCharId(character.GetId());
	}

	[EventFunction(242)]
	private unsafe static void DestroyEnemyNest(EventScriptRuntime runtime, short enemyNestId, sbyte behaviorType)
	{
		if (behaviorType < 0)
		{
			throw new ArgumentOutOfRangeException("behaviorType", behaviorType, "Parameter '{nameof(behaviorType)}' must be >= 0, but was {behaviorType}.");
		}
		DataContext context = runtime.Context;
		InstantNotificationCollection notificationCollection = DomainManager.World.GetInstantNotificationCollection();
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		int taiwuCharId = taiwu.GetId();
		EnemyNestItem enemyNestCfg = EnemyNest.Instance[enemyNestId];
		Config.Character instance = Config.Character.Instance;
		List<short> members = enemyNestCfg.Members;
		CharacterItem enemyLeaderCfg = instance[members[members.Count - 1]];
		short areaId = taiwu.GetLocation().AreaId;
		DomainManager.Adventure.ApplyDestroyEnemyNest(context, enemyNestId);
		DomainManager.Extra.ChangeAreaSpiritualDebt(context, areaId, enemyNestCfg.SpiritualDebtChange);
		taiwu.ChangeResource(context, 6, enemyNestCfg.MoneyReward);
		taiwu.ChangeResource(context, 7, enemyNestCfg.AuthorityReward);
		taiwu.ChangeExp(context, enemyNestCfg.ExpReward);
		switch (behaviorType)
		{
		case 0:
			taiwu.RecordFameAction(context, 40, -1, 5, jumpAccordingToTargetFame: false);
			DomainManager.Map.ChangeSettlementSafetyInArea(context, areaId, 1);
			notificationCollection.AddFameIncreased(taiwuCharId);
			break;
		case 1:
			taiwu.RecordFameAction(context, 38, -1, 5, jumpAccordingToTargetFame: false);
			DomainManager.Map.ChangeSettlementCultureInArea(context, areaId, 1);
			notificationCollection.AddFameIncreased(taiwuCharId);
			break;
		case 2:
			DomainManager.Map.ChangeSettlementSafetyInArea(context, areaId, 1);
			DomainManager.Map.ChangeSettlementCultureInArea(context, areaId, 1);
			break;
		case 3:
		{
			taiwu.RecordFameAction(context, 42, -1, 5, jumpAccordingToTargetFame: false);
			taiwu.ChangeHappiness(context, 3);
			int moneyGain = enemyLeaderCfg.Resources.Items[6];
			moneyGain = context.Random.Next(moneyGain * 5, moneyGain * 10 + 1);
			if (moneyGain > 0)
			{
				taiwu.ChangeResource(context, 6, moneyGain);
				notificationCollection.AddResourceIncreased(taiwuCharId, 6, moneyGain);
			}
			notificationCollection.AddFameDecreased(taiwuCharId);
			notificationCollection.AddHappinessIncreased(taiwuCharId);
			break;
		}
		case 4:
		{
			taiwu.RecordFameAction(context, 44, -1, 5, jumpAccordingToTargetFame: false);
			notificationCollection.AddFameDecreased(taiwuCharId);
			sbyte stateTemplateId = DomainManager.Map.GetStateTemplateIdByAreaId(areaId);
			sbyte orgTemplateId = MapState.Instance[stateTemplateId].SectID;
			sbyte gender = Gender.GetRandom(context.Random);
			short charTemplateId = OrganizationDomain.GetCharacterTemplateId(orgTemplateId, stateTemplateId, gender);
			OrganizationInfo orgInfo = taiwu.GetOrganizationInfo();
			orgInfo.Grade = 0;
			IntelligentCharacterCreationInfo info = new IntelligentCharacterCreationInfo(taiwu.GetLocation(), orgInfo, charTemplateId);
			info.BaseAttraction = (short)context.Random.Next(enemyLeaderCfg.BaseAttraction / 2, enemyLeaderCfg.BaseAttraction + 1);
			info.Age = (short)context.Random.Next(16, 25);
			GameData.Domains.Character.Character newCharacter = DomainManager.Character.CreateIntelligentCharacter(context, ref info);
			int newCharId = newCharacter.GetId();
			DomainManager.Character.CompleteCreatingCharacter(newCharId);
			newCharacter.AddFeature(context, 678);
			DomainManager.Character.ChangeFavorabilityOptional(context, newCharacter, taiwu, -10000, 0);
			DomainManager.Taiwu.JoinGroup(context, newCharId);
			GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.OpenGetItem_Character, new List<int> { newCharId }, (sbyte)14);
			break;
		}
		}
	}

	[EventFunction(298)]
	private static bool CheckJieQingInteractUnlock(EventScriptRuntime runtime)
	{
		return GameData.Domains.TaiwuEvent.EventHelper.EventHelper.IsSectSpecialInteractionUnlocked(13);
	}

	[EventFunction(299)]
	private static void JieQingInteractConfirmKill(EventScriptRuntime runtime, GameData.Domains.Character.Character target)
	{
		GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.HandleCombatResultKillEnemy(taiwuChar, target, isInPublic: false);
	}

	[EventFunction(300)]
	private static bool CharacterStarFortuneEnough(EventScriptRuntime runtime, GameData.Domains.Character.Character target)
	{
		return DomainManager.Extra.IsCharacterEligibleForJieqingSeizeFortune(target.GetId());
	}

	[EventFunction(315)]
	private static int CharacterGetAvailableEatingSlotsCount(EventScriptRuntime runtime, GameData.Domains.Character.Character character)
	{
		EatingItems eatingItems = character.GetEatingItems();
		return eatingItems.GetAvailableEatingSlotsCount(character.GetCurrMaxEatingSlotsCount());
	}

	[EventFunction(316)]
	private static void CharacterAddEatingItem(EventScriptRuntime runtime, GameData.Domains.Character.Character character, ItemKey itemKey, bool eatDuplicate = false)
	{
		if (eatDuplicate)
		{
			ItemKey duplicateItemKey = DomainManager.Item.CreateCopyOfItem(runtime.Context, itemKey);
			character.AddEatingItem(runtime.Context, duplicateItemKey);
			return;
		}
		character.RemoveInventoryItem(runtime.Context, itemKey, 1, deleteItem: false);
		character.AddEatingItem(runtime.Context, itemKey);
		if (character.IsTaiwu())
		{
			runtime.Current.UnregisterToShowGetItem(itemKey, 1);
		}
	}

	[EventFunction(810)]
	private static void ClearCharacterEatingItem(EventScriptRuntime runtime, GameData.Domains.Character.Character character)
	{
		character.ClearEatingItems(runtime.Context);
	}

	[EventFunction(809)]
	private static void ClearCharacterEatingItemByIndex(EventScriptRuntime runtime, GameData.Domains.Character.Character character, int index)
	{
		character.ClearSlotEatingItem(runtime.Context, index);
	}

	[EventFunction(544)]
	private static void MedicineExtraAddPercent(EventScriptRuntime runtime, ItemKey itemKey, int extraEffectPercent)
	{
		Tester.Assert(itemKey.IsValid());
		DomainManager.Item.TryAddMedicineExtraAddPercent(runtime.Context, itemKey.Id, extraEffectPercent);
	}

	[EventFunction(317)]
	private static void CharacterChangeCurrNeili(EventScriptRuntime runtime, GameData.Domains.Character.Character character, int changeValue)
	{
		character.ChangeCurrNeili(runtime.Context, changeValue);
	}

	[EventFunction(318)]
	private static void CharacterSetCurrNeili(EventScriptRuntime runtime, GameData.Domains.Character.Character character, int setValue)
	{
		character.SetCurrNeili(setValue, runtime.Context);
	}

	[EventFunction(597)]
	private static void ClearRegisterItemFilter(EventScriptRuntime runtime)
	{
		runtime.Current.ClearSelectItemRegisterData();
	}

	[EventFunction(321)]
	private static ItemKey ItemAddPoisonRandom(EventScriptRuntime runtime, ItemKey itemKey, sbyte grade)
	{
		List<int> medicineList = (from pair in Config.Medicine.Instance.RefNameMap
			where pair.Value >= 0 && Config.Medicine.Instance[pair.Value].Grade == grade && Config.Medicine.Instance[pair.Value].ItemSubType == 801
			select pair.Value).ToList();
		ItemBase itemBase = DomainManager.Item.GetBaseItem(itemKey);
		ItemBase newItemBase = DomainManager.Item.SetAttachedPoisons(runtime.Context, itemBase, (short)medicineList.GetRandom(runtime.Context.Random), add: true).item;
		return newItemBase.GetItemKey();
	}

	[EventFunction(324)]
	private static void TaiwuHealCharacter(EventScriptRuntime runtime, GameData.Domains.Character.Character character, string postAdventureEvent = null)
	{
		if (!string.IsNullOrEmpty(postAdventureEvent))
		{
			DomainManager.TaiwuEvent.SetListenerWithActionName(postAdventureEvent, runtime.ArgBox, "HealActionComplete");
		}
		List<int> doctorList = DomainManager.Taiwu.GetGroupCharIds().GetCollection().ToList();
		GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.StartHeal, doctorList, new List<int> { character.GetId() });
	}

	[EventFunction(319)]
	private static bool CharacterCheckNeiliType(EventScriptRuntime runtime, GameData.Domains.Character.Character character, int fiveElementsType)
	{
		sbyte neiliType = character.GetNeiliType();
		bool result = NeiliType.Instance[neiliType].FiveElements == fiveElementsType;
		if (runtime.RecordingConditionHints)
		{
			string elementTypeName = fiveElementsType switch
			{
				0 => LocalStringManager.Get(LanguageKey.LK_FiveElements_Type_0), 
				1 => LocalStringManager.Get(LanguageKey.LK_FiveElements_Type_1), 
				2 => LocalStringManager.Get(LanguageKey.LK_FiveElements_Type_2), 
				3 => LocalStringManager.Get(LanguageKey.LK_FiveElements_Type_3), 
				_ => LocalStringManager.Get(LanguageKey.LK_FiveElements_Type_4), 
			};
			runtime.RecordConditionHint(319, result, elementTypeName);
		}
		return result;
	}

	[EventFunction(322)]
	private static bool CharacterHaveInjury(EventScriptRuntime runtime, GameData.Domains.Character.Character character)
	{
		return character.GetInjuries().HasAnyInjury();
	}

	[EventFunction(323)]
	private static bool CharacterHavePoison(EventScriptRuntime runtime, GameData.Domains.Character.Character character)
	{
		return character.GetPoisoned().IsNonZero();
	}

	[EventFunction(333)]
	private static void StartShavingAction(EventScriptRuntime runtime, GameData.Domains.Character.Character character, GameData.Domains.Character.Character target, string afterEvent = null)
	{
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.StartShavingAction(character.GetId(), target.GetId(), afterEvent, runtime.ArgBox);
	}

	[EventFunction(249)]
	private static int GetCurrentFaith(EventScriptRuntime runtime)
	{
		return DomainManager.Character.GetFuyuFaith();
	}

	[EventFunction(250)]
	private static void GetFaithLevel(EventScriptRuntime runtime, GameData.Domains.Character.Character character, int value, string faithLv = null, string giftLv = null, string debtVal = null, string favorVal = null)
	{
		int faithLevel = GameData.Domains.TaiwuEvent.EventHelper.EventHelper.GetFuyuFaithLevel(character, value);
		if (!string.IsNullOrEmpty(faithLv))
		{
			runtime.Current.ArgBox.Set(faithLv, faithLevel);
		}
		if (!string.IsNullOrEmpty(giftLv))
		{
			runtime.Current.ArgBox.Set(giftLv, GameData.Domains.TaiwuEvent.EventHelper.EventHelper.GetFuyuFaithGiftLevelByLevel(character, faithLevel));
		}
		if (!string.IsNullOrEmpty(debtVal))
		{
			runtime.Current.ArgBox.Set(debtVal, GameData.Domains.TaiwuEvent.EventHelper.EventHelper.GetFuyuFaithDebtByLevel(character, faithLevel));
		}
		if (!string.IsNullOrEmpty(favorVal))
		{
			runtime.Current.ArgBox.Set(favorVal, GameData.Domains.TaiwuEvent.EventHelper.EventHelper.GetFuyuFaithFavorByLevel(character, faithLevel));
		}
	}

	[EventFunction(251)]
	private static int GetFuyuFaithTime(EventScriptRuntime runtime, GameData.Domains.Character.Character character)
	{
		return character.GetDarkAshCounter().Tips3;
	}

	[EventFunction(252)]
	private static void OpenFuyuFaithPanel(EventScriptRuntime runtime, GameData.Domains.Character.Character character)
	{
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.StartSelectFuyuFaithCount(runtime.Current.ArgBox, character);
	}

	[EventFunction(253)]
	private static void OpenFuyuGiftPanel(EventScriptRuntime runtime, GameData.Domains.Character.Character character, int grade, string itemKey)
	{
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.FilterItemForCharacterByType(character.GetId(), itemKey, runtime.Current.ArgBox, -1, -1, includeTransferable: false, new List<Predicate<ItemKey>>
		{
			(ItemKey itemKey2) => GameData.Domains.TaiwuEvent.EventHelper.EventHelper.GetItemGrade(itemKey2) <= grade
		}, -1);
		runtime.Current.ArgBox.Get("SelectItemInfo", out EventSelectItemData selectItemData);
		short itemTemplateId = ItemTemplateHelper.GetTemplateIdInGroup(12, 295, (sbyte)grade);
		selectItemData.CanSelectItemList.Add(new ItemDisplayData(12, itemTemplateId));
		ResourceInts resources = character.GetResources();
		for (int type = 0; type < 7; type++)
		{
			int amount = resources[type];
			if (amount > 0)
			{
				short templateId = Convert.ToInt16(type);
				ItemKey tmpItemKey = new ItemKey(12, 0, templateId, 0);
				ItemDisplayData itemData = new ItemDisplayData
				{
					Key = tmpItemKey,
					Amount = amount
				};
				selectItemData.CanSelectItemList.Add(itemData);
			}
		}
		selectItemData.ResourceMaxValue = GlobalConfig.FuyuResourceValueMax[Math.Clamp(grade, 0, GlobalConfig.FuyuResourceValueMax.Length)];
	}

	[EventFunction(254)]
	private static void ApplyFuyuFaith(EventScriptRuntime runtime, GameData.Domains.Character.Character character, int duration)
	{
		character.ExtendDarkAshWithFuyuFaith(runtime.Context, duration, DomainManager.LifeRecord.GetLifeRecordCollection());
	}

	[EventFunction(255)]
	private static int ReadSelectResultCount(EventScriptRuntime runtime)
	{
		return runtime.Current.ArgBox.GetInt("SelectCountResult");
	}

	[EventFunction(336)]
	private static void SelectFilterCharacterAgeGroup(EventScriptRuntime runtime, short operatorId, sbyte ageGroup, string saveKey)
	{
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.StartSelectTeammateAgeGroup(runtime.Current.ArgBox, new CharacterSelectFilter
		{
			FilterTemplateId = -1,
			SelectKey = saveKey
		}, includeTaiwu: true, operatorId, ageGroup, includeSpecial: false);
	}

	[EventFunction(342)]
	private static IntList GetTaiwuGroupList(EventScriptRuntime runtime, bool includeTaiwu, bool includeSpecial, bool includeMinor)
	{
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		IntList result = IntList.Create();
		result.Items.Clear();
		HashSet<int> groupCharIds = DomainManager.Taiwu.GetGroupCharIds().GetCollection();
		foreach (int charId in groupCharIds)
		{
			if (includeTaiwu || charId != taiwu.GetId())
			{
				GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
				if (includeMinor || character.GetAgeGroup() >= 2)
				{
					result.Items.Add(charId);
				}
			}
		}
		if (includeSpecial)
		{
			IReadOnlySet<int> specialGroup = DomainManager.Character.GetSpecialGroup(taiwu.GetId());
			result.Items.AddRange(specialGroup);
		}
		return result;
	}

	[EventFunction(343)]
	private static IntList CreateIntList(EventScriptRuntime runtime)
	{
		return IntList.Create();
	}

	[EventFunction(344)]
	private static IntList AddToIntList(EventScriptRuntime runtime, IntList list, int id, bool ignoreRepeated)
	{
		if (!list.Items.Contains(id) || ignoreRepeated)
		{
			list.Items.Add(id);
		}
		return list;
	}

	[EventFunction(425)]
	private static void AddListToIntList(EventScriptRuntime runtime, IntList list0, IntList list1, bool ignoreRepeated)
	{
		foreach (int item in list1.Items)
		{
			if (!list0.Items.Contains(item) || ignoreRepeated)
			{
				list0.Items.Add(item);
			}
		}
	}

	[EventFunction(629)]
	private static bool RemoveElementFromList(EventScriptRuntime runtime, IntList list, int id)
	{
		if (list.Items.Contains(id))
		{
			list.Items.Remove(id);
			return true;
		}
		return false;
	}

	[EventFunction(632)]
	private static bool TrySetListValue(EventScriptRuntime runtime, IntList list, int index, int value)
	{
		if (index >= list.Items.Count)
		{
			return false;
		}
		list.Items[index] = value;
		return false;
	}

	[EventFunction(633)]
	private static IntList SortListValueReturnIndexList(EventScriptRuntime runtime, IntList list, bool ascending)
	{
		IntList result = IntList.Create();
		var indexedList = list.Items.Select((int value, int index) => new
		{
			Value = value,
			OriginalIndex = index
		}).ToList();
		if (ascending)
		{
			indexedList.Sort((a, b) => a.Value.CompareTo(b.Value));
		}
		else
		{
			indexedList.Sort((a, b) => b.Value.CompareTo(a.Value));
		}
		result.Items.AddRange(indexedList.Select(item => item.OriginalIndex).ToList());
		return result;
	}

	[EventFunction(621)]
	private static void SelectCharacterWithFilter(EventScriptRuntime runtime, IntList list, short filterTemplateId, string saveKey)
	{
		EventArgBox argBox = runtime.ArgBox;
		if (!argBox.Get("SelectCharacterData", out EventSelectCharacterData data))
		{
			data = new EventSelectCharacterData();
			argBox.Set("SelectCharacterData", data);
		}
		if (data.FilterList == null)
		{
			data.FilterList = new List<CharacterSelectFilter>();
		}
		CharacterSelectFilter filter = new CharacterSelectFilter
		{
			FilterTemplateId = -1,
			SelectKey = saveKey,
			AvailableCharactersDisplayDataList = new List<CharacterDisplayData>()
		};
		if (filterTemplateId >= 0)
		{
			List<Predicate<GameData.Domains.Character.Character>> predicates = ObjectPool<List<Predicate<GameData.Domains.Character.Character>>>.Instance.Get();
			GameData.Domains.Character.Filters.CharacterFilterRules.ToPredicates(filterTemplateId, predicates, DomainManager.Taiwu.GetTaiwu().GetLocation());
			foreach (int charId in list.Items)
			{
				if (DomainManager.Character.TryGetElement_Objects(charId, out var character) && CharacterMatchers.MatchAll(character, predicates))
				{
					CharacterDisplayData displayData = DomainManager.Character.GetCharacterDisplayData(charId);
					filter.AvailableCharactersDisplayDataList.Add(displayData);
				}
			}
		}
		else
		{
			foreach (int charId2 in list.Items)
			{
				CharacterDisplayData displayData2 = DomainManager.Character.GetCharacterDisplayData(charId2);
				filter.AvailableCharactersDisplayDataList.Add(displayData2);
			}
		}
		data.FilterList.Add(filter);
	}

	[EventFunction(345)]
	private static void SelectCharacter(EventScriptRuntime runtime, IntList list, string saveKey)
	{
		SelectCharacterWithFilter(runtime, list, -1, saveKey);
	}

	[EventFunction(360)]
	private unsafe static void EditCharBaseNeiliProportionOfFiveElements(EventScriptRuntime runtime, GameData.Domains.Character.Character character, int metal = 0, int wood = 0, int water = 0, int fire = 0, int earth = 0)
	{
		NeiliProportionOfFiveElements fiveElements = new NeiliProportionOfFiveElements
		{
			Items = 
			{
				FixedElementField = (sbyte)metal
			}
		};
		fiveElements.Items[1] = (sbyte)wood;
		fiveElements.Items[2] = (sbyte)water;
		fiveElements.Items[3] = (sbyte)fire;
		fiveElements.Items[4] = (sbyte)earth;
		sbyte delta = (sbyte)(fiveElements.Sum() - 100);
		int unchangedCount = 0;
		for (int i = 0; i < 5; i++)
		{
			if (fiveElements.Items[i] == 0)
			{
				unchangedCount++;
			}
		}
		if (unchangedCount == 0)
		{
			unchangedCount = 5;
		}
		int avgDelta = delta / unchangedCount;
		int remDelta = delta - avgDelta * unchangedCount;
		for (int j = 0; j < 5; j++)
		{
			if (fiveElements.Items[j] == 0 || unchangedCount == 5)
			{
				ref sbyte reference = ref fiveElements.Items[j];
				reference -= (sbyte)avgDelta;
			}
		}
		fiveElements.Items[0] -= (sbyte)remDelta;
		DomainManager.Character.GmCmd_SetCharBaseNeiliProportionOfFiveElements(runtime.Context, character.GetId(), fiveElements);
	}

	[EventFunction(364)]
	private static void CreateIntelligentCharacterWithQualificationBonusWithReturn(EventScriptRuntime runtime, sbyte gender, bool hasLifeSkillAdjustBonus, bool hasCombatSkillAdjustBonus, string saveKey)
	{
		int charId = GameData.Domains.TaiwuEvent.EventHelper.EventHelper.CreateIntelligentCharacterWithQualificationBonusWithReturn(gender, hasLifeSkillAdjustBonus, hasCombatSkillAdjustBonus);
		runtime.ArgBox.Set(saveKey, charId);
	}

	[EventFunction(377)]
	private static int GetCharacterFavorabilityType(EventScriptRuntime runtime, GameData.Domains.Character.Character character, GameData.Domains.Character.Character relatedChar)
	{
		return DomainManager.Character.GetFavorabilityType(character.GetId(), relatedChar.GetId());
	}

	[EventFunction(566)]
	private static int GetCharacterBehaviorType(EventScriptRuntime runtime, GameData.Domains.Character.Character character)
	{
		return character.GetBehaviorType();
	}

	[EventFunction(384)]
	private static void DeallocateNeili(EventScriptRuntime runtime, GameData.Domains.Character.Character character, byte neiliAllocationType)
	{
		DomainManager.Character.DeallocateNeili(runtime.Context, character.GetId(), neiliAllocationType);
	}

	[EventFunction(385)]
	private static void AllocateNeili(EventScriptRuntime runtime, GameData.Domains.Character.Character character, byte neiliAllocationType)
	{
		DomainManager.Character.AllocateNeili(runtime.Context, character.GetId(), neiliAllocationType);
	}

	[EventFunction(386)]
	private static int CharacterGetCurrNeili(EventScriptRuntime runtime, GameData.Domains.Character.Character character)
	{
		return character.GetCurrNeili();
	}

	[EventFunction(394)]
	private static void TemporarilyChangeExtraNeiliAllocation(EventScriptRuntime runtime, GameData.Domains.Character.Character character, byte neiliAllocationType, short delta)
	{
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.TemporarilyChangeExtraNeiliAllocation(character, neiliAllocationType, delta);
	}

	[EventFunction(395)]
	private static void CharacterRevertAllTemporaryModifications(EventScriptRuntime runtime, GameData.Domains.Character.Character character)
	{
		DomainManager.Character.RevertAllTemporaryModifications(runtime.Context, character);
	}

	[EventFunction(396)]
	private static void OpenDriveWugKingUi(EventScriptRuntime runtime, GameData.Domains.Character.Character character)
	{
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.AddDisplayEventWugKingDrive(character);
	}

	[EventFunction(406)]
	private static int GetCharacterPersonalityType(EventScriptRuntime runtime, GameData.Domains.Character.Character character, sbyte personalityType)
	{
		return character.GetPersonality(personalityType);
	}

	[EventFunction(407)]
	private static int GetCharacterLifeSkillAttainment(EventScriptRuntime runtime, GameData.Domains.Character.Character character, sbyte lifeSkillType)
	{
		return character.GetLifeSkillAttainment(lifeSkillType);
	}

	[EventFunction(409)]
	private static int CreateRandomEnemyWithGender(EventScriptRuntime runtime, short characterTemplateId, sbyte gender)
	{
		RandomEnemyCreationInfo randomEnemyCreationInfo = new RandomEnemyCreationInfo();
		randomEnemyCreationInfo.Gender = gender;
		RandomEnemyCreationInfo creationInfo = randomEnemyCreationInfo;
		GameData.Domains.Character.Character character = DomainManager.Character.CreateRandomEnemy(runtime.Context, characterTemplateId, isTemporary: true, ref creationInfo);
		int id = character.GetId();
		DomainManager.Character.CompleteCreatingCharacter(id);
		return id;
	}

	[EventFunction(850)]
	private static ItemKey GetInventoryItem(EventScriptRuntime runtime, GameData.Domains.Character.Character character, UnmanagedVariant<TemplateKey> templateKey)
	{
		return character.GetInventory().GetInventoryItemKey(templateKey.Value.ItemType, templateKey.Value.TemplateId);
	}

	[EventFunction(440)]
	private static ItemKey GetRandomInventoryItem(EventScriptRuntime runtime, GameData.Domains.Character.Character character, sbyte itemType, short itemSubType, sbyte grade)
	{
		List<ItemKey> itemKeys = new List<ItemKey>();
		foreach (ItemKey itemKey in character.GetInventory().Items.Keys)
		{
			if ((itemType == -1 || itemType == itemKey.ItemType) && (itemSubType == -1 || ItemTemplateHelper.GetItemSubType(itemKey.ItemType, itemKey.TemplateId) == itemSubType) && (grade == -1 || ItemTemplateHelper.GetGrade(itemKey.ItemType, itemKey.TemplateId) == grade) && ItemTemplateHelper.IsTransferable(itemKey.ItemType, itemKey.TemplateId))
			{
				itemKeys.Add(itemKey);
			}
		}
		return itemKeys.GetRandomOrDefault(runtime.Context.Random, ItemKey.Invalid);
	}

	[EventFunction(441)]
	private static sbyte GetStealActionPhase(EventScriptRuntime runtime, GameData.Domains.Character.Character stealer, GameData.Domains.Character.Character targetChar, ItemKey itemKey)
	{
		int alert = targetChar.GetItemAlertFactor(itemKey, 1);
		return stealer.GetStealActionPhase(runtime.Context.Random, targetChar, alert, showCheckAnim: true);
	}

	[EventFunction(540)]
	private static sbyte GetPoisonActionPhase(EventScriptRuntime runtime, GameData.Domains.Character.Character self, GameData.Domains.Character.Character target)
	{
		return self.GetPoisonActionPhase(runtime.Context.Random, target, 100, showCheckAnim: true);
	}

	[EventFunction(541)]
	private static sbyte GetPlotHarmActionPhase(EventScriptRuntime runtime, GameData.Domains.Character.Character self, GameData.Domains.Character.Character target)
	{
		return self.GetPlotHarmActionPhase(runtime.Context.Random, target, 100, showCheckAnim: true);
	}

	[EventFunction(542)]
	private static void HandlePoisonAction(EventScriptRuntime runtime, GameData.Domains.Character.Character self, GameData.Domains.Character.Character target)
	{
		DomainManager.Character.HandlePoisonAction(runtime.Context, self, target, ItemKey.Invalid, -1);
	}

	[EventFunction(543)]
	private static void HandlePlotHarmAction(EventScriptRuntime runtime, GameData.Domains.Character.Character self, GameData.Domains.Character.Character target)
	{
		DomainManager.Character.HandlePlotHarmAction(runtime.Context, self, target, ItemKey.Invalid, -1);
	}

	[EventFunction(494)]
	private static IntList GetTaiwuKidnappedCharacterList(EventScriptRuntime runtime)
	{
		IntList result = IntList.Create();
		int taiwuId = DomainManager.Taiwu.GetTaiwuCharId();
		if (DomainManager.Character.TryGetKidnappedCharacters(taiwuId, out var kidnappedCharacterList))
		{
			result.Items.AddRange(from e in kidnappedCharacterList.GetCollection()
				select e.CharId);
		}
		return result;
	}

	[EventFunction(526)]
	private unsafe static bool TaiwuReadingBook(EventScriptRuntime runtime, ItemKey itemKey, int readCount, bool attributeCost)
	{
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		MainAttributes mainAttributes = taiwu.GetCurrMainAttributes();
		short intelligenceCost = GlobalConfig.Instance.ActiveReadingAttributeCost;
		short curInt = mainAttributes.Items[5];
		for (int i = 0; i < readCount; i++)
		{
			if (attributeCost && curInt < intelligenceCost)
			{
				break;
			}
			curInt -= intelligenceCost;
			DataContext context = runtime.Context;
			if (attributeCost)
			{
				taiwu.ChangeCurrMainAttribute(context, 5, -intelligenceCost);
			}
			if (!itemKey.IsValid())
			{
				return false;
			}
			int bookId = itemKey.Id;
			if (!DomainManager.Item.TryGetElement_SkillBooks(bookId, out var _))
			{
				return false;
			}
			DomainManager.Taiwu.TaiwuReadingBook(runtime.Context, itemKey);
		}
		return true;
	}

	[EventFunction(605)]
	private static ItemKey GetTaiwuReadingBook(EventScriptRuntime runtime)
	{
		return DomainManager.Taiwu.GetCurReadingBook();
	}

	[EventFunction(527)]
	private static bool TaiwuAddReadingEvent(EventScriptRuntime runtime)
	{
		ItemKey book = DomainManager.Taiwu.GetCurReadingBook();
		if (!book.IsValid())
		{
			return false;
		}
		List<int> bookIdList = DomainManager.Extra.GetReadingEventBookIdList();
		if (bookIdList.Contains(book.Id))
		{
			return false;
		}
		DomainManager.Extra.AddReadingEventBookId(runtime.Context, book.Id);
		return true;
	}

	[EventFunction(533)]
	private static bool TeachCombatSkill(EventScriptRuntime runtime, GameData.Domains.Character.Character self, GameData.Domains.Character.Character target, short combatSkillTemplateId)
	{
		List<short> learnedCombatSkills = self.GetLearnedCombatSkills();
		if (!learnedCombatSkills.Contains(combatSkillTemplateId))
		{
			return false;
		}
		if (Config.CombatSkill.Instance[combatSkillTemplateId].BookId < 0)
		{
			return false;
		}
		(ItemKey, byte, byte, sbyte) bookTuple = GameData.Domains.TaiwuEvent.EventHelper.EventHelper.GetTeachCombatSkillBook(self.GetId(), combatSkillTemplateId);
		bool success = GameData.Domains.TaiwuEvent.EventHelper.EventHelper.CheckLearnCombatSkillWithInstructionSucceed(target, combatSkillTemplateId);
		TeachCombatSkillAction action = new TeachCombatSkillAction
		{
			SkillTemplateId = combatSkillTemplateId,
			InternalIndex = bookTuple.Item2,
			GeneratedPageTypes = bookTuple.Item3,
			Succeed = success
		};
		if (action.CheckValid(self, target))
		{
			GameData.Domains.TaiwuEvent.EventHelper.EventHelper.ApplyGeneralActionChanges(action, self, target);
		}
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.RemoveItem(bookTuple.Item1);
		return success;
	}

	[EventFunction(536)]
	private static int GetCombatPower(EventScriptRuntime runtime, GameData.Domains.Character.Character character)
	{
		return character.GetCombatPower();
	}

	[EventFunction(547)]
	private static void SetInteractionCooldown(EventScriptRuntime runtime, GameData.Domains.Character.Character character, short templateId)
	{
		DomainManager.TaiwuEvent.SetInteractionEventOptionCooldown(character.GetId(), templateId);
	}

	[EventFunction(834)]
	private static void SetInteractionMonthCooldown(EventScriptRuntime runtime, GameData.Domains.Character.Character character, short templateId, int cooldown)
	{
		DomainManager.Extra.SetTaiwuInteractionCooldown(runtime.Context, character.GetId(), templateId, cooldown);
	}

	[EventFunction(558)]
	private static void ReadAllBookPages(EventScriptRuntime runtime, GameData.Domains.Character.Character character, ItemKey itemKey)
	{
		GameData.Domains.Item.SkillBook book = DomainManager.Item.GetElement_SkillBooks(itemKey.Id);
		byte pageId = 0;
		byte pageCount = book.GetPageCount();
		while (pageId < pageCount)
		{
			character.ReadBookPage(runtime.Context, book, pageId);
			pageId++;
		}
	}

	[EventFunction(569)]
	private static void AddNormalInformation(EventScriptRuntime runtime, GameData.Domains.Character.Character character, short infoTemplateId, sbyte level)
	{
		DomainManager.Information.AddNormalInformationToCharacter(runtime.Context, character.GetId(), new NormalInformation(infoTemplateId, level));
	}

	[EventFunction(571)]
	private static void ChangeCharacterMorality(EventScriptRuntime runtime, GameData.Domains.Character.Character character, int delta)
	{
		character.ChangeBaseMorality(runtime.Context, delta);
	}

	[EventFunction(572)]
	private static void SetCharacterBehaviorType(EventScriptRuntime runtime, GameData.Domains.Character.Character character, sbyte behaviorType)
	{
		short value = GameData.Domains.Character.BehaviorType.GetMiddleMoralityByBehaviorType(behaviorType);
		character.SetBaseMorality(value, runtime.Context);
	}

	[EventFunction(577)]
	private static int GetCharacterCombatSkillAttainment(EventScriptRuntime runtime, GameData.Domains.Character.Character character, sbyte combatSkillType)
	{
		return character.GetCombatSkillAttainment(combatSkillType);
	}

	[EventFunction(583)]
	private static void CreateFixedCharacterGrave(EventScriptRuntime runtime, short characterTemplateId, MapBlockData mapBlockData, sbyte graveLevel, int date)
	{
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.CreateFixedCharacterGrave(characterTemplateId, mapBlockData.GetLocation(), graveLevel, date);
	}

	[EventFunction(627)]
	private static int GetHighestOrLowestHappinessCharacter(EventScriptRuntime runtime, IntList list, bool getHighest)
	{
		int happiness = (getHighest ? int.MinValue : int.MaxValue);
		int charId = -1;
		foreach (int characterId in list.Items)
		{
			if (DomainManager.Character.TryGetElement_Objects(characterId, out var character))
			{
				sbyte charHappiness = character.GetHappiness();
				if (getHighest ? (charHappiness >= happiness) : (charHappiness <= happiness))
				{
					happiness = charHappiness;
					charId = characterId;
				}
			}
		}
		return charId;
	}

	[EventFunction(626)]
	private static void SetCarrierTamePoint(EventScriptRuntime runtime, ItemKey carrier, int setValue)
	{
		if (DomainManager.Extra.IsItemTamable(carrier))
		{
			int finial = Math.Clamp(setValue, 0, 100);
			DomainManager.Extra.SetCarrierTamePoint(runtime.Context, carrier.Id, finial);
		}
	}

	[EventFunction(631)]
	private static void StartCommonSelectCharacterFeature(EventScriptRuntime runtime, IntList list, string afterEvent, string saveKey, string contentKey, string eventTexture)
	{
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.StartCommonSelectCharacterFeature(list, afterEvent, saveKey, contentKey, eventTexture, runtime.ArgBox);
	}

	[EventFunction(634)]
	private static void CreateTeammateWithXiangshuCloth(EventScriptRuntime runtime, sbyte grade, string saveKey)
	{
		DataContext context = runtime.Context;
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		short areaId = taiwu.GetLocation().AreaId;
		sbyte stateTemplateId = DomainManager.Map.GetStateTemplateIdByAreaId(areaId);
		sbyte orgTemplateId = MapState.Instance[stateTemplateId].SectID;
		sbyte gender = (sbyte)context.Random.Next(0, 2);
		short charTemplateId = OrganizationDomain.GetCharacterTemplateId(orgTemplateId, stateTemplateId, gender);
		OrganizationInfo orgInfo = new OrganizationInfo(orgTemplateId, grade, principal: true, -1);
		TemporaryIntelligentCharacterCreationInfo info = new TemporaryIntelligentCharacterCreationInfo
		{
			Location = taiwu.GetLocation(),
			OrgInfo = orgInfo,
			CharTemplateId = charTemplateId,
			ActualAge = (short)context.Random.Next(16, 25)
		};
		GameData.Domains.Character.Character newCharacter = DomainManager.Character.CreateTemporaryIntelligentCharacter(runtime.Context, ref info);
		newCharacter.AddFeature(context, 802, removeMutexFeature: true);
		DomainManager.Character.ChangeFavorabilityOptional(context, newCharacter, taiwu, 0, 0);
		ItemKey item = DomainManager.Item.CreateClothing(context, 67, newCharacter.GetGender());
		newCharacter.AddInventoryItem(context, item, 1);
		ItemKey[] equipments = newCharacter.GetEquipment().ToArray();
		equipments[4] = item;
		newCharacter.ChangeEquipment(context, equipments);
		runtime.ArgBox.Set(saveKey, newCharacter.GetId());
	}

	[EventFunction(699)]
	private static void AddExtraNeiliAllocationProgressToGainExtraNeiliAllocation(EventScriptRuntime runtime, GameData.Domains.Character.Character character, byte neiliType, int delta)
	{
		character.AddExtraNeiliAllocationProgressToGainExtraNeiliAllocation(runtime.Context, neiliType, delta);
	}

	[EventFunction(738)]
	private static void SetEventRoleAlternativeName(EventScriptRuntime runtime, bool left, string key)
	{
		if (key == "Invalid")
		{
			key = string.Empty;
		}
		if (left)
		{
			DomainManager.TaiwuEvent.SetLeftRoleAlternativeName(key, runtime.Context);
		}
		else
		{
			DomainManager.TaiwuEvent.SetRightRoleAlternativeName(key, runtime.Context);
		}
	}

	[EventFunction(745)]
	private static void AutoEquipItems(EventScriptRuntime runtime, GameData.Domains.Character.Character character)
	{
		runtime.Context.Equipping.EquipItems(runtime.Context, character);
	}

	[EventFunction(781)]
	private static void ChangeEquipment(EventScriptRuntime runtime, GameData.Domains.Character.Character character, int equipmentSlot, ItemKey item)
	{
		ItemKey[] equipments = character.GetEquipment().ToArray();
		equipments[equipmentSlot] = item;
		character.ChangeEquipment(runtime.Context, equipments);
	}

	[EventFunction(746)]
	private static void AutoEquipCombatSkills(EventScriptRuntime runtime, GameData.Domains.Character.Character character)
	{
		runtime.Context.Equipping.EquipCombatSkills(runtime.Context, character, -1);
	}

	[EventFunction(747)]
	private static void AutoAllocateNeili(EventScriptRuntime runtime, GameData.Domains.Character.Character character)
	{
		runtime.Context.Equipping.AllocateNeili(runtime.Context, character);
	}

	[EventFunction(753)]
	private static void CharacterRestoreAllStatus(EventScriptRuntime runtime, GameData.Domains.Character.Character character)
	{
		DataContext context = runtime.Context;
		Injuries injuries = character.GetInjuries();
		injuries.Initialize();
		character.SetInjuries(injuries, context);
		PoisonInts poisons = character.GetPoisoned();
		poisons.Initialize();
		character.SetPoisoned(ref poisons, context);
		short leftMaxHealth = character.GetLeftMaxHealth();
		character.SetHealth(leftMaxHealth, context);
		character.SetDisorderOfQi(DisorderLevelOfQi.MinValue, context);
	}

	[EventFunction(763)]
	private static void StartSelectFilteredCharacters(EventScriptRuntime runtime, sbyte selectRange, short matcherId, string saveKey)
	{
		runtime.Current.StartSelectFilteredCharacters(selectRange, matcherId, saveKey);
	}

	[EventFunction(861)]
	private static void AddOneWayRelationType(EventScriptRuntime runtime, GameData.Domains.Character.Character selfChar, GameData.Domains.Character.Character targetChar, ushort relationType)
	{
		DomainManager.Character.TryAddAndApplyOneWayRelation(runtime.Context, selfChar.GetId(), targetChar.GetId(), relationType);
	}

	[EventFunction(779)]
	private static void CharacterMakeLove(EventScriptRuntime runtime, GameData.Domains.Character.Character selfChar, GameData.Domains.Character.Character targetChar)
	{
		int selfCharId = selfChar.GetId();
		int targetCharId = targetChar.GetId();
		selfChar.MakeLove(runtime.Context, targetChar, isRape: false);
		PeriAdvanceMonthFixedActionModification.MakeLoveState state = ((!DomainManager.Character.HasRelation(selfCharId, targetCharId, 1024)) ? PeriAdvanceMonthFixedActionModification.MakeLoveState.Illegal : PeriAdvanceMonthFixedActionModification.MakeLoveState.Legal);
		int currDate = DomainManager.World.GetCurrDate();
		Location location = selfChar.GetLocation();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		if (state == PeriAdvanceMonthFixedActionModification.MakeLoveState.Illegal)
		{
			lifeRecordCollection.AddMakeLoveIllegal(selfCharId, currDate, targetCharId, location);
			SecretInformationCollection secretInformationCollection = DomainManager.Information.GetSecretInformationCollection();
			int secretInfoOffset = secretInformationCollection.AddMakeLoveIllegal(selfCharId, targetCharId);
			SecretInformationId secretInfoId = DomainManager.Information.AddSecretInformation(runtime.Context, secretInfoOffset);
		}
		else
		{
			lifeRecordCollection.AddMakeLoveLegal(selfCharId, currDate, targetCharId, location);
		}
	}

	[EventFunction(955)]
	public static void AddRelation(EventScriptRuntime runtime, GameData.Domains.Character.Character src, GameData.Domains.Character.Character dst, ushort relationType)
	{
		switch (relationType)
		{
		case 1024:
			GameData.Domains.TaiwuEvent.EventHelper.EventHelper.AddHusbandOrWifeRelations(src.GetId(), dst.GetId());
			break;
		case 64:
			GameData.Domains.TaiwuEvent.EventHelper.EventHelper.AddAdoptiveParent(src.GetId(), dst.GetId());
			break;
		case 128:
			GameData.Domains.TaiwuEvent.EventHelper.EventHelper.AddAdoptiveParent(dst.GetId(), src.GetId());
			break;
		default:
			GameData.Domains.TaiwuEvent.EventHelper.EventHelper.AddRelation(src.GetId(), dst.GetId(), relationType);
			break;
		}
	}

	[EventFunction(956)]
	public static void RemoveRelation(EventScriptRuntime runtime, GameData.Domains.Character.Character src, GameData.Domains.Character.Character dst, ushort relationType)
	{
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.RemoveRelation(src.GetId(), dst.GetId(), relationType);
	}

	[EventFunction(782)]
	private static int GetCharacterFiveElements(EventScriptRuntime runtime, GameData.Domains.Character.Character character, sbyte fiveElementsType)
	{
		return character.GetNeiliProportionOfFiveElements()[fiveElementsType];
	}

	[EventFunction(794)]
	private static void AddCharacterExtraTitle(EventScriptRuntime runtime, GameData.Domains.Character.Character character, short titleTemplateId, int expireDate = -1)
	{
		DomainManager.Character.AddCharacterExtraTitle(runtime.Context, character.GetId(), titleTemplateId, expireDate);
	}

	[EventFunction(795)]
	private static void SelectCharacterCricket(EventScriptRuntime runtime, GameData.Domains.Character.Character character, int operatorId, int winCount, string saveKey)
	{
		if (!runtime.ArgBox.Get("SelectItemInfo", out EventSelectItemData selectItemData))
		{
			selectItemData = new EventSelectItemData
			{
				CanSelectItemList = new List<ITradeableContent>(),
				FilterList = new List<SelectItemFilter>()
			};
			runtime.ArgBox.Set("SelectItemInfo", selectItemData);
		}
		SelectItemFilter filter = new SelectItemFilter
		{
			Key = saveKey,
			DisplayDataFilterId = 0,
			FilterTemplateId = -1
		};
		Inventory inventory = character.GetInventory();
		foreach (KeyValuePair<ItemKey, int> pair in inventory.Items)
		{
			ItemKey itemKey = pair.Key;
			if (ItemTemplateHelper.GetItemSubType(itemKey.ItemType, itemKey.TemplateId) == 1100 && DomainManager.Item.TryGetElement_Crickets(itemKey.Id, out var cricket) && EventConditions.PerformOperation(operatorId, cricket.GetWinsCount(), winCount))
			{
				ItemDisplayData itemDisplayData = DomainManager.Item.GetItemDisplayData(itemKey, EventArgBox.TaiwuCharacterId);
				itemDisplayData.Amount = pair.Value;
				itemDisplayData.IsLocked = false;
				selectItemData.CanSelectItemList.Add(itemDisplayData);
			}
		}
		selectItemData.FilterList.Add(filter);
	}

	[EventFunction(796)]
	private static void StartCricketCombat(EventScriptRuntime runtime, GameData.Domains.Character.Character character, string afterEvent)
	{
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.StartCricketCombat(character.GetId(), afterEvent, runtime.ArgBox);
	}

	[EventFunction(797)]
	private static void StartCricketCombatWithConfig(EventScriptRuntime runtime, GameData.Domains.Character.Character character, bool doubleDamage, bool onlyNoInjuryCricket, sbyte minGrade, sbyte maxGrade, string afterEvent)
	{
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.StartCricketCombatWithConfig(character.GetId(), doubleDamage, onlyNoInjuryCricket, minGrade, maxGrade, afterEvent, runtime.ArgBox);
	}

	[EventFunction(798)]
	private static bool GetSimulateCricketBattleResult(EventScriptRuntime runtime, GameData.Domains.Character.Character character1, GameData.Domains.Character.Character character2)
	{
		return GameData.Domains.TaiwuEvent.EventHelper.EventHelper.GetSimulateCricketBattleResult(character1.GetId(), character2.GetId());
	}

	[EventFunction(799)]
	private static void ClearCricketItemShow(EventScriptRuntime runtime)
	{
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.SetItemListOfLeft(-1, null);
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.SetItemListOfRight(-1, null);
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.SetItemShowForCricketBattleGuess(flag: false);
	}

	[EventFunction(800)]
	private static int GetItemCurrDurability(EventScriptRuntime runtime, ItemKey itemKey)
	{
		return GameData.Domains.TaiwuEvent.EventHelper.EventHelper.GetItemCurrDurability(itemKey);
	}

	[EventFunction(802)]
	private static int GetItemMaxDurability(EventScriptRuntime runtime, ItemKey itemKey)
	{
		return GameData.Domains.TaiwuEvent.EventHelper.EventHelper.GetItemMaxDurability(itemKey);
	}

	[EventFunction(801)]
	private static void SetItemCurrDurability(EventScriptRuntime runtime, ItemKey itemKey, short durability)
	{
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.SetItemCurrDurability(itemKey, durability);
	}

	[EventFunction(806)]
	private static void AdjustCricketExtraAge(EventScriptRuntime runtime, ItemKey itemKey, int delta)
	{
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.AdjustCricketLife(itemKey, delta);
	}

	[EventFunction(807)]
	private static void BuyCricketStart(EventScriptRuntime runtime)
	{
		EventArgBox argBox = runtime.ArgBox;
		Location location = argBox.GetCharacter("RoleTaiwu").GetLocation();
		sbyte gender = 0;
		short age = 16;
		GameData.Domains.Character.Character character = GameData.Domains.TaiwuEvent.EventHelper.EventHelper.CreateTemporaryIntelligentCharacter(location, 1, 25, 750, GameData.Domains.TaiwuEvent.EventHelper.EventHelper.GetSettlementIdByOrgTemplateId(1), 5);
		argBox.Set("TempCharacter", character.GetId());
		int rd = GameData.Domains.TaiwuEvent.EventHelper.EventHelper.GetRandom();
		sbyte grade = 0;
		ItemKey cricket0 = GameData.Domains.TaiwuEvent.EventHelper.EventHelper.CreateCricket(grade: (sbyte)((rd < 5) ? 8 : ((rd < 15) ? 7 : ((rd >= 30) ? ((sbyte)GameData.Domains.TaiwuEvent.EventHelper.EventHelper.GetRandom(0, 6)) : 6))), charId: character.GetId());
		rd = GameData.Domains.TaiwuEvent.EventHelper.EventHelper.GetRandom();
		grade = 0;
		ItemKey cricket1 = GameData.Domains.TaiwuEvent.EventHelper.EventHelper.CreateCricket(grade: (sbyte)((rd < 2) ? 8 : ((rd < 8) ? 7 : ((rd >= 17) ? ((sbyte)GameData.Domains.TaiwuEvent.EventHelper.EventHelper.GetRandom(0, 6)) : 6))), charId: character.GetId());
		rd = GameData.Domains.TaiwuEvent.EventHelper.EventHelper.GetRandom();
		grade = 0;
		ItemKey cricket2 = GameData.Domains.TaiwuEvent.EventHelper.EventHelper.CreateCricket(grade: (sbyte)((rd < 0) ? 8 : ((rd < 2) ? 7 : ((rd >= 5) ? ((sbyte)GameData.Domains.TaiwuEvent.EventHelper.EventHelper.GetRandom(0, 6)) : 6))), charId: character.GetId());
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.SetItemListOfRight(-1, new ItemKey[3] { cricket2, cricket1, cricket0 });
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.SetCoverCricketJarGradeList(new List<sbyte> { 8, 6, 4 });
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.SetItemShowForCricketBattleGuess(flag: false);
		argBox.Set("BuyCricket0", cricket0);
		argBox.Set("BuyCricket1", cricket1);
		argBox.Set("BuyCricket2", cricket2);
	}

	[EventFunction(808)]
	private static void BuyCricketOption(EventScriptRuntime runtime, int index)
	{
		EventArgBox argBox = runtime.ArgBox;
		argBox.Get("BuyCricket" + index, out ItemKey cricket);
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.TransferInventoryItem(argBox.GetCharacter("TempCharacter"), argBox.GetCharacter("RoleTaiwu"), cricket);
		argBox.Set("BuyCricket", cricket);
	}

	[EventFunction(837)]
	private static void EventSetItemList(EventScriptRuntime runtime, bool left, ItemKey item1, ItemKey item2, ItemKey item3, GameData.Domains.Character.Character character)
	{
		if (left)
		{
			GameData.Domains.TaiwuEvent.EventHelper.EventHelper.SetItemListOfLeft(character?.GetId() ?? (-1), new ItemKey[3] { item1, item2, item3 });
		}
		else
		{
			GameData.Domains.TaiwuEvent.EventHelper.EventHelper.SetItemListOfRight(character?.GetId() ?? (-1), new ItemKey[3] { item1, item2, item3 });
		}
	}

	[EventFunction(840)]
	private static void SetCoverCricketJarGradeList(EventScriptRuntime runtime, sbyte grade0, sbyte grade1, sbyte grade2)
	{
		int num = 3;
		List<sbyte> list = new List<sbyte>(num);
		CollectionsMarshal.SetCount(list, num);
		Span<sbyte> span = CollectionsMarshal.AsSpan(list);
		int num2 = 0;
		span[num2] = grade0;
		num2++;
		span[num2] = grade1;
		num2++;
		span[num2] = grade2;
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.SetCoverCricketJarGradeList(list);
	}

	[EventFunction(814)]
	private static int CreateNoMindGuy(EventScriptRuntime runtime, GameData.Domains.Character.Character victim)
	{
		return GameData.Domains.TaiwuEvent.EventHelper.EventHelper.UseMainStorySeverMindPill(victim);
	}

	[EventFunction(818)]
	private static bool CompareCharFame(EventScriptRuntime runtime, GameData.Domains.Character.Character victim, int operatorId, sbyte fameType, bool includeBothGoodAndBad)
	{
		return (includeBothGoodAndBad && victim.GetFameType() == -2) || EventConditions.PerformOperation(operatorId, victim.GetFameType(), fameType);
	}

	[EventFunction(815)]
	private static int GetCharFame(EventScriptRuntime runtime, GameData.Domains.Character.Character victim)
	{
		return victim.GetFameType();
	}

	[EventFunction(816)]
	private static int GetCharPositiveFameValue(EventScriptRuntime runtime, GameData.Domains.Character.Character victim)
	{
		return GameData.Domains.Character.SharedMethods.GetFame(victim.GetFeatureIds(), victim.GetFameActionRecords(), victim.GetOrganizationInfo(), DomainManager.World.GetCurrDate(), victim.GetId() == DomainManager.Taiwu.GetTaiwuCharId()).good;
	}

	[EventFunction(817)]
	private static int GetCharNegativeFameValue(EventScriptRuntime runtime, GameData.Domains.Character.Character victim)
	{
		return GameData.Domains.Character.SharedMethods.GetFame(victim.GetFeatureIds(), victim.GetFameActionRecords(), victim.GetOrganizationInfo(), DomainManager.World.GetCurrDate(), victim.GetId() == DomainManager.Taiwu.GetTaiwuCharId()).bad;
	}

	[EventFunction(853)]
	private static void SetNpcFollowTaiwu(EventScriptRuntime runtime, GameData.Domains.Character.Character victim, int distance)
	{
		if (distance < 0)
		{
			DomainManager.Character.RemoveCharacterFollowTaiwu(runtime.Context, victim.GetId());
		}
		else
		{
			DomainManager.Character.SetCharacterFollowTaiwu(runtime.Context, victim.GetId(), distance);
		}
	}

	[EventFunction(854)]
	private static void SetNoMindGuyFollowTaiwu(EventScriptRuntime runtime, int distance)
	{
		foreach (GameData.Domains.Character.Character victim in DomainManager.Character.GetNoMindGuys())
		{
			SetNpcFollowTaiwu(runtime, victim, distance);
		}
	}

	[EventFunction(886)]
	private static void UpdateFixedCharacterMonthlyMovement(EventScriptRuntime runtime, GameData.Domains.Character.Character character)
	{
		DomainManager.Character.UpdateFixedCharacterMovement(runtime.Context, character);
	}

	[EventFunction(932)]
	private static void ChangeProfessionSeniority(EventScriptRuntime runtime, int templateId, int baseDelta)
	{
		DomainManager.Extra.ChangeProfessionSeniority(runtime.Context, templateId, baseDelta);
	}

	[EventFunction(941)]
	private static void TaiwuAsXiangshuWipeOut(EventScriptRuntime runtime, bool addExp)
	{
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.GetMapRandomEnemyListFromArgBox(runtime.ArgBox, "EnemyGroup", out var group);
		Location location = DomainManager.Taiwu.GetTaiwu().GetLocation();
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.RemoveMapRandomEnemiesOnBlock(location, group);
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.MapRandomEnemiesEscapeByCharacter(location, EventArgBox.TaiwuCharacterId);
		if (!addExp)
		{
			return;
		}
		List<short> templateIds = new List<short>();
		foreach (MapTemplateEnemyInfo item in group)
		{
			templateIds.Add(item.TemplateId);
		}
		int expAdd = DomainManager.Combat.GetExpAndAuthorityAndAreaSpiritualDebtOutOfCombat(runtime.Context, templateIds);
		ProfessionFormulaItem seniorityFormula = ProfessionFormula.Instance[114];
		int addSeniority = seniorityFormula.Calculate(expAdd);
		DomainManager.Extra.ChangeProfessionSeniority(runtime.Context, 18, addSeniority);
	}
}
