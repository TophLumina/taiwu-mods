using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.SpecialEffect.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Implement;

namespace GameData.Domains.SpecialEffect.Animal.Loong.Neigong;

public class LoongWoodImplementHeal : ISpecialEffectImplement, ISpecialEffectModifier
{
	private const short NewInjuryAutoHealSpeed = 2;

	private const short OldInjuryAutoHealSpeed = 1;

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
		CombatCharacter combatChar = EffectBase.CombatChar;
		combatChar.InnerInjuryAutoHealSpeeds.Add(2);
		combatChar.OuterInjuryAutoHealSpeeds.Add(2);
		combatChar.InnerOldInjuryAutoHealSpeeds.Add(1);
		combatChar.OuterOldInjuryAutoHealSpeeds.Add(1);
	}
}
