using System;
using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Character.Relation.RelationTree;

/// <summary>
/// 核心角色的多个配偶及子女
/// </summary>
[Obsolete]
[SerializableGameData(NotForDisplayModule = true)]
public class SpousesAndChildrenObsoleted : ISerializableGameData
{
	/// <summary>
	/// 核心角色
	/// </summary>
	[SerializableGameDataField]
	public int CoreCharId;

	/// <summary>
	/// 配偶及子女 (需要排序)
	/// </summary>
	[SerializableGameDataField]
	public List<SpouseAndChildrenObsoleted> Spouses;

	/// <summary>
	/// 角色的多个配偶及子女
	/// </summary>
	/// <param name="coreCharId"></param>
	/// <param name="spouses"></param>
	public SpousesAndChildrenObsoleted(int coreCharId, List<SpouseAndChildrenObsoleted> spouses)
	{
		CoreCharId = coreCharId;
		Spouses = spouses;
	}

	public SpousesAndChildrenObsoleted()
	{
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 4;
		if (Spouses != null)
		{
			totalSize += 2;
			int elementsCount = Spouses.Count;
			for (int i = 0; i < elementsCount; i++)
			{
				SpouseAndChildrenObsoleted element = Spouses[i];
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
		*(int*)pCurrData = CoreCharId;
		pCurrData += 4;
		if (Spouses != null)
		{
			int elementsCount = Spouses.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				SpouseAndChildrenObsoleted element = Spouses[i];
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
		CoreCharId = *(int*)pCurrData;
		pCurrData += 4;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (Spouses == null)
			{
				Spouses = new List<SpouseAndChildrenObsoleted>(elementsCount);
			}
			else
			{
				Spouses.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				ushort num = *(ushort*)pCurrData;
				pCurrData += 2;
				if (num > 0)
				{
					SpouseAndChildrenObsoleted element = new SpouseAndChildrenObsoleted();
					pCurrData += element.Deserialize(pCurrData);
					Spouses.Add(element);
				}
				else
				{
					Spouses.Add(null);
				}
			}
		}
		else
		{
			Spouses?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
