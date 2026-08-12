using System;
using GameData.Combat.Math;
using GameData.Common;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.BreakBodyEffect;

public class ChestBreakBase : BreakBodyEffectBase
{
	private const sbyte MaxBreathPercent = 60;

	protected override bool IsAffectBodyParts(sbyte bodyPart)
	{
		return bodyPart == 0;
	}

	protected ChestBreakBase()
	{
	}

	protected ChestBreakBase(int charId, int type)
		: base(charId, type)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 171, -1), EDataModifyType.Custom);
	}

	public override void OnDataAdded(DataContext context)
	{
		if (DomainManager.Combat.IsCharInCombat(base.CharacterId) && base.CombatChar.GetBreathValue() > base.CombatChar.GetMaxBreathValue())
		{
			DomainManager.Combat.ChangeBreathValue(context, base.CombatChar, 0);
		}
	}

	public override int GetModifiedValue(AffectedDataKey dataKey, int dataValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return dataValue;
		}
		if (dataKey.FieldId == 171)
		{
			return Math.Min(60, dataValue);
		}
		return base.GetModifiedValue(dataKey, dataValue);
	}
}
