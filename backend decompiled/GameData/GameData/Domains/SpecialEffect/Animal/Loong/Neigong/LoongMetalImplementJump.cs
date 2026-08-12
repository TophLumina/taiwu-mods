using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.SpecialEffect.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Implement;

namespace GameData.Domains.SpecialEffect.Animal.Loong.Neigong;

public class LoongMetalImplementJump : ISpecialEffectImplement, ISpecialEffectModifier
{
	public CombatSkillEffectBase EffectBase { get; set; }

	public void OnEnable(DataContext context)
	{
		Events.RegisterHandler_CombatBegin(OnCombatBegin);
	}

	public void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CombatBegin(OnCombatBegin);
	}

	private void OnCombatBegin(DataContext context)
	{
		DomainManager.Combat.EnableJumpMove(EffectBase.CombatChar, EffectBase.SkillTemplateId);
	}
}
