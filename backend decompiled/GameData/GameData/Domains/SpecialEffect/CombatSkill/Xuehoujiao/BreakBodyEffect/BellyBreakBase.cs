using System;
using GameData.Combat.Math;
using GameData.Common;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.BreakBodyEffect;

public class BellyBreakBase : BreakBodyEffectBase
{
	private const sbyte MaxStancePercent = 60;

	protected override bool IsAffectBodyParts(sbyte bodyPart)
	{
		return bodyPart == 1;
	}

	protected BellyBreakBase()
	{
	}

	protected BellyBreakBase(int charId, int type)
		: base(charId, type)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 172, -1), EDataModifyType.Custom);
	}

	public override void OnDataAdded(DataContext context)
	{
		if (DomainManager.Combat.IsCharInCombat(base.CharacterId) && base.CombatChar.GetStanceValue() > base.CombatChar.GetMaxStanceValue())
		{
			DomainManager.Combat.ChangeStanceValue(context, base.CombatChar, 0);
		}
	}

	public override int GetModifiedValue(AffectedDataKey dataKey, int dataValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return dataValue;
		}
		if (dataKey.FieldId == 172)
		{
			return Math.Min(60, dataValue);
		}
		return base.GetModifiedValue(dataKey, dataValue);
	}
}
