using System;
using System.Runtime.CompilerServices;
using GameData.Serializer;

namespace GameData.Domains.Character;

public struct LifeSkillInts : ISerializableGameData
{
	public unsafe fixed int Items[16];

	public unsafe ref int this[int index]
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			if (index < 0 || index >= 16)
			{
				throw new IndexOutOfRangeException($"index {index} is out of range [0,{16})");
			}
			return ref Items[index];
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
		for (int i = 0; i < 16; i++)
		{
			Items[i] = 0;
		}
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		return 64;
	}

	public unsafe int Serialize(byte* pData)
	{
		for (int i = 0; i < 16; i++)
		{
			((int*)pData)[i] = Items[i];
		}
		return 64;
	}

	public unsafe int Deserialize(byte* pData)
	{
		for (int i = 0; i < 16; i++)
		{
			Items[i] = ((int*)pData)[i];
		}
		return 64;
	}

	public unsafe LifeSkillInts Subtract(ref LifeSkillInts other)
	{
		LifeSkillInts delta = default(LifeSkillInts);
		for (int i = 0; i < 16; i++)
		{
			delta.Items[i] = Items[i] - other.Items[i];
		}
		return delta;
	}

	public unsafe LifeSkillInts GetReversed()
	{
		LifeSkillInts reversed = default(LifeSkillInts);
		for (int i = 0; i < 16; i++)
		{
			reversed.Items[i] = -Items[i];
		}
		return reversed;
	}
}
