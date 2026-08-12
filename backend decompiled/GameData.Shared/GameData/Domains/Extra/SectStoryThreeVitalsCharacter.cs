using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Extra;

/// <summary>
/// 元山地区主线 - 三才/三魔角色的额外数据
/// </summary>
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

	/// <summary>
	/// 用于序列化的类型
	/// </summary>
	[SerializableGameDataField(FieldIndex = 0)]
	private int _internalVitalType;

	/// <summary>
	/// 入魔值
	/// </summary>
	[SerializableGameDataField(FieldIndex = 1)]
	public int Infection;

	/// <summary>
	/// 是否在元山石牢
	/// </summary>
	[SerializableGameDataField(FieldIndex = 2)]
	public bool IsInPrison;

	/// <summary>
	/// 是否播放了出现动画，每次遣离要重置为false
	/// </summary>
	[SerializableGameDataField(FieldIndex = 3)]
	public bool HasPlayedComeAnim;

	/// <summary>
	/// 类型
	/// </summary>
	public SectStoryThreeVitalsCharacterType VitalType => (SectStoryThreeVitalsCharacterType)_internalVitalType;

	/// <summary>
	/// 基于类型构造数据
	/// </summary>
	/// <param name="type"></param>
	public SectStoryThreeVitalsCharacter(SectStoryThreeVitalsCharacterType type)
	{
		_internalVitalType = (int)type;
		Infection = GlobalConfig.Instance.ThreeVitalsInitInfection;
		IsInPrison = false;
	}

	/// <summary>
	/// 是否可作为同道出战
	/// </summary>
	/// <param name="vitalIsDemon">是否为三魔</param>
	/// <returns></returns>
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

	/// <summary>
	/// 计算某类型三魔/才化身另一形态替换敌方同道的概率
	/// </summary>
	/// <param name="vitalIsDemon">是否为三魔</param>
	/// <returns></returns>
	public int CalcBetrayOdds(bool vitalIsDemon)
	{
		if (AllowAsTeammate(vitalIsDemon) || IsInPrison)
		{
			return 0;
		}
		int baseOdds = GlobalConfig.Instance.ThreeVitalsDefectionBase;
		return (vitalIsDemon ? (baseOdds - Infection) : (Infection - baseOdds)) + GlobalConfig.Instance.ThreeVitalsDefectionExtra;
	}

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public SectStoryThreeVitalsCharacter()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public SectStoryThreeVitalsCharacter(SectStoryThreeVitalsCharacter other)
	{
		_internalVitalType = other._internalVitalType;
		Infection = other.Infection;
		IsInPrison = other.IsInPrison;
		HasPlayedComeAnim = other.HasPlayedComeAnim;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
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
