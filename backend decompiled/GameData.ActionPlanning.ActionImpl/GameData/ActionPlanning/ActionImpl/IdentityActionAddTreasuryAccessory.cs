using GameData.ActionPlanning.ActionImpl.Helper;
using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.Item;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.ActionPlanning.ActionImpl;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class IdentityActionAddTreasuryAccessory : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort TargetItem = 0;

		public const ushort Amount = 1;

		public const ushort Count = 2;

		public static readonly string[] FieldId2FieldName = new string[2] { "TargetItem", "Amount" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public ItemKey TargetItem;

	[SerializableGameDataField(FieldIndex = 1)]
	public int Amount;

	bool ICharacterActionImpl.OfflineInitActionData(DataContext context, Character character, ContextArgGroupHandle argGroup, CharacterActionData actionData)
	{
		sbyte grade = ItemDomain.GetGradeAfterSatisfactionOffset(character.GetOrganizationInfo().Grade);
		ItemBase selectedItem = character.SelectSpareableItem(context, grade, allowUsed: true, ItemCondition);
		if (selectedItem == null)
		{
			return false;
		}
		if (!ActionHelper.CanInteractTreasury(character))
		{
			return false;
		}
		TargetItem = selectedItem.GetItemKey();
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

	void ICharacterActionImpl.PostExecute(DataContext context, Character character, CharacterActionData actionData)
	{
		short settlementId = character.GetOrganizationInfo().SettlementId;
		character.RemoveInventoryItem(context, TargetItem, Amount, deleteItem: false);
		DomainManager.Organization.StoreItemInTreasury(context, settlementId, character, TargetItem, Amount, -1);
	}

	private static bool ItemCondition(ItemKey itemKey)
	{
		return itemKey.ItemType == 2;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 6;
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
		*(short*)pCurrData = 2;
		pCurrData += 2;
		int fieldSize = TargetItem.Serialize(pCurrData);
		pCurrData += fieldSize;
		Tester.Assert(fieldSize <= 65535);
		*(int*)pCurrData = Amount;
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
			pCurrData += TargetItem.Deserialize(pCurrData);
		}
		if (num > 1)
		{
			Amount = *(int*)pCurrData;
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
