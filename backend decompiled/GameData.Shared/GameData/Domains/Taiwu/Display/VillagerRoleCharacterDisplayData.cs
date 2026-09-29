using GameData.Domains.Character;
using GameData.Domains.Character.Display;
using GameData.Domains.Item;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Taiwu.Display;

[AutoGenerateSerializableGameData(NoCopyConstructors = true, NotForArchive = true)]
public class VillagerRoleCharacterDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public int Id;

	[SerializableGameDataField]
	public short RoleTemplateId;

	[SerializableGameDataField]
	public VillagerRoleArrangementDisplayDataWrapper ArrangementDisplayData;

	[SerializableGameDataField]
	public byte Flags;

	[SerializableGameDataField]
	public sbyte AliveState;

	[SerializableGameDataField]
	public short Age;

	[SerializableGameDataField]
	public Personalities Personalities;

	[SerializableGameDataField]
	public CombatSkillShorts CombatSkillAttainments;

	[SerializableGameDataField]
	public LifeSkillShorts LifeSkillAttainments;

	[SerializableGameDataField]
	public CombatSkillShorts CombatSkillQualifications;

	[SerializableGameDataField]
	public LifeSkillShorts LifeSkillQualifications;

	[SerializableGameDataField]
	public NameRelatedData Name;

	[SerializableGameDataField]
	public AvatarRelatedData Avatar;

	[SerializableGameDataField]
	public sbyte ReadBookMaxGrade;

	[SerializableGameDataField]
	public bool MatchVillagerRole;

	[SerializableGameDataField]
	public bool AssignLocked;

	[SerializableGameDataField]
	public sbyte LeftPotentialCount;

	[SerializableGameDataField]
	public TemplateKey ItemTemplateKey = TemplateKey.Invalid;

	[SerializableGameDataField]
	public VillagerWorkData VillagerWorkData;

	[SerializableGameDataField]
	public int CollectResourceAmount;

	public const byte FlagInVillage = 1;

	public const byte FlagInMissing = 2;

	public const byte FlagIsLeader = 4;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 201;
		totalSize = ((ArrangementDisplayData == null) ? (totalSize + 2) : (totalSize + (2 + ArrangementDisplayData.GetSerializedSize())));
		totalSize = ((Avatar == null) ? (totalSize + 2) : (totalSize + (2 + Avatar.GetSerializedSize())));
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
