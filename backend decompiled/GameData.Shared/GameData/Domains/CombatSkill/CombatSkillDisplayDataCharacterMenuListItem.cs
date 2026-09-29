using System.Collections.Generic;
using Config;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.CombatSkill;

[AutoGenerateSerializableGameData(NotForArchive = true)]
public class CombatSkillDisplayDataCharacterMenuListItem : ISerializableGameData, IFilterableCombatSkill
{
	[SerializableGameDataField]
	public int CharId;

	[SerializableGameDataField]
	public short TemplateId;

	[SerializableGameDataField]
	public short Power;

	[SerializableGameDataField]
	public bool BreakSuccess;

	[SerializableGameDataField]
	public ushort ActivationState;

	[SerializableGameDataField]
	public ushort ReadingState;

	[SerializableGameDataField]
	public List<sbyte> BreakBonusGrades;

	[SerializableGameDataField]
	public bool Revoked;

	[SerializableGameDataField]
	public sbyte LuohanId;

	[SerializableGameDataField]
	public bool Mastered;

	[SerializableGameDataField]
	public bool CanAffect;

	[SerializableGameDataField]
	public bool Conflicting;

	[SerializableGameDataField]
	public sbyte GridCount;

	[SerializableGameDataField]
	public bool IsFavorite;

	[SerializableGameDataField]
	public bool IsInAnyEquipPlans;

	[SerializableGameDataField]
	public bool IsInCurrentEquipPlan;

	[SerializableGameDataField]
	public bool HasSectEmeiSkillBreakBonus;

	[SerializableGameDataField]
	public short MaxObtainableNeili;

	[SerializableGameDataField]
	public short ObtainedNeili;

	[SerializableGameDataField]
	public sbyte FiveElementTransferTypeWhileLooping;

	[SerializableGameDataField]
	public sbyte FiveElementDestTypeWhileLooping;

	[SerializableGameDataField]
	public int CombatSkillProficiency;

	short IFilterableCombatSkill.TemplateId => TemplateId;

	sbyte IFilterableCombatSkill.Type => SkillConfig.Type;

	sbyte IFilterableCombatSkill.SectId => SkillConfig.SectId;

	ushort IFilterableCombatSkill.ActivationState => ActivationState;

	bool IFilterableCombatSkill.IsInAnyEquipPlans => IsInAnyEquipPlans;

	bool IFilterableCombatSkill.HasSectEmeiSkillBreakBonus => HasSectEmeiSkillBreakBonus;

	short IFilterableCombatSkill.Power => Power;

	List<sbyte> IFilterableCombatSkill.BreakBonusGrades => BreakBonusGrades;

	ushort IFilterableCombatSkill.ReadingState => ReadingState;

	short IFilterableCombatSkill.MaxObtainableNeili => MaxObtainableNeili;

	short IFilterableCombatSkill.ObtainedNeili => ObtainedNeili;

	int IFilterableCombatSkill.CombatSkillProficiency => CombatSkillProficiency;

	sbyte IFilterableCombatSkill.FiveElementTransferTypeWhileLooping
	{
		get
		{
			return FiveElementTransferTypeWhileLooping;
		}
		set
		{
			FiveElementTransferTypeWhileLooping = value;
		}
	}

	sbyte IFilterableCombatSkill.FiveElementDestTypeWhileLooping
	{
		get
		{
			return FiveElementDestTypeWhileLooping;
		}
		set
		{
			FiveElementDestTypeWhileLooping = value;
		}
	}

	private CombatSkillItem SkillConfig => Config.CombatSkill.Instance[TemplateId];

	public CombatSkillDisplayDataCharacterMenuListItem()
	{
	}

	public CombatSkillDisplayDataCharacterMenuListItem(CombatSkillDisplayDataCharacterMenuListItem other)
	{
		CharId = other.CharId;
		TemplateId = other.TemplateId;
		Power = other.Power;
		BreakSuccess = other.BreakSuccess;
		ActivationState = other.ActivationState;
		ReadingState = other.ReadingState;
		BreakBonusGrades = ((other.BreakBonusGrades == null) ? null : new List<sbyte>(other.BreakBonusGrades));
		Revoked = other.Revoked;
		LuohanId = other.LuohanId;
		Mastered = other.Mastered;
		CanAffect = other.CanAffect;
		Conflicting = other.Conflicting;
		GridCount = other.GridCount;
		IsFavorite = other.IsFavorite;
		IsInAnyEquipPlans = other.IsInAnyEquipPlans;
		IsInCurrentEquipPlan = other.IsInCurrentEquipPlan;
		HasSectEmeiSkillBreakBonus = other.HasSectEmeiSkillBreakBonus;
		MaxObtainableNeili = other.MaxObtainableNeili;
		ObtainedNeili = other.ObtainedNeili;
		FiveElementTransferTypeWhileLooping = other.FiveElementTransferTypeWhileLooping;
		FiveElementDestTypeWhileLooping = other.FiveElementDestTypeWhileLooping;
		CombatSkillProficiency = other.CombatSkillProficiency;
	}

