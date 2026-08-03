using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using GameData.Serializer;

namespace GameData.Domains.Character;

/// <summary>
/// 毒素的量
/// </summary>
[Serializable]
public struct PoisonShorts : ISerializableGameData, ISerializable
{
	/// <summary>
	/// *** 定长数组中的数据在创建对象时并未初始化 ***
	/// 排列顺序参见 <see cref="T:GameData.Domains.Combat.PoisonType" />
	/// </summary>
	public unsafe fixed short Items[6];

	/// <summary>
	/// 直接通过 index 安全访问数据的接口.
	/// 主要用于对性能要求不是特别严格的情况 (非过月逻辑中频繁调用或可能每帧多次调用的逻辑皆可)
	/// </summary>
	/// <param name="index">毒素类型<see cref="T:GameData.Domains.Combat.PoisonType" /></param>
	public unsafe ref short this[int index]
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			if (index < 0 || index >= 6)
			{
				throw new IndexOutOfRangeException($"index {index} is out of range [0,{(sbyte)6})");
			}
			return ref Items[index];
		}
	}

	/// <summary>
	/// 初始化对象, 为 fixed size buffer 填充默认值.
	/// 其实现依赖 PoisonType.Count == 6.
	/// <see href="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/unsafe-code#definite-assignment-checking" />
	/// </summary>
	/// <returns></returns>
	public unsafe void Initialize()
	{
		fixed (short* items = Items)
		{
			*(long*)items = 0L;
			((int*)items)[2] = 0;
		}
	}

	/// <summary>
	/// 从配置表构造对象
	/// </summary>
	/// <param name="poisons"></param>
	public unsafe PoisonShorts(params int[] poisons)
	{
		for (int i = 0; i < 6; i++)
		{
			Items[i] = (short)poisons[i];
		}
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		return 12;
	}

	public unsafe int Serialize(byte* pData)
	{
		fixed (short* pItems = Items)
		{
			*(long*)pData = *(long*)pItems;
			((int*)pData)[2] = ((int*)pItems)[2];
		}
		return 12;
	}

	public unsafe int Deserialize(byte* pData)
	{
		fixed (short* items = Items)
		{
			*(long*)items = *(long*)pData;
			((int*)items)[2] = ((int*)pData)[2];
		}
		return 12;
	}

	public unsafe PoisonShorts(SerializationInfo info, StreamingContext context)
	{
		fixed (short* items = Items)
		{
			*(ulong*)items = info.GetUInt64("0");
			((int*)items)[2] = (int)info.GetUInt32("1");
		}
	}

	public unsafe void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		fixed (short* pItems = Items)
		{
			info.AddValue("0", *(ulong*)pItems);
			info.AddValue("1", ((uint*)pItems)[2]);
		}
	}

	/// <summary>
	/// 添加毒素量
	/// </summary>
	/// <param name="delta"></param>
	public unsafe void Add(PoisonShorts delta)
	{
		for (int i = 0; i < 6; i++)
		{
			int value = Items[i] + delta.Items[i];
			if (value < 0)
			{
				value = 0;
			}
			Items[i] = (short)value;
		}
	}

	/// <summary>
	/// 计算并返回两者的差值
	/// </summary>
	/// <param name="other"></param>
	/// <returns></returns>
	public unsafe PoisonShorts Subtract(PoisonShorts other)
	{
		PoisonShorts delta = default(PoisonShorts);
		for (int i = 0; i < 6; i++)
		{
			delta.Items[i] = (short)(Items[i] - other.Items[i]);
		}
		return delta;
	}

	/// <summary>
	/// 获取倒转了正负号后的对象
	/// </summary>
	public unsafe PoisonShorts GetReversed()
	{
		PoisonShorts reversed = default(PoisonShorts);
		for (int i = 0; i < 6; i++)
		{
			reversed.Items[i] = (short)(-Items[i]);
		}
		return reversed;
	}

	/// <summary>
	/// 是否含有非零值
	/// </summary>
	/// <returns></returns>
	public unsafe bool IsNonZero()
	{
		fixed (short* pItems = Items)
		{
			if (*(long*)pItems != 0L)
			{
				return true;
			}
			if (((uint*)pItems)[2] != 0)
			{
				return true;
			}
		}
		return false;
	}

	/// <summary>
	/// 获取和
	/// </summary>
	/// <returns></returns>
	public unsafe short Sum()
	{
		short sum = 0;
		for (int i = 0; i < 6; i++)
		{
			sum += Items[i];
		}
		return sum;
	}
}
