using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class DebateStrategyEffect : ConfigData<DebateStrategyEffectItem, short>
{
	public static class DefKey
	{
		public const short BuffBases = 0;

		public const short MakeMove = 1;

		public const short SwitchCoordinate = 2;

		public const short TeleportCoordinate = 3;

		public const short DamageMore = 4;

		public const short ForwardMore = 5;

		public const short OpponentBases = 6;

		public const short DrawCardInOwned = 7;

		public const short InvertBases = 8;

		public const short ChangeSelfBases = 9;

		public const short ChangeSelfStrategyPoint = 10;

		public const short ApplyToSelfWhenDamage = 11;

		public const short ChangeOpponentBases = 12;

		public const short ChangeOpponentStrategyPoint = 13;

		public const short DamageMoreToBoth = 14;

		public const short ChangeGamePoint = 15;

		public const short HalfImmuneRemove = 16;

		public const short ImmuneDebuff = 17;

		public const short ImmuneRemove = 18;

		public const short ChangeBases = 19;

		public const short RevealBases = 20;

		public const short RemovePawn = 21;

		public const short PawnLink = 22;

		public const short InvalidateMakeMove = 23;

		public const short TheMoreTheBetter = 24;

		public const short HalfMakeMove = 25;

		public const short BasesLink = 26;

		public const short RecycleBases = 27;

		public const short StrategyPointCostMore = 28;

		public const short PawnBackward = 29;

		public const short RecycleStrategy = 30;

		public const short DrawCardInUsed = 31;

		public const short RevealStrategy = 32;

		public const short PawnAvoidConflict = 33;

		public const short PawnHalt = 34;

		public const short InertiaAddOn = 35;

		public const short MergePawn = 36;

		public const short SplitPawn = 37;

		public const short RemoveStrategy = 38;

		public const short ExchangeStrategy = 39;

		public const short ExchangeCard = 40;

		public const short NoCountAsMakeMove = 41;

		public const short TeleportToBottom = 42;

		public const short DamageMoreByNode = 43;

		public const short MoveMore = 44;
	}

	public static class DefValue
	{
		public static DebateStrategyEffectItem BuffBases => Instance[(short)0];

		public static DebateStrategyEffectItem MakeMove => Instance[(short)1];

		public static DebateStrategyEffectItem SwitchCoordinate => Instance[(short)2];

		public static DebateStrategyEffectItem TeleportCoordinate => Instance[(short)3];

		public static DebateStrategyEffectItem DamageMore => Instance[(short)4];

		public static DebateStrategyEffectItem ForwardMore => Instance[(short)5];

		public static DebateStrategyEffectItem OpponentBases => Instance[(short)6];

		public static DebateStrategyEffectItem DrawCardInOwned => Instance[(short)7];

		public static DebateStrategyEffectItem InvertBases => Instance[(short)8];

		public static DebateStrategyEffectItem ChangeSelfBases => Instance[(short)9];

		public static DebateStrategyEffectItem ChangeSelfStrategyPoint => Instance[(short)10];

		public static DebateStrategyEffectItem ApplyToSelfWhenDamage => Instance[(short)11];

		public static DebateStrategyEffectItem ChangeOpponentBases => Instance[(short)12];

		public static DebateStrategyEffectItem ChangeOpponentStrategyPoint => Instance[(short)13];

		public static DebateStrategyEffectItem DamageMoreToBoth => Instance[(short)14];

		public static DebateStrategyEffectItem ChangeGamePoint => Instance[(short)15];

		public static DebateStrategyEffectItem HalfImmuneRemove => Instance[(short)16];

		public static DebateStrategyEffectItem ImmuneDebuff => Instance[(short)17];

		public static DebateStrategyEffectItem ImmuneRemove => Instance[(short)18];

		public static DebateStrategyEffectItem ChangeBases => Instance[(short)19];

		public static DebateStrategyEffectItem RevealBases => Instance[(short)20];

		public static DebateStrategyEffectItem RemovePawn => Instance[(short)21];

		public static DebateStrategyEffectItem PawnLink => Instance[(short)22];

		public static DebateStrategyEffectItem InvalidateMakeMove => Instance[(short)23];

		public static DebateStrategyEffectItem TheMoreTheBetter => Instance[(short)24];

		public static DebateStrategyEffectItem HalfMakeMove => Instance[(short)25];

		public static DebateStrategyEffectItem BasesLink => Instance[(short)26];

		public static DebateStrategyEffectItem RecycleBases => Instance[(short)27];

		public static DebateStrategyEffectItem StrategyPointCostMore => Instance[(short)28];

		public static DebateStrategyEffectItem PawnBackward => Instance[(short)29];

		public static DebateStrategyEffectItem RecycleStrategy => Instance[(short)30];

		public static DebateStrategyEffectItem DrawCardInUsed => Instance[(short)31];

		public static DebateStrategyEffectItem RevealStrategy => Instance[(short)32];

		public static DebateStrategyEffectItem PawnAvoidConflict => Instance[(short)33];

		public static DebateStrategyEffectItem PawnHalt => Instance[(short)34];

		public static DebateStrategyEffectItem InertiaAddOn => Instance[(short)35];

		public static DebateStrategyEffectItem MergePawn => Instance[(short)36];

		public static DebateStrategyEffectItem SplitPawn => Instance[(short)37];

		public static DebateStrategyEffectItem RemoveStrategy => Instance[(short)38];

		public static DebateStrategyEffectItem ExchangeStrategy => Instance[(short)39];

		public static DebateStrategyEffectItem ExchangeCard => Instance[(short)40];

		public static DebateStrategyEffectItem NoCountAsMakeMove => Instance[(short)41];

		public static DebateStrategyEffectItem TeleportToBottom => Instance[(short)42];

		public static DebateStrategyEffectItem DamageMoreByNode => Instance[(short)43];

		public static DebateStrategyEffectItem MoveMore => Instance[(short)44];
	}

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
