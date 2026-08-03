using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.Animal.Beast.Neigong;

public class ZhuTuXiYong : AnimalEffectBase
{
	private static readonly CValuePercent CostMobilityPercent = 10;

	private bool _inAttackRange;

	private bool _isAffecting;

	private int AddDamagePercent => base.IsElite ? 60 : 30;

	public ZhuTuXiYong()
	{
	}

	public ZhuTuXiYong(CombatSkillKey skillKey)
		: base(skillKey)
	{
	}

	public override void OnEnable(DataContext context)
	{
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 69, -1), EDataModifyType.AddPercent);
		Events.RegisterHandler_CombatBegin(OnCombatBegin);
		Events.RegisterHandler_DistanceChanged(OnDistanceChanged);
		Events.RegisterHandler_MoveEnd(OnMoveEnd);
		Events.RegisterHandler_NormalAttackAllEnd(OnNormalAttackAllEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CombatBegin(OnCombatBegin);
		Events.UnRegisterHandler_DistanceChanged(OnDistanceChanged);
		Events.UnRegisterHandler_MoveEnd(OnMoveEnd);
		Events.UnRegisterHandler_NormalAttackAllEnd(OnNormalAttackAllEnd);
	}

	private void OnCombatBegin(DataContext context)
	{
		_inAttackRange = DomainManager.Combat.InAttackRange(base.CombatChar);
		if (!_inAttackRange)
		{
			EnableJumpMove();
		}
	}

	private void OnDistanceChanged(DataContext context, CombatCharacter mover, short distance, bool isMove, bool isForced)
	{
		bool newInAttackRange = DomainManager.Combat.InAttackRange(base.CombatChar);
		if (_inAttackRange != newInAttackRange)
		{
			_inAttackRange = newInAttackRange;
			if (_inAttackRange)
			{
				DisableJumpMove(context);
			}
			else
			{
				EnableJumpMove();
			}
		}
	}

	private void OnMoveEnd(DataContext context, CombatCharacter mover, int distance, bool isJump)
	{
		if (mover.GetId() == base.CharacterId && isJump)
		{
			DomainManager.Combat.ChangeMobilityValue(context, mover, -MoveSpecialConstants.MaxMobility * CostMobilityPercent);
			if (DomainManager.Combat.InAttackRange(base.CombatChar) && base.IsCurrent)
			{
				_isAffecting = true;
				base.CombatChar.NormalAttackFree();
				ShowSpecialEffectTips(1);
			}
		}
	}

	private void OnNormalAttackAllEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender)
	{
		if (attacker.GetId() == base.CharacterId)
		{
			_isAffecting = false;
		}
	}

	private void EnableJumpMove()
	{
		if (base.IsCurrent)
		{
			ShowSpecialEffectTips(0);
		}
		DomainManager.Combat.EnableJumpMove(base.CombatChar, base.SkillTemplateId);
	}

	private void DisableJumpMove(DataContext context)
	{
		DomainManager.Combat.DisableJumpMove(context, base.CombatChar, base.SkillTemplateId);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.FieldId != 69 || !_isAffecting)
		{
			return 0;
		}
		return AddDamagePercent;
	}
}
