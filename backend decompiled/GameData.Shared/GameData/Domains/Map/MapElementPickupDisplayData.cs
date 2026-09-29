using GameData.Domains.Item;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Map;

[SerializableGameData(NotForArchive = true, NoCopyConstructors = true)]
public class MapElementPickupDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public MapPickup Pickup;

	[SerializableGameDataField]
	public uint BanReason;

	[SerializableGameDataField]
	public bool CanAutoBeatXiangshuMinion;

	[SerializableGameDataField]
	public short TaiwuLoopingNeigong;

	[SerializableGameDataField]
	public ItemKey TaiwuReadingBookKey;

	public bool CanAutoTrigger()
	{
		return BanReason == 0;
	}

	public bool NeedBattle()
	{
		if (Pickup.HasXiangshuMinion)
		{
			return !CanAutoBeatXiangshuMinion;
		}
		return false;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 15;
		totalSize = ((Pickup == null) ? (totalSize + 2) : (totalSize + (2 + Pickup.GetSerializedSize())));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (Pickup != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = Pickup.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(uint*)pCurrData = BanReason;
		pCurrData += 4;
		*pCurrData = (CanAutoBeatXiangshuMinion ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(short*)pCurrData = TaiwuLoopingNeigong;
		pCurrData += 2;
		pCurrData += TaiwuReadingBookKey.Serialize(pCurrData);
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
			if (Pickup == null)
			{
				Pickup = new MapPickup();
			}
			pCurrData += Pickup.Deserialize(pCurrData);
		}
		else
		{
			Pickup = null;
		}
		BanReason = *(uint*)pCurrData;
		pCurrData += 4;
		CanAutoBeatXiangshuMinion = *pCurrData != 0;
		pCurrData++;
		TaiwuLoopingNeigong = *(short*)pCurrData;
		pCurrData += 2;
		pCurrData += TaiwuReadingBookKey.Deserialize(pCurrData);
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
