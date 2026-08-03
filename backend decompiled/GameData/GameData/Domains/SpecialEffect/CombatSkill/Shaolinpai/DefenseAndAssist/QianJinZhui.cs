using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Defense;

namespace GameData.Domains.SpecialEffect.CombatSkill.Shaolinpai.DefenseAndAssist;

public class QianJinZhui : DefenseSkillBase
{
	private const int ChangeStanceBreathValuePercent = 30;

	public QianJinZhui()
	{
	}

	public QianJinZhui(CombatSkillKey skillKey)
		: base(skillKey, 1502)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 148, -1), EDataModifyType.Custom);
		ShowSpecialEffectTips(0);
		Events.RegisterHandler_IgnoredForceChangeDistance(IgnoredForceChangeDistance);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_IgnoredForceChangeDistance(IgnoredForceChangeDistance);
		base.OnDisable(context);
	}

	private void IgnoredForceChangeDistance(DataContext context, CombatCharacter mover, int distance)
	{
		if (mover == base.CombatChar && !(base.IsDirect ? (distance < 0) : (distance > 0)) && distance != 0 && base.CanAffect)
		{
			ChangeStanceValue(context, base.CurrEnemyChar, -1200);
			ChangeBreathValue(context, base.CurrEnemyChar, -9000);
			ShowSpecialEffectTips(1);
		}
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.CharId != base.CharacterId || !base.CanAffect || !(base.IsDirect ? (dataKey.CustomParam0 > 0) : (dataKey.CustomParam0 < 0)))
		{
			return dataValue;
		}
		if (dataKey.FieldId == 148)
		{
			return false;
		}
		return dataValue;
	}
}
