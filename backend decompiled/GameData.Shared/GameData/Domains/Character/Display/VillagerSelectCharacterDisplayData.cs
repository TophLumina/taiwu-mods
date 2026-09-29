using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Character.Display;

[AutoGenerateSerializableGameData(NotRestrictCollectionSerializedSize = true)]
public class VillagerSelectCharacterDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public CharacterDisplayDataForGeneralScrollList MainData;

	[SerializableGameDataField]
	public sbyte WorkType;

	[SerializableGameDataField]
	public byte WorkStatus;

	[SerializableGameDataField]
	public int ArrangementTemplateId;

	[SerializableGameDataField]
	public int BuildingBlockTemplateId;

	[SerializableGameDataField]
	public bool IsBuyOperation;

	[SerializableGameDataField]
	public bool IsWorkLeader;

	[SerializableGameDataField]
	public int GraveId;

	[SerializableGameDataField]
	public int SwordTombId;

	[SerializableGameDataField]
	public CharacterTableLocationData LocationData;

	[SerializableGameDataField]
	public OrganizationInfo OrgInfo;

	[SerializableGameDataField]
	public ushort RelationToTaiwu;

	[SerializableGameDataField]
	public ushort RelationFromTaiwu;

	[SerializableGameDataField]
	public short RoleTemplateId;

	[SerializableGameDataField]
	public sbyte LeftPotentialCount;

	[SerializableGameDataField]
	public LifeSkillShorts LifeSkillAttainments;

	[SerializableGameDataField]
	public CombatSkillShorts CombatSkillAttainments;

	public VillagerSelectCharacterDisplayData()
	{
	}

	public VillagerSelectCharacterDisplayData(VillagerSelectCharacterDisplayData other)
	{
		MainData = new CharacterDisplayDataForGeneralScrollList(other.MainData);
		WorkType = other.WorkType;
		WorkStatus = other.WorkStatus;
		ArrangementTemplateId = other.ArrangementTemplateId;
		BuildingBlockTemplateId = other.BuildingBlockTemplateId;
		IsBuyOperation = other.IsBuyOperation;
		IsWorkLeader = other.IsWorkLeader;
		GraveId = other.GraveId;
		SwordTombId = other.SwordTombId;
		LocationData = other.LocationData;
		OrgInfo = other.OrgInfo;
		RelationToTaiwu = other.RelationToTaiwu;
		RelationFromTaiwu = other.RelationFromTaiwu;
		RoleTemplateId = other.RoleTemplateId;
		LeftPotentialCount = other.LeftPotentialCount;
		LifeSkillAttainments = other.LifeSkillAttainments;
		CombatSkillAttainments = other.CombatSkillAttainments;
	}

	public void Assign(VillagerSelectCharacterDisplayData other)
	{
		MainData = new CharacterDisplayDataForGeneralScrollList(other.MainData);
		WorkType = other.WorkType;
		WorkStatus = other.WorkStatus;
		ArrangementTemplateId = other.ArrangementTemplateId;
		BuildingBlockTemplateId = other.BuildingBlockTemplateId;
		IsBuyOperation = other.IsBuyOperation;
		IsWorkLeader = other.IsWorkLeader;
		GraveId = other.GraveId;
		SwordTombId = other.SwordTombId;
		LocationData = other.LocationData;
		OrgInfo = other.OrgInfo;
		RelationToTaiwu = other.RelationToTaiwu;
		RelationFromTaiwu = other.RelationFromTaiwu;
		RoleTemplateId = other.RoleTemplateId;
		LeftPotentialCount = other.LeftPotentialCount;
		LifeSkillAttainments = other.LifeSkillAttainments;
		CombatSkillAttainments = other.CombatSkillAttainments;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 115;
		totalSize = ((MainData == null) ? (totalSize + 2) : (totalSize + (2 + MainData.GetSerializedSize())));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (MainData != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = MainData.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (byte)WorkType;
		pCurrData++;
		*pCurrData = WorkStatus;
		pCurrData++;
		*(int*)pCurrData = ArrangementTemplateId;
		pCurrData += 4;
		*(int*)pCurrData = BuildingBlockTemplateId;
		pCurrData += 4;
		*pCurrData = (IsBuyOperation ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (IsWorkLeader ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(int*)pCurrData = GraveId;
		pCurrData += 4;
		*(int*)pCurrData = SwordTombId;
		pCurrData += 4;
		pCurrData += LocationData.Serialize(pCurrData);
		pCurrData += OrgInfo.Serialize(pCurrData);
		*(ushort*)pCurrData = RelationToTaiwu;
		pCurrData += 2;
		*(ushort*)pCurrData = RelationFromTaiwu;
		pCurrData += 2;
		*(short*)pCurrData = RoleTemplateId;
		pCurrData += 2;
		*pCurrData = (byte)LeftPotentialCount;
		pCurrData++;
		pCurrData += LifeSkillAttainments.Serialize(pCurrData);
		pCurrData += CombatSkillAttainments.Serialize(pCurrData);
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
			MainData = new CharacterDisplayDataForGeneralScrollList();
			pCurrData += MainData.Deserialize(pCurrData);
		}
		else
		{
			MainData = null;
		}
		WorkType = (sbyte)(*pCurrData);
		pCurrData++;
		WorkStatus = *pCurrData;
		pCurrData++;
		ArrangementTemplateId = *(int*)pCurrData;
		pCurrData += 4;
		BuildingBlockTemplateId = *(int*)pCurrData;
		pCurrData += 4;
		IsBuyOperation = *pCurrData != 0;
		pCurrData++;
		IsWorkLeader = *pCurrData != 0;
		pCurrData++;
		GraveId = *(int*)pCurrData;
		pCurrData += 4;
		SwordTombId = *(int*)pCurrData;
		pCurrData += 4;
		pCurrData += LocationData.Deserialize(pCurrData);
		pCurrData += OrgInfo.Deserialize(pCurrData);
		RelationToTaiwu = *(ushort*)pCurrData;
		pCurrData += 2;
		RelationFromTaiwu = *(ushort*)pCurrData;
		pCurrData += 2;
		RoleTemplateId = *(short*)pCurrData;
		pCurrData += 2;
		LeftPotentialCount = (sbyte)(*pCurrData);
		pCurrData++;
		pCurrData += LifeSkillAttainments.Deserialize(pCurrData);
		pCurrData += CombatSkillAttainments.Deserialize(pCurrData);
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
