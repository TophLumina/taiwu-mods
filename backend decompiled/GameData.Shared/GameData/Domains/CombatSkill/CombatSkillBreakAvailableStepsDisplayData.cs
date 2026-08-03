using GameData.Serializer;

namespace GameData.Domains.CombatSkill;

[SerializableGameData(NotForArchive = true)]
public class CombatSkillBreakAvailableStepsDisplayData : ISerializableGameData
{
	/// <summary>
	/// 基础可用步数（结果）
	/// </summary>
	[SerializableGameDataField]
	public sbyte BaseAvailableSteps;

	/// <summary>
	/// 基础的基础可用步数
	/// </summary>
	[SerializableGameDataField]
	public sbyte BaseBaseAvailableSteps;

	/// <summary>
	/// 产业加成
	/// </summary>
	[SerializableGameDataField]
	public sbyte BuildingBonus;

	/// <summary>
	/// 精纯加成
	/// </summary>
	[SerializableGameDataField]
	public sbyte ConsummateLevelBonus;

	/// <summary>
	/// NPC品级加成
	/// </summary>
	[SerializableGameDataField]
	public sbyte InteractionGradeBonus;

	/// <summary>
	/// 奇遇加成
	/// </summary>
	[SerializableGameDataField]
	public sbyte AdventureBonus;

	/// <summary>
	/// 门派支持率加成
	/// </summary>
	[SerializableGameDataField]
	public sbyte OrganizationBonus;

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public CombatSkillBreakAvailableStepsDisplayData()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public CombatSkillBreakAvailableStepsDisplayData(CombatSkillBreakAvailableStepsDisplayData other)
	{
		BaseAvailableSteps = other.BaseAvailableSteps;
		BaseBaseAvailableSteps = other.BaseBaseAvailableSteps;
		BuildingBonus = other.BuildingBonus;
		ConsummateLevelBonus = other.ConsummateLevelBonus;
		InteractionGradeBonus = other.InteractionGradeBonus;
		AdventureBonus = other.AdventureBonus;
		OrganizationBonus = other.OrganizationBonus;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(CombatSkillBreakAvailableStepsDisplayData other)
	{
		BaseAvailableSteps = other.BaseAvailableSteps;
		BaseBaseAvailableSteps = other.BaseBaseAvailableSteps;
		BuildingBonus = other.BuildingBonus;
		ConsummateLevelBonus = other.ConsummateLevelBonus;
		InteractionGradeBonus = other.InteractionGradeBonus;
		AdventureBonus = other.AdventureBonus;
		OrganizationBonus = other.OrganizationBonus;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 7;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		*pData = (byte)BaseAvailableSteps;
		byte* num = pData + 1;
		*num = (byte)BaseBaseAvailableSteps;
		byte* num2 = num + 1;
		*num2 = (byte)BuildingBonus;
		byte* num3 = num2 + 1;
		*num3 = (byte)ConsummateLevelBonus;
		byte* num4 = num3 + 1;
		*num4 = (byte)InteractionGradeBonus;
		byte* num5 = num4 + 1;
		*num5 = (byte)AdventureBonus;
		byte* num6 = num5 + 1;
		*num6 = (byte)OrganizationBonus;
		int totalSize = (int)(num6 + 1 - pData);
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
		BaseAvailableSteps = (sbyte)(*pCurrData);
		pCurrData++;
		BaseBaseAvailableSteps = (sbyte)(*pCurrData);
		pCurrData++;
		BuildingBonus = (sbyte)(*pCurrData);
		pCurrData++;
		ConsummateLevelBonus = (sbyte)(*pCurrData);
		pCurrData++;
		InteractionGradeBonus = (sbyte)(*pCurrData);
		pCurrData++;
		AdventureBonus = (sbyte)(*pCurrData);
		pCurrData++;
		OrganizationBonus = (sbyte)(*pCurrData);
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
