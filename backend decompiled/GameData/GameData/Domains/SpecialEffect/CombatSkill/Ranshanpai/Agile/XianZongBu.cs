using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

namespace GameData.Domains.SpecialEffect.CombatSkill.Ranshanpai.Agile;

public class XianZongBu : AgileSkillBase
{
	private const sbyte ChangeDistance = 20;

	private bool _autoMoving;

	private int _needChangeDistance;

	private CombatSkillKey _attackSkillKey;

	public XianZongBu()
	{
	}

	public XianZongBu(CombatSkillKey skillKey)
		: base(skillKey, 7404)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		AutoRemove = false;
		_autoMoving = false;
		_needChangeDistance = 0;
		_attackSkillKey.CharId = -1;
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
		if (isAlly != base.CombatChar.IsAlly && base.CanAffect && DomainManager.Combat.GetCombatCharacter(base.CombatChar.IsAlly, tryGetCoverCharacter: true) == base.CombatChar)
		{
			CombatCharacter attacker = DomainManager.Combat.GetElement_CombatCharacterDict(charId);
			if (!attacker.IsUnlockAttack)
			{
				ChangeDistanceOnAttack(context);
			}
		}
	}

	private void OnNormalAttackAllEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender)
	{
		if (_needChangeDistance != 0 && defender == base.CombatChar)
		{
			RestoreDistance(context);
		}
	}

	private void OnPrepareSkillChangeDistance(DataContext context, CombatCharacter attacker, CombatCharacter defender, short skillId)
	{
		if (skillId >= 0 && defender == base.CombatChar && base.CanAffect)
		{
			_attackSkillKey = new CombatSkillKey(attacker.GetId(), skillId);
			ChangeDistanceOnAttack(context);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (_needChangeDistance != 0 && charId == _attackSkillKey.CharId && skillId == _attackSkillKey.SkillTemplateId)
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
		DomainManager.Combat.ChangeDistance(context, base.CombatChar, base.IsDirect ? (-20) : 20);
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
		if (dataKey.CharId != base.CharacterId)
		{
			return dataValue;
		}
		if (dataKey.FieldId == 157)
		{
			return !_autoMoving;
		}
		return dataValue;
	}
}
