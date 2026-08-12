using Config;
using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.ActionPlanning.ActionImpl;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class IdentityActionHeal : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort Count = 0;
	}

	private const int HerbCost = 960;

	public bool CheckValid(GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
		return character.GetResource(5) >= 960;
	}

	void ICharacterActionImpl.PostExecute(DataContext context, GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
		int selfCharId = character.GetId();
		Location location = character.GetLocation();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		PlanningActionItem actionTemplate = actionData.Template;
		lifeRecordCollection.AddIdentityActionHealDoctor(selfCharId, location, 960, 5, actionTemplate);
		character.ChangeResource(context, 5, -960);
		SpanList<EHealActionType> healTypes = stackalloc EHealActionType[GameData.Domains.Character.Character.AllHealActions.Count];
		foreach (GameData.Domains.Character.Character targetChar in actionData.GetTargetCharacters())
		{
			healTypes.Clear();
			foreach (EHealActionType healType in GameData.Domains.Character.Character.AllHealActions)
			{
				if (targetChar.NeedHealAction(healType))
				{
					healTypes.Add(healType);
				}
			}
			if (healTypes.Count > 0)
			{
				EHealActionType selectedHealType = healTypes.GetRandom(context.Random);
				character.DoHealAction(context, selectedHealType, targetChar);
				int targetCharId = targetChar.GetId();
				lifeRecordCollection.AddIdentityActionHealPatient(targetCharId, location, selfCharId, actionTemplate);
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
		if (selfLifeRecordCfg.CheckParameterCount(3) && selfLifeRecordCfg.Parameters[0] == "Location" && selfLifeRecordCfg.Parameters[1] == "Integer" && selfLifeRecordCfg.Parameters[2] == "Resource" && targetLifeRecordCfg.CheckParameterCount(2) && targetLifeRecordCfg.Parameters[0] == "Character")
		{
			return targetLifeRecordCfg.Parameters[1] == "Location";
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
