using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class Animal : ConfigData<AnimalItem, sbyte>
{
	public static class DefKey
	{
		public const sbyte bear = 0;

		public const sbyte bull = 1;

		public const sbyte eagle = 2;

		public const sbyte jaguar = 3;

		public const sbyte lion = 4;

		public const sbyte monkey = 5;

		public const sbyte pig = 6;

		public const sbyte snake = 7;

		public const sbyte tiger = 8;

		public const sbyte bear_elite = 9;

		public const sbyte bull_elite = 10;

		public const sbyte eagle_elite = 11;

		public const sbyte jaguar_elite = 12;

		public const sbyte lion_elite = 13;

		public const sbyte monkey_elite = 14;

		public const sbyte pig_elite = 15;

		public const sbyte snake_elite = 16;

		public const sbyte tiger_elite = 17;

		public const sbyte monkey_king = 18;

		public const sbyte LiujinHuoSerpent = 19;

		public const sbyte DujingSerpent = 20;

		public const sbyte DuanxieSerpent = 21;

		public const sbyte RihunzhujingSerpen = 22;

		public const sbyte ZhuyanSerpent = 23;

		public const sbyte XuanzhoujinSerpent = 24;

		public const sbyte TianzhuSerpent = 25;

		public const sbyte JiuchibanSerpent = 26;

		public const sbyte RuiSerpent = 27;

		public const sbyte QiSerpent0 = 28;

		public const sbyte Sibuxiang = 80;

		public const sbyte Zhiren = 81;

		public const sbyte Banshanhuogui = 82;

		public const sbyte Moqilin = 83;

		public const sbyte Pixingfeiwu = 84;

		public const sbyte Xuanjiu = 85;

		public const sbyte Yuanqiu = 86;

		public const sbyte Bainiu = 87;

		public const sbyte Sanyanxiao = 88;

		public const sbyte Heishanjun = 89;

		public const sbyte Jiutouchong = 90;

		public const sbyte Qingcuiyouying = 79;

		public const sbyte LoongWhite = 29;

		public const sbyte LoongBlack = 30;

		public const sbyte LoongGreen = 31;

		public const sbyte LoongRed = 32;

		public const sbyte LoongYellow = 33;

		public const sbyte MinionLoongWhite = 34;

		public const sbyte MinionLoongBlack = 35;

		public const sbyte MinionLoongGreen = 36;

		public const sbyte MinionLoongRed = 37;

		public const sbyte MinionLoongYellow = 38;

		public const sbyte JiaoWhite = 39;

		public const sbyte JiaoBlack = 40;

		public const sbyte JiaoGreen = 41;

		public const sbyte JiaoRed = 42;

		public const sbyte JiaoYellow = 43;

		public const sbyte JiaoWB = 44;

		public const sbyte JiaoWG = 45;

		public const sbyte JiaoWR = 46;

		public const sbyte JiaoWY = 47;

		public const sbyte JiaoBG = 48;

		public const sbyte JiaoBR = 49;

		public const sbyte JiaoBY = 50;

		public const sbyte JiaoGR = 51;

		public const sbyte JiaoGY = 52;

		public const sbyte JiaoRY = 53;

		public const sbyte JiaoWBG = 54;

		public const sbyte JiaoWBR = 55;

		public const sbyte JiaoWBY = 56;

		public const sbyte JiaoWGR = 57;

		public const sbyte JiaoWGY = 58;

		public const sbyte JiaoWRY = 59;

		public const sbyte JiaoBGR = 60;

		public const sbyte JiaoBGY = 61;

		public const sbyte JiaoBRY = 62;

		public const sbyte JiaoGRY = 63;

		public const sbyte JiaoWBGR = 64;

		public const sbyte JiaoWBGY = 65;

		public const sbyte JiaoWBRY = 66;

		public const sbyte JiaoWGRY = 67;

		public const sbyte JiaoBGRY = 68;

		public const sbyte JiaoWGRYB = 69;

		public const sbyte Qiuniu = 70;

		public const sbyte Yazi = 71;

		public const sbyte Chaofeng = 72;

		public const sbyte Pulao = 73;

		public const sbyte Suanni = 74;

		public const sbyte Baxia = 75;

		public const sbyte Bian = 76;

		public const sbyte Fuxi = 77;

		public const sbyte Chiwen = 78;
	}

	public static class DefValue
	{
		public static AnimalItem bear => Instance[(sbyte)0];

		public static AnimalItem bull => Instance[(sbyte)1];

		public static AnimalItem eagle => Instance[(sbyte)2];

		public static AnimalItem jaguar => Instance[(sbyte)3];

		public static AnimalItem lion => Instance[(sbyte)4];

		public static AnimalItem monkey => Instance[(sbyte)5];

		public static AnimalItem pig => Instance[(sbyte)6];

		public static AnimalItem snake => Instance[(sbyte)7];

		public static AnimalItem tiger => Instance[(sbyte)8];

		public static AnimalItem bear_elite => Instance[(sbyte)9];

		public static AnimalItem bull_elite => Instance[(sbyte)10];

		public static AnimalItem eagle_elite => Instance[(sbyte)11];

		public static AnimalItem jaguar_elite => Instance[(sbyte)12];

		public static AnimalItem lion_elite => Instance[(sbyte)13];

		public static AnimalItem monkey_elite => Instance[(sbyte)14];

		public static AnimalItem pig_elite => Instance[(sbyte)15];

		public static AnimalItem snake_elite => Instance[(sbyte)16];

		public static AnimalItem tiger_elite => Instance[(sbyte)17];

		public static AnimalItem monkey_king => Instance[(sbyte)18];

		public static AnimalItem LiujinHuoSerpent => Instance[(sbyte)19];

		public static AnimalItem DujingSerpent => Instance[(sbyte)20];

		public static AnimalItem DuanxieSerpent => Instance[(sbyte)21];

		public static AnimalItem RihunzhujingSerpen => Instance[(sbyte)22];

		public static AnimalItem ZhuyanSerpent => Instance[(sbyte)23];

		public static AnimalItem XuanzhoujinSerpent => Instance[(sbyte)24];

		public static AnimalItem TianzhuSerpent => Instance[(sbyte)25];

		public static AnimalItem JiuchibanSerpent => Instance[(sbyte)26];

		public static AnimalItem RuiSerpent => Instance[(sbyte)27];

		public static AnimalItem QiSerpent0 => Instance[(sbyte)28];

		public static AnimalItem Sibuxiang => Instance[(sbyte)80];

		public static AnimalItem Zhiren => Instance[(sbyte)81];

		public static AnimalItem Banshanhuogui => Instance[(sbyte)82];

		public static AnimalItem Moqilin => Instance[(sbyte)83];

		public static AnimalItem Pixingfeiwu => Instance[(sbyte)84];

		public static AnimalItem Xuanjiu => Instance[(sbyte)85];

		public static AnimalItem Yuanqiu => Instance[(sbyte)86];

		public static AnimalItem Bainiu => Instance[(sbyte)87];

		public static AnimalItem Sanyanxiao => Instance[(sbyte)88];

		public static AnimalItem Heishanjun => Instance[(sbyte)89];

		public static AnimalItem Jiutouchong => Instance[(sbyte)90];

		public static AnimalItem Qingcuiyouying => Instance[(sbyte)79];

		public static AnimalItem LoongWhite => Instance[(sbyte)29];

		public static AnimalItem LoongBlack => Instance[(sbyte)30];

		public static AnimalItem LoongGreen => Instance[(sbyte)31];

		public static AnimalItem LoongRed => Instance[(sbyte)32];

		public static AnimalItem LoongYellow => Instance[(sbyte)33];

		public static AnimalItem MinionLoongWhite => Instance[(sbyte)34];

		public static AnimalItem MinionLoongBlack => Instance[(sbyte)35];

		public static AnimalItem MinionLoongGreen => Instance[(sbyte)36];

		public static AnimalItem MinionLoongRed => Instance[(sbyte)37];

		public static AnimalItem MinionLoongYellow => Instance[(sbyte)38];

		public static AnimalItem JiaoWhite => Instance[(sbyte)39];

		public static AnimalItem JiaoBlack => Instance[(sbyte)40];

		public static AnimalItem JiaoGreen => Instance[(sbyte)41];

		public static AnimalItem JiaoRed => Instance[(sbyte)42];

		public static AnimalItem JiaoYellow => Instance[(sbyte)43];

		public static AnimalItem JiaoWB => Instance[(sbyte)44];

		public static AnimalItem JiaoWG => Instance[(sbyte)45];

		public static AnimalItem JiaoWR => Instance[(sbyte)46];

		public static AnimalItem JiaoWY => Instance[(sbyte)47];

		public static AnimalItem JiaoBG => Instance[(sbyte)48];

		public static AnimalItem JiaoBR => Instance[(sbyte)49];

		public static AnimalItem JiaoBY => Instance[(sbyte)50];

		public static AnimalItem JiaoGR => Instance[(sbyte)51];

		public static AnimalItem JiaoGY => Instance[(sbyte)52];

		public static AnimalItem JiaoRY => Instance[(sbyte)53];

		public static AnimalItem JiaoWBG => Instance[(sbyte)54];

		public static AnimalItem JiaoWBR => Instance[(sbyte)55];

		public static AnimalItem JiaoWBY => Instance[(sbyte)56];

		public static AnimalItem JiaoWGR => Instance[(sbyte)57];

		public static AnimalItem JiaoWGY => Instance[(sbyte)58];

		public static AnimalItem JiaoWRY => Instance[(sbyte)59];

		public static AnimalItem JiaoBGR => Instance[(sbyte)60];

		public static AnimalItem JiaoBGY => Instance[(sbyte)61];

		public static AnimalItem JiaoBRY => Instance[(sbyte)62];

		public static AnimalItem JiaoGRY => Instance[(sbyte)63];

		public static AnimalItem JiaoWBGR => Instance[(sbyte)64];

		public static AnimalItem JiaoWBGY => Instance[(sbyte)65];

		public static AnimalItem JiaoWBRY => Instance[(sbyte)66];

		public static AnimalItem JiaoWGRY => Instance[(sbyte)67];

		public static AnimalItem JiaoBGRY => Instance[(sbyte)68];

		public static AnimalItem JiaoWGRYB => Instance[(sbyte)69];

		public static AnimalItem Qiuniu => Instance[(sbyte)70];

		public static AnimalItem Yazi => Instance[(sbyte)71];

		public static AnimalItem Chaofeng => Instance[(sbyte)72];

		public static AnimalItem Pulao => Instance[(sbyte)73];

		public static AnimalItem Suanni => Instance[(sbyte)74];

		public static AnimalItem Baxia => Instance[(sbyte)75];

		public static AnimalItem Bian => Instance[(sbyte)76];

		public static AnimalItem Fuxi => Instance[(sbyte)77];

		public static AnimalItem Chiwen => Instance[(sbyte)78];
	}

	public static Animal Instance = new Animal();

	private readonly HashSet<string> RequiredFields = new HashSet<string>
	{
		"CharacterIdList", "CatchEffect", "CarrierId", "TemplateId", "AssetFileName", "AniPrefix", "AttackDistances", "AttackParticles", "AttackSounds", "BlockSound",
		"JumpMoveParticles", "StepSound", "TeammateCommandBackCharEnterSound", "FailParticle", "FailSound"
	};

	internal override int ToInt(sbyte value)
	{
		return value;
	}

	internal override sbyte ToTemplateId(int value)
	{
		return (sbyte)value;
	}

	private void CreateItems0()
	{
		_dataArray.Add(new AnimalItem(0, new short[1] { 231 }, "bear", "bear_", new List<sbyte> { 20, 20, 18 }, new List<string> { "Particle_bear_A_001", "Particle_bear_A_002", "Particle_bear_A_003" }, new List<string> { "SE_bear_A_001", "SE_bear_A_002", "SE_bear_A_003" }, "SE_bear_A_001", null, new List<string> { "se_combat_foot_bear_1", "se_combat_foot_bear_2", "se_combat_foot_bear_3" }, null, 14, 30, null, null, isElite: false));
		_dataArray.Add(new AnimalItem(1, new short[1] { 232 }, "bull", "bull_", new List<sbyte> { 20, 20 }, new List<string> { "Particle_bull_A_001", "Particle_bull_A_004" }, new List<string> { "SE_bull_A_001", "SE_bull_A_004" }, "SE_bull_A_004", null, new List<string> { "se_combat_foot_bull_1", "se_combat_foot_bull_2", "se_combat_foot_bull_3" }, null, 15, 31, null, null, isElite: false));
		_dataArray.Add(new AnimalItem(2, new short[1] { 229 }, "eagle", "eagle_", new List<sbyte> { 13, 40 }, new List<string> { "Particle_eagle_A_002", "Particle_eagle_A_003" }, new List<string> { "SE_eagle_A_002", "SE_eagle_A_003" }, "SE_eagle_A_002", null, new List<string> { "se_combat_foot_eagle_1", "se_combat_foot_eagle_2", "se_combat_foot_eagle_3" }, null, 16, 28, null, null, isElite: false));
		_dataArray.Add(new AnimalItem(3, new short[1] { 234 }, "jaguar", "jaguar_", new List<sbyte> { 18, 16 }, new List<string> { "Particle_jaguar_A_002", "Particle_jaguar_A_003" }, new List<string> { "SE_jaguar_A_002", "SE_jaguar_A_003" }, "SE_jaguar_A_002", null, new List<string> { "se_combat_foot_jaguar_1", "se_combat_foot_jaguar_2", "se_combat_foot_jaguar_3" }, null, 17, 33, null, null, isElite: false));
		_dataArray.Add(new AnimalItem(4, new short[1] { 235 }, "lion", "lion_", new List<sbyte> { 18, 20, 16 }, new List<string> { "Particle_lion_A_001", "Particle_lion_A_002", "Particle_lion_A_003" }, new List<string> { "SE_lion_A_001", "SE_lion_A_002", "SE_lion_A_003" }, "SE_lion_A_002", null, new List<string> { "se_combat_foot_lion_1", "se_combat_foot_lion_2", "se_combat_foot_lion_3" }, null, 18, 34, null, null, isElite: false));
		_dataArray.Add(new AnimalItem(5, new short[2] { 228, 889 }, "monkey", "monkey_", new List<sbyte> { 20, 18, 12 }, new List<string> { "Particle_monkey_A_001", "Particle_monkey_A_002", "Particle_monkey_A_003" }, new List<string> { "SE_monkey_A_001", "SE_monkey_A_002", "SE_monkey_A_003" }, "SE_monkey_A_003", null, new List<string> { "se_combat_foot_monkey_1", "se_combat_foot_monkey_2", "se_combat_foot_monkey_3" }, null, 19, 27, null, null, isElite: false));
		_dataArray.Add(new AnimalItem(6, new short[1] { 230 }, "pig", "pig_", new List<sbyte> { 14, 14, 14 }, new List<string> { "Particle_pig_A_001", "Particle_pig_A_003", "Particle_pig_A_004" }, new List<string> { "SE_pig_A_001", "SE_pig_A_003", "SE_pig_A_004" }, "SE_pig_A_004", new List<string> { "Particle_pig_M_003_fly", "Particle_pig_M_004_fly" }, new List<string> { "se_combat_foot_pig_1", "se_combat_foot_pig_2", "se_combat_foot_pig_3" }, null, 20, 29, null, null, isElite: false));
		_dataArray.Add(new AnimalItem(7, new short[4] { 233, 896, 966, 967 }, "snake", "snake_", new List<sbyte> { 40, 10 }, new List<string> { "Particle_snake_A_001", "Particle_snake_A_003" }, new List<string> { "SE_snake_A_001", "SE_snake_A_003" }, "SE_snake_A_003", null, null, null, 21, 32, null, null, isElite: false));
		_dataArray.Add(new AnimalItem(8, new short[1] { 236 }, "tiger", "tiger_", new List<sbyte> { 40, 22, 14 }, new List<string> { "Particle_tiger_A_001", "Particle_tiger_A_002", "Particle_tiger_A_003" }, new List<string> { "SE_tiger_A_001", "SE_tiger_A_002", "SE_tiger_A_003" }, "SE_tiger_A_002", null, new List<string> { "se_combat_foot_tiger_1", "se_combat_foot_tiger_2", "se_combat_foot_tiger_3" }, null, 22, 35, null, null, isElite: false));
		_dataArray.Add(new AnimalItem(9, new short[1] { 240 }, "bear_elite", "bear_elite_", new List<sbyte> { 20, 30, 20 }, new List<string> { "Particle_bear_elite_A_001", "Particle_bear_elite_A_002", "Particle_bear_elite_A_003" }, new List<string> { "SE_bear_elite_A_001", "SE_bear_elite_A_002", "SE_bear_elite_A_003" }, "SE_bear_elite_A_001", null, new List<string> { "se_combat_foot_bear_1", "se_combat_foot_bear_2", "se_combat_foot_bear_3" }, null, 23, 39, null, null, isElite: true));
		_dataArray.Add(new AnimalItem(10, new short[1] { 241 }, "bull_elite", "bull_elite_", new List<sbyte> { 25, 25 }, new List<string> { "Particle_bull_elite_A_001", "Particle_bull_elite_A_004" }, new List<string> { "SE_bull_elite_A_001", "SE_bull_elite_A_004" }, "SE_bull_A_004", null, new List<string> { "se_combat_foot_bull_1", "se_combat_foot_bull_2", "se_combat_foot_bull_3" }, null, 24, 40, null, null, isElite: true));
		_dataArray.Add(new AnimalItem(11, new short[1] { 238 }, "eagle_elite", "eagle_elite_", new List<sbyte> { 16, 40 }, new List<string> { "Particle_eagle_elite_A_002", "Particle_eagle_elite_A_003" }, new List<string> { "SE_eagle_elite_A_002", "SE_eagle_elite_A_003" }, "SE_eagle_A_002", null, new List<string> { "se_combat_foot_eagle_1", "se_combat_foot_eagle_2", "se_combat_foot_eagle_3" }, null, 25, 37, null, null, isElite: true));
		_dataArray.Add(new AnimalItem(12, new short[1] { 243 }, "jaguar_elite", "jaguar_elite_", new List<sbyte> { 20, 20 }, new List<string> { "Particle_jaguar_elite_A_002", "Particle_jaguar_elite_A_003" }, new List<string> { "SE_jaguar_elite_A_002", "SE_jaguar_elite_A_003" }, "SE_jaguar_A_002", null, new List<string> { "se_combat_foot_jaguar_1", "se_combat_foot_jaguar_2", "se_combat_foot_jaguar_3" }, null, 26, 42, null, null, isElite: true));
		_dataArray.Add(new AnimalItem(13, new short[1] { 244 }, "lion_elite", "lion_elite_", new List<sbyte> { 20, 30, 18 }, new List<string> { "Particle_lion_elite_A_001", "Particle_lion_elite_A_002", "Particle_lion_elite_A_003" }, new List<string> { "SE_lion_elite_A_001", "SE_lion_elite_A_002", "SE_lion_elite_A_003" }, "SE_lion_A_002", null, new List<string> { "se_combat_foot_lion_1", "se_combat_foot_lion_2", "se_combat_foot_lion_3" }, null, 27, 43, null, null, isElite: true));
		_dataArray.Add(new AnimalItem(14, new short[2] { 237, 888 }, "monkey_elite", "monkey_elite_", new List<sbyte> { 24, 20, 12 }, new List<string> { "Particle_monkey_elite_A_001", "Particle_monkey_elite_A_002", "Particle_monkey_elite_A_003" }, new List<string> { "SE_monkey_elite_A_001", "SE_monkey_elite_A_002", "SE_monkey_elite_A_003" }, "SE_monkey_A_003", null, new List<string> { "se_combat_foot_monkey_1", "se_combat_foot_monkey_2", "se_combat_foot_monkey_3" }, null, 28, 36, null, null, isElite: true));
		_dataArray.Add(new AnimalItem(15, new short[1] { 239 }, "pig_elite", "pig_elite_", new List<sbyte> { 18, 18, 18 }, new List<string> { "Particle_pig_elite_A_001", "Particle_pig_elite_A_003", "Particle_pig_elite_A_004" }, new List<string> { "SE_pig_elite_A_001", "SE_pig_elite_A_003", "SE_pig_elite_A_004" }, "SE_pig_A_004", new List<string> { "Particle_pig_elite_M_003_fly", "Particle_pig_elite_M_004_fly" }, new List<string> { "se_combat_foot_pig_1", "se_combat_foot_pig_2", "se_combat_foot_pig_3" }, null, 29, 38, null, null, isElite: true));
		_dataArray.Add(new AnimalItem(16, new short[1] { 242 }, "snake_elite", "snake_elite_", new List<sbyte> { 45, 15 }, new List<string> { "Particle_snake_elite_A_001", "Particle_snake_elite_A_003" }, new List<string> { "SE_snake_elite_A_001", "SE_snake_elite_A_003" }, "SE_snake_A_003", null, null, null, 30, 41, null, null, isElite: true));
		_dataArray.Add(new AnimalItem(17, new short[1] { 245 }, "tiger_elite", "tiger_elite_", new List<sbyte> { 40, 30, 16 }, new List<string> { "Particle_tiger_elite_A_001", "Particle_tiger_elite_A_002", "Particle_tiger_elite_A_003" }, new List<string> { "SE_tiger_elite_A_001", "SE_tiger_elite_A_002", "SE_tiger_elite_A_003" }, "SE_tiger_A_002", null, new List<string> { "se_combat_foot_tiger_1", "se_combat_foot_tiger_2", "se_combat_foot_tiger_3" }, null, 31, 44, null, null, isElite: true));
		_dataArray.Add(new AnimalItem(18, new short[1] { 890 }, "monkey_king", "monkey_king_", new List<sbyte> { 20, 18, 13 }, new List<string> { "Particle_monkey_king_A_001", "Particle_monkey_king_A_002", "Particle_monkey_king_A_003" }, new List<string> { "SE_monkey_king_A_001", "SE_monkey_king_A_002", "SE_monkey_king_A_003" }, "SE_monkey_A_003", null, new List<string> { "se_combat_foot_monkey_1", "se_combat_foot_monkey_2", "se_combat_foot_monkey_3" }, null, 32, 36, null, null, isElite: false));
		_dataArray.Add(new AnimalItem(19, new short[3] { 603, 604, 605 }, "snake_Wudang", "snake_Wudang_", new List<sbyte> { 30 }, new List<string> { "Particle_snake_Wudang_A_002" }, new List<string> { "SE_snake_wudang_A_002" }, "SE_snake_A_003", null, null, null, 21, 32, null, null, isElite: false));
		_dataArray.Add(new AnimalItem(20, new short[3] { 606, 607, 608 }, "snake_Wudang", "snake_Wudang_", new List<sbyte> { 15 }, new List<string> { "Particle_snake_Wudang_A_003" }, new List<string> { "SE_snake_A_003" }, "SE_snake_A_003", null, null, null, 21, 32, null, null, isElite: false));
		_dataArray.Add(new AnimalItem(21, new short[3] { 609, 610, 611 }, "snake_Wudang", "snake_Wudang_", new List<sbyte> { 20, 30 }, new List<string> { "Particle_snake_Wudang_A_001", "Particle_snake_Wudang_A_002" }, new List<string> { "SE_snake_A_001", "SE_snake_wudang_A_002" }, "SE_snake_A_003", null, null, null, 21, 32, null, null, isElite: false));
		_dataArray.Add(new AnimalItem(22, new short[3] { 612, 613, 614 }, "snake_Wudang", "snake_Wudang_", new List<sbyte> { 20, 50 }, new List<string> { "Particle_snake_Wudang_A_001", "Particle_snake_Wudang_A_009_0" }, new List<string> { "SE_snake_A_001", "SE_snake_wudang_A_009" }, "SE_snake_A_003", null, null, null, 21, 32, null, null, isElite: false));
		_dataArray.Add(new AnimalItem(23, new short[3] { 615, 616, 617 }, "snake_Wudang", "snake_Wudang_", new List<sbyte> { 20 }, new List<string> { "Particle_snake_Wudang_A_001" }, new List<string> { "SE_snake_A_001" }, "SE_snake_A_003", null, null, null, 21, 32, null, null, isElite: false));
		_dataArray.Add(new AnimalItem(24, new short[3] { 618, 619, 620 }, "snake_Wudang", "snake_Wudang_", new List<sbyte> { 20, 15 }, new List<string> { "Particle_snake_Wudang_A_001", "Particle_snake_Wudang_A_003" }, new List<string> { "SE_snake_A_001", "SE_snake_A_003" }, "SE_snake_A_003", null, null, null, 21, 32, null, null, isElite: false));
		_dataArray.Add(new AnimalItem(25, new short[3] { 621, 622, 623 }, "snake_Wudang", "snake_Wudang_", new List<sbyte> { 15, 30 }, new List<string> { "Particle_snake_Wudang_A_003", "Particle_snake_Wudang_A_002" }, new List<string> { "SE_snake_A_003", "SE_snake_wudang_A_002" }, "SE_snake_A_003", null, null, null, 21, 32, null, null, isElite: false));
		_dataArray.Add(new AnimalItem(26, new short[3] { 624, 625, 626 }, "snake_Wudang", "snake_Wudang_", new List<sbyte> { 30, 50 }, new List<string> { "Particle_snake_Wudang_A_002", "Particle_snake_Wudang_A_009_0" }, new List<string> { "SE_snake_wudang_A_002", "SE_snake_wudang_A_009" }, "SE_snake_A_003", null, null, null, 21, 32, null, null, isElite: false));
		_dataArray.Add(new AnimalItem(27, new short[3] { 627, 628, 629 }, "snake_Wudang", "snake_Wudang_", new List<sbyte> { 15, 50 }, new List<string> { "Particle_snake_Wudang_A_003", "Particle_snake_Wudang_A_009_0" }, new List<string> { "SE_snake_A_003", "SE_snake_wudang_A_009" }, "SE_snake_A_003", null, null, null, 21, 32, null, null, isElite: false));
		_dataArray.Add(new AnimalItem(28, new short[3] { 630, 631, 632 }, "snake_Wudang", "snake_Wudang_", new List<sbyte> { 50 }, new List<string> { "Particle_snake_Wudang_A_009_0" }, new List<string> { "SE_snake_wudang_A_009" }, "SE_snake_A_003", null, null, null, 21, 32, null, null, isElite: false));
		_dataArray.Add(new AnimalItem(29, new short[2] { 246, 1343 }, "Loong", "Loong_", new List<sbyte> { 18, 34, 40 }, new List<string> { "Particle_Loong_A_003", "Particle_Loong_A_002", "Particle_Loong_A_004" }, new List<string> { "SE_Loong_A_003", "SE_Loong_A_002", "SE_Loong_A_004" }, "SE_Loong_T_001", null, null, null, 33, 46, null, "SE_Loong_C_011", isElite: true));
		_dataArray.Add(new AnimalItem(30, new short[2] { 247, 1344 }, "Loong", "Loong_", new List<sbyte> { 18, 34, 40 }, new List<string> { "Particle_Loong_A_003", "Particle_Loong_A_002", "Particle_Loong_A_004_a" }, new List<string> { "SE_Loong_A_003", "SE_Loong_A_002", "SE_Loong_A_004_a" }, "SE_Loong_T_001", null, null, null, 33, 47, null, "SE_Loong_C_011", isElite: true));
		_dataArray.Add(new AnimalItem(31, new short[2] { 248, 1345 }, "Loong", "Loong_", new List<sbyte> { 18, 34, 40 }, new List<string> { "Particle_Loong_A_003", "Particle_Loong_A_002", "Particle_Loong_A_004_b" }, new List<string> { "SE_Loong_A_003", "SE_Loong_A_002", "SE_Loong_A_004_b" }, "SE_Loong_T_001", null, null, null, 33, 48, null, "SE_Loong_C_011", isElite: true));
		_dataArray.Add(new AnimalItem(32, new short[2] { 249, 1346 }, "Loong", "Loong_", new List<sbyte> { 18, 34, 40 }, new List<string> { "Particle_Loong_A_003", "Particle_Loong_A_002", "Particle_Loong_A_004_a" }, new List<string> { "SE_Loong_A_003", "SE_Loong_A_002", "SE_Loong_A_004_a" }, "SE_Loong_T_001", null, null, null, 33, 49, null, "SE_Loong_C_011", isElite: true));
		_dataArray.Add(new AnimalItem(33, new short[2] { 250, 1347 }, "Loong", "Loong_", new List<sbyte> { 23, 34, 40 }, new List<string> { "Particle_Loong_A_001_a", "Particle_Loong_A_002", "Particle_Loong_A_004_a" }, new List<string> { "SE_Loong_A_001_a", "SE_Loong_A_002", "SE_Loong_A_004_a" }, "SE_Loong_T_001", null, null, null, 33, 50, null, "SE_Loong_C_011", isElite: true));
		_dataArray.Add(new AnimalItem(34, new short[1] { 251 }, "Loong", "Loong_", new List<sbyte> { 18, 34, 40 }, new List<string> { "Particle_Loong_A_003", "Particle_Loong_A_002", "Particle_Loong_A_004" }, new List<string> { "SE_Loong_A_003", "SE_Loong_A_002", "SE_Loong_A_004" }, "SE_Loong_T_001", null, null, null, 34, 46, null, "SE_Loong_C_011", isElite: false));
		_dataArray.Add(new AnimalItem(35, new short[1] { 252 }, "Loong", "Loong_", new List<sbyte> { 18, 34, 40 }, new List<string> { "Particle_Loong_A_003", "Particle_Loong_A_002", "Particle_Loong_A_004_a" }, new List<string> { "SE_Loong_A_003", "SE_Loong_A_002", "SE_Loong_A_004_a" }, "SE_Loong_T_001", null, null, null, 34, 47, null, "SE_Loong_C_011", isElite: false));
		_dataArray.Add(new AnimalItem(36, new short[1] { 253 }, "Loong", "Loong_", new List<sbyte> { 18, 34, 40 }, new List<string> { "Particle_Loong_A_003", "Particle_Loong_A_002", "Particle_Loong_A_004_b" }, new List<string> { "SE_Loong_A_003", "SE_Loong_A_002", "SE_Loong_A_004_b" }, "SE_Loong_T_001", null, null, null, 34, 48, null, "SE_Loong_C_011", isElite: false));
		_dataArray.Add(new AnimalItem(37, new short[1] { 254 }, "Loong", "Loong_", new List<sbyte> { 18, 34, 40 }, new List<string> { "Particle_Loong_A_003", "Particle_Loong_A_002", "Particle_Loong_A_004_a" }, new List<string> { "SE_Loong_A_003", "SE_Loong_A_002", "SE_Loong_A_004_a" }, "SE_Loong_T_001", null, null, new List<string> { "SE_Loong_M_016", "SE_Loong_M_017" }, 34, 49, null, "SE_Loong_C_011", isElite: false));
		_dataArray.Add(new AnimalItem(38, new short[1] { 255 }, "Loong", "Loong_", new List<sbyte> { 23, 34, 40 }, new List<string> { "Particle_Loong_A_001_a", "Particle_Loong_A_002", "Particle_Loong_A_004_a" }, new List<string> { "SE_Loong_A_001_a", "SE_Loong_A_002", "SE_Loong_A_004_a" }, "SE_Loong_T_001", null, null, null, 34, 50, null, "SE_Loong_C_011", isElite: false));
		_dataArray.Add(new AnimalItem(39, new short[1] { 256 }, "Loong", "Loong_", new List<sbyte> { 23, 18, 40 }, new List<string> { "Particle_Loong_A_001", "Particle_Loong_A_003", "Particle_Loong_A_004_b" }, new List<string> { "SE_Loong_A_001", "SE_Loong_A_003", "SE_Loong_A_004_b" }, "SE_Loong_T_001", null, null, null, 34, 46, null, "SE_Loong_C_011", isElite: false));
		_dataArray.Add(new AnimalItem(40, new short[1] { 257 }, "Loong", "Loong_", new List<sbyte> { 23, 18, 40 }, new List<string> { "Particle_Loong_A_001", "Particle_Loong_A_003", "Particle_Loong_A_004_a" }, new List<string> { "SE_Loong_A_001", "SE_Loong_A_003", "SE_Loong_A_004_a" }, "SE_Loong_T_001", null, null, null, 34, 47, null, "SE_Loong_C_011", isElite: false));
		_dataArray.Add(new AnimalItem(41, new short[1] { 258 }, "Loong", "Loong_", new List<sbyte> { 23, 18, 40 }, new List<string> { "Particle_Loong_A_001", "Particle_Loong_A_003", "Particle_Loong_A_004_b" }, new List<string> { "SE_Loong_A_001", "SE_Loong_A_003", "SE_Loong_A_004_b" }, "SE_Loong_T_001", null, null, null, 34, 48, null, "SE_Loong_C_011", isElite: false));
		_dataArray.Add(new AnimalItem(42, new short[1] { 259 }, "Loong", "Loong_", new List<sbyte> { 23, 18, 40 }, new List<string> { "Particle_Loong_A_001", "Particle_Loong_A_003", "Particle_Loong_A_004_a" }, new List<string> { "SE_Loong_A_001", "SE_Loong_A_003", "SE_Loong_A_004_a" }, "SE_Loong_T_001", null, null, null, 34, 49, null, "SE_Loong_C_011", isElite: false));
		_dataArray.Add(new AnimalItem(43, new short[1] { 260 }, "Loong", "Loong_", new List<sbyte> { 23, 18, 40 }, new List<string> { "Particle_Loong_A_001_a", "Particle_Loong_A_003", "Particle_Loong_A_004_a" }, new List<string> { "SE_Loong_A_001_a", "SE_Loong_A_003", "SE_Loong_A_004_a" }, "SE_Loong_T_001", null, null, null, 34, 50, null, "SE_Loong_C_011", isElite: false));
		_dataArray.Add(new AnimalItem(44, new short[1] { 261 }, "Loong", "Loong_", new List<sbyte> { 23, 18, 40 }, new List<string> { "Particle_Loong_A_001", "Particle_Loong_A_003", "Particle_Loong_A_004_b" }, new List<string> { "SE_Loong_A_001", "SE_Loong_A_003", "SE_Loong_A_004_b" }, "SE_Loong_T_001", null, null, null, 34, 51, null, "SE_Loong_C_011", isElite: false));
		_dataArray.Add(new AnimalItem(45, new short[2] { 262, 1107 }, "Loong", "Loong_", new List<sbyte> { 23, 18, 40 }, new List<string> { "Particle_Loong_A_001", "Particle_Loong_A_003", "Particle_Loong_A_004_b" }, new List<string> { "SE_Loong_A_001", "SE_Loong_A_003", "SE_Loong_A_004_b" }, "SE_Loong_T_001", null, null, null, 34, 52, null, "SE_Loong_C_011", isElite: false));
		_dataArray.Add(new AnimalItem(46, new short[2] { 263, 1105 }, "Loong", "Loong_", new List<sbyte> { 23, 18, 40 }, new List<string> { "Particle_Loong_A_001", "Particle_Loong_A_003", "Particle_Loong_A_004_b" }, new List<string> { "SE_Loong_A_001", "SE_Loong_A_003", "SE_Loong_A_004_b" }, "SE_Loong_T_001", null, null, null, 34, 53, null, "SE_Loong_C_011", isElite: false));
		_dataArray.Add(new AnimalItem(47, new short[2] { 264, 1103 }, "Loong", "Loong_", new List<sbyte> { 23, 18, 40 }, new List<string> { "Particle_Loong_A_001_a", "Particle_Loong_A_003", "Particle_Loong_A_004_b" }, new List<string> { "SE_Loong_A_001_a", "SE_Loong_A_003", "SE_Loong_A_004_b" }, "SE_Loong_T_001", null, null, null, 34, 54, null, "SE_Loong_C_011", isElite: false));
		_dataArray.Add(new AnimalItem(48, new short[2] { 265, 1106 }, "Loong", "Loong_", new List<sbyte> { 23, 18, 40 }, new List<string> { "Particle_Loong_A_001", "Particle_Loong_A_003", "Particle_Loong_A_004_b" }, new List<string> { "SE_Loong_A_001", "SE_Loong_A_003", "SE_Loong_A_004_b" }, "SE_Loong_T_001", null, null, null, 34, 55, null, "SE_Loong_C_011", isElite: false));
		_dataArray.Add(new AnimalItem(49, new short[2] { 266, 1108 }, "Loong", "Loong_", new List<sbyte> { 23, 18, 40 }, new List<string> { "Particle_Loong_A_001", "Particle_Loong_A_003", "Particle_Loong_A_004_a" }, new List<string> { "SE_Loong_A_001", "SE_Loong_A_003", "SE_Loong_A_004_a" }, "SE_Loong_T_001", null, null, null, 34, 56, null, "SE_Loong_C_011", isElite: false));
		_dataArray.Add(new AnimalItem(50, new short[2] { 267, 1104 }, "Loong", "Loong_", new List<sbyte> { 23, 18, 40 }, new List<string> { "Particle_Loong_A_001_a", "Particle_Loong_A_003", "Particle_Loong_A_004_a" }, new List<string> { "SE_Loong_A_001_a", "SE_Loong_A_003", "SE_Loong_A_004_a" }, "SE_Loong_T_001", null, null, null, 34, 57, null, "SE_Loong_C_011", isElite: false));
		_dataArray.Add(new AnimalItem(51, new short[1] { 268 }, "Loong", "Loong_", new List<sbyte> { 23, 18, 40 }, new List<string> { "Particle_Loong_A_001", "Particle_Loong_A_003", "Particle_Loong_A_004_b" }, new List<string> { "SE_Loong_A_001", "SE_Loong_A_003", "SE_Loong_A_004_b" }, "SE_Loong_T_001", null, null, null, 34, 58, null, "SE_Loong_C_011", isElite: false));
		_dataArray.Add(new AnimalItem(52, new short[1] { 269 }, "Loong", "Loong_", new List<sbyte> { 23, 18, 40 }, new List<string> { "Particle_Loong_A_001_a", "Particle_Loong_A_003", "Particle_Loong_A_004_b" }, new List<string> { "SE_Loong_A_001_a", "SE_Loong_A_003", "SE_Loong_A_004_b" }, "SE_Loong_T_001", null, null, null, 34, 59, null, "SE_Loong_C_011", isElite: false));
		_dataArray.Add(new AnimalItem(53, new short[1] { 270 }, "Loong", "Loong_", new List<sbyte> { 23, 18, 40 }, new List<string> { "Particle_Loong_A_001_a", "Particle_Loong_A_003", "Particle_Loong_A_004_a" }, new List<string> { "SE_Loong_A_001_a", "SE_Loong_A_003", "SE_Loong_A_004_a" }, "SE_Loong_T_001", null, null, null, 34, 60, null, "SE_Loong_C_011", isElite: false));
		_dataArray.Add(new AnimalItem(54, new short[1] { 271 }, "Loong", "Loong_", new List<sbyte> { 23, 18, 40 }, new List<string> { "Particle_Loong_A_001", "Particle_Loong_A_003", "Particle_Loong_A_004_b" }, new List<string> { "SE_Loong_A_001", "SE_Loong_A_003", "SE_Loong_A_004_b" }, "SE_Loong_T_001", null, null, null, 34, 61, null, "SE_Loong_C_011", isElite: false));
		_dataArray.Add(new AnimalItem(55, new short[1] { 272 }, "Loong", "Loong_", new List<sbyte> { 23, 18, 40 }, new List<string> { "Particle_Loong_A_001", "Particle_Loong_A_003", "Particle_Loong_A_004_b" }, new List<string> { "SE_Loong_A_001", "SE_Loong_A_003", "SE_Loong_A_004_b" }, "SE_Loong_T_001", null, null, null, 34, 62, null, "SE_Loong_C_011", isElite: false));
		_dataArray.Add(new AnimalItem(56, new short[1] { 273 }, "Loong", "Loong_", new List<sbyte> { 23, 18, 40 }, new List<string> { "Particle_Loong_A_001_a", "Particle_Loong_A_003", "Particle_Loong_A_004_b" }, new List<string> { "SE_Loong_A_001_a", "SE_Loong_A_003", "SE_Loong_A_004_b" }, "SE_Loong_T_001", null, null, null, 34, 63, null, "SE_Loong_C_011", isElite: false));
		_dataArray.Add(new AnimalItem(57, new short[1] { 274 }, "Loong", "Loong_", new List<sbyte> { 23, 18, 40 }, new List<string> { "Particle_Loong_A_001", "Particle_Loong_A_003", "Particle_Loong_A_004_b" }, new List<string> { "SE_Loong_A_001", "SE_Loong_A_003", "SE_Loong_A_004_b" }, "SE_Loong_T_001", null, null, null, 34, 64, null, "SE_Loong_C_011", isElite: false));
		_dataArray.Add(new AnimalItem(58, new short[1] { 275 }, "Loong", "Loong_", new List<sbyte> { 23, 18, 40 }, new List<string> { "Particle_Loong_A_001_a", "Particle_Loong_A_003", "Particle_Loong_A_004_b" }, new List<string> { "SE_Loong_A_001_a", "SE_Loong_A_003", "SE_Loong_A_004_b" }, "SE_Loong_T_001", null, null, null, 34, 65, null, "SE_Loong_C_011", isElite: false));
		_dataArray.Add(new AnimalItem(59, new short[1] { 276 }, "Loong", "Loong_", new List<sbyte> { 23, 18, 40 }, new List<string> { "Particle_Loong_A_001_a", "Particle_Loong_A_003", "Particle_Loong_A_004_b" }, new List<string> { "SE_Loong_A_001_a", "SE_Loong_A_003", "SE_Loong_A_004_b" }, "SE_Loong_T_001", null, null, null, 34, 66, null, "SE_Loong_C_011", isElite: false));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new AnimalItem(60, new short[1] { 277 }, "Loong", "Loong_", new List<sbyte> { 23, 18, 40 }, new List<string> { "Particle_Loong_A_001", "Particle_Loong_A_003", "Particle_Loong_A_004_b" }, new List<string> { "SE_Loong_A_001", "SE_Loong_A_003", "SE_Loong_A_004_b" }, "SE_Loong_T_001", null, null, null, 34, 67, null, "SE_Loong_C_011", isElite: false));
		_dataArray.Add(new AnimalItem(61, new short[1] { 278 }, "Loong", "Loong_", new List<sbyte> { 23, 18, 40 }, new List<string> { "Particle_Loong_A_001_a", "Particle_Loong_A_003", "Particle_Loong_A_004_b" }, new List<string> { "SE_Loong_A_001_a", "SE_Loong_A_003", "SE_Loong_A_004_b" }, "SE_Loong_T_001", null, null, null, 34, 68, null, "SE_Loong_C_011", isElite: false));
		_dataArray.Add(new AnimalItem(62, new short[1] { 279 }, "Loong", "Loong_", new List<sbyte> { 23, 18, 40 }, new List<string> { "Particle_Loong_A_001_a", "Particle_Loong_A_003", "Particle_Loong_A_004_a" }, new List<string> { "SE_Loong_A_001_a", "SE_Loong_A_003", "SE_Loong_A_004_a" }, "SE_Loong_T_001", null, null, null, 34, 69, null, "SE_Loong_C_011", isElite: false));
		_dataArray.Add(new AnimalItem(63, new short[1] { 280 }, "Loong", "Loong_", new List<sbyte> { 23, 18, 40 }, new List<string> { "Particle_Loong_A_001_a", "Particle_Loong_A_003", "Particle_Loong_A_004_b" }, new List<string> { "SE_Loong_A_001_a", "SE_Loong_A_003", "SE_Loong_A_004_b" }, "SE_Loong_T_001", null, null, null, 34, 70, null, "SE_Loong_C_011", isElite: false));
		_dataArray.Add(new AnimalItem(64, new short[1] { 281 }, "Loong", "Loong_", new List<sbyte> { 23, 18, 40 }, new List<string> { "Particle_Loong_A_001", "Particle_Loong_A_003", "Particle_Loong_A_004_b" }, new List<string> { "SE_Loong_A_001", "SE_Loong_A_003", "SE_Loong_A_004_b" }, "SE_Loong_T_001", null, null, null, 34, 71, null, "SE_Loong_C_011", isElite: false));
		_dataArray.Add(new AnimalItem(65, new short[1] { 282 }, "Loong", "Loong_", new List<sbyte> { 23, 18, 40 }, new List<string> { "Particle_Loong_A_001_a", "Particle_Loong_A_003", "Particle_Loong_A_004_b" }, new List<string> { "SE_Loong_A_001_a", "SE_Loong_A_003", "SE_Loong_A_004_b" }, "SE_Loong_T_001", null, null, null, 34, 72, null, "SE_Loong_C_011", isElite: false));
		_dataArray.Add(new AnimalItem(66, new short[1] { 283 }, "Loong", "Loong_", new List<sbyte> { 23, 18, 40 }, new List<string> { "Particle_Loong_A_001_a", "Particle_Loong_A_003", "Particle_Loong_A_004_b" }, new List<string> { "SE_Loong_A_001_a", "SE_Loong_A_003", "SE_Loong_A_004_b" }, "SE_Loong_T_001", null, null, null, 34, 73, null, "SE_Loong_C_011", isElite: false));
		_dataArray.Add(new AnimalItem(67, new short[1] { 284 }, "Loong", "Loong_", new List<sbyte> { 23, 18, 40 }, new List<string> { "Particle_Loong_A_001_a", "Particle_Loong_A_003", "Particle_Loong_A_004_b" }, new List<string> { "SE_Loong_A_001_a", "SE_Loong_A_003", "SE_Loong_A_004_b" }, "SE_Loong_T_001", null, null, null, 34, 74, null, "SE_Loong_C_011", isElite: false));
		_dataArray.Add(new AnimalItem(68, new short[1] { 285 }, "Loong", "Loong_", new List<sbyte> { 23, 18, 40 }, new List<string> { "Particle_Loong_A_001_a", "Particle_Loong_A_003", "Particle_Loong_A_004_b" }, new List<string> { "SE_Loong_A_001_a", "SE_Loong_A_003", "SE_Loong_A_004_b" }, "SE_Loong_T_001", null, null, null, 34, 75, null, "SE_Loong_C_011", isElite: false));
		_dataArray.Add(new AnimalItem(69, new short[1] { 286 }, "Loong", "Loong_", new List<sbyte> { 23, 18, 40 }, new List<string> { "Particle_Loong_A_001_a", "Particle_Loong_A_003", "Particle_Loong_A_004_b" }, new List<string> { "SE_Loong_A_001_a", "SE_Loong_A_003", "SE_Loong_A_004_b" }, "SE_Loong_T_001", null, null, null, 34, 76, null, "SE_Loong_C_011", isElite: false));
		_dataArray.Add(new AnimalItem(70, new short[1] { 287 }, "dragon_qiuniu", "dragon_qiuniu_", new List<sbyte> { 60, 16 }, new List<string> { "Particle_dragon_qiuniu_A_009_0", "Particle_dragon_qiuniu_A_009_1" }, new List<string> { "SE_dragon_qiuniu_A_009_0", "SE_dragon_qiuniu_A_009_1" }, "SE_dragon_qiuniu_T_001", null, new List<string> { "se_combat_foot_dragon_qiuniu_1", "se_combat_foot_dragon_qiuniu_2", "se_combat_foot_dragon_qiuniu_3" }, null, 35, 77, null, "SE_dragon_qiuniu_C_011", isElite: true));
		_dataArray.Add(new AnimalItem(71, new short[1] { 288 }, "dragon_yazi", "dragon_yazi_", new List<sbyte> { 20, 30 }, new List<string> { "Particle_dragon_yazi_A_003", "Particle_dragon_yazi_A_002" }, new List<string> { "SE_dragon_yazi_A_003", "SE_dragon_yazi_A_002" }, "SE_dragon_yazi_T_001", null, new List<string> { "se_combat_foot_dragon_yazi_1", "se_combat_foot_dragon_yazi_2", "se_combat_foot_dragon_yazi_3" }, null, 36, 78, null, "SE_dragon_yazi_C_011", isElite: true));
		_dataArray.Add(new AnimalItem(72, new short[1] { 289 }, "dragon_chaofeng", "dragon_chaofeng_", new List<sbyte> { 60, 20 }, new List<string> { "Particle_dragon_chaofeng_A_003", "Particle_dragon_chaofeng_A_002" }, new List<string> { "SE_dragon_chaofeng_A_003", "SE_dragon_chaofeng_A_002" }, "SE_dragon_chaofeng_T_001", null, new List<string> { "se_combat_foot_dragon_chaofeng_1", "se_combat_foot_dragon_chaofeng_2", "se_combat_foot_dragon_chaofeng_3" }, null, 37, 79, null, "SE_dragon_chaofeng_C_011", isElite: true));
		_dataArray.Add(new AnimalItem(73, new short[1] { 290 }, "dragon_pulao", "dragon_pulao_", new List<sbyte> { 40, 60 }, new List<string> { "Particle_dragon_pulao_A_003", "Particle_dragon_pulao_A_001" }, new List<string> { "SE_dragon_pulao_A_003", "SE_dragon_pulao_A_001" }, "SE_dragon_pulao_T_001", null, new List<string> { "se_combat_foot_dragon_pulao_1", "se_combat_foot_dragon_pulao_2", "se_combat_foot_dragon_pulao_3" }, null, 38, 80, null, "SE_dragon_pulao_C_011", isElite: true));
		_dataArray.Add(new AnimalItem(74, new short[1] { 291 }, "dragon_suanni", "dragon_suanni_", new List<sbyte> { 18, 18 }, new List<string> { "Particle_dragon_suanni_A_003", "Particle_dragon_suanni_A_002" }, new List<string> { "SE_dragon_suanni_A_003", "SE_dragon_suanni_A_002" }, "SE_dragon_suanni_T_001", null, new List<string> { "se_combat_foot_dragon_suanni_1", "se_combat_foot_dragon_suanni_2", "se_combat_foot_dragon_suanni_3" }, null, 39, 81, null, "SE_dragon_suanni_C_011", isElite: true));
		_dataArray.Add(new AnimalItem(75, new short[1] { 292 }, "dragon_baxia", "dragon_baxia_", new List<sbyte> { 22, 40 }, new List<string> { "Particle_dragon_baxia_A_001", "Particle_dragon_baxia_A_004" }, new List<string> { "SE_dragon_baxia_A_001", "SE_dragon_baxia_A_004" }, "SE_dragon_baxia_T_001", null, new List<string> { "se_combat_foot_dragon_baxia_1", "se_combat_foot_dragon_baxia_2", "se_combat_foot_dragon_baxia_3" }, null, 40, 82, null, "SE_dragon_baxia_C_011", isElite: true));
		_dataArray.Add(new AnimalItem(76, new short[1] { 293 }, "dragon_bian", "dragon_bian_", new List<sbyte> { 20, 20 }, new List<string> { "Particle_dragon_bian_A_003", "Particle_dragon_bian_A_002" }, new List<string> { "SE_dragon_bian_A_003", "SE_dragon_bian_A_002" }, "SE_dragon_bian_T_001", null, new List<string> { "se_combat_foot_dragon_bian_1", "se_combat_foot_dragon_bian_2", "se_combat_foot_dragon_bian_3" }, null, 41, 83, null, "SE_dragon_bian_C_011", isElite: true));
		_dataArray.Add(new AnimalItem(77, new short[1] { 294 }, "Loong", "Loong_", new List<sbyte> { 27, 50 }, new List<string> { "Particle_Loong_A_003", "Particle_Loong_A_004_b" }, new List<string> { "SE_Loong_A_003", "SE_Loong_A_004_b" }, "SE_Loong_T_001", null, null, null, 42, 84, null, "SE_Loong_C_011", isElite: true));
		_dataArray.Add(new AnimalItem(78, new short[1] { 295 }, "dragon_chiwen", "dragon_chiwen_", new List<sbyte> { 46, 60 }, new List<string> { "Particle_dragon_chiwen_A_003", "Particle_dragon_chiwen_A_002" }, new List<string> { "SE_dragon_chiwen_A_003", "SE_dragon_chiwen_A_002" }, "SE_dragon_chiwen_T_001", null, null, null, 43, 85, null, "SE_dragon_chiwen_C_011", isElite: true));
		_dataArray.Add(new AnimalItem(79, new short[5] { 939, 940, 941, 942, 943 }, "qingjiao", "qingjiao_", new List<sbyte> { 18, 34, 40 }, new List<string> { "Particle_qingjiao_A_003", "Particle_qingjiao_A_002", "Particle_qingjiao_A_004_b" }, new List<string> { "SE_qingjiao_A_003", "SE_qingjiao_A_002", "SE_qingjiao_A_004_b" }, "SE_qingjiao_T_001", null, null, null, 34, 48, null, "SE_qingjiao_C_011", isElite: false));
		_dataArray.Add(new AnimalItem(80, new short[1] { 1037 }, "sibuxiang", "sibuxiang_", new List<sbyte> { 60, 20 }, new List<string> { "Particle_sibuxiang_A_001", "Particle_sibuxiang_A_004" }, new List<string> { "SE_dragon_qiuniu_A_009_0", "SE_dragon_qiuniu_A_009_1" }, "SE_dragon_qiuniu_T_001", null, new List<string> { "se_combat_foot_dragon_qiuniu_1", "se_combat_foot_dragon_qiuniu_2", "se_combat_foot_dragon_qiuniu_3" }, null, -1, -1, null, null, isElite: false));
		_dataArray.Add(new AnimalItem(81, new short[1] { 1038 }, "zhiren", "zhiren_", new List<sbyte> { 20, 20 }, new List<string> { "Particle_zhiren_A_001", "Particle_zhiren_A_002" }, new List<string> { "SE_boss3_A_000_0_0", "SE_boss3_A_000_0_1" }, "se_combat_hit_wood_1", null, new List<string> { "se_combat_foot_wood_1", "se_combat_foot_wood_2", "se_combat_foot_wood_3" }, null, -1, -1, null, null, isElite: false));
		_dataArray.Add(new AnimalItem(82, new short[1] { 1039 }, "banshanhuogui", "banshanhuogui_", new List<sbyte> { 20, 20 }, new List<string> { "Particle_banshanhuogui_A_001", "Particle_banshanhuogui_A_004" }, new List<string> { "SE_dragon_baxia_A_001", "SE_dragon_baxia_A_004" }, "SE_dragon_baxia_T_001", null, new List<string> { "se_combat_foot_dragon_baxia_1", "se_combat_foot_dragon_baxia_2", "se_combat_foot_dragon_baxia_3" }, null, -1, -1, null, null, isElite: false));
		_dataArray.Add(new AnimalItem(83, new short[1] { 1040 }, "moqilin", "moqilin_", new List<sbyte> { 40, 20 }, new List<string> { "Particle_moqilin_A_001", "Particle_moqilin_A_004" }, new List<string> { "SE_dragon_yazi_A_002", "SE_dragon_yazi_A_003" }, "SE_dragon_yazi_T_001", null, new List<string> { "se_combat_foot_dragon_yazi_1", "se_combat_foot_dragon_yazi_2", "se_combat_foot_dragon_yazi_3" }, null, -1, -1, null, null, isElite: false));
		_dataArray.Add(new AnimalItem(84, new short[1] { 1041 }, "pixingfeiwu", "pixingfeiwu_", new List<sbyte> { 30, 20 }, new List<string> { "Particle_pixingfeiwu_A_004", "Particle_pixingfeiwu_A_002" }, new List<string> { "SE_loong_A_002", "SE_loong_A_004" }, "SE_Loong_T_001", null, null, null, -1, -1, null, null, isElite: false));
		_dataArray.Add(new AnimalItem(85, new short[1] { 1042 }, "xuanjiu", "xuanjiu_", new List<sbyte> { 13, 40 }, new List<string> { "Particle_xuanjiu_A_002", "Particle_xuanjiu_A_003" }, new List<string> { "SE_eagle_A_002 ", "SE_eagle_A_003" }, "SE_eagle_A_002", null, new List<string> { "se_combat_foot_eagle_1", "se_combat_foot_eagle_2", "se_combat_foot_eagle_3" }, null, -1, -1, null, null, isElite: false));
		_dataArray.Add(new AnimalItem(86, new short[1] { 1043 }, "yuanqiu", "yuanqiu_", new List<sbyte> { 40, 32 }, new List<string> { "Particle_yuanqiu_A_004", "Particle_yuanqiu_A_002" }, new List<string> { "SE_loong_A_002", "SE_loong_A_004" }, "SE_Loong_T_001", null, null, null, -1, -1, null, null, isElite: false));
		_dataArray.Add(new AnimalItem(87, new short[1] { 1044 }, "bainiu", "bainiu_", new List<sbyte> { 20, 20 }, new List<string> { "Particle_bainiu_A_001", "Particle_bainiu_A_004" }, new List<string> { "SE_bull_A_001", "SE_bull_A_004" }, "SE_bull_A_004", null, new List<string> { "se_combat_foot_bull_1", "se_combat_foot_bull_2", "se_combat_foot_bull_3" }, null, -1, -1, null, null, isElite: false));
		_dataArray.Add(new AnimalItem(88, new short[1] { 1045 }, "sanyanxiao", "sanyanxiao_", new List<sbyte> { 20, 18 }, new List<string> { "Particle_sanyanxiao_A_001", "Particle_sanyanxiao_A_002" }, new List<string> { "SE_monkey_A_001", "SE_monkey_A_002" }, "SE_monkey_A_003", null, new List<string> { "se_combat_foot_monkey_1", "se_combat_foot_monkey_2", "se_combat_foot_monkey_3" }, null, -1, -1, null, null, isElite: false));
		_dataArray.Add(new AnimalItem(89, new short[1] { 1046 }, "heishanjun", "heishanjun_", new List<sbyte> { 40, 22, 14 }, new List<string> { "Particle_heishanjun_A_001", "Particle_heishanjun_A_002", "Particle_heishanjun_A_003" }, new List<string> { "SE_lion_A_001", "SE_lion_A_002", "SE_lion_A_003" }, "SE_lion_A_002", null, new List<string> { "se_combat_foot_tiger_1", "se_combat_foot_tiger_2", "se_combat_foot_tiger_3" }, null, -1, -1, null, null, isElite: false));
		_dataArray.Add(new AnimalItem(90, new short[1] { 1047 }, "jiutoushe", "jiutoushe_", new List<sbyte> { 40, 10 }, new List<string> { "Particle_jiutoushe_A_001", "Particle_jiutoushe_A_003" }, new List<string> { "SE_snake_A_003", "SE_snake_A_003" }, "SE_snake_A_003", null, null, null, -1, -1, null, null, isElite: false));
		_dataArray.Add(new AnimalItem(91, new short[2] { 1097, 1112 }, "boss15", "boss15_", new List<sbyte> { 40, 50 }, new List<string> { "Particle_boss15_A_000_0" }, new List<string> { "SE_boss15_A_000_0" }, "se_combat_hit_cloth_1", null, null, null, -1, -1, null, "SE_boss15_C_005", isElite: false));
		_dataArray.Add(new AnimalItem(92, new short[5] { 1132, 1133, 1134, 1135, 1136 }, "snake_elite", "snake_elite_", new List<sbyte> { 45, 15 }, new List<string> { "Particle_snake_elite_A_001", "Particle_snake_elite_A_003" }, new List<string> { "SE_snake_elite_A_001", "SE_snake_elite_A_003" }, "SE_snake_A_003", null, null, null, -1, -1, null, null, isElite: true));
		_dataArray.Add(new AnimalItem(93, new short[5] { 1137, 1138, 1139, 1140, 1141 }, "snake_elite", "snake_elite_", new List<sbyte> { 45, 15 }, new List<string> { "Particle_snake_elite_A_001", "Particle_snake_elite_A_003" }, new List<string> { "SE_snake_elite_A_001", "SE_snake_elite_A_003" }, "SE_snake_A_003", null, null, null, -1, -1, null, null, isElite: true));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<AnimalItem>(94);
		CreateItems0();
		CreateItems1();
	}
}
