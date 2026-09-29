using System;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Character.Alertness;

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

	[SerializableGameDataField]
	public int Value;

	[SerializableGameDataField]
	public CharacterAlertnessRecordCollection RecordCollection;

	public const sbyte Level0 = 0;

	public const sbyte Level1 = 1;

	public const sbyte Level2 = 2;

	public const sbyte Level3 = 3;

	public const sbyte Level4 = 4;

	public const sbyte Level5 = 5;

	public const sbyte Level6 = 6;

	public sbyte Level => GetLevel(Value);

	public int EffectChangeFavor => GetEffectChangeFavor(Level);

	public int EffectMaxFavor => GetEffectMaxFavor(Value);

	public int EffectInteract => GetEffectInteract(Level);

	public int EffectExchange => GetEffectExchange(Level);

	public short MaxFavor => GetMaxFavor(EffectMaxFavor);

	public static sbyte LevelNormal => 3;

	public static sbyte LevelMin => 0;

	public static sbyte LevelMax => 6;

	public static int MaxValue => GlobalConfig.Instance.AlertnessMax;

	public static int MinValue => GlobalConfig.Instance.AlertnessMin;

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

	public static int GetEffectChangeFavor(int level)
	{
		level = ValidateLevel(level);
		return GlobalConfig.Instance.AlertnessLevelEffectToChangeFavor[level];
	}

	public static int GetEffectMaxFavor(int value)
	{
		if ((value == int.MinValue || value == int.MaxValue) ? true : false)
		{
			return 0;
		}
		return value / GlobalConfig.Instance.AlertnessEffectToMaxFavor;
	}

	public static int GetEffectInteract(int level)
	{
		level = ValidateLevel(level);
		return GlobalConfig.Instance.AlertnessLevelEffectToInteractSuccessRate[level];
	}

	public static int GetEffectExchange(int level)
	{
		level = ValidateLevel(level);
		return GlobalConfig.Instance.ExchangeAlertnessLevel[level];
	}

	public static short GetMaxFavor(int effect)
	{
		return (short)Math.Clamp(30000 - effect, -30000, 30000);
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

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
