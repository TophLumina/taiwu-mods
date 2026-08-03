using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Config;
using GameData.Domains.Organization;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.Domains.Character.Creation;

public static class CharacterCreation
{
	private const int BaseMainAttributeSum = 168;

	private const int MainAttributePerLevel = 21;

	private const int BaseLifeSkillSum = 448;

	private const int LifeSkillPerLevel = 56;

	private const int BaseCombatSkillSum = 392;

	private const int CombatSkillPerLevel = 49;

	private const int MutationRate = 20;

	private const int ValueSpan = 20;

	private static readonly sbyte[] SectMemberGenerationTypeWeights = GlobalConfig.CharacterCreationSectMemberGenerationTypeWeights;

	private static readonly sbyte[] CivilianGenerationTypeWeights = GlobalConfig.CharacterCreationCivilianGenerationTypeWeights;

	private static readonly sbyte[] AdjustGradeBaseChances = GlobalConfig.CharacterCreationAdjustGradeBaseChances;

	private static readonly short[][] AdjustGradeWeights = GlobalConfig.CharacterCreationAdjustGradeWeights;

	private const sbyte UseCurrOrg = 0;

	private const sbyte UseIdealSect = 1;

	private const sbyte MergeBoth = 2;

	public const int FeaturesExpectedMaxCount = 16;

	public unsafe static sbyte CalcGrowingSectGradeAndAssignWeights(IRandomSource random, ref IntelligentCharacterCreationInfo creationInfo, sbyte idealSectId)
	{
		if (creationInfo.MotherCharId >= 0 && creationInfo.ActualFatherCharId >= 0)
		{
			MainAttributes motherAttributes = creationInfo.Mother.GetBaseMainAttributes();
			MainAttributes fatherAttributes = creationInfo.ActualFather?.GetBaseMainAttributes() ?? creationInfo.ActualDeadFather.BaseMainAttributes;
			sbyte attrGrade;
			fixed (short* pAttr = creationInfo.ParentMainAttributeValues.Items)
			{
				int attrSum = GetParentValues(random, motherAttributes.Items, fatherAttributes.Items, pAttr, 6);
				attrGrade = SumToGrade(attrSum, 168, 21);
			}
			LifeSkillShorts motherLifeSkills = creationInfo.Mother.GetBaseLifeSkillQualifications();
			Character actualFather = creationInfo.ActualFather;
			LifeSkillShorts fatherLifeSkills = ((actualFather != null) ? actualFather.GetBaseLifeSkillQualifications() : creationInfo.ActualDeadFather.BaseLifeSkillQualifications);
			sbyte lifeSkillGrade;
			fixed (short* pLifeSkillQualifications = creationInfo.ParentLifeSkillQualificationValues.Items)
			{
				int lifeSkillSum = GetParentValues(random, motherLifeSkills.Items, fatherLifeSkills.Items, pLifeSkillQualifications, 16);
				lifeSkillGrade = SumToGrade(lifeSkillSum, 448, 56);
			}
			CombatSkillShorts motherCombatSkills = creationInfo.Mother.GetBaseCombatSkillQualifications();
			Character actualFather2 = creationInfo.ActualFather;
			CombatSkillShorts fatherCombatSkills = ((actualFather2 != null) ? actualFather2.GetBaseCombatSkillQualifications() : creationInfo.ActualDeadFather.BaseCombatSkillQualifications);
			sbyte combatSkillGrade;
			fixed (short* pCombatSkillQualifications = creationInfo.ParentCombatSkillQualificationValues.Items)
			{
				int combatSkillSum = GetParentValues(random, motherCombatSkills.Items, fatherCombatSkills.Items, pCombatSkillQualifications, 14);
				combatSkillGrade = SumToGrade(combatSkillSum, 392, 49);
			}
			sbyte grade = (sbyte)Math.Clamp((attrGrade + lifeSkillGrade + combatSkillGrade) / 3, 0, 8);
			if (creationInfo.AllowRandomGrowingGradeAdjust)
			{
				sbyte motherGrade = creationInfo.Mother.GetOrganizationInfo().Grade;
				sbyte fatherGrade = creationInfo.Father?.GetOrganizationInfo().Grade ?? 0;
				grade = TryAdjustGrade(random, fatherGrade, motherGrade, grade);
			}
			return grade;
		}
		if (creationInfo.MotherCharId >= 0)
		{
			creationInfo.ParentMainAttributeValues = creationInfo.Mother.GetBaseMainAttributes();
			int attrSum2 = creationInfo.ParentMainAttributeValues.GetSum();
			sbyte attrGrade2 = SumToGrade(attrSum2, 168, 21);
			creationInfo.ParentLifeSkillQualificationValues = creationInfo.Mother.GetBaseLifeSkillQualifications();
			int lifeSkillSum2 = creationInfo.ParentLifeSkillQualificationValues.GetSum();
			sbyte lifeSkillGrade2 = SumToGrade(lifeSkillSum2, 448, 56);
			creationInfo.ParentCombatSkillQualificationValues = creationInfo.Mother.GetBaseCombatSkillQualifications();
			int combatSkillSum2 = creationInfo.ParentCombatSkillQualificationValues.GetSum();
			sbyte combatSkillGrade2 = SumToGrade(combatSkillSum2, 392, 49);
			sbyte grade2 = (sbyte)Math.Clamp((attrGrade2 + lifeSkillGrade2 + combatSkillGrade2) / 3, 0, 8);
			if (creationInfo.AllowRandomGrowingGradeAdjust)
			{
				sbyte motherGrade2 = creationInfo.Mother.GetOrganizationInfo().Grade;
				sbyte fatherGrade2 = creationInfo.Father?.GetOrganizationInfo().Grade ?? 0;
				grade2 = TryAdjustGrade(random, fatherGrade2, motherGrade2, grade2);
			}
			return grade2;
		}
		sbyte templateGrade = creationInfo.OrgInfo.Grade;
		sbyte growingGrade = (sbyte)RedzenHelper.NormalDistribute(random, creationInfo.OrgInfo.Grade, 1.2f);
		if (growingGrade < 0 || growingGrade > 8)
		{
			growingGrade = creationInfo.OrgInfo.Grade;
		}
		if (creationInfo.GrowingSectId < 0)
		{
			switch ((idealSectId >= 0 && idealSectId != creationInfo.OrgInfo.OrgTemplateId) ? (OrganizationDomain.IsSect(creationInfo.OrgInfo.OrgTemplateId) ? RandomUtils.GetRandomIndex(SectMemberGenerationTypeWeights, random) : RandomUtils.GetRandomIndex(CivilianGenerationTypeWeights, random)) : 0)
			{
			case 0:
			{
				OrganizationMemberItem orgMemberCfg2 = OrganizationDomain.GetOrgMemberConfig(creationInfo.OrgInfo.OrgTemplateId, templateGrade);
				AssignVirtualParentValuesByOrgMember(random, ref creationInfo, orgMemberCfg2);
				break;
			}
			case 1:
			{
				OrganizationMemberItem idealSectOrgMemberCfg2 = OrganizationDomain.GetOrgMemberConfig(idealSectId, templateGrade);
				AssignVirtualParentValuesByOrgMember(random, ref creationInfo, idealSectOrgMemberCfg2);
				break;
			}
			case 2:
			{
				OrganizationMemberItem orgMemberCfg = OrganizationDomain.GetOrgMemberConfig(creationInfo.OrgInfo.OrgTemplateId, templateGrade);
				OrganizationMemberItem idealSectOrgMemberCfg = OrganizationDomain.GetOrgMemberConfig(idealSectId, templateGrade);
				AssignMergedVirtualParentValuesByOrgMembers(random, ref creationInfo, orgMemberCfg, idealSectOrgMemberCfg);
				break;
			}
			}
		}
		else
		{
			OrganizationMemberItem orgMemberCfg3 = OrganizationDomain.GetOrgMemberConfig(creationInfo.GrowingSectId, templateGrade);
			AssignVirtualParentValuesByOrgMember(random, ref creationInfo, orgMemberCfg3);
		}
		return growingGrade;
	}

