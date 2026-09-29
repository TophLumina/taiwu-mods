using System.Collections.Generic;
using System.Linq;
using GameData.Combat.Chicken;
using GameData.Common;
using GameData.Domains.Combat.Chicken;
using GameData.GameDataBridge;

namespace GameData.Domains.Combat;

public class CombatCharacterStateSmarterChicken : CombatCharacterStateBase
{
	private readonly List<(sbyte type, int totalPoint)> _effects = new List<(sbyte, int)>();

	private bool _finished;

	public CombatCharacterStateSmarterChicken(CombatDomain combatDomain, CombatCharacter combatChar)
		: base(combatDomain, combatChar, CombatCharacterStateType.SmarterChicken)
	{
		IsUpdateOnPause = true;
	}

	public override void OnEnter()
	{
		base.OnEnter();
		DataContext context = CombatChar.GetDataContext();
		IReadOnlyList<int> selectedPointIds = CombatChar.GetCombatReserveData().SmarterChickenIds;
		CombatChar.SetCombatReserveData(CombatReserveData.Invalid, context);
		if (selectedPointIds == null || selectedPointIds.Count <= 0 || selectedPointIds.Any(IsInvalidChickenPointId))
		{
			CombatChar.StateMachine.TranslateState();
			return;
		}
		ChickenPointZones chickenPointZones = DomainManager.Combat.GetChickenPointZones();
		ChickenPointInvokeResult result = ChickenPointHelper.InvokePoints(context.Random, selectedPointIds, chickenPointZones, ExecuteChickenEffects);
		if (result.Success)
		{
			DomainManager.Combat.SetChickenPointZones(chickenPointZones, context);
			ChickenInvokeResultDto dto = (ChickenInvokeResultDto)result;
			GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.CombatShowChickenInvokeResult, dto);
		}
		else
		{
			CombatChar.StateMachine.TranslateState();
		}
	}

	public override bool OnUpdate()
	{
		if (!base.OnUpdate())
		{
			return false;
		}
		if (_finished)
		{
			CombatChar.StateMachine.TranslateState();
		}
		_finished = false;
		return false;
	}

	private bool IsInvalidChickenPointId(int id)
	{
		return !DomainManager.Combat.GetChickenPointZones().CurrentContains(id);
	}

	private void ExecuteChickenEffects(sbyte type, int totalPoint)
	{
		_effects.Add((type, totalPoint));
	}

	public void ApplyEffect(DataContext context)
	{
		foreach (var (type, totalPoint) in _effects)
		{
			DomainManager.Combat.ExecuteChickenEffect(context, type, totalPoint);
		}
		_effects.Clear();
	}

	public void FinishState()
	{
		_finished = true;
	}
}
