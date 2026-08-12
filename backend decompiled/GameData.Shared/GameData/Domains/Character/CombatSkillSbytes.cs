using System;
using System.Runtime.CompilerServices;
using GameData.Serializer;

namespace GameData.Domains.Character;

/// <summary>
/// 各种武学类型对应的值
/// </summary>
public struct CombatSkillSbytes : ISerializableGameData
{
	/// <summary>
	/// *** 定长数组中的数据在创建对象时并未初始化 ***
	/// 排列顺序参见 <see cref="T:GameData.Domains.CombatSkill.CombatSkillType" />
	/// </summary>
	public unsafe fixed sbyte Items[14];

	/// <summary>
	/// 直接通过 index 安全访问数据的接口.
	/// 主要用于对性能要求不是特别严格的情况 (非过月逻辑中频繁调用或可能每帧多次调用的逻辑皆可)
	/// </summary>
	/// <param name="index">武学类型<see cref="T:GameData.Domains.CombatSkill.CombatSkillType" /></param>
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

	/// <summary>
	/// 初始化对象, 为 fixed size buffer 填充默认值.
	/// 其实现依赖 CombatSkillType.Count == 14.
	/// <see href="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/unsafe-code#definite-assignment-checking" />
	/// </summary>
	/// <returns></returns>
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

	/// <summary>
	/// 计算并返回两者的差值
	/// </summary>
	/// <param name="other"></param>
	/// <returns></returns>
	public unsafe CombatSkillSbytes Subtract(CombatSkillSbytes other)
	{
		CombatSkillSbytes delta = default(CombatSkillSbytes);
		for (int i = 0; i < 14; i++)
		{
			delta.Items[i] = (sbyte)(Items[i] - other.Items[i]);
		}
		return delta;
	}

	/// <summary>
	/// 获取倒转了正负号后的对象
	/// </summary>
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
