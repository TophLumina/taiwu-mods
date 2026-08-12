using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

public class AddOrReduceNeiliAllocation : CombatSkillEffectBase
{
	protected byte AffectNeiliAllocationType;

	protected virtual sbyte NeiliAllocationChange => 2;

	public AddOrReduceNeiliAllocation()
	{
	}

	public AddOrReduceNeiliAllocation(CombatSkillKey skillKey, int type)
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

	protected virtual void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			if (PowerMatchAffectRequire(power))
			{
				CombatCharacter combatChar = (base.IsDirect ? base.CombatChar : DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly, tryGetCoverCharacter: true));
				combatChar.ChangeNeiliAllocation(context, AffectNeiliAllocationType, base.IsDirect ? NeiliAllocationChange : (-NeiliAllocationChange));
				ShowSpecialEffectTips(0);
			}
			RemoveSelf(context);
		}
	}
}
