using System.Runtime.CompilerServices;
using GameData.Serializer;

namespace GameData.Domains.Adventure;

/// <summary>
/// 奇遇版本号
/// </summary>
[SerializeAs(typeof(ulong))]
public readonly record struct AdventureVersion(int Major, int Minor)
{
	public readonly int Major = Major;

	public readonly int Minor = Minor;

	public static bool operator >(AdventureVersion a, AdventureVersion b)
	{
		if (a.Major <= b.Major)
		{
			if (a.Major == b.Major)
			{
				return a.Minor > b.Minor;
			}
			return false;
		}
		return true;
	}

	public static bool operator <(AdventureVersion a, AdventureVersion b)
	{
		if (a.Major >= b.Major)
		{
			if (a.Major == b.Major)
			{
				return a.Minor < b.Minor;
			}
			return false;
		}
		return true;
	}

	public static bool operator >=(AdventureVersion a, AdventureVersion b)
	{
		if (!(a > b))
		{
			return a == b;
		}
		return true;
	}

	public static bool operator <=(AdventureVersion a, AdventureVersion b)
	{
		if (!(a < b))
		{
			return a == b;
		}
		return true;
	}

	public static implicit operator ulong(AdventureVersion version)
	{
		return (uint)version.Minor | ((ulong)(uint)version.Major << 32);
	}

	public static explicit operator AdventureVersion(ulong version)
	{
		int major = (int)(version >> 32);
		int minor = (int)(version & 0xFFFFFFFFu);
		return new AdventureVersion(major, minor);
	}

	[CompilerGenerated]
	public void Deconstruct(out int Major, out int Minor)
	{
		Major = this.Major;
		Minor = this.Minor;
	}
}