	public static (int, int) Reservoir(IRandomSource random, (int, int) current, (int, int) newSample)
	{
		int total = current.Item2 + newSample.Item2;
		int item;
		if (random.NextFloat() * (float)total < (float)newSample.Item2)
		{
			(item, _) = newSample;
		}
		else
		{
			(item, _) = current;
		}
		return (item, total);
	}

	public static int SplitInteger(IRandomSource random, int number, int freeSpace, int max)
	{
		if (number >= freeSpace * max)
		{
			return freeSpace;
		}
		if (number <= freeSpace)
		{
			return (max == 1) ? freeSpace : 0;
		}
		(int, int) ret = (0, 0);
		int i = Math.Min(number / max, (number - freeSpace) / (max - 1));
		int maxAvail;
		int curr;
		while (i >= 0 && (maxAvail = (freeSpace - i) * (max - 1) - (curr = number - i * max) + 1) > 0)
		{
			ret = Reservoir(random, ret, (i, maxAvail * (curr - (freeSpace - i) + 1)));
			i--;
		}
		return ret.Item1;
	}

	public unsafe static void CreateAttributes(IRandomSource random, out MainAttributes rawValues, ref MainAttributes rawWeights, int sum, int mutateCount = 0, int count = -1)
	{
		fixed (short* values = rawValues.Items)
		{
			fixed (short* weights = rawWeights.Items)
			{
				CreateAttributesImpl(random, values, weights, 6, sum, mutateCount);
			}
		}
	}

	public unsafe static void CreateAttributes(IRandomSource random, out CombatSkillShorts rawValues, ref CombatSkillShorts rawWeights, int sum, int mutateCount = 0, int count = -1)
	{
		fixed (short* values = rawValues.Items)
		{
			fixed (short* weights = rawWeights.Items)
			{
				CreateAttributesImpl(random, values, weights, 14, sum, mutateCount);
			}
		}
	}

	public unsafe static void CreateAttributes(IRandomSource random, out LifeSkillShorts rawValues, ref LifeSkillShorts rawWeights, int sum, int mutateCount = 0, int count = -1)
	{
		fixed (short* values = rawValues.Items)
		{
			fixed (short* weights = rawWeights.Items)
			{
				CreateAttributesImpl(random, values, weights, 16, sum, mutateCount);
			}
		}
	}

	public unsafe static void CreateAttributesImpl(IRandomSource random, short* values, short* weights, int count, int sum, int mutateCount = 0)
	{
		DistributeValues(random, values, weights, count, sum);
		if (mutateCount > 0)
		{
			PerformMutation(random, values, count, mutateCount);
		}
	}

