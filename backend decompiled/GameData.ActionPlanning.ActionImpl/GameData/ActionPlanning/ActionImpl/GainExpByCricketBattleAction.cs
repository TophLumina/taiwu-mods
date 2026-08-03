using System;
using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.Character.Ai;
using GameData.Domains.Item;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.World.MonthlyEvent;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.ActionPlanning.ActionImpl;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class GainExpByCricketBattleAction : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort Wager = 0;

		public const ushort Succeed = 1;

		public const ushort ExpGain = 2;

		public const ushort Count = 3;

		public static readonly string[] FieldId2FieldName = new string[3] { "Wager", "Succeed", "ExpGain" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public Wager Wager;

	[SerializableGameDataField(FieldIndex = 1)]
	public bool Succeed;

	[SerializableGameDataField(FieldIndex = 2)]
	public int ExpGain;

	public static bool MatchTargetCharacter(DataContext context, Character character, Character targetChar, ContextArgGroupHandle args)
	{
		if (targetChar.IsTaiwu())
		{
			return true;
		}
		sbyte behaviorType = character.GetBehaviorType();
		sbyte selfGrade = character.GetOrganizationInfo().Grade;
		sbyte[] array = AiHelper.GeneralActionConstants.CricketBattleGradeOffsets[behaviorType];
		foreach (sbyte offset in array)
		{
			if (selfGrade + offset == targetChar.GetInteractionGrade())
			{
				return true;
			}
		}
		return false;
	}

	bool ICharacterActionImpl.OfflineInitActionData(DataContext context, Character character, ContextArgGroupHandle argGroup, CharacterActionData actionData)
	{
		Character targetChar = actionData.TargetChar;
		short targetAttainment = Math.Max((short)1, targetChar.GetLifeSkillAttainment(15));
		sbyte selfGrade = character.GetOrganizationInfo().Grade;
		sbyte targetGrade = targetChar.GetInteractionGrade();
		short selfEclecticAttainment = character.GetLifeSkillAttainment(15);
		int successRate = selfEclecticAttainment * 50 / targetAttainment + (selfGrade - targetGrade) * 20;
		bool succeed = context.Random.CheckPercentProb(successRate);
		Wager wager = (succeed ? DomainManager.Item.SelectCharacterValidWager(context, targetChar) : DomainManager.Item.SelectCharacterValidWager(context, character));
		int expGain = (succeed ? DomainManager.Character.CalcExpGain(targetGrade, targetAttainment * 50 / selfEclecticAttainment) : DomainManager.Character.CalcExpGain(selfGrade, selfEclecticAttainment * 50 / targetAttainment));
		Wager = wager;
		Succeed = succeed;
		ExpGain = expGain;
		return true;
	}

	bool ICharacterActionImpl.CheckValid(Character character, CharacterActionData actionData)
	{
		return DomainManager.Item.CheckCharacterHasWager(Succeed ? actionData.TargetChar : character, Wager);
	}

	void ICharacterActionImpl.PostExecuteForTaiwuTarget(DataContext context, Character character, CharacterActionData actionData)
	{
		MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
		int selfCharId = character.GetId();
		Location location = actionData.TargetChar.GetLocation();
		monthlyEventCollection.AddRequestCricketBattle(selfCharId, location, actionData.TargetCharId);
		CharacterDomain.AddLockMovementCharSet(selfCharId);
	}

	void ICharacterActionImpl.PostExecute(DataContext context, Character character, CharacterActionData actionData)
	{
		Character targetChar = actionData.TargetChar;
		int selfCharId = character.GetId();
		int targetCharId = targetChar.GetId();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int currDate = DomainManager.World.GetCurrDate();
		Location location = character.GetLocation();
		if (Succeed)
		{
			character.ChangeExp(context, ExpGain);
			lifeRecordCollection.AddCricketBattleWin(selfCharId, currDate, targetCharId, location);
			DomainManager.Item.TransferWager(context, targetChar, character, Wager);
			int secretInfoOffset = DomainManager.Information.GetSecretInformationCollection().AddCricketBattleWin(selfCharId, targetCharId);
			DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
		}
		else
		{
			targetChar.ChangeExp(context, ExpGain);
			lifeRecordCollection.AddCricketBattleLose(selfCharId, currDate, targetCharId, location);
			DomainManager.Item.TransferWager(context, character, targetChar, Wager);
			int secretInfoOffset2 = DomainManager.Information.GetSecretInformationCollection().AddCricketBattleWin(targetCharId, selfCharId);
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
		totalSize += Wager.GetSerializedSize();
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
		int fieldSize = Wager.Serialize(pCurrData);
		pCurrData += fieldSize;
		Tester.Assert(fieldSize <= 65535);
		*pCurrData = (Succeed ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(int*)pCurrData = ExpGain;
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
			pCurrData += Wager.Deserialize(pCurrData);
		}
		if (num > 1)
		{
			Succeed = *pCurrData != 0;
			pCurrData++;
		}
		if (num > 2)
		{
			ExpGain = *(int*)pCurrData;
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
