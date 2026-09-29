using System;
using GameData.Serializer;

namespace GameData.Domains.Character;

[SerializableGameData(NotForArchive = true, IsExtensible = true)]
public struct CombatResources(CombatResources other) : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort HealingCount = 0;

		public const ushort DetoxCount = 1;

		public const ushort BreathingCount = 2;

		public const ushort RecoverCount = 3;

		public const ushort Count = 4;

		public static readonly string[] FieldId2FieldName = new string[4] { "HealingCount", "DetoxCount", "BreathingCount", "RecoverCount" };
	}

	[SerializableGameDataField]
	public sbyte HealingCount = other.HealingCount;

	[SerializableGameDataField]
	public sbyte DetoxCount = other.DetoxCount;

	[SerializableGameDataField]
	public sbyte BreathingCount = other.BreathingCount;

	[SerializableGameDataField]
	public sbyte RecoverCount = other.RecoverCount;

	public const sbyte BaseCount = 1;

	public const sbyte MaxCount = 99;

	public void Assign(CombatResources other)
	{
		HealingCount = other.HealingCount;
		DetoxCount = other.DetoxCount;
		BreathingCount = other.BreathingCount;
		RecoverCount = other.RecoverCount;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 6;
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
		*num = (byte)HealingCount;
		byte* num2 = num + 1;
		*num2 = (byte)DetoxCount;
		byte* num3 = num2 + 1;
		*num3 = (byte)BreathingCount;
		byte* num4 = num3 + 1;
		*num4 = (byte)RecoverCount;
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
			HealingCount = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (num > 1)
		{
			DetoxCount = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (num > 2)
		{
			BreathingCount = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (num > 3)
		{
			RecoverCount = (sbyte)(*pCurrData);
			pCurrData++;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	private static sbyte ClampCount(int count)
	{
		return (sbyte)Math.Clamp(count, 0, 99);
	}

	public CombatResources Sub(CombatResources used)
	{
		return new CombatResources
		{
			HealingCount = ClampCount(HealingCount - used.HealingCount),
			DetoxCount = ClampCount(DetoxCount - used.DetoxCount),
			BreathingCount = ClampCount(BreathingCount - used.BreathingCount),
			RecoverCount = ClampCount(RecoverCount - used.RecoverCount)
		};
	}

	public sbyte Get(EHealActionType healType)
	{
		return healType switch
		{
			EHealActionType.Healing => HealingCount, 
			EHealActionType.Detox => DetoxCount, 
			EHealActionType.Breathing => BreathingCount, 
			EHealActionType.Recover => RecoverCount, 
			_ => throw new ArgumentOutOfRangeException("healType", healType, null), 
		};
	}

	public void Set(EHealActionType healType, int count)
	{
		switch (healType)
		{
		case EHealActionType.Healing:
		{
			sbyte b = (HealingCount = ClampCount(count));
			break;
		}
		case EHealActionType.Detox:
		{
			sbyte b = (DetoxCount = ClampCount(count));
			break;
		}
		case EHealActionType.Breathing:
		{
			sbyte b = (BreathingCount = ClampCount(count));
			break;
		}
		case EHealActionType.Recover:
		{
			sbyte b = (RecoverCount = ClampCount(count));
			break;
		}
		default:
			throw new ArgumentOutOfRangeException("healType", healType, null);
		}
	}

	public void Change(EHealActionType healType, int delta)
	{
		Set(healType, Get(healType) + delta);
	}
}
