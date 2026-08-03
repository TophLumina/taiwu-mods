using System;
using GameData.Serializer;

namespace GameData.Domains.Character;

/// <summary>
///
/// </summary>
[SerializableGameData(NotForArchive = true)]
public class GearMateRepairCount : ISerializableGameData
{
	/// <summary>
	/// 疗伤次数
	/// </summary>
	[SerializableGameDataField]
	public sbyte OuterInjuryHealingCount;

	/// <summary>
	/// 复元次数
	/// </summary>
	[SerializableGameDataField]
	public sbyte InnerInjuryHealingCount;

	/// <summary>
	/// 驱毒次数
	/// </summary>
	[SerializableGameDataField]
	public sbyte DetoxCount;

	/// <summary>
	/// 调息次数
	/// </summary>
	[SerializableGameDataField]
	public sbyte BreathingCount;

	/// <summary>
	/// 基础次数
	/// </summary>
	public const sbyte BaseCount = 1;

	/// <summary>
	/// 次数上限
	/// </summary>
	public const sbyte MaxCount = 99;

	public GearMateRepairCount()
	{
		OuterInjuryHealingCount = 0;
		InnerInjuryHealingCount = 0;
		DetoxCount = 0;
		BreathingCount = 0;
	}

	/// <summary>
	/// 将某个使用次数限定在有效范围内
	/// </summary>
	/// <param name="count"></param>
	/// <returns></returns>
	private static sbyte ClampCount(int count)
	{
		return (sbyte)Math.Clamp(count, 0, 99);
	}

	/// <summary>
	/// 减去已使用次数
	/// </summary>
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

	/// <summary>
	///
	/// </summary>
	/// <param name="type"></param>
	/// <param name="count"></param>
	/// <exception cref="T:System.ArgumentOutOfRangeException"></exception>
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

	/// <summary>
	/// 获取某个使用次数
	/// </summary>
	/// <param name="type"></param>
	/// <returns></returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException"></exception>
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return true;
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
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
