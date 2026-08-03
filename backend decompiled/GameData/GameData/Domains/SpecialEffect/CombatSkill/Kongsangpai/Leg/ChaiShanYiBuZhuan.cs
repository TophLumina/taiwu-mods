using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Kongsangpai.Leg;

public class ChaiShanYiBuZhuan : CombatSkillEffectBase
{
	private const sbyte PrepareProgressPercent = 50;

	private const sbyte ChangeDistance = 20;

	private bool _quickCastAffected;

	public ChaiShanYiBuZhuan()
	{
	}

	public ChaiShanYiBuZhuan(CombatSkillKey skillKey)
		: base(skillKey, 10301, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		_quickCastAffected = false;
		Events.RegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.RegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.UnRegisterHandler_AttackSkillAttackEnd(OnAttackSkillAttackEnd);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnPrepareSkillBegin(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId && !_quickCastAffected && DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly).GetPreparingSkillId() >= 0)
		{
			_quickCastAffected = true;
			DomainManager.Combat.ChangeSkillPrepareProgress(base.CombatChar, base.CombatChar.SkillPrepareTotalProgress * 50 / 100);
			ShowSpecialEffectTips(0);
		}
	}

	private void OnAttackSkillAttackEnd(CombatContext context, sbyte hitType, bool hit, int index)
	{
		if (index == 3 && !(context.SkillKey != SkillKey) && CombatCharPowerMatchAffectRequire())
		{
			DomainManager.Combat.ChangeDistance(context, base.CombatChar, base.IsDirect ? (-20) : 20);
			ShowSpecialEffectTips(1);
			DomainManager.Combat.SetDisplayPosition(context, base.CombatChar.IsAlly, base.IsDirect ? int.MinValue : DomainManager.Combat.GetDisplayPosition(base.CombatChar.IsAlly, DomainManager.Combat.GetCurrentDistance()));
			if (!base.IsDirect)
			{
				CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly);
				base.CombatChar.SetCurrentPosition(base.CombatChar.GetDisplayPosition(), context);
				enemyChar.SetCurrentPosition(enemyChar.GetDisplayPosition(), context);
			}
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (_quickCastAffected && isAlly != base.CombatChar.IsAlly)
		{
			_quickCastAffected = false;
		}
		if (charId == base.CharacterId && skillId == base.SkillTemplateId && power <= 0)
		{
		}
	}
}
