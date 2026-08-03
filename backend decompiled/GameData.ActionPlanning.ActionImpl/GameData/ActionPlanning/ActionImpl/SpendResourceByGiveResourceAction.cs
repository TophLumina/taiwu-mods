using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.Character.Ai;
using GameData.Domains.Map;
using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.ActionPlanning.ActionImpl;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class SpendResourceByGiveResourceAction : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort ResourceType = 0;

		public const ushort Amount = 1;

		public const ushort Count = 2;

		public static readonly string[] FieldId2FieldName = new string[2] { "ResourceType", "Amount" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public sbyte ResourceType;

	[SerializableGameDataField(FieldIndex = 1)]
	public int Amount;

	bool ICharacterActionImpl.OfflineInitActionData(DataContext context, Character character, ContextArgGroupHandle argGroup, CharacterActionData actionData)
	{
		sbyte resourceType = argGroup.ResourceType;
		int amount = character.GetResource(resourceType) - argGroup.Amount;
		if (amount <= 0)
		{
			return false;
		}
		ResourceType = resourceType;
		Amount = amount;
		return true;
	}

	bool ICharacterActionImpl.CheckValid(Character character, CharacterActionData actionData)
	{
		return character.GetResource(ResourceType) >= Amount;
	}

	void ICharacterActionImpl.PostExecuteForTaiwuTarget(DataContext context, Character character, CharacterActionData actionData)
	{
		int selfCharId = character.GetId();
		int targetCharId = actionData.TargetChar.GetId();
		Location location = character.GetLocation();
		DomainManager.World.GetMonthlyNotificationCollection().AddGivePresentResource(selfCharId, location, ResourceType, targetCharId);
		ApplyChanges(context, character, actionData);
	}

	void ICharacterActionImpl.PostExecute(DataContext context, Character character, CharacterActionData actionData)
	{
		ApplyChanges(context, character, actionData);
	}

	private void ApplyChanges(DataContext context, Character character, CharacterActionData actionData)
	{
		int selfCharId = character.GetId();
		int targetCharId = actionData.TargetChar.GetId();
		int currDate = DomainManager.World.GetCurrDate();
		Location location = character.GetLocation();
		character.ChangeResource(context, ResourceType, -Amount);
		actionData.TargetChar.ChangeResource(context, ResourceType, Amount);
		short favorChange = AiHelper.GeneralActionConstants.GetResourceFavorabilityChange(ResourceType, Amount);
		sbyte happinessChange = AiHelper.GeneralActionConstants.GetResourceHappinessChange(ResourceType, Amount);
		DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, actionData.TargetChar, character, favorChange);
		actionData.TargetChar.ChangeHappiness(context, happinessChange);
		DomainManager.LifeRecord.GetLifeRecordCollection().AddGiveResource(selfCharId, currDate, targetCharId, location, ResourceType, Amount);
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 7;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = 2;
		byte* num = pData + 2;
		*num = (byte)ResourceType;
		byte* num2 = num + 1;
		*(int*)num2 = Amount;
		int totalSize = (int)(num2 + 4 - pData);
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
			ResourceType = (sbyte)(*pCurrData);
			pCurrData++;
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
