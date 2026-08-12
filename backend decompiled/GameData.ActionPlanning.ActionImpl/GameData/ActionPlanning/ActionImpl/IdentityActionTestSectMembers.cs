using GameData.ActionPlanning.ActionImpl.Helper;
using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.Item;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.SpecialEffect;
using GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.BreakBodyEffect;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.ActionPlanning.ActionImpl;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class IdentityActionTestSectMembers : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort ItemReward = 0;

		public const ushort FeatureId = 1;

		public const ushort Count = 2;

		public static readonly string[] FieldId2FieldName = new string[2] { "ItemReward", "FeatureId" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	private ItemKey _itemReward = ItemKey.Invalid;

	[SerializableGameDataField(FieldIndex = 1)]
	private short _featureId = -1;

	public bool OfflineInitActionData(DataContext context, Character character, ContextArgGroupHandle argGroup, CharacterActionData actionData)
	{
		sbyte bodyPart = (sbyte)context.Random.Next(7);
		_featureId = (context.Random.NextBool() ? BreakFeatureHelper.BodyPart2CrashFeature[bodyPart] : BreakFeatureHelper.BodyPart2HurtFeature[bodyPart]);
		_itemReward = ActionHelper.SelectTreasuryItemReward(context, character);
		return _itemReward.IsValid();
	}

	public bool CheckValid(Character character, CharacterActionData actionData)
	{
		return DomainManager.Organization.GetTreasury(character.GetOrganizationInfo()).Inventory.Items.ContainsKey(_itemReward);
	}

	public void PostExecute(DataContext context, Character character, CharacterActionData actionData)
	{
		Character targetChar = actionData.TargetChar;
		int targetCharId = targetChar.GetId();
		targetChar.AddFeature(context, _featureId);
		DomainManager.SpecialEffect.Add(context, targetCharId, SpecialEffectDomain.BreakBodyFeatureEffectClassName[_featureId]);
		OrganizationInfo orgInfo = targetChar.GetOrganizationInfo();
		DomainManager.Organization.GetTreasury(orgInfo).Inventory.OfflineRemove(_itemReward, 1);
		DomainManager.Item.RemoveOwner(_itemReward, ItemOwnerType.Treasury, orgInfo.SettlementId);
		targetChar.AddInventoryItem(context, _itemReward, 1);
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int currDate = DomainManager.World.GetCurrDate();
		Location location = character.GetLocation();
		int selfCharId = character.GetId();
		lifeRecordCollection.AddIdentityActionXveHou5(selfCharId, currDate, targetCharId, location, _itemReward.ItemType, _itemReward.TemplateId);
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 4;
		totalSize += _itemReward.GetSerializedSize();
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 2;
		pCurrData += 2;
		int fieldSize = _itemReward.Serialize(pCurrData);
		pCurrData += fieldSize;
		Tester.Assert(fieldSize <= 65535);
		*(short*)pCurrData = _featureId;
		pCurrData += 2;
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
			pCurrData += _itemReward.Deserialize(pCurrData);
		}
		if (num > 1)
		{
			_featureId = *(short*)pCurrData;
			pCurrData += 2;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
