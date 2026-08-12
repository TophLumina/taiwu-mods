using System;

namespace GameData.Adventure;

public readonly struct CharacterFilterKey(short filterRuleTemplateId, sbyte searchRangeType) : IEquatable<CharacterFilterKey>, IComparable<CharacterFilterKey>
{
	public readonly short FilterRuleTemplateId = filterRuleTemplateId;

	public readonly sbyte SearchRangeType = searchRangeType;

	public bool Equals(CharacterFilterKey other)
	{
		if (FilterRuleTemplateId == other.FilterRuleTemplateId)
		{
			return SearchRangeType == other.SearchRangeType;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj is CharacterFilterKey other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return (FilterRuleTemplateId.GetHashCode() * 397) ^ SearchRangeType.GetHashCode();
	}

	public static bool operator ==(CharacterFilterKey left, CharacterFilterKey right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(CharacterFilterKey left, CharacterFilterKey right)
	{
		return !left.Equals(right);
	}

	public int CompareTo(CharacterFilterKey other)
	{
		int filterRuleTemplateIdComparison = FilterRuleTemplateId.CompareTo(other.FilterRuleTemplateId);
		if (filterRuleTemplateIdComparison != 0)
		{
			return filterRuleTemplateIdComparison;
		}
		return SearchRangeType.CompareTo(other.SearchRangeType);
	}
}
