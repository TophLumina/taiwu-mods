using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using GameData.Serializer;

namespace GameData.Domains.Map;

/// <summary>
/// 材料资源
/// </summary>
[Serializable]
public struct MaterialResources : ISerializableGameData, ISerializable
{
	/// <summary>
	/// *** 定长数组中的数据在创建对象时并未初始化 ***
	/// 排列顺序参见 <see cref="T:GameData.Domains.Character.ResourceType" />
	/// </summary>
	public unsafe fixed short Items[6];

	/// <summary>
	/// 直接通过 index 安全访问数据的接口.
	/// 主要用于对性能要求不是特别严格的情况 (非过月逻辑中频繁调用或可能每帧多次调用的逻辑皆可)
	/// </summary>
	/// <param name="index">资源类型<see cref="T:GameData.Domains.Character.ResourceType" /></param>
	public unsafe ref short this[int index]
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

	/// <summary>
	/// 获取某一项，性能详见<see cref="P:GameData.Domains.Map.MaterialResources.Item(System.Int32)" />
	/// </summary>
	/// <param name="index"></param>
	/// <returns></returns>
	public short Get(int index)
	{
		return this[index];
	}

	/// <summary>
	/// 设置某一项，性能详见<see cref="P:GameData.Domains.Map.MaterialResources.Item(System.Int32)" />
	/// </summary>
	/// <param name="index"></param>
	/// <param name="value"></param>
	/// <returns></returns>
	public short Set(int index, short value)
	{
		return this[index] = value;
	}

	/// <summary>
	/// 改变某一项，性能详见<see cref="P:GameData.Domains.Map.MaterialResources.Item(System.Int32)" />
	/// </summary>
	/// <param name="index"></param>
	/// <param name="delta"></param>
	/// <returns></returns>
	public short Change(int index, short delta)
	{
		return this[index] += delta;
	}

	/// <summary>
	/// 初始化对象, 为 fixed size buffer 填充默认值.
	/// 其实现依赖 ResourceType.MaterialResourceCount == 6.
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
	/// <param name="materialResources"></param>
	public unsafe MaterialResources(params short[] materialResources)
	{
		for (int resourceType = 0; resourceType < 6; resourceType++)
		{
			Items[resourceType] = materialResources[resourceType];
		}
	}

	/// <summary>
	/// 获得资源总数
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
	/// 添加资源.
	/// 资源的数量不能小于零.
	/// </summary>
	/// <param name="delta"></param>
	public unsafe void Add(ref MaterialResources delta)
	{
		for (int i = 0; i < 6; i++)
		{
			Add((sbyte)i, delta.Items[i]);
		}
	}

	/// <summary>
	/// 添加资源，资源的数量不能小于零
	/// </summary>
	/// <param name="type"></param>
	/// <param name="value"></param>
	public unsafe void Add(sbyte type, short value)
	{
		int result = Items[type] + value;
		if (value < 0)
		{
			throw new Exception($"Resource amount cannot be negative: {type}, {value}");
		}
		Items[type] = (short)result;
	}

	public unsafe MaterialResources(SerializationInfo info, StreamingContext context)
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
}