	public static MainAttributes CreateMainAttributes(IRandomSource random, sbyte grade, short[] mainAttributesAdjust)
	{
		return CreateMainAttributes(random, grade, mainAttributesAdjust, null);
	}

	public static MainAttributes CreateMainAttributes(IRandomSource random, sbyte grade, short[] mainAttributesAdjust, WeightsSumDistribution weightSumWeightsTable, int maxMutateCount = 2, int mutatePercentProb = 20)
	{
		int sum = GradeToSum(grade, 168, 21);
		CalculateVirtualParentValues(random, mainAttributesAdjust, out MainAttributes virtualParentAttributes, weightSumWeightsTable);
		CreateAttributes(random, out var mainAttributes, ref virtualParentAttributes, sum, DecodeMutateCount(random, maxMutateCount, mutatePercentProb));
		return mainAttributes;
	}

	public static MainAttributes CreateMainAttributes(IRandomSource random, ref IntelligentCharacterCreationInfo creationInfo, int maxMutateCount = 2, int mutatePercentProb = 20)
	{
		int sum = GradeToSum(creationInfo.GrowingSectGrade, 168, 21);
		MainAttributes parentValues = creationInfo.ParentMainAttributeValues;
		CreateAttributes(random, out var mainAttributes, ref parentValues, sum, DecodeMutateCount(random, maxMutateCount, mutatePercentProb));
		return mainAttributes;
	}

	public static LifeSkillShorts CreateLifeSkillQualifications(IRandomSource random, sbyte grade, short[] lifeSkillsAdjust)
	{
		return CreateLifeSkillQualifications(random, grade, lifeSkillsAdjust, null);
	}

	public static LifeSkillShorts CreateLifeSkillQualifications(IRandomSource random, sbyte grade, short[] lifeSkillsAdjust, WeightsSumDistribution weightSumWeightsTable, int maxMutateCount = 4, int mutatePercentProb = 20)
	{
		int sum = GradeToSum(grade, 448, 56);
		CalculateVirtualParentValues(random, lifeSkillsAdjust, out LifeSkillShorts virtualParentValues, weightSumWeightsTable);
		CreateAttributes(random, out var lifeSkillQualifications, ref virtualParentValues, sum, DecodeMutateCount(random, maxMutateCount, mutatePercentProb));
		return lifeSkillQualifications;
	}

	public unsafe static LifeSkillShorts CreateLifeSkillQualifications(IRandomSource random, ref IntelligentCharacterCreationInfo creationInfo, int maxMutateCount = 4, int mutatePercentProb = 20)
	{
		int sum = GradeToSum(creationInfo.GrowingSectGrade, 448, 56);
		CreateAttributes(random, out var lifeSkillQualifications, ref creationInfo.ParentLifeSkillQualificationValues, sum, DecodeMutateCount(random, maxMutateCount, mutatePercentProb));
		if (creationInfo.LifeSkillsLowerBound != null)
		{
			for (int lifeSkillType = 0; lifeSkillType < 16; lifeSkillType++)
			{
				short lowerBound = creationInfo.LifeSkillsLowerBound[lifeSkillType];
				short currVal = lifeSkillQualifications.Items[lifeSkillType];
				if (lowerBound > currVal)
				{
					lifeSkillQualifications.Items[lifeSkillType] = (short)(lowerBound + random.Next(11));
				}
			}
		}
		return lifeSkillQualifications;
	}

	public static CombatSkillShorts CreateCombatSkillQualifications(IRandomSource random, sbyte grade, short[] combatSkillsAdjust)
	{
		return CreateCombatSkillQualifications(random, grade, combatSkillsAdjust, null);
	}

	public static CombatSkillShorts CreateCombatSkillQualifications(IRandomSource random, sbyte grade, short[] combatSkillsAdjust, WeightsSumDistribution weightSumWeightsTable, int maxMutateCount = 3, int mutatePercentProb = 20)
	{
		int sum = GradeToSum(grade, 392, 49);
		CalculateVirtualParentValues(random, combatSkillsAdjust, out CombatSkillShorts virtualParentValues, weightSumWeightsTable);
		CreateAttributes(random, out var combatSkillQualifications, ref virtualParentValues, sum, DecodeMutateCount(random, maxMutateCount, mutatePercentProb));
		return combatSkillQualifications;
	}

	public unsafe static CombatSkillShorts CreateCombatSkillQualifications(IRandomSource random, ref IntelligentCharacterCreationInfo creationInfo, int maxMutateCount = 3, int mutatePercentProb = 20)
	{
		int sum = GradeToSum(creationInfo.GrowingSectGrade, 392, 49);
		CreateAttributes(random, out var combatSkillQualifications, ref creationInfo.ParentCombatSkillQualificationValues, sum, DecodeMutateCount(random, maxMutateCount, mutatePercentProb));
		if (creationInfo.CombatSkillsLowerBound != null)
		{
			for (int combatSkillType = 0; combatSkillType < 14; combatSkillType++)
			{
				short lowerBound = creationInfo.CombatSkillsLowerBound[combatSkillType];
				short currVal = combatSkillQualifications.Items[combatSkillType];
				if (lowerBound > currVal)
				{
					combatSkillQualifications.Items[combatSkillType] = (short)(lowerBound + random.Next(11));
				}
			}
		}
		return combatSkillQualifications;
	}

