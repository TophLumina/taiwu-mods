using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Map;

/// <summary>
/// 地格筛选查找数据
/// </summary>
[AutoGenerateSerializableGameData(IsExtensible = true, NoCopyConstructors = true)]
public class MapBlockFindData : ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort MultiSelectData = 0;

		public const ushort SingleSelectData = 1;

		public const ushort SingleSliderData = 2;

		public const ushort RangeSliderData = 3;

		public const ushort ToggleSliderData = 4;

		public const ushort Count = 5;

		public static readonly string[] FieldId2FieldName = new string[5] { "MultiSelectData", "SingleSelectData", "SingleSliderData", "RangeSliderData", "ToggleSliderData" };
	}

	/// <summary>
	/// 方案数量上限
	/// </summary>
	public const int PresetCount = 10;

	[SerializableGameDataField(FieldIndex = 0)]
	public Dictionary<EFilterItemKey, IntList> MultiSelectData;

	[SerializableGameDataField(FieldIndex = 1)]
	public Dictionary<EFilterItemKey, int> SingleSelectData;

	[SerializableGameDataField(FieldIndex = 2)]
	public Dictionary<EFilterItemKey, int> SingleSliderData;

	[SerializableGameDataField(FieldIndex = 3)]
	public Dictionary<EFilterItemKey, IntPair> RangeSliderData;

	[SerializableGameDataField(FieldIndex = 4)]
	public Dictionary<EFilterItemKey, ToggleSliderValue> ToggleSliderData;

	/// <summary>
	/// 获取控件数据数量
	/// </summary>
	public int TotalDataCount => MultiSelectData.Count + SingleSelectData.Count + SingleSliderData.Count + RangeSliderData.Count + ToggleSliderData.Count;

	public MapBlockFindData()
	{
		MultiSelectData = new Dictionary<EFilterItemKey, IntList>();
		SingleSelectData = new Dictionary<EFilterItemKey, int>();
		SingleSliderData = new Dictionary<EFilterItemKey, int>();
		RangeSliderData = new Dictionary<EFilterItemKey, IntPair>();
		ToggleSliderData = new Dictionary<EFilterItemKey, ToggleSliderValue>();
	}

	/// <summary>
	/// 清空所有筛选数据
	/// </summary>
	public void Clear()
	{
		MultiSelectData.Clear();
		SingleSelectData.Clear();
		SingleSliderData.Clear();
		RangeSliderData.Clear();
		ToggleSliderData.Clear();
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 2;
		totalSize += 4;
		if (MultiSelectData != null)
		{
			foreach (KeyValuePair<EFilterItemKey, IntList> pair in MultiSelectData)
			{
				totalSize++;
				totalSize += pair.Value.GetSerializedSize();
			}
		}
		totalSize += 4;
		if (SingleSelectData != null)
		{
			foreach (KeyValuePair<EFilterItemKey, int> singleSelectDatum in SingleSelectData)
			{
				_ = singleSelectDatum;
				totalSize++;
				totalSize += 4;
			}
		}
		totalSize += 4;
		if (SingleSliderData != null)
		{
			foreach (KeyValuePair<EFilterItemKey, int> singleSliderDatum in SingleSliderData)
			{
				_ = singleSliderDatum;
				totalSize++;
				totalSize += 4;
			}
		}
		totalSize += 4;
		if (RangeSliderData != null)
		{
			foreach (KeyValuePair<EFilterItemKey, IntPair> pair2 in RangeSliderData)
			{
				totalSize++;
				totalSize += pair2.Value.GetSerializedSize();
			}
		}
		totalSize += 4;
		if (ToggleSliderData != null)
		{
			foreach (KeyValuePair<EFilterItemKey, ToggleSliderValue> pair3 in ToggleSliderData)
			{
				totalSize++;
				totalSize += pair3.Value.GetSerializedSize();
			}
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
		*(short*)pCurrData = 5;
		pCurrData += 2;
		if (MultiSelectData != null)
		{
			*(int*)pCurrData = MultiSelectData.Count;
			pCurrData += 4;
			foreach (KeyValuePair<EFilterItemKey, IntList> pair in MultiSelectData)
			{
				*pCurrData = (byte)pair.Key;
				pCurrData++;
				pCurrData += pair.Value.Serialize(pCurrData);
			}
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		if (SingleSelectData != null)
		{
			*(int*)pCurrData = SingleSelectData.Count;
			pCurrData += 4;
			foreach (KeyValuePair<EFilterItemKey, int> pair2 in SingleSelectData)
			{
				*pCurrData = (byte)pair2.Key;
				pCurrData++;
				*(int*)pCurrData = pair2.Value;
				pCurrData += 4;
			}
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		if (SingleSliderData != null)
		{
			*(int*)pCurrData = SingleSliderData.Count;
			pCurrData += 4;
			foreach (KeyValuePair<EFilterItemKey, int> pair3 in SingleSliderData)
			{
				*pCurrData = (byte)pair3.Key;
				pCurrData++;
				*(int*)pCurrData = pair3.Value;
				pCurrData += 4;
			}
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		if (RangeSliderData != null)
		{
			*(int*)pCurrData = RangeSliderData.Count;
			pCurrData += 4;
			foreach (KeyValuePair<EFilterItemKey, IntPair> pair4 in RangeSliderData)
			{
				*pCurrData = (byte)pair4.Key;
				pCurrData++;
				pCurrData += pair4.Value.Serialize(pCurrData);
			}
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		if (ToggleSliderData != null)
		{
			*(int*)pCurrData = ToggleSliderData.Count;
			pCurrData += 4;
			foreach (KeyValuePair<EFilterItemKey, ToggleSliderValue> pair5 in ToggleSliderData)
			{
				*pCurrData = (byte)pair5.Key;
				pCurrData++;
				pCurrData += pair5.Value.Serialize(pCurrData);
			}
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
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
		ushort fieldCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (fieldCount > 0)
		{
			int MultiSelectDataElementsCount = *(int*)pCurrData;
			pCurrData += 4;
			if (MultiSelectDataElementsCount > 0)
			{
				if (MultiSelectData == null)
				{
					MultiSelectData = new Dictionary<EFilterItemKey, IntList>();
				}
				else
				{
					MultiSelectData.Clear();
				}
				for (int i = 0; i < MultiSelectDataElementsCount; i++)
				{
					EFilterItemKey key = (EFilterItemKey)(*pCurrData);
					pCurrData++;
					IntList value = default(IntList);
					pCurrData += value.Deserialize(pCurrData);
					MultiSelectData.Add(key, value);
				}
			}
			else
			{
				MultiSelectData?.Clear();
			}
		}
		if (fieldCount > 1)
		{
			int SingleSelectDataElementsCount = *(int*)pCurrData;
			pCurrData += 4;
			if (SingleSelectDataElementsCount > 0)
			{
				if (SingleSelectData == null)
				{
					SingleSelectData = new Dictionary<EFilterItemKey, int>();
				}
				else
				{
					SingleSelectData.Clear();
				}
				for (int j = 0; j < SingleSelectDataElementsCount; j++)
				{
					EFilterItemKey key2 = (EFilterItemKey)(*pCurrData);
					pCurrData++;
					int value2 = *(int*)pCurrData;
					pCurrData += 4;
					SingleSelectData.Add(key2, value2);
				}
			}
			else
			{
				SingleSelectData?.Clear();
			}
		}
		if (fieldCount > 2)
		{
			int SingleSliderDataElementsCount = *(int*)pCurrData;
			pCurrData += 4;
			if (SingleSliderDataElementsCount > 0)
			{
				if (SingleSliderData == null)
				{
					SingleSliderData = new Dictionary<EFilterItemKey, int>();
				}
				else
				{
					SingleSliderData.Clear();
				}
				for (int k = 0; k < SingleSliderDataElementsCount; k++)
				{
					EFilterItemKey key3 = (EFilterItemKey)(*pCurrData);
					pCurrData++;
					int value3 = *(int*)pCurrData;
					pCurrData += 4;
					SingleSliderData.Add(key3, value3);
				}
			}
			else
			{
				SingleSliderData?.Clear();
			}
		}
		if (fieldCount > 3)
		{
			int RangeSliderDataElementsCount = *(int*)pCurrData;
			pCurrData += 4;
			if (RangeSliderDataElementsCount > 0)
			{
				if (RangeSliderData == null)
				{
					RangeSliderData = new Dictionary<EFilterItemKey, IntPair>();
				}
				else
				{
					RangeSliderData.Clear();
				}
				for (int l = 0; l < RangeSliderDataElementsCount; l++)
				{
					EFilterItemKey key4 = (EFilterItemKey)(*pCurrData);
					pCurrData++;
					IntPair value4 = default(IntPair);
					pCurrData += value4.Deserialize(pCurrData);
					RangeSliderData.Add(key4, value4);
				}
			}
			else
			{
				RangeSliderData?.Clear();
			}
		}
		if (fieldCount > 4)
		{
			int ToggleSliderDataElementsCount = *(int*)pCurrData;
			pCurrData += 4;
			if (ToggleSliderDataElementsCount > 0)
			{
				if (ToggleSliderData == null)
				{
					ToggleSliderData = new Dictionary<EFilterItemKey, ToggleSliderValue>();
				}
				else
				{
					ToggleSliderData.Clear();
				}
				for (int m = 0; m < ToggleSliderDataElementsCount; m++)
				{
					EFilterItemKey key5 = (EFilterItemKey)(*pCurrData);
					pCurrData++;
					ToggleSliderValue value5 = default(ToggleSliderValue);
					pCurrData += value5.Deserialize(pCurrData);
					ToggleSliderData.Add(key5, value5);
				}
			}
			else
			{
				ToggleSliderData?.Clear();
			}
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
