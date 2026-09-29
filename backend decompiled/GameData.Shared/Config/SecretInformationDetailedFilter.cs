using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class SecretInformationDetailedFilter : ConfigData<SecretInformationDetailedFilterItem, short>
{
	public static class DefKey
	{
		public const short Murder = 0;

		public const short Jail = 1;

		public const short Retribution = 2;

		public const short Poison = 3;

		public const short Assassination = 4;

		public const short Jailbreak = 5;

		public const short GraveRobber = 6;

		public const short Steal = 7;

		public const short Scam = 8;

		public const short Robber = 9;

		public const short AttachPoison = 10;

		public const short BreakPrecept = 11;

		public const short Teach = 12;

		public const short StealLifeSkill = 13;

		public const short StealCombatSkill = 14;

		public const short ContestDetail = 15;

		public const short Sect = 16;

		public const short Die = 17;

		public const short Commemorate = 18;

		public const short Protect = 19;

		public const short Reunion = 20;

		public const short Gift = 21;

		public const short HelpDetail = 22;

		public const short RefuseDetail = 23;

		public const short Bury = 24;

		public const short Heal = 25;

		public const short Repair = 26;

		public const short Shave = 27;

		public const short Beg = 28;

		public const short SeverEnemy = 29;

		public const short Enemy = 30;

		public const short Friend = 31;

		public const short SeverFriend = 32;

		public const short BreakupDetail = 33;

		public const short SeverOathDetail = 34;

		public const short Adored = 35;

		public const short Wedding = 36;

		public const short Sworn = 37;

		public const short AdoptParent = 38;

		public const short AdoptChildren = 39;

		public const short Monk = 40;

		public const short Mentor = 41;

		public const short Dating = 42;

		public const short Rape = 43;

		public const short Tryst = 44;

		public const short Dystocia = 45;

		public const short Birth = 46;

		public const short Abandoned = 47;

		public const short Illegitimate = 48;

		public const short Release = 49;

		public const short Save = 50;

		public const short Escape = 51;

		public const short Inprison = 52;

		public const short OutPrison = 53;

		public const short Kidnap = 54;

		public const short Bless = 55;

		public const short disaster = 56;

		public const short Lost = 57;

		public const short Other = 58;
	}

	public static class DefValue
	{
		public static SecretInformationDetailedFilterItem Murder => Instance[(short)0];

		public static SecretInformationDetailedFilterItem Jail => Instance[(short)1];

		public static SecretInformationDetailedFilterItem Retribution => Instance[(short)2];

		public static SecretInformationDetailedFilterItem Poison => Instance[(short)3];

		public static SecretInformationDetailedFilterItem Assassination => Instance[(short)4];

		public static SecretInformationDetailedFilterItem Jailbreak => Instance[(short)5];

		public static SecretInformationDetailedFilterItem GraveRobber => Instance[(short)6];

		public static SecretInformationDetailedFilterItem Steal => Instance[(short)7];

		public static SecretInformationDetailedFilterItem Scam => Instance[(short)8];

		public static SecretInformationDetailedFilterItem Robber => Instance[(short)9];

		public static SecretInformationDetailedFilterItem AttachPoison => Instance[(short)10];

		public static SecretInformationDetailedFilterItem BreakPrecept => Instance[(short)11];

		public static SecretInformationDetailedFilterItem Teach => Instance[(short)12];

		public static SecretInformationDetailedFilterItem StealLifeSkill => Instance[(short)13];

		public static SecretInformationDetailedFilterItem StealCombatSkill => Instance[(short)14];

		public static SecretInformationDetailedFilterItem ContestDetail => Instance[(short)15];

		public static SecretInformationDetailedFilterItem Sect => Instance[(short)16];

		public static SecretInformationDetailedFilterItem Die => Instance[(short)17];

		public static SecretInformationDetailedFilterItem Commemorate => Instance[(short)18];

		public static SecretInformationDetailedFilterItem Protect => Instance[(short)19];

		public static SecretInformationDetailedFilterItem Reunion => Instance[(short)20];

		public static SecretInformationDetailedFilterItem Gift => Instance[(short)21];

		public static SecretInformationDetailedFilterItem HelpDetail => Instance[(short)22];

		public static SecretInformationDetailedFilterItem RefuseDetail => Instance[(short)23];

		public static SecretInformationDetailedFilterItem Bury => Instance[(short)24];

		public static SecretInformationDetailedFilterItem Heal => Instance[(short)25];

		public static SecretInformationDetailedFilterItem Repair => Instance[(short)26];

		public static SecretInformationDetailedFilterItem Shave => Instance[(short)27];

		public static SecretInformationDetailedFilterItem Beg => Instance[(short)28];

		public static SecretInformationDetailedFilterItem SeverEnemy => Instance[(short)29];

		public static SecretInformationDetailedFilterItem Enemy => Instance[(short)30];

		public static SecretInformationDetailedFilterItem Friend => Instance[(short)31];

		public static SecretInformationDetailedFilterItem SeverFriend => Instance[(short)32];

		public static SecretInformationDetailedFilterItem BreakupDetail => Instance[(short)33];

		public static SecretInformationDetailedFilterItem SeverOathDetail => Instance[(short)34];

		public static SecretInformationDetailedFilterItem Adored => Instance[(short)35];

		public static SecretInformationDetailedFilterItem Wedding => Instance[(short)36];

		public static SecretInformationDetailedFilterItem Sworn => Instance[(short)37];

		public static SecretInformationDetailedFilterItem AdoptParent => Instance[(short)38];

		public static SecretInformationDetailedFilterItem AdoptChildren => Instance[(short)39];

		public static SecretInformationDetailedFilterItem Monk => Instance[(short)40];

		public static SecretInformationDetailedFilterItem Mentor => Instance[(short)41];

		public static SecretInformationDetailedFilterItem Dating => Instance[(short)42];

		public static SecretInformationDetailedFilterItem Rape => Instance[(short)43];

		public static SecretInformationDetailedFilterItem Tryst => Instance[(short)44];

		public static SecretInformationDetailedFilterItem Dystocia => Instance[(short)45];

		public static SecretInformationDetailedFilterItem Birth => Instance[(short)46];

		public static SecretInformationDetailedFilterItem Abandoned => Instance[(short)47];

		public static SecretInformationDetailedFilterItem Illegitimate => Instance[(short)48];

		public static SecretInformationDetailedFilterItem Release => Instance[(short)49];

		public static SecretInformationDetailedFilterItem Save => Instance[(short)50];

		public static SecretInformationDetailedFilterItem Escape => Instance[(short)51];

		public static SecretInformationDetailedFilterItem Inprison => Instance[(short)52];

		public static SecretInformationDetailedFilterItem OutPrison => Instance[(short)53];

		public static SecretInformationDetailedFilterItem Kidnap => Instance[(short)54];

		public static SecretInformationDetailedFilterItem Bless => Instance[(short)55];

		public static SecretInformationDetailedFilterItem disaster => Instance[(short)56];

		public static SecretInformationDetailedFilterItem Lost => Instance[(short)57];

		public static SecretInformationDetailedFilterItem Other => Instance[(short)58];
	}

	public static SecretInformationDetailedFilter Instance = new SecretInformationDetailedFilter();

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
		_dataArray.Add(new SecretInformationDetailedFilterItem(0, LocalStringManager.GetConfig("SecretInformationDetailedFilter_language", "Name_0")));
		_dataArray.Add(new SecretInformationDetailedFilterItem(1, LocalStringManager.GetConfig("SecretInformationDetailedFilter_language", "Name_1")));
		_dataArray.Add(new SecretInformationDetailedFilterItem(2, LocalStringManager.GetConfig("SecretInformationDetailedFilter_language", "Name_2")));
		_dataArray.Add(new SecretInformationDetailedFilterItem(3, LocalStringManager.GetConfig("SecretInformationDetailedFilter_language", "Name_3")));
		_dataArray.Add(new SecretInformationDetailedFilterItem(4, LocalStringManager.GetConfig("SecretInformationDetailedFilter_language", "Name_4")));
		_dataArray.Add(new SecretInformationDetailedFilterItem(5, LocalStringManager.GetConfig("SecretInformationDetailedFilter_language", "Name_5")));
		_dataArray.Add(new SecretInformationDetailedFilterItem(6, LocalStringManager.GetConfig("SecretInformationDetailedFilter_language", "Name_6")));
		_dataArray.Add(new SecretInformationDetailedFilterItem(7, LocalStringManager.GetConfig("SecretInformationDetailedFilter_language", "Name_7")));
		_dataArray.Add(new SecretInformationDetailedFilterItem(8, LocalStringManager.GetConfig("SecretInformationDetailedFilter_language", "Name_8")));
		_dataArray.Add(new SecretInformationDetailedFilterItem(9, LocalStringManager.GetConfig("SecretInformationDetailedFilter_language", "Name_9")));
		_dataArray.Add(new SecretInformationDetailedFilterItem(10, LocalStringManager.GetConfig("SecretInformationDetailedFilter_language", "Name_10")));
		_dataArray.Add(new SecretInformationDetailedFilterItem(11, LocalStringManager.GetConfig("SecretInformationDetailedFilter_language", "Name_11")));
		_dataArray.Add(new SecretInformationDetailedFilterItem(12, LocalStringManager.GetConfig("SecretInformationDetailedFilter_language", "Name_12")));
		_dataArray.Add(new SecretInformationDetailedFilterItem(13, LocalStringManager.GetConfig("SecretInformationDetailedFilter_language", "Name_13")));
		_dataArray.Add(new SecretInformationDetailedFilterItem(14, LocalStringManager.GetConfig("SecretInformationDetailedFilter_language", "Name_14")));
		_dataArray.Add(new SecretInformationDetailedFilterItem(15, LocalStringManager.GetConfig("SecretInformationDetailedFilter_language", "Name_15")));
		_dataArray.Add(new SecretInformationDetailedFilterItem(16, LocalStringManager.GetConfig("SecretInformationDetailedFilter_language", "Name_16")));
		_dataArray.Add(new SecretInformationDetailedFilterItem(17, LocalStringManager.GetConfig("SecretInformationDetailedFilter_language", "Name_17")));
		_dataArray.Add(new SecretInformationDetailedFilterItem(18, LocalStringManager.GetConfig("SecretInformationDetailedFilter_language", "Name_18")));
		_dataArray.Add(new SecretInformationDetailedFilterItem(19, LocalStringManager.GetConfig("SecretInformationDetailedFilter_language", "Name_19")));
		_dataArray.Add(new SecretInformationDetailedFilterItem(20, LocalStringManager.GetConfig("SecretInformationDetailedFilter_language", "Name_20")));
		_dataArray.Add(new SecretInformationDetailedFilterItem(21, LocalStringManager.GetConfig("SecretInformationDetailedFilter_language", "Name_21")));
		_dataArray.Add(new SecretInformationDetailedFilterItem(22, LocalStringManager.GetConfig("SecretInformationDetailedFilter_language", "Name_22")));
		_dataArray.Add(new SecretInformationDetailedFilterItem(23, LocalStringManager.GetConfig("SecretInformationDetailedFilter_language", "Name_23")));
		_dataArray.Add(new SecretInformationDetailedFilterItem(24, LocalStringManager.GetConfig("SecretInformationDetailedFilter_language", "Name_24")));
		_dataArray.Add(new SecretInformationDetailedFilterItem(25, LocalStringManager.GetConfig("SecretInformationDetailedFilter_language", "Name_25")));
		_dataArray.Add(new SecretInformationDetailedFilterItem(26, LocalStringManager.GetConfig("SecretInformationDetailedFilter_language", "Name_26")));
		_dataArray.Add(new SecretInformationDetailedFilterItem(27, LocalStringManager.GetConfig("SecretInformationDetailedFilter_language", "Name_27")));
		_dataArray.Add(new SecretInformationDetailedFilterItem(28, LocalStringManager.GetConfig("SecretInformationDetailedFilter_language", "Name_28")));
		_dataArray.Add(new SecretInformationDetailedFilterItem(29, LocalStringManager.GetConfig("SecretInformationDetailedFilter_language", "Name_29")));
		_dataArray.Add(new SecretInformationDetailedFilterItem(30, LocalStringManager.GetConfig("SecretInformationDetailedFilter_language", "Name_30")));
		_dataArray.Add(new SecretInformationDetailedFilterItem(31, LocalStringManager.GetConfig("SecretInformationDetailedFilter_language", "Name_31")));
		_dataArray.Add(new SecretInformationDetailedFilterItem(32, LocalStringManager.GetConfig("SecretInformationDetailedFilter_language", "Name_32")));
		_dataArray.Add(new SecretInformationDetailedFilterItem(33, LocalStringManager.GetConfig("SecretInformationDetailedFilter_language", "Name_33")));
		_dataArray.Add(new SecretInformationDetailedFilterItem(34, LocalStringManager.GetConfig("SecretInformationDetailedFilter_language", "Name_34")));
		_dataArray.Add(new SecretInformationDetailedFilterItem(35, LocalStringManager.GetConfig("SecretInformationDetailedFilter_language", "Name_35")));
		_dataArray.Add(new SecretInformationDetailedFilterItem(36, LocalStringManager.GetConfig("SecretInformationDetailedFilter_language", "Name_36")));
		_dataArray.Add(new SecretInformationDetailedFilterItem(37, LocalStringManager.GetConfig("SecretInformationDetailedFilter_language", "Name_37")));
		_dataArray.Add(new SecretInformationDetailedFilterItem(38, LocalStringManager.GetConfig("SecretInformationDetailedFilter_language", "Name_38")));
		_dataArray.Add(new SecretInformationDetailedFilterItem(39, LocalStringManager.GetConfig("SecretInformationDetailedFilter_language", "Name_39")));
		_dataArray.Add(new SecretInformationDetailedFilterItem(40, LocalStringManager.GetConfig("SecretInformationDetailedFilter_language", "Name_40")));
		_dataArray.Add(new SecretInformationDetailedFilterItem(41, LocalStringManager.GetConfig("SecretInformationDetailedFilter_language", "Name_41")));
		_dataArray.Add(new SecretInformationDetailedFilterItem(42, LocalStringManager.GetConfig("SecretInformationDetailedFilter_language", "Name_42")));
		_dataArray.Add(new SecretInformationDetailedFilterItem(43, LocalStringManager.GetConfig("SecretInformationDetailedFilter_language", "Name_43")));
		_dataArray.Add(new SecretInformationDetailedFilterItem(44, LocalStringManager.GetConfig("SecretInformationDetailedFilter_language", "Name_44")));
		_dataArray.Add(new SecretInformationDetailedFilterItem(45, LocalStringManager.GetConfig("SecretInformationDetailedFilter_language", "Name_45")));
		_dataArray.Add(new SecretInformationDetailedFilterItem(46, LocalStringManager.GetConfig("SecretInformationDetailedFilter_language", "Name_46")));
		_dataArray.Add(new SecretInformationDetailedFilterItem(47, LocalStringManager.GetConfig("SecretInformationDetailedFilter_language", "Name_47")));
		_dataArray.Add(new SecretInformationDetailedFilterItem(48, LocalStringManager.GetConfig("SecretInformationDetailedFilter_language", "Name_48")));
		_dataArray.Add(new SecretInformationDetailedFilterItem(49, LocalStringManager.GetConfig("SecretInformationDetailedFilter_language", "Name_49")));
		_dataArray.Add(new SecretInformationDetailedFilterItem(50, LocalStringManager.GetConfig("SecretInformationDetailedFilter_language", "Name_50")));
		_dataArray.Add(new SecretInformationDetailedFilterItem(51, LocalStringManager.GetConfig("SecretInformationDetailedFilter_language", "Name_51")));
		_dataArray.Add(new SecretInformationDetailedFilterItem(52, LocalStringManager.GetConfig("SecretInformationDetailedFilter_language", "Name_52")));
		_dataArray.Add(new SecretInformationDetailedFilterItem(53, LocalStringManager.GetConfig("SecretInformationDetailedFilter_language", "Name_53")));
		_dataArray.Add(new SecretInformationDetailedFilterItem(54, LocalStringManager.GetConfig("SecretInformationDetailedFilter_language", "Name_54")));
		_dataArray.Add(new SecretInformationDetailedFilterItem(55, LocalStringManager.GetConfig("SecretInformationDetailedFilter_language", "Name_55")));
		_dataArray.Add(new SecretInformationDetailedFilterItem(56, LocalStringManager.GetConfig("SecretInformationDetailedFilter_language", "Name_56")));
		_dataArray.Add(new SecretInformationDetailedFilterItem(57, LocalStringManager.GetConfig("SecretInformationDetailedFilter_language", "Name_57")));
		_dataArray.Add(new SecretInformationDetailedFilterItem(58, LocalStringManager.GetConfig("SecretInformationDetailedFilter_language", "Name_58")));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<SecretInformationDetailedFilterItem>(59);
		CreateItems0();
	}
}
