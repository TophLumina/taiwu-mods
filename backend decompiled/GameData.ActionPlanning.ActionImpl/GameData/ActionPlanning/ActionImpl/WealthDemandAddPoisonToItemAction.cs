using System;
using System.Linq;
using Config;
using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.Character.Ai;
using GameData.Domains.Character.Relation;
using GameData.Domains.Item;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.ActionPlanning.ActionImpl;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class WealthDemandAddPoisonToItemAction : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort TargetItem = 0;

		public const ushort AgreeToRequest = 1;

		public const ushort PoisonUsed = 2;

		public const ushort Count = 3;

		public static readonly string[] FieldId2FieldName = new string[3] { "TargetItem", "AgreeToRequest", "PoisonUsed" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public ItemKey TargetItem;

	[SerializableGameDataField(FieldIndex = 1)]
	public bool AgreeToRequest;

	[SerializableGameDataField(FieldIndex = 2)]
	public ItemKey PoisonUsed;

	public static bool MatchTargetCharacter(DataContext context, GameData.Domains.Character.Character character, GameData.Domains.Character.Character targetChar, ContextArgGroupHandle args)
	{
		short characterAttainment = targetChar.GetLifeSkillAttainment(9);
		foreach (ItemKey itemKey in targetChar.GetInventory().Items.Keys)
		{
			if (itemKey.ItemType != 8)
			{
				continue;
			}
			MedicineItem medicineCfg = Config.Medicine.Instance[itemKey.TemplateId];
			if (medicineCfg.EffectType == EMedicineEffectType.ApplyPoison)
			{
				sbyte num = medicineCfg.EffectSubType.PoisonType();
				short attainmentRequired = GlobalConfig.Instance.PoisonAttainments[medicineCfg.Grade];
				if (num == args.PoisonType && characterAttainment >= attainmentRequired)
				{
					return true;
				}
			}
		}
		return false;
	}

	bool ICharacterActionImpl.OfflineInitActionData(DataContext context, GameData.Domains.Character.Character character, ContextArgGroupHandle argGroup, CharacterActionData actionData)
	{
		GameData.Domains.Character.Character targetChar = actionData.TargetChar;
		sbyte favorabilityType = FavorabilityType.GetFavorabilityType(DomainManager.Character.GetFavorability(targetChar.GetId(), character.GetId()));
		sbyte respondChance = AiHelper.GeneralActionConstants.GetAskForHelpRespondChance(targetChar.GetBehaviorType(), favorabilityType);
		short toxicologyAttainment = targetChar.GetLifeSkillAttainment(9);
		int minDeviation = 16129;
		ItemKey selectedPoison = ItemKey.Invalid;
		foreach (ItemKey itemKey in targetChar.GetInventory().Items.Keys)
		{
			if (itemKey.ItemType != 8)
			{
				continue;
			}
			MedicineItem medicineCfg = Config.Medicine.Instance[itemKey.TemplateId];
			if (medicineCfg.EffectType != EMedicineEffectType.ApplyPoison)
			{
				continue;
			}
			sbyte num = medicineCfg.EffectSubType.PoisonType();
			short attainmentRequired = GlobalConfig.Instance.PoisonAttainments[medicineCfg.Grade];
			if (num == argGroup.PoisonType && toxicologyAttainment >= attainmentRequired)
			{
				int num2 = medicineCfg.Grade - character.GetOrganizationInfo().Grade;
				int currDeviation = num2 * num2;
				if (currDeviation <= minDeviation)
				{
					minDeviation = currDeviation;
					selectedPoison = itemKey;
				}
			}
		}
		if (!selectedPoison.IsValid())
		{
			throw new Exception($"Failed to find target poison {argGroup.PoisonType} in selected character {targetChar}'s inventory for {character}.");
		}
		sbyte selectedItem = SelectEquipmentInArrayToAddPoisonOn(context, character, selectedPoison.TemplateId);
		if (selectedItem >= 0)
		{
			TargetItem = character.GetEquipment()[selectedItem];
			PoisonUsed = selectedPoison;
			AgreeToRequest = context.Random.CheckPercentProb(respondChance);
			return true;
		}
		return false;
	}

	bool ICharacterActionImpl.CheckValid(GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
		if (Enumerable.Contains(character.GetEquipment(), TargetItem))
		{
			return actionData.TargetChar.GetInventory().Items.ContainsKey(PoisonUsed);
		}
		return false;
	}

	void ICharacterActionImpl.PostExecuteForTaiwuTarget(DataContext context, GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
		GameData.Domains.Character.Character targetChar = actionData.TargetChar;
		int selfCharId = character.GetId();
		int targetCharId = targetChar.GetId();
		Location location = targetChar.GetLocation();
		DomainManager.World.GetMonthlyEventCollection().AddRequestAddPoisonToItem(selfCharId, location, targetCharId, (ulong)TargetItem, (ulong)PoisonUsed);
		CharacterDomain.AddLockMovementCharSet(selfCharId);
	}

	void ICharacterActionImpl.PostExecute(DataContext context, GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
		GameData.Domains.Character.Character targetChar = actionData.TargetChar;
		int selfCharId = character.GetId();
		int targetCharId = targetChar.GetId();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		Location location = character.GetLocation();
		int currDate = DomainManager.World.GetCurrDate();
		if (AgreeToRequest)
		{
			ItemBase itemToAddPoisonOn = DomainManager.Item.GetBaseItem(TargetItem);
			Tester.Assert(Config.Medicine.Instance[PoisonUsed.TemplateId].EffectType == EMedicineEffectType.ApplyPoison);
			var (newItemObj, flag) = DomainManager.Item.SetAttachedPoisons(context, itemToAddPoisonOn, PoisonUsed.TemplateId, add: true);
			targetChar.RemoveInventoryItem(context, PoisonUsed, 1, deleteItem: true);
			if (flag)
			{
				ItemKey[] equipment = character.GetEquipment();
				for (int i = 0; i < equipment.Length; i++)
				{
					if (equipment[i].Equals(TargetItem))
					{
						equipment[i] = newItemObj.GetItemKey();
						character.SetEquipment(equipment, context);
						break;
					}
				}
			}
			int favorabilityChange = itemToAddPoisonOn.GetFavorabilityChange() * 5;
			DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, character, targetChar, favorabilityChange);
			character.ChangeHappiness(context, DomainManager.Item.GetBaseItem(TargetItem).GetHappinessChange());
			lifeRecordCollection.AddRequestAddPoisonToItemSucceed(selfCharId, currDate, targetCharId, location, TargetItem.ItemType, TargetItem.TemplateId);
			int secretInfoOffset = DomainManager.Information.GetSecretInformationCollection().AddAcceptRequestAddPoisonToItem(targetCharId, selfCharId, (ulong)TargetItem, (ulong)PoisonUsed);
			DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
		}
		else
		{
			DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, character, targetChar, -3000);
			character.ChangeHappiness(context, -3);
			lifeRecordCollection.AddRequestAddPoisonToItemFail(selfCharId, currDate, targetCharId, location, TargetItem.ItemType, TargetItem.TemplateId);
			int secretInfoOffset2 = DomainManager.Information.GetSecretInformationCollection().AddRefuseRequestAddPoisonToItem(targetCharId, selfCharId, (ulong)TargetItem, (ulong)PoisonUsed);
			DomainManager.Information.AddSecretInformation(context, secretInfoOffset2);
		}
	}

	private unsafe sbyte SelectEquipmentInArrayToAddPoisonOn(DataContext context, GameData.Domains.Character.Character character, short templateId)
	{
		MedicineItem selectedPoisonCfg = Config.Medicine.Instance[templateId];
		sbyte* weapons = stackalloc sbyte[3] { 0, 1, 2 };
		sbyte selectedWeapon = character.SelectEquipmentInArrayToAddPoisonOn(context.Random, selectedPoisonCfg, weapons, 3);
		if (selectedWeapon >= 0)
		{
			return selectedWeapon;
		}
		sbyte* armor = stackalloc sbyte[4] { 3, 5, 6, 7 };
		sbyte selectedArmor = character.SelectEquipmentInArrayToAddPoisonOn(context.Random, selectedPoisonCfg, armor, 4);
		if (selectedArmor >= 0)
		{
			return selectedArmor;
		}
		sbyte* accessories = stackalloc sbyte[3] { 8, 9, 10 };
		sbyte selectedAccessory = character.SelectEquipmentInArrayToAddPoisonOn(context.Random, selectedPoisonCfg, accessories, 3);
		if (selectedAccessory >= 0)
		{
			return selectedAccessory;
		}
		return -1;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 3;
		totalSize += TargetItem.GetSerializedSize();
		totalSize += PoisonUsed.GetSerializedSize();
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 3;
		pCurrData += 2;
		int fieldSize = TargetItem.Serialize(pCurrData);
		pCurrData += fieldSize;
		Tester.Assert(fieldSize <= 65535);
		*pCurrData = (AgreeToRequest ? ((byte)1) : ((byte)0));
		pCurrData++;
		int fieldSize2 = PoisonUsed.Serialize(pCurrData);
		pCurrData += fieldSize2;
		Tester.Assert(fieldSize2 <= 65535);
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			pCurrData += TargetItem.Deserialize(pCurrData);
		}
		if (num > 1)
		{
			AgreeToRequest = *pCurrData != 0;
			pCurrData++;
		}
		if (num > 2)
		{
			pCurrData += PoisonUsed.Deserialize(pCurrData);
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
