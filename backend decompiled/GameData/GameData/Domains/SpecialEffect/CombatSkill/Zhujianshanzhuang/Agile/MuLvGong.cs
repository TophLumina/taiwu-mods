using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

namespace GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.Agile;

public class MuLvGong : AgileSkillBase
{
	private const sbyte DirectReduceCost = -50;

	private static readonly CValuePercent ReverseAdd = 4;

	private bool _affected;

	public MuLvGong()
	{
	}

	public MuLvGong(CombatSkillKey skillKey)
		: base(skillKey, 9500)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		_affected = false;
		if (base.IsDirect)
		{
			AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, 150, -1), EDataModifyType.TotalPercent);
			ShowSpecialEffectTips(0);
		}
		else
		{
			Events.RegisterHandler_AddDirectInjury(OnAddDirectInjury);
			Events.RegisterHandler_AddDirectFatalDamageMark(OnAddDirectFatalDamageMark);
		}
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		if (!base.IsDirect)
		{
			Events.UnRegisterHandler_AddDirectInjury(OnAddDirectInjury);
			Events.UnRegisterHandler_AddDirectFatalDamageMark(OnAddDirectFatalDamageMark);
		}
	}

	private void OnAddDirectInjury(DataContext context, int attackerId, int defenderId, bool isAlly, sbyte bodyPart, sbyte outerMarkCount, sbyte innerMarkCount, short combatSkillId)
	{
		if (defenderId == base.CharacterId && isAlly != base.CombatChar.IsAlly && (outerMarkCount > 0 || innerMarkCount > 0) && base.CanAffect)
		{
			AddMobility(context);
		}
	}

	private void OnAddDirectFatalDamageMark(DataContext context, int attackerId, int defenderId, bool isAlly, sbyte bodyPart, int outerMarkCount, int innerMarkCount, short combatSkillId)
	{
		if (defenderId == base.CharacterId && isAlly != base.CombatChar.IsAlly && (outerMarkCount > 0 || innerMarkCount > 0) && base.CanAffect)
		{
			AddMobility(context);
		}
	}

	private void AddMobility(DataContext context)
	{
		if (!_affected)
		{
			ChangeMobilityValue(context, base.CombatChar, MoveSpecialConstants.MaxMobility * ReverseAdd);
			ShowSpecialEffectTips(0);
			_affected = true;
			Events.RegisterHandler_CombatStateMachineUpdateEnd(OnStateMachineUpdateEnd);
		}
	}

	private void OnStateMachineUpdateEnd(DataContext context, CombatCharacter combatChar)
	{
		_affected = false;
		Events.UnRegisterHandler_CombatStateMachineUpdateEnd(OnStateMachineUpdateEnd);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (!base.CanAffect || dataKey.CharId != base.CharacterId)
		{
			return 0;
		}
		if (dataKey.FieldId == 150)
		{
			return -50;
		}
		return 0;
	}
}
