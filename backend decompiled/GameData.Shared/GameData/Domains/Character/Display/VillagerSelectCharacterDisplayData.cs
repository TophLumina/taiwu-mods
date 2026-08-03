using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Character.Display;

/// <summary>
/// 村民选人界面专用显示数据
/// </summary>
[AutoGenerateSerializableGameData(NotRestrictCollectionSerializedSize = true)]
public class VillagerSelectCharacterDisplayData : ISerializableGameData
{
	/// <summary>
	/// 基础显示数据
	/// </summary>
	[SerializableGameDataField]
	public CharacterDisplayDataForGeneralScrollList MainData;

	/// <summary>
	/// 工作类型
	/// </summary>
	[SerializableGameDataField]
	public sbyte WorkType;

	/// <summary>
	/// 工作状态
	/// </summary>
	[SerializableGameDataField]
	public byte WorkStatus;

	/// <summary>
	/// 身份安排ID
	/// </summary>
	[SerializableGameDataField]
	public int ArrangementTemplateId;

	/// <summary>
	/// 建筑块模板ID（用于经营地点显示）
	/// </summary>
	[SerializableGameDataField]
	public int BuildingBlockTemplateId;

	/// <summary>
	/// 是否为买入操作（用于经营岗位区分）
	/// </summary>
	[SerializableGameDataField]
	public bool IsBuyOperation;

	/// <summary>
	/// 是否为领队
	/// </summary>
	[SerializableGameDataField]
	public bool IsWorkLeader;

	/// <summary>
	/// 陵墓ID（守墓时使用）
	/// </summary>
	[SerializableGameDataField]
	public int GraveId;

	/// <summary>
	/// 剑冢ID（守护剑冢时使用）
	/// </summary>
	[SerializableGameDataField]
	public int SwordTombId;

	/// <summary>
	/// 位置数据
	/// </summary>
	[SerializableGameDataField]
	public CharacterTableLocationData LocationData;

	/// <summary>
	/// 组织信息（用于身份显示）
	/// </summary>
	[SerializableGameDataField]
	public OrganizationInfo OrgInfo;

	/// <summary>
	/// 关系数据（用于筛选）
	/// </summary>
	[SerializableGameDataField]
	public ushort RelationToTaiwu;

	[SerializableGameDataField]
	public ushort RelationFromTaiwu;

	/// <summary>
	/// 村民身份ID
	/// </summary>
	[SerializableGameDataField]
	public short RoleTemplateId;

	/// <summary>
	/// 剩余潜力次数
	/// </summary>
	[SerializableGameDataField]
	public sbyte LeftPotentialCount;

	/// <summary>
	/// 技艺造诣（建筑派遣选人显示所需造诣）
	/// </summary>
	[SerializableGameDataField]
	public LifeSkillShorts LifeSkillAttainments;

	/// <summary>
	/// 武学造诣（建筑派遣选人显示所需造诣）
	/// </summary>
	[SerializableGameDataField]
	public CombatSkillShorts CombatSkillAttainments;

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public VillagerSelectCharacterDisplayData()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
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

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
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
		int totalSize = 47;
		totalSize = ((MainData == null) ? (totalSize + 2) : (totalSize + (2 + MainData.GetSerializedSize())));
		totalSize += OrgInfo.GetSerializedSize();
		totalSize += LifeSkillAttainments.GetSerializedSize();
		totalSize += CombatSkillAttainments.GetSerializedSize();
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
