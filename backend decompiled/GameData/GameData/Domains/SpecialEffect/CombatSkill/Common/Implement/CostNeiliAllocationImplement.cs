using System.Collections.Generic;
using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Common.Implement;

public class CostNeiliAllocationImplement : ISpecialEffectImplement, ISpecialEffectModifier
{
	public enum EType
	{
		AddRange,
		DamageCannotReduce
	}

	private const int AddRangeValue = 20;

	private readonly EType _directType;

	private readonly EType _reverseType;

	private readonly sbyte _fiveElementsType;

	private readonly byte _costType;

	private short _costNeiliEffectingSkillId = -1;

	private EType Type => EffectBase.IsDirect ? _directType : _reverseType;

	private CombatSkillKey EffectingSkillKey => new CombatSkillKey(EffectBase.CharacterId, _costNeiliEffectingSkillId);

	public CombatSkillEffectBase EffectBase { get; set; }

	public CostNeiliAllocationImplement(EType directType, EType reverseType, sbyte fiveElementsType, byte costType)
	{
		_directType = directType;
		_reverseType = reverseType;
		_fiveElementsType = fiveElementsType;
		_costType = costType;
	}

	public void OnEnable(DataContext context)
	{
		CombatSkillEffectBase effectBase = EffectBase;
		if (effectBase.AffectDatas == null)
		{
			effectBase.AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		}
		EffectBase.AffectDatas.Add(new AffectedDataKey(EffectBase.CharacterId, 235, -1), EDataModifyType.Custom);
		Events.RegisterHandler_CombatCostNeiliConfirm(CombatCostNeiliConfirm);
		Events.RegisterHandler_CastSkillEnd(CastSkillEnd);
	}

	public void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CombatCostNeiliConfirm(CombatCostNeiliConfirm);
		Events.UnRegisterHandler_CastSkillEnd(CastSkillEnd);
	}

	public int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.IsNormalAttack || dataKey.SkillKey != EffectingSkillKey)
		{
			return 0;
		}
		ushort fieldId = dataKey.FieldId;
		bool flag = (uint)(fieldId - 145) <= 1u;
		if (flag && Type == EType.AddRange)
		{
			return 20;
		}
		return 0;
	}

	public bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.IsNormalAttack || dataKey.SkillKey != EffectingSkillKey)
		{
			return dataValue;
		}
		if (dataKey.FieldId == 325 && Type == EType.DamageCannotReduce && dataKey.CustomParam2 == 1)
		{
			return false;
		}
		return dataValue;
	}

	public List<CastBoostEffectDisplayData> GetModifiedValue(AffectedDataKey dataKey, List<CastBoostEffectDisplayData> dataValue)
	{
		if (dataKey.CharId != EffectBase.CharacterId)
		{
			return dataValue;
		}
		if (dataKey.FieldId == 235 && dataKey.CombatSkillId >= 0 && EffectBase.FiveElementsEquals(dataKey, _fiveElementsType) && _costNeiliEffectingSkillId < 0 && CheckAttackIfNeed(dataKey.CombatSkillId))
		{
			dataValue.Add(EffectBase.SkillKey.GetPureCostNeiliEffectData(_costType, dataKey.CombatSkillId, applyEffect: true));
		}
		return dataValue;
	}

	public void AutoAffectedData()
	{
		if (ContainsType(EType.DamageCannotReduce))
		{
			EffectBase.CreateAffectedData(325, EDataModifyType.Custom, -1);
		}
		if (ContainsType(EType.AddRange))
		{
			EffectBase.CreateAffectedData(145, EDataModifyType.Add, -1);
			EffectBase.CreateAffectedData(146, EDataModifyType.Add, -1);
		}
	}

	private bool ContainsType(EType type)
	{
		return _directType == type || _reverseType == type;
	}

	private bool CheckAttackIfNeed(short skillId)
	{
		EType type = Type;
		if ((uint)type <= 1u)
		{
			return Config.CombatSkill.Instance[skillId].EquipType == 1;
		}
		return true;
	}

	private unsafe void CombatCostNeiliConfirm(DataContext context, int charId, short skillId, short effectId)
	{
		if (charId != EffectBase.CharacterId || effectId != EffectBase.EffectId || _costNeiliEffectingSkillId >= 0 || skillId < 0 || EffectBase.CombatChar.GetPreparingSkillId() != skillId || !EffectBase.FiveElementsEquals(skillId, _fiveElementsType))
		{
			return;
		}
		CastBoostEffectDisplayData costNeiliEffect = EffectBase.SkillKey.GetPureCostNeiliEffectData(_costType, skillId, applyEffect: false);
		if (costNeiliEffect.NeiliAllocationType <= 3)
		{
			NeiliAllocation neiliAllocation = EffectBase.CombatChar.GetNeiliAllocation();
			if (neiliAllocation.Items[(int)costNeiliEffect.NeiliAllocationType] >= -costNeiliEffect.NeiliAllocationValue)
			{
				DomainManager.Combat.ShowSpecialEffectTips(EffectBase.CharacterId, EffectBase.EffectId, 0);
				_costNeiliEffectingSkillId = skillId;
				EffectBase.CombatChar.ChangeNeiliAllocation(context, costNeiliEffect.NeiliAllocationType, costNeiliEffect.NeiliAllocationValue);
				ApplyEffect(context);
			}
		}
	}

	private void CastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == EffectBase.CharacterId && skillId == _costNeiliEffectingSkillId)
		{
			_costNeiliEffectingSkillId = -1;
			RevertEffect(context);
		}
	}

	private void ApplyEffect(DataContext context)
	{
		switch (Type)
		{
		case EType.AddRange:
			DomainManager.SpecialEffect.InvalidateCache(context, EffectBase.CharacterId, 145);
			DomainManager.SpecialEffect.InvalidateCache(context, EffectBase.CharacterId, 146);
			break;
		case EType.DamageCannotReduce:
			DomainManager.SpecialEffect.InvalidateCache(context, EffectBase.CharacterId, 325);
			break;
		default:
			PredefinedLog.Show(7, EffectBase.EffectId, $"{Type} not exist cost neili allocation effect to apply.");
			break;
		}
	}

	private void RevertEffect(DataContext context)
	{
		switch (Type)
		{
		case EType.AddRange:
			DomainManager.SpecialEffect.InvalidateCache(context, EffectBase.CharacterId, 145);
			DomainManager.SpecialEffect.InvalidateCache(context, EffectBase.CharacterId, 146);
			break;
		case EType.DamageCannotReduce:
			DomainManager.SpecialEffect.InvalidateCache(context, EffectBase.CharacterId, 325);
			break;
		default:
			PredefinedLog.Show(7, EffectBase.EffectId, $"{Type} not exist cost neili allocation effect to revert.");
			break;
		}
	}
}
