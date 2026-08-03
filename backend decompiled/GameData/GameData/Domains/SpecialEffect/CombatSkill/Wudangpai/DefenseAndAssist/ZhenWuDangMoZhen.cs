using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Assist;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wudangpai.DefenseAndAssist;

public class ZhenWuDangMoZhen : BuffTeammateCommand
{
	public ZhenWuDangMoZhen()
	{
	}

	public ZhenWuDangMoZhen(CombatSkillKey skillKey)
		: base(skillKey, 4605)
	{
		AffectTeammateCommandType = new ETeammateCommandImplement[1] { ETeammateCommandImplement.TransferNeiliAllocation };
		CommandPowerUpPercent = 100;
	}
}
