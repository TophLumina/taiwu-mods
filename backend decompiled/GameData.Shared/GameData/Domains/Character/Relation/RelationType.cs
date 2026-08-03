using System;
using GameData.Utilities;

namespace GameData.Domains.Character.Relation;

/// <summary>
/// 人物关系类型.
/// 非特殊关系:
///     如果有非特殊关系之外的关系, 则非特殊关系自动被移除; 如果没有任何关系, 则非特殊关系自动被添加.
/// 多级关系:
///     - 血亲要计算两级关系, 即自己的血亲的血亲, 还是是自己的血亲. 两级以上的理论上还是血亲, 但判断时不当作血亲.
///     - 继亲和义亲都只需要计算一级关系, 一级以上的从理论上就不是继亲和义亲了.
/// 关系间的排斥:
///    - 已经是血亲关系 (多级), 则不能结成血亲, 继亲, 义亲, 结义关系, 一般情况下也不能结成夫妻关系.
///    - 同辈血缘关系 (父母, 手足, 子女) 之间可能发生重叠 (比如既是血亲手足又是继亲手足), 此时更亲的可以替换原有的, 同亲疏或更疏则不行 (血亲 &gt; 继亲 &gt; 义亲).
///    - 已经是血亲, 继亲, 义亲, 结义中的任何一种 (单级), 则不能结成血亲关系 (替换同辈血缘关系除外).
///    - 已经是血亲, 继亲, 义亲中的任何一种 (单级), 则不能结成义亲, 结义关系.
/// 注意, 所有血缘关系, 在排斥和替换检查时, 都是指名义上的关系.
/// </summary>
public static class RelationType
{
	/// <summary>
	/// 无效关系.
	/// 因为不可能所有关系同时存在, 所以可以用所有关系同时存在作为无效关系.
	/// </summary>
	public const ushort Invalid = ushort.MaxValue;

	/// <summary>
	/// 非特殊关系.
	/// 指角色之间不存在任何特殊关系, 但仍然存在关系的状态.
	/// </summary>
	public const ushort General = 0;

	/// <summary>
	/// 血亲父母
	/// </summary>
	public const ushort BloodParent = 1;

	/// <summary>
	/// 血亲子女
	/// </summary>
	public const ushort BloodChild = 2;

	/// <summary>
	/// 血亲手足 (血亲父母的血亲子女)
	/// </summary>
	public const ushort BloodBrotherOrSister = 4;

	/// <summary>
	/// 继亲父母
	/// </summary>
	public const ushort StepParent = 8;

	/// <summary>
	/// 继亲子女
	/// </summary>
	public const ushort StepChild = 16;

	/// <summary>
	/// 继亲手足 (血亲父母的继亲子女 + 继亲父母的血亲子女 + 继亲父母的继亲子女)
	/// </summary>
	public const ushort StepBrotherOrSister = 32;

	/// <summary>
	/// 义亲父母
	/// </summary>
	public const ushort AdoptiveParent = 64;

	/// <summary>
	/// 义亲子女
	/// </summary>
	public const ushort AdoptiveChild = 128;

	/// <summary>
	/// 义亲手足 (血亲父母的义亲子女 + 继亲父母的义亲子女 + 义亲父母的血亲子女 + 义亲父母的继亲子女 + 义亲父母的义亲子女)
	/// </summary>
	public const ushort AdoptiveBrotherOrSister = 256;

	/// <summary>
	/// 结义
	/// </summary>
	public const ushort SwornBrotherOrSister = 512;

	/// <summary>
	/// 夫妻
	/// </summary>
	public const ushort HusbandOrWife = 1024;

	/// <summary>
	/// 师父
	/// </summary>
	public const ushort Mentor = 2048;

	/// <summary>
	/// 徒弟
	/// </summary>
	public const ushort Mentee = 4096;

	/// <summary>
	/// 朋友
	/// </summary>
	public const ushort Friend = 8192;

	/// <summary>
	/// 爱慕
	/// </summary>
	public const ushort Adored = 16384;

	/// <summary>
	/// 仇视
	/// </summary>
	public const ushort Enemy = 32768;

