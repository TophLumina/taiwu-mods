using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class FameAction : ConfigData<FameActionItem, short>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 血债难赎
		/// </summary>
		public const short Kill = 0;

		/// <summary>
		/// 拘人害命
		/// </summary>
		public const short Kidnap = 2;

		/// <summary>
		/// 义薄云天
		/// </summary>
		public const short Rescue = 4;

		/// <summary>
		/// 是非不分
		/// </summary>
		public const short MakeEnemy = 6;

		/// <summary>
		/// 嫉恶如仇2
		/// </summary>
		public const short SeverEnemy = 8;

		/// <summary>
		/// 结交良善
		/// </summary>
		public const short MakeFriends = 10;

		/// <summary>
		/// 良谊高义
		/// </summary>
		public const short MakeBrothers = 12;

		/// <summary>
		/// 佳人才子
		/// </summary>
		public const short MakeLovers = 14;

		/// <summary>
		/// 败德辱行
		/// </summary>
		public const short MakeBadLovers = 15;

		/// <summary>
		/// 救抚良善
		/// </summary>
		public const short AdoptChild = 16;

		/// <summary>
		/// 寄身善贤
		/// </summary>
		public const short AdoptedAsChild = 18;

		/// <summary>
		/// 乐善好施
		/// </summary>
		public const short GiveItem = 20;

		/// <summary>
		/// 良师益友
		/// </summary>
		public const short TeachSkill = 22;

		/// <summary>
		/// 救死扶伤
		/// </summary>
		public const short Heal = 24;

		/// <summary>
		/// 养虎遗患
		/// </summary>
		public const short HealBad = 25;

		/// <summary>
		/// 出手伤人
		/// </summary>
		public const short SurpriseAttack = 26;

		/// <summary>
		/// 惩戒恶人
		/// </summary>
		public const short DisciplineEvil = 27;

		/// <summary>
		/// 偷师窃艺
		/// </summary>
		public const short StealSkill = 28;

		/// <summary>
		/// 窃取财物
		/// </summary>
		public const short Steal = 29;

		/// <summary>
		/// 抢劫财物
		/// </summary>
		public const short Rob = 30;

		/// <summary>
		/// 掘坟盗墓
		/// </summary>
		public const short RobGrave = 31;

		/// <summary>
		/// 施毒害人
		/// </summary>
		public const short Poison = 32;

		/// <summary>
		/// 落荒而逃
		/// </summary>
		public const short Escape = 33;

		/// <summary>
		/// 欺凌幼小
		/// </summary>
		public const short FightChildren = 34;

		/// <summary>
		/// 趁人之危
		/// </summary>
		public const short TakeAdventageOfOthers = 35;

		/// <summary>
		/// 比武得胜
		/// </summary>
		public const short WinCombat = 36;

		/// <summary>
		/// 比武落败
		/// </summary>
		public const short LoseCombat = 37;

		/// <summary>
		/// 宅心仁厚
		/// </summary>
		public const short ResponseKind = 38;

		/// <summary>
		/// 义正辞严
		/// </summary>
		public const short ResponseJust = 40;

		/// <summary>
		/// 恣肆无忌
		/// </summary>
		public const short ResponseRebel = 42;

		/// <summary>
		/// 唯利是图
		/// </summary>
		public const short ResponseEgoistic = 44;

		/// <summary>
		/// 流言蜚语
		/// </summary>
		public const short RumorsAround = 46;

		/// <summary>
		/// 软弱可欺
		/// </summary>
		public const short EasyToPickOn = 47;

		/// <summary>
		/// 受人恩惠
		/// </summary>
		public const short GetAlms = 48;

		/// <summary>
		/// 受人斥责
		/// </summary>
		public const short GetBlame = 49;

		/// <summary>
		/// 受人愚弄
		/// </summary>
		public const short GetFooled = 50;

		/// <summary>
		/// 受人胁迫
		/// </summary>
		public const short GetDuress = 51;

		/// <summary>
		/// 受人称赞
		/// </summary>
		public const short GetPraised = 52;

		/// <summary>
		/// 受人嘲笑
		/// </summary>
		public const short GetRidiculed = 53;

		/// <summary>
		/// 前人恩情
		/// </summary>
		public const short InheritGoodOne = 54;

		/// <summary>
		/// 前人罪业
		/// </summary>
		public const short InheritBadOne = 55;

		/// <summary>
		/// 芜行俚语
		/// </summary>
		public const short Indecent = 56;

		/// <summary>
		/// 行乞讨钱
		/// </summary>
		public const short Beg = 57;

		/// <summary>
		/// 庸医害命
		/// </summary>
		public const short Quack = 58;

		/// <summary>
		/// 行侠仗义
		/// </summary>
		public const short KillHeretic = 59;

		/// <summary>
		/// 杀害义士
		/// </summary>
		public const short KillRighteous = 60;

		/// <summary>
		/// 伤风败俗
		/// </summary>
		public const short Immoral = 61;

		/// <summary>
		/// 败坏清规
		/// </summary>
		public const short BreakRules = 62;

		/// <summary>
		/// 罔顾人伦
		/// </summary>
		public const short Unethical = 63;

		/// <summary>
		/// 欺师背祖
		/// </summary>
		public const short Betrayal = 64;

		/// <summary>
		/// 负心薄幸
		/// </summary>
		public const short Unfaithful = 65;

		/// <summary>
		/// 衣冠禽兽
		/// </summary>
		public const short Rape = 66;

		/// <summary>
		/// 受人羞辱
		/// </summary>
		public const short BeSneered = 67;

		/// <summary>
		/// 自取其辱
		/// </summary>
		public const short SneerSelf = 68;

		/// <summary>
		/// 知难而上
		/// </summary>
		public const short CombatWithStrong = 69;

		/// <summary>
		/// 欺软怕硬
		/// </summary>
		public const short CombatWithWeak = 70;

		/// <summary>
		/// 正派名宗
		/// </summary>
		public const short FriendWithGoodSects = 71;

		/// <summary>
		/// 邪派外道
		/// </summary>
		public const short FriendWithEvilSects = 72;

		/// <summary>
		/// 亦正亦邪1
		/// </summary>
		public const short FriendWithNeutralSects1 = 73;

		/// <summary>
		/// 亦正亦邪2
		/// </summary>
		public const short FriendWithNeutralSects2 = 74;

		/// <summary>
		/// 较艺得胜
		/// </summary>
		public const short WinSkill = 75;

		/// <summary>
		/// 较艺落败
		/// </summary>
		public const short LoseSkill = 76;

		/// <summary>
		/// 制造名品
		/// </summary>
		public const short MakeFamousItem = 77;

		/// <summary>
		/// 云蒸龙变
		/// </summary>
		public const short DLCLoongDefeatLoong = 78;

		/// <summary>
		/// 擅闯库房
		/// </summary>
		public const short IntrudeTreasury = 79;

		/// <summary>
		/// 掠夺库房
		/// </summary>
		public const short PlunderTreasury = 80;

		/// <summary>
		/// 施仁布泽
		/// </summary>
		public const short AidTreasury = 81;

		/// <summary>
		/// 负罪在身
		/// </summary>
		public const short CommitCrime = 82;

		/// <summary>
		/// 缉逃擒凶
		/// </summary>
		public const short CaptureCriminals = 83;

		/// <summary>
		/// 手艺不精
		/// </summary>
		public const short LackSkill = 92;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 血债难赎
		/// </summary>
		public static FameActionItem Kill => Instance[(short)0];

		/// <summary>
		/// 拘人害命
		/// </summary>
		public static FameActionItem Kidnap => Instance[(short)2];

		/// <summary>
		/// 义薄云天
		/// </summary>
		public static FameActionItem Rescue => Instance[(short)4];

		/// <summary>
		/// 是非不分
		/// </summary>
		public static FameActionItem MakeEnemy => Instance[(short)6];

		/// <summary>
		/// 嫉恶如仇2
		/// </summary>
		public static FameActionItem SeverEnemy => Instance[(short)8];

		/// <summary>
		/// 结交良善
		/// </summary>
		public static FameActionItem MakeFriends => Instance[(short)10];

		/// <summary>
		/// 良谊高义
		/// </summary>
		public static FameActionItem MakeBrothers => Instance[(short)12];

		/// <summary>
		/// 佳人才子
		/// </summary>
		public static FameActionItem MakeLovers => Instance[(short)14];

		/// <summary>
		/// 败德辱行
		/// </summary>
		public static FameActionItem MakeBadLovers => Instance[(short)15];

		/// <summary>
		/// 救抚良善
		/// </summary>
		public static FameActionItem AdoptChild => Instance[(short)16];

		/// <summary>
		/// 寄身善贤
		/// </summary>
		public static FameActionItem AdoptedAsChild => Instance[(short)18];

		/// <summary>
		/// 乐善好施
		/// </summary>
		public static FameActionItem GiveItem => Instance[(short)20];

		/// <summary>
		/// 良师益友
		/// </summary>
		public static FameActionItem TeachSkill => Instance[(short)22];

		/// <summary>
		/// 救死扶伤
		/// </summary>
		public static FameActionItem Heal => Instance[(short)24];

		/// <summary>
		/// 养虎遗患
		/// </summary>
		public static FameActionItem HealBad => Instance[(short)25];

		/// <summary>
		/// 出手伤人
		/// </summary>
		public static FameActionItem SurpriseAttack => Instance[(short)26];

		/// <summary>
		/// 惩戒恶人
		/// </summary>
		public static FameActionItem DisciplineEvil => Instance[(short)27];

		/// <summary>
		/// 偷师窃艺
		/// </summary>
		public static FameActionItem StealSkill => Instance[(short)28];

		/// <summary>
		/// 窃取财物
		/// </summary>
		public static FameActionItem Steal => Instance[(short)29];

		/// <summary>
		/// 抢劫财物
		/// </summary>
		public static FameActionItem Rob => Instance[(short)30];

		/// <summary>
		/// 掘坟盗墓
		/// </summary>
		public static FameActionItem RobGrave => Instance[(short)31];

		/// <summary>
		/// 施毒害人
		/// </summary>
		public static FameActionItem Poison => Instance[(short)32];

		/// <summary>
		/// 落荒而逃
		/// </summary>
		public static FameActionItem Escape => Instance[(short)33];

		/// <summary>
		/// 欺凌幼小
		/// </summary>
		public static FameActionItem FightChildren => Instance[(short)34];

		/// <summary>
		/// 趁人之危
		/// </summary>
		public static FameActionItem TakeAdventageOfOthers => Instance[(short)35];

		/// <summary>
		/// 比武得胜
		/// </summary>
		public static FameActionItem WinCombat => Instance[(short)36];

		/// <summary>
		/// 比武落败
		/// </summary>
		public static FameActionItem LoseCombat => Instance[(short)37];

		/// <summary>
		/// 宅心仁厚
		/// </summary>
		public static FameActionItem ResponseKind => Instance[(short)38];

		/// <summary>
		/// 义正辞严
		/// </summary>
		public static FameActionItem ResponseJust => Instance[(short)40];

		/// <summary>
		/// 恣肆无忌
		/// </summary>
		public static FameActionItem ResponseRebel => Instance[(short)42];

		/// <summary>
		/// 唯利是图
		/// </summary>
		public static FameActionItem ResponseEgoistic => Instance[(short)44];

		/// <summary>
		/// 流言蜚语
		/// </summary>
		public static FameActionItem RumorsAround => Instance[(short)46];

		/// <summary>
		/// 软弱可欺
		/// </summary>
		public static FameActionItem EasyToPickOn => Instance[(short)47];

		/// <summary>
		/// 受人恩惠
		/// </summary>
		public static FameActionItem GetAlms => Instance[(short)48];

		/// <summary>
		/// 受人斥责
		/// </summary>
		public static FameActionItem GetBlame => Instance[(short)49];

		/// <summary>
		/// 受人愚弄
		/// </summary>
		public static FameActionItem GetFooled => Instance[(short)50];

		/// <summary>
		/// 受人胁迫
		/// </summary>
		public static FameActionItem GetDuress => Instance[(short)51];

		/// <summary>
		/// 受人称赞
		/// </summary>
		public static FameActionItem GetPraised => Instance[(short)52];

		/// <summary>
		/// 受人嘲笑
		/// </summary>
		public static FameActionItem GetRidiculed => Instance[(short)53];

		/// <summary>
		/// 前人恩情
		/// </summary>
		public static FameActionItem InheritGoodOne => Instance[(short)54];

		/// <summary>
		/// 前人罪业
		/// </summary>
		public static FameActionItem InheritBadOne => Instance[(short)55];

		/// <summary>
		/// 芜行俚语
		/// </summary>
		public static FameActionItem Indecent => Instance[(short)56];

		/// <summary>
		/// 行乞讨钱
		/// </summary>
		public static FameActionItem Beg => Instance[(short)57];

		/// <summary>
		/// 庸医害命
		/// </summary>
		public static FameActionItem Quack => Instance[(short)58];

		/// <summary>
		/// 行侠仗义
		/// </summary>
		public static FameActionItem KillHeretic => Instance[(short)59];

		/// <summary>
		/// 杀害义士
		/// </summary>
		public static FameActionItem KillRighteous => Instance[(short)60];

		/// <summary>
		/// 伤风败俗
		/// </summary>
		public static FameActionItem Immoral => Instance[(short)61];

		/// <summary>
		/// 败坏清规
		/// </summary>
		public static FameActionItem BreakRules => Instance[(short)62];

		/// <summary>
		/// 罔顾人伦
		/// </summary>
		public static FameActionItem Unethical => Instance[(short)63];

		/// <summary>
		/// 欺师背祖
		/// </summary>
		public static FameActionItem Betrayal => Instance[(short)64];

		/// <summary>
		/// 负心薄幸
		/// </summary>
		public static FameActionItem Unfaithful => Instance[(short)65];

		/// <summary>
		/// 衣冠禽兽
		/// </summary>
		public static FameActionItem Rape => Instance[(short)66];

		/// <summary>
		/// 受人羞辱
		/// </summary>
		public static FameActionItem BeSneered => Instance[(short)67];

		/// <summary>
		/// 自取其辱
		/// </summary>
		public static FameActionItem SneerSelf => Instance[(short)68];

		/// <summary>
		/// 知难而上
		/// </summary>
		public static FameActionItem CombatWithStrong => Instance[(short)69];

		/// <summary>
		/// 欺软怕硬
		/// </summary>
		public static FameActionItem CombatWithWeak => Instance[(short)70];

		/// <summary>
		/// 正派名宗
		/// </summary>
		public static FameActionItem FriendWithGoodSects => Instance[(short)71];

		/// <summary>
		/// 邪派外道
		/// </summary>
		public static FameActionItem FriendWithEvilSects => Instance[(short)72];

		/// <summary>
		/// 亦正亦邪1
		/// </summary>
		public static FameActionItem FriendWithNeutralSects1 => Instance[(short)73];

		/// <summary>
		/// 亦正亦邪2
		/// </summary>
		public static FameActionItem FriendWithNeutralSects2 => Instance[(short)74];

		/// <summary>
		/// 较艺得胜
		/// </summary>
		public static FameActionItem WinSkill => Instance[(short)75];

		/// <summary>
		/// 较艺落败
		/// </summary>
		public static FameActionItem LoseSkill => Instance[(short)76];

		/// <summary>
		/// 制造名品
		/// </summary>
		public static FameActionItem MakeFamousItem => Instance[(short)77];

		/// <summary>
		/// 云蒸龙变
		/// </summary>
		public static FameActionItem DLCLoongDefeatLoong => Instance[(short)78];

		/// <summary>
		/// 擅闯库房
		/// </summary>
		public static FameActionItem IntrudeTreasury => Instance[(short)79];

		/// <summary>
		/// 掠夺库房
		/// </summary>
		public static FameActionItem PlunderTreasury => Instance[(short)80];

		/// <summary>
		/// 施仁布泽
		/// </summary>
		public static FameActionItem AidTreasury => Instance[(short)81];

		/// <summary>
		/// 负罪在身
		/// </summary>
		public static FameActionItem CommitCrime => Instance[(short)82];

		/// <summary>
		/// 缉逃擒凶
		/// </summary>
		public static FameActionItem CaptureCriminals => Instance[(short)83];

		/// <summary>
		/// 手艺不精
		/// </summary>
		public static FameActionItem LackSkill => Instance[(short)92];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static FameAction Instance = new FameAction();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "GoodJumpId", "BadJumpId", "NormalJumpId", "TemplateId", "Duration", "RepeatType", "MaxStackCount", "ReductionTime" };

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
		_dataArray.Add(new FameActionItem(0, LocalStringManager.GetConfig("FameAction_language", "Name_0"), -20, 120, 0, 100, 40, 0, 0, hasJump: true, 0, 1, 0, 300, 0));
		_dataArray.Add(new FameActionItem(1, LocalStringManager.GetConfig("FameAction_language", "Name_1"), 3, 6, 1, 20, 3, 0, 0, hasJump: false, -1, -1, -1, 0, 300));
		_dataArray.Add(new FameActionItem(2, LocalStringManager.GetConfig("FameAction_language", "Name_2"), -20, 120, 0, 100, 40, 0, 0, hasJump: true, 2, 3, 2, 300, 0));
		_dataArray.Add(new FameActionItem(3, LocalStringManager.GetConfig("FameAction_language", "Name_3"), 3, 6, 1, 20, 3, 0, 0, hasJump: false, -1, -1, -1, 0, 300));
		_dataArray.Add(new FameActionItem(4, LocalStringManager.GetConfig("FameAction_language", "Name_4"), 3, 6, 1, 20, 3, 0, 0, hasJump: true, 4, 5, 4, 0, 45));
		_dataArray.Add(new FameActionItem(5, LocalStringManager.GetConfig("FameAction_language", "Name_5"), -3, 6, 1, 20, 18, 0, 0, hasJump: false, -1, -1, -1, 45, 0));
		_dataArray.Add(new FameActionItem(6, LocalStringManager.GetConfig("FameAction_language", "Name_6"), -2, 12, 1, 10, 36, 0, 0, hasJump: true, 6, 7, 6, 30, 0));
		_dataArray.Add(new FameActionItem(7, LocalStringManager.GetConfig("FameAction_language", "Name_7"), 2, 12, 1, 10, 6, 0, 0, hasJump: false, -1, -1, -1, 0, 30));
		_dataArray.Add(new FameActionItem(8, LocalStringManager.GetConfig("FameAction_language", "Name_8"), 2, 12, 1, 10, 6, 0, 0, hasJump: true, 8, 9, 8, 0, 30));
		_dataArray.Add(new FameActionItem(9, LocalStringManager.GetConfig("FameAction_language", "Name_9"), -2, 12, 1, 10, 36, 0, 0, hasJump: false, -1, -1, -1, 30, 0));
		_dataArray.Add(new FameActionItem(10, LocalStringManager.GetConfig("FameAction_language", "Name_10"), 2, 6, 1, 10, 3, 0, 0, hasJump: true, 10, 11, 10, 0, 30));
		_dataArray.Add(new FameActionItem(11, LocalStringManager.GetConfig("FameAction_language", "Name_11"), -2, 6, 1, 10, 18, 0, 0, hasJump: false, -1, -1, -1, 30, 0));
		_dataArray.Add(new FameActionItem(12, LocalStringManager.GetConfig("FameAction_language", "Name_12"), 4, 6, 1, 10, 3, 0, 0, hasJump: true, 12, 13, 12, 0, 60));
		_dataArray.Add(new FameActionItem(13, LocalStringManager.GetConfig("FameAction_language", "Name_13"), -4, 6, 1, 10, 18, 0, 0, hasJump: false, -1, -1, -1, 60, 0));
		_dataArray.Add(new FameActionItem(14, LocalStringManager.GetConfig("FameAction_language", "Name_14"), 6, 6, 1, 10, 3, 0, 0, hasJump: true, 14, 15, 14, 0, 90));
		_dataArray.Add(new FameActionItem(15, LocalStringManager.GetConfig("FameAction_language", "Name_15"), -6, 6, 1, 10, 18, 0, 0, hasJump: false, -1, -1, -1, 90, 0));
		_dataArray.Add(new FameActionItem(16, LocalStringManager.GetConfig("FameAction_language", "Name_16"), 3, 60, 0, 10, 10, 0, 0, hasJump: true, 16, 17, 16, 0, 45));
		_dataArray.Add(new FameActionItem(17, LocalStringManager.GetConfig("FameAction_language", "Name_17"), -3, 60, 0, 10, 20, 0, 0, hasJump: false, -1, -1, -1, 45, 0));
		_dataArray.Add(new FameActionItem(18, LocalStringManager.GetConfig("FameAction_language", "Name_18"), 10, 120, 0, 5, 20, 0, 0, hasJump: true, 18, 19, 18, 0, 150));
		_dataArray.Add(new FameActionItem(19, LocalStringManager.GetConfig("FameAction_language", "Name_19"), -10, 120, 0, 5, 40, 0, 0, hasJump: false, -1, -1, -1, 150, 0));
		_dataArray.Add(new FameActionItem(20, LocalStringManager.GetConfig("FameAction_language", "Name_20"), 2, 6, 1, 20, 3, 0, 0, hasJump: true, 20, 21, 20, 0, 30));
		_dataArray.Add(new FameActionItem(21, LocalStringManager.GetConfig("FameAction_language", "Name_21"), -2, 6, 1, 20, 18, 0, 0, hasJump: false, -1, -1, -1, 30, 0));
		_dataArray.Add(new FameActionItem(22, LocalStringManager.GetConfig("FameAction_language", "Name_22"), 2, 6, 1, 20, 3, 0, 0, hasJump: true, 22, 23, 22, 0, 30));
		_dataArray.Add(new FameActionItem(23, LocalStringManager.GetConfig("FameAction_language", "Name_23"), -2, 6, 1, 20, 18, 0, 0, hasJump: false, -1, -1, -1, 30, 0));
		_dataArray.Add(new FameActionItem(24, LocalStringManager.GetConfig("FameAction_language", "Name_24"), 2, 6, 1, 20, 3, 0, 0, hasJump: true, 24, 25, 24, 0, 30));
		_dataArray.Add(new FameActionItem(25, LocalStringManager.GetConfig("FameAction_language", "Name_25"), -2, 6, 1, 20, 18, 0, 0, hasJump: false, -1, -1, -1, 30, 0));
		_dataArray.Add(new FameActionItem(26, LocalStringManager.GetConfig("FameAction_language", "Name_26"), -3, 120, 0, 20, 40, 0, 0, hasJump: true, 26, 27, 26, 45, 0));
		_dataArray.Add(new FameActionItem(27, LocalStringManager.GetConfig("FameAction_language", "Name_27"), 3, 6, 1, 20, 3, 0, 0, hasJump: false, -1, -1, -1, 0, 45));
		_dataArray.Add(new FameActionItem(28, LocalStringManager.GetConfig("FameAction_language", "Name_28"), -5, 60, 0, 10, 20, 0, 0, hasJump: false, -1, -1, -1, 75, 0));
		_dataArray.Add(new FameActionItem(29, LocalStringManager.GetConfig("FameAction_language", "Name_29"), -5, 60, 0, 10, 20, 0, 0, hasJump: false, -1, -1, -1, 75, 0));
		_dataArray.Add(new FameActionItem(30, LocalStringManager.GetConfig("FameAction_language", "Name_30"), -5, 60, 0, 10, 20, 0, 0, hasJump: false, -1, -1, -1, 75, 0));
		_dataArray.Add(new FameActionItem(31, LocalStringManager.GetConfig("FameAction_language", "Name_31"), -5, 60, 0, 10, 20, 0, 0, hasJump: false, -1, -1, -1, 75, 0));
		_dataArray.Add(new FameActionItem(32, LocalStringManager.GetConfig("FameAction_language", "Name_32"), -5, 60, 0, 10, 20, 0, 0, hasJump: false, -1, -1, -1, 75, 0));
		_dataArray.Add(new FameActionItem(33, LocalStringManager.GetConfig("FameAction_language", "Name_33"), -2, 6, 1, 20, 18, 0, 0, hasJump: false, -1, -1, -1, 30, 0));
		_dataArray.Add(new FameActionItem(34, LocalStringManager.GetConfig("FameAction_language", "Name_34"), -2, 3, 1, 20, 9, 0, 0, hasJump: false, -1, -1, -1, 30, 0));
		_dataArray.Add(new FameActionItem(35, LocalStringManager.GetConfig("FameAction_language", "Name_35"), -2, 3, 1, 20, 9, 0, 0, hasJump: false, -1, -1, -1, 30, 0));
		_dataArray.Add(new FameActionItem(36, LocalStringManager.GetConfig("FameAction_language", "Name_36"), 0, 12, 1, 10, 6, 20, -20, hasJump: false, -1, -1, -1, 0, 45));
		_dataArray.Add(new FameActionItem(37, LocalStringManager.GetConfig("FameAction_language", "Name_37"), 0, 12, 1, 10, 36, -20, 20, hasJump: false, -1, -1, -1, 45, 0));
		_dataArray.Add(new FameActionItem(38, LocalStringManager.GetConfig("FameAction_language", "Name_38"), 2, 6, 1, 20, 3, 0, 0, hasJump: true, 38, 39, 38, 0, 30));
		_dataArray.Add(new FameActionItem(39, LocalStringManager.GetConfig("FameAction_language", "Name_39"), -2, 6, 1, 20, 12, 0, 0, hasJump: false, -1, -1, -1, 30, 0));
		_dataArray.Add(new FameActionItem(40, LocalStringManager.GetConfig("FameAction_language", "Name_40"), 2, 6, 1, 20, 3, 0, 0, hasJump: true, 41, 40, 41, 0, 30));
		_dataArray.Add(new FameActionItem(41, LocalStringManager.GetConfig("FameAction_language", "Name_41"), -2, 6, 1, 20, 12, 0, 0, hasJump: false, -1, -1, -1, 30, 0));
		_dataArray.Add(new FameActionItem(42, LocalStringManager.GetConfig("FameAction_language", "Name_42"), -2, 6, 1, 20, 12, 0, 0, hasJump: true, 42, 43, 42, 30, 0));
		_dataArray.Add(new FameActionItem(43, LocalStringManager.GetConfig("FameAction_language", "Name_43"), 2, 6, 1, 20, 3, 0, 0, hasJump: false, -1, -1, -1, 0, 30));
		_dataArray.Add(new FameActionItem(44, LocalStringManager.GetConfig("FameAction_language", "Name_44"), -2, 6, 1, 20, 12, 0, 0, hasJump: true, 44, 45, 44, 30, 0));
		_dataArray.Add(new FameActionItem(45, LocalStringManager.GetConfig("FameAction_language", "Name_45"), 2, 6, 1, 20, 3, 0, 0, hasJump: false, -1, -1, -1, 0, 30));
		_dataArray.Add(new FameActionItem(46, LocalStringManager.GetConfig("FameAction_language", "Name_46"), -2, 6, 1, 20, 18, 0, 0, hasJump: false, -1, -1, -1, 30, 0));
		_dataArray.Add(new FameActionItem(47, LocalStringManager.GetConfig("FameAction_language", "Name_47"), -3, 60, 0, 10, 20, 0, 0, hasJump: false, -1, -1, -1, 45, 0));
		_dataArray.Add(new FameActionItem(48, LocalStringManager.GetConfig("FameAction_language", "Name_48"), 0, 60, 0, 10, 20, 0, 20, hasJump: false, -1, -1, -1, 45, 0));
		_dataArray.Add(new FameActionItem(49, LocalStringManager.GetConfig("FameAction_language", "Name_49"), 0, 60, 0, 10, 20, 0, 20, hasJump: false, -1, -1, -1, 45, 0));
		_dataArray.Add(new FameActionItem(50, LocalStringManager.GetConfig("FameAction_language", "Name_50"), 0, 60, 0, 10, 20, 0, 20, hasJump: false, -1, -1, -1, 45, 0));
		_dataArray.Add(new FameActionItem(51, LocalStringManager.GetConfig("FameAction_language", "Name_51"), 0, 60, 0, 10, 20, 0, 20, hasJump: false, -1, -1, -1, 45, 0));
		_dataArray.Add(new FameActionItem(52, LocalStringManager.GetConfig("FameAction_language", "Name_52"), 2, 6, 1, 10, 3, 0, 0, hasJump: false, -1, -1, -1, 0, 30));
		_dataArray.Add(new FameActionItem(53, LocalStringManager.GetConfig("FameAction_language", "Name_53"), -2, 6, 1, 10, 18, 0, 0, hasJump: false, -1, -1, -1, 30, 0));
		_dataArray.Add(new FameActionItem(54, LocalStringManager.GetConfig("FameAction_language", "Name_54"), 0, 120, 0, 3, 20, 50, 0, hasJump: false, -1, -1, -1, 0, 450));
		_dataArray.Add(new FameActionItem(55, LocalStringManager.GetConfig("FameAction_language", "Name_55"), 0, 120, 0, 3, 20, 0, 50, hasJump: false, -1, -1, -1, 450, 0));
		_dataArray.Add(new FameActionItem(56, LocalStringManager.GetConfig("FameAction_language", "Name_56"), -5, 12, 1, 10, 36, 0, 0, hasJump: false, -1, -1, -1, 75, 0));
		_dataArray.Add(new FameActionItem(57, LocalStringManager.GetConfig("FameAction_language", "Name_57"), -3, 6, 1, 10, 18, 0, 0, hasJump: false, -1, -1, -1, 75, 0));
		_dataArray.Add(new FameActionItem(58, LocalStringManager.GetConfig("FameAction_language", "Name_58"), -5, 12, 1, 10, 36, 0, 0, hasJump: false, -1, -1, -1, 75, 0));
		_dataArray.Add(new FameActionItem(59, LocalStringManager.GetConfig("FameAction_language", "Name_59"), 2, 6, 1, 20, 3, 0, 0, hasJump: false, -1, -1, -1, 0, 30));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new FameActionItem(60, LocalStringManager.GetConfig("FameAction_language", "Name_60"), -2, 6, 1, 20, 18, 0, 0, hasJump: false, -1, -1, -1, 30, 0));
		_dataArray.Add(new FameActionItem(61, LocalStringManager.GetConfig("FameAction_language", "Name_61"), -3, 6, 1, 10, 18, 0, 0, hasJump: false, -1, -1, -1, 45, 0));
		_dataArray.Add(new FameActionItem(62, LocalStringManager.GetConfig("FameAction_language", "Name_62"), -5, 60, 0, 10, 20, 0, 0, hasJump: false, -1, -1, -1, 75, 0));
		_dataArray.Add(new FameActionItem(63, LocalStringManager.GetConfig("FameAction_language", "Name_63"), -10, 120, 0, 100, 40, 0, 0, hasJump: false, -1, -1, -1, 150, 0));
		_dataArray.Add(new FameActionItem(64, LocalStringManager.GetConfig("FameAction_language", "Name_64"), -10, 6, 1, 5, 18, 0, 0, hasJump: false, -1, -1, -1, 150, 0));
		_dataArray.Add(new FameActionItem(65, LocalStringManager.GetConfig("FameAction_language", "Name_65"), -2, 6, 1, 20, 18, 0, 0, hasJump: false, -1, -1, -1, 30, 0));
		_dataArray.Add(new FameActionItem(66, LocalStringManager.GetConfig("FameAction_language", "Name_66"), -20, 120, 0, 100, 40, 0, 0, hasJump: false, -1, -1, -1, 300, 0));
		_dataArray.Add(new FameActionItem(67, LocalStringManager.GetConfig("FameAction_language", "Name_67"), -2, 6, 1, 10, 18, 0, 0, hasJump: false, -1, -1, -1, 30, 0));
		_dataArray.Add(new FameActionItem(68, LocalStringManager.GetConfig("FameAction_language", "Name_68"), -2, 6, 1, 10, 18, 0, 0, hasJump: false, -1, -1, -1, 30, 0));
		_dataArray.Add(new FameActionItem(69, LocalStringManager.GetConfig("FameAction_language", "Name_69"), 0, 6, 1, 5, 18, 20, 20, hasJump: false, -1, -1, -1, 75, 75));
		_dataArray.Add(new FameActionItem(70, LocalStringManager.GetConfig("FameAction_language", "Name_70"), 0, 6, 1, 5, 18, -20, -20, hasJump: false, -1, -1, -1, 75, 75));
		_dataArray.Add(new FameActionItem(71, LocalStringManager.GetConfig("FameAction_language", "Name_71"), 1, 1, 0, 50, 0, 0, 0, hasJump: false, -1, -1, -1, 0, 0));
		_dataArray.Add(new FameActionItem(72, LocalStringManager.GetConfig("FameAction_language", "Name_72"), -1, 1, 0, 50, 0, 0, 0, hasJump: false, -1, -1, -1, 0, 0));
		_dataArray.Add(new FameActionItem(73, LocalStringManager.GetConfig("FameAction_language", "Name_73"), 1, 1, 0, 50, 0, 0, 0, hasJump: false, -1, -1, -1, 0, 0));
		_dataArray.Add(new FameActionItem(74, LocalStringManager.GetConfig("FameAction_language", "Name_74"), -1, 1, 0, 50, 0, 0, 0, hasJump: false, -1, -1, -1, 0, 0));
		_dataArray.Add(new FameActionItem(75, LocalStringManager.GetConfig("FameAction_language", "Name_75"), 0, 12, 1, 10, 6, 20, -20, hasJump: false, -1, -1, -1, 0, 45));
		_dataArray.Add(new FameActionItem(76, LocalStringManager.GetConfig("FameAction_language", "Name_76"), 0, 12, 1, 10, 36, -20, 20, hasJump: false, -1, -1, -1, 45, 0));
		_dataArray.Add(new FameActionItem(77, LocalStringManager.GetConfig("FameAction_language", "Name_77"), 0, 6, 1, 10, 18, 33, 33, hasJump: false, -1, -1, -1, 60, 60));
		_dataArray.Add(new FameActionItem(78, LocalStringManager.GetConfig("FameAction_language", "Name_78"), 0, 60, 1, 5, 20, 100, 100, hasJump: false, -1, -1, -1, 300, 300));
		_dataArray.Add(new FameActionItem(79, LocalStringManager.GetConfig("FameAction_language", "Name_79"), -30, 60, 1, 100, 20, 0, 0, hasJump: false, -1, -1, -1, 450, 0));
		_dataArray.Add(new FameActionItem(80, LocalStringManager.GetConfig("FameAction_language", "Name_80"), -5, 36, 1, 50, 12, 0, 0, hasJump: false, -1, -1, -1, 75, 0));
		_dataArray.Add(new FameActionItem(81, LocalStringManager.GetConfig("FameAction_language", "Name_81"), 3, 12, 0, 10, 6, 0, 0, hasJump: false, -1, -1, -1, 0, 75));
		_dataArray.Add(new FameActionItem(82, LocalStringManager.GetConfig("FameAction_language", "Name_82"), -3, 12, 1, 50, 12, 0, 0, hasJump: false, -1, -1, -1, 45, 0));
		_dataArray.Add(new FameActionItem(83, LocalStringManager.GetConfig("FameAction_language", "Name_83"), 3, 12, 1, 50, 12, 0, 0, hasJump: false, -1, -1, -1, 0, 45));
		_dataArray.Add(new FameActionItem(84, LocalStringManager.GetConfig("FameAction_language", "Name_84"), -2, 6, 1, 20, 18, 0, 0, hasJump: false, -1, -1, -1, 30, 0));
		_dataArray.Add(new FameActionItem(85, LocalStringManager.GetConfig("FameAction_language", "Name_85"), -2, 6, 1, 20, 18, 0, 0, hasJump: false, -1, -1, -1, 30, 0));
		_dataArray.Add(new FameActionItem(86, LocalStringManager.GetConfig("FameAction_language", "Name_86"), 1, 12, 0, 50, 0, 0, 0, hasJump: false, -1, -1, -1, 0, 0));
		_dataArray.Add(new FameActionItem(87, LocalStringManager.GetConfig("FameAction_language", "Name_87"), -1, 12, 0, 50, 0, 0, 0, hasJump: false, -1, -1, -1, 0, 0));
		_dataArray.Add(new FameActionItem(88, LocalStringManager.GetConfig("FameAction_language", "Name_88"), 1, 12, 0, 50, 0, 0, 0, hasJump: false, -1, -1, -1, 0, 0));
		_dataArray.Add(new FameActionItem(89, LocalStringManager.GetConfig("FameAction_language", "Name_89"), -1, 12, 0, 50, 0, 0, 0, hasJump: false, -1, -1, -1, 0, 0));
		_dataArray.Add(new FameActionItem(90, LocalStringManager.GetConfig("FameAction_language", "Name_90"), -1, 120, 0, 20, 40, 0, 0, hasJump: true, 90, 91, 90, 45, 0));
		_dataArray.Add(new FameActionItem(91, LocalStringManager.GetConfig("FameAction_language", "Name_91"), 1, 6, 1, 20, 3, 0, 0, hasJump: false, -1, -1, -1, 0, 45));
		_dataArray.Add(new FameActionItem(92, LocalStringManager.GetConfig("FameAction_language", "Name_92"), -1, 3, 1, 20, 3, 0, 0, hasJump: false, -1, -1, -1, 0, 0));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<FameActionItem>(93);
		CreateItems0();
		CreateItems1();
	}
}
