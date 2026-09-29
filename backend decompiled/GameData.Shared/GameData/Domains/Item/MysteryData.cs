using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Item;

[SerializableGameData(IsExtensible = true)]
public class MysteryData : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort Compatibility = 0;

		public const ushort EffectIds = 1;

		public const ushort Count = 2;

		public static readonly string[] FieldId2FieldName = new string[2] { "Compatibility", "EffectIds" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public Dictionary<int, int> Compatibility;

	[SerializableGameDataField(FieldIndex = 1)]
	public List<long> EffectIds;

	public MysteryData()
	{
	}

	public MysteryData(MysteryData other)
	{
		Compatibility = ((other.Compatibility == null) ? null : new Dictionary<int, int>(other.Compatibility));
		EffectIds = ((other.EffectIds == null) ? null : new List<long>(other.EffectIds));
	}

	public void Assign(MysteryData other)
	{
		Compatibility = ((other.Compatibility == null) ? null : new Dictionary<int, int>(other.Compatibility));
		EffectIds = ((other.EffectIds == null) ? null : new List<long>(other.EffectIds));
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 2;
		totalSize += SerializationHelper.DictionaryOfBasicTypePair.GetSerializedSize(Compatibility);
		totalSize = ((EffectIds == null) ? (totalSize + 2) : (totalSize + (2 + 8 * EffectIds.Count)));
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
		pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Serialize(pCurrData, ref Compatibility);
		if (EffectIds != null)
		{
			int elementsCount = EffectIds.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				((long*)pCurrData)[i] = EffectIds[i];
			}
			pCurrData += 8 * elementsCount;
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
			pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Deserialize(pCurrData, ref Compatibility);
		}
		if (num > 1)
		{
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				if (EffectIds == null)
				{
					EffectIds = new List<long>(elementsCount);
				}
				else
				{
					EffectIds.Clear();
				}
				for (int i = 0; i < elementsCount; i++)
				{
					EffectIds.Add(((long*)pCurrData)[i]);
				}
				pCurrData += 8 * elementsCount;
			}
			else
			{
				EffectIds?.Clear();
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
