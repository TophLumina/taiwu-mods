using GameData.Serializer;

namespace GameData.Domains.Taiwu.Profession.SkillsData;

/// <summary>
/// 道长技能相关数据
/// </summary>
[SerializableGameData(IsExtensible = true)]
public class TaoistMonkSkillsData : IProfessionSkillsData, ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort SurvivedTribulationCount = 0;

		public const ushort LastAgeIncreaseDate = 1;

		public const ushort Count = 2;

		public static readonly string[] FieldId2FieldName = new string[2] { "SurvivedTribulationCount", "LastAgeIncreaseDate" };
	}

	/// <summary>
	/// 度过的天劫数
	/// </summary>
	[SerializableGameDataField]
	public sbyte SurvivedTribulationCount;

	/// <summary>
	/// 上次身龄增加的时间
	/// </summary>
	[SerializableGameDataField]
	public int LastAgeIncreaseDate;

	/// <summary>
	/// 正在触发天劫
	/// </summary>
	public bool IsTriggeringTribulation;

	/// <inheritdoc />
	public void Initialize()
	{
	}

	/// <inheritdoc />
	public void InheritFrom(IProfessionSkillsData sourceData)
	{
		if (sourceData is ObsoleteTaoistMonkSkillsData skillsData)
		{
			SurvivedTribulationCount = skillsData.SurvivedTribulationCount;
		}
	}

	/// <summary>
	/// 是否度过七九天劫
	/// </summary>
	public bool HasSurvivedAllTribulation()
	{
		return SurvivedTribulationCount >= 4;
	}

	/// <summary>
	/// 是否应该增长身龄
	/// 必须在历灾渡劫全部完成后才可调用
	/// </summary>
	/// <returns></returns>
	public bool ShouldIncreaseAge()
	{
		return ExternalDataBridge.Context.CurrDate - LastAgeIncreaseDate >= 36;
	}

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public TaoistMonkSkillsData()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public TaoistMonkSkillsData(TaoistMonkSkillsData other)
	{
		SurvivedTribulationCount = other.SurvivedTribulationCount;
		LastAgeIncreaseDate = other.LastAgeIncreaseDate;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(TaoistMonkSkillsData other)
	{
		SurvivedTribulationCount = other.SurvivedTribulationCount;
		LastAgeIncreaseDate = other.LastAgeIncreaseDate;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
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
		*(short*)pData = 2;
		byte* num = pData + 2;
		*num = (byte)SurvivedTribulationCount;
		byte* num2 = num + 1;
		*(int*)num2 = LastAgeIncreaseDate;
		int totalSize = (int)(num2 + 4 - pData);
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
			SurvivedTribulationCount = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (num > 1)
		{
			LastAgeIncreaseDate = *(int*)pCurrData;
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
