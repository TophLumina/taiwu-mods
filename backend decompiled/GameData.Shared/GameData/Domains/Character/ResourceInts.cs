using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Config;
using GameData.Serializer;

namespace GameData.Domains.Character;

/// <summary>
/// 各种资源的量
/// </summary>
[Serializable]
public struct ResourceInts : ISerializableGameData, ISerializable, IEnumerable<int>, IEnumerable
{
	/// <summary>
	/// *** 定长数组中的数据在创建对象时并未初始化 ***
	/// 排列顺序参见 <see cref="T:GameData.Domains.Character.ResourceType" />
	/// </summary>
	public unsafe fixed int Items[8];

	/// <summary>
	/// 直接通过 index 安全访问数据的接口.
	/// 主要用于对性能要求不是特别严格的情况 (非过月逻辑中频繁调用或可能每帧多次调用的逻辑皆可)
	/// </summary>
	/// <param name="index">资源类型<see cref="T:GameData.Domains.Character.ResourceType" /></param>
	public unsafe ref int this[int index]
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			if (index < 0 || index >= 8)
			{
				throw new IndexOutOfRangeException($"index {index} is out of range [0,{8})");
			}
			return ref Items[index];
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	/// <summary>
	/// 获取迭代器，方便Linq使用
	/// </summary>
	/// <returns></returns>
	public IEnumerator<int> GetEnumerator()
	{
		for (int i = 0; i < 8; i++)
		{
			yield return this[i];
		}
	}

	/// <summary>
	/// 获取某一项，性能详见<see cref="P:GameData.Domains.Character.ResourceInts.Item(System.Int32)" />
	/// </summary>
	/// <param name="index"></param>
	/// <returns></returns>
	public int Get(int index)
	{
		return this[index];
	}

	/// <summary>
	/// 设置某一项，性能详见<see cref="P:GameData.Domains.Character.ResourceInts.Item(System.Int32)" />
	/// </summary>
	/// <param name="index"></param>
	/// <param name="value"></param>
	/// <returns></returns>
	public int Set(int index, int value)
	{
		return this[index] = value;
	}

	/// <summary>
	/// 改变某一项，性能详见<see cref="P:GameData.Domains.Character.ResourceInts.Item(System.Int32)" />
	/// </summary>
	/// <param name="index"></param>
	/// <param name="delta"></param>
	/// <returns></returns>
	public int Change(int index, int delta)
	{
		return this[index] += delta;
	}

