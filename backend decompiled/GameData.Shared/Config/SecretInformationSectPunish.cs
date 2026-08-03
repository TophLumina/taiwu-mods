using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class SecretInformationSectPunish : ConfigData<SecretInformationSectPunishItem, short>
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
		public static SecretInformationSectPunishItem Die => Instance[(short)0];

		/// <summary>
		/// 公开杀害
		/// </summary>
		public static SecretInformationSectPunishItem KillInPublic => Instance[(short)1];

		/// <summary>
		/// 公开关押
		/// </summary>
		public static SecretInformationSectPunishItem KidnapInPublic => Instance[(short)2];

		/// <summary>
		/// 惩戒杀害
		/// </summary>
		public static SecretInformationSectPunishItem KillForPunishment => Instance[(short)3];

		/// <summary>
		/// 惩戒关押
		/// </summary>
		public static SecretInformationSectPunishItem KidnapForPunishment => Instance[(short)4];

		/// <summary>
		/// 天降资源
		/// </summary>
		public static SecretInformationSectPunishItem UnexpectedResourceGain => Instance[(short)5];

		/// <summary>
		/// 天降财宝
		/// </summary>
		public static SecretInformationSectPunishItem UnexpectedItemGain => Instance[(short)6];

		/// <summary>
		/// 天赐秘籍
		/// </summary>
		public static SecretInformationSectPunishItem UnexpectedSkillBookGain => Instance[(short)7];

		/// <summary>
		/// 天助疗愈
		/// </summary>
		public static SecretInformationSectPunishItem UnexpectedCure => Instance[(short)8];

		/// <summary>
		/// 天损资源
		/// </summary>
		public static SecretInformationSectPunishItem UnexpectedResourceLose => Instance[(short)9];

		/// <summary>
		/// 天损财宝
		/// </summary>
		public static SecretInformationSectPunishItem UnexpectedItemLose => Instance[(short)10];

		/// <summary>
		/// 天损秘籍
		/// </summary>
		public static SecretInformationSectPunishItem UnexpectedSkillBookLose => Instance[(short)11];

		/// <summary>
		/// 天降灾刑
		/// </summary>
		public static SecretInformationSectPunishItem UnexpectedHarm => Instance[(short)12];

		/// <summary>
		/// 较艺胜利
		/// </summary>
		public static SecretInformationSectPunishItem LifeSkillBattleWin => Instance[(short)13];

		/// <summary>
		/// 促织战胜
		/// </summary>
		public static SecretInformationSectPunishItem CricketBattleWin => Instance[(short)14];

		/// <summary>
		/// 战斗大胜
		/// </summary>
		public static SecretInformationSectPunishItem MajorVictoryInCombat => Instance[(short)15];

		/// <summary>
		/// 战斗胜利
		/// </summary>
		public static SecretInformationSectPunishItem MinorVictoryInCombat => Instance[(short)16];

		/// <summary>
		/// 祭拜故人
		/// </summary>
		public static SecretInformationSectPunishItem Mourn => Instance[(short)17];

		/// <summary>
		/// 保护亲友
		/// </summary>
		public static SecretInformationSectPunishItem OfferProtection => Instance[(short)18];

		/// <summary>
		/// 痛失骨肉
		/// </summary>
		public static SecretInformationSectPunishItem LoseFetus => Instance[(short)19];

		/// <summary>
		/// 痛失骨肉2
		/// </summary>
		public static SecretInformationSectPunishItem LoseFetus2 => Instance[(short)20];

		/// <summary>
		/// 生下孩子
		/// </summary>
		public static SecretInformationSectPunishItem GiveBirthToChild => Instance[(short)21];

		/// <summary>
		/// 生下孩子2
		/// </summary>
		public static SecretInformationSectPunishItem GiveBirthToChild2 => Instance[(short)22];

		/// <summary>
		/// 遗弃孩子
		/// </summary>
		public static SecretInformationSectPunishItem AbandonChild => Instance[(short)23];

		/// <summary>
		/// 释放俘虏
		/// </summary>
		public static SecretInformationSectPunishItem ReleaseKidnappedCharacter => Instance[(short)24];

		/// <summary>
		/// 解救俘虏
		/// </summary>
		public static SecretInformationSectPunishItem RescueKidnappedCharacter => Instance[(short)25];

		/// <summary>
		/// 逃脱关押
		/// </summary>
		public static SecretInformationSectPunishItem KidnappedCharacterEscaped => Instance[(short)26];

		/// <summary>
		/// 研读失败
		/// </summary>
		public static SecretInformationSectPunishItem ReadBookFail => Instance[(short)27];

		/// <summary>
		/// 突破失败
		/// </summary>
		public static SecretInformationSectPunishItem BreakoutFail => Instance[(short)28];

		/// <summary>
		/// 遗失宝物
		/// </summary>
		public static SecretInformationSectPunishItem LoseOverloadingItem => Instance[(short)29];

		/// <summary>
		/// 化解仇怨
		/// </summary>
		public static SecretInformationSectPunishItem SeverEnemy => Instance[(short)30];

		/// <summary>
		/// 结下仇怨
		/// </summary>
		public static SecretInformationSectPunishItem BecomeEnemy => Instance[(short)31];

		/// <summary>
		/// 结为好友
		/// </summary>
		public static SecretInformationSectPunishItem BecomeFriend => Instance[(short)32];

		/// <summary>
		/// 断绝友谊
		/// </summary>
		public static SecretInformationSectPunishItem SeverFriend => Instance[(short)33];

		/// <summary>
		/// 两情相悦
		/// </summary>
		public static SecretInformationSectPunishItem BecomeLover => Instance[(short)34];

		/// <summary>
		/// 恋人分手
		/// </summary>
		public static SecretInformationSectPunishItem BreakupWithLover => Instance[(short)35];

		/// <summary>
		/// 共结连理
		/// </summary>
		public static SecretInformationSectPunishItem BecomeHusbandAndWife => Instance[(short)36];

		/// <summary>
		/// 义结金兰
		/// </summary>
		public static SecretInformationSectPunishItem BecomeSwornBrothersAndSisters => Instance[(short)37];

		/// <summary>
		/// 割袍断义
		/// </summary>
		public static SecretInformationSectPunishItem SeverSwornBrothersAndSisters => Instance[(short)38];

		/// <summary>
		/// 拜认义亲
		/// </summary>
		public static SecretInformationSectPunishItem GetAdopted => Instance[(short)39];

		/// <summary>
		/// 收养子女
		/// </summary>
		public static SecretInformationSectPunishItem AdoptChild => Instance[(short)40];

		/// <summary>
		/// 赠送资源
		/// </summary>
		public static SecretInformationSectPunishItem GivingResource => Instance[(short)41];

		/// <summary>
		/// 赠送道具
		/// </summary>
		public static SecretInformationSectPunishItem GiveItem => Instance[(short)42];

		/// <summary>
		/// 修建坟墓
		/// </summary>
		public static SecretInformationSectPunishItem BuildGrave => Instance[(short)43];

		/// <summary>
		/// 施医赠药
		/// </summary>
		public static SecretInformationSectPunishItem Cure => Instance[(short)44];

		/// <summary>
		/// 修补道具
		/// </summary>
		public static SecretInformationSectPunishItem RepairItem => Instance[(short)45];

		/// <summary>
		/// 指点技艺
		/// </summary>
		public static SecretInformationSectPunishItem InstructOnLifeSkill => Instance[(short)46];

		/// <summary>
		/// 指点武学
		/// </summary>
		public static SecretInformationSectPunishItem InstructOnCombatSkill => Instance[(short)47];

		/// <summary>
		/// 同意疗伤
		/// </summary>
		public static SecretInformationSectPunishItem AcceptRequestHealInjury => Instance[(short)48];

		/// <summary>
		/// 同意驱毒
		/// </summary>
		public static SecretInformationSectPunishItem AcceptRequestDetoxPoison => Instance[(short)49];

		/// <summary>
		/// 同意续命
		/// </summary>
		public static SecretInformationSectPunishItem AcceptRequestIncreaseHealth => Instance[(short)50];

		/// <summary>
		/// 同意调息
		/// </summary>
		public static SecretInformationSectPunishItem AcceptRequestRestoreDisorderOfQi => Instance[(short)51];

		/// <summary>
		/// 同意补内
		/// </summary>
		public static SecretInformationSectPunishItem AcceptRequestIncreaseNeili => Instance[(short)52];

		/// <summary>
		/// 同意灭蛊
		/// </summary>
		public static SecretInformationSectPunishItem AcceptRequestKillWug => Instance[(short)53];

		/// <summary>
		/// 同意乞食
		/// </summary>
		public static SecretInformationSectPunishItem AcceptRequestFood => Instance[(short)54];

		/// <summary>
		/// 同意茶酒
		/// </summary>
		public static SecretInformationSectPunishItem AcceptRequestTeaWine => Instance[(short)55];

		/// <summary>
		/// 同意资源
		/// </summary>
		public static SecretInformationSectPunishItem AcceptRequestResource => Instance[(short)56];

		/// <summary>
		/// 同意道具
		/// </summary>
		public static SecretInformationSectPunishItem AcceptRequestItem => Instance[(short)57];

		/// <summary>
		/// 同意对饮
		/// </summary>
		public static SecretInformationSectPunishItem AcceptRequestDrinking => Instance[(short)58];

		/// <summary>
		/// 同意施舍
		/// </summary>
		public static SecretInformationSectPunishItem AcceptRequestGivingMoney => Instance[(short)59];

		/// <summary>
		/// 同意研读
		/// </summary>
		public static SecretInformationSectPunishItem AcceptRequestInstructionOnReading => Instance[(short)60];

		/// <summary>
		/// 同意突破
		/// </summary>
		public static SecretInformationSectPunishItem AcceptRequestInstructionOnBreakout => Instance[(short)61];

		/// <summary>
		/// 同意修理
		/// </summary>
		public static SecretInformationSectPunishItem AcceptRequestRepairItem => Instance[(short)62];

		/// <summary>
		/// 同意淬毒
		/// </summary>
		public static SecretInformationSectPunishItem AcceptRequestAddPoisonToItem => Instance[(short)63];

		/// <summary>
		/// 同意技艺
		/// </summary>
		public static SecretInformationSectPunishItem AcceptRequestInstructionOnLifeSkill => Instance[(short)64];

		/// <summary>
		/// 同意武学
		/// </summary>
		public static SecretInformationSectPunishItem AcceptRequestInstructionOnCombatSkill => Instance[(short)65];

		/// <summary>
		/// 梳头成功
		/// </summary>
		public static SecretInformationSectPunishItem RehaircutSuccess => Instance[(short)66];

		/// <summary>
		/// 梳头失误
		/// </summary>
		public static SecretInformationSectPunishItem RehaircutIncompleted => Instance[(short)67];

		/// <summary>
		/// 梳头失败
		/// </summary>
		public static SecretInformationSectPunishItem RehaircutFail => Instance[(short)68];

		/// <summary>
		/// 拒绝疗伤
		/// </summary>
		public static SecretInformationSectPunishItem RefuseRequestHealInjury => Instance[(short)69];

		/// <summary>
		/// 拒绝驱毒
		/// </summary>
		public static SecretInformationSectPunishItem RefuseRequestDetoxPoison => Instance[(short)70];

		/// <summary>
		/// 拒绝续命
		/// </summary>
		public static SecretInformationSectPunishItem RefuseRequestIncreaseHealth => Instance[(short)71];

		/// <summary>
		/// 拒绝调息
		/// </summary>
		public static SecretInformationSectPunishItem RefuseRequestRestoreDisorderOfQi => Instance[(short)72];

		/// <summary>
		/// 拒绝补内
		/// </summary>
		public static SecretInformationSectPunishItem RefuseRequestIncreaseNeili => Instance[(short)73];

		/// <summary>
		/// 拒绝灭蛊
		/// </summary>
		public static SecretInformationSectPunishItem RefuseRequestKillWug => Instance[(short)74];

		/// <summary>
		/// 拒绝乞食
		/// </summary>
		public static SecretInformationSectPunishItem RefuseRequestFood => Instance[(short)75];

		/// <summary>
		/// 拒绝茶酒
		/// </summary>
		public static SecretInformationSectPunishItem RefuseRequestTeaWine => Instance[(short)76];

		/// <summary>
		/// 拒绝资源
		/// </summary>
		public static SecretInformationSectPunishItem RefuseRequestResource => Instance[(short)77];

		/// <summary>
		/// 拒绝道具
		/// </summary>
		public static SecretInformationSectPunishItem RefuseRequestItem => Instance[(short)78];

		/// <summary>
		/// 拒绝对饮
		/// </summary>
		public static SecretInformationSectPunishItem RefuseRequestDrinking => Instance[(short)79];

		/// <summary>
		/// 拒绝施舍
		/// </summary>
		public static SecretInformationSectPunishItem RefuseRequestGivingMoney => Instance[(short)80];

		/// <summary>
		/// 拒绝研读
		/// </summary>
		public static SecretInformationSectPunishItem RefuseRequestInstructionOnReading => Instance[(short)81];

		/// <summary>
		/// 拒绝突破
		/// </summary>
		public static SecretInformationSectPunishItem RefuseRequestInstructionOnBreakout => Instance[(short)82];

		/// <summary>
		/// 拒绝修理
		/// </summary>
		public static SecretInformationSectPunishItem RefuseRequestRepairItem => Instance[(short)83];

		/// <summary>
		/// 拒绝淬毒
		/// </summary>
		public static SecretInformationSectPunishItem RefuseRequestAddPoisonToItem => Instance[(short)84];

		/// <summary>
		/// 拒绝技艺
		/// </summary>
		public static SecretInformationSectPunishItem RefuseRequestInstructionOnLifeSkill => Instance[(short)85];

		/// <summary>
		/// 拒绝武学
		/// </summary>
		public static SecretInformationSectPunishItem RefuseRequestInstructionOnCombatSkill => Instance[(short)86];

		/// <summary>
		/// 盗掘资源
		/// </summary>
		public static SecretInformationSectPunishItem RobGraveResource => Instance[(short)87];

		/// <summary>
		/// 窃取资源
		/// </summary>
		public static SecretInformationSectPunishItem StealResource => Instance[(short)88];

		/// <summary>
		/// 骗取资源
		/// </summary>
		public static SecretInformationSectPunishItem ScamResource => Instance[(short)89];

		/// <summary>
		/// 夺取资源
		/// </summary>
		public static SecretInformationSectPunishItem RobResource => Instance[(short)90];

		/// <summary>
		/// 盗掘道具
		/// </summary>
		public static SecretInformationSectPunishItem RobGraveItem => Instance[(short)91];

		/// <summary>
		/// 窃取道具
		/// </summary>
		public static SecretInformationSectPunishItem StealItem => Instance[(short)92];

		/// <summary>
		/// 骗取道具
		/// </summary>
		public static SecretInformationSectPunishItem ScamItem => Instance[(short)93];

		/// <summary>
		/// 夺取道具
		/// </summary>
		public static SecretInformationSectPunishItem RobItem => Instance[(short)94];

		/// <summary>
		/// 秘密杀害
		/// </summary>
		public static SecretInformationSectPunishItem KillInPrivate => Instance[(short)95];

		/// <summary>
		/// 秘密关押
		/// </summary>
		public static SecretInformationSectPunishItem KidnapInPrivate => Instance[(short)96];

		/// <summary>
		/// 毒害他人
		/// </summary>
		public static SecretInformationSectPunishItem PoisonEnemy => Instance[(short)97];

		/// <summary>
		/// 损伤他人
		/// </summary>
		public static SecretInformationSectPunishItem PlotHarmEnemy => Instance[(short)98];

		/// <summary>
		/// 窃取技艺
		/// </summary>
		public static SecretInformationSectPunishItem StealLifeSkill => Instance[(short)99];

		/// <summary>
		/// 骗取技艺
		/// </summary>
		public static SecretInformationSectPunishItem ScamLifeSkill => Instance[(short)100];

		/// <summary>
		/// 窃取武学
		/// </summary>
		public static SecretInformationSectPunishItem StealCombatSkill => Instance[(short)101];

		/// <summary>
		/// 骗取武学
		/// </summary>
		public static SecretInformationSectPunishItem ScamCombatSkill => Instance[(short)102];

		/// <summary>
		/// 道具淬毒
		/// </summary>
		public static SecretInformationSectPunishItem AddPoisonToItem => Instance[(short)103];

		/// <summary>
		/// 饮食破戒
		/// </summary>
		public static SecretInformationSectPunishItem MonkBreakRule => Instance[(short)104];

		/// <summary>
		/// 非法春宵
		/// </summary>
		public static SecretInformationSectPunishItem MakeLoveIllegal => Instance[(short)105];

		/// <summary>
		/// 情难自禁
		/// </summary>
		public static SecretInformationSectPunishItem Rape => Instance[(short)106];

		/// <summary>
		/// 痛失骨肉父亲不可知
		/// </summary>
		public static SecretInformationSectPunishItem LoseFetusFatherUnknown => Instance[(short)107];

		/// <summary>
		/// 生下孩子父亲不可知
		/// </summary>
		public static SecretInformationSectPunishItem GiveBirthToChildFatherUnknown => Instance[(short)108];

		/// <summary>
		/// 与人约会
		/// </summary>
		public static SecretInformationSectPunishItem DatingWithCrush => Instance[(short)109];

		/// <summary>
		/// 迫使不语
		/// </summary>
		public static SecretInformationSectPunishItem ForcingSilence => Instance[(short)110];

		/// <summary>
		/// 寻回子女
		/// </summary>
		public static SecretInformationSectPunishItem RetrieveChild => Instance[(short)111];

		/// <summary>
		/// 解读经文1
		/// </summary>
		public static SecretInformationSectPunishItem SolveScripture1 => Instance[(short)112];

		/// <summary>
		/// 解读经文2
		/// </summary>
		public static SecretInformationSectPunishItem SolveScripture2 => Instance[(short)113];

		/// <summary>
		/// 解读经文3
		/// </summary>
		public static SecretInformationSectPunishItem SolveScripture3 => Instance[(short)114];

		/// <summary>
		/// 解读经文4
		/// </summary>
		public static SecretInformationSectPunishItem SolveScripture4 => Instance[(short)115];

		/// <summary>
		/// 公开越狱
		/// </summary>
		public static SecretInformationSectPunishItem PrisonBreak => Instance[(short)116];

		/// <summary>
		/// 身怀六甲
		/// </summary>
		public static SecretInformationSectPunishItem Pregnant => Instance[(short)117];

		/// <summary>
		/// 身怀六甲父亲未知
		/// </summary>
		public static SecretInformationSectPunishItem PregnantWithoutFather => Instance[(short)118];

		/// <summary>
		/// 人物入魔
		/// </summary>
		public static SecretInformationSectPunishItem XiangshuType0 => Instance[(short)119];

		/// <summary>
		/// 人物入邪
		/// </summary>
		public static SecretInformationSectPunishItem XiangshuType1 => Instance[(short)120];

		/// <summary>
		/// 人物出家
		/// </summary>
		public static SecretInformationSectPunishItem BecomeMonk => Instance[(short)121];

		/// <summary>
		/// 人物离婚
		/// </summary>
		public static SecretInformationSectPunishItem Divorce => Instance[(short)122];

		/// <summary>
		/// 拜为师父
		/// </summary>
		public static SecretInformationSectPunishItem BecomeMaster => Instance[(short)123];

		/// <summary>
		/// 收为徒弟
		/// </summary>
		public static SecretInformationSectPunishItem BecomeApprentice => Instance[(short)124];

		/// <summary>
		/// 加入门派
		/// </summary>
		public static SecretInformationSectPunishItem JoinOrganization => Instance[(short)125];

		/// <summary>
		/// 获得奇书
		/// </summary>
		public static SecretInformationSectPunishItem GainQiBook => Instance[(short)126];

		/// <summary>
		/// 丢失奇书
		/// </summary>
		public static SecretInformationSectPunishItem LostQiBook => Instance[(short)127];

		/// <summary>
		/// 乞讨银钱
		/// </summary>
		public static SecretInformationSectPunishItem BegMoney => Instance[(short)128];

		/// <summary>
		/// 人物入狱
		/// </summary>
		public static SecretInformationSectPunishItem Imprisoned => Instance[(short)129];

		/// <summary>
		/// 人物出狱
		/// </summary>
		public static SecretInformationSectPunishItem ReleasedPrison => Instance[(short)130];

		/// <summary>
		/// 求取俘虏
		/// </summary>
		public static SecretInformationSectPunishItem BegPrisoner => Instance[(short)131];

		/// <summary>
		/// 偷窃俘虏
		/// </summary>
		public static SecretInformationSectPunishItem StealPrisoner => Instance[(short)132];

		/// <summary>
		/// 唬骗俘虏
		/// </summary>
		public static SecretInformationSectPunishItem ScamPrisoner => Instance[(short)133];

		/// <summary>
		/// 夺取俘虏
		/// </summary>
		public static SecretInformationSectPunishItem RobPrisoner => Instance[(short)134];

		/// <summary>
		/// 断绝父母
		/// </summary>
		public static SecretInformationSectPunishItem SeverGetAdopted => Instance[(short)135];

		/// <summary>
		/// 断绝子女
		/// </summary>
		public static SecretInformationSectPunishItem SeverAdoptChild => Instance[(short)136];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static SecretInformationSectPunish Instance = new SecretInformationSectPunish();

	private readonly HashSet<string> RequiredFields = new HashSet<string>
	{
		"ActorSectPunishFreeCondition", "ActorSectPunishCondition", "ActorSectPunishBase", "ActorSectPunishSpecialCondition", "ActorSectPunishSpecial", "ReactorSectPunishFreeCondition", "ReactorSectPunishCondition", "ReactorSectPunishBase", "ReactorSectPunishSpecialCondition", "ReactorSectPunishSpecial",
		"SecactorSectPunishFreeCondition", "SecactorSectPunishCondition", "SecactorSectPunishBase", "SecactorSectPunishSpecialCondition", "SecactorSectPunishSpecial", "ActorCityPunishFreeCondition", "ActorCityPunishCondition", "ActorCityPunishBase", "ActorCityPunishSpecialCondition", "ActorCityPunishSpecial",
		"ReactorCityPunishFreeCondition", "ReactorCityPunishCondition", "ReactorCityPunishBase", "ReactorCityPunishSpecialCondition", "ReactorCityPunishSpecial", "SecactorCityPunishFreeCondition", "SecactorCityPunishCondition", "SecactorCityPunishBase", "SecactorCityPunishSpecialCondition", "SecactorCityPunishSpecial",
		"ActorTaiwuPunishFreeCondition", "ActorTaiwuPunishCondition", "ActorTaiwuPunishBase", "ActorTaiwuPunishSpecialCondition", "ActorTaiwuPunishSpecial", "ReactorTaiwuPunishFreeCondition", "ReactorTaiwuPunishCondition", "ReactorTaiwuPunishBase", "ReactorTaiwuPunishSpecialCondition", "ReactorTaiwuPunishSpecial",
		"SecactorTaiwuPunishFreeCondition", "SecactorTaiwuPunishCondition", "SecactorTaiwuPunishBase", "SecactorTaiwuPunishSpecialCondition", "SecactorTaiwuPunishSpecial", "TemplateId"
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
		_dataArray.Add(new SecretInformationSectPunishItem(0, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(1, new List<ShortList>
		{
			new ShortList(2, 0, 1)
		}, new List<ShortList>
		{
			new ShortList(56, 1),
			new ShortList(57, 1),
			new ShortList(58, 1)
		}, new List<ShortList>
		{
			new ShortList(1),
			new ShortList(2),
			new ShortList(3)
		}, new List<ShortList>
		{
			new ShortList(1, 0, 1)
		}, new List<ShortList>
		{
			new ShortList(154)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(56, 1),
			new ShortList(57, 1),
			new ShortList(58, 1)
		}, new List<ShortList>
		{
			new ShortList(1),
			new ShortList(2),
			new ShortList(3)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(56, 1),
			new ShortList(57, 1),
			new ShortList(58, 1)
		}, new List<ShortList>
		{
			new ShortList(1),
			new ShortList(2),
			new ShortList(3)
		}, new List<ShortList>
		{
			new ShortList(55, 1)
		}, new List<ShortList>
		{
			new ShortList(1),
			new ShortList(2),
			new ShortList(3)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(2, new List<ShortList>
		{
			new ShortList(2, 0, 1)
		}, new List<ShortList>
		{
			new ShortList(59, 1),
			new ShortList(60, 1),
			new ShortList(61, 1)
		}, new List<ShortList>
		{
			new ShortList(4),
			new ShortList(5),
			new ShortList(6)
		}, new List<ShortList>
		{
			new ShortList(1, 0, 1)
		}, new List<ShortList>
		{
			new ShortList(155)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(59, 1),
			new ShortList(60, 1),
			new ShortList(61, 1)
		}, new List<ShortList>
		{
			new ShortList(4),
			new ShortList(5),
			new ShortList(6)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(59, 1),
			new ShortList(60, 1),
			new ShortList(61, 1)
		}, new List<ShortList>
		{
			new ShortList(4),
			new ShortList(5),
			new ShortList(6)
		}, new List<ShortList>
		{
			new ShortList(55, 1)
		}, new List<ShortList>
		{
			new ShortList(4),
			new ShortList(5),
			new ShortList(6)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(3, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(4, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(5, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(6, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(7, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(8, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(9, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(10, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(11, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(12, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(13, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(14, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(15, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(16, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(17, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(18, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(19, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(77, 0),
			new ShortList(78, 0),
			new ShortList(79, 0)
		}, new List<ShortList>
		{
			new ShortList(44),
			new ShortList(45),
			new ShortList(46)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(77, 0),
			new ShortList(78, 0),
			new ShortList(79, 0)
		}, new List<ShortList>
		{
			new ShortList(44),
			new ShortList(45),
			new ShortList(46)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(20, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(77, 0),
			new ShortList(78, 0),
			new ShortList(79, 0)
		}, new List<ShortList>
		{
			new ShortList(44),
			new ShortList(45),
			new ShortList(46)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(77, 1),
			new ShortList(78, 1),
			new ShortList(79, 1)
		}, new List<ShortList>
		{
			new ShortList(44),
			new ShortList(45),
			new ShortList(46)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(77, 0),
			new ShortList(78, 0),
			new ShortList(79, 0)
		}, new List<ShortList>
		{
			new ShortList(44),
			new ShortList(45),
			new ShortList(46)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(77, 0),
			new ShortList(78, 0),
			new ShortList(79, 0)
		}, new List<ShortList>
		{
			new ShortList(44),
			new ShortList(45),
			new ShortList(46)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(21, new List<ShortList>
		{
			new ShortList(5)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(77, 0),
			new ShortList(78, 0),
			new ShortList(79, 0)
		}, new List<ShortList>
		{
			new ShortList(44),
			new ShortList(45),
			new ShortList(46)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(77, 0),
			new ShortList(78, 0),
			new ShortList(79, 0)
		}, new List<ShortList>
		{
			new ShortList(44),
			new ShortList(45),
			new ShortList(46)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(22, new List<ShortList>
		{
			new ShortList(5)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(77, 0),
			new ShortList(78, 0),
			new ShortList(79, 0)
		}, new List<ShortList>
		{
			new ShortList(44),
			new ShortList(45),
			new ShortList(46)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(5)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(77, 2),
			new ShortList(78, 2),
			new ShortList(79, 2)
		}, new List<ShortList>
		{
			new ShortList(44),
			new ShortList(45),
			new ShortList(46)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(77, 0),
			new ShortList(78, 0),
			new ShortList(79, 0)
		}, new List<ShortList>
		{
			new ShortList(44),
			new ShortList(45),
			new ShortList(46)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(77, 0),
			new ShortList(78, 0),
			new ShortList(79, 0)
		}, new List<ShortList>
		{
			new ShortList(44),
			new ShortList(45),
			new ShortList(46)
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(23, new List<ShortList>
		{
			new ShortList(5)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(77, 0),
			new ShortList(78, 0),
			new ShortList(79, 0)
		}, new List<ShortList>
		{
			new ShortList(44),
			new ShortList(45),
			new ShortList(46)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(77, 0),
			new ShortList(78, 0),
			new ShortList(79, 0)
		}, new List<ShortList>
		{
			new ShortList(44),
			new ShortList(45),
			new ShortList(46)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(24, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(25, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(26, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(27, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(28, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(29, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(30, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(31, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(32, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(62, 1),
			new ShortList(63, 1),
			new ShortList(64, 1),
			new ShortList(65, 1),
			new ShortList(66, 1),
			new ShortList(67, 1),
			new ShortList(68, 1),
			new ShortList(69, 1),
			new ShortList(70, 1),
			new ShortList(71, 1),
			new ShortList(72, 1),
			new ShortList(73, 1),
			new ShortList(74, 1),
			new ShortList(75, 1),
			new ShortList(76, 1)
		}, new List<ShortList>
		{
			new ShortList(24),
			new ShortList(25),
			new ShortList(26),
			new ShortList(27),
			new ShortList(28),
			new ShortList(29),
			new ShortList(30),
			new ShortList(31),
			new ShortList(32),
			new ShortList(33),
			new ShortList(34),
			new ShortList(35),
			new ShortList(36),
			new ShortList(37),
			new ShortList(38)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(62, 0),
			new ShortList(63, 0),
			new ShortList(64, 0),
			new ShortList(65, 0),
			new ShortList(66, 0),
			new ShortList(67, 0),
			new ShortList(68, 0),
			new ShortList(69, 0),
			new ShortList(70, 1),
			new ShortList(71, 1),
			new ShortList(72, 1),
			new ShortList(73, 1),
			new ShortList(74, 1),
			new ShortList(75, 1),
			new ShortList(76, 1)
		}, new List<ShortList>
		{
			new ShortList(24),
			new ShortList(25),
			new ShortList(26),
			new ShortList(27),
			new ShortList(28),
			new ShortList(29),
			new ShortList(30),
			new ShortList(31),
			new ShortList(32),
			new ShortList(33),
			new ShortList(34),
			new ShortList(35),
			new ShortList(36),
			new ShortList(37),
			new ShortList(38)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(33, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(34, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(80, 0),
			new ShortList(81, 0),
			new ShortList(82, 0),
			new ShortList(95, 1),
			new ShortList(96, 1),
			new ShortList(97, 1),
			new ShortList(98, 1),
			new ShortList(99, 1),
			new ShortList(100, 1),
			new ShortList(101, 1),
			new ShortList(102, 1),
			new ShortList(103, 1),
			new ShortList(104, 1),
			new ShortList(105, 1),
			new ShortList(106, 1),
			new ShortList(107, 1),
			new ShortList(108, 1),
			new ShortList(109, 1)
		}, new List<ShortList>
		{
			new ShortList(47),
			new ShortList(48),
			new ShortList(49),
			new ShortList(64),
			new ShortList(65),
			new ShortList(66),
			new ShortList(67),
			new ShortList(68),
			new ShortList(69),
			new ShortList(70),
			new ShortList(71),
			new ShortList(72),
			new ShortList(73),
			new ShortList(74),
			new ShortList(75),
			new ShortList(76),
			new ShortList(77),
			new ShortList(78)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(80, 1),
			new ShortList(81, 1),
			new ShortList(82, 1),
			new ShortList(95, 0),
			new ShortList(96, 0),
			new ShortList(97, 0),
			new ShortList(98, 0),
			new ShortList(99, 0),
			new ShortList(100, 0),
			new ShortList(101, 0),
			new ShortList(102, 0),
			new ShortList(103, 0),
			new ShortList(104, 0),
			new ShortList(105, 0),
			new ShortList(106, 0),
			new ShortList(107, 0),
			new ShortList(108, 0),
			new ShortList(109, 0)
		}, new List<ShortList>
		{
			new ShortList(47),
			new ShortList(48),
			new ShortList(49),
			new ShortList(64),
			new ShortList(65),
			new ShortList(66),
			new ShortList(67),
			new ShortList(68),
			new ShortList(69),
			new ShortList(70),
			new ShortList(71),
			new ShortList(72),
			new ShortList(73),
			new ShortList(74),
			new ShortList(75),
			new ShortList(76),
			new ShortList(77),
			new ShortList(78)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(80, 0),
			new ShortList(81, 0),
			new ShortList(82, 0),
			new ShortList(95, 1),
			new ShortList(96, 1),
			new ShortList(97, 1),
			new ShortList(98, 1),
			new ShortList(99, 1),
			new ShortList(100, 1),
			new ShortList(101, 1),
			new ShortList(102, 1),
			new ShortList(103, 1),
			new ShortList(104, 1),
			new ShortList(105, 1),
			new ShortList(106, 1),
			new ShortList(107, 1),
			new ShortList(108, 1),
			new ShortList(109, 1)
		}, new List<ShortList>
		{
			new ShortList(47),
			new ShortList(48),
			new ShortList(49),
			new ShortList(64),
			new ShortList(65),
			new ShortList(66),
			new ShortList(67),
			new ShortList(68),
			new ShortList(69),
			new ShortList(70),
			new ShortList(71),
			new ShortList(72),
			new ShortList(73),
			new ShortList(74),
			new ShortList(75),
			new ShortList(76),
			new ShortList(77),
			new ShortList(78)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(80, 0),
			new ShortList(81, 0),
			new ShortList(82, 0),
			new ShortList(95, 1),
			new ShortList(96, 1),
			new ShortList(97, 1),
			new ShortList(98, 1),
			new ShortList(99, 1),
			new ShortList(100, 1),
			new ShortList(101, 1),
			new ShortList(102, 1),
			new ShortList(103, 1),
			new ShortList(104, 1),
			new ShortList(105, 1),
			new ShortList(106, 1),
			new ShortList(107, 1),
			new ShortList(108, 1),
			new ShortList(109, 1)
		}, new List<ShortList>
		{
			new ShortList(47),
			new ShortList(48),
			new ShortList(49),
			new ShortList(64),
			new ShortList(65),
			new ShortList(66),
			new ShortList(67),
			new ShortList(68),
			new ShortList(69),
			new ShortList(70),
			new ShortList(71),
			new ShortList(72),
			new ShortList(73),
			new ShortList(74),
			new ShortList(75),
			new ShortList(76),
			new ShortList(77),
			new ShortList(78)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(35, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(36, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(83, 0),
			new ShortList(84, 0),
			new ShortList(85, 0)
		}, new List<ShortList>
		{
			new ShortList(50),
			new ShortList(51),
			new ShortList(52)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(83, 1),
			new ShortList(84, 1),
			new ShortList(85, 1)
		}, new List<ShortList>
		{
			new ShortList(50),
			new ShortList(51),
			new ShortList(52)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(110, 1),
			new ShortList(111, 1),
			new ShortList(112, 1),
			new ShortList(113, 1),
			new ShortList(114, 1),
			new ShortList(115, 1),
			new ShortList(116, 1),
			new ShortList(117, 1),
			new ShortList(118, 1),
			new ShortList(119, 1),
			new ShortList(120, 1),
			new ShortList(121, 1),
			new ShortList(122, 1),
			new ShortList(123, 1),
			new ShortList(124, 1)
		}, new List<ShortList>
		{
			new ShortList(79),
			new ShortList(80),
			new ShortList(81),
			new ShortList(82),
			new ShortList(83),
			new ShortList(84),
			new ShortList(85),
			new ShortList(86),
			new ShortList(87),
			new ShortList(88),
			new ShortList(89),
			new ShortList(90),
			new ShortList(91),
			new ShortList(92),
			new ShortList(93)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(110, 1),
			new ShortList(111, 1),
			new ShortList(112, 1),
			new ShortList(113, 1),
			new ShortList(114, 1),
			new ShortList(115, 1),
			new ShortList(116, 1),
			new ShortList(117, 1),
			new ShortList(118, 1),
			new ShortList(119, 1),
			new ShortList(120, 1),
			new ShortList(121, 1),
			new ShortList(122, 1),
			new ShortList(123, 1),
			new ShortList(124, 1)
		}, new List<ShortList>
		{
			new ShortList(79),
			new ShortList(80),
			new ShortList(81),
			new ShortList(82),
			new ShortList(83),
			new ShortList(84),
			new ShortList(85),
			new ShortList(86),
			new ShortList(87),
			new ShortList(88),
			new ShortList(89),
			new ShortList(90),
			new ShortList(91),
			new ShortList(92),
			new ShortList(93)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(37, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(110, 1),
			new ShortList(111, 1),
			new ShortList(112, 1),
			new ShortList(113, 1),
			new ShortList(114, 1),
			new ShortList(115, 1),
			new ShortList(116, 1),
			new ShortList(117, 1),
			new ShortList(118, 1),
			new ShortList(119, 1),
			new ShortList(120, 1),
			new ShortList(121, 1),
			new ShortList(122, 1),
			new ShortList(123, 1),
			new ShortList(124, 1)
		}, new List<ShortList>
		{
			new ShortList(79),
			new ShortList(80),
			new ShortList(81),
			new ShortList(82),
			new ShortList(83),
			new ShortList(84),
			new ShortList(85),
			new ShortList(86),
			new ShortList(87),
			new ShortList(88),
			new ShortList(89),
			new ShortList(90),
			new ShortList(91),
			new ShortList(92),
			new ShortList(93)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(110, 0),
			new ShortList(111, 0),
			new ShortList(112, 0),
			new ShortList(113, 0),
			new ShortList(114, 0),
			new ShortList(115, 0),
			new ShortList(116, 0),
			new ShortList(117, 0),
			new ShortList(118, 1),
			new ShortList(119, 1),
			new ShortList(120, 1),
			new ShortList(121, 1),
			new ShortList(122, 1),
			new ShortList(123, 1),
			new ShortList(124, 1)
		}, new List<ShortList>
		{
			new ShortList(79),
			new ShortList(80),
			new ShortList(81),
			new ShortList(82),
			new ShortList(83),
			new ShortList(84),
			new ShortList(85),
			new ShortList(86),
			new ShortList(87),
			new ShortList(88),
			new ShortList(89),
			new ShortList(90),
			new ShortList(91),
			new ShortList(92),
			new ShortList(93)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(38, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(39, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(125, 1),
			new ShortList(126, 1),
			new ShortList(127, 1),
			new ShortList(128, 1),
			new ShortList(129, 1),
			new ShortList(130, 1),
			new ShortList(131, 1),
			new ShortList(132, 1),
			new ShortList(133, 1),
			new ShortList(134, 1),
			new ShortList(135, 1),
			new ShortList(136, 1),
			new ShortList(137, 1),
			new ShortList(138, 1),
			new ShortList(139, 1)
		}, new List<ShortList>
		{
			new ShortList(94),
			new ShortList(95),
			new ShortList(96),
			new ShortList(97),
			new ShortList(98),
			new ShortList(99),
			new ShortList(100),
			new ShortList(101),
			new ShortList(102),
			new ShortList(103),
			new ShortList(104),
			new ShortList(105),
			new ShortList(106),
			new ShortList(107),
			new ShortList(108)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(40, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(140, 1),
			new ShortList(141, 1),
			new ShortList(142, 1),
			new ShortList(143, 1),
			new ShortList(144, 1),
			new ShortList(145, 1),
			new ShortList(146, 1),
			new ShortList(147, 1),
			new ShortList(148, 1),
			new ShortList(149, 1),
			new ShortList(150, 1),
			new ShortList(151, 1),
			new ShortList(152, 1),
			new ShortList(153, 1),
			new ShortList(154, 1)
		}, new List<ShortList>
		{
			new ShortList(109),
			new ShortList(110),
			new ShortList(111),
			new ShortList(112),
			new ShortList(113),
			new ShortList(114),
			new ShortList(115),
			new ShortList(116),
			new ShortList(117),
			new ShortList(118),
			new ShortList(119),
			new ShortList(120),
			new ShortList(121),
			new ShortList(122),
			new ShortList(123)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(41, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(42, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(43, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(44, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(45, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(46, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(47, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(48, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(49, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(50, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(51, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(52, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(53, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(54, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(55, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(56, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(57, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(58, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(59, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new SecretInformationSectPunishItem(60, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(61, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(62, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(63, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(64, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(65, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(66, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(67, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(68, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(69, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(70, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(71, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(72, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(73, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(74, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(75, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(76, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(77, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(78, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(79, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(80, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(81, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(82, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(83, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(84, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(85, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(86, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(87, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(10)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(10)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(10)
		}, new List<ShortList>
		{
			new ShortList(55, 1)
		}, new List<ShortList>
		{
			new ShortList(10)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(88, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(11)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(11)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(11)
		}, new List<ShortList>
		{
			new ShortList(55, 1)
		}, new List<ShortList>
		{
			new ShortList(11)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(89, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(12)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(12)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(12)
		}, new List<ShortList>
		{
			new ShortList(55, 1)
		}, new List<ShortList>
		{
			new ShortList(12)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(90, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(13)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(13)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(13)
		}, new List<ShortList>
		{
			new ShortList(55, 1)
		}, new List<ShortList>
		{
			new ShortList(13)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(91, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(10)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(10)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(10)
		}, new List<ShortList>
		{
			new ShortList(55, 1)
		}, new List<ShortList>
		{
			new ShortList(10)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(92, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(11)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(11)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(11)
		}, new List<ShortList>
		{
			new ShortList(55, 1)
		}, new List<ShortList>
		{
			new ShortList(11)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(93, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(12)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(12)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(12)
		}, new List<ShortList>
		{
			new ShortList(55, 1)
		}, new List<ShortList>
		{
			new ShortList(12)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(94, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(13)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(13)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(13)
		}, new List<ShortList>
		{
			new ShortList(55, 1)
		}, new List<ShortList>
		{
			new ShortList(13)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(95, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(22)
		}, new List<ShortList>
		{
			new ShortList(1, 0, 1)
		}, new List<ShortList>
		{
			new ShortList(156)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(22)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(22)
		}, new List<ShortList>
		{
			new ShortList(55, 1)
		}, new List<ShortList>
		{
			new ShortList(22)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(96, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(23)
		}, new List<ShortList>
		{
			new ShortList(1, 0, 1)
		}, new List<ShortList>
		{
			new ShortList(157)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(23)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(23)
		}, new List<ShortList>
		{
			new ShortList(55, 1)
		}, new List<ShortList>
		{
			new ShortList(23)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(97, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(14)
		}, new List<ShortList>
		{
			new ShortList(1, 0, 1)
		}, new List<ShortList>
		{
			new ShortList(16)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(14)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(14)
		}, new List<ShortList>
		{
			new ShortList(55, 1)
		}, new List<ShortList>
		{
			new ShortList(14)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(98, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(15)
		}, new List<ShortList>
		{
			new ShortList(1, 0, 1)
		}, new List<ShortList>
		{
			new ShortList(17)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(15)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(15)
		}, new List<ShortList>
		{
			new ShortList(55, 1)
		}, new List<ShortList>
		{
			new ShortList(15)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(99, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(158)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(158)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(158)
		}, new List<ShortList>
		{
			new ShortList(55, 1)
		}, new List<ShortList>
		{
			new ShortList(158)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(100, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(159)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(159)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(159)
		}, new List<ShortList>
		{
			new ShortList(55, 1)
		}, new List<ShortList>
		{
			new ShortList(159)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(101, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(160)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(160)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(160)
		}, new List<ShortList>
		{
			new ShortList(55, 1)
		}, new List<ShortList>
		{
			new ShortList(160)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(102, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(161)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(161)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(161)
		}, new List<ShortList>
		{
			new ShortList(55, 1)
		}, new List<ShortList>
		{
			new ShortList(161)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(103, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(19)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(104, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(185, 1),
			new ShortList(186, 1),
			new ShortList(187, 1)
		}, new List<ShortList>
		{
			new ShortList(162),
			new ShortList(163),
			new ShortList(164)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(105, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(62)
		}, new List<ShortList>
		{
			new ShortList(86, 0),
			new ShortList(87, 0),
			new ShortList(88, 0)
		}, new List<ShortList>
		{
			new ShortList(53),
			new ShortList(54),
			new ShortList(55)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(62)
		}, new List<ShortList>
		{
			new ShortList(86, 1),
			new ShortList(87, 1),
			new ShortList(88, 1)
		}, new List<ShortList>
		{
			new ShortList(53),
			new ShortList(54),
			new ShortList(55)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(86, 0),
			new ShortList(87, 0),
			new ShortList(88, 0)
		}, new List<ShortList>
		{
			new ShortList(53),
			new ShortList(54),
			new ShortList(55)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(86, 0),
			new ShortList(87, 0),
			new ShortList(88, 0)
		}, new List<ShortList>
		{
			new ShortList(53),
			new ShortList(54),
			new ShortList(55)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(106, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(63)
		}, new List<ShortList>
		{
			new ShortList(89, 0),
			new ShortList(90, 0),
			new ShortList(91, 0)
		}, new List<ShortList>
		{
			new ShortList(56),
			new ShortList(57),
			new ShortList(58)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(63)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(63)
		}, new List<ShortList>
		{
			new ShortList(89, 0),
			new ShortList(90, 0),
			new ShortList(91, 0)
		}, new List<ShortList>
		{
			new ShortList(56),
			new ShortList(57),
			new ShortList(58)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(107, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(77, 0),
			new ShortList(78, 0),
			new ShortList(79, 0)
		}, new List<ShortList>
		{
			new ShortList(44),
			new ShortList(45),
			new ShortList(46)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(108, new List<ShortList>
		{
			new ShortList(5)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(77, 0),
			new ShortList(78, 0),
			new ShortList(79, 0)
		}, new List<ShortList>
		{
			new ShortList(44),
			new ShortList(45),
			new ShortList(46)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(109, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(92, 0),
			new ShortList(93, 0),
			new ShortList(94, 0),
			new ShortList(155, 1),
			new ShortList(156, 1),
			new ShortList(157, 1),
			new ShortList(158, 1),
			new ShortList(159, 1),
			new ShortList(160, 1),
			new ShortList(161, 1),
			new ShortList(162, 1),
			new ShortList(163, 1),
			new ShortList(164, 1),
			new ShortList(165, 1),
			new ShortList(166, 1),
			new ShortList(167, 1),
			new ShortList(168, 1),
			new ShortList(169, 1)
		}, new List<ShortList>
		{
			new ShortList(59),
			new ShortList(60),
			new ShortList(61),
			new ShortList(124),
			new ShortList(125),
			new ShortList(126),
			new ShortList(127),
			new ShortList(128),
			new ShortList(129),
			new ShortList(130),
			new ShortList(131),
			new ShortList(132),
			new ShortList(133),
			new ShortList(134),
			new ShortList(135),
			new ShortList(136),
			new ShortList(137),
			new ShortList(138)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(92, 1),
			new ShortList(93, 1),
			new ShortList(94, 1),
			new ShortList(155, 0),
			new ShortList(156, 0),
			new ShortList(157, 0),
			new ShortList(158, 0),
			new ShortList(159, 0),
			new ShortList(160, 0),
			new ShortList(161, 0),
			new ShortList(162, 0),
			new ShortList(163, 0),
			new ShortList(164, 0),
			new ShortList(165, 0),
			new ShortList(166, 0),
			new ShortList(167, 0),
			new ShortList(168, 0),
			new ShortList(169, 0)
		}, new List<ShortList>
		{
			new ShortList(59),
			new ShortList(60),
			new ShortList(61),
			new ShortList(124),
			new ShortList(125),
			new ShortList(126),
			new ShortList(127),
			new ShortList(128),
			new ShortList(129),
			new ShortList(130),
			new ShortList(131),
			new ShortList(132),
			new ShortList(133),
			new ShortList(134),
			new ShortList(135),
			new ShortList(136),
			new ShortList(137),
			new ShortList(138)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(92, 0),
			new ShortList(93, 0),
			new ShortList(94, 0),
			new ShortList(155, 1),
			new ShortList(156, 1),
			new ShortList(157, 1),
			new ShortList(158, 1),
			new ShortList(159, 1),
			new ShortList(160, 1),
			new ShortList(161, 1),
			new ShortList(162, 1),
			new ShortList(163, 1),
			new ShortList(164, 1),
			new ShortList(165, 1),
			new ShortList(166, 1),
			new ShortList(167, 1),
			new ShortList(168, 1),
			new ShortList(169, 1)
		}, new List<ShortList>
		{
			new ShortList(59),
			new ShortList(60),
			new ShortList(61),
			new ShortList(124),
			new ShortList(125),
			new ShortList(126),
			new ShortList(127),
			new ShortList(128),
			new ShortList(129),
			new ShortList(130),
			new ShortList(131),
			new ShortList(132),
			new ShortList(133),
			new ShortList(134),
			new ShortList(135),
			new ShortList(136),
			new ShortList(137),
			new ShortList(138)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(92, 0),
			new ShortList(93, 0),
			new ShortList(94, 0),
			new ShortList(155, 1),
			new ShortList(156, 1),
			new ShortList(157, 1),
			new ShortList(158, 1),
			new ShortList(159, 1),
			new ShortList(160, 1),
			new ShortList(161, 1),
			new ShortList(162, 1),
			new ShortList(163, 1),
			new ShortList(164, 1),
			new ShortList(165, 1),
			new ShortList(166, 1),
			new ShortList(167, 1),
			new ShortList(168, 1),
			new ShortList(169, 1)
		}, new List<ShortList>
		{
			new ShortList(59),
			new ShortList(60),
			new ShortList(61),
			new ShortList(124),
			new ShortList(125),
			new ShortList(126),
			new ShortList(127),
			new ShortList(128),
			new ShortList(129),
			new ShortList(130),
			new ShortList(131),
			new ShortList(132),
			new ShortList(133),
			new ShortList(134),
			new ShortList(135),
			new ShortList(136),
			new ShortList(137),
			new ShortList(138)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(110, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(39)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(39)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(39)
		}, new List<ShortList>
		{
			new ShortList(55, 1)
		}, new List<ShortList>
		{
			new ShortList(39)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(111, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(170, 1),
			new ShortList(171, 1),
			new ShortList(172, 1),
			new ShortList(173, 1),
			new ShortList(174, 1),
			new ShortList(175, 1),
			new ShortList(176, 1),
			new ShortList(177, 1),
			new ShortList(178, 1),
			new ShortList(179, 1),
			new ShortList(180, 1),
			new ShortList(181, 1),
			new ShortList(182, 1),
			new ShortList(183, 1),
			new ShortList(184, 1)
		}, new List<ShortList>
		{
			new ShortList(139),
			new ShortList(140),
			new ShortList(141),
			new ShortList(142),
			new ShortList(143),
			new ShortList(144),
			new ShortList(145),
			new ShortList(146),
			new ShortList(147),
			new ShortList(148),
			new ShortList(149),
			new ShortList(150),
			new ShortList(151),
			new ShortList(152),
			new ShortList(153)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(112, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(113, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(114, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(115, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(116, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(41)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(41)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(default(short))
		}, new List<ShortList>
		{
			new ShortList(41)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(117, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(118, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(119, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
	}

	private void CreateItems2()
	{
		_dataArray.Add(new SecretInformationSectPunishItem(120, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(121, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(122, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(123, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(124, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(125, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(126, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(127, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(128, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(129, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(130, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(131, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(132, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(133, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(134, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(135, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
		_dataArray.Add(new SecretInformationSectPunishItem(136, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}, new List<ShortList>
		{
			new ShortList(-1)
		}, new List<ShortList>
		{
			new ShortList()
		}));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<SecretInformationSectPunishItem>(137);
		CreateItems0();
		CreateItems1();
		CreateItems2();
	}
}
