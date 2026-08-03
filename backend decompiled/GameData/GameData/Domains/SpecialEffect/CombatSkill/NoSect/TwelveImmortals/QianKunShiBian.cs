using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.NoSect.TwelveImmortals;

public class QianKunShiBian : TwelveImmortalsTrickBase
{
	private int _changingAttackRange;

	public QianKunShiBian()
	{
	}

	public QianKunShiBian(CombatSkillKey skillKey)
		: base(skillKey, 18003)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_CombatBegin(OnCombatBegin);
		Events.RegisterHandler_CombatStateMachineUpdateEnd(OnCombatStateMachineUpdateEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CombatBegin(OnCombatBegin);
		Events.UnRegisterHandler_CombatStateMachineUpdateEnd(OnCombatStateMachineUpdateEnd);
		base.OnDisable(context);
	}

	private void OnCombatBegin(DataContext context)
	{
		AppendAffectedData(context, 145, EDataModifyType.Add, -1);
		AppendAffectedData(context, 146, EDataModifyType.Add, -1);
		AppendAffectedAllEnemyData(context, 145, EDataModifyType.Add, -1);
		AppendAffectedAllEnemyData(context, 146, EDataModifyType.Add, -1);
	}

	private void OnCombatStateMachineUpdateEnd(DataContext context, CombatCharacter combatChar)
	{
		if (base.IsDirect && combatChar.IsAlly == base.CombatChar.IsAlly && !DomainManager.Combat.Pause)
		{
			int value = base.CombatChar.GetDefeatMarkCollection().MindMarkList?.Count ?? 0;
			value += base.EnemyChar.GetDefeatMarkCollection().MindMarkList?.Count ?? 0;
			if (value != _changingAttackRange)
			{
				_changingAttackRange = value;
				InvalidateAllAffectDataCache(context);
			}
		}
	}

	protected override void OnReverseEffectChanged(DataContext context)
	{
		_changingAttackRange = base.ReverseEffectUnit;
		InvalidateAllAffectDataCache(context);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId && !base.IsDirect)
		{
			return base.GetModifyValue(dataKey, currModifyValue);
		}
		return (dataKey.CharId == base.CharacterId) ? _changingAttackRange : (-_changingAttackRange);
	}
}
