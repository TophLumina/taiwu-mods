using System;
using System.Collections.Generic;
using Config;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.Domains.Character;

/// <summary>
/// 功法相关前后端共用常量及方法
/// </summary>
public static class CombatSkillHelper
{
	/// <summary>
	/// 计算功法造诣的门派附加值时, 配置的功法的门派信息
	/// </summary>
	public struct AttainmentSectInfo
	{
		/// <summary>
		/// 门派 ID
		/// </summary>
		public sbyte OrgTemplateId;

		/// <summary>
		/// 配置的功法个数
		/// </summary>
		public sbyte CombatSkillsCount;

		/// <summary>
		/// 配置的功法的最大品阶
		/// </summary>
		public sbyte MaxGrade;
	}

	/// <summary>
	/// 内功最大栏位数
	/// </summary>
	public const sbyte NeigongMaxSlotCount = 9;

	/// <summary>
	/// 摧破功法最大栏位数
	/// </summary>
	public const sbyte AttackMaxSlotCount = 9;

	/// <summary>
	/// 轻灵功法最大栏位数
	/// </summary>
	public const sbyte AgileMaxSlotCount = 9;

	/// <summary>
	/// 护体功法最大栏位数
	/// </summary>
	public const sbyte DefenseMaxSlotCount = 9;

	/// <summary>
	/// 奇窍功法最大栏位数
	/// </summary>
	public const sbyte AssistMaxSlotCount = 9;

	/// <summary>
	/// 全局单项功法格数上限
	/// </summary>
	public const sbyte GlobalMaxSlotCount = 99;

	/// <summary>
	/// 功法最小占格
	/// </summary>
	public const sbyte SkillMinSlotCost = 1;

	/// <summary>
	/// 各种装备类型的功法的最大栏位数.
	/// 该限制不包含人物配置、身份配置、以及特性的影响
	/// GameData.Domains.CombatSkill.CombatSkillEquipType -&gt; slotCount.
	/// </summary>
	public static readonly sbyte[] MaxSlotCounts = new sbyte[5] { 9, 9, 9, 9, 9 };

	/// <summary>
	/// 各种装备类型的功法的栏位起始索引.
	/// GameData.Domains.CombatSkill.CombatSkillEquipType -&gt; startIndex.
	/// </summary>
	public static readonly sbyte[] SlotBeginIndexes = new sbyte[5] { 0, 9, 18, 27, 36 };

	/// <summary>
	/// 各种装备类型的功法的栏位结束索引 (不包含).
	/// GameData.Domains.CombatSkill.CombatSkillEquipType -&gt; startIndex.
	/// </summary>
	public static readonly sbyte[] SlotEndIndexes = new sbyte[5] { 9, 18, 27, 36, 45 };

	/// <summary>
	/// 所有主动功法槽的总数
	/// </summary>
	public const sbyte TotalProactiveSlotCount = 54;

	/// <summary>
	/// 所有功法槽的总数
	/// </summary>
	public const sbyte TotalSlotCount = 45;

	/// <summary>
	/// 所有功法槽的总数的上限.
	/// 此值必须是 4 的倍数, 否则下面的某些方法的行为未定义.
	/// </summary>
	public const sbyte TotalSlotCapacity = 48;

	/// <summary>
	/// 万用格分配系数
	/// </summary>
	public static readonly int[] GenericAllocationCostFactor = new int[4] { 1, 2, 2, 3 };

	/// <summary>
	/// 功法品级比较
	/// </summary>
	public static IComparer<short> CombatSkillGradeComparer = Comparer<short>.Create(CompareCombatSkillByGrade);

	/// <summary>
	/// 初始化装备方案, 不装备任何功法
	/// </summary>
	/// <returns></returns>
	public unsafe static void InitializeEquippedSkills(short* pEquippedSkills)
	{
		for (int i = 0; i < 12; i++)
		{
			((long*)pEquippedSkills)[i] = -1L;
		}
	}

	/// <summary>
	/// 获取分配万用格的消耗.
	/// </summary>
	/// <param name="equipType"><see cref="T:GameData.Domains.CombatSkill.CombatSkillEquipType" /></param>
	/// <param name="currAllocated">当前已分配的格数</param>
	/// <returns></returns>
	public static int GetGenericAllocationNextCost(sbyte equipType, int currAllocated)
	{
		return 1;
	}

