using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Defense;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Baihuagu.DefenseAndAssist;

public class XueHaiNingBingShu : DefenseSkillBase
{
	private const sbyte RequirePoisonPerStatePower = 5;

	private static readonly sbyte[] DirectPoisonTypes = new sbyte[3] { 0, 3, 4 };

	private static readonly sbyte[] ReversePoisonTypes = new sbyte[3] { 1, 2, 5 };

	private readonly Dictionary<sbyte, int> _acceptedPoison = new Dictionary<sbyte, int>();

	private (sbyte type, int value, sbyte level) _bouncePoison;

	public XueHaiNingBingShu()
	{
	}

	public XueHaiNingBingShu(CombatSkillKey skillKey)
		: base(skillKey, 3507)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 162, -1), EDataModifyType.Custom);
		Events.RegisterHandler_AddPoison(OnAddPoison);
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		Events.UnRegisterHandler_AddPoison(OnAddPoison);
		if (_acceptedPoison.Count <= 0 || !DomainManager.Combat.IsInCombat() || !base.SkillData.GetCanAffect())
		{
			return;
		}
		int totalPoison = 0;
		foreach (sbyte type in _acceptedPoison.Keys)
		{
			int value = _acceptedPoison[type];
			DomainManager.Combat.ReducePoison(context, base.CombatChar, type, value);
			totalPoison += value;
		}
		int statePower = totalPoison / 5;
		if (statePower > 0)
		{
			DomainManager.Combat.AddCombatState(context, base.CombatChar, 1, (short)(base.IsDirect ? 20 : 21), statePower);
		}
		ShowSpecialEffectTips(1);
	}

	private void OnAddPoison(DataContext context, int attackerId, int defenderId, sbyte poisonType, sbyte level, int addValue, short skillId, bool canBounce)
	{
		if (defenderId == base.CharacterId && base.CanAffect && (base.IsDirect ? DirectPoisonTypes : ReversePoisonTypes).IndexOf(poisonType) >= 0)
		{
			if (!_acceptedPoison.ContainsKey(poisonType))
			{
				_acceptedPoison[poisonType] = addValue;
			}
			else
			{
				_acceptedPoison[poisonType] += addValue;
			}
			if (canBounce)
			{
				_bouncePoison = (type: poisonType, value: addValue, level: level);
				Events.RegisterHandler_CombatStateMachineUpdateEnd(OnStateMachineUpdateEnd);
			}
		}
	}

	private void OnStateMachineUpdateEnd(DataContext context, CombatCharacter combatChar)
	{
		DomainManager.Combat.AddPoison(context, base.CombatChar, base.CurrEnemyChar, _bouncePoison.type, _bouncePoison.level, _bouncePoison.value, -1, applySpecialEffect: true, canBounce: false);
		ShowSpecialEffectTips(0);
		Events.UnRegisterHandler_CombatStateMachineUpdateEnd(OnStateMachineUpdateEnd);
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.CharId != base.CharacterId || !base.CanAffect || (base.IsDirect ? DirectPoisonTypes : ReversePoisonTypes).IndexOf((sbyte)dataKey.CustomParam0) < 0)
		{
			return dataValue;
		}
		if (dataKey.FieldId == 162)
		{
			return false;
		}
		return dataValue;
	}
}
