using System.Collections.Generic;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.AttackCommon;

namespace GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.Sword;

public class GongBuDuYiJian : SwordAttackSkillEffectBase
{
	protected override IEnumerable<sbyte> RequirePersonalityTypes
	{
		get
		{
			yield return 0;
		}
	}

	protected override int RequirePersonalityValue => 50;

	protected override ushort FieldId => 69;

	protected override int AddValue => 40;

	public GongBuDuYiJian()
	{
	}

	public GongBuDuYiJian(CombatSkillKey skillKey)
		: base(skillKey, 9101)
	{
	}
}
