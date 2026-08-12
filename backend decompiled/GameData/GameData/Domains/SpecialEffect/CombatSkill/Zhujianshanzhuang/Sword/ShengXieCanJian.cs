using System.Collections.Generic;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.AttackCommon;

namespace GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.Sword;

public class ShengXieCanJian : SwordAttackSkillEffectBase
{
	protected override IEnumerable<sbyte> RequirePersonalityTypes
	{
		get
		{
			yield return 2;
		}
	}

	protected override int RequirePersonalityValue => 50;

	protected override ushort FieldId => 74;

	protected override int AddValue => 150;

	public ShengXieCanJian()
	{
	}

	public ShengXieCanJian(CombatSkillKey skillKey)
		: base(skillKey, 9102)
	{
	}
}
