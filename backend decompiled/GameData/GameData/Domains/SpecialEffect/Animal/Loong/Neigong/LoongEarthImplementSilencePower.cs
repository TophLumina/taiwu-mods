using GameData.Common;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.Animal.Loong.Neigong;

public class LoongEarthImplementSilencePower : LoongEarthImplementSilence, ILoongEarthExtra
{
	private const int ReducePower = -30;

	public void OnSilenced(DataContext context, CombatCharacter combatChar, short skillId)
	{
		DomainManager.Combat.ReduceSkillPowerInCombat(context, new CombatSkillKey(combatChar.GetId(), skillId), base.EffectBase.EffectKey, -30);
	}
}
