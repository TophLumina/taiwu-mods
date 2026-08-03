using GameData.Serializer;

namespace GameData.Domains.Combat;

/// <summary>
/// 变招显示数据
/// </summary>
[SerializableGameData(NotForArchive = true)]
public struct ChangeTrickDisplayData : ISerializableGameData
{
	/// <summary>
	/// 可以进行变招
	/// </summary>
	[SerializableGameDataField]
	public bool CanChangeTrick;

	/// <summary>
	/// 消耗变招次数
	/// </summary>
	[SerializableGameDataField]
	public sbyte CostCount;

	/// <summary>
	/// 变招倍率
	/// </summary>
	[SerializableGameDataField]
	public short AddHitRate;

	/// <summary>
	/// 招架值消耗倍率
	/// </summary>
	[SerializableGameDataField]
	public short AddBreakBlock;

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 6;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		*pData = (CanChangeTrick ? ((byte)1) : ((byte)0));
		byte* num = pData + 1;
		*num = (byte)CostCount;
		byte* num2 = num + 1;
		*(short*)num2 = AddHitRate;
		byte* num3 = num2 + 2;
		*(short*)num3 = AddBreakBlock;
		int totalSize = (int)(num3 + 2 - pData);
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
		CanChangeTrick = *pCurrData != 0;
		pCurrData++;
		CostCount = (sbyte)(*pCurrData);
		pCurrData++;
		AddHitRate = *(short*)pCurrData;
		pCurrData += 2;
		AddBreakBlock = *(short*)pCurrData;
		pCurrData += 2;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
