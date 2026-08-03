using System.Collections.Generic;
using Config;
using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.ActionPlanning.ActionImpl;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class IdentityActionCommonSingleTarget : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort Count = 0;
	}

	bool ICharacterActionImpl.OfflineInitActionData(DataContext context, GameData.Domains.Character.Character character, ContextArgGroupHandle argGroup, CharacterActionData actionData)
	{
		return true;
	}

	bool ICharacterActionImpl.CheckValid(GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
		return true;
	}

	void ICharacterActionImpl.PostExecute(DataContext context, GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int charId = character.GetId();
		Location location = character.GetLocation();
		PlanningActionItem actionTemplate = actionData.Template;
		lifeRecordCollection.AddIdentityActionCommonSelf(charId, actionData.TargetCharId, location, actionTemplate);
		lifeRecordCollection.AddIdentityActionCommonTarget(actionData.TargetCharId, charId, location, actionTemplate);
		if (character.IsInTaiwuGroup() || actionData.TargetIsTaiwuGroupMember)
		{
			DomainManager.World.GetMonthlyNotificationCollection().AddIdentityActionCommonSingleTarget(charId, actionData.TargetCharId, location, actionTemplate);
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
		if (selfLifeRecordCfg.CheckParameterCount(2) && selfLifeRecordCfg.Parameters[0] == "Character" && selfLifeRecordCfg.Parameters[1] == "Location")
		{
			if (!targetLifeRecordCfg.IsSourceRecord)
			{
				List<short> relatedIds = targetLifeRecordCfg.RelatedIds;
				if (relatedIds != null && relatedIds.Count == 1 && targetLifeRecordCfg.RelatedIds[0] == selfLifeRecordCfg.TemplateId)
				{
					return true;
				}
			}
			if (targetLifeRecordCfg.CheckParameterCount(2) && targetLifeRecordCfg.Parameters[0] == "Character")
			{
				return targetLifeRecordCfg.Parameters[1] == "Location";
			}
			return false;
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
