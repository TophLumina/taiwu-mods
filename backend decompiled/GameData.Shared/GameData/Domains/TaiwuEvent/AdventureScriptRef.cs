using System;

namespace GameData.Domains.TaiwuEvent;

public readonly struct AdventureScriptRef(string debugInfo) : IEquatable<AdventureScriptRef>
{
	public readonly string DebugInfo = debugInfo;

	public static readonly AdventureScriptRef Invalid = new AdventureScriptRef(string.Empty);

	public override string ToString()
	{
		return "Adv:" + DebugInfo;
	}

	public bool Equals(AdventureScriptRef other)
	{
		return DebugInfo == other.DebugInfo;
	}

	public override bool Equals(object obj)
	{
		if (obj is AdventureScriptRef other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		if (DebugInfo == null)
		{
			return 0;
		}
		return DebugInfo.GetHashCode();
	}

	public static bool operator ==(AdventureScriptRef left, AdventureScriptRef right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(AdventureScriptRef left, AdventureScriptRef right)
	{
		return !left.Equals(right);
	}
}
