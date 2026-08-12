using GameData.Combat.Math;

namespace GameData.Combat.Cricket.SkillsImplement;

public class AcceptDamageRecover(CricketCombatData owner) : CricketCombatSkillBase(owner)
{
	private readonly CValuePercent _recoverPercent = 50;

	public override ECricketCombatSkillType Type => ECricketCombatSkillType.AcceptDamageRecover;

	public override ECricketCombatSkillPriority GetPriority(ECricketCombatSkillEvent @event)
	{
		return ECricketCombatSkillPriority.AcceptDamageRecover;
	}

	public override bool PreCheck(ECricketCombatSkillEvent @event, CricketCombatSkillContext context)
	{
		if (@event != ECricketCombatSkillEvent.CheckDamage || context.Defender != Owner || !context.Damage.HasValue)
		{
			return false;
		}
		if (context.Damage.Value.Hp * _recoverPercent <= 0 && context.Damage.Value.Sp * _recoverPercent <= 0)
		{
			return false;
		}
		if (!context.Bridge.CheckPercentProb(66))
		{
			return false;
		}
		ShowEffectTips(context);
		return true;
	}

	public override void OnEvent(ECricketCombatSkillEvent @event, CricketCombatSkillContext context)
	{
		if (context.Damage.HasValue)
		{
			CricketCombatDamage damage = context.Damage.Value;
			int recoverHp = ((damage.Sp > 0) ? (damage.Sp * _recoverPercent) : 0);
			int recoverSp = ((damage.Hp > 0) ? (damage.Hp * _recoverPercent) : 0);
			damage.Hp -= recoverHp;
			damage.Sp -= recoverSp;
			context.Damage = damage;
		}
	}
}
