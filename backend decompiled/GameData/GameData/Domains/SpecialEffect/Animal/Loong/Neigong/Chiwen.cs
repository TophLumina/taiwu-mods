using System;
using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.Animal.Loong.Neigong;

public class Chiwen : AnimalEffectBase
{
	private const int AddOrCostBaseValue = 3;

	private static readonly CValuePercent AddOrCostPercent = 25;

	private int _damageAddPercent;

	public Chiwen()
	{
	}

	public Chiwen(CombatSkillKey skillKey)
		: base(skillKey)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(69, EDataModifyType.AddPercent, -1);
		Events.RegisterHandler_NormalAttackCalcHitEnd(OnNormalAttackCalcHitEnd);
		Events.RegisterHandler_NormalAttackAllEnd(OnNormalAttackAllEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_NormalAttackCalcHitEnd(OnNormalAttackCalcHitEnd);
		Events.UnRegisterHandler_NormalAttackAllEnd(OnNormalAttackAllEnd);
		base.OnDisable(context);
	}

	private void OnNormalAttackCalcHitEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender, int pursueIndex, bool hit, bool isFightback, bool isMind)
	{
		if (attacker.GetId() == base.CharacterId && hit && pursueIndex <= 0)
		{
			TryChangeNeiliAllocation(context, attacker, buff: true);
			TryChangeNeiliAllocation(context, defender, buff: false);
		}
	}

	private void OnNormalAttackAllEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender)
	{
		if (attacker.GetId() == base.CharacterId)
		{
			_damageAddPercent = 0;
		}
	}

	private void TryChangeNeiliAllocation(DataContext context, CombatCharacter targetChar, bool buff)
	{
		NeiliAllocation neiliAllocation = targetChar.GetNeiliAllocation();
		NeiliAllocation originNeiliAllocation = targetChar.GetOriginNeiliAllocation();
		List<byte> neiliAllocationTypes = ObjectPool<List<byte>>.Instance.Get();
		for (byte i = 0; i < 4; i++)
		{
			if (!(buff ? (neiliAllocation[i] >= originNeiliAllocation[i]) : (neiliAllocation[i] <= originNeiliAllocation[i])))
			{
				neiliAllocationTypes.Add(i);
			}
		}
		if (neiliAllocationTypes.Count > 0)
		{
			byte type = neiliAllocationTypes.GetRandom(context.Random);
			int changeValue = (3 + neiliAllocation[type] * AddOrCostPercent) * (buff ? 1 : (-1));
			changeValue = targetChar.ChangeNeiliAllocation(context, type, changeValue, applySpecialEffect: true, raiseEvent: false, applyChallengeModeQiDisorder: false);
			_damageAddPercent += Math.Abs(changeValue);
			ShowSpecialEffectTips(buff, 1, 0);
		}
		ObjectPool<List<byte>>.Instance.Return(neiliAllocationTypes);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.FieldId != 69 || _damageAddPercent <= 0)
		{
			return 0;
		}
		ShowSpecialEffectTipsOnceInFrame(2);
		return _damageAddPercent;
	}
}
