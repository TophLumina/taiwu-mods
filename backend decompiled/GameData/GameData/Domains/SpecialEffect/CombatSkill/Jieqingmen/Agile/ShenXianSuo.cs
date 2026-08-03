using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jieqingmen.Agile;

public class ShenXianSuo : AgileSkillBase
{
	private const sbyte ChangeDistance = 40;

	private bool _autoMoving;

	private int _needChangeDistance;

	public ShenXianSuo()
	{
	}

	public ShenXianSuo(CombatSkillKey skillKey)
		: base(skillKey, 13405)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		AutoRemove = false;
		_autoMoving = false;
		_needChangeDistance = 0;
		CreateAffectedData(149, EDataModifyType.Custom, -1);
		CreateAffectedData(157, EDataModifyType.Custom, -1);
		Events.RegisterHandler_NormalAttackPrepareEnd(OnNormalAttackPrepareEnd);
		Events.RegisterHandler_NormalAttackAllEnd(OnNormalAttackAllEnd);
		Events.RegisterHandler_PrepareSkillChangeDistance(OnPrepareSkillChangeDistance);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		Events.UnRegisterHandler_NormalAttackPrepareEnd(OnNormalAttackPrepareEnd);
		Events.UnRegisterHandler_NormalAttackAllEnd(OnNormalAttackAllEnd);
		Events.UnRegisterHandler_PrepareSkillChangeDistance(OnPrepareSkillChangeDistance);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnNormalAttackPrepareEnd(DataContext context, int charId, bool isAlly)
	{
		if (charId == base.CharacterId && base.CanAffect && !base.CombatChar.IsUnlockAttack)
		{
			ChangeDistanceOnAttack(context);
		}
	}

	private void OnNormalAttackAllEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender)
	{
		if (_needChangeDistance != 0 && attacker == base.CombatChar && base.CombatChar.NormalAttackLeftRepeatTimes <= 0)
		{
			RestoreDistance(context);
		}
	}

	private void OnPrepareSkillChangeDistance(DataContext context, CombatCharacter attacker, CombatCharacter defender, short skillId)
	{
		if (skillId >= 0 && attacker == base.CombatChar && base.CanAffect)
		{
			ChangeDistanceOnAttack(context);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (_needChangeDistance != 0 && charId == base.CharacterId)
		{
			RestoreDistance(context);
		}
	}

	protected override void OnMoveSkillChanged(DataContext context, DataUid dataUid)
	{
		base.OnMoveSkillChanged(context, dataUid);
		if (AgileSkillChanged && _needChangeDistance == 0)
		{
			RemoveSelf(context);
		}
	}

	private void ChangeDistanceOnAttack(DataContext context)
	{
		short distanceBefore = DomainManager.Combat.GetCurrentDistance();
		_autoMoving = true;
		DomainManager.Combat.ChangeDistance(context, base.CombatChar, base.IsDirect ? (-40) : 40);
		_autoMoving = false;
		_needChangeDistance = distanceBefore - DomainManager.Combat.GetCurrentDistance();
		ShowSpecialEffectTips(0);
	}

	private void RestoreDistance(DataContext context)
	{
		_autoMoving = true;
		DomainManager.Combat.ChangeDistance(context, base.CombatChar, _needChangeDistance);
		_autoMoving = false;
		_needChangeDistance = 0;
		if (AgileSkillChanged)
		{
			RemoveSelf(context);
		}
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.FieldId == 149 && dataKey.CustomParam0 >= 0 && DomainManager.Combat.GetElement_CombatCharacterDict(dataKey.CustomParam0).IsAlly != base.CombatChar.IsAlly && base.CanAffect)
		{
			return false;
		}
		if (dataKey.FieldId == 157)
		{
			return !_autoMoving;
		}
		return dataValue;
	}
}
