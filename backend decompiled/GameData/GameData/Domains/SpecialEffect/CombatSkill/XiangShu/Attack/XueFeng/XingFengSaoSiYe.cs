using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.XueFeng;

public class XingFengSaoSiYe : PowerUpOnCast
{
	private const sbyte AddPowerUnit = 10;

	protected override EDataModifyType ModifyType => EDataModifyType.AddPercent;

	public XingFengSaoSiYe()
	{
	}

	public XingFengSaoSiYe(CombatSkillKey skillKey)
		: base(skillKey, 17072)
	{
	}

	public override void OnEnable(DataContext context)
	{
		PowerUpValue = 10 * base.CombatChar.GetOldInjuries().GetSum();
		base.OnEnable(context);
	}
}
