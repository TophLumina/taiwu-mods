using System.Collections.Generic;
using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.Character.Ai;
using GameData.Domains.Item;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.ActionPlanning.ActionImpl;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class SocialStatusSellItemAction : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort Succeed = 0;

		public const ushort ItemKey = 1;

		public const ushort Amount = 2;

		public const ushort Price = 3;

		public const ushort Count = 4;

		public static readonly string[] FieldId2FieldName = new string[4] { "Succeed", "ItemKey", "Amount", "Price" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public bool Succeed;

	[SerializableGameDataField(FieldIndex = 1)]
	public ItemKey ItemKey;

	[SerializableGameDataField(FieldIndex = 2)]
	public int Amount;

	[SerializableGameDataField(FieldIndex = 3)]
	public int Price;

	bool ICharacterActionImpl.OfflineInitActionData(DataContext context, Character character, ContextArgGroupHandle argGroup, CharacterActionData actionData)
	{
		if (!DomainManager.Merchant.TryGetMerchantData(character.GetId(), out var merchantData))
		{
			return false;
		}
		List<ItemKey> itemKeys = context.AdvanceMonthRelatedData.ItemKeys.Occupy();
		if (merchantData.GoodsList0 != null)
		{
			itemKeys.AddRange(merchantData.GoodsList0.Items.Keys);
		}
		if (merchantData.GoodsList1 != null)
		{
			itemKeys.AddRange(merchantData.GoodsList1.Items.Keys);
		}
		if (merchantData.GoodsList2 != null)
		{
			itemKeys.AddRange(merchantData.GoodsList2.Items.Keys);
		}
		if (merchantData.GoodsList3 != null)
		{
			itemKeys.AddRange(merchantData.GoodsList3.Items.Keys);
		}
		if (merchantData.GoodsList4 != null)
		{
			itemKeys.AddRange(merchantData.GoodsList4.Items.Keys);
		}
		if (merchantData.GoodsList5 != null)
		{
			itemKeys.AddRange(merchantData.GoodsList5.Items.Keys);
		}
		if (merchantData.GoodsList6 != null)
		{
			itemKeys.AddRange(merchantData.GoodsList6.Items.Keys);
		}
		ItemKey itemKey = itemKeys.GetRandomOrDefault(context.Random, ItemKey.Invalid);
		context.AdvanceMonthRelatedData.ItemKeys.Release(ref itemKeys);
		if (!itemKey.IsValid())
		{
			return false;
		}
		int price = ItemTemplateHelper.GetBaseValue(itemKey.ItemType, itemKey.TemplateId) * 150 / 100;
		Character targetChar = actionData.TargetChar;
		if (targetChar.GetResource(6) < price)
		{
			return false;
		}
		int successChance = 40 + targetChar.GetLifeSkillAttainment(5) / 10;
		ItemKey = itemKey;
		Amount = 1;
		Price = price;
		Succeed = context.Random.CheckPercentProb(successChance);
		return true;
	}

	bool ICharacterActionImpl.CheckValid(Character character, CharacterActionData actionData)
	{
		if (DomainManager.Merchant.MerchantHasTargetItem(character.GetId(), ItemKey, Amount))
		{
			return actionData.TargetChar.GetResource(6) >= Price;
		}
		return false;
	}

	void ICharacterActionImpl.PostExecuteForTaiwuTarget(DataContext context, Character character, CharacterActionData actionData)
	{
		Character targetChar = actionData.TargetChar;
		int selfCharId = character.GetId();
		int targetCharId = targetChar.GetId();
		Location location = targetChar.GetLocation();
		DomainManager.World.GetMonthlyEventCollection().AddAdviseSales(selfCharId, location, targetCharId, (ulong)ItemKey, Price, Amount);
		CharacterDomain.AddLockMovementCharSet(character.GetId());
	}

	void ICharacterActionImpl.PostExecute(DataContext context, Character character, CharacterActionData actionData)
	{
		Character targetChar = actionData.TargetChar;
		int selfCharId = character.GetId();
		int targetCharId = targetChar.GetId();
		sbyte behaviorType = character.GetBehaviorType();
		int currDate = DomainManager.World.GetCurrDate();
		Location location = character.GetLocation();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		if (Succeed)
		{
			character.ChangeResource(context, 6, Price);
			targetChar.ChangeResource(context, 6, -Price);
			DomainManager.Merchant.RemoveExistingMerchantItem(context, selfCharId, ItemKey, Amount);
			targetChar.AddInventoryItem(context, ItemKey, Amount);
			short favorChange = AiHelper.GeneralActionConstants.GetBegSucceedFavorabilityChange(context.Random, behaviorType);
			DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, character, targetChar, favorChange);
			lifeRecordCollection.AddSellSucceed(selfCharId, currDate, targetCharId, location, ItemKey.ItemType, ItemKey.TemplateId);
		}
		else
		{
			short favorChange2 = AiHelper.GeneralActionConstants.GetBegFailFavorabilityChange(context.Random, behaviorType);
			DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, character, targetChar, favorChange2);
			lifeRecordCollection.AddSellFail(selfCharId, currDate, targetCharId, location, ItemKey.ItemType, ItemKey.TemplateId);
		}
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 11;
		totalSize += ItemKey.GetSerializedSize();
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 4;
		pCurrData += 2;
		*pCurrData = (Succeed ? ((byte)1) : ((byte)0));
		pCurrData++;
		int fieldSize = ItemKey.Serialize(pCurrData);
		pCurrData += fieldSize;
		Tester.Assert(fieldSize <= 65535);
		*(int*)pCurrData = Amount;
		pCurrData += 4;
		*(int*)pCurrData = Price;
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
			Succeed = *pCurrData != 0;
			pCurrData++;
		}
		if (num > 1)
		{
			pCurrData += ItemKey.Deserialize(pCurrData);
		}
		if (num > 2)
		{
			Amount = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 3)
		{
			Price = *(int*)pCurrData;
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
