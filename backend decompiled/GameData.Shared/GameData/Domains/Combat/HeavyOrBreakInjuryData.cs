using System;
using GameData.Serializer;

namespace GameData.Domains.Combat;

/// <summary>
/// 重伤或残毁数据
/// </summary>
[SerializableGameData(NotForArchive = true)]
public struct HeavyOrBreakInjuryData : ISerializableGameData
{
	/// <summary>
	/// 此对象可以容纳的部位数.
	/// 其实现依赖 BodyPartType.Count == 7.
	/// </summary>
	private const int Capacity = 8;

	/// <summary>
	/// 用于序列化的数据
	/// *** 定长数组中的数据在创建对象时并未初始化 ***
	/// 每个部位占 1 字节, 排列顺序参见 <see cref="T:GameData.Domains.Combat.BodyPartType" />
	/// </summary>
	[SerializableGameDataField]
	private unsafe fixed sbyte _types[8];

	/// <summary>
	/// 数据访问器
	/// </summary>
	/// <param name="bodyPart"></param>
	public unsafe EHeavyOrBreakType this[int bodyPart]
	{
		get
		{
			if ((bodyPart < 0 || bodyPart >= 7) ? true : false)
			{
				throw new ArgumentOutOfRangeException("bodyPart", bodyPart, "out of range");
			}
			return (EHeavyOrBreakType)_types[bodyPart];
		}
		set
		{
			if ((bodyPart < 0 || bodyPart >= 7) ? true : false)
			{
				throw new ArgumentOutOfRangeException("bodyPart", bodyPart, "out of range");
			}
			_types[bodyPart] = (sbyte)value;
		}
	}

	/// <summary>
	/// 初始化对象, 为 fixed size buffer 填充默认值.
	/// 其实现依赖 Capacity == 8.
	/// <see href="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/unsafe-code#definite-assignment-checking" />
	/// </summary>
	/// <returns></returns>
	public unsafe void Initialize()
	{
		fixed (sbyte* types = _types)
		{
			*(long*)types = 0L;
		}
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		return 8;
	}

	/// <inheritdoc />
	public unsafe int Serialize(byte* pData)
	{
		fixed (sbyte* pItems = _types)
		{
			*(long*)pData = *(long*)pItems;
		}
		return 8;
	}

	/// <inheritdoc />
	public unsafe int Deserialize(byte* pData)
	{
		fixed (sbyte* types = _types)
		{
			*(long*)types = *(long*)pData;
		}
		return 8;
	}
}
