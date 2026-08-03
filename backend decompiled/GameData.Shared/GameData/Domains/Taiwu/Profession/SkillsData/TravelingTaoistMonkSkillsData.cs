using GameData.Serializer;

namespace GameData.Domains.Taiwu.Profession.SkillsData;

/// <summary>
/// 云游道技能数据
/// </summary>
[SerializableGameData(IsExtensible = true)]
public class TravelingTaoistMonkSkillsData : IProfessionSkillsData, ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort BonusMaxHealth = 0;

		public const ushort Count = 1;

		public static readonly string[] FieldId2FieldName = new string[1] { "BonusMaxHealth" };
	}

	/// <summary>
	/// 化外逍遥额外最大健康
	/// </summary>
	[SerializableGameDataField]
	public short BonusMaxHealth;

	/// <inheritdoc />
	public void Initialize()
	{
	}

	/// <inheritdoc />
	public void InheritFrom(IProfessionSkillsData sourceData)
	{
		if (sourceData is ObsoleteTravelingTaoistMonkSkillsData skillsData)
		{
			BonusMaxHealth = skillsData.BonusMaxHealth;
		}
	}

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public TravelingTaoistMonkSkillsData()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public TravelingTaoistMonkSkillsData(TravelingTaoistMonkSkillsData other)
	{
		BonusMaxHealth = other.BonusMaxHealth;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(TravelingTaoistMonkSkillsData other)
	{
		BonusMaxHealth = other.BonusMaxHealth;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 4;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = 1;
		byte* num = pData + 2;
		*(short*)num = BonusMaxHealth;
		int totalSize = (int)(num + 2 - pData);
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
			BonusMaxHealth = *(short*)pCurrData;
			pCurrData += 2;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
