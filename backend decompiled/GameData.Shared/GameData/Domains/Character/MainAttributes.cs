using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using GameData.Serializer;

namespace GameData.Domains.Character;

/// <summary>
/// 主要属性
/// </summary>
[Serializable]
public struct MainAttributes : ISerializableGameData, ISerializable
{
	/// <summary>
	/// *** 定长数组中的数据在创建对象时并未初始化 ***
	/// 排列顺序参见 <see cref="T:GameData.Domains.Character.MainAttributeType" />
	/// </summary>
	public unsafe fixed short Items[6];

	/// <summary>
	/// 直接通过 index 安全访问数据的接口.
	/// 主要用于对性能要求不是特别严格的情况 (非过月逻辑中频繁调用或可能每帧多次调用的逻辑皆可)
	/// </summary>
	/// <param name="index">毒素类型<see cref="T:GameData.Domains.Character.MainAttributeType" /></param>
	public unsafe ref short this[int index]
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			if (index < 0 || index >= 6)
			{
				throw new IndexOutOfRangeException($"index {index} is out of range [0,{6})");
			}
			return ref Items[index];
		}
	}

	/// <summary>
	/// 初始化对象, 为 fixed size buffer 填充默认值.
	/// 其实现依赖 MainAttributeType.Count == 6.
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
	/// <param name="attributes"></param>
	public unsafe MainAttributes(params short[] attributes)
	{
		for (int i = 0; i < 6; i++)
		{
			Items[i] = attributes[i];
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

	public unsafe MainAttributes(SerializationInfo info, StreamingContext context)
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
	/// 计算所有属性值的总和
	/// </summary>
	/// <returns></returns>
	public unsafe int GetSum()
	{
		int sum = 0;
		for (int i = 0; i < 6; i++)
		{
			sum += Items[i];
		}
		return sum;
	}

	/// <summary>
	/// 计算并返回两者的差值
	/// </summary>
	/// <param name="other"></param>
	/// <returns></returns>
	public unsafe MainAttributes Subtract(MainAttributes other)
	{
		MainAttributes delta = default(MainAttributes);
		for (int i = 0; i < 6; i++)
		{
			delta.Items[i] = (short)(Items[i] - other.Items[i]);
		}
		return delta;
	}

	/// <summary>
	/// 获取倒转了正负号后的对象
	/// </summary>
	public unsafe MainAttributes GetReversed()
	{
		MainAttributes reversed = default(MainAttributes);
		for (int i = 0; i < 6; i++)
		{
			reversed.Items[i] = (short)(-Items[i]);
		}
		return reversed;
	}

	/// <summary>
	/// 取值
	/// </summary>
	/// <param name="type"></param>
	/// <returns></returns>
	public unsafe short Get(sbyte type)
	{
		return Items[type];
	}

	/// <summary>
	/// 比较拥有的主要属性是否满足需求
	/// </summary>
	/// <param name="needMainAttributes"></param>
	/// <returns></returns>
	public unsafe bool CheckIsMeet(ref MainAttributes needMainAttributes)
	{
		for (int i = 0; i < 6; i++)
		{
			if (Items[i] < needMainAttributes.Items[i])
			{
				return false;
			}
		}
		return true;
	}

	/// <summary>
	/// 比较拥有的资源是否满足需求
	/// </summary>
	/// <returns></returns>
	public unsafe bool CheckIsMeet(sbyte type, int value)
	{
		return Items[type] >= value;
	}
}
