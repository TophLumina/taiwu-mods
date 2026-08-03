using Config;
using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.Organization;
using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.ActionPlanning.ActionImpl;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class IdentityActionAddTreasuryResources : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort Count = 0;
	}

	public bool CheckValid(GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
		return character.GetOrganizationInfo().SettlementId >= 0;
	}

	public void PostExecute(DataContext context, GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
		OrganizationInfo orgInfo = character.GetOrganizationInfo();
		SettlementTreasury treasury = DomainManager.Organization.GetTreasury(orgInfo);
		OrganizationMemberItem orgMemberCfg = orgInfo.GetOrgMemberConfig();
		for (sbyte resourceType = 0; resourceType < 7; resourceType++)
		{
			treasury.Resources[resourceType] += orgMemberCfg.GetAdjustedResourceSatisfyingAmount(resourceType) / 10;
		}
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int selfCharId = character.GetId();
		int currDate = DomainManager.World.GetCurrDate();
		Location location = character.GetLocation();
		lifeRecordCollection.AddIdentityActionFuLong2(selfCharId, currDate, location);
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
