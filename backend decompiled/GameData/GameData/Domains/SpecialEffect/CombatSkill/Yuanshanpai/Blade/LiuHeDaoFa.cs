using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Yuanshanpai.Blade;

public class LiuHeDaoFa : CombatSkillEffectBase
{
	public LiuHeDaoFa()
	{
	}

	public LiuHeDaoFa(CombatSkillKey skillKey)
		: base(skillKey, 5301, -1)
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
				DomainManager.Combat.AddCombatState(context, base.CombatChar, 1, (short)(base.IsDirect ? 208 : 209), power);
				ShowSpecialEffectTips(0);
			}
			RemoveSelf(context);
		}
	}
}