	public void Assign(CombatSkillDisplayDataCharacterMenuListItem other)
	{
		CharId = other.CharId;
		TemplateId = other.TemplateId;
		Power = other.Power;
		BreakSuccess = other.BreakSuccess;
		ActivationState = other.ActivationState;
		ReadingState = other.ReadingState;
		BreakBonusGrades = ((other.BreakBonusGrades == null) ? null : new List<sbyte>(other.BreakBonusGrades));
		Revoked = other.Revoked;
		LuohanId = other.LuohanId;
		Mastered = other.Mastered;
		CanAffect = other.CanAffect;
		Conflicting = other.Conflicting;
		GridCount = other.GridCount;
		IsFavorite = other.IsFavorite;
		IsInAnyEquipPlans = other.IsInAnyEquipPlans;
		IsInCurrentEquipPlan = other.IsInCurrentEquipPlan;
		HasSectEmeiSkillBreakBonus = other.HasSectEmeiSkillBreakBonus;
		MaxObtainableNeili = other.MaxObtainableNeili;
		ObtainedNeili = other.ObtainedNeili;
		FiveElementTransferTypeWhileLooping = other.FiveElementTransferTypeWhileLooping;
		FiveElementDestTypeWhileLooping = other.FiveElementDestTypeWhileLooping;
		CombatSkillProficiency = other.CombatSkillProficiency;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 33;
		totalSize = ((BreakBonusGrades == null) ? (totalSize + 2) : (totalSize + (2 + BreakBonusGrades.Count)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(int*)pCurrData = CharId;
		pCurrData += 4;
		*(short*)pCurrData = TemplateId;
		pCurrData += 2;
		*(short*)pCurrData = Power;
		pCurrData += 2;
		*pCurrData = (BreakSuccess ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(ushort*)pCurrData = ActivationState;
		pCurrData += 2;
		*(ushort*)pCurrData = ReadingState;
		pCurrData += 2;
		if (BreakBonusGrades != null)
		{
			int elementsCount = BreakBonusGrades.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				*pCurrData = (byte)BreakBonusGrades[i];
				pCurrData++;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (Revoked ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (byte)LuohanId;
		pCurrData++;
		*pCurrData = (Mastered ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (CanAffect ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (Conflicting ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (byte)GridCount;
		pCurrData++;
		*pCurrData = (IsFavorite ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (IsInAnyEquipPlans ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (IsInCurrentEquipPlan ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (HasSectEmeiSkillBreakBonus ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(short*)pCurrData = MaxObtainableNeili;
		pCurrData += 2;
		*(short*)pCurrData = ObtainedNeili;
		pCurrData += 2;
		*pCurrData = (byte)FiveElementTransferTypeWhileLooping;
		pCurrData++;
		*pCurrData = (byte)FiveElementDestTypeWhileLooping;
		pCurrData++;
		*(int*)pCurrData = CombatSkillProficiency;
		pCurrData += 4;
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
		CharId = *(int*)pCurrData;
		pCurrData += 4;
		TemplateId = *(short*)pCurrData;
		pCurrData += 2;
		Power = *(short*)pCurrData;
		pCurrData += 2;
		BreakSuccess = *pCurrData != 0;
		pCurrData++;
		ActivationState = *(ushort*)pCurrData;
		pCurrData += 2;
		ReadingState = *(ushort*)pCurrData;
		pCurrData += 2;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (BreakBonusGrades == null)
			{
				BreakBonusGrades = new List<sbyte>();
			}
			else
			{
				BreakBonusGrades.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				sbyte element = (sbyte)(*pCurrData);
				pCurrData++;
				BreakBonusGrades.Add(element);
			}
		}
		else
		{
			BreakBonusGrades?.Clear();
		}
		Revoked = *pCurrData != 0;
		pCurrData++;
		LuohanId = (sbyte)(*pCurrData);
		pCurrData++;
		Mastered = *pCurrData != 0;
		pCurrData++;
		CanAffect = *pCurrData != 0;
		pCurrData++;
		Conflicting = *pCurrData != 0;
		pCurrData++;
		GridCount = (sbyte)(*pCurrData);
		pCurrData++;
		IsFavorite = *pCurrData != 0;
		pCurrData++;
		IsInAnyEquipPlans = *pCurrData != 0;
		pCurrData++;
		IsInCurrentEquipPlan = *pCurrData != 0;
		pCurrData++;
		HasSectEmeiSkillBreakBonus = *pCurrData != 0;
		pCurrData++;
		MaxObtainableNeili = *(short*)pCurrData;
		pCurrData += 2;
		ObtainedNeili = *(short*)pCurrData;
		pCurrData += 2;
		FiveElementTransferTypeWhileLooping = (sbyte)(*pCurrData);
		pCurrData++;
		FiveElementDestTypeWhileLooping = (sbyte)(*pCurrData);
		pCurrData++;
		CombatSkillProficiency = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
