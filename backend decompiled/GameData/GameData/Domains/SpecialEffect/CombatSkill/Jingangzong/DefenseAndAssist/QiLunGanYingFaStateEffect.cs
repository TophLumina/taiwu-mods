using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jingangzong.DefenseAndAssist;

public class QiLunGanYingFaStateEffect
{
	private const int ChangeNeiliAllocationUnit = 1;

	private const int StateAffectFrame = 240;

	private bool _affecting;

	private int _setupCount;

	private readonly Dictionary<int, int> _buffAffectingCounter = new Dictionary<int, int>();

	private readonly Dictionary<int, int> _debuffAffectingCounter = new Dictionary<int, int>();

	public void Setup()
	{
		_setupCount++;
		UpdateAffecting();
	}

	public void Close()
	{
		_setupCount--;
		UpdateAffecting();
	}

	public void Reset()
	{
		if (_affecting)
		{
			Events.UnRegisterHandler_CombatStateMachineUpdateEnd(OnCombatStateMachineUpdateEnd);
		}
		_affecting = false;
		_setupCount = 0;
	}

	private void UpdateAffecting()
	{
		bool affecting = _setupCount > 0;
		if (affecting != _affecting)
		{
			_affecting = affecting;
			if (affecting)
			{
				Events.RegisterHandler_CombatStateMachineUpdateEnd(OnCombatStateMachineUpdateEnd);
			}
			else
			{
				Events.UnRegisterHandler_CombatStateMachineUpdateEnd(OnCombatStateMachineUpdateEnd);
			}
		}
	}

	private void OnCombatStateMachineUpdateEnd(DataContext context, CombatCharacter combatChar)
	{
		if (!DomainManager.Combat.Pause)
		{
			DoAffect(context, combatChar, buff: true);
			DoAffect(context, combatChar, buff: false);
		}
	}

	private void DoAffect(DataContext context, CombatCharacter affectChar, bool buff)
	{
		sbyte stateType = (sbyte)(buff ? 1 : 2);
		short stateId = (short)(buff ? 166 : 167);
		Dictionary<int, int> counter = (buff ? _buffAffectingCounter : _debuffAffectingCounter);
		CValuePercent power = affectChar.GetCombatStatePower(stateType, stateId);
		int changeValue = 1 * power;
		if (changeValue <= 0)
		{
			counter[affectChar.GetId()] = 0;
			return;
		}
		counter[affectChar.GetId()] = counter.GetOrDefault(affectChar.GetId()) + 1;
		if (counter[affectChar.GetId()] == 240)
		{
			counter[affectChar.GetId()] = 0;
			short effectId = (short)(buff ? 1697 : 1698);
			if (affectChar.ChangeNeiliAllocationRandom(context, buff ? changeValue : (-changeValue)))
			{
				DomainManager.Combat.ShowSpecialEffectTips(affectChar.GetId(), effectId, 0);
			}
		}
	}
}
