using System;
using System.Runtime.CompilerServices;
using Config;
using GameData.Combat.Math;
using GameData.Domains.Taiwu.Profession.SkillsData;
using GameData.Serializer;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.Domains.Taiwu.Profession;

/// <summary>
/// 职业 (志向) 相关数据
/// </summary>
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

	/// <summary>
	/// 志向的模板 ID
	/// </summary>
	[SerializableGameDataField]
	public int TemplateId;

	/// <summary>
	/// 类型. <see cref="T:GameData.Domains.Taiwu.Profession.ProfessionDataType" />
	/// </summary>
	[SerializableGameDataField]
	public sbyte Type = -1;

	/// <summary>
	/// 志向的资历
	/// </summary>
	[SerializableGameDataField]
	public int Seniority;

	/// <summary>
	/// 志向的额外资历
	/// </summary>
	[SerializableGameDataField]
	public int ExtraSeniority;

	/// <summary>
	/// 技能冷却结束时间, 小于当前时间表示技能不在冷却
	/// </summary>
	[SerializableGameDataField]
	public int[] SkillOffCooldownDates;

	/// <summary>
	/// 转职冷却结束日期
	/// </summary>
	[Obsolete]
	public int ProfessionOffCooldownDate;

	/// <summary>
	/// 是否被解锁过
	/// </summary>
	[SerializableGameDataField]
	public bool[] HadBeenUnlocked;

	/// <summary>
	/// 职业技能相关数据, 为 null 表示没有技能相关存档数据
	/// </summary>
	[SerializableGameDataField]
	public IProfessionSkillsData SkillsData;

	/// <summary>
	/// 已领悟的技能（一志难求词条）
	/// </summary>
	[SerializableGameDataField]
	public bool[] LearnedSkills;

	private const int SkillCount = 4;

	/// <summary>
	/// 获取技能总数量
	/// </summary>
	/// <returns></returns>
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

	/// <summary>
	/// 获得志向模板数据
	/// </summary>
	/// <returns></returns>
	public ProfessionItem GetConfig()
	{
		return Config.Profession.Instance[TemplateId];
	}

	/// <summary>
	/// 获得志向技能模板数据
	/// </summary>
	/// <param name="index"></param>
	/// <returns></returns>
	public ProfessionSkillItem GetSkillConfig(int index)
	{
		ProfessionItem professionCfg = GetConfig();
		if (index < professionCfg.ProfessionSkills.Length)
		{
			return ProfessionSkill.Instance[professionCfg.ProfessionSkills[index]];
		}
		return ProfessionSkill.Instance[professionCfg.ExtraProfessionSkill];
	}

	/// <summary>
	/// 根据技能ID获取技能序号
	/// </summary>
	/// <param name="skillId"></param>
	/// <returns></returns>
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

	/// <summary>
	/// 是否可以转职到当前职业
	/// </summary>
	/// <param name="currDate"></param>
	/// <returns></returns>
	[Obsolete]
	public bool IsProfessionAvailable(int currDate)
	{
		return currDate >= ProfessionOffCooldownDate;
	}

	/// <summary>
	/// 指定技能是否已解锁
	/// </summary>
	/// <param name="skillIndex"></param>
	/// <returns></returns>
	public bool IsSkillUnlocked(int skillIndex)
	{
		return Seniority >= SharedMethods.GetSkillUnlockSeniority(SharedMethods.GetSkillId(TemplateId, skillIndex));
	}

	/// <summary>
	/// 指定技能是否已领悟（一志难求词条）
	/// </summary>
	/// <param name="skillIndex"></param>
	/// <returns></returns>
	public bool IsSkillLearned(int skillIndex)
	{
		if (LearnedSkills == null || LearnedSkills.Length <= skillIndex)
		{
			return false;
		}
		return LearnedSkills[skillIndex];
	}

	/// <summary>
	/// 设置技能已领悟（一志难求词条）
	/// </summary>
	/// <param name="skillIndex"></param>
	public void SetSkillLearned(int skillIndex)
	{
		if (LearnedSkills == null)
		{
			LearnedSkills = new bool[4];
		}
		LearnedSkills[skillIndex] = true;
	}

	/// <summary>
	/// 解锁的技能数量
	/// </summary>
	/// <returns></returns>
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

	/// <summary>
	/// 获得当前资历的百分比
	/// </summary>
	/// <returns></returns>
	public int GetSeniorityPercent()
	{
		return SeniorityToPercentage(Seniority);
	}

	/// <summary>
	/// 刷新职业是否被解锁过，需要在志向发生变化时调用
	/// </summary>
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

	/// <summary>
	/// 技能是否处于冷却
	/// </summary>
	/// <param name="currDate"></param>
	/// <param name="skillIndex"></param>
	/// <returns></returns>
	public bool IsSkillCooldown(int currDate, int skillIndex)
	{
		if (ExternalDataBridge.Context.NoProfessionSkillCooldown)
		{
			return false;
		}
		return currDate < SkillOffCooldownDates[skillIndex];
	}

	/// <summary>
	/// 技能进行冷却
	/// </summary>
	/// <param name="skillIndex"></param>
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

	/// <summary>
	/// 获取技能相关的额外数据
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <returns></returns>
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

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public ProfessionData()
	{
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
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

	/// <summary>
	/// 获取当前资历对应的人物身份品级
	/// </summary>
	/// <returns></returns>
	public int GetSeniorityOrgGrade()
	{
		return SeniorityToOrgGrade(Seniority);
	}

	/// <summary>
	/// 获取当前资历对应的主要属性恢复量
	/// </summary>
	public int GetSeniorityMainAttributeAdditional()
	{
		return SeniorityToMainAttributeAdditional(Seniority);
	}

	/// <summary>
	/// 获取当前资历对应的视野范围加成 (旅人 - 绘制地图)
	/// </summary>
	public int GetSeniorityVisionRangeBonus()
	{
		return SeniorityToVisionRangeBonus(Seniority);
	}

	/// <summary>
	/// 旅人三技能-能够传送的距离半径
	/// </summary>
	/// <returns></returns>
	public int SeniorityToTeleportDistance()
	{
		return SeniorityToTeleportDistance(Seniority);
	}

	/// <summary>
	/// 获取当前资历对应的资源恢复量 (山人 - 休养生息)
	/// </summary>
	/// <returns></returns>
	public int GetSeniorityResourceRecoveryFactor()
	{
		return SeniorityToResourceRecoveryFactor(Seniority);
	}

	/// <summary>
	/// 获取当前资历对应的造诣加成 (匠人 - 行规用矩)
	/// </summary>
	/// <returns></returns>
	public int GetSeniorityAttainmentBonus()
	{
		return SeniorityToAttainmentBonus(Seniority);
	}

	/// <summary>
	/// 获取当前资历对应的徒手工具造诣加成 (匠人 - 匠心巧手)
	/// </summary>
	/// <returns></returns>
	public int GetSeniorityEmptyToolAttainmentBonus()
	{
		return SeniorityToEmptyToolAttainmentBonus(Seniority);
	}

	/// <summary>
	/// 获取当前资历对应的消耗的资源量（匠人 - 独具匠心）
	/// </summary>
	/// <returns></returns>
	public int GetSeniorityChangeWeaponTrickCostResource(int changeTrickCountToLast, sbyte weaponGrade)
	{
		return changeTrickCountToLast * (weaponGrade + 1) * 1000 * (100 - GetSeniorityChangeWeaponTrickCostResourceReduceRate()) / 100;
	}

	/// <summary>
	/// 获取当前资历对应的资源减免（匠人 - 独具匠心）
	/// </summary>
	/// <returns></returns>
	public int GetSeniorityChangeWeaponTrickCostResourceReduceRate()
	{
		return SeniorityToChangeWeaponTrickCostResourceReduceRate(Seniority);
	}

	/// <summary>
	/// 获取消耗的引子品级（匠人 - 独具匠心）
	/// </summary>
	/// <returns></returns>
	public int GetChangeWeaponTrickCostMaterialGrade(sbyte weaponGrade)
	{
		return Math.Clamp(weaponGrade - 1, 1, 7);
	}

	/// <summary>
	/// 获取消耗的引子数量（匠人 - 独具匠心）
	/// </summary>
	/// <returns></returns>
	public int GetChangeWeaponTrickCostMaterialCount(int changeTrickCountToOrigin)
	{
		if (changeTrickCountToOrigin != 0)
		{
			return (int)Math.Pow(2.0, changeTrickCountToOrigin - 1);
		}
		return 0;
	}

	/// <summary>
	/// 获取当前资历对应的疗伤收费 (大夫 - 看诊施药)
	/// </summary>
	/// <returns></returns>
	public int GetSeniorityTreatmentCharge()
	{
		return SeniorityToTreatmentCharge(Seniority);
	}

	/// <summary>
	/// 获取当前资历对应的购买道具价格因子百分比 (富商 - 慧眼识珠)
	/// </summary>
	/// <returns></returns>
	public int GetSeniorityTradeCostFactor()
	{
		return SeniorityToTradeCostFactor(Seniority);
	}

	/// <summary>
	/// 获取当前资历对应的商队等级 (富商 - 召集商队)
	/// </summary>
	/// <returns></returns>
	public sbyte GetSeniorityCaravanGrade()
	{
		return SeniorityToCaravanGrade(Seniority);
	}

	/// <summary>
	/// 获取当前资历对应的买卖价格 (富商 - 召集商队)
	/// </summary>
	/// <returns></returns>
	public (int sell, int buy) SeniorityToCaravanPrice()
	{
		return SeniorityToCaravanPrice(Seniority);
	}

	/// <summary>
	/// 获取当前资历对应的行酒令额外增益数值（豪客 - 酒中真仙）
	/// </summary>
	/// <returns></returns>
	public CValuePercentBonus GetSeniorityToWineTasterSolarTermBonus(int wineCount)
	{
		return SeniorityToWineTasterSolarTermBonus(Seniority, wineCount);
	}

	/// <summary>
	/// 获取当前资历对应的势力值增加 (名门 - 代人说项)
	/// </summary>
	/// <returns></returns>
	public int GetInfluencePowerBonusFactor()
	{
		return SeniorityToInfluencePowerBonusFactor(Seniority);
	}

	/// <summary>
	/// 获取当前资历对应的资质成长阶级 (名门 - 采擢荐进)
	/// </summary>
	/// <returns></returns>
	public sbyte GetSeniorityGrowingGrade(IRandomSource random)
	{
		return SeniorityToGrowingGrade(Seniority, random);
	}

	/// <summary>
	/// 获取当前资历对应的资质成长阶级 (名门 - 采擢荐进)
	/// </summary>
	/// <returns></returns>
	public sbyte GetSeniorityGrowingGrade()
	{
		return SeniorityToGrowingGrade(Seniority);
	}

	/// <summary>
	/// 培养等级（升级次数）
	/// </summary>
	/// <returns></returns>
	public sbyte GetSeniorityFeatureUpgradeCount(IRandomSource random)
	{
		return SeniorityToFeatureUpgradeCount(Seniority, random);
	}

	/// <summary>
	/// 获取当前资历对应的威望获得量 (才俊 - 礼乐之教, 武师 - 保镖护院)
	/// </summary>
	/// <returns></returns>
	public int GetSeniorityAuthorityGain()
	{
		return SeniorityToAuthorityGain(Seniority);
	}

	/// <summary>
	/// 获取当前资历对应的文化增长 (才俊 - 礼乐之教)
	/// </summary>
	/// <returns></returns>
	public int GetSeniorityCultureGain()
	{
		return SeniorityToCultureGain(Seniority);
	}

	/// <summary>
	/// 获取当前资历对应的安定增长 (武师 - 保镖护院)
	/// </summary>
	/// <returns></returns>
	public int GetSenioritySafetyGain()
	{
		return SeniorityToSafetyGain(Seniority);
	}

	/// <summary>
	/// 根据资历，减少门派人物对收礼级别的需求（武师 - 江湖中人;平民-父老乡亲）
	/// </summary>
	/// <returns></returns>
	public sbyte GetSeniorityGiftLevelReduce()
	{
		return SeniorityToGiftLevelReduce(Seniority);
	}

	/// <summary>
	/// 根据资历，提升好感增加百分比（武师 - 江湖中人;平民-父老乡亲）
	/// </summary>
	/// <returns></returns>
	public sbyte GetSeniorityFavorAddPercent()
	{
		return GetSeniorityFavorAddPercent(Seniority);
	}

	/// <summary>
	/// 获取当前资历对应的发现野兽的数量 (猎户 - 追踪野兽)
	/// </summary>
	/// <returns></returns>
	public sbyte GetSeniorityAnimalCount()
	{
		return SeniorityToAnimalCount(Seniority);
	}

	/// <summary>
	/// 获取当前资历对应的狩猎野兽加成百分比
	/// </summary>
	/// <returns></returns>
	public int GetSeniorityHunterAnimalBonus()
	{
		return SeniorityHunterAnimalBonus(Seniority);
	}

	/// <summary>
	/// 获取当前资历对应的能够召集野兽的等级 (猎户 - 召集野兽)
	/// </summary>
	/// <returns></returns>
	public sbyte GetSeniorityCallAnimalGrade()
	{
		return SeniorityCallAnimalGrade(Seniority);
	}

	/// <summary>
	/// 获取当前资历对应的乞讨银钱基础值 (乞丐 - 托钵行乞)
	/// </summary>
	/// <returns></returns>
	public int GetSeniorityBeggingMoneyBaseValue()
	{
		return SeniorityToBeggingMoneyBaseValue(Seniority);
	}

	/// <summary>
	/// 获取当前资历对应的定居点类型 (大夫 - 游医义诊)
	/// </summary>
	/// <returns><see cref="T:GameData.Domains.Taiwu.Profession.ProfessionRelatedConstants.SettlementType" /></returns>
	public sbyte GetSeniorityDoctorMaxSettlementType()
	{
		return SeniorityToDoctorMaxSettlementType(Seniority);
	}

	/// <summary>
	/// 大夫的药收费 (大夫 - 看诊施药)
	/// </summary>
	/// <returns></returns>
	public short GetSeniorityDoctorMedicinePricePercent()
	{
		return GetSeniorityDoctorMedicinePricePercent(Seniority);
	}

	/// <summary>
	/// 好感增加百分比 (大夫 - 看诊施药)
	/// </summary>
	/// <returns></returns>
	public short GetSeniorityDoctorFavorAddPercent()
	{
		return GetSeniorityDoctorFavorAddPercent(Seniority);
	}

	/// <summary>
	/// 道长二技能（驱邪法事）获得的威望系数
	/// </summary>
	/// <returns></returns>
	public int GetTaoistMonkSkill3AuthorityPara()
	{
		return GetTaoistMonkSkill3AuthorityPara(Seniority);
	}

	/// <summary>
	/// 资历对应的定居点类型 (乞丐 - 托钵行乞)
	/// </summary>
	/// <returns>GameData.Domains.Taiwu.Profession.ProfessionRelatedConstants.SettlementType</returns>
	public sbyte GetSeniorityBeggarMaxSettlementType()
	{
		return SeniorityToBeggarMaxSettlementType(Seniority);
	}

	/// <summary>
	/// 获取志向技能会造成的名誉变化 (乞丐 - 芜行俚语)
	/// </summary>
	public int GetFameChange()
	{
		return FameAction.Instance[(short)56].Fame;
	}

	/// <summary>
	/// 获取主属性恢复加成后的值
	/// </summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public int GetMainAttributesRecoveryBonusAppliedRate(sbyte mainAttributeType, int baseRecovery)
	{
		baseRecovery += baseRecovery * (100 + GetSeniorityPercent()) / 100;
		return baseRecovery;
	}

	/// <summary>
	/// 资历对应的资历百分比
	/// </summary>
	/// <param name="seniority"></param>
	/// <returns></returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int SeniorityToPercentage(int seniority)
	{
		return seniority * 100 / 3000000;
	}

	/// <summary>
	/// 资历对应的人物身份品级
	/// </summary>
	/// <param name="seniority">当前资历</param>
	/// <returns>人物身份品级 <see cref="T:GameData.Domains.Character.Grade" /></returns>
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

	/// <summary>
	/// 资历对应的主要属性恢复量
	/// 10 + 20 * 资历/资历上限
	/// </summary>
	/// <param name="seniority">当前资历</param>
	/// <returns>资历恢复量</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int SeniorityToMainAttributeAdditional(int seniority)
	{
		return 10 + 20 * SeniorityToPercentage(seniority) / 100;
	}

	/// <summary>
	/// 资历对应的视野范围加成 (旅人 - 绘制地图)
	/// (资历 - 2000) / 1000
	/// </summary>
	/// <param name="seniority">当前资历</param>
	/// <returns>视野范围</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int SeniorityToVisionRangeBonus(int seniority)
	{
		return 10 * SeniorityToPercentage(seniority) / 100;
	}

	/// <summary>
	/// 旅人三技能-能够传送的距离半径
	/// </summary>
	/// <param name="seniority"></param>
	/// <returns></returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int SeniorityToTeleportDistance(int seniority)
	{
		int percentage = SeniorityToPercentage(seniority);
		return 10 + 10 * (percentage / 100);
	}

	/// <summary>
	/// 资历对应的资源恢复率 (山人 - 休养生息)
	/// <para>实际恢复量 = 地格各资源最大值 * A / 100</para>
	/// <para>A = (33 + 33 * 资历 / 资历上限)</para>
	/// <para>此处即为 A 的计算</para>
	/// </summary>
	/// <param name="seniority"></param>
	/// <returns></returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int SeniorityToResourceRecoveryFactor(int seniority)
	{
		return 33 + 33 * seniority / 3000000;
	}

	/// <summary>
	/// 资历对应的徒手工具造诣加成 (匠人 - 匠心巧手)
	/// 徒手时的造诣 = 原造诣 * (50 + 50 * 资历/资历上限)% 
	/// </summary>
	/// <param name="seniority"></param>
	/// <returns></returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int SeniorityToEmptyToolAttainmentBonus(int seniority)
	{
		return 50 * seniority / 3000000 - 50;
	}

	/// <summary>
	/// 资历对应的改变武器式的资源减免 (匠人 - 匠心巧手)
	/// （当前资历*50/资历上限）%
	/// </summary>
	/// <param name="seniority"></param>
	/// <returns></returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int SeniorityToChangeWeaponTrickCostResourceReduceRate(int seniority)
	{
		return 50 * seniority / 3000000;
	}

	/// <summary>
	/// 资历对应的造诣加成 (匠人 - 行规用矩)
	/// 工具提供的造诣加成 =（33 + 33*当前资历/资历上限）%
	/// </summary>
	/// <param name="seniority"></param>
	/// <returns></returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int SeniorityToAttainmentBonus(int seniority)
	{
		return 33 + 33 * seniority / 3000000;
	}

	/// <summary>
	/// 资历对应的治疗收费 (大夫 - 看诊施药)
	/// </summary>
	/// <param name="seniority"></param>
	/// <returns></returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int SeniorityToTreatmentCharge(int seniority)
	{
		return 100 + 2900 * seniority / 3000000;
	}

	/// <summary>
	/// 资历对应的道具购买价格百分比因子 (富商 - 慧眼识珠)
	/// </summary>
	/// <param name="seniority"></param>
	/// <returns></returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int SeniorityToTradeCostFactor(int seniority)
	{
		return 500;
	}

	/// <summary>
	/// 资历对应的商队等级 (富商 - 召集商队)
	/// </summary>
	/// <param name="seniority"></param>
	/// <returns></returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static sbyte SeniorityToCaravanGrade(int seniority)
	{
		return (sbyte)(SeniorityToPercentage(seniority) / 15);
	}

	/// <summary>
	/// 资历对应的买卖价格 (富商 - 召集商队)
	/// </summary>
	/// <param name="seniority"></param>
	/// <returns></returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static (int sell, int buy) SeniorityToCaravanPrice(int seniority)
	{
		int percentage = SeniorityToPercentage(seniority);
		return (sell: 25 * percentage / 100, buy: -25 * percentage / 100);
	}

	/// <summary>
	/// 行酒令额外增益数值（豪客 - 酒中真仙）
	/// </summary>
	/// <param name="seniority"></param>
	/// <param name="wineCount">酒类型数量</param>
	/// <returns></returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static CValuePercentBonus SeniorityToWineTasterSolarTermBonus(int seniority, int wineCount)
	{
		return wineCount * 20 * SeniorityToPercentage(seniority) / 100;
	}

	/// <summary>
	/// 资历对应的势力值增加 (名门 - 代人说项)
	/// </summary>
	/// <param name="seniority"></param>
	/// <returns></returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int SeniorityToInfluencePowerBonusFactor(int seniority)
	{
		return 50 + SeniorityToPercentage(seniority) / 2;
	}

	/// <summary>
	/// 资历对应的资质成长阶级 (名门 - 采擢荐进)
	/// </summary>
	/// <param name="seniority"></param>
	/// <param name="random"></param>
	/// <returns></returns>
	public static sbyte SeniorityToGrowingGrade(int seniority, IRandomSource random)
	{
		return (sbyte)(random.Next(ProfessionRelatedConstants.AristocratGradeRange[0], ProfessionRelatedConstants.AristocratGradeRange[1] + 1) + SeniorityToGrowingGrade(seniority));
	}

	/// <summary>
	/// 资历对应的资质成长阶级 (名门 - 采擢荐进)
	/// </summary>
	/// <param name="seniority"></param>
	/// <returns></returns>
	public static sbyte SeniorityToGrowingGrade(int seniority)
	{
		int percentage = SeniorityToPercentage(seniority);
		return (sbyte)(3 * percentage / 100);
	}

	/// <summary>
	/// 资历对应的培养等级 (名门 - 采擢荐进)
	/// </summary>
	/// <param name="seniority"></param>
	/// <param name="random"></param>
	/// <returns></returns>
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

	/// <summary>
	/// 资历对应的威望获得量 (才俊 - 礼乐之教)
	/// </summary>
	/// <param name="seniority"></param>
	/// <returns></returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int SeniorityToAuthorityGain(int seniority)
	{
		return seniority / 5;
	}

	/// <summary>
	/// 资历对应的文化值增长 (才俊 - 礼乐之教)
	/// </summary>
	/// <param name="seniority"></param>
	/// <returns></returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int SeniorityToCultureGain(int seniority)
	{
		return seniority / 400;
	}

	/// <summary>
	/// 资历对应的安定值增长 (武师 - 保镖护院)
	/// </summary>
	/// <param name="seniority"></param>
	/// <returns></returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int SeniorityToSafetyGain(int seniority)
	{
		return seniority / 400;
	}

	/// <summary>
	/// 根据资历，减少门派人物对收礼级别的需求（武师 - 江湖中人;平民-父老乡亲）
	/// </summary>
	/// <param name="seniority"></param>
	/// <returns></returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static sbyte SeniorityToGiftLevelReduce(int seniority)
	{
		int percentage = SeniorityToPercentage(seniority);
		return (sbyte)(1 + 4 * percentage / 100);
	}

	/// <summary>
	/// / 根据资历，提升好感增加百分比（武师 - 江湖中人;平民-父老乡亲）
	/// </summary>
	/// <param name="seniority"></param>
	/// <returns></returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static sbyte GetSeniorityFavorAddPercent(int seniority)
	{
		int percentage = SeniorityToPercentage(seniority);
		return (sbyte)(33 + 33 * percentage / 100);
	}

	/// <summary>
	/// 根据资历获取最大结仇人数（平民-退隐江湖）
	/// </summary>
	/// <param name="seniority"></param>
	/// <returns></returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int GetSeniorityCivilianAddHatredLimit(int seniority)
	{
		int percentage = SeniorityToPercentage(seniority);
		return 12 - 8 * percentage / 100;
	}

	/// <summary>
	/// 根据资历获取最大解仇人数（平民-安居乐业）
	/// </summary>
	/// <param name="seniority"></param>
	/// <returns></returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int GetSeniorityCivilianSeverHatredLimit(int seniority)
	{
		int percentage = SeniorityToPercentage(seniority);
		return 3 + 3 * percentage / 100;
	}

	/// <summary>
	/// 资历对应的发现野兽的数量 (猎户 - 追踪野兽)
	/// </summary>
	/// <param name="seniority"></param>
	/// <returns></returns>
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

	/// <summary>
	/// 资历对应的狩猎野兽加成百分比
	/// </summary>
	/// <param name="seniority"></param>
	/// <returns></returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int SeniorityHunterAnimalBonus(int seniority)
	{
		int seniorityPercentage = SeniorityToPercentage(seniority);
		return 33 + 33 * seniorityPercentage / 100;
	}

	/// <summary>
	/// 资历对应的能够召集野兽的等级 (猎户 - 召集野兽)
	/// </summary>
	/// <param name="seniority"></param>
	/// <returns></returns>
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

	/// <summary>
	/// 资历对应的乞讨银钱基础值 (乞丐 - 托钵行乞)
	/// </summary>
	/// <param name="seniority"></param>
	/// <returns></returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int SeniorityToBeggingMoneyBaseValue(int seniority)
	{
		return 10 + SeniorityToPercentage(seniority);
	}

	/// <summary>
	/// 资历对应的定居点类型 (大夫 - 游医义诊)
	/// </summary>
	/// <param name="seniority"></param>
	/// <returns>GameData.Domains.Taiwu.Profession.ProfessionRelatedConstants.SettlementType</returns>
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

	/// <summary>
	/// 大夫的药收费 (大夫 - 看诊施药)
	/// </summary>
	/// <param name="seniority"></param>
	/// <returns></returns>
	public static short GetSeniorityDoctorMedicinePricePercent(int seniority)
	{
		int percentage = SeniorityToPercentage(seniority);
		return (short)(150 + 150 * percentage / 100);
	}

	/// <summary>
	/// 好感增加百分比 (大夫 - 看诊施药)
	/// </summary>
	/// <param name="seniority"></param>
	/// <returns></returns>
	public static short GetSeniorityDoctorFavorAddPercent(int seniority)
	{
		int percentage = SeniorityToPercentage(seniority);
		return (short)(150 + 150 * percentage / 100);
	}

	/// <summary>
	/// 道长二技能（驱邪法事）获得的威望系数
	/// </summary>
	/// <param name="seniority"></param>
	/// <returns></returns>
	public static short GetTaoistMonkSkill3AuthorityPara(int seniority)
	{
		int percentage = SeniorityToPercentage(seniority);
		return (short)(30 + percentage * 60 / 100);
	}

	/// <summary>
	/// 资历对应的定居点类型 (乞丐 - 托钵行乞)
	/// </summary>
	/// <param name="seniority"></param>
	/// <returns>GameData.Domains.Taiwu.Profession.ProfessionRelatedConstants.SettlementType</returns>
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

	/// <summary>
	/// 额外策略个数的公式，适用于研读和周天
	/// </summary>
	/// <param name="seniority"></param>
	/// <returns></returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int SeniorityToExtraReadingLoopingStrategyCount(int seniority)
	{
		return 1 + 2 * seniority / 3000000;
	}
}
