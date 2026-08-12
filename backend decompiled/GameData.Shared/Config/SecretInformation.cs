using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class SecretInformation : ConfigData<SecretInformationItem, short>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 人物死亡
		/// </summary>
		public const short Die = 0;

		/// <summary>
		/// 公开杀害
		/// </summary>
		public const short KillInPublic = 1;

		/// <summary>
		/// 公开关押
		/// </summary>
		public const short KidnapInPublic = 2;

		/// <summary>
		/// 惩戒杀害
		/// </summary>
		public const short KillForPunishment = 3;

		/// <summary>
		/// 惩戒关押
		/// </summary>
		public const short KidnapForPunishment = 4;

		/// <summary>
		/// 天降资源
		/// </summary>
		public const short UnexpectedResourceGain = 5;

		/// <summary>
		/// 天降财宝
		/// </summary>
		public const short UnexpectedItemGain = 6;

		/// <summary>
		/// 天赐秘籍
		/// </summary>
		public const short UnexpectedSkillBookGain = 7;

		/// <summary>
		/// 天助疗愈
		/// </summary>
		public const short UnexpectedCure = 8;

		/// <summary>
		/// 天损资源
		/// </summary>
		public const short UnexpectedResourceLose = 9;

		/// <summary>
		/// 天损财宝
		/// </summary>
		public const short UnexpectedItemLose = 10;

		/// <summary>
		/// 天损秘籍
		/// </summary>
		public const short UnexpectedSkillBookLose = 11;

		/// <summary>
		/// 天降灾刑
		/// </summary>
		public const short UnexpectedHarm = 12;

		/// <summary>
		/// 较艺胜利
		/// </summary>
		public const short LifeSkillBattleWin = 13;

		/// <summary>
		/// 促织战胜
		/// </summary>
		public const short CricketBattleWin = 14;

		/// <summary>
		/// 战斗大胜
		/// </summary>
		public const short MajorVictoryInCombat = 15;

		/// <summary>
		/// 战斗胜利
		/// </summary>
		public const short MinorVictoryInCombat = 16;

		/// <summary>
		/// 祭拜故人
		/// </summary>
		public const short Mourn = 17;

		/// <summary>
		/// 保护亲友
		/// </summary>
		public const short OfferProtection = 18;

		/// <summary>
		/// 痛失骨肉
		/// </summary>
		public const short LoseFetus = 19;

		/// <summary>
		/// 痛失骨肉2
		/// </summary>
		public const short LoseFetus2 = 20;

		/// <summary>
		/// 生下孩子
		/// </summary>
		public const short GiveBirthToChild = 21;

		/// <summary>
		/// 生下孩子2
		/// </summary>
		public const short GiveBirthToChild2 = 22;

		/// <summary>
		/// 遗弃孩子
		/// </summary>
		public const short AbandonChild = 23;

		/// <summary>
		/// 释放俘虏
		/// </summary>
		public const short ReleaseKidnappedCharacter = 24;

		/// <summary>
		/// 解救俘虏
		/// </summary>
		public const short RescueKidnappedCharacter = 25;

		/// <summary>
		/// 逃脱关押
		/// </summary>
		public const short KidnappedCharacterEscaped = 26;

		/// <summary>
		/// 研读失败
		/// </summary>
		public const short ReadBookFail = 27;

		/// <summary>
		/// 突破失败
		/// </summary>
		public const short BreakoutFail = 28;

		/// <summary>
		/// 遗失宝物
		/// </summary>
		public const short LoseOverloadingItem = 29;

		/// <summary>
		/// 化解仇怨
		/// </summary>
		public const short SeverEnemy = 30;

		/// <summary>
		/// 结下仇怨
		/// </summary>
		public const short BecomeEnemy = 31;

		/// <summary>
		/// 结为好友
		/// </summary>
		public const short BecomeFriend = 32;

		/// <summary>
		/// 断绝友谊
		/// </summary>
		public const short SeverFriend = 33;

		/// <summary>
		/// 两情相悦
		/// </summary>
		public const short BecomeLover = 34;

		/// <summary>
		/// 恋人分手
		/// </summary>
		public const short BreakupWithLover = 35;

		/// <summary>
		/// 共结连理
		/// </summary>
		public const short BecomeHusbandAndWife = 36;

		/// <summary>
		/// 义结金兰
		/// </summary>
		public const short BecomeSwornBrothersAndSisters = 37;

		/// <summary>
		/// 割袍断义
		/// </summary>
		public const short SeverSwornBrothersAndSisters = 38;

		/// <summary>
		/// 拜认义亲
		/// </summary>
		public const short GetAdopted = 39;

		/// <summary>
		/// 收养子女
		/// </summary>
		public const short AdoptChild = 40;

		/// <summary>
		/// 赠送资源
		/// </summary>
		public const short GivingResource = 41;

		/// <summary>
		/// 赠送道具
		/// </summary>
		public const short GiveItem = 42;

		/// <summary>
		/// 修建坟墓
		/// </summary>
		public const short BuildGrave = 43;

		/// <summary>
		/// 施医赠药
		/// </summary>
		public const short Cure = 44;

		/// <summary>
		/// 修补道具
		/// </summary>
		public const short RepairItem = 45;

		/// <summary>
		/// 指点技艺
		/// </summary>
		public const short InstructOnLifeSkill = 46;

		/// <summary>
		/// 指点武学
		/// </summary>
		public const short InstructOnCombatSkill = 47;

		/// <summary>
		/// 同意疗伤
		/// </summary>
		public const short AcceptRequestHealInjury = 48;

		/// <summary>
		/// 同意驱毒
		/// </summary>
		public const short AcceptRequestDetoxPoison = 49;

		/// <summary>
		/// 同意续命
		/// </summary>
		public const short AcceptRequestIncreaseHealth = 50;

		/// <summary>
		/// 同意调息
		/// </summary>
		public const short AcceptRequestRestoreDisorderOfQi = 51;

		/// <summary>
		/// 同意补内
		/// </summary>
		public const short AcceptRequestIncreaseNeili = 52;

		/// <summary>
		/// 同意灭蛊
		/// </summary>
		public const short AcceptRequestKillWug = 53;

		/// <summary>
		/// 同意乞食
		/// </summary>
		public const short AcceptRequestFood = 54;

		/// <summary>
		/// 同意茶酒
		/// </summary>
		public const short AcceptRequestTeaWine = 55;

		/// <summary>
		/// 同意资源
		/// </summary>
		public const short AcceptRequestResource = 56;

		/// <summary>
		/// 同意道具
		/// </summary>
		public const short AcceptRequestItem = 57;

		/// <summary>
		/// 同意对饮
		/// </summary>
		public const short AcceptRequestDrinking = 58;

		/// <summary>
		/// 同意施舍
		/// </summary>
		public const short AcceptRequestGivingMoney = 59;

		/// <summary>
		/// 同意研读
		/// </summary>
		public const short AcceptRequestInstructionOnReading = 60;

		/// <summary>
		/// 同意突破
		/// </summary>
		public const short AcceptRequestInstructionOnBreakout = 61;

		/// <summary>
		/// 同意修理
		/// </summary>
		public const short AcceptRequestRepairItem = 62;

		/// <summary>
		/// 同意淬毒
		/// </summary>
		public const short AcceptRequestAddPoisonToItem = 63;

		/// <summary>
		/// 同意技艺
		/// </summary>
		public const short AcceptRequestInstructionOnLifeSkill = 64;

		/// <summary>
		/// 同意武学
		/// </summary>
		public const short AcceptRequestInstructionOnCombatSkill = 65;

		/// <summary>
		/// 梳头成功
		/// </summary>
		public const short RehaircutSuccess = 66;

		/// <summary>
		/// 梳头失误
		/// </summary>
		public const short RehaircutIncompleted = 67;

		/// <summary>
		/// 梳头失败
		/// </summary>
		public const short RehaircutFail = 68;

		/// <summary>
		/// 拒绝疗伤
		/// </summary>
		public const short RefuseRequestHealInjury = 69;

		/// <summary>
		/// 拒绝驱毒
		/// </summary>
		public const short RefuseRequestDetoxPoison = 70;

		/// <summary>
		/// 拒绝续命
		/// </summary>
		public const short RefuseRequestIncreaseHealth = 71;

		/// <summary>
		/// 拒绝调息
		/// </summary>
		public const short RefuseRequestRestoreDisorderOfQi = 72;

		/// <summary>
		/// 拒绝补内
		/// </summary>
		public const short RefuseRequestIncreaseNeili = 73;

		/// <summary>
		/// 拒绝灭蛊
		/// </summary>
		public const short RefuseRequestKillWug = 74;

		/// <summary>
		/// 拒绝乞食
		/// </summary>
		public const short RefuseRequestFood = 75;

		/// <summary>
		/// 拒绝茶酒
		/// </summary>
		public const short RefuseRequestTeaWine = 76;

		/// <summary>
		/// 拒绝资源
		/// </summary>
		public const short RefuseRequestResource = 77;

		/// <summary>
		/// 拒绝道具
		/// </summary>
		public const short RefuseRequestItem = 78;

		/// <summary>
		/// 拒绝对饮
		/// </summary>
		public const short RefuseRequestDrinking = 79;

		/// <summary>
		/// 拒绝施舍
		/// </summary>
		public const short RefuseRequestGivingMoney = 80;

		/// <summary>
		/// 拒绝研读
		/// </summary>
		public const short RefuseRequestInstructionOnReading = 81;

		/// <summary>
		/// 拒绝突破
		/// </summary>
		public const short RefuseRequestInstructionOnBreakout = 82;

		/// <summary>
		/// 拒绝修理
		/// </summary>
		public const short RefuseRequestRepairItem = 83;

		/// <summary>
		/// 拒绝淬毒
		/// </summary>
		public const short RefuseRequestAddPoisonToItem = 84;

		/// <summary>
		/// 拒绝技艺
		/// </summary>
		public const short RefuseRequestInstructionOnLifeSkill = 85;

		/// <summary>
		/// 拒绝武学
		/// </summary>
		public const short RefuseRequestInstructionOnCombatSkill = 86;

		/// <summary>
		/// 盗掘资源
		/// </summary>
		public const short RobGraveResource = 87;

		/// <summary>
		/// 窃取资源
		/// </summary>
		public const short StealResource = 88;

		/// <summary>
		/// 骗取资源
		/// </summary>
		public const short ScamResource = 89;

		/// <summary>
		/// 夺取资源
		/// </summary>
		public const short RobResource = 90;

		/// <summary>
		/// 盗掘道具
		/// </summary>
		public const short RobGraveItem = 91;

		/// <summary>
		/// 窃取道具
		/// </summary>
		public const short StealItem = 92;

		/// <summary>
		/// 骗取道具
		/// </summary>
		public const short ScamItem = 93;

		/// <summary>
		/// 夺取道具
		/// </summary>
		public const short RobItem = 94;

		/// <summary>
		/// 秘密杀害
		/// </summary>
		public const short KillInPrivate = 95;

		/// <summary>
		/// 秘密关押
		/// </summary>
		public const short KidnapInPrivate = 96;

		/// <summary>
		/// 毒害他人
		/// </summary>
		public const short PoisonEnemy = 97;

		/// <summary>
		/// 损伤他人
		/// </summary>
		public const short PlotHarmEnemy = 98;

		/// <summary>
		/// 窃取技艺
		/// </summary>
		public const short StealLifeSkill = 99;

		/// <summary>
		/// 骗取技艺
		/// </summary>
		public const short ScamLifeSkill = 100;

		/// <summary>
		/// 窃取武学
		/// </summary>
		public const short StealCombatSkill = 101;

		/// <summary>
		/// 骗取武学
		/// </summary>
		public const short ScamCombatSkill = 102;

		/// <summary>
		/// 道具淬毒
		/// </summary>
		public const short AddPoisonToItem = 103;

		/// <summary>
		/// 饮食破戒
		/// </summary>
		public const short MonkBreakRule = 104;

		/// <summary>
		/// 非法春宵
		/// </summary>
		public const short MakeLoveIllegal = 105;

		/// <summary>
		/// 情难自禁
		/// </summary>
		public const short Rape = 106;

		/// <summary>
		/// 痛失骨肉父亲不可知
		/// </summary>
		public const short LoseFetusFatherUnknown = 107;

		/// <summary>
		/// 生下孩子父亲不可知
		/// </summary>
		public const short GiveBirthToChildFatherUnknown = 108;

		/// <summary>
		/// 与人约会
		/// </summary>
		public const short DatingWithCrush = 109;

		/// <summary>
		/// 迫使不语
		/// </summary>
		public const short ForcingSilence = 110;

		/// <summary>
		/// 寻回子女
		/// </summary>
		public const short RetrieveChild = 111;

		/// <summary>
		/// 解读经文1
		/// </summary>
		public const short SolveScripture1 = 112;

		/// <summary>
		/// 解读经文2
		/// </summary>
		public const short SolveScripture2 = 113;

		/// <summary>
		/// 解读经文3
		/// </summary>
		public const short SolveScripture3 = 114;

		/// <summary>
		/// 解读经文4
		/// </summary>
		public const short SolveScripture4 = 115;

		/// <summary>
		/// 公开越狱
		/// </summary>
		public const short PrisonBreak = 116;

		/// <summary>
		/// 身怀六甲
		/// </summary>
		public const short Pregnant = 117;

		/// <summary>
		/// 身怀六甲父亲未知
		/// </summary>
		public const short PregnantWithoutFather = 118;

		/// <summary>
		/// 人物入魔
		/// </summary>
		public const short XiangshuType0 = 119;

		/// <summary>
		/// 人物入邪
		/// </summary>
		public const short XiangshuType1 = 120;

		/// <summary>
		/// 人物出家
		/// </summary>
		public const short BecomeMonk = 121;

		/// <summary>
		/// 人物离婚
		/// </summary>
		public const short Divorce = 122;

		/// <summary>
		/// 拜为师父
		/// </summary>
		public const short BecomeMaster = 123;

		/// <summary>
		/// 收为徒弟
		/// </summary>
		public const short BecomeApprentice = 124;

		/// <summary>
		/// 加入门派
		/// </summary>
		public const short JoinOrganization = 125;

		/// <summary>
		/// 获得奇书
		/// </summary>
		public const short GainQiBook = 126;

		/// <summary>
		/// 丢失奇书
		/// </summary>
		public const short LostQiBook = 127;

		/// <summary>
		/// 乞讨银钱
		/// </summary>
		public const short BegMoney = 128;

		/// <summary>
		/// 人物入狱
		/// </summary>
		public const short Imprisoned = 129;

		/// <summary>
		/// 人物出狱
		/// </summary>
		public const short ReleasedPrison = 130;

		/// <summary>
		/// 求取俘虏
		/// </summary>
		public const short BegPrisoner = 131;

		/// <summary>
		/// 偷窃俘虏
		/// </summary>
		public const short StealPrisoner = 132;

		/// <summary>
		/// 唬骗俘虏
		/// </summary>
		public const short ScamPrisoner = 133;

		/// <summary>
		/// 夺取俘虏
		/// </summary>
		public const short RobPrisoner = 134;

		/// <summary>
		/// 断绝父母
		/// </summary>
		public const short SeverGetAdopted = 135;

		/// <summary>
		/// 断绝子女
		/// </summary>
		public const short SeverAdoptChild = 136;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 人物死亡
		/// </summary>
		public static SecretInformationItem Die => Instance[(short)0];

		/// <summary>
		/// 公开杀害
		/// </summary>
		public static SecretInformationItem KillInPublic => Instance[(short)1];

		/// <summary>
		/// 公开关押
		/// </summary>
		public static SecretInformationItem KidnapInPublic => Instance[(short)2];

		/// <summary>
		/// 惩戒杀害
		/// </summary>
		public static SecretInformationItem KillForPunishment => Instance[(short)3];

		/// <summary>
		/// 惩戒关押
		/// </summary>
		public static SecretInformationItem KidnapForPunishment => Instance[(short)4];

		/// <summary>
		/// 天降资源
		/// </summary>
		public static SecretInformationItem UnexpectedResourceGain => Instance[(short)5];

		/// <summary>
		/// 天降财宝
		/// </summary>
		public static SecretInformationItem UnexpectedItemGain => Instance[(short)6];

		/// <summary>
		/// 天赐秘籍
		/// </summary>
		public static SecretInformationItem UnexpectedSkillBookGain => Instance[(short)7];

		/// <summary>
		/// 天助疗愈
		/// </summary>
		public static SecretInformationItem UnexpectedCure => Instance[(short)8];

		/// <summary>
		/// 天损资源
		/// </summary>
		public static SecretInformationItem UnexpectedResourceLose => Instance[(short)9];

		/// <summary>
		/// 天损财宝
		/// </summary>
		public static SecretInformationItem UnexpectedItemLose => Instance[(short)10];

		/// <summary>
		/// 天损秘籍
		/// </summary>
		public static SecretInformationItem UnexpectedSkillBookLose => Instance[(short)11];

		/// <summary>
		/// 天降灾刑
		/// </summary>
		public static SecretInformationItem UnexpectedHarm => Instance[(short)12];

		/// <summary>
		/// 较艺胜利
		/// </summary>
		public static SecretInformationItem LifeSkillBattleWin => Instance[(short)13];

		/// <summary>
		/// 促织战胜
		/// </summary>
		public static SecretInformationItem CricketBattleWin => Instance[(short)14];

		/// <summary>
		/// 战斗大胜
		/// </summary>
		public static SecretInformationItem MajorVictoryInCombat => Instance[(short)15];

		/// <summary>
		/// 战斗胜利
		/// </summary>
		public static SecretInformationItem MinorVictoryInCombat => Instance[(short)16];

		/// <summary>
		/// 祭拜故人
		/// </summary>
		public static SecretInformationItem Mourn => Instance[(short)17];

		/// <summary>
		/// 保护亲友
		/// </summary>
		public static SecretInformationItem OfferProtection => Instance[(short)18];

		/// <summary>
		/// 痛失骨肉
		/// </summary>
		public static SecretInformationItem LoseFetus => Instance[(short)19];

		/// <summary>
		/// 痛失骨肉2
		/// </summary>
		public static SecretInformationItem LoseFetus2 => Instance[(short)20];

		/// <summary>
		/// 生下孩子
		/// </summary>
		public static SecretInformationItem GiveBirthToChild => Instance[(short)21];

		/// <summary>
		/// 生下孩子2
		/// </summary>
		public static SecretInformationItem GiveBirthToChild2 => Instance[(short)22];

		/// <summary>
		/// 遗弃孩子
		/// </summary>
		public static SecretInformationItem AbandonChild => Instance[(short)23];

		/// <summary>
		/// 释放俘虏
		/// </summary>
		public static SecretInformationItem ReleaseKidnappedCharacter => Instance[(short)24];

		/// <summary>
		/// 解救俘虏
		/// </summary>
		public static SecretInformationItem RescueKidnappedCharacter => Instance[(short)25];

		/// <summary>
		/// 逃脱关押
		/// </summary>
		public static SecretInformationItem KidnappedCharacterEscaped => Instance[(short)26];

		/// <summary>
		/// 研读失败
		/// </summary>
		public static SecretInformationItem ReadBookFail => Instance[(short)27];

		/// <summary>
		/// 突破失败
		/// </summary>
		public static SecretInformationItem BreakoutFail => Instance[(short)28];

		/// <summary>
		/// 遗失宝物
		/// </summary>
		public static SecretInformationItem LoseOverloadingItem => Instance[(short)29];

		/// <summary>
		/// 化解仇怨
		/// </summary>
		public static SecretInformationItem SeverEnemy => Instance[(short)30];

		/// <summary>
		/// 结下仇怨
		/// </summary>
		public static SecretInformationItem BecomeEnemy => Instance[(short)31];

		/// <summary>
		/// 结为好友
		/// </summary>
		public static SecretInformationItem BecomeFriend => Instance[(short)32];

		/// <summary>
		/// 断绝友谊
		/// </summary>
		public static SecretInformationItem SeverFriend => Instance[(short)33];

		/// <summary>
		/// 两情相悦
		/// </summary>
		public static SecretInformationItem BecomeLover => Instance[(short)34];

		/// <summary>
		/// 恋人分手
		/// </summary>
		public static SecretInformationItem BreakupWithLover => Instance[(short)35];

		/// <summary>
		/// 共结连理
		/// </summary>
		public static SecretInformationItem BecomeHusbandAndWife => Instance[(short)36];

		/// <summary>
		/// 义结金兰
		/// </summary>
		public static SecretInformationItem BecomeSwornBrothersAndSisters => Instance[(short)37];

		/// <summary>
		/// 割袍断义
		/// </summary>
		public static SecretInformationItem SeverSwornBrothersAndSisters => Instance[(short)38];

		/// <summary>
		/// 拜认义亲
		/// </summary>
		public static SecretInformationItem GetAdopted => Instance[(short)39];

		/// <summary>
		/// 收养子女
		/// </summary>
		public static SecretInformationItem AdoptChild => Instance[(short)40];

		/// <summary>
		/// 赠送资源
		/// </summary>
		public static SecretInformationItem GivingResource => Instance[(short)41];

		/// <summary>
		/// 赠送道具
		/// </summary>
		public static SecretInformationItem GiveItem => Instance[(short)42];

		/// <summary>
		/// 修建坟墓
		/// </summary>
		public static SecretInformationItem BuildGrave => Instance[(short)43];

		/// <summary>
		/// 施医赠药
		/// </summary>
		public static SecretInformationItem Cure => Instance[(short)44];

		/// <summary>
		/// 修补道具
		/// </summary>
		public static SecretInformationItem RepairItem => Instance[(short)45];

		/// <summary>
		/// 指点技艺
		/// </summary>
		public static SecretInformationItem InstructOnLifeSkill => Instance[(short)46];

		/// <summary>
		/// 指点武学
		/// </summary>
		public static SecretInformationItem InstructOnCombatSkill => Instance[(short)47];

		/// <summary>
		/// 同意疗伤
		/// </summary>
		public static SecretInformationItem AcceptRequestHealInjury => Instance[(short)48];

		/// <summary>
		/// 同意驱毒
		/// </summary>
		public static SecretInformationItem AcceptRequestDetoxPoison => Instance[(short)49];

		/// <summary>
		/// 同意续命
		/// </summary>
		public static SecretInformationItem AcceptRequestIncreaseHealth => Instance[(short)50];

		/// <summary>
		/// 同意调息
		/// </summary>
		public static SecretInformationItem AcceptRequestRestoreDisorderOfQi => Instance[(short)51];

		/// <summary>
		/// 同意补内
		/// </summary>
		public static SecretInformationItem AcceptRequestIncreaseNeili => Instance[(short)52];

		/// <summary>
		/// 同意灭蛊
		/// </summary>
		public static SecretInformationItem AcceptRequestKillWug => Instance[(short)53];

		/// <summary>
		/// 同意乞食
		/// </summary>
		public static SecretInformationItem AcceptRequestFood => Instance[(short)54];

		/// <summary>
		/// 同意茶酒
		/// </summary>
		public static SecretInformationItem AcceptRequestTeaWine => Instance[(short)55];

		/// <summary>
		/// 同意资源
		/// </summary>
		public static SecretInformationItem AcceptRequestResource => Instance[(short)56];

		/// <summary>
		/// 同意道具
		/// </summary>
		public static SecretInformationItem AcceptRequestItem => Instance[(short)57];

		/// <summary>
		/// 同意对饮
		/// </summary>
		public static SecretInformationItem AcceptRequestDrinking => Instance[(short)58];

		/// <summary>
		/// 同意施舍
		/// </summary>
		public static SecretInformationItem AcceptRequestGivingMoney => Instance[(short)59];

		/// <summary>
		/// 同意研读
		/// </summary>
		public static SecretInformationItem AcceptRequestInstructionOnReading => Instance[(short)60];

		/// <summary>
		/// 同意突破
		/// </summary>
		public static SecretInformationItem AcceptRequestInstructionOnBreakout => Instance[(short)61];

		/// <summary>
		/// 同意修理
		/// </summary>
		public static SecretInformationItem AcceptRequestRepairItem => Instance[(short)62];

		/// <summary>
		/// 同意淬毒
		/// </summary>
		public static SecretInformationItem AcceptRequestAddPoisonToItem => Instance[(short)63];

		/// <summary>
		/// 同意技艺
		/// </summary>
		public static SecretInformationItem AcceptRequestInstructionOnLifeSkill => Instance[(short)64];

		/// <summary>
		/// 同意武学
		/// </summary>
		public static SecretInformationItem AcceptRequestInstructionOnCombatSkill => Instance[(short)65];

		/// <summary>
		/// 梳头成功
		/// </summary>
		public static SecretInformationItem RehaircutSuccess => Instance[(short)66];

		/// <summary>
		/// 梳头失误
		/// </summary>
		public static SecretInformationItem RehaircutIncompleted => Instance[(short)67];

		/// <summary>
		/// 梳头失败
		/// </summary>
		public static SecretInformationItem RehaircutFail => Instance[(short)68];

		/// <summary>
		/// 拒绝疗伤
		/// </summary>
		public static SecretInformationItem RefuseRequestHealInjury => Instance[(short)69];

		/// <summary>
		/// 拒绝驱毒
		/// </summary>
		public static SecretInformationItem RefuseRequestDetoxPoison => Instance[(short)70];

		/// <summary>
		/// 拒绝续命
		/// </summary>
		public static SecretInformationItem RefuseRequestIncreaseHealth => Instance[(short)71];

		/// <summary>
		/// 拒绝调息
		/// </summary>
		public static SecretInformationItem RefuseRequestRestoreDisorderOfQi => Instance[(short)72];

		/// <summary>
		/// 拒绝补内
		/// </summary>
		public static SecretInformationItem RefuseRequestIncreaseNeili => Instance[(short)73];

		/// <summary>
		/// 拒绝灭蛊
		/// </summary>
		public static SecretInformationItem RefuseRequestKillWug => Instance[(short)74];

		/// <summary>
		/// 拒绝乞食
		/// </summary>
		public static SecretInformationItem RefuseRequestFood => Instance[(short)75];

		/// <summary>
		/// 拒绝茶酒
		/// </summary>
		public static SecretInformationItem RefuseRequestTeaWine => Instance[(short)76];

		/// <summary>
		/// 拒绝资源
		/// </summary>
		public static SecretInformationItem RefuseRequestResource => Instance[(short)77];

		/// <summary>
		/// 拒绝道具
		/// </summary>
		public static SecretInformationItem RefuseRequestItem => Instance[(short)78];

		/// <summary>
		/// 拒绝对饮
		/// </summary>
		public static SecretInformationItem RefuseRequestDrinking => Instance[(short)79];

		/// <summary>
		/// 拒绝施舍
		/// </summary>
		public static SecretInformationItem RefuseRequestGivingMoney => Instance[(short)80];

		/// <summary>
		/// 拒绝研读
		/// </summary>
		public static SecretInformationItem RefuseRequestInstructionOnReading => Instance[(short)81];

		/// <summary>
		/// 拒绝突破
		/// </summary>
		public static SecretInformationItem RefuseRequestInstructionOnBreakout => Instance[(short)82];

		/// <summary>
		/// 拒绝修理
		/// </summary>
		public static SecretInformationItem RefuseRequestRepairItem => Instance[(short)83];

		/// <summary>
		/// 拒绝淬毒
		/// </summary>
		public static SecretInformationItem RefuseRequestAddPoisonToItem => Instance[(short)84];

		/// <summary>
		/// 拒绝技艺
		/// </summary>
		public static SecretInformationItem RefuseRequestInstructionOnLifeSkill => Instance[(short)85];

		/// <summary>
		/// 拒绝武学
		/// </summary>
		public static SecretInformationItem RefuseRequestInstructionOnCombatSkill => Instance[(short)86];

		/// <summary>
		/// 盗掘资源
		/// </summary>
		public static SecretInformationItem RobGraveResource => Instance[(short)87];

		/// <summary>
		/// 窃取资源
		/// </summary>
		public static SecretInformationItem StealResource => Instance[(short)88];

		/// <summary>
		/// 骗取资源
		/// </summary>
		public static SecretInformationItem ScamResource => Instance[(short)89];

		/// <summary>
		/// 夺取资源
		/// </summary>
		public static SecretInformationItem RobResource => Instance[(short)90];

		/// <summary>
		/// 盗掘道具
		/// </summary>
		public static SecretInformationItem RobGraveItem => Instance[(short)91];

		/// <summary>
		/// 窃取道具
		/// </summary>
		public static SecretInformationItem StealItem => Instance[(short)92];

		/// <summary>
		/// 骗取道具
		/// </summary>
		public static SecretInformationItem ScamItem => Instance[(short)93];

		/// <summary>
		/// 夺取道具
		/// </summary>
		public static SecretInformationItem RobItem => Instance[(short)94];

		/// <summary>
		/// 秘密杀害
		/// </summary>
		public static SecretInformationItem KillInPrivate => Instance[(short)95];

		/// <summary>
		/// 秘密关押
		/// </summary>
		public static SecretInformationItem KidnapInPrivate => Instance[(short)96];

		/// <summary>
		/// 毒害他人
		/// </summary>
		public static SecretInformationItem PoisonEnemy => Instance[(short)97];

		/// <summary>
		/// 损伤他人
		/// </summary>
		public static SecretInformationItem PlotHarmEnemy => Instance[(short)98];

		/// <summary>
		/// 窃取技艺
		/// </summary>
		public static SecretInformationItem StealLifeSkill => Instance[(short)99];

		/// <summary>
		/// 骗取技艺
		/// </summary>
		public static SecretInformationItem ScamLifeSkill => Instance[(short)100];

		/// <summary>
		/// 窃取武学
		/// </summary>
		public static SecretInformationItem StealCombatSkill => Instance[(short)101];

		/// <summary>
		/// 骗取武学
		/// </summary>
		public static SecretInformationItem ScamCombatSkill => Instance[(short)102];

		/// <summary>
		/// 道具淬毒
		/// </summary>
		public static SecretInformationItem AddPoisonToItem => Instance[(short)103];

		/// <summary>
		/// 饮食破戒
		/// </summary>
		public static SecretInformationItem MonkBreakRule => Instance[(short)104];

		/// <summary>
		/// 非法春宵
		/// </summary>
		public static SecretInformationItem MakeLoveIllegal => Instance[(short)105];

		/// <summary>
		/// 情难自禁
		/// </summary>
		public static SecretInformationItem Rape => Instance[(short)106];

		/// <summary>
		/// 痛失骨肉父亲不可知
		/// </summary>
		public static SecretInformationItem LoseFetusFatherUnknown => Instance[(short)107];

		/// <summary>
		/// 生下孩子父亲不可知
		/// </summary>
		public static SecretInformationItem GiveBirthToChildFatherUnknown => Instance[(short)108];

		/// <summary>
		/// 与人约会
		/// </summary>
		public static SecretInformationItem DatingWithCrush => Instance[(short)109];

		/// <summary>
		/// 迫使不语
		/// </summary>
		public static SecretInformationItem ForcingSilence => Instance[(short)110];

		/// <summary>
		/// 寻回子女
		/// </summary>
		public static SecretInformationItem RetrieveChild => Instance[(short)111];

		/// <summary>
		/// 解读经文1
		/// </summary>
		public static SecretInformationItem SolveScripture1 => Instance[(short)112];

		/// <summary>
		/// 解读经文2
		/// </summary>
		public static SecretInformationItem SolveScripture2 => Instance[(short)113];

		/// <summary>
		/// 解读经文3
		/// </summary>
		public static SecretInformationItem SolveScripture3 => Instance[(short)114];

		/// <summary>
		/// 解读经文4
		/// </summary>
		public static SecretInformationItem SolveScripture4 => Instance[(short)115];

		/// <summary>
		/// 公开越狱
		/// </summary>
		public static SecretInformationItem PrisonBreak => Instance[(short)116];

		/// <summary>
		/// 身怀六甲
		/// </summary>
		public static SecretInformationItem Pregnant => Instance[(short)117];

		/// <summary>
		/// 身怀六甲父亲未知
		/// </summary>
		public static SecretInformationItem PregnantWithoutFather => Instance[(short)118];

		/// <summary>
		/// 人物入魔
		/// </summary>
		public static SecretInformationItem XiangshuType0 => Instance[(short)119];

		/// <summary>
		/// 人物入邪
		/// </summary>
		public static SecretInformationItem XiangshuType1 => Instance[(short)120];

		/// <summary>
		/// 人物出家
		/// </summary>
		public static SecretInformationItem BecomeMonk => Instance[(short)121];

		/// <summary>
		/// 人物离婚
		/// </summary>
		public static SecretInformationItem Divorce => Instance[(short)122];

		/// <summary>
		/// 拜为师父
		/// </summary>
		public static SecretInformationItem BecomeMaster => Instance[(short)123];

		/// <summary>
		/// 收为徒弟
		/// </summary>
		public static SecretInformationItem BecomeApprentice => Instance[(short)124];

		/// <summary>
		/// 加入门派
		/// </summary>
		public static SecretInformationItem JoinOrganization => Instance[(short)125];

		/// <summary>
		/// 获得奇书
		/// </summary>
		public static SecretInformationItem GainQiBook => Instance[(short)126];

		/// <summary>
		/// 丢失奇书
		/// </summary>
		public static SecretInformationItem LostQiBook => Instance[(short)127];

		/// <summary>
		/// 乞讨银钱
		/// </summary>
		public static SecretInformationItem BegMoney => Instance[(short)128];

		/// <summary>
		/// 人物入狱
		/// </summary>
		public static SecretInformationItem Imprisoned => Instance[(short)129];

		/// <summary>
		/// 人物出狱
		/// </summary>
		public static SecretInformationItem ReleasedPrison => Instance[(short)130];

		/// <summary>
		/// 求取俘虏
		/// </summary>
		public static SecretInformationItem BegPrisoner => Instance[(short)131];

		/// <summary>
		/// 偷窃俘虏
		/// </summary>
		public static SecretInformationItem StealPrisoner => Instance[(short)132];

		/// <summary>
		/// 唬骗俘虏
		/// </summary>
		public static SecretInformationItem ScamPrisoner => Instance[(short)133];

		/// <summary>
		/// 夺取俘虏
		/// </summary>
		public static SecretInformationItem RobPrisoner => Instance[(short)134];

		/// <summary>
		/// 断绝父母
		/// </summary>
		public static SecretInformationItem SeverGetAdopted => Instance[(short)135];

		/// <summary>
		/// 断绝子女
		/// </summary>
		public static SecretInformationItem SeverAdoptChild => Instance[(short)136];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static SecretInformation Instance = new SecretInformation();

	private readonly HashSet<string> RequiredFields = new HashSet<string>
	{
		"Name", "Desc", "Parameters", "ParametersUiName", "DisseminationId", "ReceptionId", "DefaultEffectId", "StructGroupId", "SectPunishRuleId", "BroadcastDesc",
		"GeneralFilterType", "DetailedFilterType", "BlockSizeArgs"
	};

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
		_dataArray.Add(new SecretInformationItem(0, LocalStringManager.GetConfig("SecretInformation_language", "Name_0"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_0"), new sbyte[2] { 0, 1 }, -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_0_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_0_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_0_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_0_3")
		}, new sbyte[13]
		{
			1, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 1, 0, 0, 0, 1, 0, 0, autoBroadCast: true, 0, -1, 5, -3, 10, 3, ESecretInformationInitialTarget.None, new int[1], new int[1], new int[0], isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Normal, 0, 0, 0, 0, 0, 1, 250, 10000, 5, 425, 2500, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_0"), autoDissemination: true, 8, 17));
		_dataArray.Add(new SecretInformationItem(1, LocalStringManager.GetConfig("SecretInformation_language", "Name_1"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_1"), new sbyte[2], -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_1_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_1_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_1_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_1_3")
		}, new sbyte[13]
		{
			24, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 0, 0, 0, 0, 0, autoBroadCast: true, 0, -1, 5, -3, 10, 12, ESecretInformationInitialTarget.None, new int[1], new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: true, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Negative, 1, 1, 1, 15, 1, 8, 250, 10000, 5, 425, 2500, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_1"), autoDissemination: true, 0, 0));
		_dataArray.Add(new SecretInformationItem(2, LocalStringManager.GetConfig("SecretInformation_language", "Name_2"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_2"), new sbyte[2], -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_2_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_2_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_2_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_2_3")
		}, new sbyte[13]
		{
			24, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 0, 0, 0, 0, 0, autoBroadCast: true, 0, -1, 5, -3, 10, 12, ESecretInformationInitialTarget.None, new int[1], new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: true, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Negative, 2, 2, 2, 198, 2, 8, 250, 10000, 5, 425, 2500, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_2"), autoDissemination: true, 6, 1));
		_dataArray.Add(new SecretInformationItem(3, LocalStringManager.GetConfig("SecretInformation_language", "Name_3"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_3"), new sbyte[2], -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_3_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_3_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_3_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_3_3")
		}, new sbyte[13]
		{
			21, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 0, 0, 0, 0, 0, autoBroadCast: true, 0, -1, 5, -3, 10, 6, ESecretInformationInitialTarget.None, new int[1], new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Positive, 3, 3, 3, 137, 3, 7, 250, 10000, 5, 425, 2500, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_3"), autoDissemination: true, 0, 2));
		_dataArray.Add(new SecretInformationItem(4, LocalStringManager.GetConfig("SecretInformation_language", "Name_4"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_4"), new sbyte[2], -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_4_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_4_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_4_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_4_3")
		}, new sbyte[13]
		{
			21, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 0, 0, 0, 0, 0, autoBroadCast: true, 0, -1, 5, -3, 10, 6, ESecretInformationInitialTarget.None, new int[1], new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Positive, 4, 4, 4, 320, 4, 7, 250, 10000, 5, 425, 2500, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_4"), autoDissemination: true, 0, 2));
		_dataArray.Add(new SecretInformationItem(5, LocalStringManager.GetConfig("SecretInformation_language", "Name_5"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_5"), new sbyte[3] { 0, 2, 1 }, -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_5_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_5_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_5_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_5_3")
		}, new sbyte[13]
		{
			3, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 1, 0, 0, 0, 1, 1, 0, autoBroadCast: false, 100, -1, 5, -1, 10, 3, ESecretInformationInitialTarget.Area, new int[1], new int[1], new int[0], isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Positive, 5, 5, 5, 381, 5, 3, 100, 10000, 0, 425, 1000, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_5"), autoDissemination: true, 7, 55));
		_dataArray.Add(new SecretInformationItem(6, LocalStringManager.GetConfig("SecretInformation_language", "Name_6"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_6"), new sbyte[3] { 0, 3, 1 }, -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_6_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_6_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_6_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_6_3")
		}, new sbyte[13]
		{
			3, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 1, 1, 0, 0, 1, 0, 0, autoBroadCast: false, 100, -1, 5, -1, 10, 3, ESecretInformationInitialTarget.Area, new int[1], new int[1], new int[0], isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Positive, 5, 5, 6, 381, 6, 3, 100, 10000, 0, 425, 1000, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_6"), autoDissemination: true, 7, 55));
		_dataArray.Add(new SecretInformationItem(7, LocalStringManager.GetConfig("SecretInformation_language", "Name_7"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_7"), new sbyte[3] { 0, 3, 1 }, -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_7_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_7_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_7_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_7_3")
		}, new sbyte[13]
		{
			3, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 1, 1, 0, 0, 1, 0, 0, autoBroadCast: false, 100, -1, 5, -1, 10, 3, ESecretInformationInitialTarget.Area, new int[1], new int[1], new int[0], isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Positive, 6, 6, 7, 381, 7, 3, 100, 10000, 0, 425, 1000, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_7"), autoDissemination: true, 7, 55));
		_dataArray.Add(new SecretInformationItem(8, LocalStringManager.GetConfig("SecretInformation_language", "Name_8"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_8"), new sbyte[2] { 0, 1 }, -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_8_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_8_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_8_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_8_3")
		}, new sbyte[13]
		{
			3, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 1, 0, 0, 0, 1, 0, 0, autoBroadCast: false, 100, -1, 5, -1, 10, 3, ESecretInformationInitialTarget.Area, new int[1], new int[1], new int[0], isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Positive, 7, 7, 8, 381, 8, 3, 100, 10000, 0, 425, 1000, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_8"), autoDissemination: true, 7, 55));
		_dataArray.Add(new SecretInformationItem(9, LocalStringManager.GetConfig("SecretInformation_language", "Name_9"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_9"), new sbyte[3] { 0, 2, 1 }, -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_9_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_9_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_9_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_9_3")
		}, new sbyte[13]
		{
			3, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 1, 0, 0, 0, 1, 1, 0, autoBroadCast: false, 100, -1, 5, -1, 10, 3, ESecretInformationInitialTarget.Area, new int[1], new int[1], new int[0], isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Negative, 8, 8, 9, 396, 9, 3, 100, 10000, 0, 425, 1000, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_9"), autoDissemination: true, 7, 56));
		_dataArray.Add(new SecretInformationItem(10, LocalStringManager.GetConfig("SecretInformation_language", "Name_10"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_10"), new sbyte[3] { 0, 3, 1 }, -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_10_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_10_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_10_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_10_3")
		}, new sbyte[13]
		{
			3, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 1, 1, 0, 0, 1, 0, 0, autoBroadCast: false, 100, -1, 5, -1, 10, 3, ESecretInformationInitialTarget.Area, new int[1], new int[1], new int[0], isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Negative, 8, 8, 10, 396, 10, 3, 100, 10000, 0, 425, 1000, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_10"), autoDissemination: true, 7, 56));
		_dataArray.Add(new SecretInformationItem(11, LocalStringManager.GetConfig("SecretInformation_language", "Name_11"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_11"), new sbyte[3] { 0, 3, 1 }, -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_11_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_11_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_11_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_11_3")
		}, new sbyte[13]
		{
			3, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 1, 1, 0, 0, 1, 0, 0, autoBroadCast: false, 100, -1, 5, -1, 10, 3, ESecretInformationInitialTarget.Area, new int[1], new int[1], new int[0], isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Negative, 9, 9, 11, 396, 11, 3, 100, 10000, 0, 425, 1000, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_11"), autoDissemination: true, 7, 56));
		_dataArray.Add(new SecretInformationItem(12, LocalStringManager.GetConfig("SecretInformation_language", "Name_12"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_12"), new sbyte[2] { 0, 1 }, -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_12_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_12_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_12_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_12_3")
		}, new sbyte[13]
		{
			3, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 1, 0, 0, 0, 1, 0, 0, autoBroadCast: false, 100, -1, 5, -1, 10, 3, ESecretInformationInitialTarget.Area, new int[1], new int[1], new int[0], isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Negative, 10, 10, 12, 396, 12, 3, 100, 10000, 0, 425, 1000, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_12"), autoDissemination: true, 7, 56));
		_dataArray.Add(new SecretInformationItem(13, LocalStringManager.GetConfig("SecretInformation_language", "Name_13"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_13"), new sbyte[2], -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_13_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_13_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_13_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_13_3")
		}, new sbyte[13]
		{
			1, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 0, 0, 0, 0, 0, autoBroadCast: false, 100, -1, 5, -1, 10, 3, ESecretInformationInitialTarget.Nearest, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[0], isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Positive, 11, 11, 13, 411, 13, 1, 10, 10000, 1, 3100, 500, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_13"), autoDissemination: true, 2, 15));
		_dataArray.Add(new SecretInformationItem(14, LocalStringManager.GetConfig("SecretInformation_language", "Name_14"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_14"), new sbyte[2], -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_14_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_14_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_14_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_14_3")
		}, new sbyte[13]
		{
			1, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 0, 0, 0, 0, 0, autoBroadCast: false, 100, -1, 5, -1, 10, 3, ESecretInformationInitialTarget.Nearest, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[0], isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Positive, 12, 12, 14, 411, 14, 1, 10, 10000, 1, 3100, 500, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_14"), autoDissemination: true, 2, 15));
		_dataArray.Add(new SecretInformationItem(15, LocalStringManager.GetConfig("SecretInformation_language", "Name_15"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_15"), new sbyte[2], -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_15_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_15_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_15_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_15_3")
		}, new sbyte[13]
		{
			2, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 0, 0, 0, 0, 0, autoBroadCast: false, 200, -1, 5, -1, 10, 3, ESecretInformationInitialTarget.Nearest, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[0], isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Positive, 13, 13, 15, 411, 15, 2, 10, 10000, 1, 3100, 500, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_15"), autoDissemination: true, 2, 15));
		_dataArray.Add(new SecretInformationItem(16, LocalStringManager.GetConfig("SecretInformation_language", "Name_16"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_16"), new sbyte[2], -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_16_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_16_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_16_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_16_3")
		}, new sbyte[13]
		{
			2, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 0, 0, 0, 0, 0, autoBroadCast: false, 200, -1, 5, -1, 10, 3, ESecretInformationInitialTarget.Nearest, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[0], isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Positive, 14, 14, 16, 411, 16, 2, 10, 10000, 1, 3100, 500, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_16"), autoDissemination: true, 2, 15));
		_dataArray.Add(new SecretInformationItem(17, LocalStringManager.GetConfig("SecretInformation_language", "Name_17"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_17"), new sbyte[2], -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_17_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_17_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_17_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_17_3")
		}, new sbyte[13]
		{
			2, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 0, 0, 0, 0, 0, autoBroadCast: false, 100, -1, 5, -1, 10, 3, ESecretInformationInitialTarget.Local, new int[1], new int[2] { 0, 1 }, new int[1] { 1 }, isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Positive, 15, 15, 17, 458, 17, 2, 50, 10000, 5, 550, 1000, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_17"), autoDissemination: true, 8, 18));
		_dataArray.Add(new SecretInformationItem(18, LocalStringManager.GetConfig("SecretInformation_language", "Name_18"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_18"), new sbyte[3], -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_18_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_18_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_18_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_18_3")
		}, new sbyte[13]
		{
			3, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 0, 0, 0, 0, 0, autoBroadCast: false, 100, -1, 5, -1, 10, 3, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[3] { 0, 1, 2 }, new int[3] { 0, 1, 2 }, isGeneralRelationCharactersNeedSnapshot: true, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Positive, 16, 16, 18, 505, 18, 3, 100, 10000, 5, 550, 2500, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_18"), autoDissemination: true, 0, 19));
		_dataArray.Add(new SecretInformationItem(19, LocalStringManager.GetConfig("SecretInformation_language", "Name_19"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_19"), new sbyte[2] { 0, 1 }, -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_19_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_19_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_19_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_19_3")
		}, new sbyte[13]
		{
			6, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 1, 0, 0, 0, 1, 0, 0, autoBroadCast: false, 300, 1, 3, 1, 10, 6, ESecretInformationInitialTarget.Local, new int[1], new int[1], new int[1], isGeneralRelationCharactersNeedSnapshot: true, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Negative, 17, 17, 19, 602, 19, 6, 200, 10000, 0, 300, 2500, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_19"), autoDissemination: true, 5, 45));
		_dataArray.Add(new SecretInformationItem(20, LocalStringManager.GetConfig("SecretInformation_language", "Name_20"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_20"), new sbyte[3] { 0, 0, 1 }, -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_20_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_20_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_20_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_20_3")
		}, new sbyte[13]
		{
			3, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 0, 0, 1, 0, 0, autoBroadCast: false, 200, 1, 3, 1, 10, 6, ESecretInformationInitialTarget.Local, new int[1], new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: true, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Normal, 18, 18, 20, 743, 20, 3, 100, 10000, 0, 300, 1000, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_20"), autoDissemination: true, 5, 45));
		_dataArray.Add(new SecretInformationItem(21, LocalStringManager.GetConfig("SecretInformation_language", "Name_21"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_21"), new sbyte[2], -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_21_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_21_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_21_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_21_3")
		}, new sbyte[13]
		{
			6, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 0, 0, 0, 0, 0, autoBroadCast: false, 300, 1, 3, 0, 10, 6, ESecretInformationInitialTarget.Local, new int[1], new int[2] { 0, 1 }, new int[1], isGeneralRelationCharactersNeedSnapshot: true, isRelationCharactersAliveStateNeedSnapshot: true, ESecretInformationValueType.Negative, 20, 20, 21, 884, 21, 6, 200, 10000, 0, 300, 2500, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_21"), autoDissemination: true, 5, 46));
		_dataArray.Add(new SecretInformationItem(22, LocalStringManager.GetConfig("SecretInformation_language", "Name_22"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_22"), new sbyte[3], -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_22_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_22_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_22_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_22_3")
		}, new sbyte[13]
		{
			3, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 3, 0, 0, 0, 0, 0, 0, autoBroadCast: false, 200, 1, 3, 0, 10, 6, ESecretInformationInitialTarget.Local, new int[1], new int[3] { 0, 1, 2 }, new int[2] { 0, 2 }, isGeneralRelationCharactersNeedSnapshot: true, isRelationCharactersAliveStateNeedSnapshot: true, ESecretInformationValueType.Normal, 21, 21, 22, 1049, 22, 3, 100, 10000, 0, 300, 1000, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_22"), autoDissemination: true, 5, 46));
		_dataArray.Add(new SecretInformationItem(23, LocalStringManager.GetConfig("SecretInformation_language", "Name_23"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_23"), new sbyte[2], -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_23_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_23_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_23_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_23_3")
		}, new sbyte[13]
		{
			7, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 0, 0, 0, 0, 0, autoBroadCast: false, 500, 1, 3, 2, 10, 48, ESecretInformationInitialTarget.Local, new int[1], new int[2] { 0, 1 }, new int[1], isGeneralRelationCharactersNeedSnapshot: true, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Negative, 19, 19, 23, 1214, 23, 7, 200, 10000, 0, 300, 2500, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_23"), autoDissemination: true, 5, 47));
		_dataArray.Add(new SecretInformationItem(24, LocalStringManager.GetConfig("SecretInformation_language", "Name_24"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_24"), new sbyte[2], -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_24_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_24_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_24_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_24_3")
		}, new sbyte[13]
		{
			5, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 0, 0, 0, 0, 0, autoBroadCast: false, 200, -1, 5, 0, 10, 6, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: true, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Positive, 22, 22, 24, 2060, 24, 5, 250, 10000, 5, 150, 2500, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_24"), autoDissemination: true, 6, 49));
		_dataArray.Add(new SecretInformationItem(25, LocalStringManager.GetConfig("SecretInformation_language", "Name_25"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_25"), new sbyte[3], -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_25_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_25_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_25_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_25_3")
		}, new sbyte[13]
		{
			5, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 0, 0, 0, 0, 0, autoBroadCast: false, 200, -1, 5, 0, 10, 6, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[3] { 0, 1, 2 }, new int[3] { 0, 1, 2 }, isGeneralRelationCharactersNeedSnapshot: true, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Positive, 23, 23, 25, 2107, 25, 5, 250, 10000, 5, 150, 2500, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_25"), autoDissemination: true, 6, 50));
		_dataArray.Add(new SecretInformationItem(26, LocalStringManager.GetConfig("SecretInformation_language", "Name_26"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_26"), new sbyte[2], -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_26_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_26_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_26_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_26_3")
		}, new sbyte[13]
		{
			5, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 0, 0, 0, 0, 0, autoBroadCast: false, 200, -1, 5, 0, 10, 6, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[0], isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Normal, 24, 24, 26, 2204, 26, 5, 250, 10000, 5, 150, 2500, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_26"), autoDissemination: true, 6, 51));
		_dataArray.Add(new SecretInformationItem(27, LocalStringManager.GetConfig("SecretInformation_language", "Name_27"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_27"), new sbyte[2] { 0, 3 }, -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_27_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_27_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_27_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_27_3")
		}, new sbyte[13]
		{
			1, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 1, 1, 0, 0, 0, 0, 0, autoBroadCast: false, 200, -1, 5, -1, 10, 3, ESecretInformationInitialTarget.Local, new int[1], new int[1], new int[0], isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Normal, 25, 25, 27, 2251, 27, 1, 10, 10000, 1, 1225, 500, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_27"), autoDissemination: true, 2, 12));
		_dataArray.Add(new SecretInformationItem(28, LocalStringManager.GetConfig("SecretInformation_language", "Name_28"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_28"), new sbyte[2] { 0, 4 }, -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_28_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_28_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_28_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_28_3")
		}, new sbyte[13]
		{
			1, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 1, 0, 1, 0, 0, 0, 0, autoBroadCast: false, 200, -1, 5, -1, 10, 3, ESecretInformationInitialTarget.Local, new int[1], new int[1], new int[0], isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Normal, 26, 26, 28, 2266, 28, 1, 10, 10000, 1, 1225, 500, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_28"), autoDissemination: true, 2, 12));
		_dataArray.Add(new SecretInformationItem(29, LocalStringManager.GetConfig("SecretInformation_language", "Name_29"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_29"), new sbyte[3] { 0, 3, 1 }, -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_29_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_29_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_29_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_29_3")
		}, new sbyte[13]
		{
			3, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 1, 1, 0, 0, 1, 0, 0, autoBroadCast: false, 200, -1, 5, -1, 10, 3, ESecretInformationInitialTarget.Local, new int[1], new int[1], new int[0], isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Normal, 27, 27, 29, 2281, 29, 3, 25, 10000, 1, 2475, 1000, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_29"), autoDissemination: true, 7, 57));
		_dataArray.Add(new SecretInformationItem(30, LocalStringManager.GetConfig("SecretInformation_language", "Name_30"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_30"), new sbyte[2], -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_30_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_30_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_30_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_30_3")
		}, new sbyte[13]
		{
			3, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 0, 0, 0, 0, 0, autoBroadCast: false, 200, -1, 5, 0, 10, 6, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Positive, 28, 28, 30, 2343, 30, 3, 10, 10000, 5, 3050, 500, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_30"), autoDissemination: true, 3, 29));
		_dataArray.Add(new SecretInformationItem(31, LocalStringManager.GetConfig("SecretInformation_language", "Name_31"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_31"), new sbyte[2], -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_31_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_31_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_31_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_31_3")
		}, new sbyte[13]
		{
			3, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 0, 0, 0, 0, 0, autoBroadCast: false, 200, -1, 5, 0, 10, 6, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: true, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Negative, 35, 35, 31, 2404, 31, 3, 10, 10000, 5, 3050, 500, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_31"), autoDissemination: true, 3, 30));
		_dataArray.Add(new SecretInformationItem(32, LocalStringManager.GetConfig("SecretInformation_language", "Name_32"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_32"), new sbyte[2], -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_32_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_32_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_32_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_32_3")
		}, new sbyte[13]
		{
			4, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 0, 0, 0, 0, 0, autoBroadCast: false, 300, -1, 5, 0, 10, 6, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: true, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Positive, 31, 31, 32, 2465, 32, 4, 25, 10000, 5, 1175, 500, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_32"), autoDissemination: true, 3, 31));
		_dataArray.Add(new SecretInformationItem(33, LocalStringManager.GetConfig("SecretInformation_language", "Name_33"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_33"), new sbyte[2], -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_33_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_33_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_33_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_33_3")
		}, new sbyte[13]
		{
			4, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 0, 0, 0, 0, 0, autoBroadCast: false, 300, -1, 5, 0, 10, 6, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Negative, 37, 37, 33, 2526, 33, 4, 25, 10000, 5, 1175, 500, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_33"), autoDissemination: true, 3, 32));
		_dataArray.Add(new SecretInformationItem(34, LocalStringManager.GetConfig("SecretInformation_language", "Name_34"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_34"), new sbyte[2], -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_34_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_34_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_34_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_34_3")
		}, new sbyte[13]
		{
			5, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 0, 0, 0, 0, 0, autoBroadCast: false, 400, -1, 5, 0, 10, 6, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: true, isRelationCharactersAliveStateNeedSnapshot: true, ESecretInformationValueType.Positive, 29, 29, 34, 1355, 34, 5, 50, 10000, 5, 675, 1000, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_34"), autoDissemination: true, 3, 35));
		_dataArray.Add(new SecretInformationItem(35, LocalStringManager.GetConfig("SecretInformation_language", "Name_35"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_35"), new sbyte[2], -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_35_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_35_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_35_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_35_3")
		}, new sbyte[13]
		{
			5, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 0, 0, 0, 0, 0, autoBroadCast: false, 400, -1, 5, 0, 10, 6, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: true, ESecretInformationValueType.Negative, 36, 36, 35, 1496, 35, 5, 50, 10000, 5, 675, 1000, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_35"), autoDissemination: true, 3, 33));
		_dataArray.Add(new SecretInformationItem(36, LocalStringManager.GetConfig("SecretInformation_language", "Name_36"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_36"), new sbyte[2], -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_36_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_36_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_36_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_36_3")
		}, new sbyte[13]
		{
			6, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 0, 0, 0, 0, 0, autoBroadCast: false, 500, -1, 5, 0, 10, 6, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: true, isRelationCharactersAliveStateNeedSnapshot: true, ESecretInformationValueType.Positive, 30, 30, 36, 1637, 36, 6, 50, 10000, 5, 800, 1500, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_36"), autoDissemination: true, 3, 36));
		_dataArray.Add(new SecretInformationItem(37, LocalStringManager.GetConfig("SecretInformation_language", "Name_37"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_37"), new sbyte[2], -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_37_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_37_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_37_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_37_3")
		}, new sbyte[13]
		{
			6, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 0, 0, 0, 0, 0, autoBroadCast: false, 500, -1, 5, 0, 10, 6, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: true, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Positive, 32, 32, 37, 2587, 37, 6, 50, 10000, 5, 800, 1500, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_37"), autoDissemination: true, 3, 37));
		_dataArray.Add(new SecretInformationItem(38, LocalStringManager.GetConfig("SecretInformation_language", "Name_38"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_38"), new sbyte[2], -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_38_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_38_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_38_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_38_3")
		}, new sbyte[13]
		{
			6, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 0, 0, 0, 0, 0, autoBroadCast: false, 500, -1, 5, 0, 10, 6, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Negative, 38, 38, 38, 2648, 38, 6, 50, 10000, 5, 800, 1500, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_38"), autoDissemination: true, 3, 34));
		_dataArray.Add(new SecretInformationItem(39, LocalStringManager.GetConfig("SecretInformation_language", "Name_39"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_39"), new sbyte[2], -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_39_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_39_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_39_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_39_3")
		}, new sbyte[13]
		{
			6, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 0, 0, 0, 0, 0, autoBroadCast: false, 500, -1, 5, 0, 10, 6, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Positive, 33, 33, 39, 2709, 39, 6, 100, 10000, 5, 550, 2500, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_39"), autoDissemination: true, 3, 38));
		_dataArray.Add(new SecretInformationItem(40, LocalStringManager.GetConfig("SecretInformation_language", "Name_40"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_40"), new sbyte[2], -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_40_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_40_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_40_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_40_3")
		}, new sbyte[13]
		{
			6, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 0, 0, 0, 0, 0, autoBroadCast: false, 500, -1, 5, 0, 10, 6, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Positive, 34, 34, 40, 2770, 40, 6, 100, 10000, 5, 550, 2500, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_40"), autoDissemination: true, 3, 39));
		_dataArray.Add(new SecretInformationItem(41, LocalStringManager.GetConfig("SecretInformation_language", "Name_41"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_41"), new sbyte[3] { 0, 0, 2 }, -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_41_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_41_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_41_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_41_3")
		}, new sbyte[13]
		{
			1, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 0, 0, 0, 1, 0, autoBroadCast: false, 100, -1, 5, 0, 10, 6, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: true, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Positive, 39, 39, 41, 2831, 41, 1, 10, 10000, 5, 3050, 500, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_41"), autoDissemination: true, 4, 21));
		_dataArray.Add(new SecretInformationItem(42, LocalStringManager.GetConfig("SecretInformation_language", "Name_42"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_42"), new sbyte[3] { 0, 0, 3 }, -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_42_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_42_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_42_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_42_3")
		}, new sbyte[13]
		{
			1, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 1, 0, 0, 0, 0, 0, autoBroadCast: false, 100, -1, 5, 0, 10, 6, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Positive, 40, 40, 42, 2831, 42, 1, 10, 10000, 5, 3050, 500, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_42"), autoDissemination: true, 4, 21));
		_dataArray.Add(new SecretInformationItem(43, LocalStringManager.GetConfig("SecretInformation_language", "Name_43"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_43"), new sbyte[2], -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_43_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_43_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_43_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_43_3")
		}, new sbyte[13]
		{
			1, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 0, 0, 0, 0, 0, autoBroadCast: false, 100, -1, 5, 0, 10, 6, ESecretInformationInitialTarget.Nearest, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Positive, 41, 41, 43, 2296, 43, 1, 10, 10000, 5, 3050, 500, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_43"), autoDissemination: true, 8, 24));
		_dataArray.Add(new SecretInformationItem(44, LocalStringManager.GetConfig("SecretInformation_language", "Name_44"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_44"), new sbyte[2], -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_44_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_44_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_44_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_44_3")
		}, new sbyte[13]
		{
			1, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 1, 0, 0, 0, 0, 0, autoBroadCast: false, 100, -1, 5, 0, 10, 6, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: true, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Positive, 42, 42, 44, 2831, 44, 1, 10, 10000, 5, 3050, 500, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_44"), autoDissemination: true, 9, 25));
		_dataArray.Add(new SecretInformationItem(45, LocalStringManager.GetConfig("SecretInformation_language", "Name_45"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_45"), new sbyte[3] { 0, 0, 3 }, -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_45_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_45_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_45_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_45_3")
		}, new sbyte[13]
		{
			1, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 1, 0, 0, 0, 0, 0, autoBroadCast: false, 100, -1, 5, 0, 10, 6, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Positive, 43, 43, 45, 2831, 45, 1, 10, 10000, 5, 3050, 500, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_45"), autoDissemination: true, 9, 26));
		_dataArray.Add(new SecretInformationItem(46, LocalStringManager.GetConfig("SecretInformation_language", "Name_46"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_46"), new sbyte[3] { 0, 0, 5 }, -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_46_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_46_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_46_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_46_3")
		}, new sbyte[13]
		{
			1, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 0, 1, 0, 0, 0, autoBroadCast: false, 200, -1, 5, 1, 10, 6, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Positive, 44, 44, 46, 2831, 46, 1, 10, 10000, 5, 3050, 500, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_46"), autoDissemination: true, 2, 12));
		_dataArray.Add(new SecretInformationItem(47, LocalStringManager.GetConfig("SecretInformation_language", "Name_47"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_47"), new sbyte[3] { 0, 0, 4 }, -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_47_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_47_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_47_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_47_3")
		}, new sbyte[13]
		{
			1, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 1, 0, 0, 0, 0, autoBroadCast: false, 200, -1, 5, 1, 10, 6, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Positive, 45, 45, 47, 2831, 47, 1, 10, 10000, 5, 3050, 500, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_47"), autoDissemination: true, 2, 12));
		_dataArray.Add(new SecretInformationItem(48, LocalStringManager.GetConfig("SecretInformation_language", "Name_48"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_48"), new sbyte[2], -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_48_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_48_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_48_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_48_3")
		}, new sbyte[13]
		{
			1, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 0, 0, 0, 0, 0, autoBroadCast: false, 100, -1, 5, -1, 10, 3, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Normal, 46, 46, 48, 2878, 48, 1, 1, 10000, 5, 12425, 200, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_48"), autoDissemination: true, 4, 22));
		_dataArray.Add(new SecretInformationItem(49, LocalStringManager.GetConfig("SecretInformation_language", "Name_49"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_49"), new sbyte[2], -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_49_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_49_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_49_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_49_3")
		}, new sbyte[13]
		{
			1, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 0, 0, 0, 0, 0, autoBroadCast: false, 100, -1, 5, -1, 10, 3, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Normal, 47, 47, 49, 2878, 49, 1, 1, 10000, 5, 12425, 200, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_49"), autoDissemination: true, 4, 22));
		_dataArray.Add(new SecretInformationItem(50, LocalStringManager.GetConfig("SecretInformation_language", "Name_50"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_50"), new sbyte[2], -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_50_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_50_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_50_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_50_3")
		}, new sbyte[13]
		{
			1, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 0, 0, 0, 0, 0, autoBroadCast: false, 100, -1, 5, -1, 10, 3, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Normal, 48, 48, 50, 2878, 50, 1, 1, 10000, 5, 12425, 200, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_50"), autoDissemination: true, 4, 22));
		_dataArray.Add(new SecretInformationItem(51, LocalStringManager.GetConfig("SecretInformation_language", "Name_51"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_51"), new sbyte[2], -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_51_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_51_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_51_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_51_3")
		}, new sbyte[13]
		{
			1, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 0, 0, 0, 0, 0, autoBroadCast: false, 100, -1, 5, -1, 10, 3, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Normal, 49, 49, 51, 2878, 51, 1, 1, 10000, 5, 12425, 200, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_51"), autoDissemination: true, 4, 22));
		_dataArray.Add(new SecretInformationItem(52, LocalStringManager.GetConfig("SecretInformation_language", "Name_52"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_52"), new sbyte[2], -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_52_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_52_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_52_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_52_3")
		}, new sbyte[13]
		{
			1, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 0, 0, 0, 0, 0, autoBroadCast: false, 100, -1, 5, -1, 10, 3, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Normal, 50, 50, 52, 2878, 52, 1, 1, 10000, 5, 12425, 200, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_52"), autoDissemination: true, 4, 22));
		_dataArray.Add(new SecretInformationItem(53, LocalStringManager.GetConfig("SecretInformation_language", "Name_53"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_53"), new sbyte[2], -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_53_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_53_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_53_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_53_3")
		}, new sbyte[13]
		{
			1, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 0, 0, 0, 0, 0, autoBroadCast: false, 100, -1, 5, -1, 10, 3, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Normal, 51, 51, 53, 2878, 53, 1, 1, 10000, 5, 12425, 200, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_53"), autoDissemination: true, 4, 22));
		_dataArray.Add(new SecretInformationItem(54, LocalStringManager.GetConfig("SecretInformation_language", "Name_54"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_54"), new sbyte[3] { 0, 0, 3 }, -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_54_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_54_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_54_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_54_3")
		}, new sbyte[13]
		{
			1, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 1, 0, 0, 0, 0, 0, autoBroadCast: false, 100, -1, 5, -1, 10, 3, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Normal, 52, 52, 54, 2878, 54, 1, 1, 10000, 5, 12425, 200, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_54"), autoDissemination: true, 4, 22));
		_dataArray.Add(new SecretInformationItem(55, LocalStringManager.GetConfig("SecretInformation_language", "Name_55"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_55"), new sbyte[3] { 0, 0, 3 }, -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_55_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_55_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_55_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_55_3")
		}, new sbyte[13]
		{
			1, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 1, 0, 0, 0, 0, 0, autoBroadCast: false, 100, -1, 5, -1, 10, 3, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Normal, 53, 53, 55, 2878, 55, 1, 1, 10000, 5, 12425, 200, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_55"), autoDissemination: true, 4, 22));
		_dataArray.Add(new SecretInformationItem(56, LocalStringManager.GetConfig("SecretInformation_language", "Name_56"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_56"), new sbyte[3] { 0, 0, 2 }, -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_56_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_56_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_56_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_56_3")
		}, new sbyte[13]
		{
			1, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 0, 0, 0, 1, 0, autoBroadCast: false, 100, -1, 5, -1, 10, 3, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Normal, 54, 54, 56, 2878, 56, 1, 1, 10000, 5, 12425, 200, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_56"), autoDissemination: true, 4, 22));
		_dataArray.Add(new SecretInformationItem(57, LocalStringManager.GetConfig("SecretInformation_language", "Name_57"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_57"), new sbyte[3] { 0, 0, 3 }, -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_57_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_57_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_57_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_57_3")
		}, new sbyte[13]
		{
			1, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 1, 0, 0, 0, 0, 0, autoBroadCast: false, 100, -1, 5, -1, 10, 3, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Normal, 55, 55, 57, 2878, 57, 1, 1, 10000, 5, 12425, 200, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_57"), autoDissemination: true, 4, 22));
		_dataArray.Add(new SecretInformationItem(58, LocalStringManager.GetConfig("SecretInformation_language", "Name_58"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_58"), new sbyte[2], -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_58_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_58_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_58_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_58_3")
		}, new sbyte[13]
		{
			1, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 0, 0, 0, 0, 0, autoBroadCast: false, 100, -1, 5, -1, 10, 3, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Normal, 56, 56, 58, 2878, 58, 1, 1, 10000, 5, 12425, 200, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_58"), autoDissemination: true, 4, 22));
		_dataArray.Add(new SecretInformationItem(59, LocalStringManager.GetConfig("SecretInformation_language", "Name_59"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_59"), new sbyte[3] { 0, 0, 6 }, -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_59_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_59_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_59_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_59_3")
		}, new sbyte[13]
		{
			1, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 0, 0, 0, 0, 1, autoBroadCast: false, 100, -1, 5, -1, 10, 3, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Normal, 57, 57, 59, 2878, 59, 1, 1, 10000, 5, 12425, 200, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_59"), autoDissemination: true, 4, 22));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new SecretInformationItem(60, LocalStringManager.GetConfig("SecretInformation_language", "Name_60"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_60"), new sbyte[3] { 0, 0, 3 }, -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_60_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_60_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_60_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_60_3")
		}, new sbyte[13]
		{
			1, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 1, 0, 0, 0, 0, 0, autoBroadCast: false, 100, -1, 5, -1, 10, 3, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Normal, 58, 58, 60, 2878, 60, 1, 1, 10000, 5, 12425, 200, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_60"), autoDissemination: true, 4, 22));
		_dataArray.Add(new SecretInformationItem(61, LocalStringManager.GetConfig("SecretInformation_language", "Name_61"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_61"), new sbyte[3] { 0, 0, 4 }, -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_61_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_61_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_61_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_61_3")
		}, new sbyte[13]
		{
			1, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 1, 0, 0, 0, 0, autoBroadCast: false, 100, -1, 5, -1, 10, 3, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Normal, 59, 59, 61, 2878, 61, 1, 1, 10000, 5, 12425, 200, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_61"), autoDissemination: true, 4, 22));
		_dataArray.Add(new SecretInformationItem(62, LocalStringManager.GetConfig("SecretInformation_language", "Name_62"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_62"), new sbyte[3] { 0, 0, 3 }, -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_62_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_62_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_62_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_62_3")
		}, new sbyte[13]
		{
			1, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 1, 0, 0, 0, 0, 0, autoBroadCast: false, 100, -1, 5, -1, 10, 3, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Normal, 60, 60, 62, 2878, 62, 1, 1, 10000, 5, 12425, 200, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_62"), autoDissemination: true, 4, 22));
		_dataArray.Add(new SecretInformationItem(63, LocalStringManager.GetConfig("SecretInformation_language", "Name_63"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_63"), new sbyte[4] { 0, 0, 3, 3 }, -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_63_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_63_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_63_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_63_3")
		}, new sbyte[13]
		{
			1, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 2, 0, 0, 0, 0, 0, autoBroadCast: false, 100, -1, 5, -1, 10, 3, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Normal, 61, 61, 63, 2878, 63, 1, 1, 10000, 5, 12425, 200, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_63"), autoDissemination: true, 4, 22));
		_dataArray.Add(new SecretInformationItem(64, LocalStringManager.GetConfig("SecretInformation_language", "Name_64"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_64"), new sbyte[3] { 0, 0, 5 }, -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_64_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_64_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_64_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_64_3")
		}, new sbyte[13]
		{
			1, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 0, 1, 0, 0, 0, autoBroadCast: false, 100, -1, 5, -1, 10, 3, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Normal, 62, 62, 64, 2878, 64, 1, 1, 10000, 5, 12425, 200, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_64"), autoDissemination: true, 4, 22));
		_dataArray.Add(new SecretInformationItem(65, LocalStringManager.GetConfig("SecretInformation_language", "Name_65"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_65"), new sbyte[3] { 0, 0, 4 }, -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_65_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_65_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_65_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_65_3")
		}, new sbyte[13]
		{
			1, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 1, 0, 0, 0, 0, autoBroadCast: false, 100, -1, 5, -1, 10, 3, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Normal, 63, 63, 65, 2878, 65, 1, 1, 10000, 5, 12425, 200, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_65"), autoDissemination: true, 4, 22));
		_dataArray.Add(new SecretInformationItem(66, LocalStringManager.GetConfig("SecretInformation_language", "Name_66"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_66"), new sbyte[2], -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_66_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_66_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_66_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_66_3")
		}, new sbyte[13]
		{
			2, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 0, 0, 0, 0, 0, autoBroadCast: false, 100, -1, 5, -1, 10, 3, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[1] { 1 }, isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Normal, 64, 64, 66, 2972, 66, 2, 10, 10000, 1, 3100, 500, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_66"), autoDissemination: true, 9, 27));
		_dataArray.Add(new SecretInformationItem(67, LocalStringManager.GetConfig("SecretInformation_language", "Name_67"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_67"), new sbyte[2], -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_67_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_67_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_67_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_67_3")
		}, new sbyte[13]
		{
			3, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 0, 0, 0, 0, 0, autoBroadCast: false, 100, -1, 5, -1, 10, 3, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[1] { 1 }, isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Normal, 65, 65, 67, 3019, 67, 3, 10, 10000, 1, 3725, 1000, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_67"), autoDissemination: true, 9, 27));
		_dataArray.Add(new SecretInformationItem(68, LocalStringManager.GetConfig("SecretInformation_language", "Name_68"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_68"), new sbyte[2], -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_68_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_68_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_68_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_68_3")
		}, new sbyte[13]
		{
			4, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 0, 0, 0, 0, 0, autoBroadCast: false, 100, -1, 5, -1, 10, 3, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[1] { 1 }, isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Normal, 66, 66, 68, 3066, 68, 4, 10, 10000, 1, 4350, 1500, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_68"), autoDissemination: true, 9, 27));
		_dataArray.Add(new SecretInformationItem(69, LocalStringManager.GetConfig("SecretInformation_language", "Name_69"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_69"), new sbyte[2], -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_69_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_69_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_69_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_69_3")
		}, new sbyte[13]
		{
			1, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 0, 0, 0, 0, 0, autoBroadCast: false, 100, -1, 5, -1, 10, 3, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Normal, 67, 67, 69, 2925, 69, 1, 1, 10000, 5, 12425, 200, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_69"), autoDissemination: true, 4, 23));
		_dataArray.Add(new SecretInformationItem(70, LocalStringManager.GetConfig("SecretInformation_language", "Name_70"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_70"), new sbyte[2], -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_70_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_70_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_70_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_70_3")
		}, new sbyte[13]
		{
			1, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 0, 0, 0, 0, 0, autoBroadCast: false, 100, -1, 5, -1, 10, 3, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Normal, 68, 68, 70, 2925, 70, 1, 1, 10000, 5, 12425, 200, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_70"), autoDissemination: true, 4, 23));
		_dataArray.Add(new SecretInformationItem(71, LocalStringManager.GetConfig("SecretInformation_language", "Name_71"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_71"), new sbyte[2], -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_71_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_71_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_71_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_71_3")
		}, new sbyte[13]
		{
			1, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 0, 0, 0, 0, 0, autoBroadCast: false, 100, -1, 5, -1, 10, 3, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Normal, 69, 69, 71, 2925, 71, 1, 1, 10000, 5, 12425, 200, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_71"), autoDissemination: true, 4, 23));
		_dataArray.Add(new SecretInformationItem(72, LocalStringManager.GetConfig("SecretInformation_language", "Name_72"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_72"), new sbyte[2], -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_72_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_72_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_72_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_72_3")
		}, new sbyte[13]
		{
			1, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 0, 0, 0, 0, 0, autoBroadCast: false, 100, -1, 5, -1, 10, 3, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Normal, 70, 70, 72, 2925, 72, 1, 1, 10000, 5, 12425, 200, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_72"), autoDissemination: true, 4, 23));
		_dataArray.Add(new SecretInformationItem(73, LocalStringManager.GetConfig("SecretInformation_language", "Name_73"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_73"), new sbyte[2], -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_73_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_73_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_73_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_73_3")
		}, new sbyte[13]
		{
			1, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 0, 0, 0, 0, 0, autoBroadCast: false, 100, -1, 5, -1, 10, 3, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Normal, 71, 71, 73, 2925, 73, 1, 1, 10000, 5, 12425, 200, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_73"), autoDissemination: true, 4, 23));
		_dataArray.Add(new SecretInformationItem(74, LocalStringManager.GetConfig("SecretInformation_language", "Name_74"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_74"), new sbyte[2], -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_74_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_74_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_74_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_74_3")
		}, new sbyte[13]
		{
			1, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 0, 0, 0, 0, 0, autoBroadCast: false, 100, -1, 5, -1, 10, 3, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Normal, 72, 72, 74, 2925, 74, 1, 1, 10000, 5, 12425, 200, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_74"), autoDissemination: true, 4, 23));
		_dataArray.Add(new SecretInformationItem(75, LocalStringManager.GetConfig("SecretInformation_language", "Name_75"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_75"), new sbyte[3] { 0, 0, 3 }, -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_75_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_75_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_75_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_75_3")
		}, new sbyte[13]
		{
			1, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 1, 0, 0, 0, 0, 0, autoBroadCast: false, 100, -1, 5, -1, 10, 3, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Normal, 73, 73, 75, 2925, 75, 1, 1, 10000, 5, 12425, 200, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_75"), autoDissemination: true, 4, 23));
		_dataArray.Add(new SecretInformationItem(76, LocalStringManager.GetConfig("SecretInformation_language", "Name_76"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_76"), new sbyte[3] { 0, 0, 3 }, -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_76_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_76_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_76_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_76_3")
		}, new sbyte[13]
		{
			1, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 1, 0, 0, 0, 0, 0, autoBroadCast: false, 100, -1, 5, -1, 10, 3, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Normal, 74, 74, 76, 2925, 76, 1, 1, 10000, 5, 12425, 200, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_76"), autoDissemination: true, 4, 23));
		_dataArray.Add(new SecretInformationItem(77, LocalStringManager.GetConfig("SecretInformation_language", "Name_77"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_77"), new sbyte[3] { 0, 0, 2 }, -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_77_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_77_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_77_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_77_3")
		}, new sbyte[13]
		{
			1, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 0, 0, 0, 1, 0, autoBroadCast: false, 100, -1, 5, -1, 10, 3, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Normal, 75, 75, 77, 2925, 77, 1, 1, 10000, 5, 12425, 200, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_77"), autoDissemination: true, 4, 23));
		_dataArray.Add(new SecretInformationItem(78, LocalStringManager.GetConfig("SecretInformation_language", "Name_78"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_78"), new sbyte[3] { 0, 0, 3 }, -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_78_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_78_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_78_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_78_3")
		}, new sbyte[13]
		{
			1, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 1, 0, 0, 0, 0, 0, autoBroadCast: false, 100, -1, 5, -1, 10, 3, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Normal, 76, 76, 78, 2925, 78, 1, 1, 10000, 5, 12425, 200, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_78"), autoDissemination: true, 4, 23));
		_dataArray.Add(new SecretInformationItem(79, LocalStringManager.GetConfig("SecretInformation_language", "Name_79"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_79"), new sbyte[2], -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_79_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_79_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_79_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_79_3")
		}, new sbyte[13]
		{
			1, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 0, 0, 0, 0, 0, autoBroadCast: false, 100, -1, 5, -1, 10, 3, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Normal, 77, 77, 79, 2925, 79, 1, 1, 10000, 5, 12425, 200, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_79"), autoDissemination: true, 4, 23));
		_dataArray.Add(new SecretInformationItem(80, LocalStringManager.GetConfig("SecretInformation_language", "Name_80"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_80"), new sbyte[3] { 0, 0, 6 }, -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_80_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_80_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_80_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_80_3")
		}, new sbyte[13]
		{
			1, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 0, 0, 0, 0, 1, autoBroadCast: false, 100, -1, 5, -1, 10, 3, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Normal, 78, 78, 80, 2925, 80, 1, 1, 10000, 5, 12425, 200, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_80"), autoDissemination: true, 4, 23));
		_dataArray.Add(new SecretInformationItem(81, LocalStringManager.GetConfig("SecretInformation_language", "Name_81"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_81"), new sbyte[3] { 0, 0, 3 }, -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_81_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_81_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_81_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_81_3")
		}, new sbyte[13]
		{
			1, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 1, 0, 0, 0, 0, 0, autoBroadCast: false, 100, -1, 5, -1, 10, 3, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Normal, 79, 79, 81, 2925, 81, 1, 1, 10000, 5, 12425, 200, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_81"), autoDissemination: true, 4, 23));
		_dataArray.Add(new SecretInformationItem(82, LocalStringManager.GetConfig("SecretInformation_language", "Name_82"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_82"), new sbyte[3] { 0, 0, 4 }, -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_82_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_82_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_82_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_82_3")
		}, new sbyte[13]
		{
			1, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 1, 0, 0, 0, 0, autoBroadCast: false, 100, -1, 5, -1, 10, 3, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Normal, 80, 80, 82, 2925, 82, 1, 1, 10000, 5, 12425, 200, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_82"), autoDissemination: true, 4, 23));
		_dataArray.Add(new SecretInformationItem(83, LocalStringManager.GetConfig("SecretInformation_language", "Name_83"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_83"), new sbyte[3] { 0, 0, 3 }, -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_83_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_83_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_83_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_83_3")
		}, new sbyte[13]
		{
			1, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 1, 0, 0, 0, 0, 0, autoBroadCast: false, 100, -1, 5, -1, 10, 3, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Normal, 81, 81, 83, 2925, 83, 1, 1, 10000, 5, 12425, 200, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_83"), autoDissemination: true, 4, 23));
		_dataArray.Add(new SecretInformationItem(84, LocalStringManager.GetConfig("SecretInformation_language", "Name_84"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_84"), new sbyte[4] { 0, 0, 3, 3 }, -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_84_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_84_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_84_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_84_3")
		}, new sbyte[13]
		{
			1, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 2, 0, 0, 0, 0, 0, autoBroadCast: false, 100, -1, 5, -1, 10, 3, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Normal, 82, 82, 84, 2925, 84, 1, 1, 10000, 5, 12425, 200, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_84"), autoDissemination: true, 4, 23));
		_dataArray.Add(new SecretInformationItem(85, LocalStringManager.GetConfig("SecretInformation_language", "Name_85"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_85"), new sbyte[3] { 0, 0, 5 }, -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_85_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_85_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_85_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_85_3")
		}, new sbyte[13]
		{
			1, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 0, 1, 0, 0, 0, autoBroadCast: false, 100, -1, 5, -1, 10, 3, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Normal, 83, 83, 85, 2925, 85, 1, 1, 10000, 5, 12425, 200, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_85"), autoDissemination: true, 4, 23));
		_dataArray.Add(new SecretInformationItem(86, LocalStringManager.GetConfig("SecretInformation_language", "Name_86"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_86"), new sbyte[3] { 0, 0, 4 }, -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_86_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_86_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_86_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_86_3")
		}, new sbyte[13]
		{
			1, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 1, 0, 0, 0, 0, autoBroadCast: false, 100, -1, 5, -1, 10, 3, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Normal, 84, 84, 86, 2925, 86, 1, 1, 10000, 5, 12425, 200, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_86"), autoDissemination: true, 4, 23));
		_dataArray.Add(new SecretInformationItem(87, LocalStringManager.GetConfig("SecretInformation_language", "Name_87"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_87"), new sbyte[3] { 0, 0, 2 }, -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_87_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_87_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_87_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_87_3")
		}, new sbyte[13]
		{
			5, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 0, 0, 0, 1, 0, autoBroadCast: false, 300, 1, 3, 1, 10, 6, ESecretInformationInitialTarget.Local, new int[1], new int[2] { 0, 1 }, new int[1], isGeneralRelationCharactersNeedSnapshot: true, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Negative, 85, 85, 87, 3113, 87, 5, 250, 10000, 1, 100, 1000, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_87"), autoDissemination: true, 1, 6));
		_dataArray.Add(new SecretInformationItem(88, LocalStringManager.GetConfig("SecretInformation_language", "Name_88"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_88"), new sbyte[3] { 0, 0, 2 }, -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_88_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_88_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_88_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_88_3")
		}, new sbyte[13]
		{
			6, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 0, 0, 0, 1, 0, autoBroadCast: false, 500, 1, 3, 1, 10, 6, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: true, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Negative, 86, 86, 88, 3174, 88, 6, 500, 10000, 1, 100, 2500, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_88"), autoDissemination: true, 1, 7));
		_dataArray.Add(new SecretInformationItem(89, LocalStringManager.GetConfig("SecretInformation_language", "Name_89"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_89"), new sbyte[3] { 0, 0, 2 }, -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_89_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_89_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_89_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_89_3")
		}, new sbyte[13]
		{
			6, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 0, 0, 0, 1, 0, autoBroadCast: false, 500, 1, 3, 1, 10, 6, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: true, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Negative, 87, 87, 89, 3235, 89, 6, 500, 10000, 1, 100, 2500, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_89"), autoDissemination: true, 1, 8));
		_dataArray.Add(new SecretInformationItem(90, LocalStringManager.GetConfig("SecretInformation_language", "Name_90"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_90"), new sbyte[3] { 0, 0, 2 }, -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_90_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_90_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_90_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_90_3")
		}, new sbyte[13]
		{
			6, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 0, 0, 0, 1, 0, autoBroadCast: false, 500, 1, 3, 1, 10, 6, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: true, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Negative, 88, 88, 90, 3296, 90, 6, 500, 10000, 1, 100, 2500, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_90"), autoDissemination: true, 1, 9));
		_dataArray.Add(new SecretInformationItem(91, LocalStringManager.GetConfig("SecretInformation_language", "Name_91"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_91"), new sbyte[3] { 0, 0, 3 }, -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_91_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_91_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_91_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_91_3")
		}, new sbyte[13]
		{
			5, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 1, 0, 0, 0, 0, 0, autoBroadCast: false, 300, 1, 3, 1, 10, 6, ESecretInformationInitialTarget.Local, new int[1], new int[2] { 0, 1 }, new int[1], isGeneralRelationCharactersNeedSnapshot: true, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Negative, 89, 89, 91, 3113, 91, 5, 250, 10000, 1, 100, 1000, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_91"), autoDissemination: true, 1, 6));
		_dataArray.Add(new SecretInformationItem(92, LocalStringManager.GetConfig("SecretInformation_language", "Name_92"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_92"), new sbyte[3] { 0, 0, 3 }, -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_92_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_92_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_92_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_92_3")
		}, new sbyte[13]
		{
			6, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 1, 0, 0, 0, 0, 0, autoBroadCast: false, 500, 1, 3, 1, 10, 6, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: true, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Negative, 90, 90, 92, 3174, 92, 6, 500, 10000, 1, 100, 2500, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_92"), autoDissemination: true, 1, 7));
		_dataArray.Add(new SecretInformationItem(93, LocalStringManager.GetConfig("SecretInformation_language", "Name_93"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_93"), new sbyte[3] { 0, 0, 3 }, -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_93_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_93_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_93_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_93_3")
		}, new sbyte[13]
		{
			6, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 1, 0, 0, 0, 0, 0, autoBroadCast: false, 500, 1, 3, 1, 10, 6, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: true, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Negative, 91, 91, 93, 3235, 93, 6, 500, 10000, 1, 100, 2500, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_93"), autoDissemination: true, 1, 8));
		_dataArray.Add(new SecretInformationItem(94, LocalStringManager.GetConfig("SecretInformation_language", "Name_94"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_94"), new sbyte[3] { 0, 0, 3 }, -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_94_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_94_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_94_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_94_3")
		}, new sbyte[13]
		{
			6, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 1, 0, 0, 0, 0, 0, autoBroadCast: false, 500, 1, 3, 1, 10, 6, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: true, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Negative, 92, 92, 94, 3296, 94, 6, 500, 10000, 1, 100, 2500, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_94"), autoDissemination: true, 1, 9));
		_dataArray.Add(new SecretInformationItem(95, LocalStringManager.GetConfig("SecretInformation_language", "Name_95"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_95"), new sbyte[2], -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_95_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_95_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_95_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_95_3")
		}, new sbyte[13]
		{
			27, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 0, 0, 0, 0, 0, autoBroadCast: false, 1000, 1, 3, 2, 10, 12, ESecretInformationInitialTarget.Local, new int[1], new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: true, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Negative, 93, 93, 95, 76, 95, 9, 1000, 10000, 1, 100, 2500, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_95"), autoDissemination: true, 0, 0));
		_dataArray.Add(new SecretInformationItem(96, LocalStringManager.GetConfig("SecretInformation_language", "Name_96"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_96"), new sbyte[2], -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_96_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_96_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_96_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_96_3")
		}, new sbyte[13]
		{
			27, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 0, 0, 0, 0, 0, autoBroadCast: false, 1000, 1, 3, 2, 10, 12, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: true, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Negative, 94, 94, 96, 259, 96, 9, 1000, 10000, 1, 100, 2500, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_96"), autoDissemination: true, 6, 1));
		_dataArray.Add(new SecretInformationItem(97, LocalStringManager.GetConfig("SecretInformation_language", "Name_97"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_97"), new sbyte[2], -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_97_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_97_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_97_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_97_3")
		}, new sbyte[13]
		{
			8, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 0, 0, 0, 0, 0, autoBroadCast: false, 500, 1, 3, 1, 10, 6, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: true, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Negative, 95, 95, 97, 3357, 97, 8, 500, 10000, 1, 100, 2500, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_97"), autoDissemination: true, 1, 3));
		_dataArray.Add(new SecretInformationItem(98, LocalStringManager.GetConfig("SecretInformation_language", "Name_98"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_98"), new sbyte[2], -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_98_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_98_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_98_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_98_3")
		}, new sbyte[13]
		{
			8, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 0, 0, 0, 0, 0, autoBroadCast: false, 500, 1, 3, 1, 10, 6, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: true, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Negative, 96, 96, 98, 3418, 98, 8, 500, 10000, 1, 100, 2500, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_98"), autoDissemination: true, 1, 4));
		_dataArray.Add(new SecretInformationItem(99, LocalStringManager.GetConfig("SecretInformation_language", "Name_99"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_99"), new sbyte[3] { 0, 0, 5 }, -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_99_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_99_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_99_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_99_3")
		}, new sbyte[13]
		{
			6, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 0, 1, 0, 0, 0, autoBroadCast: false, 500, 1, 3, 1, 10, 6, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: true, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Negative, 97, 97, 99, 3479, 99, 6, 250, 10000, 1, 100, 1000, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_99"), autoDissemination: true, 2, 13));
		_dataArray.Add(new SecretInformationItem(100, LocalStringManager.GetConfig("SecretInformation_language", "Name_100"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_100"), new sbyte[3] { 0, 0, 5 }, -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_100_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_100_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_100_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_100_3")
		}, new sbyte[13]
		{
			6, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 0, 1, 0, 0, 0, autoBroadCast: false, 500, 1, 3, 1, 10, 6, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: true, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Negative, 98, 98, 100, 3479, 100, 6, 250, 10000, 1, 100, 1000, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_100"), autoDissemination: true, 2, 13));
		_dataArray.Add(new SecretInformationItem(101, LocalStringManager.GetConfig("SecretInformation_language", "Name_101"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_101"), new sbyte[3] { 0, 0, 4 }, -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_101_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_101_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_101_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_101_3")
		}, new sbyte[13]
		{
			6, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 1, 0, 0, 0, 0, autoBroadCast: false, 500, 1, 3, 1, 10, 6, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: true, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Negative, 99, 99, 101, 3479, 101, 6, 250, 10000, 1, 100, 1000, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_101"), autoDissemination: true, 2, 14));
		_dataArray.Add(new SecretInformationItem(102, LocalStringManager.GetConfig("SecretInformation_language", "Name_102"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_102"), new sbyte[3] { 0, 0, 4 }, -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_102_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_102_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_102_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_102_3")
		}, new sbyte[13]
		{
			6, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 1, 0, 0, 0, 0, autoBroadCast: false, 500, 1, 3, 1, 10, 6, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: true, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Negative, 100, 100, 102, 3479, 102, 6, 250, 10000, 1, 100, 1000, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_102"), autoDissemination: true, 2, 14));
		_dataArray.Add(new SecretInformationItem(103, LocalStringManager.GetConfig("SecretInformation_language", "Name_103"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_103"), new sbyte[3] { 0, 3, 3 }, -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_103_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_103_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_103_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_103_3")
		}, new sbyte[13]
		{
			3, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 1, 2, 0, 0, 0, 0, 0, autoBroadCast: false, 300, 1, 3, 1, 10, 6, ESecretInformationInitialTarget.Local, new int[1], new int[1], new int[1], isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Negative, 101, 101, 103, 3540, 103, 3, 10, 10000, 1, 3100, 1000, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_103"), autoDissemination: true, 1, 10));
		_dataArray.Add(new SecretInformationItem(104, LocalStringManager.GetConfig("SecretInformation_language", "Name_104"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_104"), new sbyte[2] { 0, 3 }, -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_104_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_104_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_104_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_104_3")
		}, new sbyte[13]
		{
			5, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 1, 1, 0, 0, 0, 0, 0, autoBroadCast: false, 300, 1, 3, 1, 10, 6, ESecretInformationInitialTarget.Local, new int[1], new int[1], new int[1], isGeneralRelationCharactersNeedSnapshot: true, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Negative, 102, 102, 104, 3559, 104, 5, 10, 10000, 1, 3100, 1000, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_104"), autoDissemination: true, 1, 11));
		_dataArray.Add(new SecretInformationItem(105, LocalStringManager.GetConfig("SecretInformation_language", "Name_105"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_105"), new sbyte[2], -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_105_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_105_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_105_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_105_3")
		}, new sbyte[13]
		{
			7, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 0, 0, 0, 0, 0, autoBroadCast: false, 500, 1, 3, 2, 10, 6, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: true, isRelationCharactersAliveStateNeedSnapshot: true, ESecretInformationValueType.Negative, 103, 103, 105, 1778, 105, 7, 1000, 10000, 1, 100, 2500, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_105"), autoDissemination: true, 3, 42));
		_dataArray.Add(new SecretInformationItem(106, LocalStringManager.GetConfig("SecretInformation_language", "Name_106"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_106"), new sbyte[2], -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_106_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_106_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_106_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_106_3")
		}, new sbyte[13]
		{
			27, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 0, 0, 0, 0, 0, autoBroadCast: false, 1000, 1, 3, 2, 10, 12, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: true, isRelationCharactersAliveStateNeedSnapshot: true, ESecretInformationValueType.Negative, 104, 104, 106, 1919, 106, 9, 1000, 10000, 1, 100, 2500, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_106"), autoDissemination: true, 1, 43));
		_dataArray.Add(new SecretInformationItem(107, LocalStringManager.GetConfig("SecretInformation_language", "Name_107"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_107"), new sbyte[3] { 0, 0, 1 }, 1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_107_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_107_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_107_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_107_3")
		}, new sbyte[13]
		{
			6, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 0, 0, 1, 0, 0, autoBroadCast: false, 500, 1, 3, 1, 10, 6, ESecretInformationInitialTarget.Local, new int[1], new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: true, isRelationCharactersAliveStateNeedSnapshot: true, ESecretInformationValueType.Negative, 17, 17, 19, 602, 107, 6, 200, 10000, 0, 300, 2500, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_107"), autoDissemination: true, 5, 48));
		_dataArray.Add(new SecretInformationItem(108, LocalStringManager.GetConfig("SecretInformation_language", "Name_108"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_108"), new sbyte[3], 2, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_108_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_108_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_108_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_108_3")
		}, new sbyte[13]
		{
			6, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 3, 0, 0, 0, 0, 0, 0, autoBroadCast: false, 500, 1, 3, 0, 10, 6, ESecretInformationInitialTarget.Local, new int[1], new int[3] { 0, 1, 2 }, new int[2] { 0, 2 }, isGeneralRelationCharactersNeedSnapshot: true, isRelationCharactersAliveStateNeedSnapshot: true, ESecretInformationValueType.Negative, 20, 20, 21, 884, 108, 6, 200, 10000, 0, 300, 2500, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_108"), autoDissemination: true, 5, 48));
		_dataArray.Add(new SecretInformationItem(109, LocalStringManager.GetConfig("SecretInformation_language", "Name_109"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_109"), new sbyte[3] { 0, 0, 1 }, -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_109_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_109_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_109_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_109_3")
		}, new sbyte[13]
		{
			4, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 0, 0, 1, 0, 0, autoBroadCast: false, 300, -1, 5, 0, 10, 6, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: true, ESecretInformationValueType.Positive, 105, 105, 109, 3578, 109, 4, 100, 10000, 5, 800, 2500, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_109"), autoDissemination: true, 3, 44));
		_dataArray.Add(new SecretInformationItem(110, LocalStringManager.GetConfig("SecretInformation_language", "Name_110"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_110"), new sbyte[2], -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_110_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_110_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_110_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_110_3")
		}, new sbyte[13]
		{
			6, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 0, 0, 0, 0, 0, autoBroadCast: false, 500, 1, 3, 1, 10, 6, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[1], new int[1], isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Negative, 106, 106, 110, 3590, 110, 6, 500, 10000, 1, 100, 2500, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_110"), autoDissemination: true, 2, 15));
		_dataArray.Add(new SecretInformationItem(111, LocalStringManager.GetConfig("SecretInformation_language", "Name_111"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_111"), new sbyte[2], -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_111_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_111_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_111_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_111_3")
		}, new sbyte[13]
		{
			6, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 0, 0, 0, 0, 0, autoBroadCast: false, 500, -1, 5, 0, 10, 6, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Positive, 107, 107, 111, 3651, 111, 6, 100, 10000, 5, 550, 2500, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_111"), autoDissemination: true, 9, 20));
		_dataArray.Add(new SecretInformationItem(112, LocalStringManager.GetConfig("SecretInformation_language", "Name_112"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_112"), new sbyte[1], -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_112_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_112_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_112_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_112_3")
		}, new sbyte[13]
		{
			27, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 1, 0, 0, 0, 0, 0, 0, autoBroadCast: false, 100, -1, 5, -3, 5, -1, ESecretInformationInitialTarget.None, new int[1], new int[0], new int[0], isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Normal, 108, 108, 112, 3712, 112, 1, 10000, 10000, 1, 25, -1, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_112"), autoDissemination: false, 9, -1));
		_dataArray.Add(new SecretInformationItem(113, LocalStringManager.GetConfig("SecretInformation_language", "Name_113"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_113"), new sbyte[1], -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_113_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_113_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_113_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_113_3")
		}, new sbyte[13]
		{
			27, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 1, 0, 0, 0, 0, 0, 0, autoBroadCast: false, 100, -1, 5, -3, 10, -1, ESecretInformationInitialTarget.None, new int[1], new int[0], new int[0], isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Normal, 109, 109, 113, 3713, 113, 1, 10000, 10000, 1, 25, -1, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_113"), autoDissemination: false, 9, -1));
		_dataArray.Add(new SecretInformationItem(114, LocalStringManager.GetConfig("SecretInformation_language", "Name_114"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_114"), new sbyte[1], -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_114_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_114_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_114_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_114_3")
		}, new sbyte[13]
		{
			27, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 1, 0, 0, 0, 0, 0, 0, autoBroadCast: false, 100, -1, 5, -3, 15, -1, ESecretInformationInitialTarget.None, new int[1], new int[0], new int[0], isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Normal, 110, 110, 114, 3714, 114, 1, 10000, 10000, 1, 25, -1, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_114"), autoDissemination: false, 9, -1));
		_dataArray.Add(new SecretInformationItem(115, LocalStringManager.GetConfig("SecretInformation_language", "Name_115"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_115"), new sbyte[1], -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_115_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_115_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_115_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_115_3")
		}, new sbyte[13]
		{
			27, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 1, 0, 0, 0, 0, 0, 0, autoBroadCast: false, 100, -1, 5, -3, 20, -1, ESecretInformationInitialTarget.None, new int[1], new int[0], new int[0], isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Normal, 111, 111, 115, 3715, 115, 1, 10000, 10000, 1, 25, -1, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_115"), autoDissemination: false, 9, -1));
		_dataArray.Add(new SecretInformationItem(116, LocalStringManager.GetConfig("SecretInformation_language", "Name_116"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_116"), new sbyte[2] { 0, 1 }, -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_116_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_116_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_116_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_116_3")
		}, new sbyte[13]
		{
			27, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 1, 0, 0, 0, 1, 0, 0, autoBroadCast: true, 0, -1, 5, -3, 10, 12, ESecretInformationInitialTarget.None, new int[1], new int[1], new int[1], isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Negative, 112, 112, 116, 3716, 116, 6, 250, 10000, 5, 300, 2500, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_116"), autoDissemination: true, 1, 5));
		_dataArray.Add(new SecretInformationItem(117, LocalStringManager.GetConfig("SecretInformation_language", "Name_117"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_117"), new sbyte[2], -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_117_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_117_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_117_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_117_3")
		}, new sbyte[13]
		{
			27, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 1, 0, 0, 0, 0, 0, 0, autoBroadCast: false, 100, 1, 3, 0, 10, 18, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: true, ESecretInformationValueType.Normal, 113, 113, 117, 3735, 117, 6, 10, 10000, 5, 12425, 2500, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_117"), autoDissemination: true, 5, 47));
		_dataArray.Add(new SecretInformationItem(118, LocalStringManager.GetConfig("SecretInformation_language", "Name_118"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_118"), new sbyte[2] { 0, 1 }, 1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_118_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_118_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_118_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_118_3")
		}, new sbyte[13]
		{
			27, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 0, 0, 0, 0, 0, autoBroadCast: false, 100, 1, 3, 0, 10, 18, ESecretInformationInitialTarget.Local, new int[1], new int[1], new int[1], isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: true, ESecretInformationValueType.Negative, 114, 114, 118, 3871, 118, 6, 10, 10000, 5, 12425, 2500, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_118"), autoDissemination: true, 5, 48));
		_dataArray.Add(new SecretInformationItem(119, LocalStringManager.GetConfig("SecretInformation_language", "Name_119"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_119"), new sbyte[2] { 0, 1 }, -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_119_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_119_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_119_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_119_3")
		}, new sbyte[13]
		{
			27, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 1, 0, 0, 0, 1, 0, 0, autoBroadCast: false, 100, 1, 3, -3, 10, 18, ESecretInformationInitialTarget.Area, new int[1], new int[1], new int[1], isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Negative, 115, 115, 119, 3912, 119, 6, 1000, 10000, 1, 100, 2500, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_119"), autoDissemination: true, 9, -1));
	}

	private void CreateItems2()
	{
		_dataArray.Add(new SecretInformationItem(120, LocalStringManager.GetConfig("SecretInformation_language", "Name_120"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_120"), new sbyte[2] { 0, 1 }, -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_120_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_120_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_120_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_120_3")
		}, new sbyte[13]
		{
			27, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 1, 0, 0, 0, 1, 0, 0, autoBroadCast: false, 100, 1, 3, -3, 10, 18, ESecretInformationInitialTarget.Area, new int[1], new int[1], new int[1], isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Negative, 116, 116, 120, 3927, 120, 6, 1000, 10000, 1, 100, 2500, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_120"), autoDissemination: true, 9, -1));
		_dataArray.Add(new SecretInformationItem(121, LocalStringManager.GetConfig("SecretInformation_language", "Name_121"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_121"), new sbyte[2] { 0, 1 }, -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_121_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_121_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_121_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_121_3")
		}, new sbyte[13]
		{
			27, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 1, 0, 0, 0, 1, 0, 0, autoBroadCast: false, 100, 1, 5, 0, 10, 6, ESecretInformationInitialTarget.Local, new int[1], new int[1], new int[1], isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Normal, 117, 117, 121, 3942, 121, 3, 100, 10000, 5, 550, 1000, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_121"), autoDissemination: true, 3, 40));
		_dataArray.Add(new SecretInformationItem(122, LocalStringManager.GetConfig("SecretInformation_language", "Name_122"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_122"), new sbyte[2], -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_122_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_122_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_122_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_122_3")
		}, new sbyte[13]
		{
			27, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 0, 0, 0, 0, 0, autoBroadCast: false, 200, 1, 3, 0, 10, 18, ESecretInformationInitialTarget.Local, new int[1], new int[1], new int[1], isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: true, ESecretInformationValueType.Negative, 118, 118, 122, 3957, 122, 5, 100, 10000, 5, 550, 1000, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_122"), autoDissemination: true, 3, 33));
		_dataArray.Add(new SecretInformationItem(123, LocalStringManager.GetConfig("SecretInformation_language", "Name_123"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_123"), new sbyte[2], -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_123_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_123_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_123_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_123_3")
		}, new sbyte[13]
		{
			27, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 0, 0, 0, 0, 0, autoBroadCast: false, 200, 1, 5, 0, 10, 6, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Positive, 119, 119, 123, 4098, 123, 6, 250, 10000, 1, 100, 1000, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_123"), autoDissemination: true, 3, 41));
		_dataArray.Add(new SecretInformationItem(124, LocalStringManager.GetConfig("SecretInformation_language", "Name_124"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_124"), new sbyte[2], -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_124_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_124_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_124_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_124_3")
		}, new sbyte[13]
		{
			27, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 0, 0, 0, 0, 0, autoBroadCast: false, 200, 1, 5, 0, 10, 6, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Positive, 120, 120, 124, 4159, 124, 6, 250, 10000, 1, 100, 1000, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_124"), autoDissemination: true, 3, 41));
		_dataArray.Add(new SecretInformationItem(125, LocalStringManager.GetConfig("SecretInformation_language", "Name_125"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_125"), new sbyte[2] { 0, 1 }, -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_125_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_125_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_125_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_125_3")
		}, new sbyte[13]
		{
			27, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 1, 0, 0, 0, 1, 0, 0, autoBroadCast: false, 0, 1, 5, 0, 10, 6, ESecretInformationInitialTarget.Local, new int[1], new int[1], new int[1], isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Positive, 121, 121, 125, 4220, 125, 6, 250, 10000, 1, 100, 1000, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_125"), autoDissemination: true, 2, 12));
		_dataArray.Add(new SecretInformationItem(126, LocalStringManager.GetConfig("SecretInformation_language", "Name_126"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_126"), new sbyte[2] { 0, 3 }, -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_126_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_126_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_126_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_126_3")
		}, new sbyte[13]
		{
			27, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 1, 1, 0, 0, 0, 0, 0, autoBroadCast: false, 300, 1, 5, -3, 10, 6, ESecretInformationInitialTarget.Area, new int[1], new int[1], new int[1], isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Normal, 122, 122, 126, 4235, 126, 9, 10000, 10000, 0, 0, 0, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_126"), autoDissemination: true, 9, -1));
		_dataArray.Add(new SecretInformationItem(127, LocalStringManager.GetConfig("SecretInformation_language", "Name_127"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_127"), new sbyte[2] { 0, 3 }, -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_127_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_127_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_127_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_127_3")
		}, new sbyte[13]
		{
			27, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 1, 0, 0, 0, 0, 0, autoBroadCast: false, 300, 1, 5, -3, 10, 6, ESecretInformationInitialTarget.Area, new int[1], new int[1], new int[1], isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Normal, 123, 123, 127, 4250, 127, 9, 10000, 10000, 0, 0, 0, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_127"), autoDissemination: true, 9, -1));
		_dataArray.Add(new SecretInformationItem(128, LocalStringManager.GetConfig("SecretInformation_language", "Name_128"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_128"), new sbyte[2], -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_128_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_128_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_128_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_128_3")
		}, new sbyte[13]
		{
			27, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 1, 0, 0, 0, 1, 0, 0, autoBroadCast: false, 50, 1, 5, -1, 10, 6, ESecretInformationInitialTarget.Local, new int[1], new int[1], new int[1], isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Normal, 124, 124, 128, 4265, 128, 1, 10, 10000, 5, 3050, 1000, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_128"), autoDissemination: true, 9, 28));
		_dataArray.Add(new SecretInformationItem(129, LocalStringManager.GetConfig("SecretInformation_language", "Name_129"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_129"), new sbyte[2] { 0, 1 }, -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_129_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_129_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_129_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_129_3")
		}, new sbyte[13]
		{
			27, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 1, 0, 0, 0, 1, 0, 0, autoBroadCast: false, 100, 1, 5, -1, 10, 6, ESecretInformationInitialTarget.Local, new int[1], new int[1], new int[1], isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Negative, 125, 125, 129, 4280, 129, 8, 500, 10000, 1, 100, 2500, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_129"), autoDissemination: true, 6, 52));
		_dataArray.Add(new SecretInformationItem(130, LocalStringManager.GetConfig("SecretInformation_language", "Name_130"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_130"), new sbyte[2] { 0, 1 }, -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_130_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_130_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_130_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_130_3")
		}, new sbyte[13]
		{
			27, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 1, 0, 0, 0, 1, 0, 0, autoBroadCast: false, 100, 1, 5, -1, 10, 6, ESecretInformationInitialTarget.Local, new int[1], new int[1], new int[1], isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Normal, 126, 126, 130, 4295, 130, 8, 500, 10000, 1, 100, 2500, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_130"), autoDissemination: true, 6, 53));
		_dataArray.Add(new SecretInformationItem(131, LocalStringManager.GetConfig("SecretInformation_language", "Name_131"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_131"), new sbyte[3], -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_131_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_131_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_131_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_131_3")
		}, new sbyte[13]
		{
			27, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 3, 0, 0, 0, 0, 0, 0, autoBroadCast: false, 200, 1, 5, -1, 10, 6, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Normal, 127, 127, 131, 4310, 131, 9, 100, 10000, 5, 550, 1000, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_131"), autoDissemination: true, 6, 54));
		_dataArray.Add(new SecretInformationItem(132, LocalStringManager.GetConfig("SecretInformation_language", "Name_132"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_132"), new sbyte[3], -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_132_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_132_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_132_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_132_3")
		}, new sbyte[13]
		{
			27, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 3, 0, 0, 0, 0, 0, 0, autoBroadCast: false, 200, 1, 5, -1, 10, 6, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Negative, 128, 128, 132, 4357, 132, 9, 100, 10000, 5, 550, 1000, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_132"), autoDissemination: true, 6, 54));
		_dataArray.Add(new SecretInformationItem(133, LocalStringManager.GetConfig("SecretInformation_language", "Name_133"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_133"), new sbyte[3], -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_133_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_133_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_133_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_133_3")
		}, new sbyte[13]
		{
			27, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 3, 0, 0, 0, 0, 0, 0, autoBroadCast: false, 200, 1, 5, -1, 10, 6, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Negative, 129, 129, 133, 4418, 133, 9, 100, 10000, 5, 550, 1000, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_133"), autoDissemination: true, 6, 54));
		_dataArray.Add(new SecretInformationItem(134, LocalStringManager.GetConfig("SecretInformation_language", "Name_134"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_134"), new sbyte[3], -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_134_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_134_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_134_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_134_3")
		}, new sbyte[13]
		{
			27, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 3, 0, 0, 0, 0, 0, 0, autoBroadCast: false, 200, 1, 5, -1, 10, 6, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Negative, 130, 130, 134, 4479, 134, 9, 100, 10000, 5, 550, 1000, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_134"), autoDissemination: true, 6, 54));
		_dataArray.Add(new SecretInformationItem(135, LocalStringManager.GetConfig("SecretInformation_language", "Name_135"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_135"), new sbyte[2], -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_135_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_135_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_135_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_135_3")
		}, new sbyte[13]
		{
			6, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 0, 0, 0, 0, 0, autoBroadCast: false, 500, -1, 5, 0, 10, 6, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Negative, 131, 131, 135, 4540, 135, 6, 10, 10000, 5, 3050, 2500, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_135"), autoDissemination: true, 3, 38));
		_dataArray.Add(new SecretInformationItem(136, LocalStringManager.GetConfig("SecretInformation_language", "Name_136"), LocalStringManager.GetConfig("SecretInformation_language", "Desc_136"), new sbyte[2], -1, new string[4]
		{
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_136_0"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_136_1"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_136_2"),
			LocalStringManager.GetConfig("SecretInformation_language", "ParametersUiName_136_3")
		}, new sbyte[13]
		{
			6, 1, 6, 22, 1, 3, 10, 0, 3, 11,
			1, 5, 15
		}, 2, 0, 0, 0, 0, 0, 0, autoBroadCast: false, 500, -1, 5, 0, 10, 6, ESecretInformationInitialTarget.Local, new int[2] { 0, 1 }, new int[2] { 0, 1 }, new int[2] { 0, 1 }, isGeneralRelationCharactersNeedSnapshot: false, isRelationCharactersAliveStateNeedSnapshot: false, ESecretInformationValueType.Negative, 132, 132, 136, 4601, 136, 6, 10, 10000, 5, 3050, 2500, LocalStringManager.GetConfig("SecretInformation_language", "BroadcastDesc_136"), autoDissemination: true, 3, 39));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<SecretInformationItem>(137);
		CreateItems0();
		CreateItems1();
		CreateItems2();
	}
}
