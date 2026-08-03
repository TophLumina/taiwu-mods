using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class ChoosyItem : ConfigItem<ChoosyItem, short>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 基础升级几率
	/// - 万位制，10000为100%；进行精挑细选时，从最低品开始向上升级的基础几率
	/// </summary>
	public readonly int BaseUpgradeRate;

	/// <summary>
	/// 最大升级几率
	/// - 万位制，基础升级几率加升级几率加成后的最大值
	/// </summary>
	public readonly int MaxUpgradeRate;

	/// <summary>
	/// 基础升级次数
	/// - 万位制，每10000为1个品级，计算时向下取整；基础可升级次数
	/// </summary>
	public readonly int BaseUpgradeCount;

	/// <summary>
	/// 最大升级次数
	/// - 万位制，每10000为1个品级，计算时向下取整；在进行升级时，最多可升级几次
	/// </summary>
	public readonly int MaxUpgradeCount;

	/// <summary>
	/// 品级列表
	/// - 精挑细选出最高品级的引子时，累计的升级几率、升级次数清零
	/// </summary>
	public readonly List<short> GradeList;

	/// <summary>
	/// 造诣倍率
	/// - 每N点造诣，增加一次升级几率加成和升级次数加成
	/// </summary>
	public readonly int AttainmentRate;

	/// <summary>
	/// 造诣升级几率加成
	/// - 每N点造诣在精挑细选后，可累计增加多少的升级几率，累计的升级几率，在精挑细选出最高品的引子后，就会清零（预期500造诣时50次让升级几率提高一倍）
	/// </summary>
	public readonly int UpgradeRateAttainmentBonus;

	/// <summary>
	/// 造诣升级次数加成
	/// - 每N点造诣在精挑细选后，可累计增加多少的升级次数，不能超过最大升级次数，在精挑细选出最高品的引子后，就会清零（预期500造诣时，50次精挑细选可开放最高品级）
	/// </summary>
	public readonly int UpgradeCountAttainmentBonus;

	/// <summary>
	/// 对应技艺类型
	/// </summary>
	public readonly sbyte LifeSkillType;

	/// <summary>
	/// 构造器 - constructor0
	/// </summary>
	/// <param name="templateId">模板 ID</param>
	/// <param name="baseUpgradeRate">基础升级几率 - 万位制，10000为100%；进行精挑细选时，从最低品开始向上升级的基础几率</param>
	/// <param name="maxUpgradeRate">最大升级几率 - 万位制，基础升级几率加升级几率加成后的最大值</param>
	/// <param name="baseUpgradeCount">基础升级次数 - 万位制，每10000为1个品级，计算时向下取整；基础可升级次数</param>
	/// <param name="maxUpgradeCount">最大升级次数 - 万位制，每10000为1个品级，计算时向下取整；在进行升级时，最多可升级几次</param>
	/// <param name="gradeList">品级列表 - 精挑细选出最高品级的引子时，累计的升级几率、升级次数清零</param>
	/// <param name="attainmentRate">造诣倍率 - 每N点造诣，增加一次升级几率加成和升级次数加成</param>
	/// <param name="upgradeRateAttainmentBonus">造诣升级几率加成 - 每N点造诣在精挑细选后，可累计增加多少的升级几率，累计的升级几率，在精挑细选出最高品的引子后，就会清零（预期500造诣时50次让升级几率提高一倍）</param>
	/// <param name="upgradeCountAttainmentBonus">造诣升级次数加成 - 每N点造诣在精挑细选后，可累计增加多少的升级次数，不能超过最大升级次数，在精挑细选出最高品的引子后，就会清零（预期500造诣时，50次精挑细选可开放最高品级）</param>
	/// <param name="lifeSkillType">对应技艺类型</param>
	public ChoosyItem(short templateId, int baseUpgradeRate, int maxUpgradeRate, int baseUpgradeCount, int maxUpgradeCount, List<short> gradeList, int attainmentRate, int upgradeRateAttainmentBonus, int upgradeCountAttainmentBonus, sbyte lifeSkillType)
	{
		TemplateId = templateId;
		BaseUpgradeRate = baseUpgradeRate;
		MaxUpgradeRate = maxUpgradeRate;
		BaseUpgradeCount = baseUpgradeCount;
		MaxUpgradeCount = maxUpgradeCount;
		GradeList = gradeList;
		AttainmentRate = attainmentRate;
		UpgradeRateAttainmentBonus = upgradeRateAttainmentBonus;
		UpgradeCountAttainmentBonus = upgradeCountAttainmentBonus;
		LifeSkillType = lifeSkillType;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public ChoosyItem()
	{
		TemplateId = 0;
		BaseUpgradeRate = 0;
		MaxUpgradeRate = 0;
		BaseUpgradeCount = 0;
		MaxUpgradeCount = 0;
		GradeList = null;
		AttainmentRate = 0;
		UpgradeRateAttainmentBonus = 0;
		UpgradeCountAttainmentBonus = 0;
		LifeSkillType = 0;
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public ChoosyItem(short templateId, ChoosyItem other)
	{
		TemplateId = templateId;
		BaseUpgradeRate = other.BaseUpgradeRate;
		MaxUpgradeRate = other.MaxUpgradeRate;
		BaseUpgradeCount = other.BaseUpgradeCount;
		MaxUpgradeCount = other.MaxUpgradeCount;
		GradeList = other.GradeList;
		AttainmentRate = other.AttainmentRate;
		UpgradeRateAttainmentBonus = other.UpgradeRateAttainmentBonus;
		UpgradeCountAttainmentBonus = other.UpgradeCountAttainmentBonus;
		LifeSkillType = other.LifeSkillType;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override ChoosyItem Duplicate(int templateId)
	{
		return new ChoosyItem((short)templateId, this);
	}
}
