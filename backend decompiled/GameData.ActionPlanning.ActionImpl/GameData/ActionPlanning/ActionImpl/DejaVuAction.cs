using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.ActionPlanning.ActionImpl;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class DejaVuAction : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort Count = 0;
	}

	public int PhaseCount => 1;

	public bool CheckValid(Character selfChar, CharacterActionData actionData)
	{
		if (DomainManager.Extra.GetDejaVuEventCharacters().Contains(selfChar.GetId()))
		{
			return false;
		}
		if (actionData.TargetCharId != DomainManager.Taiwu.GetTaiwuCharId())
		{
			return false;
		}
		if (!DomainManager.Character.TryGetElement_Objects(actionData.TargetCharId, out var target))
		{
			return false;
		}
		return selfChar.GetLocation().AreaId == target.GetLocation().AreaId;
	}

	public void OnStart(DataContext context, Character selfChar, CharacterActionData actionData)
	{
		if (!selfChar.IsInTaiwuGroup() && DomainManager.Character.TryGetElement_Objects(actionData.TargetCharId, out var target))
		{
			if (selfChar.GetLeaderId() != selfChar.GetId())
			{
				DomainManager.Character.LeaveGroup(context, selfChar);
			}
			DomainManager.Character.GroupMove(context, selfChar, target.GetLocation());
		}
	}

	public bool OnExecutePhase(DataContext context, Character selfChar, CharacterActionData actionData)
	{
		DomainManager.World.GetMonthlyEventCollection().AddCrossArchiveReunionWithAcquaintance(selfChar.GetId(), selfChar.GetLocation());
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
