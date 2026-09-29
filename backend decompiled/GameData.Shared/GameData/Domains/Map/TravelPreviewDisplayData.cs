using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Map;

[SerializableGameData(NotForArchive = true)]
public class TravelPreviewDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public short ToAreaId;

	[SerializableGameDataField]
	public List<short> NeedUnlockStations;

	[SerializableGameDataField]
	public int AuthorityCost;

	[SerializableGameDataField]
	public int MoneyCost;

	[SerializableGameDataField]
	public int DaysCost;

	[SerializableGameDataField]
	public int CurrentAuthority;

	public TravelPreviewDisplayData()
	{
	}

	public TravelPreviewDisplayData(TravelPreviewDisplayData other)
	{
		ToAreaId = other.ToAreaId;
		NeedUnlockStations = ((other.NeedUnlockStations == null) ? null : new List<short>(other.NeedUnlockStations));
		AuthorityCost = other.AuthorityCost;
		MoneyCost = other.MoneyCost;
		DaysCost = other.DaysCost;
		CurrentAuthority = other.CurrentAuthority;
	}

	public void Assign(TravelPreviewDisplayData other)
	{
		ToAreaId = other.ToAreaId;
		NeedUnlockStations = ((other.NeedUnlockStations == null) ? null : new List<short>(other.NeedUnlockStations));
		AuthorityCost = other.AuthorityCost;
		MoneyCost = other.MoneyCost;
		DaysCost = other.DaysCost;
		CurrentAuthority = other.CurrentAuthority;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 18;
		totalSize = ((NeedUnlockStations == null) ? (totalSize + 2) : (totalSize + (2 + 2 * NeedUnlockStations.Count)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = ToAreaId;
		pCurrData += 2;
		if (NeedUnlockStations != null)
		{
			int elementsCount = NeedUnlockStations.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				((short*)pCurrData)[i] = NeedUnlockStations[i];
			}
			pCurrData += 2 * elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(int*)pCurrData = AuthorityCost;
		pCurrData += 4;
		*(int*)pCurrData = MoneyCost;
		pCurrData += 4;
		*(int*)pCurrData = DaysCost;
		pCurrData += 4;
		*(int*)pCurrData = CurrentAuthority;
		pCurrData += 4;
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
		ToAreaId = *(short*)pCurrData;
		pCurrData += 2;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (NeedUnlockStations == null)
			{
				NeedUnlockStations = new List<short>(elementsCount);
			}
			else
			{
				NeedUnlockStations.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				NeedUnlockStations.Add(((short*)pCurrData)[i]);
			}
			pCurrData += 2 * elementsCount;
		}
		else
		{
			NeedUnlockStations?.Clear();
		}
		AuthorityCost = *(int*)pCurrData;
		pCurrData += 4;
		MoneyCost = *(int*)pCurrData;
		pCurrData += 4;
		DaysCost = *(int*)pCurrData;
		pCurrData += 4;
		CurrentAuthority = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
