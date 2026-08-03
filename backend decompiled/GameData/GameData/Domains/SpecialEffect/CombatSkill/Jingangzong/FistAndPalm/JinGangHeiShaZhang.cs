using GameData.Common;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jingangzong.FistAndPalm;

public class JinGangHeiShaZhang : AddWeaponEquipAttackOnAttack
{
	public JinGangHeiShaZhang()
	{
	}

	public JinGangHeiShaZhang(CombatSkillKey skillKey)
		: base(skillKey, 11103)
	{
	}

	protected override void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			if (power > 0)
			{
				DomainManager.Combat.AddCombatState(context, base.CombatChar, 1, (short)(base.IsDirect ? 55 : 56), power * 2);
				ShowSpecialEffectTips(1);
			}
			RemoveSelf(context);
		}
	}
}
