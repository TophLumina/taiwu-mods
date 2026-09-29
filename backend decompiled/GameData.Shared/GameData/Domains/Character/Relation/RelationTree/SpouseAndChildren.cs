using System.Collections.Generic;
using System.Linq;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Character.Relation.RelationTree;

[AutoGenerateSerializableGameData(IsExtensible = true, NoCopyConstructors = true, NotRestrictCollectionSerializedSize = true)]
public class SpouseAndChildren : ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort SpouseCharId = 0;

		public const ushort Children = 1;

		public const ushort BloodChildrenSpouses = 2;

		public const ushort Count = 3;

		public static readonly string[] FieldId2FieldName = new string[3] { "SpouseCharId", "Children", "BloodChildrenSpouses" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public int SpouseCharId;

	[SerializableGameDataField(FieldIndex = 1, CollectionMaxElementsCount = int.MaxValue)]
	public List<CharIdAndRelation> Children;

	[SerializableGameDataField(FieldIndex = 2, CollectionMaxElementsCount = int.MaxValue)]
	public List<SpousesAndChildren> BloodChildrenSpouses;

	public SpouseAndChildren()
	{
		SpouseCharId = -1;
	}

	public SpouseAndChildren(SpouseAndChildrenObsoleted obsoleted)
	{
		SpouseCharId = obsoleted.SpouseCharId;
		Children = obsoleted.Children?.ToList();
		BloodChildrenSpouses = obsoleted.BloodChildrenSpouses?.Select((SpousesAndChildrenObsoleted u) => new SpousesAndChildren
		{
			CoreCharId = u.CoreCharId,
			Spouses = u.Spouses?.Select((SpouseAndChildrenObsoleted obsoleted2) => new SpouseAndChildren(obsoleted2)).ToList()
		}).ToList();
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 6;
		totalSize = ((Children == null) ? (totalSize + 4) : (totalSize + (4 + 8 * Children.Count)));
		if (BloodChildrenSpouses != null)
		{
			totalSize += 4;
			for (int i = 0; i < BloodChildrenSpouses.Count; i++)
			{
				totalSize = ((BloodChildrenSpouses[i] == null) ? (totalSize + 2) : (totalSize + (2 + BloodChildrenSpouses[i].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 4;
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
		*(short*)pCurrData = 3;
		pCurrData += 2;
		*(int*)pCurrData = SpouseCharId;
		pCurrData += 4;
		if (Children != null)
		{
			int elementsCount = Children.Count;
			Tester.Assert(elementsCount <= int.MaxValue);
			*(int*)pCurrData = elementsCount;
			pCurrData += 4;
			for (int i = 0; i < elementsCount; i++)
			{
				pCurrData += Children[i].Serialize(pCurrData);
			}
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		if (BloodChildrenSpouses != null)
		{
			int elementsCount2 = BloodChildrenSpouses.Count;
			Tester.Assert(elementsCount2 <= int.MaxValue);
			*(int*)pCurrData = elementsCount2;
			pCurrData += 4;
			for (int j = 0; j < elementsCount2; j++)
			{
				if (BloodChildrenSpouses[j] != null)
				{
					byte* intPtr = pCurrData;
					pCurrData += 2;
					int fieldSize = BloodChildrenSpouses[j].Serialize(pCurrData);
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
			SpouseCharId = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 1)
		{
			int elementsCount = *(int*)pCurrData;
			pCurrData += 4;
			if (elementsCount > 0)
			{
				if (Children == null)
				{
					Children = new List<CharIdAndRelation>();
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
		}
		if (fieldCount > 2)
		{
			int elementsCount2 = *(int*)pCurrData;
			pCurrData += 4;
			if (elementsCount2 > 0)
			{
				if (BloodChildrenSpouses == null)
				{
					BloodChildrenSpouses = new List<SpousesAndChildren>();
				}
				else
				{
					BloodChildrenSpouses.Clear();
				}
				for (int j = 0; j < elementsCount2; j++)
				{
					ushort num = *(ushort*)pCurrData;
					pCurrData += 2;
					SpousesAndChildren element2;
					if (num > 0)
					{
						element2 = new SpousesAndChildren();
						pCurrData += element2.Deserialize(pCurrData);
					}
					else
					{
						element2 = null;
					}
					BloodChildrenSpouses.Add(element2);
				}
			}
			else
			{
				BloodChildrenSpouses?.Clear();
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
