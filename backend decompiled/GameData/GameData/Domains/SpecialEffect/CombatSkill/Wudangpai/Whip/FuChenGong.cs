using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wudangpai.Whip;

public class FuChenGong : CombatSkillEffectBase
{
	private const sbyte ChangeQiDisorderUnit = 40;

	public FuChenGong()
	{
	}

	public FuChenGong(CombatSkillKey skillKey)
		: base(skillKey, 4300, -1)
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
			if (power > 0)
			{
				DomainManager.Combat.ChangeDisorderOfQiRandomRecovery(context, base.IsDirect ? base.CombatChar : base.CurrEnemyChar, 40 * power / 10 * ((!base.IsDirect) ? 1 : (-1)));
				ShowSpecialEffectTips(0);
			}
			RemoveSelf(context);
		}
	}
}
