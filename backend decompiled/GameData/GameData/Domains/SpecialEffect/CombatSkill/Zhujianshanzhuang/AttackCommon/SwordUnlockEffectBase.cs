using System.Collections.Generic;
using System.Linq;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.AttackCommon;

public abstract class SwordUnlockEffectBase : WeaponUnlockEffectBase, IExtraUnlockEffect
{
	protected override short WeaponType => 8;

	protected override CValuePercent DirectAddUnlockPercent => 32;

	protected override bool ReverseEffectDoubling => RequirePersonalityTypes.All((sbyte x) => base.CombatChar.GetCharacter().GetPersonality(x) >= RequirePersonalityValue);

	protected abstract IEnumerable<sbyte> RequirePersonalityTypes { get; }

	protected abstract int RequirePersonalityValue { get; }

	protected SwordUnlockEffectBase()
	{
	}

	protected SwordUnlockEffectBase(CombatSkillKey skillKey, int type)
		: base(skillKey, type)
	{
	}

	protected sealed override void DoAffect(DataContext context, int weaponIndex)
	{
		base.CombatChar.InvokeExtraUnlockEffect(this, weaponIndex);
	}

	public void DoAffectAfterCost(DataContext context, int weaponIndex)
	{
		AddMaxEffectCount();
		OnAddedEffectCount(context);
	}

	protected virtual void OnAddedEffectCount(DataContext context)
	{
	}
}
