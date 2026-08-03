using System;
using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.Character.Relation;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.ActionPlanning.ActionImpl;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class GainExpByLifeSkillBattleAction : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort Succeed = 0;

		public const ushort ExpGain = 1;

		public const ushort Count = 2;

		public static readonly string[] FieldId2FieldName = new string[2] { "Succeed", "ExpGain" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public bool Succeed;

	[SerializableGameDataField(FieldIndex = 1)]
	public int ExpGain;

	public static bool MatchTargetCharacter(DataContext context, Character character, Character targetChar, ContextArgGroupHandle args)
	{
		int charId = character.GetId();
		int relatedCharId = targetChar.GetId();
		if (DomainManager.Character.TryGetRelation(charId, relatedCharId, out var relation))
		{
			return FavorabilityType.GetFavorabilityType(relation.Favorability) >= 2;
		}
		return false;
	}

	bool ICharacterActionImpl.OfflineInitActionData(DataContext context, Character character, ContextArgGroupHandle argGroup, CharacterActionData actionData)
	{
		Character targetChar = actionData.TargetChar;
		short selfMaxAttainment = Math.Max((short)1, character.GetLifeSkillAttainments().GetMaxLifeSkillValue());
		short targetMaxAttainment = Math.Max((short)1, targetChar.GetLifeSkillAttainments().GetMaxLifeSkillValue());
		bool succeed = context.Random.CheckPercentProb(selfMaxAttainment * 50 / targetMaxAttainment);
		int expGain = (succeed ? DomainManager.Character.CalcExpGain(targetChar.GetOrganizationInfo().Grade, targetMaxAttainment * 50 / selfMaxAttainment) : DomainManager.Character.CalcExpGain(character.GetOrganizationInfo().Grade, selfMaxAttainment * 50 / targetMaxAttainment));
		Succeed = succeed;
		ExpGain = expGain;
		return true;
	}

	bool ICharacterActionImpl.CheckValid(Character character, CharacterActionData actionData)
	{
		return true;
	}

	void ICharacterActionImpl.PostExecuteForTaiwuTarget(DataContext context, Character character, CharacterActionData actionData)
	{
		Character targetChar = actionData.TargetChar;
		int characterId = character.GetId();
		Location location = targetChar.GetLocation();
		DomainManager.World.GetMonthlyEventCollection().AddRequestLifeSkillBattle(characterId, location, targetChar.GetId());
		CharacterDomain.AddLockMovementCharSet(characterId);
	}

	void ICharacterActionImpl.PostExecute(DataContext context, Character character, CharacterActionData actionData)
	{
		int selfCharId = character.GetId();
		Character targetChar = actionData.TargetChar;
		int targetCharId = targetChar.GetId();
		int currDate = DomainManager.World.GetCurrDate();
		Location location = character.GetLocation();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		Character winner;
		if (Succeed)
		{
			lifeRecordCollection.AddLifeSkillBattleWin(selfCharId, currDate, targetCharId, location);
			winner = character;
		}
		else
		{
			lifeRecordCollection.AddLifeSkillBattleLose(selfCharId, currDate, targetCharId, location);
			winner = targetChar;
		}
		winner.ChangeExp(context, ExpGain);
		int secretInfoOffset = DomainManager.Information.GetSecretInformationCollection().AddLifeSkillBattleWin(selfCharId, targetCharId);
		DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
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
		*(int*)num2 = ExpGain;
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
