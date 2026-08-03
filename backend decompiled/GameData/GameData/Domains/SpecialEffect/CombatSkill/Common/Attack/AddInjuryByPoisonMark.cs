using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

public class AddInjuryByPoisonMark : CombatSkillEffectBase
{
	private const sbyte AddFlawOrAcupointLevel = 1;

	protected sbyte RequirePoisonType;

	protected bool IsInnerInjury;

	protected virtual bool AlsoAddFlaw => false;

	protected virtual bool AlsoAddAcupoint => false;

	protected AddInjuryByPoisonMark()
	{
	}

	protected AddInjuryByPoisonMark(CombatSkillKey skillKey, int type)
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
		if (charId != base.CharacterId || skillId != base.SkillTemplateId)
		{
			return;
		}
		if (PowerMatchAffectRequire(power))
		{
			CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly, tryGetCoverCharacter: true);
			byte poisonMarkCount = (base.IsDirect ? enemyChar : base.CombatChar).GetDefeatMarkCollection().PoisonMarkList[RequirePoisonType];
			if (poisonMarkCount > 0)
			{
				AddPowerDamageInjury(context, enemyChar, IsInnerInjury, poisonMarkCount);
				if (AlsoAddFlaw)
				{
					DomainManager.Combat.AddFlaw(context, enemyChar, 1, SkillKey, -1, poisonMarkCount);
				}
				if (AlsoAddAcupoint)
				{
					DomainManager.Combat.AddAcupoint(context, enemyChar, 1, SkillKey, -1, poisonMarkCount);
				}
				ShowSpecialEffectTips(0);
				ShowSpecialEffectTips(1);
			}
		}
		RemoveSelf(context);
	}
}
