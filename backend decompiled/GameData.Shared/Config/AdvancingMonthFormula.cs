using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class AdvancingMonthFormula : ConfigData<AdvancingMonthFormulaItem, int>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 暗杀非监牢人物成功率
		/// </summary>
		public const int JieqingAssassinateChance = 0;

		/// <summary>
		/// 暗杀非监牢人物成功率无影令
		/// </summary>
		public const int JieqingAssassinateChanceWuYing = 1;

		/// <summary>
		/// 暗杀监牢人物成功率
		/// </summary>
		public const int JieqingAssassinatePrisonerChance = 2;

		/// <summary>
		/// 暗杀监牢人物成功率无影令
		/// </summary>
		public const int JieqingAssassinatePrisonerChanceWuYing = 3;

		/// <summary>
		/// 资质成长尝试概率
		/// </summary>
		public const int QualificationGrowthTriggerChance = 4;

		/// <summary>
		/// 资质成长保底触发
		/// </summary>
		public const int QualificationGrowthGuaranteed = 5;

		/// <summary>
		/// 资质成长七元概率
		/// </summary>
		public const int QualificationGrowthPersonality = 6;

		/// <summary>
		/// 资质成长师承概率
		/// </summary>
		public const int QualificationGrowthMentor = 7;

		/// <summary>
		/// 研读书籍尝试概率
		/// </summary>
		public const int ReadingTriggerChance = 31;

		/// <summary>
		/// 选择研读打分_门派身份关联武学
		/// </summary>
		public const int ReadingScoreCurrSectAdjust = 32;

		/// <summary>
		/// 选择研读打分_理想门派身份关联武学
		/// </summary>
		public const int ReadingScoreIdealSectAdjust = 33;

		/// <summary>
		/// 选择研读打分_资质
		/// </summary>
		public const int ReadingScoreQualification = 34;

		/// <summary>
		/// 选择研读打分_书页完整度
		/// </summary>
		public const int ReadingScoreCompleteState = 35;

		/// <summary>
		/// 选择研读打分_符合需求
		/// </summary>
		public const int ReadingScorePersonalNeed = 36;

		/// <summary>
		/// 选择研读打分_村民工作建筑
		/// </summary>
		public const int ReadingScoreBuildingRequiredType = 37;

		/// <summary>
		/// 选择周天打分_品级
		/// </summary>
		public const int LoopingScoreGrade = 16;

		/// <summary>
		/// 选择周天打分_有未获取内力
		/// </summary>
		public const int LoopingScorePotentialNeili = 17;

		/// <summary>
		/// 选择周天打分_有未获取额外真气
		/// </summary>
		public const int LoopingScorePotentialExtraAllocation = 30;

		/// <summary>
		/// 选择周天打分_与本门派五行不冲克
		/// </summary>
		public const int LoopingScoreCurrSectNotCounter = 18;

		/// <summary>
		/// 选择周天打分_转入本门派五行
		/// </summary>
		public const int LoopingScoreCurrSectDestType = 19;

		/// <summary>
		/// 选择周天打分_移走与本门派五行冲克五行
		/// </summary>
		public const int LoopingScoreCurrSectTransferCounter = 20;

		/// <summary>
		/// 选择周天打分_与理想门派五行不冲克
		/// </summary>
		public const int LoopingScoreIdealSectNotCounter = 21;

		/// <summary>
		/// 选择周天打分_转入理想门派五行
		/// </summary>
		public const int LoopingScoreIdealSectDestType = 22;

		/// <summary>
		/// 选择周天打分_移走与理想门派五行冲克五行
		/// </summary>
		public const int LoopingScoreIdealSectTransferCounter = 29;

		/// <summary>
		/// 选择功法装配_本门派
		/// </summary>
		public const int EquippingScoreCurrSect = 23;

		/// <summary>
		/// 选择功法装配_理想门派
		/// </summary>
		public const int EquippingScoreIdealSect = 24;

		/// <summary>
		/// 选择功法装配_与人物内力五行不冲克
		/// </summary>
		public const int EquippingScoreNotCounter = 25;

		/// <summary>
		/// 选择功法装配_品级
		/// </summary>
		public const int EquippingScoreGrade = 26;

		/// <summary>
		/// 选择功法装配_发挥威力
		/// </summary>
		public const int EquippingScoreSkillPower = 27;

		/// <summary>
		/// 选择功法装配_已突破
		/// </summary>
		public const int EquippingScoreBreakout = 28;

		/// <summary>
		/// 选择功法装配_奇书
		/// </summary>
		public const int EquippingScoreLegendaryBook = 38;

		/// <summary>
		/// 关系发起概率
		/// </summary>
		public const int StartRelationChance = 39;

		/// <summary>
		/// 天降洪福健康
		/// </summary>
		public const int GoodLuckEventHealth = 8;

		/// <summary>
		/// 天降洪福内外伤
		/// </summary>
		public const int GoodLuckEventInjury = 9;

		/// <summary>
		/// 天降洪福毒素
		/// </summary>
		public const int GoodLuckEventPoison = 10;

		/// <summary>
		/// 天降洪福内息
		/// </summary>
		public const int GoodLuckEventQi = 11;

		/// <summary>
		/// 天降横祸健康
		/// </summary>
		public const int BadLuckEventHealth = 12;

		/// <summary>
		/// 天降横祸内外伤
		/// </summary>
		public const int BadLuckEventInjury = 13;

		/// <summary>
		/// 天降横祸毒素
		/// </summary>
		public const int BadLuckEventPoison = 14;

		/// <summary>
		/// 天降横祸紊乱
		/// </summary>
		public const int BadLuckEventQi = 15;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 暗杀非监牢人物成功率
		/// </summary>
		public static AdvancingMonthFormulaItem JieqingAssassinateChance => Instance[0];

		/// <summary>
		/// 暗杀非监牢人物成功率无影令
		/// </summary>
		public static AdvancingMonthFormulaItem JieqingAssassinateChanceWuYing => Instance[1];

		/// <summary>
		/// 暗杀监牢人物成功率
		/// </summary>
		public static AdvancingMonthFormulaItem JieqingAssassinatePrisonerChance => Instance[2];

		/// <summary>
		/// 暗杀监牢人物成功率无影令
		/// </summary>
		public static AdvancingMonthFormulaItem JieqingAssassinatePrisonerChanceWuYing => Instance[3];

		/// <summary>
		/// 资质成长尝试概率
		/// </summary>
		public static AdvancingMonthFormulaItem QualificationGrowthTriggerChance => Instance[4];

		/// <summary>
		/// 资质成长保底触发
		/// </summary>
		public static AdvancingMonthFormulaItem QualificationGrowthGuaranteed => Instance[5];

		/// <summary>
		/// 资质成长七元概率
		/// </summary>
		public static AdvancingMonthFormulaItem QualificationGrowthPersonality => Instance[6];

		/// <summary>
		/// 资质成长师承概率
		/// </summary>
		public static AdvancingMonthFormulaItem QualificationGrowthMentor => Instance[7];

		/// <summary>
		/// 研读书籍尝试概率
		/// </summary>
		public static AdvancingMonthFormulaItem ReadingTriggerChance => Instance[31];

		/// <summary>
		/// 选择研读打分_门派身份关联武学
		/// </summary>
		public static AdvancingMonthFormulaItem ReadingScoreCurrSectAdjust => Instance[32];

		/// <summary>
		/// 选择研读打分_理想门派身份关联武学
		/// </summary>
		public static AdvancingMonthFormulaItem ReadingScoreIdealSectAdjust => Instance[33];

		/// <summary>
		/// 选择研读打分_资质
		/// </summary>
		public static AdvancingMonthFormulaItem ReadingScoreQualification => Instance[34];

		/// <summary>
		/// 选择研读打分_书页完整度
		/// </summary>
		public static AdvancingMonthFormulaItem ReadingScoreCompleteState => Instance[35];

		/// <summary>
		/// 选择研读打分_符合需求
		/// </summary>
		public static AdvancingMonthFormulaItem ReadingScorePersonalNeed => Instance[36];

		/// <summary>
		/// 选择研读打分_村民工作建筑
		/// </summary>
		public static AdvancingMonthFormulaItem ReadingScoreBuildingRequiredType => Instance[37];

		/// <summary>
		/// 选择周天打分_品级
		/// </summary>
		public static AdvancingMonthFormulaItem LoopingScoreGrade => Instance[16];

		/// <summary>
		/// 选择周天打分_有未获取内力
		/// </summary>
		public static AdvancingMonthFormulaItem LoopingScorePotentialNeili => Instance[17];

		/// <summary>
		/// 选择周天打分_有未获取额外真气
		/// </summary>
		public static AdvancingMonthFormulaItem LoopingScorePotentialExtraAllocation => Instance[30];

		/// <summary>
		/// 选择周天打分_与本门派五行不冲克
		/// </summary>
		public static AdvancingMonthFormulaItem LoopingScoreCurrSectNotCounter => Instance[18];

		/// <summary>
		/// 选择周天打分_转入本门派五行
		/// </summary>
		public static AdvancingMonthFormulaItem LoopingScoreCurrSectDestType => Instance[19];

		/// <summary>
		/// 选择周天打分_移走与本门派五行冲克五行
		/// </summary>
		public static AdvancingMonthFormulaItem LoopingScoreCurrSectTransferCounter => Instance[20];

		/// <summary>
		/// 选择周天打分_与理想门派五行不冲克
		/// </summary>
		public static AdvancingMonthFormulaItem LoopingScoreIdealSectNotCounter => Instance[21];

		/// <summary>
		/// 选择周天打分_转入理想门派五行
		/// </summary>
		public static AdvancingMonthFormulaItem LoopingScoreIdealSectDestType => Instance[22];

		/// <summary>
		/// 选择周天打分_移走与理想门派五行冲克五行
		/// </summary>
		public static AdvancingMonthFormulaItem LoopingScoreIdealSectTransferCounter => Instance[29];

		/// <summary>
		/// 选择功法装配_本门派
		/// </summary>
		public static AdvancingMonthFormulaItem EquippingScoreCurrSect => Instance[23];

		/// <summary>
		/// 选择功法装配_理想门派
		/// </summary>
		public static AdvancingMonthFormulaItem EquippingScoreIdealSect => Instance[24];

		/// <summary>
		/// 选择功法装配_与人物内力五行不冲克
		/// </summary>
		public static AdvancingMonthFormulaItem EquippingScoreNotCounter => Instance[25];

		/// <summary>
		/// 选择功法装配_品级
		/// </summary>
		public static AdvancingMonthFormulaItem EquippingScoreGrade => Instance[26];

		/// <summary>
		/// 选择功法装配_发挥威力
		/// </summary>
		public static AdvancingMonthFormulaItem EquippingScoreSkillPower => Instance[27];

		/// <summary>
		/// 选择功法装配_已突破
		/// </summary>
		public static AdvancingMonthFormulaItem EquippingScoreBreakout => Instance[28];

		/// <summary>
		/// 选择功法装配_奇书
		/// </summary>
		public static AdvancingMonthFormulaItem EquippingScoreLegendaryBook => Instance[38];

		/// <summary>
		/// 关系发起概率
		/// </summary>
		public static AdvancingMonthFormulaItem StartRelationChance => Instance[39];

		/// <summary>
		/// 天降洪福健康
		/// </summary>
		public static AdvancingMonthFormulaItem GoodLuckEventHealth => Instance[8];

		/// <summary>
		/// 天降洪福内外伤
		/// </summary>
		public static AdvancingMonthFormulaItem GoodLuckEventInjury => Instance[9];

		/// <summary>
		/// 天降洪福毒素
		/// </summary>
		public static AdvancingMonthFormulaItem GoodLuckEventPoison => Instance[10];

		/// <summary>
		/// 天降洪福内息
		/// </summary>
		public static AdvancingMonthFormulaItem GoodLuckEventQi => Instance[11];

		/// <summary>
		/// 天降横祸健康
		/// </summary>
		public static AdvancingMonthFormulaItem BadLuckEventHealth => Instance[12];

		/// <summary>
		/// 天降横祸内外伤
		/// </summary>
		public static AdvancingMonthFormulaItem BadLuckEventInjury => Instance[13];

		/// <summary>
		/// 天降横祸毒素
		/// </summary>
		public static AdvancingMonthFormulaItem BadLuckEventPoison => Instance[14];

		/// <summary>
		/// 天降横祸紊乱
		/// </summary>
		public static AdvancingMonthFormulaItem BadLuckEventQi => Instance[15];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static AdvancingMonthFormula Instance = new AdvancingMonthFormula();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "TemplateId" };

	internal override int ToInt(int value)
	{
		return value;
	}

	internal override int ToTemplateId(int value)
	{
		return value;
	}

	private void CreateItems0()
	{
		_dataArray.Add(new AdvancingMonthFormulaItem(0, EAdvancingMonthFormulaType.LinearFunction, new int[2] { -6, 60 }, -1));
		_dataArray.Add(new AdvancingMonthFormulaItem(1, EAdvancingMonthFormulaType.LinearFunction, new int[2] { -12, 120 }, -1));
		_dataArray.Add(new AdvancingMonthFormulaItem(2, EAdvancingMonthFormulaType.LinearFunction, new int[2] { -12, 120 }, -1));
		_dataArray.Add(new AdvancingMonthFormulaItem(3, EAdvancingMonthFormulaType.LinearFunction, new int[2] { -24, 240 }, -1));
		_dataArray.Add(new AdvancingMonthFormulaItem(4, EAdvancingMonthFormulaType.ConstantFunction, new int[1] { 50 }, -1));
		_dataArray.Add(new AdvancingMonthFormulaItem(5, EAdvancingMonthFormulaType.ModularFunction, new int[1] { 4 }, -1));
		_dataArray.Add(new AdvancingMonthFormulaItem(6, EAdvancingMonthFormulaType.Formula0, new int[1] { 3 }, -1));
		_dataArray.Add(new AdvancingMonthFormulaItem(7, EAdvancingMonthFormulaType.Formula1, new int[1] { 3 }, -1));
		_dataArray.Add(new AdvancingMonthFormulaItem(8, EAdvancingMonthFormulaType.ConstantFunction, new int[1] { 18 }, -1));
		_dataArray.Add(new AdvancingMonthFormulaItem(9, EAdvancingMonthFormulaType.ConstantRangeRandom, new int[2] { 3, 10 }, -1));
		_dataArray.Add(new AdvancingMonthFormulaItem(10, EAdvancingMonthFormulaType.ConstantRangeRandom, new int[2] { 150, 451 }, -1));
		_dataArray.Add(new AdvancingMonthFormulaItem(11, EAdvancingMonthFormulaType.ConstantRangeRandom, new int[2] { 3000, 6001 }, -1));
		_dataArray.Add(new AdvancingMonthFormulaItem(12, EAdvancingMonthFormulaType.ConstantFunction, new int[1] { 6 }, -1));
		_dataArray.Add(new AdvancingMonthFormulaItem(13, EAdvancingMonthFormulaType.ConstantRangeRandom, new int[2] { 1, 4 }, -1));
		_dataArray.Add(new AdvancingMonthFormulaItem(14, EAdvancingMonthFormulaType.ConstantRangeRandom, new int[2] { 50, 151 }, -1));
		_dataArray.Add(new AdvancingMonthFormulaItem(15, EAdvancingMonthFormulaType.ConstantRangeRandom, new int[2] { 1000, 2001 }, -1));
		_dataArray.Add(new AdvancingMonthFormulaItem(16, EAdvancingMonthFormulaType.ProportionalFunction, new int[1] { 50 }, -1));
		_dataArray.Add(new AdvancingMonthFormulaItem(17, EAdvancingMonthFormulaType.ConstantFunction, new int[1] { 800 }, -1));
		_dataArray.Add(new AdvancingMonthFormulaItem(18, EAdvancingMonthFormulaType.ConstantFunction, new int[1] { 200 }, -1));
		_dataArray.Add(new AdvancingMonthFormulaItem(19, EAdvancingMonthFormulaType.ConstantFunction, new int[1] { 100 }, -1));
		_dataArray.Add(new AdvancingMonthFormulaItem(20, EAdvancingMonthFormulaType.ConstantFunction, new int[1] { 100 }, -1));
		_dataArray.Add(new AdvancingMonthFormulaItem(21, EAdvancingMonthFormulaType.ConstantFunction, new int[1] { 100 }, -1));
		_dataArray.Add(new AdvancingMonthFormulaItem(22, EAdvancingMonthFormulaType.ConstantFunction, new int[1] { 50 }, -1));
		_dataArray.Add(new AdvancingMonthFormulaItem(23, EAdvancingMonthFormulaType.OffsetFunction, new int[1] { 100 }, -1));
		_dataArray.Add(new AdvancingMonthFormulaItem(24, EAdvancingMonthFormulaType.Formula2, new int[2] { 2, 50 }, -1));
		_dataArray.Add(new AdvancingMonthFormulaItem(25, EAdvancingMonthFormulaType.OffsetFunction, new int[1] { 100 }, -1));
		_dataArray.Add(new AdvancingMonthFormulaItem(26, EAdvancingMonthFormulaType.ProportionalFunction, new int[1] { 50 }, -1));
		_dataArray.Add(new AdvancingMonthFormulaItem(27, EAdvancingMonthFormulaType.IdentityFunction, new int[0], 200));
		_dataArray.Add(new AdvancingMonthFormulaItem(28, EAdvancingMonthFormulaType.ConstantFunction, new int[1] { 200 }, -1));
		_dataArray.Add(new AdvancingMonthFormulaItem(29, EAdvancingMonthFormulaType.ConstantFunction, new int[1] { 50 }, -1));
		_dataArray.Add(new AdvancingMonthFormulaItem(30, EAdvancingMonthFormulaType.ConstantFunction, new int[1] { 200 }, -1));
		_dataArray.Add(new AdvancingMonthFormulaItem(31, EAdvancingMonthFormulaType.OffsetFunction, new int[1] { 50 }, -1));
		_dataArray.Add(new AdvancingMonthFormulaItem(32, EAdvancingMonthFormulaType.ProportionalFunction, new int[1] { 10 }, -1));
		_dataArray.Add(new AdvancingMonthFormulaItem(33, EAdvancingMonthFormulaType.ProportionalFunction, new int[1] { 5 }, -1));
		_dataArray.Add(new AdvancingMonthFormulaItem(34, EAdvancingMonthFormulaType.IdentityFunction, new int[0], -1));
		_dataArray.Add(new AdvancingMonthFormulaItem(35, EAdvancingMonthFormulaType.ArrayElement, new int[3] { 25, 5, 0 }, -1));
		_dataArray.Add(new AdvancingMonthFormulaItem(36, EAdvancingMonthFormulaType.ConstantFunction, new int[1] { 100 }, -1));
		_dataArray.Add(new AdvancingMonthFormulaItem(37, EAdvancingMonthFormulaType.ConstantFunction, new int[1] { 1000 }, -1));
		_dataArray.Add(new AdvancingMonthFormulaItem(38, EAdvancingMonthFormulaType.ConstantFunction, new int[1] { 300 }, -1));
		_dataArray.Add(new AdvancingMonthFormulaItem(39, EAdvancingMonthFormulaType.LinearFunction, new int[2] { 3, 30 }, -1));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<AdvancingMonthFormulaItem>(40);
		CreateItems0();
	}
}
