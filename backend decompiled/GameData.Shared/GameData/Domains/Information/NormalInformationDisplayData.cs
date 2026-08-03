using GameData.Serializer;

namespace GameData.Domains.Information;

/// <summary>
/// 为了排序和减少请求，包装的见闻数据
/// </summary>
[SerializableGameData(NotForArchive = true)]
public class NormalInformationDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public NormalInformation NormalInformation;

	[SerializableGameDataField]
	public int UsedCount;

	[SerializableGameDataField]
	public int MaxCount;

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public NormalInformationDisplayData()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public NormalInformationDisplayData(NormalInformationDisplayData other)
	{
		NormalInformation = other.NormalInformation;
		UsedCount = other.UsedCount;
		MaxCount = other.MaxCount;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(NormalInformationDisplayData other)
	{
		NormalInformation = other.NormalInformation;
		UsedCount = other.UsedCount;
		MaxCount = other.MaxCount;
	}

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
		pCurrData += NormalInformation.Serialize(pCurrData);
		*(int*)pCurrData = UsedCount;
		pCurrData += 4;
		*(int*)pCurrData = MaxCount;
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
		pCurrData += NormalInformation.Deserialize(pCurrData);
		UsedCount = *(int*)pCurrData;
		pCurrData += 4;
		MaxCount = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
