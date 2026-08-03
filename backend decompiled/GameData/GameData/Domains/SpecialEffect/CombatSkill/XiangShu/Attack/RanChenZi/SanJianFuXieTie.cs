using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.RanChenZi;

public class SanJianFuXieTie : CombatSkillEffectBase
{
	public SanJianFuXieTie()
	{
	}

	public SanJianFuXieTie(CombatSkillKey skillKey)
		: base(skillKey, 17132, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		sbyte taskStatus = DomainManager.World.GetElement_XiangshuAvatarTaskStatuses(1).JuniorXiangshuTaskStatus;
		if (taskStatus > 4)
		{
			bool goodEnding = taskStatus == 6;
			if (goodEnding)
			{
				DomainManager.Combat.RemoveAllFlaw(context, base.CurrEnemyChar);
			}
			else
			{
				DomainManager.Combat.AddFlaw(context, base.CurrEnemyChar, 3, SkillKey, -1);
			}
			ShowSpecialEffectTips(goodEnding, 1, 2);
		}
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
			if (PowerMatchAffectRequire(power))
			{
				CombatCharacter enemyChar = base.CurrEnemyChar;
				ChangeMobilityValue(context, enemyChar, -enemyChar.GetMobilityValue());
				ClearAffectingAgileSkill(context, enemyChar);
				ChangeBreathValue(context, enemyChar, -30000);
				ChangeStanceValue(context, enemyChar, -4000);
				ShowSpecialEffectTips(0);
			}
			RemoveSelf(context);
		}
	}
}
