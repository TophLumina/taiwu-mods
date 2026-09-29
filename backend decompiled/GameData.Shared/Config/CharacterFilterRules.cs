using System;
using System.Collections.Generic;
using Config.Common;
using Config.ConfigCells.Character;

namespace Config;

[Serializable]
public class CharacterFilterRules : ConfigData<CharacterFilterRulesItem, short>
{
	public static class DefKey
	{
		public const short BeggerFilter = 0;

		public const short Grade4Filter = 1;

		public const short Grade5Filter = 2;

		public const short BrideFilter1 = 3;

		public const short BrideFilter2 = 4;

		public const short MarriageMenFilter = 5;

		public const short AdultCharacterFilter = 6;

		public const short CompletelyInfectedFilter = 7;

		public const short WomanLocalFilter = 8;

		public const short ManLocalFilter = 9;

		public const short BeautyLocalFilter = 10;

		public const short Grade3Filter = 11;

		public const short MoodBadFilter = 12;

		public const short RandomMaleSuccessor = 13;

		public const short RandomFemaleSuccessor = 14;

		public const short WulinConferenceFilter = 15;

		public const short WulinConferencePrincipalFilter = 16;

		public const short FemaleMarriageMenFilter = 17;

		public const short FemaleMarriageMenLocalFilter = 18;

		public const short SectNormalCompetitionRolesLow = 19;

		public const short SectNormalCompetitionRolesMiddle = 20;

		public const short SectNormalCompetitionRolesHigh = 21;

		public const short SectNormalCompetitionRolesLowWithHair = 95;

		public const short SectNormalCompetitionRolesMiddleWithHair = 96;

		public const short SectNormalCompetitionRolesHighWithHair = 97;

		public const short SectPresiderRoles = 142;

		public const short SectCaptiveGoodRolesLow = 145;

		public const short SectCaptiveGoodRolesMiddle = 146;

		public const short SectCaptiveGoodRolesHigh = 147;

		public const short SectCaptiveEvilRolesLow = 148;

		public const short SectCaptiveEvilRolesMiddle = 149;

		public const short SectCaptiveEvilRolesHigh = 150;

		public const short SectCaptiveGoodTestRoles = 151;

		public const short SectCaptiveEvilTestRoles = 152;

		public const short CityRolesGoodAtFistAndPalm0 = 22;

		public const short CityRolesGoodAtFinger0 = 23;

		public const short CityRolesGoodAtLeg0 = 24;

		public const short CityRolesGoodAtThrow0 = 25;

		public const short CityRolesGoodAtSword0 = 26;

		public const short CityRolesGoodAtBlade0 = 27;

		public const short CityRolesGoodAtPolearm0 = 28;

		public const short CityRolesGoodAtSpecial0 = 29;

		public const short CityRolesGoodAtWhip0 = 30;

		public const short CityRolesGoodAtControllableShot0 = 31;

		public const short CityRolesGoodAtCombatMusic0 = 32;

		public const short CityRolesGoodAtFistAndPalm1 = 33;

		public const short CityRolesGoodAtFinger1 = 34;

		public const short CityRolesGoodAtLeg1 = 35;

		public const short CityRolesGoodAtThrow1 = 36;

		public const short CityRolesGoodAtSword1 = 37;

		public const short CityRolesGoodAtBlade1 = 38;

		public const short CityRolesGoodAtPolearm1 = 39;

		public const short CityRolesGoodAtSpecial1 = 40;

		public const short CityRolesGoodAtWhip1 = 41;

		public const short CityRolesGoodAtControllableShot1 = 42;

		public const short CityRolesGoodAtCombatMusic1 = 43;

		public const short CityRolesGoodAtFistAndPalm2 = 44;

		public const short CityRolesGoodAtFinger2 = 45;

		public const short CityRolesGoodAtLeg2 = 46;

		public const short CityRolesGoodAtThrow2 = 47;

		public const short CityRolesGoodAtSword2 = 48;

		public const short CityRolesGoodAtBlade2 = 49;

		public const short CityRolesGoodAtPolearm2 = 50;

		public const short CityRolesGoodAtSpecial2 = 51;

		public const short CityRolesGoodAtWhip2 = 52;

		public const short CityRolesGoodAtControllableShot2 = 53;

		public const short CityRolesGoodAtCombatMusic2 = 54;

		public const short CityRolesGoodAtFistAndPalm3 = 55;

		public const short CityRolesGoodAtFinger3 = 56;

		public const short CityRolesGoodAtLeg3 = 57;

		public const short CityRolesGoodAtThrow3 = 58;

