using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class InteractCheckTip : ConfigData<InteractCheckTipItem, short>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 互动-敌对-唬骗-辨认目标
		/// </summary>
		public const short ScamActionRecognizeTarget = 0;

		/// <summary>
		/// 互动-敌对-唬骗-隐藏潜伏
		/// </summary>
		public const short ScamActionStayHidden = 1;

		/// <summary>
		/// 互动-敌对-唬骗-判断时机
		/// </summary>
		public const short ScamActionWaitForGoodTiming = 2;

		/// <summary>
		/// 互动-敌对-唬骗-逃跑
		/// </summary>
		public const short ScamActionOnTheWay = 3;

		/// <summary>
		/// 互动-敌对-窃取-辨认目标
		/// </summary>
		public const short StealActionRecognizeTarget = 4;

		/// <summary>
		/// 互动-敌对-窃取-隐藏潜伏
		/// </summary>
		public const short StealActionStayHidden = 5;

		/// <summary>
		/// 互动-敌对-窃取-判断时机
		/// </summary>
		public const short StealActionWaitForGoodTiming = 6;

		/// <summary>
		/// 互动-敌对-窃取-果断行动
		/// </summary>
		public const short StealActionTakeAction = 7;

		/// <summary>
		/// 互动-敌对-窃取-逃跑
		/// </summary>
		public const short StealActionOnTheWay = 8;

		/// <summary>
		/// 互动-敌对-抢夺-辨认目标
		/// </summary>
		public const short RobActionRecognizeTarget = 9;

		/// <summary>
		/// 互动-敌对-抢夺-隐藏潜伏
		/// </summary>
		public const short RobActionStayHidden = 10;

		/// <summary>
		/// 互动-敌对-抢夺-判断时机
		/// </summary>
		public const short RobActionWaitForGoodTiming = 11;

		/// <summary>
		/// 互动-敌对-抢夺-果断行动
		/// </summary>
		public const short RobActionTakeAction = 12;

		/// <summary>
		/// 互动-敌对-抢夺-逃跑
		/// </summary>
		public const short RobActionOneTheWay = 13;

		/// <summary>
		/// 互动-敌对-毒害-辨认目标
		/// </summary>
		public const short PoisonActionRecognizeTarget = 14;

		/// <summary>
		/// 互动-敌对-毒害-隐藏潜伏
		/// </summary>
		public const short PoisonActionStayHidden = 15;

		/// <summary>
		/// 互动-敌对-毒害-判断时机
		/// </summary>
		public const short PoisonActionWaitForGoodTiming = 16;

		/// <summary>
		/// 互动-敌对-毒害-果断行动
		/// </summary>
		public const short PoisonActionTakeAction = 17;

		/// <summary>
		/// 互动-敌对-毒害-逃跑
		/// </summary>
		public const short PoisonActionOneTheWay = 18;

		/// <summary>
		/// 互动-敌对-暗中损害-辨认目标
		/// </summary>
		public const short PlotHarmActionRecognizeTarget = 19;

		/// <summary>
		/// 互动-敌对-暗中损害-隐藏潜伏
		/// </summary>
		public const short PlotHarmActionStayHidden = 20;

		/// <summary>
		/// 互动-敌对-暗中损害-判断时机
		/// </summary>
		public const short PlotHarmActionWaitForGoodTiming = 21;

		/// <summary>
		/// 互动-敌对-暗中损害-果断行动
		/// </summary>
		public const short PlotHarmActionTakeAction = 22;

		/// <summary>
		/// 互动-敌对-暗中损害-逃跑
		/// </summary>
		public const short PlotHarmActionOneTheWay = 23;

		/// <summary>
		/// 互动-亲近-倾诉爱意-爱慕因素
		/// </summary>
		public const short ConfessionLovePureFactor = 24;

		/// <summary>
		/// 互动-亲近-倾诉爱意-世俗因素
		/// </summary>
		public const short ConfessionLoveSecularFactor = 25;

		/// <summary>
		/// 互动-修习-偷师技艺-辨认目标
		/// </summary>
		public const short StealLifeSkillActionRecognizeTarget = 26;

		/// <summary>
		/// 互动-修习-偷师技艺-隐藏潜伏
		/// </summary>
		public const short StealLifeSkillActionStayHidden = 27;

		/// <summary>
		/// 互动-修习-偷师技艺-判断时机
		/// </summary>
		public const short StealLifeSkillActionWaitForGoodTiming = 28;

		/// <summary>
		/// 互动-修习-偷师技艺-果断行动
		/// </summary>
		public const short StealLifeSkillActionTakeAction = 29;

		/// <summary>
		/// 互动-修习-偷师技艺-逃跑
		/// </summary>
		public const short StealLifeSkillActionOnTheWay = 30;

		/// <summary>
		/// 互动-修习-偷师功法-辨认目标
		/// </summary>
		public const short StealCombatSkillActionRecognizeTarget = 31;

		/// <summary>
		/// 互动-修习-偷师功法-隐藏潜伏
		/// </summary>
		public const short StealCombatSkillActionStayHidden = 32;

		/// <summary>
		/// 互动-修习-偷师功法-判断时机
		/// </summary>
		public const short StealCombatSkillActionWaitForGoodTiming = 33;

		/// <summary>
		/// 互动-修习-偷师功法-果断行动
		/// </summary>
		public const short StealCombatSkillActionTakeAction = 34;

		/// <summary>
		/// 互动-修习-偷师功法-逃跑
		/// </summary>
		public const short StealCombatSkillActionOnTheWay = 35;

		/// <summary>
		/// 互动-敌对-唬骗-果断行动
		/// </summary>
		public const short ScamActionTakeAction = 36;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 互动-敌对-唬骗-辨认目标
		/// </summary>
		public static InteractCheckTipItem ScamActionRecognizeTarget => Instance[(short)0];

		/// <summary>
		/// 互动-敌对-唬骗-隐藏潜伏
		/// </summary>
		public static InteractCheckTipItem ScamActionStayHidden => Instance[(short)1];

		/// <summary>
		/// 互动-敌对-唬骗-判断时机
		/// </summary>
		public static InteractCheckTipItem ScamActionWaitForGoodTiming => Instance[(short)2];

		/// <summary>
		/// 互动-敌对-唬骗-逃跑
		/// </summary>
		public static InteractCheckTipItem ScamActionOnTheWay => Instance[(short)3];

		/// <summary>
		/// 互动-敌对-窃取-辨认目标
		/// </summary>
		public static InteractCheckTipItem StealActionRecognizeTarget => Instance[(short)4];

		/// <summary>
		/// 互动-敌对-窃取-隐藏潜伏
		/// </summary>
		public static InteractCheckTipItem StealActionStayHidden => Instance[(short)5];

		/// <summary>
		/// 互动-敌对-窃取-判断时机
		/// </summary>
		public static InteractCheckTipItem StealActionWaitForGoodTiming => Instance[(short)6];

		/// <summary>
		/// 互动-敌对-窃取-果断行动
		/// </summary>
		public static InteractCheckTipItem StealActionTakeAction => Instance[(short)7];

		/// <summary>
		/// 互动-敌对-窃取-逃跑
		/// </summary>
		public static InteractCheckTipItem StealActionOnTheWay => Instance[(short)8];

		/// <summary>
		/// 互动-敌对-抢夺-辨认目标
		/// </summary>
		public static InteractCheckTipItem RobActionRecognizeTarget => Instance[(short)9];

		/// <summary>
		/// 互动-敌对-抢夺-隐藏潜伏
		/// </summary>
		public static InteractCheckTipItem RobActionStayHidden => Instance[(short)10];

		/// <summary>
		/// 互动-敌对-抢夺-判断时机
		/// </summary>
		public static InteractCheckTipItem RobActionWaitForGoodTiming => Instance[(short)11];

		/// <summary>
		/// 互动-敌对-抢夺-果断行动
		/// </summary>
		public static InteractCheckTipItem RobActionTakeAction => Instance[(short)12];

		/// <summary>
		/// 互动-敌对-抢夺-逃跑
		/// </summary>
		public static InteractCheckTipItem RobActionOneTheWay => Instance[(short)13];

		/// <summary>
		/// 互动-敌对-毒害-辨认目标
		/// </summary>
		public static InteractCheckTipItem PoisonActionRecognizeTarget => Instance[(short)14];

		/// <summary>
		/// 互动-敌对-毒害-隐藏潜伏
		/// </summary>
		public static InteractCheckTipItem PoisonActionStayHidden => Instance[(short)15];

		/// <summary>
		/// 互动-敌对-毒害-判断时机
		/// </summary>
		public static InteractCheckTipItem PoisonActionWaitForGoodTiming => Instance[(short)16];

		/// <summary>
		/// 互动-敌对-毒害-果断行动
		/// </summary>
		public static InteractCheckTipItem PoisonActionTakeAction => Instance[(short)17];

		/// <summary>
		/// 互动-敌对-毒害-逃跑
		/// </summary>
		public static InteractCheckTipItem PoisonActionOneTheWay => Instance[(short)18];

		/// <summary>
		/// 互动-敌对-暗中损害-辨认目标
		/// </summary>
		public static InteractCheckTipItem PlotHarmActionRecognizeTarget => Instance[(short)19];

		/// <summary>
		/// 互动-敌对-暗中损害-隐藏潜伏
		/// </summary>
		public static InteractCheckTipItem PlotHarmActionStayHidden => Instance[(short)20];

		/// <summary>
		/// 互动-敌对-暗中损害-判断时机
		/// </summary>
		public static InteractCheckTipItem PlotHarmActionWaitForGoodTiming => Instance[(short)21];

		/// <summary>
		/// 互动-敌对-暗中损害-果断行动
		/// </summary>
		public static InteractCheckTipItem PlotHarmActionTakeAction => Instance[(short)22];

		/// <summary>
		/// 互动-敌对-暗中损害-逃跑
		/// </summary>
		public static InteractCheckTipItem PlotHarmActionOneTheWay => Instance[(short)23];

		/// <summary>
		/// 互动-亲近-倾诉爱意-爱慕因素
		/// </summary>
		public static InteractCheckTipItem ConfessionLovePureFactor => Instance[(short)24];

		/// <summary>
		/// 互动-亲近-倾诉爱意-世俗因素
		/// </summary>
		public static InteractCheckTipItem ConfessionLoveSecularFactor => Instance[(short)25];

		/// <summary>
		/// 互动-修习-偷师技艺-辨认目标
		/// </summary>
		public static InteractCheckTipItem StealLifeSkillActionRecognizeTarget => Instance[(short)26];

		/// <summary>
		/// 互动-修习-偷师技艺-隐藏潜伏
		/// </summary>
		public static InteractCheckTipItem StealLifeSkillActionStayHidden => Instance[(short)27];

		/// <summary>
		/// 互动-修习-偷师技艺-判断时机
		/// </summary>
		public static InteractCheckTipItem StealLifeSkillActionWaitForGoodTiming => Instance[(short)28];

		/// <summary>
		/// 互动-修习-偷师技艺-果断行动
		/// </summary>
		public static InteractCheckTipItem StealLifeSkillActionTakeAction => Instance[(short)29];

		/// <summary>
		/// 互动-修习-偷师技艺-逃跑
		/// </summary>
		public static InteractCheckTipItem StealLifeSkillActionOnTheWay => Instance[(short)30];

		/// <summary>
		/// 互动-修习-偷师功法-辨认目标
		/// </summary>
		public static InteractCheckTipItem StealCombatSkillActionRecognizeTarget => Instance[(short)31];

		/// <summary>
		/// 互动-修习-偷师功法-隐藏潜伏
		/// </summary>
		public static InteractCheckTipItem StealCombatSkillActionStayHidden => Instance[(short)32];

		/// <summary>
		/// 互动-修习-偷师功法-判断时机
		/// </summary>
		public static InteractCheckTipItem StealCombatSkillActionWaitForGoodTiming => Instance[(short)33];

		/// <summary>
		/// 互动-修习-偷师功法-果断行动
		/// </summary>
		public static InteractCheckTipItem StealCombatSkillActionTakeAction => Instance[(short)34];

		/// <summary>
		/// 互动-修习-偷师功法-逃跑
		/// </summary>
		public static InteractCheckTipItem StealCombatSkillActionOnTheWay => Instance[(short)35];

		/// <summary>
		/// 互动-敌对-唬骗-果断行动
		/// </summary>
		public static InteractCheckTipItem ScamActionTakeAction => Instance[(short)36];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static InteractCheckTip Instance = new InteractCheckTip();

	private readonly HashSet<string> RequiredFields = new HashSet<string>
	{
		"PhaseName", "PhaseDesc", "CheckDesc", "SelfCheckCharacterProperty", "TargetCheckCharacterProperty", "SelfCheckAttainmentCombatSkillType", "TargetCheckAttainmentCombatSkillType", "SelfCheckAttainmentLifeSkillType", "TargetCheckAttainmentLifeSkillType", "CheckResultProb",
		"FactorDesc", "TemplateId", "PhaseIcon"
	};

	internal override int ToInt(short value)
	{
		return value;
	}

	internal override short ToTemplateId(int value)
	{
		return (short)value;
	}

	private void CreateItems0()
	{
		_dataArray.Add(new InteractCheckTipItem(0, LocalStringManager.GetConfig("InteractCheckTip_language", "PhaseName_0"), LocalStringManager.GetConfig("InteractCheckTip_language", "PhaseDesc_0"), "tex_taiwuevent_judge_1_0", LocalStringManager.GetConfig("InteractCheckTip_language", "CheckDesc_0"), 2, -1, -1, -1, -1, -1, EInteractCheckTipSpecialValueDisplayType.Invalid, LocalStringManager.GetConfig("InteractCheckTip_language", "CheckResultProb_0"), EInteractCheckTipConfessionLoveFactorType.Invalid, new string[0], EInteractCheckTipSpecialLineDisplayType.Invalid));
		_dataArray.Add(new InteractCheckTipItem(1, LocalStringManager.GetConfig("InteractCheckTip_language", "PhaseName_1"), LocalStringManager.GetConfig("InteractCheckTip_language", "PhaseDesc_1"), "tex_taiwuevent_judge_1_1", LocalStringManager.GetConfig("InteractCheckTip_language", "CheckDesc_1"), -1, -1, 1, 1, -1, -1, EInteractCheckTipSpecialValueDisplayType.Invalid, LocalStringManager.GetConfig("InteractCheckTip_language", "CheckResultProb_1"), EInteractCheckTipConfessionLoveFactorType.Invalid, new string[1] { LocalStringManager.GetConfig("InteractCheckTip_language", "FactorDesc_1_0") }, EInteractCheckTipSpecialLineDisplayType.Alert));
		_dataArray.Add(new InteractCheckTipItem(2, LocalStringManager.GetConfig("InteractCheckTip_language", "PhaseName_2"), LocalStringManager.GetConfig("InteractCheckTip_language", "PhaseDesc_2"), "tex_taiwuevent_judge_1_2", LocalStringManager.GetConfig("InteractCheckTip_language", "CheckDesc_2"), 9, 15, -1, -1, -1, -1, EInteractCheckTipSpecialValueDisplayType.Invalid, LocalStringManager.GetConfig("InteractCheckTip_language", "CheckResultProb_2"), EInteractCheckTipConfessionLoveFactorType.Invalid, new string[1] { LocalStringManager.GetConfig("InteractCheckTip_language", "FactorDesc_2_0") }, EInteractCheckTipSpecialLineDisplayType.Alert));
		_dataArray.Add(new InteractCheckTipItem(3, LocalStringManager.GetConfig("InteractCheckTip_language", "PhaseName_3"), LocalStringManager.GetConfig("InteractCheckTip_language", "PhaseDesc_3"), "tex_taiwuevent_judge_1_4", LocalStringManager.GetConfig("InteractCheckTip_language", "CheckDesc_3"), 15, 9, -1, -1, -1, -1, EInteractCheckTipSpecialValueDisplayType.Invalid, LocalStringManager.GetConfig("InteractCheckTip_language", "CheckResultProb_3"), EInteractCheckTipConfessionLoveFactorType.Invalid, new string[1] { LocalStringManager.GetConfig("InteractCheckTip_language", "FactorDesc_3_0") }, EInteractCheckTipSpecialLineDisplayType.Alert));
		_dataArray.Add(new InteractCheckTipItem(4, LocalStringManager.GetConfig("InteractCheckTip_language", "PhaseName_4"), LocalStringManager.GetConfig("InteractCheckTip_language", "PhaseDesc_4"), "tex_taiwuevent_judge_1_0", LocalStringManager.GetConfig("InteractCheckTip_language", "CheckDesc_4"), 1, -1, -1, -1, -1, -1, EInteractCheckTipSpecialValueDisplayType.Invalid, LocalStringManager.GetConfig("InteractCheckTip_language", "CheckResultProb_4"), EInteractCheckTipConfessionLoveFactorType.Invalid, new string[0], EInteractCheckTipSpecialLineDisplayType.Invalid));
		_dataArray.Add(new InteractCheckTipItem(5, LocalStringManager.GetConfig("InteractCheckTip_language", "PhaseName_5"), LocalStringManager.GetConfig("InteractCheckTip_language", "PhaseDesc_5"), "tex_taiwuevent_judge_1_1", LocalStringManager.GetConfig("InteractCheckTip_language", "CheckDesc_5"), -1, -1, 1, 1, -1, -1, EInteractCheckTipSpecialValueDisplayType.Invalid, LocalStringManager.GetConfig("InteractCheckTip_language", "CheckResultProb_5"), EInteractCheckTipConfessionLoveFactorType.Invalid, new string[1] { LocalStringManager.GetConfig("InteractCheckTip_language", "FactorDesc_5_0") }, EInteractCheckTipSpecialLineDisplayType.Alert));
		_dataArray.Add(new InteractCheckTipItem(6, LocalStringManager.GetConfig("InteractCheckTip_language", "PhaseName_6"), LocalStringManager.GetConfig("InteractCheckTip_language", "PhaseDesc_6"), "tex_taiwuevent_judge_1_2", LocalStringManager.GetConfig("InteractCheckTip_language", "CheckDesc_6"), 8, 14, -1, -1, -1, -1, EInteractCheckTipSpecialValueDisplayType.Invalid, LocalStringManager.GetConfig("InteractCheckTip_language", "CheckResultProb_6"), EInteractCheckTipConfessionLoveFactorType.Invalid, new string[1] { LocalStringManager.GetConfig("InteractCheckTip_language", "FactorDesc_6_0") }, EInteractCheckTipSpecialLineDisplayType.Alert));
		_dataArray.Add(new InteractCheckTipItem(7, LocalStringManager.GetConfig("InteractCheckTip_language", "PhaseName_7"), LocalStringManager.GetConfig("InteractCheckTip_language", "PhaseDesc_7"), "tex_taiwuevent_judge_1_3", LocalStringManager.GetConfig("InteractCheckTip_language", "CheckDesc_7"), 20, 20, -1, -1, -1, -1, EInteractCheckTipSpecialValueDisplayType.Invalid, LocalStringManager.GetConfig("InteractCheckTip_language", "CheckResultProb_7"), EInteractCheckTipConfessionLoveFactorType.Invalid, new string[1] { LocalStringManager.GetConfig("InteractCheckTip_language", "FactorDesc_7_0") }, EInteractCheckTipSpecialLineDisplayType.Alert));
		_dataArray.Add(new InteractCheckTipItem(8, LocalStringManager.GetConfig("InteractCheckTip_language", "PhaseName_8"), LocalStringManager.GetConfig("InteractCheckTip_language", "PhaseDesc_8"), "tex_taiwuevent_judge_1_4", LocalStringManager.GetConfig("InteractCheckTip_language", "CheckDesc_8"), 14, 8, -1, -1, -1, -1, EInteractCheckTipSpecialValueDisplayType.Invalid, LocalStringManager.GetConfig("InteractCheckTip_language", "CheckResultProb_8"), EInteractCheckTipConfessionLoveFactorType.Invalid, new string[1] { LocalStringManager.GetConfig("InteractCheckTip_language", "FactorDesc_8_0") }, EInteractCheckTipSpecialLineDisplayType.Alert));
		_dataArray.Add(new InteractCheckTipItem(9, LocalStringManager.GetConfig("InteractCheckTip_language", "PhaseName_9"), LocalStringManager.GetConfig("InteractCheckTip_language", "PhaseDesc_9"), "tex_taiwuevent_judge_1_0", LocalStringManager.GetConfig("InteractCheckTip_language", "CheckDesc_9"), 0, -1, -1, -1, -1, -1, EInteractCheckTipSpecialValueDisplayType.Invalid, LocalStringManager.GetConfig("InteractCheckTip_language", "CheckResultProb_9"), EInteractCheckTipConfessionLoveFactorType.Invalid, new string[0], EInteractCheckTipSpecialLineDisplayType.Invalid));
		_dataArray.Add(new InteractCheckTipItem(10, LocalStringManager.GetConfig("InteractCheckTip_language", "PhaseName_10"), LocalStringManager.GetConfig("InteractCheckTip_language", "PhaseDesc_10"), "tex_taiwuevent_judge_1_1", LocalStringManager.GetConfig("InteractCheckTip_language", "CheckDesc_10"), -1, -1, 1, 1, -1, -1, EInteractCheckTipSpecialValueDisplayType.Invalid, LocalStringManager.GetConfig("InteractCheckTip_language", "CheckResultProb_10"), EInteractCheckTipConfessionLoveFactorType.Invalid, new string[1] { LocalStringManager.GetConfig("InteractCheckTip_language", "FactorDesc_10_0") }, EInteractCheckTipSpecialLineDisplayType.Alert));
		_dataArray.Add(new InteractCheckTipItem(11, LocalStringManager.GetConfig("InteractCheckTip_language", "PhaseName_11"), LocalStringManager.GetConfig("InteractCheckTip_language", "PhaseDesc_11"), "tex_taiwuevent_judge_1_2", LocalStringManager.GetConfig("InteractCheckTip_language", "CheckDesc_11"), 6, 12, -1, -1, -1, -1, EInteractCheckTipSpecialValueDisplayType.Invalid, LocalStringManager.GetConfig("InteractCheckTip_language", "CheckResultProb_11"), EInteractCheckTipConfessionLoveFactorType.Invalid, new string[1] { LocalStringManager.GetConfig("InteractCheckTip_language", "FactorDesc_11_0") }, EInteractCheckTipSpecialLineDisplayType.Alert));
		_dataArray.Add(new InteractCheckTipItem(12, LocalStringManager.GetConfig("InteractCheckTip_language", "PhaseName_12"), LocalStringManager.GetConfig("InteractCheckTip_language", "PhaseDesc_12"), "tex_taiwuevent_judge_1_3", LocalStringManager.GetConfig("InteractCheckTip_language", "CheckDesc_12"), -1, -1, -1, -1, -1, -1, EInteractCheckTipSpecialValueDisplayType.Invalid, LocalStringManager.GetConfig("InteractCheckTip_language", "CheckResultProb_12"), EInteractCheckTipConfessionLoveFactorType.Invalid, new string[2]
		{
			LocalStringManager.GetConfig("InteractCheckTip_language", "FactorDesc_12_0"),
			LocalStringManager.GetConfig("InteractCheckTip_language", "FactorDesc_12_1")
		}, EInteractCheckTipSpecialLineDisplayType.AlertAndPower));
		_dataArray.Add(new InteractCheckTipItem(13, LocalStringManager.GetConfig("InteractCheckTip_language", "PhaseName_13"), LocalStringManager.GetConfig("InteractCheckTip_language", "PhaseDesc_13"), "tex_taiwuevent_judge_1_4", LocalStringManager.GetConfig("InteractCheckTip_language", "CheckDesc_13"), 12, 6, -1, -1, -1, -1, EInteractCheckTipSpecialValueDisplayType.Invalid, LocalStringManager.GetConfig("InteractCheckTip_language", "CheckResultProb_13"), EInteractCheckTipConfessionLoveFactorType.Invalid, new string[1] { LocalStringManager.GetConfig("InteractCheckTip_language", "FactorDesc_13_0") }, EInteractCheckTipSpecialLineDisplayType.Alert));
		_dataArray.Add(new InteractCheckTipItem(14, LocalStringManager.GetConfig("InteractCheckTip_language", "PhaseName_14"), LocalStringManager.GetConfig("InteractCheckTip_language", "PhaseDesc_14"), "tex_taiwuevent_judge_1_0", LocalStringManager.GetConfig("InteractCheckTip_language", "CheckDesc_14"), -1, -1, -1, -1, 9, 9, EInteractCheckTipSpecialValueDisplayType.Invalid, LocalStringManager.GetConfig("InteractCheckTip_language", "CheckResultProb_14"), EInteractCheckTipConfessionLoveFactorType.Invalid, new string[0], EInteractCheckTipSpecialLineDisplayType.Invalid));
		_dataArray.Add(new InteractCheckTipItem(15, LocalStringManager.GetConfig("InteractCheckTip_language", "PhaseName_15"), LocalStringManager.GetConfig("InteractCheckTip_language", "PhaseDesc_15"), "tex_taiwuevent_judge_1_1", LocalStringManager.GetConfig("InteractCheckTip_language", "CheckDesc_15"), -1, -1, 1, 1, -1, -1, EInteractCheckTipSpecialValueDisplayType.Invalid, LocalStringManager.GetConfig("InteractCheckTip_language", "CheckResultProb_15"), EInteractCheckTipConfessionLoveFactorType.Invalid, new string[0], EInteractCheckTipSpecialLineDisplayType.Invalid));
		_dataArray.Add(new InteractCheckTipItem(16, LocalStringManager.GetConfig("InteractCheckTip_language", "PhaseName_16"), LocalStringManager.GetConfig("InteractCheckTip_language", "PhaseDesc_16"), "tex_taiwuevent_judge_1_2", LocalStringManager.GetConfig("InteractCheckTip_language", "CheckDesc_16"), 22, 22, -1, -1, -1, -1, EInteractCheckTipSpecialValueDisplayType.Invalid, LocalStringManager.GetConfig("InteractCheckTip_language", "CheckResultProb_16"), EInteractCheckTipConfessionLoveFactorType.Invalid, new string[0], EInteractCheckTipSpecialLineDisplayType.Invalid));
		_dataArray.Add(new InteractCheckTipItem(17, LocalStringManager.GetConfig("InteractCheckTip_language", "PhaseName_17"), LocalStringManager.GetConfig("InteractCheckTip_language", "PhaseDesc_17"), "tex_taiwuevent_judge_1_3", LocalStringManager.GetConfig("InteractCheckTip_language", "CheckDesc_17"), -1, -1, -1, -1, 9, 9, EInteractCheckTipSpecialValueDisplayType.Invalid, LocalStringManager.GetConfig("InteractCheckTip_language", "CheckResultProb_17"), EInteractCheckTipConfessionLoveFactorType.Invalid, new string[0], EInteractCheckTipSpecialLineDisplayType.Invalid));
		_dataArray.Add(new InteractCheckTipItem(18, LocalStringManager.GetConfig("InteractCheckTip_language", "PhaseName_18"), LocalStringManager.GetConfig("InteractCheckTip_language", "PhaseDesc_18"), "tex_taiwuevent_judge_1_4", LocalStringManager.GetConfig("InteractCheckTip_language", "CheckDesc_18"), 17, 11, -1, -1, -1, -1, EInteractCheckTipSpecialValueDisplayType.Invalid, LocalStringManager.GetConfig("InteractCheckTip_language", "CheckResultProb_18"), EInteractCheckTipConfessionLoveFactorType.Invalid, new string[0], EInteractCheckTipSpecialLineDisplayType.Invalid));
		_dataArray.Add(new InteractCheckTipItem(19, LocalStringManager.GetConfig("InteractCheckTip_language", "PhaseName_19"), LocalStringManager.GetConfig("InteractCheckTip_language", "PhaseDesc_19"), "tex_taiwuevent_judge_1_0", LocalStringManager.GetConfig("InteractCheckTip_language", "CheckDesc_19"), -1, -1, -1, -1, 8, 8, EInteractCheckTipSpecialValueDisplayType.Invalid, LocalStringManager.GetConfig("InteractCheckTip_language", "CheckResultProb_19"), EInteractCheckTipConfessionLoveFactorType.Invalid, new string[0], EInteractCheckTipSpecialLineDisplayType.Invalid));
		_dataArray.Add(new InteractCheckTipItem(20, LocalStringManager.GetConfig("InteractCheckTip_language", "PhaseName_20"), LocalStringManager.GetConfig("InteractCheckTip_language", "PhaseDesc_20"), "tex_taiwuevent_judge_1_1", LocalStringManager.GetConfig("InteractCheckTip_language", "CheckDesc_20"), -1, -1, 1, 1, -1, -1, EInteractCheckTipSpecialValueDisplayType.Invalid, LocalStringManager.GetConfig("InteractCheckTip_language", "CheckResultProb_20"), EInteractCheckTipConfessionLoveFactorType.Invalid, new string[0], EInteractCheckTipSpecialLineDisplayType.Invalid));
		_dataArray.Add(new InteractCheckTipItem(21, LocalStringManager.GetConfig("InteractCheckTip_language", "PhaseName_21"), LocalStringManager.GetConfig("InteractCheckTip_language", "PhaseDesc_21"), "tex_taiwuevent_judge_1_2", LocalStringManager.GetConfig("InteractCheckTip_language", "CheckDesc_21"), 25, 25, -1, -1, -1, -1, EInteractCheckTipSpecialValueDisplayType.Invalid, LocalStringManager.GetConfig("InteractCheckTip_language", "CheckResultProb_21"), EInteractCheckTipConfessionLoveFactorType.Invalid, new string[0], EInteractCheckTipSpecialLineDisplayType.Invalid));
		_dataArray.Add(new InteractCheckTipItem(22, LocalStringManager.GetConfig("InteractCheckTip_language", "PhaseName_22"), LocalStringManager.GetConfig("InteractCheckTip_language", "PhaseDesc_22"), "tex_taiwuevent_judge_1_3", LocalStringManager.GetConfig("InteractCheckTip_language", "CheckDesc_22"), -1, -1, -1, -1, 8, 8, EInteractCheckTipSpecialValueDisplayType.Invalid, LocalStringManager.GetConfig("InteractCheckTip_language", "CheckResultProb_22"), EInteractCheckTipConfessionLoveFactorType.Invalid, new string[0], EInteractCheckTipSpecialLineDisplayType.Invalid));
		_dataArray.Add(new InteractCheckTipItem(23, LocalStringManager.GetConfig("InteractCheckTip_language", "PhaseName_23"), LocalStringManager.GetConfig("InteractCheckTip_language", "PhaseDesc_23"), "tex_taiwuevent_judge_1_4", LocalStringManager.GetConfig("InteractCheckTip_language", "CheckDesc_23"), 16, 10, -1, -1, -1, -1, EInteractCheckTipSpecialValueDisplayType.Invalid, LocalStringManager.GetConfig("InteractCheckTip_language", "CheckResultProb_23"), EInteractCheckTipConfessionLoveFactorType.Invalid, new string[0], EInteractCheckTipSpecialLineDisplayType.Invalid));
		_dataArray.Add(new InteractCheckTipItem(24, LocalStringManager.GetConfig("InteractCheckTip_language", "PhaseName_24"), LocalStringManager.GetConfig("InteractCheckTip_language", "PhaseDesc_24"), "tex_taiwuevent_judge_0_1", LocalStringManager.GetConfig("InteractCheckTip_language", "CheckDesc_24"), -1, -1, -1, -1, -1, -1, EInteractCheckTipSpecialValueDisplayType.Invalid, LocalStringManager.GetConfig("InteractCheckTip_language", "CheckResultProb_24"), EInteractCheckTipConfessionLoveFactorType.ConfessionLovePure, new string[7]
		{
			LocalStringManager.GetConfig("InteractCheckTip_language", "FactorDesc_24_0"),
			LocalStringManager.GetConfig("InteractCheckTip_language", "FactorDesc_24_1"),
			LocalStringManager.GetConfig("InteractCheckTip_language", "FactorDesc_24_2"),
			LocalStringManager.GetConfig("InteractCheckTip_language", "FactorDesc_24_3"),
			LocalStringManager.GetConfig("InteractCheckTip_language", "FactorDesc_24_4"),
			LocalStringManager.GetConfig("InteractCheckTip_language", "FactorDesc_24_5"),
			LocalStringManager.GetConfig("InteractCheckTip_language", "FactorDesc_24_6")
		}, EInteractCheckTipSpecialLineDisplayType.LovePure));
		_dataArray.Add(new InteractCheckTipItem(25, LocalStringManager.GetConfig("InteractCheckTip_language", "PhaseName_25"), LocalStringManager.GetConfig("InteractCheckTip_language", "PhaseDesc_25"), "tex_taiwuevent_judge_0_2", LocalStringManager.GetConfig("InteractCheckTip_language", "CheckDesc_25"), -1, -1, -1, -1, -1, -1, EInteractCheckTipSpecialValueDisplayType.Invalid, LocalStringManager.GetConfig("InteractCheckTip_language", "CheckResultProb_25"), EInteractCheckTipConfessionLoveFactorType.ConfessionLoveSecular, new string[7]
		{
			LocalStringManager.GetConfig("InteractCheckTip_language", "FactorDesc_25_0"),
			LocalStringManager.GetConfig("InteractCheckTip_language", "FactorDesc_25_1"),
			LocalStringManager.GetConfig("InteractCheckTip_language", "FactorDesc_25_2"),
			LocalStringManager.GetConfig("InteractCheckTip_language", "FactorDesc_25_3"),
			LocalStringManager.GetConfig("InteractCheckTip_language", "FactorDesc_25_4"),
			LocalStringManager.GetConfig("InteractCheckTip_language", "FactorDesc_25_5"),
			LocalStringManager.GetConfig("InteractCheckTip_language", "FactorDesc_25_6")
		}, EInteractCheckTipSpecialLineDisplayType.LoveSecular));
		_dataArray.Add(new InteractCheckTipItem(26, LocalStringManager.GetConfig("InteractCheckTip_language", "PhaseName_26"), LocalStringManager.GetConfig("InteractCheckTip_language", "PhaseDesc_26"), "tex_taiwuevent_judge_1_0", LocalStringManager.GetConfig("InteractCheckTip_language", "CheckDesc_26"), 5, -1, -1, -1, -1, -1, EInteractCheckTipSpecialValueDisplayType.Invalid, LocalStringManager.GetConfig("InteractCheckTip_language", "CheckResultProb_26"), EInteractCheckTipConfessionLoveFactorType.Invalid, new string[0], EInteractCheckTipSpecialLineDisplayType.Invalid));
		_dataArray.Add(new InteractCheckTipItem(27, LocalStringManager.GetConfig("InteractCheckTip_language", "PhaseName_27"), LocalStringManager.GetConfig("InteractCheckTip_language", "PhaseDesc_27"), "tex_taiwuevent_judge_1_1", LocalStringManager.GetConfig("InteractCheckTip_language", "CheckDesc_27"), -1, -1, 1, 1, -1, -1, EInteractCheckTipSpecialValueDisplayType.Invalid, LocalStringManager.GetConfig("InteractCheckTip_language", "CheckResultProb_27"), EInteractCheckTipConfessionLoveFactorType.Invalid, new string[1] { LocalStringManager.GetConfig("InteractCheckTip_language", "FactorDesc_27_0") }, EInteractCheckTipSpecialLineDisplayType.Alert));
		_dataArray.Add(new InteractCheckTipItem(28, LocalStringManager.GetConfig("InteractCheckTip_language", "PhaseName_28"), LocalStringManager.GetConfig("InteractCheckTip_language", "PhaseDesc_28"), "tex_taiwuevent_judge_1_2", LocalStringManager.GetConfig("InteractCheckTip_language", "CheckDesc_28"), 7, 13, -1, -1, -1, -1, EInteractCheckTipSpecialValueDisplayType.Invalid, LocalStringManager.GetConfig("InteractCheckTip_language", "CheckResultProb_28"), EInteractCheckTipConfessionLoveFactorType.Invalid, new string[1] { LocalStringManager.GetConfig("InteractCheckTip_language", "FactorDesc_28_0") }, EInteractCheckTipSpecialLineDisplayType.Alert));
		_dataArray.Add(new InteractCheckTipItem(29, LocalStringManager.GetConfig("InteractCheckTip_language", "PhaseName_29"), LocalStringManager.GetConfig("InteractCheckTip_language", "PhaseDesc_29"), "tex_taiwuevent_judge_1_3", LocalStringManager.GetConfig("InteractCheckTip_language", "CheckDesc_29"), -1, -1, -1, -1, -1, -1, EInteractCheckTipSpecialValueDisplayType.StealSkillLifeSkillQualities, LocalStringManager.GetConfig("InteractCheckTip_language", "CheckResultProb_29"), EInteractCheckTipConfessionLoveFactorType.Invalid, new string[1] { LocalStringManager.GetConfig("InteractCheckTip_language", "FactorDesc_29_0") }, EInteractCheckTipSpecialLineDisplayType.Alert));
		_dataArray.Add(new InteractCheckTipItem(30, LocalStringManager.GetConfig("InteractCheckTip_language", "PhaseName_30"), LocalStringManager.GetConfig("InteractCheckTip_language", "PhaseDesc_30"), "tex_taiwuevent_judge_1_4", LocalStringManager.GetConfig("InteractCheckTip_language", "CheckDesc_30"), 13, 7, -1, -1, -1, -1, EInteractCheckTipSpecialValueDisplayType.Invalid, LocalStringManager.GetConfig("InteractCheckTip_language", "CheckResultProb_30"), EInteractCheckTipConfessionLoveFactorType.Invalid, new string[1] { LocalStringManager.GetConfig("InteractCheckTip_language", "FactorDesc_30_0") }, EInteractCheckTipSpecialLineDisplayType.Alert));
		_dataArray.Add(new InteractCheckTipItem(31, LocalStringManager.GetConfig("InteractCheckTip_language", "PhaseName_31"), LocalStringManager.GetConfig("InteractCheckTip_language", "PhaseDesc_31"), "tex_taiwuevent_judge_1_0", LocalStringManager.GetConfig("InteractCheckTip_language", "CheckDesc_31"), 5, -1, -1, -1, -1, -1, EInteractCheckTipSpecialValueDisplayType.Invalid, LocalStringManager.GetConfig("InteractCheckTip_language", "CheckResultProb_31"), EInteractCheckTipConfessionLoveFactorType.Invalid, new string[0], EInteractCheckTipSpecialLineDisplayType.Invalid));
		_dataArray.Add(new InteractCheckTipItem(32, LocalStringManager.GetConfig("InteractCheckTip_language", "PhaseName_32"), LocalStringManager.GetConfig("InteractCheckTip_language", "PhaseDesc_32"), "tex_taiwuevent_judge_1_1", LocalStringManager.GetConfig("InteractCheckTip_language", "CheckDesc_32"), -1, -1, 1, 1, -1, -1, EInteractCheckTipSpecialValueDisplayType.Invalid, LocalStringManager.GetConfig("InteractCheckTip_language", "CheckResultProb_32"), EInteractCheckTipConfessionLoveFactorType.Invalid, new string[1] { LocalStringManager.GetConfig("InteractCheckTip_language", "FactorDesc_32_0") }, EInteractCheckTipSpecialLineDisplayType.Alert));
		_dataArray.Add(new InteractCheckTipItem(33, LocalStringManager.GetConfig("InteractCheckTip_language", "PhaseName_33"), LocalStringManager.GetConfig("InteractCheckTip_language", "PhaseDesc_33"), "tex_taiwuevent_judge_1_2", LocalStringManager.GetConfig("InteractCheckTip_language", "CheckDesc_33"), 7, 13, -1, -1, -1, -1, EInteractCheckTipSpecialValueDisplayType.Invalid, LocalStringManager.GetConfig("InteractCheckTip_language", "CheckResultProb_33"), EInteractCheckTipConfessionLoveFactorType.Invalid, new string[1] { LocalStringManager.GetConfig("InteractCheckTip_language", "FactorDesc_33_0") }, EInteractCheckTipSpecialLineDisplayType.Alert));
		_dataArray.Add(new InteractCheckTipItem(34, LocalStringManager.GetConfig("InteractCheckTip_language", "PhaseName_34"), LocalStringManager.GetConfig("InteractCheckTip_language", "PhaseDesc_34"), "tex_taiwuevent_judge_1_3", LocalStringManager.GetConfig("InteractCheckTip_language", "CheckDesc_34"), -1, -1, -1, -1, -1, -1, EInteractCheckTipSpecialValueDisplayType.StealSkillCombatSkillQualities, LocalStringManager.GetConfig("InteractCheckTip_language", "CheckResultProb_34"), EInteractCheckTipConfessionLoveFactorType.Invalid, new string[1] { LocalStringManager.GetConfig("InteractCheckTip_language", "FactorDesc_34_0") }, EInteractCheckTipSpecialLineDisplayType.Alert));
		_dataArray.Add(new InteractCheckTipItem(35, LocalStringManager.GetConfig("InteractCheckTip_language", "PhaseName_35"), LocalStringManager.GetConfig("InteractCheckTip_language", "PhaseDesc_35"), "tex_taiwuevent_judge_1_4", LocalStringManager.GetConfig("InteractCheckTip_language", "CheckDesc_35"), 13, 7, -1, -1, -1, -1, EInteractCheckTipSpecialValueDisplayType.Invalid, LocalStringManager.GetConfig("InteractCheckTip_language", "CheckResultProb_35"), EInteractCheckTipConfessionLoveFactorType.Invalid, new string[1] { LocalStringManager.GetConfig("InteractCheckTip_language", "FactorDesc_35_0") }, EInteractCheckTipSpecialLineDisplayType.Alert));
		_dataArray.Add(new InteractCheckTipItem(36, LocalStringManager.GetConfig("InteractCheckTip_language", "PhaseName_36"), LocalStringManager.GetConfig("InteractCheckTip_language", "PhaseDesc_36"), "tex_taiwuevent_judge_1_3", LocalStringManager.GetConfig("InteractCheckTip_language", "CheckDesc_36"), -1, -1, -1, -1, -1, -1, EInteractCheckTipSpecialValueDisplayType.Invalid, LocalStringManager.GetConfig("InteractCheckTip_language", "CheckResultProb_36"), EInteractCheckTipConfessionLoveFactorType.Invalid, new string[1] { LocalStringManager.GetConfig("InteractCheckTip_language", "FactorDesc_36_0") }, EInteractCheckTipSpecialLineDisplayType.Alert));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<InteractCheckTipItem>(37);
		CreateItems0();
	}
}
