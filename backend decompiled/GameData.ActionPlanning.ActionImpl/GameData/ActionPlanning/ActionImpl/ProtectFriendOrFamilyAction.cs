using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.Character.Relation;
using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.ActionPlanning.ActionImpl;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class ProtectFriendOrFamilyAction : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort Count = 0;
	}

	public bool CheckValid(Character selfChar, CharacterActionData actionData)
	{
		if (!DomainManager.Character.IsCharacterAlive(actionData.TargetCharId))
		{
			return false;
		}
		return FavorabilityType.GetFavorabilityType(DomainManager.Character.GetFavorability(selfChar.GetId(), actionData.TargetCharId)) >= 2;
	}

	public void OnStart(DataContext context, Character selfChar, CharacterActionData actionData)
	{
		if (!selfChar.IsInTaiwuGroup())
		{
			int selfCharId = selfChar.GetId();
			int groupLeader = selfChar.GetLeaderId();
			if (groupLeader >= 0 && groupLeader != selfCharId)
			{
				DomainManager.Character.LeaveGroup(context, selfChar);
			}
			DomainManager.LifeRecord.GetLifeRecordCollection().AddDecideToProtect(date: DomainManager.World.GetCurrDate(), location: selfChar.GetLocation(), selfCharId: selfCharId, charId: actionData.TargetCharId);
			if (DomainManager.Character.IsTaiwuPeople(selfCharId) || DomainManager.Character.IsTaiwuPeople(actionData.TargetCharId))
			{
				DomainManager.World.GetMonthlyNotificationCollection().AddGoToProtect(selfCharId, actionData.TargetCharId);
			}
		}
	}

	public void OnInterrupt(DataContext context, Character selfChar, CharacterActionData actionData)
	{
		int selfCharId = selfChar.GetId();
		DomainManager.LifeRecord.GetLifeRecordCollection().AddFinishProtection(date: DomainManager.World.GetCurrDate(), location: selfChar.GetLocation(), selfCharId: selfCharId, charId: actionData.TargetCharId);
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