	public static short[] GetRandomEnemyMainAttributesAdjust(IRandomSource random, List<(OrganizationItem Sect, OrganizationMemberItem Member)> relatedSectsAndMembers)
	{
		short relatedSectsCount = (short)relatedSectsAndMembers.Count;
		short[] mainAttributesAdjust;
		if (relatedSectsCount > 1)
		{
			mainAttributesAdjust = new short[6];
			for (int i = 0; i < relatedSectsCount; i++)
			{
				short[] currAdjust = relatedSectsAndMembers[i].Member.MainAttributesAdjust;
				MergeAdjusts(currAdjust, mainAttributesAdjust);
			}
		}
		else
		{
			mainAttributesAdjust = relatedSectsAndMembers[0].Member.MainAttributesAdjust;
		}
		return mainAttributesAdjust;
	}

	public static short[] GetRandomEnemyLifeSkillsAdjust(IRandomSource random, List<(OrganizationItem Sect, OrganizationMemberItem Member)> relatedSectsAndMembers)
	{
		short relatedSectsCount = (short)relatedSectsAndMembers.Count;
		short[] lifeSkillsAdjust;
		if (relatedSectsCount > 1)
		{
			lifeSkillsAdjust = new short[16];
			for (int i = 0; i < relatedSectsCount; i++)
			{
				short[] currAdjust = relatedSectsAndMembers[i].Member.LifeSkillsAdjust;
				MergeAdjusts(currAdjust, lifeSkillsAdjust);
			}
		}
		else
		{
			lifeSkillsAdjust = relatedSectsAndMembers[0].Member.LifeSkillsAdjust;
		}
		return lifeSkillsAdjust;
	}

	public static short[] GetRandomEnemyCombatSkillsAdjust(IRandomSource random, List<(OrganizationItem Sect, OrganizationMemberItem Member)> relatedSectsAndMembers)
	{
		short relatedSectsCount = (short)relatedSectsAndMembers.Count;
		short[] combatSkillAdjusts;
		if (relatedSectsCount > 1)
		{
			combatSkillAdjusts = new short[14];
			Array.Fill(combatSkillAdjusts, (short)(-1));
			for (int i = 0; i < relatedSectsCount; i++)
			{
				short[] currAdjust = relatedSectsAndMembers[i].Member.CombatSkillsAdjust;
				MergeAdjusts(currAdjust, combatSkillAdjusts);
			}
		}
		else
		{
			combatSkillAdjusts = relatedSectsAndMembers[0].Member.CombatSkillsAdjust;
		}
		return combatSkillAdjusts;
	}

	public static void MergeAdjusts(short[] fromAdjusts, short[] toAdjusts)
	{
		for (int j = toAdjusts.Length - 1; j >= 0; j--)
		{
			toAdjusts[j] = Math.Max(toAdjusts[j], fromAdjusts[j]);
		}
	}

	public static short[] MergeAdjusts(IEnumerable<short[]> allAdjusts, int length)
	{
		short[] adjusts = new short[length];
		Array.Fill(adjusts, (short)(-1));
		foreach (short[] currAdjusts in allAdjusts)
		{
			MergeAdjusts(currAdjusts, adjusts);
		}
		return adjusts;
	}

	public static sbyte GetMainAttributeGrade(int sum)
	{
		return SumToGrade(sum, 168, 21);
	}

	public static sbyte GetCombatSkillQualificationGrade(int sum)
	{
		return SumToGrade(sum, 392, 49);
	}

	public static sbyte GetLifeSkillQualificationGrade(int sum)
	{
		return SumToGrade(sum, 448, 56);
	}

	private static int GradeToSum(sbyte grade, int baseVal, int valPerGrade)
	{
		return baseVal + grade * valPerGrade;
	}

	private static int NormalDistribute(IRandomSource random, int num, int span)
	{
		int softMin = num - span;
		int softMax = num + span;
		float stdDev = (float)span / 2.1f;
		return RedzenHelper.NormalDistribute(random, num, stdDev, softMin, softMax);
	}

	private static sbyte SumToGrade(int sum, int baseVal, int valPerGrade)
	{
		return (sbyte)Math.Clamp((sum - baseVal) / valPerGrade, 0, 127);
	}

	[Obsolete]
	private static int GenerateRandomGradeAdjust(IRandomSource random)
	{
		int num = random.Next(100);
		if (1 == 0)
		{
		}
		int result = ((num < 75) ? ((num < 5) ? (-2) : ((num < 25) ? (-1) : 0)) : ((num < 95) ? 1 : 2));
		if (1 == 0)
		{
		}
		return result;
	}

	private static sbyte TryAdjustGrade(IRandomSource random, sbyte fatherGrade, sbyte motherGrade, sbyte growingGrade)
	{
		sbyte highestGrade = Math.Max(fatherGrade, motherGrade);
		int chance = AdjustGradeBaseChances[highestGrade] + (highestGrade - growingGrade) * 5;
		if (!random.CheckPercentProb(chance))
		{
			return growingGrade;
		}
		return (sbyte)RandomUtils.GetRandomIndex(AdjustGradeWeights[highestGrade], random);
	}

