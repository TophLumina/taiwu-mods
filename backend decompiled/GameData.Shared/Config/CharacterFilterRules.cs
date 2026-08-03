using System;
using System.Collections.Generic;
using Config.Common;
using Config.ConfigCells.Character;

namespace Config;

[Serializable]
public class CharacterFilterRules : ConfigData<CharacterFilterRulesItem, short>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 筛选乞丐
		/// </summary>
		public const short BeggerFilter = 0;

		/// <summary>
		/// 筛选四阶弟子
		/// </summary>
		public const short Grade4Filter = 1;

		/// <summary>
		/// 筛选五阶以上弟子
		/// </summary>
		public const short Grade5Filter = 2;

		/// <summary>
		/// 筛选当地天人
		/// </summary>
		public const short BrideFilter1 = 3;

		/// <summary>
		/// 筛选当地非人
		/// </summary>
		public const short BrideFilter2 = 4;

		/// <summary>
		/// 筛选招亲参与者
		/// </summary>
		public const short MarriageMenFilter = 5;

		/// <summary>
		/// 筛选已成年的人物
		/// </summary>
		public const short AdultCharacterFilter = 6;

		/// <summary>
		/// 筛选入魔人
		/// </summary>
		public const short CompletelyInfectedFilter = 7;

		/// <summary>
		/// 筛选额外招亲女
		/// </summary>
		public const short WomanLocalFilter = 8;

		/// <summary>
		/// 筛选额外招亲男
		/// </summary>
		public const short ManLocalFilter = 9;

		/// <summary>
		/// 筛选额外招亲佳人
		/// </summary>
		public const short BeautyLocalFilter = 10;

		/// <summary>
		/// 筛选三阶人物
		/// </summary>
		public const short Grade3Filter = 11;

		/// <summary>
		/// 筛选心情不好强者
		/// </summary>
		public const short MoodBadFilter = 12;

		/// <summary>
		/// 筛选随机男继承人
		/// </summary>
		public const short RandomMaleSuccessor = 13;

		/// <summary>
		/// 筛选随机女继承人
		/// </summary>
		public const short RandomFemaleSuccessor = 14;

		/// <summary>
		/// 筛选武林大会人物
		/// </summary>
		public const short WulinConferenceFilter = 15;

		/// <summary>
		/// 筛选武林大会掌门
		/// </summary>
		public const short WulinConferencePrincipalFilter = 16;

		/// <summary>
		/// 筛选女版招亲参与者
		/// </summary>
		public const short FemaleMarriageMenFilter = 17;

		/// <summary>
		/// 筛选女版招亲额外男
		/// </summary>
		public const short FemaleMarriageMenLocalFilter = 18;

		/// <summary>
		/// 筛选低阶较武参与者
		/// </summary>
		public const short SectNormalCompetitionRolesLow = 19;

		/// <summary>
		/// 筛选中阶较武参与者
		/// </summary>
		public const short SectNormalCompetitionRolesMiddle = 20;

		/// <summary>
		/// 筛选高阶较武参与者
		/// </summary>
		public const short SectNormalCompetitionRolesHigh = 21;

		/// <summary>
		/// 筛选低阶较武参与者有头发
		/// </summary>
		public const short SectNormalCompetitionRolesLowWithHair = 95;

		/// <summary>
		/// 筛选中阶较武参与者有头发
		/// </summary>
		public const short SectNormalCompetitionRolesMiddleWithHair = 96;

		/// <summary>
		/// 筛选高阶较武参与者有头发
		/// </summary>
		public const short SectNormalCompetitionRolesHighWithHair = 97;

		/// <summary>
		/// 筛选较武主持者
		/// </summary>
		public const short SectPresiderRoles = 142;

		/// <summary>
		/// 筛选低阶较武正派俘虏
		/// </summary>
		public const short SectCaptiveGoodRolesLow = 145;

		/// <summary>
		/// 筛选中阶较武正派俘虏
		/// </summary>
		public const short SectCaptiveGoodRolesMiddle = 146;

		/// <summary>
		/// 筛选高阶较武正派俘虏
		/// </summary>
		public const short SectCaptiveGoodRolesHigh = 147;

		/// <summary>
		/// 筛选低阶较武邪派俘虏
		/// </summary>
		public const short SectCaptiveEvilRolesLow = 148;

		/// <summary>
		/// 筛选中阶较武邪派俘虏
		/// </summary>
		public const short SectCaptiveEvilRolesMiddle = 149;

		/// <summary>
		/// 筛选高阶较武邪派俘虏
		/// </summary>
		public const short SectCaptiveEvilRolesHigh = 150;

		/// <summary>
		/// 筛选较武考验正派俘虏
		/// </summary>
		public const short SectCaptiveGoodTestRoles = 151;

		/// <summary>
		/// 筛选较武考验邪派俘虏
		/// </summary>
		public const short SectCaptiveEvilTestRoles = 152;

		/// <summary>
		/// 筛选城镇拳掌参与者0
		/// </summary>
		public const short CityRolesGoodAtFistAndPalm0 = 22;

		/// <summary>
		/// 筛选城镇指法参与者0
		/// </summary>
		public const short CityRolesGoodAtFinger0 = 23;

		/// <summary>
		/// 筛选城镇腿法参与者0
		/// </summary>
		public const short CityRolesGoodAtLeg0 = 24;

		/// <summary>
		/// 筛选城镇暗器参与者0
		/// </summary>
		public const short CityRolesGoodAtThrow0 = 25;

		/// <summary>
		/// 筛选城镇剑法参与者0
		/// </summary>
		public const short CityRolesGoodAtSword0 = 26;

		/// <summary>
		/// 筛选城镇刀法参与者0
		/// </summary>
		public const short CityRolesGoodAtBlade0 = 27;

		/// <summary>
		/// 筛选城镇长兵参与者0
		/// </summary>
		public const short CityRolesGoodAtPolearm0 = 28;

		/// <summary>
		/// 筛选城镇奇门参与者0
		/// </summary>
		public const short CityRolesGoodAtSpecial0 = 29;

		/// <summary>
		/// 筛选城镇软兵参与者0
		/// </summary>
		public const short CityRolesGoodAtWhip0 = 30;

		/// <summary>
		/// 筛选城镇御射参与者0
		/// </summary>
		public const short CityRolesGoodAtControllableShot0 = 31;

		/// <summary>
		/// 筛选城镇乐器参与者0
		/// </summary>
		public const short CityRolesGoodAtCombatMusic0 = 32;

		/// <summary>
		/// 筛选城镇拳掌参与者1
		/// </summary>
		public const short CityRolesGoodAtFistAndPalm1 = 33;

		/// <summary>
		/// 筛选城镇指法参与者1
		/// </summary>
		public const short CityRolesGoodAtFinger1 = 34;

		/// <summary>
		/// 筛选城镇腿法参与者1
		/// </summary>
		public const short CityRolesGoodAtLeg1 = 35;

		/// <summary>
		/// 筛选城镇暗器参与者1
		/// </summary>
		public const short CityRolesGoodAtThrow1 = 36;

		/// <summary>
		/// 筛选城镇剑法参与者1
		/// </summary>
		public const short CityRolesGoodAtSword1 = 37;

		/// <summary>
		/// 筛选城镇刀法参与者1
		/// </summary>
		public const short CityRolesGoodAtBlade1 = 38;

		/// <summary>
		/// 筛选城镇长兵参与者1
		/// </summary>
		public const short CityRolesGoodAtPolearm1 = 39;

		/// <summary>
		/// 筛选城镇奇门参与者1
		/// </summary>
		public const short CityRolesGoodAtSpecial1 = 40;

		/// <summary>
		/// 筛选城镇软兵参与者1
		/// </summary>
		public const short CityRolesGoodAtWhip1 = 41;

		/// <summary>
		/// 筛选城镇御射参与者1
		/// </summary>
		public const short CityRolesGoodAtControllableShot1 = 42;

		/// <summary>
		/// 筛选城镇乐器参与者1
		/// </summary>
		public const short CityRolesGoodAtCombatMusic1 = 43;

		/// <summary>
		/// 筛选城镇拳掌参与者2
		/// </summary>
		public const short CityRolesGoodAtFistAndPalm2 = 44;

		/// <summary>
		/// 筛选城镇指法参与者2
		/// </summary>
		public const short CityRolesGoodAtFinger2 = 45;

		/// <summary>
		/// 筛选城镇腿法参与者2
		/// </summary>
		public const short CityRolesGoodAtLeg2 = 46;

		/// <summary>
		/// 筛选城镇暗器参与者2
		/// </summary>
		public const short CityRolesGoodAtThrow2 = 47;

		/// <summary>
		/// 筛选城镇剑法参与者2
		/// </summary>
		public const short CityRolesGoodAtSword2 = 48;

		/// <summary>
		/// 筛选城镇刀法参与者2
		/// </summary>
		public const short CityRolesGoodAtBlade2 = 49;

		/// <summary>
		/// 筛选城镇长兵参与者2
		/// </summary>
		public const short CityRolesGoodAtPolearm2 = 50;

		/// <summary>
		/// 筛选城镇奇门参与者2
		/// </summary>
		public const short CityRolesGoodAtSpecial2 = 51;

		/// <summary>
		/// 筛选城镇软兵参与者2
		/// </summary>
		public const short CityRolesGoodAtWhip2 = 52;

		/// <summary>
		/// 筛选城镇御射参与者2
		/// </summary>
		public const short CityRolesGoodAtControllableShot2 = 53;

		/// <summary>
		/// 筛选城镇乐器参与者2
		/// </summary>
		public const short CityRolesGoodAtCombatMusic2 = 54;

		/// <summary>
		/// 筛选城镇拳掌参与者3
		/// </summary>
		public const short CityRolesGoodAtFistAndPalm3 = 55;

		/// <summary>
		/// 筛选城镇指法参与者3
		/// </summary>
		public const short CityRolesGoodAtFinger3 = 56;

		/// <summary>
		/// 筛选城镇腿法参与者3
		/// </summary>
		public const short CityRolesGoodAtLeg3 = 57;

		/// <summary>
		/// 筛选城镇暗器参与者3
		/// </summary>
		public const short CityRolesGoodAtThrow3 = 58;

		/// <summary>
		/// 筛选城镇剑法参与者3
		/// </summary>
		public const short CityRolesGoodAtSword3 = 59;

		/// <summary>
		/// 筛选城镇刀法参与者3
		/// </summary>
		public const short CityRolesGoodAtBlade3 = 60;

		/// <summary>
		/// 筛选城镇长兵参与者3
		/// </summary>
		public const short CityRolesGoodAtPolearm3 = 61;

		/// <summary>
		/// 筛选城镇奇门参与者3
		/// </summary>
		public const short CityRolesGoodAtSpecial3 = 62;

		/// <summary>
		/// 筛选城镇软兵参与者3
		/// </summary>
		public const short CityRolesGoodAtWhip3 = 63;

		/// <summary>
		/// 筛选城镇御射参与者3
		/// </summary>
		public const short CityRolesGoodAtControllableShot3 = 64;

		/// <summary>
		/// 筛选城镇乐器参与者3
		/// </summary>
		public const short CityRolesGoodAtCombatMusic3 = 65;

		/// <summary>
		/// 筛选城镇拳掌参与者4
		/// </summary>
		public const short CityRolesGoodAtFistAndPalm4 = 66;

		/// <summary>
		/// 筛选城镇指法参与者4
		/// </summary>
		public const short CityRolesGoodAtFinger4 = 67;

		/// <summary>
		/// 筛选城镇腿法参与者4
		/// </summary>
		public const short CityRolesGoodAtLeg4 = 68;

		/// <summary>
		/// 筛选城镇暗器参与者4
		/// </summary>
		public const short CityRolesGoodAtThrow4 = 69;

		/// <summary>
		/// 筛选城镇剑法参与者4
		/// </summary>
		public const short CityRolesGoodAtSword4 = 70;

		/// <summary>
		/// 筛选城镇刀法参与者4
		/// </summary>
		public const short CityRolesGoodAtBlade4 = 71;

		/// <summary>
		/// 筛选城镇长兵参与者4
		/// </summary>
		public const short CityRolesGoodAtPolearm4 = 72;

		/// <summary>
		/// 筛选城镇奇门参与者4
		/// </summary>
		public const short CityRolesGoodAtSpecial4 = 73;

		/// <summary>
		/// 筛选城镇软兵参与者4
		/// </summary>
		public const short CityRolesGoodAtWhip4 = 74;

		/// <summary>
		/// 筛选城镇御射参与者4
		/// </summary>
		public const short CityRolesGoodAtControllableShot4 = 75;

		/// <summary>
		/// 筛选城镇乐器参与者4
		/// </summary>
		public const short CityRolesGoodAtCombatMusic4 = 76;

		/// <summary>
		/// 筛选有钱高阶参与者
		/// </summary>
		public const short CriketRichRoles = 77;

		/// <summary>
		/// 筛选城镇锻造参与者
		/// </summary>
		public const short CityRolesGoodAtForging = 78;

		/// <summary>
		/// 筛选城镇制木参与者
		/// </summary>
		public const short CityRolesGoodAtWoodworking = 79;

		/// <summary>
		/// 筛选城镇织锦参与者
		/// </summary>
		public const short CityRolesGoodAtWeaving = 80;

		/// <summary>
		/// 筛选城镇巧匠参与者
		/// </summary>
		public const short CityRolesGoodAtJade = 81;

		/// <summary>
		/// 筛选城镇医术参与者
		/// </summary>
		public const short CityRolesGoodAtMedicine = 82;

		/// <summary>
		/// 筛选城镇毒术参与者
		/// </summary>
		public const short CityRolesGoodAtToxicology = 83;

		/// <summary>
		/// 筛选城镇厨艺参与者
		/// </summary>
		public const short CityRolesGoodAtCooking = 84;

		/// <summary>
		/// 筛选较艺大会打分者
		/// </summary>
		public const short CityLifeScoreRoles = 85;

		/// <summary>
		/// 筛选何为正宗参与者一
		/// </summary>
		public const short SectMainStoryEmeiTwoPartOne = 86;

		/// <summary>
		/// 筛选何为正宗参与者二
		/// </summary>
		public const short SectMainStoryEmeiTwoPartTwo = 87;

		/// <summary>
		/// 筛选三宗比武五品
		/// </summary>
		public const short SectMainStoryRanshanGrade1 = 90;

		/// <summary>
		/// 筛选三宗比武六品
		/// </summary>
		public const short SectMainStoryRanshanGrade2 = 91;

		/// <summary>
		/// 筛选三宗比武七品
		/// </summary>
		public const short SectMainStoryRanshanGrade3 = 92;

		/// <summary>
		/// 筛选三宗比武八品
		/// </summary>
		public const short SectMainStoryRanshanGrade4 = 93;

		/// <summary>
		/// 筛选三宗比武青琅主
		/// </summary>
		public const short SectMainStoryRanshanGrade8 = 94;

		/// <summary>
		/// 筛选铸剑山庄镇山匠
		/// </summary>
		public const short SectMainStoryZhujianGrade4 = 98;

		/// <summary>
		/// 筛选铸剑山庄青君匠
		/// </summary>
		public const short SectMainStoryZhujianGrade2 = 99;

		/// <summary>
		/// 筛选铸剑山庄玄鸿匠
		/// </summary>
		public const short SectMainStoryZhujianGrade5 = 100;

		/// <summary>
		/// 筛选铸剑山庄百辟匠
		/// </summary>
		public const short SectMainStoryZhujianGrade3 = 101;

		/// <summary>
		/// 筛选铸剑山庄庄主
		/// </summary>
		public const short SectMainStoryZhujianGrade8 = 102;

		/// <summary>
		/// 筛选元山太师尊
		/// </summary>
		public const short SectMainStoryYuanshanGrade8 = 103;

		/// <summary>
		/// 筛选元山长老
		/// </summary>
		public const short SectMainStoryYuanshanGrade7 = 104;

		/// <summary>
		/// 筛选元山伏魔众
		/// </summary>
		public const short SectMainStoryYuanshanGrade6 = 105;

		/// <summary>
		/// 筛选随机下六阶元山弟子
		/// </summary>
		public const short SectMainStoryYuanshanGradeMidLow = 106;

		/// <summary>
		/// 筛选元山剧情符合世界进度的入魔人
		/// </summary>
		public const short SectMainStoryYuanshanXiangshuInfected = 107;

		/// <summary>
		/// 乱葬岗梦游者
		/// </summary>
		public const short SleepWalker = 108;

		/// <summary>
		/// 邪人死地人质
		/// </summary>
		public const short XieRenSidiHostage = 109;

		/// <summary>
		/// 邪人死地逃亡弟子
		/// </summary>
		public const short XieRenSidiGuider = 236;

		/// <summary>
		/// 修罗场义士
		/// </summary>
		public const short XiuLuoChangRighteous = 110;

		/// <summary>
		/// 恶人谷人物
		/// </summary>
		public const short VillainsValleyNPC = 111;

		/// <summary>
		/// 恶人谷食客
		/// </summary>
		public const short VillainsValleyDinner = 112;

		/// <summary>
		/// 恶人谷酒客
		/// </summary>
		public const short VillainsValleyDrinker = 113;

		/// <summary>
		/// 筛选掌门-少林派
		/// </summary>
		public const short SectLeaderShaolin = 119;

		/// <summary>
		/// 筛选掌门-峨眉派
		/// </summary>
		public const short SectLeaderEmei = 120;

		/// <summary>
		/// 筛选掌门-百花谷
		/// </summary>
		public const short SectLeaderBaihua = 121;

		/// <summary>
		/// 筛选掌门-武当派
		/// </summary>
		public const short SectLeaderWudang = 122;

		/// <summary>
		/// 筛选掌门-元山派
		/// </summary>
		public const short SectLeaderYuanshan = 123;

		/// <summary>
		/// 筛选掌门-狮相门
		/// </summary>
		public const short SectLeaderShixiang = 124;

		/// <summary>
		/// 筛选掌门-然山派
		/// </summary>
		public const short SectLeaderRanshan = 125;

		/// <summary>
		/// 筛选掌门-璇女派
		/// </summary>
		public const short SectLeaderXuannv = 126;

		/// <summary>
		/// 筛选掌门-铸剑山庄
		/// </summary>
		public const short SectLeaderZhujian = 127;

		/// <summary>
		/// 筛选掌门-空桑派
		/// </summary>
		public const short SectLeaderKongsang = 128;

		/// <summary>
		/// 筛选掌门-金刚宗
		/// </summary>
		public const short SectLeaderJingang = 129;

		/// <summary>
		/// 筛选掌门-五仙教
		/// </summary>
		public const short SectLeaderWuxian = 130;

		/// <summary>
		/// 筛选掌门-界青门
		/// </summary>
		public const short SectLeaderJieqing = 131;

		/// <summary>
		/// 筛选掌门-伏龙坛
		/// </summary>
		public const short SectLeaderFulong = 132;

		/// <summary>
		/// 筛选掌门-血犼教
		/// </summary>
		public const short SectLeaderXuehou = 133;

		/// <summary>
		/// 筛选心情不好
		/// </summary>
		public const short MoodBadAdvFilter = 134;

		/// <summary>
		/// 筛选心情好
		/// </summary>
		public const short MoodGoodAdvFilter = 135;

		/// <summary>
		/// 当前定居点首领
		/// </summary>
		public const short CurrentSettlementLeader = 156;

		/// <summary>
		/// 悍匪砦人质
		/// </summary>
		public const short BanditsStrongholdHostage = 208;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 筛选乞丐
		/// </summary>
		public static CharacterFilterRulesItem BeggerFilter => Instance[(short)0];

		/// <summary>
		/// 筛选四阶弟子
		/// </summary>
		public static CharacterFilterRulesItem Grade4Filter => Instance[(short)1];

		/// <summary>
		/// 筛选五阶以上弟子
		/// </summary>
		public static CharacterFilterRulesItem Grade5Filter => Instance[(short)2];

		/// <summary>
		/// 筛选当地天人
		/// </summary>
		public static CharacterFilterRulesItem BrideFilter1 => Instance[(short)3];

		/// <summary>
		/// 筛选当地非人
		/// </summary>
		public static CharacterFilterRulesItem BrideFilter2 => Instance[(short)4];

		/// <summary>
		/// 筛选招亲参与者
		/// </summary>
		public static CharacterFilterRulesItem MarriageMenFilter => Instance[(short)5];

		/// <summary>
		/// 筛选已成年的人物
		/// </summary>
		public static CharacterFilterRulesItem AdultCharacterFilter => Instance[(short)6];

		/// <summary>
		/// 筛选入魔人
		/// </summary>
		public static CharacterFilterRulesItem CompletelyInfectedFilter => Instance[(short)7];

		/// <summary>
		/// 筛选额外招亲女
		/// </summary>
		public static CharacterFilterRulesItem WomanLocalFilter => Instance[(short)8];

		/// <summary>
		/// 筛选额外招亲男
		/// </summary>
		public static CharacterFilterRulesItem ManLocalFilter => Instance[(short)9];

		/// <summary>
		/// 筛选额外招亲佳人
		/// </summary>
		public static CharacterFilterRulesItem BeautyLocalFilter => Instance[(short)10];

		/// <summary>
		/// 筛选三阶人物
		/// </summary>
		public static CharacterFilterRulesItem Grade3Filter => Instance[(short)11];

		/// <summary>
		/// 筛选心情不好强者
		/// </summary>
		public static CharacterFilterRulesItem MoodBadFilter => Instance[(short)12];

		/// <summary>
		/// 筛选随机男继承人
		/// </summary>
		public static CharacterFilterRulesItem RandomMaleSuccessor => Instance[(short)13];

		/// <summary>
		/// 筛选随机女继承人
		/// </summary>
		public static CharacterFilterRulesItem RandomFemaleSuccessor => Instance[(short)14];

		/// <summary>
		/// 筛选武林大会人物
		/// </summary>
		public static CharacterFilterRulesItem WulinConferenceFilter => Instance[(short)15];

		/// <summary>
		/// 筛选武林大会掌门
		/// </summary>
		public static CharacterFilterRulesItem WulinConferencePrincipalFilter => Instance[(short)16];

		/// <summary>
		/// 筛选女版招亲参与者
		/// </summary>
		public static CharacterFilterRulesItem FemaleMarriageMenFilter => Instance[(short)17];

		/// <summary>
		/// 筛选女版招亲额外男
		/// </summary>
		public static CharacterFilterRulesItem FemaleMarriageMenLocalFilter => Instance[(short)18];

		/// <summary>
		/// 筛选低阶较武参与者
		/// </summary>
		public static CharacterFilterRulesItem SectNormalCompetitionRolesLow => Instance[(short)19];

		/// <summary>
		/// 筛选中阶较武参与者
		/// </summary>
		public static CharacterFilterRulesItem SectNormalCompetitionRolesMiddle => Instance[(short)20];

		/// <summary>
		/// 筛选高阶较武参与者
		/// </summary>
		public static CharacterFilterRulesItem SectNormalCompetitionRolesHigh => Instance[(short)21];

		/// <summary>
		/// 筛选低阶较武参与者有头发
		/// </summary>
		public static CharacterFilterRulesItem SectNormalCompetitionRolesLowWithHair => Instance[(short)95];

		/// <summary>
		/// 筛选中阶较武参与者有头发
		/// </summary>
		public static CharacterFilterRulesItem SectNormalCompetitionRolesMiddleWithHair => Instance[(short)96];

		/// <summary>
		/// 筛选高阶较武参与者有头发
		/// </summary>
		public static CharacterFilterRulesItem SectNormalCompetitionRolesHighWithHair => Instance[(short)97];

		/// <summary>
		/// 筛选较武主持者
		/// </summary>
		public static CharacterFilterRulesItem SectPresiderRoles => Instance[(short)142];

		/// <summary>
		/// 筛选低阶较武正派俘虏
		/// </summary>
		public static CharacterFilterRulesItem SectCaptiveGoodRolesLow => Instance[(short)145];

		/// <summary>
		/// 筛选中阶较武正派俘虏
		/// </summary>
		public static CharacterFilterRulesItem SectCaptiveGoodRolesMiddle => Instance[(short)146];

		/// <summary>
		/// 筛选高阶较武正派俘虏
		/// </summary>
		public static CharacterFilterRulesItem SectCaptiveGoodRolesHigh => Instance[(short)147];

		/// <summary>
		/// 筛选低阶较武邪派俘虏
		/// </summary>
		public static CharacterFilterRulesItem SectCaptiveEvilRolesLow => Instance[(short)148];

		/// <summary>
		/// 筛选中阶较武邪派俘虏
		/// </summary>
		public static CharacterFilterRulesItem SectCaptiveEvilRolesMiddle => Instance[(short)149];

		/// <summary>
		/// 筛选高阶较武邪派俘虏
		/// </summary>
		public static CharacterFilterRulesItem SectCaptiveEvilRolesHigh => Instance[(short)150];

		/// <summary>
		/// 筛选较武考验正派俘虏
		/// </summary>
		public static CharacterFilterRulesItem SectCaptiveGoodTestRoles => Instance[(short)151];

		/// <summary>
		/// 筛选较武考验邪派俘虏
		/// </summary>
		public static CharacterFilterRulesItem SectCaptiveEvilTestRoles => Instance[(short)152];

		/// <summary>
		/// 筛选城镇拳掌参与者0
		/// </summary>
		public static CharacterFilterRulesItem CityRolesGoodAtFistAndPalm0 => Instance[(short)22];

		/// <summary>
		/// 筛选城镇指法参与者0
		/// </summary>
		public static CharacterFilterRulesItem CityRolesGoodAtFinger0 => Instance[(short)23];

		/// <summary>
		/// 筛选城镇腿法参与者0
		/// </summary>
		public static CharacterFilterRulesItem CityRolesGoodAtLeg0 => Instance[(short)24];

		/// <summary>
		/// 筛选城镇暗器参与者0
		/// </summary>
		public static CharacterFilterRulesItem CityRolesGoodAtThrow0 => Instance[(short)25];

		/// <summary>
		/// 筛选城镇剑法参与者0
		/// </summary>
		public static CharacterFilterRulesItem CityRolesGoodAtSword0 => Instance[(short)26];

		/// <summary>
		/// 筛选城镇刀法参与者0
		/// </summary>
		public static CharacterFilterRulesItem CityRolesGoodAtBlade0 => Instance[(short)27];

		/// <summary>
		/// 筛选城镇长兵参与者0
		/// </summary>
		public static CharacterFilterRulesItem CityRolesGoodAtPolearm0 => Instance[(short)28];

		/// <summary>
		/// 筛选城镇奇门参与者0
		/// </summary>
		public static CharacterFilterRulesItem CityRolesGoodAtSpecial0 => Instance[(short)29];

		/// <summary>
		/// 筛选城镇软兵参与者0
		/// </summary>
		public static CharacterFilterRulesItem CityRolesGoodAtWhip0 => Instance[(short)30];

		/// <summary>
		/// 筛选城镇御射参与者0
		/// </summary>
		public static CharacterFilterRulesItem CityRolesGoodAtControllableShot0 => Instance[(short)31];

		/// <summary>
		/// 筛选城镇乐器参与者0
		/// </summary>
		public static CharacterFilterRulesItem CityRolesGoodAtCombatMusic0 => Instance[(short)32];

		/// <summary>
		/// 筛选城镇拳掌参与者1
		/// </summary>
		public static CharacterFilterRulesItem CityRolesGoodAtFistAndPalm1 => Instance[(short)33];

		/// <summary>
		/// 筛选城镇指法参与者1
		/// </summary>
		public static CharacterFilterRulesItem CityRolesGoodAtFinger1 => Instance[(short)34];

		/// <summary>
		/// 筛选城镇腿法参与者1
		/// </summary>
		public static CharacterFilterRulesItem CityRolesGoodAtLeg1 => Instance[(short)35];

		/// <summary>
		/// 筛选城镇暗器参与者1
		/// </summary>
		public static CharacterFilterRulesItem CityRolesGoodAtThrow1 => Instance[(short)36];

		/// <summary>
		/// 筛选城镇剑法参与者1
		/// </summary>
		public static CharacterFilterRulesItem CityRolesGoodAtSword1 => Instance[(short)37];

		/// <summary>
		/// 筛选城镇刀法参与者1
		/// </summary>
		public static CharacterFilterRulesItem CityRolesGoodAtBlade1 => Instance[(short)38];

		/// <summary>
		/// 筛选城镇长兵参与者1
		/// </summary>
		public static CharacterFilterRulesItem CityRolesGoodAtPolearm1 => Instance[(short)39];

		/// <summary>
		/// 筛选城镇奇门参与者1
		/// </summary>
		public static CharacterFilterRulesItem CityRolesGoodAtSpecial1 => Instance[(short)40];

		/// <summary>
		/// 筛选城镇软兵参与者1
		/// </summary>
		public static CharacterFilterRulesItem CityRolesGoodAtWhip1 => Instance[(short)41];

		/// <summary>
		/// 筛选城镇御射参与者1
		/// </summary>
		public static CharacterFilterRulesItem CityRolesGoodAtControllableShot1 => Instance[(short)42];

		/// <summary>
		/// 筛选城镇乐器参与者1
		/// </summary>
		public static CharacterFilterRulesItem CityRolesGoodAtCombatMusic1 => Instance[(short)43];

		/// <summary>
		/// 筛选城镇拳掌参与者2
		/// </summary>
		public static CharacterFilterRulesItem CityRolesGoodAtFistAndPalm2 => Instance[(short)44];

		/// <summary>
		/// 筛选城镇指法参与者2
		/// </summary>
		public static CharacterFilterRulesItem CityRolesGoodAtFinger2 => Instance[(short)45];

		/// <summary>
		/// 筛选城镇腿法参与者2
		/// </summary>
		public static CharacterFilterRulesItem CityRolesGoodAtLeg2 => Instance[(short)46];

		/// <summary>
		/// 筛选城镇暗器参与者2
		/// </summary>
		public static CharacterFilterRulesItem CityRolesGoodAtThrow2 => Instance[(short)47];

		/// <summary>
		/// 筛选城镇剑法参与者2
		/// </summary>
		public static CharacterFilterRulesItem CityRolesGoodAtSword2 => Instance[(short)48];

		/// <summary>
		/// 筛选城镇刀法参与者2
		/// </summary>
		public static CharacterFilterRulesItem CityRolesGoodAtBlade2 => Instance[(short)49];

		/// <summary>
		/// 筛选城镇长兵参与者2
		/// </summary>
		public static CharacterFilterRulesItem CityRolesGoodAtPolearm2 => Instance[(short)50];

		/// <summary>
		/// 筛选城镇奇门参与者2
		/// </summary>
		public static CharacterFilterRulesItem CityRolesGoodAtSpecial2 => Instance[(short)51];

		/// <summary>
		/// 筛选城镇软兵参与者2
		/// </summary>
		public static CharacterFilterRulesItem CityRolesGoodAtWhip2 => Instance[(short)52];

		/// <summary>
		/// 筛选城镇御射参与者2
		/// </summary>
		public static CharacterFilterRulesItem CityRolesGoodAtControllableShot2 => Instance[(short)53];

		/// <summary>
		/// 筛选城镇乐器参与者2
		/// </summary>
		public static CharacterFilterRulesItem CityRolesGoodAtCombatMusic2 => Instance[(short)54];

		/// <summary>
		/// 筛选城镇拳掌参与者3
		/// </summary>
		public static CharacterFilterRulesItem CityRolesGoodAtFistAndPalm3 => Instance[(short)55];

		/// <summary>
		/// 筛选城镇指法参与者3
		/// </summary>
		public static CharacterFilterRulesItem CityRolesGoodAtFinger3 => Instance[(short)56];

		/// <summary>
		/// 筛选城镇腿法参与者3
		/// </summary>
		public static CharacterFilterRulesItem CityRolesGoodAtLeg3 => Instance[(short)57];

		/// <summary>
		/// 筛选城镇暗器参与者3
		/// </summary>
		public static CharacterFilterRulesItem CityRolesGoodAtThrow3 => Instance[(short)58];

		/// <summary>
		/// 筛选城镇剑法参与者3
		/// </summary>
		public static CharacterFilterRulesItem CityRolesGoodAtSword3 => Instance[(short)59];

		/// <summary>
		/// 筛选城镇刀法参与者3
		/// </summary>
		public static CharacterFilterRulesItem CityRolesGoodAtBlade3 => Instance[(short)60];

		/// <summary>
		/// 筛选城镇长兵参与者3
		/// </summary>
		public static CharacterFilterRulesItem CityRolesGoodAtPolearm3 => Instance[(short)61];

		/// <summary>
		/// 筛选城镇奇门参与者3
		/// </summary>
		public static CharacterFilterRulesItem CityRolesGoodAtSpecial3 => Instance[(short)62];

		/// <summary>
		/// 筛选城镇软兵参与者3
		/// </summary>
		public static CharacterFilterRulesItem CityRolesGoodAtWhip3 => Instance[(short)63];

		/// <summary>
		/// 筛选城镇御射参与者3
		/// </summary>
		public static CharacterFilterRulesItem CityRolesGoodAtControllableShot3 => Instance[(short)64];

		/// <summary>
		/// 筛选城镇乐器参与者3
		/// </summary>
		public static CharacterFilterRulesItem CityRolesGoodAtCombatMusic3 => Instance[(short)65];

		/// <summary>
		/// 筛选城镇拳掌参与者4
		/// </summary>
		public static CharacterFilterRulesItem CityRolesGoodAtFistAndPalm4 => Instance[(short)66];

		/// <summary>
		/// 筛选城镇指法参与者4
		/// </summary>
		public static CharacterFilterRulesItem CityRolesGoodAtFinger4 => Instance[(short)67];

		/// <summary>
		/// 筛选城镇腿法参与者4
		/// </summary>
		public static CharacterFilterRulesItem CityRolesGoodAtLeg4 => Instance[(short)68];

		/// <summary>
		/// 筛选城镇暗器参与者4
		/// </summary>
		public static CharacterFilterRulesItem CityRolesGoodAtThrow4 => Instance[(short)69];

		/// <summary>
		/// 筛选城镇剑法参与者4
		/// </summary>
		public static CharacterFilterRulesItem CityRolesGoodAtSword4 => Instance[(short)70];

		/// <summary>
		/// 筛选城镇刀法参与者4
		/// </summary>
		public static CharacterFilterRulesItem CityRolesGoodAtBlade4 => Instance[(short)71];

		/// <summary>
		/// 筛选城镇长兵参与者4
		/// </summary>
		public static CharacterFilterRulesItem CityRolesGoodAtPolearm4 => Instance[(short)72];

		/// <summary>
		/// 筛选城镇奇门参与者4
		/// </summary>
		public static CharacterFilterRulesItem CityRolesGoodAtSpecial4 => Instance[(short)73];

		/// <summary>
		/// 筛选城镇软兵参与者4
		/// </summary>
		public static CharacterFilterRulesItem CityRolesGoodAtWhip4 => Instance[(short)74];

		/// <summary>
		/// 筛选城镇御射参与者4
		/// </summary>
		public static CharacterFilterRulesItem CityRolesGoodAtControllableShot4 => Instance[(short)75];

		/// <summary>
		/// 筛选城镇乐器参与者4
		/// </summary>
		public static CharacterFilterRulesItem CityRolesGoodAtCombatMusic4 => Instance[(short)76];

		/// <summary>
		/// 筛选有钱高阶参与者
		/// </summary>
		public static CharacterFilterRulesItem CriketRichRoles => Instance[(short)77];

		/// <summary>
		/// 筛选城镇锻造参与者
		/// </summary>
		public static CharacterFilterRulesItem CityRolesGoodAtForging => Instance[(short)78];

		/// <summary>
		/// 筛选城镇制木参与者
		/// </summary>
		public static CharacterFilterRulesItem CityRolesGoodAtWoodworking => Instance[(short)79];

		/// <summary>
		/// 筛选城镇织锦参与者
		/// </summary>
		public static CharacterFilterRulesItem CityRolesGoodAtWeaving => Instance[(short)80];

		/// <summary>
		/// 筛选城镇巧匠参与者
		/// </summary>
		public static CharacterFilterRulesItem CityRolesGoodAtJade => Instance[(short)81];

		/// <summary>
		/// 筛选城镇医术参与者
		/// </summary>
		public static CharacterFilterRulesItem CityRolesGoodAtMedicine => Instance[(short)82];

		/// <summary>
		/// 筛选城镇毒术参与者
		/// </summary>
		public static CharacterFilterRulesItem CityRolesGoodAtToxicology => Instance[(short)83];

		/// <summary>
		/// 筛选城镇厨艺参与者
		/// </summary>
		public static CharacterFilterRulesItem CityRolesGoodAtCooking => Instance[(short)84];

		/// <summary>
		/// 筛选较艺大会打分者
		/// </summary>
		public static CharacterFilterRulesItem CityLifeScoreRoles => Instance[(short)85];

		/// <summary>
		/// 筛选何为正宗参与者一
		/// </summary>
		public static CharacterFilterRulesItem SectMainStoryEmeiTwoPartOne => Instance[(short)86];

		/// <summary>
		/// 筛选何为正宗参与者二
		/// </summary>
		public static CharacterFilterRulesItem SectMainStoryEmeiTwoPartTwo => Instance[(short)87];

		/// <summary>
		/// 筛选三宗比武五品
		/// </summary>
		public static CharacterFilterRulesItem SectMainStoryRanshanGrade1 => Instance[(short)90];

		/// <summary>
		/// 筛选三宗比武六品
		/// </summary>
		public static CharacterFilterRulesItem SectMainStoryRanshanGrade2 => Instance[(short)91];

		/// <summary>
		/// 筛选三宗比武七品
		/// </summary>
		public static CharacterFilterRulesItem SectMainStoryRanshanGrade3 => Instance[(short)92];

		/// <summary>
		/// 筛选三宗比武八品
		/// </summary>
		public static CharacterFilterRulesItem SectMainStoryRanshanGrade4 => Instance[(short)93];

		/// <summary>
		/// 筛选三宗比武青琅主
		/// </summary>
		public static CharacterFilterRulesItem SectMainStoryRanshanGrade8 => Instance[(short)94];

		/// <summary>
		/// 筛选铸剑山庄镇山匠
		/// </summary>
		public static CharacterFilterRulesItem SectMainStoryZhujianGrade4 => Instance[(short)98];

		/// <summary>
		/// 筛选铸剑山庄青君匠
		/// </summary>
		public static CharacterFilterRulesItem SectMainStoryZhujianGrade2 => Instance[(short)99];

		/// <summary>
		/// 筛选铸剑山庄玄鸿匠
		/// </summary>
		public static CharacterFilterRulesItem SectMainStoryZhujianGrade5 => Instance[(short)100];

		/// <summary>
		/// 筛选铸剑山庄百辟匠
		/// </summary>
		public static CharacterFilterRulesItem SectMainStoryZhujianGrade3 => Instance[(short)101];

		/// <summary>
		/// 筛选铸剑山庄庄主
		/// </summary>
		public static CharacterFilterRulesItem SectMainStoryZhujianGrade8 => Instance[(short)102];

		/// <summary>
		/// 筛选元山太师尊
		/// </summary>
		public static CharacterFilterRulesItem SectMainStoryYuanshanGrade8 => Instance[(short)103];

		/// <summary>
		/// 筛选元山长老
		/// </summary>
		public static CharacterFilterRulesItem SectMainStoryYuanshanGrade7 => Instance[(short)104];

		/// <summary>
		/// 筛选元山伏魔众
		/// </summary>
		public static CharacterFilterRulesItem SectMainStoryYuanshanGrade6 => Instance[(short)105];

		/// <summary>
		/// 筛选随机下六阶元山弟子
		/// </summary>
		public static CharacterFilterRulesItem SectMainStoryYuanshanGradeMidLow => Instance[(short)106];

		/// <summary>
		/// 筛选元山剧情符合世界进度的入魔人
		/// </summary>
		public static CharacterFilterRulesItem SectMainStoryYuanshanXiangshuInfected => Instance[(short)107];

		/// <summary>
		/// 乱葬岗梦游者
		/// </summary>
		public static CharacterFilterRulesItem SleepWalker => Instance[(short)108];

		/// <summary>
		/// 邪人死地人质
		/// </summary>
		public static CharacterFilterRulesItem XieRenSidiHostage => Instance[(short)109];

		/// <summary>
		/// 邪人死地逃亡弟子
		/// </summary>
		public static CharacterFilterRulesItem XieRenSidiGuider => Instance[(short)236];

		/// <summary>
		/// 修罗场义士
		/// </summary>
		public static CharacterFilterRulesItem XiuLuoChangRighteous => Instance[(short)110];

		/// <summary>
		/// 恶人谷人物
		/// </summary>
		public static CharacterFilterRulesItem VillainsValleyNPC => Instance[(short)111];

		/// <summary>
		/// 恶人谷食客
		/// </summary>
		public static CharacterFilterRulesItem VillainsValleyDinner => Instance[(short)112];

		/// <summary>
		/// 恶人谷酒客
		/// </summary>
		public static CharacterFilterRulesItem VillainsValleyDrinker => Instance[(short)113];

		/// <summary>
		/// 筛选掌门-少林派
		/// </summary>
		public static CharacterFilterRulesItem SectLeaderShaolin => Instance[(short)119];

		/// <summary>
		/// 筛选掌门-峨眉派
		/// </summary>
		public static CharacterFilterRulesItem SectLeaderEmei => Instance[(short)120];

		/// <summary>
		/// 筛选掌门-百花谷
		/// </summary>
		public static CharacterFilterRulesItem SectLeaderBaihua => Instance[(short)121];

		/// <summary>
		/// 筛选掌门-武当派
		/// </summary>
		public static CharacterFilterRulesItem SectLeaderWudang => Instance[(short)122];

		/// <summary>
		/// 筛选掌门-元山派
		/// </summary>
		public static CharacterFilterRulesItem SectLeaderYuanshan => Instance[(short)123];

		/// <summary>
		/// 筛选掌门-狮相门
		/// </summary>
		public static CharacterFilterRulesItem SectLeaderShixiang => Instance[(short)124];

		/// <summary>
		/// 筛选掌门-然山派
		/// </summary>
		public static CharacterFilterRulesItem SectLeaderRanshan => Instance[(short)125];

		/// <summary>
		/// 筛选掌门-璇女派
		/// </summary>
		public static CharacterFilterRulesItem SectLeaderXuannv => Instance[(short)126];

		/// <summary>
		/// 筛选掌门-铸剑山庄
		/// </summary>
		public static CharacterFilterRulesItem SectLeaderZhujian => Instance[(short)127];

		/// <summary>
		/// 筛选掌门-空桑派
		/// </summary>
		public static CharacterFilterRulesItem SectLeaderKongsang => Instance[(short)128];

		/// <summary>
		/// 筛选掌门-金刚宗
		/// </summary>
		public static CharacterFilterRulesItem SectLeaderJingang => Instance[(short)129];

		/// <summary>
		/// 筛选掌门-五仙教
		/// </summary>
		public static CharacterFilterRulesItem SectLeaderWuxian => Instance[(short)130];

		/// <summary>
		/// 筛选掌门-界青门
		/// </summary>
		public static CharacterFilterRulesItem SectLeaderJieqing => Instance[(short)131];

		/// <summary>
		/// 筛选掌门-伏龙坛
		/// </summary>
		public static CharacterFilterRulesItem SectLeaderFulong => Instance[(short)132];

		/// <summary>
		/// 筛选掌门-血犼教
		/// </summary>
		public static CharacterFilterRulesItem SectLeaderXuehou => Instance[(short)133];

		/// <summary>
		/// 筛选心情不好
		/// </summary>
		public static CharacterFilterRulesItem MoodBadAdvFilter => Instance[(short)134];

		/// <summary>
		/// 筛选心情好
		/// </summary>
		public static CharacterFilterRulesItem MoodGoodAdvFilter => Instance[(short)135];

		/// <summary>
		/// 当前定居点首领
		/// </summary>
		public static CharacterFilterRulesItem CurrentSettlementLeader => Instance[(short)156];

		/// <summary>
		/// 悍匪砦人质
		/// </summary>
		public static CharacterFilterRulesItem BanditsStrongholdHostage => Instance[(short)208];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static CharacterFilterRules Instance = new CharacterFilterRules();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "CharacterMatchers", "TemplateId" };

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
		_dataArray.Add(new CharacterFilterRulesItem(0, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1], 0, 0),
			new CharacterFilterElement(new int[1] { 4 }, 16, 90),
			new CharacterFilterElement(new int[1] { 2 }, 1, 1),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(1, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1], 5, 5),
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, -1, -1),
			new CharacterFilterElement(new int[1] { 4 }, 10, 90)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(2, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1], 4, 7),
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, -1, -1),
			new CharacterFilterElement(new int[1] { 4 }, 10, 90)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(3, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 5 }, 800, 900),
			new CharacterFilterElement(new int[1], 6, 7),
			new CharacterFilterElement(new int[1] { 2 }, 0, 0),
			new CharacterFilterElement(new int[1] { 4 }, 18, 20),
			new CharacterFilterElement(new int[1] { 6 }, -1, -1),
			new CharacterFilterElement(new int[1] { 9 }, 1, 1),
			new CharacterFilterElement(new int[1] { 7 }, 1, 1),
			new CharacterFilterElement(new int[1] { 11 }, 0, 0)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(4, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 5 }, 0, 100),
			new CharacterFilterElement(new int[1], 6, 7),
			new CharacterFilterElement(new int[1] { 2 }, 0, 0),
			new CharacterFilterElement(new int[1] { 4 }, 18, 20),
			new CharacterFilterElement(new int[1] { 6 }, -1, -1),
			new CharacterFilterElement(new int[1] { 9 }, 1, 1),
			new CharacterFilterElement(new int[1] { 7 }, 1, 1),
			new CharacterFilterElement(new int[1] { 11 }, 0, 0)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(5, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 2 }, 1, 1),
			new CharacterFilterElement(new int[1], 4, 7),
			new CharacterFilterElement(new int[1] { 4 }, 16, 60),
			new CharacterFilterElement(new int[1] { 7 }, 1, 1),
			new CharacterFilterElement(new int[1] { 9 }, 0, 2),
			new CharacterFilterElement(new int[1] { 11 }, 0, 0),
			new CharacterFilterElement(new int[1] { 12 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(6, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 1 }, 16, 90),
			new CharacterFilterElement(new int[1] { 9 }, 0, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(7, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 8 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(8, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1], 4, 7),
			new CharacterFilterElement(new int[1] { 2 }, 0, 0),
			new CharacterFilterElement(new int[1] { 4 }, 16, 30),
			new CharacterFilterElement(new int[1] { 6 }, -1, -1),
			new CharacterFilterElement(new int[1] { 7 }, 1, 1),
			new CharacterFilterElement(new int[1] { 11 }, 0, 0),
			new CharacterFilterElement(new int[1] { 9 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(9, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1], 4, 7),
			new CharacterFilterElement(new int[1] { 2 }, 1, 1),
			new CharacterFilterElement(new int[1] { 4 }, 16, 30),
			new CharacterFilterElement(new int[1] { 6 }, -1, -1),
			new CharacterFilterElement(new int[1] { 7 }, 1, 1),
			new CharacterFilterElement(new int[1] { 11 }, 0, 0),
			new CharacterFilterElement(new int[1] { 12 }, 1, 1),
			new CharacterFilterElement(new int[1] { 9 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(10, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1], 4, 7),
			new CharacterFilterElement(new int[1] { 2 }, 0, 0),
			new CharacterFilterElement(new int[1] { 4 }, 16, 30),
			new CharacterFilterElement(new int[1] { 6 }, -1, -1),
			new CharacterFilterElement(new int[1] { 7 }, 1, 1),
			new CharacterFilterElement(new int[1] { 5 }, 400, 900),
			new CharacterFilterElement(new int[1] { 11 }, 0, 0),
			new CharacterFilterElement(new int[1] { 9 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(11, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1], 6, 6),
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 4 }, 3, 90)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(12, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1], 6, 7),
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 10 }, -119, -30),
			new CharacterFilterElement(new int[1] { 4 }, 3, 90),
			new CharacterFilterElement(new int[1] { 15 }, 0, 0)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(13, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1], 0, 2),
			new CharacterFilterElement(new int[1] { 4 }, 16, 30),
			new CharacterFilterElement(new int[1] { 2 }, 1, 1),
			new CharacterFilterElement(new int[1] { 33 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(14, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1], 0, 2),
			new CharacterFilterElement(new int[1] { 4 }, 16, 30),
			new CharacterFilterElement(new int[1] { 2 }, 0, 0),
			new CharacterFilterElement(new int[1] { 33 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(15, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 15 }, 0, 0),
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, 1, 15),
			new CharacterFilterElement(new int[1] { 13 }, 1, 5)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(16, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1], 8, 8),
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, 1, 15),
			new CharacterFilterElement(new int[1] { 14 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(17, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 2 }, 1, 1),
			new CharacterFilterElement(new int[2] { 0, 1 }, -8, 1),
			new CharacterFilterElement(new int[1] { 4 }, 16, 50),
			new CharacterFilterElement(new int[1] { 7 }, 1, 1),
			new CharacterFilterElement(new int[1] { 9 }, 0, 2),
			new CharacterFilterElement(new int[1] { 11 }, 0, 0),
			new CharacterFilterElement(new int[1] { 12 }, 1, 1),
			new CharacterFilterElement(new int[1] { 5 }, 500, 900),
			new CharacterFilterElement(new int[1] { 15 }, 0, 0)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(18, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 2 }, 1, 1),
			new CharacterFilterElement(new int[2] { 0, 1 }, -8, 1),
			new CharacterFilterElement(new int[1] { 4 }, 16, 30),
			new CharacterFilterElement(new int[1] { 6 }, -1, -1),
			new CharacterFilterElement(new int[1] { 7 }, 1, 1),
			new CharacterFilterElement(new int[1] { 11 }, 0, 0),
			new CharacterFilterElement(new int[1] { 12 }, 1, 1),
			new CharacterFilterElement(new int[1] { 9 }, 0, 2),
			new CharacterFilterElement(new int[1] { 15 }, 0, 0)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(19, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, -1, -1),
			new CharacterFilterElement(new int[1] { 4 }, 17, 90),
			new CharacterFilterElement(new int[2] { 0, 1 }, -1, -1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(20, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, -1, -1),
			new CharacterFilterElement(new int[1] { 4 }, 17, 90),
			new CharacterFilterElement(new int[2] { 0, 1 }, 0, 0)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(21, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, -1, -1),
			new CharacterFilterElement(new int[1] { 4 }, 17, 90),
			new CharacterFilterElement(new int[2] { 0, 1 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(22, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 20, 3 }, 1, 1),
			new CharacterFilterElement(new int[1] { 16 }, 0, 5),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1] { 4 }, 10, 90),
			new CharacterFilterElement(new int[1], 0, 7)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(23, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 20, 4 }, 1, 1),
			new CharacterFilterElement(new int[1] { 16 }, 0, 5),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1] { 4 }, 10, 90),
			new CharacterFilterElement(new int[1], 0, 7)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(24, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 20, 5 }, 1, 1),
			new CharacterFilterElement(new int[1] { 16 }, 0, 5),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1] { 4 }, 10, 90),
			new CharacterFilterElement(new int[1], 0, 7)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(25, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 20, 6 }, 1, 1),
			new CharacterFilterElement(new int[1] { 16 }, 0, 5),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1] { 4 }, 10, 90),
			new CharacterFilterElement(new int[1], 0, 7)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(26, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 20, 7 }, 1, 1),
			new CharacterFilterElement(new int[1] { 16 }, 0, 5),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1] { 4 }, 10, 90),
			new CharacterFilterElement(new int[1], 0, 7)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(27, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 20, 8 }, 1, 1),
			new CharacterFilterElement(new int[1] { 16 }, 0, 5),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1] { 4 }, 10, 90),
			new CharacterFilterElement(new int[1], 0, 7)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(28, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 20, 9 }, 1, 1),
			new CharacterFilterElement(new int[1] { 16 }, 0, 5),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1] { 4 }, 10, 90),
			new CharacterFilterElement(new int[1], 0, 7)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(29, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 20, 10 }, 1, 1),
			new CharacterFilterElement(new int[1] { 16 }, 0, 5),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1] { 4 }, 10, 90),
			new CharacterFilterElement(new int[1], 0, 7)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(30, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 20, 11 }, 1, 1),
			new CharacterFilterElement(new int[1] { 16 }, 0, 5),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1] { 4 }, 10, 90),
			new CharacterFilterElement(new int[1], 0, 7)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(31, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 20, 12 }, 1, 1),
			new CharacterFilterElement(new int[1] { 16 }, 0, 5),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1] { 4 }, 10, 90),
			new CharacterFilterElement(new int[1], 0, 7)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(32, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 20, 13 }, 1, 1),
			new CharacterFilterElement(new int[1] { 16 }, 0, 5),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1] { 4 }, 10, 90),
			new CharacterFilterElement(new int[1], 0, 7)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(33, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 20, 3 }, 1, 1),
			new CharacterFilterElement(new int[1] { 16 }, 6, 7),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1] { 4 }, 10, 90),
			new CharacterFilterElement(new int[1], 0, 7)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(34, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 20, 4 }, 1, 1),
			new CharacterFilterElement(new int[1] { 16 }, 6, 7),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1] { 4 }, 10, 90),
			new CharacterFilterElement(new int[1], 0, 7)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(35, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 20, 5 }, 1, 1),
			new CharacterFilterElement(new int[1] { 16 }, 6, 7),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1] { 4 }, 10, 90),
			new CharacterFilterElement(new int[1], 0, 7)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(36, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 20, 6 }, 1, 1),
			new CharacterFilterElement(new int[1] { 16 }, 6, 7),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1] { 4 }, 10, 90),
			new CharacterFilterElement(new int[1], 0, 7)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(37, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 20, 7 }, 1, 1),
			new CharacterFilterElement(new int[1] { 16 }, 6, 7),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1] { 4 }, 10, 90),
			new CharacterFilterElement(new int[1], 0, 7)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(38, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 20, 8 }, 1, 1),
			new CharacterFilterElement(new int[1] { 16 }, 6, 7),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1] { 4 }, 10, 90),
			new CharacterFilterElement(new int[1], 0, 7)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(39, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 20, 9 }, 1, 1),
			new CharacterFilterElement(new int[1] { 16 }, 6, 7),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1] { 4 }, 10, 90),
			new CharacterFilterElement(new int[1], 0, 7)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(40, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 20, 10 }, 1, 1),
			new CharacterFilterElement(new int[1] { 16 }, 6, 7),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1] { 4 }, 10, 90),
			new CharacterFilterElement(new int[1], 0, 7)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(41, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 20, 11 }, 1, 1),
			new CharacterFilterElement(new int[1] { 16 }, 6, 7),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1] { 4 }, 10, 90),
			new CharacterFilterElement(new int[1], 0, 7)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(42, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 20, 12 }, 1, 1),
			new CharacterFilterElement(new int[1] { 16 }, 6, 7),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1] { 4 }, 10, 90),
			new CharacterFilterElement(new int[1], 0, 7)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(43, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 20, 13 }, 1, 1),
			new CharacterFilterElement(new int[1] { 16 }, 6, 7),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1] { 4 }, 10, 90),
			new CharacterFilterElement(new int[1], 0, 7)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(44, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 20, 3 }, 1, 1),
			new CharacterFilterElement(new int[1] { 16 }, 8, 9),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1] { 4 }, 10, 90),
			new CharacterFilterElement(new int[1], 0, 7)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(45, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 20, 4 }, 1, 1),
			new CharacterFilterElement(new int[1] { 16 }, 8, 9),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1] { 4 }, 10, 90),
			new CharacterFilterElement(new int[1], 0, 7)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(46, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 20, 5 }, 1, 1),
			new CharacterFilterElement(new int[1] { 16 }, 8, 9),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1] { 4 }, 10, 90),
			new CharacterFilterElement(new int[1], 0, 7)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(47, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 20, 6 }, 1, 1),
			new CharacterFilterElement(new int[1] { 16 }, 8, 9),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1] { 4 }, 10, 90),
			new CharacterFilterElement(new int[1], 0, 7)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(48, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 20, 7 }, 1, 1),
			new CharacterFilterElement(new int[1] { 16 }, 8, 9),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1] { 4 }, 10, 90),
			new CharacterFilterElement(new int[1], 0, 7)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(49, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 20, 8 }, 1, 1),
			new CharacterFilterElement(new int[1] { 16 }, 8, 9),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1] { 4 }, 10, 90),
			new CharacterFilterElement(new int[1], 0, 7)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(50, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 20, 9 }, 1, 1),
			new CharacterFilterElement(new int[1] { 16 }, 8, 9),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1] { 4 }, 10, 90),
			new CharacterFilterElement(new int[1], 0, 7)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(51, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 20, 10 }, 1, 1),
			new CharacterFilterElement(new int[1] { 16 }, 8, 9),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1] { 4 }, 10, 90),
			new CharacterFilterElement(new int[1], 0, 7)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(52, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 20, 11 }, 1, 1),
			new CharacterFilterElement(new int[1] { 16 }, 8, 9),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1] { 4 }, 10, 90),
			new CharacterFilterElement(new int[1], 0, 7)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(53, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 20, 12 }, 1, 1),
			new CharacterFilterElement(new int[1] { 16 }, 8, 9),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1] { 4 }, 10, 90),
			new CharacterFilterElement(new int[1], 0, 7)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(54, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 20, 13 }, 1, 1),
			new CharacterFilterElement(new int[1] { 16 }, 8, 9),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1] { 4 }, 10, 90),
			new CharacterFilterElement(new int[1], 0, 7)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(55, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 20, 3 }, 1, 1),
			new CharacterFilterElement(new int[1] { 16 }, 10, 11),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1] { 4 }, 10, 90),
			new CharacterFilterElement(new int[1], 0, 7)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(56, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 20, 4 }, 1, 1),
			new CharacterFilterElement(new int[1] { 16 }, 10, 11),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1] { 4 }, 10, 90),
			new CharacterFilterElement(new int[1], 0, 7)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(57, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 20, 5 }, 1, 1),
			new CharacterFilterElement(new int[1] { 16 }, 10, 11),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1] { 4 }, 10, 90),
			new CharacterFilterElement(new int[1], 0, 7)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(58, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 20, 6 }, 1, 1),
			new CharacterFilterElement(new int[1] { 16 }, 10, 11),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1] { 4 }, 10, 90),
			new CharacterFilterElement(new int[1], 0, 7)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(59, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 20, 7 }, 1, 1),
			new CharacterFilterElement(new int[1] { 16 }, 10, 11),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1] { 4 }, 10, 90),
			new CharacterFilterElement(new int[1], 0, 7)
		}));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new CharacterFilterRulesItem(60, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 20, 8 }, 1, 1),
			new CharacterFilterElement(new int[1] { 16 }, 10, 11),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1] { 4 }, 10, 90),
			new CharacterFilterElement(new int[1], 0, 7)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(61, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 20, 9 }, 1, 1),
			new CharacterFilterElement(new int[1] { 16 }, 10, 11),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1] { 4 }, 10, 90),
			new CharacterFilterElement(new int[1], 0, 7)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(62, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 20, 10 }, 1, 1),
			new CharacterFilterElement(new int[1] { 16 }, 10, 11),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1] { 4 }, 10, 90),
			new CharacterFilterElement(new int[1], 0, 7)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(63, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 20, 11 }, 1, 1),
			new CharacterFilterElement(new int[1] { 16 }, 10, 11),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1] { 4 }, 10, 90),
			new CharacterFilterElement(new int[1], 0, 7)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(64, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 20, 12 }, 1, 1),
			new CharacterFilterElement(new int[1] { 16 }, 10, 11),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1] { 4 }, 10, 90),
			new CharacterFilterElement(new int[1], 0, 7)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(65, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 20, 13 }, 1, 1),
			new CharacterFilterElement(new int[1] { 16 }, 10, 11),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1] { 4 }, 10, 90),
			new CharacterFilterElement(new int[1], 0, 7)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(66, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 20, 3 }, 1, 1),
			new CharacterFilterElement(new int[1] { 16 }, 12, 13),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1] { 4 }, 10, 90),
			new CharacterFilterElement(new int[1], 0, 7)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(67, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 20, 4 }, 1, 1),
			new CharacterFilterElement(new int[1] { 16 }, 12, 13),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1] { 4 }, 10, 90),
			new CharacterFilterElement(new int[1], 0, 7)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(68, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 20, 5 }, 1, 1),
			new CharacterFilterElement(new int[1] { 16 }, 12, 13),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1] { 4 }, 10, 90),
			new CharacterFilterElement(new int[1], 0, 7)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(69, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 20, 6 }, 1, 1),
			new CharacterFilterElement(new int[1] { 16 }, 12, 13),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1] { 4 }, 10, 90),
			new CharacterFilterElement(new int[1], 0, 7)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(70, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 20, 7 }, 1, 1),
			new CharacterFilterElement(new int[1] { 16 }, 12, 13),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1] { 4 }, 10, 90),
			new CharacterFilterElement(new int[1], 0, 7)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(71, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 20, 8 }, 1, 1),
			new CharacterFilterElement(new int[1] { 16 }, 12, 13),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1] { 4 }, 10, 90),
			new CharacterFilterElement(new int[1], 0, 7)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(72, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 20, 9 }, 1, 1),
			new CharacterFilterElement(new int[1] { 16 }, 12, 13),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1] { 4 }, 10, 90),
			new CharacterFilterElement(new int[1], 0, 7)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(73, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 20, 10 }, 1, 1),
			new CharacterFilterElement(new int[1] { 16 }, 12, 13),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1] { 4 }, 10, 90),
			new CharacterFilterElement(new int[1], 0, 7)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(74, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 20, 11 }, 1, 1),
			new CharacterFilterElement(new int[1] { 16 }, 12, 13),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1] { 4 }, 10, 90),
			new CharacterFilterElement(new int[1], 0, 7)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(75, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 20, 12 }, 1, 1),
			new CharacterFilterElement(new int[1] { 16 }, 12, 13),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1] { 4 }, 10, 90),
			new CharacterFilterElement(new int[1], 0, 7)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(76, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 20, 13 }, 1, 1),
			new CharacterFilterElement(new int[1] { 16 }, 12, 13),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1] { 4 }, 10, 90),
			new CharacterFilterElement(new int[1], 0, 7)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(77, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 21, 6 }, 10000, 500000),
			new CharacterFilterElement(new int[1], 4, 7),
			new CharacterFilterElement(new int[1] { 4 }, 10, 90),
			new CharacterFilterElement(new int[1] { 9 }, 0, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(78, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 19, 6 }, 1, 1),
			new CharacterFilterElement(new int[1], 1, 5),
			new CharacterFilterElement(new int[1] { 4 }, 10, 90),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(79, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 19, 7 }, 1, 1),
			new CharacterFilterElement(new int[1], 1, 5),
			new CharacterFilterElement(new int[1] { 4 }, 10, 90),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(80, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 19, 10 }, 1, 1),
			new CharacterFilterElement(new int[1], 1, 5),
			new CharacterFilterElement(new int[1] { 4 }, 10, 90),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(81, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 19, 11 }, 1, 1),
			new CharacterFilterElement(new int[1], 1, 5),
			new CharacterFilterElement(new int[1] { 4 }, 10, 90),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(82, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 19, 8 }, 1, 1),
			new CharacterFilterElement(new int[1], 1, 5),
			new CharacterFilterElement(new int[1] { 4 }, 10, 90),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(83, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 19, 9 }, 1, 1),
			new CharacterFilterElement(new int[1], 1, 5),
			new CharacterFilterElement(new int[1] { 4 }, 10, 90),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(84, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 19, 14 }, 1, 1),
			new CharacterFilterElement(new int[1], 1, 5),
			new CharacterFilterElement(new int[1] { 4 }, 10, 90),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(85, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 9 }, 0, 2),
			new CharacterFilterElement(new int[1] { 4 }, 3, 9999)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(86, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 6 }, 2, 2),
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1], 7, 7),
			new CharacterFilterElement(new int[1] { 4 }, 16, 90)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(87, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 6 }, 2, 2),
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1], 1, 6),
			new CharacterFilterElement(new int[1] { 4 }, 16, 90)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(88, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1], 4, 4),
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, -1, -1),
			new CharacterFilterElement(new int[1] { 4 }, 10, 90)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(89, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1], 5, 5),
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 4 }, 3, 90)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(90, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1], 4, 4),
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 4 }, 16, 40),
			new CharacterFilterElement(new int[1] { 6 }, 7, 7)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(91, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1], 3, 3),
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 4 }, 16, 40),
			new CharacterFilterElement(new int[1] { 6 }, 7, 7)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(92, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1], 2, 2),
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 4 }, 16, 40),
			new CharacterFilterElement(new int[1] { 6 }, 7, 7)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(93, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1], 1, 1),
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 4 }, 16, 40),
			new CharacterFilterElement(new int[1] { 6 }, 7, 7)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(94, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1], 8, 8),
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, 7, 7)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(95, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, -1, -1),
			new CharacterFilterElement(new int[1] { 4 }, 17, 90),
			new CharacterFilterElement(new int[2] { 0, 1 }, -1, -1),
			new CharacterFilterElement(new int[1] { 22 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(96, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, -1, -1),
			new CharacterFilterElement(new int[1] { 4 }, 17, 90),
			new CharacterFilterElement(new int[2] { 0, 1 }, 0, 0),
			new CharacterFilterElement(new int[1] { 22 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(97, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, -1, -1),
			new CharacterFilterElement(new int[1] { 4 }, 17, 90),
			new CharacterFilterElement(new int[2] { 0, 1 }, 1, 1),
			new CharacterFilterElement(new int[1] { 22 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(98, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1], 4, 4),
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 4 }, 60, 90),
			new CharacterFilterElement(new int[1] { 6 }, 9, 9),
			new CharacterFilterElement(new int[1] { 2 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(99, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1], 2, 2),
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 4 }, 60, 90),
			new CharacterFilterElement(new int[1] { 6 }, 9, 9),
			new CharacterFilterElement(new int[1] { 2 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(100, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1], 5, 5),
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 4 }, 60, 90),
			new CharacterFilterElement(new int[1] { 6 }, 9, 9),
			new CharacterFilterElement(new int[1] { 2 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(101, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1], 3, 3),
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 4 }, 60, 90),
			new CharacterFilterElement(new int[1] { 6 }, 9, 9),
			new CharacterFilterElement(new int[1] { 2 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(102, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1], 8, 8),
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 4 }, 18, 90),
			new CharacterFilterElement(new int[1] { 6 }, 9, 9)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(103, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1], 8, 8),
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 4 }, 18, 90),
			new CharacterFilterElement(new int[1] { 6 }, 5, 5)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(104, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1], 7, 7),
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 4 }, 18, 90),
			new CharacterFilterElement(new int[1] { 6 }, 5, 5)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(105, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1], 6, 6),
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 4 }, 18, 90),
			new CharacterFilterElement(new int[1] { 6 }, 5, 5)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(106, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1], 0, 5),
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 4 }, 18, 90),
			new CharacterFilterElement(new int[1] { 6 }, 5, 5)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(107, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 8 }, 1, 1),
			new CharacterFilterElement(new int[2] { 0, 1 }, 0, 0),
			new CharacterFilterElement(new int[1] { 4 }, 18, 90)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(108, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 6 }, -1, -1),
			new CharacterFilterElement(new int[1], 0, 2),
			new CharacterFilterElement(new int[1] { 4 }, 10, 50),
			new CharacterFilterElement(new int[1] { 9 }, 0, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(109, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, -1, -1),
			new CharacterFilterElement(new int[1] { 4 }, 16, 99),
			new CharacterFilterElement(new int[1], 5, 5)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(110, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 26 }, 5, 8),
			new CharacterFilterElement(new int[1] { 23 }, 1, 1),
			new CharacterFilterElement(new int[1], 4, 6),
			new CharacterFilterElement(new int[1] { 4 }, 16, 99),
			new CharacterFilterElement(new int[1] { 9 }, 0, 0)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(111, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1] { 28 }, 1, 3),
			new CharacterFilterElement(new int[1] { 4 }, 16, 99),
			new CharacterFilterElement(new int[1], 0, 3)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(112, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1] { 28 }, 1, 3),
			new CharacterFilterElement(new int[1] { 4 }, 16, 99),
			new CharacterFilterElement(new int[1] { 29 }, 700, 701),
			new CharacterFilterElement(new int[1], 0, 3)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(113, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1] { 28 }, 1, 3),
			new CharacterFilterElement(new int[1] { 4 }, 16, 99),
			new CharacterFilterElement(new int[1] { 29 }, 901, 901),
			new CharacterFilterElement(new int[1], 0, 3)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(114, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, 6, 6),
			new CharacterFilterElement(new int[1] { 4 }, 18, 90)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(115, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1] { 6 }, 6, 6),
			new CharacterFilterElement(new int[1] { 4 }, 18, 90),
			new CharacterFilterElement(new int[1], 5, 5),
			new CharacterFilterElement(new int[1] { 2 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(116, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, 12, 12),
			new CharacterFilterElement(new int[1] { 4 }, 18, 90),
			new CharacterFilterElement(new int[1], 6, 8)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(117, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, 12, 12),
			new CharacterFilterElement(new int[1] { 4 }, 18, 90),
			new CharacterFilterElement(new int[1], 0, 5)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(118, new int[1] { 10 }, new List<CharacterFilterElement>()));
		_dataArray.Add(new CharacterFilterRulesItem(119, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, 1, 1),
			new CharacterFilterElement(new int[1], 8, 8),
			new CharacterFilterElement(new int[1] { 14 }, 1, 1)
		}));
	}

	private void CreateItems2()
	{
		_dataArray.Add(new CharacterFilterRulesItem(120, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, 2, 2),
			new CharacterFilterElement(new int[1], 8, 8),
			new CharacterFilterElement(new int[1] { 14 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(121, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, 3, 3),
			new CharacterFilterElement(new int[1], 8, 8),
			new CharacterFilterElement(new int[1] { 14 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(122, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, 4, 4),
			new CharacterFilterElement(new int[1], 8, 8),
			new CharacterFilterElement(new int[1] { 14 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(123, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, 5, 5),
			new CharacterFilterElement(new int[1], 8, 8),
			new CharacterFilterElement(new int[1] { 14 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(124, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, 6, 6),
			new CharacterFilterElement(new int[1], 8, 8),
			new CharacterFilterElement(new int[1] { 14 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(125, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, 7, 7),
			new CharacterFilterElement(new int[1], 8, 8),
			new CharacterFilterElement(new int[1] { 14 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(126, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, 8, 8),
			new CharacterFilterElement(new int[1], 8, 8),
			new CharacterFilterElement(new int[1] { 14 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(127, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, 9, 9),
			new CharacterFilterElement(new int[1], 8, 8),
			new CharacterFilterElement(new int[1] { 14 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(128, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, 10, 10),
			new CharacterFilterElement(new int[1], 8, 8),
			new CharacterFilterElement(new int[1] { 14 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(129, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, 11, 11),
			new CharacterFilterElement(new int[1], 8, 8),
			new CharacterFilterElement(new int[1] { 14 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(130, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, 12, 12),
			new CharacterFilterElement(new int[1], 8, 8),
			new CharacterFilterElement(new int[1] { 14 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(131, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, 13, 13),
			new CharacterFilterElement(new int[1], 8, 8),
			new CharacterFilterElement(new int[1] { 14 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(132, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, 14, 14),
			new CharacterFilterElement(new int[1], 8, 8),
			new CharacterFilterElement(new int[1] { 14 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(133, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, 15, 15),
			new CharacterFilterElement(new int[1], 8, 8),
			new CharacterFilterElement(new int[1] { 14 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(134, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 16, 90),
			new CharacterFilterElement(new int[1] { 9 }, 0, 2),
			new CharacterFilterElement(new int[1] { 10 }, -119, -60)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(135, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 16, 90),
			new CharacterFilterElement(new int[1] { 9 }, 0, 2),
			new CharacterFilterElement(new int[1] { 10 }, 60, 119)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(136, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 16, 90),
			new CharacterFilterElement(new int[1], 6, 8),
			new CharacterFilterElement(new int[1] { 31 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(137, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 6 }, -1, -1),
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1], 0, 2),
			new CharacterFilterElement(new int[1] { 1 }, 16, 90)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(138, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 6 }, -1, -1),
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1], 3, 5),
			new CharacterFilterElement(new int[1] { 1 }, 16, 90)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(139, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 6 }, -1, -1),
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1], 6, 7),
			new CharacterFilterElement(new int[1] { 1 }, 16, 90)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(140, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 6 }, -1, -1),
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1], 8, 8),
			new CharacterFilterElement(new int[1] { 14 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(141, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 6 }, -1, -1),
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1], 0, 7),
			new CharacterFilterElement(new int[1] { 32 }, 14000, 30000),
			new CharacterFilterElement(new int[1] { 1 }, 16, 90)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(142, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, -1, -1),
			new CharacterFilterElement(new int[1] { 4 }, 17, 90),
			new CharacterFilterElement(new int[2] { 0, 1 }, 2, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(143, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1], 0, 5),
			new CharacterFilterElement(new int[1] { 4 }, 16, 90),
			new CharacterFilterElement(new int[1] { 9 }, 0, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(144, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1], 4, 7),
			new CharacterFilterElement(new int[1] { 4 }, 16, 90),
			new CharacterFilterElement(new int[1] { 9 }, 0, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(145, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, 3, 3),
			new CharacterFilterElement(new int[1] { 4 }, 17, 90),
			new CharacterFilterElement(new int[2] { 0, 1 }, -1, -1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(146, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, 3, 3),
			new CharacterFilterElement(new int[1] { 4 }, 17, 90),
			new CharacterFilterElement(new int[2] { 0, 1 }, 0, 0)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(147, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, 3, 3),
			new CharacterFilterElement(new int[1] { 4 }, 17, 90),
			new CharacterFilterElement(new int[2] { 0, 1 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(148, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, 12, 12),
			new CharacterFilterElement(new int[1] { 4 }, 17, 90),
			new CharacterFilterElement(new int[2] { 0, 1 }, -1, -1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(149, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, 12, 12),
			new CharacterFilterElement(new int[1] { 4 }, 17, 90),
			new CharacterFilterElement(new int[2] { 0, 1 }, 0, 0)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(150, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, 12, 12),
			new CharacterFilterElement(new int[1] { 4 }, 17, 90),
			new CharacterFilterElement(new int[2] { 0, 1 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(151, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, 1, 5),
			new CharacterFilterElement(new int[1] { 4 }, 17, 90),
			new CharacterFilterElement(new int[2] { 0, 1 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(152, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, 11, 15),
			new CharacterFilterElement(new int[1] { 4 }, 17, 90),
			new CharacterFilterElement(new int[2] { 0, 1 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(153, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 2 }, 0, 0),
			new CharacterFilterElement(new int[1] { 1 }, 20, 50),
			new CharacterFilterElement(new int[1] { 16 }, 0, 3),
			new CharacterFilterElement(new int[1], 0, 3),
			new CharacterFilterElement(new int[1] { 9 }, 0, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(154, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 2 }, 1, 1),
			new CharacterFilterElement(new int[1] { 1 }, 60, 80),
			new CharacterFilterElement(new int[1], 0, 3),
			new CharacterFilterElement(new int[1] { 9 }, 0, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(155, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 1 }, 8, 16),
			new CharacterFilterElement(new int[1], 0, 3),
			new CharacterFilterElement(new int[1] { 9 }, 0, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(156, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 31 }, 1, 1),
			new CharacterFilterElement(new int[1], 8, 8),
			new CharacterFilterElement(new int[1] { 14 }, 1, 1),
			new CharacterFilterElement(new int[1] { 4 }, 16, 99)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(157, new int[1] { 64 }, new List<CharacterFilterElement>()));
		_dataArray.Add(new CharacterFilterRulesItem(158, new int[1] { 62 }, new List<CharacterFilterElement>()));
		_dataArray.Add(new CharacterFilterRulesItem(159, new int[1] { 59 }, new List<CharacterFilterElement>()));
		_dataArray.Add(new CharacterFilterRulesItem(160, new int[1] { 63 }, new List<CharacterFilterElement>()));
		_dataArray.Add(new CharacterFilterRulesItem(161, new int[1] { 65 }, new List<CharacterFilterElement>()));
		_dataArray.Add(new CharacterFilterRulesItem(162, new int[1] { 60 }, new List<CharacterFilterElement>()));
		_dataArray.Add(new CharacterFilterRulesItem(163, new int[1] { 61 }, new List<CharacterFilterElement>()));
		_dataArray.Add(new CharacterFilterRulesItem(164, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, 2, 2),
			new CharacterFilterElement(new int[1], 1, 4),
			new CharacterFilterElement(new int[1] { 14 }, 1, 1),
			new CharacterFilterElement(new int[1] { 2 }, 1, 1),
			new CharacterFilterElement(new int[1] { 4 }, 16, 60),
			new CharacterFilterElement(new int[1] { 7 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(165, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, 4, 4),
			new CharacterFilterElement(new int[1], 1, 4),
			new CharacterFilterElement(new int[1] { 14 }, 1, 1),
			new CharacterFilterElement(new int[1] { 2 }, 1, 1),
			new CharacterFilterElement(new int[1] { 4 }, 16, 60),
			new CharacterFilterElement(new int[1] { 7 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(166, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, 5, 5),
			new CharacterFilterElement(new int[1], 1, 4),
			new CharacterFilterElement(new int[1] { 14 }, 1, 1),
			new CharacterFilterElement(new int[1] { 2 }, 1, 1),
			new CharacterFilterElement(new int[1] { 4 }, 16, 60),
			new CharacterFilterElement(new int[1] { 7 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(167, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, 9, 9),
			new CharacterFilterElement(new int[1], 1, 4),
			new CharacterFilterElement(new int[1] { 14 }, 1, 1),
			new CharacterFilterElement(new int[1] { 2 }, 1, 1),
			new CharacterFilterElement(new int[1] { 4 }, 16, 60),
			new CharacterFilterElement(new int[1] { 7 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(168, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, 6, 6),
			new CharacterFilterElement(new int[1], 1, 4),
			new CharacterFilterElement(new int[1] { 14 }, 1, 1),
			new CharacterFilterElement(new int[1] { 2 }, 1, 1),
			new CharacterFilterElement(new int[1] { 4 }, 16, 60),
			new CharacterFilterElement(new int[1] { 7 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(169, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, 10, 10),
			new CharacterFilterElement(new int[1], 1, 4),
			new CharacterFilterElement(new int[1] { 14 }, 1, 1),
			new CharacterFilterElement(new int[1] { 2 }, 1, 1),
			new CharacterFilterElement(new int[1] { 4 }, 16, 60),
			new CharacterFilterElement(new int[1] { 7 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(170, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, 14, 14),
			new CharacterFilterElement(new int[1], 1, 4),
			new CharacterFilterElement(new int[1] { 14 }, 1, 1),
			new CharacterFilterElement(new int[1] { 2 }, 1, 1),
			new CharacterFilterElement(new int[1] { 4 }, 16, 60),
			new CharacterFilterElement(new int[1] { 7 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(171, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, 13, 13),
			new CharacterFilterElement(new int[1], 1, 4),
			new CharacterFilterElement(new int[1] { 14 }, 1, 1),
			new CharacterFilterElement(new int[1] { 2 }, 1, 1),
			new CharacterFilterElement(new int[1] { 4 }, 16, 60),
			new CharacterFilterElement(new int[1] { 7 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(172, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, 15, 15),
			new CharacterFilterElement(new int[1], 1, 4),
			new CharacterFilterElement(new int[1] { 14 }, 1, 1),
			new CharacterFilterElement(new int[1] { 2 }, 1, 1),
			new CharacterFilterElement(new int[1] { 4 }, 16, 60),
			new CharacterFilterElement(new int[1] { 7 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(173, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 2 }, 1, 1),
			new CharacterFilterElement(new int[1] { 27 }, 59, 90),
			new CharacterFilterElement(new int[1] { 1 }, 18, 50),
			new CharacterFilterElement(new int[1] { 7 }, 1, 1),
			new CharacterFilterElement(new int[1] { 9 }, 0, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(174, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 2 }, 1, 1),
			new CharacterFilterElement(new int[1] { 26 }, 59, 90),
			new CharacterFilterElement(new int[1] { 1 }, 18, 50),
			new CharacterFilterElement(new int[1] { 7 }, 1, 1),
			new CharacterFilterElement(new int[1] { 9 }, 0, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(175, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1], 4, 4),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(176, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, 2, 2),
			new CharacterFilterElement(new int[1], 1, 4),
			new CharacterFilterElement(new int[1] { 14 }, 1, 1),
			new CharacterFilterElement(new int[1] { 2 }, 0, 0),
			new CharacterFilterElement(new int[1] { 4 }, 16, 60),
			new CharacterFilterElement(new int[1] { 7 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(177, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, 4, 4),
			new CharacterFilterElement(new int[1], 1, 4),
			new CharacterFilterElement(new int[1] { 14 }, 1, 1),
			new CharacterFilterElement(new int[1] { 2 }, 0, 0),
			new CharacterFilterElement(new int[1] { 4 }, 16, 60),
			new CharacterFilterElement(new int[1] { 7 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(178, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, 5, 5),
			new CharacterFilterElement(new int[1], 1, 4),
			new CharacterFilterElement(new int[1] { 14 }, 1, 1),
			new CharacterFilterElement(new int[1] { 2 }, 0, 0),
			new CharacterFilterElement(new int[1] { 4 }, 16, 60),
			new CharacterFilterElement(new int[1] { 7 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(179, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, 9, 9),
			new CharacterFilterElement(new int[1], 1, 4),
			new CharacterFilterElement(new int[1] { 14 }, 1, 1),
			new CharacterFilterElement(new int[1] { 2 }, 0, 0),
			new CharacterFilterElement(new int[1] { 4 }, 16, 60),
			new CharacterFilterElement(new int[1] { 7 }, 1, 1)
		}));
	}

	private void CreateItems3()
	{
		_dataArray.Add(new CharacterFilterRulesItem(180, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, 6, 6),
			new CharacterFilterElement(new int[1], 1, 4),
			new CharacterFilterElement(new int[1] { 14 }, 1, 1),
			new CharacterFilterElement(new int[1] { 2 }, 0, 0),
			new CharacterFilterElement(new int[1] { 4 }, 16, 60),
			new CharacterFilterElement(new int[1] { 7 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(181, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, 10, 10),
			new CharacterFilterElement(new int[1], 1, 4),
			new CharacterFilterElement(new int[1] { 14 }, 1, 1),
			new CharacterFilterElement(new int[1] { 2 }, 0, 0),
			new CharacterFilterElement(new int[1] { 4 }, 16, 60),
			new CharacterFilterElement(new int[1] { 7 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(182, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, 14, 14),
			new CharacterFilterElement(new int[1], 1, 4),
			new CharacterFilterElement(new int[1] { 14 }, 1, 1),
			new CharacterFilterElement(new int[1] { 2 }, 0, 0),
			new CharacterFilterElement(new int[1] { 4 }, 16, 60),
			new CharacterFilterElement(new int[1] { 7 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(183, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, 13, 13),
			new CharacterFilterElement(new int[1], 1, 4),
			new CharacterFilterElement(new int[1] { 14 }, 1, 1),
			new CharacterFilterElement(new int[1] { 2 }, 0, 0),
			new CharacterFilterElement(new int[1] { 4 }, 16, 60),
			new CharacterFilterElement(new int[1] { 7 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(184, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, 15, 15),
			new CharacterFilterElement(new int[1], 1, 4),
			new CharacterFilterElement(new int[1] { 14 }, 1, 1),
			new CharacterFilterElement(new int[1] { 2 }, 0, 0),
			new CharacterFilterElement(new int[1] { 4 }, 16, 60),
			new CharacterFilterElement(new int[1] { 7 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(185, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 2 }, 0, 0),
			new CharacterFilterElement(new int[1] { 27 }, 59, 90),
			new CharacterFilterElement(new int[1] { 1 }, 18, 50),
			new CharacterFilterElement(new int[1] { 7 }, 1, 1),
			new CharacterFilterElement(new int[1] { 9 }, 0, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(186, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 2 }, 0, 0),
			new CharacterFilterElement(new int[1] { 26 }, 59, 90),
			new CharacterFilterElement(new int[1] { 1 }, 18, 50),
			new CharacterFilterElement(new int[1] { 7 }, 1, 1),
			new CharacterFilterElement(new int[1] { 9 }, 0, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(187, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 2 }, 0, 0),
			new CharacterFilterElement(new int[2] { 21, 6 }, 5000, 99999999),
			new CharacterFilterElement(new int[1] { 1 }, 18, 50),
			new CharacterFilterElement(new int[1] { 7 }, 1, 1),
			new CharacterFilterElement(new int[1] { 9 }, 0, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(188, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 2 }, 1, 1),
			new CharacterFilterElement(new int[2] { 21, 6 }, 5000, 99999999),
			new CharacterFilterElement(new int[1] { 1 }, 18, 50),
			new CharacterFilterElement(new int[1] { 7 }, 1, 1),
			new CharacterFilterElement(new int[1] { 9 }, 0, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(189, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 2 }, 0, 0),
			new CharacterFilterElement(new int[1] { 1 }, 8, 16),
			new CharacterFilterElement(new int[1] { 9 }, 0, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(190, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 2 }, 1, 1),
			new CharacterFilterElement(new int[1] { 1 }, 8, 16),
			new CharacterFilterElement(new int[1] { 9 }, 0, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(191, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 2 }, 0, 0),
			new CharacterFilterElement(new int[1] { 1 }, 60, 80),
			new CharacterFilterElement(new int[1] { 9 }, 0, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(192, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 2 }, 1, 1),
			new CharacterFilterElement(new int[1] { 1 }, 20, 50),
			new CharacterFilterElement(new int[1] { 9 }, 0, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(193, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, 1, 1),
			new CharacterFilterElement(new int[1], 5, 5),
			new CharacterFilterElement(new int[1] { 14 }, 1, 1),
			new CharacterFilterElement(new int[1] { 5 }, 750, 750),
			new CharacterFilterElement(new int[1] { 2 }, 1, 1),
			new CharacterFilterElement(new int[1] { 1 }, 25, 25)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(194, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, 2, 2),
			new CharacterFilterElement(new int[1], 5, 5),
			new CharacterFilterElement(new int[1] { 14 }, 1, 1),
			new CharacterFilterElement(new int[1] { 5 }, 750, 750),
			new CharacterFilterElement(new int[1] { 2 }, 0, 0),
			new CharacterFilterElement(new int[1] { 1 }, 21, 21)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(195, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, 3, 3),
			new CharacterFilterElement(new int[1], 5, 5),
			new CharacterFilterElement(new int[1] { 14 }, 1, 1),
			new CharacterFilterElement(new int[1] { 5 }, 750, 750),
			new CharacterFilterElement(new int[1] { 2 }, 0, 0),
			new CharacterFilterElement(new int[1] { 1 }, 19, 19)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(196, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, 4, 4),
			new CharacterFilterElement(new int[1], 5, 5),
			new CharacterFilterElement(new int[1] { 14 }, 1, 1),
			new CharacterFilterElement(new int[1] { 5 }, 750, 750),
			new CharacterFilterElement(new int[1] { 2 }, 1, 1),
			new CharacterFilterElement(new int[1] { 1 }, 21, 21)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(197, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, 5, 5),
			new CharacterFilterElement(new int[1], 5, 5),
			new CharacterFilterElement(new int[1] { 14 }, 1, 1),
			new CharacterFilterElement(new int[1] { 5 }, 750, 750),
			new CharacterFilterElement(new int[1] { 2 }, 1, 1),
			new CharacterFilterElement(new int[1] { 1 }, 30, 30)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(198, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, 6, 6),
			new CharacterFilterElement(new int[1], 5, 5),
			new CharacterFilterElement(new int[1] { 14 }, 1, 1),
			new CharacterFilterElement(new int[1] { 5 }, 750, 750),
			new CharacterFilterElement(new int[1] { 2 }, 1, 1),
			new CharacterFilterElement(new int[1] { 1 }, 30, 30)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(199, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, 7, 7),
			new CharacterFilterElement(new int[1], 5, 5),
			new CharacterFilterElement(new int[1] { 14 }, 1, 1),
			new CharacterFilterElement(new int[1] { 5 }, 750, 750),
			new CharacterFilterElement(new int[1] { 2 }, 0, 0),
			new CharacterFilterElement(new int[1] { 1 }, 21, 21)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(200, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, 8, 8),
			new CharacterFilterElement(new int[1], 5, 5),
			new CharacterFilterElement(new int[1] { 14 }, 1, 1),
			new CharacterFilterElement(new int[1] { 5 }, 750, 750),
			new CharacterFilterElement(new int[1] { 2 }, 0, 0),
			new CharacterFilterElement(new int[1] { 1 }, 19, 19)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(201, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, 9, 9),
			new CharacterFilterElement(new int[1], 5, 5),
			new CharacterFilterElement(new int[1] { 14 }, 1, 1),
			new CharacterFilterElement(new int[1] { 5 }, 750, 750),
			new CharacterFilterElement(new int[1] { 2 }, 1, 1),
			new CharacterFilterElement(new int[1] { 1 }, 25, 25)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(202, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, 10, 10),
			new CharacterFilterElement(new int[1], 5, 5),
			new CharacterFilterElement(new int[1] { 14 }, 1, 1),
			new CharacterFilterElement(new int[1] { 5 }, 750, 750),
			new CharacterFilterElement(new int[1] { 2 }, 1, 1),
			new CharacterFilterElement(new int[1] { 1 }, 35, 35)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(203, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, 11, 11),
			new CharacterFilterElement(new int[1], 5, 5),
			new CharacterFilterElement(new int[1] { 14 }, 1, 1),
			new CharacterFilterElement(new int[1] { 5 }, 750, 750),
			new CharacterFilterElement(new int[1] { 2 }, 1, 1),
			new CharacterFilterElement(new int[1] { 1 }, 30, 30)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(204, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, 12, 12),
			new CharacterFilterElement(new int[1], 5, 5),
			new CharacterFilterElement(new int[1] { 14 }, 1, 1),
			new CharacterFilterElement(new int[1] { 5 }, 750, 750),
			new CharacterFilterElement(new int[1] { 2 }, 0, 0),
			new CharacterFilterElement(new int[1] { 1 }, 19, 19)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(205, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, 13, 13),
			new CharacterFilterElement(new int[1], 5, 5),
			new CharacterFilterElement(new int[1] { 14 }, 1, 1),
			new CharacterFilterElement(new int[1] { 5 }, 750, 750),
			new CharacterFilterElement(new int[1] { 2 }, 0, 0),
			new CharacterFilterElement(new int[1] { 1 }, 21, 21)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(206, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, 14, 14),
			new CharacterFilterElement(new int[1], 5, 5),
			new CharacterFilterElement(new int[1] { 14 }, 1, 1),
			new CharacterFilterElement(new int[1] { 5 }, 750, 750),
			new CharacterFilterElement(new int[1] { 2 }, 1, 1),
			new CharacterFilterElement(new int[1] { 1 }, 25, 25)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(207, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, 15, 15),
			new CharacterFilterElement(new int[1], 5, 5),
			new CharacterFilterElement(new int[1] { 14 }, 1, 1),
			new CharacterFilterElement(new int[1] { 5 }, 750, 750),
			new CharacterFilterElement(new int[1] { 2 }, 1, 1),
			new CharacterFilterElement(new int[1] { 1 }, 17, 17)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(208, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1], 0, 4),
			new CharacterFilterElement(new int[1] { 4 }, 8, 60),
			new CharacterFilterElement(new int[1] { 9 }, 0, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(209, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1], 0, 7),
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, 1, 1),
			new CharacterFilterElement(new int[1] { 14 }, 1, 1),
			new CharacterFilterElement(new int[1] { 4 }, 17, 90)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(210, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1], 0, 7),
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, 2, 2),
			new CharacterFilterElement(new int[1] { 14 }, 1, 1),
			new CharacterFilterElement(new int[1] { 4 }, 17, 90)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(211, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1], 0, 7),
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, 3, 3),
			new CharacterFilterElement(new int[1] { 14 }, 1, 1),
			new CharacterFilterElement(new int[1] { 4 }, 17, 90)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(212, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1], 0, 7),
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, 4, 4),
			new CharacterFilterElement(new int[1] { 14 }, 1, 1),
			new CharacterFilterElement(new int[1] { 4 }, 17, 90)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(213, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1], 0, 7),
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, 5, 5),
			new CharacterFilterElement(new int[1] { 14 }, 1, 1),
			new CharacterFilterElement(new int[1] { 4 }, 17, 90)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(214, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1], 0, 7),
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, 6, 6),
			new CharacterFilterElement(new int[1] { 14 }, 1, 1),
			new CharacterFilterElement(new int[1] { 4 }, 17, 90)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(215, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1], 0, 7),
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, 7, 7),
			new CharacterFilterElement(new int[1] { 14 }, 1, 1),
			new CharacterFilterElement(new int[1] { 4 }, 17, 90)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(216, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1], 0, 7),
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, 8, 8),
			new CharacterFilterElement(new int[1] { 14 }, 1, 1),
			new CharacterFilterElement(new int[1] { 4 }, 17, 90)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(217, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1], 0, 7),
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, 9, 9),
			new CharacterFilterElement(new int[1] { 14 }, 1, 1),
			new CharacterFilterElement(new int[1] { 4 }, 17, 90)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(218, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1], 0, 7),
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, 10, 10),
			new CharacterFilterElement(new int[1] { 14 }, 1, 1),
			new CharacterFilterElement(new int[1] { 4 }, 17, 90)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(219, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1], 0, 7),
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, 11, 11),
			new CharacterFilterElement(new int[1] { 14 }, 1, 1),
			new CharacterFilterElement(new int[1] { 4 }, 17, 90)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(220, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1], 0, 7),
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, 12, 12),
			new CharacterFilterElement(new int[1] { 14 }, 1, 1),
			new CharacterFilterElement(new int[1] { 4 }, 17, 90)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(221, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1], 0, 7),
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, 13, 13),
			new CharacterFilterElement(new int[1] { 14 }, 1, 1),
			new CharacterFilterElement(new int[1] { 4 }, 17, 90)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(222, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1], 0, 7),
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, 14, 14),
			new CharacterFilterElement(new int[1] { 14 }, 1, 1),
			new CharacterFilterElement(new int[1] { 4 }, 17, 90)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(223, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1], 0, 7),
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, 15, 15),
			new CharacterFilterElement(new int[1] { 14 }, 1, 1),
			new CharacterFilterElement(new int[1] { 4 }, 17, 90)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(224, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 9 }, 3, 3),
			new CharacterFilterElement(new int[1], 6, 6)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(225, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 34, 3 }, 0, 79),
			new CharacterFilterElement(new int[1] { 1 }, 4, 99)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(226, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 34, 4 }, 0, 79),
			new CharacterFilterElement(new int[1] { 1 }, 4, 99)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(227, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 34, 5 }, 0, 79),
			new CharacterFilterElement(new int[1] { 1 }, 4, 99)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(228, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 34, 6 }, 0, 79),
			new CharacterFilterElement(new int[1] { 1 }, 4, 99)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(229, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 34, 7 }, 0, 79),
			new CharacterFilterElement(new int[1] { 1 }, 4, 99)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(230, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 34, 8 }, 0, 79),
			new CharacterFilterElement(new int[1] { 1 }, 4, 99)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(231, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 34, 9 }, 0, 79),
			new CharacterFilterElement(new int[1] { 1 }, 4, 99)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(232, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 34, 10 }, 0, 79),
			new CharacterFilterElement(new int[1] { 1 }, 4, 99)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(233, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 34, 11 }, 0, 79),
			new CharacterFilterElement(new int[1] { 1 }, 4, 99)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(234, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 34, 12 }, 0, 79),
			new CharacterFilterElement(new int[1] { 1 }, 4, 99)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(235, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 34, 13 }, 0, 79),
			new CharacterFilterElement(new int[1] { 1 }, 4, 99)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(236, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 9 }, 0, 0),
			new CharacterFilterElement(new int[1] { 6 }, -1, -1),
			new CharacterFilterElement(new int[1] { 4 }, 16, 99),
			new CharacterFilterElement(new int[1], 6, 6)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(237, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 3, 15),
			new CharacterFilterElement(new int[1] { 2 }, 1, 1),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(238, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 3, 15),
			new CharacterFilterElement(new int[1] { 2 }, 0, 0),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(239, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 3, 15),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
	}

	private void CreateItems4()
	{
		_dataArray.Add(new CharacterFilterRulesItem(240, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 3, 15),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1] { 2 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(241, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 3, 15),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1] { 2 }, 0, 0)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(242, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 3, 15),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(243, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 16, 30),
			new CharacterFilterElement(new int[1] { 2 }, 1, 1),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(244, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 16, 30),
			new CharacterFilterElement(new int[1] { 2 }, 0, 0),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(245, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 16, 30),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(246, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 16, 30),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1] { 2 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(247, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 16, 30),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1] { 2 }, 0, 0)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(248, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 16, 30),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(249, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 30, 50),
			new CharacterFilterElement(new int[1] { 2 }, 1, 1),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(250, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 30, 50),
			new CharacterFilterElement(new int[1] { 2 }, 0, 0),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(251, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 30, 50),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(252, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 30, 50),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1] { 2 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(253, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 30, 50),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1] { 2 }, 0, 0)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(254, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 30, 50),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(255, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 60, 99),
			new CharacterFilterElement(new int[1] { 2 }, 1, 1),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(256, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 60, 99),
			new CharacterFilterElement(new int[1] { 2 }, 0, 0),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(257, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 60, 99),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(258, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 60, 99),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1] { 2 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(259, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 60, 99),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1] { 2 }, 0, 0)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(260, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 60, 99),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(261, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 16, 99),
			new CharacterFilterElement(new int[1] { 2 }, 1, 1),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(262, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 16, 99),
			new CharacterFilterElement(new int[1] { 2 }, 0, 0),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(263, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 16, 99),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(264, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 16, 99),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1] { 2 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(265, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 16, 99),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1] { 2 }, 0, 0)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(266, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 16, 99),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(267, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 3, 15),
			new CharacterFilterElement(new int[1], 6, 8),
			new CharacterFilterElement(new int[1] { 2 }, 1, 1),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(268, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 3, 15),
			new CharacterFilterElement(new int[1], 6, 8),
			new CharacterFilterElement(new int[1] { 2 }, 0, 0),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(269, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 3, 15),
			new CharacterFilterElement(new int[1], 6, 8),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(270, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 3, 15),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1], 6, 8),
			new CharacterFilterElement(new int[1] { 2 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(271, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 3, 15),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1], 6, 8),
			new CharacterFilterElement(new int[1] { 2 }, 0, 0)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(272, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 3, 15),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1], 6, 8)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(273, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 16, 30),
			new CharacterFilterElement(new int[1], 6, 8),
			new CharacterFilterElement(new int[1] { 2 }, 1, 1),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(274, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 16, 30),
			new CharacterFilterElement(new int[1], 6, 8),
			new CharacterFilterElement(new int[1] { 2 }, 0, 0),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(275, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 16, 30),
			new CharacterFilterElement(new int[1], 6, 8),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(276, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 16, 30),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1], 6, 8),
			new CharacterFilterElement(new int[1] { 2 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(277, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 16, 30),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1], 6, 8),
			new CharacterFilterElement(new int[1] { 2 }, 0, 0)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(278, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 16, 30),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1], 6, 8)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(279, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 30, 50),
			new CharacterFilterElement(new int[1], 6, 8),
			new CharacterFilterElement(new int[1] { 2 }, 1, 1),
			new CharacterFilterElement(new int[1] { 9 }, 0, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(280, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 30, 50),
			new CharacterFilterElement(new int[1], 6, 8),
			new CharacterFilterElement(new int[1] { 2 }, 0, 0),
			new CharacterFilterElement(new int[1] { 9 }, 0, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(281, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 30, 50),
			new CharacterFilterElement(new int[1], 6, 8),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(282, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 30, 50),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1], 6, 8),
			new CharacterFilterElement(new int[1] { 2 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(283, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 30, 50),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1], 6, 8),
			new CharacterFilterElement(new int[1] { 2 }, 0, 0)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(284, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 30, 50),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1], 6, 8)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(285, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 60, 99),
			new CharacterFilterElement(new int[1], 6, 8),
			new CharacterFilterElement(new int[1] { 2 }, 1, 1),
			new CharacterFilterElement(new int[1] { 9 }, 0, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(286, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 60, 99),
			new CharacterFilterElement(new int[1], 6, 8),
			new CharacterFilterElement(new int[1] { 2 }, 0, 0),
			new CharacterFilterElement(new int[1] { 9 }, 0, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(287, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 60, 99),
			new CharacterFilterElement(new int[1], 6, 8),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(288, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 60, 99),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1], 6, 8),
			new CharacterFilterElement(new int[1] { 2 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(289, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 60, 99),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1], 6, 8),
			new CharacterFilterElement(new int[1] { 2 }, 0, 0)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(290, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 60, 99),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1], 6, 8)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(291, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 16, 99),
			new CharacterFilterElement(new int[1], 6, 8),
			new CharacterFilterElement(new int[1] { 2 }, 1, 1),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(292, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 16, 99),
			new CharacterFilterElement(new int[1], 6, 8),
			new CharacterFilterElement(new int[1] { 2 }, 0, 0),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(293, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 16, 99),
			new CharacterFilterElement(new int[1], 6, 8),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(294, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 16, 99),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1], 6, 8),
			new CharacterFilterElement(new int[1] { 2 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(295, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 16, 99),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1], 6, 8),
			new CharacterFilterElement(new int[1] { 2 }, 0, 0)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(296, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 16, 99),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1], 6, 8)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(297, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 3, 15),
			new CharacterFilterElement(new int[1], 3, 5),
			new CharacterFilterElement(new int[1] { 2 }, 1, 1),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(298, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 3, 15),
			new CharacterFilterElement(new int[1], 3, 5),
			new CharacterFilterElement(new int[1] { 2 }, 0, 0),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(299, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 3, 15),
			new CharacterFilterElement(new int[1], 3, 5),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
	}

	private void CreateItems5()
	{
		_dataArray.Add(new CharacterFilterRulesItem(300, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 3, 15),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1], 3, 5),
			new CharacterFilterElement(new int[1] { 2 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(301, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 3, 15),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1], 3, 5),
			new CharacterFilterElement(new int[1] { 2 }, 0, 0)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(302, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 3, 15),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1], 3, 5)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(303, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 16, 30),
			new CharacterFilterElement(new int[1], 3, 5),
			new CharacterFilterElement(new int[1] { 2 }, 1, 1),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(304, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 16, 30),
			new CharacterFilterElement(new int[1], 3, 5),
			new CharacterFilterElement(new int[1] { 2 }, 0, 0),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(305, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 16, 30),
			new CharacterFilterElement(new int[1], 3, 5),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(306, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 16, 30),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1], 3, 5),
			new CharacterFilterElement(new int[1] { 2 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(307, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 16, 30),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1], 3, 5),
			new CharacterFilterElement(new int[1] { 2 }, 0, 0)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(308, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 16, 30),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1], 3, 5)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(309, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 30, 50),
			new CharacterFilterElement(new int[1], 3, 5),
			new CharacterFilterElement(new int[1] { 2 }, 1, 1),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(310, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 30, 50),
			new CharacterFilterElement(new int[1], 3, 5),
			new CharacterFilterElement(new int[1] { 2 }, 0, 0),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(311, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 30, 50),
			new CharacterFilterElement(new int[1], 3, 5),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(312, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 30, 50),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1], 3, 5),
			new CharacterFilterElement(new int[1] { 2 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(313, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 30, 50),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1], 3, 5),
			new CharacterFilterElement(new int[1] { 2 }, 0, 0)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(314, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 30, 50),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1], 3, 5)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(315, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 60, 99),
			new CharacterFilterElement(new int[1], 3, 5),
			new CharacterFilterElement(new int[1] { 2 }, 1, 1),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(316, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 60, 99),
			new CharacterFilterElement(new int[1], 3, 5),
			new CharacterFilterElement(new int[1] { 2 }, 0, 0),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(317, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 60, 99),
			new CharacterFilterElement(new int[1], 3, 5),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(318, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 60, 99),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1], 3, 5),
			new CharacterFilterElement(new int[1] { 2 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(319, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 60, 99),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1], 3, 5),
			new CharacterFilterElement(new int[1] { 2 }, 0, 0)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(320, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 60, 99),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1], 3, 5)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(321, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 16, 99),
			new CharacterFilterElement(new int[1], 3, 5),
			new CharacterFilterElement(new int[1] { 2 }, 1, 1),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(322, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 16, 99),
			new CharacterFilterElement(new int[1], 3, 5),
			new CharacterFilterElement(new int[1] { 2 }, 0, 0),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(323, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 16, 99),
			new CharacterFilterElement(new int[1], 3, 5),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(324, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 16, 99),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1], 3, 5),
			new CharacterFilterElement(new int[1] { 2 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(325, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 16, 99),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1], 3, 5),
			new CharacterFilterElement(new int[1] { 2 }, 0, 0)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(326, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 16, 99),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1], 3, 5)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(327, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 3, 15),
			new CharacterFilterElement(new int[1], 0, 1),
			new CharacterFilterElement(new int[1] { 2 }, 1, 1),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(328, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 3, 15),
			new CharacterFilterElement(new int[1], 0, 1),
			new CharacterFilterElement(new int[1] { 2 }, 0, 0),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(329, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 3, 15),
			new CharacterFilterElement(new int[1], 0, 1),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(330, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 3, 15),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1], 0, 1),
			new CharacterFilterElement(new int[1] { 2 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(331, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 3, 15),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1], 0, 1),
			new CharacterFilterElement(new int[1] { 2 }, 0, 0)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(332, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 3, 15),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1], 0, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(333, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 16, 30),
			new CharacterFilterElement(new int[1], 0, 1),
			new CharacterFilterElement(new int[1] { 2 }, 1, 1),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(334, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 16, 30),
			new CharacterFilterElement(new int[1], 0, 1),
			new CharacterFilterElement(new int[1] { 2 }, 0, 0),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(335, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 16, 30),
			new CharacterFilterElement(new int[1], 0, 1),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(336, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 16, 30),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1], 0, 1),
			new CharacterFilterElement(new int[1] { 2 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(337, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 16, 30),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1], 0, 1),
			new CharacterFilterElement(new int[1] { 2 }, 0, 0)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(338, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 16, 30),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1], 0, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(339, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 30, 50),
			new CharacterFilterElement(new int[1], 0, 1),
			new CharacterFilterElement(new int[1] { 2 }, 1, 1),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(340, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 30, 50),
			new CharacterFilterElement(new int[1], 0, 1),
			new CharacterFilterElement(new int[1] { 2 }, 0, 0),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(341, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 30, 50),
			new CharacterFilterElement(new int[1], 0, 1),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(342, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 30, 50),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1], 0, 1),
			new CharacterFilterElement(new int[1] { 2 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(343, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 30, 50),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1], 0, 1),
			new CharacterFilterElement(new int[1] { 2 }, 0, 0)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(344, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 30, 50),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1], 0, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(345, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 60, 99),
			new CharacterFilterElement(new int[1], 0, 1),
			new CharacterFilterElement(new int[1] { 2 }, 1, 1),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(346, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 60, 99),
			new CharacterFilterElement(new int[1], 0, 1),
			new CharacterFilterElement(new int[1] { 2 }, 0, 0),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(347, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 60, 99),
			new CharacterFilterElement(new int[1], 0, 1),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(348, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 60, 99),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1], 0, 1),
			new CharacterFilterElement(new int[1] { 2 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(349, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 60, 99),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1], 0, 1),
			new CharacterFilterElement(new int[1] { 2 }, 0, 0)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(350, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 60, 99),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1], 0, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(351, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 16, 99),
			new CharacterFilterElement(new int[1], 0, 1),
			new CharacterFilterElement(new int[1] { 2 }, 1, 1),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(352, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 16, 99),
			new CharacterFilterElement(new int[1], 0, 1),
			new CharacterFilterElement(new int[1] { 2 }, 0, 0),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(353, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 16, 99),
			new CharacterFilterElement(new int[1], 0, 1),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(354, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 16, 99),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1], 0, 1),
			new CharacterFilterElement(new int[1] { 2 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(355, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 16, 99),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1], 0, 1),
			new CharacterFilterElement(new int[1] { 2 }, 0, 0)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(356, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 16, 99),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1], 0, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(357, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 16, 99),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1], 1, 2),
			new CharacterFilterElement(new int[1] { 2 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(358, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 16, 99),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1], 1, 2),
			new CharacterFilterElement(new int[1] { 2 }, 0, 0)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(359, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 16, 99),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1], 1, 2)
		}));
	}

	private void CreateItems6()
	{
		_dataArray.Add(new CharacterFilterRulesItem(360, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 16, 99),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1], 3, 3),
			new CharacterFilterElement(new int[1] { 2 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(361, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 16, 99),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1], 3, 3),
			new CharacterFilterElement(new int[1] { 2 }, 0, 0)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(362, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 16, 99),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1], 3, 3)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(363, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 16, 99),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1], 5, 5),
			new CharacterFilterElement(new int[1] { 2 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(364, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 16, 99),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1], 5, 5),
			new CharacterFilterElement(new int[1] { 2 }, 0, 0)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(365, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 16, 99),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1], 5, 5)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(366, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 16, 99),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1], 7, 7),
			new CharacterFilterElement(new int[1] { 2 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(367, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 16, 99),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1], 7, 7),
			new CharacterFilterElement(new int[1] { 2 }, 0, 0)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(368, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 16, 99),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1], 7, 7)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(369, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 16, 99),
			new CharacterFilterElement(new int[1] { 9 }, 2, 2),
			new CharacterFilterElement(new int[1], 6, 8),
			new CharacterFilterElement(new int[1] { 2 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(370, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 16, 99),
			new CharacterFilterElement(new int[1] { 9 }, 2, 2),
			new CharacterFilterElement(new int[1], 6, 8),
			new CharacterFilterElement(new int[1] { 2 }, 0, 0)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(371, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 16, 99),
			new CharacterFilterElement(new int[1] { 9 }, 2, 2),
			new CharacterFilterElement(new int[1], 6, 8)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(372, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 16, 99),
			new CharacterFilterElement(new int[1] { 9 }, 2, 2),
			new CharacterFilterElement(new int[1], 3, 5),
			new CharacterFilterElement(new int[1] { 2 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(373, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 16, 99),
			new CharacterFilterElement(new int[1] { 9 }, 2, 2),
			new CharacterFilterElement(new int[1], 3, 5),
			new CharacterFilterElement(new int[1] { 2 }, 0, 0)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(374, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 16, 99),
			new CharacterFilterElement(new int[1] { 9 }, 2, 2),
			new CharacterFilterElement(new int[1], 3, 5)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(375, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 16, 99),
			new CharacterFilterElement(new int[1] { 9 }, 2, 2),
			new CharacterFilterElement(new int[1], 0, 2),
			new CharacterFilterElement(new int[1] { 2 }, 1, 1)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(376, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 16, 99),
			new CharacterFilterElement(new int[1] { 9 }, 2, 2),
			new CharacterFilterElement(new int[1], 0, 2),
			new CharacterFilterElement(new int[1] { 2 }, 0, 0)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(377, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 4 }, 16, 99),
			new CharacterFilterElement(new int[1] { 9 }, 2, 2),
			new CharacterFilterElement(new int[1], 0, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(378, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 19, 0 }, 1, 1),
			new CharacterFilterElement(new int[1], 1, 5),
			new CharacterFilterElement(new int[1] { 4 }, 10, 90),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(379, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 19, 1 }, 1, 1),
			new CharacterFilterElement(new int[1], 1, 5),
			new CharacterFilterElement(new int[1] { 4 }, 10, 90),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(380, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 19, 2 }, 1, 1),
			new CharacterFilterElement(new int[1], 1, 5),
			new CharacterFilterElement(new int[1] { 4 }, 10, 90),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(381, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 19, 3 }, 1, 1),
			new CharacterFilterElement(new int[1], 1, 5),
			new CharacterFilterElement(new int[1] { 4 }, 10, 90),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(382, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 19, 4 }, 1, 1),
			new CharacterFilterElement(new int[1], 1, 5),
			new CharacterFilterElement(new int[1] { 4 }, 10, 90),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(383, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 19, 5 }, 1, 1),
			new CharacterFilterElement(new int[1], 1, 5),
			new CharacterFilterElement(new int[1] { 4 }, 10, 90),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(384, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 19, 12 }, 1, 1),
			new CharacterFilterElement(new int[1], 1, 5),
			new CharacterFilterElement(new int[1] { 4 }, 10, 90),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(385, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 19, 13 }, 1, 1),
			new CharacterFilterElement(new int[1], 1, 5),
			new CharacterFilterElement(new int[1] { 4 }, 10, 90),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(386, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[2] { 19, 15 }, 1, 1),
			new CharacterFilterElement(new int[1], 1, 5),
			new CharacterFilterElement(new int[1] { 4 }, 10, 90),
			new CharacterFilterElement(new int[1] { 9 }, 1, 2)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(387, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 5 }, 800, 900),
			new CharacterFilterElement(new int[1], 6, 7),
			new CharacterFilterElement(new int[1] { 2 }, 1, 1),
			new CharacterFilterElement(new int[1] { 4 }, 18, 20),
			new CharacterFilterElement(new int[1] { 6 }, -1, -1),
			new CharacterFilterElement(new int[1] { 9 }, 1, 1),
			new CharacterFilterElement(new int[1] { 7 }, 1, 1),
			new CharacterFilterElement(new int[1] { 11 }, 0, 0)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(388, new int[0], new List<CharacterFilterElement>
		{
			new CharacterFilterElement(new int[1] { 5 }, 0, 100),
			new CharacterFilterElement(new int[1], 6, 7),
			new CharacterFilterElement(new int[1] { 2 }, 1, 1),
			new CharacterFilterElement(new int[1] { 4 }, 18, 20),
			new CharacterFilterElement(new int[1] { 6 }, -1, -1),
			new CharacterFilterElement(new int[1] { 9 }, 1, 1),
			new CharacterFilterElement(new int[1] { 7 }, 1, 1),
			new CharacterFilterElement(new int[1] { 11 }, 0, 0)
		}));
		_dataArray.Add(new CharacterFilterRulesItem(389, new int[1] { 70 }, new List<CharacterFilterElement>()));
		_dataArray.Add(new CharacterFilterRulesItem(390, new int[1] { 71 }, new List<CharacterFilterElement>()));
		_dataArray.Add(new CharacterFilterRulesItem(391, new int[1] { 72 }, new List<CharacterFilterElement>()));
		_dataArray.Add(new CharacterFilterRulesItem(392, new int[1] { 73 }, new List<CharacterFilterElement>()));
		_dataArray.Add(new CharacterFilterRulesItem(393, new int[1] { 74 }, new List<CharacterFilterElement>()));
		_dataArray.Add(new CharacterFilterRulesItem(394, new int[1] { 75 }, new List<CharacterFilterElement>()));
		_dataArray.Add(new CharacterFilterRulesItem(395, new int[1] { 76 }, new List<CharacterFilterElement>()));
		_dataArray.Add(new CharacterFilterRulesItem(396, new int[1] { 77 }, new List<CharacterFilterElement>()));
		_dataArray.Add(new CharacterFilterRulesItem(397, new int[1] { 78 }, new List<CharacterFilterElement>()));
		_dataArray.Add(new CharacterFilterRulesItem(398, new int[1] { 79 }, new List<CharacterFilterElement>()));
		_dataArray.Add(new CharacterFilterRulesItem(399, new int[1] { 80 }, new List<CharacterFilterElement>()));
		_dataArray.Add(new CharacterFilterRulesItem(400, new int[1] { 81 }, new List<CharacterFilterElement>()));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<CharacterFilterRulesItem>(401);
		CreateItems0();
		CreateItems1();
		CreateItems2();
		CreateItems3();
		CreateItems4();
		CreateItems5();
		CreateItems6();
	}
}
