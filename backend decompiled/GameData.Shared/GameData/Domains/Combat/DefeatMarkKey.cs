using System;
using GameData.Utilities;

namespace GameData.Domains.Combat;

/// <summary>
/// 战败标记键
/// </summary>
public readonly struct DefeatMarkKey : IEquatable<DefeatMarkKey>, IComparable<DefeatMarkKey>
{
	/// <summary>
	/// 无效的键
	/// </summary>
	public static DefeatMarkKey Invalid => new DefeatMarkKey(EMarkType.Invalid);

	/// <summary>
	/// 标记类型
	/// </summary>
	public EMarkType Type { get; }

	/// <summary>
	/// 标记子类型，可能是部位、毒素类型、真气类型
	/// </summary>
	public int SubType { get; }

	/// <summary>
	/// 标记子类型，可能是新旧标识、破绽封穴等级
	/// </summary>
	public int SubType2 { get; }

	/// <summary>
	/// 是否为有效键
	/// </summary>
	public bool Valid => Type >= EMarkType.Outer;

	/// <summary>
	/// 部位类型
	/// </summary>
	public sbyte BodyPart
	{
		get
		{
			EMarkType type = Type;
			bool flag = (uint)type <= 3u;
			return (sbyte)(flag ? SubType : (-1));
		}
	}

	/// <summary>
	/// 毒素类型
	/// </summary>
	public sbyte PoisonType => (sbyte)((Type == EMarkType.Poison) ? SubType : (-1));

	/// <summary>
	/// 是否有等级
	/// </summary>
	public bool HasLevel
	{
		get
		{
			EMarkType type = Type;
			if ((uint)(type - 2) <= 1u)
			{
				return true;
			}
			return false;
		}
	}

	/// <summary>
	/// 破绽或封穴等级
	/// </summary>
	public int Level
	{
		get
		{
			if (!HasLevel)
			{
				return -1;
			}
			return SubType2;
		}
	}

	/// <summary>
	/// 是否有新旧
	/// </summary>
	public bool HasOld
	{
		get
		{
			EMarkType type = Type;
			if ((uint)type <= 1u || (uint)(type - 4) <= 1u || type == EMarkType.QiDisorder)
			{
				return true;
			}
			return false;
		}
	}

	/// <summary>
	/// 伤势、内息、失神标记是否为旧伤、旧内息、固定失神
	/// </summary>
	public bool Old
	{
		get
		{
			if (HasOld)
			{
				return SubType2 == 1;
			}
			return false;
		}
	}

	/// <summary>
	/// 是否真气溃散标记
	/// </summary>
	public bool Scatter
	{
		get
		{
			if (Type == EMarkType.NeiliAllocation)
			{
				return SubType == 0;
			}
			return false;
		}
	}

	/// <summary>
	/// 是否真气充盈标记
	/// </summary>
	public bool Bulge
	{
		get
		{
			if (Type == EMarkType.NeiliAllocation)
			{
				return SubType == 1;
			}
			return false;
		}
	}

	/// <summary>
	/// 适配 ui 错误命名时使用的部位值
	/// </summary>
	public int UiIncorrectBodyPart => ParseUiIncorrectBodyPart(BodyPart);

	/// <summary>
	/// 转换适配 ui 错误命名时使用的部位值
	/// </summary>
	public static int ParseUiIncorrectBodyPart(int bodyPart)
	{
		return bodyPart switch
		{
			2 => 0, 
			0 => 1, 
			1 => 2, 
			_ => bodyPart, 
		};
	}

	internal static DefeatMarkKey Assert(DefeatMarkKey markKey)
	{
		EMarkType type = markKey.Type;
		Tester.Assert(type >= EMarkType.Invalid && type <= EMarkType.Tired);
		int subType = markKey.SubType;
		Tester.Assert(subType >= 0 && subType < 100);
		subType = markKey.SubType2;
		Tester.Assert(subType >= 0 && subType < 100);
		return markKey;
	}

	/// <summary>
	/// 隐式转换为 int
	/// </summary>
	public static implicit operator int(DefeatMarkKey markKey)
	{
		return (int)markKey.Type * 10000 + markKey.SubType * 100 + markKey.SubType2;
	}

	/// <summary>
	/// 自 int 显式转换
	/// </summary>
	public static explicit operator DefeatMarkKey(int key)
	{
		return Assert(new DefeatMarkKey((EMarkType)(key / 10000), key % 10000 / 100, key % 100));
	}

	/// <summary>
	/// 隐式构造
	/// </summary>
	public static implicit operator DefeatMarkKey(EMarkType markType)
	{
		return new DefeatMarkKey(markType);
	}

	public static implicit operator DefeatMarkKey((EMarkType markType, int subType) tup)
	{
		return new DefeatMarkKey(tup.markType, tup.subType);
	}

	public static implicit operator DefeatMarkKey((EMarkType markType, int subType, int subType2) tup)
	{
		return new DefeatMarkKey(tup.markType, tup.subType, tup.subType2);
	}

	/// <summary>
	/// 创建指定类型的标记键
	/// </summary>
	public DefeatMarkKey(EMarkType type, int subType = 0, int subType2 = 0)
	{
		Type = type;
		SubType = subType;
		SubType2 = subType2;
		Assert(this);
	}

	/// <summary>
	/// 是否属于同组标记
	/// </summary>
	public bool GroupEquals(DefeatMarkKey markKey)
	{
		if (HasLevel || HasOld)
		{
			if (Type == markKey.Type)
			{
				return SubType == markKey.SubType;
			}
			return false;
		}
		return Equals(markKey);
	}

	/// <inheritdoc />
	public override string ToString()
	{
		return $"DefeatMarkKey({Type},{SubType},{SubType2})";
	}

	/// <inheritdoc />
	public override bool Equals(object obj)
	{
		if (obj is DefeatMarkKey key)
		{
			return Equals(key);
		}
		return false;
	}

	/// <inheritdoc />
	public bool Equals(DefeatMarkKey other)
	{
		if (SubType == other.SubType && SubType2 == other.SubType2)
		{
			return Type == other.Type;
		}
		return false;
	}

	/// <inheritdoc />
	public override int GetHashCode()
	{
		return (((SubType * 397) ^ SubType2) * 397) ^ (int)Type;
	}

	/// <inheritdoc />
	public int CompareTo(DefeatMarkKey other)
	{
		return ((int)this).CompareTo(other);
	}

	/// <summary>
	/// 等于运算符
	/// </summary>
	public static bool operator ==(DefeatMarkKey left, DefeatMarkKey right)
	{
		return left.Equals(right);
	}

	/// <summary>
	/// 不等运算符
	/// </summary>
	public static bool operator !=(DefeatMarkKey left, DefeatMarkKey right)
	{
		return !(left == right);
	}
}
