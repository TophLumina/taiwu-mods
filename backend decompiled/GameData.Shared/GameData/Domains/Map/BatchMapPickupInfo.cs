using GameData.Serializer;

namespace GameData.Domains.Map;

/// <summary>
/// 挖掘道具结果
/// </summary>
[SerializableGameData(NotForArchive = true)]
public struct BatchMapPickupInfo : ISerializableGameData
{
	/// <summary>
	/// 地点
	/// </summary>
	[SerializableGameDataField]
	public Location Location = Location.Invalid;

	/// <summary>
	/// 是否拾取所有
	/// </summary>
	[SerializableGameDataField]
	public bool PickAll = false;

	/// <summary>
	/// 要拾取的Pickup的Index
	/// </summary>
	[SerializableGameDataField]
	public int PickupIndex = -1;

	/// <summary>
	/// 默认构造方法，将数量与结构都设为无效值
	/// </summary>
	public BatchMapPickupInfo()
	{
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 9;
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
		pCurrData += Location.Serialize(pCurrData);
		*pCurrData = (PickAll ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(int*)pCurrData = PickupIndex;
		pCurrData += 4;
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
		pCurrData += Location.Deserialize(pCurrData);
		PickAll = *pCurrData != 0;
		pCurrData++;
		PickupIndex = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
