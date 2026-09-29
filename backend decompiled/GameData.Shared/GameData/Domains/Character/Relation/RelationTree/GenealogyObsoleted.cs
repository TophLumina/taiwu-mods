using System;
using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Character.Relation.RelationTree;

[Obsolete]
[SerializableGameData(NotForDisplayModule = true)]
public class GenealogyObsoleted : ISerializableGameData
{
	[SerializableGameDataField]
	public int CoreCharId;

	[SerializableGameDataField]
	public int BloodFatherId;

	[SerializableGameDataField]
	public int BloodMotherId;

	[SerializableGameDataField]
	public int GrandfatherId;

	[SerializableGameDataField]
	public int GrandmotherId;

	[SerializableGameDataField]
	public int MaternalGrandfatherId;

	[SerializableGameDataField]
	public int MaternalGrandmotherId;

	[SerializableGameDataField]
	public List<CharIdAndRelation> Parents;

	[SerializableGameDataField]
	public List<CharIdAndRelation> BrothersAndSisters;

	[SerializableGameDataField]
	public List<SpouseAndChildrenObsoleted> Spouses;

	public GenealogyObsoleted()
	{
		CoreCharId = -1;
		BloodFatherId = -1;
		BloodMotherId = -1;
		GrandfatherId = -1;
		GrandmotherId = -1;
		MaternalGrandfatherId = -1;
		MaternalGrandmotherId = -1;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 28;
		totalSize = ((Parents == null) ? (totalSize + 2) : (totalSize + (2 + 8 * Parents.Count)));
		totalSize = ((BrothersAndSisters == null) ? (totalSize + 2) : (totalSize + (2 + 8 * BrothersAndSisters.Count)));
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
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				pCurrData += Parents[i].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (BrothersAndSisters != null)
		{
			int elementsCount2 = BrothersAndSisters.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				pCurrData += BrothersAndSisters[j].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (Spouses != null)
		{
			int elementsCount3 = Spouses.Count;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				SpouseAndChildrenObsoleted element = Spouses[k];
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
		BloodFatherId = *(int*)pCurrData;
		pCurrData += 4;
		BloodMotherId = *(int*)pCurrData;
		pCurrData += 4;
		GrandfatherId = *(int*)pCurrData;
		pCurrData += 4;
		GrandmotherId = *(int*)pCurrData;
		pCurrData += 4;
		MaternalGrandfatherId = *(int*)pCurrData;
		pCurrData += 4;
		MaternalGrandmotherId = *(int*)pCurrData;
		pCurrData += 4;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (Parents == null)
			{
				Parents = new List<CharIdAndRelation>(elementsCount);
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
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (BrothersAndSisters == null)
			{
				BrothersAndSisters = new List<CharIdAndRelation>(elementsCount2);
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
		ushort elementsCount3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount3 > 0)
		{
			if (Spouses == null)
			{
				Spouses = new List<SpouseAndChildrenObsoleted>(elementsCount3);
			}
			else
			{
				Spouses.Clear();
			}
			for (int k = 0; k < elementsCount3; k++)
			{
				ushort num = *(ushort*)pCurrData;
				pCurrData += 2;
				if (num > 0)
				{
					SpouseAndChildrenObsoleted element3 = new SpouseAndChildrenObsoleted();
					pCurrData += element3.Deserialize(pCurrData);
					Spouses.Add(element3);
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
