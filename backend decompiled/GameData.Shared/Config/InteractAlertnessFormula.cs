using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class InteractAlertnessFormula : ConfigData<InteractAlertnessFormulaItem, int>
{
	public static class DefKey
	{
		public const int GiveTeammateResource = 0;

		public const int GiveTeammateItem = 1;

		public const int TalkByNormalInformationGood = 2;

		public const int TalkByNormalInformationNormal = 3;

		public const int SendGiftLove = 4;

		public const int SendGiftNormal = 5;

		public const int SendGiftHate = 6;

		public const int MakeLineAndBridge = 7;

		public const int ProfessionWineTasterSkill0 = 8;

		public const int ProfessionWineTasterSkill3 = 9;

		public const int ProfessionLiteratiSkill3 = 10;

		public const int ProfessionTaoistMonkSkill1 = 11;

		public const int ProfessionAristocratSkill0 = 12;

		public const int ProfessionAristocratSkill1 = 13;

		public const int ProfessionBeggarSkill3 = 14;

		public const int ProfessionCivilianSkill0 = 15;

		public const int ProfessionCivilianSkill1 = 16;

		public const int ProfessionDoctorSkill0 = 17;

		public const int ProfessionDoctorSkill1 = 18;

		public const int ProfessionDoctorSkill3 = 19;

		public const int ProfessionTeaTasterSkill0 = 20;

		public const int ProfessionTeaTasterSkill3 = 21;

		public const int ProfessionDukeSkill1Add = 22;

		public const int ProfessionMartialArtistSkill0 = 23;

		public const int TakeTeammateResource = 24;

		public const int TakeTeammateItem = 25;

		public const int StealLifeSkill = 26;

		public const int StealCombatSkill = 27;

		public const int ScamLifeSkill = 28;

		public const int ScamCombatSkill = 29;

		public const int ScamItem = 30;

		public const int ScamResource = 31;

		public const int ScamNormalInformation = 32;

		public const int ScamSecretInformation = 33;

		public const int StealItem = 34;

		public const int StealResource = 35;

		public const int RobItem = 36;

		public const int RobResource = 37;

		public const int Poison = 38;

		public const int Damage = 39;

		public const int Attack = 40;

		public const int AttackKidnappedCharacter = 41;

		public const int ProfessionCivilianSkill2 = 42;

		public const int ProfessionDukeSkill1Remove = 43;

		public const int JoinTaiwuVillage = 44;
	}

	public static class DefValue
	{
		public static InteractAlertnessFormulaItem GiveTeammateResource => Instance[0];

		public static InteractAlertnessFormulaItem GiveTeammateItem => Instance[1];

		public static InteractAlertnessFormulaItem TalkByNormalInformationGood => Instance[2];

		public static InteractAlertnessFormulaItem TalkByNormalInformationNormal => Instance[3];

		public static InteractAlertnessFormulaItem SendGiftLove => Instance[4];

		public static InteractAlertnessFormulaItem SendGiftNormal => Instance[5];

		public static InteractAlertnessFormulaItem SendGiftHate => Instance[6];

		public static InteractAlertnessFormulaItem MakeLineAndBridge => Instance[7];

		public static InteractAlertnessFormulaItem ProfessionWineTasterSkill0 => Instance[8];

		public static InteractAlertnessFormulaItem ProfessionWineTasterSkill3 => Instance[9];

		public static InteractAlertnessFormulaItem ProfessionLiteratiSkill3 => Instance[10];

		public static InteractAlertnessFormulaItem ProfessionTaoistMonkSkill1 => Instance[11];

		public static InteractAlertnessFormulaItem ProfessionAristocratSkill0 => Instance[12];

		public static InteractAlertnessFormulaItem ProfessionAristocratSkill1 => Instance[13];

		public static InteractAlertnessFormulaItem ProfessionBeggarSkill3 => Instance[14];

		public static InteractAlertnessFormulaItem ProfessionCivilianSkill0 => Instance[15];

		public static InteractAlertnessFormulaItem ProfessionCivilianSkill1 => Instance[16];

		public static InteractAlertnessFormulaItem ProfessionDoctorSkill0 => Instance[17];

		public static InteractAlertnessFormulaItem ProfessionDoctorSkill1 => Instance[18];

		public static InteractAlertnessFormulaItem ProfessionDoctorSkill3 => Instance[19];

		public static InteractAlertnessFormulaItem ProfessionTeaTasterSkill0 => Instance[20];

		public static InteractAlertnessFormulaItem ProfessionTeaTasterSkill3 => Instance[21];

		public static InteractAlertnessFormulaItem ProfessionDukeSkill1Add => Instance[22];

		public static InteractAlertnessFormulaItem ProfessionMartialArtistSkill0 => Instance[23];

		public static InteractAlertnessFormulaItem TakeTeammateResource => Instance[24];

		public static InteractAlertnessFormulaItem TakeTeammateItem => Instance[25];

		public static InteractAlertnessFormulaItem StealLifeSkill => Instance[26];

		public static InteractAlertnessFormulaItem StealCombatSkill => Instance[27];

		public static InteractAlertnessFormulaItem ScamLifeSkill => Instance[28];

		public static InteractAlertnessFormulaItem ScamCombatSkill => Instance[29];

		public static InteractAlertnessFormulaItem ScamItem => Instance[30];

		public static InteractAlertnessFormulaItem ScamResource => Instance[31];

		public static InteractAlertnessFormulaItem ScamNormalInformation => Instance[32];

		public static InteractAlertnessFormulaItem ScamSecretInformation => Instance[33];

		public static InteractAlertnessFormulaItem StealItem => Instance[34];

		public static InteractAlertnessFormulaItem StealResource => Instance[35];

		public static InteractAlertnessFormulaItem RobItem => Instance[36];

		public static InteractAlertnessFormulaItem RobResource => Instance[37];

		public static InteractAlertnessFormulaItem Poison => Instance[38];

		public static InteractAlertnessFormulaItem Damage => Instance[39];

		public static InteractAlertnessFormulaItem Attack => Instance[40];

		public static InteractAlertnessFormulaItem AttackKidnappedCharacter => Instance[41];

		public static InteractAlertnessFormulaItem ProfessionCivilianSkill2 => Instance[42];

		public static InteractAlertnessFormulaItem ProfessionDukeSkill1Remove => Instance[43];

		public static InteractAlertnessFormulaItem JoinTaiwuVillage => Instance[44];
	}

	public static InteractAlertnessFormula Instance = new InteractAlertnessFormula();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "TemplateId" };

	internal override int ToInt(int value)
	{
		return value;
	}

	internal override int ToTemplateId(int value)
	{
		return value;
	}

	private void CreateItems0()
	{
		_dataArray.Add(new InteractAlertnessFormulaItem(0, EInteractAlertnessFormulaType.Formula1, new int[1] { 2 }, -1));
		_dataArray.Add(new InteractAlertnessFormulaItem(1, EInteractAlertnessFormulaType.Formula1, new int[1] { 10 }, -1));
		_dataArray.Add(new InteractAlertnessFormulaItem(2, EInteractAlertnessFormulaType.Formula2, new int[4] { 2000, 1, 150, 100 }, -1));
		_dataArray.Add(new InteractAlertnessFormulaItem(3, EInteractAlertnessFormulaType.Formula2, new int[4] { 2000, 1, 100, 100 }, -1));
		_dataArray.Add(new InteractAlertnessFormulaItem(4, EInteractAlertnessFormulaType.Formula3, new int[3] { 10, 120, 100 }, -1));
		_dataArray.Add(new InteractAlertnessFormulaItem(5, EInteractAlertnessFormulaType.Formula3, new int[3] { 10, 100, 100 }, -1));
		_dataArray.Add(new InteractAlertnessFormulaItem(6, EInteractAlertnessFormulaType.Formula3, new int[3] { 10, 80, 100 }, -1));
		_dataArray.Add(new InteractAlertnessFormulaItem(7, EInteractAlertnessFormulaType.Formula1, new int[1] { 2 }, -1));
		_dataArray.Add(new InteractAlertnessFormulaItem(8, EInteractAlertnessFormulaType.Formula0, new int[1] { 2000 }, -1));
		_dataArray.Add(new InteractAlertnessFormulaItem(9, EInteractAlertnessFormulaType.Formula1, new int[1] { 2 }, -1));
		_dataArray.Add(new InteractAlertnessFormulaItem(10, EInteractAlertnessFormulaType.Formula2, new int[4] { 2000, 1, 150, 100 }, -1));
		_dataArray.Add(new InteractAlertnessFormulaItem(11, EInteractAlertnessFormulaType.Formula0, new int[1] { 100000 }, -1));
		_dataArray.Add(new InteractAlertnessFormulaItem(12, EInteractAlertnessFormulaType.Formula1, new int[1] { 20 }, -1));
		_dataArray.Add(new InteractAlertnessFormulaItem(13, EInteractAlertnessFormulaType.Formula0, new int[1] { 50000 }, -1));
		_dataArray.Add(new InteractAlertnessFormulaItem(14, EInteractAlertnessFormulaType.Formula1, new int[1] { 10 }, -1));
		_dataArray.Add(new InteractAlertnessFormulaItem(15, EInteractAlertnessFormulaType.Formula3, new int[3] { 1, 20, 100 }, -1));
		_dataArray.Add(new InteractAlertnessFormulaItem(16, EInteractAlertnessFormulaType.Formula0, new int[1] { 50000 }, -1));
		_dataArray.Add(new InteractAlertnessFormulaItem(17, EInteractAlertnessFormulaType.Formula0, new int[1] { 10000 }, -1));
		_dataArray.Add(new InteractAlertnessFormulaItem(18, EInteractAlertnessFormulaType.Formula0, new int[1] { 10000 }, -1));
		_dataArray.Add(new InteractAlertnessFormulaItem(19, EInteractAlertnessFormulaType.Formula0, new int[1] { 200000 }, -1));
		_dataArray.Add(new InteractAlertnessFormulaItem(20, EInteractAlertnessFormulaType.Formula0, new int[1] { 2000 }, -1));
		_dataArray.Add(new InteractAlertnessFormulaItem(21, EInteractAlertnessFormulaType.Formula1, new int[1] { 1 }, -1));
		_dataArray.Add(new InteractAlertnessFormulaItem(22, EInteractAlertnessFormulaType.Formula0, new int[1] { 50000 }, -1));
		_dataArray.Add(new InteractAlertnessFormulaItem(23, EInteractAlertnessFormulaType.Formula3, new int[3] { 1, 20, 100 }, -1));
		_dataArray.Add(new InteractAlertnessFormulaItem(24, EInteractAlertnessFormulaType.Formula1, new int[1], -1));
		_dataArray.Add(new InteractAlertnessFormulaItem(25, EInteractAlertnessFormulaType.Formula1, new int[1], -1));
		_dataArray.Add(new InteractAlertnessFormulaItem(26, EInteractAlertnessFormulaType.Formula1, new int[1] { 10000 }, -1));
		_dataArray.Add(new InteractAlertnessFormulaItem(27, EInteractAlertnessFormulaType.Formula1, new int[1] { 10000 }, -1));
		_dataArray.Add(new InteractAlertnessFormulaItem(28, EInteractAlertnessFormulaType.Formula1, new int[1] { 10000 }, -1));
		_dataArray.Add(new InteractAlertnessFormulaItem(29, EInteractAlertnessFormulaType.Formula1, new int[1] { 10000 }, -1));
		_dataArray.Add(new InteractAlertnessFormulaItem(30, EInteractAlertnessFormulaType.Formula1, new int[1] { 15 }, -1));
		_dataArray.Add(new InteractAlertnessFormulaItem(31, EInteractAlertnessFormulaType.Formula1, new int[1] { 4 }, -1));
		_dataArray.Add(new InteractAlertnessFormulaItem(32, EInteractAlertnessFormulaType.Formula1, new int[1] { 5000 }, -1));
		_dataArray.Add(new InteractAlertnessFormulaItem(33, EInteractAlertnessFormulaType.Formula1, new int[1] { 5000 }, -1));
		_dataArray.Add(new InteractAlertnessFormulaItem(34, EInteractAlertnessFormulaType.Formula1, new int[1] { 15 }, -1));
		_dataArray.Add(new InteractAlertnessFormulaItem(35, EInteractAlertnessFormulaType.Formula1, new int[1] { 4 }, -1));
		_dataArray.Add(new InteractAlertnessFormulaItem(36, EInteractAlertnessFormulaType.Formula1, new int[1] { 15 }, -1));
		_dataArray.Add(new InteractAlertnessFormulaItem(37, EInteractAlertnessFormulaType.Formula1, new int[1] { 4 }, -1));
		_dataArray.Add(new InteractAlertnessFormulaItem(38, EInteractAlertnessFormulaType.Formula0, new int[1] { 150000 }, -1));
		_dataArray.Add(new InteractAlertnessFormulaItem(39, EInteractAlertnessFormulaType.Formula0, new int[1] { 150000 }, -1));
		_dataArray.Add(new InteractAlertnessFormulaItem(40, EInteractAlertnessFormulaType.Formula0, new int[1] { 400000 }, -1));
		_dataArray.Add(new InteractAlertnessFormulaItem(41, EInteractAlertnessFormulaType.Formula0, new int[1] { 200000 }, -1));
		_dataArray.Add(new InteractAlertnessFormulaItem(42, EInteractAlertnessFormulaType.Formula0, new int[1], -1));
		_dataArray.Add(new InteractAlertnessFormulaItem(43, EInteractAlertnessFormulaType.Formula0, new int[1] { 80000 }, -1));
		_dataArray.Add(new InteractAlertnessFormulaItem(44, EInteractAlertnessFormulaType.Formula2, new int[4] { 10000, 2, 100, 100 }, -1));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<InteractAlertnessFormulaItem>(45);
		CreateItems0();
	}
}
