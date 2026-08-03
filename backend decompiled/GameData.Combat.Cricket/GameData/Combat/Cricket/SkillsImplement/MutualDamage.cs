using GameData.Combat.Math;

namespace GameData.Combat.Cricket.SkillsImplement;

public class MutualDamage : CricketCombatSkillBase
{
	private readonly CValuePercent _costHpOrSpPercent = 10;

	private bool _hpInvoked;

	private bool _spInvoked;

	private int HpLostPercent => CValuePercent.ParseIntClamp01(Owner.MaxHp - Owner.Hp, Owner.MaxHp);

	private int SpLostPercent => CValuePercent.ParseIntClamp01(Owner.MaxSp - Owner.Sp, Owner.MaxSp);

	public override ECricketCombatSkillType Type => ECricketCombatSkillType.MutualDamage;

	private CValuePercentBonus CalcBonus(int lostPercent)
	{
		return 20 + lostPercent * 5 / 2;
	}

	public MutualDamage(CricketCombatData owner)
		: base(owner)
	{
	}

	public override bool PreCheck(ECricketCombatSkillEvent @event, CricketCombatSkillContext context)
	{
		if (@event != ECricketCombatSkillEvent.CheckDamage || !context.Damage.HasValue || context.Attacker != Owner)
		{
			return false;
		}
		_hpInvoked = (_spInvoked = false);
		CricketCombatDamage value = context.Damage.Value;
		if (value.Hp > 0 && context.Bridge.CheckPercentProb(HpLostPercent))
		{
			_hpInvoked = true;
		}
		if (value.Sp > 0 && context.Bridge.CheckPercentProb(SpLostPercent))
		{
			_spInvoked = true;
		}
		int num;
		if (!_hpInvoked)
		{
			num = (_spInvoked ? 1 : 0);
			if (num == 0)
			{
				goto IL_009c;
			}
		}
		else
		{
			num = 1;
		}
		ShowEffectTips(context);
		goto IL_009c;
		IL_009c:
		return (byte)num != 0;
	}

	public override void OnEvent(ECricketCombatSkillEvent @event, CricketCombatSkillContext context)
	{
		if (context.TopContext != null && context.Damage.HasValue)
		{
			CricketCombatDamage damage = context.Damage.Value;
			if (_hpInvoked)
			{
				damage.Hp *= CalcBonus(HpLostPercent);
			}
			if (_spInvoked)
			{
				damage.Sp *= CalcBonus(SpLostPercent);
			}
			context.Damage = damage;
			int costHp = (_hpInvoked ? (Owner.Hp * _costHpOrSpPercent) : 0);
			int costSp = (_spInvoked ? (Owner.Sp * _costHpOrSpPercent) : 0);
			if (costHp != 0 || costSp != 0)
			{
				CricketCombatDamage costDamage = CricketCombatDamage.Create(ECricketCombatDamageType.Skill);
				costDamage.Hp = costHp;
				costDamage.Sp = costSp;
				context.TopContext.DoDamage(Owner, Owner, ECricketCombatDamageType.Skill, costDamage);
			}
		}
	}
}