	private static void AssignVirtualParentValuesByOrgMember(IRandomSource random, ref IntelligentCharacterCreationInfo creationInfo, OrganizationMemberItem orgMemberCfg)
	{
		CalculateVirtualParentValues(random, orgMemberCfg.MainAttributesAdjust, out creationInfo.ParentMainAttributeValues, (WeightsSumDistribution)null);
		CalculateVirtualParentValues(random, orgMemberCfg.CombatSkillsAdjust, out creationInfo.ParentCombatSkillQualificationValues, (WeightsSumDistribution)null);
		CalculateVirtualParentValues(random, orgMemberCfg.LifeSkillsAdjust, out creationInfo.ParentLifeSkillQualificationValues, (WeightsSumDistribution)null);
	}

	private static void AssignMergedVirtualParentValuesByOrgMembers(IRandomSource random, ref IntelligentCharacterCreationInfo creationInfo, OrganizationMemberItem orgMemberCfgA, OrganizationMemberItem orgMemberCfgB)
	{
		MergeVirtualParentValues(random, orgMemberCfgA.MainAttributesAdjust, orgMemberCfgB.MainAttributesAdjust, out creationInfo.ParentMainAttributeValues, (WeightsSumDistribution)null);
		MergeVirtualParentValues(random, orgMemberCfgA.CombatSkillsAdjust, orgMemberCfgB.CombatSkillsAdjust, out creationInfo.ParentCombatSkillQualificationValues, (WeightsSumDistribution)null);
		MergeVirtualParentValues(random, orgMemberCfgA.LifeSkillsAdjust, orgMemberCfgB.LifeSkillsAdjust, out creationInfo.ParentLifeSkillQualificationValues, (WeightsSumDistribution)null);
	}

	public unsafe static void CalculateVirtualParentValues(IRandomSource random, short[] weights, out MainAttributes resultValues, WeightsSumDistribution weightAndSums = null)
	{
		fixed (short* values = resultValues.Items)
		{
			CalculateVirtualParentValues(random, weights, 6, weightAndSums ?? GlobalConfig.Instance.MainAttributeWeightsTable, values);
		}
	}

	public unsafe static void CalculateVirtualParentValues(IRandomSource random, short[] weights, out CombatSkillShorts resultValues, WeightsSumDistribution weightAndSums = null)
	{
		fixed (short* values = resultValues.Items)
		{
			CalculateVirtualParentValues(random, weights, 14, weightAndSums ?? GlobalConfig.Instance.CombatSkillQualificationWeightsTable, values);
		}
	}

	public unsafe static void CalculateVirtualParentValues(IRandomSource random, short[] weights, out LifeSkillShorts resultValues, WeightsSumDistribution weightAndSums = null)
	{
		fixed (short* values = resultValues.Items)
		{
			CalculateVirtualParentValues(random, weights, 16, weightAndSums ?? GlobalConfig.Instance.LifeSkillQualificationWeightsTable, values);
		}
	}

	public unsafe static void MergeVirtualParentValues(IRandomSource random, short[] configValuesA, short[] configValuesB, out MainAttributes resultValues, WeightsSumDistribution weightAndSums = null)
	{
		CalculateVirtualParentValues(random, configValuesA, out MainAttributes configA, weightAndSums ?? GlobalConfig.Instance.MainAttributeWeightsTable);
		CalculateVirtualParentValues(random, configValuesB, out MainAttributes configB, weightAndSums ?? GlobalConfig.Instance.MainAttributeWeightsTable);
		for (int i = 0; i < 6; i++)
		{
			resultValues.Items[i] = (short)(configA[i] + configB[i]);
		}
	}

	public unsafe static void MergeVirtualParentValues(IRandomSource random, short[] configValuesA, short[] configValuesB, out CombatSkillShorts resultValues, WeightsSumDistribution weightAndSums = null)
	{
		CalculateVirtualParentValues(random, configValuesA, out CombatSkillShorts configA, weightAndSums ?? GlobalConfig.Instance.CombatSkillQualificationWeightsTable);
		CalculateVirtualParentValues(random, configValuesB, out CombatSkillShorts configB, weightAndSums ?? GlobalConfig.Instance.CombatSkillQualificationWeightsTable);
		for (int i = 0; i < 14; i++)
		{
			resultValues.Items[i] = (short)(configA.Items[i] + configB.Items[i]);
		}
	}

	public unsafe static void MergeVirtualParentValues(IRandomSource random, short[] configValuesA, short[] configValuesB, out LifeSkillShorts resultValues, WeightsSumDistribution weightAndSums = null)
	{
		CalculateVirtualParentValues(random, configValuesA, out LifeSkillShorts configA, weightAndSums ?? GlobalConfig.Instance.LifeSkillQualificationWeightsTable);
		CalculateVirtualParentValues(random, configValuesB, out LifeSkillShorts configB, weightAndSums ?? GlobalConfig.Instance.LifeSkillQualificationWeightsTable);
		for (int i = 0; i < 16; i++)
		{
			resultValues.Items[i] = (short)(configA.Items[i] + configB.Items[i]);
		}
	}