		public const short CityRolesGoodAtSword3 = 59;

		public const short CityRolesGoodAtBlade3 = 60;

		public const short CityRolesGoodAtPolearm3 = 61;

		public const short CityRolesGoodAtSpecial3 = 62;

		public const short CityRolesGoodAtWhip3 = 63;

		public const short CityRolesGoodAtControllableShot3 = 64;

		public const short CityRolesGoodAtCombatMusic3 = 65;

		public const short CityRolesGoodAtFistAndPalm4 = 66;

		public const short CityRolesGoodAtFinger4 = 67;

		public const short CityRolesGoodAtLeg4 = 68;

		public const short CityRolesGoodAtThrow4 = 69;

		public const short CityRolesGoodAtSword4 = 70;

		public const short CityRolesGoodAtBlade4 = 71;

		public const short CityRolesGoodAtPolearm4 = 72;

		public const short CityRolesGoodAtSpecial4 = 73;

		public const short CityRolesGoodAtWhip4 = 74;

		public const short CityRolesGoodAtControllableShot4 = 75;

		public const short CityRolesGoodAtCombatMusic4 = 76;

		public const short CriketRichRoles = 77;

		public const short CityRolesGoodAtForging = 78;

		public const short CityRolesGoodAtWoodworking = 79;

		public const short CityRolesGoodAtWeaving = 80;

		public const short CityRolesGoodAtJade = 81;

		public const short CityRolesGoodAtMedicine = 82;

		public const short CityRolesGoodAtToxicology = 83;

		public const short CityRolesGoodAtCooking = 84;

		public const short CityLifeScoreRoles = 85;

		public const short SectMainStoryEmeiTwoPartOne = 86;

		public const short SectMainStoryEmeiTwoPartTwo = 87;

		public const short SectMainStoryRanshanGrade1 = 90;

		public const short SectMainStoryRanshanGrade2 = 91;

		public const short SectMainStoryRanshanGrade3 = 92;

		public const short SectMainStoryRanshanGrade4 = 93;

		public const short SectMainStoryRanshanGrade8 = 94;

		public const short SectMainStoryZhujianGrade4 = 98;

		public const short SectMainStoryZhujianGrade2 = 99;

		public const short SectMainStoryZhujianGrade5 = 100;

		public const short SectMainStoryZhujianGrade3 = 101;

		public const short SectMainStoryZhujianGrade8 = 102;

		public const short SectMainStoryYuanshanGrade8 = 103;

		public const short SectMainStoryYuanshanGrade7 = 104;

		public const short SectMainStoryYuanshanGrade6 = 105;

		public const short SectMainStoryYuanshanGradeMidLow = 106;

		public const short SectMainStoryYuanshanXiangshuInfected = 107;

		public const short SleepWalker = 108;

		public const short XieRenSidiHostage = 109;

		public const short XieRenSidiGuider = 236;

		public const short XiuLuoChangRighteous = 110;

		public const short VillainsValleyNPC = 111;

		public const short VillainsValleyDinner = 112;

		public const short VillainsValleyDrinker = 113;

		public const short SectLeaderShaolin = 119;

		public const short SectLeaderEmei = 120;

		public const short SectLeaderBaihua = 121;

		public const short SectLeaderWudang = 122;

		public const short SectLeaderYuanshan = 123;

		public const short SectLeaderShixiang = 124;

		public const short SectLeaderRanshan = 125;

		public const short SectLeaderXuannv = 126;

		public const short SectLeaderZhujian = 127;

		public const short SectLeaderKongsang = 128;

		public const short SectLeaderJingang = 129;

		public const short SectLeaderWuxian = 130;

		public const short SectLeaderJieqing = 131;

		public const short SectLeaderFulong = 132;

		public const short SectLeaderXuehou = 133;

		public const short MoodBadAdvFilter = 134;

		public const short MoodGoodAdvFilter = 135;

		public const short CurrentSettlementLeader = 156;

		public const short BanditsStrongholdHostage = 208;
	}

	public static class DefValue
	{
		public static CharacterFilterRulesItem BeggerFilter => Instance[(short)0];

		public static CharacterFilterRulesItem Grade4Filter => Instance[(short)1];

		public static CharacterFilterRulesItem Grade5Filter => Instance[(short)2];

		public static CharacterFilterRulesItem BrideFilter1 => Instance[(short)3];

		public static CharacterFilterRulesItem BrideFilter2 => Instance[(short)4];

		public static CharacterFilterRulesItem MarriageMenFilter => Instance[(short)5];

		public static CharacterFilterRulesItem AdultCharacterFilter => Instance[(short)6];

