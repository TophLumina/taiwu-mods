using System;
using System.Collections.Generic;
using Config.Common;
using Config.ConfigCells.Character;

namespace Config;

[Serializable]
public class MonthlyActions : ConfigData<MonthlyActionsItem, short>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 奇遇-京城招亲-前置准备
		/// </summary>
		public const short ContestForBrideJingcheng = 0;

		/// <summary>
		/// 奇遇-成都招亲-前置准备
		/// </summary>
		public const short ContestForBrideChengdu = 1;

		/// <summary>
		/// 奇遇-桂州招亲-前置准备
		/// </summary>
		public const short ContestForBrideGuizhou = 2;

		/// <summary>
		/// 奇遇-襄阳招亲-前置准备
		/// </summary>
		public const short ContestForBrideXiangyang = 3;

		/// <summary>
		/// 奇遇-太原招亲-前置准备
		/// </summary>
		public const short ContestForBrideTaiyuan = 4;

		/// <summary>
		/// 奇遇-广州招亲-前置准备
		/// </summary>
		public const short ContestForBrideGuangzhou = 5;

		/// <summary>
		/// 奇遇-青州招亲-前置准备
		/// </summary>
		public const short ContestForBrideQingzhou = 6;

		/// <summary>
		/// 奇遇-江陵招亲-前置准备
		/// </summary>
		public const short ContestForBrideJiangling = 7;

		/// <summary>
		/// 奇遇-福州招亲-前置准备
		/// </summary>
		public const short ContestForBrideFuzhou = 8;

		/// <summary>
		/// 奇遇-辽阳招亲-前置准备
		/// </summary>
		public const short ContestForBrideLiaoyang = 9;

		/// <summary>
		/// 奇遇-秦州招亲-前置准备
		/// </summary>
		public const short ContestForBrideQinzhou = 10;

		/// <summary>
		/// 奇遇-大理招亲-前置准备
		/// </summary>
		public const short ContestForBrideDali = 11;

		/// <summary>
		/// 奇遇-寿春招亲-前置准备
		/// </summary>
		public const short ContestForBrideShouchun = 12;

		/// <summary>
		/// 奇遇-杭州招亲-前置准备
		/// </summary>
		public const short ContestForBrideHangzhou = 13;

		/// <summary>
		/// 奇遇-扬州招亲-前置准备
		/// </summary>
		public const short ContestForBrideYangzhou = 14;

		/// <summary>
		/// 奇遇-修罗场-前置准备
		/// </summary>
		public const short EnemyNestXiuluochangPrepare = 23;

		/// <summary>
		/// 奇遇-群魔乱舞-前置准备
		/// </summary>
		public const short EnemyNestFlurryofDemonsPrepare = 24;

		/// <summary>
		/// 奇遇-弃世绝境-前置准备
		/// </summary>
		public const short EnemyNestDeadEndPrepare = 25;

		/// <summary>
		/// 奇遇-邪人死地-前置准备
		/// </summary>
		public const short EnemyNestEvilGroundPrepare = 26;

		/// <summary>
		/// 奇遇-武林大会-前置准备
		/// </summary>
		public const short MartialArtTournamentPrepare = 30;

		/// <summary>
		/// 奇遇-京城招亲女-前置准备
		/// </summary>
		public const short BrideOpenContestJingcheng = 31;

		/// <summary>
		/// 奇遇-成都招亲女-前置准备
		/// </summary>
		public const short BrideOpenContestChengdu = 32;

		/// <summary>
		/// 奇遇-桂州招亲女-前置准备
		/// </summary>
		public const short BrideOpenContestGuizhou = 33;

		/// <summary>
		/// 奇遇-襄阳招亲女-前置准备
		/// </summary>
		public const short BrideOpenContestXiangyang = 34;

		/// <summary>
		/// 奇遇-太原招亲女-前置准备
		/// </summary>
		public const short BrideOpenContestTaiyuan = 35;

		/// <summary>
		/// 奇遇-广州招亲女-前置准备
		/// </summary>
		public const short BrideOpenContestGuangzhou = 36;

		/// <summary>
		/// 奇遇-青州招亲女-前置准备
		/// </summary>
		public const short BrideOpenContestQingzhou = 37;

		/// <summary>
		/// 奇遇-江陵招亲女-前置准备
		/// </summary>
		public const short BrideOpenContestJiangling = 38;

		/// <summary>
		/// 奇遇-福州招亲女-前置准备
		/// </summary>
		public const short BrideOpenContestFuzhou = 39;

		/// <summary>
		/// 奇遇-辽阳招亲女-前置准备
		/// </summary>
		public const short BrideOpenContestLiaoyang = 40;

		/// <summary>
		/// 奇遇-秦州招亲女-前置准备
		/// </summary>
		public const short BrideOpenContestQinzhou = 41;

		/// <summary>
		/// 奇遇-大理招亲女-前置准备
		/// </summary>
		public const short BrideOpenContestDali = 42;

		/// <summary>
		/// 奇遇-寿春招亲女-前置准备
		/// </summary>
		public const short BrideOpenContestShouchun = 43;

		/// <summary>
		/// 奇遇-杭州招亲女-前置准备
		/// </summary>
		public const short BrideOpenContestHangzhou = 44;

		/// <summary>
		/// 奇遇-扬州招亲女-前置准备
		/// </summary>
		public const short BrideOpenContestYangzhou = 45;

		/// <summary>
		/// 奇遇-门派较武少林-前置准备
		/// </summary>
		public const short SectNormalCompetitionShaolin = 46;

		/// <summary>
		/// 奇遇-门派较武峨眉-前置准备
		/// </summary>
		public const short SectNormalCompetitionEmei = 47;

		/// <summary>
		/// 奇遇-门派较武百花-前置准备
		/// </summary>
		public const short SectNormalCompetitionBaihua = 48;

		/// <summary>
		/// 奇遇-门派较武武当-前置准备
		/// </summary>
		public const short SectNormalCompetitionWudang = 49;

		/// <summary>
		/// 奇遇-门派较武元山-前置准备
		/// </summary>
		public const short SectNormalCompetitionYuanshan = 50;

		/// <summary>
		/// 奇遇-门派较武狮相-前置准备
		/// </summary>
		public const short SectNormalCompetitionShixiang = 51;

		/// <summary>
		/// 奇遇-门派较武然山-前置准备
		/// </summary>
		public const short SectNormalCompetitionRanshan = 52;

		/// <summary>
		/// 奇遇-门派较武璇女-前置准备
		/// </summary>
		public const short SectNormalCompetitionXuannv = 53;

		/// <summary>
		/// 奇遇-门派较武铸剑-前置准备
		/// </summary>
		public const short SectNormalCompetitionZhujian = 54;

		/// <summary>
		/// 奇遇-门派较武空桑-前置准备
		/// </summary>
		public const short SectNormalCompetitionKongsang = 55;

		/// <summary>
		/// 奇遇-门派较武金刚-前置准备
		/// </summary>
		public const short SectNormalCompetitionJingang = 56;

		/// <summary>
		/// 奇遇-门派较武五仙-前置准备
		/// </summary>
		public const short SectNormalCompetitionWuxian = 57;

		/// <summary>
		/// 奇遇-门派较武界青-前置准备
		/// </summary>
		public const short SectNormalCompetitionJieqing = 58;

		/// <summary>
		/// 奇遇-门派较武伏龙-前置准备
		/// </summary>
		public const short SectNormalCompetitionFulong = 59;

		/// <summary>
		/// 奇遇-门派较武血犼-前置准备
		/// </summary>
		public const short SectNormalCompetitionXuehou = 60;

		/// <summary>
		/// 奇遇-春日集市-前置准备
		/// </summary>
		public const short SpringMarketPrepare = 61;

		/// <summary>
		/// 奇遇-比武大会·拳掌-前置准备
		/// </summary>
		public const short CityCombatSkillCompetitionFistAndPalm = 62;

		/// <summary>
		/// 奇遇-比武大会·指法-前置准备
		/// </summary>
		public const short CityCombatSkillCompetitionFinger = 63;

		/// <summary>
		/// 奇遇-比武大会·腿法-前置准备
		/// </summary>
		public const short CityCombatSkillCompetitionLeg = 64;

		/// <summary>
		/// 奇遇-比武大会·暗器-前置准备
		/// </summary>
		public const short CityCombatSkillCompetitionThrow = 65;

		/// <summary>
		/// 奇遇-比武大会·剑法-前置准备
		/// </summary>
		public const short CityCombatSkillCompetitionSword = 66;

		/// <summary>
		/// 奇遇-比武大会·刀法-前置准备
		/// </summary>
		public const short CityCombatSkillCompetitionBlade = 67;

		/// <summary>
		/// 奇遇-比武大会·长兵-前置准备
		/// </summary>
		public const short CityCombatSkillCompetitionPolearm = 68;

		/// <summary>
		/// 奇遇-比武大会·奇门-前置准备
		/// </summary>
		public const short CityCombatSkillCompetitionSpecial = 69;

		/// <summary>
		/// 奇遇-比武大会·软兵-前置准备
		/// </summary>
		public const short CityCombatSkillCompetitionWhip = 70;

		/// <summary>
		/// 奇遇-比武大会·御射-前置准备
		/// </summary>
		public const short CityCombatSkillCompetitionControllableShot = 71;

		/// <summary>
		/// 奇遇-比武大会·乐器-前置准备
		/// </summary>
		public const short CityCombatSkillCompetitionCombatMusic = 72;

		/// <summary>
		/// 奇遇-促织大会-前置准备
		/// </summary>
		public const short CricketConference = 73;

		/// <summary>
		/// 奇遇-较艺大会·锻造-前置准备
		/// </summary>
		public const short CityLifeSkillCompetitionForging = 74;

		/// <summary>
		/// 奇遇-较艺大会·制木-前置准备
		/// </summary>
		public const short CityLifeSkillCompetitionWoodworking = 75;

		/// <summary>
		/// 奇遇-较艺大会·织锦-前置准备
		/// </summary>
		public const short CityLifeSkillCompetitionWeaving = 76;

		/// <summary>
		/// 奇遇-较艺大会·巧匠-前置准备
		/// </summary>
		public const short CityLifeSkillCompetitionJade = 77;

		/// <summary>
		/// 奇遇-较艺大会·医术-前置准备
		/// </summary>
		public const short CityLifeSkillCompetitionMedicine = 78;

		/// <summary>
		/// 奇遇-较艺大会·毒术-前置准备
		/// </summary>
		public const short CityLifeSkillCompetitionToxicology = 79;

		/// <summary>
		/// 奇遇-较艺大会·厨艺-前置准备
		/// </summary>
		public const short CityLifeSkillCompetitionCooking = 80;

		/// <summary>
		/// 奇遇-何为正宗-前置准备
		/// </summary>
		public const short SectMainStoryEmeiTwo = 81;

		/// <summary>
		/// 奇遇-三宗比武-前置准备
		/// </summary>
		public const short SectMainStoryRanshan = 82;

		/// <summary>
		/// 奇遇-试剑大典-前置准备
		/// </summary>
		public const short SectMainStoryZhujian = 83;

		/// <summary>
		/// 奇遇-三才绝魔大阵-前置准备
		/// </summary>
		public const short SectMainStoryYuanshan = 84;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 奇遇-京城招亲-前置准备
		/// </summary>
		public static MonthlyActionsItem ContestForBrideJingcheng => Instance[(short)0];

		/// <summary>
		/// 奇遇-成都招亲-前置准备
		/// </summary>
		public static MonthlyActionsItem ContestForBrideChengdu => Instance[(short)1];

		/// <summary>
		/// 奇遇-桂州招亲-前置准备
		/// </summary>
		public static MonthlyActionsItem ContestForBrideGuizhou => Instance[(short)2];

		/// <summary>
		/// 奇遇-襄阳招亲-前置准备
		/// </summary>
		public static MonthlyActionsItem ContestForBrideXiangyang => Instance[(short)3];

		/// <summary>
		/// 奇遇-太原招亲-前置准备
		/// </summary>
		public static MonthlyActionsItem ContestForBrideTaiyuan => Instance[(short)4];

		/// <summary>
		/// 奇遇-广州招亲-前置准备
		/// </summary>
		public static MonthlyActionsItem ContestForBrideGuangzhou => Instance[(short)5];

		/// <summary>
		/// 奇遇-青州招亲-前置准备
		/// </summary>
		public static MonthlyActionsItem ContestForBrideQingzhou => Instance[(short)6];

		/// <summary>
		/// 奇遇-江陵招亲-前置准备
		/// </summary>
		public static MonthlyActionsItem ContestForBrideJiangling => Instance[(short)7];

		/// <summary>
		/// 奇遇-福州招亲-前置准备
		/// </summary>
		public static MonthlyActionsItem ContestForBrideFuzhou => Instance[(short)8];

		/// <summary>
		/// 奇遇-辽阳招亲-前置准备
		/// </summary>
		public static MonthlyActionsItem ContestForBrideLiaoyang => Instance[(short)9];

		/// <summary>
		/// 奇遇-秦州招亲-前置准备
		/// </summary>
		public static MonthlyActionsItem ContestForBrideQinzhou => Instance[(short)10];

		/// <summary>
		/// 奇遇-大理招亲-前置准备
		/// </summary>
		public static MonthlyActionsItem ContestForBrideDali => Instance[(short)11];

		/// <summary>
		/// 奇遇-寿春招亲-前置准备
		/// </summary>
		public static MonthlyActionsItem ContestForBrideShouchun => Instance[(short)12];

		/// <summary>
		/// 奇遇-杭州招亲-前置准备
		/// </summary>
		public static MonthlyActionsItem ContestForBrideHangzhou => Instance[(short)13];

		/// <summary>
		/// 奇遇-扬州招亲-前置准备
		/// </summary>
		public static MonthlyActionsItem ContestForBrideYangzhou => Instance[(short)14];

		/// <summary>
		/// 奇遇-修罗场-前置准备
		/// </summary>
		public static MonthlyActionsItem EnemyNestXiuluochangPrepare => Instance[(short)23];

		/// <summary>
		/// 奇遇-群魔乱舞-前置准备
		/// </summary>
		public static MonthlyActionsItem EnemyNestFlurryofDemonsPrepare => Instance[(short)24];

		/// <summary>
		/// 奇遇-弃世绝境-前置准备
		/// </summary>
		public static MonthlyActionsItem EnemyNestDeadEndPrepare => Instance[(short)25];

		/// <summary>
		/// 奇遇-邪人死地-前置准备
		/// </summary>
		public static MonthlyActionsItem EnemyNestEvilGroundPrepare => Instance[(short)26];

		/// <summary>
		/// 奇遇-武林大会-前置准备
		/// </summary>
		public static MonthlyActionsItem MartialArtTournamentPrepare => Instance[(short)30];

		/// <summary>
		/// 奇遇-京城招亲女-前置准备
		/// </summary>
		public static MonthlyActionsItem BrideOpenContestJingcheng => Instance[(short)31];

		/// <summary>
		/// 奇遇-成都招亲女-前置准备
		/// </summary>
		public static MonthlyActionsItem BrideOpenContestChengdu => Instance[(short)32];

		/// <summary>
		/// 奇遇-桂州招亲女-前置准备
		/// </summary>
		public static MonthlyActionsItem BrideOpenContestGuizhou => Instance[(short)33];

		/// <summary>
		/// 奇遇-襄阳招亲女-前置准备
		/// </summary>
		public static MonthlyActionsItem BrideOpenContestXiangyang => Instance[(short)34];

		/// <summary>
		/// 奇遇-太原招亲女-前置准备
		/// </summary>
		public static MonthlyActionsItem BrideOpenContestTaiyuan => Instance[(short)35];

		/// <summary>
		/// 奇遇-广州招亲女-前置准备
		/// </summary>
		public static MonthlyActionsItem BrideOpenContestGuangzhou => Instance[(short)36];

		/// <summary>
		/// 奇遇-青州招亲女-前置准备
		/// </summary>
		public static MonthlyActionsItem BrideOpenContestQingzhou => Instance[(short)37];

		/// <summary>
		/// 奇遇-江陵招亲女-前置准备
		/// </summary>
		public static MonthlyActionsItem BrideOpenContestJiangling => Instance[(short)38];

		/// <summary>
		/// 奇遇-福州招亲女-前置准备
		/// </summary>
		public static MonthlyActionsItem BrideOpenContestFuzhou => Instance[(short)39];

		/// <summary>
		/// 奇遇-辽阳招亲女-前置准备
		/// </summary>
		public static MonthlyActionsItem BrideOpenContestLiaoyang => Instance[(short)40];

		/// <summary>
		/// 奇遇-秦州招亲女-前置准备
		/// </summary>
		public static MonthlyActionsItem BrideOpenContestQinzhou => Instance[(short)41];

		/// <summary>
		/// 奇遇-大理招亲女-前置准备
		/// </summary>
		public static MonthlyActionsItem BrideOpenContestDali => Instance[(short)42];

		/// <summary>
		/// 奇遇-寿春招亲女-前置准备
		/// </summary>
		public static MonthlyActionsItem BrideOpenContestShouchun => Instance[(short)43];

		/// <summary>
		/// 奇遇-杭州招亲女-前置准备
		/// </summary>
		public static MonthlyActionsItem BrideOpenContestHangzhou => Instance[(short)44];

		/// <summary>
		/// 奇遇-扬州招亲女-前置准备
		/// </summary>
		public static MonthlyActionsItem BrideOpenContestYangzhou => Instance[(short)45];

		/// <summary>
		/// 奇遇-门派较武少林-前置准备
		/// </summary>
		public static MonthlyActionsItem SectNormalCompetitionShaolin => Instance[(short)46];

		/// <summary>
		/// 奇遇-门派较武峨眉-前置准备
		/// </summary>
		public static MonthlyActionsItem SectNormalCompetitionEmei => Instance[(short)47];

		/// <summary>
		/// 奇遇-门派较武百花-前置准备
		/// </summary>
		public static MonthlyActionsItem SectNormalCompetitionBaihua => Instance[(short)48];

		/// <summary>
		/// 奇遇-门派较武武当-前置准备
		/// </summary>
		public static MonthlyActionsItem SectNormalCompetitionWudang => Instance[(short)49];

		/// <summary>
		/// 奇遇-门派较武元山-前置准备
		/// </summary>
		public static MonthlyActionsItem SectNormalCompetitionYuanshan => Instance[(short)50];

		/// <summary>
		/// 奇遇-门派较武狮相-前置准备
		/// </summary>
		public static MonthlyActionsItem SectNormalCompetitionShixiang => Instance[(short)51];

		/// <summary>
		/// 奇遇-门派较武然山-前置准备
		/// </summary>
		public static MonthlyActionsItem SectNormalCompetitionRanshan => Instance[(short)52];

		/// <summary>
		/// 奇遇-门派较武璇女-前置准备
		/// </summary>
		public static MonthlyActionsItem SectNormalCompetitionXuannv => Instance[(short)53];

		/// <summary>
		/// 奇遇-门派较武铸剑-前置准备
		/// </summary>
		public static MonthlyActionsItem SectNormalCompetitionZhujian => Instance[(short)54];

		/// <summary>
		/// 奇遇-门派较武空桑-前置准备
		/// </summary>
		public static MonthlyActionsItem SectNormalCompetitionKongsang => Instance[(short)55];

		/// <summary>
		/// 奇遇-门派较武金刚-前置准备
		/// </summary>
		public static MonthlyActionsItem SectNormalCompetitionJingang => Instance[(short)56];

		/// <summary>
		/// 奇遇-门派较武五仙-前置准备
		/// </summary>
		public static MonthlyActionsItem SectNormalCompetitionWuxian => Instance[(short)57];

		/// <summary>
		/// 奇遇-门派较武界青-前置准备
		/// </summary>
		public static MonthlyActionsItem SectNormalCompetitionJieqing => Instance[(short)58];

		/// <summary>
		/// 奇遇-门派较武伏龙-前置准备
		/// </summary>
		public static MonthlyActionsItem SectNormalCompetitionFulong => Instance[(short)59];

		/// <summary>
		/// 奇遇-门派较武血犼-前置准备
		/// </summary>
		public static MonthlyActionsItem SectNormalCompetitionXuehou => Instance[(short)60];

		/// <summary>
		/// 奇遇-春日集市-前置准备
		/// </summary>
		public static MonthlyActionsItem SpringMarketPrepare => Instance[(short)61];

		/// <summary>
		/// 奇遇-比武大会·拳掌-前置准备
		/// </summary>
		public static MonthlyActionsItem CityCombatSkillCompetitionFistAndPalm => Instance[(short)62];

		/// <summary>
		/// 奇遇-比武大会·指法-前置准备
		/// </summary>
		public static MonthlyActionsItem CityCombatSkillCompetitionFinger => Instance[(short)63];

		/// <summary>
		/// 奇遇-比武大会·腿法-前置准备
		/// </summary>
		public static MonthlyActionsItem CityCombatSkillCompetitionLeg => Instance[(short)64];

		/// <summary>
		/// 奇遇-比武大会·暗器-前置准备
		/// </summary>
		public static MonthlyActionsItem CityCombatSkillCompetitionThrow => Instance[(short)65];

		/// <summary>
		/// 奇遇-比武大会·剑法-前置准备
		/// </summary>
		public static MonthlyActionsItem CityCombatSkillCompetitionSword => Instance[(short)66];

		/// <summary>
		/// 奇遇-比武大会·刀法-前置准备
		/// </summary>
		public static MonthlyActionsItem CityCombatSkillCompetitionBlade => Instance[(short)67];

		/// <summary>
		/// 奇遇-比武大会·长兵-前置准备
		/// </summary>
		public static MonthlyActionsItem CityCombatSkillCompetitionPolearm => Instance[(short)68];

		/// <summary>
		/// 奇遇-比武大会·奇门-前置准备
		/// </summary>
		public static MonthlyActionsItem CityCombatSkillCompetitionSpecial => Instance[(short)69];

		/// <summary>
		/// 奇遇-比武大会·软兵-前置准备
		/// </summary>
		public static MonthlyActionsItem CityCombatSkillCompetitionWhip => Instance[(short)70];

		/// <summary>
		/// 奇遇-比武大会·御射-前置准备
		/// </summary>
		public static MonthlyActionsItem CityCombatSkillCompetitionControllableShot => Instance[(short)71];

		/// <summary>
		/// 奇遇-比武大会·乐器-前置准备
		/// </summary>
		public static MonthlyActionsItem CityCombatSkillCompetitionCombatMusic => Instance[(short)72];

		/// <summary>
		/// 奇遇-促织大会-前置准备
		/// </summary>
		public static MonthlyActionsItem CricketConference => Instance[(short)73];

		/// <summary>
		/// 奇遇-较艺大会·锻造-前置准备
		/// </summary>
		public static MonthlyActionsItem CityLifeSkillCompetitionForging => Instance[(short)74];

		/// <summary>
		/// 奇遇-较艺大会·制木-前置准备
		/// </summary>
		public static MonthlyActionsItem CityLifeSkillCompetitionWoodworking => Instance[(short)75];

		/// <summary>
		/// 奇遇-较艺大会·织锦-前置准备
		/// </summary>
		public static MonthlyActionsItem CityLifeSkillCompetitionWeaving => Instance[(short)76];

		/// <summary>
		/// 奇遇-较艺大会·巧匠-前置准备
		/// </summary>
		public static MonthlyActionsItem CityLifeSkillCompetitionJade => Instance[(short)77];

		/// <summary>
		/// 奇遇-较艺大会·医术-前置准备
		/// </summary>
		public static MonthlyActionsItem CityLifeSkillCompetitionMedicine => Instance[(short)78];

		/// <summary>
		/// 奇遇-较艺大会·毒术-前置准备
		/// </summary>
		public static MonthlyActionsItem CityLifeSkillCompetitionToxicology => Instance[(short)79];

		/// <summary>
		/// 奇遇-较艺大会·厨艺-前置准备
		/// </summary>
		public static MonthlyActionsItem CityLifeSkillCompetitionCooking => Instance[(short)80];

		/// <summary>
		/// 奇遇-何为正宗-前置准备
		/// </summary>
		public static MonthlyActionsItem SectMainStoryEmeiTwo => Instance[(short)81];

		/// <summary>
		/// 奇遇-三宗比武-前置准备
		/// </summary>
		public static MonthlyActionsItem SectMainStoryRanshan => Instance[(short)82];

		/// <summary>
		/// 奇遇-试剑大典-前置准备
		/// </summary>
		public static MonthlyActionsItem SectMainStoryZhujian => Instance[(short)83];

		/// <summary>
		/// 奇遇-三才绝魔大阵-前置准备
		/// </summary>
		public static MonthlyActionsItem SectMainStoryYuanshan => Instance[(short)84];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static MonthlyActions Instance = new MonthlyActions();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "EnterMonthList", "MapState", "MapArea", "MajorTargetFilterList", "ParticipateTargetFilterList", "AdventureId", "NotificationId", "TemplateId" };

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
		_dataArray.Add(new MonthlyActionsItem(0, LocalStringManager.GetConfig("MonthlyActions_language", "Name_0"), new List<sbyte> { 8 }, -1, -1, new List<short> { 1 }, 1, majorTargetMoveVisible: false, new CharacterFilterRequirement[1]
		{
			new CharacterFilterRequirement(new int[2] { 3, 4 }, 1)
		}, new CharacterFilterRequirement[1]
		{
			new CharacterFilterRequirement(new int[1] { 5 }, 8)
		}, 101, 139, isEnemyNest: false, allowTemporaryMajorCharacter: true, allowTemporaryParticipateCharacter: false, willConvertTemporaryMajorCharacters: true, willConvertTemporaryParticipateCharacters: false, canActionBeforehand: true, 6, 2, 36, 0));
		_dataArray.Add(new MonthlyActionsItem(1, LocalStringManager.GetConfig("MonthlyActions_language", "Name_1"), new List<sbyte> { 4 }, -1, -1, new List<short> { 2 }, 1, majorTargetMoveVisible: false, new CharacterFilterRequirement[1]
		{
			new CharacterFilterRequirement(new int[2] { 3, 4 }, 1)
		}, new CharacterFilterRequirement[1]
		{
			new CharacterFilterRequirement(new int[1] { 5 }, 8)
		}, 94, 139, isEnemyNest: false, allowTemporaryMajorCharacter: true, allowTemporaryParticipateCharacter: false, willConvertTemporaryMajorCharacters: true, willConvertTemporaryParticipateCharacters: false, canActionBeforehand: true, 6, 2, 36, 0));
		_dataArray.Add(new MonthlyActionsItem(2, LocalStringManager.GetConfig("MonthlyActions_language", "Name_2"), new List<sbyte> { 11 }, -1, -1, new List<short> { 3 }, 1, majorTargetMoveVisible: false, new CharacterFilterRequirement[1]
		{
			new CharacterFilterRequirement(new int[2] { 3, 4 }, 1)
		}, new CharacterFilterRequirement[1]
		{
			new CharacterFilterRequirement(new int[1] { 5 }, 8)
		}, 98, 139, isEnemyNest: false, allowTemporaryMajorCharacter: true, allowTemporaryParticipateCharacter: false, willConvertTemporaryMajorCharacters: true, willConvertTemporaryParticipateCharacters: false, canActionBeforehand: true, 6, 2, 36, 0));
		_dataArray.Add(new MonthlyActionsItem(3, LocalStringManager.GetConfig("MonthlyActions_language", "Name_3"), new List<sbyte> { 6 }, -1, -1, new List<short> { 4 }, 1, majorTargetMoveVisible: false, new CharacterFilterRequirement[1]
		{
			new CharacterFilterRequirement(new int[2] { 3, 4 }, 1)
		}, new CharacterFilterRequirement[1]
		{
			new CharacterFilterRequirement(new int[1] { 5 }, 8)
		}, 107, 139, isEnemyNest: false, allowTemporaryMajorCharacter: true, allowTemporaryParticipateCharacter: false, willConvertTemporaryMajorCharacters: true, willConvertTemporaryParticipateCharacters: false, canActionBeforehand: true, 6, 2, 36, 0));
		_dataArray.Add(new MonthlyActionsItem(4, LocalStringManager.GetConfig("MonthlyActions_language", "Name_4"), new List<sbyte> { 9 }, -1, -1, new List<short> { 5 }, 1, majorTargetMoveVisible: false, new CharacterFilterRequirement[1]
		{
			new CharacterFilterRequirement(new int[2] { 3, 4 }, 1)
		}, new CharacterFilterRequirement[1]
		{
			new CharacterFilterRequirement(new int[1] { 5 }, 8)
		}, 106, 139, isEnemyNest: false, allowTemporaryMajorCharacter: true, allowTemporaryParticipateCharacter: false, willConvertTemporaryMajorCharacters: true, willConvertTemporaryParticipateCharacters: false, canActionBeforehand: true, 6, 2, 36, 0));
		_dataArray.Add(new MonthlyActionsItem(5, LocalStringManager.GetConfig("MonthlyActions_language", "Name_5"), new List<sbyte> { 10 }, -1, -1, new List<short> { 6 }, 1, majorTargetMoveVisible: false, new CharacterFilterRequirement[1]
		{
			new CharacterFilterRequirement(new int[2] { 3, 4 }, 1)
		}, new CharacterFilterRequirement[1]
		{
			new CharacterFilterRequirement(new int[1] { 5 }, 8)
		}, 97, 139, isEnemyNest: false, allowTemporaryMajorCharacter: true, allowTemporaryParticipateCharacter: false, willConvertTemporaryMajorCharacters: true, willConvertTemporaryParticipateCharacters: false, canActionBeforehand: true, 6, 2, 36, 0));
		_dataArray.Add(new MonthlyActionsItem(6, LocalStringManager.GetConfig("MonthlyActions_language", "Name_6"), new List<sbyte> { 5 }, -1, -1, new List<short> { 7 }, 1, majorTargetMoveVisible: false, new CharacterFilterRequirement[1]
		{
			new CharacterFilterRequirement(new int[2] { 3, 4 }, 1)
		}, new CharacterFilterRequirement[1]
		{
			new CharacterFilterRequirement(new int[1] { 5 }, 8)
		}, 104, 139, isEnemyNest: false, allowTemporaryMajorCharacter: true, allowTemporaryParticipateCharacter: false, willConvertTemporaryMajorCharacters: true, willConvertTemporaryParticipateCharacters: false, canActionBeforehand: true, 6, 2, 36, 0));
		_dataArray.Add(new MonthlyActionsItem(7, LocalStringManager.GetConfig("MonthlyActions_language", "Name_7"), new List<sbyte> { 1 }, -1, -1, new List<short> { 8 }, 1, majorTargetMoveVisible: false, new CharacterFilterRequirement[1]
		{
			new CharacterFilterRequirement(new int[2] { 3, 4 }, 1)
		}, new CharacterFilterRequirement[1]
		{
			new CharacterFilterRequirement(new int[1] { 5 }, 8)
		}, 100, 139, isEnemyNest: false, allowTemporaryMajorCharacter: true, allowTemporaryParticipateCharacter: false, willConvertTemporaryMajorCharacters: true, willConvertTemporaryParticipateCharacters: false, canActionBeforehand: true, 6, 2, 36, 0));
		_dataArray.Add(new MonthlyActionsItem(8, LocalStringManager.GetConfig("MonthlyActions_language", "Name_8"), new List<sbyte> { 5 }, -1, -1, new List<short> { 9 }, 1, majorTargetMoveVisible: false, new CharacterFilterRequirement[1]
		{
			new CharacterFilterRequirement(new int[2] { 3, 4 }, 1)
		}, new CharacterFilterRequirement[1]
		{
			new CharacterFilterRequirement(new int[1] { 5 }, 8)
		}, 96, 139, isEnemyNest: false, allowTemporaryMajorCharacter: true, allowTemporaryParticipateCharacter: false, willConvertTemporaryMajorCharacters: true, willConvertTemporaryParticipateCharacters: false, canActionBeforehand: true, 6, 2, 36, 0));
		_dataArray.Add(new MonthlyActionsItem(9, LocalStringManager.GetConfig("MonthlyActions_language", "Name_9"), new List<sbyte> { 2 }, -1, -1, new List<short> { 10 }, 1, majorTargetMoveVisible: false, new CharacterFilterRequirement[1]
		{
			new CharacterFilterRequirement(new int[2] { 3, 4 }, 1)
		}, new CharacterFilterRequirement[1]
		{
			new CharacterFilterRequirement(new int[1] { 5 }, 8)
		}, 102, 139, isEnemyNest: false, allowTemporaryMajorCharacter: true, allowTemporaryParticipateCharacter: false, willConvertTemporaryMajorCharacters: true, willConvertTemporaryParticipateCharacters: false, canActionBeforehand: true, 6, 2, 36, 0));
		_dataArray.Add(new MonthlyActionsItem(10, LocalStringManager.GetConfig("MonthlyActions_language", "Name_10"), new List<sbyte> { 1 }, -1, -1, new List<short> { 11 }, 1, majorTargetMoveVisible: false, new CharacterFilterRequirement[1]
		{
			new CharacterFilterRequirement(new int[2] { 3, 4 }, 1)
		}, new CharacterFilterRequirement[1]
		{
			new CharacterFilterRequirement(new int[1] { 5 }, 8)
		}, 103, 139, isEnemyNest: false, allowTemporaryMajorCharacter: true, allowTemporaryParticipateCharacter: false, willConvertTemporaryMajorCharacters: true, willConvertTemporaryParticipateCharacters: false, canActionBeforehand: true, 6, 2, 36, 0));
		_dataArray.Add(new MonthlyActionsItem(11, LocalStringManager.GetConfig("MonthlyActions_language", "Name_11"), new List<sbyte> { 7 }, -1, -1, new List<short> { 12 }, 1, majorTargetMoveVisible: false, new CharacterFilterRequirement[2]
		{
			new CharacterFilterRequirement(new int[2] { 3, 4 }, 1),
			new CharacterFilterRequirement(new int[1] { 8 }, 3, 10)
		}, new CharacterFilterRequirement[2]
		{
			new CharacterFilterRequirement(new int[1] { 5 }, 5),
			new CharacterFilterRequirement(new int[1] { 9 }, 3, 10)
		}, 95, 139, isEnemyNest: false, allowTemporaryMajorCharacter: true, allowTemporaryParticipateCharacter: false, willConvertTemporaryMajorCharacters: true, willConvertTemporaryParticipateCharacters: false, canActionBeforehand: true, 6, 2, 36, 0));
		_dataArray.Add(new MonthlyActionsItem(12, LocalStringManager.GetConfig("MonthlyActions_language", "Name_12"), new List<sbyte> { 3 }, -1, -1, new List<short> { 13 }, 1, majorTargetMoveVisible: false, new CharacterFilterRequirement[1]
		{
			new CharacterFilterRequirement(new int[2] { 3, 4 }, 1)
		}, new CharacterFilterRequirement[1]
		{
			new CharacterFilterRequirement(new int[1] { 5 }, 8)
		}, 105, 139, isEnemyNest: false, allowTemporaryMajorCharacter: true, allowTemporaryParticipateCharacter: false, willConvertTemporaryMajorCharacters: true, willConvertTemporaryParticipateCharacters: false, canActionBeforehand: true, 6, 2, 36, 0));
		_dataArray.Add(new MonthlyActionsItem(13, LocalStringManager.GetConfig("MonthlyActions_language", "Name_13"), new List<sbyte> { 11 }, -1, -1, new List<short> { 14 }, 1, majorTargetMoveVisible: false, new CharacterFilterRequirement[1]
		{
			new CharacterFilterRequirement(new int[2] { 3, 4 }, 1)
		}, new CharacterFilterRequirement[1]
		{
			new CharacterFilterRequirement(new int[1] { 5 }, 8)
		}, 99, 139, isEnemyNest: false, allowTemporaryMajorCharacter: true, allowTemporaryParticipateCharacter: false, willConvertTemporaryMajorCharacters: true, willConvertTemporaryParticipateCharacters: false, canActionBeforehand: true, 6, 2, 36, 0));
		_dataArray.Add(new MonthlyActionsItem(14, LocalStringManager.GetConfig("MonthlyActions_language", "Name_14"), new List<sbyte> { 0 }, -1, -1, new List<short> { 15 }, 1, majorTargetMoveVisible: false, new CharacterFilterRequirement[2]
		{
			new CharacterFilterRequirement(new int[2] { 3, 4 }, 1),
			new CharacterFilterRequirement(new int[1] { 10 }, 5, 7)
		}, new CharacterFilterRequirement[1]
		{
			new CharacterFilterRequirement(new int[1] { 5 }, 8)
		}, 108, 139, isEnemyNest: false, allowTemporaryMajorCharacter: true, allowTemporaryParticipateCharacter: false, willConvertTemporaryMajorCharacters: true, willConvertTemporaryParticipateCharacters: false, canActionBeforehand: true, 6, 2, 36, 0));
		_dataArray.Add(new MonthlyActionsItem(15, LocalStringManager.GetConfig("MonthlyActions_language", "Name_15"), new List<sbyte>(), -1, -1, new List<short>(), 0, majorTargetMoveVisible: false, new CharacterFilterRequirement[0], new CharacterFilterRequirement[0], 58, 119, isEnemyNest: true, allowTemporaryMajorCharacter: false, allowTemporaryParticipateCharacter: false, willConvertTemporaryMajorCharacters: false, willConvertTemporaryParticipateCharacters: false, canActionBeforehand: true, 0, 0, 0, 0));
		_dataArray.Add(new MonthlyActionsItem(16, LocalStringManager.GetConfig("MonthlyActions_language", "Name_16"), new List<sbyte>(), -1, -1, new List<short>(), 0, majorTargetMoveVisible: false, new CharacterFilterRequirement[0], new CharacterFilterRequirement[0], 59, 120, isEnemyNest: true, allowTemporaryMajorCharacter: false, allowTemporaryParticipateCharacter: false, willConvertTemporaryMajorCharacters: false, willConvertTemporaryParticipateCharacters: false, canActionBeforehand: true, 0, 0, 0, 0));
		_dataArray.Add(new MonthlyActionsItem(17, LocalStringManager.GetConfig("MonthlyActions_language", "Name_17"), new List<sbyte>(), -1, -1, new List<short>(), 0, majorTargetMoveVisible: false, new CharacterFilterRequirement[0], new CharacterFilterRequirement[0], 62, 123, isEnemyNest: true, allowTemporaryMajorCharacter: false, allowTemporaryParticipateCharacter: false, willConvertTemporaryMajorCharacters: false, willConvertTemporaryParticipateCharacters: false, canActionBeforehand: true, 0, 0, 0, 0));
		_dataArray.Add(new MonthlyActionsItem(18, LocalStringManager.GetConfig("MonthlyActions_language", "Name_18"), new List<sbyte>(), -1, -1, new List<short>(), 0, majorTargetMoveVisible: false, new CharacterFilterRequirement[0], new CharacterFilterRequirement[0], 60, 121, isEnemyNest: true, allowTemporaryMajorCharacter: false, allowTemporaryParticipateCharacter: false, willConvertTemporaryMajorCharacters: false, willConvertTemporaryParticipateCharacters: false, canActionBeforehand: true, 0, 0, 0, 0));
		_dataArray.Add(new MonthlyActionsItem(19, LocalStringManager.GetConfig("MonthlyActions_language", "Name_19"), new List<sbyte>(), -1, -1, new List<short>(), 0, majorTargetMoveVisible: false, new CharacterFilterRequirement[0], new CharacterFilterRequirement[0], 61, 122, isEnemyNest: true, allowTemporaryMajorCharacter: false, allowTemporaryParticipateCharacter: false, willConvertTemporaryMajorCharacters: false, willConvertTemporaryParticipateCharacters: false, canActionBeforehand: true, 0, 0, 0, 0));
		_dataArray.Add(new MonthlyActionsItem(20, LocalStringManager.GetConfig("MonthlyActions_language", "Name_20"), new List<sbyte>(), -1, -1, new List<short>(), 0, majorTargetMoveVisible: false, new CharacterFilterRequirement[0], new CharacterFilterRequirement[0], 63, 124, isEnemyNest: true, allowTemporaryMajorCharacter: false, allowTemporaryParticipateCharacter: false, willConvertTemporaryMajorCharacters: false, willConvertTemporaryParticipateCharacters: false, canActionBeforehand: true, 0, 0, 0, 0));
		_dataArray.Add(new MonthlyActionsItem(21, LocalStringManager.GetConfig("MonthlyActions_language", "Name_21"), new List<sbyte>(), -1, -1, new List<short>(), 0, majorTargetMoveVisible: false, new CharacterFilterRequirement[0], new CharacterFilterRequirement[0], 65, 126, isEnemyNest: true, allowTemporaryMajorCharacter: false, allowTemporaryParticipateCharacter: false, willConvertTemporaryMajorCharacters: false, willConvertTemporaryParticipateCharacters: false, canActionBeforehand: true, 0, 0, 0, 0));
		_dataArray.Add(new MonthlyActionsItem(22, LocalStringManager.GetConfig("MonthlyActions_language", "Name_22"), new List<sbyte>(), -1, -1, new List<short>(), 0, majorTargetMoveVisible: false, new CharacterFilterRequirement[0], new CharacterFilterRequirement[0], 64, 125, isEnemyNest: true, allowTemporaryMajorCharacter: false, allowTemporaryParticipateCharacter: false, willConvertTemporaryMajorCharacters: false, willConvertTemporaryParticipateCharacters: false, canActionBeforehand: true, 0, 0, 0, 0));
		_dataArray.Add(new MonthlyActionsItem(23, LocalStringManager.GetConfig("MonthlyActions_language", "Name_23"), new List<sbyte>(), -1, -1, new List<short>(), 1, majorTargetMoveVisible: false, new CharacterFilterRequirement[1]
		{
			new CharacterFilterRequirement(new int[2] { 11, 89 }, 1)
		}, new CharacterFilterRequirement[0], 67, 128, isEnemyNest: true, allowTemporaryMajorCharacter: false, allowTemporaryParticipateCharacter: false, willConvertTemporaryMajorCharacters: false, willConvertTemporaryParticipateCharacters: false, canActionBeforehand: true, 2, 0, 0, 0));
		_dataArray.Add(new MonthlyActionsItem(24, LocalStringManager.GetConfig("MonthlyActions_language", "Name_24"), new List<sbyte>(), -1, -1, new List<short>(), 0, majorTargetMoveVisible: false, new CharacterFilterRequirement[1]
		{
			new CharacterFilterRequirement(new int[1] { 7 }, 3, 5)
		}, new CharacterFilterRequirement[0], 68, 129, isEnemyNest: true, allowTemporaryMajorCharacter: false, allowTemporaryParticipateCharacter: false, willConvertTemporaryMajorCharacters: false, willConvertTemporaryParticipateCharacters: false, canActionBeforehand: true, 2, 0, 0, 0));
		_dataArray.Add(new MonthlyActionsItem(25, LocalStringManager.GetConfig("MonthlyActions_language", "Name_25"), new List<sbyte>(), -1, -1, new List<short>(), 1, majorTargetMoveVisible: false, new CharacterFilterRequirement[1]
		{
			new CharacterFilterRequirement(new int[1] { 12 }, 1)
		}, new CharacterFilterRequirement[0], 69, 130, isEnemyNest: true, allowTemporaryMajorCharacter: false, allowTemporaryParticipateCharacter: false, willConvertTemporaryMajorCharacters: false, willConvertTemporaryParticipateCharacters: false, canActionBeforehand: true, 2, 0, 0, 0));
		_dataArray.Add(new MonthlyActionsItem(26, LocalStringManager.GetConfig("MonthlyActions_language", "Name_26"), new List<sbyte>(), -1, -1, new List<short>(), 1, majorTargetMoveVisible: false, new CharacterFilterRequirement[1]
		{
			new CharacterFilterRequirement(new int[2] { 1, 88 }, 1)
		}, new CharacterFilterRequirement[1]
		{
			new CharacterFilterRequirement(new int[1] { 2 }, 0, 3)
		}, 66, 127, isEnemyNest: true, allowTemporaryMajorCharacter: false, allowTemporaryParticipateCharacter: true, willConvertTemporaryMajorCharacters: false, willConvertTemporaryParticipateCharacters: false, canActionBeforehand: true, 2, 0, 0, 0));
		_dataArray.Add(new MonthlyActionsItem(27, LocalStringManager.GetConfig("MonthlyActions_language", "Name_27"), new List<sbyte>(), -1, -1, new List<short>(), 0, majorTargetMoveVisible: false, new CharacterFilterRequirement[0], new CharacterFilterRequirement[0], 70, -1, isEnemyNest: true, allowTemporaryMajorCharacter: false, allowTemporaryParticipateCharacter: false, willConvertTemporaryMajorCharacters: false, willConvertTemporaryParticipateCharacters: false, canActionBeforehand: true, 0, 0, 0, 0));
		_dataArray.Add(new MonthlyActionsItem(28, LocalStringManager.GetConfig("MonthlyActions_language", "Name_28"), new List<sbyte>(), -1, -1, new List<short>(), 0, majorTargetMoveVisible: false, new CharacterFilterRequirement[0], new CharacterFilterRequirement[0], 71, -1, isEnemyNest: true, allowTemporaryMajorCharacter: false, allowTemporaryParticipateCharacter: false, willConvertTemporaryMajorCharacters: false, willConvertTemporaryParticipateCharacters: false, canActionBeforehand: true, 0, 0, 0, 0));
		_dataArray.Add(new MonthlyActionsItem(29, LocalStringManager.GetConfig("MonthlyActions_language", "Name_29"), new List<sbyte>(), -1, -1, new List<short>(), 0, majorTargetMoveVisible: false, new CharacterFilterRequirement[0], new CharacterFilterRequirement[0], 72, -1, isEnemyNest: true, allowTemporaryMajorCharacter: false, allowTemporaryParticipateCharacter: false, willConvertTemporaryMajorCharacters: false, willConvertTemporaryParticipateCharacters: false, canActionBeforehand: true, 0, 0, 0, 0));
		_dataArray.Add(new MonthlyActionsItem(30, LocalStringManager.GetConfig("MonthlyActions_language", "Name_30"), new List<sbyte>(), -1, -1, new List<short>(), 2, majorTargetMoveVisible: false, new CharacterFilterRequirement[0], new CharacterFilterRequirement[2]
		{
			new CharacterFilterRequirement(new int[1] { 15 }, 30, 45),
			new CharacterFilterRequirement(new int[1] { 16 }, 15, 15)
		}, 9, -1, isEnemyNest: false, allowTemporaryMajorCharacter: false, allowTemporaryParticipateCharacter: false, willConvertTemporaryMajorCharacters: false, willConvertTemporaryParticipateCharacters: true, canActionBeforehand: true, 0, 0, 0, 0));
		_dataArray.Add(new MonthlyActionsItem(31, LocalStringManager.GetConfig("MonthlyActions_language", "Name_31"), new List<sbyte>(), -1, -1, new List<short> { 1 }, 1, majorTargetMoveVisible: false, new CharacterFilterRequirement[0], new CharacterFilterRequirement[1]
		{
			new CharacterFilterRequirement(new int[1] { 17 }, 8)
		}, 116, 182, isEnemyNest: false, allowTemporaryMajorCharacter: false, allowTemporaryParticipateCharacter: true, willConvertTemporaryMajorCharacters: false, willConvertTemporaryParticipateCharacters: true, canActionBeforehand: true, 6, 2, 0, 0));
		_dataArray.Add(new MonthlyActionsItem(32, LocalStringManager.GetConfig("MonthlyActions_language", "Name_32"), new List<sbyte>(), -1, -1, new List<short> { 2 }, 1, majorTargetMoveVisible: false, new CharacterFilterRequirement[0], new CharacterFilterRequirement[1]
		{
			new CharacterFilterRequirement(new int[1] { 17 }, 8)
		}, 109, 182, isEnemyNest: false, allowTemporaryMajorCharacter: false, allowTemporaryParticipateCharacter: true, willConvertTemporaryMajorCharacters: false, willConvertTemporaryParticipateCharacters: true, canActionBeforehand: true, 6, 2, 0, 0));
		_dataArray.Add(new MonthlyActionsItem(33, LocalStringManager.GetConfig("MonthlyActions_language", "Name_33"), new List<sbyte>(), -1, -1, new List<short> { 3 }, 1, majorTargetMoveVisible: false, new CharacterFilterRequirement[0], new CharacterFilterRequirement[1]
		{
			new CharacterFilterRequirement(new int[1] { 17 }, 8)
		}, 113, 182, isEnemyNest: false, allowTemporaryMajorCharacter: false, allowTemporaryParticipateCharacter: true, willConvertTemporaryMajorCharacters: false, willConvertTemporaryParticipateCharacters: true, canActionBeforehand: true, 6, 2, 0, 0));
		_dataArray.Add(new MonthlyActionsItem(34, LocalStringManager.GetConfig("MonthlyActions_language", "Name_34"), new List<sbyte>(), -1, -1, new List<short> { 4 }, 1, majorTargetMoveVisible: false, new CharacterFilterRequirement[0], new CharacterFilterRequirement[1]
		{
			new CharacterFilterRequirement(new int[1] { 17 }, 8)
		}, 122, 182, isEnemyNest: false, allowTemporaryMajorCharacter: false, allowTemporaryParticipateCharacter: true, willConvertTemporaryMajorCharacters: false, willConvertTemporaryParticipateCharacters: true, canActionBeforehand: true, 6, 2, 0, 0));
		_dataArray.Add(new MonthlyActionsItem(35, LocalStringManager.GetConfig("MonthlyActions_language", "Name_35"), new List<sbyte>(), -1, -1, new List<short> { 5 }, 1, majorTargetMoveVisible: false, new CharacterFilterRequirement[0], new CharacterFilterRequirement[1]
		{
			new CharacterFilterRequirement(new int[1] { 17 }, 8)
		}, 121, 182, isEnemyNest: false, allowTemporaryMajorCharacter: false, allowTemporaryParticipateCharacter: true, willConvertTemporaryMajorCharacters: false, willConvertTemporaryParticipateCharacters: true, canActionBeforehand: true, 6, 2, 0, 0));
		_dataArray.Add(new MonthlyActionsItem(36, LocalStringManager.GetConfig("MonthlyActions_language", "Name_36"), new List<sbyte>(), -1, -1, new List<short> { 6 }, 1, majorTargetMoveVisible: false, new CharacterFilterRequirement[0], new CharacterFilterRequirement[1]
		{
			new CharacterFilterRequirement(new int[1] { 17 }, 8)
		}, 112, 182, isEnemyNest: false, allowTemporaryMajorCharacter: false, allowTemporaryParticipateCharacter: true, willConvertTemporaryMajorCharacters: false, willConvertTemporaryParticipateCharacters: true, canActionBeforehand: true, 6, 2, 0, 0));
		_dataArray.Add(new MonthlyActionsItem(37, LocalStringManager.GetConfig("MonthlyActions_language", "Name_37"), new List<sbyte>(), -1, -1, new List<short> { 7 }, 1, majorTargetMoveVisible: false, new CharacterFilterRequirement[0], new CharacterFilterRequirement[1]
		{
			new CharacterFilterRequirement(new int[1] { 17 }, 8)
		}, 119, 182, isEnemyNest: false, allowTemporaryMajorCharacter: false, allowTemporaryParticipateCharacter: true, willConvertTemporaryMajorCharacters: false, willConvertTemporaryParticipateCharacters: true, canActionBeforehand: true, 6, 2, 0, 0));
		_dataArray.Add(new MonthlyActionsItem(38, LocalStringManager.GetConfig("MonthlyActions_language", "Name_38"), new List<sbyte>(), -1, -1, new List<short> { 8 }, 1, majorTargetMoveVisible: false, new CharacterFilterRequirement[0], new CharacterFilterRequirement[1]
		{
			new CharacterFilterRequirement(new int[1] { 17 }, 8)
		}, 115, 182, isEnemyNest: false, allowTemporaryMajorCharacter: false, allowTemporaryParticipateCharacter: true, willConvertTemporaryMajorCharacters: false, willConvertTemporaryParticipateCharacters: true, canActionBeforehand: true, 6, 2, 0, 0));
		_dataArray.Add(new MonthlyActionsItem(39, LocalStringManager.GetConfig("MonthlyActions_language", "Name_39"), new List<sbyte>(), -1, -1, new List<short> { 9 }, 1, majorTargetMoveVisible: false, new CharacterFilterRequirement[0], new CharacterFilterRequirement[1]
		{
			new CharacterFilterRequirement(new int[1] { 17 }, 8)
		}, 111, 182, isEnemyNest: false, allowTemporaryMajorCharacter: false, allowTemporaryParticipateCharacter: true, willConvertTemporaryMajorCharacters: false, willConvertTemporaryParticipateCharacters: true, canActionBeforehand: true, 6, 2, 0, 0));
		_dataArray.Add(new MonthlyActionsItem(40, LocalStringManager.GetConfig("MonthlyActions_language", "Name_40"), new List<sbyte>(), -1, -1, new List<short> { 10 }, 1, majorTargetMoveVisible: false, new CharacterFilterRequirement[0], new CharacterFilterRequirement[1]
		{
			new CharacterFilterRequirement(new int[1] { 17 }, 8)
		}, 117, 182, isEnemyNest: false, allowTemporaryMajorCharacter: false, allowTemporaryParticipateCharacter: true, willConvertTemporaryMajorCharacters: false, willConvertTemporaryParticipateCharacters: true, canActionBeforehand: true, 6, 2, 0, 0));
		_dataArray.Add(new MonthlyActionsItem(41, LocalStringManager.GetConfig("MonthlyActions_language", "Name_41"), new List<sbyte>(), -1, -1, new List<short> { 11 }, 1, majorTargetMoveVisible: false, new CharacterFilterRequirement[0], new CharacterFilterRequirement[1]
		{
			new CharacterFilterRequirement(new int[1] { 17 }, 8)
		}, 118, 182, isEnemyNest: false, allowTemporaryMajorCharacter: false, allowTemporaryParticipateCharacter: true, willConvertTemporaryMajorCharacters: false, willConvertTemporaryParticipateCharacters: true, canActionBeforehand: true, 6, 2, 0, 0));
		_dataArray.Add(new MonthlyActionsItem(42, LocalStringManager.GetConfig("MonthlyActions_language", "Name_42"), new List<sbyte>(), -1, -1, new List<short> { 12 }, 1, majorTargetMoveVisible: false, new CharacterFilterRequirement[1]
		{
			new CharacterFilterRequirement(new int[1] { 8 }, 3, 10)
		}, new CharacterFilterRequirement[1]
		{
			new CharacterFilterRequirement(new int[1] { 17 }, 8)
		}, 110, 182, isEnemyNest: false, allowTemporaryMajorCharacter: true, allowTemporaryParticipateCharacter: true, willConvertTemporaryMajorCharacters: false, willConvertTemporaryParticipateCharacters: true, canActionBeforehand: true, 6, 2, 0, 0));
		_dataArray.Add(new MonthlyActionsItem(43, LocalStringManager.GetConfig("MonthlyActions_language", "Name_43"), new List<sbyte>(), -1, -1, new List<short> { 13 }, 1, majorTargetMoveVisible: false, new CharacterFilterRequirement[0], new CharacterFilterRequirement[1]
		{
			new CharacterFilterRequirement(new int[1] { 17 }, 8)
		}, 120, 182, isEnemyNest: false, allowTemporaryMajorCharacter: false, allowTemporaryParticipateCharacter: true, willConvertTemporaryMajorCharacters: false, willConvertTemporaryParticipateCharacters: true, canActionBeforehand: true, 6, 2, 0, 0));
		_dataArray.Add(new MonthlyActionsItem(44, LocalStringManager.GetConfig("MonthlyActions_language", "Name_44"), new List<sbyte>(), -1, -1, new List<short> { 14 }, 1, majorTargetMoveVisible: false, new CharacterFilterRequirement[0], new CharacterFilterRequirement[1]
		{
			new CharacterFilterRequirement(new int[1] { 17 }, 8)
		}, 114, 182, isEnemyNest: false, allowTemporaryMajorCharacter: false, allowTemporaryParticipateCharacter: true, willConvertTemporaryMajorCharacters: false, willConvertTemporaryParticipateCharacters: true, canActionBeforehand: true, 6, 2, 0, 0));
		_dataArray.Add(new MonthlyActionsItem(45, LocalStringManager.GetConfig("MonthlyActions_language", "Name_45"), new List<sbyte>(), -1, -1, new List<short> { 15 }, 1, majorTargetMoveVisible: false, new CharacterFilterRequirement[1]
		{
			new CharacterFilterRequirement(new int[1] { 10 }, 5, 7)
		}, new CharacterFilterRequirement[1]
		{
			new CharacterFilterRequirement(new int[1] { 17 }, 8)
		}, 123, 182, isEnemyNest: false, allowTemporaryMajorCharacter: true, allowTemporaryParticipateCharacter: true, willConvertTemporaryMajorCharacters: false, willConvertTemporaryParticipateCharacters: true, canActionBeforehand: true, 6, 2, 0, 0));
		_dataArray.Add(new MonthlyActionsItem(46, LocalStringManager.GetConfig("MonthlyActions_language", "Name_46"), new List<sbyte> { 3 }, -1, -1, new List<short> { 17 }, 2, majorTargetMoveVisible: false, new CharacterFilterRequirement[1]
		{
			new CharacterFilterRequirement(new int[1] { 21 }, 1)
		}, new CharacterFilterRequirement[2]
		{
			new CharacterFilterRequirement(new int[1] { 19 }, 4, 8),
			new CharacterFilterRequirement(new int[1] { 20 }, 4, 8)
		}, 75, 183, isEnemyNest: false, allowTemporaryMajorCharacter: true, allowTemporaryParticipateCharacter: true, willConvertTemporaryMajorCharacters: false, willConvertTemporaryParticipateCharacters: false, canActionBeforehand: false, 2, 2, 24, 1));
		_dataArray.Add(new MonthlyActionsItem(47, LocalStringManager.GetConfig("MonthlyActions_language", "Name_47"), new List<sbyte> { 3 }, -1, -1, new List<short> { 18 }, 2, majorTargetMoveVisible: false, new CharacterFilterRequirement[1]
		{
			new CharacterFilterRequirement(new int[1] { 21 }, 1)
		}, new CharacterFilterRequirement[2]
		{
			new CharacterFilterRequirement(new int[1] { 19 }, 4, 8),
			new CharacterFilterRequirement(new int[1] { 20 }, 4, 8)
		}, 75, 183, isEnemyNest: false, allowTemporaryMajorCharacter: true, allowTemporaryParticipateCharacter: true, willConvertTemporaryMajorCharacters: false, willConvertTemporaryParticipateCharacters: false, canActionBeforehand: false, 2, 2, 24, 1));
		_dataArray.Add(new MonthlyActionsItem(48, LocalStringManager.GetConfig("MonthlyActions_language", "Name_48"), new List<sbyte> { 3 }, -1, -1, new List<short> { 19 }, 2, majorTargetMoveVisible: false, new CharacterFilterRequirement[1]
		{
			new CharacterFilterRequirement(new int[1] { 21 }, 1)
		}, new CharacterFilterRequirement[2]
		{
			new CharacterFilterRequirement(new int[1] { 19 }, 4, 8),
			new CharacterFilterRequirement(new int[1] { 20 }, 4, 8)
		}, 75, 183, isEnemyNest: false, allowTemporaryMajorCharacter: true, allowTemporaryParticipateCharacter: true, willConvertTemporaryMajorCharacters: false, willConvertTemporaryParticipateCharacters: false, canActionBeforehand: false, 2, 2, 24, 1));
		_dataArray.Add(new MonthlyActionsItem(49, LocalStringManager.GetConfig("MonthlyActions_language", "Name_49"), new List<sbyte> { 3 }, -1, -1, new List<short> { 20 }, 2, majorTargetMoveVisible: false, new CharacterFilterRequirement[1]
		{
			new CharacterFilterRequirement(new int[1] { 21 }, 1)
		}, new CharacterFilterRequirement[2]
		{
			new CharacterFilterRequirement(new int[1] { 19 }, 4, 8),
			new CharacterFilterRequirement(new int[1] { 20 }, 4, 8)
		}, 75, 183, isEnemyNest: false, allowTemporaryMajorCharacter: true, allowTemporaryParticipateCharacter: true, willConvertTemporaryMajorCharacters: false, willConvertTemporaryParticipateCharacters: false, canActionBeforehand: false, 2, 2, 24, 1));
		_dataArray.Add(new MonthlyActionsItem(50, LocalStringManager.GetConfig("MonthlyActions_language", "Name_50"), new List<sbyte> { 3 }, -1, -1, new List<short> { 21 }, 2, majorTargetMoveVisible: false, new CharacterFilterRequirement[1]
		{
			new CharacterFilterRequirement(new int[1] { 21 }, 1)
		}, new CharacterFilterRequirement[2]
		{
			new CharacterFilterRequirement(new int[1] { 19 }, 4, 8),
			new CharacterFilterRequirement(new int[1] { 20 }, 4, 8)
		}, 75, 183, isEnemyNest: false, allowTemporaryMajorCharacter: true, allowTemporaryParticipateCharacter: true, willConvertTemporaryMajorCharacters: false, willConvertTemporaryParticipateCharacters: false, canActionBeforehand: false, 2, 2, 24, 1));
		_dataArray.Add(new MonthlyActionsItem(51, LocalStringManager.GetConfig("MonthlyActions_language", "Name_51"), new List<sbyte> { 3 }, -1, -1, new List<short> { 22 }, 2, majorTargetMoveVisible: false, new CharacterFilterRequirement[1]
		{
			new CharacterFilterRequirement(new int[1] { 21 }, 1)
		}, new CharacterFilterRequirement[2]
		{
			new CharacterFilterRequirement(new int[1] { 19 }, 4, 8),
			new CharacterFilterRequirement(new int[1] { 20 }, 4, 8)
		}, 75, 183, isEnemyNest: false, allowTemporaryMajorCharacter: true, allowTemporaryParticipateCharacter: true, willConvertTemporaryMajorCharacters: false, willConvertTemporaryParticipateCharacters: false, canActionBeforehand: false, 2, 2, 24, 1));
		_dataArray.Add(new MonthlyActionsItem(52, LocalStringManager.GetConfig("MonthlyActions_language", "Name_52"), new List<sbyte> { 3 }, -1, -1, new List<short> { 23 }, 2, majorTargetMoveVisible: false, new CharacterFilterRequirement[1]
		{
			new CharacterFilterRequirement(new int[1] { 21 }, 1)
		}, new CharacterFilterRequirement[2]
		{
			new CharacterFilterRequirement(new int[1] { 19 }, 4, 8),
			new CharacterFilterRequirement(new int[1] { 20 }, 4, 8)
		}, 75, 183, isEnemyNest: false, allowTemporaryMajorCharacter: true, allowTemporaryParticipateCharacter: true, willConvertTemporaryMajorCharacters: false, willConvertTemporaryParticipateCharacters: false, canActionBeforehand: false, 2, 2, 24, 1));
		_dataArray.Add(new MonthlyActionsItem(53, LocalStringManager.GetConfig("MonthlyActions_language", "Name_53"), new List<sbyte> { 3 }, -1, -1, new List<short> { 24 }, 2, majorTargetMoveVisible: false, new CharacterFilterRequirement[1]
		{
			new CharacterFilterRequirement(new int[1] { 97 }, 1)
		}, new CharacterFilterRequirement[2]
		{
			new CharacterFilterRequirement(new int[1] { 95 }, 4, 8),
			new CharacterFilterRequirement(new int[1] { 96 }, 4, 8)
		}, 75, 183, isEnemyNest: false, allowTemporaryMajorCharacter: true, allowTemporaryParticipateCharacter: true, willConvertTemporaryMajorCharacters: false, willConvertTemporaryParticipateCharacters: false, canActionBeforehand: false, 2, 2, 24, 1));
		_dataArray.Add(new MonthlyActionsItem(54, LocalStringManager.GetConfig("MonthlyActions_language", "Name_54"), new List<sbyte> { 3 }, -1, -1, new List<short> { 25 }, 2, majorTargetMoveVisible: false, new CharacterFilterRequirement[1]
		{
			new CharacterFilterRequirement(new int[1] { 21 }, 1)
		}, new CharacterFilterRequirement[2]
		{
			new CharacterFilterRequirement(new int[1] { 19 }, 4, 8),
			new CharacterFilterRequirement(new int[1] { 20 }, 4, 8)
		}, 75, 183, isEnemyNest: false, allowTemporaryMajorCharacter: true, allowTemporaryParticipateCharacter: true, willConvertTemporaryMajorCharacters: false, willConvertTemporaryParticipateCharacters: false, canActionBeforehand: false, 2, 2, 24, 1));
		_dataArray.Add(new MonthlyActionsItem(55, LocalStringManager.GetConfig("MonthlyActions_language", "Name_55"), new List<sbyte> { 3 }, -1, -1, new List<short> { 26 }, 2, majorTargetMoveVisible: false, new CharacterFilterRequirement[1]
		{
			new CharacterFilterRequirement(new int[1] { 21 }, 1)
		}, new CharacterFilterRequirement[2]
		{
			new CharacterFilterRequirement(new int[1] { 19 }, 4, 8),
			new CharacterFilterRequirement(new int[1] { 20 }, 4, 8)
		}, 75, 183, isEnemyNest: false, allowTemporaryMajorCharacter: true, allowTemporaryParticipateCharacter: true, willConvertTemporaryMajorCharacters: false, willConvertTemporaryParticipateCharacters: false, canActionBeforehand: false, 2, 2, 24, 1));
		_dataArray.Add(new MonthlyActionsItem(56, LocalStringManager.GetConfig("MonthlyActions_language", "Name_56"), new List<sbyte> { 3 }, -1, -1, new List<short> { 27 }, 2, majorTargetMoveVisible: false, new CharacterFilterRequirement[1]
		{
			new CharacterFilterRequirement(new int[1] { 21 }, 1)
		}, new CharacterFilterRequirement[2]
		{
			new CharacterFilterRequirement(new int[1] { 19 }, 4, 8),
			new CharacterFilterRequirement(new int[1] { 20 }, 4, 8)
		}, 75, 183, isEnemyNest: false, allowTemporaryMajorCharacter: true, allowTemporaryParticipateCharacter: true, willConvertTemporaryMajorCharacters: false, willConvertTemporaryParticipateCharacters: false, canActionBeforehand: false, 2, 2, 24, 1));
		_dataArray.Add(new MonthlyActionsItem(57, LocalStringManager.GetConfig("MonthlyActions_language", "Name_57"), new List<sbyte> { 3 }, -1, -1, new List<short> { 28 }, 2, majorTargetMoveVisible: false, new CharacterFilterRequirement[1]
		{
			new CharacterFilterRequirement(new int[1] { 21 }, 1)
		}, new CharacterFilterRequirement[2]
		{
			new CharacterFilterRequirement(new int[1] { 19 }, 4, 8),
			new CharacterFilterRequirement(new int[1] { 20 }, 4, 8)
		}, 75, 183, isEnemyNest: false, allowTemporaryMajorCharacter: true, allowTemporaryParticipateCharacter: true, willConvertTemporaryMajorCharacters: false, willConvertTemporaryParticipateCharacters: false, canActionBeforehand: false, 2, 2, 24, 1));
		_dataArray.Add(new MonthlyActionsItem(58, LocalStringManager.GetConfig("MonthlyActions_language", "Name_58"), new List<sbyte> { 3 }, -1, -1, new List<short> { 29 }, 2, majorTargetMoveVisible: false, new CharacterFilterRequirement[1]
		{
			new CharacterFilterRequirement(new int[1] { 21 }, 1)
		}, new CharacterFilterRequirement[2]
		{
			new CharacterFilterRequirement(new int[1] { 19 }, 4, 8),
			new CharacterFilterRequirement(new int[1] { 20 }, 4, 8)
		}, 75, 183, isEnemyNest: false, allowTemporaryMajorCharacter: true, allowTemporaryParticipateCharacter: true, willConvertTemporaryMajorCharacters: false, willConvertTemporaryParticipateCharacters: false, canActionBeforehand: false, 2, 2, 24, 1));
		_dataArray.Add(new MonthlyActionsItem(59, LocalStringManager.GetConfig("MonthlyActions_language", "Name_59"), new List<sbyte> { 3 }, -1, -1, new List<short> { 30 }, 2, majorTargetMoveVisible: false, new CharacterFilterRequirement[1]
		{
			new CharacterFilterRequirement(new int[1] { 21 }, 1)
		}, new CharacterFilterRequirement[2]
		{
			new CharacterFilterRequirement(new int[1] { 19 }, 4, 8),
			new CharacterFilterRequirement(new int[1] { 20 }, 4, 8)
		}, 75, 183, isEnemyNest: false, allowTemporaryMajorCharacter: true, allowTemporaryParticipateCharacter: true, willConvertTemporaryMajorCharacters: false, willConvertTemporaryParticipateCharacters: false, canActionBeforehand: false, 2, 2, 24, 1));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new MonthlyActionsItem(60, LocalStringManager.GetConfig("MonthlyActions_language", "Name_60"), new List<sbyte> { 3 }, -1, -1, new List<short> { 31 }, 2, majorTargetMoveVisible: false, new CharacterFilterRequirement[1]
		{
			new CharacterFilterRequirement(new int[1] { 21 }, 1)
		}, new CharacterFilterRequirement[2]
		{
			new CharacterFilterRequirement(new int[1] { 19 }, 4, 8),
			new CharacterFilterRequirement(new int[1] { 20 }, 4, 8)
		}, 75, 183, isEnemyNest: false, allowTemporaryMajorCharacter: true, allowTemporaryParticipateCharacter: true, willConvertTemporaryMajorCharacters: false, willConvertTemporaryParticipateCharacters: false, canActionBeforehand: false, 2, 2, 24, 1));
		_dataArray.Add(new MonthlyActionsItem(61, LocalStringManager.GetConfig("MonthlyActions_language", "Name_61"), new List<sbyte> { 1 }, -1, -1, new List<short>(), 0, majorTargetMoveVisible: false, new CharacterFilterRequirement[0], new CharacterFilterRequirement[0], 77, 131, isEnemyNest: false, allowTemporaryMajorCharacter: false, allowTemporaryParticipateCharacter: false, willConvertTemporaryMajorCharacters: false, willConvertTemporaryParticipateCharacters: false, canActionBeforehand: false, 2, 2, 0, 0));
		_dataArray.Add(new MonthlyActionsItem(62, LocalStringManager.GetConfig("MonthlyActions_language", "Name_62"), new List<sbyte> { 3 }, -1, -1, new List<short> { 1, 2, 4, 6, 8, 10, 11, 12, 14, 15 }, 2, majorTargetMoveVisible: false, new CharacterFilterRequirement[0], new CharacterFilterRequirement[5]
		{
			new CharacterFilterRequirement(new int[1] { 22 }, 2, 4),
			new CharacterFilterRequirement(new int[1] { 33 }, 2, 4),
			new CharacterFilterRequirement(new int[1] { 44 }, 2, 4),
			new CharacterFilterRequirement(new int[1] { 55 }, 2, 4),
			new CharacterFilterRequirement(new int[1] { 66 }, 2, 4)
		}, 81, 132, isEnemyNest: false, allowTemporaryMajorCharacter: false, allowTemporaryParticipateCharacter: true, willConvertTemporaryMajorCharacters: false, willConvertTemporaryParticipateCharacters: false, canActionBeforehand: false, 2, 2, 0, 0));
		_dataArray.Add(new MonthlyActionsItem(63, LocalStringManager.GetConfig("MonthlyActions_language", "Name_63"), new List<sbyte> { 3 }, -1, -1, new List<short> { 1, 2, 3, 7, 8, 10, 12, 13, 15 }, 2, majorTargetMoveVisible: false, new CharacterFilterRequirement[0], new CharacterFilterRequirement[5]
		{
			new CharacterFilterRequirement(new int[1] { 23 }, 2, 4),
			new CharacterFilterRequirement(new int[1] { 34 }, 2, 4),
			new CharacterFilterRequirement(new int[1] { 45 }, 2, 4),
			new CharacterFilterRequirement(new int[1] { 56 }, 2, 4),
			new CharacterFilterRequirement(new int[1] { 67 }, 2, 4)
		}, 85, 132, isEnemyNest: false, allowTemporaryMajorCharacter: false, allowTemporaryParticipateCharacter: true, willConvertTemporaryMajorCharacters: false, willConvertTemporaryParticipateCharacters: false, canActionBeforehand: false, 2, 2, 0, 0));
		_dataArray.Add(new MonthlyActionsItem(64, LocalStringManager.GetConfig("MonthlyActions_language", "Name_64"), new List<sbyte> { 3 }, -1, -1, new List<short> { 5, 10, 15 }, 2, majorTargetMoveVisible: false, new CharacterFilterRequirement[0], new CharacterFilterRequirement[5]
		{
			new CharacterFilterRequirement(new int[1] { 24 }, 2, 4),
			new CharacterFilterRequirement(new int[1] { 35 }, 2, 4),
			new CharacterFilterRequirement(new int[1] { 46 }, 2, 4),
			new CharacterFilterRequirement(new int[1] { 57 }, 2, 4),
			new CharacterFilterRequirement(new int[1] { 68 }, 2, 4)
		}, 83, 132, isEnemyNest: false, allowTemporaryMajorCharacter: false, allowTemporaryParticipateCharacter: true, willConvertTemporaryMajorCharacters: false, willConvertTemporaryParticipateCharacters: false, canActionBeforehand: false, 2, 2, 0, 0));
		_dataArray.Add(new MonthlyActionsItem(65, LocalStringManager.GetConfig("MonthlyActions_language", "Name_65"), new List<sbyte> { 3 }, -1, -1, new List<short> { 10, 13, 14, 15 }, 2, majorTargetMoveVisible: false, new CharacterFilterRequirement[0], new CharacterFilterRequirement[5]
		{
			new CharacterFilterRequirement(new int[1] { 25 }, 2, 4),
			new CharacterFilterRequirement(new int[1] { 36 }, 2, 4),
			new CharacterFilterRequirement(new int[1] { 47 }, 2, 4),
			new CharacterFilterRequirement(new int[1] { 58 }, 2, 4),
			new CharacterFilterRequirement(new int[1] { 69 }, 2, 4)
		}, 78, 132, isEnemyNest: false, allowTemporaryMajorCharacter: false, allowTemporaryParticipateCharacter: true, willConvertTemporaryMajorCharacters: false, willConvertTemporaryParticipateCharacters: false, canActionBeforehand: false, 2, 2, 0, 0));
		_dataArray.Add(new MonthlyActionsItem(66, LocalStringManager.GetConfig("MonthlyActions_language", "Name_66"), new List<sbyte> { 3 }, -1, -1, new List<short> { 2, 4, 5, 7, 9, 12, 13 }, 2, majorTargetMoveVisible: false, new CharacterFilterRequirement[0], new CharacterFilterRequirement[5]
		{
			new CharacterFilterRequirement(new int[1] { 26 }, 2, 4),
			new CharacterFilterRequirement(new int[1] { 37 }, 2, 4),
			new CharacterFilterRequirement(new int[1] { 48 }, 2, 4),
			new CharacterFilterRequirement(new int[1] { 59 }, 2, 4),
			new CharacterFilterRequirement(new int[1] { 70 }, 2, 4)
		}, 74, 132, isEnemyNest: false, allowTemporaryMajorCharacter: false, allowTemporaryParticipateCharacter: true, willConvertTemporaryMajorCharacters: false, willConvertTemporaryParticipateCharacters: false, canActionBeforehand: false, 2, 2, 0, 0));
		_dataArray.Add(new MonthlyActionsItem(67, LocalStringManager.GetConfig("MonthlyActions_language", "Name_67"), new List<sbyte> { 3 }, -1, -1, new List<short> { 5, 6, 9, 11, 10 }, 2, majorTargetMoveVisible: false, new CharacterFilterRequirement[0], new CharacterFilterRequirement[5]
		{
			new CharacterFilterRequirement(new int[1] { 27 }, 2, 4),
			new CharacterFilterRequirement(new int[1] { 38 }, 2, 4),
			new CharacterFilterRequirement(new int[1] { 49 }, 2, 4),
			new CharacterFilterRequirement(new int[1] { 60 }, 2, 4),
			new CharacterFilterRequirement(new int[1] { 71 }, 2, 4)
		}, 73, 132, isEnemyNest: false, allowTemporaryMajorCharacter: false, allowTemporaryParticipateCharacter: true, willConvertTemporaryMajorCharacters: false, willConvertTemporaryParticipateCharacters: false, canActionBeforehand: false, 2, 2, 0, 0));
		_dataArray.Add(new MonthlyActionsItem(68, LocalStringManager.GetConfig("MonthlyActions_language", "Name_68"), new List<sbyte> { 3 }, -1, -1, new List<short> { 1, 6, 9 }, 2, majorTargetMoveVisible: false, new CharacterFilterRequirement[0], new CharacterFilterRequirement[5]
		{
			new CharacterFilterRequirement(new int[1] { 28 }, 2, 4),
			new CharacterFilterRequirement(new int[1] { 39 }, 2, 4),
			new CharacterFilterRequirement(new int[1] { 50 }, 2, 4),
			new CharacterFilterRequirement(new int[1] { 61 }, 2, 4),
			new CharacterFilterRequirement(new int[1] { 72 }, 2, 4)
		}, 79, 132, isEnemyNest: false, allowTemporaryMajorCharacter: false, allowTemporaryParticipateCharacter: true, willConvertTemporaryMajorCharacters: false, willConvertTemporaryParticipateCharacters: false, canActionBeforehand: false, 2, 2, 0, 0));
		_dataArray.Add(new MonthlyActionsItem(69, LocalStringManager.GetConfig("MonthlyActions_language", "Name_69"), new List<sbyte> { 3 }, -1, -1, new List<short> { 2, 7, 11 }, 2, majorTargetMoveVisible: false, new CharacterFilterRequirement[0], new CharacterFilterRequirement[5]
		{
			new CharacterFilterRequirement(new int[1] { 29 }, 2, 4),
			new CharacterFilterRequirement(new int[1] { 40 }, 2, 4),
			new CharacterFilterRequirement(new int[1] { 51 }, 2, 4),
			new CharacterFilterRequirement(new int[1] { 62 }, 2, 4),
			new CharacterFilterRequirement(new int[1] { 73 }, 2, 4)
		}, 80, 132, isEnemyNest: false, allowTemporaryMajorCharacter: false, allowTemporaryParticipateCharacter: true, willConvertTemporaryMajorCharacters: false, willConvertTemporaryParticipateCharacters: false, canActionBeforehand: false, 2, 2, 0, 0));
		_dataArray.Add(new MonthlyActionsItem(70, LocalStringManager.GetConfig("MonthlyActions_language", "Name_70"), new List<sbyte> { 3 }, -1, -1, new List<short> { 4, 12 }, 2, majorTargetMoveVisible: false, new CharacterFilterRequirement[0], new CharacterFilterRequirement[5]
		{
			new CharacterFilterRequirement(new int[1] { 30 }, 2, 4),
			new CharacterFilterRequirement(new int[1] { 41 }, 2, 4),
			new CharacterFilterRequirement(new int[1] { 52 }, 2, 4),
			new CharacterFilterRequirement(new int[1] { 63 }, 2, 4),
			new CharacterFilterRequirement(new int[1] { 74 }, 2, 4)
		}, 82, 132, isEnemyNest: false, allowTemporaryMajorCharacter: false, allowTemporaryParticipateCharacter: true, willConvertTemporaryMajorCharacters: false, willConvertTemporaryParticipateCharacters: false, canActionBeforehand: false, 2, 2, 0, 0));
		_dataArray.Add(new MonthlyActionsItem(71, LocalStringManager.GetConfig("MonthlyActions_language", "Name_71"), new List<sbyte> { 3 }, -1, -1, new List<short> { 3, 9 }, 2, majorTargetMoveVisible: false, new CharacterFilterRequirement[0], new CharacterFilterRequirement[5]
		{
			new CharacterFilterRequirement(new int[1] { 31 }, 2, 4),
			new CharacterFilterRequirement(new int[1] { 42 }, 2, 4),
			new CharacterFilterRequirement(new int[1] { 53 }, 2, 4),
			new CharacterFilterRequirement(new int[1] { 64 }, 2, 4),
			new CharacterFilterRequirement(new int[1] { 75 }, 2, 4)
		}, 84, 132, isEnemyNest: false, allowTemporaryMajorCharacter: false, allowTemporaryParticipateCharacter: true, willConvertTemporaryMajorCharacters: false, willConvertTemporaryParticipateCharacters: false, canActionBeforehand: false, 2, 2, 0, 0));
		_dataArray.Add(new MonthlyActionsItem(72, LocalStringManager.GetConfig("MonthlyActions_language", "Name_72"), new List<sbyte> { 3 }, -1, -1, new List<short> { 3, 8 }, 2, majorTargetMoveVisible: false, new CharacterFilterRequirement[0], new CharacterFilterRequirement[5]
		{
			new CharacterFilterRequirement(new int[1] { 32 }, 2, 4),
			new CharacterFilterRequirement(new int[1] { 43 }, 2, 4),
			new CharacterFilterRequirement(new int[1] { 54 }, 2, 4),
			new CharacterFilterRequirement(new int[1] { 65 }, 2, 4),
			new CharacterFilterRequirement(new int[1] { 76 }, 2, 4)
		}, 76, 132, isEnemyNest: false, allowTemporaryMajorCharacter: false, allowTemporaryParticipateCharacter: true, willConvertTemporaryMajorCharacters: false, willConvertTemporaryParticipateCharacters: false, canActionBeforehand: false, 2, 2, 0, 0));
		_dataArray.Add(new MonthlyActionsItem(73, LocalStringManager.GetConfig("MonthlyActions_language", "Name_73"), new List<sbyte> { 4 }, -1, -1, new List<short>
		{
			1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
			11, 12, 13, 14, 15
		}, 2, majorTargetMoveVisible: false, new CharacterFilterRequirement[0], new CharacterFilterRequirement[1]
		{
			new CharacterFilterRequirement(new int[1] { 77 }, 15, 20)
		}, 93, 134, isEnemyNest: false, allowTemporaryMajorCharacter: false, allowTemporaryParticipateCharacter: true, willConvertTemporaryMajorCharacters: false, willConvertTemporaryParticipateCharacters: false, canActionBeforehand: false, 2, 2, 0, 0));
		_dataArray.Add(new MonthlyActionsItem(74, LocalStringManager.GetConfig("MonthlyActions_language", "Name_74"), new List<sbyte> { 9 }, -1, -1, new List<short>
		{
			1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
			11, 12, 13, 14, 15
		}, 2, majorTargetMoveVisible: false, new CharacterFilterRequirement[0], new CharacterFilterRequirement[2]
		{
			new CharacterFilterRequirement(new int[1] { 78 }, 10, 12),
			new CharacterFilterRequirement(new int[1] { 85 }, 5, 10)
		}, 88, 135, isEnemyNest: false, allowTemporaryMajorCharacter: false, allowTemporaryParticipateCharacter: true, willConvertTemporaryMajorCharacters: false, willConvertTemporaryParticipateCharacters: false, canActionBeforehand: false, 2, 2, 0, 0));
		_dataArray.Add(new MonthlyActionsItem(75, LocalStringManager.GetConfig("MonthlyActions_language", "Name_75"), new List<sbyte> { 9 }, -1, -1, new List<short>
		{
			1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
			11, 12, 13, 14, 15
		}, 2, majorTargetMoveVisible: false, new CharacterFilterRequirement[0], new CharacterFilterRequirement[2]
		{
			new CharacterFilterRequirement(new int[1] { 79 }, 10, 12),
			new CharacterFilterRequirement(new int[1] { 85 }, 5, 10)
		}, 92, 135, isEnemyNest: false, allowTemporaryMajorCharacter: false, allowTemporaryParticipateCharacter: true, willConvertTemporaryMajorCharacters: false, willConvertTemporaryParticipateCharacters: false, canActionBeforehand: false, 2, 2, 0, 0));
		_dataArray.Add(new MonthlyActionsItem(76, LocalStringManager.GetConfig("MonthlyActions_language", "Name_76"), new List<sbyte> { 9 }, -1, -1, new List<short>
		{
			1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
			11, 12, 13, 14, 15
		}, 2, majorTargetMoveVisible: false, new CharacterFilterRequirement[0], new CharacterFilterRequirement[2]
		{
			new CharacterFilterRequirement(new int[1] { 80 }, 10, 12),
			new CharacterFilterRequirement(new int[1] { 85 }, 5, 10)
		}, 91, 135, isEnemyNest: false, allowTemporaryMajorCharacter: false, allowTemporaryParticipateCharacter: true, willConvertTemporaryMajorCharacters: false, willConvertTemporaryParticipateCharacters: false, canActionBeforehand: false, 2, 2, 0, 0));
		_dataArray.Add(new MonthlyActionsItem(77, LocalStringManager.GetConfig("MonthlyActions_language", "Name_77"), new List<sbyte> { 9 }, -1, -1, new List<short>
		{
			1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
			11, 12, 13, 14, 15
		}, 2, majorTargetMoveVisible: false, new CharacterFilterRequirement[0], new CharacterFilterRequirement[2]
		{
			new CharacterFilterRequirement(new int[1] { 81 }, 10, 12),
			new CharacterFilterRequirement(new int[1] { 85 }, 5, 10)
		}, 89, 135, isEnemyNest: false, allowTemporaryMajorCharacter: false, allowTemporaryParticipateCharacter: true, willConvertTemporaryMajorCharacters: false, willConvertTemporaryParticipateCharacters: false, canActionBeforehand: false, 2, 2, 0, 0));
		_dataArray.Add(new MonthlyActionsItem(78, LocalStringManager.GetConfig("MonthlyActions_language", "Name_78"), new List<sbyte> { 9 }, -1, -1, new List<short>
		{
			1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
			11, 12, 13, 14, 15
		}, 2, majorTargetMoveVisible: false, new CharacterFilterRequirement[0], new CharacterFilterRequirement[2]
		{
			new CharacterFilterRequirement(new int[1] { 82 }, 10, 12),
			new CharacterFilterRequirement(new int[1] { 85 }, 5, 10)
		}, 90, 135, isEnemyNest: false, allowTemporaryMajorCharacter: false, allowTemporaryParticipateCharacter: true, willConvertTemporaryMajorCharacters: false, willConvertTemporaryParticipateCharacters: false, canActionBeforehand: false, 2, 2, 0, 0));
		_dataArray.Add(new MonthlyActionsItem(79, LocalStringManager.GetConfig("MonthlyActions_language", "Name_79"), new List<sbyte> { 9 }, -1, -1, new List<short>
		{
			1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
			11, 12, 13, 14, 15
		}, 2, majorTargetMoveVisible: false, new CharacterFilterRequirement[0], new CharacterFilterRequirement[2]
		{
			new CharacterFilterRequirement(new int[1] { 83 }, 10, 12),
			new CharacterFilterRequirement(new int[1] { 85 }, 5, 10)
		}, 87, 135, isEnemyNest: false, allowTemporaryMajorCharacter: false, allowTemporaryParticipateCharacter: true, willConvertTemporaryMajorCharacters: false, willConvertTemporaryParticipateCharacters: false, canActionBeforehand: false, 2, 2, 0, 0));
		_dataArray.Add(new MonthlyActionsItem(80, LocalStringManager.GetConfig("MonthlyActions_language", "Name_80"), new List<sbyte> { 9 }, -1, -1, new List<short>
		{
			1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
			11, 12, 13, 14, 15
		}, 2, majorTargetMoveVisible: false, new CharacterFilterRequirement[0], new CharacterFilterRequirement[2]
		{
			new CharacterFilterRequirement(new int[1] { 84 }, 10, 12),
			new CharacterFilterRequirement(new int[1] { 85 }, 5, 10)
		}, 86, 135, isEnemyNest: false, allowTemporaryMajorCharacter: false, allowTemporaryParticipateCharacter: true, willConvertTemporaryMajorCharacters: false, willConvertTemporaryParticipateCharacters: false, canActionBeforehand: false, 2, 2, 0, 0));
		_dataArray.Add(new MonthlyActionsItem(81, LocalStringManager.GetConfig("MonthlyActions_language", "Name_81"), new List<sbyte>(), -1, -1, new List<short> { 18 }, 0, majorTargetMoveVisible: false, new CharacterFilterRequirement[0], new CharacterFilterRequirement[2]
		{
			new CharacterFilterRequirement(new int[1] { 86 }, 4, 4),
			new CharacterFilterRequirement(new int[1] { 87 }, 11, 11)
		}, 15, 278, isEnemyNest: false, allowTemporaryMajorCharacter: true, allowTemporaryParticipateCharacter: true, willConvertTemporaryMajorCharacters: true, willConvertTemporaryParticipateCharacters: true, canActionBeforehand: true, 0, 0, 0, 0));
		_dataArray.Add(new MonthlyActionsItem(82, LocalStringManager.GetConfig("MonthlyActions_language", "Name_82"), new List<sbyte>(), -1, -1, new List<short> { 23 }, 0, majorTargetMoveVisible: false, new CharacterFilterRequirement[1]
		{
			new CharacterFilterRequirement(new int[1] { 94 }, 1, 1)
		}, new CharacterFilterRequirement[4]
		{
			new CharacterFilterRequirement(new int[1] { 90 }, 3, 3),
			new CharacterFilterRequirement(new int[1] { 91 }, 3, 3),
			new CharacterFilterRequirement(new int[1] { 92 }, 3, 3),
			new CharacterFilterRequirement(new int[1] { 93 }, 1, 1)
		}, 20, 313, isEnemyNest: false, allowTemporaryMajorCharacter: true, allowTemporaryParticipateCharacter: true, willConvertTemporaryMajorCharacters: false, willConvertTemporaryParticipateCharacters: true, canActionBeforehand: true, 0, 0, 0, 0));
		_dataArray.Add(new MonthlyActionsItem(83, LocalStringManager.GetConfig("MonthlyActions_language", "Name_83"), new List<sbyte>(), -1, -1, new List<short> { 25 }, 0, majorTargetMoveVisible: false, new CharacterFilterRequirement[1]
		{
			new CharacterFilterRequirement(new int[1] { 102 }, 1, 1)
		}, new CharacterFilterRequirement[3]
		{
			new CharacterFilterRequirement(new int[1] { 101 }, 1, 1),
			new CharacterFilterRequirement(new int[1] { 100 }, 1, 1),
			new CharacterFilterRequirement(new int[1] { 99 }, 1, 1)
		}, 22, 366, isEnemyNest: false, allowTemporaryMajorCharacter: true, allowTemporaryParticipateCharacter: true, willConvertTemporaryMajorCharacters: false, willConvertTemporaryParticipateCharacters: true, canActionBeforehand: true, 0, 0, 0, 0));
		_dataArray.Add(new MonthlyActionsItem(84, LocalStringManager.GetConfig("MonthlyActions_language", "Name_84"), new List<sbyte>(), -1, -1, new List<short> { 21 }, 0, majorTargetMoveVisible: false, new CharacterFilterRequirement[1]
		{
			new CharacterFilterRequirement(new int[1] { 103 }, 1, 1)
		}, new CharacterFilterRequirement[4]
		{
			new CharacterFilterRequirement(new int[1] { 104 }, 1, 1),
			new CharacterFilterRequirement(new int[1] { 105 }, 1, 1),
			new CharacterFilterRequirement(new int[1] { 106 }, 10, 10),
			new CharacterFilterRequirement(new int[1] { 107 }, 1, 1)
		}, 18, 391, isEnemyNest: false, allowTemporaryMajorCharacter: true, allowTemporaryParticipateCharacter: true, willConvertTemporaryMajorCharacters: false, willConvertTemporaryParticipateCharacters: true, canActionBeforehand: true, 0, 0, 0, 0));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<MonthlyActionsItem>(85);
		CreateItems0();
		CreateItems1();
	}
}
