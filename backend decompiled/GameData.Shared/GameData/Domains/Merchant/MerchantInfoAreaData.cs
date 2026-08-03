using GameData.Serializer;

namespace GameData.Domains.Merchant;

/// <summary>
/// 商会信息的地区内容
/// </summary>
[SerializableGameData(NoCopyConstructors = true)]
public class MerchantInfoAreaData : ISerializableGameData
{
	/// <summary>
	/// 地区配置ID
	/// </summary>
	[SerializableGameDataField]
	public short AreaTemplateId;

	/// <summary>
	/// 商队数量
	/// </summary>
	[SerializableGameDataField]
	public int CaravanCount;

	/// <summary>
	/// 商人数量
	/// </summary>
	[SerializableGameDataField]
	public int MerchantCount;

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 10;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = AreaTemplateId;
		byte* num = pData + 2;
		*(int*)num = CaravanCount;
		byte* num2 = num + 4;
		*(int*)num2 = MerchantCount;
		int totalSize = (int)(num2 + 4 - pData);
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
		AreaTemplateId = *(short*)pCurrData;
		pCurrData += 2;
		CaravanCount = *(int*)pCurrData;
		pCurrData += 4;
		MerchantCount = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
