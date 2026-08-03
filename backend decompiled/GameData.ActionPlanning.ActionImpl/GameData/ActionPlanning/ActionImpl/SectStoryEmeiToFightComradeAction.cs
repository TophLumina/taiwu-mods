using Config;
using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.ActionPlanning.ActionImpl;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class SectStoryEmeiToFightComradeAction : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort Count = 0;
	}

	private bool CheckAndUpdateTarget(DataContext context, GameData.Domains.Character.Character selfChar, CharacterActionData actionData, out GameData.Domains.Character.Character target)
	{
		if (!DomainManager.Character.TryGetElement_Objects(actionData.TargetCharId, out target))
		{
			DomainManager.Story.GetEmeiPotentialVictims(selfChar, out var charIds);
			if (charIds.Count != 0)
			{
				actionData.TargetCharId = charIds.GetRandom(context.Random);
			}
			return false;
		}
		return true;
	}

	public void OnStart(DataContext context, GameData.Domains.Character.Character selfChar, CharacterActionData actionData)
	{
		int selfCharId = selfChar.GetId();
		int groupLeader = selfChar.GetLeaderId();
		if (groupLeader >= 0 && groupLeader != selfCharId)
		{
			DomainManager.Character.LeaveGroup(context, selfChar);
		}
		DomainManager.Extra.SectEmeiAddInsaneCharacterId(selfChar.GetId());
	}

	public void OnInterrupt(DataContext context, GameData.Domains.Character.Character selfChar, CharacterActionData actionData)
	{
		DomainManager.Extra.SectEmeiRemoveInsaneCharacterId(selfChar.GetId());
	}

	public bool OnExecutePhase(DataContext context, GameData.Domains.Character.Character selfChar, CharacterActionData actionData)
	{
		if (!CheckAndUpdateTarget(context, selfChar, actionData, out var target))
		{
			return false;
		}
		DomainManager.Character.SimulateCharacterCombat(context, selfChar, target, CombatType.Die);
		DomainManager.Extra.SectEmeiRemoveInsaneCharacterId(selfChar.GetId());
		DomainManager.World.GetMonthlyNotificationCollection().AddSectMainStoryEmeiInfighting(selfChar.GetId(), selfChar.GetLocation());
		return true;
	}

	public bool CheckValid(GameData.Domains.Character.Character selfChar, CharacterActionData actionData)
	{
		if (!DomainManager.Character.TryGetElement_Objects(actionData.TargetCharId, out var target))
		{
			return false;
		}
		OrganizationInfo selfOrgInfo = selfChar.GetOrganizationInfo();
		OrganizationInfo targetOrgInfo = target.GetOrganizationInfo();
		if (selfOrgInfo.OrgTemplateId != 2)
		{
			return false;
		}
		if (targetOrgInfo.OrgTemplateId != 2)
		{
			return false;
		}
		if (selfChar.GetLocation().AreaId != target.GetLocation().AreaId)
		{
			return false;
		}
		if (selfChar.GetLocation().AreaId != DomainManager.Organization.GetSettlementByOrgTemplateId(2).GetLocation().AreaId)
		{
			return false;
		}
		if (target.GetAgeGroup() != 2)
		{
			return false;
		}
		if (targetOrgInfo.Grade > selfOrgInfo.Grade)
		{
			return false;
		}
		return DomainManager.Extra.GetSectMainStoryEventArgBox(2).Contains<int>(SectMainStoryEventArgKey.DefValue.EmeiKillEachOtherStage);
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
