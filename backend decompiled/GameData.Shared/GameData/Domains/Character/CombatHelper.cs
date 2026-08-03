using System;
using System.Collections.Generic;
using System.Linq;
using Config;
using GameData.Combat.Math;
using GameData.Domains.World;
using GameData.Utilities;

namespace GameData.Domains.Character;

/// <summary>
/// 战斗相关前后端共用常量及方法 (除功法外)
/// </summary>
public static class CombatHelper
{
	/// <summary>
	/// 单个真气可分配的最大值
	/// </summary>
	public const short MaxNeiliAllocation = 100;

	/// <summary>
	/// 所有真气可分配的总最大值
	/// </summary>
	public const short MaxTotalNeiliAllocation = 400;

	/// <summary>
	/// 真气从零分配到指定点数时, 内力的累计消耗.
	/// 数组下标 + 1 = 真气分配的点数.
	/// </summary>
	private static readonly short[] NeiliCumulativeCosts = new short[100]
	{
		1, 3, 6, 10, 15, 21, 28, 36, 45, 56,
		68, 81, 95, 110, 127, 145, 164, 185, 207, 231,
		256, 282, 310, 339, 370, 402, 436, 471, 508, 547,
		587, 629, 672, 717, 764, 812, 862, 914, 968, 1024,
		1081, 1140, 1201, 1264, 1329, 1396, 1465, 1536, 1609, 1684,
		1761, 1840, 1921, 2004, 2089, 2176, 2265, 2356, 2449, 2545,
		2643, 2743, 2845, 2949, 3056, 3165, 3276, 3390, 3506, 3625,
		3746, 3869, 3995, 4123, 4254, 4387, 4523, 4661, 4802, 4946,
		5092, 5241, 5392, 5546, 5703, 5862, 6024, 6189, 6357, 6528,
		6701, 6877, 7056, 7238, 7423, 7611, 7802, 7996, 8193, 8393
	};

	/// <summary>
	/// 获取指定精纯境界可分配的真气总值
	/// NOTE: 正常不要直接使用，请用<see cref="M:GameData.Domains.Character.CombatHelper.GetMaxTotalNeiliAllocationConsideringFeature(System.SByte,System.Collections.Generic.List{System.Int16},GameData.Domains.World.ChallengeModeData)" />
	/// </summary>
	[Obsolete]
	public static short GetMaxTotalNeiliAllocation(sbyte consummateLevel)
	{
		short maxNeiliAllocation = (short)ConsummateLevel.Instance[consummateLevel].MaxNeiliAllocation;
		if (maxNeiliAllocation > 400)
		{
			return 400;
		}
		return maxNeiliAllocation;
	}

	/// <summary>
	/// 获取指定精纯境界可分配的真气总值，考虑惩罚特性
	/// </summary>
	public static short GetMaxTotalNeiliAllocationConsideringFeature(sbyte consummateLevel, List<short> featureIds, ChallengeModeData challengeModeData)
	{
		consummateLevel = Math.Min(consummateLevel, GlobalConfig.Instance.MaxConsummateLevel);
		challengeModeData.ApplyChallengeModeLimitedNeiliAllocation(ref consummateLevel);
		short originMaxNeiliAllocation = Math.Min((short)ConsummateLevel.Instance[consummateLevel].MaxNeiliAllocation, (short)400);
		int allDebuff = featureIds.Sum((short featureId) => CharacterFeature.Instance[featureId].MaxNeiliAllocationDebuff);
		return (short)Math.Max(0, originMaxNeiliAllocation - allDebuff);
	}

	/// <summary>
	/// 判断能否分配一点指定类型的真气
	/// </summary>
	/// <param name="neiliAllocationType">要分配的真气类型</param>
	/// <param name="allocation">当前真气分配情况</param>
	/// <param name="currNeili">当前内力值</param>
	/// <param name="consummateLevel">当前精纯点</param>
	/// <returns></returns>
	[Obsolete]
	public unsafe static bool CanAllocateNeili(byte neiliAllocationType, NeiliAllocation allocation, int currNeili, sbyte consummateLevel)
	{
		short currValue = allocation.Items[(int)neiliAllocationType];
		if (currValue < 100 && allocation.GetTotal() < GetMaxTotalNeiliAllocation(consummateLevel))
		{
			return currNeili >= CalcNeiliCost(currValue);
		}
		return false;
	}

	/// <summary>
	/// 判断能否分配一点指定类型的真气
	/// </summary>
	/// <param name="neiliAllocationType">要分配的真气类型</param>
	/// <param name="allocation">当前真气分配情况</param>
	/// <param name="currNeili">当前内力值</param>
	/// <param name="consummateLevel">当前精纯点</param>
	/// <param name="featureIds">当前特性</param>
	/// <param name="challengeModeData"></param>
	/// <returns></returns>
	public unsafe static bool CanAllocateNeiliConsideringFeature(byte neiliAllocationType, NeiliAllocation allocation, int currNeili, sbyte consummateLevel, List<short> featureIds, ChallengeModeData challengeModeData)
	{
		short currValue = allocation.Items[(int)neiliAllocationType];
		if (currValue < 100 && allocation.GetTotal() < GetMaxTotalNeiliAllocationConsideringFeature(consummateLevel, featureIds, challengeModeData))
		{
			return currNeili >= CalcNeiliCost(currValue);
		}
		return false;
	}

