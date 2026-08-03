using System.Collections.Generic;
using Config;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.CombatSkill;

/// <summary>
/// 功法显示数据。用于任务列表中显示的简化版信息
/// </summary>
[AutoGenerateSerializableGameData(NotForArchive = true)]
public class CombatSkillDisplayDataCharacterMenuListItem : ISerializableGameData, IFilterableCombatSkill
{
	/// <summary>
	/// 人物ID
	/// </summary>
	[SerializableGameDataField]
	public int CharId;

	/// <summary>
	/// 功法模板ID
	/// </summary>
	[SerializableGameDataField]
	public short TemplateId;

	/// <summary>
	/// 威力
	/// </summary>
	[SerializableGameDataField]
	public short Power;

	/// <summary>
	/// 已经突破成功
	/// </summary>
	[SerializableGameDataField]
	public bool BreakSuccess;

	/// <summary>
	/// 激活状态
	/// </summary>
	[SerializableGameDataField]
	public ushort ActivationState;

	/// <summary>
	/// 研读状态
	/// </summary>
	[SerializableGameDataField]
	public ushort ReadingState;

	/// <summary>
	/// 玄机品级
	/// </summary>
	[SerializableGameDataField]
	public List<sbyte> BreakBonusGrades;

	/// <summary>
	/// 是否被废除
	/// </summary>
	[SerializableGameDataField]
	public bool Revoked;

	/// <summary>
	///
	/// </summary>
	[SerializableGameDataField]
	public sbyte LuohanId;

	/// <summary>
	/// 是否精解
	/// </summary>
	[SerializableGameDataField]
	public bool Mastered;

	/// <summary>
	/// 生效状态
	/// </summary>
	[SerializableGameDataField]
	public bool CanAffect;

	/// <summary>
	/// 梦回合并导致突破盘冲突，功法无法生效
	/// </summary>
	[SerializableGameDataField]
	public bool Conflicting;

	/// <summary>
	/// 占用格数
	/// </summary>
	[SerializableGameDataField]
	public sbyte GridCount;

	/// <summary>
	/// 功法是否被收藏，太吾专属数据
	/// </summary>
	[SerializableGameDataField]
	public bool IsFavorite;

	/// <summary>
	/// 是否已装备到任何方案
	/// </summary>
	[SerializableGameDataField]
	public bool IsInAnyEquipPlans;

	/// <summary>
	/// 是否有峨眉派突破加成
	/// </summary>
	[SerializableGameDataField]
	public bool HasSectEmeiSkillBreakBonus;

	/// <summary>
	/// 最大可获得内力
	/// </summary>
	[SerializableGameDataField]
	public short MaxObtainableNeili;

	/// <summary>
	/// 已获得内力
	/// </summary>
	[SerializableGameDataField]
	public short ObtainedNeili;

	/// <summary>
	/// 周天五行起始类型
	/// </summary>
	[SerializableGameDataField]
	public sbyte FiveElementTransferTypeWhileLooping;

	/// <summary>
	/// 周天五行目标类型
	/// </summary>
	[SerializableGameDataField]
	public sbyte FiveElementDestTypeWhileLooping;

	/// <summary>
	/// 实战度
	/// </summary>
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

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public CombatSkillDisplayDataCharacterMenuListItem()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
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
		HasSectEmeiSkillBreakBonus = other.HasSectEmeiSkillBreakBonus;
		MaxObtainableNeili = other.MaxObtainableNeili;
		ObtainedNeili = other.ObtainedNeili;
		FiveElementTransferTypeWhileLooping = other.FiveElementTransferTypeWhileLooping;
		FiveElementDestTypeWhileLooping = other.FiveElementDestTypeWhileLooping;
		CombatSkillProficiency = other.CombatSkillProficiency;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
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
		int totalSize = 32;
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
