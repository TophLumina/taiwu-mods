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
		public const ushort GraveId = 0;

		public const ushort Count = 1;

		public static readonly string[] FieldId2FieldName = new string[1] { "GraveId" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public int GraveId = -1;

	public int PhaseCount => 1;

	public bool OfflineInitActionData(DataContext context, Character character, ContextArgGroupHandle argGroup, CharacterActionData actionData)
	{
		GraveId = argGroup.GraveId;
		if (!DomainManager.Character.TryGetElement_Graves(GraveId, out var grave))
		{
			return false;
		}
		actionData.TargetLocation = grave.GetLocation();
		return true;
	}

	public bool CheckValid(Character selfChar, CharacterActionData actionData)
	{
		if (DomainManager.Character.TryGetElement_Graves(GraveId, out var grave))
		{
			return grave.GetLocation() == actionData.TargetLocation;
		}
		return false;
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
			DomainManager.LifeRecord.GetLifeRecordCollection().AddDecideToMourn(date: DomainManager.World.GetCurrDate(), location: selfChar.GetLocation(), selfCharId: selfCharId, charId: GraveId);
		}
	}

	public void OnInterrupt(DataContext context, Character selfChar, CharacterActionData actionData)
	{
		int selfCharId = selfChar.GetId();
		DomainManager.LifeRecord.GetLifeRecordCollection().AddFinishMourning(date: DomainManager.World.GetCurrDate(), location: selfChar.GetLocation(), selfCharId: selfCharId, charId: GraveId);
	}

	public void PreExecute(DataContext context, Character selfChar, CharacterActionData actionData)
	{
		int selfCharId = selfChar.GetId();
		if (DomainManager.Character.TryGetElement_Graves(GraveId, out var grave))
		{
			DomainManager.LifeRecord.GetLifeRecordCollection().AddMaintainGrave(date: DomainManager.World.GetCurrDate(), location: grave.GetLocation(), selfCharId: selfCharId, charId: GraveId);
			sbyte graveLevel = grave.GetLevel();
			short maxDurability = GlobalConfig.Instance.GraveDurabilities[graveLevel];
			grave.SetDurability(maxDurability, context);
			int secretInfoOffset = DomainManager.Information.GetSecretInformationCollection().AddMourn(selfCharId, GraveId);
			DomainManager.Information.AddSecretInformation(context, secretInfoOffset);
		}
	}

	public bool OnExecutePhase(DataContext context, Character selfChar, CharacterActionData actionData)
	{
		int selfCharId = selfChar.GetId();
		if (!DomainManager.Character.TryGetElement_Graves(GraveId, out var grave))
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
				DomainManager.LifeRecord.GetLifeRecordCollection().AddUpgradeGrave(date: DomainManager.World.GetCurrDate(), location: grave.GetLocation(), selfCharId: selfCharId, charId: GraveId);
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
		int totalSize = 6;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = 1;
		byte* num = pData + 2;
		*(int*)num = GraveId;
		int totalSize = (int)(num + 4 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			GraveId = *(int*)pCurrData;
			pCurrData += 4;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
