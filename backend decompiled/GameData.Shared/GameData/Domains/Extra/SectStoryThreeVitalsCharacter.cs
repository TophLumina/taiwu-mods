using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Extra;

[AutoGenerateSerializableGameData(IsExtensible = true)]
public class SectStoryThreeVitalsCharacter : ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort InternalVitalType = 0;

		public const ushort Infection = 1;

		public const ushort IsInPrison = 2;

		public const ushort HasPlayedComeAnim = 3;

		public const ushort Count = 4;

		public static readonly string[] FieldId2FieldName = new string[4] { "InternalVitalType", "Infection", "IsInPrison", "HasPlayedComeAnim" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	private int _internalVitalType;

	[SerializableGameDataField(FieldIndex = 1)]
	public int Infection;

	[SerializableGameDataField(FieldIndex = 2)]
	public bool IsInPrison;

	[SerializableGameDataField(FieldIndex = 3)]
	public bool HasPlayedComeAnim;

	public SectStoryThreeVitalsCharacterType VitalType => (SectStoryThreeVitalsCharacterType)_internalVitalType;

	public SectStoryThreeVitalsCharacter(SectStoryThreeVitalsCharacterType type)
	{
		_internalVitalType = (int)type;
		Infection = GlobalConfig.Instance.ThreeVitalsInitInfection;
		IsInPrison = false;
	}

	public bool AllowAsTeammate(bool vitalIsDemon)
	{
		if (IsInPrison)
		{
			return false;
		}
		if (!vitalIsDemon)
		{
			return Infection < GlobalConfig.Instance.ThreeVitalsThresholdHigh;
		}
		return Infection > GlobalConfig.Instance.ThreeVitalsThresholdLow;
	}

	public int CalcBetrayOdds(bool vitalIsDemon)
	{
		if (AllowAsTeammate(vitalIsDemon) || IsInPrison)
		{
			return 0;
		}
		int baseOdds = GlobalConfig.Instance.ThreeVitalsDefectionBase;
		return (vitalIsDemon ? (baseOdds - Infection) : (Infection - baseOdds)) + GlobalConfig.Instance.ThreeVitalsDefectionExtra;
	}

	public SectStoryThreeVitalsCharacter()
	{
	}

	public SectStoryThreeVitalsCharacter(SectStoryThreeVitalsCharacter other)
	{
		_internalVitalType = other._internalVitalType;
		Infection = other.Infection;
		IsInPrison = other.IsInPrison;
		HasPlayedComeAnim = other.HasPlayedComeAnim;
	}

	public void Assign(SectStoryThreeVitalsCharacter other)
	{
		_internalVitalType = other._internalVitalType;
		Infection = other.Infection;
		IsInPrison = other.IsInPrison;
		HasPlayedComeAnim = other.HasPlayedComeAnim;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 12;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = 4;
		byte* num = pData + 2;
		*(int*)num = _internalVitalType;
		byte* num2 = num + 4;
		*(int*)num2 = Infection;
		byte* num3 = num2 + 4;
		*num3 = (IsInPrison ? ((byte)1) : ((byte)0));
		byte* num4 = num3 + 1;
		*num4 = (HasPlayedComeAnim ? ((byte)1) : ((byte)0));
		int totalSize = (int)(num4 + 1 - pData);
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
			_internalVitalType = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 1)
		{
			Infection = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 2)
		{
			IsInPrison = *pCurrData != 0;
			pCurrData++;
		}
		if (num > 3)
		{
			HasPlayedComeAnim = *pCurrData != 0;
			pCurrData++;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
