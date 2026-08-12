using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.Item;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.ActionPlanning.ActionImpl;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class IdentityActionGetTianJieFuLu : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort Count = 0;
	}

	public bool CheckValid(Character character, CharacterActionData actionData)
	{
		return true;
	}

	public void PostExecute(DataContext context, Character character, CharacterActionData actionData)
	{
		ItemKey itemKey = DomainManager.Item.CreateItem(context, 12, 265);
		int amount = context.Random.Next(3, 7);
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int charId = character.GetId();
		Location location = character.GetLocation();
		int currDate = DomainManager.World.GetCurrDate();
		lifeRecordCollection.AddIdentityActionRanShan5(charId, currDate, location, amount, itemKey.ItemType, itemKey.TemplateId);
		OrganizationInfo orgInfo = character.GetOrganizationInfo();
		DomainManager.Organization.StoreItemInTreasury(context, orgInfo.SettlementId, character, itemKey, amount, -1);
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
