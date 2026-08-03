using System;
using System.Linq;

namespace Config.ConfigCells.Character;

/// <summary>
/// 角色筛选要求
/// </summary>
[Serializable]
public class CharacterFilterRequirement
{
	/// <summary>
	/// 使用的筛选规则
	/// </summary>
	public short[] CharacterFilterRuleIds;

	/// <summary>
	/// 最少需要多少个角色
	/// </summary>
	public int MinCharactersRequired;

	/// <summary>
	/// 最多需要多少个角色
	/// </summary>
	public int MaxCharactersRequired;

	/// <summary>
	/// 构造函数
	/// </summary>
	public CharacterFilterRequirement(int[] filterRuleIds, int minCharactersRequired, int maxCharactersRequired = -1)
	{
		if (filterRuleIds == null || filterRuleIds.Length == 0)
		{
			throw new ArgumentException("CharacterFilterRequirement need at least one filterRuleId");
		}
		CharacterFilterRuleIds = filterRuleIds.Select((int id) => (short)id).ToArray();
		MinCharactersRequired = minCharactersRequired;
		MaxCharactersRequired = maxCharactersRequired;
	}

	/// <summary>
	/// 有最大人数限制
	/// </summary>
	/// <returns></returns>
	public bool HasMaximum()
	{
		return MaxCharactersRequired != -1;
	}
}
