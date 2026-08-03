using GameData.Serializer;

namespace GameData.Domains.Combat;

/// <summary>
/// 内外伤阈值显示数据
/// </summary>
[SerializableGameData(NoCopyConstructors = true, NotForArchive = true)]
public struct OuterAndInnerDamageStepDisplayData : ISerializableGameData
{
	/// <summary>
	/// 外伤阈值数据
	/// </summary>
	[SerializableGameDataField]
	public DamageStepDisplayData Outer;

	/// <summary>
	/// 内伤阈值数据
	/// </summary>
	[SerializableGameDataField]
	public DamageStepDisplayData Inner;

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 48;
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
		pCurrData += Outer.Serialize(pCurrData);
		pCurrData += Inner.Serialize(pCurrData);
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
		pCurrData += Outer.Deserialize(pCurrData);
		pCurrData += Inner.Deserialize(pCurrData);
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
