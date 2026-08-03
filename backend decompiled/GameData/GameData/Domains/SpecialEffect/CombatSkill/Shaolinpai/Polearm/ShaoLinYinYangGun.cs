using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Shaolinpai.Polearm;

public class ShaoLinYinYangGun : GetTrick
{
	public ShaoLinYinYangGun()
	{
	}

	public ShaoLinYinYangGun(CombatSkillKey skillKey)
		: base(skillKey, 1301)
	{
		GetTrickType = 5;
		DirectCanChangeTrickType = new sbyte[2] { 3, 4 };
	}
}
