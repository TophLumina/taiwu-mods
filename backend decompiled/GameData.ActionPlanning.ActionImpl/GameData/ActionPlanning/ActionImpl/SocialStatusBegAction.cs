using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.Character.Ai;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.World.MonthlyEvent;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.ActionPlanning.ActionImpl;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class SocialStatusBegAction : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort Succeed = 0;

		public const ushort MoneyAmount = 1;

		public const ushort Count = 2;

		public static readonly string[] FieldId2FieldName = new string[2] { "Succeed", "MoneyAmount" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public bool Succeed;

	[SerializableGameDataField(FieldIndex = 1)]
	public int MoneyAmount;

	public static bool MatchTargetCharacter(DataContext context, Character character, Character targetChar, ContextArgGroupHandle args)
	{
		return targetChar.GetResource(6) >= 500;
	}

	bool ICharacterActionImpl.OfflineInitActionData(DataContext context, Character character, ContextArgGroupHandle argGroup, CharacterActionData actionData)
	{
		sbyte behaviorType = character.GetBehaviorType();
		sbyte startChance = AiHelper.GeneralActionConstants.StartBegChance[behaviorType];
		if (!context.Random.CheckPercentProb(startChance))
		{
			return false;
		}
		sbyte targetBehaviorType = actionData.TargetChar.GetBehaviorType();
		sbyte successRate = AiHelper.GeneralActionConstants.BegSuccessChance[targetBehaviorType];
		MoneyAmount = context.Random.Next(AiHelper.GeneralActionConstants.BeggingMoneyRange[0], AiHelper.GeneralActionConstants.BeggingMoneyRange[1]);
		Succeed = context.Random.CheckPercentProb(successRate);
		return true;
	}

	bool ICharacterActionImpl.CheckValid(Character character, CharacterActionData actionData)
	{
		return actionData.TargetChar.GetResource(6) >= MoneyAmount;
	}

	void ICharacterActionImpl.PostExecuteForTaiwuTarget(DataContext context, Character character, CharacterActionData actionData)
	{
		MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
		int selfCharId = character.GetId();
		Location location = actionData.TargetChar.GetLocation();
		monthlyEventCollection.AddAskForMoney(selfCharId, location, actionData.TargetCharId);
		CharacterDomain.AddLockMovementCharSet(selfCharId);
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
			character.ChangeResource(context, 6, MoneyAmount);
			targetChar.ChangeResource(context, 6, -MoneyAmount);
			short favorChange = AiHelper.GeneralActionConstants.GetBegSucceedFavorabilityChange(context.Random, behaviorType);
			DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, character, targetChar, favorChange);
			lifeRecordCollection.AddAskForMoneySucceed(selfCharId, currDate, targetCharId, location, 6, MoneyAmount);
			int secretInfoOffset = DomainManager.Information.GetSecretInformationCollection().AddAcceptRequestGivingMoney(targetCharId, selfCharId, MoneyAmount);
			DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
		}
		else
		{
			short favorChange2 = AiHelper.GeneralActionConstants.GetBegFailFavorabilityChange(context.Random, behaviorType);
			DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, character, targetChar, favorChange2);
			lifeRecordCollection.AddAskForMoneyFail(selfCharId, currDate, targetCharId, location, 6, MoneyAmount);
			int secretInfoOffset2 = DomainManager.Information.GetSecretInformationCollection().AddRefuseRequestGivingMoney(targetCharId, selfCharId, MoneyAmount);
			DomainManager.Information.AddSecretInformation(context, secretInfoOffset2);
		}
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
		*num = (Succeed ? ((byte)1) : ((byte)0));
		byte* num2 = num + 1;
		*(int*)num2 = MoneyAmount;
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
			Succeed = *pCurrData != 0;
			pCurrData++;
		}
		if (num > 1)
		{
			MoneyAmount = *(int*)pCurrData;
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
