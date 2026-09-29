using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Neigong.Boss;

public class QunXianDianKui : BossNeigongBase
{
	private const int RequireDefeatMarkCount = 108;

	private const int RequireBreakBodyPartCount = 6;

	private bool _canAffect;

	public QunXianDianKui()
	{
	}

	public QunXianDianKui(CombatSkillKey skillKey)
		: base(skillKey, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(281, EDataModifyType.Custom, -1);
		Events.RegisterHandler_CombatStateMachineUpdateEnd(OnCombatStateMachineUpdateEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CombatStateMachineUpdateEnd(OnCombatStateMachineUpdateEnd);
		base.OnDisable(context);
	}

	private void OnCombatStateMachineUpdateEnd(DataContext context, CombatCharacter combatChar)
	{
		if (combatChar == base.CombatChar)
		{
			UpdateCanAffect();
		}
	}

	private void UpdateCanAffect()
	{
		bool canAffect = base.CombatChar.GetDefeatMarkCollection().GetTotalCount() < 108 && base.CombatChar.CalcBreakBodyPartCount() < 6 && base.CombatChar.GetBossPhase() > 0;
		if (canAffect != _canAffect)
		{
			bool needUpdate = _canAffect;
			_canAffect = canAffect;
			if (needUpdate)
			{
				DomainManager.Combat.AddToCheckFallenSet(base.CharacterId);
			}
		}
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.CharId == base.CharacterId && dataKey.FieldId == 281)
		{
			return dataValue || _canAffect;
		}
		return base.GetModifiedValue(dataKey, dataValue);
	}
}
