using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

public abstract class PowerUpByPoison : PowerUpOnCast
{
	private const sbyte AddPowerUnit = 20;

	private const int StatePowerUnit = 20;

	protected override EDataModifyType ModifyType => EDataModifyType.AddPercent;

	protected abstract sbyte RequirePoisonType { get; }

	protected abstract short DirectStateId { get; }

	protected abstract short ReverseStateId { get; }

	protected PowerUpByPoison()
	{
	}

	protected PowerUpByPoison(CombatSkillKey skillKey, int type)
		: base(skillKey, type)
	{
	}

	public override void OnEnable(DataContext context)
	{
		CombatCharacter combatChar = (base.IsDirect ? DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly, tryGetCoverCharacter: true) : base.CombatChar);
		PowerUpValue = 20 * combatChar.GetDefeatMarkCollection().PoisonMarkList[RequirePoisonType];
		base.OnEnable(context);
	}

	protected override void OnCastSelf(DataContext context, sbyte power, bool interrupted)
	{
		int statePower = power / 10 * 20;
		if (statePower > 0)
		{
			CombatCharacter stateChar = (base.IsDirect ? base.EnemyChar : base.CombatChar);
			short stateId = (base.IsDirect ? DirectStateId : ReverseStateId);
			sbyte stateType = (sbyte)((!base.IsDirect) ? 1 : 2);
			DomainManager.Combat.AddCombatState(context, stateChar, stateType, stateId, statePower);
			ShowSpecialEffectTips(1);
		}
	}
}
