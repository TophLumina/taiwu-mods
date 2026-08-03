using System;
using System.Collections.Generic;
using GameData.Serializer;

namespace GameData.Domains.Information;

/// <summary>
/// 记录一个角色使用秘闻的次数
/// </summary>
[SerializableGameData(NotForDisplayModule = true)]
public class SecretInformationCharacterUsedCount : ISerializableGameData
{
	/// <summary>
	/// 秘闻使用次数集合
	/// K: 秘闻元数据 Id
	/// V: 秘闻使用次数
	/// </summary>
	[SerializableGameDataField]
	public readonly IDictionary<int, sbyte> UsedCounts;

	public SecretInformationCharacterUsedCount()
	{
		UsedCounts = new Dictionary<int, sbyte>();
	}

	public SecretInformationCharacterUsedCount(SecretInformationCharacterUsedCount other)
		: this()
	{
		Assign(other);
	}

	public void Assign(SecretInformationCharacterUsedCount other)
	{
		UsedCounts.Clear();
		foreach (KeyValuePair<int, sbyte> pair in other.UsedCounts)
		{
			UsedCounts.Add(pair.Key, pair.Value);
		}
	}

	/// <inheritdoc />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc />
	public int GetSerializedSize()
	{
		int totalSize = 0;
		totalSize = ((UsedCounts == null) ? (totalSize + 4) : (totalSize + (4 + 5 * UsedCounts.Count)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc />
	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (UsedCounts != null)
		{
			int elementsCount = UsedCounts.Count;
			*(int*)pCurrData = elementsCount;
			pCurrData += 4;
			foreach (KeyValuePair<int, sbyte> pair in UsedCounts)
			{
				*(int*)pCurrData = pair.Key;
				pCurrData += 4;
				*pCurrData = (byte)pair.Value;
				pCurrData++;
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

	/// <inheritdoc />
	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		uint elementsCount = *(uint*)pCurrData;
		pCurrData += 4;
		if (elementsCount != 0)
		{
			if (UsedCounts == null)
			{
				throw new NotImplementedException();
			}
			UsedCounts.Clear();
			for (int i = 0; i < elementsCount; i++)
			{
				int id = *(int*)pCurrData;
				pCurrData += 4;
				sbyte time = (sbyte)(*pCurrData);
				pCurrData++;
				UsedCounts.Add(id, time);
			}
		}
		else
		{
			UsedCounts?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
