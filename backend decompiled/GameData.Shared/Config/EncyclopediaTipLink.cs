using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class EncyclopediaTipLink : ConfigData<EncyclopediaTipLinkItem, int>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 遗惠Tips
		/// </summary>
		public const int TipLegacy = 0;

		/// <summary>
		/// 混合毒素
		/// </summary>
		public const int MixPoison = 1;

		/// <summary>
		/// 伏虞剑柄
		/// </summary>
		public const int FuyuSwordGrip = 2;

		/// <summary>
		/// 名誉
		/// </summary>
		public const int Fame = 3;

		/// <summary>
		/// 助战指令
		/// </summary>
		public const int SupportCommands = 4;

		/// <summary>
		/// 拆解
		/// </summary>
		public const int Disassembly = 5;

		/// <summary>
		/// 装备
		/// </summary>
		public const int Equip = 6;

		/// <summary>
		/// 主要装备
		/// </summary>
		public const int MainEquip = 7;

		/// <summary>
		/// 次要装备
		/// </summary>
		public const int SecondaryEquipment = 8;

		/// <summary>
		/// 资质-武学
		/// </summary>
		public const int Talent = 9;

		/// <summary>
		/// 资质-技艺
		/// </summary>
		public const int FineArts = 10;

		/// <summary>
		/// 造诣-武学
		/// </summary>
		public const int MartialArts = 11;

		/// <summary>
		/// 造诣-技艺
		/// </summary>
		public const int Attainment = 12;

		/// <summary>
		/// 突破
		/// </summary>
		public const int Breakthrough = 13;

		/// <summary>
		/// 突破玄关
		/// </summary>
		public const int Mechanism = 14;

		/// <summary>
		/// 内力
		/// </summary>
		public const int QiAttributes = 15;

		/// <summary>
		/// 关系
		/// </summary>
		public const int Relation = 16;

		/// <summary>
		/// 关押
		/// </summary>
		public const int Captive = 17;

		/// <summary>
		/// 经历
		/// </summary>
		public const int Experience = 18;

		/// <summary>
		/// 轮回
		/// </summary>
		public const int Reincarnation = 19;

		/// <summary>
		/// 精挑细选
		/// </summary>
		public const int Handpick = 20;

		/// <summary>
		/// 运功
		/// </summary>
		public const int MartialLoadout = 21;

		/// <summary>
		/// 戒心
		/// </summary>
		public const int Wariness = 22;

		/// <summary>
		/// 族谱
		/// </summary>
		public const int Bloodline = 23;

		/// <summary>
		/// 生铸
		/// </summary>
		public const int Reforged = 24;

		/// <summary>
		/// 铭刻
		/// </summary>
		public const int Imprint = 25;

		/// <summary>
		/// 研读书籍
		/// </summary>
		public const int StudyingBooks = 26;

		/// <summary>
		/// 周天运转
		/// </summary>
		public const int MicrocosmicCirculation = 27;

		/// <summary>
		/// 诊疗
		/// </summary>
		public const int MedicalCare = 28;

		/// <summary>
		/// 势力
		/// </summary>
		public const int Faction = 29;

		/// <summary>
		/// 传承
		/// </summary>
		public const int TaiwuInheritance = 30;

		/// <summary>
		/// 诛魔试炼
		/// </summary>
		public const int Shaolin = 31;

		/// <summary>
		/// 独创心法
		/// </summary>
		public const int Emei = 32;

		/// <summary>
		/// 生关死节
		/// </summary>
		public const int BaihuaLifeLink = 33;

		/// <summary>
		/// 培育神木
		/// </summary>
		public const int WudangTree = 34;

		/// <summary>
		/// 三才护阵
		/// </summary>
		public const int Yuanshan = 35;

		/// <summary>
		/// 统筹方略
		/// </summary>
		public const int Shixiang = 36;

		/// <summary>
		/// 奇书寄托
		/// </summary>
		public const int Ranshan = 37;

		/// <summary>
		/// 孤鸾镜水谣
		/// </summary>
		public const int Xuannv = 38;

		/// <summary>
		/// 天枢玄铸
		/// </summary>
		public const int ZhujianGearMate = 39;

		/// <summary>
		/// 驱使古鼎
		/// </summary>
		public const int Kongsang = 40;

		/// <summary>
		/// 化魂阁
		/// </summary>
		public const int Jingang = 41;

		/// <summary>
		/// 万蛊坛
		/// </summary>
		public const int WugKing = 42;

		/// <summary>
		/// 星运煞缘
		/// </summary>
		public const int Jieqing = 43;

		/// <summary>
		/// 汲气饮血
		/// </summary>
		public const int Xuehou = 44;

		/// <summary>
		/// 元鸡舍
		/// </summary>
		public const int ChickenCoop = 45;

		/// <summary>
		/// 茶马帮
		/// </summary>
		public const int TeaHorseCaravan = 46;

		/// <summary>
		/// 蛰室
		/// </summary>
		public const int CricketChamber = 47;

		/// <summary>
		/// 太吾村
		/// </summary>
		public const int TaiwuVillage = 48;

		/// <summary>
		/// 宴堂
		/// </summary>
		public const int BanquetHall = 49;

		/// <summary>
		/// 建筑经营
		/// </summary>
		public const int IndustryBuildings = 50;

		/// <summary>
		/// 练功房木人
		/// </summary>
		public const int WoodeDummy = 51;

		/// <summary>
		/// 练功房训练
		/// </summary>
		public const int PracticeTechnique = 52;

		/// <summary>
		/// 势力监牢
		/// </summary>
		public const int Prison = 53;

		/// <summary>
		/// 库房/势力库房
		/// </summary>
		public const int Warehouse = 54;

		/// <summary>
		/// 见闻
		/// </summary>
		public const int ExperienceChronicle = 55;

		/// <summary>
		/// 秘闻
		/// </summary>
		public const int Secret = 56;

		/// <summary>
		/// 传承名谱
		/// </summary>
		public const int InheritanceRecords = 57;

		/// <summary>
		/// 轮回台
		/// </summary>
		public const int ReincarnationPlatform = 58;

		/// <summary>
		/// 志向
		/// </summary>
		public const int AspirationInsight = 59;

		/// <summary>
		/// 较艺（准备）
		/// </summary>
		public const int DebateTopic = 60;

		/// <summary>
		/// 较艺（战斗）
		/// </summary>
		public const int Debate = 61;

		/// <summary>
		/// 旅行地图
		/// </summary>
		public const int Travel = 62;

		/// <summary>
		/// 奇书宝典
		/// </summary>
		public const int SecretTome = 63;

		/// <summary>
		/// 交换物资
		/// </summary>
		public const int Exchange = 64;

		/// <summary>
		/// 淬毒
		/// </summary>
		public const int Envenom = 65;

		/// <summary>
		/// 改制
		/// </summary>
		public const int Alteration = 66;

		/// <summary>
		/// 解毒
		/// </summary>
		public const int Detoxify = 67;

		/// <summary>
		/// 精制
		/// </summary>
		public const int Refinement = 68;

		/// <summary>
		/// 修理
		/// </summary>
		public const int Repair = 69;

		/// <summary>
		/// 制造
		/// </summary>
		public const int Craft = 70;

		/// <summary>
		/// 促织战斗
		/// </summary>
		public const int CricketDue = 71;

		/// <summary>
		/// 捉促织
		/// </summary>
		public const int CricketHunt = 72;

		/// <summary>
		/// 独具匠心
		/// </summary>
		public const int InventiveMind = 73;

		/// <summary>
		/// 石屋
		/// </summary>
		public const int StoneHouse = 74;

		/// <summary>
		/// 较艺结算
		/// </summary>
		public const int DebateRating = 75;

		/// <summary>
		/// 侵袭进度
		/// </summary>
		public const int InvasionProgress = 76;

		/// <summary>
		/// 姓名
		/// </summary>
		public const int Name = 77;

		/// <summary>
		/// 生时
		/// </summary>
		public const int BirthTime = 78;

		/// <summary>
		/// 年龄
		/// </summary>
		public const int Age = 79;

		/// <summary>
		/// 性别
		/// </summary>
		public const int Gender = 80;

		/// <summary>
		/// 魅力
		/// </summary>
		public const int Charm = 81;

		/// <summary>
		/// 心情
		/// </summary>
		public const int Mood = 82;

		/// <summary>
		/// 立场
		/// </summary>
		public const int Mindset = 83;

		/// <summary>
		/// 身份
		/// </summary>
		public const int Rank = 84;

		/// <summary>
		/// 好感
		/// </summary>
		public const int Favorability = 85;

		/// <summary>
		/// 称号
		/// </summary>
		public const int CharacterTitle = 86;

		/// <summary>
		/// 主要属性
		/// </summary>
		public const int PrimaryAttributes = 87;

		/// <summary>
		/// 战斗属性
		/// </summary>
		public const int BattleAttributes = 88;

		/// <summary>
		/// 特性
		/// </summary>
		public const int Trait = 89;

		/// <summary>
		/// 七元赋性
		/// </summary>
		public const int Dispositions = 90;

		/// <summary>
		/// 健康
		/// </summary>
		public const int Health = 91;

		/// <summary>
		/// 伤势
		/// </summary>
		public const int Injuries = 92;

		/// <summary>
		/// 毒素
		/// </summary>
		public const int Toxin = 93;

		/// <summary>
		/// 内息
		/// </summary>
		public const int InnerBreath = 94;

		/// <summary>
		/// 服食汲饮
		/// </summary>
		public const int OralMedication = 95;

		/// <summary>
		/// 爱慕
		/// </summary>
		public const int Love = 96;

		/// <summary>
		/// 仇敌
		/// </summary>
		public const int Enemy = 97;

		/// <summary>
		/// 验毒
		/// </summary>
		public const int TestingPoison = 98;

		/// <summary>
		/// 建筑
		/// </summary>
		public const int Buildings = 99;

		/// <summary>
		/// 较艺策略
		/// </summary>
		public const int DebateStrategy = 100;

		/// <summary>
		/// 技艺见闻
		/// </summary>
		public const int FineArtsInsight = 101;

		/// <summary>
		/// 内外功比例
		/// </summary>
		public const int MartialArtsRatio = 102;

		/// <summary>
		/// 精解
		/// </summary>
		public const int Simplification = 103;

		/// <summary>
		/// 丹田内力
		/// </summary>
		public const int DantianQi = 104;

		/// <summary>
		/// 精纯境界
		/// </summary>
		public const int PureEssence = 105;

		/// <summary>
		/// 真气
		/// </summary>
		public const int TrueQi = 106;

		/// <summary>
		/// 架势
		/// </summary>
		public const int Stance = 107;

		/// <summary>
		/// 提气
		/// </summary>
		public const int Inhale = 108;

		/// <summary>
		/// 脚力
		/// </summary>
		public const int Footwork = 109;

		/// <summary>
		/// 距离
		/// </summary>
		public const int Distance = 110;

		/// <summary>
		/// 招式
		/// </summary>
		public const int CombatMoves = 111;

		/// <summary>
		/// 变招
		/// </summary>
		public const int PinpointStrikes = 112;

		/// <summary>
		/// 战败标记
		/// </summary>
		public const int DefeatMarkers = 113;

		/// <summary>
		/// 战斗状态
		/// </summary>
		public const int BattleStatus = 114;

		/// <summary>
		/// 破绽
		/// </summary>
		public const int Openings = 115;

		/// <summary>
		/// 封穴
		/// </summary>
		public const int SealedAcupoints = 116;

		/// <summary>
		/// 真气状态
		/// </summary>
		public const int TrueQiState = 117;

		/// <summary>
		/// 战斗行为
		/// </summary>
		public const int CombatActions = 118;

		/// <summary>
		/// 观众
		/// </summary>
		public const int Audience = 119;

		/// <summary>
		/// 采集
		/// </summary>
		public const int MapBlockCollectResource = 120;

		/// <summary>
		/// 同道
		/// </summary>
		public const int Companion = 121;

		/// <summary>
		/// 太吾月报
		/// </summary>
		public const int MonthlyReport = 122;

		/// <summary>
		/// 人物互动
		/// </summary>
		public const int Talk = 123;

		/// <summary>
		/// 元鸡
		/// </summary>
		public const int Chicken = 124;

		/// <summary>
		/// 学艺许可
		/// </summary>
		public const int SectLearPermisson = 125;

		/// <summary>
		/// 门派恩义互动
		/// </summary>
		public const int SectDebtInteraction = 126;

		/// <summary>
		/// 交换私人藏书
		/// </summary>
		public const int BookExchangePersonal = 127;

		/// <summary>
		/// 紫竹化身
		/// </summary>
		public const int JuniorXiangshu = 128;

		/// <summary>
		/// 库房交换
		/// </summary>
		public const int WarehouseExchange = 129;

		/// <summary>
		/// 创建人物
		/// </summary>
		public const int CharacterCreate = 130;

		/// <summary>
		/// 出生地区
		/// </summary>
		public const int BornArea = 131;

		/// <summary>
		/// 内力属性
		/// </summary>
		public const int NeiliProperty = 132;

		/// <summary>
		/// 出身特质
		/// </summary>
		public const int PresetTricks = 133;

		/// <summary>
		/// 世界细节
		/// </summary>
		public const int WorldDetail = 134;

		/// <summary>
		/// 玄狱模式
		/// </summary>
		public const int ChallengeMode = 135;

		/// <summary>
		/// 门派
		/// </summary>
		public const int Sect = 136;

		/// <summary>
		/// 心韵激荡
		/// </summary>
		public const int MindUpheaval = 137;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 遗惠Tips
		/// </summary>
		public static EncyclopediaTipLinkItem TipLegacy => Instance[0];

		/// <summary>
		/// 混合毒素
		/// </summary>
		public static EncyclopediaTipLinkItem MixPoison => Instance[1];

		/// <summary>
		/// 伏虞剑柄
		/// </summary>
		public static EncyclopediaTipLinkItem FuyuSwordGrip => Instance[2];

		/// <summary>
		/// 名誉
		/// </summary>
		public static EncyclopediaTipLinkItem Fame => Instance[3];

		/// <summary>
		/// 助战指令
		/// </summary>
		public static EncyclopediaTipLinkItem SupportCommands => Instance[4];

		/// <summary>
		/// 拆解
		/// </summary>
		public static EncyclopediaTipLinkItem Disassembly => Instance[5];

		/// <summary>
		/// 装备
		/// </summary>
		public static EncyclopediaTipLinkItem Equip => Instance[6];

		/// <summary>
		/// 主要装备
		/// </summary>
		public static EncyclopediaTipLinkItem MainEquip => Instance[7];

		/// <summary>
		/// 次要装备
		/// </summary>
		public static EncyclopediaTipLinkItem SecondaryEquipment => Instance[8];

		/// <summary>
		/// 资质-武学
		/// </summary>
		public static EncyclopediaTipLinkItem Talent => Instance[9];

		/// <summary>
		/// 资质-技艺
		/// </summary>
		public static EncyclopediaTipLinkItem FineArts => Instance[10];

		/// <summary>
		/// 造诣-武学
		/// </summary>
		public static EncyclopediaTipLinkItem MartialArts => Instance[11];

		/// <summary>
		/// 造诣-技艺
		/// </summary>
		public static EncyclopediaTipLinkItem Attainment => Instance[12];

		/// <summary>
		/// 突破
		/// </summary>
		public static EncyclopediaTipLinkItem Breakthrough => Instance[13];

		/// <summary>
		/// 突破玄关
		/// </summary>
		public static EncyclopediaTipLinkItem Mechanism => Instance[14];

		/// <summary>
		/// 内力
		/// </summary>
		public static EncyclopediaTipLinkItem QiAttributes => Instance[15];

		/// <summary>
		/// 关系
		/// </summary>
		public static EncyclopediaTipLinkItem Relation => Instance[16];

		/// <summary>
		/// 关押
		/// </summary>
		public static EncyclopediaTipLinkItem Captive => Instance[17];

		/// <summary>
		/// 经历
		/// </summary>
		public static EncyclopediaTipLinkItem Experience => Instance[18];

		/// <summary>
		/// 轮回
		/// </summary>
		public static EncyclopediaTipLinkItem Reincarnation => Instance[19];

		/// <summary>
		/// 精挑细选
		/// </summary>
		public static EncyclopediaTipLinkItem Handpick => Instance[20];

		/// <summary>
		/// 运功
		/// </summary>
		public static EncyclopediaTipLinkItem MartialLoadout => Instance[21];

		/// <summary>
		/// 戒心
		/// </summary>
		public static EncyclopediaTipLinkItem Wariness => Instance[22];

		/// <summary>
		/// 族谱
		/// </summary>
		public static EncyclopediaTipLinkItem Bloodline => Instance[23];

		/// <summary>
		/// 生铸
		/// </summary>
		public static EncyclopediaTipLinkItem Reforged => Instance[24];

		/// <summary>
		/// 铭刻
		/// </summary>
		public static EncyclopediaTipLinkItem Imprint => Instance[25];

		/// <summary>
		/// 研读书籍
		/// </summary>
		public static EncyclopediaTipLinkItem StudyingBooks => Instance[26];

		/// <summary>
		/// 周天运转
		/// </summary>
		public static EncyclopediaTipLinkItem MicrocosmicCirculation => Instance[27];

		/// <summary>
		/// 诊疗
		/// </summary>
		public static EncyclopediaTipLinkItem MedicalCare => Instance[28];

		/// <summary>
		/// 势力
		/// </summary>
		public static EncyclopediaTipLinkItem Faction => Instance[29];

		/// <summary>
		/// 传承
		/// </summary>
		public static EncyclopediaTipLinkItem TaiwuInheritance => Instance[30];

		/// <summary>
		/// 诛魔试炼
		/// </summary>
		public static EncyclopediaTipLinkItem Shaolin => Instance[31];

		/// <summary>
		/// 独创心法
		/// </summary>
		public static EncyclopediaTipLinkItem Emei => Instance[32];

		/// <summary>
		/// 生关死节
		/// </summary>
		public static EncyclopediaTipLinkItem BaihuaLifeLink => Instance[33];

		/// <summary>
		/// 培育神木
		/// </summary>
		public static EncyclopediaTipLinkItem WudangTree => Instance[34];

		/// <summary>
		/// 三才护阵
		/// </summary>
		public static EncyclopediaTipLinkItem Yuanshan => Instance[35];

		/// <summary>
		/// 统筹方略
		/// </summary>
		public static EncyclopediaTipLinkItem Shixiang => Instance[36];

		/// <summary>
		/// 奇书寄托
		/// </summary>
		public static EncyclopediaTipLinkItem Ranshan => Instance[37];

		/// <summary>
		/// 孤鸾镜水谣
		/// </summary>
		public static EncyclopediaTipLinkItem Xuannv => Instance[38];

		/// <summary>
		/// 天枢玄铸
		/// </summary>
		public static EncyclopediaTipLinkItem ZhujianGearMate => Instance[39];

		/// <summary>
		/// 驱使古鼎
		/// </summary>
		public static EncyclopediaTipLinkItem Kongsang => Instance[40];

		/// <summary>
		/// 化魂阁
		/// </summary>
		public static EncyclopediaTipLinkItem Jingang => Instance[41];

		/// <summary>
		/// 万蛊坛
		/// </summary>
		public static EncyclopediaTipLinkItem WugKing => Instance[42];

		/// <summary>
		/// 星运煞缘
		/// </summary>
		public static EncyclopediaTipLinkItem Jieqing => Instance[43];

		/// <summary>
		/// 汲气饮血
		/// </summary>
		public static EncyclopediaTipLinkItem Xuehou => Instance[44];

		/// <summary>
		/// 元鸡舍
		/// </summary>
		public static EncyclopediaTipLinkItem ChickenCoop => Instance[45];

		/// <summary>
		/// 茶马帮
		/// </summary>
		public static EncyclopediaTipLinkItem TeaHorseCaravan => Instance[46];

		/// <summary>
		/// 蛰室
		/// </summary>
		public static EncyclopediaTipLinkItem CricketChamber => Instance[47];

		/// <summary>
		/// 太吾村
		/// </summary>
		public static EncyclopediaTipLinkItem TaiwuVillage => Instance[48];

		/// <summary>
		/// 宴堂
		/// </summary>
		public static EncyclopediaTipLinkItem BanquetHall => Instance[49];

		/// <summary>
		/// 建筑经营
		/// </summary>
		public static EncyclopediaTipLinkItem IndustryBuildings => Instance[50];

		/// <summary>
		/// 练功房木人
		/// </summary>
		public static EncyclopediaTipLinkItem WoodeDummy => Instance[51];

		/// <summary>
		/// 练功房训练
		/// </summary>
		public static EncyclopediaTipLinkItem PracticeTechnique => Instance[52];

		/// <summary>
		/// 势力监牢
		/// </summary>
		public static EncyclopediaTipLinkItem Prison => Instance[53];

		/// <summary>
		/// 库房/势力库房
		/// </summary>
		public static EncyclopediaTipLinkItem Warehouse => Instance[54];

		/// <summary>
		/// 见闻
		/// </summary>
		public static EncyclopediaTipLinkItem ExperienceChronicle => Instance[55];

		/// <summary>
		/// 秘闻
		/// </summary>
		public static EncyclopediaTipLinkItem Secret => Instance[56];

		/// <summary>
		/// 传承名谱
		/// </summary>
		public static EncyclopediaTipLinkItem InheritanceRecords => Instance[57];

		/// <summary>
		/// 轮回台
		/// </summary>
		public static EncyclopediaTipLinkItem ReincarnationPlatform => Instance[58];

		/// <summary>
		/// 志向
		/// </summary>
		public static EncyclopediaTipLinkItem AspirationInsight => Instance[59];

		/// <summary>
		/// 较艺（准备）
		/// </summary>
		public static EncyclopediaTipLinkItem DebateTopic => Instance[60];

		/// <summary>
		/// 较艺（战斗）
		/// </summary>
		public static EncyclopediaTipLinkItem Debate => Instance[61];

		/// <summary>
		/// 旅行地图
		/// </summary>
		public static EncyclopediaTipLinkItem Travel => Instance[62];

		/// <summary>
		/// 奇书宝典
		/// </summary>
		public static EncyclopediaTipLinkItem SecretTome => Instance[63];

		/// <summary>
		/// 交换物资
		/// </summary>
		public static EncyclopediaTipLinkItem Exchange => Instance[64];

		/// <summary>
		/// 淬毒
		/// </summary>
		public static EncyclopediaTipLinkItem Envenom => Instance[65];

		/// <summary>
		/// 改制
		/// </summary>
		public static EncyclopediaTipLinkItem Alteration => Instance[66];

		/// <summary>
		/// 解毒
		/// </summary>
		public static EncyclopediaTipLinkItem Detoxify => Instance[67];

		/// <summary>
		/// 精制
		/// </summary>
		public static EncyclopediaTipLinkItem Refinement => Instance[68];

		/// <summary>
		/// 修理
		/// </summary>
		public static EncyclopediaTipLinkItem Repair => Instance[69];

		/// <summary>
		/// 制造
		/// </summary>
		public static EncyclopediaTipLinkItem Craft => Instance[70];

		/// <summary>
		/// 促织战斗
		/// </summary>
		public static EncyclopediaTipLinkItem CricketDue => Instance[71];

		/// <summary>
		/// 捉促织
		/// </summary>
		public static EncyclopediaTipLinkItem CricketHunt => Instance[72];

		/// <summary>
		/// 独具匠心
		/// </summary>
		public static EncyclopediaTipLinkItem InventiveMind => Instance[73];

		/// <summary>
		/// 石屋
		/// </summary>
		public static EncyclopediaTipLinkItem StoneHouse => Instance[74];

		/// <summary>
		/// 较艺结算
		/// </summary>
		public static EncyclopediaTipLinkItem DebateRating => Instance[75];

		/// <summary>
		/// 侵袭进度
		/// </summary>
		public static EncyclopediaTipLinkItem InvasionProgress => Instance[76];

		/// <summary>
		/// 姓名
		/// </summary>
		public static EncyclopediaTipLinkItem Name => Instance[77];

		/// <summary>
		/// 生时
		/// </summary>
		public static EncyclopediaTipLinkItem BirthTime => Instance[78];

		/// <summary>
		/// 年龄
		/// </summary>
		public static EncyclopediaTipLinkItem Age => Instance[79];

		/// <summary>
		/// 性别
		/// </summary>
		public static EncyclopediaTipLinkItem Gender => Instance[80];

		/// <summary>
		/// 魅力
		/// </summary>
		public static EncyclopediaTipLinkItem Charm => Instance[81];

		/// <summary>
		/// 心情
		/// </summary>
		public static EncyclopediaTipLinkItem Mood => Instance[82];

		/// <summary>
		/// 立场
		/// </summary>
		public static EncyclopediaTipLinkItem Mindset => Instance[83];

		/// <summary>
		/// 身份
		/// </summary>
		public static EncyclopediaTipLinkItem Rank => Instance[84];

		/// <summary>
		/// 好感
		/// </summary>
		public static EncyclopediaTipLinkItem Favorability => Instance[85];

		/// <summary>
		/// 称号
		/// </summary>
		public static EncyclopediaTipLinkItem CharacterTitle => Instance[86];

		/// <summary>
		/// 主要属性
		/// </summary>
		public static EncyclopediaTipLinkItem PrimaryAttributes => Instance[87];

		/// <summary>
		/// 战斗属性
		/// </summary>
		public static EncyclopediaTipLinkItem BattleAttributes => Instance[88];

		/// <summary>
		/// 特性
		/// </summary>
		public static EncyclopediaTipLinkItem Trait => Instance[89];

		/// <summary>
		/// 七元赋性
		/// </summary>
		public static EncyclopediaTipLinkItem Dispositions => Instance[90];

		/// <summary>
		/// 健康
		/// </summary>
		public static EncyclopediaTipLinkItem Health => Instance[91];

		/// <summary>
		/// 伤势
		/// </summary>
		public static EncyclopediaTipLinkItem Injuries => Instance[92];

		/// <summary>
		/// 毒素
		/// </summary>
		public static EncyclopediaTipLinkItem Toxin => Instance[93];

		/// <summary>
		/// 内息
		/// </summary>
		public static EncyclopediaTipLinkItem InnerBreath => Instance[94];

		/// <summary>
		/// 服食汲饮
		/// </summary>
		public static EncyclopediaTipLinkItem OralMedication => Instance[95];

		/// <summary>
		/// 爱慕
		/// </summary>
		public static EncyclopediaTipLinkItem Love => Instance[96];

		/// <summary>
		/// 仇敌
		/// </summary>
		public static EncyclopediaTipLinkItem Enemy => Instance[97];

		/// <summary>
		/// 验毒
		/// </summary>
		public static EncyclopediaTipLinkItem TestingPoison => Instance[98];

		/// <summary>
		/// 建筑
		/// </summary>
		public static EncyclopediaTipLinkItem Buildings => Instance[99];

		/// <summary>
		/// 较艺策略
		/// </summary>
		public static EncyclopediaTipLinkItem DebateStrategy => Instance[100];

		/// <summary>
		/// 技艺见闻
		/// </summary>
		public static EncyclopediaTipLinkItem FineArtsInsight => Instance[101];

		/// <summary>
		/// 内外功比例
		/// </summary>
		public static EncyclopediaTipLinkItem MartialArtsRatio => Instance[102];

		/// <summary>
		/// 精解
		/// </summary>
		public static EncyclopediaTipLinkItem Simplification => Instance[103];

		/// <summary>
		/// 丹田内力
		/// </summary>
		public static EncyclopediaTipLinkItem DantianQi => Instance[104];

		/// <summary>
		/// 精纯境界
		/// </summary>
		public static EncyclopediaTipLinkItem PureEssence => Instance[105];

		/// <summary>
		/// 真气
		/// </summary>
		public static EncyclopediaTipLinkItem TrueQi => Instance[106];

		/// <summary>
		/// 架势
		/// </summary>
		public static EncyclopediaTipLinkItem Stance => Instance[107];

		/// <summary>
		/// 提气
		/// </summary>
		public static EncyclopediaTipLinkItem Inhale => Instance[108];

		/// <summary>
		/// 脚力
		/// </summary>
		public static EncyclopediaTipLinkItem Footwork => Instance[109];

		/// <summary>
		/// 距离
		/// </summary>
		public static EncyclopediaTipLinkItem Distance => Instance[110];

		/// <summary>
		/// 招式
		/// </summary>
		public static EncyclopediaTipLinkItem CombatMoves => Instance[111];

		/// <summary>
		/// 变招
		/// </summary>
		public static EncyclopediaTipLinkItem PinpointStrikes => Instance[112];

		/// <summary>
		/// 战败标记
		/// </summary>
		public static EncyclopediaTipLinkItem DefeatMarkers => Instance[113];

		/// <summary>
		/// 战斗状态
		/// </summary>
		public static EncyclopediaTipLinkItem BattleStatus => Instance[114];

		/// <summary>
		/// 破绽
		/// </summary>
		public static EncyclopediaTipLinkItem Openings => Instance[115];

		/// <summary>
		/// 封穴
		/// </summary>
		public static EncyclopediaTipLinkItem SealedAcupoints => Instance[116];

		/// <summary>
		/// 真气状态
		/// </summary>
		public static EncyclopediaTipLinkItem TrueQiState => Instance[117];

		/// <summary>
		/// 战斗行为
		/// </summary>
		public static EncyclopediaTipLinkItem CombatActions => Instance[118];

		/// <summary>
		/// 观众
		/// </summary>
		public static EncyclopediaTipLinkItem Audience => Instance[119];

		/// <summary>
		/// 采集
		/// </summary>
		public static EncyclopediaTipLinkItem MapBlockCollectResource => Instance[120];

		/// <summary>
		/// 同道
		/// </summary>
		public static EncyclopediaTipLinkItem Companion => Instance[121];

		/// <summary>
		/// 太吾月报
		/// </summary>
		public static EncyclopediaTipLinkItem MonthlyReport => Instance[122];

		/// <summary>
		/// 人物互动
		/// </summary>
		public static EncyclopediaTipLinkItem Talk => Instance[123];

		/// <summary>
		/// 元鸡
		/// </summary>
		public static EncyclopediaTipLinkItem Chicken => Instance[124];

		/// <summary>
		/// 学艺许可
		/// </summary>
		public static EncyclopediaTipLinkItem SectLearPermisson => Instance[125];

		/// <summary>
		/// 门派恩义互动
		/// </summary>
		public static EncyclopediaTipLinkItem SectDebtInteraction => Instance[126];

		/// <summary>
		/// 交换私人藏书
		/// </summary>
		public static EncyclopediaTipLinkItem BookExchangePersonal => Instance[127];

		/// <summary>
		/// 紫竹化身
		/// </summary>
		public static EncyclopediaTipLinkItem JuniorXiangshu => Instance[128];

		/// <summary>
		/// 库房交换
		/// </summary>
		public static EncyclopediaTipLinkItem WarehouseExchange => Instance[129];

		/// <summary>
		/// 创建人物
		/// </summary>
		public static EncyclopediaTipLinkItem CharacterCreate => Instance[130];

		/// <summary>
		/// 出生地区
		/// </summary>
		public static EncyclopediaTipLinkItem BornArea => Instance[131];

		/// <summary>
		/// 内力属性
		/// </summary>
		public static EncyclopediaTipLinkItem NeiliProperty => Instance[132];

		/// <summary>
		/// 出身特质
		/// </summary>
		public static EncyclopediaTipLinkItem PresetTricks => Instance[133];

		/// <summary>
		/// 世界细节
		/// </summary>
		public static EncyclopediaTipLinkItem WorldDetail => Instance[134];

		/// <summary>
		/// 玄狱模式
		/// </summary>
		public static EncyclopediaTipLinkItem ChallengeMode => Instance[135];

		/// <summary>
		/// 门派
		/// </summary>
		public static EncyclopediaTipLinkItem Sect => Instance[136];

		/// <summary>
		/// 心韵激荡
		/// </summary>
		public static EncyclopediaTipLinkItem MindUpheaval => Instance[137];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static EncyclopediaTipLink Instance = new EncyclopediaTipLink();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "TemplateId", "RefName", "Type" };

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
		_dataArray.Add(new EncyclopediaTipLinkItem(0, EEncyclopediaTipLinkMode.Default, "遗惠点数", EEncyclopediaTipLinkType.TipLegacy));
		_dataArray.Add(new EncyclopediaTipLinkItem(1, EEncyclopediaTipLinkMode.Default, "混合毒素", EEncyclopediaTipLinkType.MixPoison));
		_dataArray.Add(new EncyclopediaTipLinkItem(2, EEncyclopediaTipLinkMode.Default, "伏虞剑柄", EEncyclopediaTipLinkType.FuyuSwordGrip));
		_dataArray.Add(new EncyclopediaTipLinkItem(3, EEncyclopediaTipLinkMode.Default, "名誉", EEncyclopediaTipLinkType.Fame));
		_dataArray.Add(new EncyclopediaTipLinkItem(4, EEncyclopediaTipLinkMode.Default, "助战指令", EEncyclopediaTipLinkType.SupportCommands));
		_dataArray.Add(new EncyclopediaTipLinkItem(5, EEncyclopediaTipLinkMode.Default, "拆解", EEncyclopediaTipLinkType.Disassembly));
		_dataArray.Add(new EncyclopediaTipLinkItem(6, EEncyclopediaTipLinkMode.Default, "装备", EEncyclopediaTipLinkType.Equip));
		_dataArray.Add(new EncyclopediaTipLinkItem(7, EEncyclopediaTipLinkMode.Default, "主要装备", EEncyclopediaTipLinkType.MainEquip));
		_dataArray.Add(new EncyclopediaTipLinkItem(8, EEncyclopediaTipLinkMode.Default, "次要装备", EEncyclopediaTipLinkType.SecondaryEquipment));
		_dataArray.Add(new EncyclopediaTipLinkItem(9, EEncyclopediaTipLinkMode.Default, "人物-人物信息-资质", EEncyclopediaTipLinkType.Talent));
		_dataArray.Add(new EncyclopediaTipLinkItem(10, EEncyclopediaTipLinkMode.Default, "修习-技艺-技艺", EEncyclopediaTipLinkType.FineArts));
		_dataArray.Add(new EncyclopediaTipLinkItem(11, EEncyclopediaTipLinkMode.Default, "修习-武学-功法", EEncyclopediaTipLinkType.MartialArts));
		_dataArray.Add(new EncyclopediaTipLinkItem(12, EEncyclopediaTipLinkMode.Default, "人物-人物信息-造诣", EEncyclopediaTipLinkType.Attainment));
		_dataArray.Add(new EncyclopediaTipLinkItem(13, EEncyclopediaTipLinkMode.Default, "突破", EEncyclopediaTipLinkType.Breakthrough));
		_dataArray.Add(new EncyclopediaTipLinkItem(14, EEncyclopediaTipLinkMode.Default, "玄机", EEncyclopediaTipLinkType.Mechanism));
		_dataArray.Add(new EncyclopediaTipLinkItem(15, EEncyclopediaTipLinkMode.Default, "内力属性", EEncyclopediaTipLinkType.QiAttributes));
		_dataArray.Add(new EncyclopediaTipLinkItem(16, EEncyclopediaTipLinkMode.Default, "关系", EEncyclopediaTipLinkType.Relation));
		_dataArray.Add(new EncyclopediaTipLinkItem(17, EEncyclopediaTipLinkMode.Default, "俘虏", EEncyclopediaTipLinkType.Captive));
		_dataArray.Add(new EncyclopediaTipLinkItem(18, EEncyclopediaTipLinkMode.Default, "经历", EEncyclopediaTipLinkType.Experience));
		_dataArray.Add(new EncyclopediaTipLinkItem(19, EEncyclopediaTipLinkMode.Default, "轮回", EEncyclopediaTipLinkType.Reincarnation));
		_dataArray.Add(new EncyclopediaTipLinkItem(20, EEncyclopediaTipLinkMode.Default, "精挑细选", EEncyclopediaTipLinkType.Handpick));
		_dataArray.Add(new EncyclopediaTipLinkItem(21, EEncyclopediaTipLinkMode.Default, "运功", EEncyclopediaTipLinkType.MartialLoadout));
		_dataArray.Add(new EncyclopediaTipLinkItem(22, EEncyclopediaTipLinkMode.Default, "戒心", EEncyclopediaTipLinkType.Wariness));
		_dataArray.Add(new EncyclopediaTipLinkItem(23, EEncyclopediaTipLinkMode.Default, "族谱", EEncyclopediaTipLinkType.Bloodline));
		_dataArray.Add(new EncyclopediaTipLinkItem(24, EEncyclopediaTipLinkMode.Default, "生铸", EEncyclopediaTipLinkType.Reforged));
		_dataArray.Add(new EncyclopediaTipLinkItem(25, EEncyclopediaTipLinkMode.Default, "铭刻", EEncyclopediaTipLinkType.Imprint));
		_dataArray.Add(new EncyclopediaTipLinkItem(26, EEncyclopediaTipLinkMode.Default, "研读书籍", EEncyclopediaTipLinkType.StudyingBooks));
		_dataArray.Add(new EncyclopediaTipLinkItem(27, EEncyclopediaTipLinkMode.Default, "周天运转", EEncyclopediaTipLinkType.MicrocosmicCirculation));
		_dataArray.Add(new EncyclopediaTipLinkItem(28, EEncyclopediaTipLinkMode.Default, "诊疗", EEncyclopediaTipLinkType.MedicalCare));
		_dataArray.Add(new EncyclopediaTipLinkItem(29, EEncyclopediaTipLinkMode.Default, "势力", EEncyclopediaTipLinkType.Faction));
		_dataArray.Add(new EncyclopediaTipLinkItem(30, EEncyclopediaTipLinkMode.Default, "太吾传承", EEncyclopediaTipLinkType.TaiwuInheritance));
		_dataArray.Add(new EncyclopediaTipLinkItem(31, EEncyclopediaTipLinkMode.Default, "门派-门派一览-少林派-特有功能", EEncyclopediaTipLinkType.Shaolin));
		_dataArray.Add(new EncyclopediaTipLinkItem(32, EEncyclopediaTipLinkMode.Default, "特有功能2", EEncyclopediaTipLinkType.Emei));
		_dataArray.Add(new EncyclopediaTipLinkItem(33, EEncyclopediaTipLinkMode.Default, "特有功能3", EEncyclopediaTipLinkType.BaihuaLifeLink));
		_dataArray.Add(new EncyclopediaTipLinkItem(34, EEncyclopediaTipLinkMode.Default, "特有功能4", EEncyclopediaTipLinkType.WudangTree));
		_dataArray.Add(new EncyclopediaTipLinkItem(35, EEncyclopediaTipLinkMode.Default, "特有功能5", EEncyclopediaTipLinkType.Yuanshan));
		_dataArray.Add(new EncyclopediaTipLinkItem(36, EEncyclopediaTipLinkMode.Default, "特有功能6", EEncyclopediaTipLinkType.Shixiang));
		_dataArray.Add(new EncyclopediaTipLinkItem(37, EEncyclopediaTipLinkMode.Default, "特有功能7", EEncyclopediaTipLinkType.Ranshan));
		_dataArray.Add(new EncyclopediaTipLinkItem(38, EEncyclopediaTipLinkMode.Default, "特有功能8", EEncyclopediaTipLinkType.Xuannv));
		_dataArray.Add(new EncyclopediaTipLinkItem(39, EEncyclopediaTipLinkMode.Default, "特有功能9", EEncyclopediaTipLinkType.ZhujianGearMate));
		_dataArray.Add(new EncyclopediaTipLinkItem(40, EEncyclopediaTipLinkMode.Default, "特有功能10", EEncyclopediaTipLinkType.Kongsang));
		_dataArray.Add(new EncyclopediaTipLinkItem(41, EEncyclopediaTipLinkMode.Default, "特有功能11", EEncyclopediaTipLinkType.Jingang));
		_dataArray.Add(new EncyclopediaTipLinkItem(42, EEncyclopediaTipLinkMode.Default, "特有功能12", EEncyclopediaTipLinkType.WugKing));
		_dataArray.Add(new EncyclopediaTipLinkItem(43, EEncyclopediaTipLinkMode.Default, "特有功能13", EEncyclopediaTipLinkType.Jieqing));
		_dataArray.Add(new EncyclopediaTipLinkItem(44, EEncyclopediaTipLinkMode.Default, "特有功能15", EEncyclopediaTipLinkType.Xuehou));
		_dataArray.Add(new EncyclopediaTipLinkItem(45, EEncyclopediaTipLinkMode.Default, "元鸡舍", EEncyclopediaTipLinkType.ChickenCoop));
		_dataArray.Add(new EncyclopediaTipLinkItem(46, EEncyclopediaTipLinkMode.Default, "茶马帮", EEncyclopediaTipLinkType.TeaHorseCaravan));
		_dataArray.Add(new EncyclopediaTipLinkItem(47, EEncyclopediaTipLinkMode.Default, "蛰室", EEncyclopediaTipLinkType.CricketChamber));
		_dataArray.Add(new EncyclopediaTipLinkItem(48, EEncyclopediaTipLinkMode.Default, "太吾村", EEncyclopediaTipLinkType.TaiwuVillage));
		_dataArray.Add(new EncyclopediaTipLinkItem(49, EEncyclopediaTipLinkMode.Default, "宴堂", EEncyclopediaTipLinkType.BanquetHall));
		_dataArray.Add(new EncyclopediaTipLinkItem(50, EEncyclopediaTipLinkMode.Default, "产业建筑", EEncyclopediaTipLinkType.IndustryBuildings));
		_dataArray.Add(new EncyclopediaTipLinkItem(51, EEncyclopediaTipLinkMode.Default, "木人战斗", EEncyclopediaTipLinkType.WoodeDummy));
		_dataArray.Add(new EncyclopediaTipLinkItem(52, EEncyclopediaTipLinkMode.Default, "练习功法", EEncyclopediaTipLinkType.PracticeTechnique));
		_dataArray.Add(new EncyclopediaTipLinkItem(53, EEncyclopediaTipLinkMode.Default, "监牢", EEncyclopediaTipLinkType.Prison));
		_dataArray.Add(new EncyclopediaTipLinkItem(54, EEncyclopediaTipLinkMode.Default, "库房", EEncyclopediaTipLinkType.Warehouse));
		_dataArray.Add(new EncyclopediaTipLinkItem(55, EEncyclopediaTipLinkMode.Default, "见闻", EEncyclopediaTipLinkType.ExperienceChronicle));
		_dataArray.Add(new EncyclopediaTipLinkItem(56, EEncyclopediaTipLinkMode.Default, "秘闻", EEncyclopediaTipLinkType.Secret));
		_dataArray.Add(new EncyclopediaTipLinkItem(57, EEncyclopediaTipLinkMode.Default, "传承名谱", EEncyclopediaTipLinkType.InheritanceRecords));
		_dataArray.Add(new EncyclopediaTipLinkItem(58, EEncyclopediaTipLinkMode.Default, "轮回台", EEncyclopediaTipLinkType.ReincarnationPlatform));
		_dataArray.Add(new EncyclopediaTipLinkItem(59, EEncyclopediaTipLinkMode.Default, "志向", EEncyclopediaTipLinkType.AspirationInsight));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new EncyclopediaTipLinkItem(60, EEncyclopediaTipLinkMode.Default, "较艺主题", EEncyclopediaTipLinkType.DebateTopic));
		_dataArray.Add(new EncyclopediaTipLinkItem(61, EEncyclopediaTipLinkMode.Default, "较艺", EEncyclopediaTipLinkType.Debate));
		_dataArray.Add(new EncyclopediaTipLinkItem(62, EEncyclopediaTipLinkMode.Default, "旅行", EEncyclopediaTipLinkType.Travel));
		_dataArray.Add(new EncyclopediaTipLinkItem(63, EEncyclopediaTipLinkMode.Default, "解读奇书", EEncyclopediaTipLinkType.SecretTome));
		_dataArray.Add(new EncyclopediaTipLinkItem(64, EEncyclopediaTipLinkMode.Default, "交换物资", EEncyclopediaTipLinkType.Exchange));
		_dataArray.Add(new EncyclopediaTipLinkItem(65, EEncyclopediaTipLinkMode.Default, "淬毒", EEncyclopediaTipLinkType.Envenom));
		_dataArray.Add(new EncyclopediaTipLinkItem(66, EEncyclopediaTipLinkMode.Default, "改制", EEncyclopediaTipLinkType.Alteration));
		_dataArray.Add(new EncyclopediaTipLinkItem(67, EEncyclopediaTipLinkMode.Default, "解毒", EEncyclopediaTipLinkType.Detoxify));
		_dataArray.Add(new EncyclopediaTipLinkItem(68, EEncyclopediaTipLinkMode.Default, "精制", EEncyclopediaTipLinkType.Refinement));
		_dataArray.Add(new EncyclopediaTipLinkItem(69, EEncyclopediaTipLinkMode.Default, "修理", EEncyclopediaTipLinkType.Repair));
		_dataArray.Add(new EncyclopediaTipLinkItem(70, EEncyclopediaTipLinkMode.Default, "制造", EEncyclopediaTipLinkType.Craft));
		_dataArray.Add(new EncyclopediaTipLinkItem(71, EEncyclopediaTipLinkMode.Default, "促织决斗", EEncyclopediaTipLinkType.CricketDue));
		_dataArray.Add(new EncyclopediaTipLinkItem(72, EEncyclopediaTipLinkMode.Default, "捕捉促织", EEncyclopediaTipLinkType.CricketHunt));
		_dataArray.Add(new EncyclopediaTipLinkItem(73, EEncyclopediaTipLinkMode.Default, "独具匠心", EEncyclopediaTipLinkType.InventiveMind));
		_dataArray.Add(new EncyclopediaTipLinkItem(74, EEncyclopediaTipLinkMode.Default, "石屋", EEncyclopediaTipLinkType.StoneHouse));
		_dataArray.Add(new EncyclopediaTipLinkItem(75, EEncyclopediaTipLinkMode.Default, "较艺评价", EEncyclopediaTipLinkType.DebateRating));
		_dataArray.Add(new EncyclopediaTipLinkItem(76, EEncyclopediaTipLinkMode.Default, "侵袭进度", EEncyclopediaTipLinkType.InvasionProgress));
		_dataArray.Add(new EncyclopediaTipLinkItem(77, EEncyclopediaTipLinkMode.Default, "姓名", EEncyclopediaTipLinkType.Name));
		_dataArray.Add(new EncyclopediaTipLinkItem(78, EEncyclopediaTipLinkMode.Default, "生时", EEncyclopediaTipLinkType.BirthTime));
		_dataArray.Add(new EncyclopediaTipLinkItem(79, EEncyclopediaTipLinkMode.Default, "年龄", EEncyclopediaTipLinkType.Age));
		_dataArray.Add(new EncyclopediaTipLinkItem(80, EEncyclopediaTipLinkMode.Default, "性别", EEncyclopediaTipLinkType.Gender));
		_dataArray.Add(new EncyclopediaTipLinkItem(81, EEncyclopediaTipLinkMode.Default, "魅力", EEncyclopediaTipLinkType.Charm));
		_dataArray.Add(new EncyclopediaTipLinkItem(82, EEncyclopediaTipLinkMode.Default, "心情", EEncyclopediaTipLinkType.Mood));
		_dataArray.Add(new EncyclopediaTipLinkItem(83, EEncyclopediaTipLinkMode.Default, "立场", EEncyclopediaTipLinkType.Mindset));
		_dataArray.Add(new EncyclopediaTipLinkItem(84, EEncyclopediaTipLinkMode.Default, "身份", EEncyclopediaTipLinkType.Rank));
		_dataArray.Add(new EncyclopediaTipLinkItem(85, EEncyclopediaTipLinkMode.Default, "好感", EEncyclopediaTipLinkType.Favorability));
		_dataArray.Add(new EncyclopediaTipLinkItem(86, EEncyclopediaTipLinkMode.Default, "称号", EEncyclopediaTipLinkType.CharacterTitle));
		_dataArray.Add(new EncyclopediaTipLinkItem(87, EEncyclopediaTipLinkMode.Default, "主要属性", EEncyclopediaTipLinkType.PrimaryAttributes));
		_dataArray.Add(new EncyclopediaTipLinkItem(88, EEncyclopediaTipLinkMode.Default, "战斗属性", EEncyclopediaTipLinkType.BattleAttributes));
		_dataArray.Add(new EncyclopediaTipLinkItem(89, EEncyclopediaTipLinkMode.Default, "特性", EEncyclopediaTipLinkType.Trait));
		_dataArray.Add(new EncyclopediaTipLinkItem(90, EEncyclopediaTipLinkMode.Default, "七元赋性", EEncyclopediaTipLinkType.Dispositions));
		_dataArray.Add(new EncyclopediaTipLinkItem(91, EEncyclopediaTipLinkMode.Default, "健康", EEncyclopediaTipLinkType.Health));
		_dataArray.Add(new EncyclopediaTipLinkItem(92, EEncyclopediaTipLinkMode.Default, "伤势", EEncyclopediaTipLinkType.Injuries));
		_dataArray.Add(new EncyclopediaTipLinkItem(93, EEncyclopediaTipLinkMode.Default, "毒素", EEncyclopediaTipLinkType.Toxin));
		_dataArray.Add(new EncyclopediaTipLinkItem(94, EEncyclopediaTipLinkMode.Default, "内息", EEncyclopediaTipLinkType.InnerBreath));
		_dataArray.Add(new EncyclopediaTipLinkItem(95, EEncyclopediaTipLinkMode.Default, "服食汲饮", EEncyclopediaTipLinkType.OralMedication));
		_dataArray.Add(new EncyclopediaTipLinkItem(96, EEncyclopediaTipLinkMode.Default, "爱慕", EEncyclopediaTipLinkType.Love));
		_dataArray.Add(new EncyclopediaTipLinkItem(97, EEncyclopediaTipLinkMode.Default, "仇敌", EEncyclopediaTipLinkType.Enemy));
		_dataArray.Add(new EncyclopediaTipLinkItem(98, EEncyclopediaTipLinkMode.Default, "验毒", EEncyclopediaTipLinkType.TestingPoison));
		_dataArray.Add(new EncyclopediaTipLinkItem(99, EEncyclopediaTipLinkMode.Default, "建筑", EEncyclopediaTipLinkType.Buildings));
		_dataArray.Add(new EncyclopediaTipLinkItem(100, EEncyclopediaTipLinkMode.Default, "较艺策略", EEncyclopediaTipLinkType.DebateStrategy));
		_dataArray.Add(new EncyclopediaTipLinkItem(101, EEncyclopediaTipLinkMode.Default, "技艺见闻", EEncyclopediaTipLinkType.FineArtsInsight));
		_dataArray.Add(new EncyclopediaTipLinkItem(102, EEncyclopediaTipLinkMode.Default, "内外功比例", EEncyclopediaTipLinkType.MartialArtsRatio));
		_dataArray.Add(new EncyclopediaTipLinkItem(103, EEncyclopediaTipLinkMode.Default, "精解", EEncyclopediaTipLinkType.Simplification));
		_dataArray.Add(new EncyclopediaTipLinkItem(104, EEncyclopediaTipLinkMode.Default, "丹田内力", EEncyclopediaTipLinkType.DantianQi));
		_dataArray.Add(new EncyclopediaTipLinkItem(105, EEncyclopediaTipLinkMode.Default, "精纯境界", EEncyclopediaTipLinkType.PureEssence));
		_dataArray.Add(new EncyclopediaTipLinkItem(106, EEncyclopediaTipLinkMode.Default, "真气", EEncyclopediaTipLinkType.TrueQi));
		_dataArray.Add(new EncyclopediaTipLinkItem(107, EEncyclopediaTipLinkMode.Default, "架势", EEncyclopediaTipLinkType.Stance));
		_dataArray.Add(new EncyclopediaTipLinkItem(108, EEncyclopediaTipLinkMode.Default, "提气", EEncyclopediaTipLinkType.Inhale));
		_dataArray.Add(new EncyclopediaTipLinkItem(109, EEncyclopediaTipLinkMode.Default, "脚力", EEncyclopediaTipLinkType.Footwork));
		_dataArray.Add(new EncyclopediaTipLinkItem(110, EEncyclopediaTipLinkMode.Default, "距离", EEncyclopediaTipLinkType.Distance));
		_dataArray.Add(new EncyclopediaTipLinkItem(111, EEncyclopediaTipLinkMode.Default, "招式", EEncyclopediaTipLinkType.CombatMoves));
		_dataArray.Add(new EncyclopediaTipLinkItem(112, EEncyclopediaTipLinkMode.Default, "变招", EEncyclopediaTipLinkType.PinpointStrikes));
		_dataArray.Add(new EncyclopediaTipLinkItem(113, EEncyclopediaTipLinkMode.Default, "战败标记", EEncyclopediaTipLinkType.DefeatMarkers));
		_dataArray.Add(new EncyclopediaTipLinkItem(114, EEncyclopediaTipLinkMode.Default, "战斗状态", EEncyclopediaTipLinkType.BattleStatus));
		_dataArray.Add(new EncyclopediaTipLinkItem(115, EEncyclopediaTipLinkMode.Default, "破绽", EEncyclopediaTipLinkType.Openings));
		_dataArray.Add(new EncyclopediaTipLinkItem(116, EEncyclopediaTipLinkMode.Default, "封穴", EEncyclopediaTipLinkType.SealedAcupoints));
		_dataArray.Add(new EncyclopediaTipLinkItem(117, EEncyclopediaTipLinkMode.Default, "真气状态", EEncyclopediaTipLinkType.TrueQiState));
		_dataArray.Add(new EncyclopediaTipLinkItem(118, EEncyclopediaTipLinkMode.Default, "战斗行为", EEncyclopediaTipLinkType.CombatActions));
		_dataArray.Add(new EncyclopediaTipLinkItem(119, EEncyclopediaTipLinkMode.Default, "观众", EEncyclopediaTipLinkType.Audience));
	}

	private void CreateItems2()
	{
		_dataArray.Add(new EncyclopediaTipLinkItem(120, EEncyclopediaTipLinkMode.Default, "采集", EEncyclopediaTipLinkType.MapBlockCollectResource));
		_dataArray.Add(new EncyclopediaTipLinkItem(121, EEncyclopediaTipLinkMode.Default, "同道", EEncyclopediaTipLinkType.Companion));
		_dataArray.Add(new EncyclopediaTipLinkItem(122, EEncyclopediaTipLinkMode.Default, "太吾月报", EEncyclopediaTipLinkType.MonthlyReport));
		_dataArray.Add(new EncyclopediaTipLinkItem(123, EEncyclopediaTipLinkMode.Default, "人物互动", EEncyclopediaTipLinkType.Talk));
		_dataArray.Add(new EncyclopediaTipLinkItem(124, EEncyclopediaTipLinkMode.Default, "元鸡", EEncyclopediaTipLinkType.Chicken));
		_dataArray.Add(new EncyclopediaTipLinkItem(125, EEncyclopediaTipLinkMode.Default, "学艺许可", EEncyclopediaTipLinkType.SectLearPermisson));
		_dataArray.Add(new EncyclopediaTipLinkItem(126, EEncyclopediaTipLinkMode.Default, "门派恩义互动", EEncyclopediaTipLinkType.SectDebtInteraction));
		_dataArray.Add(new EncyclopediaTipLinkItem(127, EEncyclopediaTipLinkMode.Default, "交换私人藏书", EEncyclopediaTipLinkType.BookExchangePersonal));
		_dataArray.Add(new EncyclopediaTipLinkItem(128, EEncyclopediaTipLinkMode.Default, "紫竹化身", EEncyclopediaTipLinkType.JuniorXiangshu));
		_dataArray.Add(new EncyclopediaTipLinkItem(129, EEncyclopediaTipLinkMode.Default, "库房交换", EEncyclopediaTipLinkType.WarehouseExchange));
		_dataArray.Add(new EncyclopediaTipLinkItem(130, EEncyclopediaTipLinkMode.Default, "创建人物", EEncyclopediaTipLinkType.CharacterCreate));
		_dataArray.Add(new EncyclopediaTipLinkItem(131, EEncyclopediaTipLinkMode.Default, "出生地区", EEncyclopediaTipLinkType.BornArea));
		_dataArray.Add(new EncyclopediaTipLinkItem(132, EEncyclopediaTipLinkMode.Default, "内力属性", EEncyclopediaTipLinkType.NeiliProperty));
		_dataArray.Add(new EncyclopediaTipLinkItem(133, EEncyclopediaTipLinkMode.Default, "出身特质", EEncyclopediaTipLinkType.PresetTricks));
		_dataArray.Add(new EncyclopediaTipLinkItem(134, EEncyclopediaTipLinkMode.Default, "世界细节", EEncyclopediaTipLinkType.WorldDetail));
		_dataArray.Add(new EncyclopediaTipLinkItem(135, EEncyclopediaTipLinkMode.Default, "玄狱模式", EEncyclopediaTipLinkType.ChallengeMode));
		_dataArray.Add(new EncyclopediaTipLinkItem(136, EEncyclopediaTipLinkMode.Default, "门派", EEncyclopediaTipLinkType.Sect));
		_dataArray.Add(new EncyclopediaTipLinkItem(137, EEncyclopediaTipLinkMode.Default, "心韵激荡", EEncyclopediaTipLinkType.MindUpheaval));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<EncyclopediaTipLinkItem>(138);
		CreateItems0();
		CreateItems1();
		CreateItems2();
	}
}
