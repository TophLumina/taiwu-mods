using System;
using System.Runtime.CompilerServices;
using GameData.Serializer;

namespace GameData.Domains.Character;

public struct CombatSkillInts : ISerializableGameData
{
	public unsafe fixed int Items[14];

	public unsafe ref int this[int index]
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			if (index < 0 || index >= 14)
			{
				throw new IndexOutOfRangeException($"index {index} is out of range [0,{14})");
			}
			return ref Items[index];
		}
	}

	public unsafe void Initialize()
	{
		for (int i = 0; i < 14; i++)
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
		return 56;
	}

	public unsafe int Serialize(byte* pData)
	{
		for (int i = 0; i < 14; i++)
		{
			((int*)pData)[i] = Items[i];
		}
		return 56;
	}

	public unsafe int Deserialize(byte* pData)
	{
		for (int i = 0; i < 14; i++)
		{
			Items[i] = ((int*)pData)[i];
		}
		return 56;
	}

	public unsafe CombatSkillInts Subtract(ref CombatSkillInts other)
	{
		CombatSkillInts delta = default(CombatSkillInts);
		for (int i = 0; i < 14; i++)
		{
			delta.Items[i] = Items[i] - other.Items[i];
		}
		return delta;
	}

	public unsafe CombatSkillInts GetReversed()
	{
		CombatSkillInts reversed = default(CombatSkillInts);
		for (int i = 0; i < 14; i++)
		{
			reversed.Items[i] = -Items[i];
		}
		return reversed;
	}
}
