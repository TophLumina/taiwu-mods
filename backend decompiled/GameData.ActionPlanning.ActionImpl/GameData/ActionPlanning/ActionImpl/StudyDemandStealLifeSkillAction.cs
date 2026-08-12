using Config;
using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.Character.Ai;
using GameData.Domains.Combat;
using GameData.Domains.Item;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.World.MonthlyEvent;
using GameData.Domains.World.Notification;
using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.ActionPlanning.ActionImpl;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class StudyDemandStealLifeSkillAction : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort BookTemplateId = 0;

		public const ushort PageId = 1;

		public const ushort Phase = 2;

		public const ushort Count = 3;

		public static readonly string[] FieldId2FieldName = new string[3] { "BookTemplateId", "PageId", "Phase" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public short BookTemplateId;

	[SerializableGameDataField(FieldIndex = 1)]
	public byte PageId;

	[SerializableGameDataField(FieldIndex = 2)]
	public sbyte Phase;

	public static bool MatchTargetCharacter(DataContext context, GameData.Domains.Character.Character character, GameData.Domains.Character.Character targetChar, ContextArgGroupHandle args)
	{
		return character.CanLearnLifeSkillFrom(targetChar, args.LifeSkillType);
	}

	bool ICharacterActionImpl.OfflineInitActionData(DataContext context, GameData.Domains.Character.Character character, ContextArgGroupHandle argGroup, CharacterActionData actionData)
	{
		GameData.Domains.Character.Character targetChar = actionData.TargetChar;
		sbyte lifeSkillType = argGroup.LifeSkillType;
		sbyte mainAttributeType = AiHelper.DemandActionType.ToMainAttributeType(1, isSkill: true);
		if (mainAttributeType >= 0 && character.GetCurrMainAttribute(mainAttributeType) < GlobalConfig.Instance.HarmfulActionCost)
		{
			return false;
		}
		(short skillId, byte pageId) tuple = character.CalcLifeSkillToLearnFromCharacter(context, targetChar, lifeSkillType);
		short lifeSkillTemplateId = tuple.skillId;
		byte pageId = tuple.pageId;
		short bookTemplateId = LifeSkill.Instance[lifeSkillTemplateId].SkillBookId;
		sbyte grade = LifeSkill.Instance[lifeSkillTemplateId].Grade;
		BookTemplateId = bookTemplateId;
		PageId = pageId;
		Phase = character.GetStealLifeSkillActionPhase(context.Random, targetChar, lifeSkillType, grade);
		return true;
	}

	bool ICharacterActionImpl.CheckValid(GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
		return character.FindLearnedLifeSkillIndex(Config.SkillBook.Instance[BookTemplateId].LifeSkillTemplateId) < 0;
	}

	void ICharacterActionImpl.PostExecuteForTaiwuTarget(DataContext context, GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
		GameData.Domains.Character.Character targetChar = actionData.TargetChar;
		int selfCharId = character.GetId();
		int targetCharId = targetChar.GetId();
		Location location = character.GetLocation();
		SkillBookItem bookCfg = Config.SkillBook.Instance[BookTemplateId];
		MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
		MonthlyNotificationCollection monthlyNotificationCollection = DomainManager.World.GetMonthlyNotificationCollection();
		if (Phase <= 3)
		{
			monthlyNotificationCollection.AddStealLifeSkillFailure(selfCharId, location, targetCharId, bookCfg.LifeSkillTemplateId);
			ApplyChanges(context, character, targetChar);
			return;
		}
		monthlyNotificationCollection.AddStealLifeSkillSuccess(selfCharId, location, targetCharId, bookCfg.LifeSkillTemplateId);
		if (Phase == 4)
		{
			monthlyEventCollection.AddStealLifeSkillButBeCaught(selfCharId, location, targetCharId, 10, BookTemplateId, PageId + 1);
		}
		else
		{
			monthlyEventCollection.AddStealLifeSkillAndEscape(selfCharId, location, targetCharId, 10, BookTemplateId, PageId + 1);
		}
		CharacterDomain.AddLockMovementCharSet(selfCharId);
	}

	void ICharacterActionImpl.PostExecute(DataContext context, GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
		ApplyChanges(context, character, actionData.TargetChar);
	}

	private void ApplyChanges(DataContext context, GameData.Domains.Character.Character selfChar, GameData.Domains.Character.Character targetChar)
	{
		short lifeSkillTemplateId = Config.SkillBook.Instance[BookTemplateId].LifeSkillTemplateId;
		int selfCharId = selfChar.GetId();
		int targetCharId = targetChar.GetId();
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int currDate = DomainManager.World.GetCurrDate();
		Location location = selfChar.GetLocation();
		if (selfCharId != taiwuCharId)
		{
			selfChar.ChangeCurrMainAttribute(context, 5, -GlobalConfig.Instance.HarmfulActionCost);
		}
		if (Phase >= 4)
		{
			int secretInfoOffset = DomainManager.Information.GetSecretInformationCollection().AddStealLifeSkill(selfCharId, targetCharId, lifeSkillTemplateId);
			DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
		}
		switch (Phase)
		{
		case 0:
			lifeRecordCollection.AddStealLifeSkillFail1(selfCharId, currDate, targetCharId, location, 10, BookTemplateId, PageId + 1);
			break;
		case 1:
			lifeRecordCollection.AddStealLifeSkillFail2(selfCharId, currDate, targetCharId, location, 10, BookTemplateId, PageId + 1);
			break;
		case 2:
			lifeRecordCollection.AddStealLifeSkillFail3(selfCharId, currDate, targetCharId, location, 10, BookTemplateId, PageId + 1);
			break;
		case 3:
			lifeRecordCollection.AddStealLifeSkillFail4(selfCharId, currDate, targetCharId, location, 10, BookTemplateId, PageId + 1);
			break;
		case 4:
			if (selfCharId == taiwuCharId)
			{
				ItemKey itemKey2 = DomainManager.Item.CreateDemandedSkillBook(context, BookTemplateId, PageId, 0);
				selfChar.AddInventoryItem(context, itemKey2, 1);
			}
			selfChar.LearnNewLifeSkill(context, lifeSkillTemplateId, (byte)(1 << (int)PageId));
			lifeRecordCollection.AddStealLifeSkillSucceed(selfCharId, currDate, targetCharId, location, 10, BookTemplateId, PageId + 1);
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
				ItemKey itemKey = DomainManager.Item.CreateDemandedSkillBook(context, BookTemplateId, PageId, 0);
				selfChar.AddInventoryItem(context, itemKey, 1);
			}
			selfChar.LearnNewLifeSkill(context, lifeSkillTemplateId, (byte)(1 << (int)PageId));
			lifeRecordCollection.AddStealLifeSkillSucceedAndEscaped(selfCharId, currDate, targetCharId, location, 10, BookTemplateId, PageId + 1);
			break;
		}
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 6;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = 3;
		byte* num = pData + 2;
		*(short*)num = BookTemplateId;
		byte* num2 = num + 2;
		*num2 = PageId;
		byte* num3 = num2 + 1;
		*num3 = (byte)Phase;
		int totalSize = (int)(num3 + 1 - pData);
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
			PageId = *pCurrData;
			pCurrData++;
		}
		if (num > 2)
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
