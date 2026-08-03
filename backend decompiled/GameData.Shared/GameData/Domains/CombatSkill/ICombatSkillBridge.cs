using System.Collections.Generic;
using Config;
using GameData.Domains.Character;

namespace GameData.Domains.CombatSkill;

/// <summary>
/// 功法数据接口
/// </summary>
public interface ICombatSkillBridge
{
	/// <summary>
	/// 功法模板 ID
	/// </summary>
	short SkillTemplateId { get; }

	/// <summary>
	/// 消耗气势值
	/// </summary>
	OuterAndInnerInts CostBreathStance { get; }

	/// <summary>
	/// 获取消耗脚力值
	/// </summary>
	sbyte GetCostMobilityPercent();

	/// <summary>
	/// 获取消耗蓄式
	/// </summary>
	/// <param name="costTricks"></param>
	void GetCostTrick(List<NeedTrick> costTricks);

	/// <summary>
	/// 获取消耗真气
	/// </summary>
	/// <returns></returns>
	(sbyte type, sbyte value) GetCostNeiliAllocation();
}
