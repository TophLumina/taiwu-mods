using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Kongsangpai.Finger;

public class WuHuanShou : CombatSkillEffectBase
{
	private CombatCharacter _affectEnemy;

	public WuHuanShou()
	{
	}

	public WuHuanShou(CombatSkillKey skillKey)
		: base(skillKey, 10205, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_NormalAttackCalcHitEnd(OnNormalAttackCalcHitEnd);
		Events.RegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.RegisterHandler_ChangeBossPhase(OnChangeBossPhase);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_NormalAttackCalcHitEnd(OnNormalAttackCalcHitEnd);
		Events.UnRegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.UnRegisterHandler_ChangeBossPhase(OnChangeBossPhase);
	}

	private void OnNormalAttackCalcHitEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender, int pursueIndex, bool hit, bool isFightback, bool isMind)
	{
		if (attacker.IsAlly == base.CombatChar.IsAlly && defender == _affectEnemy)
		{
			RemoveEffect(context);
		}
	}

	private void OnAttackSkillAttackEnd(CombatContext context, sbyte hitType, bool hit, int index)
	{
		if (context.Attacker.IsAlly == base.CombatChar.IsAlly && context.Defender == _affectEnemy)
		{
			RemoveEffect(context);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (SkillKey.IsMatch(charId, skillId) && PowerMatchAffectRequire(power) && base.CombatChar.SkillAttackBodyPart == 2)
		{
			AddEffect(context);
		}
	}

	private void OnChangeBossPhase(DataContext context)
	{
		RemoveEffect(context);
	}

	private void AddEffect(DataContext context)
	{
		if (_affectEnemy == null)
		{
			_affectEnemy = base.CurrEnemyChar;
			_affectEnemy.ForbidNormalAttackEffectCount++;
			if (base.IsDirect)
			{
				_affectEnemy.CanCastSkillCostStance = false;
			}
			else
			{
				_affectEnemy.CanCastSkillCostBreath = false;
			}
			_affectEnemy.AiController.ClearMemories();
			DomainManager.Combat.UpdateCanChangeTrick(context, _affectEnemy);
			DomainManager.Combat.UpdateSkillCanUse(context, _affectEnemy);
			ShowSpecialEffectTips(0);
		}
	}

	private void RemoveEffect(DataContext context)
	{
		if (_affectEnemy != null)
		{
			_affectEnemy.ForbidNormalAttackEffectCount--;
			if (base.IsDirect)
			{
				_affectEnemy.CanCastSkillCostStance = true;
			}
			else
			{
				_affectEnemy.CanCastSkillCostBreath = true;
			}
			DomainManager.Combat.UpdateCanChangeTrick(context, _affectEnemy);
			DomainManager.Combat.UpdateSkillCanUse(context, _affectEnemy);
			_affectEnemy = null;
		}
	}
}
