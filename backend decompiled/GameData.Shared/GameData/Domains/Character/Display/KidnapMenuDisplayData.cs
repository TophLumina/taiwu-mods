using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Character.Display;

[AutoGenerateSerializableGameData(IsExtensible = true, NoCopyConstructors = true)]
public class KidnapMenuDisplayData : ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort KidnapperId = 0;

		public const ushort KidnapCharDisplayDataList = 1;

		public const ushort MaxKidnapSlotCount = 2;

		public const ushort CurrentKidnapCount = 3;

		public const ushort Count = 4;

		public static readonly string[] FieldId2FieldName = new string[4] { "KidnapperId", "KidnapCharDisplayDataList", "MaxKidnapSlotCount", "CurrentKidnapCount" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public int KidnapperId;

	[SerializableGameDataField(FieldIndex = 1)]
	public List<KidnapCharDisplayData> KidnapCharDisplayDataList;

	[SerializableGameDataField(FieldIndex = 2)]
	public int MaxKidnapSlotCount;

	[SerializableGameDataField(FieldIndex = 3)]
	public int CurrentKidnapCount;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 14;
		if (KidnapCharDisplayDataList != null)
		{
			totalSize += 2;
			for (int i = 0; i < KidnapCharDisplayDataList.Count; i++)
			{
				totalSize = ((KidnapCharDisplayDataList[i] == null) ? (totalSize + 2) : (totalSize + (2 + KidnapCharDisplayDataList[i].GetSerializedSize())));
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
		*(short*)pCurrData = 4;
		pCurrData += 2;
		*(int*)pCurrData = KidnapperId;
		pCurrData += 4;
		if (KidnapCharDisplayDataList != null)
		{
			int elementsCount = KidnapCharDisplayDataList.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				if (KidnapCharDisplayDataList[i] != null)
				{
					byte* intPtr = pCurrData;
					pCurrData += 2;
					int fieldSize = KidnapCharDisplayDataList[i].Serialize(pCurrData);
					pCurrData += fieldSize;
					Tester.Assert(fieldSize <= 65535);
					*(ushort*)intPtr = (ushort)fieldSize;
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
		*(int*)pCurrData = MaxKidnapSlotCount;
		pCurrData += 4;
		*(int*)pCurrData = CurrentKidnapCount;
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
		ushort fieldCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (fieldCount > 0)
		{
			KidnapperId = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 1)
		{
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				if (KidnapCharDisplayDataList == null)
				{
					KidnapCharDisplayDataList = new List<KidnapCharDisplayData>();
				}
				else
				{
					KidnapCharDisplayDataList.Clear();
				}
				for (int i = 0; i < elementsCount; i++)
				{
					ushort num = *(ushort*)pCurrData;
					pCurrData += 2;
					KidnapCharDisplayData element;
					if (num > 0)
					{
						element = new KidnapCharDisplayData();
						pCurrData += element.Deserialize(pCurrData);
					}
					else
					{
						element = null;
					}
					KidnapCharDisplayDataList.Add(element);
				}
			}
			else
			{
				KidnapCharDisplayDataList?.Clear();
			}
		}
		if (fieldCount > 2)
		{
			MaxKidnapSlotCount = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 3)
		{
			CurrentKidnapCount = *(int*)pCurrData;
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
