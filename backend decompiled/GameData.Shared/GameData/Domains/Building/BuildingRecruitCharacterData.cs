using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Building;

[SerializableGameData(IsExtensible = true, NotRestrictCollectionSerializedSize = true)]
public class BuildingRecruitCharacterData : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort CharacterData = 0;

		public const ushort BuildingBlockKey = 1;

		public const ushort RecruitInfoIndex = 2;

		public const ushort RecruitLevel = 3;

		public const ushort Count = 4;

		public static readonly string[] FieldId2FieldName = new string[4] { "CharacterData", "BuildingBlockKey", "RecruitInfoIndex", "RecruitLevel" };
	}

	[SerializableGameDataField]
	public RecruitCharacterData CharacterData;

	[SerializableGameDataField]
	public BuildingBlockKey BuildingBlockKey;

	[SerializableGameDataField]
	public int RecruitInfoIndex;

	[SerializableGameDataField]
	public IntPair RecruitLevel;

	public BuildingRecruitCharacterData()
	{
	}

	public BuildingRecruitCharacterData(BuildingRecruitCharacterData other)
	{
		CharacterData = new RecruitCharacterData(other.CharacterData);
		BuildingBlockKey = other.BuildingBlockKey;
		RecruitInfoIndex = other.RecruitInfoIndex;
		RecruitLevel = other.RecruitLevel;
	}

	public void Assign(BuildingRecruitCharacterData other)
	{
		CharacterData = new RecruitCharacterData(other.CharacterData);
		BuildingBlockKey = other.BuildingBlockKey;
		RecruitInfoIndex = other.RecruitInfoIndex;
		RecruitLevel = other.RecruitLevel;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 22;
		totalSize = ((CharacterData == null) ? (totalSize + 2) : (totalSize + (2 + CharacterData.GetSerializedSize())));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 4;
		pCurrData += 2;
		if (CharacterData != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = CharacterData.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += BuildingBlockKey.Serialize(pCurrData);
		*(int*)pCurrData = RecruitInfoIndex;
		pCurrData += 4;
		pCurrData += RecruitLevel.Serialize(pCurrData);
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
			ushort num2 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (num2 > 0)
			{
				if (CharacterData == null)
				{
					CharacterData = new RecruitCharacterData();
				}
				pCurrData += CharacterData.Deserialize(pCurrData);
			}
			else
			{
				CharacterData = null;
			}
		}
		if (num > 1)
		{
			pCurrData += BuildingBlockKey.Deserialize(pCurrData);
		}
		if (num > 2)
		{
			RecruitInfoIndex = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 3)
		{
			pCurrData += RecruitLevel.Deserialize(pCurrData);
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
