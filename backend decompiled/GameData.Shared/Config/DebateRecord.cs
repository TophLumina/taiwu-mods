using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class DebateRecord : ConfigData<DebateRecordItem, short>
{
	public static class DefKey
	{
		public const short RoundStart = 0;

		public const short MakeMove = 1;

		public const short PawnReduceGamePoint = 2;

		public const short ShuffleCardGain = 3;

		public const short ShuffleCardLose = 4;

		public const short ResetStrategy = 5;

		public const short Comment = 6;

		public const short NodeEffectJustSpecial = 8;

		public const short NodeEffectEvenSpecial = 10;

		public const short PressureReduceGamePoint = 13;

		public const short PressureNoBasesRecover = 14;

		public const short PressureNoStrategyRecover = 15;

		public const short PressureUseBases = 16;

		public const short PressureUseStrategy = 17;

		public const short NpcUseStrategy = 18;

		public const short TaiwuUseTriggerStrategy = 19;

		public const short StrategyPoem3 = 28;

		public const short StrategyMedicine2Instant = 45;

		public const short StrategyMedicine2Special = 46;

		public const short StrategyJade1Special = 54;

		public const short StrategyJade2 = 55;

		public const short StrategyBuddhism3 = 62;
	}

	public static class DefValue
	{
		public static DebateRecordItem RoundStart => Instance[(short)0];

		public static DebateRecordItem MakeMove => Instance[(short)1];

		public static DebateRecordItem PawnReduceGamePoint => Instance[(short)2];

		public static DebateRecordItem ShuffleCardGain => Instance[(short)3];

		public static DebateRecordItem ShuffleCardLose => Instance[(short)4];

		public static DebateRecordItem ResetStrategy => Instance[(short)5];

		public static DebateRecordItem Comment => Instance[(short)6];

		public static DebateRecordItem NodeEffectJustSpecial => Instance[(short)8];

		public static DebateRecordItem NodeEffectEvenSpecial => Instance[(short)10];

		public static DebateRecordItem PressureReduceGamePoint => Instance[(short)13];

		public static DebateRecordItem PressureNoBasesRecover => Instance[(short)14];

		public static DebateRecordItem PressureNoStrategyRecover => Instance[(short)15];

		public static DebateRecordItem PressureUseBases => Instance[(short)16];

		public static DebateRecordItem PressureUseStrategy => Instance[(short)17];

		public static DebateRecordItem NpcUseStrategy => Instance[(short)18];

		public static DebateRecordItem TaiwuUseTriggerStrategy => Instance[(short)19];

		public static DebateRecordItem StrategyPoem3 => Instance[(short)28];

		public static DebateRecordItem StrategyMedicine2Instant => Instance[(short)45];

		public static DebateRecordItem StrategyMedicine2Special => Instance[(short)46];

		public static DebateRecordItem StrategyJade1Special => Instance[(short)54];

		public static DebateRecordItem StrategyJade2 => Instance[(short)55];

		public static DebateRecordItem StrategyBuddhism3 => Instance[(short)62];
	}

	public static DebateRecord Instance = new DebateRecord();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Desc", "Parameters", "TemplateId" };

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
		_dataArray.Add(new DebateRecordItem(0, LocalStringManager.GetConfig("DebateRecord_language", "Desc_0"), new EDebateRecordParamType[6]
		{
			EDebateRecordParamType.IntValue,
			EDebateRecordParamType.StrategyPoint,
			EDebateRecordParamType.IntValue,
			EDebateRecordParamType.Bases,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid
		}));
		_dataArray.Add(new DebateRecordItem(1, LocalStringManager.GetConfig("DebateRecord_language", "Desc_1"), new EDebateRecordParamType[6]
		{
			EDebateRecordParamType.IntValue,
			EDebateRecordParamType.SelfPawn,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid
		}));
		_dataArray.Add(new DebateRecordItem(2, LocalStringManager.GetConfig("DebateRecord_language", "Desc_2"), new EDebateRecordParamType[6]
		{
			EDebateRecordParamType.BottomNode,
			EDebateRecordParamType.OpponentPawn,
			EDebateRecordParamType.IntValue,
			EDebateRecordParamType.GamePoint,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid
		}));
		_dataArray.Add(new DebateRecordItem(3, LocalStringManager.GetConfig("DebateRecord_language", "Desc_3"), new EDebateRecordParamType[6]
		{
			EDebateRecordParamType.IntValue,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid
		}));
		_dataArray.Add(new DebateRecordItem(4, LocalStringManager.GetConfig("DebateRecord_language", "Desc_4"), new EDebateRecordParamType[6]
		{
			EDebateRecordParamType.IntValue,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid
		}));
		_dataArray.Add(new DebateRecordItem(5, LocalStringManager.GetConfig("DebateRecord_language", "Desc_5"), new EDebateRecordParamType[6]
		{
			EDebateRecordParamType.IntValue,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid
		}));
		_dataArray.Add(new DebateRecordItem(6, LocalStringManager.GetConfig("DebateRecord_language", "Desc_6"), new EDebateRecordParamType[6]
		{
			EDebateRecordParamType.Spectator,
			EDebateRecordParamType.Character,
			EDebateRecordParamType.Comment,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid
		}));
		_dataArray.Add(new DebateRecordItem(7, LocalStringManager.GetConfig("DebateRecord_language", "Desc_7"), new EDebateRecordParamType[6]
		{
			EDebateRecordParamType.SelfPawn,
			EDebateRecordParamType.Spectator,
			EDebateRecordParamType.NodeEffect,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid
		}));
		_dataArray.Add(new DebateRecordItem(8, LocalStringManager.GetConfig("DebateRecord_language", "Desc_8"), new EDebateRecordParamType[6]
		{
			EDebateRecordParamType.SelfPawn,
			EDebateRecordParamType.Spectator,
			EDebateRecordParamType.NodeEffect,
			EDebateRecordParamType.IntValue,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid
		}));
		_dataArray.Add(new DebateRecordItem(9, LocalStringManager.GetConfig("DebateRecord_language", "Desc_9"), new EDebateRecordParamType[6]
		{
			EDebateRecordParamType.SelfPawn,
			EDebateRecordParamType.Spectator,
			EDebateRecordParamType.NodeEffect,
			EDebateRecordParamType.IntValue,
			EDebateRecordParamType.Bases,
			EDebateRecordParamType.Invalid
		}));
		_dataArray.Add(new DebateRecordItem(10, LocalStringManager.GetConfig("DebateRecord_language", "Desc_10"), new EDebateRecordParamType[6]
		{
			EDebateRecordParamType.Spectator,
			EDebateRecordParamType.NodeEffect,
			EDebateRecordParamType.IntValue,
			EDebateRecordParamType.SelfPawn,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid
		}));
		_dataArray.Add(new DebateRecordItem(11, LocalStringManager.GetConfig("DebateRecord_language", "Desc_11"), new EDebateRecordParamType[6]
		{
			EDebateRecordParamType.SelfPawn,
			EDebateRecordParamType.Spectator,
			EDebateRecordParamType.NodeEffect,
			EDebateRecordParamType.Character,
			EDebateRecordParamType.BottomNode,
			EDebateRecordParamType.Invalid
		}));
		_dataArray.Add(new DebateRecordItem(12, LocalStringManager.GetConfig("DebateRecord_language", "Desc_12"), new EDebateRecordParamType[6]
		{
			EDebateRecordParamType.Spectator,
			EDebateRecordParamType.NodeEffect,
			EDebateRecordParamType.BottomNode,
			EDebateRecordParamType.OpponentPawn,
			EDebateRecordParamType.IntValue,
			EDebateRecordParamType.GamePoint
		}));
		_dataArray.Add(new DebateRecordItem(13, LocalStringManager.GetConfig("DebateRecord_language", "Desc_13"), new EDebateRecordParamType[6]
		{
			EDebateRecordParamType.Pressure,
			EDebateRecordParamType.IntValue,
			EDebateRecordParamType.IntValue,
			EDebateRecordParamType.GamePoint,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid
		}));
		_dataArray.Add(new DebateRecordItem(14, LocalStringManager.GetConfig("DebateRecord_language", "Desc_14"), new EDebateRecordParamType[6]
		{
			EDebateRecordParamType.Pressure,
			EDebateRecordParamType.IntValue,
			EDebateRecordParamType.Bases,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid
		}));
		_dataArray.Add(new DebateRecordItem(15, LocalStringManager.GetConfig("DebateRecord_language", "Desc_15"), new EDebateRecordParamType[6]
		{
			EDebateRecordParamType.Pressure,
			EDebateRecordParamType.IntValue,
			EDebateRecordParamType.StrategyPoint,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid
		}));
		_dataArray.Add(new DebateRecordItem(16, LocalStringManager.GetConfig("DebateRecord_language", "Desc_16"), new EDebateRecordParamType[6]
		{
			EDebateRecordParamType.Pressure,
			EDebateRecordParamType.IntValue,
			EDebateRecordParamType.SelfPawn,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid
		}));
		_dataArray.Add(new DebateRecordItem(17, LocalStringManager.GetConfig("DebateRecord_language", "Desc_17"), new EDebateRecordParamType[6]
		{
			EDebateRecordParamType.Pressure,
			EDebateRecordParamType.IntValue,
			EDebateRecordParamType.Strategy,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid
		}));
		_dataArray.Add(new DebateRecordItem(18, LocalStringManager.GetConfig("DebateRecord_language", "Desc_18"), new EDebateRecordParamType[6]
		{
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid
		}));
		_dataArray.Add(new DebateRecordItem(19, LocalStringManager.GetConfig("DebateRecord_language", "Desc_19"), new EDebateRecordParamType[6]
		{
			EDebateRecordParamType.Strategy,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid
		}));
		_dataArray.Add(new DebateRecordItem(20, LocalStringManager.GetConfig("DebateRecord_language", "Desc_20"), new EDebateRecordParamType[6]
		{
			EDebateRecordParamType.Strategy,
			EDebateRecordParamType.OpponentPawn,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid
		}));
		_dataArray.Add(new DebateRecordItem(21, LocalStringManager.GetConfig("DebateRecord_language", "Desc_21"), new EDebateRecordParamType[6]
		{
			EDebateRecordParamType.Strategy,
			EDebateRecordParamType.OpponentPawn,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid
		}));
		_dataArray.Add(new DebateRecordItem(22, LocalStringManager.GetConfig("DebateRecord_language", "Desc_22"), new EDebateRecordParamType[6]
		{
			EDebateRecordParamType.Strategy,
			EDebateRecordParamType.OpponentPawn,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid
		}));
		_dataArray.Add(new DebateRecordItem(23, LocalStringManager.GetConfig("DebateRecord_language", "Desc_23"), new EDebateRecordParamType[6]
		{
			EDebateRecordParamType.Strategy,
			EDebateRecordParamType.PawnCount,
			EDebateRecordParamType.SelfPawn,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid
		}));
		_dataArray.Add(new DebateRecordItem(24, LocalStringManager.GetConfig("DebateRecord_language", "Desc_24"), new EDebateRecordParamType[6]
		{
			EDebateRecordParamType.Strategy,
			EDebateRecordParamType.PawnCount,
			EDebateRecordParamType.SelfPawn,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid
		}));
		_dataArray.Add(new DebateRecordItem(25, LocalStringManager.GetConfig("DebateRecord_language", "Desc_25"), new EDebateRecordParamType[6]
		{
			EDebateRecordParamType.Strategy,
			EDebateRecordParamType.PawnCount,
			EDebateRecordParamType.SelfPawn,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid
		}));
		_dataArray.Add(new DebateRecordItem(26, LocalStringManager.GetConfig("DebateRecord_language", "Desc_26"), new EDebateRecordParamType[6]
		{
			EDebateRecordParamType.Strategy,
			EDebateRecordParamType.OpponentPawn,
			EDebateRecordParamType.BottomNode,
			EDebateRecordParamType.IntValue,
			EDebateRecordParamType.GamePoint,
			EDebateRecordParamType.Invalid
		}));
		_dataArray.Add(new DebateRecordItem(27, LocalStringManager.GetConfig("DebateRecord_language", "Desc_27"), new EDebateRecordParamType[6]
		{
			EDebateRecordParamType.Strategy,
			EDebateRecordParamType.SelfPawn,
			EDebateRecordParamType.IntValue,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid
		}));
		_dataArray.Add(new DebateRecordItem(28, LocalStringManager.GetConfig("DebateRecord_language", "Desc_28"), new EDebateRecordParamType[6]
		{
			EDebateRecordParamType.SelfPawn,
			EDebateRecordParamType.Strategy,
			EDebateRecordParamType.OpponentPawn,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid
		}));
		_dataArray.Add(new DebateRecordItem(29, LocalStringManager.GetConfig("DebateRecord_language", "Desc_29"), new EDebateRecordParamType[6]
		{
			EDebateRecordParamType.Strategy,
			EDebateRecordParamType.SelfPawn,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid
		}));
		_dataArray.Add(new DebateRecordItem(30, LocalStringManager.GetConfig("DebateRecord_language", "Desc_30"), new EDebateRecordParamType[6]
		{
			EDebateRecordParamType.Strategy,
			EDebateRecordParamType.SelfPawn,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid
		}));
		_dataArray.Add(new DebateRecordItem(31, LocalStringManager.GetConfig("DebateRecord_language", "Desc_31"), new EDebateRecordParamType[6]
		{
			EDebateRecordParamType.Strategy,
			EDebateRecordParamType.SelfPawn,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid
		}));
		_dataArray.Add(new DebateRecordItem(32, LocalStringManager.GetConfig("DebateRecord_language", "Desc_32"), new EDebateRecordParamType[6]
		{
			EDebateRecordParamType.Strategy,
			EDebateRecordParamType.OwnedCards,
			EDebateRecordParamType.IntValue,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid
		}));
		_dataArray.Add(new DebateRecordItem(33, LocalStringManager.GetConfig("DebateRecord_language", "Desc_33"), new EDebateRecordParamType[6]
		{
			EDebateRecordParamType.Strategy,
			EDebateRecordParamType.Pawn,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid
		}));
		_dataArray.Add(new DebateRecordItem(34, LocalStringManager.GetConfig("DebateRecord_language", "Desc_34"), new EDebateRecordParamType[6]
		{
			EDebateRecordParamType.Strategy,
			EDebateRecordParamType.IntValue,
			EDebateRecordParamType.OpponentPawn,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid
		}));
		_dataArray.Add(new DebateRecordItem(35, LocalStringManager.GetConfig("DebateRecord_language", "Desc_35"), new EDebateRecordParamType[6]
		{
			EDebateRecordParamType.SelfPawn,
			EDebateRecordParamType.Strategy,
			EDebateRecordParamType.IntValue,
			EDebateRecordParamType.Bases,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid
		}));
		_dataArray.Add(new DebateRecordItem(36, LocalStringManager.GetConfig("DebateRecord_language", "Desc_36"), new EDebateRecordParamType[6]
		{
			EDebateRecordParamType.SelfPawn,
			EDebateRecordParamType.Strategy,
			EDebateRecordParamType.IntValue,
			EDebateRecordParamType.StrategyPoint,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid
		}));
		_dataArray.Add(new DebateRecordItem(37, LocalStringManager.GetConfig("DebateRecord_language", "Desc_37"), new EDebateRecordParamType[6]
		{
			EDebateRecordParamType.BottomNode,
			EDebateRecordParamType.SelfPawn,
			EDebateRecordParamType.Strategy,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid
		}));
		_dataArray.Add(new DebateRecordItem(38, LocalStringManager.GetConfig("DebateRecord_language", "Desc_38"), new EDebateRecordParamType[6]
		{
			EDebateRecordParamType.SelfPawn,
			EDebateRecordParamType.Strategy,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid
		}));
		_dataArray.Add(new DebateRecordItem(39, LocalStringManager.GetConfig("DebateRecord_language", "Desc_39"), new EDebateRecordParamType[6]
		{
			EDebateRecordParamType.SelfPawn,
			EDebateRecordParamType.Strategy,
			EDebateRecordParamType.BottomNode,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid
		}));
		_dataArray.Add(new DebateRecordItem(40, LocalStringManager.GetConfig("DebateRecord_language", "Desc_40"), new EDebateRecordParamType[6]
		{
			EDebateRecordParamType.SelfPawn,
			EDebateRecordParamType.Strategy,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid
		}));
		_dataArray.Add(new DebateRecordItem(41, LocalStringManager.GetConfig("DebateRecord_language", "Desc_41"), new EDebateRecordParamType[6]
		{
			EDebateRecordParamType.SelfPawn,
			EDebateRecordParamType.Strategy,
			EDebateRecordParamType.IntValue,
			EDebateRecordParamType.Bases,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid
		}));
		_dataArray.Add(new DebateRecordItem(42, LocalStringManager.GetConfig("DebateRecord_language", "Desc_42"), new EDebateRecordParamType[6]
		{
			EDebateRecordParamType.SelfPawn,
			EDebateRecordParamType.Strategy,
			EDebateRecordParamType.IntValue,
			EDebateRecordParamType.StrategyPoint,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid
		}));
		_dataArray.Add(new DebateRecordItem(43, LocalStringManager.GetConfig("DebateRecord_language", "Desc_43"), new EDebateRecordParamType[6]
		{
			EDebateRecordParamType.Strategy,
			EDebateRecordParamType.SelfPawn,
			EDebateRecordParamType.IntValue,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid
		}));
		_dataArray.Add(new DebateRecordItem(44, LocalStringManager.GetConfig("DebateRecord_language", "Desc_44"), new EDebateRecordParamType[6]
		{
			EDebateRecordParamType.Strategy,
			EDebateRecordParamType.OpponentPawn,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid
		}));
		_dataArray.Add(new DebateRecordItem(45, LocalStringManager.GetConfig("DebateRecord_language", "Desc_45"), new EDebateRecordParamType[6]
		{
			EDebateRecordParamType.Strategy,
			EDebateRecordParamType.PawnCount,
			EDebateRecordParamType.Pawn,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid
		}));
		_dataArray.Add(new DebateRecordItem(46, LocalStringManager.GetConfig("DebateRecord_language", "Desc_46"), new EDebateRecordParamType[6]
		{
			EDebateRecordParamType.Strategy,
			EDebateRecordParamType.IntValue,
			EDebateRecordParamType.GamePoint,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid
		}));
		_dataArray.Add(new DebateRecordItem(47, LocalStringManager.GetConfig("DebateRecord_language", "Desc_47"), new EDebateRecordParamType[6]
		{
			EDebateRecordParamType.Strategy,
			EDebateRecordParamType.SelfPawn,
			EDebateRecordParamType.BottomNode,
			EDebateRecordParamType.IntValue,
			EDebateRecordParamType.GamePoint,
			EDebateRecordParamType.Invalid
		}));
		_dataArray.Add(new DebateRecordItem(48, LocalStringManager.GetConfig("DebateRecord_language", "Desc_48"), new EDebateRecordParamType[6]
		{
			EDebateRecordParamType.Strategy,
			EDebateRecordParamType.Pawn,
			EDebateRecordParamType.SelfPawn,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid
		}));
		_dataArray.Add(new DebateRecordItem(49, LocalStringManager.GetConfig("DebateRecord_language", "Desc_49"), new EDebateRecordParamType[6]
		{
			EDebateRecordParamType.Strategy,
			EDebateRecordParamType.SelfPawn,
			EDebateRecordParamType.BottomNode,
			EDebateRecordParamType.IntValue,
			EDebateRecordParamType.GamePoint,
			EDebateRecordParamType.Invalid
		}));
		_dataArray.Add(new DebateRecordItem(50, LocalStringManager.GetConfig("DebateRecord_language", "Desc_50"), new EDebateRecordParamType[6]
		{
			EDebateRecordParamType.Strategy,
			EDebateRecordParamType.SelfPawn,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid
		}));
		_dataArray.Add(new DebateRecordItem(51, LocalStringManager.GetConfig("DebateRecord_language", "Desc_51"), new EDebateRecordParamType[6]
		{
			EDebateRecordParamType.Strategy,
			EDebateRecordParamType.SelfPawn,
			EDebateRecordParamType.PawnCount,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid
		}));
		_dataArray.Add(new DebateRecordItem(52, LocalStringManager.GetConfig("DebateRecord_language", "Desc_52"), new EDebateRecordParamType[6]
		{
			EDebateRecordParamType.Strategy,
			EDebateRecordParamType.PawnCount,
			EDebateRecordParamType.SelfPawn,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid
		}));
		_dataArray.Add(new DebateRecordItem(53, LocalStringManager.GetConfig("DebateRecord_language", "Desc_53"), new EDebateRecordParamType[6]
		{
			EDebateRecordParamType.Strategy,
			EDebateRecordParamType.PawnCount,
			EDebateRecordParamType.Pawn,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid
		}));
		_dataArray.Add(new DebateRecordItem(54, LocalStringManager.GetConfig("DebateRecord_language", "Desc_54"), new EDebateRecordParamType[6]
		{
			EDebateRecordParamType.Strategy,
			EDebateRecordParamType.IntValue,
			EDebateRecordParamType.Bases,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid
		}));
		_dataArray.Add(new DebateRecordItem(55, LocalStringManager.GetConfig("DebateRecord_language", "Desc_55"), new EDebateRecordParamType[6]
		{
			EDebateRecordParamType.Strategy,
			EDebateRecordParamType.Pawn,
			EDebateRecordParamType.Strategy,
			EDebateRecordParamType.IntValue,
			EDebateRecordParamType.StrategyPoint,
			EDebateRecordParamType.Invalid
		}));
		_dataArray.Add(new DebateRecordItem(56, LocalStringManager.GetConfig("DebateRecord_language", "Desc_56"), new EDebateRecordParamType[6]
		{
			EDebateRecordParamType.Strategy,
			EDebateRecordParamType.Pawn,
			EDebateRecordParamType.BottomNode,
			EDebateRecordParamType.IntValue,
			EDebateRecordParamType.GamePoint,
			EDebateRecordParamType.Invalid
		}));
		_dataArray.Add(new DebateRecordItem(57, LocalStringManager.GetConfig("DebateRecord_language", "Desc_57"), new EDebateRecordParamType[6]
		{
			EDebateRecordParamType.Strategy,
			EDebateRecordParamType.PawnCount,
			EDebateRecordParamType.Pawn,
			EDebateRecordParamType.IntValue,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid
		}));
		_dataArray.Add(new DebateRecordItem(58, LocalStringManager.GetConfig("DebateRecord_language", "Desc_58"), new EDebateRecordParamType[6]
		{
			EDebateRecordParamType.Strategy,
			EDebateRecordParamType.Strategy,
			EDebateRecordParamType.IntValue,
			EDebateRecordParamType.StrategyPoint,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid
		}));
		_dataArray.Add(new DebateRecordItem(59, LocalStringManager.GetConfig("DebateRecord_language", "Desc_59"), new EDebateRecordParamType[6]
		{
			EDebateRecordParamType.Strategy,
			EDebateRecordParamType.UsedCards,
			EDebateRecordParamType.IntValue,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid
		}));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new DebateRecordItem(60, LocalStringManager.GetConfig("DebateRecord_language", "Desc_60"), new EDebateRecordParamType[6]
		{
			EDebateRecordParamType.Strategy,
			EDebateRecordParamType.PawnCount,
			EDebateRecordParamType.Pawn,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid
		}));
		_dataArray.Add(new DebateRecordItem(61, LocalStringManager.GetConfig("DebateRecord_language", "Desc_61"), new EDebateRecordParamType[6]
		{
			EDebateRecordParamType.SelfPawn,
			EDebateRecordParamType.Strategy,
			EDebateRecordParamType.OpponentPawn,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid
		}));
		_dataArray.Add(new DebateRecordItem(62, LocalStringManager.GetConfig("DebateRecord_language", "Desc_62"), new EDebateRecordParamType[6]
		{
			EDebateRecordParamType.SelfPawn,
			EDebateRecordParamType.Strategy,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid
		}));
		_dataArray.Add(new DebateRecordItem(63, LocalStringManager.GetConfig("DebateRecord_language", "Desc_63"), new EDebateRecordParamType[6]
		{
			EDebateRecordParamType.Strategy,
			EDebateRecordParamType.Pawn,
			EDebateRecordParamType.IntValue,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid
		}));
		_dataArray.Add(new DebateRecordItem(64, LocalStringManager.GetConfig("DebateRecord_language", "Desc_64"), new EDebateRecordParamType[6]
		{
			EDebateRecordParamType.Strategy,
			EDebateRecordParamType.Pawn,
			EDebateRecordParamType.Pawn,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid
		}));
		_dataArray.Add(new DebateRecordItem(65, LocalStringManager.GetConfig("DebateRecord_language", "Desc_65"), new EDebateRecordParamType[6]
		{
			EDebateRecordParamType.Pawn,
			EDebateRecordParamType.Strategy,
			EDebateRecordParamType.IntValue,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid
		}));
		_dataArray.Add(new DebateRecordItem(66, LocalStringManager.GetConfig("DebateRecord_language", "Desc_66"), new EDebateRecordParamType[6]
		{
			EDebateRecordParamType.Strategy,
			EDebateRecordParamType.Pawn,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid
		}));
		_dataArray.Add(new DebateRecordItem(67, LocalStringManager.GetConfig("DebateRecord_language", "Desc_67"), new EDebateRecordParamType[6]
		{
			EDebateRecordParamType.Strategy,
			EDebateRecordParamType.Pawn,
			EDebateRecordParamType.Pawn,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid
		}));
		_dataArray.Add(new DebateRecordItem(68, LocalStringManager.GetConfig("DebateRecord_language", "Desc_68"), new EDebateRecordParamType[6]
		{
			EDebateRecordParamType.Strategy,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid,
			EDebateRecordParamType.Invalid
		}));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<DebateRecordItem>(69);
		CreateItems0();
		CreateItems1();
	}
}