	/// <summary>
	/// 尝试用传入的内力将真气补齐到目标值. 该方法依照摧破、轻灵、护体、奇窍各一点直到无法再补的方式.
	/// 该方法会修改传入的当前
	/// </summary>
	public unsafe static void TryAllocateToTargetAllocation(NeiliAllocation target, ref NeiliAllocation current, int maxNeili, ref int currNeili, int maxTotalAllocation = 400, int costPercent = 100)
	{
		int* allocationCosts = stackalloc int[4];
		int state = 0;
		int allocated = 0;
		for (int i = 0; i < 4; i++)
		{
			allocationCosts[i] = CalcNeiliCost(current.Items[i]);
		}
		int totalAllocation = current.GetTotal();
		do
		{
			for (int j = 0; j < 4; j++)
			{
				if (totalAllocation >= maxTotalAllocation)
				{
					state = 15;
					break;
				}
				short currAllocation = current.Items[j];
				if (currAllocation >= target.Items[j])
				{
					state |= 1 << j;
					continue;
				}
				int cost = allocationCosts[j] * costPercent / 100;
				if (cost > currNeili || allocationCosts[j] > maxNeili)
				{
					allocated |= 1 << j;
					continue;
				}
				totalAllocation++;
				currAllocation++;
				currNeili -= cost;
				maxNeili -= allocationCosts[j];
				current.Items[j] = currAllocation;
				allocationCosts[j] = CalcNeiliCost(currAllocation);
			}
		}
		while ((state | allocated) != 15);
	}

	/// <summary>
	/// 计算提升一点真气所需的内力值
	/// </summary>
	/// <param name="currAllocation">当前真气值</param>
	/// <returns></returns>
	public static int CalcNeiliCost(short currAllocation)
	{
		int num = currAllocation + 1;
		return num + num * num / 100;
	}

	/// <summary>
	/// 计算战中恢复真气所需的内力值
	/// </summary>
	/// <param name="currAllocation"></param>
	/// <param name="qiDisorderLevel">内息紊乱级别<see cref="T:GameData.Domains.Character.DisorderLevelOfQi" /></param>
	/// <returns></returns>
	public static int CalcNeiliCostInCombat(short currAllocation, sbyte qiDisorderLevel)
	{
		CValuePercent neiliCostInCombat = QiDisorderEffect.Instance[qiDisorderLevel].NeiliCostInCombat;
		if (neiliCostInCombat <= 0)
		{
			return 0;
		}
		return Math.Max(CalcNeiliCost(currAllocation) * neiliCostInCombat, 1);
	}

	/// <summary>
	/// 计算把真气从零分配到指定点数, 需要消耗多少点内力
	/// </summary>
	/// <param name="neiliAllocation">目标真气点数, 取值范围 [0, MaxNeiliAllocation]</param>
	/// <returns></returns>
	public static int CalcNeiliCostFromZero(short neiliAllocation)
	{
		if (neiliAllocation == 0)
		{
			return 0;
		}
		int index = neiliAllocation - 1;
		if (index < NeiliCumulativeCosts.Length)
		{
			return NeiliCumulativeCosts[index];
		}
		int totalCost = NeiliCumulativeCosts[^1];
		for (int i = NeiliCumulativeCosts.Length; i < neiliAllocation; i++)
		{
			totalCost += CalcNeiliCost((short)i);
		}
		return totalCost;
	}

	/// <summary>
	/// 计算配置指定的真气组合所需的内力
	/// </summary>
	/// <param name="allocation"></param>
	/// <returns></returns>
	public unsafe static int CalcRequiredNeili(NeiliAllocation allocation)
	{
		int value = 0;
		for (int i = 0; i < 4; i++)
		{
			value += CalcNeiliCostFromZero(allocation.Items[i]);
		}
		return value;
	}

	/// <summary>
	/// 计算消耗指定内力点数, 可以把真气从零分配到多少点
	/// TODO: NeiliCumulativeCosts 当前最多分配到 100, 如果出现使用该方法的需求，需要支持更高的数字
	/// </summary>
	/// <param name="availableNeili">可供消耗的内力</param>
	/// <returns></returns>
	[Obsolete]
	public unsafe static short CalcAllocatedNeili(int availableNeili)
	{
		int index;
		fixed (short* pCosts = NeiliCumulativeCosts)
		{
			index = CollectionUtils.BinarySearch(pCosts, 0, 100, availableNeili);
		}
		if (index >= 0)
		{
			return (short)(index + 1);
		}
		index = ~index;
		return (short)index;
	}
}
