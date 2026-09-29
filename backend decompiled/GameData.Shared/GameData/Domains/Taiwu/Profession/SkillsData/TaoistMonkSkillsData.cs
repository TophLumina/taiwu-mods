using GameData.Serializer;

namespace GameData.Domains.Taiwu.Profession.SkillsData;

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

	[SerializableGameDataField]
	public sbyte SurvivedTribulationCount;

	[SerializableGameDataField]
	public int LastAgeIncreaseDate;

	public bool IsTriggeringTribulation;

	public void Initialize()
	{
	}

	public void InheritFrom(IProfessionSkillsData sourceData)
	{
		if (sourceData is ObsoleteTaoistMonkSkillsData skillsData)
		{
			SurvivedTribulationCount = skillsData.SurvivedTribulationCount;
		}
	}

	public bool HasSurvivedAllTribulation()
	{
		return SurvivedTribulationCount >= 4;
	}

	public bool ShouldIncreaseAge()
	{
		return ExternalDataBridge.Context.CurrDate - LastAgeIncreaseDate >= 36;
	}

	public TaoistMonkSkillsData()
	{
	}

	public TaoistMonkSkillsData(TaoistMonkSkillsData other)
	{
		SurvivedTribulationCount = other.SurvivedTribulationCount;
		LastAgeIncreaseDate = other.LastAgeIncreaseDate;
	}

	public void Assign(TaoistMonkSkillsData other)
	{
		SurvivedTribulationCount = other.SurvivedTribulationCount;
		LastAgeIncreaseDate = other.LastAgeIncreaseDate;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 7;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

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
