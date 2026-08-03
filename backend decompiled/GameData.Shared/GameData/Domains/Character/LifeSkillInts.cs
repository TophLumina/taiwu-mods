using System;
using System.Runtime.CompilerServices;
using GameData.Serializer;

namespace GameData.Domains.Character;

/// <summary>
/// 各种技艺类型对应的值
/// </summary>
public struct LifeSkillInts : ISerializableGameData
{
	/// <summary>
	/// *** 定长数组中的数据在创建对象时并未初始化 ***
	/// 排列顺序参见 <see cref="T:GameData.Domains.Character.LifeSkillType" />
	/// </summary>
	public unsafe fixed int Items[16];

	/// <summary>
	/// 直接通过 index 安全访问数据的接口.
	/// 主要用于对性能要求不是特别严格的情况 (非过月逻辑中频繁调用或可能每帧多次调用的逻辑皆可)
	/// </summary>
	/// <param name="index">技艺类型<see cref="T:GameData.Domains.Character.LifeSkillType" /></param>
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

	/// <summary>
	/// 获取某一项，性能详见<see cref="P:GameData.Domains.Character.LifeSkillInts.Item(System.Int32)" />
	/// </summary>
	/// <param name="index"></param>
	/// <returns></returns>
	public int Get(int index)
	{
		return this[index];
	}

	/// <summary>
	/// 设置某一项，性能详见<see cref="P:GameData.Domains.Character.LifeSkillInts.Item(System.Int32)" />
	/// </summary>
	/// <param name="index"></param>
	/// <param name="value"></param>
	/// <returns></returns>
	public int Set(int index, int value)
	{
		return this[index] = value;
	}

	/// <summary>
	/// 改变某一项，性能详见<see cref="P:GameData.Domains.Character.LifeSkillInts.Item(System.Int32)" />
	/// </summary>
	/// <param name="index"></param>
	/// <param name="delta"></param>
	/// <returns></returns>
	public int Change(int index, int delta)
	{
		return this[index] += delta;
	}

	/// <summary>
	/// 初始化对象, 为 fixed size buffer 填充默认值.
	/// <see href="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/unsafe-code#definite-assignment-checking" />
	/// </summary>
	/// <returns></returns>
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

	/// <summary>
	/// 计算并返回两者的差值
	/// </summary>
	/// <param name="other"></param>
	/// <returns></returns>
	public unsafe LifeSkillInts Subtract(ref LifeSkillInts other)
	{
		LifeSkillInts delta = default(LifeSkillInts);
		for (int i = 0; i < 16; i++)
		{
			delta.Items[i] = Items[i] - other.Items[i];
		}
		return delta;
	}

	/// <summary>
	/// 获取倒转了正负号后的对象
	/// </summary>
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
