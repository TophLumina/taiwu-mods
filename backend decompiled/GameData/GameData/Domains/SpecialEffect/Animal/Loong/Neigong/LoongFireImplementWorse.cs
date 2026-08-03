using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.SpecialEffect.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Implement;

namespace GameData.Domains.SpecialEffect.Animal.Loong.Neigong;

public class LoongFireImplementWorse : ISpecialEffectImplement, ISpecialEffectModifier
{
	private readonly CValuePercent _worsenPercent;

	public CombatSkillEffectBase EffectBase { get; set; }

	public LoongFireImplementWorse(CValuePercent worsenPercent)
	{
		_worsenPercent = worsenPercent;
	}

	public void OnEnable(DataContext context)
	{
		Events.RegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
	}

	public void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
	}

	private void OnNormalAttackEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender, sbyte trickType, int pursueIndex, bool hit, bool isFightback)
	{
		if (!(attacker.GetId() != EffectBase.CharacterId || isFightback) && hit && pursueIndex <= 0)
		{
			sbyte bodyPart = attacker.NormalAttackBodyPart;
			if (bodyPart >= 0 && bodyPart < 7)
			{
				defender.WorsenInjury(context, bodyPart, inner: true, _worsenPercent);
				defender.WorsenInjury(context, bodyPart, inner: false, _worsenPercent);
				EffectBase.ShowSpecialEffectTips(0);
			}
		}
	}
}
