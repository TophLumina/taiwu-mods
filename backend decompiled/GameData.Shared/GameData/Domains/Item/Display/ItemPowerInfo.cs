using GameData.Serializer;

namespace GameData.Domains.Item.Display;

/// <summary>
/// 物品威力信息
/// </summary>
[SerializableGameData(NotForArchive = true)]
public struct ItemPowerInfo : ISerializableGameData
{
	/// <summary>
	/// 威力
	/// </summary>
	[SerializableGameDataField]
	public short Power;

	/// <summary>
	/// 威力上限
	/// </summary>
	[SerializableGameDataField]
	public short MaxPower;

	/// <summary>
	/// 发挥威力
	/// </summary>
	[SerializableGameDataField]
	public short RequirementsPower;

	/// <summary>
	/// 默认威力值
	/// </summary>
	public static ItemPowerInfo Default => new ItemPowerInfo
	{
		Power = 100,
		MaxPower = 100,
		RequirementsPower = 100
	};

	/// <summary>
	/// 是否有任意值
	/// </summary>
	public bool AnyValue
	{
		get
		{
			if (Power <= 0 && MaxPower <= 0)
			{
				return RequirementsPower > 0;
			}
			return true;
		}
	}

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
		*(short*)pData = Power;
		byte* num = pData + 2;
		*(short*)num = MaxPower;
		byte* num2 = num + 2;
		*(short*)num2 = RequirementsPower;
		int totalSize = (int)(num2 + 2 - pData);
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
		Power = *(short*)pCurrData;
		pCurrData += 2;
		MaxPower = *(short*)pCurrData;
		pCurrData += 2;
		RequirementsPower = *(short*)pCurrData;
		pCurrData += 2;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
