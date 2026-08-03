using System.Collections.Generic;
using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.Item;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.Organization;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.ActionPlanning.ActionImpl;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class SpendResourceByPurchaseGiftAction : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort MoneyCost = 0;

		public const ushort PurchasedItem = 1;

		public const ushort ItemAmount = 2;

		public const ushort Count = 3;

		public static readonly string[] FieldId2FieldName = new string[3] { "MoneyCost", "PurchasedItem", "ItemAmount" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public int MoneyCost;

	[SerializableGameDataField(FieldIndex = 1)]
	public TemplateKey PurchasedItem;

	[SerializableGameDataField(FieldIndex = 2)]
	public int ItemAmount;

	public static bool MatchTargetCharacter(DataContext context, Character character, Character targetChar, ContextArgGroupHandle args)
	{
		if (targetChar.GetId() == DomainManager.Taiwu.GetTaiwuCharId())
		{
			return false;
		}
		IReadOnlyList<CharacterGoalData> goals = targetChar.GetGoals();
		for (int i = goals.Count - 1; i >= 0; i--)
		{
			CharacterGoalData goal = goals[i];
			if (goal.Match(238))
			{
				sbyte itemType = goal.Args.ItemType;
				if (itemType != 11 && itemType != 3)
				{
					return true;
				}
			}
		}
		return false;
	}

	bool ICharacterActionImpl.OfflineInitActionData(DataContext context, Character character, ContextArgGroupHandle argGroup, CharacterActionData actionData)
	{
		IReadOnlyList<CharacterGoalData> targetGoals = actionData.TargetChar.GetGoals();
		for (int i = targetGoals.Count - 1; i >= 0; i--)
		{
			CharacterGoalData goal = targetGoals[i];
			if (goal.Match(238))
			{
				sbyte itemType = goal.Args.ItemType;
				short itemTemplateId = goal.Args.ItemTemplateId;
				if ((itemType != 3 && itemType != 11) || 1 == 0)
				{
					int price = ItemTemplateHelper.GetBaseValue(itemType, itemTemplateId) * 2 * OrganizationDomain.GetOrgMemberConfig(character.GetOrganizationInfo()).PurchaseItemDiscount / 100;
					PurchasedItem = new TemplateKey(itemType, itemTemplateId);
					ItemAmount = 1;
					MoneyCost = price;
					return true;
				}
			}
		}
		return false;
	}

	bool ICharacterActionImpl.CheckValid(Character character, CharacterActionData actionData)
	{
		if (character.IsInRegularSettlementRange())
		{
			return character.GetResource(6) >= MoneyCost;
		}
		return false;
	}

	void ICharacterActionImpl.PostExecute(DataContext context, Character character, CharacterActionData actionData)
	{
		Character targetChar = actionData.TargetChar;
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int selfCharId = character.GetId();
		int currDate = DomainManager.World.GetCurrDate();
		Location location = character.GetValidLocation();
		Location settlementLocation = DomainManager.Map.GetBelongSettlementBlock(location).GetLocation();
		character.ChangeResource(context, 6, -MoneyCost);
		lifeRecordCollection.AddPurchaseItem1(selfCharId, currDate, settlementLocation, PurchasedItem.ItemType, PurchasedItem.TemplateId);
		targetChar.CreateInventoryItem(context, PurchasedItem.ItemType, PurchasedItem.TemplateId, ItemAmount);
		lifeRecordCollection.AddGiveItem(selfCharId, currDate, targetChar.GetId(), settlementLocation, PurchasedItem.ItemType, PurchasedItem.TemplateId);
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 10;
		totalSize += PurchasedItem.GetSerializedSize();
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
		*(int*)pCurrData = MoneyCost;
		pCurrData += 4;
		int fieldSize = PurchasedItem.Serialize(pCurrData);
		pCurrData += fieldSize;
		Tester.Assert(fieldSize <= 65535);
		*(int*)pCurrData = ItemAmount;
		pCurrData += 4;
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
			MoneyCost = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 1)
		{
			pCurrData += PurchasedItem.Deserialize(pCurrData);
		}
		if (num > 2)
		{
			ItemAmount = *(int*)pCurrData;
			pCurrData += 4;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
