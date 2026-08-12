using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using GameData.Serializer;
using Redzen.Random;

namespace GameData.Domains.Character;

/// <summary>
/// 各种技艺类型对应的值
/// </summary>
[Serializable]
public struct LifeSkillShorts : ISerializableGameData, ISerializable
{
	/// <summary>
	/// *** 定长数组中的数据在创建对象时并未初始化 ***
	/// 排列顺序参见 <see cref="T:GameData.Domains.Character.LifeSkillType" />
	/// </summary>
	public unsafe fixed short Items[16];

	/// <summary>
	/// 直接通过 index 安全访问数据的接口.
	/// 主要用于对性能要求不是特别严格的情况 (非过月逻辑中频繁调用或可能每帧多次调用的逻辑皆可)
	/// </summary>
	/// <param name="index">技艺类型<see cref="T:GameData.Domains.Character.LifeSkillType" /></param>
	public unsafe ref short this[int index]
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

	/// <summary>
	/// 获取某一项，性能详见<see cref="P:GameData.Domains.Character.LifeSkillShorts.Item(System.Int32)" />
	/// </summary>
	/// <param name="index"></param>
	/// <returns></returns>
	public short Get(int index)
	{
		return this[index];
	}

	/// <summary>
	/// 设置某一项，性能详见<see cref="P:GameData.Domains.Character.LifeSkillShorts.Item(System.Int32)" />
	/// </summary>
	/// <param name="index"></param>
	/// <param name="value"></param>
	/// <returns></returns>
	public short Set(int index, short value)
	{
		return this[index] = value;
	}

	/// <summary>
	/// 改变某一项，性能详见<see cref="P:GameData.Domains.Character.LifeSkillShorts.Item(System.Int32)" />
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
	/// 其实现依赖 LifeSkillType.Count == 16.
	/// <see href="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/unsafe-code#definite-assignment-checking" />
	/// </summary>
	/// <returns></returns>
	public unsafe void Initialize()
	{
		fixed (short* items = Items)
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
	/// <param name="values"></param>
	public unsafe LifeSkillShorts(params short[] values)
	{
		for (int i = 0; i < 16; i++)
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
		return 32;
	}

	public unsafe int Serialize(byte* pData)
	{
		fixed (short* pItems = Items)
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
		fixed (short* items = Items)
		{
			*(long*)items = *(long*)pData;
			((long*)items)[1] = ((long*)pData)[1];
			((long*)items)[2] = ((long*)pData)[2];
			((long*)items)[3] = ((long*)pData)[3];
		}
		return 32;
	}

	public unsafe LifeSkillShorts(SerializationInfo info, StreamingContext context)
	{
		fixed (short* items = Items)
		{
			*(ulong*)items = info.GetUInt64("0");
			((long*)items)[1] = (long)info.GetUInt64("1");
			((long*)items)[2] = (long)info.GetUInt64("2");
			((long*)items)[3] = (long)info.GetUInt64("3");
		}
	}

	public unsafe void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		fixed (short* pItems = Items)
		{
			info.AddValue("0", *(ulong*)pItems);
			info.AddValue("1", ((ulong*)pItems)[1]);
			info.AddValue("2", ((ulong*)pItems)[2]);
			info.AddValue("3", ((ulong*)pItems)[3]);
		}
	}

	/// <summary>
	/// 计算所有值的总和
	/// </summary>
	/// <returns></returns>
	public unsafe int GetSum()
	{
		int sum = 0;
		for (int i = 0; i < 16; i++)
		{
			sum += Items[i];
		}
		return sum;
	}

	/// <summary>
	/// 计算并返回两者的差值
	/// </summary>
	/// <param name="other"></param>
	/// <returns></returns>
	public unsafe LifeSkillShorts Subtract(ref LifeSkillShorts other)
	{
		LifeSkillShorts delta = default(LifeSkillShorts);
		for (int i = 0; i < 16; i++)
		{
			delta.Items[i] = (short)(Items[i] - other.Items[i]);
		}
		return delta;
	}

	/// <summary>
	/// 获取倒转了正负号后的对象
	/// </summary>
	public unsafe LifeSkillShorts GetReversed()
	{
		LifeSkillShorts reversed = default(LifeSkillShorts);
		for (int i = 0; i < 16; i++)
		{
			reversed.Items[i] = (short)(-Items[i]);
		}
		return reversed;
	}

	/// <summary>
	/// 获取最大值
	/// </summary>
	public unsafe short GetMaxLifeSkillValue()
	{
		short max = short.MinValue;
		for (sbyte lifeSkillType = 0; lifeSkillType < 16; lifeSkillType++)
		{
			if (Items[lifeSkillType] > max)
			{
				max = Items[lifeSkillType];
			}
		}
		return max;
	}

	/// <summary>
	/// 获取最大值的类型,如有相同值则返回首个
	/// </summary>
	/// <returns></returns>
	public unsafe sbyte GetMaxLifeSkillType()
	{
		short max = Items[0];
		sbyte type = 0;
		for (sbyte i = 1; i < 16; i++)
		{
			if (Items[i] > max)
			{
				max = Items[i];
				type = i;
			}
		}
		return type;
	}

	/// <summary>
	/// 获取最大值的类型,如有相同值则随机一个
	/// </summary>
	public unsafe sbyte GetMaxLifeSkillType(IRandomSource random)
	{
		short max = short.MinValue;
		for (sbyte lifeSkillType = 0; lifeSkillType < 16; lifeSkillType++)
		{
			if (Items[lifeSkillType] > max)
			{
				max = Items[lifeSkillType];
			}
		}
		sbyte* selectableTypes = stackalloc sbyte[16];
		int selectableCount = 0;
		for (sbyte lifeSkillType2 = 0; lifeSkillType2 < 16; lifeSkillType2++)
		{
			if (Items[lifeSkillType2] == max)
			{
				selectableTypes[selectableCount] = lifeSkillType2;
				selectableCount++;
			}
		}
		return selectableTypes[random.Next(0, selectableCount)];
	}
}
