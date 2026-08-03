using System;

namespace GameData.Domains.Combat;

public struct CastFreeData : IEquatable<CastFreeData>, IComparable<CastFreeData>
{
	public short SkillId;

	public ECombatCastFreePriority Priority;

	public static implicit operator CastFreeData((short skillId, ECombatCastFreePriority priority) tuple)
	{
		CastFreeData result = default(CastFreeData);
		(result.SkillId, result.Priority) = tuple;
		return result;
	}

	public void Deconstruct(out short skillId, out ECombatCastFreePriority priority)
	{
		skillId = SkillId;
		priority = Priority;
	}

	public bool Equals(CastFreeData other)
	{
		return SkillId == other.SkillId && Priority == other.Priority;
	}

	public override bool Equals(object obj)
	{
		return obj is CastFreeData other && Equals(other);
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(SkillId, (int)Priority);
	}

	public int CompareTo(CastFreeData other)
	{
		int priority = (int)Priority;
		int priorityComparison = priority.CompareTo((int)other.Priority);
		return (priorityComparison != 0) ? priorityComparison : SkillId.CompareTo(other.SkillId);
	}

	public static bool operator ==(CastFreeData left, CastFreeData right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(CastFreeData left, CastFreeData right)
	{
		return !(left == right);
	}
}
