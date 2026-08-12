using GameData.Domains.Character;
using GameData.Serializer;

namespace GameData.Domains.Map;

/// <summary>
/// 模拟地图恢复结果
/// </summary>
[SerializableGameData(NotForArchive = true)]
public struct MapHealSimulateResult : ISerializableGameData
{
	/// <summary>
	/// 用于序列化的类型
	/// </summary>
	[SerializableGameDataField]
	private int _serializeType;

	/// <summary>
	/// 消耗药材
	/// </summary>
	[SerializableGameDataField]
	public int CostHerb;

	/// <summary>
	/// 消耗银钱
	/// </summary>
	[SerializableGameDataField]
	public int CostMoney;

	/// <summary>
	/// 消耗地区恩义，最大值1000
	/// </summary>
	[SerializableGameDataField]
	public int CostSpiritualDebt;

	/// <summary>
	/// 治疗效果
	/// 疗伤：治愈伤势数量
	/// 驱毒：驱除毒素数量
	/// 调息：减少内息紊乱
	/// 复元：恢复健康数量
	/// </summary>
	[SerializableGameDataField]
	public int HealEffect;

	/// <summary>
	/// 最大需求造诣
	/// </summary>
	[SerializableGameDataField]
	public int MaxRequireAttainment;

	/// <summary>
	/// 类型
	/// </summary>
	public EHealActionType Type => (EHealActionType)_serializeType;

	/// <summary>
	/// 后端使用的构造方法
	/// </summary>
	public MapHealSimulateResult(EHealActionType type, int costHerb, int costMoney, int healEffect, int costSpiritualDebt, int maxRequireAttainment)
	{
		_serializeType = (int)type;
		CostHerb = costHerb;
		CostMoney = costMoney;
		HealEffect = healEffect;
		CostSpiritualDebt = costSpiritualDebt;
		MaxRequireAttainment = maxRequireAttainment;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 24;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		*(int*)pData = _serializeType;
		byte* num = pData + 4;
		*(int*)num = CostHerb;
		byte* num2 = num + 4;
		*(int*)num2 = CostMoney;
		byte* num3 = num2 + 4;
		*(int*)num3 = CostSpiritualDebt;
		byte* num4 = num3 + 4;
		*(int*)num4 = HealEffect;
		byte* num5 = num4 + 4;
		*(int*)num5 = MaxRequireAttainment;
		int totalSize = (int)(num5 + 4 - pData);
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
		_serializeType = *(int*)pCurrData;
		pCurrData += 4;
		CostHerb = *(int*)pCurrData;
		pCurrData += 4;
		CostMoney = *(int*)pCurrData;
		pCurrData += 4;
		CostSpiritualDebt = *(int*)pCurrData;
		pCurrData += 4;
		HealEffect = *(int*)pCurrData;
		pCurrData += 4;
		MaxRequireAttainment = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
