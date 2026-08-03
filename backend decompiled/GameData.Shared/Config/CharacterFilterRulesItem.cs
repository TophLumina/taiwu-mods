using System;
using System.Collections.Generic;
using Config.Common;
using Config.ConfigCells.Character;

namespace Config;

[Serializable]
public class CharacterFilterRulesItem : ConfigItem<CharacterFilterRulesItem, short>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 综合角色匹配条件
	/// - 配置了该条件时禁止用于生成临时角色.
	/// </summary>
	public readonly int[] CharacterMatchers;

	public readonly List<CharacterFilterElement> RulesList;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="characterMatchers">综合角色匹配条件 - 配置了该条件时禁止用于生成临时角色.</param>
	/// <param name="rulesList"> - 该列不要手动填写</param>
	public CharacterFilterRulesItem(short templateId, int[] characterMatchers, List<CharacterFilterElement> rulesList)
	{
		TemplateId = templateId;
		CharacterMatchers = characterMatchers;
		RulesList = rulesList;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public CharacterFilterRulesItem()
	{
		TemplateId = 0;
		CharacterMatchers = new int[0];
		RulesList = new List<CharacterFilterElement>();
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
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

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override CharacterFilterRulesItem Duplicate(int templateId)
	{
		return new CharacterFilterRulesItem((short)templateId, this);
	}
}
