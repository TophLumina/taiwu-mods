using Config;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wudangpai.FistAndPalm;

public class WuDangChunYangQuan : CombatSkillEffectBase
{
	private const sbyte PrepareProgressPercent = 50;

	public WuDangChunYangQuan()
	{
	}

	public WuDangChunYangQuan(CombatSkillKey skillKey)
		: base(skillKey, 4106, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.RegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.UnRegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
	}

	private void OnPrepareSkillBegin(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId && GetCanInterruptSKill() >= 0)
		{
			DomainManager.Combat.ChangeSkillPrepareProgress(base.CombatChar, base.CombatChar.SkillPrepareTotalProgress * 50 / 100);
		}
	}

	private void OnAttackSkillAttackEnd(CombatContext context, sbyte hitType, bool hit, int index)
	{
		if (context.SkillKey != SkillKey || index != 3)
		{
			return;
		}
		short interruptSkillId = GetCanInterruptSKill();
		if (CombatCharPowerMatchAffectRequire() && interruptSkillId >= 0)
		{
			if (DomainManager.Combat.InterruptSkill(context, base.CurrEnemyChar))
			{
				base.CurrEnemyChar.SetAnimationToPlayOnce(base.CurrEnemyChar.GetBeHitAni(2), context);
				DomainManager.Combat.SetProperLoopAniAndParticle(context, base.CurrEnemyChar);
			}
			ShowSpecialEffectTips(0);
		}
	}

	private short GetCanInterruptSKill()
	{
		short skillId = base.CurrEnemyChar.GetPreparingSkillId();
		if (skillId < 0 || Config.CombatSkill.Instance[skillId].EquipType != 1)
		{
			return -1;
		}
		sbyte innerRatio = DomainManager.CombatSkill.GetElement_CombatSkills(new CombatSkillKey(base.CurrEnemyChar.GetId(), skillId)).GetCurrInnerRatio();
		return (short)((base.IsDirect ? (innerRatio > 50) : (innerRatio < 50)) ? skillId : (-1));
	}

	public static int CalcInterruptOdds(CombatSkillKey selfSkill, bool isDirect, CombatSkillKey enemySkill)
	{
		sbyte innerRatio = DomainManager.CombatSkill.GetElement_CombatSkills(enemySkill).GetCurrInnerRatio();
		return (short)((isDirect ? (innerRatio > 50) : (innerRatio < 50)) ? 100 : (-1));
	}
}