	/// <summary>
	/// 获取分配万用格当前已消耗的总和.
	/// </summary>
	/// <param name="equipType"><see cref="T:GameData.Domains.CombatSkill.CombatSkillEquipType" /></param>
	/// <param name="currAllocated">当前已分配的格数</param>
	/// <returns></returns>
	public static int GetGenericAllocationTotalCost(sbyte equipType, int currAllocated)
	{
		return currAllocated;
	}

	/// <summary>
	/// 初始化装备方案, 不装备任何功法
	/// </summary>
	/// <param name="equippedSkills"></param>
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

	/// <summary>
	/// 比较两个装备方案是否相同
	/// </summary>
	/// <param name="lhs"></param>
	/// <param name="pRhs"></param>
	/// <returns></returns>
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

	/// <summary>
	/// 比较两个精通技能方案是否相等
	/// </summary>
	/// <param name="lhs"></param>
	/// <param name="rhs"></param>
	/// <returns></returns>
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

	/// <summary>
	/// 复制装备方案
	/// </summary>
	/// <param name="dest"></param>
	/// <param name="pSrc"></param>
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

	/// <summary>
	/// 获取指定位置的已装备功法
	/// </summary>
	/// <param name="equippedSkills"></param>
	/// <param name="equipType"><see cref="T:GameData.Domains.CombatSkill.CombatSkillEquipType" /></param>
	/// <param name="index">上述装备类型的功法槽中的索引</param>
	/// <returns></returns>
	public static short GetEquippedSkill(short[] equippedSkills, sbyte equipType, sbyte index)
	{
		sbyte startIndex = SlotBeginIndexes[equipType];
		return equippedSkills[startIndex + index];
	}

	/// <summary>
	/// 是否主动功法 (内功既不是主动功法, 也不是被动功法)
	/// </summary>
	/// <param name="equipType"><see cref="T:GameData.Domains.CombatSkill.CombatSkillEquipType" /></param>
	/// <returns></returns>
	public static bool IsProactiveSkill(sbyte equipType)
	{
		if (equipType != 1 && equipType != 2)
		{
			return equipType == 3;
		}
		return true;
	}

	/// <summary>
	/// 是否被动功法 (内功既不是主动功法, 也不是被动功法)
	/// </summary>
	/// <param name="equipType"><see cref="T:GameData.Domains.CombatSkill.CombatSkillEquipType" /></param>
	/// <returns></returns>
	public static bool IsPassiveSkill(sbyte equipType)
	{
		return equipType == 4;
	}

	/// <summary>
	/// 计算功法造诣的门派附加值时, 记录门派功法信息
	/// </summary>
	/// <param name="sectInfos"></param>
	/// <param name="orgTemplateId"></param>
	/// <param name="grade"></param>
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

	/// <summary>
	/// 计算功法造诣的门派附加值时, 获取首选组合门派
	/// </summary>
	/// <param name="sectInfos"></param>
	/// <returns></returns>
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

	/// <summary>
	/// 比较功法品级
	/// </summary>
	public static int CompareCombatSkillByGrade(short skillTemplateIdA, short skillTemplateIdB)
	{
		CombatSkillItem combatSkillItem = Config.CombatSkill.Instance[skillTemplateIdA];
		CombatSkillItem skillCfgB = Config.CombatSkill.Instance[skillTemplateIdB];
		return combatSkillItem.Grade.CompareTo(skillCfgB.Grade);
	}

	/// <summary>
	/// 计算突破成功率
	/// </summary>
	/// <param name="skillTemplateId">功法模板ID</param>
	/// <param name="qualifications">角色的功法资质</param>
	/// <returns>突破成功率</returns>
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

	/// <summary>
	/// 计算强行突破（走火入魔）一步造成的伤势和内息紊乱变化
	/// </summary>
	/// <param name="random"></param>
	/// <param name="config"></param>
	/// <param name="injuries">突破该步前的伤势</param>
	/// <param name="disorderOfQi">突破该步前的内息紊乱值</param>
	/// <returns>溢出的伤势值</returns>
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
