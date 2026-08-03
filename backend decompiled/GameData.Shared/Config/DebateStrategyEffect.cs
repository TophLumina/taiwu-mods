using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class DebateStrategyEffect : ConfigData<DebateStrategyEffectItem, short>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 影响论据
		/// </summary>
		public const short BuffBases = 0;

		/// <summary>
		/// 放置论点
		/// </summary>
		public const short MakeMove = 1;

		/// <summary>
		/// 交换位置
		/// </summary>
		public const short SwitchCoordinate = 2;

		/// <summary>
		/// 移动位置
		/// </summary>
		public const short TeleportCoordinate = 3;

		/// <summary>
		/// 额外伤害
		/// </summary>
		public const short DamageMore = 4;

		/// <summary>
		/// 额外前进
		/// </summary>
		public const short ForwardMore = 5;

		/// <summary>
		/// 对手论据
		/// </summary>
		public const short OpponentBases = 6;

		/// <summary>
		/// 抽卡待用
		/// </summary>
		public const short DrawCardInOwned = 7;

		/// <summary>
		/// 反转论据
		/// </summary>
		public const short InvertBases = 8;

		/// <summary>
		/// 己方论据
		/// </summary>
		public const short ChangeSelfBases = 9;

		/// <summary>
		/// 己方策略
		/// </summary>
		public const short ChangeSelfStrategyPoint = 10;

		/// <summary>
		/// 伤人救己
		/// </summary>
		public const short ApplyToSelfWhenDamage = 11;

		/// <summary>
		/// 对方论据
		/// </summary>
		public const short ChangeOpponentBases = 12;

		/// <summary>
		/// 对方策略
		/// </summary>
		public const short ChangeOpponentStrategyPoint = 13;

		/// <summary>
		/// 伤人伤己
		/// </summary>
		public const short DamageMoreToBoth = 14;

		/// <summary>
		/// 改变结论
		/// </summary>
		public const short ChangeGamePoint = 15;

		/// <summary>
		/// 减半消除
		/// </summary>
		public const short HalfImmuneRemove = 16;

		/// <summary>
		/// 免疫受损
		/// </summary>
		public const short ImmuneDebuff = 17;

		/// <summary>
		/// 免疫消除
		/// </summary>
		public const short ImmuneRemove = 18;

		/// <summary>
		/// 改变论据
		/// </summary>
		public const short ChangeBases = 19;

		/// <summary>
		/// 揭示论据
		/// </summary>
		public const short RevealBases = 20;

		/// <summary>
		/// 消除论点
		/// </summary>
		public const short RemovePawn = 21;

		/// <summary>
		/// 论点链接
		/// </summary>
		public const short PawnLink = 22;

		/// <summary>
		/// 禁止落子
		/// </summary>
		public const short InvalidateMakeMove = 23;

		/// <summary>
		/// 多多益善
		/// </summary>
		public const short TheMoreTheBetter = 24;

		/// <summary>
		/// 减半落子
		/// </summary>
		public const short HalfMakeMove = 25;

		/// <summary>
		/// 论据链接
		/// </summary>
		public const short BasesLink = 26;

		/// <summary>
		/// 回收论据
		/// </summary>
		public const short RecycleBases = 27;

		/// <summary>
		/// 额外消耗
		/// </summary>
		public const short StrategyPointCostMore = 28;

		/// <summary>
		/// 论点后退
		/// </summary>
		public const short PawnBackward = 29;

		/// <summary>
		/// 回收卡片
		/// </summary>
		public const short RecycleStrategy = 30;

		/// <summary>
		/// 废卡利用
		/// </summary>
		public const short DrawCardInUsed = 31;

		/// <summary>
		/// 揭示策略
		/// </summary>
		public const short RevealStrategy = 32;

		/// <summary>
		/// 避战前进
		/// </summary>
		public const short PawnAvoidConflict = 33;

		/// <summary>
		/// 减半前进
		/// </summary>
		public const short PawnHalt = 34;

		/// <summary>
		/// 惰性附着
		/// </summary>
		public const short InertiaAddOn = 35;

		/// <summary>
		/// 合并论点
		/// </summary>
		public const short MergePawn = 36;

		/// <summary>
		/// 分解论点
		/// </summary>
		public const short SplitPawn = 37;

		/// <summary>
		/// 消除策略
		/// </summary>
		public const short RemoveStrategy = 38;

		/// <summary>
		/// 交换策略
		/// </summary>
		public const short ExchangeStrategy = 39;

		/// <summary>
		/// 交换卡片
		/// </summary>
		public const short ExchangeCard = 40;

		/// <summary>
		/// 随意落子
		/// </summary>
		public const short NoCountAsMakeMove = 41;

		/// <summary>
		/// 怪言乱语
		/// </summary>
		public const short TeleportToBottom = 42;

		/// <summary>
		/// 声威袭人
		/// </summary>
		public const short DamageMoreByNode = 43;

		/// <summary>
		/// 快人快语
		/// </summary>
		public const short MoveMore = 44;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 影响论据
		/// </summary>
		public static DebateStrategyEffectItem BuffBases => Instance[(short)0];

		/// <summary>
		/// 放置论点
		/// </summary>
		public static DebateStrategyEffectItem MakeMove => Instance[(short)1];

		/// <summary>
		/// 交换位置
		/// </summary>
		public static DebateStrategyEffectItem SwitchCoordinate => Instance[(short)2];

		/// <summary>
		/// 移动位置
		/// </summary>
		public static DebateStrategyEffectItem TeleportCoordinate => Instance[(short)3];

		/// <summary>
		/// 额外伤害
		/// </summary>
		public static DebateStrategyEffectItem DamageMore => Instance[(short)4];

		/// <summary>
		/// 额外前进
		/// </summary>
		public static DebateStrategyEffectItem ForwardMore => Instance[(short)5];

		/// <summary>
		/// 对手论据
		/// </summary>
		public static DebateStrategyEffectItem OpponentBases => Instance[(short)6];

		/// <summary>
		/// 抽卡待用
		/// </summary>
		public static DebateStrategyEffectItem DrawCardInOwned => Instance[(short)7];

		/// <summary>
		/// 反转论据
		/// </summary>
		public static DebateStrategyEffectItem InvertBases => Instance[(short)8];

		/// <summary>
		/// 己方论据
		/// </summary>
		public static DebateStrategyEffectItem ChangeSelfBases => Instance[(short)9];

		/// <summary>
		/// 己方策略
		/// </summary>
		public static DebateStrategyEffectItem ChangeSelfStrategyPoint => Instance[(short)10];

		/// <summary>
		/// 伤人救己
		/// </summary>
		public static DebateStrategyEffectItem ApplyToSelfWhenDamage => Instance[(short)11];

		/// <summary>
		/// 对方论据
		/// </summary>
		public static DebateStrategyEffectItem ChangeOpponentBases => Instance[(short)12];

		/// <summary>
		/// 对方策略
		/// </summary>
		public static DebateStrategyEffectItem ChangeOpponentStrategyPoint => Instance[(short)13];

		/// <summary>
		/// 伤人伤己
		/// </summary>
		public static DebateStrategyEffectItem DamageMoreToBoth => Instance[(short)14];

		/// <summary>
		/// 改变结论
		/// </summary>
		public static DebateStrategyEffectItem ChangeGamePoint => Instance[(short)15];

		/// <summary>
		/// 减半消除
		/// </summary>
		public static DebateStrategyEffectItem HalfImmuneRemove => Instance[(short)16];

		/// <summary>
		/// 免疫受损
		/// </summary>
		public static DebateStrategyEffectItem ImmuneDebuff => Instance[(short)17];

		/// <summary>
		/// 免疫消除
		/// </summary>
		public static DebateStrategyEffectItem ImmuneRemove => Instance[(short)18];

		/// <summary>
		/// 改变论据
		/// </summary>
		public static DebateStrategyEffectItem ChangeBases => Instance[(short)19];

		/// <summary>
		/// 揭示论据
		/// </summary>
		public static DebateStrategyEffectItem RevealBases => Instance[(short)20];

		/// <summary>
		/// 消除论点
		/// </summary>
		public static DebateStrategyEffectItem RemovePawn => Instance[(short)21];

		/// <summary>
		/// 论点链接
		/// </summary>
		public static DebateStrategyEffectItem PawnLink => Instance[(short)22];

		/// <summary>
		/// 禁止落子
		/// </summary>
		public static DebateStrategyEffectItem InvalidateMakeMove => Instance[(short)23];

		/// <summary>
		/// 多多益善
		/// </summary>
		public static DebateStrategyEffectItem TheMoreTheBetter => Instance[(short)24];

		/// <summary>
		/// 减半落子
		/// </summary>
		public static DebateStrategyEffectItem HalfMakeMove => Instance[(short)25];

		/// <summary>
		/// 论据链接
		/// </summary>
		public static DebateStrategyEffectItem BasesLink => Instance[(short)26];

		/// <summary>
		/// 回收论据
		/// </summary>
		public static DebateStrategyEffectItem RecycleBases => Instance[(short)27];

		/// <summary>
		/// 额外消耗
		/// </summary>
		public static DebateStrategyEffectItem StrategyPointCostMore => Instance[(short)28];

		/// <summary>
		/// 论点后退
		/// </summary>
		public static DebateStrategyEffectItem PawnBackward => Instance[(short)29];

		/// <summary>
		/// 回收卡片
		/// </summary>
		public static DebateStrategyEffectItem RecycleStrategy => Instance[(short)30];

		/// <summary>
		/// 废卡利用
		/// </summary>
		public static DebateStrategyEffectItem DrawCardInUsed => Instance[(short)31];

		/// <summary>
		/// 揭示策略
		/// </summary>
		public static DebateStrategyEffectItem RevealStrategy => Instance[(short)32];

		/// <summary>
		/// 避战前进
		/// </summary>
		public static DebateStrategyEffectItem PawnAvoidConflict => Instance[(short)33];

		/// <summary>
		/// 减半前进
		/// </summary>
		public static DebateStrategyEffectItem PawnHalt => Instance[(short)34];

		/// <summary>
		/// 惰性附着
		/// </summary>
		public static DebateStrategyEffectItem InertiaAddOn => Instance[(short)35];

		/// <summary>
		/// 合并论点
		/// </summary>
		public static DebateStrategyEffectItem MergePawn => Instance[(short)36];

		/// <summary>
		/// 分解论点
		/// </summary>
		public static DebateStrategyEffectItem SplitPawn => Instance[(short)37];

		/// <summary>
		/// 消除策略
		/// </summary>
		public static DebateStrategyEffectItem RemoveStrategy => Instance[(short)38];

		/// <summary>
		/// 交换策略
		/// </summary>
		public static DebateStrategyEffectItem ExchangeStrategy => Instance[(short)39];

		/// <summary>
		/// 交换卡片
		/// </summary>
		public static DebateStrategyEffectItem ExchangeCard => Instance[(short)40];

		/// <summary>
		/// 随意落子
		/// </summary>
		public static DebateStrategyEffectItem NoCountAsMakeMove => Instance[(short)41];

		/// <summary>
		/// 怪言乱语
		/// </summary>
		public static DebateStrategyEffectItem TeleportToBottom => Instance[(short)42];

		/// <summary>
		/// 声威袭人
		/// </summary>
		public static DebateStrategyEffectItem DamageMoreByNode => Instance[(short)43];

		/// <summary>
		/// 快人快语
		/// </summary>
		public static DebateStrategyEffectItem MoveMore => Instance[(short)44];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static DebateStrategyEffect Instance = new DebateStrategyEffect();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "TemplateId" };

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
		_dataArray.Add(new DebateStrategyEffectItem(0));
		_dataArray.Add(new DebateStrategyEffectItem(1));
		_dataArray.Add(new DebateStrategyEffectItem(2));
		_dataArray.Add(new DebateStrategyEffectItem(3));
		_dataArray.Add(new DebateStrategyEffectItem(4));
		_dataArray.Add(new DebateStrategyEffectItem(5));
		_dataArray.Add(new DebateStrategyEffectItem(6));
		_dataArray.Add(new DebateStrategyEffectItem(7));
		_dataArray.Add(new DebateStrategyEffectItem(8));
		_dataArray.Add(new DebateStrategyEffectItem(9));
		_dataArray.Add(new DebateStrategyEffectItem(10));
		_dataArray.Add(new DebateStrategyEffectItem(11));
		_dataArray.Add(new DebateStrategyEffectItem(12));
		_dataArray.Add(new DebateStrategyEffectItem(13));
		_dataArray.Add(new DebateStrategyEffectItem(14));
		_dataArray.Add(new DebateStrategyEffectItem(15));
		_dataArray.Add(new DebateStrategyEffectItem(16));
		_dataArray.Add(new DebateStrategyEffectItem(17));
		_dataArray.Add(new DebateStrategyEffectItem(18));
		_dataArray.Add(new DebateStrategyEffectItem(19));
		_dataArray.Add(new DebateStrategyEffectItem(20));
		_dataArray.Add(new DebateStrategyEffectItem(21));
		_dataArray.Add(new DebateStrategyEffectItem(22));
		_dataArray.Add(new DebateStrategyEffectItem(23));
		_dataArray.Add(new DebateStrategyEffectItem(24));
		_dataArray.Add(new DebateStrategyEffectItem(25));
		_dataArray.Add(new DebateStrategyEffectItem(26));
		_dataArray.Add(new DebateStrategyEffectItem(27));
		_dataArray.Add(new DebateStrategyEffectItem(28));
		_dataArray.Add(new DebateStrategyEffectItem(29));
		_dataArray.Add(new DebateStrategyEffectItem(30));
		_dataArray.Add(new DebateStrategyEffectItem(31));
		_dataArray.Add(new DebateStrategyEffectItem(32));
		_dataArray.Add(new DebateStrategyEffectItem(33));
		_dataArray.Add(new DebateStrategyEffectItem(34));
		_dataArray.Add(new DebateStrategyEffectItem(35));
		_dataArray.Add(new DebateStrategyEffectItem(36));
		_dataArray.Add(new DebateStrategyEffectItem(37));
		_dataArray.Add(new DebateStrategyEffectItem(38));
		_dataArray.Add(new DebateStrategyEffectItem(39));
		_dataArray.Add(new DebateStrategyEffectItem(40));
		_dataArray.Add(new DebateStrategyEffectItem(41));
		_dataArray.Add(new DebateStrategyEffectItem(42));
		_dataArray.Add(new DebateStrategyEffectItem(43));
		_dataArray.Add(new DebateStrategyEffectItem(44));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<DebateStrategyEffectItem>(45);
		CreateItems0();
	}
}
