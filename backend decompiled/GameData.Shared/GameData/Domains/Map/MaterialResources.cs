using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using GameData.Serializer;

namespace GameData.Domains.Map;

[Serializable]
public struct MaterialResources : ISerializableGameData, ISerializable
{
	public unsafe fixed short Items[6];

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

	public short Get(int index)
	{
		return this[index];
	}

	public short Set(int index, short value)
	{
		return this[index] = value;
	}

	public short Change(int index, short delta)
	{
		return this[index] += delta;
	}

	public unsafe void Initialize()
	{
		fixed (short* items = Items)
		{
			*(long*)items = 0L;
			((int*)items)[2] = 0;
		}
	}

	public unsafe MaterialResources(params short[] materialResources)
	{
		for (int resourceType = 0; resourceType < 6; resourceType++)
		{
			Items[resourceType] = materialResources[resourceType];
		}
	}

	public unsafe int GetSum()
	{
		int sum = 0;
		for (int i = 0; i < 6; i++)
		{
			sum += Items[i];
		}
		return sum;
	}

	public unsafe void Add(ref MaterialResources delta)
	{
		for (int i = 0; i < 6; i++)
		{
			Add((sbyte)i, delta.Items[i]);
		}
	}

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
