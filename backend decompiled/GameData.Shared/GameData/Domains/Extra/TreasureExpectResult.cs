using GameData.Domains.Map;
using GameData.Serializer;

namespace GameData.Domains.Extra;

/// <summary>
/// 挖掘期望结果
/// </summary>
[SerializableGameData(NotForArchive = true)]
public struct TreasureExpectResult : ISerializableGameData
{
	/// <summary>
	/// 最高品级
	/// </summary>
	[SerializableGameDataField]
	public sbyte MaxGrade;

	/// <summary>
	/// 获取概率
	/// </summary>
	[SerializableGameDataField]
	public int Chance;

	/// <summary>
	/// 数据坐标
	/// </summary>
	[SerializableGameDataField]
	public Location Location;

	/// <summary>
	/// 当前地格存在心材
	/// </summary>
	[SerializableGameDataField]
	public bool AnyMaterial;

	/// <summary>
	/// 当前地格存在普通道具（排除龙鳞，蛟卵）
	/// </summary>
	[SerializableGameDataField]
	public bool AnyNormalItem;

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 11;
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
		*pCurrData = (byte)MaxGrade;
		pCurrData++;
		*(int*)pCurrData = Chance;
		pCurrData += 4;
		pCurrData += Location.Serialize(pCurrData);
		*pCurrData = (AnyMaterial ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (AnyNormalItem ? ((byte)1) : ((byte)0));
		pCurrData++;
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
		MaxGrade = (sbyte)(*pCurrData);
		pCurrData++;
		Chance = *(int*)pCurrData;
		pCurrData += 4;
		pCurrData += Location.Deserialize(pCurrData);
		AnyMaterial = *pCurrData != 0;
		pCurrData++;
		AnyNormalItem = *pCurrData != 0;
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
