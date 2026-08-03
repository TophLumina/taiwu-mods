using System;
using GameData.Serializer;

namespace GameData.Domains.Character;

/// <summary>
/// 内力分配值
/// </summary>
public struct NeiliAllocation : ISerializableGameData
{
	/// <summary>
	/// *** 定长数组中的数据在创建对象时并未初始化 ***
	/// 排列顺序参见 <see cref="T:GameData.Domains.Character.NeiliAllocationType" />
	/// </summary>
	public unsafe fixed short Items[4];

	/// <summary>
	/// 替代 unsafe 调用的真气值获取接口
	/// </summary>
	public unsafe ref short this[int neiliAllocationType]
	{
		get
		{
			if ((neiliAllocationType < 0 || neiliAllocationType >= 4) ? true : false)
			{
				throw new IndexOutOfRangeException("neiliAllocationType");
			}
			return ref Items[neiliAllocationType];
		}
	}

	/// <summary>
	/// 初始化对象, 为 fixed size buffer 填充默认值.
	/// 其实现依赖 NeiliAllocationType.Count == 4.
	/// <see href="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/unsafe-code#definite-assignment-checking" />
	/// </summary>
	/// <returns></returns>
	public unsafe void Initialize()
	{
		fixed (short* items = Items)
		{
			*(long*)items = 0L;
		}
	}

	/// <summary>
	/// 用于配置的构造方法
	/// </summary>
	public unsafe NeiliAllocation(short val0, short val1, short val2, short val3)
	{
		Items[0] = val0;
		Items[1] = val1;
		Items[2] = val2;
		Items[3] = val3;
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		return 8;
	}

	public unsafe int Serialize(byte* pData)
	{
		fixed (short* pItems = Items)
		{
			*(long*)pData = *(long*)pItems;
		}
		return 8;
	}

	public unsafe int Deserialize(byte* pData)
	{
		fixed (short* items = Items)
		{
			*(long*)items = *(long*)pData;
		}
		return 8;
	}

	/// <summary>
	/// 相等判断.
	/// 其实现依赖 NeiliAllocationType.Count == 4.
	/// </summary>
	public unsafe static bool Equals(NeiliAllocation lhs, NeiliAllocation rhs)
	{
		return *(long*)(&lhs) == *(long*)(&rhs);
	}

	/// <summary>
	/// 获取内力分配总值.
	/// 其实现依赖 NeiliAllocationType.Count == 4.
	/// </summary>
	/// <returns></returns>
	public unsafe short GetTotal()
	{
		return (short)(Items[0] + Items[1] + Items[2] + Items[3]);
	}

	/// <summary>
	/// 计算并返回两者的差值
	/// </summary>
	/// <param name="other"></param>
	/// <returns></returns>
	public unsafe NeiliAllocation Subtract(NeiliAllocation other)
	{
		NeiliAllocation delta = default(NeiliAllocation);
		for (int i = 0; i < 4; i++)
		{
			delta.Items[i] = (short)(Items[i] - other.Items[i]);
		}
		return delta;
	}

	/// <summary>
	/// 获取倒转了正负号后的对象
	/// </summary>
	public unsafe NeiliAllocation GetReversed()
	{
		NeiliAllocation reversed = default(NeiliAllocation);
		for (int i = 0; i < 4; i++)
		{
			reversed.Items[i] = (short)(-Items[i]);
		}
		return reversed;
	}

	/// <summary>
	/// 获取半数
	/// </summary>
	public unsafe NeiliAllocation GetHalf()
	{
		NeiliAllocation half = default(NeiliAllocation);
		for (int i = 0; i < 4; i++)
		{
			half.Items[i] = (short)(Items[i] / 2);
		}
		return half;
	}

	/// <summary>
	/// 获取最大值的真气类型
	/// </summary>
	/// <returns><see cref="T:GameData.Domains.Character.NeiliAllocationType" />&gt;</returns>
	public unsafe byte GetMaxType()
	{
		byte maxType = 0;
		short maxValue = Items[(int)maxType];
		for (byte type = 1; type < 4; type++)
		{
			if (Items[(int)type] > maxValue)
			{
				maxType = type;
				maxValue = Items[(int)type];
			}
		}
		return maxType;
	}

	/// <summary>
	/// 获取所有真气之和
	/// </summary>
	public unsafe int Sum()
	{
		int sum = 0;
		for (int i = 0; i < 4; i++)
		{
			sum += Items[i];
		}
		return sum;
	}

	/// <inheritdoc />
	public unsafe override string ToString()
	{
		return $"NeiliAllocation{{{Items[0]}, {Items[1]}, {Items[2]}, {Items[3]}}}";
	}
}
