using System;
using System.Collections.Generic;
using Config.Common;
using Config.ConfigCells.Character;

namespace Config;

[Serializable]
public class ShopEvent : ConfigData<ShopEventItem, short>
{
	public static class DefKey
	{
		public const short CollectResourceSuccess0 = 0;

		public const short CollectResourceSuccess1 = 1;

		public const short CollectResourceSuccess2 = 2;

		public const short CollectResourceSuccess3 = 3;

		public const short CollectResourceSuccess4 = 4;

		public const short CollectResourceSuccess5 = 5;

		public const short CollectResourceSuccess6 = 6;

		public const short CollectResourceSuccess7 = 7;

		public const short CollectResourceSuccess8 = 8;

		public const short CollectResourceSuccess9 = 9;

		public const short CollectBetterResourceSuccess0 = 10;

		public const short CollectBetterResourceSuccess1 = 11;

		public const short CollectBetterResourceSuccess2 = 12;

		public const short CollectBetterResourceSuccess3 = 13;

		public const short CollectBetterResourceSuccess4 = 14;

		public const short CollectBetterResourceSuccess5 = 15;

		public const short CollectBetterResourceSuccess6 = 16;

		public const short CollectBetterResourceSuccess7 = 17;

		public const short CollectBetterResourceSuccess8 = 18;

		public const short CollectBetterResourceSuccess9 = 19;

		public const short CollectResourceFail0 = 20;

		public const short CollectResourceFail1 = 21;

		public const short CollectResourceFail2 = 22;

		public const short CollectResourceFail3 = 23;

		public const short CollectResourceFail4 = 24;

		public const short CollectResourceFail5 = 25;

		public const short CollectResourceFail6 = 26;

		public const short CollectResourceFail7 = 27;

		public const short CollectResourceFail8 = 28;

		public const short CollectResourceFail9 = 29;

		public const short CollectBetterResourceFail0 = 30;

		public const short CollectBetterResourceFail1 = 31;

		public const short CollectBetterResourceFail2 = 32;

		public const short CollectBetterResourceFail3 = 33;

		public const short CollectBetterResourceFail4 = 34;

		public const short CollectBetterResourceFail5 = 35;

		public const short CollectBetterResourceFail6 = 36;

		public const short CollectBetterResourceFail7 = 37;

		public const short CollectBetterResourceFail8 = 38;

		public const short CollectBetterResourceFail9 = 39;

		public const short ManageCombatSkillBuildingSuccess0 = 40;

		public const short ManageCombatSkillBuildingSuccess1 = 41;

		public const short ManageCombatSkillBuildingSuccess2 = 42;

		public const short ManageCombatSkillBuildingFail0 = 43;

		public const short ManageCombatSkillBuildingFail1 = 44;

		public const short ManageCombatSkillBuildingFail2 = 45;

		public const short ManageMusicBuildingSuccess0 = 46;

		public const short ManageMusicBuildingSuccess1 = 47;

		public const short ManageMusicBuildingSuccess2 = 48;

		public const short ManageMusicBuildingFail0 = 49;

		public const short ManageMusicBuildingFail1 = 50;

		public const short ManageMusicBuildingFail2 = 51;

		public const short ManageChessBuildingSuccess0 = 52;

		public const short ManageChessBuildingSuccess1 = 53;

		public const short ManageChessBuildingSuccess2 = 54;

		public const short ManageChessBuildingFail0 = 55;

		public const short ManageChessBuildingFail1 = 56;

		public const short ManageChessBuildingFail2 = 57;

		public const short ManagePoemBuildingSuccess0 = 58;

		public const short ManagePoemBuildingSuccess1 = 59;

		public const short ManagePoemBuildingSuccess2 = 60;

		public const short ManagePoemBuildingFail0 = 61;

		public const short ManagePoemBuildingFail1 = 62;

		public const short ManagePoemBuildingFail2 = 63;

		public const short ManagePaintingBuildingSuccess0 = 64;

		public const short ManagePaintingBuildingSuccess1 = 65;

		public const short ManagePaintingBuildingSuccess2 = 66;

		public const short ManagePaintingBuildingFail0 = 67;

		public const short ManagePaintingBuildingFail1 = 68;

		public const short ManagePaintingBuildingFail2 = 69;

		public const short ManageMathBuildingSuccess0 = 70;

		public const short ManageMathBuildingSuccess1 = 71;

		public const short ManageMathBuildingSuccess2 = 72;

		public const short ManageMathBuildingFail0 = 73;

		public const short ManageMathBuildingFail1 = 74;

		public const short ManageMathBuildingFail2 = 75;

		public const short ManageAppraisalBuildingSuccess0 = 76;

		public const short ManageAppraisalBuildingSuccess1 = 77;

		public const short ManageAppraisalBuildingSuccess2 = 78;

		public const short ManageAppraisalBuildingSuccess3 = 79;

		public const short ManageAppraisalBuildingSuccess4 = 80;

		public const short ManageAppraisalBuildingSuccess5 = 81;

		public const short ManageAppraisalBuildingFail0 = 82;

		public const short ManageAppraisalBuildingFail1 = 83;

		public const short ManageAppraisalBuildingFail2 = 84;

		public const short ManageAppraisalBuildingFail3 = 85;

		public const short ManageAppraisalBuildingFail4 = 86;

		public const short ManageAppraisalBuildingFail5 = 87;

		public const short ManageForgingBuildingSuccess0 = 88;

		public const short ManageForgingBuildingSuccess1 = 89;

		public const short ManageForgingBuildingSuccess2 = 90;

		public const short ManageForgingBuildingSuccess3 = 91;

		public const short ManageForgingBuildingSuccess4 = 92;

		public const short ManageForgingBuildingFail0 = 93;

		public const short ManageForgingBuildingFail1 = 94;

		public const short ManageForgingBuildingFail2 = 95;

		public const short ManageForgingBuildingFail3 = 96;

		public const short ManageForgingBuildingFail4 = 97;

		public const short ManageWoodworkingBuildingSuccess0 = 98;

		public const short ManageWoodworkingBuildingSuccess1 = 99;

		public const short ManageWoodworkingBuildingSuccess2 = 100;

		public const short ManageWoodworkingBuildingSuccess3 = 101;

		public const short ManageWoodworkingBuildingSuccess4 = 102;

		public const short ManageWoodworkingBuildingFail0 = 103;

		public const short ManageWoodworkingBuildingFail1 = 104;

		public const short ManageWoodworkingBuildingFail2 = 105;

		public const short ManageWoodworkingBuildingFail3 = 106;

		public const short ManageWoodworkingBuildingFail4 = 107;

		public const short ManageMedicineBuildingSuccess0 = 108;

		public const short ManageMedicineBuildingSuccess1 = 109;

		public const short ManageMedicineBuildingSuccess2 = 110;

		public const short ManageMedicineBuildingSuccess3 = 111;

		public const short ManageMedicineBuildingSuccess4 = 112;

		public const short ManageMedicineBuildingFail0 = 113;

		public const short ManageMedicineBuildingFail1 = 114;

		public const short ManageMedicineBuildingFail2 = 115;

		public const short ManageMedicineBuildingFail3 = 116;

		public const short ManageMedicineBuildingFail4 = 117;

		public const short ManageToxicologyBuildingSuccess0 = 118;

		public const short ManageToxicologyBuildingSuccess1 = 119;

		public const short ManageToxicologyBuildingSuccess2 = 120;

		public const short ManageToxicologyBuildingSuccess3 = 121;

		public const short ManageToxicologyBuildingSuccess4 = 122;

		public const short ManageToxicologyBuildingFail0 = 123;

		public const short ManageToxicologyBuildingFail1 = 124;

		public const short ManageToxicologyBuildingFail2 = 125;

		public const short ManageToxicologyBuildingFail3 = 126;

		public const short ManageToxicologyBuildingFail4 = 127;

		public const short ManageWeavingBuildingSuccess0 = 128;

		public const short ManageWeavingBuildingSuccess1 = 129;

		public const short ManageWeavingBuildingSuccess2 = 130;

		public const short ManageWeavingBuildingSuccess3 = 131;

		public const short ManageWeavingBuildingSuccess4 = 132;

		public const short ManageWeavingBuildingFail0 = 133;

		public const short ManageWeavingBuildingFail1 = 134;

		public const short ManageWeavingBuildingFail2 = 135;

		public const short ManageWeavingBuildingFail3 = 136;

		public const short ManageWeavingBuildingFail4 = 137;

		public const short ManageJadeBuildingSuccess0 = 138;

		public const short ManageJadeBuildingSuccess1 = 139;

		public const short ManageJadeBuildingSuccess2 = 140;

		public const short ManageJadeBuildingSuccess3 = 141;

		public const short ManageJadeBuildingSuccess4 = 142;

		public const short ManageJadeBuildingFail0 = 143;

		public const short ManageJadeBuildingFail1 = 144;

		public const short ManageJadeBuildingFail2 = 145;

		public const short ManageJadeBuildingFail3 = 146;

		public const short ManageJadeBuildingFail4 = 147;

		public const short ManageTaoismBuildingSuccess0 = 148;

		public const short ManageTaoismBuildingSuccess1 = 149;

		public const short ManageTaoismBuildingSuccess2 = 150;

		public const short ManageTaoismBuildingFail0 = 151;

		public const short ManageTaoismBuildingFail1 = 152;

		public const short ManageTaoismBuildingFail2 = 153;

		public const short ManageBuddhismBuildingSuccess0 = 154;

		public const short ManageBuddhismBuildingSuccess1 = 155;

		public const short ManageBuddhismBuildingSuccess2 = 156;

		public const short ManageBuddhismBuildingFail0 = 157;

		public const short ManageBuddhismBuildingFail1 = 158;

		public const short ManageBuddhismBuildingFail2 = 159;

		public const short ManageCookingBuildingSuccess0 = 160;

		public const short ManageCookingBuildingSuccess1 = 161;

		public const short ManageCookingBuildingSuccess2 = 162;

		public const short ManageCookingBuildingSuccess3 = 163;

		public const short ManageCookingBuildingSuccess4 = 164;

		public const short ManageCookingBuildingFail0 = 165;

		public const short ManageCookingBuildingFail1 = 166;

		public const short ManageCookingBuildingFail2 = 167;

		public const short ManageCookingBuildingFail3 = 168;

		public const short ManageCookingBuildingFail4 = 169;

		public const short ManageEclecticBuildingSuccess0 = 170;

		public const short ManageEclecticBuildingSuccess1 = 171;

		public const short ManageEclecticBuildingSuccess2 = 172;

		public const short ManageEclecticBuildingSuccess3 = 173;

		public const short ManageEclecticBuildingSuccess4 = 174;

		public const short ManageEclecticBuildingSuccess5 = 175;

		public const short ManageEclecticBuildingSuccess6 = 176;

		public const short ManageEclecticBuildingSuccess7 = 177;

		public const short ManageEclecticBuildingFail0 = 178;

		public const short ManageEclecticBuildingFail1 = 179;

		public const short ManageEclecticBuildingFail2 = 180;

		public const short ManageEclecticBuildingFail3 = 181;

		public const short ManageEclecticBuildingFail4 = 182;

		public const short ManageEclecticBuildingFail5 = 183;

		public const short ManageEclecticBuildingFail6 = 184;

		public const short ManageEclecticBuildingFail7 = 185;

		public const short LearnLifeSkillSuccess = 186;

		public const short LearnCombatSkillSuccess = 187;

		public const short LearnLifeSkillFail = 188;

		public const short LearnCombatSkillFail = 189;

		public const short ManageLifeSkillAbilityUp = 190;

		public const short ManageCombatSkillAbilityUp = 191;

		public const short BaseDevelopLifeSkill = 192;

		public const short BaseDevelopCombatSkill = 193;

		public const short PersonalityDevelopLifeSkill = 194;

		public const short PersonalityDevelopCombatSkill = 195;

		public const short LeaderDevelopLifeSkill = 196;

		public const short LeaderDevelopCombatSkill = 197;

		public const short LearnLifeSkill = 198;

		public const short LearnCombatSkill = 199;

		public const short SalaryReceived = 200;

		public const short Banquet_1 = 201;

		public const short Banquet_2 = 202;

