using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.HuanXin;

public class DuoShen : CombatSkillEffectBase
{
	private const short SilenceFrame = 600;

	public DuoShen()
	{
	}

	public DuoShen(CombatSkillKey skillKey)
		: base(skillKey, 17105, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly);
		DomainManager.Combat.AddCombatState(context, base.CombatChar, 1, 114);
		DomainManager.Combat.AddCombatState(context, enemyChar, 2, 115);
		ShowSpecialEffectTips(0);
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
			CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly);
			foreach (short banableSkillId in enemyChar.GetBanableSkillIds(2, -1))
			{
				DomainManager.Combat.SilenceSkill(context, enemyChar, banableSkillId, 600);
			}
			ShowSpecialEffectTips(1);
		}
		RemoveSelf(context);
	}
}
