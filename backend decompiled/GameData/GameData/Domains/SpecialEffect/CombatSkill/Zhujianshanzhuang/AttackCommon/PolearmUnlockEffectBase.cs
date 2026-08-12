using System.Collections.Generic;
using System.Linq;
using GameData.Combat.Math;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.AttackCommon;

public abstract class PolearmUnlockEffectBase : WeaponUnlockEffectBase
{
	protected override short WeaponType => 10;

	protected override CValuePercent DirectAddUnlockPercent => 16;

	protected override bool ReverseEffectDoubling => RequireMainAttributeTypes.All((sbyte x) => base.CombatChar.GetCharacter().GetMaxMainAttribute(x) >= RequireMainAttributeValue);

	protected abstract IEnumerable<sbyte> RequireMainAttributeTypes { get; }

	protected abstract int RequireMainAttributeValue { get; }

	protected PolearmUnlockEffectBase()
	{
	}

	protected PolearmUnlockEffectBase(CombatSkillKey skillKey, int type)
		: base(skillKey, type)
	{
	}
}
