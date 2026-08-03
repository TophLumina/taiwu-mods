using System.Collections.Generic;
using Config;

namespace GameData.Utilities;

/// <summary>
/// 道具配置通用接口
/// </summary>
public interface IItemConfig
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	short TemplateId { get; }

	/// <summary>
	/// 道具类型
	/// </summary>
	sbyte ItemType { get; }

	/// <summary>
	/// 道具子类型
	/// </summary>
	short ItemSubType { get; }

	/// <summary>
	/// 名称
	/// </summary>
	string Name { get; }

	/// <summary>
	/// 图标
	/// </summary>
	string Icon { get; }

	/// <summary>
	/// 品级
	/// </summary>
	sbyte Grade { get; }

	/// <summary>
	/// 所属分组
	/// </summary>
	short GroupId { get; }

	/// <summary>
	/// 最大使用距离
	/// </summary>
	sbyte MaxUseDistance => 0;

	/// <summary>
	/// 持续时间
	/// </summary>
	short Duration => 0;

	/// <summary>
	/// 物品价格
	/// </summary>
	int BaseValue { get; }

	/// <summary>
	/// 玄字效果配置
	/// </summary>
	MysteryEffectItem MysteryEffect => Config.MysteryEffect.Instance[MysteryEffectId];

	/// <summary>
	/// 玄字效果 ID
	/// </summary>
	int MysteryEffectId => -1;

	/// <summary>
	/// 武具效果 ID
	/// </summary>
	int EquipmentMasteryId => -1;

	/// <summary>
	/// 制造子类型
	/// </summary>
	short MakeItemSubType => -1;

	/// <summary>
	/// 任务锁
	/// - 当对应任务被启用时，禁止移动物品 TAIWU-39826
	/// </summary>
	List<int> TaskLock { get; }
}