	public unsafe static void CalculateVirtualParentValues(IRandomSource random, short[] weights, int count, WeightsSumDistribution weightAndSums, short* resultValues)
	{
		for (int i = 0; i < count; i++)
		{
			resultValues[i] = weights[i];
		}
		int offset = Array.BinarySearch(weightAndSums.Weights, random.Next(weightAndSums.Weights[^1]));
		if (offset < 0)
		{
			offset = ~offset;
		}
		int targetWeights = weightAndSums.Min + offset;
		Span<int> indexes = stackalloc int[16];
		int randomWeights = 0;
		for (int j = 0; j < count; j++)
		{
			if (resultValues[j] < 0)
			{
				indexes[randomWeights++] = j;
			}
			else
			{
				targetWeights -= resultValues[j];
			}
		}
		if (randomWeights <= 0)
		{
			return;
		}
		for (short i2 = 9; i2 > 0; i2--)
		{
			int counter = SplitInteger(random, targetWeights, randomWeights, i2);
			targetWeights -= i2 * counter;
			while (counter > 0)
			{
				int rndIdx = random.Next(randomWeights--);
				resultValues[indexes[rndIdx]] = i2;
				indexes[rndIdx] = indexes[randomWeights];
				counter--;
			}
		}
	}

	[Obsolete("Use `CalculateVirtualParentValues` and its interfaces instead.")]
	private unsafe static void CreateVirtualParentValues(IRandomSource random, short[] configValues, short* resultValues, int count)
	{
		for (int index = 0; index < count; index++)
		{
			resultValues[index] = ((configValues[index] >= 0) ? configValues[index] : GenerateRandomWeight(random));
		}
	}

	private unsafe static void MergeCreateVirtualParentValues(IRandomSource random, short[] configValuesA, short[] configValuesB, short* resultValues, int count)
	{
		for (int index = 0; index < count; index++)
		{
			short valueA = ((configValuesA[index] >= 0) ? configValuesA[index] : GenerateRandomWeight(random));
			short valueB = ((configValuesB[index] >= 0) ? configValuesB[index] : GenerateRandomWeight(random));
			resultValues[index] = (short)(valueA + valueB);
		}
	}

	private unsafe static int GetParentValues(IRandomSource random, short* motherValues, short* fatherValues, short* resultValues, int count)
	{
		int sum = 0;
		int useMaxCount = count / 2;
		for (int index = 0; index < count; index++)
		{
			short motherVal = motherValues[index];
			short fatherVal = fatherValues[index];
			if (useMaxCount > 0 && random.NextBool())
			{
				resultValues[index] = Math.Max(motherVal, fatherVal);
				sum += resultValues[index];
				useMaxCount--;
			}
			else
			{
				resultValues[index] = Math.Min(motherVal, fatherVal);
				sum += resultValues[index];
			}
		}
		return sum;
	}

	private unsafe static void DistributeValues(IRandomSource random, short* values, short* weights, int count, int sum)
	{
		int weightSum = AdjustWeightsAndGetSum(weights, count);
		for (int i = 0; i < count; i++)
		{
			short weight = weights[i];
			int value = sum * weight / weightSum;
			values[i] = (short)NormalDistribute(random, value, value * 20 / 100);
		}
	}

	private unsafe static int AdjustWeightsAndGetSum(short* weight, int count)
	{
		int sum = 1;
		for (int i = 0; i < count; i++)
		{
			weight[i] = (short)Math.Min(weight[i] * 10 + 1, 10000);
			sum += weight[i];
		}
		short minWeight = (short)(sum / 100);
		sum = 0;
		for (int j = 0; j < count; j++)
		{
			weight[j] = Math.Max(weight[j], minWeight);
			sum += weight[j];
		}
		return sum;
	}

	private static short GenerateRandomWeight(IRandomSource random)
	{
		return (short)RedzenHelper.SkewDistribute(random, 6f, 1.5f, -2f, 2, 12);
	}

