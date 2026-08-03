using System.Collections.Generic;
using Config;
using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.CombatSkill;
using GameData.Domains.Item;
using GameData.Domains.Map;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.ActionPlanning.ActionImpl;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class GainExpByReadingAction : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort DurabilityReduction = 0;

		public const ushort ExpGain = 1;

		public const ushort ItemKey = 2;

		public const ushort Count = 3;

		public static readonly string[] FieldId2FieldName = new string[3] { "DurabilityReduction", "ExpGain", "ItemKey" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public short DurabilityReduction;

	[SerializableGameDataField(FieldIndex = 1)]
	public int ExpGain;

	[SerializableGameDataField(FieldIndex = 2)]
	public ItemKey ItemKey = ItemKey.Invalid;

	bool ICharacterActionImpl.OfflineInitActionData(DataContext context, GameData.Domains.Character.Character character, ContextArgGroupHandle argGroup, CharacterActionData actionData)
	{
		ItemKey = SelectBookToReadForExp(context, character);
		if (!ItemKey.IsValid())
		{
			return false;
		}
		sbyte grade = Config.SkillBook.Instance[ItemKey.TemplateId].Grade;
		short durabilityReduction = 3;
		short durability = DomainManager.Item.GetElement_SkillBooks(ItemKey.Id).GetCurrDurability();
		if (durabilityReduction > durability)
		{
			durabilityReduction = durability;
		}
		ExpGain = SkillGradeData.Instance[grade].ReadingExpGainPerPage * durabilityReduction;
		DurabilityReduction = durabilityReduction;
		return true;
	}

	bool ICharacterActionImpl.CheckValid(GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
		return character.GetInventory().Items.ContainsKey(ItemKey);
	}

	void ICharacterActionImpl.PostExecute(DataContext context, GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
		int selfCharId = character.GetId();
		int currDate = DomainManager.World.GetCurrDate();
		Location location = character.GetLocation();
		character.ChangeExp(context, ExpGain);
		GameData.Domains.Item.SkillBook skillBook = DomainManager.Item.GetElement_SkillBooks(ItemKey.Id);
		if (skillBook.GetCurrDurability() <= DurabilityReduction)
		{
			character.RemoveInventoryItem(context, ItemKey, 1, deleteItem: true);
		}
		else
		{
			skillBook.ChangeCurrDurability(context, -DurabilityReduction);
		}
		DomainManager.LifeRecord.GetLifeRecordCollection().AddGainExpByReadingOldBook(selfCharId, currDate, location, ItemKey.ItemType, ItemKey.TemplateId);
	}

	private ItemKey SelectBookToReadForExp(DataContext context, GameData.Domains.Character.Character character)
	{
		int charId = character.GetId();
		Inventory inventory = character.GetInventory();
		Dictionary<short, GameData.Domains.CombatSkill.CombatSkill> combatSkills = DomainManager.CombatSkill.GetCharCombatSkills(charId);
		List<ItemKey> books = context.AdvanceMonthRelatedData.ItemKeys.Occupy();
		foreach (ItemKey itemKey in inventory.Items.Keys)
		{
			if (itemKey.ItemType != 10)
			{
				continue;
			}
			GameData.Domains.Item.SkillBook skillBook = DomainManager.Item.GetElement_SkillBooks(itemKey.Id);
			if (skillBook.GetCurrDurability() >= skillBook.GetMaxDurability())
			{
				continue;
			}
			if (skillBook.IsCombatSkillBook())
			{
				if (combatSkills.TryGetValue(skillBook.GetCombatSkillTemplateId(), out var combatSkill) && CombatSkillStateHelper.IsReadNormalPagesMeetConditionOfBreakout(combatSkill.GetReadingState()))
				{
					books.Add(itemKey);
				}
				continue;
			}
			int index = character.FindLearnedLifeSkillIndex(skillBook.GetLifeSkillTemplateId());
			if (index >= 0 && character.GetLearnedLifeSkills()[index].IsAllPagesRead())
			{
				books.Add(itemKey);
			}
		}
		if (books.Count <= 0)
		{
			return ItemKey.Invalid;
		}
		return books.GetRandom(context.Random);
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 8;
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
		*(short*)pCurrData = 3;
		pCurrData += 2;
		*(short*)pCurrData = DurabilityReduction;
		pCurrData += 2;
		*(int*)pCurrData = ExpGain;
		pCurrData += 4;
		int fieldSize = ItemKey.Serialize(pCurrData);
		pCurrData += fieldSize;
		Tester.Assert(fieldSize <= 65535);
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
			DurabilityReduction = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 1)
		{
			ExpGain = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 2)
		{
			pCurrData += ItemKey.Deserialize(pCurrData);
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
