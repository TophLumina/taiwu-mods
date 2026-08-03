using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

public class AddCombatStateBySkillPower : CombatSkillEffectBase
{
	protected sbyte[] StateTypes;

	protected short[] StateIds;

	protected bool[] StateAddToSelf;

	protected sbyte StatePowerUnit;

	protected AddCombatStateBySkillPower()
	{
	}

	protected AddCombatStateBySkillPower(CombatSkillKey skillKey, int type)
		: base(skillKey, type, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			if (power > 0)
			{
				int index = ((!base.IsDirect) ? 1 : 0);
				CombatCharacter combatChar = (StateAddToSelf[index] ? base.CombatChar : base.CurrEnemyChar);
				DomainManager.Combat.AddCombatState(context, combatChar, StateTypes[index], StateIds[index], StatePowerUnit * power / 10);
				ShowSpecialEffectTips(0);
			}
			RemoveSelf(context);
		}
	}
}
