namespace GameData.Combat.Cricket.SkillsImplement;

public class AdvanceParry : CricketCombatSkillBase
{
	private bool _affectHp;

	private bool _affectSp;

	public override ECricketCombatSkillType Type => ECricketCombatSkillType.AdvanceParry;

	public AdvanceParry(CricketCombatData owner)
		: base(owner)
	{
	}

	public override bool PreCheck(ECricketCombatSkillEvent @event, CricketCombatSkillContext context)
	{
		if (@event != ECricketCombatSkillEvent.CheckDamage || !context.Damage.HasValue || context.Defender != Owner)
		{
			return false;
		}
		CricketCombatDamage value = context.Damage.Value;
		if (value.Hp > 0)
		{
			_affectHp = context.Bridge.CheckPercentProb(33);
		}
		if (value.Sp > 0)
		{
			_affectSp = context.Bridge.CheckPercentProb(33);
		}
		int num;
		if (!_affectHp)
		{
			num = (_affectSp ? 1 : 0);
			if (num == 0)
			{
				goto IL_007e;
			}
		}
		else
		{
			num = 1;
		}
		ShowEffectTips(context);
		goto IL_007e;
		IL_007e:
		return (byte)num != 0;
	}

	public override void OnEvent(ECricketCombatSkillEvent @event, CricketCombatSkillContext context)
	{
		if (context.Damage.HasValue)
		{
			CricketCombatDamage damage = context.Damage.Value;
			if (_affectHp)
			{
				damage.Hp = 0;
			}
			if (_affectSp)
			{
				damage.Sp = 0;
			}
			context.Damage = damage;
		}
	}
}
