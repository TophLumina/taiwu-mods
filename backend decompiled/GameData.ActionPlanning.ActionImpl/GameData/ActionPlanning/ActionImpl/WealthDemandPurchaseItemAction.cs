using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.Item;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.ActionPlanning.ActionImpl;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class WealthDemandPurchaseItemAction : ICharacterActionImpl, ISerializableGameData
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

	bool ICharacterActionImpl.OfflineInitActionData(DataContext context, Character character, ContextArgGroupHandle argGroup, CharacterActionData actionData)
	{
		sbyte itemType = argGroup.ItemType;
		short itemTemplateId = argGroup.ItemTemplateId;
		if ((itemType == 3 || itemType == 11) ? true : false)
		{
			return false;
		}
		int money = character.GetResource(6);
		int price = ItemTemplateHelper.GetBaseValue(itemType, itemTemplateId) * 2 * character.GetOrganizationInfo().GetOrgMemberConfig().PurchaseItemDiscount / 100;
		if (price <= 0 || money < price)
		{
			return false;
		}
		MoneyCost = price;
		PurchasedItem = new TemplateKey(itemType, itemTemplateId);
		ItemAmount = 1;
		return true;
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
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int selfCharId = character.GetId();
		int currDate = DomainManager.World.GetCurrDate();
		Location location = character.GetValidLocation();
		Location settlementLocation = DomainManager.Map.GetBelongSettlementBlock(location).GetLocation();
		character.ChangeResource(context, 6, -MoneyCost);
		lifeRecordCollection.AddPurchaseItem1(selfCharId, currDate, settlementLocation, PurchasedItem.ItemType, PurchasedItem.TemplateId);
		character.CreateInventoryItem(context, PurchasedItem.ItemType, PurchasedItem.TemplateId, ItemAmount);
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
