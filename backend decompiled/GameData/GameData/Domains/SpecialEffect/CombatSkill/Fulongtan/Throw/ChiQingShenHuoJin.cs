using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Fulongtan.Throw;

public class ChiQingShenHuoJin : CombatSkillEffectBase
{
	private const int StatePower = 250;

	public ChiQingShenHuoJin()
	{
	}

	public ChiQingShenHuoJin(CombatSkillKey skillKey)
		: base(skillKey, 14303, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnPrepareSkillBegin(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			DomainManager.Combat.AddCombatState(context, base.CombatChar, 1, (short)(base.IsDirect ? 69 : 71), 250);
			DomainManager.Combat.AddCombatState(context, base.CombatChar, 2, (short)(base.IsDirect ? 70 : 72), 250);
			ShowSpecialEffectTips(0);
			ShowSpecialEffectTips(1);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			RemoveSelf(context);
		}
	}
}
