using System.Collections.Generic;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.CombatSkillEffectCountMoreOrEqual)]
public class AiConditionCombatSkillEffectCountMoreOrEqual : AiConditionCheckCharBase
{
	private readonly SkillEffectKey _effectKey;

	private readonly int _count;

	public AiConditionCombatSkillEffectCountMoreOrEqual(IReadOnlyList<int> ints)
		: base(ints)
	{
		bool isDirect = ints[1] == 1;
		short skillId = (short)ints[2];
		_effectKey = new SkillEffectKey(skillId, isDirect);
		_count = ints[3];
	}

	protected override bool Check(CombatCharacter checkChar)
	{
		Dictionary<SkillEffectKey, short> effectDict = checkChar.GetSkillEffectCollection()?.EffectDict;
		if (effectDict == null)
		{
			return false;
		}
		short count;
		return effectDict.TryGetValue(_effectKey, out count) && count >= _count;
	}
}
