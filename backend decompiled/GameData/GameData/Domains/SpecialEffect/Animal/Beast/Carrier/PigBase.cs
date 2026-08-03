using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;

namespace GameData.Domains.SpecialEffect.Animal.Beast.Carrier;

public abstract class PigBase : CombatStateEffectBase
{
	protected abstract CValuePercent AddCriticalOddsPercent { get; }

	protected PigBase()
	{
	}

	protected PigBase(int charId)
		: base(charId)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 341, -1), EDataModifyType.AddPercent);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return 0;
		}
		if (dataKey.FieldId == 341)
		{
			return (140 - DomainManager.Combat.GetCurrentDistance()) * AddCriticalOddsPercent;
		}
		return 0;
	}
}
