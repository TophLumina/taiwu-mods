using System;
using System.Collections.Generic;
using Config;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.Domains.Character;

public static class CombatSkillHelper
{
	public struct AttainmentSectInfo
	{
		public sbyte OrgTemplateId;

		public sbyte CombatSkillsCount;

		public sbyte MaxGrade;
	}

	public const sbyte NeigongMaxSlotCount = 9;

	public const sbyte AttackMaxSlotCount = 9;

	public const sbyte AgileMaxSlotCount = 9;

	public const sbyte DefenseMaxSlotCount = 9;

	public const sbyte AssistMaxSlotCount = 9;

	public const sbyte GlobalMaxSlotCount = 99;

	public const sbyte SkillMinSlotCost = 1;

	public static readonly sbyte[] MaxSlotCounts = new sbyte[5] { 9, 9, 9, 9, 9 };

	public static readonly sbyte[] SlotBeginIndexes = new sbyte[5] { 0, 9, 18, 27, 36 };

	public static readonly sbyte[] SlotEndIndexes = new sbyte[5] { 9, 18, 27, 36, 45 };

	public const sbyte TotalProactiveSlotCount = 54;

	public const sbyte TotalSlotCount = 45;

	public const sbyte TotalSlotCapacity = 48;

	public static readonly int[] GenericAllocationCostFactor = new int[4] { 1, 2, 2, 3 };

	public static IComparer<short> CombatSkillGradeComparer = Comparer<short>.Create(CompareCombatSkillByGrade);

	public unsafe static void InitializeEquippedSkills(short* pEquippedSkills)
	{
		for (int i = 0; i < 12; i++)
		{
			((long*)pEquippedSkills)[i] = -1L;
		}
	}

	public static int GetGenericAllocationNextCost(sbyte equipType, int currAllocated)
	{
		return 1;
	}

	public static int GetGenericAllocationTotalCost(sbyte equipType, int currAllocated)
	{
		return currAllocated;
	}

	public unsafe static void InitializeEquippedSkills(short[] equippedSkills)
	{
		fixed (short* pEquippedSkills = equippedSkills)
		{
			for (int i = 0; i < 12; i++)
			{
				((long*)pEquippedSkills)[i] = -1L;
			}
		}
	}

	public unsafe static bool Equals(short[] lhs, short* pRhs)
	{
		fixed (short* pLhs = lhs)
		{
			for (int i = 0; i < 12; i++)
			{
				if (((long*)pLhs)[i] != ((long*)pRhs)[i])
				{
					return false;
				}
			}
		}
		return true;
	}

	public static bool Equals(IList<short> lhs, IList<short> rhs)
	{
		if (lhs == null || lhs.Count == 0)
		{
			if (rhs != null)
			{
				return rhs.Count == 0;
			}
			return true;
		}
		if (lhs.Count != rhs.Count)
		{
			return false;
		}
		int count = lhs.Count;
		for (int i = 0; i < count; i++)
		{
			short element = lhs[i];
			if (!rhs.Contains(element))
			{
				return false;
			}
		}
		return true;
	}

	public unsafe static void Copy(short[] dest, short* pSrc)
	{
		fixed (short* pDest = dest)
		{
			for (int i = 0; i < 12; i++)
			{
				((long*)pDest)[i] = ((long*)pSrc)[i];
			}
		}
	}

	public static short GetEquippedSkill(short[] equippedSkills, sbyte equipType, sbyte index)
	{
		sbyte startIndex = SlotBeginIndexes[equipType];
		return equippedSkills[startIndex + index];
	}

	public static bool IsProactiveSkill(sbyte equipType)
	{
		if (equipType != 1 && equipType != 2)
		{
			return equipType == 3;
		}
		return true;
	}

	public static bool IsPassiveSkill(sbyte equipType)
	{
		return equipType == 4;
	}

	public static void CalcAttainments_RecordSectInfo(List<AttainmentSectInfo> sectInfos, sbyte orgTemplateId, sbyte grade)
	{
		int index = -1;
		int i = 0;
		for (int count = sectInfos.Count; i < count; i++)
		{
			if (sectInfos[i].OrgTemplateId == orgTemplateId)
			{
				index = i;
				break;
			}
		}
		if (index >= 0)
		{
			AttainmentSectInfo info = sectInfos[index];
			info.CombatSkillsCount++;
			if (info.MaxGrade < grade)
			{
				info.MaxGrade = grade;
			}
			sectInfos[index] = info;
		}
		else
		{
			AttainmentSectInfo info2 = default(AttainmentSectInfo);
			info2.OrgTemplateId = orgTemplateId;
			info2.CombatSkillsCount = 1;
			info2.MaxGrade = grade;
			sectInfos.Add(info2);
		}
	}

	public static int CalcAttainments_GetPrimarySectIndex(List<AttainmentSectInfo> sectInfos)
	{
		int maxValue = int.MinValue;
		int index = -1;
		int i = 0;
		for (int count = sectInfos.Count; i < count; i++)
		{
			AttainmentSectInfo info = sectInfos[i];
			int value = (info.CombatSkillsCount << 8) + info.MaxGrade;
			if (value > maxValue)
			{
				maxValue = value;
				index = i;
			}
		}
		return index;
	}

	public static int CompareCombatSkillByGrade(short skillTemplateIdA, short skillTemplateIdB)
	{
		CombatSkillItem combatSkillItem = Config.CombatSkill.Instance[skillTemplateIdA];
		CombatSkillItem skillCfgB = Config.CombatSkill.Instance[skillTemplateIdB];
		return combatSkillItem.Grade.CompareTo(skillCfgB.Grade);
	}

	public unsafe static int CalcBreakoutSuccessRate(short skillTemplateId, ref CombatSkillShorts qualifications)
	{
		CombatSkillItem skillCfg = Config.CombatSkill.Instance[skillTemplateId];
		short qualification = qualifications.Items[skillCfg.Type];
		short requiredQualification = SkillGradeData.Instance[skillCfg.Grade].PracticeQualificationRequirement;
		if (qualification >= requiredQualification)
		{
			return 100;
		}
		return GlobalConfig.Instance.NpcBreakoutBaseSuccessRate + qualification * (100 - GlobalConfig.Instance.NpcBreakoutBaseSuccessRate) / requiredQualification;
	}

	public static int CalcForceBreakoutInjuriesAndDisorderOfQi(IRandomSource random, CombatSkillItem config, ref Injuries injuries, ref short disorderOfQi)
	{
		disorderOfQi += config.GoneMadQiDisorder;
		sbyte part = config.GoneMadInjuredPart.GetRandom(random);
		sbyte injuryValue = config.GoneMadInjuryValue;
		int val = injuries.Get(part, config.GoneMadInnerInjury) + injuryValue - 6;
		injuries.Change(part, config.GoneMadInnerInjury, injuryValue);
		return Math.Max(val, 0);
	}
}
