using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuannvpai.Neigong;

public class TaiYinYiMingJue : GenderKeepYoung
{
	protected override sbyte ReduceFatalDamageValueType => 1;

	public TaiYinYiMingJue()
	{
	}

	public TaiYinYiMingJue(CombatSkillKey skillKey)
		: base(skillKey, 8008)
	{
		RequireGender = 0;
	}
}
