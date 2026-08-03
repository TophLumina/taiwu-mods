using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.ActionPlanning.ActionImpl;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class SectStoryBaihuaToCureManic : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort Count = 0;
	}

	public bool CheckValid(Character character, CharacterActionData actionData)
	{
		return true;
	}

	public void OnStart(DataContext context, Character selfChar, CharacterActionData actionData)
	{
		DomainManager.Story.BaihuaAddCharIdToCureSpecialDebuffIntList(context, actionData.TargetCharId);
	}

	public void OnInterrupt(DataContext context, Character selfChar, CharacterActionData actionData)
	{
		DomainManager.Story.BaihuaRemoveCharIdToCureSpecialDebuffIntList(context, actionData.TargetCharId);
	}

	public bool OnExecutePhase(DataContext context, Character selfChar, CharacterActionData actionData)
	{
		if (!DomainManager.Character.TryGetElement_Objects(actionData.TargetCharId, out var targetChar))
		{
			return !TryChangeTarget(context, actionData);
		}
		if (!targetChar.IsInteractableAsIntelligentCharacter())
		{
			return !TryChangeTarget(context, actionData);
		}
		if (!targetChar.RemoveFeatureGroup(context, 712))
		{
			return !TryChangeTarget(context, actionData);
		}
		int currDate = DomainManager.World.GetCurrDate();
		DomainManager.LifeRecord.GetLifeRecordCollection().AddSectMainStoryBaihuaManiaCure(selfChar.GetId(), currDate, targetChar.GetId(), selfChar.GetLocation());
		return !TryChangeTarget(context, actionData);
	}

	private bool TryChangeTarget(DataContext context, CharacterActionData actionData)
	{
		if (!DomainManager.Character.BaihuaManicCharIds.TryTake(out var newTargetCharId))
		{
			return false;
		}
		DomainManager.Story.BaihuaRemoveCharIdToCureSpecialDebuffIntList(context, actionData.TargetCharId);
		actionData.TargetCharId = newTargetCharId;
		DomainManager.Story.BaihuaAddCharIdToCureSpecialDebuffIntList(context, actionData.TargetCharId);
		return true;
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
