using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class CharacterTableElement : ConfigData<CharacterTableElementItem, short>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 姓名
		/// </summary>
		public const short Avatar = 0;

		/// <summary>
		/// 空格
		/// </summary>
		public const short Empty = 1;

		/// <summary>
		/// 年龄
		/// </summary>
		public const short PhysiologicalAge = 2;

		/// <summary>
		/// 健康
		/// </summary>
		public const short Health = 3;

		/// <summary>
		/// 伤势
		/// </summary>
		public const short Injury = 4;

		/// <summary>
		/// 魅力
		/// </summary>
		public const short Charm = 5;

		/// <summary>
		/// 立场
		/// </summary>
		public const short Behavior = 6;

		/// <summary>
		/// 心情
		/// </summary>
		public const short Happiness = 7;

		/// <summary>
		/// 好感
		/// </summary>
		public const short Favor = 8;

		/// <summary>
		/// 轮回
		/// </summary>
		public const short Preexistence = 9;

		/// <summary>
		/// 名誉
		/// </summary>
		public const short Fame = 10;

		/// <summary>
		/// 膂力
		/// </summary>
		public const short Strength = 11;

		/// <summary>
		/// 灵敏
		/// </summary>
		public const short Dexterity = 12;

		/// <summary>
		/// 定力
		/// </summary>
		public const short Concentration = 13;

		/// <summary>
		/// 体质
		/// </summary>
		public const short Vitality = 14;

		/// <summary>
		/// 根骨
		/// </summary>
		public const short Energy = 15;

		/// <summary>
		/// 悟性
		/// </summary>
		public const short Intelligence = 16;

		/// <summary>
		/// 破体
		/// </summary>
		public const short PenetrateOfOuter = 17;

		/// <summary>
		/// 破气
		/// </summary>
		public const short PenetrateOfInner = 18;

		/// <summary>
		/// 御体
		/// </summary>
		public const short PenetrateResistOfOuter = 19;

		/// <summary>
		/// 御气
		/// </summary>
		public const short PenetrateResistOfInner = 20;

		/// <summary>
		/// 力道
		/// </summary>
		public const short HitRateStrength = 21;

		/// <summary>
		/// 精妙
		/// </summary>
		public const short HitRateTechnique = 22;

		/// <summary>
		/// 迅疾
		/// </summary>
		public const short HitRateSpeed = 23;

		/// <summary>
		/// 动心
		/// </summary>
		public const short HitRateMind = 24;

		/// <summary>
		/// 卸力
		/// </summary>
		public const short AvoidRateStrength = 25;

		/// <summary>
		/// 拆招
		/// </summary>
		public const short AvoidRateTechnique = 26;

		/// <summary>
		/// 闪避
		/// </summary>
		public const short AvoidRateSpeed = 27;

		/// <summary>
		/// 守心
		/// </summary>
		public const short AvoidRateMind = 28;

		/// <summary>
		/// 紊乱
		/// </summary>
		public const short DisorderOfQi = 29;

		/// <summary>
		/// 音律
		/// </summary>
		public const short Music = 30;

		/// <summary>
		/// 弈棋
		/// </summary>
		public const short Chess = 31;

		/// <summary>
		/// 诗书
		/// </summary>
		public const short Poem = 32;

		/// <summary>
		/// 绘画
		/// </summary>
		public const short Painting = 33;

		/// <summary>
		/// 术数
		/// </summary>
		public const short Math = 34;

		/// <summary>
		/// 品鉴
		/// </summary>
		public const short Appraisal = 35;

		/// <summary>
		/// 锻造
		/// </summary>
		public const short Forging = 36;

		/// <summary>
		/// 制木
		/// </summary>
		public const short Woodworking = 37;

		/// <summary>
		/// 医术
		/// </summary>
		public const short Medicine = 38;

		/// <summary>
		/// 毒术
		/// </summary>
		public const short Toxicology = 39;

		/// <summary>
		/// 织锦
		/// </summary>
		public const short Weaving = 40;

		/// <summary>
		/// 巧匠
		/// </summary>
		public const short JadeLifeSkill = 41;

		/// <summary>
		/// 道法
		/// </summary>
		public const short Taoism = 42;

		/// <summary>
		/// 佛学
		/// </summary>
		public const short Buddhism = 43;

		/// <summary>
		/// 厨艺
		/// </summary>
		public const short Cooking = 44;

		/// <summary>
		/// 杂学
		/// </summary>
		public const short Eclectic = 45;

		/// <summary>
		/// 技艺成长
		/// </summary>
		public const short LifeSkillGrowth = 46;

		/// <summary>
		/// 内功
		/// </summary>
		public const short Neigong = 47;

		/// <summary>
		/// 身法
		/// </summary>
		public const short Posing = 48;

		/// <summary>
		/// 绝技
		/// </summary>
		public const short Stunt = 49;

		/// <summary>
		/// 拳掌
		/// </summary>
		public const short FistAndPalm = 50;

		/// <summary>
		/// 指法
		/// </summary>
		public const short Finger = 51;

		/// <summary>
		/// 腿法
		/// </summary>
		public const short Leg = 52;

		/// <summary>
		/// 暗器
		/// </summary>
		public const short Throw = 53;

		/// <summary>
		/// 剑法
		/// </summary>
		public const short Sword = 54;

		/// <summary>
		/// 刀法
		/// </summary>
		public const short Blade = 55;

		/// <summary>
		/// 长兵
		/// </summary>
		public const short Polearm = 56;

		/// <summary>
		/// 奇门
		/// </summary>
		public const short Special = 57;

		/// <summary>
		/// 软兵
		/// </summary>
		public const short Whip = 58;

		/// <summary>
		/// 御射
		/// </summary>
		public const short ControllableShot = 59;

		/// <summary>
		/// 乐器
		/// </summary>
		public const short CombatMusic = 60;

		/// <summary>
		/// 武学成长
		/// </summary>
		public const short CombatSkillGrowth = 61;

		/// <summary>
		/// 冷静
		/// </summary>
		public const short Calm = 62;

		/// <summary>
		/// 聪颖
		/// </summary>
		public const short Clever = 63;

		/// <summary>
		/// 热情
		/// </summary>
		public const short Enthusiastic = 64;

		/// <summary>
		/// 勇壮
		/// </summary>
		public const short Brave = 65;

		/// <summary>
		/// 坚毅
		/// </summary>
		public const short Firm = 66;

		/// <summary>
		/// 福缘
		/// </summary>
		public const short Lucky = 67;

		/// <summary>
		/// 合道
		/// </summary>
		public const short Perceptive = 68;

		/// <summary>
		/// 食材
		/// </summary>
		public const short Food = 69;

		/// <summary>
		/// 木材
		/// </summary>
		public const short Wood = 70;

		/// <summary>
		/// 金铁
		/// </summary>
		public const short Metal = 71;

		/// <summary>
		/// 玉石
		/// </summary>
		public const short JadeResource = 72;

		/// <summary>
		/// 织物
		/// </summary>
		public const short Fabric = 73;

		/// <summary>
		/// 药材
		/// </summary>
		public const short Herb = 74;

		/// <summary>
		/// 银钱
		/// </summary>
		public const short Money = 75;

		/// <summary>
		/// 威望
		/// </summary>
		public const short Authority = 76;

		/// <summary>
		/// 行囊
		/// </summary>
		public const short Weight = 77;

		/// <summary>
		/// 当前负重
		/// </summary>
		public const short CurrLoad = 78;

		/// <summary>
		/// 最大负重
		/// </summary>
		public const short MaxLoad = 79;

		/// <summary>
		/// 关押
		/// </summary>
		public const short Kidnap = 80;

		/// <summary>
		/// 进攻
		/// </summary>
		public const short AttackMedal = 81;

		/// <summary>
		/// 守御
		/// </summary>
		public const short DefenceMedal = 82;

		/// <summary>
		/// 机略
		/// </summary>
		public const short WisdomMedal = 83;

		/// <summary>
		/// 指令1
		/// </summary>
		public const short Command0 = 84;

		/// <summary>
		/// 指令2
		/// </summary>
		public const short Command1 = 85;

		/// <summary>
		/// 指令3
		/// </summary>
		public const short Command2 = 86;

		/// <summary>
		/// 争夺奇书
		/// </summary>
		public const short WantedLegendaryBookDesc = 87;

		/// <summary>
		/// 争夺奇书图标
		/// </summary>
		public const short WantedLegendaryBookIcon = 88;

		/// <summary>
		/// 拥有奇书
		/// </summary>
		public const short OwnedLegendaryBookDesc = 89;

		/// <summary>
		/// 拥有奇书图标
		/// </summary>
		public const short OwnedLegendaryBookIcon = 90;

		/// <summary>
		/// 从属
		/// </summary>
		public const short OrganizationName = 91;

		/// <summary>
		/// 身份
		/// </summary>
		public const short Identity = 92;

		/// <summary>
		/// 精纯
		/// </summary>
		public const short ConsummateLevel = 93;

		/// <summary>
		/// 所处位置1
		/// </summary>
		public const short Location1 = 94;

		/// <summary>
		/// 拥有特性
		/// </summary>
		public const short LegendaryBookFeature = 95;

		/// <summary>
		/// 性别
		/// </summary>
		public const short Gender = 96;

		/// <summary>
		/// 真实年龄
		/// </summary>
		public const short ActualAge = 97;

		/// <summary>
		/// 奇书持有状态
		/// </summary>
		public const short LegendaryBookOwnerState = 98;

		/// <summary>
		/// 工作状态
		/// </summary>
		public const short WorkStatus = 99;

		/// <summary>
		/// 经营地点
		/// </summary>
		public const short WorkBuilding = 100;

		/// <summary>
		/// 经营岗位
		/// </summary>
		public const short WorkPost = 101;

		/// <summary>
		/// 潜力
		/// </summary>
		public const short Potential = 102;

		/// <summary>
		/// 所处位置2
		/// </summary>
		public const short Location2 = 103;

		/// <summary>
		/// 角色关系太吾
		/// </summary>
		public const short RelationToTaiwu = 104;

		/// <summary>
		/// 太吾关系角色
		/// </summary>
		public const short RelationFromTaiwu = 105;

		/// <summary>
		/// 同派系
		/// </summary>
		public const short SameFaction = 106;

		/// <summary>
		/// 势力值
		/// </summary>
		public const short InfluencePower = 107;

		/// <summary>
		/// 拿取时间
		/// </summary>
		public const short TakeItemTime = 108;

		/// <summary>
		/// 拿取数量
		/// </summary>
		public const short TakeItemAmount = 109;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 姓名
		/// </summary>
		public static CharacterTableElementItem Avatar => Instance[(short)0];

		/// <summary>
		/// 空格
		/// </summary>
		public static CharacterTableElementItem Empty => Instance[(short)1];

		/// <summary>
		/// 年龄
		/// </summary>
		public static CharacterTableElementItem PhysiologicalAge => Instance[(short)2];

		/// <summary>
		/// 健康
		/// </summary>
		public static CharacterTableElementItem Health => Instance[(short)3];

		/// <summary>
		/// 伤势
		/// </summary>
		public static CharacterTableElementItem Injury => Instance[(short)4];

		/// <summary>
		/// 魅力
		/// </summary>
		public static CharacterTableElementItem Charm => Instance[(short)5];

		/// <summary>
		/// 立场
		/// </summary>
		public static CharacterTableElementItem Behavior => Instance[(short)6];

		/// <summary>
		/// 心情
		/// </summary>
		public static CharacterTableElementItem Happiness => Instance[(short)7];

		/// <summary>
		/// 好感
		/// </summary>
		public static CharacterTableElementItem Favor => Instance[(short)8];

		/// <summary>
		/// 轮回
		/// </summary>
		public static CharacterTableElementItem Preexistence => Instance[(short)9];

		/// <summary>
		/// 名誉
		/// </summary>
		public static CharacterTableElementItem Fame => Instance[(short)10];

		/// <summary>
		/// 膂力
		/// </summary>
		public static CharacterTableElementItem Strength => Instance[(short)11];

		/// <summary>
		/// 灵敏
		/// </summary>
		public static CharacterTableElementItem Dexterity => Instance[(short)12];

		/// <summary>
		/// 定力
		/// </summary>
		public static CharacterTableElementItem Concentration => Instance[(short)13];

		/// <summary>
		/// 体质
		/// </summary>
		public static CharacterTableElementItem Vitality => Instance[(short)14];

		/// <summary>
		/// 根骨
		/// </summary>
		public static CharacterTableElementItem Energy => Instance[(short)15];

		/// <summary>
		/// 悟性
		/// </summary>
		public static CharacterTableElementItem Intelligence => Instance[(short)16];

		/// <summary>
		/// 破体
		/// </summary>
		public static CharacterTableElementItem PenetrateOfOuter => Instance[(short)17];

		/// <summary>
		/// 破气
		/// </summary>
		public static CharacterTableElementItem PenetrateOfInner => Instance[(short)18];

		/// <summary>
		/// 御体
		/// </summary>
		public static CharacterTableElementItem PenetrateResistOfOuter => Instance[(short)19];

		/// <summary>
		/// 御气
		/// </summary>
		public static CharacterTableElementItem PenetrateResistOfInner => Instance[(short)20];

		/// <summary>
		/// 力道
		/// </summary>
		public static CharacterTableElementItem HitRateStrength => Instance[(short)21];

		/// <summary>
		/// 精妙
		/// </summary>
		public static CharacterTableElementItem HitRateTechnique => Instance[(short)22];

		/// <summary>
		/// 迅疾
		/// </summary>
		public static CharacterTableElementItem HitRateSpeed => Instance[(short)23];

		/// <summary>
		/// 动心
		/// </summary>
		public static CharacterTableElementItem HitRateMind => Instance[(short)24];

		/// <summary>
		/// 卸力
		/// </summary>
		public static CharacterTableElementItem AvoidRateStrength => Instance[(short)25];

		/// <summary>
		/// 拆招
		/// </summary>
		public static CharacterTableElementItem AvoidRateTechnique => Instance[(short)26];

		/// <summary>
		/// 闪避
		/// </summary>
		public static CharacterTableElementItem AvoidRateSpeed => Instance[(short)27];

		/// <summary>
		/// 守心
		/// </summary>
		public static CharacterTableElementItem AvoidRateMind => Instance[(short)28];

		/// <summary>
		/// 紊乱
		/// </summary>
		public static CharacterTableElementItem DisorderOfQi => Instance[(short)29];

		/// <summary>
		/// 音律
		/// </summary>
		public static CharacterTableElementItem Music => Instance[(short)30];

		/// <summary>
		/// 弈棋
		/// </summary>
		public static CharacterTableElementItem Chess => Instance[(short)31];

		/// <summary>
		/// 诗书
		/// </summary>
		public static CharacterTableElementItem Poem => Instance[(short)32];

		/// <summary>
		/// 绘画
		/// </summary>
		public static CharacterTableElementItem Painting => Instance[(short)33];

		/// <summary>
		/// 术数
		/// </summary>
		public static CharacterTableElementItem Math => Instance[(short)34];

		/// <summary>
		/// 品鉴
		/// </summary>
		public static CharacterTableElementItem Appraisal => Instance[(short)35];

		/// <summary>
		/// 锻造
		/// </summary>
		public static CharacterTableElementItem Forging => Instance[(short)36];

		/// <summary>
		/// 制木
		/// </summary>
		public static CharacterTableElementItem Woodworking => Instance[(short)37];

		/// <summary>
		/// 医术
		/// </summary>
		public static CharacterTableElementItem Medicine => Instance[(short)38];

		/// <summary>
		/// 毒术
		/// </summary>
		public static CharacterTableElementItem Toxicology => Instance[(short)39];

		/// <summary>
		/// 织锦
		/// </summary>
		public static CharacterTableElementItem Weaving => Instance[(short)40];

		/// <summary>
		/// 巧匠
		/// </summary>
		public static CharacterTableElementItem JadeLifeSkill => Instance[(short)41];

		/// <summary>
		/// 道法
		/// </summary>
		public static CharacterTableElementItem Taoism => Instance[(short)42];

		/// <summary>
		/// 佛学
		/// </summary>
		public static CharacterTableElementItem Buddhism => Instance[(short)43];

		/// <summary>
		/// 厨艺
		/// </summary>
		public static CharacterTableElementItem Cooking => Instance[(short)44];

		/// <summary>
		/// 杂学
		/// </summary>
		public static CharacterTableElementItem Eclectic => Instance[(short)45];

		/// <summary>
		/// 技艺成长
		/// </summary>
		public static CharacterTableElementItem LifeSkillGrowth => Instance[(short)46];

		/// <summary>
		/// 内功
		/// </summary>
		public static CharacterTableElementItem Neigong => Instance[(short)47];

		/// <summary>
		/// 身法
		/// </summary>
		public static CharacterTableElementItem Posing => Instance[(short)48];

		/// <summary>
		/// 绝技
		/// </summary>
		public static CharacterTableElementItem Stunt => Instance[(short)49];

		/// <summary>
		/// 拳掌
		/// </summary>
		public static CharacterTableElementItem FistAndPalm => Instance[(short)50];

		/// <summary>
		/// 指法
		/// </summary>
		public static CharacterTableElementItem Finger => Instance[(short)51];

		/// <summary>
		/// 腿法
		/// </summary>
		public static CharacterTableElementItem Leg => Instance[(short)52];

		/// <summary>
		/// 暗器
		/// </summary>
		public static CharacterTableElementItem Throw => Instance[(short)53];

		/// <summary>
		/// 剑法
		/// </summary>
		public static CharacterTableElementItem Sword => Instance[(short)54];

		/// <summary>
		/// 刀法
		/// </summary>
		public static CharacterTableElementItem Blade => Instance[(short)55];

		/// <summary>
		/// 长兵
		/// </summary>
		public static CharacterTableElementItem Polearm => Instance[(short)56];

		/// <summary>
		/// 奇门
		/// </summary>
		public static CharacterTableElementItem Special => Instance[(short)57];

		/// <summary>
		/// 软兵
		/// </summary>
		public static CharacterTableElementItem Whip => Instance[(short)58];

		/// <summary>
		/// 御射
		/// </summary>
		public static CharacterTableElementItem ControllableShot => Instance[(short)59];

		/// <summary>
		/// 乐器
		/// </summary>
		public static CharacterTableElementItem CombatMusic => Instance[(short)60];

		/// <summary>
		/// 武学成长
		/// </summary>
		public static CharacterTableElementItem CombatSkillGrowth => Instance[(short)61];

		/// <summary>
		/// 冷静
		/// </summary>
		public static CharacterTableElementItem Calm => Instance[(short)62];

		/// <summary>
		/// 聪颖
		/// </summary>
		public static CharacterTableElementItem Clever => Instance[(short)63];

		/// <summary>
		/// 热情
		/// </summary>
		public static CharacterTableElementItem Enthusiastic => Instance[(short)64];

		/// <summary>
		/// 勇壮
		/// </summary>
		public static CharacterTableElementItem Brave => Instance[(short)65];

		/// <summary>
		/// 坚毅
		/// </summary>
		public static CharacterTableElementItem Firm => Instance[(short)66];

		/// <summary>
		/// 福缘
		/// </summary>
		public static CharacterTableElementItem Lucky => Instance[(short)67];

		/// <summary>
		/// 合道
		/// </summary>
		public static CharacterTableElementItem Perceptive => Instance[(short)68];

		/// <summary>
		/// 食材
		/// </summary>
		public static CharacterTableElementItem Food => Instance[(short)69];

		/// <summary>
		/// 木材
		/// </summary>
		public static CharacterTableElementItem Wood => Instance[(short)70];

		/// <summary>
		/// 金铁
		/// </summary>
		public static CharacterTableElementItem Metal => Instance[(short)71];

		/// <summary>
		/// 玉石
		/// </summary>
		public static CharacterTableElementItem JadeResource => Instance[(short)72];

		/// <summary>
		/// 织物
		/// </summary>
		public static CharacterTableElementItem Fabric => Instance[(short)73];

		/// <summary>
		/// 药材
		/// </summary>
		public static CharacterTableElementItem Herb => Instance[(short)74];

		/// <summary>
		/// 银钱
		/// </summary>
		public static CharacterTableElementItem Money => Instance[(short)75];

		/// <summary>
		/// 威望
		/// </summary>
		public static CharacterTableElementItem Authority => Instance[(short)76];

		/// <summary>
		/// 行囊
		/// </summary>
		public static CharacterTableElementItem Weight => Instance[(short)77];

		/// <summary>
		/// 当前负重
		/// </summary>
		public static CharacterTableElementItem CurrLoad => Instance[(short)78];

		/// <summary>
		/// 最大负重
		/// </summary>
		public static CharacterTableElementItem MaxLoad => Instance[(short)79];

		/// <summary>
		/// 关押
		/// </summary>
		public static CharacterTableElementItem Kidnap => Instance[(short)80];

		/// <summary>
		/// 进攻
		/// </summary>
		public static CharacterTableElementItem AttackMedal => Instance[(short)81];

		/// <summary>
		/// 守御
		/// </summary>
		public static CharacterTableElementItem DefenceMedal => Instance[(short)82];

		/// <summary>
		/// 机略
		/// </summary>
		public static CharacterTableElementItem WisdomMedal => Instance[(short)83];

		/// <summary>
		/// 指令1
		/// </summary>
		public static CharacterTableElementItem Command0 => Instance[(short)84];

		/// <summary>
		/// 指令2
		/// </summary>
		public static CharacterTableElementItem Command1 => Instance[(short)85];

		/// <summary>
		/// 指令3
		/// </summary>
		public static CharacterTableElementItem Command2 => Instance[(short)86];

		/// <summary>
		/// 争夺奇书
		/// </summary>
		public static CharacterTableElementItem WantedLegendaryBookDesc => Instance[(short)87];

		/// <summary>
		/// 争夺奇书图标
		/// </summary>
		public static CharacterTableElementItem WantedLegendaryBookIcon => Instance[(short)88];

		/// <summary>
		/// 拥有奇书
		/// </summary>
		public static CharacterTableElementItem OwnedLegendaryBookDesc => Instance[(short)89];

		/// <summary>
		/// 拥有奇书图标
		/// </summary>
		public static CharacterTableElementItem OwnedLegendaryBookIcon => Instance[(short)90];

		/// <summary>
		/// 从属
		/// </summary>
		public static CharacterTableElementItem OrganizationName => Instance[(short)91];

		/// <summary>
		/// 身份
		/// </summary>
		public static CharacterTableElementItem Identity => Instance[(short)92];

		/// <summary>
		/// 精纯
		/// </summary>
		public static CharacterTableElementItem ConsummateLevel => Instance[(short)93];

		/// <summary>
		/// 所处位置1
		/// </summary>
		public static CharacterTableElementItem Location1 => Instance[(short)94];

		/// <summary>
		/// 拥有特性
		/// </summary>
		public static CharacterTableElementItem LegendaryBookFeature => Instance[(short)95];

		/// <summary>
		/// 性别
		/// </summary>
		public static CharacterTableElementItem Gender => Instance[(short)96];

		/// <summary>
		/// 真实年龄
		/// </summary>
		public static CharacterTableElementItem ActualAge => Instance[(short)97];

		/// <summary>
		/// 奇书持有状态
		/// </summary>
		public static CharacterTableElementItem LegendaryBookOwnerState => Instance[(short)98];

		/// <summary>
		/// 工作状态
		/// </summary>
		public static CharacterTableElementItem WorkStatus => Instance[(short)99];

		/// <summary>
		/// 经营地点
		/// </summary>
		public static CharacterTableElementItem WorkBuilding => Instance[(short)100];

		/// <summary>
		/// 经营岗位
		/// </summary>
		public static CharacterTableElementItem WorkPost => Instance[(short)101];

		/// <summary>
		/// 潜力
		/// </summary>
		public static CharacterTableElementItem Potential => Instance[(short)102];

		/// <summary>
		/// 所处位置2
		/// </summary>
		public static CharacterTableElementItem Location2 => Instance[(short)103];

		/// <summary>
		/// 角色关系太吾
		/// </summary>
		public static CharacterTableElementItem RelationToTaiwu => Instance[(short)104];

		/// <summary>
		/// 太吾关系角色
		/// </summary>
		public static CharacterTableElementItem RelationFromTaiwu => Instance[(short)105];

		/// <summary>
		/// 同派系
		/// </summary>
		public static CharacterTableElementItem SameFaction => Instance[(short)106];

		/// <summary>
		/// 势力值
		/// </summary>
		public static CharacterTableElementItem InfluencePower => Instance[(short)107];

		/// <summary>
		/// 拿取时间
		/// </summary>
		public static CharacterTableElementItem TakeItemTime => Instance[(short)108];

		/// <summary>
		/// 拿取数量
		/// </summary>
		public static CharacterTableElementItem TakeItemAmount => Instance[(short)109];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static CharacterTableElement Instance = new CharacterTableElement();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "TemplateId" };

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
		_dataArray.Add(new CharacterTableElementItem(0, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_0"), ECharacterTableElementType.Avatar, canSort: true, canHighlight: false, needAsync: true, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(1, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_1"), ECharacterTableElementType.Empty, canSort: false, canHighlight: false, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(2, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_2"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: true));
		_dataArray.Add(new CharacterTableElementItem(3, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_3"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: true));
		_dataArray.Add(new CharacterTableElementItem(4, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_4"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(5, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_5"), ECharacterTableElementType.Text, canSort: true, canHighlight: false, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(6, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_6"), ECharacterTableElementType.Text, canSort: true, canHighlight: false, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(7, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_7"), ECharacterTableElementType.Text, canSort: true, canHighlight: false, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(8, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_8"), ECharacterTableElementType.Text, canSort: true, canHighlight: false, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(9, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_9"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(10, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_10"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(11, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_11"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(12, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_12"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(13, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_13"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(14, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_14"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(15, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_15"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(16, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_16"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(17, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_17"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(18, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_18"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(19, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_19"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(20, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_20"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(21, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_21"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(22, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_22"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(23, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_23"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(24, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_24"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(25, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_25"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(26, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_26"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(27, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_27"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(28, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_28"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(29, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_29"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(30, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_30"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: true));
		_dataArray.Add(new CharacterTableElementItem(31, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_31"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: true));
		_dataArray.Add(new CharacterTableElementItem(32, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_32"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: true));
		_dataArray.Add(new CharacterTableElementItem(33, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_33"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: true));
		_dataArray.Add(new CharacterTableElementItem(34, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_34"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: true));
		_dataArray.Add(new CharacterTableElementItem(35, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_35"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: true));
		_dataArray.Add(new CharacterTableElementItem(36, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_36"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: true));
		_dataArray.Add(new CharacterTableElementItem(37, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_37"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: true));
		_dataArray.Add(new CharacterTableElementItem(38, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_38"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: true));
		_dataArray.Add(new CharacterTableElementItem(39, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_39"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: true));
		_dataArray.Add(new CharacterTableElementItem(40, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_40"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: true));
		_dataArray.Add(new CharacterTableElementItem(41, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_41"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: true));
		_dataArray.Add(new CharacterTableElementItem(42, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_42"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: true));
		_dataArray.Add(new CharacterTableElementItem(43, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_43"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: true));
		_dataArray.Add(new CharacterTableElementItem(44, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_44"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: true));
		_dataArray.Add(new CharacterTableElementItem(45, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_45"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: true));
		_dataArray.Add(new CharacterTableElementItem(46, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_46"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: true));
		_dataArray.Add(new CharacterTableElementItem(47, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_47"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: true));
		_dataArray.Add(new CharacterTableElementItem(48, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_48"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: true));
		_dataArray.Add(new CharacterTableElementItem(49, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_49"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: true));
		_dataArray.Add(new CharacterTableElementItem(50, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_50"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: true));
		_dataArray.Add(new CharacterTableElementItem(51, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_51"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: true));
		_dataArray.Add(new CharacterTableElementItem(52, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_52"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: true));
		_dataArray.Add(new CharacterTableElementItem(53, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_53"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: true));
		_dataArray.Add(new CharacterTableElementItem(54, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_54"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: true));
		_dataArray.Add(new CharacterTableElementItem(55, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_55"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: true));
		_dataArray.Add(new CharacterTableElementItem(56, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_56"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: true));
		_dataArray.Add(new CharacterTableElementItem(57, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_57"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: true));
		_dataArray.Add(new CharacterTableElementItem(58, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_58"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: true));
		_dataArray.Add(new CharacterTableElementItem(59, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_59"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: true));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new CharacterTableElementItem(60, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_60"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: true));
		_dataArray.Add(new CharacterTableElementItem(61, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_61"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: true));
		_dataArray.Add(new CharacterTableElementItem(62, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_62"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(63, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_63"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(64, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_64"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(65, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_65"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(66, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_66"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(67, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_67"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(68, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_68"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(69, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_69"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(70, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_70"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(71, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_71"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(72, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_72"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(73, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_73"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(74, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_74"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(75, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_75"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(76, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_76"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(77, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_77"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(78, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_78"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(79, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_79"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(80, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_80"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(81, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_81"), ECharacterTableElementType.TextWithIcon, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(82, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_82"), ECharacterTableElementType.TextWithIcon, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(83, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_83"), ECharacterTableElementType.TextWithIcon, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(84, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_84"), ECharacterTableElementType.Command, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(85, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_85"), ECharacterTableElementType.Command, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(86, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_86"), ECharacterTableElementType.Command, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(87, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_87"), ECharacterTableElementType.TextWithIcon, canSort: true, canHighlight: false, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(88, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_88"), ECharacterTableElementType.TextWithIcon, canSort: false, canHighlight: false, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(89, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_89"), ECharacterTableElementType.TextWithIcon, canSort: true, canHighlight: false, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(90, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_90"), ECharacterTableElementType.TextWithIcon, canSort: false, canHighlight: false, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(91, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_91"), ECharacterTableElementType.Text, canSort: true, canHighlight: false, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(92, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_92"), ECharacterTableElementType.Text, canSort: true, canHighlight: false, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(93, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_93"), ECharacterTableElementType.Text, canSort: true, canHighlight: false, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(94, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_94"), ECharacterTableElementType.TextWithSprite, canSort: true, canHighlight: false, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(95, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_95"), ECharacterTableElementType.Feature, canSort: false, canHighlight: false, needAsync: true, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(96, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_96"), ECharacterTableElementType.Text, canSort: false, canHighlight: false, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(97, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_97"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(98, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_98"), ECharacterTableElementType.Text, canSort: false, canHighlight: false, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(99, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_99"), ECharacterTableElementType.Text, canSort: true, canHighlight: false, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(100, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_100"), ECharacterTableElementType.Text, canSort: true, canHighlight: false, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(101, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_101"), ECharacterTableElementType.Text, canSort: true, canHighlight: false, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(102, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_102"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(103, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_103"), ECharacterTableElementType.TextWithSprite, canSort: true, canHighlight: false, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(104, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_104"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(105, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_105"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(106, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_106"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(107, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_107"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(108, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_108"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
		_dataArray.Add(new CharacterTableElementItem(109, LocalStringManager.GetConfig("CharacterTableElement_language", "Name_109"), ECharacterTableElementType.Text, canSort: true, canHighlight: true, needAsync: false, hideProperty: false));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<CharacterTableElementItem>(110);
		CreateItems0();
		CreateItems1();
	}
}
