using GameData.Domains.Character;
using GameData.Domains.Character.Display;
using GameData.Domains.Item;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Taiwu.Display;

/// <summary>
/// 一个有身份的村民的显示数据
/// </summary>
[AutoGenerateSerializableGameData(NoCopyConstructors = true, NotForArchive = true)]
public class VillagerRoleCharacterDisplayData : ISerializableGameData
{
	/// <summary>
	/// 角色id
	/// </summary>
	[SerializableGameDataField]
	public int Id;

	/// <summary>
	/// 什么身份
	/// </summary>
	[SerializableGameDataField]
	public short RoleTemplateId;

	/// <summary>
	/// 身份派遣工作
	/// </summary>
	[SerializableGameDataField]
	public VillagerRoleArrangementDisplayDataWrapper ArrangementDisplayData;

	/// <summary>
	/// 标记
	/// </summary>
	[SerializableGameDataField]
	public byte Flags;

	/// <summary>
	/// 存活状态：0：活着，1：死亡，2：死亡并消除数据
	/// </summary>
	[SerializableGameDataField]
	public sbyte AliveState;

	/// <summary>
	/// 年龄
	/// </summary>
	[SerializableGameDataField]
	public short Age;

	/// <summary>
	/// 七元赋性
	/// </summary>
	[SerializableGameDataField]
	public Personalities Personalities;

	/// <summary>
	/// 武学造诣，村长信息需要
	/// </summary>
	[SerializableGameDataField]
	public CombatSkillShorts CombatSkillAttainments;

	/// <summary>
	/// 技艺造诣，村长信息需要
	/// </summary>
	[SerializableGameDataField]
	public LifeSkillShorts LifeSkillAttainments;

	/// <summary>
	/// 武学资质，村长信息需要
	/// </summary>
	[SerializableGameDataField]
	public CombatSkillShorts CombatSkillQualifications;

	/// <summary>
	/// 技艺资质，村长信息需要
	/// </summary>
	[SerializableGameDataField]
	public LifeSkillShorts LifeSkillQualifications;

	/// <summary>
	/// 名称数据
	/// </summary>
	[SerializableGameDataField]
	public NameRelatedData Name;

	/// <summary>
	/// 外貌
	/// </summary>
	[SerializableGameDataField]
	public AvatarRelatedData Avatar;

	/// <summary>
	/// 在经营建筑中的相应读书的最高品级
	/// </summary>
	[SerializableGameDataField]
	public sbyte ReadBookMaxGrade;

	/// <summary>
	/// 拥有的身份是否适合经营建筑类型
	/// </summary>
	[SerializableGameDataField]
	public bool MatchVillagerRole;

	/// <summary>
	/// 是否被锁定派遣
	/// </summary>
	[SerializableGameDataField]
	public bool AssignLocked;

	/// <summary>
	/// 剩余潜力次数
	/// </summary>
	[SerializableGameDataField]
	public sbyte LeftPotentialCount;

	/// <summary>
	/// 关联物品
	/// </summary>
	[SerializableGameDataField]
	public TemplateKey ItemTemplateKey = TemplateKey.Invalid;

	/// <summary>
	/// 基础工作
	/// </summary>
	[SerializableGameDataField]
	public VillagerWorkData VillagerWorkData;

	/// <summary>
	/// 农户采集资源
	/// </summary>
	[SerializableGameDataField]
	public int CollectResourceAmount;

	/// <summary>
	/// 标记 · 当前在村
	/// </summary>
	public const byte FlagInVillage = 1;

	/// <summary>
	/// 标记 · 遗漏走失
	/// </summary>
	public const byte FlagInMissing = 2;

