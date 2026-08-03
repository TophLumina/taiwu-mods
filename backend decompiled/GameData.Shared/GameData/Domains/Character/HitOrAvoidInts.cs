using System;
using System.Runtime.Serialization;
using GameData.Serializer;

namespace GameData.Domains.Character;

/// <summary>
/// 命中或化解值
/// </summary>
[Serializable]
public struct HitOrAvoidInts : ISerializableGameData, ISerializable
{
	/// <summary>
	/// *** 定长数组中的数据在创建对象时并未初始化 ***
	/// 排列顺序参见 <see cref="T:GameData.Domains.CombatSkill.AttackHitType" />
	/// </summary>
	public unsafe fixed int Items[4];

	/// <summary>
	/// 替代 unsafe 调用的数据获取接口
	/// </summary>
	/// <param name="index"><see cref="T:GameData.Domains.CombatSkill.AttackHitType" /></param>
	public unsafe int this[int index]
	{
		get
		{
			if ((index < 0 || index >= 4) ? true : false)
			{
				throw new IndexOutOfRangeException($"index {index} is out of range [0,{4})");
			}
			return Items[index];
		}
		set
		{
			if ((index < 0 || index >= 4) ? true : false)
			{
				throw new IndexOutOfRangeException($"index {index} is out of range [0,{4})");
			}
			Items[index] = value;
		}
	}

	/// <summary>
	/// 初始化对象, 为 fixed size buffer 填充默认值.
	/// 其实现依赖 AttackHitType.Count == 4.
	/// <see href="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/unsafe-code#definite-assignment-checking" />
	/// </summary>
	/// <returns></returns>
	public unsafe void Initialize()
	{
		fixed (int* items = Items)
		{
			*(long*)items = 0L;
			((long*)items)[1] = 0L;
		}
	}

	/// <summary>
	/// 从配置表构造对象
	/// </summary>
	/// <param name="values"></param>
	public unsafe HitOrAvoidInts(params int[] values)
	{
		for (int i = 0; i < 4; i++)
		{
			Items[i] = values[i];
		}
	}

	public static implicit operator HitOrAvoidInts(HitOrAvoidShorts shorts)
	{
		HitOrAvoidInts ints = default(HitOrAvoidInts);
		for (int i = 0; i < 4; i++)
		{
			ints[i] = shorts[i];
		}
		return ints;
	}

	public static explicit operator HitOrAvoidShorts(HitOrAvoidInts ints)
	{
		HitOrAvoidShorts shorts = default(HitOrAvoidShorts);
		for (int i = 0; i < 4; i++)
		{
			shorts[i] = (short)Math.Clamp(ints[i], -32768, 32767);
		}
		return shorts;
	}

	public static HitOrAvoidInts operator +(HitOrAvoidInts lhs, HitOrAvoidInts rhs)
	{
		for (int i = 0; i < 4; i++)
		{
			lhs[i] += rhs[i];
		}
		return lhs;
	}

	public static HitOrAvoidInts operator -(HitOrAvoidInts lhs, HitOrAvoidInts rhs)
	{
		for (int i = 0; i < 4; i++)
		{
			lhs[i] -= rhs[i];
		}
		return lhs;
	}

	public static HitOrAvoidInts operator /(HitOrAvoidInts ints, int divisor)
	{
		for (int i = 0; i < 4; i++)
		{
			ints[i] /= divisor;
		}
		return ints;
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		return 16;
	}

	public unsafe int Serialize(byte* pData)
	{
		fixed (int* pItems = Items)
		{
			*(long*)pData = *(long*)pItems;
			((long*)pData)[1] = ((long*)pItems)[1];
		}
		return 16;
	}

	public unsafe int Deserialize(byte* pData)
	{
		fixed (int* items = Items)
		{
			*(long*)items = *(long*)pData;
			((long*)items)[1] = ((long*)pData)[1];
		}
		return 16;
	}

	public unsafe HitOrAvoidInts(SerializationInfo info, StreamingContext context)
	{
		fixed (int* items = Items)
		{
			*(ulong*)items = info.GetUInt64("0");
			((long*)items)[1] = (long)info.GetUInt64("1");
		}
	}

	public unsafe void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		fixed (int* pItems = Items)
		{
			info.AddValue("0", *(ulong*)pItems);
			info.AddValue("1", ((ulong*)pItems)[1]);
		}
	}
}
