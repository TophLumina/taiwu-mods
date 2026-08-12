using System;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Shixiangmen.Polearm;

public class WuHuDuanHunQiang : PowerUpOnCast
{
	private const sbyte AddPowerUnit = 20;

	protected override EDataModifyType ModifyType => EDataModifyType.AddPercent;

	public WuHuDuanHunQiang()
	{
	}

	public WuHuDuanHunQiang(CombatSkillKey skillKey)
		: base(skillKey, 6301)
	{
	}

	public override void OnEnable(DataContext context)
	{
		CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly);
		OuterAndInnerShorts selfRange = base.CombatChar.GetAttackRange();
		OuterAndInnerShorts enemyRange = enemyChar.GetAttackRange();
		PowerUpValue = Math.Max((base.IsDirect ? (selfRange.Inner - enemyRange.Inner) : (enemyRange.Outer - selfRange.Outer)) / 10 * 20, 0);
		base.OnEnable(context);
	}
}
