using System.Collections.Generic;
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
public class IdentityActionFavorBetweenSectMembers : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort Count = 0;
	}

	public bool IgnoreConfigChanges => true;

	public bool CheckValid(GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
		return true;
	}

	public void PostExecute(DataContext context, GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int charId = character.GetId();
		Location location = character.GetLocation();
		PlanningActionItem actionTemplate = actionData.Template;
		lifeRecordCollection.AddIdentityActionCommonSelf(charId, location, actionTemplate);
		List<GameData.Domains.Character.Character> targetList = ObjectPool<List<GameData.Domains.Character.Character>>.Instance.Get();
		targetList.Clear();
		int[] targetCharIds = actionData.TargetCharIds;
		foreach (int targetCharId in targetCharIds)
		{
			if (DomainManager.Character.TryGetElement_Objects(targetCharId, out var targetChar))
			{
				targetList.Add(targetChar);
			}
		}
		foreach (GameData.Domains.Character.Character charA in targetList)
		{
			foreach (GameData.Domains.Character.Character charB in targetList)
			{
				if (charA != charB)
				{
					DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, charA, charB, actionTemplate.FavorabilityChange);
				}
			}
			lifeRecordCollection.AddIdentityActionCommonTarget(charA.GetId(), charId, location, actionTemplate);
		}
		ObjectPool<List<GameData.Domains.Character.Character>>.Instance.Return(targetList);
	}

	private static bool CheckLifeRecords(PlanningActionItem config)
	{
		if (config.ExecuteSelfLifeRecord < 0 || config.ExecuteTargetLifeRecord < 0)
		{
			return false;
		}
		LifeRecordItem selfLifeRecordCfg = LifeRecord.Instance[config.ExecuteSelfLifeRecord];
		LifeRecordItem targetLifeRecordCfg = LifeRecord.Instance[config.ExecuteTargetLifeRecord];
		if (selfLifeRecordCfg.CheckParameterCount(1) && selfLifeRecordCfg.Parameters[0] == "Location" && targetLifeRecordCfg.CheckParameterCount(2) && targetLifeRecordCfg.Parameters[0] == "Character")
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
