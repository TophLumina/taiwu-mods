using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.HuanXin;

public class ChaiRen : CombatSkillEffectBase
{
	private const short SilenceFrame = 600;

	public ChaiRen()
	{
	}

	public ChaiRen(CombatSkillKey skillKey)
		: base(skillKey, 17103, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly);
		DomainManager.Combat.AddCombatState(context, base.CombatChar, 1, (short)(94 + context.Random.Next(0, 10)));
		DomainManager.Combat.AddCombatState(context, enemyChar, 2, (short)(104 + context.Random.Next(0, 10)));
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
			foreach (short banableSkillId in enemyChar.GetBanableSkillIds(1, -1))
			{
				DomainManager.Combat.SilenceSkill(context, enemyChar, banableSkillId, 600);
			}
			ShowSpecialEffectTips(1);
		}
		RemoveSelf(context);
	}
}
