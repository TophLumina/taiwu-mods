using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jieqingmen.Throw;

public class WuYingLiuShou : CombatSkillEffectBase
{
	private bool IsAffectChar(CombatCharacter combatChar)
	{
		return combatChar.IsAlly != base.CombatChar.IsAlly;
	}

	public WuYingLiuShou()
	{
	}

	public WuYingLiuShou(CombatSkillKey skillKey)
		: base(skillKey, 13302, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_CombatBegin(OnCombatBegin);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.RegisterHandler_AddInjury(OnAddInjury);
		Events.RegisterHandler_AddMindMark(OnAddMindMark);
		Events.RegisterHandler_FlawAdded(OnFlawAdded);
		Events.RegisterHandler_AcuPointAdded(OnAcuPointAdded);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CombatBegin(OnCombatBegin);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.UnRegisterHandler_AddInjury(OnAddInjury);
		Events.UnRegisterHandler_AddMindMark(OnAddMindMark);
		Events.UnRegisterHandler_FlawAdded(OnFlawAdded);
		Events.UnRegisterHandler_AcuPointAdded(OnAcuPointAdded);
	}

	private void OnCombatBegin(DataContext context)
	{
		AddMaxEffectCount();
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId && PowerMatchAffectRequire(power))
		{
			AddMaxEffectCount();
		}
	}

	private void OnAddInjury(DataContext context, CombatCharacter character, sbyte bodyPart, bool isInner, int value, bool changeToOld)
	{
		if (IsAffectChar(character))
		{
			DoAddTrick(context);
		}
	}

	private void OnAddMindMark(DataContext context, CombatCharacter character, int count)
	{
		if (IsAffectChar(character) && count > 0)
		{
			DoAddTrick(context);
		}
	}

	private void OnFlawAdded(DataContext context, CombatCharacter combatChar, sbyte bodyPart, sbyte level)
	{
		if (IsAffectChar(combatChar))
		{
			DoAddTrick(context);
		}
	}

	private void OnAcuPointAdded(DataContext context, CombatCharacter combatChar, sbyte bodyPart, sbyte level)
	{
		if (IsAffectChar(combatChar))
		{
			DoAddTrick(context);
		}
	}

	private void DoAddTrick(DataContext context)
	{
		if (base.EffectCount > 0 && base.IsCurrent)
		{
			ReduceEffectCount();
			DomainManager.Combat.AddTrick(context, base.IsDirect ? base.CombatChar : base.EnemyChar, 19, base.IsDirect);
			ShowSpecialEffectTips(0);
		}
	}
}
