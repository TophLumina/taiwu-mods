using System;
using System.Collections.Generic;
using Config.Common;
using Config.ConfigCells.Character;

namespace Config;

[Serializable]
public class CharacterFilterRulesItem : ConfigItem<CharacterFilterRulesItem, short>
{
	public readonly short TemplateId;

	public readonly int[] CharacterMatchers;

	public readonly List<CharacterFilterElement> RulesList;

	public CharacterFilterRulesItem(short templateId, int[] characterMatchers, List<CharacterFilterElement> rulesList)
	{
		TemplateId = templateId;
		CharacterMatchers = characterMatchers;
		RulesList = rulesList;
	}

	public CharacterFilterRulesItem()
	{
		TemplateId = 0;
		CharacterMatchers = new int[0];
		RulesList = new List<CharacterFilterElement>();
	}

	public CharacterFilterRulesItem(short templateId, CharacterFilterRulesItem other)
	{
		TemplateId = templateId;
		CharacterMatchers = other.CharacterMatchers;
		RulesList = other.RulesList;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override CharacterFilterRulesItem Duplicate(int templateId)
	{
		return new CharacterFilterRulesItem((short)templateId, this);
	}
}
