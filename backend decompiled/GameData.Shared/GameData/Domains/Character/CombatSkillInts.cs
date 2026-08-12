using System;
using System.Runtime.CompilerServices;
using GameData.Serializer;

namespace GameData.Domains.Character;

/// <summary>
/// 各种武学类型对应的值
/// </summary>
public struct CombatSkillInts : ISerializableGameData
{
	/// <summary>
	/// *** 定长数组中的数据在创建对象时并未初始化 ***
	/// 排列顺序参见 <see cref="T:GameData.Domains.CombatSkill.CombatSkillType" />
	/// </summary>
	public unsafe fixed int Items[14];

	/// <summary>
	/// 直接通过 index 安全访问数据的接口.
	/// 主要用于对性能要求不是特别严格的情况 (非过月逻辑中频繁调用或可能每帧多次调用的逻辑皆可)
	/// </summary>
	/// <param name="index">武学类型<see cref="T:GameData.Domains.CombatSkill.CombatSkillType" /></param>
	public unsafe ref int this[int index]
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			if (index < 0 || index >= 14)
			{
				throw new IndexOutOfRangeException($"index {index} is out of range [0,{14})");
			}
			return ref Items[index];
		}
	}

	/// <summary>
	/// 初始化对象, 为 fixed size buffer 填充默认值.
	/// <see href="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/unsafe-code#definite-assignment-checking" />
	/// </summary>
	/// <returns></returns>
	public unsafe void Initialize()
	{
		for (int i = 0; i < 14; i++)
		{
			Items[i] = 0;
		}
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		return 56;
	}

	public unsafe int Serialize(byte* pData)
	{
		for (int i = 0; i < 14; i++)
		{
			((int*)pData)[i] = Items[i];
		}
		return 56;
	}

	public unsafe int Deserialize(byte* pData)
	{
		for (int i = 0; i < 14; i++)
		{
			Items[i] = ((int*)pData)[i];
		}
		return 56;
	}

	/// <summary>
	/// 计算并返回两者的差值
	/// </summary>
	/// <param name="other"></param>
	/// <returns></returns>
	public unsafe CombatSkillInts Subtract(ref CombatSkillInts other)
	{
		CombatSkillInts delta = default(CombatSkillInts);
		for (int i = 0; i < 14; i++)
		{
			delta.Items[i] = Items[i] - other.Items[i];
		}
		return delta;
	}

	/// <summary>
	/// 获取倒转了正负号后的对象
	/// </summary>
	public unsafe CombatSkillInts GetReversed()
	{
		CombatSkillInts reversed = default(CombatSkillInts);
		for (int i = 0; i < 14; i++)
		{
			reversed.Items[i] = -Items[i];
		}
		return reversed;
	}
}
