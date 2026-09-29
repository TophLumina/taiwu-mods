using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Config;
using GameData.Combat.Math;
using GameData.Domains.Taiwu.Profession.SkillsData;
using GameData.Serializer;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.Domains.Taiwu.Profession;

[SerializableGameData(IsExtensible = true, NoCopyConstructors = true)]
public class ProfessionData : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort TemplateId = 0;

		public const ushort Type = 1;

		public const ushort Seniority = 2;

		public const ushort SkillOffCooldownDates = 3;

		public const ushort HadBeenUnlocked = 4;

		public const ushort SkillsData = 5;

		public const ushort ExtraSeniority = 6;

		public const ushort LearnedSkills = 7;

		public const ushort Count = 8;

		public static readonly string[] FieldId2FieldName = new string[8] { "TemplateId", "Type", "Seniority", "SkillOffCooldownDates", "HadBeenUnlocked", "SkillsData", "ExtraSeniority", "LearnedSkills" };
	}

	[SerializableGameDataField]
	public int TemplateId;

	[SerializableGameDataField]
	public sbyte Type = -1;

	[SerializableGameDataField]
	public int Seniority;

	[SerializableGameDataField]
	public int ExtraSeniority;

	[SerializableGameDataField]
	public int[] SkillOffCooldownDates;

	[Obsolete]
	public int ProfessionOffCooldownDate;

	[SerializableGameDataField]
	public bool[] HadBeenUnlocked;

	[SerializableGameDataField]
	public IProfessionSkillsData SkillsData;

	[SerializableGameDataField]
	public bool[] LearnedSkills;

	private const int SkillCount = 4;

	public int GetSkillCount()
	{
		ProfessionItem professionItem = Config.Profession.Instance[TemplateId];
		int skillCount = professionItem.ProfessionSkills.Length;
		if (professionItem.ExtraProfessionSkill >= 0)
		{
			skillCount++;
		}
		return skillCount;
	}

	public ProfessionData(int templateId, sbyte type)
	{
		TemplateId = templateId;
		SkillOffCooldownDates = new int[4];
		HadBeenUnlocked = new bool[4];
		Type = type;
		SkillsData = CreateExtraData(TemplateId, type);
	}

	public ProfessionData(ObsoleteProfessionData obsoleteProfessionData)
	{
		TemplateId = obsoleteProfessionData.TemplateId;
		Seniority = 300 * obsoleteProfessionData.Seniority;
		ExtraSeniority = 0;
		SkillOffCooldownDates = new int[4];
		for (int i = 0; i < obsoleteProfessionData.SkillOffCooldownDates.Length; i++)
		{
			SkillOffCooldownDates[i] = obsoleteProfessionData.SkillOffCooldownDates[i];
		}
		HadBeenUnlocked = new bool[4];
		for (int j = 0; j < obsoleteProfessionData.HadBeenUnlocked.Length; j++)
		{
			HadBeenUnlocked[j] = obsoleteProfessionData.HadBeenUnlocked[j];
		}
		SkillsData = CreateExtraData(obsoleteProfessionData.TemplateId, 0);
		SkillsData?.InheritFrom(obsoleteProfessionData.SkillsData);
		OfflineUpdateHadBeenUnlocked(isInherit: true);
	}

	public ProfessionItem GetConfig()
	{
		return Config.Profession.Instance[TemplateId];
	}

	public ProfessionSkillItem GetSkillConfig(int index)
	{
		ProfessionItem professionCfg = GetConfig();
		if (index < professionCfg.ProfessionSkills.Length)
		{
			return ProfessionSkill.Instance[professionCfg.ProfessionSkills[index]];
		}
		return ProfessionSkill.Instance[professionCfg.ExtraProfessionSkill];
	}

	public int GetSkillIndex(int skillId)
	{
		ProfessionItem professionCfg = GetConfig();
		int index = professionCfg.ProfessionSkills.IndexOf(skillId);
		if (index > -1)
		{
			return index;
		}
		if (skillId == professionCfg.ExtraProfessionSkill)
		{
			return professionCfg.ProfessionSkills.Length;
		}
		return -1;
	}

	[Obsolete]
	public bool IsProfessionAvailable(int currDate)
	{
		return currDate >= ProfessionOffCooldownDate;
	}

	public bool IsSkillUnlocked(int skillIndex)
	{
		return Seniority >= SharedMethods.GetSkillUnlockSeniority(SharedMethods.GetSkillId(TemplateId, skillIndex));
	}

	public bool IsSkillLearned(int skillIndex)
	{
		if (LearnedSkills == null || LearnedSkills.Length <= skillIndex)
		{
			return false;
		}
		return LearnedSkills[skillIndex];
	}

	public void SetSkillLearned(int skillIndex)
	{
		if (LearnedSkills == null)
		{
			LearnedSkills = new bool[4];
		}
		LearnedSkills[skillIndex] = true;
	}

	public int GetUnlockedSkillCount()
	{
		for (int i = 3; i >= 0; i--)
		{
			if (IsSkillUnlocked(i))
			{
				return i + 1;
			}
		}
		return 0;
	}

	public int GetSeniorityPercent()
	{
		return SeniorityToPercentage(Seniority);
	}

	public void OfflineUpdateHadBeenUnlocked(bool isInherit = false)
	{
		ProfessionItem config = GetConfig();
		int length = config.ProfessionSkills.Length;
		for (int i = 0; i < config.ProfessionSkills.Length; i++)
		{
			if (isInherit)
			{
				HadBeenUnlocked[i] = HadBeenUnlocked[i] && IsSkillUnlocked(i);
			}
			else
			{
				HadBeenUnlocked[i] = HadBeenUnlocked[i] || IsSkillUnlocked(i);
			}
		}
		if (config.ExtraProfessionSkill >= 0)
		{
			if (isInherit)
			{
				HadBeenUnlocked[length] = HadBeenUnlocked[length] && IsSkillUnlocked(length);
			}
			else
			{
				HadBeenUnlocked[length] = HadBeenUnlocked[length] || IsSkillUnlocked(length);
			}
		}
	}

	public bool IsSkillCooldown(int currDate, int skillIndex)
	{
		if (ExternalDataBridge.Context.NoProfessionSkillCooldown)
		{
			return false;
		}
		return currDate < SkillOffCooldownDates[skillIndex];
	}

	public void OfflineSkillCooldown(int skillIndex)
	{
		if (!ExternalDataBridge.Context.NoProfessionSkillCooldown)
		{
			SkillOffCooldownDates[skillIndex] = ExternalDataBridge.Context.CurrDate + GetSkillConfig(skillIndex).SkillCoolDown;
		}
	}

	public void OfflineClearSkillCooldown(int skillIndex)
	{
		if (!ExternalDataBridge.Context.NoProfessionSkillCooldown)
		{
			SkillOffCooldownDates[skillIndex] = 0;
		}
	}

	public T GetSkillsData<T>() where T : IProfessionSkillsData
	{
		return (T)SkillsData;
	}

	private static IProfessionSkillsData CreateExtraData(int templateId, sbyte type)
	{
		if (type != 0)
		{
			return null;
		}
		return templateId switch
		{
			1 => new HunterSkillsData(), 
			5 => new TaoistMonkSkillsData(), 
			6 => new BuddhistMonkSkillsData(), 
			7 => new WineTasterSkillsData(), 
			9 => new BeggarSkillsData(), 
			12 => new TravelingBuddhistMonkSkillsData(), 
			17 => new DukeSkillsData(), 
			8 => new AristocratSkillsData(), 
			14 => new TravelingTaoistMonkSkillsData(), 
			16 => new TeaTasterSkillsData(), 
			11 => new TravelerSkillsData(), 
			2 => new CraftSkillsData(), 
			_ => null, 
		};
	}

	public ProfessionData()
	{
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 15;
		totalSize = ((SkillOffCooldownDates == null) ? (totalSize + 2) : (totalSize + (2 + 4 * SkillOffCooldownDates.Length)));
		totalSize = ((HadBeenUnlocked == null) ? (totalSize + 2) : (totalSize + (2 + HadBeenUnlocked.Length)));
		totalSize = ((SkillsData == null) ? (totalSize + 2) : (totalSize + (2 + SkillsData.GetSerializedSize())));
		totalSize = ((LearnedSkills == null) ? (totalSize + 2) : (totalSize + (2 + LearnedSkills.Length)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 8;
		pCurrData += 2;
		*(int*)pCurrData = TemplateId;
		pCurrData += 4;
		*pCurrData = (byte)Type;
		pCurrData++;
		*(int*)pCurrData = Seniority;
		pCurrData += 4;
		if (SkillOffCooldownDates != null)
		{
			int elementsCount = SkillOffCooldownDates.Length;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				((int*)pCurrData)[i] = SkillOffCooldownDates[i];
			}
			pCurrData += 4 * elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (HadBeenUnlocked != null)
		{
			int elementsCount2 = HadBeenUnlocked.Length;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				pCurrData[j] = (HadBeenUnlocked[j] ? ((byte)1) : ((byte)0));
			}
			pCurrData += elementsCount2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (SkillsData != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = SkillsData.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(int*)pCurrData = ExtraSeniority;
		pCurrData += 4;
		if (LearnedSkills != null)
		{
			int elementsCount3 = LearnedSkills.Length;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				pCurrData[k] = (LearnedSkills[k] ? ((byte)1) : ((byte)0));
			}
			pCurrData += elementsCount3;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort fieldCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (fieldCount > 0)
		{
			TemplateId = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 1)
		{
			Type = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (fieldCount > 2)
		{
			Seniority = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 3)
		{
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				if (SkillOffCooldownDates == null || SkillOffCooldownDates.Length != elementsCount)
				{
					SkillOffCooldownDates = new int[elementsCount];
				}
				for (int i = 0; i < elementsCount; i++)
				{
					SkillOffCooldownDates[i] = ((int*)pCurrData)[i];
				}
				pCurrData += 4 * elementsCount;
			}
			else
			{
				SkillOffCooldownDates = null;
			}
		}
		if (fieldCount > 4)
		{
			ushort elementsCount2 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount2 > 0)
			{
				if (HadBeenUnlocked == null || HadBeenUnlocked.Length != elementsCount2)
				{
					HadBeenUnlocked = new bool[elementsCount2];
				}
				for (int j = 0; j < elementsCount2; j++)
				{
					HadBeenUnlocked[j] = pCurrData[j] != 0;
				}
				pCurrData += (int)elementsCount2;
			}
			else
			{
				HadBeenUnlocked = null;
			}
		}
		if (fieldCount > 5)
		{
			ushort num = *(ushort*)pCurrData;
			pCurrData += 2;
			if (num > 0)
			{
				if (SkillsData == null)
				{
					SkillsData = CreateExtraData(TemplateId, Type);
				}
				pCurrData += SkillsData.Deserialize(pCurrData);
			}
			else
			{
				SkillsData = CreateExtraData(TemplateId, Type);
			}
		}
		if (fieldCount > 6)
		{
			ExtraSeniority = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 7)
		{
			ushort elementsCount3 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount3 > 0)
			{
				if (LearnedSkills == null || LearnedSkills.Length != elementsCount3)
				{
					LearnedSkills = new bool[elementsCount3];
				}
				for (int k = 0; k < elementsCount3; k++)
				{
					LearnedSkills[k] = pCurrData[k] != 0;
				}
				pCurrData += (int)elementsCount3;
			}
			else
			{
				LearnedSkills = null;
			}
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public int GetSeniorityOrgGrade()
	{
		return SeniorityToOrgGrade(Seniority);
	}

	public int GetSeniorityMainAttributeAdditional()
	{
		return SeniorityToMainAttributeAdditional(Seniority);
	}

	public int GetSeniorityVisionRangeBonus()
	{
		return SeniorityToVisionRangeBonus(Seniority);
	}

	public int SeniorityToTeleportDistance()
	{
		return SeniorityToTeleportDistance(Seniority);
	}

	public int GetSeniorityResourceRecoveryFactor()
	{
		return SeniorityToResourceRecoveryFactor(Seniority);
	}

	public int GetSeniorityAttainmentBonus()
	{
		return SeniorityToAttainmentBonus(Seniority);
	}

	public int GetSeniorityEmptyToolAttainmentBonus()
	{
		return SeniorityToEmptyToolAttainmentBonus(Seniority);
	}

	public int GetSeniorityChangeWeaponTrickCostResource(int changeTrickCountToLast, sbyte weaponGrade)
	{
		return changeTrickCountToLast * (weaponGrade + 1) * 1000 * (100 - GetSeniorityChangeWeaponTrickCostResourceReduceRate()) / 100;
	}

	public int GetSeniorityChangeWeaponTrickCostResourceReduceRate()
	{
		return SeniorityToChangeWeaponTrickCostResourceReduceRate(Seniority);
	}

	public int GetChangeWeaponTrickCostMaterialGrade(sbyte weaponGrade)
	{
		return Math.Clamp(weaponGrade - 1, 1, 7);
	}

	public int GetChangeWeaponTrickCostMaterialCount(int changeTrickCountToOrigin)
	{
		if (changeTrickCountToOrigin != 0)
		{
			return (int)Math.Pow(2.0, changeTrickCountToOrigin - 1);
		}
		return 0;
	}

	public int GetSeniorityTreatmentCharge()
	{
		return SeniorityToTreatmentCharge(Seniority);
	}

	public int GetSeniorityTradeCostFactor()
	{
		return SeniorityToTradeCostFactor(Seniority);
	}

	public sbyte GetSeniorityCaravanGrade()
	{
		return SeniorityToCaravanGrade(Seniority);
	}

	public (int sell, int buy) SeniorityToCaravanPrice()
	{
		return SeniorityToCaravanPrice(Seniority);
	}

	public CValuePercentBonus GetSeniorityToWineTasterSolarTermBonus(int wineCount)
	{
		return SeniorityToWineTasterSolarTermBonus(Seniority, wineCount);
	}

	public int GetInfluencePowerBonusFactor()
	{
		return SeniorityToInfluencePowerBonusFactor(Seniority);
	}

	public sbyte GetSeniorityGrowingGrade(IRandomSource random)
	{
		return SeniorityToGrowingGrade(Seniority, random);
	}

	public sbyte GetSeniorityGrowingGrade()
	{
		return SeniorityToGrowingGrade(Seniority);
	}

	public sbyte GetSeniorityFeatureUpgradeCount(IRandomSource random)
	{
		return SeniorityToFeatureUpgradeCount(Seniority, random);
	}

	public int GetSeniorityAuthorityGain()
	{
		return SeniorityToAuthorityGain(Seniority);
	}

	public int GetSeniorityCultureGain()
	{
		return SeniorityToCultureGain(Seniority);
	}

	public int GetSenioritySafetyGain()
	{
		return SeniorityToSafetyGain(Seniority);
	}

	public sbyte GetSeniorityGiftLevelReduce()
	{
		return SeniorityToGiftLevelReduce(Seniority);
	}

	public sbyte GetSeniorityFavorAddPercent()
	{
		return GetSeniorityFavorAddPercent(Seniority);
	}

	public sbyte GetSeniorityAnimalCount()
	{
		return SeniorityToAnimalCount(Seniority);
	}

	public int GetSeniorityHunterAnimalBonus()
	{
		return SeniorityHunterAnimalBonus(Seniority);
	}

	public sbyte GetSeniorityCallAnimalGrade()
	{
		return SeniorityCallAnimalGrade(Seniority);
	}

	public int GetSeniorityBeggingMoneyBaseValue()
	{
		return SeniorityToBeggingMoneyBaseValue(Seniority);
	}

	public sbyte GetSeniorityDoctorMaxSettlementType()
	{
		return SeniorityToDoctorMaxSettlementType(Seniority);
	}

	public short GetSeniorityDoctorMedicinePricePercent()
	{
		return GetSeniorityDoctorMedicinePricePercent(Seniority);
	}

	public short GetSeniorityDoctorFavorAddPercent()
	{
		return GetSeniorityDoctorFavorAddPercent(Seniority);
	}

	public int GetTaoistMonkSkill3AuthorityPara()
	{
		return GetTaoistMonkSkill3AuthorityPara(Seniority);
	}

	public sbyte GetSeniorityBeggarMaxSettlementType()
	{
		return SeniorityToBeggarMaxSettlementType(Seniority);
	}

	public int GetFameChange()
	{
		return FameAction.Instance[(short)56].Fame;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public int GetMainAttributesRecoveryBonusAppliedRate(sbyte mainAttributeType, int baseRecovery)
	{
		baseRecovery += baseRecovery * (100 + GetSeniorityPercent()) / 100;
		return baseRecovery;
	}

	public int GetSeniorityOrgGradeXiangshuSkill0()
	{
		return SeniorityOrgGradeXiangshuSkill0(Seniority);
	}

	public int GetXiangshuSkill1InfectionChange()
	{
		return GetXiangshuSkill1InfectionChange(Seniority);
	}

	public int GetXiangshuSkill2MinionCount()
	{
		return GetXiangshuSkill2MinionCount(Seniority);
	}

	public List<short> GetXiangshuSkill2MinionTemplateIdList()
	{
		return GetXiangshuSkill2MinionTemplateIdList(Seniority);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int SeniorityToPercentage(int seniority)
	{
		return seniority * 100 / 3000000;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static sbyte SeniorityToOrgGrade(int seniority)
	{
		int seniorityPercent = SeniorityToPercentage(seniority);
		if (seniorityPercent >= 90)
		{
			return 8;
		}
		if (seniorityPercent >= 70)
		{
			return 7;
		}
		if (seniorityPercent >= 50)
		{
			return 6;
		}
		if (seniorityPercent >= 30)
		{
			return 4;
		}
		return 2;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int SeniorityToMainAttributeAdditional(int seniority)
	{
		return 10 + 20 * SeniorityToPercentage(seniority) / 100;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int SeniorityToVisionRangeBonus(int seniority)
	{
		return 10 * SeniorityToPercentage(seniority) / 100;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int SeniorityToTeleportDistance(int seniority)
	{
		int percentage = SeniorityToPercentage(seniority);
		return 10 + 10 * (percentage / 100);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int SeniorityToResourceRecoveryFactor(int seniority)
	{
		return 33 + 33 * seniority / 3000000;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int SeniorityToEmptyToolAttainmentBonus(int seniority)
	{
		return 50 * seniority / 3000000 - 50;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int SeniorityToChangeWeaponTrickCostResourceReduceRate(int seniority)
	{
		return 50 * seniority / 3000000;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int SeniorityToAttainmentBonus(int seniority)
	{
		return 33 + 33 * seniority / 3000000;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int SeniorityToTreatmentCharge(int seniority)
	{
		return 100 + 2900 * seniority / 3000000;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int SeniorityToTradeCostFactor(int seniority)
	{
		return 500;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static sbyte SeniorityToCaravanGrade(int seniority)
	{
		return (sbyte)(SeniorityToPercentage(seniority) / 15);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static (int sell, int buy) SeniorityToCaravanPrice(int seniority)
	{
		int percentage = SeniorityToPercentage(seniority);
		return (sell: 25 * percentage / 100, buy: -25 * percentage / 100);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static CValuePercentBonus SeniorityToWineTasterSolarTermBonus(int seniority, int wineCount)
	{
		return wineCount * 20 * SeniorityToPercentage(seniority) / 100;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int SeniorityToInfluencePowerBonusFactor(int seniority)
	{
		return 50 + SeniorityToPercentage(seniority) / 2;
	}

	public static sbyte SeniorityToGrowingGrade(int seniority, IRandomSource random)
	{
		return (sbyte)(random.Next(ProfessionRelatedConstants.AristocratGradeRange[0], ProfessionRelatedConstants.AristocratGradeRange[1] + 1) + SeniorityToGrowingGrade(seniority));
	}

	public static sbyte SeniorityToGrowingGrade(int seniority)
	{
		int percentage = SeniorityToPercentage(seniority);
		return (sbyte)(3 * percentage / 100);
	}

	public static sbyte SeniorityToFeatureUpgradeCount(int seniority, IRandomSource random)
	{
		int percentage = SeniorityToPercentage(seniority);
		float level1Prob = Math.Max(0, 100 - 3 * percentage / 4);
		float level2Prob = percentage / 2;
		float randomValue = random.NextFloat() * 100f;
		if (randomValue < level1Prob)
		{
			return 1;
		}
		if (randomValue < level1Prob + level2Prob)
		{
			return 2;
		}
		return 3;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int SeniorityToAuthorityGain(int seniority)
	{
		return seniority / 5;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int SeniorityToCultureGain(int seniority)
	{
		return seniority / 400;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int SeniorityToSafetyGain(int seniority)
	{
		return seniority / 400;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static sbyte SeniorityToGiftLevelReduce(int seniority)
	{
		int percentage = SeniorityToPercentage(seniority);
		return (sbyte)(1 + 4 * percentage / 100);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static sbyte GetSeniorityFavorAddPercent(int seniority)
	{
		int percentage = SeniorityToPercentage(seniority);
		return (sbyte)(33 + 33 * percentage / 100);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int GetSeniorityCivilianAddHatredLimit(int seniority)
	{
		int percentage = SeniorityToPercentage(seniority);
		return 12 - 8 * percentage / 100;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int GetSeniorityCivilianSeverHatredLimit(int seniority)
	{
		int percentage = SeniorityToPercentage(seniority);
		return 3 + 3 * percentage / 100;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static sbyte SeniorityToAnimalCount(int seniority)
	{
		int percentage = SeniorityToPercentage(seniority);
		for (sbyte i = 0; i < GlobalConfig.Instance.HunterSkill2_SeniorityPercentToAnimalCount.Length; i++)
		{
			if (percentage < GlobalConfig.Instance.HunterSkill2_SeniorityPercentToAnimalCount[i])
			{
				return (sbyte)(i + 1);
			}
		}
		return (sbyte)GlobalConfig.Instance.HunterSkill2_SeniorityPercentToAnimalCount.Length;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int SeniorityHunterAnimalBonus(int seniority)
	{
		int seniorityPercentage = SeniorityToPercentage(seniority);
		return 33 + 33 * seniorityPercentage / 100;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static sbyte SeniorityCallAnimalGrade(int seniority)
	{
		if (SeniorityToPercentage(seniority) >= 90)
		{
			return 7;
		}
		if (SeniorityToPercentage(seniority) >= 75)
		{
			return 6;
		}
		if (SeniorityToPercentage(seniority) >= 60)
		{
			return 5;
		}
		if (SeniorityToPercentage(seniority) >= 45)
		{
			return 4;
		}
		return 3;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int SeniorityToBeggingMoneyBaseValue(int seniority)
	{
		return 10 + SeniorityToPercentage(seniority);
	}

	public static sbyte SeniorityToDoctorMaxSettlementType(int seniority)
	{
		int percentage = SeniorityToPercentage(seniority);
		if (percentage >= 60)
		{
			return 3;
		}
		if (percentage >= 50)
		{
			return 2;
		}
		if (percentage >= 40)
		{
			return 1;
		}
		if (percentage >= 30)
		{
			return 0;
		}
		return -1;
	}

	public static short GetSeniorityDoctorMedicinePricePercent(int seniority)
	{
		int percentage = SeniorityToPercentage(seniority);
		return (short)(150 + 150 * percentage / 100);
	}

	public static short GetSeniorityDoctorFavorAddPercent(int seniority)
	{
		int percentage = SeniorityToPercentage(seniority);
		return (short)(150 + 150 * percentage / 100);
	}

	public static short GetTaoistMonkSkill3AuthorityPara(int seniority)
	{
		int percentage = SeniorityToPercentage(seniority);
		return (short)(30 + percentage * 60 / 100);
	}

	public static sbyte SeniorityToBeggarMaxSettlementType(int seniority)
	{
		int percentage = SeniorityToPercentage(seniority);
		if (percentage >= 30)
		{
			return 3;
		}
		if (percentage >= 20)
		{
			return 2;
		}
		if (percentage >= 10)
		{
			return 1;
		}
		return 0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int SeniorityToExtraReadingLoopingStrategyCount(int seniority)
	{
		return 1 + 2 * seniority / 3000000;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static sbyte SeniorityOrgGradeXiangshuSkill0(int seniority)
	{
		int seniorityPercent = SeniorityToPercentage(seniority);
		int maxAffectedGrade = ProfessionRelatedConstants.XiangshuSkill0MaxAffectedGradeRules[0].Grade;
		(int, int)[] xiangshuSkill0MaxAffectedGradeRules = ProfessionRelatedConstants.XiangshuSkill0MaxAffectedGradeRules;
		for (int i = 0; i < xiangshuSkill0MaxAffectedGradeRules.Length; i++)
		{
			(int, int) rule = xiangshuSkill0MaxAffectedGradeRules[i];
			if (seniorityPercent >= rule.Item1)
			{
				maxAffectedGrade = rule.Item2;
			}
		}
		return (sbyte)maxAffectedGrade;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public short GetXiangshuSkill1InfectionChange(int seniority)
	{
		return (short)((float)SeniorityToPercentage(seniority) * 62.5f / 100f + 37.5f);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public short GetXiangshuSkill2MinionCount(int seniority)
	{
		int seniorityPercent = SeniorityToPercentage(seniority);
		int ratioPercent = ProfessionRelatedConstants.XiangshuSkill2MinionCountRules[0].RatioPercent;
		(int, int)[] xiangshuSkill2MinionCountRules = ProfessionRelatedConstants.XiangshuSkill2MinionCountRules;
		for (int i = 0; i < xiangshuSkill2MinionCountRules.Length; i++)
		{
			(int, int) rule = xiangshuSkill2MinionCountRules[i];
			if (seniorityPercent >= rule.Item1)
			{
				ratioPercent = rule.Item2;
			}
		}
		return (short)(20 * ratioPercent / 100);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public List<short> GetXiangshuSkill2MinionTemplateIdList(int seniority)
	{
		int seniorityPercent = SeniorityToPercentage(seniority);
		List<short> templateIdList = new List<short>();
		if (seniorityPercent >= 100)
		{
			templateIdList.Add(374);
			return templateIdList;
		}
		int minIndex = ProfessionRelatedConstants.XiangshuSkill2MinionTemplateTierRules[0].MinIndex;
		int maxIndex = ProfessionRelatedConstants.XiangshuSkill2MinionTemplateTierRules[0].MaxIndex;
		(int, int, int)[] xiangshuSkill2MinionTemplateTierRules = ProfessionRelatedConstants.XiangshuSkill2MinionTemplateTierRules;
		for (int i = 0; i < xiangshuSkill2MinionTemplateTierRules.Length; i++)
		{
			(int, int, int) rule = xiangshuSkill2MinionTemplateTierRules[i];
			if (seniorityPercent >= rule.Item1)
			{
				minIndex = rule.Item2;
				maxIndex = rule.Item3;
			}
		}
		for (int j = 366 + minIndex; j <= 366 + maxIndex; j++)
		{
			templateIdList.Add((short)j);
		}
		return templateIdList;
	}
}
