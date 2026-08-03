namespace GameData.Combat.Cricket.SkillsImplement;

public class BeHitAddProperty : CricketCombatSkillBase
{
	public override ECricketCombatSkillType Type => ECricketCombatSkillType.BeHitAddProperty;

	public BeHitAddProperty(CricketCombatData owner)
		: base(owner)
	{
	}

	public override bool PreCheck(ECricketCombatSkillEvent @event, CricketCombatSkillContext context)
	{
		if (@event != ECricketCombatSkillEvent.DoDamage || context.Defender != Owner)
		{
			return false;
		}
		ECricketCombatDamageType? damageType = context.DamageType;
		bool flag;
		if (damageType.HasValue)
		{
			ECricketCombatDamageType valueOrDefault = damageType.GetValueOrDefault();
			if ((uint)valueOrDefault <= 2u)
			{
				flag = true;
				goto IL_0036;
			}
		}
		flag = false;
		goto IL_0036;
		IL_0036:
		if (!flag)
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
		AddModify(context, ECricketCombatPropertyModifyLifeCycle.Combat, context.DamageType switch
		{
			ECricketCombatDamageType.Vigor => ECricketCombatPropertyType.Vigor, 
			ECricketCombatDamageType.Strength => ECricketCombatPropertyType.Strength, 
			ECricketCombatDamageType.Bite => ECricketCombatPropertyType.Bite, 
			_ => ECricketCombatPropertyType.Invalid, 
		}, 1);
	}
}
