using System;
using System.Runtime.CompilerServices;
using GameData.Serializer;

namespace GameData.Domains.Character;

public struct Personalities : ISerializableGameData
{
	public const sbyte MinValue = 0;

	public const sbyte MaxValue = 100;

	public unsafe fixed sbyte Items[7];

	public unsafe ref sbyte this[int index]
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			if (index < 0 || index >= 7)
			{
				throw new IndexOutOfRangeException($"index {index} is out of range [0,{7})");
			}
			return ref Items[index];
		}
	}

	public unsafe int GetSum()
	{
		int sum = 0;
		for (int i = 0; i < 7; i++)
		{
			sum += Items[i];
		}
		return sum;
	}

	public unsafe void Initialize()
	{
		fixed (sbyte* items = Items)
		{
			*(int*)items = 0;
			((short*)items)[2] = 0;
			items[6] = 0;
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
		fixed (sbyte* pItems = Items)
		{
			*(int*)pData = *(int*)pItems;
			((short*)pData)[2] = ((short*)pItems)[2];
			pData[6] = (byte)pItems[6];
		}
		return 8;
	}

	public unsafe int Deserialize(byte* pData)
	{
		fixed (sbyte* items = Items)
		{
			*(int*)items = *(int*)pData;
			((short*)items)[2] = ((short*)pData)[2];
			items[6] = (sbyte)pData[6];
		}
		return 8;
	}
}
