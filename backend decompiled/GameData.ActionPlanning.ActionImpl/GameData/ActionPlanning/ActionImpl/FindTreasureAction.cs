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
public class FindTreasureAction : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort Count = 0;
	}

	public int PhaseCount => 1;

	public bool CheckValid(Character character, CharacterActionData actionData)
	{
		return true;
	}

	public void OnStart(DataContext context, Character selfChar, CharacterActionData actionData)
	{
		if (!selfChar.IsInTaiwuGroup())
		{
			int selfCharId = selfChar.GetId();
			LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
			int currDate = DomainManager.World.GetCurrDate();
			Location currLocation = selfChar.GetLocation();
			Location targetLocation = actionData.GetActualTargetLocation();
			lifeRecordCollection.AddDecideToFindLostItem(selfCharId, currDate, currLocation, targetLocation);
		}
	}

	public void OnInterrupt(DataContext context, Character selfChar, CharacterActionData actionData)
	{
		int selfCharId = selfChar.GetId();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int currDate = DomainManager.World.GetCurrDate();
		Location currLocation = selfChar.GetLocation();
		lifeRecordCollection.AddFinishFIndingLostItem(selfCharId, currDate, currLocation);
	}

	public unsafe bool OnExecutePhase(DataContext context, Character selfChar, CharacterActionData actionData)
	{
		int selfCharId = selfChar.GetId();
		sbyte selfGrade = selfChar.GetOrganizationInfo().Grade;
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int currDate = DomainManager.World.GetCurrDate();
		Location currLocation = selfChar.GetLocation();
		if (!currLocation.IsValid())
		{
			return false;
		}
		MapBlockData currBlockData = DomainManager.Map.GetBlock(currLocation);
		Personalities personalities = selfChar.GetPersonalities();
		sbyte luck = personalities.Items[5];
		int chance = currBlockData.CalcFindTreasureChance(luck);
		if (context.Random.CheckPercentProb(chance))
		{
			ItemKeyAndDate itemAndDates = currBlockData.Items.Keys.GetRandom(context.Random);
			ItemKey itemKey = itemAndDates.ItemKey;
			int amount = currBlockData.Items[itemAndDates];
			DomainManager.Map.RemoveBlockItem(context, currBlockData, itemAndDates);
			selfChar.AddInventoryItem(context, itemKey, amount);
			lifeRecordCollection.AddFindLostItemSucceed(selfCharId, currDate, currLocation, itemKey.ItemType, itemKey.TemplateId);
			return ItemTemplateHelper.GetGrade(itemKey.ItemType, itemKey.TemplateId) >= selfGrade;
		}
		lifeRecordCollection.AddFindLostItemFail(selfCharId, currDate, currLocation);
		return false;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 2;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = 0;
		int totalSize = (int)(pData + 2 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		_ = *(ushort*)pData;
		int totalSize = (int)(pData + 2 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
