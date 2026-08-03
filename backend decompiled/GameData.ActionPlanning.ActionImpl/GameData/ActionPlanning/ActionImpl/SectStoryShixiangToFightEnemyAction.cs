using System.Collections.Generic;
using Config;
using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.Map;
using GameData.Domains.TaiwuEvent;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.ActionPlanning.ActionImpl;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class SectStoryShixiangToFightEnemyAction : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort Count = 0;
	}

	public void OnStart(DataContext context, GameData.Domains.Character.Character selfChar, CharacterActionData actionData)
	{
		int selfCharId = selfChar.GetId();
		int groupLeader = selfChar.GetLeaderId();
		if (groupLeader >= 0 && groupLeader != selfCharId)
		{
			DomainManager.Character.LeaveGroup(context, selfChar);
		}
	}

	public bool OnExecutePhase(DataContext context, GameData.Domains.Character.Character selfChar, CharacterActionData actionData)
	{
		int killedLimitInMonth = DomainManager.Story.GetShixiangKilledLimit();
		if (killedLimitInMonth <= 0)
		{
			return false;
		}
		MapBlockData block = DomainManager.Map.GetBlock(actionData.GetActualTargetLocation());
		HashSet<int> enemyCharacterSet = block.EnemyCharacterSet;
		if (enemyCharacterSet != null && enemyCharacterSet.Count > 0)
		{
			GameData.Domains.Character.Character enemyChar = null;
			foreach (int enemyId in block.EnemyCharacterSet)
			{
				if (DomainManager.Character.TryGetElement_Objects(enemyId, out var tempEnemyChar))
				{
					short templateId = tempEnemyChar.GetTemplateId();
					if ((templateId >= 681 && templateId <= 690) || 1 == 0)
					{
						enemyChar = tempEnemyChar;
						break;
					}
				}
			}
			if (enemyChar == null)
			{
				return false;
			}
			int fightScore = DomainManager.Character.GetSimulateCharacterCombatWinRate(context, selfChar, enemyChar);
			bool num = context.Random.CheckPercentProb(fightScore);
			DomainManager.Character.SimulateRandomEnemyAttackNpc(context, enemyChar, selfChar, 2, 2, CombatType.Die);
			if (num)
			{
				DomainManager.Character.RemoveNonIntelligentCharacter(context, enemyChar);
				killedLimitInMonth--;
				DomainManager.Story.SetShixiangKilledLimit(killedLimitInMonth, context);
				short templateId = enemyChar.GetTemplateId();
				if (templateId >= 686 && templateId <= 690)
				{
					EventArgBox sectArgBox = DomainManager.Extra.GetSectMainStoryEventArgBox(6);
					sectArgBox.Set(SectMainStoryEventArgKey.DefValue.ShixiangKillBarbarianMasterCount, sectArgBox.GetInt(SectMainStoryEventArgKey.DefValue.ShixiangKillBarbarianMasterCount) + 1);
					sectArgBox.Set(SectMainStoryEventArgKey.DefValue.ShixiangKillBarbarianMasterCount2, sectArgBox.GetInt(SectMainStoryEventArgKey.DefValue.ShixiangKillBarbarianMasterCount2) + 1);
					DomainManager.Extra.SaveSectMainStoryEventArgumentBox(context, 6);
				}
			}
		}
		else
		{
			DomainManager.Story.ShixiangQueryEnemyLocations(context, out var areaId, out var blockIds);
			if (blockIds.Count == 0)
			{
				return false;
			}
			actionData.TargetLocation = new Location(areaId, blockIds.GetRandom(context.Random));
		}
		return false;
	}

	public bool CheckValid(GameData.Domains.Character.Character selfChar, CharacterActionData actionData)
	{
		if (selfChar.GetOrganizationInfo().OrgTemplateId != 6)
		{
			return false;
		}
		return DomainManager.Extra.GetSectMainStoryEventArgBox(6).GetBool(SectMainStoryEventArgKey.DefValue.ShixiangToFightEnemy);
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
