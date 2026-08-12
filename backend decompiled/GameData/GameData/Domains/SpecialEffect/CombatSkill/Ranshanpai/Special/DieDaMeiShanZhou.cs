using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Ranshanpai.Special;

public class DieDaMeiShanZhou : CombatSkillEffectBase
{
	private static readonly CValuePercent DirectChangeMobility = -60;

	private static readonly CValuePercent ReverseChangeMobility = 30;

	public DieDaMeiShanZhou()
	{
	}

	public DieDaMeiShanZhou(CombatSkillKey skillKey)
		: base(skillKey, 7300, -1)
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
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			if (PowerMatchAffectRequire(power))
			{
				CombatCharacter affectChar = (base.IsDirect ? base.CurrEnemyChar : base.CombatChar);
				CValuePercent percent = (base.IsDirect ? DirectChangeMobility : ReverseChangeMobility);
				ChangeMobilityValue(context, affectChar, MoveSpecialConstants.MaxMobility * percent);
				ShowSpecialEffectTips(0);
			}
			RemoveSelf(context);
		}
	}
}