		public const short Banquet_3 = 203;

		public const short Banquet_4 = 204;

		public const short Banquet_5 = 205;

		public const short Banquet_6 = 206;

		public const short Banquet_7 = 207;

		public const short Banquet_8 = 208;

		public const short Banquet_9 = 209;

		public const short Banquet_10 = 210;
	}

	public static class DefValue
	{
		public static ShopEventItem CollectResourceSuccess0 => Instance[(short)0];

		public static ShopEventItem CollectResourceSuccess1 => Instance[(short)1];

		public static ShopEventItem CollectResourceSuccess2 => Instance[(short)2];

		public static ShopEventItem CollectResourceSuccess3 => Instance[(short)3];

		public static ShopEventItem CollectResourceSuccess4 => Instance[(short)4];

		public static ShopEventItem CollectResourceSuccess5 => Instance[(short)5];

		public static ShopEventItem CollectResourceSuccess6 => Instance[(short)6];

		public static ShopEventItem CollectResourceSuccess7 => Instance[(short)7];

		public static ShopEventItem CollectResourceSuccess8 => Instance[(short)8];

		public static ShopEventItem CollectResourceSuccess9 => Instance[(short)9];

		public static ShopEventItem CollectBetterResourceSuccess0 => Instance[(short)10];

		public static ShopEventItem CollectBetterResourceSuccess1 => Instance[(short)11];

		public static ShopEventItem CollectBetterResourceSuccess2 => Instance[(short)12];

		public static ShopEventItem CollectBetterResourceSuccess3 => Instance[(short)13];

		public static ShopEventItem CollectBetterResourceSuccess4 => Instance[(short)14];

		public static ShopEventItem CollectBetterResourceSuccess5 => Instance[(short)15];

		public static ShopEventItem CollectBetterResourceSuccess6 => Instance[(short)16];

		public static ShopEventItem CollectBetterResourceSuccess7 => Instance[(short)17];

		public static ShopEventItem CollectBetterResourceSuccess8 => Instance[(short)18];

		public static ShopEventItem CollectBetterResourceSuccess9 => Instance[(short)19];

		public static ShopEventItem CollectResourceFail0 => Instance[(short)20];

		public static ShopEventItem CollectResourceFail1 => Instance[(short)21];

		public static ShopEventItem CollectResourceFail2 => Instance[(short)22];

		public static ShopEventItem CollectResourceFail3 => Instance[(short)23];

		public static ShopEventItem CollectResourceFail4 => Instance[(short)24];

		public static ShopEventItem CollectResourceFail5 => Instance[(short)25];

		public static ShopEventItem CollectResourceFail6 => Instance[(short)26];

		public static ShopEventItem CollectResourceFail7 => Instance[(short)27];

		public static ShopEventItem CollectResourceFail8 => Instance[(short)28];

		public static ShopEventItem CollectResourceFail9 => Instance[(short)29];

		public static ShopEventItem CollectBetterResourceFail0 => Instance[(short)30];

		public static ShopEventItem CollectBetterResourceFail1 => Instance[(short)31];

		public static ShopEventItem CollectBetterResourceFail2 => Instance[(short)32];

		public static ShopEventItem CollectBetterResourceFail3 => Instance[(short)33];

		public static ShopEventItem CollectBetterResourceFail4 => Instance[(short)34];

		public static ShopEventItem CollectBetterResourceFail5 => Instance[(short)35];

		public static ShopEventItem CollectBetterResourceFail6 => Instance[(short)36];

		public static ShopEventItem CollectBetterResourceFail7 => Instance[(short)37];

		public static ShopEventItem CollectBetterResourceFail8 => Instance[(short)38];

		public static ShopEventItem CollectBetterResourceFail9 => Instance[(short)39];

		public static ShopEventItem ManageCombatSkillBuildingSuccess0 => Instance[(short)40];

		public static ShopEventItem ManageCombatSkillBuildingSuccess1 => Instance[(short)41];

		public static ShopEventItem ManageCombatSkillBuildingSuccess2 => Instance[(short)42];

		public static ShopEventItem ManageCombatSkillBuildingFail0 => Instance[(short)43];

		public static ShopEventItem ManageCombatSkillBuildingFail1 => Instance[(short)44];

		public static ShopEventItem ManageCombatSkillBuildingFail2 => Instance[(short)45];

		public static ShopEventItem ManageMusicBuildingSuccess0 => Instance[(short)46];

		public static ShopEventItem ManageMusicBuildingSuccess1 => Instance[(short)47];

		public static ShopEventItem ManageMusicBuildingSuccess2 => Instance[(short)48];

		public static ShopEventItem ManageMusicBuildingFail0 => Instance[(short)49];

		public static ShopEventItem ManageMusicBuildingFail1 => Instance[(short)50];

		public static ShopEventItem ManageMusicBuildingFail2 => Instance[(short)51];

		public static ShopEventItem ManageChessBuildingSuccess0 => Instance[(short)52];

		public static ShopEventItem ManageChessBuildingSuccess1 => Instance[(short)53];

		public static ShopEventItem ManageChessBuildingSuccess2 => Instance[(short)54];

		public static ShopEventItem ManageChessBuildingFail0 => Instance[(short)55];

		public static ShopEventItem ManageChessBuildingFail1 => Instance[(short)56];

		public static ShopEventItem ManageChessBuildingFail2 => Instance[(short)57];

		public static ShopEventItem ManagePoemBuildingSuccess0 => Instance[(short)58];

		public static ShopEventItem ManagePoemBuildingSuccess1 => Instance[(short)59];

		public static ShopEventItem ManagePoemBuildingSuccess2 => Instance[(short)60];

		public static ShopEventItem ManagePoemBuildingFail0 => Instance[(short)61];

		public static ShopEventItem ManagePoemBuildingFail1 => Instance[(short)62];

		public static ShopEventItem ManagePoemBuildingFail2 => Instance[(short)63];

		public static ShopEventItem ManagePaintingBuildingSuccess0 => Instance[(short)64];

		public static ShopEventItem ManagePaintingBuildingSuccess1 => Instance[(short)65];

		public static ShopEventItem ManagePaintingBuildingSuccess2 => Instance[(short)66];

		public static ShopEventItem ManagePaintingBuildingFail0 => Instance[(short)67];

		public static ShopEventItem ManagePaintingBuildingFail1 => Instance[(short)68];

		public static ShopEventItem ManagePaintingBuildingFail2 => Instance[(short)69];

		public static ShopEventItem ManageMathBuildingSuccess0 => Instance[(short)70];

		public static ShopEventItem ManageMathBuildingSuccess1 => Instance[(short)71];

		public static ShopEventItem ManageMathBuildingSuccess2 => Instance[(short)72];

		public static ShopEventItem ManageMathBuildingFail0 => Instance[(short)73];

		public static ShopEventItem ManageMathBuildingFail1 => Instance[(short)74];

		public static ShopEventItem ManageMathBuildingFail2 => Instance[(short)75];

		public static ShopEventItem ManageAppraisalBuildingSuccess0 => Instance[(short)76];

		public static ShopEventItem ManageAppraisalBuildingSuccess1 => Instance[(short)77];

		public static ShopEventItem ManageAppraisalBuildingSuccess2 => Instance[(short)78];

		public static ShopEventItem ManageAppraisalBuildingSuccess3 => Instance[(short)79];

		public static ShopEventItem ManageAppraisalBuildingSuccess4 => Instance[(short)80];

		public static ShopEventItem ManageAppraisalBuildingSuccess5 => Instance[(short)81];

		public static ShopEventItem ManageAppraisalBuildingFail0 => Instance[(short)82];

		public static ShopEventItem ManageAppraisalBuildingFail1 => Instance[(short)83];

		public static ShopEventItem ManageAppraisalBuildingFail2 => Instance[(short)84];

		public static ShopEventItem ManageAppraisalBuildingFail3 => Instance[(short)85];

		public static ShopEventItem ManageAppraisalBuildingFail4 => Instance[(short)86];

		public static ShopEventItem ManageAppraisalBuildingFail5 => Instance[(short)87];

		public static ShopEventItem ManageForgingBuildingSuccess0 => Instance[(short)88];

		public static ShopEventItem ManageForgingBuildingSuccess1 => Instance[(short)89];

		public static ShopEventItem ManageForgingBuildingSuccess2 => Instance[(short)90];

		public static ShopEventItem ManageForgingBuildingSuccess3 => Instance[(short)91];

		public static ShopEventItem ManageForgingBuildingSuccess4 => Instance[(short)92];

		public static ShopEventItem ManageForgingBuildingFail0 => Instance[(short)93];

		public static ShopEventItem ManageForgingBuildingFail1 => Instance[(short)94];

		public static ShopEventItem ManageForgingBuildingFail2 => Instance[(short)95];

		public static ShopEventItem ManageForgingBuildingFail3 => Instance[(short)96];

		public static ShopEventItem ManageForgingBuildingFail4 => Instance[(short)97];

		public static ShopEventItem ManageWoodworkingBuildingSuccess0 => Instance[(short)98];

		public static ShopEventItem ManageWoodworkingBuildingSuccess1 => Instance[(short)99];

		public static ShopEventItem ManageWoodworkingBuildingSuccess2 => Instance[(short)100];

		public static ShopEventItem ManageWoodworkingBuildingSuccess3 => Instance[(short)101];

		public static ShopEventItem ManageWoodworkingBuildingSuccess4 => Instance[(short)102];

		public static ShopEventItem ManageWoodworkingBuildingFail0 => Instance[(short)103];

		public static ShopEventItem ManageWoodworkingBuildingFail1 => Instance[(short)104];

		public static ShopEventItem ManageWoodworkingBuildingFail2 => Instance[(short)105];

		public static ShopEventItem ManageWoodworkingBuildingFail3 => Instance[(short)106];

		public static ShopEventItem ManageWoodworkingBuildingFail4 => Instance[(short)107];

		public static ShopEventItem ManageMedicineBuildingSuccess0 => Instance[(short)108];

		public static ShopEventItem ManageMedicineBuildingSuccess1 => Instance[(short)109];

		public static ShopEventItem ManageMedicineBuildingSuccess2 => Instance[(short)110];

		public static ShopEventItem ManageMedicineBuildingSuccess3 => Instance[(short)111];

		public static ShopEventItem ManageMedicineBuildingSuccess4 => Instance[(short)112];

		public static ShopEventItem ManageMedicineBuildingFail0 => Instance[(short)113];

		public static ShopEventItem ManageMedicineBuildingFail1 => Instance[(short)114];

		public static ShopEventItem ManageMedicineBuildingFail2 => Instance[(short)115];

		public static ShopEventItem ManageMedicineBuildingFail3 => Instance[(short)116];

		public static ShopEventItem ManageMedicineBuildingFail4 => Instance[(short)117];

		public static ShopEventItem ManageToxicologyBuildingSuccess0 => Instance[(short)118];

		public static ShopEventItem ManageToxicologyBuildingSuccess1 => Instance[(short)119];

		public static ShopEventItem ManageToxicologyBuildingSuccess2 => Instance[(short)120];

		public static ShopEventItem ManageToxicologyBuildingSuccess3 => Instance[(short)121];

		public static ShopEventItem ManageToxicologyBuildingSuccess4 => Instance[(short)122];

		public static ShopEventItem ManageToxicologyBuildingFail0 => Instance[(short)123];

		public static ShopEventItem ManageToxicologyBuildingFail1 => Instance[(short)124];

		public static ShopEventItem ManageToxicologyBuildingFail2 => Instance[(short)125];

		public static ShopEventItem ManageToxicologyBuildingFail3 => Instance[(short)126];

		public static ShopEventItem ManageToxicologyBuildingFail4 => Instance[(short)127];

		public static ShopEventItem ManageWeavingBuildingSuccess0 => Instance[(short)128];

		public static ShopEventItem ManageWeavingBuildingSuccess1 => Instance[(short)129];

		public static ShopEventItem ManageWeavingBuildingSuccess2 => Instance[(short)130];

		public static ShopEventItem ManageWeavingBuildingSuccess3 => Instance[(short)131];

		public static ShopEventItem ManageWeavingBuildingSuccess4 => Instance[(short)132];

