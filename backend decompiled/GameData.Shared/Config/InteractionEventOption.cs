using System;
using System.Collections.Generic;
using Config.Common;
using GameData.Domains.Character;

namespace Config;

[Serializable]
public class InteractionEventOption : ConfigData<InteractionEventOptionItem, short>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 交谈-见闻闲谈
		/// </summary>
		public const short TalkByNormalInformation = 0;

		/// <summary>
		/// 交谈-使用秘闻
		/// </summary>
		public const short TalkBySecretInformation = 1;

		/// <summary>
		/// 交谈-打探秘闻
		/// </summary>
		public const short AskForSecretInformation = 2;

		/// <summary>
		/// 交谈-赞颂夸奖
		/// </summary>
		public const short Praise = 3;

		/// <summary>
		/// 交谈-羞辱指责
		/// </summary>
		public const short Sneer = 4;

		/// <summary>
		/// 交谈-邀约聚会
		/// </summary>
		public const short Invitation = 5;

		/// <summary>
		/// 交谈-赠送礼物
		/// </summary>
		public const short SendGift = 6;

		/// <summary>
		/// 比试-促织决斗
		/// </summary>
		public const short CriketCombatInteract = 7;

		/// <summary>
		/// 比试-较艺比试
		/// </summary>
		public const short LifeSkillCombatInteract = 8;

		/// <summary>
		/// 比试-切磋武功
		/// </summary>
		public const short CombatInteract = 9;

		/// <summary>
		/// 比试-发起挑战
		/// </summary>
		public const short CombatInteractChallenge = 10;

		/// <summary>
		/// 修习-请教技艺1
		/// </summary>
		public const short ConsultLifeSkill1 = 11;

		/// <summary>
		/// 修习-请教技艺2
		/// </summary>
		public const short ConsultLifeSkill2 = 12;

		/// <summary>
		/// 修习-请教技艺3
		/// </summary>
		public const short ConsultLifeSkill3 = 13;

		/// <summary>
		/// 修习-请教功法1
		/// </summary>
		public const short ConsultCombatSkill1 = 14;

		/// <summary>
		/// 修习-请教功法2
		/// </summary>
		public const short ConsultCombatSkill2 = 15;

		/// <summary>
		/// 修习-请教功法3
		/// </summary>
		public const short ConsultCombatSkill3 = 16;

		/// <summary>
		/// 修习-偷师技艺
		/// </summary>
		public const short StealLifeSkill = 17;

		/// <summary>
		/// 修习-偷师功法
		/// </summary>
		public const short StealCombatSkill = 18;

		/// <summary>
		/// 修习-唬骗技艺
		/// </summary>
		public const short ScamLifeSkill = 19;

		/// <summary>
		/// 修习-唬骗功法
		/// </summary>
		public const short ScamCombatSkill = 20;

		/// <summary>
		/// 修习-交换藏书
		/// </summary>
		public const short ExchangeSkillBook = 21;

		/// <summary>
		/// 亲近-邀为同道1
		/// </summary>
		public const short AskForTeammate1 = 22;

		/// <summary>
		/// 亲近-邀为同道2
		/// </summary>
		public const short AskForTeammate2 = 23;

		/// <summary>
		/// 亲近-邀请回村
		/// </summary>
		public const short AskForTaiwuVillager = 24;

		/// <summary>
		/// 亲近-获取支持
		/// </summary>
		public const short AskForSupport = 25;

		/// <summary>
		/// 亲近-拜为义父
		/// </summary>
		public const short BecomeAdoptiveFather = 26;

		/// <summary>
		/// 亲近-拜为义母
		/// </summary>
		public const short BecomeAdoptiveMother = 27;

		/// <summary>
		/// 亲近-收为义子
		/// </summary>
		public const short BecomeAdoptiveSon = 28;

		/// <summary>
		/// 亲近-收为义女
		/// </summary>
		public const short BecomeAdoptiveDaughter = 29;

		/// <summary>
		/// 亲近-知心而交
		/// </summary>
		public const short BecomeFriend = 30;

		/// <summary>
		/// 亲近-倾述爱意
		/// </summary>
		public const short BecomeLover = 31;

		/// <summary>
		/// 亲近-共结连理1
		/// </summary>
		public const short BecomeCouple1 = 32;

		/// <summary>
		/// 亲近-共结连理2
		/// </summary>
		public const short BecomeCouple2 = 33;

		/// <summary>
		/// 亲近-背恩绝情
		/// </summary>
		public const short BreakUp = 34;

		/// <summary>
		/// 亲近-义结金兰
		/// </summary>
		public const short BecomeSwornFriend = 35;

		/// <summary>
		/// 亲近-割袍断义
		/// </summary>
		public const short SeverFriendship = 36;

		/// <summary>
		/// 亲近-推朋荐友
		/// </summary>
		public const short RecommendFriend = 37;

		/// <summary>
		/// 亲近-挑拨离间
		/// </summary>
		public const short RecommendEnemy = 38;

		/// <summary>
		/// 亲近-调停恩怨
		/// </summary>
		public const short PersuadeResentment = 39;

		/// <summary>
		/// 亲近-男媒女妁
		/// </summary>
		public const short Matchmaker = 40;

		/// <summary>
		/// 敌对-唬骗道具
		/// </summary>
		public const short ScamItem = 41;

		/// <summary>
		/// 敌对-唬骗见闻
		/// </summary>
		public const short ScamNormalInformation = 42;

		/// <summary>
		/// 敌对-唬骗秘闻
		/// </summary>
		public const short ScamSecretInformation = 43;

		/// <summary>
		/// 敌对-窃取道具
		/// </summary>
		public const short StealItem = 44;

		/// <summary>
		/// 敌对-夺取道具
		/// </summary>
		public const short RobItem = 45;

		/// <summary>
		/// 敌对-施以毒害
		/// </summary>
		public const short Poison = 46;

		/// <summary>
		/// 敌对-暗中损伤
		/// </summary>
		public const short Damage = 47;

		/// <summary>
		/// 敌对-出手袭击
		/// </summary>
		public const short Attack = 48;

		/// <summary>
		/// 奇书-发起挑战
		/// </summary>
		public const short LegendaryBookChallenge = 49;

		/// <summary>
		/// 奇书-斩妖除魔
		/// </summary>
		public const short LegendaryBookKillXiangshu = 50;

		/// <summary>
		/// 奇书-诚恳求取
		/// </summary>
		public const short LegendaryBookBeg = 51;

		/// <summary>
		/// 奇书-提出交换
		/// </summary>
		public const short LegendaryBookExchange = 52;

		/// <summary>
		/// 互动-收养元鸡
		/// </summary>
		public const short IdentityAdoptChicken = 53;

		/// <summary>
		/// 互动-举办招亲
		/// </summary>
		public const short IdentityMatchmaker = 54;

		/// <summary>
		/// 互动-茶酒会友
		/// </summary>
		public const short IdentityWineTeaAndFriend = 55;

		/// <summary>
		/// 互动-城镇集会
		/// </summary>
		public const short HoldTownMarket = 56;

		/// <summary>
		/// 互动-浏览货物
		/// </summary>
		public const short IdentityBrowseGoods = 57;

		/// <summary>
		/// 互动-疗伤驱毒
		/// </summary>
		public const short IdentityDoctorHeal = 58;

		/// <summary>
		/// 互动-修补物品
		/// </summary>
		public const short IdentityRepairMan = 59;

		/// <summary>
		/// 互动-采买鲜果
		/// </summary>
		public const short IdentityFarmer = 141;

		/// <summary>
		/// 互动-梳头修面
		/// </summary>
		public const short IdentityHairCutter = 60;

		/// <summary>
		/// 互动-施舍银钱
		/// </summary>
		public const short IdentityMoneyCharity = 61;

		/// <summary>
		/// 互动-荐送弟子
		/// </summary>
		public const short IntimateInteractionRecommendPupil = 62;

		/// <summary>
		/// 互动-求取弟子
		/// </summary>
		public const short IntimateInteractionDemandPupil = 63;

		/// <summary>
		/// 互动-面壁阅经
		/// </summary>
		public const short SpiritualDebtInteractionShaolin = 64;

		/// <summary>
		/// 互动-天府规略
		/// </summary>
		public const short SpiritualDebtInteractionEmei = 65;

		/// <summary>
		/// 互动-起死回生
		/// </summary>
		public const short SpiritualDebtInteractionBaihua = 66;

		/// <summary>
		/// 互动-七星调元
		/// </summary>
		public const short SpiritualDebtInteractionWudang = 67;

		/// <summary>
		/// 互动-石牢静坐
		/// </summary>
		public const short SpiritualDebtInteractionYuanshan = 68;

		/// <summary>
		/// 互动-散播威名
		/// </summary>
		public const short SpiritualDebtInteractionShixiang = 69;

		/// <summary>
		/// 互动-王禅典籍
		/// </summary>
		public const short SpiritualDebtInteractionRanshan = 70;

		/// <summary>
		/// 互动-玉镜沉思
		/// </summary>
		public const short SpiritualDebtInteractionXuannv = 71;

		/// <summary>
		/// 互动-欧冶古具
		/// </summary>
		public const short SpiritualDebtInteractionZhujian = 72;

		/// <summary>
		/// 互动-铸剑试炼
		/// </summary>
		public const short SpiritualDebtInteractionZhujian2 = 73;

		/// <summary>
		/// 互动-秘药延寿
		/// </summary>
		public const short SpiritualDebtInteractionKongsang = 74;

		/// <summary>
		/// 互动-搜集贡品
		/// </summary>
		public const short SpiritualDebtInteractionJingang = 75;

		/// <summary>
		/// 互动-五圣秘浴
		/// </summary>
		public const short SpiritualDebtInteractionWuxian = 76;

		/// <summary>
		/// 互动-委托暗杀
		/// </summary>
		public const short SpiritualDebtInteractionJieqing = 77;

		/// <summary>
		/// 互动-龙岛忠仆
		/// </summary>
		public const short SpiritualDebtInteractionFulong = 78;

		/// <summary>
		/// 互动-血池秘法
		/// </summary>
		public const short SpiritualDebtInteractionXuehou = 79;

		/// <summary>
		/// 互动-州府条例
		/// </summary>
		public const short CityPunishmentSeverityCustomize = 80;

		/// <summary>
		/// 互动-重金诊疗
		/// </summary>
		public const short DoctorExpensiveHeal = 81;

		/// <summary>
		/// 互动-看诊施药
		/// </summary>
		public const short ProfessionDoctorSkill0 = 82;

		/// <summary>
		/// 互动-金针渡命
		/// </summary>
		public const short ProfessionDoctorSkill3 = 83;

		/// <summary>
		/// 互动-封侯拜相
		/// </summary>
		public const short ProfessionDukeSkill1 = 84;

		/// <summary>
		/// 互动-评水品茗
		/// </summary>
		public const short ProfessionTeaTasterSkill0 = 85;

		/// <summary>
		/// 互动-慧眼识珠
		/// </summary>
		public const short ProfessionCapitalistSkill0 = 86;

		/// <summary>
		/// 互动-占卜吉凶
		/// </summary>
		public const short ProfessionTravelingTaoistMonkSkill1 = 87;

		/// <summary>
		/// 互动-易天改命
		/// </summary>
		public const short ProfessionTravelingTaoistMonkSkill2 = 88;

		/// <summary>
		/// 互动-导恶向善
		/// </summary>
		public const short ProfessionTravelingBuddhistMonkSkill1 = 89;

		/// <summary>
		/// 互动-退隐江湖
		/// </summary>
		public const short ProfessionCivilianSkill2 = 90;

		/// <summary>
		/// 互动-扶助保荐
		/// </summary>
		public const short ProfessionAristocratSkill0 = 91;

		/// <summary>
		/// 互动-拼豪斗酒
		/// </summary>
		public const short ProfessionWineTasterSkill0 = 92;

		/// <summary>
		/// 互动-传法度人
		/// </summary>
		public const short ProfessionBuddhistMonkSkill1 = 93;

		/// <summary>
		/// 互动-驱邪法事
		/// </summary>
		public const short ProfessionTaoistMonkSkill1 = 94;

		/// <summary>
		/// 互动-代笔改名
		/// </summary>
		public const short ProfessionLiteratiSkill0 = 95;

		/// <summary>
		/// 特殊-武林大会
		/// </summary>
		public const short Wulin = 96;

		/// <summary>
		/// 特殊-归还雕像
		/// </summary>
		public const short ShaolinStatueReturn = 97;

		/// <summary>
		/// 特殊-塔林崩塌
		/// </summary>
		public const short ShaolinCollapse = 98;

		/// <summary>
		/// 特殊-狮相谣言
		/// </summary>
		public const short ShixiangRumour = 99;

		/// <summary>
		/// 特殊-狮相闹剧
		/// </summary>
		public const short Shixiangnaoju = 100;

		/// <summary>
		/// 特殊-峨眉凶案
		/// </summary>
		public const short EMeiMurder = 101;

		/// <summary>
		/// 特殊-隐居长老
		/// </summary>
		public const short EMeiElder = 102;

		/// <summary>
		/// 特殊-正宗之忧
		/// </summary>
		public const short EMeiAuthentic = 103;

		/// <summary>
		/// 特殊-送还婴儿
		/// </summary>
		public const short ReturnInfant = 104;

		/// <summary>
		/// 特殊-杀人夺心
		/// </summary>
		public const short BaihuaInteract1 = 105;

		/// <summary>
		/// 特殊-毁人神智
		/// </summary>
		public const short BaihuaInteract2 = 106;

		/// <summary>
		/// 特殊-打听神秘人之事-城镇人物
		/// </summary>
		public const short XuannuInteract1 = 107;

		/// <summary>
		/// 特殊-打听神秘人之事-璇女门派人物
		/// </summary>
		public const short XuannuInteract2 = 108;

		/// <summary>
		/// 特殊-询问《孤鸾镜水谣》
		/// </summary>
		public const short XuannuInteract3 = 109;

		/// <summary>
		/// 特殊-论及“情”字
		/// </summary>
		public const short XuannuInteract4 = 110;

		/// <summary>
		/// 俘虏互动-劝说
		/// </summary>
		public const short PersuadePrisoner = 111;

		/// <summary>
		/// 坟墓互动祭拜逝者1
		/// </summary>
		public const short MourningTomb1 = 112;

		/// <summary>
		/// 坟墓互动祭拜逝者2
		/// </summary>
		public const short MourningTomb2 = 113;

		/// <summary>
		/// 坟墓互动祭拜逝者3
		/// </summary>
		public const short MourningTomb3 = 114;

		/// <summary>
		/// 坟墓互动祭拜逝者4
		/// </summary>
		public const short MourningTomb4 = 115;

		/// <summary>
		/// 坟墓互动修葺坟墓1
		/// </summary>
		public const short UpgradingTomb1 = 116;

		/// <summary>
		/// 坟墓互动修葺坟墓2
		/// </summary>
		public const short UpgradingTomb2 = 117;

		/// <summary>
		/// 坟墓互动修葺坟墓3
		/// </summary>
		public const short UpgradingTomb3 = 118;

		/// <summary>
		/// 坟墓互动摸金倒斗
		/// </summary>
		public const short StealingTomb = 119;

		/// <summary>
		/// 特殊-解蛊之法
		/// </summary>
		public const short WuxianInteract1 = 120;

		/// <summary>
		/// 特殊-下蛊之事
		/// </summary>
		public const short WuxianInteract2 = 121;

		/// <summary>
		/// 敌对-捉拿罪犯
		/// </summary>
		public const short ArrestPrison = 122;

		/// <summary>
		/// 互动-索要囚犯
		/// </summary>
		public const short AskForPrison = 123;

		/// <summary>
		/// 互动-真龙降世
		/// </summary>
		public const short SectMainStoryFulong1 = 124;

		/// <summary>
		/// 互动-神龙降世
		/// </summary>
		public const short LongDlc = 125;

		/// <summary>
		/// 互动-志向经验
		/// </summary>
		public const short AskForProfessionExp = 126;

		/// <summary>
		/// 交谈-打探见闻
		/// </summary>
		public const short AskForInformation = 127;

		/// <summary>
		/// 互动-推恩施义
		/// </summary>
		public const short ExtendFavor = 128;

		/// <summary>
		/// 互动-牵线搭桥
		/// </summary>
		public const short MakeLineAndBridge = 129;

		/// <summary>
		/// 互动-安定文化
		/// </summary>
		public const short SafetyAndCulture = 130;

		/// <summary>
		/// 互动-诗画怡情
		/// </summary>
		public const short PoemAndImage = 131;

		/// <summary>
		/// 互动-商会赞誉
		/// </summary>
		public const short MerchantPraise = 132;

		/// <summary>
		/// 互动-调理土地
		/// </summary>
		public const short FixLandResource = 133;

		/// <summary>
		/// 互动-市井百态
		/// </summary>
		public const short TalkChangeBehaType = 134;

		/// <summary>
		/// 互动-兑换工具
		/// </summary>
		public const short GiveExchangeTool = 135;

		/// <summary>
		/// 互动-剥夺星运
		/// </summary>
		public const short TakeStarFortune = 136;

		/// <summary>
		/// 互动-开悟天资
		/// </summary>
		public const short InsightfulTalent = 137;

		/// <summary>
		/// 互动-开悟入魔
		/// </summary>
		public const short Infected = 138;

		/// <summary>
		/// 互动-为NPC梳头修面
		/// </summary>
		public const short HairCutterForNPC = 139;

		/// <summary>
		/// 互动-打听秘闻
		/// </summary>
		public const short IdentityBuySecrets = 142;

		/// <summary>
		/// 互动-玄石火灰
		/// </summary>
		public const short FuyuFaith = 140;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 交谈-见闻闲谈
		/// </summary>
		public static InteractionEventOptionItem TalkByNormalInformation => Instance[(short)0];

		/// <summary>
		/// 交谈-使用秘闻
		/// </summary>
		public static InteractionEventOptionItem TalkBySecretInformation => Instance[(short)1];

		/// <summary>
		/// 交谈-打探秘闻
		/// </summary>
		public static InteractionEventOptionItem AskForSecretInformation => Instance[(short)2];

		/// <summary>
		/// 交谈-赞颂夸奖
		/// </summary>
		public static InteractionEventOptionItem Praise => Instance[(short)3];

		/// <summary>
		/// 交谈-羞辱指责
		/// </summary>
		public static InteractionEventOptionItem Sneer => Instance[(short)4];

		/// <summary>
		/// 交谈-邀约聚会
		/// </summary>
		public static InteractionEventOptionItem Invitation => Instance[(short)5];

		/// <summary>
		/// 交谈-赠送礼物
		/// </summary>
		public static InteractionEventOptionItem SendGift => Instance[(short)6];

		/// <summary>
		/// 比试-促织决斗
		/// </summary>
		public static InteractionEventOptionItem CriketCombatInteract => Instance[(short)7];

		/// <summary>
		/// 比试-较艺比试
		/// </summary>
		public static InteractionEventOptionItem LifeSkillCombatInteract => Instance[(short)8];

		/// <summary>
		/// 比试-切磋武功
		/// </summary>
		public static InteractionEventOptionItem CombatInteract => Instance[(short)9];

		/// <summary>
		/// 比试-发起挑战
		/// </summary>
		public static InteractionEventOptionItem CombatInteractChallenge => Instance[(short)10];

		/// <summary>
		/// 修习-请教技艺1
		/// </summary>
		public static InteractionEventOptionItem ConsultLifeSkill1 => Instance[(short)11];

		/// <summary>
		/// 修习-请教技艺2
		/// </summary>
		public static InteractionEventOptionItem ConsultLifeSkill2 => Instance[(short)12];

		/// <summary>
		/// 修习-请教技艺3
		/// </summary>
		public static InteractionEventOptionItem ConsultLifeSkill3 => Instance[(short)13];

		/// <summary>
		/// 修习-请教功法1
		/// </summary>
		public static InteractionEventOptionItem ConsultCombatSkill1 => Instance[(short)14];

		/// <summary>
		/// 修习-请教功法2
		/// </summary>
		public static InteractionEventOptionItem ConsultCombatSkill2 => Instance[(short)15];

		/// <summary>
		/// 修习-请教功法3
		/// </summary>
		public static InteractionEventOptionItem ConsultCombatSkill3 => Instance[(short)16];

		/// <summary>
		/// 修习-偷师技艺
		/// </summary>
		public static InteractionEventOptionItem StealLifeSkill => Instance[(short)17];

		/// <summary>
		/// 修习-偷师功法
		/// </summary>
		public static InteractionEventOptionItem StealCombatSkill => Instance[(short)18];

		/// <summary>
		/// 修习-唬骗技艺
		/// </summary>
		public static InteractionEventOptionItem ScamLifeSkill => Instance[(short)19];

		/// <summary>
		/// 修习-唬骗功法
		/// </summary>
		public static InteractionEventOptionItem ScamCombatSkill => Instance[(short)20];

		/// <summary>
		/// 修习-交换藏书
		/// </summary>
		public static InteractionEventOptionItem ExchangeSkillBook => Instance[(short)21];

		/// <summary>
		/// 亲近-邀为同道1
		/// </summary>
		public static InteractionEventOptionItem AskForTeammate1 => Instance[(short)22];

		/// <summary>
		/// 亲近-邀为同道2
		/// </summary>
		public static InteractionEventOptionItem AskForTeammate2 => Instance[(short)23];

		/// <summary>
		/// 亲近-邀请回村
		/// </summary>
		public static InteractionEventOptionItem AskForTaiwuVillager => Instance[(short)24];

		/// <summary>
		/// 亲近-获取支持
		/// </summary>
		public static InteractionEventOptionItem AskForSupport => Instance[(short)25];

		/// <summary>
		/// 亲近-拜为义父
		/// </summary>
		public static InteractionEventOptionItem BecomeAdoptiveFather => Instance[(short)26];

		/// <summary>
		/// 亲近-拜为义母
		/// </summary>
		public static InteractionEventOptionItem BecomeAdoptiveMother => Instance[(short)27];

		/// <summary>
		/// 亲近-收为义子
		/// </summary>
		public static InteractionEventOptionItem BecomeAdoptiveSon => Instance[(short)28];

		/// <summary>
		/// 亲近-收为义女
		/// </summary>
		public static InteractionEventOptionItem BecomeAdoptiveDaughter => Instance[(short)29];

		/// <summary>
		/// 亲近-知心而交
		/// </summary>
		public static InteractionEventOptionItem BecomeFriend => Instance[(short)30];

		/// <summary>
		/// 亲近-倾述爱意
		/// </summary>
		public static InteractionEventOptionItem BecomeLover => Instance[(short)31];

		/// <summary>
		/// 亲近-共结连理1
		/// </summary>
		public static InteractionEventOptionItem BecomeCouple1 => Instance[(short)32];

		/// <summary>
		/// 亲近-共结连理2
		/// </summary>
		public static InteractionEventOptionItem BecomeCouple2 => Instance[(short)33];

		/// <summary>
		/// 亲近-背恩绝情
		/// </summary>
		public static InteractionEventOptionItem BreakUp => Instance[(short)34];

		/// <summary>
		/// 亲近-义结金兰
		/// </summary>
		public static InteractionEventOptionItem BecomeSwornFriend => Instance[(short)35];

		/// <summary>
		/// 亲近-割袍断义
		/// </summary>
		public static InteractionEventOptionItem SeverFriendship => Instance[(short)36];

		/// <summary>
		/// 亲近-推朋荐友
		/// </summary>
		public static InteractionEventOptionItem RecommendFriend => Instance[(short)37];

		/// <summary>
		/// 亲近-挑拨离间
		/// </summary>
		public static InteractionEventOptionItem RecommendEnemy => Instance[(short)38];

		/// <summary>
		/// 亲近-调停恩怨
		/// </summary>
		public static InteractionEventOptionItem PersuadeResentment => Instance[(short)39];

		/// <summary>
		/// 亲近-男媒女妁
		/// </summary>
		public static InteractionEventOptionItem Matchmaker => Instance[(short)40];

		/// <summary>
		/// 敌对-唬骗道具
		/// </summary>
		public static InteractionEventOptionItem ScamItem => Instance[(short)41];

		/// <summary>
		/// 敌对-唬骗见闻
		/// </summary>
		public static InteractionEventOptionItem ScamNormalInformation => Instance[(short)42];

		/// <summary>
		/// 敌对-唬骗秘闻
		/// </summary>
		public static InteractionEventOptionItem ScamSecretInformation => Instance[(short)43];

		/// <summary>
		/// 敌对-窃取道具
		/// </summary>
		public static InteractionEventOptionItem StealItem => Instance[(short)44];

		/// <summary>
		/// 敌对-夺取道具
		/// </summary>
		public static InteractionEventOptionItem RobItem => Instance[(short)45];

		/// <summary>
		/// 敌对-施以毒害
		/// </summary>
		public static InteractionEventOptionItem Poison => Instance[(short)46];

		/// <summary>
		/// 敌对-暗中损伤
		/// </summary>
		public static InteractionEventOptionItem Damage => Instance[(short)47];

		/// <summary>
		/// 敌对-出手袭击
		/// </summary>
		public static InteractionEventOptionItem Attack => Instance[(short)48];

		/// <summary>
		/// 奇书-发起挑战
		/// </summary>
		public static InteractionEventOptionItem LegendaryBookChallenge => Instance[(short)49];

		/// <summary>
		/// 奇书-斩妖除魔
		/// </summary>
		public static InteractionEventOptionItem LegendaryBookKillXiangshu => Instance[(short)50];

		/// <summary>
		/// 奇书-诚恳求取
		/// </summary>
		public static InteractionEventOptionItem LegendaryBookBeg => Instance[(short)51];

		/// <summary>
		/// 奇书-提出交换
		/// </summary>
		public static InteractionEventOptionItem LegendaryBookExchange => Instance[(short)52];

		/// <summary>
		/// 互动-收养元鸡
		/// </summary>
		public static InteractionEventOptionItem IdentityAdoptChicken => Instance[(short)53];

		/// <summary>
		/// 互动-举办招亲
		/// </summary>
		public static InteractionEventOptionItem IdentityMatchmaker => Instance[(short)54];

		/// <summary>
		/// 互动-茶酒会友
		/// </summary>
		public static InteractionEventOptionItem IdentityWineTeaAndFriend => Instance[(short)55];

		/// <summary>
		/// 互动-城镇集会
		/// </summary>
		public static InteractionEventOptionItem HoldTownMarket => Instance[(short)56];

		/// <summary>
		/// 互动-浏览货物
		/// </summary>
		public static InteractionEventOptionItem IdentityBrowseGoods => Instance[(short)57];

		/// <summary>
		/// 互动-疗伤驱毒
		/// </summary>
		public static InteractionEventOptionItem IdentityDoctorHeal => Instance[(short)58];

		/// <summary>
		/// 互动-修补物品
		/// </summary>
		public static InteractionEventOptionItem IdentityRepairMan => Instance[(short)59];

		/// <summary>
		/// 互动-采买鲜果
		/// </summary>
		public static InteractionEventOptionItem IdentityFarmer => Instance[(short)141];

		/// <summary>
		/// 互动-梳头修面
		/// </summary>
		public static InteractionEventOptionItem IdentityHairCutter => Instance[(short)60];

		/// <summary>
		/// 互动-施舍银钱
		/// </summary>
		public static InteractionEventOptionItem IdentityMoneyCharity => Instance[(short)61];

		/// <summary>
		/// 互动-荐送弟子
		/// </summary>
		public static InteractionEventOptionItem IntimateInteractionRecommendPupil => Instance[(short)62];

		/// <summary>
		/// 互动-求取弟子
		/// </summary>
		public static InteractionEventOptionItem IntimateInteractionDemandPupil => Instance[(short)63];

		/// <summary>
		/// 互动-面壁阅经
		/// </summary>
		public static InteractionEventOptionItem SpiritualDebtInteractionShaolin => Instance[(short)64];

		/// <summary>
		/// 互动-天府规略
		/// </summary>
		public static InteractionEventOptionItem SpiritualDebtInteractionEmei => Instance[(short)65];

		/// <summary>
		/// 互动-起死回生
		/// </summary>
		public static InteractionEventOptionItem SpiritualDebtInteractionBaihua => Instance[(short)66];

		/// <summary>
		/// 互动-七星调元
		/// </summary>
		public static InteractionEventOptionItem SpiritualDebtInteractionWudang => Instance[(short)67];

		/// <summary>
		/// 互动-石牢静坐
		/// </summary>
		public static InteractionEventOptionItem SpiritualDebtInteractionYuanshan => Instance[(short)68];

		/// <summary>
		/// 互动-散播威名
		/// </summary>
		public static InteractionEventOptionItem SpiritualDebtInteractionShixiang => Instance[(short)69];

		/// <summary>
		/// 互动-王禅典籍
		/// </summary>
		public static InteractionEventOptionItem SpiritualDebtInteractionRanshan => Instance[(short)70];

		/// <summary>
		/// 互动-玉镜沉思
		/// </summary>
		public static InteractionEventOptionItem SpiritualDebtInteractionXuannv => Instance[(short)71];

		/// <summary>
		/// 互动-欧冶古具
		/// </summary>
		public static InteractionEventOptionItem SpiritualDebtInteractionZhujian => Instance[(short)72];

		/// <summary>
		/// 互动-铸剑试炼
		/// </summary>
		public static InteractionEventOptionItem SpiritualDebtInteractionZhujian2 => Instance[(short)73];

		/// <summary>
		/// 互动-秘药延寿
		/// </summary>
		public static InteractionEventOptionItem SpiritualDebtInteractionKongsang => Instance[(short)74];

		/// <summary>
		/// 互动-搜集贡品
		/// </summary>
		public static InteractionEventOptionItem SpiritualDebtInteractionJingang => Instance[(short)75];

		/// <summary>
		/// 互动-五圣秘浴
		/// </summary>
		public static InteractionEventOptionItem SpiritualDebtInteractionWuxian => Instance[(short)76];

		/// <summary>
		/// 互动-委托暗杀
		/// </summary>
		public static InteractionEventOptionItem SpiritualDebtInteractionJieqing => Instance[(short)77];

		/// <summary>
		/// 互动-龙岛忠仆
		/// </summary>
		public static InteractionEventOptionItem SpiritualDebtInteractionFulong => Instance[(short)78];

		/// <summary>
		/// 互动-血池秘法
		/// </summary>
		public static InteractionEventOptionItem SpiritualDebtInteractionXuehou => Instance[(short)79];

		/// <summary>
		/// 互动-州府条例
		/// </summary>
		public static InteractionEventOptionItem CityPunishmentSeverityCustomize => Instance[(short)80];

		/// <summary>
		/// 互动-重金诊疗
		/// </summary>
		public static InteractionEventOptionItem DoctorExpensiveHeal => Instance[(short)81];

		/// <summary>
		/// 互动-看诊施药
		/// </summary>
		public static InteractionEventOptionItem ProfessionDoctorSkill0 => Instance[(short)82];

		/// <summary>
		/// 互动-金针渡命
		/// </summary>
		public static InteractionEventOptionItem ProfessionDoctorSkill3 => Instance[(short)83];

		/// <summary>
		/// 互动-封侯拜相
		/// </summary>
		public static InteractionEventOptionItem ProfessionDukeSkill1 => Instance[(short)84];

		/// <summary>
		/// 互动-评水品茗
		/// </summary>
		public static InteractionEventOptionItem ProfessionTeaTasterSkill0 => Instance[(short)85];

		/// <summary>
		/// 互动-慧眼识珠
		/// </summary>
		public static InteractionEventOptionItem ProfessionCapitalistSkill0 => Instance[(short)86];

		/// <summary>
		/// 互动-占卜吉凶
		/// </summary>
		public static InteractionEventOptionItem ProfessionTravelingTaoistMonkSkill1 => Instance[(short)87];

		/// <summary>
		/// 互动-易天改命
		/// </summary>
		public static InteractionEventOptionItem ProfessionTravelingTaoistMonkSkill2 => Instance[(short)88];

		/// <summary>
		/// 互动-导恶向善
		/// </summary>
		public static InteractionEventOptionItem ProfessionTravelingBuddhistMonkSkill1 => Instance[(short)89];

		/// <summary>
		/// 互动-退隐江湖
		/// </summary>
		public static InteractionEventOptionItem ProfessionCivilianSkill2 => Instance[(short)90];

		/// <summary>
		/// 互动-扶助保荐
		/// </summary>
		public static InteractionEventOptionItem ProfessionAristocratSkill0 => Instance[(short)91];

		/// <summary>
		/// 互动-拼豪斗酒
		/// </summary>
		public static InteractionEventOptionItem ProfessionWineTasterSkill0 => Instance[(short)92];

		/// <summary>
		/// 互动-传法度人
		/// </summary>
		public static InteractionEventOptionItem ProfessionBuddhistMonkSkill1 => Instance[(short)93];

		/// <summary>
		/// 互动-驱邪法事
		/// </summary>
		public static InteractionEventOptionItem ProfessionTaoistMonkSkill1 => Instance[(short)94];

		/// <summary>
		/// 互动-代笔改名
		/// </summary>
		public static InteractionEventOptionItem ProfessionLiteratiSkill0 => Instance[(short)95];

		/// <summary>
		/// 特殊-武林大会
		/// </summary>
		public static InteractionEventOptionItem Wulin => Instance[(short)96];

		/// <summary>
		/// 特殊-归还雕像
		/// </summary>
		public static InteractionEventOptionItem ShaolinStatueReturn => Instance[(short)97];

		/// <summary>
		/// 特殊-塔林崩塌
		/// </summary>
		public static InteractionEventOptionItem ShaolinCollapse => Instance[(short)98];

		/// <summary>
		/// 特殊-狮相谣言
		/// </summary>
		public static InteractionEventOptionItem ShixiangRumour => Instance[(short)99];

		/// <summary>
		/// 特殊-狮相闹剧
		/// </summary>
		public static InteractionEventOptionItem Shixiangnaoju => Instance[(short)100];

		/// <summary>
		/// 特殊-峨眉凶案
		/// </summary>
		public static InteractionEventOptionItem EMeiMurder => Instance[(short)101];

		/// <summary>
		/// 特殊-隐居长老
		/// </summary>
		public static InteractionEventOptionItem EMeiElder => Instance[(short)102];

		/// <summary>
		/// 特殊-正宗之忧
		/// </summary>
		public static InteractionEventOptionItem EMeiAuthentic => Instance[(short)103];

		/// <summary>
		/// 特殊-送还婴儿
		/// </summary>
		public static InteractionEventOptionItem ReturnInfant => Instance[(short)104];

		/// <summary>
		/// 特殊-杀人夺心
		/// </summary>
		public static InteractionEventOptionItem BaihuaInteract1 => Instance[(short)105];

		/// <summary>
		/// 特殊-毁人神智
		/// </summary>
		public static InteractionEventOptionItem BaihuaInteract2 => Instance[(short)106];

		/// <summary>
		/// 特殊-打听神秘人之事-城镇人物
		/// </summary>
		public static InteractionEventOptionItem XuannuInteract1 => Instance[(short)107];

		/// <summary>
		/// 特殊-打听神秘人之事-璇女门派人物
		/// </summary>
		public static InteractionEventOptionItem XuannuInteract2 => Instance[(short)108];

		/// <summary>
		/// 特殊-询问《孤鸾镜水谣》
		/// </summary>
		public static InteractionEventOptionItem XuannuInteract3 => Instance[(short)109];

		/// <summary>
		/// 特殊-论及“情”字
		/// </summary>
		public static InteractionEventOptionItem XuannuInteract4 => Instance[(short)110];

		/// <summary>
		/// 俘虏互动-劝说
		/// </summary>
		public static InteractionEventOptionItem PersuadePrisoner => Instance[(short)111];

		/// <summary>
		/// 坟墓互动祭拜逝者1
		/// </summary>
		public static InteractionEventOptionItem MourningTomb1 => Instance[(short)112];

		/// <summary>
		/// 坟墓互动祭拜逝者2
		/// </summary>
		public static InteractionEventOptionItem MourningTomb2 => Instance[(short)113];

		/// <summary>
		/// 坟墓互动祭拜逝者3
		/// </summary>
		public static InteractionEventOptionItem MourningTomb3 => Instance[(short)114];

		/// <summary>
		/// 坟墓互动祭拜逝者4
		/// </summary>
		public static InteractionEventOptionItem MourningTomb4 => Instance[(short)115];

		/// <summary>
		/// 坟墓互动修葺坟墓1
		/// </summary>
		public static InteractionEventOptionItem UpgradingTomb1 => Instance[(short)116];

		/// <summary>
		/// 坟墓互动修葺坟墓2
		/// </summary>
		public static InteractionEventOptionItem UpgradingTomb2 => Instance[(short)117];

		/// <summary>
		/// 坟墓互动修葺坟墓3
		/// </summary>
		public static InteractionEventOptionItem UpgradingTomb3 => Instance[(short)118];

		/// <summary>
		/// 坟墓互动摸金倒斗
		/// </summary>
		public static InteractionEventOptionItem StealingTomb => Instance[(short)119];

		/// <summary>
		/// 特殊-解蛊之法
		/// </summary>
		public static InteractionEventOptionItem WuxianInteract1 => Instance[(short)120];

		/// <summary>
		/// 特殊-下蛊之事
		/// </summary>
		public static InteractionEventOptionItem WuxianInteract2 => Instance[(short)121];

		/// <summary>
		/// 敌对-捉拿罪犯
		/// </summary>
		public static InteractionEventOptionItem ArrestPrison => Instance[(short)122];

		/// <summary>
		/// 互动-索要囚犯
		/// </summary>
		public static InteractionEventOptionItem AskForPrison => Instance[(short)123];

		/// <summary>
		/// 互动-真龙降世
		/// </summary>
		public static InteractionEventOptionItem SectMainStoryFulong1 => Instance[(short)124];

		/// <summary>
		/// 互动-神龙降世
		/// </summary>
		public static InteractionEventOptionItem LongDlc => Instance[(short)125];

		/// <summary>
		/// 互动-志向经验
		/// </summary>
		public static InteractionEventOptionItem AskForProfessionExp => Instance[(short)126];

		/// <summary>
		/// 交谈-打探见闻
		/// </summary>
		public static InteractionEventOptionItem AskForInformation => Instance[(short)127];

		/// <summary>
		/// 互动-推恩施义
		/// </summary>
		public static InteractionEventOptionItem ExtendFavor => Instance[(short)128];

		/// <summary>
		/// 互动-牵线搭桥
		/// </summary>
		public static InteractionEventOptionItem MakeLineAndBridge => Instance[(short)129];

		/// <summary>
		/// 互动-安定文化
		/// </summary>
		public static InteractionEventOptionItem SafetyAndCulture => Instance[(short)130];

		/// <summary>
		/// 互动-诗画怡情
		/// </summary>
		public static InteractionEventOptionItem PoemAndImage => Instance[(short)131];

		/// <summary>
		/// 互动-商会赞誉
		/// </summary>
		public static InteractionEventOptionItem MerchantPraise => Instance[(short)132];

		/// <summary>
		/// 互动-调理土地
		/// </summary>
		public static InteractionEventOptionItem FixLandResource => Instance[(short)133];

		/// <summary>
		/// 互动-市井百态
		/// </summary>
		public static InteractionEventOptionItem TalkChangeBehaType => Instance[(short)134];

		/// <summary>
		/// 互动-兑换工具
		/// </summary>
		public static InteractionEventOptionItem GiveExchangeTool => Instance[(short)135];

		/// <summary>
		/// 互动-剥夺星运
		/// </summary>
		public static InteractionEventOptionItem TakeStarFortune => Instance[(short)136];

		/// <summary>
		/// 互动-开悟天资
		/// </summary>
		public static InteractionEventOptionItem InsightfulTalent => Instance[(short)137];

		/// <summary>
		/// 互动-开悟入魔
		/// </summary>
		public static InteractionEventOptionItem Infected => Instance[(short)138];

		/// <summary>
		/// 互动-为NPC梳头修面
		/// </summary>
		public static InteractionEventOptionItem HairCutterForNPC => Instance[(short)139];

		/// <summary>
		/// 互动-打听秘闻
		/// </summary>
		public static InteractionEventOptionItem IdentityBuySecrets => Instance[(short)142];

		/// <summary>
		/// 互动-玄石火灰
		/// </summary>
		public static InteractionEventOptionItem FuyuFaith => Instance[(short)140];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static InteractionEventOption Instance = new InteractionEventOption();

	private readonly HashSet<string> RequiredFields = new HashSet<string>
	{
		"MutexGroupId", "Name", "BehaviorType", "TaiwuBehaviorType", "ProfessionSkill", "AfterMainStoryLineProgress", "BeforeMainStoryLineProgress", "DuringTask", "OrganizationIdentity", "Organization",
		"NonOrganization", "InteractionFeature", "InteractionItem", "TaiwuItem", "RelationNumber", "ExistentRelation", "NonexistentRelation", "TaiwuNonexistentRelation", "InteractionNonexistentRelation", "TemplateId",
		"OptionGuid"
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
		_dataArray.Add(new InteractionEventOptionItem(0, "b83f08bc-38fb-4510-9aa1-f1b3c88e0aed", 0, EInteractionEventOptionInteractionType.Talk, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_0"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: true, new sbyte[5] { -6, -6, -6, -6, -6 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 10, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "05e87c45-f14e-49ef-8769-cbaced4753ae" }, new List<string> { "b83f08bc-38fb-4510-9aa1-f1b3c88e0aed" }));
		_dataArray.Add(new InteractionEventOptionItem(1, "28249f52-8580-4116-a945-e97754549334", -1, EInteractionEventOptionInteractionType.Talk, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_1"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { -6, -6, -6, -6, -6 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 10, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: true, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "05e87c45-f14e-49ef-8769-cbaced4753ae" }, new List<string> { "28249f52-8580-4116-a945-e97754549334" }));
		_dataArray.Add(new InteractionEventOptionItem(2, "02aa698d-8883-4c46-a0a7-a145f01aea16", -1, EInteractionEventOptionInteractionType.Talk, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_2"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { 5, 5, 5, 5, 5 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 10, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "05e87c45-f14e-49ef-8769-cbaced4753ae" }, new List<string> { "02aa698d-8883-4c46-a0a7-a145f01aea16" }));
		_dataArray.Add(new InteractionEventOptionItem(3, "99d2a9ec-d771-4025-acf5-3e1cd441a131", 3, EInteractionEventOptionInteractionType.Talk, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_3"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: true, new sbyte[5] { -6, -6, -6, -6, -6 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 10, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "05e87c45-f14e-49ef-8769-cbaced4753ae" }, new List<string> { "99d2a9ec-d771-4025-acf5-3e1cd441a131" }));
		_dataArray.Add(new InteractionEventOptionItem(4, "ca7d1404-1eef-426e-8244-e701f5d46179", 3, EInteractionEventOptionInteractionType.Talk, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_4"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: true, new sbyte[5] { -6, -6, -6, -6, -6 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 10, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "05e87c45-f14e-49ef-8769-cbaced4753ae" }, new List<string> { "ca7d1404-1eef-426e-8244-e701f5d46179" }));
		_dataArray.Add(new InteractionEventOptionItem(5, "a4553961-d8a4-4f74-97e3-236d1a81cfc5", -1, EInteractionEventOptionInteractionType.Talk, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_5"), EInteractionEventOptionTaiwuGroupStatus.NonTeammate, oncePerMonth: false, new sbyte[5] { -6, -6, -6, -6, -6 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 50, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), 16, 27, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "05e87c45-f14e-49ef-8769-cbaced4753ae" }, new List<string> { "a4553961-d8a4-4f74-97e3-236d1a81cfc5" }));
		_dataArray.Add(new InteractionEventOptionItem(6, "fe975917-a80d-4601-9e44-8b02d5ef4e70", -1, EInteractionEventOptionInteractionType.Talk, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_6"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { -6, -6, -6, -6, -6 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 30, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "05e87c45-f14e-49ef-8769-cbaced4753ae" }, new List<string> { "fe975917-a80d-4601-9e44-8b02d5ef4e70" }));
		_dataArray.Add(new InteractionEventOptionItem(7, "1803031e-500e-4e0c-b751-beba5a194755", 7, EInteractionEventOptionInteractionType.Competition, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_7"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: true, new sbyte[5] { 1, 1, 1, 1, 1 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 30, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), 3, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "9dce4f27-347c-4588-9be4-08c1c7f1f4a3" }, new List<string> { "1803031e-500e-4e0c-b751-beba5a194755" }));
		_dataArray.Add(new InteractionEventOptionItem(8, "ebeef265-487b-450d-8b30-7992553eac31", 8, EInteractionEventOptionInteractionType.Competition, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_8"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: true, new sbyte[5] { 3, 3, 3, 3, 3 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 30, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), 6, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "9dce4f27-347c-4588-9be4-08c1c7f1f4a3" }, new List<string> { "ebeef265-487b-450d-8b30-7992553eac31" }));
		_dataArray.Add(new InteractionEventOptionItem(9, "b8e895b1-00e3-4f5f-8e78-3b82340a97d8", 9, EInteractionEventOptionInteractionType.Competition, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_9"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: true, new sbyte[5] { 3, 3, 3, 3, 3 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 30, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), 3, -1, null, null, EInteractionEventOptionCompareConsummate.ConsummateGteTaiwu, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "9dce4f27-347c-4588-9be4-08c1c7f1f4a3" }, new List<string> { "b8e895b1-00e3-4f5f-8e78-3b82340a97d8" }));
		_dataArray.Add(new InteractionEventOptionItem(10, "c130f027-3054-42e0-a822-1110d4d0ca97", 9, EInteractionEventOptionInteractionType.Competition, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_10"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: true, new sbyte[5] { 3, 3, 3, 3, 3 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 30, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), 6, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "9dce4f27-347c-4588-9be4-08c1c7f1f4a3" }, new List<string> { "c130f027-3054-42e0-a822-1110d4d0ca97" }));
		_dataArray.Add(new InteractionEventOptionItem(11, "18219ebc-1d0d-41f9-9b21-0bc58b63f911", -1, EInteractionEventOptionInteractionType.Practice, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_11"), EInteractionEventOptionTaiwuGroupStatus.NonTeammate, oncePerMonth: false, new sbyte[5] { 2, 2, 2, 2, 2 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 50, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), 6, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, new List<short>
		{
			1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
			11, 12, 13, 14, 15
		}, new List<short> { 16 }, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "a9d0bcd8-e378-4ee9-96a6-1e5b9db17371" }, new List<string> { "18219ebc-1d0d-41f9-9b21-0bc58b63f911" }));
		_dataArray.Add(new InteractionEventOptionItem(12, "f4560d2f-a824-4722-9ea3-a8021a2167b2", -1, EInteractionEventOptionInteractionType.Practice, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_12"), EInteractionEventOptionTaiwuGroupStatus.NonTeammate, oncePerMonth: false, new sbyte[5] { 4, 4, 4, 4, 4 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 50, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), 6, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, new List<short>
		{
			1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
			11, 12, 13, 14, 15, 16
		}, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "a9d0bcd8-e378-4ee9-96a6-1e5b9db17371" }, new List<string> { "f4560d2f-a824-4722-9ea3-a8021a2167b2" }));
		_dataArray.Add(new InteractionEventOptionItem(13, "296ea777-65a9-4158-b669-f1ccaa16fdbc", -1, EInteractionEventOptionInteractionType.Practice, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_13"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { 4, 4, 4, 4, 4 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 50, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), 6, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, new List<short> { 16 }, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "a9d0bcd8-e378-4ee9-96a6-1e5b9db17371" }, new List<string> { "296ea777-65a9-4158-b669-f1ccaa16fdbc" }));
		_dataArray.Add(new InteractionEventOptionItem(14, "83d3927b-dc15-4238-bc84-572a80e6dbc3", -1, EInteractionEventOptionInteractionType.Practice, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_14"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { 2, 2, 2, 2, 2 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 50, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), 6, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "a9d0bcd8-e378-4ee9-96a6-1e5b9db17371" }, new List<string> { "83d3927b-dc15-4238-bc84-572a80e6dbc3" }));
		_dataArray.Add(new InteractionEventOptionItem(15, "8e94e7f9-4532-4762-9ea0-7c6af9c5f297", -1, EInteractionEventOptionInteractionType.Practice, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_15"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { 4, 4, 4, 4, 4 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 50, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), 6, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "a9d0bcd8-e378-4ee9-96a6-1e5b9db17371" }, new List<string> { "8e94e7f9-4532-4762-9ea0-7c6af9c5f297" }));
		_dataArray.Add(new InteractionEventOptionItem(16, "4a8c0f76-1601-4f89-bb79-74107b5bd67a", -1, EInteractionEventOptionInteractionType.Practice, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_16"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { 4, 4, 4, 4, 4 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 50, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), 6, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "a9d0bcd8-e378-4ee9-96a6-1e5b9db17371" }, new List<string> { "4a8c0f76-1601-4f89-bb79-74107b5bd67a" }));
		_dataArray.Add(new InteractionEventOptionItem(17, "f43fb5bc-b5d8-4d03-83e7-709537f80a3a", -1, EInteractionEventOptionInteractionType.Practice, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_17"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { -6, -6, -6, -6, -6 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 50, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(0, 0, 0, 0, 0, 20), 6, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "a9d0bcd8-e378-4ee9-96a6-1e5b9db17371" }, new List<string> { "f43fb5bc-b5d8-4d03-83e7-709537f80a3a" }));
		_dataArray.Add(new InteractionEventOptionItem(18, "a855d95e-0545-4ab5-87a9-c5666c35ef4b", -1, EInteractionEventOptionInteractionType.Practice, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_18"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { -6, -6, -6, -6, -6 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 50, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(0, 0, 0, 0, 0, 20), 6, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "a9d0bcd8-e378-4ee9-96a6-1e5b9db17371" }, new List<string> { "a855d95e-0545-4ab5-87a9-c5666c35ef4b" }));
		_dataArray.Add(new InteractionEventOptionItem(19, "22dd120c-d1cf-47b5-9b6f-8dfffe10021f", -1, EInteractionEventOptionInteractionType.Practice, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_19"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { -6, -6, -6, -6, -6 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 50, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(0, 0, 20, 0, 0, 0), 6, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "a9d0bcd8-e378-4ee9-96a6-1e5b9db17371" }, new List<string> { "22dd120c-d1cf-47b5-9b6f-8dfffe10021f" }));
		_dataArray.Add(new InteractionEventOptionItem(20, "f9445979-a8af-4453-a252-754615ae7ae1", -1, EInteractionEventOptionInteractionType.Practice, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_20"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { -6, -6, -6, -6, -6 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 50, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(0, 0, 20, 0, 0, 0), 6, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "a9d0bcd8-e378-4ee9-96a6-1e5b9db17371" }, new List<string> { "f9445979-a8af-4453-a252-754615ae7ae1" }));
		_dataArray.Add(new InteractionEventOptionItem(21, "c94ad014-80e9-48d3-acfa-b40e7d00b330", -1, EInteractionEventOptionInteractionType.Practice, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_21"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { 2, 2, 2, 2, 2 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 0, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), 6, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: true, ableReturnInfant: false, new List<string> { "a9d0bcd8-e378-4ee9-96a6-1e5b9db17371" }, new List<string> { "c94ad014-80e9-48d3-acfa-b40e7d00b330" }));
		_dataArray.Add(new InteractionEventOptionItem(22, "2aa9a29a-0290-4df7-aa8e-8cdaea94a22d", -1, EInteractionEventOptionInteractionType.Intimate, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_22"), EInteractionEventOptionTaiwuGroupStatus.NonTeammate, oncePerMonth: false, new sbyte[5] { -6, -6, -6, -6, -6 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 0, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), 8, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, new List<short> { 16 }, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: true, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "bad63f08-115a-45aa-970c-fa203dd85e2b" }, new List<string> { "2aa9a29a-0290-4df7-aa8e-8cdaea94a22d" }));
		_dataArray.Add(new InteractionEventOptionItem(23, "de774882-4c43-4bb8-b1a8-b141956d34e6", -1, EInteractionEventOptionInteractionType.Intimate, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_23"), EInteractionEventOptionTaiwuGroupStatus.NonTeammate, oncePerMonth: false, new sbyte[5] { 5, 5, 5, 5, 5 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 0, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), 8, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, new List<short> { 16 }, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: true, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "bad63f08-115a-45aa-970c-fa203dd85e2b" }, new List<string> { "de774882-4c43-4bb8-b1a8-b141956d34e6" }));
		_dataArray.Add(new InteractionEventOptionItem(24, "3e313ce1-daca-4d7e-9a64-70b45fbcce27", -1, EInteractionEventOptionInteractionType.Intimate, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_24"), EInteractionEventOptionTaiwuGroupStatus.NonTeammate, oncePerMonth: false, new sbyte[5] { 5, 5, 5, 5, 5 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 0, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), 8, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, new List<short> { 16 }, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "bad63f08-115a-45aa-970c-fa203dd85e2b" }, new List<string> { "3e313ce1-daca-4d7e-9a64-70b45fbcce27" }));
		_dataArray.Add(new InteractionEventOptionItem(25, "1afc4f92-ec82-433a-bca2-1578edcbc9d5", -1, EInteractionEventOptionInteractionType.Intimate, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_25"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { 2, 2, 2, 2, 2 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 50, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), 6, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, new List<short>
		{
			1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
			11, 12, 13, 14, 15
		}, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.NonObtainedOrganizationSupport, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: true, ableReturnInfant: false, new List<string> { "bad63f08-115a-45aa-970c-fa203dd85e2b" }, new List<string> { "1afc4f92-ec82-433a-bca2-1578edcbc9d5" }));
		_dataArray.Add(new InteractionEventOptionItem(26, "851deb6a-de66-4231-a9ce-fb51723739ea", -1, EInteractionEventOptionInteractionType.Intimate, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_26"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { 5, 5, 5, 5, 5 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 30, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), 6, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, 1, 30, -1, -1, 16, oneAdult: false, -1, -1, new List<short> { 1, 0, 9, 3, 2 }, new List<short> { 10, 13, 16 }, new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "bad63f08-115a-45aa-970c-fa203dd85e2b" }, new List<string> { "851deb6a-de66-4231-a9ce-fb51723739ea" }));
		_dataArray.Add(new InteractionEventOptionItem(27, "ad358628-3687-41e8-9898-bcd7b6e67910", -1, EInteractionEventOptionInteractionType.Intimate, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_27"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { 5, 5, 5, 5, 5 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 30, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), 6, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, 0, 30, -1, -1, 16, oneAdult: false, -1, -1, new List<short> { 1, 0, 9, 3, 2 }, new List<short> { 10, 13, 16 }, new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "bad63f08-115a-45aa-970c-fa203dd85e2b" }, new List<string> { "ad358628-3687-41e8-9898-bcd7b6e67910" }));
		_dataArray.Add(new InteractionEventOptionItem(28, "bba2883b-3408-45fd-abf1-b0ce7b366201", -1, EInteractionEventOptionInteractionType.Intimate, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_28"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { 5, 5, 5, 5, 5 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 30, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), 6, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, 1, -1, 16, 30, -1, oneAdult: false, -1, -1, new List<short> { 1, 0, 9, 3, 2 }, new List<short>(), new List<short> { 10, 13, 16 }, ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "bad63f08-115a-45aa-970c-fa203dd85e2b" }, new List<string> { "bba2883b-3408-45fd-abf1-b0ce7b366201" }));
		_dataArray.Add(new InteractionEventOptionItem(29, "e9d8182a-c473-4dbc-b5c4-a5b7f62445a4", -1, EInteractionEventOptionInteractionType.Intimate, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_29"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { 5, 5, 5, 5, 5 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 30, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), 6, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, 0, -1, 16, 30, -1, oneAdult: false, -1, -1, new List<short> { 1, 0, 9, 3, 2 }, new List<short>(), new List<short> { 10, 13, 16 }, ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "bad63f08-115a-45aa-970c-fa203dd85e2b" }, new List<string> { "e9d8182a-c473-4dbc-b5c4-a5b7f62445a4" }));
		_dataArray.Add(new InteractionEventOptionItem(30, "8485fb14-e3e9-4a7c-b14e-d8b4d194c4d3", -1, EInteractionEventOptionInteractionType.Intimate, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_30"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { 4, 4, 4, 4, 4 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 30, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), 6, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short> { 6 }, new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "bad63f08-115a-45aa-970c-fa203dd85e2b" }, new List<string> { "8485fb14-e3e9-4a7c-b14e-d8b4d194c4d3" }));
		_dataArray.Add(new InteractionEventOptionItem(31, "baca7ff7-bd45-4e4a-8d04-9ca3b351af83", -1, EInteractionEventOptionInteractionType.Intimate, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_31"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { 4, 4, 4, 4, 4 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 30, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), 6, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: true, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, 16, -1, 16, -1, oneAdult: false, -1, 6, new List<short> { 7, 8, 1, 0, 9, 3 }, new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "bad63f08-115a-45aa-970c-fa203dd85e2b" }, new List<string> { "baca7ff7-bd45-4e4a-8d04-9ca3b351af83" }));
		_dataArray.Add(new InteractionEventOptionItem(32, "a80d5623-3293-4ff7-85a7-503652de8596", -1, EInteractionEventOptionInteractionType.Intimate, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_32"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { 5, 5, 5, 5, 5 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 30, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), 6, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: true, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, 16, -1, 16, -1, oneAdult: false, -1, 7, new List<short> { 0, 9, 3, 1, 2 }, new List<short> { 2 }, new List<short> { 2 }, ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "bad63f08-115a-45aa-970c-fa203dd85e2b" }, new List<string> { "a80d5623-3293-4ff7-85a7-503652de8596" }));
		_dataArray.Add(new InteractionEventOptionItem(33, "360e1b76-7edf-47e9-85ed-d923205fe1d8", -1, EInteractionEventOptionInteractionType.Intimate, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_33"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { 5, 5, 5, 5, 5 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 30, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), 6, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: true, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, 16, -1, 16, -1, oneAdult: false, -1, 7, new List<short> { 0, 9, 3, 1, 2 }, new List<short> { 2 }, new List<short> { 2 }, ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "bad63f08-115a-45aa-970c-fa203dd85e2b" }, new List<string> { "360e1b76-7edf-47e9-85ed-d923205fe1d8" }));
		_dataArray.Add(new InteractionEventOptionItem(34, "ae23b819-8c1c-4dff-befb-5d0c62ff0962", -1, EInteractionEventOptionInteractionType.Intimate, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_34"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { -6, -6, -6, -6, -6 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 30, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), 6, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, 7, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "bad63f08-115a-45aa-970c-fa203dd85e2b" }, new List<string> { "ae23b819-8c1c-4dff-befb-5d0c62ff0962" }));
		_dataArray.Add(new InteractionEventOptionItem(35, "3e5cdc83-4648-46ab-822f-99e5cbf5a75a", -1, EInteractionEventOptionInteractionType.Intimate, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_35"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { 5, 5, 5, 5, 5 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 30, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), 6, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, 1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, 6, new List<short> { 7, 0, 9, 3, 1, 2 }, new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "bad63f08-115a-45aa-970c-fa203dd85e2b" }, new List<string> { "3e5cdc83-4648-46ab-822f-99e5cbf5a75a" }));
		_dataArray.Add(new InteractionEventOptionItem(36, "a0211104-e039-49ff-981f-7e878f0ca9bc", -1, EInteractionEventOptionInteractionType.Intimate, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_36"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { -6, -6, -6, -6, -6 }, new sbyte[5], null, null, -1, 30, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), 6, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, 1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "bad63f08-115a-45aa-970c-fa203dd85e2b" }, new List<string> { "a0211104-e039-49ff-981f-7e878f0ca9bc" }));
		_dataArray.Add(new InteractionEventOptionItem(37, "db0a85ca-426e-4577-9fea-48a2c8821312", -1, EInteractionEventOptionInteractionType.Intimate, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_37"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { 4, 4, 4, 4, 4 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 50, 0, 0, new ResourceInts(0, 0, 0, 0, 0, 0, 0, 300), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), 8, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "bad63f08-115a-45aa-970c-fa203dd85e2b" }, new List<string> { "db0a85ca-426e-4577-9fea-48a2c8821312" }));
		_dataArray.Add(new InteractionEventOptionItem(38, "84a0ec96-5374-4c82-bbb6-cb3a6fe4e85b", -1, EInteractionEventOptionInteractionType.Intimate, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_38"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { 4, 4, 4, 4, 4 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, new List<sbyte> { 3 }, -1, 50, 0, 0, new ResourceInts(0, 0, 0, 0, 0, 0, 0, 500), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), 8, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "bad63f08-115a-45aa-970c-fa203dd85e2b" }, new List<string> { "84a0ec96-5374-4c82-bbb6-cb3a6fe4e85b" }));
		_dataArray.Add(new InteractionEventOptionItem(39, "8c39e722-3940-4547-9fcc-a18ba3c2b035", -1, EInteractionEventOptionInteractionType.Intimate, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_39"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { 4, 4, 4, 4, 4 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 50, 0, 0, new ResourceInts(0, 0, 0, 0, 0, 0, 0, 300), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), 8, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "bad63f08-115a-45aa-970c-fa203dd85e2b" }, new List<string> { "8c39e722-3940-4547-9fcc-a18ba3c2b035" }));
		_dataArray.Add(new InteractionEventOptionItem(40, "d21bd2ce-c438-4b77-a6e5-eb48e7802d1f", -1, EInteractionEventOptionInteractionType.Intimate, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_40"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { 5, 5, 5, 5, 5 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 50, 0, 0, new ResourceInts(0, 0, 0, 0, 0, 0, 0, 500), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), 8, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, 16, -1, -1, -1, oneAdult: false, -1, 6, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "bad63f08-115a-45aa-970c-fa203dd85e2b" }, new List<string> { "d21bd2ce-c438-4b77-a6e5-eb48e7802d1f" }));
		_dataArray.Add(new InteractionEventOptionItem(41, "a106867a-89ed-4e0e-b0d9-9b4cccd9bf63", -1, EInteractionEventOptionInteractionType.Enemy, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_41"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { -6, -6, -6, -6, -6 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 50, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(0, 0, 20, 0, 0, 0), 6, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short> { 2 }, ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "7c70ce0c-577a-4049-bcad-e593c63d62d4", "24fef4f7-8593-418a-9b3d-1d2543750dc1" }, new List<string> { "a97f546a-f6ba-47f2-8aaf-03ab649bb7e4", "a106867a-89ed-4e0e-b0d9-9b4cccd9bf63" }));
		_dataArray.Add(new InteractionEventOptionItem(42, "bacb95b9-b726-4812-85fb-7e59d7128363", -1, EInteractionEventOptionInteractionType.Enemy, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_42"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { -6, -6, -6, -6, -6 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 50, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(0, 0, 20, 0, 0, 0), 6, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short> { 2 }, ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "7c70ce0c-577a-4049-bcad-e593c63d62d4", "24fef4f7-8593-418a-9b3d-1d2543750dc1" }, new List<string> { "a97f546a-f6ba-47f2-8aaf-03ab649bb7e4", "bacb95b9-b726-4812-85fb-7e59d7128363" }));
		_dataArray.Add(new InteractionEventOptionItem(43, "c06e1840-0236-4042-895c-07b741877ed2", -1, EInteractionEventOptionInteractionType.Enemy, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_43"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { -6, -6, -6, -6, -6 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 50, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(0, 0, 20, 0, 0, 0), 6, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short> { 2 }, ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "7c70ce0c-577a-4049-bcad-e593c63d62d4", "24fef4f7-8593-418a-9b3d-1d2543750dc1" }, new List<string> { "a97f546a-f6ba-47f2-8aaf-03ab649bb7e4", "c06e1840-0236-4042-895c-07b741877ed2" }));
		_dataArray.Add(new InteractionEventOptionItem(44, "42efe0a9-af89-4043-8d48-d734624ba4b9", -1, EInteractionEventOptionInteractionType.Enemy, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_44"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { -6, -6, -6, -6, -6 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, new List<sbyte> { 3 }, -1, 50, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(0, 20, 0, 0, 0, 0), 6, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "7c70ce0c-577a-4049-bcad-e593c63d62d4", "9d8e027b-5ee6-4c8c-917a-fbd9678014dc" }, new List<string> { "49ccb9e0-6216-4b06-b171-66a2be0b9e8c", "42efe0a9-af89-4043-8d48-d734624ba4b9" }));
		_dataArray.Add(new InteractionEventOptionItem(45, "0842bf96-a459-4d6d-adf9-46245bf99341", -1, EInteractionEventOptionInteractionType.Enemy, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_45"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { -6, -6, -6, -6, -6 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, new List<sbyte> { 4 }, -1, 50, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(20, 0, 0, 0, 0, 0), 6, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "7c70ce0c-577a-4049-bcad-e593c63d62d4", "9d8e027b-5ee6-4c8c-917a-fbd9678014dc" }, new List<string> { "49ccb9e0-6216-4b06-b171-66a2be0b9e8c", "0842bf96-a459-4d6d-adf9-46245bf99341" }));
		_dataArray.Add(new InteractionEventOptionItem(46, "9256bef3-0835-45af-8f08-8e736f3e2888", -1, EInteractionEventOptionInteractionType.Enemy, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_46"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { -6, -6, -6, -6, -6 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, new List<sbyte> { 3 }, -1, 30, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(0, 0, 0, 0, 20, 0), 6, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "7c70ce0c-577a-4049-bcad-e593c63d62d4", "4ea2bec5-f95d-430d-9516-734432c715f3" }, new List<string> { "b8220a30-457c-402b-980a-0f62cef398d8", "9256bef3-0835-45af-8f08-8e736f3e2888" }));
		_dataArray.Add(new InteractionEventOptionItem(47, "55a3b8eb-3ff5-4311-aae4-8afbd8bd04a2", -1, EInteractionEventOptionInteractionType.Enemy, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_47"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { -6, -6, -6, -6, -6 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, new List<sbyte> { 3 }, -1, 30, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(0, 0, 0, 0, 20, 0), 6, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "7c70ce0c-577a-4049-bcad-e593c63d62d4", "4ea2bec5-f95d-430d-9516-734432c715f3" }, new List<string> { "b8220a30-457c-402b-980a-0f62cef398d8", "55a3b8eb-3ff5-4311-aae4-8afbd8bd04a2" }));
		_dataArray.Add(new InteractionEventOptionItem(48, "9a1295b0-338b-4b70-9414-3b27d17ef7d7", -1, EInteractionEventOptionInteractionType.Enemy, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_48"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { -6, -6, -6, -6, -6 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, new List<sbyte> { 4 }, -1, 50, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), 6, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "7c70ce0c-577a-4049-bcad-e593c63d62d4", "4ea2bec5-f95d-430d-9516-734432c715f3" }, new List<string> { "b8220a30-457c-402b-980a-0f62cef398d8", "9a1295b0-338b-4b70-9414-3b27d17ef7d7" }));
		_dataArray.Add(new InteractionEventOptionItem(49, "c06b393e-5448-4ddc-9205-d697d9fcf086", -1, EInteractionEventOptionInteractionType.LegendaryBook, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_49"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { -6, -6, -6, -6, -6 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 50, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, 214, 1202, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "fb38f657-6ed0-41e4-a0c2-c82afb49762f", "e78e92d1-7712-4d0f-82d2-780b65f4a49b" }, new List<string> { "aa0fe434-6f2a-4f0f-a5bc-af1d4bcfe978", "c06b393e-5448-4ddc-9205-d697d9fcf086" }));
		_dataArray.Add(new InteractionEventOptionItem(50, "2b68413a-23bb-4cc6-a6cc-6f0d42ec9c32", -1, EInteractionEventOptionInteractionType.LegendaryBook, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_50"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { -6, -6, -6, -6, -6 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 50, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, 215, 1202, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "fb38f657-6ed0-41e4-a0c2-c82afb49762f", "e78e92d1-7712-4d0f-82d2-780b65f4a49b" }, new List<string> { "aa0fe434-6f2a-4f0f-a5bc-af1d4bcfe978", "2b68413a-23bb-4cc6-a6cc-6f0d42ec9c32" }));
		_dataArray.Add(new InteractionEventOptionItem(51, "e19db710-0672-415e-b55e-35763c32503c", -1, EInteractionEventOptionInteractionType.LegendaryBook, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_51"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { -6, -6, -6, -6, -6 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 50, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, 214, 1202, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "fb38f657-6ed0-41e4-a0c2-c82afb49762f", "e78e92d1-7712-4d0f-82d2-780b65f4a49b" }, new List<string> { "aa0fe434-6f2a-4f0f-a5bc-af1d4bcfe978", "e19db710-0672-415e-b55e-35763c32503c" }));
		_dataArray.Add(new InteractionEventOptionItem(52, "0d9998ec-286d-4a4a-a874-003421e2d090", -1, EInteractionEventOptionInteractionType.LegendaryBook, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_52"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { -6, -6, -6, -6, -6 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 50, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, 214, 1202, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "fb38f657-6ed0-41e4-a0c2-c82afb49762f", "e78e92d1-7712-4d0f-82d2-780b65f4a49b" }, new List<string> { "aa0fe434-6f2a-4f0f-a5bc-af1d4bcfe978", "0d9998ec-286d-4a4a-a874-003421e2d090" }));
		_dataArray.Add(new InteractionEventOptionItem(53, "92b9bed2-fe66-4afc-81b3-531c13cd8887", -1, EInteractionEventOptionInteractionType.Identity, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_53"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { 3, 3, 3, 3, 3 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 100, 1000, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: true, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: true, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "fb38f657-6ed0-41e4-a0c2-c82afb49762f" }, new List<string> { "92b9bed2-fe66-4afc-81b3-531c13cd8887" }));
		_dataArray.Add(new InteractionEventOptionItem(54, "32c8c82c-0a50-4266-bfcc-30584c3ead79", -1, EInteractionEventOptionInteractionType.Identity, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_54"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { 3, 3, 3, 3, 3 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 100, 500, 0, new ResourceInts(0, 0, 0, 0, 0, 0, 0, 500), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), 16, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.IdentityExtendFavor, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, 0, -1, -1, -1, 16, -1, oneAdult: false, -1, -1, new List<short>(), new List<short> { 2 }, new List<short>(), ableOnOrganizationBlock: true, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "fb38f657-6ed0-41e4-a0c2-c82afb49762f" }, new List<string> { "32c8c82c-0a50-4266-bfcc-30584c3ead79" }));
		_dataArray.Add(new InteractionEventOptionItem(55, "6dfdc03e-8354-4673-89f8-5950baba1dc1", -1, EInteractionEventOptionInteractionType.Identity, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_55"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { 2, 2, 2, 2, 2 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 100, 100, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, 27, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.IdentityWineTeaAndFriend, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "fb38f657-6ed0-41e4-a0c2-c82afb49762f" }, new List<string> { "6dfdc03e-8354-4673-89f8-5950baba1dc1" }));
		_dataArray.Add(new InteractionEventOptionItem(56, "ecf43809-ba5c-474a-90bb-b79f4b01970a", -1, EInteractionEventOptionInteractionType.Identity, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_56"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { 2, 2, 2, 2, 2 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 100, 400, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, 27, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.HoldTownMarket, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "fb38f657-6ed0-41e4-a0c2-c82afb49762f" }, new List<string> { "ecf43809-ba5c-474a-90bb-b79f4b01970a" }));
		_dataArray.Add(new InteractionEventOptionItem(57, "4ab58b95-ea2b-41eb-ad44-2c7867650413", -1, EInteractionEventOptionInteractionType.Identity, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_57"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { -6, -6, -6, -6, -6 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 0, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.IdentityBrowseGoods, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "fb38f657-6ed0-41e4-a0c2-c82afb49762f" }, new List<string> { "4ab58b95-ea2b-41eb-ad44-2c7867650413" }));
		_dataArray.Add(new InteractionEventOptionItem(58, "d71fad67-d8a9-4c09-896b-709ac501e38f", -1, EInteractionEventOptionInteractionType.Identity, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_58"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5], new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 30, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.IdentityDoctorHeal, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "fb38f657-6ed0-41e4-a0c2-c82afb49762f" }, new List<string> { "d71fad67-d8a9-4c09-896b-709ac501e38f" }));
		_dataArray.Add(new InteractionEventOptionItem(59, "476dfbe2-888e-46ad-9739-607ed8bead58", -1, EInteractionEventOptionInteractionType.Identity, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_59"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5], new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 30, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.IdentityRepairMan, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "fb38f657-6ed0-41e4-a0c2-c82afb49762f" }, new List<string> { "476dfbe2-888e-46ad-9739-607ed8bead58" }));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new InteractionEventOptionItem(60, "63fba20b-af20-4acf-a3d4-8d141f723603", 60, EInteractionEventOptionInteractionType.Identity, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_60"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5], new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 30, 0, 0, new ResourceInts(0, 0, 0, 0, 0, 0, 500, 0), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.IdentityHairCutter, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: true, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "fb38f657-6ed0-41e4-a0c2-c82afb49762f" }, new List<string> { "63fba20b-af20-4acf-a3d4-8d141f723603" }));
		_dataArray.Add(new InteractionEventOptionItem(61, "f3cd1acd-9ab3-47f6-b4ed-d8436858d240", -1, EInteractionEventOptionInteractionType.Identity, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_61"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5], new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 10, 0, 0, new ResourceInts(0, 0, 0, 0, 0, 0, 100, 0), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.IdentityMoneyCharity, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "fb38f657-6ed0-41e4-a0c2-c82afb49762f" }, new List<string> { "f3cd1acd-9ab3-47f6-b4ed-d8436858d240" }));
		_dataArray.Add(new InteractionEventOptionItem(62, "6c6feb27-bdff-4034-9b34-3f4c4ca9cca4", -1, EInteractionEventOptionInteractionType.Organization, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_62"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { 3, 3, 3, 3, 3 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 50, 0, 0, new ResourceInts(0, 0, 0, 0, 0, 0, 0, 200), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, 27, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.IntimateInteractionRecommendPupil, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: true, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "fb38f657-6ed0-41e4-a0c2-c82afb49762f" }, new List<string> { "6c6feb27-bdff-4034-9b34-3f4c4ca9cca4" }));
		_dataArray.Add(new InteractionEventOptionItem(63, "9dcaf5f0-a127-4305-81e6-e8b4c5e3c7b3", -1, EInteractionEventOptionInteractionType.Organization, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_63"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { -6, -6, -6, -6, -6 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 0, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, 27, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.IntimateInteractionDemandPupil, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: true, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "fb38f657-6ed0-41e4-a0c2-c82afb49762f" }, new List<string> { "9dcaf5f0-a127-4305-81e6-e8b4c5e3c7b3" }));
		_dataArray.Add(new InteractionEventOptionItem(64, "34008183-b660-4d37-8c6e-829f909b0740", -1, EInteractionEventOptionInteractionType.Organization, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_64"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { 3, 3, 3, 3, 3 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 100, 200, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.SpiritualDebtInteractionShaolin, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: true, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "fb38f657-6ed0-41e4-a0c2-c82afb49762f" }, new List<string> { "34008183-b660-4d37-8c6e-829f909b0740" }));
		_dataArray.Add(new InteractionEventOptionItem(65, "489cac2a-7ba5-4491-9a04-9cdfc2bc6c81", -1, EInteractionEventOptionInteractionType.Organization, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_65"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { 3, 3, 3, 3, 3 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 100, 500, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.SpiritualDebtInteractionEmei, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: true, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "fb38f657-6ed0-41e4-a0c2-c82afb49762f" }, new List<string> { "489cac2a-7ba5-4491-9a04-9cdfc2bc6c81" }));
		_dataArray.Add(new InteractionEventOptionItem(66, "ec748a64-2203-4a39-8c73-027ca7a8ffbb", -1, EInteractionEventOptionInteractionType.Organization, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_66"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { 3, 3, 3, 3, 3 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 100, 400, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.SpiritualDebtInteractionBaihua, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: true, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "fb38f657-6ed0-41e4-a0c2-c82afb49762f" }, new List<string> { "ec748a64-2203-4a39-8c73-027ca7a8ffbb" }));
		_dataArray.Add(new InteractionEventOptionItem(67, "47505f4f-a83a-4b04-be26-bfe68168bb6b", -1, EInteractionEventOptionInteractionType.Organization, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_67"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { 3, 3, 3, 3, 3 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 100, 300, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.SpiritualDebtInteractionWudang, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: true, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "fb38f657-6ed0-41e4-a0c2-c82afb49762f" }, new List<string> { "47505f4f-a83a-4b04-be26-bfe68168bb6b" }));
		_dataArray.Add(new InteractionEventOptionItem(68, "24955b46-54cf-4f5c-8219-8785b59daa8c", -1, EInteractionEventOptionInteractionType.Organization, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_68"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { 3, 3, 3, 3, 3 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 100, 300, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.SpiritualDebtInteractionYuanshan, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: true, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "fb38f657-6ed0-41e4-a0c2-c82afb49762f" }, new List<string> { "24955b46-54cf-4f5c-8219-8785b59daa8c" }));
		_dataArray.Add(new InteractionEventOptionItem(69, "dddddfb1-1875-42d7-bc1c-71d50de926d9", -1, EInteractionEventOptionInteractionType.Organization, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_69"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { 3, 3, 3, 3, 3 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 100, 300, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.SpiritualDebtInteractionShixiang, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: true, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "fb38f657-6ed0-41e4-a0c2-c82afb49762f" }, new List<string> { "dddddfb1-1875-42d7-bc1c-71d50de926d9" }));
		_dataArray.Add(new InteractionEventOptionItem(70, "58ef6bdf-64a0-46e5-bfbf-8d494c1962c9", -1, EInteractionEventOptionInteractionType.Organization, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_70"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { 3, 3, 3, 3, 3 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 100, 300, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.SpiritualDebtInteractionRanshan, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: true, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "fb38f657-6ed0-41e4-a0c2-c82afb49762f" }, new List<string> { "58ef6bdf-64a0-46e5-bfbf-8d494c1962c9" }));
		_dataArray.Add(new InteractionEventOptionItem(71, "445ba0fb-5613-458f-8d6c-7e2ef4b479ba", -1, EInteractionEventOptionInteractionType.Organization, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_71"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { 3, 3, 3, 3, 3 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 100, 500, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.SpiritualDebtInteractionXuannv, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: true, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "fb38f657-6ed0-41e4-a0c2-c82afb49762f" }, new List<string> { "445ba0fb-5613-458f-8d6c-7e2ef4b479ba" }));
		_dataArray.Add(new InteractionEventOptionItem(72, "82431922-c9c8-41d9-b98b-3f469b7d302f", -1, EInteractionEventOptionInteractionType.Organization, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_72"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { 3, 3, 3, 3, 3 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 100, 500, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.SpiritualDebtInteractionZhujian, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: true, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "fb38f657-6ed0-41e4-a0c2-c82afb49762f" }, new List<string> { "82431922-c9c8-41d9-b98b-3f469b7d302f" }));
		_dataArray.Add(new InteractionEventOptionItem(73, "2e3f9ab3-1edf-4959-8293-c57803dc745f", -1, EInteractionEventOptionInteractionType.Organization, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_73"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { 3, 3, 3, 3, 3 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 100, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.SpiritualDebtInteractionZhujian, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: true, ableZhujian: true, ableJoinSect: false, ableReturnInfant: false, new List<string> { "fb38f657-6ed0-41e4-a0c2-c82afb49762f" }, new List<string> { "2e3f9ab3-1edf-4959-8293-c57803dc745f" }));
		_dataArray.Add(new InteractionEventOptionItem(74, "1bfebfdb-54ad-42cf-8cca-77a0f860cc40", -1, EInteractionEventOptionInteractionType.Organization, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_74"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { 3, 3, 3, 3, 3 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 100, 500, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.SpiritualDebtInteractionKongsang, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: true, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "fb38f657-6ed0-41e4-a0c2-c82afb49762f" }, new List<string> { "1bfebfdb-54ad-42cf-8cca-77a0f860cc40" }));
		_dataArray.Add(new InteractionEventOptionItem(75, "4a2474c4-7e69-4464-a44c-8b1de2a50e9c", -1, EInteractionEventOptionInteractionType.Organization, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_75"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { 3, 3, 3, 3, 3 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 100, 200, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.SpiritualDebtInteractionJingang, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: true, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "fb38f657-6ed0-41e4-a0c2-c82afb49762f" }, new List<string> { "4a2474c4-7e69-4464-a44c-8b1de2a50e9c" }));
		_dataArray.Add(new InteractionEventOptionItem(76, "6f4b56f5-6d60-4b2b-87b1-735402a75508", -1, EInteractionEventOptionInteractionType.Organization, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_76"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { 3, 3, 3, 3, 3 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 100, 300, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.SpiritualDebtInteractionWuxian, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: true, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "fb38f657-6ed0-41e4-a0c2-c82afb49762f" }, new List<string> { "6f4b56f5-6d60-4b2b-87b1-735402a75508" }));
		_dataArray.Add(new InteractionEventOptionItem(77, "0dc5194c-bee0-4c29-a2e0-28596136275d", -1, EInteractionEventOptionInteractionType.Organization, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_77"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { 3, 3, 3, 3, 3 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 100, 600, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.SpiritualDebtInteractionJieqing, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: true, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "fb38f657-6ed0-41e4-a0c2-c82afb49762f" }, new List<string> { "0dc5194c-bee0-4c29-a2e0-28596136275d" }));
		_dataArray.Add(new InteractionEventOptionItem(78, "70ed5c6a-a615-404d-bcba-39c855eb2e38", -1, EInteractionEventOptionInteractionType.Organization, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_78"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { 3, 3, 3, 3, 3 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 100, 300, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.SpiritualDebtInteractionFulong, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: true, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "fb38f657-6ed0-41e4-a0c2-c82afb49762f" }, new List<string> { "70ed5c6a-a615-404d-bcba-39c855eb2e38" }));
		_dataArray.Add(new InteractionEventOptionItem(79, "6c87bcdd-7fad-4f82-aacc-10295820db88", -1, EInteractionEventOptionInteractionType.Organization, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_79"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { 3, 3, 3, 3, 3 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 100, 300, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.SpiritualDebtInteractionXuehou, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: true, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "fb38f657-6ed0-41e4-a0c2-c82afb49762f" }, new List<string> { "6c87bcdd-7fad-4f82-aacc-10295820db88" }));
		_dataArray.Add(new InteractionEventOptionItem(80, "e243fb2f-a058-445a-95e7-fa9366e50a2d", -1, EInteractionEventOptionInteractionType.Identity, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_80"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { 2, 2, 2, 2, 2 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 100, 400, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, 27, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.CityPunishmentSeverityCustomize, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "fb38f657-6ed0-41e4-a0c2-c82afb49762f" }, new List<string> { "e243fb2f-a058-445a-95e7-fa9366e50a2d" }));
		_dataArray.Add(new InteractionEventOptionItem(81, "537cfe1b-031a-46f3-84bb-da10ef548ebf", -1, EInteractionEventOptionInteractionType.Identity, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_81"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { 2, 2, 2, 2, 2 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 100, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, 27, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.DoctorExpensiveHeal, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "fb38f657-6ed0-41e4-a0c2-c82afb49762f" }, new List<string> { "537cfe1b-031a-46f3-84bb-da10ef548ebf" }));
		_dataArray.Add(new InteractionEventOptionItem(82, "0269e8a7-3857-4fb5-99f4-68945a69daf4", -1, EInteractionEventOptionInteractionType.Profession, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_82"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { -6, -6, -6, -6, -6 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, 52, 50, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "fb38f657-6ed0-41e4-a0c2-c82afb49762f" }, new List<string> { "0269e8a7-3857-4fb5-99f4-68945a69daf4" }));
		_dataArray.Add(new InteractionEventOptionItem(83, "c0b946c6-de04-4953-af90-bd4f92ce3938", -1, EInteractionEventOptionInteractionType.Profession, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_83"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { -6, -6, -6, -6, -6 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 0, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "fb38f657-6ed0-41e4-a0c2-c82afb49762f" }, new List<string> { "c0b946c6-de04-4953-af90-bd4f92ce3938" }));
		_dataArray.Add(new InteractionEventOptionItem(84, "9453eb35-bbff-4ff1-b2ff-e6b0626609a5", -1, EInteractionEventOptionInteractionType.Profession, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_84"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { -6, -6, -6, -6, -6 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, 69, 50, 0, 0, new ResourceInts(0, 0, 0, 0, 0, 0, 0, 500), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "fb38f657-6ed0-41e4-a0c2-c82afb49762f" }, new List<string> { "9453eb35-bbff-4ff1-b2ff-e6b0626609a5" }));
		_dataArray.Add(new InteractionEventOptionItem(85, "d7b341af-2633-4e18-8bde-81a3fa268790", -1, EInteractionEventOptionInteractionType.Profession, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_85"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { -6, -6, -6, -6, -6 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, 64, 50, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, 900, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, 16, -1, -1, -1, oneAdult: false, 400, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "fb38f657-6ed0-41e4-a0c2-c82afb49762f" }, new List<string> { "d7b341af-2633-4e18-8bde-81a3fa268790" }));
		_dataArray.Add(new InteractionEventOptionItem(86, "8c10275e-7059-4751-8000-bbf3b0a7ad15", -1, EInteractionEventOptionInteractionType.Profession, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_86"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { 3, 3, 3, 3, 3 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, 60, 50, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "fb38f657-6ed0-41e4-a0c2-c82afb49762f" }, new List<string> { "8c10275e-7059-4751-8000-bbf3b0a7ad15" }));
		_dataArray.Add(new InteractionEventOptionItem(87, "4885ea08-706b-4542-b903-a9bbb8a00f5c", -1, EInteractionEventOptionInteractionType.Profession, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_87"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { 2, 2, 2, 2, 2 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, 57, 100, 0, 2500, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "fb38f657-6ed0-41e4-a0c2-c82afb49762f" }, new List<string> { "4885ea08-706b-4542-b903-a9bbb8a00f5c" }));
		_dataArray.Add(new InteractionEventOptionItem(88, "b99161e5-43cc-4ffa-bfa4-d24c9fed5200", -1, EInteractionEventOptionInteractionType.Profession, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_88"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: true, new sbyte[5] { -6, -6, -6, -6, -6 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, 58, 100, 0, 25000, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "fb38f657-6ed0-41e4-a0c2-c82afb49762f" }, new List<string> { "b99161e5-43cc-4ffa-bfa4-d24c9fed5200" }));
		_dataArray.Add(new InteractionEventOptionItem(89, "4531865f-fed9-4258-a525-2e2b764c967d", -1, EInteractionEventOptionInteractionType.Profession, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_89"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { -6, -6, -6, -6, -6 }, new sbyte[5] { 6, 6, 6, 6, 6 }, new List<sbyte> { 4, 3 }, null, 49, 100, 0, 1500, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.NonXiangshuEffect, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "fb38f657-6ed0-41e4-a0c2-c82afb49762f" }, new List<string> { "4531865f-fed9-4258-a525-2e2b764c967d" }));
		_dataArray.Add(new InteractionEventOptionItem(90, "5a818082-0c33-4e02-abfc-135ae1f96728", -1, EInteractionEventOptionInteractionType.Profession, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_90"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { -6, -6, -6, -6, -6 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, 42, 150, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "fb38f657-6ed0-41e4-a0c2-c82afb49762f" }, new List<string> { "5a818082-0c33-4e02-abfc-135ae1f96728" }));
		_dataArray.Add(new InteractionEventOptionItem(91, "63989f81-30b3-403b-946d-11e372207e6c", -1, EInteractionEventOptionInteractionType.Profession, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_91"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { -6, -6, -6, -6, -6 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, 32, 100, 0, 0, new ResourceInts(0, 0, 0, 0, 0, 0, 0, 100), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, new List<short>
		{
			1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
			11, 12, 13, 14, 15
		}, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short> { 5 }, new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "fb38f657-6ed0-41e4-a0c2-c82afb49762f" }, new List<string> { "63989f81-30b3-403b-946d-11e372207e6c" }));
		_dataArray.Add(new InteractionEventOptionItem(92, "5b16cb9f-8c81-42ca-9bff-6a240032d0b7", -1, EInteractionEventOptionInteractionType.Profession, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_92"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { -6, -6, -6, -6, -6 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, 28, 50, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, 901, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, 16, -1, 16, -1, oneAdult: false, 400, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "fb38f657-6ed0-41e4-a0c2-c82afb49762f" }, new List<string> { "5b16cb9f-8c81-42ca-9bff-6a240032d0b7" }));
		_dataArray.Add(new InteractionEventOptionItem(93, "3ba39e16-9853-4b26-9bb2-4d15958cdbe7", -1, EInteractionEventOptionInteractionType.Profession, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_93"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { 3, 3, 4, 5, 5 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, 25, 100, 0, 1500, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "fb38f657-6ed0-41e4-a0c2-c82afb49762f" }, new List<string> { "3ba39e16-9853-4b26-9bb2-4d15958cdbe7" }));
		_dataArray.Add(new InteractionEventOptionItem(94, "01089785-6545-435b-baea-2cf9a9856426", -1, EInteractionEventOptionInteractionType.Profession, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_94"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: true, new sbyte[5] { -6, -6, -6, -6, -6 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, 21, 100, 0, 1000, new ResourceInts(0, 0, 0, 0, 0, 0, 0, 500), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.XiangshuEffect, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "fb38f657-6ed0-41e4-a0c2-c82afb49762f" }, new List<string> { "01089785-6545-435b-baea-2cf9a9856426" }));
		_dataArray.Add(new InteractionEventOptionItem(95, "85476161-eb2b-45ed-9c1c-d3ffbbb076f7", -1, EInteractionEventOptionInteractionType.Profession, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_95"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { -6, -6, -6, -6, -6 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, 16, 50, 0, 0, new ResourceInts(0, 0, 0, 0, 0, 0, 0, 100), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "fb38f657-6ed0-41e4-a0c2-c82afb49762f" }, new List<string> { "85476161-eb2b-45ed-9c1c-d3ffbbb076f7" }));
		_dataArray.Add(new InteractionEventOptionItem(96, "cd66efe2-548a-4ab0-a7c8-57c937f029f5", -1, EInteractionEventOptionInteractionType.Special, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_96"), EInteractionEventOptionTaiwuGroupStatus.NonTeammate, oncePerMonth: false, new sbyte[5] { -6, -6, -6, -6, -6 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 0, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), 22, -1, new List<short> { 65 }, new List<short>
		{
			46, 47, 48, 55, 56, 57, 64, 65, 66, 73,
			74, 75, 82, 83, 84, 91, 92, 93, 100, 101,
			102, 109, 110, 111, 118, 119, 120, 127, 128, 129,
			136, 137, 138, 145, 146, 147, 154, 155, 156, 163,
			164, 165, 172, 173, 174
		}, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "567d1caf-8b28-4dbf-8cbe-e746e8ac8cfd" }, new List<string> { "cd66efe2-548a-4ab0-a7c8-57c937f029f5" }));
		_dataArray.Add(new InteractionEventOptionItem(97, "02746aa3-ed0c-4f99-aee9-92cadf8c6ee1", -1, EInteractionEventOptionInteractionType.Special, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_97"), EInteractionEventOptionTaiwuGroupStatus.NonTeammate, oncePerMonth: false, new sbyte[5] { -6, -6, -6, -6, -6 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 0, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, new List<short> { 136, 139 }, new List<short> { 46, 47, 48 }, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "fb38f657-6ed0-41e4-a0c2-c82afb49762f" }, new List<string> { "02746aa3-ed0c-4f99-aee9-92cadf8c6ee1" }));
		_dataArray.Add(new InteractionEventOptionItem(98, "e122fb62-76d7-4057-9177-90f2fd101517", -1, EInteractionEventOptionInteractionType.Special, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_98"), EInteractionEventOptionTaiwuGroupStatus.NonTeammate, oncePerMonth: false, new sbyte[5] { -6, -6, -6, -6, -6 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 0, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, new List<short> { 132, 133 }, new List<short> { 46, 47, 48 }, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "fb38f657-6ed0-41e4-a0c2-c82afb49762f" }, new List<string> { "e122fb62-76d7-4057-9177-90f2fd101517" }));
		_dataArray.Add(new InteractionEventOptionItem(99, "7b1996f3-7a2c-42a1-ad59-21efbff1418f", -1, EInteractionEventOptionInteractionType.Special, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_99"), EInteractionEventOptionTaiwuGroupStatus.NonTeammate, oncePerMonth: false, new sbyte[5] { -6, -6, -6, -6, -6 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 0, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, new List<short> { 182, 186 }, new List<short> { 46, 47, 48 }, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "fb38f657-6ed0-41e4-a0c2-c82afb49762f" }, new List<string> { "7b1996f3-7a2c-42a1-ad59-21efbff1418f" }));
		_dataArray.Add(new InteractionEventOptionItem(100, "9010a41a-5252-4319-8e29-7938ca8dc1c7", 100, EInteractionEventOptionInteractionType.Special, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_100"), EInteractionEventOptionTaiwuGroupStatus.NonTeammate, oncePerMonth: false, new sbyte[5] { -6, -6, -6, -6, -6 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 0, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, new List<short> { 186, 187 }, new List<short> { 46, 47, 48 }, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "fb38f657-6ed0-41e4-a0c2-c82afb49762f" }, new List<string> { "9010a41a-5252-4319-8e29-7938ca8dc1c7" }));
		_dataArray.Add(new InteractionEventOptionItem(101, "d53deeba-0dbb-44f0-bce4-3e70769cebef", -1, EInteractionEventOptionInteractionType.Special, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_101"), EInteractionEventOptionTaiwuGroupStatus.NonTeammate, oncePerMonth: false, new sbyte[5] { -6, -6, -6, -6, -6 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 0, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, new List<short> { 227, 227 }, new List<short> { 46, 47, 48 }, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "fb38f657-6ed0-41e4-a0c2-c82afb49762f" }, new List<string> { "d53deeba-0dbb-44f0-bce4-3e70769cebef" }));
		_dataArray.Add(new InteractionEventOptionItem(102, "a1f97f93-c18e-4a0e-965c-3901ffa1b3dc", -1, EInteractionEventOptionInteractionType.Special, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_102"), EInteractionEventOptionTaiwuGroupStatus.NonTeammate, oncePerMonth: false, new sbyte[5] { -6, -6, -6, -6, -6 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 0, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, new List<short> { 227, 227 }, new List<short> { 46, 47, 48 }, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "fb38f657-6ed0-41e4-a0c2-c82afb49762f" }, new List<string> { "a1f97f93-c18e-4a0e-965c-3901ffa1b3dc" }));
		_dataArray.Add(new InteractionEventOptionItem(103, "5cf95dae-dbff-409c-ac09-fed1f491261f", -1, EInteractionEventOptionInteractionType.Special, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_103"), EInteractionEventOptionTaiwuGroupStatus.NonTeammate, oncePerMonth: false, new sbyte[5] { -6, -6, -6, -6, -6 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 0, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, new List<short> { 227, 227 }, new List<short> { 46, 47, 48 }, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "fb38f657-6ed0-41e4-a0c2-c82afb49762f" }, new List<string> { "5cf95dae-dbff-409c-ac09-fed1f491261f" }));
		_dataArray.Add(new InteractionEventOptionItem(104, "a11267cf-5048-48b8-84f3-64ab6d2e4892", -1, EInteractionEventOptionInteractionType.Special, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_104"), EInteractionEventOptionTaiwuGroupStatus.NonTeammate, oncePerMonth: false, new sbyte[5] { -6, -6, -6, -6, -6 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 0, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: true, new List<string> { "fb38f657-6ed0-41e4-a0c2-c82afb49762f", "567d1caf-8b28-4dbf-8cbe-e746e8ac8cfd" }, new List<string> { "92211893-432e-493b-bdd7-8ddd1a125200", "a11267cf-5048-48b8-84f3-64ab6d2e4892" }));
		_dataArray.Add(new InteractionEventOptionItem(105, "e19374a9-239e-4184-b46c-3dd3926689d0", -1, EInteractionEventOptionInteractionType.Special, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_105"), EInteractionEventOptionTaiwuGroupStatus.NonTeammate, oncePerMonth: false, new sbyte[5] { -6, -6, -6, -6, -6 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 0, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "fb38f657-6ed0-41e4-a0c2-c82afb49762f" }, new List<string> { "e19374a9-239e-4184-b46c-3dd3926689d0" }));
		_dataArray.Add(new InteractionEventOptionItem(106, "86e4b26d-136a-47f4-8e64-2db1a38ff5e5", -1, EInteractionEventOptionInteractionType.Special, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_106"), EInteractionEventOptionTaiwuGroupStatus.NonTeammate, oncePerMonth: false, new sbyte[5] { -6, -6, -6, -6, -6 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 0, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "fb38f657-6ed0-41e4-a0c2-c82afb49762f" }, new List<string> { "86e4b26d-136a-47f4-8e64-2db1a38ff5e5" }));
		_dataArray.Add(new InteractionEventOptionItem(107, "ab54df75-25c4-421f-bf61-e04f56271e54", -1, EInteractionEventOptionInteractionType.Special, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_107"), EInteractionEventOptionTaiwuGroupStatus.NonTeammate, oncePerMonth: false, new sbyte[5] { -6, -6, -6, -6, -6 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 0, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "fb38f657-6ed0-41e4-a0c2-c82afb49762f" }, new List<string> { "ab54df75-25c4-421f-bf61-e04f56271e54" }));
		_dataArray.Add(new InteractionEventOptionItem(108, "e7d14768-de9e-425b-b4c6-0eb5da3cf6bd", -1, EInteractionEventOptionInteractionType.Special, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_108"), EInteractionEventOptionTaiwuGroupStatus.NonTeammate, oncePerMonth: false, new sbyte[5] { -6, -6, -6, -6, -6 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 0, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "fb38f657-6ed0-41e4-a0c2-c82afb49762f" }, new List<string> { "e7d14768-de9e-425b-b4c6-0eb5da3cf6bd" }));
		_dataArray.Add(new InteractionEventOptionItem(109, "6b2b8317-a75d-4735-a5ae-2b7e890e7a82", -1, EInteractionEventOptionInteractionType.Special, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_109"), EInteractionEventOptionTaiwuGroupStatus.NonTeammate, oncePerMonth: false, new sbyte[5] { -6, -6, -6, -6, -6 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 0, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "fb38f657-6ed0-41e4-a0c2-c82afb49762f" }, new List<string> { "6b2b8317-a75d-4735-a5ae-2b7e890e7a82" }));
		_dataArray.Add(new InteractionEventOptionItem(110, "d28f20bb-1d2d-4620-ad1f-f84fba3a0f9a", -1, EInteractionEventOptionInteractionType.Special, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_110"), EInteractionEventOptionTaiwuGroupStatus.NonTeammate, oncePerMonth: false, new sbyte[5] { 6, 6, 6, 6, 6 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 0, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "fb38f657-6ed0-41e4-a0c2-c82afb49762f" }, new List<string> { "d28f20bb-1d2d-4620-ad1f-f84fba3a0f9a" }));
		_dataArray.Add(new InteractionEventOptionItem(111, "40460cd3-f0a5-4103-a453-9dfe8dfb3774", 111, EInteractionEventOptionInteractionType.Invalid, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_111"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { -6, -6, -6, -6, -6 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 0, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "2e651ccb-3a77-447a-a74f-c9a24a1a32d1" }, new List<string> { "40460cd3-f0a5-4103-a453-9dfe8dfb3774" }));
		_dataArray.Add(new InteractionEventOptionItem(112, "10e49b41-43ca-408f-b0c8-596788aae3cb", 112, EInteractionEventOptionInteractionType.Invalid, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_112"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { -6, -6, -6, -6, -6 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 0, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "e357bf81-75dc-48cc-b47e-98217d622954" }, new List<string> { "10e49b41-43ca-408f-b0c8-596788aae3cb" }));
		_dataArray.Add(new InteractionEventOptionItem(113, "4f99f3fc-5180-42ef-ae17-c8b97ffa11f1", 112, EInteractionEventOptionInteractionType.Invalid, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_113"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { -6, -6, -6, -6, -6 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 0, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "e357bf81-75dc-48cc-b47e-98217d622954" }, new List<string> { "4f99f3fc-5180-42ef-ae17-c8b97ffa11f1" }));
		_dataArray.Add(new InteractionEventOptionItem(114, "20378f3d-9ee6-40a8-ab8d-070eab218877", 112, EInteractionEventOptionInteractionType.Invalid, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_114"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { -6, -6, -6, -6, -6 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 0, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "e357bf81-75dc-48cc-b47e-98217d622954" }, new List<string> { "20378f3d-9ee6-40a8-ab8d-070eab218877" }));
		_dataArray.Add(new InteractionEventOptionItem(115, "96259b88-4f8d-4d28-a4e2-c91c62614cff", 112, EInteractionEventOptionInteractionType.Invalid, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_115"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { -6, -6, -6, -6, -6 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 0, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "e357bf81-75dc-48cc-b47e-98217d622954" }, new List<string> { "96259b88-4f8d-4d28-a4e2-c91c62614cff" }));
		_dataArray.Add(new InteractionEventOptionItem(116, "b5954ff0-ecc1-478e-bfa8-e50b57f8c257", 112, EInteractionEventOptionInteractionType.Invalid, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_116"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { -6, -6, -6, -6, -6 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 0, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "e357bf81-75dc-48cc-b47e-98217d622954" }, new List<string> { "b5954ff0-ecc1-478e-bfa8-e50b57f8c257" }));
		_dataArray.Add(new InteractionEventOptionItem(117, "ba491398-ea61-4bf9-8c3e-e8a7346ec469", 112, EInteractionEventOptionInteractionType.Invalid, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_117"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { -6, -6, -6, -6, -6 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 0, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "e357bf81-75dc-48cc-b47e-98217d622954" }, new List<string> { "ba491398-ea61-4bf9-8c3e-e8a7346ec469" }));
		_dataArray.Add(new InteractionEventOptionItem(118, "2cad2869-4bfc-460e-bf92-2418c37b4882", 112, EInteractionEventOptionInteractionType.Invalid, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_118"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { -6, -6, -6, -6, -6 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 0, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "e357bf81-75dc-48cc-b47e-98217d622954" }, new List<string> { "2cad2869-4bfc-460e-bf92-2418c37b4882" }));
		_dataArray.Add(new InteractionEventOptionItem(119, "67141bbb-5dc0-496c-b529-b0a991e90f51", 112, EInteractionEventOptionInteractionType.Invalid, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_119"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { -6, -6, -6, -6, -6 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 0, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "e357bf81-75dc-48cc-b47e-98217d622954" }, new List<string> { "67141bbb-5dc0-496c-b529-b0a991e90f51" }));
	}

	private void CreateItems2()
	{
		_dataArray.Add(new InteractionEventOptionItem(120, "1538340f-979f-40a2-9328-3a9dcf326f92", -1, EInteractionEventOptionInteractionType.Special, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_120"), EInteractionEventOptionTaiwuGroupStatus.NonTeammate, oncePerMonth: false, new sbyte[5] { -6, -6, -6, -6, -6 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 0, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "fb38f657-6ed0-41e4-a0c2-c82afb49762f" }, new List<string> { "1538340f-979f-40a2-9328-3a9dcf326f92" }));
		_dataArray.Add(new InteractionEventOptionItem(121, "b48c9fdb-195b-43f0-9101-7fb23b9b396a", -1, EInteractionEventOptionInteractionType.Special, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_121"), EInteractionEventOptionTaiwuGroupStatus.NonTeammate, oncePerMonth: false, new sbyte[5] { -6, -6, -6, -6, -6 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 0, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "fb38f657-6ed0-41e4-a0c2-c82afb49762f" }, new List<string> { "b48c9fdb-195b-43f0-9101-7fb23b9b396a" }));
		_dataArray.Add(new InteractionEventOptionItem(122, "b07acab7-edae-47be-a070-bf808f906990", -1, EInteractionEventOptionInteractionType.Enemy, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_122"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { -6, -6, -6, -6, -6 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 0, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "7c70ce0c-577a-4049-bcad-e593c63d62d4" }, new List<string> { "b07acab7-edae-47be-a070-bf808f906990" }));
		_dataArray.Add(new InteractionEventOptionItem(123, "b174661d-5fa7-4b79-a539-615b708f2733", -1, EInteractionEventOptionInteractionType.Special, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_123"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { -6, -6, -6, -6, -6 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 0, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "fb38f657-6ed0-41e4-a0c2-c82afb49762f" }, new List<string> { "b174661d-5fa7-4b79-a539-615b708f2733" }));
		_dataArray.Add(new InteractionEventOptionItem(124, "01443b53-44f4-4793-bde2-df4a7aacf6ad", -1, EInteractionEventOptionInteractionType.Special, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_124"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { -6, -6, -6, -6, -6 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 0, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "fb38f657-6ed0-41e4-a0c2-c82afb49762f" }, new List<string> { "01443b53-44f4-4793-bde2-df4a7aacf6ad" }));
		_dataArray.Add(new InteractionEventOptionItem(125, "4205fc5d-2eeb-4fa1-87f9-d0b12d8f15d3", -1, EInteractionEventOptionInteractionType.Special, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_125"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { -6, -6, -6, -6, -6 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 0, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "fb38f657-6ed0-41e4-a0c2-c82afb49762f" }, new List<string> { "4205fc5d-2eeb-4fa1-87f9-d0b12d8f15d3" }));
		_dataArray.Add(new InteractionEventOptionItem(126, "72ee5c31-5730-4a46-b0d4-ea6690573e29", -1, EInteractionEventOptionInteractionType.Practice, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_126"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { -6, -6, -6, -6, -6 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 0, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "a9d0bcd8-e378-4ee9-96a6-1e5b9db17371" }, new List<string> { "72ee5c31-5730-4a46-b0d4-ea6690573e29" }));
		_dataArray.Add(new InteractionEventOptionItem(127, "545aaa89-568f-4d93-8404-0342c32e8cfe", -1, EInteractionEventOptionInteractionType.Talk, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_127"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { -6, -6, -6, -6, -6 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 30, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "05e87c45-f14e-49ef-8769-cbaced4753ae" }, new List<string> { "545aaa89-568f-4d93-8404-0342c32e8cfe" }));
		_dataArray.Add(new InteractionEventOptionItem(128, "ed5fff3b-770a-4d16-8577-56233ff750df", -1, EInteractionEventOptionInteractionType.Identity, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_128"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { 3, 3, 3, 3, 3 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 50, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "fb38f657-6ed0-41e4-a0c2-c82afb49762f" }, new List<string> { "ed5fff3b-770a-4d16-8577-56233ff750df" }));
		_dataArray.Add(new InteractionEventOptionItem(129, "ad8dcb0b-cdb7-47af-95a4-45659c85e706", -1, EInteractionEventOptionInteractionType.Identity, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_129"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { 3, 3, 3, 3, 3 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 50, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "fb38f657-6ed0-41e4-a0c2-c82afb49762f" }, new List<string> { "ad8dcb0b-cdb7-47af-95a4-45659c85e706" }));
		_dataArray.Add(new InteractionEventOptionItem(130, "None", -1, EInteractionEventOptionInteractionType.Identity, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_130"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { 2, 2, 2, 2, 2 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 50, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "" }, new List<string> { "" }));
		_dataArray.Add(new InteractionEventOptionItem(131, "8ba68dca-6b4f-476a-a026-2cdf6e15300f", -1, EInteractionEventOptionInteractionType.Identity, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_131"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { 2, 2, 2, 2, 2 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 30, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "fb38f657-6ed0-41e4-a0c2-c82afb49762f" }, new List<string> { "8ba68dca-6b4f-476a-a026-2cdf6e15300f" }));
		_dataArray.Add(new InteractionEventOptionItem(132, "342bb50c-33b8-40bf-8717-11033ec9dd1d", -1, EInteractionEventOptionInteractionType.Identity, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_132"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { 2, 2, 2, 2, 2 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 100, 400, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "fb38f657-6ed0-41e4-a0c2-c82afb49762f" }, new List<string> { "342bb50c-33b8-40bf-8717-11033ec9dd1d" }));
		_dataArray.Add(new InteractionEventOptionItem(133, "None", -1, EInteractionEventOptionInteractionType.Identity, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_133"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { 2, 2, 2, 2, 2 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 100, 400, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "" }, new List<string> { "" }));
		_dataArray.Add(new InteractionEventOptionItem(134, "None", -1, EInteractionEventOptionInteractionType.Identity, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_134"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { 2, 2, 2, 2, 2 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 100, 300, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "" }, new List<string> { "" }));
		_dataArray.Add(new InteractionEventOptionItem(135, "None", -1, EInteractionEventOptionInteractionType.Identity, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_135"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { 2, 2, 2, 2, 2 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 100, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "" }, new List<string> { "" }));
		_dataArray.Add(new InteractionEventOptionItem(136, "474a30b4-4711-4906-84ff-1b3f34a4dc82", 136, EInteractionEventOptionInteractionType.Enemy, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_136"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: true, new sbyte[5] { -6, -6, -6, -6, -6 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 3, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "" }, new List<string> { "" }));
		_dataArray.Add(new InteractionEventOptionItem(137, "706f80ee-4454-444c-85f2-1bf75c06115b", 137, EInteractionEventOptionInteractionType.Special, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_137"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: true, new sbyte[5] { -6, -6, -6, -6, -6 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 5, 0, 4000, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "3d79705b-1245-4a8a-a45c-b2a8d5b2f02d" }, new List<string> { "706f80ee-4454-444c-85f2-1bf75c06115b" }));
		_dataArray.Add(new InteractionEventOptionItem(138, "c4a7c72f-a311-4f63-9929-a86895883beb", 137, EInteractionEventOptionInteractionType.Special, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_138"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: true, new sbyte[5] { -6, -6, -6, -6, -6 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 5, 0, 4000, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "3d79705b-1245-4a8a-a45c-b2a8d5b2f02d" }, new List<string> { "c4a7c72f-a311-4f63-9929-a86895883beb" }));
		_dataArray.Add(new InteractionEventOptionItem(139, "e00b25ae-009e-4d34-b99d-cf258df9cc01", -1, EInteractionEventOptionInteractionType.Identity, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_139"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: true, new sbyte[5], new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 30, 0, 0, new ResourceInts(0, 0, 0, 0, 300, 0, 0, 0), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "fb38f657-6ed0-41e4-a0c2-c82afb49762f" }, new List<string> { "e00b25ae-009e-4d34-b99d-cf258df9cc01" }));
		_dataArray.Add(new InteractionEventOptionItem(140, "aad3fa1c-5c6b-4f72-bd11-19644a2275bd", 140, EInteractionEventOptionInteractionType.Special, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_140"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5] { -6, -6, -6, -6, -6 }, new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 100, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "45b767f3-3d09-4502-bc94-6492c69c2e30" }, new List<string> { "aad3fa1c-5c6b-4f72-bd11-19644a2275bd" }));
		_dataArray.Add(new InteractionEventOptionItem(141, "0e173b97-3b81-4cc0-add0-53d635e02b8e", -1, EInteractionEventOptionInteractionType.Identity, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_141"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5], new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 0, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "fb38f657-6ed0-41e4-a0c2-c82afb49762f" }, new List<string> { "0e173b97-3b81-4cc0-add0-53d635e02b8e" }));
		_dataArray.Add(new InteractionEventOptionItem(142, "92466761-aab5-4304-bd51-70324c35a477", -1, EInteractionEventOptionInteractionType.Identity, LocalStringManager.GetConfig("InteractionEventOption_language", "Name_142"), EInteractionEventOptionTaiwuGroupStatus.Invalid, oncePerMonth: false, new sbyte[5], new sbyte[5] { 6, 6, 6, 6, 6 }, null, null, -1, 0, 0, 0, new ResourceInts(default(int), default(int), default(int), default(int), default(int), default(int), default(int), default(int)), new MainAttributes(default(short), default(short), default(short), default(short), default(short), default(short)), -1, -1, null, null, EInteractionEventOptionCompareConsummate.Invalid, null, null, ableAffectionate: false, ableNormalMarried: false, ableMonkMarried: false, -1, -1, ableChicken: false, EInteractionEventOptionAbleXiangshu.Invalid, EInteractionEventOptionIdentityAbility.Invalid, taiwuSecretInformation: false, -1, EInteractionEventOptionOrganizationSupport.Invalid, -1, teammateNumber: false, -1, -1, -1, -1, -1, -1, oneAdult: false, -1, -1, new List<short>(), new List<short>(), new List<short>(), ableOnOrganizationBlock: false, ableZhujian: false, ableJoinSect: false, ableReturnInfant: false, new List<string> { "fb38f657-6ed0-41e4-a0c2-c82afb49762f" }, new List<string> { "92466761-aab5-4304-bd51-70324c35a477" }));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<InteractionEventOptionItem>(143);
		CreateItems0();
		CreateItems1();
		CreateItems2();
	}
}
