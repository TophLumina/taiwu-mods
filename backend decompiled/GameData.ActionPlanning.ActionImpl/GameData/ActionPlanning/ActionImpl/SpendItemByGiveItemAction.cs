using GameData.ActionPlanning.ActionImpl.Helper;
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
public class SpendItemByGiveItemAction : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort TargetItem = 0;

		public const ushort Amount = 1;

		public const ushort RefusePoisonousItem = 2;

		public const ushort Count = 3;

		public static readonly string[] FieldId2FieldName = new string[3] { "TargetItem", "Amount", "RefusePoisonousItem" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public ItemKey TargetItem;

	[SerializableGameDataField(FieldIndex = 1)]
	public int Amount;

	[SerializableGameDataField(FieldIndex = 2)]
	public bool RefusePoisonousItem;

	bool ICharacterActionImpl.OfflineInitActionData(DataContext context, Character character, ContextArgGroupHandle argGroup, CharacterActionData actionData)
	{
		if (!character.IsInRegularSettlementRange())
		{
			return false;
		}
		sbyte targetBestGrade = actionData.TargetChar.GetInteractionGrade();
		ItemKey itemKey = ActionHelper.SelectSpareableItem(context, character, targetBestGrade, allowUsed: true);
		if (!itemKey.IsValid())
		{
			return false;
		}
		ItemBase selectedItem = DomainManager.Item.GetBaseItem(itemKey);
		if (selectedItem.GetCurrDurability() < selectedItem.GetMaxDurability())
		{
			return false;
		}
		TargetItem = itemKey;
		Amount = 1;
		return true;
	}

	bool ICharacterActionImpl.CheckValid(Character character, CharacterActionData actionData)
	{
		if (character.GetInventory().Items.TryGetValue(TargetItem, out var amount))
		{
			return amount >= Amount;
		}
		return false;
	}

	void ICharacterActionImpl.PostExecuteForTaiwuTarget(DataContext context, Character character, CharacterActionData actionData)
	{
		int selfCharId = character.GetId();
		int targetCharId = actionData.TargetCharId;
		Location location = character.GetLocation();
		DomainManager.World.GetMonthlyNotificationCollection().AddGivePresentItem(selfCharId, location, TargetItem.ItemType, TargetItem.TemplateId, targetCharId);
		ApplyChanges(context, character, actionData);
	}

	void ICharacterActionImpl.PostExecute(DataContext context, Character character, CharacterActionData actionData)
	{
		ApplyChanges(context, character, actionData);
	}

	private void ApplyChanges(DataContext context, Character character, CharacterActionData actionData)
	{
		Character targetChar = actionData.TargetChar;
		int selfCharId = character.GetId();
		int targetCharId = actionData.TargetCharId;
		int currDate = DomainManager.World.GetCurrDate();
		Location location = character.GetLocation();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		if (RefusePoisonousItem)
		{
			lifeRecordCollection.AddRefusePoisonousGift(selfCharId, currDate, targetCharId, location, TargetItem.ItemType, TargetItem.TemplateId);
			return;
		}
		lifeRecordCollection.AddGiveItem(selfCharId, currDate, targetCharId, location, TargetItem.ItemType, TargetItem.TemplateId);
		DomainManager.Character.TransferInventoryItem(context, character, targetChar, TargetItem, Amount);
		ItemBase baseItem = DomainManager.Item.GetBaseItem(TargetItem);
		int favorChange = baseItem.GetFavorabilityChange();
		DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, targetChar, character, favorChange);
		targetChar.ChangeHappiness(context, baseItem.GetHappinessChange());
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 7;
		totalSize += TargetItem.GetSerializedSize();
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
		*(int*)pCurrData = Amount;
		pCurrData += 4;
		*pCurrData = (RefusePoisonousItem ? ((byte)1) : ((byte)0));
		pCurrData++;
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
			Amount = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 2)
		{
			RefusePoisonousItem = *pCurrData != 0;
			pCurrData++;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
