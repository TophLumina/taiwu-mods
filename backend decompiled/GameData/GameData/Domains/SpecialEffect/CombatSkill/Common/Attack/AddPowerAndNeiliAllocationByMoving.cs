using System;
using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

public class AddPowerAndNeiliAllocationByMoving : CombatSkillEffectBase
{
	protected byte AddNeiliAllocationType;

	private short _movedDist;

	private short _addPower;

	protected static sbyte MoveDistInPrepare => 40;

	protected static sbyte AffectDistanceUnit => 2;

	protected virtual sbyte AddPowerUnit => 5;

	protected virtual int MoveCostMobilityAddPercent => 0;

	protected virtual sbyte AddNeiliAllocationUnit => 3;

	protected AddPowerAndNeiliAllocationByMoving()
	{
	}

	protected AddPowerAndNeiliAllocationByMoving(CombatSkillKey skillKey, int type)
		: base(skillKey, type, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		DomainManager.Combat.AddMoveDistInSkillPrepare(base.CombatChar, MoveDistInPrepare, base.IsDirect);
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 199, base.SkillTemplateId), EDataModifyType.AddPercent);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 175, -1), EDataModifyType.AddPercent);
		Events.RegisterHandler_DistanceChanged(OnDistanceChanged);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_DistanceChanged(OnDistanceChanged);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnDistanceChanged(DataContext context, CombatCharacter mover, short distance, bool isMove, bool isForced)
	{
		if (mover.GetId() != base.CharacterId || !isMove || (base.IsDirect ? (distance > 0) : (distance < 0)))
		{
			return;
		}
		int prevUnit = Math.Abs(_movedDist) / AffectDistanceUnit;
		_movedDist += distance;
		int currUnit = Math.Abs(_movedDist) / AffectDistanceUnit;
		if (prevUnit != currUnit)
		{
			_addPower = (short)(currUnit * AddPowerUnit);
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 199);
			ShowSpecialEffectTips(0);
			int unit = currUnit - prevUnit;
			for (int i = 0; i < unit; i++)
			{
				OnDistanceChangedAddNeiliAllocation(context);
			}
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			RemoveSelf(context);
		}
	}

	protected virtual void OnDistanceChangedAddNeiliAllocation(DataContext context)
	{
		base.CombatChar.ChangeNeiliAllocation(context, AddNeiliAllocationType, AddNeiliAllocationUnit);
		ShowSpecialEffectTips(1);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return 0;
		}
		if (dataKey.FieldId == 175)
		{
			return MoveCostMobilityAddPercent;
		}
		if (dataKey.CombatSkillId != base.SkillTemplateId)
		{
			return 0;
		}
		if (dataKey.FieldId == 199)
		{
			return _addPower;
		}
		return 0;
	}
}
