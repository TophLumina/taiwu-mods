using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class LegacyPoint : ConfigData<LegacyPointItem, short>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 初次结识
		/// </summary>
		public const short MeetNewPeople = 0;

		/// <summary>
		/// 呼朋唤友
		/// </summary>
		public const short MakeFriends = 1;

		/// <summary>
		/// 结为爱侣
		/// </summary>
		public const short BecomeLovers = 2;

		/// <summary>
		/// 缘定三生
		/// </summary>
		public const short MarryLovedOne = 3;

		/// <summary>
		/// 生儿育女
		/// </summary>
		public const short HaveChildren = 4;

		/// <summary>
		/// 义结金兰
		/// </summary>
		public const short SwornBrothersAndSisters = 5;

		/// <summary>
		/// 收养义儿
		/// </summary>
		public const short AdoptChildren = 6;

		/// <summary>
		/// 拜认父母
		/// </summary>
		public const short GetAdopted = 7;

		/// <summary>
		/// 万念不绝
		/// </summary>
		public const short ChallengeMode = 51;

		/// <summary>
		/// 切磋胜利
		/// </summary>
		public const short CombatToPlay = 8;

		/// <summary>
		/// 接招胜利
		/// </summary>
		public const short CombatToTest = 9;

		/// <summary>
		/// 恶斗胜利
		/// </summary>
		public const short CombatToBeat = 10;

		/// <summary>
		/// 死斗胜利
		/// </summary>
		public const short CombatToKill = 11;

		/// <summary>
		/// 失心救治
		/// </summary>
		public const short SaveTheInfected = 12;

		/// <summary>
		/// 剿灭巢穴
		/// </summary>
		public const short DestroyEnemyNest = 13;

		/// <summary>
		/// 习得技艺
		/// </summary>
		public const short LearnLifeSkill = 14;

		/// <summary>
		/// 解读书页1
		/// </summary>
		public const short ReadLifeSkillNormalPage = 15;

		/// <summary>
		/// 解读残页1
		/// </summary>
		public const short ReadLifeSkillIncompletePage = 16;

		/// <summary>
		/// 技艺大成
		/// </summary>
		public const short FinishLifeSkillBook = 17;

		/// <summary>
		/// 较艺胜利
		/// </summary>
		public const short LifeSkillBattleWin = 18;

		/// <summary>
		/// 传授技艺
		/// </summary>
		public const short TeachLifeSkillInShrine = 19;

		/// <summary>
		/// 研读策略
		/// </summary>
		public const short ReadingStrategyUesd = 47;

		/// <summary>
		/// 习得功法
		/// </summary>
		public const short LearnCombatSkill = 20;

		/// <summary>
		/// 解读书页2
		/// </summary>
		public const short ReadCombatSkillNormalPage = 21;

		/// <summary>
		/// 解读残页2
		/// </summary>
		public const short ReadCombatSkillIncompletePage = 22;

		/// <summary>
		/// 练成功法
		/// </summary>
		public const short ProficiencyEnough = 23;

		/// <summary>
		/// 突破功法
		/// </summary>
		public const short BreakoutCombatSkill = 24;

		/// <summary>
		/// 传授功法
		/// </summary>
		public const short TeachCombatSkillInShrine = 25;

		/// <summary>
		/// 周天策略
		/// </summary>
		public const short QiArtStrategy = 48;

		/// <summary>
		/// 打通玄机
		/// </summary>
		public const short SkillBreakMystery = 49;

		/// <summary>
		/// 建设村庄
		/// </summary>
		public const short ConstructVillage = 26;

		/// <summary>
		/// 扩建建筑
		/// </summary>
		public const short ExpandVillage = 27;

		/// <summary>
		/// 资源收获
		/// </summary>
		public const short GainResources = 28;

		/// <summary>
		/// 经营收获
		/// </summary>
		public const short ManagementGain = 29;

		/// <summary>
		/// 制造珍品
		/// </summary>
		public const short CraftValuableItem = 30;

		/// <summary>
		/// 招揽人才
		/// </summary>
		public const short HireGoodWorker = 31;

		/// <summary>
		/// 任命村民
		/// </summary>
		public const short AppointVillagers = 50;

		/// <summary>
		/// 捕捉促织
		/// </summary>
		public const short CatchCricket = 32;

		/// <summary>
		/// 促织决斗
		/// </summary>
		public const short CricketBattle = 33;

		/// <summary>
		/// 获得见闻
		/// </summary>
		public const short GainInformation = 34;

		/// <summary>
		/// 使用见闻
		/// </summary>
		public const short UseInformation = 35;

		/// <summary>
		/// 递送拜帖
		/// </summary>
		public const short DeliverSaluteToSect = 36;

		/// <summary>
		/// 传驿通路
		/// </summary>
		public const short UnlockStation = 37;

		/// <summary>
		/// 获取支持
		/// </summary>
		public const short GetSupportFromSectMembers = 38;

		/// <summary>
		/// 完成奇遇
		/// </summary>
		public const short CompleteAdventure = 39;

		/// <summary>
		/// 志向初成
		/// </summary>
		public const short PrimaryProfession = 42;

		/// <summary>
		/// 志向深入
		/// </summary>
		public const short MiddleProfession = 43;

		/// <summary>
		/// 志向精熟
		/// </summary>
		public const short AdvancedProfession = 44;

		/// <summary>
		/// 志向达成
		/// </summary>
		public const short MasterProfession = 45;

		/// <summary>
		/// 获得星运
		/// </summary>
		public const short GainExtraLegacyPoint = 46;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 初次结识
		/// </summary>
		public static LegacyPointItem MeetNewPeople => Instance[(short)0];

		/// <summary>
		/// 呼朋唤友
		/// </summary>
		public static LegacyPointItem MakeFriends => Instance[(short)1];

		/// <summary>
		/// 结为爱侣
		/// </summary>
		public static LegacyPointItem BecomeLovers => Instance[(short)2];

		/// <summary>
		/// 缘定三生
		/// </summary>
		public static LegacyPointItem MarryLovedOne => Instance[(short)3];

		/// <summary>
		/// 生儿育女
		/// </summary>
		public static LegacyPointItem HaveChildren => Instance[(short)4];

		/// <summary>
		/// 义结金兰
		/// </summary>
		public static LegacyPointItem SwornBrothersAndSisters => Instance[(short)5];

		/// <summary>
		/// 收养义儿
		/// </summary>
		public static LegacyPointItem AdoptChildren => Instance[(short)6];

		/// <summary>
		/// 拜认父母
		/// </summary>
		public static LegacyPointItem GetAdopted => Instance[(short)7];

		/// <summary>
		/// 万念不绝
		/// </summary>
		public static LegacyPointItem ChallengeMode => Instance[(short)51];

		/// <summary>
		/// 切磋胜利
		/// </summary>
		public static LegacyPointItem CombatToPlay => Instance[(short)8];

		/// <summary>
		/// 接招胜利
		/// </summary>
		public static LegacyPointItem CombatToTest => Instance[(short)9];

		/// <summary>
		/// 恶斗胜利
		/// </summary>
		public static LegacyPointItem CombatToBeat => Instance[(short)10];

		/// <summary>
		/// 死斗胜利
		/// </summary>
		public static LegacyPointItem CombatToKill => Instance[(short)11];

		/// <summary>
		/// 失心救治
		/// </summary>
		public static LegacyPointItem SaveTheInfected => Instance[(short)12];

		/// <summary>
		/// 剿灭巢穴
		/// </summary>
		public static LegacyPointItem DestroyEnemyNest => Instance[(short)13];

		/// <summary>
		/// 习得技艺
		/// </summary>
		public static LegacyPointItem LearnLifeSkill => Instance[(short)14];

		/// <summary>
		/// 解读书页1
		/// </summary>
		public static LegacyPointItem ReadLifeSkillNormalPage => Instance[(short)15];

		/// <summary>
		/// 解读残页1
		/// </summary>
		public static LegacyPointItem ReadLifeSkillIncompletePage => Instance[(short)16];

		/// <summary>
		/// 技艺大成
		/// </summary>
		public static LegacyPointItem FinishLifeSkillBook => Instance[(short)17];

		/// <summary>
		/// 较艺胜利
		/// </summary>
		public static LegacyPointItem LifeSkillBattleWin => Instance[(short)18];

		/// <summary>
		/// 传授技艺
		/// </summary>
		public static LegacyPointItem TeachLifeSkillInShrine => Instance[(short)19];

		/// <summary>
		/// 研读策略
		/// </summary>
		public static LegacyPointItem ReadingStrategyUesd => Instance[(short)47];

		/// <summary>
		/// 习得功法
		/// </summary>
		public static LegacyPointItem LearnCombatSkill => Instance[(short)20];

		/// <summary>
		/// 解读书页2
		/// </summary>
		public static LegacyPointItem ReadCombatSkillNormalPage => Instance[(short)21];

		/// <summary>
		/// 解读残页2
		/// </summary>
		public static LegacyPointItem ReadCombatSkillIncompletePage => Instance[(short)22];

		/// <summary>
		/// 练成功法
		/// </summary>
		public static LegacyPointItem ProficiencyEnough => Instance[(short)23];

		/// <summary>
		/// 突破功法
		/// </summary>
		public static LegacyPointItem BreakoutCombatSkill => Instance[(short)24];

		/// <summary>
		/// 传授功法
		/// </summary>
		public static LegacyPointItem TeachCombatSkillInShrine => Instance[(short)25];

		/// <summary>
		/// 周天策略
		/// </summary>
		public static LegacyPointItem QiArtStrategy => Instance[(short)48];

		/// <summary>
		/// 打通玄机
		/// </summary>
		public static LegacyPointItem SkillBreakMystery => Instance[(short)49];

		/// <summary>
		/// 建设村庄
		/// </summary>
		public static LegacyPointItem ConstructVillage => Instance[(short)26];

		/// <summary>
		/// 扩建建筑
		/// </summary>
		public static LegacyPointItem ExpandVillage => Instance[(short)27];

		/// <summary>
		/// 资源收获
		/// </summary>
		public static LegacyPointItem GainResources => Instance[(short)28];

		/// <summary>
		/// 经营收获
		/// </summary>
		public static LegacyPointItem ManagementGain => Instance[(short)29];

		/// <summary>
		/// 制造珍品
		/// </summary>
		public static LegacyPointItem CraftValuableItem => Instance[(short)30];

		/// <summary>
		/// 招揽人才
		/// </summary>
		public static LegacyPointItem HireGoodWorker => Instance[(short)31];

		/// <summary>
		/// 任命村民
		/// </summary>
		public static LegacyPointItem AppointVillagers => Instance[(short)50];

		/// <summary>
		/// 捕捉促织
		/// </summary>
		public static LegacyPointItem CatchCricket => Instance[(short)32];

		/// <summary>
		/// 促织决斗
		/// </summary>
		public static LegacyPointItem CricketBattle => Instance[(short)33];

		/// <summary>
		/// 获得见闻
		/// </summary>
		public static LegacyPointItem GainInformation => Instance[(short)34];

		/// <summary>
		/// 使用见闻
		/// </summary>
		public static LegacyPointItem UseInformation => Instance[(short)35];

		/// <summary>
		/// 递送拜帖
		/// </summary>
		public static LegacyPointItem DeliverSaluteToSect => Instance[(short)36];

		/// <summary>
		/// 传驿通路
		/// </summary>
		public static LegacyPointItem UnlockStation => Instance[(short)37];

		/// <summary>
		/// 获取支持
		/// </summary>
		public static LegacyPointItem GetSupportFromSectMembers => Instance[(short)38];

		/// <summary>
		/// 完成奇遇
		/// </summary>
		public static LegacyPointItem CompleteAdventure => Instance[(short)39];

		/// <summary>
		/// 志向初成
		/// </summary>
		public static LegacyPointItem PrimaryProfession => Instance[(short)42];

		/// <summary>
		/// 志向深入
		/// </summary>
		public static LegacyPointItem MiddleProfession => Instance[(short)43];

		/// <summary>
		/// 志向精熟
		/// </summary>
		public static LegacyPointItem AdvancedProfession => Instance[(short)44];

		/// <summary>
		/// 志向达成
		/// </summary>
		public static LegacyPointItem MasterProfession => Instance[(short)45];

		/// <summary>
		/// 获得星运
		/// </summary>
		public static LegacyPointItem GainExtraLegacyPoint => Instance[(short)46];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static LegacyPoint Instance = new LegacyPoint();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "Type", "BonusTypes", "ConditionDesc", "TemplateId" };

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
		_dataArray.Add(new LegacyPointItem(0, LocalStringManager.GetConfig("LegacyPoint_language", "Name_0"), 0, 5, 500, isHidden: false, new byte[5] { 12, 5, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_0")));
		_dataArray.Add(new LegacyPointItem(1, LocalStringManager.GetConfig("LegacyPoint_language", "Name_1"), 0, 10, 500, isHidden: false, new byte[5] { 12, 5, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_1")));
		_dataArray.Add(new LegacyPointItem(2, LocalStringManager.GetConfig("LegacyPoint_language", "Name_2"), 0, 250, 500, isHidden: false, new byte[5] { 12, 5, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_2")));
		_dataArray.Add(new LegacyPointItem(3, LocalStringManager.GetConfig("LegacyPoint_language", "Name_3"), 0, 500, 500, isHidden: false, new byte[5] { 12, 5, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_3")));
		_dataArray.Add(new LegacyPointItem(4, LocalStringManager.GetConfig("LegacyPoint_language", "Name_4"), 0, 250, 500, isHidden: false, new byte[5] { 12, 5, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_4")));
		_dataArray.Add(new LegacyPointItem(5, LocalStringManager.GetConfig("LegacyPoint_language", "Name_5"), 0, 100, 500, isHidden: false, new byte[5] { 12, 5, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_5")));
		_dataArray.Add(new LegacyPointItem(6, LocalStringManager.GetConfig("LegacyPoint_language", "Name_6"), 0, 250, 500, isHidden: false, new byte[5] { 12, 5, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_6")));
		_dataArray.Add(new LegacyPointItem(7, LocalStringManager.GetConfig("LegacyPoint_language", "Name_7"), 0, 250, 500, isHidden: false, new byte[5] { 12, 5, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_7")));
		_dataArray.Add(new LegacyPointItem(8, LocalStringManager.GetConfig("LegacyPoint_language", "Name_8"), 1, 5, 500, isHidden: false, new byte[9] { 1, 11, 2, 3, 4, 5, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_8")));
		_dataArray.Add(new LegacyPointItem(9, LocalStringManager.GetConfig("LegacyPoint_language", "Name_9"), 1, 10, 500, isHidden: false, new byte[9] { 1, 11, 2, 3, 4, 5, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_9")));
		_dataArray.Add(new LegacyPointItem(10, LocalStringManager.GetConfig("LegacyPoint_language", "Name_10"), 1, 10, 500, isHidden: false, new byte[9] { 1, 11, 2, 3, 4, 5, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_10")));
		_dataArray.Add(new LegacyPointItem(11, LocalStringManager.GetConfig("LegacyPoint_language", "Name_11"), 1, 20, 500, isHidden: false, new byte[9] { 1, 11, 2, 3, 4, 5, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_11")));
		_dataArray.Add(new LegacyPointItem(12, LocalStringManager.GetConfig("LegacyPoint_language", "Name_12"), 1, 20, 1000, isHidden: false, new byte[9] { 1, 11, 2, 3, 4, 5, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_12")));
		_dataArray.Add(new LegacyPointItem(13, LocalStringManager.GetConfig("LegacyPoint_language", "Name_13"), 1, 50, 1000, isHidden: false, new byte[9] { 1, 11, 2, 3, 4, 5, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_13")));
		_dataArray.Add(new LegacyPointItem(14, LocalStringManager.GetConfig("LegacyPoint_language", "Name_14"), 2, 20, 500, isHidden: false, new byte[5] { 2, 5, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_14")));
		_dataArray.Add(new LegacyPointItem(15, LocalStringManager.GetConfig("LegacyPoint_language", "Name_15"), 2, 10, 500, isHidden: false, new byte[5] { 2, 5, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_15")));
		_dataArray.Add(new LegacyPointItem(16, LocalStringManager.GetConfig("LegacyPoint_language", "Name_16"), 2, 20, 500, isHidden: false, new byte[5] { 2, 5, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_16")));
		_dataArray.Add(new LegacyPointItem(17, LocalStringManager.GetConfig("LegacyPoint_language", "Name_17"), 2, 20, 500, isHidden: false, new byte[5] { 2, 5, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_17")));
		_dataArray.Add(new LegacyPointItem(18, LocalStringManager.GetConfig("LegacyPoint_language", "Name_18"), 2, 10, 500, isHidden: false, new byte[5] { 2, 5, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_18")));
		_dataArray.Add(new LegacyPointItem(19, LocalStringManager.GetConfig("LegacyPoint_language", "Name_19"), 2, 5, 500, isHidden: false, new byte[5] { 2, 5, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_19")));
		_dataArray.Add(new LegacyPointItem(20, LocalStringManager.GetConfig("LegacyPoint_language", "Name_20"), 3, 20, 500, isHidden: false, new byte[5] { 2, 5, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_20")));
		_dataArray.Add(new LegacyPointItem(21, LocalStringManager.GetConfig("LegacyPoint_language", "Name_21"), 3, 10, 500, isHidden: false, new byte[5] { 2, 5, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_21")));
		_dataArray.Add(new LegacyPointItem(22, LocalStringManager.GetConfig("LegacyPoint_language", "Name_22"), 3, 20, 500, isHidden: false, new byte[5] { 2, 5, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_22")));
		_dataArray.Add(new LegacyPointItem(23, LocalStringManager.GetConfig("LegacyPoint_language", "Name_23"), 3, 20, 500, isHidden: false, new byte[5] { 2, 5, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_23")));
		_dataArray.Add(new LegacyPointItem(24, LocalStringManager.GetConfig("LegacyPoint_language", "Name_24"), 3, 20, 500, isHidden: false, new byte[6] { 2, 3, 5, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_24")));
		_dataArray.Add(new LegacyPointItem(25, LocalStringManager.GetConfig("LegacyPoint_language", "Name_25"), 3, 5, 500, isHidden: false, new byte[6] { 2, 3, 5, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_25")));
		_dataArray.Add(new LegacyPointItem(26, LocalStringManager.GetConfig("LegacyPoint_language", "Name_26"), 4, 100, 1000, isHidden: false, new byte[4] { 5, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_26")));
		_dataArray.Add(new LegacyPointItem(27, LocalStringManager.GetConfig("LegacyPoint_language", "Name_27"), 4, 20, 1000, isHidden: false, new byte[4] { 5, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_27")));
		_dataArray.Add(new LegacyPointItem(28, LocalStringManager.GetConfig("LegacyPoint_language", "Name_28"), 4, 5, 500, isHidden: false, new byte[4] { 5, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_28")));
		_dataArray.Add(new LegacyPointItem(29, LocalStringManager.GetConfig("LegacyPoint_language", "Name_29"), 4, 5, 500, isHidden: false, new byte[4] { 5, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_29")));
		_dataArray.Add(new LegacyPointItem(30, LocalStringManager.GetConfig("LegacyPoint_language", "Name_30"), 4, 10, 500, isHidden: false, new byte[4] { 5, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_30")));
		_dataArray.Add(new LegacyPointItem(31, LocalStringManager.GetConfig("LegacyPoint_language", "Name_31"), 4, 20, 500, isHidden: false, new byte[4] { 5, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_31")));
		_dataArray.Add(new LegacyPointItem(32, LocalStringManager.GetConfig("LegacyPoint_language", "Name_32"), 5, 10, 500, isHidden: false, new byte[2] { 5, 6 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_32")));
		_dataArray.Add(new LegacyPointItem(33, LocalStringManager.GetConfig("LegacyPoint_language", "Name_33"), 5, 10, 500, isHidden: false, new byte[2] { 5, 6 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_33")));
		_dataArray.Add(new LegacyPointItem(34, LocalStringManager.GetConfig("LegacyPoint_language", "Name_34"), 5, 10, 500, isHidden: false, new byte[2] { 5, 6 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_34")));
		_dataArray.Add(new LegacyPointItem(35, LocalStringManager.GetConfig("LegacyPoint_language", "Name_35"), 5, 10, 500, isHidden: false, new byte[2] { 5, 6 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_35")));
		_dataArray.Add(new LegacyPointItem(36, LocalStringManager.GetConfig("LegacyPoint_language", "Name_36"), 5, 100, 500, isHidden: false, new byte[2] { 5, 6 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_36")));
		_dataArray.Add(new LegacyPointItem(37, LocalStringManager.GetConfig("LegacyPoint_language", "Name_37"), 5, 100, 500, isHidden: false, new byte[4] { 5, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_37")));
		_dataArray.Add(new LegacyPointItem(38, LocalStringManager.GetConfig("LegacyPoint_language", "Name_38"), 5, 10, 500, isHidden: false, new byte[4] { 5, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_38")));
		_dataArray.Add(new LegacyPointItem(39, LocalStringManager.GetConfig("LegacyPoint_language", "Name_39"), 5, 20, 500, isHidden: false, new byte[4] { 5, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_39")));
		_dataArray.Add(new LegacyPointItem(40, LocalStringManager.GetConfig("LegacyPoint_language", "Name_40"), 6, 250, 2500, isHidden: false, new byte[7] { 1, 2, 3, 4, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_40")));
		_dataArray.Add(new LegacyPointItem(41, LocalStringManager.GetConfig("LegacyPoint_language", "Name_41"), 6, 2500, 7500, isHidden: false, new byte[7] { 1, 2, 3, 4, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_41")));
		_dataArray.Add(new LegacyPointItem(42, LocalStringManager.GetConfig("LegacyPoint_language", "Name_42"), 7, 50, 500, isHidden: false, new byte[11]
		{
			12, 1, 11, 2, 3, 4, 5, 6, 7, 13,
			14
		}, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_42")));
		_dataArray.Add(new LegacyPointItem(43, LocalStringManager.GetConfig("LegacyPoint_language", "Name_43"), 7, 50, 500, isHidden: false, new byte[11]
		{
			12, 1, 11, 2, 3, 4, 5, 6, 7, 13,
			14
		}, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_43")));
		_dataArray.Add(new LegacyPointItem(44, LocalStringManager.GetConfig("LegacyPoint_language", "Name_44"), 7, 100, 1000, isHidden: false, new byte[11]
		{
			12, 1, 11, 2, 3, 4, 5, 6, 7, 13,
			14
		}, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_44")));
		_dataArray.Add(new LegacyPointItem(45, LocalStringManager.GetConfig("LegacyPoint_language", "Name_45"), 7, 200, 2000, isHidden: false, new byte[11]
		{
			12, 1, 11, 2, 3, 4, 5, 6, 7, 13,
			14
		}, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_45")));
		_dataArray.Add(new LegacyPointItem(46, LocalStringManager.GetConfig("LegacyPoint_language", "Name_46"), -1, -1, -1, isHidden: true, new byte[10] { 12, 1, 11, 2, 3, 4, 5, 6, 7, 13 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_46")));
		_dataArray.Add(new LegacyPointItem(47, LocalStringManager.GetConfig("LegacyPoint_language", "Name_47"), 2, 5, 500, isHidden: false, new byte[5] { 2, 5, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_47")));
		_dataArray.Add(new LegacyPointItem(48, LocalStringManager.GetConfig("LegacyPoint_language", "Name_48"), 3, 5, 500, isHidden: false, new byte[5] { 2, 5, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_48")));
		_dataArray.Add(new LegacyPointItem(49, LocalStringManager.GetConfig("LegacyPoint_language", "Name_49"), 3, 20, 500, isHidden: false, new byte[6] { 2, 3, 5, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_49")));
		_dataArray.Add(new LegacyPointItem(50, LocalStringManager.GetConfig("LegacyPoint_language", "Name_50"), 4, 20, 500, isHidden: false, new byte[4] { 5, 6, 7, 14 }, LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_50")));
		_dataArray.Add(new LegacyPointItem(51, LocalStringManager.GetConfig("LegacyPoint_language", "Name_51"), 0, 10000, 10000, isHidden: true, new byte[0], LocalStringManager.GetConfig("LegacyPoint_language", "ConditionDesc_51")));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<LegacyPointItem>(52);
		CreateItems0();
	}
}
