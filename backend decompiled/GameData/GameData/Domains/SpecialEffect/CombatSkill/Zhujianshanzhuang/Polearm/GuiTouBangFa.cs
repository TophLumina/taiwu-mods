using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.AttackCommon;

namespace GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.Polearm;

public class GuiTouBangFa : RawCreateUnlockEffectBase
{
	private CValuePercent CastAddUnlockPercent => base.IsDirectOrReverseEffectDoubling ? 12 : 6;

	protected override IEnumerable<sbyte> RequireMainAttributeTypes { get; } = new sbyte[2] { 1, 5 };

	protected override int RequireMainAttributeValue => 65;

	public GuiTouBangFa()
	{
	}

	public GuiTouBangFa(CombatSkillKey skillKey)
		: base(skillKey, 9303)
	{
	}

	protected override void OnCastAddUnlockAttackValue(DataContext context, CValuePercent power)
	{
		base.OnCastAddUnlockAttackValue(context, power);
		if (base.IsReverseOrUsingDirectWeapon)
		{
			base.CombatChar.ChangeAllUnlockAttackValue(context, CastAddUnlockPercent * power);
			ShowSpecialEffectTipsOnceInFrame(0);
		}
	}
}
