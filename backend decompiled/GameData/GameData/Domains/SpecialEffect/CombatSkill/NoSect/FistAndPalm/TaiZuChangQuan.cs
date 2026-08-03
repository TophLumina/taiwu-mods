using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.NoSect.FistAndPalm;

public class TaiZuChangQuan : CombatSkillEffectBase
{
	public TaiZuChangQuan()
	{
	}

	public TaiZuChangQuan(CombatSkillKey skillKey)
		: base(skillKey, 100, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
		Events.RegisterHandler_CombatSettlement(OnCombatSettlement);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
		Events.UnRegisterHandler_CombatSettlement(OnCombatSettlement);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnCastAttackSkillBegin(DataContext context, CombatCharacter attacker, CombatCharacter defender, short skillId)
	{
		if (attacker == base.CombatChar && skillId == base.SkillTemplateId)
		{
			IsSrcSkillPrepared = true;
		}
	}

	private void OnCombatSettlement(DataContext context, sbyte combatStatus)
	{
		if (IsSrcSkillPrepared && base.CombatChar.IsAlly && combatStatus == 3)
		{
			DomainManager.Combat.AppendEvaluation(32);
			ShowSpecialEffectTipsByDisplayEvent(0);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			CombatCharacter enemyChar = DomainManager.Combat.GetMainCharacter(!base.CombatChar.IsAlly);
			if (!DomainManager.Combat.IsCharacterFallen(enemyChar))
			{
				RemoveSelf(context);
			}
		}
	}
}
