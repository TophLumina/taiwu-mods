using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class Animal : ConfigData<AnimalItem, sbyte>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 熊0
		/// </summary>
		public const sbyte bear = 0;

		/// <summary>
		/// 牛0
		/// </summary>
		public const sbyte bull = 1;

		/// <summary>
		/// 鹰0
		/// </summary>
		public const sbyte eagle = 2;

		/// <summary>
		/// 豹0
		/// </summary>
		public const sbyte jaguar = 3;

		/// <summary>
		/// 狮0
		/// </summary>
		public const sbyte lion = 4;

		/// <summary>
		/// 猴0
		/// </summary>
		public const sbyte monkey = 5;

		/// <summary>
		/// 猪0
		/// </summary>
		public const sbyte pig = 6;

		/// <summary>
		/// 蛇0
		/// </summary>
		public const sbyte snake = 7;

		/// <summary>
		/// 虎0
		/// </summary>
		public const sbyte tiger = 8;

		/// <summary>
		/// 熊1
		/// </summary>
		public const sbyte bear_elite = 9;

		/// <summary>
		/// 牛1
		/// </summary>
		public const sbyte bull_elite = 10;

		/// <summary>
		/// 鹰1
		/// </summary>
		public const sbyte eagle_elite = 11;

		/// <summary>
		/// 豹1
		/// </summary>
		public const sbyte jaguar_elite = 12;

		/// <summary>
		/// 狮1
		/// </summary>
		public const sbyte lion_elite = 13;

		/// <summary>
		/// 猴1
		/// </summary>
		public const sbyte monkey_elite = 14;

		/// <summary>
		/// 猪1
		/// </summary>
		public const sbyte pig_elite = 15;

		/// <summary>
		/// 蛇1
		/// </summary>
		public const sbyte snake_elite = 16;

		/// <summary>
		/// 虎1
		/// </summary>
		public const sbyte tiger_elite = 17;

		/// <summary>
		/// 猴2
		/// </summary>
		public const sbyte monkey_king = 18;

		/// <summary>
		/// 流金火蛇
		/// </summary>
		public const sbyte LiujinHuoSerpent = 19;

		/// <summary>
		/// 蠹经蛇
		/// </summary>
		public const sbyte DujingSerpent = 20;

		/// <summary>
		/// 断邪
		/// </summary>
		public const sbyte DuanxieSerpent = 21;

		/// <summary>
		/// 日魂朱景
		/// </summary>
		public const sbyte RihunzhujingSerpen = 22;

		/// <summary>
		/// 朱炎
		/// </summary>
		public const sbyte ZhuyanSerpent = 23;

		/// <summary>
		/// 玄州金蛇
		/// </summary>
		public const sbyte XuanzhoujinSerpent = 24;

		/// <summary>
		/// 天烛
		/// </summary>
		public const sbyte TianzhuSerpent = 25;

		/// <summary>
		/// 九赤斑蛇
		/// </summary>
		public const sbyte JiuchibanSerpent = 26;

		/// <summary>
		/// 瑞蛇
		/// </summary>
		public const sbyte RuiSerpent = 27;

		/// <summary>
		/// 炁蛇
		/// </summary>
		public const sbyte QiSerpent0 = 28;

		/// <summary>
		/// 四不像
		/// </summary>
		public const sbyte Sibuxiang = 80;

		/// <summary>
		/// 芝人
		/// </summary>
		public const sbyte Zhiren = 81;

		/// <summary>
		/// 搬山火龟
		/// </summary>
		public const sbyte Banshanhuogui = 82;

		/// <summary>
		/// 墨麒麟
		/// </summary>
		public const sbyte Moqilin = 83;

		/// <summary>
		/// 披星飞蜈
		/// </summary>
		public const sbyte Pixingfeiwu = 84;

		/// <summary>
		/// 玄鸠
		/// </summary>
		public const sbyte Xuanjiu = 85;

		/// <summary>
		/// 渊虬
		/// </summary>
		public const sbyte Yuanqiu = 86;

		/// <summary>
		/// 白牛
		/// </summary>
		public const sbyte Bainiu = 87;

		/// <summary>
		/// 三眼魈
		/// </summary>
		public const sbyte Sanyanxiao = 88;

		/// <summary>
		/// 黑山君
		/// </summary>
		public const sbyte Heishanjun = 89;

		/// <summary>
		/// 九头虫
		/// </summary>
		public const sbyte Jiutouchong = 90;

		/// <summary>
		/// 青翠幽影
		/// </summary>
		public const sbyte Qingcuiyouying = 79;

		/// <summary>
		/// 白龙
		/// </summary>
		public const sbyte LoongWhite = 29;

		/// <summary>
		/// 黑龙
		/// </summary>
		public const sbyte LoongBlack = 30;

		/// <summary>
		/// 青龙
		/// </summary>
		public const sbyte LoongGreen = 31;

		/// <summary>
		/// 赤龙
		/// </summary>
		public const sbyte LoongRed = 32;

		/// <summary>
		/// 黄龙
		/// </summary>
		public const sbyte LoongYellow = 33;

		/// <summary>
		/// 小白龙
		/// </summary>
		public const sbyte MinionLoongWhite = 34;

		/// <summary>
		/// 小黑龙
		/// </summary>
		public const sbyte MinionLoongBlack = 35;

		/// <summary>
		/// 小青龙
		/// </summary>
		public const sbyte MinionLoongGreen = 36;

		/// <summary>
		/// 小赤龙
		/// </summary>
		public const sbyte MinionLoongRed = 37;

		/// <summary>
		/// 小黄龙
		/// </summary>
		public const sbyte MinionLoongYellow = 38;

		/// <summary>
		/// 白蛟
		/// </summary>
		public const sbyte JiaoWhite = 39;

		/// <summary>
		/// 黑蛟
		/// </summary>
		public const sbyte JiaoBlack = 40;

		/// <summary>
		/// 青蛟
		/// </summary>
		public const sbyte JiaoGreen = 41;

		/// <summary>
		/// 赤蛟
		/// </summary>
		public const sbyte JiaoRed = 42;

		/// <summary>
		/// 黄蛟
		/// </summary>
		public const sbyte JiaoYellow = 43;

		/// <summary>
		/// 白黑蛟
		/// </summary>
		public const sbyte JiaoWB = 44;

		/// <summary>
		/// 白青蛟
		/// </summary>
		public const sbyte JiaoWG = 45;

		/// <summary>
		/// 白赤蛟
		/// </summary>
		public const sbyte JiaoWR = 46;

		/// <summary>
		/// 白黄蛟
		/// </summary>
		public const sbyte JiaoWY = 47;

		/// <summary>
		/// 黑青蛟
		/// </summary>
		public const sbyte JiaoBG = 48;

		/// <summary>
		/// 黑赤蛟
		/// </summary>
		public const sbyte JiaoBR = 49;

		/// <summary>
		/// 黑黄蛟
		/// </summary>
		public const sbyte JiaoBY = 50;

		/// <summary>
		/// 青赤蛟
		/// </summary>
		public const sbyte JiaoGR = 51;

		/// <summary>
		/// 青黄蛟
		/// </summary>
		public const sbyte JiaoGY = 52;

		/// <summary>
		/// 赤黄蛟
		/// </summary>
		public const sbyte JiaoRY = 53;

		/// <summary>
		/// 白黑青蛟
		/// </summary>
		public const sbyte JiaoWBG = 54;

		/// <summary>
		/// 白黑赤蛟
		/// </summary>
		public const sbyte JiaoWBR = 55;

		/// <summary>
		/// 白黑黄蛟
		/// </summary>
		public const sbyte JiaoWBY = 56;

		/// <summary>
		/// 白青赤蛟
		/// </summary>
		public const sbyte JiaoWGR = 57;

		/// <summary>
		/// 白青黄蛟
		/// </summary>
		public const sbyte JiaoWGY = 58;

		/// <summary>
		/// 白赤黄蛟
		/// </summary>
		public const sbyte JiaoWRY = 59;

		/// <summary>
		/// 黑青赤蛟
		/// </summary>
		public const sbyte JiaoBGR = 60;

		/// <summary>
		/// 黑青黄蛟
		/// </summary>
		public const sbyte JiaoBGY = 61;

		/// <summary>
		/// 黑赤黄蛟
		/// </summary>
		public const sbyte JiaoBRY = 62;

		/// <summary>
		/// 青赤黄蛟
		/// </summary>
		public const sbyte JiaoGRY = 63;

		/// <summary>
		/// 白黑青赤蛟
		/// </summary>
		public const sbyte JiaoWBGR = 64;

		/// <summary>
		/// 白黑青黄蛟
		/// </summary>
		public const sbyte JiaoWBGY = 65;

		/// <summary>
		/// 白黑赤黄蛟
		/// </summary>
		public const sbyte JiaoWBRY = 66;

		/// <summary>
		/// 白青赤黄蛟
		/// </summary>
		public const sbyte JiaoWGRY = 67;

		/// <summary>
		/// 黑青赤黄蛟
		/// </summary>
		public const sbyte JiaoBGRY = 68;

		/// <summary>
		/// 白青赤黄黑蛟
		/// </summary>
		public const sbyte JiaoWGRYB = 69;

		/// <summary>
		/// 囚牛
		/// </summary>
		public const sbyte Qiuniu = 70;

		/// <summary>
		/// 睚眦
		/// </summary>
		public const sbyte Yazi = 71;

		/// <summary>
		/// 嘲风
		/// </summary>
		public const sbyte Chaofeng = 72;

		/// <summary>
		/// 蒲牢
		/// </summary>
		public const sbyte Pulao = 73;

		/// <summary>
		/// 狻猊
		/// </summary>
		public const sbyte Suanni = 74;

		/// <summary>
		/// 霸下
		/// </summary>
		public const sbyte Baxia = 75;

		/// <summary>
		/// 狴犴
		/// </summary>
		public const sbyte Bian = 76;

		/// <summary>
		/// 负屃
		/// </summary>
		public const sbyte Fuxi = 77;

		/// <summary>
		/// 螭吻
		/// </summary>
		public const sbyte Chiwen = 78;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 熊0
		/// </summary>
		public static AnimalItem bear => Instance[(sbyte)0];

		/// <summary>
		/// 牛0
		/// </summary>
		public static AnimalItem bull => Instance[(sbyte)1];

		/// <summary>
		/// 鹰0
		/// </summary>
		public static AnimalItem eagle => Instance[(sbyte)2];

		/// <summary>
		/// 豹0
		/// </summary>
		public static AnimalItem jaguar => Instance[(sbyte)3];

		/// <summary>
		/// 狮0
		/// </summary>
		public static AnimalItem lion => Instance[(sbyte)4];

		/// <summary>
		/// 猴0
		/// </summary>
		public static AnimalItem monkey => Instance[(sbyte)5];

		/// <summary>
		/// 猪0
		/// </summary>
		public static AnimalItem pig => Instance[(sbyte)6];

		/// <summary>
		/// 蛇0
		/// </summary>
		public static AnimalItem snake => Instance[(sbyte)7];

		/// <summary>
		/// 虎0
		/// </summary>
		public static AnimalItem tiger => Instance[(sbyte)8];

		/// <summary>
		/// 熊1
		/// </summary>
		public static AnimalItem bear_elite => Instance[(sbyte)9];

		/// <summary>
		/// 牛1
		/// </summary>
		public static AnimalItem bull_elite => Instance[(sbyte)10];

		/// <summary>
		/// 鹰1
		/// </summary>
		public static AnimalItem eagle_elite => Instance[(sbyte)11];

		/// <summary>
		/// 豹1
		/// </summary>
		public static AnimalItem jaguar_elite => Instance[(sbyte)12];

		/// <summary>
		/// 狮1
		/// </summary>
		public static AnimalItem lion_elite => Instance[(sbyte)13];

		/// <summary>
		/// 猴1
		/// </summary>
		public static AnimalItem monkey_elite => Instance[(sbyte)14];

		/// <summary>
		/// 猪1
		/// </summary>
		public static AnimalItem pig_elite => Instance[(sbyte)15];

		/// <summary>
		/// 蛇1
		/// </summary>
		public static AnimalItem snake_elite => Instance[(sbyte)16];

		/// <summary>
		/// 虎1
		/// </summary>
		public static AnimalItem tiger_elite => Instance[(sbyte)17];

		/// <summary>
		/// 猴2
		/// </summary>
		public static AnimalItem monkey_king => Instance[(sbyte)18];

		/// <summary>
		/// 流金火蛇
		/// </summary>
		public static AnimalItem LiujinHuoSerpent => Instance[(sbyte)19];

		/// <summary>
		/// 蠹经蛇
		/// </summary>
		public static AnimalItem DujingSerpent => Instance[(sbyte)20];

		/// <summary>
		/// 断邪
		/// </summary>
		public static AnimalItem DuanxieSerpent => Instance[(sbyte)21];

		/// <summary>
		/// 日魂朱景
		/// </summary>
		public static AnimalItem RihunzhujingSerpen => Instance[(sbyte)22];

		/// <summary>
		/// 朱炎
		/// </summary>
		public static AnimalItem ZhuyanSerpent => Instance[(sbyte)23];

		/// <summary>
		/// 玄州金蛇
		/// </summary>
		public static AnimalItem XuanzhoujinSerpent => Instance[(sbyte)24];

		/// <summary>
		/// 天烛
		/// </summary>
		public static AnimalItem TianzhuSerpent => Instance[(sbyte)25];

		/// <summary>
		/// 九赤斑蛇
		/// </summary>
		public static AnimalItem JiuchibanSerpent => Instance[(sbyte)26];

		/// <summary>
		/// 瑞蛇
		/// </summary>
		public static AnimalItem RuiSerpent => Instance[(sbyte)27];

		/// <summary>
		/// 炁蛇
		/// </summary>
		public static AnimalItem QiSerpent0 => Instance[(sbyte)28];

		/// <summary>
		/// 四不像
		/// </summary>
		public static AnimalItem Sibuxiang => Instance[(sbyte)80];

		/// <summary>
		/// 芝人
		/// </summary>
		public static AnimalItem Zhiren => Instance[(sbyte)81];

		/// <summary>
		/// 搬山火龟
		/// </summary>
		public static AnimalItem Banshanhuogui => Instance[(sbyte)82];

		/// <summary>
		/// 墨麒麟
		/// </summary>
		public static AnimalItem Moqilin => Instance[(sbyte)83];

		/// <summary>
		/// 披星飞蜈
		/// </summary>
		public static AnimalItem Pixingfeiwu => Instance[(sbyte)84];

		/// <summary>
		/// 玄鸠
		/// </summary>
		public static AnimalItem Xuanjiu => Instance[(sbyte)85];

		/// <summary>
		/// 渊虬
		/// </summary>
		public static AnimalItem Yuanqiu => Instance[(sbyte)86];

		/// <summary>
		/// 白牛
		/// </summary>
		public static AnimalItem Bainiu => Instance[(sbyte)87];

		/// <summary>
		/// 三眼魈
		/// </summary>
		public static AnimalItem Sanyanxiao => Instance[(sbyte)88];

		/// <summary>
		/// 黑山君
		/// </summary>
		public static AnimalItem Heishanjun => Instance[(sbyte)89];

		/// <summary>
		/// 九头虫
		/// </summary>
		public static AnimalItem Jiutouchong => Instance[(sbyte)90];

		/// <summary>
		/// 青翠幽影
		/// </summary>
		public static AnimalItem Qingcuiyouying => Instance[(sbyte)79];

		/// <summary>
		/// 白龙
		/// </summary>
		public static AnimalItem LoongWhite => Instance[(sbyte)29];

		/// <summary>
		/// 黑龙
		/// </summary>
		public static AnimalItem LoongBlack => Instance[(sbyte)30];

		/// <summary>
		/// 青龙
		/// </summary>
		public static AnimalItem LoongGreen => Instance[(sbyte)31];

		/// <summary>
		/// 赤龙
		/// </summary>
		public static AnimalItem LoongRed => Instance[(sbyte)32];

		/// <summary>
		/// 黄龙
		/// </summary>
		public static AnimalItem LoongYellow => Instance[(sbyte)33];

		/// <summary>
		/// 小白龙
		/// </summary>
		public static AnimalItem MinionLoongWhite => Instance[(sbyte)34];

		/// <summary>
		/// 小黑龙
		/// </summary>
		public static AnimalItem MinionLoongBlack => Instance[(sbyte)35];

		/// <summary>
		/// 小青龙
		/// </summary>
		public static AnimalItem MinionLoongGreen => Instance[(sbyte)36];

		/// <summary>
		/// 小赤龙
		/// </summary>
		public static AnimalItem MinionLoongRed => Instance[(sbyte)37];

		/// <summary>
		/// 小黄龙
		/// </summary>
		public static AnimalItem MinionLoongYellow => Instance[(sbyte)38];

		/// <summary>
		/// 白蛟
		/// </summary>
		public static AnimalItem JiaoWhite => Instance[(sbyte)39];

		/// <summary>
		/// 黑蛟
		/// </summary>
		public static AnimalItem JiaoBlack => Instance[(sbyte)40];

		/// <summary>
		/// 青蛟
		/// </summary>
		public static AnimalItem JiaoGreen => Instance[(sbyte)41];

		/// <summary>
		/// 赤蛟
		/// </summary>
		public static AnimalItem JiaoRed => Instance[(sbyte)42];

		/// <summary>
		/// 黄蛟
		/// </summary>
		public static AnimalItem JiaoYellow => Instance[(sbyte)43];

		/// <summary>
		/// 白黑蛟
		/// </summary>
		public static AnimalItem JiaoWB => Instance[(sbyte)44];

		/// <summary>
		/// 白青蛟
		/// </summary>
		public static AnimalItem JiaoWG => Instance[(sbyte)45];

		/// <summary>
		/// 白赤蛟
		/// </summary>
		public static AnimalItem JiaoWR => Instance[(sbyte)46];

		/// <summary>
		/// 白黄蛟
		/// </summary>
		public static AnimalItem JiaoWY => Instance[(sbyte)47];

		/// <summary>
		/// 黑青蛟
		/// </summary>
		public static AnimalItem JiaoBG => Instance[(sbyte)48];

		/// <summary>
		/// 黑赤蛟
		/// </summary>
		public static AnimalItem JiaoBR => Instance[(sbyte)49];

		/// <summary>
		/// 黑黄蛟
		/// </summary>
		public static AnimalItem JiaoBY => Instance[(sbyte)50];

		/// <summary>
		/// 青赤蛟
		/// </summary>
		public static AnimalItem JiaoGR => Instance[(sbyte)51];

		/// <summary>
		/// 青黄蛟
		/// </summary>
		public static AnimalItem JiaoGY => Instance[(sbyte)52];

		/// <summary>
		/// 赤黄蛟
		/// </summary>
		public static AnimalItem JiaoRY => Instance[(sbyte)53];

		/// <summary>
		/// 白黑青蛟
		/// </summary>
		public static AnimalItem JiaoWBG => Instance[(sbyte)54];

		/// <summary>
		/// 白黑赤蛟
		/// </summary>
		public static AnimalItem JiaoWBR => Instance[(sbyte)55];

		/// <summary>
		/// 白黑黄蛟
		/// </summary>
		public static AnimalItem JiaoWBY => Instance[(sbyte)56];

		/// <summary>
		/// 白青赤蛟
		/// </summary>
		public static AnimalItem JiaoWGR => Instance[(sbyte)57];

		/// <summary>
		/// 白青黄蛟
		/// </summary>
		public static AnimalItem JiaoWGY => Instance[(sbyte)58];

		/// <summary>
		/// 白赤黄蛟
		/// </summary>
		public static AnimalItem JiaoWRY => Instance[(sbyte)59];

		/// <summary>
		/// 黑青赤蛟
		/// </summary>
		public static AnimalItem JiaoBGR => Instance[(sbyte)60];

		/// <summary>
		/// 黑青黄蛟
		/// </summary>
		public static AnimalItem JiaoBGY => Instance[(sbyte)61];

		/// <summary>
		/// 黑赤黄蛟
		/// </summary>
		public static AnimalItem JiaoBRY => Instance[(sbyte)62];

		/// <summary>
		/// 青赤黄蛟
		/// </summary>
		public static AnimalItem JiaoGRY => Instance[(sbyte)63];

		/// <summary>
		/// 白黑青赤蛟
		/// </summary>
		public static AnimalItem JiaoWBGR => Instance[(sbyte)64];

		/// <summary>
		/// 白黑青黄蛟
		/// </summary>
		public static AnimalItem JiaoWBGY => Instance[(sbyte)65];

		/// <summary>
		/// 白黑赤黄蛟
		/// </summary>
		public static AnimalItem JiaoWBRY => Instance[(sbyte)66];

		/// <summary>
		/// 白青赤黄蛟
		/// </summary>
		public static AnimalItem JiaoWGRY => Instance[(sbyte)67];

		/// <summary>
		/// 黑青赤黄蛟
		/// </summary>
		public static AnimalItem JiaoBGRY => Instance[(sbyte)68];

		/// <summary>
		/// 白青赤黄黑蛟
		/// </summary>
		public static AnimalItem JiaoWGRYB => Instance[(sbyte)69];

		/// <summary>
		/// 囚牛
		/// </summary>
		public static AnimalItem Qiuniu => Instance[(sbyte)70];

		/// <summary>
		/// 睚眦
		/// </summary>
		public static AnimalItem Yazi => Instance[(sbyte)71];

		/// <summary>
		/// 嘲风
		/// </summary>
		public static AnimalItem Chaofeng => Instance[(sbyte)72];

		/// <summary>
		/// 蒲牢
		/// </summary>
		public static AnimalItem Pulao => Instance[(sbyte)73];

		/// <summary>
		/// 狻猊
		/// </summary>
		public static AnimalItem Suanni => Instance[(sbyte)74];

		/// <summary>
		/// 霸下
		/// </summary>
		public static AnimalItem Baxia => Instance[(sbyte)75];

		/// <summary>
		/// 狴犴
		/// </summary>
		public static AnimalItem Bian => Instance[(sbyte)76];

		/// <summary>
		/// 负屃
		/// </summary>
		public static AnimalItem Fuxi => Instance[(sbyte)77];

		/// <summary>
		/// 螭吻
		/// </summary>
		public static AnimalItem Chiwen => Instance[(sbyte)78];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
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
		_dataArray.Add(new AnimalItem(29, new short[1] { 246 }, "Loong", "Loong_", new List<sbyte> { 18, 34, 40 }, new List<string> { "Particle_Loong_A_003", "Particle_Loong_A_002", "Particle_Loong_A_004" }, new List<string> { "SE_Loong_A_003", "SE_Loong_A_002", "SE_Loong_A_004" }, "SE_Loong_T_001", null, null, null, 33, 46, null, "SE_Loong_C_011", isElite: true));
		_dataArray.Add(new AnimalItem(30, new short[1] { 247 }, "Loong", "Loong_", new List<sbyte> { 18, 34, 40 }, new List<string> { "Particle_Loong_A_003", "Particle_Loong_A_002", "Particle_Loong_A_004_a" }, new List<string> { "SE_Loong_A_003", "SE_Loong_A_002", "SE_Loong_A_004_a" }, "SE_Loong_T_001", null, null, null, 33, 47, null, "SE_Loong_C_011", isElite: true));
		_dataArray.Add(new AnimalItem(31, new short[1] { 248 }, "Loong", "Loong_", new List<sbyte> { 18, 34, 40 }, new List<string> { "Particle_Loong_A_003", "Particle_Loong_A_002", "Particle_Loong_A_004_b" }, new List<string> { "SE_Loong_A_003", "SE_Loong_A_002", "SE_Loong_A_004_b" }, "SE_Loong_T_001", null, null, null, 33, 48, null, "SE_Loong_C_011", isElite: true));
		_dataArray.Add(new AnimalItem(32, new short[1] { 249 }, "Loong", "Loong_", new List<sbyte> { 18, 34, 40 }, new List<string> { "Particle_Loong_A_003", "Particle_Loong_A_002", "Particle_Loong_A_004_a" }, new List<string> { "SE_Loong_A_003", "SE_Loong_A_002", "SE_Loong_A_004_a" }, "SE_Loong_T_001", null, null, null, 33, 49, null, "SE_Loong_C_011", isElite: true));
		_dataArray.Add(new AnimalItem(33, new short[1] { 250 }, "Loong", "Loong_", new List<sbyte> { 23, 34, 40 }, new List<string> { "Particle_Loong_A_001_a", "Particle_Loong_A_002", "Particle_Loong_A_004_a" }, new List<string> { "SE_Loong_A_001_a", "SE_Loong_A_002", "SE_Loong_A_004_a" }, "SE_Loong_T_001", null, null, null, 33, 50, null, "SE_Loong_C_011", isElite: true));
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