		public static CharacterFilterRulesItem CompletelyInfectedFilter => Instance[(short)7];

		public static CharacterFilterRulesItem WomanLocalFilter => Instance[(short)8];

		public static CharacterFilterRulesItem ManLocalFilter => Instance[(short)9];

		public static CharacterFilterRulesItem BeautyLocalFilter => Instance[(short)10];

		public static CharacterFilterRulesItem Grade3Filter => Instance[(short)11];

		public static CharacterFilterRulesItem MoodBadFilter => Instance[(short)12];

		public static CharacterFilterRulesItem RandomMaleSuccessor => Instance[(short)13];

		public static CharacterFilterRulesItem RandomFemaleSuccessor => Instance[(short)14];

		public static CharacterFilterRulesItem WulinConferenceFilter => Instance[(short)15];

		public static CharacterFilterRulesItem WulinConferencePrincipalFilter => Instance[(short)16];

		public static CharacterFilterRulesItem FemaleMarriageMenFilter => Instance[(short)17];

		public static CharacterFilterRulesItem FemaleMarriageMenLocalFilter => Instance[(short)18];

		public static CharacterFilterRulesItem SectNormalCompetitionRolesLow => Instance[(short)19];

		public static CharacterFilterRulesItem SectNormalCompetitionRolesMiddle => Instance[(short)20];

		public static CharacterFilterRulesItem SectNormalCompetitionRolesHigh => Instance[(short)21];

		public static CharacterFilterRulesItem SectNormalCompetitionRolesLowWithHair => Instance[(short)95];

		public static CharacterFilterRulesItem SectNormalCompetitionRolesMiddleWithHair => Instance[(short)96];

		public static CharacterFilterRulesItem SectNormalCompetitionRolesHighWithHair => Instance[(short)97];

		public static CharacterFilterRulesItem SectPresiderRoles => Instance[(short)142];

		public static CharacterFilterRulesItem SectCaptiveGoodRolesLow => Instance[(short)145];

		public static CharacterFilterRulesItem SectCaptiveGoodRolesMiddle => Instance[(short)146];

		public static CharacterFilterRulesItem SectCaptiveGoodRolesHigh => Instance[(short)147];

		public static CharacterFilterRulesItem SectCaptiveEvilRolesLow => Instance[(short)148];

		public static CharacterFilterRulesItem SectCaptiveEvilRolesMiddle => Instance[(short)149];

		public static CharacterFilterRulesItem SectCaptiveEvilRolesHigh => Instance[(short)150];

		public static CharacterFilterRulesItem SectCaptiveGoodTestRoles => Instance[(short)151];

		public static CharacterFilterRulesItem SectCaptiveEvilTestRoles => Instance[(short)152];

		public static CharacterFilterRulesItem CityRolesGoodAtFistAndPalm0 => Instance[(short)22];

		public static CharacterFilterRulesItem CityRolesGoodAtFinger0 => Instance[(short)23];

		public static CharacterFilterRulesItem CityRolesGoodAtLeg0 => Instance[(short)24];

		public static CharacterFilterRulesItem CityRolesGoodAtThrow0 => Instance[(short)25];

		public static CharacterFilterRulesItem CityRolesGoodAtSword0 => Instance[(short)26];

		public static CharacterFilterRulesItem CityRolesGoodAtBlade0 => Instance[(short)27];

		public static CharacterFilterRulesItem CityRolesGoodAtPolearm0 => Instance[(short)28];

		public static CharacterFilterRulesItem CityRolesGoodAtSpecial0 => Instance[(short)29];

		public static CharacterFilterRulesItem CityRolesGoodAtWhip0 => Instance[(short)30];

		public static CharacterFilterRulesItem CityRolesGoodAtControllableShot0 => Instance[(short)31];

		public static CharacterFilterRulesItem CityRolesGoodAtCombatMusic0 => Instance[(short)32];

		public static CharacterFilterRulesItem CityRolesGoodAtFistAndPalm1 => Instance[(short)33];

		public static CharacterFilterRulesItem CityRolesGoodAtFinger1 => Instance[(short)34];

		public static CharacterFilterRulesItem CityRolesGoodAtLeg1 => Instance[(short)35];

		public static CharacterFilterRulesItem CityRolesGoodAtThrow1 => Instance[(short)36];

		public static CharacterFilterRulesItem CityRolesGoodAtSword1 => Instance[(short)37];

		public static CharacterFilterRulesItem CityRolesGoodAtBlade1 => Instance[(short)38];

		public static CharacterFilterRulesItem CityRolesGoodAtPolearm1 => Instance[(short)39];

