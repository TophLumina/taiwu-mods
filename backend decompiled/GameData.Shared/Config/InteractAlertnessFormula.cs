using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class InteractAlertnessFormula : ConfigData<InteractAlertnessFormulaItem, int>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 转赠同道资源
		/// </summary>
		public const int GiveTeammateResource = 0;

		/// <summary>
		/// 转赠同道道具
		/// </summary>
		public const int GiveTeammateItem = 1;

		/// <summary>
		/// 见闻闲谈-有效
		/// </summary>
		public const int TalkByNormalInformationGood = 2;

		/// <summary>
		/// 见闻闲谈-一般
		/// </summary>
		public const int TalkByNormalInformationNormal = 3;

		/// <summary>
		/// 赠送礼物-对方喜欢
		/// </summary>
		public const int SendGiftLove = 4;

		/// <summary>
		/// 赠送礼物-对方一般
		/// </summary>
		public const int SendGiftNormal = 5;

		/// <summary>
		/// 赠送礼物-对方讨厌
		/// </summary>
		public const int SendGiftHate = 6;

		/// <summary>
		/// 牵线搭桥
		/// </summary>
		public const int MakeLineAndBridge = 7;

		/// <summary>
		/// 豪客-拼豪斗酒
		/// </summary>
		public const int ProfessionWineTasterSkill0 = 8;

		/// <summary>
		/// 豪客-豪侠研武
		/// </summary>
		public const int ProfessionWineTasterSkill3 = 9;

		/// <summary>
		/// 才俊-谈天说地
		/// </summary>
		public const int ProfessionLiteratiSkill3 = 10;

		/// <summary>
		/// 道长-驱邪法事
		/// </summary>
		public const int ProfessionTaoistMonkSkill1 = 11;

		/// <summary>
		/// 名门-扶助保荐
		/// </summary>
		public const int ProfessionAristocratSkill0 = 12;

		/// <summary>
		/// 名门-采擢荐进
		/// </summary>
		public const int ProfessionAristocratSkill1 = 13;

		/// <summary>
		/// 乞丐-天地为食
		/// </summary>
		public const int ProfessionBeggarSkill3 = 14;

		/// <summary>
		/// 平民-乡亲父老
		/// </summary>
		public const int ProfessionCivilianSkill0 = 15;

		/// <summary>
		/// 平民-安居乐业
		/// </summary>
		public const int ProfessionCivilianSkill1 = 16;

		/// <summary>
		/// 大夫-看诊施药
		/// </summary>
		public const int ProfessionDoctorSkill0 = 17;

		/// <summary>
		/// 大夫-游医义诊
		/// </summary>
		public const int ProfessionDoctorSkill1 = 18;

		/// <summary>
		/// 大夫-金针渡命
		/// </summary>
		public const int ProfessionDoctorSkill3 = 19;

		/// <summary>
		/// 贵客-评水品茗
		/// </summary>
		public const int ProfessionTeaTasterSkill0 = 20;

		/// <summary>
		/// 贵客-仙人泼墨
		/// </summary>
		public const int ProfessionTeaTasterSkill3 = 21;

		/// <summary>
		/// 王公-封侯拜相添加
		/// </summary>
		public const int ProfessionDukeSkill1Add = 22;

		/// <summary>
		/// 武师-江湖中人
		/// </summary>
		public const int ProfessionMartialArtistSkill0 = 23;

		/// <summary>
		/// 拿取同道资源
		/// </summary>
		public const int TakeTeammateResource = 24;

		/// <summary>
		/// 拿取同道道具
		/// </summary>
		public const int TakeTeammateItem = 25;

		/// <summary>
		/// 偷师技艺
		/// </summary>
		public const int StealLifeSkill = 26;

		/// <summary>
		/// 偷师功法
		/// </summary>
		public const int StealCombatSkill = 27;

		/// <summary>
		/// 唬骗技艺
		/// </summary>
		public const int ScamLifeSkill = 28;

		/// <summary>
		/// 唬骗功法
		/// </summary>
		public const int ScamCombatSkill = 29;

		/// <summary>
		/// 唬骗物品
		/// </summary>
		public const int ScamItem = 30;

		/// <summary>
		/// 唬骗资源
		/// </summary>
		public const int ScamResource = 31;

		/// <summary>
		/// 唬骗见闻
		/// </summary>
		public const int ScamNormalInformation = 32;

		/// <summary>
		/// 唬骗秘闻
		/// </summary>
		public const int ScamSecretInformation = 33;

		/// <summary>
		/// 窃取物品
		/// </summary>
		public const int StealItem = 34;

		/// <summary>
		/// 窃取资源
		/// </summary>
		public const int StealResource = 35;

		/// <summary>
		/// 夺取物品
		/// </summary>
		public const int RobItem = 36;

		/// <summary>
		/// 夺取资源
		/// </summary>
		public const int RobResource = 37;

		/// <summary>
		/// 施以毒害
		/// </summary>
		public const int Poison = 38;

		/// <summary>
		/// 暗中损伤
		/// </summary>
		public const int Damage = 39;

		/// <summary>
		/// 出手袭击
		/// </summary>
		public const int Attack = 40;

		/// <summary>
		/// 处罚俘虏
		/// </summary>
		public const int AttackKidnappedCharacter = 41;

		/// <summary>
		/// 平民-退隐江湖
		/// </summary>
		public const int ProfessionCivilianSkill2 = 42;

		/// <summary>
		/// 王公-封侯拜相移除
		/// </summary>
		public const int ProfessionDukeSkill1Remove = 43;

		/// <summary>
		/// 加入太吾村
		/// </summary>
		public const int JoinTaiwuVillage = 44;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 转赠同道资源
		/// </summary>
		public static InteractAlertnessFormulaItem GiveTeammateResource => Instance[0];

		/// <summary>
		/// 转赠同道道具
		/// </summary>
		public static InteractAlertnessFormulaItem GiveTeammateItem => Instance[1];

		/// <summary>
		/// 见闻闲谈-有效
		/// </summary>
		public static InteractAlertnessFormulaItem TalkByNormalInformationGood => Instance[2];

		/// <summary>
		/// 见闻闲谈-一般
		/// </summary>
		public static InteractAlertnessFormulaItem TalkByNormalInformationNormal => Instance[3];

		/// <summary>
		/// 赠送礼物-对方喜欢
		/// </summary>
		public static InteractAlertnessFormulaItem SendGiftLove => Instance[4];

		/// <summary>
		/// 赠送礼物-对方一般
		/// </summary>
		public static InteractAlertnessFormulaItem SendGiftNormal => Instance[5];

		/// <summary>
		/// 赠送礼物-对方讨厌
		/// </summary>
		public static InteractAlertnessFormulaItem SendGiftHate => Instance[6];

		/// <summary>
		/// 牵线搭桥
		/// </summary>
		public static InteractAlertnessFormulaItem MakeLineAndBridge => Instance[7];

		/// <summary>
		/// 豪客-拼豪斗酒
		/// </summary>
		public static InteractAlertnessFormulaItem ProfessionWineTasterSkill0 => Instance[8];

		/// <summary>
		/// 豪客-豪侠研武
		/// </summary>
		public static InteractAlertnessFormulaItem ProfessionWineTasterSkill3 => Instance[9];

		/// <summary>
		/// 才俊-谈天说地
		/// </summary>
		public static InteractAlertnessFormulaItem ProfessionLiteratiSkill3 => Instance[10];

		/// <summary>
		/// 道长-驱邪法事
		/// </summary>
		public static InteractAlertnessFormulaItem ProfessionTaoistMonkSkill1 => Instance[11];

		/// <summary>
		/// 名门-扶助保荐
		/// </summary>
		public static InteractAlertnessFormulaItem ProfessionAristocratSkill0 => Instance[12];

		/// <summary>
		/// 名门-采擢荐进
		/// </summary>
		public static InteractAlertnessFormulaItem ProfessionAristocratSkill1 => Instance[13];

		/// <summary>
		/// 乞丐-天地为食
		/// </summary>
		public static InteractAlertnessFormulaItem ProfessionBeggarSkill3 => Instance[14];

		/// <summary>
		/// 平民-乡亲父老
		/// </summary>
		public static InteractAlertnessFormulaItem ProfessionCivilianSkill0 => Instance[15];

		/// <summary>
		/// 平民-安居乐业
		/// </summary>
		public static InteractAlertnessFormulaItem ProfessionCivilianSkill1 => Instance[16];

		/// <summary>
		/// 大夫-看诊施药
		/// </summary>
		public static InteractAlertnessFormulaItem ProfessionDoctorSkill0 => Instance[17];

		/// <summary>
		/// 大夫-游医义诊
		/// </summary>
		public static InteractAlertnessFormulaItem ProfessionDoctorSkill1 => Instance[18];

		/// <summary>
		/// 大夫-金针渡命
		/// </summary>
		public static InteractAlertnessFormulaItem ProfessionDoctorSkill3 => Instance[19];

		/// <summary>
		/// 贵客-评水品茗
		/// </summary>
		public static InteractAlertnessFormulaItem ProfessionTeaTasterSkill0 => Instance[20];

		/// <summary>
		/// 贵客-仙人泼墨
		/// </summary>
		public static InteractAlertnessFormulaItem ProfessionTeaTasterSkill3 => Instance[21];

		/// <summary>
		/// 王公-封侯拜相添加
		/// </summary>
		public static InteractAlertnessFormulaItem ProfessionDukeSkill1Add => Instance[22];

		/// <summary>
		/// 武师-江湖中人
		/// </summary>
		public static InteractAlertnessFormulaItem ProfessionMartialArtistSkill0 => Instance[23];

		/// <summary>
		/// 拿取同道资源
		/// </summary>
		public static InteractAlertnessFormulaItem TakeTeammateResource => Instance[24];

		/// <summary>
		/// 拿取同道道具
		/// </summary>
		public static InteractAlertnessFormulaItem TakeTeammateItem => Instance[25];

		/// <summary>
		/// 偷师技艺
		/// </summary>
		public static InteractAlertnessFormulaItem StealLifeSkill => Instance[26];

		/// <summary>
		/// 偷师功法
		/// </summary>
		public static InteractAlertnessFormulaItem StealCombatSkill => Instance[27];

		/// <summary>
		/// 唬骗技艺
		/// </summary>
		public static InteractAlertnessFormulaItem ScamLifeSkill => Instance[28];

		/// <summary>
		/// 唬骗功法
		/// </summary>
		public static InteractAlertnessFormulaItem ScamCombatSkill => Instance[29];

		/// <summary>
		/// 唬骗物品
		/// </summary>
		public static InteractAlertnessFormulaItem ScamItem => Instance[30];

		/// <summary>
		/// 唬骗资源
		/// </summary>
		public static InteractAlertnessFormulaItem ScamResource => Instance[31];

		/// <summary>
		/// 唬骗见闻
		/// </summary>
		public static InteractAlertnessFormulaItem ScamNormalInformation => Instance[32];

		/// <summary>
		/// 唬骗秘闻
		/// </summary>
		public static InteractAlertnessFormulaItem ScamSecretInformation => Instance[33];

		/// <summary>
		/// 窃取物品
		/// </summary>
		public static InteractAlertnessFormulaItem StealItem => Instance[34];

		/// <summary>
		/// 窃取资源
		/// </summary>
		public static InteractAlertnessFormulaItem StealResource => Instance[35];

		/// <summary>
		/// 夺取物品
		/// </summary>
		public static InteractAlertnessFormulaItem RobItem => Instance[36];

		/// <summary>
		/// 夺取资源
		/// </summary>
		public static InteractAlertnessFormulaItem RobResource => Instance[37];

		/// <summary>
		/// 施以毒害
		/// </summary>
		public static InteractAlertnessFormulaItem Poison => Instance[38];

		/// <summary>
		/// 暗中损伤
		/// </summary>
		public static InteractAlertnessFormulaItem Damage => Instance[39];

		/// <summary>
		/// 出手袭击
		/// </summary>
		public static InteractAlertnessFormulaItem Attack => Instance[40];

		/// <summary>
		/// 处罚俘虏
		/// </summary>
		public static InteractAlertnessFormulaItem AttackKidnappedCharacter => Instance[41];

		/// <summary>
		/// 平民-退隐江湖
		/// </summary>
		public static InteractAlertnessFormulaItem ProfessionCivilianSkill2 => Instance[42];

		/// <summary>
		/// 王公-封侯拜相移除
		/// </summary>
		public static InteractAlertnessFormulaItem ProfessionDukeSkill1Remove => Instance[43];

		/// <summary>
		/// 加入太吾村
		/// </summary>
		public static InteractAlertnessFormulaItem JoinTaiwuVillage => Instance[44];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
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
