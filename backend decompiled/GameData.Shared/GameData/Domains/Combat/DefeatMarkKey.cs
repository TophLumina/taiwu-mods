using System;
using GameData.Utilities;

namespace GameData.Domains.Combat;

public readonly struct DefeatMarkKey : IEquatable<DefeatMarkKey>, IComparable<DefeatMarkKey>
{
	public static DefeatMarkKey Invalid => new DefeatMarkKey(EMarkType.Invalid);

	public EMarkType Type { get; }

	public int SubType { get; }

	public int SubType2 { get; }

	public bool Valid => Type >= EMarkType.Outer;

	public sbyte BodyPart
	{
		get
		{
			EMarkType type = Type;
			bool flag = (uint)type <= 3u;
			return (sbyte)(flag ? SubType : (-1));
		}
	}

	public sbyte PoisonType => (sbyte)((Type == EMarkType.Poison) ? SubType : (-1));

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

	public int UiIncorrectBodyPart => ParseUiIncorrectBodyPart(BodyPart);

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

	public static implicit operator int(DefeatMarkKey markKey)
	{
		return (int)markKey.Type * 10000 + markKey.SubType * 100 + markKey.SubType2;
	}

	public static explicit operator DefeatMarkKey(int key)
	{
		return Assert(new DefeatMarkKey((EMarkType)(key / 10000), key % 10000 / 100, key % 100));
	}

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

	public DefeatMarkKey(EMarkType type, int subType = 0, int subType2 = 0)
	{
		Type = type;
		SubType = subType;
		SubType2 = subType2;
		Assert(this);
	}

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

	public override string ToString()
	{
		return $"DefeatMarkKey({Type},{SubType},{SubType2})";
	}

	public override bool Equals(object obj)
	{
		if (obj is DefeatMarkKey key)
		{
			return Equals(key);
		}
		return false;
	}

	public bool Equals(DefeatMarkKey other)
	{
		if (SubType == other.SubType && SubType2 == other.SubType2)
		{
			return Type == other.Type;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return (((SubType * 397) ^ SubType2) * 397) ^ (int)Type;
	}

	public int CompareTo(DefeatMarkKey other)
	{
		return ((int)this).CompareTo(other);
	}

	public static bool operator ==(DefeatMarkKey left, DefeatMarkKey right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(DefeatMarkKey left, DefeatMarkKey right)
	{
		return !(left == right);
	}
}
