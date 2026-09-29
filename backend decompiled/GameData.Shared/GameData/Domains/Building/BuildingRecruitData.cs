using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Building;

[SerializableGameData(IsExtensible = true, NotRestrictCollectionSerializedSize = true)]
public class BuildingRecruitData : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort CharacterDataList = 0;

		public const ushort BuildingTemplateId = 1;

		public const ushort Count = 2;

		public static readonly string[] FieldId2FieldName = new string[2] { "CharacterDataList", "BuildingTemplateId" };
	}

	[SerializableGameDataField]
	public List<BuildingRecruitCharacterData> CharacterDataList;

	[SerializableGameDataField]
	public short BuildingTemplateId;

	public BuildingRecruitData()
	{
	}

	public BuildingRecruitData(BuildingRecruitData other)
	{
		if (other.CharacterDataList != null)
		{
			List<BuildingRecruitCharacterData> item = other.CharacterDataList;
			int elementsCount = item.Count;
			CharacterDataList = new List<BuildingRecruitCharacterData>(elementsCount);
			for (int i = 0; i < elementsCount; i++)
			{
				CharacterDataList.Add(new BuildingRecruitCharacterData(item[i]));
			}
		}
		else
		{
			CharacterDataList = null;
		}
		BuildingTemplateId = other.BuildingTemplateId;
	}

	public void Assign(BuildingRecruitData other)
	{
		if (other.CharacterDataList != null)
		{
			List<BuildingRecruitCharacterData> item = other.CharacterDataList;
			int elementsCount = item.Count;
			CharacterDataList = new List<BuildingRecruitCharacterData>(elementsCount);
			for (int i = 0; i < elementsCount; i++)
			{
				CharacterDataList.Add(new BuildingRecruitCharacterData(item[i]));
			}
		}
		else
		{
			CharacterDataList = null;
		}
		BuildingTemplateId = other.BuildingTemplateId;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 4;
		if (CharacterDataList != null)
		{
			totalSize += 2;
			int elementsCount = CharacterDataList.Count;
			for (int i = 0; i < elementsCount; i++)
			{
				BuildingRecruitCharacterData element = CharacterDataList[i];
				totalSize = ((element == null) ? (totalSize + 2) : (totalSize + (2 + element.GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
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
		if (CharacterDataList != null)
		{
			int elementsCount = CharacterDataList.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				BuildingRecruitCharacterData element = CharacterDataList[i];
				if (element != null)
				{
					byte* intPtr = pCurrData;
					pCurrData += 2;
					int subDataSize = element.Serialize(pCurrData);
					pCurrData += subDataSize;
					Tester.Assert(subDataSize <= 65535);
					*(ushort*)intPtr = (ushort)subDataSize;
				}
				else
				{
					*(short*)pCurrData = 0;
					pCurrData += 2;
				}
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(short*)pCurrData = BuildingTemplateId;
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
		ushort fieldCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (fieldCount > 0)
		{
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				if (CharacterDataList == null)
				{
					CharacterDataList = new List<BuildingRecruitCharacterData>(elementsCount);
				}
				else
				{
					CharacterDataList.Clear();
				}
				for (int i = 0; i < elementsCount; i++)
				{
					ushort num = *(ushort*)pCurrData;
					pCurrData += 2;
					if (num > 0)
					{
						BuildingRecruitCharacterData element = new BuildingRecruitCharacterData();
						pCurrData += element.Deserialize(pCurrData);
						CharacterDataList.Add(element);
					}
					else
					{
						CharacterDataList.Add(null);
					}
				}
			}
			else
			{
				CharacterDataList?.Clear();
			}
		}
		if (fieldCount > 1)
		{
			BuildingTemplateId = *(short*)pCurrData;
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
