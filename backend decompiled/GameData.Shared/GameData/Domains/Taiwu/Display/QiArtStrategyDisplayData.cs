using GameData.Serializer;

namespace GameData.Domains.Taiwu.Display;

/// <summary>
/// 一个周天策略的显示数据
/// </summary>
[SerializableGameData(NotRestrictCollectionSerializedSize = true)]
public class QiArtStrategyDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public sbyte TemplateId;

	[SerializableGameDataField]
	public int ExpireTime;

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public QiArtStrategyDisplayData()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public QiArtStrategyDisplayData(QiArtStrategyDisplayData other)
	{
		TemplateId = other.TemplateId;
		ExpireTime = other.ExpireTime;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(QiArtStrategyDisplayData other)
	{
		TemplateId = other.TemplateId;
		ExpireTime = other.ExpireTime;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 5;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		*pData = (byte)TemplateId;
		byte* num = pData + 1;
		*(int*)num = ExpireTime;
		int totalSize = (int)(num + 4 - pData);
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
		TemplateId = (sbyte)(*pCurrData);
		pCurrData++;
		ExpireTime = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
