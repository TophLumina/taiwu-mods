using System;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.Animal.Loong.Neigong;

public class Pulao : AnimalEffectBase
{
	private enum EAcceptDamageType
	{
		None,
		Outer,
		Inner,
		Mind
	}

	private bool _beAttacked;

	private EAcceptDamageType _acceptDamageType = EAcceptDamageType.None;

	private bool IsDamageValid(EAcceptDamageType damageType)
	{
		if (_beAttacked)
		{
			return damageType == _acceptDamageType;
		}
		EAcceptDamageType acceptDamageType = _acceptDamageType;
		if (1 == 0)
		{
		}
		bool result;
		switch (acceptDamageType)
		{
		case EAcceptDamageType.None:
			result = true;
			break;
		case EAcceptDamageType.Outer:
		{
			bool flag = (uint)(damageType - 2) <= 1u;
			result = flag;
			break;
		}
		case EAcceptDamageType.Inner:
		{
			bool flag = ((damageType == EAcceptDamageType.Outer || damageType == EAcceptDamageType.Mind) ? true : false);
			result = flag;
			break;
		}
		case EAcceptDamageType.Mind:
		{
			bool flag = (uint)(damageType - 1) <= 1u;
			result = flag;
			break;
		}
		default:
			throw new Exception($"Unexpected acceptDamageType {_acceptDamageType}");
		}
		if (1 == 0)
		{
		}
		return result;
	}

	public Pulao()
	{
	}

	public Pulao(CombatSkillKey skillKey)
		: base(skillKey)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(114, EDataModifyType.Custom, -1);
		CreateAffectedData(275, EDataModifyType.Custom, -1);
		Events.RegisterHandler_AddDirectDamageValue(OnAddDirectDamageValue);
		Events.RegisterHandler_AddMindDamage(OnAddMindDamageValue);
		Events.RegisterHandler_NormalAttackAllEnd(OnNormalAttackAllEnd);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_AddDirectDamageValue(OnAddDirectDamageValue);
		Events.UnRegisterHandler_AddMindDamage(OnAddMindDamageValue);
		Events.UnRegisterHandler_NormalAttackAllEnd(OnNormalAttackAllEnd);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		base.OnDisable(context);
	}

	private void OnAddDirectDamageValue(DataContext context, int attackerId, int defenderId, sbyte bodyPart, bool isInner, int damageValue, short combatSkillId)
	{
		if (defenderId == base.CharacterId && damageValue > 0 && !_beAttacked)
		{
			_beAttacked = true;
			_acceptDamageType = ((!isInner) ? EAcceptDamageType.Outer : EAcceptDamageType.Inner);
		}
	}

	private void OnAddMindDamageValue(DataContext context, int attackerId, int defenderId, int damageValue, int markCount, short combatSkillId)
	{
		if (defenderId == base.CharacterId && damageValue > 0 && !_beAttacked)
		{
			_beAttacked = true;
			_acceptDamageType = EAcceptDamageType.Mind;
		}
	}

	private void OnNormalAttackAllEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender)
	{
		if (defender.GetId() == base.CharacterId && _beAttacked)
		{
			_beAttacked = false;
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId != base.CharacterId && _beAttacked)
		{
			_beAttacked = false;
		}
	}

	public override int GetModifiedValue(AffectedDataKey dataKey, int dataValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.FieldId != 275)
		{
			return dataValue;
		}
		if (IsDamageValid(EAcceptDamageType.Mind))
		{
			return dataValue;
		}
		ShowSpecialEffectTips(0);
		return 0;
	}

	public override long GetModifiedValue(AffectedDataKey dataKey, long dataValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.FieldId != 114)
		{
			return dataValue;
		}
		EDamageType damageType = (EDamageType)dataKey.CustomParam0;
		if (damageType != EDamageType.Direct)
		{
			return dataValue;
		}
		bool isInner = dataKey.CustomParam1 == 1;
		if (IsDamageValid((!isInner) ? EAcceptDamageType.Outer : EAcceptDamageType.Inner))
		{
			return dataValue;
		}
		ShowSpecialEffectTips(0);
		return 0L;
	}
}
