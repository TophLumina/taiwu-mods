using System;
using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Character.Relation.RelationTree;

/// <summary>
/// 配偶及子女
/// </summary>
[Obsolete]
[SerializableGameData(NotForDisplayModule = true)]
public class SpouseAndChildrenObsoleted : ISerializableGameData
{
	/// <summary>
	/// 核心角色的配偶.
	/// 为 -1 表示配偶不存在但有子女. 比如自己未婚时认的义亲子女, 轮回台感应生下的孩子.
	/// </summary>
	[SerializableGameDataField]
	public int SpouseCharId;

	/// <summary>
	/// "和核心角色共同的血亲子女" + "核心角色的继亲子女, 配偶的血亲子女或继亲子女" + "和核心角色共同的义亲子女" (需要排序)
	/// </summary>
	[SerializableGameDataField]
	public List<CharIdAndRelation> Children;

	/// <summary>
	/// "和核心角色共同的血亲子女" 的配偶及子女 (不需要排序).
	/// 到孙辈时此数据固定为空.
	/// </summary>
	[SerializableGameDataField]
	public List<SpousesAndChildrenObsoleted> BloodChildrenSpouses;

	/// <summary>
	/// 配偶及子女
	/// </summary>
	public SpouseAndChildrenObsoleted()
	{
		SpouseCharId = -1;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 4;
		totalSize = ((Children == null) ? (totalSize + 2) : (totalSize + (2 + 8 * Children.Count)));
		if (BloodChildrenSpouses != null)
		{
			totalSize += 2;
			int elementsCount = BloodChildrenSpouses.Count;
			for (int i = 0; i < elementsCount; i++)
			{
				SpousesAndChildrenObsoleted element = BloodChildrenSpouses[i];
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
		*(int*)pCurrData = SpouseCharId;
		pCurrData += 4;
		if (Children != null)
		{
			int elementsCount = Children.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				pCurrData += Children[i].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (BloodChildrenSpouses != null)
		{
			int elementsCount2 = BloodChildrenSpouses.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				SpousesAndChildrenObsoleted element = BloodChildrenSpouses[j];
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
		SpouseCharId = *(int*)pCurrData;
		pCurrData += 4;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (Children == null)
			{
				Children = new List<CharIdAndRelation>(elementsCount);
			}
			else
			{
				Children.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				CharIdAndRelation element = default(CharIdAndRelation);
				pCurrData += element.Deserialize(pCurrData);
				Children.Add(element);
			}
		}
		else
		{
			Children?.Clear();
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (BloodChildrenSpouses == null)
			{
				BloodChildrenSpouses = new List<SpousesAndChildrenObsoleted>(elementsCount2);
			}
			else
			{
				BloodChildrenSpouses.Clear();
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				ushort num = *(ushort*)pCurrData;
				pCurrData += 2;
				if (num > 0)
				{
					SpousesAndChildrenObsoleted element2 = new SpousesAndChildrenObsoleted();
					pCurrData += element2.Deserialize(pCurrData);
					BloodChildrenSpouses.Add(element2);
				}
				else
				{
					BloodChildrenSpouses.Add(null);
				}
			}
		}
		else
		{
			BloodChildrenSpouses?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
