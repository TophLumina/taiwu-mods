using System.Collections.Generic;
using GameData.Combat.Chicken;
using GameData.Serializer;

namespace GameData.Domains.Combat.Chicken;

[SerializeFrom(typeof(ChickenPointZones))]
[SerializableGameData(NotForArchive = true, NoCopyConstructors = true)]
public struct ChickenPointZonesDto : ISerializableGameData
{
	private ChickenPointZones _internalValue;

	public static explicit operator ChickenPointZonesDto(ChickenPointZones zones)
	{
		return new ChickenPointZonesDto
		{
			_internalValue = zones
		};
	}

	public static explicit operator ChickenPointZones(ChickenPointZonesDto dto)
	{
		return dto._internalValue ?? new ChickenPointZones();
	}

	private static int GetZoneSize(List<ChickenPointRuntime> zone)
	{
		if (zone == null)
		{
			return 4;
		}
		return 4 + zone.Count * default(ChickenPointDto).GetSerializedSize();
	}

	private unsafe static int SerializeZone(byte* pData, List<ChickenPointRuntime> zone)
	{
		byte* pCurrData = pData;
		if (zone == null)
		{
			*(int*)pCurrData = 0;
			return 4;
		}
		*(int*)pCurrData = zone.Count;
		pCurrData += 4;
		foreach (ChickenPointRuntime point in zone)
		{
			pCurrData += ((ChickenPointDto)point).Serialize(pCurrData);
		}
		return (int)(pCurrData - pData);
	}

	private unsafe static int DeserializeZone(byte* pData, List<ChickenPointRuntime> zone)
	{
		byte* pCurrData = pData;
		int count = *(int*)pCurrData;
		pCurrData += 4;
		zone.Clear();
		for (int i = 0; i < count; i++)
		{
			ChickenPointDto point = default(ChickenPointDto);
			pCurrData += point.Deserialize(pCurrData);
			zone.Add((ChickenPointRuntime)point);
		}
		return (int)(pCurrData - pData);
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		ChickenPointZones zones = _internalValue;
		if (zones == null)
		{
			return 12;
		}
		return GetZoneSize(zones.Pending) + GetZoneSize(zones.Current) + GetZoneSize(zones.Discard);
	}

	public unsafe int Serialize(byte* pData)
	{
		ChickenPointZones zones = _internalValue;
		byte* num = pData + SerializeZone(pData, zones?.Pending);
		byte* num2 = num + SerializeZone(num, zones?.Current);
		return (int)(num2 + SerializeZone(num2, zones?.Discard) - pData);
	}

	public unsafe int Deserialize(byte* pData)
	{
		if (_internalValue == null)
		{
			_internalValue = new ChickenPointZones();
		}
		byte* num = pData + DeserializeZone(pData, _internalValue.Pending);
		byte* num2 = num + DeserializeZone(num, _internalValue.Current);
		return (int)(num2 + DeserializeZone(num2, _internalValue.Discard) - pData);
	}
}
