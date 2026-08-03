using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wudangpai.Sword;

public class ChunYangJianYi : PowerUpOnCast
{
	private int AddPowerPercent => base.IsDirect ? 12 : 6;

	protected override EDataModifyType ModifyType => EDataModifyType.AddPercent;

	public ChunYangJianYi()
	{
	}

	public ChunYangJianYi(CombatSkillKey skillKey)
		: base(skillKey, 4204)
	{
	}

	public override void OnEnable(DataContext context)
	{
		if (base.IsDirect == CharObj.HasVirginity())
		{
			PowerUpValue = CharObj.GetInnerRatio() * AddPowerPercent / 100;
		}
		base.OnEnable(context);
	}
}