	private unsafe static void PerformMutation(IRandomSource random, short* values, int count, int mutateCount)
	{
		short maxVal = values[CollectionUtils.GetMaxIndex(values, count)];
		short minVal = values[CollectionUtils.GetMinIndex(values, count)];
		sbyte* normalIndices = stackalloc sbyte[(int)(uint)(count - 2)];
		sbyte* extremeIndices = stackalloc sbyte[(int)(uint)count];
		int extremeCount = 0;
		int validCount = 0;
		for (sbyte i = 0; i < count; i++)
		{
			short value = values[i];
			if (value == maxVal || value == minVal)
			{
				extremeIndices[extremeCount] = i;
				extremeCount++;
			}
			else
			{
				normalIndices[validCount] = i;
				validCount++;
			}
		}
		if (validCount != 0)
		{
			for (int j = 0; j < mutateCount; j++)
			{
				int extremeIndexOffset = random.Next(extremeCount);
				int normalIndexOffset = random.Next(validCount);
				sbyte extremeIndex = extremeIndices[extremeIndexOffset];
				sbyte normalIndex = normalIndices[normalIndexOffset];
				ref short reference = ref values[extremeIndex];
				short* num = values + normalIndex;
				short num2 = values[normalIndex];
				short num3 = values[extremeIndex];
				reference = num2;
				*num = num3;
				extremeIndices[extremeIndexOffset] = normalIndex;
				normalIndices[normalIndexOffset] = extremeIndex;
			}
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int DecodeMutateCount(IRandomSource random, int maxMutateCount, int percentProb = 20)
	{
		return (maxMutateCount > 0 && random.CheckPercentProb(percentProb)) ? (1 + random.Next(maxMutateCount)) : 0;
	}

	public static void CreateFeatures(IRandomSource random, Character character, ref IntelligentCharacterCreationInfo creationInfo)
	{
		FeatureCreationContext context = new FeatureCreationContext(character, ref creationInfo);
		CreateFeatures(random, ref context);
	}

	public static void CreateFeatures(IRandomSource random, Character character)
	{
		FeatureCreationContext context = new FeatureCreationContext(character);
		CreateFeatures(random, ref context);
	}

	public static void CreateFeatures(IRandomSource random, ref FeatureCreationContext creationContext)
	{
		Dictionary<short, short> featureGroup2Id = new Dictionary<short, short>(16);
		foreach (short featureId in creationContext.FeatureIds)
		{
			AddFeature(featureGroup2Id, featureId);
		}
		creationContext.FeatureIds.Clear();
		GenerateFixedFeatures(ref creationContext, featureGroup2Id);
		if (creationContext.DestinyType >= 0)
		{
			AddFeature(featureGroup2Id, DestinyType.Instance[creationContext.DestinyType].Feature);
		}
		if (creationContext.RandomFeaturesAtCreating)
		{
			GenerateGeneticFeatures(ref creationContext, random, featureGroup2Id);
			AddFeature(featureGroup2Id, CharacterDomain.GetBirthdayFeatureId(creationContext.BirthMonth));
			if (creationContext.CurrAge >= 1 && random.CheckPercentProb(50))
			{
				AddFeature(featureGroup2Id, CharacterDomain.GenerateOneYearOldCatchFeature(random));
			}
			GenerateRandomBasicFeatures(ref creationContext, featureGroup2Id, random);
		}
		ApplyFeatureIds(ref creationContext, featureGroup2Id);
	}

	private static void ApplyFeatureIds(ref FeatureCreationContext context, Dictionary<short, short> featureGroup2Id)
	{
		List<short> featureIds = context.FeatureIds;
		List<short> potentialFeatureIds = context.PotentialFeatureIds;
		short potentialFeaturesAge = context.PotentialFeaturesAge;
		ApplyFeatureGroup(featureGroup2Id, featureIds, 209);
		ApplyFeatureGroup(featureGroup2Id, featureIds, 196);
		ApplyFeatureGroup(featureGroup2Id, featureIds, 184);
		ApplyFeatureGroup(featureGroup2Id, featureIds, 172);
		foreach (KeyValuePair<short, short> item in featureGroup2Id)
		{
			short featureId = item.Value;
			if (potentialFeaturesAge >= 0 && CharacterFeature.Instance[featureId].Mergeable)
			{
				potentialFeatureIds.Add(featureId);
			}
			else
			{
				featureIds.Add(featureId);
			}
		}
		if (potentialFeaturesAge >= 0)
		{
			int affectedFeaturesCount = potentialFeatureIds.Count * potentialFeaturesAge / 16;
			for (int i = 0; i < affectedFeaturesCount; i++)
			{
				featureIds.Add(potentialFeatureIds[i]);
			}
		}
		featureIds.Sort(CharacterFeatureHelper.FeatureComparer);
	}

	private static void ApplyFeatureGroup(Dictionary<short, short> featureGroup2Id, List<short> featureIds, short groupId)
	{
		if (featureGroup2Id.TryGetValue(groupId, out var featureId))
		{
			featureIds.Add(featureId);
			featureGroup2Id.Remove(groupId);
		}
	}

	private static void GenerateFixedFeatures(ref FeatureCreationContext context, Dictionary<short, short> featureGroup2Id)
	{
		short virginityFeatureId = 196;
		short xiangshuStateFeatureId = 209;
		List<short> featureIds = context.FeatureIds;
		int featureIdsCount = featureIds.Count;
		for (int i = 0; i < featureIdsCount; i++)
		{
			short featureId = featureIds[i];
			switch (CharacterFeature.Instance[featureId].MutexGroupId)
			{
			case 196:
				virginityFeatureId = featureId;
				break;
			case 209:
				xiangshuStateFeatureId = featureId;
				break;
			}
		}
		AddFeature(featureGroup2Id, virginityFeatureId);
		AddFeature(featureGroup2Id, xiangshuStateFeatureId);
		for (int j = 0; j < featureIdsCount; j++)
		{
			AddFeature(featureGroup2Id, featureIds[j]);
		}
	}

	private static void GenerateGeneticFeatures(ref FeatureCreationContext context, IRandomSource random, Dictionary<short, short> featureGroup2Id)
	{
		Character mother = context.Mother;
		Character father = context.Father;
		DeadCharacter deadFather = context.DeadFather;
		PregnantState pregnantState = context.PregnantState;
		if (mother == null && father == null && deadFather == null)
		{
			return;
		}
		List<short> motherFeatureIds = null;
		List<short> fatherFeatureIds = null;
		if (pregnantState != null)
		{
			motherFeatureIds = pregnantState.MotherFeatureIds;
			fatherFeatureIds = pregnantState.FatherFeatureIds;
		}
		else
		{
			if (mother != null)
			{
				motherFeatureIds = mother.GetFeatureIds();
			}
			if (father != null)
			{
				fatherFeatureIds = father.GetFeatureIds();
			}
			else if (deadFather != null)
			{
				fatherFeatureIds = deadFather.FeatureIds;
			}
		}
		Dictionary<short, (short, short)> mergeableFeaturePairs = new Dictionary<short, (short, short)>();
		if (fatherFeatureIds != null)
		{
			int fatherFeatureIdsCount = fatherFeatureIds.Count;
			for (int i = 0; i < fatherFeatureIdsCount; i++)
			{
				short featureId = fatherFeatureIds[i];
				CharacterFeatureItem template = CharacterFeature.Instance[featureId];
				short groupId = template.MutexGroupId;
				sbyte geneticProb = template.GeneticProb;
				if (template.Mergeable)
				{
					mergeableFeaturePairs[groupId] = (-1, featureId);
				}
				else if (geneticProb > 0 && !featureGroup2Id.ContainsKey(groupId) && random.CheckPercentProb(geneticProb))
				{
					featureGroup2Id.Add(groupId, featureId);
				}
			}
		}
		if (motherFeatureIds != null)
		{
			int motherFeatureIdsCount = motherFeatureIds.Count;
			for (int j = 0; j < motherFeatureIdsCount; j++)
			{
				short featureId2 = motherFeatureIds[j];
				CharacterFeatureItem template2 = CharacterFeature.Instance[featureId2];
				short groupId2 = template2.MutexGroupId;
				sbyte geneticProb2 = template2.GeneticProb;
				if (template2.Mergeable)
				{
					if (mergeableFeaturePairs.TryGetValue(groupId2, out var pair))
					{
						mergeableFeaturePairs[groupId2] = (featureId2, pair.Item2);
					}
				}
				else if (geneticProb2 > 0 && !featureGroup2Id.ContainsKey(groupId2) && random.CheckPercentProb(geneticProb2))
				{
					featureGroup2Id.Add(groupId2, featureId2);
				}
			}
		}
		foreach (KeyValuePair<short, (short, short)> entry in mergeableFeaturePairs)
		{
			short groupId3 = entry.Key;
			var (motherFeatureId, fatherFeatureId) = entry.Value;
			if (motherFeatureId < 0 || fatherFeatureId < 0 || featureGroup2Id.ContainsKey(groupId3))
			{
				continue;
			}
			sbyte motherLevel = CharacterFeature.Instance[motherFeatureId].Level;
			sbyte fatherLevel = CharacterFeature.Instance[fatherFeatureId].Level;
			sbyte mergedLevel = (sbyte)((motherLevel + fatherLevel) / 2);
			if (motherLevel > 0 && fatherLevel > 0)
			{
				int upgradeProb = (3 - mergedLevel) * 40;
				if (random.CheckPercentProb(upgradeProb))
				{
					mergedLevel++;
				}
			}
			else if (motherLevel < 0 && fatherLevel < 0)
			{
				int downgradeProb = (3 + mergedLevel) * 40;
				if (random.CheckPercentProb(downgradeProb))
				{
					mergedLevel--;
				}
			}
			if (mergedLevel != 0)
			{
				short mergedFeatureId = CharacterDomain.GetMergeableFeatureIdByLevel(groupId3, mergedLevel);
				featureGroup2Id.Add(groupId3, mergedFeatureId);
			}
		}
	}

	private static void GenerateRandomBasicFeatures(ref FeatureCreationContext context, Dictionary<short, short> featureGroup2Id, IRandomSource random)
	{
		int basicFeaturesCount = (context.AllGoodBasicFeature ? 5 : GenerateRandomBasicFeaturesCount(random));
		foreach (KeyValuePair<short, short> item in featureGroup2Id)
		{
			short featureId = item.Value;
			if (CharacterFeature.Instance[featureId].Basic)
			{
				basicFeaturesCount--;
			}
		}
		if (basicFeaturesCount <= 0)
		{
			return;
		}
		int goodFeaturesPotential = random.Next(101);
		sbyte gender = context.Gender;
		for (int i = 0; i < basicFeaturesCount; i++)
		{
			if (context.AllGoodBasicFeature || random.CheckPercentProb(goodFeaturesPotential))
			{
				var (groupId, featureId2) = CharacterDomain.GetRandomBasicFeature(random, context.IsProtagonist, context.Gender, isPositive: true, featureGroup2Id);
				if (featureId2 >= 0)
				{
					featureGroup2Id.Add(groupId, featureId2);
					goodFeaturesPotential -= 20;
				}
			}
			else
			{
				var (groupId2, featureId3) = CharacterDomain.GetRandomBasicFeature(random, context.IsProtagonist, context.Gender, isPositive: false, featureGroup2Id);
				if (featureId3 >= 0)
				{
					featureGroup2Id.Add(groupId2, featureId3);
					goodFeaturesPotential += 20;
				}
			}
		}
		if (featureGroup2Id.ContainsValue(686))
		{
			CharacterDomain.GenerateLongevityFeatures(random, context.Gender, featureGroup2Id);
		}
	}

	public static int GenerateRandomBasicFeaturesCount(IRandomSource random)
	{
		return RedzenHelper.SkewDistribute(random, 4f, 0.333f, 3f, 3, 7);
	}

	private static void AddFeature(Dictionary<short, short> featureGroup2Id, short featureId)
	{
		short groupId = CharacterFeature.Instance[featureId].MutexGroupId;
		featureGroup2Id.TryAdd(groupId, featureId);
	}
}
