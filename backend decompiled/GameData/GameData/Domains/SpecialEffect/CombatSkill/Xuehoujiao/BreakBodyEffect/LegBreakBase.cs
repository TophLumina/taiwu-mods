using System;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Combat;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.BreakBodyEffect;

public class LegBreakBase : BreakBodyEffectBase
{
	private const sbyte MaxMobilityPercent = 50;

	protected override bool IsAffectBodyParts(sbyte bodyPart)
	{
		if ((uint)(bodyPart - 5) <= 1u)
		{
			return true;
		}
		return false;
	}

	protected LegBreakBase()
	{
	}

	protected LegBreakBase(int charId, int type)
		: base(charId, type)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 273, -1), EDataModifyType.Custom);
	}

	public override void OnDataAdded(DataContext context)
	{
		if (DomainManager.Combat.IsCharInCombat(base.CharacterId) && base.CombatChar.GetMobilityValue() > MoveSpecialConstants.MaxMobility * 50 / 100)
		{
			DomainManager.Combat.ChangeMobilityValue(context, base.CombatChar, 0);
		}
	}

	public override int GetModifiedValue(AffectedDataKey dataKey, int dataValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return dataValue;
		}
		if (dataKey.FieldId == 273)
		{
			return Math.Min(50, dataValue);
		}
		return base.GetModifiedValue(dataKey, dataValue);
	}
}
