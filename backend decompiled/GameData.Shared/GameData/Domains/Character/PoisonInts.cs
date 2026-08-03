using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using GameData.Domains.Item;
using GameData.Serializer;

namespace GameData.Domains.Character;

/// <summary>
/// 毒素的量
/// </summary>
[Serializable]
public struct PoisonInts : ISerializableGameData, ISerializable
{
	/// <summary>
	/// *** 定长数组中的数据在创建对象时并未初始化 ***
	/// 排列顺序参见 <see cref="T:GameData.Domains.Combat.PoisonType" />
	/// </summary>
	public unsafe fixed int Items[6];

	/// <summary>
	/// 直接通过 index 安全访问数据的接口.
	/// 主要用于对性能要求不是特别严格的情况 (非过月逻辑中频繁调用或可能每帧多次调用的逻辑皆可)
	/// </summary>
	/// <param name="index">毒素类型<see cref="T:GameData.Domains.Combat.PoisonType" /></param>
	public unsafe ref int this[int index]
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
		fixed (int* items = Items)
		{
			*(long*)items = 0L;
			((long*)items)[1] = 0L;
			((long*)items)[2] = 0L;
		}
	}

	/// <summary>
	/// 从配置表构造对象
	/// </summary>
	/// <param name="poisons"></param>
	public unsafe PoisonInts(params int[] poisons)
	{
		for (int i = 0; i < 6; i++)
		{
			Items[i] = poisons[i];
		}
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		return 24;
	}

	public unsafe int Serialize(byte* pData)
	{
		fixed (int* pItems = Items)
		{
			*(long*)pData = *(long*)pItems;
			((long*)pData)[1] = ((long*)pItems)[1];
			((long*)pData)[2] = ((long*)pItems)[2];
		}
		return 24;
	}

	public unsafe int Deserialize(byte* pData)
	{
		fixed (int* items = Items)
		{
			*(long*)items = *(long*)pData;
			((long*)items)[1] = ((long*)pData)[1];
			((long*)items)[2] = ((long*)pData)[2];
		}
		return 24;
	}

	public unsafe PoisonInts(SerializationInfo info, StreamingContext context)
	{
		fixed (int* items = Items)
		{
			*(ulong*)items = info.GetUInt64("0");
			((long*)items)[1] = (long)info.GetUInt64("1");
			((long*)items)[2] = (long)info.GetUInt64("2");
		}
	}

	public unsafe void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		fixed (int* pItems = Items)
		{
			info.AddValue("0", *(ulong*)pItems);
			info.AddValue("1", ((ulong*)pItems)[1]);
			info.AddValue("2", ((ulong*)pItems)[2]);
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
			Items[i] = value;
		}
	}

	/// <summary>
	/// 添加毒素量
	/// </summary>
	/// <param name="delta"></param>
	public unsafe void Add(ref PoisonInts delta)
	{
		for (int i = 0; i < 6; i++)
		{
			int value = Items[i] + delta.Items[i];
			if (value < 0)
			{
				value = 0;
			}
			Items[i] = value;
		}
	}

	/// <summary>
	/// 计算并返回两者的差值
	/// </summary>
	/// <param name="other"></param>
	/// <returns></returns>
	public unsafe PoisonInts Subtract(ref PoisonInts other)
	{
		PoisonInts delta = default(PoisonInts);
		for (int i = 0; i < 6; i++)
		{
			delta.Items[i] = Items[i] - other.Items[i];
		}
		return delta;
	}

	/// <summary>
	/// 获取倒转了正负号后的对象
	/// </summary>
	public unsafe PoisonInts GetReversed()
	{
		PoisonInts reversed = default(PoisonInts);
		for (int i = 0; i < 6; i++)
		{
			reversed.Items[i] = -Items[i];
		}
		return reversed;
	}

	/// <summary>
	/// 是否含有非零值
	/// </summary>
	/// <returns></returns>
	public unsafe bool IsNonZero()
	{
		fixed (int* pItems = Items)
		{
			if (*(long*)pItems != 0L)
			{
				return true;
			}
			if (((long*)pItems)[1] != 0L)
			{
				return true;
			}
			if (((long*)pItems)[2] != 0L)
			{
				return true;
			}
		}
		return false;
	}

	public unsafe sbyte GetLightestType()
	{
		int count = 0;
		sbyte type = 0;
		for (sbyte i = 0; i < 6; i++)
		{
			if (Items[i] < count)
			{
				type = i;
				count = Items[i];
			}
		}
		return type;
	}

	/// <summary>
	/// 获取和
	/// </summary>
	/// <returns></returns>
	public unsafe int Sum()
	{
		int sum = 0;
		for (int i = 0; i < 6; i++)
		{
			sum += Items[i];
		}
		return sum;
	}

	/// <summary>
	/// 最大值
	/// </summary>
	/// <returns></returns>
	public unsafe int Max()
	{
		int max = 0;
		for (int i = 0; i < 6; i++)
		{
			max = Math.Max(max, Items[i]);
		}
		return max;
	}

	public unsafe bool Equals(PoisonInts other)
	{
		bool result = true;
		for (int i = 0; i < 6; i++)
		{
			if (Items[i] != other.Items[i])
			{
				result = false;
				break;
			}
		}
		return result;
	}

	/// <summary>
	/// 获取值
	/// </summary>
	/// <param name="index"></param>
	/// <returns></returns>
	public unsafe int Get(int index)
	{
		return Items[index];
	}

	public unsafe PoisonsAndLevels GetPoisonsAndLevels()
	{
		PoisonsAndLevels result = default(PoisonsAndLevels);
		result.Initialize();
		for (int i = 0; i < 6; i++)
		{
			result.Values[i] = (short)Items[i];
			result.Levels[i] = PoisonsAndLevels.CalcPoisonedLevel(Items[i]);
		}
		return result;
	}
}