		public static CharacterFilterRulesItem CityRolesGoodAtSpecial1 => Instance[(short)40];

		public static CharacterFilterRulesItem CityRolesGoodAtWhip1 => Instance[(short)41];

		public static CharacterFilterRulesItem CityRolesGoodAtControllableShot1 => Instance[(short)42];

		public static CharacterFilterRulesItem CityRolesGoodAtCombatMusic1 => Instance[(short)43];

		public static CharacterFilterRulesItem CityRolesGoodAtFistAndPalm2 => Instance[(short)44];

		public static CharacterFilterRulesItem CityRolesGoodAtFinger2 => Instance[(short)45];

		public static CharacterFilterRulesItem CityRolesGoodAtLeg2 => Instance[(short)46];

		public static CharacterFilterRulesItem CityRolesGoodAtThrow2 => Instance[(short)47];

		public static CharacterFilterRulesItem CityRolesGoodAtSword2 => Instance[(short)48];

		public static CharacterFilterRulesItem CityRolesGoodAtBlade2 => Instance[(short)49];

		public static CharacterFilterRulesItem CityRolesGoodAtPolearm2 => Instance[(short)50];

		public static CharacterFilterRulesItem CityRolesGoodAtSpecial2 => Instance[(short)51];

		public static CharacterFilterRulesItem CityRolesGoodAtWhip2 => Instance[(short)52];

		public static CharacterFilterRulesItem CityRolesGoodAtControllableShot2 => Instance[(short)53];

		public static CharacterFilterRulesItem CityRolesGoodAtCombatMusic2 => Instance[(short)54];

		public static CharacterFilterRulesItem CityRolesGoodAtFistAndPalm3 => Instance[(short)55];

		public static CharacterFilterRulesItem CityRolesGoodAtFinger3 => Instance[(short)56];

		public static CharacterFilterRulesItem CityRolesGoodAtLeg3 => Instance[(short)57];

		public static CharacterFilterRulesItem CityRolesGoodAtThrow3 => Instance[(short)58];

		public static CharacterFilterRulesItem CityRolesGoodAtSword3 => Instance[(short)59];

		public static CharacterFilterRulesItem CityRolesGoodAtBlade3 => Instance[(short)60];

		public static CharacterFilterRulesItem CityRolesGoodAtPolearm3 => Instance[(short)61];

		public static CharacterFilterRulesItem CityRolesGoodAtSpecial3 => Instance[(short)62];

		public static CharacterFilterRulesItem CityRolesGoodAtWhip3 => Instance[(short)63];

		public static CharacterFilterRulesItem CityRolesGoodAtControllableShot3 => Instance[(short)64];

		public static CharacterFilterRulesItem CityRolesGoodAtCombatMusic3 => Instance[(short)65];

		public static CharacterFilterRulesItem CityRolesGoodAtFistAndPalm4 => Instance[(short)66];

		public static CharacterFilterRulesItem CityRolesGoodAtFinger4 => Instance[(short)67];

		public static CharacterFilterRulesItem CityRolesGoodAtLeg4 => Instance[(short)68];

		public static CharacterFilterRulesItem CityRolesGoodAtThrow4 => Instance[(short)69];

		public static CharacterFilterRulesItem CityRolesGoodAtSword4 => Instance[(short)70];

		public static CharacterFilterRulesItem CityRolesGoodAtBlade4 => Instance[(short)71];

		public static CharacterFilterRulesItem CityRolesGoodAtPolearm4 => Instance[(short)72];

		public static CharacterFilterRulesItem CityRolesGoodAtSpecial4 => Instance[(short)73];

		public static CharacterFilterRulesItem CityRolesGoodAtWhip4 => Instance[(short)74];

		public static CharacterFilterRulesItem CityRolesGoodAtControllableShot4 => Instance[(short)75];

		public static CharacterFilterRulesItem CityRolesGoodAtCombatMusic4 => Instance[(short)76];

		public static CharacterFilterRulesItem CriketRichRoles => Instance[(short)77];

		public static CharacterFilterRulesItem CityRolesGoodAtForging => Instance[(short)78];

		public static CharacterFilterRulesItem CityRolesGoodAtWoodworking => Instance[(short)79];

		public static CharacterFilterRulesItem CityRolesGoodAtWeaving => Instance[(short)80];

		public static CharacterFilterRulesItem CityRolesGoodAtJade => Instance[(short)81];

		public static CharacterFilterRulesItem CityRolesGoodAtMedicine => Instance[(short)82];

		public static CharacterFilterRulesItem CityRolesGoodAtToxicology => Instance[(short)83];

