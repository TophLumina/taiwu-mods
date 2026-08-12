using System.Collections.Generic;

namespace GameData.Domains.CombatSkill;

/// <summary>
/// 施展需要的身体部位类型
/// </summary>
public static class NeedBodyPartType
{
	/// <summary>
	/// 头颈
	/// </summary>
	public const sbyte Head = 0;

	/// <summary>
	/// 胸背
	/// </summary>
	public const sbyte Chest = 1;

	/// <summary>
	/// 腰腹
	/// </summary>
	public const sbyte Belly = 2;

	/// <summary>
	/// 双手
	/// </summary>
	public const sbyte BothHands = 3;

	/// <summary>
	/// 单手
	/// </summary>
	public const sbyte AnyHand = 4;

	/// <summary>
	/// 双腿
	/// </summary>
	public const sbyte BothLegs = 5;

	/// <summary>
	/// 单腿
	/// </summary>
	public const sbyte AnyLeg = 6;

	/// <summary>
	/// 所需部位包含指定部位
	/// </summary>
	/// <param name="needBodyPart"><see cref="T:GameData.Domains.CombatSkill.NeedBodyPartType" /></param>
	/// <param name="bodyPart"><see cref="T:GameData.Domains.Combat.BodyPartType" /></param>
	/// <returns></returns>
	public static bool Contains(sbyte needBodyPart, sbyte bodyPart)
	{
		switch (needBodyPart)
		{
		case 0:
			return bodyPart == 2;
		case 1:
			return bodyPart == 0;
		case 2:
			return bodyPart == 1;
		case 3:
		case 4:
			return (uint)(bodyPart - 3) <= 1u;
		case 5:
		case 6:
			return (uint)(bodyPart - 5) <= 1u;
		default:
			return false;
		}
	}

	/// <summary>
	/// 转换为部位
	/// </summary>
	/// <param name="needBodyPart">需求部位类型</param>
	/// <returns></returns>
	public static IEnumerable<sbyte> ParseBodyParts(sbyte needBodyPart)
	{
		for (sbyte bodyPart = 0; bodyPart < 7; bodyPart++)
		{
			if (Contains(needBodyPart, bodyPart))
			{
				yield return bodyPart;
			}
		}
	}
}
