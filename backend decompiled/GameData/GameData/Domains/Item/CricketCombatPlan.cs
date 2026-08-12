using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Item;

[SerializableGameData(IsExtensible = true, NotForDisplayModule = true)]
public class CricketCombatPlan : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort Crickets = 0;

		public const ushort Count = 1;

		public static readonly string[] FieldId2FieldName = new string[1] { "Crickets" };
	}

	[SerializableGameDataField]
	public List<ItemKey> Crickets;

	public CricketCombatPlan()
	{
	}

	public CricketCombatPlan(CricketCombatPlan other)
	{
		Crickets = ((other.Crickets == null) ? null : new List<ItemKey>(other.Crickets));
	}

	public void Assign(CricketCombatPlan other)
	{
		Crickets = ((other.Crickets == null) ? null : new List<ItemKey>(other.Crickets));
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 2;
		totalSize = ((Crickets == null) ? (totalSize + 2) : (totalSize + (2 + 8 * Crickets.Count)));
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 1;
		pCurrData += 2;
		if (Crickets != null)
		{
			int elementsCount = Crickets.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				pCurrData += Crickets[i].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort fieldCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (fieldCount > 0)
		{
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				if (Crickets == null)
				{
					Crickets = new List<ItemKey>(elementsCount);
				}
				else
				{
					Crickets.Clear();
				}
				for (int i = 0; i < elementsCount; i++)
				{
					ItemKey element = default(ItemKey);
					pCurrData += element.Deserialize(pCurrData);
					Crickets.Add(element);
				}
			}
			else
			{
				Crickets?.Clear();
			}
		}
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}
}
