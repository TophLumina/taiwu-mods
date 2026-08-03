using Config;
using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.Character.Ai;
using GameData.Domains.CombatSkill;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.ActionPlanning.ActionImpl;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class IdentityActionBreakOutSectSkill : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort CombatSkillTemplateId = 0;

		public const ushort Count = 1;

		public static readonly string[] FieldId2FieldName = new string[1] { "CombatSkillTemplateId" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	private short _combatSkillTemplateId;

	public bool OfflineInitActionData(DataContext context, GameData.Domains.Character.Character character, ContextArgGroupHandle argGroup, CharacterActionData actionData)
	{
		_combatSkillTemplateId = Equipping.SelectSectCombatSkillToBreakOut(character);
		return _combatSkillTemplateId >= 0;
	}

	public bool CheckValid(GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
		CombatSkillKey skillKey = new CombatSkillKey(character.GetId(), _combatSkillTemplateId);
		if (DomainManager.CombatSkill.TryGetElement_CombatSkills(skillKey, out var combatSkill) && !CombatSkillStateHelper.IsBrokenOut(combatSkill.GetActivationState()))
		{
			return combatSkill.CanBreakout();
		}
		return false;
	}

	public void PostExecute(DataContext context, GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
		CombatSkillKey skillKey = new CombatSkillKey(character.GetId(), _combatSkillTemplateId);
		GameData.Domains.CombatSkill.CombatSkill element_CombatSkills = DomainManager.CombatSkill.GetElement_CombatSkills(skillKey);
		ushort readingState = element_CombatSkills.GetReadingState();
		ushort activationState = CombatSkillStateHelper.GenerateRandomActivatedOutlinePage(activationState: CombatSkillStateHelper.GenerateRandomActivatedNormalPages(context.Random, readingState, 0), random: context.Random, readingState: readingState, behaviorType: character.GetBehaviorType());
		sbyte availableStepsCount = character.GetSkillBreakoutAvailableStepsCount(_combatSkillTemplateId);
		element_CombatSkills.SetActivationState(activationState, context);
		element_CombatSkills.SetBreakoutStepsCount(availableStepsCount, context);
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int charId = character.GetId();
		Location location = character.GetLocation();
		lifeRecordCollection.AddIdentityActionBreakOutSectSkill(charId, location, _combatSkillTemplateId, actionData.Template);
	}

	private static bool CheckLifeRecords(PlanningActionItem config)
	{
		if (config.ExecuteSelfLifeRecord < 0)
		{
			return false;
		}
		LifeRecordItem lifeRecordCfg = LifeRecord.Instance[config.ExecuteSelfLifeRecord];
		if (lifeRecordCfg.CheckParameterCount(2) && lifeRecordCfg.Parameters[0] == "Location")
		{
			return lifeRecordCfg.Parameters[1] == "CombatSkill";
		}
		return false;
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
		*(short*)pData = 1;
		byte* num = pData + 2;
		*(short*)num = _combatSkillTemplateId;
		int totalSize = (int)(num + 2 - pData);
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
			_combatSkillTemplateId = *(short*)pCurrData;
			pCurrData += 2;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
