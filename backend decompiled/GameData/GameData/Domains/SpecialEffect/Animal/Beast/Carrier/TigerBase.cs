using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;

namespace GameData.Domains.SpecialEffect.Animal.Beast.Carrier;

public abstract class TigerBase : CombatStateEffectBase
{
	protected abstract int AddDamagePercentUnit { get; }

	protected TigerBase()
	{
	}

	protected TigerBase(int charId)
		: base(charId)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 69, -1), EDataModifyType.AddPercent);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId >= 0 || dataKey.FieldId != 69)
		{
			return 0;
		}
		return base.CombatChar.PursueAttackCount * AddDamagePercentUnit;
	}
}
