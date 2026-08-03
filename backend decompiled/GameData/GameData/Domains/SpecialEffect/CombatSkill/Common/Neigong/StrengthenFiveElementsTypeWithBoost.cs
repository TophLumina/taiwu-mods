using System;
using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Implement;

namespace GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

public abstract class StrengthenFiveElementsTypeWithBoost : StrengthenFiveElementsType
{
	private const int AddPrepareProgressPercent = 50;

	private const int AddPrepareProgressMaxPercent = 75;

	private const sbyte AddPower = 20;

	private short _affectingSkillId = -1;

	protected override int DirectAddPower => 10;

	protected override int ReverseReduceCostPercent => -20;

	protected abstract byte CostNeiliAllocationType { get; }

	protected StrengthenFiveElementsTypeWithBoost()
	{
	}

	protected StrengthenFiveElementsTypeWithBoost(CombatSkillKey skillKey, int type)
		: base(skillKey, type)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(235, EDataModifyType.Custom, -1);
		Events.RegisterHandler_CombatCostNeiliConfirm(OnCombatCostNeiliConfirm);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
		if (!base.IsDirect)
		{
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, 199, -1), EDataModifyType.Add);
		}
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CombatCostNeiliConfirm(OnCombatCostNeiliConfirm);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		base.OnDisable(context);
	}

	private void OnCombatCostNeiliConfirm(DataContext context, int charId, short skillId, short effectId)
	{
		if (charId != base.CharacterId || effectId != base.EffectId || _affectingSkillId >= 0 || skillId < 0 || base.CombatChar.GetPreparingSkillId() != skillId || !FiveElementsEquals(skillId, FiveElementsType))
		{
			return;
		}
		CastBoostEffectDisplayData costNeiliEffect = SkillKey.GetPureCostNeiliEffectData(CostNeiliAllocationType, skillId, applyEffect: false);
		if (costNeiliEffect.NeiliAllocationType <= 3)
		{
			int requireValue = base.CombatChar.ApplySpecialEffectToNeiliAllocation(costNeiliEffect.NeiliAllocationType, costNeiliEffect.NeiliAllocationValue);
			if (base.CombatChar.GetNeiliAllocation()[costNeiliEffect.NeiliAllocationType] >= -requireValue)
			{
				ShowSpecialEffectTips(0);
				_affectingSkillId = skillId;
				base.CombatChar.ChangeNeiliAllocation(context, costNeiliEffect.NeiliAllocationType, costNeiliEffect.NeiliAllocationValue);
				ApplyEffect(context);
			}
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == _affectingSkillId)
		{
			_affectingSkillId = -1;
			RevertEffect(context);
		}
	}

	private void ApplyEffect(DataContext context)
	{
		if (base.IsDirect)
		{
			int addProgress = base.CombatChar.SkillPrepareTotalProgress * 50 / 100;
			int maxProgress = base.CombatChar.SkillPrepareTotalProgress * 75 / 100;
			base.CombatChar.SkillPrepareCurrProgress = Math.Max(base.CombatChar.SkillPrepareCurrProgress, Math.Min(base.CombatChar.SkillPrepareCurrProgress + addProgress, maxProgress));
			base.CombatChar.SetSkillPreparePercent((byte)(base.CombatChar.SkillPrepareCurrProgress * 100 / base.CombatChar.SkillPrepareTotalProgress), context);
		}
		else
		{
			InvalidateCache(context, 199);
		}
	}

	private void RevertEffect(DataContext context)
	{
		if (!base.IsDirect)
		{
			InvalidateCache(context, 199);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		int value = base.GetModifyValue(dataKey, currModifyValue);
		if (dataKey.CharId == base.CharacterId && dataKey.CombatSkillId == _affectingSkillId && dataKey.FieldId == 199 && !base.IsDirect)
		{
			value += 20;
		}
		return value;
	}

	public override List<CastBoostEffectDisplayData> GetModifiedValue(AffectedDataKey dataKey, List<CastBoostEffectDisplayData> dataValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return dataValue;
		}
		if (dataKey.FieldId == 235 && dataKey.CombatSkillId >= 0 && FiveElementsEquals(dataKey, FiveElementsType) && _affectingSkillId < 0)
		{
			dataValue.Add(SkillKey.GetPureCostNeiliEffectData(CostNeiliAllocationType, dataKey.CombatSkillId, applyEffect: true));
		}
		return dataValue;
	}
}
