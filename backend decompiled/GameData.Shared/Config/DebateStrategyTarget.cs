using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class DebateStrategyTarget : ConfigData<DebateStrategyTargetItem, short>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 己方可重复论点
		/// </summary>
		public const short SelfRepeatablePawn = 0;

		/// <summary>
		/// 己方不重复论点
		/// </summary>
		public const short SelfDistinctPawn = 1;

		/// <summary>
		/// 对方可重复论点
		/// </summary>
		public const short OpponentRepeatablePawn = 2;

		/// <summary>
		/// 对方不重复论点
		/// </summary>
		public const short OpponentDistinctPawn = 3;

		/// <summary>
		/// 双方可重复论点
		/// </summary>
		public const short BothRepeatablePawn = 4;

		/// <summary>
		/// 双方不重复论点
		/// </summary>
		public const short BothDistinctPawn = 5;

		/// <summary>
		/// 非对方底线空格
		/// </summary>
		public const short NonOpponentBottomNode = 6;

		/// <summary>
		/// 非己方底线空格
		/// </summary>
		public const short NonSelfBottomNode = 7;

		/// <summary>
		/// 己方相邻空格
		/// </summary>
		public const short SelfNeighborNode = 8;

		/// <summary>
		/// 论点等级
		/// </summary>
		public const short PawnGrade = 9;

		/// <summary>
		/// 策略卡片
		/// </summary>
		public const short StrategyCard = 10;

		/// <summary>
		/// 宽松论点
		/// </summary>
		public const short LoosePawn = 11;

		/// <summary>
		/// 未揭示论据论点
		/// </summary>
		public const short BasesNotRevealedPawn = 12;

		/// <summary>
		/// 未揭示策略论点
		/// </summary>
		public const short StrategiesNotRevealedPawn = 13;

		/// <summary>
		/// 可移除策略论点
		/// </summary>
		public const short RemovableStrategyPawn = 14;

		/// <summary>
		/// 待用卡组
		/// </summary>
		public const short OwnedCard = 15;

		/// <summary>
		/// 弃用卡组
		/// </summary>
		public const short UsedCard = 16;

		/// <summary>
		/// 对手卡组
		/// </summary>
		public const short OpponentCard = 17;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 己方可重复论点
		/// </summary>
		public static DebateStrategyTargetItem SelfRepeatablePawn => Instance[(short)0];

		/// <summary>
		/// 己方不重复论点
		/// </summary>
		public static DebateStrategyTargetItem SelfDistinctPawn => Instance[(short)1];

		/// <summary>
		/// 对方可重复论点
		/// </summary>
		public static DebateStrategyTargetItem OpponentRepeatablePawn => Instance[(short)2];

		/// <summary>
		/// 对方不重复论点
		/// </summary>
		public static DebateStrategyTargetItem OpponentDistinctPawn => Instance[(short)3];

		/// <summary>
		/// 双方可重复论点
		/// </summary>
		public static DebateStrategyTargetItem BothRepeatablePawn => Instance[(short)4];

		/// <summary>
		/// 双方不重复论点
		/// </summary>
		public static DebateStrategyTargetItem BothDistinctPawn => Instance[(short)5];

		/// <summary>
		/// 非对方底线空格
		/// </summary>
		public static DebateStrategyTargetItem NonOpponentBottomNode => Instance[(short)6];

		/// <summary>
		/// 非己方底线空格
		/// </summary>
		public static DebateStrategyTargetItem NonSelfBottomNode => Instance[(short)7];

		/// <summary>
		/// 己方相邻空格
		/// </summary>
		public static DebateStrategyTargetItem SelfNeighborNode => Instance[(short)8];

		/// <summary>
		/// 论点等级
		/// </summary>
		public static DebateStrategyTargetItem PawnGrade => Instance[(short)9];

		/// <summary>
		/// 策略卡片
		/// </summary>
		public static DebateStrategyTargetItem StrategyCard => Instance[(short)10];

		/// <summary>
		/// 宽松论点
		/// </summary>
		public static DebateStrategyTargetItem LoosePawn => Instance[(short)11];

		/// <summary>
		/// 未揭示论据论点
		/// </summary>
		public static DebateStrategyTargetItem BasesNotRevealedPawn => Instance[(short)12];

		/// <summary>
		/// 未揭示策略论点
		/// </summary>
		public static DebateStrategyTargetItem StrategiesNotRevealedPawn => Instance[(short)13];

		/// <summary>
		/// 可移除策略论点
		/// </summary>
		public static DebateStrategyTargetItem RemovableStrategyPawn => Instance[(short)14];

		/// <summary>
		/// 待用卡组
		/// </summary>
		public static DebateStrategyTargetItem OwnedCard => Instance[(short)15];

		/// <summary>
		/// 弃用卡组
		/// </summary>
		public static DebateStrategyTargetItem UsedCard => Instance[(short)16];

		/// <summary>
		/// 对手卡组
		/// </summary>
		public static DebateStrategyTargetItem OpponentCard => Instance[(short)17];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static DebateStrategyTarget Instance = new DebateStrategyTarget();

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
		_dataArray.Add(new DebateStrategyTargetItem(0, LocalStringManager.GetConfig("DebateStrategyTarget_language", "Name_0"), EDebateStrategyTargetObjectType.Pawn));
		_dataArray.Add(new DebateStrategyTargetItem(1, LocalStringManager.GetConfig("DebateStrategyTarget_language", "Name_1"), EDebateStrategyTargetObjectType.Pawn));
		_dataArray.Add(new DebateStrategyTargetItem(2, LocalStringManager.GetConfig("DebateStrategyTarget_language", "Name_2"), EDebateStrategyTargetObjectType.Pawn));
		_dataArray.Add(new DebateStrategyTargetItem(3, LocalStringManager.GetConfig("DebateStrategyTarget_language", "Name_3"), EDebateStrategyTargetObjectType.Pawn));
		_dataArray.Add(new DebateStrategyTargetItem(4, LocalStringManager.GetConfig("DebateStrategyTarget_language", "Name_4"), EDebateStrategyTargetObjectType.Pawn));
		_dataArray.Add(new DebateStrategyTargetItem(5, LocalStringManager.GetConfig("DebateStrategyTarget_language", "Name_5"), EDebateStrategyTargetObjectType.Pawn));
		_dataArray.Add(new DebateStrategyTargetItem(6, LocalStringManager.GetConfig("DebateStrategyTarget_language", "Name_6"), EDebateStrategyTargetObjectType.Node));
		_dataArray.Add(new DebateStrategyTargetItem(7, LocalStringManager.GetConfig("DebateStrategyTarget_language", "Name_7"), EDebateStrategyTargetObjectType.Node));
		_dataArray.Add(new DebateStrategyTargetItem(8, LocalStringManager.GetConfig("DebateStrategyTarget_language", "Name_8"), EDebateStrategyTargetObjectType.Node));
		_dataArray.Add(new DebateStrategyTargetItem(9, LocalStringManager.GetConfig("DebateStrategyTarget_language", "Name_9"), EDebateStrategyTargetObjectType.PawnGrade));
		_dataArray.Add(new DebateStrategyTargetItem(10, LocalStringManager.GetConfig("DebateStrategyTarget_language", "Name_10"), EDebateStrategyTargetObjectType.StrategyCard));
		_dataArray.Add(new DebateStrategyTargetItem(11, LocalStringManager.GetConfig("DebateStrategyTarget_language", "Name_11"), EDebateStrategyTargetObjectType.Pawn));
		_dataArray.Add(new DebateStrategyTargetItem(12, LocalStringManager.GetConfig("DebateStrategyTarget_language", "Name_12"), EDebateStrategyTargetObjectType.Pawn));
		_dataArray.Add(new DebateStrategyTargetItem(13, LocalStringManager.GetConfig("DebateStrategyTarget_language", "Name_13"), EDebateStrategyTargetObjectType.Pawn));
		_dataArray.Add(new DebateStrategyTargetItem(14, LocalStringManager.GetConfig("DebateStrategyTarget_language", "Name_14"), EDebateStrategyTargetObjectType.Pawn));
		_dataArray.Add(new DebateStrategyTargetItem(15, LocalStringManager.GetConfig("DebateStrategyTarget_language", "Name_15"), EDebateStrategyTargetObjectType.StrategyCard));
		_dataArray.Add(new DebateStrategyTargetItem(16, LocalStringManager.GetConfig("DebateStrategyTarget_language", "Name_16"), EDebateStrategyTargetObjectType.StrategyCard));
		_dataArray.Add(new DebateStrategyTargetItem(17, LocalStringManager.GetConfig("DebateStrategyTarget_language", "Name_17"), EDebateStrategyTargetObjectType.StrategyCard));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<DebateStrategyTargetItem>(18);
		CreateItems0();
	}
}
