using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class AdvancingMonthFormula : ConfigData<AdvancingMonthFormulaItem, int>
{
	public static class DefKey
	{
		public const int JieqingAssassinateChance = 0;

		public const int JieqingAssassinateChanceWuYing = 1;

		public const int JieqingAssassinatePrisonerChance = 2;

		public const int JieqingAssassinatePrisonerChanceWuYing = 3;

		public const int QualificationGrowthTriggerChance = 4;

		public const int QualificationGrowthGuaranteed = 5;

		public const int QualificationGrowthPersonality = 6;

		public const int QualificationGrowthMentor = 7;

		public const int ReadingTriggerChance = 31;

		public const int ReadingScoreCurrSectAdjust = 32;

		public const int ReadingScoreIdealSectAdjust = 33;

		public const int ReadingScoreQualification = 34;

		public const int ReadingScoreCompleteState = 35;

		public const int ReadingScorePersonalNeed = 36;

		public const int ReadingScoreBuildingRequiredType = 37;

		public const int LoopingScoreGrade = 16;

		public const int LoopingScorePotentialNeili = 17;

		public const int LoopingScorePotentialExtraAllocation = 30;

		public const int LoopingScoreCurrSectNotCounter = 18;

		public const int LoopingScoreCurrSectDestType = 19;

		public const int LoopingScoreCurrSectTransferCounter = 20;

		public const int LoopingScoreIdealSectNotCounter = 21;

		public const int LoopingScoreIdealSectDestType = 22;

		public const int LoopingScoreIdealSectTransferCounter = 29;

		public const int EquippingScoreCurrSect = 23;

		public const int EquippingScoreIdealSect = 24;

		public const int EquippingScoreNotCounter = 25;

		public const int EquippingScoreGrade = 26;

		public const int EquippingScoreSkillPower = 27;

		public const int EquippingScoreBreakout = 28;

		public const int EquippingScoreLegendaryBook = 38;

		public const int StartRelationChance = 39;

		public const int GoodLuckEventHealth = 8;

		public const int GoodLuckEventInjury = 9;

		public const int GoodLuckEventPoison = 10;

		public const int GoodLuckEventQi = 11;

		public const int BadLuckEventHealth = 12;

		public const int BadLuckEventInjury = 13;

		public const int BadLuckEventPoison = 14;

		public const int BadLuckEventQi = 15;
	}

	public static class DefValue
	{
		public static AdvancingMonthFormulaItem JieqingAssassinateChance => Instance[0];

		public static AdvancingMonthFormulaItem JieqingAssassinateChanceWuYing => Instance[1];

		public static AdvancingMonthFormulaItem JieqingAssassinatePrisonerChance => Instance[2];

		public static AdvancingMonthFormulaItem JieqingAssassinatePrisonerChanceWuYing => Instance[3];

		public static AdvancingMonthFormulaItem QualificationGrowthTriggerChance => Instance[4];

		public static AdvancingMonthFormulaItem QualificationGrowthGuaranteed => Instance[5];

		public static AdvancingMonthFormulaItem QualificationGrowthPersonality => Instance[6];

		public static AdvancingMonthFormulaItem QualificationGrowthMentor => Instance[7];

		public static AdvancingMonthFormulaItem ReadingTriggerChance => Instance[31];

		public static AdvancingMonthFormulaItem ReadingScoreCurrSectAdjust => Instance[32];

		public static AdvancingMonthFormulaItem ReadingScoreIdealSectAdjust => Instance[33];

		public static AdvancingMonthFormulaItem ReadingScoreQualification => Instance[34];

		public static AdvancingMonthFormulaItem ReadingScoreCompleteState => Instance[35];

		public static AdvancingMonthFormulaItem ReadingScorePersonalNeed => Instance[36];

		public static AdvancingMonthFormulaItem ReadingScoreBuildingRequiredType => Instance[37];

		public static AdvancingMonthFormulaItem LoopingScoreGrade => Instance[16];

		public static AdvancingMonthFormulaItem LoopingScorePotentialNeili => Instance[17];

		public static AdvancingMonthFormulaItem LoopingScorePotentialExtraAllocation => Instance[30];

		public static AdvancingMonthFormulaItem LoopingScoreCurrSectNotCounter => Instance[18];

		public static AdvancingMonthFormulaItem LoopingScoreCurrSectDestType => Instance[19];

		public static AdvancingMonthFormulaItem LoopingScoreCurrSectTransferCounter => Instance[20];

		public static AdvancingMonthFormulaItem LoopingScoreIdealSectNotCounter => Instance[21];

		public static AdvancingMonthFormulaItem LoopingScoreIdealSectDestType => Instance[22];

		public static AdvancingMonthFormulaItem LoopingScoreIdealSectTransferCounter => Instance[29];

		public static AdvancingMonthFormulaItem EquippingScoreCurrSect => Instance[23];

		public static AdvancingMonthFormulaItem EquippingScoreIdealSect => Instance[24];

		public static AdvancingMonthFormulaItem EquippingScoreNotCounter => Instance[25];

		public static AdvancingMonthFormulaItem EquippingScoreGrade => Instance[26];

		public static AdvancingMonthFormulaItem EquippingScoreSkillPower => Instance[27];

		public static AdvancingMonthFormulaItem EquippingScoreBreakout => Instance[28];

		public static AdvancingMonthFormulaItem EquippingScoreLegendaryBook => Instance[38];

		public static AdvancingMonthFormulaItem StartRelationChance => Instance[39];

		public static AdvancingMonthFormulaItem GoodLuckEventHealth => Instance[8];

		public static AdvancingMonthFormulaItem GoodLuckEventInjury => Instance[9];

		public static AdvancingMonthFormulaItem GoodLuckEventPoison => Instance[10];

		public static AdvancingMonthFormulaItem GoodLuckEventQi => Instance[11];

		public static AdvancingMonthFormulaItem BadLuckEventHealth => Instance[12];

		public static AdvancingMonthFormulaItem BadLuckEventInjury => Instance[13];

		public static AdvancingMonthFormulaItem BadLuckEventPoison => Instance[14];

		public static AdvancingMonthFormulaItem BadLuckEventQi => Instance[15];
	}

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
