using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class SettlementPrisonEventEffect : ConfigData<SettlementPrisonEventEffectItem, short>
{
	public static class DefKey
	{
		public const short SendToPrison = 0;

		public const short BreakIntoPrisonLow = 1;

		public const short BreakIntoPrisonMid = 2;

		public const short BreakIntoPrisonHigh = 3;

		public const short KidnapInfectedPrisoner = 4;

		public const short RescuePrisonerLow = 5;

		public const short RescuePrisonerMid = 6;

		public const short RescuePrisonerHigh = 7;

		public const short FightHunterSuccess = 8;

		public const short FightHunterFail = 9;

		public const short GiveHunterTeammate = 10;

		public const short ArrestPrisonerSuccess = 11;

		public const short ArrestPrisonerFail = 12;

		public const short AskForPrisoner = 13;

		public const short AskForPrisonerRelease = 14;

		public const short AskForPrisonerKidnap = 15;

		public const short TaiwuFightHunterSuccess = 16;
	}

	public static class DefValue
	{
		public static SettlementPrisonEventEffectItem SendToPrison => Instance[(short)0];

		public static SettlementPrisonEventEffectItem BreakIntoPrisonLow => Instance[(short)1];

		public static SettlementPrisonEventEffectItem BreakIntoPrisonMid => Instance[(short)2];

		public static SettlementPrisonEventEffectItem BreakIntoPrisonHigh => Instance[(short)3];

		public static SettlementPrisonEventEffectItem KidnapInfectedPrisoner => Instance[(short)4];

		public static SettlementPrisonEventEffectItem RescuePrisonerLow => Instance[(short)5];

		public static SettlementPrisonEventEffectItem RescuePrisonerMid => Instance[(short)6];

		public static SettlementPrisonEventEffectItem RescuePrisonerHigh => Instance[(short)7];

		public static SettlementPrisonEventEffectItem FightHunterSuccess => Instance[(short)8];

		public static SettlementPrisonEventEffectItem FightHunterFail => Instance[(short)9];

		public static SettlementPrisonEventEffectItem GiveHunterTeammate => Instance[(short)10];

		public static SettlementPrisonEventEffectItem ArrestPrisonerSuccess => Instance[(short)11];

		public static SettlementPrisonEventEffectItem ArrestPrisonerFail => Instance[(short)12];

		public static SettlementPrisonEventEffectItem AskForPrisoner => Instance[(short)13];

		public static SettlementPrisonEventEffectItem AskForPrisonerRelease => Instance[(short)14];

		public static SettlementPrisonEventEffectItem AskForPrisonerKidnap => Instance[(short)15];

		public static SettlementPrisonEventEffectItem TaiwuFightHunterSuccess => Instance[(short)16];
	}

	public static SettlementPrisonEventEffect Instance = new SettlementPrisonEventEffect();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "TaiwuBounty", "TemplateId" };

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
		_dataArray.Add(new SettlementPrisonEventEffectItem(0, -12000, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 0));
		_dataArray.Add(new SettlementPrisonEventEffectItem(1, 0, 0, 100, 1, -30000, 100, 0, 100, 30, 1, -15000, 30, 0, 30, 168, 3));
		_dataArray.Add(new SettlementPrisonEventEffectItem(2, 0, 0, 100, 1, -30000, 100, 0, 100, 60, 1, -15000, 60, 0, 60, 169, 6));
		_dataArray.Add(new SettlementPrisonEventEffectItem(3, 0, 0, 100, 1, -30000, 100, 0, 100, 90, 1, -15000, 90, 0, 90, 170, 12));
		_dataArray.Add(new SettlementPrisonEventEffectItem(4, 0, 0, 0, 0, 0, 0, 25, 0, 20, 1, 10000, 0, 25, 0, -1, 0));
		_dataArray.Add(new SettlementPrisonEventEffectItem(5, 0, 0, 100, 1, -30000, 100, 0, 100, 30, 1, -15000, 30, 0, 30, 168, 3));
		_dataArray.Add(new SettlementPrisonEventEffectItem(6, 0, 0, 100, 1, -30000, 100, 0, 100, 60, 1, -15000, 60, 0, 60, 169, 6));
		_dataArray.Add(new SettlementPrisonEventEffectItem(7, 0, 0, 100, 1, -30000, 100, 0, 100, 90, 1, -15000, 90, 0, 90, 170, 12));
		_dataArray.Add(new SettlementPrisonEventEffectItem(8, 9000, 0, 100, 1, -30000, 100, 0, 100, 30, 1, -15000, 50, 0, 50, -1, 0));
		_dataArray.Add(new SettlementPrisonEventEffectItem(9, 6000, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 0));
		_dataArray.Add(new SettlementPrisonEventEffectItem(10, -12000, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 0));
		_dataArray.Add(new SettlementPrisonEventEffectItem(11, -9000, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 0));
		_dataArray.Add(new SettlementPrisonEventEffectItem(12, -3000, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 0));
		_dataArray.Add(new SettlementPrisonEventEffectItem(13, 9000, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 0));
		_dataArray.Add(new SettlementPrisonEventEffectItem(14, 6000, -6000, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 0));
		_dataArray.Add(new SettlementPrisonEventEffectItem(15, 0, -6000, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 0));
		_dataArray.Add(new SettlementPrisonEventEffectItem(16, 0, -6000, 100, 1, -30000, 100, 0, 100, 30, 1, -15000, 50, 0, 50, -1, 0));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<SettlementPrisonEventEffectItem>(17);
		CreateItems0();
	}
}
