using System;
using System.Linq;
using Config;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.NoSect.TwelveImmortals;

public abstract class TwelveImmortalsBase : CombatSkillEffectBase
{
	protected TwelveImmortalsItem TwelveImmortalsConfig => Config.TwelveImmortals.Instance.FirstOrDefault(Match) ?? throw new Exception($"No match config at {SkillKey}");

	protected TwelveImmortalsBase()
	{
	}

	protected TwelveImmortalsBase(CombatSkillKey skillKey, int type)
		: base(skillKey, type, -1)
	{
	}

	private bool Match(TwelveImmortalsItem config)
	{
		return config.CombatSkill == base.SkillTemplateId;
	}
}
