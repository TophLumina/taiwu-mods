using System;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wudangpai.Agile;

public class TianGangBeiDouBu : AgileSkillBase
{
	private const sbyte RequireMoveDistance = 10;

	private const sbyte AddNeiliAllocationPercent = 10;

	private int _distanceAccumulator;

	private int _addedNeiliAllocation;

	public TianGangBeiDouBu()
	{
	}

	public TianGangBeiDouBu(CombatSkillKey skillKey)
		: base(skillKey, 4403)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		_distanceAccumulator = 0;
		_addedNeiliAllocation = 0;
		Events.RegisterHandler_DistanceChanged(OnDistanceChanged);
		Events.RegisterHandler_NeiliAllocationChanged(OnNeiliAllocationChanged);
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		if (DomainManager.Combat.IsInCombat())
		{
			base.CombatChar.ChangeNeiliAllocation(context, 1, -_addedNeiliAllocation);
		}
		Events.UnRegisterHandler_DistanceChanged(OnDistanceChanged);
		Events.UnRegisterHandler_NeiliAllocationChanged(OnNeiliAllocationChanged);
	}

	private unsafe void OnDistanceChanged(DataContext context, CombatCharacter mover, short distance, bool isMove, bool isForced)
	{
		if (mover != base.CombatChar || !isMove || isForced)
		{
			return;
		}
		_distanceAccumulator += Math.Abs(distance);
		while (_distanceAccumulator >= 10)
		{
			_distanceAccumulator -= 10;
			if (base.CanAffect)
			{
				byte srcType = (byte)((!base.IsDirect) ? 2 : 0);
				NeiliAllocation neiliAllocation = base.CombatChar.GetNeiliAllocation();
				int addValue = neiliAllocation.Items[(int)srcType] * 10 / 100;
				if (addValue != 0)
				{
					int oldValue = neiliAllocation.Items[1];
					base.CombatChar.ChangeNeiliAllocation(context, 1, addValue);
					neiliAllocation = base.CombatChar.GetNeiliAllocation();
					_addedNeiliAllocation += Math.Max(neiliAllocation.Items[1] - oldValue, 0);
					ShowSpecialEffectTips(0);
				}
			}
		}
	}

	private void OnNeiliAllocationChanged(DataContext context, int charId, byte type, int changeValue)
	{
		if (charId == base.CharacterId && type == 1 && changeValue < 0 && _addedNeiliAllocation > 0)
		{
			_addedNeiliAllocation = Math.Max(_addedNeiliAllocation + changeValue, 0);
		}
	}
}
