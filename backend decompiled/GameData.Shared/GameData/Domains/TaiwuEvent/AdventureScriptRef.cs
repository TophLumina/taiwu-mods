using System;

namespace GameData.Domains.TaiwuEvent;

/// <summary>
/// 奇遇脚本引用
/// </summary>
public readonly struct AdventureScriptRef(string debugInfo) : IEquatable<AdventureScriptRef>
{
	/// <summary>
	/// 调试信息
	/// </summary>
	public readonly string DebugInfo = debugInfo;

	/// <summary>
	/// 无效引用
	/// </summary>
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
