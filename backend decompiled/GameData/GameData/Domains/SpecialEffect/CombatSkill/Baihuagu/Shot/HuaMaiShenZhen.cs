using GameData.Common;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Baihuagu.Shot;

public class HuaMaiShenZhen : PoisonAddInjury
{
	private const int CostNeiliAllocationUnit = -10;

	private const int SilenceNeiliAllocationUnit = 400;

	public HuaMaiShenZhen()
	{
	}

	public HuaMaiShenZhen(CombatSkillKey skillKey)
		: base(skillKey, 3207)
	{
		RequirePoisonType = 1;
	}

	protected override void OnCastMaxPower(DataContext context)
	{
		CombatCharacter poisonChar = (base.IsDirect ? base.EnemyChar : base.CombatChar);
		byte unit = poisonChar.GetDefeatMarkCollection().PoisonMarkList[RequirePoisonType];
		if (unit > 0)
		{
			for (byte i = 0; i < 4; i++)
			{
				base.EnemyChar.ChangeNeiliAllocation(context, i, unit * -10);
			}
			base.EnemyChar.SilenceNeiliAllocationAutoRecover(context, unit * 400);
			ShowSpecialEffectTips(1);
		}
	}
}
