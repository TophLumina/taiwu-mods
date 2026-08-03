using GameData.ActionPlanning.ActionImpl.Helper;
using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.Character.Ai;
using GameData.Domains.Combat;
using GameData.Domains.Item;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.ActionPlanning.ActionImpl;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class IdentityActionJudgeRandomDuel : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort RewardItemKey = 0;

		public const ushort Count = 1;

		public static readonly string[] FieldId2FieldName = new string[1] { "RewardItemKey" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	private ItemKey _rewardItemKey = ItemKey.Invalid;

	public bool OfflineInitActionData(DataContext context, Character character, ContextArgGroupHandle argGroup, CharacterActionData actionData)
	{
		_rewardItemKey = ActionHelper.SelectTreasuryItemReward(context, character);
		return _rewardItemKey.IsValid();
	}

	public bool CheckValid(Character character, CharacterActionData actionData)
	{
		int targetCharIdA = actionData.TargetCharIds[0];
		int targetCharIdB = actionData.TargetCharIds[1];
		Character element_Objects = DomainManager.Character.GetElement_Objects(targetCharIdA);
		Character targetCharB = DomainManager.Character.GetElement_Objects(targetCharIdB);
		OrganizationInfo targetCharAOrgInfo = element_Objects.GetOrganizationInfo();
		if (targetCharAOrgInfo.Grade != targetCharB.GetOrganizationInfo().Grade)
		{
			return false;
		}
		if (targetCharAOrgInfo.Grade >= character.GetOrganizationInfo().Grade)
		{
			return false;
		}
		return DomainManager.Organization.GetTreasury(targetCharAOrgInfo).Inventory.Items.ContainsKey(_rewardItemKey);
	}

	public void PostExecute(DataContext context, Character character, CharacterActionData actionData)
	{
		int targetCharIdA = actionData.TargetCharIds[0];
		int targetCharIdB = actionData.TargetCharIds[1];
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int selfCharId = character.GetId();
		int currDate = DomainManager.World.GetCurrDate();
		Location location = character.GetLocation();
		lifeRecordCollection.AddIdentityActionJieQing5(selfCharId, currDate, targetCharIdA, targetCharIdB, location, _rewardItemKey.ItemType, _rewardItemKey.TemplateId);
		Character targetCharA = DomainManager.Character.GetElement_Objects(targetCharIdA);
		Character targetCharB = DomainManager.Character.GetElement_Objects(targetCharIdB);
		OrganizationInfo orgInfo = targetCharA.GetOrganizationInfo();
		DomainManager.Organization.RemoveTreasuryItem(context, orgInfo.SettlementId, _rewardItemKey, 1);
		AiHelper.NpcCombatResultType resultType = DomainManager.Character.SimulateCharacterCombat(context, targetCharA, targetCharB, CombatType.Beat, isGroupCombat: false);
		if ((uint)resultType <= 1u)
		{
			targetCharA.AddInventoryItem(context, _rewardItemKey, 1);
		}
		else
		{
			targetCharB.AddInventoryItem(context, _rewardItemKey, 1);
		}
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 2;
		totalSize += _rewardItemKey.GetSerializedSize();
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 1;
		pCurrData += 2;
		int fieldSize = _rewardItemKey.Serialize(pCurrData);
		pCurrData += fieldSize;
		Tester.Assert(fieldSize <= 65535);
		int totalSize = (int)(pCurrData - pData);
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
			pCurrData += _rewardItemKey.Deserialize(pCurrData);
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
