using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.HuanXin;

public class ShiFeng : CombatSkillEffectBase
{
	public ShiFeng()
	{
	}

	public ShiFeng(CombatSkillKey skillKey)
		: base(skillKey, 17102, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		DomainManager.Combat.AddCombatState(context, base.CombatChar, 1, 93);
		ShowSpecialEffectTips(0);
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
			RemoveSelf(context);
		}
	}
}
