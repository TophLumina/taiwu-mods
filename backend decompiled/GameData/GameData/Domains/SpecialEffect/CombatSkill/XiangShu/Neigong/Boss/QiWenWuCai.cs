using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Neigong.Boss;

public class QiWenWuCai : BossNeigongBase
{
	private sbyte AddNeiliAllocationFrame = 60;

	private int _frameCounter;

	public QiWenWuCai()
	{
	}

	public QiWenWuCai(CombatSkillKey skillKey)
		: base(skillKey, 16103)
	{
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		Events.UnRegisterHandler_CombatStateMachineUpdateEnd(OnStateMachineUpdateEnd);
	}

	protected override void ActivePhase2Effect(DataContext context)
	{
		AppendAffectedData(context, base.CharacterId, 114, EDataModifyType.Custom, -1);
		Events.RegisterHandler_CombatStateMachineUpdateEnd(OnStateMachineUpdateEnd);
	}

	private void OnStateMachineUpdateEnd(DataContext context, CombatCharacter combatChar)
	{
		if (base.CombatChar != combatChar || DomainManager.Combat.Pause)
		{
			return;
		}
		_frameCounter++;
		if (_frameCounter >= AddNeiliAllocationFrame)
		{
			_frameCounter = 0;
			for (byte type = 0; type < 4; type++)
			{
				base.CombatChar.ChangeNeiliAllocation(context, type, 1);
			}
		}
	}

	public unsafe override long GetModifiedValue(AffectedDataKey dataKey, long dataValue)
	{
		EDamageType damageType = (EDamageType)dataKey.CustomParam0;
		if (dataKey.CharId != base.CharacterId || damageType != EDamageType.Direct)
		{
			return dataValue;
		}
		NeiliAllocation selfNeiliAllocation = base.CombatChar.GetNeiliAllocation();
		NeiliAllocation enemyNeiliAllocation = base.CurrEnemyChar.GetNeiliAllocation();
		for (byte type = 0; type < 4; type++)
		{
			if (selfNeiliAllocation.Items[(int)type] < enemyNeiliAllocation.Items[(int)type] * 2)
			{
				return dataValue;
			}
		}
		return 0L;
	}
}
