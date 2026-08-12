using Config;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.XiangShu;

public class WanNianWeiShi : CombatSkillEffectBase
{
	private const short AddGoneMadInjury = 200;

	private const int HealInjuryFactor = 2;

	public WanNianWeiShi()
	{
	}

	public WanNianWeiShi(CombatSkillKey skillKey)
		: base(skillKey, -1, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
		base.OnDisable(context);
	}

	private void OnCastAttackSkillBegin(DataContext context, CombatCharacter attacker, CombatCharacter _, short skillId)
	{
		if (SkillKey.IsMatch(attacker.GetId(), skillId))
		{
			AddMaxEffectCount();
		}
		else if (base.EffectCount > 0 && attacker.IsAlly != base.CombatChar.IsAlly)
		{
			DoAffect(context, attacker, skillId);
		}
	}

	private void DoAffect(DataContext context, CombatCharacter combatChar, short skillId)
	{
		ReduceEffectCount();
		sbyte part = DomainManager.Combat.AddGoneMadInjury(context, combatChar, skillId, 200);
		ShowSpecialEffectTips(0);
		CombatSkillItem config = Config.CombatSkill.Instance[skillId];
		int value = config.GoneMadInjuryValue * 2;
		if (part < 0)
		{
			base.CombatChar.RemoveFatalMark(context, value);
		}
		else
		{
			base.CombatChar.RemoveInjury(context, part, config.GoneMadInnerInjury, value);
		}
		ShowSpecialEffectTips(1);
	}
}
