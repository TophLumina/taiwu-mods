using GameData.Serializer;

namespace GameData.Domains.CombatSkill;

[SerializableGameData(NotForArchive = true)]
public class CombatSkillBreakSuccessRateDisplayData : ISerializableGameData
{
	/// <summary>
	/// 基础成功率（结果）
	/// </summary>
	[SerializableGameDataField]
	public byte BaseSuccessRate;

	/// <summary>
	/// 基础的基础
	/// </summary>
	[SerializableGameDataField]
	public byte BaseBaseSuccessRate;

	/// <summary>
	/// 门派加成
	/// </summary>
	[SerializableGameDataField]
	public byte OrganizationBonus;

	/// <summary>
	/// 悟性加成
	/// </summary>
	[SerializableGameDataField]
	public byte AttributesBonus;

	/// <summary>
	/// 精纯加成
	/// </summary>
	[SerializableGameDataField]
	public byte ConsummateLevelBonus;

	/// <summary>
	/// 产业加成
	/// </summary>
	[SerializableGameDataField]
	public byte BuildingBonus;

	/// <summary>
	/// 奇遇加成
	/// </summary>
	[SerializableGameDataField]
	public byte AdventureBonus;

	/// <summary>
	/// 难度加成
	/// </summary>
	[SerializableGameDataField]
	public byte DifficultyBonus;

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public CombatSkillBreakSuccessRateDisplayData()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public CombatSkillBreakSuccessRateDisplayData(CombatSkillBreakSuccessRateDisplayData other)
	{
		BaseSuccessRate = other.BaseSuccessRate;
		BaseBaseSuccessRate = other.BaseBaseSuccessRate;
		OrganizationBonus = other.OrganizationBonus;
		AttributesBonus = other.AttributesBonus;
		ConsummateLevelBonus = other.ConsummateLevelBonus;
		BuildingBonus = other.BuildingBonus;
		AdventureBonus = other.AdventureBonus;
		DifficultyBonus = other.DifficultyBonus;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(CombatSkillBreakSuccessRateDisplayData other)
	{
		BaseSuccessRate = other.BaseSuccessRate;
		BaseBaseSuccessRate = other.BaseBaseSuccessRate;
		OrganizationBonus = other.OrganizationBonus;
		AttributesBonus = other.AttributesBonus;
		ConsummateLevelBonus = other.ConsummateLevelBonus;
		BuildingBonus = other.BuildingBonus;
		AdventureBonus = other.AdventureBonus;
		DifficultyBonus = other.DifficultyBonus;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 8;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		*pData = BaseSuccessRate;
		byte* num = pData + 1;
		*num = BaseBaseSuccessRate;
		byte* num2 = num + 1;
		*num2 = OrganizationBonus;
		byte* num3 = num2 + 1;
		*num3 = AttributesBonus;
		byte* num4 = num3 + 1;
		*num4 = ConsummateLevelBonus;
		byte* num5 = num4 + 1;
		*num5 = BuildingBonus;
		byte* num6 = num5 + 1;
		*num6 = AdventureBonus;
		byte* num7 = num6 + 1;
		*num7 = DifficultyBonus;
		int totalSize = (int)(num7 + 1 - pData);
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
		BaseSuccessRate = *pCurrData;
		pCurrData++;
		BaseBaseSuccessRate = *pCurrData;
		pCurrData++;
		OrganizationBonus = *pCurrData;
		pCurrData++;
		AttributesBonus = *pCurrData;
		pCurrData++;
		ConsummateLevelBonus = *pCurrData;
		pCurrData++;
		BuildingBonus = *pCurrData;
		pCurrData++;
		AdventureBonus = *pCurrData;
		pCurrData++;
		DifficultyBonus = *pCurrData;
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