	/// <summary>
	/// 标记 · 是否首领
	/// </summary>
	public const byte FlagIsLeader = 4;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 18;
		totalSize = ((ArrangementDisplayData == null) ? (totalSize + 2) : (totalSize + (2 + ArrangementDisplayData.GetSerializedSize())));
		totalSize += Personalities.GetSerializedSize();
		totalSize += CombatSkillAttainments.GetSerializedSize();
		totalSize += LifeSkillAttainments.GetSerializedSize();
		totalSize += CombatSkillQualifications.GetSerializedSize();
		totalSize += LifeSkillQualifications.GetSerializedSize();
		totalSize += Name.GetSerializedSize();
		totalSize = ((Avatar == null) ? (totalSize + 2) : (totalSize + (2 + Avatar.GetSerializedSize())));
		totalSize += ItemTemplateKey.GetSerializedSize();
		totalSize = ((VillagerWorkData == null) ? (totalSize + 2) : (totalSize + (2 + VillagerWorkData.GetSerializedSize())));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(int*)pCurrData = Id;
		pCurrData += 4;
		*(short*)pCurrData = RoleTemplateId;
		pCurrData += 2;
		if (ArrangementDisplayData != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = ArrangementDisplayData.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = Flags;
		pCurrData++;
		*pCurrData = (byte)AliveState;
		pCurrData++;
		*(short*)pCurrData = Age;
		pCurrData += 2;
		pCurrData += Personalities.Serialize(pCurrData);
		pCurrData += CombatSkillAttainments.Serialize(pCurrData);
		pCurrData += LifeSkillAttainments.Serialize(pCurrData);
		pCurrData += CombatSkillQualifications.Serialize(pCurrData);
		pCurrData += LifeSkillQualifications.Serialize(pCurrData);
		pCurrData += Name.Serialize(pCurrData);
		if (Avatar != null)
		{
			byte* intPtr2 = pCurrData;
			pCurrData += 2;
			int fieldSize2 = Avatar.Serialize(pCurrData);
			pCurrData += fieldSize2;
			Tester.Assert(fieldSize2 <= 65535);
			*(ushort*)intPtr2 = (ushort)fieldSize2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (byte)ReadBookMaxGrade;
		pCurrData++;
		*pCurrData = (MatchVillagerRole ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (AssignLocked ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (byte)LeftPotentialCount;
		pCurrData++;
		pCurrData += ItemTemplateKey.Serialize(pCurrData);
		pCurrData += VillagerWorkData.Serialize(pCurrData);
		*(int*)pCurrData = CollectResourceAmount;
		pCurrData += 4;
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
		Id = *(int*)pCurrData;
		pCurrData += 4;
		RoleTemplateId = *(short*)pCurrData;
		pCurrData += 2;
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			ArrangementDisplayData = new VillagerRoleArrangementDisplayDataWrapper();
			pCurrData += ArrangementDisplayData.Deserialize(pCurrData);
		}
		else
		{
			ArrangementDisplayData = null;
		}
		Flags = *pCurrData;
		pCurrData++;
		AliveState = (sbyte)(*pCurrData);
		pCurrData++;
		Age = *(short*)pCurrData;
		pCurrData += 2;
		pCurrData += Personalities.Deserialize(pCurrData);
		pCurrData += CombatSkillAttainments.Deserialize(pCurrData);
		pCurrData += LifeSkillAttainments.Deserialize(pCurrData);
		pCurrData += CombatSkillQualifications.Deserialize(pCurrData);
		pCurrData += LifeSkillQualifications.Deserialize(pCurrData);
		pCurrData += Name.Deserialize(pCurrData);
		ushort num2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num2 > 0)
		{
			Avatar = new AvatarRelatedData();
			pCurrData += Avatar.Deserialize(pCurrData);
		}
		else
		{
			Avatar = null;
		}
		ReadBookMaxGrade = (sbyte)(*pCurrData);
		pCurrData++;
		MatchVillagerRole = *pCurrData != 0;
		pCurrData++;
		AssignLocked = *pCurrData != 0;
		pCurrData++;
		LeftPotentialCount = (sbyte)(*pCurrData);
		pCurrData++;
		pCurrData += ItemTemplateKey.Deserialize(pCurrData);
		VillagerWorkData = new VillagerWorkData();
		pCurrData += VillagerWorkData.Deserialize(pCurrData);
		CollectResourceAmount = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