		public static ShopEventItem ManageWeavingBuildingFail0 => Instance[(short)133];

		public static ShopEventItem ManageWeavingBuildingFail1 => Instance[(short)134];

		public static ShopEventItem ManageWeavingBuildingFail2 => Instance[(short)135];

		public static ShopEventItem ManageWeavingBuildingFail3 => Instance[(short)136];

		public static ShopEventItem ManageWeavingBuildingFail4 => Instance[(short)137];

		public static ShopEventItem ManageJadeBuildingSuccess0 => Instance[(short)138];

		public static ShopEventItem ManageJadeBuildingSuccess1 => Instance[(short)139];

		public static ShopEventItem ManageJadeBuildingSuccess2 => Instance[(short)140];

		public static ShopEventItem ManageJadeBuildingSuccess3 => Instance[(short)141];

		public static ShopEventItem ManageJadeBuildingSuccess4 => Instance[(short)142];

		public static ShopEventItem ManageJadeBuildingFail0 => Instance[(short)143];

		public static ShopEventItem ManageJadeBuildingFail1 => Instance[(short)144];

		public static ShopEventItem ManageJadeBuildingFail2 => Instance[(short)145];

		public static ShopEventItem ManageJadeBuildingFail3 => Instance[(short)146];

		public static ShopEventItem ManageJadeBuildingFail4 => Instance[(short)147];

		public static ShopEventItem ManageTaoismBuildingSuccess0 => Instance[(short)148];

		public static ShopEventItem ManageTaoismBuildingSuccess1 => Instance[(short)149];

		public static ShopEventItem ManageTaoismBuildingSuccess2 => Instance[(short)150];

		public static ShopEventItem ManageTaoismBuildingFail0 => Instance[(short)151];

		public static ShopEventItem ManageTaoismBuildingFail1 => Instance[(short)152];

		public static ShopEventItem ManageTaoismBuildingFail2 => Instance[(short)153];

		public static ShopEventItem ManageBuddhismBuildingSuccess0 => Instance[(short)154];

		public static ShopEventItem ManageBuddhismBuildingSuccess1 => Instance[(short)155];

		public static ShopEventItem ManageBuddhismBuildingSuccess2 => Instance[(short)156];

		public static ShopEventItem ManageBuddhismBuildingFail0 => Instance[(short)157];

		public static ShopEventItem ManageBuddhismBuildingFail1 => Instance[(short)158];

		public static ShopEventItem ManageBuddhismBuildingFail2 => Instance[(short)159];

		public static ShopEventItem ManageCookingBuildingSuccess0 => Instance[(short)160];

		public static ShopEventItem ManageCookingBuildingSuccess1 => Instance[(short)161];

		public static ShopEventItem ManageCookingBuildingSuccess2 => Instance[(short)162];

		public static ShopEventItem ManageCookingBuildingSuccess3 => Instance[(short)163];

		public static ShopEventItem ManageCookingBuildingSuccess4 => Instance[(short)164];

		public static ShopEventItem ManageCookingBuildingFail0 => Instance[(short)165];

		public static ShopEventItem ManageCookingBuildingFail1 => Instance[(short)166];

		public static ShopEventItem ManageCookingBuildingFail2 => Instance[(short)167];

		public static ShopEventItem ManageCookingBuildingFail3 => Instance[(short)168];

		public static ShopEventItem ManageCookingBuildingFail4 => Instance[(short)169];

		public static ShopEventItem ManageEclecticBuildingSuccess0 => Instance[(short)170];

		public static ShopEventItem ManageEclecticBuildingSuccess1 => Instance[(short)171];

		public static ShopEventItem ManageEclecticBuildingSuccess2 => Instance[(short)172];

		public static ShopEventItem ManageEclecticBuildingSuccess3 => Instance[(short)173];

		public static ShopEventItem ManageEclecticBuildingSuccess4 => Instance[(short)174];

		public static ShopEventItem ManageEclecticBuildingSuccess5 => Instance[(short)175];

		public static ShopEventItem ManageEclecticBuildingSuccess6 => Instance[(short)176];

		public static ShopEventItem ManageEclecticBuildingSuccess7 => Instance[(short)177];

		public static ShopEventItem ManageEclecticBuildingFail0 => Instance[(short)178];

		public static ShopEventItem ManageEclecticBuildingFail1 => Instance[(short)179];

		public static ShopEventItem ManageEclecticBuildingFail2 => Instance[(short)180];

		public static ShopEventItem ManageEclecticBuildingFail3 => Instance[(short)181];

		public static ShopEventItem ManageEclecticBuildingFail4 => Instance[(short)182];

		public static ShopEventItem ManageEclecticBuildingFail5 => Instance[(short)183];

		public static ShopEventItem ManageEclecticBuildingFail6 => Instance[(short)184];

		public static ShopEventItem ManageEclecticBuildingFail7 => Instance[(short)185];

		public static ShopEventItem LearnLifeSkillSuccess => Instance[(short)186];

		public static ShopEventItem LearnCombatSkillSuccess => Instance[(short)187];

		public static ShopEventItem LearnLifeSkillFail => Instance[(short)188];

		public static ShopEventItem LearnCombatSkillFail => Instance[(short)189];

		public static ShopEventItem ManageLifeSkillAbilityUp => Instance[(short)190];

		public static ShopEventItem ManageCombatSkillAbilityUp => Instance[(short)191];

		public static ShopEventItem BaseDevelopLifeSkill => Instance[(short)192];

		public static ShopEventItem BaseDevelopCombatSkill => Instance[(short)193];

		public static ShopEventItem PersonalityDevelopLifeSkill => Instance[(short)194];

		public static ShopEventItem PersonalityDevelopCombatSkill => Instance[(short)195];

		public static ShopEventItem LeaderDevelopLifeSkill => Instance[(short)196];

		public static ShopEventItem LeaderDevelopCombatSkill => Instance[(short)197];

		public static ShopEventItem LearnLifeSkill => Instance[(short)198];

		public static ShopEventItem LearnCombatSkill => Instance[(short)199];

		public static ShopEventItem SalaryReceived => Instance[(short)200];

		public static ShopEventItem Banquet_1 => Instance[(short)201];

		public static ShopEventItem Banquet_2 => Instance[(short)202];

		public static ShopEventItem Banquet_3 => Instance[(short)203];

		public static ShopEventItem Banquet_4 => Instance[(short)204];

		public static ShopEventItem Banquet_5 => Instance[(short)205];

		public static ShopEventItem Banquet_6 => Instance[(short)206];

		public static ShopEventItem Banquet_7 => Instance[(short)207];

		public static ShopEventItem Banquet_8 => Instance[(short)208];

		public static ShopEventItem Banquet_9 => Instance[(short)209];

		public static ShopEventItem Banquet_10 => Instance[(short)210];
	}

