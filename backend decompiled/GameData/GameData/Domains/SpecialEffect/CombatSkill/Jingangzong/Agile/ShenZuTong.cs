using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jingangzong.Agile;

public class ShenZuTong : AgileSkillBase
{
	private MoveState _moveState;

	public ShenZuTong()
	{
	}

	public ShenZuTong(CombatSkillKey skillKey)
		: base(skillKey, 11503)
	{
		ListenCanAffectChange = true;
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		_moveState = MoveState.Stay;
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 55, -1), EDataModifyType.Custom);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 157, -1), EDataModifyType.Custom);
		Events.RegisterHandler_MoveStateChanged(OnMoveStateChanged);
		ShowSpecialEffectTips(0);
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		Events.UnRegisterHandler_MoveStateChanged(OnMoveStateChanged);
	}

	private void OnMoveStateChanged(DataContext context, CombatCharacter character, MoveState moveState)
	{
		if (character == base.CombatChar)
		{
			_moveState = moveState;
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 55);
		}
	}

	protected override void OnMoveSkillCanAffectChanged(DataContext context, DataUid dataUid)
	{
		DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 55);
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.CharId != base.CharacterId || !base.CanAffect || _moveState != (MoveState)(base.IsDirect ? 1 : 2))
		{
			return dataValue;
		}
		if (dataKey.FieldId == 55 && dataKey.CustomParam0 == 1)
		{
			return false;
		}
		if (dataKey.FieldId == 157)
		{
			return false;
		}
		return dataValue;
	}
}
