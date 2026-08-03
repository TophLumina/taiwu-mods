using System;
using GameData.Serializer;

namespace GameData.Domains.Character;

/// <summary>
/// 战斗资源
/// </summary>
[SerializableGameData(NotForArchive = true, IsExtensible = true)]
public struct CombatResources : ISerializableGameData
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

	/// <summary>
	/// 疗伤次数
	/// </summary>
	[SerializableGameDataField]
	public sbyte HealingCount;

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
	/// 复元次数
	/// </summary>
	[SerializableGameDataField]
	public sbyte RecoverCount;

	/// <summary>
	/// 基础次数
	/// </summary>
	public const sbyte BaseCount = 1;

	/// <summary>
	/// 次数上限
	/// </summary>
	public const sbyte MaxCount = 99;

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public CombatResources(CombatResources other)
	{
		HealingCount = other.HealingCount;
		DetoxCount = other.DetoxCount;
		BreathingCount = other.BreathingCount;
		RecoverCount = other.RecoverCount;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(CombatResources other)
	{
		HealingCount = other.HealingCount;
		DetoxCount = other.DetoxCount;
		BreathingCount = other.BreathingCount;
		RecoverCount = other.RecoverCount;
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
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
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

	/// <summary>
	/// 获取某个使用次数
	/// </summary>
	/// <param name="healType"></param>
	/// <returns></returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException"></exception>
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

	/// <summary>
	/// 设置某个使用次数
	/// </summary>
	/// <param name="healType"></param>
	/// <param name="count"></param>
	/// <returns></returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException"></exception>
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

	/// <summary>
	/// 变化某个使用次数
	/// </summary>
	/// <param name="healType"></param>
	/// <param name="delta">正值为增加次数，负值为减少次数</param>
	/// <exception cref="T:System.ArgumentOutOfRangeException"></exception>
	public void Change(EHealActionType healType, int delta)
	{
		Set(healType, Get(healType) + delta);
	}
}
