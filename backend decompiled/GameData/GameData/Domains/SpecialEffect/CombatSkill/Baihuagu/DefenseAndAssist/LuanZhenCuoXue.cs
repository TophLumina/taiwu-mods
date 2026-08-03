using System.Collections.Generic;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Assist;

namespace GameData.Domains.SpecialEffect.CombatSkill.Baihuagu.DefenseAndAssist;

public class LuanZhenCuoXue : AssistSkillBase
{
	private readonly List<sbyte> _bodyPartRandomPool = new List<sbyte>();

	private bool _affecting;

	private sbyte _bodyPart = -1;

	private CombatCharacter _reverseEnemyChar;

	private sbyte _reverseLevel;

	public LuanZhenCuoXue()
	{
	}

	public LuanZhenCuoXue(CombatSkillKey skillKey)
		: base(skillKey, 3603)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		_affecting = false;
		if (base.IsDirect)
		{
			Events.RegisterHandler_AcuPointRemoved(OnAcuPointRemoved);
		}
		else
		{
			Events.RegisterHandler_AcuPointAdded(OnAcupointAdded);
		}
		Events.RegisterHandler_CombatStateMachineUpdateEnd(OnStateMachineUpdateEnd);
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		if (base.IsDirect)
		{
			Events.UnRegisterHandler_AcuPointRemoved(OnAcuPointRemoved);
		}
		else
		{
			Events.UnRegisterHandler_AcuPointAdded(OnAcupointAdded);
		}
		Events.UnRegisterHandler_CombatStateMachineUpdateEnd(OnStateMachineUpdateEnd);
	}

	private void OnAcuPointRemoved(DataContext context, CombatCharacter combatChar, sbyte bodyPart, sbyte level)
	{
		if (combatChar == base.CombatChar && !_affecting && base.CanAffect)
		{
			_bodyPart = bodyPart;
		}
	}

	private void OnAcupointAdded(DataContext context, CombatCharacter combatChar, sbyte bodyPart, sbyte level)
	{
		if (combatChar.IsAlly != base.CombatChar.IsAlly && !_affecting && base.CanAffect && DomainManager.Combat.IsCurrentCombatCharacter(base.CombatChar) && base.CombatChar.TeammateBeforeMainChar < 0)
		{
			_bodyPart = bodyPart;
			_reverseEnemyChar = combatChar;
			_reverseLevel = level;
		}
	}

	private void OnStateMachineUpdateEnd(DataContext context, CombatCharacter combatChar)
	{
		if (combatChar.GetId() != base.CharacterId || _bodyPart < 0)
		{
			return;
		}
		CombatCharacter targetChar = (base.IsDirect ? base.CombatChar : _reverseEnemyChar);
		byte[] acupointCount = targetChar.GetAcupointCount();
		int maxCount = (base.IsDirect ? (-1) : _reverseEnemyChar.GetMaxAcupointCount());
		_bodyPartRandomPool.Clear();
		foreach (sbyte part in targetChar.GetAvailableBodyParts())
		{
			if (part != _bodyPart && (base.IsDirect ? (acupointCount[part] > 0) : (acupointCount[part] < maxCount)))
			{
				_bodyPartRandomPool.Add(part);
			}
		}
		if (_bodyPartRandomPool.Count > 0)
		{
			sbyte part2 = _bodyPartRandomPool[context.Random.Next(0, _bodyPartRandomPool.Count)];
			_affecting = true;
			if (base.IsDirect)
			{
				DomainManager.Combat.RemoveAcupoint(context, base.CombatChar, part2, 0);
			}
			else
			{
				DomainManager.Combat.AddAcupoint(context, _reverseEnemyChar, _reverseLevel, new CombatSkillKey(-1, -1), part2);
			}
			_affecting = false;
			ShowSpecialEffectTips(0);
		}
		_bodyPart = -1;
	}
}
