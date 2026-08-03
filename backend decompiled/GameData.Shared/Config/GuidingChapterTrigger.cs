using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class GuidingChapterTrigger : ConfigData<GuidingChapterTriggerItem, short>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 过月后健康上限产生变动时
		/// </summary>
		public const short Trigger1 = 0;

		/// <summary>
		/// 过月发生一次天灾
		/// </summary>
		public const short Trigger2 = 1;

		/// <summary>
		/// 首次完成过月后
		/// </summary>
		public const short Trigger3 = 2;

		/// <summary>
		/// 首次来到促织生成的月份
		/// </summary>
		public const short Trigger4 = 3;

		/// <summary>
		/// 首次拥有任意绳索物品时
		/// </summary>
		public const short Trigger5 = 4;

		/// <summary>
		/// 首次获得已验明的淬毒道具
		/// </summary>
		public const short Trigger6 = 5;

		/// <summary>
		/// 首次获得验明毒素的装备
		/// </summary>
		public const short Trigger7 = 6;

		/// <summary>
		/// 首次获得信鸽道具时
		/// </summary>
		public const short Trigger8 = 7;

		/// <summary>
		/// 首次获得王蛊道具
		/// </summary>
		public const short Trigger9 = 8;

		/// <summary>
		/// 首次获得任意引子、精制材料时
		/// </summary>
		public const short Trigger10 = 9;

		/// <summary>
		/// 首次获得任意衣装时
		/// </summary>
		public const short Trigger11 = 10;

		/// <summary>
		/// 首次获得任意野兽代步时
		/// </summary>
		public const short Trigger12 = 11;

		/// <summary>
		/// 首次获得任意血露时
		/// </summary>
		public const short Trigger13 = 12;

		/// <summary>
		/// 首次获得任意心材时
		/// </summary>
		public const short Trigger14 = 13;

		/// <summary>
		/// 首次获得任意西域珍宝时
		/// </summary>
		public const short Trigger15 = 14;

		/// <summary>
		/// 首次获得任意书籍时
		/// </summary>
		public const short Trigger16 = 15;

		/// <summary>
		/// 首次获得任意神木种子时
		/// </summary>
		public const short Trigger18 = 16;

		/// <summary>
		/// 首次获得任意护具时
		/// </summary>
		public const short Trigger19 = 17;

		/// <summary>
		/// 首次获得任意工具时
		/// </summary>
		public const short Trigger20 = 18;

		/// <summary>
		/// 首次获得任意毒药
		/// </summary>
		public const short Trigger21 = 19;

		/// <summary>
		/// 首次获得任意带词条的装备时
		/// </summary>
		public const short Trigger22 = 20;

		/// <summary>
		/// 首次获得任意代步时
		/// </summary>
		public const short Trigger23 = 21;

		/// <summary>
		/// 首次获得任意兵器时
		/// </summary>
		public const short Trigger24 = 22;

		/// <summary>
		/// 首次获得任意宝物时
		/// </summary>
		public const short Trigger25 = 23;

		/// <summary>
		/// 首次获得精制材料时
		/// </summary>
		public const short Trigger26 = 24;

		/// <summary>
		/// 首次获得资源收入
		/// </summary>
		public const short Trigger27 = 25;

		/// <summary>
		/// 首次获得银钱收入
		/// </summary>
		public const short Trigger28 = 26;

		/// <summary>
		/// 首次获得威望收入
		/// </summary>
		public const short Trigger29 = 27;

		/// <summary>
		/// 与任意野兽进行互动
		/// </summary>
		public const short Trigger30 = 28;

		/// <summary>
		/// 与任意人物进行互动时
		/// </summary>
		public const short Trigger31 = 29;

		/// <summary>
		/// 首次与带有【铸剑试炼】的人物互动时
		/// </summary>
		public const short Trigger32 = 30;

		/// <summary>
		/// 首次与带有【州府法规】或【门派法规】的人物互动时
		/// </summary>
		public const short Trigger33 = 31;

		/// <summary>
		/// 首次与带有【玉镜沉思】的人物互动时
		/// </summary>
		public const short Trigger34 = 32;

		/// <summary>
		/// 首次与带有【血池秘法】的人物互动时
		/// </summary>
		public const short Trigger35 = 33;

		/// <summary>
		/// 首次与带有【五圣秘浴】的人物互动时
		/// </summary>
		public const short Trigger36 = 34;

		/// <summary>
		/// 首次与带有【委托暗杀】的人物互动时
		/// </summary>
		public const short Trigger37 = 35;

		/// <summary>
		/// 首次与带有【王禅典籍】的人物互动时
		/// </summary>
		public const short Trigger38 = 36;

		/// <summary>
		/// 首次与带有【天府之国】的人物互动时
		/// </summary>
		public const short Trigger39 = 37;

		/// <summary>
		/// 首次与带有【石牢静坐】的人物互动时
		/// </summary>
		public const short Trigger40 = 38;

		/// <summary>
		/// 首次与带有【散播威名】的人物互动时
		/// </summary>
		public const short Trigger41 = 39;

		/// <summary>
		/// 首次与带有【起死回生】的人物互动时
		/// </summary>
		public const short Trigger42 = 40;

		/// <summary>
		/// 首次与带有【七星调元】的人物互动时
		/// </summary>
		public const short Trigger43 = 41;

		/// <summary>
		/// 首次与带有【欧冶古具】的人物互动时
		/// </summary>
		public const short Trigger44 = 42;

		/// <summary>
		/// 首次与带有【面壁阅经】的人物互动时
		/// </summary>
		public const short Trigger45 = 43;

		/// <summary>
		/// 首次与带有【秘药延寿】的人物互动时
		/// </summary>
		public const short Trigger46 = 44;

		/// <summary>
		/// 首次与带有【龙岛忠仆】的人物互动时
		/// </summary>
		public const short Trigger47 = 45;

		/// <summary>
		/// 首次与带有【金刚秘法】的人物互动时
		/// </summary>
		public const short Trigger48 = 46;

		/// <summary>
		/// 首次与带有【荐送弟子】的人物互动时
		/// </summary>
		public const short Trigger49 = 47;

		/// <summary>
		/// 首次和下九流身份NPC交谈时
		/// </summary>
		public const short Trigger50 = 48;

		/// <summary>
		/// 首次和文人身份NPC交谈时
		/// </summary>
		public const short Trigger51 = 49;

		/// <summary>
		/// 首次和手艺人身份NPC交谈时
		/// </summary>
		public const short Trigger52 = 50;

		/// <summary>
		/// 首次和身为守卫的NPC互动（通过库房或者监牢和守卫互动也算)
		/// </summary>
		public const short Trigger53 = 51;

		/// <summary>
		/// 首次和商人身份NPC交谈时
		/// </summary>
		public const short Trigger54 = 52;

		/// <summary>
		/// 首次和任意势力上三阶人物交互
		/// </summary>
		public const short Trigger55 = 53;

		/// <summary>
		/// 首次和任意城镇一阶身份NPC交谈时
		/// </summary>
		public const short Trigger56 = 54;

		/// <summary>
		/// 首次和任意城镇二阶身份NPC交谈时
		/// </summary>
		public const short Trigger57 = 55;

		/// <summary>
		/// 首次和乞丐身份NPC交谈时
		/// </summary>
		public const short Trigger58 = 56;

		/// <summary>
		/// 首次和农户身份NPC交谈时
		/// </summary>
		public const short Trigger59 = 57;

		/// <summary>
		/// 首次和富豪身份NPC交谈时
		/// </summary>
		public const short Trigger60 = 58;

		/// <summary>
		/// 首次和大夫身份NPC交谈时
		/// </summary>
		public const short Trigger61 = 59;

		/// <summary>
		/// 首次到达任意存在地区剧情的地区
		/// </summary>
		public const short WorldStatusSectStory = 60;

		/// <summary>
		/// 首次达到存在任意较武奇遇的地区
		/// </summary>
		public const short ArriveAreaWithSectExam = 61;

		/// <summary>
		/// 首次进入诊疗界面
		/// </summary>
		public const short FirstEnterHeal = 62;

		/// <summary>
		/// 首次进入战斗界面
		/// </summary>
		public const short FirstEnterCombat = 63;

		/// <summary>
		/// 首次进入用药界面
		/// </summary>
		public const short FirstEnterViewUsingMedicine = 64;

		/// <summary>
		/// 首次进入天人感应界面
		/// </summary>
		public const short Trigger68 = 65;

		/// <summary>
		/// 首次进入世界地图界面时
		/// </summary>
		public const short FirstEnterPartWorldMap = 66;

		/// <summary>
		/// 首次进入任意商店界面
		/// </summary>
		public const short FirstEnterShop = 67;

		/// <summary>
		/// 首次进入任意揭示了喜恶的人物的人物属性界面
		/// </summary>
		public const short FirstEnterCharacterInfoWithLoveAndHate = 68;

		/// <summary>
		/// 首次进入人物属性界面
		/// </summary>
		public const short FirstEnterCharacterInfo = 69;

		/// <summary>
		/// 首次进入奇书奇遇时
		/// </summary>
		public const short Trigger73 = 70;

		/// <summary>
		/// 首次进入某个带库房的定居点的产业视图
		/// </summary>
		public const short Trigger74 = 71;

		/// <summary>
		/// 首次进入灵光一闪界面
		/// </summary>
		public const short FirstEnterReadingEvent = 72;

		/// <summary>
		/// 首次进入库房界面
		/// </summary>
		public const short FirstEnterTreasury = 73;

		/// <summary>
		/// 首次进入较艺准备界面
		/// </summary>
		public const short Trigger77 = 74;

		/// <summary>
		/// 首次进入技艺或武学造诣界面
		/// </summary>
		public const short FirstOpenUISkillAttainment = 75;

		/// <summary>
		/// 首次进入NPC的代制界面
		/// </summary>
		public const short FirstEnterViewCraftsmanForCharacter = 76;

		/// <summary>
		/// 首次进入【周天运转】界面
		/// </summary>
		public const short Trigger80 = 77;

		/// <summary>
		/// 首次进入【研读书籍】界面
		/// </summary>
		public const short FirstEnterReading = 78;

		/// <summary>
		/// 首次进入【突破玩法】界面
		/// </summary>
		public const short FirstOpenUISkillBreak = 79;

		/// <summary>
		/// 首次进入交换物资界面
		/// </summary>
		public const short FirstEnterExchange = 80;

		/// <summary>
		/// 首次进入【交换藏书】界面
		/// </summary>
		public const short FirstEnterBookExchange = 81;

		/// <summary>
		/// 首次点开任意资源点建筑界面
		/// </summary>
		public const short FirstEnterViewBuildingManageForResource = 82;

		/// <summary>
		/// 首次点开任意制造类任意建筑的界面
		/// </summary>
		public const short FirstEnterViewBuildingManageForMake = 83;

		/// <summary>
		/// 首次点开任意银钱威望/售卖建筑界面
		/// </summary>
		public const short FirstEnterViewBuildingManageForShop = 84;

		/// <summary>
		/// 首次点开能扩建的建筑界面
		/// </summary>
		public const short FirstEnterViewBuildingManageForExpand = 85;

		/// <summary>
		/// 首次打开族谱界面
		/// </summary>
		public const short FirstOpenUIGenealogy = 86;

		/// <summary>
		/// 首次打开造诣总览界面
		/// </summary>
		public const short FirstOpenUIAttainmentOverview = 87;

		/// <summary>
		/// 首次打开运功界面
		/// </summary>
		public const short Trigger90 = 88;

		/// <summary>
		/// 首次打开元鸡舍界面
		/// </summary>
		public const short FirstEnterViewBuildingManageForChicken = 89;

		/// <summary>
		/// 首次打开宴堂建筑的界面
		/// </summary>
		public const short FirstEnterViewBuildingManageForEntertain = 90;

		/// <summary>
		/// 首次打开悬赏榜界面
		/// </summary>
		public const short FirstEnterBounty = 91;

		/// <summary>
		/// 首次打开行囊时有食物类道具
		/// </summary>
		public const short FirstEnterViewCharacterMenuItemsWithFood = 92;

		/// <summary>
		/// 首次打开行囊时有毒药类道具
		/// </summary>
		public const short FirstEnterViewCharacterMenuItemsWithPoison = 93;

		/// <summary>
		/// 首次打开行囊时有丹药类道具
		/// </summary>
		public const short FirstEnterViewCharacterMenuItemsWithMedicine = 94;

		/// <summary>
		/// 首次打开太吾氏祠堂界面
		/// </summary>
		public const short FirstEnterViewBuildingManageForLineage = 95;

		/// <summary>
		/// 首次打开属性页签
		/// </summary>
		public const short FirstEnterCharacterAttribute = 96;

		/// <summary>
		/// 首次打开属性界面的轮回二级界面时
		/// </summary>
		public const short FirstEnterViewSamsara = 97;

		/// <summary>
		/// 首次打开势力界面
		/// </summary>
		public const short FirstEnterSettlementInformation = 98;

		/// <summary>
		/// 首次打开石屋界面
		/// </summary>
		public const short FirstOpenUIStoneHouse = 99;

		/// <summary>
		/// 首次打开身份说明界面
		/// </summary>
		public const short FirstOpenUIVillagerRoleDesc = 100;

		/// <summary>
		/// 首次打开伤病页签
		/// </summary>
		public const short FirstEnterCharacterInjury = 101;

		/// <summary>
		/// 首次打开任意制造建筑的【制造】功能界面
		/// </summary>
		public const short FirstEnterViewMakeForMake = 102;

		/// <summary>
		/// 首次打开任意制造建筑的【修理】功能界面
		/// </summary>
		public const short FirstEnterViewMakeForRepair = 103;

		/// <summary>
		/// 首次打开任意制造建筑的【精制】功能界面
		/// </summary>
		public const short FirstEnterViewMakeForRefine = 104;

		/// <summary>
		/// 首次打开任意制造建筑的【代制】功能界面
		/// </summary>
		public const short FirstEnterViewCraftsmanForBuilding = 105;

		/// <summary>
		/// 首次打开批量操作的【修理】页签
		/// </summary>
		public const short FirstEnterItemMultiplyOperationPanelForRepair = 106;

		/// <summary>
		/// 首次打开批量操作的【拆解】页签
		/// </summary>
		public const short FirstEnterItemMultiplyOperationPanelForDisassemble = 107;

		/// <summary>
		/// 首次打开人物属性界面
		/// </summary>
		public const short Trigger109 = 108;

		/// <summary>
		/// 首次打开人物的造诣总览/武学详情界面
		/// </summary>
		public const short FirstOpenUICharacterSkillSummary = 109;

		/// <summary>
		/// 首次打开奇书界面
		/// </summary>
		public const short FirstOpenUILegendaryBook = 110;

		/// <summary>
		/// 首次打开七级商店
		/// </summary>
		public const short FirstEnterLevel7Shop = 111;

		/// <summary>
		/// 首次打开内力界面
		/// </summary>
		public const short Trigger113 = 112;

		/// <summary>
		/// 首次打开铭刻界面
		/// </summary>
		public const short FirstEnterCheckInscription = 113;

		/// <summary>
		/// 首次打开轮回台界面
		/// </summary>
		public const short FirstEnterSamsaraPlatform = 114;

		/// <summary>
		/// 首次打开练功房界面
		/// </summary>
		public const short Trigger116 = 115;

		/// <summary>
		/// 首次打开居所界面时
		/// </summary>
		public const short FirstEnterViewBuildingManageForResidence = 116;

		/// <summary>
		/// 首次打开精挑细选界面
		/// </summary>
		public const short FirstEnterViewChoosyResource = 117;

		/// <summary>
		/// 首次打开经历界面
		/// </summary>
		public const short FirstEnterLifeSummary = 118;

		/// <summary>
		/// 首次打开建造总览界面
		/// </summary>
		public const short Trigger120 = 119;

		/// <summary>
		/// 首次打开建设空间的【资源】页签
		/// </summary>
		public const short Trigger121 = 120;

		/// <summary>
		/// 首次打开监牢建筑界面
		/// </summary>
		public const short FirstEnterViewBuildingManageForPrison = 121;

		/// <summary>
		/// 首次打开监牢功能界面
		/// </summary>
		public const short FirstEnterPrison = 122;

		/// <summary>
		/// 首次打开关系界面
		/// </summary>
		public const short Trigger124 = 123;

		/// <summary>
		/// 首次打开法规条文界面
		/// </summary>
		public const short FirstEnterViewSectLaw = 124;

		/// <summary>
		/// 首次打开促织陈列界面
		/// </summary>
		public const short Trigger126 = 125;

		/// <summary>
		/// 首次打开传承名谱界面
		/// </summary>
		public const short FirstOpenUIVillagerRole = 126;

		/// <summary>
		/// 首次打开持有九世轮回特性人物的人物属性界面
		/// </summary>
		public const short FirstEnterCharacterInfoWithFeatureReincarnationBonus = 127;

		/// <summary>
		/// 首次打开超出当前好感度的商店界面
		/// </summary>
		public const short FirstEnterOverFavorShop = 128;

		/// <summary>
		/// 首次打开茶马帮界面
		/// </summary>
		public const short FirstEnterTeaHorseCaravan = 129;

		/// <summary>
		/// 首次打开仓库建筑的界面
		/// </summary>
		public const short FirstEnterWarehouse = 130;

		/// <summary>
		/// 首次打开参悟玄机界面时
		/// </summary>
		public const short FirstEnterViewSkillBreakBonusSelect = 131;

		/// <summary>
		/// 首次打开不渝成年同道的人物属性界面
		/// </summary>
		public const short FirstEnterCharacterInfoGroupFavorite6 = 132;

		/// <summary>
		/// 首次打开【装备】界面
		/// </summary>
		public const short FirstEnterMenuEquipment = 133;

		/// <summary>
		/// 首次打开【突破】界面
		/// </summary>
		public const short Trigger135 = 134;

		/// <summary>
		/// 首次打开【解毒】功能界面
		/// </summary>
		public const short FirstEnterViewMakeForRemovePoison = 135;

		/// <summary>
		/// 首次打开【改制】功能界面
		/// </summary>
		public const short FirstEnterViewMakeForWeave = 136;

		/// <summary>
		/// 首次打开【淬毒】功能界面
		/// </summary>
		public const short FirstEnterViewMakeForAddPoison = 137;

		/// <summary>
		/// 首次打开【持有】界面
		/// </summary>
		public const short FirstEnterViewCharacterMenuItems = 138;

		/// <summary>
		/// 进入任意奇遇
		/// </summary>
		public const short Trigger140 = 139;

		/// <summary>
		/// 打开石屋首次有失心人存在时
		/// </summary>
		public const short OpenUIStoneHouseWithFallen = 140;

		/// <summary>
		/// 打开人物的造诣总览/技艺详情界面
		/// </summary>
		public const short OpenUICharacterSkillSummary = 141;

		/// <summary>
		/// 初次进入太吾村产业视图
		/// </summary>
		public const short Trigger143 = 142;

		/// <summary>
		/// 初次进入任意产业视图
		/// </summary>
		public const short Trigger144 = 143;

		/// <summary>
		/// 初次进入产业规划界面
		/// </summary>
		public const short Trigger145 = 144;

		/// <summary>
		/// 战斗准备己方/敌方产生一次负面指令
		/// </summary>
		public const short Trigger146 = 145;

		/// <summary>
		/// 战斗中携带的摧破首次满足释放条件
		/// </summary>
		public const short CombatAttackSkillCanCast = 146;

		/// <summary>
		/// 战斗中受到任意伤害积累时
		/// </summary>
		public const short CombatAcceptAnyDamage = 147;

		/// <summary>
		/// 战斗中首次打开使用物品界面
		/// </summary>
		public const short FirstEnterCombatUseItemPanel = 148;

		/// <summary>
		/// 战斗中己方或对方遭到功法反噬
		/// </summary>
		public const short CombatGoneMadInjury = 149;

		/// <summary>
		/// 战斗首次让敌方进入到兵器攻击范围
		/// </summary>
		public const short CombatInAttackRange = 150;

		/// <summary>
		/// 在可以逃跑的战斗类型中己方战败标记超过一半时
		/// </summary>
		public const short CombatCanFleeHalfFallen = 151;

		/// <summary>
		/// 用普攻或摧破命中敌人要害时
		/// </summary>
		public const short CombatCritical = 152;

		/// <summary>
		/// 通过功法使对方拥有蛊虫
		/// </summary>
		public const short CombatAddWugBySkill = 153;

		/// <summary>
		/// 跳出处决确认按钮时
		/// </summary>
		public const short FirstMercyButton = 154;

		/// <summary>
		/// 首个身法或腿法可施展时
		/// </summary>
		public const short CombatAgileOrLegSkillCanCast = 155;

		/// <summary>
		/// 己方或者敌方首次掉血时
		/// </summary>
		public const short Trigger157 = 156;

		/// <summary>
		/// 己方或敌方首次产生战败标记
		/// </summary>
		public const short CombatAnyMark = 157;

		/// <summary>
		/// 己方服食栏首次出现任意蛊虫
		/// </summary>
		public const short CombatAcceptWug = 158;

		/// <summary>
		/// 己方/敌方形成一个重创标记
		/// </summary>
		public const short CombatFatalMark = 159;

		/// <summary>
		/// 己方/敌方形成一个失神标记
		/// </summary>
		public const short CombatMindMark = 160;

		/// <summary>
		/// 己方/敌方形成一个任意真气标记
		/// </summary>
		public const short CombatNeiliAllocationMark = 161;

		/// <summary>
		/// 己方/敌方形成一个任意外伤/内伤标记
		/// </summary>
		public const short CombatInjuryMark = 162;

		/// <summary>
		/// 己方/敌方形成一个任意内息标记
		/// </summary>
		public const short CombatQiDisorderMark = 163;

		/// <summary>
		/// 己方/敌方形成一个任意健康标记
		/// </summary>
		public const short CombatHealthMark = 164;

		/// <summary>
		/// 己方/敌方形成一个任意减益标记
		/// </summary>
		public const short CombatStateMark = 165;

		/// <summary>
		/// 己方/敌方形成一个任意蛊虫标记
		/// </summary>
		public const short CombatWugMark = 166;

		/// <summary>
		/// 己方/敌方形成一个任意毒素标记
		/// </summary>
		public const short CombatPoisonMark = 167;

		/// <summary>
		/// 己方/敌方形成一个破绽标记
		/// </summary>
		public const short CombatFlawMark = 168;

		/// <summary>
		/// 己方/敌方形成一个封穴标记
		/// </summary>
		public const short CombatAcupointMark = 169;

		/// <summary>
		/// 己方/敌方释放任意带反震效果的护体
		/// </summary>
		public const short CombatCastBounceDefendSkill = 170;

		/// <summary>
		/// 己方/敌方释放任意带反击效果的护体
		/// </summary>
		public const short CombatCastFightBackDefendSkill = 171;

		/// <summary>
		/// 己方/敌方施展完毕任意一个摧破功法
		/// </summary>
		public const short CombatCastAttackSkill = 172;

		/// <summary>
		/// 己方/敌方任意一个真气达到异常状态
		/// </summary>
		public const short CombatNeiliAllocationAnyStatus = 173;

		/// <summary>
		/// 己方/敌方任意一个功法被封禁
		/// </summary>
		public const short CombatSkillSilence = 174;

		/// <summary>
		/// 在主界面进行一次移动
		/// </summary>
		public const short MapMove = 175;

		/// <summary>
		/// 移动到有促织的地格上
		/// </summary>
		public const short MapMoveInCricket = 176;

		/// <summary>
		/// 移动到埋有物品的地格上时
		/// </summary>
		public const short MapMoveInTreasure = 177;

		/// <summary>
		/// 首次来到任意定居点地格
		/// </summary>
		public const short MapMoveInSettlement = 178;

		/// <summary>
		/// 太吾到达某个门派的定居点地格
		/// </summary>
		public const short MapMoveInSect = 179;

		/// <summary>
		/// 首次到达少林派定居点
		/// </summary>
		public const short MapMoveInSectShaolin = 180;

		/// <summary>
		/// 首次到达峨眉派定居点
		/// </summary>
		public const short MapMoveInSectEmei = 181;

		/// <summary>
		/// 首次到达百花谷定居点
		/// </summary>
		public const short MapMoveInSectBaihua = 182;

		/// <summary>
		/// 首次到达武当派定居点
		/// </summary>
		public const short MapMoveInSectWudang = 183;

		/// <summary>
		/// 首次到达元山派定居点
		/// </summary>
		public const short MapMoveInSectYuanshan = 184;

		/// <summary>
		/// 首次到达狮相门定居点
		/// </summary>
		public const short MapMoveInSectShixiang = 185;

		/// <summary>
		/// 首次到达然山派定居点
		/// </summary>
		public const short MapMoveInSectRanshan = 186;

		/// <summary>
		/// 首次到达璇女派定居点
		/// </summary>
		public const short MapMoveInSectXuannv = 187;

		/// <summary>
		/// 首次到达铸剑山庄定居点
		/// </summary>
		public const short MapMoveInSectZhujian = 188;

		/// <summary>
		/// 首次到达空桑派定居点
		/// </summary>
		public const short MapMoveInSectKongsang = 189;

		/// <summary>
		/// 首次到达金刚宗定居点
		/// </summary>
		public const short MapMoveInSectJingang = 190;

		/// <summary>
		/// 首次到达五仙教定居点
		/// </summary>
		public const short MapMoveInSectWuxian = 191;

		/// <summary>
		/// 首次到达界青门定居点
		/// </summary>
		public const short MapMoveInSectJieqing = 192;

		/// <summary>
		/// 首次到达伏龙坛定居点
		/// </summary>
		public const short MapMoveInSectFulong = 193;

		/// <summary>
		/// 首次到达血犼教定居点
		/// </summary>
		public const short MapMoveInSectXuehou = 194;

		/// <summary>
		/// 首次到达太吾村地格
		/// </summary>
		public const short MapMoveInTaiwuVillage = 195;

		/// <summary>
		/// 首次到达存在沾染玄灰的人所在的地格
		/// </summary>
		public const short MapMoveInAsh = 196;

		/// <summary>
		/// 首次到达存在任意爪牙的地格
		/// </summary>
		public const short MapMoveInXiangshuMinion = 197;

		/// <summary>
		/// 首次到达存在任意外道或义士的地格
		/// </summary>
		public const short MapMoveInHereticOrRighteous = 198;

		/// <summary>
		/// 首次到达存在任意商队的地格
		/// </summary>
		public const short MapMoveInMerchant = 199;

		/// <summary>
		/// 到达任意一个非太吾村定居点地格
		/// </summary>
		public const short MapMoveInCity = 200;

		/// <summary>
		/// 首次走到有拾取物的地格上
		/// </summary>
		public const short MapMoveInPickup = 201;

		/// <summary>
		/// 完成奇书宝典解锁事件后
		/// </summary>
		public const short Trigger204 = 202;

		/// <summary>
		/// 太吾或配偶孩子出生事件结束
		/// </summary>
		public const short Trigger205 = 203;

		/// <summary>
		/// 太吾触发旅行地图门派事件
		/// </summary>
		public const short Trigger206 = 204;

		/// <summary>
		/// 首次与罪犯NPC互动
		/// </summary>
		public const short Trigger207 = 205;

		/// <summary>
		/// 首次与任意坟墓互动
		/// </summary>
		public const short Trigger208 = 206;

		/// <summary>
		/// 首次为其他NPC修建坟墓
		/// </summary>
		public const short Trigger209 = 207;

		/// <summary>
		/// 首次完成玄石紫竹奇遇后
		/// </summary>
		public const short Trigger210 = 208;

		/// <summary>
		/// 首次进入任意门派弟子的【修习】交互
		/// </summary>
		public const short Trigger211 = 209;

		/// <summary>
		/// 首次获得门派支持度（也就是拜访事件后）
		/// </summary>
		public const short Trigger212 = 210;

		/// <summary>
		/// 首次过月触发奇书降世奇遇时
		/// </summary>
		public const short Trigger213 = 211;

		/// <summary>
		/// 任意化身破冢后
		/// </summary>
		public const short SwordTombInvasion = 212;

		/// <summary>
		/// 开通太吾村地区的驿站
		/// </summary>
		public const short Trigger215 = 213;

		/// <summary>
		/// 剑冢出现事件结束后
		/// </summary>
		public const short Trigger216 = 214;

		/// <summary>
		/// 打开人物的【修习】互动时
		/// </summary>
		public const short Trigger217 = 215;

		/// <summary>
		/// 打开人物的【请教武学】互动时
		/// </summary>
		public const short Trigger218 = 216;

		/// <summary>
		/// 打开人物的【请教技艺】互动时
		/// </summary>
		public const short Trigger219 = 217;

		/// <summary>
		/// 打开人物的【亲近】互动时
		/// </summary>
		public const short Trigger220 = 218;

		/// <summary>
		/// 打开人物的【交谈】互动时
		/// </summary>
		public const short Trigger221 = 219;

		/// <summary>
		/// 打开人物的【敌对】互动时
		/// </summary>
		public const short Trigger222 = 220;

		/// <summary>
		/// 打开人物的【比试】互动时
		/// </summary>
		public const short Trigger223 = 221;

		/// <summary>
		/// 志向解锁事件结束后
		/// </summary>
		public const short Trigger224 = 222;

		/// <summary>
		/// 首次选择带立场的选项时
		/// </summary>
		public const short Trigger225 = 223;

		/// <summary>
		/// 装备重量超出负重上限时
		/// </summary>
		public const short EquipOverload = 224;

		/// <summary>
		/// 战斗中遭遇相枢爪牙
		/// </summary>
		public const short Trigger227 = 225;

		/// <summary>
		/// 在主界面移动时揭示一次地格
		/// </summary>
		public const short MapMoveShowBlock = 226;

		/// <summary>
		/// 在运功界面装配任意奇窍功法
		/// </summary>
		public const short Trigger229 = 227;

		/// <summary>
		/// 在所处地区存在奇遇时
		/// </summary>
		public const short MapMoveInAdventure = 228;

		/// <summary>
		/// 在死斗中击败敌人后
		/// </summary>
		public const short CombatWinDie = 229;

		/// <summary>
		/// 拥有一名相互爱慕的对象或者配偶
		/// </summary>
		public const short Trigger232 = 230;

		/// <summary>
		/// 拥有第一个同道时
		/// </summary>
		public const short Trigger233 = 231;

		/// <summary>
		/// 拥有第一个俘虏时
		/// </summary>
		public const short Trigger234 = 232;

		/// <summary>
		/// 已装备的物品首次耐久到达20%及以下时
		/// </summary>
		public const short Trigger235 = 233;

		/// <summary>
		/// 行囊负重超过上限时
		/// </summary>
		public const short WorldStatusTaiwuOverload = 234;

		/// <summary>
		/// 下一次可以连接到玄机格时
		/// </summary>
		public const short CanLinkToBonusCell = 235;

		/// <summary>
		/// 通过研读首次习得功法
		/// </summary>
		public const short Trigger238 = 236;

		/// <summary>
		/// 太吾自身首次在战斗外触发混合毒素效果
		/// </summary>
		public const short Trigger239 = 237;

		/// <summary>
		/// 太吾自身怀孕或者配偶怀孕
		/// </summary>
		public const short Trigger240 = 238;

		/// <summary>
		/// 太吾首次入邪
		/// </summary>
		public const short Trigger241 = 239;

		/// <summary>
		/// 太吾首次被通缉
		/// </summary>
		public const short Trigger242 = 240;

		/// <summary>
		/// 太吾氏祠堂建造完毕
		/// </summary>
		public const short Trigger243 = 241;

		/// <summary>
		/// 太吾或同道到达超重状态
		/// </summary>
		public const short WorldStatusOverload = 242;

		/// <summary>
		/// 太吾持有至少一世轮回时打开太吾的人物属性界面
		/// </summary>
		public const short FirstEnterCharacterInfoSamsaraCount1 = 243;

		/// <summary>
		/// 首个剧情剑冢拔除
		/// </summary>
		public const short Trigger246 = 244;

		/// <summary>
		/// 首次装配着任意轻灵功法进入战斗
		/// </summary>
		public const short CombatEquipAgile = 245;

		/// <summary>
		/// 首次主动仇恨其他人
		/// </summary>
		public const short FirstHate = 246;

		/// <summary>
		/// 首次主动爱慕其他人
		/// </summary>
		public const short FirstLove = 247;

		/// <summary>
		/// 首次种下任意神木种子时
		/// </summary>
		public const short FirstPlantHeavenlyTree = 248;

		/// <summary>
		/// 首次正式开始任意较艺决斗
		/// </summary>
		public const short Trigger251 = 249;

		/// <summary>
		/// 首次在助战同道栏放置同道
		/// </summary>
		public const short ArrangeTeammate = 250;

		/// <summary>
		/// 首次在战斗中己方或对方触发混合毒素
		/// </summary>
		public const short CombatMixPoisonAffect = 251;

		/// <summary>
		/// 首次在战斗中己方或对方触发毒素发作效果或者混合毒素发作效果
		/// </summary>
		public const short CombatPoisonAffect = 252;

		/// <summary>
		/// 首次在拥有任意一个技能的情况下打开志向界面
		/// </summary>
		public const short FirstEnterProfessionWithSkill = 253;

		/// <summary>
		/// 首次在交互时与他人的戒心产生变化时
		/// </summary>
		public const short FirstChangeAlertness = 254;

		/// <summary>
		/// 首次在交互时与他人的好感产生变化时
		/// </summary>
		public const short FirstChangeFavorability = 255;

		/// <summary>
		/// 首次与失心人进行战斗
		/// </summary>
		public const short Trigger258 = 256;

		/// <summary>
		/// 首次与某人好感度达到亲密
		/// </summary>
		public const short FirstChangeFavorabilityToFavorite5 = 257;

		/// <summary>
		/// 首次选中任意策略卡时
		/// </summary>
		public const short FirstSelectDebateCard = 258;

		/// <summary>
		/// 首次悬停任意身法/护体/摧破类功法的Tips
		/// </summary>
		public const short FirstEnterCombatTipEquipTypeAttackAgileDefense = 259;

		/// <summary>
		/// 首次悬停任意功法的Tips
		/// </summary>
		public const short FirstEnterCombatTip = 260;

		/// <summary>
		/// 首次悬停任意【护具】Tips时
		/// </summary>
		public const short FirstShowTipForArmor = 261;

		/// <summary>
		/// 首次悬停任意【代步】Tips时
		/// </summary>
		public const short FirstShowTipForCarrier = 262;

		/// <summary>
		/// 首次悬停任意【兵器】Tips时
		/// </summary>
		public const short FirstShowTipForWeapon = 263;

		/// <summary>
		/// 首次形成冲克的内力
		/// </summary>
		public const short FirstFiveElementConflict = 264;

		/// <summary>
		/// 首次消耗了任意属性后
		/// </summary>
		public const short CostMainAttribute = 265;

		/// <summary>
		/// 首次完成功法书籍的研读
		/// </summary>
		public const short FirstFinishReadingCombatSkillBook = 266;

		/// <summary>
		/// 首次提升精纯
		/// </summary>
		public const short Trigger269 = 267;

		/// <summary>
		/// 首次太吾自己的心情产生变化时
		/// </summary>
		public const short Trigger270 = 268;

		/// <summary>
		/// 首次双方距离达到或超过10时
		/// </summary>
		public const short CombatDistanceMoreOrEqual = 269;

		/// <summary>
		/// 首次受到淬毒道具影响
		/// </summary>
		public const short FirstAffectedByPoisonedItem = 270;

		/// <summary>
		/// 首次身上带有毒素
		/// </summary>
		public const short Trigger273 = 271;

		/// <summary>
		/// 首次内息到达逆阻
		/// </summary>
		public const short Trigger274 = 272;

		/// <summary>
		/// 首次某个非腿法摧破或护体可施展时
		/// </summary>
		public const short CombatDefendOrNotLegAttackSkillCanCast = 273;

		/// <summary>
		/// 首次累积满1次变招进度
		/// </summary>
		public const short CombatCanChangeTrick = 274;

		/// <summary>
		/// 首次开启促织决斗时
		/// </summary>
		public const short FirstEnterCricketCombat = 275;

		/// <summary>
		/// 首次精力少于5的时候
		/// </summary>
		public const short TimeBallAcuPointLessThan5 = 276;

		/// <summary>
		/// 首次精力少于10的时候
		/// </summary>
		public const short TimeBallAcuPointLessThan10 = 277;

		/// <summary>
		/// 首次进行功法精解
		/// </summary>
		public const short Trigger281 = 278;

		/// <summary>
		/// 首次进行兵器攻击后
		/// </summary>
		public const short CombatNormalAttack = 279;

		/// <summary>
		/// 首次进入战斗准备环节
		/// </summary>
		public const short FirstEnterCombatBegin = 280;

		/// <summary>
		/// 首次进入战斗结算环节
		/// </summary>
		public const short FirstEnterCombatResult = 281;

		/// <summary>
		/// 首次进入战斗环节
		/// </summary>
		public const short Trigger285 = 282;

		/// <summary>
		/// 首次解锁紫竹故事最后一篇后
		/// </summary>
		public const short Trigger286 = 283;

		/// <summary>
		/// 首次结束一场促织决斗时
		/// </summary>
		public const short FirstEnterCricketCombatResult = 284;

		/// <summary>
		/// 首次结束突破（包括成功/失败/退出界面）
		/// </summary>
		public const short FirstExitUISkillBreak = 285;

		/// <summary>
		/// 首次建造任意经营建筑
		/// </summary>
		public const short Trigger289 = 286;

		/// <summary>
		/// 首次建设空间到达上限
		/// </summary>
		public const short Trigger290 = 287;

		/// <summary>
		/// 首次获取伏虞心念后
		/// </summary>
		public const short FirstTimeObtainFuyuFaith = 288;

		/// <summary>
		/// 首次获得新的名誉词条时
		/// </summary>
		public const short Trigger292 = 289;

		/// <summary>
		/// 首次获得王蛊
		/// </summary>
		public const short FirstGetWugKing = 290;

		/// <summary>
		/// 首次获得任意志向见闻
		/// </summary>
		public const short Trigger294 = 291;

		/// <summary>
		/// 首次获得任意蓄式时
		/// </summary>
		public const short CombatAddAnyTrick = 292;

		/// <summary>
		/// 首次获得任意西域见闻
		/// </summary>
		public const short Trigger296 = 293;

		/// <summary>
		/// 首次获得任意同道时（包含谷密）
		/// </summary>
		public const short Trigger297 = 294;

		/// <summary>
		/// 首次获得任意门派见闻
		/// </summary>
		public const short Trigger298 = 295;

		/// <summary>
		/// 首次获得任意较艺策略
		/// </summary>
		public const short FirstUnlockDebateStrategy = 296;

		/// <summary>
		/// 首次获得任意剑冢见闻
		/// </summary>
		public const short Trigger300 = 297;

		/// <summary>
		/// 首次获得任意见闻
		/// </summary>
		public const short Trigger301 = 298;

		/// <summary>
		/// 首次获得任意技艺见闻
		/// </summary>
		public const short Trigger302 = 299;

		/// <summary>
		/// 首次获得任意地区恩义时
		/// </summary>
		public const short Trigger303 = 300;

		/// <summary>
		/// 首次获得任意地方见闻
		/// </summary>
		public const short Trigger304 = 301;

		/// <summary>
		/// 首次获得历练收入
		/// </summary>
		public const short Trigger305 = 302;

		/// <summary>
		/// 关闭研读界面时研读的是武学书籍
		/// </summary>
		public const short CloseReadingWithCombatSkillBook = 303;

		/// <summary>
		/// 首次对对方造成任意直接伤害
		/// </summary>
		public const short CombatMakeDirectDamage = 304;

		/// <summary>
		/// 首次点亮新的太吾村石碑
		/// </summary>
		public const short FirstUnlockVowStele = 305;

		/// <summary>
		/// 首次触发天人感应
		/// </summary>
		public const short HaveLoopingBonus = 306;

		/// <summary>
		/// 首次触发灵光一闪
		/// </summary>
		public const short HaveReadingBonus = 307;

		/// <summary>
		/// 首次出现奇书入邪者时
		/// </summary>
		public const short Trigger312 = 308;

		/// <summary>
		/// 首次被其他人仇恨
		/// </summary>
		public const short Trigger313 = 309;

		/// <summary>
		/// 首次被其他人爱慕
		/// </summary>
		public const short Trigger314 = 310;

		/// <summary>
		/// 剩余至少1精力时选择过月
		/// </summary>
		public const short TimeBallPassMonthWithAcuPointRemain = 311;

		/// <summary>
		/// 商店界面首次出现任意高价商品、季节性商品、诸会宝号商品
		/// </summary>
		public const short ShopHasExtraGoods = 312;

		/// <summary>
		/// 任意一方的压力增长时
		/// </summary>
		public const short Trigger317 = 313;

		/// <summary>
		/// 任意同道首次入邪
		/// </summary>
		public const short Trigger318 = 314;

		/// <summary>
		/// 任意建筑受损时
		/// </summary>
		public const short Trigger319 = 315;

		/// <summary>
		/// 连接次数超过天资上限一半时
		/// </summary>
		public const short SkillBreakPlateOverHalf = 316;

		/// <summary>
		/// 进行过一次主动研读或周天
		/// </summary>
		public const short ActiveLoopOrReadTriggered = 317;

		/// <summary>
		/// 解锁志向有成技能时
		/// </summary>
		public const short FirstUnlockProfessionExtraSkill = 318;

		/// <summary>
		/// 解锁了传剑功能时
		/// </summary>
		public const short UnlockSwordLegacy = 319;

		/// <summary>
		/// 解锁采集功能后
		/// </summary>
		public const short UnlockCollectResource = 320;

		/// <summary>
		/// 解封到达100%进度且带有生铸效果
		/// </summary>
		public const short CombatCanUnlockAttackWithRawCreate = 321;

		/// <summary>
		/// 结束任意一场较艺时
		/// </summary>
		public const short Trigger327 = 322;

		/// <summary>
		/// 己方/敌方携带任意带解封效果的功法进入战斗
		/// </summary>
		public const short CombatUnlockAttackSkill = 323;

		/// <summary>
		/// 获取遗惠点数达到100
		/// </summary>
		public const short Trigger329 = 324;

		/// <summary>
		/// 获取任意生平遗惠时
		/// </summary>
		public const short Trigger330 = 325;

		/// <summary>
		/// 获得一只促织时
		/// </summary>
		public const short Trigger331 = 326;

		/// <summary>
		/// 关闭研读界面时研读的是技艺书籍
		/// </summary>
		public const short CloseReadingWithLifeSkillBook = 327;

		/// <summary>
		/// 发生首次论点冲突后
		/// </summary>
		public const short Trigger333 = 328;

		/// <summary>
		/// 对方使用功法让己方拥有蛊虫
		/// </summary>
		public const short CombatAcceptWugBySkill = 329;

		/// <summary>
		/// 对方开始施展任意摧破
		/// </summary>
		public const short CombatEnemyCastAttackSkill = 330;

		/// <summary>
		/// 当前健康以任意原因下降时
		/// </summary>
		public const short Trigger337 = 331;

		/// <summary>
		/// 存在任意没有入住居所的村民时
		/// </summary>
		public const short Trigger338 = 332;

		/// <summary>
		/// 触发一次指令清除CD效果
		/// </summary>
		public const short CombatTeammateCommandSkipCd = 333;

		/// <summary>
		/// 触发任意一个剑冢的二阶段后
		/// </summary>
		public const short CombatBossAddPhase = 334;

		/// <summary>
		/// 被敌人命中要害时
		/// </summary>
		public const short CombatAcceptCritical = 335;

		/// <summary>
		/// 诛魔试炼
		/// </summary>
		public const short Trigger342 = 336;

		/// <summary>
		/// 罗汉开悟
		/// </summary>
		public const short Trigger343 = 337;

		/// <summary>
		/// 独创心法
		/// </summary>
		public const short Trigger344 = 338;

		/// <summary>
		/// 生关死节
		/// </summary>
		public const short Trigger345 = 339;

		/// <summary>
		/// 改正修逆
		/// </summary>
		public const short Trigger346 = 340;

		/// <summary>
		/// 移宫易穴
		/// </summary>
		public const short Trigger347 = 341;

		/// <summary>
		/// 统筹方略
		/// </summary>
		public const short Trigger348 = 342;

		/// <summary>
		/// 寄托奇书
		/// </summary>
		public const short Trigger349 = 343;

		/// <summary>
		/// 孤鸾镜水谣
		/// </summary>
		public const short Trigger350 = 344;

		/// <summary>
		/// 造化生人
		/// </summary>
		public const short Trigger351 = 345;

		/// <summary>
		/// 天外游历
		/// </summary>
		public const short Trigger352 = 346;

		/// <summary>
		/// 天枢玄铸
		/// </summary>
		public const short Trigger353 = 347;

		/// <summary>
		/// 驱使古鼎
		/// </summary>
		public const short Trigger354 = 348;

		/// <summary>
		/// 鼎蛟淬身
		/// </summary>
		public const short Trigger355 = 349;

		/// <summary>
		/// 化魂仪式
		/// </summary>
		public const short Trigger356 = 350;

		/// <summary>
		/// 炼制王蛊
		/// </summary>
		public const short Trigger357 = 351;

		/// <summary>
		/// 驱动王蛊
		/// </summary>
		public const short Trigger358 = 352;

		/// <summary>
		/// 奇纹星斗
		/// </summary>
		public const short Trigger359 = 353;

		/// <summary>
		/// 调遣元鸡
		/// </summary>
		public const short Trigger360 = 354;

		/// <summary>
		/// 元鸡灵羽
		/// </summary>
		public const short Trigger361 = 355;

		/// <summary>
		/// 姬穸随行
		/// </summary>
		public const short Trigger362 = 356;

		/// <summary>
		/// 持印汲气
		/// </summary>
		public const short Trigger363 = 357;

		/// <summary>
		/// 三才护阵
		/// </summary>
		public const short Trigger364 = 358;

		/// <summary>
		/// 三魔乱阵
		/// </summary>
		public const short Trigger365 = 359;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 过月后健康上限产生变动时
		/// </summary>
		public static GuidingChapterTriggerItem Trigger1 => Instance[(short)0];

		/// <summary>
		/// 过月发生一次天灾
		/// </summary>
		public static GuidingChapterTriggerItem Trigger2 => Instance[(short)1];

		/// <summary>
		/// 首次完成过月后
		/// </summary>
		public static GuidingChapterTriggerItem Trigger3 => Instance[(short)2];

		/// <summary>
		/// 首次来到促织生成的月份
		/// </summary>
		public static GuidingChapterTriggerItem Trigger4 => Instance[(short)3];

		/// <summary>
		/// 首次拥有任意绳索物品时
		/// </summary>
		public static GuidingChapterTriggerItem Trigger5 => Instance[(short)4];

		/// <summary>
		/// 首次获得已验明的淬毒道具
		/// </summary>
		public static GuidingChapterTriggerItem Trigger6 => Instance[(short)5];

		/// <summary>
		/// 首次获得验明毒素的装备
		/// </summary>
		public static GuidingChapterTriggerItem Trigger7 => Instance[(short)6];

		/// <summary>
		/// 首次获得信鸽道具时
		/// </summary>
		public static GuidingChapterTriggerItem Trigger8 => Instance[(short)7];

		/// <summary>
		/// 首次获得王蛊道具
		/// </summary>
		public static GuidingChapterTriggerItem Trigger9 => Instance[(short)8];

		/// <summary>
		/// 首次获得任意引子、精制材料时
		/// </summary>
		public static GuidingChapterTriggerItem Trigger10 => Instance[(short)9];

		/// <summary>
		/// 首次获得任意衣装时
		/// </summary>
		public static GuidingChapterTriggerItem Trigger11 => Instance[(short)10];

		/// <summary>
		/// 首次获得任意野兽代步时
		/// </summary>
		public static GuidingChapterTriggerItem Trigger12 => Instance[(short)11];

		/// <summary>
		/// 首次获得任意血露时
		/// </summary>
		public static GuidingChapterTriggerItem Trigger13 => Instance[(short)12];

		/// <summary>
		/// 首次获得任意心材时
		/// </summary>
		public static GuidingChapterTriggerItem Trigger14 => Instance[(short)13];

		/// <summary>
		/// 首次获得任意西域珍宝时
		/// </summary>
		public static GuidingChapterTriggerItem Trigger15 => Instance[(short)14];

		/// <summary>
		/// 首次获得任意书籍时
		/// </summary>
		public static GuidingChapterTriggerItem Trigger16 => Instance[(short)15];

		/// <summary>
		/// 首次获得任意神木种子时
		/// </summary>
		public static GuidingChapterTriggerItem Trigger18 => Instance[(short)16];

		/// <summary>
		/// 首次获得任意护具时
		/// </summary>
		public static GuidingChapterTriggerItem Trigger19 => Instance[(short)17];

		/// <summary>
		/// 首次获得任意工具时
		/// </summary>
		public static GuidingChapterTriggerItem Trigger20 => Instance[(short)18];

		/// <summary>
		/// 首次获得任意毒药
		/// </summary>
		public static GuidingChapterTriggerItem Trigger21 => Instance[(short)19];

		/// <summary>
		/// 首次获得任意带词条的装备时
		/// </summary>
		public static GuidingChapterTriggerItem Trigger22 => Instance[(short)20];

		/// <summary>
		/// 首次获得任意代步时
		/// </summary>
		public static GuidingChapterTriggerItem Trigger23 => Instance[(short)21];

		/// <summary>
		/// 首次获得任意兵器时
		/// </summary>
		public static GuidingChapterTriggerItem Trigger24 => Instance[(short)22];

		/// <summary>
		/// 首次获得任意宝物时
		/// </summary>
		public static GuidingChapterTriggerItem Trigger25 => Instance[(short)23];

		/// <summary>
		/// 首次获得精制材料时
		/// </summary>
		public static GuidingChapterTriggerItem Trigger26 => Instance[(short)24];

		/// <summary>
		/// 首次获得资源收入
		/// </summary>
		public static GuidingChapterTriggerItem Trigger27 => Instance[(short)25];

		/// <summary>
		/// 首次获得银钱收入
		/// </summary>
		public static GuidingChapterTriggerItem Trigger28 => Instance[(short)26];

		/// <summary>
		/// 首次获得威望收入
		/// </summary>
		public static GuidingChapterTriggerItem Trigger29 => Instance[(short)27];

		/// <summary>
		/// 与任意野兽进行互动
		/// </summary>
		public static GuidingChapterTriggerItem Trigger30 => Instance[(short)28];

		/// <summary>
		/// 与任意人物进行互动时
		/// </summary>
		public static GuidingChapterTriggerItem Trigger31 => Instance[(short)29];

		/// <summary>
		/// 首次与带有【铸剑试炼】的人物互动时
		/// </summary>
		public static GuidingChapterTriggerItem Trigger32 => Instance[(short)30];

		/// <summary>
		/// 首次与带有【州府法规】或【门派法规】的人物互动时
		/// </summary>
		public static GuidingChapterTriggerItem Trigger33 => Instance[(short)31];

		/// <summary>
		/// 首次与带有【玉镜沉思】的人物互动时
		/// </summary>
		public static GuidingChapterTriggerItem Trigger34 => Instance[(short)32];

		/// <summary>
		/// 首次与带有【血池秘法】的人物互动时
		/// </summary>
		public static GuidingChapterTriggerItem Trigger35 => Instance[(short)33];

		/// <summary>
		/// 首次与带有【五圣秘浴】的人物互动时
		/// </summary>
		public static GuidingChapterTriggerItem Trigger36 => Instance[(short)34];

		/// <summary>
		/// 首次与带有【委托暗杀】的人物互动时
		/// </summary>
		public static GuidingChapterTriggerItem Trigger37 => Instance[(short)35];

		/// <summary>
		/// 首次与带有【王禅典籍】的人物互动时
		/// </summary>
		public static GuidingChapterTriggerItem Trigger38 => Instance[(short)36];

		/// <summary>
		/// 首次与带有【天府之国】的人物互动时
		/// </summary>
		public static GuidingChapterTriggerItem Trigger39 => Instance[(short)37];

		/// <summary>
		/// 首次与带有【石牢静坐】的人物互动时
		/// </summary>
		public static GuidingChapterTriggerItem Trigger40 => Instance[(short)38];

		/// <summary>
		/// 首次与带有【散播威名】的人物互动时
		/// </summary>
		public static GuidingChapterTriggerItem Trigger41 => Instance[(short)39];

		/// <summary>
		/// 首次与带有【起死回生】的人物互动时
		/// </summary>
		public static GuidingChapterTriggerItem Trigger42 => Instance[(short)40];

		/// <summary>
		/// 首次与带有【七星调元】的人物互动时
		/// </summary>
		public static GuidingChapterTriggerItem Trigger43 => Instance[(short)41];

		/// <summary>
		/// 首次与带有【欧冶古具】的人物互动时
		/// </summary>
		public static GuidingChapterTriggerItem Trigger44 => Instance[(short)42];

		/// <summary>
		/// 首次与带有【面壁阅经】的人物互动时
		/// </summary>
		public static GuidingChapterTriggerItem Trigger45 => Instance[(short)43];

		/// <summary>
		/// 首次与带有【秘药延寿】的人物互动时
		/// </summary>
		public static GuidingChapterTriggerItem Trigger46 => Instance[(short)44];

		/// <summary>
		/// 首次与带有【龙岛忠仆】的人物互动时
		/// </summary>
		public static GuidingChapterTriggerItem Trigger47 => Instance[(short)45];

		/// <summary>
		/// 首次与带有【金刚秘法】的人物互动时
		/// </summary>
		public static GuidingChapterTriggerItem Trigger48 => Instance[(short)46];

		/// <summary>
		/// 首次与带有【荐送弟子】的人物互动时
		/// </summary>
		public static GuidingChapterTriggerItem Trigger49 => Instance[(short)47];

		/// <summary>
		/// 首次和下九流身份NPC交谈时
		/// </summary>
		public static GuidingChapterTriggerItem Trigger50 => Instance[(short)48];

		/// <summary>
		/// 首次和文人身份NPC交谈时
		/// </summary>
		public static GuidingChapterTriggerItem Trigger51 => Instance[(short)49];

		/// <summary>
		/// 首次和手艺人身份NPC交谈时
		/// </summary>
		public static GuidingChapterTriggerItem Trigger52 => Instance[(short)50];

		/// <summary>
		/// 首次和身为守卫的NPC互动（通过库房或者监牢和守卫互动也算)
		/// </summary>
		public static GuidingChapterTriggerItem Trigger53 => Instance[(short)51];

		/// <summary>
		/// 首次和商人身份NPC交谈时
		/// </summary>
		public static GuidingChapterTriggerItem Trigger54 => Instance[(short)52];

		/// <summary>
		/// 首次和任意势力上三阶人物交互
		/// </summary>
		public static GuidingChapterTriggerItem Trigger55 => Instance[(short)53];

		/// <summary>
		/// 首次和任意城镇一阶身份NPC交谈时
		/// </summary>
		public static GuidingChapterTriggerItem Trigger56 => Instance[(short)54];

		/// <summary>
		/// 首次和任意城镇二阶身份NPC交谈时
		/// </summary>
		public static GuidingChapterTriggerItem Trigger57 => Instance[(short)55];

		/// <summary>
		/// 首次和乞丐身份NPC交谈时
		/// </summary>
		public static GuidingChapterTriggerItem Trigger58 => Instance[(short)56];

		/// <summary>
		/// 首次和农户身份NPC交谈时
		/// </summary>
		public static GuidingChapterTriggerItem Trigger59 => Instance[(short)57];

		/// <summary>
		/// 首次和富豪身份NPC交谈时
		/// </summary>
		public static GuidingChapterTriggerItem Trigger60 => Instance[(short)58];

		/// <summary>
		/// 首次和大夫身份NPC交谈时
		/// </summary>
		public static GuidingChapterTriggerItem Trigger61 => Instance[(short)59];

		/// <summary>
		/// 首次到达任意存在地区剧情的地区
		/// </summary>
		public static GuidingChapterTriggerItem WorldStatusSectStory => Instance[(short)60];

		/// <summary>
		/// 首次达到存在任意较武奇遇的地区
		/// </summary>
		public static GuidingChapterTriggerItem ArriveAreaWithSectExam => Instance[(short)61];

		/// <summary>
		/// 首次进入诊疗界面
		/// </summary>
		public static GuidingChapterTriggerItem FirstEnterHeal => Instance[(short)62];

		/// <summary>
		/// 首次进入战斗界面
		/// </summary>
		public static GuidingChapterTriggerItem FirstEnterCombat => Instance[(short)63];

		/// <summary>
		/// 首次进入用药界面
		/// </summary>
		public static GuidingChapterTriggerItem FirstEnterViewUsingMedicine => Instance[(short)64];

		/// <summary>
		/// 首次进入天人感应界面
		/// </summary>
		public static GuidingChapterTriggerItem Trigger68 => Instance[(short)65];

		/// <summary>
		/// 首次进入世界地图界面时
		/// </summary>
		public static GuidingChapterTriggerItem FirstEnterPartWorldMap => Instance[(short)66];

		/// <summary>
		/// 首次进入任意商店界面
		/// </summary>
		public static GuidingChapterTriggerItem FirstEnterShop => Instance[(short)67];

		/// <summary>
		/// 首次进入任意揭示了喜恶的人物的人物属性界面
		/// </summary>
		public static GuidingChapterTriggerItem FirstEnterCharacterInfoWithLoveAndHate => Instance[(short)68];

		/// <summary>
		/// 首次进入人物属性界面
		/// </summary>
		public static GuidingChapterTriggerItem FirstEnterCharacterInfo => Instance[(short)69];

		/// <summary>
		/// 首次进入奇书奇遇时
		/// </summary>
		public static GuidingChapterTriggerItem Trigger73 => Instance[(short)70];

		/// <summary>
		/// 首次进入某个带库房的定居点的产业视图
		/// </summary>
		public static GuidingChapterTriggerItem Trigger74 => Instance[(short)71];

		/// <summary>
		/// 首次进入灵光一闪界面
		/// </summary>
		public static GuidingChapterTriggerItem FirstEnterReadingEvent => Instance[(short)72];

		/// <summary>
		/// 首次进入库房界面
		/// </summary>
		public static GuidingChapterTriggerItem FirstEnterTreasury => Instance[(short)73];

		/// <summary>
		/// 首次进入较艺准备界面
		/// </summary>
		public static GuidingChapterTriggerItem Trigger77 => Instance[(short)74];

		/// <summary>
		/// 首次进入技艺或武学造诣界面
		/// </summary>
		public static GuidingChapterTriggerItem FirstOpenUISkillAttainment => Instance[(short)75];

		/// <summary>
		/// 首次进入NPC的代制界面
		/// </summary>
		public static GuidingChapterTriggerItem FirstEnterViewCraftsmanForCharacter => Instance[(short)76];

		/// <summary>
		/// 首次进入【周天运转】界面
		/// </summary>
		public static GuidingChapterTriggerItem Trigger80 => Instance[(short)77];

		/// <summary>
		/// 首次进入【研读书籍】界面
		/// </summary>
		public static GuidingChapterTriggerItem FirstEnterReading => Instance[(short)78];

		/// <summary>
		/// 首次进入【突破玩法】界面
		/// </summary>
		public static GuidingChapterTriggerItem FirstOpenUISkillBreak => Instance[(short)79];

		/// <summary>
		/// 首次进入交换物资界面
		/// </summary>
		public static GuidingChapterTriggerItem FirstEnterExchange => Instance[(short)80];

		/// <summary>
		/// 首次进入【交换藏书】界面
		/// </summary>
		public static GuidingChapterTriggerItem FirstEnterBookExchange => Instance[(short)81];

		/// <summary>
		/// 首次点开任意资源点建筑界面
		/// </summary>
		public static GuidingChapterTriggerItem FirstEnterViewBuildingManageForResource => Instance[(short)82];

		/// <summary>
		/// 首次点开任意制造类任意建筑的界面
		/// </summary>
		public static GuidingChapterTriggerItem FirstEnterViewBuildingManageForMake => Instance[(short)83];

		/// <summary>
		/// 首次点开任意银钱威望/售卖建筑界面
		/// </summary>
		public static GuidingChapterTriggerItem FirstEnterViewBuildingManageForShop => Instance[(short)84];

		/// <summary>
		/// 首次点开能扩建的建筑界面
		/// </summary>
		public static GuidingChapterTriggerItem FirstEnterViewBuildingManageForExpand => Instance[(short)85];

		/// <summary>
		/// 首次打开族谱界面
		/// </summary>
		public static GuidingChapterTriggerItem FirstOpenUIGenealogy => Instance[(short)86];

		/// <summary>
		/// 首次打开造诣总览界面
		/// </summary>
		public static GuidingChapterTriggerItem FirstOpenUIAttainmentOverview => Instance[(short)87];

		/// <summary>
		/// 首次打开运功界面
		/// </summary>
		public static GuidingChapterTriggerItem Trigger90 => Instance[(short)88];

		/// <summary>
		/// 首次打开元鸡舍界面
		/// </summary>
		public static GuidingChapterTriggerItem FirstEnterViewBuildingManageForChicken => Instance[(short)89];

		/// <summary>
		/// 首次打开宴堂建筑的界面
		/// </summary>
		public static GuidingChapterTriggerItem FirstEnterViewBuildingManageForEntertain => Instance[(short)90];

		/// <summary>
		/// 首次打开悬赏榜界面
		/// </summary>
		public static GuidingChapterTriggerItem FirstEnterBounty => Instance[(short)91];

		/// <summary>
		/// 首次打开行囊时有食物类道具
		/// </summary>
		public static GuidingChapterTriggerItem FirstEnterViewCharacterMenuItemsWithFood => Instance[(short)92];

		/// <summary>
		/// 首次打开行囊时有毒药类道具
		/// </summary>
		public static GuidingChapterTriggerItem FirstEnterViewCharacterMenuItemsWithPoison => Instance[(short)93];

		/// <summary>
		/// 首次打开行囊时有丹药类道具
		/// </summary>
		public static GuidingChapterTriggerItem FirstEnterViewCharacterMenuItemsWithMedicine => Instance[(short)94];

		/// <summary>
		/// 首次打开太吾氏祠堂界面
		/// </summary>
		public static GuidingChapterTriggerItem FirstEnterViewBuildingManageForLineage => Instance[(short)95];

		/// <summary>
		/// 首次打开属性页签
		/// </summary>
		public static GuidingChapterTriggerItem FirstEnterCharacterAttribute => Instance[(short)96];

		/// <summary>
		/// 首次打开属性界面的轮回二级界面时
		/// </summary>
		public static GuidingChapterTriggerItem FirstEnterViewSamsara => Instance[(short)97];

		/// <summary>
		/// 首次打开势力界面
		/// </summary>
		public static GuidingChapterTriggerItem FirstEnterSettlementInformation => Instance[(short)98];

		/// <summary>
		/// 首次打开石屋界面
		/// </summary>
		public static GuidingChapterTriggerItem FirstOpenUIStoneHouse => Instance[(short)99];

		/// <summary>
		/// 首次打开身份说明界面
		/// </summary>
		public static GuidingChapterTriggerItem FirstOpenUIVillagerRoleDesc => Instance[(short)100];

		/// <summary>
		/// 首次打开伤病页签
		/// </summary>
		public static GuidingChapterTriggerItem FirstEnterCharacterInjury => Instance[(short)101];

		/// <summary>
		/// 首次打开任意制造建筑的【制造】功能界面
		/// </summary>
		public static GuidingChapterTriggerItem FirstEnterViewMakeForMake => Instance[(short)102];

		/// <summary>
		/// 首次打开任意制造建筑的【修理】功能界面
		/// </summary>
		public static GuidingChapterTriggerItem FirstEnterViewMakeForRepair => Instance[(short)103];

		/// <summary>
		/// 首次打开任意制造建筑的【精制】功能界面
		/// </summary>
		public static GuidingChapterTriggerItem FirstEnterViewMakeForRefine => Instance[(short)104];

		/// <summary>
		/// 首次打开任意制造建筑的【代制】功能界面
		/// </summary>
		public static GuidingChapterTriggerItem FirstEnterViewCraftsmanForBuilding => Instance[(short)105];

		/// <summary>
		/// 首次打开批量操作的【修理】页签
		/// </summary>
		public static GuidingChapterTriggerItem FirstEnterItemMultiplyOperationPanelForRepair => Instance[(short)106];

		/// <summary>
		/// 首次打开批量操作的【拆解】页签
		/// </summary>
		public static GuidingChapterTriggerItem FirstEnterItemMultiplyOperationPanelForDisassemble => Instance[(short)107];

		/// <summary>
		/// 首次打开人物属性界面
		/// </summary>
		public static GuidingChapterTriggerItem Trigger109 => Instance[(short)108];

		/// <summary>
		/// 首次打开人物的造诣总览/武学详情界面
		/// </summary>
		public static GuidingChapterTriggerItem FirstOpenUICharacterSkillSummary => Instance[(short)109];

		/// <summary>
		/// 首次打开奇书界面
		/// </summary>
		public static GuidingChapterTriggerItem FirstOpenUILegendaryBook => Instance[(short)110];

		/// <summary>
		/// 首次打开七级商店
		/// </summary>
		public static GuidingChapterTriggerItem FirstEnterLevel7Shop => Instance[(short)111];

		/// <summary>
		/// 首次打开内力界面
		/// </summary>
		public static GuidingChapterTriggerItem Trigger113 => Instance[(short)112];

		/// <summary>
		/// 首次打开铭刻界面
		/// </summary>
		public static GuidingChapterTriggerItem FirstEnterCheckInscription => Instance[(short)113];

		/// <summary>
		/// 首次打开轮回台界面
		/// </summary>
		public static GuidingChapterTriggerItem FirstEnterSamsaraPlatform => Instance[(short)114];

		/// <summary>
		/// 首次打开练功房界面
		/// </summary>
		public static GuidingChapterTriggerItem Trigger116 => Instance[(short)115];

		/// <summary>
		/// 首次打开居所界面时
		/// </summary>
		public static GuidingChapterTriggerItem FirstEnterViewBuildingManageForResidence => Instance[(short)116];

		/// <summary>
		/// 首次打开精挑细选界面
		/// </summary>
		public static GuidingChapterTriggerItem FirstEnterViewChoosyResource => Instance[(short)117];

		/// <summary>
		/// 首次打开经历界面
		/// </summary>
		public static GuidingChapterTriggerItem FirstEnterLifeSummary => Instance[(short)118];

		/// <summary>
		/// 首次打开建造总览界面
		/// </summary>
		public static GuidingChapterTriggerItem Trigger120 => Instance[(short)119];

		/// <summary>
		/// 首次打开建设空间的【资源】页签
		/// </summary>
		public static GuidingChapterTriggerItem Trigger121 => Instance[(short)120];

		/// <summary>
		/// 首次打开监牢建筑界面
		/// </summary>
		public static GuidingChapterTriggerItem FirstEnterViewBuildingManageForPrison => Instance[(short)121];

		/// <summary>
		/// 首次打开监牢功能界面
		/// </summary>
		public static GuidingChapterTriggerItem FirstEnterPrison => Instance[(short)122];

		/// <summary>
		/// 首次打开关系界面
		/// </summary>
		public static GuidingChapterTriggerItem Trigger124 => Instance[(short)123];

		/// <summary>
		/// 首次打开法规条文界面
		/// </summary>
		public static GuidingChapterTriggerItem FirstEnterViewSectLaw => Instance[(short)124];

		/// <summary>
		/// 首次打开促织陈列界面
		/// </summary>
		public static GuidingChapterTriggerItem Trigger126 => Instance[(short)125];

		/// <summary>
		/// 首次打开传承名谱界面
		/// </summary>
		public static GuidingChapterTriggerItem FirstOpenUIVillagerRole => Instance[(short)126];

		/// <summary>
		/// 首次打开持有九世轮回特性人物的人物属性界面
		/// </summary>
		public static GuidingChapterTriggerItem FirstEnterCharacterInfoWithFeatureReincarnationBonus => Instance[(short)127];

		/// <summary>
		/// 首次打开超出当前好感度的商店界面
		/// </summary>
		public static GuidingChapterTriggerItem FirstEnterOverFavorShop => Instance[(short)128];

		/// <summary>
		/// 首次打开茶马帮界面
		/// </summary>
		public static GuidingChapterTriggerItem FirstEnterTeaHorseCaravan => Instance[(short)129];

		/// <summary>
		/// 首次打开仓库建筑的界面
		/// </summary>
		public static GuidingChapterTriggerItem FirstEnterWarehouse => Instance[(short)130];

		/// <summary>
		/// 首次打开参悟玄机界面时
		/// </summary>
		public static GuidingChapterTriggerItem FirstEnterViewSkillBreakBonusSelect => Instance[(short)131];

		/// <summary>
		/// 首次打开不渝成年同道的人物属性界面
		/// </summary>
		public static GuidingChapterTriggerItem FirstEnterCharacterInfoGroupFavorite6 => Instance[(short)132];

		/// <summary>
		/// 首次打开【装备】界面
		/// </summary>
		public static GuidingChapterTriggerItem FirstEnterMenuEquipment => Instance[(short)133];

		/// <summary>
		/// 首次打开【突破】界面
		/// </summary>
		public static GuidingChapterTriggerItem Trigger135 => Instance[(short)134];

		/// <summary>
		/// 首次打开【解毒】功能界面
		/// </summary>
		public static GuidingChapterTriggerItem FirstEnterViewMakeForRemovePoison => Instance[(short)135];

		/// <summary>
		/// 首次打开【改制】功能界面
		/// </summary>
		public static GuidingChapterTriggerItem FirstEnterViewMakeForWeave => Instance[(short)136];

		/// <summary>
		/// 首次打开【淬毒】功能界面
		/// </summary>
		public static GuidingChapterTriggerItem FirstEnterViewMakeForAddPoison => Instance[(short)137];

		/// <summary>
		/// 首次打开【持有】界面
		/// </summary>
		public static GuidingChapterTriggerItem FirstEnterViewCharacterMenuItems => Instance[(short)138];

		/// <summary>
		/// 进入任意奇遇
		/// </summary>
		public static GuidingChapterTriggerItem Trigger140 => Instance[(short)139];

		/// <summary>
		/// 打开石屋首次有失心人存在时
		/// </summary>
		public static GuidingChapterTriggerItem OpenUIStoneHouseWithFallen => Instance[(short)140];

		/// <summary>
		/// 打开人物的造诣总览/技艺详情界面
		/// </summary>
		public static GuidingChapterTriggerItem OpenUICharacterSkillSummary => Instance[(short)141];

		/// <summary>
		/// 初次进入太吾村产业视图
		/// </summary>
		public static GuidingChapterTriggerItem Trigger143 => Instance[(short)142];

		/// <summary>
		/// 初次进入任意产业视图
		/// </summary>
		public static GuidingChapterTriggerItem Trigger144 => Instance[(short)143];

		/// <summary>
		/// 初次进入产业规划界面
		/// </summary>
		public static GuidingChapterTriggerItem Trigger145 => Instance[(short)144];

		/// <summary>
		/// 战斗准备己方/敌方产生一次负面指令
		/// </summary>
		public static GuidingChapterTriggerItem Trigger146 => Instance[(short)145];

		/// <summary>
		/// 战斗中携带的摧破首次满足释放条件
		/// </summary>
		public static GuidingChapterTriggerItem CombatAttackSkillCanCast => Instance[(short)146];

		/// <summary>
		/// 战斗中受到任意伤害积累时
		/// </summary>
		public static GuidingChapterTriggerItem CombatAcceptAnyDamage => Instance[(short)147];

		/// <summary>
		/// 战斗中首次打开使用物品界面
		/// </summary>
		public static GuidingChapterTriggerItem FirstEnterCombatUseItemPanel => Instance[(short)148];

		/// <summary>
		/// 战斗中己方或对方遭到功法反噬
		/// </summary>
		public static GuidingChapterTriggerItem CombatGoneMadInjury => Instance[(short)149];

		/// <summary>
		/// 战斗首次让敌方进入到兵器攻击范围
		/// </summary>
		public static GuidingChapterTriggerItem CombatInAttackRange => Instance[(short)150];

		/// <summary>
		/// 在可以逃跑的战斗类型中己方战败标记超过一半时
		/// </summary>
		public static GuidingChapterTriggerItem CombatCanFleeHalfFallen => Instance[(short)151];

		/// <summary>
		/// 用普攻或摧破命中敌人要害时
		/// </summary>
		public static GuidingChapterTriggerItem CombatCritical => Instance[(short)152];

		/// <summary>
		/// 通过功法使对方拥有蛊虫
		/// </summary>
		public static GuidingChapterTriggerItem CombatAddWugBySkill => Instance[(short)153];

		/// <summary>
		/// 跳出处决确认按钮时
		/// </summary>
		public static GuidingChapterTriggerItem FirstMercyButton => Instance[(short)154];

		/// <summary>
		/// 首个身法或腿法可施展时
		/// </summary>
		public static GuidingChapterTriggerItem CombatAgileOrLegSkillCanCast => Instance[(short)155];

		/// <summary>
		/// 己方或者敌方首次掉血时
		/// </summary>
		public static GuidingChapterTriggerItem Trigger157 => Instance[(short)156];

		/// <summary>
		/// 己方或敌方首次产生战败标记
		/// </summary>
		public static GuidingChapterTriggerItem CombatAnyMark => Instance[(short)157];

		/// <summary>
		/// 己方服食栏首次出现任意蛊虫
		/// </summary>
		public static GuidingChapterTriggerItem CombatAcceptWug => Instance[(short)158];

		/// <summary>
		/// 己方/敌方形成一个重创标记
		/// </summary>
		public static GuidingChapterTriggerItem CombatFatalMark => Instance[(short)159];

		/// <summary>
		/// 己方/敌方形成一个失神标记
		/// </summary>
		public static GuidingChapterTriggerItem CombatMindMark => Instance[(short)160];

		/// <summary>
		/// 己方/敌方形成一个任意真气标记
		/// </summary>
		public static GuidingChapterTriggerItem CombatNeiliAllocationMark => Instance[(short)161];

		/// <summary>
		/// 己方/敌方形成一个任意外伤/内伤标记
		/// </summary>
		public static GuidingChapterTriggerItem CombatInjuryMark => Instance[(short)162];

		/// <summary>
		/// 己方/敌方形成一个任意内息标记
		/// </summary>
		public static GuidingChapterTriggerItem CombatQiDisorderMark => Instance[(short)163];

		/// <summary>
		/// 己方/敌方形成一个任意健康标记
		/// </summary>
		public static GuidingChapterTriggerItem CombatHealthMark => Instance[(short)164];

		/// <summary>
		/// 己方/敌方形成一个任意减益标记
		/// </summary>
		public static GuidingChapterTriggerItem CombatStateMark => Instance[(short)165];

		/// <summary>
		/// 己方/敌方形成一个任意蛊虫标记
		/// </summary>
		public static GuidingChapterTriggerItem CombatWugMark => Instance[(short)166];

		/// <summary>
		/// 己方/敌方形成一个任意毒素标记
		/// </summary>
		public static GuidingChapterTriggerItem CombatPoisonMark => Instance[(short)167];

		/// <summary>
		/// 己方/敌方形成一个破绽标记
		/// </summary>
		public static GuidingChapterTriggerItem CombatFlawMark => Instance[(short)168];

		/// <summary>
		/// 己方/敌方形成一个封穴标记
		/// </summary>
		public static GuidingChapterTriggerItem CombatAcupointMark => Instance[(short)169];

		/// <summary>
		/// 己方/敌方释放任意带反震效果的护体
		/// </summary>
		public static GuidingChapterTriggerItem CombatCastBounceDefendSkill => Instance[(short)170];

		/// <summary>
		/// 己方/敌方释放任意带反击效果的护体
		/// </summary>
		public static GuidingChapterTriggerItem CombatCastFightBackDefendSkill => Instance[(short)171];

		/// <summary>
		/// 己方/敌方施展完毕任意一个摧破功法
		/// </summary>
		public static GuidingChapterTriggerItem CombatCastAttackSkill => Instance[(short)172];

		/// <summary>
		/// 己方/敌方任意一个真气达到异常状态
		/// </summary>
		public static GuidingChapterTriggerItem CombatNeiliAllocationAnyStatus => Instance[(short)173];

		/// <summary>
		/// 己方/敌方任意一个功法被封禁
		/// </summary>
		public static GuidingChapterTriggerItem CombatSkillSilence => Instance[(short)174];

		/// <summary>
		/// 在主界面进行一次移动
		/// </summary>
		public static GuidingChapterTriggerItem MapMove => Instance[(short)175];

		/// <summary>
		/// 移动到有促织的地格上
		/// </summary>
		public static GuidingChapterTriggerItem MapMoveInCricket => Instance[(short)176];

		/// <summary>
		/// 移动到埋有物品的地格上时
		/// </summary>
		public static GuidingChapterTriggerItem MapMoveInTreasure => Instance[(short)177];

		/// <summary>
		/// 首次来到任意定居点地格
		/// </summary>
		public static GuidingChapterTriggerItem MapMoveInSettlement => Instance[(short)178];

		/// <summary>
		/// 太吾到达某个门派的定居点地格
		/// </summary>
		public static GuidingChapterTriggerItem MapMoveInSect => Instance[(short)179];

		/// <summary>
		/// 首次到达少林派定居点
		/// </summary>
		public static GuidingChapterTriggerItem MapMoveInSectShaolin => Instance[(short)180];

		/// <summary>
		/// 首次到达峨眉派定居点
		/// </summary>
		public static GuidingChapterTriggerItem MapMoveInSectEmei => Instance[(short)181];

		/// <summary>
		/// 首次到达百花谷定居点
		/// </summary>
		public static GuidingChapterTriggerItem MapMoveInSectBaihua => Instance[(short)182];

		/// <summary>
		/// 首次到达武当派定居点
		/// </summary>
		public static GuidingChapterTriggerItem MapMoveInSectWudang => Instance[(short)183];

		/// <summary>
		/// 首次到达元山派定居点
		/// </summary>
		public static GuidingChapterTriggerItem MapMoveInSectYuanshan => Instance[(short)184];

		/// <summary>
		/// 首次到达狮相门定居点
		/// </summary>
		public static GuidingChapterTriggerItem MapMoveInSectShixiang => Instance[(short)185];

		/// <summary>
		/// 首次到达然山派定居点
		/// </summary>
		public static GuidingChapterTriggerItem MapMoveInSectRanshan => Instance[(short)186];

		/// <summary>
		/// 首次到达璇女派定居点
		/// </summary>
		public static GuidingChapterTriggerItem MapMoveInSectXuannv => Instance[(short)187];

		/// <summary>
		/// 首次到达铸剑山庄定居点
		/// </summary>
		public static GuidingChapterTriggerItem MapMoveInSectZhujian => Instance[(short)188];

		/// <summary>
		/// 首次到达空桑派定居点
		/// </summary>
		public static GuidingChapterTriggerItem MapMoveInSectKongsang => Instance[(short)189];

		/// <summary>
		/// 首次到达金刚宗定居点
		/// </summary>
		public static GuidingChapterTriggerItem MapMoveInSectJingang => Instance[(short)190];

		/// <summary>
		/// 首次到达五仙教定居点
		/// </summary>
		public static GuidingChapterTriggerItem MapMoveInSectWuxian => Instance[(short)191];

		/// <summary>
		/// 首次到达界青门定居点
		/// </summary>
		public static GuidingChapterTriggerItem MapMoveInSectJieqing => Instance[(short)192];

		/// <summary>
		/// 首次到达伏龙坛定居点
		/// </summary>
		public static GuidingChapterTriggerItem MapMoveInSectFulong => Instance[(short)193];

		/// <summary>
		/// 首次到达血犼教定居点
		/// </summary>
		public static GuidingChapterTriggerItem MapMoveInSectXuehou => Instance[(short)194];

		/// <summary>
		/// 首次到达太吾村地格
		/// </summary>
		public static GuidingChapterTriggerItem MapMoveInTaiwuVillage => Instance[(short)195];

		/// <summary>
		/// 首次到达存在沾染玄灰的人所在的地格
		/// </summary>
		public static GuidingChapterTriggerItem MapMoveInAsh => Instance[(short)196];

		/// <summary>
		/// 首次到达存在任意爪牙的地格
		/// </summary>
		public static GuidingChapterTriggerItem MapMoveInXiangshuMinion => Instance[(short)197];

		/// <summary>
		/// 首次到达存在任意外道或义士的地格
		/// </summary>
		public static GuidingChapterTriggerItem MapMoveInHereticOrRighteous => Instance[(short)198];

		/// <summary>
		/// 首次到达存在任意商队的地格
		/// </summary>
		public static GuidingChapterTriggerItem MapMoveInMerchant => Instance[(short)199];

		/// <summary>
		/// 到达任意一个非太吾村定居点地格
		/// </summary>
		public static GuidingChapterTriggerItem MapMoveInCity => Instance[(short)200];

		/// <summary>
		/// 首次走到有拾取物的地格上
		/// </summary>
		public static GuidingChapterTriggerItem MapMoveInPickup => Instance[(short)201];

		/// <summary>
		/// 完成奇书宝典解锁事件后
		/// </summary>
		public static GuidingChapterTriggerItem Trigger204 => Instance[(short)202];

		/// <summary>
		/// 太吾或配偶孩子出生事件结束
		/// </summary>
		public static GuidingChapterTriggerItem Trigger205 => Instance[(short)203];

		/// <summary>
		/// 太吾触发旅行地图门派事件
		/// </summary>
		public static GuidingChapterTriggerItem Trigger206 => Instance[(short)204];

		/// <summary>
		/// 首次与罪犯NPC互动
		/// </summary>
		public static GuidingChapterTriggerItem Trigger207 => Instance[(short)205];

		/// <summary>
		/// 首次与任意坟墓互动
		/// </summary>
		public static GuidingChapterTriggerItem Trigger208 => Instance[(short)206];

		/// <summary>
		/// 首次为其他NPC修建坟墓
		/// </summary>
		public static GuidingChapterTriggerItem Trigger209 => Instance[(short)207];

		/// <summary>
		/// 首次完成玄石紫竹奇遇后
		/// </summary>
		public static GuidingChapterTriggerItem Trigger210 => Instance[(short)208];

		/// <summary>
		/// 首次进入任意门派弟子的【修习】交互
		/// </summary>
		public static GuidingChapterTriggerItem Trigger211 => Instance[(short)209];

		/// <summary>
		/// 首次获得门派支持度（也就是拜访事件后）
		/// </summary>
		public static GuidingChapterTriggerItem Trigger212 => Instance[(short)210];

		/// <summary>
		/// 首次过月触发奇书降世奇遇时
		/// </summary>
		public static GuidingChapterTriggerItem Trigger213 => Instance[(short)211];

		/// <summary>
		/// 任意化身破冢后
		/// </summary>
		public static GuidingChapterTriggerItem SwordTombInvasion => Instance[(short)212];

		/// <summary>
		/// 开通太吾村地区的驿站
		/// </summary>
		public static GuidingChapterTriggerItem Trigger215 => Instance[(short)213];

		/// <summary>
		/// 剑冢出现事件结束后
		/// </summary>
		public static GuidingChapterTriggerItem Trigger216 => Instance[(short)214];

		/// <summary>
		/// 打开人物的【修习】互动时
		/// </summary>
		public static GuidingChapterTriggerItem Trigger217 => Instance[(short)215];

		/// <summary>
		/// 打开人物的【请教武学】互动时
		/// </summary>
		public static GuidingChapterTriggerItem Trigger218 => Instance[(short)216];

		/// <summary>
		/// 打开人物的【请教技艺】互动时
		/// </summary>
		public static GuidingChapterTriggerItem Trigger219 => Instance[(short)217];

		/// <summary>
		/// 打开人物的【亲近】互动时
		/// </summary>
		public static GuidingChapterTriggerItem Trigger220 => Instance[(short)218];

		/// <summary>
		/// 打开人物的【交谈】互动时
		/// </summary>
		public static GuidingChapterTriggerItem Trigger221 => Instance[(short)219];

		/// <summary>
		/// 打开人物的【敌对】互动时
		/// </summary>
		public static GuidingChapterTriggerItem Trigger222 => Instance[(short)220];

		/// <summary>
		/// 打开人物的【比试】互动时
		/// </summary>
		public static GuidingChapterTriggerItem Trigger223 => Instance[(short)221];

		/// <summary>
		/// 志向解锁事件结束后
		/// </summary>
		public static GuidingChapterTriggerItem Trigger224 => Instance[(short)222];

		/// <summary>
		/// 首次选择带立场的选项时
		/// </summary>
		public static GuidingChapterTriggerItem Trigger225 => Instance[(short)223];

		/// <summary>
		/// 装备重量超出负重上限时
		/// </summary>
		public static GuidingChapterTriggerItem EquipOverload => Instance[(short)224];

		/// <summary>
		/// 战斗中遭遇相枢爪牙
		/// </summary>
		public static GuidingChapterTriggerItem Trigger227 => Instance[(short)225];

		/// <summary>
		/// 在主界面移动时揭示一次地格
		/// </summary>
		public static GuidingChapterTriggerItem MapMoveShowBlock => Instance[(short)226];

		/// <summary>
		/// 在运功界面装配任意奇窍功法
		/// </summary>
		public static GuidingChapterTriggerItem Trigger229 => Instance[(short)227];

		/// <summary>
		/// 在所处地区存在奇遇时
		/// </summary>
		public static GuidingChapterTriggerItem MapMoveInAdventure => Instance[(short)228];

		/// <summary>
		/// 在死斗中击败敌人后
		/// </summary>
		public static GuidingChapterTriggerItem CombatWinDie => Instance[(short)229];

		/// <summary>
		/// 拥有一名相互爱慕的对象或者配偶
		/// </summary>
		public static GuidingChapterTriggerItem Trigger232 => Instance[(short)230];

		/// <summary>
		/// 拥有第一个同道时
		/// </summary>
		public static GuidingChapterTriggerItem Trigger233 => Instance[(short)231];

		/// <summary>
		/// 拥有第一个俘虏时
		/// </summary>
		public static GuidingChapterTriggerItem Trigger234 => Instance[(short)232];

		/// <summary>
		/// 已装备的物品首次耐久到达20%及以下时
		/// </summary>
		public static GuidingChapterTriggerItem Trigger235 => Instance[(short)233];

		/// <summary>
		/// 行囊负重超过上限时
		/// </summary>
		public static GuidingChapterTriggerItem WorldStatusTaiwuOverload => Instance[(short)234];

		/// <summary>
		/// 下一次可以连接到玄机格时
		/// </summary>
		public static GuidingChapterTriggerItem CanLinkToBonusCell => Instance[(short)235];

		/// <summary>
		/// 通过研读首次习得功法
		/// </summary>
		public static GuidingChapterTriggerItem Trigger238 => Instance[(short)236];

		/// <summary>
		/// 太吾自身首次在战斗外触发混合毒素效果
		/// </summary>
		public static GuidingChapterTriggerItem Trigger239 => Instance[(short)237];

		/// <summary>
		/// 太吾自身怀孕或者配偶怀孕
		/// </summary>
		public static GuidingChapterTriggerItem Trigger240 => Instance[(short)238];

		/// <summary>
		/// 太吾首次入邪
		/// </summary>
		public static GuidingChapterTriggerItem Trigger241 => Instance[(short)239];

		/// <summary>
		/// 太吾首次被通缉
		/// </summary>
		public static GuidingChapterTriggerItem Trigger242 => Instance[(short)240];

		/// <summary>
		/// 太吾氏祠堂建造完毕
		/// </summary>
		public static GuidingChapterTriggerItem Trigger243 => Instance[(short)241];

		/// <summary>
		/// 太吾或同道到达超重状态
		/// </summary>
		public static GuidingChapterTriggerItem WorldStatusOverload => Instance[(short)242];

		/// <summary>
		/// 太吾持有至少一世轮回时打开太吾的人物属性界面
		/// </summary>
		public static GuidingChapterTriggerItem FirstEnterCharacterInfoSamsaraCount1 => Instance[(short)243];

		/// <summary>
		/// 首个剧情剑冢拔除
		/// </summary>
		public static GuidingChapterTriggerItem Trigger246 => Instance[(short)244];

		/// <summary>
		/// 首次装配着任意轻灵功法进入战斗
		/// </summary>
		public static GuidingChapterTriggerItem CombatEquipAgile => Instance[(short)245];

		/// <summary>
		/// 首次主动仇恨其他人
		/// </summary>
		public static GuidingChapterTriggerItem FirstHate => Instance[(short)246];

		/// <summary>
		/// 首次主动爱慕其他人
		/// </summary>
		public static GuidingChapterTriggerItem FirstLove => Instance[(short)247];

		/// <summary>
		/// 首次种下任意神木种子时
		/// </summary>
		public static GuidingChapterTriggerItem FirstPlantHeavenlyTree => Instance[(short)248];

		/// <summary>
		/// 首次正式开始任意较艺决斗
		/// </summary>
		public static GuidingChapterTriggerItem Trigger251 => Instance[(short)249];

		/// <summary>
		/// 首次在助战同道栏放置同道
		/// </summary>
		public static GuidingChapterTriggerItem ArrangeTeammate => Instance[(short)250];

		/// <summary>
		/// 首次在战斗中己方或对方触发混合毒素
		/// </summary>
		public static GuidingChapterTriggerItem CombatMixPoisonAffect => Instance[(short)251];

		/// <summary>
		/// 首次在战斗中己方或对方触发毒素发作效果或者混合毒素发作效果
		/// </summary>
		public static GuidingChapterTriggerItem CombatPoisonAffect => Instance[(short)252];

		/// <summary>
		/// 首次在拥有任意一个技能的情况下打开志向界面
		/// </summary>
		public static GuidingChapterTriggerItem FirstEnterProfessionWithSkill => Instance[(short)253];

		/// <summary>
		/// 首次在交互时与他人的戒心产生变化时
		/// </summary>
		public static GuidingChapterTriggerItem FirstChangeAlertness => Instance[(short)254];

		/// <summary>
		/// 首次在交互时与他人的好感产生变化时
		/// </summary>
		public static GuidingChapterTriggerItem FirstChangeFavorability => Instance[(short)255];

		/// <summary>
		/// 首次与失心人进行战斗
		/// </summary>
		public static GuidingChapterTriggerItem Trigger258 => Instance[(short)256];

		/// <summary>
		/// 首次与某人好感度达到亲密
		/// </summary>
		public static GuidingChapterTriggerItem FirstChangeFavorabilityToFavorite5 => Instance[(short)257];

		/// <summary>
		/// 首次选中任意策略卡时
		/// </summary>
		public static GuidingChapterTriggerItem FirstSelectDebateCard => Instance[(short)258];

		/// <summary>
		/// 首次悬停任意身法/护体/摧破类功法的Tips
		/// </summary>
		public static GuidingChapterTriggerItem FirstEnterCombatTipEquipTypeAttackAgileDefense => Instance[(short)259];

		/// <summary>
		/// 首次悬停任意功法的Tips
		/// </summary>
		public static GuidingChapterTriggerItem FirstEnterCombatTip => Instance[(short)260];

		/// <summary>
		/// 首次悬停任意【护具】Tips时
		/// </summary>
		public static GuidingChapterTriggerItem FirstShowTipForArmor => Instance[(short)261];

		/// <summary>
		/// 首次悬停任意【代步】Tips时
		/// </summary>
		public static GuidingChapterTriggerItem FirstShowTipForCarrier => Instance[(short)262];

		/// <summary>
		/// 首次悬停任意【兵器】Tips时
		/// </summary>
		public static GuidingChapterTriggerItem FirstShowTipForWeapon => Instance[(short)263];

		/// <summary>
		/// 首次形成冲克的内力
		/// </summary>
		public static GuidingChapterTriggerItem FirstFiveElementConflict => Instance[(short)264];

		/// <summary>
		/// 首次消耗了任意属性后
		/// </summary>
		public static GuidingChapterTriggerItem CostMainAttribute => Instance[(short)265];

		/// <summary>
		/// 首次完成功法书籍的研读
		/// </summary>
		public static GuidingChapterTriggerItem FirstFinishReadingCombatSkillBook => Instance[(short)266];

		/// <summary>
		/// 首次提升精纯
		/// </summary>
		public static GuidingChapterTriggerItem Trigger269 => Instance[(short)267];

		/// <summary>
		/// 首次太吾自己的心情产生变化时
		/// </summary>
		public static GuidingChapterTriggerItem Trigger270 => Instance[(short)268];

		/// <summary>
		/// 首次双方距离达到或超过10时
		/// </summary>
		public static GuidingChapterTriggerItem CombatDistanceMoreOrEqual => Instance[(short)269];

		/// <summary>
		/// 首次受到淬毒道具影响
		/// </summary>
		public static GuidingChapterTriggerItem FirstAffectedByPoisonedItem => Instance[(short)270];

		/// <summary>
		/// 首次身上带有毒素
		/// </summary>
		public static GuidingChapterTriggerItem Trigger273 => Instance[(short)271];

		/// <summary>
		/// 首次内息到达逆阻
		/// </summary>
		public static GuidingChapterTriggerItem Trigger274 => Instance[(short)272];

		/// <summary>
		/// 首次某个非腿法摧破或护体可施展时
		/// </summary>
		public static GuidingChapterTriggerItem CombatDefendOrNotLegAttackSkillCanCast => Instance[(short)273];

		/// <summary>
		/// 首次累积满1次变招进度
		/// </summary>
		public static GuidingChapterTriggerItem CombatCanChangeTrick => Instance[(short)274];

		/// <summary>
		/// 首次开启促织决斗时
		/// </summary>
		public static GuidingChapterTriggerItem FirstEnterCricketCombat => Instance[(short)275];

		/// <summary>
		/// 首次精力少于5的时候
		/// </summary>
		public static GuidingChapterTriggerItem TimeBallAcuPointLessThan5 => Instance[(short)276];

		/// <summary>
		/// 首次精力少于10的时候
		/// </summary>
		public static GuidingChapterTriggerItem TimeBallAcuPointLessThan10 => Instance[(short)277];

		/// <summary>
		/// 首次进行功法精解
		/// </summary>
		public static GuidingChapterTriggerItem Trigger281 => Instance[(short)278];

		/// <summary>
		/// 首次进行兵器攻击后
		/// </summary>
		public static GuidingChapterTriggerItem CombatNormalAttack => Instance[(short)279];

		/// <summary>
		/// 首次进入战斗准备环节
		/// </summary>
		public static GuidingChapterTriggerItem FirstEnterCombatBegin => Instance[(short)280];

		/// <summary>
		/// 首次进入战斗结算环节
		/// </summary>
		public static GuidingChapterTriggerItem FirstEnterCombatResult => Instance[(short)281];

		/// <summary>
		/// 首次进入战斗环节
		/// </summary>
		public static GuidingChapterTriggerItem Trigger285 => Instance[(short)282];

		/// <summary>
		/// 首次解锁紫竹故事最后一篇后
		/// </summary>
		public static GuidingChapterTriggerItem Trigger286 => Instance[(short)283];

		/// <summary>
		/// 首次结束一场促织决斗时
		/// </summary>
		public static GuidingChapterTriggerItem FirstEnterCricketCombatResult => Instance[(short)284];

		/// <summary>
		/// 首次结束突破（包括成功/失败/退出界面）
		/// </summary>
		public static GuidingChapterTriggerItem FirstExitUISkillBreak => Instance[(short)285];

		/// <summary>
		/// 首次建造任意经营建筑
		/// </summary>
		public static GuidingChapterTriggerItem Trigger289 => Instance[(short)286];

		/// <summary>
		/// 首次建设空间到达上限
		/// </summary>
		public static GuidingChapterTriggerItem Trigger290 => Instance[(short)287];

		/// <summary>
		/// 首次获取伏虞心念后
		/// </summary>
		public static GuidingChapterTriggerItem FirstTimeObtainFuyuFaith => Instance[(short)288];

		/// <summary>
		/// 首次获得新的名誉词条时
		/// </summary>
		public static GuidingChapterTriggerItem Trigger292 => Instance[(short)289];

		/// <summary>
		/// 首次获得王蛊
		/// </summary>
		public static GuidingChapterTriggerItem FirstGetWugKing => Instance[(short)290];

		/// <summary>
		/// 首次获得任意志向见闻
		/// </summary>
		public static GuidingChapterTriggerItem Trigger294 => Instance[(short)291];

		/// <summary>
		/// 首次获得任意蓄式时
		/// </summary>
		public static GuidingChapterTriggerItem CombatAddAnyTrick => Instance[(short)292];

		/// <summary>
		/// 首次获得任意西域见闻
		/// </summary>
		public static GuidingChapterTriggerItem Trigger296 => Instance[(short)293];

		/// <summary>
		/// 首次获得任意同道时（包含谷密）
		/// </summary>
		public static GuidingChapterTriggerItem Trigger297 => Instance[(short)294];

		/// <summary>
		/// 首次获得任意门派见闻
		/// </summary>
		public static GuidingChapterTriggerItem Trigger298 => Instance[(short)295];

		/// <summary>
		/// 首次获得任意较艺策略
		/// </summary>
		public static GuidingChapterTriggerItem FirstUnlockDebateStrategy => Instance[(short)296];

		/// <summary>
		/// 首次获得任意剑冢见闻
		/// </summary>
		public static GuidingChapterTriggerItem Trigger300 => Instance[(short)297];

		/// <summary>
		/// 首次获得任意见闻
		/// </summary>
		public static GuidingChapterTriggerItem Trigger301 => Instance[(short)298];

		/// <summary>
		/// 首次获得任意技艺见闻
		/// </summary>
		public static GuidingChapterTriggerItem Trigger302 => Instance[(short)299];

		/// <summary>
		/// 首次获得任意地区恩义时
		/// </summary>
		public static GuidingChapterTriggerItem Trigger303 => Instance[(short)300];

		/// <summary>
		/// 首次获得任意地方见闻
		/// </summary>
		public static GuidingChapterTriggerItem Trigger304 => Instance[(short)301];

		/// <summary>
		/// 首次获得历练收入
		/// </summary>
		public static GuidingChapterTriggerItem Trigger305 => Instance[(short)302];

		/// <summary>
		/// 关闭研读界面时研读的是武学书籍
		/// </summary>
		public static GuidingChapterTriggerItem CloseReadingWithCombatSkillBook => Instance[(short)303];

		/// <summary>
		/// 首次对对方造成任意直接伤害
		/// </summary>
		public static GuidingChapterTriggerItem CombatMakeDirectDamage => Instance[(short)304];

		/// <summary>
		/// 首次点亮新的太吾村石碑
		/// </summary>
		public static GuidingChapterTriggerItem FirstUnlockVowStele => Instance[(short)305];

		/// <summary>
		/// 首次触发天人感应
		/// </summary>
		public static GuidingChapterTriggerItem HaveLoopingBonus => Instance[(short)306];

		/// <summary>
		/// 首次触发灵光一闪
		/// </summary>
		public static GuidingChapterTriggerItem HaveReadingBonus => Instance[(short)307];

		/// <summary>
		/// 首次出现奇书入邪者时
		/// </summary>
		public static GuidingChapterTriggerItem Trigger312 => Instance[(short)308];

		/// <summary>
		/// 首次被其他人仇恨
		/// </summary>
		public static GuidingChapterTriggerItem Trigger313 => Instance[(short)309];

		/// <summary>
		/// 首次被其他人爱慕
		/// </summary>
		public static GuidingChapterTriggerItem Trigger314 => Instance[(short)310];

		/// <summary>
		/// 剩余至少1精力时选择过月
		/// </summary>
		public static GuidingChapterTriggerItem TimeBallPassMonthWithAcuPointRemain => Instance[(short)311];

		/// <summary>
		/// 商店界面首次出现任意高价商品、季节性商品、诸会宝号商品
		/// </summary>
		public static GuidingChapterTriggerItem ShopHasExtraGoods => Instance[(short)312];

		/// <summary>
		/// 任意一方的压力增长时
		/// </summary>
		public static GuidingChapterTriggerItem Trigger317 => Instance[(short)313];

		/// <summary>
		/// 任意同道首次入邪
		/// </summary>
		public static GuidingChapterTriggerItem Trigger318 => Instance[(short)314];

		/// <summary>
		/// 任意建筑受损时
		/// </summary>
		public static GuidingChapterTriggerItem Trigger319 => Instance[(short)315];

		/// <summary>
		/// 连接次数超过天资上限一半时
		/// </summary>
		public static GuidingChapterTriggerItem SkillBreakPlateOverHalf => Instance[(short)316];

		/// <summary>
		/// 进行过一次主动研读或周天
		/// </summary>
		public static GuidingChapterTriggerItem ActiveLoopOrReadTriggered => Instance[(short)317];

		/// <summary>
		/// 解锁志向有成技能时
		/// </summary>
		public static GuidingChapterTriggerItem FirstUnlockProfessionExtraSkill => Instance[(short)318];

		/// <summary>
		/// 解锁了传剑功能时
		/// </summary>
		public static GuidingChapterTriggerItem UnlockSwordLegacy => Instance[(short)319];

		/// <summary>
		/// 解锁采集功能后
		/// </summary>
		public static GuidingChapterTriggerItem UnlockCollectResource => Instance[(short)320];

		/// <summary>
		/// 解封到达100%进度且带有生铸效果
		/// </summary>
		public static GuidingChapterTriggerItem CombatCanUnlockAttackWithRawCreate => Instance[(short)321];

		/// <summary>
		/// 结束任意一场较艺时
		/// </summary>
		public static GuidingChapterTriggerItem Trigger327 => Instance[(short)322];

		/// <summary>
		/// 己方/敌方携带任意带解封效果的功法进入战斗
		/// </summary>
		public static GuidingChapterTriggerItem CombatUnlockAttackSkill => Instance[(short)323];

		/// <summary>
		/// 获取遗惠点数达到100
		/// </summary>
		public static GuidingChapterTriggerItem Trigger329 => Instance[(short)324];

		/// <summary>
		/// 获取任意生平遗惠时
		/// </summary>
		public static GuidingChapterTriggerItem Trigger330 => Instance[(short)325];

		/// <summary>
		/// 获得一只促织时
		/// </summary>
		public static GuidingChapterTriggerItem Trigger331 => Instance[(short)326];

		/// <summary>
		/// 关闭研读界面时研读的是技艺书籍
		/// </summary>
		public static GuidingChapterTriggerItem CloseReadingWithLifeSkillBook => Instance[(short)327];

		/// <summary>
		/// 发生首次论点冲突后
		/// </summary>
		public static GuidingChapterTriggerItem Trigger333 => Instance[(short)328];

		/// <summary>
		/// 对方使用功法让己方拥有蛊虫
		/// </summary>
		public static GuidingChapterTriggerItem CombatAcceptWugBySkill => Instance[(short)329];

		/// <summary>
		/// 对方开始施展任意摧破
		/// </summary>
		public static GuidingChapterTriggerItem CombatEnemyCastAttackSkill => Instance[(short)330];

		/// <summary>
		/// 当前健康以任意原因下降时
		/// </summary>
		public static GuidingChapterTriggerItem Trigger337 => Instance[(short)331];

		/// <summary>
		/// 存在任意没有入住居所的村民时
		/// </summary>
		public static GuidingChapterTriggerItem Trigger338 => Instance[(short)332];

		/// <summary>
		/// 触发一次指令清除CD效果
		/// </summary>
		public static GuidingChapterTriggerItem CombatTeammateCommandSkipCd => Instance[(short)333];

		/// <summary>
		/// 触发任意一个剑冢的二阶段后
		/// </summary>
		public static GuidingChapterTriggerItem CombatBossAddPhase => Instance[(short)334];

		/// <summary>
		/// 被敌人命中要害时
		/// </summary>
		public static GuidingChapterTriggerItem CombatAcceptCritical => Instance[(short)335];

		/// <summary>
		/// 诛魔试炼
		/// </summary>
		public static GuidingChapterTriggerItem Trigger342 => Instance[(short)336];

		/// <summary>
		/// 罗汉开悟
		/// </summary>
		public static GuidingChapterTriggerItem Trigger343 => Instance[(short)337];

		/// <summary>
		/// 独创心法
		/// </summary>
		public static GuidingChapterTriggerItem Trigger344 => Instance[(short)338];

		/// <summary>
		/// 生关死节
		/// </summary>
		public static GuidingChapterTriggerItem Trigger345 => Instance[(short)339];

		/// <summary>
		/// 改正修逆
		/// </summary>
		public static GuidingChapterTriggerItem Trigger346 => Instance[(short)340];

		/// <summary>
		/// 移宫易穴
		/// </summary>
		public static GuidingChapterTriggerItem Trigger347 => Instance[(short)341];

		/// <summary>
		/// 统筹方略
		/// </summary>
		public static GuidingChapterTriggerItem Trigger348 => Instance[(short)342];

		/// <summary>
		/// 寄托奇书
		/// </summary>
		public static GuidingChapterTriggerItem Trigger349 => Instance[(short)343];

		/// <summary>
		/// 孤鸾镜水谣
		/// </summary>
		public static GuidingChapterTriggerItem Trigger350 => Instance[(short)344];

		/// <summary>
		/// 造化生人
		/// </summary>
		public static GuidingChapterTriggerItem Trigger351 => Instance[(short)345];

		/// <summary>
		/// 天外游历
		/// </summary>
		public static GuidingChapterTriggerItem Trigger352 => Instance[(short)346];

		/// <summary>
		/// 天枢玄铸
		/// </summary>
		public static GuidingChapterTriggerItem Trigger353 => Instance[(short)347];

		/// <summary>
		/// 驱使古鼎
		/// </summary>
		public static GuidingChapterTriggerItem Trigger354 => Instance[(short)348];

		/// <summary>
		/// 鼎蛟淬身
		/// </summary>
		public static GuidingChapterTriggerItem Trigger355 => Instance[(short)349];

		/// <summary>
		/// 化魂仪式
		/// </summary>
		public static GuidingChapterTriggerItem Trigger356 => Instance[(short)350];

		/// <summary>
		/// 炼制王蛊
		/// </summary>
		public static GuidingChapterTriggerItem Trigger357 => Instance[(short)351];

		/// <summary>
		/// 驱动王蛊
		/// </summary>
		public static GuidingChapterTriggerItem Trigger358 => Instance[(short)352];

		/// <summary>
		/// 奇纹星斗
		/// </summary>
		public static GuidingChapterTriggerItem Trigger359 => Instance[(short)353];

		/// <summary>
		/// 调遣元鸡
		/// </summary>
		public static GuidingChapterTriggerItem Trigger360 => Instance[(short)354];

		/// <summary>
		/// 元鸡灵羽
		/// </summary>
		public static GuidingChapterTriggerItem Trigger361 => Instance[(short)355];

		/// <summary>
		/// 姬穸随行
		/// </summary>
		public static GuidingChapterTriggerItem Trigger362 => Instance[(short)356];

		/// <summary>
		/// 持印汲气
		/// </summary>
		public static GuidingChapterTriggerItem Trigger363 => Instance[(short)357];

		/// <summary>
		/// 三才护阵
		/// </summary>
		public static GuidingChapterTriggerItem Trigger364 => Instance[(short)358];

		/// <summary>
		/// 三魔乱阵
		/// </summary>
		public static GuidingChapterTriggerItem Trigger365 => Instance[(short)359];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static GuidingChapterTrigger Instance = new GuidingChapterTrigger();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Chapters", "TemplateId" };

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
		_dataArray.Add(new GuidingChapterTriggerItem(0, new List<short> { 104 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(1, new List<short> { 24 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(2, new List<short>(), 0));
		_dataArray.Add(new GuidingChapterTriggerItem(3, new List<short> { 346 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(4, new List<short> { 170, 328 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(5, new List<short> { 341 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(6, new List<short> { 340 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(7, new List<short> { 329 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(8, new List<short> { 115 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(9, new List<short> { 325 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(10, new List<short> { 319 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(11, new List<short> { 321 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(12, new List<short> { 332 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(13, new List<short> { 327 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(14, new List<short> { 333 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(15, new List<short> { 323 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(16, new List<short> { 330 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(17, new List<short> { 316 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(18, new List<short> { 324 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(19, new List<short> { 106, 107 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(20, new List<short> { 313 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(21, new List<short> { 320 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(22, new List<short> { 314 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(23, new List<short> { 318 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(24, new List<short> { 326 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(25, new List<short> { 304 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(26, new List<short> { 305 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(27, new List<short> { 306 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(28, new List<short> { 50 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(29, new List<short> { 131 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(30, new List<short> { 162 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(31, new List<short> { 151 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(32, new List<short> { 160 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(33, new List<short> { 168 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(34, new List<short> { 165 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(35, new List<short> { 166 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(36, new List<short> { 159 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(37, new List<short> { 154 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(38, new List<short> { 157 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(39, new List<short> { 158 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(40, new List<short> { 155 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(41, new List<short> { 156 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(42, new List<short> { 161 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(43, new List<short> { 153 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(44, new List<short> { 163 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(45, new List<short> { 167 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(46, new List<short> { 164 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(47, new List<short> { 152 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(48, new List<short> { 143 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(49, new List<short> { 147 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(50, new List<short> { 144 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(51, new List<short> { 34 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(52, new List<short> { 146 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(53, new List<short> { 32 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(54, new List<short> { 150 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(55, new List<short> { 149 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(56, new List<short> { 141 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(57, new List<short> { 142 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(58, new List<short> { 148 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(59, new List<short> { 145 }, 0));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new GuidingChapterTriggerItem(60, new List<short> { 57 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(61, new List<short>(), 0));
		_dataArray.Add(new GuidingChapterTriggerItem(62, new List<short> { 116 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(63, new List<short> { 221, 267, 271 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(64, new List<short> { 118 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(65, new List<short> { 189 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(66, new List<short> { 17 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(67, new List<short> { 42, 43, 46 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(68, new List<short> { 84 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(69, new List<short>
		{
			73, 74, 75, 76, 77, 78, 79, 80, 98, 99,
			101
		}, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(70, new List<short>(), 0));
		_dataArray.Add(new GuidingChapterTriggerItem(71, new List<short> { 40 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(72, new List<short> { 187 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(73, new List<short> { 41 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(74, new List<short> { 100, 354 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(75, new List<short> { 90 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(76, new List<short> { 335 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(77, new List<short> { 184, 185 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(78, new List<short> { 180, 181 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(79, new List<short> { 194, 195, 197 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(80, new List<short> { 133 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(81, new List<short> { 136 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(82, new List<short> { 280, 287 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(83, new List<short> { 289 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(84, new List<short> { 288 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(85, new List<short> { 279 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(86, new List<short> { 122 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(87, new List<short> { 89, 90 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(88, new List<short> { 201, 204, 206, 254 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(89, new List<short> { 296 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(90, new List<short> { 294 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(91, new List<short> { 38 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(92, new List<short> { 308 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(93, new List<short> { 310 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(94, new List<short> { 309 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(95, new List<short> { 293 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(96, new List<short> { 91, 93, 94, 95, 96, 97 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(97, new List<short> { 87 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(98, new List<short> { 32, 33 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(99, new List<short> { 292 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(100, new List<short> { 302 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(101, new List<short> { 102, 117 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(102, new List<short> { 334 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(103, new List<short> { 336 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(104, new List<short> { 338 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(105, new List<short> { 335 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(106, new List<short> { 336 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(107, new List<short> { 337 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(108, new List<short>(), 0));
		_dataArray.Add(new GuidingChapterTriggerItem(109, new List<short> { 179 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(110, new List<short> { 215 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(111, new List<short> { 44 }, 6));
		_dataArray.Add(new GuidingChapterTriggerItem(112, new List<short> { 207, 208, 209, 211 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(113, new List<short> { 4 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(114, new List<short> { 297 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(115, new List<short> { 299 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(116, new List<short> { 290 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(117, new List<short> { 304 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(118, new List<short> { 123 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(119, new List<short> { 274, 275, 278 }, 0));
	}

	private void CreateItems2()
	{
		_dataArray.Add(new GuidingChapterTriggerItem(120, new List<short> { 287 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(121, new List<short> { 36 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(122, new List<short> { 37 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(123, new List<short> { 119 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(124, new List<short> { 35 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(125, new List<short> { 291 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(126, new List<short> { 301 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(127, new List<short> { 88 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(128, new List<short> { 44 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(129, new List<short> { 298 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(130, new List<short> { 295 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(131, new List<short> { 199 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(132, new List<short> { 4 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(133, new List<short> { 311, 312 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(134, new List<short> { 191, 192, 193 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(135, new List<short> { 340 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(136, new List<short> { 342 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(137, new List<short> { 339 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(138, new List<short> { 303 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(139, new List<short>(), 0));
		_dataArray.Add(new GuidingChapterTriggerItem(140, new List<short> { 7 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(141, new List<short> { 178 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(142, new List<short> { 282 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(143, new List<short> { 273, 277 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(144, new List<short> { 283 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(145, new List<short> { 266 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(146, new List<short> { 256 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(147, new List<short> { 236 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(148, new List<short> { 269 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(149, new List<short> { 263 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(150, new List<short> { 222, 226 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(151, new List<short> { 270 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(152, new List<short> { 228 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(153, new List<short> { 111, 112, 113, 114 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(154, new List<short> { 272 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(155, new List<short> { 252 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(156, new List<short> { 358 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(157, new List<short> { 233, 235 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(158, new List<short> { 111, 113, 114 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(159, new List<short> { 238 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(160, new List<short> { 241 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(161, new List<short> { 246 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(162, new List<short> { 237, 268, 105 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(163, new List<short> { 244 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(164, new List<short> { 247 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(165, new List<short> { 245 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(166, new List<short> { 243 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(167, new List<short> { 242, 268 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(168, new List<short> { 239 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(169, new List<short> { 240 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(170, new List<short> { 261 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(171, new List<short> { 260 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(172, new List<short> { 259 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(173, new List<short> { 248 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(174, new List<short> { 262 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(175, new List<short> { 19, 20 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(176, new List<short> { 347 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(177, new List<short> { 27 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(178, new List<short> { 31 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(179, new List<short> { 51 }, 0));
	}

	private void CreateItems3()
	{
		_dataArray.Add(new GuidingChapterTriggerItem(180, new List<short> { 58, 52 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(181, new List<short> { 59 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(182, new List<short> { 60 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(183, new List<short> { 61, 52 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(184, new List<short> { 62, 52 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(185, new List<short> { 63, 52 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(186, new List<short> { 64, 52 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(187, new List<short> { 65, 52 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(188, new List<short> { 66, 52 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(189, new List<short> { 67, 52 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(190, new List<short> { 68 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(191, new List<short> { 69 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(192, new List<short> { 70, 52 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(193, new List<short> { 71 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(194, new List<short> { 72 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(195, new List<short> { 300 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(196, new List<short> { 8 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(197, new List<short> { 49 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(198, new List<short> { 48 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(199, new List<short> { 47 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(200, new List<short> { 22 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(201, new List<short> { 25 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(202, new List<short> { 212 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(203, new List<short> { 173 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(204, new List<short> { 53 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(205, new List<short> { 39 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(206, new List<short> { 174 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(207, new List<short> { 174 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(208, new List<short> { 14 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(209, new List<short> { 54 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(210, new List<short> { 55 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(211, new List<short> { 213 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(212, new List<short> { 13 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(213, new List<short> { 15 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(214, new List<short> { 10 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(215, new List<short> { 137 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(216, new List<short> { 135 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(217, new List<short> { 135 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(218, new List<short> { 139 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(219, new List<short> { 132 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(220, new List<short> { 140 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(221, new List<short> { 134 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(222, new List<short> { 343 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(223, new List<short> { 85 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(224, new List<short> { 312 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(225, new List<short> { 49 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(226, new List<short> { 21 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(227, new List<short> { 258 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(228, new List<short>(), 0));
		_dataArray.Add(new GuidingChapterTriggerItem(229, new List<short> { 272 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(230, new List<short> { 171 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(231, new List<short> { 169 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(232, new List<short> { 170 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(233, new List<short> { 336 }, 20));
		_dataArray.Add(new GuidingChapterTriggerItem(234, new List<short> { 337 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(235, new List<short> { 198 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(236, new List<short> { 204 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(237, new List<short> { 108 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(238, new List<short> { 172 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(239, new List<short> { 6 }, 0));
	}

	private void CreateItems4()
	{
		_dataArray.Add(new GuidingChapterTriggerItem(240, new List<short> { 38, 39 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(241, new List<short> { 0 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(242, new List<short> { 26 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(243, new List<short> { 88 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(244, new List<short> { 5 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(245, new List<short> { 255 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(246, new List<short> { 121 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(247, new List<short> { 120 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(248, new List<short> { 331 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(249, new List<short> { 355 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(250, new List<short> { 265 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(251, new List<short> { 108 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(252, new List<short> { 109 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(253, new List<short> { 344 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(254, new List<short> { 83 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(255, new List<short> { 82 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(256, new List<short> { 7 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(257, new List<short> { 138 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(258, new List<short> { 356 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(259, new List<short> { 249 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(260, new List<short> { 202, 203 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(261, new List<short> { 317 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(262, new List<short> { 322 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(263, new List<short> { 315 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(264, new List<short> { 210 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(265, new List<short> { 92 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(266, new List<short> { 182 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(267, new List<short> { 207 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(268, new List<short> { 81 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(269, new List<short> { 270 }, 100));
		_dataArray.Add(new GuidingChapterTriggerItem(270, new List<short> { 341 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(271, new List<short> { 106 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(272, new List<short> { 110 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(273, new List<short> { 250, 251 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(274, new List<short> { 230 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(275, new List<short> { 349 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(276, new List<short> { 29 }, 50));
		_dataArray.Add(new GuidingChapterTriggerItem(277, new List<short> { 28 }, 100));
		_dataArray.Add(new GuidingChapterTriggerItem(278, new List<short> { 205 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(279, new List<short> { 229, 223, 224, 225, 227 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(280, new List<short> { 100, 217, 218 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(281, new List<short> { 220 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(282, new List<short> { 201 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(283, new List<short> { 12 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(284, new List<short> { 350 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(285, new List<short> { 200 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(286, new List<short> { 284, 285, 286 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(287, new List<short> { 281 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(288, new List<short> { 9 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(289, new List<short> { 86 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(290, new List<short> { 111 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(291, new List<short> { 130 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(292, new List<short> { 253 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(293, new List<short> { 128 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(294, new List<short> { 264 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(295, new List<short> { 126 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(296, new List<short> { 183 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(297, new List<short> { 129 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(298, new List<short> { 124 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(299, new List<short> { 127 }, 0));
	}

	private void CreateItems5()
	{
		_dataArray.Add(new GuidingChapterTriggerItem(300, new List<short> { 18 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(301, new List<short> { 125 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(302, new List<short> { 307 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(303, new List<short> { 179 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(304, new List<short> { 234 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(305, new List<short> { 281 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(306, new List<short> { 188 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(307, new List<short> { 186 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(308, new List<short> { 216 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(309, new List<short> { 121 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(310, new List<short> { 120 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(311, new List<short> { 190 }, 10));
		_dataArray.Add(new GuidingChapterTriggerItem(312, new List<short> { 45 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(313, new List<short> { 359 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(314, new List<short> { 6 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(315, new List<short> { 276 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(316, new List<short> { 196 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(317, new List<short> { 190 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(318, new List<short> { 345 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(319, new List<short> { 1, 2, 3 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(320, new List<short> { 23 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(321, new List<short> { 232 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(322, new List<short> { 360 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(323, new List<short> { 231 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(324, new List<short> { 2 }, 100));
		_dataArray.Add(new GuidingChapterTriggerItem(325, new List<short> { 3 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(326, new List<short> { 348 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(327, new List<short> { 178 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(328, new List<short> { 357 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(329, new List<short> { 112 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(330, new List<short> { 257 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(331, new List<short> { 103 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(332, new List<short> { 290 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(333, new List<short> { 266 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(334, new List<short> { 11 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(335, new List<short> { 228 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(336, new List<short> { 361 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(337, new List<short> { 362 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(338, new List<short> { 363 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(339, new List<short> { 364 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(340, new List<short> { 365 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(341, new List<short> { 366 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(342, new List<short> { 368 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(343, new List<short> { 369 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(344, new List<short> { 371 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(345, new List<short> { 372 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(346, new List<short> { 373 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(347, new List<short> { 374 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(348, new List<short> { 375 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(349, new List<short> { 376 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(350, new List<short> { 377 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(351, new List<short> { 378 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(352, new List<short> { 379 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(353, new List<short> { 380 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(354, new List<short> { 381 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(355, new List<short> { 382 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(356, new List<short> { 386 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(357, new List<short> { 383 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(358, new List<short> { 384 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(359, new List<short> { 385 }, 0));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<GuidingChapterTriggerItem>(360);
		CreateItems0();
		CreateItems1();
		CreateItems2();
		CreateItems3();
		CreateItems4();
		CreateItems5();
	}
}
