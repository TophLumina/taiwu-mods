using GameData.Common;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Shaolinpai.Polearm;

public class ShiBaDianQiMeiGun : TrickBuffFlaw
{
	private const sbyte ReverseTrickOdds = 60;

	public ShiBaDianQiMeiGun()
	{
	}

	public ShiBaDianQiMeiGun(CombatSkillKey skillKey)
		: base(skillKey, 1302)
	{
		RequireTrickType = 5;
	}

	protected override bool OnReverseAffect(DataContext context, int trickCount)
	{
		bool anyAffect = false;
		for (int i = 0; i < trickCount; i++)
		{
			if (context.Random.CheckPercentProb(60))
			{
				DomainManager.Combat.ChangeChangeTrickCount(context, base.CombatChar, 1);
				anyAffect = true;
			}
		}
		return anyAffect;
	}
}
