using System;
using System.Runtime.CompilerServices;
using GameData.Serializer;

namespace GameData.Domains.Character;

/// <summary>
/// 七元赋性
/// </summary>
public struct Personalities : ISerializableGameData
{
	/// <summary>
	/// 七元赋性最小值
	/// </summary>
	public const sbyte MinValue = 0;

	/// <summary>
	/// 七元赋性最大值
	/// </summary>
	public const sbyte MaxValue = 100;

	/// <summary>
	/// *** 定长数组中的数据在创建对象时并未初始化 ***
	/// 排列顺序参见 <see cref="T:GameData.Domains.Character.PersonalityType" />
	/// </summary>
	public unsafe fixed sbyte Items[7];

	/// <summary>
	/// 直接通过 index 安全访问数据的接口.
	/// 主要用于对性能要求不是特别严格的情况 (非过月逻辑中频繁调用或可能每帧多次调用的逻辑皆可)
	/// </summary>
	/// <param name="index">七元类型<see cref="T:GameData.Domains.Character.PersonalityType" /></param>
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

	/// <summary>
	/// 初始化对象, 为 fixed size buffer 填充默认值.
	/// 其实现依赖 PersonalityType.Count == 7.
	/// <see href="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/unsafe-code#definite-assignment-checking" />
	/// </summary>
	/// <returns></returns>
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
