using GameData.Domains.Item;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Map;

/// <summary>
/// 单个拾取物显示数据
/// </summary>
[SerializableGameData(NotForArchive = true, NoCopyConstructors = true)]
public class MapElementPickupDisplayData : ISerializableGameData
{
	/// <summary>
	/// 拾取物本身
	/// </summary>
	[SerializableGameDataField]
	public MapPickup Pickup;

	/// <summary>
	/// 禁用的原因，使用BoolArray32转换
	/// </summary>
	[SerializableGameDataField]
	public uint BanReason;

	/// <summary>
	/// 是否可以自动驱逐爪牙，对没有爪牙的拾取物无意义
	/// </summary>
	[SerializableGameDataField]
	public bool CanAutoBeatXiangshuMinion;

	/// <summary>
	/// 太吾正在运转的功法
	/// </summary>
	[SerializableGameDataField]
	public short TaiwuLoopingNeigong;

	/// <summary>
	/// 太吾正在读的书
	/// </summary>
	[SerializableGameDataField]
	public ItemKey TaiwuReadingBookKey;

	/// <summary>
	/// 是否可以自动触发
	/// </summary>
	public bool CanAutoTrigger()
	{
		return BanReason == 0;
	}

	/// <summary>
	/// 有一场战斗
	/// </summary>
	public bool NeedBattle()
	{
		if (Pickup.HasXiangshuMinion)
		{
			return !CanAutoBeatXiangshuMinion;
		}
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
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
