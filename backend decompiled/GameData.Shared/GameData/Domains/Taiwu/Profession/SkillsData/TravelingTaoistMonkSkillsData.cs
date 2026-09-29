using GameData.Serializer;

namespace GameData.Domains.Taiwu.Profession.SkillsData;

[SerializableGameData(IsExtensible = true)]
public class TravelingTaoistMonkSkillsData : IProfessionSkillsData, ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort BonusMaxHealth = 0;

		public const ushort Count = 1;

		public static readonly string[] FieldId2FieldName = new string[1] { "BonusMaxHealth" };
	}

	[SerializableGameDataField]
	public short BonusMaxHealth;

	public void Initialize()
	{
	}

	public void InheritFrom(IProfessionSkillsData sourceData)
	{
		if (sourceData is ObsoleteTravelingTaoistMonkSkillsData skillsData)
		{
			BonusMaxHealth = skillsData.BonusMaxHealth;
		}
	}

	public TravelingTaoistMonkSkillsData()
	{
	}

	public TravelingTaoistMonkSkillsData(TravelingTaoistMonkSkillsData other)
	{
		BonusMaxHealth = other.BonusMaxHealth;
	}

	public void Assign(TravelingTaoistMonkSkillsData other)
	{
		BonusMaxHealth = other.BonusMaxHealth;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 4;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

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
