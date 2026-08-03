using Config;
using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.Character.Ai;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.Item;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.World.MonthlyEvent;
using GameData.Domains.World.Notification;
using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.ActionPlanning.ActionImpl;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class StudyDemandScamCombatSkillAction : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort BookTemplateId = 0;

		public const ushort InternalIndex = 1;

		public const ushort GeneratedPageTypes = 2;

		public const ushort Phase = 3;

		public const ushort Count = 4;

		public static readonly string[] FieldId2FieldName = new string[4] { "BookTemplateId", "InternalIndex", "GeneratedPageTypes", "Phase" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public short BookTemplateId;

	[SerializableGameDataField(FieldIndex = 1)]
	public byte InternalIndex;

	[SerializableGameDataField(FieldIndex = 2)]
	public byte GeneratedPageTypes;

	[SerializableGameDataField(FieldIndex = 3)]
	public sbyte Phase;

	public static bool MatchTargetCharacter(DataContext context, GameData.Domains.Character.Character character, GameData.Domains.Character.Character targetChar, ContextArgGroupHandle args)
	{
		return character.CanLearnCombatSkillFrom(targetChar, args.CombatSkillType);
	}

	bool ICharacterActionImpl.OfflineInitActionData(DataContext context, GameData.Domains.Character.Character character, ContextArgGroupHandle argGroup, CharacterActionData actionData)
	{
		GameData.Domains.Character.Character targetChar = actionData.TargetChar;
		sbyte mainAttributeType = AiHelper.DemandActionType.ToMainAttributeType(2, isSkill: true);
		if (mainAttributeType >= 0 && character.GetCurrMainAttribute(mainAttributeType) < GlobalConfig.Instance.HarmfulActionCost)
		{
			return false;
		}
		(short skillId, byte internalIndex, byte pageTypes) tuple = character.CalcCombatSkillToLearnFromCharacter(context, targetChar, argGroup.CombatSkillType);
		short skillTemplateId = tuple.skillId;
		byte currInternalIndex = tuple.internalIndex;
		byte pageTypes = tuple.pageTypes;
		short bookTemplateId = Config.CombatSkill.Instance[skillTemplateId].BookId;
		int value = ItemTemplateHelper.GetBaseValue(10, bookTemplateId);
		int alertFactor = targetChar.GetValueAlertFactor(value, 1);
		BookTemplateId = bookTemplateId;
		InternalIndex = currInternalIndex;
		GeneratedPageTypes = pageTypes;
		Phase = character.GetScamActionPhase(context.Random, targetChar, alertFactor);
		return true;
	}

	bool ICharacterActionImpl.CheckValid(GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
		return !character.GetLearnedCombatSkills().Contains(Config.SkillBook.Instance[BookTemplateId].CombatSkillTemplateId);
	}

	void ICharacterActionImpl.PostExecuteForTaiwuTarget(DataContext context, GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
		GameData.Domains.Character.Character targetChar = actionData.TargetChar;
		int selfCharId = character.GetId();
		int targetCharId = targetChar.GetId();
		Location location = targetChar.GetLocation();
		short combatSkillTemplateId = Config.SkillBook.Instance[BookTemplateId].CombatSkillTemplateId;
		MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
		MonthlyNotificationCollection monthlyNotificationCollection = DomainManager.World.GetMonthlyNotificationCollection();
		if (Phase <= 2)
		{
			monthlyNotificationCollection.AddCheatCombatSkillFailure(selfCharId, location, targetCharId, combatSkillTemplateId);
			ApplyChanges(context, character, targetChar);
		}
		else
		{
			monthlyEventCollection.AddScamCombatSkill(selfCharId, location, targetCharId, 10, BookTemplateId, CombatSkillStateHelper.GetPageId(InternalIndex) + 1, InternalIndex, GeneratedPageTypes);
			CharacterDomain.AddLockMovementCharSet(selfCharId);
		}
	}

	void ICharacterActionImpl.PostExecute(DataContext context, GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
		ApplyChanges(context, character, actionData.TargetChar);
	}

	private void ApplyChanges(DataContext context, GameData.Domains.Character.Character selfChar, GameData.Domains.Character.Character targetChar)
	{
		short combatSkillTemplateId = Config.SkillBook.Instance[BookTemplateId].CombatSkillTemplateId;
		byte pageId = CombatSkillStateHelper.GetPageId(InternalIndex);
		int selfCharId = selfChar.GetId();
		int targetCharId = targetChar.GetId();
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		if (selfCharId != taiwuCharId)
		{
			selfChar.ChangeCurrMainAttribute(context, 2, -GlobalConfig.Instance.HarmfulActionCost);
		}
		if (Phase >= 4)
		{
			int secretInfoOffset = DomainManager.Information.GetSecretInformationCollection().AddScamCombatSkill(selfCharId, targetCharId, combatSkillTemplateId);
			DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
		}
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int currDate = DomainManager.World.GetCurrDate();
		Location location = selfChar.GetLocation();
		switch (Phase)
		{
		case 0:
			lifeRecordCollection.AddStealCombatSkillFail1(selfCharId, currDate, targetCharId, location, 10, BookTemplateId, pageId + 1);
			break;
		case 1:
			lifeRecordCollection.AddStealCombatSkillFail2(selfCharId, currDate, targetCharId, location, 10, BookTemplateId, pageId + 1);
			break;
		case 2:
			lifeRecordCollection.AddStealCombatSkillFail3(selfCharId, currDate, targetCharId, location, 10, BookTemplateId, pageId + 1);
			break;
		case 3:
			lifeRecordCollection.AddStealCombatSkillFail4(selfCharId, currDate, targetCharId, location, 10, BookTemplateId, pageId + 1);
			break;
		case 4:
			if (selfCharId == taiwuCharId)
			{
				ItemKey itemKey2 = DomainManager.Item.CreateDemandedSkillBook(context, BookTemplateId, InternalIndex, GeneratedPageTypes);
				selfChar.AddInventoryItem(context, itemKey2, 1);
			}
			selfChar.LearnNewCombatSkill(context, combatSkillTemplateId, (ushort)(1 << (int)InternalIndex));
			lifeRecordCollection.AddScamCombatSkillSucceed(selfCharId, currDate, targetCharId, location, 10, BookTemplateId, pageId + 1);
			if (targetCharId != taiwuCharId)
			{
				AiHelper.NpcCombatResultType combatResultType = DomainManager.Character.SimulateCharacterCombat(context, targetChar, selfChar, CombatType.Beat);
				if ((uint)(combatResultType - 2) <= 1u)
				{
					DomainManager.Character.SimulateCharacterCombatResult(context, selfChar, targetChar, -40, -20, 0);
				}
				else
				{
					DomainManager.Character.SimulateCharacterCombatResult(context, targetChar, selfChar, -40, -20, 0);
				}
			}
			break;
		default:
			if (selfCharId == taiwuCharId)
			{
				ItemKey itemKey = DomainManager.Item.CreateDemandedSkillBook(context, BookTemplateId, InternalIndex, GeneratedPageTypes);
				selfChar.AddInventoryItem(context, itemKey, 1);
			}
			selfChar.LearnNewCombatSkill(context, combatSkillTemplateId, (ushort)(1 << (int)InternalIndex));
			lifeRecordCollection.AddScamCombatSkillSucceedAndEscaped(selfCharId, currDate, targetCharId, location, 10, BookTemplateId, pageId + 1);
			break;
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
		*(short*)pData = 4;
		byte* num = pData + 2;
		*(short*)num = BookTemplateId;
		byte* num2 = num + 2;
		*num2 = InternalIndex;
		byte* num3 = num2 + 1;
		*num3 = GeneratedPageTypes;
		byte* num4 = num3 + 1;
		*num4 = (byte)Phase;
		int totalSize = (int)(num4 + 1 - pData);
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
			BookTemplateId = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 1)
		{
			InternalIndex = *pCurrData;
			pCurrData++;
		}
		if (num > 2)
		{
			GeneratedPageTypes = *pCurrData;
			pCurrData++;
		}
		if (num > 3)
		{
			Phase = (sbyte)(*pCurrData);
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
