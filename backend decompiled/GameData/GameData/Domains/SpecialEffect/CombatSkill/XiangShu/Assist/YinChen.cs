using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Assist;

public class YinChen : RanChenZiAssistSkillBase
{
	public YinChen()
	{
	}

	public YinChen(CombatSkillKey skillKey)
		: base(skillKey, 16410)
	{
		RequireBossPhase = 0;
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 157, -1), EDataModifyType.Custom);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 175, -1), EDataModifyType.Custom);
		Events.RegisterHandler_CombatBegin(OnCombatBegin);
	}

	protected override void DeactivateEffect(DataContext context)
	{
		ClearAffectedData(context);
	}

	private void OnCombatBegin(DataContext context)
	{
		ShowSpecialEffectTips(0);
		base.CombatChar.SetXiangshuEffectId((short)base.EffectId, context);
		SetConstAffecting(context, affecting: true);
		Events.UnRegisterHandler_CombatBegin(OnCombatBegin);
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return base.GetModifiedValue(dataKey, dataValue);
		}
		if (dataKey.FieldId == 157)
		{
			return false;
		}
		return base.GetModifiedValue(dataKey, dataValue);
	}

	public override int GetModifiedValue(AffectedDataKey dataKey, int dataValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return dataValue;
		}
		if (dataKey.FieldId == 175)
		{
			return 0;
		}
		return dataValue;
	}
}
