using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.ActionPlanning.ActionImpl;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class MournAction : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort Count = 0;
	}

	public int PhaseCount => 1;

	public bool CheckValid(Character selfChar, CharacterActionData actionData)
	{
		Grave element;
		return DomainManager.Character.TryGetElement_Graves(actionData.TargetCharId, out element);
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
			DomainManager.LifeRecord.GetLifeRecordCollection().AddDecideToMourn(date: DomainManager.World.GetCurrDate(), location: selfChar.GetLocation(), selfCharId: selfCharId, charId: actionData.TargetCharId);
		}
	}

	public void OnInterrupt(DataContext context, Character selfChar, CharacterActionData actionData)
	{
		int selfCharId = selfChar.GetId();
		DomainManager.LifeRecord.GetLifeRecordCollection().AddFinishMourning(date: DomainManager.World.GetCurrDate(), location: selfChar.GetLocation(), selfCharId: selfCharId, charId: actionData.TargetCharId);
	}

	public void PreExecute(DataContext context, Character selfChar, CharacterActionData actionData)
	{
		int selfCharId = selfChar.GetId();
		if (DomainManager.Character.TryGetElement_Graves(actionData.TargetCharId, out var grave))
		{
			DomainManager.LifeRecord.GetLifeRecordCollection().AddMaintainGrave(date: DomainManager.World.GetCurrDate(), location: grave.GetLocation(), selfCharId: selfCharId, charId: actionData.TargetCharId);
			sbyte graveLevel = grave.GetLevel();
			short maxDurability = GlobalConfig.Instance.GraveDurabilities[graveLevel];
			grave.SetDurability(maxDurability, context);
			int secretInfoOffset = DomainManager.Information.GetSecretInformationCollection().AddMourn(selfCharId, actionData.TargetCharId);
			DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
		}
	}

	public bool OnExecutePhase(DataContext context, Character selfChar, CharacterActionData actionData)
	{
		int selfCharId = selfChar.GetId();
		if (!DomainManager.Character.TryGetElement_Graves(actionData.TargetCharId, out var grave))
		{
			return true;
		}
		sbyte graveLevel = grave.GetLevel();
		if (graveLevel < GlobalConfig.Instance.GraveLevelMoneyCosts.Length - 1)
		{
			short moneyRequired = GlobalConfig.Instance.GraveLevelMoneyCosts[graveLevel + 1];
			if (selfChar.GetResource(6) >= moneyRequired)
			{
				graveLevel++;
				grave.SetLevel(graveLevel, context);
				selfChar.ChangeResource(context, 6, -moneyRequired);
				DomainManager.LifeRecord.GetLifeRecordCollection().AddUpgradeGrave(date: DomainManager.World.GetCurrDate(), location: grave.GetLocation(), selfCharId: selfCharId, charId: actionData.TargetCharId);
			}
		}
		short maxDurability = GlobalConfig.Instance.GraveDurabilities[graveLevel];
		grave.SetDurability(maxDurability, context);
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
