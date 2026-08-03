using System.Collections.Generic;
using GameData.Common;

namespace GameData.Domains.SpecialEffect.SectStory.Baihua;

public class SiQiDuoHun : XiongZhongSiQi
{
	protected override short CombatStateId => 225;

	public SiQiDuoHun(int charId)
		: base(charId)
	{
	}

	protected override IEnumerable<int> CalcFrameCounterPeriods()
	{
		yield return 60;
	}

	public override void OnProcess(DataContext context, int counterType)
	{
		base.CombatChar.AddFatalMarkImmediate(context, 1);
		DomainManager.Combat.ShowSpecialEffectTips(base.CharacterId, 1712, 0);
	}
}
