using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class RandomEnemyItem : ConfigItem<RandomEnemyItem, short>
{
	/// <summary>
	/// 模板 ID
	/// </summary>
	public readonly short TemplateId;

	/// <summary>
	/// 门派
	/// - 可选门派集合. 关联到 Organization 表.
	/// </summary>
	public readonly List<short> SectIds;

	/// <summary>
	/// 选择几个门派的功法
	/// - 以此配置，限制人物能够从几个门派的功法中选择功法，如：配置为1，而人物的可选门派集合中有3个门派，则在选择此人物的功法前，先随机选择集合中的1个门派，再从这个门派里选择功法
	/// </summary>
	public readonly int SelectSectCount;

	/// <summary>
	/// 可生成摧破类型
	/// - 空的表示不限制
	/// </summary>
	public readonly List<short> RequireAttackSkillType;

	/// <summary>
	/// 物品品级
	/// - 该角色的物品的期望品级, 生成的物品等级通常会比这个低. 正常范围 [0, 8]. 0 为最低品, -1 为无效值.
	/// </summary>
	public readonly sbyte ItemGrade;

	/// <summary>
	/// 技艺资质调整
	/// - 原资质 * (100 + 调整值) / 100 = 最终资质
	/// </summary>
	public readonly short LifeSkillQualificationAdjust;

	/// <summary>
	/// 武学资质调整
	/// - 原资质 * (100 + 调整值) / 100 = 最终资质
	/// </summary>
	public readonly short CombatSkillQualificationAdjust;

	/// <summary>
	/// 获取恩义
	/// - 驱逐或打败散落在地图上的敌人时，获得的地区恩义
	/// </summary>
	public readonly short SpiritualDebt;

	/// <summary>
	/// 道具淬毒几率
	/// - 生成时给自身持有的可淬毒道具淬毒的概率
	/// </summary>
	public readonly sbyte AddPoisonRate;

	/// <summary>
	/// 最大淬毒个数
	/// - 最多向一个道具上淬几个毒，如参数为3，则表示淬1~3种不同类型的毒
	/// </summary>
	public readonly sbyte MaxAddPoisonCount;

	/// <summary>
	/// 使用毒药
	/// - 给自身可淬毒道具淬毒时使用的毒药
	/// </summary>
	public readonly short[] PoisonsToAdd;

	/// <summary>
	/// 修习度范围
	/// - {10,120}表示结果在10至120间随机，最大100
	/// </summary>
	public readonly (int, int) PracticeRandomRange;

	/// <summary>
	/// 书页范围
	/// - {{1,10},{1,10}}表示正练1~10页，最多5页，逆练1~10页，最多5页
	/// </summary>
	public readonly (int, int)[] PageCountRandomRange;

	public RandomEnemyItem(short templateId, List<short> sectIds, int selectSectCount, List<short> requireAttackSkillType, sbyte itemGrade, short lifeSkillQualificationAdjust, short combatSkillQualificationAdjust, short spiritualDebt, sbyte addPoisonRate, sbyte maxAddPoisonCount, short[] poisonsToAdd, (int, int) practiceRandomRange, (int, int)[] pageCountRandomRange)
	{
		TemplateId = templateId;
		SectIds = sectIds;
		SelectSectCount = selectSectCount;
		RequireAttackSkillType = requireAttackSkillType;
		ItemGrade = itemGrade;
		LifeSkillQualificationAdjust = lifeSkillQualificationAdjust;
		CombatSkillQualificationAdjust = combatSkillQualificationAdjust;
		SpiritualDebt = spiritualDebt;
		AddPoisonRate = addPoisonRate;
		MaxAddPoisonCount = maxAddPoisonCount;
		PoisonsToAdd = poisonsToAdd;
		PracticeRandomRange = practiceRandomRange;
		PageCountRandomRange = pageCountRandomRange;
	}

	/// <summary>
	/// 默认构造器 - constructor1
	/// </summary>
	public RandomEnemyItem()
	{
		TemplateId = 0;
		SectIds = new List<short> { 0 };
		SelectSectCount = 1;
		RequireAttackSkillType = new List<short>();
		ItemGrade = 0;
		LifeSkillQualificationAdjust = 0;
		CombatSkillQualificationAdjust = 0;
		SpiritualDebt = 0;
		AddPoisonRate = 0;
		MaxAddPoisonCount = 0;
		PoisonsToAdd = new short[0];
		PracticeRandomRange = default((int, int));
		PageCountRandomRange = new(int, int)[2]
		{
			(0, 0),
			(0, 0)
		};
	}

	/// <summary>
	/// 复制构造器 - constructor2
	/// </summary>
	public RandomEnemyItem(short templateId, RandomEnemyItem other)
	{
		TemplateId = templateId;
		SectIds = other.SectIds;
		SelectSectCount = other.SelectSectCount;
		RequireAttackSkillType = other.RequireAttackSkillType;
		ItemGrade = other.ItemGrade;
		LifeSkillQualificationAdjust = other.LifeSkillQualificationAdjust;
		CombatSkillQualificationAdjust = other.CombatSkillQualificationAdjust;
		SpiritualDebt = other.SpiritualDebt;
		AddPoisonRate = other.AddPoisonRate;
		MaxAddPoisonCount = other.MaxAddPoisonCount;
		PoisonsToAdd = other.PoisonsToAdd;
		PracticeRandomRange = other.PracticeRandomRange;
		PageCountRandomRange = other.PageCountRandomRange;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	/// <summary>
	/// 以指定Id生成ConfigData的副本
	/// </summary>
	/// <param name="templateId"></param>
	public override RandomEnemyItem Duplicate(int templateId)
	{
		return new RandomEnemyItem((short)templateId, this);
	}
}
