using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Global;

[SerializableGameData(NotForArchive = true, NoCopyConstructors = true)]
public class MapPickupAutoTriggerSetting : ISerializableGameData
{
	[SerializableGameDataField]
	public bool IncludeXiangshuMinion;

	[SerializableGameDataField]
	public sbyte MinGrade;

	[SerializableGameDataField]
	public bool[] PickupTypes = new bool[14];

	public MapPickupAutoTriggerSetting()
	{
		IncludeXiangshuMinion = true;
		MinGrade = -1;
		PickupTypes = new bool[14];
		for (int i = 0; i < PickupTypes.Length; i++)
		{
			PickupTypes[i] = true;
		}
	}

	public MapPickupAutoTriggerSetting(bool includeXiangshuMinion, sbyte minGrade, int pickupTypeMask)
	{
		IncludeXiangshuMinion = includeXiangshuMinion;
		MinGrade = minGrade;
		PickupTypes = new bool[14];
		for (int i = 0; i < PickupTypes.Length; i++)
		{
			PickupTypes[i] = ((pickupTypeMask >> i) & 1) == 1;
		}
	}

	public int GetPickupTypeMask()
	{
		int mask = 0;
		for (int i = 0; i < PickupTypes.Length; i++)
		{
			if (PickupTypes[i])
			{
				mask |= 1 << i;
			}
		}
		return mask;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 2;
		totalSize = ((PickupTypes == null) ? (totalSize + 2) : (totalSize + (2 + PickupTypes.Length)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*pCurrData = (IncludeXiangshuMinion ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (byte)MinGrade;
		pCurrData++;
		if (PickupTypes != null)
		{
			int elementsCount = PickupTypes.Length;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				pCurrData[i] = (PickupTypes[i] ? ((byte)1) : ((byte)0));
			}
			pCurrData += elementsCount;
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
		IncludeXiangshuMinion = *pCurrData != 0;
		pCurrData++;
		MinGrade = (sbyte)(*pCurrData);
		pCurrData++;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (PickupTypes == null || PickupTypes.Length != elementsCount)
			{
				PickupTypes = new bool[elementsCount];
			}
			for (int i = 0; i < elementsCount; i++)
			{
				PickupTypes[i] = pCurrData[i] != 0;
			}
			pCurrData += (int)elementsCount;
		}
		else
		{
			PickupTypes = null;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
