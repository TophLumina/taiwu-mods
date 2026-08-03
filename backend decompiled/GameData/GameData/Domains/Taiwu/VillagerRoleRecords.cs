using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Taiwu;

[SerializableGameData(IsExtensible = true, NoCopyConstructors = true, NotForDisplayModule = true)]
public class VillagerRoleRecords : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort History = 0;

		public const ushort Count = 1;

		public static readonly string[] FieldId2FieldName = new string[1] { "History" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public List<VillagerRoleRecordElement> History = new List<VillagerRoleRecordElement>();

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 2;
		if (History != null)
		{
			totalSize += 2;
			int elementsCount = History.Count;
			for (int i = 0; i < elementsCount; i++)
			{
				VillagerRoleRecordElement element = History[i];
				totalSize = ((element == null) ? (totalSize + 2) : (totalSize + (2 + element.GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 1;
		pCurrData += 2;
		if (History != null)
		{
			int elementsCount = History.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				VillagerRoleRecordElement element = History[i];
				if (element != null)
				{
					byte* pSubDataCount = pCurrData;
					pCurrData += 2;
					int subDataSize = element.Serialize(pCurrData);
					pCurrData += subDataSize;
					Tester.Assert(subDataSize <= 65535);
					*(ushort*)pSubDataCount = (ushort)subDataSize;
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
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
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
				if (History == null)
				{
					History = new List<VillagerRoleRecordElement>(elementsCount);
				}
				else
				{
					History.Clear();
				}
				for (int i = 0; i < elementsCount; i++)
				{
					ushort subDataCount = *(ushort*)pCurrData;
					pCurrData += 2;
					if (subDataCount > 0)
					{
						VillagerRoleRecordElement element = new VillagerRoleRecordElement();
						pCurrData += element.Deserialize(pCurrData);
						History.Add(element);
					}
					else
					{
						History.Add(null);
					}
				}
			}
			else
			{
				History?.Clear();
			}
		}
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}
}
