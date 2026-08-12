using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class SecretInformationDetailedFilter : ConfigData<SecretInformationDetailedFilterItem, short>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 血案
		/// </summary>
		public const short Murder = 0;

		/// <summary>
		/// 关押
		/// </summary>
		public const short Jail = 1;

		/// <summary>
		/// 惩戒
		/// </summary>
		public const short Retribution = 2;

		/// <summary>
		/// 毒害
		/// </summary>
		public const short Poison = 3;

		/// <summary>
		/// 暗害
		/// </summary>
		public const short Assassination = 4;

		/// <summary>
		/// 越狱
		/// </summary>
		public const short Jailbreak = 5;

		/// <summary>
		/// 盗掘
		/// </summary>
		public const short GraveRobber = 6;

		/// <summary>
		/// 窃取
		/// </summary>
		public const short Steal = 7;

		/// <summary>
		/// 唬骗
		/// </summary>
		public const short Scam = 8;

		/// <summary>
		/// 抢夺
		/// </summary>
		public const short Robber = 9;

		/// <summary>
		/// 淬毒
		/// </summary>
		public const short AttachPoison = 10;

		/// <summary>
		/// 破戒
		/// </summary>
		public const short BreakPrecept = 11;

		/// <summary>
		/// 指点
		/// </summary>
		public const short Teach = 12;

		/// <summary>
		/// 窃艺
		/// </summary>
		public const short StealLifeSkill = 13;

		/// <summary>
		/// 偷师
		/// </summary>
		public const short StealCombatSkill = 14;

		/// <summary>
		/// 比试
		/// </summary>
		public const short ContestDetail = 15;

		/// <summary>
		/// 门派
		/// </summary>
		public const short Sect = 16;

		/// <summary>
		/// 辞世
		/// </summary>
		public const short Die = 17;

		/// <summary>
		/// 祭奠
		/// </summary>
		public const short Commemorate = 18;

		/// <summary>
		/// 守护
		/// </summary>
		public const short Protect = 19;

		/// <summary>
		/// 团聚
		/// </summary>
		public const short Reunion = 20;

		/// <summary>
		/// 赠礼
		/// </summary>
		public const short Gift = 21;

		/// <summary>
		/// 襄助
		/// </summary>
		public const short HelpDetail = 22;

		/// <summary>
		/// 回绝
		/// </summary>
		public const short RefuseDetail = 23;

		/// <summary>
		/// 安葬
		/// </summary>
		public const short Bury = 24;

		/// <summary>
		/// 医治
		/// </summary>
		public const short Heal = 25;

		/// <summary>
		/// 修补
		/// </summary>
		public const short Repair = 26;

		/// <summary>
		/// 梳头
		/// </summary>
		public const short Shave = 27;

		/// <summary>
		/// 乞讨
		/// </summary>
		public const short Beg = 28;

		/// <summary>
		/// 化解
		/// </summary>
		public const short SeverEnemy = 29;

		/// <summary>
		/// 结仇
		/// </summary>
		public const short Enemy = 30;

		/// <summary>
		/// 结交
		/// </summary>
		public const short Friend = 31;

		/// <summary>
		/// 绝交
		/// </summary>
		public const short SeverFriend = 32;

		/// <summary>
		/// 分手
		/// </summary>
		public const short BreakupDetail = 33;

		/// <summary>
		/// 绝义
		/// </summary>
		public const short SeverOathDetail = 34;

		/// <summary>
		/// 恋情
		/// </summary>
		public const short Adored = 35;

		/// <summary>
		/// 成婚
		/// </summary>
		public const short Wedding = 36;

		/// <summary>
		/// 结义
		/// </summary>
		public const short Sworn = 37;

		/// <summary>
		/// 拜认
		/// </summary>
		public const short AdoptParent = 38;

		/// <summary>
		/// 收养
		/// </summary>
		public const short AdoptChildren = 39;

		/// <summary>
		/// 出家
		/// </summary>
		public const short Monk = 40;

		/// <summary>
		/// 师徒
		/// </summary>
		public const short Mentor = 41;

		/// <summary>
		/// 约会
		/// </summary>
		public const short Dating = 42;

		/// <summary>
		/// 欺辱
		/// </summary>
		public const short Rape = 43;

		/// <summary>
		/// 私会
		/// </summary>
		public const short Tryst = 44;

		/// <summary>
		/// 难产
		/// </summary>
		public const short Dystocia = 45;

		/// <summary>
		/// 生育
		/// </summary>
		public const short Birth = 46;

		/// <summary>
		/// 遗弃
		/// </summary>
		public const short Abandoned = 47;

		/// <summary>
		/// 私生
		/// </summary>
		public const short Illegitimate = 48;

		/// <summary>
		/// 释放
		/// </summary>
		public const short Release = 49;

		/// <summary>
		/// 解救
		/// </summary>
		public const short Save = 50;

		/// <summary>
		/// 逃脱
		/// </summary>
		public const short Escape = 51;

		/// <summary>
		/// 入狱
		/// </summary>
		public const short Inprison = 52;

		/// <summary>
		/// 出狱
		/// </summary>
		public const short OutPrison = 53;

		/// <summary>
		/// 俘虏
		/// </summary>
		public const short Kidnap = 54;

		/// <summary>
		/// 横福
		/// </summary>
		public const short Bless = 55;

		/// <summary>
		/// 横祸
		/// </summary>
		public const short disaster = 56;

		/// <summary>
		/// 遗失
		/// </summary>
		public const short Lost = 57;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 血案
		/// </summary>
		public static SecretInformationDetailedFilterItem Murder => Instance[(short)0];

		/// <summary>
		/// 关押
		/// </summary>
		public static SecretInformationDetailedFilterItem Jail => Instance[(short)1];

		/// <summary>
		/// 惩戒
		/// </summary>
		public static SecretInformationDetailedFilterItem Retribution => Instance[(short)2];

		/// <summary>
		/// 毒害
		/// </summary>
		public static SecretInformationDetailedFilterItem Poison => Instance[(short)3];

		/// <summary>
		/// 暗害
		/// </summary>
		public static SecretInformationDetailedFilterItem Assassination => Instance[(short)4];

		/// <summary>
		/// 越狱
		/// </summary>
		public static SecretInformationDetailedFilterItem Jailbreak => Instance[(short)5];

		/// <summary>
		/// 盗掘
		/// </summary>
		public static SecretInformationDetailedFilterItem GraveRobber => Instance[(short)6];

		/// <summary>
		/// 窃取
		/// </summary>
		public static SecretInformationDetailedFilterItem Steal => Instance[(short)7];

		/// <summary>
		/// 唬骗
		/// </summary>
		public static SecretInformationDetailedFilterItem Scam => Instance[(short)8];

		/// <summary>
		/// 抢夺
		/// </summary>
		public static SecretInformationDetailedFilterItem Robber => Instance[(short)9];

		/// <summary>
		/// 淬毒
		/// </summary>
		public static SecretInformationDetailedFilterItem AttachPoison => Instance[(short)10];

		/// <summary>
		/// 破戒
		/// </summary>
		public static SecretInformationDetailedFilterItem BreakPrecept => Instance[(short)11];

		/// <summary>
		/// 指点
		/// </summary>
		public static SecretInformationDetailedFilterItem Teach => Instance[(short)12];

		/// <summary>
		/// 窃艺
		/// </summary>
		public static SecretInformationDetailedFilterItem StealLifeSkill => Instance[(short)13];

		/// <summary>
		/// 偷师
		/// </summary>
		public static SecretInformationDetailedFilterItem StealCombatSkill => Instance[(short)14];

		/// <summary>
		/// 比试
		/// </summary>
		public static SecretInformationDetailedFilterItem ContestDetail => Instance[(short)15];

		/// <summary>
		/// 门派
		/// </summary>
		public static SecretInformationDetailedFilterItem Sect => Instance[(short)16];

		/// <summary>
		/// 辞世
		/// </summary>
		public static SecretInformationDetailedFilterItem Die => Instance[(short)17];

		/// <summary>
		/// 祭奠
		/// </summary>
		public static SecretInformationDetailedFilterItem Commemorate => Instance[(short)18];

		/// <summary>
		/// 守护
		/// </summary>
		public static SecretInformationDetailedFilterItem Protect => Instance[(short)19];

		/// <summary>
		/// 团聚
		/// </summary>
		public static SecretInformationDetailedFilterItem Reunion => Instance[(short)20];

		/// <summary>
		/// 赠礼
		/// </summary>
		public static SecretInformationDetailedFilterItem Gift => Instance[(short)21];

		/// <summary>
		/// 襄助
		/// </summary>
		public static SecretInformationDetailedFilterItem HelpDetail => Instance[(short)22];

		/// <summary>
		/// 回绝
		/// </summary>
		public static SecretInformationDetailedFilterItem RefuseDetail => Instance[(short)23];

		/// <summary>
		/// 安葬
		/// </summary>
		public static SecretInformationDetailedFilterItem Bury => Instance[(short)24];

		/// <summary>
		/// 医治
		/// </summary>
		public static SecretInformationDetailedFilterItem Heal => Instance[(short)25];

		/// <summary>
		/// 修补
		/// </summary>
		public static SecretInformationDetailedFilterItem Repair => Instance[(short)26];

		/// <summary>
		/// 梳头
		/// </summary>
		public static SecretInformationDetailedFilterItem Shave => Instance[(short)27];

		/// <summary>
		/// 乞讨
		/// </summary>
		public static SecretInformationDetailedFilterItem Beg => Instance[(short)28];

		/// <summary>
		/// 化解
		/// </summary>
		public static SecretInformationDetailedFilterItem SeverEnemy => Instance[(short)29];

		/// <summary>
		/// 结仇
		/// </summary>
		public static SecretInformationDetailedFilterItem Enemy => Instance[(short)30];

		/// <summary>
		/// 结交
		/// </summary>
		public static SecretInformationDetailedFilterItem Friend => Instance[(short)31];

		/// <summary>
		/// 绝交
		/// </summary>
		public static SecretInformationDetailedFilterItem SeverFriend => Instance[(short)32];

		/// <summary>
		/// 分手
		/// </summary>
		public static SecretInformationDetailedFilterItem BreakupDetail => Instance[(short)33];

		/// <summary>
		/// 绝义
		/// </summary>
		public static SecretInformationDetailedFilterItem SeverOathDetail => Instance[(short)34];

		/// <summary>
		/// 恋情
		/// </summary>
		public static SecretInformationDetailedFilterItem Adored => Instance[(short)35];

		/// <summary>
		/// 成婚
		/// </summary>
		public static SecretInformationDetailedFilterItem Wedding => Instance[(short)36];

		/// <summary>
		/// 结义
		/// </summary>
		public static SecretInformationDetailedFilterItem Sworn => Instance[(short)37];

		/// <summary>
		/// 拜认
		/// </summary>
		public static SecretInformationDetailedFilterItem AdoptParent => Instance[(short)38];

		/// <summary>
		/// 收养
		/// </summary>
		public static SecretInformationDetailedFilterItem AdoptChildren => Instance[(short)39];

		/// <summary>
		/// 出家
		/// </summary>
		public static SecretInformationDetailedFilterItem Monk => Instance[(short)40];

		/// <summary>
		/// 师徒
		/// </summary>
		public static SecretInformationDetailedFilterItem Mentor => Instance[(short)41];

		/// <summary>
		/// 约会
		/// </summary>
		public static SecretInformationDetailedFilterItem Dating => Instance[(short)42];

		/// <summary>
		/// 欺辱
		/// </summary>
		public static SecretInformationDetailedFilterItem Rape => Instance[(short)43];

		/// <summary>
		/// 私会
		/// </summary>
		public static SecretInformationDetailedFilterItem Tryst => Instance[(short)44];

		/// <summary>
		/// 难产
		/// </summary>
		public static SecretInformationDetailedFilterItem Dystocia => Instance[(short)45];

		/// <summary>
		/// 生育
		/// </summary>
		public static SecretInformationDetailedFilterItem Birth => Instance[(short)46];

		/// <summary>
		/// 遗弃
		/// </summary>
		public static SecretInformationDetailedFilterItem Abandoned => Instance[(short)47];

		/// <summary>
		/// 私生
		/// </summary>
		public static SecretInformationDetailedFilterItem Illegitimate => Instance[(short)48];

		/// <summary>
		/// 释放
		/// </summary>
		public static SecretInformationDetailedFilterItem Release => Instance[(short)49];

		/// <summary>
		/// 解救
		/// </summary>
		public static SecretInformationDetailedFilterItem Save => Instance[(short)50];

		/// <summary>
		/// 逃脱
		/// </summary>
		public static SecretInformationDetailedFilterItem Escape => Instance[(short)51];

		/// <summary>
		/// 入狱
		/// </summary>
		public static SecretInformationDetailedFilterItem Inprison => Instance[(short)52];

		/// <summary>
		/// 出狱
		/// </summary>
		public static SecretInformationDetailedFilterItem OutPrison => Instance[(short)53];

		/// <summary>
		/// 俘虏
		/// </summary>
		public static SecretInformationDetailedFilterItem Kidnap => Instance[(short)54];

		/// <summary>
		/// 横福
		/// </summary>
		public static SecretInformationDetailedFilterItem Bless => Instance[(short)55];

		/// <summary>
		/// 横祸
		/// </summary>
		public static SecretInformationDetailedFilterItem disaster => Instance[(short)56];

		/// <summary>
		/// 遗失
		/// </summary>
		public static SecretInformationDetailedFilterItem Lost => Instance[(short)57];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
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
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<SecretInformationDetailedFilterItem>(58);
		CreateItems0();
	}
}
