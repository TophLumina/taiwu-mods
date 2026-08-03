using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Emeipai.Finger;

public class GuangXiangZhi : CombatSkillEffectBase
{
	private const sbyte ChangeDistance = 40;

	private const sbyte DirectRequireDistance = 80;

	private const sbyte ReverseRequireDistance = 40;

	private OuterAndInnerInts _makedDamage;

	public GuangXiangZhi()
	{
	}

	public GuangXiangZhi(CombatSkillKey skillKey)
		: base(skillKey, 2204, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		_makedDamage.Outer = 0;
		_makedDamage.Inner = 0;
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 145, base.SkillTemplateId), EDataModifyType.Add);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 146, base.SkillTemplateId), EDataModifyType.Add);
		Events.RegisterHandler_AddDirectDamageValue(OnAddDirectDamageValue);
		Events.RegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_AddDirectDamageValue(OnAddDirectDamageValue);
		Events.UnRegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnAddDirectDamageValue(DataContext context, int attackerId, int defenderId, sbyte bodyPart, bool isInner, int damageValue, short combatSkillId)
	{
		if (attackerId == base.CharacterId && combatSkillId == base.SkillTemplateId)
		{
			if (isInner)
			{
				_makedDamage.Inner = damageValue;
			}
			else
			{
				_makedDamage.Outer = damageValue;
			}
		}
	}

	private void OnAttackSkillAttackEnd(CombatContext context, sbyte hitType, bool hit, int index)
	{
		if (index == 3 && !(context.SkillKey != SkillKey) && CombatCharPowerMatchAffectRequire())
		{
			CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly);
			DomainManager.Combat.ChangeDistance(context, enemyChar, base.IsDirect ? 40 : (-40), isForced: true);
			ShowSpecialEffectTips(0);
			DomainManager.Combat.SetDisplayPosition(context, !base.CombatChar.IsAlly, base.IsDirect ? int.MinValue : DomainManager.Combat.GetDisplayPosition(!base.CombatChar.IsAlly, DomainManager.Combat.GetCurrentDistance()));
			if (!base.IsDirect)
			{
				base.CombatChar.SetCurrentPosition(base.CombatChar.GetDisplayPosition(), context);
				enemyChar.SetCurrentPosition(enemyChar.GetDisplayPosition(), context);
			}
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			if (PowerMatchAffectRequire(power) && (_makedDamage.Outer > 0 || _makedDamage.Inner > 0) && (base.IsDirect ? (DomainManager.Combat.GetCurrentDistance() <= 80) : (DomainManager.Combat.GetCurrentDistance() >= 40)))
			{
				DomainManager.Combat.AddInjuryDamageValue(base.CombatChar, base.CurrEnemyChar, base.CombatChar.SkillAttackBodyPart, _makedDamage.Outer, _makedDamage.Inner, base.SkillTemplateId);
				ShowSpecialEffectTips(1);
			}
			_makedDamage.Outer = 0;
			_makedDamage.Inner = 0;
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != base.SkillTemplateId)
		{
			return 0;
		}
		if (dataKey.FieldId == 145 || dataKey.FieldId == 146)
		{
			return 10000;
		}
		return 0;
	}
}
