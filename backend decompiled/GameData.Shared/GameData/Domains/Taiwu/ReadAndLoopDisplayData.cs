using System.Collections.Generic;
using GameData.Domains.Character;
using GameData.Domains.Item;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Taiwu;

/// <summary>
/// 周天与读书的显示数据
/// </summary>
[AutoGenerateSerializableGameData(NotForArchive = true, NoCopyConstructors = true)]
public class ReadAndLoopDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public sbyte BookReadProgress;

	[SerializableGameDataField]
	public sbyte HasEventFlag;

	[SerializableGameDataField]
	public short LoopingId;

	[SerializableGameDataField]
	public short LoopingObtainedNeili;

	[SerializableGameDataField]
	public short LoopingTotalObtainableNeili;

	[SerializableGameDataField]
	public short ActiveLoopingProgress;

	[SerializableGameDataField]
	public short ActiveReadingProgress;

	[SerializableGameDataField]
	public ItemKey BookKey;

	[SerializableGameDataField]
	public MainAttributes MainAttributes;

	[SerializableGameDataField]
	public List<int> Durabilities;

	[SerializableGameDataField(ArrayElementsCount = 3)]
	public ItemKey[] ReferenceBook = new ItemKey[3]
	{
		ItemKey.Invalid,
		ItemKey.Invalid,
		ItemKey.Invalid
	};

	public short BookId => BookKey.TemplateId;

	public bool BookFinish => BookReadProgress >= 100;

	public bool LoopingFinished => LoopingObtainedNeili >= LoopingTotalObtainableNeili;

	public bool BookHasEvent => (HasEventFlag & 1) != 0;

	public bool LoopingHasEvent => (HasEventFlag & 2) != 0;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 12;
		totalSize += BookKey.GetSerializedSize();
		totalSize += MainAttributes.GetSerializedSize();
		totalSize = ((Durabilities == null) ? (totalSize + 2) : (totalSize + (2 + 4 * Durabilities.Count)));
		for (int i = 0; i < 3; i++)
		{
			totalSize += ReferenceBook[i].GetSerializedSize();
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
		*pCurrData = (byte)BookReadProgress;
		pCurrData++;
		*pCurrData = (byte)HasEventFlag;
		pCurrData++;
		*(short*)pCurrData = LoopingId;
		pCurrData += 2;
		*(short*)pCurrData = LoopingObtainedNeili;
		pCurrData += 2;
		*(short*)pCurrData = LoopingTotalObtainableNeili;
		pCurrData += 2;
		*(short*)pCurrData = ActiveLoopingProgress;
		pCurrData += 2;
		*(short*)pCurrData = ActiveReadingProgress;
		pCurrData += 2;
		pCurrData += BookKey.Serialize(pCurrData);
		pCurrData += MainAttributes.Serialize(pCurrData);
		if (Durabilities != null)
		{
			int elementsCount = Durabilities.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				*(int*)pCurrData = Durabilities[i];
				pCurrData += 4;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		Tester.Assert(ReferenceBook.Length == 3);
		for (int j = 0; j < 3; j++)
		{
			pCurrData += ReferenceBook[j].Serialize(pCurrData);
		}
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
		BookReadProgress = (sbyte)(*pCurrData);
		pCurrData++;
		HasEventFlag = (sbyte)(*pCurrData);
		pCurrData++;
		LoopingId = *(short*)pCurrData;
		pCurrData += 2;
		LoopingObtainedNeili = *(short*)pCurrData;
		pCurrData += 2;
		LoopingTotalObtainableNeili = *(short*)pCurrData;
		pCurrData += 2;
		ActiveLoopingProgress = *(short*)pCurrData;
		pCurrData += 2;
		ActiveReadingProgress = *(short*)pCurrData;
		pCurrData += 2;
		pCurrData += BookKey.Deserialize(pCurrData);
		pCurrData += MainAttributes.Deserialize(pCurrData);
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (Durabilities == null)
			{
				Durabilities = new List<int>();
			}
			else
			{
				Durabilities.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				int element = *(int*)pCurrData;
				pCurrData += 4;
				Durabilities.Add(element);
			}
		}
		else
		{
			Durabilities?.Clear();
		}
		if (ReferenceBook == null || ReferenceBook.Length != 3)
		{
			ReferenceBook = new ItemKey[3];
		}
		for (int j = 0; j < 3; j++)
		{
			ReferenceBook[j] = default(ItemKey);
			pCurrData += ReferenceBook[j].Deserialize(pCurrData);
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
