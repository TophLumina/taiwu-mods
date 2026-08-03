using System.Collections.Generic;
using GameData.Common;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.Adventure.EnemyNest;

public class BaHanCiFu : FeatureEffectBase
{
	private const int DurationFrame = 800;

	private const sbyte AcupointLevel = 3;

	public BaHanCiFu()
	{
	}

	public BaHanCiFu(int charId, short featureId)
		: base(charId, featureId, 100003)
	{
	}

	protected override IEnumerable<int> CalcFrameCounterPeriods()
	{
		yield return 800;
	}

	public override void OnProcess(DataContext context, int counterType)
	{
		DomainManager.Combat.AddAcupoint(context, base.EnemyChar, 3, CombatSkillKey.Invalid, -1);
		DomainManager.Combat.ShowSpecialEffectTips(base.CharacterId, 1800, 0);
	}
}
