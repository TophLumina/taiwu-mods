using System;
using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Map;

[SerializableGameData(IsExtensible = true)]
public class BrokenAreaData : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort Level = 0;

		public const ushort RandomEnemies = 1;

		public const ushort Count = 2;

		public static readonly string[] FieldId2FieldName = new string[2] { "Level", "RandomEnemies" };
	}

	[SerializableGameDataField]
	public sbyte Level;

	[SerializableGameDataField]
	public List<MapTemplateEnemyInfo> RandomEnemies;

	public short BaseXiangshuMinionTemplateId => (short)Math.Clamp(366 + Level - 1, 366, 374);

	public BrokenAreaData()
	{
		RandomEnemies = new List<MapTemplateEnemyInfo>();
	}

	public BrokenAreaData(BrokenAreaData other)
	{
		Level = other.Level;
		RandomEnemies = ((other.RandomEnemies == null) ? null : new List<MapTemplateEnemyInfo>(other.RandomEnemies));
	}

	public void Assign(BrokenAreaData other)
	{
		Level = other.Level;
		RandomEnemies = ((other.RandomEnemies == null) ? null : new List<MapTemplateEnemyInfo>(other.RandomEnemies));
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 3;
		totalSize = ((RandomEnemies == null) ? (totalSize + 2) : (totalSize + (2 + 8 * RandomEnemies.Count)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 2;
		pCurrData += 2;
		*pCurrData = (byte)Level;
		pCurrData++;
		if (RandomEnemies != null)
		{
			int elementsCount = RandomEnemies.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				pCurrData += RandomEnemies[i].Serialize(pCurrData);
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
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			Level = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (num > 1)
		{
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				if (RandomEnemies == null)
				{
					RandomEnemies = new List<MapTemplateEnemyInfo>(elementsCount);
				}
				else
				{
					RandomEnemies.Clear();
				}
				for (int i = 0; i < elementsCount; i++)
				{
					MapTemplateEnemyInfo element = default(MapTemplateEnemyInfo);
					pCurrData += element.Deserialize(pCurrData);
					RandomEnemies.Add(element);
				}
			}
			else
			{
				RandomEnemies?.Clear();
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
