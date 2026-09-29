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

[AutoGenerateSerializableGameData]
public class IdentityActionCommonNoTarget : ICharacterActionImpl, ISerializableGameData
{
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
		lifeRecordCollection.AddIdentityActionCommonSelf(charId, location, actionTemplate);
	}

	private static bool CheckLifeRecords(PlanningActionItem config)
	{
		if (config.ExecuteSelfLifeRecord < 0 || config.ExecuteTargetLifeRecord >= 0)
		{
			return false;
		}
		LifeRecordItem selfLifeRecordCfg = LifeRecord.Instance[config.ExecuteSelfLifeRecord];
		if (selfLifeRecordCfg.CheckParameterCount(1))
		{
			return selfLifeRecordCfg.Parameters[0] == "Location";
		}
		return false;
	}

	public IdentityActionCommonNoTarget()
	{
	}

	public IdentityActionCommonNoTarget(IdentityActionCommonNoTarget other)
	{
	}

	public void Assign(IdentityActionCommonNoTarget other)
	{
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 0;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		int totalSize = (int)(pData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		int totalSize = (int)(pData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
