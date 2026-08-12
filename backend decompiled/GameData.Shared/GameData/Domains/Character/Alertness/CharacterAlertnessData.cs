using System;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Character.Alertness;

/// <summary>
/// NPC对太吾的戒心数据
/// </summary>
[SerializableGameData(IsExtensible = true, NoCopyConstructors = true)]
public class CharacterAlertnessData : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort Value = 0;

		public const ushort RecordCollection = 1;

		public const ushort Count = 2;

		public static readonly string[] FieldId2FieldName = new string[2] { "Value", "RecordCollection" };
	}

	/// <summary>
	/// 戒心值
	/// </summary>
	[SerializableGameDataField]
	public int Value;

	/// <summary>
	/// 戒心变化记录
	/// </summary>
	[SerializableGameDataField]
	public CharacterAlertnessRecordCollection RecordCollection;

	/// <summary>
	/// 笃信
	/// </summary>
	public const sbyte Level0 = 0;

	/// <summary>
	/// 深信
	/// </summary>
	public const sbyte Level1 = 1;

	/// <summary>
	/// 信任
	/// </summary>
	public const sbyte Level2 = 2;

	/// <summary>
	/// 平常
	/// </summary>
	public const sbyte Level3 = 3;

	/// <summary>
	/// 生疑
	/// </summary>
	public const sbyte Level4 = 4;

	/// <summary>
	/// 猜忌
	/// </summary>
	public const sbyte Level5 = 5;

	/// <summary>
	/// 戒备
	/// </summary>
	public const sbyte Level6 = 6;

	/// <summary>
	/// 戒心等级
	/// </summary>
	public sbyte Level => GetLevel(Value);

	/// <summary>
	/// 对好感变化的影响
	/// </summary>
	public int EffectChangeFavor => GetEffectChangeFavor(Level);

	/// <summary>
	/// 对好感上限的影响
	/// </summary>
	public int EffectMaxFavor => GetEffectMaxFavor(Value);

	/// <summary>
	/// 对互动成功率的影响
	/// </summary>
	public int EffectInteract => GetEffectInteract(Level);

	/// <summary>
	/// 对交换优势的影响
	/// </summary>
	public int EffectExchange => GetEffectExchange(Level);

	/// <summary>
	/// 最大好感
	/// </summary>
	public short MaxFavor => GetMaxFavor(EffectMaxFavor);

	/// <summary>
	/// 引用平常
	/// </summary>
	public static sbyte LevelNormal => 3;

	/// <summary>
	/// 最小等级
	/// </summary>
	public static sbyte LevelMin => 0;

	/// <summary>
	/// 最大等级
	/// </summary>
	public static sbyte LevelMax => 6;

	/// <summary>
	/// 戒心最大值
	/// </summary>
	public static int MaxValue => GlobalConfig.Instance.AlertnessMax;

	/// <summary>
	/// 戒心最小值
	/// </summary>
	public static int MinValue => GlobalConfig.Instance.AlertnessMin;

	/// <summary>
	/// 获取戒心等级
	/// </summary>
	/// <param name="alertness"></param>
	/// <returns></returns>
	public static sbyte GetLevel(int alertness)
	{
		if ((alertness == int.MinValue || alertness == int.MaxValue) ? true : false)
		{
			return -1;
		}
		if (alertness >= GlobalConfig.Instance.AlertnessLevelRange[0] && alertness < GlobalConfig.Instance.AlertnessLevelRange[1])
		{
			return 0;
		}
		if (alertness >= GlobalConfig.Instance.AlertnessLevelRange[1] && alertness < GlobalConfig.Instance.AlertnessLevelRange[2])
		{
			return 1;
		}
		if (alertness >= GlobalConfig.Instance.AlertnessLevelRange[2] && alertness < GlobalConfig.Instance.AlertnessLevelRange[3])
		{
			return 2;
		}
		if (alertness >= GlobalConfig.Instance.AlertnessLevelRange[3] && alertness <= GlobalConfig.Instance.AlertnessLevelRange[4])
		{
			return 3;
		}
		if (alertness > GlobalConfig.Instance.AlertnessLevelRange[4] && alertness <= GlobalConfig.Instance.AlertnessLevelRange[5])
		{
			return 4;
		}
		if (alertness > GlobalConfig.Instance.AlertnessLevelRange[5] && alertness <= GlobalConfig.Instance.AlertnessLevelRange[6])
		{
			return 5;
		}
		if (alertness > GlobalConfig.Instance.AlertnessLevelRange[6] && alertness <= GlobalConfig.Instance.AlertnessLevelRange[7])
		{
			return 6;
		}
		return LevelNormal;
	}

	public static int ClampValue(int value)
	{
		return Math.Clamp(value, MinValue, MaxValue);
	}

	public static int ClampChangeValue(int value)
	{
		return Math.Clamp(value, MinValue * 2, MaxValue * 2);
	}

	public static sbyte ValidateLevel(int level)
	{
		if (level < 0)
		{
			level = LevelNormal;
		}
		return (sbyte)Math.Clamp(level, LevelMin, LevelMax);
	}

	/// <summary>
	/// 获取戒心对好感变化的影响
	/// </summary>
	/// <param name="level"></param>
	/// <returns></returns>
	public static int GetEffectChangeFavor(int level)
	{
		level = ValidateLevel(level);
		return GlobalConfig.Instance.AlertnessLevelEffectToChangeFavor[level];
	}

	/// <summary>
	/// 获取戒心对好感上限的影响
	/// </summary>
	/// <returns></returns>
	public static int GetEffectMaxFavor(int value)
	{
		if ((value == int.MinValue || value == int.MaxValue) ? true : false)
		{
			return 0;
		}
		return value / GlobalConfig.Instance.AlertnessEffectToMaxFavor;
	}

	/// <summary>
	/// 获取戒心对互动成功率的影响
	/// </summary>
	/// <param name="level"></param>
	/// <returns></returns>
	public static int GetEffectInteract(int level)
	{
		level = ValidateLevel(level);
		return GlobalConfig.Instance.AlertnessLevelEffectToInteractSuccessRate[level];
	}

	/// <summary>
	/// 获取戒心对交换优势的影响
	/// </summary>
	/// <param name="level"></param>
	/// <returns></returns>
	public static int GetEffectExchange(int level)
	{
		level = ValidateLevel(level);
		return GlobalConfig.Instance.ExchangeAlertnessLevel[level];
	}

	/// <summary>
	/// 获取戒心影响后的好感上限
	/// </summary>
	/// <param name="effect"></param>
	/// <returns></returns>
	public static short GetMaxFavor(int effect)
	{
		return (short)Math.Clamp(30000 - effect, -30000, 30000);
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 6;
		totalSize = ((RecordCollection == null) ? (totalSize + 2) : (totalSize + (2 + RecordCollection.GetSerializedSize())));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 2;
		pCurrData += 2;
		*(int*)pCurrData = Value;
		pCurrData += 4;
		if (RecordCollection != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = RecordCollection.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		int totalSize = (int)(pCurrData - pData);
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
			Value = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 1)
		{
			ushort num2 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (num2 > 0)
			{
				if (RecordCollection == null)
				{
					RecordCollection = new CharacterAlertnessRecordCollection();
				}
				pCurrData += RecordCollection.Deserialize(pCurrData);
			}
			else
			{
				RecordCollection = null;
			}
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
