using GameData.Domains.Item;
using GameData.Serializer;

namespace GameData.Domains.Extra;

/// <summary>
/// 促织陈列数据
/// </summary>
[SerializableGameData(IsExtensible = true)]
public class CricketCollectionData : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort CollectionCrickets = 0;

		public const ushort CollectionCricketJars = 1;

		public const ushort CollectionCricketRegen = 2;

		public const ushort Count = 3;

		public static readonly string[] FieldId2FieldName = new string[3] { "Cricket", "CricketJar", "CricketRegen" };
	}

	/// <summary>
	/// 陈列界面中陈列蛐蛐的最大个数
	/// </summary>
	public const int CricketCollectionCapacity = 17;

	/// <summary>
	/// 陈列促织
	/// </summary>
	[SerializableGameDataField]
	public ItemKey Cricket;

	/// <summary>
	/// 陈列促织罐
	/// </summary>
	[SerializableGameDataField]
	public ItemKey CricketJar;

	/// <summary>
	/// 陈列促织恢复进度列表
	/// </summary>
	[SerializableGameDataField]
	public int CricketRegen;

	/// <summary>
	///
	/// </summary>
	/// <param name="crickets"></param>
	/// <param name="cricketJar"></param>
	/// <param name="cricketRegen"></param>
	public CricketCollectionData(ItemKey crickets, ItemKey cricketJar, int cricketRegen)
	{
		Cricket = crickets;
		CricketJar = cricketJar;
		CricketRegen = cricketRegen;
	}

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public CricketCollectionData()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public CricketCollectionData(CricketCollectionData other)
	{
		Cricket = other.Cricket;
		CricketJar = other.CricketJar;
		CricketRegen = other.CricketRegen;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(CricketCollectionData other)
	{
		Cricket = other.Cricket;
		CricketJar = other.CricketJar;
		CricketRegen = other.CricketRegen;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 22;
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
		*(short*)pCurrData = 3;
		pCurrData += 2;
		pCurrData += Cricket.Serialize(pCurrData);
		pCurrData += CricketJar.Serialize(pCurrData);
		*(int*)pCurrData = CricketRegen;
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
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			pCurrData += Cricket.Deserialize(pCurrData);
		}
		if (num > 1)
		{
			pCurrData += CricketJar.Deserialize(pCurrData);
		}
		if (num > 2)
		{
			CricketRegen = *(int*)pCurrData;
			pCurrData += 4;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
