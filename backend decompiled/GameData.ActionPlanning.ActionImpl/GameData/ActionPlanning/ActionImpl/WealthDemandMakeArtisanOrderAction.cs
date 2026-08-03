using System.Collections.Generic;
using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.Character.Filters;
using GameData.Domains.Item;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.Organization;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.ActionPlanning.ActionImpl;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class WealthDemandMakeArtisanOrderAction : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort LifeSkillType = 0;

		public const ushort ItemSubType = 1;

		public const ushort GiftTargetCharId = 2;

		public const ushort CraftsmanCharId = 3;

		public const ushort Count = 4;

		public static readonly string[] FieldId2FieldName = new string[4] { "LifeSkillType", "ItemSubType", "GiftTargetCharId", "CraftsmanCharId" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public sbyte LifeSkillType;

	[SerializableGameDataField(FieldIndex = 1)]
	public short ItemSubType;

	[SerializableGameDataField(FieldIndex = 2)]
	public int GiftTargetCharId = -1;

	[SerializableGameDataField(FieldIndex = 3)]
	public int CraftsmanCharId = -1;

	public bool OfflineInitActionData(DataContext context, Character selfChar, ContextArgGroupHandle argGroup, CharacterActionData actionData)
	{
		sbyte itemType = argGroup.ItemType;
		short itemTemplateId = argGroup.ItemTemplateId;
		if (!selfChar.GetLocation().IsValid())
		{
			return false;
		}
		if (!selfChar.IsInRegularSettlementRange())
		{
			return false;
		}
		if (!ItemTemplateHelper.CanMakeArtisanOrder(itemType, itemTemplateId))
		{
			return false;
		}
		sbyte lifeSkillType = ItemTemplateHelper.GetCraftRequiredLifeSkillType(itemType, itemTemplateId);
		if (lifeSkillType < 0)
		{
			return false;
		}
		short itemSubType = ItemTemplateHelper.GetItemSubType(itemType, itemTemplateId);
		List<Character> targetCharList = ObjectPool<List<Character>>.Instance.Get();
		MapCharacterFilter.Find((Character character) => character.IsInteractableAsIntelligentCharacter() && character.IdentifyCanCraftItem(itemType, itemTemplateId) && DomainManager.Extra.IsArtisanIdle(character.GetId()), targetCharList, selfChar.GetLocation().AreaId);
		Character purchaseTarget = targetCharList.GetRandomOrDefault(context.Random, null);
		ObjectPool<List<Character>>.Instance.Return(targetCharList);
		if (purchaseTarget == null)
		{
			return false;
		}
		ItemSubType = itemSubType;
		LifeSkillType = lifeSkillType;
		GiftTargetCharId = actionData.TargetCharId;
		CraftsmanCharId = purchaseTarget.GetId();
		return true;
	}

	public bool CheckValid(Character character, CharacterActionData actionData)
	{
		if (DomainManager.Character.TryGetElement_Objects(CraftsmanCharId, out var targetChar) && OrganizationDomain.GetOrgMemberConfig(targetChar.GetOrganizationInfo()).CraftTypes.Exist(LifeSkillType))
		{
			return DomainManager.Extra.IsArtisanIdle(targetChar.GetId());
		}
		return false;
	}

	public void PostExecute(DataContext context, Character selfChar, CharacterActionData actionData)
	{
		Character craftsmanTarget = DomainManager.Character.GetElement_Objects(CraftsmanCharId);
		int currDate = DomainManager.World.GetCurrDate();
		Location location = craftsmanTarget.GetLocation();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		if (GiftTargetCharId >= 0 && DomainManager.Character.TryGetElement_Objects(GiftTargetCharId, out var giftTargetChar))
		{
			DomainManager.Extra.CreateArtisanOrderWithoutCost(context, craftsmanTarget, giftTargetChar, LifeSkillType, ItemSubType);
			lifeRecordCollection.AddOrderProductForOthers(selfChar.GetId(), currDate, CraftsmanCharId, GiftTargetCharId, location);
		}
		else
		{
			DomainManager.Extra.CreateArtisanOrderWithoutCost(context, craftsmanTarget, selfChar, LifeSkillType, ItemSubType);
			lifeRecordCollection.AddOrderProduct(selfChar.GetId(), currDate, CraftsmanCharId, location);
		}
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 13;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = 4;
		byte* num = pData + 2;
		*num = (byte)LifeSkillType;
		byte* num2 = num + 1;
		*(short*)num2 = ItemSubType;
		byte* num3 = num2 + 2;
		*(int*)num3 = GiftTargetCharId;
		byte* num4 = num3 + 4;
		*(int*)num4 = CraftsmanCharId;
		int totalSize = (int)(num4 + 4 - pData);
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
			LifeSkillType = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (num > 1)
		{
			ItemSubType = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 2)
		{
			GiftTargetCharId = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 3)
		{
			CraftsmanCharId = *(int*)pCurrData;
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
