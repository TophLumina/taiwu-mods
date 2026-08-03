using System.Collections.Generic;
using GameData.Common;

namespace GameData.Domains.SpecialEffect.Adventure.EnemyNest;

public class WuJianCiFu : FeatureEffectBase
{
	private const int DurationFrame = 800;

	public WuJianCiFu()
	{
	}

	public WuJianCiFu(int charId, short featureId)
		: base(charId, featureId, 100004)
	{
	}

	protected override IEnumerable<int> CalcFrameCounterPeriods()
	{
		yield return 800;
	}

	public override void OnProcess(DataContext context, int counterType)
	{
		base.EnemyChar.AddMindMark(context, 1, -1);
		DomainManager.Combat.ShowSpecialEffectTips(base.CharacterId, 1801, 0);
	}
}
