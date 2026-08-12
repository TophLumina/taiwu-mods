using System;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Assist;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.DefenseAndAssist;

public class MiChongXiang : AssistSkillBase
{
	private const int StaticPeriodicFrames = 30;

	private const int DynamicPeriodicFrames = 90;

	private static readonly CValuePercent AttainmentReducePercent = 20;

	private int _periodicFrames;

	private int _frameCounter;

	public MiChongXiang()
	{
	}

	public MiChongXiang(CombatSkillKey skillKey)
		: base(skillKey, 12800)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_CombatBegin(OnCombatBegin);
		Events.RegisterHandler_CombatStateMachineUpdateEnd(OnCombatStateMachineUpdateEnd);
	}

	public override void OnDataAdded(DataContext context)
	{
		base.OnDataAdded(context);
		if (base.IsDirect)
		{
			AppendAffectedAllEnemyData(context, 258, EDataModifyType.AddPercent, -1);
		}
		else
		{
			AppendAffectedData(context, base.CharacterId, 258, EDataModifyType.AddPercent, -1);
		}
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		Events.UnRegisterHandler_CombatBegin(OnCombatBegin);
		Events.UnRegisterHandler_CombatStateMachineUpdateEnd(OnCombatStateMachineUpdateEnd);
	}

	private void OnCombatBegin(DataContext context)
	{
		CValuePercent attainmentReducePercent = CharObj.GetLifeSkillAttainment(9) * AttainmentReducePercent;
		_periodicFrames = 30 + Math.Max(0, 90 - 90 * attainmentReducePercent);
		_frameCounter = 0;
	}

	private void OnCombatStateMachineUpdateEnd(DataContext context, CombatCharacter combatChar)
	{
		if (combatChar != base.CombatChar || DomainManager.Combat.Pause)
		{
			return;
		}
		_frameCounter++;
		if (_frameCounter >= _periodicFrames)
		{
			_frameCounter = 0;
			if (base.CombatChar.ChangeWugCount(context, 1))
			{
				ShowSpecialEffectTips(0);
				ShowEffectTips(context);
			}
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.FieldId != 258)
		{
			return 0;
		}
		if (base.IsDirect && !base.IsCurrent)
		{
			return 0;
		}
		short unit = base.CombatChar.GetWugCount();
		if (unit <= 0)
		{
			return 0;
		}
		ShowSpecialEffectTips(1);
		return base.IsDirect ? (unit * 2) : (-unit);
	}
}
