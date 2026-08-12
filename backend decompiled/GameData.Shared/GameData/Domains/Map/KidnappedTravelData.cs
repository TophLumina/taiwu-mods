using GameData.Serializer;

namespace GameData.Domains.Map;

/// <summary>
/// 抓捕旅行数据
/// </summary>
[SerializableGameData(IsExtensible = true)]
public class KidnappedTravelData : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort Target = 0;

		public const ushort HunterCharId = 1;

		public const ushort Count = 2;

		public static readonly string[] FieldId2FieldName = new string[2] { "Target", "HunterCharId" };
	}

	/// <summary>
	/// 无效的占位数据
	/// </summary>
	public static readonly KidnappedTravelData Invalid = new KidnappedTravelData();

	/// <summary>
	/// 目标位置
	/// </summary>
	[SerializableGameDataField]
	public Location Target = Location.Invalid;

	/// <summary>
	/// 捕快角色 ID
	/// </summary>
	[SerializableGameDataField]
	public int HunterCharId = -1;

	/// <summary>
	/// 有效性
	/// </summary>
	public bool Valid
	{
		get
		{
			if (Target.IsValid())
			{
				return HunterCharId >= 0;
			}
			return false;
		}
	}

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public KidnappedTravelData()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public KidnappedTravelData(KidnappedTravelData other)
	{
		Target = other.Target;
		HunterCharId = other.HunterCharId;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(KidnappedTravelData other)
	{
		Target = other.Target;
		HunterCharId = other.HunterCharId;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
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
		byte* pCurrData = pData;
		*(short*)pCurrData = 2;
		pCurrData += 2;
		pCurrData += Target.Serialize(pCurrData);
		*(int*)pCurrData = HunterCharId;
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
			pCurrData += Target.Deserialize(pCurrData);
		}
		if (num > 1)
		{
			HunterCharId = *(int*)pCurrData;
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