		public static CharacterFilterRulesItem CityRolesGoodAtCooking => Instance[(short)84];

		public static CharacterFilterRulesItem CityLifeScoreRoles => Instance[(short)85];

		public static CharacterFilterRulesItem SectMainStoryEmeiTwoPartOne => Instance[(short)86];

		public static CharacterFilterRulesItem SectMainStoryEmeiTwoPartTwo => Instance[(short)87];

		public static CharacterFilterRulesItem SectMainStoryRanshanGrade1 => Instance[(short)90];

		public static CharacterFilterRulesItem SectMainStoryRanshanGrade2 => Instance[(short)91];

		public static CharacterFilterRulesItem SectMainStoryRanshanGrade3 => Instance[(short)92];

		public static CharacterFilterRulesItem SectMainStoryRanshanGrade4 => Instance[(short)93];

		public static CharacterFilterRulesItem SectMainStoryRanshanGrade8 => Instance[(short)94];

		public static CharacterFilterRulesItem SectMainStoryZhujianGrade4 => Instance[(short)98];

		public static CharacterFilterRulesItem SectMainStoryZhujianGrade2 => Instance[(short)99];

		public static CharacterFilterRulesItem SectMainStoryZhujianGrade5 => Instance[(short)100];

		public static CharacterFilterRulesItem SectMainStoryZhujianGrade3 => Instance[(short)101];

		public static CharacterFilterRulesItem SectMainStoryZhujianGrade8 => Instance[(short)102];

		public static CharacterFilterRulesItem SectMainStoryYuanshanGrade8 => Instance[(short)103];

		public static CharacterFilterRulesItem SectMainStoryYuanshanGrade7 => Instance[(short)104];

		public static CharacterFilterRulesItem SectMainStoryYuanshanGrade6 => Instance[(short)105];

		public static CharacterFilterRulesItem SectMainStoryYuanshanGradeMidLow => Instance[(short)106];

		public static CharacterFilterRulesItem SectMainStoryYuanshanXiangshuInfected => Instance[(short)107];

		public static CharacterFilterRulesItem SleepWalker => Instance[(short)108];

		public static CharacterFilterRulesItem XieRenSidiHostage => Instance[(short)109];

		public static CharacterFilterRulesItem XieRenSidiGuider => Instance[(short)236];

		public static CharacterFilterRulesItem XiuLuoChangRighteous => Instance[(short)110];

		public static CharacterFilterRulesItem VillainsValleyNPC => Instance[(short)111];

		public static CharacterFilterRulesItem VillainsValleyDinner => Instance[(short)112];

		public static CharacterFilterRulesItem VillainsValleyDrinker => Instance[(short)113];

		public static CharacterFilterRulesItem SectLeaderShaolin => Instance[(short)119];

		public static CharacterFilterRulesItem SectLeaderEmei => Instance[(short)120];

		public static CharacterFilterRulesItem SectLeaderBaihua => Instance[(short)121];

		public static CharacterFilterRulesItem SectLeaderWudang => Instance[(short)122];

		public static CharacterFilterRulesItem SectLeaderYuanshan => Instance[(short)123];

		public static CharacterFilterRulesItem SectLeaderShixiang => Instance[(short)124];

		public static CharacterFilterRulesItem SectLeaderRanshan => Instance[(short)125];

		public static CharacterFilterRulesItem SectLeaderXuannv => Instance[(short)126];

		public static CharacterFilterRulesItem SectLeaderZhujian => Instance[(short)127];

		public static CharacterFilterRulesItem SectLeaderKongsang => Instance[(short)128];

		public static CharacterFilterRulesItem SectLeaderJingang => Instance[(short)129];

		public static CharacterFilterRulesItem SectLeaderWuxian => Instance[(short)130];

		public static CharacterFilterRulesItem SectLeaderJieqing => Instance[(short)131];

		public static CharacterFilterRulesItem SectLeaderFulong => Instance[(short)132];

		public static CharacterFilterRulesItem SectLeaderXuehou => Instance[(short)133];

		public static CharacterFilterRulesItem MoodBadAdvFilter => Instance[(short)134];

		public static CharacterFilterRulesItem MoodGoodAdvFilter => Instance[(short)135];

		public static CharacterFilterRulesItem CurrentSettlementLeader => Instance[(short)156];

		public static CharacterFilterRulesItem BanditsStrongholdHostage => Instance[(short)208];
	}

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
			new CharacterFilterElement(new int[1] { 9 }, 1, 2),
			new CharacterFilterElement(new int[1] { 4 }, 10, 90)
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
