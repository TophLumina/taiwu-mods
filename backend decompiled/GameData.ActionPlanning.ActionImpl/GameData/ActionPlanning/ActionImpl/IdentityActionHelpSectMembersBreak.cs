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
public class IdentityActionHelpSectMembersBreak : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort Count = 0;
	}

	public bool OfflineInitActionData(DataContext context, GameData.Domains.Character.Character character, ContextArgGroupHandle argGroup, CharacterActionData actionData)
	{
		return true;
	}

	public bool CheckValid(GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
		return true;
	}

	public void PostExecute(DataContext context, GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
		Location location = character.GetLocation();
		PlanningActionItem actionTemplate = actionData.Template;
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		lifeRecordCollection.AddIdentityActionCommonSelf(character.GetId(), location, actionTemplate);
		int[] targetCharIds = actionData.TargetCharIds;
		foreach (int targetCharId in targetCharIds)
		{
			if (DomainManager.Character.TryGetElement_Objects(targetCharId, out var targetChar))
			{
				short combatSkillTemplateId = Equipping.SelectSectCombatSkillToBreakOut(character);
				CombatSkillKey skillKey = new CombatSkillKey(targetChar.GetId(), combatSkillTemplateId);
				GameData.Domains.CombatSkill.CombatSkill element_CombatSkills = DomainManager.CombatSkill.GetElement_CombatSkills(skillKey);
				ushort readingState = element_CombatSkills.GetReadingState();
				ushort activationState = CombatSkillStateHelper.GenerateRandomActivatedOutlinePage(activationState: CombatSkillStateHelper.GenerateRandomActivatedNormalPages(context.Random, readingState, 0), random: context.Random, readingState: readingState, behaviorType: targetChar.GetBehaviorType());
				sbyte availableStepsCount = targetChar.GetSkillBreakoutAvailableStepsCount(combatSkillTemplateId);
				element_CombatSkills.SetActivationState(activationState, context);
				element_CombatSkills.SetBreakoutStepsCount(availableStepsCount, context);
				lifeRecordCollection.AddIdentityActionHelpSectMembersBreakSkillsTarget(targetChar.GetId(), character.GetId(), location, combatSkillTemplateId, actionTemplate);
			}
		}
	}

	private static bool CheckLifeRecords(PlanningActionItem config)
	{
		if (config.ExecuteSelfLifeRecord < 0 || config.ExecuteTargetLifeRecord < 0)
		{
			return false;
		}
		LifeRecordItem selfLifeRecordCfg = LifeRecord.Instance[config.ExecuteSelfLifeRecord];
		LifeRecordItem targetLifeRecordCfg = LifeRecord.Instance[config.ExecuteTargetLifeRecord];
		if (selfLifeRecordCfg.CheckParameterCount(1) && selfLifeRecordCfg.Parameters[0] == "Location" && targetLifeRecordCfg.CheckParameterCount(3) && targetLifeRecordCfg.Parameters[0] == "Character" && targetLifeRecordCfg.Parameters[1] == "Location")
		{
			return targetLifeRecordCfg.Parameters[2] == "CombatSkill";
		}
		return false;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 2;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = 0;
		int totalSize = (int)(pData + 2 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		_ = *(ushort*)pData;
		int totalSize = (int)(pData + 2 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