	/// <summary>
	/// 人物关系类型的个数
	/// </summary>
	public const int Count = 17;

	/// <summary>
	/// 把不连续的人物关系类型转化为连续的 ID (用于某些根据类型索引对应数据的情形)
	/// </summary>
	/// <param name="relationType">单一关系类型</param>
	/// <returns></returns>
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

	/// <summary>
	/// 把不连续的人物关系类型转化为连续的 ID (用于某些根据类型索引对应数据的情形)
	/// </summary>
	/// <param name="relationType">单一关系类型</param>
	/// <returns></returns>
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

	/// <summary>
	/// 把连续的 ID 转化为把不连续的人物关系类型
	/// </summary>
	/// <param name="typeId">取值范围 [0, RelationType.Count - 1]</param>
	/// <returns></returns>
	public static ushort GetRelationType(sbyte typeId)
	{
		return (ushort)((typeId > 0) ? ((uint)(1 << typeId - 1)) : 0u);
	}

	/// <summary>
	/// 是否为可单项存在的关系
	/// </summary>
	/// <param name="relationType"></param>
	/// <returns></returns>
	public static bool IsOneWayRelation(ushort relationType)
	{
		if (relationType != 16384)
		{
			return relationType == 32768;
		}
		return true;
	}

	/// <summary>
	/// 检查当前类型组合里是否已有指定类型
	/// </summary>
	/// <param name="currTypes">已有关系类型组合</param>
	/// <param name="targetType">单一目标类型, 调用者保证类型有效且不为 RelationType.General</param>
	/// <returns></returns>
	public static bool HasRelation(ushort currTypes, ushort targetType)
	{
		Tester.Assert(targetType != 0);
		return (currTypes & targetType) != 0;
	}

	/// <summary>
	/// 获取指定关系类型的相对关系.
	/// A 和 B 两人, 以 A 为主体的关系和以 B 为主体的关系相对.
	/// 比如在 A 看来, B 是自己的血亲父母, 那么在 B 看来, A 就是自己的血亲子女.
	/// </summary>
	/// <param name="relationType">单一关系类型</param>
	/// <returns></returns>
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

	/// <summary>
	/// 是否是亲人关系
	/// </summary>
	/// <param name="relation"></param>
	/// <returns></returns>
	public static bool IsFamilyRelation(ushort relation)
	{
		return (0x5FF & relation) != 0;
	}

	/// <summary>
	/// 是否是朋友关系
	/// </summary>
	/// <param name="relation"></param>
	/// <returns></returns>
	public static bool IsFriendRelation(ushort relation)
	{
		return (0x6200 & relation) != 0;
	}

	/// <summary>
	/// 判断传入的关系类型组合是否包含直接血亲关系
	/// </summary>
	/// <param name="relationTypes">关系类型组合</param>
	/// <returns></returns>
	public static bool ContainDirectBloodRelations(ushort relationTypes)
	{
		return (relationTypes & 7) != 0;
	}

	/// <summary>
	/// 判断传入的关系类型组合是否包含继亲、义亲、结义关系
	/// </summary>
	/// <param name="relationTypes"></param>
	/// <returns></returns>
	public static bool ContainNonBloodFamilyRelations(ushort relationTypes)
	{
		return (relationTypes & 0x3F8) != 0;
	}

	/// <summary>
	/// 判断传入的关系类型组合是否包含正面关系
	/// </summary>
	/// <param name="relationTypes"></param>
	/// <returns></returns>
	public static bool ContainPositiveRelations(ushort relationTypes)
	{
		return (relationTypes & 0x7FFF) != 0;
	}

	/// <summary>
	/// 判断传入的关系类型组合是否包含不可移除的关系
	/// </summary>
	/// <param name="relationTypes"></param>
	/// <returns></returns>
	public static bool ContainsNonRemovableRelations(ushort relationTypes)
	{
		return (relationTypes & 0x13F) != 0;
	}

	/// <summary>
	/// 判断传入的关系类型在移除时是否需要被记录
	/// </summary>
	/// <param name="relationType"></param>
	/// <returns></returns>
	public static bool NeedRecordOnRemoval(ushort relationType)
	{
		if (relationType == 64 || relationType == 128 || relationType == 1024)
		{
			return true;
		}
		return false;
	}

