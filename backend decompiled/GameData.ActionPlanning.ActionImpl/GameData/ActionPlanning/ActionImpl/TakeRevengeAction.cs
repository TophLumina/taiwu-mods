using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.Item;
using GameData.Domains.LifeRecord;
using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.ActionPlanning.ActionImpl;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class TakeRevengeAction : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort Count = 0;
	}

	public bool CheckValid(Character selfChar, CharacterActionData actionData)
	{
		return DomainManager.Character.IsCharacterAlive(actionData.TargetCharId);
	}

	public void OnStart(DataContext context, Character selfChar, CharacterActionData actionData)
	{
		int selfCharId = selfChar.GetId();
		DomainManager.LifeRecord.GetLifeRecordCollection().AddDecideToRevenge(date: DomainManager.World.GetCurrDate(), location: selfChar.GetLocation(), selfCharId: selfCharId, charId: actionData.TargetCharId);
		if (DomainManager.Character.IsTaiwuPeople(selfCharId) || DomainManager.Character.IsTaiwuPeople(actionData.TargetCharId))
		{
			DomainManager.World.GetMonthlyNotificationCollection().AddGoToRevenge(selfCharId, actionData.TargetCharId);
		}
		DomainManager.Character.AddOngoingVengeance(context, selfCharId, actionData.TargetCharId);
	}

	public void OnInterrupt(DataContext context, Character selfChar, CharacterActionData actionData)
	{
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int currDate = DomainManager.World.GetCurrDate();
		int selfCharId = selfChar.GetId();
		lifeRecordCollection.AddFinishTakingRevenge(location: selfChar.GetLocation(), selfCharId: selfCharId, date: currDate, charId: actionData.TargetCharId);
		DomainManager.Character.FinishOngoingVengeance(context, selfCharId, actionData.TargetCharId);
	}

	public void OnCharacterDead(DataContext context, Character selfChar, CharacterActionData actionData)
	{
		DomainManager.Character.FinishOngoingVengeance(context, selfChar.GetId(), actionData.TargetCharId);
	}

	public bool OnExecutePhase(DataContext context, Character selfChar, CharacterActionData actionData)
	{
		Character targetChar = DomainManager.Character.GetElement_Objects(actionData.TargetCharId);
		if (targetChar.GetKidnapperId() >= 0)
		{
			return false;
		}
		switch (DomainManager.Character.SelectHarmfulActionType(context, selfChar, targetChar))
		{
		case 0:
			DomainManager.Character.HandleAttackAction(context, selfChar, targetChar, actionData.Template);
			break;
		case 1:
			DomainManager.Character.HandlePoisonAction(context, selfChar, targetChar, ItemKey.Invalid, actionData.Template);
			break;
		case 2:
			DomainManager.Character.HandlePlotHarmAction(context, selfChar, targetChar, ItemKey.Invalid, actionData.Template);
			break;
		default:
			return false;
		}
		if (DomainManager.Character.IsCharacterAlive(actionData.TargetCharId))
		{
			return targetChar.GetKidnapperId() == selfChar.GetId();
		}
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
