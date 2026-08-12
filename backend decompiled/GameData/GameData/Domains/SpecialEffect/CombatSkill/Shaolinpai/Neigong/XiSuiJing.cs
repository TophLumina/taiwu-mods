using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Shaolinpai.Neigong;

public class XiSuiJing : GenderKeepYoung
{
	protected override sbyte ReduceFatalDamageValueType => 0;

	public XiSuiJing()
	{
	}

	public XiSuiJing(CombatSkillKey skillKey)
		: base(skillKey, 1008)
	{
		RequireGender = 1;
	}
}
