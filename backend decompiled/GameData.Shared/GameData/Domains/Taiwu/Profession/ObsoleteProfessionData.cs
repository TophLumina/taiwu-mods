using System;
using Config;
using GameData.Domains.Taiwu.Profession.SkillsData;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Taiwu.Profession;

[Obsolete]
[SerializableGameData(NotForDisplayModule = true)]
public class ObsoleteProfessionData : ISerializableGameData
{
	[SerializableGameDataField]
	public int TemplateId;

	[SerializableGameDataField]
	public int Seniority;

	[SerializableGameDataField]
	public int ProfessionOffCooldownDate;

	[SerializableGameDataField]
	public int[] SkillOffCooldownDates;

	[SerializableGameDataField]
	public bool[] HadBeenUnlocked;

	[SerializableGameDataField]
	public IProfessionSkillsData SkillsData;

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

	public bool IsSkillUnlocked(int skillIndex)
	{
		return Seniority >= ProfessionRelatedConstants.SkillUnlockSeniority[skillIndex];
	}

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

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

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
