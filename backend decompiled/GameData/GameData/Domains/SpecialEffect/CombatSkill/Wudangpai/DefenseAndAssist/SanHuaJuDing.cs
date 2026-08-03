using System;
using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Assist;
using GameData.GameDataBridge;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wudangpai.DefenseAndAssist;

public class SanHuaJuDing : AssistSkillBase
{
	private const int PowerAddFrame = 30;

	private const int PowerAddUnit = 1;

	private const int SpreadRequirePower = 100;

	private const int SpreadPowerDivisor = 10;

	private DataUid _neiliAllocationUid;

	private bool _affecting;

	private short _originalPower;

	private short _addedPower;

	private int _changingPower;

	private short SelfPower => base.SkillInstance.GetPower();

	public SanHuaJuDing()
	{
	}

	public SanHuaJuDing(CombatSkillKey skillKey)
		: base(skillKey, 4607)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_CombatBegin(OnCombatBegin);
		Events.RegisterHandler_CombatCharChanged(OnCombatCharChanged);
		Events.RegisterHandler_CombatStateMachineUpdateEnd(OnCombatStateMachineUpdateEnd);
		_originalPower = SelfPower;
		_neiliAllocationUid = ParseNeiliAllocationDataUid();
		GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(_neiliAllocationUid, base.DataHandlerKey, OnNeiliAllocationChanged);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CombatBegin(OnCombatBegin);
		Events.UnRegisterHandler_CombatCharChanged(OnCombatCharChanged);
		Events.UnRegisterHandler_CombatStateMachineUpdateEnd(OnCombatStateMachineUpdateEnd);
		GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_neiliAllocationUid, base.DataHandlerKey);
		base.OnDisable(context);
	}

	protected override IEnumerable<int> CalcFrameCounterPeriods()
	{
		yield return 30;
	}

	public override bool IsOn(int counterType)
	{
		return _affecting && _addedPower < _originalPower;
	}

	public override void OnProcess(DataContext context, int counterType)
	{
		_addedPower = (short)Math.Min(_addedPower + 1, _originalPower);
		DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 199);
	}

	private void OnCombatBegin(DataContext context)
	{
		if (base.IsDirect)
		{
			AppendAffectedData(context, 199, EDataModifyType.Custom, -1);
		}
		else
		{
			AppendAffectedData(context, 199, EDataModifyType.Custom, base.SkillTemplateId);
			AppendAffectedAllEnemyData(context, 199, EDataModifyType.Custom, -1);
		}
		OnNeiliAllocationChanged(context, _neiliAllocationUid);
	}

	private void OnCombatCharChanged(DataContext context, bool isAlly)
	{
		if (isAlly == base.CombatChar.IsAlly)
		{
			InvalidateAllEnemyCache(context, 199);
		}
	}

	private void OnCombatStateMachineUpdateEnd(DataContext context, CombatCharacter combatChar)
	{
		if (!DomainManager.Combat.IsCharInCombat(combatChar.GetId()) || combatChar.GetId() != base.CharacterId)
		{
			return;
		}
		int changingPower = ((SelfPower >= 100) ? (SelfPower / 10 * (base.IsDirect ? 1 : (-1))) : 0);
		if (changingPower != _changingPower)
		{
			_changingPower = changingPower;
			if (base.IsDirect)
			{
				InvalidateCache(context, 199);
			}
			else
			{
				InvalidateAllEnemyCache(context, 199);
			}
		}
	}

	private unsafe void OnNeiliAllocationChanged(DataContext context, DataUid dataUid)
	{
		bool allNotLess = true;
		NeiliAllocation originNeiliAllocation = base.CombatChar.GetOriginNeiliAllocation();
		NeiliAllocation currNeiliAllocation = base.CombatChar.GetNeiliAllocation();
		for (int i = 0; i < 4; i++)
		{
			allNotLess = allNotLess && currNeiliAllocation.Items[i] >= originNeiliAllocation.Items[i];
		}
		if (_affecting != allNotLess)
		{
			_affecting = allNotLess;
			SetConstAffecting(context, _affecting);
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 199);
		}
	}

	public override int GetModifiedValue(AffectedDataKey dataKey, int dataValue)
	{
		if (!base.CanAffect || dataKey.FieldId != 199)
		{
			return dataValue;
		}
		if (dataKey.CombatSkillId == base.SkillTemplateId)
		{
			return (dataKey.CharId != base.CharacterId) ? dataValue : (_affecting ? (dataValue + _addedPower) : ((dataValue + _addedPower) / 2));
		}
		if (!base.IsDirect && !base.IsCurrent)
		{
			return dataValue;
		}
		if (base.IsDirect ? (base.CharacterId == dataKey.CharId) : (base.CharacterId != dataKey.CharId))
		{
			return dataValue + _changingPower;
		}
		return dataValue;
	}
}
