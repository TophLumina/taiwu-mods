using GameData.ActionPlanning.ActionImpl.Helper;
using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.Character.Ai;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.World.Notification;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.ActionPlanning.ActionImpl;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class WealthDemandRobGraveResourceAction : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort ResourceType = 0;

		public const ushort Amount = 1;

		public const ushort Succeed = 2;

		public const ushort TargetGraveId = 3;

		public const ushort Count = 4;

		public static readonly string[] FieldId2FieldName = new string[4] { "ResourceType", "Amount", "Succeed", "TargetGraveId" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public sbyte ResourceType;

	[SerializableGameDataField(FieldIndex = 1)]
	public int Amount;

	[SerializableGameDataField(FieldIndex = 2)]
	public bool Succeed;

	[SerializableGameDataField(FieldIndex = 3)]
	public int TargetGraveId;

	bool ICharacterActionImpl.OfflineInitActionData(DataContext context, Character character, ContextArgGroupHandle argGroup, CharacterActionData actionData)
	{
		sbyte resourceType = argGroup.ResourceType;
		int amount = argGroup.Amount;
		sbyte requestActionType = 4;
		int targetCharId = ActionHelper.GetTargetGraveId(context, character, (Grave grave) => grave.GetResources().Get(resourceType) >= amount, 1);
		if (targetCharId < 0)
		{
			return false;
		}
		sbyte mainAttributeType = AiHelper.DemandActionType.ToMainAttributeType(requestActionType, isSkill: false);
		if (mainAttributeType >= 0 && character.GetCurrMainAttribute(mainAttributeType) < GlobalConfig.Instance.HarmfulActionCost)
		{
			return false;
		}
		int successRate = 7 * (100 + character.GetPersonality(6) * 5) / 35;
		ResourceType = resourceType;
		Amount = amount;
		Succeed = context.Random.CheckPercentProb(successRate);
		TargetGraveId = targetCharId;
		return true;
	}

	bool ICharacterActionImpl.CheckValid(Character character, CharacterActionData actionData)
	{
		if (!DomainManager.Character.TryGetElement_Graves(TargetGraveId, out var grave))
		{
			return false;
		}
		ResourceInts resources = grave.GetResources();
		return resources.Get(ResourceType) >= Amount;
	}

	void ICharacterActionImpl.PostExecute(DataContext context, Character character, CharacterActionData actionData)
	{
		int selfCharId = character.GetId();
		MonthlyNotificationCollection monthlyNotificationCollection = DomainManager.World.GetMonthlyNotificationCollection();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		Location location = character.GetLocation();
		int currDate = DomainManager.World.GetCurrDate();
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		if (selfCharId != taiwuCharId)
		{
			character.ChangeCurrMainAttribute(context, 3, -GlobalConfig.Instance.HarmfulActionCost);
		}
		if (DomainManager.Character.IsTaiwuPeople(TargetGraveId))
		{
			monthlyNotificationCollection.AddDigResource(selfCharId, location, TargetGraveId, ResourceType);
		}
		if (Succeed)
		{
			Grave element_Graves = DomainManager.Character.GetElement_Graves(TargetGraveId);
			character.ChangeResource(context, ResourceType, Amount);
			ResourceInts resources = element_Graves.GetResources();
			resources.Change(ResourceType, -Amount);
			element_Graves.SetResources(ref resources, context);
			lifeRecordCollection.AddRobResourceFromGraveSucceed(selfCharId, currDate, TargetGraveId, location, ResourceType, Amount);
			int secretInfoOffset = DomainManager.Information.GetSecretInformationCollection().AddRobGraveResource(selfCharId, TargetGraveId, ResourceType);
			DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
		}
		else
		{
			lifeRecordCollection.AddRobResourceFromGraveFail(selfCharId, currDate, TargetGraveId, location, ResourceType);
		}
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 12;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = 4;
		byte* num = pData + 2;
		*num = (byte)ResourceType;
		byte* num2 = num + 1;
		*(int*)num2 = Amount;
		byte* num3 = num2 + 4;
		*num3 = (Succeed ? ((byte)1) : ((byte)0));
		byte* num4 = num3 + 1;
		*(int*)num4 = TargetGraveId;
		int totalSize = (int)(num4 + 4 - pData);
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
		if (num > 2)
		{
			Succeed = *pCurrData != 0;
			pCurrData++;
		}
		if (num > 3)
		{
			TargetGraveId = *(int*)pCurrData;
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
