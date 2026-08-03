using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.Map;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.ActionPlanning.ActionImpl;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class HuntTaiwuAction : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort Count = 0;
	}

	public int PhaseCount => 1;

	public bool CheckValid(Character selfChar, CharacterActionData actionData)
	{
		if (!DomainManager.World.GetWorldFunctionsStatus(4))
		{
			return false;
		}
		if (!DomainManager.Character.IsCharacterAlive(selfChar.GetId()))
		{
			return false;
		}
		if (!DomainManager.Character.IsCharacterAlive(actionData.TargetCharId))
		{
			return false;
		}
		return true;
	}

	public void OnStart(DataContext context, Character selfChar, CharacterActionData actionData)
	{
		if (!selfChar.IsInTaiwuGroup())
		{
			AdaptableLog.Info($"{selfChar} start huntTaiwuAction,target is {DomainManager.Character.GetElement_Objects(actionData.TargetCharId)}.");
			int selfCharId = selfChar.GetId();
			int targetCharId = actionData.TargetCharId;
			int currDate = DomainManager.World.GetCurrDate();
			DomainManager.LifeRecord.GetLifeRecordCollection().AddJieQingPunishmentAssassinSetOut(selfCharId, currDate, targetCharId);
		}
	}

	public void OnInterrupt(DataContext context, Character selfChar, CharacterActionData actionData)
	{
		AdaptableLog.Info(DomainManager.Character.TryGetElement_Objects(actionData.TargetCharId, out var targetChar) ? $"{selfChar} end huntTaiwuAction {targetChar}." : $"{selfChar} end huntTaiwuAction {actionData.TargetCharId}.");
		int selfCharId = selfChar.GetId();
		int targetCharId = actionData.TargetCharId;
		int currDate = DomainManager.World.GetCurrDate();
		DomainManager.LifeRecord.GetLifeRecordCollection().AddJieQingPunishmentAssassinGiveUp(selfCharId, currDate, targetCharId);
	}

	public bool OnExecutePhase(DataContext context, Character selfChar, CharacterActionData actionData)
	{
		if (DomainManager.World.ClearMonthlyEventCollectionNotEndGame())
		{
			OnInterrupt(context, selfChar, actionData);
			return true;
		}
		Location taiwuLocation = DomainManager.Taiwu.GetTaiwu().GetLocation();
		Location selfLocation = selfChar.GetLocation();
		if (taiwuLocation.Equals(selfLocation))
		{
			DomainManager.Taiwu.SetJieqingPunishmentAssassinAlreadyAdd(value: true);
			DomainManager.World.GetMonthlyEventCollection().AddJieQingPunishmentAssassin(DomainManager.Taiwu.GetTaiwuCharId(), selfLocation, selfChar.GetId());
			return true;
		}
		AdaptableLog.Info($"{selfChar} cannot hunt taiwu, because taiwu is not in the same location.selfLocation is {selfLocation}, taiwuLocation is {taiwuLocation}.");
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
