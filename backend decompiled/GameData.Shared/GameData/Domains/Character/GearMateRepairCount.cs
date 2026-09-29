using System;
using GameData.Serializer;

namespace GameData.Domains.Character;

[SerializableGameData(NotForArchive = true)]
public class GearMateRepairCount : ISerializableGameData
{
	[SerializableGameDataField]
	public sbyte OuterInjuryHealingCount;

	[SerializableGameDataField]
	public sbyte InnerInjuryHealingCount;

	[SerializableGameDataField]
	public sbyte DetoxCount;

	[SerializableGameDataField]
	public sbyte BreathingCount;

	public const sbyte BaseCount = 1;

	public const sbyte MaxCount = 99;

	public GearMateRepairCount()
	{
		OuterInjuryHealingCount = 0;
		InnerInjuryHealingCount = 0;
		DetoxCount = 0;
		BreathingCount = 0;
	}

	private static sbyte ClampCount(int count)
	{
		return (sbyte)Math.Clamp(count, 0, 99);
	}

	public GearMateRepairCount Sub(GearMateRepairCount other)
	{
		return new GearMateRepairCount
		{
			OuterInjuryHealingCount = ClampCount(OuterInjuryHealingCount - other.OuterInjuryHealingCount),
			InnerInjuryHealingCount = ClampCount(InnerInjuryHealingCount - other.InnerInjuryHealingCount),
			DetoxCount = ClampCount(DetoxCount - other.DetoxCount),
			BreathingCount = ClampCount(BreathingCount - other.BreathingCount)
		};
	}

	public void Set(sbyte type, int count)
	{
		switch (type)
		{
		case 0:
		{
			sbyte b = (OuterInjuryHealingCount = ClampCount(count));
			break;
		}
		case 1:
		{
			sbyte b = (InnerInjuryHealingCount = ClampCount(count));
			break;
		}
		case 2:
		{
			sbyte b = (DetoxCount = ClampCount(count));
			break;
		}
		case 3:
		{
			sbyte b = (BreathingCount = ClampCount(count));
			break;
		}
		default:
			throw new ArgumentOutOfRangeException("type", type, null);
		}
	}

	public sbyte Get(sbyte type)
	{
		return type switch
		{
			0 => OuterInjuryHealingCount, 
			1 => InnerInjuryHealingCount, 
			2 => DetoxCount, 
			3 => BreathingCount, 
			_ => throw new ArgumentOutOfRangeException("type", type, null), 
		};
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
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
		*pData = (byte)OuterInjuryHealingCount;
		byte* num = pData + 1;
		*num = (byte)InnerInjuryHealingCount;
		byte* num2 = num + 1;
		*num2 = (byte)DetoxCount;
		byte* num3 = num2 + 1;
		*num3 = (byte)BreathingCount;
		int totalSize = (int)(num3 + 1 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		OuterInjuryHealingCount = (sbyte)(*pCurrData);
		pCurrData++;
		InnerInjuryHealingCount = (sbyte)(*pCurrData);
		pCurrData++;
		DetoxCount = (sbyte)(*pCurrData);
		pCurrData++;
		BreathingCount = (sbyte)(*pCurrData);
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
