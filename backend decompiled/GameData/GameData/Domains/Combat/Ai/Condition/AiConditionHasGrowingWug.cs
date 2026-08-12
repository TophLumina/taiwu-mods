using System.Collections.Generic;
using GameData.Domains.Character;
using GameData.Domains.Item;

namespace GameData.Domains.Combat.Ai.Condition;

[AiCondition(EAiConditionType.HasGrowingWug)]
public class AiConditionHasGrowingWug : AiConditionCheckCharBase
{
	private readonly bool _isNotInCombat;

	private readonly bool _isGood;

	private readonly sbyte _wugType;

	public AiConditionHasGrowingWug(IReadOnlyList<int> ints)
		: base(ints)
	{
		_isNotInCombat = ints[1] == 1;
		_isGood = ints[2] == 1;
		_wugType = (sbyte)ints[3];
	}

	protected override bool Check(CombatCharacter checkChar)
	{
		bool isGood = _isGood;
		if (1 == 0)
		{
		}
		sbyte b = (sbyte)((!isGood) ? (_isNotInCombat ? 3 : 2) : (_isNotInCombat ? 1 : 0));
		if (1 == 0)
		{
		}
		sbyte growthType = b;
		short templateId = ItemDomain.GetWugTemplateId(_wugType, growthType);
		return checkChar.GetCharacter().GetEatingItems().IndexOfWug(templateId) >= 0;
	}
}
