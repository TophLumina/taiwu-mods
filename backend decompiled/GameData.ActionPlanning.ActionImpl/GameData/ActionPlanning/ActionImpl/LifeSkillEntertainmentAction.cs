using System;
using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.World.Notification;
using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.ActionPlanning.ActionImpl;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class LifeSkillEntertainmentAction : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort ActionLifeSkillType = 0;

		public const ushort Count = 1;

		public static readonly string[] FieldId2FieldName = new string[1] { "ActionLifeSkillType" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public sbyte ActionLifeSkillType;

	bool ICharacterActionImpl.OfflineInitActionData(DataContext context, Character character, ContextArgGroupHandle argGroup, CharacterActionData actionData)
	{
		ActionLifeSkillType = argGroup.LifeSkillType;
		if (ActionLifeSkillType >= 0)
		{
			return true;
		}
		Span<sbyte> entertainingLifeSkillTypes = stackalloc sbyte[LifeSkillType.EntertainingTypes.Length];
		int entertainingLifeSkillTypeCount = 0;
		sbyte[] entertainingTypes = LifeSkillType.EntertainingTypes;
		foreach (sbyte lifeSkillType in entertainingTypes)
		{
			if (character.GetLifeSkillAttainment(lifeSkillType) >= 200)
			{
				entertainingLifeSkillTypes[entertainingLifeSkillTypeCount] = lifeSkillType;
				entertainingLifeSkillTypeCount++;
			}
		}
		if (entertainingLifeSkillTypeCount == 0)
		{
			return false;
		}
		ActionLifeSkillType = entertainingLifeSkillTypes[context.Random.Next(entertainingLifeSkillTypeCount)];
		return true;
	}

	bool ICharacterActionImpl.CheckValid(Character character, CharacterActionData actionData)
	{
		return true;
	}

	void ICharacterActionImpl.PostExecuteForTaiwuTarget(DataContext context, Character character, CharacterActionData actionData)
	{
		Character targetChar = actionData.TargetChar;
		int targetCharId = targetChar.GetId();
		int selfCharId = character.GetId();
		MonthlyNotificationCollection monthlyNotifications = DomainManager.World.GetMonthlyNotificationCollection();
		Location location = character.GetLocation();
		switch (ActionLifeSkillType)
		{
		case 0:
			monthlyNotifications.AddAmuseOthersByMusic(targetCharId, location, selfCharId);
			break;
		case 1:
			monthlyNotifications.AddAmuseOthersByChess(targetCharId, location, selfCharId);
			break;
		case 2:
			monthlyNotifications.AddAmuseOthersByPoem(targetCharId, location, selfCharId);
			break;
		case 3:
			monthlyNotifications.AddAmuseOthersByPainting(targetCharId, location, selfCharId);
			break;
		default:
			throw new Exception($"Invalid life skill type for entertainment {ActionLifeSkillType}");
		}
		ApplyChanges(context, character, targetChar);
	}

	void ICharacterActionImpl.PostExecute(DataContext context, Character character, CharacterActionData actionData)
	{
		ApplyChanges(context, character, actionData.TargetChar);
	}

	private void ApplyChanges(DataContext context, Character selfChar, Character targetChar)
	{
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int currDate = DomainManager.World.GetCurrDate();
		Location location = selfChar.GetLocation();
		int targetCharId = targetChar.GetId();
		int selfCharId = selfChar.GetId();
		short selfAttainment = Math.Max((short)1, selfChar.GetLifeSkillAttainment(ActionLifeSkillType));
		short targetAttainment = Math.Max((short)1, targetChar.GetLifeSkillAttainment(ActionLifeSkillType));
		int selfHappinessChange = Math.Clamp(targetAttainment * 2 / selfAttainment - 1, -1, 5);
		int targetHappinessChange = Math.Clamp(selfAttainment * 2 / targetAttainment - 1, -1, 5);
		selfChar.ChangeHappiness(context, selfHappinessChange);
		targetChar.ChangeHappiness(context, targetHappinessChange);
		int selfFavorabilityChange = Math.Clamp(targetAttainment * 1200 / selfAttainment - 600, -600, 3000);
		int targetFavorabilityChange = Math.Clamp(selfAttainment * 1200 / targetAttainment - 600, -600, 3000);
		DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, selfChar, targetChar, selfFavorabilityChange);
		DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, targetChar, selfChar, targetFavorabilityChange);
		switch (ActionLifeSkillType)
		{
		case 0:
			lifeRecordCollection.AddEntertainWithMusic(selfCharId, currDate, targetCharId, location);
			break;
		case 1:
			lifeRecordCollection.AddEntertainWithChess(selfCharId, currDate, targetCharId, location);
			break;
		case 2:
			lifeRecordCollection.AddEntertainWithPoem(selfCharId, currDate, targetCharId, location);
			break;
		case 3:
			lifeRecordCollection.AddEntertainWithPainting(selfCharId, currDate, targetCharId, location);
			break;
		default:
			throw new Exception($"Invalid life skill type for entertainment {ActionLifeSkillType}");
		}
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 3;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = 1;
		byte* num = pData + 2;
		*num = (byte)ActionLifeSkillType;
		int totalSize = (int)(num + 1 - pData);
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
			ActionLifeSkillType = (sbyte)(*pCurrData);
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