	/// <summary>
	/// 判断传入的关系类型组合是否包含负面关系
	/// </summary>
	/// <param name="relationTypes"></param>
	/// <returns></returns>
	public static bool ContainNegativeRelations(ushort relationTypes)
	{
		return (relationTypes & 0x8000) != 0;
	}

	/// <summary>
	/// 判断传入的关系类型组合是否包含排斥血亲的关系 (血亲, 继亲, 义亲, 结义, 夫妻)
	/// </summary>
	/// <param name="relationTypes">关系类型组合</param>
	/// <returns></returns>
	public static bool ContainBloodExclusionRelations(ushort relationTypes)
	{
		return (relationTypes & 0x7FF) != 0;
	}

	/// <summary>
	/// 判断传入的关系类型组合是否包含父母关系
	/// </summary>
	/// <param name="relationTypes">关系类型组合</param>
	/// <returns></returns>
	public static bool ContainParentRelations(ushort relationTypes)
	{
		return (relationTypes & 0x49) != 0;
	}

	/// <summary>
	/// 判断传入的关系类型组合是否包含子女关系
	/// </summary>
	/// <param name="relationTypes">关系类型组合</param>
	/// <returns></returns>
	public static bool ContainChildRelations(ushort relationTypes)
	{
		return (relationTypes & 0x92) != 0;
	}

	/// <summary>
	/// 判断传入的关系类型组合是否包含手足关系
	/// </summary>
	/// <param name="relationTypes">关系类型组合</param>
	/// <returns></returns>
	public static bool ContainBrotherOrSisterRelations(ushort relationTypes)
	{
		return (relationTypes & 0x124) != 0;
	}

	/// <summary>
	/// 判断传入的关系类型组合是否包含指定类型的血缘关系
	/// </summary>
	/// <param name="relationTypes">关系类型组合</param>
	/// <param name="bloodRelatedRelationType"><see cref="T:GameData.Domains.Character.Relation.BloodRelatedRelationType" /></param>
	/// <returns></returns>
	public static bool ContainBloodRelatedRelations(ushort relationTypes, sbyte bloodRelatedRelationType)
	{
		return bloodRelatedRelationType switch
		{
			0 => ContainParentRelations(relationTypes), 
			1 => ContainChildRelations(relationTypes), 
			_ => ContainBrotherOrSisterRelations(relationTypes), 
		};
	}

	/// <summary>
	/// 判断传入的关系类型组合是否包含任意血缘关系 (血亲, 继亲, 义亲，夫妻)
	/// </summary>
	/// <param name="relationTypes">关系类型组合</param>
	/// <returns></returns>
	public static bool ContainBloodRelatedRelations(ushort relationTypes)
	{
		return (relationTypes & 0x5FF) != 0;
	}

	/// <summary>
	/// 从传入的关系类型组合中抽取父母关系
	/// </summary>
	/// <param name="relationTypes">关系类型组合, 调用者保证其中有且仅有一种父母关系</param>
	/// <returns>抽取到的父母关系</returns>
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

	/// <summary>
	/// 从传入的关系类型组合中抽取子女关系
	/// </summary>
	/// <param name="relationTypes">关系类型组合, 调用者保证其中有且仅有一种子女关系</param>
	/// <returns>抽取到的子女关系</returns>
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

	/// <summary>
	/// 从传入的关系类型组合中抽取手足关系
	/// </summary>
	/// <param name="relationTypes">关系类型组合, 调用者保证其中有且仅有一种手足关系</param>
	/// <returns>抽取到的手足关系</returns>
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

	/// <summary>
	/// 从传入的关系类型组合中抽取指定类型的血缘关系
	/// </summary>
	/// <param name="relationTypes">关系类型组合, 调用者保证其中有且仅有一种和传入血缘类型对应的关系</param>
	/// <param name="bloodRelatedRelationType"><see cref="T:GameData.Domains.Character.Relation.BloodRelatedRelationType" /></param>
	/// <returns>抽取到的血缘关系</returns>
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
