using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Config;
using GameData.Serializer;

namespace GameData.Domains.Character;

[Serializable]
public struct ResourceInts : ISerializableGameData, ISerializable, IEnumerable<int>, IEnumerable
{
	public unsafe fixed int Items[8];

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

	public IEnumerator<int> GetEnumerator()
	{
		for (int i = 0; i < 8; i++)
		{
			yield return this[i];
		}
	}

	public int Get(int index)
	{
		return this[index];
	}

	public int Set(int index, int value)
	{
		return this[index] = value;
	}

	public int Change(int index, int delta)
	{
		return this[index] += delta;
	}

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

	public unsafe void Add(ref ResourceInts delta)
	{
		for (int i = 0; i < 8; i++)
		{
			Add((sbyte)i, delta.Items[i]);
		}
	}

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

	public unsafe void Subtract(sbyte type, int value)
	{
		int result = Items[type] - value;
		if (value < 0)
		{
			throw new Exception($"Resource amount cannot be negative: {type}, {value}");
		}
		Items[type] = result;
	}

	public unsafe ResourceInts Subtract(ref ResourceInts other)
	{
		ResourceInts delta = default(ResourceInts);
		for (int i = 0; i < 8; i++)
		{
			delta.Items[i] = Items[i] - other.Items[i];
		}
		return delta;
	}

	public unsafe ResourceInts GetReversed()
	{
		ResourceInts reversed = default(ResourceInts);
		for (int i = 0; i < 8; i++)
		{
			reversed.Items[i] = -Items[i];
		}
		return reversed;
	}

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

	public unsafe bool CheckIsMeet(sbyte type, int value)
	{
		return Items[type] >= value;
	}

	public unsafe int GetSum()
	{
		int sum = 0;
		for (int i = 0; i < 8; i++)
		{
			sum += Items[i];
		}
		return sum;
	}

	public unsafe long GetValueSum()
	{
		return (long)Items[0] * (long)Misc.DefValue.ResourceFood.BaseValue + (long)Items[1] * (long)Misc.DefValue.ResourceWood.BaseValue + (long)Items[2] * (long)Misc.DefValue.ResourceMetal.BaseValue + (long)Items[3] * (long)Misc.DefValue.ResourceJade.BaseValue + (long)Items[4] * (long)Misc.DefValue.ResourceFabric.BaseValue + (long)Items[5] * (long)Misc.DefValue.ResourceHerb.BaseValue + (long)Items[6] * (long)Misc.DefValue.ResourceMoney.BaseValue + (long)Items[7] * (long)Misc.DefValue.ResourceAuthority.BaseValue;
	}

	public sbyte GetMaxType()
	{
		return GetMaxType(8);
	}

	public sbyte GetMaxMaterialType()
	{
		return GetMaxType(6);
	}

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
