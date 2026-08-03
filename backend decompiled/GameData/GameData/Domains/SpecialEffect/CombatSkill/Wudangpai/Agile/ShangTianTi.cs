using System;
using System.Collections.Generic;
using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wudangpai.Agile;

public class ShangTianTi : AgileSkillBase
{
	private const sbyte RequireMoveDistance = 5;

	private const int MaxUnit = 4;

	private const sbyte AddPowerUnit = 10;

	private int _distanceAccumulator;

	private int _addPower;

	private static int MaxAddPower => 40;

	public ShangTianTi()
	{
	}

	public ShangTianTi(CombatSkillKey skillKey)
		: base(skillKey, 4405)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		_distanceAccumulator = 0;
		_addPower = 0;
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 199, -1), EDataModifyType.AddPercent);
		Events.RegisterHandler_DistanceChanged(OnDistanceChanged);
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		Events.UnRegisterHandler_DistanceChanged(OnDistanceChanged);
	}

	private void OnDistanceChanged(DataContext context, CombatCharacter mover, short distance, bool isMove, bool isForced)
	{
		if (mover != base.CombatChar || !isMove || isForced || distance == 0)
		{
			return;
		}
		if (base.IsDirect ? (distance < 0) : (distance > 0))
		{
			_distanceAccumulator += Math.Abs(distance);
			bool powerChanged = false;
			while (_distanceAccumulator >= 5)
			{
				_distanceAccumulator -= 5;
				if (_addPower < MaxAddPower && base.CanAffect)
				{
					_addPower += 10;
					powerChanged = true;
				}
			}
			if (powerChanged)
			{
				DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 199);
				ShowSpecialEffectTips(0);
			}
		}
		else
		{
			_distanceAccumulator = 0;
			_addPower = 0;
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 199);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || Config.CombatSkill.Instance[dataKey.CombatSkillId].EquipType != 1)
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
