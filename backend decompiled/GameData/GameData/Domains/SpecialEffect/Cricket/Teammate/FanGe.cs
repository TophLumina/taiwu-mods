using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.Domains.SpecialEffect.Cricket.Teammate;

public class FanGe : AutoCollectEffectBase
{
	private const int AddFlawOrAcupointOdds = 33;

	private const int MinLevel = 0;

	private const int MaxLevel = 2;

	private static sbyte RandomFlawOrAcupointLevel(IRandomSource random)
	{
		return (sbyte)random.Next(0, 3);
	}

	public FanGe(int charId)
		: base(charId)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
		Events.RegisterHandler_BounceInjury(OnBounceInjury);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
		Events.UnRegisterHandler_BounceInjury(OnBounceInjury);
		base.OnDisable(context);
	}

	private void OnNormalAttackEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender, sbyte trickType, int pursueIndex, bool hit, bool isFightBack)
	{
		if (isFightBack && hit)
		{
			CombatCharacter mainChar = DomainManager.Combat.GetMainCharacter(base.CombatChar.IsAlly);
			if (mainChar == attacker && context.Random.CheckPercentProb(33))
			{
				sbyte level = RandomFlawOrAcupointLevel(context.Random);
				DomainManager.Combat.AddAcupoint(context, defender, level, CombatSkillKey.Invalid, -1);
			}
		}
	}

	private void OnBounceInjury(DataContext context, int attackerId, int defenderId, bool isAlly, sbyte bodyPart, sbyte outerMarkCount, sbyte innerMarkCount)
	{
		if (DomainManager.Combat.TryGetElement_CombatCharacterDict(defenderId, out var defender))
		{
			CombatCharacter mainChar = DomainManager.Combat.GetMainCharacter(base.CombatChar.IsAlly);
			if (mainChar.GetId() == attackerId && context.Random.CheckPercentProb(33))
			{
				sbyte level = RandomFlawOrAcupointLevel(context.Random);
				DomainManager.Combat.AddFlaw(context, defender, level, CombatSkillKey.Invalid, -1);
			}
		}
	}
}
