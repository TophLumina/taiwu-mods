using GameData.Serializer;

namespace GameData.Domains.Building.Display;

/// <summary>
/// 元鸡拔毛显示数据
/// </summary>
[SerializableGameData(NotRestrictCollectionSerializedSize = true)]
public class ChickenPluckFeatherDisplayData : ISerializableGameData
{
	/// <summary>
	/// 当前羽毛值（进度）
	/// </summary>
	[SerializableGameDataField]
	public int FeatherValue;

	/// <summary>
	/// 太吾村元鸡数量
	/// </summary>
	[SerializableGameDataField]
	public int ChickenCount;

	/// <summary>
	/// 可拔毛元鸡数量
	/// </summary>
	[SerializableGameDataField]
	public int CanPluckCount;

	/// <summary>
	/// 本月羽毛值增加量（基础值 + 元鸡数 × 每只增加量）
	/// </summary>
	[SerializableGameDataField]
	public int MonthlyIncrease;

	/// <summary>
	/// 本月剩余天数
	/// </summary>
	[SerializableGameDataField]
	public int RemainingDays;

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public ChickenPluckFeatherDisplayData()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public ChickenPluckFeatherDisplayData(ChickenPluckFeatherDisplayData other)
	{
		FeatherValue = other.FeatherValue;
		ChickenCount = other.ChickenCount;
		CanPluckCount = other.CanPluckCount;
		MonthlyIncrease = other.MonthlyIncrease;
		RemainingDays = other.RemainingDays;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(ChickenPluckFeatherDisplayData other)
	{
		FeatherValue = other.FeatherValue;
		ChickenCount = other.ChickenCount;
		CanPluckCount = other.CanPluckCount;
		MonthlyIncrease = other.MonthlyIncrease;
		RemainingDays = other.RemainingDays;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 20;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		*(int*)pData = FeatherValue;
		byte* num = pData + 4;
		*(int*)num = ChickenCount;
		byte* num2 = num + 4;
		*(int*)num2 = CanPluckCount;
		byte* num3 = num2 + 4;
		*(int*)num3 = MonthlyIncrease;
		byte* num4 = num3 + 4;
		*(int*)num4 = RemainingDays;
		int totalSize = (int)(num4 + 4 - pData);
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
		FeatherValue = *(int*)pCurrData;
		pCurrData += 4;
		ChickenCount = *(int*)pCurrData;
		pCurrData += 4;
		CanPluckCount = *(int*)pCurrData;
		pCurrData += 4;
		MonthlyIncrease = *(int*)pCurrData;
		pCurrData += 4;
		RemainingDays = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
