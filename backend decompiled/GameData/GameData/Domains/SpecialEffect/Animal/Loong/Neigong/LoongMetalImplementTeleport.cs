using System;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.SpecialEffect.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Implement;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.Animal.Loong.Neigong;

public class LoongMetalImplementTeleport : ISpecialEffectImplement, ISpecialEffectModifier
{
	private const int MoveRangeDelta = 10;

	private static readonly CValuePercent MinMobilityPercent = 50;

	private bool _affecting;

	private bool _teleporting;

	public CombatSkillEffectBase EffectBase { get; set; }

	public void OnEnable(DataContext context)
	{
		EffectBase.CreateAffectedData(157, EDataModifyType.Custom, -1);
		Events.RegisterHandler_AddDirectDamageValue(AddDirectDamageValue);
		Events.RegisterHandler_NormalAttackPrepareEnd(OnNormalAttackPrepareEnd);
		Events.RegisterHandler_NormalAttackAllEnd(OnNormalAttackAllEnd);
		Events.RegisterHandler_PrepareSkillEnd(OnPrepareSkillEnd);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_AddDirectDamageValue(AddDirectDamageValue);
		Events.UnRegisterHandler_NormalAttackPrepareEnd(OnNormalAttackPrepareEnd);
		Events.UnRegisterHandler_NormalAttackAllEnd(OnNormalAttackAllEnd);
		Events.UnRegisterHandler_PrepareSkillEnd(OnPrepareSkillEnd);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void AddDirectDamageValue(DataContext context, int attackerId, int defenderId, sbyte bodyPart, bool isInner, int damageValue, short combatSkillId)
	{
		if (defenderId == EffectBase.CharacterId && damageValue != 0)
		{
			_affecting = true;
		}
	}

	private void OnNormalAttackPrepareEnd(DataContext context, int charId, bool isAlly)
	{
		_affecting = false;
	}

	private void OnNormalAttackAllEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender)
	{
		DoTeleport(context);
	}

	private void OnPrepareSkillEnd(DataContext context, int charId, bool isAlly, short skillId)
	{
		_affecting = false;
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		DoTeleport(context);
	}

	private void DoTeleport(DataContext context)
	{
		(byte min, byte max) moveRange;
		OuterAndInnerShorts enemyAttackRange;
		if (_affecting)
		{
			_affecting = false;
			if (EffectBase.CombatChar.GetMobilityValue() >= MoveSpecialConstants.MaxMobility * MinMobilityPercent)
			{
				moveRange = DomainManager.Combat.GetDistanceRange();
				CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!EffectBase.CombatChar.IsAlly);
				enemyAttackRange = enemyChar.GetAttackRange();
				int forwardSpace = Math.Abs(moveRange.min - enemyAttackRange.Outer);
				int backwardSpace = Math.Abs(moveRange.max - enemyAttackRange.Inner);
				int targetDistance = ((forwardSpace < backwardSpace) ? BackwardDistance() : ((forwardSpace <= backwardSpace) ? (context.Random.CheckPercentProb(50) ? ForwardDistance() : BackwardDistance()) : ForwardDistance()));
				int addDistance = targetDistance - DomainManager.Combat.GetCurrentDistance();
				_teleporting = true;
				DomainManager.Combat.ChangeDistance(context, EffectBase.CombatChar, addDistance, isForced: false, canStop: false);
				_teleporting = false;
				EffectBase.ShowSpecialEffectTips(0);
			}
		}
		int BackwardDistance()
		{
			return Math.Min(moveRange.max, enemyAttackRange.Inner + 10);
		}
		int ForwardDistance()
		{
			return Math.Max(moveRange.max, enemyAttackRange.Outer - 10);
		}
	}

	public bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.CharId != EffectBase.CharacterId || dataKey.FieldId != 157)
		{
			return dataValue;
		}
		return !_teleporting && dataValue;
	}
}
