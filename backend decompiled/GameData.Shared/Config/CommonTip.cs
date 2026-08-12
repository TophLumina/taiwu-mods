using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class CommonTip : ConfigData<CommonTipItem, int>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 调试
		/// </summary>
		public const int DebugTip = 0;

		/// <summary>
		/// 毒素情况
		/// </summary>
		public const int AttachedPoison = 7;

		/// <summary>
		/// 建设空间
		/// </summary>
		public const int BuildingArea = 8;

		/// <summary>
		/// 宴堂效果
		/// </summary>
		public const int BuildingFeast = 9;

		/// <summary>
		/// 建筑规模
		/// </summary>
		public const int BuildingLevel = 10;

		/// <summary>
		/// 主事教学
		/// </summary>
		public const int BuildingTeachBook = 11;

		/// <summary>
		/// 六道轮回信息
		/// </summary>
		public const int Destiny = 12;

		/// <summary>
		/// 蛟养育方针
		/// </summary>
		public const int JiaoNurturance = 13;

		/// <summary>
		/// 主事服众
		/// </summary>
		public const int MatchVillagerRole = 14;

		/// <summary>
		/// 木人实战模式
		/// </summary>
		public const int PracticeRoomActualMode = 15;

		/// <summary>
		/// 木人训练模式
		/// </summary>
		public const int PracticeRoomPracticeMode = 16;

		/// <summary>
		/// 代制进度
		/// </summary>
		public const int ProductAddProgress = 17;

		/// <summary>
		/// 库房规模
		/// </summary>
		public const int SettlementTreasuryOrPrisonLayer = 18;

		/// <summary>
		/// 奇纹星台建造
		/// </summary>
		public const int SpecialBuild_Qwxt_Complete = 19;

		/// <summary>
		/// 奇纹星台撤除
		/// </summary>
		public const int SpecialBuild_Qwxt_Unbuilt = 20;

		/// <summary>
		/// 心材获取冷却
		/// </summary>
		public const int UpdateBlock = 21;

		/// <summary>
		/// 年龄
		/// </summary>
		public const int Age = 22;

		/// <summary>
		/// 身体部位
		/// </summary>
		public const int BodyPart = 23;

		/// <summary>
		/// 人物毒素
		/// </summary>
		public const int CharacterPoison = 24;

		/// <summary>
		/// 人物内息
		/// </summary>
		public const int DisorderOfQi = 25;

		/// <summary>
		/// 服食栏位蛊
		/// </summary>
		public const int EatingWug = 26;

		/// <summary>
		/// 装备负重
		/// </summary>
		public const int EquipLoad = 27;

		/// <summary>
		/// 人物特性
		/// </summary>
		public const int Feature = 28;

		/// <summary>
		/// 人物策略
		/// </summary>
		public const int FeatureMedalLegacy = 29;

		/// <summary>
		/// 内力五行属性
		/// </summary>
		public const int FiveElements = 30;

		/// <summary>
		/// 主动仇恨
		/// </summary>
		public const int HateButton = 31;

		/// <summary>
		/// 主动爱慕
		/// </summary>
		public const int LoveButton = 32;

		/// <summary>
		/// 人物身份
		/// </summary>
		public const int Identity = 33;

		/// <summary>
		/// 见闻效果
		/// </summary>
		public const int InformationEffect = 34;

		/// <summary>
		/// 混合毒素
		/// </summary>
		public const int MixPoison = 35;

		/// <summary>
		/// 人物从属
		/// </summary>
		public const int Organization = 36;

		/// <summary>
		/// 抵抗值
		/// </summary>
		public const int PrisonerResistance = 37;

		/// <summary>
		/// 秘闻信息
		/// </summary>
		public const int SecretInformation = 38;

		/// <summary>
		/// 同道数量
		/// </summary>
		public const int TeammateCount = 39;

		/// <summary>
		/// 护卫
		/// </summary>
		public const int Guard = 5;

		/// <summary>
		/// 魅力基本说明
		/// </summary>
		public const int Charm = 93;

		/// <summary>
		/// 封穴
		/// </summary>
		public const int CombatAcupressure = 40;

		/// <summary>
		/// 破绽
		/// </summary>
		public const int CombatPartialFlaw = 41;

		/// <summary>
		/// 战斗先后手
		/// </summary>
		public const int CombatBeginFirstMove = 42;

		/// <summary>
		/// 变招进度
		/// </summary>
		public const int CombatChangeTrick = 43;

		/// <summary>
		/// 战斗变招招式
		/// </summary>
		public const int CombatChangeTrickTrick = 3;

		/// <summary>
		/// 战斗变招确认
		/// </summary>
		public const int CombatChangeTrickConfirm = 4;

		/// <summary>
		/// 先天罡气
		/// </summary>
		public const int CombatGangqi = 44;

		/// <summary>
		/// 兵器解封
		/// </summary>
		public const int CombatWeaponUnlock = 45;

		/// <summary>
		/// 施展增幅
		/// </summary>
		public const int CostNeiliAllocation = 46;

		/// <summary>
		/// 王蛊增幅
		/// </summary>
		public const int CostWugKing = 47;

		/// <summary>
		/// 紊乱增幅
		/// </summary>
		public const int CostClearDefend = 92;

		/// <summary>
		/// 部位伤害累积
		/// </summary>
		public const int DamageValue = 48;

		/// <summary>
		/// 战斗心韵激荡
		/// </summary>
		public const int MindUpheaval = 94;

		/// <summary>
		/// 促织技能替换
		/// </summary>
		public const int CricketSkillReplace = 1;

		/// <summary>
		/// 事件选项
		/// </summary>
		public const int EventOption = 6;

		/// <summary>
		/// 访驻周旋
		/// </summary>
		public const int CustomSectLaw = 2;

		/// <summary>
		/// 商队操作
		/// </summary>
		public const int CaravanOperation = 49;

		/// <summary>
		/// 奇书加点
		/// </summary>
		public const int LegendaryBookBonus_1 = 50;

		/// <summary>
		/// 奇书特效
		/// </summary>
		public const int LegendaryBookBonus_2 = 51;

		/// <summary>
		/// 较艺观众
		/// </summary>
		public const int LifeSkillCombatBlock = 52;

		/// <summary>
		/// 较艺先手
		/// </summary>
		public const int LifeSkillCombatFirstMove = 53;

		/// <summary>
		/// 较艺后手
		/// </summary>
		public const int LifeSkillCombatLastMove = 54;

		/// <summary>
		/// 较艺策略
		/// </summary>
		public const int LifeSkillCombatStrategy = 55;

		/// <summary>
		/// 较艺论点
		/// </summary>
		public const int LifeSkillCombatUnit = 56;

		/// <summary>
		/// 主动周天
		/// </summary>
		public const int ActiveLoop = 57;

		/// <summary>
		/// 主动研读
		/// </summary>
		public const int ActiveRead = 58;

		/// <summary>
		/// 月份更替
		/// </summary>
		public const int Advance = 59;

		/// <summary>
		/// 奇遇信息
		/// </summary>
		public const int Adventure = 60;

		/// <summary>
		/// 伏龙火焰
		/// </summary>
		public const int FulongFlame = 61;

		/// <summary>
		/// 神龙地格
		/// </summary>
		public const int loongDebuff = 62;

		/// <summary>
		/// 参悟心法
		/// </summary>
		public const int CombatSkillBreakInfo = 63;

		/// <summary>
		/// 突破功法
		/// </summary>
		public const int CombatSkillBreakout = 64;

		/// <summary>
		/// 研读进度
		/// </summary>
		public const int LifeSkillDetailReadProgress = 65;

		/// <summary>
		/// 解锁技艺见闻
		/// </summary>
		public const int LifeSkillDetailUnlockInformation = 66;

		/// <summary>
		/// 解锁较艺策略
		/// </summary>
		public const int LifeSkillDetailUnlockStrategy = 67;

		/// <summary>
		/// 实战和天人感应
		/// </summary>
		public const int LoopingEvent = 68;

		/// <summary>
		/// 实战和灵光一闪
		/// </summary>
		public const int ReadingEvent = 69;

		/// <summary>
		/// 研读情况
		/// </summary>
		public const int ReadingBook = 70;

		/// <summary>
		/// 突破格子
		/// </summary>
		public const int SkillBreakNormalCell = 71;

		/// <summary>
		/// 威力上限
		/// </summary>
		public const int SkillBreakPower = 72;

		/// <summary>
		/// 天资上限
		/// </summary>
		public const int SkillBreakStep = 73;

		/// <summary>
		/// 移宫易穴
		/// </summary>
		public const int SkillBreakSwapButton = 74;

		/// <summary>
		/// 志向有成
		/// </summary>
		public const int ExtraProfessionSkill = 75;

		/// <summary>
		/// 志向资历
		/// </summary>
		public const int ProfessionSeniority = 76;

		/// <summary>
		/// 志向技能
		/// </summary>
		public const int ProfessionSkill = 77;

		/// <summary>
		/// 志向技能百晓册
		/// </summary>
		public const int ProfessionSkillEncyclopedia = 78;

		/// <summary>
		/// 诛魔试炼
		/// </summary>
		public const int DemonSlayer = 79;

		/// <summary>
		/// 机关人内力真气
		/// </summary>
		public const int GearMateNeiliAndQiProgress = 80;

		/// <summary>
		/// 机关人研读进度
		/// </summary>
		public const int GearMateReadProgress = 81;

		/// <summary>
		/// 机关人主要属性
		/// </summary>
		public const int MouseTipGearMateUpgradeAttribute = 82;

		/// <summary>
		/// 机关人特性成长
		/// </summary>
		public const int MouseTipGearMateUpgradeFeature = 83;

		/// <summary>
		/// 百花内力类型
		/// </summary>
		public const int LifeLinkNeiliType = 84;

		/// <summary>
		/// 璇女播放器
		/// </summary>
		public const int Music = 85;

		/// <summary>
		/// 寄托奇书
		/// </summary>
		public const int RanshanBookKeeping = 86;

		/// <summary>
		/// 奇书断执
		/// </summary>
		public const int LegendaryBookGiveUp = 87;

		/// <summary>
		/// 狮相指令升级
		/// </summary>
		public const int ShixiangUpgradeTeammateCommand = 88;

		/// <summary>
		/// 三魔三才能量
		/// </summary>
		public const int ThreeVitals = 89;

		/// <summary>
		/// 姬穸成长进度
		/// </summary>
		public const int XuehouJixiGrowProgress = 90;

		/// <summary>
		/// 姬穸五行转移
		/// </summary>
		public const int XuehouTransferProgress = 91;

		/// <summary>
		/// 武具效果
		/// </summary>
		public const int EquipmentMastery = 95;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 调试
		/// </summary>
		public static CommonTipItem DebugTip => Instance[0];

		/// <summary>
		/// 毒素情况
		/// </summary>
		public static CommonTipItem AttachedPoison => Instance[7];

		/// <summary>
		/// 建设空间
		/// </summary>
		public static CommonTipItem BuildingArea => Instance[8];

		/// <summary>
		/// 宴堂效果
		/// </summary>
		public static CommonTipItem BuildingFeast => Instance[9];

		/// <summary>
		/// 建筑规模
		/// </summary>
		public static CommonTipItem BuildingLevel => Instance[10];

		/// <summary>
		/// 主事教学
		/// </summary>
		public static CommonTipItem BuildingTeachBook => Instance[11];

		/// <summary>
		/// 六道轮回信息
		/// </summary>
		public static CommonTipItem Destiny => Instance[12];

		/// <summary>
		/// 蛟养育方针
		/// </summary>
		public static CommonTipItem JiaoNurturance => Instance[13];

		/// <summary>
		/// 主事服众
		/// </summary>
		public static CommonTipItem MatchVillagerRole => Instance[14];

		/// <summary>
		/// 木人实战模式
		/// </summary>
		public static CommonTipItem PracticeRoomActualMode => Instance[15];

		/// <summary>
		/// 木人训练模式
		/// </summary>
		public static CommonTipItem PracticeRoomPracticeMode => Instance[16];

		/// <summary>
		/// 代制进度
		/// </summary>
		public static CommonTipItem ProductAddProgress => Instance[17];

		/// <summary>
		/// 库房规模
		/// </summary>
		public static CommonTipItem SettlementTreasuryOrPrisonLayer => Instance[18];

		/// <summary>
		/// 奇纹星台建造
		/// </summary>
		public static CommonTipItem SpecialBuild_Qwxt_Complete => Instance[19];

		/// <summary>
		/// 奇纹星台撤除
		/// </summary>
		public static CommonTipItem SpecialBuild_Qwxt_Unbuilt => Instance[20];

		/// <summary>
		/// 心材获取冷却
		/// </summary>
		public static CommonTipItem UpdateBlock => Instance[21];

		/// <summary>
		/// 年龄
		/// </summary>
		public static CommonTipItem Age => Instance[22];

		/// <summary>
		/// 身体部位
		/// </summary>
		public static CommonTipItem BodyPart => Instance[23];

		/// <summary>
		/// 人物毒素
		/// </summary>
		public static CommonTipItem CharacterPoison => Instance[24];

		/// <summary>
		/// 人物内息
		/// </summary>
		public static CommonTipItem DisorderOfQi => Instance[25];

		/// <summary>
		/// 服食栏位蛊
		/// </summary>
		public static CommonTipItem EatingWug => Instance[26];

		/// <summary>
		/// 装备负重
		/// </summary>
		public static CommonTipItem EquipLoad => Instance[27];

		/// <summary>
		/// 人物特性
		/// </summary>
		public static CommonTipItem Feature => Instance[28];

		/// <summary>
		/// 人物策略
		/// </summary>
		public static CommonTipItem FeatureMedalLegacy => Instance[29];

		/// <summary>
		/// 内力五行属性
		/// </summary>
		public static CommonTipItem FiveElements => Instance[30];

		/// <summary>
		/// 主动仇恨
		/// </summary>
		public static CommonTipItem HateButton => Instance[31];

		/// <summary>
		/// 主动爱慕
		/// </summary>
		public static CommonTipItem LoveButton => Instance[32];

		/// <summary>
		/// 人物身份
		/// </summary>
		public static CommonTipItem Identity => Instance[33];

		/// <summary>
		/// 见闻效果
		/// </summary>
		public static CommonTipItem InformationEffect => Instance[34];

		/// <summary>
		/// 混合毒素
		/// </summary>
		public static CommonTipItem MixPoison => Instance[35];

		/// <summary>
		/// 人物从属
		/// </summary>
		public static CommonTipItem Organization => Instance[36];

		/// <summary>
		/// 抵抗值
		/// </summary>
		public static CommonTipItem PrisonerResistance => Instance[37];

		/// <summary>
		/// 秘闻信息
		/// </summary>
		public static CommonTipItem SecretInformation => Instance[38];

		/// <summary>
		/// 同道数量
		/// </summary>
		public static CommonTipItem TeammateCount => Instance[39];

		/// <summary>
		/// 护卫
		/// </summary>
		public static CommonTipItem Guard => Instance[5];

		/// <summary>
		/// 魅力基本说明
		/// </summary>
		public static CommonTipItem Charm => Instance[93];

		/// <summary>
		/// 封穴
		/// </summary>
		public static CommonTipItem CombatAcupressure => Instance[40];

		/// <summary>
		/// 破绽
		/// </summary>
		public static CommonTipItem CombatPartialFlaw => Instance[41];

		/// <summary>
		/// 战斗先后手
		/// </summary>
		public static CommonTipItem CombatBeginFirstMove => Instance[42];

		/// <summary>
		/// 变招进度
		/// </summary>
		public static CommonTipItem CombatChangeTrick => Instance[43];

		/// <summary>
		/// 战斗变招招式
		/// </summary>
		public static CommonTipItem CombatChangeTrickTrick => Instance[3];

		/// <summary>
		/// 战斗变招确认
		/// </summary>
		public static CommonTipItem CombatChangeTrickConfirm => Instance[4];

		/// <summary>
		/// 先天罡气
		/// </summary>
		public static CommonTipItem CombatGangqi => Instance[44];

		/// <summary>
		/// 兵器解封
		/// </summary>
		public static CommonTipItem CombatWeaponUnlock => Instance[45];

		/// <summary>
		/// 施展增幅
		/// </summary>
		public static CommonTipItem CostNeiliAllocation => Instance[46];

		/// <summary>
		/// 王蛊增幅
		/// </summary>
		public static CommonTipItem CostWugKing => Instance[47];

		/// <summary>
		/// 紊乱增幅
		/// </summary>
		public static CommonTipItem CostClearDefend => Instance[92];

		/// <summary>
		/// 部位伤害累积
		/// </summary>
		public static CommonTipItem DamageValue => Instance[48];

		/// <summary>
		/// 战斗心韵激荡
		/// </summary>
		public static CommonTipItem MindUpheaval => Instance[94];

		/// <summary>
		/// 促织技能替换
		/// </summary>
		public static CommonTipItem CricketSkillReplace => Instance[1];

		/// <summary>
		/// 事件选项
		/// </summary>
		public static CommonTipItem EventOption => Instance[6];

		/// <summary>
		/// 访驻周旋
		/// </summary>
		public static CommonTipItem CustomSectLaw => Instance[2];

		/// <summary>
		/// 商队操作
		/// </summary>
		public static CommonTipItem CaravanOperation => Instance[49];

		/// <summary>
		/// 奇书加点
		/// </summary>
		public static CommonTipItem LegendaryBookBonus_1 => Instance[50];

		/// <summary>
		/// 奇书特效
		/// </summary>
		public static CommonTipItem LegendaryBookBonus_2 => Instance[51];

		/// <summary>
		/// 较艺观众
		/// </summary>
		public static CommonTipItem LifeSkillCombatBlock => Instance[52];

		/// <summary>
		/// 较艺先手
		/// </summary>
		public static CommonTipItem LifeSkillCombatFirstMove => Instance[53];

		/// <summary>
		/// 较艺后手
		/// </summary>
		public static CommonTipItem LifeSkillCombatLastMove => Instance[54];

		/// <summary>
		/// 较艺策略
		/// </summary>
		public static CommonTipItem LifeSkillCombatStrategy => Instance[55];

		/// <summary>
		/// 较艺论点
		/// </summary>
		public static CommonTipItem LifeSkillCombatUnit => Instance[56];

		/// <summary>
		/// 主动周天
		/// </summary>
		public static CommonTipItem ActiveLoop => Instance[57];

		/// <summary>
		/// 主动研读
		/// </summary>
		public static CommonTipItem ActiveRead => Instance[58];

		/// <summary>
		/// 月份更替
		/// </summary>
		public static CommonTipItem Advance => Instance[59];

		/// <summary>
		/// 奇遇信息
		/// </summary>
		public static CommonTipItem Adventure => Instance[60];

		/// <summary>
		/// 伏龙火焰
		/// </summary>
		public static CommonTipItem FulongFlame => Instance[61];

		/// <summary>
		/// 神龙地格
		/// </summary>
		public static CommonTipItem loongDebuff => Instance[62];

		/// <summary>
		/// 参悟心法
		/// </summary>
		public static CommonTipItem CombatSkillBreakInfo => Instance[63];

		/// <summary>
		/// 突破功法
		/// </summary>
		public static CommonTipItem CombatSkillBreakout => Instance[64];

		/// <summary>
		/// 研读进度
		/// </summary>
		public static CommonTipItem LifeSkillDetailReadProgress => Instance[65];

		/// <summary>
		/// 解锁技艺见闻
		/// </summary>
		public static CommonTipItem LifeSkillDetailUnlockInformation => Instance[66];

		/// <summary>
		/// 解锁较艺策略
		/// </summary>
		public static CommonTipItem LifeSkillDetailUnlockStrategy => Instance[67];

		/// <summary>
		/// 实战和天人感应
		/// </summary>
		public static CommonTipItem LoopingEvent => Instance[68];

		/// <summary>
		/// 实战和灵光一闪
		/// </summary>
		public static CommonTipItem ReadingEvent => Instance[69];

		/// <summary>
		/// 研读情况
		/// </summary>
		public static CommonTipItem ReadingBook => Instance[70];

		/// <summary>
		/// 突破格子
		/// </summary>
		public static CommonTipItem SkillBreakNormalCell => Instance[71];

		/// <summary>
		/// 威力上限
		/// </summary>
		public static CommonTipItem SkillBreakPower => Instance[72];

		/// <summary>
		/// 天资上限
		/// </summary>
		public static CommonTipItem SkillBreakStep => Instance[73];

		/// <summary>
		/// 移宫易穴
		/// </summary>
		public static CommonTipItem SkillBreakSwapButton => Instance[74];

		/// <summary>
		/// 志向有成
		/// </summary>
		public static CommonTipItem ExtraProfessionSkill => Instance[75];

		/// <summary>
		/// 志向资历
		/// </summary>
		public static CommonTipItem ProfessionSeniority => Instance[76];

		/// <summary>
		/// 志向技能
		/// </summary>
		public static CommonTipItem ProfessionSkill => Instance[77];

		/// <summary>
		/// 志向技能百晓册
		/// </summary>
		public static CommonTipItem ProfessionSkillEncyclopedia => Instance[78];

		/// <summary>
		/// 诛魔试炼
		/// </summary>
		public static CommonTipItem DemonSlayer => Instance[79];

		/// <summary>
		/// 机关人内力真气
		/// </summary>
		public static CommonTipItem GearMateNeiliAndQiProgress => Instance[80];

		/// <summary>
		/// 机关人研读进度
		/// </summary>
		public static CommonTipItem GearMateReadProgress => Instance[81];

		/// <summary>
		/// 机关人主要属性
		/// </summary>
		public static CommonTipItem MouseTipGearMateUpgradeAttribute => Instance[82];

		/// <summary>
		/// 机关人特性成长
		/// </summary>
		public static CommonTipItem MouseTipGearMateUpgradeFeature => Instance[83];

		/// <summary>
		/// 百花内力类型
		/// </summary>
		public static CommonTipItem LifeLinkNeiliType => Instance[84];

		/// <summary>
		/// 璇女播放器
		/// </summary>
		public static CommonTipItem Music => Instance[85];

		/// <summary>
		/// 寄托奇书
		/// </summary>
		public static CommonTipItem RanshanBookKeeping => Instance[86];

		/// <summary>
		/// 奇书断执
		/// </summary>
		public static CommonTipItem LegendaryBookGiveUp => Instance[87];

		/// <summary>
		/// 狮相指令升级
		/// </summary>
		public static CommonTipItem ShixiangUpgradeTeammateCommand => Instance[88];

		/// <summary>
		/// 三魔三才能量
		/// </summary>
		public static CommonTipItem ThreeVitals => Instance[89];

		/// <summary>
		/// 姬穸成长进度
		/// </summary>
		public static CommonTipItem XuehouJixiGrowProgress => Instance[90];

		/// <summary>
		/// 姬穸五行转移
		/// </summary>
		public static CommonTipItem XuehouTransferProgress => Instance[91];

		/// <summary>
		/// 武具效果
		/// </summary>
		public static CommonTipItem EquipmentMastery => Instance[95];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static CommonTip Instance = new CommonTip();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "TemplateId", "Path" };

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
		_dataArray.Add(new CommonTipItem(0, "Debug/DebugTip"));
		_dataArray.Add(new CommonTipItem(1, "Cricket/CricketSkillReplace"));
		_dataArray.Add(new CommonTipItem(2, "Event/CustomSectLaw"));
		_dataArray.Add(new CommonTipItem(3, "Combat/CombatChangeTrickTrickTip"));
		_dataArray.Add(new CommonTipItem(4, "Combat/CombatChangeTrickConfirmTip"));
		_dataArray.Add(new CommonTipItem(5, "Character/Guard"));
		_dataArray.Add(new CommonTipItem(6, "Event/EventOption"));
		_dataArray.Add(new CommonTipItem(7, "Building/AttachedPoison"));
		_dataArray.Add(new CommonTipItem(8, "Building/BuildingArea"));
		_dataArray.Add(new CommonTipItem(9, "Building/BuildingFeast"));
		_dataArray.Add(new CommonTipItem(10, "Building/BuildingLevel"));
		_dataArray.Add(new CommonTipItem(11, "Building/BuildingTeachBook"));
		_dataArray.Add(new CommonTipItem(12, "Building/Destiny"));
		_dataArray.Add(new CommonTipItem(13, "Building/JiaoNurturance"));
		_dataArray.Add(new CommonTipItem(14, "Building/MatchVillagerRole"));
		_dataArray.Add(new CommonTipItem(15, "Building/PracticeRoomActualMode"));
		_dataArray.Add(new CommonTipItem(16, "Building/PracticeRoomPracticeMode"));
		_dataArray.Add(new CommonTipItem(17, "Building/ProductAddProgress"));
		_dataArray.Add(new CommonTipItem(18, "Building/SettlementTreasuryOrPrisonLayer"));
		_dataArray.Add(new CommonTipItem(19, "Building/SpecialBuild_Qwxt_Complete"));
		_dataArray.Add(new CommonTipItem(20, "Building/SpecialBuild_Qwxt_Unbuilt"));
		_dataArray.Add(new CommonTipItem(21, "Building/UpdateBlock"));
		_dataArray.Add(new CommonTipItem(22, "Character/Age"));
		_dataArray.Add(new CommonTipItem(23, "Character/BodyPart"));
		_dataArray.Add(new CommonTipItem(24, "Character/CharacterPoison"));
		_dataArray.Add(new CommonTipItem(25, "Character/DisorderOfQi"));
		_dataArray.Add(new CommonTipItem(26, "Character/EatingWug"));
		_dataArray.Add(new CommonTipItem(27, "Character/EquipLoad"));
		_dataArray.Add(new CommonTipItem(28, "Character/Feature"));
		_dataArray.Add(new CommonTipItem(29, "Character/FeatureMedalLegacy"));
		_dataArray.Add(new CommonTipItem(30, "Character/FiveElements"));
		_dataArray.Add(new CommonTipItem(31, "Character/HateButton"));
		_dataArray.Add(new CommonTipItem(32, "Character/LoveButton"));
		_dataArray.Add(new CommonTipItem(33, "Character/Identity"));
		_dataArray.Add(new CommonTipItem(34, "Character/InformationEffect"));
		_dataArray.Add(new CommonTipItem(35, "Character/MixPoison"));
		_dataArray.Add(new CommonTipItem(36, "Character/Organization"));
		_dataArray.Add(new CommonTipItem(37, "Character/PrisonerResistance"));
		_dataArray.Add(new CommonTipItem(38, "Character/SecretInformation"));
		_dataArray.Add(new CommonTipItem(39, "Character/TeammateCount"));
		_dataArray.Add(new CommonTipItem(40, "Combat/CombatAcupressure"));
		_dataArray.Add(new CommonTipItem(41, "Combat/CombatPartialFlaw"));
		_dataArray.Add(new CommonTipItem(42, "Combat/CombatBeginFirstMove"));
		_dataArray.Add(new CommonTipItem(43, "Combat/CombatChangeTrick"));
		_dataArray.Add(new CommonTipItem(44, "Combat/CombatGangqi"));
		_dataArray.Add(new CommonTipItem(45, "Combat/CombatWeaponUnlock"));
		_dataArray.Add(new CommonTipItem(46, "Combat/CostNeiliAllocation"));
		_dataArray.Add(new CommonTipItem(47, "Combat/CostWugKing"));
		_dataArray.Add(new CommonTipItem(48, "Combat/DamageValue"));
		_dataArray.Add(new CommonTipItem(49, "Event/CaravanOperation"));
		_dataArray.Add(new CommonTipItem(50, "LegendaryBook/LegendaryBookBonus_1"));
		_dataArray.Add(new CommonTipItem(51, "LegendaryBook/LegendaryBookBonus_2"));
		_dataArray.Add(new CommonTipItem(52, "LifeSkillCombat/LifeSkillCombatBlock"));
		_dataArray.Add(new CommonTipItem(53, "LifeSkillCombat/LifeSkillCombatFirstMove"));
		_dataArray.Add(new CommonTipItem(54, "LifeSkillCombat/LifeSkillCombatLastMove"));
		_dataArray.Add(new CommonTipItem(55, "LifeSkillCombat/LifeSkillCombatStrategy"));
		_dataArray.Add(new CommonTipItem(56, "LifeSkillCombat/LifeSkillCombatUnit"));
		_dataArray.Add(new CommonTipItem(57, "Map/ActiveLoop"));
		_dataArray.Add(new CommonTipItem(58, "Map/ActiveRead"));
		_dataArray.Add(new CommonTipItem(59, "Map/Advance"));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new CommonTipItem(60, "Map/Adventure"));
		_dataArray.Add(new CommonTipItem(61, "Map/FulongFlame"));
		_dataArray.Add(new CommonTipItem(62, "Map/loongDebuff"));
		_dataArray.Add(new CommonTipItem(63, "Practice/CombatSkillBreakInfo"));
		_dataArray.Add(new CommonTipItem(64, "Practice/CombatSkillBreakout"));
		_dataArray.Add(new CommonTipItem(65, "Practice/LifeSkillDetailReadProgress"));
		_dataArray.Add(new CommonTipItem(66, "Practice/LifeSkillDetailUnlockInformation"));
		_dataArray.Add(new CommonTipItem(67, "Practice/LifeSkillDetailUnlockStrategy"));
		_dataArray.Add(new CommonTipItem(68, "Practice/LoopingEvent"));
		_dataArray.Add(new CommonTipItem(69, "Practice/ReadingEvent"));
		_dataArray.Add(new CommonTipItem(70, "Practice/ReadingBook"));
		_dataArray.Add(new CommonTipItem(71, "Practice/SkillBreakNormalCell"));
		_dataArray.Add(new CommonTipItem(72, "Practice/SkillBreakPower"));
		_dataArray.Add(new CommonTipItem(73, "Practice/SkillBreakStep"));
		_dataArray.Add(new CommonTipItem(74, "Practice/SkillBreakSwapButton"));
		_dataArray.Add(new CommonTipItem(75, "Profession/ExtraProfessionSkill"));
		_dataArray.Add(new CommonTipItem(76, "Profession/ProfessionSeniority"));
		_dataArray.Add(new CommonTipItem(77, "Profession/ProfessionSkill"));
		_dataArray.Add(new CommonTipItem(78, "Profession/ProfessionSkillEncyclopedia"));
		_dataArray.Add(new CommonTipItem(79, "SectFunction/DemonSlayer"));
		_dataArray.Add(new CommonTipItem(80, "SectFunction/GearMateNeiliAndQiProgress"));
		_dataArray.Add(new CommonTipItem(81, "SectFunction/GearMateReadProgress"));
		_dataArray.Add(new CommonTipItem(82, "SectFunction/MouseTipGearMateUpgradeAttribute"));
		_dataArray.Add(new CommonTipItem(83, "SectFunction/MouseTipGearMateUpgradeFeature"));
		_dataArray.Add(new CommonTipItem(84, "SectFunction/LifeLinkNeiliType"));
		_dataArray.Add(new CommonTipItem(85, "SectFunction/Music"));
		_dataArray.Add(new CommonTipItem(86, "SectFunction/RanshanBookKeeping"));
		_dataArray.Add(new CommonTipItem(87, "SectFunction/LegendaryBookGiveUp"));
		_dataArray.Add(new CommonTipItem(88, "SectFunction/ShixiangUpgradeTeammateCommand"));
		_dataArray.Add(new CommonTipItem(89, "SectFunction/ThreeVitals"));
		_dataArray.Add(new CommonTipItem(90, "SectFunction/XuehouJixiGrowProgress"));
		_dataArray.Add(new CommonTipItem(91, "SectFunction/XuehouTransferProgress"));
		_dataArray.Add(new CommonTipItem(92, "Combat/CostClearDefend"));
		_dataArray.Add(new CommonTipItem(93, "Character/Charm"));
		_dataArray.Add(new CommonTipItem(94, "Combat/MindUpheaval"));
		_dataArray.Add(new CommonTipItem(95, "Make/EquipmentMastery"));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<CommonTipItem>(96);
		CreateItems0();
		CreateItems1();
	}
}
