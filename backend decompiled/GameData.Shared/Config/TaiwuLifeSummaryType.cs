using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class TaiwuLifeSummaryType : ConfigData<TaiwuLifeSummaryTypeItem, int>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 太吾结识人物数量
		/// </summary>
		public const int CreateRelationCount = 0;

		/// <summary>
		/// 太吾结交朋友数量
		/// </summary>
		public const int MakeFriendCount = 1;

		/// <summary>
		/// 太吾仇敌人物数量
		/// </summary>
		public const int MakeEnemyCount = 2;

		/// <summary>
		/// 太吾爱慕人物数量
		/// </summary>
		public const int StartAdoreCount = 3;

		/// <summary>
		/// 太吾拜认的义父母数量
		/// </summary>
		public const int BeAdoptedCount = 4;

		/// <summary>
		/// 太吾的结义人数
		/// </summary>
		public const int SworeBrotherhoodCount = 5;

		/// <summary>
		/// 太吾的夫妻数量
		/// </summary>
		public const int MarryCount = 6;

		/// <summary>
		/// 太吾的子女数量
		/// </summary>
		public const int GetChildrenCount = 7;

		/// <summary>
		/// 累计战斗场次
		/// </summary>
		public const int CombatTotalCount = 8;

		/// <summary>
		/// 恶斗胜利次数
		/// </summary>
		public const int CombatWinBeat = 9;

		/// <summary>
		/// 死斗胜利次数
		/// </summary>
		public const int CombatWinDie = 10;

		/// <summary>
		/// 接招胜利次数
		/// </summary>
		public const int CombatWinTest = 11;

		/// <summary>
		/// 救治失心人数量
		/// </summary>
		public const int SaveInfectedCharacter = 12;

		/// <summary>
		/// 治疗伤势累计
		/// </summary>
		public const int CombatHealInjuryTotal = 13;

		/// <summary>
		/// 驱除毒素累计
		/// </summary>
		public const int CombatHealPoisonTotal = 14;

		/// <summary>
		/// 造成外伤数值累计
		/// </summary>
		public const int CombatMakeOuterInjuryTotal = 15;

		/// <summary>
		/// 造成内伤数值累计
		/// </summary>
		public const int CombatMakeInnerInjuryTotal = 16;

		/// <summary>
		/// 造成重创数值累计
		/// </summary>
		public const int CombatMakeFatalTotal = 17;

		/// <summary>
		/// 造成心神激荡时长
		/// </summary>
		public const int CombatMakeMindUpheavalTime = 18;

		/// <summary>
		/// 造成失神数值累计
		/// </summary>
		public const int CombatMakeMindTotal = 19;

		/// <summary>
		/// 造成破绽累计
		/// </summary>
		public const int CombatMakeFlawTotal = 20;

		/// <summary>
		/// 造成封穴累计
		/// </summary>
		public const int CombatMakeAcupointTotal = 21;

		/// <summary>
		/// 造成各类毒素累计
		/// </summary>
		public const int CombatMakePoisonTotal = 22;

		/// <summary>
		/// 造成必死标记总和
		/// </summary>
		public const int CombatMakeDieMarkTotal = 23;

		/// <summary>
		/// 对敌人施加蛊虫数量
		/// </summary>
		public const int CombatMakeWugCount = 24;

		/// <summary>
		/// 承受外伤数值累计
		/// </summary>
		public const int CombatAcceptOuterInjuryTotal = 25;

		/// <summary>
		/// 承受内伤数值累计
		/// </summary>
		public const int CombatAcceptInnerInjuryTotal = 26;

		/// <summary>
		/// 承受重创数值累计
		/// </summary>
		public const int CombatAcceptFatalTotal = 27;

		/// <summary>
		/// 承受心神激荡时长
		/// </summary>
		public const int CombatAcceptMindUpheavalTime = 28;

		/// <summary>
		/// 承受失神数值累计
		/// </summary>
		public const int CombatAcceptMindTotal = 29;

		/// <summary>
		/// 承受破绽累计
		/// </summary>
		public const int CombatAcceptFlawTotal = 30;

		/// <summary>
		/// 承受封穴累计
		/// </summary>
		public const int CombatAcceptAcupointTotal = 31;

		/// <summary>
		/// 承受各类毒素累计
		/// </summary>
		public const int CombatAcceptPoisonTotal = 32;

		/// <summary>
		/// 承受必死标记总和
		/// </summary>
		public const int CombatAcceptDieMarkTotal = 33;

		/// <summary>
		/// 战斗中使用道具次数
		/// </summary>
		public const int CombatUseItemCount = 34;

		/// <summary>
		/// 使用化身剑柄碎片次数
		/// </summary>
		public const int CombatUseSwordFragmentCount = 35;

		/// <summary>
		/// 同道指令使用次数
		/// </summary>
		public const int CombatTeammateCommandUseCount = 36;

		/// <summary>
		/// 累计封禁敌人功法时长
		/// </summary>
		public const int CombatSilenceEnemySkillTime = 37;

		/// <summary>
		/// 累计被封禁功法时长
		/// </summary>
		public const int CombatBeSilenceSkillTime = 38;

		/// <summary>
		/// 较艺胜利次数
		/// </summary>
		public const int DebateWin = 39;

		/// <summary>
		/// 累计使用策略次数
		/// </summary>
		public const int DebateStrategyUsed = 40;

		/// <summary>
		/// 新习得技艺数量
		/// </summary>
		public const int LearnLifeSkillCount = 41;

		/// <summary>
		/// 解读技艺书页数量
		/// </summary>
		public const int ReadLifeSkillBookPageCount = 42;

		/// <summary>
		/// 解读技艺书残页数量
		/// </summary>
		public const int ReadIncompleteLifeSkillBookPageCount = 43;

		/// <summary>
		/// 研读技艺书籍次数
		/// </summary>
		public const int ReadLifeSkillBookCount = 44;

		/// <summary>
		/// 使用研读策略次数
		/// </summary>
		public const int UseReadingStrategyCount = 45;

		/// <summary>
		/// 新习得功法数量
		/// </summary>
		public const int LearnCombatSkillCount = 46;

		/// <summary>
		/// 解读武学书页数量
		/// </summary>
		public const int ReadCombatSkillBookPageCount = 47;

		/// <summary>
		/// 解读武学残页数量
		/// </summary>
		public const int ReadIncompleteCombatSkillBookPageCount = 48;

		/// <summary>
		/// 研读武学书籍次数
		/// </summary>
		public const int ReadCombatSkillBookCount = 49;

		/// <summary>
		/// 打通玄机次数
		/// </summary>
		public const int FillSkillBreakBonusCell = 50;

		/// <summary>
		/// 完成突破次数
		/// </summary>
		public const int CompleteSkillBreak = 51;

		/// <summary>
		/// 周天运转次数
		/// </summary>
		public const int ApplyNeigongLoopingEffectCount = 52;

		/// <summary>
		/// 使用周天策略次数
		/// </summary>
		public const int ApplyQiArtStrategyCount = 53;

		/// <summary>
		/// 太吾村建筑竣工数量
		/// </summary>
		public const int CompleteConstructionCount = 54;

		/// <summary>
		/// 太吾村升级资源点次数
		/// </summary>
		public const int UpgradeResourceBuildingCount = 55;

		/// <summary>
		/// 太吾村新增村民数量
		/// </summary>
		public const int NewTaiwuVillagerCount = 56;

		/// <summary>
		/// 轮回台渡人次数
		/// </summary>
		public const int SamsaraPlatformUsedCount = 57;

		/// <summary>
		/// 茶马帮带回西域珍宝数量
		/// </summary>
		public const int TeaHorseCaravanGotItemCount = 58;

		/// <summary>
		/// 宴堂招待人物次数
		/// </summary>
		public const int FeastCount = 59;

		/// <summary>
		/// 产业累计收获心材数量
		/// </summary>
		public const int BuildingBlockCollectBuildingCoreItemCount = 60;

		/// <summary>
		/// 产业建筑累计收获次数
		/// </summary>
		public const int BuildingBlockCollectEarningTotal = 61;

		/// <summary>
		/// 产业建筑累计收获银钱
		/// </summary>
		public const int BuildingBlockCollectMoney = 62;

		/// <summary>
		/// 产业建筑累计收获威望
		/// </summary>
		public const int BuildingBlockCollectAuthority = 63;

		/// <summary>
		/// 产业建筑累计招募人才
		/// </summary>
		public const int BuildingBlockCollectRecruit = 64;

		/// <summary>
		/// 产业建筑累计收获道具
		/// </summary>
		public const int BuildingBlockCollectItem = 65;

		/// <summary>
		/// 产业内制造次数
		/// </summary>
		public const int MakeItemCount = 66;

		/// <summary>
		/// 累计任命村民数量
		/// </summary>
		public const int AssignVillagerRoleCount = 67;

		/// <summary>
		/// 化魂仪式举办次数
		/// </summary>
		public const int SwapSoulCount = 68;

		/// <summary>
		/// 掌握初级志向技能数量
		/// </summary>
		public const int UnlockProfessionSkill0Count = 69;

		/// <summary>
		/// 掌握中级志向技能数量
		/// </summary>
		public const int UnlockProfessionSkill1Count = 70;

		/// <summary>
		/// 掌握高级志向技能数量
		/// </summary>
		public const int UnlockProfessionSkill2Count = 71;

		/// <summary>
		/// 捕捉蛐蛐数量
		/// </summary>
		public const int CatchCricketCount = 72;

		/// <summary>
		/// 捕捉到异品促织王的次数
		/// </summary>
		public const int CatchCricketKingCount = 73;

		/// <summary>
		/// 促织决斗胜利次数
		/// </summary>
		public const int CricketCombatWinCount = 74;

		/// <summary>
		/// 开通驿站数量
		/// </summary>
		public const int UnlockStationCount = 75;

		/// <summary>
		/// 首次拜访门派数量
		/// </summary>
		public const int VisitSectCount = 76;

		/// <summary>
		/// 取得门派支持次数
		/// </summary>
		public const int GetSectMemberSupportCount = 77;

		/// <summary>
		/// 完成奇遇数量
		/// </summary>
		public const int FinishAdventure = 78;

		/// <summary>
		/// 收养元鸡数量
		/// </summary>
		public const int TransferChickenCount = 79;

		/// <summary>
		/// 昌盛结局门派
		/// </summary>
		public const int GoodEndSectStory = 80;

		/// <summary>
		/// 衰落结局门派
		/// </summary>
		public const int BadEndSectStory = 81;

		/// <summary>
		/// 太吾赢得武林大会次数
		/// </summary>
		public const int TaiwuWinMartialArtTournament = 82;

		/// <summary>
		/// 太吾取得奇书次数
		/// </summary>
		public const int GainLegendaryBook = 83;

		/// <summary>
		/// 炼制王蛊数量
		/// </summary>
		public const int MakeWugKingAmount = 84;

		/// <summary>
		/// 击破莫女衣时间
		/// </summary>
		public const int DefeatMonvDate = 86;

		/// <summary>
		/// 解锁莫女化身时间
		/// </summary>
		public const int UnlockJuniorMonvDate = 95;

		/// <summary>
		/// 莫女衣绘卷结局
		/// </summary>
		public const int FinishJuniorMonvStoryDate = 104;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 太吾结识人物数量
		/// </summary>
		public static TaiwuLifeSummaryTypeItem CreateRelationCount => Instance[0];

		/// <summary>
		/// 太吾结交朋友数量
		/// </summary>
		public static TaiwuLifeSummaryTypeItem MakeFriendCount => Instance[1];

		/// <summary>
		/// 太吾仇敌人物数量
		/// </summary>
		public static TaiwuLifeSummaryTypeItem MakeEnemyCount => Instance[2];

		/// <summary>
		/// 太吾爱慕人物数量
		/// </summary>
		public static TaiwuLifeSummaryTypeItem StartAdoreCount => Instance[3];

		/// <summary>
		/// 太吾拜认的义父母数量
		/// </summary>
		public static TaiwuLifeSummaryTypeItem BeAdoptedCount => Instance[4];

		/// <summary>
		/// 太吾的结义人数
		/// </summary>
		public static TaiwuLifeSummaryTypeItem SworeBrotherhoodCount => Instance[5];

		/// <summary>
		/// 太吾的夫妻数量
		/// </summary>
		public static TaiwuLifeSummaryTypeItem MarryCount => Instance[6];

		/// <summary>
		/// 太吾的子女数量
		/// </summary>
		public static TaiwuLifeSummaryTypeItem GetChildrenCount => Instance[7];

		/// <summary>
		/// 累计战斗场次
		/// </summary>
		public static TaiwuLifeSummaryTypeItem CombatTotalCount => Instance[8];

		/// <summary>
		/// 恶斗胜利次数
		/// </summary>
		public static TaiwuLifeSummaryTypeItem CombatWinBeat => Instance[9];

		/// <summary>
		/// 死斗胜利次数
		/// </summary>
		public static TaiwuLifeSummaryTypeItem CombatWinDie => Instance[10];

		/// <summary>
		/// 接招胜利次数
		/// </summary>
		public static TaiwuLifeSummaryTypeItem CombatWinTest => Instance[11];

		/// <summary>
		/// 救治失心人数量
		/// </summary>
		public static TaiwuLifeSummaryTypeItem SaveInfectedCharacter => Instance[12];

		/// <summary>
		/// 治疗伤势累计
		/// </summary>
		public static TaiwuLifeSummaryTypeItem CombatHealInjuryTotal => Instance[13];

		/// <summary>
		/// 驱除毒素累计
		/// </summary>
		public static TaiwuLifeSummaryTypeItem CombatHealPoisonTotal => Instance[14];

		/// <summary>
		/// 造成外伤数值累计
		/// </summary>
		public static TaiwuLifeSummaryTypeItem CombatMakeOuterInjuryTotal => Instance[15];

		/// <summary>
		/// 造成内伤数值累计
		/// </summary>
		public static TaiwuLifeSummaryTypeItem CombatMakeInnerInjuryTotal => Instance[16];

		/// <summary>
		/// 造成重创数值累计
		/// </summary>
		public static TaiwuLifeSummaryTypeItem CombatMakeFatalTotal => Instance[17];

		/// <summary>
		/// 造成心神激荡时长
		/// </summary>
		public static TaiwuLifeSummaryTypeItem CombatMakeMindUpheavalTime => Instance[18];

		/// <summary>
		/// 造成失神数值累计
		/// </summary>
		public static TaiwuLifeSummaryTypeItem CombatMakeMindTotal => Instance[19];

		/// <summary>
		/// 造成破绽累计
		/// </summary>
		public static TaiwuLifeSummaryTypeItem CombatMakeFlawTotal => Instance[20];

		/// <summary>
		/// 造成封穴累计
		/// </summary>
		public static TaiwuLifeSummaryTypeItem CombatMakeAcupointTotal => Instance[21];

		/// <summary>
		/// 造成各类毒素累计
		/// </summary>
		public static TaiwuLifeSummaryTypeItem CombatMakePoisonTotal => Instance[22];

		/// <summary>
		/// 造成必死标记总和
		/// </summary>
		public static TaiwuLifeSummaryTypeItem CombatMakeDieMarkTotal => Instance[23];

		/// <summary>
		/// 对敌人施加蛊虫数量
		/// </summary>
		public static TaiwuLifeSummaryTypeItem CombatMakeWugCount => Instance[24];

		/// <summary>
		/// 承受外伤数值累计
		/// </summary>
		public static TaiwuLifeSummaryTypeItem CombatAcceptOuterInjuryTotal => Instance[25];

		/// <summary>
		/// 承受内伤数值累计
		/// </summary>
		public static TaiwuLifeSummaryTypeItem CombatAcceptInnerInjuryTotal => Instance[26];

		/// <summary>
		/// 承受重创数值累计
		/// </summary>
		public static TaiwuLifeSummaryTypeItem CombatAcceptFatalTotal => Instance[27];

		/// <summary>
		/// 承受心神激荡时长
		/// </summary>
		public static TaiwuLifeSummaryTypeItem CombatAcceptMindUpheavalTime => Instance[28];

		/// <summary>
		/// 承受失神数值累计
		/// </summary>
		public static TaiwuLifeSummaryTypeItem CombatAcceptMindTotal => Instance[29];

		/// <summary>
		/// 承受破绽累计
		/// </summary>
		public static TaiwuLifeSummaryTypeItem CombatAcceptFlawTotal => Instance[30];

		/// <summary>
		/// 承受封穴累计
		/// </summary>
		public static TaiwuLifeSummaryTypeItem CombatAcceptAcupointTotal => Instance[31];

		/// <summary>
		/// 承受各类毒素累计
		/// </summary>
		public static TaiwuLifeSummaryTypeItem CombatAcceptPoisonTotal => Instance[32];

		/// <summary>
		/// 承受必死标记总和
		/// </summary>
		public static TaiwuLifeSummaryTypeItem CombatAcceptDieMarkTotal => Instance[33];

		/// <summary>
		/// 战斗中使用道具次数
		/// </summary>
		public static TaiwuLifeSummaryTypeItem CombatUseItemCount => Instance[34];

		/// <summary>
		/// 使用化身剑柄碎片次数
		/// </summary>
		public static TaiwuLifeSummaryTypeItem CombatUseSwordFragmentCount => Instance[35];

		/// <summary>
		/// 同道指令使用次数
		/// </summary>
		public static TaiwuLifeSummaryTypeItem CombatTeammateCommandUseCount => Instance[36];

		/// <summary>
		/// 累计封禁敌人功法时长
		/// </summary>
		public static TaiwuLifeSummaryTypeItem CombatSilenceEnemySkillTime => Instance[37];

		/// <summary>
		/// 累计被封禁功法时长
		/// </summary>
		public static TaiwuLifeSummaryTypeItem CombatBeSilenceSkillTime => Instance[38];

		/// <summary>
		/// 较艺胜利次数
		/// </summary>
		public static TaiwuLifeSummaryTypeItem DebateWin => Instance[39];

		/// <summary>
		/// 累计使用策略次数
		/// </summary>
		public static TaiwuLifeSummaryTypeItem DebateStrategyUsed => Instance[40];

		/// <summary>
		/// 新习得技艺数量
		/// </summary>
		public static TaiwuLifeSummaryTypeItem LearnLifeSkillCount => Instance[41];

		/// <summary>
		/// 解读技艺书页数量
		/// </summary>
		public static TaiwuLifeSummaryTypeItem ReadLifeSkillBookPageCount => Instance[42];

		/// <summary>
		/// 解读技艺书残页数量
		/// </summary>
		public static TaiwuLifeSummaryTypeItem ReadIncompleteLifeSkillBookPageCount => Instance[43];

		/// <summary>
		/// 研读技艺书籍次数
		/// </summary>
		public static TaiwuLifeSummaryTypeItem ReadLifeSkillBookCount => Instance[44];

		/// <summary>
		/// 使用研读策略次数
		/// </summary>
		public static TaiwuLifeSummaryTypeItem UseReadingStrategyCount => Instance[45];

		/// <summary>
		/// 新习得功法数量
		/// </summary>
		public static TaiwuLifeSummaryTypeItem LearnCombatSkillCount => Instance[46];

		/// <summary>
		/// 解读武学书页数量
		/// </summary>
		public static TaiwuLifeSummaryTypeItem ReadCombatSkillBookPageCount => Instance[47];

		/// <summary>
		/// 解读武学残页数量
		/// </summary>
		public static TaiwuLifeSummaryTypeItem ReadIncompleteCombatSkillBookPageCount => Instance[48];

		/// <summary>
		/// 研读武学书籍次数
		/// </summary>
		public static TaiwuLifeSummaryTypeItem ReadCombatSkillBookCount => Instance[49];

		/// <summary>
		/// 打通玄机次数
		/// </summary>
		public static TaiwuLifeSummaryTypeItem FillSkillBreakBonusCell => Instance[50];

		/// <summary>
		/// 完成突破次数
		/// </summary>
		public static TaiwuLifeSummaryTypeItem CompleteSkillBreak => Instance[51];

		/// <summary>
		/// 周天运转次数
		/// </summary>
		public static TaiwuLifeSummaryTypeItem ApplyNeigongLoopingEffectCount => Instance[52];

		/// <summary>
		/// 使用周天策略次数
		/// </summary>
		public static TaiwuLifeSummaryTypeItem ApplyQiArtStrategyCount => Instance[53];

		/// <summary>
		/// 太吾村建筑竣工数量
		/// </summary>
		public static TaiwuLifeSummaryTypeItem CompleteConstructionCount => Instance[54];

		/// <summary>
		/// 太吾村升级资源点次数
		/// </summary>
		public static TaiwuLifeSummaryTypeItem UpgradeResourceBuildingCount => Instance[55];

		/// <summary>
		/// 太吾村新增村民数量
		/// </summary>
		public static TaiwuLifeSummaryTypeItem NewTaiwuVillagerCount => Instance[56];

		/// <summary>
		/// 轮回台渡人次数
		/// </summary>
		public static TaiwuLifeSummaryTypeItem SamsaraPlatformUsedCount => Instance[57];

		/// <summary>
		/// 茶马帮带回西域珍宝数量
		/// </summary>
		public static TaiwuLifeSummaryTypeItem TeaHorseCaravanGotItemCount => Instance[58];

		/// <summary>
		/// 宴堂招待人物次数
		/// </summary>
		public static TaiwuLifeSummaryTypeItem FeastCount => Instance[59];

		/// <summary>
		/// 产业累计收获心材数量
		/// </summary>
		public static TaiwuLifeSummaryTypeItem BuildingBlockCollectBuildingCoreItemCount => Instance[60];

		/// <summary>
		/// 产业建筑累计收获次数
		/// </summary>
		public static TaiwuLifeSummaryTypeItem BuildingBlockCollectEarningTotal => Instance[61];

		/// <summary>
		/// 产业建筑累计收获银钱
		/// </summary>
		public static TaiwuLifeSummaryTypeItem BuildingBlockCollectMoney => Instance[62];

		/// <summary>
		/// 产业建筑累计收获威望
		/// </summary>
		public static TaiwuLifeSummaryTypeItem BuildingBlockCollectAuthority => Instance[63];

		/// <summary>
		/// 产业建筑累计招募人才
		/// </summary>
		public static TaiwuLifeSummaryTypeItem BuildingBlockCollectRecruit => Instance[64];

		/// <summary>
		/// 产业建筑累计收获道具
		/// </summary>
		public static TaiwuLifeSummaryTypeItem BuildingBlockCollectItem => Instance[65];

		/// <summary>
		/// 产业内制造次数
		/// </summary>
		public static TaiwuLifeSummaryTypeItem MakeItemCount => Instance[66];

		/// <summary>
		/// 累计任命村民数量
		/// </summary>
		public static TaiwuLifeSummaryTypeItem AssignVillagerRoleCount => Instance[67];

		/// <summary>
		/// 化魂仪式举办次数
		/// </summary>
		public static TaiwuLifeSummaryTypeItem SwapSoulCount => Instance[68];

		/// <summary>
		/// 掌握初级志向技能数量
		/// </summary>
		public static TaiwuLifeSummaryTypeItem UnlockProfessionSkill0Count => Instance[69];

		/// <summary>
		/// 掌握中级志向技能数量
		/// </summary>
		public static TaiwuLifeSummaryTypeItem UnlockProfessionSkill1Count => Instance[70];

		/// <summary>
		/// 掌握高级志向技能数量
		/// </summary>
		public static TaiwuLifeSummaryTypeItem UnlockProfessionSkill2Count => Instance[71];

		/// <summary>
		/// 捕捉蛐蛐数量
		/// </summary>
		public static TaiwuLifeSummaryTypeItem CatchCricketCount => Instance[72];

		/// <summary>
		/// 捕捉到异品促织王的次数
		/// </summary>
		public static TaiwuLifeSummaryTypeItem CatchCricketKingCount => Instance[73];

		/// <summary>
		/// 促织决斗胜利次数
		/// </summary>
		public static TaiwuLifeSummaryTypeItem CricketCombatWinCount => Instance[74];

		/// <summary>
		/// 开通驿站数量
		/// </summary>
		public static TaiwuLifeSummaryTypeItem UnlockStationCount => Instance[75];

		/// <summary>
		/// 首次拜访门派数量
		/// </summary>
		public static TaiwuLifeSummaryTypeItem VisitSectCount => Instance[76];

		/// <summary>
		/// 取得门派支持次数
		/// </summary>
		public static TaiwuLifeSummaryTypeItem GetSectMemberSupportCount => Instance[77];

		/// <summary>
		/// 完成奇遇数量
		/// </summary>
		public static TaiwuLifeSummaryTypeItem FinishAdventure => Instance[78];

		/// <summary>
		/// 收养元鸡数量
		/// </summary>
		public static TaiwuLifeSummaryTypeItem TransferChickenCount => Instance[79];

		/// <summary>
		/// 昌盛结局门派
		/// </summary>
		public static TaiwuLifeSummaryTypeItem GoodEndSectStory => Instance[80];

		/// <summary>
		/// 衰落结局门派
		/// </summary>
		public static TaiwuLifeSummaryTypeItem BadEndSectStory => Instance[81];

		/// <summary>
		/// 太吾赢得武林大会次数
		/// </summary>
		public static TaiwuLifeSummaryTypeItem TaiwuWinMartialArtTournament => Instance[82];

		/// <summary>
		/// 太吾取得奇书次数
		/// </summary>
		public static TaiwuLifeSummaryTypeItem GainLegendaryBook => Instance[83];

		/// <summary>
		/// 炼制王蛊数量
		/// </summary>
		public static TaiwuLifeSummaryTypeItem MakeWugKingAmount => Instance[84];

		/// <summary>
		/// 击破莫女衣时间
		/// </summary>
		public static TaiwuLifeSummaryTypeItem DefeatMonvDate => Instance[86];

		/// <summary>
		/// 解锁莫女化身时间
		/// </summary>
		public static TaiwuLifeSummaryTypeItem UnlockJuniorMonvDate => Instance[95];

		/// <summary>
		/// 莫女衣绘卷结局
		/// </summary>
		public static TaiwuLifeSummaryTypeItem FinishJuniorMonvStoryDate => Instance[104];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static TaiwuLifeSummaryType Instance = new TaiwuLifeSummaryType();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "Type", "TemplateId" };

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
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(0, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_0"), 0, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(1, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_1"), 0, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(2, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_2"), 0, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(3, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_3"), 0, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(4, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_4"), 0, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(5, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_5"), 0, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(6, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_6"), 0, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(7, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_7"), 0, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(8, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_8"), 1, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(9, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_9"), 1, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(10, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_10"), 1, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(11, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_11"), 1, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(12, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_12"), 1, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(13, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_13"), 1, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(14, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_14"), 1, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(15, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_15"), 1, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(16, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_16"), 1, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(17, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_17"), 1, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(18, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_18"), 1, displayInScrollOfTaiwu: false, isDate: false, isTime: true));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(19, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_19"), 1, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(20, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_20"), 1, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(21, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_21"), 1, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(22, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_22"), 1, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(23, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_23"), 1, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(24, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_24"), 1, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(25, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_25"), 1, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(26, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_26"), 1, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(27, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_27"), 1, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(28, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_28"), 1, displayInScrollOfTaiwu: false, isDate: false, isTime: true));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(29, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_29"), 1, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(30, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_30"), 1, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(31, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_31"), 1, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(32, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_32"), 1, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(33, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_33"), 1, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(34, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_34"), 1, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(35, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_35"), 1, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(36, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_36"), 1, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(37, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_37"), 1, displayInScrollOfTaiwu: false, isDate: false, isTime: true));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(38, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_38"), 1, displayInScrollOfTaiwu: false, isDate: false, isTime: true));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(39, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_39"), 2, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(40, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_40"), 2, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(41, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_41"), 2, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(42, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_42"), 2, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(43, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_43"), 2, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(44, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_44"), 2, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(45, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_45"), 2, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(46, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_46"), 3, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(47, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_47"), 3, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(48, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_48"), 3, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(49, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_49"), 3, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(50, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_50"), 3, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(51, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_51"), 3, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(52, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_52"), 3, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(53, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_53"), 3, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(54, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_54"), 4, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(55, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_55"), 4, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(56, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_56"), 4, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(57, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_57"), 4, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(58, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_58"), 4, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(59, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_59"), 4, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(60, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_60"), 4, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(61, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_61"), 4, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(62, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_62"), 4, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(63, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_63"), 4, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(64, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_64"), 4, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(65, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_65"), 4, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(66, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_66"), 4, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(67, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_67"), 4, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(68, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_68"), 4, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(69, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_69"), 7, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(70, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_70"), 7, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(71, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_71"), 7, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(72, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_72"), 5, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(73, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_73"), 5, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(74, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_74"), 5, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(75, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_75"), 5, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(76, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_76"), 5, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(77, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_77"), 5, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(78, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_78"), 5, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(79, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_79"), 5, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(80, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_80"), 5, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(81, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_81"), 5, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(82, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_82"), 5, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(83, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_83"), 5, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(84, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_84"), 5, displayInScrollOfTaiwu: false, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(85, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_85"), 6, displayInScrollOfTaiwu: true, isDate: false, isTime: false));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(86, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_86"), 6, displayInScrollOfTaiwu: true, isDate: true, isTime: true));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(87, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_87"), 6, displayInScrollOfTaiwu: true, isDate: true, isTime: true));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(88, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_88"), 6, displayInScrollOfTaiwu: true, isDate: true, isTime: true));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(89, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_89"), 6, displayInScrollOfTaiwu: true, isDate: true, isTime: true));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(90, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_90"), 6, displayInScrollOfTaiwu: true, isDate: true, isTime: true));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(91, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_91"), 6, displayInScrollOfTaiwu: true, isDate: true, isTime: true));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(92, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_92"), 6, displayInScrollOfTaiwu: true, isDate: true, isTime: true));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(93, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_93"), 6, displayInScrollOfTaiwu: true, isDate: true, isTime: true));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(94, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_94"), 6, displayInScrollOfTaiwu: true, isDate: true, isTime: true));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(95, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_95"), 6, displayInScrollOfTaiwu: false, isDate: true, isTime: true));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(96, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_96"), 6, displayInScrollOfTaiwu: false, isDate: true, isTime: true));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(97, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_97"), 6, displayInScrollOfTaiwu: false, isDate: true, isTime: true));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(98, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_98"), 6, displayInScrollOfTaiwu: false, isDate: true, isTime: true));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(99, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_99"), 6, displayInScrollOfTaiwu: false, isDate: true, isTime: true));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(100, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_100"), 6, displayInScrollOfTaiwu: false, isDate: true, isTime: true));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(101, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_101"), 6, displayInScrollOfTaiwu: false, isDate: true, isTime: true));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(102, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_102"), 6, displayInScrollOfTaiwu: false, isDate: true, isTime: true));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(103, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_103"), 6, displayInScrollOfTaiwu: false, isDate: true, isTime: true));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(104, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_104"), 6, displayInScrollOfTaiwu: false, isDate: true, isTime: true));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(105, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_105"), 6, displayInScrollOfTaiwu: false, isDate: true, isTime: true));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(106, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_106"), 6, displayInScrollOfTaiwu: false, isDate: true, isTime: true));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(107, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_107"), 6, displayInScrollOfTaiwu: false, isDate: true, isTime: true));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(108, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_108"), 6, displayInScrollOfTaiwu: false, isDate: true, isTime: true));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(109, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_109"), 6, displayInScrollOfTaiwu: false, isDate: true, isTime: true));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(110, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_110"), 6, displayInScrollOfTaiwu: false, isDate: true, isTime: true));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(111, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_111"), 6, displayInScrollOfTaiwu: false, isDate: true, isTime: true));
		_dataArray.Add(new TaiwuLifeSummaryTypeItem(112, LocalStringManager.GetConfig("TaiwuLifeSummaryType_language", "Name_112"), 6, displayInScrollOfTaiwu: false, isDate: true, isTime: true));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<TaiwuLifeSummaryTypeItem>(113);
		CreateItems0();
		CreateItems1();
	}
}
