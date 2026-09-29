using System;
using GameData.Utilities;

namespace GameData.Domains.Character.Relation;

public static class RelationType
{
	public const ushort Invalid = ushort.MaxValue;

	public const ushort General = 0;

	public const ushort BloodParent = 1;

	public const ushort BloodChild = 2;

	public const ushort BloodBrotherOrSister = 4;

	public const ushort StepParent = 8;

	public const ushort StepChild = 16;

	public const ushort StepBrotherOrSister = 32;

	public const ushort AdoptiveParent = 64;

	public const ushort AdoptiveChild = 128;

	public const ushort AdoptiveBrotherOrSister = 256;

	public const ushort SwornBrotherOrSister = 512;

	public const ushort HusbandOrWife = 1024;

	public const ushort Mentor = 2048;

	public const ushort Mentee = 4096;

	public const ushort Friend = 8192;

	public const ushort Adored = 16384;

	public const ushort Enemy = 32768;

	public const int Count = 17;

	public static sbyte GetTypeId(ushort relationType)
	{
		return relationType switch
		{
			0 => 0, 
			1 => 1, 
			2 => 2, 
			4 => 3, 
			8 => 4, 
			16 => 5, 
			32 => 6, 
			64 => 7, 
			128 => 8, 
			256 => 9, 
			512 => 10, 
			1024 => 11, 
			2048 => 12, 
			4096 => 13, 
			8192 => 14, 
			16384 => 15, 
			32768 => 16, 
			_ => throw new Exception($"Unsupported relation type: {relationType}"), 
		};
	}

	public static string GetTypeName(ushort relationType)
	{
		return relationType switch
		{
			0 => "General", 
			1 => "BloodParent", 
			2 => "BloodChild", 
			4 => "BloodBrotherOrSister", 
			8 => "StepParent", 
			16 => "StepChild", 
			32 => "StepBrotherOrSister", 
			64 => "AdoptiveParent", 
			128 => "AdoptiveChild", 
			256 => "AdoptiveBrotherOrSister", 
			512 => "SwornBrotherOrSister", 
			1024 => "HusbandOrWife", 
			2048 => "Mentor", 
			4096 => "Mentee", 
			8192 => "Friend", 
			16384 => "Adored", 
			32768 => "Enemy", 
			_ => throw new Exception($"Unsupported relation type: {relationType}"), 
		};
	}

	public static ushort GetRelationType(sbyte typeId)
	{
		return (ushort)((typeId > 0) ? ((uint)(1 << typeId - 1)) : 0u);
	}

	public static bool IsOneWayRelation(ushort relationType)
	{
		if (relationType != 16384)
		{
			return relationType == 32768;
		}
		return true;
	}

	public static bool HasRelation(ushort currTypes, ushort targetType)
	{
		Tester.Assert(targetType != 0);
		return (currTypes & targetType) != 0;
	}

	public static ushort GetOppositeRelationType(ushort relationType)
	{
		return relationType switch
		{
			0 => 0, 
			1 => 2, 
			2 => 1, 
			4 => 4, 
			8 => 16, 
			16 => 8, 
			32 => 32, 
			64 => 128, 
			128 => 64, 
			256 => 256, 
			512 => 512, 
			1024 => 1024, 
			2048 => 4096, 
			4096 => 2048, 
			8192 => 8192, 
			16384 => 0, 
			32768 => 0, 
			_ => throw new Exception($"Unsupported relation type: {relationType}"), 
		};
	}

	public static bool IsFamilyRelation(ushort relation)
	{
		return (0x5FF & relation) != 0;
	}

	public static bool IsFriendRelation(ushort relation)
	{
		return (0x6200 & relation) != 0;
	}

	public static bool ContainDirectBloodRelations(ushort relationTypes)
	{
		return (relationTypes & 7) != 0;
	}

	public static bool ContainNonBloodFamilyRelations(ushort relationTypes)
	{
		return (relationTypes & 0x3F8) != 0;
	}

	public static bool ContainPositiveRelations(ushort relationTypes)
	{
		return (relationTypes & 0x7FFF) != 0;
	}

	public static bool ContainsNonRemovableRelations(ushort relationTypes)
	{
		return (relationTypes & 0x13F) != 0;
	}

	public static bool NeedRecordOnRemoval(ushort relationType)
	{
		if (relationType == 64 || relationType == 128 || relationType == 1024)
		{
			return true;
		}
		return false;
	}

	public static bool ContainNegativeRelations(ushort relationTypes)
	{
		return (relationTypes & 0x8000) != 0;
	}

	public static bool ContainBloodExclusionRelations(ushort relationTypes)
	{
		return (relationTypes & 0x7FF) != 0;
	}

	public static bool ContainParentRelations(ushort relationTypes)
	{
		return (relationTypes & 0x49) != 0;
	}

	public static bool ContainChildRelations(ushort relationTypes)
	{
		return (relationTypes & 0x92) != 0;
	}

	public static bool ContainBrotherOrSisterRelations(ushort relationTypes)
	{
		return (relationTypes & 0x124) != 0;
	}

	public static bool ContainBloodRelatedRelations(ushort relationTypes, sbyte bloodRelatedRelationType)
	{
		return bloodRelatedRelationType switch
		{
			0 => ContainParentRelations(relationTypes), 
			1 => ContainChildRelations(relationTypes), 
			_ => ContainBrotherOrSisterRelations(relationTypes), 
		};
	}

	public static bool ContainBloodRelatedRelations(ushort relationTypes)
	{
		return (relationTypes & 0x5FF) != 0;
	}

	public static ushort GetParentRelation(ushort relationTypes)
	{
		if ((relationTypes & 1) != 0)
		{
			return 1;
		}
		if ((relationTypes & 8) != 0)
		{
			return 8;
		}
		if ((relationTypes & 0x40) != 0)
		{
			return 64;
		}
		return ushort.MaxValue;
	}

	private static ushort GetChildRelation(ushort relationTypes)
	{
		if ((relationTypes & 2) != 0)
		{
			return 2;
		}
		if ((relationTypes & 0x10) != 0)
		{
			return 16;
		}
		if ((relationTypes & 0x80) != 0)
		{
			return 128;
		}
		return ushort.MaxValue;
	}

	public static ushort GetBrotherOrSisterRelation(ushort relationTypes)
	{
		if ((relationTypes & 4) != 0)
		{
			return 4;
		}
		if ((relationTypes & 0x20) != 0)
		{
			return 32;
		}
		if ((relationTypes & 0x100) != 0)
		{
			return 256;
		}
		return ushort.MaxValue;
	}

	public static ushort GetBloodRelatedRelation(ushort relationTypes, sbyte bloodRelatedRelationType)
	{
		return bloodRelatedRelationType switch
		{
			0 => GetParentRelation(relationTypes), 
			1 => GetChildRelation(relationTypes), 
			_ => GetBrotherOrSisterRelation(relationTypes), 
		};
	}
}
