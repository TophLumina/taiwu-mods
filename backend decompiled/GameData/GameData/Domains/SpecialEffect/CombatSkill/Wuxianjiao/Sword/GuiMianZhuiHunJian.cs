using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.Sword;

public class GuiMianZhuiHunJian : AddPowerAndNeiliAllocationByMoving
{
	protected override sbyte AddPowerUnit => 10;

	protected override int MoveCostMobilityAddPercent => -100;

	protected override sbyte AddNeiliAllocationUnit => 0;

	public GuiMianZhuiHunJian()
	{
	}

	public GuiMianZhuiHunJian(CombatSkillKey skillKey)
		: base(skillKey, 12304)
	{
		AddNeiliAllocationType = 1;
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(175, EDataModifyType.Custom, -1);
		ShowSpecialEffectTips(1);
	}

	protected override void OnDistanceChangedAddNeiliAllocation(DataContext context)
	{
	}

	public override int GetModifiedValue(AffectedDataKey dataKey, int dataValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.FieldId != 175)
		{
			return dataValue;
		}
		return 0;
	}
}
