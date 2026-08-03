using System;
using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.World.Notification;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.ActionPlanning.ActionImpl;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class LifeSkillAwakeningAction : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort AwakeningLifeSkillType = 0;

		public const ushort IncreasedLifeSkillType = 1;

		public const ushort Count = 2;

		public static readonly string[] FieldId2FieldName = new string[2] { "AwakeningLifeSkillType", "IncreasedLifeSkillType" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public sbyte AwakeningLifeSkillType;

	[SerializableGameDataField(FieldIndex = 1)]
	public sbyte IncreasedLifeSkillType;

	public static bool MatchTargetCharacter(DataContext context, Character character, Character targetChar, ContextArgGroupHandle args)
	{
		bool hasValidLifeSkillType = false;
		for (sbyte lifeSkillType = 0; lifeSkillType < 16; lifeSkillType++)
		{
			if (targetChar.GetBaseLifeSkillQualifications()[lifeSkillType] < 90)
			{
				hasValidLifeSkillType = true;
				break;
			}
		}
		if (!hasValidLifeSkillType)
		{
			return false;
		}
		if (character.GetLifeSkillAttainment(13) >= 200)
		{
			return true;
		}
		if (character.GetLifeSkillAttainment(12) >= 200)
		{
			return true;
		}
		return false;
	}

	bool ICharacterActionImpl.OfflineInitActionData(DataContext context, Character character, ContextArgGroupHandle argGroup, CharacterActionData actionData)
	{
		short lifeSkillAttainment = character.GetLifeSkillAttainment(13);
		short selfTaoismAttainment = character.GetLifeSkillAttainment(12);
		if (lifeSkillAttainment < 200 && selfTaoismAttainment < 200)
		{
			return false;
		}
		Character targetChar = actionData.TargetChar;
		SpanList<sbyte> canImproveLifeSkillTypes = stackalloc sbyte[16];
		targetChar.GetCanImproveLifeSkillTypes(ref canImproveLifeSkillTypes);
		if (canImproveLifeSkillTypes.Count == 0)
		{
			throw new Exception($"Selected character {targetChar} does not have a life skill type that can be awakened by {this}.");
		}
		sbyte selectedLifeSkillType = canImproveLifeSkillTypes.GetRandom(context.Random);
		Span<sbyte> religiousLifeSkillTypes = stackalloc sbyte[LifeSkillType.ReligiousTypes.Length];
		int religiousLifeSkillTypeCount = 0;
		sbyte[] religiousTypes = LifeSkillType.ReligiousTypes;
		foreach (sbyte lifeSkillType in religiousTypes)
		{
			if (character.GetLifeSkillAttainment(lifeSkillType) >= 200)
			{
				religiousLifeSkillTypes[religiousLifeSkillTypeCount] = lifeSkillType;
				religiousLifeSkillTypeCount++;
			}
		}
		if (religiousLifeSkillTypeCount == 0)
		{
			throw new Exception($"{this} cannot perform awakening action to {targetChar} due to insufficient buddhism or taoism attainment.");
		}
		sbyte religiousLifeSkillType = religiousLifeSkillTypes[context.Random.Next(religiousLifeSkillTypeCount)];
		AwakeningLifeSkillType = religiousLifeSkillType;
		IncreasedLifeSkillType = selectedLifeSkillType;
		return true;
	}

	bool ICharacterActionImpl.CheckValid(Character character, CharacterActionData actionData)
	{
		return actionData.TargetChar.GetLifeSkillQualification(IncreasedLifeSkillType) < 90;
	}

	void ICharacterActionImpl.PostExecuteForTaiwuTarget(DataContext context, Character character, CharacterActionData actionData)
	{
		Character targetChar = actionData.TargetChar;
		if (IncreasedLifeSkillType >= 0)
		{
			MonthlyNotificationCollection monthlyNotifications = DomainManager.World.GetMonthlyNotificationCollection();
			switch (AwakeningLifeSkillType)
			{
			case 13:
				monthlyNotifications.AddEnlightenedByBuddhism(character.GetId(), character.GetLocation(), targetChar.GetId(), IncreasedLifeSkillType);
				break;
			case 12:
				monthlyNotifications.AddEnlightenedByDaoism(character.GetId(), character.GetLocation(), targetChar.GetId(), IncreasedLifeSkillType);
				break;
			default:
				throw new Exception($"{character.GetId()} is trying to awake {targetChar.GetId()}'s {AwakeningLifeSkillType}, which is neither Buddhism nor Taoism");
			}
		}
		ApplyChanges(context, character, targetChar);
	}

	void ICharacterActionImpl.PostExecute(DataContext context, Character character, CharacterActionData actionData)
	{
		ApplyChanges(context, character, actionData.TargetChar);
	}

	private unsafe void ApplyChanges(DataContext context, Character selfChar, Character targetChar)
	{
		int selfCharId = selfChar.GetId();
		int targetCharId = targetChar.GetId();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int currDate = DomainManager.World.GetCurrDate();
		Location location = selfChar.GetLocation();
		if (IncreasedLifeSkillType >= 0)
		{
			switch (AwakeningLifeSkillType)
			{
			case 13:
				lifeRecordCollection.AddBuddismAwakeningSucceed(selfCharId, currDate, targetCharId, location);
				break;
			case 12:
				lifeRecordCollection.AddTaoismAwakeningSucceed(selfCharId, currDate, targetCharId, location);
				break;
			default:
				throw new Exception($"{selfChar.GetId()} is trying to awake {targetChar.GetId()}'s {AwakeningLifeSkillType}, which is neither Buddhism nor Taoism");
			}
			LifeSkillShorts baseLifeSkillQualifications = targetChar.GetBaseLifeSkillQualifications();
			ref short reference = ref baseLifeSkillQualifications.Items[IncreasedLifeSkillType];
			reference++;
			targetChar.SetBaseLifeSkillQualifications(ref baseLifeSkillQualifications, context);
		}
		else
		{
			switch (AwakeningLifeSkillType)
			{
			case 13:
				lifeRecordCollection.AddBuddismAwakeningFail(selfCharId, currDate, targetCharId, location);
				return;
			case 12:
				lifeRecordCollection.AddTaoismAwakeningFail(selfCharId, currDate, targetCharId, location);
				return;
			}
			throw new Exception($"{selfChar.GetId()} is trying to awake {targetChar.GetId()}'s {AwakeningLifeSkillType}, which is neither Buddhism nor Taoism");
		}
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 4;
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
		*num = (byte)AwakeningLifeSkillType;
		byte* num2 = num + 1;
		*num2 = (byte)IncreasedLifeSkillType;
		int totalSize = (int)(num2 + 1 - pData);
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
			AwakeningLifeSkillType = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (num > 1)
		{
			IncreasedLifeSkillType = (sbyte)(*pCurrData);
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
