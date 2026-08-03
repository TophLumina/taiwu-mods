using System;
using System.Runtime.Serialization;
using GameData.Serializer;

namespace GameData.Domains.Character;

/// <summary>
/// 命中或化解值
/// </summary>
[Serializable]
public struct HitOrAvoidShorts : ISerializableGameData, ISerializable
{
	/// <summary>
	/// *** 定长数组中的数据在创建对象时并未初始化 ***
	/// 排列顺序参见 <see cref="T:GameData.Domains.CombatSkill.AttackHitType" />
	/// </summary>
	public unsafe fixed short Items[4];

	/// <summary>
	/// 替代 unsafe 调用的数据获取接口
	/// </summary>
	/// <param name="index"><see cref="T:GameData.Domains.CombatSkill.AttackHitType" /></param>
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

	/// <summary>
	/// 初始化对象, 为 fixed size buffer 填充默认值.
	/// 其实现依赖 AttackHitType.Count == 4.
	/// <see href="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/unsafe-code#definite-assignment-checking" />
	/// </summary>
	/// <returns></returns>
	public unsafe void Initialize()
	{
		fixed (short* items = Items)
		{
			*(long*)items = 0L;
		}
	}

	/// <summary>
	/// 从配置表构造对象
	/// </summary>
	/// <param name="values"></param>
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
