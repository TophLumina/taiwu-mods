using GameData.Serializer;

namespace GameData.Domains.Building.Display;

/// <summary>
/// 0. 是否可以操作取出全部促织 == 陈列中是否有促织
/// 1. 是否可以操作取出全部罐 == 陈列中是否有罐
/// 2. 是否可以操作自动存放促织1 == 各来源是否有促织
/// 3. 是否可以操作自动存放促织2 == 陈列中是否有空罐
/// 4. 是否可以操作自动存放罐1 == 各来源是否有罐
/// 5. 是否可以操作自动存放罐2 == 陈列中是否有位置放罐
/// </summary>
[SerializableGameData(NotRestrictCollectionSerializedSize = true)]
public class CricketCollectionBatchButtonStateDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public bool HasCricketInCollection;

	[SerializableGameDataField]
	public bool HasJarInCollection;

	[SerializableGameDataField]
	public bool HasCricketInSources;

	[SerializableGameDataField]
	public bool HasEmptyJarInCollection;

	[SerializableGameDataField]
	public bool HasJarInSources;

	[SerializableGameDataField]
	public bool HasEmptyPositionInCollection;

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public CricketCollectionBatchButtonStateDisplayData()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public CricketCollectionBatchButtonStateDisplayData(CricketCollectionBatchButtonStateDisplayData other)
	{
		HasCricketInCollection = other.HasCricketInCollection;
		HasJarInCollection = other.HasJarInCollection;
		HasCricketInSources = other.HasCricketInSources;
		HasEmptyJarInCollection = other.HasEmptyJarInCollection;
		HasJarInSources = other.HasJarInSources;
		HasEmptyPositionInCollection = other.HasEmptyPositionInCollection;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(CricketCollectionBatchButtonStateDisplayData other)
	{
		HasCricketInCollection = other.HasCricketInCollection;
		HasJarInCollection = other.HasJarInCollection;
		HasCricketInSources = other.HasCricketInSources;
		HasEmptyJarInCollection = other.HasEmptyJarInCollection;
		HasJarInSources = other.HasJarInSources;
		HasEmptyPositionInCollection = other.HasEmptyPositionInCollection;
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
		*pData = (HasCricketInCollection ? ((byte)1) : ((byte)0));
		byte* num = pData + 1;
		*num = (HasJarInCollection ? ((byte)1) : ((byte)0));
		byte* num2 = num + 1;
		*num2 = (HasCricketInSources ? ((byte)1) : ((byte)0));
		byte* num3 = num2 + 1;
		*num3 = (HasEmptyJarInCollection ? ((byte)1) : ((byte)0));
		byte* num4 = num3 + 1;
		*num4 = (HasJarInSources ? ((byte)1) : ((byte)0));
		byte* num5 = num4 + 1;
		*num5 = (HasEmptyPositionInCollection ? ((byte)1) : ((byte)0));
		int totalSize = (int)(num5 + 1 - pData);
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
		HasCricketInCollection = *pCurrData != 0;
		pCurrData++;
		HasJarInCollection = *pCurrData != 0;
		pCurrData++;
		HasCricketInSources = *pCurrData != 0;
		pCurrData++;
		HasEmptyJarInCollection = *pCurrData != 0;
		pCurrData++;
		HasJarInSources = *pCurrData != 0;
		pCurrData++;
		HasEmptyPositionInCollection = *pCurrData != 0;
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
