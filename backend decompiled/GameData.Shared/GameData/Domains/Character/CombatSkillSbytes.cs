using System;
using System.Runtime.CompilerServices;
using GameData.Serializer;

namespace GameData.Domains.Character;

public struct CombatSkillSbytes : ISerializableGameData
{
	public unsafe fixed sbyte Items[14];

	public unsafe ref sbyte this[int index]
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
		fixed (sbyte* items = Items)
		{
			*(long*)items = 0L;
			((int*)items)[2] = 0;
			((short*)items)[6] = 0;
		}
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		return 14;
	}

	public unsafe int Serialize(byte* pData)
	{
		fixed (sbyte* pItems = Items)
		{
			*(long*)pData = *(long*)pItems;
			((int*)pData)[2] = ((int*)pItems)[2];
			((short*)pData)[6] = ((short*)pItems)[6];
		}
		return 14;
	}

	public unsafe int Deserialize(byte* pData)
	{
		fixed (sbyte* items = Items)
		{
			*(long*)items = *(long*)pData;
			((int*)items)[2] = ((int*)pData)[2];
			((short*)items)[6] = ((short*)pData)[6];
		}
		return 14;
	}

	public unsafe CombatSkillSbytes Subtract(CombatSkillSbytes other)
	{
		CombatSkillSbytes delta = default(CombatSkillSbytes);
		for (int i = 0; i < 14; i++)
		{
			delta.Items[i] = (sbyte)(Items[i] - other.Items[i]);
		}
		return delta;
	}

	public unsafe CombatSkillSbytes GetReversed()
	{
		CombatSkillSbytes reversed = default(CombatSkillSbytes);
		for (int i = 0; i < 14; i++)
		{
			reversed.Items[i] = (sbyte)(-Items[i]);
		}
		return reversed;
	}
}