	public static ShopEvent Instance = new ShopEvent();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Desc", "ResourceList", "ResourceGoods", "ItemList", "BuildingCore", "ExchangeResourceGoods", "CharacterPropertyFix", "TemplateId" };

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
		_dataArray.Add(new ShopEventItem(0, LocalStringManager.GetConfig("ShopEvent_language", "Desc_0"), new string[6] { "Item", "", "", "", "", "" }, 5, new List<sbyte> { 0 }, -1, new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 56, 20, 100),
			new PresetInventoryItem("Material", 57, 10, 100),
			new PresetInventoryItem("Material", 58, 0, 100),
			new PresetInventoryItem("Material", 59, -15, 100),
			new PresetInventoryItem("Material", 77, 20, 100),
			new PresetInventoryItem("Material", 78, 10, 100),
			new PresetInventoryItem("Material", 79, 0, 100),
			new PresetInventoryItem("Material", 80, -15, 100)
		}, 100, new List<sbyte>(), 10, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(1, LocalStringManager.GetConfig("ShopEvent_language", "Desc_1"), new string[6] { "Item", "", "", "", "", "" }, 5, new List<sbyte> { 2 }, -1, new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 21, 20, 100),
			new PresetInventoryItem("Material", 22, 10, 100),
			new PresetInventoryItem("Material", 23, 0, 100),
			new PresetInventoryItem("Material", 24, -15, 100)
		}, 101, new List<sbyte>(), 10, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(2, LocalStringManager.GetConfig("ShopEvent_language", "Desc_2"), new string[6] { "Item", "", "", "", "", "" }, 5, new List<sbyte> { 1 }, -1, new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 0, 20, 100),
			new PresetInventoryItem("Material", 1, 10, 100),
			new PresetInventoryItem("Material", 2, 0, 100),
			new PresetInventoryItem("Material", 3, -15, 100)
		}, 102, new List<sbyte>(), 10, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(3, LocalStringManager.GetConfig("ShopEvent_language", "Desc_3"), new string[6] { "Item", "", "", "", "", "" }, 5, new List<sbyte> { 2, 3 }, -1, new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 14, 20, 100),
			new PresetInventoryItem("Material", 15, 10, 100),
			new PresetInventoryItem("Material", 16, 0, 100),
			new PresetInventoryItem("Material", 17, -15, 100),
			new PresetInventoryItem("Material", 28, 20, 100),
			new PresetInventoryItem("Material", 29, 10, 100),
			new PresetInventoryItem("Material", 30, 0, 100),
			new PresetInventoryItem("Material", 31, -15, 100)
		}, 103, new List<sbyte>(), 10, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(4, LocalStringManager.GetConfig("ShopEvent_language", "Desc_4"), new string[6] { "Item", "", "", "", "", "" }, 5, new List<sbyte> { 5 }, -1, new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 140, 10, 100),
			new PresetInventoryItem("Material", 141, -15, 100),
			new PresetInventoryItem("Material", 144, 10, 100),
			new PresetInventoryItem("Material", 145, -15, 100),
			new PresetInventoryItem("Material", 148, 10, 100),
			new PresetInventoryItem("Material", 149, -15, 100),
			new PresetInventoryItem("Material", 152, 10, 100),
			new PresetInventoryItem("Material", 153, -15, 100),
			new PresetInventoryItem("Material", 156, 10, 100),
			new PresetInventoryItem("Material", 157, -15, 100),
			new PresetInventoryItem("Material", 160, 10, 100),
			new PresetInventoryItem("Material", 161, -15, 100),
			new PresetInventoryItem("Material", 164, 10, 100),
			new PresetInventoryItem("Material", 165, -15, 100),
			new PresetInventoryItem("Material", 168, 10, 100),
			new PresetInventoryItem("Material", 169, -15, 100),
			new PresetInventoryItem("Material", 172, 10, 100),
			new PresetInventoryItem("Material", 173, -15, 100),
			new PresetInventoryItem("Material", 176, 10, 100),
			new PresetInventoryItem("Material", 177, -15, 100),
			new PresetInventoryItem("Material", 180, 10, 100),
			new PresetInventoryItem("Material", 181, -15, 100),
			new PresetInventoryItem("Material", 184, 10, 100),
			new PresetInventoryItem("Material", 185, -15, 100),
			new PresetInventoryItem("Material", 188, 10, 100),
			new PresetInventoryItem("Material", 189, -15, 100),
			new PresetInventoryItem("Material", 192, 10, 100),
			new PresetInventoryItem("Material", 193, -15, 100),
			new PresetInventoryItem("Material", 196, 10, 100),
			new PresetInventoryItem("Material", 197, -15, 100),
			new PresetInventoryItem("Material", 200, 10, 100),
			new PresetInventoryItem("Material", 201, -15, 100),
			new PresetInventoryItem("Material", 204, 10, 100),
			new PresetInventoryItem("Material", 205, -15, 100),
			new PresetInventoryItem("Material", 208, 10, 100),
			new PresetInventoryItem("Material", 209, -15, 100),
			new PresetInventoryItem("Material", 212, 10, 100),
			new PresetInventoryItem("Material", 213, -15, 100),
			new PresetInventoryItem("Material", 216, 10, 100),
			new PresetInventoryItem("Material", 217, -15, 100),
			new PresetInventoryItem("Material", 220, 10, 100),
			new PresetInventoryItem("Material", 221, -15, 100),
			new PresetInventoryItem("Material", 224, 10, 100),
			new PresetInventoryItem("Material", 225, -15, 100),
			new PresetInventoryItem("Material", 228, 10, 100),
			new PresetInventoryItem("Material", 229, -15, 100),
			new PresetInventoryItem("Material", 232, 10, 100),
			new PresetInventoryItem("Material", 233, -15, 100)
		}, 104, new List<sbyte>(), 10, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(5, LocalStringManager.GetConfig("ShopEvent_language", "Desc_5"), new string[6] { "Item", "", "", "", "", "" }, 5, new List<sbyte> { 5 }, -1, new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 236, 20, 100),
			new PresetInventoryItem("Material", 237, 10, 100),
			new PresetInventoryItem("Material", 238, 0, 100),
			new PresetInventoryItem("Material", 239, -15, 100),
			new PresetInventoryItem("Material", 243, 20, 100),
			new PresetInventoryItem("Material", 244, 10, 100),
			new PresetInventoryItem("Material", 245, 0, 100),
			new PresetInventoryItem("Material", 246, -15, 100),
			new PresetInventoryItem("Material", 250, 20, 100),
			new PresetInventoryItem("Material", 251, 10, 100),
			new PresetInventoryItem("Material", 252, 0, 100),
			new PresetInventoryItem("Material", 253, -15, 100),
			new PresetInventoryItem("Material", 257, 20, 100),
			new PresetInventoryItem("Material", 258, 10, 100),
			new PresetInventoryItem("Material", 259, 0, 100),
			new PresetInventoryItem("Material", 260, -15, 100),
			new PresetInventoryItem("Material", 264, 20, 100),
			new PresetInventoryItem("Material", 265, 10, 100),
			new PresetInventoryItem("Material", 266, 0, 100),
			new PresetInventoryItem("Material", 267, -15, 100),
			new PresetInventoryItem("Material", 271, 20, 100),
			new PresetInventoryItem("Material", 272, 10, 100),
			new PresetInventoryItem("Material", 273, 0, 100),
			new PresetInventoryItem("Material", 274, -15, 100)
		}, 105, new List<sbyte>(), 10, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(6, LocalStringManager.GetConfig("ShopEvent_language", "Desc_6"), new string[6] { "Item", "", "", "", "", "" }, 5, new List<sbyte> { 4 }, -1, new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 49, 20, 100),
			new PresetInventoryItem("Material", 50, 10, 100),
			new PresetInventoryItem("Material", 51, 0, 100),
			new PresetInventoryItem("Material", 52, -15, 100)
		}, 106, new List<sbyte>(), 10, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(7, LocalStringManager.GetConfig("ShopEvent_language", "Desc_7"), new string[6] { "Item", "", "", "", "", "" }, 5, new List<sbyte> { 3 }, -1, new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 35, 20, 100),
			new PresetInventoryItem("Material", 36, 10, 100),
			new PresetInventoryItem("Material", 37, 0, 100),
			new PresetInventoryItem("Material", 38, -15, 100)
		}, 107, new List<sbyte>(), 10, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(8, LocalStringManager.GetConfig("ShopEvent_language", "Desc_8"), new string[6] { "Item", "", "", "", "", "" }, 5, new List<sbyte> { 0, 1 }, -1, new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 70, 20, 100),
			new PresetInventoryItem("Material", 71, 10, 100),
			new PresetInventoryItem("Material", 72, 0, 100),
			new PresetInventoryItem("Material", 73, -15, 100),
			new PresetInventoryItem("Material", 7, 20, 100),
			new PresetInventoryItem("Material", 8, 10, 100),
			new PresetInventoryItem("Material", 9, 0, 100),
			new PresetInventoryItem("Material", 10, -15, 100)
		}, 108, new List<sbyte>(), 10, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(9, LocalStringManager.GetConfig("ShopEvent_language", "Desc_9"), new string[6] { "Item", "", "", "", "", "" }, 5, new List<sbyte> { 0, 4 }, -1, new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 63, 20, 100),
			new PresetInventoryItem("Material", 64, 10, 100),
			new PresetInventoryItem("Material", 65, 0, 100),
			new PresetInventoryItem("Material", 66, -15, 100),
			new PresetInventoryItem("Material", 42, 20, 100),
			new PresetInventoryItem("Material", 43, 10, 100),
			new PresetInventoryItem("Material", 44, 0, 100),
			new PresetInventoryItem("Material", 45, -15, 100)
		}, 109, new List<sbyte>(), 10, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(10, LocalStringManager.GetConfig("ShopEvent_language", "Desc_10"), new string[6] { "Item", "", "", "", "", "" }, 5, new List<sbyte> { 2 }, -1, new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 21, 20, 100),
			new PresetInventoryItem("Material", 22, 10, 100),
			new PresetInventoryItem("Material", 23, 0, 100),
			new PresetInventoryItem("Material", 24, -15, 100),
			new PresetInventoryItem("Material", 25, -30, 100),
			new PresetInventoryItem("Material", 26, -45, 100)
		}, 110, new List<sbyte>(), 15, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(11, LocalStringManager.GetConfig("ShopEvent_language", "Desc_11"), new string[6] { "Item", "", "", "", "", "" }, 5, new List<sbyte> { 2 }, -1, new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 14, 20, 100),
			new PresetInventoryItem("Material", 15, 10, 100),
			new PresetInventoryItem("Material", 16, 0, 100),
			new PresetInventoryItem("Material", 17, -15, 100),
			new PresetInventoryItem("Material", 18, -30, 100),
			new PresetInventoryItem("Material", 19, -45, 100)
		}, 111, new List<sbyte>(), 15, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(12, LocalStringManager.GetConfig("ShopEvent_language", "Desc_12"), new string[6] { "Item", "", "", "", "", "" }, 5, new List<sbyte> { 1 }, -1, new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 0, 20, 100),
			new PresetInventoryItem("Material", 1, 10, 100),
			new PresetInventoryItem("Material", 2, 0, 100),
			new PresetInventoryItem("Material", 3, -15, 100),
			new PresetInventoryItem("Material", 4, -30, 100),
			new PresetInventoryItem("Material", 5, -45, 100)
		}, 112, new List<sbyte>(), 15, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(13, LocalStringManager.GetConfig("ShopEvent_language", "Desc_13"), new string[6] { "Item", "", "", "", "", "" }, 5, new List<sbyte> { 1 }, -1, new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 7, 20, 100),
			new PresetInventoryItem("Material", 8, 10, 100),
			new PresetInventoryItem("Material", 9, 0, 100),
			new PresetInventoryItem("Material", 10, -15, 100),
			new PresetInventoryItem("Material", 11, -30, 100),
			new PresetInventoryItem("Material", 12, -45, 100)
		}, 113, new List<sbyte>(), 15, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(14, LocalStringManager.GetConfig("ShopEvent_language", "Desc_14"), new string[6] { "Item", "", "", "", "", "" }, 5, new List<sbyte> { 5 }, -1, new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 140, 10, 100),
			new PresetInventoryItem("Material", 144, 10, 100),
			new PresetInventoryItem("Material", 148, 10, 100),
			new PresetInventoryItem("Material", 152, 10, 100),
			new PresetInventoryItem("Material", 156, 10, 100),
			new PresetInventoryItem("Material", 160, 10, 100),
			new PresetInventoryItem("Material", 164, 10, 100),
			new PresetInventoryItem("Material", 168, 10, 100),
			new PresetInventoryItem("Material", 172, 10, 100),
			new PresetInventoryItem("Material", 176, 10, 100),
			new PresetInventoryItem("Material", 180, 10, 100),
			new PresetInventoryItem("Material", 184, 10, 100),
			new PresetInventoryItem("Material", 188, 10, 100),
			new PresetInventoryItem("Material", 192, 10, 100),
			new PresetInventoryItem("Material", 196, 10, 100),
			new PresetInventoryItem("Material", 200, 10, 100),
			new PresetInventoryItem("Material", 204, 10, 100),
			new PresetInventoryItem("Material", 208, 10, 100),
			new PresetInventoryItem("Material", 212, 10, 100),
			new PresetInventoryItem("Material", 216, 10, 100),
			new PresetInventoryItem("Material", 220, 10, 100),
			new PresetInventoryItem("Material", 224, 10, 100),
			new PresetInventoryItem("Material", 228, 10, 100),
			new PresetInventoryItem("Material", 232, 10, 100),
			new PresetInventoryItem("Material", 141, -15, 100),
			new PresetInventoryItem("Material", 145, -15, 100),
			new PresetInventoryItem("Material", 149, -15, 100),
			new PresetInventoryItem("Material", 153, -15, 100),
			new PresetInventoryItem("Material", 157, -15, 100),
			new PresetInventoryItem("Material", 161, -15, 100),
			new PresetInventoryItem("Material", 165, -15, 100),
			new PresetInventoryItem("Material", 169, -15, 100),
			new PresetInventoryItem("Material", 173, -15, 100),
			new PresetInventoryItem("Material", 177, -15, 100),
			new PresetInventoryItem("Material", 181, -15, 100),
			new PresetInventoryItem("Material", 185, -15, 100),
			new PresetInventoryItem("Material", 189, -15, 100),
			new PresetInventoryItem("Material", 193, -15, 100),
			new PresetInventoryItem("Material", 197, -15, 100),
			new PresetInventoryItem("Material", 201, -15, 100),
			new PresetInventoryItem("Material", 205, -15, 100),
			new PresetInventoryItem("Material", 209, -15, 100),
			new PresetInventoryItem("Material", 213, -15, 100),
			new PresetInventoryItem("Material", 217, -15, 100),
			new PresetInventoryItem("Material", 221, -15, 100),
			new PresetInventoryItem("Material", 225, -15, 100),
			new PresetInventoryItem("Material", 229, -15, 100),
			new PresetInventoryItem("Material", 233, -15, 100),
			new PresetInventoryItem("Material", 142, -45, 100),
			new PresetInventoryItem("Material", 146, -45, 100),
			new PresetInventoryItem("Material", 150, -45, 100),
			new PresetInventoryItem("Material", 154, -45, 100),
			new PresetInventoryItem("Material", 158, -45, 100),
			new PresetInventoryItem("Material", 162, -45, 100),
			new PresetInventoryItem("Material", 166, -45, 100),
			new PresetInventoryItem("Material", 170, -45, 100),
			new PresetInventoryItem("Material", 174, -45, 100),
			new PresetInventoryItem("Material", 178, -45, 100),
			new PresetInventoryItem("Material", 182, -45, 100),
			new PresetInventoryItem("Material", 186, -45, 100),
			new PresetInventoryItem("Material", 190, -45, 100),
			new PresetInventoryItem("Material", 194, -45, 100),
			new PresetInventoryItem("Material", 198, -45, 100),
			new PresetInventoryItem("Material", 202, -45, 100),
			new PresetInventoryItem("Material", 206, -45, 100),
			new PresetInventoryItem("Material", 210, -45, 100),
			new PresetInventoryItem("Material", 214, -45, 100),
			new PresetInventoryItem("Material", 218, -45, 100),
			new PresetInventoryItem("Material", 222, -45, 100),
			new PresetInventoryItem("Material", 226, -45, 100),
			new PresetInventoryItem("Material", 230, -45, 100),
			new PresetInventoryItem("Material", 234, -45, 100)
		}, 114, new List<sbyte>(), 15, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(15, LocalStringManager.GetConfig("ShopEvent_language", "Desc_15"), new string[6] { "Item", "", "", "", "", "" }, 5, new List<sbyte> { 5 }, -1, new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 236, 20, 100),
			new PresetInventoryItem("Material", 237, 10, 100),
			new PresetInventoryItem("Material", 238, 0, 100),
			new PresetInventoryItem("Material", 239, -15, 100),
			new PresetInventoryItem("Material", 240, -30, 100),
			new PresetInventoryItem("Material", 241, -45, 100),
			new PresetInventoryItem("Material", 243, 20, 100),
			new PresetInventoryItem("Material", 244, 10, 100),
			new PresetInventoryItem("Material", 245, 0, 100),
			new PresetInventoryItem("Material", 246, -15, 100),
			new PresetInventoryItem("Material", 247, -30, 100),
			new PresetInventoryItem("Material", 248, -45, 100),
			new PresetInventoryItem("Material", 250, 20, 100),
			new PresetInventoryItem("Material", 251, 10, 100),
			new PresetInventoryItem("Material", 252, 0, 100),
			new PresetInventoryItem("Material", 253, -15, 100),
			new PresetInventoryItem("Material", 254, -30, 100),
			new PresetInventoryItem("Material", 255, -45, 100),
			new PresetInventoryItem("Material", 257, 20, 100),
			new PresetInventoryItem("Material", 258, 10, 100),
			new PresetInventoryItem("Material", 259, 0, 100),
			new PresetInventoryItem("Material", 260, -15, 100),
			new PresetInventoryItem("Material", 261, -30, 100),
			new PresetInventoryItem("Material", 262, -45, 100),
			new PresetInventoryItem("Material", 264, 20, 100),
			new PresetInventoryItem("Material", 265, 10, 100),
			new PresetInventoryItem("Material", 266, 0, 100),
			new PresetInventoryItem("Material", 267, -15, 100),
			new PresetInventoryItem("Material", 268, -30, 100),
			new PresetInventoryItem("Material", 269, -45, 100),
			new PresetInventoryItem("Material", 271, 20, 100),
			new PresetInventoryItem("Material", 272, 10, 100),
			new PresetInventoryItem("Material", 273, 0, 100),
			new PresetInventoryItem("Material", 274, -15, 100),
			new PresetInventoryItem("Material", 275, -30, 100),
			new PresetInventoryItem("Material", 276, -45, 100)
		}, 115, new List<sbyte>(), 15, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(16, LocalStringManager.GetConfig("ShopEvent_language", "Desc_16"), new string[6] { "Item", "", "", "", "", "" }, 5, new List<sbyte> { 4 }, -1, new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 49, 20, 100),
			new PresetInventoryItem("Material", 50, 10, 100),
			new PresetInventoryItem("Material", 51, 0, 100),
			new PresetInventoryItem("Material", 52, -15, 100),
			new PresetInventoryItem("Material", 53, -30, 100),
			new PresetInventoryItem("Material", 54, -45, 100)
		}, 116, new List<sbyte>(), 15, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(17, LocalStringManager.GetConfig("ShopEvent_language", "Desc_17"), new string[6] { "Item", "", "", "", "", "" }, 5, new List<sbyte> { 4 }, -1, new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 42, 20, 100),
			new PresetInventoryItem("Material", 43, 10, 100),
			new PresetInventoryItem("Material", 44, 0, 100),
			new PresetInventoryItem("Material", 45, -15, 100),
			new PresetInventoryItem("Material", 46, -30, 100),
			new PresetInventoryItem("Material", 47, -45, 100)
		}, 117, new List<sbyte>(), 15, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(18, LocalStringManager.GetConfig("ShopEvent_language", "Desc_18"), new string[6] { "Item", "", "", "", "", "" }, 5, new List<sbyte> { 3 }, -1, new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 28, 20, 100),
			new PresetInventoryItem("Material", 29, 10, 100),
			new PresetInventoryItem("Material", 30, 0, 100),
			new PresetInventoryItem("Material", 31, -15, 100),
			new PresetInventoryItem("Material", 32, -30, 100),
			new PresetInventoryItem("Material", 33, -45, 100)
		}, 118, new List<sbyte>(), 15, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(19, LocalStringManager.GetConfig("ShopEvent_language", "Desc_19"), new string[6] { "Item", "", "", "", "", "" }, 5, new List<sbyte> { 3 }, -1, new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 35, 20, 100),
			new PresetInventoryItem("Material", 36, 10, 100),
			new PresetInventoryItem("Material", 37, 0, 100),
			new PresetInventoryItem("Material", 38, -15, 100),
			new PresetInventoryItem("Material", 39, -30, 100),
			new PresetInventoryItem("Material", 40, -45, 100)
		}, 119, new List<sbyte>(), 15, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(20, LocalStringManager.GetConfig("ShopEvent_language", "Desc_20"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(21, LocalStringManager.GetConfig("ShopEvent_language", "Desc_21"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(22, LocalStringManager.GetConfig("ShopEvent_language", "Desc_22"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(23, LocalStringManager.GetConfig("ShopEvent_language", "Desc_23"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(24, LocalStringManager.GetConfig("ShopEvent_language", "Desc_24"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(25, LocalStringManager.GetConfig("ShopEvent_language", "Desc_25"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(26, LocalStringManager.GetConfig("ShopEvent_language", "Desc_26"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(27, LocalStringManager.GetConfig("ShopEvent_language", "Desc_27"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(28, LocalStringManager.GetConfig("ShopEvent_language", "Desc_28"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(29, LocalStringManager.GetConfig("ShopEvent_language", "Desc_29"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(30, LocalStringManager.GetConfig("ShopEvent_language", "Desc_30"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(31, LocalStringManager.GetConfig("ShopEvent_language", "Desc_31"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(32, LocalStringManager.GetConfig("ShopEvent_language", "Desc_32"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(33, LocalStringManager.GetConfig("ShopEvent_language", "Desc_33"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(34, LocalStringManager.GetConfig("ShopEvent_language", "Desc_34"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(35, LocalStringManager.GetConfig("ShopEvent_language", "Desc_35"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(36, LocalStringManager.GetConfig("ShopEvent_language", "Desc_36"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(37, LocalStringManager.GetConfig("ShopEvent_language", "Desc_37"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(38, LocalStringManager.GetConfig("ShopEvent_language", "Desc_38"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(39, LocalStringManager.GetConfig("ShopEvent_language", "Desc_39"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(40, LocalStringManager.GetConfig("ShopEvent_language", "Desc_40"), new string[6] { "Resource", "Integer", "", "", "", "" }, 5, new List<sbyte>(), 6, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 10, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 10, 0));
		_dataArray.Add(new ShopEventItem(41, LocalStringManager.GetConfig("ShopEvent_language", "Desc_41"), new string[6] { "", "", "", "", "", "" }, 5, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 20, -1, new List<sbyte> { 20, 10, 0, -15, -30, -45 }, new List<sbyte> { -10, 11 }, new List<sbyte> { 65, 70, 75, 80, 85, 90 }, -1, new List<short>(), 20, 0));
		_dataArray.Add(new ShopEventItem(42, LocalStringManager.GetConfig("ShopEvent_language", "Desc_42"), new string[6] { "Resource", "Integer", "", "", "", "" }, 5, new List<sbyte>(), 7, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 15, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 15, 0));
		_dataArray.Add(new ShopEventItem(43, LocalStringManager.GetConfig("ShopEvent_language", "Desc_43"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(44, LocalStringManager.GetConfig("ShopEvent_language", "Desc_44"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(45, LocalStringManager.GetConfig("ShopEvent_language", "Desc_45"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(46, LocalStringManager.GetConfig("ShopEvent_language", "Desc_46"), new string[6] { "Resource", "Integer", "", "", "", "" }, 5, new List<sbyte>(), 6, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 10, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(47, LocalStringManager.GetConfig("ShopEvent_language", "Desc_47"), new string[6] { "", "", "", "", "", "" }, 5, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 20, 0, -1, new List<sbyte> { 20, 10, 0, -15, -30, -45 }, new List<sbyte> { -10, 11 }, new List<sbyte> { 65, 70, 75, 80, 85, 90 }, -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(48, LocalStringManager.GetConfig("ShopEvent_language", "Desc_48"), new string[6] { "Resource", "Integer", "", "", "", "" }, 5, new List<sbyte>(), 7, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 15, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(49, LocalStringManager.GetConfig("ShopEvent_language", "Desc_49"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(50, LocalStringManager.GetConfig("ShopEvent_language", "Desc_50"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(51, LocalStringManager.GetConfig("ShopEvent_language", "Desc_51"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(52, LocalStringManager.GetConfig("ShopEvent_language", "Desc_52"), new string[6] { "Resource", "Integer", "", "", "", "" }, 5, new List<sbyte>(), 6, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 10, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(53, LocalStringManager.GetConfig("ShopEvent_language", "Desc_53"), new string[6] { "", "", "", "", "", "" }, 5, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 20, 0, -1, new List<sbyte> { 20, 10, 0, -15, -30, -45 }, new List<sbyte> { -10, 11 }, new List<sbyte> { 65, 70, 75, 80, 85, 90 }, -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(54, LocalStringManager.GetConfig("ShopEvent_language", "Desc_54"), new string[6] { "Resource", "Integer", "", "", "", "" }, 5, new List<sbyte>(), 7, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 15, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(55, LocalStringManager.GetConfig("ShopEvent_language", "Desc_55"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(56, LocalStringManager.GetConfig("ShopEvent_language", "Desc_56"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(57, LocalStringManager.GetConfig("ShopEvent_language", "Desc_57"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(58, LocalStringManager.GetConfig("ShopEvent_language", "Desc_58"), new string[6] { "Resource", "Integer", "", "", "", "" }, 5, new List<sbyte>(), 6, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 10, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(59, LocalStringManager.GetConfig("ShopEvent_language", "Desc_59"), new string[6] { "", "", "", "", "", "" }, 5, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 20, 0, -1, new List<sbyte> { 20, 10, 0, -15, -30, -45 }, new List<sbyte> { -10, 11 }, new List<sbyte> { 65, 70, 75, 80, 85, 90 }, -1, new List<short>(), 0, 0));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new ShopEventItem(60, LocalStringManager.GetConfig("ShopEvent_language", "Desc_60"), new string[6] { "Resource", "Integer", "", "", "", "" }, 5, new List<sbyte>(), 7, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 15, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(61, LocalStringManager.GetConfig("ShopEvent_language", "Desc_61"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(62, LocalStringManager.GetConfig("ShopEvent_language", "Desc_62"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(63, LocalStringManager.GetConfig("ShopEvent_language", "Desc_63"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(64, LocalStringManager.GetConfig("ShopEvent_language", "Desc_64"), new string[6] { "Resource", "Integer", "", "", "", "" }, 5, new List<sbyte>(), 6, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 10, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(65, LocalStringManager.GetConfig("ShopEvent_language", "Desc_65"), new string[6] { "", "", "", "", "", "" }, 5, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 20, 0, -1, new List<sbyte> { 20, 10, 0, -15, -30, -45 }, new List<sbyte> { -10, 11 }, new List<sbyte> { 65, 70, 75, 80, 85, 90 }, -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(66, LocalStringManager.GetConfig("ShopEvent_language", "Desc_66"), new string[6] { "Resource", "Integer", "", "", "", "" }, 5, new List<sbyte>(), 7, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 15, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(67, LocalStringManager.GetConfig("ShopEvent_language", "Desc_67"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(68, LocalStringManager.GetConfig("ShopEvent_language", "Desc_68"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(69, LocalStringManager.GetConfig("ShopEvent_language", "Desc_69"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(70, LocalStringManager.GetConfig("ShopEvent_language", "Desc_70"), new string[6] { "Resource", "Integer", "", "", "", "" }, 5, new List<sbyte>(), 6, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 10, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(71, LocalStringManager.GetConfig("ShopEvent_language", "Desc_71"), new string[6] { "", "", "", "", "", "" }, 5, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 20, 0, -1, new List<sbyte> { 20, 10, 0, -15, -30, -45 }, new List<sbyte> { -10, 11 }, new List<sbyte> { 65, 70, 75, 80, 85, 90 }, -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(72, LocalStringManager.GetConfig("ShopEvent_language", "Desc_72"), new string[6] { "Resource", "Integer", "", "", "", "" }, 5, new List<sbyte>(), 7, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 15, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(73, LocalStringManager.GetConfig("ShopEvent_language", "Desc_73"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(74, LocalStringManager.GetConfig("ShopEvent_language", "Desc_74"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(75, LocalStringManager.GetConfig("ShopEvent_language", "Desc_75"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(76, LocalStringManager.GetConfig("ShopEvent_language", "Desc_76"), new string[6] { "Item", "Resource", "Integer", "", "", "" }, 5, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 10, 0, 6, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(77, LocalStringManager.GetConfig("ShopEvent_language", "Desc_77"), new string[6] { "Item", "Resource", "Integer", "", "", "" }, 5, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 10, 0, 6, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(78, LocalStringManager.GetConfig("ShopEvent_language", "Desc_78"), new string[6] { "", "", "", "", "", "" }, 5, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 20, 0, -1, new List<sbyte> { 20, 10, 0, -15, -30, -45 }, new List<sbyte> { -10, 11 }, new List<sbyte> { 65, 70, 75, 80, 85, 90 }, -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(79, LocalStringManager.GetConfig("ShopEvent_language", "Desc_79"), new string[6] { "Item", "Resource", "Integer", "", "", "" }, 5, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 15, 0, 7, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(80, LocalStringManager.GetConfig("ShopEvent_language", "Desc_80"), new string[6] { "Item", "", "", "", "", "" }, 5, new List<sbyte>(), -1, new List<PresetInventoryItem>
		{
			new PresetInventoryItem("TeaWine", 18, 40, 100),
			new PresetInventoryItem("TeaWine", 19, 30, 100),
			new PresetInventoryItem("TeaWine", 20, 20, 100),
			new PresetInventoryItem("TeaWine", 21, 10, 100),
			new PresetInventoryItem("TeaWine", 22, 0, 100),
			new PresetInventoryItem("TeaWine", 23, -15, 100),
			new PresetInventoryItem("TeaWine", 24, -30, 100),
			new PresetInventoryItem("TeaWine", 25, -45, 100),
			new PresetInventoryItem("TeaWine", 27, 40, 100),
			new PresetInventoryItem("TeaWine", 28, 30, 100),
			new PresetInventoryItem("TeaWine", 29, 20, 100),
			new PresetInventoryItem("TeaWine", 30, 10, 100),
			new PresetInventoryItem("TeaWine", 31, 0, 100),
			new PresetInventoryItem("TeaWine", 32, -15, 100),
			new PresetInventoryItem("TeaWine", 33, -30, 100),
			new PresetInventoryItem("TeaWine", 34, -45, 100)
		}, -1, new List<sbyte>(), 25, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(81, LocalStringManager.GetConfig("ShopEvent_language", "Desc_81"), new string[6] { "Item", "", "", "", "", "" }, 5, new List<sbyte>(), -1, new List<PresetInventoryItem>
		{
			new PresetInventoryItem("TeaWine", 0, 40, 100),
			new PresetInventoryItem("TeaWine", 1, 30, 100),
			new PresetInventoryItem("TeaWine", 2, 20, 100),
			new PresetInventoryItem("TeaWine", 3, 10, 100),
			new PresetInventoryItem("TeaWine", 4, 0, 100),
			new PresetInventoryItem("TeaWine", 5, -15, 100),
			new PresetInventoryItem("TeaWine", 6, -30, 100),
			new PresetInventoryItem("TeaWine", 7, -45, 100),
			new PresetInventoryItem("TeaWine", 9, 40, 100),
			new PresetInventoryItem("TeaWine", 10, 30, 100),
			new PresetInventoryItem("TeaWine", 11, 20, 100),
			new PresetInventoryItem("TeaWine", 12, 10, 100),
			new PresetInventoryItem("TeaWine", 13, 0, 100),
			new PresetInventoryItem("TeaWine", 14, -15, 100),
			new PresetInventoryItem("TeaWine", 15, -30, 100),
			new PresetInventoryItem("TeaWine", 16, -45, 100)
		}, -1, new List<sbyte>(), 25, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(82, LocalStringManager.GetConfig("ShopEvent_language", "Desc_82"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(83, LocalStringManager.GetConfig("ShopEvent_language", "Desc_83"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(84, LocalStringManager.GetConfig("ShopEvent_language", "Desc_84"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(85, LocalStringManager.GetConfig("ShopEvent_language", "Desc_85"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(86, LocalStringManager.GetConfig("ShopEvent_language", "Desc_86"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(87, LocalStringManager.GetConfig("ShopEvent_language", "Desc_87"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(88, LocalStringManager.GetConfig("ShopEvent_language", "Desc_88"), new string[6] { "Item", "Resource", "Integer", "", "", "" }, 5, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 10, 0, 6, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(89, LocalStringManager.GetConfig("ShopEvent_language", "Desc_89"), new string[6] { "", "", "", "", "", "" }, 5, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 20, 0, -1, new List<sbyte> { 20, 10, 0, -15, -30, -45 }, new List<sbyte> { -10, 11 }, new List<sbyte> { 65, 70, 75, 80, 85, 90 }, -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(90, LocalStringManager.GetConfig("ShopEvent_language", "Desc_90"), new string[6] { "Item", "Resource", "Integer", "", "", "" }, 5, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 15, 0, 7, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(91, LocalStringManager.GetConfig("ShopEvent_language", "Desc_91"), new string[6] { "Item", "", "", "", "", "" }, 5, new List<sbyte>(), -1, new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 21, 30, 100),
			new PresetInventoryItem("Material", 22, 20, 100),
			new PresetInventoryItem("Material", 23, 10, 100),
			new PresetInventoryItem("Material", 24, 0, 100),
			new PresetInventoryItem("Material", 25, -10, 100),
			new PresetInventoryItem("Material", 26, -20, 100)
		}, -1, new List<sbyte>(), 25, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(92, LocalStringManager.GetConfig("ShopEvent_language", "Desc_92"), new string[6] { "Item", "", "", "", "", "" }, 5, new List<sbyte>(), -1, new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 14, 30, 100),
			new PresetInventoryItem("Material", 15, 20, 100),
			new PresetInventoryItem("Material", 16, 10, 100),
			new PresetInventoryItem("Material", 17, 0, 100),
			new PresetInventoryItem("Material", 18, -10, 100),
			new PresetInventoryItem("Material", 19, -20, 100)
		}, -1, new List<sbyte>(), 25, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(93, LocalStringManager.GetConfig("ShopEvent_language", "Desc_93"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(94, LocalStringManager.GetConfig("ShopEvent_language", "Desc_94"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(95, LocalStringManager.GetConfig("ShopEvent_language", "Desc_95"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(96, LocalStringManager.GetConfig("ShopEvent_language", "Desc_96"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(97, LocalStringManager.GetConfig("ShopEvent_language", "Desc_97"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(98, LocalStringManager.GetConfig("ShopEvent_language", "Desc_98"), new string[6] { "Item", "Resource", "Integer", "", "", "" }, 5, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 10, 0, 6, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(99, LocalStringManager.GetConfig("ShopEvent_language", "Desc_99"), new string[6] { "", "", "", "", "", "" }, 5, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 20, 0, -1, new List<sbyte> { 20, 10, 0, -15, -30, -45 }, new List<sbyte> { -10, 11 }, new List<sbyte> { 65, 70, 75, 80, 85, 90 }, -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(100, LocalStringManager.GetConfig("ShopEvent_language", "Desc_100"), new string[6] { "Item", "Resource", "Integer", "", "", "" }, 5, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 15, 0, 7, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(101, LocalStringManager.GetConfig("ShopEvent_language", "Desc_101"), new string[6] { "Item", "", "", "", "", "" }, 5, new List<sbyte>(), -1, new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 0, 30, 100),
			new PresetInventoryItem("Material", 1, 20, 100),
			new PresetInventoryItem("Material", 2, 10, 100),
			new PresetInventoryItem("Material", 3, 0, 100),
			new PresetInventoryItem("Material", 4, -10, 100),
			new PresetInventoryItem("Material", 5, -20, 100)
		}, -1, new List<sbyte>(), 25, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(102, LocalStringManager.GetConfig("ShopEvent_language", "Desc_102"), new string[6] { "Item", "", "", "", "", "" }, 5, new List<sbyte>(), -1, new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 7, 30, 100),
			new PresetInventoryItem("Material", 8, 20, 100),
			new PresetInventoryItem("Material", 9, 10, 100),
			new PresetInventoryItem("Material", 10, 0, 100),
			new PresetInventoryItem("Material", 11, -10, 100),
			new PresetInventoryItem("Material", 12, -20, 100)
		}, -1, new List<sbyte>(), 25, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(103, LocalStringManager.GetConfig("ShopEvent_language", "Desc_103"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(104, LocalStringManager.GetConfig("ShopEvent_language", "Desc_104"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(105, LocalStringManager.GetConfig("ShopEvent_language", "Desc_105"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(106, LocalStringManager.GetConfig("ShopEvent_language", "Desc_106"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(107, LocalStringManager.GetConfig("ShopEvent_language", "Desc_107"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(108, LocalStringManager.GetConfig("ShopEvent_language", "Desc_108"), new string[6] { "Item", "Resource", "Integer", "", "", "" }, 5, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 10, 0, 6, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(109, LocalStringManager.GetConfig("ShopEvent_language", "Desc_109"), new string[6] { "", "", "", "", "", "" }, 5, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 20, 0, -1, new List<sbyte> { 20, 10, 0, -15, -30, -45 }, new List<sbyte> { -10, 11 }, new List<sbyte> { 65, 70, 75, 80, 85, 90 }, -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(110, LocalStringManager.GetConfig("ShopEvent_language", "Desc_110"), new string[6] { "Item", "Resource", "Integer", "", "", "" }, 5, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 15, 0, 7, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(111, LocalStringManager.GetConfig("ShopEvent_language", "Desc_111"), new string[6] { "Item", "", "", "", "", "" }, 5, new List<sbyte>(), -1, new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 140, 20, 100),
			new PresetInventoryItem("Material", 144, 20, 100),
			new PresetInventoryItem("Material", 148, 20, 100),
			new PresetInventoryItem("Material", 152, 20, 100),
			new PresetInventoryItem("Material", 176, 20, 100),
			new PresetInventoryItem("Material", 180, 20, 100),
			new PresetInventoryItem("Material", 184, 20, 100),
			new PresetInventoryItem("Material", 188, 20, 100),
			new PresetInventoryItem("Material", 208, 20, 100),
			new PresetInventoryItem("Material", 212, 20, 100),
			new PresetInventoryItem("Material", 220, 20, 100),
			new PresetInventoryItem("Material", 232, 20, 100),
			new PresetInventoryItem("Material", 141, 0, 100),
			new PresetInventoryItem("Material", 145, 0, 100),
			new PresetInventoryItem("Material", 149, 0, 100),
			new PresetInventoryItem("Material", 153, 0, 100),
			new PresetInventoryItem("Material", 177, 0, 100),
			new PresetInventoryItem("Material", 181, 0, 100),
			new PresetInventoryItem("Material", 185, 0, 100),
			new PresetInventoryItem("Material", 189, 0, 100),
			new PresetInventoryItem("Material", 209, 0, 100),
			new PresetInventoryItem("Material", 213, 0, 100),
			new PresetInventoryItem("Material", 221, 0, 100),
			new PresetInventoryItem("Material", 233, 0, 100),
			new PresetInventoryItem("Material", 142, -20, 100),
			new PresetInventoryItem("Material", 146, -20, 100),
			new PresetInventoryItem("Material", 150, -20, 100),
			new PresetInventoryItem("Material", 154, -20, 100),
			new PresetInventoryItem("Material", 178, -20, 100),
			new PresetInventoryItem("Material", 182, -20, 100),
			new PresetInventoryItem("Material", 186, -20, 100),
			new PresetInventoryItem("Material", 190, -20, 100),
			new PresetInventoryItem("Material", 210, -20, 100),
			new PresetInventoryItem("Material", 214, -20, 100),
			new PresetInventoryItem("Material", 222, -20, 100),
			new PresetInventoryItem("Material", 234, -20, 100)
		}, -1, new List<sbyte>(), 25, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(112, LocalStringManager.GetConfig("ShopEvent_language", "Desc_112"), new string[6] { "Item", "", "", "", "", "" }, 5, new List<sbyte>(), -1, new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 156, 20, 100),
			new PresetInventoryItem("Material", 160, 20, 100),
			new PresetInventoryItem("Material", 164, 20, 100),
			new PresetInventoryItem("Material", 168, 20, 100),
			new PresetInventoryItem("Material", 172, 20, 100),
			new PresetInventoryItem("Material", 192, 20, 100),
			new PresetInventoryItem("Material", 196, 20, 100),
			new PresetInventoryItem("Material", 200, 20, 100),
			new PresetInventoryItem("Material", 204, 20, 100),
			new PresetInventoryItem("Material", 216, 20, 100),
			new PresetInventoryItem("Material", 224, 20, 100),
			new PresetInventoryItem("Material", 228, 20, 100),
			new PresetInventoryItem("Material", 157, 0, 100),
			new PresetInventoryItem("Material", 161, 0, 100),
			new PresetInventoryItem("Material", 165, 0, 100),
			new PresetInventoryItem("Material", 169, 0, 100),
			new PresetInventoryItem("Material", 173, 0, 100),
			new PresetInventoryItem("Material", 193, 0, 100),
			new PresetInventoryItem("Material", 197, 0, 100),
			new PresetInventoryItem("Material", 201, 0, 100),
			new PresetInventoryItem("Material", 205, 0, 100),
			new PresetInventoryItem("Material", 217, 0, 100),
			new PresetInventoryItem("Material", 225, 0, 100),
			new PresetInventoryItem("Material", 229, 0, 100),
			new PresetInventoryItem("Material", 158, -20, 100),
			new PresetInventoryItem("Material", 162, -20, 100),
			new PresetInventoryItem("Material", 166, -20, 100),
			new PresetInventoryItem("Material", 170, -20, 100),
			new PresetInventoryItem("Material", 174, -20, 100),
			new PresetInventoryItem("Material", 194, -20, 100),
			new PresetInventoryItem("Material", 198, -20, 100),
			new PresetInventoryItem("Material", 202, -20, 100),
			new PresetInventoryItem("Material", 206, -20, 100),
			new PresetInventoryItem("Material", 218, -20, 100),
			new PresetInventoryItem("Material", 226, -20, 100),
			new PresetInventoryItem("Material", 230, -20, 100)
		}, -1, new List<sbyte>(), 25, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(113, LocalStringManager.GetConfig("ShopEvent_language", "Desc_113"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(114, LocalStringManager.GetConfig("ShopEvent_language", "Desc_114"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(115, LocalStringManager.GetConfig("ShopEvent_language", "Desc_115"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(116, LocalStringManager.GetConfig("ShopEvent_language", "Desc_116"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(117, LocalStringManager.GetConfig("ShopEvent_language", "Desc_117"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(118, LocalStringManager.GetConfig("ShopEvent_language", "Desc_118"), new string[6] { "Item", "Resource", "Integer", "", "", "" }, 5, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 10, 0, 6, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(119, LocalStringManager.GetConfig("ShopEvent_language", "Desc_119"), new string[6] { "", "", "", "", "", "" }, 5, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 20, 0, -1, new List<sbyte> { 20, 10, 0, -15, -30, -45 }, new List<sbyte> { -10, 11 }, new List<sbyte> { 65, 70, 75, 80, 85, 90 }, -1, new List<short>(), 0, 0));
	}

	private void CreateItems2()
	{
		_dataArray.Add(new ShopEventItem(120, LocalStringManager.GetConfig("ShopEvent_language", "Desc_120"), new string[6] { "Item", "Resource", "Integer", "", "", "" }, 5, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 15, 0, 7, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(121, LocalStringManager.GetConfig("ShopEvent_language", "Desc_121"), new string[6] { "Item", "", "", "", "", "" }, 5, new List<sbyte>(), -1, new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 236, 30, 100),
			new PresetInventoryItem("Material", 237, 20, 100),
			new PresetInventoryItem("Material", 238, 10, 100),
			new PresetInventoryItem("Material", 239, 0, 100),
			new PresetInventoryItem("Material", 240, -10, 100),
			new PresetInventoryItem("Material", 241, -20, 100),
			new PresetInventoryItem("Material", 257, 30, 100),
			new PresetInventoryItem("Material", 258, 20, 100),
			new PresetInventoryItem("Material", 259, 10, 100),
			new PresetInventoryItem("Material", 260, 0, 100),
			new PresetInventoryItem("Material", 261, -10, 100),
			new PresetInventoryItem("Material", 262, -20, 100),
			new PresetInventoryItem("Material", 264, 30, 100),
			new PresetInventoryItem("Material", 265, 20, 100),
			new PresetInventoryItem("Material", 266, 10, 100),
			new PresetInventoryItem("Material", 267, 0, 100),
			new PresetInventoryItem("Material", 268, -10, 100),
			new PresetInventoryItem("Material", 269, -20, 100)
		}, -1, new List<sbyte>(), 25, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(122, LocalStringManager.GetConfig("ShopEvent_language", "Desc_122"), new string[6] { "Item", "", "", "", "", "" }, 5, new List<sbyte>(), -1, new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 243, 30, 100),
			new PresetInventoryItem("Material", 244, 20, 100),
			new PresetInventoryItem("Material", 245, 10, 100),
			new PresetInventoryItem("Material", 246, 0, 100),
			new PresetInventoryItem("Material", 247, -10, 100),
			new PresetInventoryItem("Material", 248, -20, 100),
			new PresetInventoryItem("Material", 250, 30, 100),
			new PresetInventoryItem("Material", 251, 20, 100),
			new PresetInventoryItem("Material", 252, 10, 100),
			new PresetInventoryItem("Material", 253, 0, 100),
			new PresetInventoryItem("Material", 254, -10, 100),
			new PresetInventoryItem("Material", 255, -20, 100),
			new PresetInventoryItem("Material", 271, 30, 100),
			new PresetInventoryItem("Material", 272, 20, 100),
			new PresetInventoryItem("Material", 273, 10, 100),
			new PresetInventoryItem("Material", 274, 0, 100),
			new PresetInventoryItem("Material", 275, -10, 100),
			new PresetInventoryItem("Material", 276, -20, 100)
		}, -1, new List<sbyte>(), 25, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(123, LocalStringManager.GetConfig("ShopEvent_language", "Desc_123"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(124, LocalStringManager.GetConfig("ShopEvent_language", "Desc_124"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(125, LocalStringManager.GetConfig("ShopEvent_language", "Desc_125"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(126, LocalStringManager.GetConfig("ShopEvent_language", "Desc_126"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(127, LocalStringManager.GetConfig("ShopEvent_language", "Desc_127"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(128, LocalStringManager.GetConfig("ShopEvent_language", "Desc_128"), new string[6] { "Item", "Resource", "Integer", "", "", "" }, 5, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 10, 0, 6, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(129, LocalStringManager.GetConfig("ShopEvent_language", "Desc_129"), new string[6] { "", "", "", "", "", "" }, 5, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 20, 0, -1, new List<sbyte> { 20, 10, 0, -15, -30, -45 }, new List<sbyte> { -10, 11 }, new List<sbyte> { 65, 70, 75, 80, 85, 90 }, -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(130, LocalStringManager.GetConfig("ShopEvent_language", "Desc_130"), new string[6] { "Item", "Resource", "Integer", "", "", "" }, 5, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 15, 0, 7, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(131, LocalStringManager.GetConfig("ShopEvent_language", "Desc_131"), new string[6] { "Item", "", "", "", "", "" }, 5, new List<sbyte>(), -1, new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 49, 30, 100),
			new PresetInventoryItem("Material", 50, 20, 100),
			new PresetInventoryItem("Material", 51, 10, 100),
			new PresetInventoryItem("Material", 52, 0, 100),
			new PresetInventoryItem("Material", 53, -10, 100),
			new PresetInventoryItem("Material", 54, -20, 100)
		}, -1, new List<sbyte>(), 25, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(132, LocalStringManager.GetConfig("ShopEvent_language", "Desc_132"), new string[6] { "Item", "", "", "", "", "" }, 5, new List<sbyte>(), -1, new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 42, 30, 100),
			new PresetInventoryItem("Material", 43, 20, 100),
			new PresetInventoryItem("Material", 44, 10, 100),
			new PresetInventoryItem("Material", 45, 0, 100),
			new PresetInventoryItem("Material", 46, -10, 100),
			new PresetInventoryItem("Material", 47, -20, 100)
		}, -1, new List<sbyte>(), 25, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(133, LocalStringManager.GetConfig("ShopEvent_language", "Desc_133"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(134, LocalStringManager.GetConfig("ShopEvent_language", "Desc_134"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(135, LocalStringManager.GetConfig("ShopEvent_language", "Desc_135"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(136, LocalStringManager.GetConfig("ShopEvent_language", "Desc_136"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(137, LocalStringManager.GetConfig("ShopEvent_language", "Desc_137"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(138, LocalStringManager.GetConfig("ShopEvent_language", "Desc_138"), new string[6] { "Item", "Resource", "Integer", "", "", "" }, 5, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 10, 0, 6, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(139, LocalStringManager.GetConfig("ShopEvent_language", "Desc_139"), new string[6] { "", "", "", "", "", "" }, 5, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 20, 0, -1, new List<sbyte> { 20, 10, 0, -15, -30, -45 }, new List<sbyte> { -10, 11 }, new List<sbyte> { 65, 70, 75, 80, 85, 90 }, -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(140, LocalStringManager.GetConfig("ShopEvent_language", "Desc_140"), new string[6] { "Item", "Resource", "Integer", "", "", "" }, 5, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 15, 0, 7, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(141, LocalStringManager.GetConfig("ShopEvent_language", "Desc_141"), new string[6] { "Item", "", "", "", "", "" }, 5, new List<sbyte>(), -1, new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 35, 30, 100),
			new PresetInventoryItem("Material", 36, 20, 100),
			new PresetInventoryItem("Material", 37, 10, 100),
			new PresetInventoryItem("Material", 38, 0, 100),
			new PresetInventoryItem("Material", 39, -10, 100),
			new PresetInventoryItem("Material", 40, -20, 100)
		}, -1, new List<sbyte>(), 25, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(142, LocalStringManager.GetConfig("ShopEvent_language", "Desc_142"), new string[6] { "Item", "", "", "", "", "" }, 5, new List<sbyte>(), -1, new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 28, 30, 100),
			new PresetInventoryItem("Material", 29, 20, 100),
			new PresetInventoryItem("Material", 30, 10, 100),
			new PresetInventoryItem("Material", 31, 0, 100),
			new PresetInventoryItem("Material", 32, -10, 100),
			new PresetInventoryItem("Material", 33, -20, 100)
		}, -1, new List<sbyte>(), 25, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(143, LocalStringManager.GetConfig("ShopEvent_language", "Desc_143"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(144, LocalStringManager.GetConfig("ShopEvent_language", "Desc_144"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(145, LocalStringManager.GetConfig("ShopEvent_language", "Desc_145"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(146, LocalStringManager.GetConfig("ShopEvent_language", "Desc_146"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(147, LocalStringManager.GetConfig("ShopEvent_language", "Desc_147"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(148, LocalStringManager.GetConfig("ShopEvent_language", "Desc_148"), new string[6] { "Resource", "Integer", "", "", "", "" }, 5, new List<sbyte>(), 6, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 10, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(149, LocalStringManager.GetConfig("ShopEvent_language", "Desc_149"), new string[6] { "", "", "", "", "", "" }, 5, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 20, 0, -1, new List<sbyte> { 20, 10, 0, -15, -30, -45 }, new List<sbyte> { -10, 11 }, new List<sbyte> { 65, 70, 75, 80, 85, 90 }, -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(150, LocalStringManager.GetConfig("ShopEvent_language", "Desc_150"), new string[6] { "Resource", "Integer", "", "", "", "" }, 5, new List<sbyte>(), 7, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 15, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(151, LocalStringManager.GetConfig("ShopEvent_language", "Desc_151"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(152, LocalStringManager.GetConfig("ShopEvent_language", "Desc_152"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(153, LocalStringManager.GetConfig("ShopEvent_language", "Desc_153"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(154, LocalStringManager.GetConfig("ShopEvent_language", "Desc_154"), new string[6] { "Resource", "Integer", "", "", "", "" }, 5, new List<sbyte>(), 6, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 10, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(155, LocalStringManager.GetConfig("ShopEvent_language", "Desc_155"), new string[6] { "", "", "", "", "", "" }, 5, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 20, 0, -1, new List<sbyte> { 20, 10, 0, -15, -30, -45 }, new List<sbyte> { -10, 11 }, new List<sbyte> { 65, 70, 75, 80, 85, 90 }, -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(156, LocalStringManager.GetConfig("ShopEvent_language", "Desc_156"), new string[6] { "Resource", "Integer", "", "", "", "" }, 5, new List<sbyte>(), 7, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 15, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(157, LocalStringManager.GetConfig("ShopEvent_language", "Desc_157"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(158, LocalStringManager.GetConfig("ShopEvent_language", "Desc_158"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(159, LocalStringManager.GetConfig("ShopEvent_language", "Desc_159"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(160, LocalStringManager.GetConfig("ShopEvent_language", "Desc_160"), new string[6] { "Item", "Resource", "Integer", "", "", "" }, 5, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 10, 0, 6, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(161, LocalStringManager.GetConfig("ShopEvent_language", "Desc_161"), new string[6] { "", "", "", "", "", "" }, 5, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 20, 0, -1, new List<sbyte> { 20, 10, 0, -15, -30, -45 }, new List<sbyte> { -10, 11 }, new List<sbyte> { 65, 70, 75, 80, 85, 90 }, -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(162, LocalStringManager.GetConfig("ShopEvent_language", "Desc_162"), new string[6] { "Item", "Resource", "Integer", "", "", "" }, 5, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 15, 0, 7, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(163, LocalStringManager.GetConfig("ShopEvent_language", "Desc_163"), new string[6] { "Item", "", "", "", "", "" }, 5, new List<sbyte>(), -1, new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 70, 30, 100),
			new PresetInventoryItem("Material", 71, 20, 100),
			new PresetInventoryItem("Material", 72, 10, 100),
			new PresetInventoryItem("Material", 73, 0, 100),
			new PresetInventoryItem("Material", 74, -10, 100),
			new PresetInventoryItem("Material", 75, -20, 100),
			new PresetInventoryItem("Material", 63, 30, 100),
			new PresetInventoryItem("Material", 64, 20, 100),
			new PresetInventoryItem("Material", 65, 10, 100),
			new PresetInventoryItem("Material", 66, 0, 100),
			new PresetInventoryItem("Material", 67, -10, 100),
			new PresetInventoryItem("Material", 68, -20, 100)
		}, -1, new List<sbyte>(), 25, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(164, LocalStringManager.GetConfig("ShopEvent_language", "Desc_164"), new string[6] { "Item", "", "", "", "", "" }, 5, new List<sbyte>(), -1, new List<PresetInventoryItem>
		{
			new PresetInventoryItem("Material", 56, 30, 100),
			new PresetInventoryItem("Material", 57, 20, 100),
			new PresetInventoryItem("Material", 58, 10, 100),
			new PresetInventoryItem("Material", 59, 0, 100),
			new PresetInventoryItem("Material", 60, -10, 100),
			new PresetInventoryItem("Material", 61, -20, 100),
			new PresetInventoryItem("Material", 77, 30, 100),
			new PresetInventoryItem("Material", 78, 20, 100),
			new PresetInventoryItem("Material", 79, 10, 100),
			new PresetInventoryItem("Material", 80, 0, 100),
			new PresetInventoryItem("Material", 81, -10, 100),
			new PresetInventoryItem("Material", 82, -20, 100)
		}, -1, new List<sbyte>(), 25, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(165, LocalStringManager.GetConfig("ShopEvent_language", "Desc_165"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(166, LocalStringManager.GetConfig("ShopEvent_language", "Desc_166"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(167, LocalStringManager.GetConfig("ShopEvent_language", "Desc_167"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(168, LocalStringManager.GetConfig("ShopEvent_language", "Desc_168"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(169, LocalStringManager.GetConfig("ShopEvent_language", "Desc_169"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(170, LocalStringManager.GetConfig("ShopEvent_language", "Desc_170"), new string[6] { "Item", "Resource", "Integer", "", "", "" }, 5, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 10, 0, 6, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(171, LocalStringManager.GetConfig("ShopEvent_language", "Desc_171"), new string[6] { "Resource", "Integer", "", "", "", "" }, 5, new List<sbyte>(), 6, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 10, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(172, LocalStringManager.GetConfig("ShopEvent_language", "Desc_172"), new string[6] { "Resource", "Integer", "", "", "", "" }, 5, new List<sbyte>(), 6, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 10, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(173, LocalStringManager.GetConfig("ShopEvent_language", "Desc_173"), new string[6] { "", "", "", "", "", "" }, 5, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 20, 0, -1, new List<sbyte> { 20, 10, 0, -15, -30, -45 }, new List<sbyte> { -100, 101 }, new List<sbyte>(), 101, new List<short> { 400, 500, 600, 700, 800, 900 }, 0, 0));
		_dataArray.Add(new ShopEventItem(174, LocalStringManager.GetConfig("ShopEvent_language", "Desc_174"), new string[6] { "", "", "", "", "", "" }, 5, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 20, 0, -1, new List<sbyte> { 20, 10, 0, -15, -30, -45 }, new List<sbyte> { -10, 11 }, new List<sbyte> { 65, 70, 75, 80, 85, 90 }, -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(175, LocalStringManager.GetConfig("ShopEvent_language", "Desc_175"), new string[6] { "Resource", "Integer", "", "", "", "" }, 5, new List<sbyte>(), 7, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 15, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(176, LocalStringManager.GetConfig("ShopEvent_language", "Desc_176"), new string[6] { "Item", "Resource", "Integer", "", "", "" }, 5, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte> { 40, 30, 20, 10, 0, -15, -30, -45, -60 }, 25, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(177, LocalStringManager.GetConfig("ShopEvent_language", "Desc_177"), new string[6] { "Resource", "Integer", "", "", "", "" }, 5, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 25, 0, -1, new List<sbyte> { 40, 30, 20, 10, 0, -15, -30, -45, -60 }, new List<sbyte> { -10, 11 }, new List<sbyte> { 65, 70, 75, 80, 85, 90, 95, 100, 105 }, -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(178, LocalStringManager.GetConfig("ShopEvent_language", "Desc_178"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(179, LocalStringManager.GetConfig("ShopEvent_language", "Desc_179"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
	}

	private void CreateItems3()
	{
		_dataArray.Add(new ShopEventItem(180, LocalStringManager.GetConfig("ShopEvent_language", "Desc_180"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(181, LocalStringManager.GetConfig("ShopEvent_language", "Desc_181"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(182, LocalStringManager.GetConfig("ShopEvent_language", "Desc_182"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(183, LocalStringManager.GetConfig("ShopEvent_language", "Desc_183"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(184, LocalStringManager.GetConfig("ShopEvent_language", "Desc_184"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(185, LocalStringManager.GetConfig("ShopEvent_language", "Desc_185"), new string[6] { "", "", "", "", "", "" }, 25, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(186, LocalStringManager.GetConfig("ShopEvent_language", "Desc_186"), new string[6] { "Character", "Item", "", "", "", "" }, 0, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 1, 0));
		_dataArray.Add(new ShopEventItem(187, LocalStringManager.GetConfig("ShopEvent_language", "Desc_187"), new string[6] { "Character", "Item", "", "", "", "" }, 0, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 1, 0));
		_dataArray.Add(new ShopEventItem(188, LocalStringManager.GetConfig("ShopEvent_language", "Desc_188"), new string[6] { "Character", "LifeSkillType", "", "", "", "" }, 0, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 1, 0));
		_dataArray.Add(new ShopEventItem(189, LocalStringManager.GetConfig("ShopEvent_language", "Desc_189"), new string[6] { "Character", "CombatSkillType", "", "", "", "" }, 0, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 1, 0));
		_dataArray.Add(new ShopEventItem(190, LocalStringManager.GetConfig("ShopEvent_language", "Desc_190"), new string[6] { "Character", "LifeSkillType", "", "", "", "" }, 0, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 1, 0));
		_dataArray.Add(new ShopEventItem(191, LocalStringManager.GetConfig("ShopEvent_language", "Desc_191"), new string[6] { "Character", "CombatSkillType", "", "", "", "" }, 0, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 1, 0));
		_dataArray.Add(new ShopEventItem(192, LocalStringManager.GetConfig("ShopEvent_language", "Desc_192"), new string[6] { "Character", "LifeSkillType", "", "", "", "" }, 0, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 1, 0));
		_dataArray.Add(new ShopEventItem(193, LocalStringManager.GetConfig("ShopEvent_language", "Desc_193"), new string[6] { "Character", "CombatSkillType", "", "", "", "" }, 0, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 1, 0));
		_dataArray.Add(new ShopEventItem(194, LocalStringManager.GetConfig("ShopEvent_language", "Desc_194"), new string[6] { "Character", "LifeSkillType", "", "", "", "" }, 0, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 1, 0));
		_dataArray.Add(new ShopEventItem(195, LocalStringManager.GetConfig("ShopEvent_language", "Desc_195"), new string[6] { "Character", "CombatSkillType", "", "", "", "" }, 0, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 1, 0));
		_dataArray.Add(new ShopEventItem(196, LocalStringManager.GetConfig("ShopEvent_language", "Desc_196"), new string[6] { "Character", "Character", "LifeSkillType", "", "", "" }, 0, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 1, 0));
		_dataArray.Add(new ShopEventItem(197, LocalStringManager.GetConfig("ShopEvent_language", "Desc_197"), new string[6] { "Character", "Character", "CombatSkillType", "", "", "" }, 0, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 1, 0));
		_dataArray.Add(new ShopEventItem(198, LocalStringManager.GetConfig("ShopEvent_language", "Desc_198"), new string[6] { "Character", "Item", "Integer", "", "", "" }, 0, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 1, 0));
		_dataArray.Add(new ShopEventItem(199, LocalStringManager.GetConfig("ShopEvent_language", "Desc_199"), new string[6] { "Character", "Item", "Integer", "", "", "" }, 0, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 1, 0));
		_dataArray.Add(new ShopEventItem(200, LocalStringManager.GetConfig("ShopEvent_language", "Desc_200"), new string[6] { "Character", "Integer", "Resource", "", "", "" }, 0, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 0));
		_dataArray.Add(new ShopEventItem(201, LocalStringManager.GetConfig("ShopEvent_language", "Desc_201"), new string[6] { "Character", "Item", "Item", "", "", "" }, 0, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 3));
		_dataArray.Add(new ShopEventItem(202, LocalStringManager.GetConfig("ShopEvent_language", "Desc_202"), new string[6] { "Character", "Item", "Item", "", "", "" }, 0, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 5));
		_dataArray.Add(new ShopEventItem(203, LocalStringManager.GetConfig("ShopEvent_language", "Desc_203"), new string[6] { "Character", "Item", "Item", "Feast", "", "" }, 0, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 8));
		_dataArray.Add(new ShopEventItem(204, LocalStringManager.GetConfig("ShopEvent_language", "Desc_204"), new string[6] { "Character", "Item", "Item", "Feast", "", "" }, 0, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 9));
		_dataArray.Add(new ShopEventItem(205, LocalStringManager.GetConfig("ShopEvent_language", "Desc_205"), new string[6] { "Character", "Item", "Item", "", "", "" }, 0, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 2));
		_dataArray.Add(new ShopEventItem(206, LocalStringManager.GetConfig("ShopEvent_language", "Desc_206"), new string[6] { "Character", "Item", "Item", "", "", "" }, 0, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 4));
		_dataArray.Add(new ShopEventItem(207, LocalStringManager.GetConfig("ShopEvent_language", "Desc_207"), new string[6] { "Character", "Item", "Item", "Feast", "", "" }, 0, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 6));
		_dataArray.Add(new ShopEventItem(208, LocalStringManager.GetConfig("ShopEvent_language", "Desc_208"), new string[6] { "Character", "Item", "Item", "Feast", "", "" }, 0, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 7));
		_dataArray.Add(new ShopEventItem(209, LocalStringManager.GetConfig("ShopEvent_language", "Desc_209"), new string[6] { "Character", "", "", "", "", "" }, 0, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 1));
		_dataArray.Add(new ShopEventItem(210, LocalStringManager.GetConfig("ShopEvent_language", "Desc_210"), new string[6] { "Character", "", "", "", "", "" }, 0, new List<sbyte>(), -1, new List<PresetInventoryItem>(), -1, new List<sbyte>(), 0, 0, -1, new List<sbyte>(), new List<sbyte>(), new List<sbyte>(), -1, new List<short>(), 0, 10));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<ShopEventItem>(211);
		CreateItems0();
		CreateItems1();
		CreateItems2();
		CreateItems3();
	}
}
