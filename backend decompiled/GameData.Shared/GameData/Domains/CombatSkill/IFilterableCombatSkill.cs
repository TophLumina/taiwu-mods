using System.Collections.Generic;

namespace GameData.Domains.CombatSkill;

/// <summary>
/// 可筛选的功法数据
/// 用于功法列表的筛选和排序功能
/// </summary>
public interface IFilterableCombatSkill
{
	/// <summary>
	/// 功法模板 ID
	/// </summary>
	short TemplateId { get; }

	/// <summary>
	/// 功法类型
	/// <see cref="T:GameData.Domains.CombatSkill.CombatSkillType" />
	/// </summary>
	sbyte Type { get; }

	/// <summary>
	/// 所属门派
	/// <see cref="T:Config.Organization" />
	/// </summary>
	sbyte SectId { get; }

	/// <summary>
	/// 激活状态
	/// 用于判断功法是否已突破（通过 CombatSkillStateHelper.IsBrokenOut 判断）
	/// </summary>
	ushort ActivationState { get; }

	/// <summary>
	/// 是否已装备到任何方案
	/// 用于筛选已装备/未装备功法
	/// </summary>
	bool IsInAnyEquipPlans { get; }

	/// <summary>
	/// 是否有峨眉派突破加成
	/// 用于特殊筛选功能
	/// </summary>
	bool HasSectEmeiSkillBreakBonus { get; }

	/// <summary>
	/// 功法威力
	/// 用于按威力排序
	/// </summary>
	short Power { get; }

	/// <summary>
	/// 突破加成等级列表
	/// 用于按突破加成数量排序
	/// </summary>
	List<sbyte> BreakBonusGrades { get; }

	/// <summary>
	/// 阅读状态
	/// 用于按阅读进度排序（通过 CombatSkillStateHelper.GetReadPagesCount 获取已读页数）
	/// </summary>
	ushort ReadingState { get; }

	/// <summary>
	/// 最大可获得内力
	/// 用于演练功能排序
	/// </summary>
	short MaxObtainableNeili { get; }

	/// <summary>
	/// 已获得内力
	/// 用于演练功能排序
	/// </summary>
	short ObtainedNeili { get; }

	/// <summary>
	/// 周天五行起始类型
	/// </summary>
	sbyte FiveElementTransferTypeWhileLooping { get; set; }

	/// <summary>
	/// 周天五行目标类型
	/// 用于五行转移排序（值 &gt;= 0 表示有五行转移）
	/// </summary>
	sbyte FiveElementDestTypeWhileLooping { get; set; }

	/// <summary>
	/// 实战度（CombatSkillProficiency 分子值）
	/// 用于按实战排序
	/// </summary>
	int CombatSkillProficiency { get; }
}