	/// <summary>
	/// 初始化对象, 为 fixed size buffer 填充默认值.
	/// 其实现依赖 ResourceType.Count == 8.
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
			((long*)items)[3] = 0L;
		}
	}

	/// <summary>
	/// 从配置表构造对象
	/// </summary>
	/// <param name="amounts"></param>
	public unsafe ResourceInts(params int[] amounts)
	{
		for (int i = 0; i < 8; i++)
		{
			Items[i] = amounts[i];
		}
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		return 32;
	}

	public unsafe int Serialize(byte* pData)
	{
		fixed (int* pItems = Items)
		{
			*(long*)pData = *(long*)pItems;
			((long*)pData)[1] = ((long*)pItems)[1];
			((long*)pData)[2] = ((long*)pItems)[2];
			((long*)pData)[3] = ((long*)pItems)[3];
		}
		return 32;
	}

	public unsafe int Deserialize(byte* pData)
	{
		fixed (int* items = Items)
		{
			*(long*)items = *(long*)pData;
			((long*)items)[1] = ((long*)pData)[1];
			((long*)items)[2] = ((long*)pData)[2];
			((long*)items)[3] = ((long*)pData)[3];
		}
		return 32;
	}

	public unsafe ResourceInts(SerializationInfo info, StreamingContext context)
	{
		fixed (int* items = Items)
		{
			*(ulong*)items = info.GetUInt64("0");
			((long*)items)[1] = (long)info.GetUInt64("1");
			((long*)items)[2] = (long)info.GetUInt64("2");
			((long*)items)[3] = (long)info.GetUInt64("3");
		}
	}

	public unsafe void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		fixed (int* pItems = Items)
		{
			info.AddValue("0", *(ulong*)pItems);
			info.AddValue("1", ((ulong*)pItems)[1]);
			info.AddValue("2", ((ulong*)pItems)[2]);
			info.AddValue("3", ((ulong*)pItems)[3]);
		}
	}

	/// <summary>
	/// 添加资源.
	/// 资源的数量不能小于零.
	/// </summary>
	/// <param name="delta"></param>
	public unsafe void Add(ref ResourceInts delta)
	{
		for (int i = 0; i < 8; i++)
		{
			Add((sbyte)i, delta.Items[i]);
		}
	}

	/// <summary>
	/// 添加资源，资源的数量不能小于零
	/// </summary>
	/// <param name="type"></param>
	/// <param name="value"></param>
	public unsafe void Add(sbyte type, int value)
	{
		int result = Items[type] + value;
		if (value < 0)
		{
			throw new Exception($"Resource amount cannot be negative: {type}, {value}");
		}
		if (result > 999999999)
		{
			result = 999999999;
		}
		Items[type] = result;
	}

	/// <summary>
	/// 减少资源，资源的数量不能小于零
	/// </summary>
	/// <param name="type"></param>
	/// <param name="value"></param>
	public unsafe void Subtract(sbyte type, int value)
	{
		int result = Items[type] - value;
		if (value < 0)
		{
			throw new Exception($"Resource amount cannot be negative: {type}, {value}");
		}
		Items[type] = result;
	}

	/// <summary>
	/// 计算并返回两者的差值
	/// </summary>
	/// <param name="other"></param>
	/// <returns></returns>
	public unsafe ResourceInts Subtract(ref ResourceInts other)
	{
		ResourceInts delta = default(ResourceInts);
		for (int i = 0; i < 8; i++)
		{
			delta.Items[i] = Items[i] - other.Items[i];
		}
		return delta;
	}

	/// <summary>
	/// 获取倒转了正负号后的对象
	/// </summary>
	public unsafe ResourceInts GetReversed()
	{
		ResourceInts reversed = default(ResourceInts);
		for (int i = 0; i < 8; i++)
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
		for (int i = 0; i < 8; i++)
		{
			if (Items[i] != 0)
			{
				return true;
			}
		}
		return false;
	}

	/// <summary>
	/// 比较拥有的资源是否满足需求
	/// </summary>
	/// <param name="needResources"></param>
	/// <returns></returns>
	public unsafe bool CheckIsMeet(ref ResourceInts needResources)
	{
		for (int i = 0; i < 8; i++)
		{
			if (Items[i] < needResources.Items[i])
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

	/// <summary>
	/// 获取总和
	/// </summary>
	/// <returns></returns>
	public unsafe int GetSum()
	{
		int sum = 0;
		for (int i = 0; i < 8; i++)
		{
			sum += Items[i];
		}
		return sum;
	}

	/// <summary>
	/// 获取总价值
	/// </summary>
	/// <returns></returns>
	public unsafe long GetValueSum()
	{
		return (long)Items[0] * (long)Misc.DefValue.ResourceFood.BaseValue + (long)Items[1] * (long)Misc.DefValue.ResourceWood.BaseValue + (long)Items[2] * (long)Misc.DefValue.ResourceMetal.BaseValue + (long)Items[3] * (long)Misc.DefValue.ResourceJade.BaseValue + (long)Items[4] * (long)Misc.DefValue.ResourceFabric.BaseValue + (long)Items[5] * (long)Misc.DefValue.ResourceHerb.BaseValue + (long)Items[6] * (long)Misc.DefValue.ResourceMoney.BaseValue + (long)Items[7] * (long)Misc.DefValue.ResourceAuthority.BaseValue;
	}

	/// <summary>
	/// 获取最大数量的资源类型
	/// </summary>
	/// <returns></returns>
	public sbyte GetMaxType()
	{
		return GetMaxType(8);
	}

	/// <summary>
	/// 获取最大数量的材料资源类型
	/// </summary>
	/// <returns></returns>
	public sbyte GetMaxMaterialType()
	{
		return GetMaxType(6);
	}

	/// <summary>
	/// 获取最大数量的财富资源类型
	/// </summary>
	/// <returns></returns>
	public sbyte GetMaxWealthType()
	{
		return GetMaxType(7);
	}

	private unsafe sbyte GetMaxType(int count)
	{
		sbyte maxType = 0;
		int maxValue = 0;
		for (sbyte resourceType = 0; resourceType < count; resourceType++)
		{
			if (Items[resourceType] > maxValue)
			{
				maxValue = Items[resourceType];
				maxType = resourceType;
			}
		}
		return maxType;
	}
}
