using GameData.Serializer;

namespace GameData.Domains.Building;

/// <summary>
/// 建筑经营产出 Tips  依赖建筑数据
/// </summary>
[SerializableGameData(NotForArchive = true)]
public struct BuildingProduceDependencyData : ISerializableGameData
{
	/// <summary>
	/// 无效值
	/// </summary>
	public static readonly BuildingProduceDependencyData Invalid = new BuildingProduceDependencyData(-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1);

	/// <summary>
	/// 模板ID
	/// </summary>
	[SerializableGameDataField]
	public short TemplateId;

	/// <summary>
	/// 规模
	/// </summary>
	[SerializableGameDataField]
	public sbyte Level;

	/// <summary>
	/// 基础资源(原产出等级)
	/// </summary>
	[SerializableGameDataField]
	public int ResourceYieldLevelFactor;

	/// <summary>
	/// 资源修正(原地格基础产出)
	/// </summary>
	[SerializableGameDataField]
	public int BlockBaseYieldFactor;

	/// <summary>
	/// 建筑产能
	/// </summary>
	[SerializableGameDataField]
	public int ProductivityFactor;

	/// <summary>
	/// 总造诣值
	/// </summary>
	[SerializableGameDataField]
	public int TotalAttainmentFactor;

	/// <summary>
	/// 太吾村资源产出难度修正
	/// </summary>
	[SerializableGameDataField]
	public int GainResourcePercentFactor;

	/// <summary>
	/// 安定文化
	/// </summary>
	[SerializableGameDataField]
	public int SafetyCultureFactor;

	/// <summary>
	/// 单个预计产出
	/// </summary>
	[SerializableGameDataField]
	public int ResourceSingleOutputValuation;

	/// <summary>
	/// 随机因子上限
	/// </summary>
	[SerializableGameDataField]
	public float RandomFactorUpperLimit;

	/// <summary>
	/// 随机因子下限
	/// </summary>
	[SerializableGameDataField]
	public float RandomFactorLowerLimit;

	/// 资源产出量 =
	///            基础资源 *
	///            建筑产能 / 100 *
	///            资源修正 / 100 *
	///            总造诣值 / 100 *
	///            太吾村资源产出难度修正 / 100
	public int ResourceBuildingOutput => ResourceYieldLevelFactor * ProductivityFactor / 100 * BlockBaseYieldFactor / 100 * TotalAttainmentFactor / 100 * GainResourcePercentFactor / 100;

	/// 银钱产出量 =
	///             建筑产能 / 100 *
	///             (100 + 安定文化因子) / 100 *
	///             总造诣值 / 100 *
	///             随机因子 / 100 *
	///             太吾村银钱威望产出难度修正 / 100
	public int MoneyBuildingOutput => 300 * ProductivityFactor / 100 * SafetyCultureFactor / 100 * TotalAttainmentFactor / 100 * GainResourcePercentFactor / 100;

	/// <summary>
	/// 威望产出量
	/// </summary>
	public int AuthorityBuildingOutput => MoneyBuildingOutput / 10;

	/// <summary>
	/// 赌坊产出
	/// </summary>
	public int GamblingHouseOutput => MoneyBuildingOutput;

	/// <summary>
	/// 青楼产出
	/// </summary>
	public int BrothelOutput => MoneyBuildingOutput;

	private BuildingProduceDependencyData(short templateId, sbyte level, int resourceYieldLevelFactor, int blockBaseYieldFactor, int productivityFactor, int totalAttainmentFactor, int gainResourcePercentFactor, int safetyCultureFactor, int randomFactorUpperLimit, int randomFactorLowerLimit, int collectDamping, int resourceSingleOutputValuation)
	{
		TemplateId = templateId;
		Level = level;
		ResourceYieldLevelFactor = resourceYieldLevelFactor;
		BlockBaseYieldFactor = blockBaseYieldFactor;
		ProductivityFactor = productivityFactor;
		TotalAttainmentFactor = totalAttainmentFactor;
		GainResourcePercentFactor = gainResourcePercentFactor;
		SafetyCultureFactor = safetyCultureFactor;
		RandomFactorUpperLimit = randomFactorUpperLimit;
		RandomFactorLowerLimit = randomFactorLowerLimit;
		ResourceSingleOutputValuation = resourceSingleOutputValuation;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 39;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = TemplateId;
		byte* num = pData + 2;
		*num = (byte)Level;
		byte* num2 = num + 1;
		*(int*)num2 = ResourceYieldLevelFactor;
		byte* num3 = num2 + 4;
		*(int*)num3 = BlockBaseYieldFactor;
		byte* num4 = num3 + 4;
		*(int*)num4 = ProductivityFactor;
		byte* num5 = num4 + 4;
		*(int*)num5 = TotalAttainmentFactor;
		byte* num6 = num5 + 4;
		*(int*)num6 = GainResourcePercentFactor;
		byte* num7 = num6 + 4;
		*(int*)num7 = SafetyCultureFactor;
		byte* num8 = num7 + 4;
		*(int*)num8 = ResourceSingleOutputValuation;
		byte* num9 = num8 + 4;
		*(float*)num9 = RandomFactorUpperLimit;
		byte* num10 = num9 + 4;
		*(float*)num10 = RandomFactorLowerLimit;
		int totalSize = (int)(num10 + 4 - pData);
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
		TemplateId = *(short*)pCurrData;
		pCurrData += 2;
		Level = (sbyte)(*pCurrData);
		pCurrData++;
		ResourceYieldLevelFactor = *(int*)pCurrData;
		pCurrData += 4;
		BlockBaseYieldFactor = *(int*)pCurrData;
		pCurrData += 4;
		ProductivityFactor = *(int*)pCurrData;
		pCurrData += 4;
		TotalAttainmentFactor = *(int*)pCurrData;
		pCurrData += 4;
		GainResourcePercentFactor = *(int*)pCurrData;
		pCurrData += 4;
		SafetyCultureFactor = *(int*)pCurrData;
		pCurrData += 4;
		ResourceSingleOutputValuation = *(int*)pCurrData;
		pCurrData += 4;
		RandomFactorUpperLimit = *(float*)pCurrData;
		pCurrData += 4;
		RandomFactorLowerLimit = *(float*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <summary>
	/// 计算售卖道具价格
	/// </summary>
	/// <param name="basePrice"> 道具原始价格(含耐久等计算) </param>
	/// <returns></returns>
	public int CalcSaleItemPrice(int basePrice)
	{
		return basePrice * TotalAttainmentFactor / 100 * ProductivityFactor / 100 * SafetyCultureFactor / 100 * GainResourcePercentFactor / 100;
	}

	/// <summary>
	/// 根据总造诣计算售卖道具的工作效率
	/// </summary>
	/// <param name="totalAttainment"></param>
	/// <returns></returns>
	public int BuildSaleItemAttainmentFactor(int totalAttainment)
	{
		return 40 + totalAttainment / 50;
	}
}
