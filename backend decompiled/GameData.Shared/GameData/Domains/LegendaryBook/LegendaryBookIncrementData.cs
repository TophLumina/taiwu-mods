using System.Collections.Generic;
using GameData.Domains.Map;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.LegendaryBook;

/// <summary>
/// 增强奇书信息
/// </summary>
[SerializableGameData(NotRestrictCollectionSerializedSize = true, NotForArchive = true, NoCopyConstructors = true)]
public class LegendaryBookIncrementData : ISerializableGameData
{
	/// <summary>
	/// 奇书地格数据
	/// </summary>
	[SerializableGameDataField]
	public Dictionary<sbyte, MapBlockData> BlockDataMap;

	/// <summary>
	/// 奇书地格数据
	/// </summary>
	[SerializableGameDataField]
	public Dictionary<sbyte, FullBlockName> BlockNameDataMap;

	/// <summary>
	/// 奇书位置
	/// </summary>
	[SerializableGameDataField]
	public Dictionary<sbyte, Location> BookLocationMap;

	/// <summary>
	/// 奇书剩余时间
	/// </summary>
	[SerializableGameDataField]
	public Dictionary<sbyte, int> BookDurationMap;

	/// <summary>
	/// 角色字典
	/// </summary>
	[SerializableGameDataField]
	public Dictionary<int, LegendaryBookCharacterRelatedData> CharacterMap;

	/// <summary>
	/// 奇书拥有者
	/// </summary>
	[SerializableGameDataField]
	public Dictionary<sbyte, int> OwnerMap;

	/// <summary>
	/// 奇书争夺者
	/// </summary>
	[SerializableGameDataField]
	public List<int> ContestList;

	/// <summary>
	/// 奇书入邪者
	/// </summary>
	[SerializableGameDataField]
	public List<int> ShockedList;

	/// <summary>
	/// 奇书入魔者
	/// </summary>
	[SerializableGameDataField]
	public List<int> InsaneList;

	/// <summary>
	/// 奇书堕魔者
	/// </summary>
	[SerializableGameDataField]
	public List<int> ConsumedList;

	/// <summary>
	/// 上个持有者
	/// </summary>
	[SerializableGameDataField]
	public List<int> PreviousOwner;

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public LegendaryBookIncrementData()
	{
		BlockDataMap = new Dictionary<sbyte, MapBlockData>();
		BlockNameDataMap = new Dictionary<sbyte, FullBlockName>();
		BookLocationMap = new Dictionary<sbyte, Location>();
		BookDurationMap = new Dictionary<sbyte, int>();
		CharacterMap = new Dictionary<int, LegendaryBookCharacterRelatedData>();
		OwnerMap = new Dictionary<sbyte, int>();
		ContestList = new List<int>();
		ShockedList = new List<int>();
		InsaneList = new List<int>();
		ConsumedList = new List<int>();
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 0;
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(BlockDataMap);
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(BlockNameDataMap);
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(BookLocationMap);
		totalSize += SerializationHelper.DictionaryOfBasicTypePair.GetSerializedSize(BookDurationMap);
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(CharacterMap);
		totalSize += SerializationHelper.DictionaryOfBasicTypePair.GetSerializedSize(OwnerMap);
		totalSize = ((ContestList == null) ? (totalSize + 2) : (totalSize + (2 + 4 * ContestList.Count)));
		totalSize = ((ShockedList == null) ? (totalSize + 2) : (totalSize + (2 + 4 * ShockedList.Count)));
		totalSize = ((InsaneList == null) ? (totalSize + 2) : (totalSize + (2 + 4 * InsaneList.Count)));
		totalSize = ((ConsumedList == null) ? (totalSize + 2) : (totalSize + (2 + 4 * ConsumedList.Count)));
		totalSize = ((PreviousOwner == null) ? (totalSize + 2) : (totalSize + (2 + 4 * PreviousOwner.Count)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(pCurrData, ref BlockDataMap);
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(pCurrData, ref BlockNameDataMap);
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(pCurrData, ref BookLocationMap);
		pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Serialize(pCurrData, ref BookDurationMap);
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(pCurrData, ref CharacterMap);
		pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Serialize(pCurrData, ref OwnerMap);
		if (ContestList != null)
		{
			int elementsCount = ContestList.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				((int*)pCurrData)[i] = ContestList[i];
			}
			pCurrData += 4 * elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (ShockedList != null)
		{
			int elementsCount2 = ShockedList.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				((int*)pCurrData)[j] = ShockedList[j];
			}
			pCurrData += 4 * elementsCount2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (InsaneList != null)
		{
			int elementsCount3 = InsaneList.Count;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				((int*)pCurrData)[k] = InsaneList[k];
			}
			pCurrData += 4 * elementsCount3;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (ConsumedList != null)
		{
			int elementsCount4 = ConsumedList.Count;
			Tester.Assert(elementsCount4 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount4;
			pCurrData += 2;
			for (int l = 0; l < elementsCount4; l++)
			{
				((int*)pCurrData)[l] = ConsumedList[l];
			}
			pCurrData += 4 * elementsCount4;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (PreviousOwner != null)
		{
			int elementsCount5 = PreviousOwner.Count;
			Tester.Assert(elementsCount5 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount5;
			pCurrData += 2;
			for (int m = 0; m < elementsCount5; m++)
			{
				((int*)pCurrData)[m] = PreviousOwner[m];
			}
			pCurrData += 4 * elementsCount5;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref BlockDataMap);
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref BlockNameDataMap);
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref BookLocationMap);
		pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Deserialize(pCurrData, ref BookDurationMap);
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref CharacterMap);
		pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Deserialize(pCurrData, ref OwnerMap);
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (ContestList == null)
			{
				ContestList = new List<int>(elementsCount);
			}
			else
			{
				ContestList.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				ContestList.Add(((int*)pCurrData)[i]);
			}
			pCurrData += 4 * elementsCount;
		}
		else
		{
			ContestList?.Clear();
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (ShockedList == null)
			{
				ShockedList = new List<int>(elementsCount2);
			}
			else
			{
				ShockedList.Clear();
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				ShockedList.Add(((int*)pCurrData)[j]);
			}
			pCurrData += 4 * elementsCount2;
		}
		else
		{
			ShockedList?.Clear();
		}
		ushort elementsCount3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount3 > 0)
		{
			if (InsaneList == null)
			{
				InsaneList = new List<int>(elementsCount3);
			}
			else
			{
				InsaneList.Clear();
			}
			for (int k = 0; k < elementsCount3; k++)
			{
				InsaneList.Add(((int*)pCurrData)[k]);
			}
			pCurrData += 4 * elementsCount3;
		}
		else
		{
			InsaneList?.Clear();
		}
		ushort elementsCount4 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount4 > 0)
		{
			if (ConsumedList == null)
			{
				ConsumedList = new List<int>(elementsCount4);
			}
			else
			{
				ConsumedList.Clear();
			}
			for (int l = 0; l < elementsCount4; l++)
			{
				ConsumedList.Add(((int*)pCurrData)[l]);
			}
			pCurrData += 4 * elementsCount4;
		}
		else
		{
			ConsumedList?.Clear();
		}
		ushort elementsCount5 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount5 > 0)
		{
			if (PreviousOwner == null)
			{
				PreviousOwner = new List<int>(elementsCount5);
			}
			else
			{
				PreviousOwner.Clear();
			}
			for (int m = 0; m < elementsCount5; m++)
			{
				PreviousOwner.Add(((int*)pCurrData)[m]);
			}
			pCurrData += 4 * elementsCount5;
		}
		else
		{
			PreviousOwner?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
