using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.Whip;

public class TianSheSuo : CombatSkillEffectBase
{
	private const sbyte AddDamagePercent = 15;

	public TianSheSuo()
	{
	}

	public TianSheSuo(CombatSkillKey skillKey)
		: base(skillKey, 12408, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		DomainManager.Combat.AddSkillEffect(context, base.CombatChar, new SkillEffectKey(base.SkillTemplateId, base.IsDirect), 0, base.MaxEffectCount, autoRemoveOnNoCount: false);
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 69, base.SkillTemplateId), EDataModifyType.AddPercent);
		Events.RegisterHandler_AddDirectInjury(OnAddDirectInjury);
		Events.RegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_AddDirectInjury(OnAddDirectInjury);
		Events.UnRegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
	}

	private void OnAddDirectInjury(DataContext context, int attackerId, int defenderId, bool isAlly, sbyte bodyPart, sbyte outerMarkCount, sbyte innerMarkCount, short combatSkillId)
	{
		if (attackerId == base.CharacterId && combatSkillId != base.SkillTemplateId && (base.IsDirect ? outerMarkCount : innerMarkCount) > 0 && base.EffectCount < base.MaxEffectCount)
		{
			DomainManager.Combat.ChangeSkillEffectCount(DomainManager.Combat.Context, base.CombatChar, new SkillEffectKey(base.SkillTemplateId, base.IsDirect), 1);
			ShowSpecialEffectTips(0);
		}
	}

	private void OnAttackSkillAttackEnd(CombatContext context, sbyte hitType, bool hit, int index)
	{
		if (index == 3 && base.EffectCount > 0 && !(context.SkillKey != SkillKey) && CombatCharPowerMatchAffectRequire())
		{
			ReduceEffectCount();
			ShowSpecialEffectTips(1);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return 0;
		}
		if (dataKey.FieldId == 69 && dataKey.CombatSkillId == base.SkillTemplateId && base.EffectCount > 0 && dataKey.CustomParam0 == ((!base.IsDirect) ? 1 : 0) && base.CombatChar.GetAttackSkillPower() >= 100)
		{
			return 15 * base.EffectCount;
		}
		return 0;
	}
}
