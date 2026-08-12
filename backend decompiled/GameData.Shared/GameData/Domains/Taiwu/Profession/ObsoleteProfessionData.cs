using System;
using Config;
using GameData.Domains.Taiwu.Profession.SkillsData;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Taiwu.Profession;

/// <summary>
/// 职业 (志向) 相关数据
/// </summary>
[Obsolete]
[SerializableGameData(NotForDisplayModule = true)]
public class ObsoleteProfessionData : ISerializableGameData
{
	/// <summary>
	/// 职业的模板 ID
	/// </summary>
	[SerializableGameDataField]
	public int TemplateId;

	/// <summary>
	/// 职业的资历
	/// </summary>
	[SerializableGameDataField]
	public int Seniority;

	/// <summary>
	/// 转职冷却结束日期
	/// </summary>
	[SerializableGameDataField]
	public int ProfessionOffCooldownDate;

	/// <summary>
	/// 技能冷却结束时间, 小于当前时间表示技能不在冷却
	/// </summary>
	[SerializableGameDataField]
	public int[] SkillOffCooldownDates;

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

	public ObsoleteProfessionData(int templateId)
	{
		TemplateId = templateId;
		int skillCount = GetSkillCount();
		SkillOffCooldownDates = new int[skillCount];
		HadBeenUnlocked = new bool[skillCount];
		SkillsData = CreateExtraData(TemplateId);
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
	/// 指定技能是否已解锁
	/// </summary>
	/// <param name="skillIndex"></param>
	/// <returns></returns>
	public bool IsSkillUnlocked(int skillIndex)
	{
		return Seniority >= ProfessionRelatedConstants.SkillUnlockSeniority[skillIndex];
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

	private static IProfessionSkillsData CreateExtraData(int templateId)
	{
		return templateId switch
		{
			1 => new ObsoleteHunterSkillsData(), 
			5 => new ObsoleteTaoistMonkSkillsData(), 
			6 => new ObsoleteBuddhistMonkSkillsData(), 
			7 => new WineTasterSkillsData(), 
			9 => new ObsoleteBeggarSkillsData(), 
			12 => new ObsoleteTravelingBuddhistMonkSkillsData(), 
			17 => new ObsoleteDukeSkillsData(), 
			8 => new ObsoleteAristocratSkillsData(), 
			14 => new ObsoleteTravelingTaoistMonkSkillsData(), 
			16 => new TeaTasterSkillsData(), 
			_ => null, 
		};
	}

	public ObsoleteProfessionData()
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
		int totalSize = 12;
		totalSize = ((SkillOffCooldownDates == null) ? (totalSize + 2) : (totalSize + (2 + 4 * SkillOffCooldownDates.Length)));
		totalSize = ((HadBeenUnlocked == null) ? (totalSize + 2) : (totalSize + (2 + HadBeenUnlocked.Length)));
		totalSize = ((SkillsData == null) ? (totalSize + 2) : (totalSize + (2 + SkillsData.GetSerializedSize())));
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
		*(int*)pCurrData = TemplateId;
		pCurrData += 4;
		*(int*)pCurrData = Seniority;
		pCurrData += 4;
		*(int*)pCurrData = ProfessionOffCooldownDate;
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
		TemplateId = *(int*)pCurrData;
		pCurrData += 4;
		Seniority = *(int*)pCurrData;
		pCurrData += 4;
		ProfessionOffCooldownDate = *(int*)pCurrData;
		pCurrData += 4;
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
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			if (SkillsData == null)
			{
				SkillsData = CreateExtraData(TemplateId);
			}
			pCurrData += SkillsData.Deserialize(pCurrData);
		}
		else
		{
			SkillsData = CreateExtraData(TemplateId);
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
