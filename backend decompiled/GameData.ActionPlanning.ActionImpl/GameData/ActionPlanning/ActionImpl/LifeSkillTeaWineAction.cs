using System;
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
public class LifeSkillTeaWineAction : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort ItemTemplateKey = 0;

		public const ushort Amount = 1;

		public const ushort Count = 2;

		public static readonly string[] FieldId2FieldName = new string[2] { "ItemTemplateKey", "Amount" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public TemplateKey ItemTemplateKey;

	[SerializableGameDataField(FieldIndex = 1)]
	public int Amount;

	bool ICharacterActionImpl.OfflineInitActionData(DataContext context, Character character, ContextArgGroupHandle argGroup, CharacterActionData actionData)
	{
		sbyte targetGrade = (sbyte)Math.Min(character.GetLifeSkillAttainment(5) / 75 - context.Random.Next(4), 8);
		if (targetGrade < 0)
		{
			actionData.Succeed = false;
			return false;
		}
		sbyte behaviorType = character.GetBehaviorType();
		sbyte eatForbiddenFoodChance = AiHelper.UpdateStatusConstants.EatForbiddenFoodChance[behaviorType];
		bool allowWines = !character.IsForbiddenToDrinkingWines() || context.Random.CheckPercentProb(eatForbiddenFoodChance);
		Span<short> validTeaWines = stackalloc short[4] { 27, 18, 9, 0 };
		int validTeaWineCount = (allowWines ? 4 : 2);
		sbyte itemType = 9;
		short groupId = validTeaWines[context.Random.Next(validTeaWineCount)];
		short itemTemplateId = ItemTemplateHelper.GetTemplateIdInGroup(itemType, groupId, targetGrade);
		actionData.Succeed = true;
		ItemTemplateKey = new TemplateKey(itemType, itemTemplateId);
		Amount = 1;
		return true;
	}

	bool ICharacterActionImpl.CheckValid(Character character, CharacterActionData actionData)
	{
		return true;
	}

	void ICharacterActionImpl.PostExecute(DataContext context, Character character, CharacterActionData actionData)
	{
		int selfCharId = character.GetId();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int currDate = DomainManager.World.GetCurrDate();
		Location location = character.GetLocation();
		if (actionData.Succeed)
		{
			TemplateKey templateKey = ItemTemplateKey;
			character.CreateInventoryItem(context, templateKey.ItemType, templateKey.TemplateId, Amount);
			lifeRecordCollection.AddCollectTeaWineSucceed(selfCharId, currDate, location, templateKey.ItemType, templateKey.TemplateId);
		}
		else
		{
			lifeRecordCollection.AddCollectTeaWineFail(selfCharId, currDate, location);
		}
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 6;
		totalSize += ItemTemplateKey.GetSerializedSize();
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
		int fieldSize = ItemTemplateKey.Serialize(pCurrData);
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
			pCurrData += ItemTemplateKey.Deserialize(pCurrData);
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
