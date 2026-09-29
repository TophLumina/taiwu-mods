using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Character.Relation.RelationTree;

[AutoGenerateSerializableGameData(IsExtensible = true, NoCopyConstructors = true, NotRestrictCollectionSerializedSize = true)]
public class Genealogy : ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort CoreCharId = 0;

		public const ushort BloodFatherId = 1;

		public const ushort BloodMotherId = 2;

		public const ushort GrandfatherId = 3;

		public const ushort GrandmotherId = 4;

		public const ushort MaternalGrandfatherId = 5;

		public const ushort MaternalGrandmotherId = 6;

		public const ushort Parents = 7;

		public const ushort BrothersAndSisters = 8;

		public const ushort Spouses = 9;

		public const ushort Count = 10;

		public static readonly string[] FieldId2FieldName = new string[10] { "CoreCharId", "BloodFatherId", "BloodMotherId", "GrandfatherId", "GrandmotherId", "MaternalGrandfatherId", "MaternalGrandmotherId", "Parents", "BrothersAndSisters", "Spouses" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public int CoreCharId;

	[SerializableGameDataField(FieldIndex = 1)]
	public int BloodFatherId;

	[SerializableGameDataField(FieldIndex = 2)]
	public int BloodMotherId;

	[SerializableGameDataField(FieldIndex = 3)]
	public int GrandfatherId;

	[SerializableGameDataField(FieldIndex = 4)]
	public int GrandmotherId;

	[SerializableGameDataField(FieldIndex = 5)]
	public int MaternalGrandfatherId;

	[SerializableGameDataField(FieldIndex = 6)]
	public int MaternalGrandmotherId;

	[SerializableGameDataField(FieldIndex = 7, CollectionMaxElementsCount = int.MaxValue)]
	public List<CharIdAndRelation> Parents;

	[SerializableGameDataField(FieldIndex = 8, CollectionMaxElementsCount = int.MaxValue)]
	public List<CharIdAndRelation> BrothersAndSisters;

	[SerializableGameDataField(FieldIndex = 9, CollectionMaxElementsCount = int.MaxValue)]
	public List<SpouseAndChildren> Spouses;

	public Genealogy()
	{
		CoreCharId = -1;
		BloodFatherId = -1;
		BloodMotherId = -1;
		GrandfatherId = -1;
		GrandmotherId = -1;
		MaternalGrandfatherId = -1;
		MaternalGrandmotherId = -1;
		Parents = new List<CharIdAndRelation>();
		BrothersAndSisters = new List<CharIdAndRelation>();
		Spouses = new List<SpouseAndChildren>();
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 30;
		totalSize = ((Parents == null) ? (totalSize + 4) : (totalSize + (4 + 8 * Parents.Count)));
		totalSize = ((BrothersAndSisters == null) ? (totalSize + 4) : (totalSize + (4 + 8 * BrothersAndSisters.Count)));
		if (Spouses != null)
		{
			totalSize += 4;
			for (int i = 0; i < Spouses.Count; i++)
			{
				totalSize = ((Spouses[i] == null) ? (totalSize + 2) : (totalSize + (2 + Spouses[i].GetSerializedSize())));
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
		*(short*)pCurrData = 10;
		pCurrData += 2;
		*(int*)pCurrData = CoreCharId;
		pCurrData += 4;
		*(int*)pCurrData = BloodFatherId;
		pCurrData += 4;
		*(int*)pCurrData = BloodMotherId;
		pCurrData += 4;
		*(int*)pCurrData = GrandfatherId;
		pCurrData += 4;
		*(int*)pCurrData = GrandmotherId;
		pCurrData += 4;
		*(int*)pCurrData = MaternalGrandfatherId;
		pCurrData += 4;
		*(int*)pCurrData = MaternalGrandmotherId;
		pCurrData += 4;
		if (Parents != null)
		{
			int elementsCount = Parents.Count;
			Tester.Assert(elementsCount <= int.MaxValue);
			*(int*)pCurrData = elementsCount;
			pCurrData += 4;
			for (int i = 0; i < elementsCount; i++)
			{
				pCurrData += Parents[i].Serialize(pCurrData);
			}
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		if (BrothersAndSisters != null)
		{
			int elementsCount2 = BrothersAndSisters.Count;
			Tester.Assert(elementsCount2 <= int.MaxValue);
			*(int*)pCurrData = elementsCount2;
			pCurrData += 4;
			for (int j = 0; j < elementsCount2; j++)
			{
				pCurrData += BrothersAndSisters[j].Serialize(pCurrData);
			}
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		if (Spouses != null)
		{
			int elementsCount3 = Spouses.Count;
			Tester.Assert(elementsCount3 <= int.MaxValue);
			*(int*)pCurrData = elementsCount3;
			pCurrData += 4;
			for (int k = 0; k < elementsCount3; k++)
			{
				if (Spouses[k] != null)
				{
					byte* intPtr = pCurrData;
					pCurrData += 2;
					int fieldSize = Spouses[k].Serialize(pCurrData);
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
			CoreCharId = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 1)
		{
			BloodFatherId = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 2)
		{
			BloodMotherId = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 3)
		{
			GrandfatherId = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 4)
		{
			GrandmotherId = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 5)
		{
			MaternalGrandfatherId = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 6)
		{
			MaternalGrandmotherId = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 7)
		{
			int elementsCount = *(int*)pCurrData;
			pCurrData += 4;
			if (elementsCount > 0)
			{
				if (Parents == null)
				{
					Parents = new List<CharIdAndRelation>();
				}
				else
				{
					Parents.Clear();
				}
				for (int i = 0; i < elementsCount; i++)
				{
					CharIdAndRelation element = default(CharIdAndRelation);
					pCurrData += element.Deserialize(pCurrData);
					Parents.Add(element);
				}
			}
			else
			{
				Parents?.Clear();
			}
		}
		if (fieldCount > 8)
		{
			int elementsCount2 = *(int*)pCurrData;
			pCurrData += 4;
			if (elementsCount2 > 0)
			{
				if (BrothersAndSisters == null)
				{
					BrothersAndSisters = new List<CharIdAndRelation>();
				}
				else
				{
					BrothersAndSisters.Clear();
				}
				for (int j = 0; j < elementsCount2; j++)
				{
					CharIdAndRelation element2 = default(CharIdAndRelation);
					pCurrData += element2.Deserialize(pCurrData);
					BrothersAndSisters.Add(element2);
				}
			}
			else
			{
				BrothersAndSisters?.Clear();
			}
		}
		if (fieldCount > 9)
		{
			int elementsCount3 = *(int*)pCurrData;
			pCurrData += 4;
			if (elementsCount3 > 0)
			{
				if (Spouses == null)
				{
					Spouses = new List<SpouseAndChildren>();
				}
				else
				{
					Spouses.Clear();
				}
				for (int k = 0; k < elementsCount3; k++)
				{
					ushort num = *(ushort*)pCurrData;
					pCurrData += 2;
					SpouseAndChildren element3;
					if (num > 0)
					{
						element3 = new SpouseAndChildren();
						pCurrData += element3.Deserialize(pCurrData);
					}
					else
					{
						element3 = null;
					}
					Spouses.Add(element3);
				}
			}
			else
			{
				Spouses?.Clear();
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
