using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Shixiangmen.Blade;

public class JinNiZhenMoDao : CombatSkillEffectBase
{
	public JinNiZhenMoDao()
	{
	}

	public JinNiZhenMoDao(CombatSkillKey skillKey)
		: base(skillKey, 6206, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.RegisterHandler_SkillEffectChange(OnSkillEffectChange);
	}

	public override void OnDisable(DataContext context)
	{
		SetDirectionCanCast(context, base.CombatChar, !base.IsDirect, canCast: true);
		Events.UnRegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.UnRegisterHandler_SkillEffectChange(OnSkillEffectChange);
	}

	private void OnPrepareSkillBegin(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (charId != base.CharacterId)
		{
			return;
		}
		sbyte affectDirection = (sbyte)(base.IsDirect ? 1 : 0);
		if (!IsSrcSkillPerformed)
		{
			if (skillId == base.SkillTemplateId)
			{
				CombatCharacter enemyChar0 = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly);
				CombatCharacter enemyChar1 = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly, tryGetCoverCharacter: true);
				if (enemyChar0.GetPreparingSkillId() >= 0 && DomainManager.CombatSkill.GetSkillDirection(enemyChar0.GetId(), enemyChar0.GetPreparingSkillId()) == affectDirection && DomainManager.Combat.InterruptSkill(context, enemyChar0))
				{
					enemyChar0.SetAnimationToPlayOnce(enemyChar0.GetBeHitAni(2), context);
					DomainManager.Combat.SetProperLoopAniAndParticle(context, enemyChar0);
				}
				ClearAffectingSkill(context, enemyChar0, affectDirection);
				if (enemyChar1 != enemyChar0)
				{
					ClearAffectingSkill(context, enemyChar1, affectDirection);
				}
				SetDirectionCanCast(context, !isAlly, !base.IsDirect, canCast: false);
				ShowSpecialEffectTips(0);
			}
		}
		else if ((int)DomainManager.CombatSkill.GetSkillDirection(charId, skillId) == ((!base.IsDirect) ? 1 : 0))
		{
			ReduceEffectCount();
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			if (!IsSrcSkillPerformed)
			{
				IsSrcSkillPerformed = true;
				SetDirectionCanCast(context, !isAlly, !base.IsDirect, canCast: true);
				SetDirectionCanCast(context, base.CombatChar, !base.IsDirect, canCast: false);
				AddMaxEffectCount();
			}
			else
			{
				RemoveSelf(context);
			}
		}
	}

	private void OnSkillEffectChange(DataContext context, int charId, SkillEffectKey key, short oldCount, short newCount, bool removed)
	{
		if (removed && IsSrcSkillPerformed && charId == base.CharacterId && key.SkillId == base.SkillTemplateId && key.IsDirect == base.IsDirect)
		{
			RemoveSelf(context);
		}
	}

	private void ClearAffectingSkill(DataContext context, CombatCharacter combatChar, sbyte direction)
	{
		short defendSkillId = combatChar.GetAffectingDefendSkillId();
		short moveSkillId = combatChar.GetAffectingMoveSkillId();
		if (defendSkillId >= 0 && DomainManager.CombatSkill.GetSkillDirection(combatChar.GetId(), defendSkillId) == direction)
		{
			DomainManager.Combat.ClearAffectingDefenseSkill(context, combatChar);
		}
		if (moveSkillId >= 0 && DomainManager.CombatSkill.GetSkillDirection(combatChar.GetId(), moveSkillId) == direction)
		{
			ClearAffectingAgileSkill(context, combatChar);
		}
	}

	private void SetDirectionCanCast(DataContext context, bool isAlly, bool isDirect, bool canCast)
	{
		int[] charList = DomainManager.Combat.GetCharacterList(isAlly);
		for (int i = 0; i < charList.Length; i++)
		{
			if (charList[i] >= 0)
			{
				SetDirectionCanCast(context, DomainManager.Combat.GetElement_CombatCharacterDict(charList[i]), isDirect, canCast);
			}
		}
	}

	private void SetDirectionCanCast(DataContext context, CombatCharacter combatChar, bool isDirect, bool canCast)
	{
		if (isDirect)
		{
			combatChar.CanCastDirectSkill = canCast;
		}
		else
		{
			combatChar.CanCastReverseSkill = canCast;
		}
		DomainManager.Combat.UpdateSkillCanUse(context, combatChar);
		DomainManager.Combat.UpdateTeammateCommandUsable(context, combatChar, ETeammateCommandImplement.Defend);
	}

	public static int CalcInterruptOdds(CombatSkillKey selfSkill, bool isDirect, CombatSkillKey enemySkill)
	{
		sbyte direction = DomainManager.CombatSkill.GetSkillDirection(enemySkill.CharId, enemySkill.SkillTemplateId);
		return (direction == (isDirect ? 1 : 0)) ? 100 : 0;
	}
}
