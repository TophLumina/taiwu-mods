using GameData.Serializer;

namespace GameData.Domains.Map;

/// <summary>
/// 梦回位置数据，一个位置对应一些额外属性
/// </summary>
[SerializableGameData(IsExtensible = true)]
public struct DreamBackLocationData : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort Location = 0;

		public const ushort InternalType = 1;

		public const ushort Count = 2;

		public static readonly string[] FieldId2FieldName = new string[2] { "Location", "InternalType" };
	}

	/// <summary>
	/// 梦回位置
	/// </summary>
	[SerializableGameDataField]
	public Location Location;

	/// <summary>
	/// 梦回类型，用于序列化
	/// </summary>
	[SerializableGameDataField]
	private sbyte _internalType;

	/// <summary>
	/// 梦回类型
	/// </summary>
	public EDreamBackLocationType Type => (EDreamBackLocationType)_internalType;

	/// <summary>
	/// 创建一个梦回位置数据
	/// </summary>
	public static DreamBackLocationData Create(Location location, EDreamBackLocationType locationType)
	{
		return new DreamBackLocationData
		{
			Location = location,
			_internalType = (sbyte)locationType
		};
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 7;
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
		*(short*)pCurrData = 2;
		pCurrData += 2;
		pCurrData += Location.Serialize(pCurrData);
		*pCurrData = (byte)_internalType;
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
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			pCurrData += Location.Deserialize(pCurrData);
		}
		if (num > 1)
		{
			_internalType = (sbyte)(*pCurrData);
			pCurrData++;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
