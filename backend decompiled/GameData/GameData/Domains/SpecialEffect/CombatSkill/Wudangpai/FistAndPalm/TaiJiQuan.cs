using System;
using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wudangpai.FistAndPalm;

public class TaiJiQuan : CombatSkillEffectBase
{
	private int _leveragingValue;

	private bool _leveragingBySkill;

	private static CValuePercent HitFactor => 100;

	private static CValuePercent AvoidFactor => 300;

	public TaiJiQuan()
	{
	}

	public TaiJiQuan(CombatSkillKey skillKey)
		: base(skillKey, 4108, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		CreateAffectedData(209, EDataModifyType.Custom, base.SkillTemplateId);
		CreateAffectedData(114, EDataModifyType.Custom, -1);
		CreateAffectedData(253, EDataModifyType.Custom, -1);
		Events.RegisterHandler_CombatBegin(OnCombatBegin);
		Events.RegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
		Events.RegisterHandler_CalcLeveragingValue(OnCalcLeveragingValue);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CombatBegin(OnCombatBegin);
		Events.UnRegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
		Events.UnRegisterHandler_CalcLeveragingValue(OnCalcLeveragingValue);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnCombatBegin(DataContext context)
	{
		AddMaxEffectCount();
	}

	private void OnAttackSkillAttackEnd(CombatContext context, sbyte hitType, bool hit, int index)
	{
		OnCalcLeveragingValue(context, hitType, hit, index);
		if (!(context.SkillKey != SkillKey) && !base.IsDirect && index >= 3 && _leveragingValue > 0)
		{
			CombatCharacter enemyChar = base.CurrEnemyChar;
			CValuePercent innerRatio = base.SkillInstance.GetCurrInnerRatio();
			int innerFatalDamageValue = _leveragingValue * innerRatio;
			int outerFatalDamageValue = _leveragingValue - innerFatalDamageValue;
			_leveragingValue = 0;
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 253);
			enemyChar.AddFatalDamage(context, innerFatalDamageValue, 1, -1, base.SkillTemplateId);
			enemyChar.AddFatalDamage(context, outerFatalDamageValue, 0, -1, base.SkillTemplateId);
			ShowSpecialEffectTips(1);
		}
	}

	private void OnCalcLeveragingValue(CombatContext context, sbyte hitType, bool hit, int index)
	{
		bool flag = ((hitType < 0 || hitType == 3) ? true : false);
		if (flag || base.EffectCount <= 0)
		{
			return;
		}
		sbyte bodyPart = context.BodyPart;
		flag = ((bodyPart < 0 || bodyPart >= 7) ? true : false);
		if (flag || (base.IsDirect ? context.DefenderId : context.AttackerId) != base.CharacterId)
		{
			return;
		}
		if (!context.IsNormalAttack && index == 3)
		{
			if (_leveragingBySkill)
			{
				_leveragingBySkill = false;
				ReduceEffectCount();
			}
			return;
		}
		int power = (context.IsNormalAttack ? 100 : context.Skill.GetHitDistribution()[hitType]);
		OuterAndInnerInts mixedDamage = CombatContext.Create(context.Attacker, context.Attacker, context.BodyPart, context.SkillTemplateId).CalcMixedDamage(hitType, power);
		int addValue = (mixedDamage.Outer + mixedDamage.Inner) * (hit ? HitFactor : AvoidFactor);
		addValue *= (CValuePercentBonus)base.SkillInstance.GetPower();
		_leveragingValue += addValue;
		DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 253);
		ShowSpecialEffectTips(0);
		if (context.IsNormalAttack)
		{
			ReduceEffectCount();
		}
		else
		{
			_leveragingBySkill = true;
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool _)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			DomainManager.Combat.RemoveSkillEffect(context, base.CombatChar, base.EffectKey);
			ShowSpecialEffectTips(2);
			base.IsDirect = !base.IsDirect;
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 209);
			AddMaxEffectCount();
		}
	}

	public override int GetModifiedValue(AffectedDataKey dataKey, int dataValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != base.SkillTemplateId)
		{
			return dataValue;
		}
		if (dataKey.FieldId == 209)
		{
			return (!base.IsDirect) ? 1 : 0;
		}
		return dataValue;
	}

	public override long GetModifiedValue(AffectedDataKey dataKey, long dataValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId < 0)
		{
			return dataValue;
		}
		if (dataKey.FieldId == 114 && dataKey.CustomParam0 == 1 && base.IsDirect && base.CombatChar.BeCalcInjuryInnerRatio >= 0)
		{
			bool isInner = dataKey.CustomParam1 == 1;
			int innerRatio = base.CombatChar.BeCalcInjuryInnerRatio;
			CValuePercent leveragingValueRatio = (isInner ? innerRatio : (100 - innerRatio));
			int defendValue = (int)Math.Min(_leveragingValue * leveragingValueRatio, dataValue);
			_leveragingValue -= defendValue;
			DomainManager.SpecialEffect.InvalidateCache(base.CombatChar.GetDataContext(), base.CharacterId, 253);
			ShowSpecialEffectTips(1);
			return dataValue - defendValue;
		}
		return dataValue;
	}

	public override List<CombatSkillEffectData> GetModifiedValue(AffectedDataKey dataKey, List<CombatSkillEffectData> dataValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != base.SkillTemplateId)
		{
			return dataValue;
		}
		dataValue.Add(new CombatSkillEffectData(ECombatSkillEffectType.TaiJiQuanLeveragingValue, _leveragingValue));
		return dataValue;
	}
}
