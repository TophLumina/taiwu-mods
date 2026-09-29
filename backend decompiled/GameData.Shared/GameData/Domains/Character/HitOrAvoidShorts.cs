using System;
using System.Runtime.Serialization;
using GameData.Serializer;

namespace GameData.Domains.Character;

[Serializable]
public struct HitOrAvoidShorts : ISerializableGameData, ISerializable
{
	public unsafe fixed short Items[4];

	public unsafe short this[int index]
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

	public unsafe void Initialize()
	{
		fixed (short* items = Items)
		{
			*(long*)items = 0L;
		}
	}

	public unsafe HitOrAvoidShorts(params short[] values)
	{
		for (int i = 0; i < 4; i++)
		{
			Items[i] = values[i];
		}
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

	public unsafe HitOrAvoidShorts(SerializationInfo info, StreamingContext context)
	{
		fixed (short* items = Items)
		{
			*(ulong*)items = info.GetUInt64("0");
		}
	}

	public unsafe void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		fixed (short* pItems = Items)
		{
			info.AddValue("0", *(ulong*)pItems);
		}
	}
}
