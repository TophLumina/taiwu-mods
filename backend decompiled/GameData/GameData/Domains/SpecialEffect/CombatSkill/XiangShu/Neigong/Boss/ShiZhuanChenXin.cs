using GameData.Common;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Neigong.Boss;

public class ShiZhuanChenXin : CombatSkillEffectBase
{
	private const sbyte AddNeiliAllocationPercent = 50;

	public ShiZhuanChenXin()
	{
	}

	public ShiZhuanChenXin(CombatSkillKey skillKey)
		: base(skillKey, 16110, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		CombatDomain.RegisterHandler_CombatCharAboutToFall(OnCharAboutToFall);
	}

	public override void OnDisable(DataContext context)
	{
		CombatDomain.UnRegisterHandler_CombatCharAboutToFall(OnCharAboutToFall);
	}

	private unsafe void OnCharAboutToFall(DataContext context, CombatCharacter combatChar, ECombatCharAboutToFallType type)
	{
		if (combatChar == base.CombatChar && type == ECombatCharAboutToFallType.AddPhase && base.CombatChar.GetBossPhase() < 5 && DomainManager.Combat.IsCharacterFallen(base.CombatChar))
		{
			DomainManager.Combat.Reset(context, base.CombatChar);
			DomainManager.Combat.AddBossPhase(context, base.CombatChar, -1);
			NeiliAllocation originNeiliAllocation = base.CombatChar.GetOriginNeiliAllocation();
			for (byte i = 0; i < 4; i++)
			{
				base.CombatChar.ChangeNeiliAllocation(context, i, originNeiliAllocation.Items[(int)i] * 50 / 100);
			}
			ShowSpecialEffectTips(0);
		}
	}
}
