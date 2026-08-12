using GameData.Common;

namespace GameData.Domains.SpecialEffect.CombatSkill.Common.Implement;

public interface ISpecialEffectImplement : ISpecialEffectModifier
{
	CombatSkillEffectBase EffectBase { get; set; }

	void OnEnable(DataContext context);

	void OnDisable(DataContext context);
}
