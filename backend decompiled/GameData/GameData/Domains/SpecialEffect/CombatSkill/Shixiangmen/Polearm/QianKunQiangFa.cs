using GameData.Common;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Shixiangmen.Polearm;

public class QianKunQiangFa : AddPowerAndNeiliAllocationByMoving
{
	protected override int MoveCostMobilityAddPercent => -50;

	public QianKunQiangFa()
	{
	}

	public QianKunQiangFa(CombatSkillKey skillKey)
		: base(skillKey, 6304)
	{
		AddNeiliAllocationType = 2;
	}

	protected override void OnDistanceChangedAddNeiliAllocation(DataContext context)
	{
		base.OnDistanceChangedAddNeiliAllocation(context);
		base.CombatChar.ChangeNeiliAllocation(context, 0, AddNeiliAllocationUnit);
		ShowSpecialEffectTips(2);
	}
}
