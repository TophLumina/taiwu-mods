using System.Collections.Generic;
using GameData.Common;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.Adventure.EnemyNest;

public class BaReCiFu : FeatureEffectBase
{
	private const int DurationFrame = 800;

	private const sbyte FlawLevel = 3;

	public BaReCiFu()
	{
	}

	public BaReCiFu(int charId, short featureId)
		: base(charId, featureId, 100002)
	{
	}

	protected override IEnumerable<int> CalcFrameCounterPeriods()
	{
		yield return 800;
	}

	public override void OnProcess(DataContext context, int counterType)
	{
		DomainManager.Combat.AddFlaw(context, base.EnemyChar, 3, CombatSkillKey.Invalid, -1);
		DomainManager.Combat.ShowSpecialEffectTips(base.CharacterId, 1799, 0);
	}
}
